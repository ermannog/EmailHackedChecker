Public Module UtilEnumExtensions
    <System.Runtime.CompilerServices.Extension()>
    Public Function GetDescription(ByVal enumValue As [Enum]) As String
        Dim description As String = enumValue.GetDescriptionAttributeValue()

        If String.IsNullOrEmpty(description) Then
            description = System.Enum.GetName(enumValue.GetType(), enumValue)
        End If

        Return description
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function GetDescriptionAttributeValue(ByVal enumValue As [Enum]) As String
        Dim name As String = System.Enum.GetName(enumValue.GetType(), enumValue)

        Dim field As System.Reflection.FieldInfo =
            enumValue.GetType().GetField(System.Enum.GetName(enumValue.GetType(), enumValue),
                Reflection.BindingFlags.Public Or Reflection.BindingFlags.Static)

        Dim description As String = String.Empty
        Dim fieldDescriptions() As Object =
            field.GetCustomAttributes(
                GetType(System.ComponentModel.DescriptionAttribute), False)
        If fieldDescriptions.Length > 0 Then
            description = DirectCast(fieldDescriptions(0),
                System.ComponentModel.DescriptionAttribute).Description
        End If

        Return description
    End Function
End Module

