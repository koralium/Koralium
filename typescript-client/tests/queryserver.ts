import { GenericContainer, StartedTestContainer, Wait } from "testcontainers"
import path from "path"

export class QueryServer {

  container: StartedTestContainer;

  async start() {
     this.container = await new GenericContainer("koraliumwebtest")
      .withExposedPorts(5015)
      .withBindMount(path.resolve(__dirname, "../../TestData/"), "/app/Data/", "ro")
      .withWaitStrategy(Wait.forLogMessage('Application started. Press Ctrl+C to shut down.'))
      .start();
  }

  async stop() {
    if(this.container != undefined) {
      await this.container.stop();
    }
  }

  getIpAddress() : string {
    return this.container.getContainerIpAddress();
  }

  getPort() : number {    
    return this.container.getMappedPort(5015);
  }
}