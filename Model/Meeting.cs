using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Meeting : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FirstMeeting { get; set; }
        public int FrequencyTime { get; set; }
        public int PsycotherapistId { get; set; }
        [ForeignKey(nameof(PsycotherapistId))]
        public Psycotherapist Psycotherapist { get; set; }
    }
}
