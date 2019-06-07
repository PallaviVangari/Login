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
using System.Data.SqlClient;
using System.Data;

namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            password.PasswordChar = '*';
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HR2SEVF\SQLEXPRESS;Initial Catalog=my;User ID=sa;Password=pallavi");
            string query = "select * from login_table where UserName='" + username.Text.Trim() + "'and Password1='" + password.Password.ToString().Trim() + "';";
            SqlDataAdapter sd = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                if (ConnectionState.Closed == conn.State)
                    conn.Open();

            }
            catch
            { }
            sd.Fill(dt);
            if(dt.Rows.Count == 1)
            {
                Form1 obj = new Login.Form1();
                this.Hide();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
            
        }

    }
}
