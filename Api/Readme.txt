--------------------------------------------------
----- Swagger ------------------------------------
--------------------------------------------------

(1)

Install-Package Swashbuckle.AspNetCore

	Swashbuckle.AspNetCore.Swagger
	Swashbuckle.AspNetCore.SwaggerUI
	Swashbuckle.AspNetCore.SwaggerGen

(2)

Right click on Application -> Properties -> Build ->
Check: XML documentation file check box
Fill Text Box (File Name): Api.xml ([ApplicationName].xml)

Note: Never use path!

Note: After this settings, If we do not use xml documentation
(For classes and members), VS will display some warnings!

URL: https://localhost:44335/swagger/index.html
--------------------------------------------------

جلسه چهاردهم

Domain

	Domain

		SeedWork

			IDomainEvent.cs

			IEntity.cs
			IAggregateRoot.cs

			Entity.cs
			AggregateRoot.cs

		Aggregates

			Users
				Events
					UserPasswordChangedEvent.cs

				User.cs
					Function: ChangePassword [TODO: Check Old Password!]

Infrastructure

	Persistence

		DatabaseContext.cs

			Function: Constructor
			Function: SaveChangesAsync Not SaveChanges!

Api

	Api

		Startup.cs

			Function: ConfigureServices [AddMediatR]

Infrastructure

	Application

		Users

			EventHandlers

				UserPasswordChangedEventHandler.cs [Register Philosophy in Startup.cs]

Run:

	1. ChangePassword -> Change Password with New Password
	2. ChangePassword -> Change Password with Old Password
