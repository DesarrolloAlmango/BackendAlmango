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
   public class secisauthbyobjectname : GXProcedure
   {
      public secisauthbyobjectname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secisauthbyobjectname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SecObjectName ,
                           out bool aP1_IsAuthorized )
      {
         this.AV9SecObjectName = aP0_SecObjectName;
         this.AV8IsAuthorized = false ;
         initialize();
         ExecutePrivate();
         aP1_IsAuthorized=this.AV8IsAuthorized;
      }

      public bool executeUdp( string aP0_SecObjectName )
      {
         execute(aP0_SecObjectName, out aP1_IsAuthorized);
         return AV8IsAuthorized ;
      }

      public void executeSubmit( string aP0_SecObjectName ,
                                 out bool aP1_IsAuthorized )
      {
         this.AV9SecObjectName = aP0_SecObjectName;
         this.AV8IsAuthorized = false ;
         SubmitImpl();
         aP1_IsAuthorized=this.AV8IsAuthorized;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8IsAuthorized = false;
         AV10LowerSecObjectName = StringUtil.Trim( StringUtil.Lower( AV9SecObjectName));
         AV11GXLvl4 = 0;
         /* Using cursor P00272 */
         pr_default.execute(0, new Object[] {AV10LowerSecObjectName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A17SecObjectName = P00272_A17SecObjectName[0];
            A13SecFunctionalityId = P00272_A13SecFunctionalityId[0];
            AV11GXLvl4 = 1;
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalityid(context ).execute(  A13SecFunctionalityId, out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( AV8IsAuthorized )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV11GXLvl4 == 0 )
         {
            AV8IsAuthorized = true;
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
         AV10LowerSecObjectName = "";
         P00272_A17SecObjectName = new string[] {""} ;
         P00272_A13SecFunctionalityId = new long[1] ;
         A17SecObjectName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secisauthbyobjectname__default(),
            new Object[][] {
                new Object[] {
               P00272_A17SecObjectName, P00272_A13SecFunctionalityId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11GXLvl4 ;
      private long A13SecFunctionalityId ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private string AV9SecObjectName ;
      private string AV10LowerSecObjectName ;
      private string A17SecObjectName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00272_A17SecObjectName ;
      private long[] P00272_A13SecFunctionalityId ;
      private bool aP1_IsAuthorized ;
   }

   public class secisauthbyobjectname__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00272;
          prmP00272 = new Object[] {
          new ParDef("@AV10LowerSecObjectName",GXType.NVarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00272", "SELECT [SecObjectName], [SecFunctionalityId] FROM [SecObjectFunctionalities] WHERE [SecObjectName] = @AV10LowerSecObjectName ORDER BY [SecObjectName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00272,100, GxCacheFrequency.OFF ,true,false )
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
