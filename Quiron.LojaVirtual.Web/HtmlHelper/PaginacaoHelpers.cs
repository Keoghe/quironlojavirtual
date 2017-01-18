using Quiron.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.HtmlHelpers
{
    //Classe responsável por montar a paginação na tela
    public static class PaginacaoHelpers
    {
        //Total de pagina igual a 3

        public static MvcHtmlString PageLinks(this HtmlHelper html, Paginacao paginacao, Func<int, string> paginaUrl)
        {

            StringBuilder resultado = new StringBuilder();

            for (int i = 1; i <= paginacao.TotalPagina; i++)
            {
                //Adicionando a Tag "a"
                TagBuilder tag = new TagBuilder("a");

                tag.MergeAttribute("href", paginaUrl(i));
                //passando a numeração da pagina
                tag.InnerHtml = i.ToString();

                if(i == paginacao.PaginaAtual)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                //Adicionando a linha após inclusão de parâmetros
                resultado.Append(tag);
            }

            return MvcHtmlString.Create(resultado.ToString());
        }
    }
}