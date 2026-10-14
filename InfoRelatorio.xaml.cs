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
    /// Lógica interna para InfoRelatorio.xaml
    /// </summary>
    public partial class InfoRelatorio : Window


    {
        private readonly List<Relatorio> pets = new()
        {
            new Relatorio
            {
                NomePet = "Rex",
                Tutor = "João da Silva",
                Status = "Em atendimento",
                Progresso = 60
            },
            new Relatorio
            {
                NomePet = "Mel",
                Tutor = "Maria Oliveira",
                Status = "Pronto para liberação",
                Progresso = 100
            },
            new Relatorio
            {
                NomePet = "Thor",
                Tutor = "Carlos Santos",
                Status = "Aguardando atendimento",
                Progresso = 0
            }
        };

        public InfoRelatorio()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            var pet = pets.FirstOrDefault(p =>
                p.NomePet.Equals(txtPesquisa.Text.Trim(),
                    System.StringComparison.OrdinalIgnoreCase));

            if (pet == null)
            {
                MessageBox.Show("Pet não encontrado!");
                return;
            }

            txtNomePet.Text = "🐶 " + pet.NomePet;
            txtTutor.Text = "Tutor: " + pet.Tutor;
            txtStatus.Text = "● " + pet.Status;
            barraProgresso.Value = pet.Progresso;
            txtProgresso.Text = pet.Progresso + "% concluído";

            txtMensagemStatus.Text = pet.Status switch
            {
                "Em atendimento" => "🟡 O pet está em atendimento.",
                "Pronto para liberação" => "🟢 O pet está pronto para ser liberado!",
                "Aguardando atendimento" => "⏳ O pet está aguardando atendimento.",
                _ => pet.Status
            };
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

