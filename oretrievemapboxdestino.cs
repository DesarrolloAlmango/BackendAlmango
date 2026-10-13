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
   public class oretrievemapboxdestino : GXProcedure
   {
      public oretrievemapboxdestino( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oretrievemapboxdestino( IGxContext context )
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
         new oparametros(context ).execute(  context.GetMessage( "TOKENMAPBOX", ""), out  AV27Token, out  AV29ParametrosNumerico, out  AV30ParametrosEstado) ;
         new oparametros(context ).execute(  context.GetMessage( "STOKENMAPBOX", ""), out  AV28SessionToken, out  AV29ParametrosNumerico, out  AV30ParametrosEstado) ;
         AV8httpclient.Host = context.GetMessage( "api.mapbox.com", "");
         AV8httpclient.Port = 443;
         AV8httpclient.Secure = 1;
         AV8httpclient.BaseURL = context.GetMessage( "/search/searchbox/v1/retrieve/", "");
         AV8httpclient.AddHeader(context.GetMessage( "Content-Type", ""), context.GetMessage( "application/json", ""));
         AV8httpclient.Execute(context.GetMessage( "GET", ""), AV26WebSession.Get(context.GetMessage( "&MapBox_idDestino", ""))+context.GetMessage( "?session_token=", "")+StringUtil.Trim( AV28SessionToken)+context.GetMessage( "&access_token=", "")+StringUtil.Trim( AV27Token));
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
         AV30ParametrosEstado = "";
         AV28SessionToken = "";
         AV8httpclient = new GxHttpClient( context);
         AV26WebSession = context.GetSession();
         /* GeneXus formulas. */
      }

      private int AV29ParametrosNumerico ;
      private string AV30ParametrosEstado ;
      private string AV28SessionToken ;
      private string AV10Result ;
      private string AV27Token ;
      private IGxSession AV26WebSession ;
      private GxHttpClient AV8httpclient ;
      private string aP0_Result ;
   }

}
