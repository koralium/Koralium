Authorization
==============

*Koralium SQL API* supports *authorization* of different tables. The implementation builds upon and uses *AspNetCore*'s
library for *authorization*.

To add support for authorization, you first need to have AspNetCore authorization set up.

Example:

.. code-block:: csharp

  public void ConfigureServices(IServiceCollection services)
  {
    ...
    services.AddAuthentication(options =>
    {
      ...
    })
    .AddJwtBearer(options =>
    {
      ...
    });
    ...
    services.AddAuthorization(opt =>
    {
      ...
      opt.AddPolicy("policy", o => o.RequireAuthenticatedUser());
      ...
    });
    ...
  }

  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    ...
    app.UseAuthentication();
    app.UseAuthorization();
    ...
  }

When an *Authorization Policy* has been set up, to enforce it you add the *Authorization Attribute* on the
table resolver that you want to apply it to. Example:

.. code-block:: csharp

  [Authorize("policy")]
  public class TestTableResolver : TableResolver<Test>
  {
    ...
  }

Row level security / Field level security
------------------------------------------

When authorization is set up, it is possible to access the *HttpContext* and the current user from the resolver.
This allows filtering of data, based on the current user.

An example where the data is filtered based on the current user:

.. code-block:: csharp

  [Authorize("policyName")]
  public class UserResolver : TableResolver<User>
  {
    private readonly UserContext _userContext;

    public SecureResolver(UserContext userContext)
    {
        _userContext = userContext;
    }

    protected override Task<IQueryable<User>> GetQueryableData()
    {
        var userName = this.HttpContext.User.Identity.Name;
        return _userContext.Data.Where(x => x.Creator == userName);
    }
  }
