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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-MVCEUV6\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
        public Window2()
        {
            InitializeComponent();
            fill();

            int id = transactions.Items.Count + 1;
            rid.Text = id.ToString();
        }

        private void fill()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Receipt", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int rid = dr.GetInt32(0);
                    int did = dr.GetInt32(1);
                    int pid = dr.GetInt32(2);
                    var date = dr.GetDateTime(3).ToString("yyyy-MM-dd");
                    double price = dr.GetDouble(4);
                    double tax = dr.GetDouble(5);
                    double tp = dr.GetDouble(6);
                    double ar = dr.GetDouble(7);
                    double change = dr.GetDouble(8);
                    int cid = dr.GetInt32(9);
                    int eid = dr.GetInt32(10);
                    
                    transactions.Items.Add(rid + ". " + did + ", " + pid + ", " + date + ", " 
                        + price + ", " + tax + ", " + tp + ", " + ar + ", " + change + ", " + cid + ", " + eid);
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            string query = "insert into Receipt(RID, DID, PID, Date, Price, Tax, Total_Price, Amount_Received, Change, CID, EID) " +
                "values(" + rid.Text + ", " + did.Text + ", " + pid.Text + ", '" + date.Text + "', " 
                + price.Text + ", 0, 0, " + ar.Text + ", 0, " + cid.Text + ", " + eid.Text + ")";
            SqlCommand cmd = new SqlCommand(query, con);

            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("Entry saved");
                con.Close();

                transactions.Items.Clear();
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
