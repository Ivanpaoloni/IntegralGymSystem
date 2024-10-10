using IntegralGymSystem.Contracts.Dtos.Customer;
using IntegralGymSystem.Contracts.Services;
using IntegralGymSystem.Contracts.UnitOfWork;
using IntegralGymSystem.Domain.Entities;

namespace IntegralGymSystem.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _unitOfWork.Customers.GetAllAsync();
            var list = new List<CustomerDto>();
            foreach (var customer in customers)
            {
                list.Add(new CustomerDto()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    DNI = customer.DNI,
                    Email = customer.Email,
                    EmergencyContactName = customer.EmergencyContactName,
                    EmergencyContactPhoneNumber = customer.EmergencyContactPhoneNumber,
                    GymId = customer.GymId,
                    PhoneNumber = customer.PhoneNumber,
                    Surname = customer.Surname,
                });
            }
            return list;
        }

        public async Task<CustomerDto> GetById(Guid id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer == null) throw new ArgumentException("Cliente no encontrado");
            var customerDto = new CustomerDto()
            {
                Id = customer.Id,
                Name = customer.Name,
                DNI = customer.DNI,
                Email = customer.Email,
                EmergencyContactName = customer.EmergencyContactName,
                EmergencyContactPhoneNumber = customer.EmergencyContactPhoneNumber,
                GymId = customer.GymId,
                PhoneNumber = customer.PhoneNumber,
                Surname = customer.Surname,
            };
            return customerDto;
        }

        public async Task<Guid> CreateAsync(CustomerDto dto, bool saveChanges = false)
        {
            dto.Id = Guid.NewGuid();
            var customer = new Customer()
            {
                Id = dto.Id,
                Name = dto.Name,
                DNI = dto.DNI,
                Email = dto.Email,
                EmergencyContactName = dto.EmergencyContactName,
                EmergencyContactPhoneNumber = dto.EmergencyContactPhoneNumber,
                GymId = dto.GymId,
                PhoneNumber = dto.PhoneNumber,
                Surname = dto.Surname,
            };

            await _unitOfWork.Customers.AddAsync(customer);
            if (saveChanges) await _unitOfWork.SaveAsync();

            return dto.Id;
        }

        public async Task UpdateAsync(CustomerDto dto, bool saveChanges = false)
        {
            await UpdateAsync(new Customer
            {
                Id = dto.Id,
                Name = dto.Name,
                DNI = dto.DNI,
                Email = dto.Email,
                EmergencyContactName = dto.EmergencyContactName,
                EmergencyContactPhoneNumber = dto.EmergencyContactPhoneNumber,
                GymId = dto.GymId,
                PhoneNumber = dto.PhoneNumber,
                Surname = dto.Surname,
            }, false);

            if (saveChanges) await _unitOfWork.SaveAsync();
        }

        public async Task Delete(Guid id) => await _unitOfWork.Customers.DeleteAsync(id);

        internal async Task<Customer> FindById(Guid id)
        {
            var result = await _unitOfWork.Customers.GetByIdAsync(id);

            if (result == null) throw new ArgumentException("Cliente no encontrado");

            return result;
        }

        internal async Task UpdateAsync(Customer customer, bool saveChanges = false)
        {
            var oldcustomer = await FindById(customer.Id);

            oldcustomer.Name = customer.Name;
            oldcustomer.DNI = customer.DNI;
            oldcustomer.Email = customer.Email;
            oldcustomer.EmergencyContactName = customer.EmergencyContactName;
            oldcustomer.EmergencyContactPhoneNumber = customer.EmergencyContactPhoneNumber;
            oldcustomer.GymId = customer.GymId;
            oldcustomer.PhoneNumber = customer.PhoneNumber;
            oldcustomer.Surname = customer.Surname;

            await _unitOfWork.Customers.UpdateAsync(oldcustomer);
            if (saveChanges) await _unitOfWork.SaveAsync();
        }
    }
}
