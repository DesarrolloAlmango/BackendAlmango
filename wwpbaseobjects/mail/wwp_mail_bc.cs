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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_mail_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_mail_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_mail_bc( IGxContext context )
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
         ReadRow0G17( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0G17( ) ;
         standaloneModal( ) ;
         AddRow0G17( ) ;
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
               Z89WWPMailId = A89WWPMailId;
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

      protected void CONFIRM_0G0( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0G17( ) ;
            }
            else
            {
               CheckExtendedTable0G17( ) ;
               if ( AnyError == 0 )
               {
                  ZM0G17( 9) ;
               }
               CloseExtendedTableCursors0G17( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode17 = Gx_mode;
            CONFIRM_0G18( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode17;
            }
            /* Restore parent mode. */
            Gx_mode = sMode17;
         }
      }

      protected void CONFIRM_0G18( )
      {
         nGXsfl_18_idx = 0;
         while ( nGXsfl_18_idx < bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Count )
         {
            ReadRow0G18( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound18 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_18 != 0 ) )
            {
               GetKey0G18( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound18 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0G18( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0G18( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0G18( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound18 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0G18( ) ;
                        Load0G18( ) ;
                        BeforeValidate0G18( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0G18( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_18 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0G18( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0G18( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0G18( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow18( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_18_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ZM0G17( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z78WWPMailSubject = A78WWPMailSubject;
            Z90WWPMailStatus = A90WWPMailStatus;
            Z100WWPMailCreated = A100WWPMailCreated;
            Z101WWPMailScheduled = A101WWPMailScheduled;
            Z95WWPMailProcessed = A95WWPMailProcessed;
            Z31WWPNotificationId = A31WWPNotificationId;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z33WWPNotificationCreated = A33WWPNotificationCreated;
         }
         if ( GX_JID == -8 )
         {
            Z89WWPMailId = A89WWPMailId;
            Z78WWPMailSubject = A78WWPMailSubject;
            Z70WWPMailBody = A70WWPMailBody;
            Z79WWPMailTo = A79WWPMailTo;
            Z92WWPMailCC = A92WWPMailCC;
            Z93WWPMailBCC = A93WWPMailBCC;
            Z80WWPMailSenderAddress = A80WWPMailSenderAddress;
            Z81WWPMailSenderName = A81WWPMailSenderName;
            Z90WWPMailStatus = A90WWPMailStatus;
            Z100WWPMailCreated = A100WWPMailCreated;
            Z101WWPMailScheduled = A101WWPMailScheduled;
            Z95WWPMailProcessed = A95WWPMailProcessed;
            Z96WWPMailDetail = A96WWPMailDetail;
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
         if ( IsIns( )  && (0==A90WWPMailStatus) && ( Gx_BScreen == 0 ) )
         {
            A90WWPMailStatus = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A100WWPMailCreated) && ( Gx_BScreen == 0 ) )
         {
            A100WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A101WWPMailScheduled) && ( Gx_BScreen == 0 ) )
         {
            A101WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0G17( )
      {
         /* Using cursor BC000G7 */
         pr_default.execute(5, new Object[] {A89WWPMailId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound17 = 1;
            A78WWPMailSubject = BC000G7_A78WWPMailSubject[0];
            A70WWPMailBody = BC000G7_A70WWPMailBody[0];
            A79WWPMailTo = BC000G7_A79WWPMailTo[0];
            n79WWPMailTo = BC000G7_n79WWPMailTo[0];
            A92WWPMailCC = BC000G7_A92WWPMailCC[0];
            n92WWPMailCC = BC000G7_n92WWPMailCC[0];
            A93WWPMailBCC = BC000G7_A93WWPMailBCC[0];
            n93WWPMailBCC = BC000G7_n93WWPMailBCC[0];
            A80WWPMailSenderAddress = BC000G7_A80WWPMailSenderAddress[0];
            A81WWPMailSenderName = BC000G7_A81WWPMailSenderName[0];
            A90WWPMailStatus = BC000G7_A90WWPMailStatus[0];
            A100WWPMailCreated = BC000G7_A100WWPMailCreated[0];
            A101WWPMailScheduled = BC000G7_A101WWPMailScheduled[0];
            A95WWPMailProcessed = BC000G7_A95WWPMailProcessed[0];
            n95WWPMailProcessed = BC000G7_n95WWPMailProcessed[0];
            A96WWPMailDetail = BC000G7_A96WWPMailDetail[0];
            n96WWPMailDetail = BC000G7_n96WWPMailDetail[0];
            A33WWPNotificationCreated = BC000G7_A33WWPNotificationCreated[0];
            A31WWPNotificationId = BC000G7_A31WWPNotificationId[0];
            n31WWPNotificationId = BC000G7_n31WWPNotificationId[0];
            ZM0G17( -8) ;
         }
         pr_default.close(5);
         OnLoadActions0G17( ) ;
      }

      protected void OnLoadActions0G17( )
      {
      }

      protected void CheckExtendedTable0G17( )
      {
         standaloneModal( ) ;
         if ( ! ( ( A90WWPMailStatus == 1 ) || ( A90WWPMailStatus == 2 ) || ( A90WWPMailStatus == 3 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Mail Status", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A100WWPMailCreated) || ( A100WWPMailCreated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Mail Created", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A101WWPMailScheduled) || ( A101WWPMailScheduled >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Mail Scheduled", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A95WWPMailProcessed) || ( A95WWPMailProcessed >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Mail Processed", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000G6 */
         pr_default.execute(4, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A31WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
            }
         }
         A33WWPNotificationCreated = BC000G6_A33WWPNotificationCreated[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0G17( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0G17( )
      {
         /* Using cursor BC000G8 */
         pr_default.execute(6, new Object[] {A89WWPMailId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000G5 */
         pr_default.execute(3, new Object[] {A89WWPMailId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0G17( 8) ;
            RcdFound17 = 1;
            A89WWPMailId = BC000G5_A89WWPMailId[0];
            A78WWPMailSubject = BC000G5_A78WWPMailSubject[0];
            A70WWPMailBody = BC000G5_A70WWPMailBody[0];
            A79WWPMailTo = BC000G5_A79WWPMailTo[0];
            n79WWPMailTo = BC000G5_n79WWPMailTo[0];
            A92WWPMailCC = BC000G5_A92WWPMailCC[0];
            n92WWPMailCC = BC000G5_n92WWPMailCC[0];
            A93WWPMailBCC = BC000G5_A93WWPMailBCC[0];
            n93WWPMailBCC = BC000G5_n93WWPMailBCC[0];
            A80WWPMailSenderAddress = BC000G5_A80WWPMailSenderAddress[0];
            A81WWPMailSenderName = BC000G5_A81WWPMailSenderName[0];
            A90WWPMailStatus = BC000G5_A90WWPMailStatus[0];
            A100WWPMailCreated = BC000G5_A100WWPMailCreated[0];
            A101WWPMailScheduled = BC000G5_A101WWPMailScheduled[0];
            A95WWPMailProcessed = BC000G5_A95WWPMailProcessed[0];
            n95WWPMailProcessed = BC000G5_n95WWPMailProcessed[0];
            A96WWPMailDetail = BC000G5_A96WWPMailDetail[0];
            n96WWPMailDetail = BC000G5_n96WWPMailDetail[0];
            A31WWPNotificationId = BC000G5_A31WWPNotificationId[0];
            n31WWPNotificationId = BC000G5_n31WWPNotificationId[0];
            Z89WWPMailId = A89WWPMailId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0G17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0G17( ) ;
            }
            Gx_mode = sMode17;
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0G17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode17;
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G17( ) ;
         if ( RcdFound17 == 0 )
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
         CONFIRM_0G0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0G17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000G4 */
            pr_default.execute(2, new Object[] {A89WWPMailId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z78WWPMailSubject, BC000G4_A78WWPMailSubject[0]) != 0 ) || ( Z90WWPMailStatus != BC000G4_A90WWPMailStatus[0] ) || ( Z100WWPMailCreated != BC000G4_A100WWPMailCreated[0] ) || ( Z101WWPMailScheduled != BC000G4_A101WWPMailScheduled[0] ) || ( Z95WWPMailProcessed != BC000G4_A95WWPMailProcessed[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z31WWPNotificationId != BC000G4_A31WWPNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Mail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G17( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G17( 0) ;
            CheckOptimisticConcurrency0G17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G9 */
                     pr_default.execute(7, new Object[] {A78WWPMailSubject, A70WWPMailBody, n79WWPMailTo, A79WWPMailTo, n92WWPMailCC, A92WWPMailCC, n93WWPMailBCC, A93WWPMailBCC, A80WWPMailSenderAddress, A81WWPMailSenderName, A90WWPMailStatus, A100WWPMailCreated, A101WWPMailScheduled, n95WWPMailProcessed, A95WWPMailProcessed, n96WWPMailDetail, A96WWPMailDetail, n31WWPNotificationId, A31WWPNotificationId});
                     A89WWPMailId = BC000G9_A89WWPMailId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0G17( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load0G17( ) ;
            }
            EndLevel0G17( ) ;
         }
         CloseExtendedTableCursors0G17( ) ;
      }

      protected void Update0G17( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G10 */
                     pr_default.execute(8, new Object[] {A78WWPMailSubject, A70WWPMailBody, n79WWPMailTo, A79WWPMailTo, n92WWPMailCC, A92WWPMailCC, n93WWPMailBCC, A93WWPMailBCC, A80WWPMailSenderAddress, A81WWPMailSenderName, A90WWPMailStatus, A100WWPMailCreated, A101WWPMailScheduled, n95WWPMailProcessed, A95WWPMailProcessed, n96WWPMailDetail, A96WWPMailDetail, n31WWPNotificationId, A31WWPNotificationId, A89WWPMailId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G17( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0G17( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel0G17( ) ;
         }
         CloseExtendedTableCursors0G17( ) ;
      }

      protected void DeferredUpdate0G17( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G17( ) ;
            AfterConfirm0G17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G17( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0G18( ) ;
                  while ( RcdFound18 != 0 )
                  {
                     getByPrimaryKey0G18( ) ;
                     Delete0G18( ) ;
                     ScanKeyNext0G18( ) ;
                  }
                  ScanKeyEnd0G18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G11 */
                     pr_default.execute(9, new Object[] {A89WWPMailId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
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
         }
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0G17( ) ;
         Gx_mode = sMode17;
      }

      protected void OnDeleteControls0G17( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000G12 */
            pr_default.execute(10, new Object[] {n31WWPNotificationId, A31WWPNotificationId});
            A33WWPNotificationCreated = BC000G12_A33WWPNotificationCreated[0];
            pr_default.close(10);
         }
      }

      protected void ProcessNestedLevel0G18( )
      {
         nGXsfl_18_idx = 0;
         while ( nGXsfl_18_idx < bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Count )
         {
            ReadRow0G18( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound18 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_18 != 0 ) )
            {
               standaloneNotModal0G18( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0G18( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0G18( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0G18( ) ;
                  }
               }
            }
            KeyVarsToRow18( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_18_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_18_idx = 0;
            while ( nGXsfl_18_idx < bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Count )
            {
               ReadRow0G18( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound18 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.RemoveElement(nGXsfl_18_idx);
                  nGXsfl_18_idx = (int)(nGXsfl_18_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0G18( ) ;
                  VarsToRow18( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_18_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0G18( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_18 = 0;
         nIsMod_18 = 0;
      }

      protected void ProcessLevel0G17( )
      {
         /* Save parent mode. */
         sMode17 = Gx_mode;
         ProcessNestedLevel0G18( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode17;
         /* ' Update level parameters */
      }

      protected void EndLevel0G17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G17( ) ;
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

      public void ScanKeyStart0G17( )
      {
         /* Using cursor BC000G13 */
         pr_default.execute(11, new Object[] {A89WWPMailId});
         RcdFound17 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound17 = 1;
            A89WWPMailId = BC000G13_A89WWPMailId[0];
            A78WWPMailSubject = BC000G13_A78WWPMailSubject[0];
            A70WWPMailBody = BC000G13_A70WWPMailBody[0];
            A79WWPMailTo = BC000G13_A79WWPMailTo[0];
            n79WWPMailTo = BC000G13_n79WWPMailTo[0];
            A92WWPMailCC = BC000G13_A92WWPMailCC[0];
            n92WWPMailCC = BC000G13_n92WWPMailCC[0];
            A93WWPMailBCC = BC000G13_A93WWPMailBCC[0];
            n93WWPMailBCC = BC000G13_n93WWPMailBCC[0];
            A80WWPMailSenderAddress = BC000G13_A80WWPMailSenderAddress[0];
            A81WWPMailSenderName = BC000G13_A81WWPMailSenderName[0];
            A90WWPMailStatus = BC000G13_A90WWPMailStatus[0];
            A100WWPMailCreated = BC000G13_A100WWPMailCreated[0];
            A101WWPMailScheduled = BC000G13_A101WWPMailScheduled[0];
            A95WWPMailProcessed = BC000G13_A95WWPMailProcessed[0];
            n95WWPMailProcessed = BC000G13_n95WWPMailProcessed[0];
            A96WWPMailDetail = BC000G13_A96WWPMailDetail[0];
            n96WWPMailDetail = BC000G13_n96WWPMailDetail[0];
            A33WWPNotificationCreated = BC000G13_A33WWPNotificationCreated[0];
            A31WWPNotificationId = BC000G13_A31WWPNotificationId[0];
            n31WWPNotificationId = BC000G13_n31WWPNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0G17( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound17 = 0;
         ScanKeyLoad0G17( ) ;
      }

      protected void ScanKeyLoad0G17( )
      {
         sMode17 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound17 = 1;
            A89WWPMailId = BC000G13_A89WWPMailId[0];
            A78WWPMailSubject = BC000G13_A78WWPMailSubject[0];
            A70WWPMailBody = BC000G13_A70WWPMailBody[0];
            A79WWPMailTo = BC000G13_A79WWPMailTo[0];
            n79WWPMailTo = BC000G13_n79WWPMailTo[0];
            A92WWPMailCC = BC000G13_A92WWPMailCC[0];
            n92WWPMailCC = BC000G13_n92WWPMailCC[0];
            A93WWPMailBCC = BC000G13_A93WWPMailBCC[0];
            n93WWPMailBCC = BC000G13_n93WWPMailBCC[0];
            A80WWPMailSenderAddress = BC000G13_A80WWPMailSenderAddress[0];
            A81WWPMailSenderName = BC000G13_A81WWPMailSenderName[0];
            A90WWPMailStatus = BC000G13_A90WWPMailStatus[0];
            A100WWPMailCreated = BC000G13_A100WWPMailCreated[0];
            A101WWPMailScheduled = BC000G13_A101WWPMailScheduled[0];
            A95WWPMailProcessed = BC000G13_A95WWPMailProcessed[0];
            n95WWPMailProcessed = BC000G13_n95WWPMailProcessed[0];
            A96WWPMailDetail = BC000G13_A96WWPMailDetail[0];
            n96WWPMailDetail = BC000G13_n96WWPMailDetail[0];
            A33WWPNotificationCreated = BC000G13_A33WWPNotificationCreated[0];
            A31WWPNotificationId = BC000G13_A31WWPNotificationId[0];
            n31WWPNotificationId = BC000G13_n31WWPNotificationId[0];
         }
         Gx_mode = sMode17;
      }

      protected void ScanKeyEnd0G17( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0G17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G17( )
      {
      }

      protected void ZM0G18( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -10 )
         {
            Z89WWPMailId = A89WWPMailId;
            Z102WWPMailAttachmentName = A102WWPMailAttachmentName;
            Z94WWPMailAttachmentFile = A94WWPMailAttachmentFile;
         }
      }

      protected void standaloneNotModal0G18( )
      {
      }

      protected void standaloneModal0G18( )
      {
      }

      protected void Load0G18( )
      {
         /* Using cursor BC000G14 */
         pr_default.execute(12, new Object[] {A89WWPMailId, A102WWPMailAttachmentName});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound18 = 1;
            A94WWPMailAttachmentFile = BC000G14_A94WWPMailAttachmentFile[0];
            ZM0G18( -10) ;
         }
         pr_default.close(12);
         OnLoadActions0G18( ) ;
      }

      protected void OnLoadActions0G18( )
      {
      }

      protected void CheckExtendedTable0G18( )
      {
         Gx_BScreen = 1;
         standaloneModal0G18( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors0G18( )
      {
      }

      protected void enableDisable0G18( )
      {
      }

      protected void GetKey0G18( )
      {
         /* Using cursor BC000G15 */
         pr_default.execute(13, new Object[] {A89WWPMailId, A102WWPMailAttachmentName});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey0G18( )
      {
         /* Using cursor BC000G3 */
         pr_default.execute(1, new Object[] {A89WWPMailId, A102WWPMailAttachmentName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G18( 10) ;
            RcdFound18 = 1;
            InitializeNonKey0G18( ) ;
            A102WWPMailAttachmentName = BC000G3_A102WWPMailAttachmentName[0];
            A94WWPMailAttachmentFile = BC000G3_A94WWPMailAttachmentFile[0];
            Z89WWPMailId = A89WWPMailId;
            Z102WWPMailAttachmentName = A102WWPMailAttachmentName;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0G18( ) ;
            Load0G18( ) ;
            Gx_mode = sMode18;
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0G18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0G18( ) ;
            Gx_mode = sMode18;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0G18( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0G18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000G2 */
            pr_default.execute(0, new Object[] {A89WWPMailId, A102WWPMailAttachmentName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailAttachments"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G18( )
      {
         BeforeValidate0G18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G18( 0) ;
            CheckOptimisticConcurrency0G18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G16 */
                     pr_default.execute(14, new Object[] {A89WWPMailId, A102WWPMailAttachmentName, A94WWPMailAttachmentFile});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                     if ( (pr_default.getStatus(14) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load0G18( ) ;
            }
            EndLevel0G18( ) ;
         }
         CloseExtendedTableCursors0G18( ) ;
      }

      protected void Update0G18( )
      {
         BeforeValidate0G18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G18( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G17 */
                     pr_default.execute(15, new Object[] {A94WWPMailAttachmentFile, A89WWPMailId, A102WWPMailAttachmentName});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G18( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0G18( ) ;
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
            EndLevel0G18( ) ;
         }
         CloseExtendedTableCursors0G18( ) ;
      }

      protected void DeferredUpdate0G18( )
      {
      }

      protected void Delete0G18( )
      {
         Gx_mode = "DLT";
         BeforeValidate0G18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G18( ) ;
            AfterConfirm0G18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000G18 */
                  pr_default.execute(16, new Object[] {A89WWPMailId, A102WWPMailAttachmentName});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0G18( ) ;
         Gx_mode = sMode18;
      }

      protected void OnDeleteControls0G18( )
      {
         standaloneModal0G18( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0G18( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0G18( )
      {
         /* Scan By routine */
         /* Using cursor BC000G19 */
         pr_default.execute(17, new Object[] {A89WWPMailId});
         RcdFound18 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound18 = 1;
            A102WWPMailAttachmentName = BC000G19_A102WWPMailAttachmentName[0];
            A94WWPMailAttachmentFile = BC000G19_A94WWPMailAttachmentFile[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0G18( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound18 = 0;
         ScanKeyLoad0G18( ) ;
      }

      protected void ScanKeyLoad0G18( )
      {
         sMode18 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound18 = 1;
            A102WWPMailAttachmentName = BC000G19_A102WWPMailAttachmentName[0];
            A94WWPMailAttachmentFile = BC000G19_A94WWPMailAttachmentFile[0];
         }
         Gx_mode = sMode18;
      }

      protected void ScanKeyEnd0G18( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0G18( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G18( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G18( )
      {
      }

      protected void send_integrity_lvl_hashes0G18( )
      {
      }

      protected void send_integrity_lvl_hashes0G17( )
      {
      }

      protected void AddRow0G17( )
      {
         VarsToRow17( bcwwpbaseobjects_mail_WWP_Mail) ;
      }

      protected void ReadRow0G17( )
      {
         RowToVars17( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
      }

      protected void AddRow0G18( )
      {
         GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj18;
         obj18 = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments(context);
         VarsToRow18( obj18) ;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Add(obj18, 0);
         obj18.gxTpr_Mode = "UPD";
         obj18.gxTpr_Modified = 0;
      }

      protected void ReadRow0G18( )
      {
         nGXsfl_18_idx = (int)(nGXsfl_18_idx+1);
         RowToVars18( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_18_idx)), 1) ;
      }

      protected void InitializeNonKey0G17( )
      {
         A78WWPMailSubject = "";
         A70WWPMailBody = "";
         A79WWPMailTo = "";
         n79WWPMailTo = false;
         A92WWPMailCC = "";
         n92WWPMailCC = false;
         A93WWPMailBCC = "";
         n93WWPMailBCC = false;
         A80WWPMailSenderAddress = "";
         A81WWPMailSenderName = "";
         A95WWPMailProcessed = (DateTime)(DateTime.MinValue);
         n95WWPMailProcessed = false;
         A96WWPMailDetail = "";
         n96WWPMailDetail = false;
         A31WWPNotificationId = 0;
         n31WWPNotificationId = false;
         A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A90WWPMailStatus = 1;
         A100WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A101WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z78WWPMailSubject = "";
         Z90WWPMailStatus = 0;
         Z100WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z101WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z95WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z31WWPNotificationId = 0;
      }

      protected void InitAll0G17( )
      {
         A89WWPMailId = 0;
         InitializeNonKey0G17( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A90WWPMailStatus = i90WWPMailStatus;
         A100WWPMailCreated = i100WWPMailCreated;
         A101WWPMailScheduled = i101WWPMailScheduled;
      }

      protected void InitializeNonKey0G18( )
      {
         A94WWPMailAttachmentFile = "";
      }

      protected void InitAll0G18( )
      {
         A102WWPMailAttachmentName = "";
         InitializeNonKey0G18( ) ;
      }

      protected void StandaloneModalInsert0G18( )
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

      public void VarsToRow17( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail obj17 )
      {
         obj17.gxTpr_Mode = Gx_mode;
         obj17.gxTpr_Wwpmailsubject = A78WWPMailSubject;
         obj17.gxTpr_Wwpmailbody = A70WWPMailBody;
         obj17.gxTpr_Wwpmailto = A79WWPMailTo;
         obj17.gxTpr_Wwpmailcc = A92WWPMailCC;
         obj17.gxTpr_Wwpmailbcc = A93WWPMailBCC;
         obj17.gxTpr_Wwpmailsenderaddress = A80WWPMailSenderAddress;
         obj17.gxTpr_Wwpmailsendername = A81WWPMailSenderName;
         obj17.gxTpr_Wwpmailprocessed = A95WWPMailProcessed;
         obj17.gxTpr_Wwpmaildetail = A96WWPMailDetail;
         obj17.gxTpr_Wwpnotificationid = A31WWPNotificationId;
         obj17.gxTpr_Wwpnotificationcreated = A33WWPNotificationCreated;
         obj17.gxTpr_Wwpmailstatus = A90WWPMailStatus;
         obj17.gxTpr_Wwpmailcreated = A100WWPMailCreated;
         obj17.gxTpr_Wwpmailscheduled = A101WWPMailScheduled;
         obj17.gxTpr_Wwpmailid = A89WWPMailId;
         obj17.gxTpr_Wwpmailid_Z = Z89WWPMailId;
         obj17.gxTpr_Wwpmailsubject_Z = Z78WWPMailSubject;
         obj17.gxTpr_Wwpmailstatus_Z = Z90WWPMailStatus;
         obj17.gxTpr_Wwpmailcreated_Z = Z100WWPMailCreated;
         obj17.gxTpr_Wwpmailscheduled_Z = Z101WWPMailScheduled;
         obj17.gxTpr_Wwpmailprocessed_Z = Z95WWPMailProcessed;
         obj17.gxTpr_Wwpnotificationid_Z = Z31WWPNotificationId;
         obj17.gxTpr_Wwpnotificationcreated_Z = Z33WWPNotificationCreated;
         obj17.gxTpr_Wwpmailto_N = (short)(Convert.ToInt16(n79WWPMailTo));
         obj17.gxTpr_Wwpmailcc_N = (short)(Convert.ToInt16(n92WWPMailCC));
         obj17.gxTpr_Wwpmailbcc_N = (short)(Convert.ToInt16(n93WWPMailBCC));
         obj17.gxTpr_Wwpmailprocessed_N = (short)(Convert.ToInt16(n95WWPMailProcessed));
         obj17.gxTpr_Wwpmaildetail_N = (short)(Convert.ToInt16(n96WWPMailDetail));
         obj17.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n31WWPNotificationId));
         obj17.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow17( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail obj17 )
      {
         obj17.gxTpr_Wwpmailid = A89WWPMailId;
         return  ;
      }

      public void RowToVars17( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail obj17 ,
                               int forceLoad )
      {
         Gx_mode = obj17.gxTpr_Mode;
         A78WWPMailSubject = obj17.gxTpr_Wwpmailsubject;
         A70WWPMailBody = obj17.gxTpr_Wwpmailbody;
         A79WWPMailTo = obj17.gxTpr_Wwpmailto;
         n79WWPMailTo = false;
         A92WWPMailCC = obj17.gxTpr_Wwpmailcc;
         n92WWPMailCC = false;
         A93WWPMailBCC = obj17.gxTpr_Wwpmailbcc;
         n93WWPMailBCC = false;
         A80WWPMailSenderAddress = obj17.gxTpr_Wwpmailsenderaddress;
         A81WWPMailSenderName = obj17.gxTpr_Wwpmailsendername;
         A95WWPMailProcessed = obj17.gxTpr_Wwpmailprocessed;
         n95WWPMailProcessed = false;
         A96WWPMailDetail = obj17.gxTpr_Wwpmaildetail;
         n96WWPMailDetail = false;
         A31WWPNotificationId = obj17.gxTpr_Wwpnotificationid;
         n31WWPNotificationId = false;
         A33WWPNotificationCreated = obj17.gxTpr_Wwpnotificationcreated;
         A90WWPMailStatus = obj17.gxTpr_Wwpmailstatus;
         A100WWPMailCreated = obj17.gxTpr_Wwpmailcreated;
         A101WWPMailScheduled = obj17.gxTpr_Wwpmailscheduled;
         A89WWPMailId = obj17.gxTpr_Wwpmailid;
         Z89WWPMailId = obj17.gxTpr_Wwpmailid_Z;
         Z78WWPMailSubject = obj17.gxTpr_Wwpmailsubject_Z;
         Z90WWPMailStatus = obj17.gxTpr_Wwpmailstatus_Z;
         Z100WWPMailCreated = obj17.gxTpr_Wwpmailcreated_Z;
         Z101WWPMailScheduled = obj17.gxTpr_Wwpmailscheduled_Z;
         Z95WWPMailProcessed = obj17.gxTpr_Wwpmailprocessed_Z;
         Z31WWPNotificationId = obj17.gxTpr_Wwpnotificationid_Z;
         Z33WWPNotificationCreated = obj17.gxTpr_Wwpnotificationcreated_Z;
         n79WWPMailTo = (bool)(Convert.ToBoolean(obj17.gxTpr_Wwpmailto_N));
         n92WWPMailCC = (bool)(Convert.ToBoolean(obj17.gxTpr_Wwpmailcc_N));
         n93WWPMailBCC = (bool)(Convert.ToBoolean(obj17.gxTpr_Wwpmailbcc_N));
         n95WWPMailProcessed = (bool)(Convert.ToBoolean(obj17.gxTpr_Wwpmailprocessed_N));
         n96WWPMailDetail = (bool)(Convert.ToBoolean(obj17.gxTpr_Wwpmaildetail_N));
         n31WWPNotificationId = (bool)(Convert.ToBoolean(obj17.gxTpr_Wwpnotificationid_N));
         Gx_mode = obj17.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow18( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj18 )
      {
         obj18.gxTpr_Mode = Gx_mode;
         obj18.gxTpr_Wwpmailattachmentfile = A94WWPMailAttachmentFile;
         obj18.gxTpr_Wwpmailattachmentname = A102WWPMailAttachmentName;
         obj18.gxTpr_Wwpmailattachmentname_Z = Z102WWPMailAttachmentName;
         obj18.gxTpr_Modified = nIsMod_18;
         return  ;
      }

      public void KeyVarsToRow18( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj18 )
      {
         obj18.gxTpr_Wwpmailattachmentname = A102WWPMailAttachmentName;
         return  ;
      }

      public void RowToVars18( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj18 ,
                               int forceLoad )
      {
         Gx_mode = obj18.gxTpr_Mode;
         A94WWPMailAttachmentFile = obj18.gxTpr_Wwpmailattachmentfile;
         A102WWPMailAttachmentName = obj18.gxTpr_Wwpmailattachmentname;
         Z102WWPMailAttachmentName = obj18.gxTpr_Wwpmailattachmentname_Z;
         nIsMod_18 = obj18.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A89WWPMailId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0G17( ) ;
         ScanKeyStart0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z89WWPMailId = A89WWPMailId;
         }
         ZM0G17( -8) ;
         OnLoadActions0G17( ) ;
         AddRow0G17( ) ;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.ClearCollection();
         if ( RcdFound17 == 1 )
         {
            ScanKeyStart0G18( ) ;
            nGXsfl_18_idx = 1;
            while ( RcdFound18 != 0 )
            {
               Z89WWPMailId = A89WWPMailId;
               Z102WWPMailAttachmentName = A102WWPMailAttachmentName;
               ZM0G18( -10) ;
               OnLoadActions0G18( ) ;
               nRcdExists_18 = 1;
               nIsMod_18 = 0;
               AddRow0G18( ) ;
               nGXsfl_18_idx = (int)(nGXsfl_18_idx+1);
               ScanKeyNext0G18( ) ;
            }
            ScanKeyEnd0G18( ) ;
         }
         ScanKeyEnd0G17( ) ;
         if ( RcdFound17 == 0 )
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
         RowToVars17( bcwwpbaseobjects_mail_WWP_Mail, 0) ;
         ScanKeyStart0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z89WWPMailId = A89WWPMailId;
         }
         ZM0G17( -8) ;
         OnLoadActions0G17( ) ;
         AddRow0G17( ) ;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.ClearCollection();
         if ( RcdFound17 == 1 )
         {
            ScanKeyStart0G18( ) ;
            nGXsfl_18_idx = 1;
            while ( RcdFound18 != 0 )
            {
               Z89WWPMailId = A89WWPMailId;
               Z102WWPMailAttachmentName = A102WWPMailAttachmentName;
               ZM0G18( -10) ;
               OnLoadActions0G18( ) ;
               nRcdExists_18 = 1;
               nIsMod_18 = 0;
               AddRow0G18( ) ;
               nGXsfl_18_idx = (int)(nGXsfl_18_idx+1);
               ScanKeyNext0G18( ) ;
            }
            ScanKeyEnd0G18( ) ;
         }
         ScanKeyEnd0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0G17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0G17( ) ;
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A89WWPMailId != Z89WWPMailId )
               {
                  A89WWPMailId = Z89WWPMailId;
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
                  Update0G17( ) ;
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
                  if ( A89WWPMailId != Z89WWPMailId )
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
                        Insert0G17( ) ;
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
                        Insert0G17( ) ;
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
         RowToVars17( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         SaveImpl( ) ;
         VarsToRow17( bcwwpbaseobjects_mail_WWP_Mail) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars17( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0G17( ) ;
         AfterTrn( ) ;
         VarsToRow17( bcwwpbaseobjects_mail_WWP_Mail) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow17( bcwwpbaseobjects_mail_WWP_Mail) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail auxBC = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A89WWPMailId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_mail_WWP_Mail);
               auxBC.Save();
               bcwwpbaseobjects_mail_WWP_Mail.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars17( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
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
         RowToVars17( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0G17( ) ;
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
               VarsToRow17( bcwwpbaseobjects_mail_WWP_Mail) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow17( bcwwpbaseobjects_mail_WWP_Mail) ;
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
         RowToVars17( bcwwpbaseobjects_mail_WWP_Mail, 0) ;
         GetKey0G17( ) ;
         if ( RcdFound17 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A89WWPMailId != Z89WWPMailId )
            {
               A89WWPMailId = Z89WWPMailId;
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
            if ( A89WWPMailId != Z89WWPMailId )
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
         pr_default.close(3);
         pr_default.close(1);
         pr_default.close(10);
         context.RollbackDataStores("wwpbaseobjects.mail.wwp_mail_bc",pr_default);
         VarsToRow17( bcwwpbaseobjects_mail_WWP_Mail) ;
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
         Gx_mode = bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_mail_WWP_Mail )
         {
            bcwwpbaseobjects_mail_WWP_Mail = (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow17( bcwwpbaseobjects_mail_WWP_Mail) ;
            }
            else
            {
               RowToVars17( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars17( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_Mail WWP_Mail_BC
      {
         get {
            return bcwwpbaseobjects_mail_WWP_Mail ;
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
         pr_default.close(3);
         pr_default.close(10);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode17 = "";
         Z78WWPMailSubject = "";
         A78WWPMailSubject = "";
         Z100WWPMailCreated = (DateTime)(DateTime.MinValue);
         A100WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z101WWPMailScheduled = (DateTime)(DateTime.MinValue);
         A101WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z95WWPMailProcessed = (DateTime)(DateTime.MinValue);
         A95WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z70WWPMailBody = "";
         A70WWPMailBody = "";
         Z79WWPMailTo = "";
         A79WWPMailTo = "";
         Z92WWPMailCC = "";
         A92WWPMailCC = "";
         Z93WWPMailBCC = "";
         A93WWPMailBCC = "";
         Z80WWPMailSenderAddress = "";
         A80WWPMailSenderAddress = "";
         Z81WWPMailSenderName = "";
         A81WWPMailSenderName = "";
         Z96WWPMailDetail = "";
         A96WWPMailDetail = "";
         BC000G7_A89WWPMailId = new long[1] ;
         BC000G7_A78WWPMailSubject = new string[] {""} ;
         BC000G7_A70WWPMailBody = new string[] {""} ;
         BC000G7_A79WWPMailTo = new string[] {""} ;
         BC000G7_n79WWPMailTo = new bool[] {false} ;
         BC000G7_A92WWPMailCC = new string[] {""} ;
         BC000G7_n92WWPMailCC = new bool[] {false} ;
         BC000G7_A93WWPMailBCC = new string[] {""} ;
         BC000G7_n93WWPMailBCC = new bool[] {false} ;
         BC000G7_A80WWPMailSenderAddress = new string[] {""} ;
         BC000G7_A81WWPMailSenderName = new string[] {""} ;
         BC000G7_A90WWPMailStatus = new short[1] ;
         BC000G7_A100WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000G7_A101WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000G7_A95WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000G7_n95WWPMailProcessed = new bool[] {false} ;
         BC000G7_A96WWPMailDetail = new string[] {""} ;
         BC000G7_n96WWPMailDetail = new bool[] {false} ;
         BC000G7_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000G7_A31WWPNotificationId = new long[1] ;
         BC000G7_n31WWPNotificationId = new bool[] {false} ;
         BC000G6_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000G8_A89WWPMailId = new long[1] ;
         BC000G5_A89WWPMailId = new long[1] ;
         BC000G5_A78WWPMailSubject = new string[] {""} ;
         BC000G5_A70WWPMailBody = new string[] {""} ;
         BC000G5_A79WWPMailTo = new string[] {""} ;
         BC000G5_n79WWPMailTo = new bool[] {false} ;
         BC000G5_A92WWPMailCC = new string[] {""} ;
         BC000G5_n92WWPMailCC = new bool[] {false} ;
         BC000G5_A93WWPMailBCC = new string[] {""} ;
         BC000G5_n93WWPMailBCC = new bool[] {false} ;
         BC000G5_A80WWPMailSenderAddress = new string[] {""} ;
         BC000G5_A81WWPMailSenderName = new string[] {""} ;
         BC000G5_A90WWPMailStatus = new short[1] ;
         BC000G5_A100WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000G5_A101WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000G5_A95WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000G5_n95WWPMailProcessed = new bool[] {false} ;
         BC000G5_A96WWPMailDetail = new string[] {""} ;
         BC000G5_n96WWPMailDetail = new bool[] {false} ;
         BC000G5_A31WWPNotificationId = new long[1] ;
         BC000G5_n31WWPNotificationId = new bool[] {false} ;
         BC000G4_A89WWPMailId = new long[1] ;
         BC000G4_A78WWPMailSubject = new string[] {""} ;
         BC000G4_A70WWPMailBody = new string[] {""} ;
         BC000G4_A79WWPMailTo = new string[] {""} ;
         BC000G4_n79WWPMailTo = new bool[] {false} ;
         BC000G4_A92WWPMailCC = new string[] {""} ;
         BC000G4_n92WWPMailCC = new bool[] {false} ;
         BC000G4_A93WWPMailBCC = new string[] {""} ;
         BC000G4_n93WWPMailBCC = new bool[] {false} ;
         BC000G4_A80WWPMailSenderAddress = new string[] {""} ;
         BC000G4_A81WWPMailSenderName = new string[] {""} ;
         BC000G4_A90WWPMailStatus = new short[1] ;
         BC000G4_A100WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000G4_A101WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000G4_A95WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000G4_n95WWPMailProcessed = new bool[] {false} ;
         BC000G4_A96WWPMailDetail = new string[] {""} ;
         BC000G4_n96WWPMailDetail = new bool[] {false} ;
         BC000G4_A31WWPNotificationId = new long[1] ;
         BC000G4_n31WWPNotificationId = new bool[] {false} ;
         BC000G9_A89WWPMailId = new long[1] ;
         BC000G12_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000G13_A89WWPMailId = new long[1] ;
         BC000G13_A78WWPMailSubject = new string[] {""} ;
         BC000G13_A70WWPMailBody = new string[] {""} ;
         BC000G13_A79WWPMailTo = new string[] {""} ;
         BC000G13_n79WWPMailTo = new bool[] {false} ;
         BC000G13_A92WWPMailCC = new string[] {""} ;
         BC000G13_n92WWPMailCC = new bool[] {false} ;
         BC000G13_A93WWPMailBCC = new string[] {""} ;
         BC000G13_n93WWPMailBCC = new bool[] {false} ;
         BC000G13_A80WWPMailSenderAddress = new string[] {""} ;
         BC000G13_A81WWPMailSenderName = new string[] {""} ;
         BC000G13_A90WWPMailStatus = new short[1] ;
         BC000G13_A100WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000G13_A101WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000G13_A95WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000G13_n95WWPMailProcessed = new bool[] {false} ;
         BC000G13_A96WWPMailDetail = new string[] {""} ;
         BC000G13_n96WWPMailDetail = new bool[] {false} ;
         BC000G13_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000G13_A31WWPNotificationId = new long[1] ;
         BC000G13_n31WWPNotificationId = new bool[] {false} ;
         Z102WWPMailAttachmentName = "";
         A102WWPMailAttachmentName = "";
         Z94WWPMailAttachmentFile = "";
         A94WWPMailAttachmentFile = "";
         BC000G14_A89WWPMailId = new long[1] ;
         BC000G14_A102WWPMailAttachmentName = new string[] {""} ;
         BC000G14_A94WWPMailAttachmentFile = new string[] {""} ;
         BC000G15_A89WWPMailId = new long[1] ;
         BC000G15_A102WWPMailAttachmentName = new string[] {""} ;
         BC000G3_A89WWPMailId = new long[1] ;
         BC000G3_A102WWPMailAttachmentName = new string[] {""} ;
         BC000G3_A94WWPMailAttachmentFile = new string[] {""} ;
         sMode18 = "";
         BC000G2_A89WWPMailId = new long[1] ;
         BC000G2_A102WWPMailAttachmentName = new string[] {""} ;
         BC000G2_A94WWPMailAttachmentFile = new string[] {""} ;
         BC000G19_A89WWPMailId = new long[1] ;
         BC000G19_A102WWPMailAttachmentName = new string[] {""} ;
         BC000G19_A94WWPMailAttachmentFile = new string[] {""} ;
         i100WWPMailCreated = (DateTime)(DateTime.MinValue);
         i101WWPMailScheduled = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail_bc__default(),
            new Object[][] {
                new Object[] {
               BC000G2_A89WWPMailId, BC000G2_A102WWPMailAttachmentName, BC000G2_A94WWPMailAttachmentFile
               }
               , new Object[] {
               BC000G3_A89WWPMailId, BC000G3_A102WWPMailAttachmentName, BC000G3_A94WWPMailAttachmentFile
               }
               , new Object[] {
               BC000G4_A89WWPMailId, BC000G4_A78WWPMailSubject, BC000G4_A70WWPMailBody, BC000G4_A79WWPMailTo, BC000G4_n79WWPMailTo, BC000G4_A92WWPMailCC, BC000G4_n92WWPMailCC, BC000G4_A93WWPMailBCC, BC000G4_n93WWPMailBCC, BC000G4_A80WWPMailSenderAddress,
               BC000G4_A81WWPMailSenderName, BC000G4_A90WWPMailStatus, BC000G4_A100WWPMailCreated, BC000G4_A101WWPMailScheduled, BC000G4_A95WWPMailProcessed, BC000G4_n95WWPMailProcessed, BC000G4_A96WWPMailDetail, BC000G4_n96WWPMailDetail, BC000G4_A31WWPNotificationId, BC000G4_n31WWPNotificationId
               }
               , new Object[] {
               BC000G5_A89WWPMailId, BC000G5_A78WWPMailSubject, BC000G5_A70WWPMailBody, BC000G5_A79WWPMailTo, BC000G5_n79WWPMailTo, BC000G5_A92WWPMailCC, BC000G5_n92WWPMailCC, BC000G5_A93WWPMailBCC, BC000G5_n93WWPMailBCC, BC000G5_A80WWPMailSenderAddress,
               BC000G5_A81WWPMailSenderName, BC000G5_A90WWPMailStatus, BC000G5_A100WWPMailCreated, BC000G5_A101WWPMailScheduled, BC000G5_A95WWPMailProcessed, BC000G5_n95WWPMailProcessed, BC000G5_A96WWPMailDetail, BC000G5_n96WWPMailDetail, BC000G5_A31WWPNotificationId, BC000G5_n31WWPNotificationId
               }
               , new Object[] {
               BC000G6_A33WWPNotificationCreated
               }
               , new Object[] {
               BC000G7_A89WWPMailId, BC000G7_A78WWPMailSubject, BC000G7_A70WWPMailBody, BC000G7_A79WWPMailTo, BC000G7_n79WWPMailTo, BC000G7_A92WWPMailCC, BC000G7_n92WWPMailCC, BC000G7_A93WWPMailBCC, BC000G7_n93WWPMailBCC, BC000G7_A80WWPMailSenderAddress,
               BC000G7_A81WWPMailSenderName, BC000G7_A90WWPMailStatus, BC000G7_A100WWPMailCreated, BC000G7_A101WWPMailScheduled, BC000G7_A95WWPMailProcessed, BC000G7_n95WWPMailProcessed, BC000G7_A96WWPMailDetail, BC000G7_n96WWPMailDetail, BC000G7_A33WWPNotificationCreated, BC000G7_A31WWPNotificationId,
               BC000G7_n31WWPNotificationId
               }
               , new Object[] {
               BC000G8_A89WWPMailId
               }
               , new Object[] {
               BC000G9_A89WWPMailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000G12_A33WWPNotificationCreated
               }
               , new Object[] {
               BC000G13_A89WWPMailId, BC000G13_A78WWPMailSubject, BC000G13_A70WWPMailBody, BC000G13_A79WWPMailTo, BC000G13_n79WWPMailTo, BC000G13_A92WWPMailCC, BC000G13_n92WWPMailCC, BC000G13_A93WWPMailBCC, BC000G13_n93WWPMailBCC, BC000G13_A80WWPMailSenderAddress,
               BC000G13_A81WWPMailSenderName, BC000G13_A90WWPMailStatus, BC000G13_A100WWPMailCreated, BC000G13_A101WWPMailScheduled, BC000G13_A95WWPMailProcessed, BC000G13_n95WWPMailProcessed, BC000G13_A96WWPMailDetail, BC000G13_n96WWPMailDetail, BC000G13_A33WWPNotificationCreated, BC000G13_A31WWPNotificationId,
               BC000G13_n31WWPNotificationId
               }
               , new Object[] {
               BC000G14_A89WWPMailId, BC000G14_A102WWPMailAttachmentName, BC000G14_A94WWPMailAttachmentFile
               }
               , new Object[] {
               BC000G15_A89WWPMailId, BC000G15_A102WWPMailAttachmentName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000G19_A89WWPMailId, BC000G19_A102WWPMailAttachmentName, BC000G19_A94WWPMailAttachmentFile
               }
            }
         );
         Z101WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A101WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i101WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z100WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A100WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i100WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z90WWPMailStatus = 1;
         A90WWPMailStatus = 1;
         i90WWPMailStatus = 1;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_18 ;
      private short RcdFound18 ;
      private short Z90WWPMailStatus ;
      private short A90WWPMailStatus ;
      private short Gx_BScreen ;
      private short RcdFound17 ;
      private short nRcdExists_18 ;
      private short Gxremove18 ;
      private short i90WWPMailStatus ;
      private int trnEnded ;
      private int nGXsfl_18_idx=1 ;
      private long Z89WWPMailId ;
      private long A89WWPMailId ;
      private long Z31WWPNotificationId ;
      private long A31WWPNotificationId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode17 ;
      private string sMode18 ;
      private DateTime Z100WWPMailCreated ;
      private DateTime A100WWPMailCreated ;
      private DateTime Z101WWPMailScheduled ;
      private DateTime A101WWPMailScheduled ;
      private DateTime Z95WWPMailProcessed ;
      private DateTime A95WWPMailProcessed ;
      private DateTime Z33WWPNotificationCreated ;
      private DateTime A33WWPNotificationCreated ;
      private DateTime i100WWPMailCreated ;
      private DateTime i101WWPMailScheduled ;
      private bool n79WWPMailTo ;
      private bool n92WWPMailCC ;
      private bool n93WWPMailBCC ;
      private bool n95WWPMailProcessed ;
      private bool n96WWPMailDetail ;
      private bool n31WWPNotificationId ;
      private bool Gx_longc ;
      private string Z70WWPMailBody ;
      private string A70WWPMailBody ;
      private string Z79WWPMailTo ;
      private string A79WWPMailTo ;
      private string Z92WWPMailCC ;
      private string A92WWPMailCC ;
      private string Z93WWPMailBCC ;
      private string A93WWPMailBCC ;
      private string Z80WWPMailSenderAddress ;
      private string A80WWPMailSenderAddress ;
      private string Z81WWPMailSenderName ;
      private string A81WWPMailSenderName ;
      private string Z96WWPMailDetail ;
      private string A96WWPMailDetail ;
      private string Z94WWPMailAttachmentFile ;
      private string A94WWPMailAttachmentFile ;
      private string Z78WWPMailSubject ;
      private string A78WWPMailSubject ;
      private string Z102WWPMailAttachmentName ;
      private string A102WWPMailAttachmentName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail bcwwpbaseobjects_mail_WWP_Mail ;
      private IDataStoreProvider pr_default ;
      private long[] BC000G7_A89WWPMailId ;
      private string[] BC000G7_A78WWPMailSubject ;
      private string[] BC000G7_A70WWPMailBody ;
      private string[] BC000G7_A79WWPMailTo ;
      private bool[] BC000G7_n79WWPMailTo ;
      private string[] BC000G7_A92WWPMailCC ;
      private bool[] BC000G7_n92WWPMailCC ;
      private string[] BC000G7_A93WWPMailBCC ;
      private bool[] BC000G7_n93WWPMailBCC ;
      private string[] BC000G7_A80WWPMailSenderAddress ;
      private string[] BC000G7_A81WWPMailSenderName ;
      private short[] BC000G7_A90WWPMailStatus ;
      private DateTime[] BC000G7_A100WWPMailCreated ;
      private DateTime[] BC000G7_A101WWPMailScheduled ;
      private DateTime[] BC000G7_A95WWPMailProcessed ;
      private bool[] BC000G7_n95WWPMailProcessed ;
      private string[] BC000G7_A96WWPMailDetail ;
      private bool[] BC000G7_n96WWPMailDetail ;
      private DateTime[] BC000G7_A33WWPNotificationCreated ;
      private long[] BC000G7_A31WWPNotificationId ;
      private bool[] BC000G7_n31WWPNotificationId ;
      private DateTime[] BC000G6_A33WWPNotificationCreated ;
      private long[] BC000G8_A89WWPMailId ;
      private long[] BC000G5_A89WWPMailId ;
      private string[] BC000G5_A78WWPMailSubject ;
      private string[] BC000G5_A70WWPMailBody ;
      private string[] BC000G5_A79WWPMailTo ;
      private bool[] BC000G5_n79WWPMailTo ;
      private string[] BC000G5_A92WWPMailCC ;
      private bool[] BC000G5_n92WWPMailCC ;
      private string[] BC000G5_A93WWPMailBCC ;
      private bool[] BC000G5_n93WWPMailBCC ;
      private string[] BC000G5_A80WWPMailSenderAddress ;
      private string[] BC000G5_A81WWPMailSenderName ;
      private short[] BC000G5_A90WWPMailStatus ;
      private DateTime[] BC000G5_A100WWPMailCreated ;
      private DateTime[] BC000G5_A101WWPMailScheduled ;
      private DateTime[] BC000G5_A95WWPMailProcessed ;
      private bool[] BC000G5_n95WWPMailProcessed ;
      private string[] BC000G5_A96WWPMailDetail ;
      private bool[] BC000G5_n96WWPMailDetail ;
      private long[] BC000G5_A31WWPNotificationId ;
      private bool[] BC000G5_n31WWPNotificationId ;
      private long[] BC000G4_A89WWPMailId ;
      private string[] BC000G4_A78WWPMailSubject ;
      private string[] BC000G4_A70WWPMailBody ;
      private string[] BC000G4_A79WWPMailTo ;
      private bool[] BC000G4_n79WWPMailTo ;
      private string[] BC000G4_A92WWPMailCC ;
      private bool[] BC000G4_n92WWPMailCC ;
      private string[] BC000G4_A93WWPMailBCC ;
      private bool[] BC000G4_n93WWPMailBCC ;
      private string[] BC000G4_A80WWPMailSenderAddress ;
      private string[] BC000G4_A81WWPMailSenderName ;
      private short[] BC000G4_A90WWPMailStatus ;
      private DateTime[] BC000G4_A100WWPMailCreated ;
      private DateTime[] BC000G4_A101WWPMailScheduled ;
      private DateTime[] BC000G4_A95WWPMailProcessed ;
      private bool[] BC000G4_n95WWPMailProcessed ;
      private string[] BC000G4_A96WWPMailDetail ;
      private bool[] BC000G4_n96WWPMailDetail ;
      private long[] BC000G4_A31WWPNotificationId ;
      private bool[] BC000G4_n31WWPNotificationId ;
      private long[] BC000G9_A89WWPMailId ;
      private DateTime[] BC000G12_A33WWPNotificationCreated ;
      private long[] BC000G13_A89WWPMailId ;
      private string[] BC000G13_A78WWPMailSubject ;
      private string[] BC000G13_A70WWPMailBody ;
      private string[] BC000G13_A79WWPMailTo ;
      private bool[] BC000G13_n79WWPMailTo ;
      private string[] BC000G13_A92WWPMailCC ;
      private bool[] BC000G13_n92WWPMailCC ;
      private string[] BC000G13_A93WWPMailBCC ;
      private bool[] BC000G13_n93WWPMailBCC ;
      private string[] BC000G13_A80WWPMailSenderAddress ;
      private string[] BC000G13_A81WWPMailSenderName ;
      private short[] BC000G13_A90WWPMailStatus ;
      private DateTime[] BC000G13_A100WWPMailCreated ;
      private DateTime[] BC000G13_A101WWPMailScheduled ;
      private DateTime[] BC000G13_A95WWPMailProcessed ;
      private bool[] BC000G13_n95WWPMailProcessed ;
      private string[] BC000G13_A96WWPMailDetail ;
      private bool[] BC000G13_n96WWPMailDetail ;
      private DateTime[] BC000G13_A33WWPNotificationCreated ;
      private long[] BC000G13_A31WWPNotificationId ;
      private bool[] BC000G13_n31WWPNotificationId ;
      private long[] BC000G14_A89WWPMailId ;
      private string[] BC000G14_A102WWPMailAttachmentName ;
      private string[] BC000G14_A94WWPMailAttachmentFile ;
      private long[] BC000G15_A89WWPMailId ;
      private string[] BC000G15_A102WWPMailAttachmentName ;
      private long[] BC000G3_A89WWPMailId ;
      private string[] BC000G3_A102WWPMailAttachmentName ;
      private string[] BC000G3_A94WWPMailAttachmentFile ;
      private long[] BC000G2_A89WWPMailId ;
      private string[] BC000G2_A102WWPMailAttachmentName ;
      private string[] BC000G2_A94WWPMailAttachmentFile ;
      private long[] BC000G19_A89WWPMailId ;
      private string[] BC000G19_A102WWPMailAttachmentName ;
      private string[] BC000G19_A94WWPMailAttachmentFile ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_mail_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mail_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000G2;
        prmBC000G2 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0) ,
        new ParDef("@WWPMailAttachmentName",GXType.NVarChar,40,0)
        };
        Object[] prmBC000G3;
        prmBC000G3 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0) ,
        new ParDef("@WWPMailAttachmentName",GXType.NVarChar,40,0)
        };
        Object[] prmBC000G4;
        prmBC000G4 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        Object[] prmBC000G5;
        prmBC000G5 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        Object[] prmBC000G6;
        prmBC000G6 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000G7;
        prmBC000G7 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        Object[] prmBC000G8;
        prmBC000G8 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        Object[] prmBC000G9;
        prmBC000G9 = new Object[] {
        new ParDef("@WWPMailSubject",GXType.NVarChar,80,0) ,
        new ParDef("@WWPMailBody",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailTo",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPMailCC",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPMailBCC",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPMailSenderAddress",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailSenderName",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailStatus",GXType.Int16,4,0) ,
        new ParDef("@WWPMailCreated",GXType.DateTime2,10,12) ,
        new ParDef("@WWPMailScheduled",GXType.DateTime2,10,12) ,
        new ParDef("@WWPMailProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("@WWPMailDetail",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000G10;
        prmBC000G10 = new Object[] {
        new ParDef("@WWPMailSubject",GXType.NVarChar,80,0) ,
        new ParDef("@WWPMailBody",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailTo",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPMailCC",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPMailBCC",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPMailSenderAddress",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailSenderName",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailStatus",GXType.Int16,4,0) ,
        new ParDef("@WWPMailCreated",GXType.DateTime2,10,12) ,
        new ParDef("@WWPMailScheduled",GXType.DateTime2,10,12) ,
        new ParDef("@WWPMailProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("@WWPMailDetail",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        Object[] prmBC000G11;
        prmBC000G11 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        Object[] prmBC000G12;
        prmBC000G12 = new Object[] {
        new ParDef("@WWPNotificationId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC000G13;
        prmBC000G13 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        Object[] prmBC000G14;
        prmBC000G14 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0) ,
        new ParDef("@WWPMailAttachmentName",GXType.NVarChar,40,0)
        };
        Object[] prmBC000G15;
        prmBC000G15 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0) ,
        new ParDef("@WWPMailAttachmentName",GXType.NVarChar,40,0)
        };
        Object[] prmBC000G16;
        prmBC000G16 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0) ,
        new ParDef("@WWPMailAttachmentName",GXType.NVarChar,40,0) ,
        new ParDef("@WWPMailAttachmentFile",GXType.NVarChar,2097152,0)
        };
        Object[] prmBC000G17;
        prmBC000G17 = new Object[] {
        new ParDef("@WWPMailAttachmentFile",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailId",GXType.Decimal,10,0) ,
        new ParDef("@WWPMailAttachmentName",GXType.NVarChar,40,0)
        };
        Object[] prmBC000G18;
        prmBC000G18 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0) ,
        new ParDef("@WWPMailAttachmentName",GXType.NVarChar,40,0)
        };
        Object[] prmBC000G19;
        prmBC000G19 = new Object[] {
        new ParDef("@WWPMailId",GXType.Decimal,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000G2", "SELECT [WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile] FROM [WWP_MailAttachments] WITH (UPDLOCK) WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G3", "SELECT [WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile] FROM [WWP_MailAttachments] WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G4", "SELECT [WWPMailId], [WWPMailSubject], [WWPMailBody], [WWPMailTo], [WWPMailCC], [WWPMailBCC], [WWPMailSenderAddress], [WWPMailSenderName], [WWPMailStatus], [WWPMailCreated], [WWPMailScheduled], [WWPMailProcessed], [WWPMailDetail], [WWPNotificationId] FROM [WWP_Mail] WITH (UPDLOCK) WHERE [WWPMailId] = @WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G5", "SELECT [WWPMailId], [WWPMailSubject], [WWPMailBody], [WWPMailTo], [WWPMailCC], [WWPMailBCC], [WWPMailSenderAddress], [WWPMailSenderName], [WWPMailStatus], [WWPMailCreated], [WWPMailScheduled], [WWPMailProcessed], [WWPMailDetail], [WWPNotificationId] FROM [WWP_Mail] WHERE [WWPMailId] = @WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G6", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G7", "SELECT TM1.[WWPMailId], TM1.[WWPMailSubject], TM1.[WWPMailBody], TM1.[WWPMailTo], TM1.[WWPMailCC], TM1.[WWPMailBCC], TM1.[WWPMailSenderAddress], TM1.[WWPMailSenderName], TM1.[WWPMailStatus], TM1.[WWPMailCreated], TM1.[WWPMailScheduled], TM1.[WWPMailProcessed], TM1.[WWPMailDetail], T2.[WWPNotificationCreated], TM1.[WWPNotificationId] FROM ([WWP_Mail] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) WHERE TM1.[WWPMailId] = @WWPMailId ORDER BY TM1.[WWPMailId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G8", "SELECT [WWPMailId] FROM [WWP_Mail] WHERE [WWPMailId] = @WWPMailId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G9", "INSERT INTO [WWP_Mail]([WWPMailSubject], [WWPMailBody], [WWPMailTo], [WWPMailCC], [WWPMailBCC], [WWPMailSenderAddress], [WWPMailSenderName], [WWPMailStatus], [WWPMailCreated], [WWPMailScheduled], [WWPMailProcessed], [WWPMailDetail], [WWPNotificationId]) VALUES(@WWPMailSubject, @WWPMailBody, @WWPMailTo, @WWPMailCC, @WWPMailBCC, @WWPMailSenderAddress, @WWPMailSenderName, @WWPMailStatus, @WWPMailCreated, @WWPMailScheduled, @WWPMailProcessed, @WWPMailDetail, @WWPNotificationId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000G10", "UPDATE [WWP_Mail] SET [WWPMailSubject]=@WWPMailSubject, [WWPMailBody]=@WWPMailBody, [WWPMailTo]=@WWPMailTo, [WWPMailCC]=@WWPMailCC, [WWPMailBCC]=@WWPMailBCC, [WWPMailSenderAddress]=@WWPMailSenderAddress, [WWPMailSenderName]=@WWPMailSenderName, [WWPMailStatus]=@WWPMailStatus, [WWPMailCreated]=@WWPMailCreated, [WWPMailScheduled]=@WWPMailScheduled, [WWPMailProcessed]=@WWPMailProcessed, [WWPMailDetail]=@WWPMailDetail, [WWPNotificationId]=@WWPNotificationId  WHERE [WWPMailId] = @WWPMailId", GxErrorMask.GX_NOMASK,prmBC000G10)
           ,new CursorDef("BC000G11", "DELETE FROM [WWP_Mail]  WHERE [WWPMailId] = @WWPMailId", GxErrorMask.GX_NOMASK,prmBC000G11)
           ,new CursorDef("BC000G12", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G13", "SELECT TM1.[WWPMailId], TM1.[WWPMailSubject], TM1.[WWPMailBody], TM1.[WWPMailTo], TM1.[WWPMailCC], TM1.[WWPMailBCC], TM1.[WWPMailSenderAddress], TM1.[WWPMailSenderName], TM1.[WWPMailStatus], TM1.[WWPMailCreated], TM1.[WWPMailScheduled], TM1.[WWPMailProcessed], TM1.[WWPMailDetail], T2.[WWPNotificationCreated], TM1.[WWPNotificationId] FROM ([WWP_Mail] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) WHERE TM1.[WWPMailId] = @WWPMailId ORDER BY TM1.[WWPMailId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G14", "SELECT [WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile] FROM [WWP_MailAttachments] WHERE [WWPMailId] = @WWPMailId and [WWPMailAttachmentName] = @WWPMailAttachmentName ORDER BY [WWPMailId], [WWPMailAttachmentName]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G14,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G15", "SELECT [WWPMailId], [WWPMailAttachmentName] FROM [WWP_MailAttachments] WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G16", "INSERT INTO [WWP_MailAttachments]([WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile]) VALUES(@WWPMailId, @WWPMailAttachmentName, @WWPMailAttachmentFile)", GxErrorMask.GX_NOMASK,prmBC000G16)
           ,new CursorDef("BC000G17", "UPDATE [WWP_MailAttachments] SET [WWPMailAttachmentFile]=@WWPMailAttachmentFile  WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName", GxErrorMask.GX_NOMASK,prmBC000G17)
           ,new CursorDef("BC000G18", "DELETE FROM [WWP_MailAttachments]  WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName", GxErrorMask.GX_NOMASK,prmBC000G18)
           ,new CursorDef("BC000G19", "SELECT [WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile] FROM [WWP_MailAttachments] WHERE [WWPMailId] = @WWPMailId ORDER BY [WWPMailId], [WWPMailAttachmentName]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G19,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((long[]) buf[18])[0] = rslt.getLong(14);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((long[]) buf[18])[0] = rslt.getLong(14);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              return;
           case 4 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(14, true);
              ((long[]) buf[19])[0] = rslt.getLong(15);
              ((bool[]) buf[20])[0] = rslt.wasNull(15);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(14, true);
              ((long[]) buf[19])[0] = rslt.getLong(15);
              ((bool[]) buf[20])[0] = rslt.wasNull(15);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
     }
  }

}

}
