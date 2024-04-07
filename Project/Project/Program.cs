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
            string input = "write 10;";
            AntlrInputStream inputStream = new AntlrInputStream(input);
            GrammarLexer lexer = new GrammarLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(commonTokenStream);
            
            parser.AddErrorListener(new VerboseErrorListener());

            IParseTree tree = parser.program();

            if (parser.NumberOfSyntaxErrors == 0)
            {
                /*ParseTreeWalker walker = new ParseTreeWalker();
                walker.Walk(new EvalListener(), tree);*/
            }
        }
    }
}