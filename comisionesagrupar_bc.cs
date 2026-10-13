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
   public class comisionesagrupar_bc : GXHttpHandler, IGxSilentTrn
   {
      public comisionesagrupar_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comisionesagrupar_bc( IGxContext context )
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
         ReadRow1X74( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1X74( ) ;
         standaloneModal( ) ;
         AddRow1X74( ) ;
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
            /* Execute user event: After Trn */
            E111X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z503ComisionesID = A503ComisionesID;
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

      protected void CONFIRM_1X0( )
      {
         BeforeValidate1X74( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1X74( ) ;
            }
            else
            {
               CheckExtendedTable1X74( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1X74( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode74 = Gx_mode;
            CONFIRM_1X77( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode74;
            }
            /* Restore parent mode. */
            Gx_mode = sMode74;
         }
      }

      protected void CONFIRM_1X77( )
      {
         s512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
         n512ComisionesInventarioEnum = false;
         nGXsfl_77_idx = 0;
         while ( nGXsfl_77_idx < bcComisionesAgrupar.gxTpr_Rubros.Count )
         {
            ReadRow1X77( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound77 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_77 != 0 ) )
            {
               GetKey1X77( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound77 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate1X77( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1X77( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM1X77( 7) ;
                           ZM1X77( 8) ;
                           ZM1X77( 9) ;
                        }
                        CloseExtendedTableCursors1X77( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        O512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
                        n512ComisionesInventarioEnum = false;
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
                  if ( RcdFound77 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey1X77( ) ;
                        Load1X77( ) ;
                        BeforeValidate1X77( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1X77( ) ;
                           O512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
                           n512ComisionesInventarioEnum = false;
                        }
                     }
                     else
                     {
                        if ( nIsMod_77 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate1X77( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1X77( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM1X77( 7) ;
                                 ZM1X77( 8) ;
                                 ZM1X77( 9) ;
                              }
                              CloseExtendedTableCursors1X77( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              O512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
                              n512ComisionesInventarioEnum = false;
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
               VarsToRow77( ((SdtComisionesAgrupar_Rubros)bcComisionesAgrupar.gxTpr_Rubros.Item(nGXsfl_77_idx))) ;
            }
         }
         O512ComisionesInventarioEnum = s512ComisionesInventarioEnum;
         n512ComisionesInventarioEnum = false;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E121X2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisionesAgrupar_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisionesAgrupar_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisionesAgrupar_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV25Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111X2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1X74( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z505ComisionesTipo = A505ComisionesTipo;
            Z504ComisionesNombre = A504ComisionesNombre;
            Z506ComisionesDefault = A506ComisionesDefault;
            Z512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
         }
         if ( GX_JID == -5 )
         {
            Z503ComisionesID = A503ComisionesID;
            Z505ComisionesTipo = A505ComisionesTipo;
            Z504ComisionesNombre = A504ComisionesNombre;
            Z506ComisionesDefault = A506ComisionesDefault;
            Z512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1X74( )
      {
         /* Using cursor BC001X9 */
         pr_default.execute(7, new Object[] {A503ComisionesID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound74 = 1;
            A505ComisionesTipo = BC001X9_A505ComisionesTipo[0];
            A504ComisionesNombre = BC001X9_A504ComisionesNombre[0];
            A506ComisionesDefault = BC001X9_A506ComisionesDefault[0];
            n506ComisionesDefault = BC001X9_n506ComisionesDefault[0];
            A512ComisionesInventarioEnum = BC001X9_A512ComisionesInventarioEnum[0];
            n512ComisionesInventarioEnum = BC001X9_n512ComisionesInventarioEnum[0];
            ZM1X74( -5) ;
         }
         pr_default.close(7);
         OnLoadActions1X74( ) ;
      }

      protected void OnLoadActions1X74( )
      {
         AV25Pgmname = "ComisionesAgrupar_BC";
      }

      protected void CheckExtendedTable1X74( )
      {
         standaloneModal( ) ;
         AV25Pgmname = "ComisionesAgrupar_BC";
         if ( ! ( ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 ) || ( StringUtil.StrCmp(A505ComisionesTipo, "C") == 0 ) || ( StringUtil.StrCmp(A505ComisionesTipo, "Z") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Tipo", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1X74( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1X74( )
      {
         /* Using cursor BC001X10 */
         pr_default.execute(8, new Object[] {A503ComisionesID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound74 = 1;
         }
         else
         {
            RcdFound74 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001X8 */
         pr_default.execute(6, new Object[] {A503ComisionesID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM1X74( 5) ;
            RcdFound74 = 1;
            A503ComisionesID = BC001X8_A503ComisionesID[0];
            A505ComisionesTipo = BC001X8_A505ComisionesTipo[0];
            A504ComisionesNombre = BC001X8_A504ComisionesNombre[0];
            A506ComisionesDefault = BC001X8_A506ComisionesDefault[0];
            n506ComisionesDefault = BC001X8_n506ComisionesDefault[0];
            A512ComisionesInventarioEnum = BC001X8_A512ComisionesInventarioEnum[0];
            n512ComisionesInventarioEnum = BC001X8_n512ComisionesInventarioEnum[0];
            O512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
            n512ComisionesInventarioEnum = false;
            Z503ComisionesID = A503ComisionesID;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1X74( ) ;
            if ( AnyError == 1 )
            {
               RcdFound74 = 0;
               InitializeNonKey1X74( ) ;
            }
            Gx_mode = sMode74;
         }
         else
         {
            RcdFound74 = 0;
            InitializeNonKey1X74( ) ;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode74;
         }
         pr_default.close(6);
      }

      protected void getEqualNoModal( )
      {
         GetKey1X74( ) ;
         if ( RcdFound74 == 0 )
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
         CONFIRM_1X0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1X74( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001X7 */
            pr_default.execute(5, new Object[] {A503ComisionesID});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Comisiones"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(5) == 101) || ( StringUtil.StrCmp(Z505ComisionesTipo, BC001X7_A505ComisionesTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z504ComisionesNombre, BC001X7_A504ComisionesNombre[0]) != 0 ) || ( Z506ComisionesDefault != BC001X7_A506ComisionesDefault[0] ) || ( Z512ComisionesInventarioEnum != BC001X7_A512ComisionesInventarioEnum[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Comisiones"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1X74( )
      {
         BeforeValidate1X74( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1X74( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1X74( 0) ;
            CheckOptimisticConcurrency1X74( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1X74( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1X74( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001X11 */
                     pr_default.execute(9, new Object[] {A505ComisionesTipo, A504ComisionesNombre, n506ComisionesDefault, A506ComisionesDefault, n512ComisionesInventarioEnum, A512ComisionesInventarioEnum});
                     A503ComisionesID = BC001X11_A503ComisionesID[0];
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Comisiones");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1X74( ) ;
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
               Load1X74( ) ;
            }
            EndLevel1X74( ) ;
         }
         CloseExtendedTableCursors1X74( ) ;
      }

      protected void Update1X74( )
      {
         BeforeValidate1X74( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1X74( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1X74( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1X74( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1X74( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001X12 */
                     pr_default.execute(10, new Object[] {A505ComisionesTipo, A504ComisionesNombre, n506ComisionesDefault, A506ComisionesDefault, n512ComisionesInventarioEnum, A512ComisionesInventarioEnum, A503ComisionesID});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Comisiones");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Comisiones"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1X74( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1X74( ) ;
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
            EndLevel1X74( ) ;
         }
         CloseExtendedTableCursors1X74( ) ;
      }

      protected void DeferredUpdate1X74( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1X74( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1X74( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1X74( ) ;
            AfterConfirm1X74( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1X74( ) ;
               if ( AnyError == 0 )
               {
                  A512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
                  n512ComisionesInventarioEnum = false;
                  ScanKeyStart1X77( ) ;
                  while ( RcdFound77 != 0 )
                  {
                     getByPrimaryKey1X77( ) ;
                     Delete1X77( ) ;
                     ScanKeyNext1X77( ) ;
                     O512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
                     n512ComisionesInventarioEnum = false;
                  }
                  ScanKeyEnd1X77( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001X13 */
                     pr_default.execute(11, new Object[] {A503ComisionesID});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Comisiones");
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
         sMode74 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1X74( ) ;
         Gx_mode = sMode74;
      }

      protected void OnDeleteControls1X74( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV25Pgmname = "ComisionesAgrupar_BC";
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001X14 */
            pr_default.execute(12, new Object[] {A503ComisionesID});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Profesionales", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC001X15 */
            pr_default.execute(13, new Object[] {A503ComisionesID});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Comercio | Proveedor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void ProcessNestedLevel1X77( )
      {
         s512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
         n512ComisionesInventarioEnum = false;
         nGXsfl_77_idx = 0;
         while ( nGXsfl_77_idx < bcComisionesAgrupar.gxTpr_Rubros.Count )
         {
            ReadRow1X77( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound77 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_77 != 0 ) )
            {
               standaloneNotModal1X77( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert1X77( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete1X77( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update1X77( ) ;
                  }
               }
               O512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
               n512ComisionesInventarioEnum = false;
            }
            KeyVarsToRow77( ((SdtComisionesAgrupar_Rubros)bcComisionesAgrupar.gxTpr_Rubros.Item(nGXsfl_77_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_77_idx = 0;
            while ( nGXsfl_77_idx < bcComisionesAgrupar.gxTpr_Rubros.Count )
            {
               ReadRow1X77( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound77 == 0 )
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
                  bcComisionesAgrupar.gxTpr_Rubros.RemoveElement(nGXsfl_77_idx);
                  nGXsfl_77_idx = (int)(nGXsfl_77_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey1X77( ) ;
                  VarsToRow77( ((SdtComisionesAgrupar_Rubros)bcComisionesAgrupar.gxTpr_Rubros.Item(nGXsfl_77_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1X77( ) ;
         if ( AnyError != 0 )
         {
            O512ComisionesInventarioEnum = s512ComisionesInventarioEnum;
            n512ComisionesInventarioEnum = false;
         }
         nRcdExists_77 = 0;
         nIsMod_77 = 0;
      }

      protected void ProcessLevel1X74( )
      {
         /* Save parent mode. */
         sMode74 = Gx_mode;
         ProcessNestedLevel1X77( ) ;
         if ( AnyError != 0 )
         {
            O512ComisionesInventarioEnum = s512ComisionesInventarioEnum;
            n512ComisionesInventarioEnum = false;
         }
         /* Restore parent mode. */
         Gx_mode = sMode74;
         /* ' Update level parameters */
         /* Using cursor BC001X16 */
         pr_default.execute(14, new Object[] {n512ComisionesInventarioEnum, A512ComisionesInventarioEnum, A503ComisionesID});
         pr_default.close(14);
         pr_default.SmartCacheProvider.SetUpdated("Comisiones");
      }

      protected void EndLevel1X74( )
      {
         pr_default.close(5);
         if ( AnyError == 0 )
         {
            BeforeComplete1X74( ) ;
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

      public void ScanKeyStart1X74( )
      {
         /* Scan By routine */
         /* Using cursor BC001X17 */
         pr_default.execute(15, new Object[] {A503ComisionesID});
         RcdFound74 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound74 = 1;
            A503ComisionesID = BC001X17_A503ComisionesID[0];
            A505ComisionesTipo = BC001X17_A505ComisionesTipo[0];
            A504ComisionesNombre = BC001X17_A504ComisionesNombre[0];
            A506ComisionesDefault = BC001X17_A506ComisionesDefault[0];
            n506ComisionesDefault = BC001X17_n506ComisionesDefault[0];
            A512ComisionesInventarioEnum = BC001X17_A512ComisionesInventarioEnum[0];
            n512ComisionesInventarioEnum = BC001X17_n512ComisionesInventarioEnum[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1X74( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound74 = 0;
         ScanKeyLoad1X74( ) ;
      }

      protected void ScanKeyLoad1X74( )
      {
         sMode74 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound74 = 1;
            A503ComisionesID = BC001X17_A503ComisionesID[0];
            A505ComisionesTipo = BC001X17_A505ComisionesTipo[0];
            A504ComisionesNombre = BC001X17_A504ComisionesNombre[0];
            A506ComisionesDefault = BC001X17_A506ComisionesDefault[0];
            n506ComisionesDefault = BC001X17_n506ComisionesDefault[0];
            A512ComisionesInventarioEnum = BC001X17_A512ComisionesInventarioEnum[0];
            n512ComisionesInventarioEnum = BC001X17_n512ComisionesInventarioEnum[0];
         }
         Gx_mode = sMode74;
      }

      protected void ScanKeyEnd1X74( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1X74( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1X74( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1X74( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1X74( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1X74( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1X74( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1X74( )
      {
      }

      protected void ZM1X77( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z515ComisionesAgruparRubrosValor = A515ComisionesAgruparRubrosValor;
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z135InventarioId = A135InventarioId;
            Z517ComisionesAgruparRubrosGan = A517ComisionesAgruparRubrosGan;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z517ComisionesAgruparRubrosGan = A517ComisionesAgruparRubrosGan;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z517ComisionesAgruparRubrosGan = A517ComisionesAgruparRubrosGan;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z181InventarioPrecioFinal = A181InventarioPrecioFinal;
            Z517ComisionesAgruparRubrosGan = A517ComisionesAgruparRubrosGan;
         }
         if ( GX_JID == -6 )
         {
            Z503ComisionesID = A503ComisionesID;
            Z513ComisionesAgruparRubrosId = A513ComisionesAgruparRubrosId;
            Z515ComisionesAgruparRubrosValor = A515ComisionesAgruparRubrosValor;
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z135InventarioId = A135InventarioId;
            Z181InventarioPrecioFinal = A181InventarioPrecioFinal;
         }
      }

      protected void standaloneNotModal1X77( )
      {
      }

      protected void standaloneModal1X77( )
      {
         if ( IsIns( )  )
         {
            A512ComisionesInventarioEnum = (int)(O512ComisionesInventarioEnum+1);
            n512ComisionesInventarioEnum = false;
         }
         if ( IsIns( )  )
         {
            A513ComisionesAgruparRubrosId = A512ComisionesInventarioEnum;
         }
      }

      protected void Load1X77( )
      {
         /* Using cursor BC001X18 */
         pr_default.execute(16, new Object[] {A503ComisionesID, A513ComisionesAgruparRubrosId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound77 = 1;
            A181InventarioPrecioFinal = BC001X18_A181InventarioPrecioFinal[0];
            A515ComisionesAgruparRubrosValor = BC001X18_A515ComisionesAgruparRubrosValor[0];
            A121RubrosId = BC001X18_A121RubrosId[0];
            A137MedidasID = BC001X18_A137MedidasID[0];
            n137MedidasID = BC001X18_n137MedidasID[0];
            A135InventarioId = BC001X18_A135InventarioId[0];
            n135InventarioId = BC001X18_n135InventarioId[0];
            ZM1X77( -6) ;
         }
         pr_default.close(16);
         OnLoadActions1X77( ) ;
      }

      protected void OnLoadActions1X77( )
      {
         if ( ( A515ComisionesAgruparRubrosValor > Convert.ToDecimal( 0 )) )
         {
            A517ComisionesAgruparRubrosGan = (decimal)((A181InventarioPrecioFinal*(A515ComisionesAgruparRubrosValor/ (decimal)(100))));
         }
         else
         {
            A517ComisionesAgruparRubrosGan = 0;
         }
      }

      protected void CheckExtendedTable1X77( )
      {
         Gx_BScreen = 1;
         standaloneModal1X77( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC001X4 */
         pr_default.execute(2, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RUBROSID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC001X5 */
         pr_default.execute(3, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros Medidas y Precios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDIDASID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         /* Using cursor BC001X6 */
         pr_default.execute(4, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) || (0==A135InventarioId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "INVENTARIOID");
               AnyError = 1;
            }
         }
         A181InventarioPrecioFinal = BC001X6_A181InventarioPrecioFinal[0];
         pr_default.close(4);
         if ( ( A515ComisionesAgruparRubrosValor > Convert.ToDecimal( 0 )) )
         {
            A517ComisionesAgruparRubrosGan = (decimal)((A181InventarioPrecioFinal*(A515ComisionesAgruparRubrosValor/ (decimal)(100))));
         }
         else
         {
            A517ComisionesAgruparRubrosGan = 0;
         }
      }

      protected void CloseExtendedTableCursors1X77( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable1X77( )
      {
      }

      protected void GetKey1X77( )
      {
         /* Using cursor BC001X19 */
         pr_default.execute(17, new Object[] {A503ComisionesID, A513ComisionesAgruparRubrosId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound77 = 1;
         }
         else
         {
            RcdFound77 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey1X77( )
      {
         /* Using cursor BC001X3 */
         pr_default.execute(1, new Object[] {A503ComisionesID, A513ComisionesAgruparRubrosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1X77( 6) ;
            RcdFound77 = 1;
            InitializeNonKey1X77( ) ;
            A513ComisionesAgruparRubrosId = BC001X3_A513ComisionesAgruparRubrosId[0];
            A515ComisionesAgruparRubrosValor = BC001X3_A515ComisionesAgruparRubrosValor[0];
            A121RubrosId = BC001X3_A121RubrosId[0];
            A137MedidasID = BC001X3_A137MedidasID[0];
            n137MedidasID = BC001X3_n137MedidasID[0];
            A135InventarioId = BC001X3_A135InventarioId[0];
            n135InventarioId = BC001X3_n135InventarioId[0];
            Z503ComisionesID = A503ComisionesID;
            Z513ComisionesAgruparRubrosId = A513ComisionesAgruparRubrosId;
            sMode77 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1X77( ) ;
            Load1X77( ) ;
            Gx_mode = sMode77;
         }
         else
         {
            RcdFound77 = 0;
            InitializeNonKey1X77( ) ;
            sMode77 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1X77( ) ;
            Gx_mode = sMode77;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1X77( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1X77( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001X2 */
            pr_default.execute(0, new Object[] {A503ComisionesID, A513ComisionesAgruparRubrosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ComisionesAgruparRubros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z515ComisionesAgruparRubrosValor != BC001X2_A515ComisionesAgruparRubrosValor[0] ) || ( Z121RubrosId != BC001X2_A121RubrosId[0] ) || ( Z137MedidasID != BC001X2_A137MedidasID[0] ) || ( Z135InventarioId != BC001X2_A135InventarioId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ComisionesAgruparRubros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1X77( )
      {
         BeforeValidate1X77( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1X77( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1X77( 0) ;
            CheckOptimisticConcurrency1X77( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1X77( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1X77( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001X20 */
                     pr_default.execute(18, new Object[] {A503ComisionesID, A513ComisionesAgruparRubrosId, A515ComisionesAgruparRubrosValor, A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("ComisionesAgruparRubros");
                     if ( (pr_default.getStatus(18) == 1) )
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
               Load1X77( ) ;
            }
            EndLevel1X77( ) ;
         }
         CloseExtendedTableCursors1X77( ) ;
      }

      protected void Update1X77( )
      {
         BeforeValidate1X77( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1X77( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1X77( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1X77( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1X77( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001X21 */
                     pr_default.execute(19, new Object[] {A515ComisionesAgruparRubrosValor, A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId, A503ComisionesID, A513ComisionesAgruparRubrosId});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("ComisionesAgruparRubros");
                     if ( (pr_default.getStatus(19) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ComisionesAgruparRubros"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1X77( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey1X77( ) ;
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
            EndLevel1X77( ) ;
         }
         CloseExtendedTableCursors1X77( ) ;
      }

      protected void DeferredUpdate1X77( )
      {
      }

      protected void Delete1X77( )
      {
         Gx_mode = "DLT";
         BeforeValidate1X77( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1X77( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1X77( ) ;
            AfterConfirm1X77( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1X77( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001X22 */
                  pr_default.execute(20, new Object[] {A503ComisionesID, A513ComisionesAgruparRubrosId});
                  pr_default.close(20);
                  pr_default.SmartCacheProvider.SetUpdated("ComisionesAgruparRubros");
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
         sMode77 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1X77( ) ;
         Gx_mode = sMode77;
      }

      protected void OnDeleteControls1X77( )
      {
         standaloneModal1X77( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001X23 */
            pr_default.execute(21, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
            A181InventarioPrecioFinal = BC001X23_A181InventarioPrecioFinal[0];
            pr_default.close(21);
            if ( ( A515ComisionesAgruparRubrosValor > Convert.ToDecimal( 0 )) )
            {
               A517ComisionesAgruparRubrosGan = (decimal)((A181InventarioPrecioFinal*(A515ComisionesAgruparRubrosValor/ (decimal)(100))));
            }
            else
            {
               A517ComisionesAgruparRubrosGan = 0;
            }
         }
      }

      protected void EndLevel1X77( )
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

      public void ScanKeyStart1X77( )
      {
         /* Scan By routine */
         /* Using cursor BC001X24 */
         pr_default.execute(22, new Object[] {A503ComisionesID});
         RcdFound77 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound77 = 1;
            A513ComisionesAgruparRubrosId = BC001X24_A513ComisionesAgruparRubrosId[0];
            A181InventarioPrecioFinal = BC001X24_A181InventarioPrecioFinal[0];
            A515ComisionesAgruparRubrosValor = BC001X24_A515ComisionesAgruparRubrosValor[0];
            A121RubrosId = BC001X24_A121RubrosId[0];
            A137MedidasID = BC001X24_A137MedidasID[0];
            n137MedidasID = BC001X24_n137MedidasID[0];
            A135InventarioId = BC001X24_A135InventarioId[0];
            n135InventarioId = BC001X24_n135InventarioId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1X77( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound77 = 0;
         ScanKeyLoad1X77( ) ;
      }

      protected void ScanKeyLoad1X77( )
      {
         sMode77 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound77 = 1;
            A513ComisionesAgruparRubrosId = BC001X24_A513ComisionesAgruparRubrosId[0];
            A181InventarioPrecioFinal = BC001X24_A181InventarioPrecioFinal[0];
            A515ComisionesAgruparRubrosValor = BC001X24_A515ComisionesAgruparRubrosValor[0];
            A121RubrosId = BC001X24_A121RubrosId[0];
            A137MedidasID = BC001X24_A137MedidasID[0];
            n137MedidasID = BC001X24_n137MedidasID[0];
            A135InventarioId = BC001X24_A135InventarioId[0];
            n135InventarioId = BC001X24_n135InventarioId[0];
         }
         Gx_mode = sMode77;
      }

      protected void ScanKeyEnd1X77( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm1X77( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1X77( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1X77( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1X77( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1X77( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1X77( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1X77( )
      {
      }

      protected void send_integrity_lvl_hashes1X77( )
      {
      }

      protected void send_integrity_lvl_hashes1X74( )
      {
      }

      protected void AddRow1X74( )
      {
         VarsToRow74( bcComisionesAgrupar) ;
      }

      protected void ReadRow1X74( )
      {
         RowToVars74( bcComisionesAgrupar, 1) ;
      }

      protected void AddRow1X77( )
      {
         SdtComisionesAgrupar_Rubros obj77;
         obj77 = new SdtComisionesAgrupar_Rubros(context);
         VarsToRow77( obj77) ;
         bcComisionesAgrupar.gxTpr_Rubros.Add(obj77, 0);
         obj77.gxTpr_Mode = "UPD";
         obj77.gxTpr_Modified = 0;
      }

      protected void ReadRow1X77( )
      {
         nGXsfl_77_idx = (int)(nGXsfl_77_idx+1);
         RowToVars77( ((SdtComisionesAgrupar_Rubros)bcComisionesAgrupar.gxTpr_Rubros.Item(nGXsfl_77_idx)), 1) ;
      }

      protected void InitializeNonKey1X74( )
      {
         A505ComisionesTipo = "";
         A504ComisionesNombre = "";
         A506ComisionesDefault = 0;
         n506ComisionesDefault = false;
         A512ComisionesInventarioEnum = 0;
         n512ComisionesInventarioEnum = false;
         O512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
         n512ComisionesInventarioEnum = false;
         Z505ComisionesTipo = "";
         Z504ComisionesNombre = "";
         Z506ComisionesDefault = 0;
         Z512ComisionesInventarioEnum = 0;
      }

      protected void InitAll1X74( )
      {
         A503ComisionesID = 0;
         InitializeNonKey1X74( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1X77( )
      {
         A517ComisionesAgruparRubrosGan = 0;
         A121RubrosId = 0;
         A137MedidasID = 0;
         n137MedidasID = false;
         A135InventarioId = 0;
         n135InventarioId = false;
         A181InventarioPrecioFinal = 0;
         A515ComisionesAgruparRubrosValor = 0;
         Z515ComisionesAgruparRubrosValor = 0;
         Z121RubrosId = 0;
         Z137MedidasID = 0;
         Z135InventarioId = 0;
      }

      protected void InitAll1X77( )
      {
         A513ComisionesAgruparRubrosId = 0;
         InitializeNonKey1X77( ) ;
      }

      protected void StandaloneModalInsert1X77( )
      {
         A512ComisionesInventarioEnum = i512ComisionesInventarioEnum;
         n512ComisionesInventarioEnum = false;
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

      public void VarsToRow74( SdtComisionesAgrupar obj74 )
      {
         obj74.gxTpr_Mode = Gx_mode;
         obj74.gxTpr_Comisionestipo = A505ComisionesTipo;
         obj74.gxTpr_Comisionesnombre = A504ComisionesNombre;
         obj74.gxTpr_Comisionesdefault = A506ComisionesDefault;
         obj74.gxTpr_Comisionesinventarioenum = A512ComisionesInventarioEnum;
         obj74.gxTpr_Comisionesid = A503ComisionesID;
         obj74.gxTpr_Comisionesid_Z = Z503ComisionesID;
         obj74.gxTpr_Comisionestipo_Z = Z505ComisionesTipo;
         obj74.gxTpr_Comisionesnombre_Z = Z504ComisionesNombre;
         obj74.gxTpr_Comisionesdefault_Z = Z506ComisionesDefault;
         obj74.gxTpr_Comisionesinventarioenum_Z = Z512ComisionesInventarioEnum;
         obj74.gxTpr_Comisionesdefault_N = (short)(Convert.ToInt16(n506ComisionesDefault));
         obj74.gxTpr_Comisionesinventarioenum_N = (short)(Convert.ToInt16(n512ComisionesInventarioEnum));
         obj74.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow74( SdtComisionesAgrupar obj74 )
      {
         obj74.gxTpr_Comisionesid = A503ComisionesID;
         return  ;
      }

      public void RowToVars74( SdtComisionesAgrupar obj74 ,
                               int forceLoad )
      {
         Gx_mode = obj74.gxTpr_Mode;
         A505ComisionesTipo = obj74.gxTpr_Comisionestipo;
         A504ComisionesNombre = obj74.gxTpr_Comisionesnombre;
         A506ComisionesDefault = obj74.gxTpr_Comisionesdefault;
         n506ComisionesDefault = false;
         if ( forceLoad == 1 )
         {
            A512ComisionesInventarioEnum = obj74.gxTpr_Comisionesinventarioenum;
            n512ComisionesInventarioEnum = false;
         }
         A503ComisionesID = obj74.gxTpr_Comisionesid;
         Z503ComisionesID = obj74.gxTpr_Comisionesid_Z;
         Z505ComisionesTipo = obj74.gxTpr_Comisionestipo_Z;
         Z504ComisionesNombre = obj74.gxTpr_Comisionesnombre_Z;
         Z506ComisionesDefault = obj74.gxTpr_Comisionesdefault_Z;
         Z512ComisionesInventarioEnum = obj74.gxTpr_Comisionesinventarioenum_Z;
         O512ComisionesInventarioEnum = obj74.gxTpr_Comisionesinventarioenum_Z;
         n506ComisionesDefault = (bool)(Convert.ToBoolean(obj74.gxTpr_Comisionesdefault_N));
         n512ComisionesInventarioEnum = (bool)(Convert.ToBoolean(obj74.gxTpr_Comisionesinventarioenum_N));
         Gx_mode = obj74.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow77( SdtComisionesAgrupar_Rubros obj77 )
      {
         obj77.gxTpr_Mode = Gx_mode;
         obj77.gxTpr_Comisionesagruparrubrosgan = A517ComisionesAgruparRubrosGan;
         obj77.gxTpr_Rubrosid = A121RubrosId;
         obj77.gxTpr_Medidasid = A137MedidasID;
         obj77.gxTpr_Inventarioid = A135InventarioId;
         obj77.gxTpr_Inventariopreciofinal = A181InventarioPrecioFinal;
         obj77.gxTpr_Comisionesagruparrubrosvalor = A515ComisionesAgruparRubrosValor;
         obj77.gxTpr_Comisionesagruparrubrosid = A513ComisionesAgruparRubrosId;
         obj77.gxTpr_Comisionesagruparrubrosid_Z = Z513ComisionesAgruparRubrosId;
         obj77.gxTpr_Rubrosid_Z = Z121RubrosId;
         obj77.gxTpr_Medidasid_Z = Z137MedidasID;
         obj77.gxTpr_Inventarioid_Z = Z135InventarioId;
         obj77.gxTpr_Inventariopreciofinal_Z = Z181InventarioPrecioFinal;
         obj77.gxTpr_Comisionesagruparrubrosvalor_Z = Z515ComisionesAgruparRubrosValor;
         obj77.gxTpr_Comisionesagruparrubrosgan_Z = Z517ComisionesAgruparRubrosGan;
         obj77.gxTpr_Medidasid_N = (short)(Convert.ToInt16(n137MedidasID));
         obj77.gxTpr_Inventarioid_N = (short)(Convert.ToInt16(n135InventarioId));
         obj77.gxTpr_Modified = nIsMod_77;
         return  ;
      }

      public void KeyVarsToRow77( SdtComisionesAgrupar_Rubros obj77 )
      {
         obj77.gxTpr_Comisionesagruparrubrosid = A513ComisionesAgruparRubrosId;
         return  ;
      }

      public void RowToVars77( SdtComisionesAgrupar_Rubros obj77 ,
                               int forceLoad )
      {
         Gx_mode = obj77.gxTpr_Mode;
         A517ComisionesAgruparRubrosGan = obj77.gxTpr_Comisionesagruparrubrosgan;
         A121RubrosId = obj77.gxTpr_Rubrosid;
         A137MedidasID = obj77.gxTpr_Medidasid;
         n137MedidasID = false;
         A135InventarioId = obj77.gxTpr_Inventarioid;
         n135InventarioId = false;
         A181InventarioPrecioFinal = obj77.gxTpr_Inventariopreciofinal;
         A515ComisionesAgruparRubrosValor = obj77.gxTpr_Comisionesagruparrubrosvalor;
         if ( forceLoad == 1 )
         {
            A513ComisionesAgruparRubrosId = obj77.gxTpr_Comisionesagruparrubrosid;
         }
         Z513ComisionesAgruparRubrosId = obj77.gxTpr_Comisionesagruparrubrosid_Z;
         Z121RubrosId = obj77.gxTpr_Rubrosid_Z;
         Z137MedidasID = obj77.gxTpr_Medidasid_Z;
         Z135InventarioId = obj77.gxTpr_Inventarioid_Z;
         Z181InventarioPrecioFinal = obj77.gxTpr_Inventariopreciofinal_Z;
         Z515ComisionesAgruparRubrosValor = obj77.gxTpr_Comisionesagruparrubrosvalor_Z;
         Z517ComisionesAgruparRubrosGan = obj77.gxTpr_Comisionesagruparrubrosgan_Z;
         n137MedidasID = (bool)(Convert.ToBoolean(obj77.gxTpr_Medidasid_N));
         n135InventarioId = (bool)(Convert.ToBoolean(obj77.gxTpr_Inventarioid_N));
         nIsMod_77 = obj77.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A503ComisionesID = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1X74( ) ;
         ScanKeyStart1X74( ) ;
         if ( RcdFound74 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z503ComisionesID = A503ComisionesID;
            O512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
            n512ComisionesInventarioEnum = false;
         }
         ZM1X74( -5) ;
         OnLoadActions1X74( ) ;
         AddRow1X74( ) ;
         bcComisionesAgrupar.gxTpr_Rubros.ClearCollection();
         if ( RcdFound74 == 1 )
         {
            ScanKeyStart1X77( ) ;
            nGXsfl_77_idx = 1;
            while ( RcdFound77 != 0 )
            {
               Z503ComisionesID = A503ComisionesID;
               Z513ComisionesAgruparRubrosId = A513ComisionesAgruparRubrosId;
               ZM1X77( -6) ;
               OnLoadActions1X77( ) ;
               nRcdExists_77 = 1;
               nIsMod_77 = 0;
               AddRow1X77( ) ;
               nGXsfl_77_idx = (int)(nGXsfl_77_idx+1);
               ScanKeyNext1X77( ) ;
            }
            ScanKeyEnd1X77( ) ;
         }
         ScanKeyEnd1X74( ) ;
         if ( RcdFound74 == 0 )
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
         RowToVars74( bcComisionesAgrupar, 0) ;
         ScanKeyStart1X74( ) ;
         if ( RcdFound74 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z503ComisionesID = A503ComisionesID;
            O512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
            n512ComisionesInventarioEnum = false;
         }
         ZM1X74( -5) ;
         OnLoadActions1X74( ) ;
         AddRow1X74( ) ;
         bcComisionesAgrupar.gxTpr_Rubros.ClearCollection();
         if ( RcdFound74 == 1 )
         {
            ScanKeyStart1X77( ) ;
            nGXsfl_77_idx = 1;
            while ( RcdFound77 != 0 )
            {
               Z503ComisionesID = A503ComisionesID;
               Z513ComisionesAgruparRubrosId = A513ComisionesAgruparRubrosId;
               ZM1X77( -6) ;
               OnLoadActions1X77( ) ;
               nRcdExists_77 = 1;
               nIsMod_77 = 0;
               AddRow1X77( ) ;
               nGXsfl_77_idx = (int)(nGXsfl_77_idx+1);
               ScanKeyNext1X77( ) ;
            }
            ScanKeyEnd1X77( ) ;
         }
         ScanKeyEnd1X74( ) ;
         if ( RcdFound74 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1X74( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
            n512ComisionesInventarioEnum = false;
            Insert1X74( ) ;
         }
         else
         {
            if ( RcdFound74 == 1 )
            {
               if ( A503ComisionesID != Z503ComisionesID )
               {
                  A503ComisionesID = Z503ComisionesID;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
                  n512ComisionesInventarioEnum = false;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
                  n512ComisionesInventarioEnum = false;
                  Update1X74( ) ;
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
                  if ( A503ComisionesID != Z503ComisionesID )
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
                        A512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
                        n512ComisionesInventarioEnum = false;
                        Insert1X74( ) ;
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
                        A512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
                        n512ComisionesInventarioEnum = false;
                        Insert1X74( ) ;
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
         RowToVars74( bcComisionesAgrupar, 1) ;
         SaveImpl( ) ;
         VarsToRow74( bcComisionesAgrupar) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars74( bcComisionesAgrupar, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
         n512ComisionesInventarioEnum = false;
         Insert1X74( ) ;
         AfterTrn( ) ;
         VarsToRow74( bcComisionesAgrupar) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow74( bcComisionesAgrupar) ;
         }
         else
         {
            SdtComisionesAgrupar auxBC = new SdtComisionesAgrupar(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A503ComisionesID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcComisionesAgrupar);
               auxBC.Save();
               bcComisionesAgrupar.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars74( bcComisionesAgrupar, 1) ;
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
         RowToVars74( bcComisionesAgrupar, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1X74( ) ;
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
               VarsToRow74( bcComisionesAgrupar) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow74( bcComisionesAgrupar) ;
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
         RowToVars74( bcComisionesAgrupar, 0) ;
         GetKey1X74( ) ;
         if ( RcdFound74 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A503ComisionesID != Z503ComisionesID )
            {
               A503ComisionesID = Z503ComisionesID;
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
            if ( A503ComisionesID != Z503ComisionesID )
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
         pr_default.close(6);
         pr_default.close(1);
         pr_default.close(21);
         context.RollbackDataStores("comisionesagrupar_bc",pr_default);
         VarsToRow74( bcComisionesAgrupar) ;
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
         Gx_mode = bcComisionesAgrupar.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcComisionesAgrupar.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcComisionesAgrupar )
         {
            bcComisionesAgrupar = (SdtComisionesAgrupar)(sdt);
            if ( StringUtil.StrCmp(bcComisionesAgrupar.gxTpr_Mode, "") == 0 )
            {
               bcComisionesAgrupar.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow74( bcComisionesAgrupar) ;
            }
            else
            {
               RowToVars74( bcComisionesAgrupar, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcComisionesAgrupar.gxTpr_Mode, "") == 0 )
            {
               bcComisionesAgrupar.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars74( bcComisionesAgrupar, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtComisionesAgrupar ComisionesAgrupar_BC
      {
         get {
            return bcComisionesAgrupar ;
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
         pr_default.close(21);
         pr_default.close(6);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode74 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV25Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z505ComisionesTipo = "";
         A505ComisionesTipo = "";
         Z504ComisionesNombre = "";
         A504ComisionesNombre = "";
         BC001X9_A503ComisionesID = new long[1] ;
         BC001X9_A505ComisionesTipo = new string[] {""} ;
         BC001X9_A504ComisionesNombre = new string[] {""} ;
         BC001X9_A506ComisionesDefault = new decimal[1] ;
         BC001X9_n506ComisionesDefault = new bool[] {false} ;
         BC001X9_A512ComisionesInventarioEnum = new int[1] ;
         BC001X9_n512ComisionesInventarioEnum = new bool[] {false} ;
         BC001X10_A503ComisionesID = new long[1] ;
         BC001X8_A503ComisionesID = new long[1] ;
         BC001X8_A505ComisionesTipo = new string[] {""} ;
         BC001X8_A504ComisionesNombre = new string[] {""} ;
         BC001X8_A506ComisionesDefault = new decimal[1] ;
         BC001X8_n506ComisionesDefault = new bool[] {false} ;
         BC001X8_A512ComisionesInventarioEnum = new int[1] ;
         BC001X8_n512ComisionesInventarioEnum = new bool[] {false} ;
         BC001X7_A503ComisionesID = new long[1] ;
         BC001X7_A505ComisionesTipo = new string[] {""} ;
         BC001X7_A504ComisionesNombre = new string[] {""} ;
         BC001X7_A506ComisionesDefault = new decimal[1] ;
         BC001X7_n506ComisionesDefault = new bool[] {false} ;
         BC001X7_A512ComisionesInventarioEnum = new int[1] ;
         BC001X7_n512ComisionesInventarioEnum = new bool[] {false} ;
         BC001X11_A503ComisionesID = new long[1] ;
         BC001X14_A503ComisionesID = new long[1] ;
         BC001X14_A120ProfesionalesId = new string[] {""} ;
         BC001X15_A503ComisionesID = new long[1] ;
         BC001X15_A133ProveedorID = new long[1] ;
         BC001X17_A503ComisionesID = new long[1] ;
         BC001X17_A505ComisionesTipo = new string[] {""} ;
         BC001X17_A504ComisionesNombre = new string[] {""} ;
         BC001X17_A506ComisionesDefault = new decimal[1] ;
         BC001X17_n506ComisionesDefault = new bool[] {false} ;
         BC001X17_A512ComisionesInventarioEnum = new int[1] ;
         BC001X17_n512ComisionesInventarioEnum = new bool[] {false} ;
         BC001X18_A503ComisionesID = new long[1] ;
         BC001X18_A513ComisionesAgruparRubrosId = new long[1] ;
         BC001X18_A181InventarioPrecioFinal = new decimal[1] ;
         BC001X18_A515ComisionesAgruparRubrosValor = new decimal[1] ;
         BC001X18_A121RubrosId = new short[1] ;
         BC001X18_A137MedidasID = new long[1] ;
         BC001X18_n137MedidasID = new bool[] {false} ;
         BC001X18_A135InventarioId = new long[1] ;
         BC001X18_n135InventarioId = new bool[] {false} ;
         BC001X4_A121RubrosId = new short[1] ;
         BC001X5_A121RubrosId = new short[1] ;
         BC001X6_A181InventarioPrecioFinal = new decimal[1] ;
         BC001X19_A503ComisionesID = new long[1] ;
         BC001X19_A513ComisionesAgruparRubrosId = new long[1] ;
         BC001X3_A503ComisionesID = new long[1] ;
         BC001X3_A513ComisionesAgruparRubrosId = new long[1] ;
         BC001X3_A515ComisionesAgruparRubrosValor = new decimal[1] ;
         BC001X3_A121RubrosId = new short[1] ;
         BC001X3_A137MedidasID = new long[1] ;
         BC001X3_n137MedidasID = new bool[] {false} ;
         BC001X3_A135InventarioId = new long[1] ;
         BC001X3_n135InventarioId = new bool[] {false} ;
         sMode77 = "";
         BC001X2_A503ComisionesID = new long[1] ;
         BC001X2_A513ComisionesAgruparRubrosId = new long[1] ;
         BC001X2_A515ComisionesAgruparRubrosValor = new decimal[1] ;
         BC001X2_A121RubrosId = new short[1] ;
         BC001X2_A137MedidasID = new long[1] ;
         BC001X2_n137MedidasID = new bool[] {false} ;
         BC001X2_A135InventarioId = new long[1] ;
         BC001X2_n135InventarioId = new bool[] {false} ;
         BC001X23_A181InventarioPrecioFinal = new decimal[1] ;
         BC001X24_A503ComisionesID = new long[1] ;
         BC001X24_A513ComisionesAgruparRubrosId = new long[1] ;
         BC001X24_A181InventarioPrecioFinal = new decimal[1] ;
         BC001X24_A515ComisionesAgruparRubrosValor = new decimal[1] ;
         BC001X24_A121RubrosId = new short[1] ;
         BC001X24_A137MedidasID = new long[1] ;
         BC001X24_n137MedidasID = new bool[] {false} ;
         BC001X24_A135InventarioId = new long[1] ;
         BC001X24_n135InventarioId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.comisionesagrupar_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisionesagrupar_bc__default(),
            new Object[][] {
                new Object[] {
               BC001X2_A503ComisionesID, BC001X2_A513ComisionesAgruparRubrosId, BC001X2_A515ComisionesAgruparRubrosValor, BC001X2_A121RubrosId, BC001X2_A137MedidasID, BC001X2_n137MedidasID, BC001X2_A135InventarioId, BC001X2_n135InventarioId
               }
               , new Object[] {
               BC001X3_A503ComisionesID, BC001X3_A513ComisionesAgruparRubrosId, BC001X3_A515ComisionesAgruparRubrosValor, BC001X3_A121RubrosId, BC001X3_A137MedidasID, BC001X3_n137MedidasID, BC001X3_A135InventarioId, BC001X3_n135InventarioId
               }
               , new Object[] {
               BC001X4_A121RubrosId
               }
               , new Object[] {
               BC001X5_A121RubrosId
               }
               , new Object[] {
               BC001X6_A181InventarioPrecioFinal
               }
               , new Object[] {
               BC001X7_A503ComisionesID, BC001X7_A505ComisionesTipo, BC001X7_A504ComisionesNombre, BC001X7_A506ComisionesDefault, BC001X7_n506ComisionesDefault, BC001X7_A512ComisionesInventarioEnum, BC001X7_n512ComisionesInventarioEnum
               }
               , new Object[] {
               BC001X8_A503ComisionesID, BC001X8_A505ComisionesTipo, BC001X8_A504ComisionesNombre, BC001X8_A506ComisionesDefault, BC001X8_n506ComisionesDefault, BC001X8_A512ComisionesInventarioEnum, BC001X8_n512ComisionesInventarioEnum
               }
               , new Object[] {
               BC001X9_A503ComisionesID, BC001X9_A505ComisionesTipo, BC001X9_A504ComisionesNombre, BC001X9_A506ComisionesDefault, BC001X9_n506ComisionesDefault, BC001X9_A512ComisionesInventarioEnum, BC001X9_n512ComisionesInventarioEnum
               }
               , new Object[] {
               BC001X10_A503ComisionesID
               }
               , new Object[] {
               BC001X11_A503ComisionesID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001X14_A503ComisionesID, BC001X14_A120ProfesionalesId
               }
               , new Object[] {
               BC001X15_A503ComisionesID, BC001X15_A133ProveedorID
               }
               , new Object[] {
               }
               , new Object[] {
               BC001X17_A503ComisionesID, BC001X17_A505ComisionesTipo, BC001X17_A504ComisionesNombre, BC001X17_A506ComisionesDefault, BC001X17_n506ComisionesDefault, BC001X17_A512ComisionesInventarioEnum, BC001X17_n512ComisionesInventarioEnum
               }
               , new Object[] {
               BC001X18_A503ComisionesID, BC001X18_A513ComisionesAgruparRubrosId, BC001X18_A181InventarioPrecioFinal, BC001X18_A515ComisionesAgruparRubrosValor, BC001X18_A121RubrosId, BC001X18_A137MedidasID, BC001X18_n137MedidasID, BC001X18_A135InventarioId, BC001X18_n135InventarioId
               }
               , new Object[] {
               BC001X19_A503ComisionesID, BC001X19_A513ComisionesAgruparRubrosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001X23_A181InventarioPrecioFinal
               }
               , new Object[] {
               BC001X24_A503ComisionesID, BC001X24_A513ComisionesAgruparRubrosId, BC001X24_A181InventarioPrecioFinal, BC001X24_A515ComisionesAgruparRubrosValor, BC001X24_A121RubrosId, BC001X24_A137MedidasID, BC001X24_n137MedidasID, BC001X24_A135InventarioId, BC001X24_n135InventarioId
               }
            }
         );
         AV25Pgmname = "ComisionesAgrupar_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121X2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_77 ;
      private short RcdFound77 ;
      private short RcdFound74 ;
      private short nRcdExists_77 ;
      private short Z121RubrosId ;
      private short A121RubrosId ;
      private short Gx_BScreen ;
      private short Gxremove77 ;
      private int trnEnded ;
      private int s512ComisionesInventarioEnum ;
      private int O512ComisionesInventarioEnum ;
      private int A512ComisionesInventarioEnum ;
      private int nGXsfl_77_idx=1 ;
      private int Z512ComisionesInventarioEnum ;
      private int i512ComisionesInventarioEnum ;
      private long Z503ComisionesID ;
      private long A503ComisionesID ;
      private long Z137MedidasID ;
      private long A137MedidasID ;
      private long Z135InventarioId ;
      private long A135InventarioId ;
      private long Z513ComisionesAgruparRubrosId ;
      private long A513ComisionesAgruparRubrosId ;
      private decimal Z506ComisionesDefault ;
      private decimal A506ComisionesDefault ;
      private decimal Z515ComisionesAgruparRubrosValor ;
      private decimal A515ComisionesAgruparRubrosValor ;
      private decimal Z517ComisionesAgruparRubrosGan ;
      private decimal A517ComisionesAgruparRubrosGan ;
      private decimal Z181InventarioPrecioFinal ;
      private decimal A181InventarioPrecioFinal ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode74 ;
      private string AV25Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Z505ComisionesTipo ;
      private string A505ComisionesTipo ;
      private string Z504ComisionesNombre ;
      private string A504ComisionesNombre ;
      private string sMode77 ;
      private bool n512ComisionesInventarioEnum ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool n506ComisionesDefault ;
      private bool n137MedidasID ;
      private bool n135InventarioId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtComisionesAgrupar bcComisionesAgrupar ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] BC001X9_A503ComisionesID ;
      private string[] BC001X9_A505ComisionesTipo ;
      private string[] BC001X9_A504ComisionesNombre ;
      private decimal[] BC001X9_A506ComisionesDefault ;
      private bool[] BC001X9_n506ComisionesDefault ;
      private int[] BC001X9_A512ComisionesInventarioEnum ;
      private bool[] BC001X9_n512ComisionesInventarioEnum ;
      private long[] BC001X10_A503ComisionesID ;
      private long[] BC001X8_A503ComisionesID ;
      private string[] BC001X8_A505ComisionesTipo ;
      private string[] BC001X8_A504ComisionesNombre ;
      private decimal[] BC001X8_A506ComisionesDefault ;
      private bool[] BC001X8_n506ComisionesDefault ;
      private int[] BC001X8_A512ComisionesInventarioEnum ;
      private bool[] BC001X8_n512ComisionesInventarioEnum ;
      private long[] BC001X7_A503ComisionesID ;
      private string[] BC001X7_A505ComisionesTipo ;
      private string[] BC001X7_A504ComisionesNombre ;
      private decimal[] BC001X7_A506ComisionesDefault ;
      private bool[] BC001X7_n506ComisionesDefault ;
      private int[] BC001X7_A512ComisionesInventarioEnum ;
      private bool[] BC001X7_n512ComisionesInventarioEnum ;
      private long[] BC001X11_A503ComisionesID ;
      private long[] BC001X14_A503ComisionesID ;
      private string[] BC001X14_A120ProfesionalesId ;
      private long[] BC001X15_A503ComisionesID ;
      private long[] BC001X15_A133ProveedorID ;
      private long[] BC001X17_A503ComisionesID ;
      private string[] BC001X17_A505ComisionesTipo ;
      private string[] BC001X17_A504ComisionesNombre ;
      private decimal[] BC001X17_A506ComisionesDefault ;
      private bool[] BC001X17_n506ComisionesDefault ;
      private int[] BC001X17_A512ComisionesInventarioEnum ;
      private bool[] BC001X17_n512ComisionesInventarioEnum ;
      private long[] BC001X18_A503ComisionesID ;
      private long[] BC001X18_A513ComisionesAgruparRubrosId ;
      private decimal[] BC001X18_A181InventarioPrecioFinal ;
      private decimal[] BC001X18_A515ComisionesAgruparRubrosValor ;
      private short[] BC001X18_A121RubrosId ;
      private long[] BC001X18_A137MedidasID ;
      private bool[] BC001X18_n137MedidasID ;
      private long[] BC001X18_A135InventarioId ;
      private bool[] BC001X18_n135InventarioId ;
      private short[] BC001X4_A121RubrosId ;
      private short[] BC001X5_A121RubrosId ;
      private decimal[] BC001X6_A181InventarioPrecioFinal ;
      private long[] BC001X19_A503ComisionesID ;
      private long[] BC001X19_A513ComisionesAgruparRubrosId ;
      private long[] BC001X3_A503ComisionesID ;
      private long[] BC001X3_A513ComisionesAgruparRubrosId ;
      private decimal[] BC001X3_A515ComisionesAgruparRubrosValor ;
      private short[] BC001X3_A121RubrosId ;
      private long[] BC001X3_A137MedidasID ;
      private bool[] BC001X3_n137MedidasID ;
      private long[] BC001X3_A135InventarioId ;
      private bool[] BC001X3_n135InventarioId ;
      private long[] BC001X2_A503ComisionesID ;
      private long[] BC001X2_A513ComisionesAgruparRubrosId ;
      private decimal[] BC001X2_A515ComisionesAgruparRubrosValor ;
      private short[] BC001X2_A121RubrosId ;
      private long[] BC001X2_A137MedidasID ;
      private bool[] BC001X2_n137MedidasID ;
      private long[] BC001X2_A135InventarioId ;
      private bool[] BC001X2_n135InventarioId ;
      private decimal[] BC001X23_A181InventarioPrecioFinal ;
      private long[] BC001X24_A503ComisionesID ;
      private long[] BC001X24_A513ComisionesAgruparRubrosId ;
      private decimal[] BC001X24_A181InventarioPrecioFinal ;
      private decimal[] BC001X24_A515ComisionesAgruparRubrosValor ;
      private short[] BC001X24_A121RubrosId ;
      private long[] BC001X24_A137MedidasID ;
      private bool[] BC001X24_n137MedidasID ;
      private long[] BC001X24_A135InventarioId ;
      private bool[] BC001X24_n135InventarioId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class comisionesagrupar_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class comisionesagrupar_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC001X2;
        prmBC001X2 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ComisionesAgruparRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmBC001X3;
        prmBC001X3 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ComisionesAgruparRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmBC001X4;
        prmBC001X4 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC001X5;
        prmBC001X5 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001X6;
        prmBC001X6 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001X7;
        prmBC001X7 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmBC001X8;
        prmBC001X8 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmBC001X9;
        prmBC001X9 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmBC001X10;
        prmBC001X10 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmBC001X11;
        prmBC001X11 = new Object[] {
        new ParDef("@ComisionesTipo",GXType.NChar,1,0) ,
        new ParDef("@ComisionesNombre",GXType.NChar,80,0) ,
        new ParDef("@ComisionesDefault",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@ComisionesInventarioEnum",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmBC001X12;
        prmBC001X12 = new Object[] {
        new ParDef("@ComisionesTipo",GXType.NChar,1,0) ,
        new ParDef("@ComisionesNombre",GXType.NChar,80,0) ,
        new ParDef("@ComisionesDefault",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@ComisionesInventarioEnum",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmBC001X13;
        prmBC001X13 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmBC001X14;
        prmBC001X14 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmBC001X15;
        prmBC001X15 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmBC001X16;
        prmBC001X16 = new Object[] {
        new ParDef("@ComisionesInventarioEnum",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmBC001X17;
        prmBC001X17 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmBC001X18;
        prmBC001X18 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ComisionesAgruparRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmBC001X19;
        prmBC001X19 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ComisionesAgruparRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmBC001X20;
        prmBC001X20 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ComisionesAgruparRubrosId",GXType.Decimal,18,0) ,
        new ParDef("@ComisionesAgruparRubrosValor",GXType.Decimal,18,2) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001X21;
        prmBC001X21 = new Object[] {
        new ParDef("@ComisionesAgruparRubrosValor",GXType.Decimal,18,2) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ComisionesAgruparRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmBC001X22;
        prmBC001X22 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ComisionesAgruparRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmBC001X23;
        prmBC001X23 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001X24;
        prmBC001X24 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC001X2", "SELECT [ComisionesID], [ComisionesAgruparRubrosId], [ComisionesAgruparRubrosValor], [RubrosId], [MedidasID], [InventarioId] FROM [ComisionesAgruparRubros] WITH (UPDLOCK) WHERE [ComisionesID] = @ComisionesID AND [ComisionesAgruparRubrosId] = @ComisionesAgruparRubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001X3", "SELECT [ComisionesID], [ComisionesAgruparRubrosId], [ComisionesAgruparRubrosValor], [RubrosId], [MedidasID], [InventarioId] FROM [ComisionesAgruparRubros] WHERE [ComisionesID] = @ComisionesID AND [ComisionesAgruparRubrosId] = @ComisionesAgruparRubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001X4", "SELECT [RubrosId] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001X5", "SELECT [RubrosId] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001X6", "SELECT [InventarioPrecioFinal] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001X7", "SELECT [ComisionesID], [ComisionesTipo], [ComisionesNombre], [ComisionesDefault], [ComisionesInventarioEnum] FROM [Comisiones] WITH (UPDLOCK) WHERE [ComisionesID] = @ComisionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001X8", "SELECT [ComisionesID], [ComisionesTipo], [ComisionesNombre], [ComisionesDefault], [ComisionesInventarioEnum] FROM [Comisiones] WHERE [ComisionesID] = @ComisionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001X9", "SELECT TM1.[ComisionesID], TM1.[ComisionesTipo], TM1.[ComisionesNombre], TM1.[ComisionesDefault], TM1.[ComisionesInventarioEnum] FROM [Comisiones] TM1 WHERE TM1.[ComisionesID] = @ComisionesID ORDER BY TM1.[ComisionesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X9,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001X10", "SELECT [ComisionesID] FROM [Comisiones] WHERE [ComisionesID] = @ComisionesID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001X11", "INSERT INTO [Comisiones]([ComisionesTipo], [ComisionesNombre], [ComisionesDefault], [ComisionesInventarioEnum], [ComisionesImagen], [ComisionesImagen_GXI], [ComisionesGlobal], [ComisionesFechaAlta], [ComisionesEspermanente], [ComisionesFechaVigencia], [ComisionesFechaVencimiento], [ComisionesEstado], [ComisionesComentario]) VALUES(@ComisionesTipo, @ComisionesNombre, @ComisionesDefault, @ComisionesInventarioEnum, CONVERT(varbinary(1), ''), '', convert(bit, 0), convert( DATETIME, '17530101', 112 ), convert(bit, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', ''); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001X12", "UPDATE [Comisiones] SET [ComisionesTipo]=@ComisionesTipo, [ComisionesNombre]=@ComisionesNombre, [ComisionesDefault]=@ComisionesDefault, [ComisionesInventarioEnum]=@ComisionesInventarioEnum  WHERE [ComisionesID] = @ComisionesID", GxErrorMask.GX_NOMASK,prmBC001X12)
           ,new CursorDef("BC001X13", "DELETE FROM [Comisiones]  WHERE [ComisionesID] = @ComisionesID", GxErrorMask.GX_NOMASK,prmBC001X13)
           ,new CursorDef("BC001X14", "SELECT TOP 1 [ComisionesID], [ProfesionalesId] FROM [ComisionesProfesionales] WHERE [ComisionesID] = @ComisionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001X15", "SELECT TOP 1 [ComisionesID], [ProveedorID] FROM [ComisionesProveedores] WHERE [ComisionesID] = @ComisionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001X16", "UPDATE [Comisiones] SET [ComisionesInventarioEnum]=@ComisionesInventarioEnum  WHERE [ComisionesID] = @ComisionesID", GxErrorMask.GX_NOMASK,prmBC001X16)
           ,new CursorDef("BC001X17", "SELECT TM1.[ComisionesID], TM1.[ComisionesTipo], TM1.[ComisionesNombre], TM1.[ComisionesDefault], TM1.[ComisionesInventarioEnum] FROM [Comisiones] TM1 WHERE TM1.[ComisionesID] = @ComisionesID ORDER BY TM1.[ComisionesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001X18", "SELECT T1.[ComisionesID], T1.[ComisionesAgruparRubrosId], T2.[InventarioPrecioFinal], T1.[ComisionesAgruparRubrosValor], T1.[RubrosId], T1.[MedidasID], T1.[InventarioId] FROM ([ComisionesAgruparRubros] T1 LEFT JOIN [Inventario] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID] AND T2.[InventarioId] = T1.[InventarioId]) WHERE T1.[ComisionesID] = @ComisionesID and T1.[ComisionesAgruparRubrosId] = @ComisionesAgruparRubrosId ORDER BY T1.[ComisionesID], T1.[ComisionesAgruparRubrosId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X18,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001X19", "SELECT [ComisionesID], [ComisionesAgruparRubrosId] FROM [ComisionesAgruparRubros] WHERE [ComisionesID] = @ComisionesID AND [ComisionesAgruparRubrosId] = @ComisionesAgruparRubrosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001X20", "INSERT INTO [ComisionesAgruparRubros]([ComisionesID], [ComisionesAgruparRubrosId], [ComisionesAgruparRubrosValor], [RubrosId], [MedidasID], [InventarioId]) VALUES(@ComisionesID, @ComisionesAgruparRubrosId, @ComisionesAgruparRubrosValor, @RubrosId, @MedidasID, @InventarioId)", GxErrorMask.GX_NOMASK,prmBC001X20)
           ,new CursorDef("BC001X21", "UPDATE [ComisionesAgruparRubros] SET [ComisionesAgruparRubrosValor]=@ComisionesAgruparRubrosValor, [RubrosId]=@RubrosId, [MedidasID]=@MedidasID, [InventarioId]=@InventarioId  WHERE [ComisionesID] = @ComisionesID AND [ComisionesAgruparRubrosId] = @ComisionesAgruparRubrosId", GxErrorMask.GX_NOMASK,prmBC001X21)
           ,new CursorDef("BC001X22", "DELETE FROM [ComisionesAgruparRubros]  WHERE [ComisionesID] = @ComisionesID AND [ComisionesAgruparRubrosId] = @ComisionesAgruparRubrosId", GxErrorMask.GX_NOMASK,prmBC001X22)
           ,new CursorDef("BC001X23", "SELECT [InventarioPrecioFinal] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001X24", "SELECT T1.[ComisionesID], T1.[ComisionesAgruparRubrosId], T2.[InventarioPrecioFinal], T1.[ComisionesAgruparRubrosValor], T1.[RubrosId], T1.[MedidasID], T1.[InventarioId] FROM ([ComisionesAgruparRubros] T1 LEFT JOIN [Inventario] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID] AND T2.[InventarioId] = T1.[InventarioId]) WHERE T1.[ComisionesID] = @ComisionesID ORDER BY T1.[ComisionesID], T1.[ComisionesAgruparRubrosId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X24,11, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((int[]) buf[5])[0] = rslt.getInt(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((int[]) buf[5])[0] = rslt.getInt(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((int[]) buf[5])[0] = rslt.getInt(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((int[]) buf[5])[0] = rslt.getInt(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((long[]) buf[7])[0] = rslt.getLong(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 21 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              return;
           case 22 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((long[]) buf[7])[0] = rslt.getLong(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
     }
  }

}

}
