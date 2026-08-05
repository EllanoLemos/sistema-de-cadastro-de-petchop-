using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cadastro_PetChop_Versao4_Ellano
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

        private void btn_sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_clientes_Click(object sender, RoutedEventArgs e)
        {
           
            

            FramePrincipal.Visibility = Visibility.Visible;
            FramePrincipal.Navigate(new InfoCliente());


        }

        public void VoltarMenu()
        {

            // 1. Remove a página atual do componente visual
            FramePrincipal.Content = null;

            // 2. Limpa o histórico de forma segura (apenas se ele realmente existir)
            while (FramePrincipal.CanGoBack)
            {
                FramePrincipal.RemoveBackEntry();
            }

            // 3. Esconde o Frame para revelar o menu original da MainWindow de volta
            FramePrincipal.Visibility = Visibility.Collapsed;
        }
    }
}