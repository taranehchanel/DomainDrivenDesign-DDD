﻿namespace ViewModels.Users
{
	public class UserRequestViewModel : object
	{
		public UserRequestViewModel() : base()
		{
		}

		public int? Role { get; set; }

		public int? Gender { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public string LastName { get; set; }

		public string FirstName { get; set; }

		public string EmailAddress { get; set; }
	}
}
