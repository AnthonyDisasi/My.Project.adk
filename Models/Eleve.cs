using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My.Project.adk.Models
{
    public enum Sexe
    {
        Homme, Femme
    }

    public class Eleve
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public string ClasseID { get; set; }

        public string Nom { get; set; }
        public string Postnom { get; set; }

        public string Matricule { get; set; }


        [EnumDataType(typeof(Sexe))]
        public Sexe? Sexe { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateNaissaince { get; set; }

        public Classe Classe { get; set; }
    }
}
