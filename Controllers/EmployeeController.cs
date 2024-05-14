using InMemoryCaching.Data;
using InMemoryCaching.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeDbContext _context;
        private readonly IMemoryCache _cache;


        public EmployeeController(EmployeeDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var products = await _context.Employees.ToListAsync();

        //    return Ok(products);
        //}

        [HttpGet]
        [Route("GetAllCache")]
        public async Task<IActionResult> GetAllCache()
        {
            var cacheKey = "GET_ALL_EMPLOYEES";

            // If data found in cache, return cached data
            if (_cache.TryGetValue(cacheKey, out List<Employee> Employees))
            {
                return Ok(Employees);
            }

            // If not found, then fetch data from database
            Employees = await _context.Employees.ToListAsync();

            // Add data in cache
            //_cache.Set(cacheKey, Employees);



            var cacheOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(5)
            };

            _cache.Set(cacheKey, Employees, cacheOptions);





            //var cacheOptions = new MemoryCacheEntryOptions()
            //{
            //    SlidingExpiration = TimeSpan.FromMinutes(5)
            //};

            //_cache.Set(cacheKey, Employees, cacheOptions);


            //var cacheOptions = new MemoryCacheEntryOptions()
            //{
            //    SlidingExpiration = TimeSpan.FromMinutes(5),
            //    AbsoluteExpiration = DateTime.Now.AddMinutes(60)
            //};

            //_cache.Set(cacheKey, Employees, cacheOptions);




            //var cacheOptions = new MemoryCacheEntryOptions()
            //{
            //    AbsoluteExpiration = DateTime.Now.AddMinutes(60),
            //    Priority = CacheItemPriority.High
            //};

            //_cache.Set(cacheKey, Employees, cacheOptions);


            return Ok(Employees);
        }


    }
}
