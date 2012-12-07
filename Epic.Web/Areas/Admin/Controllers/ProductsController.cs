using System.Web.Mvc;
using Epic.Data.Repositories;
using Epic.Domain;

namespace Epic.Web.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
    	private readonly ProductRepository _productRepository;

    	public ProductsController(ProductRepository productRepository)
    	{
    		_productRepository = productRepository;
    	}

    	public ViewResult Index()
    	{
    		var products = _productRepository.GetProducts();
			return View(products);
        }

		public ViewResult New()
		{
			return View(new Product());
		}

		[HttpPost]
		public ActionResult New(Product product)
		{
			if (!ModelState.IsValid)
				return View(product);

			_productRepository.Create(product);
			return RedirectToAction("index");
		}

		public ViewResult _List()
		{
			return View(_productRepository.GetProducts());
		}
    }
}
