using api1.Data;
using api1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ProductController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById (int id)
        { 
            var product = context.Products.Find(id);
            if (product == null)
                return NotFound();
            else 
                return product;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                //return StatusCode(StatusCodes.Status400BadRequest); 
                return Content("Error: Product not found !");
            }  
            else
            {
                context.Products.Remove(product);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        [HttpPost]
        public IActionResult AddNewProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            product.Id = id;
            context.Products.Update(product);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
