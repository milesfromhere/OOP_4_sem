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
                    MessageBox.Show("����������, ������� �������� ����� � ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double length = double.Parse(lengthTextBox.Text);
                double width = double.Parse(widthTextBox.Text);

                if (length < 1)
                {
                    MessageBox.Show("����������, ������� �������� ������ ����.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (width < 1) {
                    MessageBox.Show("����������, ������� �������� ������ ����.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                    Calculator calculator = new Calculator();

                double areaInSquareMeters = calculator.CalculateAreaInSquareMeters(length, width);
                double areaInSquareFeet = calculator.ConvertSquareMetersToSquareFeet(areaInSquareMeters);
                int laminateQuantity = calculator.CalculateLaminateQuantity(areaInSquareMeters, 0.5); 

                resultLabel.Text = $"������� � ���������� ������: {areaInSquareMeters:F2}\n" +
                                  $"������� � ���������� �����: {areaInSquareFeet:F2}\n" +
                                  $"������������� ���������� ��������: {laminateQuantity}";
            }
            catch (FormatException)
            {
                MessageBox.Show("����������, ������� ���������� �������� ��������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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