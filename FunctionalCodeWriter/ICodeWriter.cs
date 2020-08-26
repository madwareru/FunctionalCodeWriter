namespace FunctionalCodeWriter
{
    /// <summary>
    /// Basic interface used everywhere. It's intentionally is simple by itself so user can provide its own
    /// implementation without much a problem.
    /// </summary>
    public interface ICodeWriter
    {
        string PrintResult();
        void Clear();
        ICodeWriter IncIndent();
        ICodeWriter DecIndent();
        ICodeWriter AddText(string text);
        ICodeWriter AddNewLine();
        ICodeWriter AddIndent();
    }
}