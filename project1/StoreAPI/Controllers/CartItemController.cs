using System;
using Microsoft.AspNetCore.Mvc;
using StoreDB.Models;
using StoreLib;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService cartItemService;
        public CartItemController(ICartItemService cartItemService)
        {
            this.cartItemService = cartItemService;
        }
        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddCartItem(CartItem cartItem)
        {
            try
            {
                cartItemService.AddCartItem(cartItem);
                return CreatedAtAction("AddCartItem", cartItem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateCartItem(CartItem cartItem)
        {
            try
            {
                cartItemService.UpdateCartItem(cartItem);
                return CreatedAtAction("UpdateCartItem", cartItem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("get/{cartItemId}")]
        [Produces("application/json")]
        public IActionResult GetCartItemById(int cartItemId)
        {
            try
            {
                return Ok(cartItemService.GetCartItemById(cartItemId));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /*        [HttpPost("get/{cartId}")]
                [Consumes("application/json")]
                [Produces("application/json")]
                public IActionResult GetCartItemByCartId(int cartId)
                {
                    try
                    {
                        return Ok(cartItemService.GetAllCartItemsByCartId(cartId));
                    }
                    catch (Exception)
                    {
                        return BadRequest();
                }
                }
           */

        [HttpPost("get/{cartId}")]
        [Produces("application/json")]
        public ActionResult GetAllCartItemsByCartId(int cartId)
        {
            try
            {
                return Ok(cartItemService.GetAllCartItemsByCartId(cartId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult DeleteCartItem(CartItem cartItem)
        {
            try
            {
                cartItemService.DeleteCartItem(cartItem);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
