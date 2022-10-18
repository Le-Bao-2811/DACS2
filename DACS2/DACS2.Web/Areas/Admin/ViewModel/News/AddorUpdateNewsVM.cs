using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace DACS2.Web.Areas.Admin.ViewModel.News
{
    public class AddorUpdateNewsVM
    {
        public int Id { get; set; }
        [DisplayName("Tiêu đề")]
        public string Title { get; set; }
        [DisplayName("Nội dung")]
        public string Content { get; set; }
        [DisplayName("Thể loại")]
        public int IdCategoryNew { get; set; }
        [DisplayName("Hình ảnh")]
        public IFormFile? Image { get; set; }
        public string? pathImg { get; set; }
    }
}
