using Microsoft.AspNetCore.Mvc;
using NWEBFinal.Application.DTOs;

namespace NWEBFinal.WebApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly HttpClient _api;

        public StudentsController(IHttpClientFactory http)
            => _api = http.CreateClient("api");

        // GET: /Students
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _api.GetFromJsonAsync<List<StudentDto>>("api/students");
                return View(list);
            }
            catch (HttpRequestException)
            {
                ViewBag.Error = "Không thể kết nối tới dịch vụ. Vui lòng thử lại sau.";
                return View(new List<StudentDto>());
            }
        }

        // GET: /Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var res = await _api.GetAsync($"api/students/{id}");
            if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound();
            if (!res.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index), new { error = "Lỗi khi lấy chi tiết." });

            var dto = await res.Content.ReadFromJsonAsync<StudentDto>();
            return View(dto);
        }

        // GET: /Students/Create
        public IActionResult Create() => View(new StudentDto());

        // POST: /Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var res = await _api.PostAsJsonAsync("api/students", dto);
            if (res.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));
            ViewBag.Error = "Tạo mới thất bại. Vui lòng kiểm tra dữ liệu.";
            return View(dto);
        }

        // GET: /Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _api.GetFromJsonAsync<StudentDto>($"api/students/{id}");
            if (dto == null) return NotFound();
            return View(dto);
        }

        // POST: /Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var res = await _api.PutAsJsonAsync($"api/students/{id}", dto);
            if (res.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ViewBag.Error = "Cập nhật thất bại.";
            return View(dto);
        }

        // GET: /Students/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _api.GetFromJsonAsync<StudentDto>($"api/students/{id}");
            if (dto == null) return NotFound();
            return View(dto);
        }

        // POST: /Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var res = await _api.DeleteAsync($"api/students/{id}");
            if (res.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ViewBag.Error = "Xóa thất bại.";
            return RedirectToAction(nameof(Delete), new { id, error = ViewBag.Error });
        }
    }
}
