using System.Net.Sockets;
using Microsoft.VisualBasic;

namespace Project;

public class Interpreter
{
    private Dictionary<string, object> variables = new Dictionary<string, object>();
    private Stack<object> memory = new Stack<object>();
    private Dictionary<string, int> labels = new Dictionary<string, int>();

    private void reset()
    {
        this.variables.Clear();
        this.memory.Clear();
        this.labels.Clear();
    }

    public void Interpret(string fileName)
    {
        var code = new List<string[]>();
        using (var reader = new StreamReader(fileName))
        {
            string? line;
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                int spaceIndex = line.IndexOf(' ');
                if(spaceIndex == -1)
                    code.Add(new string[] {line});
                else
                {
                    string[] instruction = { line.Substring(0, spaceIndex), line.Substring(spaceIndex + 1).Trim() };
                    if(instruction[0] == "label")
                        this.labels.Add(instruction[1], i);
                    code.Add(instruction);
                }

                i++;
            }
        }
        for(int i = 0; i < code.Count; i++)
        {
            string[] instruction = code[i];
            switch (instruction[0])
            {
                case "add":
                {
                    object right = this.memory.Pop();
                    object left = this.memory.Pop();
                    if (left is int)
                        this.memory.Push((int)left + (int)right);
                    else
                        this.memory.Push((float)left + (float)right);
                    break;
                }
                case "sub":
                {
                    object right = this.memory.Pop();
                    object left = this.memory.Pop();
                    if (left is int)
                        this.memory.Push((int)left - (int)right);
                    else
                        this.memory.Push((float)left - (float)right);
                    break;
                }
                case "mul":
                {
                    object right = this.memory.Pop();
                    object left = this.memory.Pop();
                    if (left is int)
                        this.memory.Push((int)left * (int)right);
                    else
                        this.memory.Push((float)left * (float)right);
                    break;
                }
                case "div":
                {
                    object right = this.memory.Pop();
                    object left = this.memory.Pop();
                    if (left is int)
                        this.memory.Push((int)left / (int)right);
                    else
                        this.memory.Push((float)left / (float)right);
                    break;
                }
                case "mod":
                {
                    object right = this.memory.Pop();
                    object left = this.memory.Pop();
                    this.memory.Push((int)left % (int)right);
                    break;
                }
                case "uminus":
                {
                    object value = this.memory.Pop();
                    if (value is int)
                        this.memory.Push(-(int)value);
                    else
                        this.memory.Push(-(float)value);
                    break;
                }
                case "concat":
                {
                    object right = this.memory.Pop();
                    object left = this.memory.Pop();
                    this.memory.Push((string)left + (string)right);
                    break;
                }
                case "and":
                {
                    object left = this.memory.Pop();
                    object right = this.memory.Pop();
                    this.memory.Push((bool)left && (bool)right);
                    break;
                }
                case "or":
                {
                    object left = this.memory.Pop();
                    object right = this.memory.Pop();
                    this.memory.Push((bool)left || (bool)right);
                    break;
                }
                case "gt":
                {
                    object right = this.memory.Pop();
                    object left = this.memory.Pop();
                    if(left is int)
                        this.memory.Push((int)left > (int)right);
                    else
                        this.memory.Push((float)left > (float)right);
                    break;
                }
                case "lt":
                {
                    object right = this.memory.Pop();
                    object left = this.memory.Pop();
                    if(left is int)
                        this.memory.Push((int)left < (int)right);
                    else
                        this.memory.Push((float)left < (float)right);
                    break;
                }
                case "eq":
                {
                    object left = this.memory.Pop();
                    object right = this.memory.Pop();
                    if(left is int)
                        this.memory.Push((int)left == (int)right);
                    else if(left is float)
                        this.memory.Push((float)left == (float)right);
                    else 
                        this.memory.Push((string)left == (string)right);
                    break;
                }
                case "not":
                {
                    object value = this.memory.Pop();
                    this.memory.Push(!(bool)value);
                    break;
                }
                case "itof":
                {
                    object value = this.memory.Pop();
                    this.memory.Push((float)(int)value);
                    break;
                }
                case "push":
                {
                    char type = instruction[1][0];
                    string value = instruction[1].Substring(2);
                    switch(type)
                    {
                        case 'I':
                            this.memory.Push(int.Parse(value));
                            break;
                        case 'F':
                            this.memory.Push(float.Parse(value));
                            break;
                        case 'S':
                        {
                            this.memory.Push(value.Trim('"'));
                            break;
                        }
                        case 'B':
                            this.memory.Push(bool.Parse(value));
                            break;
                    }
                    break;
                }
                case "pop":
                {
                    this.memory.Pop();
                    break;
                }
                case "load":
                {
                    this.memory.Push(this.variables[instruction[1]]);
                    break;
                }
                case "save":
                {
                    this.variables[instruction[1]] = this.memory.Pop();
                    break;
                }
                case "label":
                {
                    this.labels[instruction[1]] = i+1;
                    break;
                }
                case "jmp":
                {
                    i = this.labels[instruction[1]] - 1;
                    break;
                }
                case "fjmp":
                {
                    object value = this.memory.Pop();
                    if (!(bool)value)
                    {
                        i = this.labels[instruction[1]] - 1;
                    }
                    break;
                }
                case "print":
                {
                    string res = "";
                    for (int j = 0; j < int.Parse(instruction[1]); j++)
                    {
                        object value = this.memory.Pop();
                        if (value is int)
                        {
                            res = (int)value + res;
                        }
                        else if (value is float)
                        {
                            res = (float)value + res;
                        }
                        else if (value is string)
                        {
                            res = (string)value + res;
                        }
                        else if (value is bool)
                        {
                            res = (bool)value + res;
                        }
                    }
                    Console.WriteLine(res);
                    break;
                }
                case "read":
                {
                    switch(instruction[1])
                    {
                        case "I":
                            this.memory.Push(int.Parse(Console.ReadLine()));
                            break;
                        case "F":
                            this.memory.Push(float.Parse(Console.ReadLine()));
                            break;
                        case "S":
                            this.memory.Push(Console.ReadLine());
                            break;
                        case "B":
                            this.memory.Push(bool.Parse(Console.ReadLine()));
                            break;
                    }
                    break;
                }
            }
        }

    }
}