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
   public class ofreezado : GXProcedure
   {
      public ofreezado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public ofreezado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorID ,
                           short aP1_RubrosId ,
                           long aP2_MedidasID ,
                           long aP3_InventarioId ,
                           short aP4_MonedaId ,
                           out bool aP5_Freezar )
      {
         this.AV2ProveedorID = aP0_ProveedorID;
         this.AV3RubrosId = aP1_RubrosId;
         this.AV4MedidasID = aP2_MedidasID;
         this.AV5InventarioId = aP3_InventarioId;
         this.AV6MonedaId = aP4_MonedaId;
         this.AV7Freezar = false ;
         initialize();
         ExecutePrivate();
         aP5_Freezar=this.AV7Freezar;
      }

      public bool executeUdp( long aP0_ProveedorID ,
                              short aP1_RubrosId ,
                              long aP2_MedidasID ,
                              long aP3_InventarioId ,
                              short aP4_MonedaId )
      {
         execute(aP0_ProveedorID, aP1_RubrosId, aP2_MedidasID, aP3_InventarioId, aP4_MonedaId, out aP5_Freezar);
         return AV7Freezar ;
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 short aP1_RubrosId ,
                                 long aP2_MedidasID ,
                                 long aP3_InventarioId ,
                                 short aP4_MonedaId ,
                                 out bool aP5_Freezar )
      {
         this.AV2ProveedorID = aP0_ProveedorID;
         this.AV3RubrosId = aP1_RubrosId;
         this.AV4MedidasID = aP2_MedidasID;
         this.AV5InventarioId = aP3_InventarioId;
         this.AV6MonedaId = aP4_MonedaId;
         this.AV7Freezar = false ;
         SubmitImpl();
         aP5_Freezar=this.AV7Freezar;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2ProveedorID,(short)AV3RubrosId,(long)AV4MedidasID,(long)AV5InventarioId,(short)AV6MonedaId,(bool)AV7Freezar} ;
         ClassLoader.Execute("aofreezado","GeneXus.Programs","aofreezado", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 6 ) )
         {
            AV7Freezar = (bool)(args[5]) ;
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

      private short AV3RubrosId ;
      private short AV6MonedaId ;
      private long AV2ProveedorID ;
      private long AV4MedidasID ;
      private long AV5InventarioId ;
      private bool AV7Freezar ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private bool aP5_Freezar ;
   }

}
