using Certificate.Models;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace Certificate.Services
{
    class CertificateService : IDisposable
    {
        private readonly string pathDirectory;

        private readonly string templatePath;

        /// <summary>
        /// Проверяет доступность шаблона
        /// </summary>
        public bool IsTemplateAvailable => File.Exists(templatePath);

        /// <summary>
        /// Возвращает путь к шаблону
        /// </summary>
        public string TemplatePath => templatePath;

        public CertificateService(string pathDefault)
        {
            pathDirectory = pathDefault;
            templatePath = Path.Combine(pathDirectory, "Certificate.xlsx");
            ValidateTemplate();
        }
        private void ValidateTemplate()
        {
            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException($"Шаблон сертификата не найден: {templatePath}");
            }
        }
        /// <summary>
        /// Создает PDF по указанному пути
        /// </summary>
        public void GeneratePdf(CertificateData data, string outputPath)
        {
            if (string.IsNullOrWhiteSpace(outputPath))
                throw new ArgumentException("Путь для сохранения не может быть пустым");

            // Создаем папку если не существует
            string directory = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            CreatePdfInternal(data, outputPath);
        }

        /// <summary>
        /// Создает временный PDF для предпросмотра
        /// </summary>
        public string GenerateTemporaryPdf(CertificateData data)
        {
            string tempPath = Path.Combine(pathDirectory, $"CertPreview_{data.CertificateNumber}.pdf");
            if (File.Exists(tempPath))
            {
                return tempPath;
            }
            CreatePdfInternal(data, tempPath);
            return tempPath;
        }

        /// <summary>
        /// Создает PDF с дефолтным именем в папке Certificates
        /// </summary>
        public string GenerateDefaultPdf(CertificateData data)
        {
            string certificatesFolder = Path.Combine(Path.GetDirectoryName(templatePath), "Certificates");
            if (!Directory.Exists(certificatesFolder))
            {
                Directory.CreateDirectory(certificatesFolder);
            }

            string fileName = $"Certificate_{data.CertificateNumber:D3}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string outputPath = Path.Combine(certificatesFolder, fileName);

            CreatePdfInternal(data, outputPath);
            return outputPath;
        }

        private void CreatePdfInternal(CertificateData data, string outputPath)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            Workbook workbook = null;
            Worksheet worksheet = null;

            try
            {
                // Открываем Excel
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;

                // Открываем шаблон как копию
                workbook = excelApp.Workbooks.Open(templatePath, ReadOnly: false);
                worksheet = workbook.ActiveSheet;

                // Заполняем данные
                FillCertificateData(worksheet, data);

                // Настройки печати
                SetupPrintSettings(worksheet);

                // Экспорт в PDF
                worksheet.ExportAsFixedFormat(
                    XlFixedFormatType.xlTypePDF,
                    outputPath,
                    XlFixedFormatQuality.xlQualityStandard,
                    true,  // IncludeDocProps
                    false, // IgnorePrintAreas  
                    Type.Missing,
                    Type.Missing,
                    false  // OpenAfterPublish
                );
            }
            finally
            {
                // Закрываем без сохранения (оригинал остается нетронутым)
                workbook?.Close(false);
                excelApp?.Quit();

                // Освобождение ресурсов COM
                if (worksheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                if (workbook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                if (excelApp != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
        }

        private void FillCertificateData(Worksheet worksheet, CertificateData data)
        {
            string fullSertificate = $"{data.ContractNumber}/{data.CertificateNumber}";

            worksheet.Cells[2, 5] = fullSertificate;                        // E2 - Договор/Сертификат
            worksheet.Cells[2, 11] = data.IssueDate.ToString("dd.MM.yyyy"); // K2 - Дата оформления
            worksheet.Cells[12, 3] = data.CarModel;                         // C12 - Марка машины
            worksheet.Cells[12, 12] = data.Year;                            // L12 - Год выпуска
            worksheet.Cells[13, 2] = data.VIN;                              // B13 - Вин номер
            worksheet.Cells[13, 6] = data.RegNumber;                        // F13 - Регистрационый знак
            worksheet.Cells[13, 10] = data.RegistrationDoc;                 // J13 - Свидетельство о регистрации
            worksheet.Cells[13, 12] = data.DateRegDoc;                      // L13 - Дата регистрации
            worksheet.Cells[18, 6] = data.ValidFrom;                        // F18 - Дата начала
            worksheet.Cells[18, 10] = data.ValidTo;                         // J18 - Дата окончания
            worksheet.Cells[8, 2] = data.OwnerName;                         // B8 - ФИО
            worksheet.Cells[8, 11] = data.Phone;                            // K8 - Телефон
        }

        private void SetupPrintSettings(Worksheet worksheet)
        {
            worksheet.PageSetup.Orientation = XlPageOrientation.xlPortrait;

            worksheet.PageSetup.LeftMargin = 0.1 * 72;    // ~0.1 дюйма (2.5 мм)
            worksheet.PageSetup.RightMargin = 0.1 * 72;
            worksheet.PageSetup.TopMargin = 0.1 * 72;     // ~0.1 дюйма (2.5 мм)
            worksheet.PageSetup.BottomMargin = 0.1 * 72;
            worksheet.PageSetup.HeaderMargin = 0;
            worksheet.PageSetup.FooterMargin = 0;

            // 3. Отключить автоматический масштаб (если он мешает)
            worksheet.PageSetup.Zoom = false;

            // 4. Вписать в ОДНУ страницу (но без искажений)
            worksheet.PageSetup.FitToPagesWide = 1;
            worksheet.PageSetup.FitToPagesTall = 1;

            // 5. Убедиться, что печатается только нужная область
            worksheet.PageSetup.PrintArea = "A1:L61";
        }

        /// <summary>
        /// Удаляет старые временные файлы предпросмотра
        /// </summary>
        private void CleanupOldTempFiles()
        {
            try
            {
                var tempFiles = Directory.GetFiles(pathDirectory, "CertPreview_*.pdf");
                foreach (var file in tempFiles)
                {
                    try
                    {
                        if (File.GetCreationTime(file) < DateTime.Now.AddHours(-1))
                        {
                            File.Delete(file);
                        }
                    }
                    catch
                    {
                        
                    }
                }
            }
            catch
            {
                
            }
        }

        public void Dispose()
        {
            CleanupOldTempFiles();
        }
    }
}
