using System;
using Microsoft.AspNetCore.Mvc;

namespace APIintro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    List<string> studens = new() { "Tunzale", "Semed", "Meryem", "Haci" };
        //    return Ok(studens);
        //}

        //[HttpPost]
        //public IActionResult Search([FromBody] User user)
        //{
        //    return Ok(user.Surname + user.Name);
        //}


        //[HttpGet("{id}")]
        //public IActionResult GetById([FromRoute] int id)
        //{
        //    return Ok(id + "-this is id");
        //}

        //[HttpPost]
        //public IActionResult Test1()
        //{
        //    return Ok();
        //}


        //[HttpDelete]
        //public IActionResult Test2()
        //{
        //    return Ok();
        //}


        //[HttpPut]
        //public IActionResult Test3()
        //{
        //    return Ok();
        //}
    }

}

