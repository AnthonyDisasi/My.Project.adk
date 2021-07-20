using My.Project.adk.Models.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace My.Project.adk.Models
{
    public class Classe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public string EcoleID { get; set; }

        public string Niveau { get; set; }
        public string AnneeScolaire { get; set; }
        [EnumDataType(typeof(Section))]
        public Section? Sexe { get; set; }

        public Ecole Ecole { get; set; }
        public ICollection<Eleve> Eleves { get; set; }
    }
}
