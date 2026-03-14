using Certificate.Models;
using Certificate.Properties;
using Certificate.Services;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Certificate
{
    public partial class MainMenu: Form
    {
        private string pathDirectory;

        private readonly MainMenu instance;

        private const string FILE_NAME = "settings.json";

        private RegistryService RegistryService { get; set; }

        private CertificateService SertificateService { get; set; }

        private DataGrid dataGridWindow;

        WebView2 webView;

        private string pathTempPDF;

        private SettingsData settingsData;

        public MainMenu()
        {
            instance = this;
            InitializeComponent();
            pathDirectory = GetRegistryPath();
            RegistryService = new RegistryService(pathDirectory);
            SertificateService = new CertificateService(pathDirectory);
            InitializeSettings();
            ValidateTextBoxAddDay();

            InitWebView();

            textBoxContractNumber.Text = "000000-000-000000";
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseApp();
        }
        private void CloseApp()
        {
            settingsData.Data = CreateCertificateData();
            File.WriteAllText(FILE_NAME, JsonSerializer.Serialize(settingsData));
            webView.Dispose();
            RegistryService.Dispose();
            SertificateService.Dispose();
        }
        private void InitializeSettings()
        {
            if (!File.Exists(FILE_NAME))
            {
                settingsData = new SettingsData
                {
                    DaysUntilValidFrom = 5,         // Начинает действовать через 5 дней
                    AddDaysToValidTo = -1,          // минус 1 дней
                    AddMonthsToValidTo = 12,        // Плюс 1 год
                    PremiumPercentage = 10,         // 10 %
                    ThresholdPrice = 10000,         // пороговое значение 10 000
                    MinimumPremium = 1000           // Минимальная сумма 1 000
                };
                File.WriteAllText(FILE_NAME, JsonSerializer.Serialize(settingsData));
            }
            settingsData = JsonSerializer.Deserialize<SettingsData>(File.ReadAllText(FILE_NAME));

            checkBoxNewCertificate.Checked = RegistryService.FindByCertificateNumber(settingsData.Data.CertificateNumber)
                .Equals(default(CertificateData));
            if(!checkBoxNewCertificate.Checked)
                textBoxNumberSertificate.Text = settingsData.Data.CertificateNumber.ToString();
            else
                textBoxNumberSertificate.Text = (RegistryService.LastCertificate + 1).ToString();

            if (checkBoxNewCertificate.Checked)
                FillControlsFromCertificateData(settingsData.Data);
        }
        private async void InitWebView()
        {
            webView = new WebView2();
            webView.Dock = DockStyle.Fill;
            this.groupBoxView.Controls.Add(webView);

            await webView.EnsureCoreWebView2Async();
        }
        private string GetRegistryPath()
        {
            string appPath = Application.StartupPath;

            string dataFolder = Path.Combine(appPath, "DataFiles");

            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            return dataFolder;
        }

        private CertificateData CreateCertificateData()
        {
            if (!int.TryParse(textBoxNumberSertificate.Text, out int numberSertificate))
            {
                return default;
            }

            int price = (int)boxPriceGlass.Value;

            int premium = settingsData.MinimumPremium;

            if(price > settingsData.ThresholdPrice)
            {
                premium = price * settingsData.PremiumPercentage / 100;
            }

            return new CertificateData()
            {
                CertificateNumber = numberSertificate,
                ContractNumber = textBoxContractNumber.Text,
                IssueDate = dateTimePickerIssueDate.Value,
                ValidFrom = dateTimePickerValidFrom.Value,
                ValidTo = dateTimePickerValidTo.Value,
                OwnerName = textBoxOwnerName.Text,
                Phone = textBoxPhone.Text,
                CarModel = textBoxCarModel.Text,
                Year = int.TryParse(textBoxYear.Text, out int year) ? year : 0,
                VIN = textBoxVIN.Text,
                RegNumber = textBoxRegNumber.Text,
                RegistrationDoc = textBoxRegistrationDoc.Text,
                DateRegDoc = dateTimePickerDateRegDoc.Value,
                PriceGlass = price,
                Premium = premium
            };

        }
        private void FillControlsFromCertificateData(CertificateData data)
        {
            // Если пришел default (значение по умолчанию), очищаем поля
            if (data.Equals(default(CertificateData)))
            {
                ClearCertificateFields();
                return;
            }

            // Заполняем текстовые поля
            textBoxContractNumber.Text = data.ContractNumber ?? string.Empty;
            textBoxOwnerName.Text = data.OwnerName ?? string.Empty;
            textBoxPhone.Text = data.Phone ?? string.Empty;
            textBoxCarModel.Text = data.CarModel ?? string.Empty;
            textBoxYear.Text = data.Year.ToString();
            textBoxVIN.Text = data.VIN ?? string.Empty;
            textBoxRegNumber.Text = data.RegNumber ?? string.Empty;
            textBoxRegistrationDoc.Text = data.RegistrationDoc ?? string.Empty;
            boxPriceGlass.Value = data.PriceGlass;

            // Заполняем даты (с проверкой на минимальную дату)
            dateTimePickerIssueDate.Value = data.IssueDate != default(DateTime) ? data.IssueDate : DateTime.Today;
            dateTimePickerValidFrom.Value = data.ValidFrom != default(DateTime) ? data.ValidFrom : DateTime.Today;
            dateTimePickerValidTo.Value = data.ValidTo != default(DateTime) ? data.ValidTo : DateTime.Today;
            dateTimePickerDateRegDoc.Value = data.DateRegDoc != default(DateTime) ? data.DateRegDoc : DateTime.Today;
        }

        private void ValidateDateTime()
        {
            dateTimePickerIssueDate.Value = DateTime.Today;
            dateTimePickerValidFrom.Value = settingsData.CalculateValidFrom();
            dateTimePickerValidTo.Value = settingsData.CalculateValidTo();
        }

        private void ClearCertificateFields()
        {
            // Очищаем текстовые поля
            textBoxContractNumber.Text = string.Empty;
            textBoxOwnerName.Text = string.Empty;
            textBoxPhone.Text = string.Empty;
            textBoxCarModel.Text = string.Empty;
            textBoxYear.Text = string.Empty;
            textBoxVIN.Text = string.Empty;
            textBoxRegNumber.Text = string.Empty;
            textBoxRegistrationDoc.Text = string.Empty;
            boxPriceGlass.Value = 0;

            // Устанавливаем даты на текущую
            var today = DateTime.Today;
            ValidateDateTime();
            dateTimePickerDateRegDoc.Value = today;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridWindow == null || dataGridWindow.IsDisposed)
            {
                dataGridWindow = new DataGrid(RegistryService);
                dataGridWindow.Show();
            }
        }

        private void textBoxNumberSertificate_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxNumberSertificate.Text, out int num))
            {
                FillControlsFromCertificateData(RegistryService.FindByCertificateNumber(num));
            }
        }

        private void checkBoxNewCertificate_CheckedChanged(object sender, EventArgs e)
        {
            textBoxNumberSertificate.Enabled = !checkBoxNewCertificate.Checked;
            DataBox.Enabled = checkBoxNewCertificate.Checked;
            buttonRepeatCert.Enabled = !checkBoxNewCertificate.Checked;
            if (checkBoxNewCertificate.Checked)
            {
                textBoxNumberSertificate.Text = (RegistryService.LastCertificate + 1).ToString();
                textBoxContractNumber.Text = "000000-000-000000"; 
            }
        }

        private void buttonbuttonRepeatCert_Click(object sender, EventArgs e)
        {
            var sertificate = CreateCertificateData();
            checkBoxNewCertificate.Checked = true;
            textBoxNumberSertificate.Text = (RegistryService.LastCertificate + 1).ToString();
            FillControlsFromCertificateData(sertificate);
            ValidateDateTime();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            var sertificate = CreateCertificateData();
            pathTempPDF = SertificateService.GenerateTemporaryPdf(sertificate);
            if (checkBoxNewCertificate.Checked)
            {
                int current = RegistryService.AddCertificate(sertificate);
                RegistryService.SaveToExcel();
                checkBoxNewCertificate.Checked = false;
                textBoxNumberSertificate.Text = current.ToString();
            }
            webView.CoreWebView2.Navigate($"file:///{pathTempPDF}");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pathTempPDF) && !File.Exists(pathTempPDF))
            {
                MessageBox.Show("Сформируйте сертификат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Формируем имя файла по шаблону
            string defaultFileName = $"Сертификат_{textBoxContractNumber.Text}_{DateTime.Now:yyyyMMdd}.pdf";

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Сохранить сертификат";
                saveFileDialog.Filter = "PDF файлы (*.pdf)|*.pdf";
                saveFileDialog.FileName = defaultFileName;
                saveFileDialog.DefaultExt = ".pdf";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(pathTempPDF, saveFileDialog.FileName, overwrite: true);
                        DialogResult result = MessageBox.Show(
                        "Сертификат успешно сохранён!\nПерейти к файлу?",
                        "Успешное сохранение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            Process.Start("explorer.exe", $"/select,\"{saveFileDialog.FileName}\"");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void textBoxDaysUntilValidFrom_TextChanged(object sender, EventArgs e)
        {
            settingsData.DaysUntilValidFrom = int.TryParse(textBoxDaysUntilValidFrom.Text, out int num) ? num : 0;
        }

        private void textBoxAddDaysToValidTo_TextChanged(object sender, EventArgs e)
        {
            settingsData.AddDaysToValidTo = int.TryParse(textBoxAddDaysToValidTo.Text, out int num) ? num : 0;
        }

        private void textBoxAddMonthsToValidTo_TextChanged(object sender, EventArgs e)
        {
            settingsData.AddMonthsToValidTo = int.TryParse(textBoxAddMonthsToValidTo.Text, out int num) ? num : 0;
        }

        private void ValidateTextBoxAddDay()
        {
            textBoxDaysUntilValidFrom.Text = settingsData.DaysUntilValidFrom.ToString();
            textBoxAddDaysToValidTo.Text = settingsData.AddDaysToValidTo.ToString();
            textBoxAddMonthsToValidTo.Text = settingsData.AddMonthsToValidTo.ToString();
        }

        private void buttonRedactDialog_Click(object sender, EventArgs e)
        {
            var price = new PriceDialog(settingsData.PremiumPercentage, settingsData.ThresholdPrice, settingsData.PremiumPercentage);
            if (price.ShowDialog() == DialogResult.OK)
            {
                settingsData.ThresholdPrice = price.ThresholdPrice;
                settingsData.PremiumPercentage = price.PremiumPercentage;
            }
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            RegistryService.CreateBackup();
        }
    }
}
