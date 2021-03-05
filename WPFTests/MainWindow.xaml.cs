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
using WPFTests.Models;
using WPFTests.ViewModels;

namespace WPFTests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel = new MainViewModel();
        public MainWindow(LoginModel login)
        {
            InitializeComponent();
            this.DataContext = _viewModel;
            _viewModel.Token = login.access_token;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.GetValues();
        }
    }
}
