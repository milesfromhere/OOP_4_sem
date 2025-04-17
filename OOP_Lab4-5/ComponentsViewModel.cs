using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Text.Json;
using System.IO;

namespace OOP_Lab4_5
{
    public class ComponentsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private List<Component> _allComponents = new();
        private Component _selectedComponent;
        private string _searchText;
        private string _selectedCategory;
        private decimal? _minPrice;
        private decimal? _maxPrice;

        public ObservableCollection<Component> FilteredComponents { get; } = new();
        public ObservableCollection<string> Categories { get; } = new();
        public ObservableCollection<string> PriceSortOptions { get; } = new() { "По возрастанию", "По убыванию" };

        public Component SelectedComponent
        {
            get => _selectedComponent;
            set
            {
                _selectedComponent = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                ApplyFilters();
            }
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                ApplyFilters();
            }
        }

        public decimal? MinPrice
        {
            get => _minPrice;
            set
            {
                _minPrice = value;
                OnPropertyChanged();
                ApplyFilters();
            }
        }

        public decimal? MaxPrice
        {
            get => _maxPrice;
            set
            {
                _maxPrice = value;
                OnPropertyChanged();
                ApplyFilters();
            }
        }

        public ICommand ApplyFiltersCommand { get; }
        public ICommand ResetFiltersCommand { get; }
        public ICommand AddComponentCommand { get; }
        public ICommand EditComponentCommand { get; }
        public ICommand DeleteComponentCommand { get; }

        public ComponentsViewModel()
        {
            LoadComponents();
            InitializeCategories();

            ApplyFiltersCommand = new RelayCommand(ApplyFilters);
            ResetFiltersCommand = new RelayCommand(ResetFilters);
            AddComponentCommand = new RelayCommand(AddComponent);
            EditComponentCommand = new RelayCommand(EditComponent, CanEditDelete);
            DeleteComponentCommand = new RelayCommand(DeleteComponent, CanEditDelete);
        }

        private bool CanEditDelete() => SelectedComponent != null;

        private void LoadComponents()
        {
            try
            {
                var json = File.ReadAllText("Components.json");
                var data = JsonSerializer.Deserialize<ComponentData>(json);

                _allComponents.Clear();

                _allComponents.AddRange(data.CPUs.Select(c => { c.Category = "Процессор"; return c; }));
                _allComponents.AddRange(data.GPUs.Select(c => { c.Category = "Видеокарта"; return c; }));
                _allComponents.AddRange(data.RAMs.Select(c => { c.Category = "Оперативная память"; return c; }));
                _allComponents.AddRange(data.Motherboards.Select(c => { c.Category = "Материнская плата"; return c; }));
                _allComponents.AddRange(data.PSUs.Select(c => { c.Category = "Блок питания"; return c; }));
                _allComponents.AddRange(data.Storages.Select(c => { c.Category = "Накопитель"; return c; }));
                _allComponents.AddRange(data.Coolers.Select(c => { c.Category = "Кулер"; return c; }));
                _allComponents.AddRange(data.Cases.Select(c => { c.Category = "Корпус"; return c; }));

                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки компонентов: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InitializeCategories()
        {
            Categories.Clear();
            Categories.Add("Все");
            Categories.Add("Процессор");
            Categories.Add("Видеокарта");
            Categories.Add("Оперативная память");
            Categories.Add("Материнская плата");
            Categories.Add("Блок питания");
            Categories.Add("Накопитель");
            Categories.Add("Кулер");
            Categories.Add("Корпус");

            SelectedCategory = "Все";
        }

        private void ApplyFilters()
        {
            FilteredComponents.Clear();

            var query = _allComponents.AsEnumerable();

            if (!string.IsNullOrEmpty(SearchText))
            {
                query = query.Where(c => c.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(SelectedCategory) && SelectedCategory != "Все")
            {
                query = query.Where(c => c.Category == SelectedCategory);
            }

            if (MinPrice.HasValue)
            {
                query = query.Where(c => c.Price >= MinPrice.Value);
            }

            if (MaxPrice.HasValue)
            {
                query = query.Where(c => c.Price <= MaxPrice.Value);
            }

            foreach (var component in query.OrderBy(c => c.Name))
            {
                FilteredComponents.Add(component);
            }
        }

        private void ResetFilters()
        {
            SearchText = string.Empty;
            SelectedCategory = "Все";
            MinPrice = null;
            MaxPrice = null;
        }

        private void AddComponent()
        {
            var dialog = new ComponentEditWindow();
            if (dialog.ShowDialog() == true)
            {
                _allComponents.Add(dialog.Component);
                ApplyFilters();
                SaveComponentsToJson();
            }
        }

        private void EditComponent()
        {
            if (SelectedComponent == null) return;

            var dialog = new ComponentEditWindow(SelectedComponent);
            if (dialog.ShowDialog() == true)
            {
                var index = _allComponents.IndexOf(SelectedComponent);
                if (index >= 0)
                {
                    _allComponents[index] = dialog.Component;
                    ApplyFilters();
                    SaveComponentsToJson();
                }
            }
        }

        private void DeleteComponent()
        {
            if (SelectedComponent == null) return;

            if (MessageBox.Show($"Удалить компонент: {SelectedComponent.Name}?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _allComponents.Remove(SelectedComponent);
                SelectedComponent = null;
                ApplyFilters();
                SaveComponentsToJson();
            }
        }

        private void SaveComponentsToJson()
        {
            try
            {
                var data = new ComponentData
                {
                    CPUs = _allComponents.Where(c => c.Category == "Процессор").ToList(),
                    GPUs = _allComponents.Where(c => c.Category == "Видеокарта").ToList(),
                    RAMs = _allComponents.Where(c => c.Category == "Оперативная память").ToList(),
                    Motherboards = _allComponents.Where(c => c.Category == "Материнская плата").ToList(),
                    PSUs = _allComponents.Where(c => c.Category == "Блок питания").ToList(),
                    Storages = _allComponents.Where(c => c.Category == "Накопитель").ToList(),
                    Coolers = _allComponents.Where(c => c.Category == "Кулер").ToList(),
                    Cases = _allComponents.Where(c => c.Category == "Корпус").ToList()
                };

                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(data, options);
                File.WriteAllText("Components.json", json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения компонентов: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}