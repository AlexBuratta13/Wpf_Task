using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Wpf_Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static int TrovaMultipli(int a)
        {
            int multipli = 0;
            for (int i = 0; i < 200000000; i++)
            {
                if (i % a == 0)
                {
                    multipli++;
                }
            }
            return multipli;
        }
            private void btn_esegui_Click(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(txt_inserisci.Text);
            Task<int> task1 = Task.Factory.StartNew(() => TrovaMultipli(a),
                CancellationToken.None,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default
                );
            lbl_Risultato.Content = $" Risultato: {task1.Result}";
        }
    }
}
