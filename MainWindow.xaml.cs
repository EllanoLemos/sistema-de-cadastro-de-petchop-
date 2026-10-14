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

namespace Cadastro_de_PetChop_Versao5_EllanoLemos
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

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            // 1. Cria a instância da nova tela
            InfoClientes telaCadastro = new InfoClientes();

            telaCadastro.Owner = this;

            // 2. Abre a tela (ShowDialog bloqueia a principal até fechar a de cadastro)
            telaCadastro.ShowDialog();

            // Dica: Use telaCadastro.Show(); se quiser manter as duas abertas ao mesmo tempo
        }

        private void btnPets_Click(object sender, RoutedEventArgs e)
        {
            // 1. Cria a instância da nova tela
            InfoPets telaCadastro = new InfoPets();

            telaCadastro.Owner = this;

            // 2. Abre a tela (ShowDialog bloqueia a principal até fechar a de cadastro)
            telaCadastro.ShowDialog();

            // Dica: Use telaCadastro.Show(); se quiser manter as duas abertas ao mesmo tempo
        }

        private void btnAgendamento_Click(object sender, RoutedEventArgs e)
        {
            // 1. Cria a instância da nova tela
            InfoAgendamentos telaCadastro = new InfoAgendamentos();

            telaCadastro.Owner = this;

            // 2. Abre a tela (ShowDialog bloqueia a principal até fechar a de cadastro)
            telaCadastro.ShowDialog();

            // Dica: Use telaCadastro.Show(); se quiser manter as duas abertas ao mesmo tempo
        }

        private void btnServicos_Click(object sender, RoutedEventArgs e)
        {
            InfoServicos telaCadastro = new InfoServicos();

            telaCadastro.Owner = this;

            telaCadastro.ShowDialog();


        }

        private void btnHistorico_Click(object sender, RoutedEventArgs e)
        {
            InfoHistorico telaCadastro = new InfoHistorico();

            telaCadastro.Owner = this;

            telaCadastro.ShowDialog();
        }

        private void btnRelatorio_Click(object sender, RoutedEventArgs e)
        {
            InfoRelatorio telaCadastro = new InfoRelatorio();

            telaCadastro.Owner = this;

            telaCadastro.ShowDialog();
        }
    }
}