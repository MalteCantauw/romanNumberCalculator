using Malte_Cantauw_flapo_it_exercise.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Malte_Cantauw_flapo_it_exercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private char[] operationList = { '+', '-', '*', '/' };
        Calculator calculator = new Calculator();

        public MainWindow()
        {
            InitializeComponent();
            cbOperaitions.ItemsSource = operationList;
            cbOperaitions.SelectedIndex = 0;
        }

        public void Button_Click_Calculate(object sender, RoutedEventArgs e)
        {
            string firstNumberString = calculator.Check_input_Valid(firstNumberTextBox.Text) ? firstNumberTextBox.Text : "";
            string secundNumberString = calculator.Check_input_Valid(secundNumberTextBox.Text) ? secundNumberTextBox.Text : "";
            if (firstNumberString != "" && secundNumberString != "")
            {
                switch (cbOperaitions.Text)
                {
                    case "+":
                        result.Text = calculator.Switch_to_roman(calculator.Switch_to_int(firstNumberString) + calculator.Switch_to_int(secundNumberString)).ToString(); break;
                    case "-":
                        result.Text = calculator.Switch_to_roman(calculator.Switch_to_int(firstNumberString) - calculator.Switch_to_int(secundNumberString)).ToString(); break;
                    case "*":
                        result.Text = calculator.Switch_to_roman(calculator.Switch_to_int(firstNumberString) * calculator.Switch_to_int(secundNumberString)).ToString(); break;
                    case "/":
                        result.Text = calculator.Switch_to_roman(calculator.Switch_to_int(firstNumberString) / calculator.Switch_to_int(secundNumberString)).ToString(); break;
                    default:
                        errorMessageBox.Text = $"The operation could not be performed use a vaild one.";
                        break;
                }
                return;
            }
            else
            {
                errorMessageBox.Text = "";
                if (firstNumberString == "")
                {
                    errorMessageBox.Text = $"The entered value for the first number is worng - {firstNumberTextBox.Text}. Pleas fix this number.";
                }
                if (secundNumberString == "")
                {
                    errorMessageBox.Text = errorMessageBox.Text + "\r\n" + $"The entered value for the secund number is worng - {secundNumberTextBox.Text}. Pleas fix this number.";
                }
            }
            result.Text = "calc";
        }

        /**
         * Function to ermit if the textbox value is still valid after a change.
         * @Param sender: object with the reference for the textbox in the ui.
         * @Param e: event that gets triggert after a change in the ui.
         */
        public void Textbox_Changed(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine("Textbox_Changed_check_valid");
            errorMessageBox.Text = "";
            TextBox textbox = (TextBox)sender;
            if (calculator.Check_input_Valid(textbox.Text))
            {
                return;
            }
            else
            {
                errorMessageBox.Text = "Bitten nutzen Sie nur Zahlen oder das römische Zahlensystem!";
            }
        }
    }
}