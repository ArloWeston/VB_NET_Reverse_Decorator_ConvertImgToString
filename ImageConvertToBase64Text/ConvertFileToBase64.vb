
Imports System.ComponentModel
Imports System.Threading
Imports ImageConvertToBase64Text

Public Interface IConvertFileToBase64
  Sub RunMe(ByVal dataObj As ConvertFileToBase64Vals)
End Interface


Public Class ConvertFileToBase64Vals
  Public Sub New()
    ErrObj = New ErrorObj()
  End Sub
  Public Property ErrObj As ErrorObj
  Public Property FilePathAndName As String
  Public Property Base64String As String

End Class


Public Class GetFilePath
  Implements IConvertFileToBase64

  Private _runMeNext As IConvertFileToBase64

  Public Sub New(ByVal runMeNext As IConvertFileToBase64)
    _runMeNext = runMeNext

  End Sub

  Public Sub RunMe(dataObj As ConvertFileToBase64Vals) Implements IConvertFileToBase64.RunMe

    If Not dataObj.ErrObj.HasError Then

      Try

        Dim OpenFileDialog1 = New OpenFileDialog()
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
          dataObj.FilePathAndName = OpenFileDialog1.FileName
        End If

      Catch ex As Exception
        dataObj.ErrObj.HasError = True
        dataObj.ErrObj.Message = "GetFilePath: " & ex.Message
      End Try

    End If


    If Not IsNothing(_runMeNext) Then
      _runMeNext.RunMe(dataObj)
    End If

  End Sub

End Class


Public Class ConvertToBase64String
  Implements IConvertFileToBase64

  Private _runMeNext As IConvertFileToBase64

  Public Sub New(ByVal runMeNext As IConvertFileToBase64)
    _runMeNext = runMeNext

  End Sub

  Public Sub RunMe(dataObj As ConvertFileToBase64Vals) Implements IConvertFileToBase64.RunMe


    If Not dataObj.ErrObj.HasError Then

      Try

        dataObj.Base64String = Convert.ToBase64String(System.IO.File.ReadAllBytes(dataObj.FilePathAndName))

      Catch ex As Exception
        dataObj.ErrObj.HasError = True
        dataObj.ErrObj.Message = "ConvertToBase64String: " & ex.Message
      End Try

    End If

    If Not IsNothing(_runMeNext) Then
      _runMeNext.RunMe(dataObj)
    End If

  End Sub

End Class


Public Class LongRunningTask
  Implements IConvertFileToBase64

  Private _runMeNext As IConvertFileToBase64

  Public Sub New(ByVal runMeNext As IConvertFileToBase64)
    _runMeNext = runMeNext

  End Sub

  Public Sub RunMe(dataObj As ConvertFileToBase64Vals) Implements IConvertFileToBase64.RunMe


    If Not dataObj.ErrObj.HasError Then

      Try

        Thread.Sleep(10000)

      Catch ex As Exception
        dataObj.ErrObj.HasError = True
        dataObj.ErrObj.Message = "LongRunningTask: " & ex.Message
      End Try

    End If

    If Not IsNothing(_runMeNext) Then
      _runMeNext.RunMe(dataObj)
    End If

  End Sub

End Class


'Public Class TurnOnWaitForm1
'  Implements IConvertFileToBase64

'  Private _CurrForm1 As Form1
'  Private _runMeNext As IConvertFileToBase64

'  Public Sub New(ByVal runMeNext As IConvertFileToBase64)

'    _runMeNext = runMeNext

'  End Sub

'  Public Sub RunMe(dataObj As ConvertFileToBase64Vals) Implements IConvertFileToBase64.RunMe


'    If Not dataObj.ErrObj.HasError Then

'      Try

'        Thread.Sleep(10000)

'      Catch ex As Exception
'        dataObj.ErrObj.HasError = True
'        dataObj.ErrObj.Message = "LongRunningTask: " & ex.Message
'      End Try

'    End If

'    If Not IsNothing(_runMeNext) Then
'      _runMeNext.RunMe(dataObj)
'    End If

'  End Sub

'End Class


'Public Class WriteToTextBox
'  Implements IConvertFileToBase64

'  Private _runMeNext As IConvertFileToBase64
'  Private _currForm1 As Form1

'  Public Sub New(ByRef currForm1 As Form1, ByVal runMeNext As IConvertFileToBase64)
'    _runMeNext = runMeNext

'  End Sub

'  Public Sub RunMe(dataObj As ConvertFileToBase64Vals) Implements IConvertFileToBase64.RunMe

'    If Not dataObj.ErrObj.HasError Then

'      Try

'        _currForm1.txtResults.Text = dataObj.Base64String

'      Catch ex As Exception
'        dataObj.ErrObj.HasError = True
'        dataObj.ErrObj.Message = "WriteToTextBox: " & ex.Message
'      End Try

'    End If

'    If Not IsNothing(_runMeNext) Then
'      _runMeNext.RunMe(dataObj)
'    End If

'  End Sub

'End Class





Public Class MoveToNewThread
  Implements IConvertFileToBase64

  Private WithEvents _bgw As BackgroundWorker
  Private _nextSub As IConvertFileToBase64
  Private _callMeWhenDone As Action(Of ConvertFileToBase64Vals)

  Public Sub New(ByRef callMeWhenDone As Action(Of ConvertFileToBase64Vals), ByRef nextSub As IConvertFileToBase64)

    _callMeWhenDone = callMeWhenDone
    _nextSub = nextSub
    If IsNothing(_bgw) Then
      _bgw = New BackgroundWorker()
      _bgw.WorkerReportsProgress = True
      _bgw.WorkerSupportsCancellation = True
    End If

  End Sub 'New


  Private Sub bgw_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) _
   Handles _bgw.DoWork

    Dim locDataObj As ConvertFileToBase64Vals = TryCast(e.Argument, ConvertFileToBase64Vals)
    If IsNothing(locDataObj) Then
      locDataObj = New ConvertFileToBase64Vals()
      locDataObj.ErrObj.HasError = True
      locDataObj.ErrObj.Message = "MoveToNewThread: No locDataObj passed.  Ending Execution."
      If Not IsNothing(_nextSub) Then
        _nextSub.RunMe(locDataObj)
      End If
      Exit Sub
    End If

    e.Result = locDataObj

    If Not IsNothing(_nextSub) Then
      _nextSub.RunMe(locDataObj)
    End If

  End Sub 'bgw_DoWork

  Private Sub bgw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles _bgw.RunWorkerCompleted

    Dim dataObj As ConvertFileToBase64Vals = TryCast(e.Result, ConvertFileToBase64Vals)

    _callMeWhenDone(dataObj)

  End Sub 'bgw_RunWorkerCompleted

  Public Sub RunMe(dataObj As ConvertFileToBase64Vals) Implements IConvertFileToBase64.RunMe

    If Not dataObj.ErrObj.HasError AndAlso Not _bgw.IsBusy Then
      _bgw.RunWorkerAsync(dataObj)
    ElseIf Not IsNothing(_nextSub) Then
      _nextSub.RunMe(dataObj)
    End If

  End Sub

End Class 'MoveToNewThread








Public Class ErrorObj
  Public Sub New()
    HasError = False
  End Sub
  Public Property HasError As Boolean
  Public Property Message As String
End Class