using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Voltage_Stablizer.Entities;
using Voltage_Stablizer.Repositories.Repository;

namespace Voltage_Stablizer
{
    /// <summary>
    /// Interaction logic for SelectPage.xaml
    /// </summary>
    public partial class SelectPage : Page
    {
        public SelectPage()
        {
            InitializeComponent();
        }
        public void exitbtn_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(null);
        }

        Methods method = new Methods();

        public void Exit_click(object sender, RoutedEventArgs e)
        {
            method.Writer();

            Environment.Exit(0);
        }

        public void Selectbtn_Click(object sender, RoutedEventArgs e)
        {
            progressbar.IsIndeterminate = false;

            // reader for parameter

            double uwk = 0;
            double power = 0;
            double cosf = 0;
            double fullPower = 0;
            double a = 220;

            var data = method.Reader();

            if(string.IsNullOrEmpty(data) == false)
            {
                List<User> parameters = JsonConvert.DeserializeObject<List<User>>(data);
                for (int i = 0; i < parameters.Count; i++)
                {
                    power += Math.Round((parameters[i].Power * parameters[i].Quantity),3);
                }
                if (parameters.FirstOrDefault().Voltage == 45)
                    uwk = 0.15;
                if (parameters.FirstOrDefault().Voltage == 60)
                    uwk = 0.20;
                if (parameters.FirstOrDefault().Voltage == 75)
                    uwk = 0.25;
                if (parameters.FirstOrDefault().Voltage == 95)
                    uwk = 0.30;
                if (parameters.FirstOrDefault().Voltage == 110)
                    uwk = 0.35;
                if (parameters.FirstOrDefault().Voltage == 130)
                    uwk = 0.45;
                if (parameters.FirstOrDefault().Voltage == 150)
                    uwk = 0.50;
                if (parameters.FirstOrDefault().Voltage == 170)
                    uwk = 0.70;
                if (parameters.FirstOrDefault().Voltage >= 198)
                    uwk = 1;

                cosf = parameters.FirstOrDefault().cos;
                fullPower = Math.Round(((power / cosf) * uwk), 2);

                V.Content = parameters.FirstOrDefault().Voltage;
                cos.Content = parameters.FirstOrDefault().cos;
                S.Content = fullPower.ToString();
                fik.Content = uwk.ToString();
                I1.Content = (Math.Round((fullPower*1000) / parameters.FirstOrDefault().Voltage, 2)).ToString();
                I2.Content = (Math.Round((fullPower * 1000) / a, 2)).ToString();


                if (fullPower <= 5)
                    result.Text = "5 kVA quvvatli kuchlanish stabilizatori tanlandi"; 
                if (fullPower >= 5 & fullPower <= 7.5)
                    result.Text = "7.5 kVA quvvatli kuchlanish stabilizatori tanlandi"; 
                if (fullPower >= 7.5 & fullPower <= 10)
                    result.Text = "10 kVA quvvatli kuchlanish stabilizatori tanlandi";
                if (fullPower >= 10 & fullPower <= 15)
                    result.Text = "15 kVA quvvatli kuchlanish stabilizatori tanlandi"; 
                if (fullPower >= 10 & fullPower <= 12.5)
                    result.Text = "12.5 kVA quvvatli kuchlanish stabilizatori tanlandi"; 
                if (fullPower >= 15 & fullPower <= 20)
                    result.Text = "20 kVA quvvatli kuchlanish stabilizatori tanlandi"; 
            }
            else
                snackbar.MessageQueue.Enqueue("Dastlabki ma'lumotlar o'chirilgan."); 
        }
    }
}
