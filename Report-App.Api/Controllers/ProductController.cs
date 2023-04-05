using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.Dtos.Request;
using ReportApp.BLL.ServicesContract;
using ReportApp.DAL.Entities;

namespace Report_App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;


        public ProductController(IProductServices productService, IMapper mapper)
        {
            _productServices = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Product>))]
        public IActionResult GetAllProducts()
        {
            var allProducts = _productServices.GetAllProducts();
            return Ok(allProducts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequest product)
        {
            if (ModelState.IsValid)
            {
                var newProduct = await _productServices.CreateProduct(product);
                if (newProduct != null)
                {
                    return Created("Get", newProduct);
                }
                return BadRequest();
            }
            return BadRequest();
        }



        [HttpGet]
        [Route("product/{Id}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> GetProduct(Guid userId)
        {
            /* if (!_productServices.ProductExist(Id))
                 return NotFound();*/

            var product = _productServices.GetProduct(userId);

            return Ok(product);
        }




        [HttpDelete]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Product>> DeleteProduct(Guid Id)
        {
            await _productServices.DeleteProduct(Id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
        {

            var respose = await _productServices.UpdateProduct(request);
            if (respose == null)
                return BadRequest("something went wrong");

            return Ok(respose);
        }


    }
}
