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
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IKoraliumParserListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class KoraliumParserBaseListener : IKoraliumParserListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.parse"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParse([NotNull] KoraliumParser.ParseContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.parse"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParse([NotNull] KoraliumParser.ParseContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.statements_list"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatements_list([NotNull] KoraliumParser.Statements_listContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.statements_list"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatements_list([NotNull] KoraliumParser.Statements_listContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.sql_statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSql_statement([NotNull] KoraliumParser.Sql_statementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.sql_statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSql_statement([NotNull] KoraliumParser.Sql_statementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.set_variable_statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSet_variable_statement([NotNull] KoraliumParser.Set_variable_statementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.set_variable_statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSet_variable_statement([NotNull] KoraliumParser.Set_variable_statementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.select_statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSelect_statement([NotNull] KoraliumParser.Select_statementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.select_statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSelect_statement([NotNull] KoraliumParser.Select_statementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.order_by_clause"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOrder_by_clause([NotNull] KoraliumParser.Order_by_clauseContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.order_by_clause"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOrder_by_clause([NotNull] KoraliumParser.Order_by_clauseContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.order_by_element"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOrder_by_element([NotNull] KoraliumParser.Order_by_elementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.order_by_element"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOrder_by_element([NotNull] KoraliumParser.Order_by_elementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.having_clause"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterHaving_clause([NotNull] KoraliumParser.Having_clauseContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.having_clause"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitHaving_clause([NotNull] KoraliumParser.Having_clauseContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.from_clause"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFrom_clause([NotNull] KoraliumParser.From_clauseContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.from_clause"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFrom_clause([NotNull] KoraliumParser.From_clauseContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.table_name"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTable_name([NotNull] KoraliumParser.Table_nameContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.table_name"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTable_name([NotNull] KoraliumParser.Table_nameContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.subquery"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSubquery([NotNull] KoraliumParser.SubqueryContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.subquery"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSubquery([NotNull] KoraliumParser.SubqueryContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.orderby_subquery"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOrderby_subquery([NotNull] KoraliumParser.Orderby_subqueryContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.orderby_subquery"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOrderby_subquery([NotNull] KoraliumParser.Orderby_subqueryContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.group_subquery"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterGroup_subquery([NotNull] KoraliumParser.Group_subqueryContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.group_subquery"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitGroup_subquery([NotNull] KoraliumParser.Group_subqueryContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.variable_reference"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVariable_reference([NotNull] KoraliumParser.Variable_referenceContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.variable_reference"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVariable_reference([NotNull] KoraliumParser.Variable_referenceContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.select_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSelect_expression([NotNull] KoraliumParser.Select_expressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.select_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSelect_expression([NotNull] KoraliumParser.Select_expressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.where_clause"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterWhere_clause([NotNull] KoraliumParser.Where_clauseContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.where_clause"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitWhere_clause([NotNull] KoraliumParser.Where_clauseContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.groupby_clause"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterGroupby_clause([NotNull] KoraliumParser.Groupby_clauseContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.groupby_clause"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitGroupby_clause([NotNull] KoraliumParser.Groupby_clauseContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.groupby_element"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterGroupby_element([NotNull] KoraliumParser.Groupby_elementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.groupby_element"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitGroupby_element([NotNull] KoraliumParser.Groupby_elementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.boolean_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBoolean_expression([NotNull] KoraliumParser.Boolean_expressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.boolean_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBoolean_expression([NotNull] KoraliumParser.Boolean_expressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.predicate"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPredicate([NotNull] KoraliumParser.PredicateContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.predicate"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPredicate([NotNull] KoraliumParser.PredicateContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.is_null_predicate"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIs_null_predicate([NotNull] KoraliumParser.Is_null_predicateContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.is_null_predicate"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIs_null_predicate([NotNull] KoraliumParser.Is_null_predicateContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.search_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSearch_expression([NotNull] KoraliumParser.Search_expressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.search_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSearch_expression([NotNull] KoraliumParser.Search_expressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.in_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIn_expression([NotNull] KoraliumParser.In_expressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.in_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIn_expression([NotNull] KoraliumParser.In_expressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.like_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLike_expression([NotNull] KoraliumParser.Like_expressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.like_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLike_expression([NotNull] KoraliumParser.Like_expressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.in_left_scalar"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIn_left_scalar([NotNull] KoraliumParser.In_left_scalarContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.in_left_scalar"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIn_left_scalar([NotNull] KoraliumParser.In_left_scalarContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.between_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBetween_expression([NotNull] KoraliumParser.Between_expressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.between_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBetween_expression([NotNull] KoraliumParser.Between_expressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.boolean_comparison_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBoolean_comparison_expression([NotNull] KoraliumParser.Boolean_comparison_expressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.boolean_comparison_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBoolean_comparison_expression([NotNull] KoraliumParser.Boolean_comparison_expressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.boolean_comparison_type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBoolean_comparison_type([NotNull] KoraliumParser.Boolean_comparison_typeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.boolean_comparison_type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBoolean_comparison_type([NotNull] KoraliumParser.Boolean_comparison_typeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.boolean_binary_type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBoolean_binary_type([NotNull] KoraliumParser.Boolean_binary_typeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.boolean_binary_type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBoolean_binary_type([NotNull] KoraliumParser.Boolean_binary_typeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.column_alias"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterColumn_alias([NotNull] KoraliumParser.Column_aliasContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.column_alias"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitColumn_alias([NotNull] KoraliumParser.Column_aliasContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.scalar_expression2"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterScalar_expression2([NotNull] KoraliumParser.Scalar_expression2Context context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.scalar_expression2"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitScalar_expression2([NotNull] KoraliumParser.Scalar_expression2Context context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.scalar_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterScalar_expression([NotNull] KoraliumParser.Scalar_expressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.scalar_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitScalar_expression([NotNull] KoraliumParser.Scalar_expressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.error"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterError([NotNull] KoraliumParser.ErrorContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.error"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitError([NotNull] KoraliumParser.ErrorContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.binary_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBinary_expression([NotNull] KoraliumParser.Binary_expressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.binary_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBinary_expression([NotNull] KoraliumParser.Binary_expressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.binary_operation_type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBinary_operation_type([NotNull] KoraliumParser.Binary_operation_typeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.binary_operation_type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBinary_operation_type([NotNull] KoraliumParser.Binary_operation_typeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.lambda_parameter"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLambda_parameter([NotNull] KoraliumParser.Lambda_parameterContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.lambda_parameter"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLambda_parameter([NotNull] KoraliumParser.Lambda_parameterContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.lambda_function"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLambda_function([NotNull] KoraliumParser.Lambda_functionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.lambda_function"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLambda_function([NotNull] KoraliumParser.Lambda_functionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.function_parameter"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunction_parameter([NotNull] KoraliumParser.Function_parameterContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.function_parameter"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunction_parameter([NotNull] KoraliumParser.Function_parameterContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.function_call"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunction_call([NotNull] KoraliumParser.Function_callContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.function_call"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunction_call([NotNull] KoraliumParser.Function_callContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.column_reference"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterColumn_reference([NotNull] KoraliumParser.Column_referenceContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.column_reference"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitColumn_reference([NotNull] KoraliumParser.Column_referenceContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.literal_value"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLiteral_value([NotNull] KoraliumParser.Literal_valueContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.literal_value"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLiteral_value([NotNull] KoraliumParser.Literal_valueContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.column_name"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterColumn_name([NotNull] KoraliumParser.Column_nameContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.column_name"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitColumn_name([NotNull] KoraliumParser.Column_nameContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.function_name"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunction_name([NotNull] KoraliumParser.Function_nameContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.function_name"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunction_name([NotNull] KoraliumParser.Function_nameContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.table_alias"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTable_alias([NotNull] KoraliumParser.Table_aliasContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.table_alias"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTable_alias([NotNull] KoraliumParser.Table_aliasContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="KoraliumParser.any_name"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAny_name([NotNull] KoraliumParser.Any_nameContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="KoraliumParser.any_name"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAny_name([NotNull] KoraliumParser.Any_nameContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
