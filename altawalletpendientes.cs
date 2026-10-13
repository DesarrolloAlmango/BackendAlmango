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
   public class altawalletpendientes : GXProcedure
   {
      public altawalletpendientes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public altawalletpendientes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Gx_msg )
      {
         this.Gx_msg = "" ;
         initialize();
         ExecutePrivate();
         aP0_Gx_msg=this.Gx_msg;
      }

      public string executeUdp( )
      {
         execute(out aP0_Gx_msg);
         return Gx_msg ;
      }

      public void executeSubmit( out string aP0_Gx_msg )
      {
         this.Gx_msg = "" ;
         SubmitImpl();
         aP0_Gx_msg=this.Gx_msg;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10TotalCreadas = 0;
         /* Using cursor P00NQ2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A108EstadosGenericosId = P00NQ2_A108EstadosGenericosId[0];
            A107EstadosTipo = P00NQ2_A107EstadosTipo[0];
            A120ProfesionalesId = P00NQ2_A120ProfesionalesId[0];
            if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
            {
               AV11ProfesionalesId = A120ProfesionalesId;
               new wallet_obtenerocrear(context ).execute(  "PRO",  AV11ProfesionalesId, out  AV14WalletId, out  AV15FueCreada, out  AV16IsOk, out  Gx_msg) ;
               if ( AV16IsOk )
               {
                  if ( AV15FueCreada )
                  {
                     AV10TotalCreadas = (short)(AV10TotalCreadas+1);
                  }
               }
               else
               {
                  AV17Plog = new SdtPlog(context);
                  AV17Plog.gxTpr_Plogmsg = StringUtil.Format( context.GetMessage( "Error al crear wallet para %1: %2", ""), AV11ProfesionalesId, Gx_msg, "", "", "", "", "", "", "");
                  AV17Plog.gxTpr_Plogpgm = context.GetMessage( "Alta Wallet", "");
                  AV17Plog.Save();
                  context.CommitDataStores("altawalletpendientes",pr_default);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Gx_msg = context.GetMessage( "Proceso finalizado. Cuentas creadas: ", "") + StringUtil.Str( (decimal)(AV10TotalCreadas), 4, 0);
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
         Gx_msg = "";
         P00NQ2_A108EstadosGenericosId = new int[1] ;
         P00NQ2_A107EstadosTipo = new string[] {""} ;
         P00NQ2_A120ProfesionalesId = new string[] {""} ;
         A107EstadosTipo = "";
         A120ProfesionalesId = "";
         AV11ProfesionalesId = "";
         AV17Plog = new SdtPlog(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.altawalletpendientes__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.altawalletpendientes__default(),
            new Object[][] {
                new Object[] {
               P00NQ2_A108EstadosGenericosId, P00NQ2_A107EstadosTipo, P00NQ2_A120ProfesionalesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10TotalCreadas ;
      private int A108EstadosGenericosId ;
      private long AV14WalletId ;
      private string Gx_msg ;
      private string A107EstadosTipo ;
      private string A120ProfesionalesId ;
      private string AV11ProfesionalesId ;
      private bool AV15FueCreada ;
      private bool AV16IsOk ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00NQ2_A108EstadosGenericosId ;
      private string[] P00NQ2_A107EstadosTipo ;
      private string[] P00NQ2_A120ProfesionalesId ;
      private SdtPlog AV17Plog ;
      private string aP0_Gx_msg ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class altawalletpendientes__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class altawalletpendientes__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00NQ2;
        prmP00NQ2 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("P00NQ2", "SELECT [EstadosGenericosId], [EstadosTipo], [ProfesionalesId] FROM [Profesionales] WHERE [EstadosGenericosId] = 1 ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NQ2,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
     }
  }

}

}
