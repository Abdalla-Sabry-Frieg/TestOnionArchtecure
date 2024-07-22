using LearnCore.Data;
using LearnCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace LearnCore.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ItemsController(ApplicationDbContext applicationDbContext , IHostingEnvironment hostingEnvironment)
        {
            _context = applicationDbContext;
            _hostingEnvironment = hostingEnvironment;

        }
        private readonly IHostingEnvironment _hostingEnvironment;
        public IActionResult Index()
        {
            var items = _context.Items.Include(x=>x.Category).ToList();
            return View(items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateCategoryList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item model)
        {
            var fillName = string.Empty;
            if(model.clientFile != null)
            {
                string myUpload = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                fillName =model.clientFile.FileName;
                string fullPath = Path.Combine(myUpload, fillName);
                model.clientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                model.imagePath=fillName;
            }

            // Add my owen validation 
            if (model.Name == "Ali")
            {
                ModelState.AddModelError("Name","This name is not allowed to use ");
                CreateCategoryList(model.CategoryId);
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _context.Items.Add(model);
                _context.SaveChanges();
                TempData["SuccessData"] = "Item has been Added successfully";
                return RedirectToAction(nameof(Index));
            }
            else

            return View(model);
        }

        public IActionResult Edit(int? Id)
        {
            var items = _context.Items.Find(Id);
            if(Id== null || Id==0)
            {
                return NotFound();
            }
            else
            CreateCategoryList(items.CategoryId);
            return View(items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item model)
        {
            var fillName = string.Empty;
            if (model.clientFile != null)
            {
                string myUpload = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                fillName = model.clientFile.FileName;
                string fullPath = Path.Combine(myUpload, fillName);
                model.clientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                model.imagePath = fillName;
            }
            if (ModelState.IsValid) 
            {
                _context.Items.Update(model);
                _context.SaveChanges();
                TempData["SuccessData"] = "Item has been Edited successfully";
                CreateCategoryList(model.CategoryId);
                return RedirectToAction(nameof(Index));
            }
            else return View(model);
        }

        public IActionResult Delete(int? Id)
        {
            var items = _context.Items.Find(Id);
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            else
             CreateCategoryList(items.CategoryId);
            return View(items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItems(int? Id)
        {

            var items = _context.Items.Find(Id);
            if (items == null)
            {
                return NotFound();
            }
            _context.Items.Remove(items);
            _context.SaveChanges();
            TempData["SuccessData"] = "Item has been Deleted successfully";
            return RedirectToAction(nameof(Index));
            
           
        }

        public void CreateCategoryList(int selectedId=1)
        {
            //List<Category> categories = new List<Category>()
            //{
            //    //new Category() { Id =0 , Name = "Select Category"},
            //    //new Category() { Id =1 , Name = "Computer"},
            //    //new Category() { Id =2 , Name = "Laptops"},
            //    //new Category() { Id =3 , Name = "Mobiles"},
            //};

            List <Category> categories = _context.Categories.ToList();
            SelectList listItems = new SelectList(categories , "Id" , "Name" , selectedId);
            
            ViewBag.Categories = listItems;
        }


    }
}
