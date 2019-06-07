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
using System.Windows.Shapes;
using System.Data;
using System.Text.RegularExpressions;


namespace Login
{
    /// <summary>
    /// Interaction logic for Form1.xaml
    /// </summary>
    public partial class Form1 : Window
    {
        Class1 c;
        DataTable d;
        int amt;
        public Form1()
        {
            InitializeComponent();
            c = new Login.Class1();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int x = int.Parse(textBox.Text);
            d = c.process(x);
            dataGrid.ItemsSource = d.DefaultView;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            amt = 0;
            foreach (DataRow row in d.Rows)
            {
                amt += int.Parse(row["cost"].ToString());
            }
            MessageBox.Show("Total Amount=" + amt);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            d.Clear();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            int x = int.Parse(textBox.Text);
            d = c.deleteItem(d, x);
            dataGrid.ItemsSource = d.DefaultView;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(textBox.Text);
            amt = 0;
            foreach (DataRow row in d.Rows)
            {
                amt += int.Parse(row["cost"].ToString());
            }
            if (a < amt)
                MessageBox.Show("Money entered is not sufficient to pay the bill");
            else
                MessageBox.Show("Thank You :)\n Change =" + (a - amt));
        }
    }
}
