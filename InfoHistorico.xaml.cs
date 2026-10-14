using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Cadastro_de_PetChop_Versao5_EllanoLemos
{
    /// <summary>
    /// Lógica interna para InfoHistorico.xaml
    /// </summary>
    public partial class InfoHistorico : Window
    {
        private ObservableCollection<Atendimento> atendimentos =
     new ObservableCollection<Atendimento>();

        public InfoHistorico()
        {
            InitializeComponent();

            // Cria a lista de atendimentos
            atendimentos = new ObservableCollection<Atendimento>();

            // Liga a lista ao DataGrid
            dgHistorico.ItemsSource = atendimentos;

            // Carrega os dados iniciais
            CarregarDados();
        }

        private void CarregarDados()
        {
            atendimentos.Add(new Atendimento
            {
                Id = 1,
                Data = new DateTime(2026, 9, 30),
                Cliente = "João da Silva",
                Pet = "Rex",
                Tipo = "Serviço",
                Descricao = "Banho e Tosa",
                Observacao = "Pet apresentou comportamento tranquilo durante o atendimento."
            });

            atendimentos.Add(new Atendimento
            {
                Id = 2,
                Data = new DateTime(2026, 9, 15),
                Cliente = "João da Silva",
                Pet = "Rex",
                Tipo = "Agendamento",
                Descricao = "Consulta veterinária",
                Observacao = "Cliente solicitou atenção especial."
            });

            atendimentos.Add(new Atendimento
            {
                Id = 3,
                Data = new DateTime(2026, 9, 10),
                Cliente = "João da Silva",
                Pet = "Rex",
                Tipo = "Pet cadastrado",
                Descricao = "Cadastro do pet",
                Observacao = "Golden Retriever, 3 anos."
            });
        }

        private void btnAdicionarObservacao_Click(object sender, RoutedEventArgs e)
        {
            // Verifica se existe uma linha selecionada
            if (dgHistorico.SelectedItem is Atendimento atendimentoSelecionado)
            {
                // Verifica se foi digitada alguma observação
                if (string.IsNullOrWhiteSpace(txtObservacao.Text))
                {
                    MessageBox.Show(
                        "Digite uma observação.",
                        "Atenção",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);

                    return;
                }

                // Adiciona a observação ao atendimento selecionado
                atendimentoSelecionado.Observacao = txtObservacao.Text;

                // Atualiza o DataGrid
                dgHistorico.Items.Refresh();

                // Limpa o campo
                txtObservacao.Clear();

                MessageBox.Show(
                    "Observação adicionada com sucesso!",
                    "Sucesso",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(
                    "Selecione um atendimento no histórico.",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void dgHistorico_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Verifica se existe um atendimento selecionado
            if (dgHistorico.SelectedItem is Atendimento atendimentoSelecionado)
            {
                // Mostra a observação existente
                txtObservacao.Text = atendimentoSelecionado.Observacao;
            }
            else
            {
                txtObservacao.Clear();
            }
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            string pesquisa = txtPesquisa.Text.Trim().ToLower();

            // Se o campo estiver vazio, mostra todos os atendimentos
            if (string.IsNullOrWhiteSpace(pesquisa))
            {
                dgHistorico.ItemsSource = atendimentos;
                return;
            }

            // Filtra os atendimentos
            var resultado = atendimentos.Where(a =>
                a.Cliente.ToLower().Contains(pesquisa) ||
                a.Pet.ToLower().Contains(pesquisa) ||
                a.Tipo.ToLower().Contains(pesquisa) ||
                a.Descricao.ToLower().Contains(pesquisa) ||
                a.Observacao.ToLower().Contains(pesquisa)
            ).ToList();

            // Mostra o resultado no DataGrid
            dgHistorico.ItemsSource = resultado;

            // Verifica se encontrou algum resultado
            if (resultado.Count == 0)
            {
                MessageBox.Show(
                    "Nenhum atendimento encontrado.",
                    "Pesquisa",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
