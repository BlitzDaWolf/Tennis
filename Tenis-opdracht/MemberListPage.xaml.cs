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
using Tenis_opdracht.Api;

namespace Tenis_opdracht
{
    /// <summary>
    /// Interaction logic for MemberListPage.xaml
    /// </summary>
    public partial class MemberListPage : Page, IDisposable
    {
        public MemberListPage()
        {
            InitializeComponent();
            // MemberList.MouseDoubleClick + MemberList_SelectionChanged;
        }

        public void Dispose()
        {

        }

        public async Task loadData()
        {
            var l = await MemberAPI.GetMembers();
            MemberList.ItemsSource = from member in l
                                     where member.FirstName.ToLower().Contains(filter.Text.ToLower()) || member.LastName.ToLower().Contains(filter.Text.ToLower())
                                     select new { Gender = member.Gender.Name, member.FirstName, member.LastName };
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await loadData();
        }

        private async void refresh_Click(object sender, RoutedEventArgs e)
        {
            await loadData();
        }

        private async void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            await loadData();
        }

        private void MemberList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var v = MemberList.SelectedCells[0].Item;
        }
    }
}
