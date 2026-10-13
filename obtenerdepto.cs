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
   public class obtenerdepto : GXProcedure
   {
      public obtenerdepto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public obtenerdepto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDTDepartamento> aP0_SDTDepartamento )
      {
         this.AV2SDTDepartamento = new GXBaseCollection<SdtSDTDepartamento>( context, "SDTDepartamento", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP0_SDTDepartamento=this.AV2SDTDepartamento;
      }

      public GXBaseCollection<SdtSDTDepartamento> executeUdp( )
      {
         execute(out aP0_SDTDepartamento);
         return AV2SDTDepartamento ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTDepartamento> aP0_SDTDepartamento )
      {
         this.AV2SDTDepartamento = new GXBaseCollection<SdtSDTDepartamento>( context, "SDTDepartamento", "AlmangoX") ;
         SubmitImpl();
         aP0_SDTDepartamento=this.AV2SDTDepartamento;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(GXBaseCollection<SdtSDTDepartamento>)AV2SDTDepartamento} ;
         ClassLoader.Execute("aobtenerdepto","GeneXus.Programs","aobtenerdepto", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2SDTDepartamento = (GXBaseCollection<SdtSDTDepartamento>)(args[0]) ;
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
         AV2SDTDepartamento = new GXBaseCollection<SdtSDTDepartamento>( context, "SDTDepartamento", "AlmangoX");
         /* GeneXus formulas. */
      }

      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTDepartamento> AV2SDTDepartamento ;
      private Object[] args ;
      private GXBaseCollection<SdtSDTDepartamento> aP0_SDTDepartamento ;
   }

}
