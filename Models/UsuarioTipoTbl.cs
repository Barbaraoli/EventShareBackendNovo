using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJETO.Models
{
    [Table("usuario_tipo_tbl")]
    public partial class UsuarioTipoTbl
    {
        public UsuarioTipoTbl()
        {
            UsuarioTbl = new HashSet<UsuarioTbl>();
        }

        [Key]
        [Column("tipo_id")]
        public int TipoId { get; set; }
        [Required]
        [Column("tipo_nome")]
        [StringLength(50)]
        public string TipoNome { get; set; }

        [InverseProperty("UsuarioTipo")]
        public virtual ICollection<UsuarioTbl> UsuarioTbl { get; set; }
    }
}
