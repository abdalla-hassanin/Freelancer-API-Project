using FreelancerApiProject.Api.Base;
using FreelancerApiProject.Core.MediatrHandlers.Category.Commands.Models;
using FreelancerApiProject.Core.MediatrHandlers.Category.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerApiProject.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetCategoriesQuery());
            return CreateResponse(response);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetCategoryByIdQuery(id));
            return CreateResponse(response);
        }

     
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] AddCategoryCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRate(EditCategoryCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteCategoryCommand(id));
            return CreateResponse(response);
        }
    }
}