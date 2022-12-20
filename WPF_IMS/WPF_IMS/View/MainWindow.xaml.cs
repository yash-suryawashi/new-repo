using System.Windows;

namespace WPF_IMS.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addNewBtn_Click(object sender, RoutedEventArgs e)
        {
            Add_dialog ad = new Add_dialog();
            ad.Show();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            Update_dialog upd = new Update_dialog();
            upd.Show();
        }
    }
}
