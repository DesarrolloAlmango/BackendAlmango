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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_notification_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_notification_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_notification_bc( IGxContext context )
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
         ReadRow0E15( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0E15( ) ;
         standaloneModal( ) ;
         AddRow0E15( ) ;
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
               Z31WWPNotificationId = A31WWPNotificationId;
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

      protected void CONFIRM_0E0( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0E15( ) ;
            }
            else
            {
               CheckExtendedTable0E15( ) ;
               if ( AnyError == 0 )
               {
                  ZM0E15( 6) ;
                  ZM0E15( 7) ;
               }
               CloseExtendedTableCursors0E15( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0E15( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z33WWPNotificationCreated = A33WWPNotificationCreated;
            Z85WWPNotificationIcon = A85WWPNotificationIcon;
            Z86WWPNotificationTitle = A86WWPNotificationTitle;
            Z87WWPNotificationShortDescriptio = A87WWPNotificationShortDescriptio;
            Z88WWPNotificationLink = A88WWPNotificationLink;
            Z91WWPNotificationIsRead = A91WWPNotificationIsRead;
            Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z68WWPNotificationDefinitionName = A68WWPNotificationDefinitionName;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
         if ( GX_JID == -5 )
         {
            Z31WWPNotificationId = A31WWPNotificationId;
            Z33WWPNotificationCreated = A33WWPNotificationCreated;
            Z85WWPNotificationIcon = A85WWPNotificationIcon;
            Z86WWPNotificationTitle = A86WWPNotificationTitle;
            Z87WWPNotificationShortDescriptio = A87WWPNotificationShortDescriptio;
            Z88WWPNotificationLink = A88WWPNotificationLink;
            Z91WWPNotificationIsRead = A91WWPNotificationIsRead;
            Z69WWPNotificationMetadata = A69WWPNotificationMetadata;
            Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z68WWPNotificationDefinitionName = A68WWPNotificationDefinitionName;
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A33WWPNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A33WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0E15( )
      {
         /* Using cursor BC000E6 */
         pr_default.execute(4, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound15 = 1;
            A68WWPNotificationDefinitionName = BC000E6_A68WWPNotificationDefinitionName[0];
            A33WWPNotificationCreated = BC000E6_A33WWPNotificationCreated[0];
            A85WWPNotificationIcon = BC000E6_A85WWPNotificationIcon[0];
            A86WWPNotificationTitle = BC000E6_A86WWPNotificationTitle[0];
            A87WWPNotificationShortDescriptio = BC000E6_A87WWPNotificationShortDescriptio[0];
            A88WWPNotificationLink = BC000E6_A88WWPNotificationLink[0];
            A91WWPNotificationIsRead = BC000E6_A91WWPNotificationIsRead[0];
            A2WWPUserExtendedFullName = BC000E6_A2WWPUserExtendedFullName[0];
            A69WWPNotificationMetadata = BC000E6_A69WWPNotificationMetadata[0];
            n69WWPNotificationMetadata = BC000E6_n69WWPNotificationMetadata[0];
            A32WWPNotificationDefinitionId = BC000E6_A32WWPNotificationDefinitionId[0];
            A1WWPUserExtendedId = BC000E6_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000E6_n1WWPUserExtendedId[0];
            ZM0E15( -5) ;
         }
         pr_default.close(4);
         OnLoadActions0E15( ) ;
      }

      protected void OnLoadActions0E15( )
      {
      }

      protected void CheckExtendedTable0E15( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000E4 */
         pr_default.execute(2, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
         }
         A68WWPNotificationDefinitionName = BC000E4_A68WWPNotificationDefinitionName[0];
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A33WWPNotificationCreated) || ( A33WWPNotificationCreated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Notification Created Date", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A88WWPNotificationLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Notification Link", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000E5 */
         pr_default.execute(3, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
            }
         }
         A2WWPUserExtendedFullName = BC000E5_A2WWPUserExtendedFullName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0E15( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0E15( )
      {
         /* Using cursor BC000E7 */
         pr_default.execute(5, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000E3 */
         pr_default.execute(1, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E15( 5) ;
            RcdFound15 = 1;
            A31WWPNotificationId = BC000E3_A31WWPNotificationId[0];
            n31WWPNotificationId = BC000E3_n31WWPNotificationId[0];
            A33WWPNotificationCreated = BC000E3_A33WWPNotificationCreated[0];
            A85WWPNotificationIcon = BC000E3_A85WWPNotificationIcon[0];
            A86WWPNotificationTitle = BC000E3_A86WWPNotificationTitle[0];
            A87WWPNotificationShortDescriptio = BC000E3_A87WWPNotificationShortDescriptio[0];
            A88WWPNotificationLink = BC000E3_A88WWPNotificationLink[0];
            A91WWPNotificationIsRead = BC000E3_A91WWPNotificationIsRead[0];
            A69WWPNotificationMetadata = BC000E3_A69WWPNotificationMetadata[0];
            n69WWPNotificationMetadata = BC000E3_n69WWPNotificationMetadata[0];
            A32WWPNotificationDefinitionId = BC000E3_A32WWPNotificationDefinitionId[0];
            A1WWPUserExtendedId = BC000E3_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000E3_n1WWPUserExtendedId[0];
            Z31WWPNotificationId = A31WWPNotificationId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0E15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0E15( ) ;
            }
            Gx_mode = sMode15;
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0E15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode15;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E15( ) ;
         if ( RcdFound15 == 0 )
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
         CONFIRM_0E0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0E15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000E2 */
            pr_default.execute(0, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z33WWPNotificationCreated != BC000E2_A33WWPNotificationCreated[0] ) || ( StringUtil.StrCmp(Z85WWPNotificationIcon, BC000E2_A85WWPNotificationIcon[0]) != 0 ) || ( StringUtil.StrCmp(Z86WWPNotificationTitle, BC000E2_A86WWPNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z87WWPNotificationShortDescriptio, BC000E2_A87WWPNotificationShortDescriptio[0]) != 0 ) || ( StringUtil.StrCmp(Z88WWPNotificationLink, BC000E2_A88WWPNotificationLink[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z91WWPNotificationIsRead != BC000E2_A91WWPNotificationIsRead[0] ) || ( Z32WWPNotificationDefinitionId != BC000E2_A32WWPNotificationDefinitionId[0] ) || ( StringUtil.StrCmp(Z1WWPUserExtendedId, BC000E2_A1WWPUserExtendedId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Notification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E15( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E15( 0) ;
            CheckOptimisticConcurrency0E15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E8 */
                     pr_default.execute(6, new Object[] {A33WWPNotificationCreated, A85WWPNotificationIcon, A86WWPNotificationTitle, A87WWPNotificationShortDescriptio, A88WWPNotificationLink, A91WWPNotificationIsRead, n69WWPNotificationMetadata, A69WWPNotificationMetadata, A32WWPNotificationDefinitionId, n1WWPUserExtendedId, A1WWPUserExtendedId});
                     A31WWPNotificationId = BC000E8_A31WWPNotificationId[0];
                     n31WWPNotificationId = BC000E8_n31WWPNotificationId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
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
               Load0E15( ) ;
            }
            EndLevel0E15( ) ;
         }
         CloseExtendedTableCursors0E15( ) ;
      }

      protected void Update0E15( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E9 */
                     pr_default.execute(7, new Object[] {A33WWPNotificationCreated, A85WWPNotificationIcon, A86WWPNotificationTitle, A87WWPNotificationShortDescriptio, A88WWPNotificationLink, A91WWPNotificationIsRead, n69WWPNotificationMetadata, A69WWPNotificationMetadata, A32WWPNotificationDefinitionId, n1WWPUserExtendedId, A1WWPUserExtendedId, n31WWPNotificationId, A31WWPNotificationId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E15( ) ;
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
            EndLevel0E15( ) ;
         }
         CloseExtendedTableCursors0E15( ) ;
      }

      protected void DeferredUpdate0E15( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E15( ) ;
            AfterConfirm0E15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E15( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000E10 */
                  pr_default.execute(8, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0E15( ) ;
         Gx_mode = sMode15;
      }

      protected void OnDeleteControls0E15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000E11 */
            pr_default.execute(9, new Object[] {A32WWPNotificationDefinitionId});
            A68WWPNotificationDefinitionName = BC000E11_A68WWPNotificationDefinitionName[0];
            pr_default.close(9);
            /* Using cursor BC000E12 */
            pr_default.execute(10, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
            A2WWPUserExtendedFullName = BC000E12_A2WWPUserExtendedFullName[0];
            pr_default.close(10);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000E13 */
            pr_default.execute(11, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_Mail", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000E14 */
            pr_default.execute(12, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_WebNotification", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000E15 */
            pr_default.execute(13, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_SMS", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel0E15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( mustCommit )
            {
               pr_default.close(1);
               pr_default.close(9);
               pr_default.close(10);
               context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_notification_bc",pr_default);
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            if ( mustCommit )
            {
               pr_default.close(1);
               pr_default.close(9);
               pr_default.close(10);
               context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notification_bc",pr_default);
            }
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0E15( )
      {
         /* Using cursor BC000E16 */
         pr_default.execute(14, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         RcdFound15 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound15 = 1;
            A31WWPNotificationId = BC000E16_A31WWPNotificationId[0];
            n31WWPNotificationId = BC000E16_n31WWPNotificationId[0];
            A68WWPNotificationDefinitionName = BC000E16_A68WWPNotificationDefinitionName[0];
            A33WWPNotificationCreated = BC000E16_A33WWPNotificationCreated[0];
            A85WWPNotificationIcon = BC000E16_A85WWPNotificationIcon[0];
            A86WWPNotificationTitle = BC000E16_A86WWPNotificationTitle[0];
            A87WWPNotificationShortDescriptio = BC000E16_A87WWPNotificationShortDescriptio[0];
            A88WWPNotificationLink = BC000E16_A88WWPNotificationLink[0];
            A91WWPNotificationIsRead = BC000E16_A91WWPNotificationIsRead[0];
            A2WWPUserExtendedFullName = BC000E16_A2WWPUserExtendedFullName[0];
            A69WWPNotificationMetadata = BC000E16_A69WWPNotificationMetadata[0];
            n69WWPNotificationMetadata = BC000E16_n69WWPNotificationMetadata[0];
            A32WWPNotificationDefinitionId = BC000E16_A32WWPNotificationDefinitionId[0];
            A1WWPUserExtendedId = BC000E16_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000E16_n1WWPUserExtendedId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0E15( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound15 = 0;
         ScanKeyLoad0E15( ) ;
      }

      protected void ScanKeyLoad0E15( )
      {
         sMode15 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound15 = 1;
            A31WWPNotificationId = BC000E16_A31WWPNotificationId[0];
            n31WWPNotificationId = BC000E16_n31WWPNotificationId[0];
            A68WWPNotificationDefinitionName = BC000E16_A68WWPNotificationDefinitionName[0];
            A33WWPNotificationCreated = BC000E16_A33WWPNotificationCreated[0];
            A85WWPNotificationIcon = BC000E16_A85WWPNotificationIcon[0];
            A86WWPNotificationTitle = BC000E16_A86WWPNotificationTitle[0];
            A87WWPNotificationShortDescriptio = BC000E16_A87WWPNotificationShortDescriptio[0];
            A88WWPNotificationLink = BC000E16_A88WWPNotificationLink[0];
            A91WWPNotificationIsRead = BC000E16_A91WWPNotificationIsRead[0];
            A2WWPUserExtendedFullName = BC000E16_A2WWPUserExtendedFullName[0];
            A69WWPNotificationMetadata = BC000E16_A69WWPNotificationMetadata[0];
            n69WWPNotificationMetadata = BC000E16_n69WWPNotificationMetadata[0];
            A32WWPNotificationDefinitionId = BC000E16_A32WWPNotificationDefinitionId[0];
            A1WWPUserExtendedId = BC000E16_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000E16_n1WWPUserExtendedId[0];
         }
         Gx_mode = sMode15;
      }

      protected void ScanKeyEnd0E15( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0E15( )
      {
         /* After Confirm Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) )
         {
            A1WWPUserExtendedId = "";
            n1WWPUserExtendedId = false;
            n1WWPUserExtendedId = true;
         }
      }

      protected void BeforeInsert0E15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E15( )
      {
      }

      protected void send_integrity_lvl_hashes0E15( )
      {
      }

      protected void AddRow0E15( )
      {
         VarsToRow15( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
      }

      protected void ReadRow0E15( )
      {
         RowToVars15( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
      }

      protected void InitializeNonKey0E15( )
      {
         A32WWPNotificationDefinitionId = 0;
         A68WWPNotificationDefinitionName = "";
         A85WWPNotificationIcon = "";
         A86WWPNotificationTitle = "";
         A87WWPNotificationShortDescriptio = "";
         A88WWPNotificationLink = "";
         A91WWPNotificationIsRead = false;
         A1WWPUserExtendedId = "";
         n1WWPUserExtendedId = false;
         A2WWPUserExtendedFullName = "";
         A69WWPNotificationMetadata = "";
         n69WWPNotificationMetadata = false;
         A33WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z85WWPNotificationIcon = "";
         Z86WWPNotificationTitle = "";
         Z87WWPNotificationShortDescriptio = "";
         Z88WWPNotificationLink = "";
         Z91WWPNotificationIsRead = false;
         Z32WWPNotificationDefinitionId = 0;
         Z1WWPUserExtendedId = "";
      }

      protected void InitAll0E15( )
      {
         A31WWPNotificationId = 0;
         n31WWPNotificationId = false;
         InitializeNonKey0E15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A33WWPNotificationCreated = i33WWPNotificationCreated;
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

      public void VarsToRow15( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification obj15 )
      {
         obj15.gxTpr_Mode = Gx_mode;
         obj15.gxTpr_Wwpnotificationdefinitionid = A32WWPNotificationDefinitionId;
         obj15.gxTpr_Wwpnotificationdefinitionname = A68WWPNotificationDefinitionName;
         obj15.gxTpr_Wwpnotificationicon = A85WWPNotificationIcon;
         obj15.gxTpr_Wwpnotificationtitle = A86WWPNotificationTitle;
         obj15.gxTpr_Wwpnotificationshortdescription = A87WWPNotificationShortDescriptio;
         obj15.gxTpr_Wwpnotificationlink = A88WWPNotificationLink;
         obj15.gxTpr_Wwpnotificationisread = A91WWPNotificationIsRead;
         obj15.gxTpr_Wwpuserextendedid = A1WWPUserExtendedId;
         obj15.gxTpr_Wwpuserextendedfullname = A2WWPUserExtendedFullName;
         obj15.gxTpr_Wwpnotificationmetadata = A69WWPNotificationMetadata;
         obj15.gxTpr_Wwpnotificationcreated = A33WWPNotificationCreated;
         obj15.gxTpr_Wwpnotificationid = A31WWPNotificationId;
         obj15.gxTpr_Wwpnotificationid_Z = Z31WWPNotificationId;
         obj15.gxTpr_Wwpnotificationdefinitionid_Z = Z32WWPNotificationDefinitionId;
         obj15.gxTpr_Wwpnotificationdefinitionname_Z = Z68WWPNotificationDefinitionName;
         obj15.gxTpr_Wwpnotificationcreated_Z = Z33WWPNotificationCreated;
         obj15.gxTpr_Wwpnotificationicon_Z = Z85WWPNotificationIcon;
         obj15.gxTpr_Wwpnotificationtitle_Z = Z86WWPNotificationTitle;
         obj15.gxTpr_Wwpnotificationshortdescription_Z = Z87WWPNotificationShortDescriptio;
         obj15.gxTpr_Wwpnotificationlink_Z = Z88WWPNotificationLink;
         obj15.gxTpr_Wwpnotificationisread_Z = Z91WWPNotificationIsRead;
         obj15.gxTpr_Wwpuserextendedid_Z = Z1WWPUserExtendedId;
         obj15.gxTpr_Wwpuserextendedfullname_Z = Z2WWPUserExtendedFullName;
         obj15.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n31WWPNotificationId));
         obj15.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n1WWPUserExtendedId));
         obj15.gxTpr_Wwpnotificationmetadata_N = (short)(Convert.ToInt16(n69WWPNotificationMetadata));
         obj15.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow15( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification obj15 )
      {
         obj15.gxTpr_Wwpnotificationid = A31WWPNotificationId;
         return  ;
      }

      public void RowToVars15( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification obj15 ,
                               int forceLoad )
      {
         Gx_mode = obj15.gxTpr_Mode;
         A32WWPNotificationDefinitionId = obj15.gxTpr_Wwpnotificationdefinitionid;
         A68WWPNotificationDefinitionName = obj15.gxTpr_Wwpnotificationdefinitionname;
         A85WWPNotificationIcon = obj15.gxTpr_Wwpnotificationicon;
         A86WWPNotificationTitle = obj15.gxTpr_Wwpnotificationtitle;
         A87WWPNotificationShortDescriptio = obj15.gxTpr_Wwpnotificationshortdescription;
         A88WWPNotificationLink = obj15.gxTpr_Wwpnotificationlink;
         A91WWPNotificationIsRead = obj15.gxTpr_Wwpnotificationisread;
         A1WWPUserExtendedId = obj15.gxTpr_Wwpuserextendedid;
         n1WWPUserExtendedId = false;
         A2WWPUserExtendedFullName = obj15.gxTpr_Wwpuserextendedfullname;
         A69WWPNotificationMetadata = obj15.gxTpr_Wwpnotificationmetadata;
         n69WWPNotificationMetadata = false;
         A33WWPNotificationCreated = obj15.gxTpr_Wwpnotificationcreated;
         A31WWPNotificationId = obj15.gxTpr_Wwpnotificationid;
         n31WWPNotificationId = false;
         Z31WWPNotificationId = obj15.gxTpr_Wwpnotificationid_Z;
         Z32WWPNotificationDefinitionId = obj15.gxTpr_Wwpnotificationdefinitionid_Z;
         Z68WWPNotificationDefinitionName = obj15.gxTpr_Wwpnotificationdefinitionname_Z;
         Z33WWPNotificationCreated = obj15.gxTpr_Wwpnotificationcreated_Z;
         Z85WWPNotificationIcon = obj15.gxTpr_Wwpnotificationicon_Z;
         Z86WWPNotificationTitle = obj15.gxTpr_Wwpnotificationtitle_Z;
         Z87WWPNotificationShortDescriptio = obj15.gxTpr_Wwpnotificationshortdescription_Z;
         Z88WWPNotificationLink = obj15.gxTpr_Wwpnotificationlink_Z;
         Z91WWPNotificationIsRead = obj15.gxTpr_Wwpnotificationisread_Z;
         Z1WWPUserExtendedId = obj15.gxTpr_Wwpuserextendedid_Z;
         Z2WWPUserExtendedFullName = obj15.gxTpr_Wwpuserextendedfullname_Z;
         n31WWPNotificationId = (bool)(Convert.ToBoolean(obj15.gxTpr_Wwpnotificationid_N));
         n1WWPUserExtendedId = (bool)(Convert.ToBoolean(obj15.gxTpr_Wwpuserextendedid_N));
         n69WWPNotificationMetadata = (bool)(Convert.ToBoolean(obj15.gxTpr_Wwpnotificationmetadata_N));
         Gx_mode = obj15.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A31WWPNotificationId = (long)getParm(obj,0);
         n31WWPNotificationId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0E15( ) ;
         ScanKeyStart0E15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z31WWPNotificationId = A31WWPNotificationId;
         }
         ZM0E15( -5) ;
         OnLoadActions0E15( ) ;
         AddRow0E15( ) ;
         ScanKeyEnd0E15( ) ;
         if ( RcdFound15 == 0 )
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
         RowToVars15( bcwwpbaseobjects_notifications_common_WWP_Notification, 0) ;
         ScanKeyStart0E15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z31WWPNotificationId = A31WWPNotificationId;
         }
         ZM0E15( -5) ;
         OnLoadActions0E15( ) ;
         AddRow0E15( ) ;
         ScanKeyEnd0E15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0E15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0E15( ) ;
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A31WWPNotificationId != Z31WWPNotificationId )
               {
                  A31WWPNotificationId = Z31WWPNotificationId;
                  n31WWPNotificationId = false;
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
                  Update0E15( ) ;
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
                  if ( A31WWPNotificationId != Z31WWPNotificationId )
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
                        Insert0E15( ) ;
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
                        Insert0E15( ) ;
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
         RowToVars15( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         SaveImpl( ) ;
         VarsToRow15( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars15( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E15( ) ;
         AfterTrn( ) ;
         VarsToRow15( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow15( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A31WWPNotificationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_common_WWP_Notification);
               auxBC.Save();
               bcwwpbaseobjects_notifications_common_WWP_Notification.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars15( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
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
         RowToVars15( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E15( ) ;
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
               VarsToRow15( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow15( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
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
         RowToVars15( bcwwpbaseobjects_notifications_common_WWP_Notification, 0) ;
         GetKey0E15( ) ;
         if ( RcdFound15 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A31WWPNotificationId != Z31WWPNotificationId )
            {
               A31WWPNotificationId = Z31WWPNotificationId;
               n31WWPNotificationId = false;
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
            if ( A31WWPNotificationId != Z31WWPNotificationId )
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
         pr_default.close(9);
         pr_default.close(10);
         context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notification_bc",pr_default);
         VarsToRow15( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_common_WWP_Notification )
         {
            bcwwpbaseobjects_notifications_common_WWP_Notification = (GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow15( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
            }
            else
            {
               RowToVars15( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars15( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_Notification WWP_Notification_BC
      {
         get {
            return bcwwpbaseobjects_notifications_common_WWP_Notification ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         mustCommit = true;
         GxHttpClient GXSoapHTTPClient;
         GXSoapHTTPClient = new GxHttpClient( context);
         GxSoapRequest GXSoapHTTPRequest;
         GXSoapHTTPRequest = new GxSoapRequest(context) ;
         GXXMLReader GXSoapXMLReader;
         GXSoapXMLReader = new GXXMLReader(context.GetPhysicalPath());
         short GXSoapError;
         GXSoapError = 0;
         GxHttpResponse GXSoapHTTPResponse;
         GXSoapHTTPResponse = new GxHttpResponse(context) ;
         GXXMLWriter GXSoapXMLWriter;
         GXSoapXMLWriter = new GXXMLWriter(context.GetPhysicalPath());
         if ( ! context.isAjaxRequest( ) )
         {
            GXSoapHTTPResponse.AppendHeader("Content-type", "text/xml;charset=utf-8");
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapHTTPRequest.Method), "get") == 0 )
         {
            if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapHTTPRequest.QueryString), "wsdl") == 0 )
            {
               GXSoapXMLWriter.OpenResponse(GXSoapHTTPResponse);
               GXSoapXMLWriter.WriteStartDocument("utf-8", 0);
               GXSoapXMLWriter.WriteStartElement("definitions");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC");
               GXSoapXMLWriter.WriteAttribute("targetNamespace", "AlmangoX");
               GXSoapXMLWriter.WriteAttribute("xmlns:wsdlns", "AlmangoX");
               GXSoapXMLWriter.WriteAttribute("xmlns:soap", "http://schemas.xmlsoap.org/wsdl/soap/");
               GXSoapXMLWriter.WriteAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
               GXSoapXMLWriter.WriteAttribute("xmlns", "http://schemas.xmlsoap.org/wsdl/");
               GXSoapXMLWriter.WriteAttribute("xmlns:tns1", "GeneXus");
               GXSoapXMLWriter.WriteAttribute("xmlns:tns", "AlmangoX");
               GXSoapXMLWriter.WriteStartElement("types");
               GXSoapXMLWriter.WriteStartElement("schema");
               GXSoapXMLWriter.WriteAttribute("targetNamespace", "GeneXus");
               GXSoapXMLWriter.WriteAttribute("xmlns", "http://www.w3.org/2001/XMLSchema");
               GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENC", "http://schemas.xmlsoap.org/soap/encoding/");
               GXSoapXMLWriter.WriteAttribute("elementFormDefault", "qualified");
               GXSoapXMLWriter.WriteElement("import", "");
               GXSoapXMLWriter.WriteAttribute("namespace", "AlmangoX");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "Messages");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "Message");
               GXSoapXMLWriter.WriteAttribute("type", "tns1:GeneXus.Common.Messages.Message");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "GeneXus.Common.Messages.Message");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Id");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Type");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:byte");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Description");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("schema");
               GXSoapXMLWriter.WriteAttribute("targetNamespace", "AlmangoX");
               GXSoapXMLWriter.WriteAttribute("xmlns", "http://www.w3.org/2001/XMLSchema");
               GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENC", "http://schemas.xmlsoap.org/soap/encoding/");
               GXSoapXMLWriter.WriteAttribute("elementFormDefault", "qualified");
               GXSoapXMLWriter.WriteElement("import", "");
               GXSoapXMLWriter.WriteAttribute("namespace", "GeneXus");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "WWP_Notification");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationId");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationDefinitionId");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationDefinitionName");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationCreated");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:dateTime");
               GXSoapXMLWriter.WriteAttribute("nillable", "true");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationIcon");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationTitle");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationShortDescription");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationLink");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationIsRead");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:boolean");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPUserExtendedId");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPUserExtendedFullName");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationMetadata");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Mode");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Initialized");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:short");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationId_Z");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationDefinitionId_Z");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationDefinitionName_Z");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationCreated_Z");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:dateTime");
               GXSoapXMLWriter.WriteAttribute("nillable", "true");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationIcon_Z");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationTitle_Z");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationShortDescription_Z");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationLink_Z");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationIsRead_Z");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:boolean");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPUserExtendedId_Z");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPUserExtendedFullName_Z");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationId_N");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:byte");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPUserExtendedId_N");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:byte");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPNotificationMetadata_N");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:byte");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.LoadKeySvc");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Wwpnotificationid");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "bcwwpbaseobjects_notifications_common_WWP_Notification");
               GXSoapXMLWriter.WriteAttribute("type", "tns:WWP_Notification");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.LoadKeySvcResponse");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "bcwwpbaseobjects_notifications_common_WWP_Notification");
               GXSoapXMLWriter.WriteAttribute("type", "tns:WWP_Notification");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "bcwwpbaseobjects_notifications_common_WWP_NotificationMessages");
               GXSoapXMLWriter.WriteAttribute("type", "tns1:Messages");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.SaveSvc");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "bcwwpbaseobjects_notifications_common_WWP_Notification");
               GXSoapXMLWriter.WriteAttribute("type", "tns:WWP_Notification");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.SaveSvcResponse");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "bcwwpbaseobjects_notifications_common_WWP_Notification");
               GXSoapXMLWriter.WriteAttribute("type", "tns:WWP_Notification");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "bcwwpbaseobjects_notifications_common_WWP_NotificationMessages");
               GXSoapXMLWriter.WriteAttribute("type", "tns1:Messages");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.CheckSvc");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "bcwwpbaseobjects_notifications_common_WWP_Notification");
               GXSoapXMLWriter.WriteAttribute("type", "tns:WWP_Notification");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.CheckSvcResponse");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "bcwwpbaseobjects_notifications_common_WWP_Notification");
               GXSoapXMLWriter.WriteAttribute("type", "tns:WWP_Notification");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "bcwwpbaseobjects_notifications_common_WWP_NotificationMessages");
               GXSoapXMLWriter.WriteAttribute("type", "tns1:Messages");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.DeleteSvc");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "bcwwpbaseobjects_notifications_common_WWP_Notification");
               GXSoapXMLWriter.WriteAttribute("type", "tns:WWP_Notification");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.DeleteSvcResponse");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "bcwwpbaseobjects_notifications_common_WWP_Notification");
               GXSoapXMLWriter.WriteAttribute("type", "tns:WWP_Notification");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "bcwwpbaseobjects_notifications_common_WWP_NotificationMessages");
               GXSoapXMLWriter.WriteAttribute("type", "tns1:Messages");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.LoadKeySvcSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.LoadKeySvc");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.LoadKeySvcSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.LoadKeySvcResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.SaveSvcSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.SaveSvc");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.SaveSvcSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.SaveSvcResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.CheckSvcSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.CheckSvc");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.CheckSvcSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.CheckSvcResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.DeleteSvcSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.DeleteSvc");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.DeleteSvcSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.DeleteSvcResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBCSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "LoadKeySvc");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.LoadKeySvcSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.LoadKeySvcSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "SaveSvc");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.SaveSvcSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.SaveSvcSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "CheckSvc");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.CheckSvcSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.CheckSvcSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "DeleteSvc");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.DeleteSvcSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.DeleteSvcSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBCSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"WWPBaseObjects.Notifications.Common.WWP_Notification_BCBCSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "LoadKeySvc");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "AlmangoXaction/"+"wwpbaseobjects.notifications.common.WWP_NOTIFICATION_BC.LoadKeySvc");
               GXSoapXMLWriter.WriteStartElement("input");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("output");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "SaveSvc");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "AlmangoXaction/"+"wwpbaseobjects.notifications.common.WWP_NOTIFICATION_BC.SaveSvc");
               GXSoapXMLWriter.WriteStartElement("input");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("output");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "CheckSvc");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "AlmangoXaction/"+"wwpbaseobjects.notifications.common.WWP_NOTIFICATION_BC.CheckSvc");
               GXSoapXMLWriter.WriteStartElement("input");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("output");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "DeleteSvc");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "AlmangoXaction/"+"wwpbaseobjects.notifications.common.WWP_NOTIFICATION_BC.DeleteSvc");
               GXSoapXMLWriter.WriteStartElement("input");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("output");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("service");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "WWPBaseObjects.Notifications.Common.WWP_Notification_BCBCSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"WWPBaseObjects.Notifications.Common.WWP_Notification_BCBCSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"wwpbaseobjects.notifications.common.wwp_notification_bc.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "wwpbaseobjects.notifications.common.wwp_notification_bc.aspx" + "?wsdl to get the WSDL.";
            }
         }
         if ( currSoapErr == 0 )
         {
            GXSoapXMLReader.OpenRequest(GXSoapHTTPRequest);
            GXSoapXMLReader.ReadExternalEntities = 0;
            GXSoapXMLReader.IgnoreComments = 1;
            GXSoapError = GXSoapXMLReader.Read();
            while ( GXSoapError > 0 )
            {
               if ( StringUtil.StringSearch( GXSoapXMLReader.Name, "Envelope", 1) > 0 )
               {
                  this.SetPrefixesFromReader( GXSoapXMLReader);
               }
               if ( StringUtil.StringSearch( GXSoapXMLReader.Name, "Body", 1) > 0 )
               {
                  this.SetPrefixesFromReader( GXSoapXMLReader);
                  if (true) break;
               }
               GXSoapError = GXSoapXMLReader.Read();
            }
            if ( GXSoapError > 0 )
            {
               GXSoapError = GXSoapXMLReader.Read();
               if ( GXSoapError > 0 )
               {
                  this.SetPrefixesFromReader( GXSoapXMLReader);
                  currMethod = GXSoapXMLReader.Name;
                  if ( ( StringUtil.StringSearch( currMethod+"&", "LoadKeySvc&", 1) > 0 ) || ( currSoapErr != 0 ) )
                  {
                     if ( currSoapErr == 0 )
                     {
                        bcwwpbaseobjects_notifications_common_WWP_Notification = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
                        bcwwpbaseobjects_notifications_common_WWP_NotificationMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
                        formatError = false;
                        sTagName = GXSoapXMLReader.Name;
                        if ( GXSoapXMLReader.IsSimple == 0 )
                        {
                           GXSoapError = GXSoapXMLReader.Read();
                           nOutParmCount = 0;
                           while ( ( ( StringUtil.StrCmp(GXSoapXMLReader.Name, sTagName) != 0 ) || ( GXSoapXMLReader.NodeType == 1 ) ) && ( GXSoapError > 0 ) )
                           {
                              readOk = 0;
                              readElement = false;
                              this.SetNamedPrefixesFromReader( GXSoapXMLReader);
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Wwpnotificationid") )
                              {
                                 A31WWPNotificationId = (long)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
                                 n31WWPNotificationId = false;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "bcwwpbaseobjects_notifications_common_WWP_Notification") )
                              {
                                 if ( bcwwpbaseobjects_notifications_common_WWP_Notification == null )
                                 {
                                    bcwwpbaseobjects_notifications_common_WWP_Notification = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
                                 }
                                 bcwwpbaseobjects_notifications_common_WWP_Notification.SetPrefixes( GetPrefixesInContext(), GXSoapXMLReader);
                                 GXSoapError = bcwwpbaseobjects_notifications_common_WWP_Notification.readxml(GXSoapXMLReader, "bcwwpbaseobjects_notifications_common_WWP_Notification");
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( ! readElement )
                              {
                                 readOk = 1;
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              nOutParmCount = (short)(nOutParmCount+1);
                              if ( ( readOk == 0 ) || formatError )
                              {
                                 context.sSOAPErrMsg += "Error reading " + sTagName + StringUtil.NewLine( );
                                 context.sSOAPErrMsg += "Message: " + GXSoapXMLReader.ReadRawXML();
                                 GXSoapError = (short)(nOutParmCount*-1);
                              }
                           }
                        }
                     }
                  }
                  else if ( ( StringUtil.StringSearch( currMethod+"&", "SaveSvc&", 1) > 0 ) || ( currSoapErr != 0 ) )
                  {
                     if ( currSoapErr == 0 )
                     {
                        bcwwpbaseobjects_notifications_common_WWP_Notification = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
                        bcwwpbaseobjects_notifications_common_WWP_NotificationMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
                        formatError = false;
                        sTagName = GXSoapXMLReader.Name;
                        if ( GXSoapXMLReader.IsSimple == 0 )
                        {
                           if ( ! StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "bcwwpbaseobjects_notifications_common_WWP_Notification") )
                           {
                              GXSoapError = GXSoapXMLReader.Read();
                           }
                           nOutParmCount = 0;
                           while ( ( ( StringUtil.StrCmp(GXSoapXMLReader.Name, sTagName) != 0 ) || ( GXSoapXMLReader.NodeType == 1 ) ) && ( GXSoapError > 0 ) )
                           {
                              readOk = 0;
                              readElement = false;
                              this.SetNamedPrefixesFromReader( GXSoapXMLReader);
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "bcwwpbaseobjects_notifications_common_WWP_Notification") )
                              {
                                 if ( bcwwpbaseobjects_notifications_common_WWP_Notification == null )
                                 {
                                    bcwwpbaseobjects_notifications_common_WWP_Notification = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
                                 }
                                 bcwwpbaseobjects_notifications_common_WWP_Notification.SetPrefixes( GetPrefixesInContext(), GXSoapXMLReader);
                                 GXSoapError = bcwwpbaseobjects_notifications_common_WWP_Notification.readxml(GXSoapXMLReader, "bcwwpbaseobjects_notifications_common_WWP_Notification");
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( ! readElement )
                              {
                                 readOk = 1;
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              nOutParmCount = (short)(nOutParmCount+1);
                              if ( ( readOk == 0 ) || formatError )
                              {
                                 context.sSOAPErrMsg += "Error reading " + sTagName + StringUtil.NewLine( );
                                 context.sSOAPErrMsg += "Message: " + GXSoapXMLReader.ReadRawXML();
                                 GXSoapError = (short)(nOutParmCount*-1);
                              }
                           }
                        }
                     }
                  }
                  else if ( ( StringUtil.StringSearch( currMethod+"&", "CheckSvc&", 1) > 0 ) || ( currSoapErr != 0 ) )
                  {
                     if ( currSoapErr == 0 )
                     {
                        bcwwpbaseobjects_notifications_common_WWP_Notification = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
                        bcwwpbaseobjects_notifications_common_WWP_NotificationMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
                        formatError = false;
                        sTagName = GXSoapXMLReader.Name;
                        if ( GXSoapXMLReader.IsSimple == 0 )
                        {
                           if ( ! StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "bcwwpbaseobjects_notifications_common_WWP_Notification") )
                           {
                              GXSoapError = GXSoapXMLReader.Read();
                           }
                           nOutParmCount = 0;
                           while ( ( ( StringUtil.StrCmp(GXSoapXMLReader.Name, sTagName) != 0 ) || ( GXSoapXMLReader.NodeType == 1 ) ) && ( GXSoapError > 0 ) )
                           {
                              readOk = 0;
                              readElement = false;
                              this.SetNamedPrefixesFromReader( GXSoapXMLReader);
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "bcwwpbaseobjects_notifications_common_WWP_Notification") )
                              {
                                 if ( bcwwpbaseobjects_notifications_common_WWP_Notification == null )
                                 {
                                    bcwwpbaseobjects_notifications_common_WWP_Notification = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
                                 }
                                 bcwwpbaseobjects_notifications_common_WWP_Notification.SetPrefixes( GetPrefixesInContext(), GXSoapXMLReader);
                                 GXSoapError = bcwwpbaseobjects_notifications_common_WWP_Notification.readxml(GXSoapXMLReader, "bcwwpbaseobjects_notifications_common_WWP_Notification");
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( ! readElement )
                              {
                                 readOk = 1;
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              nOutParmCount = (short)(nOutParmCount+1);
                              if ( ( readOk == 0 ) || formatError )
                              {
                                 context.sSOAPErrMsg += "Error reading " + sTagName + StringUtil.NewLine( );
                                 context.sSOAPErrMsg += "Message: " + GXSoapXMLReader.ReadRawXML();
                                 GXSoapError = (short)(nOutParmCount*-1);
                              }
                           }
                        }
                     }
                  }
                  else if ( ( StringUtil.StringSearch( currMethod+"&", "DeleteSvc&", 1) > 0 ) || ( currSoapErr != 0 ) )
                  {
                     if ( currSoapErr == 0 )
                     {
                        bcwwpbaseobjects_notifications_common_WWP_Notification = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
                        bcwwpbaseobjects_notifications_common_WWP_NotificationMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
                        formatError = false;
                        sTagName = GXSoapXMLReader.Name;
                        if ( GXSoapXMLReader.IsSimple == 0 )
                        {
                           if ( ! StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "bcwwpbaseobjects_notifications_common_WWP_Notification") )
                           {
                              GXSoapError = GXSoapXMLReader.Read();
                           }
                           nOutParmCount = 0;
                           while ( ( ( StringUtil.StrCmp(GXSoapXMLReader.Name, sTagName) != 0 ) || ( GXSoapXMLReader.NodeType == 1 ) ) && ( GXSoapError > 0 ) )
                           {
                              readOk = 0;
                              readElement = false;
                              this.SetNamedPrefixesFromReader( GXSoapXMLReader);
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "bcwwpbaseobjects_notifications_common_WWP_Notification") )
                              {
                                 if ( bcwwpbaseobjects_notifications_common_WWP_Notification == null )
                                 {
                                    bcwwpbaseobjects_notifications_common_WWP_Notification = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
                                 }
                                 bcwwpbaseobjects_notifications_common_WWP_Notification.SetPrefixes( GetPrefixesInContext(), GXSoapXMLReader);
                                 GXSoapError = bcwwpbaseobjects_notifications_common_WWP_Notification.readxml(GXSoapXMLReader, "bcwwpbaseobjects_notifications_common_WWP_Notification");
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( ! readElement )
                              {
                                 readOk = 1;
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              nOutParmCount = (short)(nOutParmCount+1);
                              if ( ( readOk == 0 ) || formatError )
                              {
                                 context.sSOAPErrMsg += "Error reading " + sTagName + StringUtil.NewLine( );
                                 context.sSOAPErrMsg += "Message: " + GXSoapXMLReader.ReadRawXML();
                                 GXSoapError = (short)(nOutParmCount*-1);
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     currSoapErr = (short)(-20002);
                     currSoapErrmsg = "Wrong method called. Expected method: " + "LoadKeySvc,SaveSvc,CheckSvc,DeleteSvc";
                  }
               }
            }
            GXSoapXMLReader.Close();
         }
         if ( currSoapErr == 0 )
         {
            if ( GXSoapError < 0 )
            {
               currSoapErr = (short)(GXSoapError*-1);
               currSoapErrmsg = context.sSOAPErrMsg;
            }
            else
            {
               if ( GXSoapXMLReader.ErrCode > 0 )
               {
                  currSoapErr = (short)(GXSoapXMLReader.ErrCode*-1);
                  currSoapErrmsg = GXSoapXMLReader.ErrDescription;
               }
               else
               {
                  if ( GXSoapError == 0 )
                  {
                     currSoapErr = (short)(-20001);
                     currSoapErrmsg = "Malformed SOAP message.";
                  }
                  else
                  {
                     currSoapErr = 0;
                     currSoapErrmsg = "No error.";
                  }
               }
            }
         }
         if ( currSoapErr == 0 )
         {
            if ( ( StringUtil.StringSearch( currMethod+"&", "LoadKeySvc&", 1) > 0 ) || ( currSoapErr != 0 ) )
            {
               bcwwpbaseobjects_notifications_common_WWP_Notification.ForceCommitOnExit();
               bcwwpbaseobjects_notifications_common_WWP_Notification.Load(A31WWPNotificationId);
               bcwwpbaseobjects_notifications_common_WWP_NotificationMessages = bcwwpbaseobjects_notifications_common_WWP_Notification.GetMessages();
            }
            else if ( ( StringUtil.StringSearch( currMethod+"&", "SaveSvc&", 1) > 0 ) || ( currSoapErr != 0 ) )
            {
               bcwwpbaseobjects_notifications_common_WWP_Notification.ForceCommitOnExit();
               bcwwpbaseobjects_notifications_common_WWP_Notification.Save();
               bcwwpbaseobjects_notifications_common_WWP_NotificationMessages = bcwwpbaseobjects_notifications_common_WWP_Notification.GetMessages();
            }
            else if ( ( StringUtil.StringSearch( currMethod+"&", "CheckSvc&", 1) > 0 ) || ( currSoapErr != 0 ) )
            {
               bcwwpbaseobjects_notifications_common_WWP_Notification.ForceCommitOnExit();
               bcwwpbaseobjects_notifications_common_WWP_Notification.Check();
               bcwwpbaseobjects_notifications_common_WWP_NotificationMessages = bcwwpbaseobjects_notifications_common_WWP_Notification.GetMessages();
            }
            else if ( ( StringUtil.StringSearch( currMethod+"&", "DeleteSvc&", 1) > 0 ) || ( currSoapErr != 0 ) )
            {
               bcwwpbaseobjects_notifications_common_WWP_Notification.ForceCommitOnExit();
               bcwwpbaseobjects_notifications_common_WWP_Notification.Delete();
               bcwwpbaseobjects_notifications_common_WWP_NotificationMessages = bcwwpbaseobjects_notifications_common_WWP_Notification.GetMessages();
            }
         }
         context.CloseConnections();
         sIncludeState = true;
         GXSoapXMLWriter.OpenResponse(GXSoapHTTPResponse);
         GXSoapXMLWriter.WriteStartDocument("utf-8", 0);
         GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Envelope");
         GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENV", "http://schemas.xmlsoap.org/soap/envelope/");
         GXSoapXMLWriter.WriteAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
         GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENC", "http://schemas.xmlsoap.org/soap/encoding/");
         GXSoapXMLWriter.WriteAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
         if ( ( StringUtil.StringSearch( currMethod+"&", "LoadKeySvc&", 1) > 0 ) || ( currSoapErr != 0 ) )
         {
            GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Body");
            GXSoapXMLWriter.WriteStartElement("WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.LoadKeySvcResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
            if ( currSoapErr == 0 )
            {
               if ( bcwwpbaseobjects_notifications_common_WWP_Notification != null )
               {
                  bcwwpbaseobjects_notifications_common_WWP_Notification.writexml(GXSoapXMLWriter, "bcwwpbaseobjects_notifications_common_WWP_Notification", "[*:nosend]AlmangoX");
               }
               if ( bcwwpbaseobjects_notifications_common_WWP_NotificationMessages != null )
               {
                  bcwwpbaseobjects_notifications_common_WWP_NotificationMessages.writexmlcollection(GXSoapXMLWriter, "bcwwpbaseobjects_notifications_common_WWP_NotificationMessages", "[*:nosend]AlmangoX", "Message", "GeneXus");
               }
            }
            else
            {
               GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Fault");
               GXSoapXMLWriter.WriteElement("faultcode", "SOAP-ENV:Client");
               GXSoapXMLWriter.WriteElement("faultstring", currSoapErrmsg);
               GXSoapXMLWriter.WriteElement("detail", StringUtil.Trim( StringUtil.Str( (decimal)(currSoapErr), 10, 0)));
               GXSoapXMLWriter.WriteEndElement();
            }
            GXSoapXMLWriter.WriteEndElement();
            GXSoapXMLWriter.WriteEndElement();
         }
         else if ( ( StringUtil.StringSearch( currMethod+"&", "SaveSvc&", 1) > 0 ) || ( currSoapErr != 0 ) )
         {
            GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Body");
            GXSoapXMLWriter.WriteStartElement("WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.SaveSvcResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
            if ( currSoapErr == 0 )
            {
               if ( bcwwpbaseobjects_notifications_common_WWP_Notification != null )
               {
                  bcwwpbaseobjects_notifications_common_WWP_Notification.writexml(GXSoapXMLWriter, "bcwwpbaseobjects_notifications_common_WWP_Notification", "[*:nosend]AlmangoX");
               }
               if ( bcwwpbaseobjects_notifications_common_WWP_NotificationMessages != null )
               {
                  bcwwpbaseobjects_notifications_common_WWP_NotificationMessages.writexmlcollection(GXSoapXMLWriter, "bcwwpbaseobjects_notifications_common_WWP_NotificationMessages", "[*:nosend]AlmangoX", "Message", "GeneXus");
               }
            }
            else
            {
               GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Fault");
               GXSoapXMLWriter.WriteElement("faultcode", "SOAP-ENV:Client");
               GXSoapXMLWriter.WriteElement("faultstring", currSoapErrmsg);
               GXSoapXMLWriter.WriteElement("detail", StringUtil.Trim( StringUtil.Str( (decimal)(currSoapErr), 10, 0)));
               GXSoapXMLWriter.WriteEndElement();
            }
            GXSoapXMLWriter.WriteEndElement();
            GXSoapXMLWriter.WriteEndElement();
         }
         else if ( ( StringUtil.StringSearch( currMethod+"&", "CheckSvc&", 1) > 0 ) || ( currSoapErr != 0 ) )
         {
            GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Body");
            GXSoapXMLWriter.WriteStartElement("WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.CheckSvcResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
            if ( currSoapErr == 0 )
            {
               if ( bcwwpbaseobjects_notifications_common_WWP_Notification != null )
               {
                  bcwwpbaseobjects_notifications_common_WWP_Notification.writexml(GXSoapXMLWriter, "bcwwpbaseobjects_notifications_common_WWP_Notification", "[*:nosend]AlmangoX");
               }
               if ( bcwwpbaseobjects_notifications_common_WWP_NotificationMessages != null )
               {
                  bcwwpbaseobjects_notifications_common_WWP_NotificationMessages.writexmlcollection(GXSoapXMLWriter, "bcwwpbaseobjects_notifications_common_WWP_NotificationMessages", "[*:nosend]AlmangoX", "Message", "GeneXus");
               }
            }
            else
            {
               GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Fault");
               GXSoapXMLWriter.WriteElement("faultcode", "SOAP-ENV:Client");
               GXSoapXMLWriter.WriteElement("faultstring", currSoapErrmsg);
               GXSoapXMLWriter.WriteElement("detail", StringUtil.Trim( StringUtil.Str( (decimal)(currSoapErr), 10, 0)));
               GXSoapXMLWriter.WriteEndElement();
            }
            GXSoapXMLWriter.WriteEndElement();
            GXSoapXMLWriter.WriteEndElement();
         }
         else if ( ( StringUtil.StringSearch( currMethod+"&", "DeleteSvc&", 1) > 0 ) || ( currSoapErr != 0 ) )
         {
            GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Body");
            GXSoapXMLWriter.WriteStartElement("WWPBaseObjects.Notifications.Common.WWP_Notification_BCBC.DeleteSvcResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
            if ( currSoapErr == 0 )
            {
               if ( bcwwpbaseobjects_notifications_common_WWP_Notification != null )
               {
                  bcwwpbaseobjects_notifications_common_WWP_Notification.writexml(GXSoapXMLWriter, "bcwwpbaseobjects_notifications_common_WWP_Notification", "[*:nosend]AlmangoX");
               }
               if ( bcwwpbaseobjects_notifications_common_WWP_NotificationMessages != null )
               {
                  bcwwpbaseobjects_notifications_common_WWP_NotificationMessages.writexmlcollection(GXSoapXMLWriter, "bcwwpbaseobjects_notifications_common_WWP_NotificationMessages", "[*:nosend]AlmangoX", "Message", "GeneXus");
               }
            }
            else
            {
               GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Fault");
               GXSoapXMLWriter.WriteElement("faultcode", "SOAP-ENV:Client");
               GXSoapXMLWriter.WriteElement("faultstring", currSoapErrmsg);
               GXSoapXMLWriter.WriteElement("detail", StringUtil.Trim( StringUtil.Str( (decimal)(currSoapErr), 10, 0)));
               GXSoapXMLWriter.WriteEndElement();
            }
            GXSoapXMLWriter.WriteEndElement();
            GXSoapXMLWriter.WriteEndElement();
         }
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.Close();
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
         pr_default.close(9);
         pr_default.close(10);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z85WWPNotificationIcon = "";
         A85WWPNotificationIcon = "";
         Z86WWPNotificationTitle = "";
         A86WWPNotificationTitle = "";
         Z87WWPNotificationShortDescriptio = "";
         A87WWPNotificationShortDescriptio = "";
         Z88WWPNotificationLink = "";
         A88WWPNotificationLink = "";
         Z1WWPUserExtendedId = "";
         A1WWPUserExtendedId = "";
         Z68WWPNotificationDefinitionName = "";
         A68WWPNotificationDefinitionName = "";
         Z2WWPUserExtendedFullName = "";
         A2WWPUserExtendedFullName = "";
         Z69WWPNotificationMetadata = "";
         A69WWPNotificationMetadata = "";
         BC000E6_A31WWPNotificationId = new long[1] ;
         BC000E6_n31WWPNotificationId = new bool[] {false} ;
         BC000E6_A68WWPNotificationDefinitionName = new string[] {""} ;
         BC000E6_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000E6_A85WWPNotificationIcon = new string[] {""} ;
         BC000E6_A86WWPNotificationTitle = new string[] {""} ;
         BC000E6_A87WWPNotificationShortDescriptio = new string[] {""} ;
         BC000E6_A88WWPNotificationLink = new string[] {""} ;
         BC000E6_A91WWPNotificationIsRead = new bool[] {false} ;
         BC000E6_A2WWPUserExtendedFullName = new string[] {""} ;
         BC000E6_A69WWPNotificationMetadata = new string[] {""} ;
         BC000E6_n69WWPNotificationMetadata = new bool[] {false} ;
         BC000E6_A32WWPNotificationDefinitionId = new long[1] ;
         BC000E6_A1WWPUserExtendedId = new string[] {""} ;
         BC000E6_n1WWPUserExtendedId = new bool[] {false} ;
         BC000E4_A68WWPNotificationDefinitionName = new string[] {""} ;
         BC000E5_A2WWPUserExtendedFullName = new string[] {""} ;
         BC000E7_A31WWPNotificationId = new long[1] ;
         BC000E7_n31WWPNotificationId = new bool[] {false} ;
         BC000E3_A31WWPNotificationId = new long[1] ;
         BC000E3_n31WWPNotificationId = new bool[] {false} ;
         BC000E3_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000E3_A85WWPNotificationIcon = new string[] {""} ;
         BC000E3_A86WWPNotificationTitle = new string[] {""} ;
         BC000E3_A87WWPNotificationShortDescriptio = new string[] {""} ;
         BC000E3_A88WWPNotificationLink = new string[] {""} ;
         BC000E3_A91WWPNotificationIsRead = new bool[] {false} ;
         BC000E3_A69WWPNotificationMetadata = new string[] {""} ;
         BC000E3_n69WWPNotificationMetadata = new bool[] {false} ;
         BC000E3_A32WWPNotificationDefinitionId = new long[1] ;
         BC000E3_A1WWPUserExtendedId = new string[] {""} ;
         BC000E3_n1WWPUserExtendedId = new bool[] {false} ;
         sMode15 = "";
         BC000E2_A31WWPNotificationId = new long[1] ;
         BC000E2_n31WWPNotificationId = new bool[] {false} ;
         BC000E2_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000E2_A85WWPNotificationIcon = new string[] {""} ;
         BC000E2_A86WWPNotificationTitle = new string[] {""} ;
         BC000E2_A87WWPNotificationShortDescriptio = new string[] {""} ;
         BC000E2_A88WWPNotificationLink = new string[] {""} ;
         BC000E2_A91WWPNotificationIsRead = new bool[] {false} ;
         BC000E2_A69WWPNotificationMetadata = new string[] {""} ;
         BC000E2_n69WWPNotificationMetadata = new bool[] {false} ;
         BC000E2_A32WWPNotificationDefinitionId = new long[1] ;
         BC000E2_A1WWPUserExtendedId = new string[] {""} ;
         BC000E2_n1WWPUserExtendedId = new bool[] {false} ;
         BC000E8_A31WWPNotificationId = new long[1] ;
         BC000E8_n31WWPNotificationId = new bool[] {false} ;
         BC000E11_A68WWPNotificationDefinitionName = new string[] {""} ;
         BC000E12_A2WWPUserExtendedFullName = new string[] {""} ;
         BC000E13_A89WWPMailId = new long[1] ;
         BC000E14_A56WWPWebNotificationId = new long[1] ;
         BC000E15_A42WWPSMSId = new long[1] ;
         BC000E16_A31WWPNotificationId = new long[1] ;
         BC000E16_n31WWPNotificationId = new bool[] {false} ;
         BC000E16_A68WWPNotificationDefinitionName = new string[] {""} ;
         BC000E16_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000E16_A85WWPNotificationIcon = new string[] {""} ;
         BC000E16_A86WWPNotificationTitle = new string[] {""} ;
         BC000E16_A87WWPNotificationShortDescriptio = new string[] {""} ;
         BC000E16_A88WWPNotificationLink = new string[] {""} ;
         BC000E16_A91WWPNotificationIsRead = new bool[] {false} ;
         BC000E16_A2WWPUserExtendedFullName = new string[] {""} ;
         BC000E16_A69WWPNotificationMetadata = new string[] {""} ;
         BC000E16_n69WWPNotificationMetadata = new bool[] {false} ;
         BC000E16_A32WWPNotificationDefinitionId = new long[1] ;
         BC000E16_A1WWPUserExtendedId = new string[] {""} ;
         BC000E16_n1WWPUserExtendedId = new bool[] {false} ;
         i33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         currSoapErrmsg = "";
         currMethod = "";
         sTagName = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification_bc__default(),
            new Object[][] {
                new Object[] {
               BC000E2_A31WWPNotificationId, BC000E2_A33WWPNotificationCreated, BC000E2_A85WWPNotificationIcon, BC000E2_A86WWPNotificationTitle, BC000E2_A87WWPNotificationShortDescriptio, BC000E2_A88WWPNotificationLink, BC000E2_A91WWPNotificationIsRead, BC000E2_A69WWPNotificationMetadata, BC000E2_n69WWPNotificationMetadata, BC000E2_A32WWPNotificationDefinitionId,
               BC000E2_A1WWPUserExtendedId, BC000E2_n1WWPUserExtendedId
               }
               , new Object[] {
               BC000E3_A31WWPNotificationId, BC000E3_A33WWPNotificationCreated, BC000E3_A85WWPNotificationIcon, BC000E3_A86WWPNotificationTitle, BC000E3_A87WWPNotificationShortDescriptio, BC000E3_A88WWPNotificationLink, BC000E3_A91WWPNotificationIsRead, BC000E3_A69WWPNotificationMetadata, BC000E3_n69WWPNotificationMetadata, BC000E3_A32WWPNotificationDefinitionId,
               BC000E3_A1WWPUserExtendedId, BC000E3_n1WWPUserExtendedId
               }
               , new Object[] {
               BC000E4_A68WWPNotificationDefinitionName
               }
               , new Object[] {
               BC000E5_A2WWPUserExtendedFullName
               }
               , new Object[] {
               BC000E6_A31WWPNotificationId, BC000E6_A68WWPNotificationDefinitionName, BC000E6_A33WWPNotificationCreated, BC000E6_A85WWPNotificationIcon, BC000E6_A86WWPNotificationTitle, BC000E6_A87WWPNotificationShortDescriptio, BC000E6_A88WWPNotificationLink, BC000E6_A91WWPNotificationIsRead, BC000E6_A2WWPUserExtendedFullName, BC000E6_A69WWPNotificationMetadata,
               BC000E6_n69WWPNotificationMetadata, BC000E6_A32WWPNotificationDefinitionId, BC000E6_A1WWPUserExtendedId, BC000E6_n1WWPUserExtendedId
               }
               , new Object[] {
               BC000E7_A31WWPNotificationId
               }
               , new Object[] {
               BC000E8_A31WWPNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000E11_A68WWPNotificationDefinitionName
               }
               , new Object[] {
               BC000E12_A2WWPUserExtendedFullName
               }
               , new Object[] {
               BC000E13_A89WWPMailId
               }
               , new Object[] {
               BC000E14_A56WWPWebNotificationId
               }
               , new Object[] {
               BC000E15_A42WWPSMSId
               }
               , new Object[] {
               BC000E16_A31WWPNotificationId, BC000E16_A68WWPNotificationDefinitionName, BC000E16_A33WWPNotificationCreated, BC000E16_A85WWPNotificationIcon, BC000E16_A86WWPNotificationTitle, BC000E16_A87WWPNotificationShortDescriptio, BC000E16_A88WWPNotificationLink, BC000E16_A91WWPNotificationIsRead, BC000E16_A2WWPUserExtendedFullName, BC000E16_A69WWPNotificationMetadata,
               BC000E16_n69WWPNotificationMetadata, BC000E16_A32WWPNotificationDefinitionId, BC000E16_A1WWPUserExtendedId, BC000E16_n1WWPUserExtendedId
               }
            }
         );
         Z33WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A33WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i33WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound15 ;
      private short currSoapErr ;
      private short readOk ;
      private short nOutParmCount ;
      private int trnEnded ;
      private long Z31WWPNotificationId ;
      private long A31WWPNotificationId ;
      private long Z32WWPNotificationDefinitionId ;
      private long A32WWPNotificationDefinitionId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1WWPUserExtendedId ;
      private string A1WWPUserExtendedId ;
      private string sMode15 ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private DateTime Z33WWPNotificationCreated ;
      private DateTime A33WWPNotificationCreated ;
      private DateTime i33WWPNotificationCreated ;
      private bool Z91WWPNotificationIsRead ;
      private bool A91WWPNotificationIsRead ;
      private bool n31WWPNotificationId ;
      private bool n69WWPNotificationMetadata ;
      private bool n1WWPUserExtendedId ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private string Z69WWPNotificationMetadata ;
      private string A69WWPNotificationMetadata ;
      private string Z85WWPNotificationIcon ;
      private string A85WWPNotificationIcon ;
      private string Z86WWPNotificationTitle ;
      private string A86WWPNotificationTitle ;
      private string Z87WWPNotificationShortDescriptio ;
      private string A87WWPNotificationShortDescriptio ;
      private string Z88WWPNotificationLink ;
      private string A88WWPNotificationLink ;
      private string Z68WWPNotificationDefinitionName ;
      private string A68WWPNotificationDefinitionName ;
      private string Z2WWPUserExtendedFullName ;
      private string A2WWPUserExtendedFullName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000E6_A31WWPNotificationId ;
      private bool[] BC000E6_n31WWPNotificationId ;
      private string[] BC000E6_A68WWPNotificationDefinitionName ;
      private DateTime[] BC000E6_A33WWPNotificationCreated ;
      private string[] BC000E6_A85WWPNotificationIcon ;
      private string[] BC000E6_A86WWPNotificationTitle ;
      private string[] BC000E6_A87WWPNotificationShortDescriptio ;
      private string[] BC000E6_A88WWPNotificationLink ;
      private bool[] BC000E6_A91WWPNotificationIsRead ;
      private string[] BC000E6_A2WWPUserExtendedFullName ;
      private string[] BC000E6_A69WWPNotificationMetadata ;
      private bool[] BC000E6_n69WWPNotificationMetadata ;
      private long[] BC000E6_A32WWPNotificationDefinitionId ;
      private string[] BC000E6_A1WWPUserExtendedId ;
      private bool[] BC000E6_n1WWPUserExtendedId ;
      private string[] BC000E4_A68WWPNotificationDefinitionName ;
      private string[] BC000E5_A2WWPUserExtendedFullName ;
      private long[] BC000E7_A31WWPNotificationId ;
      private bool[] BC000E7_n31WWPNotificationId ;
      private long[] BC000E3_A31WWPNotificationId ;
      private bool[] BC000E3_n31WWPNotificationId ;
      private DateTime[] BC000E3_A33WWPNotificationCreated ;
      private string[] BC000E3_A85WWPNotificationIcon ;
      private string[] BC000E3_A86WWPNotificationTitle ;
      private string[] BC000E3_A87WWPNotificationShortDescriptio ;
      private string[] BC000E3_A88WWPNotificationLink ;
      private bool[] BC000E3_A91WWPNotificationIsRead ;
      private string[] BC000E3_A69WWPNotificationMetadata ;
      private bool[] BC000E3_n69WWPNotificationMetadata ;
      private long[] BC000E3_A32WWPNotificationDefinitionId ;
      private string[] BC000E3_A1WWPUserExtendedId ;
      private bool[] BC000E3_n1WWPUserExtendedId ;
      private long[] BC000E2_A31WWPNotificationId ;
      private bool[] BC000E2_n31WWPNotificationId ;
      private DateTime[] BC000E2_A33WWPNotificationCreated ;
      private string[] BC000E2_A85WWPNotificationIcon ;
      private string[] BC000E2_A86WWPNotificationTitle ;
      private string[] BC000E2_A87WWPNotificationShortDescriptio ;
      private string[] BC000E2_A88WWPNotificationLink ;
      private bool[] BC000E2_A91WWPNotificationIsRead ;
      private string[] BC000E2_A69WWPNotificationMetadata ;
      private bool[] BC000E2_n69WWPNotificationMetadata ;
      private long[] BC000E2_A32WWPNotificationDefinitionId ;
      private string[] BC000E2_A1WWPUserExtendedId ;
      private bool[] BC000E2_n1WWPUserExtendedId ;
      private long[] BC000E8_A31WWPNotificationId ;
      private bool[] BC000E8_n31WWPNotificationId ;
      private string[] BC000E11_A68WWPNotificationDefinitionName ;
      private string[] BC000E12_A2WWPUserExtendedFullName ;
      private long[] BC000E13_A89WWPMailId ;
      private long[] BC000E14_A56WWPWebNotificationId ;
      private long[] BC000E15_A42WWPSMSId ;
      private long[] BC000E16_A31WWPNotificationId ;
      private bool[] BC000E16_n31WWPNotificationId ;
      private string[] BC000E16_A68WWPNotificationDefinitionName ;
      private DateTime[] BC000E16_A33WWPNotificationCreated ;
      private string[] BC000E16_A85WWPNotificationIcon ;
      private string[] BC000E16_A86WWPNotificationTitle ;
      private string[] BC000E16_A87WWPNotificationShortDescriptio ;
      private string[] BC000E16_A88WWPNotificationLink ;
      private bool[] BC000E16_A91WWPNotificationIsRead ;
      private string[] BC000E16_A2WWPUserExtendedFullName ;
      private string[] BC000E16_A69WWPNotificationMetadata ;
      private bool[] BC000E16_n69WWPNotificationMetadata ;
      private long[] BC000E16_A32WWPNotificationDefinitionId ;
      private string[] BC000E16_A1WWPUserExtendedId ;
      private bool[] BC000E16_n1WWPUserExtendedId ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification bcwwpbaseobjects_notifications_common_WWP_Notification=null ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> bcwwpbaseobjects_notifications_common_WWP_NotificationMessages ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_notification_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notification_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000E2;
        prmBC000E2 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000E3;
        prmBC000E3 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000E4;
        prmBC000E4 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmBC000E5;
        prmBC000E5 = new Object[] {
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
        };
        Object[] prmBC000E6;
        prmBC000E6 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000E7;
        prmBC000E7 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000E8;
        prmBC000E8 = new Object[] {
        new ParDef("@WWPNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("@WWPNotificationIcon",GXType.NVarChar,100,0) ,
        new ParDef("@WWPNotificationTitle",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationShortDescriptio",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationLink",GXType.NVarChar,1000,0) ,
        new ParDef("@WWPNotificationIsRead",GXType.Boolean,4,0) ,
        new ParDef("@WWPNotificationMetadata",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0) ,
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
        };
        Object[] prmBC000E9;
        prmBC000E9 = new Object[] {
        new ParDef("@WWPNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("@WWPNotificationIcon",GXType.NVarChar,100,0) ,
        new ParDef("@WWPNotificationTitle",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationShortDescriptio",GXType.NVarChar,200,0) ,
        new ParDef("@WWPNotificationLink",GXType.NVarChar,1000,0) ,
        new ParDef("@WWPNotificationIsRead",GXType.Boolean,4,0) ,
        new ParDef("@WWPNotificationMetadata",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0) ,
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true} ,
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000E10;
        prmBC000E10 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000E11;
        prmBC000E11 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmBC000E12;
        prmBC000E12 = new Object[] {
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
        };
        Object[] prmBC000E13;
        prmBC000E13 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000E14;
        prmBC000E14 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000E15;
        prmBC000E15 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000E16;
        prmBC000E16 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC000E2", "SELECT [WWPNotificationId], [WWPNotificationCreated], [WWPNotificationIcon], [WWPNotificationTitle], [WWPNotificationShortDescriptio], [WWPNotificationLink], [WWPNotificationIsRead], [WWPNotificationMetadata], [WWPNotificationDefinitionId], [WWPUserExtendedId] FROM [WWP_Notification] WITH (UPDLOCK) WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E3", "SELECT [WWPNotificationId], [WWPNotificationCreated], [WWPNotificationIcon], [WWPNotificationTitle], [WWPNotificationShortDescriptio], [WWPNotificationLink], [WWPNotificationIsRead], [WWPNotificationMetadata], [WWPNotificationDefinitionId], [WWPUserExtendedId] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E4", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E5", "SELECT [WWPUserExtendedFullName] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E6", "SELECT TM1.[WWPNotificationId], T2.[WWPNotificationDefinitionName], TM1.[WWPNotificationCreated], TM1.[WWPNotificationIcon], TM1.[WWPNotificationTitle], TM1.[WWPNotificationShortDescriptio], TM1.[WWPNotificationLink], TM1.[WWPNotificationIsRead], T3.[WWPUserExtendedFullName], TM1.[WWPNotificationMetadata], TM1.[WWPNotificationDefinitionId], TM1.[WWPUserExtendedId] FROM (([WWP_Notification] TM1 INNER JOIN [WWP_NotificationDefinition] T2 ON T2.[WWPNotificationDefinitionId] = TM1.[WWPNotificationDefinitionId]) LEFT JOIN [WWP_UserExtended] T3 ON T3.[WWPUserExtendedId] = TM1.[WWPUserExtendedId]) WHERE TM1.[WWPNotificationId] = @WWPNotificationId ORDER BY TM1.[WWPNotificationId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E7", "SELECT [WWPNotificationId] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E8", "INSERT INTO [WWP_Notification]([WWPNotificationCreated], [WWPNotificationIcon], [WWPNotificationTitle], [WWPNotificationShortDescriptio], [WWPNotificationLink], [WWPNotificationIsRead], [WWPNotificationMetadata], [WWPNotificationDefinitionId], [WWPUserExtendedId]) VALUES(@WWPNotificationCreated, @WWPNotificationIcon, @WWPNotificationTitle, @WWPNotificationShortDescriptio, @WWPNotificationLink, @WWPNotificationIsRead, @WWPNotificationMetadata, @WWPNotificationDefinitionId, @WWPUserExtendedId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000E9", "UPDATE [WWP_Notification] SET [WWPNotificationCreated]=@WWPNotificationCreated, [WWPNotificationIcon]=@WWPNotificationIcon, [WWPNotificationTitle]=@WWPNotificationTitle, [WWPNotificationShortDescriptio]=@WWPNotificationShortDescriptio, [WWPNotificationLink]=@WWPNotificationLink, [WWPNotificationIsRead]=@WWPNotificationIsRead, [WWPNotificationMetadata]=@WWPNotificationMetadata, [WWPNotificationDefinitionId]=@WWPNotificationDefinitionId, [WWPUserExtendedId]=@WWPUserExtendedId  WHERE [WWPNotificationId] = @WWPNotificationId", GxErrorMask.GX_NOMASK,prmBC000E9)
           ,new CursorDef("BC000E10", "DELETE FROM [WWP_Notification]  WHERE [WWPNotificationId] = @WWPNotificationId", GxErrorMask.GX_NOMASK,prmBC000E10)
           ,new CursorDef("BC000E11", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E12", "SELECT [WWPUserExtendedFullName] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E13", "SELECT TOP 1 [WWPMailId] FROM [WWP_Mail] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000E14", "SELECT TOP 1 [WWPWebNotificationId] FROM [WWP_WebNotification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000E15", "SELECT TOP 1 [WWPSMSId] FROM [WWP_SMS] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000E16", "SELECT TM1.[WWPNotificationId], T2.[WWPNotificationDefinitionName], TM1.[WWPNotificationCreated], TM1.[WWPNotificationIcon], TM1.[WWPNotificationTitle], TM1.[WWPNotificationShortDescriptio], TM1.[WWPNotificationLink], TM1.[WWPNotificationIsRead], T3.[WWPUserExtendedFullName], TM1.[WWPNotificationMetadata], TM1.[WWPNotificationDefinitionId], TM1.[WWPUserExtendedId] FROM (([WWP_Notification] TM1 INNER JOIN [WWP_NotificationDefinition] T2 ON T2.[WWPNotificationDefinitionId] = TM1.[WWPNotificationDefinitionId]) LEFT JOIN [WWP_UserExtended] T3 ON T3.[WWPUserExtendedId] = TM1.[WWPUserExtendedId]) WHERE TM1.[WWPNotificationId] = @WWPNotificationId ORDER BY TM1.[WWPNotificationId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E16,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((long[]) buf[9])[0] = rslt.getLong(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 40);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((long[]) buf[9])[0] = rslt.getLong(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 40);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((long[]) buf[11])[0] = rslt.getLong(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(12);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((long[]) buf[11])[0] = rslt.getLong(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(12);
              return;
     }
  }

}

}
