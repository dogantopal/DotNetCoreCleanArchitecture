using Application.Contracts;
using Application.Dtos;
using AutoMapper;
using Infrastructure.SearchParams;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IVisitService _visitService;
        private readonly IMapper _mapper;

        public HomeController(
            IAccountService accountService,
            IVisitService visitService,
            IMapper mapper)
        {
            _accountService = accountService;
            _visitService = visitService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetVisits(JqueryDatatableQueryModel model)
        {
            var data = await _visitService.GetAllAsync(new VisitSearchParams
            {
                Search = model.Search.Value,
                Take = Convert.ToInt32(model.Length),
                Skip = Convert.ToInt32(model.Start),
                UserId = UserId,
                Status = model.Status ?? VisitStatus.All
            });

            var returnModel = new JqueryDatatableResultModel<VisitListModel>
            {
                Data = _mapper.Map<List<VisitListModel>>(data.Data),
                Draw = model.Draw,
                RecordsFiltered = data.Data.Count,
                RecordsTotal = data.Count
            };

            return Json(returnModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VisitCreateModel model)
        {
            model.UserId = UserId;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var visitDTO = _mapper.Map<VisitDTO>(model);
            await _visitService.CreateAsync(visitDTO);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var model = await _visitService.GetAsync(id);

            return View(_mapper.Map<VisitUpdateModel>(model));
        }

        [HttpPost]
        public async Task<IActionResult> Update(VisitUpdateModel model)
        {
            model.UserId = UserId;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var visitDTO = _mapper.Map<VisitDTO>(model);
            await _visitService.UpdateAsync(visitDTO);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _visitService.DeleteAsync(id);

            return Json(true);
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _accountService.GetAccountsAsync();

            return Json(accounts);
        }
    }
}
