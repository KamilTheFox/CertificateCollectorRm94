using System;
using System.Data;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace Certificate.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Certificate.Models;
    using Microsoft.Office.Interop.Excel;

    public class RegistryService : IDisposable
    {
        private readonly string pathDirectory;
        private readonly string registryFilePath;
        private readonly string backupDirectory;
        private List<CertificateData> certificates;

        // Excel объекты для сохранения
        private Microsoft.Office.Interop.Excel.Application excelApp;
        private Workbook workbook;
        private Worksheet worksheet;

        public string[] HEADERS { get; private set; } = new string[]
            {
                "№ Сертификата", "Дата оформления", "Срок ОТ", "Срок ДО",
                "ФИО владельца", "Телефон", "Марка/Модель", "Год", "VIN",
                "Рег. знак", "СТС", "Дата СТС", "Дата замены стекла", "Примечание", "Цена стекла", "Страховая премия" 
            };

        public RegistryService(string pathDefault)
        {
            pathDirectory = pathDefault;
            registryFilePath = Path.Combine(pathDirectory, "Registry.xlsx");
            backupDirectory = Path.Combine(pathDirectory, "Backups");

            certificates = new List<CertificateData>();

            EnsureDirectoriesExist();
            LoadFromExcel();
        }

        #region Initialization

        private void EnsureDirectoriesExist()
        {
            if (!Directory.Exists(pathDirectory))
                Directory.CreateDirectory(pathDirectory);

            if (!Directory.Exists(backupDirectory))
                Directory.CreateDirectory(backupDirectory);
        }

        private void LoadFromExcel()
        {
            try
            {
                InitializeExcel();
                certificates = ParseExcelData();
            }
            catch (Exception ex)
            {
                Dispose();
                throw new InvalidOperationException($"Ошибка загрузки реестра: {ex.Message}", ex);
            }
        }

        private void InitializeExcel()
        {
            excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = false;
            excelApp.DisplayAlerts = false;

            if(File.Exists(registryFilePath))
                workbook = excelApp.Workbooks.Open(registryFilePath);
            else
            {
                workbook = excelApp.Workbooks.Add();
                CreateDefaultWorksheet();
                workbook.SaveAs(registryFilePath);
            }

            SelectWorksheet("Реестр");
        }

        private void SelectWorksheet(string sheetName)
        {
            try
            {
                worksheet = workbook.Sheets[sheetName];
            }
            catch
            {
                worksheet = workbook.Sheets.Add();
                worksheet.Name = sheetName;
                WriteHeaders();
            }
        }

        private void CreateDefaultWorksheet()
        {
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Реестр";
            WriteHeaders();
        }

        private void WriteHeaders()
        {

            for (int i = 0; i < HEADERS.Length; i++)
            {
                worksheet.Cells[1, i + 1] = HEADERS[i];
            }

            Range headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, HEADERS.Length]];
            headerRange.Font.Bold = true;
            headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
        }

        private List<CertificateData> ParseExcelData()
        {
            var result = new List<CertificateData>();

            if (worksheet.UsedRange == null) return result;

            Range usedRange = worksheet.UsedRange;
            int rowCount = usedRange.Rows.Count;

            for (int row = 2; row <= rowCount; row++)
            {
                try
                {
                    var cert = new CertificateData
                    {
                        CertificateNumber = Convert.ToInt32(worksheet.Cells[row, 1].Value ?? 0),
                        IssueDate = ParseDate(worksheet.Cells[row, 2].Value),
                        ValidFrom = ParseDate(worksheet.Cells[row, 3].Value),
                        ValidTo = ParseDate(worksheet.Cells[row, 4].Value),
                        OwnerName = worksheet.Cells[row, 5].Value?.ToString() ?? "",
                        Phone = worksheet.Cells[row, 6].Value?.ToString() ?? "",
                        CarModel = worksheet.Cells[row, 7].Value?.ToString() ?? "",
                        Year = Convert.ToInt32(worksheet.Cells[row, 8].Value ?? 0),
                        VIN = worksheet.Cells[row, 9].Value?.ToString() ?? "",
                        RegNumber = worksheet.Cells[row, 10].Value?.ToString() ?? "",
                        RegistrationDoc = worksheet.Cells[row, 11].Value?.ToString() ?? "",
                        DateRegDoc = ParseDate(worksheet.Cells[row, 12].Value),
                        DateGlassReplacement = ParseDate(worksheet.Cells[row, 13].Value),
                        Note = worksheet.Cells[row, 14].Value?.ToString() ?? "",
                        PriceGlass = Convert.ToInt32(worksheet.Cells[row, 15].Value ?? 0),
                        Premium = Convert.ToInt32(worksheet.Cells[row, 16].Value ?? 0)
                    };

                    if (cert.CertificateNumber > 0)
                    {
                        result.Add(cert);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Ошибка парсинга строки {row}: {ex.Message}");
                }
            }

            return result;
        }

        private DateTime ParseDate(object value)
        {
            if (value == null) return DateTime.MinValue;

            if (value is DateTime dt) return dt;

            if (DateTime.TryParse(value.ToString(), out DateTime result))
                return result;

            return DateTime.MinValue;
        }

        #endregion

        #region Public Properties

        public int Count => certificates.Count;

        public int LastCertificate => certificates.Count == 0 ? 0 : certificates.Max(cert => cert.CertificateNumber);

        public bool HasData => certificates.Any();
        public IReadOnlyList<CertificateData> AllCertificates => certificates.AsReadOnly();

        #endregion

        #region Search Methods

        /// <summary>
        /// Поиск сертификата по номеру
        /// </summary>
        public CertificateData FindByCertificateNumber(int certificateNumber)
        {
            return certificates.FirstOrDefault(c => c.CertificateNumber == certificateNumber);
        }
        /// <summary>
        /// Поиск сертификата по диапозону номеров
        /// </summary>
        public List<CertificateData> FindByCertificateNumbers(int certificateNumberFirst, int certificateNumberLast)
        {
            return certificates.Where(c => c.CertificateNumber >= certificateNumberFirst && c.CertificateNumber <= certificateNumberLast).ToList();
        }

        /// <summary>
        /// Поиск сертификатов по VIN номеру
        /// </summary>
        public List<CertificateData> FindByVIN(string vin)
        {
            if (string.IsNullOrWhiteSpace(vin)) return new List<CertificateData>();

            string search = vin.ToLower();

            return certificates
                .Where(c =>
                    c.VIN.ToLower().Contains(search) 
                )
                .OrderByDescending(c => c.IssueDate)
                .ToList();
        }

        /// <summary>
        /// Поиск сертификатов по номеру телефона
        /// </summary>
        public List<CertificateData> FindByPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return new List<CertificateData>();

            string cleanPhone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            return certificates
                .Where(c => c.Phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Contains(cleanPhone))
                .OrderByDescending(c => c.IssueDate)
                .ToList();
        }

        /// <summary>
        /// Поиск сертификатов по дате оформления
        /// </summary>
        public List<CertificateData> FindByIssueDate(DateTime fromDate, DateTime toDate)
        {
            return certificates
                .Where(c => c.IssueDate >= fromDate && c.IssueDate <= toDate)
                .OrderByDescending(c => c.IssueDate)
                .ToList();
        }

        /// <summary>
        /// Получить все сертификаты действующие на указанную дату
        /// </summary>
        public List<CertificateData> GetActiveCertificates(DateTime checkDate)
        {
            return certificates
                .Where(c => checkDate >= c.ValidFrom && checkDate <= c.ValidTo)
                .OrderByDescending(c => c.IssueDate)
                .ToList();
        }

        /// <summary>
        /// Получить все действующие на сегодня сертификаты
        /// </summary>
        public List<CertificateData> GetCurrentlyActiveCertificates()
        {
            return GetActiveCertificates(DateTime.Today);
        }

        /// <summary>
        /// Поиск сертификатов истекающих в ближайшее время
        /// </summary>
        public List<CertificateData> GetExpiringSoon(int daysAhead = 30)
        {
            DateTime checkDate = DateTime.Today.AddDays(daysAhead);

            return certificates
                .Where(c => c.ValidTo <= checkDate && c.ValidTo >= DateTime.Today)
                .OrderBy(c => c.ValidTo)
                .ToList();
        }

        /// <summary>
        /// Универсальный поиск по тексту
        /// </summary>
        public List<CertificateData> Search(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText)) return certificates.ToList();

            string search = searchText.ToLower();

            return certificates
                .Where(c =>
                    c.CertificateNumber.ToString().Contains(search) ||
                    c.OwnerName.ToLower().Contains(search) ||
                    c.Phone.Contains(search) ||
                    c.CarModel.ToLower().Contains(search) ||
                    c.VIN.ToLower().Contains(search) ||
                    c.RegNumber.ToLower().Contains(search) ||
                    c.Note.ToLower().Contains(search)
                )
                .OrderByDescending(c => c.IssueDate)
                .ToList();
        }

        #endregion


        #region Modification Methods

        /// <summary>
        /// Добавить новый сертификат
        /// </summary>
        public int AddCertificate(CertificateData certificate)
        {
            int newNumber = certificates.Any() ? LastCertificate + 1 : 1;
            certificate.CertificateNumber = newNumber;

            certificates.Add(certificate);
            return newNumber;
        }

        /// <summary>
        /// Обновить существующий сертификат
        /// </summary>
        public bool UpdateCertificate(CertificateData certificate)
        {
            var index = certificates.FindIndex(c => c.CertificateNumber == certificate.CertificateNumber);
            if (index >= 0)
            {
                certificates[index] = certificate;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Удалить сертификат
        /// </summary>
        public bool RemoveCertificate(int certificateNumber)
        {
            return certificates.RemoveAll(c => c.CertificateNumber == certificateNumber) > 0;
        }

        #endregion

        #region Save and Backup

        /// <summary>
        /// Сохранить изменения в Excel
        /// </summary>
        public void SaveToExcel()
        {
            try
            {
                WriteDataToExcel();
                workbook.Save();
            }
            catch (Exception ex)
            {
                Dispose();
                throw new InvalidOperationException($"Ошибка сохранения реестра: {ex.Message}", ex);
            }
        }

        private void WriteDataToExcel()
        {
            if (worksheet.UsedRange != null && worksheet.UsedRange.Rows.Count > 1)
            {
                Range dataRange = worksheet.Range[
                    worksheet.Cells[2, 1],
                    worksheet.Cells[worksheet.UsedRange.Rows.Count, worksheet.UsedRange.Columns.Count]
                ];
                dataRange.Delete();
            }

            // Записываем данные
            for (int i = 0; i < certificates.Count; i++)
            {
                var cert = certificates[i];
                int row = i + 2; // Начинаем с 2-й строки

                worksheet.Cells[row, 1] = cert.CertificateNumber;
                worksheet.Cells[row, 2] = cert.IssueDate != DateTime.MinValue ? cert.IssueDate.ToString("dd.MM.yyyy") : "";
                worksheet.Cells[row, 3] = cert.ValidFrom != DateTime.MinValue ? cert.ValidFrom.ToString("dd.MM.yyyy") : "";
                worksheet.Cells[row, 4] = cert.ValidTo != DateTime.MinValue ? cert.ValidTo.ToString("dd.MM.yyyy") : "";
                worksheet.Cells[row, 5] = cert.OwnerName;
                worksheet.Cells[row, 6] = cert.Phone;
                worksheet.Cells[row, 7] = cert.CarModel;
                worksheet.Cells[row, 8] = cert.Year > 0 ? cert.Year.ToString() : "";
                worksheet.Cells[row, 9] = cert.VIN;
                worksheet.Cells[row, 10] = cert.RegNumber;
                worksheet.Cells[row, 11] = cert.RegistrationDoc;
                worksheet.Cells[row, 12] = cert.DateRegDoc != DateTime.MinValue ? cert.DateRegDoc.ToString("dd.MM.yyyy") : "";
                worksheet.Cells[row, 13] = cert.DateGlassReplacement != DateTime.MinValue ? cert.DateGlassReplacement.ToString("dd.MM.yyyy") : "";
                worksheet.Cells[row, 14] = cert.Note;
                worksheet.Cells[row, 15] = cert.PriceGlass;
                worksheet.Cells[row, 16] = cert.Premium;
            }

            worksheet.Columns.AutoFit();
        }

        /// <summary>
        /// Создать backup файла
        /// </summary>
        public void CreateBackup()
        {
            try
            {
                if (File.Exists(registryFilePath))
                {
                    string backupFileName = $"Registry_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                    string backupPath = Path.Combine(backupDirectory, backupFileName);
                    File.Copy(registryFilePath, backupPath);

                    // Удаляем старые backups (оставляем только последние 10)
                    CleanupOldBackups();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка создания backup: {ex.Message}");
            }
        }

        private void CleanupOldBackups()
        {
            try
            {
                var backupFiles = Directory.GetFiles(backupDirectory, "Registry_Backup_*.xlsx")
                    .Select(f => new FileInfo(f))
                    .OrderByDescending(f => f.CreationTime)
                    .ToList();

                // Удаляем все файлы кроме последних 10
                foreach (var file in backupFiles.Skip(10))
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка очистки backup: {ex.Message}");
            }
        }

        #endregion

        #region Statistics

        public RegistryStatistics GetStatistics()
        {
            var today = DateTime.Today;
            var stats = new RegistryStatistics
            {
                TotalCertificates = certificates.Count,
                ActiveCertificates = certificates.Count(c => today >= c.ValidFrom && today <= c.ValidTo),
                ExpiredCertificates = certificates.Count(c => c.ValidTo < today),
                ExpiringSoon = certificates.Count(c => c.ValidTo <= today.AddDays(30) && c.ValidTo >= today)
            };

            if (certificates.Any())
            {
                stats.LatestIssueDate = certificates.Max(c => c.IssueDate);
                stats.EarliestIssueDate = certificates.Min(c => c.IssueDate);
            }

            return stats;
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    SaveToExcel();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error Save");
                }
            }
            try
            {
                workbook?.Close();
                excelApp?.Quit();
                if (worksheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                if (workbook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                if (excelApp != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            catch
            {
            }
        }
        #endregion
    }
}
