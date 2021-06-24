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
using System.Data.SqlClient;

namespace FINALPROJECTPOS
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-MVCEUV6\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
        
        public Window3()
        {
            InitializeComponent();
            fill();

            int id = customers.Items.Count + 1;
            cid.Text = id.ToString();
        }

        private void fill()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Customer", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int cid = dr.GetInt32(0);
                    string cname = dr.GetString(1);
                    string cnum = dr.GetString(2);
                    int gid = dr.GetInt32(3);
                    string g = "";

                    if(gid == 1)
                    {
                        g = "Male";
                    }
                    else if(gid == 2)
                    {
                        g = "Female";
                    }

                    customers.Items.Add(cid + ". " + cname + ", " + cnum + ", " + g);
                }
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Customer(CID, Name, Contact_Number, GID) " +
                "values(" + cid.Text + ", '" + name.Text + "', '" + cn.Text + "', " + gid.Text +")" ,con);

            int i = cmd.ExecuteNonQuery();
            if(i != 0)
            {
                MessageBox.Show("Entry saved");
                con.Close();

                customers.Items.Clear();
                fill();
            }
            else
            {
                MessageBox.Show("Entry not saved", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
