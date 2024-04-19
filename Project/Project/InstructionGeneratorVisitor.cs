using Antlr4.Runtime.Misc;

namespace Project;

public class InstructionGeneratorVisitor : GrammarBaseVisitor<string>
{
    private StreamWriter sw;
    private Dictionary<string, char> identifiers = new Dictionary<string, char>();
    private int labelCounter = 0;

    public void CloseStream()
    {
        sw.Close();
    }

    public override string VisitProgram([NotNull] GrammarParser.ProgramContext context)
    {
        File.Delete("ins.txt");
        this.sw = File.AppendText("ins.txt");
        foreach (var statement in context.statement())
        {
            VisitStatement(statement);
        }

        this.CloseStream();
        
        return null;
    }

    public override string VisitStatement([NotNull] GrammarParser.StatementContext context)
    {
        /* Done */
        if (context.ChildCount == 2 && context.expression() != null && context.SEMI() != null)
        {
            VisitExpression(context.expression()[0]);
        }

        if (context.READ() != null)
        {
            foreach (var identifier in context.IDENTIFIER())
            {
                string i = identifier.GetText();
                sw.WriteLine("read " + this.identifiers[i]);
                sw.WriteLine("save " + i);
            }
        }
        
        if (context.WRITE() != null)
        {
            //FIX
            foreach (var expression in context.expression())
            {
                VisitExpression(expression);
            }
            sw.WriteLine("print " + context.expression().Length);
        }
        /* Done */
        if (context.block() != null)
        {
            VisitBlock(context.block());
        }
        /* Done */
        if (context.declaration() != null)
        {
            VisitDeclaration(context.declaration());
        }
        
        if (context.IF() != null)
        {
            this.VisitExpression(context.expression()[0]);
            int labelOne = this.labelCounter++;
            int labelTwo = this.labelCounter++;
            sw.WriteLine("fjmp " + labelOne);
            VisitStatement(context.statement()[0]);
            sw.WriteLine("jmp " + labelTwo);
            sw.WriteLine("label " + labelOne);
            if (context.ELSE() != null)
                VisitStatement(context.statement()[1]);
            sw.WriteLine("label " + labelTwo);
        }

        if (context.DO() != null)
        {
            throw new NotImplementedException("Do-While loop is not implemented.");
        }

        if (context.WHILE() != null && context.DO() == null)
        {
            int labelOne = this.labelCounter++;
            int labelTwo = this.labelCounter++;
            sw.WriteLine("label " + labelOne);
            this.VisitExpression(context.expression()[0]);
            sw.WriteLine("fjmp " + labelTwo);
            VisitStatement(context.statement()[0]);
            sw.WriteLine("jmp " + labelOne);
            sw.WriteLine("label " + labelTwo);
        }

        return null;
    }

    /* Done */
    public override string VisitDeclaration([NotNull] GrammarParser.DeclarationContext context)
    {
        string typeName = VisitPrimitiveType(context.primitiveType());
        foreach (var identifier in context.IDENTIFIER())
        {
            switch(typeName)
            {
                case "I":
                    sw.WriteLine("push I 0");
                    sw.WriteLine("save " + identifier.GetText());
                    this.identifiers.Add(identifier.GetText(), 'I');
                    break;
                case "F":
                    sw.WriteLine("push F 0.0");
                    sw.WriteLine("save " + identifier.GetText());
                    this.identifiers.Add(identifier.GetText(), 'F');
                    break;
                case "B":
                    sw.WriteLine("push B false");
                    sw.WriteLine("save " + identifier.GetText());
                    this.identifiers.Add(identifier.GetText(), 'B');
                    break;
                case "S":
                    sw.WriteLine("push S \"\"");
                    sw.WriteLine("save " + identifier.GetText());
                    this.identifiers.Add(identifier.GetText(), 'S');
                    break;
            }
        }
        
        return null;
    }

    /* Done */
    public override string VisitBlock([NotNull] GrammarParser.BlockContext context)
    {
        foreach (var statement in context.statement())
        {
            VisitStatement(statement);
        }

        return null;
    }

    public override string VisitExpression([NotNull] GrammarParser.ExpressionContext context)
    {
        /* Done */
        if (context.BOOL() != null)
        {
            sw.WriteLine("push B " + context.BOOL().GetText());
            return "B";
        }
        /* Done */
        if (context.INT() != null)
        {
            sw.WriteLine("push I " + context.INT().GetText());
            return "I";
        }
        /* Done */
        if (context.FLOAT() != null)
        {
            sw.WriteLine("push F " + context.FLOAT().GetText());
            return "F";
        }
        /* Done */
        if (context.STRING_LITERAL() != null)
        {
            sw.WriteLine("push S " + context.STRING_LITERAL().GetText());
            return "S";
        }
        /* Done */
        if (context.IDENTIFIER() != null)
        {
            sw.WriteLine("load " + context.IDENTIFIER().GetText());
            return this.identifiers[context.IDENTIFIER().GetText()].ToString();
        }
        /* Done */
        if (context.MINUS() != null && context.expression().Length == 1)
        {
            string res = this.VisitExpression(context.expression()[0]);
            sw.WriteLine("uminus");
            return res;
        }
        /* Done */
        if (context.NEG() != null)
        {
            this.VisitExpression(context.expression()[0]);
            sw.WriteLine("not");
            return "B";
        }

        if (context.PLUS() != null || context.MINUS() != null)
        {
            string res1 = this.VisitExpression(context.expression()[0]);
            string res2Type = this.CheckOutExpressionType(context.expression()[1]);
            if (res1 == "I" && res2Type == "F")
            {
                sw.WriteLine("itof");
                res1 = "F";
            }
            string res2 = this.VisitExpression(context.expression()[1]);
            if (res1 == "F" && res2 == "I")
            {
                sw.WriteLine("itof");
            }
            if(context.PLUS() != null)
                sw.WriteLine("add " + res1);
            if(context.MINUS() != null)
                sw.WriteLine("sub " + res1);
            return res1;
        }
        
        if (context.DIV() != null || context.MULT() != null)
        {
            string res1 = this.VisitExpression(context.expression()[0]);
            string res2Type = this.CheckOutExpressionType(context.expression()[1]);
            if (res1 == "I" && res2Type == "F")
            {
                sw.WriteLine("itof");
                res1 = "F";
            }
            string res2 = this.VisitExpression(context.expression()[1]);
            if (res1 == "F" && res2 == "I")
            {
                sw.WriteLine("itof");
            }
            if(context.DIV() != null)
                sw.WriteLine("div " + res1);
            if(context.MULT() != null)
                sw.WriteLine("mul " + res1);
            return res1;
        }

        if (context.MOD() != null)
        {
            string res1 = this.VisitExpression(context.expression()[0]);
            string res2 = this.VisitExpression(context.expression()[1]);
            sw.WriteLine("mod");
        }

        if (context.DOT() != null)
        {
            this.VisitExpression(context.expression()[0]);
            this.VisitExpression(context.expression()[1]);
            sw.WriteLine("concat");
        }
        
        if (context.LESS() != null || context.GREATER() != null)
        {
            string res1 = this.VisitExpression(context.expression()[0]);
            string res2Type = this.CheckOutExpressionType(context.expression()[1]);
            if(res1 == "I" && res2Type == "F")
                sw.WriteLine("itof");
            string res2 = this.VisitExpression(context.expression()[1]);
            if (res1 == "F" && res2 == "I")
                sw.WriteLine("itof");
            if(context.LESS() != null)
                sw.WriteLine("lt");
            if(context.GREATER() != null)
                sw.WriteLine("gt");
            return "B";
        }

        if (context.EQ() != null || context.NEQ() != null)
        {
            string res1 = this.VisitExpression(context.expression()[0]);
            string res2Type = this.CheckOutExpressionType(context.expression()[1]);
            if(res1 == "I" && res2Type == "F")
                sw.WriteLine("itof");
            string res2 = this.VisitExpression(context.expression()[1]);
            if (res1 == "F" && res2 == "I")
                sw.WriteLine("itof");
            if(context.EQ() != null)
                sw.WriteLine("eq");
            else if (context.NEQ() != null)
            {
                sw.WriteLine("eq");
                sw.WriteLine("not");
            }
            return "B";
        }
        
        if (context.AND() != null || context.OR() != null)
        {
            string res1 = this.VisitExpression(context.expression()[0]);
            string res2 = this.VisitExpression(context.expression()[1]);
            if(context.AND() != null)
                sw.WriteLine("and");
            if(context.OR() != null)
                sw.WriteLine("or");
            return "B";
        }
        /* Done */
        if (context.ASSIGN() != null)
        {
            string res = this.VisitExpression(context.expression()[1]);
            string identifier;
            //multiple expression
            while (context.expression()[0].IDENTIFIER() == null)
            {
                context = context.expression()[0];
                identifier = context.expression()[1].IDENTIFIER().GetText();
                if(res == "I" && this.identifiers[identifier] == 'F')
                    sw.WriteLine("itof");
                sw.WriteLine("save " + identifier);
                sw.WriteLine("load " + identifier);
                res = this.identifiers[identifier].ToString();
            }

            identifier = context.expression()[0].IDENTIFIER().GetText();
            if(res == "I" && this.identifiers[identifier] == 'F')
                sw.WriteLine("itof");
            sw.WriteLine("save " + identifier);
            sw.WriteLine("load " + identifier);
            sw.WriteLine("pop");
        }
        /* Done */
        if (context.ChildCount == 3 && context.expression().Length == 1)
        {
            return VisitExpression(context.expression(0));
        }
        
        return null;
    }

    /* Done */
    public override string VisitPrimitiveType([NotNull] GrammarParser.PrimitiveTypeContext context)
    {
        string typeName = context.GetText();

        switch(typeName)
        {
            case "int":
                return "I";
            case "float":
                return "F";
            case "bool":
                return "B";
            case "string":
                return "S";
        }
        
        return null;
    }
    
    public string CheckOutExpressionType([NotNull] GrammarParser.ExpressionContext context)
    {
        if (context.BOOL() != null)
            return "S";
        
        if (context.INT() != null)
            return "I";
        
        if (context.FLOAT() != null)
            return "F";
        
        if (context.STRING_LITERAL() != null)
            return "S";

        if (context.IDENTIFIER() != null)
        {
            string identifier = context.IDENTIFIER().GetText();
            
            if(!this.identifiers.ContainsKey(identifier))
            {
                return null;
            }

            if(this.identifiers.ContainsKey(identifier))
                return this.identifiers[identifier] + "";
            return null;
        }

        if (context.MINUS() != null && context.expression().Length == 1)
        {
            string operandType = CheckOutExpressionType(context.expression(0));
            if(operandType != "I" && operandType != "F")
            {
                return null;
            }

            return operandType;
        }

        if (context.NEG() != null)
        {
            String operandType = CheckOutExpressionType(context.expression(0));
            if(operandType != "B")
            {
                return null;
            }

            return "B";
        }

        if (context.PLUS() != null || context.MINUS() != null || context.DIV() != null || context.MULT() != null)
        {
            //INT OR FLOAT
            String leftType = CheckOutExpressionType(context.expression(0));
            String rightType = CheckOutExpressionType(context.expression(1));

            if(leftType == "I" && rightType == "F" || leftType == "F" && rightType == "F")
            {
                return "F";
            }
            
            if (leftType != rightType)
            {
                return null;
            }
            
            if(leftType != "I" && leftType != "F")
            {
                return null;
            }

            return leftType;
        }

        if (context.MOD() != null)
        {
            //INT
            String leftType = CheckOutExpressionType(context.expression(0));
            String rightType = CheckOutExpressionType(context.expression(1));
            
            if(leftType != "I" || rightType != "I")
            {
                return null;
            }

            return "I";
        }

        if (context.DOT() != null)
        {
            //STRING
            String leftType = CheckOutExpressionType(context.expression(0));
            String rightType = CheckOutExpressionType(context.expression(1));
            
            if(leftType != "S" || rightType != "S")
            {
                return null;
            }

            return "S";
        }
        
        if (context.LESS() != null || context.GREATER() != null)
        {
            //INT OR FLOAT
            String leftType = CheckOutExpressionType(context.expression(0));
            String rightType = CheckOutExpressionType(context.expression(1));
            
            if(leftType == "I" && rightType =="F" || leftType == "F" && rightType == "I")
            {
                return "F";
            }
            
            if (leftType != rightType)
            {
                return null;
            }
            
            if(leftType != "I" && leftType != "F")
            {
                return null;
            }

            return "B";
        }

        if (context.EQ() != null || context.NEQ() != null)
        {
            //INT OR FLOAT OR STRING
            string leftType = CheckOutExpressionType(context.expression(0));
            string rightType = CheckOutExpressionType(context.expression(1));
            
            if(leftType == "I" && rightType == "F" || leftType == "F" && rightType == "I")
            {
                return "F";
            }
            
            if(leftType != rightType)
            {
                return null;
            }

            if (leftType != "I" && leftType != "F" && leftType != "S") 
            {
                return null;
            }

            return "B";
        }
        
        if (context.AND() != null || context.OR() != null)
        {
            //BOOL
            string leftType = CheckOutExpressionType(context.expression(0));
            string rightType = CheckOutExpressionType(context.expression(1));
            
            if(leftType != "B" || rightType != "B")
            {
                return null;
            }

            return "B";
        }

        if (context.ASSIGN() != null)
        {
            string leftType = CheckOutExpressionType(context.expression(0));
            string rightType = CheckOutExpressionType(context.expression(1));
            
            if(leftType == "F" && rightType == "I")
            {
                return "F";
            }
            
            if(leftType != rightType)
            {
                return null;
            }

            return leftType;
        }
        
        if (context.ChildCount == 3 && context.expression().Length == 1)
        {
            return CheckOutExpressionType(context.expression(0));
        }
        
        return null;
    }
}