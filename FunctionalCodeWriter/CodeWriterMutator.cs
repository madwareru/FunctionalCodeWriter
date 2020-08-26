namespace FunctionalCodeWriter
{
    /// <summary>
    /// Basic building block for functional composition. As you can guess any method of an ICodeWriter could be
    /// trivially wrapped in this form.
    /// </summary>
    public delegate ICodeWriter CodeWriterMutator(ICodeWriter input);

    /// <summary>
    /// This is a special kind of struct letting us to do functional composition DSL
    /// </summary>
    public struct CodeMutatorBox
    {
        private readonly CodeWriterMutator _writerMutator;
        public CodeMutatorBox(CodeWriterMutator writerMutator)
        {
            _writerMutator = writerMutator;
        }
        public static implicit operator CodeWriterMutator(CodeMutatorBox box) 
            => box._writerMutator;
        public static implicit operator CodeMutatorBox(CodeWriterMutator writerMutator) 
            => new CodeMutatorBox(writerMutator);

        public static CodeMutatorBox operator +(CodeMutatorBox lhs, CodeWriterMutator rhs) =>
            new CodeMutatorBox(input =>
            {
                lhs._writerMutator(input);
                return rhs(input);
            });
    }
}