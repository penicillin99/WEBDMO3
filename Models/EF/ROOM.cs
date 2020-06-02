namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROOM")]
    public partial class ROOM
    {
        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string title { get; set; }

        [Required]
        [StringLength(100)]
        public string address { get; set; }

        public int idRoom { get; set; }

        public int price { get; set; }

        public bool funcion_1 { get; set; }

        public bool funcion_2 { get; set; }

        [Required]
        public string content { get; set; }

        public int personMax { get; set; }

        [Required]
        [StringLength(10)]
        public string acreage { get; set; }

        public bool allowPet { get; set; }

        public int idEmployer { get; set; }

        public bool status { get; set; }

        [Column(TypeName = "date")]
        public DateTime createdate { get; set; }

        [StringLength(50)]
        public string cratedBy { get; set; }

        public virtual EMPLOYER EMPLOYER { get; set; }

        public virtual TYPEROOM TYPEROOM { get; set; }
    }
}
