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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-MVCEUV6\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
        public Window1()
        {
            InitializeComponent();
            select();
            fillage();
            fillbreed();
            fillgender();
            fillprice();
        }

        private void fillage()
        {
            age.Items.Add("4 months or less");
            age.Items.Add("5 to 11 months");
            age.Items.Add("12 months or more");
        }

        private void fillbreed()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Breed", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string b = dr.GetString(1);

                    breed.Items.Add(b);
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void fillgender()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Gender", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string g = dr.GetString(1);

                    gender.Items.Add(g);
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void fillprice()
        {
            price.Items.Add("below 25K");
            price.Items.Add("25K - 50K");
            price.Items.Add("over 50K");
        }

        private void fill(string script)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(script, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int did = dr.GetInt32(0);
                    string breed = dr.GetString(1);
                    string gender = dr.GetString(2);
                    int age = dr.GetInt32(3);
                    var bday = dr.GetDateTime(4).ToString("yyyy-MM-dd");
                    double price = dr.GetDouble(5);
                    string br = dr.GetString(6);
                    string stat = dr.GetString(7);

                    StackPanel sp = new StackPanel();
                    sp.Orientation = Orientation.Horizontal;
                    //BitmapImage doggo = new BitmapImage(new Uri(@"C:\Users\Natasja\source\repos\FINALPROJECTPOS\FINALPROJECTPOS\images\chihuahua.png"));


                    if (breed == "Chihuahua")
                    {
                        BitmapImage doggo = new BitmapImage(new Uri(@"C:\Users\Natasja\source\repos\FINALPROJECTPOS\FINALPROJECTPOS\images\chihuahua.png"));
                        Image thedoggo = new Image();
                        thedoggo.Source = doggo;

                        thedoggo.Width = 125;
                        thedoggo.Height = 125;

                        sp.Children.Add(thedoggo);
                    }
                    else if (breed == "Corgi")
                    {
                        BitmapImage doggo = new BitmapImage(new Uri(@"C:\Users\Natasja\source\repos\FINALPROJECTPOS\FINALPROJECTPOS\images\corgi.png"));
                        Image thedoggo = new Image();
                        thedoggo.Source = doggo;

                        thedoggo.Width = 125;
                        thedoggo.Height = 125;

                        sp.Children.Add(thedoggo);
                    }
                    else if (breed == "Maltese")
                    {
                        BitmapImage doggo = new BitmapImage(new Uri(@"C:\Users\Natasja\source\repos\FINALPROJECTPOS\FINALPROJECTPOS\images\maltese.jpg"));
                        Image thedoggo = new Image();
                        thedoggo.Source = doggo;

                        thedoggo.Width = 125;
                        thedoggo.Height = 125;

                        sp.Children.Add(thedoggo);
                    }
                    else if (breed == "Pomeranian")
                    {
                        BitmapImage doggo = new BitmapImage(new Uri(@"C:\Users\Natasja\source\repos\FINALPROJECTPOS\FINALPROJECTPOS\images\pomeranian.png"));
                        Image thedoggo = new Image();
                        thedoggo.Source = doggo;

                        thedoggo.Width = 125;
                        thedoggo.Height = 125;

                        sp.Children.Add(thedoggo);
                    }
                    else if (breed == "Pug")
                    {
                        BitmapImage doggo = new BitmapImage(new Uri(@"C:\Users\Natasja\source\repos\FINALPROJECTPOS\FINALPROJECTPOS\images\pug.png"));
                        Image thedoggo = new Image();
                        thedoggo.Source = doggo;

                        thedoggo.Width = 125;
                        thedoggo.Height = 125;

                        sp.Children.Add(thedoggo);
                    }
                    else if (breed == "Toy Poodle")
                    {
                        BitmapImage doggo = new BitmapImage(new Uri(@"C:\Users\Natasja\source\repos\FINALPROJECTPOS\FINALPROJECTPOS\images\poodle.png"));
                        Image thedoggo = new Image();
                        thedoggo.Source = doggo;

                        thedoggo.Width = 125;
                        thedoggo.Height = 125;

                        sp.Children.Add(thedoggo);
                    }
                    else if (breed == "Yorkie")
                    {
                        BitmapImage doggo = new BitmapImage(new Uri(@"C:\Users\Natasja\source\repos\FINALPROJECTPOS\FINALPROJECTPOS\images\yorkie.jpg"));
                        Image thedoggo = new Image();
                        thedoggo.Source = doggo;

                        thedoggo.Width = 125;
                        thedoggo.Height = 125;

                        sp.Children.Add(thedoggo);
                    }

                    Label txtdoggo = new Label();
                    txtdoggo.Content = "ID: " + did + "\nBreed: " + breed + "\nGender: " + gender + "\nAge: " + age + "\nDoB: "
                        + bday + "\nPrice: " + price + " Php\nBreeder: " + br + "\nStatus: " + stat;

                    sp.Children.Add(txtdoggo);

                    pets.Items.Add(sp);

                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void so_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            Window5 w5 = new Window5();
            w5.Show();
        }

        private void vtrans_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.Show();

            if (position.Content.ToString().Equals("Worker"))
            {
                w2.add.Visibility = Visibility.Hidden;
            }
        }

        private void vcus_Click(object sender, RoutedEventArgs e)
        {
            Window3 w3 = new Window3();
            w3.Show();

            if(position.Content.ToString().Equals("Worker"))
            {
                w3.add.Visibility = Visibility.Hidden;
            }
        }

        private void vbd_Click(object sender, RoutedEventArgs e)
        {
            Window4 w4 = new Window4();
            w4.Show();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            Window6 w6 = new Window6();
            w6.Show();
        }

        private void age_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pets.Items.Clear();
            string script = "";

            if (age.SelectedIndex == 0)
            {
                script = "select * from [Employee].vDogsAvailable where Age <= 4";
            }
            else if (age.SelectedIndex == 1)
            {
                script = "select * from [Employee].vDogsAvailable where Age > 4 and Age < 12";
            }
            else if (age.SelectedIndex == 2)
            {
                script = "select * from [Employee].vDogsAvailable where Age >= 12";
            }

            fill(script);
        }

        private void breed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            select();
        }

        private void gender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            select();
        }

        private void price_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pets.Items.Clear();
            string script = "";

            if (price.SelectedIndex == 0)
            {
                script = "select * from [Employee].vDogsAvailable where Price < 25000";
            }
            else if (price.SelectedIndex == 1)
            {
                script = "select * from [Employee].vDogsAvailable where Price >= 25000 and Price <= 50000";
            }
            else if (price.SelectedIndex == 2)
            {
                script = "select * from [Employee].vDogsAvailable where Price > 50000";
            }

            fill(script);
        }

        private void select()
        {
            pets.Items.Clear();
            string script = "";
            if (breed.SelectedIndex == -1 && gender.SelectedIndex > -1)
            {
                script = "select * from [Employee].vDogsAvailable where Gender = '" + gender.SelectedItem.ToString() + "'";
            }
            else if(gender.SelectedIndex == -1 && breed.SelectedIndex > -1)
            {
                script = "select * from [Employee].vDogsAvailable where Breed = '" + breed.SelectedItem.ToString() + "'";
            }
            else if(breed.SelectedIndex > -1 && gender.SelectedIndex > -1)
            {
                script = "select * from [Employee].vDogsAvailable where Breed = '" + breed.SelectedItem.ToString()
                    + "' and Gender = '" + gender.SelectedItem.ToString() + "'";
            }
            else
            {
                script = "select * from [Employee].vDogsAvailable";
            }

            fill(script);
        }

        private void reload_Click(object sender, RoutedEventArgs e)
        {
            pets.Items.Clear();
            fill("select * from [Employee].vDogsAvailable");
        }
    }
}
