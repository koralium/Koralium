Configuration
===============

This section is a work in progress.

Custom column name
-------------------

It is possible to override the column name that is given to a property.
That is done by using the attribute *ColumnName*, example:

.. code-block:: csharp

  [ColumnName("test"]
  public string OtherName { get; set; }

OtherName will now be called "test".

It is also possible to set a default naming policy during configuration:

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
          opt.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
      });
      ...
    });
  ...
  }

The default naming policy is camelCase.

To remove the naming policy simple set *PropertyNamingPolicy = null*.