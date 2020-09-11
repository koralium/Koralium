cd protos
protoc-gen-grpc --plugin=protoc-gen-ts=..\node_modules\.bin\protoc-gen-ts.cmd --js_out="import_style=commonjs,binary:../generated" --ts_out="service=grpc-node:../generated" --grpc_out="../generated" koralium.proto
cd ..