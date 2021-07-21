using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My.Project.adk.Models
{
    public class Ecole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }

        public string Nom { get; set; }
        public string Adresse { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreation { get; set; }

        public ICollection<Classe> Classes { get; set; }
    }
}
