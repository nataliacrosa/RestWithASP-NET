using Microsoft.AspNetCore.Mvc;
using RestWithASP_NET.Model;
using RestWithASP_NET.Business;
using RestWithASP_NET.Data.VO;
using Microsoft.AspNetCore.Authorization;

namespace RestWithASP_NET.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : Controller
    {
        private IBookBusiness _bookBusiness;

        public BooksController(IBookBusiness BookBusiness)
        {
            _bookBusiness = BookBusiness;
        }
        // GET api/values
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize("Bearer")]
        public IActionResult Get(long id)
        {
            var Book = _bookBusiness.FindById(id);
            if (Book == null) return NotFound();
            return Ok(Book);
        }

        // POST api/values
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_bookBusiness.Create(book));
        }

        // PUT api/values/5
        [HttpPut]
        [Authorize("Bearer")]
        public IActionResult Put([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();
            var updateBook = _bookBusiness.Update(book);
            if (updateBook == null) return NoContent();
            return new ObjectResult(updateBook);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
