Joins
======

Join operations are not supported in *Koralium SQL API*.

This choice was taken early in development since supporting joins can hinder future features, such as distrubuted partitions etc.
If you want to join data between data sources, it is instead recommended to use a federated query engine such as *PrestoSQL*.

*Koralium* supports returning arrays and objects in the result for each entry, so the data should instead be presented in that manner.
