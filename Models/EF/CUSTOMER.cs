namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUSTOMER")]
    public partial class CUSTOMER
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string fullname { get; set; }

        [Required]
        [StringLength(100)]
        public string address { get; set; }

        [Required]
        [StringLength(20)]
        public string phoneNumber { get; set; }
    }
}
