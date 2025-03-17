using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserInformation.Application.IRepositories;
using UserInformation.Domain.Entities;

namespace UserInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoRepository _userInfoRepository;
        public UserInfoController(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<bool>> CreateUser(UserInfo vm)
        {
            return Ok(await _userInfoRepository.CreateUser(vm));
        }
        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<ActionResult<List<UserInfo>>> GetAllUsers()
        {
            return Ok(await _userInfoRepository.GetAllUsers());
        }
    }
}
