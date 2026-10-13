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
   public class osuggestmapbox : GXProcedure
   {
      public osuggestmapbox( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public osuggestmapbox( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Calle ,
                           string aP1_Origen ,
                           out string aP2_result )
      {
         this.AV19Calle = aP0_Calle;
         this.AV24Origen = aP1_Origen;
         this.AV10result = "" ;
         initialize();
         ExecutePrivate();
         aP2_result=this.AV10result;
      }

      public string executeUdp( string aP0_Calle ,
                                string aP1_Origen )
      {
         execute(aP0_Calle, aP1_Origen, out aP2_result);
         return AV10result ;
      }

      public void executeSubmit( string aP0_Calle ,
                                 string aP1_Origen ,
                                 out string aP2_result )
      {
         this.AV19Calle = aP0_Calle;
         this.AV24Origen = aP1_Origen;
         this.AV10result = "" ;
         SubmitImpl();
         aP2_result=this.AV10result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new oparametros(context ).execute(  context.GetMessage( "TOKENMAPBOX", ""), out  AV26Token, out  AV28ParametrosNumerico, out  AV29ParametrosEstado) ;
         new oparametros(context ).execute(  context.GetMessage( "STOKENMAPBOX", ""), out  AV27SessionToken, out  AV28ParametrosNumerico, out  AV29ParametrosEstado) ;
         AV8httpclient.Host = context.GetMessage( "api.mapbox.com", "");
         AV8httpclient.Port = 443;
         AV8httpclient.Secure = 1;
         AV8httpclient.BaseURL = context.GetMessage( "/search/searchbox/v1/", "");
         AV8httpclient.AddHeader(context.GetMessage( "Content-Type", ""), context.GetMessage( "application/json", ""));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24Origen)) )
         {
            AV8httpclient.Execute(context.GetMessage( "GET", ""), context.GetMessage( "suggest?q=", "")+StringUtil.Trim( AV19Calle)+context.GetMessage( "&language=es&country=uy&limit=10&session_token=", "")+StringUtil.Trim( AV27SessionToken)+context.GetMessage( "&access_token=", "")+StringUtil.Trim( AV26Token));
         }
         else
         {
            AV8httpclient.Execute(context.GetMessage( "GET", ""), context.GetMessage( "suggest?q=", "")+StringUtil.Trim( AV19Calle)+context.GetMessage( "&language=es&country=uy&limit=10&proximity=-83.748708,42.265837&navigation_profile=driving&origin=", "")+AV24Origen+context.GetMessage( "&session_token=", "")+StringUtil.Trim( AV27SessionToken)+context.GetMessage( "&access_token=", "")+StringUtil.Trim( AV26Token));
         }
         if ( AV8httpclient.StatusCode == 200 )
         {
            AV10result = AV8httpclient.ToString();
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
         AV10result = "";
         AV26Token = "";
         AV29ParametrosEstado = "";
         AV27SessionToken = "";
         AV8httpclient = new GxHttpClient( context);
         /* GeneXus formulas. */
      }

      private int AV28ParametrosNumerico ;
      private string AV29ParametrosEstado ;
      private string AV27SessionToken ;
      private string AV10result ;
      private string AV19Calle ;
      private string AV24Origen ;
      private string AV26Token ;
      private GxHttpClient AV8httpclient ;
      private string aP2_result ;
   }

}
