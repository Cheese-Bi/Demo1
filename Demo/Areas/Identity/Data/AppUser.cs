using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Microsoft.AspNetCore.Identity;

namespace Demo.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    
    public DateTime? DoB { get; set; }
    public string? Address { get; set; }
    public Store? Store { get; set; }  //store co the null
    public virtual ICollection<Order>? Orders { get; set; }
}

