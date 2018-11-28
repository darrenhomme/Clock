'Clock 1.0

Sub OnExecPerField()
    Dim TargetTime As DateTime
    Dim NowTime As DateTime

    Dim TimeDiffSec As Integer

    Dim TimeSec As Integer   '1 Leftover
    Dim TimeMin As Integer   '60
    Dim TimeHr As Integer    '3600
    Dim TimeDay As Integer   '86400

    NowTime = GetCurrentTime()

    TargetTime.Minute = GetText("Minute")
    TargetTime.Hour  = GetText("Hour")
    TargetTime.DayOfMonth = GetText("Day")
    TargetTime.Month = GetText("Month")
    TargetTime.Year = GetText("Year")

    TimeDiffSec = TargetTime.TotalSeconds - NowTime.TotalSeconds

    If TimeDiffSec > 0 Then
        TimeDay = TimeDiffSec/86400
        TimeHr = (TimeDiffSec - (TimeDay * 86400)) / 3600
        TimeMin = (TimeDiffSec - ((TimeHr * 3600) + (TimeDay * 86400))) / 60
        TimeSec = (TimeDiffSec - ((TimeMin * 60) + (TimeHr * 3600) + (TimeDay * 86400)))
    Else
        TimeDay = 0
        TimeHr = 0
        TimeMin = 0
        TimeSec = 0
    End If

    SetTime(TimeDay, "Days", "Days")
    SetTime(TimeHr, "Hour", "Hours")
    SetTime(TimeMin, "Min", "Mins")
    SetTime(TimeSec, "Sec", "Secs")

End Sub

Sub SetTime(Time As Integer, Field As String, Unit As String)
    If Time = 1 then Unit = Unit.Left(Unit.Length -1)

    If Time < 10 then SetText(Feild, "Number", "0" & CStr(Time))
    If Time > 9 then SetText(Field, "Number", CStr(Time))
    SetText(Field, "Text", Unit)
End Sub

Function GetText(Field As String) As Integer
     GetText = CInt(Scene.FindContainer("Input").FindSubContainer(Field).geometry.text)
End Function

Sub SetText(Clock As String, Field As String, Value As String)
    Scene.FindContainer("Clock").FindSubContainer(Clock).FindSubContainer(Field).geometry.text = Value
End Sub


