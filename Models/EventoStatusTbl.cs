using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJETO.Models
{
    [Table("evento_status_tbl")]
    public partial class EventoStatusTbl
    {
        public EventoStatusTbl()
        {
            EventoTbl = new HashSet<EventoTbl>();
        }

        [Key]
        [Column("evento_status_id")]
        public int EventoStatusId { get; set; }
        [Required]
        [Column("evento_status_nome")]
        [StringLength(50)]
        public string EventoStatusNome { get; set; }

        [InverseProperty("EventoStatus")]
        public virtual ICollection<EventoTbl> EventoTbl { get; set; }
    }
}
