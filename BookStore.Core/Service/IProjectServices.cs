using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public interface IProjectServices
    {
        List<Project> GetProjects();
        Project GetProject(string id);
        Project AddProject(Project project);
        void DeleteProject(string id);
        Project UpdateProject(Project project);
    }
}
