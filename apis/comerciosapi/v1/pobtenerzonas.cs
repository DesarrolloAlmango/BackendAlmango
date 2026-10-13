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
   public class pobtenerzonas : GXProcedure
   {
      public pobtenerzonas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pobtenerzonas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out bool aP0_Error ,
                           out string aP1_Msj ,
                           out GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem> aP2_Departamentos ,
                           out short aP3_Gx_restcode )
      {
         this.AV12Error = false ;
         this.AV14Msj = "" ;
         this.AV10Departamentos = new GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem>( context, "SDT_ApiZonas.DepartamentosItem", "AlmangoX") ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP0_Error=this.AV12Error;
         aP1_Msj=this.AV14Msj;
         aP2_Departamentos=this.AV10Departamentos;
         aP3_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( out bool aP0_Error ,
                               out string aP1_Msj ,
                               out GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem> aP2_Departamentos )
      {
         execute(out aP0_Error, out aP1_Msj, out aP2_Departamentos, out aP3_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( out bool aP0_Error ,
                                 out string aP1_Msj ,
                                 out GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem> aP2_Departamentos ,
                                 out short aP3_Gx_restcode )
      {
         this.AV12Error = false ;
         this.AV14Msj = "" ;
         this.AV10Departamentos = new GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem>( context, "SDT_ApiZonas.DepartamentosItem", "AlmangoX") ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP0_Error=this.AV12Error;
         aP1_Msj=this.AV14Msj;
         aP2_Departamentos=this.AV10Departamentos;
         aP3_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8ApiKeyHeader = AV13HttpRequest.GetHeader(context.GetMessage( "x-api-key", ""));
         new GeneXus.Programs.apis.comerciosapi.v1.pvalidarapikeycomercio(context ).execute(  AV8ApiKeyHeader, out  AV16ProveedorID, out  AV17STComerciosID, out  AV18TipoIntegracion, out  AV9ComercioAutenticado) ;
         if ( ! AV9ComercioAutenticado )
         {
            Gx_restcode = 401;
            AV12Error = true;
            AV14Msj = context.GetMessage( "No autorizado. Verifique su API Key.", "");
            cleanup();
            if (true) return;
         }
         AV10Departamentos = new GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem>( context, "SDT_ApiZonas.DepartamentosItem", "AlmangoX");
         /* Using cursor P00N62 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112DepartamentoId = P00N62_A112DepartamentoId[0];
            A966DepartamentoIntegracionEcommer = P00N62_A966DepartamentoIntegracionEcommer[0];
            n966DepartamentoIntegracionEcommer = P00N62_n966DepartamentoIntegracionEcommer[0];
            A907DepartamentoEstado = P00N62_A907DepartamentoEstado[0];
            n907DepartamentoEstado = P00N62_n907DepartamentoEstado[0];
            A113DepartamentoDepartamento = P00N62_A113DepartamentoDepartamento[0];
            if ( StringUtil.StrCmp(A907DepartamentoEstado, context.GetMessage( "DES", "")) != 0 )
            {
               AV11DeptoItem = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem(context);
               AV11DeptoItem.gxTpr_Id = A112DepartamentoId;
               AV11DeptoItem.gxTpr_Nombre = A113DepartamentoDepartamento;
               /* Using cursor P00N63 */
               pr_default.execute(1, new Object[] {A112DepartamentoId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A967DepartamentoMunicipioIntegraci = P00N63_A967DepartamentoMunicipioIntegraci[0];
                  n967DepartamentoMunicipioIntegraci = P00N63_n967DepartamentoMunicipioIntegraci[0];
                  A908DepartamentoMunicipioEstado = P00N63_A908DepartamentoMunicipioEstado[0];
                  n908DepartamentoMunicipioEstado = P00N63_n908DepartamentoMunicipioEstado[0];
                  A114DepartamentoMunicipioId = P00N63_A114DepartamentoMunicipioId[0];
                  A115DepartamentoMunicipioNombre = P00N63_A115DepartamentoMunicipioNombre[0];
                  A863DepartamentoMunicipioCosto = P00N63_A863DepartamentoMunicipioCosto[0];
                  if ( StringUtil.StrCmp(A908DepartamentoMunicipioEstado, context.GetMessage( "DES", "")) != 0 )
                  {
                     AV15MuniItem = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem(context);
                     AV15MuniItem.gxTpr_Id = A114DepartamentoMunicipioId;
                     AV15MuniItem.gxTpr_Nombre = A115DepartamentoMunicipioNombre;
                     AV15MuniItem.gxTpr_Costoadicional = A863DepartamentoMunicipioCosto;
                     AV11DeptoItem.gxTpr_Municipios.Add(AV15MuniItem, 0);
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               if ( AV11DeptoItem.gxTpr_Municipios.Count > 0 )
               {
                  AV10Departamentos.Add(AV11DeptoItem, 0);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV12Error = false;
         AV14Msj = context.GetMessage( "Zonas obtenidas correctamente.", "");
         Gx_restcode = 200;
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
         AV14Msj = "";
         AV10Departamentos = new GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem>( context, "SDT_ApiZonas.DepartamentosItem", "AlmangoX");
         AV8ApiKeyHeader = "";
         AV13HttpRequest = new GxHttpRequest( context);
         P00N62_A112DepartamentoId = new long[1] ;
         P00N62_A966DepartamentoIntegracionEcommer = new string[] {""} ;
         P00N62_n966DepartamentoIntegracionEcommer = new bool[] {false} ;
         P00N62_A907DepartamentoEstado = new string[] {""} ;
         P00N62_n907DepartamentoEstado = new bool[] {false} ;
         P00N62_A113DepartamentoDepartamento = new string[] {""} ;
         A966DepartamentoIntegracionEcommer = "";
         A907DepartamentoEstado = "";
         A113DepartamentoDepartamento = "";
         AV11DeptoItem = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem(context);
         P00N63_A112DepartamentoId = new long[1] ;
         P00N63_A967DepartamentoMunicipioIntegraci = new string[] {""} ;
         P00N63_n967DepartamentoMunicipioIntegraci = new bool[] {false} ;
         P00N63_A908DepartamentoMunicipioEstado = new string[] {""} ;
         P00N63_n908DepartamentoMunicipioEstado = new bool[] {false} ;
         P00N63_A114DepartamentoMunicipioId = new long[1] ;
         P00N63_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P00N63_A863DepartamentoMunicipioCosto = new decimal[1] ;
         A967DepartamentoMunicipioIntegraci = "";
         A908DepartamentoMunicipioEstado = "";
         A115DepartamentoMunicipioNombre = "";
         AV15MuniItem = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.comerciosapi.v1.pobtenerzonas__default(),
            new Object[][] {
                new Object[] {
               P00N62_A112DepartamentoId, P00N62_A966DepartamentoIntegracionEcommer, P00N62_n966DepartamentoIntegracionEcommer, P00N62_A907DepartamentoEstado, P00N62_n907DepartamentoEstado, P00N62_A113DepartamentoDepartamento
               }
               , new Object[] {
               P00N63_A112DepartamentoId, P00N63_A967DepartamentoMunicipioIntegraci, P00N63_n967DepartamentoMunicipioIntegraci, P00N63_A908DepartamentoMunicipioEstado, P00N63_n908DepartamentoMunicipioEstado, P00N63_A114DepartamentoMunicipioId, P00N63_A115DepartamentoMunicipioNombre, P00N63_A863DepartamentoMunicipioCosto
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV18TipoIntegracion ;
      private long AV16ProveedorID ;
      private long AV17STComerciosID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private decimal A863DepartamentoMunicipioCosto ;
      private string A966DepartamentoIntegracionEcommer ;
      private string A907DepartamentoEstado ;
      private string A113DepartamentoDepartamento ;
      private string A967DepartamentoMunicipioIntegraci ;
      private string A908DepartamentoMunicipioEstado ;
      private string A115DepartamentoMunicipioNombre ;
      private bool AV12Error ;
      private bool AV9ComercioAutenticado ;
      private bool n966DepartamentoIntegracionEcommer ;
      private bool n907DepartamentoEstado ;
      private bool n967DepartamentoMunicipioIntegraci ;
      private bool n908DepartamentoMunicipioEstado ;
      private string AV14Msj ;
      private string AV8ApiKeyHeader ;
      private GxHttpRequest AV13HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem> AV10Departamentos ;
      private IDataStoreProvider pr_default ;
      private long[] P00N62_A112DepartamentoId ;
      private string[] P00N62_A966DepartamentoIntegracionEcommer ;
      private bool[] P00N62_n966DepartamentoIntegracionEcommer ;
      private string[] P00N62_A907DepartamentoEstado ;
      private bool[] P00N62_n907DepartamentoEstado ;
      private string[] P00N62_A113DepartamentoDepartamento ;
      private GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem AV11DeptoItem ;
      private long[] P00N63_A112DepartamentoId ;
      private string[] P00N63_A967DepartamentoMunicipioIntegraci ;
      private bool[] P00N63_n967DepartamentoMunicipioIntegraci ;
      private string[] P00N63_A908DepartamentoMunicipioEstado ;
      private bool[] P00N63_n908DepartamentoMunicipioEstado ;
      private long[] P00N63_A114DepartamentoMunicipioId ;
      private string[] P00N63_A115DepartamentoMunicipioNombre ;
      private decimal[] P00N63_A863DepartamentoMunicipioCosto ;
      private GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem AV15MuniItem ;
      private bool aP0_Error ;
      private string aP1_Msj ;
      private GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem> aP2_Departamentos ;
      private short aP3_Gx_restcode ;
   }

   public class pobtenerzonas__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00N62;
          prmP00N62 = new Object[] {
          };
          Object[] prmP00N63;
          prmP00N63 = new Object[] {
          new ParDef("@DepartamentoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00N62", "SELECT [DepartamentoId], [DepartamentoIntegracionEcommer], [DepartamentoEstado], [DepartamentoDepartamento] FROM [Departamento] WHERE ( [DepartamentoIntegracionEcommer] = 'T' or [DepartamentoIntegracionEcommer] = 'P') ORDER BY [DepartamentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00N62,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00N63", "SELECT [DepartamentoId], [DepartamentoMunicipioIntegraci], [DepartamentoMunicipioEstado], [DepartamentoMunicipioId], [DepartamentoMunicipioNombre], [DepartamentoMunicipioCosto] FROM [DepartamentoMunicipio] WHERE ([DepartamentoId] = @DepartamentoId) AND ([DepartamentoMunicipioId] <> 9999) AND (( [DepartamentoMunicipioIntegraci] = 'T' or [DepartamentoMunicipioIntegraci] = 'P')) ORDER BY [DepartamentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00N63,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 80);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 120);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
                return;
       }
    }

 }

}
