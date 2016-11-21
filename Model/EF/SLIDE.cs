namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SLIDE")]
    public partial class SLIDE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public DateTime? Created_Date { get; set; }

        [StringLength(50)]
        public string Created_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        [StringLength(50)]
        public string Modified_By { get; set; }

        public bool Status { get; set; }
        public int? TypeID { get; set; }
    }
}
