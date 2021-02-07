Index support
==============

In many cases the user might send a query similar to:

.. code-block:: sql

  SELECT * FROM test WHERE c1 = 'test'
  SELECT * FROM test WHERE c1 in ('test1', 'test2', 'test3')

In those cases the ID's might be spread out and sending the query down to a relational database might add
alot of additional query time.

To allow the support of faster lookups for those cases it is possible to get out equal filters that must be true
for the query to succeed.

Example:

.. code-block:: csharp

  protected override Task<IQueryable<IndexTest>> GetQueryableData(IQueryOptions<Test> queryOptions, ICustomMetadata customMetadata)
  {
    // Try get any required filters for the property 'Key'
    if (queryOptions.TryGetEqualFiltersForProperty(x => x.Key, out var filters))
    {
      List<Test> output = new List<Test>();
      foreach (var val in filters)
      {
        //Get your object from your cache/database here
        var obj = GetObjectFromCache(val);
        output.Add(obj);
      }
      return Task.FromResult(output.AsQueryable());
    }
    ...
  }

Getting out the filters this way can greatly increase the performance if the data is also stored in for example a Redis Cache.
That allows fast access to specific objects, while also not putting a strain on the query database.