using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FailedRequestViewer.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FailedRequestViewer.Controllers
{
    public class RequestController : Controller
    {
        readonly IConfiguration _configuration;
        public RequestController(IConfiguration configuration )
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var model = new FailedRequestsModel(_configuration);
            
            var items = model.GetFailedRequestsWithInOFS();
            return View(items);
        }

      public IActionResult Download(string id)
      {
          var model = new FailedRequestsModel(_configuration);
          return File(model.GetFile(id + ".xml"),"application/octet-stream");

          //byte[] bytes = Convert.FromBase64String(data);
          //return File(bytes,"application/octet-stream");
      }
    }
}
