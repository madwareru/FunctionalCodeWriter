using System;
using NUnit.Framework;
using static FunctionalCodeWriter.CodeWriterMutatorExt;

namespace FunctionalCodeWriter.Tests
{
    [TestFixture]
    public class ExampleUsage
    {
        [Test]
        public void Simplest()
        {
            // Just run this and see the result in a console
            
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
        }
    }
}