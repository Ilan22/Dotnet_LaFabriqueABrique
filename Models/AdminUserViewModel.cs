using LaFabriqueaBriques.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaFabriqueaBriques.Models
{
    public class AdminUserViewModel
    {
        public List<User> Users { get; set; }
        public int Role { get; set; }
    }
}