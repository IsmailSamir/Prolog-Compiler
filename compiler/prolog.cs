
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF         =  0, // (EOF)
        SYMBOL_ERROR       =  1, // (Error)
        SYMBOL_COMMENT     =  2, // Comment
        SYMBOL_WHITESPACE  =  3, // Whitespace
        SYMBOL_PERCENT     =  4, // '%'
        SYMBOL_TIMESDIV    =  5, // '*/'
        SYMBOL_DIVTIMES    =  6, // '/*'
        SYMBOL_MINUS       =  7, // '-'
        SYMBOL_EXCLAM      =  8, // '!'
        SYMBOL_LPAREN      =  9, // '('
        SYMBOL_RPAREN      = 10, // ')'
        SYMBOL_RPARENDOT   = 11, // ').'
        SYMBOL_TIMES       = 12, // '*'
        SYMBOL_COMMA       = 13, // ','
        SYMBOL_DOT         = 14, // '.'
        SYMBOL_DIV         = 15, // '/'
        SYMBOL_COLON       = 16, // ':'
        SYMBOL_COLONMINUS  = 17, // ':-'
        SYMBOL_SEMI        = 18, // ';'
        SYMBOL_PLUS        = 19, // '+'
        SYMBOL_LT          = 20, // '<'
        SYMBOL_LTEQ        = 21, // '<='
        SYMBOL_LTGT        = 22, // '<>'
        SYMBOL_EQ          = 23, // '='
        SYMBOL_GT          = 24, // '>'
        SYMBOL_GTEQ        = 25, // '>='
        SYMBOL_CHAR        = 26, // char
        SYMBOL_CLAUSES     = 27, // clauses
        SYMBOL_DOUBLE      = 28, // double
        SYMBOL_GOAL        = 29, // goal
        SYMBOL_IDENTIFIER  = 30, // Identifier
        SYMBOL_INT         = 31, // Int
        SYMBOL_INTEGER     = 32, // integer
        SYMBOL_NEWLINE     = 33, // NewLine
        SYMBOL_NONDETERM   = 34, // nondeterm
        SYMBOL_PREDICATES  = 35, // predicates
        SYMBOL_PRERULE     = 36, // preRule
        SYMBOL_REAL        = 37, // real
        SYMBOL_REL         = 38, // rel
        SYMBOL_SINGLE      = 39, // single
        SYMBOL_STRING      = 40, // string
        SYMBOL_SYMBOL      = 41, // symbol
        SYMBOL_ADDEXP      = 42, // <Add Exp>
        SYMBOL_CLAUSES2    = 43, // <Clauses>
        SYMBOL_CLURULES    = 44, // <CluRules>
        SYMBOL_COMMAB      = 45, // <commab>
        SYMBOL_COMMAC      = 46, // <commaC>
        SYMBOL_COMMAP      = 47, // <commaP>
        SYMBOL_DATATYPE    = 48, // <datatype>
        SYMBOL_DOB         = 49, // <dob>
        SYMBOL_EXPRESSION  = 50, // <Expression>
        SYMBOL_FACTORRULE  = 51, // <FactOrRule>
        SYMBOL_FIRSTRULE   = 52, // <firstRule>
        SYMBOL_GENERALRULE = 53, // <GeneralRule>
        SYMBOL_GOAL2       = 54, // <Goal>
        SYMBOL_MULTEXP     = 55, // <Mult Exp>
        SYMBOL_NEGATEEXP   = 56, // <Negate Exp>
        SYMBOL_NL          = 57, // <nl>
        SYMBOL_NLOPT       = 58, // <nl Opt>
        SYMBOL_OR          = 59, // <Or>
        SYMBOL_PARAMETERS  = 60, // <Parameters>
        SYMBOL_PREDICATE   = 61, // <Predicate>
        SYMBOL_PRESTAT     = 62, // <prestat>
        SYMBOL_PRO         = 63, // <Pro>
        SYMBOL_RULE        = 64, // <Rule>
        SYMBOL_SING        = 65, // <sing>
        SYMBOL_SWITCH      = 66, // <switch>
        SYMBOL_SWITCHDOT   = 67, // <switch dot>
        SYMBOL_SWITCHBODY  = 68, // <switchbody>
        SYMBOL_VALUE       = 69  // <Value>
    };

    enum RuleConstants : int
    {
        RULE_PRO                             =  0, // <Pro> ::= <nl Opt> <Predicate> <nl Opt> <Clauses> <nl Opt> <Goal> <nl Opt>
        RULE_NL_NEWLINE                      =  1, // <nl> ::= NewLine <nl>
        RULE_NL_NEWLINE2                     =  2, // <nl> ::= NewLine
        RULE_NLOPT_NEWLINE                   =  3, // <nl Opt> ::= NewLine <nl Opt>
        RULE_NLOPT                           =  4, // <nl Opt> ::= 
        RULE_PREDICATE_PREDICATES            =  5, // <Predicate> ::= predicates <nl Opt> <prestat>
        RULE_PRESTAT_NONDETERM               =  6, // <prestat> ::= nondeterm <Rule> <nl> <prestat>
        RULE_PRESTAT                         =  7, // <prestat> ::= <Rule> <nl> <prestat>
        RULE_PRESTAT2                        =  8, // <prestat> ::= 
        RULE_RULE_PRERULE_LPAREN_RPARENDOT   =  9, // <Rule> ::= preRule '(' <datatype> <commaP> ').'
        RULE_RULE_PRERULE_DOT                = 10, // <Rule> ::= preRule '.'
        RULE_DATATYPE_INTEGER                = 11, // <datatype> ::= integer
        RULE_DATATYPE_SYMBOL                 = 12, // <datatype> ::= symbol
        RULE_DATATYPE_STRING                 = 13, // <datatype> ::= string
        RULE_DATATYPE_CHAR                   = 14, // <datatype> ::= char
        RULE_DATATYPE_REAL                   = 15, // <datatype> ::= real
        RULE_COMMAP_COMMA                    = 16, // <commaP> ::= ',' <datatype> <commaP>
        RULE_COMMAP                          = 17, // <commaP> ::= 
        RULE_CLAUSES_CLAUSES                 = 18, // <Clauses> ::= clauses <nl> <FactOrRule>
        RULE_FIRSTRULE_PRERULE_LPAREN_RPAREN = 19, // <firstRule> ::= preRule '(' <switch> <commaC> ')'
        RULE_FIRSTRULE_PRERULE               = 20, // <firstRule> ::= preRule
        RULE_FACTORRULE                      = 21, // <FactOrRule> ::= <GeneralRule> <CluRules> <nl> <FactOrRule>
        RULE_FACTORRULE2                     = 22, // <FactOrRule> ::= 
        RULE_COMMAC_COMMA                    = 23, // <commaC> ::= ',' <nl Opt> <switch> <commaC>
        RULE_COMMAC                          = 24, // <commaC> ::= 
        RULE_CLURULES                        = 25, // <CluRules> ::= <switch dot>
        RULE_CLURULES_COLONMINUS             = 26, // <CluRules> ::= ':-' <switchbody> <commab> <switch dot>
        RULE_SWITCHBODY                      = 27, // <switchbody> ::= <GeneralRule>
        RULE_SWITCHBODY2                     = 28, // <switchbody> ::= <Expression>
        RULE_SWITCHBODY_EXCLAM               = 29, // <switchbody> ::= '!'
        RULE_COMMAB_COMMA                    = 30, // <commab> ::= ',' <nl Opt> <switchbody> <commab>
        RULE_COMMAB_SEMI                     = 31, // <commab> ::= ';' <nl Opt> <switchbody> <commab>
        RULE_COMMAB                          = 32, // <commab> ::= 
        RULE_GENERALRULE_PRERULE_LPAREN      = 33, // <GeneralRule> ::= preRule '(' <switch> <commaC>
        RULE_GENERALRULE                     = 34, // <GeneralRule> ::= <firstRule>
        RULE_PARAMETERS_INT                  = 35, // <Parameters> ::= Int
        RULE_PARAMETERS_SINGLE               = 36, // <Parameters> ::= single <Or> <sing>
        RULE_PARAMETERS_DOUBLE               = 37, // <Parameters> ::= double <Or> <dob>
        RULE_PARAMETERS_REL                  = 38, // <Parameters> ::= rel
        RULE_PARAMETERS_PRERULE              = 39, // <Parameters> ::= preRule
        RULE_SING_SINGLE                     = 40, // <sing> ::= single
        RULE_SING                            = 41, // <sing> ::= 
        RULE_DOB_DOUBLE                      = 42, // <dob> ::= double
        RULE_DOB                             = 43, // <dob> ::= 
        RULE_OR_IDENTIFIER                   = 44, // <Or> ::= Identifier <Or>
        RULE_OR_PRERULE                      = 45, // <Or> ::= preRule <Or>
        RULE_OR_INT                          = 46, // <Or> ::= Int <Or>
        RULE_OR_SINGLE                       = 47, // <Or> ::= single <Or>
        RULE_OR_DOUBLE                       = 48, // <Or> ::= double <Or>
        RULE_OR_MINUS                        = 49, // <Or> ::= '-' <Or>
        RULE_OR_COLON                        = 50, // <Or> ::= ':' <Or>
        RULE_OR                              = 51, // <Or> ::= 
        RULE_SWITCH_IDENTIFIER               = 52, // <switch> ::= Identifier
        RULE_SWITCH                          = 53, // <switch> ::= <Parameters>
        RULE_SWITCHDOT_RPAREN                = 54, // <switch dot> ::= ')'
        RULE_SWITCHDOT_RPARENDOT             = 55, // <switch dot> ::= ').'
        RULE_SWITCHDOT_DOT                   = 56, // <switch dot> ::= '.'
        RULE_EXPRESSION_GT                   = 57, // <Expression> ::= <Expression> '>' <Add Exp>
        RULE_EXPRESSION_LT                   = 58, // <Expression> ::= <Expression> '<' <Add Exp>
        RULE_EXPRESSION_LTEQ                 = 59, // <Expression> ::= <Expression> '<=' <Add Exp>
        RULE_EXPRESSION_GTEQ                 = 60, // <Expression> ::= <Expression> '>=' <Add Exp>
        RULE_EXPRESSION_EQ                   = 61, // <Expression> ::= <Expression> '=' <Add Exp>
        RULE_EXPRESSION_LTGT                 = 62, // <Expression> ::= <Expression> '<>' <Add Exp>
        RULE_EXPRESSION                      = 63, // <Expression> ::= <Add Exp>
        RULE_ADDEXP_PLUS                     = 64, // <Add Exp> ::= <Add Exp> '+' <Mult Exp>
        RULE_ADDEXP_MINUS                    = 65, // <Add Exp> ::= <Add Exp> '-' <Mult Exp>
        RULE_ADDEXP                          = 66, // <Add Exp> ::= <Mult Exp>
        RULE_MULTEXP_TIMES                   = 67, // <Mult Exp> ::= <Mult Exp> '*' <Negate Exp>
        RULE_MULTEXP_DIV                     = 68, // <Mult Exp> ::= <Mult Exp> '/' <Negate Exp>
        RULE_MULTEXP                         = 69, // <Mult Exp> ::= <Negate Exp>
        RULE_NEGATEEXP_MINUS                 = 70, // <Negate Exp> ::= '-' <Value>
        RULE_NEGATEEXP                       = 71, // <Negate Exp> ::= <Value>
        RULE_VALUE_IDENTIFIER                = 72, // <Value> ::= Identifier
        RULE_VALUE_REL                       = 73, // <Value> ::= rel
        RULE_VALUE_INT                       = 74, // <Value> ::= Int
        RULE_VALUE_LPAREN_RPAREN             = 75, // <Value> ::= '(' <Add Exp> ')'
        RULE_GOAL_GOAL                       = 76  // <Goal> ::= goal <nl> <GeneralRule> <switch dot>
    };

    public class MyParser
    {
        private LALRParser parser;
        public string message = "";
        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnReduce += new LALRParser.ReduceHandler(ReduceEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
            parser.OnAccept += new LALRParser.AcceptHandler(AcceptEvent);
            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            parser.Parse(source);

        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
        }

        private Object CreateObject(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMENT :
                //Comment
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESDIV :
                //'*/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIVTIMES :
                //'/*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAM :
                //'!'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPARENDOT :
                //').'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOT :
                //'.'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLONMINUS :
                //':-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTGT :
                //'<>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHAR :
                //char
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLAUSES :
                //clauses
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GOAL :
                //goal
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //Int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGER :
                //integer
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEWLINE :
                //NewLine
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NONDETERM :
                //nondeterm
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PREDICATES :
                //predicates
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRERULE :
                //preRule
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REAL :
                //real
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REL :
                //rel
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SINGLE :
                //single
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SYMBOL :
                //symbol
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDEXP :
                //<Add Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLAUSES2 :
                //<Clauses>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLURULES :
                //<CluRules>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMAB :
                //<commab>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMAC :
                //<commaC>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMAP :
                //<commaP>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATATYPE :
                //<datatype>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOB :
                //<dob>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTORRULE :
                //<FactOrRule>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FIRSTRULE :
                //<firstRule>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GENERALRULE :
                //<GeneralRule>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GOAL2 :
                //<Goal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<Mult Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEGATEEXP :
                //<Negate Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NL :
                //<nl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NLOPT :
                //<nl Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OR :
                //<Or>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETERS :
                //<Parameters>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PREDICATE :
                //<Predicate>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRESTAT :
                //<prestat>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRO :
                //<Pro>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RULE :
                //<Rule>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SING :
                //<sing>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //<switch>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHDOT :
                //<switch dot>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHBODY :
                //<switchbody>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<Value>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        private void ReduceEvent(LALRParser parser, ReduceEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
        }

        public static Object CreateObject(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PRO :
                //<Pro> ::= <nl Opt> <Predicate> <nl Opt> <Clauses> <nl Opt> <Goal> <nl Opt>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NL_NEWLINE :
                //<nl> ::= NewLine <nl>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NL_NEWLINE2 :
                //<nl> ::= NewLine
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NLOPT_NEWLINE :
                //<nl Opt> ::= NewLine <nl Opt>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NLOPT :
                //<nl Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PREDICATE_PREDICATES :
                //<Predicate> ::= predicates <nl Opt> <prestat>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRESTAT_NONDETERM :
                //<prestat> ::= nondeterm <Rule> <nl> <prestat>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRESTAT :
                //<prestat> ::= <Rule> <nl> <prestat>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRESTAT2 :
                //<prestat> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_RULE_PRERULE_LPAREN_RPARENDOT :
                //<Rule> ::= preRule '(' <datatype> <commaP> ').'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_RULE_PRERULE_DOT :
                //<Rule> ::= preRule '.'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_INTEGER :
                //<datatype> ::= integer
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_SYMBOL :
                //<datatype> ::= symbol
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_STRING :
                //<datatype> ::= string
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_CHAR :
                //<datatype> ::= char
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_REAL :
                //<datatype> ::= real
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMMAP_COMMA :
                //<commaP> ::= ',' <datatype> <commaP>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMMAP :
                //<commaP> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLAUSES_CLAUSES :
                //<Clauses> ::= clauses <nl> <FactOrRule>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FIRSTRULE_PRERULE_LPAREN_RPAREN :
                //<firstRule> ::= preRule '(' <switch> <commaC> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FIRSTRULE_PRERULE :
                //<firstRule> ::= preRule
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FACTORRULE :
                //<FactOrRule> ::= <GeneralRule> <CluRules> <nl> <FactOrRule>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FACTORRULE2 :
                //<FactOrRule> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMMAC_COMMA :
                //<commaC> ::= ',' <nl Opt> <switch> <commaC>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMMAC :
                //<commaC> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLURULES :
                //<CluRules> ::= <switch dot>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLURULES_COLONMINUS :
                //<CluRules> ::= ':-' <switchbody> <commab> <switch dot>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHBODY :
                //<switchbody> ::= <GeneralRule>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHBODY2 :
                //<switchbody> ::= <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHBODY_EXCLAM :
                //<switchbody> ::= '!'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMMAB_COMMA :
                //<commab> ::= ',' <nl Opt> <switchbody> <commab>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMMAB_SEMI :
                //<commab> ::= ';' <nl Opt> <switchbody> <commab>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMMAB :
                //<commab> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_GENERALRULE_PRERULE_LPAREN :
                //<GeneralRule> ::= preRule '(' <switch> <commaC>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_GENERALRULE :
                //<GeneralRule> ::= <firstRule>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS_INT :
                //<Parameters> ::= Int
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS_SINGLE :
                //<Parameters> ::= single <Or> <sing>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS_DOUBLE :
                //<Parameters> ::= double <Or> <dob>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS_REL :
                //<Parameters> ::= rel
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS_PRERULE :
                //<Parameters> ::= preRule
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SING_SINGLE :
                //<sing> ::= single
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SING :
                //<sing> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DOB_DOUBLE :
                //<dob> ::= double
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DOB :
                //<dob> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OR_IDENTIFIER :
                //<Or> ::= Identifier <Or>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OR_PRERULE :
                //<Or> ::= preRule <Or>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OR_INT :
                //<Or> ::= Int <Or>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OR_SINGLE :
                //<Or> ::= single <Or>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OR_DOUBLE :
                //<Or> ::= double <Or>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OR_MINUS :
                //<Or> ::= '-' <Or>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OR_COLON :
                //<Or> ::= ':' <Or>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OR :
                //<Or> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCH_IDENTIFIER :
                //<switch> ::= Identifier
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCH :
                //<switch> ::= <Parameters>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHDOT_RPAREN :
                //<switch dot> ::= ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHDOT_RPARENDOT :
                //<switch dot> ::= ').'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHDOT_DOT :
                //<switch dot> ::= '.'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GT :
                //<Expression> ::= <Expression> '>' <Add Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LT :
                //<Expression> ::= <Expression> '<' <Add Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTEQ :
                //<Expression> ::= <Expression> '<=' <Add Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GTEQ :
                //<Expression> ::= <Expression> '>=' <Add Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EQ :
                //<Expression> ::= <Expression> '=' <Add Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTGT :
                //<Expression> ::= <Expression> '<>' <Add Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <Add Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_PLUS :
                //<Add Exp> ::= <Add Exp> '+' <Mult Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_MINUS :
                //<Add Exp> ::= <Add Exp> '-' <Mult Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ADDEXP :
                //<Add Exp> ::= <Mult Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_TIMES :
                //<Mult Exp> ::= <Mult Exp> '*' <Negate Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_DIV :
                //<Mult Exp> ::= <Mult Exp> '/' <Negate Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MULTEXP :
                //<Mult Exp> ::= <Negate Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP_MINUS :
                //<Negate Exp> ::= '-' <Value>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP :
                //<Negate Exp> ::= <Value>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VALUE_IDENTIFIER :
                //<Value> ::= Identifier
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VALUE_REL :
                //<Value> ::= rel
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VALUE_INT :
                //<Value> ::= Int
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VALUE_LPAREN_RPAREN :
                //<Value> ::= '(' <Add Exp> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_GOAL_GOAL :
                //<Goal> ::= goal <nl> <GeneralRule> <switch dot>
                //todo: Create a new object using the stored user objects.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void AcceptEvent(LALRParser parser, AcceptEventArgs args)
        {
            //todo: Use your fully reduced args.Token.UserObject
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
             message =message+ "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            message = message + "Parse error caused by token: " + args.UnexpectedToken.ToString() + "\n" + "in line : " + args.UnexpectedToken.Location.LineNr + "\n";
            //todo: Report message to UI?
            message = message + "expected token : " + args.ExpectedTokens.ToString() + "\n";
        }


    }
}
