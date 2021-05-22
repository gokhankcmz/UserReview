using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserReview.ActionFilters;

namespace UserReview.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public UserController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet, Authorize(Policy = "UserAccess")]
        public IActionResult GetAllUsersIncludingAdmin()
        {
            // Burada user girişi ile admin hesaplarının görülmemesi durumunu gerçeklemeye çalıştım.
            var users = ControllerContext.HttpContext.User.IsInRole("Admin") ? 
                _repository.User.GetUsersAndAdmins(trackChanges: false): 
                _repository.User.GetUsers(trackChanges: false);
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(usersDto);
        }



        [HttpGet("{id}", Name="UserById"), Authorize(Policy = "UserAccess")]
        public IActionResult GetUser(Guid id)
        {
            // Tekil sorgulamalarda aynı sorgulamayı kullanmadım. Sadece yukarıda denemek istedim.
            var user = _repository.User.GetUser(id, trackChanges: false);
            if (user == null)
            {
                _logger.LogInfo($"User with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var usersDto = _mapper.Map<UserDto>(user);
                return Ok(usersDto);
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateUser([FromBody] UserDtoForCreation user)
        {
            var userEntitiy = _mapper.Map<User>(user);
            _repository.User.CreateUser(userEntitiy);
            _repository.Save();
            var userToReturn = _mapper.Map<UserDto>(userEntitiy);  
            return Ok();
            //return CreatedAtRoute("UserById", new { id = userToReturn.id }, userToReturn);   
            //LOGİN OLMADAN DÖNÜŞ SORUN ÇIKARIR. UserById yetki istiyor. Login'e yönlendir.
        }
    }
}
