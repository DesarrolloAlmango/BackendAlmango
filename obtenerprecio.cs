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
   public class obtenerprecio : GXProcedure
   {
      public obtenerprecio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public obtenerprecio( IGxContext context )
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
                           out decimal aP4_Precio )
      {
         this.AV2ProveedorID = aP0_ProveedorID;
         this.AV3RubrosId = aP1_RubrosId;
         this.AV4MedidasID = aP2_MedidasID;
         this.AV5InventarioId = aP3_InventarioId;
         this.AV6Precio = 0 ;
         initialize();
         ExecutePrivate();
         aP4_Precio=this.AV6Precio;
      }

      public decimal executeUdp( long aP0_ProveedorID ,
                                 short aP1_RubrosId ,
                                 long aP2_MedidasID ,
                                 long aP3_InventarioId )
      {
         execute(aP0_ProveedorID, aP1_RubrosId, aP2_MedidasID, aP3_InventarioId, out aP4_Precio);
         return AV6Precio ;
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 short aP1_RubrosId ,
                                 long aP2_MedidasID ,
                                 long aP3_InventarioId ,
                                 out decimal aP4_Precio )
      {
         this.AV2ProveedorID = aP0_ProveedorID;
         this.AV3RubrosId = aP1_RubrosId;
         this.AV4MedidasID = aP2_MedidasID;
         this.AV5InventarioId = aP3_InventarioId;
         this.AV6Precio = 0 ;
         SubmitImpl();
         aP4_Precio=this.AV6Precio;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2ProveedorID,(short)AV3RubrosId,(long)AV4MedidasID,(long)AV5InventarioId,(decimal)AV6Precio} ;
         ClassLoader.Execute("aobtenerprecio","GeneXus.Programs","aobtenerprecio", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 5 ) )
         {
            AV6Precio = (decimal)(args[4]) ;
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
      private long AV2ProveedorID ;
      private long AV4MedidasID ;
      private long AV5InventarioId ;
      private decimal AV6Precio ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private decimal aP4_Precio ;
   }

}
