using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tenis_opdracht.View
{
    /// <summary>
    /// Interaction logic for MemberView.xaml
    /// </summary>
    public partial class MemberView : Window
    {
        public MemberView()
        {
            InitializeComponent();
            this.Content = new MemberListPage();
        }
    }
}
