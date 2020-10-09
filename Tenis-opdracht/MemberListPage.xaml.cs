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
using Tenis_opdracht.Data.Model;

namespace Tenis_opdracht
{
    /// <summary>
    /// Interaction logic for MemberListPage.xaml
    /// </summary>
    public partial class MemberListPage : Page
    {
        public MemberListPage()
        {
            InitializeComponent();
        }

        private async Task loadData()
        {
            var list = await ApiHelper.apiCaller.GetAll<Member>("includes=Gender");
            this.MemberList.ItemsSource = from m in list select new { m.Id, m.FullName, Gender = m.Gender.Name, m.FullAddress };
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await loadData();
        }

        private async void refresh_Click(object sender, RoutedEventArgs e)
        {
            await loadData();
        }
    }
}
