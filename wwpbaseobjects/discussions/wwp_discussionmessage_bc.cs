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
   public class wwp_discussionmessage_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_discussionmessage_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_discussionmessage_bc( IGxContext context )
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
         ReadRow1Y78( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1Y78( ) ;
         standaloneModal( ) ;
         AddRow1Y78( ) ;
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

      protected void CONFIRM_1Y0( )
      {
         BeforeValidate1Y78( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1Y78( ) ;
            }
            else
            {
               CheckExtendedTable1Y78( ) ;
               if ( AnyError == 0 )
               {
                  ZM1Y78( 6) ;
                  ZM1Y78( 7) ;
                  ZM1Y78( 8) ;
               }
               CloseExtendedTableCursors1Y78( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1Y78( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z543WWPDiscussionMessageDate = A543WWPDiscussionMessageDate;
            Z544WWPDiscussionMessageMessage = A544WWPDiscussionMessageMessage;
            Z545WWPDiscussionMessageEntityReco = A545WWPDiscussionMessageEntityReco;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z29WWPEntityId = A29WWPEntityId;
            Z539WWPDiscussionMessageThreadId = A539WWPDiscussionMessageThreadId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z30WWPEntityName = A30WWPEntityName;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -5 )
         {
            Z540WWPDiscussionMessageId = A540WWPDiscussionMessageId;
            Z543WWPDiscussionMessageDate = A543WWPDiscussionMessageDate;
            Z544WWPDiscussionMessageMessage = A544WWPDiscussionMessageMessage;
            Z545WWPDiscussionMessageEntityReco = A545WWPDiscussionMessageEntityReco;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z29WWPEntityId = A29WWPEntityId;
            Z539WWPDiscussionMessageThreadId = A539WWPDiscussionMessageThreadId;
            Z4WWPUserExtendedPhoto = A4WWPUserExtendedPhoto;
            Z40000WWPUserExtendedPhoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
            Z30WWPEntityName = A30WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         A543WWPDiscussionMessageDate = DateTimeUtil.Now( context);
         GXt_char1 = A1WWPUserExtendedId;
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         A1WWPUserExtendedId = GXt_char1;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor BC001Y4 */
            pr_default.execute(2, new Object[] {A1WWPUserExtendedId});
            A40000WWPUserExtendedPhoto_GXI = BC001Y4_A40000WWPUserExtendedPhoto_GXI[0];
            A2WWPUserExtendedFullName = BC001Y4_A2WWPUserExtendedFullName[0];
            A4WWPUserExtendedPhoto = BC001Y4_A4WWPUserExtendedPhoto[0];
            pr_default.close(2);
         }
      }

      protected void Load1Y78( )
      {
         /* Using cursor BC001Y7 */
         pr_default.execute(5, new Object[] {A540WWPDiscussionMessageId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound78 = 1;
            A543WWPDiscussionMessageDate = BC001Y7_A543WWPDiscussionMessageDate[0];
            A544WWPDiscussionMessageMessage = BC001Y7_A544WWPDiscussionMessageMessage[0];
            A40000WWPUserExtendedPhoto_GXI = BC001Y7_A40000WWPUserExtendedPhoto_GXI[0];
            A2WWPUserExtendedFullName = BC001Y7_A2WWPUserExtendedFullName[0];
            A30WWPEntityName = BC001Y7_A30WWPEntityName[0];
            A545WWPDiscussionMessageEntityReco = BC001Y7_A545WWPDiscussionMessageEntityReco[0];
            A1WWPUserExtendedId = BC001Y7_A1WWPUserExtendedId[0];
            A29WWPEntityId = BC001Y7_A29WWPEntityId[0];
            A539WWPDiscussionMessageThreadId = BC001Y7_A539WWPDiscussionMessageThreadId[0];
            n539WWPDiscussionMessageThreadId = BC001Y7_n539WWPDiscussionMessageThreadId[0];
            A4WWPUserExtendedPhoto = BC001Y7_A4WWPUserExtendedPhoto[0];
            ZM1Y78( -5) ;
         }
         pr_default.close(5);
         OnLoadActions1Y78( ) ;
      }

      protected void OnLoadActions1Y78( )
      {
      }

      protected void CheckExtendedTable1Y78( )
      {
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A543WWPDiscussionMessageDate) || ( A543WWPDiscussionMessageDate >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Message Date", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC001Y6 */
         pr_default.execute(4, new Object[] {n539WWPDiscussionMessageThreadId, A539WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A539WWPDiscussionMessageThreadId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Thread", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
            }
         }
         pr_default.close(4);
         /* Using cursor BC001Y4 */
         pr_default.execute(2, new Object[] {A1WWPUserExtendedId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
         }
         A40000WWPUserExtendedPhoto_GXI = BC001Y4_A40000WWPUserExtendedPhoto_GXI[0];
         A2WWPUserExtendedFullName = BC001Y4_A2WWPUserExtendedFullName[0];
         A4WWPUserExtendedPhoto = BC001Y4_A4WWPUserExtendedPhoto[0];
         pr_default.close(2);
         /* Using cursor BC001Y5 */
         pr_default.execute(3, new Object[] {A29WWPEntityId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A30WWPEntityName = BC001Y5_A30WWPEntityName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1Y78( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1Y78( )
      {
         /* Using cursor BC001Y8 */
         pr_default.execute(6, new Object[] {A540WWPDiscussionMessageId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound78 = 1;
         }
         else
         {
            RcdFound78 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001Y3 */
         pr_default.execute(1, new Object[] {A540WWPDiscussionMessageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Y78( 5) ;
            RcdFound78 = 1;
            A540WWPDiscussionMessageId = BC001Y3_A540WWPDiscussionMessageId[0];
            A543WWPDiscussionMessageDate = BC001Y3_A543WWPDiscussionMessageDate[0];
            A544WWPDiscussionMessageMessage = BC001Y3_A544WWPDiscussionMessageMessage[0];
            A545WWPDiscussionMessageEntityReco = BC001Y3_A545WWPDiscussionMessageEntityReco[0];
            A1WWPUserExtendedId = BC001Y3_A1WWPUserExtendedId[0];
            A29WWPEntityId = BC001Y3_A29WWPEntityId[0];
            A539WWPDiscussionMessageThreadId = BC001Y3_A539WWPDiscussionMessageThreadId[0];
            n539WWPDiscussionMessageThreadId = BC001Y3_n539WWPDiscussionMessageThreadId[0];
            Z540WWPDiscussionMessageId = A540WWPDiscussionMessageId;
            sMode78 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1Y78( ) ;
            if ( AnyError == 1 )
            {
               RcdFound78 = 0;
               InitializeNonKey1Y78( ) ;
            }
            Gx_mode = sMode78;
         }
         else
         {
            RcdFound78 = 0;
            InitializeNonKey1Y78( ) ;
            sMode78 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode78;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Y78( ) ;
         if ( RcdFound78 == 0 )
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
         CONFIRM_1Y0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1Y78( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001Y2 */
            pr_default.execute(0, new Object[] {A540WWPDiscussionMessageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z543WWPDiscussionMessageDate != BC001Y2_A543WWPDiscussionMessageDate[0] ) || ( StringUtil.StrCmp(Z544WWPDiscussionMessageMessage, BC001Y2_A544WWPDiscussionMessageMessage[0]) != 0 ) || ( StringUtil.StrCmp(Z545WWPDiscussionMessageEntityReco, BC001Y2_A545WWPDiscussionMessageEntityReco[0]) != 0 ) || ( StringUtil.StrCmp(Z1WWPUserExtendedId, BC001Y2_A1WWPUserExtendedId[0]) != 0 ) || ( Z29WWPEntityId != BC001Y2_A29WWPEntityId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z539WWPDiscussionMessageThreadId != BC001Y2_A539WWPDiscussionMessageThreadId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_DiscussionMessage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Y78( )
      {
         BeforeValidate1Y78( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Y78( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Y78( 0) ;
            CheckOptimisticConcurrency1Y78( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Y78( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Y78( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001Y9 */
                     pr_default.execute(7, new Object[] {A543WWPDiscussionMessageDate, A544WWPDiscussionMessageMessage, A545WWPDiscussionMessageEntityReco, A1WWPUserExtendedId, A29WWPEntityId, n539WWPDiscussionMessageThreadId, A539WWPDiscussionMessageThreadId});
                     A540WWPDiscussionMessageId = BC001Y9_A540WWPDiscussionMessageId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
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
               Load1Y78( ) ;
            }
            EndLevel1Y78( ) ;
         }
         CloseExtendedTableCursors1Y78( ) ;
      }

      protected void Update1Y78( )
      {
         BeforeValidate1Y78( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Y78( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Y78( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Y78( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Y78( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001Y10 */
                     pr_default.execute(8, new Object[] {A543WWPDiscussionMessageDate, A544WWPDiscussionMessageMessage, A545WWPDiscussionMessageEntityReco, A1WWPUserExtendedId, A29WWPEntityId, n539WWPDiscussionMessageThreadId, A539WWPDiscussionMessageThreadId, A540WWPDiscussionMessageId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1Y78( ) ;
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
            EndLevel1Y78( ) ;
         }
         CloseExtendedTableCursors1Y78( ) ;
      }

      protected void DeferredUpdate1Y78( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1Y78( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Y78( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Y78( ) ;
            AfterConfirm1Y78( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Y78( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001Y11 */
                  pr_default.execute(9, new Object[] {A540WWPDiscussionMessageId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
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
         sMode78 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1Y78( ) ;
         Gx_mode = sMode78;
      }

      protected void OnDeleteControls1Y78( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001Y12 */
            pr_default.execute(10, new Object[] {A1WWPUserExtendedId});
            A40000WWPUserExtendedPhoto_GXI = BC001Y12_A40000WWPUserExtendedPhoto_GXI[0];
            A2WWPUserExtendedFullName = BC001Y12_A2WWPUserExtendedFullName[0];
            A4WWPUserExtendedPhoto = BC001Y12_A4WWPUserExtendedPhoto[0];
            pr_default.close(10);
            /* Using cursor BC001Y13 */
            pr_default.execute(11, new Object[] {A29WWPEntityId});
            A30WWPEntityName = BC001Y13_A30WWPEntityName[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001Y14 */
            pr_default.execute(12, new Object[] {A540WWPDiscussionMessageId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_DiscussionMessage", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC001Y15 */
            pr_default.execute(13, new Object[] {A540WWPDiscussionMessageId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_DiscussionMessageMention", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel1Y78( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1Y78( ) ;
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

      public void ScanKeyStart1Y78( )
      {
         /* Using cursor BC001Y16 */
         pr_default.execute(14, new Object[] {A540WWPDiscussionMessageId});
         RcdFound78 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound78 = 1;
            A540WWPDiscussionMessageId = BC001Y16_A540WWPDiscussionMessageId[0];
            A543WWPDiscussionMessageDate = BC001Y16_A543WWPDiscussionMessageDate[0];
            A544WWPDiscussionMessageMessage = BC001Y16_A544WWPDiscussionMessageMessage[0];
            A40000WWPUserExtendedPhoto_GXI = BC001Y16_A40000WWPUserExtendedPhoto_GXI[0];
            A2WWPUserExtendedFullName = BC001Y16_A2WWPUserExtendedFullName[0];
            A30WWPEntityName = BC001Y16_A30WWPEntityName[0];
            A545WWPDiscussionMessageEntityReco = BC001Y16_A545WWPDiscussionMessageEntityReco[0];
            A1WWPUserExtendedId = BC001Y16_A1WWPUserExtendedId[0];
            A29WWPEntityId = BC001Y16_A29WWPEntityId[0];
            A539WWPDiscussionMessageThreadId = BC001Y16_A539WWPDiscussionMessageThreadId[0];
            n539WWPDiscussionMessageThreadId = BC001Y16_n539WWPDiscussionMessageThreadId[0];
            A4WWPUserExtendedPhoto = BC001Y16_A4WWPUserExtendedPhoto[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1Y78( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound78 = 0;
         ScanKeyLoad1Y78( ) ;
      }

      protected void ScanKeyLoad1Y78( )
      {
         sMode78 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound78 = 1;
            A540WWPDiscussionMessageId = BC001Y16_A540WWPDiscussionMessageId[0];
            A543WWPDiscussionMessageDate = BC001Y16_A543WWPDiscussionMessageDate[0];
            A544WWPDiscussionMessageMessage = BC001Y16_A544WWPDiscussionMessageMessage[0];
            A40000WWPUserExtendedPhoto_GXI = BC001Y16_A40000WWPUserExtendedPhoto_GXI[0];
            A2WWPUserExtendedFullName = BC001Y16_A2WWPUserExtendedFullName[0];
            A30WWPEntityName = BC001Y16_A30WWPEntityName[0];
            A545WWPDiscussionMessageEntityReco = BC001Y16_A545WWPDiscussionMessageEntityReco[0];
            A1WWPUserExtendedId = BC001Y16_A1WWPUserExtendedId[0];
            A29WWPEntityId = BC001Y16_A29WWPEntityId[0];
            A539WWPDiscussionMessageThreadId = BC001Y16_A539WWPDiscussionMessageThreadId[0];
            n539WWPDiscussionMessageThreadId = BC001Y16_n539WWPDiscussionMessageThreadId[0];
            A4WWPUserExtendedPhoto = BC001Y16_A4WWPUserExtendedPhoto[0];
         }
         Gx_mode = sMode78;
      }

      protected void ScanKeyEnd1Y78( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm1Y78( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Y78( )
      {
         /* Before Insert Rules */
         if ( (0==A539WWPDiscussionMessageThreadId) )
         {
            A539WWPDiscussionMessageThreadId = 0;
            n539WWPDiscussionMessageThreadId = false;
            n539WWPDiscussionMessageThreadId = true;
         }
      }

      protected void BeforeUpdate1Y78( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Y78( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Y78( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Y78( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Y78( )
      {
      }

      protected void send_integrity_lvl_hashes1Y78( )
      {
      }

      protected void AddRow1Y78( )
      {
         VarsToRow78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
      }

      protected void ReadRow1Y78( )
      {
         RowToVars78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
      }

      protected void InitializeNonKey1Y78( )
      {
         A543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A1WWPUserExtendedId = "";
         A539WWPDiscussionMessageThreadId = 0;
         n539WWPDiscussionMessageThreadId = false;
         A544WWPDiscussionMessageMessage = "";
         A4WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         A2WWPUserExtendedFullName = "";
         A29WWPEntityId = 0;
         A30WWPEntityName = "";
         A545WWPDiscussionMessageEntityReco = "";
         Z543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z544WWPDiscussionMessageMessage = "";
         Z545WWPDiscussionMessageEntityReco = "";
         Z1WWPUserExtendedId = "";
         Z29WWPEntityId = 0;
         Z539WWPDiscussionMessageThreadId = 0;
      }

      protected void InitAll1Y78( )
      {
         A540WWPDiscussionMessageId = 0;
         InitializeNonKey1Y78( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A543WWPDiscussionMessageDate = i543WWPDiscussionMessageDate;
         A1WWPUserExtendedId = i1WWPUserExtendedId;
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

      public void VarsToRow78( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage obj78 )
      {
         obj78.gxTpr_Mode = Gx_mode;
         obj78.gxTpr_Wwpdiscussionmessagedate = A543WWPDiscussionMessageDate;
         obj78.gxTpr_Wwpuserextendedid = A1WWPUserExtendedId;
         obj78.gxTpr_Wwpdiscussionmessagethreadid = A539WWPDiscussionMessageThreadId;
         obj78.gxTpr_Wwpdiscussionmessagemessage = A544WWPDiscussionMessageMessage;
         obj78.gxTpr_Wwpuserextendedphoto = A4WWPUserExtendedPhoto;
         obj78.gxTpr_Wwpuserextendedphoto_gxi = A40000WWPUserExtendedPhoto_GXI;
         obj78.gxTpr_Wwpuserextendedfullname = A2WWPUserExtendedFullName;
         obj78.gxTpr_Wwpentityid = A29WWPEntityId;
         obj78.gxTpr_Wwpentityname = A30WWPEntityName;
         obj78.gxTpr_Wwpdiscussionmessageentityrecordid = A545WWPDiscussionMessageEntityReco;
         obj78.gxTpr_Wwpdiscussionmessageid = A540WWPDiscussionMessageId;
         obj78.gxTpr_Wwpdiscussionmessageid_Z = Z540WWPDiscussionMessageId;
         obj78.gxTpr_Wwpdiscussionmessagedate_Z = Z543WWPDiscussionMessageDate;
         obj78.gxTpr_Wwpdiscussionmessagethreadid_Z = Z539WWPDiscussionMessageThreadId;
         obj78.gxTpr_Wwpdiscussionmessagemessage_Z = Z544WWPDiscussionMessageMessage;
         obj78.gxTpr_Wwpuserextendedid_Z = Z1WWPUserExtendedId;
         obj78.gxTpr_Wwpuserextendedfullname_Z = Z2WWPUserExtendedFullName;
         obj78.gxTpr_Wwpentityid_Z = Z29WWPEntityId;
         obj78.gxTpr_Wwpentityname_Z = Z30WWPEntityName;
         obj78.gxTpr_Wwpdiscussionmessageentityrecordid_Z = Z545WWPDiscussionMessageEntityReco;
         obj78.gxTpr_Wwpuserextendedphoto_gxi_Z = Z40000WWPUserExtendedPhoto_GXI;
         obj78.gxTpr_Wwpdiscussionmessagethreadid_N = (short)(Convert.ToInt16(n539WWPDiscussionMessageThreadId));
         obj78.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow78( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage obj78 )
      {
         obj78.gxTpr_Wwpdiscussionmessageid = A540WWPDiscussionMessageId;
         return  ;
      }

      public void RowToVars78( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage obj78 ,
                               int forceLoad )
      {
         Gx_mode = obj78.gxTpr_Mode;
         A543WWPDiscussionMessageDate = obj78.gxTpr_Wwpdiscussionmessagedate;
         A1WWPUserExtendedId = obj78.gxTpr_Wwpuserextendedid;
         A539WWPDiscussionMessageThreadId = obj78.gxTpr_Wwpdiscussionmessagethreadid;
         n539WWPDiscussionMessageThreadId = false;
         A544WWPDiscussionMessageMessage = obj78.gxTpr_Wwpdiscussionmessagemessage;
         A4WWPUserExtendedPhoto = obj78.gxTpr_Wwpuserextendedphoto;
         A40000WWPUserExtendedPhoto_GXI = obj78.gxTpr_Wwpuserextendedphoto_gxi;
         A2WWPUserExtendedFullName = obj78.gxTpr_Wwpuserextendedfullname;
         A29WWPEntityId = obj78.gxTpr_Wwpentityid;
         A30WWPEntityName = obj78.gxTpr_Wwpentityname;
         A545WWPDiscussionMessageEntityReco = obj78.gxTpr_Wwpdiscussionmessageentityrecordid;
         A540WWPDiscussionMessageId = obj78.gxTpr_Wwpdiscussionmessageid;
         Z540WWPDiscussionMessageId = obj78.gxTpr_Wwpdiscussionmessageid_Z;
         Z543WWPDiscussionMessageDate = obj78.gxTpr_Wwpdiscussionmessagedate_Z;
         Z539WWPDiscussionMessageThreadId = obj78.gxTpr_Wwpdiscussionmessagethreadid_Z;
         Z544WWPDiscussionMessageMessage = obj78.gxTpr_Wwpdiscussionmessagemessage_Z;
         Z1WWPUserExtendedId = obj78.gxTpr_Wwpuserextendedid_Z;
         Z2WWPUserExtendedFullName = obj78.gxTpr_Wwpuserextendedfullname_Z;
         Z29WWPEntityId = obj78.gxTpr_Wwpentityid_Z;
         Z30WWPEntityName = obj78.gxTpr_Wwpentityname_Z;
         Z545WWPDiscussionMessageEntityReco = obj78.gxTpr_Wwpdiscussionmessageentityrecordid_Z;
         Z40000WWPUserExtendedPhoto_GXI = obj78.gxTpr_Wwpuserextendedphoto_gxi_Z;
         n539WWPDiscussionMessageThreadId = (bool)(Convert.ToBoolean(obj78.gxTpr_Wwpdiscussionmessagethreadid_N));
         Gx_mode = obj78.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A540WWPDiscussionMessageId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1Y78( ) ;
         ScanKeyStart1Y78( ) ;
         if ( RcdFound78 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z540WWPDiscussionMessageId = A540WWPDiscussionMessageId;
         }
         ZM1Y78( -5) ;
         OnLoadActions1Y78( ) ;
         AddRow1Y78( ) ;
         ScanKeyEnd1Y78( ) ;
         if ( RcdFound78 == 0 )
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
         RowToVars78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 0) ;
         ScanKeyStart1Y78( ) ;
         if ( RcdFound78 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z540WWPDiscussionMessageId = A540WWPDiscussionMessageId;
         }
         ZM1Y78( -5) ;
         OnLoadActions1Y78( ) ;
         AddRow1Y78( ) ;
         ScanKeyEnd1Y78( ) ;
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1Y78( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1Y78( ) ;
         }
         else
         {
            if ( RcdFound78 == 1 )
            {
               if ( A540WWPDiscussionMessageId != Z540WWPDiscussionMessageId )
               {
                  A540WWPDiscussionMessageId = Z540WWPDiscussionMessageId;
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
                  Update1Y78( ) ;
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
                  if ( A540WWPDiscussionMessageId != Z540WWPDiscussionMessageId )
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
                        Insert1Y78( ) ;
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
                        Insert1Y78( ) ;
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
         RowToVars78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         SaveImpl( ) ;
         VarsToRow78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1Y78( ) ;
         AfterTrn( ) ;
         VarsToRow78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage auxBC = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A540WWPDiscussionMessageId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_discussions_WWP_DiscussionMessage);
               auxBC.Save();
               bcwwpbaseobjects_discussions_WWP_DiscussionMessage.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
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
         RowToVars78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1Y78( ) ;
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
               VarsToRow78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
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
         RowToVars78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 0) ;
         GetKey1Y78( ) ;
         if ( RcdFound78 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A540WWPDiscussionMessageId != Z540WWPDiscussionMessageId )
            {
               A540WWPDiscussionMessageId = Z540WWPDiscussionMessageId;
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
            if ( A540WWPDiscussionMessageId != Z540WWPDiscussionMessageId )
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
         pr_default.close(11);
         context.RollbackDataStores("wwpbaseobjects.discussions.wwp_discussionmessage_bc",pr_default);
         VarsToRow78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
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
         Gx_mode = bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_discussions_WWP_DiscussionMessage )
         {
            bcwwpbaseobjects_discussions_WWP_DiscussionMessage = (GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
            }
            else
            {
               RowToVars78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars78( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_DiscussionMessage WWP_DiscussionMessage_BC
      {
         get {
            return bcwwpbaseobjects_discussions_WWP_DiscussionMessage ;
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z544WWPDiscussionMessageMessage = "";
         A544WWPDiscussionMessageMessage = "";
         Z545WWPDiscussionMessageEntityReco = "";
         A545WWPDiscussionMessageEntityReco = "";
         Z1WWPUserExtendedId = "";
         A1WWPUserExtendedId = "";
         Z2WWPUserExtendedFullName = "";
         A2WWPUserExtendedFullName = "";
         Z30WWPEntityName = "";
         A30WWPEntityName = "";
         Z4WWPUserExtendedPhoto = "";
         A4WWPUserExtendedPhoto = "";
         Z40000WWPUserExtendedPhoto_GXI = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         GXt_char1 = "";
         BC001Y4_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC001Y4_A2WWPUserExtendedFullName = new string[] {""} ;
         BC001Y4_A4WWPUserExtendedPhoto = new string[] {""} ;
         BC001Y7_A540WWPDiscussionMessageId = new long[1] ;
         BC001Y7_A543WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC001Y7_A544WWPDiscussionMessageMessage = new string[] {""} ;
         BC001Y7_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC001Y7_A2WWPUserExtendedFullName = new string[] {""} ;
         BC001Y7_A30WWPEntityName = new string[] {""} ;
         BC001Y7_A545WWPDiscussionMessageEntityReco = new string[] {""} ;
         BC001Y7_A1WWPUserExtendedId = new string[] {""} ;
         BC001Y7_A29WWPEntityId = new long[1] ;
         BC001Y7_A539WWPDiscussionMessageThreadId = new long[1] ;
         BC001Y7_n539WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC001Y7_A4WWPUserExtendedPhoto = new string[] {""} ;
         BC001Y6_A539WWPDiscussionMessageThreadId = new long[1] ;
         BC001Y6_n539WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC001Y5_A30WWPEntityName = new string[] {""} ;
         BC001Y8_A540WWPDiscussionMessageId = new long[1] ;
         BC001Y3_A540WWPDiscussionMessageId = new long[1] ;
         BC001Y3_A543WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC001Y3_A544WWPDiscussionMessageMessage = new string[] {""} ;
         BC001Y3_A545WWPDiscussionMessageEntityReco = new string[] {""} ;
         BC001Y3_A1WWPUserExtendedId = new string[] {""} ;
         BC001Y3_A29WWPEntityId = new long[1] ;
         BC001Y3_A539WWPDiscussionMessageThreadId = new long[1] ;
         BC001Y3_n539WWPDiscussionMessageThreadId = new bool[] {false} ;
         sMode78 = "";
         BC001Y2_A540WWPDiscussionMessageId = new long[1] ;
         BC001Y2_A543WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC001Y2_A544WWPDiscussionMessageMessage = new string[] {""} ;
         BC001Y2_A545WWPDiscussionMessageEntityReco = new string[] {""} ;
         BC001Y2_A1WWPUserExtendedId = new string[] {""} ;
         BC001Y2_A29WWPEntityId = new long[1] ;
         BC001Y2_A539WWPDiscussionMessageThreadId = new long[1] ;
         BC001Y2_n539WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC001Y9_A540WWPDiscussionMessageId = new long[1] ;
         BC001Y12_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC001Y12_A2WWPUserExtendedFullName = new string[] {""} ;
         BC001Y12_A4WWPUserExtendedPhoto = new string[] {""} ;
         BC001Y13_A30WWPEntityName = new string[] {""} ;
         BC001Y14_A539WWPDiscussionMessageThreadId = new long[1] ;
         BC001Y14_n539WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC001Y15_A540WWPDiscussionMessageId = new long[1] ;
         BC001Y15_A541WWPDiscussionMentionUserId = new string[] {""} ;
         BC001Y16_A540WWPDiscussionMessageId = new long[1] ;
         BC001Y16_A543WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC001Y16_A544WWPDiscussionMessageMessage = new string[] {""} ;
         BC001Y16_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC001Y16_A2WWPUserExtendedFullName = new string[] {""} ;
         BC001Y16_A30WWPEntityName = new string[] {""} ;
         BC001Y16_A545WWPDiscussionMessageEntityReco = new string[] {""} ;
         BC001Y16_A1WWPUserExtendedId = new string[] {""} ;
         BC001Y16_A29WWPEntityId = new long[1] ;
         BC001Y16_A539WWPDiscussionMessageThreadId = new long[1] ;
         BC001Y16_n539WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC001Y16_A4WWPUserExtendedPhoto = new string[] {""} ;
         i543WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         i1WWPUserExtendedId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage_bc__default(),
            new Object[][] {
                new Object[] {
               BC001Y2_A540WWPDiscussionMessageId, BC001Y2_A543WWPDiscussionMessageDate, BC001Y2_A544WWPDiscussionMessageMessage, BC001Y2_A545WWPDiscussionMessageEntityReco, BC001Y2_A1WWPUserExtendedId, BC001Y2_A29WWPEntityId, BC001Y2_A539WWPDiscussionMessageThreadId, BC001Y2_n539WWPDiscussionMessageThreadId
               }
               , new Object[] {
               BC001Y3_A540WWPDiscussionMessageId, BC001Y3_A543WWPDiscussionMessageDate, BC001Y3_A544WWPDiscussionMessageMessage, BC001Y3_A545WWPDiscussionMessageEntityReco, BC001Y3_A1WWPUserExtendedId, BC001Y3_A29WWPEntityId, BC001Y3_A539WWPDiscussionMessageThreadId, BC001Y3_n539WWPDiscussionMessageThreadId
               }
               , new Object[] {
               BC001Y4_A40000WWPUserExtendedPhoto_GXI, BC001Y4_A2WWPUserExtendedFullName, BC001Y4_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               BC001Y5_A30WWPEntityName
               }
               , new Object[] {
               BC001Y6_A539WWPDiscussionMessageThreadId
               }
               , new Object[] {
               BC001Y7_A540WWPDiscussionMessageId, BC001Y7_A543WWPDiscussionMessageDate, BC001Y7_A544WWPDiscussionMessageMessage, BC001Y7_A40000WWPUserExtendedPhoto_GXI, BC001Y7_A2WWPUserExtendedFullName, BC001Y7_A30WWPEntityName, BC001Y7_A545WWPDiscussionMessageEntityReco, BC001Y7_A1WWPUserExtendedId, BC001Y7_A29WWPEntityId, BC001Y7_A539WWPDiscussionMessageThreadId,
               BC001Y7_n539WWPDiscussionMessageThreadId, BC001Y7_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               BC001Y8_A540WWPDiscussionMessageId
               }
               , new Object[] {
               BC001Y9_A540WWPDiscussionMessageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001Y12_A40000WWPUserExtendedPhoto_GXI, BC001Y12_A2WWPUserExtendedFullName, BC001Y12_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               BC001Y13_A30WWPEntityName
               }
               , new Object[] {
               BC001Y14_A539WWPDiscussionMessageThreadId
               }
               , new Object[] {
               BC001Y15_A540WWPDiscussionMessageId, BC001Y15_A541WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC001Y16_A540WWPDiscussionMessageId, BC001Y16_A543WWPDiscussionMessageDate, BC001Y16_A544WWPDiscussionMessageMessage, BC001Y16_A40000WWPUserExtendedPhoto_GXI, BC001Y16_A2WWPUserExtendedFullName, BC001Y16_A30WWPEntityName, BC001Y16_A545WWPDiscussionMessageEntityReco, BC001Y16_A1WWPUserExtendedId, BC001Y16_A29WWPEntityId, BC001Y16_A539WWPDiscussionMessageThreadId,
               BC001Y16_n539WWPDiscussionMessageThreadId, BC001Y16_A4WWPUserExtendedPhoto
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound78 ;
      private int trnEnded ;
      private long Z540WWPDiscussionMessageId ;
      private long A540WWPDiscussionMessageId ;
      private long Z29WWPEntityId ;
      private long A29WWPEntityId ;
      private long Z539WWPDiscussionMessageThreadId ;
      private long A539WWPDiscussionMessageThreadId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1WWPUserExtendedId ;
      private string A1WWPUserExtendedId ;
      private string GXt_char1 ;
      private string sMode78 ;
      private string i1WWPUserExtendedId ;
      private DateTime Z543WWPDiscussionMessageDate ;
      private DateTime A543WWPDiscussionMessageDate ;
      private DateTime i543WWPDiscussionMessageDate ;
      private bool n539WWPDiscussionMessageThreadId ;
      private bool Gx_longc ;
      private string Z544WWPDiscussionMessageMessage ;
      private string A544WWPDiscussionMessageMessage ;
      private string Z545WWPDiscussionMessageEntityReco ;
      private string A545WWPDiscussionMessageEntityReco ;
      private string Z2WWPUserExtendedFullName ;
      private string A2WWPUserExtendedFullName ;
      private string Z30WWPEntityName ;
      private string A30WWPEntityName ;
      private string Z40000WWPUserExtendedPhoto_GXI ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string Z4WWPUserExtendedPhoto ;
      private string A4WWPUserExtendedPhoto ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC001Y4_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC001Y4_A2WWPUserExtendedFullName ;
      private string[] BC001Y4_A4WWPUserExtendedPhoto ;
      private long[] BC001Y7_A540WWPDiscussionMessageId ;
      private DateTime[] BC001Y7_A543WWPDiscussionMessageDate ;
      private string[] BC001Y7_A544WWPDiscussionMessageMessage ;
      private string[] BC001Y7_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC001Y7_A2WWPUserExtendedFullName ;
      private string[] BC001Y7_A30WWPEntityName ;
      private string[] BC001Y7_A545WWPDiscussionMessageEntityReco ;
      private string[] BC001Y7_A1WWPUserExtendedId ;
      private long[] BC001Y7_A29WWPEntityId ;
      private long[] BC001Y7_A539WWPDiscussionMessageThreadId ;
      private bool[] BC001Y7_n539WWPDiscussionMessageThreadId ;
      private string[] BC001Y7_A4WWPUserExtendedPhoto ;
      private long[] BC001Y6_A539WWPDiscussionMessageThreadId ;
      private bool[] BC001Y6_n539WWPDiscussionMessageThreadId ;
      private string[] BC001Y5_A30WWPEntityName ;
      private long[] BC001Y8_A540WWPDiscussionMessageId ;
      private long[] BC001Y3_A540WWPDiscussionMessageId ;
      private DateTime[] BC001Y3_A543WWPDiscussionMessageDate ;
      private string[] BC001Y3_A544WWPDiscussionMessageMessage ;
      private string[] BC001Y3_A545WWPDiscussionMessageEntityReco ;
      private string[] BC001Y3_A1WWPUserExtendedId ;
      private long[] BC001Y3_A29WWPEntityId ;
      private long[] BC001Y3_A539WWPDiscussionMessageThreadId ;
      private bool[] BC001Y3_n539WWPDiscussionMessageThreadId ;
      private long[] BC001Y2_A540WWPDiscussionMessageId ;
      private DateTime[] BC001Y2_A543WWPDiscussionMessageDate ;
      private string[] BC001Y2_A544WWPDiscussionMessageMessage ;
      private string[] BC001Y2_A545WWPDiscussionMessageEntityReco ;
      private string[] BC001Y2_A1WWPUserExtendedId ;
      private long[] BC001Y2_A29WWPEntityId ;
      private long[] BC001Y2_A539WWPDiscussionMessageThreadId ;
      private bool[] BC001Y2_n539WWPDiscussionMessageThreadId ;
      private long[] BC001Y9_A540WWPDiscussionMessageId ;
      private string[] BC001Y12_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC001Y12_A2WWPUserExtendedFullName ;
      private string[] BC001Y12_A4WWPUserExtendedPhoto ;
      private string[] BC001Y13_A30WWPEntityName ;
      private long[] BC001Y14_A539WWPDiscussionMessageThreadId ;
      private bool[] BC001Y14_n539WWPDiscussionMessageThreadId ;
      private long[] BC001Y15_A540WWPDiscussionMessageId ;
      private string[] BC001Y15_A541WWPDiscussionMentionUserId ;
      private long[] BC001Y16_A540WWPDiscussionMessageId ;
      private DateTime[] BC001Y16_A543WWPDiscussionMessageDate ;
      private string[] BC001Y16_A544WWPDiscussionMessageMessage ;
      private string[] BC001Y16_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC001Y16_A2WWPUserExtendedFullName ;
      private string[] BC001Y16_A30WWPEntityName ;
      private string[] BC001Y16_A545WWPDiscussionMessageEntityReco ;
      private string[] BC001Y16_A1WWPUserExtendedId ;
      private long[] BC001Y16_A29WWPEntityId ;
      private long[] BC001Y16_A539WWPDiscussionMessageThreadId ;
      private bool[] BC001Y16_n539WWPDiscussionMessageThreadId ;
      private string[] BC001Y16_A4WWPUserExtendedPhoto ;
      private GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage bcwwpbaseobjects_discussions_WWP_DiscussionMessage ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_discussionmessage_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_discussionmessage_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC001Y2;
        prmBC001Y2 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmBC001Y3;
        prmBC001Y3 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmBC001Y4;
        prmBC001Y4 = new Object[] {
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0)
        };
        Object[] prmBC001Y5;
        prmBC001Y5 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmBC001Y6;
        prmBC001Y6 = new Object[] {
        new ParDef("@WWPDiscussionMessageThreadId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC001Y7;
        prmBC001Y7 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmBC001Y8;
        prmBC001Y8 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmBC001Y9;
        prmBC001Y9 = new Object[] {
        new ParDef("@WWPDiscussionMessageDate",GXType.DateTime,8,5) ,
        new ParDef("@WWPDiscussionMessageMessage",GXType.NVarChar,400,0) ,
        new ParDef("@WWPDiscussionMessageEntityReco",GXType.NVarChar,100,0) ,
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0) ,
        new ParDef("@WWPEntityId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMessageThreadId",GXType.Decimal,10,0){Nullable=true}
        };
        Object[] prmBC001Y10;
        prmBC001Y10 = new Object[] {
        new ParDef("@WWPDiscussionMessageDate",GXType.DateTime,8,5) ,
        new ParDef("@WWPDiscussionMessageMessage",GXType.NVarChar,400,0) ,
        new ParDef("@WWPDiscussionMessageEntityReco",GXType.NVarChar,100,0) ,
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0) ,
        new ParDef("@WWPEntityId",GXType.Decimal,10,0) ,
        new ParDef("@WWPDiscussionMessageThreadId",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmBC001Y11;
        prmBC001Y11 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmBC001Y12;
        prmBC001Y12 = new Object[] {
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0)
        };
        Object[] prmBC001Y13;
        prmBC001Y13 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmBC001Y14;
        prmBC001Y14 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmBC001Y15;
        prmBC001Y15 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        Object[] prmBC001Y16;
        prmBC001Y16 = new Object[] {
        new ParDef("@WWPDiscussionMessageId",GXType.Decimal,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC001Y2", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMessageDate], [WWPDiscussionMessageMessage], [WWPDiscussionMessageEntityReco], [WWPUserExtendedId], [WWPEntityId], [WWPDiscussionMessageThreadId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WITH (UPDLOCK) WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Y3", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMessageDate], [WWPDiscussionMessageMessage], [WWPDiscussionMessageEntityReco], [WWPUserExtendedId], [WWPEntityId], [WWPDiscussionMessageThreadId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Y4", "SELECT [WWPUserExtendedPhoto_GXI], [WWPUserExtendedFullName], [WWPUserExtendedPhoto] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Y5", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Y6", "SELECT [WWPDiscussionMessageId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageThreadId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Y7", "SELECT TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMessageDate], TM1.[WWPDiscussionMessageMessage], T2.[WWPUserExtendedPhoto_GXI], T2.[WWPUserExtendedFullName], T3.[WWPEntityName], TM1.[WWPDiscussionMessageEntityReco], TM1.[WWPUserExtendedId], TM1.[WWPEntityId], TM1.[WWPDiscussionMessageThreadId] AS WWPDiscussionMessageThreadId, T2.[WWPUserExtendedPhoto] FROM (([WWP_DiscussionMessage] TM1 INNER JOIN [WWP_UserExtended] T2 ON T2.[WWPUserExtendedId] = TM1.[WWPUserExtendedId]) INNER JOIN [WWP_Entity] T3 ON T3.[WWPEntityId] = TM1.[WWPEntityId]) WHERE TM1.[WWPDiscussionMessageId] = @WWPDiscussionMessageId ORDER BY TM1.[WWPDiscussionMessageId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Y8", "SELECT [WWPDiscussionMessageId] FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Y9", "INSERT INTO [WWP_DiscussionMessage]([WWPDiscussionMessageDate], [WWPDiscussionMessageMessage], [WWPDiscussionMessageEntityReco], [WWPUserExtendedId], [WWPEntityId], [WWPDiscussionMessageThreadId]) VALUES(@WWPDiscussionMessageDate, @WWPDiscussionMessageMessage, @WWPDiscussionMessageEntityReco, @WWPUserExtendedId, @WWPEntityId, @WWPDiscussionMessageThreadId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001Y10", "UPDATE [WWP_DiscussionMessage] SET [WWPDiscussionMessageDate]=@WWPDiscussionMessageDate, [WWPDiscussionMessageMessage]=@WWPDiscussionMessageMessage, [WWPDiscussionMessageEntityReco]=@WWPDiscussionMessageEntityReco, [WWPUserExtendedId]=@WWPUserExtendedId, [WWPEntityId]=@WWPEntityId, [WWPDiscussionMessageThreadId]=@WWPDiscussionMessageThreadId  WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId", GxErrorMask.GX_NOMASK,prmBC001Y10)
           ,new CursorDef("BC001Y11", "DELETE FROM [WWP_DiscussionMessage]  WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId", GxErrorMask.GX_NOMASK,prmBC001Y11)
           ,new CursorDef("BC001Y12", "SELECT [WWPUserExtendedPhoto_GXI], [WWPUserExtendedFullName], [WWPUserExtendedPhoto] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Y13", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001Y14", "SELECT TOP 1 [WWPDiscussionMessageId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageThreadId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001Y15", "SELECT TOP 1 [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] FROM [WWP_DiscussionMessageMention] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001Y16", "SELECT TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMessageDate], TM1.[WWPDiscussionMessageMessage], T2.[WWPUserExtendedPhoto_GXI], T2.[WWPUserExtendedFullName], T3.[WWPEntityName], TM1.[WWPDiscussionMessageEntityReco], TM1.[WWPUserExtendedId], TM1.[WWPEntityId], TM1.[WWPDiscussionMessageThreadId] AS WWPDiscussionMessageThreadId, T2.[WWPUserExtendedPhoto] FROM (([WWP_DiscussionMessage] TM1 INNER JOIN [WWP_UserExtended] T2 ON T2.[WWPUserExtendedId] = TM1.[WWPUserExtendedId]) INNER JOIN [WWP_Entity] T3 ON T3.[WWPEntityId] = TM1.[WWPEntityId]) WHERE TM1.[WWPDiscussionMessageId] = @WWPDiscussionMessageId ORDER BY TM1.[WWPDiscussionMessageId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y16,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
              return;
     }
  }

}

}
