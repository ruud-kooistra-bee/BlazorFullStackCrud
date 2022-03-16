using Blazored.Toast.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorFullStackCrud.Shared;

namespace BlazorFullStackCrud.Client.Services
{
    public class RoleService : IRoleService
    {
        private readonly IToastService _toastService;

        public RoleService(IToastService toastService)
        {
            _toastService = toastService;
        }

        public IList<Role> Roles => new List<Role>
        {
            new Role { Id = 1, Name = "Admin" },
            new Role { Id = 2, Name = "User" }
        };

        public IList<UserRole> MyRoles { get; set; } = new List<UserRole>();

        public void AddRole(int RoleId)
        {
            var role = Roles.First(role => role.Id == RoleId);
            MyRoles.Add(new UserRole { RoleId = role.Id });
            _toastService.ShowSuccess($"Your role {role.Name} has been added!");
        }
    }
}
