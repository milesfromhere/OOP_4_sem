using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using BankAccountManagement;

namespace BankAccountManagement
{


    public partial class MainForm : Form
    {
        private List<Account> accounts = new List<Account>();
        private Stack<List<Account>> undoStack = new Stack<List<Account>>();
        private Stack<List<Account>> redoStack = new Stack<List<Account>>();

        public MainForm()
        {
            InitializeComponent();
            dgvAccounts.AutoGenerateColumns = true;
            dgvAccounts.AllowUserToOrderColumns = true;
            dgvAccounts.ColumnHeaderMouseClick += dgvAccounts_ColumnHeaderMouseClick;
        }

        private void dgvAccounts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (accounts == null || accounts.Count == 0)
                return;

            string columnName = dgvAccounts.Columns[e.ColumnIndex].DataPropertyName;
            if (columnName == "Balance" || columnName == "AccountNumber")
            {
                SortData(columnName);
            }
        }

        public void SortData(string columnName)
        {
            bool isAscending = true;

            if (dgvAccounts.Tag != null && dgvAccounts.Tag.ToString() == columnName)
            {
                isAscending = false; 
                dgvAccounts.Tag = null;
            }
            else
            {
                dgvAccounts.Tag = columnName;
            }

            if (columnName == "Balance")
            {
                accounts = isAscending
                    ? accounts.OrderBy(a => a.Balance).ToList()
                    : accounts.OrderByDescending(a => a.Balance).ToList();
            }
            else if (columnName == "AccountNumber")
            {
                accounts = isAscending
                    ? accounts.OrderBy(a => a.AccountNumber).ToList()
                    : accounts.OrderByDescending(a => a.AccountNumber).ToList();
            }
            dgvAccounts.DataSource = null;
            dgvAccounts.DataSource = accounts;
        }

        private void SaveState()
        {
            undoStack.Push(CloneAccounts(accounts));
            redoStack.Clear(); 
        }

        private List<Account> CloneAccounts(List<Account> source)
        {
            return source.Select(acc => new Account
            {
                AccountNumber = acc.AccountNumber,
                DepositType = acc.DepositType,
                Balance = acc.Balance,
                OpenDate = acc.OpenDate,
                PhoneNumber = acc.PhoneNumber,
                Adress = acc.Adress,
                Owner = new Owner
                {
                    FullName = acc.Owner.FullName,
                    BirthDate = acc.Owner.BirthDate,
                    PassportData = acc.Owner.PassportData,
                    PhoneNumber = acc.Owner.PhoneNumber,
                    Adress = acc.Owner.Adress
                },
                SmsNotification = acc.SmsNotification,
                InternetBanking = acc.InternetBanking
            }).ToList();
        }

        private void btnCalculateBudget_Click(object sender, EventArgs e)
        {
            var budget = accounts.GroupBy(a => a.Owner.FullName)
                                .Select(g => new { Owner = g.Key, Budget = g.Sum(a => a.Balance) });

            dgvBudget.DataSource = budget.ToList();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void сортироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
                MessageBox.Show("Бондарик Никита Дмитриевич.Версия 1.0.0");
        }

        private List<Account> _data;

        private void LoadDataFromJson()
        {
            string jsonFilePath = "accounts.json"; 
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                _data = JsonSerializer.Deserialize<List<Account>>(json);
            }
            else
            {
                MessageBox.Show("Файл accounts.json не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _data = new List<Account>(); 
            }
        }

        private void поБалансуToolStripMenuItem1_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex >= dgvAccounts.Columns.Count)
            {
                MessageBox.Show("Недопустимый индекс столбца.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string columnName = dgvAccounts.Columns[e.ColumnIndex].Name;

            ListSortDirection direction;
            if (dgvAccounts.SortedColumn == dgvAccounts.Columns[e.ColumnIndex] &&
                dgvAccounts.SortOrder == SortOrder.Ascending)
            {
                direction = ListSortDirection.Descending;
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            SortData(columnName, direction);

            dgvAccounts.DataSource = null;
            dgvAccounts.DataSource = _data;
        }

        private void SortData(string columnName, ListSortDirection direction)
        {
            switch (columnName)
            {
                case "FullName":
                    if (direction == ListSortDirection.Ascending)
                    {
                        _data = _data.OrderBy(x => x.Owner.FullName).ToList();
                    }
                    else
                    {
                        _data = _data.OrderByDescending(x => x.Owner.FullName).ToList();
                    }
                    break;

                case "Balance":
                    if (direction == ListSortDirection.Ascending)
                    {
                        _data = _data.OrderBy(x => x.Balance).ToList();
                    }
                    else
                    {
                        _data = _data.OrderByDescending(x => x.Balance).ToList();
                    }
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveState();

            var account = new Account
            {
                AccountNumber = txtAccountNumber.Text,
                DepositType = cmbDepositType.SelectedItem?.ToString(),
                Balance = decimal.Parse(txtBalance.Text),
                OpenDate = dtpOpenDate.Value,
                PhoneNumber = txtPhoneNumber.Text,
                Adress = txtAdress.Text,
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
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(account);
            if (!Validator.TryValidateObject(account, validationContext, validationResults, true))
            {
                string errorMessages = string.Join("\n", validationResults.Select(vr => vr.ErrorMessage));
                MessageBox.Show(errorMessages, "Ошибка валидации.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            accounts.Add(account);
            dgvAccounts.DataSource = null;
            dgvAccounts.DataSource = accounts;
            SaveToFile(accounts, "accounts.json");
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            accounts = LoadFromFile<List<Account>>("accounts.json");
            dgvAccounts.DataSource = null;
            dgvAccounts.DataSource = accounts;
        }


        private void поИмениToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
                dgvAccounts.DataSource = null;
                accounts.Clear();
                dgvBudget.DataSource = null;
                MessageBox.Show("Очистка выполнена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (accounts.Count == 0)
            {
                MessageBox.Show("Нет записей для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveState(); 

            accounts.Clear();
            dgvAccounts.DataSource = null;
            dgvBudget.DataSource = null;

            SaveToFile(accounts, "accounts.json");
            MessageBox.Show("Все записи удалены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int currentIndex = 0;

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 0)
            {
                redoStack.Push(CloneAccounts(accounts));
                accounts = undoStack.Pop(); 
                dgvAccounts.DataSource = null;
                dgvAccounts.DataSource = accounts;

                dgvAccounts.Visible = accounts.Count > 0;
            }
            else
            {
                MessageBox.Show("Нет действий для отмены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void вперёдToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0)
            {
                undoStack.Push(CloneAccounts(accounts)); 
                accounts = redoStack.Pop(); 
                dgvAccounts.DataSource = null;
                dgvAccounts.DataSource = accounts;

                dgvAccounts.Visible = accounts.Count > 0;
            }
            else
            {
                MessageBox.Show("Нет действий для возврата.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveToFile<T>(T data, string fileName)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }

        private void SearchByAccountNumber()
        {
            
        }


        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите номер счета для поиска:", "Поиск по номеру счета", "");

            if (!string.IsNullOrWhiteSpace(input))
            {
                var filteredAccounts = accounts.Where(a => a.AccountNumber.Contains(input)).ToList();

                if (filteredAccounts.Count > 0)
                {
                    dgvAccounts.DataSource = null;
                    dgvAccounts.DataSource = filteredAccounts;
                }
                else
                {
                    MessageBox.Show("Счет не найден.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private T LoadFromFile<T>(string fileName)
        {
            var json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<T>(json);
        }
    }

    public class PhoneNumberAttribute : ValidationAttribute
    {
        public PhoneNumberAttribute() : base("Номер телефона имеет неверный формат.")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            string phoneNumber = value.ToString();
            var regex = new Regex(@"^\+?\d{1,4}?[\s.-]?\(?\d{1,3}?\)?[\s.-]?\d{1,4}[\s.-]?\d{1,4}[\s.-]?\d{1,9}$");

            if (!regex.IsMatch(phoneNumber))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }

    public class PassportDataAttribute : ValidationAttribute
    {
        public PassportDataAttribute() : base("Некорректный номер паспорта.")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("Данные паспорта не могут быть пустыми.");
            }

            string passportData = value.ToString();
            var regex = new Regex(@"^\d{4}\s\d{6}$");

            if (!regex.IsMatch(passportData))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
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

    [PhoneNumber]
    public string PhoneNumber { get; set; }

    public string Adress { get; set; }
}

public class Owner
    {
    public string FullName { get; set; }
    
    public DateTime BirthDate { get; set; }
    [PassportData]
        public string PassportData { get; set; }

    [PhoneNumber]
        public string PhoneNumber { get; set; }

    public string Adress { get; set; }
}
}