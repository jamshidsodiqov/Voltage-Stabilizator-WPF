using MaterialDesignThemes.Wpf.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Converters;
using Voltage_Stablizer.Entities;
using Voltage_Stablizer.Repositories.Repository;

namespace Voltage_Stablizer
{
    /// <summary>
    /// Interaction logic for EnterParams.xaml
    /// </summary>
    /// 

    public partial class EnterParams : Page
    {
        public EnterParams()
        {
            InitializeComponent();
        }

        private void exitbtn_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(null);
        }

        Methods method = new Methods();

        public void CreateData_Click(object sender, RoutedEventArgs e)
        {
            bool done = false;
            Repository repository = new Repository();

            if (equipment.Text != "" & power.Text != "" & quantity.Text != "" & voltage.Text!= "" & cosf.Text != "")
            {
                double c = 0;
                repository.Create(new User
                {
                    Voltage = int.Parse(voltage.Text),
                    cos = double.Parse(cosf.Text),
                    Name = equipment.Text,
                    Power = double.Parse(power.Text),
                    Quantity = int.Parse(quantity.Text),
                    Create = DateTime.Now
                }) ;
                done = true;

                // display json file information

                var data = method.Reader();
                List<User> users = JsonConvert.DeserializeObject<List<User>>(data);

                datagrid.ItemsSource = null;

                if (users != null)
                {
                    datagrid.ItemsSource = users;
                }

                for (int i = 0; i < users.Count; i++)
                {
                    c += users[i].Power * users[i].Quantity;
                }
                full_power.Content = Math.Round(c,2).ToString();
            }
            else
                MessageBox.Show("Ma`lumotlarni to`liq kiriting!");
            
            if(done == true)
            {
                equipment.Text = "";
                power.Text = "";
                quantity.Text = "";
            }

        }

        public void Nextbtn_Click(object sender, RoutedEventArgs e)
        {
            EnterParamsFrame.Content = new SelectPage();
        }

        public void Newbtn_Click(object sender, RoutedEventArgs e)
        {
            voltage.Text = "";
            cosf.Text = "";
            equipment.Text = "";
            power.Text = "";
            quantity.Text = "";

            full_power.Content = "0";
            datagrid.ItemsSource = null;

            method.Writer();
        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            method.Writer();

            Environment.Exit(0);
        }
    }
}
