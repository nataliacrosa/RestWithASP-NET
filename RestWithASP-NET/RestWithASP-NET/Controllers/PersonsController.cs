﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASP_NET.Business;
using RestWithASP_NET.Data.VO;

namespace RestWithASP_NET.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]    
    public class PersonsController : Controller
    {
        private IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        [HttpGet("find-by-name")]
        [Authorize("Bearer")]
        public IActionResult GetByName([FromQuery] string firstName, [FromQuery] string lastName)
        {
            return new OkObjectResult(_personBusiness.FindByName(firstName, lastName));
        }

        [HttpGet("find-with-paged-search/{sortDirection}/{pageSize}/{page}")]
        [Authorize("Bearer")]
        public IActionResult GetPagedSearch([FromQuery] string name, string sortDirection, int pageSize, int page)
        {                     
            return new OkObjectResult(_personBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

        // GET api/values
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            return new OkObjectResult(_personBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize("Bearer")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]PersonVO person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT api/values/5
        [HttpPut]
        [Authorize("Bearer")]
        public IActionResult Put([FromBody]PersonVO person)
        {
            if (person == null) return BadRequest();
            var updatePerson = _personBusiness.Update(person);
            if (updatePerson == null) return NoContent();
            return new ObjectResult(updatePerson);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
