namespace BankAccountManagement
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.TextBox txtOwnerName;
        private System.Windows.Forms.TextBox txtPassportData;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.ComboBox cmbDepositType;
        private System.Windows.Forms.DateTimePicker dtpOpenDate;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.CheckBox chkSmsNotification;
        private System.Windows.Forms.CheckBox chkInternetBanking;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnCalculateBudget;
        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.DataGridView dgvBudget;
        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.Label lblOwnerName;
        private System.Windows.Forms.Label lblPassportData;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblDepositType;
        private System.Windows.Forms.Label lblOpenDate;
        private System.Windows.Forms.Label lblBirthDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            txtAccountNumber = new TextBox();
            txtOwnerName = new TextBox();
            txtPassportData = new TextBox();
            txtBalance = new TextBox();
            cmbDepositType = new ComboBox();
            dtpOpenDate = new DateTimePicker();
            dtpBirthDate = new DateTimePicker();
            chkSmsNotification = new CheckBox();
            chkInternetBanking = new CheckBox();
            btnSave = new Button();
            btnLoad = new Button();
            btnCalculateBudget = new Button();
            dgvAccounts = new DataGridView();
            dgvBudget = new DataGridView();
            lblAccountNumber = new Label();
            lblOwnerName = new Label();
            lblPassportData = new Label();
            lblBalance = new Label();
            lblDepositType = new Label();
            lblOpenDate = new Label();
            lblBirthDate = new Label();
            txtPhoneNumber = new TextBox();
            lblPhoneNumber = new Label();
            lblAdress = new Label();
            txtAdress = new TextBox();
            linkLabel1 = new LinkLabel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBudget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtAccountNumber
            // 
            txtAccountNumber.Location = new Point(200, 31);
            txtAccountNumber.Margin = new Padding(4, 5, 4, 5);
            txtAccountNumber.Name = "txtAccountNumber";
            txtAccountNumber.PlaceholderText = "10 символов";
            txtAccountNumber.Size = new Size(265, 27);
            txtAccountNumber.TabIndex = 0;
            txtAccountNumber.Text = "1234567890";
            // 
            // txtOwnerName
            // 
            txtOwnerName.Location = new Point(200, 77);
            txtOwnerName.Margin = new Padding(4, 5, 4, 5);
            txtOwnerName.Name = "txtOwnerName";
            txtOwnerName.Size = new Size(265, 27);
            txtOwnerName.TabIndex = 1;
            txtOwnerName.Text = "Бондарик Никита Дмитриевич";
            // 
            // txtPassportData
            // 
            txtPassportData.Location = new Point(200, 123);
            txtPassportData.Margin = new Padding(4, 5, 4, 5);
            txtPassportData.Name = "txtPassportData";
            txtPassportData.Size = new Size(265, 27);
            txtPassportData.TabIndex = 2;
            txtPassportData.Text = "МС354673";
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(200, 169);
            txtBalance.Margin = new Padding(4, 5, 4, 5);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(265, 27);
            txtBalance.TabIndex = 3;
            txtBalance.Text = "500";
            // 
            // cmbDepositType
            // 
            cmbDepositType.FormattingEnabled = true;
            cmbDepositType.Items.AddRange(new object[] { "Депозит", "Текущий счет", "Накопительный счет" });
            cmbDepositType.Location = new Point(200, 215);
            cmbDepositType.Margin = new Padding(4, 5, 4, 5);
            cmbDepositType.Name = "cmbDepositType";
            cmbDepositType.Size = new Size(265, 28);
            cmbDepositType.TabIndex = 4;
            // 
            // dtpOpenDate
            // 
            dtpOpenDate.Location = new Point(200, 262);
            dtpOpenDate.Margin = new Padding(4, 5, 4, 5);
            dtpOpenDate.Name = "dtpOpenDate";
            dtpOpenDate.Size = new Size(265, 27);
            dtpOpenDate.TabIndex = 5;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(200, 308);
            dtpBirthDate.Margin = new Padding(4, 5, 4, 5);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(265, 27);
            dtpBirthDate.TabIndex = 6;
            dtpBirthDate.Value = new DateTime(2005, 11, 11, 15, 31, 0, 0);
            // 
            // chkSmsNotification
            // 
            chkSmsNotification.AutoSize = true;
            chkSmsNotification.Location = new Point(197, 431);
            chkSmsNotification.Margin = new Padding(4, 5, 4, 5);
            chkSmsNotification.Name = "chkSmsNotification";
            chkSmsNotification.Size = new Size(157, 24);
            chkSmsNotification.TabIndex = 7;
            chkSmsNotification.Text = "СМС-оповещения";
            chkSmsNotification.UseVisualStyleBackColor = true;
            // 
            // chkInternetBanking
            // 
            chkInternetBanking.AutoSize = true;
            chkInternetBanking.Location = new Point(194, 465);
            chkInternetBanking.Margin = new Padding(4, 5, 4, 5);
            chkInternetBanking.Name = "chkInternetBanking";
            chkInternetBanking.Size = new Size(160, 24);
            chkInternetBanking.TabIndex = 8;
            chkInternetBanking.Text = "Интернет-банкинг";
            chkInternetBanking.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(200, 499);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(133, 46);
            btnSave.TabIndex = 9;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(347, 499);
            btnLoad.Margin = new Padding(4, 5, 4, 5);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(133, 46);
            btnLoad.TabIndex = 10;
            btnLoad.Text = "Загрузить";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnCalculateBudget
            // 
            btnCalculateBudget.Location = new Point(200, 555);
            btnCalculateBudget.Margin = new Padding(4, 5, 4, 5);
            btnCalculateBudget.Name = "btnCalculateBudget";
            btnCalculateBudget.Size = new Size(280, 46);
            btnCalculateBudget.TabIndex = 11;
            btnCalculateBudget.Text = "Рассчитать бюджет";
            btnCalculateBudget.UseVisualStyleBackColor = true;
            btnCalculateBudget.Click += btnCalculateBudget_Click;
            // 
            // dgvAccounts
            // 
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.Location = new Point(533, 35);
            dgvAccounts.Margin = new Padding(4, 5, 4, 5);
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.RowHeadersWidth = 51;
            dgvAccounts.Size = new Size(533, 251);
            dgvAccounts.TabIndex = 12;
            // 
            // dgvBudget
            // 
            dgvBudget.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBudget.Location = new Point(533, 308);
            dgvBudget.Margin = new Padding(4, 5, 4, 5);
            dgvBudget.Name = "dgvBudget";
            dgvBudget.RowHeadersWidth = 51;
            dgvBudget.Size = new Size(533, 255);
            dgvBudget.TabIndex = 13;
            // 
            // lblAccountNumber
            // 
            lblAccountNumber.AutoSize = true;
            lblAccountNumber.Location = new Point(27, 35);
            lblAccountNumber.Margin = new Padding(4, 0, 4, 0);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.Size = new Size(101, 20);
            lblAccountNumber.TabIndex = 14;
            lblAccountNumber.Text = "Номер счета:";
            // 
            // lblOwnerName
            // 
            lblOwnerName.AutoSize = true;
            lblOwnerName.Location = new Point(27, 82);
            lblOwnerName.Margin = new Padding(4, 0, 4, 0);
            lblOwnerName.Name = "lblOwnerName";
            lblOwnerName.Size = new Size(122, 20);
            lblOwnerName.TabIndex = 15;
            lblOwnerName.Text = "ФИО владельца:";
            // 
            // lblPassportData
            // 
            lblPassportData.AutoSize = true;
            lblPassportData.Location = new Point(27, 128);
            lblPassportData.Margin = new Padding(4, 0, 4, 0);
            lblPassportData.Name = "lblPassportData";
            lblPassportData.Size = new Size(156, 20);
            lblPassportData.TabIndex = 16;
            lblPassportData.Text = "Паспортные данные:";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(27, 174);
            lblBalance.Margin = new Padding(4, 0, 4, 0);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(102, 20);
            lblBalance.TabIndex = 17;
            lblBalance.Text = "Баланс счета:";
            // 
            // lblDepositType
            // 
            lblDepositType.AutoSize = true;
            lblDepositType.Location = new Point(27, 220);
            lblDepositType.Margin = new Padding(4, 0, 4, 0);
            lblDepositType.Name = "lblDepositType";
            lblDepositType.Size = new Size(89, 20);
            lblDepositType.TabIndex = 18;
            lblDepositType.Text = "Тип вклада:";
            // 
            // lblOpenDate
            // 
            lblOpenDate.AutoSize = true;
            lblOpenDate.Location = new Point(27, 266);
            lblOpenDate.Margin = new Padding(4, 0, 4, 0);
            lblOpenDate.Name = "lblOpenDate";
            lblOpenDate.Size = new Size(113, 20);
            lblOpenDate.TabIndex = 19;
            lblOpenDate.Text = "Дата открытия:";
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Location = new Point(27, 312);
            lblBirthDate.Margin = new Padding(4, 0, 4, 0);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(119, 20);
            lblBirthDate.TabIndex = 20;
            lblBirthDate.Text = "Дата рождения:";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(200, 355);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(265, 27);
            txtPhoneNumber.TabIndex = 21;
            txtPhoneNumber.Text = "+375291234567";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(27, 355);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(130, 20);
            lblPhoneNumber.TabIndex = 22;
            lblPhoneNumber.Text = "Номер телефона:";
            // 
            // lblAdress
            // 
            lblAdress.AutoSize = true;
            lblAdress.Location = new Point(27, 394);
            lblAdress.Name = "lblAdress";
            lblAdress.Size = new Size(147, 20);
            lblAdress.TabIndex = 23;
            lblAdress.Text = "Адрес проживания:";
            // 
            // txtAdress
            // 
            txtAdress.Location = new Point(197, 396);
            txtAdress.Name = "txtAdress";
            txtAdress.Size = new Size(268, 27);
            txtAdress.TabIndex = 24;
            txtAdress.Text = "ул. Пушкина д.150a кв. 52";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(29, 581);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(145, 20);
            linkLabel1.TabIndex = 25;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Служба Поддержки";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(871, 110);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(684, 678);
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1545, 789);
            Controls.Add(pictureBox1);
            Controls.Add(linkLabel1);
            Controls.Add(txtAdress);
            Controls.Add(lblAdress);
            Controls.Add(lblPhoneNumber);
            Controls.Add(txtPhoneNumber);
            Controls.Add(lblBirthDate);
            Controls.Add(lblOpenDate);
            Controls.Add(lblDepositType);
            Controls.Add(lblBalance);
            Controls.Add(lblPassportData);
            Controls.Add(lblOwnerName);
            Controls.Add(lblAccountNumber);
            Controls.Add(dgvBudget);
            Controls.Add(dgvAccounts);
            Controls.Add(btnCalculateBudget);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(chkInternetBanking);
            Controls.Add(chkSmsNotification);
            Controls.Add(dtpBirthDate);
            Controls.Add(dtpOpenDate);
            Controls.Add(cmbDepositType);
            Controls.Add(txtBalance);
            Controls.Add(txtPassportData);
            Controls.Add(txtOwnerName);
            Controls.Add(txtAccountNumber);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            Text = "Управление банковскими счетами";
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBudget).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtPhoneNumber;
        private Label lblPhoneNumber;
        private Label lblAdress;
        private TextBox txtAdress;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox1;
    }
}