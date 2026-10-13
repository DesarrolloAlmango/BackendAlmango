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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_subscription_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_subscription_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_subscription_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0910( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0910( ) ;
         standaloneModal( ) ;
         AddRow0910( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z34WWPSubscriptionId = A34WWPSubscriptionId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_090( )
      {
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0910( ) ;
            }
            else
            {
               CheckExtendedTable0910( ) ;
               if ( AnyError == 0 )
               {
                  ZM0910( 3) ;
                  ZM0910( 4) ;
                  ZM0910( 5) ;
               }
               CloseExtendedTableCursors0910( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0910( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z35WWPSubscriptionEntityRecordId = A35WWPSubscriptionEntityRecordId;
            Z37WWPSubscriptionEntityRecordDes = A37WWPSubscriptionEntityRecordDes;
            Z28WWPSubscriptionRoleId = A28WWPSubscriptionRoleId;
            Z36WWPSubscriptionSubscribed = A36WWPSubscriptionSubscribed;
            Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z29WWPEntityId = A29WWPEntityId;
            Z38WWPNotificationDefinitionDescr = A38WWPNotificationDefinitionDescr;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z30WWPEntityName = A30WWPEntityName;
         }
         if ( GX_JID == -2 )
         {
            Z34WWPSubscriptionId = A34WWPSubscriptionId;
            Z35WWPSubscriptionEntityRecordId = A35WWPSubscriptionEntityRecordId;
            Z37WWPSubscriptionEntityRecordDes = A37WWPSubscriptionEntityRecordDes;
            Z28WWPSubscriptionRoleId = A28WWPSubscriptionRoleId;
            Z36WWPSubscriptionSubscribed = A36WWPSubscriptionSubscribed;
            Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z29WWPEntityId = A29WWPEntityId;
            Z38WWPNotificationDefinitionDescr = A38WWPNotificationDefinitionDescr;
            Z30WWPEntityName = A30WWPEntityName;
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0910( )
      {
         /* Using cursor BC00097 */
         pr_default.execute(5, new Object[] {A34WWPSubscriptionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound10 = 1;
            A29WWPEntityId = BC00097_A29WWPEntityId[0];
            A38WWPNotificationDefinitionDescr = BC00097_A38WWPNotificationDefinitionDescr[0];
            A30WWPEntityName = BC00097_A30WWPEntityName[0];
            A2WWPUserExtendedFullName = BC00097_A2WWPUserExtendedFullName[0];
            A35WWPSubscriptionEntityRecordId = BC00097_A35WWPSubscriptionEntityRecordId[0];
            A37WWPSubscriptionEntityRecordDes = BC00097_A37WWPSubscriptionEntityRecordDes[0];
            A28WWPSubscriptionRoleId = BC00097_A28WWPSubscriptionRoleId[0];
            n28WWPSubscriptionRoleId = BC00097_n28WWPSubscriptionRoleId[0];
            A36WWPSubscriptionSubscribed = BC00097_A36WWPSubscriptionSubscribed[0];
            A32WWPNotificationDefinitionId = BC00097_A32WWPNotificationDefinitionId[0];
            A1WWPUserExtendedId = BC00097_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC00097_n1WWPUserExtendedId[0];
            ZM0910( -2) ;
         }
         pr_default.close(5);
         OnLoadActions0910( ) ;
      }

      protected void OnLoadActions0910( )
      {
      }

      protected void CheckExtendedTable0910( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00094 */
         pr_default.execute(2, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
         }
         A29WWPEntityId = BC00094_A29WWPEntityId[0];
         A38WWPNotificationDefinitionDescr = BC00094_A38WWPNotificationDefinitionDescr[0];
         pr_default.close(2);
         /* Using cursor BC00096 */
         pr_default.execute(4, new Object[] {A29WWPEntityId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A30WWPEntityName = BC00096_A30WWPEntityName[0];
         pr_default.close(4);
         /* Using cursor BC00095 */
         pr_default.execute(3, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
            }
         }
         A2WWPUserExtendedFullName = BC00095_A2WWPUserExtendedFullName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0910( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0910( )
      {
         /* Using cursor BC00098 */
         pr_default.execute(6, new Object[] {A34WWPSubscriptionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00093 */
         pr_default.execute(1, new Object[] {A34WWPSubscriptionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0910( 2) ;
            RcdFound10 = 1;
            A34WWPSubscriptionId = BC00093_A34WWPSubscriptionId[0];
            A35WWPSubscriptionEntityRecordId = BC00093_A35WWPSubscriptionEntityRecordId[0];
            A37WWPSubscriptionEntityRecordDes = BC00093_A37WWPSubscriptionEntityRecordDes[0];
            A28WWPSubscriptionRoleId = BC00093_A28WWPSubscriptionRoleId[0];
            n28WWPSubscriptionRoleId = BC00093_n28WWPSubscriptionRoleId[0];
            A36WWPSubscriptionSubscribed = BC00093_A36WWPSubscriptionSubscribed[0];
            A32WWPNotificationDefinitionId = BC00093_A32WWPNotificationDefinitionId[0];
            A1WWPUserExtendedId = BC00093_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC00093_n1WWPUserExtendedId[0];
            Z34WWPSubscriptionId = A34WWPSubscriptionId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0910( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0910( ) ;
            }
            Gx_mode = sMode10;
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0910( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode10;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0910( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_090( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0910( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00092 */
            pr_default.execute(0, new Object[] {A34WWPSubscriptionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z35WWPSubscriptionEntityRecordId, BC00092_A35WWPSubscriptionEntityRecordId[0]) != 0 ) || ( StringUtil.StrCmp(Z37WWPSubscriptionEntityRecordDes, BC00092_A37WWPSubscriptionEntityRecordDes[0]) != 0 ) || ( StringUtil.StrCmp(Z28WWPSubscriptionRoleId, BC00092_A28WWPSubscriptionRoleId[0]) != 0 ) || ( Z36WWPSubscriptionSubscribed != BC00092_A36WWPSubscriptionSubscribed[0] ) || ( Z32WWPNotificationDefinitionId != BC00092_A32WWPNotificationDefinitionId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1WWPUserExtendedId, BC00092_A1WWPUserExtendedId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Subscription"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0910( )
      {
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0910( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0910( 0) ;
            CheckOptimisticConcurrency0910( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0910( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0910( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00099 */
                     pr_default.execute(7, new Object[] {A35WWPSubscriptionEntityRecordId, A37WWPSubscriptionEntityRecordDes, n28WWPSubscriptionRoleId, A28WWPSubscriptionRoleId, A36WWPSubscriptionSubscribed, A32WWPNotificationDefinitionId, n1WWPUserExtendedId, A1WWPUserExtendedId});
                     A34WWPSubscriptionId = BC00099_A34WWPSubscriptionId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0910( ) ;
            }
            EndLevel0910( ) ;
         }
         CloseExtendedTableCursors0910( ) ;
      }

      protected void Update0910( )
      {
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0910( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0910( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0910( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0910( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000910 */
                     pr_default.execute(8, new Object[] {A35WWPSubscriptionEntityRecordId, A37WWPSubscriptionEntityRecordDes, n28WWPSubscriptionRoleId, A28WWPSubscriptionRoleId, A36WWPSubscriptionSubscribed, A32WWPNotificationDefinitionId, n1WWPUserExtendedId, A1WWPUserExtendedId, A34WWPSubscriptionId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0910( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0910( ) ;
         }
         CloseExtendedTableCursors0910( ) ;
      }

      protected void DeferredUpdate0910( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0910( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0910( ) ;
            AfterConfirm0910( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0910( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000911 */
                  pr_default.execute(9, new Object[] {A34WWPSubscriptionId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0910( ) ;
         Gx_mode = sMode10;
      }

      protected void OnDeleteControls0910( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000912 */
            pr_default.execute(10, new Object[] {A32WWPNotificationDefinitionId});
            A29WWPEntityId = BC000912_A29WWPEntityId[0];
            A38WWPNotificationDefinitionDescr = BC000912_A38WWPNotificationDefinitionDescr[0];
            pr_default.close(10);
            /* Using cursor BC000913 */
            pr_default.execute(11, new Object[] {A29WWPEntityId});
            A30WWPEntityName = BC000913_A30WWPEntityName[0];
            pr_default.close(11);
            /* Using cursor BC000914 */
            pr_default.execute(12, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
            A2WWPUserExtendedFullName = BC000914_A2WWPUserExtendedFullName[0];
            pr_default.close(12);
         }
      }

      protected void EndLevel0910( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0910( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0910( )
      {
         /* Using cursor BC000915 */
         pr_default.execute(13, new Object[] {A34WWPSubscriptionId});
         RcdFound10 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound10 = 1;
            A29WWPEntityId = BC000915_A29WWPEntityId[0];
            A34WWPSubscriptionId = BC000915_A34WWPSubscriptionId[0];
            A38WWPNotificationDefinitionDescr = BC000915_A38WWPNotificationDefinitionDescr[0];
            A30WWPEntityName = BC000915_A30WWPEntityName[0];
            A2WWPUserExtendedFullName = BC000915_A2WWPUserExtendedFullName[0];
            A35WWPSubscriptionEntityRecordId = BC000915_A35WWPSubscriptionEntityRecordId[0];
            A37WWPSubscriptionEntityRecordDes = BC000915_A37WWPSubscriptionEntityRecordDes[0];
            A28WWPSubscriptionRoleId = BC000915_A28WWPSubscriptionRoleId[0];
            n28WWPSubscriptionRoleId = BC000915_n28WWPSubscriptionRoleId[0];
            A36WWPSubscriptionSubscribed = BC000915_A36WWPSubscriptionSubscribed[0];
            A32WWPNotificationDefinitionId = BC000915_A32WWPNotificationDefinitionId[0];
            A1WWPUserExtendedId = BC000915_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000915_n1WWPUserExtendedId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0910( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound10 = 0;
         ScanKeyLoad0910( ) ;
      }

      protected void ScanKeyLoad0910( )
      {
         sMode10 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound10 = 1;
            A29WWPEntityId = BC000915_A29WWPEntityId[0];
            A34WWPSubscriptionId = BC000915_A34WWPSubscriptionId[0];
            A38WWPNotificationDefinitionDescr = BC000915_A38WWPNotificationDefinitionDescr[0];
            A30WWPEntityName = BC000915_A30WWPEntityName[0];
            A2WWPUserExtendedFullName = BC000915_A2WWPUserExtendedFullName[0];
            A35WWPSubscriptionEntityRecordId = BC000915_A35WWPSubscriptionEntityRecordId[0];
            A37WWPSubscriptionEntityRecordDes = BC000915_A37WWPSubscriptionEntityRecordDes[0];
            A28WWPSubscriptionRoleId = BC000915_A28WWPSubscriptionRoleId[0];
            n28WWPSubscriptionRoleId = BC000915_n28WWPSubscriptionRoleId[0];
            A36WWPSubscriptionSubscribed = BC000915_A36WWPSubscriptionSubscribed[0];
            A32WWPNotificationDefinitionId = BC000915_A32WWPNotificationDefinitionId[0];
            A1WWPUserExtendedId = BC000915_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000915_n1WWPUserExtendedId[0];
         }
         Gx_mode = sMode10;
      }

      protected void ScanKeyEnd0910( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0910( )
      {
         /* After Confirm Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) )
         {
            A1WWPUserExtendedId = "";
            n1WWPUserExtendedId = false;
            n1WWPUserExtendedId = true;
         }
      }

      protected void BeforeInsert0910( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0910( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0910( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0910( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0910( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0910( )
      {
      }

      protected void send_integrity_lvl_hashes0910( )
      {
      }

      protected void AddRow0910( )
      {
         VarsToRow10( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
      }

      protected void ReadRow0910( )
      {
         RowToVars10( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
      }

      protected void InitializeNonKey0910( )
      {
         A29WWPEntityId = 0;
         A32WWPNotificationDefinitionId = 0;
         A38WWPNotificationDefinitionDescr = "";
         A30WWPEntityName = "";
         A1WWPUserExtendedId = "";
         n1WWPUserExtendedId = false;
         A2WWPUserExtendedFullName = "";
         A35WWPSubscriptionEntityRecordId = "";
         A37WWPSubscriptionEntityRecordDes = "";
         A28WWPSubscriptionRoleId = "";
         n28WWPSubscriptionRoleId = false;
         A36WWPSubscriptionSubscribed = false;
         Z35WWPSubscriptionEntityRecordId = "";
         Z37WWPSubscriptionEntityRecordDes = "";
         Z28WWPSubscriptionRoleId = "";
         Z36WWPSubscriptionSubscribed = false;
         Z32WWPNotificationDefinitionId = 0;
         Z1WWPUserExtendedId = "";
      }

      protected void InitAll0910( )
      {
         A34WWPSubscriptionId = 0;
         InitializeNonKey0910( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow10( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription obj10 )
      {
         obj10.gxTpr_Mode = Gx_mode;
         obj10.gxTpr_Wwpnotificationdefinitionid = A32WWPNotificationDefinitionId;
         obj10.gxTpr_Wwpnotificationdefinitiondescription = A38WWPNotificationDefinitionDescr;
         obj10.gxTpr_Wwpentityname = A30WWPEntityName;
         obj10.gxTpr_Wwpuserextendedid = A1WWPUserExtendedId;
         obj10.gxTpr_Wwpuserextendedfullname = A2WWPUserExtendedFullName;
         obj10.gxTpr_Wwpsubscriptionentityrecordid = A35WWPSubscriptionEntityRecordId;
         obj10.gxTpr_Wwpsubscriptionentityrecorddescription = A37WWPSubscriptionEntityRecordDes;
         obj10.gxTpr_Wwpsubscriptionroleid = A28WWPSubscriptionRoleId;
         obj10.gxTpr_Wwpsubscriptionsubscribed = A36WWPSubscriptionSubscribed;
         obj10.gxTpr_Wwpsubscriptionid = A34WWPSubscriptionId;
         obj10.gxTpr_Wwpsubscriptionid_Z = Z34WWPSubscriptionId;
         obj10.gxTpr_Wwpnotificationdefinitionid_Z = Z32WWPNotificationDefinitionId;
         obj10.gxTpr_Wwpnotificationdefinitiondescription_Z = Z38WWPNotificationDefinitionDescr;
         obj10.gxTpr_Wwpentityname_Z = Z30WWPEntityName;
         obj10.gxTpr_Wwpuserextendedid_Z = Z1WWPUserExtendedId;
         obj10.gxTpr_Wwpuserextendedfullname_Z = Z2WWPUserExtendedFullName;
         obj10.gxTpr_Wwpsubscriptionentityrecordid_Z = Z35WWPSubscriptionEntityRecordId;
         obj10.gxTpr_Wwpsubscriptionentityrecorddescription_Z = Z37WWPSubscriptionEntityRecordDes;
         obj10.gxTpr_Wwpsubscriptionroleid_Z = Z28WWPSubscriptionRoleId;
         obj10.gxTpr_Wwpsubscriptionsubscribed_Z = Z36WWPSubscriptionSubscribed;
         obj10.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n1WWPUserExtendedId));
         obj10.gxTpr_Wwpsubscriptionroleid_N = (short)(Convert.ToInt16(n28WWPSubscriptionRoleId));
         obj10.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow10( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription obj10 )
      {
         obj10.gxTpr_Wwpsubscriptionid = A34WWPSubscriptionId;
         return  ;
      }

      public void RowToVars10( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription obj10 ,
                               int forceLoad )
      {
         Gx_mode = obj10.gxTpr_Mode;
         A32WWPNotificationDefinitionId = obj10.gxTpr_Wwpnotificationdefinitionid;
         A38WWPNotificationDefinitionDescr = obj10.gxTpr_Wwpnotificationdefinitiondescription;
         A30WWPEntityName = obj10.gxTpr_Wwpentityname;
         A1WWPUserExtendedId = obj10.gxTpr_Wwpuserextendedid;
         n1WWPUserExtendedId = false;
         A2WWPUserExtendedFullName = obj10.gxTpr_Wwpuserextendedfullname;
         A35WWPSubscriptionEntityRecordId = obj10.gxTpr_Wwpsubscriptionentityrecordid;
         A37WWPSubscriptionEntityRecordDes = obj10.gxTpr_Wwpsubscriptionentityrecorddescription;
         A28WWPSubscriptionRoleId = obj10.gxTpr_Wwpsubscriptionroleid;
         n28WWPSubscriptionRoleId = false;
         A36WWPSubscriptionSubscribed = obj10.gxTpr_Wwpsubscriptionsubscribed;
         A34WWPSubscriptionId = obj10.gxTpr_Wwpsubscriptionid;
         Z34WWPSubscriptionId = obj10.gxTpr_Wwpsubscriptionid_Z;
         Z32WWPNotificationDefinitionId = obj10.gxTpr_Wwpnotificationdefinitionid_Z;
         Z38WWPNotificationDefinitionDescr = obj10.gxTpr_Wwpnotificationdefinitiondescription_Z;
         Z30WWPEntityName = obj10.gxTpr_Wwpentityname_Z;
         Z1WWPUserExtendedId = obj10.gxTpr_Wwpuserextendedid_Z;
         Z2WWPUserExtendedFullName = obj10.gxTpr_Wwpuserextendedfullname_Z;
         Z35WWPSubscriptionEntityRecordId = obj10.gxTpr_Wwpsubscriptionentityrecordid_Z;
         Z37WWPSubscriptionEntityRecordDes = obj10.gxTpr_Wwpsubscriptionentityrecorddescription_Z;
         Z28WWPSubscriptionRoleId = obj10.gxTpr_Wwpsubscriptionroleid_Z;
         Z36WWPSubscriptionSubscribed = obj10.gxTpr_Wwpsubscriptionsubscribed_Z;
         n1WWPUserExtendedId = (bool)(Convert.ToBoolean(obj10.gxTpr_Wwpuserextendedid_N));
         n28WWPSubscriptionRoleId = (bool)(Convert.ToBoolean(obj10.gxTpr_Wwpsubscriptionroleid_N));
         Gx_mode = obj10.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A34WWPSubscriptionId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0910( ) ;
         ScanKeyStart0910( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z34WWPSubscriptionId = A34WWPSubscriptionId;
         }
         ZM0910( -2) ;
         OnLoadActions0910( ) ;
         AddRow0910( ) ;
         ScanKeyEnd0910( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars10( bcwwpbaseobjects_subscriptions_WWP_Subscription, 0) ;
         ScanKeyStart0910( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z34WWPSubscriptionId = A34WWPSubscriptionId;
         }
         ZM0910( -2) ;
         OnLoadActions0910( ) ;
         AddRow0910( ) ;
         ScanKeyEnd0910( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0910( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0910( ) ;
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( A34WWPSubscriptionId != Z34WWPSubscriptionId )
               {
                  A34WWPSubscriptionId = Z34WWPSubscriptionId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update0910( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A34WWPSubscriptionId != Z34WWPSubscriptionId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0910( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0910( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars10( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         SaveImpl( ) ;
         VarsToRow10( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars10( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0910( ) ;
         AfterTrn( ) ;
         VarsToRow10( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow10( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription auxBC = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A34WWPSubscriptionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_subscriptions_WWP_Subscription);
               auxBC.Save();
               bcwwpbaseobjects_subscriptions_WWP_Subscription.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars10( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars10( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0910( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow10( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow10( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars10( bcwwpbaseobjects_subscriptions_WWP_Subscription, 0) ;
         GetKey0910( ) ;
         if ( RcdFound10 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A34WWPSubscriptionId != Z34WWPSubscriptionId )
            {
               A34WWPSubscriptionId = Z34WWPSubscriptionId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A34WWPSubscriptionId != Z34WWPSubscriptionId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         pr_default.close(10);
         pr_default.close(12);
         pr_default.close(11);
         context.RollbackDataStores("wwpbaseobjects.subscriptions.wwp_subscription_bc",pr_default);
         VarsToRow10( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_subscriptions_WWP_Subscription )
         {
            bcwwpbaseobjects_subscriptions_WWP_Subscription = (GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow10( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
            }
            else
            {
               RowToVars10( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars10( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_Subscription WWP_Subscription_BC
      {
         get {
            return bcwwpbaseobjects_subscriptions_WWP_Subscription ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected override void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(10);
         pr_default.close(12);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z35WWPSubscriptionEntityRecordId = "";
         A35WWPSubscriptionEntityRecordId = "";
         Z37WWPSubscriptionEntityRecordDes = "";
         A37WWPSubscriptionEntityRecordDes = "";
         Z28WWPSubscriptionRoleId = "";
         A28WWPSubscriptionRoleId = "";
         Z1WWPUserExtendedId = "";
         A1WWPUserExtendedId = "";
         Z38WWPNotificationDefinitionDescr = "";
         A38WWPNotificationDefinitionDescr = "";
         Z2WWPUserExtendedFullName = "";
         A2WWPUserExtendedFullName = "";
         Z30WWPEntityName = "";
         A30WWPEntityName = "";
         BC00097_A29WWPEntityId = new long[1] ;
         BC00097_A34WWPSubscriptionId = new long[1] ;
         BC00097_A38WWPNotificationDefinitionDescr = new string[] {""} ;
         BC00097_A30WWPEntityName = new string[] {""} ;
         BC00097_A2WWPUserExtendedFullName = new string[] {""} ;
         BC00097_A35WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC00097_A37WWPSubscriptionEntityRecordDes = new string[] {""} ;
         BC00097_A28WWPSubscriptionRoleId = new string[] {""} ;
         BC00097_n28WWPSubscriptionRoleId = new bool[] {false} ;
         BC00097_A36WWPSubscriptionSubscribed = new bool[] {false} ;
         BC00097_A32WWPNotificationDefinitionId = new long[1] ;
         BC00097_A1WWPUserExtendedId = new string[] {""} ;
         BC00097_n1WWPUserExtendedId = new bool[] {false} ;
         BC00094_A29WWPEntityId = new long[1] ;
         BC00094_A38WWPNotificationDefinitionDescr = new string[] {""} ;
         BC00096_A30WWPEntityName = new string[] {""} ;
         BC00095_A2WWPUserExtendedFullName = new string[] {""} ;
         BC00098_A34WWPSubscriptionId = new long[1] ;
         BC00093_A34WWPSubscriptionId = new long[1] ;
         BC00093_A35WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC00093_A37WWPSubscriptionEntityRecordDes = new string[] {""} ;
         BC00093_A28WWPSubscriptionRoleId = new string[] {""} ;
         BC00093_n28WWPSubscriptionRoleId = new bool[] {false} ;
         BC00093_A36WWPSubscriptionSubscribed = new bool[] {false} ;
         BC00093_A32WWPNotificationDefinitionId = new long[1] ;
         BC00093_A1WWPUserExtendedId = new string[] {""} ;
         BC00093_n1WWPUserExtendedId = new bool[] {false} ;
         sMode10 = "";
         BC00092_A34WWPSubscriptionId = new long[1] ;
         BC00092_A35WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC00092_A37WWPSubscriptionEntityRecordDes = new string[] {""} ;
         BC00092_A28WWPSubscriptionRoleId = new string[] {""} ;
         BC00092_n28WWPSubscriptionRoleId = new bool[] {false} ;
         BC00092_A36WWPSubscriptionSubscribed = new bool[] {false} ;
         BC00092_A32WWPNotificationDefinitionId = new long[1] ;
         BC00092_A1WWPUserExtendedId = new string[] {""} ;
         BC00092_n1WWPUserExtendedId = new bool[] {false} ;
         BC00099_A34WWPSubscriptionId = new long[1] ;
         BC000912_A29WWPEntityId = new long[1] ;
         BC000912_A38WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000913_A30WWPEntityName = new string[] {""} ;
         BC000914_A2WWPUserExtendedFullName = new string[] {""} ;
         BC000915_A29WWPEntityId = new long[1] ;
         BC000915_A34WWPSubscriptionId = new long[1] ;
         BC000915_A38WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000915_A30WWPEntityName = new string[] {""} ;
         BC000915_A2WWPUserExtendedFullName = new string[] {""} ;
         BC000915_A35WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC000915_A37WWPSubscriptionEntityRecordDes = new string[] {""} ;
         BC000915_A28WWPSubscriptionRoleId = new string[] {""} ;
         BC000915_n28WWPSubscriptionRoleId = new bool[] {false} ;
         BC000915_A36WWPSubscriptionSubscribed = new bool[] {false} ;
         BC000915_A32WWPNotificationDefinitionId = new long[1] ;
         BC000915_A1WWPUserExtendedId = new string[] {""} ;
         BC000915_n1WWPUserExtendedId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription_bc__default(),
            new Object[][] {
                new Object[] {
               BC00092_A34WWPSubscriptionId, BC00092_A35WWPSubscriptionEntityRecordId, BC00092_A37WWPSubscriptionEntityRecordDes, BC00092_A28WWPSubscriptionRoleId, BC00092_n28WWPSubscriptionRoleId, BC00092_A36WWPSubscriptionSubscribed, BC00092_A32WWPNotificationDefinitionId, BC00092_A1WWPUserExtendedId, BC00092_n1WWPUserExtendedId
               }
               , new Object[] {
               BC00093_A34WWPSubscriptionId, BC00093_A35WWPSubscriptionEntityRecordId, BC00093_A37WWPSubscriptionEntityRecordDes, BC00093_A28WWPSubscriptionRoleId, BC00093_n28WWPSubscriptionRoleId, BC00093_A36WWPSubscriptionSubscribed, BC00093_A32WWPNotificationDefinitionId, BC00093_A1WWPUserExtendedId, BC00093_n1WWPUserExtendedId
               }
               , new Object[] {
               BC00094_A29WWPEntityId, BC00094_A38WWPNotificationDefinitionDescr
               }
               , new Object[] {
               BC00095_A2WWPUserExtendedFullName
               }
               , new Object[] {
               BC00096_A30WWPEntityName
               }
               , new Object[] {
               BC00097_A29WWPEntityId, BC00097_A34WWPSubscriptionId, BC00097_A38WWPNotificationDefinitionDescr, BC00097_A30WWPEntityName, BC00097_A2WWPUserExtendedFullName, BC00097_A35WWPSubscriptionEntityRecordId, BC00097_A37WWPSubscriptionEntityRecordDes, BC00097_A28WWPSubscriptionRoleId, BC00097_n28WWPSubscriptionRoleId, BC00097_A36WWPSubscriptionSubscribed,
               BC00097_A32WWPNotificationDefinitionId, BC00097_A1WWPUserExtendedId, BC00097_n1WWPUserExtendedId
               }
               , new Object[] {
               BC00098_A34WWPSubscriptionId
               }
               , new Object[] {
               BC00099_A34WWPSubscriptionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000912_A29WWPEntityId, BC000912_A38WWPNotificationDefinitionDescr
               }
               , new Object[] {
               BC000913_A30WWPEntityName
               }
               , new Object[] {
               BC000914_A2WWPUserExtendedFullName
               }
               , new Object[] {
               BC000915_A29WWPEntityId, BC000915_A34WWPSubscriptionId, BC000915_A38WWPNotificationDefinitionDescr, BC000915_A30WWPEntityName, BC000915_A2WWPUserExtendedFullName, BC000915_A35WWPSubscriptionEntityRecordId, BC000915_A37WWPSubscriptionEntityRecordDes, BC000915_A28WWPSubscriptionRoleId, BC000915_n28WWPSubscriptionRoleId, BC000915_A36WWPSubscriptionSubscribed,
               BC000915_A32WWPNotificationDefinitionId, BC000915_A1WWPUserExtendedId, BC000915_n1WWPUserExtendedId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound10 ;
      private int trnEnded ;
      private long Z34WWPSubscriptionId ;
      private long A34WWPSubscriptionId ;
      private long Z32WWPNotificationDefinitionId ;
      private long A32WWPNotificationDefinitionId ;
      private long Z29WWPEntityId ;
      private long A29WWPEntityId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z28WWPSubscriptionRoleId ;
      private string A28WWPSubscriptionRoleId ;
      private string Z1WWPUserExtendedId ;
      private string A1WWPUserExtendedId ;
      private string sMode10 ;
      private bool Z36WWPSubscriptionSubscribed ;
      private bool A36WWPSubscriptionSubscribed ;
      private bool n28WWPSubscriptionRoleId ;
      private bool n1WWPUserExtendedId ;
      private bool Gx_longc ;
      private string Z35WWPSubscriptionEntityRecordId ;
      private string A35WWPSubscriptionEntityRecordId ;
      private string Z37WWPSubscriptionEntityRecordDes ;
      private string A37WWPSubscriptionEntityRecordDes ;
      private string Z38WWPNotificationDefinitionDescr ;
      private string A38WWPNotificationDefinitionDescr ;
      private string Z2WWPUserExtendedFullName ;
      private string A2WWPUserExtendedFullName ;
      private string Z30WWPEntityName ;
      private string A30WWPEntityName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00097_A29WWPEntityId ;
      private long[] BC00097_A34WWPSubscriptionId ;
      private string[] BC00097_A38WWPNotificationDefinitionDescr ;
      private string[] BC00097_A30WWPEntityName ;
      private string[] BC00097_A2WWPUserExtendedFullName ;
      private string[] BC00097_A35WWPSubscriptionEntityRecordId ;
      private string[] BC00097_A37WWPSubscriptionEntityRecordDes ;
      private string[] BC00097_A28WWPSubscriptionRoleId ;
      private bool[] BC00097_n28WWPSubscriptionRoleId ;
      private bool[] BC00097_A36WWPSubscriptionSubscribed ;
      private long[] BC00097_A32WWPNotificationDefinitionId ;
      private string[] BC00097_A1WWPUserExtendedId ;
      private bool[] BC00097_n1WWPUserExtendedId ;
      private long[] BC00094_A29WWPEntityId ;
      private string[] BC00094_A38WWPNotificationDefinitionDescr ;
      private string[] BC00096_A30WWPEntityName ;
      private string[] BC00095_A2WWPUserExtendedFullName ;
      private long[] BC00098_A34WWPSubscriptionId ;
      private long[] BC00093_A34WWPSubscriptionId ;
      private string[] BC00093_A35WWPSubscriptionEntityRecordId ;
      private string[] BC00093_A37WWPSubscriptionEntityRecordDes ;
      private string[] BC00093_A28WWPSubscriptionRoleId ;
      private bool[] BC00093_n28WWPSubscriptionRoleId ;
      private bool[] BC00093_A36WWPSubscriptionSubscribed ;
      private long[] BC00093_A32WWPNotificationDefinitionId ;
      private string[] BC00093_A1WWPUserExtendedId ;
      private bool[] BC00093_n1WWPUserExtendedId ;
      private long[] BC00092_A34WWPSubscriptionId ;
      private string[] BC00092_A35WWPSubscriptionEntityRecordId ;
      private string[] BC00092_A37WWPSubscriptionEntityRecordDes ;
      private string[] BC00092_A28WWPSubscriptionRoleId ;
      private bool[] BC00092_n28WWPSubscriptionRoleId ;
      private bool[] BC00092_A36WWPSubscriptionSubscribed ;
      private long[] BC00092_A32WWPNotificationDefinitionId ;
      private string[] BC00092_A1WWPUserExtendedId ;
      private bool[] BC00092_n1WWPUserExtendedId ;
      private long[] BC00099_A34WWPSubscriptionId ;
      private long[] BC000912_A29WWPEntityId ;
      private string[] BC000912_A38WWPNotificationDefinitionDescr ;
      private string[] BC000913_A30WWPEntityName ;
      private string[] BC000914_A2WWPUserExtendedFullName ;
      private long[] BC000915_A29WWPEntityId ;
      private long[] BC000915_A34WWPSubscriptionId ;
      private string[] BC000915_A38WWPNotificationDefinitionDescr ;
      private string[] BC000915_A30WWPEntityName ;
      private string[] BC000915_A2WWPUserExtendedFullName ;
      private string[] BC000915_A35WWPSubscriptionEntityRecordId ;
      private string[] BC000915_A37WWPSubscriptionEntityRecordDes ;
      private string[] BC000915_A28WWPSubscriptionRoleId ;
      private bool[] BC000915_n28WWPSubscriptionRoleId ;
      private bool[] BC000915_A36WWPSubscriptionSubscribed ;
      private long[] BC000915_A32WWPNotificationDefinitionId ;
      private string[] BC000915_A1WWPUserExtendedId ;
      private bool[] BC000915_n1WWPUserExtendedId ;
      private GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription bcwwpbaseobjects_subscriptions_WWP_Subscription ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_subscription_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_subscription_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00092;
        prmBC00092 = new Object[] {
        new ParDef("@WWPSubscriptionId",GXType.Decimal,10,0)
        };
        Object[] prmBC00093;
        prmBC00093 = new Object[] {
        new ParDef("@WWPSubscriptionId",GXType.Decimal,10,0)
        };
        Object[] prmBC00094;
        prmBC00094 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmBC00095;
        prmBC00095 = new Object[] {
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
        };
        Object[] prmBC00096;
        prmBC00096 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmBC00097;
        prmBC00097 = new Object[] {
        new ParDef("@WWPSubscriptionId",GXType.Decimal,10,0)
        };
        Object[] prmBC00098;
        prmBC00098 = new Object[] {
        new ParDef("@WWPSubscriptionId",GXType.Decimal,10,0)
        };
        Object[] prmBC00099;
        prmBC00099 = new Object[] {
        new ParDef("@WWPSubscriptionEntityRecordId",GXType.NVarChar,2000,0) ,
        new ParDef("@WWPSubscriptionEntityRecordDes",GXType.NVarChar,200,0) ,
        new ParDef("@WWPSubscriptionRoleId",GXType.NChar,40,0){Nullable=true} ,
        new ParDef("@WWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0) ,
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
        };
        Object[] prmBC000910;
        prmBC000910 = new Object[] {
        new ParDef("@WWPSubscriptionEntityRecordId",GXType.NVarChar,2000,0) ,
        new ParDef("@WWPSubscriptionEntityRecordDes",GXType.NVarChar,200,0) ,
        new ParDef("@WWPSubscriptionRoleId",GXType.NChar,40,0){Nullable=true} ,
        new ParDef("@WWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0) ,
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true} ,
        new ParDef("@WWPSubscriptionId",GXType.Decimal,10,0)
        };
        Object[] prmBC000911;
        prmBC000911 = new Object[] {
        new ParDef("@WWPSubscriptionId",GXType.Decimal,10,0)
        };
        Object[] prmBC000912;
        prmBC000912 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmBC000913;
        prmBC000913 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmBC000914;
        prmBC000914 = new Object[] {
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
        };
        Object[] prmBC000915;
        prmBC000915 = new Object[] {
        new ParDef("@WWPSubscriptionId",GXType.Decimal,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00092", "SELECT [WWPSubscriptionId], [WWPSubscriptionEntityRecordId], [WWPSubscriptionEntityRecordDes], [WWPSubscriptionRoleId], [WWPSubscriptionSubscribed], [WWPNotificationDefinitionId], [WWPUserExtendedId] FROM [WWP_Subscription] WITH (UPDLOCK) WHERE [WWPSubscriptionId] = @WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00092,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00093", "SELECT [WWPSubscriptionId], [WWPSubscriptionEntityRecordId], [WWPSubscriptionEntityRecordDes], [WWPSubscriptionRoleId], [WWPSubscriptionSubscribed], [WWPNotificationDefinitionId], [WWPUserExtendedId] FROM [WWP_Subscription] WHERE [WWPSubscriptionId] = @WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00093,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00094", "SELECT [WWPEntityId], [WWPNotificationDefinitionDescr] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00094,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00095", "SELECT [WWPUserExtendedFullName] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00095,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00096", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00096,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00097", "SELECT T2.[WWPEntityId], TM1.[WWPSubscriptionId], T2.[WWPNotificationDefinitionDescr], T3.[WWPEntityName], T4.[WWPUserExtendedFullName], TM1.[WWPSubscriptionEntityRecordId], TM1.[WWPSubscriptionEntityRecordDes], TM1.[WWPSubscriptionRoleId], TM1.[WWPSubscriptionSubscribed], TM1.[WWPNotificationDefinitionId], TM1.[WWPUserExtendedId] FROM ((([WWP_Subscription] TM1 INNER JOIN [WWP_NotificationDefinition] T2 ON T2.[WWPNotificationDefinitionId] = TM1.[WWPNotificationDefinitionId]) INNER JOIN [WWP_Entity] T3 ON T3.[WWPEntityId] = T2.[WWPEntityId]) LEFT JOIN [WWP_UserExtended] T4 ON T4.[WWPUserExtendedId] = TM1.[WWPUserExtendedId]) WHERE TM1.[WWPSubscriptionId] = @WWPSubscriptionId ORDER BY TM1.[WWPSubscriptionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00097,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00098", "SELECT [WWPSubscriptionId] FROM [WWP_Subscription] WHERE [WWPSubscriptionId] = @WWPSubscriptionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00098,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00099", "INSERT INTO [WWP_Subscription]([WWPSubscriptionEntityRecordId], [WWPSubscriptionEntityRecordDes], [WWPSubscriptionRoleId], [WWPSubscriptionSubscribed], [WWPNotificationDefinitionId], [WWPUserExtendedId]) VALUES(@WWPSubscriptionEntityRecordId, @WWPSubscriptionEntityRecordDes, @WWPSubscriptionRoleId, @WWPSubscriptionSubscribed, @WWPNotificationDefinitionId, @WWPUserExtendedId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00099,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000910", "UPDATE [WWP_Subscription] SET [WWPSubscriptionEntityRecordId]=@WWPSubscriptionEntityRecordId, [WWPSubscriptionEntityRecordDes]=@WWPSubscriptionEntityRecordDes, [WWPSubscriptionRoleId]=@WWPSubscriptionRoleId, [WWPSubscriptionSubscribed]=@WWPSubscriptionSubscribed, [WWPNotificationDefinitionId]=@WWPNotificationDefinitionId, [WWPUserExtendedId]=@WWPUserExtendedId  WHERE [WWPSubscriptionId] = @WWPSubscriptionId", GxErrorMask.GX_NOMASK,prmBC000910)
           ,new CursorDef("BC000911", "DELETE FROM [WWP_Subscription]  WHERE [WWPSubscriptionId] = @WWPSubscriptionId", GxErrorMask.GX_NOMASK,prmBC000911)
           ,new CursorDef("BC000912", "SELECT [WWPEntityId], [WWPNotificationDefinitionDescr] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000912,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000913", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000913,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000914", "SELECT [WWPUserExtendedFullName] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000914,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000915", "SELECT T2.[WWPEntityId], TM1.[WWPSubscriptionId], T2.[WWPNotificationDefinitionDescr], T3.[WWPEntityName], T4.[WWPUserExtendedFullName], TM1.[WWPSubscriptionEntityRecordId], TM1.[WWPSubscriptionEntityRecordDes], TM1.[WWPSubscriptionRoleId], TM1.[WWPSubscriptionSubscribed], TM1.[WWPNotificationDefinitionId], TM1.[WWPUserExtendedId] FROM ((([WWP_Subscription] TM1 INNER JOIN [WWP_NotificationDefinition] T2 ON T2.[WWPNotificationDefinitionId] = TM1.[WWPNotificationDefinitionId]) INNER JOIN [WWP_Entity] T3 ON T3.[WWPEntityId] = T2.[WWPEntityId]) LEFT JOIN [WWP_UserExtended] T4 ON T4.[WWPUserExtendedId] = TM1.[WWPUserExtendedId]) WHERE TM1.[WWPSubscriptionId] = @WWPSubscriptionId ORDER BY TM1.[WWPSubscriptionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000915,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((bool[]) buf[5])[0] = rslt.getBool(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((bool[]) buf[5])[0] = rslt.getBool(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((bool[]) buf[9])[0] = rslt.getBool(9);
              ((long[]) buf[10])[0] = rslt.getLong(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 40);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((bool[]) buf[9])[0] = rslt.getBool(9);
              ((long[]) buf[10])[0] = rslt.getLong(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 40);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              return;
     }
  }

}

}
