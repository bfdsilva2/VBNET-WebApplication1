Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        RefreshTowList()
    End Sub

    Sub RefreshTowList()
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
        objConn.Dispose()
    End Sub

    Private Sub gvMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvMain.SelectedIndexChanged
        Dim strConn As String = ConfigurationManager.ConnectionStrings("tow_conn").ConnectionString
        Dim objConn As New SqlClient.SqlConnection(strConn)
        Dim dataSet As New DataSet()
        Dim query As String = "select * from [tow_jobs] Where TowId = @TowID;"
        Dim objCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand(query, objConn)
        Dim ObjPrm As SqlClient.SqlParameter = New SqlClient.SqlParameter("TowID", SqlDbType.Int)
        Dim intID As Integer = gvMain.SelectedValue
        ObjPrm.Value = intID
        objCmd.Parameters.Add(ObjPrm)
        Dim dpt As New SqlClient.SqlDataAdapter(objCmd)
        dpt.Fill(dataSet, "tmptow_jobs")
        Dim tblData As DataTable = dataSet.Tables("tmptow_jobs")
        Dim ObjRow As DataRow = tblData.Rows(0)
        txtCalledBy.Text = "" & ObjRow("CalledBy")
        txtDriver.Text = "" & ObjRow("Driver")
        txtVehicle.Text = "" & ObjRow("Vehicle")
        txtTowAddress.Text = "" & ObjRow("TowAddress")
        txtTowLocation.Text = "" & ObjRow("TowLocation")
        txtConatctPhone.Text = "" & ObjRow("ConatctPhone")
        txtNotes.Text = "" & ObjRow("Notes")
        objConn.Close()
        objCmd.Dispose()
        dpt.Dispose()
        tblData.Dispose()
        dataSet.Dispose()

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'Update the row with new values
        Dim strConn As String = ConfigurationManager.ConnectionStrings("tow_conn").ConnectionString
        Dim objConn As New SqlClient.SqlConnection(strConn)
        Dim dataSet As New DataSet()
        Dim query As String = "Update [tow_jobs] Set CalledBy = @CalledBy " &
            " , Driver = @Driver " &
            " , Vehicle = @Vehicle " &
            " , TowAddress = @TowAddress " &
            " , TowLocation = @TowLocation " &
            " , ConatctPhone = @ConatctPhone " &
            " , Notes = @Notes " &
            " Where TowId = @TowID;"
        Dim objCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand(query, objConn)
        Dim prmCalledBy As New SqlClient.SqlParameter("@CalledBy", SqlDbType.NVarChar)
        Dim prmDriver As New SqlClient.SqlParameter("@Driver", SqlDbType.NVarChar)
        Dim prmVehicle As New SqlClient.SqlParameter("@Vehicle", SqlDbType.NVarChar)
        Dim prmTowAddress As New SqlClient.SqlParameter("@TowAddress", SqlDbType.NVarChar)
        Dim prmTowLocation As New SqlClient.SqlParameter("@TowLocation", SqlDbType.NVarChar)
        Dim prmConatctPhone As New SqlClient.SqlParameter("@ConatctPhone", SqlDbType.NVarChar)
        Dim prmNotes As New SqlClient.SqlParameter("@Notes", SqlDbType.NVarChar)
        Dim prmTowID As New SqlClient.SqlParameter("@TowID", SqlDbType.Int)
        prmCalledBy.Value = "" & txtCalledBy.Text
        prmDriver.Value = "" & txtDriver.Text
        prmVehicle.Value = "" & txtVehicle.Text
        prmTowAddress.Value = "" & txtTowAddress.Text
        prmTowLocation.Value = "" & txtTowLocation.Text
        prmConatctPhone.Value = "" & txtConatctPhone.Text
        prmNotes.Value = "" & txtNotes.Text
        prmTowID.Value = "" & gvMain.SelectedValue
        objCmd.Parameters.Add(prmCalledBy)
        objCmd.Parameters.Add(prmDriver)
        objCmd.Parameters.Add(prmVehicle)
        objCmd.Parameters.Add(prmTowAddress)
        objCmd.Parameters.Add(prmTowLocation)
        objCmd.Parameters.Add(prmConatctPhone)
        objCmd.Parameters.Add(prmNotes)
        objCmd.Parameters.Add(prmTowID)
        objConn.Open()
        objCmd.ExecuteNonQuery()
        objConn.Close()
        objCmd.Dispose()
        dataSet.Dispose()

        RefreshTowList()

        txtCalledBy.Text = ""
        txtDriver.Text = ""
        txtVehicle.Text = ""
        txtTowAddress.Text = ""
        txtTowLocation.Text = ""
        txtConatctPhone.Text = ""
        txtNotes.Text = ""

    End Sub
End Class