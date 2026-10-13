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
   public class wwp_subscribementioneduserstodiscussion : GXProcedure
   {
      public wwp_subscribementioneduserstodiscussion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_subscribementioneduserstodiscussion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPNotificationDefinitionName ,
                           string aP1_WWPEntityName ,
                           string aP2_WWPSubscriptionEntityRecordId ,
                           string aP3_WWPSubscriptionEntityRecordDescription ,
                           string aP4_MentionWWPUserExtendedIdCollectionJson )
      {
         this.AV8WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV14WWPEntityName = aP1_WWPEntityName;
         this.AV9WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV11WWPSubscriptionEntityRecordDescription = aP3_WWPSubscriptionEntityRecordDescription;
         this.AV15MentionWWPUserExtendedIdCollectionJson = aP4_MentionWWPUserExtendedIdCollectionJson;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( string aP0_WWPNotificationDefinitionName ,
                                 string aP1_WWPEntityName ,
                                 string aP2_WWPSubscriptionEntityRecordId ,
                                 string aP3_WWPSubscriptionEntityRecordDescription ,
                                 string aP4_MentionWWPUserExtendedIdCollectionJson )
      {
         this.AV8WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV14WWPEntityName = aP1_WWPEntityName;
         this.AV9WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV11WWPSubscriptionEntityRecordDescription = aP3_WWPSubscriptionEntityRecordDescription;
         this.AV15MentionWWPUserExtendedIdCollectionJson = aP4_MentionWWPUserExtendedIdCollectionJson;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12MentionWWPUserExtendedIdCollection.FromJSonString(AV15MentionWWPUserExtendedIdCollectionJson, null);
         AV16GXLvl2 = 0;
         AV17Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context).executeUdp(  AV14WWPEntityName);
         /* Using cursor P00AE2 */
         pr_default.execute(0, new Object[] {AV17Udparg1, AV8WWPNotificationDefinitionName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A32WWPNotificationDefinitionId = P00AE2_A32WWPNotificationDefinitionId[0];
            A29WWPEntityId = P00AE2_A29WWPEntityId[0];
            A68WWPNotificationDefinitionName = P00AE2_A68WWPNotificationDefinitionName[0];
            AV16GXLvl2 = 1;
            AV18GXV1 = 1;
            while ( AV18GXV1 <= AV12MentionWWPUserExtendedIdCollection.Count )
            {
               AV13WWPUserExtendedId = AV12MentionWWPUserExtendedIdCollection.GetString(AV18GXV1);
               AV19GXLvl6 = 0;
               /* Optimized UPDATE. */
               /* Using cursor P00AE3 */
               pr_default.execute(1, new Object[] {AV13WWPUserExtendedId, A32WWPNotificationDefinitionId, AV9WWPSubscriptionEntityRecordId});
               if ( (pr_default.getStatus(1) != 101) )
               {
                  AV19GXLvl6 = 1;
               }
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
               /* End optimized UPDATE. */
               if ( AV19GXLvl6 == 0 )
               {
                  AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
                  AV10WWPSubscription.gxTpr_Wwpnotificationdefinitionid = A32WWPNotificationDefinitionId;
                  AV10WWPSubscription.gxTpr_Wwpuserextendedid = AV13WWPUserExtendedId;
                  AV10WWPSubscription.gxTpr_Wwpsubscriptionentityrecordid = AV9WWPSubscriptionEntityRecordId;
                  AV10WWPSubscription.gxTpr_Wwpsubscriptionentityrecorddescription = AV11WWPSubscriptionEntityRecordDescription;
                  AV10WWPSubscription.gxTpr_Wwpsubscriptionsubscribed = true;
                  AV10WWPSubscription.Save();
                  if ( ! AV10WWPSubscription.Success() )
                  {
                     new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  context.GetMessage( "Subscribe Mentioned User", ""),  AV10WWPSubscription.GetMessages().ToJSonString(false)) ;
                  }
               }
               AV18GXV1 = (int)(AV18GXV1+1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV16GXLvl2 == 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV20Pgmname,  StringUtil.Format( "WWP_NotificationDefinition not found: %1", AV8WWPNotificationDefinitionName, "", "", "", "", "", "", "", "")) ;
         }
         context.CommitDataStores("wwpbaseobjects.discussions.wwp_subscribementioneduserstodiscussion",pr_default);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.discussions.wwp_subscribementioneduserstodiscussion",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV12MentionWWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         P00AE2_A32WWPNotificationDefinitionId = new long[1] ;
         P00AE2_A29WWPEntityId = new long[1] ;
         P00AE2_A68WWPNotificationDefinitionName = new string[] {""} ;
         A68WWPNotificationDefinitionName = "";
         AV13WWPUserExtendedId = "";
         AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
         AV20Pgmname = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribementioneduserstodiscussion__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribementioneduserstodiscussion__default(),
            new Object[][] {
                new Object[] {
               P00AE2_A32WWPNotificationDefinitionId, P00AE2_A29WWPEntityId, P00AE2_A68WWPNotificationDefinitionName
               }
               , new Object[] {
               }
            }
         );
         AV20Pgmname = "WWPBaseObjects.Discussions.WWP_SubscribeMentionedUsersToDiscussion";
         /* GeneXus formulas. */
         AV20Pgmname = "WWPBaseObjects.Discussions.WWP_SubscribeMentionedUsersToDiscussion";
      }

      private short AV16GXLvl2 ;
      private short AV19GXLvl6 ;
      private int AV18GXV1 ;
      private long AV17Udparg1 ;
      private long A32WWPNotificationDefinitionId ;
      private long A29WWPEntityId ;
      private string AV13WWPUserExtendedId ;
      private string AV20Pgmname ;
      private string AV15MentionWWPUserExtendedIdCollectionJson ;
      private string AV8WWPNotificationDefinitionName ;
      private string AV14WWPEntityName ;
      private string AV9WWPSubscriptionEntityRecordId ;
      private string AV11WWPSubscriptionEntityRecordDescription ;
      private string A68WWPNotificationDefinitionName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV12MentionWWPUserExtendedIdCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P00AE2_A32WWPNotificationDefinitionId ;
      private long[] P00AE2_A29WWPEntityId ;
      private string[] P00AE2_A68WWPNotificationDefinitionName ;
      private GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription AV10WWPSubscription ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_subscribementioneduserstodiscussion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_subscribementioneduserstodiscussion__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00AE2;
        prmP00AE2 = new Object[] {
        new ParDef("@AV17Udparg1",GXType.Decimal,10,0) ,
        new ParDef("@AV8WWPNotificationDefinitionName",GXType.NVarChar,100,0)
        };
        Object[] prmP00AE3;
        prmP00AE3 = new Object[] {
        new ParDef("@AV13WWPUserExtendedId",GXType.NChar,40,0) ,
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0) ,
        new ParDef("@AV9WWPSubscriptionEntityRecordId",GXType.NVarChar,2000,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00AE2", "SELECT [WWPNotificationDefinitionId], [WWPEntityId], [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE ([WWPEntityId] = @AV17Udparg1) AND ([WWPNotificationDefinitionName] = @AV8WWPNotificationDefinitionName) ORDER BY [WWPEntityId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AE2,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00AE3", "UPDATE [WWP_Subscription] SET [WWPSubscriptionSubscribed]=CONVERT(BIT, 1)  WHERE ([WWPUserExtendedId] = @AV13WWPUserExtendedId) AND ([WWPNotificationDefinitionId] = @WWPNotificationDefinitionId) AND ([WWPSubscriptionEntityRecordId] = @AV9WWPSubscriptionEntityRecordId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00AE3)
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
