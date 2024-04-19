using System;
using System.Globalization;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            var input = new StreamReader("../../../input.txt");
            AntlrInputStream inputStream = new AntlrInputStream(input);
            GrammarLexer lexer = new GrammarLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(commonTokenStream);
            
            parser.AddErrorListener(new VerboseErrorListener());

            IParseTree tree = parser.program();

            if (parser.NumberOfSyntaxErrors == 0)
            {
                TypeCheckingVisitor visitor = new TypeCheckingVisitor();
                visitor.Visit(tree);
                if(visitor.errors.Count > 0)
                    foreach (var error in visitor.errors)
                    {
                        Console.Error.WriteLine(error);
                    }
                else
                {
                    InstructionGeneratorVisitor generator = new InstructionGeneratorVisitor();
                    generator.Visit(tree);
                    Interpreter interpreter = new Interpreter();
                    interpreter.Interpret("ins.txt");
                }
            }
        }
    }
}