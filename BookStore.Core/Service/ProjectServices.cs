using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Bookstore.Core
{
    public class ProjectServices : IProjectServices
    {
        private readonly IMongoCollection<Project> _projects;

        public ProjectServices(IDbClient dbClient)
        {
            _projects = dbClient.GetProjectsCollection();
        }
        public Project AddProject(Project project)
        {
            _projects.InsertOne(project);
            return project;
        }

        public void DeleteProject(string id)
        {
            _projects.DeleteOne(project => project.Id == id);
        }

        public Project GetProject(string id) => _projects.Find(project => project.Id == id).First();

        public List<Project> GetProjects()
        {
            return _projects.Find(project => true).ToList();
        }

        public Project UpdateProject(Project project)
        {
            GetProject(project.Id);
            _projects.ReplaceOne(p => p.Id == project.Id, project);
            return project;
        }
    }
}
