//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from ./KoraliumParser.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="KoraliumParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface IKoraliumParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.parse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParse([NotNull] KoraliumParser.ParseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.statements_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatements_list([NotNull] KoraliumParser.Statements_listContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.sql_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSql_statement([NotNull] KoraliumParser.Sql_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.set_variable_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSet_variable_statement([NotNull] KoraliumParser.Set_variable_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.select_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSelect_statement([NotNull] KoraliumParser.Select_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.order_by_clause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrder_by_clause([NotNull] KoraliumParser.Order_by_clauseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.order_by_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrder_by_element([NotNull] KoraliumParser.Order_by_elementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.having_clause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHaving_clause([NotNull] KoraliumParser.Having_clauseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.from_clause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFrom_clause([NotNull] KoraliumParser.From_clauseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.table_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTable_name([NotNull] KoraliumParser.Table_nameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.subquery"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubquery([NotNull] KoraliumParser.SubqueryContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.orderby_subquery"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrderby_subquery([NotNull] KoraliumParser.Orderby_subqueryContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.group_subquery"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGroup_subquery([NotNull] KoraliumParser.Group_subqueryContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.variable_reference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariable_reference([NotNull] KoraliumParser.Variable_referenceContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.select_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSelect_expression([NotNull] KoraliumParser.Select_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.where_clause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhere_clause([NotNull] KoraliumParser.Where_clauseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.groupby_clause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGroupby_clause([NotNull] KoraliumParser.Groupby_clauseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.groupby_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGroupby_element([NotNull] KoraliumParser.Groupby_elementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.boolean_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolean_expression([NotNull] KoraliumParser.Boolean_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.predicate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPredicate([NotNull] KoraliumParser.PredicateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.is_null_predicate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIs_null_predicate([NotNull] KoraliumParser.Is_null_predicateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.search_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSearch_expression([NotNull] KoraliumParser.Search_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.in_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIn_expression([NotNull] KoraliumParser.In_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.like_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLike_expression([NotNull] KoraliumParser.Like_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.in_left_scalar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIn_left_scalar([NotNull] KoraliumParser.In_left_scalarContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.between_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBetween_expression([NotNull] KoraliumParser.Between_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.boolean_comparison_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolean_comparison_expression([NotNull] KoraliumParser.Boolean_comparison_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.boolean_comparison_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolean_comparison_type([NotNull] KoraliumParser.Boolean_comparison_typeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.boolean_binary_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolean_binary_type([NotNull] KoraliumParser.Boolean_binary_typeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.column_alias"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitColumn_alias([NotNull] KoraliumParser.Column_aliasContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.scalar_expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScalar_expression2([NotNull] KoraliumParser.Scalar_expression2Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.scalar_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScalar_expression([NotNull] KoraliumParser.Scalar_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.error"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitError([NotNull] KoraliumParser.ErrorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.binary_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinary_expression([NotNull] KoraliumParser.Binary_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.binary_operation_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinary_operation_type([NotNull] KoraliumParser.Binary_operation_typeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.lambda_function"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLambda_function([NotNull] KoraliumParser.Lambda_functionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.function_parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction_parameter([NotNull] KoraliumParser.Function_parameterContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.function_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction_call([NotNull] KoraliumParser.Function_callContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.column_reference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitColumn_reference([NotNull] KoraliumParser.Column_referenceContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.literal_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteral_value([NotNull] KoraliumParser.Literal_valueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.column_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitColumn_name([NotNull] KoraliumParser.Column_nameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.function_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction_name([NotNull] KoraliumParser.Function_nameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.table_alias"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTable_alias([NotNull] KoraliumParser.Table_aliasContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="KoraliumParser.any_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAny_name([NotNull] KoraliumParser.Any_nameContext context);
}
