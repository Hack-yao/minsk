namespace Minsk.CodeAnalysis
{
    internal static class SyntaxFacts
    {
        public static int GetBinaryOperatorPrecedence(this SyntaxKind kind)  // extension method for SyntaxKind
        {
            switch (kind)
            {
                case SyntaxKind.PlusToken:
                case SyntaxKind.MinusToken:
                    return 1;
                case SyntaxKind.StarToken:
                case SyntaxKind.SlashToken:
                    return 2;
                default:
                    return 0; // is not a binary operator
            }
        }
        public static int GetUnaryOperatorPrecedence(this SyntaxKind kind)  // extension method for SyntaxKind
        {
            switch (kind)
            {
                case SyntaxKind.PlusToken:
                case SyntaxKind.MinusToken:
                    return 3;
                default:
                    return 0; // is not a unary operator
            }
        }
    }

}