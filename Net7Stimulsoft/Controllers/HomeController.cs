using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Net7Stimulsoft.Models;
using Newtonsoft.Json;
using Stimulsoft.Base;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;


namespace Net7Stimulsoft.Controllers
{

    using System.Net.Http;
    using System.Threading.Tasks;

    public class HttpClientWrapper : IDisposable
    {
        private readonly HttpClient _client;

        public HttpClientWrapper()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetStringAsync(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }



    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _env;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
            string path = Path.Combine(_env.WebRootPath, "Reports\\license\\license.key");
            StiLicense.LoadFromFile(path);
        }






        public IActionResult Index()
        {
            HttpClientWrapper gg = new HttpClientWrapper();
            var jsonString = gg.GetStringAsync("http://localhost:5146/api/GetListOstan").Result;
            var people = JsonConvert.DeserializeObject<List<Ostan>>(jsonString).Select(v => new SelectListItem()
            {
                Text = v.FullName,
                Value = v.Id
            }).ToList();
            return View(people);
        }


        [HttpPost]
        public PartialViewResult Search(string name, string tell, string ostan)
        {
            TempData["name"] = name;
            TempData["tell"] = tell;
            TempData["ostan"] = ostan;

            return PartialView("PrintPage");
        }




        public IActionResult PrintPage()
        {
            return View();
        }
        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
        public IActionResult ExportReport()
        {
            return StiNetCoreViewer.ExportReportResult(this);
        }
        public IActionResult Print()
        {
            var name = TempData["name"] as string;
            var tell = TempData["tell"] as string;
            var ostan = TempData["ostan"] as string;

            HttpClientWrapper gg = new HttpClientWrapper();
            var jsonString = gg.GetStringAsync("http://localhost:5146/api/GetListPerson").Result;
            var people = JsonConvert.DeserializeObject<List<Person>>(jsonString).ToList();

            if (ostan != "0")
            {
                people = people.Where(v => v.IdOstan == ostan).ToList();
            }
            if (string.IsNullOrWhiteSpace(tell) == false)
            {
                people = people.Where(v => v.Tell.Contains(tell)).ToList();
            }
            if (string.IsNullOrWhiteSpace(name) == false)
            {
                people = people.Where(v => v.FullName.Contains(name)).ToList();
            }


            StiReport report = new StiReport();
            report.Load(StiNetCoreHelper.MapPath(this, "wwwroot/Content/Reports/Report.mrt"));
            report.RegData("dt", people);
            return StiNetCoreViewer.GetReportResult(this, report);
        }
    }
}