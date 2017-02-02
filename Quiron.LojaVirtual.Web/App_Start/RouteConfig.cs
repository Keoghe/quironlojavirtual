using System.Web.Mvc;
using System.Web.Routing;

namespace Quiron.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Obrigatório para poder utilizar os atributos por rota
            routes.MapMvcAttributeRoutes();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //1 - Inicio
            routes.MapRoute(
                null,
                "",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                    categoria = (string)null,
                    pagina = 1
                }
            );

            //2
            routes.MapRoute(
                null,
                "Pagina{pagina}",
                 new
                 {
                     controller = "Vitrine",
                     action = "ListaProdutos",
                     categoria = (string)null
                 },
                new { pagina = @"\d+" }

            );

            //3
            routes.MapRoute(
                null,
                "{categoria}",
                new { Controller = "Vitrine", action = "ListaProdutos", pagina = 1}
            ) ;
            
            //4
            routes.MapRoute(
                null,
                "{categoria}/Pagina{pagina}",
                 new
                {
                    Controller = "Vitrine",
                    action = "ListaProdutos"
                },
                new { pagina = @"\d+" }                
                
            );

            //5
            //routes.MapRoute(
            //    "ObterImagem",
            //    "Vitrine/ObterImagem/{produtoID}",
            //     new
            //     {
            //         Controller = "Vitrine",
            //         action = "ObterImagem",
            //         produtoId = UrlParameter.Optional
            //     }
            //    //new { pagina = @"\d+" }

            //);

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
