namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTENT")]
    public partial class CONTENT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name = "Content_Name", ResourceType = typeof(StaticResources.Resources))]
        //[Required(ErrorMessageResourceName = "Content_Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string Name { get; set; }

        [StringLength(250)]
        [Display(Name = "Content_Metatitle", ResourceType = typeof(StaticResources.Resources))]
        //[Required(ErrorMessageResourceName = "Content_Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string Metatitle { get; set; }
        
        [Column(TypeName = "ntext")]
        [Display(Name = "Content_Description", ResourceType = typeof(StaticResources.Resources))]
        //[Required(ErrorMessageResourceName = "Content_Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string Description { get; set; }

        [StringLength(250)]
        [Display(Name = "Content_Image", ResourceType = typeof(StaticResources.Resources))]
        //[Required(ErrorMessageResourceName = "Content_Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string Image { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Content_Detail", ResourceType = typeof(StaticResources.Resources))]
        //[Required(ErrorMessageResourceName = "Content_Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string Detail { get; set; }
        [Display(Name = "Content_CreatedDate", ResourceType = typeof(StaticResources.Resources))]
        public DateTime? CreatedDate { get; set; }


        [StringLength(50)]
        [Display(Name = "Content_CreatedBy", ResourceType = typeof(StaticResources.Resources))]
        public string CreatedBy { get; set; }

        [Display(Name = "Content_ModifielDate", ResourceType = typeof(StaticResources.Resources))]
        //[Required(ErrorMessageResourceName = "Content_Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public DateTime? ModifielDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Content_ModifielBy", ResourceType = typeof(StaticResources.Resources))]
        //[Required(ErrorMessageResourceName = "Content_Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string ModifielBy { get; set; }
        
        [StringLength(250)]
        [Display(Name = "Content_MetaKeywords", ResourceType = typeof(StaticResources.Resources))]
        //[Required(ErrorMessageResourceName = "Content_Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]

        public string MetaKeywords { get; set; }

        [StringLength(250)]
        [Display(Name = "Content_MetaDescriptions", ResourceType = typeof(StaticResources.Resources))]
        //[Required(ErrorMessageResourceName = "Content_Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string MetaDescriptions { get; set; }

        [Display(Name = "Content_Status", ResourceType = typeof(StaticResources.Resources))]
        public bool Status { get; set; }
        [Display(Name = "Content_Language", ResourceType = typeof(StaticResources.Resources))]
        public string Language { get; set; }
    }
}
