using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class oretrievemapbox : GXProcedure
   {
      public oretrievemapbox( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oretrievemapbox( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_Result )
      {
         this.AV10Result = "" ;
         initialize();
         ExecutePrivate();
         aP0_Result=this.AV10Result;
      }

      public string executeUdp( )
      {
         execute(out aP0_Result);
         return AV10Result ;
      }

      public void executeSubmit( out string aP0_Result )
      {
         this.AV10Result = "" ;
         SubmitImpl();
         aP0_Result=this.AV10Result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new oparametros(context ).execute(  context.GetMessage( "TOKENMAPBOX", ""), out  AV27Token, out  AV28ParametrosNumerico, out  AV29ParametrosEstado) ;
         new oparametros(context ).execute(  context.GetMessage( "STOKENMAPBOX", ""), out  AV30SessionToken, out  AV28ParametrosNumerico, out  AV29ParametrosEstado) ;
         AV8httpclient.Host = context.GetMessage( "api.mapbox.com", "");
         AV8httpclient.Port = 443;
         AV8httpclient.Secure = 1;
         AV8httpclient.BaseURL = context.GetMessage( "/search/searchbox/v1/retrieve/", "");
         AV8httpclient.AddHeader(context.GetMessage( "Content-Type", ""), context.GetMessage( "application/json", ""));
         AV8httpclient.Execute(context.GetMessage( "GET", ""), AV26WebSession.Get(context.GetMessage( "&MapBox_id", ""))+context.GetMessage( "?session_token=05beb917-06ef-45b1-8912-e62db7406c05&access_token=pk.eyJ1IjoibWFwYm94Y3VlbnRhIiwiYSI6ImNtMGQxM3h0aTA3c2YybG9jNmxqcmxxZjYifQ.NvvfF-ebLRB2aJnO5zMqUw", ""));
         if ( AV8httpclient.StatusCode == 200 )
         {
            AV10Result = AV8httpclient.ToString();
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "Error:", "")+StringUtil.Str( (decimal)(AV8httpclient.StatusCode), 10, 2));
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10Result = "";
         AV27Token = "";
         AV29ParametrosEstado = "";
         AV30SessionToken = "";
         AV8httpclient = new GxHttpClient( context);
         AV26WebSession = context.GetSession();
         /* GeneXus formulas. */
      }

      private int AV28ParametrosNumerico ;
      private string AV29ParametrosEstado ;
      private string AV10Result ;
      private string AV27Token ;
      private string AV30SessionToken ;
      private IGxSession AV26WebSession ;
      private GxHttpClient AV8httpclient ;
      private string aP0_Result ;
   }

}
