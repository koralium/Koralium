Adding new type support
========================

This section describes the steps that are required to add support for a new data type.


Koralium.Transport:

* ColumnType - Add type to enum

Koralium.Core:

* ColumnTypeHelper - Convert type to the enum, add nullable support.

Arrow Flight:

* Add type support in TypeConverter.
* Add encoder class
* EncoderHelper - Resolve encoder.

Json:

* Add new encoder class
* Resolve encoder in EncoderHelper

Presto:

* Add decoder class
* Add type to KoraliumType enum
* Resolve type in PrestoArrowTypeVisitor,

ADO.NET:

* Add decoder class
* Resolve in TypeDecoderVisitor