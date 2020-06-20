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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            var categories = await _repository.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Details(int id)
        {
            var category = await _repository.Get(id);
            if (category == null)
                return NotFound();
            else
                return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                await _repository.Add(category);
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != category.Id)
                return BadRequest();

            try
            {
                await _repository.Update(category);
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
            var category = await _repository.Get(id);
            if (category == null)
                return BadRequest();

            try
            {
                await _repository.Delete(category);
                return Ok();
            }
            catch (DbUpdateException exception)
            {
                throw exception;
            }
        }
    }
}
