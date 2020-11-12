using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreDB.Models;
using StoreLib;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                productService.AddProduct(product);
                return CreatedAtAction("AddProduct", product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateProduct(Product product)
        {
            try
            {
                productService.UpdateProduct(product);
                return CreatedAtAction("UpdateProduct", product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteProduct(Product product)
        {
            try
            {
                productService.DeleteProduct(product);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok(productService.GetAllProducts());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/Product/name={productName}")]
        [Produces("application/json")]
        public IActionResult GetProductByName(string productName)
        {
            try
            {
                return Ok(productService.GetProductByName(productName));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
