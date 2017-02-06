using Quiron.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiron.LojaVirtual.V2.Models
{
    public class SubGrupoCategoriasViewModel
    {
        public SubGrupo SubGrupo { get; set; }

        public IEnumerable<Categoria> Categorias { get; set; }
    }
}