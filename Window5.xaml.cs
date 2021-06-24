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

namespace FINALPROJECTPOS
{
    /// <summary>
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-MVCEUV6\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
        public Window5()
        {
            InitializeComponent();
            fill();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void fill()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Dog", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int did = dr.GetInt32(0);
                    int bid = dr.GetInt32(1);
                    int gid = dr.GetInt32(2);
                    int age = dr.GetInt32(3);
                    var bday = dr.GetDateTime(4).ToString("yyyy-MM-dd");
                    string desc = dr.GetString(5);
                    double price = dr.GetDouble(6);
                    int brid = dr.GetInt32(7);
                    int sid = dr.GetInt32(8);

                    string sp = "ID: " + did + ", BID: " + bid + ", GID: " + gid + ", Age: " + age + ", DoB: "
                        + bday + ", Description: " + desc + ", Price: " + price + " Php, BrID: " + brid + ", SID: " + sid;

                    upets.Items.Add(sp);
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void upets_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Dog where DID = " + (upets.SelectedIndex + 1), con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int did = dr.GetInt32(0);
                    int bid = dr.GetInt32(1);
                    int gid = dr.GetInt32(2);
                    int age = dr.GetInt32(3);
                    var bday = dr.GetDateTime(4).ToString("yyyy-MM-dd");
                    string desc = dr.GetString(5);
                    double price = dr.GetDouble(6);
                    int brid = dr.GetInt32(7);
                    int sid = dr.GetInt32(8);

                    tb0.Text = did.ToString();
                    tb1.Text = bid.ToString();
                    tb2.Text = gid.ToString();
                    tb3.Text = age.ToString();
                    tb4.Text = bday;
                    tb5.Text = desc;
                    tb6.Text = price.ToString();
                    tb7.Text = brid.ToString();
                    tb8.Text = sid.ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            string query = "update Dog set BID = " + tb1.Text + ", GID = " + tb2.Text + ", Age = "
                + tb3.Text + ", Birthday = '" + tb4.Text + "', Description = '" + tb5.Text + "', Price = "
                + tb6.Text + ", BrID = " + tb7.Text + "where DID = " + tb0.Text;
            SqlCommand cmd = new SqlCommand(query, con);

            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("Entry updated");
                con.Close();

                upets.Items.Clear();
                fill();
            }
            else
            {
                MessageBox.Show("Entry not saved", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
