# How to build

To build the presto connector, write the following command:

```
mvn package
```

# Use in IntelliJ

To code in IntelliJ you first have to run the build command

```
mvn package -DskipTests
```

This will generate the gRPC code from the proto file.