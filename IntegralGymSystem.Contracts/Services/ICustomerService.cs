using IntegralGymSystem.Contracts.Dtos.Customer;

namespace IntegralGymSystem.Contracts.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetById(Guid id);
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<Guid> CreateAsync(CustomerDto dto, bool saveChanges = false);
        Task UpdateAsync(CustomerDto dto, bool saveChanges = false);
        Task Delete(Guid id);
    }
}
