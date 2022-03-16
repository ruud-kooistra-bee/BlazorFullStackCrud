using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorFullStackCrud.Shared;

namespace BlazorFullStackCrud.Client.Services
{
    public interface IRoleService
    {
        IList<Role> Roles { get; }

        IList<UserRole> MyRoles { get; set; }

        void AddRole(int roleId);
    }
}
