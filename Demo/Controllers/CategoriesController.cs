using Demo.Data;
using Demo.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly UserContext _context;
        public CategoriesController(UserContext context)
        {
            _context = context;
        }

        public IActionResult Index(string keyword)
        {
            var query = _context.Categories.ToList();  //lấy tất cả dữ liệu từ bảng categories
            var categories = query.AsQueryable();       //chuyển đổi list categories sang kiểu AsQueryable

            if (!string.IsNullOrEmpty(keyword))   //Nếu có keyword , 
            {
                categories = categories.Where(x => x.Name.Contains(keyword));   //từ list categorie, lọc từng thằng list categories theo tên thỏa mãn với keyword
            }

            var result = categories.Select(x => new CategoryViewModel()  //lọc từng thằng trong list categories --> tạo mới CategoryViewModel 
            {
                Name = x.Name,
                Id = x.Id,
                Description = x.Description    //Chuyền dữ liệu từ list categories đã lọc sang CategoryViewModel
            }).ToList();  //trả về dạng list
            return View(result);
        }
    }
}
