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
namespace GeneXus.Programs.wwpbaseobjects.sms {
   public class wwp_sms_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_sms_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_sms_bc( IGxContext context )
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
         ReadRow0A11( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0A11( ) ;
         standaloneModal( ) ;
         AddRow0A11( ) ;
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
               Z42WWPSMSId = A42WWPSMSId;
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

      protected void CONFIRM_0A0( )
      {
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0A11( ) ;
            }
            else
            {
               CheckExtendedTable0A11( ) ;
               if ( AnyError == 0 )
               {
                  ZM0A11( 9) ;
               }
               CloseExtendedTableCursors0A11( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0A11( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z43WWPSMSStatus = A43WWPSMSStatus;
            Z49WWPSMSCreated = A49WWPSMSCreated;
            Z50WWPSMSScheduled = A50WWPSMSScheduled;
            Z44WWPSMSProcessed = A44WWPSMSProcessed;
            Z31WWPNotificationId = A31WWPNotificationId;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z33WWPNotificationCreated = A33WWPNotificationCreated;
         }
         if ( GX_JID == -8 )
         {
            Z42WWPSMSId = A42WWPSMSId;
            Z46WWPSMSMessage = A46WWPSMSMessage;
            Z47WWPSMSSenderNumber = A47WWPSMSSenderNumber;
            Z48WWPSMSRecipientNumbers = A48WWPSMSRecipientNumbers;
            Z43WWPSMSStatus = A43WWPSMSStatus;
            Z49WWPSMSCreated = A49WWPSMSCreated;
            Z50WWPSMSScheduled = A50WWPSMSScheduled;
            Z44WWPSMSProcessed = A44WWPSMSProcessed;
            Z45WWPSMSDetail = A45WWPSMSDetail;
            Z31WWPNotificationId = A31WWPNotificationId;
            Z33WWPNotificationCreated = A33WWPNotificationCreated;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A43WWPSMSStatus) && ( Gx_BScreen == 0 ) )
         {
            A43WWPSMSStatus = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A49WWPSMSCreated) && ( Gx_BScreen == 0 ) )
         {
            A49WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A50WWPSMSScheduled) && ( Gx_BScreen == 0 ) )
         {
            A50WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0A11( )
      {
         /* Using cursor BC000A5 */
         pr_default.execute(3, new Object[] {A42WWPSMSId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound11 = 1;
            A46WWPSMSMessage = BC000A5_A46WWPSMSMessage[0];
            A47WWPSMSSenderNumber = BC000A5_A47WWPSMSSenderNumber[0];
            A48WWPSMSRecipientNumbers = BC000A5_A48WWPSMSRecipientNumbers[0];
            A43WWPSMSStatus = BC000A5_A43WWPSMSStatus[0];
            A49WWPSMSCreated = BC000A5_A49WWPSMSCreated[0];
            A50WWPSMSScheduled = BC000A5_A50WWPSMSScheduled[0];
            A44WWPSMSProcessed = BC000A5_A44WWPSMSProcessed[0];
            n44WWPSMSProcessed = BC000A5_n44WWPSMSProcessed[0];
            A45WWPSMSDetail = BC000A5_A45WWPSMSDetail[0];
            n45WWPSMSDetail = BC000A5_n45WWPSMSDetail[0];
            A33WWPNotificationCreated = BC000A5_A33WWPNotificationCreated[0];
            A31WWPNotificationId = BC000A5_A31WWPNotificationId[0];
            n31WWPNotificationId = BC000A5_n31WWPNotificationId[0];
            ZM0A11( -8) ;
         }
         pr_default.close(3);
         OnLoadActions0A11( ) ;
      }

      protected void OnLoadActions0A11( )
      {
      }

      protected void CheckExtendedTable0A11( )
      {
         standaloneModal( ) ;
         if ( ! ( ( A43WWPSMSStatus == 1 ) || ( A43WWPSMSStatus == 2 ) || ( A43WWPSMSStatus == 3 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "SMS Status", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A49WWPSMSCreated) || ( A49WWPSMSCreated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "SMS Created", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A50WWPSMSScheduled) || ( A50WWPSMSScheduled >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "SMS Scheduled", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A44WWPSMSProcessed) || ( A44WWPSMSProcessed >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "SMS Processed", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000A4 */
         pr_default.execute(2, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A31WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
            }
         }
         A33WWPNotificationCreated = BC000A4_A33WWPNotificationCreated[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0A11( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0A11( )
      {
         /* Using cursor BC000A6 */
         pr_default.execute(4, new Object[] {A42WWPSMSId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000A3 */
         pr_default.execute(1, new Object[] {A42WWPSMSId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A11( 8) ;
            RcdFound11 = 1;
            A42WWPSMSId = BC000A3_A42WWPSMSId[0];
            A46WWPSMSMessage = BC000A3_A46WWPSMSMessage[0];
            A47WWPSMSSenderNumber = BC000A3_A47WWPSMSSenderNumber[0];
            A48WWPSMSRecipientNumbers = BC000A3_A48WWPSMSRecipientNumbers[0];
            A43WWPSMSStatus = BC000A3_A43WWPSMSStatus[0];
            A49WWPSMSCreated = BC000A3_A49WWPSMSCreated[0];
            A50WWPSMSScheduled = BC000A3_A50WWPSMSScheduled[0];
            A44WWPSMSProcessed = BC000A3_A44WWPSMSProcessed[0];
            n44WWPSMSProcessed = BC000A3_n44WWPSMSProcessed[0];
            A45WWPSMSDetail = BC000A3_A45WWPSMSDetail[0];
            n45WWPSMSDetail = BC000A3_n45WWPSMSDetail[0];
            A31WWPNotificationId = BC000A3_A31WWPNotificationId[0];
            n31WWPNotificationId = BC000A3_n31WWPNotificationId[0];
            Z42WWPSMSId = A42WWPSMSId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0A11( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0A11( ) ;
            }
            Gx_mode = sMode11;
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0A11( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode11;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A11( ) ;
         if ( RcdFound11 == 0 )
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
         CONFIRM_0A0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0A11( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000A2 */
            pr_default.execute(0, new Object[] {A42WWPSMSId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z43WWPSMSStatus != BC000A2_A43WWPSMSStatus[0] ) || ( Z49WWPSMSCreated != BC000A2_A49WWPSMSCreated[0] ) || ( Z50WWPSMSScheduled != BC000A2_A50WWPSMSScheduled[0] ) || ( Z44WWPSMSProcessed != BC000A2_A44WWPSMSProcessed[0] ) || ( Z31WWPNotificationId != BC000A2_A31WWPNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_SMS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A11( )
      {
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A11( 0) ;
            CheckOptimisticConcurrency0A11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A7 */
                     pr_default.execute(5, new Object[] {A46WWPSMSMessage, A47WWPSMSSenderNumber, A48WWPSMSRecipientNumbers, A43WWPSMSStatus, A49WWPSMSCreated, A50WWPSMSScheduled, n44WWPSMSProcessed, A44WWPSMSProcessed, n45WWPSMSDetail, A45WWPSMSDetail, n31WWPNotificationId, A31WWPNotificationId});
                     A42WWPSMSId = BC000A7_A42WWPSMSId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
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
               Load0A11( ) ;
            }
            EndLevel0A11( ) ;
         }
         CloseExtendedTableCursors0A11( ) ;
      }

      protected void Update0A11( )
      {
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A8 */
                     pr_default.execute(6, new Object[] {A46WWPSMSMessage, A47WWPSMSSenderNumber, A48WWPSMSRecipientNumbers, A43WWPSMSStatus, A49WWPSMSCreated, A50WWPSMSScheduled, n44WWPSMSProcessed, A44WWPSMSProcessed, n45WWPSMSDetail, A45WWPSMSDetail, n31WWPNotificationId, A31WWPNotificationId, A42WWPSMSId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A11( ) ;
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
            EndLevel0A11( ) ;
         }
         CloseExtendedTableCursors0A11( ) ;
      }

      protected void DeferredUpdate0A11( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A11( ) ;
            AfterConfirm0A11( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A11( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000A9 */
                  pr_default.execute(7, new Object[] {A42WWPSMSId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0A11( ) ;
         Gx_mode = sMode11;
      }

      protected void OnDeleteControls0A11( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000A10 */
            pr_default.execute(8, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
            A33WWPNotificationCreated = BC000A10_A33WWPNotificationCreated[0];
            pr_default.close(8);
         }
      }

      protected void EndLevel0A11( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A11( ) ;
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

      public void ScanKeyStart0A11( )
      {
         /* Using cursor BC000A11 */
         pr_default.execute(9, new Object[] {A42WWPSMSId});
         RcdFound11 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound11 = 1;
            A42WWPSMSId = BC000A11_A42WWPSMSId[0];
            A46WWPSMSMessage = BC000A11_A46WWPSMSMessage[0];
            A47WWPSMSSenderNumber = BC000A11_A47WWPSMSSenderNumber[0];
            A48WWPSMSRecipientNumbers = BC000A11_A48WWPSMSRecipientNumbers[0];
            A43WWPSMSStatus = BC000A11_A43WWPSMSStatus[0];
            A49WWPSMSCreated = BC000A11_A49WWPSMSCreated[0];
            A50WWPSMSScheduled = BC000A11_A50WWPSMSScheduled[0];
            A44WWPSMSProcessed = BC000A11_A44WWPSMSProcessed[0];
            n44WWPSMSProcessed = BC000A11_n44WWPSMSProcessed[0];
            A45WWPSMSDetail = BC000A11_A45WWPSMSDetail[0];
            n45WWPSMSDetail = BC000A11_n45WWPSMSDetail[0];
            A33WWPNotificationCreated = BC000A11_A33WWPNotificationCreated[0];
            A31WWPNotificationId = BC000A11_A31WWPNotificationId[0];
            n31WWPNotificationId = BC000A11_n31WWPNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0A11( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound11 = 0;
         ScanKeyLoad0A11( ) ;
      }

      protected void ScanKeyLoad0A11( )
      {
         sMode11 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound11 = 1;
            A42WWPSMSId = BC000A11_A42WWPSMSId[0];
            A46WWPSMSMessage = BC000A11_A46WWPSMSMessage[0];
            A47WWPSMSSenderNumber = BC000A11_A47WWPSMSSenderNumber[0];
            A48WWPSMSRecipientNumbers = BC000A11_A48WWPSMSRecipientNumbers[0];
            A43WWPSMSStatus = BC000A11_A43WWPSMSStatus[0];
            A49WWPSMSCreated = BC000A11_A49WWPSMSCreated[0];
            A50WWPSMSScheduled = BC000A11_A50WWPSMSScheduled[0];
            A44WWPSMSProcessed = BC000A11_A44WWPSMSProcessed[0];
            n44WWPSMSProcessed = BC000A11_n44WWPSMSProcessed[0];
            A45WWPSMSDetail = BC000A11_A45WWPSMSDetail[0];
            n45WWPSMSDetail = BC000A11_n45WWPSMSDetail[0];
            A33WWPNotificationCreated = BC000A11_A33WWPNotificationCreated[0];
            A31WWPNotificationId = BC000A11_A31WWPNotificationId[0];
            n31WWPNotificationId = BC000A11_n31WWPNotificationId[0];
         }
         Gx_mode = sMode11;
      }

      protected void ScanKeyEnd0A11( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0A11( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A11( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A11( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A11( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A11( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A11( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A11( )
      {
      }

      protected void send_integrity_lvl_hashes0A11( )
      {
      }

      protected void AddRow0A11( )
      {
         VarsToRow11( bcwwpbaseobjects_sms_WWP_SMS) ;
      }

      protected void ReadRow0A11( )
      {
         RowToVars11( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
      }

      protected void InitializeNonKey0A11( )
      {
         A46WWPSMSMessage = "";
         A47WWPSMSSenderNumber = "";
         A48WWPSMSRecipientNumbers = "";
         A44WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         n44WWPSMSProcessed = false;
         A45WWPSMSDetail = "";
         n45WWPSMSDetail = false;
         A31WWPNotificationId = 0;
         n31WWPNotificationId = false;
         A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A43WWPSMSStatus = 1;
         A49WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A50WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z43WWPSMSStatus = 0;
         Z49WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z50WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z44WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         Z31WWPNotificationId = 0;
      }

      protected void InitAll0A11( )
      {
         A42WWPSMSId = 0;
         InitializeNonKey0A11( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A43WWPSMSStatus = i43WWPSMSStatus;
         A49WWPSMSCreated = i49WWPSMSCreated;
         A50WWPSMSScheduled = i50WWPSMSScheduled;
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

      public void VarsToRow11( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS obj11 )
      {
         obj11.gxTpr_Mode = Gx_mode;
         obj11.gxTpr_Wwpsmsmessage = A46WWPSMSMessage;
         obj11.gxTpr_Wwpsmssendernumber = A47WWPSMSSenderNumber;
         obj11.gxTpr_Wwpsmsrecipientnumbers = A48WWPSMSRecipientNumbers;
         obj11.gxTpr_Wwpsmsprocessed = A44WWPSMSProcessed;
         obj11.gxTpr_Wwpsmsdetail = A45WWPSMSDetail;
         obj11.gxTpr_Wwpnotificationid = A31WWPNotificationId;
         obj11.gxTpr_Wwpnotificationcreated = A33WWPNotificationCreated;
         obj11.gxTpr_Wwpsmsstatus = A43WWPSMSStatus;
         obj11.gxTpr_Wwpsmscreated = A49WWPSMSCreated;
         obj11.gxTpr_Wwpsmsscheduled = A50WWPSMSScheduled;
         obj11.gxTpr_Wwpsmsid = A42WWPSMSId;
         obj11.gxTpr_Wwpsmsid_Z = Z42WWPSMSId;
         obj11.gxTpr_Wwpsmsstatus_Z = Z43WWPSMSStatus;
         obj11.gxTpr_Wwpsmscreated_Z = Z49WWPSMSCreated;
         obj11.gxTpr_Wwpsmsscheduled_Z = Z50WWPSMSScheduled;
         obj11.gxTpr_Wwpsmsprocessed_Z = Z44WWPSMSProcessed;
         obj11.gxTpr_Wwpnotificationid_Z = Z31WWPNotificationId;
         obj11.gxTpr_Wwpnotificationcreated_Z = Z33WWPNotificationCreated;
         obj11.gxTpr_Wwpsmsprocessed_N = (short)(Convert.ToInt16(n44WWPSMSProcessed));
         obj11.gxTpr_Wwpsmsdetail_N = (short)(Convert.ToInt16(n45WWPSMSDetail));
         obj11.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n31WWPNotificationId));
         obj11.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow11( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS obj11 )
      {
         obj11.gxTpr_Wwpsmsid = A42WWPSMSId;
         return  ;
      }

      public void RowToVars11( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS obj11 ,
                               int forceLoad )
      {
         Gx_mode = obj11.gxTpr_Mode;
         A46WWPSMSMessage = obj11.gxTpr_Wwpsmsmessage;
         A47WWPSMSSenderNumber = obj11.gxTpr_Wwpsmssendernumber;
         A48WWPSMSRecipientNumbers = obj11.gxTpr_Wwpsmsrecipientnumbers;
         A44WWPSMSProcessed = obj11.gxTpr_Wwpsmsprocessed;
         n44WWPSMSProcessed = false;
         A45WWPSMSDetail = obj11.gxTpr_Wwpsmsdetail;
         n45WWPSMSDetail = false;
         A31WWPNotificationId = obj11.gxTpr_Wwpnotificationid;
         n31WWPNotificationId = false;
         A33WWPNotificationCreated = obj11.gxTpr_Wwpnotificationcreated;
         A43WWPSMSStatus = obj11.gxTpr_Wwpsmsstatus;
         A49WWPSMSCreated = obj11.gxTpr_Wwpsmscreated;
         A50WWPSMSScheduled = obj11.gxTpr_Wwpsmsscheduled;
         A42WWPSMSId = obj11.gxTpr_Wwpsmsid;
         Z42WWPSMSId = obj11.gxTpr_Wwpsmsid_Z;
         Z43WWPSMSStatus = obj11.gxTpr_Wwpsmsstatus_Z;
         Z49WWPSMSCreated = obj11.gxTpr_Wwpsmscreated_Z;
         Z50WWPSMSScheduled = obj11.gxTpr_Wwpsmsscheduled_Z;
         Z44WWPSMSProcessed = obj11.gxTpr_Wwpsmsprocessed_Z;
         Z31WWPNotificationId = obj11.gxTpr_Wwpnotificationid_Z;
         Z33WWPNotificationCreated = obj11.gxTpr_Wwpnotificationcreated_Z;
         n44WWPSMSProcessed = (bool)(Convert.ToBoolean(obj11.gxTpr_Wwpsmsprocessed_N));
         n45WWPSMSDetail = (bool)(Convert.ToBoolean(obj11.gxTpr_Wwpsmsdetail_N));
         n31WWPNotificationId = (bool)(Convert.ToBoolean(obj11.gxTpr_Wwpnotificationid_N));
         Gx_mode = obj11.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A42WWPSMSId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0A11( ) ;
         ScanKeyStart0A11( ) ;
         if ( RcdFound11 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z42WWPSMSId = A42WWPSMSId;
         }
         ZM0A11( -8) ;
         OnLoadActions0A11( ) ;
         AddRow0A11( ) ;
         ScanKeyEnd0A11( ) ;
         if ( RcdFound11 == 0 )
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
         RowToVars11( bcwwpbaseobjects_sms_WWP_SMS, 0) ;
         ScanKeyStart0A11( ) ;
         if ( RcdFound11 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z42WWPSMSId = A42WWPSMSId;
         }
         ZM0A11( -8) ;
         OnLoadActions0A11( ) ;
         AddRow0A11( ) ;
         ScanKeyEnd0A11( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0A11( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0A11( ) ;
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( A42WWPSMSId != Z42WWPSMSId )
               {
                  A42WWPSMSId = Z42WWPSMSId;
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
                  Update0A11( ) ;
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
                  if ( A42WWPSMSId != Z42WWPSMSId )
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
                        Insert0A11( ) ;
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
                        Insert0A11( ) ;
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
         RowToVars11( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         SaveImpl( ) ;
         VarsToRow11( bcwwpbaseobjects_sms_WWP_SMS) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars11( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A11( ) ;
         AfterTrn( ) ;
         VarsToRow11( bcwwpbaseobjects_sms_WWP_SMS) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow11( bcwwpbaseobjects_sms_WWP_SMS) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS auxBC = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A42WWPSMSId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_sms_WWP_SMS);
               auxBC.Save();
               bcwwpbaseobjects_sms_WWP_SMS.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars11( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
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
         RowToVars11( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A11( ) ;
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
               VarsToRow11( bcwwpbaseobjects_sms_WWP_SMS) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow11( bcwwpbaseobjects_sms_WWP_SMS) ;
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
         RowToVars11( bcwwpbaseobjects_sms_WWP_SMS, 0) ;
         GetKey0A11( ) ;
         if ( RcdFound11 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A42WWPSMSId != Z42WWPSMSId )
            {
               A42WWPSMSId = Z42WWPSMSId;
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
            if ( A42WWPSMSId != Z42WWPSMSId )
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
         context.RollbackDataStores("wwpbaseobjects.sms.wwp_sms_bc",pr_default);
         VarsToRow11( bcwwpbaseobjects_sms_WWP_SMS) ;
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
         Gx_mode = bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_sms_WWP_SMS )
         {
            bcwwpbaseobjects_sms_WWP_SMS = (GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow11( bcwwpbaseobjects_sms_WWP_SMS) ;
            }
            else
            {
               RowToVars11( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars11( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_SMS WWP_SMS_BC
      {
         get {
            return bcwwpbaseobjects_sms_WWP_SMS ;
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
         Z49WWPSMSCreated = (DateTime)(DateTime.MinValue);
         A49WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z50WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         A50WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z44WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         A44WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         Z33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z46WWPSMSMessage = "";
         A46WWPSMSMessage = "";
         Z47WWPSMSSenderNumber = "";
         A47WWPSMSSenderNumber = "";
         Z48WWPSMSRecipientNumbers = "";
         A48WWPSMSRecipientNumbers = "";
         Z45WWPSMSDetail = "";
         A45WWPSMSDetail = "";
         BC000A5_A42WWPSMSId = new long[1] ;
         BC000A5_A46WWPSMSMessage = new string[] {""} ;
         BC000A5_A47WWPSMSSenderNumber = new string[] {""} ;
         BC000A5_A48WWPSMSRecipientNumbers = new string[] {""} ;
         BC000A5_A43WWPSMSStatus = new short[1] ;
         BC000A5_A49WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A5_A50WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000A5_A44WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000A5_n44WWPSMSProcessed = new bool[] {false} ;
         BC000A5_A45WWPSMSDetail = new string[] {""} ;
         BC000A5_n45WWPSMSDetail = new bool[] {false} ;
         BC000A5_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A5_A31WWPNotificationId = new long[1] ;
         BC000A5_n31WWPNotificationId = new bool[] {false} ;
         BC000A4_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A6_A42WWPSMSId = new long[1] ;
         BC000A3_A42WWPSMSId = new long[1] ;
         BC000A3_A46WWPSMSMessage = new string[] {""} ;
         BC000A3_A47WWPSMSSenderNumber = new string[] {""} ;
         BC000A3_A48WWPSMSRecipientNumbers = new string[] {""} ;
         BC000A3_A43WWPSMSStatus = new short[1] ;
         BC000A3_A49WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A3_A50WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000A3_A44WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000A3_n44WWPSMSProcessed = new bool[] {false} ;
         BC000A3_A45WWPSMSDetail = new string[] {""} ;
         BC000A3_n45WWPSMSDetail = new bool[] {false} ;
         BC000A3_A31WWPNotificationId = new long[1] ;
         BC000A3_n31WWPNotificationId = new bool[] {false} ;
         sMode11 = "";
         BC000A2_A42WWPSMSId = new long[1] ;
         BC000A2_A46WWPSMSMessage = new string[] {""} ;
         BC000A2_A47WWPSMSSenderNumber = new string[] {""} ;
         BC000A2_A48WWPSMSRecipientNumbers = new string[] {""} ;
         BC000A2_A43WWPSMSStatus = new short[1] ;
         BC000A2_A49WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A2_A50WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000A2_A44WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000A2_n44WWPSMSProcessed = new bool[] {false} ;
         BC000A2_A45WWPSMSDetail = new string[] {""} ;
         BC000A2_n45WWPSMSDetail = new bool[] {false} ;
         BC000A2_A31WWPNotificationId = new long[1] ;
         BC000A2_n31WWPNotificationId = new bool[] {false} ;
         BC000A7_A42WWPSMSId = new long[1] ;
         BC000A10_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A11_A42WWPSMSId = new long[1] ;
         BC000A11_A46WWPSMSMessage = new string[] {""} ;
         BC000A11_A47WWPSMSSenderNumber = new string[] {""} ;
         BC000A11_A48WWPSMSRecipientNumbers = new string[] {""} ;
         BC000A11_A43WWPSMSStatus = new short[1] ;
         BC000A11_A49WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A11_A50WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000A11_A44WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000A11_n44WWPSMSProcessed = new bool[] {false} ;
         BC000A11_A45WWPSMSDetail = new string[] {""} ;
         BC000A11_n45WWPSMSDetail = new bool[] {false} ;
         BC000A11_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A11_A31WWPNotificationId = new long[1] ;
         BC000A11_n31WWPNotificationId = new bool[] {false} ;
         i49WWPSMSCreated = (DateTime)(DateTime.MinValue);
         i50WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms_bc__default(),
            new Object[][] {
                new Object[] {
               BC000A2_A42WWPSMSId, BC000A2_A46WWPSMSMessage, BC000A2_A47WWPSMSSenderNumber, BC000A2_A48WWPSMSRecipientNumbers, BC000A2_A43WWPSMSStatus, BC000A2_A49WWPSMSCreated, BC000A2_A50WWPSMSScheduled, BC000A2_A44WWPSMSProcessed, BC000A2_n44WWPSMSProcessed, BC000A2_A45WWPSMSDetail,
               BC000A2_n45WWPSMSDetail, BC000A2_A31WWPNotificationId, BC000A2_n31WWPNotificationId
               }
               , new Object[] {
               BC000A3_A42WWPSMSId, BC000A3_A46WWPSMSMessage, BC000A3_A47WWPSMSSenderNumber, BC000A3_A48WWPSMSRecipientNumbers, BC000A3_A43WWPSMSStatus, BC000A3_A49WWPSMSCreated, BC000A3_A50WWPSMSScheduled, BC000A3_A44WWPSMSProcessed, BC000A3_n44WWPSMSProcessed, BC000A3_A45WWPSMSDetail,
               BC000A3_n45WWPSMSDetail, BC000A3_A31WWPNotificationId, BC000A3_n31WWPNotificationId
               }
               , new Object[] {
               BC000A4_A33WWPNotificationCreated
               }
               , new Object[] {
               BC000A5_A42WWPSMSId, BC000A5_A46WWPSMSMessage, BC000A5_A47WWPSMSSenderNumber, BC000A5_A48WWPSMSRecipientNumbers, BC000A5_A43WWPSMSStatus, BC000A5_A49WWPSMSCreated, BC000A5_A50WWPSMSScheduled, BC000A5_A44WWPSMSProcessed, BC000A5_n44WWPSMSProcessed, BC000A5_A45WWPSMSDetail,
               BC000A5_n45WWPSMSDetail, BC000A5_A33WWPNotificationCreated, BC000A5_A31WWPNotificationId, BC000A5_n31WWPNotificationId
               }
               , new Object[] {
               BC000A6_A42WWPSMSId
               }
               , new Object[] {
               BC000A7_A42WWPSMSId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000A10_A33WWPNotificationCreated
               }
               , new Object[] {
               BC000A11_A42WWPSMSId, BC000A11_A46WWPSMSMessage, BC000A11_A47WWPSMSSenderNumber, BC000A11_A48WWPSMSRecipientNumbers, BC000A11_A43WWPSMSStatus, BC000A11_A49WWPSMSCreated, BC000A11_A50WWPSMSScheduled, BC000A11_A44WWPSMSProcessed, BC000A11_n44WWPSMSProcessed, BC000A11_A45WWPSMSDetail,
               BC000A11_n45WWPSMSDetail, BC000A11_A33WWPNotificationCreated, BC000A11_A31WWPNotificationId, BC000A11_n31WWPNotificationId
               }
            }
         );
         Z50WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A50WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i50WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z49WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A49WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i49WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z43WWPSMSStatus = 1;
         A43WWPSMSStatus = 1;
         i43WWPSMSStatus = 1;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z43WWPSMSStatus ;
      private short A43WWPSMSStatus ;
      private short Gx_BScreen ;
      private short RcdFound11 ;
      private short i43WWPSMSStatus ;
      private int trnEnded ;
      private long Z42WWPSMSId ;
      private long A42WWPSMSId ;
      private long Z31WWPNotificationId ;
      private long A31WWPNotificationId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode11 ;
      private DateTime Z49WWPSMSCreated ;
      private DateTime A49WWPSMSCreated ;
      private DateTime Z50WWPSMSScheduled ;
      private DateTime A50WWPSMSScheduled ;
      private DateTime Z44WWPSMSProcessed ;
      private DateTime A44WWPSMSProcessed ;
      private DateTime Z33WWPNotificationCreated ;
      private DateTime A33WWPNotificationCreated ;
      private DateTime i49WWPSMSCreated ;
      private DateTime i50WWPSMSScheduled ;
      private bool n44WWPSMSProcessed ;
      private bool n45WWPSMSDetail ;
      private bool n31WWPNotificationId ;
      private string Z46WWPSMSMessage ;
      private string A46WWPSMSMessage ;
      private string Z47WWPSMSSenderNumber ;
      private string A47WWPSMSSenderNumber ;
      private string Z48WWPSMSRecipientNumbers ;
      private string A48WWPSMSRecipientNumbers ;
      private string Z45WWPSMSDetail ;
      private string A45WWPSMSDetail ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000A5_A42WWPSMSId ;
      private string[] BC000A5_A46WWPSMSMessage ;
      private string[] BC000A5_A47WWPSMSSenderNumber ;
      private string[] BC000A5_A48WWPSMSRecipientNumbers ;
      private short[] BC000A5_A43WWPSMSStatus ;
      private DateTime[] BC000A5_A49WWPSMSCreated ;
      private DateTime[] BC000A5_A50WWPSMSScheduled ;
      private DateTime[] BC000A5_A44WWPSMSProcessed ;
      private bool[] BC000A5_n44WWPSMSProcessed ;
      private string[] BC000A5_A45WWPSMSDetail ;
      private bool[] BC000A5_n45WWPSMSDetail ;
      private DateTime[] BC000A5_A33WWPNotificationCreated ;
      private long[] BC000A5_A31WWPNotificationId ;
      private bool[] BC000A5_n31WWPNotificationId ;
      private DateTime[] BC000A4_A33WWPNotificationCreated ;
      private long[] BC000A6_A42WWPSMSId ;
      private long[] BC000A3_A42WWPSMSId ;
      private string[] BC000A3_A46WWPSMSMessage ;
      private string[] BC000A3_A47WWPSMSSenderNumber ;
      private string[] BC000A3_A48WWPSMSRecipientNumbers ;
      private short[] BC000A3_A43WWPSMSStatus ;
      private DateTime[] BC000A3_A49WWPSMSCreated ;
      private DateTime[] BC000A3_A50WWPSMSScheduled ;
      private DateTime[] BC000A3_A44WWPSMSProcessed ;
      private bool[] BC000A3_n44WWPSMSProcessed ;
      private string[] BC000A3_A45WWPSMSDetail ;
      private bool[] BC000A3_n45WWPSMSDetail ;
      private long[] BC000A3_A31WWPNotificationId ;
      private bool[] BC000A3_n31WWPNotificationId ;
      private long[] BC000A2_A42WWPSMSId ;
      private string[] BC000A2_A46WWPSMSMessage ;
      private string[] BC000A2_A47WWPSMSSenderNumber ;
      private string[] BC000A2_A48WWPSMSRecipientNumbers ;
      private short[] BC000A2_A43WWPSMSStatus ;
      private DateTime[] BC000A2_A49WWPSMSCreated ;
      private DateTime[] BC000A2_A50WWPSMSScheduled ;
      private DateTime[] BC000A2_A44WWPSMSProcessed ;
      private bool[] BC000A2_n44WWPSMSProcessed ;
      private string[] BC000A2_A45WWPSMSDetail ;
      private bool[] BC000A2_n45WWPSMSDetail ;
      private long[] BC000A2_A31WWPNotificationId ;
      private bool[] BC000A2_n31WWPNotificationId ;
      private long[] BC000A7_A42WWPSMSId ;
      private DateTime[] BC000A10_A33WWPNotificationCreated ;
      private long[] BC000A11_A42WWPSMSId ;
      private string[] BC000A11_A46WWPSMSMessage ;
      private string[] BC000A11_A47WWPSMSSenderNumber ;
      private string[] BC000A11_A48WWPSMSRecipientNumbers ;
      private short[] BC000A11_A43WWPSMSStatus ;
      private DateTime[] BC000A11_A49WWPSMSCreated ;
      private DateTime[] BC000A11_A50WWPSMSScheduled ;
      private DateTime[] BC000A11_A44WWPSMSProcessed ;
      private bool[] BC000A11_n44WWPSMSProcessed ;
      private string[] BC000A11_A45WWPSMSDetail ;
      private bool[] BC000A11_n45WWPSMSDetail ;
      private DateTime[] BC000A11_A33WWPNotificationCreated ;
      private long[] BC000A11_A31WWPNotificationId ;
      private bool[] BC000A11_n31WWPNotificationId ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS bcwwpbaseobjects_sms_WWP_SMS ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_sms_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_sms_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000A2;
        prmBC000A2 = new Object[] {
        new ParDef("@WWPSMSId",GXType.Decimal,10,0)
        };
        Object[] prmBC000A3;
        prmBC000A3 = new Object[] {
        new ParDef("@WWPSMSId",GXType.Decimal,10,0)
        };
        Object[] prmBC000A4;
        prmBC000A4 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000A5;
        prmBC000A5 = new Object[] {
        new ParDef("@WWPSMSId",GXType.Decimal,10,0)
        };
        Object[] prmBC000A6;
        prmBC000A6 = new Object[] {
        new ParDef("@WWPSMSId",GXType.Decimal,10,0)
        };
        Object[] prmBC000A7;
        prmBC000A7 = new Object[] {
        new ParDef("@WWPSMSMessage",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPSMSSenderNumber",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPSMSRecipientNumbers",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPSMSStatus",GXType.Int16,4,0) ,
        new ParDef("@WWPSMSCreated",GXType.DateTime2,10,12) ,
        new ParDef("@WWPSMSScheduled",GXType.DateTime2,10,12) ,
        new ParDef("@WWPSMSProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("@WWPSMSDetail",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000A8;
        prmBC000A8 = new Object[] {
        new ParDef("@WWPSMSMessage",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPSMSSenderNumber",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPSMSRecipientNumbers",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPSMSStatus",GXType.Int16,4,0) ,
        new ParDef("@WWPSMSCreated",GXType.DateTime2,10,12) ,
        new ParDef("@WWPSMSScheduled",GXType.DateTime2,10,12) ,
        new ParDef("@WWPSMSProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("@WWPSMSDetail",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@WWPSMSId",GXType.Decimal,10,0)
        };
        Object[] prmBC000A9;
        prmBC000A9 = new Object[] {
        new ParDef("@WWPSMSId",GXType.Decimal,10,0)
        };
        Object[] prmBC000A10;
        prmBC000A10 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000A11;
        prmBC000A11 = new Object[] {
        new ParDef("@WWPSMSId",GXType.Decimal,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000A2", "SELECT [WWPSMSId], [WWPSMSMessage], [WWPSMSSenderNumber], [WWPSMSRecipientNumbers], [WWPSMSStatus], [WWPSMSCreated], [WWPSMSScheduled], [WWPSMSProcessed], [WWPSMSDetail], [WWPNotificationId] FROM [WWP_SMS] WITH (UPDLOCK) WHERE [WWPSMSId] = @WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A3", "SELECT [WWPSMSId], [WWPSMSMessage], [WWPSMSSenderNumber], [WWPSMSRecipientNumbers], [WWPSMSStatus], [WWPSMSCreated], [WWPSMSScheduled], [WWPSMSProcessed], [WWPSMSDetail], [WWPNotificationId] FROM [WWP_SMS] WHERE [WWPSMSId] = @WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A4", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A5", "SELECT TM1.[WWPSMSId], TM1.[WWPSMSMessage], TM1.[WWPSMSSenderNumber], TM1.[WWPSMSRecipientNumbers], TM1.[WWPSMSStatus], TM1.[WWPSMSCreated], TM1.[WWPSMSScheduled], TM1.[WWPSMSProcessed], TM1.[WWPSMSDetail], T2.[WWPNotificationCreated], TM1.[WWPNotificationId] FROM ([WWP_SMS] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) WHERE TM1.[WWPSMSId] = @WWPSMSId ORDER BY TM1.[WWPSMSId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A6", "SELECT [WWPSMSId] FROM [WWP_SMS] WHERE [WWPSMSId] = @WWPSMSId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A7", "INSERT INTO [WWP_SMS]([WWPSMSMessage], [WWPSMSSenderNumber], [WWPSMSRecipientNumbers], [WWPSMSStatus], [WWPSMSCreated], [WWPSMSScheduled], [WWPSMSProcessed], [WWPSMSDetail], [WWPNotificationId]) VALUES(@WWPSMSMessage, @WWPSMSSenderNumber, @WWPSMSRecipientNumbers, @WWPSMSStatus, @WWPSMSCreated, @WWPSMSScheduled, @WWPSMSProcessed, @WWPSMSDetail, @WWPNotificationId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000A8", "UPDATE [WWP_SMS] SET [WWPSMSMessage]=@WWPSMSMessage, [WWPSMSSenderNumber]=@WWPSMSSenderNumber, [WWPSMSRecipientNumbers]=@WWPSMSRecipientNumbers, [WWPSMSStatus]=@WWPSMSStatus, [WWPSMSCreated]=@WWPSMSCreated, [WWPSMSScheduled]=@WWPSMSScheduled, [WWPSMSProcessed]=@WWPSMSProcessed, [WWPSMSDetail]=@WWPSMSDetail, [WWPNotificationId]=@WWPNotificationId  WHERE [WWPSMSId] = @WWPSMSId", GxErrorMask.GX_NOMASK,prmBC000A8)
           ,new CursorDef("BC000A9", "DELETE FROM [WWP_SMS]  WHERE [WWPSMSId] = @WWPSMSId", GxErrorMask.GX_NOMASK,prmBC000A9)
           ,new CursorDef("BC000A10", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A11", "SELECT TM1.[WWPSMSId], TM1.[WWPSMSMessage], TM1.[WWPSMSSenderNumber], TM1.[WWPSMSRecipientNumbers], TM1.[WWPSMSStatus], TM1.[WWPSMSCreated], TM1.[WWPSMSScheduled], TM1.[WWPSMSProcessed], TM1.[WWPSMSDetail], T2.[WWPNotificationCreated], TM1.[WWPNotificationId] FROM ([WWP_SMS] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) WHERE TM1.[WWPSMSId] = @WWPSMSId ORDER BY TM1.[WWPSMSId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((long[]) buf[11])[0] = rslt.getLong(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((long[]) buf[11])[0] = rslt.getLong(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
              ((long[]) buf[12])[0] = rslt.getLong(11);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
              ((long[]) buf[12])[0] = rslt.getLong(11);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              return;
     }
  }

}

}
