using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    //API Controller
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController  (IServiceManager serviceManager): ControllerBase
    {
        //end point : public non-static method

        [HttpGet] //Get : /api/products

        public async Task<IActionResult> GetAllProducts()
        {
            var result = await serviceManager.ProductService.GetAllProductAsync();
            if (result is null) return BadRequest(); //400
            return Ok(result); //200

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsById(int id) //Get : /api /product/12
        {
            var result = await serviceManager.ProductService.GetProductByIdAsync(id);
            if (result is null) return NotFound(); //400
            return Ok(result); //200

        }



    }
}
