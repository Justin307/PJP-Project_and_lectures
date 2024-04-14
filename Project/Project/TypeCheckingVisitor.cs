using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Numerics;
using System.Security.Cryptography;
using System.Xml.Xsl;

namespace Project
{
    public class TypeCheckingVisitor : GrammarBaseVisitor<Type>
    {
        private Dictionary<string, Type> symbolTable = new Dictionary<string, Type>();

        public List<string> errors = new List<string>();
        
        public void printSymbolTable()
        {
            foreach (var entry in symbolTable)
            {
                Console.WriteLine($"{entry.Key} : {entry.Value.ToString()}");
            }
        }

        public override Type VisitProgram([NotNull] GrammarParser.ProgramContext context)
        {
            foreach (var statement in context.statement())
            {
                VisitStatement(statement);
            }

            return null;
        }

        public override Type VisitStatement([NotNull] GrammarParser.StatementContext context)
        {
            if (context
                    .ChildCount == 2 && context.expression() != null && context.SEMI() != null)
            {
                return VisitExpression(context.expression(0));
            }

            if (context.READ() != null)
            {
                var temp = context.IDENTIFIER();
                foreach (var identifier in temp)
                {
                    var identName = identifier.GetText();
                    if (!symbolTable.ContainsKey(identName))
                    {
                        errors.Add($"{context.Start.Line}: Variable {identName} not declared");
                    }
                }
            }
            
            if (context.WRITE() != null)
            {
                foreach (var expression in context.expression())
                {
                    VisitExpression(expression);
                }
            }
            
            if (context.block() != null)
            {
                VisitBlock(context.block());
            }
            
            if (context.declaration() != null)
            {
                VisitDeclaration(context.declaration());
            }
            
            if (context.IF() != null)
            {
                Type conditionType = VisitExpression(context.expression(0));
                if (conditionType != typeof(bool))
                {
                    errors.Add(context.Start.Line + ": If condition must be of type bool");
                }

                foreach (var statement in context.statement())
                {
                    VisitStatement(statement);
                }
            }

            if (context.DO() != null)
            {
                Type conditionType = VisitExpression(context.expression(0));
                if (conditionType != typeof(bool))
                {
                    errors.Add(context.Start.Line + ": Do while condition must be of type bool");
                }

                VisitStatement(context.statement(0));
            }

            if (context.WHILE() != null && context.DO() == null)
            {
                Type conditionType = VisitExpression(context.expression(0));
                if (conditionType != typeof(bool))
                {
                    errors.Add(context.Start.Line + ": While condition must be of type bool");
                }

                VisitStatement(context.statement(0));
            }

            return null;
        }

        public override Type VisitDeclaration([NotNull] GrammarParser.DeclarationContext context)
        {
            Type type = Visit(context.primitiveType());
            var temp = context.IDENTIFIER();
            foreach (var identifier in temp)
            {
                string varName = identifier.GetText();
                if (symbolTable.ContainsKey(varName))
                {
                    errors.Add($"{context.Start.Line}: Variable {varName} already declared");
                }
                else
                {
                    symbolTable.Add(varName, type);
                }
            }

            return null;
        }

        public override Type VisitBlock([NotNull] GrammarParser.BlockContext context)
        {
            var temp = context.statement();
            foreach (var statement in temp)
            {
                VisitStatement(statement);
            }

            return null;
        }

        public override Type VisitExpression([NotNull] GrammarParser.ExpressionContext context)
        {
            if (context.BOOL() != null)
                return typeof(bool);
            
            if (context.INT() != null)
                return typeof(int);
            
            if (context.FLOAT() != null)
                return typeof(float);
            
            if (context.STRING_LITERAL() != null)
                return typeof(string);

            if (context.IDENTIFIER() != null)
            {
                string identifier = context.IDENTIFIER().GetText();
                
                if(!symbolTable.ContainsKey(identifier))
                {
                    errors.Add($"{context.Start.Line}: Variable {identifier} not declared");
                }

                if(symbolTable.ContainsKey(identifier))
                    return symbolTable[identifier];
                return null;
            }

            if (context.MINUS() != null && context.expression().Length == 1)
            {
                Type operandType = VisitExpression(context.expression(0));
                if(operandType != typeof(int) && operandType != typeof(float))
                {
                    errors.Add(context.Start.Line + ": Unary minus can only be applied to int or float");
                }

                return operandType;
            }

            if (context.NEG() != null)
            {
                Type operandType = VisitExpression(context.expression(0));
                if(operandType != typeof(bool))
                {
                    errors.Add(context.Start.Line + ": Negation can only be applied to bool");
                }

                return typeof(bool);
            }

            if (context.PLUS() != null || context.MINUS() != null || context.DIV() != null || context.MULT() != null)
            {
                //INT OR FLOAT
                Type leftType = VisitExpression(context.expression(0));
                Type rightType = VisitExpression(context.expression(1));

                if(leftType == typeof(int) && rightType == typeof(float) || leftType == typeof(float) && rightType == typeof(int))
                {
                    return typeof(float);
                }
                
                if (leftType != rightType)
                {
                    errors.Add(context.Start.Line + ": Binary operation can only be applied to operands of the same type");
                }
                
                if(leftType != typeof(int) && leftType != typeof(float))
                {
                    errors.Add(context.Start.Line + ": Binary operation can only be applied to int or float");
                }

                return leftType;
            }

            if (context.MOD() != null)
            {
                //INT
                Type leftType = VisitExpression(context.expression(0));
                Type rightType = VisitExpression(context.expression(1));
                
                if(leftType != typeof(int) || rightType != typeof(int))
                {
                    errors.Add(context.Start.Line + ": Modulo can only be applied to int");
                }

                return typeof(int);
            }

            if (context.DOT() != null)
            {
                //STRING
                Type leftType = VisitExpression(context.expression(0));
                Type rightType = VisitExpression(context.expression(1));
                
                if(leftType != typeof(string) || rightType != typeof(string))
                {
                    errors.Add(context.Start.Line + ": Dot operator can only be applied to string");
                }

                return typeof(string);
            }
            
            if (context.LESS() != null || context.GREATER() != null)
            {
                //INT OR FLOAT
                Type leftType = VisitExpression(context.expression(0));
                Type rightType = VisitExpression(context.expression(1));
                
                if(leftType == typeof(int) && rightType == typeof(float) || leftType == typeof(float) && rightType == typeof(int))
                {
                    return typeof(float);
                }
                
                if (leftType != rightType)
                {
                    errors.Add(context.Start.Line + ": Relation operation can only be applied to operands of the same type");
                }
                
                if(leftType != typeof(int) && leftType != typeof(float))
                {
                    errors.Add(context.Start.Line + ": Relation operation can only be applied to int or float");
                }

                return typeof(bool);
            }

            if (context.EQ() != null || context.NEQ() != null)
            {
                //INT OR FLOAT OR STRING
                Type leftType = VisitExpression(context.expression(0));
                Type rightType = VisitExpression(context.expression(1));
                
                if(leftType == typeof(int) && rightType == typeof(float) || leftType == typeof(float) && rightType == typeof(int))
                {
                    return typeof(float);
                }
                
                if(leftType != rightType)
                {
                    errors.Add(context.Start.Line + ": Relation operation can only be applied to operands of the same type");
                }

                if (leftType != typeof(int) && leftType != typeof(float) && leftType != typeof(string)) 
                {
                    errors.Add(context.Start.Line + ": Binary operation can only be applied to int or float or string");
                }

                return typeof(bool);
            }
            
            if (context.AND() != null || context.OR() != null)
            {
                //BOOL
                Type leftType = VisitExpression(context.expression(0));
                Type rightType = VisitExpression(context.expression(1));
                
                if(leftType != typeof(bool) || rightType != typeof(bool))
                {
                    errors.Add(context.Start.Line + ": Logical operation can only be applied to bool");
                }

                return typeof(bool);
            }

            if (context.ASSIGN() != null)
            {
                Type leftType = VisitExpression(context.expression(0));
                Type rightType = VisitExpression(context.expression(1));
                
                if(leftType == typeof(float) && rightType == typeof(int))
                {
                    return typeof(float);
                }
                
                if(leftType != rightType)
                {
                    errors.Add(context.Start.Line + ": Assignment can only be applied to operands of the same type");
                }

                return leftType;
            }
            
            if (context.ChildCount == 3 && context.expression().Length == 1)
            {
                return VisitExpression(context.expression(0));
            }

            errors.Add(context.Start.Line + " " + context.Start.Column + ": Unsupported expression");

            return null;
        }

        public override Type VisitPrimitiveType([NotNull] GrammarParser.PrimitiveTypeContext context)
        {
            string typeName = context.GetText();
            switch (typeName)
            {
                case "int":
                    return typeof(int);
                case "float":
                    return typeof(float);
                case "string":
                    return typeof(string);
                case "bool":
                    return typeof(bool);
                default:
                    errors.Add(context.Start.Line + ": Unsupported primitive type: " + typeName);
                    break;
            }

            return null;
        }
    }
}