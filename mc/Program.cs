﻿using System;
using System.Linq;
using Minsk.CodeAnalysis;

namespace Minsk
{
    /*
        1 + 2 * 3

          +
         /  \
        1    *
            / \
             2  3

    */
    internal static class Program
    {
        private static void Main()
        {
            var showTree = false;
            while (true)
            {
                Console.Write("> ");
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    return;
                }

                if (line == "#showTree")
                {
                    showTree = !showTree;
                    Console.WriteLine(showTree ? "Showing parse trees" : "Not showing parse trees");
                    continue;
                }
                else if (line == "#cls")
                {
                    Console.Clear();
                    continue;
                }

                var syntaxTree = SyntaxTree.Parse(line);

                if (showTree)
                {
                    // var color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    PrettyPrint(syntaxTree.Root);
                    // Console.ForegroundColor = color;
                    Console.ResetColor();
                }

                if (!syntaxTree.Diagnostics.Any())
                {
                    Evaluator evaluator = new Evaluator(syntaxTree.Root);
                    var result = evaluator.Evaluate();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    foreach (var diag in syntaxTree.Diagnostics)
                    {
                        Console.WriteLine(diag);
                    }
                    Console.ResetColor();
                }
            }
        }

        static void PrettyPrint(SyntaxNode node, string indent = "", bool isLast = true)
        {

            // └──
            // ├──
            //  │
            var marker = isLast ? "└──" : "├──";

            Console.Write(indent);
            Console.Write(marker);
            Console.Write(node.Kind);

            if (node is SyntaxToken t && t.Value != null)
            {
                Console.Write(" ");
                Console.Write(t.Value);
            }
            Console.WriteLine();

            indent += isLast ?  "   " : "│  ";
            var lastChild = node.GetChildren().LastOrDefault();
            foreach (var child in node.GetChildren())
            {
                PrettyPrint(child, indent, child == lastChild);
            }
        }
    }

}
