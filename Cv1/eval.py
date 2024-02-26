def infix_to_postfix(infix):
    precedence = {'+':1, '-':1, '*':2, '/':2}
    res = []
    stack = []
    isNum = False
    num = 0
    for i in range(len(infix)):
        char = infix[i]
        
        if char.isdigit():
            if isNum:
                num = num * 10 + int(char)
            else:
                num = int(char)
                isNum = True
        else:
            if isNum:
                res.append(num)
                num = 0
                isNum = False
            if char == '(':
                stack.append(char)
            elif char == ')':
                while stack and stack[-1] != '(':
                    res.append(stack.pop())
                if not stack or stack[-1] != '(':
                    return None
                stack.pop()
            elif char in ['+', '-', '*', '/']:
                if i == 0 or infix[i-1] in ['+', '-', '*', '/', '(']:
                    return None
                while stack and stack[-1] != '(' and precedence[char] <= precedence.get(stack[-1], 0):
                    res.append(stack.pop())
                stack.append(char)
            else:
                return None
    if isNum:
        res.append(num)
    while stack:
        if stack[-1] == '(':
            return None
        res.append(stack.pop())
    return res
            
        
def main():
    num = int(input())
    for i in range(num):
        line = input()
        line  = line.replace(" ", "")
        postfix = infix_to_postfix(line)
        if postfix:
            i = 0
            while(len(postfix) > 1):
                if(postfix[i] in ['+', '-', '*', '/']):
                    a = postfix.pop(i-2)
                    b = postfix.pop(i-2)
                    if postfix[i-2] == '+':
                        postfix[i-2] = a + b
                    elif postfix[i-2] == '-':
                        postfix[i-2] = a - b
                    elif postfix[i-2] == '*':
                        postfix[i-2] = a * b
                    elif postfix[i-2] == '/':
                        if(a == 0):
                            print("ERROR")
                            break
                        postfix[i-2] = a / b
                    i -= 1
                else:
                    i += 1
            print(postfix[0])
        else:
            print("ERROR")

if __name__ == "__main__":
    main()
