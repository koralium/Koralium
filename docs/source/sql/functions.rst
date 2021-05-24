SQL Functions
==============


Array functions
----------------

Any_match
**********

*any_match* is a function that allows the caller to check if any element in an array fulfills a certain predicate.

Example:

.. code-block:: sql

  SELECT * FROM test WHERE any_match(arr, x -> x = 'test')

Filter
*******

*filter* is a function that takes in an array and returns all elements that fulfills a certain predicate.

Example:

.. code-block:: sql

  SELECT filter(arr, x -> x = 'test') FROM test

First
******

*first* returns the first element in an array.

Example:

.. code-block:: sql

  SELECT first(arr) FROM test

It is also possible to add a predicate as the second argument.

.. code-block:: sql

  SELECT first(arr, x -> x = 'test') FROM test

