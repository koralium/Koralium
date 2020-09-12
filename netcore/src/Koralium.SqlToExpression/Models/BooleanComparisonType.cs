namespace Koralium.SqlToExpression.Models
{
    public enum BooleanComparisonType
    {
        //
        // Summary:
        //     The '=' character, equal to.
        Equals = 0,
        //
        // Summary:
        //     The '>' character, greater than.
        GreaterThan = 1,
        //
        // Summary:
        //     The '<' character, less than.
        LessThan = 2,
        //
        // Summary:
        //     The '>' '=' characters, greater than or equal to.
        GreaterThanOrEqualTo = 3,
        //
        // Summary:
        //     The '<' '=' characters, less than or equal to.
        LessThanOrEqualTo = 4,
        //
        // Summary:
        //     The '<' '>' characters, not equal to.
        NotEqualToBrackets = 5,
        //
        // Summary:
        //     The '!' '=' characters, not equal to.
        NotEqualToExclamation = 6,
        //
        // Summary:
        //     The '!' '<' characters, not less than.
        NotLessThan = 7,
        //
        // Summary:
        //     The '!' '>' characters, not greater than.
        NotGreaterThan = 8,
        //
        // Summary:
        //     The '*' '=' characters, left outer join.
        LeftOuterJoin = 9,
        //
        // Summary:
        //     The '=' '*' characters, right outer join.
        RightOuterJoin = 10
    }
}
