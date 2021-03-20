In Memory Data
===============

In some cases the data might not come from a database with entity framework core, or elasticsearch, etc.
When the data is in memory, some operations might not work as expected as when the data comes from a database, such as:

* String comparisons is case insensitive in a database but not in memory
* Selecting object sub fields will throw null exceptions.

To fix this it is possible to mark a table as being in memory:

.. code-block:: csharp

  opt.AddTableResolver<TestResolver, Test>(o =>
  {
    //Mark that this table uses data stored in memory
    o.UseInMemoryOperations();
  });


This will then add a new operations provider that is suitable to handle in memory operations to still have case insensitive string comparisons and not throwing null exceptions.
