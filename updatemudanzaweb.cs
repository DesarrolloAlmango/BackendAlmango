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
   public class updatemudanzaweb : GXProcedure
   {
      public updatemudanzaweb( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public updatemudanzaweb( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_MudanzaId ,
                           string aP1_SDTMudanzaJson ,
                           string aP2_SDTCargaJson ,
                           out string aP3_Mensaje )
      {
         this.AV2MudanzaId = aP0_MudanzaId;
         this.AV3SDTMudanzaJson = aP1_SDTMudanzaJson;
         this.AV4SDTCargaJson = aP2_SDTCargaJson;
         this.AV5Mensaje = "" ;
         initialize();
         ExecutePrivate();
         aP3_Mensaje=this.AV5Mensaje;
      }

      public string executeUdp( long aP0_MudanzaId ,
                                string aP1_SDTMudanzaJson ,
                                string aP2_SDTCargaJson )
      {
         execute(aP0_MudanzaId, aP1_SDTMudanzaJson, aP2_SDTCargaJson, out aP3_Mensaje);
         return AV5Mensaje ;
      }

      public void executeSubmit( long aP0_MudanzaId ,
                                 string aP1_SDTMudanzaJson ,
                                 string aP2_SDTCargaJson ,
                                 out string aP3_Mensaje )
      {
         this.AV2MudanzaId = aP0_MudanzaId;
         this.AV3SDTMudanzaJson = aP1_SDTMudanzaJson;
         this.AV4SDTCargaJson = aP2_SDTCargaJson;
         this.AV5Mensaje = "" ;
         SubmitImpl();
         aP3_Mensaje=this.AV5Mensaje;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2MudanzaId,(string)AV3SDTMudanzaJson,(string)AV4SDTCargaJson,(string)AV5Mensaje} ;
         ClassLoader.Execute("aupdatemudanzaweb","GeneXus.Programs","aupdatemudanzaweb", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 4 ) )
         {
            AV5Mensaje = (string)(args[3]) ;
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
         AV5Mensaje = "";
         /* GeneXus formulas. */
      }

      private long AV2MudanzaId ;
      private string AV3SDTMudanzaJson ;
      private string AV4SDTCargaJson ;
      private string AV5Mensaje ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP3_Mensaje ;
   }

}
