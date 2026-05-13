using MySql.Data.MySqlClient;
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

namespace jozsi
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(AgeBox.Text, out int age))
            {
                MessageBox.Show("Az életkor szám legyen!");
                return;
            }

            string connStr = "server=localhost;user=root;password=;database=usesr;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "INSERT INTO users (username, address, age) VALUES (@name, @address, @age)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", NameBox.Text);
                    cmd.Parameters.AddWithValue("@address", AddressBox.Text);
                    cmd.Parameters.AddWithValue("@age", age);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Mentve!");
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
