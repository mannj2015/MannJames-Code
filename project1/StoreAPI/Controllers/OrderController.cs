using System;
using Microsoft.AspNetCore.Mvc;
using StoreDB.Models;
using StoreLib;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddOrder(Order order)
        {
            try
            {
                orderService.AddOrder(order);
                return CreatedAtAction("AddOrder", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateOrder(Order order)
        {
            try
            {
                orderService.UpdateOrder(order);
                return CreatedAtAction("UpdateOrder", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteOrder(Order order)
        {
            try
            {
                orderService.DeleteOrder(order);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/Order/all/locId={locationId}")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByLocationId(int id)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByLocationId(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpGet("get/Order/userId={userId}")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByUserId(int id)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByUserId(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("get/Order/userId={userId}/date/asc")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByUserIdDateAsc(int id)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByUserIdDateAsc(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("get/Order/userId={userId}/date/desc")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByUserIdDateDesc(int id)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByUserIdDateDesc(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("get/Order/userId={userId}/price/asc")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByUserIdPriceAsc(int id)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByUserIdPriceAsc(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("get/Order/userId={userId}/price/desc")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByUserIdPriceDesc(int id)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByUserIdPriceDesc(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("get/Order/{dateTime}")]
        [Produces("application/json")]
        public IActionResult GetOrderByDate(DateTime dateTime)
        {
            try
            {
                return Ok(orderService.GetOrderByDate(dateTime));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("get/Order/{orderId}")]
        [Produces("application/json")]
        public IActionResult GetOrderById(int id)
        {
            try
            {
                return Ok(orderService.GetOrderById(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("get/Order/locId={locationId}")]
        [Produces("application/json")]
        public IActionResult GetOrderByLocationId(int id)
        {
            try
            {
                return Ok(orderService.GetOrderByLocationId(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("get/{userId}")]
        [Produces("application/json")]
        public IActionResult GetOrderByUserId(int id)
        {
            try
            {
                return Ok(orderService.GetOrderByUserId(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}