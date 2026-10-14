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
    /// Lógica interna para InfoAgendamentos.xaml
    /// </summary>
    public partial class InfoAgendamentos : Window
    {

        // Lista temporária de agendamentos.
        // Futuramente será substituída pelo banco de dados.
        private ObservableCollection<Agendamentos> agendamentos;
        public InfoAgendamentos()
        {
            
            InitializeComponent();

            // Cria a lista de agendamentos
            agendamentos = new ObservableCollection<Agendamentos>();

            // Liga a lista ao DataGrid
            dgStatus.ItemsSource = agendamentos;

            // Carrega os dados iniciais da tela
            CarregarDados();
        }

        private void CarregarDados()
        {
            // CLIENTES
            cboCliente.Items.Add("João da Silva");
            cboCliente.Items.Add("Maria Oliveira");
            cboCliente.Items.Add("Carlos Santos");
            cboCliente.Items.Add("Ana Souza");


            // PETS
            cboPet.Items.Add("Rex");
            cboPet.Items.Add("Mel");
            cboPet.Items.Add("Thor");
            cboPet.Items.Add("Luna");


            // SERVIÇOS
            cboServico.Items.Add("Banho");
            cboServico.Items.Add("Tosa");
            cboServico.Items.Add("Banho e Tosa");
            cboServico.Items.Add("Consulta Veterinária");
            cboServico.Items.Add("corte de pelo e unha");
            cboServico.Items.Add("Remedios e Vacinas");

            // HORÁRIOS
            cboHorario.Items.Add("08:00");
            cboHorario.Items.Add("08:30");
            cboHorario.Items.Add("09:00");
            cboHorario.Items.Add("09:30");
            cboHorario.Items.Add("10:00");
            cboHorario.Items.Add("10:30");
            cboHorario.Items.Add("11:00");
            cboHorario.Items.Add("14:00");
            cboHorario.Items.Add("14:30");
            cboHorario.Items.Add("15:00");
            cboHorario.Items.Add("15:30");
            cboHorario.Items.Add("16:00");
            cboHorario.Items.Add("16:30");
            cboHorario.Items.Add("17:00");


            // Define a data atual como padrão
            dpData.SelectedDate = DateTime.Today;
        }


        private void btnAgendar_Click(object sender, RoutedEventArgs e)
        {
            // Verifica se o cliente foi selecionado
            if (cboCliente.SelectedItem == null)
            {
                MessageBox.Show(
                    "Selecione o cliente.",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }


            // Verifica se o pet foi selecionado
            if (cboPet.SelectedItem == null)
            {
                MessageBox.Show(
                    "Selecione o pet.",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }


            // Verifica se o serviço foi selecionado
            if (cboServico.SelectedItem == null)
            {
                MessageBox.Show(
                    "Selecione o serviço.",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }


            // Verifica se a data foi selecionada
            if (dpData.SelectedDate == null)
            {
                MessageBox.Show(
                    "Selecione a data do agendamento.",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }


            // Verifica se o horário foi selecionado
            if (cboHorario.SelectedItem == null)
            {
                MessageBox.Show(
                    "Selecione o horário.",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }


            // Cria um novo agendamento
            Agendamentos novoAgendamento = new Agendamentos
            {
                Cliente = cboCliente.SelectedItem.ToString() ?? string.Empty,

                Pet = cboPet.SelectedItem.ToString() ?? string.Empty,

                Servico = cboServico.SelectedItem.ToString() ?? string.Empty,

                Data = dpData.SelectedDate.Value,

                Horario = cboHorario.SelectedItem.ToString() ?? string.Empty,

                Observacoes = txtObs.Text,

                Status = "Agendado"
            };


            // Adiciona o agendamento à lista
            agendamentos.Add(novoAgendamento);


            // Mostra mensagem de confirmação
            MessageBox.Show(
                "Agendamento realizado com sucesso!",
                "Pet Shop",
                MessageBoxButton.OK,
                MessageBoxImage.Information);


            // Limpa os campos
            LimparCampos();
        }


        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            LimparCampos();
        }


        private void LimparCampos()
        {
            // Limpa cliente
            cboCliente.SelectedIndex = -1;

            // Limpa pet
            cboPet.SelectedIndex = -1;

            // Limpa serviço
            cboServico.SelectedIndex = -1;

            // Limpa horário
            cboHorario.SelectedIndex = -1;

            // Volta para a data atual
            dpData.SelectedDate = DateTime.Today;

            // Limpa observações
            txtObs.Clear();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            // Verifica se algum agendamento foi selecionado
            if (dgStatus.SelectedItem == null)
            {
                MessageBox.Show(
                    "Selecione um agendamento para cancelar.",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            // Obtém o agendamento selecionado
            Agendamentos agendamentoSelecionado =
                (Agendamentos)dgStatus.SelectedItem;

            // Confirma o cancelamento
            MessageBoxResult resultado = MessageBox.Show(
                "Deseja realmente cancelar este agendamento?",
                "Cancelar Agendamento",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (resultado == MessageBoxResult.Yes)
            {
                // Altera o status
                agendamentoSelecionado.Status = "Cancelado";

                // Atualiza o DataGrid
                dgStatus.Items.Refresh();

                MessageBox.Show(
                    "Agendamento cancelado com sucesso!",
                    "Pet Shop",
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
