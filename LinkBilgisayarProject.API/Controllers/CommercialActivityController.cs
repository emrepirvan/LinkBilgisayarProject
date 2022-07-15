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
    public class CommercialActivityController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICommercialActivityService _service;
        public CommercialActivityController(IMapper mapper, ICommercialActivityService service = null)
        {
            _mapper = mapper;
            _service = service;
        }
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Editor)]
        [HttpGet("GetCommercialActivityWithCustomer")]
        public async Task<IActionResult> GetCommercialActivityWithCustomer()
        {
            var commercialActivitiesWithCustomer = await _service.GetCommercialActivitiesWithCustomer();
            var commercialActivitiesWithCustomerDtos = _mapper.Map<List<CommercialActivityWithCustomerDto>>(commercialActivitiesWithCustomer);
            return Ok(CustomResponseDto<List<CommercialActivityWithCustomerDto>>.Success(200, commercialActivitiesWithCustomerDtos));
        }
        //---------------------------------------
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Editor)]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var commercialActivities = await _service.GetAllAsync();
            var commercialActivitiesDtos = _mapper.Map<List<CommercialActivityDto>>(commercialActivities.ToList());
            return Ok(CustomResponseDto<List<CommercialActivityDto>>.Success(200, commercialActivitiesDtos));
        }
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Editor)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var commercialActivity = await _service.GetByIdAsync(id);
            var commercialActivityDto = _mapper.Map<CommercialActivityDto>(commercialActivity);
            return CreateActionResult(CustomResponseDto<CommercialActivityDto>.Success(200, commercialActivityDto));
        }
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Editor)]
        [HttpPost]
        public async Task<IActionResult> Save(CommercialActivityDto commercialActivityDto)
        {
            var commercialActivity = await _service.AddAsync(_mapper.Map<CommercialActivity>(commercialActivityDto));
            var commercialActivitiesDto = _mapper.Map<CommercialActivityDto>(commercialActivity);
            return CreateActionResult(CustomResponseDto<CommercialActivityDto>.Success(201, commercialActivitiesDto));
        }
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Editor)]
        [HttpPut]
        public async Task<IActionResult> Update(CommercialActivityDto commercialActivityDto)
        {
            await _service.UpdateAsync(_mapper.Map<CommercialActivity>(commercialActivityDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var commercialActivity = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(commercialActivity);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete]
        public async Task<IActionResult> RemoveRange(int[] id)
        {
            List<CommercialActivity> ca = new List<CommercialActivity>();
            foreach (var item in id)
            {
                var commercialActivity = await _service.GetByIdAsync(item);
                ca.Add(commercialActivity);
            }
            await _service.RemoveRangeAsync(ca);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}