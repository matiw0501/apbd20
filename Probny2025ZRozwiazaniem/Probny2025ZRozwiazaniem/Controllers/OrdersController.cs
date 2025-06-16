using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Probny2025ZRozwiazaniem.Data;
using Probny2025ZRozwiazaniem.DTOs;
using Probny2025ZRozwiazaniem.Exceptions;
using Probny2025ZRozwiazaniem.Services;

namespace Probny2025ZRozwiazaniem.Controllers;


    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IDbService _dbService;
        

        public OrdersController(IDbService dbService)
        {
            _dbService = dbService;
          
        }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {
            try
            {
                var order = await _dbService.GetOrders(id);
                return Ok(order);
            }
            catch (NotFoundException e)
            {
               return NotFound(e.Message);
            }
        }


        [HttpPut("{id}/{status}")]
        public async Task<IActionResult> FulfillOrder(int id, FulfillOrderDTO status)
        {
            try
            {
                await _dbService.FulfillOrder(id, status);
                return Ok();

            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ConflixtException e)
            {
                return Conflict(e.Message);
            }
        }

    }
