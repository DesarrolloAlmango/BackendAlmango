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
   public class secfunctionalityrole_bc : GXHttpHandler, IGxSilentTrn
   {
      public secfunctionalityrole_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalityrole_bc( IGxContext context )
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
         ReadRow033( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey033( ) ;
         standaloneModal( ) ;
         AddRow033( ) ;
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
               Z13SecFunctionalityId = A13SecFunctionalityId;
               Z16SecRoleId = A16SecRoleId;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               if ( AnyError == 0 )
               {
                  ZM033( 2) ;
                  ZM033( 3) ;
               }
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z20SecFunctionalityDescription = A20SecFunctionalityDescription;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z13SecFunctionalityId = A13SecFunctionalityId;
            Z16SecRoleId = A16SecRoleId;
            Z20SecFunctionalityDescription = A20SecFunctionalityDescription;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load033( )
      {
         /* Using cursor BC00036 */
         pr_default.execute(4, new Object[] {A13SecFunctionalityId, A16SecRoleId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound3 = 1;
            A20SecFunctionalityDescription = BC00036_A20SecFunctionalityDescription[0];
            ZM033( -1) ;
         }
         pr_default.close(4);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
      }

      protected void CheckExtendedTable033( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00034 */
         pr_default.execute(2, new Object[] {A13SecFunctionalityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Functionality", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECFUNCTIONALITYID");
            AnyError = 1;
         }
         A20SecFunctionalityDescription = BC00034_A20SecFunctionalityDescription[0];
         pr_default.close(2);
         /* Using cursor BC00035 */
         pr_default.execute(3, new Object[] {A16SecRoleId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Role", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECROLEID");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors033( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor BC00037 */
         pr_default.execute(5, new Object[] {A13SecFunctionalityId, A16SecRoleId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00033 */
         pr_default.execute(1, new Object[] {A13SecFunctionalityId, A16SecRoleId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 1) ;
            RcdFound3 = 1;
            A13SecFunctionalityId = BC00033_A13SecFunctionalityId[0];
            A16SecRoleId = BC00033_A16SecRoleId[0];
            Z13SecFunctionalityId = A13SecFunctionalityId;
            Z16SecRoleId = A16SecRoleId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode3;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
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
         CONFIRM_030( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00032 */
            pr_default.execute(0, new Object[] {A13SecFunctionalityId, A16SecRoleId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecFunctionalityRole"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecFunctionalityRole"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00038 */
                     pr_default.execute(6, new Object[] {A13SecFunctionalityId, A16SecRoleId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("SecFunctionalityRole");
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [SecFunctionalityRole] */
                     DeferredUpdate033( ) ;
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00039 */
                  pr_default.execute(7, new Object[] {A13SecFunctionalityId, A16SecRoleId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("SecFunctionalityRole");
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel033( ) ;
         Gx_mode = sMode3;
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000310 */
            pr_default.execute(8, new Object[] {A13SecFunctionalityId});
            A20SecFunctionalityDescription = BC000310_A20SecFunctionalityDescription[0];
            pr_default.close(8);
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
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

      public void ScanKeyStart033( )
      {
         /* Scan By routine */
         /* Using cursor BC000311 */
         pr_default.execute(9, new Object[] {A13SecFunctionalityId, A16SecRoleId});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound3 = 1;
            A20SecFunctionalityDescription = BC000311_A20SecFunctionalityDescription[0];
            A13SecFunctionalityId = BC000311_A13SecFunctionalityId[0];
            A16SecRoleId = BC000311_A16SecRoleId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound3 = 0;
         ScanKeyLoad033( ) ;
      }

      protected void ScanKeyLoad033( )
      {
         sMode3 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound3 = 1;
            A20SecFunctionalityDescription = BC000311_A20SecFunctionalityDescription[0];
            A13SecFunctionalityId = BC000311_A13SecFunctionalityId[0];
            A16SecRoleId = BC000311_A16SecRoleId[0];
         }
         Gx_mode = sMode3;
      }

      protected void ScanKeyEnd033( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void AddRow033( )
      {
         VarsToRow3( bcwwpbaseobjects_SecFunctionalityRole) ;
      }

      protected void ReadRow033( )
      {
         RowToVars3( bcwwpbaseobjects_SecFunctionalityRole, 1) ;
      }

      protected void InitializeNonKey033( )
      {
         A20SecFunctionalityDescription = "";
      }

      protected void InitAll033( )
      {
         A13SecFunctionalityId = 0;
         A16SecRoleId = 0;
         InitializeNonKey033( ) ;
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

      public void VarsToRow3( GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole obj3 )
      {
         obj3.gxTpr_Mode = Gx_mode;
         obj3.gxTpr_Secfunctionalitydescription = A20SecFunctionalityDescription;
         obj3.gxTpr_Secfunctionalityid = A13SecFunctionalityId;
         obj3.gxTpr_Secroleid = A16SecRoleId;
         obj3.gxTpr_Secfunctionalityid_Z = Z13SecFunctionalityId;
         obj3.gxTpr_Secfunctionalitydescription_Z = Z20SecFunctionalityDescription;
         obj3.gxTpr_Secroleid_Z = Z16SecRoleId;
         obj3.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow3( GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole obj3 )
      {
         obj3.gxTpr_Secfunctionalityid = A13SecFunctionalityId;
         obj3.gxTpr_Secroleid = A16SecRoleId;
         return  ;
      }

      public void RowToVars3( GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole obj3 ,
                              int forceLoad )
      {
         Gx_mode = obj3.gxTpr_Mode;
         A20SecFunctionalityDescription = obj3.gxTpr_Secfunctionalitydescription;
         A13SecFunctionalityId = obj3.gxTpr_Secfunctionalityid;
         A16SecRoleId = obj3.gxTpr_Secroleid;
         Z13SecFunctionalityId = obj3.gxTpr_Secfunctionalityid_Z;
         Z20SecFunctionalityDescription = obj3.gxTpr_Secfunctionalitydescription_Z;
         Z16SecRoleId = obj3.gxTpr_Secroleid_Z;
         Gx_mode = obj3.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A13SecFunctionalityId = (long)getParm(obj,0);
         A16SecRoleId = (short)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey033( ) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000310 */
            pr_default.execute(8, new Object[] {A13SecFunctionalityId});
            if ( (pr_default.getStatus(8) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Functionality", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECFUNCTIONALITYID");
               AnyError = 1;
            }
            A20SecFunctionalityDescription = BC000310_A20SecFunctionalityDescription[0];
            pr_default.close(8);
            /* Using cursor BC000312 */
            pr_default.execute(10, new Object[] {A16SecRoleId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Role", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECROLEID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z13SecFunctionalityId = A13SecFunctionalityId;
            Z16SecRoleId = A16SecRoleId;
         }
         ZM033( -1) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
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
         RowToVars3( bcwwpbaseobjects_SecFunctionalityRole, 0) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000310 */
            pr_default.execute(8, new Object[] {A13SecFunctionalityId});
            if ( (pr_default.getStatus(8) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Functionality", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECFUNCTIONALITYID");
               AnyError = 1;
            }
            A20SecFunctionalityDescription = BC000310_A20SecFunctionalityDescription[0];
            pr_default.close(8);
            /* Using cursor BC000312 */
            pr_default.execute(10, new Object[] {A16SecRoleId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Role", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECROLEID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z13SecFunctionalityId = A13SecFunctionalityId;
            Z16SecRoleId = A16SecRoleId;
         }
         ZM033( -1) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert033( ) ;
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( ( A13SecFunctionalityId != Z13SecFunctionalityId ) || ( A16SecRoleId != Z16SecRoleId ) )
               {
                  A13SecFunctionalityId = Z13SecFunctionalityId;
                  A16SecRoleId = Z16SecRoleId;
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
                  Update033( ) ;
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
                  if ( ( A13SecFunctionalityId != Z13SecFunctionalityId ) || ( A16SecRoleId != Z16SecRoleId ) )
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
                        Insert033( ) ;
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
                        Insert033( ) ;
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
         RowToVars3( bcwwpbaseobjects_SecFunctionalityRole, 1) ;
         SaveImpl( ) ;
         VarsToRow3( bcwwpbaseobjects_SecFunctionalityRole) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars3( bcwwpbaseobjects_SecFunctionalityRole, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
         AfterTrn( ) ;
         VarsToRow3( bcwwpbaseobjects_SecFunctionalityRole) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow3( bcwwpbaseobjects_SecFunctionalityRole) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole auxBC = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A13SecFunctionalityId, A16SecRoleId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_SecFunctionalityRole);
               auxBC.Save();
               bcwwpbaseobjects_SecFunctionalityRole.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars3( bcwwpbaseobjects_SecFunctionalityRole, 1) ;
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
         RowToVars3( bcwwpbaseobjects_SecFunctionalityRole, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
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
               VarsToRow3( bcwwpbaseobjects_SecFunctionalityRole) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow3( bcwwpbaseobjects_SecFunctionalityRole) ;
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
         RowToVars3( bcwwpbaseobjects_SecFunctionalityRole, 0) ;
         GetKey033( ) ;
         if ( RcdFound3 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A13SecFunctionalityId != Z13SecFunctionalityId ) || ( A16SecRoleId != Z16SecRoleId ) )
            {
               A13SecFunctionalityId = Z13SecFunctionalityId;
               A16SecRoleId = Z16SecRoleId;
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
            if ( ( A13SecFunctionalityId != Z13SecFunctionalityId ) || ( A16SecRoleId != Z16SecRoleId ) )
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
         pr_default.close(10);
         context.RollbackDataStores("wwpbaseobjects.secfunctionalityrole_bc",pr_default);
         VarsToRow3( bcwwpbaseobjects_SecFunctionalityRole) ;
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
         Gx_mode = bcwwpbaseobjects_SecFunctionalityRole.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_SecFunctionalityRole.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_SecFunctionalityRole )
         {
            bcwwpbaseobjects_SecFunctionalityRole = (GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_SecFunctionalityRole.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_SecFunctionalityRole.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow3( bcwwpbaseobjects_SecFunctionalityRole) ;
            }
            else
            {
               RowToVars3( bcwwpbaseobjects_SecFunctionalityRole, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_SecFunctionalityRole.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_SecFunctionalityRole.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars3( bcwwpbaseobjects_SecFunctionalityRole, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSecFunctionalityRole SecFunctionalityRole_BC
      {
         get {
            return bcwwpbaseobjects_SecFunctionalityRole ;
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
         pr_default.close(10);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z20SecFunctionalityDescription = "";
         A20SecFunctionalityDescription = "";
         BC00036_A20SecFunctionalityDescription = new string[] {""} ;
         BC00036_A13SecFunctionalityId = new long[1] ;
         BC00036_A16SecRoleId = new short[1] ;
         BC00034_A20SecFunctionalityDescription = new string[] {""} ;
         BC00035_A16SecRoleId = new short[1] ;
         BC00037_A13SecFunctionalityId = new long[1] ;
         BC00037_A16SecRoleId = new short[1] ;
         BC00033_A13SecFunctionalityId = new long[1] ;
         BC00033_A16SecRoleId = new short[1] ;
         sMode3 = "";
         BC00032_A13SecFunctionalityId = new long[1] ;
         BC00032_A16SecRoleId = new short[1] ;
         BC000310_A20SecFunctionalityDescription = new string[] {""} ;
         BC000311_A20SecFunctionalityDescription = new string[] {""} ;
         BC000311_A13SecFunctionalityId = new long[1] ;
         BC000311_A16SecRoleId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000312_A16SecRoleId = new short[1] ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalityrole_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalityrole_bc__default(),
            new Object[][] {
                new Object[] {
               BC00032_A13SecFunctionalityId, BC00032_A16SecRoleId
               }
               , new Object[] {
               BC00033_A13SecFunctionalityId, BC00033_A16SecRoleId
               }
               , new Object[] {
               BC00034_A20SecFunctionalityDescription
               }
               , new Object[] {
               BC00035_A16SecRoleId
               }
               , new Object[] {
               BC00036_A20SecFunctionalityDescription, BC00036_A13SecFunctionalityId, BC00036_A16SecRoleId
               }
               , new Object[] {
               BC00037_A13SecFunctionalityId, BC00037_A16SecRoleId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000310_A20SecFunctionalityDescription
               }
               , new Object[] {
               BC000311_A20SecFunctionalityDescription, BC000311_A13SecFunctionalityId, BC000311_A16SecRoleId
               }
               , new Object[] {
               BC000312_A16SecRoleId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z16SecRoleId ;
      private short A16SecRoleId ;
      private short RcdFound3 ;
      private int trnEnded ;
      private long Z13SecFunctionalityId ;
      private long A13SecFunctionalityId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode3 ;
      private string Z20SecFunctionalityDescription ;
      private string A20SecFunctionalityDescription ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00036_A20SecFunctionalityDescription ;
      private long[] BC00036_A13SecFunctionalityId ;
      private short[] BC00036_A16SecRoleId ;
      private string[] BC00034_A20SecFunctionalityDescription ;
      private short[] BC00035_A16SecRoleId ;
      private long[] BC00037_A13SecFunctionalityId ;
      private short[] BC00037_A16SecRoleId ;
      private long[] BC00033_A13SecFunctionalityId ;
      private short[] BC00033_A16SecRoleId ;
      private long[] BC00032_A13SecFunctionalityId ;
      private short[] BC00032_A16SecRoleId ;
      private string[] BC000310_A20SecFunctionalityDescription ;
      private string[] BC000311_A20SecFunctionalityDescription ;
      private long[] BC000311_A13SecFunctionalityId ;
      private short[] BC000311_A16SecRoleId ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole bcwwpbaseobjects_SecFunctionalityRole ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] BC000312_A16SecRoleId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class secfunctionalityrole_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class secfunctionalityrole_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00032;
        prmBC00032 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC00033;
        prmBC00033 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC00034;
        prmBC00034 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmBC00035;
        prmBC00035 = new Object[] {
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC00036;
        prmBC00036 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC00037;
        prmBC00037 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC00038;
        prmBC00038 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC00039;
        prmBC00039 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC000310;
        prmBC000310 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmBC000311;
        prmBC000311 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC000312;
        prmBC000312 = new Object[] {
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00032", "SELECT [SecFunctionalityId], [SecRoleId] FROM [SecFunctionalityRole] WITH (UPDLOCK) WHERE [SecFunctionalityId] = @SecFunctionalityId AND [SecRoleId] = @SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00032,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00033", "SELECT [SecFunctionalityId], [SecRoleId] FROM [SecFunctionalityRole] WHERE [SecFunctionalityId] = @SecFunctionalityId AND [SecRoleId] = @SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00033,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00034", "SELECT [SecFunctionalityDescription] FROM [SecFunctionality] WHERE [SecFunctionalityId] = @SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00034,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00035", "SELECT [SecRoleId] FROM [SecRole] WHERE [SecRoleId] = @SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00035,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00036", "SELECT T2.[SecFunctionalityDescription], TM1.[SecFunctionalityId], TM1.[SecRoleId] FROM ([SecFunctionalityRole] TM1 INNER JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = TM1.[SecFunctionalityId]) WHERE TM1.[SecFunctionalityId] = @SecFunctionalityId and TM1.[SecRoleId] = @SecRoleId ORDER BY TM1.[SecFunctionalityId], TM1.[SecRoleId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00036,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00037", "SELECT [SecFunctionalityId], [SecRoleId] FROM [SecFunctionalityRole] WHERE [SecFunctionalityId] = @SecFunctionalityId AND [SecRoleId] = @SecRoleId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00037,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00038", "INSERT INTO [SecFunctionalityRole]([SecFunctionalityId], [SecRoleId]) VALUES(@SecFunctionalityId, @SecRoleId)", GxErrorMask.GX_NOMASK,prmBC00038)
           ,new CursorDef("BC00039", "DELETE FROM [SecFunctionalityRole]  WHERE [SecFunctionalityId] = @SecFunctionalityId AND [SecRoleId] = @SecRoleId", GxErrorMask.GX_NOMASK,prmBC00039)
           ,new CursorDef("BC000310", "SELECT [SecFunctionalityDescription] FROM [SecFunctionality] WHERE [SecFunctionalityId] = @SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000310,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000311", "SELECT T2.[SecFunctionalityDescription], TM1.[SecFunctionalityId], TM1.[SecRoleId] FROM ([SecFunctionalityRole] TM1 INNER JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = TM1.[SecFunctionalityId]) WHERE TM1.[SecFunctionalityId] = @SecFunctionalityId and TM1.[SecRoleId] = @SecRoleId ORDER BY TM1.[SecFunctionalityId], TM1.[SecRoleId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000311,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000312", "SELECT [SecRoleId] FROM [SecRole] WHERE [SecRoleId] = @SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000312,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 10 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}
