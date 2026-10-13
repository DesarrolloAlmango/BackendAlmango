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
   public class requestgoogleplace : GXProcedure
   {
      public requestgoogleplace( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public requestgoogleplace( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_TextSearch ,
                           out string aP1_result )
      {
         this.AV12TextSearch = aP0_TextSearch;
         this.AV10result = "" ;
         initialize();
         ExecutePrivate();
         aP1_result=this.AV10result;
      }

      public string executeUdp( string aP0_TextSearch )
      {
         execute(aP0_TextSearch, out aP1_result);
         return AV10result ;
      }

      public void executeSubmit( string aP0_TextSearch ,
                                 out string aP1_result )
      {
         this.AV12TextSearch = aP0_TextSearch;
         this.AV10result = "" ;
         SubmitImpl();
         aP1_result=this.AV10result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8httpclient.Host = context.GetMessage( "places.googleapis.com", "");
         AV8httpclient.Port = 443;
         AV8httpclient.Secure = 1;
         AV8httpclient.BaseURL = context.GetMessage( "/v1/places:searchText", "");
         AV8httpclient.AddHeader(context.GetMessage( "Content-Type", ""), context.GetMessage( "application/json", ""));
         AV8httpclient.AddHeader(context.GetMessage( "X-Goog-Api-Key", ""), context.GetMessage( "AIzaSyDtfA6v_vqAxuRULBckahD6qDHRRMHInMs", ""));
         AV8httpclient.AddHeader(context.GetMessage( "X-Goog-FieldMask", ""), context.GetMessage( "places.formattedAddress", ""));
         AV9requestBody = context.GetMessage( "{\"textQuery\": \"Crisostomo alvarez 1190 tucuman\"}", "");
         AV8httpclient.AddHeader(context.GetMessage( "Content-type", ""), context.GetMessage( "application/json", ""));
         AV8httpclient.AddString(context.GetMessage( "{\"textQuery\": \"", "")+AV12TextSearch+"\"}");
         AV8httpclient.Execute(context.GetMessage( "POST", ""), "");
         if ( AV8httpclient.StatusCode == 200 )
         {
            AV10result = AV8httpclient.ToString();
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "Error: ", "")+StringUtil.Str( (decimal)(AV8httpclient.StatusCode), 10, 2)+" - "+AV8httpclient.ToString());
            AV10result = context.GetMessage( "Error.", "");
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
         AV10result = "";
         AV8httpclient = new GxHttpClient( context);
         AV9requestBody = "";
         /* GeneXus formulas. */
      }

      private string AV10result ;
      private string AV9requestBody ;
      private string AV12TextSearch ;
      private GxHttpClient AV8httpclient ;
      private string aP1_result ;
   }

}
