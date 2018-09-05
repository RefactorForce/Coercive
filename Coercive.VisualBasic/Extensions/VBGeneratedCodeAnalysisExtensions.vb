﻿Imports Microsoft.CodeAnalysis
Imports Microsoft.CodeAnalysis.VisualBasic
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax
Imports Microsoft.CodeAnalysis.Diagnostics
Imports System.Linq
Imports System.Runtime.CompilerServices
'Imports System.Text.RegularExpressions

Public Module VBGeneratedCodeAnalysisExtensions
    <Extension> Public Function IsGenerated(context As Microsoft.CodeAnalysis.Diagnostics.SyntaxNodeAnalysisContext) As Boolean
        Return If(context.SemanticModel?.SyntaxTree?.IsGenerated(), False) OrElse If(context.Node?.IsGenerated(), False)
    End Function

    Private ReadOnly generatedCodeAttributes() As String = {"DebuggerNonUserCode", "GeneratedCode", NameOf(DebuggerNonUserCodeAttribute), "GeneratedCodeAttribute"}

    <Extension> Public Function IsGenerated(node As SyntaxNode) As Boolean
        Return node.HasAttributeOnAncestorOrSelf(generatedCodeAttributes)
    End Function

    <Extension> Public Function IsGenerated(context As SyntaxTreeAnalysisContext) As Boolean
        Return If(context.Tree?.IsGenerated(), False)
    End Function

    <Extension> Public Function IsGenerated(context As SymbolAnalysisContext) As Boolean
        If (context.Symbol Is Nothing) Then Return False
        For Each syntaxReference In context.Symbol.DeclaringSyntaxReferences
            If (syntaxReference.SyntaxTree.IsGenerated()) Then Return True
            Dim root = syntaxReference.SyntaxTree.GetRoot()
            Dim node = root?.FindNode(syntaxReference.Span)
            If (node.IsGenerated()) Then Return True
        Next
        Return False
    End Function

    <Extension> Public Function IsGenerated(tree As SyntaxTree) As Boolean
        Return If(tree.FilePath?.IsOnGeneratedFile(), False) OrElse tree.HasAutoGeneratedComment()
    End Function

    '<Extension> Public Function IsOnGeneratedFile(filePath As String) As Boolean
    '    Return Regex.IsMatch(filePath, "(\\service|\\TemporaryGeneratedFile_.*|\\assemblyinfo|\\assemblyattributes|\.(g\.i|g|designer|generated|assemblyattributes))\.(cs|vb)$",
    '            RegexOptions.IgnoreCase)
    'End Function

    <Extension> Public Function HasAutoGeneratedComment(tree As SyntaxTree) As Boolean
        Dim root = tree.GetRoot()
        If (root Is Nothing) Then Return False
        Dim firstToken = root.GetFirstToken()
        Dim trivia As SyntaxTriviaList
        If (firstToken = Nothing) Then
            Dim token = DirectCast(root, CompilationUnitSyntax).EndOfFileToken
            If (token.HasLeadingTrivia = False) Then Return False
            trivia = token.LeadingTrivia
        Else
            If (firstToken.HasLeadingTrivia = False) Then Return False
            trivia = firstToken.LeadingTrivia
        End If
        Dim commentLines = trivia.Where(Function(t As SyntaxTrivia) t.IsKind(SyntaxKind.CommentTrivia)).Take(2).ToList()
        If (commentLines.Count <> 2) Then Return False
        Return commentLines(1).ToString() = "' <auto-generated>"
    End Function
End Module