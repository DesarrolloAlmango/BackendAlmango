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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secisauthbyfunctionalitykey : GXProcedure
   {
      public secisauthbyfunctionalitykey( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secisauthbyfunctionalitykey( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SecFunctionalityKey ,
                           out bool aP1_IsAuthorized )
      {
         this.AV9SecFunctionalityKey = aP0_SecFunctionalityKey;
         this.AV8IsAuthorized = false ;
         initialize();
         ExecutePrivate();
         aP1_IsAuthorized=this.AV8IsAuthorized;
      }

      public bool executeUdp( string aP0_SecFunctionalityKey )
      {
         execute(aP0_SecFunctionalityKey, out aP1_IsAuthorized);
         return AV8IsAuthorized ;
      }

      public void executeSubmit( string aP0_SecFunctionalityKey ,
                                 out bool aP1_IsAuthorized )
      {
         this.AV9SecFunctionalityKey = aP0_SecFunctionalityKey;
         this.AV8IsAuthorized = false ;
         SubmitImpl();
         aP1_IsAuthorized=this.AV8IsAuthorized;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8IsAuthorized = false;
         AV10GXLvl3 = 0;
         /* Using cursor P00252 */
         pr_default.execute(0, new Object[] {AV9SecFunctionalityKey});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A15SecFunctionalityKey = P00252_A15SecFunctionalityKey[0];
            A13SecFunctionalityId = P00252_A13SecFunctionalityId[0];
            AV10GXLvl3 = 1;
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalityid(context ).execute(  A13SecFunctionalityId, out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV10GXLvl3 == 0 )
         {
            AV8IsAuthorized = false;
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
         P00252_A15SecFunctionalityKey = new string[] {""} ;
         P00252_A13SecFunctionalityId = new long[1] ;
         A15SecFunctionalityKey = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey__default(),
            new Object[][] {
                new Object[] {
               P00252_A15SecFunctionalityKey, P00252_A13SecFunctionalityId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10GXLvl3 ;
      private long A13SecFunctionalityId ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private string AV9SecFunctionalityKey ;
      private string A15SecFunctionalityKey ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00252_A15SecFunctionalityKey ;
      private long[] P00252_A13SecFunctionalityId ;
      private bool aP1_IsAuthorized ;
   }

   public class secisauthbyfunctionalitykey__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00252;
          prmP00252 = new Object[] {
          new ParDef("@AV9SecFunctionalityKey",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00252", "SELECT TOP 1 [SecFunctionalityKey], [SecFunctionalityId] FROM [SecFunctionality] WHERE [SecFunctionalityKey] = @AV9SecFunctionalityKey ORDER BY [SecFunctionalityKey] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00252,1, GxCacheFrequency.OFF ,true,true )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
