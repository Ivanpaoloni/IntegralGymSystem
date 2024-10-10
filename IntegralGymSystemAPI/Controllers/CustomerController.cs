using IntegralGymSystem.Contracts.Dtos.Customer;
using IntegralGymSystem.Contracts.Dtos.Gym;
using IntegralGymSystem.Contracts.Managers;
using IntegralGymSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IntegralGymSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;
        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            var list = await _customerManager.GetCustomers();
            return list;
        }
        
        [HttpGet("{id}")]
        public async Task<CustomerDto> GetDto(Guid id)
        {
            return await _customerManager.GetCustomerById(id);
        }

        [HttpPost]
        public async Task<Guid> Post(CustomerDto dto)
        {
            return await _customerManager.CreateCustomerAsync(dto);
        }

        [HttpPut]
        public async Task Put(CustomerDto dto)
        {
            await _customerManager.UpdateCustomerAsync(dto);
        }
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _customerManager.DeleteCustomerAsync(id);
        }
    }
}
