using System;

namespace Minsk.CodeAnalysis.Binding
{

    internal sealed class BoundBinaryExpression : BoundExpression
    {
        public BoundBinaryExpression(BoundExpression left, BoundBinaryOperator op, BoundExpression right)
        {
            Left = left;
            Op = op;
            Right = right;
        }

        public BoundExpression Left { get; }
        public BoundBinaryOperator Op { get; }
        public BoundExpression Right { get; }

        // public override Type Type => Left.Type;    // 1 == 1 && 2 == 2      1==1   返回type 1?? error
        public override Type Type => Op.Type;


        public override BoundNodeKind Kind => BoundNodeKind.BoundBinaryExpression;

    }


}