Public Class _Default
    Inherits Page

    Dim IsAdding As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        RefreshTowList()
    End Sub

    Sub RefreshTowList()
        Try
            Dim strConn As String = ConfigurationManager.ConnectionStrings("tow_conn").ConnectionString
            Dim objConn As New SqlClient.SqlConnection(strConn)
            Dim dataSet As New DataSet()
            Dim query As String = "select TowID, Vehicle, TowAddress, ContactPhone, CalledIn, Completed from [tow_jobs] order by CalledIn;"
            Dim dpt As New SqlClient.SqlDataAdapter(query, objConn)
            dpt.Fill(dataSet, "tmptow_jobs")
            Dim tblData As DataTable = dataSet.Tables("tmptow_jobs")

            gvMain.DataSource = tblData
            gvMain.DataBind()
            objConn.Close()
            tblData.Dispose()
            dpt.Dispose()
            objConn.Dispose()

            btnUpdate.Enabled = False
            lblStatus.Text = String.Empty

        Catch ex As Exception
            lblStatus.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub gvMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvMain.SelectedIndexChanged

        Try
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
            txtConatctPhone.Text = "" & ObjRow("ContactPhone")
            txtNotes.Text = "" & ObjRow("Notes")

            If Len("" & ObjRow("CalledIn")) > 0 Then
                txtCalledInDate.Text = "" & Format(ObjRow("CalledIn"), "yyyy-MM-dd")
                txtCalledInTime.Text = "" & Format(ObjRow("CalledIn"), "HH:mm")
            Else
                txtCalledInDate.Text = ""
                txtCalledInTime.Text = ""
            End If

            objConn.Close()
            objCmd.Dispose()
            dpt.Dispose()
            tblData.Dispose()
            dataSet.Dispose()

            SetControlsUpdating()

        Catch ex As Exception
            lblStatus.Text = "Error: " & ex.Message
        End Try

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            'Update the row with new values
            Dim strConn As String = ConfigurationManager.ConnectionStrings("tow_conn").ConnectionString
            Dim objConn As New SqlClient.SqlConnection(strConn)
            Dim dataSet As New DataSet()
            Dim query As String = "Update [tow_jobs] Set CalledBy = @CalledBy " &
                " , Driver = @Driver " &
                " , Vehicle = @Vehicle " &
                " , TowAddress = @TowAddress " &
                " , TowLocation = @TowLocation " &
                " , ContactPhone = @ContactPhone " &
                " , Notes = @Notes " &
                " , CalledIn = @CalledIn " &
                " Where TowId = @TowID;"
            Dim objCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand(query, objConn)
            Dim prmCalledBy As New SqlClient.SqlParameter("@CalledBy", SqlDbType.NVarChar)
            Dim prmDriver As New SqlClient.SqlParameter("@Driver", SqlDbType.NVarChar)
            Dim prmVehicle As New SqlClient.SqlParameter("@Vehicle", SqlDbType.NVarChar)
            Dim prmTowAddress As New SqlClient.SqlParameter("@TowAddress", SqlDbType.NVarChar)
            Dim prmTowLocation As New SqlClient.SqlParameter("@TowLocation", SqlDbType.NVarChar)
            Dim prmConatctPhone As New SqlClient.SqlParameter("@ContactPhone", SqlDbType.NVarChar)
            Dim prmNotes As New SqlClient.SqlParameter("@Notes", SqlDbType.NVarChar)
            Dim prmTowID As New SqlClient.SqlParameter("@TowID", SqlDbType.Int)
            Dim prmCalledIn As New SqlClient.SqlParameter("@CalledIn", SqlDbType.DateTime)
            prmCalledBy.Value = "" & txtCalledBy.Text
            prmDriver.Value = "" & txtDriver.Text
            prmVehicle.Value = "" & txtVehicle.Text
            prmTowAddress.Value = "" & txtTowAddress.Text
            prmTowLocation.Value = "" & txtTowLocation.Text
            prmConatctPhone.Value = "" & txtConatctPhone.Text
            prmNotes.Value = "" & txtNotes.Text
            prmTowID.Value = "" & gvMain.SelectedValue
            If Len(txtCalledInDate.Text) > 0 And Len(txtCalledInTime.Text) > 0 Then
                prmCalledIn.Value = txtCalledInDate.Text & " " & txtCalledInTime.Text
            Else
                prmCalledIn.Value = DBNull.Value
            End If

            objCmd.Parameters.Add(prmCalledBy)
            objCmd.Parameters.Add(prmDriver)
            objCmd.Parameters.Add(prmVehicle)
            objCmd.Parameters.Add(prmTowAddress)
            objCmd.Parameters.Add(prmTowLocation)
            objCmd.Parameters.Add(prmConatctPhone)
            objCmd.Parameters.Add(prmNotes)
            objCmd.Parameters.Add(prmTowID)
            objCmd.Parameters.Add(prmCalledIn)

            objConn.Open()
            objCmd.ExecuteNonQuery()
            objConn.Close()
            objCmd.Dispose()
            dataSet.Dispose()

            Dim intTowID As Integer = gvMain.SelectedValue
            RefreshTowList()
            For Each objGRow As GridViewRow In gvMain.Rows
                If objGRow.Cells(1).Text = intTowID Then
                    gvMain.SelectedIndex = objGRow.RowIndex
                End If
            Next

            lblStatus.Text = "The record has been updated!"

            ClearDataFields()
            SetControlsDefault()
        Catch ex As Exception
            lblStatus.Text = "Error: " & ex.Message
        End Try

    End Sub

    Sub ClearDataFields()
        txtCalledBy.Text = ""
        txtDriver.Text = ""
        txtVehicle.Text = ""
        txtTowAddress.Text = ""
        txtTowLocation.Text = ""
        txtConatctPhone.Text = ""
        txtNotes.Text = ""
        txtCalledInDate.Text = ""
        txtCalledInTime.Text = ""
    End Sub

    Sub SetControlsAddind()
        ClearDataFields()
        gvMain.SelectedIndex = -1
        btnUpdate.Visible = False
        btnUpdate.Enabled = False
        btnAddNewRecord.Enabled = True
        btnAdd.Visible = True
        btnAdd.Enabled = True
        btnCancel.Enabled = True
        btnCancel.Visible = True
        dataTitle.InnerText = "Add New Data"
        pSectionData.InnerText = "You can add new data in this section."
    End Sub

    Sub SetControlsDefault()
        ClearDataFields()
        btnUpdate.Visible = False
        btnUpdate.Enabled = False
        btnAddNewRecord.Enabled = True
        btnAdd.Visible = False
        btnAdd.Enabled = False
        btnCancel.Enabled = False
        btnCancel.Visible = False
        dataTitle.InnerText = "Tow Data"
        pSectionData.InnerText = ""

    End Sub

    Sub SetControlsUpdating()
        btnUpdate.Visible = True
        btnUpdate.Enabled = True
        btnAddNewRecord.Enabled = False
        btnAdd.Visible = False
        btnAdd.Enabled = False
        btnCancel.Enabled = True
        btnCancel.Visible = True
        dataTitle.InnerText = "Edit Data"
        pSectionData.InnerText = "You can edit selected data in this section."
    End Sub

    Private Sub btnAddNewRecord_Click(sender As Object, e As EventArgs) Handles btnAddNewRecord.Click
        ClearDataFields()
        SetControlsAddind()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        SetControlsDefault()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Try
            'Add the row into database
            Dim strConn As String = ConfigurationManager.ConnectionStrings("tow_conn").ConnectionString
            Dim objConn As New SqlClient.SqlConnection(strConn)
            Dim dataSet As New DataSet()
            Dim query As String = "INSERT INTO [tow_jobs] " &
                " ( [CalledBy] ,[Driver] ,[Vehicle] ,[TowAddress] ,[TowLocation] ,[ContactPhone] ,[Notes] ,[CalledIn] ) " &
                " VALUES ( " &
                "   @CalledBy " &
                " , @Driver " &
                " , @Vehicle " &
                " , @TowAddress " &
                " , @TowLocation " &
                " , @ContactPhone " &
                " , @Notes " &
                " , @CalledIn " &
                " );"
            Dim objCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand(query, objConn)
            Dim prmCalledBy As New SqlClient.SqlParameter("@CalledBy", SqlDbType.NVarChar)
            Dim prmDriver As New SqlClient.SqlParameter("@Driver", SqlDbType.NVarChar)
            Dim prmVehicle As New SqlClient.SqlParameter("@Vehicle", SqlDbType.NVarChar)
            Dim prmTowAddress As New SqlClient.SqlParameter("@TowAddress", SqlDbType.NVarChar)
            Dim prmTowLocation As New SqlClient.SqlParameter("@TowLocation", SqlDbType.NVarChar)
            Dim prmConatctPhone As New SqlClient.SqlParameter("@ContactPhone", SqlDbType.NVarChar)
            Dim prmNotes As New SqlClient.SqlParameter("@Notes", SqlDbType.NVarChar)
            Dim prmCalledIn As New SqlClient.SqlParameter("@CalledIn", SqlDbType.DateTime)
            prmCalledBy.Value = "" & txtCalledBy.Text
            prmDriver.Value = "" & txtDriver.Text
            prmVehicle.Value = "" & txtVehicle.Text
            prmTowAddress.Value = "" & txtTowAddress.Text
            prmTowLocation.Value = "" & txtTowLocation.Text
            prmConatctPhone.Value = "" & txtConatctPhone.Text
            prmNotes.Value = "" & txtNotes.Text
            If Len(txtCalledInDate.Text) > 0 And Len(txtCalledInTime.Text) > 0 Then
                prmCalledIn.Value = txtCalledInDate.Text & " " & txtCalledInTime.Text
            Else
                prmCalledIn.Value = DBNull.Value
            End If

            objCmd.Parameters.Add(prmCalledBy)
            objCmd.Parameters.Add(prmDriver)
            objCmd.Parameters.Add(prmVehicle)
            objCmd.Parameters.Add(prmTowAddress)
            objCmd.Parameters.Add(prmTowLocation)
            objCmd.Parameters.Add(prmConatctPhone)
            objCmd.Parameters.Add(prmNotes)
            objCmd.Parameters.Add(prmCalledIn)

            objConn.Open()
            objCmd.ExecuteNonQuery()
            objConn.Close()
            objCmd.Dispose()
            dataSet.Dispose()

            RefreshTowList()
            SetControlsDefault()
            lblStatus.Text = "The new record has been added!"
        Catch ex As Exception
            lblStatus.Text = "Error: " & ex.Message
        End Try


    End Sub
End Class