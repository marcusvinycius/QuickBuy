using System.Collections;
using System.Collections.Generic;

namespace QuickBuy.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public string Nome { get; set; }
        public string SobreNome { get; set; }

        /*Um usuario pode ter nenhum ou muitos pedidos
         *"virtual" permite o carregamento por demanda, ou seja, sempre que consultar o usuario o sistema carrega os pedidos viculados
         * Obs.: Tem que Habilitar a propriedade "UseLazyLoadingProxies" no Startup.cs
         *       Tem que colocar a propriedade "virtual" na classe Pedido também para o método Usuario
        */
        public virtual ICollection<Pedido> Pedidos { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();
            if (string.IsNullOrEmpty(Email))
                AdicionarCritica("Crítica - Email não foi informado");

            if (string.IsNullOrEmpty(Senha))
                AdicionarCritica("Crítica - Senha não foi informada");
        }
    }
}
