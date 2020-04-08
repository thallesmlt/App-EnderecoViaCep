using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App1.Servico.Modelo;
using Newtonsoft.Json;

namespace App1.Servico
{
    class ViaCepServico
    {
        private static string EnderecoUrl = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string NovoEnderecoUrl = string.Format(EnderecoUrl, cep); // inclui o Cep no campo{0} 
            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoUrl); // Conteudo recebe o objeto json retornado pela pagina

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo); // O método converte o conteudo json para as variaveis da classe Endereço
           

            return end;
        }
    }
}
