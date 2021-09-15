import { Message } from 'apache-arrow'


export function decodeMessage(buf: any) {
  return Message.decode(buf)
}