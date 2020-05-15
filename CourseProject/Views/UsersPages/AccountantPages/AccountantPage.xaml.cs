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
using CourseProject.Views.UsersPages.AccountantPages;

namespace CourseProject.Views.UsersPages
{
    /// <summary>
    /// Логика взаимодействия для AccountantPage.xaml
    /// </summary>
    public partial class AccountantPage : Page
    {
        public AccountantPage(string login)
        {
            InitializeComponent();
            InfoTextBox.Text = UserViewModel.GetInfoForUser(login);
        }

        private void ReauthorizeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            AccountantMenuFrame.Navigate(new StatisticsPage());
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            AccountantMenuFrame.Navigate(new UsersPage());
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            AccountantMenuFrame.Navigate(new RentalConractPage());
        }

        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            AccountantMenuFrame.Navigate(new ReportsPage());
        }
    }
}
