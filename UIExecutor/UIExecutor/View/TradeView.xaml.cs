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
using UIExecutor.Model;

namespace UIExecutor.View
{
    /// <summary>
    /// Interaction logic for TradeView.xaml
    /// </summary>
    public partial class TradeView : Grid
    {
        public TradeView()
        {
            InitializeComponent();
        }


        private void CopyCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            TradeRecord tr = lvMessages.SelectedItem as TradeRecord;
            Clipboard.SetText(tr.TradeID);
        }

        private void CanCopyExecuteHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (lvMessages.Items.Count > 0) && (lvMessages.SelectedItem != null);
            e.Handled = true;
        }

        private void BtnExecute_Click(object sender, RoutedEventArgs e)
        {
            var tradeRecord = (TradeRecord)((Button)sender).DataContext;
            Clipboard.SetText(tradeRecord.TradeID);
        }
    }
}
