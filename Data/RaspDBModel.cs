using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YandexRasp {

    [Table("RaspDBTable")]
    public class RaspDBModel {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column]
        [StringLength(64)]
        public string From { get; set; }


        [Column]
        [StringLength(64)]
        public string To { get; set; }   

        [Column]
        [StringLength(16)]
        public string Date { get; set; }

        [Column]
        [StringLength(16)]
        public string FlightNo { get; set; } 
    }
}