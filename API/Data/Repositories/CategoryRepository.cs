using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data.Interfaces;
using API.Models;

namespace API.Data.Repositories
{
    public class CategoryRepository : IDisposable, ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        protected async void Dispose(bool disposing)
        {
            if (disposing)
                if (_context != null)
                    await _context.DisposeAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.Include(x => x.Products).ToListAsync();
        }

        public async Task<Category> Get(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<object> Add(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return new { };
        }

        public async Task<object> Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return new { };
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<object> Delete(Category category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return new { };
        }
    }
}