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
   public class wwp_getloggeduserroles : GXProcedure
   {
      public wwp_getloggeduserroles( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getloggeduserroles( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GxSimpleCollection<string> aP0_WWPSubscriptionRoleIdCollection )
      {
         this.AV9WWPSubscriptionRoleIdCollection = new GxSimpleCollection<string>() ;
         initialize();
         ExecutePrivate();
         aP0_WWPSubscriptionRoleIdCollection=this.AV9WWPSubscriptionRoleIdCollection;
      }

      public GxSimpleCollection<string> executeUdp( )
      {
         execute(out aP0_WWPSubscriptionRoleIdCollection);
         return AV9WWPSubscriptionRoleIdCollection ;
      }

      public void executeSubmit( out GxSimpleCollection<string> aP0_WWPSubscriptionRoleIdCollection )
      {
         this.AV9WWPSubscriptionRoleIdCollection = new GxSimpleCollection<string>() ;
         SubmitImpl();
         aP0_WWPSubscriptionRoleIdCollection=this.AV9WWPSubscriptionRoleIdCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9WWPSubscriptionRoleIdCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         /* Using cursor P002U2 */
         pr_default.execute(0, new Object[] {AV8WWPContext.gxTpr_Userid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A18SecUserId = P002U2_A18SecUserId[0];
            A16SecRoleId = P002U2_A16SecRoleId[0];
            AV9WWPSubscriptionRoleIdCollection.Add(StringUtil.Trim( StringUtil.Str( (decimal)(A16SecRoleId), 4, 0)), 0);
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
         AV9WWPSubscriptionRoleIdCollection = new GxSimpleCollection<string>();
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P002U2_A18SecUserId = new long[1] ;
         P002U2_A16SecRoleId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserroles__default(),
            new Object[][] {
                new Object[] {
               P002U2_A18SecUserId, P002U2_A16SecRoleId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A16SecRoleId ;
      private long A18SecUserId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV9WWPSubscriptionRoleIdCollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private IDataStoreProvider pr_default ;
      private long[] P002U2_A18SecUserId ;
      private short[] P002U2_A16SecRoleId ;
      private GxSimpleCollection<string> aP0_WWPSubscriptionRoleIdCollection ;
   }

   public class wwp_getloggeduserroles__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002U2;
          prmP002U2 = new Object[] {
          new ParDef("@AV8WWPContext__Userid",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002U2", "SELECT [SecUserId], [SecRoleId] FROM [SecUserRole] WHERE [SecUserId] = @AV8WWPContext__Userid ORDER BY [SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002U2,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
