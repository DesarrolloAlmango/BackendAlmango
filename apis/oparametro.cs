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
namespace GeneXus.Programs.apis {
   public class oparametro : GXProcedure
   {
      public oparametro( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oparametro( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Codigo ,
                           out string aP1_Valor )
      {
         this.AV8Codigo = aP0_Codigo;
         this.AV9Valor = "" ;
         initialize();
         ExecutePrivate();
         aP1_Valor=this.AV9Valor;
      }

      public string executeUdp( string aP0_Codigo )
      {
         execute(aP0_Codigo, out aP1_Valor);
         return AV9Valor ;
      }

      public void executeSubmit( string aP0_Codigo ,
                                 out string aP1_Valor )
      {
         this.AV8Codigo = aP0_Codigo;
         this.AV9Valor = "" ;
         SubmitImpl();
         aP1_Valor=this.AV9Valor;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Valor = "";
         /* Using cursor P00JM2 */
         pr_default.execute(0, new Object[] {AV8Codigo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A238ParametrosEstado = P00JM2_A238ParametrosEstado[0];
            A237ParametrosCodigo = P00JM2_A237ParametrosCodigo[0];
            A602ParametrosValor = P00JM2_A602ParametrosValor[0];
            A283ParametrosId = P00JM2_A283ParametrosId[0];
            if ( StringUtil.StrCmp(A238ParametrosEstado, context.GetMessage( "HAB", "")) == 0 )
            {
               AV9Valor = A602ParametrosValor;
            }
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
         AV9Valor = "";
         P00JM2_A238ParametrosEstado = new string[] {""} ;
         P00JM2_A237ParametrosCodigo = new string[] {""} ;
         P00JM2_A602ParametrosValor = new string[] {""} ;
         P00JM2_A283ParametrosId = new long[1] ;
         A238ParametrosEstado = "";
         A237ParametrosCodigo = "";
         A602ParametrosValor = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.oparametro__default(),
            new Object[][] {
                new Object[] {
               P00JM2_A238ParametrosEstado, P00JM2_A237ParametrosCodigo, P00JM2_A602ParametrosValor, P00JM2_A283ParametrosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A283ParametrosId ;
      private string AV8Codigo ;
      private string A238ParametrosEstado ;
      private string A237ParametrosCodigo ;
      private string AV9Valor ;
      private string A602ParametrosValor ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00JM2_A238ParametrosEstado ;
      private string[] P00JM2_A237ParametrosCodigo ;
      private string[] P00JM2_A602ParametrosValor ;
      private long[] P00JM2_A283ParametrosId ;
      private string aP1_Valor ;
   }

   public class oparametro__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00JM2;
          prmP00JM2 = new Object[] {
          new ParDef("@AV8Codigo",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00JM2", "SELECT [ParametrosEstado], [ParametrosCodigo], [ParametrosValor], [ParametrosId] FROM [Parametros] WHERE RTRIM(LTRIM([ParametrosCodigo])) = RTRIM(LTRIM(@AV8Codigo)) ORDER BY [ParametrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JM2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
