namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDER")]
    public partial class ORDER
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public DateTime? CretedDate { get; set; }


        [StringLength(50)]
        public string ShipName { get; set; }

        [StringLength(50)]
        public string ShipMobile { get; set; }

        [StringLength(50)]
        public string ShipAddress { get; set; }
        [StringLength(150)]
        public string PaymentMethod { get; set; }
        [StringLength(150)]
        public string CustomerMessage { get; set; }

        [StringLength(50)]
        public string ShipEmail { get; set; }

        public bool Status { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
