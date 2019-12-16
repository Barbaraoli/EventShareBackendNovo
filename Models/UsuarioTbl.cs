using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJETO.Models
{
    [Table("usuario_tbl")]
    public partial class UsuarioTbl
    {
        public UsuarioTbl()
        {
            EventoTbl = new HashSet<EventoTbl>();
        }

        [Key]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        // [Required]
        [Column("usuario_nome")]
        [StringLength(50)]
        public string UsuarioNome { get; set; }
        [Required]
        [Column("usuario_email")]
        [StringLength(100)]
        public string UsuarioEmail { get; set; }
        [Column("usuario_comunidade")]
        [StringLength(100)]
        public string UsuarioComunidade { get; set; }
        [Required]
        [Column("usuario_senha")]
        [StringLength(255)]
        public string UsuarioSenha { get; set; }
        [Column("usuario_tipo_id")]
        public int UsuarioTipoId { get; set; }
        [Column("usuario_imagem")]
        [StringLength(250)]
        public string UsuarioImagem { get; set; }

        [ForeignKey(nameof(UsuarioTipoId))]
        [InverseProperty(nameof(UsuarioTipoTbl.UsuarioTbl))]
        public virtual UsuarioTipoTbl UsuarioTipo { get; set; }
        [InverseProperty("CriadorUsuario")]
        public virtual ICollection<EventoTbl> EventoTbl { get; set; }
    }
}
