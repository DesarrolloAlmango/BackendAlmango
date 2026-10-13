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
namespace GeneXus.Programs {
   public class obtenercontrolintegracion : GXProcedure
   {
      public obtenercontrolintegracion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenercontrolintegracion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EcommerceId ,
                           long aP1_ComercioId ,
                           string aP2_TipoOperacion ,
                           out DateTime aP3_FechaDesde ,
                           out DateTime aP4_FechaHasta )
      {
         this.AV12EcommerceId = aP0_EcommerceId;
         this.AV8ComercioId = aP1_ComercioId;
         this.AV9TipoOperacion = aP2_TipoOperacion;
         this.AV10FechaDesde = DateTime.MinValue ;
         this.AV11FechaHasta = DateTime.MinValue ;
         initialize();
         ExecutePrivate();
         aP3_FechaDesde=this.AV10FechaDesde;
         aP4_FechaHasta=this.AV11FechaHasta;
      }

      public DateTime executeUdp( long aP0_EcommerceId ,
                                  long aP1_ComercioId ,
                                  string aP2_TipoOperacion ,
                                  out DateTime aP3_FechaDesde )
      {
         execute(aP0_EcommerceId, aP1_ComercioId, aP2_TipoOperacion, out aP3_FechaDesde, out aP4_FechaHasta);
         return AV11FechaHasta ;
      }

      public void executeSubmit( long aP0_EcommerceId ,
                                 long aP1_ComercioId ,
                                 string aP2_TipoOperacion ,
                                 out DateTime aP3_FechaDesde ,
                                 out DateTime aP4_FechaHasta )
      {
         this.AV12EcommerceId = aP0_EcommerceId;
         this.AV8ComercioId = aP1_ComercioId;
         this.AV9TipoOperacion = aP2_TipoOperacion;
         this.AV10FechaDesde = DateTime.MinValue ;
         this.AV11FechaHasta = DateTime.MinValue ;
         SubmitImpl();
         aP3_FechaDesde=this.AV10FechaDesde;
         aP4_FechaHasta=this.AV11FechaHasta;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11FechaHasta = DateTimeUtil.Today( context);
         AV10FechaDesde = DateTimeUtil.DAdd(DateTimeUtil.Today( context),-((int)(1)));
         /* Using cursor P00LM2 */
         pr_default.execute(0, new Object[] {AV8ComercioId, AV12EcommerceId, AV9TipoOperacion});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A962OperacionesComercioId1 = P00LM2_A962OperacionesComercioId1[0];
            n962OperacionesComercioId1 = P00LM2_n962OperacionesComercioId1[0];
            A963OperacionesComercioId2 = P00LM2_A963OperacionesComercioId2[0];
            n963OperacionesComercioId2 = P00LM2_n963OperacionesComercioId2[0];
            A649OperacionesTipo = P00LM2_A649OperacionesTipo[0];
            n649OperacionesTipo = P00LM2_n649OperacionesTipo[0];
            A659OperacionesFechaHasta = P00LM2_A659OperacionesFechaHasta[0];
            n659OperacionesFechaHasta = P00LM2_n659OperacionesFechaHasta[0];
            A581OperacionesFechaAlta = P00LM2_A581OperacionesFechaAlta[0];
            n581OperacionesFechaAlta = P00LM2_n581OperacionesFechaAlta[0];
            A554OperacionesId = P00LM2_A554OperacionesId[0];
            AV10FechaDesde = DateTimeUtil.DAdd(A659OperacionesFechaHasta,-((int)(1)));
            AV11FechaHasta = DateTimeUtil.Today( context);
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
         AV10FechaDesde = DateTime.MinValue;
         AV11FechaHasta = DateTime.MinValue;
         P00LM2_A962OperacionesComercioId1 = new long[1] ;
         P00LM2_n962OperacionesComercioId1 = new bool[] {false} ;
         P00LM2_A963OperacionesComercioId2 = new long[1] ;
         P00LM2_n963OperacionesComercioId2 = new bool[] {false} ;
         P00LM2_A649OperacionesTipo = new string[] {""} ;
         P00LM2_n649OperacionesTipo = new bool[] {false} ;
         P00LM2_A659OperacionesFechaHasta = new DateTime[] {DateTime.MinValue} ;
         P00LM2_n659OperacionesFechaHasta = new bool[] {false} ;
         P00LM2_A581OperacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00LM2_n581OperacionesFechaAlta = new bool[] {false} ;
         P00LM2_A554OperacionesId = new long[1] ;
         A649OperacionesTipo = "";
         A659OperacionesFechaHasta = DateTime.MinValue;
         A581OperacionesFechaAlta = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenercontrolintegracion__default(),
            new Object[][] {
                new Object[] {
               P00LM2_A962OperacionesComercioId1, P00LM2_n962OperacionesComercioId1, P00LM2_A963OperacionesComercioId2, P00LM2_n963OperacionesComercioId2, P00LM2_A649OperacionesTipo, P00LM2_n649OperacionesTipo, P00LM2_A659OperacionesFechaHasta, P00LM2_n659OperacionesFechaHasta, P00LM2_A581OperacionesFechaAlta, P00LM2_n581OperacionesFechaAlta,
               P00LM2_A554OperacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV12EcommerceId ;
      private long AV8ComercioId ;
      private long A962OperacionesComercioId1 ;
      private long A963OperacionesComercioId2 ;
      private long A554OperacionesId ;
      private string AV9TipoOperacion ;
      private string A649OperacionesTipo ;
      private DateTime AV10FechaDesde ;
      private DateTime AV11FechaHasta ;
      private DateTime A659OperacionesFechaHasta ;
      private DateTime A581OperacionesFechaAlta ;
      private bool n962OperacionesComercioId1 ;
      private bool n963OperacionesComercioId2 ;
      private bool n649OperacionesTipo ;
      private bool n659OperacionesFechaHasta ;
      private bool n581OperacionesFechaAlta ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00LM2_A962OperacionesComercioId1 ;
      private bool[] P00LM2_n962OperacionesComercioId1 ;
      private long[] P00LM2_A963OperacionesComercioId2 ;
      private bool[] P00LM2_n963OperacionesComercioId2 ;
      private string[] P00LM2_A649OperacionesTipo ;
      private bool[] P00LM2_n649OperacionesTipo ;
      private DateTime[] P00LM2_A659OperacionesFechaHasta ;
      private bool[] P00LM2_n659OperacionesFechaHasta ;
      private DateTime[] P00LM2_A581OperacionesFechaAlta ;
      private bool[] P00LM2_n581OperacionesFechaAlta ;
      private long[] P00LM2_A554OperacionesId ;
      private DateTime aP3_FechaDesde ;
      private DateTime aP4_FechaHasta ;
   }

   public class obtenercontrolintegracion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00LM2;
          prmP00LM2 = new Object[] {
          new ParDef("@AV8ComercioId",GXType.Decimal,18,0) ,
          new ParDef("@AV12EcommerceId",GXType.Decimal,18,0) ,
          new ParDef("@AV9TipoOperacion",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00LM2", "SELECT TOP 1 [OperacionesComercioId1], [OperacionesComercioId2], [OperacionesTipo], [OperacionesFechaHasta], [OperacionesFechaAlta], [OperacionesId] FROM [Operaciones] WHERE ([OperacionesComercioId1] = @AV8ComercioId) AND ([OperacionesComercioId2] = @AV12EcommerceId) AND ([OperacionesTipo] = @AV9TipoOperacion) ORDER BY [OperacionesFechaAlta] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LM2,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((long[]) buf[10])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
