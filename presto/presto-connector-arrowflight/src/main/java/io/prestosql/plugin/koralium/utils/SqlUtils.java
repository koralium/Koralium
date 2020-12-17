package io.prestosql.plugin.koralium.utils;

import net.sf.jsqlparser.JSQLParserException;
import net.sf.jsqlparser.parser.CCJSqlParserUtil;
import net.sf.jsqlparser.statement.select.Select;

public class SqlUtils
{
    private SqlUtils()
    {
        //NOP
    }

    public static String getTableName(String sql)
    {
        Select stmt = null;
        try {
            stmt = (Select) CCJSqlParserUtil.parse(sql);
        } catch (JSQLParserException e) {
            e.printStackTrace();
        }
        SqlFromTableVisitor visitor = new SqlFromTableVisitor();
        visitor.visit(stmt);
        return visitor.getTableName();
    }
}
