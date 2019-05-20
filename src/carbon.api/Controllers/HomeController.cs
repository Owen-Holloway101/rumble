﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using carbon.api.Models;
using carbon.core.domain.model;
using carbon.core.dtos.model;
using carbon.core.dtos.ui;
using carbon.persistence.interfaces;

namespace carbon.api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        
        public HomeController(IReadOnlyRepository readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
        }
        
        public IActionResult Index()
        {

            var testObjs =  _readOnlyRepository.Table<Test, Guid>();

            var viewObj = new HomeDto();

            viewObj.NameValues = new List<TestDto>();
            
            foreach (var testObj in testObjs)
            {
                viewObj.NameValues.Add(new TestDto()
                {
                    Name = testObj.Name,
                    Value = testObj.Value
                });
            }
            
            return View(viewObj);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}