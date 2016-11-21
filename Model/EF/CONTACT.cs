namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTACT")]
    public partial class CONTACT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Contact_Content", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Contact_Required", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string Content { get; set; }

        public bool Status { get; set; }
    }
}
