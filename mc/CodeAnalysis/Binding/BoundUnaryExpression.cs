using System;

namespace Minsk.CodeAnalysis.Binding
{
    internal sealed class BoundUnaryExpression : BoundExpression
    {
        public BoundUnaryExpression(BoundUnaryOperator op, BoundExpression operand)
        {
            Op = op;
            Operand = operand;
        }

        public override Type Type => Operand.Type;
        public override BoundNodeKind Kind => BoundNodeKind.BoundUnaryExpression;
        public BoundUnaryOperator Op { get; }
        public BoundExpression Operand { get; }
    }


}