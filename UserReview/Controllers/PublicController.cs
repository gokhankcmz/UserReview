using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserReview.ActionFilters;

namespace UserReview.Controllers
{
    [Route("api/public")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper; 
        private readonly IAuthenticationManager _authManager;
        public PublicController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IAuthenticationManager authManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
        }


        [HttpGet]
        public IActionResult GetAllApprovedReviews()
        {
            var reviews = _repository.Review.GetReviews(ReviewStatus.Approved, trackChanges: false);
            var reviewsDTO = _mapper.Map<IEnumerable<ReviewDtoPublic>>(reviews);
            return Ok(reviewsDTO);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Login([FromBody] UserForAuthenticationDto user)
        {
            var result = _authManager.Authenticate(user, _repository);
            return Ok(new { Token = result });
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserDtoForCreation user)
        {

            var userEntitiy = _mapper.Map<User>(user);
            _repository.User.CreateUser(userEntitiy);
            _repository.Save();
            var userToReturn = _mapper.Map<UserDto>(userEntitiy);
            return Ok();
            //return RedirectToAction("CreateUser", "UserController");
        }

    }
}
