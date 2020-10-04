using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;
using System.Windows.Data;
using System.Windows.Documents;
using Tenis_opdracht.Data;
using Tenis_opdracht.Api;

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
            ApiHelper.InitializeClient(new ApiCallerMock());
        }
    }
}
