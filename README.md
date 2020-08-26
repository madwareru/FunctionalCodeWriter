# FunctionalCodeWriter
Code writer inspired by power of functional composition

## Example usage
Add following usings:
```CSharp
using FunctionalCodeWriter;
using static FunctionalCodeWriter.CodeWriterMutatorExt;
```

And then write this code somewhere:
```CSharp
CodeWriterMutator AddNameSpace(string nameSpace, CodeWriterMutator content)
{
    return 
        AddLineWithBracket($"namespace {nameSpace}") +
        content +
        CloseBracket;
}

CodeWriterMutator AddMonoBehaviourClass(string className, CodeWriterMutator content)
{
    return 
        AddLineWithBracket($"public class {className}: MonoBehaviour") +
        content +
        CloseBracket;
}

CodeWriterMutator AddPrivateVoidParameterlessMethod(string methodName, CodeWriterMutator content)
{
    return 
        AddLineWithBracket($"private void {methodName}()") +
        content +
        CloseBracket;
}
var codeWriter = new CodeWriter();

var printedCode = 
    codeWriter.Do(
        AddLine("using UnityEngine;\n") +
        AddNameSpace(
            "AwesomeGame",
            AddMonoBehaviourClass(
                "AwesomeBehaviourOne",
                AddPrivateVoidParameterlessMethod(
                    "Start",
                    AddLine("Debug.Log(\"AwesomeBehaviourOne Started!\");")
                ) +
                AddPrivateVoidParameterlessMethod(
                    "Update",
                    AddLine("Debug.Log(\"AwesomeBehaviourOne Updated!\");")
                )
            ) +
            AddLine() +
            AddMonoBehaviourClass(
                "AwesomeBehaviourTwo",
                AddPrivateVoidParameterlessMethod(
                    "Start",
                    AddLine("Debug.Log(\"AwesomeBehaviourTwo Started!\");")
                ) +
                AddPrivateVoidParameterlessMethod(
                    "Update",
                    AddLine("Debug.Log(\"AwesomeBehaviourTwo Updated!\");")
                )
            )
        )
    ).PrintResult();
Console.WriteLine(printedCode);
```

It would print this result in a console:
```CSharp
using UnityEngine;

namespace AwesomeGame
{
    public class AwesomeBehaviourOne: MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("AwesomeBehaviourOne Started!");
        }
        private void Update()
        {
            Debug.Log("AwesomeBehaviourOne Updated!");
        }
    }
    
    public class AwesomeBehaviourTwo: MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("AwesomeBehaviourTwo Started!");
        }
        private void Update()
        {
            Debug.Log("AwesomeBehaviourTwo Updated!");
        }
    }
}
```
