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
namespace GeneXus.Programs {
   public class plog_bc : GXHttpHandler, IGxSilentTrn
   {
      public plog_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public plog_bc( IGxContext context )
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
         ReadRow2I117( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2I117( ) ;
         standaloneModal( ) ;
         AddRow2I117( ) ;
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
               Z725PlogId = A725PlogId;
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

      protected void CONFIRM_2I0( )
      {
         BeforeValidate2I117( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2I117( ) ;
            }
            else
            {
               CheckExtendedTable2I117( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors2I117( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM2I117( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z725PlogId = A725PlogId;
            Z726PlogMsg = A726PlogMsg;
            Z727PlogPgm = A727PlogPgm;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2I117( )
      {
         /* Using cursor BC002I4 */
         pr_default.execute(2, new Object[] {A725PlogId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound117 = 1;
            A726PlogMsg = BC002I4_A726PlogMsg[0];
            A727PlogPgm = BC002I4_A727PlogPgm[0];
            ZM2I117( -1) ;
         }
         pr_default.close(2);
         OnLoadActions2I117( ) ;
      }

      protected void OnLoadActions2I117( )
      {
      }

      protected void CheckExtendedTable2I117( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors2I117( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2I117( )
      {
         /* Using cursor BC002I5 */
         pr_default.execute(3, new Object[] {A725PlogId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound117 = 1;
         }
         else
         {
            RcdFound117 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002I3 */
         pr_default.execute(1, new Object[] {A725PlogId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2I117( 1) ;
            RcdFound117 = 1;
            A725PlogId = BC002I3_A725PlogId[0];
            A726PlogMsg = BC002I3_A726PlogMsg[0];
            A727PlogPgm = BC002I3_A727PlogPgm[0];
            Z725PlogId = A725PlogId;
            sMode117 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2I117( ) ;
            if ( AnyError == 1 )
            {
               RcdFound117 = 0;
               InitializeNonKey2I117( ) ;
            }
            Gx_mode = sMode117;
         }
         else
         {
            RcdFound117 = 0;
            InitializeNonKey2I117( ) ;
            sMode117 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode117;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2I117( ) ;
         if ( RcdFound117 == 0 )
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
         CONFIRM_2I0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2I117( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002I2 */
            pr_default.execute(0, new Object[] {A725PlogId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Plog"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Plog"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2I117( )
      {
         BeforeValidate2I117( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2I117( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2I117( 0) ;
            CheckOptimisticConcurrency2I117( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2I117( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2I117( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002I6 */
                     pr_default.execute(4, new Object[] {A726PlogMsg, A727PlogPgm});
                     A725PlogId = BC002I6_A725PlogId[0];
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Plog");
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
               Load2I117( ) ;
            }
            EndLevel2I117( ) ;
         }
         CloseExtendedTableCursors2I117( ) ;
      }

      protected void Update2I117( )
      {
         BeforeValidate2I117( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2I117( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2I117( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2I117( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2I117( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002I7 */
                     pr_default.execute(5, new Object[] {A726PlogMsg, A727PlogPgm, A725PlogId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Plog");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Plog"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2I117( ) ;
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
            EndLevel2I117( ) ;
         }
         CloseExtendedTableCursors2I117( ) ;
      }

      protected void DeferredUpdate2I117( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2I117( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2I117( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2I117( ) ;
            AfterConfirm2I117( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2I117( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002I8 */
                  pr_default.execute(6, new Object[] {A725PlogId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Plog");
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
         sMode117 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2I117( ) ;
         Gx_mode = sMode117;
      }

      protected void OnDeleteControls2I117( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2I117( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2I117( ) ;
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

      public void ScanKeyStart2I117( )
      {
         /* Using cursor BC002I9 */
         pr_default.execute(7, new Object[] {A725PlogId});
         RcdFound117 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound117 = 1;
            A725PlogId = BC002I9_A725PlogId[0];
            A726PlogMsg = BC002I9_A726PlogMsg[0];
            A727PlogPgm = BC002I9_A727PlogPgm[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2I117( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound117 = 0;
         ScanKeyLoad2I117( ) ;
      }

      protected void ScanKeyLoad2I117( )
      {
         sMode117 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound117 = 1;
            A725PlogId = BC002I9_A725PlogId[0];
            A726PlogMsg = BC002I9_A726PlogMsg[0];
            A727PlogPgm = BC002I9_A727PlogPgm[0];
         }
         Gx_mode = sMode117;
      }

      protected void ScanKeyEnd2I117( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm2I117( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2I117( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2I117( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2I117( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2I117( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2I117( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2I117( )
      {
      }

      protected void send_integrity_lvl_hashes2I117( )
      {
      }

      protected void AddRow2I117( )
      {
         VarsToRow117( bcPlog) ;
      }

      protected void ReadRow2I117( )
      {
         RowToVars117( bcPlog, 1) ;
      }

      protected void InitializeNonKey2I117( )
      {
         A726PlogMsg = "";
         A727PlogPgm = "";
      }

      protected void InitAll2I117( )
      {
         A725PlogId = 0;
         InitializeNonKey2I117( ) ;
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

      public void VarsToRow117( SdtPlog obj117 )
      {
         obj117.gxTpr_Mode = Gx_mode;
         obj117.gxTpr_Plogmsg = A726PlogMsg;
         obj117.gxTpr_Plogpgm = A727PlogPgm;
         obj117.gxTpr_Plogid = A725PlogId;
         obj117.gxTpr_Plogid_Z = Z725PlogId;
         obj117.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow117( SdtPlog obj117 )
      {
         obj117.gxTpr_Plogid = A725PlogId;
         return  ;
      }

      public void RowToVars117( SdtPlog obj117 ,
                                int forceLoad )
      {
         Gx_mode = obj117.gxTpr_Mode;
         A726PlogMsg = obj117.gxTpr_Plogmsg;
         A727PlogPgm = obj117.gxTpr_Plogpgm;
         A725PlogId = obj117.gxTpr_Plogid;
         Z725PlogId = obj117.gxTpr_Plogid_Z;
         Gx_mode = obj117.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A725PlogId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2I117( ) ;
         ScanKeyStart2I117( ) ;
         if ( RcdFound117 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z725PlogId = A725PlogId;
         }
         ZM2I117( -1) ;
         OnLoadActions2I117( ) ;
         AddRow2I117( ) ;
         ScanKeyEnd2I117( ) ;
         if ( RcdFound117 == 0 )
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
         RowToVars117( bcPlog, 0) ;
         ScanKeyStart2I117( ) ;
         if ( RcdFound117 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z725PlogId = A725PlogId;
         }
         ZM2I117( -1) ;
         OnLoadActions2I117( ) ;
         AddRow2I117( ) ;
         ScanKeyEnd2I117( ) ;
         if ( RcdFound117 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2I117( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2I117( ) ;
         }
         else
         {
            if ( RcdFound117 == 1 )
            {
               if ( A725PlogId != Z725PlogId )
               {
                  A725PlogId = Z725PlogId;
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
                  Update2I117( ) ;
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
                  if ( A725PlogId != Z725PlogId )
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
                        Insert2I117( ) ;
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
                        Insert2I117( ) ;
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
         RowToVars117( bcPlog, 1) ;
         SaveImpl( ) ;
         VarsToRow117( bcPlog) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars117( bcPlog, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2I117( ) ;
         AfterTrn( ) ;
         VarsToRow117( bcPlog) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow117( bcPlog) ;
         }
         else
         {
            SdtPlog auxBC = new SdtPlog(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A725PlogId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPlog);
               auxBC.Save();
               bcPlog.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars117( bcPlog, 1) ;
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
         RowToVars117( bcPlog, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2I117( ) ;
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
               VarsToRow117( bcPlog) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow117( bcPlog) ;
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
         RowToVars117( bcPlog, 0) ;
         GetKey2I117( ) ;
         if ( RcdFound117 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A725PlogId != Z725PlogId )
            {
               A725PlogId = Z725PlogId;
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
            if ( A725PlogId != Z725PlogId )
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
         context.RollbackDataStores("plog_bc",pr_default);
         VarsToRow117( bcPlog) ;
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
         Gx_mode = bcPlog.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPlog.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPlog )
         {
            bcPlog = (SdtPlog)(sdt);
            if ( StringUtil.StrCmp(bcPlog.gxTpr_Mode, "") == 0 )
            {
               bcPlog.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow117( bcPlog) ;
            }
            else
            {
               RowToVars117( bcPlog, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPlog.gxTpr_Mode, "") == 0 )
            {
               bcPlog.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars117( bcPlog, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPlog Plog_BC
      {
         get {
            return bcPlog ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z726PlogMsg = "";
         A726PlogMsg = "";
         Z727PlogPgm = "";
         A727PlogPgm = "";
         BC002I4_A725PlogId = new short[1] ;
         BC002I4_A726PlogMsg = new string[] {""} ;
         BC002I4_A727PlogPgm = new string[] {""} ;
         BC002I5_A725PlogId = new short[1] ;
         BC002I3_A725PlogId = new short[1] ;
         BC002I3_A726PlogMsg = new string[] {""} ;
         BC002I3_A727PlogPgm = new string[] {""} ;
         sMode117 = "";
         BC002I2_A725PlogId = new short[1] ;
         BC002I2_A726PlogMsg = new string[] {""} ;
         BC002I2_A727PlogPgm = new string[] {""} ;
         BC002I6_A725PlogId = new short[1] ;
         BC002I9_A725PlogId = new short[1] ;
         BC002I9_A726PlogMsg = new string[] {""} ;
         BC002I9_A727PlogPgm = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.plog_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.plog_bc__default(),
            new Object[][] {
                new Object[] {
               BC002I2_A725PlogId, BC002I2_A726PlogMsg, BC002I2_A727PlogPgm
               }
               , new Object[] {
               BC002I3_A725PlogId, BC002I3_A726PlogMsg, BC002I3_A727PlogPgm
               }
               , new Object[] {
               BC002I4_A725PlogId, BC002I4_A726PlogMsg, BC002I4_A727PlogPgm
               }
               , new Object[] {
               BC002I5_A725PlogId
               }
               , new Object[] {
               BC002I6_A725PlogId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002I9_A725PlogId, BC002I9_A726PlogMsg, BC002I9_A727PlogPgm
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z725PlogId ;
      private short A725PlogId ;
      private short RcdFound117 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode117 ;
      private string Z726PlogMsg ;
      private string A726PlogMsg ;
      private string Z727PlogPgm ;
      private string A727PlogPgm ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC002I4_A725PlogId ;
      private string[] BC002I4_A726PlogMsg ;
      private string[] BC002I4_A727PlogPgm ;
      private short[] BC002I5_A725PlogId ;
      private short[] BC002I3_A725PlogId ;
      private string[] BC002I3_A726PlogMsg ;
      private string[] BC002I3_A727PlogPgm ;
      private short[] BC002I2_A725PlogId ;
      private string[] BC002I2_A726PlogMsg ;
      private string[] BC002I2_A727PlogPgm ;
      private short[] BC002I6_A725PlogId ;
      private short[] BC002I9_A725PlogId ;
      private string[] BC002I9_A726PlogMsg ;
      private string[] BC002I9_A727PlogPgm ;
      private SdtPlog bcPlog ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class plog_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class plog_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC002I2;
        prmBC002I2 = new Object[] {
        new ParDef("@PlogId",GXType.Int16,4,0)
        };
        Object[] prmBC002I3;
        prmBC002I3 = new Object[] {
        new ParDef("@PlogId",GXType.Int16,4,0)
        };
        Object[] prmBC002I4;
        prmBC002I4 = new Object[] {
        new ParDef("@PlogId",GXType.Int16,4,0)
        };
        Object[] prmBC002I5;
        prmBC002I5 = new Object[] {
        new ParDef("@PlogId",GXType.Int16,4,0)
        };
        Object[] prmBC002I6;
        prmBC002I6 = new Object[] {
        new ParDef("@PlogMsg",GXType.NVarChar,2097152,0) ,
        new ParDef("@PlogPgm",GXType.NVarChar,2097152,0)
        };
        Object[] prmBC002I7;
        prmBC002I7 = new Object[] {
        new ParDef("@PlogMsg",GXType.NVarChar,2097152,0) ,
        new ParDef("@PlogPgm",GXType.NVarChar,2097152,0) ,
        new ParDef("@PlogId",GXType.Int16,4,0)
        };
        Object[] prmBC002I8;
        prmBC002I8 = new Object[] {
        new ParDef("@PlogId",GXType.Int16,4,0)
        };
        Object[] prmBC002I9;
        prmBC002I9 = new Object[] {
        new ParDef("@PlogId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC002I2", "SELECT [PlogId], [PlogMsg], [PlogPgm] FROM [Plog] WITH (UPDLOCK) WHERE [PlogId] = @PlogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002I3", "SELECT [PlogId], [PlogMsg], [PlogPgm] FROM [Plog] WHERE [PlogId] = @PlogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002I4", "SELECT TM1.[PlogId], TM1.[PlogMsg], TM1.[PlogPgm] FROM [Plog] TM1 WHERE TM1.[PlogId] = @PlogId ORDER BY TM1.[PlogId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002I4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002I5", "SELECT [PlogId] FROM [Plog] WHERE [PlogId] = @PlogId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002I5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002I6", "INSERT INTO [Plog]([PlogMsg], [PlogPgm]) VALUES(@PlogMsg, @PlogPgm); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC002I6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC002I7", "UPDATE [Plog] SET [PlogMsg]=@PlogMsg, [PlogPgm]=@PlogPgm  WHERE [PlogId] = @PlogId", GxErrorMask.GX_NOMASK,prmBC002I7)
           ,new CursorDef("BC002I8", "DELETE FROM [Plog]  WHERE [PlogId] = @PlogId", GxErrorMask.GX_NOMASK,prmBC002I8)
           ,new CursorDef("BC002I9", "SELECT TM1.[PlogId], TM1.[PlogMsg], TM1.[PlogPgm] FROM [Plog] TM1 WHERE TM1.[PlogId] = @PlogId ORDER BY TM1.[PlogId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002I9,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
     }
  }

}

}
