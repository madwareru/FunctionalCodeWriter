using System.Text;

namespace FunctionalCodeWriter
{
    /// <summary>
    /// Basic implemtnation of ICodeWriter. You can provide your own and use it freely if you want
    /// </summary>
    public class CodeWriter : ICodeWriter
    {
        private const string TABULATION = "    ";
        private readonly StringBuilder _sb;
        private uint _indentCount;

        public CodeWriter()
        {
            _sb = new StringBuilder();
            _indentCount = 0;
        }

        public string PrintResult() => _sb.ToString();
        public ICodeWriter IncIndent()
        {
            ++_indentCount;
            return this;
        }
        
        public ICodeWriter DecIndent()
        {
            if (_indentCount > 0)
            {
                --_indentCount;
            }
            return this;
        }

        public ICodeWriter AddText(string text)
        {
            _sb.Append(text);
            return this;
        }

        public ICodeWriter AddNewLine()
        {
            _sb.Append("\n");
            return this;
        }

        public ICodeWriter AddIndent()
        {
            for(var i = _indentCount; i != 0; --i)
                _sb.Append(TABULATION);
            return this;
        }
    }
}