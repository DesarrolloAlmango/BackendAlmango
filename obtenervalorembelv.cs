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
   public class obtenervalorembelv : GXProcedure
   {
      public obtenervalorembelv( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenervalorembelv( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_MudanzaId ,
                           short aP1_Piso ,
                           out decimal aP2_Valor )
      {
         this.A735MudanzaId = aP0_MudanzaId;
         this.AV8Piso = aP1_Piso;
         this.AV9Valor = 0 ;
         initialize();
         ExecutePrivate();
         aP2_Valor=this.AV9Valor;
      }

      public decimal executeUdp( long aP0_MudanzaId ,
                                 short aP1_Piso )
      {
         execute(aP0_MudanzaId, aP1_Piso, out aP2_Valor);
         return AV9Valor ;
      }

      public void executeSubmit( long aP0_MudanzaId ,
                                 short aP1_Piso ,
                                 out decimal aP2_Valor )
      {
         this.A735MudanzaId = aP0_MudanzaId;
         this.AV8Piso = aP1_Piso;
         this.AV9Valor = 0 ;
         SubmitImpl();
         aP2_Valor=this.AV9Valor;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00GH2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A732ParametroMudanzaNombre = P00GH2_A732ParametroMudanzaNombre[0];
            A733ParametroMudanzaValor = P00GH2_A733ParametroMudanzaValor[0];
            A730ParametroMudanzaId = P00GH2_A730ParametroMudanzaId[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "PrecioElevPiso", "")) == 0 )
            {
               AV10PrecioElevPiso = A733ParametroMudanzaValor;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00GH3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A732ParametroMudanzaNombre = P00GH3_A732ParametroMudanzaNombre[0];
            A733ParametroMudanzaValor = P00GH3_A733ParametroMudanzaValor[0];
            A730ParametroMudanzaId = P00GH3_A730ParametroMudanzaId[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "PrecioEmbMetro3", "")) == 0 )
            {
               AV12PrecioEmbMetro3 = A733ParametroMudanzaValor;
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV9Valor = 0;
         /* Using cursor P00GH4 */
         pr_default.execute(2, new Object[] {A735MudanzaId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A751ItemCargaId = P00GH4_A751ItemCargaId[0];
            A754ItemCargaVolumen = P00GH4_A754ItemCargaVolumen[0];
            A813ItemCargaEmbCant = P00GH4_A813ItemCargaEmbCant[0];
            n813ItemCargaEmbCant = P00GH4_n813ItemCargaEmbCant[0];
            A814ItemCargaElevCant = P00GH4_A814ItemCargaElevCant[0];
            n814ItemCargaElevCant = P00GH4_n814ItemCargaElevCant[0];
            A754ItemCargaVolumen = P00GH4_A754ItemCargaVolumen[0];
            AV9Valor = (decimal)(AV9Valor+((A814ItemCargaElevCant*AV8Piso*AV10PrecioElevPiso)+(A813ItemCargaEmbCant*A754ItemCargaVolumen*AV12PrecioEmbMetro3)));
            pr_default.readNext(2);
         }
         pr_default.close(2);
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
         P00GH2_A732ParametroMudanzaNombre = new string[] {""} ;
         P00GH2_A733ParametroMudanzaValor = new decimal[1] ;
         P00GH2_A730ParametroMudanzaId = new short[1] ;
         A732ParametroMudanzaNombre = "";
         P00GH3_A732ParametroMudanzaNombre = new string[] {""} ;
         P00GH3_A733ParametroMudanzaValor = new decimal[1] ;
         P00GH3_A730ParametroMudanzaId = new short[1] ;
         P00GH4_A751ItemCargaId = new short[1] ;
         P00GH4_A735MudanzaId = new long[1] ;
         P00GH4_A754ItemCargaVolumen = new decimal[1] ;
         P00GH4_A813ItemCargaEmbCant = new short[1] ;
         P00GH4_n813ItemCargaEmbCant = new bool[] {false} ;
         P00GH4_A814ItemCargaElevCant = new short[1] ;
         P00GH4_n814ItemCargaElevCant = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenervalorembelv__default(),
            new Object[][] {
                new Object[] {
               P00GH2_A732ParametroMudanzaNombre, P00GH2_A733ParametroMudanzaValor, P00GH2_A730ParametroMudanzaId
               }
               , new Object[] {
               P00GH3_A732ParametroMudanzaNombre, P00GH3_A733ParametroMudanzaValor, P00GH3_A730ParametroMudanzaId
               }
               , new Object[] {
               P00GH4_A751ItemCargaId, P00GH4_A735MudanzaId, P00GH4_A754ItemCargaVolumen, P00GH4_A813ItemCargaEmbCant, P00GH4_n813ItemCargaEmbCant, P00GH4_A814ItemCargaElevCant, P00GH4_n814ItemCargaElevCant
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8Piso ;
      private short A730ParametroMudanzaId ;
      private short A751ItemCargaId ;
      private short A813ItemCargaEmbCant ;
      private short A814ItemCargaElevCant ;
      private long A735MudanzaId ;
      private decimal AV9Valor ;
      private decimal A733ParametroMudanzaValor ;
      private decimal AV10PrecioElevPiso ;
      private decimal AV12PrecioEmbMetro3 ;
      private decimal A754ItemCargaVolumen ;
      private bool n813ItemCargaEmbCant ;
      private bool n814ItemCargaElevCant ;
      private string A732ParametroMudanzaNombre ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00GH2_A732ParametroMudanzaNombre ;
      private decimal[] P00GH2_A733ParametroMudanzaValor ;
      private short[] P00GH2_A730ParametroMudanzaId ;
      private string[] P00GH3_A732ParametroMudanzaNombre ;
      private decimal[] P00GH3_A733ParametroMudanzaValor ;
      private short[] P00GH3_A730ParametroMudanzaId ;
      private short[] P00GH4_A751ItemCargaId ;
      private long[] P00GH4_A735MudanzaId ;
      private decimal[] P00GH4_A754ItemCargaVolumen ;
      private short[] P00GH4_A813ItemCargaEmbCant ;
      private bool[] P00GH4_n813ItemCargaEmbCant ;
      private short[] P00GH4_A814ItemCargaElevCant ;
      private bool[] P00GH4_n814ItemCargaElevCant ;
      private decimal aP2_Valor ;
   }

   public class obtenervalorembelv__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GH2;
          prmP00GH2 = new Object[] {
          };
          Object[] prmP00GH3;
          prmP00GH3 = new Object[] {
          };
          Object[] prmP00GH4;
          prmP00GH4 = new Object[] {
          new ParDef("@MudanzaId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GH2", "SELECT [ParametroMudanzaNombre], [ParametroMudanzaValor], [ParametroMudanzaId] FROM [ParametroMudanza] ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GH2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GH3", "SELECT [ParametroMudanzaNombre], [ParametroMudanzaValor], [ParametroMudanzaId] FROM [ParametroMudanza] ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GH3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GH4", "SELECT T1.[ItemCargaId] AS ItemCargaId, T1.[MudanzaId], T2.[ParametroMudanzaValor] AS ItemCargaVolumen, T1.[ItemCargaEmbCant], T1.[ItemCargaElevCant] FROM ([MudanzaCarga] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[ItemCargaId]) WHERE T1.[MudanzaId] = @MudanzaId ORDER BY T1.[MudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GH4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
