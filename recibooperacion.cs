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
   public class recibooperacion : GXProcedure
   {
      public recibooperacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public recibooperacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_OperacionesIdNew ,
                           long aP1_OperacionesId ,
                           string aP2_TipoEntidad ,
                           string aP3_OperacionesRef ,
                           string aP4_NombreRef ,
                           string aP5_TipoOperacion ,
                           decimal aP6_OperacionesImporte )
      {
         this.AV2OperacionesIdNew = aP0_OperacionesIdNew;
         this.AV3OperacionesId = aP1_OperacionesId;
         this.AV4TipoEntidad = aP2_TipoEntidad;
         this.AV5OperacionesRef = aP3_OperacionesRef;
         this.AV6NombreRef = aP4_NombreRef;
         this.AV7TipoOperacion = aP5_TipoOperacion;
         this.AV8OperacionesImporte = aP6_OperacionesImporte;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_OperacionesIdNew ,
                                 long aP1_OperacionesId ,
                                 string aP2_TipoEntidad ,
                                 string aP3_OperacionesRef ,
                                 string aP4_NombreRef ,
                                 string aP5_TipoOperacion ,
                                 decimal aP6_OperacionesImporte )
      {
         this.AV2OperacionesIdNew = aP0_OperacionesIdNew;
         this.AV3OperacionesId = aP1_OperacionesId;
         this.AV4TipoEntidad = aP2_TipoEntidad;
         this.AV5OperacionesRef = aP3_OperacionesRef;
         this.AV6NombreRef = aP4_NombreRef;
         this.AV7TipoOperacion = aP5_TipoOperacion;
         this.AV8OperacionesImporte = aP6_OperacionesImporte;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2OperacionesIdNew,(long)AV3OperacionesId,(string)AV4TipoEntidad,(string)AV5OperacionesRef,(string)AV6NombreRef,(string)AV7TipoOperacion,(decimal)AV8OperacionesImporte} ;
         ClassLoader.Execute("arecibooperacion","GeneXus.Programs","arecibooperacion", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 7 ) )
         {
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
         /* GeneXus formulas. */
      }

      private long AV2OperacionesIdNew ;
      private long AV3OperacionesId ;
      private decimal AV8OperacionesImporte ;
      private string AV4TipoEntidad ;
      private string AV5OperacionesRef ;
      private string AV6NombreRef ;
      private string AV7TipoOperacion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
