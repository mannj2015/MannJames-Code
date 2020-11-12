using System;
using Microsoft.AspNetCore.Mvc;
using StoreDB.Models;
using StoreLib;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddCart(Cart cart)
        {
            try
            {
                cartService.AddCart(cart);
                return CreatedAtAction("AddCart", cart);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateCart(Cart cart)
        {
            try
            {
                cartService.UpdateCart(cart);
                return CreatedAtAction("UpdateCart", cart);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("get/{cartId}")]
        [Produces("application/json")]
        public IActionResult GetCartById(int id)
        {
            try
            {
                return Ok(cartService.GetCartById(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("delete")]
        [Produces("application/json")]
        public IActionResult GetCartByUserId(int id)
        {
            try
            {
                return Ok(cartService.GetCartByUserId(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteCart(Cart cart)
        {
            try
            {
                cartService.DeleteCart(cart);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}