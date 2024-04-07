using Antlr4.Runtime;

namespace Project;

public class VerboseErrorListener : BaseErrorListener
{
    public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
    {
        IList<string> stack = ((Parser)recognizer).GetRuleInvocationStack();
        stack.Reverse();
        
        Console.Error.WriteLine("rule stack: " + String.Join(", ", stack));
        Console.Error.WriteLine("line " + line + ":" + charPositionInLine + " at " + offendingSymbol + ": " + msg);
    }
}