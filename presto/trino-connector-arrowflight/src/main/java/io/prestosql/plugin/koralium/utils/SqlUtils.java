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
        }
        catch (JSQLParserException e) {
            e.printStackTrace();
        }
        SqlFromTableVisitor visitor = new SqlFromTableVisitor();
        visitor.visit(stmt);
        return visitor.getTableName();
    }
}
