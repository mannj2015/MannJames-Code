﻿using System;
using Microsoft.AspNetCore.Mvc;
using StoreDB.Models;
using StoreLib;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddInventoryItem(InventoryItem item)
        {
            try
            {
                inventoryService.AddInventoryItem(item);
                return CreatedAtAction("AddInventoryItem", item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateInventoryItem(InventoryItem item)
        {
            try
            {
                inventoryService.UpdateInventoryItem(item);
                return CreatedAtAction("UpdateInventoryItem", item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteInventoryItem(InventoryItem item)
        {
            try
            {
                inventoryService.DeleteInventoryItem(item);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{locationId}")]
        [Produces("application/json")]
        public IActionResult GetAllInventoryItemsByLocationId(int id)
        {
            try
            {
                //TODO this is broken
                return Ok(inventoryService.GetAllInventoryItemsByLocationId(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{locationId}/{productId}")]
        [Produces("application/json")]
        public IActionResult GetItemByLocationIdBookId(int locationId, int productId)
        {
            try
            {
                return Ok(inventoryService.GetItemByLocationIdProductId(locationId, productId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}