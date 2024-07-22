using LearnCore.Models;
using LearnCore.Repository.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace LearnCore.Controllers
{
    // can't acsses except admin user
    [Authorize(Roles = ClassRoles.roleAdmin)]
    public class CategoryController : Controller
    {
        // using repository geniric

        //public CategoryController(IRepository<Category> categoryRepository)
        //{
        //    _categoryRepository = categoryRepository;
        //}
        //  private IRepository<Category> _categoryRepository;

        //public IActionResult Index()
        //{
        //    return View(_categoryRepository.FindAll());
        //}

        // public async Task<IActionResult> Index()
        // {
        //     var OneCategory = _categoryRepository.SelectOne(x => x.Name == "Computer");

        //     var allCategory = await _categoryRepository.FindAllAsync("Items");

        //     return View (allCategory);
        // }

        ////Get 

        // public IActionResult Create()
        // {
        //     return View();
        // }

        // // POST 

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public IActionResult Create(Category model)
        // {
        //     if (ModelState.IsValid) 
        //     {
        //         _categoryRepository.AddOne(model);
        //         TempData["SuccessData"] = "Category has been Added successfully";
        //         return RedirectToAction("Index");

        //     }
        //     else
        //     {
        //         return View(model);
        //     }
        // }

        // //GET
        // public IActionResult Edit(int? Id)
        // {
        //     if (Id == null)
        //     {
        //         return NotFound();
        //     }
        //    var category = _categoryRepository.FindById(Id.Value);
        //     if(category==null)
        //     {
        //         return NotFound();
        //     }
        //     return View(category);
        // }

        // // POST 

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public IActionResult Edit(Category model)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _categoryRepository.UpdateOne(model);
        //         TempData["SuccessData"] = "Category has been Edited successfully";

        //         return RedirectToAction("Index");
        //     }
        //     else
        //     {
        //         return View(model);
        //     }
        // }

        // //GET
        // public IActionResult Delete(int? Id)
        // {
        //     if(Id == null)
        //     {
        //         return NotFound();
        //     }
        //     var category = _categoryRepository.FindById(Id.Value);
        //     if(category==null)
        //     {
        //         return NotFound();
        //     }
        //     return View(category);  
        // }

        // // POST 

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public IActionResult Delete(Category model)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _categoryRepository.DeleteOne(model);
        //         TempData["SuccessData"] = "Category has been Deleted successfully";

        //         return RedirectToAction("Index");
        //     }
        //     else
        //     {
        //         return View(model);
        //     }
        // }

        //-------------------------------------------------------------------------------------------------------------------------------


        // using unit of work 

        public CategoryController(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
            
        }

        private readonly IUnitOfWork _unitOfWork;
      

        public async Task<IActionResult> Index()
        {
            var OneCategory = _unitOfWork.Categories.SelectOne(x => x.Name == "Computer");

            var allCategory = await _unitOfWork.Categories.FindAllAsync("Items");

            return View(allCategory);
        }

        //Get 
        
        public IActionResult Create()
        {
            return View();
        }

        // POST 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category model)
        {
            // Save image using database binary set data

            if (model.clientFile != null)
            {
                MemoryStream stream = new MemoryStream();
                model.clientFile.CopyTo(stream);
                model.DbImage = stream.ToArray();

            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Categories.AddOne(model);
                TempData["SuccessData"] = "Category has been Added successfully";
                return RedirectToAction("Index");

            }
            else
            {
                return View(model);
            }
        }

        //GET
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var category = _unitOfWork.Categories.FindById(Id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category model)
        {
            if (model.clientFile != null)
            {
                MemoryStream stream = new MemoryStream();
                model.clientFile.CopyTo(stream);
                model.DbImage = stream.ToArray();

            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Categories.UpdateOne(model);
                TempData["SuccessData"] = "Category has been Edited successfully";

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        //GET
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var category = _unitOfWork.Categories.FindById(Id.Value);
            if (category == null)
            {
                return NotFound();
            }
           
            return View(category);
        }

        // POST 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category model)
        {
            if (model.clientFile != null)
            {
                MemoryStream stream = new MemoryStream();
                model.clientFile.CopyTo(stream);
                model.DbImage = stream.ToArray();

            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Categories.DeleteOne(model);
                TempData["SuccessData"] = "Category has been Deleted successfully";

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        

    }
}
