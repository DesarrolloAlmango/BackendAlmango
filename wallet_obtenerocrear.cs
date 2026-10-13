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
   public class wallet_obtenerocrear : GXProcedure
   {
      public wallet_obtenerocrear( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wallet_obtenerocrear( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WalletTipoEntidad ,
                           string aP1_WalletCodRefencia ,
                           out long aP2_WalletId ,
                           out bool aP3_FueCreada ,
                           out bool aP4_IsOk ,
                           out string aP5_Gx_msg )
      {
         this.AV10WalletTipoEntidad = aP0_WalletTipoEntidad;
         this.AV11WalletCodRefencia = aP1_WalletCodRefencia;
         this.AV9WalletId = 0 ;
         this.AV15FueCreada = false ;
         this.AV8IsOk = false ;
         this.Gx_msg = "" ;
         initialize();
         ExecutePrivate();
         aP2_WalletId=this.AV9WalletId;
         aP3_FueCreada=this.AV15FueCreada;
         aP4_IsOk=this.AV8IsOk;
         aP5_Gx_msg=this.Gx_msg;
      }

      public string executeUdp( string aP0_WalletTipoEntidad ,
                                string aP1_WalletCodRefencia ,
                                out long aP2_WalletId ,
                                out bool aP3_FueCreada ,
                                out bool aP4_IsOk )
      {
         execute(aP0_WalletTipoEntidad, aP1_WalletCodRefencia, out aP2_WalletId, out aP3_FueCreada, out aP4_IsOk, out aP5_Gx_msg);
         return Gx_msg ;
      }

      public void executeSubmit( string aP0_WalletTipoEntidad ,
                                 string aP1_WalletCodRefencia ,
                                 out long aP2_WalletId ,
                                 out bool aP3_FueCreada ,
                                 out bool aP4_IsOk ,
                                 out string aP5_Gx_msg )
      {
         this.AV10WalletTipoEntidad = aP0_WalletTipoEntidad;
         this.AV11WalletCodRefencia = aP1_WalletCodRefencia;
         this.AV9WalletId = 0 ;
         this.AV15FueCreada = false ;
         this.AV8IsOk = false ;
         this.Gx_msg = "" ;
         SubmitImpl();
         aP2_WalletId=this.AV9WalletId;
         aP3_FueCreada=this.AV15FueCreada;
         aP4_IsOk=this.AV8IsOk;
         aP5_Gx_msg=this.Gx_msg;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8IsOk = true;
         Gx_msg = "";
         AV9WalletId = 0;
         AV15FueCreada = false;
         /* Using cursor P00NR2 */
         pr_default.execute(0, new Object[] {AV11WalletCodRefencia, AV10WalletTipoEntidad});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A639WalletCodRefencia = P00NR2_A639WalletCodRefencia[0];
            A638WalletTipoEntidad = P00NR2_A638WalletTipoEntidad[0];
            A637WalletId = P00NR2_A637WalletId[0];
            AV9WalletId = A637WalletId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV9WalletId == 0 )
         {
            AV12WalletBC = new SdtWallet(context);
            AV12WalletBC.gxTpr_Tipocuentaid = 5;
            AV12WalletBC.gxTpr_Wallettipoentidad = AV10WalletTipoEntidad;
            AV12WalletBC.gxTpr_Walletcodrefencia = AV11WalletCodRefencia;
            AV12WalletBC.gxTpr_Monedaid = 1;
            AV12WalletBC.gxTpr_Walletestado = "HAB";
            AV12WalletBC.Save();
            if ( AV12WalletBC.Success() )
            {
               context.CommitDataStores("wallet_obtenerocrear",pr_default);
               AV9WalletId = AV12WalletBC.gxTpr_Walletid;
               AV15FueCreada = true;
            }
            else
            {
               context.RollbackDataStores("wallet_obtenerocrear",pr_default);
               AV8IsOk = false;
               AV13Messages = AV12WalletBC.GetMessages();
               AV18GXV1 = 1;
               while ( AV18GXV1 <= AV13Messages.Count )
               {
                  AV14Message = ((GeneXus.Utils.SdtMessages_Message)AV13Messages.Item(AV18GXV1));
                  Gx_msg += AV14Message.gxTpr_Description + " ";
                  AV18GXV1 = (int)(AV18GXV1+1);
               }
            }
         }
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
         P00NR2_A639WalletCodRefencia = new string[] {""} ;
         P00NR2_A638WalletTipoEntidad = new string[] {""} ;
         P00NR2_A637WalletId = new long[1] ;
         A639WalletCodRefencia = "";
         A638WalletTipoEntidad = "";
         AV12WalletBC = new SdtWallet(context);
         AV13Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wallet_obtenerocrear__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wallet_obtenerocrear__default(),
            new Object[][] {
                new Object[] {
               P00NR2_A639WalletCodRefencia, P00NR2_A638WalletTipoEntidad, P00NR2_A637WalletId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV18GXV1 ;
      private long AV9WalletId ;
      private long A637WalletId ;
      private string AV10WalletTipoEntidad ;
      private string AV11WalletCodRefencia ;
      private string Gx_msg ;
      private string A639WalletCodRefencia ;
      private string A638WalletTipoEntidad ;
      private bool AV15FueCreada ;
      private bool AV8IsOk ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00NR2_A639WalletCodRefencia ;
      private string[] P00NR2_A638WalletTipoEntidad ;
      private long[] P00NR2_A637WalletId ;
      private SdtWallet AV12WalletBC ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV13Messages ;
      private GeneXus.Utils.SdtMessages_Message AV14Message ;
      private long aP2_WalletId ;
      private bool aP3_FueCreada ;
      private bool aP4_IsOk ;
      private string aP5_Gx_msg ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wallet_obtenerocrear__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wallet_obtenerocrear__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00NR2;
        prmP00NR2 = new Object[] {
        new ParDef("@AV11WalletCodRefencia",GXType.NChar,25,0) ,
        new ParDef("@AV10WalletTipoEntidad",GXType.NChar,3,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00NR2", "SELECT TOP 1 [WalletCodRefencia], [WalletTipoEntidad], [WalletId] FROM [Wallet] WHERE ([WalletCodRefencia] = @AV11WalletCodRefencia) AND ([WalletTipoEntidad] = @AV10WalletTipoEntidad) ORDER BY [WalletCodRefencia] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NR2,1, GxCacheFrequency.OFF ,false,true )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 25);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
     }
  }

}

}
