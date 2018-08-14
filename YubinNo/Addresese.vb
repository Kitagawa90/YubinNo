Public Class Addresese
    Private ReadOnly _CsvFilePath As String


    ''' <summary>
    ''' アドレス一覧
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Lists() As List(Of Address)
        Get

            If _Lists Is Nothing Then
                _Lists = CreateData.ToList()
            End If

            Return _Lists
        End Get
    End Property
    Private _Lists As List(Of Address)

    ''' <summary>
    ''' CSVファイルがない場合例外スロー。CAVファイルはEXE直下
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        _CsvFilePath = System.Windows.Forms.Application.StartupPath & "\KEN_ALL.CSV"
    End Sub

    ''' <summary>
    ''' CSVファイルがない場合例外スロー
    ''' </summary>
    ''' <param name="CsvFilePath">住所CSVファイルパス</param>
    Public Sub New(ByVal CsvFilePath As String)
        _CsvFilePath = CsvFilePath
    End Sub


    ''' <summary>
    ''' 住所csvファイルから住所情報作成
    ''' </summary>
    ''' <returns></returns>
    Public Function CreateData() As IEnumerable(Of Address)

        Try
            Dim gcsv As New getAddressCsvData(_CsvFilePath)
            Return gcsv.MakeAddressData()
        Catch ex As Exception
            Throw
        End Try

    End Function

    ''' <summary>
    ''' 住所csvファイルから住所情報作成
    ''' </summary>
    ''' <returns></returns>
    Public Function CreateDictionary() As Dictionary(Of String, Address)
        Return CreateData.ToDictionary(Of String)(Function(x) x.YubinBango)
    End Function

    ''' <summary>
    ''' 郵便番号から住所取得
    ''' </summary>
    ''' <param name="prYubinBango">郵便番号（ハイフンなし）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAddressString(ByVal prYubinBango As String) As String
        Dim wkAddress As String = ""

        Dim terget As Address = CreateData.Where(Function(x) x.YubinBango = prYubinBango).FirstOrDefault

        If terget Is Nothing Then
            Return ""
        End If

        With terget
            wkAddress = .Todouhuken & " " & .Sichouson & " " & .Chouiki
        End With
        Return wkAddress

    End Function

    ''' <summary>
    ''' 郵便番号からAddressクラス取得（Nll注意）
    ''' </summary>
    ''' <param name="prYubinbango"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAddress(ByVal prYubinbango As String) As Address
        Dim terget As Address = CreateData.Where(Function(x) x.YubinBango = prYubinbango).FirstOrDefault
        Return terget
    End Function


End Class
