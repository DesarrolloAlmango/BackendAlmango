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
   public class obtenercapacidadproductiva : GXProcedure
   {
      public obtenercapacidadproductiva( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenercapacidadproductiva( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_LongVarchar )
      {
         this.AV12LongVarchar = "" ;
         initialize();
         ExecutePrivate();
         aP0_LongVarchar=this.AV12LongVarchar;
      }

      public string executeUdp( )
      {
         execute(out aP0_LongVarchar);
         return AV12LongVarchar ;
      }

      public void executeSubmit( out string aP0_LongVarchar )
      {
         this.AV12LongVarchar = "" ;
         SubmitImpl();
         aP0_LongVarchar=this.AV12LongVarchar;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Total = 0;
         /* Using cursor P00GE2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112DepartamentoId = P00GE2_A112DepartamentoId[0];
            n112DepartamentoId = P00GE2_n112DepartamentoId[0];
            A113DepartamentoDepartamento = P00GE2_A113DepartamentoDepartamento[0];
            AV9TotalxDepto = 0;
            /* Optimized group. */
            /* Using cursor P00GE3 */
            pr_default.execute(1, new Object[] {n112DepartamentoId, A112DepartamentoId});
            cV8Total = P00GE3_AV8Total[0];
            cV9TotalxDepto = P00GE3_AV9TotalxDepto[0];
            pr_default.close(1);
            AV8Total = (decimal)(AV8Total+cV8Total*1);
            AV9TotalxDepto = (decimal)(AV9TotalxDepto+cV9TotalxDepto*1);
            /* End optimized group. */
            AV11SDTCapacidadProductivaItem = new SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem(context);
            AV11SDTCapacidadProductivaItem.gxTpr_Departamentoid = A112DepartamentoId;
            AV11SDTCapacidadProductivaItem.gxTpr_Departamentonombre = A113DepartamentoDepartamento;
            AV11SDTCapacidadProductivaItem.gxTpr_Solicitudescantidad = AV9TotalxDepto;
            AV10SDTCapacidadProductiva.Add(AV11SDTCapacidadProductivaItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV15GXV1 = 1;
         while ( AV15GXV1 <= AV10SDTCapacidadProductiva.Count )
         {
            AV11SDTCapacidadProductivaItem = ((SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem)AV10SDTCapacidadProductiva.Item(AV15GXV1));
            AV11SDTCapacidadProductivaItem.gxTpr_Solicitudesporcentaje = (decimal)((AV11SDTCapacidadProductivaItem.gxTpr_Solicitudescantidad/ (decimal)(AV8Total))*100);
            AV15GXV1 = (int)(AV15GXV1+1);
         }
         AV12LongVarchar = AV10SDTCapacidadProductiva.ToJSonString(false);
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
         AV12LongVarchar = "";
         P00GE2_A112DepartamentoId = new long[1] ;
         P00GE2_n112DepartamentoId = new bool[] {false} ;
         P00GE2_A113DepartamentoDepartamento = new string[] {""} ;
         A113DepartamentoDepartamento = "";
         P00GE3_AV8Total = new decimal[1] ;
         P00GE3_AV9TotalxDepto = new decimal[1] ;
         AV11SDTCapacidadProductivaItem = new SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem(context);
         AV10SDTCapacidadProductiva = new GXBaseCollection<SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem>( context, "SDTCapacidadProductivaItem", "AlmangoX");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenercapacidadproductiva__default(),
            new Object[][] {
                new Object[] {
               P00GE2_A112DepartamentoId, P00GE2_A113DepartamentoDepartamento
               }
               , new Object[] {
               P00GE3_AV8Total, P00GE3_AV9TotalxDepto
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV15GXV1 ;
      private long A112DepartamentoId ;
      private decimal AV8Total ;
      private decimal AV9TotalxDepto ;
      private decimal cV8Total ;
      private decimal cV9TotalxDepto ;
      private string A113DepartamentoDepartamento ;
      private bool n112DepartamentoId ;
      private string AV12LongVarchar ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00GE2_A112DepartamentoId ;
      private bool[] P00GE2_n112DepartamentoId ;
      private string[] P00GE2_A113DepartamentoDepartamento ;
      private decimal[] P00GE3_AV8Total ;
      private decimal[] P00GE3_AV9TotalxDepto ;
      private SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem AV11SDTCapacidadProductivaItem ;
      private GXBaseCollection<SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem> AV10SDTCapacidadProductiva ;
      private string aP0_LongVarchar ;
   }

   public class obtenercapacidadproductiva__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00GE2;
          prmP00GE2 = new Object[] {
          };
          Object[] prmP00GE3;
          prmP00GE3 = new Object[] {
          new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00GE2", "SELECT [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GE2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GE3", "SELECT COUNT(*), COUNT(*) FROM [Solicitudes] WHERE ([DepartamentoId] = @DepartamentoId) AND (Not [EstadosSolId] = 3) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GE3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 1 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
       }
    }

 }

}
