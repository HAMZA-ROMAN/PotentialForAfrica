using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PotentialForAfrica.Models
{
    public class CandidatModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CandidatId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nom { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Prénom")]
        public string Prenom { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("E-Mail")]
        [EmailAddressAttribute]
        public string Mail { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Téléphone")]
        [PhoneAttribute]
        public string Telehone { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Niveau d’étude")]
        public string NiveauEtude { get; set; }
        [Required]
        [DisplayName("Nombre d’années d’expérience")]
        public int NbreAnneeExperience { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Dernier employeur")]
        public string DernierEmployeur { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("CV")]
        public string NomCV { get; set; }
    }
}
