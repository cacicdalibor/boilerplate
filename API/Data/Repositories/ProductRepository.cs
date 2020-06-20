using API.Data.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
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

        public async Task<object> Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return new { };
        }

        public async Task<object> Delete(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return new { };
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<object> Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
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
    }
}