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
    /// Lógica interna para InfoClientes.xaml
    /// </summary>
    public partial class InfoClientes : Window
    {
        public InfoClientes()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            // 1. Instancia o modelo e captura os dados da tela
            var cliente = new Clientes
            {
                Nome = txtNomeCliente.Text.Trim(),
                Cpf = txtCpf.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Telefone = txtTelefone.Text.Trim(),
                Endereco = txtEndereco.Text.Trim()
            };

            // 2. VALIDAÇÕES CONSOLIDADAS
            if (string.IsNullOrWhiteSpace(cliente.Nome))
            {
                ExibirAviso("Nome do Cliente é obrigatório!", txtNomeCliente);
                return;
            }
            if (string.IsNullOrWhiteSpace(cliente.Cpf) || cliente.Cpf.Length < 11)
            {
                ExibirAviso("CPF inválido ou incompleto.", txtCpf);
                return;
            }
            if (string.IsNullOrWhiteSpace(cliente.Email) || !cliente.Email.Contains("@"))
            {
                ExibirAviso("Insira um e-mail válido.", txtEmail);
                return;
            }
            if (string.IsNullOrWhiteSpace(cliente.Endereco))
            {
                ExibirAviso("Endereço é obrigatório!", txtEndereco);
                return;
            }

            if (string.IsNullOrWhiteSpace(cliente.Telefone))
            {
                ExibirAviso("O telefone é obrigatório!", txtTelefone);
                return;
            }

            // [AQUI ENTRARÁ O SEU BANCO DE DADOS NO FUTURO]
            // Exemplo: _database.Salvar(cliente);

           // 3. MENSAGEM DE SUCESSO
           string mensagem = $"Cliente cadastrado com sucesso!\n\n" +
                              $"Dono: {cliente.Nome}\nCPF: {cliente.Cpf}\nE-mail: {cliente.Email}\nTelefone: {cliente.Telefone}" ;
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
            txtNomeCliente.Text = txtCpf.Text = txtEmail.Text = txtTelefone.Text = txtEndereco.Text = string.Empty;
            txtNomeCliente.Focus();
        }
           
    }
}
