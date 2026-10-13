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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aresttestertool : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aresttestertool( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aresttestertool( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( )
      {
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8httpclient.Host = context.GetMessage( "localhost", "");
         AV8httpclient.BaseURL = AV11httprequest.ScriptPath;
         AV8httpclient.Execute(context.GetMessage( "POST", ""), context.GetMessage( "rest/RESTTestSVC/", ""));
         AV9result = AV8httpclient.ToString();
         if ( StringUtil.StringSearch( AV9result, context.GetMessage( "SUCCESS", ""), 1) >= 0 )
         {
            AV10httpresponse.AddString(AV9result);
         }
         else
         {
            AV10httpresponse.AddString(context.GetMessage( "ERROR - URL Rewrite or REST services not working", ""));
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV8httpclient = new GxHttpClient( context);
         AV11httprequest = new GxHttpRequest( context);
         AV9result = "";
         AV10httpresponse = new GxHttpResponse( context);
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV9result ;
      private bool entryPointCalled ;
      private GxHttpClient AV8httpclient ;
      private GxHttpRequest AV11httprequest ;
      private GxHttpResponse AV10httpresponse ;
   }

}
