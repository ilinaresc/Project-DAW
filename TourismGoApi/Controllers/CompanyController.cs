using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourismGoDomain.Core.Entities;
using TourismGoDomain.Core.Interfaces;

namespace TourismGoApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _companyRepository.GetAll();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var companies = await _companyRepository.GetById(id);
            if (companies == null)
                return NotFound();

            return Ok(companies);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Companies companies)
        {
            var result = await _companyRepository.Insert(companies);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Companies companies)
        {
            if (id != companies.Id) return BadRequest();
            var result = await _companyRepository.Update(companies);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _companyRepository.Delete(id);
            if (!result)
                return BadRequest();
            return Ok(result);
        }
    }
}
