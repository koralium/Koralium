package io.prestosql.plugin.koralium.utils;

import net.sf.jsqlparser.expression.Expression;
import net.sf.jsqlparser.schema.Table;
import net.sf.jsqlparser.statement.*;
import net.sf.jsqlparser.statement.alter.Alter;
import net.sf.jsqlparser.statement.alter.sequence.AlterSequence;
import net.sf.jsqlparser.statement.comment.Comment;
import net.sf.jsqlparser.statement.create.index.CreateIndex;
import net.sf.jsqlparser.statement.create.schema.CreateSchema;
import net.sf.jsqlparser.statement.create.sequence.CreateSequence;
import net.sf.jsqlparser.statement.create.table.CreateTable;
import net.sf.jsqlparser.statement.create.view.AlterView;
import net.sf.jsqlparser.statement.create.view.CreateView;
import net.sf.jsqlparser.statement.delete.Delete;
import net.sf.jsqlparser.statement.drop.Drop;
import net.sf.jsqlparser.statement.execute.Execute;
import net.sf.jsqlparser.statement.grant.Grant;
import net.sf.jsqlparser.statement.insert.Insert;
import net.sf.jsqlparser.statement.merge.Merge;
import net.sf.jsqlparser.statement.replace.Replace;
import net.sf.jsqlparser.statement.select.*;
import net.sf.jsqlparser.statement.truncate.Truncate;
import net.sf.jsqlparser.statement.update.Update;
import net.sf.jsqlparser.statement.upsert.Upsert;
import net.sf.jsqlparser.statement.values.ValuesStatement;

public class SqlFromTableVisitor implements FromItemVisitor, SelectVisitor, StatementVisitor {

    private String tableName;

    public String getTableName()
    {
        return tableName;
    }

    @Override
    public void visit(Table table)
    {
        tableName = table.getName();
    }

    @Override
    public void visit(SubSelect subSelect)
    {
        if (subSelect.getWithItemsList() != null) {
            for (WithItem withItem : subSelect.getWithItemsList()) {
                withItem.accept(this);
            }
        }
        subSelect.getSelectBody().accept(this);
    }

    @Override
    public void visit(SubJoin subJoin)
    {
        subJoin.getLeft().accept(this);
        for (Join join : subJoin.getJoinList()) {
            join.getRightItem().accept(this);
        }
    }

    @Override
    public void visit(LateralSubSelect lateralSubSelect)
    {
        lateralSubSelect.getSubSelect().getSelectBody().accept(this);
    }

    @Override
    public void visit(ValuesList valuesList)
    {
        //NOP
    }

    @Override
    public void visit(TableFunction tableFunction)
    {
        //NOP
    }

    @Override
    public void visit(ParenthesisFromItem parenthesisFromItem)
    {
        parenthesisFromItem.getFromItem().accept(this);
    }

    @Override
    public void visit(PlainSelect plainSelect)
    {
        if (plainSelect.getFromItem() != null) {
            plainSelect.getFromItem().accept(this);
        }
    }

    @Override
    public void visit(SetOperationList setOperationList)
    {
        for (SelectBody plainSelect : setOperationList.getSelects()) {
            plainSelect.accept(this);
        }
    }

    @Override
    public void visit(WithItem withItem)
    {
        withItem.getSelectBody().accept(this);
    }

    @Override
    public void visit(Comment comment)
    {
        //NOP
    }

    @Override
    public void visit(Commit commit)
    {
        //NOP
    }

    @Override
    public void visit(Delete delete)
    {
        //NOP
    }

    @Override
    public void visit(Update update)
    {
        //NOP
    }

    @Override
    public void visit(Insert insert)
    {
        //NOP
    }

    @Override
    public void visit(Replace replace)
    {
        //NOP
    }

    @Override
    public void visit(Drop drop)
    {
        //NOP
    }

    @Override
    public void visit(Truncate truncate)
    {
        //NOP
    }

    @Override
    public void visit(CreateIndex createIndex)
    {
        //NOP
    }

    @Override
    public void visit(CreateSchema createSchema)
    {
        //NOP
    }

    @Override
    public void visit(CreateTable createTable)
    {
        //NOP
    }

    @Override
    public void visit(CreateView createView)
    {
        //BOP
    }

    @Override
    public void visit(AlterView alterView)
    {
        //NOP
    }

    @Override
    public void visit(Alter alter)
    {
        //NOP
    }

    @Override
    public void visit(Statements statements)
    {
        //NOP
    }

    @Override
    public void visit(Execute execute)
    {
        //NOP
    }

    @Override
    public void visit(SetStatement setStatement)
    {
        //NOP
    }

    @Override
    public void visit(ShowColumnsStatement showColumnsStatement)
    {
        //NOP
    }

    @Override
    public void visit(Merge merge)
    {
        //NOP
    }

    @Override
    public void visit(Select select)
    {
        if (select.getWithItemsList() != null) {
            for (WithItem withItem : select.getWithItemsList()) {
                withItem.accept(this);
            }
        }
        select.getSelectBody().accept(this);
    }

    @Override
    public void visit(Upsert upsert)
    {
        //NOP
    }

    @Override
    public void visit(UseStatement useStatement)
    {
        //NOP
    }

    @Override
    public void visit(Block block)
    {
        if (block.getStatements() != null) {
            visit(block.getStatements());
        }
    }

    @Override
    public void visit(ValuesStatement valuesStatement)
    {
        //NOP
    }

    @Override
    public void visit(DescribeStatement describeStatement)
    {
        //NOP
    }

    @Override
    public void visit(ExplainStatement explainStatement)
    {
        //NOP
    }

    @Override
    public void visit(ShowStatement showStatement)
    {
        //NOP
    }

    @Override
    public void visit(DeclareStatement declareStatement)
    {
        //NOP
    }

    @Override
    public void visit(Grant grant)
    {
        //NOP
    }

    @Override
    public void visit(CreateSequence createSequence)
    {
        //NOP
    }

    @Override
    public void visit(AlterSequence alterSequence)
    {
        //NOP
    }

    @Override
    public void visit(CreateFunctionalStatement createFunctionalStatement)
    {
        //NOP
    }
}
