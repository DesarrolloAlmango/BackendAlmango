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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_subscribeloggedusertodiscussion : GXProcedure
   {
      public wwp_subscribeloggedusertodiscussion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_subscribeloggedusertodiscussion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPNotificationDefinitionName ,
                           string aP1_WWPEntityName ,
                           string aP2_WWPSubscriptionEntityRecordId ,
                           string aP3_WWPSubscriptionEntityRecordDescription )
      {
         this.AV8WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV12WWPEntityName = aP1_WWPEntityName;
         this.AV9WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV11WWPSubscriptionEntityRecordDescription = aP3_WWPSubscriptionEntityRecordDescription;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( string aP0_WWPNotificationDefinitionName ,
                                 string aP1_WWPEntityName ,
                                 string aP2_WWPSubscriptionEntityRecordId ,
                                 string aP3_WWPSubscriptionEntityRecordDescription )
      {
         this.AV8WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV12WWPEntityName = aP1_WWPEntityName;
         this.AV9WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV11WWPSubscriptionEntityRecordDescription = aP3_WWPSubscriptionEntityRecordDescription;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13GXLvl1 = 0;
         AV14Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context).executeUdp(  AV12WWPEntityName);
         /* Using cursor P00AF2 */
         pr_default.execute(0, new Object[] {AV14Udparg1, AV8WWPNotificationDefinitionName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A32WWPNotificationDefinitionId = P00AF2_A32WWPNotificationDefinitionId[0];
            A29WWPEntityId = P00AF2_A29WWPEntityId[0];
            A68WWPNotificationDefinitionName = P00AF2_A68WWPNotificationDefinitionName[0];
            AV13GXLvl1 = 1;
            AV15GXLvl5 = 0;
            AV16Udparg2 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
            /* Optimized UPDATE. */
            /* Using cursor P00AF3 */
            pr_default.execute(1, new Object[] {AV16Udparg2, A32WWPNotificationDefinitionId, AV9WWPSubscriptionEntityRecordId});
            if ( (pr_default.getStatus(1) != 101) )
            {
               AV15GXLvl5 = 1;
            }
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
            /* End optimized UPDATE. */
            if ( AV15GXLvl5 == 0 )
            {
               AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
               AV10WWPSubscription.gxTpr_Wwpnotificationdefinitionid = A32WWPNotificationDefinitionId;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
               AV10WWPSubscription.gxTpr_Wwpuserextendedid = GXt_char1;
               AV10WWPSubscription.gxTpr_Wwpsubscriptionentityrecordid = AV9WWPSubscriptionEntityRecordId;
               AV10WWPSubscription.gxTpr_Wwpsubscriptionentityrecorddescription = AV11WWPSubscriptionEntityRecordDescription;
               AV10WWPSubscription.gxTpr_Wwpsubscriptionsubscribed = true;
               AV10WWPSubscription.Save();
               if ( AV10WWPSubscription.Success() )
               {
                  context.CommitDataStores("wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion",pr_default);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV13GXLvl1 == 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV17Pgmname,  StringUtil.Format( "WWP_NotificationDefinition not found: %1", AV8WWPNotificationDefinitionName, "", "", "", "", "", "", "", "")) ;
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00AF2_A32WWPNotificationDefinitionId = new long[1] ;
         P00AF2_A29WWPEntityId = new long[1] ;
         P00AF2_A68WWPNotificationDefinitionName = new string[] {""} ;
         A68WWPNotificationDefinitionName = "";
         AV16Udparg2 = "";
         AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
         GXt_char1 = "";
         AV17Pgmname = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion__default(),
            new Object[][] {
                new Object[] {
               P00AF2_A32WWPNotificationDefinitionId, P00AF2_A29WWPEntityId, P00AF2_A68WWPNotificationDefinitionName
               }
               , new Object[] {
               }
            }
         );
         AV17Pgmname = "WWPBaseObjects.Discussions.WWP_SubscribeLoggedUserToDiscussion";
         /* GeneXus formulas. */
         AV17Pgmname = "WWPBaseObjects.Discussions.WWP_SubscribeLoggedUserToDiscussion";
      }

      private short AV13GXLvl1 ;
      private short AV15GXLvl5 ;
      private long AV14Udparg1 ;
      private long A32WWPNotificationDefinitionId ;
      private long A29WWPEntityId ;
      private string AV16Udparg2 ;
      private string GXt_char1 ;
      private string AV17Pgmname ;
      private string AV8WWPNotificationDefinitionName ;
      private string AV12WWPEntityName ;
      private string AV9WWPSubscriptionEntityRecordId ;
      private string AV11WWPSubscriptionEntityRecordDescription ;
      private string A68WWPNotificationDefinitionName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00AF2_A32WWPNotificationDefinitionId ;
      private long[] P00AF2_A29WWPEntityId ;
      private string[] P00AF2_A68WWPNotificationDefinitionName ;
      private GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription AV10WWPSubscription ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_subscribeloggedusertodiscussion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_subscribeloggedusertodiscussion__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00AF2;
        prmP00AF2 = new Object[] {
        new ParDef("@AV14Udparg1",GXType.Decimal,10,0) ,
        new ParDef("@AV8WWPNotificationDefinitionName",GXType.NVarChar,100,0)
        };
        Object[] prmP00AF3;
        prmP00AF3 = new Object[] {
        new ParDef("@AV16Udparg2",GXType.NChar,40,0) ,
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0) ,
        new ParDef("@AV9WWPSubscriptionEntityRecordId",GXType.NVarChar,2000,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00AF2", "SELECT [WWPNotificationDefinitionId], [WWPEntityId], [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE ([WWPEntityId] = @AV14Udparg1) AND ([WWPNotificationDefinitionName] = @AV8WWPNotificationDefinitionName) ORDER BY [WWPEntityId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AF2,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00AF3", "UPDATE [WWP_Subscription] SET [WWPSubscriptionSubscribed]=CONVERT(BIT, 1)  WHERE ([WWPUserExtendedId] = @AV16Udparg2) AND ([WWPNotificationDefinitionId] = @WWPNotificationDefinitionId) AND ([WWPSubscriptionEntityRecordId] = @AV9WWPSubscriptionEntityRecordId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00AF3)
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
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
     }
  }

}

}
