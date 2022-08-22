using goodfood_provider.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using goodfood_provider.Entities;
using goodfood_provider.Models;
using goodfood_provider.Services.Interfaces;


namespace goodfood_provider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProviderService _providerSerivce;

        public ProviderController(IUnitOfWork unitOfWork, IProviderService providerSerivce)
        {
            _unitOfWork = unitOfWork;
            _providerSerivce = providerSerivce;
        }
        
        [HttpGet]
        public async Task<ActionResult<ICollection<Provider>>> GetProvider()
        {
            return (await _providerSerivce.GetAllProviderAsync()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Provider>> GetProduct(int id)
        {
            Provider provider = await _providerSerivce.GetProviderByIdAsync(id);

            if (provider == null)
            {
                return NotFound();
            }

            return provider;
        }

        [HttpPost]
        public async Task<ActionResult<Provider>> CreateProvider([FromForm] ProviderModel providerModel)
        {
            Provider providerFromDatabase = await _providerSerivce.CreateProviderAsync(providerModel);
            await _unitOfWork.SaveChangesAsync();
            return providerFromDatabase;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProvider(int id, [FromForm] ProviderModel providerModel)
        {
            if (id != providerModel.Id)
            {
                return BadRequest();
            }

            await _providerSerivce.UpdateProviderAsync(providerModel);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProvider(int id)
        {
            _providerSerivce.DeleteProviderAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

    }
}
