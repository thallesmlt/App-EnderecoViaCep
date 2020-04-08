using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1.Servico.Modelo;
using App1.Servico;

namespace App1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {

            // To Do - validações 
            string cep = CEP.Text.Trim(); // Trim remove os espaços iniciais e finais da string CEP digitada pelo usuário
            if (ValidarCEP(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep); // endereço do cep forneciodo pelo usuário
                    if(string.IsNullOrEmpty(end.cep))
                    {
                        DisplayAlert("Erro", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }
                    
                    if (String.IsNullOrEmpty(end.bairro))
                    {
                        RESULTADO.Text = string.Format("Endereço: Rua: {0} , UF:{1}", end.localidade, end.uf); // exibição do resultado
                    }
                    else
                    {
                        RESULTADO.Text = string.Format("Endereço: Rua: {0} , Bairro: {1} , UF:{2}", end.localidade, end.bairro, end.uf); // exibição do resultado
                    }
                }
                catch(Exception e)
                {
                    DisplayAlert("Erro Crítico", e.Message, "OK");
                }
               
                
            }
        }

        private bool ValidarCEP(string cep)
        {
            bool valido = true;
            if(cep.Length != 8)
            {
                DisplayAlert("Erro", "Cep inválido! O CEP deve conter 8 caracteres", "OK"); 
                valido = false;
                //Erro
            }
            int NovoCEP = 0;
            if(!int.TryParse(cep,out NovoCEP))
            {
                //ERRO
                DisplayAlert("Erro", "Cep inválido! O CEP deve ser composto apenas por números", "OK");
                valido = false;
            }
            return valido;
        }
    }
}
