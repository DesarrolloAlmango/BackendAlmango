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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_discussionmessagemention_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_discussionmessagemention_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_discussionmessagemention_bc( IGxContext context )
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
         ReadRow1Z79( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1Z79( ) ;
         standaloneModal( ) ;
         AddRow1Z79( ) ;
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
               Z540WWPDiscussionMessageId = A540WWPDiscussionMessageId;
               Z541WWPDiscussionMentionUserId = A541WWPDiscussionMentionUserId;
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

      protected void CONFIRM_1Z0( )
      {
         BeforeValidate1Z79( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1Z79( ) ;
            }
            else
            {
               CheckExtendedTable1Z79( ) ;
               if ( AnyError == 0 )
               {
                  ZM1Z79( 2) ;
                  ZM1Z79( 3) ;
               }
               CloseExtendedTableCursors1Z79( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1Z79( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z543WWPDiscussionMessageDate = A543WWPDiscussionMessageDate;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z542WWPDiscussionMentionUserName = A542WWPDiscussionMentionUserName;
         }
         if ( GX_JID == -1 )
         {
            Z540WWPDiscussionMessageId = A540WWPDiscussionMessageId;
            Z541WWPDiscussionMentionUserId = A541WWPDiscussionMentionUserId;
            Z543WWPDiscussionMessageDate = A543WWPDiscussionMessageDate;
            Z542WWPDiscussionMentionUserName = A542WWPDiscussionMentionUserName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1Z79( )
      {
         /* Using cursor BC001Z6 */
         pr_default.execute(4, new Object[] {A540WWPDiscussionMessageId, A541WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound79 = 1;
            A543WWPDiscussionMessageDate = BC001Z6_A543WWPDiscussionMessageDate[0];
            A542WWPDiscussionMentionUserName = BC001Z6_A542WWPDiscussionMentionUserName[0];
            ZM1Z79( -1) ;
         }
         pr_default.close(4);
         OnLoadActions1Z79( ) ;
      }

      protected void OnLoadActions1Z79( )
      {
      }

      protected void CheckExtendedTable1Z79( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001Z4 */
         pr_default.execute(2, new Object[] {A540WWPDiscussionMessageId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_DiscussionMessage", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
         }
         A543WWPDiscussionMessageDate = BC001Z4_A543WWPDiscussionMessageDate[0];
         pr_default.close(2);
         /* Using cursor BC001Z5 */
         pr_default.execute(3, new Object[] {A541WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Mention User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
            AnyError = 1;
         }
         A542WWPDiscussionMentionUserName = BC001Z5_A542WWPDiscussionMentionUserName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1Z79( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1Z79( )
      {
         /* Using cursor BC001Z7 */
         pr_default.execute(5, new Object[] {A540WWPDiscussionMessageId, A541WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound79 = 1;
         }
         else
         {
            RcdFound79 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001Z3 */
         pr_default.execute(1, new Object[] {A540WWPDiscussionMessageId, A541WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Z79( 1) ;
            RcdFound79 = 1;
            A540WWPDiscussionMessageId = BC001Z3_A540WWPDiscussionMessageId[0];
            A541WWPDiscussionMentionUserId = BC001Z3_A541WWPDiscussionMentionUserId[0];
            Z540WWPDiscussionMessageId = A540WWPDiscussionMessageId;
            Z541WWPDiscussionMentionUserId = A541WWPDiscussionMentionUserId;
            sMode79 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1Z79( ) ;
            if ( AnyError == 1 )
            {
               RcdFound79 = 0;
               InitializeNonKey1Z79( ) ;
            }
            Gx_mode = sMode79;
         }
         else
         {
            RcdFound79 = 0;
            InitializeNonKey1Z79( ) ;
            sMode79 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode79;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Z79( ) ;
         if ( RcdFound79 == 0 )
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
         CONFIRM_1Z0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1Z79( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001Z2 */
            pr_default.execute(0, new Object[] {A540WWPDiscussionMessageId, A541WWPDiscussionMentionUserId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessageMention"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_DiscussionMessageMention"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Z79( )
      {
         BeforeValidate1Z79( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Z79( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Z79( 0) ;
            CheckOptimisticConcurrency1Z79( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Z79( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Z79( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001Z8 */
                     pr_default.execute(6, new Object[] {A540WWPDiscussionMessageId, A541WWPDiscussionMentionUserId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessageMention");
                     if ( (pr_default.getStatus(6) == 1) )
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
               Load1Z79( ) ;
            }
            EndLevel1Z79( ) ;
         }
         CloseExtendedTableCursors1Z79( ) ;
      }

      protected void Update1Z79( )
      {
         BeforeValidate1Z79( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Z79( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Z79( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Z79( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Z79( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [WWP_DiscussionMessageMention] */
                     DeferredUpdate1Z79( ) ;
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
            EndLevel1Z79( ) ;
         }
         CloseExtendedTableCursors1Z79( ) ;
      }

      protected void DeferredUpdate1Z79( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1Z79( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Z79( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Z79( ) ;
            AfterConfirm1Z79( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Z79( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001Z9 */
                  pr_default.execute(7, new Object[] {A540WWPDiscussionMessageId, A541WWPDiscussionMentionUserId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessageMention");
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
         sMode79 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1Z79( ) ;
         Gx_mode = sMode79;
      }

      protected void OnDeleteControls1Z79( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001Z10 */
            pr_default.execute(8, new Object[] {A540WWPDiscussionMessageId});
            A543WWPDiscussionMessageDate = BC001Z10_A543WWPDiscussionMessageDate[0];
            pr_default.close(8);
            /* Using cursor BC001Z11 */
            pr_default.execute(9, new Object[] {A541WWPDiscussionMentionUserId});
            A542WWPDiscussionMentionUserName = BC001Z11_A542WWPDiscussionMentionUserName[0];
            pr_default.close(9);
         }
      }

      protected void EndLevel1Z79( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1Z79( ) ;
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

      public void ScanKeyStart1Z79( )
      {
         /* Using cursor BC001Z12 */
         pr_default.execute(10, new Object[] {A540WWPDiscussionMessageId, A541WWPDiscussionMentionUserId});
         RcdFound79 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound79 = 1;
            A543WWPDiscussionMessageDate = BC001Z12_A543WWPDiscussionMessageDate[0];
            A542WWPDiscussionMentionUserName = BC001Z12_A542WWPDiscussionMentionUserName[0];
            A540WWPDiscussionMessageId = BC001Z12_A540WWPDiscussionMessageId[0];
            A541WWPDiscussionMentionUserId = BC001Z12_A541WWPDiscussionMentionUserId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1Z79( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound79 = 0;
         ScanKeyLoad1Z79( ) ;
      }

      protected void ScanKeyLoad1Z79( )
      {
         sMode79 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound79 = 1;
            A543WWPDiscussionMessageDate = BC001Z12_A543WWPDiscussionMessageDate[0];
            A542WWPDiscussionMentionUserName = BC001Z12_A542WWPDiscussionMentionUserName[0];
            A540WWPDiscussionMessageId = BC001Z12_A540WWPDiscussionMessageId[0];
            A541WWPDiscussionMentionUserId = BC001Z12_A541WWPDiscussionMentionUserId[0];
         }
         Gx_mode = sMode79;
      }

      protected void ScanKeyEnd1Z79( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1Z79( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Z79( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Z79( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Z79( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Z79( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Z79( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Z79( )
      {
      }

      protected void send_integrity_lvl_hashes1Z79( )
      {
      }

      protected void AddRow1Z79( )
      {
         VarsToRow79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
      }

      protected void ReadRow1Z79( )
      {
         RowToVars79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
      }

      protected void InitializeNonKey1Z79( )
      {
         A543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A542WWPDiscussionMentionUserName = "";
      }

      protected void InitAll1Z79( )
      {
         A540WWPDiscussionMessageId = 0;
         A541WWPDiscussionMentionUserId = "";
         InitializeNonKey1Z79( ) ;
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

      public void VarsToRow79( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention obj79 )
      {
         obj79.gxTpr_Mode = Gx_mode;
         obj79.gxTpr_Wwpdiscussionmessagedate = A543WWPDiscussionMessageDate;
         obj79.gxTpr_Wwpdiscussionmentionusername = A542WWPDiscussionMentionUserName;
         obj79.gxTpr_Wwpdiscussionmessageid = A540WWPDiscussionMessageId;
         obj79.gxTpr_Wwpdiscussionmentionuserid = A541WWPDiscussionMentionUserId;
         obj79.gxTpr_Wwpdiscussionmessageid_Z = Z540WWPDiscussionMessageId;
         obj79.gxTpr_Wwpdiscussionmessagedate_Z = Z543WWPDiscussionMessageDate;
         obj79.gxTpr_Wwpdiscussionmentionuserid_Z = Z541WWPDiscussionMentionUserId;
         obj79.gxTpr_Wwpdiscussionmentionusername_Z = Z542WWPDiscussionMentionUserName;
         obj79.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow79( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention obj79 )
      {
         obj79.gxTpr_Wwpdiscussionmessageid = A540WWPDiscussionMessageId;
         obj79.gxTpr_Wwpdiscussionmentionuserid = A541WWPDiscussionMentionUserId;
         return  ;
      }

      public void RowToVars79( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention obj79 ,
                               int forceLoad )
      {
         Gx_mode = obj79.gxTpr_Mode;
         A543WWPDiscussionMessageDate = obj79.gxTpr_Wwpdiscussionmessagedate;
         A542WWPDiscussionMentionUserName = obj79.gxTpr_Wwpdiscussionmentionusername;
         A540WWPDiscussionMessageId = obj79.gxTpr_Wwpdiscussionmessageid;
         A541WWPDiscussionMentionUserId = obj79.gxTpr_Wwpdiscussionmentionuserid;
         Z540WWPDiscussionMessageId = obj79.gxTpr_Wwpdiscussionmessageid_Z;
         Z543WWPDiscussionMessageDate = obj79.gxTpr_Wwpdiscussionmessagedate_Z;
         Z541WWPDiscussionMentionUserId = obj79.gxTpr_Wwpdiscussionmentionuserid_Z;
         Z542WWPDiscussionMentionUserName = obj79.gxTpr_Wwpdiscussionmentionusername_Z;
         Gx_mode = obj79.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A540WWPDiscussionMessageId = (long)getParm(obj,0);
         A541WWPDiscussionMentionUserId = (string)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1Z79( ) ;
         ScanKeyStart1Z79( ) ;
         if ( RcdFound79 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001Z10 */
            pr_default.execute(8, new Object[] {A540WWPDiscussionMessageId});
            if ( (pr_default.getStatus(8) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_DiscussionMessage", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
               AnyError = 1;
            }
            A543WWPDiscussionMessageDate = BC001Z10_A543WWPDiscussionMessageDate[0];
            pr_default.close(8);
            /* Using cursor BC001Z11 */
            pr_default.execute(9, new Object[] {A541WWPDiscussionMentionUserId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Mention User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
               AnyError = 1;
            }
            A542WWPDiscussionMentionUserName = BC001Z11_A542WWPDiscussionMentionUserName[0];
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z540WWPDiscussionMessageId = A540WWPDiscussionMessageId;
            Z541WWPDiscussionMentionUserId = A541WWPDiscussionMentionUserId;
         }
         ZM1Z79( -1) ;
         OnLoadActions1Z79( ) ;
         AddRow1Z79( ) ;
         ScanKeyEnd1Z79( ) ;
         if ( RcdFound79 == 0 )
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
         RowToVars79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 0) ;
         ScanKeyStart1Z79( ) ;
         if ( RcdFound79 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001Z10 */
            pr_default.execute(8, new Object[] {A540WWPDiscussionMessageId});
            if ( (pr_default.getStatus(8) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_DiscussionMessage", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
               AnyError = 1;
            }
            A543WWPDiscussionMessageDate = BC001Z10_A543WWPDiscussionMessageDate[0];
            pr_default.close(8);
            /* Using cursor BC001Z11 */
            pr_default.execute(9, new Object[] {A541WWPDiscussionMentionUserId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Mention User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
               AnyError = 1;
            }
            A542WWPDiscussionMentionUserName = BC001Z11_A542WWPDiscussionMentionUserName[0];
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z540WWPDiscussionMessageId = A540WWPDiscussionMessageId;
            Z541WWPDiscussionMentionUserId = A541WWPDiscussionMentionUserId;
         }
         ZM1Z79( -1) ;
         OnLoadActions1Z79( ) ;
         AddRow1Z79( ) ;
         ScanKeyEnd1Z79( ) ;
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1Z79( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1Z79( ) ;
         }
         else
         {
            if ( RcdFound79 == 1 )
            {
               if ( ( A540WWPDiscussionMessageId != Z540WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A541WWPDiscussionMentionUserId, Z541WWPDiscussionMentionUserId) != 0 ) )
               {
                  A540WWPDiscussionMessageId = Z540WWPDiscussionMessageId;
                  A541WWPDiscussionMentionUserId = Z541WWPDiscussionMentionUserId;
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
                  Update1Z79( ) ;
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
                  if ( ( A540WWPDiscussionMessageId != Z540WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A541WWPDiscussionMentionUserId, Z541WWPDiscussionMentionUserId) != 0 ) )
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
                        Insert1Z79( ) ;
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
                        Insert1Z79( ) ;
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
         RowToVars79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         SaveImpl( ) ;
         VarsToRow79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1Z79( ) ;
         AfterTrn( ) ;
         VarsToRow79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention auxBC = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A540WWPDiscussionMessageId, A541WWPDiscussionMentionUserId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention);
               auxBC.Save();
               bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
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
         RowToVars79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1Z79( ) ;
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
               VarsToRow79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
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
         RowToVars79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 0) ;
         GetKey1Z79( ) ;
         if ( RcdFound79 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A540WWPDiscussionMessageId != Z540WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A541WWPDiscussionMentionUserId, Z541WWPDiscussionMentionUserId) != 0 ) )
            {
               A540WWPDiscussionMessageId = Z540WWPDiscussionMessageId;
               A541WWPDiscussionMentionUserId = Z541WWPDiscussionMentionUserId;
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
            if ( ( A540WWPDiscussionMessageId != Z540WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A541WWPDiscussionMentionUserId, Z541WWPDiscussionMentionUserId) != 0 ) )
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
         pr_default.close(9);
         context.RollbackDataStores("wwpbaseobjects.discussions.wwp_discussionmessagemention_bc",pr_default);
         VarsToRow79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
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
         Gx_mode = bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention )
         {
            bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention = (GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
            }
            else
            {
               RowToVars79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars79( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_DiscussionMessageMention WWP_DiscussionMessageMention_BC
      {
         get {
            return bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention ;
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
         pr_default.close(9);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z541WWPDiscussionMentionUserId = "";
         A541WWPDiscussionMentionUserId = "";
         Z543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z542WWPDiscussionMentionUserName = "";
         A542WWPDiscussionMentionUserName = "";
         BC001Z6_A543WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC001Z6_A542WWPDiscussionMentionUserName = new string[] {""} ;
         BC001Z6_A540WWPDiscussionMessageId = new long[1] ;
         BC001Z6_A541WWPDiscussionMentionUserId = new string[] {""} ;
         BC001Z4_A543WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC001Z5_A542WWPDiscussionMentionUserName = new string[] {""} ;
         BC001Z7_A540WWPDiscussionMessageId = new long[1] ;
         BC001Z7_A541WWPDiscussionMentionUserId = new string[] {""} ;
         BC001Z3_A540WWPDiscussionMessageId = new long[1] ;
         BC001Z3_A541WWPDiscussionMentionUserId = new string[] {""} ;
         sMode79 = "";
         BC001Z2_A540WWPDiscussionMessageId = new long[1] ;
         BC001Z2_A541WWPDiscussionMentionUserId = new string[] {""} ;
         BC001Z10_A543WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC001Z11_A542WWPDiscussionMentionUserName = new string[] {""} ;
         BC001Z12_A543WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC001Z12_A542WWPDiscussionMentionUserName = new string[] {""} ;
         BC001Z12_A540WWPDiscussionMessageId = new long[1] ;
         BC001Z12_A541WWPDiscussionMentionUserId = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessagemention_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessagemention_bc__default(),
            new Object[][] {
                new Object[] {
               BC001Z2_A540WWPDiscussionMessageId, BC001Z2_A541WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC001Z3_A540WWPDiscussionMessageId, BC001Z3_A541WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC001Z4_A543WWPDiscussionMessageDate
               }
               , new Object[] {
               BC001Z5_A542WWPDiscussionMentionUserName
               }
               , new Object[] {
               BC001Z6_A543WWPDiscussionMessageDate, BC001Z6_A542WWPDiscussionMentionUserName, BC001Z6_A540WWPDiscussionMessageId, BC001Z6_A541WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC001Z7_A540WWPDiscussionMessageId, BC001Z7_A541WWPDiscussionMentionUserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001Z10_A543WWPDiscussionMessageDate
               }
               , new Object[] {
               BC001Z11_A542WWPDiscussionMentionUserName
               }
               , new Object[] {
               BC001Z12_A543WWPDiscussionMessageDate, BC001Z12_A542WWPDiscussionMentionUserName, BC001Z12_A540WWPDiscussionMessageId, BC001Z12_A541WWPDiscussionMentionUserId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound79 ;
      private int trnEnded ;
      private long Z540WWPDiscussionMessageId ;
      private long A540WWPDiscussionMessageId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z541WWPDiscussionMentionUserId ;
      private string A541WWPDiscussionMentionUserId ;
      private string sMode79 ;
      private DateTime Z543WWPDiscussionMessageDate ;
      private DateTime A543WWPDiscussionMessageDate ;
      private string Z542WWPDiscussionMentionUserName ;
      private string A542WWPDiscussionMentionUserName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] BC001Z6_A543WWPDiscussionMessageDate ;
      private string[] BC001Z6_A542WWPDiscussionMentionUserName ;
      private long[] BC001Z6_A540WWPDiscussionMessageId ;
      private string[] BC001Z6_A541WWPDiscussionMentionUserId ;
      private DateTime[] BC001Z4_A543WWPDiscussionMessageDate ;
      private string[] BC001Z5_A542WWPDiscussionMentionUserName ;
      private long[] BC001Z7_A540WWPDiscussionMessageId ;
      private string[] BC001Z7_A541WWPDiscussionMentionUserId ;
      private long[] BC001Z3_A540WWPDiscussionMessageId ;
      private string[] BC001Z3_A541WWPDiscussionMentionUserId ;
      private long[] BC001Z2_A540WWPDiscussionMessageId ;
      private string[] BC001Z2_A541WWPDiscussionMentionUserId ;
      private DateTime[] BC001Z10_A543WWPDiscussionMessageDate ;
      private string[] BC001Z11_A542WWPDiscussionMentionUserName ;
      private DateTime[] BC001Z12_A543WWPDiscussionMessageDate ;
      private string[] BC001Z12_A542WWPDiscussionMentionUserName ;
      private long[] BC001Z12_A540WWPDiscussionMessageId ;
      private string[] BC001Z12_A541WWPDiscussionMentionUserId ;
      private GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_discussionmessagemention_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_discussionmessagemention_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC001Z2;
        prmBC001Z2 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmBC001Z3;
        prmBC001Z3 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmBC001Z4;
        prmBC001Z4 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmBC001Z5;
        prmBC001Z5 = new Object[] {
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmBC001Z6;
        prmBC001Z6 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmBC001Z7;
        prmBC001Z7 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmBC001Z8;
        prmBC001Z8 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmBC001Z9;
        prmBC001Z9 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmBC001Z10;
        prmBC001Z10 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmBC001Z11;
        prmBC001Z11 = new Object[] {
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        Object[] prmBC001Z12;
        prmBC001Z12 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMentionUserId",GXType.NChar,40,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC001Z2", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] WITH (UPDLOCK) WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId AND [WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Z3", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId AND [WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Z4", "SELECT [WWPDiscussionMessageDate] FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Z5", "SELECT [WWPUserExtendedFullName] AS WWPDiscussionMentionUserName FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Z6", "SELECT T2.[WWPDiscussionMessageDate], T3.[WWPUserExtendedFullName] AS WWPDiscussionMentionUserName, TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM (([WWP_DiscussionMessageMention] TM1 INNER JOIN [WWP_DiscussionMessage] T2 ON T2.[WWPDiscussionMessageId] = TM1.[WWPDiscussionMessageId]) INNER JOIN [WWP_UserExtended] T3 ON T3.[WWPUserExtendedId] = TM1.[WWPDiscussionMentionUserId]) WHERE TM1.[WWPDiscussionMessageId] = @WWPDiscussionMessageId and TM1.[WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId ORDER BY TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMentionUserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Z7", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId AND [WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Z8", "INSERT INTO [WWP_DiscussionMessageMention]([WWPDiscussionMessageId], [WWPDiscussionMentionUserId]) VALUES(@WWPDiscussionMessageId, @WWPDiscussionMentionUserId)", GxErrorMask.GX_NOMASK,prmBC001Z8)
           ,new CursorDef("BC001Z9", "DELETE FROM [WWP_DiscussionMessageMention]  WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId AND [WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId", GxErrorMask.GX_NOMASK,prmBC001Z9)
           ,new CursorDef("BC001Z10", "SELECT [WWPDiscussionMessageDate] FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Z11", "SELECT [WWPUserExtendedFullName] AS WWPDiscussionMentionUserName FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Z12", "SELECT T2.[WWPDiscussionMessageDate], T3.[WWPUserExtendedFullName] AS WWPDiscussionMentionUserName, TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM (([WWP_DiscussionMessageMention] TM1 INNER JOIN [WWP_DiscussionMessage] T2 ON T2.[WWPDiscussionMessageId] = TM1.[WWPDiscussionMessageId]) INNER JOIN [WWP_UserExtended] T3 ON T3.[WWPUserExtendedId] = TM1.[WWPDiscussionMentionUserId]) WHERE TM1.[WWPDiscussionMessageId] = @WWPDiscussionMessageId and TM1.[WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId ORDER BY TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMentionUserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z12,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 2 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 8 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 10 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              return;
     }
  }

}

}
