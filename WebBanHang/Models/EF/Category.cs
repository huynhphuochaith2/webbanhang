using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHang.Models.EF
{
    [Table("Category")]
    public class Category:CommonAbstract
    {
        public Category()
        {
            this.News = new HashSet<News>();//1 danh mục có thể có nhiều tin tức
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên danh mục không để trống")]
        [StringLength(150)]
        public String Title { get; set; }
        public string Alias { get; set; }
        //[StringLength(150)]
        //public string TypeCode { get; set; }
        public string Link { get; set; }
        public String Description { get; set; }
        [StringLength(150)]
        public String SeoTitle { get; set; }
        [StringLength(250)]
        public String SeoDescription { get; set; }
        [StringLength(150)]
        public String SeoKeywords { get; set; }
        public bool IsActive { get; set; }
        public int Position { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<Posts> Posts { get; set; }

    }
}