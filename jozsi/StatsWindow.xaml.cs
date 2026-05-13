using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for StatsWindow.xaml
    /// </summary>
    public partial class StatsWindow : Window

    {
        public ObservableCollection<User> Users { get; set; }
    = new ObservableCollection<User>();

        public StatsWindow()
        {
            InitializeComponent();
            LoadUsers();
            DataContext = Users;
        }

        private void LoadUsers()
        {
            string connStr = "server=localhost;user=root;password=;database=usesr;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT username, address, age FROM users";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Users.Add(new User
                        {
                            Name = reader.GetString("username"),
                            Address = reader.GetString("address"),
                            Age = reader.GetInt32("age")
                        });
                    }
                }
            }
        }


    }
}
