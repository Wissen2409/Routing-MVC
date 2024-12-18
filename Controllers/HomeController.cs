using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Routing_MVC.Models;

namespace Routing_MVC.Controllers;

// Controller seviyede routing vermek, o controller içerisindeki tüm actionlara istek yapılırken
// controllera verilen routing adının da kullanılması gerekmektedir

// Örnek :  //http://localhost:5249/wissen/[çağırılacak action]
[Route("wissen")]


// Routing esnasındai controlleri yazmamak isterseniz Route[""] şekinde bırakabilirsiniz, bu durumda adres çubuğunda kontroller adı yazmak zorunda kalmazsınız!!
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
    public IActionResult Privacy(string id)
    {
        return Content(id+" değeri gönderildi");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    // article action'una routing verdik, artık bu action'a gelmek için 

    // wissen/blog adresini yazmamız gerekmektedir!

    // aynı zamanda bu action'un aldığı 3 adet parametreyide, routing olarak ekledik!!

    // Örnek kullanım : wissen/blog/2024/12/orhan-pamuk-kar
    [Route("blog/{year}/{month}/{title}")]
    public IActionResult Article(int year,int month,string title){

        return Content($"Makale : {year}/{month}/{title}");

    }
    

    // Aşağıda vermiş olduğumuz routing productname alanı routing esnasında boş gönderilirse, ball isimli default değeri alması sağlanacaktır
    // eğer değer gönderilirse, default değer ezilir ve gönderilen değer yazılır!!
    [Route("ProductDetail/{productname=Ball}")]
    public IActionResult ProductDetail(string productname){
        return Content($"{productname}");
    }

    // Routing esnasında gönderilen parametreye tip şartı koyabilirsiniz
    // int tipinde bir kısıt koymak demek, parametre olarak yanlızca, tam sayı tipleri gelebilir demektir.!!


    // decimal tipi kısıtı koyduğumuzda, hem tam sayı hedme ondalık sayı alabildiğini gördük!!
    [Route("Non3D/{bankname:decimal}")]
    public IActionResult Pay(decimal bankname){
        return Content($"{bankname}");
    }

    // bu routing ile, gönderilen parametreye karakter sınırı koyabiliriz.1!!!
    [Route("files/{filename:minlength(5)}")]
    public IActionResult File(string filename){
        return Content($"{filename}");
    }
}
