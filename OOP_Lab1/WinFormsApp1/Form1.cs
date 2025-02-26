using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lengthTextBox.Text) || string.IsNullOrEmpty(widthTextBox.Text) || string.IsNullOrWhiteSpace(widthTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите значения длины и ширины.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double length = double.Parse(lengthTextBox.Text);
                double width = double.Parse(widthTextBox.Text);

                if (length < 1)
                {
                    MessageBox.Show("Пожалуйста, введите значения больше нуля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (width < 1) {
                    MessageBox.Show("Пожалуйста, введите значения больше нуля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                    Calculator calculator = new Calculator();

                double areaInSquareMeters = calculator.CalculateAreaInSquareMeters(length, width);
                double areaInSquareFeet = calculator.ConvertSquareMetersToSquareFeet(areaInSquareMeters);
                int laminateQuantity = calculator.CalculateLaminateQuantity(areaInSquareMeters, 0.5); 

                resultLabel.Text = $"Площадь в квадратных метрах: {areaInSquareMeters:F2}\n" +
                                  $"Площадь в квадратных футах: {areaInSquareFeet:F2}\n" +
                                  $"Рекомендуемое количество ламината: {laminateQuantity}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lengthTextBox_TextChanged(object sender, EventArgs e)
        {
        }
    }

    public class Calculator
    {

        public double CalculateAreaInSquareMeters(double length, double width)
        {
                return length * width;
        }

        public double ConvertSquareMetersToSquareFeet(double squareMeters)
        {
            return squareMeters * 10.7639;
        }

        public int CalculateLaminateQuantity(double area, double laminateSize)
        {
            return (int)Math.Ceiling(area / laminateSize);
        }
    }
}