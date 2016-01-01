using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXEdu2XHKD.Domain.Concrete
{
    public partial class SchoolRepository
    {
        public SXEdu2XHKD.Domain.Entities.School GetModelBySchoolName(string schoolName)
        {
            return dal.GetModelBySchoolName(schoolName);
        }

        public bool SchoolNameExists(string schoolName)
        {
            return dal.SchoolNameExists(schoolName);
        }
    }
}
