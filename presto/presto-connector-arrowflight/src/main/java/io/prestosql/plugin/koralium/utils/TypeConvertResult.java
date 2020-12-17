package io.prestosql.plugin.koralium.utils;

import io.prestosql.plugin.koralium.KoraliumType;
import io.prestosql.spi.type.Type;

public class TypeConvertResult
{
    private final Type prestoType;
    private final KoraliumType koraliumType;

    public TypeConvertResult(Type prestoType, KoraliumType koraliumType)
    {
        this.prestoType = prestoType;
        this.koraliumType = koraliumType;
    }

    public Type getPrestoType()
    {
        return prestoType;
    }

    public KoraliumType getKoraliumType()
    {
        return koraliumType;
    }
}
