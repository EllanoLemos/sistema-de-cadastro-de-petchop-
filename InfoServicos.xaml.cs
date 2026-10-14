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
    /// Lógica interna para Servicos.xaml
    /// </summary>
    public partial class InfoServicos : Window
    {
        public InfoServicos()
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
            var servicos = new Servicos
            {
                Nome = (cboNomeServico.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "",
                Preco = (cboPreco.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "",
                Obs = txtObs.Text.Trim(),
            };

            // 2. VALIDAÇÕES CONSOLIDADAS
            if (string.IsNullOrWhiteSpace(servicos.Nome))
            {
                ExibirAviso("o tipo do serviço é obrigatório!", cboNomeServico);
                return;
            }
            if (string.IsNullOrWhiteSpace(servicos.Preco))
            {
                ExibirAviso("a escolha do preço e tipo é obrigatória!", cboPreco);
                return;
            }
            if (string.IsNullOrWhiteSpace(servicos.Obs))
            {
                ExibirAviso("A sua observação e obrigatória", txtObs);
                return;
            }
           
            // [AQUI ENTRARÁ O SEU BANCO DE DADOS NO FUTURO]
            // Exemplo: _database.Salvar(cliente);

            // 3. MENSAGEM DE SUCESSO
            string mensagem = $"Cliente cadastrado com sucesso!\n\n" +
                               $"Serviço: {servicos.Nome}\nTipo e Preço: {servicos.Preco}\nOBS: {servicos.Obs}";
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
            txtObs.Text = string.Empty;

            cboNomeServico.SelectedIndex = -1;
            cboPreco.SelectedIndex = -1;

            txtObs.Focus();
        }
    }
    
}
