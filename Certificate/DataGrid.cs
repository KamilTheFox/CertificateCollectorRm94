using Certificate.Models;
using Certificate.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Certificate
{
    public partial class DataGrid: Form
    {
        RegistryService registryService;

        private BindingList<CertificateData> displayData;

        public DataGrid(RegistryService registry)
        {
            InitializeComponent();
            // Инициализация сервиса
            registryService = registry;

            // Настройка DataGridView
            SetupDataGridView();

            // Загрузка данных
            LoadAllData();

        }

        private void SetupDataGridView()
        {
            // Основные настройки
            dataGridRegistry.AllowUserToAddRows = false;
            dataGridRegistry.AllowUserToDeleteRows = false;
            dataGridRegistry.ReadOnly = true;
            dataGridRegistry.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridRegistry.MultiSelect = true;
            dataGridRegistry.AutoGenerateColumns = false;

            // Создаем колонки
            CreateColumns();
        }

        private void CreateColumns()
        {
            dataGridRegistry.Columns.Clear();

            // Номер сертификата
            dataGridRegistry.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CertificateNumber",
                HeaderText = "№ Сертификата",
                Name = "CertificateNumber",
                Width = 100,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Дата оформления
            dataGridRegistry.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IssueDate",
                HeaderText = "Дата оформления",
                Name = "IssueDate",
                Width = 100,
                DefaultCellStyle = { Format = "dd.MM.yyyy" }
            });

            // Срок ОТ
            dataGridRegistry.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ValidFrom",
                HeaderText = "Срок ОТ",
                Name = "ValidFrom",
                Width = 100,
                DefaultCellStyle = { Format = "dd.MM.yyyy" }
            });

            // Срок ДО
            dataGridRegistry.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ValidTo",
                HeaderText = "Срок ДО",
                Name = "ValidTo",
                Width = 100,
                DefaultCellStyle = { Format = "dd.MM.yyyy" }
            });

            // ФИО владельца
            dataGridRegistry.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OwnerName",
                HeaderText = "ФИО владельца",
                Name = "OwnerName",
                Width = 200
            });

            // Телефон
            dataGridRegistry.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "Телефон",
                Name = "Phone",
                Width = 120
            });

            // Марка/Модель
            dataGridRegistry.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CarModel",
                HeaderText = "Марка/Модель",
                Name = "CarModel",
                Width = 150
            });

            // Год
            dataGridRegistry.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Year",
                HeaderText = "Год",
                Name = "Year",
                Width = 60,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // VIN
            dataGridRegistry.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VIN",
                HeaderText = "VIN",
                Name = "VIN",
                Width = 150
            });

            // Рег. знак
            dataGridRegistry.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RegNumber",
                HeaderText = "Рег. знак",
                Name = "RegNumber",
                Width = 100
            });

            // СТС
            dataGridRegistry.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RegistrationDoc",
                HeaderText = "СТС",
                Name = "RegistrationDoc",
                Width = 120
            });

            // Дата СТС
            dataGridRegistry.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DateRegDoc",
                HeaderText = "Дата СТС",
                Name = "DateRegDoc",
                Width = 100,
                DefaultCellStyle = { Format = "dd.MM.yyyy" }
            });

            // Дата замены стекла
            dataGridRegistry.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DateGlassReplacement",
                HeaderText = "Дата замены стекла",
                Name = "DateGlassReplacement",
                Width = 130,
                DefaultCellStyle = { Format = "dd.MM.yyyy" }
            });

            // Примечание
            dataGridRegistry.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Note",
                HeaderText = "Примечание",
                Name = "Note",
                Width = 150
            });
            //Цена стекла
            dataGridRegistry.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PriceGlass",
                HeaderText = "Цена стекла",
                Name = "PriceGlass",
                Width = 150
            });
            //Страховая премия
            dataGridRegistry.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Premium",
                HeaderText = "Страховая премия",
                Name = "Premium",
                Width = 150
            });
        }

        private void LoadAllData()
        {
            try
            {
                ValidateGrid(registryService.AllCertificates.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateGrid(List<CertificateData> ts)
        {
            displayData = new BindingList<CertificateData>(ts);

            dataGridRegistry.DataSource = displayData;
        }

        #region Export to Excel

        private void OnExportExcelClick(object sender, EventArgs e)
        {
            if (displayData.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта", "Информация");
                return;
            }

            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel файлы (*.xlsx)|*.xlsx|Все файлы (*.*)|*.*";
                saveDialog.DefaultExt = "xlsx";
                saveDialog.FileName = $"Registry_Export_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                saveDialog.Title = "Экспорт реестра в Excel";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportToExcel(saveDialog.FileName);

                        var result = MessageBox.Show(
                            $"Экспорт завершен!\nФайл: {Path.GetFileName(saveDialog.FileName)}\n\nОткрыть файл?",
                            "Экспорт завершен",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information
                        );

                        if (result == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportToExcel(string filePath)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;

                workbook = excelApp.Workbooks.Add();
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Реестр сертификатов";

                // Заголовки
                string[] headers = registryService.HEADERS;

                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[1, i + 1] = headers[i];
                }

                // Форматирование заголовков
                var headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, headers.Length]];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);

                // Данные
                for (int row = 0; row < displayData.Count; row++)
                {
                    var cert = displayData[row];
                    int excelRow = row + 2;

                    worksheet.Cells[excelRow, 1] = cert.CertificateNumber;
                    worksheet.Cells[excelRow, 2] = cert.IssueDate != DateTime.MinValue ? cert.IssueDate.ToString("dd.MM.yyyy") : "";
                    worksheet.Cells[excelRow, 3] = cert.ValidFrom != DateTime.MinValue ? cert.ValidFrom.ToString("dd.MM.yyyy") : "";
                    worksheet.Cells[excelRow, 4] = cert.ValidTo != DateTime.MinValue ? cert.ValidTo.ToString("dd.MM.yyyy") : "";
                    worksheet.Cells[excelRow, 5] = cert.OwnerName;
                    worksheet.Cells[excelRow, 6] = cert.Phone;
                    worksheet.Cells[excelRow, 7] = cert.CarModel;
                    worksheet.Cells[excelRow, 8] = cert.Year > 0 ? cert.Year.ToString() : "";
                    worksheet.Cells[excelRow, 9] = cert.VIN;
                    worksheet.Cells[excelRow, 10] = cert.RegNumber;
                    worksheet.Cells[excelRow, 11] = cert.RegistrationDoc;
                    worksheet.Cells[excelRow, 12] = cert.DateRegDoc != DateTime.MinValue ? cert.DateRegDoc.ToString("dd.MM.yyyy") : "";
                    worksheet.Cells[excelRow, 13] = cert.DateGlassReplacement != DateTime.MinValue ? cert.DateGlassReplacement.ToString("dd.MM.yyyy") : "";
                    worksheet.Cells[excelRow, 14] = cert.Note;
                    worksheet.Cells[excelRow, 15] = cert.PriceGlass;
                    worksheet.Cells[excelRow, 16] = cert.Premium;
                }

                // Автоподбор ширины колонок
                worksheet.Columns.AutoFit();

                // Сохранение
                workbook.SaveAs(filePath);
            }
            finally
            {
                // Освобождение ресурсов
                workbook?.Close();
                excelApp?.Quit();

                if (worksheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                if (workbook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                if (excelApp != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
        }

        #endregion

        private void showAllbutton_Click(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void searchBy_Click(object sender, EventArgs e)
        {
            ValidateGrid(registryService.Search(textBoxSearchBy.Text));

        }

        private void buttonExpiring_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBoxExpiring.Text, out int input))
                ValidateGrid(registryService.GetExpiringSoon(input));
        }

        private void buttonActiveCertificates_Click(object sender, EventArgs e)
        {
            ValidateGrid(registryService.GetActiveCertificates(dateTimePickerActiveCertificates.Value));
        }

        private void buttonFindByIssue_Click(object sender, EventArgs e)
        {
            ValidateGrid(registryService.FindByIssueDate(
                dateTimePickerFrom.Value,
                dateTimePickerTo.Value
                ));
        }

        private void buttonFindPhone_Click(object sender, EventArgs e)
        {
            ValidateGrid(registryService.FindByPhone(
                textBoxFindPhone.Text));
        }

        private void buttonFindByVIN_Click(object sender, EventArgs e)
        {
            ValidateGrid(registryService.FindByVIN(
                textBoxFindByVIN.Text));
        }

        private void buttonFindByNumber_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxFindByNumber.Text, out int input))
                ValidateGrid(new List<CertificateData>() { registryService.FindByCertificateNumber(input) });
        }

        private void buttonFindByNumbers_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxFindByNumbersFirst.Text, out int num1) && int.TryParse(textBoxFindByNumbersSecond.Text, out int num2))
                ValidateGrid(registryService.FindByCertificateNumbers(num1, num2));
        }
    }
}

