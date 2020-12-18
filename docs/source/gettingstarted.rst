Getting started
================

To set up Koralium in a .Net Core project, the project must be running netcoreapp3.1.

Installation - Apache Arrow Flight
*******************

To install Koralium, download the nuget package "Koralium".

To add support for Apache Arrow Flight, download also:

* Koralium.Transport.ArrowFlight

In your startup.cs file, add the following in *ConfigureServices*.

.. code-block:: csharp

  public void ConfigureServices(IServiceCollection services) 
  {
    services.AddGrpc()
      .AddKoraliumFlightServer();
  ...
    services.AddKoralium(opt =>
    {

    });
  ...
  }

Again in startup.cs, but in the *Configure* method:

.. code-block:: csharp

  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
  ...
    app.UseEndpoints(endpoints =>
    {
        ...
        endpoints.MapKoraliumArrowFlight();
        ...
    });
  ...
  }

This will set up the required services and endpoints required to use Koralium with Apache Arrow Flight, which is the recomended endpoint.

Installation - http/json
*************************

If you also want to support queries over normal http and return json that is possible.

Install the following nuget packages:

* Koralium
* Koralium.Transport.Json

In startup.cs, in the *ConfigureServices* method:

.. code-block:: csharp

  public void ConfigureServices(IServiceCollection services) 
  {
  ...
    services.AddKoralium(opt =>
    {

    });
  ...
  }

In *Configure* add the following in UseEndpoints:

.. code-block:: csharp

  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
  ...
    app.UseEndpoints(endpoints =>
    {
        ...
        endpoints.MapKoraliumJsonPost("sql"); //Map post 
        endpoints.MapKoraliumJsonGet("sql"); //Map get
        ...
    });
  ...
  }

This should then allow the following GET call:

.. code-block::

  http(s)://{your-dns}/sql?query={query}

Adding a table resolver
************************

At this stage we can send in queries, for instance "select * from test", but we will get an error that the table *test* does not exist.
To fix this we need to add a *TableResolver*, that allows an implementation on where the data for a table is collected from.

Before we create the *resolver* though, we need a model class that contains the properties that the table should have.

Example:

.. code-block:: csharp

  public class Test
  {
    public long Id { get; set; }

    public string Name { get; set; }
  }

After that, we create a class called *TestTableResolver* as an example if our table will be called *Test*.

.. code-block:: csharp

  public class TestTableResolver : TableResolver<Test>
  {
       protected override Task<IQueryable<Test>> GetQueryableData()
        {
            return Task.FromResult(new List<Test>()
              {
                    new Test()
                  {
                      Id = 1,
                      Name = "test"
                  }
              }.AsQueryable());
        }
  }

Finally, we need add the following in startup.cs, to register the resolver:

.. code-block:: csharp

  public void ConfigureServices(IServiceCollection services) 
  {
  ...
    services.AddKoralium(opt =>
    {
      ...
      opt.AddTableResolver<TestTableResolver, Test>(opt =>
      {
          opt.TableName = "test";
      });
      ...
    });
  ...
  }

The table resolver is now registered and one can do the following query:

.. code-block:: sql

  select * from test

