using System.Windows;
using Tenis_opdracht.Api;
using System.Windows.Controls;
using System;
using Tenis_opdracht.DTO.Member;

namespace Tenis_opdracht
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient(new ApiCaller());
        }

        private void setPage(Page page)
        {
            test.Content = page;
            GC.Collect();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            setPage(new MemberListPage());
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MemberCreateDTO member = new MemberCreateDTO
            {
                GenderId = 2,
                FirstName = "Sam",
                LastName = "Wouters",
                BirthDate = DateTime.Now,
                Address = "Volhardingstraat",
                Number = "67",
                Zipcode = "2020",
                City = "Antwerpen",
                FederationNr= "SEW"
            };
            MemberAPI.CreateMember(member);
        }
    }
}
