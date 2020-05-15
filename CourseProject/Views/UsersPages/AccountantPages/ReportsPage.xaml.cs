﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CourseProject.ProjectFunctions;

namespace CourseProject.Views.UsersPages.AccountantPages
{
    /// <summary>
    /// Логика взаимодействия для ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page
    {
        public ReportsPage()
        {
            InitializeComponent();
        }

        private void RentalContractButton_Click(object sender, RoutedEventArgs e)
        {
            StatisticsGeneration.SaveToFile(StatisticsGeneration.GetRentalContract());
        }

        private void RentalAccountingButton_Click(object sender, RoutedEventArgs e)
        {
            StatisticsGeneration.SaveToFile(StatisticsGeneration.GetRentalAccounting());
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            StatisticsGeneration.SaveToFile(StatisticsGeneration.GetStatistic());
        }
    }
}
