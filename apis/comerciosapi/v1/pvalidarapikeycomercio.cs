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
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis.comerciosapi.v1 {
   public class pvalidarapikeycomercio : GXProcedure
   {
      public pvalidarapikeycomercio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pvalidarapikeycomercio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ApiKeyHeader ,
                           out long aP1_ProveedorID ,
                           out long aP2_STComerciosID ,
                           out short aP3_TipoIntegracion ,
                           out bool aP4_ComercioAutenticado )
      {
         this.AV12ApiKeyHeader = aP0_ApiKeyHeader;
         this.AV11ProveedorID = 0 ;
         this.AV10STComerciosID = 0 ;
         this.AV9TipoIntegracion = 0 ;
         this.AV8ComercioAutenticado = false ;
         initialize();
         ExecutePrivate();
         aP1_ProveedorID=this.AV11ProveedorID;
         aP2_STComerciosID=this.AV10STComerciosID;
         aP3_TipoIntegracion=this.AV9TipoIntegracion;
         aP4_ComercioAutenticado=this.AV8ComercioAutenticado;
      }

      public bool executeUdp( string aP0_ApiKeyHeader ,
                              out long aP1_ProveedorID ,
                              out long aP2_STComerciosID ,
                              out short aP3_TipoIntegracion )
      {
         execute(aP0_ApiKeyHeader, out aP1_ProveedorID, out aP2_STComerciosID, out aP3_TipoIntegracion, out aP4_ComercioAutenticado);
         return AV8ComercioAutenticado ;
      }

      public void executeSubmit( string aP0_ApiKeyHeader ,
                                 out long aP1_ProveedorID ,
                                 out long aP2_STComerciosID ,
                                 out short aP3_TipoIntegracion ,
                                 out bool aP4_ComercioAutenticado )
      {
         this.AV12ApiKeyHeader = aP0_ApiKeyHeader;
         this.AV11ProveedorID = 0 ;
         this.AV10STComerciosID = 0 ;
         this.AV9TipoIntegracion = 0 ;
         this.AV8ComercioAutenticado = false ;
         SubmitImpl();
         aP1_ProveedorID=this.AV11ProveedorID;
         aP2_STComerciosID=this.AV10STComerciosID;
         aP3_TipoIntegracion=this.AV9TipoIntegracion;
         aP4_ComercioAutenticado=this.AV8ComercioAutenticado;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8ComercioAutenticado = false;
         /* Using cursor P00MS2 */
         pr_default.execute(0, new Object[] {AV12ApiKeyHeader});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A552ConexionesID = P00MS2_A552ConexionesID[0];
            n552ConexionesID = P00MS2_n552ConexionesID[0];
            A560ConexionesApiKey = P00MS2_A560ConexionesApiKey[0];
            n560ConexionesApiKey = P00MS2_n560ConexionesApiKey[0];
            A562ConexionesEstado = P00MS2_A562ConexionesEstado[0];
            n562ConexionesEstado = P00MS2_n562ConexionesEstado[0];
            A133ProveedorID = P00MS2_A133ProveedorID[0];
            A919STComerciosID = P00MS2_A919STComerciosID[0];
            n919STComerciosID = P00MS2_n919STComerciosID[0];
            A964ConexionesTipoIntegracion = P00MS2_A964ConexionesTipoIntegracion[0];
            n964ConexionesTipoIntegracion = P00MS2_n964ConexionesTipoIntegracion[0];
            A918MapeoID = P00MS2_A918MapeoID[0];
            A560ConexionesApiKey = P00MS2_A560ConexionesApiKey[0];
            n560ConexionesApiKey = P00MS2_n560ConexionesApiKey[0];
            A562ConexionesEstado = P00MS2_A562ConexionesEstado[0];
            n562ConexionesEstado = P00MS2_n562ConexionesEstado[0];
            A964ConexionesTipoIntegracion = P00MS2_A964ConexionesTipoIntegracion[0];
            n964ConexionesTipoIntegracion = P00MS2_n964ConexionesTipoIntegracion[0];
            AV11ProveedorID = A133ProveedorID;
            AV10STComerciosID = A919STComerciosID;
            AV9TipoIntegracion = A964ConexionesTipoIntegracion;
            AV8ComercioAutenticado = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         P00MS2_A552ConexionesID = new string[] {""} ;
         P00MS2_n552ConexionesID = new bool[] {false} ;
         P00MS2_A560ConexionesApiKey = new string[] {""} ;
         P00MS2_n560ConexionesApiKey = new bool[] {false} ;
         P00MS2_A562ConexionesEstado = new string[] {""} ;
         P00MS2_n562ConexionesEstado = new bool[] {false} ;
         P00MS2_A133ProveedorID = new long[1] ;
         P00MS2_A919STComerciosID = new long[1] ;
         P00MS2_n919STComerciosID = new bool[] {false} ;
         P00MS2_A964ConexionesTipoIntegracion = new short[1] ;
         P00MS2_n964ConexionesTipoIntegracion = new bool[] {false} ;
         P00MS2_A918MapeoID = new long[1] ;
         A552ConexionesID = "";
         A560ConexionesApiKey = "";
         A562ConexionesEstado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.comerciosapi.v1.pvalidarapikeycomercio__default(),
            new Object[][] {
                new Object[] {
               P00MS2_A552ConexionesID, P00MS2_n552ConexionesID, P00MS2_A560ConexionesApiKey, P00MS2_n560ConexionesApiKey, P00MS2_A562ConexionesEstado, P00MS2_n562ConexionesEstado, P00MS2_A133ProveedorID, P00MS2_A919STComerciosID, P00MS2_n919STComerciosID, P00MS2_A964ConexionesTipoIntegracion,
               P00MS2_n964ConexionesTipoIntegracion, P00MS2_A918MapeoID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9TipoIntegracion ;
      private short A964ConexionesTipoIntegracion ;
      private long AV11ProveedorID ;
      private long AV10STComerciosID ;
      private long A133ProveedorID ;
      private long A919STComerciosID ;
      private long A918MapeoID ;
      private string A552ConexionesID ;
      private string A560ConexionesApiKey ;
      private string A562ConexionesEstado ;
      private bool AV8ComercioAutenticado ;
      private bool n552ConexionesID ;
      private bool n560ConexionesApiKey ;
      private bool n562ConexionesEstado ;
      private bool n919STComerciosID ;
      private bool n964ConexionesTipoIntegracion ;
      private string AV12ApiKeyHeader ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00MS2_A552ConexionesID ;
      private bool[] P00MS2_n552ConexionesID ;
      private string[] P00MS2_A560ConexionesApiKey ;
      private bool[] P00MS2_n560ConexionesApiKey ;
      private string[] P00MS2_A562ConexionesEstado ;
      private bool[] P00MS2_n562ConexionesEstado ;
      private long[] P00MS2_A133ProveedorID ;
      private long[] P00MS2_A919STComerciosID ;
      private bool[] P00MS2_n919STComerciosID ;
      private short[] P00MS2_A964ConexionesTipoIntegracion ;
      private bool[] P00MS2_n964ConexionesTipoIntegracion ;
      private long[] P00MS2_A918MapeoID ;
      private long aP1_ProveedorID ;
      private long aP2_STComerciosID ;
      private short aP3_TipoIntegracion ;
      private bool aP4_ComercioAutenticado ;
   }

   public class pvalidarapikeycomercio__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00MS2;
          prmP00MS2 = new Object[] {
          new ParDef("@AV12ApiKeyHeader",GXType.NVarChar,128,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MS2", "SELECT TOP 1 T1.[ConexionesID], T2.[ConexionesApiKey], T2.[ConexionesEstado], T1.[ProveedorID], T1.[STComerciosID], T2.[ConexionesTipoIntegracion], T1.[MapeoID] FROM ([ListaMapeo] T1 LEFT JOIN [Conexiones] T2 ON T2.[ConexionesID] = T1.[ConexionesID]) WHERE (RTRIM(LTRIM(T2.[ConexionesApiKey])) = RTRIM(LTRIM(@AV12ApiKeyHeader))) AND (T2.[ConexionesEstado] = 'HAB') ORDER BY T1.[MapeoID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MS2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 9);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 128);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4);
                ((long[]) buf[7])[0] = rslt.getLong(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((long[]) buf[11])[0] = rslt.getLong(7);
                return;
       }
    }

 }

}
