using Microsoft.AspNetCore.Mvc;
using web1.Models;

namespace web1.Controllers
{
    public class ProductController : Controller
    {
        [Route("/ProductList")]
        public IActionResult List()
        {
            //create new Product objects
            var product1 = new Product();
            product1.Name = "iphone";
            product1.Price = 999.99;
            product1.Image = "https://store.storeimages.cdn-apple.com/8756/as-images.apple.com/is/iphone-card-40-iphone15prohero-202309_FMT_WHH?wid=508&hei=472&fmt=p-jpg&qlt=95&.v=1693086369818";

            //declare new Product list and add items to list
            Product product2 = new Product { Name = "ipad", Price = 888.88, Image = "https://product.hstatic.net/1000259254/product/ipad_pro_12.9-inch__space_grey_0bb597a785d34e6e93d9a5f2e4f17aab.jpg" };

            List<Product> productList = new List<Product>()
            {
                product1, product2, product2, product2,
                new Product {Name = "macbook", Price = 2000, Image = "https://product.hstatic.net/1000259254/product/macbook_pro_m2_gray_-1_90ed3468b4f4462fb5a254bf8313795f_master.jpg"}
            };
     
            //render view with productList as data
            return View(productList);
        }
    }
}
