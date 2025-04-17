using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Text.Json;
using System.IO;
using System.Globalization;
using System.Windows.Data;

namespace OOP_Lab4_5
{

    public class ThemeIconConverter : IValueConverter
    {
        public static ThemeIconConverter Instance { get; } = new ThemeIconConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool isDarkTheme && isDarkTheme) ? "🌙" : "☀";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void OpenComponentsWindow()
        {
            var window = new ComponentsWindow();
            window.ShowDialog();
        }

        private bool _isDarkTheme = true;
        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set
            {
                _isDarkTheme = value;
                OnPropertyChanged();
                ApplyTheme();
            }
        }

        private void ApplyTheme()
        {
            var app = Application.Current;
            if (app == null) return;

            if (IsDarkTheme)
            {
                app.Resources.MergedDictionaries[0].Source = new Uri("Styles.xaml", UriKind.Relative);
            }
            else
            {
                app.Resources.MergedDictionaries[0].Source = new Uri("LightStyles.xaml", UriKind.Relative);
            }
        }

        public void ChangeLanguage(string languageCode)
        {
            var dict = new ResourceDictionary();

            if (languageCode == "en-US")
                dict.Source = new Uri("Resources/Strings.en-US.xaml", UriKind.Relative);
            else
                dict.Source = new Uri("Resources/Strings.ru-RU.xaml", UriKind.Relative);

            // Находим и удаляем только языковые ресурсы
            var oldDict = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.StartsWith("Resources/Strings."));

            if (oldDict != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(oldDict);
            }

            // Добавляем новые языковые ресурсы
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        // Коллекции компонентов
        public ObservableCollection<Component> CPUs { get; } = new();
        public ObservableCollection<Component> GPUs { get; } = new();
        public ObservableCollection<Component> RAMs { get; } = new();
        public ObservableCollection<Component> Motherboards { get; } = new();
        public ObservableCollection<Component> PSUs { get; } = new();
        public ObservableCollection<Component> Storages { get; } = new();
        public ObservableCollection<Component> Coolers { get; } = new();
        public ObservableCollection<Component> Cases { get; } = new();

        // Выбранные компоненты
        private Component _selectedCPU, _selectedGPU, _selectedRAM, _selectedMotherboard,
                         _selectedPSU, _selectedStorage, _selectedCooler, _selectedCase;
        private Component _selectedComponent;
        private string _imagePath;

        public class Component
        {
            public string Name { get; set; }
            public decimal Price { get; set; }

            private string _imagePath;
            public string ImagePath
            {
                get => GetCorrectImagePath(_imagePath);
                set => _imagePath = value;
            }

            public List<string> Specifications { get; set; } = new();
            public string SpecificationsString => string.Join(Environment.NewLine, Specifications);

            private string GetCorrectImagePath(string rawPath)
            {
                if (string.IsNullOrEmpty(rawPath))
                {
                    return "pack://application:,,,/Images/placeholder.png";
                }

                // Если путь уже в формате pack://, возвращаем как есть
                if (rawPath.StartsWith("pack://"))
                {
                    return rawPath;
                }

                // Если путь абсолютный и файл существует
                if (System.IO.Path.IsPathRooted(rawPath) && File.Exists(rawPath))
                {
                    return new Uri(rawPath).AbsoluteUri;
                }

                // Относительный путь в проекте
                return $"pack://application:,,,/{rawPath.TrimStart('/')}";
            }
        }
        public Component SelectedComponent
        {
            get => _selectedComponent;
            set
            {
                _selectedComponent = value;
                OnPropertyChanged();
            }
        }

        public Component SelectedCPU
        {
            get => _selectedCPU;
            set
            {
                _selectedCPU = value;
                OnPropertyChanged();
                UpdateConfiguration();
                UpdateSelectedComponent();
            }
        }

        public Component SelectedGPU
        {
            get => _selectedGPU;
            set
            {
                _selectedGPU = value;
                OnPropertyChanged();
                UpdateConfiguration();
                UpdateSelectedComponent();
            }
        }

        public Component SelectedRAM
        {
            get => _selectedRAM;
            set
            {
                _selectedRAM = value;
                OnPropertyChanged();
                UpdateConfiguration();
                UpdateSelectedComponent();
            }
        }

        public Component SelectedMotherboard
        {
            get => _selectedMotherboard;
            set
            {
                _selectedMotherboard = value;
                OnPropertyChanged();
                UpdateConfiguration();
                UpdateSelectedComponent();
            }
        }

        public Component SelectedPSU
        {
            get => _selectedPSU;
            set
            {
                _selectedPSU = value;
                OnPropertyChanged();
                UpdateConfiguration();
                UpdateSelectedComponent();
            }
        }

        public Component SelectedStorage
        {
            get => _selectedStorage;
            set
            {
                _selectedStorage = value;
                OnPropertyChanged();
                UpdateConfiguration();
                UpdateSelectedComponent();
            }
        }

        public Component SelectedCooler
        {
            get => _selectedCooler;
            set
            {
                _selectedCooler = value;
                OnPropertyChanged();
                UpdateConfiguration();
                UpdateSelectedComponent();
            }
        }

        public Component SelectedCase
        {
            get => _selectedCase;
            set
            {
                _selectedCase = value;
                OnPropertyChanged();
                UpdateConfiguration();
                UpdateSelectedComponent();
            }
        }

        public class ComponentData
        {
            public List<Component> CPUs { get; set; }
            public List<Component> GPUs { get; set; }
            public List<Component> RAMs { get; set; }
            public List<Component> Motherboards { get; set; }
            public List<Component> PSUs { get; set; }
            public List<Component> Storages { get; set; }
            public List<Component> Coolers { get; set; }
            public List<Component> Cases { get; set; }
        }

        // Текущая конфигурация
        public ObservableCollection<Component> CurrentConfiguration { get; } = new();
        public decimal TotalPrice => CurrentConfiguration.Sum(c => c?.Price ?? 0);

        // Команды
        public ICommand OpenComponentsCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand ResetCommand { get; }
        public ICommand RemoveComponentCommand { get; }
        public ICommand ChangeThemeCommand { get; }
        public ICommand ChangeLanguageCommand { get; }

        public MainViewModel()
        {
            LoadComponentsFromJson();
            OpenComponentsCommand = new RelayCommand(OpenComponentsWindow);
            SaveCommand = new RelayCommand(SaveConfiguration);
            ResetCommand = new RelayCommand(ResetConfiguration);
            RemoveComponentCommand = new RelayCommand<Component>(RemoveComponent);
            ChangeThemeCommand = new RelayCommand(ToggleTheme);
            ChangeLanguageCommand = new RelayCommand<string>(ChangeLanguage);
            InitializeComponents();
        }

        private void ToggleTheme()
        {
            IsDarkTheme = !IsDarkTheme;
        }

        private void LoadComponentsFromJson()
        {
            try
            {
                var json = File.ReadAllText("Components.json");
                var data = JsonSerializer.Deserialize<ComponentData>(json);

                CPUs.Clear();
                foreach (var item in data.CPUs) CPUs.Add(item);

                GPUs.Clear();
                foreach (var item in data.GPUs) GPUs.Add(item);

                RAMs.Clear();
                foreach (var item in data.RAMs) RAMs.Add(item);

                Motherboards.Clear();
                foreach (var item in data.Motherboards) Motherboards.Add(item);

                PSUs.Clear();
                foreach (var item in data.PSUs) PSUs.Add(item);

                Storages.Clear();
                foreach (var item in data.Storages) Storages.Add(item);

                Coolers.Clear();
                foreach (var item in data.Coolers) Coolers.Add(item);

                Cases.Clear();
                foreach (var item in data.Cases) Cases.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading components: {ex.Message}");
            }
        }

        private void InitializeComponents()
        { }

        public static class LanguageManager
        {
            public static void SetLanguage(string languageCode)
            {
                var dict = new ResourceDictionary();
                dict.Source = new Uri($"Resources/Strings.{languageCode}.xaml", UriKind.Relative);

                // Удаляем старые ресурсы
                var oldDict = Application.Current.Resources.MergedDictionaries
                    .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.StartsWith("Resources/Strings."));
                if (oldDict != null)
                {
                    Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                }

                Application.Current.Resources.MergedDictionaries.Add(dict);
            }
        }

        private void UpdateConfiguration()
        {
            CurrentConfiguration.Clear();

            if (SelectedCPU != null) CurrentConfiguration.Add(SelectedCPU);
            if (SelectedGPU != null) CurrentConfiguration.Add(SelectedGPU);
            if (SelectedRAM != null) CurrentConfiguration.Add(SelectedRAM);
            if (SelectedMotherboard != null) CurrentConfiguration.Add(SelectedMotherboard);
            if (SelectedPSU != null) CurrentConfiguration.Add(SelectedPSU);
            if (SelectedStorage != null) CurrentConfiguration.Add(SelectedStorage);
            if (SelectedCooler != null) CurrentConfiguration.Add(SelectedCooler);
            if (SelectedCase != null) CurrentConfiguration.Add(SelectedCase);

            OnPropertyChanged(nameof(CurrentConfiguration));
            OnPropertyChanged(nameof(TotalPrice));
        }

        private void UpdateSelectedComponent()
        {
            var lastSelected = new[]
            {
                SelectedCPU, SelectedGPU, SelectedRAM, SelectedMotherboard,
                SelectedPSU, SelectedStorage, SelectedCooler, SelectedCase
            }.LastOrDefault(c => c != null);

            SelectedComponent = lastSelected;
        }

        private void RemoveComponent(Component component)
        {
            if (component == SelectedCPU) SelectedCPU = null;
            else if (component == SelectedGPU) SelectedGPU = null;
            else if (component == SelectedRAM) SelectedRAM = null;
            else if (component == SelectedMotherboard) SelectedMotherboard = null;
            else if (component == SelectedPSU) SelectedPSU = null;
            else if (component == SelectedStorage) SelectedStorage = null;
            else if (component == SelectedCooler) SelectedCooler = null;
            else if (component == SelectedCase) SelectedCase = null;

            CurrentConfiguration.Remove(component);
            UpdateSelectedComponent();
        }

        private void ResetConfiguration()
        {
            SelectedCPU = SelectedGPU = SelectedRAM = SelectedMotherboard =
            SelectedPSU = SelectedStorage = SelectedCooler = SelectedCase = null;
            SelectedComponent = null;
        }

        private void SaveConfiguration()
        {
            if (!CurrentConfiguration.Any())
            {
                MessageBox.Show("Выберите хотя бы один компонент!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string config = string.Join("\n", CurrentConfiguration.Select(c => $"{c.Name} - {c.Price}BYN"));
            MessageBox.Show($"Конфигурация сохранена!\n\n{config}\n\nИтого: {TotalPrice}BYN",
                          "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute, Func<bool> canExecute = null) =>
            (_execute, _canExecute) = (execute ?? throw new ArgumentNullException(nameof(execute)), canExecute);

        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;
        public void Execute(object parameter) => _execute();
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null) =>
            (_execute, _canExecute) = (execute ?? throw new ArgumentNullException(nameof(execute)), canExecute);

        public bool CanExecute(object parameter) => _canExecute?.Invoke((T)parameter) ?? true;
        public void Execute(object parameter) => _execute((T)parameter);
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}