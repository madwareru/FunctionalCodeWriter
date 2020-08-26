namespace FunctionalCodeWriter
{
    public static class CodeMutatorExt
    {
        public static CodeWriterMutator Entry => i => i;
        public static CodeWriterMutator IncIndent => i => i.IncIndent();
        public static CodeWriterMutator DecIndent => i => i.DecIndent();
        public static CodeWriterMutator AddText(string text = "") => i => i.AddText(text);
        public static CodeWriterMutator AddNewLine => i => i.AddNewLine();
        public static CodeWriterMutator AddIndent => i => i.AddIndent();
        public static CodeWriterMutator AddLine(string line = "") =>
            AddIndent + AddText(line) + AddNewLine;
        public static CodeWriterMutator AddLineWithBracket(string line = "") =>
            AddLine(line) + AddLine("{") + IncIndent;
        public static CodeWriterMutator AddLineWithBracketInline(string line = "") =>
            AddText(line) + AddLine("{") + IncIndent;
        public static CodeWriterMutator CloseBracket(string text = "") => 
            AddLine(text) + DecIndent + AddLine("}");
        
        public static ICodeWriter Do(this ICodeWriter writer, CodeWriterMutator mutator) =>
            mutator(writer);
    }
}