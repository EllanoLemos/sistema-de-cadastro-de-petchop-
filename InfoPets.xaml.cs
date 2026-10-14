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
using System.Windows.Shapes;

namespace Cadastro_de_PetChop_Versao5_EllanoLemos
{
    /// <summary>
    /// Lógica interna para InfoPets.xaml
    /// </summary>
    public partial class InfoPets : Window
    {
        public InfoPets()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

            // 1. Identifica o sexo selecionado nos RadioButtons
            string sexoDoPet = "";
            if (rbMacho.IsChecked == true)
            {
                sexoDoPet = "Macho";
            }
            else if (rbFemea.IsChecked == true)
            {
                sexoDoPet = "Fêmea";
            }
            else
            {
                sexoDoPet = "Não Informado"; // Evita travar o código se nenhum estiver marcado
            }
            // 1. Instancia o modelo e captura os dados da tela
            var pet = new Pets
            {
                Nome = txtNomePet.Text.Trim(),
                Tipo = (cboTipoPet.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "",
                Raca = (cboRaca.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "",
                Idade = txtIdade.Text.Trim(),
                Cor = txtCorPet.Text.Trim(),
                Porte = (cboPorte.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "",
                Peso = txtPeso.Text.Trim(),
                Tamanho = (cboTamanhoPelo.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "",
                Sexo = sexoDoPet
            };

            // 2. VALIDAÇÕES CONSOLIDADAS
            if (string.IsNullOrWhiteSpace(pet.Nome))
            {
                ExibirAviso("Nome do Pet é obrigatório!", txtNomePet);
                return;
            }
            if (string.IsNullOrWhiteSpace(pet.Tipo))
            {
                ExibirAviso("O Tipo do Pet é obrigatório! Por favor, selecione uma opção.", cboTipoPet);
                return;
            }
            if (string.IsNullOrWhiteSpace(pet.Raca))
            {
                ExibirAviso("a Raça do Pet é obrigatória! Por favor, selecione uma opção.", cboRaca);
                return;
            }
            if (string.IsNullOrWhiteSpace(pet.Idade))
            {
                ExibirAviso("A Idade é obrigatória!", txtIdade);
                return;
            }

            if (string.IsNullOrWhiteSpace(pet.Cor))
            {
                ExibirAviso("A cor do Pet é obrigatória!", txtCorPet);
                return;
            }

            if (string.IsNullOrWhiteSpace(pet.Porte))
            {
                ExibirAviso("O Porte do pet é Obrigatório! Por Favor, selecione uma opção.", cboPorte);
                return;
            }

            if (string.IsNullOrWhiteSpace(pet.Peso))
            {
                ExibirAviso("O peso do Pet é obrigatório!", txtPeso);
                return;
            }

            if (string.IsNullOrWhiteSpace(pet.Tamanho))
            {
                ExibirAviso("O tamanho do Pelo do Pet é obrigatório! Por favor, selecione uma opção.", cboTamanhoPelo);
                return;
            }

            // Validação do Sexo (Inserida aqui!)
            if (sexoDoPet == "Não Informado")
            {
                MessageBox.Show("Por favor, selecione o sexo do pet (Macho ou Fêmea).", "Campo Obrigatório", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // [AQUI ENTRARÁ O SEU BANCO DE DADOS NO FUTURO]
            // Exemplo: _database.Salvar(cliente);

            // 3. MENSAGEM DE SUCESSO
            string mensagem = $"Cliente cadastrado com sucesso!\n\n" +
                               $"Pet: {pet.Nome}\nTipo do pet: {pet.Tipo}\nRaça: {pet.Raca}\nIdade do pet: {pet.Idade}\nCor do pet: {pet.Cor}\nPorte do pet: {pet.Porte}\n" +
                               $"Peso: {pet.Peso}\nTamanho do pelo: {pet.Tamanho}\nSexo: {pet.Sexo}";
            MessageBox.Show(mensagem, "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);

            // 4. LIMPEZA DE TELA
            LimparFormulario();
        }

        private void ExibirAviso(string mensagem, Control campoFoco)
        {
            MessageBox.Show(mensagem, "Campo Obrigatório", MessageBoxButton.OK, MessageBoxImage.Warning);
            campoFoco.Focus();
        }

        private void LimparFormulario()
        {
            // 1. Limpa todas as Caixas de Texto (TextBox) do Pet
            txtNomePet.Text = string.Empty;
            txtIdade.Text = string.Empty;
            txtCorPet.Text = string.Empty;
            txtPeso.Text = string.Empty;

            // 2. Reseta a seleção dos ComboBox para o estado "vazio"
            cboTipoPet.SelectedIndex = -1;
            cboRaca.SelectedIndex = -1;
            cboPorte.SelectedIndex = -1;
            cboTamanhoPelo.SelectedIndex = -1;

            // 3. Desmarca os RadioButtons do Sexo do Pet
            rbMacho.IsChecked = false;
            rbFemea.IsChecked = false;

            // 4. Devolve o foco visual para o primeiro campo (Nome do Pet)
            txtNomePet.Focus();
        }
    }
}
