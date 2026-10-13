using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
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
   public class altamudanzaweb : GXProcedure
   {
      public altamudanzaweb( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public altamudanzaweb( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SDTMudanzaJson ,
                           string aP1_SDTCargaJson ,
                           out long aP2_MudanzaId ,
                           out long aP3_SolicitudId ,
                           out string aP4_Mensaje )
      {
         this.AV2SDTMudanzaJson = aP0_SDTMudanzaJson;
         this.AV3SDTCargaJson = aP1_SDTCargaJson;
         this.AV4MudanzaId = 0 ;
         this.AV5SolicitudId = 0 ;
         this.AV6Mensaje = "" ;
         initialize();
         ExecutePrivate();
         aP2_MudanzaId=this.AV4MudanzaId;
         aP3_SolicitudId=this.AV5SolicitudId;
         aP4_Mensaje=this.AV6Mensaje;
      }

      public string executeUdp( string aP0_SDTMudanzaJson ,
                                string aP1_SDTCargaJson ,
                                out long aP2_MudanzaId ,
                                out long aP3_SolicitudId )
      {
         execute(aP0_SDTMudanzaJson, aP1_SDTCargaJson, out aP2_MudanzaId, out aP3_SolicitudId, out aP4_Mensaje);
         return AV6Mensaje ;
      }

      public void executeSubmit( string aP0_SDTMudanzaJson ,
                                 string aP1_SDTCargaJson ,
                                 out long aP2_MudanzaId ,
                                 out long aP3_SolicitudId ,
                                 out string aP4_Mensaje )
      {
         this.AV2SDTMudanzaJson = aP0_SDTMudanzaJson;
         this.AV3SDTCargaJson = aP1_SDTCargaJson;
         this.AV4MudanzaId = 0 ;
         this.AV5SolicitudId = 0 ;
         this.AV6Mensaje = "" ;
         SubmitImpl();
         aP2_MudanzaId=this.AV4MudanzaId;
         aP3_SolicitudId=this.AV5SolicitudId;
         aP4_Mensaje=this.AV6Mensaje;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2SDTMudanzaJson,(string)AV3SDTCargaJson,(long)AV4MudanzaId,(long)AV5SolicitudId,(string)AV6Mensaje} ;
         ClassLoader.Execute("aaltamudanzaweb","GeneXus.Programs","aaltamudanzaweb", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 5 ) )
         {
            AV4MudanzaId = (long)(args[2]) ;
            AV5SolicitudId = (long)(args[3]) ;
            AV6Mensaje = (string)(args[4]) ;
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
      }

      public override void initialize( )
      {
         AV6Mensaje = "";
         /* GeneXus formulas. */
      }

      private long AV4MudanzaId ;
      private long AV5SolicitudId ;
      private string AV2SDTMudanzaJson ;
      private string AV3SDTCargaJson ;
      private string AV6Mensaje ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private long aP2_MudanzaId ;
      private long aP3_SolicitudId ;
      private string aP4_Mensaje ;
   }

}
