using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

using HollandMethods.StatisticClasses;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using WebApp.Classes;
using WebApp.Models;
using WebApp.XmlModels;

namespace WebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IWebHostEnvironment _hostingEnvironment;
		private readonly string _filesPath;

		public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment)
		{
			_logger = logger;
			_hostingEnvironment = hostingEnvironment;
			_filesPath = _hostingEnvironment.WebRootPath + @"\Files";
		}

		[HttpGet]
		public IActionResult Index()
		{
			InsertModel model = new InsertModel();
			return View(model);
		}

		[HttpPost]
		public IActionResult Index(InsertModel model)
		{
			return RedirectToAction("MethodStatistic", "Home", model);
		}

		public IActionResult MethodStatistic(InsertModel model)
		{
			var holland = new HollandStatistics(model.TaskCount, model.ProcCount, model.SpeciesCount, model.MinLoad, model.MaxLoad, model.RepeatsCount, model.MatrixCount, _filesPath);
			holland.FeelStatistics();

			List<HollandModel> result = new List<HollandModel>();

			foreach (var r in holland.Statistics)
			{
				result.Add(new HollandModel(r));
			}
			List<StatisticViewModel> statistic = new List<StatisticViewModel>();

			statistic = result.GroupBy(c => c.StartGenerationTypeString).Select(s => new StatisticViewModel
			{
				StartType = s.Key,
				HollandResult = s.Select(h => h).ToList()
			}).ToList();

			return View(statistic);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
