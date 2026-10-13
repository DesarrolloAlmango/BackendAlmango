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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_checkuserisnotunsubscribed : GXProcedure
   {
      public wwp_checkuserisnotunsubscribed( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_checkuserisnotunsubscribed( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_WWPNotificationDefinitionId ,
                           ref long aP1_WWPSubscriptionId ,
                           ref bool aP2_IncludeNotification )
      {
         this.AV9WWPNotificationDefinitionId = aP0_WWPNotificationDefinitionId;
         this.AV10WWPSubscriptionId = aP1_WWPSubscriptionId;
         this.AV8IncludeNotification = aP2_IncludeNotification;
         initialize();
         ExecutePrivate();
         aP1_WWPSubscriptionId=this.AV10WWPSubscriptionId;
         aP2_IncludeNotification=this.AV8IncludeNotification;
      }

      public bool executeUdp( long aP0_WWPNotificationDefinitionId ,
                              ref long aP1_WWPSubscriptionId )
      {
         execute(aP0_WWPNotificationDefinitionId, ref aP1_WWPSubscriptionId, ref aP2_IncludeNotification);
         return AV8IncludeNotification ;
      }

      public void executeSubmit( long aP0_WWPNotificationDefinitionId ,
                                 ref long aP1_WWPSubscriptionId ,
                                 ref bool aP2_IncludeNotification )
      {
         this.AV9WWPNotificationDefinitionId = aP0_WWPNotificationDefinitionId;
         this.AV10WWPSubscriptionId = aP1_WWPSubscriptionId;
         this.AV8IncludeNotification = aP2_IncludeNotification;
         SubmitImpl();
         aP1_WWPSubscriptionId=this.AV10WWPSubscriptionId;
         aP2_IncludeNotification=this.AV8IncludeNotification;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Using cursor P002Y2 */
         pr_default.execute(0, new Object[] {AV12Udparg1, AV9WWPNotificationDefinitionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A36WWPSubscriptionSubscribed = P002Y2_A36WWPSubscriptionSubscribed[0];
            A1WWPUserExtendedId = P002Y2_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = P002Y2_n1WWPUserExtendedId[0];
            A32WWPNotificationDefinitionId = P002Y2_A32WWPNotificationDefinitionId[0];
            A34WWPSubscriptionId = P002Y2_A34WWPSubscriptionId[0];
            AV8IncludeNotification = false;
            AV10WWPSubscriptionId = A34WWPSubscriptionId;
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
         AV12Udparg1 = "";
         P002Y2_A36WWPSubscriptionSubscribed = new bool[] {false} ;
         P002Y2_A1WWPUserExtendedId = new string[] {""} ;
         P002Y2_n1WWPUserExtendedId = new bool[] {false} ;
         P002Y2_A32WWPNotificationDefinitionId = new long[1] ;
         P002Y2_A34WWPSubscriptionId = new long[1] ;
         A1WWPUserExtendedId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_checkuserisnotunsubscribed__default(),
            new Object[][] {
                new Object[] {
               P002Y2_A36WWPSubscriptionSubscribed, P002Y2_A1WWPUserExtendedId, P002Y2_n1WWPUserExtendedId, P002Y2_A32WWPNotificationDefinitionId, P002Y2_A34WWPSubscriptionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9WWPNotificationDefinitionId ;
      private long AV10WWPSubscriptionId ;
      private long A32WWPNotificationDefinitionId ;
      private long A34WWPSubscriptionId ;
      private string AV12Udparg1 ;
      private string A1WWPUserExtendedId ;
      private bool AV8IncludeNotification ;
      private bool A36WWPSubscriptionSubscribed ;
      private bool n1WWPUserExtendedId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private long aP1_WWPSubscriptionId ;
      private bool aP2_IncludeNotification ;
      private IDataStoreProvider pr_default ;
      private bool[] P002Y2_A36WWPSubscriptionSubscribed ;
      private string[] P002Y2_A1WWPUserExtendedId ;
      private bool[] P002Y2_n1WWPUserExtendedId ;
      private long[] P002Y2_A32WWPNotificationDefinitionId ;
      private long[] P002Y2_A34WWPSubscriptionId ;
   }

   public class wwp_checkuserisnotunsubscribed__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002Y2;
          prmP002Y2 = new Object[] {
          new ParDef("@AV12Udparg1",GXType.NChar,40,0) ,
          new ParDef("@AV9WWPNotificationDefinitionId",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002Y2", "SELECT TOP 1 [WWPSubscriptionSubscribed], [WWPUserExtendedId], [WWPNotificationDefinitionId], [WWPSubscriptionId] FROM [WWP_Subscription] WHERE ([WWPUserExtendedId] = @AV12Udparg1) AND ([WWPNotificationDefinitionId] = @AV9WWPNotificationDefinitionId) AND ([WWPSubscriptionSubscribed] = 0) ORDER BY [WWPUserExtendedId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Y2,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
