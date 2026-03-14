namespace Certificate
{
    partial class DataGrid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataGrid));
            this.dataGridRegistry = new System.Windows.Forms.DataGridView();
            this.buttonFindByNumber = new System.Windows.Forms.Button();
            this.textBoxFindByNumber = new System.Windows.Forms.TextBox();
            this.textBoxFindByVIN = new System.Windows.Forms.TextBox();
            this.buttonFindByVIN = new System.Windows.Forms.Button();
            this.textBoxFindPhone = new System.Windows.Forms.TextBox();
            this.buttonFindPhone = new System.Windows.Forms.Button();
            this.buttonFindByIssue = new System.Windows.Forms.Button();
            this.buttonActiveCertificates = new System.Windows.Forms.Button();
            this.dateTimePickerActiveCertificates = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.textBoxExpiring = new System.Windows.Forms.TextBox();
            this.buttonExpiring = new System.Windows.Forms.Button();
            this.textBoxSearchBy = new System.Windows.Forms.TextBox();
            this.searchBy = new System.Windows.Forms.Button();
            this.showAllbuton = new System.Windows.Forms.Button();
            this.buttonExportExel = new System.Windows.Forms.Button();
            this.buttonFindByNumbers = new System.Windows.Forms.Button();
            this.textBoxFindByNumbersFirst = new System.Windows.Forms.TextBox();
            this.textBoxFindByNumbersSecond = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRegistry)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridRegistry
            // 
            this.dataGridRegistry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridRegistry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRegistry.Location = new System.Drawing.Point(501, 15);
            this.dataGridRegistry.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridRegistry.Name = "dataGridRegistry";
            this.dataGridRegistry.Size = new System.Drawing.Size(972, 756);
            this.dataGridRegistry.TabIndex = 0;
            // 
            // buttonFindByNumber
            // 
            this.buttonFindByNumber.Location = new System.Drawing.Point(16, 54);
            this.buttonFindByNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFindByNumber.Name = "buttonFindByNumber";
            this.buttonFindByNumber.Size = new System.Drawing.Size(216, 25);
            this.buttonFindByNumber.TabIndex = 1;
            this.buttonFindByNumber.Text = "Найти по индексу";
            this.buttonFindByNumber.UseVisualStyleBackColor = true;
            this.buttonFindByNumber.Click += new System.EventHandler(this.buttonFindByNumber_Click);
            // 
            // textBoxFindByNumber
            // 
            this.textBoxFindByNumber.Location = new System.Drawing.Point(241, 54);
            this.textBoxFindByNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFindByNumber.Name = "textBoxFindByNumber";
            this.textBoxFindByNumber.Size = new System.Drawing.Size(251, 22);
            this.textBoxFindByNumber.TabIndex = 2;
            // 
            // textBoxFindByVIN
            // 
            this.textBoxFindByVIN.Location = new System.Drawing.Point(241, 118);
            this.textBoxFindByVIN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFindByVIN.Name = "textBoxFindByVIN";
            this.textBoxFindByVIN.Size = new System.Drawing.Size(251, 22);
            this.textBoxFindByVIN.TabIndex = 6;
            // 
            // buttonFindByVIN
            // 
            this.buttonFindByVIN.Location = new System.Drawing.Point(16, 118);
            this.buttonFindByVIN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFindByVIN.Name = "buttonFindByVIN";
            this.buttonFindByVIN.Size = new System.Drawing.Size(216, 25);
            this.buttonFindByVIN.TabIndex = 5;
            this.buttonFindByVIN.Text = "Найти по VIN";
            this.buttonFindByVIN.UseVisualStyleBackColor = true;
            this.buttonFindByVIN.Click += new System.EventHandler(this.buttonFindByVIN_Click);
            // 
            // textBoxFindPhone
            // 
            this.textBoxFindPhone.Location = new System.Drawing.Point(241, 150);
            this.textBoxFindPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFindPhone.Name = "textBoxFindPhone";
            this.textBoxFindPhone.Size = new System.Drawing.Size(251, 22);
            this.textBoxFindPhone.TabIndex = 8;
            // 
            // buttonFindPhone
            // 
            this.buttonFindPhone.Location = new System.Drawing.Point(16, 150);
            this.buttonFindPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFindPhone.Name = "buttonFindPhone";
            this.buttonFindPhone.Size = new System.Drawing.Size(216, 25);
            this.buttonFindPhone.TabIndex = 7;
            this.buttonFindPhone.Text = "Найти по номеру телефона";
            this.buttonFindPhone.UseVisualStyleBackColor = true;
            this.buttonFindPhone.Click += new System.EventHandler(this.buttonFindPhone_Click);
            // 
            // buttonFindByIssue
            // 
            this.buttonFindByIssue.Location = new System.Drawing.Point(16, 182);
            this.buttonFindByIssue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFindByIssue.Name = "buttonFindByIssue";
            this.buttonFindByIssue.Size = new System.Drawing.Size(477, 25);
            this.buttonFindByIssue.TabIndex = 9;
            this.buttonFindByIssue.Text = "Найти по Дате оформления";
            this.buttonFindByIssue.UseVisualStyleBackColor = true;
            this.buttonFindByIssue.Click += new System.EventHandler(this.buttonFindByIssue_Click);
            // 
            // buttonActiveCertificates
            // 
            this.buttonActiveCertificates.Location = new System.Drawing.Point(16, 250);
            this.buttonActiveCertificates.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonActiveCertificates.Name = "buttonActiveCertificates";
            this.buttonActiveCertificates.Size = new System.Drawing.Size(216, 25);
            this.buttonActiveCertificates.TabIndex = 11;
            this.buttonActiveCertificates.Text = "Действующие";
            this.buttonActiveCertificates.UseVisualStyleBackColor = true;
            this.buttonActiveCertificates.Click += new System.EventHandler(this.buttonActiveCertificates_Click);
            // 
            // dateTimePickerActiveCertificates
            // 
            this.dateTimePickerActiveCertificates.Location = new System.Drawing.Point(241, 250);
            this.dateTimePickerActiveCertificates.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerActiveCertificates.Name = "dateTimePickerActiveCertificates";
            this.dateTimePickerActiveCertificates.Size = new System.Drawing.Size(251, 22);
            this.dateTimePickerActiveCertificates.TabIndex = 12;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(16, 214);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(215, 22);
            this.dateTimePickerFrom.TabIndex = 13;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(241, 214);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(251, 22);
            this.dateTimePickerTo.TabIndex = 14;
            // 
            // textBoxExpiring
            // 
            this.textBoxExpiring.Location = new System.Drawing.Point(241, 282);
            this.textBoxExpiring.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxExpiring.Name = "textBoxExpiring";
            this.textBoxExpiring.Size = new System.Drawing.Size(251, 22);
            this.textBoxExpiring.TabIndex = 16;
            // 
            // buttonExpiring
            // 
            this.buttonExpiring.Location = new System.Drawing.Point(16, 282);
            this.buttonExpiring.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExpiring.Name = "buttonExpiring";
            this.buttonExpiring.Size = new System.Drawing.Size(216, 25);
            this.buttonExpiring.TabIndex = 15;
            this.buttonExpiring.Text = "Истекающие через дней";
            this.buttonExpiring.UseVisualStyleBackColor = true;
            this.buttonExpiring.Click += new System.EventHandler(this.buttonExpiring_Click);
            // 
            // textBoxSearchBy
            // 
            this.textBoxSearchBy.Location = new System.Drawing.Point(241, 314);
            this.textBoxSearchBy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSearchBy.Name = "textBoxSearchBy";
            this.textBoxSearchBy.Size = new System.Drawing.Size(251, 22);
            this.textBoxSearchBy.TabIndex = 18;
            // 
            // searchBy
            // 
            this.searchBy.Location = new System.Drawing.Point(16, 314);
            this.searchBy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchBy.Name = "searchBy";
            this.searchBy.Size = new System.Drawing.Size(216, 25);
            this.searchBy.TabIndex = 17;
            this.searchBy.Text = "Искать по тексту";
            this.searchBy.UseVisualStyleBackColor = true;
            this.searchBy.Click += new System.EventHandler(this.searchBy_Click);
            // 
            // showAllbuton
            // 
            this.showAllbuton.Location = new System.Drawing.Point(16, 22);
            this.showAllbuton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.showAllbuton.Name = "showAllbuton";
            this.showAllbuton.Size = new System.Drawing.Size(477, 25);
            this.showAllbuton.TabIndex = 19;
            this.showAllbuton.Text = "Показать все";
            this.showAllbuton.UseVisualStyleBackColor = true;
            this.showAllbuton.Click += new System.EventHandler(this.showAllbutton_Click);
            // 
            // buttonExportExel
            // 
            this.buttonExportExel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExportExel.Location = new System.Drawing.Point(16, 719);
            this.buttonExportExel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExportExel.Name = "buttonExportExel";
            this.buttonExportExel.Size = new System.Drawing.Size(216, 52);
            this.buttonExportExel.TabIndex = 20;
            this.buttonExportExel.Text = "Экспортировать Exel";
            this.buttonExportExel.UseVisualStyleBackColor = true;
            this.buttonExportExel.Click += new System.EventHandler(this.OnExportExcelClick);
            // 
            // buttonFindByNumbers
            // 
            this.buttonFindByNumbers.Location = new System.Drawing.Point(16, 86);
            this.buttonFindByNumbers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFindByNumbers.Name = "buttonFindByNumbers";
            this.buttonFindByNumbers.Size = new System.Drawing.Size(216, 25);
            this.buttonFindByNumbers.TabIndex = 21;
            this.buttonFindByNumbers.Text = "Найти по индексам";
            this.buttonFindByNumbers.UseVisualStyleBackColor = true;
            this.buttonFindByNumbers.Click += new System.EventHandler(this.buttonFindByNumbers_Click);
            // 
            // textBoxFindByNumbersFirst
            // 
            this.textBoxFindByNumbersFirst.Location = new System.Drawing.Point(240, 87);
            this.textBoxFindByNumbersFirst.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFindByNumbersFirst.Name = "textBoxFindByNumbersFirst";
            this.textBoxFindByNumbersFirst.Size = new System.Drawing.Size(120, 22);
            this.textBoxFindByNumbersFirst.TabIndex = 22;
            // 
            // textBoxFindByNumbersSecond
            // 
            this.textBoxFindByNumbersSecond.Location = new System.Drawing.Point(372, 86);
            this.textBoxFindByNumbersSecond.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFindByNumbersSecond.Name = "textBoxFindByNumbersSecond";
            this.textBoxFindByNumbersSecond.Size = new System.Drawing.Size(120, 22);
            this.textBoxFindByNumbersSecond.TabIndex = 23;
            // 
            // DataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 785);
            this.Controls.Add(this.textBoxFindByNumbersSecond);
            this.Controls.Add(this.textBoxFindByNumbersFirst);
            this.Controls.Add(this.buttonFindByNumbers);
            this.Controls.Add(this.buttonExportExel);
            this.Controls.Add(this.showAllbuton);
            this.Controls.Add(this.textBoxSearchBy);
            this.Controls.Add(this.searchBy);
            this.Controls.Add(this.textBoxExpiring);
            this.Controls.Add(this.buttonExpiring);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.dateTimePickerActiveCertificates);
            this.Controls.Add(this.buttonActiveCertificates);
            this.Controls.Add(this.buttonFindByIssue);
            this.Controls.Add(this.textBoxFindPhone);
            this.Controls.Add(this.buttonFindPhone);
            this.Controls.Add(this.textBoxFindByVIN);
            this.Controls.Add(this.buttonFindByVIN);
            this.Controls.Add(this.textBoxFindByNumber);
            this.Controls.Add(this.buttonFindByNumber);
            this.Controls.Add(this.dataGridRegistry);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DataGrid";
            this.Text = "Реестр";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRegistry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridRegistry;
        private System.Windows.Forms.Button buttonFindByNumber;
        private System.Windows.Forms.TextBox textBoxFindByNumber;
        private System.Windows.Forms.TextBox textBoxFindByVIN;
        private System.Windows.Forms.Button buttonFindByVIN;
        private System.Windows.Forms.TextBox textBoxFindPhone;
        private System.Windows.Forms.Button buttonFindPhone;
        private System.Windows.Forms.Button buttonFindByIssue;
        private System.Windows.Forms.Button buttonActiveCertificates;
        private System.Windows.Forms.DateTimePicker dateTimePickerActiveCertificates;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.TextBox textBoxExpiring;
        private System.Windows.Forms.Button buttonExpiring;
        private System.Windows.Forms.TextBox textBoxSearchBy;
        private System.Windows.Forms.Button searchBy;
        private System.Windows.Forms.Button showAllbuton;
        private System.Windows.Forms.Button buttonExportExel;
        private System.Windows.Forms.Button buttonFindByNumbers;
        private System.Windows.Forms.TextBox textBoxFindByNumbersFirst;
        private System.Windows.Forms.TextBox textBoxFindByNumbersSecond;
    }
}