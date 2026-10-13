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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_notificationdefinition_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_notificationdefinition_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_notificationdefinition_bc( IGxContext context )
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
         ReadRow0D14( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0D14( ) ;
         standaloneModal( ) ;
         AddRow0D14( ) ;
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
               Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
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

      protected void CONFIRM_0D0( )
      {
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0D14( ) ;
            }
            else
            {
               CheckExtendedTable0D14( ) ;
               if ( AnyError == 0 )
               {
                  ZM0D14( 5) ;
               }
               CloseExtendedTableCursors0D14( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0D14( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z68WWPNotificationDefinitionName = A68WWPNotificationDefinitionName;
            Z39WWPNotificationDefinitionAppli = A39WWPNotificationDefinitionAppli;
            Z40WWPNotificationDefinitionAllow = A40WWPNotificationDefinitionAllow;
            Z38WWPNotificationDefinitionDescr = A38WWPNotificationDefinitionDescr;
            Z71WWPNotificationDefinitionIcon = A71WWPNotificationDefinitionIcon;
            Z72WWPNotificationDefinitionTitle = A72WWPNotificationDefinitionTitle;
            Z73WWPNotificationDefinitionShort = A73WWPNotificationDefinitionShort;
            Z74WWPNotificationDefinitionLongD = A74WWPNotificationDefinitionLongD;
            Z75WWPNotificationDefinitionLink = A75WWPNotificationDefinitionLink;
            Z76WWPNotificationDefinitionSecFu = A76WWPNotificationDefinitionSecFu;
            Z29WWPEntityId = A29WWPEntityId;
            Z77WWPNotificationDefinitionIsAut = A77WWPNotificationDefinitionIsAut;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z30WWPEntityName = A30WWPEntityName;
            Z77WWPNotificationDefinitionIsAut = A77WWPNotificationDefinitionIsAut;
         }
         if ( GX_JID == -4 )
         {
            Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
            Z68WWPNotificationDefinitionName = A68WWPNotificationDefinitionName;
            Z39WWPNotificationDefinitionAppli = A39WWPNotificationDefinitionAppli;
            Z40WWPNotificationDefinitionAllow = A40WWPNotificationDefinitionAllow;
            Z38WWPNotificationDefinitionDescr = A38WWPNotificationDefinitionDescr;
            Z71WWPNotificationDefinitionIcon = A71WWPNotificationDefinitionIcon;
            Z72WWPNotificationDefinitionTitle = A72WWPNotificationDefinitionTitle;
            Z73WWPNotificationDefinitionShort = A73WWPNotificationDefinitionShort;
            Z74WWPNotificationDefinitionLongD = A74WWPNotificationDefinitionLongD;
            Z75WWPNotificationDefinitionLink = A75WWPNotificationDefinitionLink;
            Z76WWPNotificationDefinitionSecFu = A76WWPNotificationDefinitionSecFu;
            Z29WWPEntityId = A29WWPEntityId;
            Z30WWPEntityName = A30WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0D14( )
      {
         /* Using cursor BC000D5 */
         pr_default.execute(3, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound14 = 1;
            A68WWPNotificationDefinitionName = BC000D5_A68WWPNotificationDefinitionName[0];
            A39WWPNotificationDefinitionAppli = BC000D5_A39WWPNotificationDefinitionAppli[0];
            A40WWPNotificationDefinitionAllow = BC000D5_A40WWPNotificationDefinitionAllow[0];
            A38WWPNotificationDefinitionDescr = BC000D5_A38WWPNotificationDefinitionDescr[0];
            A71WWPNotificationDefinitionIcon = BC000D5_A71WWPNotificationDefinitionIcon[0];
            A72WWPNotificationDefinitionTitle = BC000D5_A72WWPNotificationDefinitionTitle[0];
            A73WWPNotificationDefinitionShort = BC000D5_A73WWPNotificationDefinitionShort[0];
            A74WWPNotificationDefinitionLongD = BC000D5_A74WWPNotificationDefinitionLongD[0];
            A75WWPNotificationDefinitionLink = BC000D5_A75WWPNotificationDefinitionLink[0];
            A30WWPEntityName = BC000D5_A30WWPEntityName[0];
            A76WWPNotificationDefinitionSecFu = BC000D5_A76WWPNotificationDefinitionSecFu[0];
            A29WWPEntityId = BC000D5_A29WWPEntityId[0];
            ZM0D14( -4) ;
         }
         pr_default.close(3);
         OnLoadActions0D14( ) ;
      }

      protected void OnLoadActions0D14( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A76WWPNotificationDefinitionSecFu)) )
         {
            A77WWPNotificationDefinitionIsAut = true;
         }
         else
         {
            GXt_boolean1 = A77WWPNotificationDefinitionIsAut;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  A76WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A77WWPNotificationDefinitionIsAut = GXt_boolean1;
         }
      }

      protected void CheckExtendedTable0D14( )
      {
         standaloneModal( ) ;
         if ( ! ( ( A39WWPNotificationDefinitionAppli == 1 ) || ( A39WWPNotificationDefinitionAppli == 2 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Notification Definition Applies To", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A75WWPNotificationDefinitionLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Notification Definition Default Link", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000D4 */
         pr_default.execute(2, new Object[] {A29WWPEntityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A30WWPEntityName = BC000D4_A30WWPEntityName[0];
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A76WWPNotificationDefinitionSecFu)) )
         {
            A77WWPNotificationDefinitionIsAut = true;
         }
         else
         {
            GXt_boolean1 = A77WWPNotificationDefinitionIsAut;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  A76WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A77WWPNotificationDefinitionIsAut = GXt_boolean1;
         }
      }

      protected void CloseExtendedTableCursors0D14( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0D14( )
      {
         /* Using cursor BC000D6 */
         pr_default.execute(4, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000D3 */
         pr_default.execute(1, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D14( 4) ;
            RcdFound14 = 1;
            A32WWPNotificationDefinitionId = BC000D3_A32WWPNotificationDefinitionId[0];
            A68WWPNotificationDefinitionName = BC000D3_A68WWPNotificationDefinitionName[0];
            A39WWPNotificationDefinitionAppli = BC000D3_A39WWPNotificationDefinitionAppli[0];
            A40WWPNotificationDefinitionAllow = BC000D3_A40WWPNotificationDefinitionAllow[0];
            A38WWPNotificationDefinitionDescr = BC000D3_A38WWPNotificationDefinitionDescr[0];
            A71WWPNotificationDefinitionIcon = BC000D3_A71WWPNotificationDefinitionIcon[0];
            A72WWPNotificationDefinitionTitle = BC000D3_A72WWPNotificationDefinitionTitle[0];
            A73WWPNotificationDefinitionShort = BC000D3_A73WWPNotificationDefinitionShort[0];
            A74WWPNotificationDefinitionLongD = BC000D3_A74WWPNotificationDefinitionLongD[0];
            A75WWPNotificationDefinitionLink = BC000D3_A75WWPNotificationDefinitionLink[0];
            A76WWPNotificationDefinitionSecFu = BC000D3_A76WWPNotificationDefinitionSecFu[0];
            A29WWPEntityId = BC000D3_A29WWPEntityId[0];
            Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0D14( ) ;
            if ( AnyError == 1 )
            {
               RcdFound14 = 0;
               InitializeNonKey0D14( ) ;
            }
            Gx_mode = sMode14;
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0D14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode14;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D14( ) ;
         if ( RcdFound14 == 0 )
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
         CONFIRM_0D0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0D14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000D2 */
            pr_default.execute(0, new Object[] {A32WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z68WWPNotificationDefinitionName, BC000D2_A68WWPNotificationDefinitionName[0]) != 0 ) || ( Z39WWPNotificationDefinitionAppli != BC000D2_A39WWPNotificationDefinitionAppli[0] ) || ( Z40WWPNotificationDefinitionAllow != BC000D2_A40WWPNotificationDefinitionAllow[0] ) || ( StringUtil.StrCmp(Z38WWPNotificationDefinitionDescr, BC000D2_A38WWPNotificationDefinitionDescr[0]) != 0 ) || ( StringUtil.StrCmp(Z71WWPNotificationDefinitionIcon, BC000D2_A71WWPNotificationDefinitionIcon[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z72WWPNotificationDefinitionTitle, BC000D2_A72WWPNotificationDefinitionTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z73WWPNotificationDefinitionShort, BC000D2_A73WWPNotificationDefinitionShort[0]) != 0 ) || ( StringUtil.StrCmp(Z74WWPNotificationDefinitionLongD, BC000D2_A74WWPNotificationDefinitionLongD[0]) != 0 ) || ( StringUtil.StrCmp(Z75WWPNotificationDefinitionLink, BC000D2_A75WWPNotificationDefinitionLink[0]) != 0 ) || ( StringUtil.StrCmp(Z76WWPNotificationDefinitionSecFu, BC000D2_A76WWPNotificationDefinitionSecFu[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z29WWPEntityId != BC000D2_A29WWPEntityId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_NotificationDefinition"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D14( )
      {
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D14( 0) ;
            CheckOptimisticConcurrency0D14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D7 */
                     pr_default.execute(5, new Object[] {A68WWPNotificationDefinitionName, A39WWPNotificationDefinitionAppli, A40WWPNotificationDefinitionAllow, A38WWPNotificationDefinitionDescr, A71WWPNotificationDefinitionIcon, A72WWPNotificationDefinitionTitle, A73WWPNotificationDefinitionShort, A74WWPNotificationDefinitionLongD, A75WWPNotificationDefinitionLink, A76WWPNotificationDefinitionSecFu, A29WWPEntityId});
                     A32WWPNotificationDefinitionId = BC000D7_A32WWPNotificationDefinitionId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
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
               Load0D14( ) ;
            }
            EndLevel0D14( ) ;
         }
         CloseExtendedTableCursors0D14( ) ;
      }

      protected void Update0D14( )
      {
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D8 */
                     pr_default.execute(6, new Object[] {A68WWPNotificationDefinitionName, A39WWPNotificationDefinitionAppli, A40WWPNotificationDefinitionAllow, A38WWPNotificationDefinitionDescr, A71WWPNotificationDefinitionIcon, A72WWPNotificationDefinitionTitle, A73WWPNotificationDefinitionShort, A74WWPNotificationDefinitionLongD, A75WWPNotificationDefinitionLink, A76WWPNotificationDefinitionSecFu, A29WWPEntityId, A32WWPNotificationDefinitionId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D14( ) ;
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
            EndLevel0D14( ) ;
         }
         CloseExtendedTableCursors0D14( ) ;
      }

      protected void DeferredUpdate0D14( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D14( ) ;
            AfterConfirm0D14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000D9 */
                  pr_default.execute(7, new Object[] {A32WWPNotificationDefinitionId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
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
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0D14( ) ;
         Gx_mode = sMode14;
      }

      protected void OnDeleteControls0D14( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000D10 */
            pr_default.execute(8, new Object[] {A29WWPEntityId});
            A30WWPEntityName = BC000D10_A30WWPEntityName[0];
            pr_default.close(8);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A76WWPNotificationDefinitionSecFu)) )
            {
               A77WWPNotificationDefinitionIsAut = true;
            }
            else
            {
               GXt_boolean1 = A77WWPNotificationDefinitionIsAut;
               new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  A76WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
               A77WWPNotificationDefinitionIsAut = GXt_boolean1;
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000D11 */
            pr_default.execute(9, new Object[] {A32WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_Notification", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000D12 */
            pr_default.execute(10, new Object[] {A32WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_Subscription", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel0D14( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D14( ) ;
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

      public void ScanKeyStart0D14( )
      {
         /* Using cursor BC000D13 */
         pr_default.execute(11, new Object[] {A32WWPNotificationDefinitionId});
         RcdFound14 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound14 = 1;
            A32WWPNotificationDefinitionId = BC000D13_A32WWPNotificationDefinitionId[0];
            A68WWPNotificationDefinitionName = BC000D13_A68WWPNotificationDefinitionName[0];
            A39WWPNotificationDefinitionAppli = BC000D13_A39WWPNotificationDefinitionAppli[0];
            A40WWPNotificationDefinitionAllow = BC000D13_A40WWPNotificationDefinitionAllow[0];
            A38WWPNotificationDefinitionDescr = BC000D13_A38WWPNotificationDefinitionDescr[0];
            A71WWPNotificationDefinitionIcon = BC000D13_A71WWPNotificationDefinitionIcon[0];
            A72WWPNotificationDefinitionTitle = BC000D13_A72WWPNotificationDefinitionTitle[0];
            A73WWPNotificationDefinitionShort = BC000D13_A73WWPNotificationDefinitionShort[0];
            A74WWPNotificationDefinitionLongD = BC000D13_A74WWPNotificationDefinitionLongD[0];
            A75WWPNotificationDefinitionLink = BC000D13_A75WWPNotificationDefinitionLink[0];
            A30WWPEntityName = BC000D13_A30WWPEntityName[0];
            A76WWPNotificationDefinitionSecFu = BC000D13_A76WWPNotificationDefinitionSecFu[0];
            A29WWPEntityId = BC000D13_A29WWPEntityId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0D14( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound14 = 0;
         ScanKeyLoad0D14( ) ;
      }

      protected void ScanKeyLoad0D14( )
      {
         sMode14 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound14 = 1;
            A32WWPNotificationDefinitionId = BC000D13_A32WWPNotificationDefinitionId[0];
            A68WWPNotificationDefinitionName = BC000D13_A68WWPNotificationDefinitionName[0];
            A39WWPNotificationDefinitionAppli = BC000D13_A39WWPNotificationDefinitionAppli[0];
            A40WWPNotificationDefinitionAllow = BC000D13_A40WWPNotificationDefinitionAllow[0];
            A38WWPNotificationDefinitionDescr = BC000D13_A38WWPNotificationDefinitionDescr[0];
            A71WWPNotificationDefinitionIcon = BC000D13_A71WWPNotificationDefinitionIcon[0];
            A72WWPNotificationDefinitionTitle = BC000D13_A72WWPNotificationDefinitionTitle[0];
            A73WWPNotificationDefinitionShort = BC000D13_A73WWPNotificationDefinitionShort[0];
            A74WWPNotificationDefinitionLongD = BC000D13_A74WWPNotificationDefinitionLongD[0];
            A75WWPNotificationDefinitionLink = BC000D13_A75WWPNotificationDefinitionLink[0];
            A30WWPEntityName = BC000D13_A30WWPEntityName[0];
            A76WWPNotificationDefinitionSecFu = BC000D13_A76WWPNotificationDefinitionSecFu[0];
            A29WWPEntityId = BC000D13_A29WWPEntityId[0];
         }
         Gx_mode = sMode14;
      }

      protected void ScanKeyEnd0D14( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0D14( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D14( )
      {
      }

      protected void send_integrity_lvl_hashes0D14( )
      {
      }

      protected void AddRow0D14( )
      {
         VarsToRow14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
      }

      protected void ReadRow0D14( )
      {
         RowToVars14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
      }

      protected void InitializeNonKey0D14( )
      {
         A77WWPNotificationDefinitionIsAut = false;
         A68WWPNotificationDefinitionName = "";
         A39WWPNotificationDefinitionAppli = 0;
         A40WWPNotificationDefinitionAllow = false;
         A38WWPNotificationDefinitionDescr = "";
         A71WWPNotificationDefinitionIcon = "";
         A72WWPNotificationDefinitionTitle = "";
         A73WWPNotificationDefinitionShort = "";
         A74WWPNotificationDefinitionLongD = "";
         A75WWPNotificationDefinitionLink = "";
         A29WWPEntityId = 0;
         A30WWPEntityName = "";
         A76WWPNotificationDefinitionSecFu = "";
         Z68WWPNotificationDefinitionName = "";
         Z39WWPNotificationDefinitionAppli = 0;
         Z40WWPNotificationDefinitionAllow = false;
         Z38WWPNotificationDefinitionDescr = "";
         Z71WWPNotificationDefinitionIcon = "";
         Z72WWPNotificationDefinitionTitle = "";
         Z73WWPNotificationDefinitionShort = "";
         Z74WWPNotificationDefinitionLongD = "";
         Z75WWPNotificationDefinitionLink = "";
         Z76WWPNotificationDefinitionSecFu = "";
         Z29WWPEntityId = 0;
      }

      protected void InitAll0D14( )
      {
         A32WWPNotificationDefinitionId = 0;
         InitializeNonKey0D14( ) ;
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

      public void VarsToRow14( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition obj14 )
      {
         obj14.gxTpr_Mode = Gx_mode;
         obj14.gxTpr_Wwpnotificationdefinitionisauthorized = A77WWPNotificationDefinitionIsAut;
         obj14.gxTpr_Wwpnotificationdefinitionname = A68WWPNotificationDefinitionName;
         obj14.gxTpr_Wwpnotificationdefinitionappliesto = A39WWPNotificationDefinitionAppli;
         obj14.gxTpr_Wwpnotificationdefinitionallowusersubscription = A40WWPNotificationDefinitionAllow;
         obj14.gxTpr_Wwpnotificationdefinitiondescription = A38WWPNotificationDefinitionDescr;
         obj14.gxTpr_Wwpnotificationdefinitionicon = A71WWPNotificationDefinitionIcon;
         obj14.gxTpr_Wwpnotificationdefinitiontitle = A72WWPNotificationDefinitionTitle;
         obj14.gxTpr_Wwpnotificationdefinitionshortdescription = A73WWPNotificationDefinitionShort;
         obj14.gxTpr_Wwpnotificationdefinitionlongdescription = A74WWPNotificationDefinitionLongD;
         obj14.gxTpr_Wwpnotificationdefinitionlink = A75WWPNotificationDefinitionLink;
         obj14.gxTpr_Wwpentityid = A29WWPEntityId;
         obj14.gxTpr_Wwpentityname = A30WWPEntityName;
         obj14.gxTpr_Wwpnotificationdefinitionsecfuncionality = A76WWPNotificationDefinitionSecFu;
         obj14.gxTpr_Wwpnotificationdefinitionid = A32WWPNotificationDefinitionId;
         obj14.gxTpr_Wwpnotificationdefinitionid_Z = Z32WWPNotificationDefinitionId;
         obj14.gxTpr_Wwpnotificationdefinitionname_Z = Z68WWPNotificationDefinitionName;
         obj14.gxTpr_Wwpnotificationdefinitionappliesto_Z = Z39WWPNotificationDefinitionAppli;
         obj14.gxTpr_Wwpnotificationdefinitionallowusersubscription_Z = Z40WWPNotificationDefinitionAllow;
         obj14.gxTpr_Wwpnotificationdefinitiondescription_Z = Z38WWPNotificationDefinitionDescr;
         obj14.gxTpr_Wwpnotificationdefinitionicon_Z = Z71WWPNotificationDefinitionIcon;
         obj14.gxTpr_Wwpnotificationdefinitiontitle_Z = Z72WWPNotificationDefinitionTitle;
         obj14.gxTpr_Wwpnotificationdefinitionshortdescription_Z = Z73WWPNotificationDefinitionShort;
         obj14.gxTpr_Wwpnotificationdefinitionlongdescription_Z = Z74WWPNotificationDefinitionLongD;
         obj14.gxTpr_Wwpnotificationdefinitionlink_Z = Z75WWPNotificationDefinitionLink;
         obj14.gxTpr_Wwpentityid_Z = Z29WWPEntityId;
         obj14.gxTpr_Wwpentityname_Z = Z30WWPEntityName;
         obj14.gxTpr_Wwpnotificationdefinitionsecfuncionality_Z = Z76WWPNotificationDefinitionSecFu;
         obj14.gxTpr_Wwpnotificationdefinitionisauthorized_Z = Z77WWPNotificationDefinitionIsAut;
         obj14.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow14( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition obj14 )
      {
         obj14.gxTpr_Wwpnotificationdefinitionid = A32WWPNotificationDefinitionId;
         return  ;
      }

      public void RowToVars14( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition obj14 ,
                               int forceLoad )
      {
         Gx_mode = obj14.gxTpr_Mode;
         A77WWPNotificationDefinitionIsAut = obj14.gxTpr_Wwpnotificationdefinitionisauthorized;
         A68WWPNotificationDefinitionName = obj14.gxTpr_Wwpnotificationdefinitionname;
         A39WWPNotificationDefinitionAppli = obj14.gxTpr_Wwpnotificationdefinitionappliesto;
         A40WWPNotificationDefinitionAllow = obj14.gxTpr_Wwpnotificationdefinitionallowusersubscription;
         A38WWPNotificationDefinitionDescr = obj14.gxTpr_Wwpnotificationdefinitiondescription;
         A71WWPNotificationDefinitionIcon = obj14.gxTpr_Wwpnotificationdefinitionicon;
         A72WWPNotificationDefinitionTitle = obj14.gxTpr_Wwpnotificationdefinitiontitle;
         A73WWPNotificationDefinitionShort = obj14.gxTpr_Wwpnotificationdefinitionshortdescription;
         A74WWPNotificationDefinitionLongD = obj14.gxTpr_Wwpnotificationdefinitionlongdescription;
         A75WWPNotificationDefinitionLink = obj14.gxTpr_Wwpnotificationdefinitionlink;
         A29WWPEntityId = obj14.gxTpr_Wwpentityid;
         A30WWPEntityName = obj14.gxTpr_Wwpentityname;
         A76WWPNotificationDefinitionSecFu = obj14.gxTpr_Wwpnotificationdefinitionsecfuncionality;
         A32WWPNotificationDefinitionId = obj14.gxTpr_Wwpnotificationdefinitionid;
         Z32WWPNotificationDefinitionId = obj14.gxTpr_Wwpnotificationdefinitionid_Z;
         Z68WWPNotificationDefinitionName = obj14.gxTpr_Wwpnotificationdefinitionname_Z;
         Z39WWPNotificationDefinitionAppli = obj14.gxTpr_Wwpnotificationdefinitionappliesto_Z;
         Z40WWPNotificationDefinitionAllow = obj14.gxTpr_Wwpnotificationdefinitionallowusersubscription_Z;
         Z38WWPNotificationDefinitionDescr = obj14.gxTpr_Wwpnotificationdefinitiondescription_Z;
         Z71WWPNotificationDefinitionIcon = obj14.gxTpr_Wwpnotificationdefinitionicon_Z;
         Z72WWPNotificationDefinitionTitle = obj14.gxTpr_Wwpnotificationdefinitiontitle_Z;
         Z73WWPNotificationDefinitionShort = obj14.gxTpr_Wwpnotificationdefinitionshortdescription_Z;
         Z74WWPNotificationDefinitionLongD = obj14.gxTpr_Wwpnotificationdefinitionlongdescription_Z;
         Z75WWPNotificationDefinitionLink = obj14.gxTpr_Wwpnotificationdefinitionlink_Z;
         Z29WWPEntityId = obj14.gxTpr_Wwpentityid_Z;
         Z30WWPEntityName = obj14.gxTpr_Wwpentityname_Z;
         Z76WWPNotificationDefinitionSecFu = obj14.gxTpr_Wwpnotificationdefinitionsecfuncionality_Z;
         Z77WWPNotificationDefinitionIsAut = obj14.gxTpr_Wwpnotificationdefinitionisauthorized_Z;
         Gx_mode = obj14.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A32WWPNotificationDefinitionId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0D14( ) ;
         ScanKeyStart0D14( ) ;
         if ( RcdFound14 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
         }
         ZM0D14( -4) ;
         OnLoadActions0D14( ) ;
         AddRow0D14( ) ;
         ScanKeyEnd0D14( ) ;
         if ( RcdFound14 == 0 )
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
         RowToVars14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 0) ;
         ScanKeyStart0D14( ) ;
         if ( RcdFound14 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
         }
         ZM0D14( -4) ;
         OnLoadActions0D14( ) ;
         AddRow0D14( ) ;
         ScanKeyEnd0D14( ) ;
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0D14( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0D14( ) ;
         }
         else
         {
            if ( RcdFound14 == 1 )
            {
               if ( A32WWPNotificationDefinitionId != Z32WWPNotificationDefinitionId )
               {
                  A32WWPNotificationDefinitionId = Z32WWPNotificationDefinitionId;
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
                  Update0D14( ) ;
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
                  if ( A32WWPNotificationDefinitionId != Z32WWPNotificationDefinitionId )
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
                        Insert0D14( ) ;
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
                        Insert0D14( ) ;
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
         RowToVars14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         SaveImpl( ) ;
         VarsToRow14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D14( ) ;
         AfterTrn( ) ;
         VarsToRow14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A32WWPNotificationDefinitionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition);
               auxBC.Save();
               bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
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
         RowToVars14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D14( ) ;
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
               VarsToRow14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
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
         RowToVars14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 0) ;
         GetKey0D14( ) ;
         if ( RcdFound14 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A32WWPNotificationDefinitionId != Z32WWPNotificationDefinitionId )
            {
               A32WWPNotificationDefinitionId = Z32WWPNotificationDefinitionId;
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
            if ( A32WWPNotificationDefinitionId != Z32WWPNotificationDefinitionId )
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
         pr_default.close(8);
         context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc",pr_default);
         VarsToRow14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition )
         {
            bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition = (GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
            }
            else
            {
               RowToVars14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars14( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_NotificationDefinition WWP_NotificationDefinition_BC
      {
         get {
            return bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition ;
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
         pr_default.close(8);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z68WWPNotificationDefinitionName = "";
         A68WWPNotificationDefinitionName = "";
         Z38WWPNotificationDefinitionDescr = "";
         A38WWPNotificationDefinitionDescr = "";
         Z71WWPNotificationDefinitionIcon = "";
         A71WWPNotificationDefinitionIcon = "";
         Z72WWPNotificationDefinitionTitle = "";
         A72WWPNotificationDefinitionTitle = "";
         Z73WWPNotificationDefinitionShort = "";
         A73WWPNotificationDefinitionShort = "";
         Z74WWPNotificationDefinitionLongD = "";
         A74WWPNotificationDefinitionLongD = "";
         Z75WWPNotificationDefinitionLink = "";
         A75WWPNotificationDefinitionLink = "";
         Z76WWPNotificationDefinitionSecFu = "";
         A76WWPNotificationDefinitionSecFu = "";
         Z30WWPEntityName = "";
         A30WWPEntityName = "";
         BC000D5_A32WWPNotificationDefinitionId = new long[1] ;
         BC000D5_A68WWPNotificationDefinitionName = new string[] {""} ;
         BC000D5_A39WWPNotificationDefinitionAppli = new short[1] ;
         BC000D5_A40WWPNotificationDefinitionAllow = new bool[] {false} ;
         BC000D5_A38WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000D5_A71WWPNotificationDefinitionIcon = new string[] {""} ;
         BC000D5_A72WWPNotificationDefinitionTitle = new string[] {""} ;
         BC000D5_A73WWPNotificationDefinitionShort = new string[] {""} ;
         BC000D5_A74WWPNotificationDefinitionLongD = new string[] {""} ;
         BC000D5_A75WWPNotificationDefinitionLink = new string[] {""} ;
         BC000D5_A30WWPEntityName = new string[] {""} ;
         BC000D5_A76WWPNotificationDefinitionSecFu = new string[] {""} ;
         BC000D5_A29WWPEntityId = new long[1] ;
         BC000D4_A30WWPEntityName = new string[] {""} ;
         BC000D6_A32WWPNotificationDefinitionId = new long[1] ;
         BC000D3_A32WWPNotificationDefinitionId = new long[1] ;
         BC000D3_A68WWPNotificationDefinitionName = new string[] {""} ;
         BC000D3_A39WWPNotificationDefinitionAppli = new short[1] ;
         BC000D3_A40WWPNotificationDefinitionAllow = new bool[] {false} ;
         BC000D3_A38WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000D3_A71WWPNotificationDefinitionIcon = new string[] {""} ;
         BC000D3_A72WWPNotificationDefinitionTitle = new string[] {""} ;
         BC000D3_A73WWPNotificationDefinitionShort = new string[] {""} ;
         BC000D3_A74WWPNotificationDefinitionLongD = new string[] {""} ;
         BC000D3_A75WWPNotificationDefinitionLink = new string[] {""} ;
         BC000D3_A76WWPNotificationDefinitionSecFu = new string[] {""} ;
         BC000D3_A29WWPEntityId = new long[1] ;
         sMode14 = "";
         BC000D2_A32WWPNotificationDefinitionId = new long[1] ;
         BC000D2_A68WWPNotificationDefinitionName = new string[] {""} ;
         BC000D2_A39WWPNotificationDefinitionAppli = new short[1] ;
         BC000D2_A40WWPNotificationDefinitionAllow = new bool[] {false} ;
         BC000D2_A38WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000D2_A71WWPNotificationDefinitionIcon = new string[] {""} ;
         BC000D2_A72WWPNotificationDefinitionTitle = new string[] {""} ;
         BC000D2_A73WWPNotificationDefinitionShort = new string[] {""} ;
         BC000D2_A74WWPNotificationDefinitionLongD = new string[] {""} ;
         BC000D2_A75WWPNotificationDefinitionLink = new string[] {""} ;
         BC000D2_A76WWPNotificationDefinitionSecFu = new string[] {""} ;
         BC000D2_A29WWPEntityId = new long[1] ;
         BC000D7_A32WWPNotificationDefinitionId = new long[1] ;
         BC000D10_A30WWPEntityName = new string[] {""} ;
         BC000D11_A31WWPNotificationId = new long[1] ;
         BC000D12_A34WWPSubscriptionId = new long[1] ;
         BC000D13_A32WWPNotificationDefinitionId = new long[1] ;
         BC000D13_A68WWPNotificationDefinitionName = new string[] {""} ;
         BC000D13_A39WWPNotificationDefinitionAppli = new short[1] ;
         BC000D13_A40WWPNotificationDefinitionAllow = new bool[] {false} ;
         BC000D13_A38WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000D13_A71WWPNotificationDefinitionIcon = new string[] {""} ;
         BC000D13_A72WWPNotificationDefinitionTitle = new string[] {""} ;
         BC000D13_A73WWPNotificationDefinitionShort = new string[] {""} ;
         BC000D13_A74WWPNotificationDefinitionLongD = new string[] {""} ;
         BC000D13_A75WWPNotificationDefinitionLink = new string[] {""} ;
         BC000D13_A30WWPEntityName = new string[] {""} ;
         BC000D13_A76WWPNotificationDefinitionSecFu = new string[] {""} ;
         BC000D13_A29WWPEntityId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc__default(),
            new Object[][] {
                new Object[] {
               BC000D2_A32WWPNotificationDefinitionId, BC000D2_A68WWPNotificationDefinitionName, BC000D2_A39WWPNotificationDefinitionAppli, BC000D2_A40WWPNotificationDefinitionAllow, BC000D2_A38WWPNotificationDefinitionDescr, BC000D2_A71WWPNotificationDefinitionIcon, BC000D2_A72WWPNotificationDefinitionTitle, BC000D2_A73WWPNotificationDefinitionShort, BC000D2_A74WWPNotificationDefinitionLongD, BC000D2_A75WWPNotificationDefinitionLink,
               BC000D2_A76WWPNotificationDefinitionSecFu, BC000D2_A29WWPEntityId
               }
               , new Object[] {
               BC000D3_A32WWPNotificationDefinitionId, BC000D3_A68WWPNotificationDefinitionName, BC000D3_A39WWPNotificationDefinitionAppli, BC000D3_A40WWPNotificationDefinitionAllow, BC000D3_A38WWPNotificationDefinitionDescr, BC000D3_A71WWPNotificationDefinitionIcon, BC000D3_A72WWPNotificationDefinitionTitle, BC000D3_A73WWPNotificationDefinitionShort, BC000D3_A74WWPNotificationDefinitionLongD, BC000D3_A75WWPNotificationDefinitionLink,
               BC000D3_A76WWPNotificationDefinitionSecFu, BC000D3_A29WWPEntityId
               }
               , new Object[] {
               BC000D4_A30WWPEntityName
               }
               , new Object[] {
               BC000D5_A32WWPNotificationDefinitionId, BC000D5_A68WWPNotificationDefinitionName, BC000D5_A39WWPNotificationDefinitionAppli, BC000D5_A40WWPNotificationDefinitionAllow, BC000D5_A38WWPNotificationDefinitionDescr, BC000D5_A71WWPNotificationDefinitionIcon, BC000D5_A72WWPNotificationDefinitionTitle, BC000D5_A73WWPNotificationDefinitionShort, BC000D5_A74WWPNotificationDefinitionLongD, BC000D5_A75WWPNotificationDefinitionLink,
               BC000D5_A30WWPEntityName, BC000D5_A76WWPNotificationDefinitionSecFu, BC000D5_A29WWPEntityId
               }
               , new Object[] {
               BC000D6_A32WWPNotificationDefinitionId
               }
               , new Object[] {
               BC000D7_A32WWPNotificationDefinitionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D10_A30WWPEntityName
               }
               , new Object[] {
               BC000D11_A31WWPNotificationId
               }
               , new Object[] {
               BC000D12_A34WWPSubscriptionId
               }
               , new Object[] {
               BC000D13_A32WWPNotificationDefinitionId, BC000D13_A68WWPNotificationDefinitionName, BC000D13_A39WWPNotificationDefinitionAppli, BC000D13_A40WWPNotificationDefinitionAllow, BC000D13_A38WWPNotificationDefinitionDescr, BC000D13_A71WWPNotificationDefinitionIcon, BC000D13_A72WWPNotificationDefinitionTitle, BC000D13_A73WWPNotificationDefinitionShort, BC000D13_A74WWPNotificationDefinitionLongD, BC000D13_A75WWPNotificationDefinitionLink,
               BC000D13_A30WWPEntityName, BC000D13_A76WWPNotificationDefinitionSecFu, BC000D13_A29WWPEntityId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z39WWPNotificationDefinitionAppli ;
      private short A39WWPNotificationDefinitionAppli ;
      private short RcdFound14 ;
      private int trnEnded ;
      private long Z32WWPNotificationDefinitionId ;
      private long A32WWPNotificationDefinitionId ;
      private long Z29WWPEntityId ;
      private long A29WWPEntityId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode14 ;
      private bool Z40WWPNotificationDefinitionAllow ;
      private bool A40WWPNotificationDefinitionAllow ;
      private bool Z77WWPNotificationDefinitionIsAut ;
      private bool A77WWPNotificationDefinitionIsAut ;
      private bool Gx_longc ;
      private bool GXt_boolean1 ;
      private string Z68WWPNotificationDefinitionName ;
      private string A68WWPNotificationDefinitionName ;
      private string Z38WWPNotificationDefinitionDescr ;
      private string A38WWPNotificationDefinitionDescr ;
      private string Z71WWPNotificationDefinitionIcon ;
      private string A71WWPNotificationDefinitionIcon ;
      private string Z72WWPNotificationDefinitionTitle ;
      private string A72WWPNotificationDefinitionTitle ;
      private string Z73WWPNotificationDefinitionShort ;
      private string A73WWPNotificationDefinitionShort ;
      private string Z74WWPNotificationDefinitionLongD ;
      private string A74WWPNotificationDefinitionLongD ;
      private string Z75WWPNotificationDefinitionLink ;
      private string A75WWPNotificationDefinitionLink ;
      private string Z76WWPNotificationDefinitionSecFu ;
      private string A76WWPNotificationDefinitionSecFu ;
      private string Z30WWPEntityName ;
      private string A30WWPEntityName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000D5_A32WWPNotificationDefinitionId ;
      private string[] BC000D5_A68WWPNotificationDefinitionName ;
      private short[] BC000D5_A39WWPNotificationDefinitionAppli ;
      private bool[] BC000D5_A40WWPNotificationDefinitionAllow ;
      private string[] BC000D5_A38WWPNotificationDefinitionDescr ;
      private string[] BC000D5_A71WWPNotificationDefinitionIcon ;
      private string[] BC000D5_A72WWPNotificationDefinitionTitle ;
      private string[] BC000D5_A73WWPNotificationDefinitionShort ;
      private string[] BC000D5_A74WWPNotificationDefinitionLongD ;
      private string[] BC000D5_A75WWPNotificationDefinitionLink ;
      private string[] BC000D5_A30WWPEntityName ;
      private string[] BC000D5_A76WWPNotificationDefinitionSecFu ;
      private long[] BC000D5_A29WWPEntityId ;
      private string[] BC000D4_A30WWPEntityName ;
      private long[] BC000D6_A32WWPNotificationDefinitionId ;
      private long[] BC000D3_A32WWPNotificationDefinitionId ;
      private string[] BC000D3_A68WWPNotificationDefinitionName ;
      private short[] BC000D3_A39WWPNotificationDefinitionAppli ;
      private bool[] BC000D3_A40WWPNotificationDefinitionAllow ;
      private string[] BC000D3_A38WWPNotificationDefinitionDescr ;
      private string[] BC000D3_A71WWPNotificationDefinitionIcon ;
      private string[] BC000D3_A72WWPNotificationDefinitionTitle ;
      private string[] BC000D3_A73WWPNotificationDefinitionShort ;
      private string[] BC000D3_A74WWPNotificationDefinitionLongD ;
      private string[] BC000D3_A75WWPNotificationDefinitionLink ;
      private string[] BC000D3_A76WWPNotificationDefinitionSecFu ;
      private long[] BC000D3_A29WWPEntityId ;
      private long[] BC000D2_A32WWPNotificationDefinitionId ;
      private string[] BC000D2_A68WWPNotificationDefinitionName ;
      private short[] BC000D2_A39WWPNotificationDefinitionAppli ;
      private bool[] BC000D2_A40WWPNotificationDefinitionAllow ;
      private string[] BC000D2_A38WWPNotificationDefinitionDescr ;
      private string[] BC000D2_A71WWPNotificationDefinitionIcon ;
      private string[] BC000D2_A72WWPNotificationDefinitionTitle ;
      private string[] BC000D2_A73WWPNotificationDefinitionShort ;
      private string[] BC000D2_A74WWPNotificationDefinitionLongD ;
      private string[] BC000D2_A75WWPNotificationDefinitionLink ;
      private string[] BC000D2_A76WWPNotificationDefinitionSecFu ;
      private long[] BC000D2_A29WWPEntityId ;
      private long[] BC000D7_A32WWPNotificationDefinitionId ;
      private string[] BC000D10_A30WWPEntityName ;
      private long[] BC000D11_A31WWPNotificationId ;
      private long[] BC000D12_A34WWPSubscriptionId ;
      private long[] BC000D13_A32WWPNotificationDefinitionId ;
      private string[] BC000D13_A68WWPNotificationDefinitionName ;
      private short[] BC000D13_A39WWPNotificationDefinitionAppli ;
      private bool[] BC000D13_A40WWPNotificationDefinitionAllow ;
      private string[] BC000D13_A38WWPNotificationDefinitionDescr ;
      private string[] BC000D13_A71WWPNotificationDefinitionIcon ;
      private string[] BC000D13_A72WWPNotificationDefinitionTitle ;
      private string[] BC000D13_A73WWPNotificationDefinitionShort ;
      private string[] BC000D13_A74WWPNotificationDefinitionLongD ;
      private string[] BC000D13_A75WWPNotificationDefinitionLink ;
      private string[] BC000D13_A30WWPEntityName ;
      private string[] BC000D13_A76WWPNotificationDefinitionSecFu ;
      private long[] BC000D13_A29WWPEntityId ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_notificationdefinition_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notificationdefinition_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000D2;
        prmBC000D2 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmBC000D3;
        prmBC000D3 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmBC000D4;
        prmBC000D4 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmBC000D5;
        prmBC000D5 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmBC000D6;
        prmBC000D6 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmBC000D7;
        prmBC000D7 = new Object[] {
        new ParDef("@WWPNotificationDefinitionName",GXType.NVarChar,100,0) ,
        new ParDef("@WWPNotificationDefinitionAppli",GXType.Int16,1,0) ,
        new ParDef("@WWPNotificationDefinitionAllow",GXType.Boolean,4,0) ,
        new ParDef("@WWPNotificationDefinitionDescr",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationDefinitionIcon",GXType.NVarChar,40,0) ,
        new ParDef("@WWPNotificationDefinitionTitle",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationDefinitionShort",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationDefinitionLongD",GXType.NVarChar,1000,0) ,
        new ParDef("@WWPNotificationDefinitionLink",GXType.NVarChar,1000,0) ,
        new ParDef("@WWPNotificationDefinitionSecFu",GXType.NVarChar,200,0) ,
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmBC000D8;
        prmBC000D8 = new Object[] {
        new ParDef("@WWPNotificationDefinitionName",GXType.NVarChar,100,0) ,
        new ParDef("@WWPNotificationDefinitionAppli",GXType.Int16,1,0) ,
        new ParDef("@WWPNotificationDefinitionAllow",GXType.Boolean,4,0) ,
        new ParDef("@WWPNotificationDefinitionDescr",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationDefinitionIcon",GXType.NVarChar,40,0) ,
        new ParDef("@WWPNotificationDefinitionTitle",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationDefinitionShort",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationDefinitionLongD",GXType.NVarChar,1000,0) ,
        new ParDef("@WWPNotificationDefinitionLink",GXType.NVarChar,1000,0) ,
        new ParDef("@WWPNotificationDefinitionSecFu",GXType.NVarChar,200,0) ,
        new ParDef("@WWPEntityId",GXType.Decimal,10,0) ,
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmBC000D9;
        prmBC000D9 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmBC000D10;
        prmBC000D10 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmBC000D11;
        prmBC000D11 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmBC000D12;
        prmBC000D12 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmBC000D13;
        prmBC000D13 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000D2", "SELECT [WWPNotificationDefinitionId], [WWPNotificationDefinitionName], [WWPNotificationDefinitionAppli], [WWPNotificationDefinitionAllow], [WWPNotificationDefinitionDescr], [WWPNotificationDefinitionIcon], [WWPNotificationDefinitionTitle], [WWPNotificationDefinitionShort], [WWPNotificationDefinitionLongD], [WWPNotificationDefinitionLink], [WWPNotificationDefinitionSecFu], [WWPEntityId] FROM [WWP_NotificationDefinition] WITH (UPDLOCK) WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D3", "SELECT [WWPNotificationDefinitionId], [WWPNotificationDefinitionName], [WWPNotificationDefinitionAppli], [WWPNotificationDefinitionAllow], [WWPNotificationDefinitionDescr], [WWPNotificationDefinitionIcon], [WWPNotificationDefinitionTitle], [WWPNotificationDefinitionShort], [WWPNotificationDefinitionLongD], [WWPNotificationDefinitionLink], [WWPNotificationDefinitionSecFu], [WWPEntityId] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D4", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D5", "SELECT TM1.[WWPNotificationDefinitionId], TM1.[WWPNotificationDefinitionName], TM1.[WWPNotificationDefinitionAppli], TM1.[WWPNotificationDefinitionAllow], TM1.[WWPNotificationDefinitionDescr], TM1.[WWPNotificationDefinitionIcon], TM1.[WWPNotificationDefinitionTitle], TM1.[WWPNotificationDefinitionShort], TM1.[WWPNotificationDefinitionLongD], TM1.[WWPNotificationDefinitionLink], T2.[WWPEntityName], TM1.[WWPNotificationDefinitionSecFu], TM1.[WWPEntityId] FROM ([WWP_NotificationDefinition] TM1 INNER JOIN [WWP_Entity] T2 ON T2.[WWPEntityId] = TM1.[WWPEntityId]) WHERE TM1.[WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ORDER BY TM1.[WWPNotificationDefinitionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D6", "SELECT [WWPNotificationDefinitionId] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D7", "INSERT INTO [WWP_NotificationDefinition]([WWPNotificationDefinitionName], [WWPNotificationDefinitionAppli], [WWPNotificationDefinitionAllow], [WWPNotificationDefinitionDescr], [WWPNotificationDefinitionIcon], [WWPNotificationDefinitionTitle], [WWPNotificationDefinitionShort], [WWPNotificationDefinitionLongD], [WWPNotificationDefinitionLink], [WWPNotificationDefinitionSecFu], [WWPEntityId]) VALUES(@WWPNotificationDefinitionName, @WWPNotificationDefinitionAppli, @WWPNotificationDefinitionAllow, @WWPNotificationDefinitionDescr, @WWPNotificationDefinitionIcon, @WWPNotificationDefinitionTitle, @WWPNotificationDefinitionShort, @WWPNotificationDefinitionLongD, @WWPNotificationDefinitionLink, @WWPNotificationDefinitionSecFu, @WWPEntityId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000D8", "UPDATE [WWP_NotificationDefinition] SET [WWPNotificationDefinitionName]=@WWPNotificationDefinitionName, [WWPNotificationDefinitionAppli]=@WWPNotificationDefinitionAppli, [WWPNotificationDefinitionAllow]=@WWPNotificationDefinitionAllow, [WWPNotificationDefinitionDescr]=@WWPNotificationDefinitionDescr, [WWPNotificationDefinitionIcon]=@WWPNotificationDefinitionIcon, [WWPNotificationDefinitionTitle]=@WWPNotificationDefinitionTitle, [WWPNotificationDefinitionShort]=@WWPNotificationDefinitionShort, [WWPNotificationDefinitionLongD]=@WWPNotificationDefinitionLongD, [WWPNotificationDefinitionLink]=@WWPNotificationDefinitionLink, [WWPNotificationDefinitionSecFu]=@WWPNotificationDefinitionSecFu, [WWPEntityId]=@WWPEntityId  WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId", GxErrorMask.GX_NOMASK,prmBC000D8)
           ,new CursorDef("BC000D9", "DELETE FROM [WWP_NotificationDefinition]  WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId", GxErrorMask.GX_NOMASK,prmBC000D9)
           ,new CursorDef("BC000D10", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D11", "SELECT TOP 1 [WWPNotificationId] FROM [WWP_Notification] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000D12", "SELECT TOP 1 [WWPSubscriptionId] FROM [WWP_Subscription] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000D13", "SELECT TM1.[WWPNotificationDefinitionId], TM1.[WWPNotificationDefinitionName], TM1.[WWPNotificationDefinitionAppli], TM1.[WWPNotificationDefinitionAllow], TM1.[WWPNotificationDefinitionDescr], TM1.[WWPNotificationDefinitionIcon], TM1.[WWPNotificationDefinitionTitle], TM1.[WWPNotificationDefinitionShort], TM1.[WWPNotificationDefinitionLongD], TM1.[WWPNotificationDefinitionLink], T2.[WWPEntityName], TM1.[WWPNotificationDefinitionSecFu], TM1.[WWPEntityId] FROM ([WWP_NotificationDefinition] TM1 INNER JOIN [WWP_Entity] T2 ON T2.[WWPEntityId] = TM1.[WWPEntityId]) WHERE TM1.[WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ORDER BY TM1.[WWPNotificationDefinitionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D13,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((long[]) buf[12])[0] = rslt.getLong(13);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((long[]) buf[12])[0] = rslt.getLong(13);
              return;
     }
  }

}

}
