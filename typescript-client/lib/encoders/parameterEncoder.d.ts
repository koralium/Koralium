import { Parameter } from "../generated/koralium_pb";
export default function encodeParameters(parameters: {
    [key: string]: any;
}): Parameter[];
