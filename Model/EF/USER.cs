namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USER")]
    public partial class USER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Display(Name="Tài khoản:")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Mật khẩu:")]
        [StringLength(32)]
        public string Password { get; set; }

        [StringLength(20)]
        public string GroupID { get; set; }

        [Required(ErrorMessage = "Nhập tên")]
        [Display(Name = "Họ tên:")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nhập địa chỉ")]
        [Display(Name = "Địa Chỉ:")]
        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool Status { get; set; }
    }
}
