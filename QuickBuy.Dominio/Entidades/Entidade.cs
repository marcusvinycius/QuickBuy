using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public abstract class Entidade
    {
        public List<string> _mensagensValidacao { get; set; }
        private List<string> mensagemValidacao 
        { 
            get;
            //get { return _mensagensValidacao ?? (_mensagensValidacao == new List<string>()); }
        }

        public abstract void Validade();
        protected bool EhValidado
        {
            get { return !mensagemValidacao.Any(); }
        }

        protected void LimparMensagemValidacao() {
            mensagemValidacao.Clear();
        }

        protected void AdicionarCritica(string mensagem)
        {
            mensagemValidacao.Add(mensagem);
        }
    }
}
