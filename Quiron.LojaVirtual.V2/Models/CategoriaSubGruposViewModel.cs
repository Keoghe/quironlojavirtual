using Quiron.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiron.LojaVirtual.V2.Models
{
    public class CategoriaSubGruposViewModel
    {
        public IEnumerable<SubGrupo> subGrupos { get; set; }

        public Categoria Categoria { get; set; }
    }
}