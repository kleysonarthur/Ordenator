using Microsoft.AspNetCore.Mvc;
using Ordenator.Models;
using Ordenator.Models.ViewModels;
using Ordenator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ordenator.Services.Exceptions;
using System.Diagnostics;


namespace Ordenator.Controllers {
    public class SellersController : Controller {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;
        private readonly RegService _regService;
        public SellersController(SellerService sellerService, DepartmentService departmentService, RegService regService) {
            _sellerService = sellerService;
            _departmentService = departmentService;
            _regService = regService;
        }
        public async Task<IActionResult> Index() {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }
        public async Task<IActionResult> Create() {
            var departments = await _departmentService.FindAllAsync();
            var profile = await _regService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments, Profile = profile };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller) {
            if(!ModelState.IsValid) {
                var departments = await _departmentService.FindAllAsync(); 
                var profile = await _regService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id) {
            if(id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _sellerService.FindByIdasync(id.Value);
            if(obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) {
            try {
                await _sellerService.RemoveAsyn(id);
                return RedirectToAction(nameof(Index)); ;
            }
            catch(IntergrityException e) {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        public async Task<IActionResult> Details(int? id) {
            if(id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _sellerService.FindByIdasync(id.Value);
            if(obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }
        public async Task<IActionResult> Edit(int? id) {
            if(id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _sellerService.FindByIdasync(id.Value);
            if(obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            List<Department> departments = await _departmentService.FindAllAsync();
            List<Profile> profile = await _regService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller) {
            if(!ModelState.IsValid) {
                var departments = await _departmentService.FindAllAsync();
                var profile = await _regService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            if(id != seller.Id) {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException e) {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        public IActionResult Error(string message) {
            var viewModel = new ErrorViewModel {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
