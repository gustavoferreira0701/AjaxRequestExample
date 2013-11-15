using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AjaxExample
{
    public partial class Pagina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Para que a requisição ajax encontre o método é necessário 
        /// "decorá-lo" com o atributo webmethod, que o transforma em um webservice, 
        /// a partir daí e possível que seja feita a comunicação via ajax.
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="telefone"></param>
        /// <param name="endereco"></param>
        /// <param name="idade"></param>
        [WebMethod]
        public static string MetodoSimples(string nome, string telefone, string endereco, int idade)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                Pessoa p = new Pessoa { 
                    Nome = nome, 
                    Telefone = telefone, 
                    Endereco = endereco, 
                    Idade = idade 
                };

                /*Para o envio das informações transformo todas em string e depois uso o método JSON.parse 
                 * na página que vai receber as informações.
                */

                return js.Serialize(p);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }


    public class Pessoa
    {
        
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public int Idade { get; set; }
    }
}