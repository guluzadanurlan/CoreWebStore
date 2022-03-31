using Microsoft.AspNetCore.Identity;

namespace CoreUI.Identity
{
    public class User: IdentityUser
    {
       public string Name { get; set; }
       public string LastName { get; set; }

       public string Password{get;set;}
    }
}