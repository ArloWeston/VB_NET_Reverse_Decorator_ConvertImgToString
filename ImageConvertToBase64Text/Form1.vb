Public Class Form1
  Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click

    TurnOnWait()

    Dim runMe As IConvertFileToBase64 = Nothing
    runMe = New LongRunningTask(runMe)
    runMe = New ConvertToBase64String(runMe)
    runMe = New MoveToNewThread(AddressOf btnConvert_Click_FinishUp, runMe)
    runMe = New GetFilePath(runMe)


    Dim dataObj As New ConvertFileToBase64Vals()
    runMe.RunMe(dataObj)

    'btnConvert_Click_FinishUp(dataObj)

  End Sub

  Private Sub btnConvert_Click_FinishUp(ByVal dataObj As ConvertFileToBase64Vals)

    If dataObj.ErrObj.HasError Then
      Me.txtResults.Text = "ERROR: " & dataObj.ErrObj.Message
    Else
      Me.txtResults.Text = dataObj.Base64String
    End If

    TurnOffWait()

  End Sub

  Public Sub TurnOnWait()
    Cursor = Cursors.WaitCursor
    Me.lblConvertImage.Visible = True
    Me.progBarConvertImage.Visible = True
  End Sub

  Public Sub TurnOffWait()
    Me.lblConvertImage.Visible = False
    Me.progBarConvertImage.Visible = False
    Cursor = Cursors.Default
  End Sub

End Class
