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
   public class parametromudanza_bc : GXHttpHandler, IGxSilentTrn
   {
      public parametromudanza_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public parametromudanza_bc( IGxContext context )
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
         ReadRow2J118( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2J118( ) ;
         standaloneModal( ) ;
         AddRow2J118( ) ;
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
            E112J2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z730ParametroMudanzaId = A730ParametroMudanzaId;
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

      protected void CONFIRM_2J0( )
      {
         BeforeValidate2J118( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2J118( ) ;
            }
            else
            {
               CheckExtendedTable2J118( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors2J118( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122J2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametroMudanza_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametroMudanza_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametroMudanza_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV15Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E112J2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void E132J2( )
      {
         /* ParametroMudanzaTipo_Click Routine */
         returnInSub = false;
      }

      protected void ZM2J118( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z731ParametroMudanzaTipo = A731ParametroMudanzaTipo;
            Z869ParametroMudanzaTitulo = A869ParametroMudanzaTitulo;
            Z732ParametroMudanzaNombre = A732ParametroMudanzaNombre;
            Z812ParametroMudanzaDescripcion = A812ParametroMudanzaDescripcion;
            Z733ParametroMudanzaValor = A733ParametroMudanzaValor;
            Z734ParametroMudanzaUnidad = A734ParametroMudanzaUnidad;
            Z818ParametroMudanzaPisoElev = A818ParametroMudanzaPisoElev;
            Z877ParametroMudanzaActivo = A877ParametroMudanzaActivo;
         }
         if ( GX_JID == -4 )
         {
            Z730ParametroMudanzaId = A730ParametroMudanzaId;
            Z731ParametroMudanzaTipo = A731ParametroMudanzaTipo;
            Z869ParametroMudanzaTitulo = A869ParametroMudanzaTitulo;
            Z732ParametroMudanzaNombre = A732ParametroMudanzaNombre;
            Z812ParametroMudanzaDescripcion = A812ParametroMudanzaDescripcion;
            Z733ParametroMudanzaValor = A733ParametroMudanzaValor;
            Z734ParametroMudanzaUnidad = A734ParametroMudanzaUnidad;
            Z818ParametroMudanzaPisoElev = A818ParametroMudanzaPisoElev;
            Z870ParametroMudanzaImagen = A870ParametroMudanzaImagen;
            Z40000ParametroMudanzaImagen_GXI = A40000ParametroMudanzaImagen_GXI;
            Z877ParametroMudanzaActivo = A877ParametroMudanzaActivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A877ParametroMudanzaActivo) && ( Gx_BScreen == 0 ) )
         {
            A877ParametroMudanzaActivo = true;
         }
      }

      protected void Load2J118( )
      {
         /* Using cursor BC002J4 */
         pr_default.execute(2, new Object[] {A730ParametroMudanzaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound118 = 1;
            A731ParametroMudanzaTipo = BC002J4_A731ParametroMudanzaTipo[0];
            A869ParametroMudanzaTitulo = BC002J4_A869ParametroMudanzaTitulo[0];
            A732ParametroMudanzaNombre = BC002J4_A732ParametroMudanzaNombre[0];
            A812ParametroMudanzaDescripcion = BC002J4_A812ParametroMudanzaDescripcion[0];
            A733ParametroMudanzaValor = BC002J4_A733ParametroMudanzaValor[0];
            A734ParametroMudanzaUnidad = BC002J4_A734ParametroMudanzaUnidad[0];
            A818ParametroMudanzaPisoElev = BC002J4_A818ParametroMudanzaPisoElev[0];
            A40000ParametroMudanzaImagen_GXI = BC002J4_A40000ParametroMudanzaImagen_GXI[0];
            A877ParametroMudanzaActivo = BC002J4_A877ParametroMudanzaActivo[0];
            A870ParametroMudanzaImagen = BC002J4_A870ParametroMudanzaImagen[0];
            ZM2J118( -4) ;
         }
         pr_default.close(2);
         OnLoadActions2J118( ) ;
      }

      protected void OnLoadActions2J118( )
      {
         AV15Pgmname = "ParametroMudanza_BC";
      }

      protected void CheckExtendedTable2J118( )
      {
         standaloneModal( ) ;
         AV15Pgmname = "ParametroMudanza_BC";
         if ( ! ( ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleCasa") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoEstacionamiento") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoVehiculo") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaHogar") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemAdicional") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Peaje") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleApto") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaMobiliario") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaExterior") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaDecoracion") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaOtros") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Escalera") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Ascensor") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "EscaAsce") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioEmbalaje") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioElevacion") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioBase") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxKm") == 0 ) || ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxM3") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Parametro Mudanza Tipo", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "m3") == 0 ) || ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "$") == 0 ) || ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "u") == 0 ) || ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mi") == 0 ) || ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "%") == 0 ) || ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mm") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Parametro Mudanza Unidad", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2J118( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2J118( )
      {
         /* Using cursor BC002J5 */
         pr_default.execute(3, new Object[] {A730ParametroMudanzaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound118 = 1;
         }
         else
         {
            RcdFound118 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002J3 */
         pr_default.execute(1, new Object[] {A730ParametroMudanzaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2J118( 4) ;
            RcdFound118 = 1;
            A730ParametroMudanzaId = BC002J3_A730ParametroMudanzaId[0];
            A731ParametroMudanzaTipo = BC002J3_A731ParametroMudanzaTipo[0];
            A869ParametroMudanzaTitulo = BC002J3_A869ParametroMudanzaTitulo[0];
            A732ParametroMudanzaNombre = BC002J3_A732ParametroMudanzaNombre[0];
            A812ParametroMudanzaDescripcion = BC002J3_A812ParametroMudanzaDescripcion[0];
            A733ParametroMudanzaValor = BC002J3_A733ParametroMudanzaValor[0];
            A734ParametroMudanzaUnidad = BC002J3_A734ParametroMudanzaUnidad[0];
            A818ParametroMudanzaPisoElev = BC002J3_A818ParametroMudanzaPisoElev[0];
            A40000ParametroMudanzaImagen_GXI = BC002J3_A40000ParametroMudanzaImagen_GXI[0];
            A877ParametroMudanzaActivo = BC002J3_A877ParametroMudanzaActivo[0];
            A870ParametroMudanzaImagen = BC002J3_A870ParametroMudanzaImagen[0];
            Z730ParametroMudanzaId = A730ParametroMudanzaId;
            sMode118 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2J118( ) ;
            if ( AnyError == 1 )
            {
               RcdFound118 = 0;
               InitializeNonKey2J118( ) ;
            }
            Gx_mode = sMode118;
         }
         else
         {
            RcdFound118 = 0;
            InitializeNonKey2J118( ) ;
            sMode118 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode118;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2J118( ) ;
         if ( RcdFound118 == 0 )
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
         CONFIRM_2J0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2J118( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002J2 */
            pr_default.execute(0, new Object[] {A730ParametroMudanzaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ParametroMudanza"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z731ParametroMudanzaTipo, BC002J2_A731ParametroMudanzaTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z869ParametroMudanzaTitulo, BC002J2_A869ParametroMudanzaTitulo[0]) != 0 ) || ( StringUtil.StrCmp(Z732ParametroMudanzaNombre, BC002J2_A732ParametroMudanzaNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z812ParametroMudanzaDescripcion, BC002J2_A812ParametroMudanzaDescripcion[0]) != 0 ) || ( Z733ParametroMudanzaValor != BC002J2_A733ParametroMudanzaValor[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z734ParametroMudanzaUnidad, BC002J2_A734ParametroMudanzaUnidad[0]) != 0 ) || ( Z818ParametroMudanzaPisoElev != BC002J2_A818ParametroMudanzaPisoElev[0] ) || ( Z877ParametroMudanzaActivo != BC002J2_A877ParametroMudanzaActivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ParametroMudanza"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2J118( )
      {
         BeforeValidate2J118( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2J118( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2J118( 0) ;
            CheckOptimisticConcurrency2J118( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2J118( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2J118( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002J6 */
                     pr_default.execute(4, new Object[] {A731ParametroMudanzaTipo, A869ParametroMudanzaTitulo, A732ParametroMudanzaNombre, A812ParametroMudanzaDescripcion, A733ParametroMudanzaValor, A734ParametroMudanzaUnidad, A818ParametroMudanzaPisoElev, A870ParametroMudanzaImagen, A40000ParametroMudanzaImagen_GXI, A877ParametroMudanzaActivo});
                     A730ParametroMudanzaId = BC002J6_A730ParametroMudanzaId[0];
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
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
               Load2J118( ) ;
            }
            EndLevel2J118( ) ;
         }
         CloseExtendedTableCursors2J118( ) ;
      }

      protected void Update2J118( )
      {
         BeforeValidate2J118( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2J118( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2J118( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2J118( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2J118( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002J7 */
                     pr_default.execute(5, new Object[] {A731ParametroMudanzaTipo, A869ParametroMudanzaTitulo, A732ParametroMudanzaNombre, A812ParametroMudanzaDescripcion, A733ParametroMudanzaValor, A734ParametroMudanzaUnidad, A818ParametroMudanzaPisoElev, A877ParametroMudanzaActivo, A730ParametroMudanzaId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ParametroMudanza"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2J118( ) ;
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
            EndLevel2J118( ) ;
         }
         CloseExtendedTableCursors2J118( ) ;
      }

      protected void DeferredUpdate2J118( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC002J8 */
            pr_default.execute(6, new Object[] {A870ParametroMudanzaImagen, A40000ParametroMudanzaImagen_GXI, A730ParametroMudanzaId});
            pr_default.close(6);
            pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2J118( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2J118( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2J118( ) ;
            AfterConfirm2J118( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2J118( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002J9 */
                  pr_default.execute(7, new Object[] {A730ParametroMudanzaId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
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
         sMode118 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2J118( ) ;
         Gx_mode = sMode118;
      }

      protected void OnDeleteControls2J118( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "ParametroMudanza_BC";
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC002J10 */
            pr_default.execute(8, new Object[] {A730ParametroMudanzaId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Adicional", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC002J11 */
            pr_default.execute(9, new Object[] {A730ParametroMudanzaId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Carga", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC002J12 */
            pr_default.execute(10, new Object[] {A730ParametroMudanzaId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Mudanza", "")+" ("+context.GetMessage( "Tipo Estacionam Destino", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC002J13 */
            pr_default.execute(11, new Object[] {A730ParametroMudanzaId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Mudanza", "")+" ("+context.GetMessage( "Tipo Estacionam Origen", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC002J14 */
            pr_default.execute(12, new Object[] {A730ParametroMudanzaId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Mudanza", "")+" ("+context.GetMessage( "Tipo Inmueble Destino", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC002J15 */
            pr_default.execute(13, new Object[] {A730ParametroMudanzaId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Mudanza", "")+" ("+context.GetMessage( "Tipo Inmueble Origen", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel2J118( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2J118( ) ;
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

      public void ScanKeyStart2J118( )
      {
         /* Scan By routine */
         /* Using cursor BC002J16 */
         pr_default.execute(14, new Object[] {A730ParametroMudanzaId});
         RcdFound118 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound118 = 1;
            A730ParametroMudanzaId = BC002J16_A730ParametroMudanzaId[0];
            A731ParametroMudanzaTipo = BC002J16_A731ParametroMudanzaTipo[0];
            A869ParametroMudanzaTitulo = BC002J16_A869ParametroMudanzaTitulo[0];
            A732ParametroMudanzaNombre = BC002J16_A732ParametroMudanzaNombre[0];
            A812ParametroMudanzaDescripcion = BC002J16_A812ParametroMudanzaDescripcion[0];
            A733ParametroMudanzaValor = BC002J16_A733ParametroMudanzaValor[0];
            A734ParametroMudanzaUnidad = BC002J16_A734ParametroMudanzaUnidad[0];
            A818ParametroMudanzaPisoElev = BC002J16_A818ParametroMudanzaPisoElev[0];
            A40000ParametroMudanzaImagen_GXI = BC002J16_A40000ParametroMudanzaImagen_GXI[0];
            A877ParametroMudanzaActivo = BC002J16_A877ParametroMudanzaActivo[0];
            A870ParametroMudanzaImagen = BC002J16_A870ParametroMudanzaImagen[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2J118( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound118 = 0;
         ScanKeyLoad2J118( ) ;
      }

      protected void ScanKeyLoad2J118( )
      {
         sMode118 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound118 = 1;
            A730ParametroMudanzaId = BC002J16_A730ParametroMudanzaId[0];
            A731ParametroMudanzaTipo = BC002J16_A731ParametroMudanzaTipo[0];
            A869ParametroMudanzaTitulo = BC002J16_A869ParametroMudanzaTitulo[0];
            A732ParametroMudanzaNombre = BC002J16_A732ParametroMudanzaNombre[0];
            A812ParametroMudanzaDescripcion = BC002J16_A812ParametroMudanzaDescripcion[0];
            A733ParametroMudanzaValor = BC002J16_A733ParametroMudanzaValor[0];
            A734ParametroMudanzaUnidad = BC002J16_A734ParametroMudanzaUnidad[0];
            A818ParametroMudanzaPisoElev = BC002J16_A818ParametroMudanzaPisoElev[0];
            A40000ParametroMudanzaImagen_GXI = BC002J16_A40000ParametroMudanzaImagen_GXI[0];
            A877ParametroMudanzaActivo = BC002J16_A877ParametroMudanzaActivo[0];
            A870ParametroMudanzaImagen = BC002J16_A870ParametroMudanzaImagen[0];
         }
         Gx_mode = sMode118;
      }

      protected void ScanKeyEnd2J118( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm2J118( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2J118( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2J118( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2J118( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2J118( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2J118( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2J118( )
      {
      }

      protected void send_integrity_lvl_hashes2J118( )
      {
      }

      protected void AddRow2J118( )
      {
         VarsToRow118( bcParametroMudanza) ;
      }

      protected void ReadRow2J118( )
      {
         RowToVars118( bcParametroMudanza, 1) ;
      }

      protected void InitializeNonKey2J118( )
      {
         A731ParametroMudanzaTipo = "";
         A869ParametroMudanzaTitulo = "";
         A732ParametroMudanzaNombre = "";
         A812ParametroMudanzaDescripcion = "";
         A733ParametroMudanzaValor = 0;
         A734ParametroMudanzaUnidad = "";
         A818ParametroMudanzaPisoElev = 0;
         A870ParametroMudanzaImagen = "";
         A40000ParametroMudanzaImagen_GXI = "";
         A877ParametroMudanzaActivo = true;
         Z731ParametroMudanzaTipo = "";
         Z869ParametroMudanzaTitulo = "";
         Z732ParametroMudanzaNombre = "";
         Z812ParametroMudanzaDescripcion = "";
         Z733ParametroMudanzaValor = 0;
         Z734ParametroMudanzaUnidad = "";
         Z818ParametroMudanzaPisoElev = 0;
         Z877ParametroMudanzaActivo = false;
      }

      protected void InitAll2J118( )
      {
         A730ParametroMudanzaId = 0;
         InitializeNonKey2J118( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A877ParametroMudanzaActivo = i877ParametroMudanzaActivo;
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

      public void VarsToRow118( SdtParametroMudanza obj118 )
      {
         obj118.gxTpr_Mode = Gx_mode;
         obj118.gxTpr_Parametromudanzatipo = A731ParametroMudanzaTipo;
         obj118.gxTpr_Parametromudanzatitulo = A869ParametroMudanzaTitulo;
         obj118.gxTpr_Parametromudanzanombre = A732ParametroMudanzaNombre;
         obj118.gxTpr_Parametromudanzadescripcion = A812ParametroMudanzaDescripcion;
         obj118.gxTpr_Parametromudanzavalor = A733ParametroMudanzaValor;
         obj118.gxTpr_Parametromudanzaunidad = A734ParametroMudanzaUnidad;
         obj118.gxTpr_Parametromudanzapisoelev = A818ParametroMudanzaPisoElev;
         obj118.gxTpr_Parametromudanzaimagen = A870ParametroMudanzaImagen;
         obj118.gxTpr_Parametromudanzaimagen_gxi = A40000ParametroMudanzaImagen_GXI;
         obj118.gxTpr_Parametromudanzaactivo = A877ParametroMudanzaActivo;
         obj118.gxTpr_Parametromudanzaid = A730ParametroMudanzaId;
         obj118.gxTpr_Parametromudanzaid_Z = Z730ParametroMudanzaId;
         obj118.gxTpr_Parametromudanzatipo_Z = Z731ParametroMudanzaTipo;
         obj118.gxTpr_Parametromudanzatitulo_Z = Z869ParametroMudanzaTitulo;
         obj118.gxTpr_Parametromudanzanombre_Z = Z732ParametroMudanzaNombre;
         obj118.gxTpr_Parametromudanzadescripcion_Z = Z812ParametroMudanzaDescripcion;
         obj118.gxTpr_Parametromudanzavalor_Z = Z733ParametroMudanzaValor;
         obj118.gxTpr_Parametromudanzaunidad_Z = Z734ParametroMudanzaUnidad;
         obj118.gxTpr_Parametromudanzapisoelev_Z = Z818ParametroMudanzaPisoElev;
         obj118.gxTpr_Parametromudanzaactivo_Z = Z877ParametroMudanzaActivo;
         obj118.gxTpr_Parametromudanzaimagen_gxi_Z = Z40000ParametroMudanzaImagen_GXI;
         obj118.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow118( SdtParametroMudanza obj118 )
      {
         obj118.gxTpr_Parametromudanzaid = A730ParametroMudanzaId;
         return  ;
      }

      public void RowToVars118( SdtParametroMudanza obj118 ,
                                int forceLoad )
      {
         Gx_mode = obj118.gxTpr_Mode;
         A731ParametroMudanzaTipo = obj118.gxTpr_Parametromudanzatipo;
         A869ParametroMudanzaTitulo = obj118.gxTpr_Parametromudanzatitulo;
         A732ParametroMudanzaNombre = obj118.gxTpr_Parametromudanzanombre;
         A812ParametroMudanzaDescripcion = obj118.gxTpr_Parametromudanzadescripcion;
         A733ParametroMudanzaValor = obj118.gxTpr_Parametromudanzavalor;
         A734ParametroMudanzaUnidad = obj118.gxTpr_Parametromudanzaunidad;
         A818ParametroMudanzaPisoElev = obj118.gxTpr_Parametromudanzapisoelev;
         A870ParametroMudanzaImagen = obj118.gxTpr_Parametromudanzaimagen;
         A40000ParametroMudanzaImagen_GXI = obj118.gxTpr_Parametromudanzaimagen_gxi;
         A877ParametroMudanzaActivo = obj118.gxTpr_Parametromudanzaactivo;
         A730ParametroMudanzaId = obj118.gxTpr_Parametromudanzaid;
         Z730ParametroMudanzaId = obj118.gxTpr_Parametromudanzaid_Z;
         Z731ParametroMudanzaTipo = obj118.gxTpr_Parametromudanzatipo_Z;
         Z869ParametroMudanzaTitulo = obj118.gxTpr_Parametromudanzatitulo_Z;
         Z732ParametroMudanzaNombre = obj118.gxTpr_Parametromudanzanombre_Z;
         Z812ParametroMudanzaDescripcion = obj118.gxTpr_Parametromudanzadescripcion_Z;
         Z733ParametroMudanzaValor = obj118.gxTpr_Parametromudanzavalor_Z;
         Z734ParametroMudanzaUnidad = obj118.gxTpr_Parametromudanzaunidad_Z;
         Z818ParametroMudanzaPisoElev = obj118.gxTpr_Parametromudanzapisoelev_Z;
         Z877ParametroMudanzaActivo = obj118.gxTpr_Parametromudanzaactivo_Z;
         Z40000ParametroMudanzaImagen_GXI = obj118.gxTpr_Parametromudanzaimagen_gxi_Z;
         Gx_mode = obj118.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A730ParametroMudanzaId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2J118( ) ;
         ScanKeyStart2J118( ) ;
         if ( RcdFound118 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z730ParametroMudanzaId = A730ParametroMudanzaId;
         }
         ZM2J118( -4) ;
         OnLoadActions2J118( ) ;
         AddRow2J118( ) ;
         ScanKeyEnd2J118( ) ;
         if ( RcdFound118 == 0 )
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
         RowToVars118( bcParametroMudanza, 0) ;
         ScanKeyStart2J118( ) ;
         if ( RcdFound118 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z730ParametroMudanzaId = A730ParametroMudanzaId;
         }
         ZM2J118( -4) ;
         OnLoadActions2J118( ) ;
         AddRow2J118( ) ;
         ScanKeyEnd2J118( ) ;
         if ( RcdFound118 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2J118( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2J118( ) ;
         }
         else
         {
            if ( RcdFound118 == 1 )
            {
               if ( A730ParametroMudanzaId != Z730ParametroMudanzaId )
               {
                  A730ParametroMudanzaId = Z730ParametroMudanzaId;
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
                  Update2J118( ) ;
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
                  if ( A730ParametroMudanzaId != Z730ParametroMudanzaId )
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
                        Insert2J118( ) ;
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
                        Insert2J118( ) ;
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
         RowToVars118( bcParametroMudanza, 1) ;
         SaveImpl( ) ;
         VarsToRow118( bcParametroMudanza) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars118( bcParametroMudanza, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2J118( ) ;
         AfterTrn( ) ;
         VarsToRow118( bcParametroMudanza) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow118( bcParametroMudanza) ;
         }
         else
         {
            SdtParametroMudanza auxBC = new SdtParametroMudanza(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A730ParametroMudanzaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcParametroMudanza);
               auxBC.Save();
               bcParametroMudanza.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars118( bcParametroMudanza, 1) ;
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
         RowToVars118( bcParametroMudanza, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2J118( ) ;
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
               VarsToRow118( bcParametroMudanza) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow118( bcParametroMudanza) ;
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
         RowToVars118( bcParametroMudanza, 0) ;
         GetKey2J118( ) ;
         if ( RcdFound118 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A730ParametroMudanzaId != Z730ParametroMudanzaId )
            {
               A730ParametroMudanzaId = Z730ParametroMudanzaId;
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
            if ( A730ParametroMudanzaId != Z730ParametroMudanzaId )
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
         context.RollbackDataStores("parametromudanza_bc",pr_default);
         VarsToRow118( bcParametroMudanza) ;
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
         Gx_mode = bcParametroMudanza.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcParametroMudanza.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcParametroMudanza )
         {
            bcParametroMudanza = (SdtParametroMudanza)(sdt);
            if ( StringUtil.StrCmp(bcParametroMudanza.gxTpr_Mode, "") == 0 )
            {
               bcParametroMudanza.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow118( bcParametroMudanza) ;
            }
            else
            {
               RowToVars118( bcParametroMudanza, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcParametroMudanza.gxTpr_Mode, "") == 0 )
            {
               bcParametroMudanza.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars118( bcParametroMudanza, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtParametroMudanza ParametroMudanza_BC
      {
         get {
            return bcParametroMudanza ;
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV15Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z731ParametroMudanzaTipo = "";
         A731ParametroMudanzaTipo = "";
         Z869ParametroMudanzaTitulo = "";
         A869ParametroMudanzaTitulo = "";
         Z732ParametroMudanzaNombre = "";
         A732ParametroMudanzaNombre = "";
         Z812ParametroMudanzaDescripcion = "";
         A812ParametroMudanzaDescripcion = "";
         Z734ParametroMudanzaUnidad = "";
         A734ParametroMudanzaUnidad = "";
         Z870ParametroMudanzaImagen = "";
         A870ParametroMudanzaImagen = "";
         Z40000ParametroMudanzaImagen_GXI = "";
         A40000ParametroMudanzaImagen_GXI = "";
         BC002J4_A730ParametroMudanzaId = new short[1] ;
         BC002J4_A731ParametroMudanzaTipo = new string[] {""} ;
         BC002J4_A869ParametroMudanzaTitulo = new string[] {""} ;
         BC002J4_A732ParametroMudanzaNombre = new string[] {""} ;
         BC002J4_A812ParametroMudanzaDescripcion = new string[] {""} ;
         BC002J4_A733ParametroMudanzaValor = new decimal[1] ;
         BC002J4_A734ParametroMudanzaUnidad = new string[] {""} ;
         BC002J4_A818ParametroMudanzaPisoElev = new short[1] ;
         BC002J4_A40000ParametroMudanzaImagen_GXI = new string[] {""} ;
         BC002J4_A877ParametroMudanzaActivo = new bool[] {false} ;
         BC002J4_A870ParametroMudanzaImagen = new string[] {""} ;
         BC002J5_A730ParametroMudanzaId = new short[1] ;
         BC002J3_A730ParametroMudanzaId = new short[1] ;
         BC002J3_A731ParametroMudanzaTipo = new string[] {""} ;
         BC002J3_A869ParametroMudanzaTitulo = new string[] {""} ;
         BC002J3_A732ParametroMudanzaNombre = new string[] {""} ;
         BC002J3_A812ParametroMudanzaDescripcion = new string[] {""} ;
         BC002J3_A733ParametroMudanzaValor = new decimal[1] ;
         BC002J3_A734ParametroMudanzaUnidad = new string[] {""} ;
         BC002J3_A818ParametroMudanzaPisoElev = new short[1] ;
         BC002J3_A40000ParametroMudanzaImagen_GXI = new string[] {""} ;
         BC002J3_A877ParametroMudanzaActivo = new bool[] {false} ;
         BC002J3_A870ParametroMudanzaImagen = new string[] {""} ;
         sMode118 = "";
         BC002J2_A730ParametroMudanzaId = new short[1] ;
         BC002J2_A731ParametroMudanzaTipo = new string[] {""} ;
         BC002J2_A869ParametroMudanzaTitulo = new string[] {""} ;
         BC002J2_A732ParametroMudanzaNombre = new string[] {""} ;
         BC002J2_A812ParametroMudanzaDescripcion = new string[] {""} ;
         BC002J2_A733ParametroMudanzaValor = new decimal[1] ;
         BC002J2_A734ParametroMudanzaUnidad = new string[] {""} ;
         BC002J2_A818ParametroMudanzaPisoElev = new short[1] ;
         BC002J2_A40000ParametroMudanzaImagen_GXI = new string[] {""} ;
         BC002J2_A877ParametroMudanzaActivo = new bool[] {false} ;
         BC002J2_A870ParametroMudanzaImagen = new string[] {""} ;
         BC002J6_A730ParametroMudanzaId = new short[1] ;
         BC002J10_A735MudanzaId = new long[1] ;
         BC002J10_A766ItemAdicionalId = new short[1] ;
         BC002J11_A735MudanzaId = new long[1] ;
         BC002J11_A751ItemCargaId = new short[1] ;
         BC002J12_A735MudanzaId = new long[1] ;
         BC002J13_A735MudanzaId = new long[1] ;
         BC002J14_A735MudanzaId = new long[1] ;
         BC002J15_A735MudanzaId = new long[1] ;
         BC002J16_A730ParametroMudanzaId = new short[1] ;
         BC002J16_A731ParametroMudanzaTipo = new string[] {""} ;
         BC002J16_A869ParametroMudanzaTitulo = new string[] {""} ;
         BC002J16_A732ParametroMudanzaNombre = new string[] {""} ;
         BC002J16_A812ParametroMudanzaDescripcion = new string[] {""} ;
         BC002J16_A733ParametroMudanzaValor = new decimal[1] ;
         BC002J16_A734ParametroMudanzaUnidad = new string[] {""} ;
         BC002J16_A818ParametroMudanzaPisoElev = new short[1] ;
         BC002J16_A40000ParametroMudanzaImagen_GXI = new string[] {""} ;
         BC002J16_A877ParametroMudanzaActivo = new bool[] {false} ;
         BC002J16_A870ParametroMudanzaImagen = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.parametromudanza_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametromudanza_bc__default(),
            new Object[][] {
                new Object[] {
               BC002J2_A730ParametroMudanzaId, BC002J2_A731ParametroMudanzaTipo, BC002J2_A869ParametroMudanzaTitulo, BC002J2_A732ParametroMudanzaNombre, BC002J2_A812ParametroMudanzaDescripcion, BC002J2_A733ParametroMudanzaValor, BC002J2_A734ParametroMudanzaUnidad, BC002J2_A818ParametroMudanzaPisoElev, BC002J2_A40000ParametroMudanzaImagen_GXI, BC002J2_A877ParametroMudanzaActivo,
               BC002J2_A870ParametroMudanzaImagen
               }
               , new Object[] {
               BC002J3_A730ParametroMudanzaId, BC002J3_A731ParametroMudanzaTipo, BC002J3_A869ParametroMudanzaTitulo, BC002J3_A732ParametroMudanzaNombre, BC002J3_A812ParametroMudanzaDescripcion, BC002J3_A733ParametroMudanzaValor, BC002J3_A734ParametroMudanzaUnidad, BC002J3_A818ParametroMudanzaPisoElev, BC002J3_A40000ParametroMudanzaImagen_GXI, BC002J3_A877ParametroMudanzaActivo,
               BC002J3_A870ParametroMudanzaImagen
               }
               , new Object[] {
               BC002J4_A730ParametroMudanzaId, BC002J4_A731ParametroMudanzaTipo, BC002J4_A869ParametroMudanzaTitulo, BC002J4_A732ParametroMudanzaNombre, BC002J4_A812ParametroMudanzaDescripcion, BC002J4_A733ParametroMudanzaValor, BC002J4_A734ParametroMudanzaUnidad, BC002J4_A818ParametroMudanzaPisoElev, BC002J4_A40000ParametroMudanzaImagen_GXI, BC002J4_A877ParametroMudanzaActivo,
               BC002J4_A870ParametroMudanzaImagen
               }
               , new Object[] {
               BC002J5_A730ParametroMudanzaId
               }
               , new Object[] {
               BC002J6_A730ParametroMudanzaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002J10_A735MudanzaId, BC002J10_A766ItemAdicionalId
               }
               , new Object[] {
               BC002J11_A735MudanzaId, BC002J11_A751ItemCargaId
               }
               , new Object[] {
               BC002J12_A735MudanzaId
               }
               , new Object[] {
               BC002J13_A735MudanzaId
               }
               , new Object[] {
               BC002J14_A735MudanzaId
               }
               , new Object[] {
               BC002J15_A735MudanzaId
               }
               , new Object[] {
               BC002J16_A730ParametroMudanzaId, BC002J16_A731ParametroMudanzaTipo, BC002J16_A869ParametroMudanzaTitulo, BC002J16_A732ParametroMudanzaNombre, BC002J16_A812ParametroMudanzaDescripcion, BC002J16_A733ParametroMudanzaValor, BC002J16_A734ParametroMudanzaUnidad, BC002J16_A818ParametroMudanzaPisoElev, BC002J16_A40000ParametroMudanzaImagen_GXI, BC002J16_A877ParametroMudanzaActivo,
               BC002J16_A870ParametroMudanzaImagen
               }
            }
         );
         Z877ParametroMudanzaActivo = true;
         A877ParametroMudanzaActivo = true;
         i877ParametroMudanzaActivo = true;
         AV15Pgmname = "ParametroMudanza_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122J2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z730ParametroMudanzaId ;
      private short A730ParametroMudanzaId ;
      private short Z818ParametroMudanzaPisoElev ;
      private short A818ParametroMudanzaPisoElev ;
      private short Gx_BScreen ;
      private short RcdFound118 ;
      private int trnEnded ;
      private decimal Z733ParametroMudanzaValor ;
      private decimal A733ParametroMudanzaValor ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV15Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Z734ParametroMudanzaUnidad ;
      private string A734ParametroMudanzaUnidad ;
      private string sMode118 ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Z877ParametroMudanzaActivo ;
      private bool A877ParametroMudanzaActivo ;
      private bool Gx_longc ;
      private bool i877ParametroMudanzaActivo ;
      private string Z731ParametroMudanzaTipo ;
      private string A731ParametroMudanzaTipo ;
      private string Z869ParametroMudanzaTitulo ;
      private string A869ParametroMudanzaTitulo ;
      private string Z732ParametroMudanzaNombre ;
      private string A732ParametroMudanzaNombre ;
      private string Z812ParametroMudanzaDescripcion ;
      private string A812ParametroMudanzaDescripcion ;
      private string Z40000ParametroMudanzaImagen_GXI ;
      private string A40000ParametroMudanzaImagen_GXI ;
      private string Z870ParametroMudanzaImagen ;
      private string A870ParametroMudanzaImagen ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] BC002J4_A730ParametroMudanzaId ;
      private string[] BC002J4_A731ParametroMudanzaTipo ;
      private string[] BC002J4_A869ParametroMudanzaTitulo ;
      private string[] BC002J4_A732ParametroMudanzaNombre ;
      private string[] BC002J4_A812ParametroMudanzaDescripcion ;
      private decimal[] BC002J4_A733ParametroMudanzaValor ;
      private string[] BC002J4_A734ParametroMudanzaUnidad ;
      private short[] BC002J4_A818ParametroMudanzaPisoElev ;
      private string[] BC002J4_A40000ParametroMudanzaImagen_GXI ;
      private bool[] BC002J4_A877ParametroMudanzaActivo ;
      private string[] BC002J4_A870ParametroMudanzaImagen ;
      private short[] BC002J5_A730ParametroMudanzaId ;
      private short[] BC002J3_A730ParametroMudanzaId ;
      private string[] BC002J3_A731ParametroMudanzaTipo ;
      private string[] BC002J3_A869ParametroMudanzaTitulo ;
      private string[] BC002J3_A732ParametroMudanzaNombre ;
      private string[] BC002J3_A812ParametroMudanzaDescripcion ;
      private decimal[] BC002J3_A733ParametroMudanzaValor ;
      private string[] BC002J3_A734ParametroMudanzaUnidad ;
      private short[] BC002J3_A818ParametroMudanzaPisoElev ;
      private string[] BC002J3_A40000ParametroMudanzaImagen_GXI ;
      private bool[] BC002J3_A877ParametroMudanzaActivo ;
      private string[] BC002J3_A870ParametroMudanzaImagen ;
      private short[] BC002J2_A730ParametroMudanzaId ;
      private string[] BC002J2_A731ParametroMudanzaTipo ;
      private string[] BC002J2_A869ParametroMudanzaTitulo ;
      private string[] BC002J2_A732ParametroMudanzaNombre ;
      private string[] BC002J2_A812ParametroMudanzaDescripcion ;
      private decimal[] BC002J2_A733ParametroMudanzaValor ;
      private string[] BC002J2_A734ParametroMudanzaUnidad ;
      private short[] BC002J2_A818ParametroMudanzaPisoElev ;
      private string[] BC002J2_A40000ParametroMudanzaImagen_GXI ;
      private bool[] BC002J2_A877ParametroMudanzaActivo ;
      private string[] BC002J2_A870ParametroMudanzaImagen ;
      private short[] BC002J6_A730ParametroMudanzaId ;
      private long[] BC002J10_A735MudanzaId ;
      private short[] BC002J10_A766ItemAdicionalId ;
      private long[] BC002J11_A735MudanzaId ;
      private short[] BC002J11_A751ItemCargaId ;
      private long[] BC002J12_A735MudanzaId ;
      private long[] BC002J13_A735MudanzaId ;
      private long[] BC002J14_A735MudanzaId ;
      private long[] BC002J15_A735MudanzaId ;
      private short[] BC002J16_A730ParametroMudanzaId ;
      private string[] BC002J16_A731ParametroMudanzaTipo ;
      private string[] BC002J16_A869ParametroMudanzaTitulo ;
      private string[] BC002J16_A732ParametroMudanzaNombre ;
      private string[] BC002J16_A812ParametroMudanzaDescripcion ;
      private decimal[] BC002J16_A733ParametroMudanzaValor ;
      private string[] BC002J16_A734ParametroMudanzaUnidad ;
      private short[] BC002J16_A818ParametroMudanzaPisoElev ;
      private string[] BC002J16_A40000ParametroMudanzaImagen_GXI ;
      private bool[] BC002J16_A877ParametroMudanzaActivo ;
      private string[] BC002J16_A870ParametroMudanzaImagen ;
      private SdtParametroMudanza bcParametroMudanza ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class parametromudanza_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class parametromudanza_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
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
        Object[] prmBC002J2;
        prmBC002J2 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmBC002J3;
        prmBC002J3 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmBC002J4;
        prmBC002J4 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmBC002J5;
        prmBC002J5 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmBC002J6;
        prmBC002J6 = new Object[] {
        new ParDef("@ParametroMudanzaTipo",GXType.NVarChar,20,0) ,
        new ParDef("@ParametroMudanzaTitulo",GXType.NVarChar,80,0) ,
        new ParDef("@ParametroMudanzaNombre",GXType.NVarChar,100,0) ,
        new ParDef("@ParametroMudanzaDescripcion",GXType.NVarChar,100,0) ,
        new ParDef("@ParametroMudanzaValor",GXType.Decimal,18,2) ,
        new ParDef("@ParametroMudanzaUnidad",GXType.NChar,2,0) ,
        new ParDef("@ParametroMudanzaPisoElev",GXType.Int16,4,0) ,
        new ParDef("@ParametroMudanzaImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ParametroMudanzaImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=7, Tbl="ParametroMudanza", Fld="ParametroMudanzaImagen"} ,
        new ParDef("@ParametroMudanzaActivo",GXType.Boolean,4,0)
        };
        Object[] prmBC002J7;
        prmBC002J7 = new Object[] {
        new ParDef("@ParametroMudanzaTipo",GXType.NVarChar,20,0) ,
        new ParDef("@ParametroMudanzaTitulo",GXType.NVarChar,80,0) ,
        new ParDef("@ParametroMudanzaNombre",GXType.NVarChar,100,0) ,
        new ParDef("@ParametroMudanzaDescripcion",GXType.NVarChar,100,0) ,
        new ParDef("@ParametroMudanzaValor",GXType.Decimal,18,2) ,
        new ParDef("@ParametroMudanzaUnidad",GXType.NChar,2,0) ,
        new ParDef("@ParametroMudanzaPisoElev",GXType.Int16,4,0) ,
        new ParDef("@ParametroMudanzaActivo",GXType.Boolean,4,0) ,
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmBC002J8;
        prmBC002J8 = new Object[] {
        new ParDef("@ParametroMudanzaImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ParametroMudanzaImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="ParametroMudanza", Fld="ParametroMudanzaImagen"} ,
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmBC002J9;
        prmBC002J9 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmBC002J10;
        prmBC002J10 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmBC002J11;
        prmBC002J11 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmBC002J12;
        prmBC002J12 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmBC002J13;
        prmBC002J13 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmBC002J14;
        prmBC002J14 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmBC002J15;
        prmBC002J15 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        Object[] prmBC002J16;
        prmBC002J16 = new Object[] {
        new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC002J2", "SELECT [ParametroMudanzaId], [ParametroMudanzaTipo], [ParametroMudanzaTitulo], [ParametroMudanzaNombre], [ParametroMudanzaDescripcion], [ParametroMudanzaValor], [ParametroMudanzaUnidad], [ParametroMudanzaPisoElev], [ParametroMudanzaImagen_GXI], [ParametroMudanzaActivo], [ParametroMudanzaImagen] FROM [ParametroMudanza] WITH (UPDLOCK) WHERE [ParametroMudanzaId] = @ParametroMudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002J3", "SELECT [ParametroMudanzaId], [ParametroMudanzaTipo], [ParametroMudanzaTitulo], [ParametroMudanzaNombre], [ParametroMudanzaDescripcion], [ParametroMudanzaValor], [ParametroMudanzaUnidad], [ParametroMudanzaPisoElev], [ParametroMudanzaImagen_GXI], [ParametroMudanzaActivo], [ParametroMudanzaImagen] FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @ParametroMudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002J4", "SELECT TM1.[ParametroMudanzaId], TM1.[ParametroMudanzaTipo], TM1.[ParametroMudanzaTitulo], TM1.[ParametroMudanzaNombre], TM1.[ParametroMudanzaDescripcion], TM1.[ParametroMudanzaValor], TM1.[ParametroMudanzaUnidad], TM1.[ParametroMudanzaPisoElev], TM1.[ParametroMudanzaImagen_GXI], TM1.[ParametroMudanzaActivo], TM1.[ParametroMudanzaImagen] FROM [ParametroMudanza] TM1 WHERE TM1.[ParametroMudanzaId] = @ParametroMudanzaId ORDER BY TM1.[ParametroMudanzaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002J5", "SELECT [ParametroMudanzaId] FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @ParametroMudanzaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002J6", "INSERT INTO [ParametroMudanza]([ParametroMudanzaTipo], [ParametroMudanzaTitulo], [ParametroMudanzaNombre], [ParametroMudanzaDescripcion], [ParametroMudanzaValor], [ParametroMudanzaUnidad], [ParametroMudanzaPisoElev], [ParametroMudanzaImagen], [ParametroMudanzaImagen_GXI], [ParametroMudanzaActivo]) VALUES(@ParametroMudanzaTipo, @ParametroMudanzaTitulo, @ParametroMudanzaNombre, @ParametroMudanzaDescripcion, @ParametroMudanzaValor, @ParametroMudanzaUnidad, @ParametroMudanzaPisoElev, @ParametroMudanzaImagen, @ParametroMudanzaImagen_GXI, @ParametroMudanzaActivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC002J7", "UPDATE [ParametroMudanza] SET [ParametroMudanzaTipo]=@ParametroMudanzaTipo, [ParametroMudanzaTitulo]=@ParametroMudanzaTitulo, [ParametroMudanzaNombre]=@ParametroMudanzaNombre, [ParametroMudanzaDescripcion]=@ParametroMudanzaDescripcion, [ParametroMudanzaValor]=@ParametroMudanzaValor, [ParametroMudanzaUnidad]=@ParametroMudanzaUnidad, [ParametroMudanzaPisoElev]=@ParametroMudanzaPisoElev, [ParametroMudanzaActivo]=@ParametroMudanzaActivo  WHERE [ParametroMudanzaId] = @ParametroMudanzaId", GxErrorMask.GX_NOMASK,prmBC002J7)
           ,new CursorDef("BC002J8", "UPDATE [ParametroMudanza] SET [ParametroMudanzaImagen]=@ParametroMudanzaImagen, [ParametroMudanzaImagen_GXI]=@ParametroMudanzaImagen_GXI  WHERE [ParametroMudanzaId] = @ParametroMudanzaId", GxErrorMask.GX_NOMASK,prmBC002J8)
           ,new CursorDef("BC002J9", "DELETE FROM [ParametroMudanza]  WHERE [ParametroMudanzaId] = @ParametroMudanzaId", GxErrorMask.GX_NOMASK,prmBC002J9)
           ,new CursorDef("BC002J10", "SELECT TOP 1 [MudanzaId], [ItemAdicionalId] FROM [MudanzaAdicional] WHERE [ItemAdicionalId] = @ParametroMudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC002J11", "SELECT TOP 1 [MudanzaId], [ItemCargaId] FROM [MudanzaCarga] WHERE [ItemCargaId] = @ParametroMudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC002J12", "SELECT TOP 1 [MudanzaId] FROM [Mudanza] WHERE [TipoEstacionamDestinoId] = @ParametroMudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC002J13", "SELECT TOP 1 [MudanzaId] FROM [Mudanza] WHERE [TipoEstacionamOrigenId] = @ParametroMudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC002J14", "SELECT TOP 1 [MudanzaId] FROM [Mudanza] WHERE [TipoInmuebleDestinoId] = @ParametroMudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC002J15", "SELECT TOP 1 [MudanzaId] FROM [Mudanza] WHERE [TipoInmuebleOrigenId] = @ParametroMudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC002J16", "SELECT TM1.[ParametroMudanzaId], TM1.[ParametroMudanzaTipo], TM1.[ParametroMudanzaTitulo], TM1.[ParametroMudanzaNombre], TM1.[ParametroMudanzaDescripcion], TM1.[ParametroMudanzaValor], TM1.[ParametroMudanzaUnidad], TM1.[ParametroMudanzaPisoElev], TM1.[ParametroMudanzaImagen_GXI], TM1.[ParametroMudanzaActivo], TM1.[ParametroMudanzaImagen] FROM [ParametroMudanza] TM1 WHERE TM1.[ParametroMudanzaId] = @ParametroMudanzaId ORDER BY TM1.[ParametroMudanzaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J16,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 2);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(9));
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 2);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(9));
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 2);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(9));
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 2);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(9));
              return;
     }
  }

}

}
