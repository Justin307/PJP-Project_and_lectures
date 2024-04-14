grammar Grammar;

// Lexer rules
INT_KEYWORD: 'int';
FLOAT_KEYWORD: 'float';
STRING_KEYWORD: 'string';
BOOL_KEYWORD: 'bool';
READ: 'read';
WRITE: 'write';
IF: 'if';
ELSE: 'else';
WHILE: 'while';
DO: 'do';
SEMI: ';';
COMMA: ',';
DOT: '.';
MULT: '*';
DIV: '/';
MOD: '%';
PLUS: '+';
MINUS: '-';
LESS: '<';
GREATER: '>';
NEG: '!';
ASSIGN: '=';
EQ: '==';
NEQ: '!=';
AND: '&&';
OR: '||';

// Tokens
INT: [0-9]+;
FLOAT: [0-9]+'.'[0-9]+;
BOOL: 'true' | 'false';
STRING_LITERAL: '"' .*? '"';
IDENTIFIER: [a-zA-Z] [a-zA-Z0-9_]*;
WS: [ \t\r\n]+ -> skip;
COMMENT: '/*' .*? '*/' -> skip;
LINE_COMMENT: '//' ~[\r\n]* -> skip;

// Parser rules
program: statement+ EOF;

statement:
    SEMI
    | declaration
    | expression SEMI
    | READ IDENTIFIER (COMMA IDENTIFIER)* SEMI
    | WRITE expression (COMMA expression)* SEMI
    | block
    | IF '(' expression ')' statement (ELSE statement)?
    | WHILE '(' expression ')' statement
    | DO statement WHILE '(' expression ')' SEMI
    ;

declaration:
    primitiveType IDENTIFIER (COMMA IDENTIFIER)* SEMI
    ;

block:
    '{' statement* '}'
    ;

expression:
    BOOL
    | IDENTIFIER
    | INT
    | FLOAT
    | STRING_LITERAL
    | '(' expression ')'
    | MINUS expression
    | NEG expression
    | expression (MULT | DIV | MOD) expression
    | expression (PLUS | MINUS | DOT) expression
    | expression (LESS | GREATER) expression
    | expression (EQ | NEQ) expression
    | expression AND expression
    | expression OR expression
    | expression ASSIGN expression
    ;

primitiveType:
    INT_KEYWORD
    | FLOAT_KEYWORD
    | STRING_KEYWORD
    | BOOL_KEYWORD
    ;