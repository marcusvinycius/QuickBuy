using System;

namespace QuickBuy.Dominio.Entidades
{
    public class Produto : Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();
            if (String.IsNullOrEmpty(Nome))
                AdicionarCritica("Crítica - Nome deve estar preenchido");

            if (Preco == 0)
                AdicionarCritica("Crítica - Preço não pode ser zero");
        }
    }
}
