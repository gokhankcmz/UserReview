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
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ReviewController(IRepositoryManager repository, ILoggerManager logger,  IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAllApprovedReviews()
        {

            var reviews = _repository.Review.GetReviews(ReviewStatus.Approved, trackChanges: false);
            var reviewsDTO = _mapper.Map<IEnumerable<ReviewDtoPublic>>(reviews);
            return Ok(reviewsDTO);
        }



        [HttpGet("{id}", Name = "ReviewById"), Authorize(Policy = "UserAccess")]
        public IActionResult GetSingleReview(Guid id)
        {
            var review = _repository.Review.GetReview(id, trackChanges: false);
            var reviewsDTO = _mapper.Map<IEnumerable<ReviewDtoPublic>>(review);
            return Ok(reviewsDTO);
        }

        [HttpPut("{id}"), Authorize(Policy = "UserAccess")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult UpdateReview(Guid id, [FromBody] ReviewForUpdateDto reviewDtoForUserUpdate)
        {
            var reviewEntity = _repository.Review.GetReview(id, trackChanges:true);
            if (reviewEntity == null)
            {
                _logger.LogInfo($"Review with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var claim = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            if (!reviewEntity.userId.Equals(new Guid(userId)))
            {
                _logger.LogInfo($"User:{userId} is unauthorized to update review with id: {id}");
                return Unauthorized();
            }
            _mapper.Map(reviewDtoForUserUpdate, reviewEntity);
            _repository.Save();
            return NoContent();
        }



        [HttpPost, Authorize(Policy = "UserAccess")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult PostReview([FromBody] ReviewForCreationDto reviewDtoForCreation)
        {
            var reviewEntitiy = _mapper.Map<Review>(reviewDtoForCreation);
            var claim = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            _repository.Review.CreateReview(new Guid(userId),reviewEntitiy);
            _repository.Save();
            var reviewToReturn = _mapper.Map<ReviewDto_user>(reviewEntitiy);
            return CreatedAtRoute("ReviewById", new { id = reviewDtoForCreation.id }, reviewToReturn);
        }

        [HttpGet("user"), Authorize(Policy = "UserAccess")]
        public IActionResult GetUserReviews()
        {
            var claim = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);
            var userId = new Guid(claim.Value);
            var reviews = _repository.Review.GetReviews(userId, trackChanges: false);
            var reviewsDTO = _mapper.Map<IEnumerable<ReviewDto_user>>(reviews);
            return Ok(reviewsDTO);
        }

        [HttpGet("pending"), Authorize(Policy = "AdminAccess")]
        public IActionResult GetAllPending()
        {
            var reviews = _repository.Review.GetReviews(ReviewStatus.Pending, trackChanges: false);
            return Ok(reviews);
        }
        [HttpGet("rejected"), Authorize(Policy = "AdminAccess")]
        public IActionResult GetAllRejected()
        {
            var reviews = _repository.Review.GetReviews(ReviewStatus.Rejected, trackChanges: false);
            return Ok(reviews);
        }
        [HttpPut("approve/{id}"), Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult ApproveReview(Guid id)
        {
            var reviewEntity = _repository.Review.GetReview(id, trackChanges: true);
            if (reviewEntity == null)
            {
                _logger.LogInfo($"Review with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var claim = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);
            var adminId = new Guid(claim.Value);
            reviewEntity.status = ReviewStatus.Approved;
            reviewEntity.operatedBy = adminId;
            _repository.Save();
            return NoContent();
        }

        [HttpPut("reject/{id}"), Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult RejectReview(Guid id, [FromBody] RejectReasonDto RejectReason)
        {
            var reviewEntity = _repository.Review.GetReview(id, trackChanges: true);
            if (reviewEntity == null)
            {
                _logger.LogInfo($"Review with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var claim = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);
            var adminId = new Guid(claim.Value);
            reviewEntity.status = ReviewStatus.Rejected;
            reviewEntity.operatedBy = adminId;
            reviewEntity.rejectReason = RejectReason.rejectReason;
            _repository.Save();
            return NoContent();
        }


    }
}
