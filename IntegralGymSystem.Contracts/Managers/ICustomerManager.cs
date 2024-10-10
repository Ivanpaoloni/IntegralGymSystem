using IntegralGymSystem.Contracts.Dtos.Customer;

namespace IntegralGymSystem.Contracts.Managers
{
    public interface ICustomerManager
    {
        Task<Guid> CreateCustomerAsync(CustomerDto dto);
        Task DeleteCustomerAsync(Guid id);
        Task<CustomerDto> GetCustomerById(Guid id);
        Task<IEnumerable<CustomerDto>> GetCustomers();
        Task UpdateCustomerAsync(CustomerDto dto);
    }
}
