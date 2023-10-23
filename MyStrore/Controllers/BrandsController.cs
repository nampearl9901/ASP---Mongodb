﻿using Microsoft.AspNetCore.Mvc;
using MyStrore.Data;
using MyStrore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStrore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BrandsController : ControllerBase
    {
        private readonly IBrandServices _brands;
        public BrandsController(IBrandServices brandServices)
        {
            _brands = brandServices;
        }
        // GET: api/<BrandsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var brands = await _brands.GetAllAsynsc();
            return Ok(brands);
        }

        // GET api/<BrandsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var brands = await _brands.GetById(id);
            if (brands == null)
            {
                return NotFound();
            }
            return Ok(brands);
        }

        // POST api/<BrandsController>
        [HttpPost]
        public async Task<IActionResult> Post(Brands brands)
        {
            await _brands.CreateAsync(brands);
            return Ok("created successfully");
        }

        // PUT api/<BrandsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Brands newbrands)
        {
            
            var existingbrands = await _brands.GetById(id);
            if (existingbrands == null)
            {
                return NotFound();
            }

            // Kiểm tra xem id trong newcategory có giống với id truyền vào không
            if (newbrands.Id != id)
            {
                // Trường Id không thể chỉnh sửa
                return BadRequest("Cannot update Id");
            }

            await _brands.UpdateAsync(id, newbrands);
            return Ok("Updated successfully");
        }

        // DELETE api/<BrandsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var brands = await _brands.GetById(id);
            if (brands == null)

                return NotFound();
            await _brands.DeleteAysnc(id);
            return Ok("Delete successfully");
        }
    }
}
