using AutoMapper;
using LinkBilgisayarProject.Core.Dtos;
using LinkBilgisayarProject.Core.Entites;
using LinkBilgisayarProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkBilgisayarProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _service;
        public CustomersController(IMapper mapper,  ICustomerService service )
        {
            _mapper = mapper;
            _service = service;
        }
        //-------------------------------------------------------
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Editor)]
        [HttpGet("[action]/{customerId}")]
        public async Task<IActionResult> GetOneCustomerByIdWithCommercialActivities(int customerId)
        {
            var customers = await _service.GetOneCustomerByIdWithCommercialActivitiesAsync(customerId);
            var customersDtos = _mapper.Map<CustomerWithCommercialAcitivityDto>(customers);
            return Ok(CustomResponseDto<CustomerWithCommercialAcitivityDto>.Success(200, customersDtos));
        }





        //-------------------------------------------------------
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Editor)]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var customers = await _service.GetAllAsync();
            var customersDtos = _mapper.Map<List<CustomerDto>>(customers.ToList());
            return Ok(CustomResponseDto<List<CustomerDto>>.Success(200, customersDtos));
        }
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Editor)]
        // GET /api/User/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(200, customerDto));
        }

        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Editor)]
        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto customerDto)
        {
            var customer = await _service.AddAsync(_mapper.Map<Customer>(customerDto));
            var customersDto = _mapper.Map<CustomerDto>(customer);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(201, customersDto));
        }
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Editor)]
        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            await _service.UpdateAsync(_mapper.Map<Customer>(customerDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(customer);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete]
        public async Task<IActionResult> RemoveRange(int[] id)
        {
            List<Customer> cs = new List<Customer>();
            foreach (var item in id)
            {
                var customer = await _service.GetByIdAsync(item);
                cs.Add(customer);
            }
            await _service.RemoveRangeAsync(cs);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
