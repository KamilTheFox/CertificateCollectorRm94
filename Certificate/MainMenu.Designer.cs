namespace Certificate
{
    partial class MainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.DataBox = new System.Windows.Forms.GroupBox();
            this.boxPriceGlass = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxContractNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dateTimePickerDateRegDoc = new System.Windows.Forms.DateTimePicker();
            this.textBoxRegistrationDoc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxRegNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxVIN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCarModel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxOwnerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerValidTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerValidFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerIssueDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxNumberSertificate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBoxView = new System.Windows.Forms.GroupBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonRegistry = new System.Windows.Forms.Button();
            this.buttonRepeatCert = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxNewCertificate = new System.Windows.Forms.CheckBox();
            this.textBoxDaysUntilValidFrom = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxAddDaysToValidTo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxAddMonthsToValidTo = new System.Windows.Forms.TextBox();
            this.buttonRedactDialog = new System.Windows.Forms.Button();
            this.buttonbackup = new System.Windows.Forms.Button();
            this.DataBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxPriceGlass)).BeginInit();
            this.SuspendLayout();
            // 
            // DataBox
            // 
            this.DataBox.Controls.Add(this.boxPriceGlass);
            this.DataBox.Controls.Add(this.label17);
            this.DataBox.Controls.Add(this.label11);
            this.DataBox.Controls.Add(this.textBoxContractNumber);
            this.DataBox.Controls.Add(this.label13);
            this.DataBox.Controls.Add(this.dateTimePickerDateRegDoc);
            this.DataBox.Controls.Add(this.textBoxRegistrationDoc);
            this.DataBox.Controls.Add(this.label10);
            this.DataBox.Controls.Add(this.textBoxRegNumber);
            this.DataBox.Controls.Add(this.label9);
            this.DataBox.Controls.Add(this.textBoxVIN);
            this.DataBox.Controls.Add(this.label8);
            this.DataBox.Controls.Add(this.textBoxYear);
            this.DataBox.Controls.Add(this.label7);
            this.DataBox.Controls.Add(this.textBoxCarModel);
            this.DataBox.Controls.Add(this.label6);
            this.DataBox.Controls.Add(this.textBoxPhone);
            this.DataBox.Controls.Add(this.label5);
            this.DataBox.Controls.Add(this.textBoxOwnerName);
            this.DataBox.Controls.Add(this.label4);
            this.DataBox.Controls.Add(this.label3);
            this.DataBox.Controls.Add(this.label2);
            this.DataBox.Controls.Add(this.label1);
            this.DataBox.Controls.Add(this.dateTimePickerValidTo);
            this.DataBox.Controls.Add(this.dateTimePickerValidFrom);
            this.DataBox.Controls.Add(this.dateTimePickerIssueDate);
            this.DataBox.Location = new System.Drawing.Point(16, 55);
            this.DataBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataBox.Name = "DataBox";
            this.DataBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataBox.Size = new System.Drawing.Size(540, 420);
            this.DataBox.TabIndex = 0;
            this.DataBox.TabStop = false;
            this.DataBox.Text = "Данные";
            // 
            // boxPriceGlass
            // 
            this.boxPriceGlass.Location = new System.Drawing.Point(185, 377);
            this.boxPriceGlass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boxPriceGlass.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.boxPriceGlass.Name = "boxPriceGlass";
            this.boxPriceGlass.Size = new System.Drawing.Size(340, 22);
            this.boxPriceGlass.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 377);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 16);
            this.label17.TabIndex = 27;
            this.label17.Text = "Цена стекла";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(331, 348);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 16);
            this.label11.TabIndex = 26;
            this.label11.Text = "От";
            // 
            // textBoxContractNumber
            // 
            this.textBoxContractNumber.Location = new System.Drawing.Point(185, 25);
            this.textBoxContractNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxContractNumber.Name = "textBoxContractNumber";
            this.textBoxContractNumber.Size = new System.Drawing.Size(339, 22);
            this.textBoxContractNumber.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 25);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 16);
            this.label13.TabIndex = 24;
            this.label13.Text = "Номер договора";
            // 
            // dateTimePickerDateRegDoc
            // 
            this.dateTimePickerDateRegDoc.Location = new System.Drawing.Point(365, 345);
            this.dateTimePickerDateRegDoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerDateRegDoc.Name = "dateTimePickerDateRegDoc";
            this.dateTimePickerDateRegDoc.Size = new System.Drawing.Size(159, 22);
            this.dateTimePickerDateRegDoc.TabIndex = 20;
            // 
            // textBoxRegistrationDoc
            // 
            this.textBoxRegistrationDoc.Location = new System.Drawing.Point(55, 345);
            this.textBoxRegistrationDoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRegistrationDoc.Name = "textBoxRegistrationDoc";
            this.textBoxRegistrationDoc.Size = new System.Drawing.Size(269, 22);
            this.textBoxRegistrationDoc.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 345);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "СТС";
            // 
            // textBoxRegNumber
            // 
            this.textBoxRegNumber.Location = new System.Drawing.Point(185, 313);
            this.textBoxRegNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRegNumber.Name = "textBoxRegNumber";
            this.textBoxRegNumber.Size = new System.Drawing.Size(339, 22);
            this.textBoxRegNumber.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 313);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Регистрационный знак";
            // 
            // textBoxVIN
            // 
            this.textBoxVIN.Location = new System.Drawing.Point(185, 281);
            this.textBoxVIN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxVIN.Name = "textBoxVIN";
            this.textBoxVIN.Size = new System.Drawing.Size(339, 22);
            this.textBoxVIN.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 281);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "VIN";
            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(185, 249);
            this.textBoxYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(339, 22);
            this.textBoxYear.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 249);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Год выпуска";
            // 
            // textBoxCarModel
            // 
            this.textBoxCarModel.Location = new System.Drawing.Point(185, 217);
            this.textBoxCarModel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCarModel.Name = "textBoxCarModel";
            this.textBoxCarModel.Size = new System.Drawing.Size(339, 22);
            this.textBoxCarModel.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 217);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Марка/Модель";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(185, 185);
            this.textBoxPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(339, 22);
            this.textBoxPhone.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 185);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Телефон (Без +7/8)";
            // 
            // textBoxOwnerName
            // 
            this.textBoxOwnerName.Location = new System.Drawing.Point(185, 153);
            this.textBoxOwnerName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxOwnerName.Name = "textBoxOwnerName";
            this.textBoxOwnerName.Size = new System.Drawing.Size(339, 22);
            this.textBoxOwnerName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 153);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "ФИО";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Конец действия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Начало действия";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Дата оформления";
            // 
            // dateTimePickerValidTo
            // 
            this.dateTimePickerValidTo.Location = new System.Drawing.Point(185, 121);
            this.dateTimePickerValidTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerValidTo.Name = "dateTimePickerValidTo";
            this.dateTimePickerValidTo.Size = new System.Drawing.Size(339, 22);
            this.dateTimePickerValidTo.TabIndex = 2;
            // 
            // dateTimePickerValidFrom
            // 
            this.dateTimePickerValidFrom.Location = new System.Drawing.Point(185, 89);
            this.dateTimePickerValidFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerValidFrom.Name = "dateTimePickerValidFrom";
            this.dateTimePickerValidFrom.Size = new System.Drawing.Size(339, 22);
            this.dateTimePickerValidFrom.TabIndex = 1;
            // 
            // dateTimePickerIssueDate
            // 
            this.dateTimePickerIssueDate.Enabled = false;
            this.dateTimePickerIssueDate.Location = new System.Drawing.Point(185, 57);
            this.dateTimePickerIssueDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerIssueDate.Name = "dateTimePickerIssueDate";
            this.dateTimePickerIssueDate.Size = new System.Drawing.Size(339, 22);
            this.dateTimePickerIssueDate.TabIndex = 0;
            // 
            // textBoxNumberSertificate
            // 
            this.textBoxNumberSertificate.Enabled = false;
            this.textBoxNumberSertificate.Location = new System.Drawing.Point(373, 23);
            this.textBoxNumberSertificate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxNumberSertificate.Name = "textBoxNumberSertificate";
            this.textBoxNumberSertificate.Size = new System.Drawing.Size(167, 22);
            this.textBoxNumberSertificate.TabIndex = 22;
            this.textBoxNumberSertificate.TextChanged += new System.EventHandler(this.textBoxNumberSertificate_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 23);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(142, 16);
            this.label12.TabIndex = 21;
            this.label12.Text = "Номер Сертификата";
            // 
            // groupBoxView
            // 
            this.groupBoxView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxView.Location = new System.Drawing.Point(569, 9);
            this.groupBoxView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxView.Name = "groupBoxView";
            this.groupBoxView.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxView.Size = new System.Drawing.Size(624, 722);
            this.groupBoxView.TabIndex = 23;
            this.groupBoxView.TabStop = false;
            this.groupBoxView.Text = "Предпросмотр";
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(15, 484);
            this.buttonGenerate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(271, 39);
            this.buttonGenerate.TabIndex = 24;
            this.buttonGenerate.Text = "Сформировать Сертификат";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonRegistry
            // 
            this.buttonRegistry.Location = new System.Drawing.Point(15, 530);
            this.buttonRegistry.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRegistry.Name = "buttonRegistry";
            this.buttonRegistry.Size = new System.Drawing.Size(271, 39);
            this.buttonRegistry.TabIndex = 25;
            this.buttonRegistry.Text = "Реестр";
            this.buttonRegistry.UseVisualStyleBackColor = true;
            this.buttonRegistry.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonRepeatCert
            // 
            this.buttonRepeatCert.Enabled = false;
            this.buttonRepeatCert.Location = new System.Drawing.Point(293, 530);
            this.buttonRepeatCert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRepeatCert.Name = "buttonRepeatCert";
            this.buttonRepeatCert.Size = new System.Drawing.Size(261, 39);
            this.buttonRepeatCert.TabIndex = 26;
            this.buttonRepeatCert.Text = "Повторить сертификат";
            this.buttonRepeatCert.UseVisualStyleBackColor = true;
            this.buttonRepeatCert.Click += new System.EventHandler(this.buttonbuttonRepeatCert_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(293, 482);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(261, 39);
            this.buttonSave.TabIndex = 27;
            this.buttonSave.Text = "Сохранить Сертификат";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkBoxNewCertificate
            // 
            this.checkBoxNewCertificate.AutoSize = true;
            this.checkBoxNewCertificate.Checked = true;
            this.checkBoxNewCertificate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNewCertificate.Location = new System.Drawing.Point(201, 26);
            this.checkBoxNewCertificate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxNewCertificate.Name = "checkBoxNewCertificate";
            this.checkBoxNewCertificate.Size = new System.Drawing.Size(151, 20);
            this.checkBoxNewCertificate.TabIndex = 28;
            this.checkBoxNewCertificate.Text = "Новый сертификат";
            this.checkBoxNewCertificate.UseVisualStyleBackColor = true;
            this.checkBoxNewCertificate.CheckedChanged += new System.EventHandler(this.checkBoxNewCertificate_CheckedChanged);
            // 
            // textBoxDaysUntilValidFrom
            // 
            this.textBoxDaysUntilValidFrom.Location = new System.Drawing.Point(213, 629);
            this.textBoxDaysUntilValidFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDaysUntilValidFrom.Name = "textBoxDaysUntilValidFrom";
            this.textBoxDaysUntilValidFrom.Size = new System.Drawing.Size(327, 22);
            this.textBoxDaysUntilValidFrom.TabIndex = 29;
            this.textBoxDaysUntilValidFrom.TextChanged += new System.EventHandler(this.textBoxDaysUntilValidFrom_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 630);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(179, 16);
            this.label14.TabIndex = 27;
            this.label14.Text = "Начало срока через дней:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 662);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(161, 16);
            this.label15.TabIndex = 30;
            this.label15.Text = "Количество дней срока";
            // 
            // textBoxAddDaysToValidTo
            // 
            this.textBoxAddDaysToValidTo.Location = new System.Drawing.Point(213, 661);
            this.textBoxAddDaysToValidTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAddDaysToValidTo.Name = "textBoxAddDaysToValidTo";
            this.textBoxAddDaysToValidTo.Size = new System.Drawing.Size(327, 22);
            this.textBoxAddDaysToValidTo.TabIndex = 31;
            this.textBoxAddDaysToValidTo.TextChanged += new System.EventHandler(this.textBoxAddDaysToValidTo_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 694);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(184, 16);
            this.label16.TabIndex = 32;
            this.label16.Text = "Количество месяцев срока";
            // 
            // textBoxAddMonthsToValidTo
            // 
            this.textBoxAddMonthsToValidTo.Location = new System.Drawing.Point(213, 693);
            this.textBoxAddMonthsToValidTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAddMonthsToValidTo.Name = "textBoxAddMonthsToValidTo";
            this.textBoxAddMonthsToValidTo.Size = new System.Drawing.Size(327, 22);
            this.textBoxAddMonthsToValidTo.TabIndex = 33;
            this.textBoxAddMonthsToValidTo.TextChanged += new System.EventHandler(this.textBoxAddMonthsToValidTo_TextChanged);
            // 
            // buttonRedactDialog
            // 
            this.buttonRedactDialog.Location = new System.Drawing.Point(16, 577);
            this.buttonRedactDialog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRedactDialog.Name = "buttonRedactDialog";
            this.buttonRedactDialog.Size = new System.Drawing.Size(271, 39);
            this.buttonRedactDialog.TabIndex = 34;
            this.buttonRedactDialog.Text = "Редактировать формулу";
            this.buttonRedactDialog.UseVisualStyleBackColor = true;
            this.buttonRedactDialog.Click += new System.EventHandler(this.buttonRedactDialog_Click);
            // 
            // buttonbackup
            // 
            this.buttonbackup.Location = new System.Drawing.Point(293, 577);
            this.buttonbackup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonbackup.Name = "buttonbackup";
            this.buttonbackup.Size = new System.Drawing.Size(261, 39);
            this.buttonbackup.TabIndex = 35;
            this.buttonbackup.Text = "Бэап реестра";
            this.buttonbackup.UseVisualStyleBackColor = true;
            this.buttonbackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 746);
            this.Controls.Add(this.buttonbackup);
            this.Controls.Add(this.buttonRedactDialog);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBoxAddMonthsToValidTo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBoxAddDaysToValidTo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxDaysUntilValidFrom);
            this.Controls.Add(this.checkBoxNewCertificate);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonRepeatCert);
            this.Controls.Add(this.buttonRegistry);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.groupBoxView);
            this.Controls.Add(this.textBoxNumberSertificate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.DataBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainMenu";
            this.Text = "Сертификаты";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_FormClosed);
            this.DataBox.ResumeLayout(false);
            this.DataBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxPriceGlass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox DataBox;
        private System.Windows.Forms.TextBox textBoxVIN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCarModel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxOwnerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerValidTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerValidFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerIssueDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateRegDoc;
        private System.Windows.Forms.TextBox textBoxRegistrationDoc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxRegNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxNumberSertificate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxContractNumber;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBoxView;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonRegistry;
        private System.Windows.Forms.Button buttonRepeatCert;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxNewCertificate;
        private System.Windows.Forms.TextBox textBoxDaysUntilValidFrom;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxAddDaysToValidTo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxAddMonthsToValidTo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button buttonRedactDialog;
        private System.Windows.Forms.NumericUpDown boxPriceGlass;
        private System.Windows.Forms.Button buttonbackup;
    }
}

