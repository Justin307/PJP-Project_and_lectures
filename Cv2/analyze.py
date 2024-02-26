from enum import Enum

class TokenType(Enum):
    DIV = 1
    MOD = 2
    LPAR = 3
    RPAR = 4
    SEMICOLON = 5
    OP = 6
    NUM = 7
    ID = 8
    EOF = 9
    
    
class Token:
    type: TokenType
    value: str
    
    def __init__(self, type, value = "") -> None:
        self.type = type
        self.value = value
        pass
    
    def __str__(self) -> str:
        match self.type:
            case TokenType.DIV:
                return "DIV"
            case TokenType.MOD:
                return "MOD"
            case TokenType.LPAR:
                return "LPAR"
            case TokenType.RPAR:
                return "RPAR"
            case TokenType.SEMICOLON:
                return "SEMICOLON"
            case TokenType.OP:
                return "OP:" + str(self.value)
            case TokenType.NUM:
                return "NUM:" + str(self.value)
            case TokenType.ID:
                return "ID:" + str(self.value)
            case TokenType.EOF:
                return "EOF"
        return "UNKNOWN"


def parse(line: str) -> list[Token]:
    tokens = []
    while len(line) > 0:
        if line[0] == " ":
            line = line[1:]
            continue
        elif line[0] == "(":
            tokens.append(Token(TokenType.LPAR))
            line = line[1:]
            continue
        elif line[0] == ")":
            tokens.append(Token(TokenType.RPAR))
            line = line[1:]
            continue
        elif line[0] == ";":
            tokens.append(Token(TokenType.SEMICOLON))
            line = line[1:]
            continue
        elif line[0] in ["+", "-", "*", "/"]:
            tokens.append(Token(TokenType.OP, line[0]))
            line = line[1:]
            continue
        elif line[0:3] == "div":
            tokens.append(Token(TokenType.DIV))
            line = line[3:]
            continue
        elif line[0:3] == "mod":
            tokens.append(Token(TokenType.MOD))
            line = line[3:]
            continue
        else:
            s = ""
            while len(line) > 0 and line[0]not in [" ", "(", ")", ";", "+", "-", "*", "/"]:
                s += line[0]
                line = line[1:]
            if s.isnumeric():
                tokens.append(Token(TokenType.NUM, s))
            else:
                tokens.append(Token(TokenType.ID, s))
                              
    tokens.append(Token(TokenType.EOF))
    return tokens        

def main():
    line = input()
    if len(line) == 0:
        return None
    comment_index = line.find("//")
    if(comment_index != -1):
        line = line[:comment_index]
    tokens = parse(line)
    for token in tokens:
        print(token.__str__())
        

if __name__ == "__main__":
    main()