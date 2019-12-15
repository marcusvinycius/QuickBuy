using QuickBuy.Dominio.ObjetoDeValor;
using System.Collections;
using System.Collections.Generic;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public Datetime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public ICollection<ItemPedido> ItensPedido { get; set; }
        public Datetime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string EnderecoCompleto { get; set; }
        public string NumeroEndereco { get; set; }
        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

    }
}
