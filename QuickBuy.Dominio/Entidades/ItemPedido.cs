using System;

namespace QuickBuy.Dominio.Entidades
{
    public class ItemPedido : Entidade
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        public int Quantidade { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();
            if (ProdutoId == 0)
                AdicionarCritica("Crítica - Não foi identificado qual a referência do produto");

            if (Quantidade == 0)
                AdicionarCritica("Crítica - Quantidade não foi informada");
        }
    }
}
