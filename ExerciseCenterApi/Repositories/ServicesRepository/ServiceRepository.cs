using ExerciseCenter_API.Models;
using ExerciseCenter_API.Models.ServicesModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace ExerciseCenter_API.Repositories.ServicesRepository
{
    public class ServiceRepository:IServiceRepository
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllServices()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service> GetServiceById(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<Service> CreateService(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task UpdateService(Service service)
        {
            _context.Entry(service).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        }
    }
}
