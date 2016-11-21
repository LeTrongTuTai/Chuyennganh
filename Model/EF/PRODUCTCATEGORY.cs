namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCTCATEGORY")]
    public partial class PRODUCTCATEGORY
    {
        public long? ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [Key]
        [StringLength(250)]
        public string Metatitle { get; set; }

        public long? ParentID { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        public int? DisplayOrder { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        public bool? Status { get; set; }

        public virtual IEnumerable<PRODUCT> PRODUCTs { set; get; }
    }
}
