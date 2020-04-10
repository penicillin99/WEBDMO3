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
        [StringLength(100)]
        public string address { get; set; }

        public int idRoom { get; set; }

        public int price { get; set; }

        public bool funcion_1 { get; set; }

        public bool funcion_2 { get; set; }

        [Required]
        public string content { get; set; }

        public int personMax { get; set; }

        public int acreage { get; set; }

        public bool allowPet { get; set; }

        public int idEmployer { get; set; }

        public int status { get; set; }

        public virtual EMPLOYER EMPLOYER { get; set; }

        public virtual TYPEROOM TYPEROOM { get; set; }
    }
}
