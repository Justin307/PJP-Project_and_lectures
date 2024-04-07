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
IDENTIFIER: [a-zA-Z] [a-zA-Z0-9_]*;
INT: [0-9]+;
FLOAT: [0-9]+'.'[0-9]+;
BOOL: 'true' | 'false';
STRING_LITERAL: '"' .*? '"';
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
    | expression (PLUS | MINUS | DIV | MULT | MOD | AND | OR | LESS | GREATER | EQ | NEQ | ASSIGN | DOT) expression
    | NEG expression
    | typeCast
    ;

primitiveType:
    INT_KEYWORD
    | FLOAT_KEYWORD
    | STRING_KEYWORD
    | BOOL_KEYWORD
    ;

typeCast:
    '(' primitiveType ')' expression
    ;
