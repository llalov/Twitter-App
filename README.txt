# ASP.NET MVC Project

STEPS TO CREATE BASE OF WEB-APP:

1. Create a new new Blank Solution project 
2. Add folders Common, Data, External Libraries, Web
3. In web folder add new ASP.NET Web Application with name (projName.Web) -> MVC
4. Open Package Manager console and type 'update-package'
5. In 'Data' add new 'Class Library' project (projName.Data) and delete Class.cs
	- add new class 'ApplicationDbContext.cs'
	- in Web->Models->IdentityModels cut ApplicationDbContext class and place it in projName.Data->ApplicationDbContext``		  .cs 
	- in projName.Data install ASP.NET.Identity.Entity framework, upgrade -||-.Entity framwork
6. In 'Data' add new 'Class Library' project (projName.Models) and delete Class.cs
	- install ASP.NET.Entity framework
	- install ASP.NET.Identity.Entity framework
	- add new class 'User.cs'
	- in Web->Models->IdentityModels cut ApplicationUser class and place it in projName.Models->User.cs
7. In projName.Web add references to projName.Data and projName.Models
8. In projName.Data add references to projName.Models
9. Edit 'Web.config' file
10. projName.Web->App_Start-> IdentityConfig.cs -> in ApplicationUserManager edit PasswordValidator 
11. Build and fix assembly references
12. Web->Models->AccountViewModels-> edit LoginViewModel, RegisterViewModel 
13. In AccountController -> Login-> change model.email with model.UserName; Register-> change UserName = model.email (UserName)
	14. Web->Views->Account->Login.cshtml -> change to log with username not email; Register.cshtml-> add one more input field like email, for username.
14. Create Models
15. Open Package Manager Console, in projName.Data (where ApplicationDbContext.cs is) and type: 'Enable-Migrations -EnableAutomaticMigrations'
16. ApplicationDbContext.cs-> 'Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());'
17. Package Manager Console-> update-database
18. ApplicationDbContext.cs->Add 'public IDbSet<Model> Models {get; set;}' for all Models
19. ApplicationDbContext.cs-> 
	(example)
		'protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Endorcement>()
        .HasRequired(e => e.UserSkill)
        .WithMany(usrSkl => usrSkl.Endorcements)
        .WillCascadeOnDelete(false);
			
			base.OnModelCreating(modelBuilder);
		}'
20. projName.Data-> create: IApplicationDbContext.cs, IprojNameData.cs, projNameData.cs; Create 'Repositories' folder->IRepository.cs and GenericRepository.cs.
21. Delete Web->Models->IdentityModels.cs	
22. Create Web->Controllers->BaseController.cs and make all controllers inherit it;
23. Web-> Install 'Ninject.MVC5' package
24. Web->App_Start->NinjectWebCommon.cs-> in 'RegisterServices' method add: 
	kernel.Bind<IprojNameData>().To<projNameData>();
kernel.Bind<IApplicationDbContext>().To<ApplicationDbContext>();
25. If you want to remove the 'Web Forms View Engine' for better performance:
	-Web->App_Start-> create class "ViewEnginesConfig.cs", clear all view engines and add only razor(or any other that you want to use)
	-Web->Global.asax.cs->ApplicationStart()-> add: 'ViewEnginesConfig.RegisterViewEngines(ViewEngines.Engines);'
26. Web-> Install packages: 'Glimpse.Mvc5' and 'Glimpse.EF6', open localhost:****/glimpse.axd and enable glimpse
27. Web-> Install package: Microsoft.jQuery.Unobtrusive.Ajax; Web->App_Start-> add this code: 
			"bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                "~/Scripts/jquery.unobtrusive-ajax.min.js"));"
		Include the unobtrusive AJAX script in the view which needs AJAX: "@section scripts {@Scripts.Render("~/bundles/ajax")}"
28. Notifications system: Web-> Install: "BootstrapNotifications"; Views->Shared->_Layout.cshtml : add before "@RenderBody()": "@Html.Partial("_Notifications")"
	- when is successfull before redirect action place: "this.AddNotification("User registered", NotificationType.INFO);"
	-\Content\Site.css -> .alert {margin-top: 10px;}
	
	---------
Configuration.cs-> Seed()->
		if (!context.Roles.Any())
    {
        var store = new RoleStore<IdentityRole>(context);
        var manager = new RoleManager<IdentityRole>(store);
        var role = new IdentityRole() { Name = "Administrator" };

        manager.Create(role);
    }

    if (!context.Users.Any())
    {
        var store = new UserStore<ApplicationUser>(context);
        var manager = new UserManager<ApplicationUser>(store);
        var user = new ApplicationUser()
        {
            UserName = "admin@admin.com",
            Email = "admin@admin.com",
            PhoneNumber = "+359897564793"
        };

        manager.Create(user, "ASDqwe123_");
        manager.AddToRole(user.Id, "Administrator");
    }
---------
