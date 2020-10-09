using System.Collections.Generic;
using System.Windows;
using Tenis_opdracht.Data;
using Tenis_opdracht.Api;
using Tenis_opdracht.View;
using Tenis_opdracht.Data.Model;

namespace Tenis_opdracht
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Gender> members;

        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient(new ApiCaller());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MemberView mv = new MemberView();
            mv.Show();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await ApiHelper.apiCaller.GetAll<Member>("a=5", "t=5");
        }
    }
}
