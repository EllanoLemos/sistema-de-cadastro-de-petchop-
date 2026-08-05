using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cadastro_PetChop_Versao4_Ellano
{
    /// <summary>
    /// Interação lógica para InfoCliente.xam
    /// </summary>
    public partial class InfoCliente : Page
    {
        public InfoCliente()
        {
            InitializeComponent();

            this.DataContext = new ClienteViewModel();

            // Força o vínculo do clique diretamente no código para garantir que rode
            BtnVoltar.Click += BtnVoltar_Click;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as ClienteViewModel;
            if (viewModel == null || viewModel.ClienteAtual == null) return;

            // 1. Captura e limpa os dados da ViewModel (Incluindo o Email)
            string nomeCliente = viewModel.ClienteAtual.Nome?.Trim();
            string cpf = viewModel.ClienteAtual.Cpf?.Trim();
            string telefone = viewModel.ClienteAtual.Telefone?.Trim();
            string email = viewModel.ClienteAtual.Email?.Trim();
            string endereco = viewModel.ClienteAtual.Endereco?.Trim();// Adicionado aqui

            // 2. VALIDAÇÃO: Nome do Cliente (Obrigatório)
            if (string.IsNullOrEmpty(nomeCliente))
            {
                MessageBox.Show("Por favor, preencha o Nome do Cliente!", "Campo Obrigatório", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtNomeCliente.Focus();
                return;
            }

            // 3. VALIDAÇÃO: CPF (Obrigatório)
            if (string.IsNullOrEmpty(cpf))
            {
                MessageBox.Show("Por favor, preencha o CPF do Cliente!", "Campo Obrigatório", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtCpf.Focus();
                return;
            }

            if (cpf.Length < 11)
            {
                MessageBox.Show("O CPF digitado está incompleto. Digite os 11 números.", "Dados Inválidos", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtCpf.Focus();
                return;
            }

            // 4. VALIDAÇÃO: E-mail (Campo Específico Obrigatório)
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Por favor, preencha o E-mail do Cliente!", "Campo Obrigatório", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtEmail.Focus(); // ⚠️ Certifique-se de que o TextBox do Email tem o x:Name="txtEmail" no XAML
                return;
            }

            // Validação extra específica para E-mail (Verifica se possui @ e ponto)
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Por favor, insira um endereço de e-mail válido (exemplo@email.com).", "E-mail Inválido", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtEmail.Focus();
                return;
            }

            // 5. VALIDAÇÃO: Telefone (Opcional, valida formato se preenchido)
            if (!string.IsNullOrEmpty(telefone) && telefone.Length < 10)
            {
                MessageBox.Show("O telefone digitado parece estar incompleto.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtTelefone.Focus();
                return;
            }

            // 5. VALIDAÇÃO: Endereço Obrigatório e com estrutura válida (Rua + Número)

            if (string.IsNullOrWhiteSpace(endereco))
            {
                MessageBox.Show("Por favor, preencha o Endereço do Cliente!", "Campo Obrigatório", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtEndereco.Focus();
                return;
            }

            // Verifica se o usuário digitou menos de 10 caracteres (ex: escreveu apenas "Rua A")
            // E usa LINQ para verificar se existe pelo menos um número digitado no texto do endereço



            // 6. MENSAGEM DE SUCESSO (Com todos os dados)
            string mensagemSucesso = $"Cliente cadastrado com sucesso!\n\n" +
                                     $"Dono: {nomeCliente}\n" +
                                     $"CPF: {cpf}\n" +
                                     $"E-mail: {email}\n" +
                                     $"Telefone: {telefone}\n" +
                                     $"Endereço: {endereco}"; // Adicionado aqui

            MessageBox.Show(mensagemSucesso, "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);

            // 7. Limpa a tela
            LimparCamposMvvm(viewModel);

        }



        // Método auxiliar para limpar a tela (removido o txtNomePet.Clear())
        private void LimparCamposMvvm(ClienteViewModel viewModel)
        {
            // 1. Limpa os valores diretamente nos componentes visuais (TextBoxes)
            txtNomeCliente.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtEndereco.Text = string.Empty;

            // 2. Limpa os valores na memória da ViewModel também
            viewModel.ClienteAtual.Nome = string.Empty;
            viewModel.ClienteAtual.Cpf = string.Empty;
            viewModel.ClienteAtual.Email = string.Empty;
            viewModel.ClienteAtual.Telefone = string.Empty;
            viewModel.ClienteAtual.Endereco = string.Empty;

            // 3. Devolve o foco para o primeiro campo
            txtNomeCliente.Focus();

        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            // Acessa a Window principal onde esta Page está hospedada
           if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                // Chama o método auxiliar que você já fez para esconder o Frame e voltar ao Menu
                mainWindow.VoltarMenu();
            }
        }

        
    }
}
        

