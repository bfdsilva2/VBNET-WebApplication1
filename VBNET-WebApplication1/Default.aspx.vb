Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim strConn As String = ConfigurationManager.ConnectionStrings("tow_conn").ConnectionString
        Dim objConn As New SqlClient.SqlConnection(strConn)
        Dim dataSet As New DataSet()
        Dim query As String = "select * from [tow_jobs] order by CalledBy;"
        Dim dpt As New SqlClient.SqlDataAdapter(query, objConn)
        dpt.Fill(dataSet, "tmptow_jobs")
        Dim tblData As DataTable = dataSet.Tables("tmptow_jobs")

        gvMain.DataSource = tblData
        gvMain.DataBind()
        objConn.Close()
        tblData.Dispose()
        dpt.Dispose()
        objConn.Close()

    End Sub
End Class