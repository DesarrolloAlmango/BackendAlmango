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
   public class obteneridbycoordenadas : GXProcedure
   {
      public obteneridbycoordenadas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obteneridbycoordenadas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Latitud ,
                           string aP1_Longitud ,
                           out string aP2_Result )
      {
         this.AV39Latitud = aP0_Latitud;
         this.AV38Longitud = aP1_Longitud;
         this.AV34Result = "" ;
         initialize();
         ExecutePrivate();
         aP2_Result=this.AV34Result;
      }

      public string executeUdp( string aP0_Latitud ,
                                string aP1_Longitud )
      {
         execute(aP0_Latitud, aP1_Longitud, out aP2_Result);
         return AV34Result ;
      }

      public void executeSubmit( string aP0_Latitud ,
                                 string aP1_Longitud ,
                                 out string aP2_Result )
      {
         this.AV39Latitud = aP0_Latitud;
         this.AV38Longitud = aP1_Longitud;
         this.AV34Result = "" ;
         SubmitImpl();
         aP2_Result=this.AV34Result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new oparametros(context ).execute(  context.GetMessage( "TOKENMAPBOX", ""), out  AV37Token, out  AV30ParametrosNumerico, out  AV29ParametrosEstado) ;
         new oparametros(context ).execute(  context.GetMessage( "STOKENMAPBOX", ""), out  AV35SessionToken, out  AV30ParametrosNumerico, out  AV29ParametrosEstado) ;
         AV21httpclient.Host = context.GetMessage( "api.mapbox.com", "");
         AV21httpclient.Port = 443;
         AV21httpclient.Secure = 1;
         AV21httpclient.BaseURL = context.GetMessage( "/search/searchbox/v1/reverse", "");
         AV21httpclient.AddHeader(context.GetMessage( "Content-Type", ""), context.GetMessage( "application/json", ""));
         AV21httpclient.Execute(context.GetMessage( "GET", ""), context.GetMessage( "?longitude=", "")+StringUtil.Trim( AV38Longitud)+context.GetMessage( "&latitude=", "")+StringUtil.Trim( AV39Latitud)+context.GetMessage( "&access_token=pk.eyJ1IjoiYWxtYW5nby0yMDI0IiwiYSI6ImNtMnRncWp5dTAydW0yanB4ZmVvNDVreXMifQ.CmZhTMAuivTcsDGCklAEYg", ""));
         if ( AV21httpclient.StatusCode == 200 )
         {
            AV34Result = AV21httpclient.ToString();
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "Error:", "")+StringUtil.Str( (decimal)(AV21httpclient.StatusCode), 10, 2));
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
         AV34Result = "";
         AV37Token = "";
         AV29ParametrosEstado = "";
         AV35SessionToken = "";
         AV21httpclient = new GxHttpClient( context);
         /* GeneXus formulas. */
      }

      private int AV30ParametrosNumerico ;
      private string AV29ParametrosEstado ;
      private string AV34Result ;
      private string AV39Latitud ;
      private string AV38Longitud ;
      private string AV37Token ;
      private string AV35SessionToken ;
      private GxHttpClient AV21httpclient ;
      private string aP2_Result ;
   }

}
