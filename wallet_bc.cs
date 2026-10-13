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
   public class wallet_bc : GXHttpHandler, IGxSilentTrn
   {
      public wallet_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wallet_bc( IGxContext context )
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
         ReadRow2992( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2992( ) ;
         standaloneModal( ) ;
         AddRow2992( ) ;
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
            E11292 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z637WalletId = A637WalletId;
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

      protected void CONFIRM_290( )
      {
         BeforeValidate2992( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2992( ) ;
            }
            else
            {
               CheckExtendedTable2992( ) ;
               if ( AnyError == 0 )
               {
                  ZM2992( 18) ;
                  ZM2992( 19) ;
               }
               CloseExtendedTableCursors2992( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode92 = Gx_mode;
            CONFIRM_2993( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode92;
            }
            /* Restore parent mode. */
            Gx_mode = sMode92;
         }
      }

      protected void CONFIRM_2993( )
      {
         nGXsfl_93_idx = 0;
         while ( nGXsfl_93_idx < bcWallet.gxTpr_Balances.Count )
         {
            ReadRow2993( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound93 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_93 != 0 ) )
            {
               GetKey2993( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound93 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate2993( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable2993( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors2993( ) ;
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
                  if ( RcdFound93 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey2993( ) ;
                        Load2993( ) ;
                        BeforeValidate2993( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls2993( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_93 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate2993( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable2993( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors2993( ) ;
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
               VarsToRow93( ((SdtWallet_Balances)bcWallet.gxTpr_Balances.Item(nGXsfl_93_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E12292( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWWallet_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWWallet_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWWallet_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV18Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV18Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV19GXV1 = 1;
            while ( AV19GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV19GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "TipoCuentaId") == 0 )
               {
                  AV13Insert_TipoCuentaId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "MonedaId") == 0 )
               {
                  AV14Insert_MonedaId = (short)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV19GXV1 = (int)(AV19GXV1+1);
            }
         }
      }

      protected void E11292( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2992( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z638WalletTipoEntidad = A638WalletTipoEntidad;
            Z639WalletCodRefencia = A639WalletCodRefencia;
            Z665WalletEstado = A665WalletEstado;
            Z483TipoCuentaId = A483TipoCuentaId;
            Z118MonedaId = A118MonedaId;
            Z715WalletNombre = A715WalletNombre;
            Z646WalletTotalDebito = A646WalletTotalDebito;
            Z647WalletTotalCredito = A647WalletTotalCredito;
            Z648WalletSaldo = A648WalletSaldo;
            Z1007WalletSolicitudesPendientes = A1007WalletSolicitudesPendientes;
            Z1008WalletSaldoAlDia = A1008WalletSaldoAlDia;
         }
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z636TipoCuentaConcepto = A636TipoCuentaConcepto;
            Z484TipoCuentaNombre = A484TipoCuentaNombre;
            Z715WalletNombre = A715WalletNombre;
            Z646WalletTotalDebito = A646WalletTotalDebito;
            Z647WalletTotalCredito = A647WalletTotalCredito;
            Z648WalletSaldo = A648WalletSaldo;
            Z1007WalletSolicitudesPendientes = A1007WalletSolicitudesPendientes;
            Z1008WalletSaldoAlDia = A1008WalletSaldoAlDia;
         }
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            Z119MonedaISOSimbolo = A119MonedaISOSimbolo;
            Z715WalletNombre = A715WalletNombre;
            Z646WalletTotalDebito = A646WalletTotalDebito;
            Z647WalletTotalCredito = A647WalletTotalCredito;
            Z648WalletSaldo = A648WalletSaldo;
            Z1007WalletSolicitudesPendientes = A1007WalletSolicitudesPendientes;
            Z1008WalletSaldoAlDia = A1008WalletSaldoAlDia;
         }
         if ( GX_JID == -16 )
         {
            Z637WalletId = A637WalletId;
            Z638WalletTipoEntidad = A638WalletTipoEntidad;
            Z639WalletCodRefencia = A639WalletCodRefencia;
            Z665WalletEstado = A665WalletEstado;
            Z483TipoCuentaId = A483TipoCuentaId;
            Z118MonedaId = A118MonedaId;
            Z636TipoCuentaConcepto = A636TipoCuentaConcepto;
            Z484TipoCuentaNombre = A484TipoCuentaNombre;
            Z119MonedaISOSimbolo = A119MonedaISOSimbolo;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2992( )
      {
         /* Using cursor BC00298 */
         pr_default.execute(6, new Object[] {A637WalletId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound92 = 1;
            A636TipoCuentaConcepto = BC00298_A636TipoCuentaConcepto[0];
            A484TipoCuentaNombre = BC00298_A484TipoCuentaNombre[0];
            A638WalletTipoEntidad = BC00298_A638WalletTipoEntidad[0];
            A639WalletCodRefencia = BC00298_A639WalletCodRefencia[0];
            A119MonedaISOSimbolo = BC00298_A119MonedaISOSimbolo[0];
            A665WalletEstado = BC00298_A665WalletEstado[0];
            A483TipoCuentaId = BC00298_A483TipoCuentaId[0];
            A118MonedaId = BC00298_A118MonedaId[0];
            n118MonedaId = BC00298_n118MonedaId[0];
            ZM2992( -16) ;
         }
         pr_default.close(6);
         OnLoadActions2992( ) ;
      }

      protected void OnLoadActions2992( )
      {
         AV18Pgmname = "Wallet_BC";
         GXt_decimal2 = A647WalletTotalCredito;
         new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
         A647WalletTotalCredito = GXt_decimal2;
         GXt_decimal2 = A646WalletTotalDebito;
         new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
         A646WalletTotalDebito = GXt_decimal2;
         A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
         GXt_char3 = A715WalletNombre;
         new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char3) ;
         A715WalletNombre = GXt_char3;
         GXt_decimal2 = A1007WalletSolicitudesPendientes;
         new owalletsaldosolpendientes(context ).execute(  A639WalletCodRefencia, out  GXt_decimal2) ;
         A1007WalletSolicitudesPendientes = GXt_decimal2;
         A1008WalletSaldoAlDia = (decimal)(A648WalletSaldo+A1007WalletSolicitudesPendientes);
      }

      protected void CheckExtendedTable2992( )
      {
         standaloneModal( ) ;
         AV18Pgmname = "Wallet_BC";
         /* Using cursor BC00299 */
         pr_default.execute(7, new Object[] {A639WalletCodRefencia, A637WalletId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Código de Refencia", "")}), "DuplicateCandidateKey", 1, "");
            AnyError = 1;
         }
         pr_default.close(7);
         GXt_decimal2 = A647WalletTotalCredito;
         new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
         A647WalletTotalCredito = GXt_decimal2;
         GXt_decimal2 = A646WalletTotalDebito;
         new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
         A646WalletTotalDebito = GXt_decimal2;
         A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
         /* Using cursor BC00296 */
         pr_default.execute(4, new Object[] {A483TipoCuentaId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo Cuenta", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TIPOCUENTAID");
            AnyError = 1;
         }
         A636TipoCuentaConcepto = BC00296_A636TipoCuentaConcepto[0];
         A484TipoCuentaNombre = BC00296_A484TipoCuentaNombre[0];
         pr_default.close(4);
         if ( ! ( ( StringUtil.StrCmp(A638WalletTipoEntidad, "CLI") == 0 ) || ( StringUtil.StrCmp(A638WalletTipoEntidad, "COM") == 0 ) || ( StringUtil.StrCmp(A638WalletTipoEntidad, "PRO") == 0 ) || ( StringUtil.StrCmp(A638WalletTipoEntidad, "EMP") == 0 ) || ( StringUtil.StrCmp(A638WalletTipoEntidad, "OTR") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Wallet Tipo Entidad", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         GXt_char3 = A715WalletNombre;
         new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char3) ;
         A715WalletNombre = GXt_char3;
         GXt_decimal2 = A1007WalletSolicitudesPendientes;
         new owalletsaldosolpendientes(context ).execute(  A639WalletCodRefencia, out  GXt_decimal2) ;
         A1007WalletSolicitudesPendientes = GXt_decimal2;
         A1008WalletSaldoAlDia = (decimal)(A648WalletSaldo+A1007WalletSolicitudesPendientes);
         /* Using cursor BC00297 */
         pr_default.execute(5, new Object[] {n118MonedaId, A118MonedaId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A118MonedaId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( " T12", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MONEDAID");
               AnyError = 1;
            }
         }
         A119MonedaISOSimbolo = BC00297_A119MonedaISOSimbolo[0];
         pr_default.close(5);
         if ( ! ( ( StringUtil.StrCmp(A665WalletEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A665WalletEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A665WalletEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A665WalletEstado, "BLO") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2992( )
      {
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2992( )
      {
         /* Using cursor BC002910 */
         pr_default.execute(8, new Object[] {A637WalletId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound92 = 1;
         }
         else
         {
            RcdFound92 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00295 */
         pr_default.execute(3, new Object[] {A637WalletId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM2992( 16) ;
            RcdFound92 = 1;
            A637WalletId = BC00295_A637WalletId[0];
            A638WalletTipoEntidad = BC00295_A638WalletTipoEntidad[0];
            A639WalletCodRefencia = BC00295_A639WalletCodRefencia[0];
            A665WalletEstado = BC00295_A665WalletEstado[0];
            A483TipoCuentaId = BC00295_A483TipoCuentaId[0];
            A118MonedaId = BC00295_A118MonedaId[0];
            n118MonedaId = BC00295_n118MonedaId[0];
            Z637WalletId = A637WalletId;
            sMode92 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2992( ) ;
            if ( AnyError == 1 )
            {
               RcdFound92 = 0;
               InitializeNonKey2992( ) ;
            }
            Gx_mode = sMode92;
         }
         else
         {
            RcdFound92 = 0;
            InitializeNonKey2992( ) ;
            sMode92 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode92;
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey2992( ) ;
         if ( RcdFound92 == 0 )
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
         CONFIRM_290( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2992( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00294 */
            pr_default.execute(2, new Object[] {A637WalletId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Wallet"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z638WalletTipoEntidad, BC00294_A638WalletTipoEntidad[0]) != 0 ) || ( StringUtil.StrCmp(Z639WalletCodRefencia, BC00294_A639WalletCodRefencia[0]) != 0 ) || ( StringUtil.StrCmp(Z665WalletEstado, BC00294_A665WalletEstado[0]) != 0 ) || ( Z483TipoCuentaId != BC00294_A483TipoCuentaId[0] ) || ( Z118MonedaId != BC00294_A118MonedaId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Wallet"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2992( )
      {
         BeforeValidate2992( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2992( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2992( 0) ;
            CheckOptimisticConcurrency2992( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2992( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2992( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002911 */
                     pr_default.execute(9, new Object[] {A638WalletTipoEntidad, A639WalletCodRefencia, A665WalletEstado, A483TipoCuentaId, n118MonedaId, A118MonedaId});
                     A637WalletId = BC002911_A637WalletId[0];
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Wallet");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2992( ) ;
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
               Load2992( ) ;
            }
            EndLevel2992( ) ;
         }
         CloseExtendedTableCursors2992( ) ;
      }

      protected void Update2992( )
      {
         BeforeValidate2992( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2992( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2992( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2992( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2992( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002912 */
                     pr_default.execute(10, new Object[] {A638WalletTipoEntidad, A639WalletCodRefencia, A665WalletEstado, A483TipoCuentaId, n118MonedaId, A118MonedaId, A637WalletId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Wallet");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Wallet"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2992( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2992( ) ;
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
            EndLevel2992( ) ;
         }
         CloseExtendedTableCursors2992( ) ;
      }

      protected void DeferredUpdate2992( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2992( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2992( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2992( ) ;
            AfterConfirm2992( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2992( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart2993( ) ;
                  while ( RcdFound93 != 0 )
                  {
                     getByPrimaryKey2993( ) ;
                     Delete2993( ) ;
                     ScanKeyNext2993( ) ;
                  }
                  ScanKeyEnd2993( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002913 */
                     pr_default.execute(11, new Object[] {A637WalletId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Wallet");
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
         sMode92 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2992( ) ;
         Gx_mode = sMode92;
      }

      protected void OnDeleteControls2992( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV18Pgmname = "Wallet_BC";
            GXt_decimal2 = A647WalletTotalCredito;
            new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
            A647WalletTotalCredito = GXt_decimal2;
            GXt_decimal2 = A646WalletTotalDebito;
            new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
            A646WalletTotalDebito = GXt_decimal2;
            A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
            /* Using cursor BC002914 */
            pr_default.execute(12, new Object[] {A483TipoCuentaId});
            A636TipoCuentaConcepto = BC002914_A636TipoCuentaConcepto[0];
            A484TipoCuentaNombre = BC002914_A484TipoCuentaNombre[0];
            pr_default.close(12);
            GXt_char3 = A715WalletNombre;
            new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char3) ;
            A715WalletNombre = GXt_char3;
            GXt_decimal2 = A1007WalletSolicitudesPendientes;
            new owalletsaldosolpendientes(context ).execute(  A639WalletCodRefencia, out  GXt_decimal2) ;
            A1007WalletSolicitudesPendientes = GXt_decimal2;
            A1008WalletSaldoAlDia = (decimal)(A648WalletSaldo+A1007WalletSolicitudesPendientes);
            /* Using cursor BC002915 */
            pr_default.execute(13, new Object[] {n118MonedaId, A118MonedaId});
            A119MonedaISOSimbolo = BC002915_A119MonedaISOSimbolo[0];
            pr_default.close(13);
         }
      }

      protected void ProcessNestedLevel2993( )
      {
         nGXsfl_93_idx = 0;
         while ( nGXsfl_93_idx < bcWallet.gxTpr_Balances.Count )
         {
            ReadRow2993( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound93 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_93 != 0 ) )
            {
               standaloneNotModal2993( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert2993( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete2993( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update2993( ) ;
                  }
               }
            }
            KeyVarsToRow93( ((SdtWallet_Balances)bcWallet.gxTpr_Balances.Item(nGXsfl_93_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_93_idx = 0;
            while ( nGXsfl_93_idx < bcWallet.gxTpr_Balances.Count )
            {
               ReadRow2993( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound93 == 0 )
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
                  bcWallet.gxTpr_Balances.RemoveElement(nGXsfl_93_idx);
                  nGXsfl_93_idx = (int)(nGXsfl_93_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey2993( ) ;
                  VarsToRow93( ((SdtWallet_Balances)bcWallet.gxTpr_Balances.Item(nGXsfl_93_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll2993( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_93 = 0;
         nIsMod_93 = 0;
      }

      protected void ProcessLevel2992( )
      {
         /* Save parent mode. */
         sMode92 = Gx_mode;
         ProcessNestedLevel2993( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode92;
         /* ' Update level parameters */
      }

      protected void EndLevel2992( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2992( ) ;
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

      public void ScanKeyStart2992( )
      {
         /* Scan By routine */
         /* Using cursor BC002916 */
         pr_default.execute(14, new Object[] {A637WalletId});
         RcdFound92 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound92 = 1;
            A637WalletId = BC002916_A637WalletId[0];
            A636TipoCuentaConcepto = BC002916_A636TipoCuentaConcepto[0];
            A484TipoCuentaNombre = BC002916_A484TipoCuentaNombre[0];
            A638WalletTipoEntidad = BC002916_A638WalletTipoEntidad[0];
            A639WalletCodRefencia = BC002916_A639WalletCodRefencia[0];
            A119MonedaISOSimbolo = BC002916_A119MonedaISOSimbolo[0];
            A665WalletEstado = BC002916_A665WalletEstado[0];
            A483TipoCuentaId = BC002916_A483TipoCuentaId[0];
            A118MonedaId = BC002916_A118MonedaId[0];
            n118MonedaId = BC002916_n118MonedaId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2992( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound92 = 0;
         ScanKeyLoad2992( ) ;
      }

      protected void ScanKeyLoad2992( )
      {
         sMode92 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound92 = 1;
            A637WalletId = BC002916_A637WalletId[0];
            A636TipoCuentaConcepto = BC002916_A636TipoCuentaConcepto[0];
            A484TipoCuentaNombre = BC002916_A484TipoCuentaNombre[0];
            A638WalletTipoEntidad = BC002916_A638WalletTipoEntidad[0];
            A639WalletCodRefencia = BC002916_A639WalletCodRefencia[0];
            A119MonedaISOSimbolo = BC002916_A119MonedaISOSimbolo[0];
            A665WalletEstado = BC002916_A665WalletEstado[0];
            A483TipoCuentaId = BC002916_A483TipoCuentaId[0];
            A118MonedaId = BC002916_A118MonedaId[0];
            n118MonedaId = BC002916_n118MonedaId[0];
         }
         Gx_mode = sMode92;
      }

      protected void ScanKeyEnd2992( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm2992( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2992( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2992( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2992( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2992( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2992( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2992( )
      {
      }

      protected void ZM2993( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            Z641WalletBalancesFechaAlta = A641WalletBalancesFechaAlta;
            Z642WalletBalancesUsrAlta = A642WalletBalancesUsrAlta;
            Z643WalletBalancesTipoMov = A643WalletBalancesTipoMov;
            Z644WalletBalancesImporte = A644WalletBalancesImporte;
            Z1009WalletBalancesObs = A1009WalletBalancesObs;
            Z1010WalletBalancesConcepto = A1010WalletBalancesConcepto;
            Z1011WalletBalancesUrl = A1011WalletBalancesUrl;
            Z645WalletBalancesEstadoOPE = A645WalletBalancesEstadoOPE;
            Z1012WalletBalanceLiquidacion = A1012WalletBalanceLiquidacion;
         }
         if ( GX_JID == -20 )
         {
            Z637WalletId = A637WalletId;
            Z640WalletBalancesId = A640WalletBalancesId;
            Z641WalletBalancesFechaAlta = A641WalletBalancesFechaAlta;
            Z642WalletBalancesUsrAlta = A642WalletBalancesUsrAlta;
            Z643WalletBalancesTipoMov = A643WalletBalancesTipoMov;
            Z644WalletBalancesImporte = A644WalletBalancesImporte;
            Z1009WalletBalancesObs = A1009WalletBalancesObs;
            Z1010WalletBalancesConcepto = A1010WalletBalancesConcepto;
            Z1011WalletBalancesUrl = A1011WalletBalancesUrl;
            Z645WalletBalancesEstadoOPE = A645WalletBalancesEstadoOPE;
            Z1012WalletBalanceLiquidacion = A1012WalletBalanceLiquidacion;
         }
      }

      protected void standaloneNotModal2993( )
      {
      }

      protected void standaloneModal2993( )
      {
      }

      protected void Load2993( )
      {
         /* Using cursor BC002917 */
         pr_default.execute(15, new Object[] {A637WalletId, A640WalletBalancesId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound93 = 1;
            A641WalletBalancesFechaAlta = BC002917_A641WalletBalancesFechaAlta[0];
            A642WalletBalancesUsrAlta = BC002917_A642WalletBalancesUsrAlta[0];
            A643WalletBalancesTipoMov = BC002917_A643WalletBalancesTipoMov[0];
            A644WalletBalancesImporte = BC002917_A644WalletBalancesImporte[0];
            A1009WalletBalancesObs = BC002917_A1009WalletBalancesObs[0];
            n1009WalletBalancesObs = BC002917_n1009WalletBalancesObs[0];
            A1010WalletBalancesConcepto = BC002917_A1010WalletBalancesConcepto[0];
            n1010WalletBalancesConcepto = BC002917_n1010WalletBalancesConcepto[0];
            A1011WalletBalancesUrl = BC002917_A1011WalletBalancesUrl[0];
            n1011WalletBalancesUrl = BC002917_n1011WalletBalancesUrl[0];
            A645WalletBalancesEstadoOPE = BC002917_A645WalletBalancesEstadoOPE[0];
            A1012WalletBalanceLiquidacion = BC002917_A1012WalletBalanceLiquidacion[0];
            n1012WalletBalanceLiquidacion = BC002917_n1012WalletBalanceLiquidacion[0];
            ZM2993( -20) ;
         }
         pr_default.close(15);
         OnLoadActions2993( ) ;
      }

      protected void OnLoadActions2993( )
      {
      }

      protected void CheckExtendedTable2993( )
      {
         Gx_BScreen = 1;
         standaloneModal2993( ) ;
         Gx_BScreen = 0;
         if ( ! ( (DateTime.MinValue==A641WalletBalancesFechaAlta) || ( A641WalletBalancesFechaAlta >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha de Alta", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A643WalletBalancesTipoMov, "DEB") == 0 ) || ( StringUtil.StrCmp(A643WalletBalancesTipoMov, "CRE") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Tipo de Movimiento", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( A1010WalletBalancesConcepto == 1 ) || ( A1010WalletBalancesConcepto == 2 ) || ( A1010WalletBalancesConcepto == 3 ) || ( A1010WalletBalancesConcepto == 4 ) || ( A1010WalletBalancesConcepto == 5 ) || ( A1010WalletBalancesConcepto == 6 ) || (0==A1010WalletBalancesConcepto) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Wallet Balances Concepto", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A1011WalletBalancesUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") || String.IsNullOrEmpty(StringUtil.RTrim( A1011WalletBalancesUrl)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Wallet Balances Url", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A645WalletBalancesEstadoOPE, "PRO") == 0 ) || ( StringUtil.StrCmp(A645WalletBalancesEstadoOPE, "PND") == 0 ) || ( StringUtil.StrCmp(A645WalletBalancesEstadoOPE, "ANU") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2993( )
      {
      }

      protected void enableDisable2993( )
      {
      }

      protected void GetKey2993( )
      {
         /* Using cursor BC002918 */
         pr_default.execute(16, new Object[] {A637WalletId, A640WalletBalancesId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound93 = 1;
         }
         else
         {
            RcdFound93 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey2993( )
      {
         /* Using cursor BC00293 */
         pr_default.execute(1, new Object[] {A637WalletId, A640WalletBalancesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2993( 20) ;
            RcdFound93 = 1;
            InitializeNonKey2993( ) ;
            A640WalletBalancesId = BC00293_A640WalletBalancesId[0];
            A641WalletBalancesFechaAlta = BC00293_A641WalletBalancesFechaAlta[0];
            A642WalletBalancesUsrAlta = BC00293_A642WalletBalancesUsrAlta[0];
            A643WalletBalancesTipoMov = BC00293_A643WalletBalancesTipoMov[0];
            A644WalletBalancesImporte = BC00293_A644WalletBalancesImporte[0];
            A1009WalletBalancesObs = BC00293_A1009WalletBalancesObs[0];
            n1009WalletBalancesObs = BC00293_n1009WalletBalancesObs[0];
            A1010WalletBalancesConcepto = BC00293_A1010WalletBalancesConcepto[0];
            n1010WalletBalancesConcepto = BC00293_n1010WalletBalancesConcepto[0];
            A1011WalletBalancesUrl = BC00293_A1011WalletBalancesUrl[0];
            n1011WalletBalancesUrl = BC00293_n1011WalletBalancesUrl[0];
            A645WalletBalancesEstadoOPE = BC00293_A645WalletBalancesEstadoOPE[0];
            A1012WalletBalanceLiquidacion = BC00293_A1012WalletBalanceLiquidacion[0];
            n1012WalletBalanceLiquidacion = BC00293_n1012WalletBalanceLiquidacion[0];
            Z637WalletId = A637WalletId;
            Z640WalletBalancesId = A640WalletBalancesId;
            sMode93 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal2993( ) ;
            Load2993( ) ;
            Gx_mode = sMode93;
         }
         else
         {
            RcdFound93 = 0;
            InitializeNonKey2993( ) ;
            sMode93 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal2993( ) ;
            Gx_mode = sMode93;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes2993( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency2993( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00292 */
            pr_default.execute(0, new Object[] {A637WalletId, A640WalletBalancesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WalletBalances"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z641WalletBalancesFechaAlta != BC00292_A641WalletBalancesFechaAlta[0] ) || ( Z642WalletBalancesUsrAlta != BC00292_A642WalletBalancesUsrAlta[0] ) || ( StringUtil.StrCmp(Z643WalletBalancesTipoMov, BC00292_A643WalletBalancesTipoMov[0]) != 0 ) || ( Z644WalletBalancesImporte != BC00292_A644WalletBalancesImporte[0] ) || ( StringUtil.StrCmp(Z1009WalletBalancesObs, BC00292_A1009WalletBalancesObs[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1010WalletBalancesConcepto != BC00292_A1010WalletBalancesConcepto[0] ) || ( StringUtil.StrCmp(Z1011WalletBalancesUrl, BC00292_A1011WalletBalancesUrl[0]) != 0 ) || ( StringUtil.StrCmp(Z645WalletBalancesEstadoOPE, BC00292_A645WalletBalancesEstadoOPE[0]) != 0 ) || ( Z1012WalletBalanceLiquidacion != BC00292_A1012WalletBalanceLiquidacion[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WalletBalances"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2993( )
      {
         BeforeValidate2993( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2993( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2993( 0) ;
            CheckOptimisticConcurrency2993( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2993( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2993( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002919 */
                     pr_default.execute(17, new Object[] {A637WalletId, A640WalletBalancesId, A641WalletBalancesFechaAlta, A642WalletBalancesUsrAlta, A643WalletBalancesTipoMov, A644WalletBalancesImporte, n1009WalletBalancesObs, A1009WalletBalancesObs, n1010WalletBalancesConcepto, A1010WalletBalancesConcepto, n1011WalletBalancesUrl, A1011WalletBalancesUrl, A645WalletBalancesEstadoOPE, n1012WalletBalanceLiquidacion, A1012WalletBalanceLiquidacion});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("WalletBalances");
                     if ( (pr_default.getStatus(17) == 1) )
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
               Load2993( ) ;
            }
            EndLevel2993( ) ;
         }
         CloseExtendedTableCursors2993( ) ;
      }

      protected void Update2993( )
      {
         BeforeValidate2993( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2993( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2993( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2993( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2993( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002920 */
                     pr_default.execute(18, new Object[] {A641WalletBalancesFechaAlta, A642WalletBalancesUsrAlta, A643WalletBalancesTipoMov, A644WalletBalancesImporte, n1009WalletBalancesObs, A1009WalletBalancesObs, n1010WalletBalancesConcepto, A1010WalletBalancesConcepto, n1011WalletBalancesUrl, A1011WalletBalancesUrl, A645WalletBalancesEstadoOPE, n1012WalletBalanceLiquidacion, A1012WalletBalanceLiquidacion, A637WalletId, A640WalletBalancesId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("WalletBalances");
                     if ( (pr_default.getStatus(18) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WalletBalances"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2993( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey2993( ) ;
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
            EndLevel2993( ) ;
         }
         CloseExtendedTableCursors2993( ) ;
      }

      protected void DeferredUpdate2993( )
      {
      }

      protected void Delete2993( )
      {
         Gx_mode = "DLT";
         BeforeValidate2993( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2993( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2993( ) ;
            AfterConfirm2993( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2993( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002921 */
                  pr_default.execute(19, new Object[] {A637WalletId, A640WalletBalancesId});
                  pr_default.close(19);
                  pr_default.SmartCacheProvider.SetUpdated("WalletBalances");
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
         sMode93 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2993( ) ;
         Gx_mode = sMode93;
      }

      protected void OnDeleteControls2993( )
      {
         standaloneModal2993( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2993( )
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

      public void ScanKeyStart2993( )
      {
         /* Scan By routine */
         /* Using cursor BC002922 */
         pr_default.execute(20, new Object[] {A637WalletId});
         RcdFound93 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound93 = 1;
            A640WalletBalancesId = BC002922_A640WalletBalancesId[0];
            A641WalletBalancesFechaAlta = BC002922_A641WalletBalancesFechaAlta[0];
            A642WalletBalancesUsrAlta = BC002922_A642WalletBalancesUsrAlta[0];
            A643WalletBalancesTipoMov = BC002922_A643WalletBalancesTipoMov[0];
            A644WalletBalancesImporte = BC002922_A644WalletBalancesImporte[0];
            A1009WalletBalancesObs = BC002922_A1009WalletBalancesObs[0];
            n1009WalletBalancesObs = BC002922_n1009WalletBalancesObs[0];
            A1010WalletBalancesConcepto = BC002922_A1010WalletBalancesConcepto[0];
            n1010WalletBalancesConcepto = BC002922_n1010WalletBalancesConcepto[0];
            A1011WalletBalancesUrl = BC002922_A1011WalletBalancesUrl[0];
            n1011WalletBalancesUrl = BC002922_n1011WalletBalancesUrl[0];
            A645WalletBalancesEstadoOPE = BC002922_A645WalletBalancesEstadoOPE[0];
            A1012WalletBalanceLiquidacion = BC002922_A1012WalletBalanceLiquidacion[0];
            n1012WalletBalanceLiquidacion = BC002922_n1012WalletBalanceLiquidacion[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2993( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound93 = 0;
         ScanKeyLoad2993( ) ;
      }

      protected void ScanKeyLoad2993( )
      {
         sMode93 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound93 = 1;
            A640WalletBalancesId = BC002922_A640WalletBalancesId[0];
            A641WalletBalancesFechaAlta = BC002922_A641WalletBalancesFechaAlta[0];
            A642WalletBalancesUsrAlta = BC002922_A642WalletBalancesUsrAlta[0];
            A643WalletBalancesTipoMov = BC002922_A643WalletBalancesTipoMov[0];
            A644WalletBalancesImporte = BC002922_A644WalletBalancesImporte[0];
            A1009WalletBalancesObs = BC002922_A1009WalletBalancesObs[0];
            n1009WalletBalancesObs = BC002922_n1009WalletBalancesObs[0];
            A1010WalletBalancesConcepto = BC002922_A1010WalletBalancesConcepto[0];
            n1010WalletBalancesConcepto = BC002922_n1010WalletBalancesConcepto[0];
            A1011WalletBalancesUrl = BC002922_A1011WalletBalancesUrl[0];
            n1011WalletBalancesUrl = BC002922_n1011WalletBalancesUrl[0];
            A645WalletBalancesEstadoOPE = BC002922_A645WalletBalancesEstadoOPE[0];
            A1012WalletBalanceLiquidacion = BC002922_A1012WalletBalanceLiquidacion[0];
            n1012WalletBalanceLiquidacion = BC002922_n1012WalletBalanceLiquidacion[0];
         }
         Gx_mode = sMode93;
      }

      protected void ScanKeyEnd2993( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm2993( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2993( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2993( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2993( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2993( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2993( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2993( )
      {
      }

      protected void send_integrity_lvl_hashes2993( )
      {
      }

      protected void send_integrity_lvl_hashes2992( )
      {
      }

      protected void AddRow2992( )
      {
         VarsToRow92( bcWallet) ;
      }

      protected void ReadRow2992( )
      {
         RowToVars92( bcWallet, 1) ;
      }

      protected void AddRow2993( )
      {
         SdtWallet_Balances obj93;
         obj93 = new SdtWallet_Balances(context);
         VarsToRow93( obj93) ;
         bcWallet.gxTpr_Balances.Add(obj93, 0);
         obj93.gxTpr_Mode = "UPD";
         obj93.gxTpr_Modified = 0;
      }

      protected void ReadRow2993( )
      {
         nGXsfl_93_idx = (int)(nGXsfl_93_idx+1);
         RowToVars93( ((SdtWallet_Balances)bcWallet.gxTpr_Balances.Item(nGXsfl_93_idx)), 1) ;
      }

      protected void InitializeNonKey2992( )
      {
         A1008WalletSaldoAlDia = 0;
         A648WalletSaldo = 0;
         A1007WalletSolicitudesPendientes = 0;
         A715WalletNombre = "";
         A646WalletTotalDebito = 0;
         A647WalletTotalCredito = 0;
         A483TipoCuentaId = 0;
         A636TipoCuentaConcepto = "";
         A484TipoCuentaNombre = "";
         A638WalletTipoEntidad = "";
         A639WalletCodRefencia = "";
         A118MonedaId = 0;
         n118MonedaId = false;
         A119MonedaISOSimbolo = "";
         A665WalletEstado = "";
         Z638WalletTipoEntidad = "";
         Z639WalletCodRefencia = "";
         Z665WalletEstado = "";
         Z483TipoCuentaId = 0;
         Z118MonedaId = 0;
      }

      protected void InitAll2992( )
      {
         A637WalletId = 0;
         InitializeNonKey2992( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey2993( )
      {
         A641WalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
         A642WalletBalancesUsrAlta = 0;
         A643WalletBalancesTipoMov = "";
         A644WalletBalancesImporte = 0;
         A1009WalletBalancesObs = "";
         n1009WalletBalancesObs = false;
         A1010WalletBalancesConcepto = 0;
         n1010WalletBalancesConcepto = false;
         A1011WalletBalancesUrl = "";
         n1011WalletBalancesUrl = false;
         A645WalletBalancesEstadoOPE = "";
         A1012WalletBalanceLiquidacion = 0;
         n1012WalletBalanceLiquidacion = false;
         Z641WalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
         Z642WalletBalancesUsrAlta = 0;
         Z643WalletBalancesTipoMov = "";
         Z644WalletBalancesImporte = 0;
         Z1009WalletBalancesObs = "";
         Z1010WalletBalancesConcepto = 0;
         Z1011WalletBalancesUrl = "";
         Z645WalletBalancesEstadoOPE = "";
         Z1012WalletBalanceLiquidacion = 0;
      }

      protected void InitAll2993( )
      {
         A640WalletBalancesId = 0;
         InitializeNonKey2993( ) ;
      }

      protected void StandaloneModalInsert2993( )
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

      public void VarsToRow92( SdtWallet obj92 )
      {
         obj92.gxTpr_Mode = Gx_mode;
         obj92.gxTpr_Walletsaldoaldia = A1008WalletSaldoAlDia;
         obj92.gxTpr_Walletsaldo = A648WalletSaldo;
         obj92.gxTpr_Walletsolicitudespendientes = A1007WalletSolicitudesPendientes;
         obj92.gxTpr_Walletnombre = A715WalletNombre;
         obj92.gxTpr_Wallettotaldebito = A646WalletTotalDebito;
         obj92.gxTpr_Wallettotalcredito = A647WalletTotalCredito;
         obj92.gxTpr_Tipocuentaid = A483TipoCuentaId;
         obj92.gxTpr_Tipocuentaconcepto = A636TipoCuentaConcepto;
         obj92.gxTpr_Tipocuentanombre = A484TipoCuentaNombre;
         obj92.gxTpr_Wallettipoentidad = A638WalletTipoEntidad;
         obj92.gxTpr_Walletcodrefencia = A639WalletCodRefencia;
         obj92.gxTpr_Monedaid = A118MonedaId;
         obj92.gxTpr_Monedaisosimbolo = A119MonedaISOSimbolo;
         obj92.gxTpr_Walletestado = A665WalletEstado;
         obj92.gxTpr_Walletid = A637WalletId;
         obj92.gxTpr_Walletid_Z = Z637WalletId;
         obj92.gxTpr_Tipocuentaid_Z = Z483TipoCuentaId;
         obj92.gxTpr_Tipocuentaconcepto_Z = Z636TipoCuentaConcepto;
         obj92.gxTpr_Tipocuentanombre_Z = Z484TipoCuentaNombre;
         obj92.gxTpr_Wallettipoentidad_Z = Z638WalletTipoEntidad;
         obj92.gxTpr_Walletcodrefencia_Z = Z639WalletCodRefencia;
         obj92.gxTpr_Walletnombre_Z = Z715WalletNombre;
         obj92.gxTpr_Monedaid_Z = Z118MonedaId;
         obj92.gxTpr_Monedaisosimbolo_Z = Z119MonedaISOSimbolo;
         obj92.gxTpr_Wallettotaldebito_Z = Z646WalletTotalDebito;
         obj92.gxTpr_Wallettotalcredito_Z = Z647WalletTotalCredito;
         obj92.gxTpr_Walletsaldo_Z = Z648WalletSaldo;
         obj92.gxTpr_Walletsolicitudespendientes_Z = Z1007WalletSolicitudesPendientes;
         obj92.gxTpr_Walletsaldoaldia_Z = Z1008WalletSaldoAlDia;
         obj92.gxTpr_Walletestado_Z = Z665WalletEstado;
         obj92.gxTpr_Monedaid_N = (short)(Convert.ToInt16(n118MonedaId));
         obj92.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow92( SdtWallet obj92 )
      {
         obj92.gxTpr_Walletid = A637WalletId;
         return  ;
      }

      public void RowToVars92( SdtWallet obj92 ,
                               int forceLoad )
      {
         Gx_mode = obj92.gxTpr_Mode;
         A1008WalletSaldoAlDia = obj92.gxTpr_Walletsaldoaldia;
         A648WalletSaldo = obj92.gxTpr_Walletsaldo;
         A1007WalletSolicitudesPendientes = obj92.gxTpr_Walletsolicitudespendientes;
         A715WalletNombre = obj92.gxTpr_Walletnombre;
         A646WalletTotalDebito = obj92.gxTpr_Wallettotaldebito;
         A647WalletTotalCredito = obj92.gxTpr_Wallettotalcredito;
         A483TipoCuentaId = obj92.gxTpr_Tipocuentaid;
         A636TipoCuentaConcepto = obj92.gxTpr_Tipocuentaconcepto;
         A484TipoCuentaNombre = obj92.gxTpr_Tipocuentanombre;
         A638WalletTipoEntidad = obj92.gxTpr_Wallettipoentidad;
         A639WalletCodRefencia = obj92.gxTpr_Walletcodrefencia;
         A118MonedaId = obj92.gxTpr_Monedaid;
         n118MonedaId = false;
         A119MonedaISOSimbolo = obj92.gxTpr_Monedaisosimbolo;
         A665WalletEstado = obj92.gxTpr_Walletestado;
         A637WalletId = obj92.gxTpr_Walletid;
         Z637WalletId = obj92.gxTpr_Walletid_Z;
         Z483TipoCuentaId = obj92.gxTpr_Tipocuentaid_Z;
         Z636TipoCuentaConcepto = obj92.gxTpr_Tipocuentaconcepto_Z;
         Z484TipoCuentaNombre = obj92.gxTpr_Tipocuentanombre_Z;
         Z638WalletTipoEntidad = obj92.gxTpr_Wallettipoentidad_Z;
         Z639WalletCodRefencia = obj92.gxTpr_Walletcodrefencia_Z;
         Z715WalletNombre = obj92.gxTpr_Walletnombre_Z;
         Z118MonedaId = obj92.gxTpr_Monedaid_Z;
         Z119MonedaISOSimbolo = obj92.gxTpr_Monedaisosimbolo_Z;
         Z646WalletTotalDebito = obj92.gxTpr_Wallettotaldebito_Z;
         Z647WalletTotalCredito = obj92.gxTpr_Wallettotalcredito_Z;
         Z648WalletSaldo = obj92.gxTpr_Walletsaldo_Z;
         Z1007WalletSolicitudesPendientes = obj92.gxTpr_Walletsolicitudespendientes_Z;
         Z1008WalletSaldoAlDia = obj92.gxTpr_Walletsaldoaldia_Z;
         Z665WalletEstado = obj92.gxTpr_Walletestado_Z;
         n118MonedaId = (bool)(Convert.ToBoolean(obj92.gxTpr_Monedaid_N));
         Gx_mode = obj92.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow93( SdtWallet_Balances obj93 )
      {
         obj93.gxTpr_Mode = Gx_mode;
         obj93.gxTpr_Walletbalancesfechaalta = A641WalletBalancesFechaAlta;
         obj93.gxTpr_Walletbalancesusralta = A642WalletBalancesUsrAlta;
         obj93.gxTpr_Walletbalancestipomov = A643WalletBalancesTipoMov;
         obj93.gxTpr_Walletbalancesimporte = A644WalletBalancesImporte;
         obj93.gxTpr_Walletbalancesobs = A1009WalletBalancesObs;
         obj93.gxTpr_Walletbalancesconcepto = A1010WalletBalancesConcepto;
         obj93.gxTpr_Walletbalancesurl = A1011WalletBalancesUrl;
         obj93.gxTpr_Walletbalancesestadoope = A645WalletBalancesEstadoOPE;
         obj93.gxTpr_Walletbalanceliquidacion = A1012WalletBalanceLiquidacion;
         obj93.gxTpr_Walletbalancesid = A640WalletBalancesId;
         obj93.gxTpr_Walletbalancesid_Z = Z640WalletBalancesId;
         obj93.gxTpr_Walletbalancesfechaalta_Z = Z641WalletBalancesFechaAlta;
         obj93.gxTpr_Walletbalancesusralta_Z = Z642WalletBalancesUsrAlta;
         obj93.gxTpr_Walletbalancestipomov_Z = Z643WalletBalancesTipoMov;
         obj93.gxTpr_Walletbalancesimporte_Z = Z644WalletBalancesImporte;
         obj93.gxTpr_Walletbalancesobs_Z = Z1009WalletBalancesObs;
         obj93.gxTpr_Walletbalancesconcepto_Z = Z1010WalletBalancesConcepto;
         obj93.gxTpr_Walletbalancesurl_Z = Z1011WalletBalancesUrl;
         obj93.gxTpr_Walletbalancesestadoope_Z = Z645WalletBalancesEstadoOPE;
         obj93.gxTpr_Walletbalanceliquidacion_Z = Z1012WalletBalanceLiquidacion;
         obj93.gxTpr_Walletbalancesobs_N = (short)(Convert.ToInt16(n1009WalletBalancesObs));
         obj93.gxTpr_Walletbalancesconcepto_N = (short)(Convert.ToInt16(n1010WalletBalancesConcepto));
         obj93.gxTpr_Walletbalancesurl_N = (short)(Convert.ToInt16(n1011WalletBalancesUrl));
         obj93.gxTpr_Walletbalanceliquidacion_N = (short)(Convert.ToInt16(n1012WalletBalanceLiquidacion));
         obj93.gxTpr_Modified = nIsMod_93;
         return  ;
      }

      public void KeyVarsToRow93( SdtWallet_Balances obj93 )
      {
         obj93.gxTpr_Walletbalancesid = A640WalletBalancesId;
         return  ;
      }

      public void RowToVars93( SdtWallet_Balances obj93 ,
                               int forceLoad )
      {
         Gx_mode = obj93.gxTpr_Mode;
         A641WalletBalancesFechaAlta = obj93.gxTpr_Walletbalancesfechaalta;
         A642WalletBalancesUsrAlta = obj93.gxTpr_Walletbalancesusralta;
         A643WalletBalancesTipoMov = obj93.gxTpr_Walletbalancestipomov;
         A644WalletBalancesImporte = obj93.gxTpr_Walletbalancesimporte;
         A1009WalletBalancesObs = obj93.gxTpr_Walletbalancesobs;
         n1009WalletBalancesObs = false;
         A1010WalletBalancesConcepto = obj93.gxTpr_Walletbalancesconcepto;
         n1010WalletBalancesConcepto = false;
         A1011WalletBalancesUrl = obj93.gxTpr_Walletbalancesurl;
         n1011WalletBalancesUrl = false;
         A645WalletBalancesEstadoOPE = obj93.gxTpr_Walletbalancesestadoope;
         A1012WalletBalanceLiquidacion = obj93.gxTpr_Walletbalanceliquidacion;
         n1012WalletBalanceLiquidacion = false;
         A640WalletBalancesId = obj93.gxTpr_Walletbalancesid;
         Z640WalletBalancesId = obj93.gxTpr_Walletbalancesid_Z;
         Z641WalletBalancesFechaAlta = obj93.gxTpr_Walletbalancesfechaalta_Z;
         Z642WalletBalancesUsrAlta = obj93.gxTpr_Walletbalancesusralta_Z;
         Z643WalletBalancesTipoMov = obj93.gxTpr_Walletbalancestipomov_Z;
         Z644WalletBalancesImporte = obj93.gxTpr_Walletbalancesimporte_Z;
         Z1009WalletBalancesObs = obj93.gxTpr_Walletbalancesobs_Z;
         Z1010WalletBalancesConcepto = obj93.gxTpr_Walletbalancesconcepto_Z;
         Z1011WalletBalancesUrl = obj93.gxTpr_Walletbalancesurl_Z;
         Z645WalletBalancesEstadoOPE = obj93.gxTpr_Walletbalancesestadoope_Z;
         Z1012WalletBalanceLiquidacion = obj93.gxTpr_Walletbalanceliquidacion_Z;
         n1009WalletBalancesObs = (bool)(Convert.ToBoolean(obj93.gxTpr_Walletbalancesobs_N));
         n1010WalletBalancesConcepto = (bool)(Convert.ToBoolean(obj93.gxTpr_Walletbalancesconcepto_N));
         n1011WalletBalancesUrl = (bool)(Convert.ToBoolean(obj93.gxTpr_Walletbalancesurl_N));
         n1012WalletBalanceLiquidacion = (bool)(Convert.ToBoolean(obj93.gxTpr_Walletbalanceliquidacion_N));
         nIsMod_93 = obj93.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A637WalletId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2992( ) ;
         ScanKeyStart2992( ) ;
         if ( RcdFound92 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z637WalletId = A637WalletId;
         }
         ZM2992( -16) ;
         OnLoadActions2992( ) ;
         AddRow2992( ) ;
         bcWallet.gxTpr_Balances.ClearCollection();
         if ( RcdFound92 == 1 )
         {
            ScanKeyStart2993( ) ;
            nGXsfl_93_idx = 1;
            while ( RcdFound93 != 0 )
            {
               Z637WalletId = A637WalletId;
               Z640WalletBalancesId = A640WalletBalancesId;
               ZM2993( -20) ;
               OnLoadActions2993( ) ;
               nRcdExists_93 = 1;
               nIsMod_93 = 0;
               AddRow2993( ) ;
               nGXsfl_93_idx = (int)(nGXsfl_93_idx+1);
               ScanKeyNext2993( ) ;
            }
            ScanKeyEnd2993( ) ;
         }
         ScanKeyEnd2992( ) ;
         if ( RcdFound92 == 0 )
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
         RowToVars92( bcWallet, 0) ;
         ScanKeyStart2992( ) ;
         if ( RcdFound92 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z637WalletId = A637WalletId;
         }
         ZM2992( -16) ;
         OnLoadActions2992( ) ;
         AddRow2992( ) ;
         bcWallet.gxTpr_Balances.ClearCollection();
         if ( RcdFound92 == 1 )
         {
            ScanKeyStart2993( ) ;
            nGXsfl_93_idx = 1;
            while ( RcdFound93 != 0 )
            {
               Z637WalletId = A637WalletId;
               Z640WalletBalancesId = A640WalletBalancesId;
               ZM2993( -20) ;
               OnLoadActions2993( ) ;
               nRcdExists_93 = 1;
               nIsMod_93 = 0;
               AddRow2993( ) ;
               nGXsfl_93_idx = (int)(nGXsfl_93_idx+1);
               ScanKeyNext2993( ) ;
            }
            ScanKeyEnd2993( ) ;
         }
         ScanKeyEnd2992( ) ;
         if ( RcdFound92 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2992( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2992( ) ;
         }
         else
         {
            if ( RcdFound92 == 1 )
            {
               if ( A637WalletId != Z637WalletId )
               {
                  A637WalletId = Z637WalletId;
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
                  Update2992( ) ;
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
                  if ( A637WalletId != Z637WalletId )
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
                        Insert2992( ) ;
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
                        Insert2992( ) ;
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
         RowToVars92( bcWallet, 1) ;
         SaveImpl( ) ;
         VarsToRow92( bcWallet) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars92( bcWallet, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2992( ) ;
         AfterTrn( ) ;
         VarsToRow92( bcWallet) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow92( bcWallet) ;
         }
         else
         {
            SdtWallet auxBC = new SdtWallet(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A637WalletId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcWallet);
               auxBC.Save();
               bcWallet.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars92( bcWallet, 1) ;
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
         RowToVars92( bcWallet, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2992( ) ;
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
               VarsToRow92( bcWallet) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow92( bcWallet) ;
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
         RowToVars92( bcWallet, 0) ;
         GetKey2992( ) ;
         if ( RcdFound92 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A637WalletId != Z637WalletId )
            {
               A637WalletId = Z637WalletId;
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
            if ( A637WalletId != Z637WalletId )
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
         pr_default.close(12);
         pr_default.close(13);
         context.RollbackDataStores("wallet_bc",pr_default);
         VarsToRow92( bcWallet) ;
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
         Gx_mode = bcWallet.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcWallet.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcWallet )
         {
            bcWallet = (SdtWallet)(sdt);
            if ( StringUtil.StrCmp(bcWallet.gxTpr_Mode, "") == 0 )
            {
               bcWallet.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow92( bcWallet) ;
            }
            else
            {
               RowToVars92( bcWallet, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcWallet.gxTpr_Mode, "") == 0 )
            {
               bcWallet.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars92( bcWallet, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWallet Wallet_BC
      {
         get {
            return bcWallet ;
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
         pr_default.close(12);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode92 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV18Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z638WalletTipoEntidad = "";
         A638WalletTipoEntidad = "";
         Z639WalletCodRefencia = "";
         A639WalletCodRefencia = "";
         Z665WalletEstado = "";
         A665WalletEstado = "";
         Z715WalletNombre = "";
         A715WalletNombre = "";
         Z636TipoCuentaConcepto = "";
         A636TipoCuentaConcepto = "";
         Z484TipoCuentaNombre = "";
         A484TipoCuentaNombre = "";
         Z119MonedaISOSimbolo = "";
         A119MonedaISOSimbolo = "";
         BC00298_A637WalletId = new long[1] ;
         BC00298_A636TipoCuentaConcepto = new string[] {""} ;
         BC00298_A484TipoCuentaNombre = new string[] {""} ;
         BC00298_A638WalletTipoEntidad = new string[] {""} ;
         BC00298_A639WalletCodRefencia = new string[] {""} ;
         BC00298_A119MonedaISOSimbolo = new string[] {""} ;
         BC00298_A665WalletEstado = new string[] {""} ;
         BC00298_A483TipoCuentaId = new long[1] ;
         BC00298_A118MonedaId = new short[1] ;
         BC00298_n118MonedaId = new bool[] {false} ;
         BC00299_A639WalletCodRefencia = new string[] {""} ;
         BC00296_A636TipoCuentaConcepto = new string[] {""} ;
         BC00296_A484TipoCuentaNombre = new string[] {""} ;
         BC00297_A119MonedaISOSimbolo = new string[] {""} ;
         BC002910_A637WalletId = new long[1] ;
         BC00295_A637WalletId = new long[1] ;
         BC00295_A638WalletTipoEntidad = new string[] {""} ;
         BC00295_A639WalletCodRefencia = new string[] {""} ;
         BC00295_A665WalletEstado = new string[] {""} ;
         BC00295_A483TipoCuentaId = new long[1] ;
         BC00295_A118MonedaId = new short[1] ;
         BC00295_n118MonedaId = new bool[] {false} ;
         BC00294_A637WalletId = new long[1] ;
         BC00294_A638WalletTipoEntidad = new string[] {""} ;
         BC00294_A639WalletCodRefencia = new string[] {""} ;
         BC00294_A665WalletEstado = new string[] {""} ;
         BC00294_A483TipoCuentaId = new long[1] ;
         BC00294_A118MonedaId = new short[1] ;
         BC00294_n118MonedaId = new bool[] {false} ;
         BC002911_A637WalletId = new long[1] ;
         BC002914_A636TipoCuentaConcepto = new string[] {""} ;
         BC002914_A484TipoCuentaNombre = new string[] {""} ;
         GXt_char3 = "";
         BC002915_A119MonedaISOSimbolo = new string[] {""} ;
         BC002916_A637WalletId = new long[1] ;
         BC002916_A636TipoCuentaConcepto = new string[] {""} ;
         BC002916_A484TipoCuentaNombre = new string[] {""} ;
         BC002916_A638WalletTipoEntidad = new string[] {""} ;
         BC002916_A639WalletCodRefencia = new string[] {""} ;
         BC002916_A119MonedaISOSimbolo = new string[] {""} ;
         BC002916_A665WalletEstado = new string[] {""} ;
         BC002916_A483TipoCuentaId = new long[1] ;
         BC002916_A118MonedaId = new short[1] ;
         BC002916_n118MonedaId = new bool[] {false} ;
         Z641WalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
         A641WalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
         Z643WalletBalancesTipoMov = "";
         A643WalletBalancesTipoMov = "";
         Z1009WalletBalancesObs = "";
         A1009WalletBalancesObs = "";
         Z1011WalletBalancesUrl = "";
         A1011WalletBalancesUrl = "";
         Z645WalletBalancesEstadoOPE = "";
         A645WalletBalancesEstadoOPE = "";
         BC002917_A637WalletId = new long[1] ;
         BC002917_A640WalletBalancesId = new long[1] ;
         BC002917_A641WalletBalancesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC002917_A642WalletBalancesUsrAlta = new long[1] ;
         BC002917_A643WalletBalancesTipoMov = new string[] {""} ;
         BC002917_A644WalletBalancesImporte = new decimal[1] ;
         BC002917_A1009WalletBalancesObs = new string[] {""} ;
         BC002917_n1009WalletBalancesObs = new bool[] {false} ;
         BC002917_A1010WalletBalancesConcepto = new short[1] ;
         BC002917_n1010WalletBalancesConcepto = new bool[] {false} ;
         BC002917_A1011WalletBalancesUrl = new string[] {""} ;
         BC002917_n1011WalletBalancesUrl = new bool[] {false} ;
         BC002917_A645WalletBalancesEstadoOPE = new string[] {""} ;
         BC002917_A1012WalletBalanceLiquidacion = new long[1] ;
         BC002917_n1012WalletBalanceLiquidacion = new bool[] {false} ;
         BC002918_A637WalletId = new long[1] ;
         BC002918_A640WalletBalancesId = new long[1] ;
         BC00293_A637WalletId = new long[1] ;
         BC00293_A640WalletBalancesId = new long[1] ;
         BC00293_A641WalletBalancesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC00293_A642WalletBalancesUsrAlta = new long[1] ;
         BC00293_A643WalletBalancesTipoMov = new string[] {""} ;
         BC00293_A644WalletBalancesImporte = new decimal[1] ;
         BC00293_A1009WalletBalancesObs = new string[] {""} ;
         BC00293_n1009WalletBalancesObs = new bool[] {false} ;
         BC00293_A1010WalletBalancesConcepto = new short[1] ;
         BC00293_n1010WalletBalancesConcepto = new bool[] {false} ;
         BC00293_A1011WalletBalancesUrl = new string[] {""} ;
         BC00293_n1011WalletBalancesUrl = new bool[] {false} ;
         BC00293_A645WalletBalancesEstadoOPE = new string[] {""} ;
         BC00293_A1012WalletBalanceLiquidacion = new long[1] ;
         BC00293_n1012WalletBalanceLiquidacion = new bool[] {false} ;
         sMode93 = "";
         BC00292_A637WalletId = new long[1] ;
         BC00292_A640WalletBalancesId = new long[1] ;
         BC00292_A641WalletBalancesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC00292_A642WalletBalancesUsrAlta = new long[1] ;
         BC00292_A643WalletBalancesTipoMov = new string[] {""} ;
         BC00292_A644WalletBalancesImporte = new decimal[1] ;
         BC00292_A1009WalletBalancesObs = new string[] {""} ;
         BC00292_n1009WalletBalancesObs = new bool[] {false} ;
         BC00292_A1010WalletBalancesConcepto = new short[1] ;
         BC00292_n1010WalletBalancesConcepto = new bool[] {false} ;
         BC00292_A1011WalletBalancesUrl = new string[] {""} ;
         BC00292_n1011WalletBalancesUrl = new bool[] {false} ;
         BC00292_A645WalletBalancesEstadoOPE = new string[] {""} ;
         BC00292_A1012WalletBalanceLiquidacion = new long[1] ;
         BC00292_n1012WalletBalanceLiquidacion = new bool[] {false} ;
         BC002922_A637WalletId = new long[1] ;
         BC002922_A640WalletBalancesId = new long[1] ;
         BC002922_A641WalletBalancesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC002922_A642WalletBalancesUsrAlta = new long[1] ;
         BC002922_A643WalletBalancesTipoMov = new string[] {""} ;
         BC002922_A644WalletBalancesImporte = new decimal[1] ;
         BC002922_A1009WalletBalancesObs = new string[] {""} ;
         BC002922_n1009WalletBalancesObs = new bool[] {false} ;
         BC002922_A1010WalletBalancesConcepto = new short[1] ;
         BC002922_n1010WalletBalancesConcepto = new bool[] {false} ;
         BC002922_A1011WalletBalancesUrl = new string[] {""} ;
         BC002922_n1011WalletBalancesUrl = new bool[] {false} ;
         BC002922_A645WalletBalancesEstadoOPE = new string[] {""} ;
         BC002922_A1012WalletBalanceLiquidacion = new long[1] ;
         BC002922_n1012WalletBalanceLiquidacion = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wallet_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wallet_bc__default(),
            new Object[][] {
                new Object[] {
               BC00292_A637WalletId, BC00292_A640WalletBalancesId, BC00292_A641WalletBalancesFechaAlta, BC00292_A642WalletBalancesUsrAlta, BC00292_A643WalletBalancesTipoMov, BC00292_A644WalletBalancesImporte, BC00292_A1009WalletBalancesObs, BC00292_n1009WalletBalancesObs, BC00292_A1010WalletBalancesConcepto, BC00292_n1010WalletBalancesConcepto,
               BC00292_A1011WalletBalancesUrl, BC00292_n1011WalletBalancesUrl, BC00292_A645WalletBalancesEstadoOPE, BC00292_A1012WalletBalanceLiquidacion, BC00292_n1012WalletBalanceLiquidacion
               }
               , new Object[] {
               BC00293_A637WalletId, BC00293_A640WalletBalancesId, BC00293_A641WalletBalancesFechaAlta, BC00293_A642WalletBalancesUsrAlta, BC00293_A643WalletBalancesTipoMov, BC00293_A644WalletBalancesImporte, BC00293_A1009WalletBalancesObs, BC00293_n1009WalletBalancesObs, BC00293_A1010WalletBalancesConcepto, BC00293_n1010WalletBalancesConcepto,
               BC00293_A1011WalletBalancesUrl, BC00293_n1011WalletBalancesUrl, BC00293_A645WalletBalancesEstadoOPE, BC00293_A1012WalletBalanceLiquidacion, BC00293_n1012WalletBalanceLiquidacion
               }
               , new Object[] {
               BC00294_A637WalletId, BC00294_A638WalletTipoEntidad, BC00294_A639WalletCodRefencia, BC00294_A665WalletEstado, BC00294_A483TipoCuentaId, BC00294_A118MonedaId, BC00294_n118MonedaId
               }
               , new Object[] {
               BC00295_A637WalletId, BC00295_A638WalletTipoEntidad, BC00295_A639WalletCodRefencia, BC00295_A665WalletEstado, BC00295_A483TipoCuentaId, BC00295_A118MonedaId, BC00295_n118MonedaId
               }
               , new Object[] {
               BC00296_A636TipoCuentaConcepto, BC00296_A484TipoCuentaNombre
               }
               , new Object[] {
               BC00297_A119MonedaISOSimbolo
               }
               , new Object[] {
               BC00298_A637WalletId, BC00298_A636TipoCuentaConcepto, BC00298_A484TipoCuentaNombre, BC00298_A638WalletTipoEntidad, BC00298_A639WalletCodRefencia, BC00298_A119MonedaISOSimbolo, BC00298_A665WalletEstado, BC00298_A483TipoCuentaId, BC00298_A118MonedaId, BC00298_n118MonedaId
               }
               , new Object[] {
               BC00299_A639WalletCodRefencia
               }
               , new Object[] {
               BC002910_A637WalletId
               }
               , new Object[] {
               BC002911_A637WalletId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002914_A636TipoCuentaConcepto, BC002914_A484TipoCuentaNombre
               }
               , new Object[] {
               BC002915_A119MonedaISOSimbolo
               }
               , new Object[] {
               BC002916_A637WalletId, BC002916_A636TipoCuentaConcepto, BC002916_A484TipoCuentaNombre, BC002916_A638WalletTipoEntidad, BC002916_A639WalletCodRefencia, BC002916_A119MonedaISOSimbolo, BC002916_A665WalletEstado, BC002916_A483TipoCuentaId, BC002916_A118MonedaId, BC002916_n118MonedaId
               }
               , new Object[] {
               BC002917_A637WalletId, BC002917_A640WalletBalancesId, BC002917_A641WalletBalancesFechaAlta, BC002917_A642WalletBalancesUsrAlta, BC002917_A643WalletBalancesTipoMov, BC002917_A644WalletBalancesImporte, BC002917_A1009WalletBalancesObs, BC002917_n1009WalletBalancesObs, BC002917_A1010WalletBalancesConcepto, BC002917_n1010WalletBalancesConcepto,
               BC002917_A1011WalletBalancesUrl, BC002917_n1011WalletBalancesUrl, BC002917_A645WalletBalancesEstadoOPE, BC002917_A1012WalletBalanceLiquidacion, BC002917_n1012WalletBalanceLiquidacion
               }
               , new Object[] {
               BC002918_A637WalletId, BC002918_A640WalletBalancesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002922_A637WalletId, BC002922_A640WalletBalancesId, BC002922_A641WalletBalancesFechaAlta, BC002922_A642WalletBalancesUsrAlta, BC002922_A643WalletBalancesTipoMov, BC002922_A644WalletBalancesImporte, BC002922_A1009WalletBalancesObs, BC002922_n1009WalletBalancesObs, BC002922_A1010WalletBalancesConcepto, BC002922_n1010WalletBalancesConcepto,
               BC002922_A1011WalletBalancesUrl, BC002922_n1011WalletBalancesUrl, BC002922_A645WalletBalancesEstadoOPE, BC002922_A1012WalletBalanceLiquidacion, BC002922_n1012WalletBalanceLiquidacion
               }
            }
         );
         AV18Pgmname = "Wallet_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12292 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_93 ;
      private short RcdFound93 ;
      private short AV14Insert_MonedaId ;
      private short Z118MonedaId ;
      private short A118MonedaId ;
      private short RcdFound92 ;
      private short nRcdExists_93 ;
      private short Z1010WalletBalancesConcepto ;
      private short A1010WalletBalancesConcepto ;
      private short Gx_BScreen ;
      private short Gxremove93 ;
      private int trnEnded ;
      private int nGXsfl_93_idx=1 ;
      private int AV19GXV1 ;
      private long Z637WalletId ;
      private long A637WalletId ;
      private long AV13Insert_TipoCuentaId ;
      private long Z483TipoCuentaId ;
      private long A483TipoCuentaId ;
      private long Z642WalletBalancesUsrAlta ;
      private long A642WalletBalancesUsrAlta ;
      private long Z1012WalletBalanceLiquidacion ;
      private long A1012WalletBalanceLiquidacion ;
      private long Z640WalletBalancesId ;
      private long A640WalletBalancesId ;
      private decimal Z646WalletTotalDebito ;
      private decimal A646WalletTotalDebito ;
      private decimal Z647WalletTotalCredito ;
      private decimal A647WalletTotalCredito ;
      private decimal Z648WalletSaldo ;
      private decimal A648WalletSaldo ;
      private decimal Z1007WalletSolicitudesPendientes ;
      private decimal A1007WalletSolicitudesPendientes ;
      private decimal Z1008WalletSaldoAlDia ;
      private decimal A1008WalletSaldoAlDia ;
      private decimal GXt_decimal2 ;
      private decimal Z644WalletBalancesImporte ;
      private decimal A644WalletBalancesImporte ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode92 ;
      private string AV18Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Z638WalletTipoEntidad ;
      private string A638WalletTipoEntidad ;
      private string Z639WalletCodRefencia ;
      private string A639WalletCodRefencia ;
      private string Z665WalletEstado ;
      private string A665WalletEstado ;
      private string Z715WalletNombre ;
      private string A715WalletNombre ;
      private string Z636TipoCuentaConcepto ;
      private string A636TipoCuentaConcepto ;
      private string Z484TipoCuentaNombre ;
      private string A484TipoCuentaNombre ;
      private string Z119MonedaISOSimbolo ;
      private string A119MonedaISOSimbolo ;
      private string GXt_char3 ;
      private string Z643WalletBalancesTipoMov ;
      private string A643WalletBalancesTipoMov ;
      private string Z645WalletBalancesEstadoOPE ;
      private string A645WalletBalancesEstadoOPE ;
      private string sMode93 ;
      private DateTime Z641WalletBalancesFechaAlta ;
      private DateTime A641WalletBalancesFechaAlta ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool n118MonedaId ;
      private bool n1009WalletBalancesObs ;
      private bool n1010WalletBalancesConcepto ;
      private bool n1011WalletBalancesUrl ;
      private bool n1012WalletBalanceLiquidacion ;
      private bool Gx_longc ;
      private string Z1009WalletBalancesObs ;
      private string A1009WalletBalancesObs ;
      private string Z1011WalletBalancesUrl ;
      private string A1011WalletBalancesUrl ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtWallet bcWallet ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private long[] BC00298_A637WalletId ;
      private string[] BC00298_A636TipoCuentaConcepto ;
      private string[] BC00298_A484TipoCuentaNombre ;
      private string[] BC00298_A638WalletTipoEntidad ;
      private string[] BC00298_A639WalletCodRefencia ;
      private string[] BC00298_A119MonedaISOSimbolo ;
      private string[] BC00298_A665WalletEstado ;
      private long[] BC00298_A483TipoCuentaId ;
      private short[] BC00298_A118MonedaId ;
      private bool[] BC00298_n118MonedaId ;
      private string[] BC00299_A639WalletCodRefencia ;
      private string[] BC00296_A636TipoCuentaConcepto ;
      private string[] BC00296_A484TipoCuentaNombre ;
      private string[] BC00297_A119MonedaISOSimbolo ;
      private long[] BC002910_A637WalletId ;
      private long[] BC00295_A637WalletId ;
      private string[] BC00295_A638WalletTipoEntidad ;
      private string[] BC00295_A639WalletCodRefencia ;
      private string[] BC00295_A665WalletEstado ;
      private long[] BC00295_A483TipoCuentaId ;
      private short[] BC00295_A118MonedaId ;
      private bool[] BC00295_n118MonedaId ;
      private long[] BC00294_A637WalletId ;
      private string[] BC00294_A638WalletTipoEntidad ;
      private string[] BC00294_A639WalletCodRefencia ;
      private string[] BC00294_A665WalletEstado ;
      private long[] BC00294_A483TipoCuentaId ;
      private short[] BC00294_A118MonedaId ;
      private bool[] BC00294_n118MonedaId ;
      private long[] BC002911_A637WalletId ;
      private string[] BC002914_A636TipoCuentaConcepto ;
      private string[] BC002914_A484TipoCuentaNombre ;
      private string[] BC002915_A119MonedaISOSimbolo ;
      private long[] BC002916_A637WalletId ;
      private string[] BC002916_A636TipoCuentaConcepto ;
      private string[] BC002916_A484TipoCuentaNombre ;
      private string[] BC002916_A638WalletTipoEntidad ;
      private string[] BC002916_A639WalletCodRefencia ;
      private string[] BC002916_A119MonedaISOSimbolo ;
      private string[] BC002916_A665WalletEstado ;
      private long[] BC002916_A483TipoCuentaId ;
      private short[] BC002916_A118MonedaId ;
      private bool[] BC002916_n118MonedaId ;
      private long[] BC002917_A637WalletId ;
      private long[] BC002917_A640WalletBalancesId ;
      private DateTime[] BC002917_A641WalletBalancesFechaAlta ;
      private long[] BC002917_A642WalletBalancesUsrAlta ;
      private string[] BC002917_A643WalletBalancesTipoMov ;
      private decimal[] BC002917_A644WalletBalancesImporte ;
      private string[] BC002917_A1009WalletBalancesObs ;
      private bool[] BC002917_n1009WalletBalancesObs ;
      private short[] BC002917_A1010WalletBalancesConcepto ;
      private bool[] BC002917_n1010WalletBalancesConcepto ;
      private string[] BC002917_A1011WalletBalancesUrl ;
      private bool[] BC002917_n1011WalletBalancesUrl ;
      private string[] BC002917_A645WalletBalancesEstadoOPE ;
      private long[] BC002917_A1012WalletBalanceLiquidacion ;
      private bool[] BC002917_n1012WalletBalanceLiquidacion ;
      private long[] BC002918_A637WalletId ;
      private long[] BC002918_A640WalletBalancesId ;
      private long[] BC00293_A637WalletId ;
      private long[] BC00293_A640WalletBalancesId ;
      private DateTime[] BC00293_A641WalletBalancesFechaAlta ;
      private long[] BC00293_A642WalletBalancesUsrAlta ;
      private string[] BC00293_A643WalletBalancesTipoMov ;
      private decimal[] BC00293_A644WalletBalancesImporte ;
      private string[] BC00293_A1009WalletBalancesObs ;
      private bool[] BC00293_n1009WalletBalancesObs ;
      private short[] BC00293_A1010WalletBalancesConcepto ;
      private bool[] BC00293_n1010WalletBalancesConcepto ;
      private string[] BC00293_A1011WalletBalancesUrl ;
      private bool[] BC00293_n1011WalletBalancesUrl ;
      private string[] BC00293_A645WalletBalancesEstadoOPE ;
      private long[] BC00293_A1012WalletBalanceLiquidacion ;
      private bool[] BC00293_n1012WalletBalanceLiquidacion ;
      private long[] BC00292_A637WalletId ;
      private long[] BC00292_A640WalletBalancesId ;
      private DateTime[] BC00292_A641WalletBalancesFechaAlta ;
      private long[] BC00292_A642WalletBalancesUsrAlta ;
      private string[] BC00292_A643WalletBalancesTipoMov ;
      private decimal[] BC00292_A644WalletBalancesImporte ;
      private string[] BC00292_A1009WalletBalancesObs ;
      private bool[] BC00292_n1009WalletBalancesObs ;
      private short[] BC00292_A1010WalletBalancesConcepto ;
      private bool[] BC00292_n1010WalletBalancesConcepto ;
      private string[] BC00292_A1011WalletBalancesUrl ;
      private bool[] BC00292_n1011WalletBalancesUrl ;
      private string[] BC00292_A645WalletBalancesEstadoOPE ;
      private long[] BC00292_A1012WalletBalanceLiquidacion ;
      private bool[] BC00292_n1012WalletBalanceLiquidacion ;
      private long[] BC002922_A637WalletId ;
      private long[] BC002922_A640WalletBalancesId ;
      private DateTime[] BC002922_A641WalletBalancesFechaAlta ;
      private long[] BC002922_A642WalletBalancesUsrAlta ;
      private string[] BC002922_A643WalletBalancesTipoMov ;
      private decimal[] BC002922_A644WalletBalancesImporte ;
      private string[] BC002922_A1009WalletBalancesObs ;
      private bool[] BC002922_n1009WalletBalancesObs ;
      private short[] BC002922_A1010WalletBalancesConcepto ;
      private bool[] BC002922_n1010WalletBalancesConcepto ;
      private string[] BC002922_A1011WalletBalancesUrl ;
      private bool[] BC002922_n1011WalletBalancesUrl ;
      private string[] BC002922_A645WalletBalancesEstadoOPE ;
      private long[] BC002922_A1012WalletBalanceLiquidacion ;
      private bool[] BC002922_n1012WalletBalanceLiquidacion ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wallet_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wallet_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new ForEachCursor(def[20])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00292;
        prmBC00292 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0)
        };
        Object[] prmBC00293;
        prmBC00293 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0)
        };
        Object[] prmBC00294;
        prmBC00294 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmBC00295;
        prmBC00295 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmBC00296;
        prmBC00296 = new Object[] {
        new ParDef("@TipoCuentaId",GXType.Decimal,18,0)
        };
        Object[] prmBC00297;
        prmBC00297 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmBC00298;
        prmBC00298 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmBC00299;
        prmBC00299 = new Object[] {
        new ParDef("@WalletCodRefencia",GXType.NChar,25,0) ,
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmBC002910;
        prmBC002910 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmBC002911;
        prmBC002911 = new Object[] {
        new ParDef("@WalletTipoEntidad",GXType.NChar,3,0) ,
        new ParDef("@WalletCodRefencia",GXType.NChar,25,0) ,
        new ParDef("@WalletEstado",GXType.NChar,3,0) ,
        new ParDef("@TipoCuentaId",GXType.Decimal,18,0) ,
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmBC002912;
        prmBC002912 = new Object[] {
        new ParDef("@WalletTipoEntidad",GXType.NChar,3,0) ,
        new ParDef("@WalletCodRefencia",GXType.NChar,25,0) ,
        new ParDef("@WalletEstado",GXType.NChar,3,0) ,
        new ParDef("@TipoCuentaId",GXType.Decimal,18,0) ,
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmBC002913;
        prmBC002913 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmBC002914;
        prmBC002914 = new Object[] {
        new ParDef("@TipoCuentaId",GXType.Decimal,18,0)
        };
        Object[] prmBC002915;
        prmBC002915 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmBC002916;
        prmBC002916 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        Object[] prmBC002917;
        prmBC002917 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0)
        };
        Object[] prmBC002918;
        prmBC002918 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0)
        };
        Object[] prmBC002919;
        prmBC002919 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@WalletBalancesUsrAlta",GXType.Decimal,10,0) ,
        new ParDef("@WalletBalancesTipoMov",GXType.NChar,3,0) ,
        new ParDef("@WalletBalancesImporte",GXType.Decimal,18,2) ,
        new ParDef("@WalletBalancesObs",GXType.NVarChar,120,0){Nullable=true} ,
        new ParDef("@WalletBalancesConcepto",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@WalletBalancesUrl",GXType.NVarChar,1000,0){Nullable=true} ,
        new ParDef("@WalletBalancesEstadoOPE",GXType.NChar,3,0) ,
        new ParDef("@WalletBalanceLiquidacion",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC002920;
        prmBC002920 = new Object[] {
        new ParDef("@WalletBalancesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@WalletBalancesUsrAlta",GXType.Decimal,10,0) ,
        new ParDef("@WalletBalancesTipoMov",GXType.NChar,3,0) ,
        new ParDef("@WalletBalancesImporte",GXType.Decimal,18,2) ,
        new ParDef("@WalletBalancesObs",GXType.NVarChar,120,0){Nullable=true} ,
        new ParDef("@WalletBalancesConcepto",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@WalletBalancesUrl",GXType.NVarChar,1000,0){Nullable=true} ,
        new ParDef("@WalletBalancesEstadoOPE",GXType.NChar,3,0) ,
        new ParDef("@WalletBalanceLiquidacion",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0)
        };
        Object[] prmBC002921;
        prmBC002921 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0)
        };
        Object[] prmBC002922;
        prmBC002922 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00292", "SELECT [WalletId], [WalletBalancesId], [WalletBalancesFechaAlta], [WalletBalancesUsrAlta], [WalletBalancesTipoMov], [WalletBalancesImporte], [WalletBalancesObs], [WalletBalancesConcepto], [WalletBalancesUrl], [WalletBalancesEstadoOPE], [WalletBalanceLiquidacion] FROM [WalletBalances] WITH (UPDLOCK) WHERE [WalletId] = @WalletId AND [WalletBalancesId] = @WalletBalancesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00292,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00293", "SELECT [WalletId], [WalletBalancesId], [WalletBalancesFechaAlta], [WalletBalancesUsrAlta], [WalletBalancesTipoMov], [WalletBalancesImporte], [WalletBalancesObs], [WalletBalancesConcepto], [WalletBalancesUrl], [WalletBalancesEstadoOPE], [WalletBalanceLiquidacion] FROM [WalletBalances] WHERE [WalletId] = @WalletId AND [WalletBalancesId] = @WalletBalancesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00293,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00294", "SELECT [WalletId], [WalletTipoEntidad], [WalletCodRefencia], [WalletEstado], [TipoCuentaId], [MonedaId] FROM [Wallet] WITH (UPDLOCK) WHERE [WalletId] = @WalletId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00294,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00295", "SELECT [WalletId], [WalletTipoEntidad], [WalletCodRefencia], [WalletEstado], [TipoCuentaId], [MonedaId] FROM [Wallet] WHERE [WalletId] = @WalletId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00295,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00296", "SELECT [TipoCuentaConcepto], [TipoCuentaNombre] FROM [TipoCuenta] WHERE [TipoCuentaId] = @TipoCuentaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00296,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00297", "SELECT [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00297,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00298", "SELECT TM1.[WalletId], T2.[TipoCuentaConcepto], T2.[TipoCuentaNombre], TM1.[WalletTipoEntidad], TM1.[WalletCodRefencia], T3.[MonedaISOSimbolo], TM1.[WalletEstado], TM1.[TipoCuentaId], TM1.[MonedaId] FROM (([Wallet] TM1 INNER JOIN [TipoCuenta] T2 ON T2.[TipoCuentaId] = TM1.[TipoCuentaId]) LEFT JOIN [Moneda] T3 ON T3.[MonedaId] = TM1.[MonedaId]) WHERE TM1.[WalletId] = @WalletId ORDER BY TM1.[WalletId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00298,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00299", "SELECT [WalletCodRefencia] FROM [Wallet] WHERE ([WalletCodRefencia] = @WalletCodRefencia) AND (Not ( [WalletId] = @WalletId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00299,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002910", "SELECT [WalletId] FROM [Wallet] WHERE [WalletId] = @WalletId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002910,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002911", "INSERT INTO [Wallet]([WalletTipoEntidad], [WalletCodRefencia], [WalletEstado], [TipoCuentaId], [MonedaId]) VALUES(@WalletTipoEntidad, @WalletCodRefencia, @WalletEstado, @TipoCuentaId, @MonedaId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC002911,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC002912", "UPDATE [Wallet] SET [WalletTipoEntidad]=@WalletTipoEntidad, [WalletCodRefencia]=@WalletCodRefencia, [WalletEstado]=@WalletEstado, [TipoCuentaId]=@TipoCuentaId, [MonedaId]=@MonedaId  WHERE [WalletId] = @WalletId", GxErrorMask.GX_NOMASK,prmBC002912)
           ,new CursorDef("BC002913", "DELETE FROM [Wallet]  WHERE [WalletId] = @WalletId", GxErrorMask.GX_NOMASK,prmBC002913)
           ,new CursorDef("BC002914", "SELECT [TipoCuentaConcepto], [TipoCuentaNombre] FROM [TipoCuenta] WHERE [TipoCuentaId] = @TipoCuentaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002914,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002915", "SELECT [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002915,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002916", "SELECT TM1.[WalletId], T2.[TipoCuentaConcepto], T2.[TipoCuentaNombre], TM1.[WalletTipoEntidad], TM1.[WalletCodRefencia], T3.[MonedaISOSimbolo], TM1.[WalletEstado], TM1.[TipoCuentaId], TM1.[MonedaId] FROM (([Wallet] TM1 INNER JOIN [TipoCuenta] T2 ON T2.[TipoCuentaId] = TM1.[TipoCuentaId]) LEFT JOIN [Moneda] T3 ON T3.[MonedaId] = TM1.[MonedaId]) WHERE TM1.[WalletId] = @WalletId ORDER BY TM1.[WalletId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002916,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002917", "SELECT [WalletId], [WalletBalancesId], [WalletBalancesFechaAlta], [WalletBalancesUsrAlta], [WalletBalancesTipoMov], [WalletBalancesImporte], [WalletBalancesObs], [WalletBalancesConcepto], [WalletBalancesUrl], [WalletBalancesEstadoOPE], [WalletBalanceLiquidacion] FROM [WalletBalances] WHERE [WalletId] = @WalletId and [WalletBalancesId] = @WalletBalancesId ORDER BY [WalletId], [WalletBalancesId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002917,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002918", "SELECT [WalletId], [WalletBalancesId] FROM [WalletBalances] WHERE [WalletId] = @WalletId AND [WalletBalancesId] = @WalletBalancesId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002918,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002919", "INSERT INTO [WalletBalances]([WalletId], [WalletBalancesId], [WalletBalancesFechaAlta], [WalletBalancesUsrAlta], [WalletBalancesTipoMov], [WalletBalancesImporte], [WalletBalancesObs], [WalletBalancesConcepto], [WalletBalancesUrl], [WalletBalancesEstadoOPE], [WalletBalanceLiquidacion]) VALUES(@WalletId, @WalletBalancesId, @WalletBalancesFechaAlta, @WalletBalancesUsrAlta, @WalletBalancesTipoMov, @WalletBalancesImporte, @WalletBalancesObs, @WalletBalancesConcepto, @WalletBalancesUrl, @WalletBalancesEstadoOPE, @WalletBalanceLiquidacion)", GxErrorMask.GX_NOMASK,prmBC002919)
           ,new CursorDef("BC002920", "UPDATE [WalletBalances] SET [WalletBalancesFechaAlta]=@WalletBalancesFechaAlta, [WalletBalancesUsrAlta]=@WalletBalancesUsrAlta, [WalletBalancesTipoMov]=@WalletBalancesTipoMov, [WalletBalancesImporte]=@WalletBalancesImporte, [WalletBalancesObs]=@WalletBalancesObs, [WalletBalancesConcepto]=@WalletBalancesConcepto, [WalletBalancesUrl]=@WalletBalancesUrl, [WalletBalancesEstadoOPE]=@WalletBalancesEstadoOPE, [WalletBalanceLiquidacion]=@WalletBalanceLiquidacion  WHERE [WalletId] = @WalletId AND [WalletBalancesId] = @WalletBalancesId", GxErrorMask.GX_NOMASK,prmBC002920)
           ,new CursorDef("BC002921", "DELETE FROM [WalletBalances]  WHERE [WalletId] = @WalletId AND [WalletBalancesId] = @WalletBalancesId", GxErrorMask.GX_NOMASK,prmBC002921)
           ,new CursorDef("BC002922", "SELECT [WalletId], [WalletBalancesId], [WalletBalancesFechaAlta], [WalletBalancesUsrAlta], [WalletBalancesTipoMov], [WalletBalancesImporte], [WalletBalancesObs], [WalletBalancesConcepto], [WalletBalancesUrl], [WalletBalancesEstadoOPE], [WalletBalanceLiquidacion] FROM [WalletBalances] WHERE [WalletId] = @WalletId ORDER BY [WalletId], [WalletBalancesId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002922,11, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getVarchar(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getString(10, 3);
              ((long[]) buf[13])[0] = rslt.getLong(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getVarchar(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getString(10, 3);
              ((long[]) buf[13])[0] = rslt.getLong(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 25);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 25);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 25);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((string[]) buf[6])[0] = rslt.getString(7, 3);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 25);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 25);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((string[]) buf[6])[0] = rslt.getString(7, 3);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getVarchar(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getString(10, 3);
              ((long[]) buf[13])[0] = rslt.getLong(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getVarchar(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getString(10, 3);
              ((long[]) buf[13])[0] = rslt.getLong(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              return;
     }
  }

}

}
