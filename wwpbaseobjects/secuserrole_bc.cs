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
   public class secuserrole_bc : GXHttpHandler, IGxSilentTrn
   {
      public secuserrole_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserrole_bc( IGxContext context )
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
         ReadRow078( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey078( ) ;
         standaloneModal( ) ;
         AddRow078( ) ;
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
               Z18SecUserId = A18SecUserId;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls078( ) ;
            }
            else
            {
               CheckExtendedTable078( ) ;
               if ( AnyError == 0 )
               {
                  ZM078( 3) ;
                  ZM078( 4) ;
                  ZM078( 5) ;
               }
               CloseExtendedTableCursors078( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM078( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z551SecUserRoleEstado = A551SecUserRoleEstado;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z145usuariosId = A145usuariosId;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z25SecRoleName = A25SecRoleName;
            Z24SecRoleDescription = A24SecRoleDescription;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z222usuariosNombre = A222usuariosNombre;
         }
         if ( GX_JID == -2 )
         {
            Z551SecUserRoleEstado = A551SecUserRoleEstado;
            Z18SecUserId = A18SecUserId;
            Z16SecRoleId = A16SecRoleId;
            Z145usuariosId = A145usuariosId;
            Z222usuariosNombre = A222usuariosNombre;
            Z25SecRoleName = A25SecRoleName;
            Z24SecRoleDescription = A24SecRoleDescription;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load078( )
      {
         /* Using cursor BC00077 */
         pr_default.execute(5, new Object[] {A18SecUserId, A16SecRoleId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound8 = 1;
            A145usuariosId = BC00077_A145usuariosId[0];
            n145usuariosId = BC00077_n145usuariosId[0];
            A222usuariosNombre = BC00077_A222usuariosNombre[0];
            A25SecRoleName = BC00077_A25SecRoleName[0];
            A24SecRoleDescription = BC00077_A24SecRoleDescription[0];
            A551SecUserRoleEstado = BC00077_A551SecUserRoleEstado[0];
            ZM078( -2) ;
         }
         pr_default.close(5);
         OnLoadActions078( ) ;
      }

      protected void OnLoadActions078( )
      {
      }

      protected void CheckExtendedTable078( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00074 */
         pr_default.execute(2, new Object[] {A18SecUserId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECUSERID");
            AnyError = 1;
         }
         A145usuariosId = BC00074_A145usuariosId[0];
         n145usuariosId = BC00074_n145usuariosId[0];
         pr_default.close(2);
         /* Using cursor BC00076 */
         pr_default.execute(4, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "usuarios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOSID");
               AnyError = 1;
            }
         }
         A222usuariosNombre = BC00076_A222usuariosNombre[0];
         pr_default.close(4);
         /* Using cursor BC00075 */
         pr_default.execute(3, new Object[] {A16SecRoleId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Role", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECROLEID");
            AnyError = 1;
         }
         A25SecRoleName = BC00075_A25SecRoleName[0];
         A24SecRoleDescription = BC00075_A24SecRoleDescription[0];
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A551SecUserRoleEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A551SecUserRoleEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A551SecUserRoleEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A551SecUserRoleEstado, "BLO") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors078( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey078( )
      {
         /* Using cursor BC00078 */
         pr_default.execute(6, new Object[] {A18SecUserId, A16SecRoleId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00073 */
         pr_default.execute(1, new Object[] {A18SecUserId, A16SecRoleId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM078( 2) ;
            RcdFound8 = 1;
            A551SecUserRoleEstado = BC00073_A551SecUserRoleEstado[0];
            A18SecUserId = BC00073_A18SecUserId[0];
            A16SecRoleId = BC00073_A16SecRoleId[0];
            Z18SecUserId = A18SecUserId;
            Z16SecRoleId = A16SecRoleId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load078( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey078( ) ;
            }
            Gx_mode = sMode8;
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey078( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode8;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey078( ) ;
         if ( RcdFound8 == 0 )
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
         CONFIRM_070( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency078( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00072 */
            pr_default.execute(0, new Object[] {A18SecUserId, A16SecRoleId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUserRole"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z551SecUserRoleEstado, BC00072_A551SecUserRoleEstado[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecUserRole"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert078( )
      {
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable078( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM078( 0) ;
            CheckOptimisticConcurrency078( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm078( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert078( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00079 */
                     pr_default.execute(7, new Object[] {A551SecUserRoleEstado, A18SecUserId, A16SecRoleId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("SecUserRole");
                     if ( (pr_default.getStatus(7) == 1) )
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
               Load078( ) ;
            }
            EndLevel078( ) ;
         }
         CloseExtendedTableCursors078( ) ;
      }

      protected void Update078( )
      {
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable078( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency078( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm078( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate078( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000710 */
                     pr_default.execute(8, new Object[] {A551SecUserRoleEstado, A18SecUserId, A16SecRoleId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("SecUserRole");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUserRole"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate078( ) ;
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
            EndLevel078( ) ;
         }
         CloseExtendedTableCursors078( ) ;
      }

      protected void DeferredUpdate078( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency078( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls078( ) ;
            AfterConfirm078( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete078( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000711 */
                  pr_default.execute(9, new Object[] {A18SecUserId, A16SecRoleId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("SecUserRole");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel078( ) ;
         Gx_mode = sMode8;
      }

      protected void OnDeleteControls078( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000712 */
            pr_default.execute(10, new Object[] {A18SecUserId});
            A145usuariosId = BC000712_A145usuariosId[0];
            n145usuariosId = BC000712_n145usuariosId[0];
            pr_default.close(10);
            /* Using cursor BC000713 */
            pr_default.execute(11, new Object[] {n145usuariosId, A145usuariosId});
            A222usuariosNombre = BC000713_A222usuariosNombre[0];
            pr_default.close(11);
            /* Using cursor BC000714 */
            pr_default.execute(12, new Object[] {A16SecRoleId});
            A25SecRoleName = BC000714_A25SecRoleName[0];
            A24SecRoleDescription = BC000714_A24SecRoleDescription[0];
            pr_default.close(12);
         }
      }

      protected void EndLevel078( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete078( ) ;
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

      public void ScanKeyStart078( )
      {
         /* Using cursor BC000715 */
         pr_default.execute(13, new Object[] {A18SecUserId, A16SecRoleId});
         RcdFound8 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound8 = 1;
            A145usuariosId = BC000715_A145usuariosId[0];
            n145usuariosId = BC000715_n145usuariosId[0];
            A222usuariosNombre = BC000715_A222usuariosNombre[0];
            A25SecRoleName = BC000715_A25SecRoleName[0];
            A24SecRoleDescription = BC000715_A24SecRoleDescription[0];
            A551SecUserRoleEstado = BC000715_A551SecUserRoleEstado[0];
            A18SecUserId = BC000715_A18SecUserId[0];
            A16SecRoleId = BC000715_A16SecRoleId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext078( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound8 = 0;
         ScanKeyLoad078( ) ;
      }

      protected void ScanKeyLoad078( )
      {
         sMode8 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound8 = 1;
            A145usuariosId = BC000715_A145usuariosId[0];
            n145usuariosId = BC000715_n145usuariosId[0];
            A222usuariosNombre = BC000715_A222usuariosNombre[0];
            A25SecRoleName = BC000715_A25SecRoleName[0];
            A24SecRoleDescription = BC000715_A24SecRoleDescription[0];
            A551SecUserRoleEstado = BC000715_A551SecUserRoleEstado[0];
            A18SecUserId = BC000715_A18SecUserId[0];
            A16SecRoleId = BC000715_A16SecRoleId[0];
         }
         Gx_mode = sMode8;
      }

      protected void ScanKeyEnd078( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm078( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert078( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate078( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete078( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete078( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate078( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes078( )
      {
      }

      protected void send_integrity_lvl_hashes078( )
      {
      }

      protected void AddRow078( )
      {
         VarsToRow8( bcwwpbaseobjects_SecUserRole) ;
      }

      protected void ReadRow078( )
      {
         RowToVars8( bcwwpbaseobjects_SecUserRole, 1) ;
      }

      protected void InitializeNonKey078( )
      {
         A145usuariosId = "";
         n145usuariosId = false;
         A222usuariosNombre = "";
         A25SecRoleName = "";
         A24SecRoleDescription = "";
         A551SecUserRoleEstado = "";
         Z551SecUserRoleEstado = "";
      }

      protected void InitAll078( )
      {
         A18SecUserId = 0;
         A16SecRoleId = 0;
         InitializeNonKey078( ) ;
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

      public void VarsToRow8( GeneXus.Programs.wwpbaseobjects.SdtSecUserRole obj8 )
      {
         obj8.gxTpr_Mode = Gx_mode;
         obj8.gxTpr_Usuariosnombre = A222usuariosNombre;
         obj8.gxTpr_Secrolename = A25SecRoleName;
         obj8.gxTpr_Secroledescription = A24SecRoleDescription;
         obj8.gxTpr_Secuserroleestado = A551SecUserRoleEstado;
         obj8.gxTpr_Secuserid = A18SecUserId;
         obj8.gxTpr_Secroleid = A16SecRoleId;
         obj8.gxTpr_Secuserid_Z = Z18SecUserId;
         obj8.gxTpr_Secroleid_Z = Z16SecRoleId;
         obj8.gxTpr_Usuariosnombre_Z = Z222usuariosNombre;
         obj8.gxTpr_Secrolename_Z = Z25SecRoleName;
         obj8.gxTpr_Secroledescription_Z = Z24SecRoleDescription;
         obj8.gxTpr_Secuserroleestado_Z = Z551SecUserRoleEstado;
         obj8.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow8( GeneXus.Programs.wwpbaseobjects.SdtSecUserRole obj8 )
      {
         obj8.gxTpr_Secuserid = A18SecUserId;
         obj8.gxTpr_Secroleid = A16SecRoleId;
         return  ;
      }

      public void RowToVars8( GeneXus.Programs.wwpbaseobjects.SdtSecUserRole obj8 ,
                              int forceLoad )
      {
         Gx_mode = obj8.gxTpr_Mode;
         A222usuariosNombre = obj8.gxTpr_Usuariosnombre;
         A25SecRoleName = obj8.gxTpr_Secrolename;
         A24SecRoleDescription = obj8.gxTpr_Secroledescription;
         A551SecUserRoleEstado = obj8.gxTpr_Secuserroleestado;
         A18SecUserId = obj8.gxTpr_Secuserid;
         A16SecRoleId = obj8.gxTpr_Secroleid;
         Z18SecUserId = obj8.gxTpr_Secuserid_Z;
         Z16SecRoleId = obj8.gxTpr_Secroleid_Z;
         Z222usuariosNombre = obj8.gxTpr_Usuariosnombre_Z;
         Z25SecRoleName = obj8.gxTpr_Secrolename_Z;
         Z24SecRoleDescription = obj8.gxTpr_Secroledescription_Z;
         Z551SecUserRoleEstado = obj8.gxTpr_Secuserroleestado_Z;
         Gx_mode = obj8.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A18SecUserId = (long)getParm(obj,0);
         A16SecRoleId = (short)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey078( ) ;
         ScanKeyStart078( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000712 */
            pr_default.execute(10, new Object[] {A18SecUserId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
            }
            A145usuariosId = BC000712_A145usuariosId[0];
            n145usuariosId = BC000712_n145usuariosId[0];
            pr_default.close(10);
            /* Using cursor BC000713 */
            pr_default.execute(11, new Object[] {n145usuariosId, A145usuariosId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ) )
               {
                  GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "usuarios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOSID");
                  AnyError = 1;
               }
            }
            A222usuariosNombre = BC000713_A222usuariosNombre[0];
            pr_default.close(11);
            /* Using cursor BC000714 */
            pr_default.execute(12, new Object[] {A16SecRoleId});
            if ( (pr_default.getStatus(12) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Role", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECROLEID");
               AnyError = 1;
            }
            A25SecRoleName = BC000714_A25SecRoleName[0];
            A24SecRoleDescription = BC000714_A24SecRoleDescription[0];
            pr_default.close(12);
         }
         else
         {
            Gx_mode = "UPD";
            Z18SecUserId = A18SecUserId;
            Z16SecRoleId = A16SecRoleId;
         }
         ZM078( -2) ;
         OnLoadActions078( ) ;
         AddRow078( ) ;
         ScanKeyEnd078( ) ;
         if ( RcdFound8 == 0 )
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
         RowToVars8( bcwwpbaseobjects_SecUserRole, 0) ;
         ScanKeyStart078( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000712 */
            pr_default.execute(10, new Object[] {A18SecUserId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
            }
            A145usuariosId = BC000712_A145usuariosId[0];
            n145usuariosId = BC000712_n145usuariosId[0];
            pr_default.close(10);
            /* Using cursor BC000713 */
            pr_default.execute(11, new Object[] {n145usuariosId, A145usuariosId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ) )
               {
                  GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "usuarios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOSID");
                  AnyError = 1;
               }
            }
            A222usuariosNombre = BC000713_A222usuariosNombre[0];
            pr_default.close(11);
            /* Using cursor BC000714 */
            pr_default.execute(12, new Object[] {A16SecRoleId});
            if ( (pr_default.getStatus(12) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Role", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SECROLEID");
               AnyError = 1;
            }
            A25SecRoleName = BC000714_A25SecRoleName[0];
            A24SecRoleDescription = BC000714_A24SecRoleDescription[0];
            pr_default.close(12);
         }
         else
         {
            Gx_mode = "UPD";
            Z18SecUserId = A18SecUserId;
            Z16SecRoleId = A16SecRoleId;
         }
         ZM078( -2) ;
         OnLoadActions078( ) ;
         AddRow078( ) ;
         ScanKeyEnd078( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey078( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert078( ) ;
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( ( A18SecUserId != Z18SecUserId ) || ( A16SecRoleId != Z16SecRoleId ) )
               {
                  A18SecUserId = Z18SecUserId;
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
                  Update078( ) ;
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
                  if ( ( A18SecUserId != Z18SecUserId ) || ( A16SecRoleId != Z16SecRoleId ) )
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
                        Insert078( ) ;
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
                        Insert078( ) ;
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
         RowToVars8( bcwwpbaseobjects_SecUserRole, 1) ;
         SaveImpl( ) ;
         VarsToRow8( bcwwpbaseobjects_SecUserRole) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars8( bcwwpbaseobjects_SecUserRole, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert078( ) ;
         AfterTrn( ) ;
         VarsToRow8( bcwwpbaseobjects_SecUserRole) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow8( bcwwpbaseobjects_SecUserRole) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtSecUserRole auxBC = new GeneXus.Programs.wwpbaseobjects.SdtSecUserRole(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A18SecUserId, A16SecRoleId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_SecUserRole);
               auxBC.Save();
               bcwwpbaseobjects_SecUserRole.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars8( bcwwpbaseobjects_SecUserRole, 1) ;
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
         RowToVars8( bcwwpbaseobjects_SecUserRole, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert078( ) ;
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
               VarsToRow8( bcwwpbaseobjects_SecUserRole) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow8( bcwwpbaseobjects_SecUserRole) ;
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
         RowToVars8( bcwwpbaseobjects_SecUserRole, 0) ;
         GetKey078( ) ;
         if ( RcdFound8 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A18SecUserId != Z18SecUserId ) || ( A16SecRoleId != Z16SecRoleId ) )
            {
               A18SecUserId = Z18SecUserId;
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
            if ( ( A18SecUserId != Z18SecUserId ) || ( A16SecRoleId != Z16SecRoleId ) )
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
         pr_default.close(12);
         pr_default.close(11);
         context.RollbackDataStores("wwpbaseobjects.secuserrole_bc",pr_default);
         VarsToRow8( bcwwpbaseobjects_SecUserRole) ;
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
         Gx_mode = bcwwpbaseobjects_SecUserRole.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_SecUserRole.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_SecUserRole )
         {
            bcwwpbaseobjects_SecUserRole = (GeneXus.Programs.wwpbaseobjects.SdtSecUserRole)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_SecUserRole.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_SecUserRole.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow8( bcwwpbaseobjects_SecUserRole) ;
            }
            else
            {
               RowToVars8( bcwwpbaseobjects_SecUserRole, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_SecUserRole.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_SecUserRole.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars8( bcwwpbaseobjects_SecUserRole, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSecUserRole SecUserRole_BC
      {
         get {
            return bcwwpbaseobjects_SecUserRole ;
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
         pr_default.close(12);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z551SecUserRoleEstado = "";
         A551SecUserRoleEstado = "";
         Z145usuariosId = "";
         A145usuariosId = "";
         Z25SecRoleName = "";
         A25SecRoleName = "";
         Z24SecRoleDescription = "";
         A24SecRoleDescription = "";
         Z222usuariosNombre = "";
         A222usuariosNombre = "";
         BC00077_A145usuariosId = new string[] {""} ;
         BC00077_n145usuariosId = new bool[] {false} ;
         BC00077_A222usuariosNombre = new string[] {""} ;
         BC00077_A25SecRoleName = new string[] {""} ;
         BC00077_A24SecRoleDescription = new string[] {""} ;
         BC00077_A551SecUserRoleEstado = new string[] {""} ;
         BC00077_A18SecUserId = new long[1] ;
         BC00077_A16SecRoleId = new short[1] ;
         BC00074_A145usuariosId = new string[] {""} ;
         BC00074_n145usuariosId = new bool[] {false} ;
         BC00076_A222usuariosNombre = new string[] {""} ;
         BC00075_A25SecRoleName = new string[] {""} ;
         BC00075_A24SecRoleDescription = new string[] {""} ;
         BC00078_A18SecUserId = new long[1] ;
         BC00078_A16SecRoleId = new short[1] ;
         BC00073_A551SecUserRoleEstado = new string[] {""} ;
         BC00073_A18SecUserId = new long[1] ;
         BC00073_A16SecRoleId = new short[1] ;
         sMode8 = "";
         BC00072_A551SecUserRoleEstado = new string[] {""} ;
         BC00072_A18SecUserId = new long[1] ;
         BC00072_A16SecRoleId = new short[1] ;
         BC000712_A145usuariosId = new string[] {""} ;
         BC000712_n145usuariosId = new bool[] {false} ;
         BC000713_A222usuariosNombre = new string[] {""} ;
         BC000714_A25SecRoleName = new string[] {""} ;
         BC000714_A24SecRoleDescription = new string[] {""} ;
         BC000715_A145usuariosId = new string[] {""} ;
         BC000715_n145usuariosId = new bool[] {false} ;
         BC000715_A222usuariosNombre = new string[] {""} ;
         BC000715_A25SecRoleName = new string[] {""} ;
         BC000715_A24SecRoleDescription = new string[] {""} ;
         BC000715_A551SecUserRoleEstado = new string[] {""} ;
         BC000715_A18SecUserId = new long[1] ;
         BC000715_A16SecRoleId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secuserrole_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secuserrole_bc__default(),
            new Object[][] {
                new Object[] {
               BC00072_A551SecUserRoleEstado, BC00072_A18SecUserId, BC00072_A16SecRoleId
               }
               , new Object[] {
               BC00073_A551SecUserRoleEstado, BC00073_A18SecUserId, BC00073_A16SecRoleId
               }
               , new Object[] {
               BC00074_A145usuariosId, BC00074_n145usuariosId
               }
               , new Object[] {
               BC00075_A25SecRoleName, BC00075_A24SecRoleDescription
               }
               , new Object[] {
               BC00076_A222usuariosNombre
               }
               , new Object[] {
               BC00077_A145usuariosId, BC00077_n145usuariosId, BC00077_A222usuariosNombre, BC00077_A25SecRoleName, BC00077_A24SecRoleDescription, BC00077_A551SecUserRoleEstado, BC00077_A18SecUserId, BC00077_A16SecRoleId
               }
               , new Object[] {
               BC00078_A18SecUserId, BC00078_A16SecRoleId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000712_A145usuariosId, BC000712_n145usuariosId
               }
               , new Object[] {
               BC000713_A222usuariosNombre
               }
               , new Object[] {
               BC000714_A25SecRoleName, BC000714_A24SecRoleDescription
               }
               , new Object[] {
               BC000715_A145usuariosId, BC000715_n145usuariosId, BC000715_A222usuariosNombre, BC000715_A25SecRoleName, BC000715_A24SecRoleDescription, BC000715_A551SecUserRoleEstado, BC000715_A18SecUserId, BC000715_A16SecRoleId
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
      private short RcdFound8 ;
      private int trnEnded ;
      private long Z18SecUserId ;
      private long A18SecUserId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z551SecUserRoleEstado ;
      private string A551SecUserRoleEstado ;
      private string Z145usuariosId ;
      private string A145usuariosId ;
      private string Z222usuariosNombre ;
      private string A222usuariosNombre ;
      private string sMode8 ;
      private bool n145usuariosId ;
      private string Z25SecRoleName ;
      private string A25SecRoleName ;
      private string Z24SecRoleDescription ;
      private string A24SecRoleDescription ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00077_A145usuariosId ;
      private bool[] BC00077_n145usuariosId ;
      private string[] BC00077_A222usuariosNombre ;
      private string[] BC00077_A25SecRoleName ;
      private string[] BC00077_A24SecRoleDescription ;
      private string[] BC00077_A551SecUserRoleEstado ;
      private long[] BC00077_A18SecUserId ;
      private short[] BC00077_A16SecRoleId ;
      private string[] BC00074_A145usuariosId ;
      private bool[] BC00074_n145usuariosId ;
      private string[] BC00076_A222usuariosNombre ;
      private string[] BC00075_A25SecRoleName ;
      private string[] BC00075_A24SecRoleDescription ;
      private long[] BC00078_A18SecUserId ;
      private short[] BC00078_A16SecRoleId ;
      private string[] BC00073_A551SecUserRoleEstado ;
      private long[] BC00073_A18SecUserId ;
      private short[] BC00073_A16SecRoleId ;
      private string[] BC00072_A551SecUserRoleEstado ;
      private long[] BC00072_A18SecUserId ;
      private short[] BC00072_A16SecRoleId ;
      private string[] BC000712_A145usuariosId ;
      private bool[] BC000712_n145usuariosId ;
      private string[] BC000713_A222usuariosNombre ;
      private string[] BC000714_A25SecRoleName ;
      private string[] BC000714_A24SecRoleDescription ;
      private string[] BC000715_A145usuariosId ;
      private bool[] BC000715_n145usuariosId ;
      private string[] BC000715_A222usuariosNombre ;
      private string[] BC000715_A25SecRoleName ;
      private string[] BC000715_A24SecRoleDescription ;
      private string[] BC000715_A551SecUserRoleEstado ;
      private long[] BC000715_A18SecUserId ;
      private short[] BC000715_A16SecRoleId ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecUserRole bcwwpbaseobjects_SecUserRole ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class secuserrole_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class secuserrole_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00072;
        prmBC00072 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC00073;
        prmBC00073 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC00074;
        prmBC00074 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmBC00075;
        prmBC00075 = new Object[] {
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC00076;
        prmBC00076 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmBC00077;
        prmBC00077 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC00078;
        prmBC00078 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC00079;
        prmBC00079 = new Object[] {
        new ParDef("@SecUserRoleEstado",GXType.NChar,3,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC000710;
        prmBC000710 = new Object[] {
        new ParDef("@SecUserRoleEstado",GXType.NChar,3,0) ,
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC000711;
        prmBC000711 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC000712;
        prmBC000712 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmBC000713;
        prmBC000713 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmBC000714;
        prmBC000714 = new Object[] {
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmBC000715;
        prmBC000715 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00072", "SELECT [SecUserRoleEstado], [SecUserId], [SecRoleId] FROM [SecUserRole] WITH (UPDLOCK) WHERE [SecUserId] = @SecUserId AND [SecRoleId] = @SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00072,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00073", "SELECT [SecUserRoleEstado], [SecUserId], [SecRoleId] FROM [SecUserRole] WHERE [SecUserId] = @SecUserId AND [SecRoleId] = @SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00073,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00074", "SELECT [usuariosId] FROM [SecUser] WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00074,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00075", "SELECT [SecRoleName], [SecRoleDescription] FROM [SecRole] WHERE [SecRoleId] = @SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00075,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00076", "SELECT [usuariosNombre] FROM [usuarios] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00076,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00077", "SELECT T2.[usuariosId], T3.[usuariosNombre], T4.[SecRoleName], T4.[SecRoleDescription], TM1.[SecUserRoleEstado], TM1.[SecUserId], TM1.[SecRoleId] FROM ((([SecUserRole] TM1 INNER JOIN [SecUser] T2 ON T2.[SecUserId] = TM1.[SecUserId]) LEFT JOIN [usuarios] T3 ON T3.[usuariosId] = T2.[usuariosId]) INNER JOIN [SecRole] T4 ON T4.[SecRoleId] = TM1.[SecRoleId]) WHERE TM1.[SecUserId] = @SecUserId and TM1.[SecRoleId] = @SecRoleId ORDER BY TM1.[SecUserId], TM1.[SecRoleId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00077,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00078", "SELECT [SecUserId], [SecRoleId] FROM [SecUserRole] WHERE [SecUserId] = @SecUserId AND [SecRoleId] = @SecRoleId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00078,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00079", "INSERT INTO [SecUserRole]([SecUserRoleEstado], [SecUserId], [SecRoleId]) VALUES(@SecUserRoleEstado, @SecUserId, @SecRoleId)", GxErrorMask.GX_NOMASK,prmBC00079)
           ,new CursorDef("BC000710", "UPDATE [SecUserRole] SET [SecUserRoleEstado]=@SecUserRoleEstado  WHERE [SecUserId] = @SecUserId AND [SecRoleId] = @SecRoleId", GxErrorMask.GX_NOMASK,prmBC000710)
           ,new CursorDef("BC000711", "DELETE FROM [SecUserRole]  WHERE [SecUserId] = @SecUserId AND [SecRoleId] = @SecRoleId", GxErrorMask.GX_NOMASK,prmBC000711)
           ,new CursorDef("BC000712", "SELECT [usuariosId] FROM [SecUser] WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000712,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000713", "SELECT [usuariosNombre] FROM [usuarios] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000713,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000714", "SELECT [SecRoleName], [SecRoleDescription] FROM [SecRole] WHERE [SecRoleId] = @SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000714,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000715", "SELECT T2.[usuariosId], T3.[usuariosNombre], T4.[SecRoleName], T4.[SecRoleDescription], TM1.[SecUserRoleEstado], TM1.[SecUserId], TM1.[SecRoleId] FROM ((([SecUserRole] TM1 INNER JOIN [SecUser] T2 ON T2.[SecUserId] = TM1.[SecUserId]) LEFT JOIN [usuarios] T3 ON T3.[usuariosId] = T2.[usuariosId]) INNER JOIN [SecRole] T4 ON T4.[SecRoleId] = TM1.[SecRoleId]) WHERE TM1.[SecUserId] = @SecUserId and TM1.[SecRoleId] = @SecRoleId ORDER BY TM1.[SecUserId], TM1.[SecRoleId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000715,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 80);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 3);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 80);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 3);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              return;
     }
  }

}

}
