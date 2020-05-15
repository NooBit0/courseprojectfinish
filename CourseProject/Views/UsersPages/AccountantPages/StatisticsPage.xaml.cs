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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CourseProject.ViewModels;

namespace CourseProject.Views.UsersPages.AccountantPages
{
    /// <summary>
    /// Логика взаимодействия для StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        public StatisticsPage()
        {
            InitializeComponent();
        }

        private void PriceListButton_Click(object sender, RoutedEventArgs e)
        {
            InfoTextBlock.Text = StatisticsGenerationViewModel.GetRentalPramses();
        }

        private void RentalAccountingButton_Click(object sender, RoutedEventArgs e)
        {
            InfoTextBlock.Text = StatisticsGenerationViewModel.GetRentalAccounting();
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            InfoTextBlock.Text = StatisticsGenerationViewModel.GetStatistic();
        }
    }
}
