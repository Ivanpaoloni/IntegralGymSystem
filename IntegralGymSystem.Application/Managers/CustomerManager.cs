using IntegralGymSystem.Contracts.Dtos.Customer;
using IntegralGymSystem.Contracts.Managers;
using IntegralGymSystem.Contracts.Services;

namespace IntegralGymSystem.Application.Managers
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerService _customerService;
        public CustomerManager(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<CustomerDto> GetCustomerById(Guid id)
        {
            try
            {
                return await _customerService.GetById(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener el cliente.", ex);
            }
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            try
            {
                return await _customerService.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener el listado de clientes.", ex);

            }
        }
        public async Task<Guid> CreateCustomerAsync(CustomerDto dto)
        {
            try
            {
                return await _customerService.CreateAsync(dto, true);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al crear el cliente.", ex);
            }
        }

        public async Task UpdateCustomerAsync(CustomerDto dto)
        {
            try
            {
                await _customerService.UpdateAsync(dto, true);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al actualizar el cliente.", ex);
            }
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            try
            {
                await _customerService.Delete(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al eliminar el cliente.", ex);
            }
        }
    }
}