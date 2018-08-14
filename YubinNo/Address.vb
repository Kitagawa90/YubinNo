
''' <summary>
''' 
''' </summary>
''' <remarks>
''' 
''' </remarks>
Public Class Address

    Private _yubinBango As String
    Private _Todouhuken As String
    Private _Sichouson As String
    Private _Chouiki As String
    Private _TodouhukenKana As String
    Private _SichousonKana As String
    Private _ChouikiKana As String

    ''' <summary>
    ''' 郵便番号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property YubinBango() As String
        Get
            Return _yubinBango
        End Get
        Set(ByVal value As String)
            _yubinBango = value
        End Set
    End Property

    ''' <summary>
    ''' 都道府県
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Property Todouhuken() As String
        Get
            Return _Todouhuken
        End Get
        Set(ByVal value As String)
            _Todouhuken = value
        End Set
    End Property

    ''' <summary>
    ''' 市町村
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property Sichouson() As String
        Get
            Return _Sichouson
        End Get
        Set(ByVal value As String)
            _Sichouson = value
        End Set
    End Property

    ''' <summary>
    '''町域
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property Chouiki() As String
        Get
            Return _Chouiki
        End Get
        Set(ByVal value As String)
            _Chouiki = value
        End Set
    End Property
    ''' <summary>
    ''' 都道府県かな
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property TodouhukenKana() As String
        Get
            Return _TodouhukenKana
        End Get
        Set(ByVal value As String)
            _TodouhukenKana = value
        End Set
    End Property

    ''' <summary>
    ''' 市町村かな
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property SichousonKana() As String
        Get
            Return _SichousonKana
        End Get
        Set(ByVal value As String)
            _SichousonKana = value
        End Set
    End Property

    ''' <summary>
    ''' 町域かな
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property ChouikiKana() As String
        Get
            Return _ChouikiKana
        End Get
        Set(ByVal value As String)
            _ChouikiKana = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return Todouhuken & " " & Sichouson & " " & " " & Chouiki
    End Function

  

End Class
