using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;
using System.Linq;
using Quiron.LojaVirtual.Web.Controllers;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Test
{
    [TestClass]
    public class CarrinhoControllerTestes
    {
        [TestMethod]
        public void AdicionarItemAoCarrinho()
        {
            //preparação (Arrange) e o estímulo (Act), das verificações(Asserts)

            Produto produto1 = new Produto()
            {
                ProdutoID = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto()
            {
                ProdutoID = 2,
                Nome = "Teste 2"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1,1);

            carrinho.AdicionarItem(produto2, 4);

            CarrinhoController controller = new CarrinhoController();

            //Act  
            controller.Adicionar(carrinho, 2,1, "");

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count(),2);

            Assert.AreEqual(carrinho.ItensCarrinho.ToArray()[0].Produto.ProdutoID, 1);

        }


        [TestMethod]
        public void Adiciono_Produto_No_Carrinho_Volto_Para_A_Categoria()
        {
            //preparação (Arrange) e o estímulo (Act), das verificações(Asserts)

            //Arrange
            Carrinho carrinho = new Carrinho();

            CarrinhoController controller = new CarrinhoController();

            //Act
            RedirectToRouteResult result = controller.Adicionar(carrinho, 2,1, "minhaUrl");

            Assert.AreEqual(result.RouteValues["action"], "Index");

            Assert.AreEqual(result.RouteValues["returnUrl"], "minhaUrl");
        }


        [TestMethod]
        public void Posso_Ver_O_Conteudo_Do_Carrinho()
        {
            Carrinho carrinho = new Carrinho();

            CarrinhoController controller = new CarrinhoController();

            CarrinhoViewModel resultado = (CarrinhoViewModel) controller.Index(carrinho,"minhaUrl").ViewData.Model;

            //Assert
            Assert.AreSame(resultado.Carrinho, carrinho);

            Assert.AreEqual(resultado.ReturnUrl, "minhaUrl");


        }

    }
}
