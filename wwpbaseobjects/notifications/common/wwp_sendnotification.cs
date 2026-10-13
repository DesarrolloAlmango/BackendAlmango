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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_sendnotification : GXProcedure
   {
      public wwp_sendnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_sendnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPNotificationDefinitionName ,
                           string aP1_WWPEntityName ,
                           string aP2_WWPSubscriptionEntityRecordId ,
                           string aP3_pWWPNotificationDefinitionIcon ,
                           string aP4_pWWPNotificationDefinitionTitle ,
                           string aP5_pWWPNotificationDefinitionShortDescription ,
                           string aP6_pWWPNotificationDefinitionLongDescription ,
                           string aP7_pWWPNotificationDefinitionLink ,
                           string aP8_WWPNotificationMetadata ,
                           string aP9_ExcludedWWPUserExtendedIdCollectionJson ,
                           bool aP10_MakeCommit )
      {
         this.AV23WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV18WWPEntityName = aP1_WWPEntityName;
         this.AV27WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV13pWWPNotificationDefinitionIcon = aP3_pWWPNotificationDefinitionIcon;
         this.AV17pWWPNotificationDefinitionTitle = aP4_pWWPNotificationDefinitionTitle;
         this.AV16pWWPNotificationDefinitionShortDescription = aP5_pWWPNotificationDefinitionShortDescription;
         this.AV15pWWPNotificationDefinitionLongDescription = aP6_pWWPNotificationDefinitionLongDescription;
         this.AV14pWWPNotificationDefinitionLink = aP7_pWWPNotificationDefinitionLink;
         this.AV26WWPNotificationMetadata = aP8_WWPNotificationMetadata;
         this.AV11ExcludedWWPUserExtendedIdCollectionJson = aP9_ExcludedWWPUserExtendedIdCollectionJson;
         this.AV9MakeCommit = aP10_MakeCommit;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( string aP0_WWPNotificationDefinitionName ,
                                 string aP1_WWPEntityName ,
                                 string aP2_WWPSubscriptionEntityRecordId ,
                                 string aP3_pWWPNotificationDefinitionIcon ,
                                 string aP4_pWWPNotificationDefinitionTitle ,
                                 string aP5_pWWPNotificationDefinitionShortDescription ,
                                 string aP6_pWWPNotificationDefinitionLongDescription ,
                                 string aP7_pWWPNotificationDefinitionLink ,
                                 string aP8_WWPNotificationMetadata ,
                                 string aP9_ExcludedWWPUserExtendedIdCollectionJson ,
                                 bool aP10_MakeCommit )
      {
         this.AV23WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV18WWPEntityName = aP1_WWPEntityName;
         this.AV27WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV13pWWPNotificationDefinitionIcon = aP3_pWWPNotificationDefinitionIcon;
         this.AV17pWWPNotificationDefinitionTitle = aP4_pWWPNotificationDefinitionTitle;
         this.AV16pWWPNotificationDefinitionShortDescription = aP5_pWWPNotificationDefinitionShortDescription;
         this.AV15pWWPNotificationDefinitionLongDescription = aP6_pWWPNotificationDefinitionLongDescription;
         this.AV14pWWPNotificationDefinitionLink = aP7_pWWPNotificationDefinitionLink;
         this.AV26WWPNotificationMetadata = aP8_WWPNotificationMetadata;
         this.AV11ExcludedWWPUserExtendedIdCollectionJson = aP9_ExcludedWWPUserExtendedIdCollectionJson;
         this.AV9MakeCommit = aP10_MakeCommit;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11ExcludedWWPUserExtendedIdCollectionJson)) )
         {
            AV10ExcludedWWPUserExtendedIdCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         }
         else
         {
            AV10ExcludedWWPUserExtendedIdCollection.FromJSonString(AV11ExcludedWWPUserExtendedIdCollectionJson, null);
         }
         AV10ExcludedWWPUserExtendedIdCollection.Add(new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( ), 0);
         AV29Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context).executeUdp(  AV18WWPEntityName);
         /* Using cursor P003E2 */
         pr_default.execute(0, new Object[] {AV29Udparg1, AV23WWPNotificationDefinitionName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A32WWPNotificationDefinitionId = P003E2_A32WWPNotificationDefinitionId[0];
            A29WWPEntityId = P003E2_A29WWPEntityId[0];
            A68WWPNotificationDefinitionName = P003E2_A68WWPNotificationDefinitionName[0];
            A71WWPNotificationDefinitionIcon = P003E2_A71WWPNotificationDefinitionIcon[0];
            A72WWPNotificationDefinitionTitle = P003E2_A72WWPNotificationDefinitionTitle[0];
            A73WWPNotificationDefinitionShort = P003E2_A73WWPNotificationDefinitionShort[0];
            A74WWPNotificationDefinitionLongD = P003E2_A74WWPNotificationDefinitionLongD[0];
            A75WWPNotificationDefinitionLink = P003E2_A75WWPNotificationDefinitionLink[0];
            AV20WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13pWWPNotificationDefinitionIcon)) )
            {
               AV19WWPNotificationDefinitionIcon = A71WWPNotificationDefinitionIcon;
            }
            else
            {
               AV19WWPNotificationDefinitionIcon = AV13pWWPNotificationDefinitionIcon;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17pWWPNotificationDefinitionTitle)) )
            {
               AV25WWPNotificationDefinitionTitle = A72WWPNotificationDefinitionTitle;
            }
            else
            {
               AV25WWPNotificationDefinitionTitle = AV17pWWPNotificationDefinitionTitle;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16pWWPNotificationDefinitionShortDescription)) )
            {
               AV24WWPNotificationDefinitionShortDescription = A73WWPNotificationDefinitionShort;
            }
            else
            {
               AV24WWPNotificationDefinitionShortDescription = AV16pWWPNotificationDefinitionShortDescription;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15pWWPNotificationDefinitionLongDescription)) )
            {
               AV22WWPNotificationDefinitionLongDescription = A74WWPNotificationDefinitionLongD;
            }
            else
            {
               AV22WWPNotificationDefinitionLongDescription = AV15pWWPNotificationDefinitionLongDescription;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14pWWPNotificationDefinitionLink)) )
            {
               AV21WWPNotificationDefinitionLink = A75WWPNotificationDefinitionLink;
            }
            else
            {
               AV21WWPNotificationDefinitionLink = AV14pWWPNotificationDefinitionLink;
            }
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV27WWPSubscriptionEntityRecordId ,
                                                 A35WWPSubscriptionEntityRecordId ,
                                                 A32WWPNotificationDefinitionId } ,
                                                 new int[]{
                                                 TypeConstants.LONG
                                                 }
            });
            /* Using cursor P003E3 */
            pr_default.execute(1, new Object[] {A32WWPNotificationDefinitionId, AV27WWPSubscriptionEntityRecordId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A35WWPSubscriptionEntityRecordId = P003E3_A35WWPSubscriptionEntityRecordId[0];
               A1WWPUserExtendedId = P003E3_A1WWPUserExtendedId[0];
               n1WWPUserExtendedId = P003E3_n1WWPUserExtendedId[0];
               A36WWPSubscriptionSubscribed = P003E3_A36WWPSubscriptionSubscribed[0];
               A28WWPSubscriptionRoleId = P003E3_A28WWPSubscriptionRoleId[0];
               n28WWPSubscriptionRoleId = P003E3_n28WWPSubscriptionRoleId[0];
               A34WWPSubscriptionId = P003E3_A34WWPSubscriptionId[0];
               if ( ! ( (AV10ExcludedWWPUserExtendedIdCollection.IndexOf(StringUtil.RTrim( A1WWPUserExtendedId))>0) ) )
               {
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) && A36WWPSubscriptionSubscribed )
                  {
                     AV8WWPUserExtendedId = A1WWPUserExtendedId;
                     new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_createnotificationtouser(context ).execute(  AV8WWPUserExtendedId,  AV20WWPNotificationDefinitionId,  AV25WWPNotificationDefinitionTitle,  AV24WWPNotificationDefinitionShortDescription,  AV22WWPNotificationDefinitionLongDescription, ref  AV21WWPNotificationDefinitionLink,  AV26WWPNotificationMetadata,  AV19WWPNotificationDefinitionIcon,  StringUtil.StartsWith( AV23WWPNotificationDefinitionName, context.GetMessage( "Discussion", ""))) ;
                  }
                  else
                  {
                     AV32GXV2 = 1;
                     GXt_objcol_char1 = AV31GXV1;
                     new GeneXus.Programs.wwpbaseobjects.wwp_getusersfromrole(context ).execute(  A28WWPSubscriptionRoleId, out  GXt_objcol_char1) ;
                     AV31GXV1 = GXt_objcol_char1;
                     while ( AV32GXV2 <= AV31GXV1.Count )
                     {
                        AV8WWPUserExtendedId = AV31GXV1.GetString(AV32GXV2);
                        /* Execute user subroutine: 'INCLUDENOTIFICATIONTOUSER' */
                        S111 ();
                        if ( returnInSub )
                        {
                           pr_default.close(1);
                           cleanup();
                           if (true) return;
                        }
                        if ( AV12IncludeNotificationToUser )
                        {
                           new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_createnotificationtouser(context ).execute(  AV8WWPUserExtendedId,  AV20WWPNotificationDefinitionId,  AV25WWPNotificationDefinitionTitle,  AV24WWPNotificationDefinitionShortDescription,  AV22WWPNotificationDefinitionLongDescription, ref  AV21WWPNotificationDefinitionLink,  AV26WWPNotificationMetadata,  AV19WWPNotificationDefinitionIcon,  StringUtil.StartsWith( AV23WWPNotificationDefinitionName, context.GetMessage( "Discussion", ""))) ;
                        }
                        AV32GXV2 = (int)(AV32GXV2+1);
                     }
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV9MakeCommit )
         {
            context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_sendnotification",pr_default);
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendpendingnotifications(context).executeSubmit( ) ;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'INCLUDENOTIFICATIONTOUSER' Routine */
         returnInSub = false;
         /* Using cursor P003E5 */
         pr_default.execute(2, new Object[] {AV20WWPNotificationDefinitionId, AV8WWPUserExtendedId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40000GXC1 = P003E5_A40000GXC1[0];
            n40000GXC1 = P003E5_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(2);
         AV12IncludeNotificationToUser = (bool)((A40000GXC1==0));
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

      protected override void CloseCursors( )
      {
      }

      public override void initialize( )
      {
         AV10ExcludedWWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         P003E2_A32WWPNotificationDefinitionId = new long[1] ;
         P003E2_A29WWPEntityId = new long[1] ;
         P003E2_A68WWPNotificationDefinitionName = new string[] {""} ;
         P003E2_A71WWPNotificationDefinitionIcon = new string[] {""} ;
         P003E2_A72WWPNotificationDefinitionTitle = new string[] {""} ;
         P003E2_A73WWPNotificationDefinitionShort = new string[] {""} ;
         P003E2_A74WWPNotificationDefinitionLongD = new string[] {""} ;
         P003E2_A75WWPNotificationDefinitionLink = new string[] {""} ;
         A68WWPNotificationDefinitionName = "";
         A71WWPNotificationDefinitionIcon = "";
         A72WWPNotificationDefinitionTitle = "";
         A73WWPNotificationDefinitionShort = "";
         A74WWPNotificationDefinitionLongD = "";
         A75WWPNotificationDefinitionLink = "";
         AV19WWPNotificationDefinitionIcon = "";
         AV25WWPNotificationDefinitionTitle = "";
         AV24WWPNotificationDefinitionShortDescription = "";
         AV22WWPNotificationDefinitionLongDescription = "";
         AV21WWPNotificationDefinitionLink = "";
         A35WWPSubscriptionEntityRecordId = "";
         P003E3_A32WWPNotificationDefinitionId = new long[1] ;
         P003E3_A35WWPSubscriptionEntityRecordId = new string[] {""} ;
         P003E3_A1WWPUserExtendedId = new string[] {""} ;
         P003E3_n1WWPUserExtendedId = new bool[] {false} ;
         P003E3_A36WWPSubscriptionSubscribed = new bool[] {false} ;
         P003E3_A28WWPSubscriptionRoleId = new string[] {""} ;
         P003E3_n28WWPSubscriptionRoleId = new bool[] {false} ;
         P003E3_A34WWPSubscriptionId = new long[1] ;
         A1WWPUserExtendedId = "";
         A28WWPSubscriptionRoleId = "";
         AV8WWPUserExtendedId = "";
         AV31GXV1 = new GxSimpleCollection<string>();
         GXt_objcol_char1 = new GxSimpleCollection<string>();
         P003E5_A40000GXC1 = new int[1] ;
         P003E5_n40000GXC1 = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification__default(),
            new Object[][] {
                new Object[] {
               P003E2_A32WWPNotificationDefinitionId, P003E2_A29WWPEntityId, P003E2_A68WWPNotificationDefinitionName, P003E2_A71WWPNotificationDefinitionIcon, P003E2_A72WWPNotificationDefinitionTitle, P003E2_A73WWPNotificationDefinitionShort, P003E2_A74WWPNotificationDefinitionLongD, P003E2_A75WWPNotificationDefinitionLink
               }
               , new Object[] {
               P003E3_A32WWPNotificationDefinitionId, P003E3_A35WWPSubscriptionEntityRecordId, P003E3_A1WWPUserExtendedId, P003E3_n1WWPUserExtendedId, P003E3_A36WWPSubscriptionSubscribed, P003E3_A28WWPSubscriptionRoleId, P003E3_n28WWPSubscriptionRoleId, P003E3_A34WWPSubscriptionId
               }
               , new Object[] {
               P003E5_A40000GXC1, P003E5_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV32GXV2 ;
      private int A40000GXC1 ;
      private long AV29Udparg1 ;
      private long A32WWPNotificationDefinitionId ;
      private long A29WWPEntityId ;
      private long AV20WWPNotificationDefinitionId ;
      private long A34WWPSubscriptionId ;
      private string A1WWPUserExtendedId ;
      private string A28WWPSubscriptionRoleId ;
      private string AV8WWPUserExtendedId ;
      private bool AV9MakeCommit ;
      private bool n1WWPUserExtendedId ;
      private bool A36WWPSubscriptionSubscribed ;
      private bool n28WWPSubscriptionRoleId ;
      private bool returnInSub ;
      private bool AV12IncludeNotificationToUser ;
      private bool n40000GXC1 ;
      private string AV26WWPNotificationMetadata ;
      private string AV11ExcludedWWPUserExtendedIdCollectionJson ;
      private string AV23WWPNotificationDefinitionName ;
      private string AV18WWPEntityName ;
      private string AV27WWPSubscriptionEntityRecordId ;
      private string AV13pWWPNotificationDefinitionIcon ;
      private string AV17pWWPNotificationDefinitionTitle ;
      private string AV16pWWPNotificationDefinitionShortDescription ;
      private string AV15pWWPNotificationDefinitionLongDescription ;
      private string AV14pWWPNotificationDefinitionLink ;
      private string A68WWPNotificationDefinitionName ;
      private string A71WWPNotificationDefinitionIcon ;
      private string A72WWPNotificationDefinitionTitle ;
      private string A73WWPNotificationDefinitionShort ;
      private string A74WWPNotificationDefinitionLongD ;
      private string A75WWPNotificationDefinitionLink ;
      private string AV19WWPNotificationDefinitionIcon ;
      private string AV25WWPNotificationDefinitionTitle ;
      private string AV24WWPNotificationDefinitionShortDescription ;
      private string AV22WWPNotificationDefinitionLongDescription ;
      private string AV21WWPNotificationDefinitionLink ;
      private string A35WWPSubscriptionEntityRecordId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV10ExcludedWWPUserExtendedIdCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P003E2_A32WWPNotificationDefinitionId ;
      private long[] P003E2_A29WWPEntityId ;
      private string[] P003E2_A68WWPNotificationDefinitionName ;
      private string[] P003E2_A71WWPNotificationDefinitionIcon ;
      private string[] P003E2_A72WWPNotificationDefinitionTitle ;
      private string[] P003E2_A73WWPNotificationDefinitionShort ;
      private string[] P003E2_A74WWPNotificationDefinitionLongD ;
      private string[] P003E2_A75WWPNotificationDefinitionLink ;
      private long[] P003E3_A32WWPNotificationDefinitionId ;
      private string[] P003E3_A35WWPSubscriptionEntityRecordId ;
      private string[] P003E3_A1WWPUserExtendedId ;
      private bool[] P003E3_n1WWPUserExtendedId ;
      private bool[] P003E3_A36WWPSubscriptionSubscribed ;
      private string[] P003E3_A28WWPSubscriptionRoleId ;
      private bool[] P003E3_n28WWPSubscriptionRoleId ;
      private long[] P003E3_A34WWPSubscriptionId ;
      private GxSimpleCollection<string> AV31GXV1 ;
      private GxSimpleCollection<string> GXt_objcol_char1 ;
      private int[] P003E5_A40000GXC1 ;
      private bool[] P003E5_n40000GXC1 ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_sendnotification__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_sendnotification__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P003E3( IGxContext context ,
                                           string AV27WWPSubscriptionEntityRecordId ,
                                           string A35WWPSubscriptionEntityRecordId ,
                                           long A32WWPNotificationDefinitionId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int2 = new short[2];
       Object[] GXv_Object3 = new Object[2];
       scmdbuf = "SELECT [WWPNotificationDefinitionId], [WWPSubscriptionEntityRecordId], [WWPUserExtendedId], [WWPSubscriptionSubscribed], [WWPSubscriptionRoleId], [WWPSubscriptionId] FROM [WWP_Subscription]";
       AddWhere(sWhereString, "([WWPNotificationDefinitionId] = @WWPNotificationDefinitionId)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27WWPSubscriptionEntityRecordId)) )
       {
          AddWhere(sWhereString, "([WWPSubscriptionEntityRecordId] = @AV27WWPSubscriptionEntityRecordId)");
       }
       else
       {
          GXv_int2[1] = 1;
       }
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY [WWPNotificationDefinitionId]";
       GXv_Object3[0] = scmdbuf;
       GXv_Object3[1] = GXv_int2;
       return GXv_Object3 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 1 :
                   return conditional_P003E3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (long)dynConstraints[2] );
       }
       return base.getDynamicStatement(cursor, context, dynConstraints);
    }

    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP003E2;
        prmP003E2 = new Object[] {
        new ParDef("@AV29Udparg1",GXType.Decimal,10,0) ,
        new ParDef("@AV23WWPNotificationDefinitionName",GXType.NVarChar,100,0)
        };
        Object[] prmP003E5;
        prmP003E5 = new Object[] {
        new ParDef("@AV20WWPNotificationDefinitionId",GXType.Decimal,10,0) ,
        new ParDef("@AV8WWPUserExtendedId",GXType.NChar,40,0)
        };
        Object[] prmP003E3;
        prmP003E3 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0) ,
        new ParDef("@AV27WWPSubscriptionEntityRecordId",GXType.NVarChar,2000,0)
        };
        def= new CursorDef[] {
            new CursorDef("P003E2", "SELECT [WWPNotificationDefinitionId], [WWPEntityId], [WWPNotificationDefinitionName], [WWPNotificationDefinitionIcon], [WWPNotificationDefinitionTitle], [WWPNotificationDefinitionShort], [WWPNotificationDefinitionLongD], [WWPNotificationDefinitionLink] FROM [WWP_NotificationDefinition] WHERE ([WWPEntityId] = @AV29Udparg1) AND ([WWPNotificationDefinitionName] = @AV23WWPNotificationDefinitionName) ORDER BY [WWPEntityId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003E2,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P003E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003E3,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P003E5", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM ([WWP_Subscription] T2 INNER JOIN [WWP_NotificationDefinition] T3 ON T3.[WWPNotificationDefinitionId] = T2.[WWPNotificationDefinitionId]) WHERE (T2.[WWPNotificationDefinitionId] = @AV20WWPNotificationDefinitionId) AND (T2.[WWPUserExtendedId] = @AV8WWPUserExtendedId) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003E5,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 40);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((bool[]) buf[4])[0] = rslt.getBool(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((long[]) buf[7])[0] = rslt.getLong(6);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
     }
  }

}

}
