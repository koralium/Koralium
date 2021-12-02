Parameters
===========

Parameters can be used as regular SQL parameters in queries, such as:

.. code-block:: SQL

  SELECT * FROM orders WHERE orderkey > @p1


Parameters can be sent in, in two different ways:

* HTTP Headers
* SQL statement

HTTP Headers
-------------

Parameters can be sent in using HTTP headers where each parameter is prefixed with 'P_*'

Example:

P_p1: "123"

This would create a sql parameter named p1 and can be used in queries with '@p1'.

In the case of special characters such as 'åäö' it is required to URI encode the parameter.
Example would be that 'å' would be translated to '%C3%A5'.
This is required since http headers only supports ASCII.

SQL Statement
--------------

Sending in a SQL parameter using a SQL statement can be done in the following way:

.. code-block:: SQL

  SET @p1 = 1;
  SELECT * FROM orders WHERE orderkey > @p1;

This would create a parameter named 'p1'.

The example above is susceptible for SQL injection though. To use parameters in a SQL statement without worrying for sql injection,
one can base64 encode the parameter string.

Example:

.. code-block:: SQL

  SET @p1 = b64'MQ==';
  SELECT * FROM orders WHERE orderkey > @p1;

The rules for base64 encoding is the following:

* All characters in the parameter should be converted to utf8.
* Strings encoded should not encode the quotes.
* The base64 encoded string should be prefixed by "b64".

Sending in complex objects as parameters
-----------------------------------------

Parameters can also contain complex objects, with multiple fields, or lists. Complex objects are json encoded.

Example HTTP Header:

p_p1: "{ "test": "hello" }"

When sending in complex objects using SQL statements, it is recomended to use base64 encoded parameters to not use conflicting characters.

Reading parameters in resolvers
--------------------------------

A Parameter can also be used by the resolvers for specific operations, here are some examples of use cases:

* Use a different data source than usual.
* Limiting the returining result based on data not in the returning result.

An example of a resolver reading a parameter:

.. code-block:: csharp

  protected override Task<IQueryable<Order>> GetQueryableData()
  {
    //Check if a parameter named p1 is in the parameters
    if(QueryOptions.Parameters.TryGetParameter("p1", out var parameter))
    {
      //Try to get the parameter as an integer
      if(parameter.TryGetValue<int>(out var parameterValue))
      {
          ...
      }
    }
    ...
  }