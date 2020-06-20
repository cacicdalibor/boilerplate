using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var products = await _repository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Details(int id)
        {
            var product = await _repository.Get(id);
            if (product == null)
                return NotFound();
            else
                return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                await _repository.Add(product);
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != product.Id)
                return BadRequest();

            try
            {
                await _repository.Update(product);
                return Ok();
            }
            catch (DbUpdateException exception)
            {
                throw exception;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _repository.Get(id);
            if (product == null)
                return BadRequest();

            try
            {
                await _repository.Delete(product);
                return Ok();
            }
            catch (DbUpdateException exception)
            {
                throw exception;
            }
        }
    }
}
