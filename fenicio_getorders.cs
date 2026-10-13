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
   public class fenicio_getorders : GXProcedure
   {
      public fenicio_getorders( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public fenicio_getorders( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_BaseUrl ,
                           string aP1_Estado ,
                           DateTime aP2_FechaDesde ,
                           DateTime aP3_FechaHasta ,
                           short aP4_PageNumber ,
                           short aP5_PageSize ,
                           out SdtSDTFenicioOrdersResponse aP6_OrdersResponse ,
                           out bool aP7_Error ,
                           ref string aP8_DebugLog )
      {
         this.AV8BaseUrl = aP0_BaseUrl;
         this.AV12Estado = aP1_Estado;
         this.AV13FechaDesde = aP2_FechaDesde;
         this.AV14FechaHasta = aP3_FechaHasta;
         this.AV17PageNumber = aP4_PageNumber;
         this.AV18PageSize = aP5_PageSize;
         this.AV16OrdersResponse = new SdtSDTFenicioOrdersResponse(context) ;
         this.AV11Error = false ;
         this.AV9DebugLog = aP8_DebugLog;
         initialize();
         ExecutePrivate();
         aP6_OrdersResponse=this.AV16OrdersResponse;
         aP7_Error=this.AV11Error;
         aP8_DebugLog=this.AV9DebugLog;
      }

      public string executeUdp( string aP0_BaseUrl ,
                                string aP1_Estado ,
                                DateTime aP2_FechaDesde ,
                                DateTime aP3_FechaHasta ,
                                short aP4_PageNumber ,
                                short aP5_PageSize ,
                                out SdtSDTFenicioOrdersResponse aP6_OrdersResponse ,
                                out bool aP7_Error )
      {
         execute(aP0_BaseUrl, aP1_Estado, aP2_FechaDesde, aP3_FechaHasta, aP4_PageNumber, aP5_PageSize, out aP6_OrdersResponse, out aP7_Error, ref aP8_DebugLog);
         return AV9DebugLog ;
      }

      public void executeSubmit( string aP0_BaseUrl ,
                                 string aP1_Estado ,
                                 DateTime aP2_FechaDesde ,
                                 DateTime aP3_FechaHasta ,
                                 short aP4_PageNumber ,
                                 short aP5_PageSize ,
                                 out SdtSDTFenicioOrdersResponse aP6_OrdersResponse ,
                                 out bool aP7_Error ,
                                 ref string aP8_DebugLog )
      {
         this.AV8BaseUrl = aP0_BaseUrl;
         this.AV12Estado = aP1_Estado;
         this.AV13FechaDesde = aP2_FechaDesde;
         this.AV14FechaHasta = aP3_FechaHasta;
         this.AV17PageNumber = aP4_PageNumber;
         this.AV18PageSize = aP5_PageSize;
         this.AV16OrdersResponse = new SdtSDTFenicioOrdersResponse(context) ;
         this.AV11Error = false ;
         this.AV9DebugLog = aP8_DebugLog;
         SubmitImpl();
         aP6_OrdersResponse=this.AV16OrdersResponse;
         aP7_Error=this.AV11Error;
         aP8_DebugLog=this.AV9DebugLog;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11Error = false;
         AV19Url = StringUtil.Trim( AV8BaseUrl);
         AV10DescripcionEstado = context.GetMessage( gxdomainestadoordenfenicio.getDescription(context,AV12Estado), "");
         AV19Url += context.GetMessage( "?estado=", "") + StringUtil.Trim( AV10DescripcionEstado);
         AV19Url += context.GetMessage( "&pag=", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV17PageNumber), 4, 0));
         AV19Url += context.GetMessage( "&tot=", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV18PageSize), 4, 0));
         AV19Url += context.GetMessage( "&fDesde=", "") + StringUtil.Format( context.localUtil.DToC( AV13FechaDesde, 0, "-"), context.GetMessage( "yyyy-MM-dd", ""), "", "", "", "", "", "", "", "");
         AV19Url += context.GetMessage( "&fHasta=", "") + StringUtil.Format( context.localUtil.DToC( AV14FechaHasta, 0, "-"), context.GetMessage( "yyyy-MM-dd", ""), "", "", "", "", "", "", "", "");
         AV9DebugLog += context.GetMessage( "Url formada: ", "") + AV19Url;
         AV15HttpClient = new GxHttpClient( context);
         AV15HttpClient.AddHeader(context.GetMessage( "Content-Type", ""), context.GetMessage( "application/json", ""));
         AV15HttpClient.Execute(context.GetMessage( "GET", ""), AV19Url);
         if ( AV15HttpClient.StatusCode != 200 )
         {
            AV11Error = true;
            cleanup();
            if (true) return;
         }
         AV16OrdersResponse.FromJSonString(AV15HttpClient.ToString(), null);
         if ( AV16OrdersResponse.gxTpr_Error )
         {
            AV11Error = true;
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
         AV16OrdersResponse = new SdtSDTFenicioOrdersResponse(context);
         AV19Url = "";
         AV10DescripcionEstado = "";
         AV15HttpClient = new GxHttpClient( context);
         /* GeneXus formulas. */
      }

      private short AV17PageNumber ;
      private short AV18PageSize ;
      private DateTime AV13FechaDesde ;
      private DateTime AV14FechaHasta ;
      private bool AV11Error ;
      private string AV9DebugLog ;
      private string AV8BaseUrl ;
      private string AV12Estado ;
      private string AV19Url ;
      private string AV10DescripcionEstado ;
      private GxHttpClient AV15HttpClient ;
      private SdtSDTFenicioOrdersResponse AV16OrdersResponse ;
      private string aP8_DebugLog ;
      private SdtSDTFenicioOrdersResponse aP6_OrdersResponse ;
      private bool aP7_Error ;
   }

}
