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
using System.Data;

namespace FINALPROJECTPOS
{
    /// <summary>
    /// Interaction logic for Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-MVCEUV6\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
        public Window6()
        {
            InitializeComponent();
            fillbid();
            fillgid();
            fillbrid();

            Window5 w5 = new Window5();
            int id = w5.upets.Items.Count + 1;
            tb0.Text = id.ToString();
            tb8.Text = 1.ToString();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            string query = "insert Dog values( " + tb0.Text + ", " + tb1.Text + ", " + tb2.Text + ", "
                + tb3.Text + ", '" + tb4.Text + "', '" + tb5.Text + "', "
                + tb6.Text + ", " + tb7.Text + ", " + tb8.Text + ")";
            SqlCommand cmd = new SqlCommand(query, con);

            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("Entry saved");
                con.Close();
            }
            else
            {
                MessageBox.Show("Entry not saved", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void fillbid()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Breed", con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Breed");
                adp.Fill(dt);
                bid.ItemsSource = dt.DefaultView;
                adp.Update(dt);

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void fillgid()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Gender", con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Gender");
                adp.Fill(dt);
                gid.ItemsSource = dt.DefaultView;
                adp.Update(dt);

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void fillbrid()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select BrID, Name from Breeder", con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Breeder");
                adp.Fill(dt);
                brid.ItemsSource = dt.DefaultView;
                adp.Update(dt);

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
