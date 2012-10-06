<%@ Application Language="VB" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        
        '---------------------------------------------------------------
        ' Assign the Loader
        '---------------------------------------------------------------        
        EntitySpaces.Interfaces.esProviderFactory.Factory = _
            New EntitySpaces.Loader.esDataProviderFactory()
        
    End Sub
    

       
</script>