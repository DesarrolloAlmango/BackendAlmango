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
   public class altamudanzasolefectivo : GXProcedure
   {
      public altamudanzasolefectivo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public altamudanzasolefectivo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtMudanza aP0_Mudanza ,
                           out long aP1_SolicitudesId ,
                           out string aP2_Mensaje )
      {
         this.AV2Mudanza = aP0_Mudanza;
         this.AV3SolicitudesId = 0 ;
         this.AV4Mensaje = "" ;
         initialize();
         ExecutePrivate();
         aP1_SolicitudesId=this.AV3SolicitudesId;
         aP2_Mensaje=this.AV4Mensaje;
      }

      public string executeUdp( SdtMudanza aP0_Mudanza ,
                                out long aP1_SolicitudesId )
      {
         execute(aP0_Mudanza, out aP1_SolicitudesId, out aP2_Mensaje);
         return AV4Mensaje ;
      }

      public void executeSubmit( SdtMudanza aP0_Mudanza ,
                                 out long aP1_SolicitudesId ,
                                 out string aP2_Mensaje )
      {
         this.AV2Mudanza = aP0_Mudanza;
         this.AV3SolicitudesId = 0 ;
         this.AV4Mensaje = "" ;
         SubmitImpl();
         aP1_SolicitudesId=this.AV3SolicitudesId;
         aP2_Mensaje=this.AV4Mensaje;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(SdtMudanza)AV2Mudanza,(long)AV3SolicitudesId,(string)AV4Mensaje} ;
         ClassLoader.Execute("aaltamudanzasolefectivo","GeneXus.Programs","aaltamudanzasolefectivo", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV3SolicitudesId = (long)(args[1]) ;
            AV4Mensaje = (string)(args[2]) ;
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
         AV4Mensaje = "";
         /* GeneXus formulas. */
      }

      private long AV3SolicitudesId ;
      private string AV4Mensaje ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtMudanza AV2Mudanza ;
      private Object[] args ;
      private long aP1_SolicitudesId ;
      private string aP2_Mensaje ;
   }

}
