﻿using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var reviewsDTO = _mapper.Map<IEnumerable<PublicReview>>(reviews);
            return Ok(reviewsDTO);
        }


        [HttpGet("{id}")]
        public IActionResult GetUserReviews(Guid id)
        {
            var reviews = _repository.Review.GetReviews(id, trackChanges: false);
            var reviewsDTO = _mapper.Map<IEnumerable<PublicReview>>(reviews);
            return Ok(reviewsDTO);
        }


    }
}
