using FastMapper;
using Quiron.LojaVirtual.Dominio.Dto;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Entidades.Vitrine;
using System.Collections.Generic;
using System.Linq;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{


    public class MenuRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Categoria> ObterCategorias()
        {
            return _context.Categorias.OrderBy(c => c.CategoriaDescricao);
        }

        //Obter algumas marcas
        public IEnumerable<MarcaVitrine> ObterMarcas()
        {
            return _context.MarcaVitrine.OrderBy(c => c.MarcaDescricao);
        }

        public IEnumerable<ClubesNacionais> ObterClubesNacionais()
        {
            return _context.ClubesNacionais.OrderBy(c => c.LinhaDescricao);
        }

        public IEnumerable<ClubesInternacionais> ObterClubesInternacionais()
        {
            return _context.ClubesInternacionais.OrderBy(c => c.LinhaDescricao);
        }

        public IEnumerable<Genero> ObterGeneros()
        {
            return _context.Generos.OrderBy(g => g.GeneroDescricao);
        }

        public SubGrupo SubGrupoTenis()
        {
            return _context.SubGrupos.FirstOrDefault(s => s.SubGrupoCodigo == "0084");
        }
        //obtendo as categorias pré definidas através da query na tabela categoria
        public IEnumerable<Categoria> ObterTenisCategoria()
        {
            var categorias = new[] { "0005", "0082", "0112", "0010", "0063" };
            return _context.Categorias.Where(c => categorias.Contains(c.CategoriaCodigo)).OrderBy(c => c.CategoriaDescricao);
        }

        #region[Menu Lateral Casual]

        /// <summary>
        ///Retorno a modalidade Casual
        /// </summary>
        /// <returns></returns>
        public Modalidade ModalidadeCasual()
        {
            const string CODIGOMODALIDADE = "0001";
            return _context.Modalidades.FirstOrDefault(m => m.ModalidadeCodigo == CODIGOMODALIDADE);
        }
        //UTILIZANDO DTO
        public IEnumerable<SubGrupoDto> ObterCasualSubGrupo()
        {
            var subGrupos = new[] {"0001", "0102", "0103", "0738", "0084", "0921" };
            var query = from s in _context.SubGrupos
                        .Where(s => subGrupos.Contains(s.SubGrupoCodigo))
                        .Select(s => new { s.SubGrupoCodigo, s.SubGrupoDescricao })
                        .Distinct()
                        .OrderBy(s => s.SubGrupoDescricao)
                        select new
                        {
                            s.SubGrupoCodigo,
                            s.SubGrupoDescricao
                        };

            return query.Project().To<SubGrupoDto>().ToList();
        }

        #endregion[Menu Lateral Casual]

        #region[Menu Lateral Suplementos]

        public Categoria Sumplemento()
        {
            var categoriaSuplemento = "0008";

            return _context.Categorias.FirstOrDefault(s => s.CategoriaCodigo == categoriaSuplemento);
        }

        public IEnumerable<SubGrupo> ObterSuplementos()
        {
            var subGrupos = new[]
            {
                "0162","0381","0557","0564","0565","1082","1083","1084","1085","0977"
            };

            return _context.SubGrupos
                .Where(s => subGrupos.Contains(s.SubGrupoCodigo) && s.GrupoCodigo == "0012") 
                .Distinct()                        
                .OrderBy(s => s.SubGrupoDescricao);
        }
        #endregion[Menu Lateral Suplementos]

    }
}
