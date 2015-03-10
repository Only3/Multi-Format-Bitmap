
        Dim Bmp = {"1.bmp", "2.jpg", "3.png"}
        Dim Bytes As New List(Of Byte) From {66, 77, Bmp.Count, 0, 0, 0, 54, 0, 0, 0}
        For i = 0 To Bmp.Count - 1
            If Bmp(i).EndsWith("bmp") Then
                Dim B = IO.File.ReadAllBytes(Bmp(i))
                If i = 0 Then
                    Bytes.InsertRange(2, B.Skip(2).Take(4))
                    Bytes.AddRange(B.Skip(14).Take(B.Count - 14))
                Else
                    Bytes.AddRange(B)
                End If
            Else
                Dim Bm As New Bitmap(Bmp(i))
                Dim Ms As New IO.MemoryStream
                Bm.Save(Ms, Imaging.ImageFormat.Bmp)
                Bytes.AddRange(Ms.ToArray)
                Ms.Close()
            End If
        Next
        IO.File.WriteAllBytes("New.bmp", Bytes.ToArray)
        
