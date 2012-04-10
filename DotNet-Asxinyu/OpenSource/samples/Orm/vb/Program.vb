Imports Lephone.Data.Model.Inserter
Imports Lephone.Data
Imports Lephone.Data.Builder
Imports OrmCommon

Module Program

    Sub Main()
        Console.WriteLine("Basic usage of DbEntry.Net:" + vbCrLf)

        Console.WriteLine("Show last items in database:")
        Show()

        Console.WriteLine("Insert a new item into database:")
        Dim d As SampleData = SampleData.[New]("angel", UserRole.Worker, New DateTime(2004, 2, 27, 15, 10, 23), True, 5)
        d.Save()
        Show()

        Console.WriteLine("Update this item to database:")
        d.Name = "demon"
        d.Role = UserRole.Client
        d.JoinDate = New DateTime(2005, 6, 10, 9, 5, 32)
        d.NullInt = Nothing
        d.Save()
        Show()

        Console.WriteLine("Delete this item from database:")
        d.Delete()
        Show()

        Console.WriteLine("Complex query:")
        Dim MyDataList As List(Of SampleData) = SampleData.Find(r!Id >= 3 And r!Id <= 6, New OrderBy(New DESC("Id")))

        For Each dd As SampleData In MyDataList
            Console.WriteLine(dd)
        Next
        Console.WriteLine()

        Console.WriteLine("Using Transaction : Insert and rollback")
        Try
            InsertAndRollback()
        Catch
        End Try
        Show()

        Console.WriteLine("Using Transaction : Insert and commit")
        InsertAndCommit()
        Show()

        Console.WriteLine("Using Transaction : delete the items.")
        Delete()
        Show()

        Console.WriteLine("Process large results:")
        Dim ctx As ModelContext = ModelContext.GetInstance(GetType(SampleData))
        ctx.Operator.DataLoad(New ItemOutputer(), GetType(SampleData), Nothing, Nothing, New OrderBy("Id"), Nothing, False, False)
    End Sub

    ReadOnly JoinDate = New DateTime(2011, 5, 19, 18, 30, 31)

    Sub InsertAndRollback()
        DbEntry.UsingConnection(
            Sub()
                SampleData.[New]("aa", UserRole.Manager, JoinDate, True, Nothing).Save()
                SampleData.[New]("bb", UserRole.Client, JoinDate, False, Nothing).Save()
                ' emu exception
                Throw New DataException()
            End Sub)
    End Sub

    Sub InsertAndCommit()
        DbEntry.UsingConnection(
            Sub()
                SampleData.[New]("aa", UserRole.Manager, JoinDate, True, Nothing).Save()
                SampleData.[New]("bb", UserRole.Client, JoinDate, False, Nothing).Save()
            End Sub)
    End Sub

    Sub Delete()
        Dim sb As DeleteStatementBuilder = New DeleteStatementBuilder("SampleData")
        sb.Where.Conditions = r!Id > 9
        DbEntry.Provider.ExecuteNonQuery(sb.ToSqlStatement(DbEntry.Provider.Dialect, Nothing))
    End Sub

    Sub Show()
        Dim ds As IList = DbEntry.From(Of SampleData).Where(r!Id >= 5).OrderBy("Id").Select()
        For Each d As SampleData In ds
            Console.WriteLine(d)
        Next
        Console.WriteLine()
    End Sub

End Module

Public Class ItemOutputer
    Implements IProcessor

    Public Function Process(ByVal obj As Object) As Boolean Implements IProcessor.Process
        Console.WriteLine(obj)
        Return True
    End Function
End Class

