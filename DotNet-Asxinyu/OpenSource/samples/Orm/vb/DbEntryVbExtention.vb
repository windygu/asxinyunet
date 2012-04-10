Imports Lephone.Data

Public Class DbEntryVbExtention
    Default Public ReadOnly Property Col(ByVal ColName As String) As CK
        Get
            Return CK.K(ColName)
        End Get
    End Property
End Class

Module DbEntryVbExtentionModule
    Public r As DbEntryVbExtention = New DbEntryVbExtention()
End Module
