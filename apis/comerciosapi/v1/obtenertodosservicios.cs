using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis.comerciosapi.v1 {
   public class obtenertodosservicios : GXProcedure
   {
      public obtenertodosservicios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenertodosservicios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out bool aP0_Error ,
                           out string aP1_Msj ,
                           out GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio> aP2_ListaServicios ,
                           out short aP3_Gx_restcode )
      {
         this.AV10Error = false ;
         this.AV13Msj = "" ;
         this.AV12ListaServicios = new GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio>( context, "SDT_Servicio", "AlmangoX") ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP0_Error=this.AV10Error;
         aP1_Msj=this.AV13Msj;
         aP2_ListaServicios=this.AV12ListaServicios;
         aP3_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( out bool aP0_Error ,
                               out string aP1_Msj ,
                               out GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio> aP2_ListaServicios )
      {
         execute(out aP0_Error, out aP1_Msj, out aP2_ListaServicios, out aP3_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( out bool aP0_Error ,
                                 out string aP1_Msj ,
                                 out GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio> aP2_ListaServicios ,
                                 out short aP3_Gx_restcode )
      {
         this.AV10Error = false ;
         this.AV13Msj = "" ;
         this.AV12ListaServicios = new GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio>( context, "SDT_Servicio", "AlmangoX") ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP0_Error=this.AV10Error;
         aP1_Msj=this.AV13Msj;
         aP2_ListaServicios=this.AV12ListaServicios;
         aP3_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Error = false;
         AV13Msj = "";
         AV12ListaServicios = new GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio>( context, "SDT_Servicio", "AlmangoX");
         AV8ApiKeyHeader = AV11HttpRequest.GetHeader(context.GetMessage( "x-api-key", ""));
         new GeneXus.Programs.apis.comerciosapi.v1.pvalidarapikeycomercio(context ).execute(  AV8ApiKeyHeader, out  AV14ProveedorID, out  AV19STComerciosID, out  AV20TipoIntegracion, out  AV9ComercioAutenticado) ;
         if ( ! AV9ComercioAutenticado )
         {
            Gx_restcode = 401;
            AV10Error = true;
            AV13Msj = context.GetMessage( "No autorizado. Verifique su API Key.", "");
            cleanup();
            if (true) return;
         }
         /* Using cursor P00MY2 */
         pr_default.execute(0, new Object[] {AV14ProveedorID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A139MedidasEstado = P00MY2_A139MedidasEstado[0];
            n139MedidasEstado = P00MY2_n139MedidasEstado[0];
            A123RubrosEstado = P00MY2_A123RubrosEstado[0];
            n123RubrosEstado = P00MY2_n123RubrosEstado[0];
            A108EstadosGenericosId = P00MY2_A108EstadosGenericosId[0];
            A107EstadosTipo = P00MY2_A107EstadosTipo[0];
            A133ProveedorID = P00MY2_A133ProveedorID[0];
            A135InventarioId = P00MY2_A135InventarioId[0];
            n135InventarioId = P00MY2_n135InventarioId[0];
            A137MedidasID = P00MY2_A137MedidasID[0];
            A121RubrosId = P00MY2_A121RubrosId[0];
            A157ProveedorComisionID = P00MY2_A157ProveedorComisionID[0];
            A123RubrosEstado = P00MY2_A123RubrosEstado[0];
            n123RubrosEstado = P00MY2_n123RubrosEstado[0];
            A139MedidasEstado = P00MY2_A139MedidasEstado[0];
            n139MedidasEstado = P00MY2_n139MedidasEstado[0];
            A108EstadosGenericosId = P00MY2_A108EstadosGenericosId[0];
            A107EstadosTipo = P00MY2_A107EstadosTipo[0];
            if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "INV", "")) == 0 )
            {
               AV18SKU = context.GetMessage( "amg", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
               new GeneXus.Programs.apis.comerciosapi.v1.pobtenerservicioyprecio(context ).execute(  AV14ProveedorID,  A121RubrosId,  A137MedidasID,  A135InventarioId, out  AV16ServicioElemento, out  AV17ServicioEncontrado) ;
               if ( AV17ServicioEncontrado )
               {
                  AV16ServicioElemento.gxTpr_Codigoservicio = AV18SKU;
                  AV12ListaServicios.Add(AV16ServicioElemento, 0);
                  AV16ServicioElemento = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio(context);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Gx_restcode = 200;
         AV10Error = false;
         AV13Msj = context.GetMessage( "Catálogo obtenido exitosamente.", "");
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
         AV13Msj = "";
         AV12ListaServicios = new GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio>( context, "SDT_Servicio", "AlmangoX");
         AV8ApiKeyHeader = "";
         AV11HttpRequest = new GxHttpRequest( context);
         P00MY2_A139MedidasEstado = new string[] {""} ;
         P00MY2_n139MedidasEstado = new bool[] {false} ;
         P00MY2_A123RubrosEstado = new string[] {""} ;
         P00MY2_n123RubrosEstado = new bool[] {false} ;
         P00MY2_A108EstadosGenericosId = new int[1] ;
         P00MY2_A107EstadosTipo = new string[] {""} ;
         P00MY2_A133ProveedorID = new long[1] ;
         P00MY2_A135InventarioId = new long[1] ;
         P00MY2_n135InventarioId = new bool[] {false} ;
         P00MY2_A137MedidasID = new long[1] ;
         P00MY2_A121RubrosId = new short[1] ;
         P00MY2_A157ProveedorComisionID = new long[1] ;
         A139MedidasEstado = "";
         A123RubrosEstado = "";
         A107EstadosTipo = "";
         AV18SKU = "";
         AV16ServicioElemento = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.comerciosapi.v1.obtenertodosservicios__default(),
            new Object[][] {
                new Object[] {
               P00MY2_A139MedidasEstado, P00MY2_n139MedidasEstado, P00MY2_A123RubrosEstado, P00MY2_n123RubrosEstado, P00MY2_A108EstadosGenericosId, P00MY2_A107EstadosTipo, P00MY2_A133ProveedorID, P00MY2_A135InventarioId, P00MY2_n135InventarioId, P00MY2_A137MedidasID,
               P00MY2_A121RubrosId, P00MY2_A157ProveedorComisionID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV20TipoIntegracion ;
      private short A121RubrosId ;
      private int A108EstadosGenericosId ;
      private long AV14ProveedorID ;
      private long AV19STComerciosID ;
      private long A133ProveedorID ;
      private long A135InventarioId ;
      private long A137MedidasID ;
      private long A157ProveedorComisionID ;
      private string A139MedidasEstado ;
      private string A123RubrosEstado ;
      private string A107EstadosTipo ;
      private bool AV10Error ;
      private bool AV9ComercioAutenticado ;
      private bool n139MedidasEstado ;
      private bool n123RubrosEstado ;
      private bool n135InventarioId ;
      private bool AV17ServicioEncontrado ;
      private string AV13Msj ;
      private string AV8ApiKeyHeader ;
      private string AV18SKU ;
      private GxHttpRequest AV11HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio> AV12ListaServicios ;
      private IDataStoreProvider pr_default ;
      private string[] P00MY2_A139MedidasEstado ;
      private bool[] P00MY2_n139MedidasEstado ;
      private string[] P00MY2_A123RubrosEstado ;
      private bool[] P00MY2_n123RubrosEstado ;
      private int[] P00MY2_A108EstadosGenericosId ;
      private string[] P00MY2_A107EstadosTipo ;
      private long[] P00MY2_A133ProveedorID ;
      private long[] P00MY2_A135InventarioId ;
      private bool[] P00MY2_n135InventarioId ;
      private long[] P00MY2_A137MedidasID ;
      private short[] P00MY2_A121RubrosId ;
      private long[] P00MY2_A157ProveedorComisionID ;
      private GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio AV16ServicioElemento ;
      private bool aP0_Error ;
      private string aP1_Msj ;
      private GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio> aP2_ListaServicios ;
      private short aP3_Gx_restcode ;
   }

   public class obtenertodosservicios__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00MY2;
          prmP00MY2 = new Object[] {
          new ParDef("@AV14ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MY2", "SELECT T3.[MedidasEstado], T2.[RubrosEstado], T4.[EstadosGenericosId], T4.[EstadosTipo], T1.[ProveedorID], T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T1.[ProveedorComisionID] FROM ((([ProveedorComision] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) LEFT JOIN [Inventario] T4 ON T4.[RubrosId] = T1.[RubrosId] AND T4.[MedidasID] = T1.[MedidasID] AND T4.[InventarioId] = T1.[InventarioId]) WHERE (T1.[ProveedorID] = @AV14ProveedorID) AND (T4.[EstadosGenericosId] = 1) AND (T2.[RubrosEstado] = 'HAB') AND (T3.[MedidasEstado] = 'HAB') ORDER BY T1.[ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MY2,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 3);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((long[]) buf[9])[0] = rslt.getLong(7);
                ((short[]) buf[10])[0] = rslt.getShort(8);
                ((long[]) buf[11])[0] = rslt.getLong(9);
                return;
       }
    }

 }

}
