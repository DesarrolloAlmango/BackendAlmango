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
   public class opeajevalor : GXProcedure
   {
      public opeajevalor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public opeajevalor( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out decimal aP0_MudanzaPeajeValor )
      {
         this.AV8MudanzaPeajeValor = 0 ;
         initialize();
         ExecutePrivate();
         aP0_MudanzaPeajeValor=this.AV8MudanzaPeajeValor;
      }

      public decimal executeUdp( )
      {
         execute(out aP0_MudanzaPeajeValor);
         return AV8MudanzaPeajeValor ;
      }

      public void executeSubmit( out decimal aP0_MudanzaPeajeValor )
      {
         this.AV8MudanzaPeajeValor = 0 ;
         SubmitImpl();
         aP0_MudanzaPeajeValor=this.AV8MudanzaPeajeValor;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00F02 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A732ParametroMudanzaNombre = P00F02_A732ParametroMudanzaNombre[0];
            A731ParametroMudanzaTipo = P00F02_A731ParametroMudanzaTipo[0];
            A733ParametroMudanzaValor = P00F02_A733ParametroMudanzaValor[0];
            A730ParametroMudanzaId = P00F02_A730ParametroMudanzaId[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "Peaje", "")) == 0 )
            {
               AV8MudanzaPeajeValor = A733ParametroMudanzaValor;
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
         P00F02_A732ParametroMudanzaNombre = new string[] {""} ;
         P00F02_A731ParametroMudanzaTipo = new string[] {""} ;
         P00F02_A733ParametroMudanzaValor = new decimal[1] ;
         P00F02_A730ParametroMudanzaId = new short[1] ;
         A732ParametroMudanzaNombre = "";
         A731ParametroMudanzaTipo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.opeajevalor__default(),
            new Object[][] {
                new Object[] {
               P00F02_A732ParametroMudanzaNombre, P00F02_A731ParametroMudanzaTipo, P00F02_A733ParametroMudanzaValor, P00F02_A730ParametroMudanzaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A730ParametroMudanzaId ;
      private decimal AV8MudanzaPeajeValor ;
      private decimal A733ParametroMudanzaValor ;
      private string A732ParametroMudanzaNombre ;
      private string A731ParametroMudanzaTipo ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00F02_A732ParametroMudanzaNombre ;
      private string[] P00F02_A731ParametroMudanzaTipo ;
      private decimal[] P00F02_A733ParametroMudanzaValor ;
      private short[] P00F02_A730ParametroMudanzaId ;
      private decimal aP0_MudanzaPeajeValor ;
   }

   public class opeajevalor__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00F02;
          prmP00F02 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00F02", "SELECT [ParametroMudanzaNombre], [ParametroMudanzaTipo], [ParametroMudanzaValor], [ParametroMudanzaId] FROM [ParametroMudanza] WHERE [ParametroMudanzaTipo] = 'Peaje' ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F02,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
