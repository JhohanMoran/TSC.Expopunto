using Microsoft.AspNetCore.Mvc;

namespace TSC.Expopunto.Api.Controllers
{
    [ApiController]
    public class TipoDocumentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
