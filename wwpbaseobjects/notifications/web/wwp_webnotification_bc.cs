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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_webnotification_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_webnotification_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_webnotification_bc( IGxContext context )
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
         ReadRow0B12( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0B12( ) ;
         standaloneModal( ) ;
         AddRow0B12( ) ;
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
               Z56WWPWebNotificationId = A56WWPWebNotificationId;
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

      protected void CONFIRM_0B0( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0B12( ) ;
            }
            else
            {
               CheckExtendedTable0B12( ) ;
               if ( AnyError == 0 )
               {
                  ZM0B12( 10) ;
                  ZM0B12( 11) ;
               }
               CloseExtendedTableCursors0B12( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0B12( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z51WWPWebNotificationTitle = A51WWPWebNotificationTitle;
            Z52WWPWebNotificationText = A52WWPWebNotificationText;
            Z53WWPWebNotificationIcon = A53WWPWebNotificationIcon;
            Z63WWPWebNotificationStatus = A63WWPWebNotificationStatus;
            Z54WWPWebNotificationCreated = A54WWPWebNotificationCreated;
            Z67WWPWebNotificationScheduled = A67WWPWebNotificationScheduled;
            Z64WWPWebNotificationProcessed = A64WWPWebNotificationProcessed;
            Z55WWPWebNotificationRead = A55WWPWebNotificationRead;
            Z66WWPWebNotificationReceived = A66WWPWebNotificationReceived;
            Z31WWPNotificationId = A31WWPNotificationId;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
            Z33WWPNotificationCreated = A33WWPNotificationCreated;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z68WWPNotificationDefinitionName = A68WWPNotificationDefinitionName;
         }
         if ( GX_JID == -9 )
         {
            Z56WWPWebNotificationId = A56WWPWebNotificationId;
            Z51WWPWebNotificationTitle = A51WWPWebNotificationTitle;
            Z52WWPWebNotificationText = A52WWPWebNotificationText;
            Z53WWPWebNotificationIcon = A53WWPWebNotificationIcon;
            Z62WWPWebNotificationClientId = A62WWPWebNotificationClientId;
            Z63WWPWebNotificationStatus = A63WWPWebNotificationStatus;
            Z54WWPWebNotificationCreated = A54WWPWebNotificationCreated;
            Z67WWPWebNotificationScheduled = A67WWPWebNotificationScheduled;
            Z64WWPWebNotificationProcessed = A64WWPWebNotificationProcessed;
            Z55WWPWebNotificationRead = A55WWPWebNotificationRead;
            Z65WWPWebNotificationDetail = A65WWPWebNotificationDetail;
            Z66WWPWebNotificationReceived = A66WWPWebNotificationReceived;
            Z31WWPNotificationId = A31WWPNotificationId;
            Z32WWPNotificationDefinitionId = A32WWPNotificationDefinitionId;
            Z33WWPNotificationCreated = A33WWPNotificationCreated;
            Z69WWPNotificationMetadata = A69WWPNotificationMetadata;
            Z68WWPNotificationDefinitionName = A68WWPNotificationDefinitionName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A63WWPWebNotificationStatus) && ( Gx_BScreen == 0 ) )
         {
            A63WWPWebNotificationStatus = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A54WWPWebNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A54WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A67WWPWebNotificationScheduled) && ( Gx_BScreen == 0 ) )
         {
            A67WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0B12( )
      {
         /* Using cursor BC000B6 */
         pr_default.execute(4, new Object[] {A56WWPWebNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound12 = 1;
            A32WWPNotificationDefinitionId = BC000B6_A32WWPNotificationDefinitionId[0];
            A51WWPWebNotificationTitle = BC000B6_A51WWPWebNotificationTitle[0];
            A33WWPNotificationCreated = BC000B6_A33WWPNotificationCreated[0];
            A69WWPNotificationMetadata = BC000B6_A69WWPNotificationMetadata[0];
            n69WWPNotificationMetadata = BC000B6_n69WWPNotificationMetadata[0];
            A68WWPNotificationDefinitionName = BC000B6_A68WWPNotificationDefinitionName[0];
            A52WWPWebNotificationText = BC000B6_A52WWPWebNotificationText[0];
            A53WWPWebNotificationIcon = BC000B6_A53WWPWebNotificationIcon[0];
            A62WWPWebNotificationClientId = BC000B6_A62WWPWebNotificationClientId[0];
            A63WWPWebNotificationStatus = BC000B6_A63WWPWebNotificationStatus[0];
            A54WWPWebNotificationCreated = BC000B6_A54WWPWebNotificationCreated[0];
            A67WWPWebNotificationScheduled = BC000B6_A67WWPWebNotificationScheduled[0];
            A64WWPWebNotificationProcessed = BC000B6_A64WWPWebNotificationProcessed[0];
            A55WWPWebNotificationRead = BC000B6_A55WWPWebNotificationRead[0];
            n55WWPWebNotificationRead = BC000B6_n55WWPWebNotificationRead[0];
            A65WWPWebNotificationDetail = BC000B6_A65WWPWebNotificationDetail[0];
            n65WWPWebNotificationDetail = BC000B6_n65WWPWebNotificationDetail[0];
            A66WWPWebNotificationReceived = BC000B6_A66WWPWebNotificationReceived[0];
            n66WWPWebNotificationReceived = BC000B6_n66WWPWebNotificationReceived[0];
            A31WWPNotificationId = BC000B6_A31WWPNotificationId[0];
            n31WWPNotificationId = BC000B6_n31WWPNotificationId[0];
            ZM0B12( -9) ;
         }
         pr_default.close(4);
         OnLoadActions0B12( ) ;
      }

      protected void OnLoadActions0B12( )
      {
      }

      protected void CheckExtendedTable0B12( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000B4 */
         pr_default.execute(2, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A31WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
            }
         }
         A32WWPNotificationDefinitionId = BC000B4_A32WWPNotificationDefinitionId[0];
         A33WWPNotificationCreated = BC000B4_A33WWPNotificationCreated[0];
         A69WWPNotificationMetadata = BC000B4_A69WWPNotificationMetadata[0];
         n69WWPNotificationMetadata = BC000B4_n69WWPNotificationMetadata[0];
         pr_default.close(2);
         /* Using cursor BC000B5 */
         pr_default.execute(3, new Object[] {A32WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A32WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
            }
         }
         A68WWPNotificationDefinitionName = BC000B5_A68WWPNotificationDefinitionName[0];
         pr_default.close(3);
         if ( ! ( ( A63WWPWebNotificationStatus == 1 ) || ( A63WWPWebNotificationStatus == 2 ) || ( A63WWPWebNotificationStatus == 3 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Web Notification Status", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A54WWPWebNotificationCreated) || ( A54WWPWebNotificationCreated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Web Notification Created", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A67WWPWebNotificationScheduled) || ( A67WWPWebNotificationScheduled >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Web Notification Scheduled", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A64WWPWebNotificationProcessed) || ( A64WWPWebNotificationProcessed >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Web Notification Processed", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A55WWPWebNotificationRead) || ( A55WWPWebNotificationRead >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Web Notification Read", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0B12( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B12( )
      {
         /* Using cursor BC000B7 */
         pr_default.execute(5, new Object[] {A56WWPWebNotificationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000B3 */
         pr_default.execute(1, new Object[] {A56WWPWebNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B12( 9) ;
            RcdFound12 = 1;
            A56WWPWebNotificationId = BC000B3_A56WWPWebNotificationId[0];
            A51WWPWebNotificationTitle = BC000B3_A51WWPWebNotificationTitle[0];
            A52WWPWebNotificationText = BC000B3_A52WWPWebNotificationText[0];
            A53WWPWebNotificationIcon = BC000B3_A53WWPWebNotificationIcon[0];
            A62WWPWebNotificationClientId = BC000B3_A62WWPWebNotificationClientId[0];
            A63WWPWebNotificationStatus = BC000B3_A63WWPWebNotificationStatus[0];
            A54WWPWebNotificationCreated = BC000B3_A54WWPWebNotificationCreated[0];
            A67WWPWebNotificationScheduled = BC000B3_A67WWPWebNotificationScheduled[0];
            A64WWPWebNotificationProcessed = BC000B3_A64WWPWebNotificationProcessed[0];
            A55WWPWebNotificationRead = BC000B3_A55WWPWebNotificationRead[0];
            n55WWPWebNotificationRead = BC000B3_n55WWPWebNotificationRead[0];
            A65WWPWebNotificationDetail = BC000B3_A65WWPWebNotificationDetail[0];
            n65WWPWebNotificationDetail = BC000B3_n65WWPWebNotificationDetail[0];
            A66WWPWebNotificationReceived = BC000B3_A66WWPWebNotificationReceived[0];
            n66WWPWebNotificationReceived = BC000B3_n66WWPWebNotificationReceived[0];
            A31WWPNotificationId = BC000B3_A31WWPNotificationId[0];
            n31WWPNotificationId = BC000B3_n31WWPNotificationId[0];
            Z56WWPWebNotificationId = A56WWPWebNotificationId;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0B12( ) ;
            if ( AnyError == 1 )
            {
               RcdFound12 = 0;
               InitializeNonKey0B12( ) ;
            }
            Gx_mode = sMode12;
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0B12( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode12;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B12( ) ;
         if ( RcdFound12 == 0 )
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
         CONFIRM_0B0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0B12( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000B2 */
            pr_default.execute(0, new Object[] {A56WWPWebNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z51WWPWebNotificationTitle, BC000B2_A51WWPWebNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z52WWPWebNotificationText, BC000B2_A52WWPWebNotificationText[0]) != 0 ) || ( StringUtil.StrCmp(Z53WWPWebNotificationIcon, BC000B2_A53WWPWebNotificationIcon[0]) != 0 ) || ( Z63WWPWebNotificationStatus != BC000B2_A63WWPWebNotificationStatus[0] ) || ( Z54WWPWebNotificationCreated != BC000B2_A54WWPWebNotificationCreated[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z67WWPWebNotificationScheduled != BC000B2_A67WWPWebNotificationScheduled[0] ) || ( Z64WWPWebNotificationProcessed != BC000B2_A64WWPWebNotificationProcessed[0] ) || ( Z55WWPWebNotificationRead != BC000B2_A55WWPWebNotificationRead[0] ) || ( Z66WWPWebNotificationReceived != BC000B2_A66WWPWebNotificationReceived[0] ) || ( Z31WWPNotificationId != BC000B2_A31WWPNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B12( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B12( 0) ;
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B8 */
                     pr_default.execute(6, new Object[] {A51WWPWebNotificationTitle, A52WWPWebNotificationText, A53WWPWebNotificationIcon, A62WWPWebNotificationClientId, A63WWPWebNotificationStatus, A54WWPWebNotificationCreated, A67WWPWebNotificationScheduled, A64WWPWebNotificationProcessed, n55WWPWebNotificationRead, A55WWPWebNotificationRead, n65WWPWebNotificationDetail, A65WWPWebNotificationDetail, n66WWPWebNotificationReceived, A66WWPWebNotificationReceived, n31WWPNotificationId, A31WWPNotificationId});
                     A56WWPWebNotificationId = BC000B8_A56WWPWebNotificationId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
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
               Load0B12( ) ;
            }
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void Update0B12( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B9 */
                     pr_default.execute(7, new Object[] {A51WWPWebNotificationTitle, A52WWPWebNotificationText, A53WWPWebNotificationIcon, A62WWPWebNotificationClientId, A63WWPWebNotificationStatus, A54WWPWebNotificationCreated, A67WWPWebNotificationScheduled, A64WWPWebNotificationProcessed, n55WWPWebNotificationRead, A55WWPWebNotificationRead, n65WWPWebNotificationDetail, A65WWPWebNotificationDetail, n66WWPWebNotificationReceived, A66WWPWebNotificationReceived, n31WWPNotificationId, A31WWPNotificationId, A56WWPWebNotificationId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B12( ) ;
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
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void DeferredUpdate0B12( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B12( ) ;
            AfterConfirm0B12( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B12( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000B10 */
                  pr_default.execute(8, new Object[] {A56WWPWebNotificationId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
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
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0B12( ) ;
         Gx_mode = sMode12;
      }

      protected void OnDeleteControls0B12( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000B11 */
            pr_default.execute(9, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
            A32WWPNotificationDefinitionId = BC000B11_A32WWPNotificationDefinitionId[0];
            A33WWPNotificationCreated = BC000B11_A33WWPNotificationCreated[0];
            A69WWPNotificationMetadata = BC000B11_A69WWPNotificationMetadata[0];
            n69WWPNotificationMetadata = BC000B11_n69WWPNotificationMetadata[0];
            pr_default.close(9);
            /* Using cursor BC000B12 */
            pr_default.execute(10, new Object[] {A32WWPNotificationDefinitionId});
            A68WWPNotificationDefinitionName = BC000B12_A68WWPNotificationDefinitionName[0];
            pr_default.close(10);
         }
      }

      protected void EndLevel0B12( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B12( ) ;
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

      public void ScanKeyStart0B12( )
      {
         /* Using cursor BC000B13 */
         pr_default.execute(11, new Object[] {A56WWPWebNotificationId});
         RcdFound12 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound12 = 1;
            A32WWPNotificationDefinitionId = BC000B13_A32WWPNotificationDefinitionId[0];
            A56WWPWebNotificationId = BC000B13_A56WWPWebNotificationId[0];
            A51WWPWebNotificationTitle = BC000B13_A51WWPWebNotificationTitle[0];
            A33WWPNotificationCreated = BC000B13_A33WWPNotificationCreated[0];
            A69WWPNotificationMetadata = BC000B13_A69WWPNotificationMetadata[0];
            n69WWPNotificationMetadata = BC000B13_n69WWPNotificationMetadata[0];
            A68WWPNotificationDefinitionName = BC000B13_A68WWPNotificationDefinitionName[0];
            A52WWPWebNotificationText = BC000B13_A52WWPWebNotificationText[0];
            A53WWPWebNotificationIcon = BC000B13_A53WWPWebNotificationIcon[0];
            A62WWPWebNotificationClientId = BC000B13_A62WWPWebNotificationClientId[0];
            A63WWPWebNotificationStatus = BC000B13_A63WWPWebNotificationStatus[0];
            A54WWPWebNotificationCreated = BC000B13_A54WWPWebNotificationCreated[0];
            A67WWPWebNotificationScheduled = BC000B13_A67WWPWebNotificationScheduled[0];
            A64WWPWebNotificationProcessed = BC000B13_A64WWPWebNotificationProcessed[0];
            A55WWPWebNotificationRead = BC000B13_A55WWPWebNotificationRead[0];
            n55WWPWebNotificationRead = BC000B13_n55WWPWebNotificationRead[0];
            A65WWPWebNotificationDetail = BC000B13_A65WWPWebNotificationDetail[0];
            n65WWPWebNotificationDetail = BC000B13_n65WWPWebNotificationDetail[0];
            A66WWPWebNotificationReceived = BC000B13_A66WWPWebNotificationReceived[0];
            n66WWPWebNotificationReceived = BC000B13_n66WWPWebNotificationReceived[0];
            A31WWPNotificationId = BC000B13_A31WWPNotificationId[0];
            n31WWPNotificationId = BC000B13_n31WWPNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0B12( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound12 = 0;
         ScanKeyLoad0B12( ) ;
      }

      protected void ScanKeyLoad0B12( )
      {
         sMode12 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound12 = 1;
            A32WWPNotificationDefinitionId = BC000B13_A32WWPNotificationDefinitionId[0];
            A56WWPWebNotificationId = BC000B13_A56WWPWebNotificationId[0];
            A51WWPWebNotificationTitle = BC000B13_A51WWPWebNotificationTitle[0];
            A33WWPNotificationCreated = BC000B13_A33WWPNotificationCreated[0];
            A69WWPNotificationMetadata = BC000B13_A69WWPNotificationMetadata[0];
            n69WWPNotificationMetadata = BC000B13_n69WWPNotificationMetadata[0];
            A68WWPNotificationDefinitionName = BC000B13_A68WWPNotificationDefinitionName[0];
            A52WWPWebNotificationText = BC000B13_A52WWPWebNotificationText[0];
            A53WWPWebNotificationIcon = BC000B13_A53WWPWebNotificationIcon[0];
            A62WWPWebNotificationClientId = BC000B13_A62WWPWebNotificationClientId[0];
            A63WWPWebNotificationStatus = BC000B13_A63WWPWebNotificationStatus[0];
            A54WWPWebNotificationCreated = BC000B13_A54WWPWebNotificationCreated[0];
            A67WWPWebNotificationScheduled = BC000B13_A67WWPWebNotificationScheduled[0];
            A64WWPWebNotificationProcessed = BC000B13_A64WWPWebNotificationProcessed[0];
            A55WWPWebNotificationRead = BC000B13_A55WWPWebNotificationRead[0];
            n55WWPWebNotificationRead = BC000B13_n55WWPWebNotificationRead[0];
            A65WWPWebNotificationDetail = BC000B13_A65WWPWebNotificationDetail[0];
            n65WWPWebNotificationDetail = BC000B13_n65WWPWebNotificationDetail[0];
            A66WWPWebNotificationReceived = BC000B13_A66WWPWebNotificationReceived[0];
            n66WWPWebNotificationReceived = BC000B13_n66WWPWebNotificationReceived[0];
            A31WWPNotificationId = BC000B13_A31WWPNotificationId[0];
            n31WWPNotificationId = BC000B13_n31WWPNotificationId[0];
         }
         Gx_mode = sMode12;
      }

      protected void ScanKeyEnd0B12( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0B12( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B12( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B12( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B12( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B12( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B12( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B12( )
      {
      }

      protected void send_integrity_lvl_hashes0B12( )
      {
      }

      protected void AddRow0B12( )
      {
         VarsToRow12( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
      }

      protected void ReadRow0B12( )
      {
         RowToVars12( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
      }

      protected void InitializeNonKey0B12( )
      {
         A32WWPNotificationDefinitionId = 0;
         A51WWPWebNotificationTitle = "";
         A31WWPNotificationId = 0;
         n31WWPNotificationId = false;
         A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A69WWPNotificationMetadata = "";
         n69WWPNotificationMetadata = false;
         A68WWPNotificationDefinitionName = "";
         A52WWPWebNotificationText = "";
         A53WWPWebNotificationIcon = "";
         A62WWPWebNotificationClientId = "";
         A64WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         A55WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         n55WWPWebNotificationRead = false;
         A65WWPWebNotificationDetail = "";
         n65WWPWebNotificationDetail = false;
         A66WWPWebNotificationReceived = false;
         n66WWPWebNotificationReceived = false;
         A63WWPWebNotificationStatus = 1;
         A54WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A67WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z51WWPWebNotificationTitle = "";
         Z52WWPWebNotificationText = "";
         Z53WWPWebNotificationIcon = "";
         Z63WWPWebNotificationStatus = 0;
         Z54WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z67WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z64WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z55WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         Z66WWPWebNotificationReceived = false;
         Z31WWPNotificationId = 0;
      }

      protected void InitAll0B12( )
      {
         A56WWPWebNotificationId = 0;
         InitializeNonKey0B12( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A63WWPWebNotificationStatus = i63WWPWebNotificationStatus;
         A54WWPWebNotificationCreated = i54WWPWebNotificationCreated;
         A67WWPWebNotificationScheduled = i67WWPWebNotificationScheduled;
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

      public void VarsToRow12( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification obj12 )
      {
         obj12.gxTpr_Mode = Gx_mode;
         obj12.gxTpr_Wwpwebnotificationtitle = A51WWPWebNotificationTitle;
         obj12.gxTpr_Wwpnotificationid = A31WWPNotificationId;
         obj12.gxTpr_Wwpnotificationcreated = A33WWPNotificationCreated;
         obj12.gxTpr_Wwpnotificationmetadata = A69WWPNotificationMetadata;
         obj12.gxTpr_Wwpnotificationdefinitionname = A68WWPNotificationDefinitionName;
         obj12.gxTpr_Wwpwebnotificationtext = A52WWPWebNotificationText;
         obj12.gxTpr_Wwpwebnotificationicon = A53WWPWebNotificationIcon;
         obj12.gxTpr_Wwpwebnotificationclientid = A62WWPWebNotificationClientId;
         obj12.gxTpr_Wwpwebnotificationprocessed = A64WWPWebNotificationProcessed;
         obj12.gxTpr_Wwpwebnotificationread = A55WWPWebNotificationRead;
         obj12.gxTpr_Wwpwebnotificationdetail = A65WWPWebNotificationDetail;
         obj12.gxTpr_Wwpwebnotificationreceived = A66WWPWebNotificationReceived;
         obj12.gxTpr_Wwpwebnotificationstatus = A63WWPWebNotificationStatus;
         obj12.gxTpr_Wwpwebnotificationcreated = A54WWPWebNotificationCreated;
         obj12.gxTpr_Wwpwebnotificationscheduled = A67WWPWebNotificationScheduled;
         obj12.gxTpr_Wwpwebnotificationid = A56WWPWebNotificationId;
         obj12.gxTpr_Wwpwebnotificationid_Z = Z56WWPWebNotificationId;
         obj12.gxTpr_Wwpwebnotificationtitle_Z = Z51WWPWebNotificationTitle;
         obj12.gxTpr_Wwpnotificationid_Z = Z31WWPNotificationId;
         obj12.gxTpr_Wwpnotificationcreated_Z = Z33WWPNotificationCreated;
         obj12.gxTpr_Wwpnotificationdefinitionname_Z = Z68WWPNotificationDefinitionName;
         obj12.gxTpr_Wwpwebnotificationtext_Z = Z52WWPWebNotificationText;
         obj12.gxTpr_Wwpwebnotificationicon_Z = Z53WWPWebNotificationIcon;
         obj12.gxTpr_Wwpwebnotificationstatus_Z = Z63WWPWebNotificationStatus;
         obj12.gxTpr_Wwpwebnotificationcreated_Z = Z54WWPWebNotificationCreated;
         obj12.gxTpr_Wwpwebnotificationscheduled_Z = Z67WWPWebNotificationScheduled;
         obj12.gxTpr_Wwpwebnotificationprocessed_Z = Z64WWPWebNotificationProcessed;
         obj12.gxTpr_Wwpwebnotificationread_Z = Z55WWPWebNotificationRead;
         obj12.gxTpr_Wwpwebnotificationreceived_Z = Z66WWPWebNotificationReceived;
         obj12.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n31WWPNotificationId));
         obj12.gxTpr_Wwpnotificationmetadata_N = (short)(Convert.ToInt16(n69WWPNotificationMetadata));
         obj12.gxTpr_Wwpwebnotificationread_N = (short)(Convert.ToInt16(n55WWPWebNotificationRead));
         obj12.gxTpr_Wwpwebnotificationdetail_N = (short)(Convert.ToInt16(n65WWPWebNotificationDetail));
         obj12.gxTpr_Wwpwebnotificationreceived_N = (short)(Convert.ToInt16(n66WWPWebNotificationReceived));
         obj12.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow12( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification obj12 )
      {
         obj12.gxTpr_Wwpwebnotificationid = A56WWPWebNotificationId;
         return  ;
      }

      public void RowToVars12( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification obj12 ,
                               int forceLoad )
      {
         Gx_mode = obj12.gxTpr_Mode;
         A51WWPWebNotificationTitle = obj12.gxTpr_Wwpwebnotificationtitle;
         A31WWPNotificationId = obj12.gxTpr_Wwpnotificationid;
         n31WWPNotificationId = false;
         A33WWPNotificationCreated = obj12.gxTpr_Wwpnotificationcreated;
         A69WWPNotificationMetadata = obj12.gxTpr_Wwpnotificationmetadata;
         n69WWPNotificationMetadata = false;
         A68WWPNotificationDefinitionName = obj12.gxTpr_Wwpnotificationdefinitionname;
         A52WWPWebNotificationText = obj12.gxTpr_Wwpwebnotificationtext;
         A53WWPWebNotificationIcon = obj12.gxTpr_Wwpwebnotificationicon;
         A62WWPWebNotificationClientId = obj12.gxTpr_Wwpwebnotificationclientid;
         A64WWPWebNotificationProcessed = obj12.gxTpr_Wwpwebnotificationprocessed;
         A55WWPWebNotificationRead = obj12.gxTpr_Wwpwebnotificationread;
         n55WWPWebNotificationRead = false;
         A65WWPWebNotificationDetail = obj12.gxTpr_Wwpwebnotificationdetail;
         n65WWPWebNotificationDetail = false;
         A66WWPWebNotificationReceived = obj12.gxTpr_Wwpwebnotificationreceived;
         n66WWPWebNotificationReceived = false;
         A63WWPWebNotificationStatus = obj12.gxTpr_Wwpwebnotificationstatus;
         A54WWPWebNotificationCreated = obj12.gxTpr_Wwpwebnotificationcreated;
         A67WWPWebNotificationScheduled = obj12.gxTpr_Wwpwebnotificationscheduled;
         A56WWPWebNotificationId = obj12.gxTpr_Wwpwebnotificationid;
         Z56WWPWebNotificationId = obj12.gxTpr_Wwpwebnotificationid_Z;
         Z51WWPWebNotificationTitle = obj12.gxTpr_Wwpwebnotificationtitle_Z;
         Z31WWPNotificationId = obj12.gxTpr_Wwpnotificationid_Z;
         Z33WWPNotificationCreated = obj12.gxTpr_Wwpnotificationcreated_Z;
         Z68WWPNotificationDefinitionName = obj12.gxTpr_Wwpnotificationdefinitionname_Z;
         Z52WWPWebNotificationText = obj12.gxTpr_Wwpwebnotificationtext_Z;
         Z53WWPWebNotificationIcon = obj12.gxTpr_Wwpwebnotificationicon_Z;
         Z63WWPWebNotificationStatus = obj12.gxTpr_Wwpwebnotificationstatus_Z;
         Z54WWPWebNotificationCreated = obj12.gxTpr_Wwpwebnotificationcreated_Z;
         Z67WWPWebNotificationScheduled = obj12.gxTpr_Wwpwebnotificationscheduled_Z;
         Z64WWPWebNotificationProcessed = obj12.gxTpr_Wwpwebnotificationprocessed_Z;
         Z55WWPWebNotificationRead = obj12.gxTpr_Wwpwebnotificationread_Z;
         Z66WWPWebNotificationReceived = obj12.gxTpr_Wwpwebnotificationreceived_Z;
         n31WWPNotificationId = (bool)(Convert.ToBoolean(obj12.gxTpr_Wwpnotificationid_N));
         n69WWPNotificationMetadata = (bool)(Convert.ToBoolean(obj12.gxTpr_Wwpnotificationmetadata_N));
         n55WWPWebNotificationRead = (bool)(Convert.ToBoolean(obj12.gxTpr_Wwpwebnotificationread_N));
         n65WWPWebNotificationDetail = (bool)(Convert.ToBoolean(obj12.gxTpr_Wwpwebnotificationdetail_N));
         n66WWPWebNotificationReceived = (bool)(Convert.ToBoolean(obj12.gxTpr_Wwpwebnotificationreceived_N));
         Gx_mode = obj12.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A56WWPWebNotificationId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0B12( ) ;
         ScanKeyStart0B12( ) ;
         if ( RcdFound12 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z56WWPWebNotificationId = A56WWPWebNotificationId;
         }
         ZM0B12( -9) ;
         OnLoadActions0B12( ) ;
         AddRow0B12( ) ;
         ScanKeyEnd0B12( ) ;
         if ( RcdFound12 == 0 )
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
         RowToVars12( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 0) ;
         ScanKeyStart0B12( ) ;
         if ( RcdFound12 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z56WWPWebNotificationId = A56WWPWebNotificationId;
         }
         ZM0B12( -9) ;
         OnLoadActions0B12( ) ;
         AddRow0B12( ) ;
         ScanKeyEnd0B12( ) ;
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0B12( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0B12( ) ;
         }
         else
         {
            if ( RcdFound12 == 1 )
            {
               if ( A56WWPWebNotificationId != Z56WWPWebNotificationId )
               {
                  A56WWPWebNotificationId = Z56WWPWebNotificationId;
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
                  Update0B12( ) ;
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
                  if ( A56WWPWebNotificationId != Z56WWPWebNotificationId )
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
                        Insert0B12( ) ;
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
                        Insert0B12( ) ;
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
         RowToVars12( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         SaveImpl( ) ;
         VarsToRow12( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars12( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B12( ) ;
         AfterTrn( ) ;
         VarsToRow12( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow12( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A56WWPWebNotificationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_web_WWP_WebNotification);
               auxBC.Save();
               bcwwpbaseobjects_notifications_web_WWP_WebNotification.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars12( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
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
         RowToVars12( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B12( ) ;
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
               VarsToRow12( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow12( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
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
         RowToVars12( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 0) ;
         GetKey0B12( ) ;
         if ( RcdFound12 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A56WWPWebNotificationId != Z56WWPWebNotificationId )
            {
               A56WWPWebNotificationId = Z56WWPWebNotificationId;
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
            if ( A56WWPWebNotificationId != Z56WWPWebNotificationId )
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
         context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webnotification_bc",pr_default);
         VarsToRow12( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_web_WWP_WebNotification )
         {
            bcwwpbaseobjects_notifications_web_WWP_WebNotification = (GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow12( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
            }
            else
            {
               RowToVars12( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars12( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_WebNotification WWP_WebNotification_BC
      {
         get {
            return bcwwpbaseobjects_notifications_web_WWP_WebNotification ;
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
         pr_default.close(9);
         pr_default.close(10);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z51WWPWebNotificationTitle = "";
         A51WWPWebNotificationTitle = "";
         Z52WWPWebNotificationText = "";
         A52WWPWebNotificationText = "";
         Z53WWPWebNotificationIcon = "";
         A53WWPWebNotificationIcon = "";
         Z54WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         A54WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z67WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         A67WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z64WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         A64WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z55WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         A55WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         Z33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z68WWPNotificationDefinitionName = "";
         A68WWPNotificationDefinitionName = "";
         Z62WWPWebNotificationClientId = "";
         A62WWPWebNotificationClientId = "";
         Z65WWPWebNotificationDetail = "";
         A65WWPWebNotificationDetail = "";
         Z69WWPNotificationMetadata = "";
         A69WWPNotificationMetadata = "";
         BC000B6_A32WWPNotificationDefinitionId = new long[1] ;
         BC000B6_A56WWPWebNotificationId = new long[1] ;
         BC000B6_A51WWPWebNotificationTitle = new string[] {""} ;
         BC000B6_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000B6_A69WWPNotificationMetadata = new string[] {""} ;
         BC000B6_n69WWPNotificationMetadata = new bool[] {false} ;
         BC000B6_A68WWPNotificationDefinitionName = new string[] {""} ;
         BC000B6_A52WWPWebNotificationText = new string[] {""} ;
         BC000B6_A53WWPWebNotificationIcon = new string[] {""} ;
         BC000B6_A62WWPWebNotificationClientId = new string[] {""} ;
         BC000B6_A63WWPWebNotificationStatus = new short[1] ;
         BC000B6_A54WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000B6_A67WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000B6_A64WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000B6_A55WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC000B6_n55WWPWebNotificationRead = new bool[] {false} ;
         BC000B6_A65WWPWebNotificationDetail = new string[] {""} ;
         BC000B6_n65WWPWebNotificationDetail = new bool[] {false} ;
         BC000B6_A66WWPWebNotificationReceived = new bool[] {false} ;
         BC000B6_n66WWPWebNotificationReceived = new bool[] {false} ;
         BC000B6_A31WWPNotificationId = new long[1] ;
         BC000B6_n31WWPNotificationId = new bool[] {false} ;
         BC000B4_A32WWPNotificationDefinitionId = new long[1] ;
         BC000B4_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000B4_A69WWPNotificationMetadata = new string[] {""} ;
         BC000B4_n69WWPNotificationMetadata = new bool[] {false} ;
         BC000B5_A68WWPNotificationDefinitionName = new string[] {""} ;
         BC000B7_A56WWPWebNotificationId = new long[1] ;
         BC000B3_A56WWPWebNotificationId = new long[1] ;
         BC000B3_A51WWPWebNotificationTitle = new string[] {""} ;
         BC000B3_A52WWPWebNotificationText = new string[] {""} ;
         BC000B3_A53WWPWebNotificationIcon = new string[] {""} ;
         BC000B3_A62WWPWebNotificationClientId = new string[] {""} ;
         BC000B3_A63WWPWebNotificationStatus = new short[1] ;
         BC000B3_A54WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000B3_A67WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000B3_A64WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000B3_A55WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC000B3_n55WWPWebNotificationRead = new bool[] {false} ;
         BC000B3_A65WWPWebNotificationDetail = new string[] {""} ;
         BC000B3_n65WWPWebNotificationDetail = new bool[] {false} ;
         BC000B3_A66WWPWebNotificationReceived = new bool[] {false} ;
         BC000B3_n66WWPWebNotificationReceived = new bool[] {false} ;
         BC000B3_A31WWPNotificationId = new long[1] ;
         BC000B3_n31WWPNotificationId = new bool[] {false} ;
         sMode12 = "";
         BC000B2_A56WWPWebNotificationId = new long[1] ;
         BC000B2_A51WWPWebNotificationTitle = new string[] {""} ;
         BC000B2_A52WWPWebNotificationText = new string[] {""} ;
         BC000B2_A53WWPWebNotificationIcon = new string[] {""} ;
         BC000B2_A62WWPWebNotificationClientId = new string[] {""} ;
         BC000B2_A63WWPWebNotificationStatus = new short[1] ;
         BC000B2_A54WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000B2_A67WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000B2_A64WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000B2_A55WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC000B2_n55WWPWebNotificationRead = new bool[] {false} ;
         BC000B2_A65WWPWebNotificationDetail = new string[] {""} ;
         BC000B2_n65WWPWebNotificationDetail = new bool[] {false} ;
         BC000B2_A66WWPWebNotificationReceived = new bool[] {false} ;
         BC000B2_n66WWPWebNotificationReceived = new bool[] {false} ;
         BC000B2_A31WWPNotificationId = new long[1] ;
         BC000B2_n31WWPNotificationId = new bool[] {false} ;
         BC000B8_A56WWPWebNotificationId = new long[1] ;
         BC000B11_A32WWPNotificationDefinitionId = new long[1] ;
         BC000B11_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000B11_A69WWPNotificationMetadata = new string[] {""} ;
         BC000B11_n69WWPNotificationMetadata = new bool[] {false} ;
         BC000B12_A68WWPNotificationDefinitionName = new string[] {""} ;
         BC000B13_A32WWPNotificationDefinitionId = new long[1] ;
         BC000B13_A56WWPWebNotificationId = new long[1] ;
         BC000B13_A51WWPWebNotificationTitle = new string[] {""} ;
         BC000B13_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000B13_A69WWPNotificationMetadata = new string[] {""} ;
         BC000B13_n69WWPNotificationMetadata = new bool[] {false} ;
         BC000B13_A68WWPNotificationDefinitionName = new string[] {""} ;
         BC000B13_A52WWPWebNotificationText = new string[] {""} ;
         BC000B13_A53WWPWebNotificationIcon = new string[] {""} ;
         BC000B13_A62WWPWebNotificationClientId = new string[] {""} ;
         BC000B13_A63WWPWebNotificationStatus = new short[1] ;
         BC000B13_A54WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000B13_A67WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000B13_A64WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000B13_A55WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC000B13_n55WWPWebNotificationRead = new bool[] {false} ;
         BC000B13_A65WWPWebNotificationDetail = new string[] {""} ;
         BC000B13_n65WWPWebNotificationDetail = new bool[] {false} ;
         BC000B13_A66WWPWebNotificationReceived = new bool[] {false} ;
         BC000B13_n66WWPWebNotificationReceived = new bool[] {false} ;
         BC000B13_A31WWPNotificationId = new long[1] ;
         BC000B13_n31WWPNotificationId = new bool[] {false} ;
         i54WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         i67WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification_bc__default(),
            new Object[][] {
                new Object[] {
               BC000B2_A56WWPWebNotificationId, BC000B2_A51WWPWebNotificationTitle, BC000B2_A52WWPWebNotificationText, BC000B2_A53WWPWebNotificationIcon, BC000B2_A62WWPWebNotificationClientId, BC000B2_A63WWPWebNotificationStatus, BC000B2_A54WWPWebNotificationCreated, BC000B2_A67WWPWebNotificationScheduled, BC000B2_A64WWPWebNotificationProcessed, BC000B2_A55WWPWebNotificationRead,
               BC000B2_n55WWPWebNotificationRead, BC000B2_A65WWPWebNotificationDetail, BC000B2_n65WWPWebNotificationDetail, BC000B2_A66WWPWebNotificationReceived, BC000B2_n66WWPWebNotificationReceived, BC000B2_A31WWPNotificationId, BC000B2_n31WWPNotificationId
               }
               , new Object[] {
               BC000B3_A56WWPWebNotificationId, BC000B3_A51WWPWebNotificationTitle, BC000B3_A52WWPWebNotificationText, BC000B3_A53WWPWebNotificationIcon, BC000B3_A62WWPWebNotificationClientId, BC000B3_A63WWPWebNotificationStatus, BC000B3_A54WWPWebNotificationCreated, BC000B3_A67WWPWebNotificationScheduled, BC000B3_A64WWPWebNotificationProcessed, BC000B3_A55WWPWebNotificationRead,
               BC000B3_n55WWPWebNotificationRead, BC000B3_A65WWPWebNotificationDetail, BC000B3_n65WWPWebNotificationDetail, BC000B3_A66WWPWebNotificationReceived, BC000B3_n66WWPWebNotificationReceived, BC000B3_A31WWPNotificationId, BC000B3_n31WWPNotificationId
               }
               , new Object[] {
               BC000B4_A32WWPNotificationDefinitionId, BC000B4_A33WWPNotificationCreated, BC000B4_A69WWPNotificationMetadata, BC000B4_n69WWPNotificationMetadata
               }
               , new Object[] {
               BC000B5_A68WWPNotificationDefinitionName
               }
               , new Object[] {
               BC000B6_A32WWPNotificationDefinitionId, BC000B6_A56WWPWebNotificationId, BC000B6_A51WWPWebNotificationTitle, BC000B6_A33WWPNotificationCreated, BC000B6_A69WWPNotificationMetadata, BC000B6_n69WWPNotificationMetadata, BC000B6_A68WWPNotificationDefinitionName, BC000B6_A52WWPWebNotificationText, BC000B6_A53WWPWebNotificationIcon, BC000B6_A62WWPWebNotificationClientId,
               BC000B6_A63WWPWebNotificationStatus, BC000B6_A54WWPWebNotificationCreated, BC000B6_A67WWPWebNotificationScheduled, BC000B6_A64WWPWebNotificationProcessed, BC000B6_A55WWPWebNotificationRead, BC000B6_n55WWPWebNotificationRead, BC000B6_A65WWPWebNotificationDetail, BC000B6_n65WWPWebNotificationDetail, BC000B6_A66WWPWebNotificationReceived, BC000B6_n66WWPWebNotificationReceived,
               BC000B6_A31WWPNotificationId, BC000B6_n31WWPNotificationId
               }
               , new Object[] {
               BC000B7_A56WWPWebNotificationId
               }
               , new Object[] {
               BC000B8_A56WWPWebNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000B11_A32WWPNotificationDefinitionId, BC000B11_A33WWPNotificationCreated, BC000B11_A69WWPNotificationMetadata, BC000B11_n69WWPNotificationMetadata
               }
               , new Object[] {
               BC000B12_A68WWPNotificationDefinitionName
               }
               , new Object[] {
               BC000B13_A32WWPNotificationDefinitionId, BC000B13_A56WWPWebNotificationId, BC000B13_A51WWPWebNotificationTitle, BC000B13_A33WWPNotificationCreated, BC000B13_A69WWPNotificationMetadata, BC000B13_n69WWPNotificationMetadata, BC000B13_A68WWPNotificationDefinitionName, BC000B13_A52WWPWebNotificationText, BC000B13_A53WWPWebNotificationIcon, BC000B13_A62WWPWebNotificationClientId,
               BC000B13_A63WWPWebNotificationStatus, BC000B13_A54WWPWebNotificationCreated, BC000B13_A67WWPWebNotificationScheduled, BC000B13_A64WWPWebNotificationProcessed, BC000B13_A55WWPWebNotificationRead, BC000B13_n55WWPWebNotificationRead, BC000B13_A65WWPWebNotificationDetail, BC000B13_n65WWPWebNotificationDetail, BC000B13_A66WWPWebNotificationReceived, BC000B13_n66WWPWebNotificationReceived,
               BC000B13_A31WWPNotificationId, BC000B13_n31WWPNotificationId
               }
            }
         );
         Z67WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A67WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i67WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z54WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A54WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i54WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z63WWPWebNotificationStatus = 1;
         A63WWPWebNotificationStatus = 1;
         i63WWPWebNotificationStatus = 1;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z63WWPWebNotificationStatus ;
      private short A63WWPWebNotificationStatus ;
      private short Gx_BScreen ;
      private short RcdFound12 ;
      private short i63WWPWebNotificationStatus ;
      private int trnEnded ;
      private long Z56WWPWebNotificationId ;
      private long A56WWPWebNotificationId ;
      private long Z31WWPNotificationId ;
      private long A31WWPNotificationId ;
      private long Z32WWPNotificationDefinitionId ;
      private long A32WWPNotificationDefinitionId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode12 ;
      private DateTime Z54WWPWebNotificationCreated ;
      private DateTime A54WWPWebNotificationCreated ;
      private DateTime Z67WWPWebNotificationScheduled ;
      private DateTime A67WWPWebNotificationScheduled ;
      private DateTime Z64WWPWebNotificationProcessed ;
      private DateTime A64WWPWebNotificationProcessed ;
      private DateTime Z55WWPWebNotificationRead ;
      private DateTime A55WWPWebNotificationRead ;
      private DateTime Z33WWPNotificationCreated ;
      private DateTime A33WWPNotificationCreated ;
      private DateTime i54WWPWebNotificationCreated ;
      private DateTime i67WWPWebNotificationScheduled ;
      private bool Z66WWPWebNotificationReceived ;
      private bool A66WWPWebNotificationReceived ;
      private bool n69WWPNotificationMetadata ;
      private bool n55WWPWebNotificationRead ;
      private bool n65WWPWebNotificationDetail ;
      private bool n66WWPWebNotificationReceived ;
      private bool n31WWPNotificationId ;
      private bool Gx_longc ;
      private string Z62WWPWebNotificationClientId ;
      private string A62WWPWebNotificationClientId ;
      private string Z65WWPWebNotificationDetail ;
      private string A65WWPWebNotificationDetail ;
      private string Z69WWPNotificationMetadata ;
      private string A69WWPNotificationMetadata ;
      private string Z51WWPWebNotificationTitle ;
      private string A51WWPWebNotificationTitle ;
      private string Z52WWPWebNotificationText ;
      private string A52WWPWebNotificationText ;
      private string Z53WWPWebNotificationIcon ;
      private string A53WWPWebNotificationIcon ;
      private string Z68WWPNotificationDefinitionName ;
      private string A68WWPNotificationDefinitionName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000B6_A32WWPNotificationDefinitionId ;
      private long[] BC000B6_A56WWPWebNotificationId ;
      private string[] BC000B6_A51WWPWebNotificationTitle ;
      private DateTime[] BC000B6_A33WWPNotificationCreated ;
      private string[] BC000B6_A69WWPNotificationMetadata ;
      private bool[] BC000B6_n69WWPNotificationMetadata ;
      private string[] BC000B6_A68WWPNotificationDefinitionName ;
      private string[] BC000B6_A52WWPWebNotificationText ;
      private string[] BC000B6_A53WWPWebNotificationIcon ;
      private string[] BC000B6_A62WWPWebNotificationClientId ;
      private short[] BC000B6_A63WWPWebNotificationStatus ;
      private DateTime[] BC000B6_A54WWPWebNotificationCreated ;
      private DateTime[] BC000B6_A67WWPWebNotificationScheduled ;
      private DateTime[] BC000B6_A64WWPWebNotificationProcessed ;
      private DateTime[] BC000B6_A55WWPWebNotificationRead ;
      private bool[] BC000B6_n55WWPWebNotificationRead ;
      private string[] BC000B6_A65WWPWebNotificationDetail ;
      private bool[] BC000B6_n65WWPWebNotificationDetail ;
      private bool[] BC000B6_A66WWPWebNotificationReceived ;
      private bool[] BC000B6_n66WWPWebNotificationReceived ;
      private long[] BC000B6_A31WWPNotificationId ;
      private bool[] BC000B6_n31WWPNotificationId ;
      private long[] BC000B4_A32WWPNotificationDefinitionId ;
      private DateTime[] BC000B4_A33WWPNotificationCreated ;
      private string[] BC000B4_A69WWPNotificationMetadata ;
      private bool[] BC000B4_n69WWPNotificationMetadata ;
      private string[] BC000B5_A68WWPNotificationDefinitionName ;
      private long[] BC000B7_A56WWPWebNotificationId ;
      private long[] BC000B3_A56WWPWebNotificationId ;
      private string[] BC000B3_A51WWPWebNotificationTitle ;
      private string[] BC000B3_A52WWPWebNotificationText ;
      private string[] BC000B3_A53WWPWebNotificationIcon ;
      private string[] BC000B3_A62WWPWebNotificationClientId ;
      private short[] BC000B3_A63WWPWebNotificationStatus ;
      private DateTime[] BC000B3_A54WWPWebNotificationCreated ;
      private DateTime[] BC000B3_A67WWPWebNotificationScheduled ;
      private DateTime[] BC000B3_A64WWPWebNotificationProcessed ;
      private DateTime[] BC000B3_A55WWPWebNotificationRead ;
      private bool[] BC000B3_n55WWPWebNotificationRead ;
      private string[] BC000B3_A65WWPWebNotificationDetail ;
      private bool[] BC000B3_n65WWPWebNotificationDetail ;
      private bool[] BC000B3_A66WWPWebNotificationReceived ;
      private bool[] BC000B3_n66WWPWebNotificationReceived ;
      private long[] BC000B3_A31WWPNotificationId ;
      private bool[] BC000B3_n31WWPNotificationId ;
      private long[] BC000B2_A56WWPWebNotificationId ;
      private string[] BC000B2_A51WWPWebNotificationTitle ;
      private string[] BC000B2_A52WWPWebNotificationText ;
      private string[] BC000B2_A53WWPWebNotificationIcon ;
      private string[] BC000B2_A62WWPWebNotificationClientId ;
      private short[] BC000B2_A63WWPWebNotificationStatus ;
      private DateTime[] BC000B2_A54WWPWebNotificationCreated ;
      private DateTime[] BC000B2_A67WWPWebNotificationScheduled ;
      private DateTime[] BC000B2_A64WWPWebNotificationProcessed ;
      private DateTime[] BC000B2_A55WWPWebNotificationRead ;
      private bool[] BC000B2_n55WWPWebNotificationRead ;
      private string[] BC000B2_A65WWPWebNotificationDetail ;
      private bool[] BC000B2_n65WWPWebNotificationDetail ;
      private bool[] BC000B2_A66WWPWebNotificationReceived ;
      private bool[] BC000B2_n66WWPWebNotificationReceived ;
      private long[] BC000B2_A31WWPNotificationId ;
      private bool[] BC000B2_n31WWPNotificationId ;
      private long[] BC000B8_A56WWPWebNotificationId ;
      private long[] BC000B11_A32WWPNotificationDefinitionId ;
      private DateTime[] BC000B11_A33WWPNotificationCreated ;
      private string[] BC000B11_A69WWPNotificationMetadata ;
      private bool[] BC000B11_n69WWPNotificationMetadata ;
      private string[] BC000B12_A68WWPNotificationDefinitionName ;
      private long[] BC000B13_A32WWPNotificationDefinitionId ;
      private long[] BC000B13_A56WWPWebNotificationId ;
      private string[] BC000B13_A51WWPWebNotificationTitle ;
      private DateTime[] BC000B13_A33WWPNotificationCreated ;
      private string[] BC000B13_A69WWPNotificationMetadata ;
      private bool[] BC000B13_n69WWPNotificationMetadata ;
      private string[] BC000B13_A68WWPNotificationDefinitionName ;
      private string[] BC000B13_A52WWPWebNotificationText ;
      private string[] BC000B13_A53WWPWebNotificationIcon ;
      private string[] BC000B13_A62WWPWebNotificationClientId ;
      private short[] BC000B13_A63WWPWebNotificationStatus ;
      private DateTime[] BC000B13_A54WWPWebNotificationCreated ;
      private DateTime[] BC000B13_A67WWPWebNotificationScheduled ;
      private DateTime[] BC000B13_A64WWPWebNotificationProcessed ;
      private DateTime[] BC000B13_A55WWPWebNotificationRead ;
      private bool[] BC000B13_n55WWPWebNotificationRead ;
      private string[] BC000B13_A65WWPWebNotificationDetail ;
      private bool[] BC000B13_n65WWPWebNotificationDetail ;
      private bool[] BC000B13_A66WWPWebNotificationReceived ;
      private bool[] BC000B13_n66WWPWebNotificationReceived ;
      private long[] BC000B13_A31WWPNotificationId ;
      private bool[] BC000B13_n31WWPNotificationId ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification bcwwpbaseobjects_notifications_web_WWP_WebNotification ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_webnotification_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_webnotification_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000B2;
        prmBC000B2 = new Object[] {
        new ParDef("@WWPWebNotificationId",GXType.Decimal,10,0)
        };
        Object[] prmBC000B3;
        prmBC000B3 = new Object[] {
        new ParDef("@WWPWebNotificationId",GXType.Decimal,10,0)
        };
        Object[] prmBC000B4;
        prmBC000B4 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000B5;
        prmBC000B5 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmBC000B6;
        prmBC000B6 = new Object[] {
        new ParDef("@WWPWebNotificationId",GXType.Decimal,10,0)
        };
        Object[] prmBC000B7;
        prmBC000B7 = new Object[] {
        new ParDef("@WWPWebNotificationId",GXType.Decimal,10,0)
        };
        Object[] prmBC000B8;
        prmBC000B8 = new Object[] {
        new ParDef("@WWPWebNotificationTitle",GXType.NVarChar,40,0) ,
        new ParDef("@WWPWebNotificationText",GXType.NVarChar,120,0) ,
        new ParDef("@WWPWebNotificationIcon",GXType.NVarChar,255,0) ,
        new ParDef("@WWPWebNotificationClientId",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPWebNotificationStatus",GXType.Int16,4,0) ,
        new ParDef("@WWPWebNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("@WWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
        new ParDef("@WWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
        new ParDef("@WWPWebNotificationRead",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("@WWPWebNotificationDetail",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPWebNotificationReceived",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000B9;
        prmBC000B9 = new Object[] {
        new ParDef("@WWPWebNotificationTitle",GXType.NVarChar,40,0) ,
        new ParDef("@WWPWebNotificationText",GXType.NVarChar,120,0) ,
        new ParDef("@WWPWebNotificationIcon",GXType.NVarChar,255,0) ,
        new ParDef("@WWPWebNotificationClientId",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPWebNotificationStatus",GXType.Int16,4,0) ,
        new ParDef("@WWPWebNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("@WWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
        new ParDef("@WWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
        new ParDef("@WWPWebNotificationRead",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("@WWPWebNotificationDetail",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPWebNotificationReceived",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@WWPWebNotificationId",GXType.Decimal,10,0)
        };
        Object[] prmBC000B10;
        prmBC000B10 = new Object[] {
        new ParDef("@WWPWebNotificationId",GXType.Decimal,10,0)
        };
        Object[] prmBC000B11;
        prmBC000B11 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000B12;
        prmBC000B12 = new Object[] {
        new ParDef("@WWPNotificationDefinitionId",GXType.Decimal,10,0)
        };
        Object[] prmBC000B13;
        prmBC000B13 = new Object[] {
        new ParDef("@WWPWebNotificationId",GXType.Decimal,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000B2", "SELECT [WWPWebNotificationId], [WWPWebNotificationTitle], [WWPWebNotificationText], [WWPWebNotificationIcon], [WWPWebNotificationClientId], [WWPWebNotificationStatus], [WWPWebNotificationCreated], [WWPWebNotificationScheduled], [WWPWebNotificationProcessed], [WWPWebNotificationRead], [WWPWebNotificationDetail], [WWPWebNotificationReceived], [WWPNotificationId] FROM [WWP_WebNotification] WITH (UPDLOCK) WHERE [WWPWebNotificationId] = @WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B3", "SELECT [WWPWebNotificationId], [WWPWebNotificationTitle], [WWPWebNotificationText], [WWPWebNotificationIcon], [WWPWebNotificationClientId], [WWPWebNotificationStatus], [WWPWebNotificationCreated], [WWPWebNotificationScheduled], [WWPWebNotificationProcessed], [WWPWebNotificationRead], [WWPWebNotificationDetail], [WWPWebNotificationReceived], [WWPNotificationId] FROM [WWP_WebNotification] WHERE [WWPWebNotificationId] = @WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B4", "SELECT [WWPNotificationDefinitionId], [WWPNotificationCreated], [WWPNotificationMetadata] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B5", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B6", "SELECT T2.[WWPNotificationDefinitionId], TM1.[WWPWebNotificationId], TM1.[WWPWebNotificationTitle], T2.[WWPNotificationCreated], T2.[WWPNotificationMetadata], T3.[WWPNotificationDefinitionName], TM1.[WWPWebNotificationText], TM1.[WWPWebNotificationIcon], TM1.[WWPWebNotificationClientId], TM1.[WWPWebNotificationStatus], TM1.[WWPWebNotificationCreated], TM1.[WWPWebNotificationScheduled], TM1.[WWPWebNotificationProcessed], TM1.[WWPWebNotificationRead], TM1.[WWPWebNotificationDetail], TM1.[WWPWebNotificationReceived], TM1.[WWPNotificationId] FROM (([WWP_WebNotification] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) LEFT JOIN [WWP_NotificationDefinition] T3 ON T3.[WWPNotificationDefinitionId] = T2.[WWPNotificationDefinitionId]) WHERE TM1.[WWPWebNotificationId] = @WWPWebNotificationId ORDER BY TM1.[WWPWebNotificationId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B7", "SELECT [WWPWebNotificationId] FROM [WWP_WebNotification] WHERE [WWPWebNotificationId] = @WWPWebNotificationId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B8", "INSERT INTO [WWP_WebNotification]([WWPWebNotificationTitle], [WWPWebNotificationText], [WWPWebNotificationIcon], [WWPWebNotificationClientId], [WWPWebNotificationStatus], [WWPWebNotificationCreated], [WWPWebNotificationScheduled], [WWPWebNotificationProcessed], [WWPWebNotificationRead], [WWPWebNotificationDetail], [WWPWebNotificationReceived], [WWPNotificationId]) VALUES(@WWPWebNotificationTitle, @WWPWebNotificationText, @WWPWebNotificationIcon, @WWPWebNotificationClientId, @WWPWebNotificationStatus, @WWPWebNotificationCreated, @WWPWebNotificationScheduled, @WWPWebNotificationProcessed, @WWPWebNotificationRead, @WWPWebNotificationDetail, @WWPWebNotificationReceived, @WWPNotificationId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000B9", "UPDATE [WWP_WebNotification] SET [WWPWebNotificationTitle]=@WWPWebNotificationTitle, [WWPWebNotificationText]=@WWPWebNotificationText, [WWPWebNotificationIcon]=@WWPWebNotificationIcon, [WWPWebNotificationClientId]=@WWPWebNotificationClientId, [WWPWebNotificationStatus]=@WWPWebNotificationStatus, [WWPWebNotificationCreated]=@WWPWebNotificationCreated, [WWPWebNotificationScheduled]=@WWPWebNotificationScheduled, [WWPWebNotificationProcessed]=@WWPWebNotificationProcessed, [WWPWebNotificationRead]=@WWPWebNotificationRead, [WWPWebNotificationDetail]=@WWPWebNotificationDetail, [WWPWebNotificationReceived]=@WWPWebNotificationReceived, [WWPNotificationId]=@WWPNotificationId  WHERE [WWPWebNotificationId] = @WWPWebNotificationId", GxErrorMask.GX_NOMASK,prmBC000B9)
           ,new CursorDef("BC000B10", "DELETE FROM [WWP_WebNotification]  WHERE [WWPWebNotificationId] = @WWPWebNotificationId", GxErrorMask.GX_NOMASK,prmBC000B10)
           ,new CursorDef("BC000B11", "SELECT [WWPNotificationDefinitionId], [WWPNotificationCreated], [WWPNotificationMetadata] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B12", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B13", "SELECT T2.[WWPNotificationDefinitionId], TM1.[WWPWebNotificationId], TM1.[WWPWebNotificationTitle], T2.[WWPNotificationCreated], T2.[WWPNotificationMetadata], T3.[WWPNotificationDefinitionName], TM1.[WWPWebNotificationText], TM1.[WWPWebNotificationIcon], TM1.[WWPWebNotificationClientId], TM1.[WWPWebNotificationStatus], TM1.[WWPWebNotificationCreated], TM1.[WWPWebNotificationScheduled], TM1.[WWPWebNotificationProcessed], TM1.[WWPWebNotificationRead], TM1.[WWPWebNotificationDetail], TM1.[WWPWebNotificationReceived], TM1.[WWPNotificationId] FROM (([WWP_WebNotification] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) LEFT JOIN [WWP_NotificationDefinition] T3 ON T3.[WWPNotificationDefinitionId] = T2.[WWPNotificationDefinitionId]) WHERE TM1.[WWPWebNotificationId] = @WWPWebNotificationId ORDER BY TM1.[WWPWebNotificationId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B13,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getLongVarchar(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((bool[]) buf[13])[0] = rslt.getBool(12);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((long[]) buf[15])[0] = rslt.getLong(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getLongVarchar(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((bool[]) buf[13])[0] = rslt.getBool(12);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((long[]) buf[15])[0] = rslt.getLong(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(12, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(13, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(14, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(14);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(15);
              ((bool[]) buf[17])[0] = rslt.wasNull(15);
              ((bool[]) buf[18])[0] = rslt.getBool(16);
              ((bool[]) buf[19])[0] = rslt.wasNull(16);
              ((long[]) buf[20])[0] = rslt.getLong(17);
              ((bool[]) buf[21])[0] = rslt.wasNull(17);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(12, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(13, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(14, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(14);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(15);
              ((bool[]) buf[17])[0] = rslt.wasNull(15);
              ((bool[]) buf[18])[0] = rslt.getBool(16);
              ((bool[]) buf[19])[0] = rslt.wasNull(16);
              ((long[]) buf[20])[0] = rslt.getLong(17);
              ((bool[]) buf[21])[0] = rslt.wasNull(17);
              return;
     }
  }

}

}
