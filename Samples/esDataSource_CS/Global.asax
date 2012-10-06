<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        //---------------------------------------------------------------
        // Assign the Loader
        //---------------------------------------------------------------        
        EntitySpaces.Interfaces.esProviderFactory.Factory =
            new EntitySpaces.Loader.esDataProviderFactory();        
    }
       
</script>
