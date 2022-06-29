using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organized
{
    internal class businessService
    {
        private businessDataService service;

        public businessService()
        {
            service = new businessDataService();
        }

        public List<Course> getCourses()
        {
            return service.getCourses();
        }
    }
}
