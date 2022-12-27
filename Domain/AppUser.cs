using System;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
	public class AppUser : IdentityUser
	{
		public string? Nickname { get; set; }
	}
}