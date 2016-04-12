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

namespace GamaAfterTheHolyGrail.CooperacionModule.Views
{
    /// <summary>
    /// Interaction logic for SearchBoxView.xaml
    /// </summary>
    public partial class SearchBoxView : UserControl
    {
        public SearchBoxView()
        {
            InitializeComponent();
        }

        private void RichLookupBox_Search(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Oh dear...", "Yes", MessageBoxButton.YesNoCancel, MessageBoxImage.Hand,
                MessageBoxResult.OK, MessageBoxOptions.RightAlign);
        }
    }
}
