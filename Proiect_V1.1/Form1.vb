Public Class Form1
    Dim apa(3) As PictureBox
    Dim scor As Integer
    Dim pixeli() As String = {"000", "100", "200", "300", "400", "500"}
    Dim Oprire As Boolean
    Dim nume As String


    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click 'Permite aplicatiei sa "inceapa". Ascunde elementele fundalului de start
        Timer1.Start()
        Timer2.Start()
        Timer3.Start()
        pozaFundal.Visible = False
        btnCumSaJoci.Visible = False
        btnIesire.Visible = False
        btnClas.Visible = False
        Me.ControlBox = True
        btnStart.Visible = False
        btnSetari.Visible = False
        TextBox1.Visible = True
        TextBox2.Visible = True
        Pamant.Left = 0
        Pamant.Top = 0
        scor = 0
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        apa(0) = apa1
        apa(1) = apa2
        apa(2) = apa3
    End Sub

    Private Sub frmMain_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode 'La apasarea sagetilor broasca se misca in functie de sageata

            Case Keys.Right
                Broasca.Left = Broasca.Left + 100
                scor = scor + 1
                For index = 0 To 2
                    If Broasca.Bounds.IntersectsWith(apa(index).Bounds) Then
                        Call CondCastig() 'Apelam functia creata
                        nume = InputBox("Felicitari!!! ati terminat in " & scor & " miscari! Introduceti numele dumneavoastra", "Castigator")
                        If nume <> "" Then
                            Form3.DataGridView1.Rows.Add(nume, scor)
                            Form3.Show()
                            Form3.Visible = True
                        Else
                            If nume = "" Then
                                Return
                            End If
                        End If

                        Exit Sub
                    End If
                Next

            Case Keys.Left
                Broasca.Left = Broasca.Left - 100
                scor = scor + 1
                For index = 0 To 2
                    If Broasca.Bounds.IntersectsWith(apa(index).Bounds) Then
                        Call CondCastig()
                        nume = InputBox("Felicitari!!! ati terminat in " & scor & " miscari! Introduceti numele dumneavoastra", "Castigator")
                        If nume <> "" Then
                            Form3.DataGridView1.Rows.Add(nume, scor)
                            Form3.Show()
                            Form3.Visible = True
                        Else
                            If nume = "" Then
                                Return
                            End If
                        End If

                        Exit Sub
                    End If
                Next

            Case Keys.Up
        Broasca.Top = Broasca.Top - 100
                scor = scor + 1
        For index = 0 To 2
                    If Broasca.Bounds.IntersectsWith(apa(index).Bounds) Then
                        Call CondCastig()
                        nume = InputBox("Felicitari!!! ati terminat in " & scor & " miscari! Introduceti numele dumneavoastra", "Castigator")
                        If nume <> "" Then
                            Form3.DataGridView1.Rows.Add(nume, scor)
                            Form3.Show()
                            Form3.Visible = True
                        Else
                            If nume = "" Then
                                Return
                            End If
                        End If
                        Call CondCastig()
                        Exit Sub
                    End If
        Next

            Case Keys.Down
        Broasca.Top = Broasca.Top + 100
                scor = scor + 1
        For index = 0 To 2
                    If Broasca.Bounds.IntersectsWith(apa(index).Bounds) Then
                        Call CondCastig()
                        nume = InputBox("Felicitari!!! ati terminat in " & scor & " miscari! Introduceti numele dumneavoastra", "Castigator")
                        If nume <> "" Then
                            Form3.DataGridView1.Rows.Add(nume, scor)
                            Form3.Show()
                            Form3.Visible = True
                        Else
                            If nume = "" Then
                                Return

                            End If
                        End If
                        Exit Sub
                    End If
                Next

        End Select
    End Sub

    Sub CondCastig() 'Facem o functie pentru a scurta din cod pe care o apelam de fiecare data cand broasca cade in apa

        pozaFundal.Visible = True
            Broasca.Top = 0
            Broasca.Left = 0
            btnStart.Visible = True
            btnCumSaJoci.Visible = True
            btnIesire.Visible = True
            btnSetari.Visible = True
        btnClas.Visible = True
        TextBox1.Visible = False
        TextBox2.Visible = False
            Timer1.Stop()
        Timer2.Stop()
        Timer3.Stop()

    End Sub

    Sub DepasireEcran() 'Functie pentru a nu lasa broasca sa depaseasca ecranul
        If Broasca.Left > 500 Then
            Broasca.Left = Broasca.Left - 100
            scor = scor - 1
        End If
        If Broasca.Top > 300 Then
            Broasca.Top = Broasca.Top - 100
            scor = scor - 1
        End If
        If Broasca.Left < 0 Then
            Broasca.Left = Broasca.Left + 100
            scor = scor - 1
        End If
        If Broasca.Top < 0 Then
            Broasca.Top = Broasca.Top + 100
            scor = scor - 1
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        For index = 0 To 2
            apa(index).Top = pixeli(4 * Rnd()) 'Randomizam "caderea nuferilor" 
            apa(index).Left = pixeli(5 * Rnd())
            If Pamant.Bounds.IntersectsWith(apa(index).Bounds) Then
                Pamant.Left = Pamant.Left + 100
            End If
            If apa(index).Bounds.IntersectsWith(Broasca.Bounds) Then
                Call CondCastig()

                nume = InputBox("Felicitari!!! ati terminat in " & scor & " miscari! Introduceti numele dumneavoastra", "Castigator")

                Form3.DataGridView1.Rows.Add(nume, TextBox1.Text)

                If nume <> "" Then
                    Form3.Show()
                    Form3.Visible = True
                Else
                    If nume = "" Then
                        Return
                    End If
                End If
                Exit Sub
            End If
            If Pamant.Bounds.IntersectsWith(apa(index).Bounds) Then
                apa(index).Enabled = False
            Else
                apa(index).Enabled = True
            End If
        Next
    End Sub

    Private Sub btnIesire_Click(sender As Object, e As EventArgs) Handles btnIesire.Click
        Dim iesire as MsgBoxResult
        iesire = MsgBox("Doriti sa iesiti din joc?", MsgBoxStyle.OkCancel)
        If iesire = MsgBoxResult.Ok Then
            Me.Close()
        Else
            If iesire = MsgBoxResult.Cancel Then
                Return

            End If
        End If
    End Sub

    Private Sub btnCumSaJoci_Click(sender As Object, e As EventArgs) Handles btnCumSaJoci.Click
        MsgBox("Trebuie sa mergi pe cat mai multi nuferi. Din cand in cand nuferii cad in apa aleatoriu." _
               & "Te pot surprinde, asa ca trebuie sa te misti repede. Unul din nuferi va fi zona de siguranta. Daca stai pe el nu poti cadea in apa." _
                & " Insa si acesta se misca din cand in cand. Pentru a misca broasca apesi pe sageti (sus-jos-stanga-dreapta). " _
& "Pentru a modifica timpul de miscare a nuferilor cat si al celul de siguranta apasa pe butonul Setari din meniul principal.")
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
       Pamant.Top = pixeli(4 * Rnd())
        Pamant.Left = pixeli(5 * Rnd())
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSetari.Click
        Form2.Show()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnClas.Click
        Form3.Visible = True
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Call DepasireEcran()
        TextBox1.Text = scor
        TextBox1.Refresh()
    End Sub

End Class
