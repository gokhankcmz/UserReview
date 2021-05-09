using Contracts;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserReview.Controllers
{
    [Route("api/public")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public PublicController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult GetAllApprovedReviews()
        {
            var reviews = _repository.Review.GetReviews(ReviewStatus.Approved, trackChanges: false);
            return Ok(reviews);
        }

    }
}
