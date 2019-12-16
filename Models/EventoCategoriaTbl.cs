using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJETO.Models
{
    [Table("evento_categoria_tbl")]
    public partial class EventoCategoriaTbl
    {
        public EventoCategoriaTbl()
        {
            EventoTbl = new HashSet<EventoTbl>();
        }

        [Key]
        [Column("categoria_id")]
        public int CategoriaId { get; set; }
        [Required]
        [Column("categoria_nome")]
        [StringLength(50)]
        public string CategoriaNome { get; set; }

        [InverseProperty("EventoCategoria")]
        public virtual ICollection<EventoTbl> EventoTbl { get; set; }
    }
}
