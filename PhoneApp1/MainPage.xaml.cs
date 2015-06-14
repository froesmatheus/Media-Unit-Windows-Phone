using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using Windows.UI.Popups;  
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.Resources;

namespace PhoneApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void botaoCalcular_Click(object sender, RoutedEventArgs e)
        {
            double notaUm = 0.0, notaDois = 0.0, media = 0.0;

            if (unidadeUm.Text != "")
            {
                try
                {
                    notaUm = Double.Parse(unidadeUm.Text);
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Digite uma nota válida");
                    unidadeUm.Text = "";
                    return;
                }
                
            }

            if (unidadeDois.Text != "")
            {
                try
                {
                    notaDois = Double.Parse(unidadeDois.Text);
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Digite uma nota válida");
                    unidadeDois.Text = "";
                    return;
                }
                
            }

            // Testar se os dois campos estão vazios
            if (unidadeUm.Text == "" && unidadeDois.Text == "")
            {

                MessageBox.Show("Informe pelo menos uma nota");
            }

            // Testar se as notas não são maior que 10 ou menor que 0
            else if (notaUm > 10.0 || notaUm < 0 || notaDois > 10.0 || notaDois < 0)
            {
                MessageBox.Show("O valor da nota deve estar entre 0 e 10");
            }

            // Testar se a primeira nota NÃO ESTÁ vazia e se a segunda ESTÁ
            else if (unidadeUm.Text != "" && unidadeDois.Text == "")
            {
                media = ((-1 * ((notaUm * 4) - 60)) / 6);
                unidadeDois.Text = String.Format("{0:0.0}", media);
            }

            // Testar se a primeira nota ESTÁ vazia e se a segunda NÃO ESTÁ
            else if (unidadeUm.Text == "" && unidadeDois.Text != "")
            {
                double provaFinal;
                media = ((-1 * ((notaDois * 6) - 60)) / 4);

                if (media > 10)
                {
                    string situacao = "Em prova final";
                    double notaNecessariaProvaFinal;
                    provaFinal = 40 - (notaDois * 6);
                    provaFinal = provaFinal / 4;
                    notaNecessariaProvaFinal = 12 - ((notaDois * 6) + (provaFinal * 4)) / 10;
                    MessageBox.Show("Nota mínima necessária na 1ª unidade para ter direito a prova final: " + String.Format("{0:0.0}", provaFinal) +
                        "\n\nSituação: " + situacao + "\n\nNota necessária na prova final: " + notaNecessariaProvaFinal);       
                }
                else
                {
                    unidadeUm.Text = String.Format("{0:0.0}", media);
                }
            }


            // Testar se as duas notas NÃO ESTÃO VAZIAS
            else if (unidadeUm.Text != "" && unidadeDois.Text != "")
            {
                media = (((notaUm * 4) + (notaDois * 6)) / 10);
                media = Convert.ToDouble(String.Format("{0:0.0}", media));
                string mensagem = "Sua média é: " + String.Format("{0:0.0}", media);
                string mensagemDois = "\n\nSituação: " + Verificar_Situacao(media);
                string mensagemTres = "";
                if (media < 6 && media >= 4)
                {
                   mensagemTres = "\n\nNota necessária para aprovação: " + String.Format("{0:0.0}", 12 - media);       
                }
                
                MessageBox.Show(mensagem + mensagemDois + mensagemTres); 
            }
        }

        private string Verificar_Situacao(double media)
        {
            if (media >= 6.0)
            {
                return "Aprovado";
            }

            else if (media >= 4)
            {
                return "Em prova final";
            }

            else
            {
                return "Reprovado";
            }
        }

        private void botaoLimpar_Click(object sender, RoutedEventArgs e)
        {
            unidadeUm.Text = "";
            unidadeDois.Text = "";
        }

        private void SobreButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }

        private void unidadeBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ApplicationBar.IsVisible = false;
        }

        private void unidadeBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ApplicationBar.IsVisible = true;
        }
    }
}