namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCT")]
    public partial class PRODUCT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long ID { get; set; }
        //[Display(Name = "Tên sản phẩm")]
        //[Required(ErrorMessage = "Mời bạn nhập Tên sản phẩm")]
        [Display(Name = "Name", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        [StringLength(250)]
        public string Name { get; set; }
        [StringLength(500)]
        [Display(Name = "Metatitle", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string Metatitle { get; set; }

        [StringLength(500)]
        [Display(Name = "Description", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string Description { get; set; }

        [StringLength(250)]
        [Display(Name = "Image", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string Image { get; set; }

        [StringLength(250)]
        [Display(Name = "MoreImages", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string MoreImages { get; set; }
        //[Display(Name = "Giá")]
        //[Required(ErrorMessage = "Mời bạn nhập giá")]
        [Display(Name = "Price", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public decimal? Price { get; set; }
        //[Display(Name = "Giá khuyến mãi")]
        [Display(Name = "PromotionPrice", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public decimal? PromotionPrice { get; set; }
        //[Required(ErrorMessage = "Mời bạn nhập số lượng")]

        //[Display(Name = "Số lượng")]
        [Display(Name = "Quantity", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public int Quantity { get; set; }

        //[Display(Name = "Miêu tả")]
        [Display(Name = "Detail", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string Detail { get; set; }

        public int Warranty { get; set; }

        [Display(Name = "CreatedDate", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "CreatedBy", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string CreatedBy { get; set; }

        [Display(Name = "ModifiedDate", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "ModifiedBy", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        [Display(Name = "MetaKeywords", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        [Display(Name = "MetaDescriptions", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string MetaDescriptions { get; set; }
        [Display(Name = "Status", ResourceType = typeof(StaticResources.Resources))]
        public bool Status { get; set; }
        [Display(Name = "TopHot", ResourceType = typeof(StaticResources.Resources))]
        public DateTime? TopHot { get; set; }
        [Display(Name = "ViewCount", ResourceType = typeof(StaticResources.Resources))]
        public int? ViewCount { get; set; }
        [Display(Name = "Like", ResourceType = typeof(StaticResources.Resources))]
        public int? Like { get; set; }      

        public virtual PRODUCTCATEGORY PRODUCTCATEGORY { set; get; }       

    }
}
