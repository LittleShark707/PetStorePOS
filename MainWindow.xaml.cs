using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace FINALPROJECTPOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-MVCEUV6\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void elog_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            //w1.Show();
            //this.Close();

            try
            {
                int id = Int32.Parse(eid.Text);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Employee where EID = " + id, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //int i = dr.GetInt32(0);
                    string pos = dr.GetString(6);
                    string p = dr.GetString(8);

                    if (ep.Text == p)
                    {
                        if (!pos.Equals("Admin"))
                        {
                            w1.mm.Visibility = Visibility.Hidden;
                            w1.update.Visibility = Visibility.Hidden;
                            w1.insert.Visibility = Visibility.Hidden;
                        }
                        else if (pos.Equals("Admin"))
                        {
                            w1.mm.Visibility = Visibility.Visible;
                            w1.update.Visibility = Visibility.Visible;
                            w1.insert.Visibility = Visibility.Visible;
                        }

                        w1.Show();
                        w1.position.Content = pos;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("EID or Password is incorrect");
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
