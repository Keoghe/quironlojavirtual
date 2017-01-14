using System;

namespace Quiron.LojaVirtual.Web.Models
{
    //Class que faz o controle da paginação
    public class Paginacao
    {
        //Itens total por pagina
        public int ItensTotal { get; set; }

        public int ItensPorPagina { get; set; }

        public int PaginaAtual { get; set; }

        public int TotalPagina {
            get
            {
                return (int)Math.Ceiling((Decimal) ItensTotal / ItensPorPagina);
            }
        }

    }
}