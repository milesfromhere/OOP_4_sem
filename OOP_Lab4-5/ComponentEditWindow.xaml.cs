using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace OOP_Lab4_5
{
    public partial class ComponentEditWindow : Window
    {
        public Component Component { get; set; }
        public ObservableCollection<string> Categories { get; } = new()
        {
            "Процессор", "Видеокарта", "Оперативная память",
            "Материнская плата", "Блок питания", "Накопитель",
            "Кулер", "Корпус"
        };

        private string _specificationsText;
        public string SpecificationsText
        {
            get => _specificationsText ?? string.Join("\n", Component.Specifications);
            set
            {
                _specificationsText = value;
                Component.Specifications = value.Split('\n')
                    .Select(s => s.Trim())
                    .Where(s => !string.IsNullOrEmpty(s))
                    .ToList();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public ComponentEditWindow()
        {
            try
            {
                InitializeComponent();
                Component = new Component();
                DataContext = this;

                SaveCommand = new RelayCommand(Save);
                CancelCommand = new RelayCommand(Cancel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации окна: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ComponentEditWindow(Component component) : this()
        {
            if (component != null)
            {
                Component = new Component
                {
                    Name = component.Name,
                    Price = component.Price,
                    ImagePath = component.ImagePath,
                    Category = component.Category,
                    Specifications = new List<string>(component.Specifications)
                };
                _specificationsText = string.Join("\n", component.Specifications);
            }
        }

        private void Save()
        {
            if (string.IsNullOrWhiteSpace(Component.Name))
            {
                MessageBox.Show("Введите название компонента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
            Close();
        }

        private void Cancel()
        {
            DialogResult = false;
            Close();
        }
    }
}