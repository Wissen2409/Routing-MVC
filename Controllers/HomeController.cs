using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Routing_MVC.Models;

namespace Routing_MVC.Controllers;

// Controller seviyede routing vermek, o controller içerisindeki tüm actionlara istek yapılırken
// controllera verilen routing adının da kullanılması gerekmektedir

// Örnek :  //http://localhost:5249/wissen/[çağırılacak action]
[Route("Wissen")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // artık index sayfasını çağırırken, anasayfa diye çağırmak gerekmektedir.11
    [Route("anasayfa")]
    public IActionResult Index()
    {
        return View();
    }


    //http://localhost:5249/wissen/10

    // aşağıdaki şekilde bir routing verirseniz, adres çubuğuna, action adını yazmak yerine bir id değeri vermek zorunda kalacaksınızdır!!

    // bu şekildeki routingler genelde arama motorları tarafından daha iyi  bulunur!!
    [Route("{id}")]
    public IActionResult Privacy(int id)
    {
        return Content(id+" değeri gönderildi");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [Route("blog/{year}/{month}/{title}")]
    public IActionResult Article(int year,int month,string title){

        return Content($"Makale : {year}/{month}/{title}");

    }
}
