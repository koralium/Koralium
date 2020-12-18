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
package io.prestosql.plugin.koralium;

import org.testcontainers.containers.GenericContainer;

import java.io.Closeable;

import static org.testcontainers.utility.MountableFile.forHostPath;

public class QueryServer
        implements Closeable
{
    private static final int PORT = 5015;

    private GenericContainer<?> dockerContainer;

    public QueryServer() {}

    public void start()
    {
        if (this.dockerContainer == null) {
            this.dockerContainer = new GenericContainer<>("koraliumwebtest")
                    .withExposedPorts(PORT)
                    .withCopyFileToContainer(forHostPath("./tmpData/customer.csv"), "/app/Data/tpch/customer.csv")
                    .withCopyFileToContainer(forHostPath("./tmpData/lineitem.csv"), "/app/Data/tpch/lineitem.csv")
                    .withCopyFileToContainer(forHostPath("./tmpData/nation.csv"), "/app/Data/tpch/nation.csv")
                    .withCopyFileToContainer(forHostPath("./tmpData/orders.csv"), "/app/Data/tpch/orders.csv")
                    .withCopyFileToContainer(forHostPath("./tmpData/part.csv"), "/app/Data/tpch/part.csv")
                    .withCopyFileToContainer(forHostPath("./tmpData/partsupp.csv"), "/app/Data/tpch/partsupp.csv")
                    .withCopyFileToContainer(forHostPath("./tmpData/region.csv"), "/app/Data/tpch/region.csv")
                    .withCopyFileToContainer(forHostPath("./tmpData/supplier.csv"), "/app/Data/tpch/supplier.csv");

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
