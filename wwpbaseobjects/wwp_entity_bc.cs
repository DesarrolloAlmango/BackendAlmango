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
   public class wwp_entity_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_entity_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_entity_bc( IGxContext context )
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
         ReadRow089( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey089( ) ;
         standaloneModal( ) ;
         AddRow089( ) ;
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
               Z29WWPEntityId = A29WWPEntityId;
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

      protected void CONFIRM_080( )
      {
         BeforeValidate089( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls089( ) ;
            }
            else
            {
               CheckExtendedTable089( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors089( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM089( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z30WWPEntityName = A30WWPEntityName;
         }
         if ( GX_JID == -1 )
         {
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

      protected void Load089( )
      {
         /* Using cursor BC00084 */
         pr_default.execute(2, new Object[] {A29WWPEntityId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound9 = 1;
            A30WWPEntityName = BC00084_A30WWPEntityName[0];
            ZM089( -1) ;
         }
         pr_default.close(2);
         OnLoadActions089( ) ;
      }

      protected void OnLoadActions089( )
      {
      }

      protected void CheckExtendedTable089( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors089( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey089( )
      {
         /* Using cursor BC00085 */
         pr_default.execute(3, new Object[] {A29WWPEntityId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00083 */
         pr_default.execute(1, new Object[] {A29WWPEntityId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM089( 1) ;
            RcdFound9 = 1;
            A29WWPEntityId = BC00083_A29WWPEntityId[0];
            A30WWPEntityName = BC00083_A30WWPEntityName[0];
            Z29WWPEntityId = A29WWPEntityId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load089( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey089( ) ;
            }
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey089( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode9;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey089( ) ;
         if ( RcdFound9 == 0 )
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
         CONFIRM_080( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency089( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00082 */
            pr_default.execute(0, new Object[] {A29WWPEntityId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Entity"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z30WWPEntityName, BC00082_A30WWPEntityName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Entity"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert089( )
      {
         BeforeValidate089( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable089( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM089( 0) ;
            CheckOptimisticConcurrency089( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm089( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert089( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00086 */
                     pr_default.execute(4, new Object[] {A30WWPEntityName});
                     A29WWPEntityId = BC00086_A29WWPEntityId[0];
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Entity");
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
               Load089( ) ;
            }
            EndLevel089( ) ;
         }
         CloseExtendedTableCursors089( ) ;
      }

      protected void Update089( )
      {
         BeforeValidate089( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable089( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency089( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm089( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate089( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00087 */
                     pr_default.execute(5, new Object[] {A30WWPEntityName, A29WWPEntityId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Entity");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Entity"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate089( ) ;
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
            EndLevel089( ) ;
         }
         CloseExtendedTableCursors089( ) ;
      }

      protected void DeferredUpdate089( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate089( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency089( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls089( ) ;
            AfterConfirm089( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete089( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00088 */
                  pr_default.execute(6, new Object[] {A29WWPEntityId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Entity");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel089( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls089( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC00089 */
            pr_default.execute(7, new Object[] {A29WWPEntityId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_DiscussionMessage", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
            /* Using cursor BC000810 */
            pr_default.execute(8, new Object[] {A29WWPEntityId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_NotificationDefinition", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel089( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete089( ) ;
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

      public void ScanKeyStart089( )
      {
         /* Using cursor BC000811 */
         pr_default.execute(9, new Object[] {A29WWPEntityId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound9 = 1;
            A29WWPEntityId = BC000811_A29WWPEntityId[0];
            A30WWPEntityName = BC000811_A30WWPEntityName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext089( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound9 = 0;
         ScanKeyLoad089( ) ;
      }

      protected void ScanKeyLoad089( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound9 = 1;
            A29WWPEntityId = BC000811_A29WWPEntityId[0];
            A30WWPEntityName = BC000811_A30WWPEntityName[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd089( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm089( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert089( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate089( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete089( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete089( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate089( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes089( )
      {
      }

      protected void send_integrity_lvl_hashes089( )
      {
      }

      protected void AddRow089( )
      {
         VarsToRow9( bcwwpbaseobjects_WWP_Entity) ;
      }

      protected void ReadRow089( )
      {
         RowToVars9( bcwwpbaseobjects_WWP_Entity, 1) ;
      }

      protected void InitializeNonKey089( )
      {
         A30WWPEntityName = "";
         Z30WWPEntityName = "";
      }

      protected void InitAll089( )
      {
         A29WWPEntityId = 0;
         InitializeNonKey089( ) ;
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

      public void VarsToRow9( GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Wwpentityname = A30WWPEntityName;
         obj9.gxTpr_Wwpentityid = A29WWPEntityId;
         obj9.gxTpr_Wwpentityid_Z = Z29WWPEntityId;
         obj9.gxTpr_Wwpentityname_Z = Z30WWPEntityName;
         obj9.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow9( GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity obj9 )
      {
         obj9.gxTpr_Wwpentityid = A29WWPEntityId;
         return  ;
      }

      public void RowToVars9( GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A30WWPEntityName = obj9.gxTpr_Wwpentityname;
         A29WWPEntityId = obj9.gxTpr_Wwpentityid;
         Z29WWPEntityId = obj9.gxTpr_Wwpentityid_Z;
         Z30WWPEntityName = obj9.gxTpr_Wwpentityname_Z;
         Gx_mode = obj9.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A29WWPEntityId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey089( ) ;
         ScanKeyStart089( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z29WWPEntityId = A29WWPEntityId;
         }
         ZM089( -1) ;
         OnLoadActions089( ) ;
         AddRow089( ) ;
         ScanKeyEnd089( ) ;
         if ( RcdFound9 == 0 )
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
         RowToVars9( bcwwpbaseobjects_WWP_Entity, 0) ;
         ScanKeyStart089( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z29WWPEntityId = A29WWPEntityId;
         }
         ZM089( -1) ;
         OnLoadActions089( ) ;
         AddRow089( ) ;
         ScanKeyEnd089( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey089( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert089( ) ;
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A29WWPEntityId != Z29WWPEntityId )
               {
                  A29WWPEntityId = Z29WWPEntityId;
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
                  Update089( ) ;
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
                  if ( A29WWPEntityId != Z29WWPEntityId )
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
                        Insert089( ) ;
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
                        Insert089( ) ;
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
         RowToVars9( bcwwpbaseobjects_WWP_Entity, 1) ;
         SaveImpl( ) ;
         VarsToRow9( bcwwpbaseobjects_WWP_Entity) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcwwpbaseobjects_WWP_Entity, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert089( ) ;
         AfterTrn( ) ;
         VarsToRow9( bcwwpbaseobjects_WWP_Entity) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow9( bcwwpbaseobjects_WWP_Entity) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity auxBC = new GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A29WWPEntityId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_WWP_Entity);
               auxBC.Save();
               bcwwpbaseobjects_WWP_Entity.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars9( bcwwpbaseobjects_WWP_Entity, 1) ;
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
         RowToVars9( bcwwpbaseobjects_WWP_Entity, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert089( ) ;
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
               VarsToRow9( bcwwpbaseobjects_WWP_Entity) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow9( bcwwpbaseobjects_WWP_Entity) ;
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
         RowToVars9( bcwwpbaseobjects_WWP_Entity, 0) ;
         GetKey089( ) ;
         if ( RcdFound9 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A29WWPEntityId != Z29WWPEntityId )
            {
               A29WWPEntityId = Z29WWPEntityId;
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
            if ( A29WWPEntityId != Z29WWPEntityId )
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
         context.RollbackDataStores("wwpbaseobjects.wwp_entity_bc",pr_default);
         VarsToRow9( bcwwpbaseobjects_WWP_Entity) ;
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
         Gx_mode = bcwwpbaseobjects_WWP_Entity.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_WWP_Entity.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_WWP_Entity )
         {
            bcwwpbaseobjects_WWP_Entity = (GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_WWP_Entity.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_WWP_Entity.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow9( bcwwpbaseobjects_WWP_Entity) ;
            }
            else
            {
               RowToVars9( bcwwpbaseobjects_WWP_Entity, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_WWP_Entity.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_WWP_Entity.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars9( bcwwpbaseobjects_WWP_Entity, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_Entity WWP_Entity_BC
      {
         get {
            return bcwwpbaseobjects_WWP_Entity ;
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
         Z30WWPEntityName = "";
         A30WWPEntityName = "";
         BC00084_A29WWPEntityId = new long[1] ;
         BC00084_A30WWPEntityName = new string[] {""} ;
         BC00085_A29WWPEntityId = new long[1] ;
         BC00083_A29WWPEntityId = new long[1] ;
         BC00083_A30WWPEntityName = new string[] {""} ;
         sMode9 = "";
         BC00082_A29WWPEntityId = new long[1] ;
         BC00082_A30WWPEntityName = new string[] {""} ;
         BC00086_A29WWPEntityId = new long[1] ;
         BC00089_A540WWPDiscussionMessageId = new long[1] ;
         BC000810_A32WWPNotificationDefinitionId = new long[1] ;
         BC000811_A29WWPEntityId = new long[1] ;
         BC000811_A30WWPEntityName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_entity_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_entity_bc__default(),
            new Object[][] {
                new Object[] {
               BC00082_A29WWPEntityId, BC00082_A30WWPEntityName
               }
               , new Object[] {
               BC00083_A29WWPEntityId, BC00083_A30WWPEntityName
               }
               , new Object[] {
               BC00084_A29WWPEntityId, BC00084_A30WWPEntityName
               }
               , new Object[] {
               BC00085_A29WWPEntityId
               }
               , new Object[] {
               BC00086_A29WWPEntityId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00089_A540WWPDiscussionMessageId
               }
               , new Object[] {
               BC000810_A32WWPNotificationDefinitionId
               }
               , new Object[] {
               BC000811_A29WWPEntityId, BC000811_A30WWPEntityName
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound9 ;
      private int trnEnded ;
      private long Z29WWPEntityId ;
      private long A29WWPEntityId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode9 ;
      private string Z30WWPEntityName ;
      private string A30WWPEntityName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00084_A29WWPEntityId ;
      private string[] BC00084_A30WWPEntityName ;
      private long[] BC00085_A29WWPEntityId ;
      private long[] BC00083_A29WWPEntityId ;
      private string[] BC00083_A30WWPEntityName ;
      private long[] BC00082_A29WWPEntityId ;
      private string[] BC00082_A30WWPEntityName ;
      private long[] BC00086_A29WWPEntityId ;
      private long[] BC00089_A540WWPDiscussionMessageId ;
      private long[] BC000810_A32WWPNotificationDefinitionId ;
      private long[] BC000811_A29WWPEntityId ;
      private string[] BC000811_A30WWPEntityName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity bcwwpbaseobjects_WWP_Entity ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_entity_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_entity_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00082;
        prmBC00082 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmBC00083;
        prmBC00083 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmBC00084;
        prmBC00084 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmBC00085;
        prmBC00085 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmBC00086;
        prmBC00086 = new Object[] {
        new ParDef("@WWPEntityName",GXType.NVarChar,100,0)
        };
        Object[] prmBC00087;
        prmBC00087 = new Object[] {
        new ParDef("@WWPEntityName",GXType.NVarChar,100,0) ,
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmBC00088;
        prmBC00088 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmBC00089;
        prmBC00089 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmBC000810;
        prmBC000810 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        Object[] prmBC000811;
        prmBC000811 = new Object[] {
        new ParDef("@WWPEntityId",GXType.Decimal,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00082", "SELECT [WWPEntityId], [WWPEntityName] FROM [WWP_Entity] WITH (UPDLOCK) WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00082,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00083", "SELECT [WWPEntityId], [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00083,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00084", "SELECT TM1.[WWPEntityId], TM1.[WWPEntityName] FROM [WWP_Entity] TM1 WHERE TM1.[WWPEntityId] = @WWPEntityId ORDER BY TM1.[WWPEntityId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00084,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00085", "SELECT [WWPEntityId] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00085,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00086", "INSERT INTO [WWP_Entity]([WWPEntityName]) VALUES(@WWPEntityName); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00086,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC00087", "UPDATE [WWP_Entity] SET [WWPEntityName]=@WWPEntityName  WHERE [WWPEntityId] = @WWPEntityId", GxErrorMask.GX_NOMASK,prmBC00087)
           ,new CursorDef("BC00088", "DELETE FROM [WWP_Entity]  WHERE [WWPEntityId] = @WWPEntityId", GxErrorMask.GX_NOMASK,prmBC00088)
           ,new CursorDef("BC00089", "SELECT TOP 1 [WWPDiscussionMessageId] FROM [WWP_DiscussionMessage] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00089,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000810", "SELECT TOP 1 [WWPNotificationDefinitionId] FROM [WWP_NotificationDefinition] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000810,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000811", "SELECT TM1.[WWPEntityId], TM1.[WWPEntityName] FROM [WWP_Entity] TM1 WHERE TM1.[WWPEntityId] = @WWPEntityId ORDER BY TM1.[WWPEntityId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000811,100, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
     }
  }

}

}
