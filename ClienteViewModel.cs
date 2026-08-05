using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cadastro_PetChop_Versao4_Ellano
{
    public class ClienteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        private Cliente _clienteAtual;

        // Propriedade que a tela vai ler e escrever
        public Cliente ClienteAtual
        {
            get => _clienteAtual;
            set
            {
                _clienteAtual = value;
                OnPropertyChanged();
            }
        }

        // Comando que o botão Salvar vai acionar
        public ICommand SalvarCommand { get; }

        public ClienteViewModel()
        {
            ClienteAtual = new Cliente();
            SalvarCommand = new RelayCommand(SalvarCliente);
        }

        private void SalvarCliente()
        {
            // Validação simples
            if (string.IsNullOrWhiteSpace(ClienteAtual.Nome))
            {
                MessageBox.Show("O nome do cliente é obrigatório!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Teste temporário (substitua pelo banco de dados depois)
            MessageBox.Show($"Cliente {ClienteAtual.Nome} cadastrado com sucesso!", "Sucesso");

            // Limpa a tela para o próximo cadastro
            ClienteAtual = new Cliente();
        }

        // Implementação obrigatória para o WPF atualizar os campos na tela automaticamente

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }

    // Classe auxiliar para fazer o botão funcionar no padrão MVVM
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        public RelayCommand(Action execute) => _execute = execute;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => _execute();
        public event EventHandler CanExecuteChanged { add { } remove { } }



    }
}
