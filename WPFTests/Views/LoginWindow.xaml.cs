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
using WPFTests.ViewModels;

namespace WPFTests.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginViewModel _viewModel = new LoginViewModel();
        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = _viewModel;
            if (_viewModel.CloseAction == null)
                _viewModel.CloseAction = new Action(this.Close);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.Login();
            if (_viewModel.IsLoggedIn)
            {
                MainWindow window = new MainWindow(_viewModel.login);
                window.Show();
                _viewModel.CloseAction();
            }
        }
    }
}
