import { Parameter } from "../generated/koralium_pb";
import encodeScalar from "./scalarEncoder";

export default function encodeParameters(parameters: {}) {
  
  const output: Array<Parameter> = [];
  
  for (let [key] of Object.entries(parameters)) {
    const parameter = new Parameter();
    parameter.setName(key);
    parameter.setValue(encodeScalar(parameters[key]));
    output.push(parameter);
  }

  return output;
}