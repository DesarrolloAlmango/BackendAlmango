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
   public class aobtenerdepto : GXProcedure
   {
      public aobtenerdepto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aobtenerdepto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDTDepartamento> aP0_SDTDepartamento )
      {
         this.AV8SDTDepartamento = new GXBaseCollection<SdtSDTDepartamento>( context, "SDTDepartamento", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP0_SDTDepartamento=this.AV8SDTDepartamento;
      }

      public GXBaseCollection<SdtSDTDepartamento> executeUdp( )
      {
         execute(out aP0_SDTDepartamento);
         return AV8SDTDepartamento ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTDepartamento> aP0_SDTDepartamento )
      {
         this.AV8SDTDepartamento = new GXBaseCollection<SdtSDTDepartamento>( context, "SDTDepartamento", "AlmangoX") ;
         SubmitImpl();
         aP0_SDTDepartamento=this.AV8SDTDepartamento;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00H32 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A907DepartamentoEstado = P00H32_A907DepartamentoEstado[0];
            n907DepartamentoEstado = P00H32_n907DepartamentoEstado[0];
            A112DepartamentoId = P00H32_A112DepartamentoId[0];
            A113DepartamentoDepartamento = P00H32_A113DepartamentoDepartamento[0];
            if ( StringUtil.StrCmp(A907DepartamentoEstado, context.GetMessage( "DES", "")) != 0 )
            {
               AV9SDTDepartamentoItem = new SdtSDTDepartamento(context);
               AV9SDTDepartamentoItem.gxTpr_Departamentoid = A112DepartamentoId;
               AV9SDTDepartamentoItem.gxTpr_Departamentodepartamento = A113DepartamentoDepartamento;
               AV8SDTDepartamento.Add(AV9SDTDepartamentoItem, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         context.StatusMessage( AV8SDTDepartamento.ToJSonString(false) );
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
         AV8SDTDepartamento = new GXBaseCollection<SdtSDTDepartamento>( context, "SDTDepartamento", "AlmangoX");
         P00H32_A907DepartamentoEstado = new string[] {""} ;
         P00H32_n907DepartamentoEstado = new bool[] {false} ;
         P00H32_A112DepartamentoId = new long[1] ;
         P00H32_A113DepartamentoDepartamento = new string[] {""} ;
         A907DepartamentoEstado = "";
         A113DepartamentoDepartamento = "";
         AV9SDTDepartamentoItem = new SdtSDTDepartamento(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aobtenerdepto__default(),
            new Object[][] {
                new Object[] {
               P00H32_A907DepartamentoEstado, P00H32_n907DepartamentoEstado, P00H32_A112DepartamentoId, P00H32_A113DepartamentoDepartamento
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A112DepartamentoId ;
      private string A907DepartamentoEstado ;
      private string A113DepartamentoDepartamento ;
      private bool n907DepartamentoEstado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTDepartamento> AV8SDTDepartamento ;
      private IDataStoreProvider pr_default ;
      private string[] P00H32_A907DepartamentoEstado ;
      private bool[] P00H32_n907DepartamentoEstado ;
      private long[] P00H32_A112DepartamentoId ;
      private string[] P00H32_A113DepartamentoDepartamento ;
      private SdtSDTDepartamento AV9SDTDepartamentoItem ;
      private GXBaseCollection<SdtSDTDepartamento> aP0_SDTDepartamento ;
   }

   public class aobtenerdepto__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00H32;
          prmP00H32 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00H32", "SELECT [DepartamentoEstado], [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H32,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                return;
       }
    }

 }

}
