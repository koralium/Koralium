package io.prestosql.plugin.koralium;

import org.testcontainers.containers.GenericContainer;

import java.io.Closeable;

import static org.testcontainers.utility.MountableFile.forHostPath;

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
