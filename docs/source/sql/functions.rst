SQL Functions
==============


Array functions
----------------

Any_match
**********

*any_match* is a function that allows the caller to check if any element in an array fulfills a certain predicate.

Example:

```
SELECT * FROM test WHERE any_match(arr, x -> x = 'test')
```

