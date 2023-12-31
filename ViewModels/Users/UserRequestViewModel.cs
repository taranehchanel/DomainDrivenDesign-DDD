﻿namespace ViewModels.Users
{
	public class CreateRequestViewModel : object
	{
		public CreateRequestViewModel() : base()
		{
		}

		public int? Role { get; set; }

		public int? Gender { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public string LastName { get; set; }

		public string FirstName { get; set; }

		public string EmailAddress { get; set; }

		public string CellPhoneNumber { get; set; }
	}
}
