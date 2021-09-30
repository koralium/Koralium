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
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="KoraliumParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface IKoraliumParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.parse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParse([NotNull] KoraliumParser.ParseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.parse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParse([NotNull] KoraliumParser.ParseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.statements_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatements_list([NotNull] KoraliumParser.Statements_listContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.statements_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatements_list([NotNull] KoraliumParser.Statements_listContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.sql_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSql_statement([NotNull] KoraliumParser.Sql_statementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.sql_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSql_statement([NotNull] KoraliumParser.Sql_statementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.set_variable_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSet_variable_statement([NotNull] KoraliumParser.Set_variable_statementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.set_variable_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSet_variable_statement([NotNull] KoraliumParser.Set_variable_statementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.set_variable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSet_variable([NotNull] KoraliumParser.Set_variableContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.set_variable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSet_variable([NotNull] KoraliumParser.Set_variableContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.stored_procedure_parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStored_procedure_parameter([NotNull] KoraliumParser.Stored_procedure_parameterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.stored_procedure_parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStored_procedure_parameter([NotNull] KoraliumParser.Stored_procedure_parameterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.stored_procedure_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStored_procedure_statement([NotNull] KoraliumParser.Stored_procedure_statementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.stored_procedure_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStored_procedure_statement([NotNull] KoraliumParser.Stored_procedure_statementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.select_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSelect_statement([NotNull] KoraliumParser.Select_statementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.select_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSelect_statement([NotNull] KoraliumParser.Select_statementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.order_by_clause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOrder_by_clause([NotNull] KoraliumParser.Order_by_clauseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.order_by_clause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOrder_by_clause([NotNull] KoraliumParser.Order_by_clauseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.order_by_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOrder_by_element([NotNull] KoraliumParser.Order_by_elementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.order_by_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOrder_by_element([NotNull] KoraliumParser.Order_by_elementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.having_clause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHaving_clause([NotNull] KoraliumParser.Having_clauseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.having_clause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHaving_clause([NotNull] KoraliumParser.Having_clauseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.from_clause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFrom_clause([NotNull] KoraliumParser.From_clauseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.from_clause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFrom_clause([NotNull] KoraliumParser.From_clauseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.table_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTable_name([NotNull] KoraliumParser.Table_nameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.table_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTable_name([NotNull] KoraliumParser.Table_nameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.subquery"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSubquery([NotNull] KoraliumParser.SubqueryContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.subquery"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSubquery([NotNull] KoraliumParser.SubqueryContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.orderby_subquery"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOrderby_subquery([NotNull] KoraliumParser.Orderby_subqueryContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.orderby_subquery"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOrderby_subquery([NotNull] KoraliumParser.Orderby_subqueryContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.group_subquery"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGroup_subquery([NotNull] KoraliumParser.Group_subqueryContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.group_subquery"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGroup_subquery([NotNull] KoraliumParser.Group_subqueryContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.variable_reference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariable_reference([NotNull] KoraliumParser.Variable_referenceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.variable_reference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariable_reference([NotNull] KoraliumParser.Variable_referenceContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.select_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSelect_expression([NotNull] KoraliumParser.Select_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.select_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSelect_expression([NotNull] KoraliumParser.Select_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.where_clause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhere_clause([NotNull] KoraliumParser.Where_clauseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.where_clause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhere_clause([NotNull] KoraliumParser.Where_clauseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.groupby_clause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGroupby_clause([NotNull] KoraliumParser.Groupby_clauseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.groupby_clause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGroupby_clause([NotNull] KoraliumParser.Groupby_clauseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.groupby_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGroupby_element([NotNull] KoraliumParser.Groupby_elementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.groupby_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGroupby_element([NotNull] KoraliumParser.Groupby_elementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.boolean_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolean_expression([NotNull] KoraliumParser.Boolean_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.boolean_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolean_expression([NotNull] KoraliumParser.Boolean_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.predicate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPredicate([NotNull] KoraliumParser.PredicateContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.predicate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPredicate([NotNull] KoraliumParser.PredicateContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.is_null_predicate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIs_null_predicate([NotNull] KoraliumParser.Is_null_predicateContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.is_null_predicate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIs_null_predicate([NotNull] KoraliumParser.Is_null_predicateContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.search_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSearch_expression([NotNull] KoraliumParser.Search_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.search_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSearch_expression([NotNull] KoraliumParser.Search_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.in_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIn_expression([NotNull] KoraliumParser.In_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.in_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIn_expression([NotNull] KoraliumParser.In_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.like_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLike_expression([NotNull] KoraliumParser.Like_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.like_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLike_expression([NotNull] KoraliumParser.Like_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.in_left_scalar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIn_left_scalar([NotNull] KoraliumParser.In_left_scalarContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.in_left_scalar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIn_left_scalar([NotNull] KoraliumParser.In_left_scalarContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.between_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBetween_expression([NotNull] KoraliumParser.Between_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.between_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBetween_expression([NotNull] KoraliumParser.Between_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.boolean_comparison_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolean_comparison_expression([NotNull] KoraliumParser.Boolean_comparison_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.boolean_comparison_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolean_comparison_expression([NotNull] KoraliumParser.Boolean_comparison_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.boolean_comparison_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolean_comparison_type([NotNull] KoraliumParser.Boolean_comparison_typeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.boolean_comparison_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolean_comparison_type([NotNull] KoraliumParser.Boolean_comparison_typeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.boolean_binary_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolean_binary_type([NotNull] KoraliumParser.Boolean_binary_typeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.boolean_binary_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolean_binary_type([NotNull] KoraliumParser.Boolean_binary_typeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.column_alias"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterColumn_alias([NotNull] KoraliumParser.Column_aliasContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.column_alias"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitColumn_alias([NotNull] KoraliumParser.Column_aliasContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.scalar_expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterScalar_expression2([NotNull] KoraliumParser.Scalar_expression2Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.scalar_expression2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitScalar_expression2([NotNull] KoraliumParser.Scalar_expression2Context context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.scalar_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterScalar_expression([NotNull] KoraliumParser.Scalar_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.scalar_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitScalar_expression([NotNull] KoraliumParser.Scalar_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.error"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterError([NotNull] KoraliumParser.ErrorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.error"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitError([NotNull] KoraliumParser.ErrorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.binary_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBinary_expression([NotNull] KoraliumParser.Binary_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.binary_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBinary_expression([NotNull] KoraliumParser.Binary_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.binary_operation_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBinary_operation_type([NotNull] KoraliumParser.Binary_operation_typeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.binary_operation_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBinary_operation_type([NotNull] KoraliumParser.Binary_operation_typeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.lambda_parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLambda_parameter([NotNull] KoraliumParser.Lambda_parameterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.lambda_parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLambda_parameter([NotNull] KoraliumParser.Lambda_parameterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.lambda_function"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLambda_function([NotNull] KoraliumParser.Lambda_functionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.lambda_function"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLambda_function([NotNull] KoraliumParser.Lambda_functionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.function_parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunction_parameter([NotNull] KoraliumParser.Function_parameterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.function_parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunction_parameter([NotNull] KoraliumParser.Function_parameterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.function_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunction_call([NotNull] KoraliumParser.Function_callContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.function_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunction_call([NotNull] KoraliumParser.Function_callContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.column_reference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterColumn_reference([NotNull] KoraliumParser.Column_referenceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.column_reference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitColumn_reference([NotNull] KoraliumParser.Column_referenceContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.literal_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteral_value([NotNull] KoraliumParser.Literal_valueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.literal_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteral_value([NotNull] KoraliumParser.Literal_valueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.column_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterColumn_name([NotNull] KoraliumParser.Column_nameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.column_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitColumn_name([NotNull] KoraliumParser.Column_nameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.function_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunction_name([NotNull] KoraliumParser.Function_nameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.function_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunction_name([NotNull] KoraliumParser.Function_nameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.table_alias"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTable_alias([NotNull] KoraliumParser.Table_aliasContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.table_alias"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTable_alias([NotNull] KoraliumParser.Table_aliasContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.any_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAny_name([NotNull] KoraliumParser.Any_nameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.any_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAny_name([NotNull] KoraliumParser.Any_nameContext context);
}
