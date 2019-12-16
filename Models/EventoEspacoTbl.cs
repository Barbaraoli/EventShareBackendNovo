using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJETO.Models
{
    [Table("evento_espaco_tbl")]
    public partial class EventoEspacoTbl
    {
        public EventoEspacoTbl()
        {
            EventoTbl = new HashSet<EventoTbl>();
        }

        [Key]
        [Column("espaco_id")]
        public int EspacoId { get; set; }
        [Required]
        [Column("espaco_nome")]
        [StringLength(50)]
        public string EspacoNome { get; set; }

        [InverseProperty("EventoEspaco")]
        public virtual ICollection<EventoTbl> EventoTbl { get; set; }
    }
}
