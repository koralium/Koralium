/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
package io.trino.plugin.koralium;

import org.testcontainers.containers.GenericContainer;

import java.io.Closeable;

public class RedisServer
        implements Closeable
{
    private static final int PORT = 6379;

    private GenericContainer<?> dockerContainer;

    public RedisServer() {}

    public void start()
    {
        if (this.dockerContainer == null) {
            this.dockerContainer = new GenericContainer<>("redis")
                    .withExposedPorts(PORT);

            dockerContainer.start();
        }
    }

    public String getHost()
    {
        return dockerContainer.getContainerIpAddress();
    }

    public int getPort()
    {
        return dockerContainer.getMappedPort(PORT);
    }

    @Override
    public void close()
    {
        if (this.dockerContainer != null) {
            dockerContainer.close();
        }
    }
}
