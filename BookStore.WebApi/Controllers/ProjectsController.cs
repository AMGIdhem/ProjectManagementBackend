using Bookstore.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {

        private readonly IProjectServices _projectServices;

        public ProjectsController(IProjectServices storeServices)
        {
            _projectServices = storeServices;
        }

        [HttpGet]
        public IActionResult GetProjects()
        {
            return Ok(_projectServices.GetProjects());
        }

        [HttpPost]
        public IActionResult AddProject(Project project)
        {
            _projectServices.AddProject(project);
            return CreatedAtRoute("GetProject", new { id = project.Id }, project);
        }

        [HttpGet("{id}", Name = "GetProject")]
        public IActionResult GetProject(string id)
        {
            return Ok(_projectServices.GetProject(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(string id)
        {
            _projectServices.DeleteProject(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateProject(Project project)
        {
            return Ok(_projectServices.UpdateProject(project));
        }
    }
}
