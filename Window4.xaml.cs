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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FINALPROJECTPOS
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-MVCEUV6\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
        public Window4()
        {
            InitializeComponent();

            DispatcherTimer time = new DispatcherTimer();
            time.Interval = new TimeSpan(0, 0, 1);
            time.Tick += time_Tick;
            time.Start();

            dogbdfill();
            employeebdfill();
        }

        private void dogbdfill()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Dog where datepart(d, Birthday) = datepart(d, getdate()) and datepart(m, Birthday) = datepart(m, getdate())", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int did = dr.GetInt32(0);
                    int breed = dr.GetInt32(1);
                    int gender = dr.GetInt32(2);
                    int age = dr.GetInt32(3);
                    var bday = dr.GetDateTime(4).ToString("yyyy-MM-dd");

                    dogbd.Items.Add("ID = " + did + ", BreedID = " + breed + ", GenderID = " + gender + ", Age = " + age + ", DoB = " + bday);
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void employeebdfill()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Employee where datepart(d, Birthday) = datepart(d, getdate()) and datepart(m, Birthday) = datepart(m, getdate())", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int did = dr.GetInt32(0);
                    string name = dr.GetString(1);
                    var bday = dr.GetDateTime(2).ToString("yyyy-MM-dd");
                    string position = dr.GetString(6);
                    

                    dogbd.Items.Add("EID = " + did + ", " + name + ", " + bday + ", " + position);
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void time_Tick(object sender, EventArgs e)
        {
            date.Content = DateTime.Now.ToString();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
