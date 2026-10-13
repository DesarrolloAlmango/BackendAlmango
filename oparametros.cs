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
   public class oparametros : GXProcedure
   {
      public oparametros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oparametros( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ParametrosCodigo ,
                           out string aP1_ParametrosValor ,
                           out int aP2_ParametrosNumerico ,
                           out string aP3_ParametrosEstado )
      {
         this.AV8ParametrosCodigo = aP0_ParametrosCodigo;
         this.AV9ParametrosValor = "" ;
         this.AV11ParametrosNumerico = 0 ;
         this.AV10ParametrosEstado = "" ;
         initialize();
         ExecutePrivate();
         aP1_ParametrosValor=this.AV9ParametrosValor;
         aP2_ParametrosNumerico=this.AV11ParametrosNumerico;
         aP3_ParametrosEstado=this.AV10ParametrosEstado;
      }

      public string executeUdp( string aP0_ParametrosCodigo ,
                                out string aP1_ParametrosValor ,
                                out int aP2_ParametrosNumerico )
      {
         execute(aP0_ParametrosCodigo, out aP1_ParametrosValor, out aP2_ParametrosNumerico, out aP3_ParametrosEstado);
         return AV10ParametrosEstado ;
      }

      public void executeSubmit( string aP0_ParametrosCodigo ,
                                 out string aP1_ParametrosValor ,
                                 out int aP2_ParametrosNumerico ,
                                 out string aP3_ParametrosEstado )
      {
         this.AV8ParametrosCodigo = aP0_ParametrosCodigo;
         this.AV9ParametrosValor = "" ;
         this.AV11ParametrosNumerico = 0 ;
         this.AV10ParametrosEstado = "" ;
         SubmitImpl();
         aP1_ParametrosValor=this.AV9ParametrosValor;
         aP2_ParametrosNumerico=this.AV11ParametrosNumerico;
         aP3_ParametrosEstado=this.AV10ParametrosEstado;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ParametrosValor = "";
         AV10ParametrosEstado = "DES";
         /* Using cursor P00B82 */
         pr_default.execute(0, new Object[] {AV8ParametrosCodigo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A237ParametrosCodigo = P00B82_A237ParametrosCodigo[0];
            A602ParametrosValor = P00B82_A602ParametrosValor[0];
            A635ParametrosNumerico = P00B82_A635ParametrosNumerico[0];
            A238ParametrosEstado = P00B82_A238ParametrosEstado[0];
            A283ParametrosId = P00B82_A283ParametrosId[0];
            AV9ParametrosValor = A602ParametrosValor;
            AV11ParametrosNumerico = A635ParametrosNumerico;
            AV10ParametrosEstado = A238ParametrosEstado;
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
         AV9ParametrosValor = "";
         AV10ParametrosEstado = "";
         P00B82_A237ParametrosCodigo = new string[] {""} ;
         P00B82_A602ParametrosValor = new string[] {""} ;
         P00B82_A635ParametrosNumerico = new int[1] ;
         P00B82_A238ParametrosEstado = new string[] {""} ;
         P00B82_A283ParametrosId = new long[1] ;
         A237ParametrosCodigo = "";
         A602ParametrosValor = "";
         A238ParametrosEstado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.oparametros__default(),
            new Object[][] {
                new Object[] {
               P00B82_A237ParametrosCodigo, P00B82_A602ParametrosValor, P00B82_A635ParametrosNumerico, P00B82_A238ParametrosEstado, P00B82_A283ParametrosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV11ParametrosNumerico ;
      private int A635ParametrosNumerico ;
      private long A283ParametrosId ;
      private string AV8ParametrosCodigo ;
      private string AV10ParametrosEstado ;
      private string A237ParametrosCodigo ;
      private string A238ParametrosEstado ;
      private string AV9ParametrosValor ;
      private string A602ParametrosValor ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00B82_A237ParametrosCodigo ;
      private string[] P00B82_A602ParametrosValor ;
      private int[] P00B82_A635ParametrosNumerico ;
      private string[] P00B82_A238ParametrosEstado ;
      private long[] P00B82_A283ParametrosId ;
      private string aP1_ParametrosValor ;
      private int aP2_ParametrosNumerico ;
      private string aP3_ParametrosEstado ;
   }

   public class oparametros__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00B82;
          prmP00B82 = new Object[] {
          new ParDef("@AV8ParametrosCodigo",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B82", "SELECT TOP 1 [ParametrosCodigo], [ParametrosValor], [ParametrosNumerico], [ParametrosEstado], [ParametrosId] FROM [Parametros] WHERE UPPER(RTRIM(LTRIM([ParametrosCodigo]))) = UPPER(RTRIM(LTRIM(@AV8ParametrosCodigo))) ORDER BY [ParametrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B82,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
