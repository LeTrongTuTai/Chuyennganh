using System;
using System.ComponentModel.DataAnnotations;


namespace DoanMVC.Models
{
    public class ProductViewModel
    {
        public int ID { set; get; }

        [Required(ErrorMessage = "Nhập tên sách")]
        [Display(Name = "Tên sách")]
        public string Name { set; get; }

        public string Alias { set; get; }

        [Display(Name = "Danh mục cha")]
        public int CategoryID { set; get; }

        [Display(Name = "Nhà sản xuất")]
        public int ProviderID { set; get; }

        [Required(ErrorMessage = "Nhập số lượng")]
        [Display(Name = "Số lượng")]
        public int? Quantity { set; get; }

        [Required(ErrorMessage = "Chọn hình ảnh")]
        [Display(Name = "Hình ảnh")]
        public string Image { set; get; }

        public string MoreImages { set; get; }

        [Required(ErrorMessage = "Nhập giá bán")]
        [Display(Name = "Giá bán")]
        public decimal Price { set; get; }

        [Display(Name = "Giá khuyến mãi")]
        public decimal? PromotionPrice { set; get; }

        [Display(Name = "Mô tả ngắn")]
        [MaxLength(500)]
        public string Description { set; get; }

        [Required(ErrorMessage = "Nhập chi tiết")]
        [Display(Name = "Chi tiết")]
        public string Content { set; get; }

        [Display(Name = "Hiển thị trang chủ")]
        public bool? HomeFlag { set; get; }

        [Display(Name = "Sản phẩm bán chạy")]
        public bool? SaleFlag { set; get; }

        [Display(Name = "Sản phẩm nỗi bật")]
        public bool? HotFlag { set; get; }

        public int? ViewCount { set; get; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { set; get; }

        [Display(Name = "Tạo bởi")]
        public string CreatedBy { set; get; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? UpdatedDate { set; get; }

        [Display(Name = "Cập nhật bởi")]
        public string UpdatedBy { set; get; }

        [Display(Name = "Từ khóa")]
        public string MetaKeyword { set; get; }

        [Display(Name = "Description")]
        public string MetaDescription { set; get; }

        [Display(Name = "Trạng thái")]
        public bool Status { set; get; }
    }
}