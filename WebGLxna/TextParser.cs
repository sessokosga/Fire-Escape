using Sprache;

namespace WebGLxna;
    public static class TextParser{
        public static readonly Parser<string> Identifier = Parse.Letter.AtLeastOnce().Text().Token();
        public static readonly Parser<string> QuotedText = (
            from open in Parse.Char('"')
            from content in Parse.CharExcept('"').Many().Text()
            from close in Parse.Char('"')
            select content
        ).Token();
    }
