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
   public class oprecprov : GXProcedure
   {
      public oprecprov( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public oprecprov( IGxContext context )
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
                           out decimal aP5_ProveedorComision ,
                           out string aP6_ProveedorComisionAccion ,
                           out string aP7_ProveedorComisionTipo ,
                           out decimal aP8_InventarioPrecioFinal ,
                           out bool aP9_Freezar )
      {
         this.AV2ProveedorID = aP0_ProveedorID;
         this.AV3RubrosId = aP1_RubrosId;
         this.AV4MedidasID = aP2_MedidasID;
         this.AV5InventarioId = aP3_InventarioId;
         this.AV6MonedaId = aP4_MonedaId;
         this.AV7ProveedorComision = 0 ;
         this.AV8ProveedorComisionAccion = "" ;
         this.AV9ProveedorComisionTipo = "" ;
         this.AV10InventarioPrecioFinal = 0 ;
         this.AV11Freezar = false ;
         initialize();
         ExecutePrivate();
         aP5_ProveedorComision=this.AV7ProveedorComision;
         aP6_ProveedorComisionAccion=this.AV8ProveedorComisionAccion;
         aP7_ProveedorComisionTipo=this.AV9ProveedorComisionTipo;
         aP8_InventarioPrecioFinal=this.AV10InventarioPrecioFinal;
         aP9_Freezar=this.AV11Freezar;
      }

      public bool executeUdp( long aP0_ProveedorID ,
                              short aP1_RubrosId ,
                              long aP2_MedidasID ,
                              long aP3_InventarioId ,
                              short aP4_MonedaId ,
                              out decimal aP5_ProveedorComision ,
                              out string aP6_ProveedorComisionAccion ,
                              out string aP7_ProveedorComisionTipo ,
                              out decimal aP8_InventarioPrecioFinal )
      {
         execute(aP0_ProveedorID, aP1_RubrosId, aP2_MedidasID, aP3_InventarioId, aP4_MonedaId, out aP5_ProveedorComision, out aP6_ProveedorComisionAccion, out aP7_ProveedorComisionTipo, out aP8_InventarioPrecioFinal, out aP9_Freezar);
         return AV11Freezar ;
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 short aP1_RubrosId ,
                                 long aP2_MedidasID ,
                                 long aP3_InventarioId ,
                                 short aP4_MonedaId ,
                                 out decimal aP5_ProveedorComision ,
                                 out string aP6_ProveedorComisionAccion ,
                                 out string aP7_ProveedorComisionTipo ,
                                 out decimal aP8_InventarioPrecioFinal ,
                                 out bool aP9_Freezar )
      {
         this.AV2ProveedorID = aP0_ProveedorID;
         this.AV3RubrosId = aP1_RubrosId;
         this.AV4MedidasID = aP2_MedidasID;
         this.AV5InventarioId = aP3_InventarioId;
         this.AV6MonedaId = aP4_MonedaId;
         this.AV7ProveedorComision = 0 ;
         this.AV8ProveedorComisionAccion = "" ;
         this.AV9ProveedorComisionTipo = "" ;
         this.AV10InventarioPrecioFinal = 0 ;
         this.AV11Freezar = false ;
         SubmitImpl();
         aP5_ProveedorComision=this.AV7ProveedorComision;
         aP6_ProveedorComisionAccion=this.AV8ProveedorComisionAccion;
         aP7_ProveedorComisionTipo=this.AV9ProveedorComisionTipo;
         aP8_InventarioPrecioFinal=this.AV10InventarioPrecioFinal;
         aP9_Freezar=this.AV11Freezar;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2ProveedorID,(short)AV3RubrosId,(long)AV4MedidasID,(long)AV5InventarioId,(short)AV6MonedaId,(decimal)AV7ProveedorComision,(string)AV8ProveedorComisionAccion,(string)AV9ProveedorComisionTipo,(decimal)AV10InventarioPrecioFinal,(bool)AV11Freezar} ;
         ClassLoader.Execute("aoprecprov","GeneXus.Programs","aoprecprov", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 10 ) )
         {
            AV7ProveedorComision = (decimal)(args[5]) ;
            AV8ProveedorComisionAccion = (string)(args[6]) ;
            AV9ProveedorComisionTipo = (string)(args[7]) ;
            AV10InventarioPrecioFinal = (decimal)(args[8]) ;
            AV11Freezar = (bool)(args[9]) ;
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
         AV8ProveedorComisionAccion = "";
         AV9ProveedorComisionTipo = "";
         /* GeneXus formulas. */
      }

      private short AV3RubrosId ;
      private short AV6MonedaId ;
      private long AV2ProveedorID ;
      private long AV4MedidasID ;
      private long AV5InventarioId ;
      private decimal AV7ProveedorComision ;
      private decimal AV10InventarioPrecioFinal ;
      private string AV8ProveedorComisionAccion ;
      private string AV9ProveedorComisionTipo ;
      private bool AV11Freezar ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private decimal aP5_ProveedorComision ;
      private string aP6_ProveedorComisionAccion ;
      private string aP7_ProveedorComisionTipo ;
      private decimal aP8_InventarioPrecioFinal ;
      private bool aP9_Freezar ;
   }

}
