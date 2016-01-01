using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SXEdu2XHKD.Domain.Entities
{
    public enum MemberStatus
    {
        Normal = 1,
        DidntSetPassWord = 2,
        ForgotPassWord = 3,
        Banned = 4
    }
}
