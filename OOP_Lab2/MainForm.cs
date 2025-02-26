using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace BankAccountManagement
{
    public partial class MainForm : Form
    {
        private List<Account> accounts = new List<Account>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAccountNumber.Text) || string.IsNullOrEmpty(txtOwnerName.Text) || string.IsNullOrEmpty(txtAccountNumber.Text) || string.IsNullOrEmpty(cmbDepositType.Text) || string.IsNullOrWhiteSpace(cmbDepositType.Text) || string.IsNullOrWhiteSpace(txtPhoneNumber.Text) || string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                MessageBox.Show("Заполните все обязательные поля.");
                return;
            }
            double Text = double.Parse(txtAccountNumber.Text);

            if (Text < 1000000000 || Text > 9999999999)
            {
                MessageBox.Show("Номер введён неправильно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var account = new Account
            {
                AccountNumber = txtAccountNumber.Text,
                DepositType = cmbDepositType.SelectedItem?.ToString(),
                Balance = decimal.Parse(txtBalance.Text),
                OpenDate = dtpOpenDate.Value,
                PhoneNumber = txtPhoneNumber.Text?.ToString(),
                Adress = txtAdress.Text?.ToString(),
                Owner = new Owner
                {
                    FullName = txtOwnerName.Text,
                    BirthDate = dtpBirthDate.Value,
                    PassportData = txtPassportData.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Adress = txtAdress.Text
                },
                SmsNotification = chkSmsNotification.Checked,
                InternetBanking = chkInternetBanking.Checked
            };

            accounts.Add(account);

            SaveToFile(accounts, "accounts.json");

            MessageBox.Show("Данные сохранены.");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            accounts = LoadFromFile<List<Account>>("accounts.json");

            dgvAccounts.DataSource = accounts;
        }

        private void btnCalculateBudget_Click(object sender, EventArgs e)
        {
            var budget = accounts.GroupBy(a => a.Owner.FullName)
                                .Select(g => new { Owner = g.Key, Budget = g.Sum(a => a.Balance) });

            dgvBudget.DataSource = budget.ToList();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("http://metanit.com");
        }

        private void SaveToFile<T>(T data, string fileName)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }

        private T LoadFromFile<T>(string fileName)
        {
            var json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<T>(json);
        }
    }

    public class Account
    {
        public string AccountNumber { get; set; }
        public string DepositType { get; set; }
        public decimal Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public Owner Owner { get; set; }
        public bool SmsNotification { get; set; }
        public bool InternetBanking { get; set; }

        public string PhoneNumber {  get; set; }

        public string Adress { get; set; }
    }

    public class Owner
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PassportData { get; set; }

        public string PhoneNumber { get; set; }

        public string Adress { get; set; }
    }
}