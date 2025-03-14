using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _DbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext kontekst)
        {
            _logger = logger;
            _DbContext = kontekst;
        }

        public IActionResult Index()
        {
            var model = _DbContext.Schroniska.ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ListaSchronisk()
        {
            /*List<Schronisko> schroniska = new List<Schronisko>();
            schroniska.Add(new Schronisko {Id=1, Miejscowosc="Wa³brzych", Nazwa="Andrzejówka", Ocena=10 });
            schroniska.Add(new Schronisko { Id = 2, Miejscowosc = "Rzeszów", Nazwa = "£yba", Ocena = 7 });
            schroniska.Add(new Schronisko { Id = 3, Miejscowosc = "Kraków", Nazwa = "Chata bogata", Ocena = 8 });

            var model = schroniska;*/
            var model = _DbContext.Schroniska.ToList();
            return View(model);
        }


        /*********************************************************************************************
         https://moodle.ezn.edu.pl/mod/page/view.php?id=876
         *********************************************************************************************/


        public IActionResult Szczegoly(int id)
        {
            //ViewBag.Identyfikator = id;
            var schronisko = _DbContext.Schroniska.Find(id);
            var oceny = _DbContext.OcenySchroniska.Where(o => o.IdSchroniska == id).ToList();
            var model = new OcenySchroniskaViewModel();
            model.schronisko = schronisko;
            model.ocenaSchroniska = oceny;
            return View(model);
        }

        //GET NoweSchronisko
        public IActionResult NoweSchronisko()
        {
            return View();
        }

        //POST NoweSchronisko
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult NoweSchronisko(Schronisko schronisko)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Schroniska.Add(schronisko);
                _DbContext.SaveChanges();
                return RedirectToAction("ListaSchronisk");
            }
            return View(schronisko);
        }

        //GET UsunSchronisko
        public async Task<IActionResult> UsunSchronisko(int id)
        {
            var schronisko = await _DbContext.Schroniska.FirstOrDefaultAsync(s => s.Id == id);
            return View(schronisko);
        }

        //POST UsunSchronisko
        [HttpPost, ActionName("UsunSchronisko")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var schronisko = _DbContext.Schroniska.Find(id);
            _DbContext.Schroniska.Remove(schronisko);
            _DbContext.SaveChanges();
            return RedirectToAction("ListaSchronisk");
        }

        //GET ZmienSchronisko
        public async Task<IActionResult> ZmienSchronisko(int id)
        {
            var schronisko = await _DbContext.Schroniska.FirstOrDefaultAsync(s => s.Id == id);
            return View(schronisko);
        }

        //POST ZmienSchronisko
        [HttpPost, ActionName("ZmienSchronisko")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Schronisko schronisko)
        {
            //var poprzednieSchronisko = _DbContext.Schroniska.Find(id);
            _DbContext.Schroniska.Update(schronisko);
            _DbContext.SaveChanges();
            return RedirectToAction("ListaSchronisk");
        }

        public IActionResult ListaSQL()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
