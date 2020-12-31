Trino/Presto connector
=======================

The Trino connector allows querying a *Koralium Data Service* using Trino.
This enables joining data and executing more advanced sql queries against the data between different data services.

Settings
----------

+-------------------------------+---------------+-------------------+-----------------------------------------+
| Key                           | Default Value | Required          | Description                             |
+===============================+===============+===================+=========================================+
| koralium.url                  | ""            | Yes               | Url to the Koralium service             |
+-------------------------------+---------------+-------------------+-----------------------------------------+
| koralium.cache.enabled        | false         | No                | Enables in memory caching               |
+-------------------------------+---------------+-------------------+-----------------------------------------+
| koralium.cache.redisUrl       | ""            | If cache enabled  | Url to redis server                     |
+-------------------------------+---------------+-------------------+-----------------------------------------+
| koralium.cache.expireTime     | 60            | No                | Cache entry expiration time in seconds  |
+-------------------------------+---------------+-------------------+-----------------------------------------+
| koralium.cache.maxSizeInBytes | 104857600     | No                | Max size of the cache in bytes          |
+-------------------------------+---------------+-------------------+-----------------------------------------+

Installation
-------------

To install the Trino Connector, copy the compiled jar files into a subdirectory called "koralium" in the plugin folder
on each node in the Trino cluster.

Partitions
------------

Partitions can greatly help increase the performance of sending data to *Trino*, since multiple nodes in the *Trino* cluster
can participate and collect individual partitions for a query.

This enables scaling up the performance of collecting a data set by having multiple *Koralium* data service replicas give out partitions.
Using partitions together with the cache also makes the cache entry on an individual node smaller which can enable using the cache
with queries that might have been too big before to be stored on an individual node. 

Cache
---------------

The Trino connector has a cache solution which has two functions, firstly give better performance on subsequent queries
that uses the same data from the source, but also to reduce the load of the data service.

The cache works by storing the data in-memory in the nodes on the *Trino* cluster up to the *maxSizeInBytes*.
If the *maxSizeInBytes* is reached, it starts switching out data in a least rececently used fashion.

To coordinate and see which nodes has a query in its cache, Redis is used as an outside coordinator. 
The only data that is stored in redis is the query and which node has it in its cache if any.

If an entry has reached its expiration time before its being used, it will be cleared from the cache and the data will be collected
from the data service.