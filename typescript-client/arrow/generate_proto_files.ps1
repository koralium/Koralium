cd protos
protoc-gen-grpc --plugin=protoc-gen-ts=..\node_modules\.bin\protoc-gen-ts.cmd --js_out="import_style=commonjs,binary:../src/generated" --ts_out="service=grpc-node:../src/generated" --grpc_out="../src/generated" Flight.proto
cd ..