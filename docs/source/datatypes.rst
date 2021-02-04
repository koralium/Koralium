Data Types
===========

The supported data types are:

* Boolean
* DateTime
* Double
* Float
* Short (int16)
* Int (int32)
* Long (int64)
* String
* Byte (uint8)
* UInt (uint32)
* ULong (uint64)
* Lists
* Objects
* Byte[] (binary)
* Enums

Enums
------

All enums are represented as strings both in Json and Apache Arrow Flight.
This is done to create a better readability of the value of the enum.

This means that enums are filtered the same way as strings, example:

```
SELECT enumValue FROM test WHERE enumValue = 'Active'
```

This would only select rows that has 'enumValue' set as 'Active'.


