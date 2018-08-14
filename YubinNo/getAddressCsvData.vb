Friend Class getAddressCsvData
    '1    全国地方公共団体コード（JIS X0401、X0402）………　半角数字
    '2    （旧）郵便番号（5桁）………………………………………　半角数字
    '3    郵便番号（7桁）………………………………………　半角数字
    '4    都道府県名　…………　半角カタカナ（コード順に掲載）　（注1）
    '5    市区町村名　…………　半角カタカナ（コード順に掲載）　（注1）
    '6    町域名　………………　半角カタカナ（五十音順に掲載）　（注1）
    '7    都道府県名　…………　漢字（コード順に掲載）　（注1,2）
    '8    市区町村名　…………　漢字（コード順に掲載）　（注1,2）
    '9    町域名　………………　漢字（五十音順に掲載）　（注1,2）
    '10   一町域が二以上の郵便番号で表される場合の表示　（注3）　（「1」は該当、「0」は該当せず）
    '11   小字毎に番地が起番されている町域の表示　（注4）　（「1」は該当、「0」は該当せず）
    '12   丁目を有する町域の場合の表示　（「1」は該当、「0」は該当せず）
    '13   一つの郵便番号で二以上の町域を表す場合の表示　（注5）　（「1」は該当、「0」は該当せず）
    '14   更新の表示（注6）（「0」は変更なし、「1」は変更あり、「2」廃止（廃止データのみ使用））
    '15   変更理由　（「0」は変更なし、「1」市政・区政・町政・分区・政令指定都市施行、「2」住居表示の実施、「3」区画整理、「4」郵便区調整等、「5」訂正、「6」廃止（廃止データのみ使用））

    Private ReadOnly _FilePath As String '= System.Windows.Forms.Application.StartupPath & "\KEN_ALL.CSV"

    ''' <summary>
    ''' コンストラクタ。引数が存在しないパスの場合、FileNotFoundException
    ''' </summary>
    ''' <param name="CsvFilePath"></param>
    Public Sub New(ByVal CsvFilePath As String)

        If Not System.IO.File.Exists(CsvFilePath) Then
            Throw New System.IO.FileNotFoundException("住所CSVファイルが見つかりません。")
        End If

        _FilePath = CsvFilePath
    End Sub

    Public Iterator Function MakeAddressData() As IEnumerable(Of Address)
        Try

            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(_FilePath, System.Text.Encoding.Default)

                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(",")

                Dim currentRow As String()
                '行
                While Not MyReader.EndOfData
                    Try
                        '列
                        Dim wkAddress As New Address
                        currentRow = MyReader.ReadFields()

                        For ColumnIndex As Integer = 0 To 8
                            Select Case ColumnIndex
                                Case 2
                                    wkAddress.YubinBango = currentRow(ColumnIndex)
                                Case 3
                                    wkAddress.TodouhukenKana = currentRow(ColumnIndex)
                                Case 4
                                    wkAddress.SichousonKana = currentRow(ColumnIndex)
                                Case 5
                                    wkAddress.ChouikiKana = currentRow(ColumnIndex)
                                Case 6
                                    wkAddress.Todouhuken = currentRow(ColumnIndex)
                                Case 7
                                    wkAddress.Sichouson = currentRow(ColumnIndex)
                                Case 8
                                    wkAddress.Chouiki = currentRow(ColumnIndex)
                            End Select

                        Next

                        Yield wkAddress

                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        Throw
                    Catch ex As Exception
                        Throw
                    End Try

                End While

            End Using
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function SetCsv(ByRef lstAddress As List(Of Address)) As Boolean
        Try

            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(_FilePath, System.Text.Encoding.Default)

                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(",")


                Dim currentRow As String()
                '行
                While Not MyReader.EndOfData
                    Try
                        '列
                        Dim Add As New Address
                        currentRow = MyReader.ReadFields()

                        For counter As Integer = 0 To 8
                            Select Case counter
                                Case 2
                                    Add.YubinBango = currentRow(counter)
                                Case 3
                                    Add.TodouhukenKana = currentRow(counter)
                                Case 4
                                    Add.SichousonKana = currentRow(counter)
                                Case 5
                                    Add.ChouikiKana = currentRow(counter)
                                Case 6
                                    Add.Todouhuken = currentRow(counter)
                                Case 7
                                    Add.Sichouson = currentRow(counter)
                                Case 8
                                    Add.Chouiki = currentRow(counter)
                            End Select

                        Next

                        lstAddress.Add(Add)

                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        Throw
                    Catch ex As Exception
                        Throw
                    End Try

                End While

            End Using

        Catch ex As Exception
            Throw
        End Try



    End Function


End Class
