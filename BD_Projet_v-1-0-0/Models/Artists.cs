
using System.ComponentModel.DataAnnotations;


namespace BD_Projet_v_1_0_0.Models
{
    public class Artists{

        [Key]
        [Display(Name = "Artist ID")]
        public Guid ID { get; set; }
        [Display(Name = "Stage Name")]
        public string Stage_Name { get; set; }

        [Display(Name = "Full Name")]
        public string Full_Name { get; set; }

        [Display(Name = "Date of Birth")]
        public string Date_of_Birth { get; set; }

        [Display(Name = "Original Group")]
        public string Original_group { get; set; }

        [Display(Name = "Debut")]
        public string Debut { get; set; }

        [Display(Name = "Company")]
        public string Company { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Height")]
        public int? Height { get; set; }

        [Display(Name = "Weight")]
        public int? Weight { get; set; }

        [Display(Name = "BirthPlace")]
        public string Birthplace { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Songs")]
        public IDictionary<string,string> song { get; set; }

        public override string ToString()
    {
        string tt="{";
        foreach (var i in song){
            tt+=i.Key+":"+i.Value+",";

        }
        tt+="}";
        return $"Artist: ID={ID},Stage_Name={Stage_Name},Full_Name={Full_Name},Date_of_Birth={Date_of_Birth},Original_group={Original_group},Debut={Debut},Company={Company},Country={Country},Height={Height},Weight={Weight},Birthplace={Birthplace},Gender={Gender},song={tt}";
    }

    }
}