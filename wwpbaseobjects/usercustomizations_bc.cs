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
namespace GeneXus.Programs.wwpbaseobjects {
   public class usercustomizations_bc : GXHttpHandler, IGxSilentTrn
   {
      public usercustomizations_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usercustomizations_bc( IGxContext context )
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
         ReadRow0H19( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0H19( ) ;
         standaloneModal( ) ;
         AddRow0H19( ) ;
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
               Z103UserCustomizationsId = A103UserCustomizationsId;
               Z104UserCustomizationsKey = A104UserCustomizationsKey;
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

      protected void CONFIRM_0H0( )
      {
         BeforeValidate0H19( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0H19( ) ;
            }
            else
            {
               CheckExtendedTable0H19( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0H19( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0H19( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z103UserCustomizationsId = A103UserCustomizationsId;
            Z104UserCustomizationsKey = A104UserCustomizationsKey;
            Z105UserCustomizationsValue = A105UserCustomizationsValue;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0H19( )
      {
         /* Using cursor BC000H4 */
         pr_default.execute(2, new Object[] {A103UserCustomizationsId, A104UserCustomizationsKey});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound19 = 1;
            A105UserCustomizationsValue = BC000H4_A105UserCustomizationsValue[0];
            ZM0H19( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0H19( ) ;
      }

      protected void OnLoadActions0H19( )
      {
      }

      protected void CheckExtendedTable0H19( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0H19( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0H19( )
      {
         /* Using cursor BC000H5 */
         pr_default.execute(3, new Object[] {A103UserCustomizationsId, A104UserCustomizationsKey});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000H3 */
         pr_default.execute(1, new Object[] {A103UserCustomizationsId, A104UserCustomizationsKey});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H19( 1) ;
            RcdFound19 = 1;
            A103UserCustomizationsId = BC000H3_A103UserCustomizationsId[0];
            A104UserCustomizationsKey = BC000H3_A104UserCustomizationsKey[0];
            A105UserCustomizationsValue = BC000H3_A105UserCustomizationsValue[0];
            Z103UserCustomizationsId = A103UserCustomizationsId;
            Z104UserCustomizationsKey = A104UserCustomizationsKey;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0H19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0H19( ) ;
            }
            Gx_mode = sMode19;
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0H19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode19;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H19( ) ;
         if ( RcdFound19 == 0 )
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
         CONFIRM_0H0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0H19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000H2 */
            pr_default.execute(0, new Object[] {A103UserCustomizationsId, A104UserCustomizationsKey});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UserCustomizations"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"UserCustomizations"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H19( )
      {
         BeforeValidate0H19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H19( 0) ;
            CheckOptimisticConcurrency0H19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H6 */
                     pr_default.execute(4, new Object[] {A103UserCustomizationsId, A104UserCustomizationsKey, A105UserCustomizationsValue});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("UserCustomizations");
                     if ( (pr_default.getStatus(4) == 1) )
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
               Load0H19( ) ;
            }
            EndLevel0H19( ) ;
         }
         CloseExtendedTableCursors0H19( ) ;
      }

      protected void Update0H19( )
      {
         BeforeValidate0H19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H7 */
                     pr_default.execute(5, new Object[] {A105UserCustomizationsValue, A103UserCustomizationsId, A104UserCustomizationsKey});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("UserCustomizations");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UserCustomizations"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0H19( ) ;
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
            EndLevel0H19( ) ;
         }
         CloseExtendedTableCursors0H19( ) ;
      }

      protected void DeferredUpdate0H19( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0H19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H19( ) ;
            AfterConfirm0H19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000H8 */
                  pr_default.execute(6, new Object[] {A103UserCustomizationsId, A104UserCustomizationsKey});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("UserCustomizations");
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0H19( ) ;
         Gx_mode = sMode19;
      }

      protected void OnDeleteControls0H19( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0H19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H19( ) ;
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

      public void ScanKeyStart0H19( )
      {
         /* Using cursor BC000H9 */
         pr_default.execute(7, new Object[] {A103UserCustomizationsId, A104UserCustomizationsKey});
         RcdFound19 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound19 = 1;
            A103UserCustomizationsId = BC000H9_A103UserCustomizationsId[0];
            A104UserCustomizationsKey = BC000H9_A104UserCustomizationsKey[0];
            A105UserCustomizationsValue = BC000H9_A105UserCustomizationsValue[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0H19( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound19 = 0;
         ScanKeyLoad0H19( ) ;
      }

      protected void ScanKeyLoad0H19( )
      {
         sMode19 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound19 = 1;
            A103UserCustomizationsId = BC000H9_A103UserCustomizationsId[0];
            A104UserCustomizationsKey = BC000H9_A104UserCustomizationsKey[0];
            A105UserCustomizationsValue = BC000H9_A105UserCustomizationsValue[0];
         }
         Gx_mode = sMode19;
      }

      protected void ScanKeyEnd0H19( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0H19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0H19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H19( )
      {
      }

      protected void send_integrity_lvl_hashes0H19( )
      {
      }

      protected void AddRow0H19( )
      {
         VarsToRow19( bcwwpbaseobjects_UserCustomizations) ;
      }

      protected void ReadRow0H19( )
      {
         RowToVars19( bcwwpbaseobjects_UserCustomizations, 1) ;
      }

      protected void InitializeNonKey0H19( )
      {
         A105UserCustomizationsValue = "";
      }

      protected void InitAll0H19( )
      {
         A103UserCustomizationsId = 0;
         A104UserCustomizationsKey = "";
         InitializeNonKey0H19( ) ;
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

      public void VarsToRow19( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj19 )
      {
         obj19.gxTpr_Mode = Gx_mode;
         obj19.gxTpr_Usercustomizationsvalue = A105UserCustomizationsValue;
         obj19.gxTpr_Usercustomizationsid = A103UserCustomizationsId;
         obj19.gxTpr_Usercustomizationskey = A104UserCustomizationsKey;
         obj19.gxTpr_Usercustomizationsid_Z = Z103UserCustomizationsId;
         obj19.gxTpr_Usercustomizationskey_Z = Z104UserCustomizationsKey;
         obj19.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow19( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj19 )
      {
         obj19.gxTpr_Usercustomizationsid = A103UserCustomizationsId;
         obj19.gxTpr_Usercustomizationskey = A104UserCustomizationsKey;
         return  ;
      }

      public void RowToVars19( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj19 ,
                               int forceLoad )
      {
         Gx_mode = obj19.gxTpr_Mode;
         A105UserCustomizationsValue = obj19.gxTpr_Usercustomizationsvalue;
         A103UserCustomizationsId = obj19.gxTpr_Usercustomizationsid;
         A104UserCustomizationsKey = obj19.gxTpr_Usercustomizationskey;
         Z103UserCustomizationsId = obj19.gxTpr_Usercustomizationsid_Z;
         Z104UserCustomizationsKey = obj19.gxTpr_Usercustomizationskey_Z;
         Gx_mode = obj19.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A103UserCustomizationsId = (int)getParm(obj,0);
         A104UserCustomizationsKey = (string)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0H19( ) ;
         ScanKeyStart0H19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z103UserCustomizationsId = A103UserCustomizationsId;
            Z104UserCustomizationsKey = A104UserCustomizationsKey;
         }
         ZM0H19( -1) ;
         OnLoadActions0H19( ) ;
         AddRow0H19( ) ;
         ScanKeyEnd0H19( ) ;
         if ( RcdFound19 == 0 )
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
         RowToVars19( bcwwpbaseobjects_UserCustomizations, 0) ;
         ScanKeyStart0H19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z103UserCustomizationsId = A103UserCustomizationsId;
            Z104UserCustomizationsKey = A104UserCustomizationsKey;
         }
         ZM0H19( -1) ;
         OnLoadActions0H19( ) ;
         AddRow0H19( ) ;
         ScanKeyEnd0H19( ) ;
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0H19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0H19( ) ;
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( ( A103UserCustomizationsId != Z103UserCustomizationsId ) || ( StringUtil.StrCmp(A104UserCustomizationsKey, Z104UserCustomizationsKey) != 0 ) )
               {
                  A103UserCustomizationsId = Z103UserCustomizationsId;
                  A104UserCustomizationsKey = Z104UserCustomizationsKey;
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
                  Update0H19( ) ;
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
                  if ( ( A103UserCustomizationsId != Z103UserCustomizationsId ) || ( StringUtil.StrCmp(A104UserCustomizationsKey, Z104UserCustomizationsKey) != 0 ) )
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
                        Insert0H19( ) ;
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
                        Insert0H19( ) ;
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
         RowToVars19( bcwwpbaseobjects_UserCustomizations, 1) ;
         SaveImpl( ) ;
         VarsToRow19( bcwwpbaseobjects_UserCustomizations) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars19( bcwwpbaseobjects_UserCustomizations, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H19( ) ;
         AfterTrn( ) ;
         VarsToRow19( bcwwpbaseobjects_UserCustomizations) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow19( bcwwpbaseobjects_UserCustomizations) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations auxBC = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A103UserCustomizationsId, A104UserCustomizationsKey);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_UserCustomizations);
               auxBC.Save();
               bcwwpbaseobjects_UserCustomizations.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars19( bcwwpbaseobjects_UserCustomizations, 1) ;
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
         RowToVars19( bcwwpbaseobjects_UserCustomizations, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H19( ) ;
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
               VarsToRow19( bcwwpbaseobjects_UserCustomizations) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow19( bcwwpbaseobjects_UserCustomizations) ;
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
         RowToVars19( bcwwpbaseobjects_UserCustomizations, 0) ;
         GetKey0H19( ) ;
         if ( RcdFound19 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A103UserCustomizationsId != Z103UserCustomizationsId ) || ( StringUtil.StrCmp(A104UserCustomizationsKey, Z104UserCustomizationsKey) != 0 ) )
            {
               A103UserCustomizationsId = Z103UserCustomizationsId;
               A104UserCustomizationsKey = Z104UserCustomizationsKey;
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
            if ( ( A103UserCustomizationsId != Z103UserCustomizationsId ) || ( StringUtil.StrCmp(A104UserCustomizationsKey, Z104UserCustomizationsKey) != 0 ) )
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
         context.RollbackDataStores("wwpbaseobjects.usercustomizations_bc",pr_default);
         VarsToRow19( bcwwpbaseobjects_UserCustomizations) ;
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
         Gx_mode = bcwwpbaseobjects_UserCustomizations.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_UserCustomizations )
         {
            bcwwpbaseobjects_UserCustomizations = (GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_UserCustomizations.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow19( bcwwpbaseobjects_UserCustomizations) ;
            }
            else
            {
               RowToVars19( bcwwpbaseobjects_UserCustomizations, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_UserCustomizations.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars19( bcwwpbaseobjects_UserCustomizations, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtUserCustomizations UserCustomizations_BC
      {
         get {
            return bcwwpbaseobjects_UserCustomizations ;
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
         Z104UserCustomizationsKey = "";
         A104UserCustomizationsKey = "";
         Z105UserCustomizationsValue = "";
         A105UserCustomizationsValue = "";
         BC000H4_A103UserCustomizationsId = new int[1] ;
         BC000H4_A104UserCustomizationsKey = new string[] {""} ;
         BC000H4_A105UserCustomizationsValue = new string[] {""} ;
         BC000H5_A103UserCustomizationsId = new int[1] ;
         BC000H5_A104UserCustomizationsKey = new string[] {""} ;
         BC000H3_A103UserCustomizationsId = new int[1] ;
         BC000H3_A104UserCustomizationsKey = new string[] {""} ;
         BC000H3_A105UserCustomizationsValue = new string[] {""} ;
         sMode19 = "";
         BC000H2_A103UserCustomizationsId = new int[1] ;
         BC000H2_A104UserCustomizationsKey = new string[] {""} ;
         BC000H2_A105UserCustomizationsValue = new string[] {""} ;
         BC000H9_A103UserCustomizationsId = new int[1] ;
         BC000H9_A104UserCustomizationsKey = new string[] {""} ;
         BC000H9_A105UserCustomizationsValue = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.usercustomizations_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.usercustomizations_bc__default(),
            new Object[][] {
                new Object[] {
               BC000H2_A103UserCustomizationsId, BC000H2_A104UserCustomizationsKey, BC000H2_A105UserCustomizationsValue
               }
               , new Object[] {
               BC000H3_A103UserCustomizationsId, BC000H3_A104UserCustomizationsKey, BC000H3_A105UserCustomizationsValue
               }
               , new Object[] {
               BC000H4_A103UserCustomizationsId, BC000H4_A104UserCustomizationsKey, BC000H4_A105UserCustomizationsValue
               }
               , new Object[] {
               BC000H5_A103UserCustomizationsId, BC000H5_A104UserCustomizationsKey
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000H9_A103UserCustomizationsId, BC000H9_A104UserCustomizationsKey, BC000H9_A105UserCustomizationsValue
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound19 ;
      private int trnEnded ;
      private int Z103UserCustomizationsId ;
      private int A103UserCustomizationsId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode19 ;
      private string Z105UserCustomizationsValue ;
      private string A105UserCustomizationsValue ;
      private string Z104UserCustomizationsKey ;
      private string A104UserCustomizationsKey ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000H4_A103UserCustomizationsId ;
      private string[] BC000H4_A104UserCustomizationsKey ;
      private string[] BC000H4_A105UserCustomizationsValue ;
      private int[] BC000H5_A103UserCustomizationsId ;
      private string[] BC000H5_A104UserCustomizationsKey ;
      private int[] BC000H3_A103UserCustomizationsId ;
      private string[] BC000H3_A104UserCustomizationsKey ;
      private string[] BC000H3_A105UserCustomizationsValue ;
      private int[] BC000H2_A103UserCustomizationsId ;
      private string[] BC000H2_A104UserCustomizationsKey ;
      private string[] BC000H2_A105UserCustomizationsValue ;
      private int[] BC000H9_A103UserCustomizationsId ;
      private string[] BC000H9_A104UserCustomizationsKey ;
      private string[] BC000H9_A105UserCustomizationsValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations bcwwpbaseobjects_UserCustomizations ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class usercustomizations_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class usercustomizations_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new UpdateCursor(def[4])
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
        Object[] prmBC000H2;
        prmBC000H2 = new Object[] {
        new ParDef("@UserCustomizationsId",GXType.Int32,6,0) ,
        new ParDef("@UserCustomizationsKey",GXType.NVarChar,200,0)
        };
        Object[] prmBC000H3;
        prmBC000H3 = new Object[] {
        new ParDef("@UserCustomizationsId",GXType.Int32,6,0) ,
        new ParDef("@UserCustomizationsKey",GXType.NVarChar,200,0)
        };
        Object[] prmBC000H4;
        prmBC000H4 = new Object[] {
        new ParDef("@UserCustomizationsId",GXType.Int32,6,0) ,
        new ParDef("@UserCustomizationsKey",GXType.NVarChar,200,0)
        };
        Object[] prmBC000H5;
        prmBC000H5 = new Object[] {
        new ParDef("@UserCustomizationsId",GXType.Int32,6,0) ,
        new ParDef("@UserCustomizationsKey",GXType.NVarChar,200,0)
        };
        Object[] prmBC000H6;
        prmBC000H6 = new Object[] {
        new ParDef("@UserCustomizationsId",GXType.Int32,6,0) ,
        new ParDef("@UserCustomizationsKey",GXType.NVarChar,200,0) ,
        new ParDef("@UserCustomizationsValue",GXType.NVarChar,2097152,0)
        };
        Object[] prmBC000H7;
        prmBC000H7 = new Object[] {
        new ParDef("@UserCustomizationsValue",GXType.NVarChar,2097152,0) ,
        new ParDef("@UserCustomizationsId",GXType.Int32,6,0) ,
        new ParDef("@UserCustomizationsKey",GXType.NVarChar,200,0)
        };
        Object[] prmBC000H8;
        prmBC000H8 = new Object[] {
        new ParDef("@UserCustomizationsId",GXType.Int32,6,0) ,
        new ParDef("@UserCustomizationsKey",GXType.NVarChar,200,0)
        };
        Object[] prmBC000H9;
        prmBC000H9 = new Object[] {
        new ParDef("@UserCustomizationsId",GXType.Int32,6,0) ,
        new ParDef("@UserCustomizationsKey",GXType.NVarChar,200,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000H2", "SELECT [UserCustomizationsId], [UserCustomizationsKey], [UserCustomizationsValue] FROM [UserCustomizations] WITH (UPDLOCK) WHERE [UserCustomizationsId] = @UserCustomizationsId AND [UserCustomizationsKey] = @UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H3", "SELECT [UserCustomizationsId], [UserCustomizationsKey], [UserCustomizationsValue] FROM [UserCustomizations] WHERE [UserCustomizationsId] = @UserCustomizationsId AND [UserCustomizationsKey] = @UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H4", "SELECT TM1.[UserCustomizationsId], TM1.[UserCustomizationsKey], TM1.[UserCustomizationsValue] FROM [UserCustomizations] TM1 WHERE TM1.[UserCustomizationsId] = @UserCustomizationsId and TM1.[UserCustomizationsKey] = @UserCustomizationsKey ORDER BY TM1.[UserCustomizationsId], TM1.[UserCustomizationsKey]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H5", "SELECT [UserCustomizationsId], [UserCustomizationsKey] FROM [UserCustomizations] WHERE [UserCustomizationsId] = @UserCustomizationsId AND [UserCustomizationsKey] = @UserCustomizationsKey  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H6", "INSERT INTO [UserCustomizations]([UserCustomizationsId], [UserCustomizationsKey], [UserCustomizationsValue]) VALUES(@UserCustomizationsId, @UserCustomizationsKey, @UserCustomizationsValue)", GxErrorMask.GX_NOMASK,prmBC000H6)
           ,new CursorDef("BC000H7", "UPDATE [UserCustomizations] SET [UserCustomizationsValue]=@UserCustomizationsValue  WHERE [UserCustomizationsId] = @UserCustomizationsId AND [UserCustomizationsKey] = @UserCustomizationsKey", GxErrorMask.GX_NOMASK,prmBC000H7)
           ,new CursorDef("BC000H8", "DELETE FROM [UserCustomizations]  WHERE [UserCustomizationsId] = @UserCustomizationsId AND [UserCustomizationsKey] = @UserCustomizationsKey", GxErrorMask.GX_NOMASK,prmBC000H8)
           ,new CursorDef("BC000H9", "SELECT TM1.[UserCustomizationsId], TM1.[UserCustomizationsKey], TM1.[UserCustomizationsValue] FROM [UserCustomizations] TM1 WHERE TM1.[UserCustomizationsId] = @UserCustomizationsId and TM1.[UserCustomizationsKey] = @UserCustomizationsKey ORDER BY TM1.[UserCustomizationsId], TM1.[UserCustomizationsKey]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H9,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
     }
  }

}

}
