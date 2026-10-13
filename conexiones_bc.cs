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
   public class conexiones_bc : GXHttpHandler, IGxSilentTrn
   {
      public conexiones_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public conexiones_bc( IGxContext context )
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
         ReadRow2080( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2080( ) ;
         standaloneModal( ) ;
         AddRow2080( ) ;
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
            E11202 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z552ConexionesID = A552ConexionesID;
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

      protected void CONFIRM_200( )
      {
         BeforeValidate2080( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2080( ) ;
            }
            else
            {
               CheckExtendedTable2080( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors2080( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode80 = Gx_mode;
            CONFIRM_2081( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode80;
            }
            /* Restore parent mode. */
            Gx_mode = sMode80;
         }
      }

      protected void CONFIRM_2081( )
      {
         nGXsfl_81_idx = 0;
         while ( nGXsfl_81_idx < bcConexiones.gxTpr_Datos.Count )
         {
            ReadRow2081( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound81 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_81 != 0 ) )
            {
               GetKey2081( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound81 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate2081( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable2081( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors2081( ) ;
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
                  if ( RcdFound81 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey2081( ) ;
                        Load2081( ) ;
                        BeforeValidate2081( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls2081( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_81 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate2081( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable2081( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors2081( ) ;
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
               VarsToRow81( ((SdtConexiones_Datos)bcConexiones.gxTpr_Datos.Item(nGXsfl_81_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E12202( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWConexiones_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWConexiones_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWConexiones_Delete", out  GXt_boolean1) ;
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

      protected void E11202( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void E13202( )
      {
         /* 'Alta Automatica' Routine */
         returnInSub = false;
         new aautconexiones(context ).execute( ) ;
      }

      protected void ZM2080( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z556ConexionesNombre = A556ConexionesNombre;
            Z964ConexionesTipoIntegracion = A964ConexionesTipoIntegracion;
            Z557ConexionesHost = A557ConexionesHost;
            Z558ConexionesBaseURL = A558ConexionesBaseURL;
            Z559ConexionesPort = A559ConexionesPort;
            Z560ConexionesApiKey = A560ConexionesApiKey;
            Z561ConexionesUsr = A561ConexionesUsr;
            Z563ConexionesAux1 = A563ConexionesAux1;
            Z564ConexionesAux2 = A564ConexionesAux2;
            Z565ConexionesAux3 = A565ConexionesAux3;
            Z562ConexionesEstado = A562ConexionesEstado;
         }
         if ( GX_JID == -3 )
         {
            Z552ConexionesID = A552ConexionesID;
            Z556ConexionesNombre = A556ConexionesNombre;
            Z964ConexionesTipoIntegracion = A964ConexionesTipoIntegracion;
            Z557ConexionesHost = A557ConexionesHost;
            Z558ConexionesBaseURL = A558ConexionesBaseURL;
            Z559ConexionesPort = A559ConexionesPort;
            Z560ConexionesApiKey = A560ConexionesApiKey;
            Z561ConexionesUsr = A561ConexionesUsr;
            Z563ConexionesAux1 = A563ConexionesAux1;
            Z564ConexionesAux2 = A564ConexionesAux2;
            Z565ConexionesAux3 = A565ConexionesAux3;
            Z562ConexionesEstado = A562ConexionesEstado;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2080( )
      {
         /* Using cursor BC00206 */
         pr_default.execute(4, new Object[] {n552ConexionesID, A552ConexionesID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound80 = 1;
            A556ConexionesNombre = BC00206_A556ConexionesNombre[0];
            n556ConexionesNombre = BC00206_n556ConexionesNombre[0];
            A964ConexionesTipoIntegracion = BC00206_A964ConexionesTipoIntegracion[0];
            n964ConexionesTipoIntegracion = BC00206_n964ConexionesTipoIntegracion[0];
            A557ConexionesHost = BC00206_A557ConexionesHost[0];
            n557ConexionesHost = BC00206_n557ConexionesHost[0];
            A558ConexionesBaseURL = BC00206_A558ConexionesBaseURL[0];
            n558ConexionesBaseURL = BC00206_n558ConexionesBaseURL[0];
            A559ConexionesPort = BC00206_A559ConexionesPort[0];
            n559ConexionesPort = BC00206_n559ConexionesPort[0];
            A560ConexionesApiKey = BC00206_A560ConexionesApiKey[0];
            n560ConexionesApiKey = BC00206_n560ConexionesApiKey[0];
            A561ConexionesUsr = BC00206_A561ConexionesUsr[0];
            n561ConexionesUsr = BC00206_n561ConexionesUsr[0];
            A563ConexionesAux1 = BC00206_A563ConexionesAux1[0];
            n563ConexionesAux1 = BC00206_n563ConexionesAux1[0];
            A564ConexionesAux2 = BC00206_A564ConexionesAux2[0];
            n564ConexionesAux2 = BC00206_n564ConexionesAux2[0];
            A565ConexionesAux3 = BC00206_A565ConexionesAux3[0];
            n565ConexionesAux3 = BC00206_n565ConexionesAux3[0];
            A562ConexionesEstado = BC00206_A562ConexionesEstado[0];
            n562ConexionesEstado = BC00206_n562ConexionesEstado[0];
            ZM2080( -3) ;
         }
         pr_default.close(4);
         OnLoadActions2080( ) ;
      }

      protected void OnLoadActions2080( )
      {
         AV15Pgmname = "Conexiones_BC";
      }

      protected void CheckExtendedTable2080( )
      {
         standaloneModal( ) ;
         AV15Pgmname = "Conexiones_BC";
         if ( ! ( ( A964ConexionesTipoIntegracion == 1 ) || ( A964ConexionesTipoIntegracion == 2 ) || (0==A964ConexionesTipoIntegracion) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Conexiones Tipo Integracion", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A562ConexionesEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A562ConexionesEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A562ConexionesEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A562ConexionesEstado, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A562ConexionesEstado)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2080( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2080( )
      {
         /* Using cursor BC00207 */
         pr_default.execute(5, new Object[] {n552ConexionesID, A552ConexionesID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound80 = 1;
         }
         else
         {
            RcdFound80 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00205 */
         pr_default.execute(3, new Object[] {n552ConexionesID, A552ConexionesID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM2080( 3) ;
            RcdFound80 = 1;
            A552ConexionesID = BC00205_A552ConexionesID[0];
            n552ConexionesID = BC00205_n552ConexionesID[0];
            A556ConexionesNombre = BC00205_A556ConexionesNombre[0];
            n556ConexionesNombre = BC00205_n556ConexionesNombre[0];
            A964ConexionesTipoIntegracion = BC00205_A964ConexionesTipoIntegracion[0];
            n964ConexionesTipoIntegracion = BC00205_n964ConexionesTipoIntegracion[0];
            A557ConexionesHost = BC00205_A557ConexionesHost[0];
            n557ConexionesHost = BC00205_n557ConexionesHost[0];
            A558ConexionesBaseURL = BC00205_A558ConexionesBaseURL[0];
            n558ConexionesBaseURL = BC00205_n558ConexionesBaseURL[0];
            A559ConexionesPort = BC00205_A559ConexionesPort[0];
            n559ConexionesPort = BC00205_n559ConexionesPort[0];
            A560ConexionesApiKey = BC00205_A560ConexionesApiKey[0];
            n560ConexionesApiKey = BC00205_n560ConexionesApiKey[0];
            A561ConexionesUsr = BC00205_A561ConexionesUsr[0];
            n561ConexionesUsr = BC00205_n561ConexionesUsr[0];
            A563ConexionesAux1 = BC00205_A563ConexionesAux1[0];
            n563ConexionesAux1 = BC00205_n563ConexionesAux1[0];
            A564ConexionesAux2 = BC00205_A564ConexionesAux2[0];
            n564ConexionesAux2 = BC00205_n564ConexionesAux2[0];
            A565ConexionesAux3 = BC00205_A565ConexionesAux3[0];
            n565ConexionesAux3 = BC00205_n565ConexionesAux3[0];
            A562ConexionesEstado = BC00205_A562ConexionesEstado[0];
            n562ConexionesEstado = BC00205_n562ConexionesEstado[0];
            Z552ConexionesID = A552ConexionesID;
            sMode80 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2080( ) ;
            if ( AnyError == 1 )
            {
               RcdFound80 = 0;
               InitializeNonKey2080( ) ;
            }
            Gx_mode = sMode80;
         }
         else
         {
            RcdFound80 = 0;
            InitializeNonKey2080( ) ;
            sMode80 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode80;
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey2080( ) ;
         if ( RcdFound80 == 0 )
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
         CONFIRM_200( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2080( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00204 */
            pr_default.execute(2, new Object[] {n552ConexionesID, A552ConexionesID});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Conexiones"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z556ConexionesNombre, BC00204_A556ConexionesNombre[0]) != 0 ) || ( Z964ConexionesTipoIntegracion != BC00204_A964ConexionesTipoIntegracion[0] ) || ( StringUtil.StrCmp(Z557ConexionesHost, BC00204_A557ConexionesHost[0]) != 0 ) || ( StringUtil.StrCmp(Z558ConexionesBaseURL, BC00204_A558ConexionesBaseURL[0]) != 0 ) || ( Z559ConexionesPort != BC00204_A559ConexionesPort[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z560ConexionesApiKey, BC00204_A560ConexionesApiKey[0]) != 0 ) || ( StringUtil.StrCmp(Z561ConexionesUsr, BC00204_A561ConexionesUsr[0]) != 0 ) || ( StringUtil.StrCmp(Z563ConexionesAux1, BC00204_A563ConexionesAux1[0]) != 0 ) || ( StringUtil.StrCmp(Z564ConexionesAux2, BC00204_A564ConexionesAux2[0]) != 0 ) || ( StringUtil.StrCmp(Z565ConexionesAux3, BC00204_A565ConexionesAux3[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z562ConexionesEstado, BC00204_A562ConexionesEstado[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Conexiones"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2080( )
      {
         BeforeValidate2080( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2080( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2080( 0) ;
            CheckOptimisticConcurrency2080( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2080( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2080( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00208 */
                     pr_default.execute(6, new Object[] {n552ConexionesID, A552ConexionesID, n556ConexionesNombre, A556ConexionesNombre, n964ConexionesTipoIntegracion, A964ConexionesTipoIntegracion, n557ConexionesHost, A557ConexionesHost, n558ConexionesBaseURL, A558ConexionesBaseURL, n559ConexionesPort, A559ConexionesPort, n560ConexionesApiKey, A560ConexionesApiKey, n561ConexionesUsr, A561ConexionesUsr, n563ConexionesAux1, A563ConexionesAux1, n564ConexionesAux2, A564ConexionesAux2, n565ConexionesAux3, A565ConexionesAux3, n562ConexionesEstado, A562ConexionesEstado});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Conexiones");
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
                           ProcessLevel2080( ) ;
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
               Load2080( ) ;
            }
            EndLevel2080( ) ;
         }
         CloseExtendedTableCursors2080( ) ;
      }

      protected void Update2080( )
      {
         BeforeValidate2080( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2080( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2080( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2080( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2080( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00209 */
                     pr_default.execute(7, new Object[] {n556ConexionesNombre, A556ConexionesNombre, n964ConexionesTipoIntegracion, A964ConexionesTipoIntegracion, n557ConexionesHost, A557ConexionesHost, n558ConexionesBaseURL, A558ConexionesBaseURL, n559ConexionesPort, A559ConexionesPort, n560ConexionesApiKey, A560ConexionesApiKey, n561ConexionesUsr, A561ConexionesUsr, n563ConexionesAux1, A563ConexionesAux1, n564ConexionesAux2, A564ConexionesAux2, n565ConexionesAux3, A565ConexionesAux3, n562ConexionesEstado, A562ConexionesEstado, n552ConexionesID, A552ConexionesID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Conexiones");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Conexiones"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2080( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2080( ) ;
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
            EndLevel2080( ) ;
         }
         CloseExtendedTableCursors2080( ) ;
      }

      protected void DeferredUpdate2080( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2080( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2080( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2080( ) ;
            AfterConfirm2080( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2080( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart2081( ) ;
                  while ( RcdFound81 != 0 )
                  {
                     getByPrimaryKey2081( ) ;
                     Delete2081( ) ;
                     ScanKeyNext2081( ) ;
                  }
                  ScanKeyEnd2081( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002010 */
                     pr_default.execute(8, new Object[] {n552ConexionesID, A552ConexionesID});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Conexiones");
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
         sMode80 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2080( ) ;
         Gx_mode = sMode80;
      }

      protected void OnDeleteControls2080( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "Conexiones_BC";
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC002011 */
            pr_default.execute(9, new Object[] {n552ConexionesID, A552ConexionesID});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Lista Mapeo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void ProcessNestedLevel2081( )
      {
         nGXsfl_81_idx = 0;
         while ( nGXsfl_81_idx < bcConexiones.gxTpr_Datos.Count )
         {
            ReadRow2081( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound81 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_81 != 0 ) )
            {
               standaloneNotModal2081( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert2081( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete2081( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update2081( ) ;
                  }
               }
            }
            KeyVarsToRow81( ((SdtConexiones_Datos)bcConexiones.gxTpr_Datos.Item(nGXsfl_81_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_81_idx = 0;
            while ( nGXsfl_81_idx < bcConexiones.gxTpr_Datos.Count )
            {
               ReadRow2081( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound81 == 0 )
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
                  bcConexiones.gxTpr_Datos.RemoveElement(nGXsfl_81_idx);
                  nGXsfl_81_idx = (int)(nGXsfl_81_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey2081( ) ;
                  VarsToRow81( ((SdtConexiones_Datos)bcConexiones.gxTpr_Datos.Item(nGXsfl_81_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll2081( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_81 = 0;
         nIsMod_81 = 0;
      }

      protected void ProcessLevel2080( )
      {
         /* Save parent mode. */
         sMode80 = Gx_mode;
         ProcessNestedLevel2081( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode80;
         /* ' Update level parameters */
      }

      protected void EndLevel2080( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2080( ) ;
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

      public void ScanKeyStart2080( )
      {
         /* Scan By routine */
         /* Using cursor BC002012 */
         pr_default.execute(10, new Object[] {n552ConexionesID, A552ConexionesID});
         RcdFound80 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound80 = 1;
            A552ConexionesID = BC002012_A552ConexionesID[0];
            n552ConexionesID = BC002012_n552ConexionesID[0];
            A556ConexionesNombre = BC002012_A556ConexionesNombre[0];
            n556ConexionesNombre = BC002012_n556ConexionesNombre[0];
            A964ConexionesTipoIntegracion = BC002012_A964ConexionesTipoIntegracion[0];
            n964ConexionesTipoIntegracion = BC002012_n964ConexionesTipoIntegracion[0];
            A557ConexionesHost = BC002012_A557ConexionesHost[0];
            n557ConexionesHost = BC002012_n557ConexionesHost[0];
            A558ConexionesBaseURL = BC002012_A558ConexionesBaseURL[0];
            n558ConexionesBaseURL = BC002012_n558ConexionesBaseURL[0];
            A559ConexionesPort = BC002012_A559ConexionesPort[0];
            n559ConexionesPort = BC002012_n559ConexionesPort[0];
            A560ConexionesApiKey = BC002012_A560ConexionesApiKey[0];
            n560ConexionesApiKey = BC002012_n560ConexionesApiKey[0];
            A561ConexionesUsr = BC002012_A561ConexionesUsr[0];
            n561ConexionesUsr = BC002012_n561ConexionesUsr[0];
            A563ConexionesAux1 = BC002012_A563ConexionesAux1[0];
            n563ConexionesAux1 = BC002012_n563ConexionesAux1[0];
            A564ConexionesAux2 = BC002012_A564ConexionesAux2[0];
            n564ConexionesAux2 = BC002012_n564ConexionesAux2[0];
            A565ConexionesAux3 = BC002012_A565ConexionesAux3[0];
            n565ConexionesAux3 = BC002012_n565ConexionesAux3[0];
            A562ConexionesEstado = BC002012_A562ConexionesEstado[0];
            n562ConexionesEstado = BC002012_n562ConexionesEstado[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2080( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound80 = 0;
         ScanKeyLoad2080( ) ;
      }

      protected void ScanKeyLoad2080( )
      {
         sMode80 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound80 = 1;
            A552ConexionesID = BC002012_A552ConexionesID[0];
            n552ConexionesID = BC002012_n552ConexionesID[0];
            A556ConexionesNombre = BC002012_A556ConexionesNombre[0];
            n556ConexionesNombre = BC002012_n556ConexionesNombre[0];
            A964ConexionesTipoIntegracion = BC002012_A964ConexionesTipoIntegracion[0];
            n964ConexionesTipoIntegracion = BC002012_n964ConexionesTipoIntegracion[0];
            A557ConexionesHost = BC002012_A557ConexionesHost[0];
            n557ConexionesHost = BC002012_n557ConexionesHost[0];
            A558ConexionesBaseURL = BC002012_A558ConexionesBaseURL[0];
            n558ConexionesBaseURL = BC002012_n558ConexionesBaseURL[0];
            A559ConexionesPort = BC002012_A559ConexionesPort[0];
            n559ConexionesPort = BC002012_n559ConexionesPort[0];
            A560ConexionesApiKey = BC002012_A560ConexionesApiKey[0];
            n560ConexionesApiKey = BC002012_n560ConexionesApiKey[0];
            A561ConexionesUsr = BC002012_A561ConexionesUsr[0];
            n561ConexionesUsr = BC002012_n561ConexionesUsr[0];
            A563ConexionesAux1 = BC002012_A563ConexionesAux1[0];
            n563ConexionesAux1 = BC002012_n563ConexionesAux1[0];
            A564ConexionesAux2 = BC002012_A564ConexionesAux2[0];
            n564ConexionesAux2 = BC002012_n564ConexionesAux2[0];
            A565ConexionesAux3 = BC002012_A565ConexionesAux3[0];
            n565ConexionesAux3 = BC002012_n565ConexionesAux3[0];
            A562ConexionesEstado = BC002012_A562ConexionesEstado[0];
            n562ConexionesEstado = BC002012_n562ConexionesEstado[0];
         }
         Gx_mode = sMode80;
      }

      protected void ScanKeyEnd2080( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm2080( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2080( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2080( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2080( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2080( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2080( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2080( )
      {
      }

      protected void ZM2081( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z566ConexionesDatosInt = A566ConexionesDatosInt;
            Z567ConexionesDatosExt = A567ConexionesDatosExt;
            Z568ConexionesDatosDetalle = A568ConexionesDatosDetalle;
         }
         if ( GX_JID == -4 )
         {
            Z552ConexionesID = A552ConexionesID;
            Z553ConexionesDatosId = A553ConexionesDatosId;
            Z566ConexionesDatosInt = A566ConexionesDatosInt;
            Z567ConexionesDatosExt = A567ConexionesDatosExt;
            Z568ConexionesDatosDetalle = A568ConexionesDatosDetalle;
         }
      }

      protected void standaloneNotModal2081( )
      {
      }

      protected void standaloneModal2081( )
      {
      }

      protected void Load2081( )
      {
         /* Using cursor BC002013 */
         pr_default.execute(11, new Object[] {n552ConexionesID, A552ConexionesID, A553ConexionesDatosId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound81 = 1;
            A566ConexionesDatosInt = BC002013_A566ConexionesDatosInt[0];
            n566ConexionesDatosInt = BC002013_n566ConexionesDatosInt[0];
            A567ConexionesDatosExt = BC002013_A567ConexionesDatosExt[0];
            n567ConexionesDatosExt = BC002013_n567ConexionesDatosExt[0];
            A568ConexionesDatosDetalle = BC002013_A568ConexionesDatosDetalle[0];
            n568ConexionesDatosDetalle = BC002013_n568ConexionesDatosDetalle[0];
            ZM2081( -4) ;
         }
         pr_default.close(11);
         OnLoadActions2081( ) ;
      }

      protected void OnLoadActions2081( )
      {
      }

      protected void CheckExtendedTable2081( )
      {
         Gx_BScreen = 1;
         standaloneModal2081( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors2081( )
      {
      }

      protected void enableDisable2081( )
      {
      }

      protected void GetKey2081( )
      {
         /* Using cursor BC002014 */
         pr_default.execute(12, new Object[] {n552ConexionesID, A552ConexionesID, A553ConexionesDatosId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound81 = 1;
         }
         else
         {
            RcdFound81 = 0;
         }
         pr_default.close(12);
      }

      protected void getByPrimaryKey2081( )
      {
         /* Using cursor BC00203 */
         pr_default.execute(1, new Object[] {n552ConexionesID, A552ConexionesID, A553ConexionesDatosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2081( 4) ;
            RcdFound81 = 1;
            InitializeNonKey2081( ) ;
            A553ConexionesDatosId = BC00203_A553ConexionesDatosId[0];
            A566ConexionesDatosInt = BC00203_A566ConexionesDatosInt[0];
            n566ConexionesDatosInt = BC00203_n566ConexionesDatosInt[0];
            A567ConexionesDatosExt = BC00203_A567ConexionesDatosExt[0];
            n567ConexionesDatosExt = BC00203_n567ConexionesDatosExt[0];
            A568ConexionesDatosDetalle = BC00203_A568ConexionesDatosDetalle[0];
            n568ConexionesDatosDetalle = BC00203_n568ConexionesDatosDetalle[0];
            Z552ConexionesID = A552ConexionesID;
            Z553ConexionesDatosId = A553ConexionesDatosId;
            sMode81 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal2081( ) ;
            Load2081( ) ;
            Gx_mode = sMode81;
         }
         else
         {
            RcdFound81 = 0;
            InitializeNonKey2081( ) ;
            sMode81 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal2081( ) ;
            Gx_mode = sMode81;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes2081( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency2081( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00202 */
            pr_default.execute(0, new Object[] {n552ConexionesID, A552ConexionesID, A553ConexionesDatosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConexionesDatos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z566ConexionesDatosInt, BC00202_A566ConexionesDatosInt[0]) != 0 ) || ( StringUtil.StrCmp(Z567ConexionesDatosExt, BC00202_A567ConexionesDatosExt[0]) != 0 ) || ( StringUtil.StrCmp(Z568ConexionesDatosDetalle, BC00202_A568ConexionesDatosDetalle[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ConexionesDatos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2081( )
      {
         BeforeValidate2081( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2081( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2081( 0) ;
            CheckOptimisticConcurrency2081( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2081( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2081( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002015 */
                     pr_default.execute(13, new Object[] {n552ConexionesID, A552ConexionesID, A553ConexionesDatosId, n566ConexionesDatosInt, A566ConexionesDatosInt, n567ConexionesDatosExt, A567ConexionesDatosExt, n568ConexionesDatosDetalle, A568ConexionesDatosDetalle});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
                     if ( (pr_default.getStatus(13) == 1) )
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
               Load2081( ) ;
            }
            EndLevel2081( ) ;
         }
         CloseExtendedTableCursors2081( ) ;
      }

      protected void Update2081( )
      {
         BeforeValidate2081( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2081( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2081( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2081( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2081( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002016 */
                     pr_default.execute(14, new Object[] {n566ConexionesDatosInt, A566ConexionesDatosInt, n567ConexionesDatosExt, A567ConexionesDatosExt, n568ConexionesDatosDetalle, A568ConexionesDatosDetalle, n552ConexionesID, A552ConexionesID, A553ConexionesDatosId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConexionesDatos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2081( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey2081( ) ;
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
            EndLevel2081( ) ;
         }
         CloseExtendedTableCursors2081( ) ;
      }

      protected void DeferredUpdate2081( )
      {
      }

      protected void Delete2081( )
      {
         Gx_mode = "DLT";
         BeforeValidate2081( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2081( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2081( ) ;
            AfterConfirm2081( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2081( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002017 */
                  pr_default.execute(15, new Object[] {n552ConexionesID, A552ConexionesID, A553ConexionesDatosId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
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
         sMode81 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2081( ) ;
         Gx_mode = sMode81;
      }

      protected void OnDeleteControls2081( )
      {
         standaloneModal2081( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2081( )
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

      public void ScanKeyStart2081( )
      {
         /* Scan By routine */
         /* Using cursor BC002018 */
         pr_default.execute(16, new Object[] {n552ConexionesID, A552ConexionesID});
         RcdFound81 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound81 = 1;
            A553ConexionesDatosId = BC002018_A553ConexionesDatosId[0];
            A566ConexionesDatosInt = BC002018_A566ConexionesDatosInt[0];
            n566ConexionesDatosInt = BC002018_n566ConexionesDatosInt[0];
            A567ConexionesDatosExt = BC002018_A567ConexionesDatosExt[0];
            n567ConexionesDatosExt = BC002018_n567ConexionesDatosExt[0];
            A568ConexionesDatosDetalle = BC002018_A568ConexionesDatosDetalle[0];
            n568ConexionesDatosDetalle = BC002018_n568ConexionesDatosDetalle[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2081( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound81 = 0;
         ScanKeyLoad2081( ) ;
      }

      protected void ScanKeyLoad2081( )
      {
         sMode81 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound81 = 1;
            A553ConexionesDatosId = BC002018_A553ConexionesDatosId[0];
            A566ConexionesDatosInt = BC002018_A566ConexionesDatosInt[0];
            n566ConexionesDatosInt = BC002018_n566ConexionesDatosInt[0];
            A567ConexionesDatosExt = BC002018_A567ConexionesDatosExt[0];
            n567ConexionesDatosExt = BC002018_n567ConexionesDatosExt[0];
            A568ConexionesDatosDetalle = BC002018_A568ConexionesDatosDetalle[0];
            n568ConexionesDatosDetalle = BC002018_n568ConexionesDatosDetalle[0];
         }
         Gx_mode = sMode81;
      }

      protected void ScanKeyEnd2081( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm2081( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2081( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2081( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2081( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2081( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2081( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2081( )
      {
      }

      protected void send_integrity_lvl_hashes2081( )
      {
      }

      protected void send_integrity_lvl_hashes2080( )
      {
      }

      protected void AddRow2080( )
      {
         VarsToRow80( bcConexiones) ;
      }

      protected void ReadRow2080( )
      {
         RowToVars80( bcConexiones, 1) ;
      }

      protected void AddRow2081( )
      {
         SdtConexiones_Datos obj81;
         obj81 = new SdtConexiones_Datos(context);
         VarsToRow81( obj81) ;
         bcConexiones.gxTpr_Datos.Add(obj81, 0);
         obj81.gxTpr_Mode = "UPD";
         obj81.gxTpr_Modified = 0;
      }

      protected void ReadRow2081( )
      {
         nGXsfl_81_idx = (int)(nGXsfl_81_idx+1);
         RowToVars81( ((SdtConexiones_Datos)bcConexiones.gxTpr_Datos.Item(nGXsfl_81_idx)), 1) ;
      }

      protected void InitializeNonKey2080( )
      {
         A556ConexionesNombre = "";
         n556ConexionesNombre = false;
         A964ConexionesTipoIntegracion = 0;
         n964ConexionesTipoIntegracion = false;
         A557ConexionesHost = "";
         n557ConexionesHost = false;
         A558ConexionesBaseURL = "";
         n558ConexionesBaseURL = false;
         A559ConexionesPort = 0;
         n559ConexionesPort = false;
         A560ConexionesApiKey = "";
         n560ConexionesApiKey = false;
         A561ConexionesUsr = "";
         n561ConexionesUsr = false;
         A563ConexionesAux1 = "";
         n563ConexionesAux1 = false;
         A564ConexionesAux2 = "";
         n564ConexionesAux2 = false;
         A565ConexionesAux3 = "";
         n565ConexionesAux3 = false;
         A562ConexionesEstado = "";
         n562ConexionesEstado = false;
         Z556ConexionesNombre = "";
         Z964ConexionesTipoIntegracion = 0;
         Z557ConexionesHost = "";
         Z558ConexionesBaseURL = "";
         Z559ConexionesPort = 0;
         Z560ConexionesApiKey = "";
         Z561ConexionesUsr = "";
         Z563ConexionesAux1 = "";
         Z564ConexionesAux2 = "";
         Z565ConexionesAux3 = "";
         Z562ConexionesEstado = "";
      }

      protected void InitAll2080( )
      {
         A552ConexionesID = "";
         n552ConexionesID = false;
         InitializeNonKey2080( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey2081( )
      {
         A566ConexionesDatosInt = "";
         n566ConexionesDatosInt = false;
         A567ConexionesDatosExt = "";
         n567ConexionesDatosExt = false;
         A568ConexionesDatosDetalle = "";
         n568ConexionesDatosDetalle = false;
         Z566ConexionesDatosInt = "";
         Z567ConexionesDatosExt = "";
         Z568ConexionesDatosDetalle = "";
      }

      protected void InitAll2081( )
      {
         A553ConexionesDatosId = "";
         InitializeNonKey2081( ) ;
      }

      protected void StandaloneModalInsert2081( )
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

      public void VarsToRow80( SdtConexiones obj80 )
      {
         obj80.gxTpr_Mode = Gx_mode;
         obj80.gxTpr_Conexionesnombre = A556ConexionesNombre;
         obj80.gxTpr_Conexionestipointegracion = A964ConexionesTipoIntegracion;
         obj80.gxTpr_Conexioneshost = A557ConexionesHost;
         obj80.gxTpr_Conexionesbaseurl = A558ConexionesBaseURL;
         obj80.gxTpr_Conexionesport = A559ConexionesPort;
         obj80.gxTpr_Conexionesapikey = A560ConexionesApiKey;
         obj80.gxTpr_Conexionesusr = A561ConexionesUsr;
         obj80.gxTpr_Conexionesaux1 = A563ConexionesAux1;
         obj80.gxTpr_Conexionesaux2 = A564ConexionesAux2;
         obj80.gxTpr_Conexionesaux3 = A565ConexionesAux3;
         obj80.gxTpr_Conexionesestado = A562ConexionesEstado;
         obj80.gxTpr_Conexionesid = A552ConexionesID;
         obj80.gxTpr_Conexionesid_Z = Z552ConexionesID;
         obj80.gxTpr_Conexionesnombre_Z = Z556ConexionesNombre;
         obj80.gxTpr_Conexionestipointegracion_Z = Z964ConexionesTipoIntegracion;
         obj80.gxTpr_Conexioneshost_Z = Z557ConexionesHost;
         obj80.gxTpr_Conexionesbaseurl_Z = Z558ConexionesBaseURL;
         obj80.gxTpr_Conexionesport_Z = Z559ConexionesPort;
         obj80.gxTpr_Conexionesapikey_Z = Z560ConexionesApiKey;
         obj80.gxTpr_Conexionesusr_Z = Z561ConexionesUsr;
         obj80.gxTpr_Conexionesaux1_Z = Z563ConexionesAux1;
         obj80.gxTpr_Conexionesaux2_Z = Z564ConexionesAux2;
         obj80.gxTpr_Conexionesaux3_Z = Z565ConexionesAux3;
         obj80.gxTpr_Conexionesestado_Z = Z562ConexionesEstado;
         obj80.gxTpr_Conexionesid_N = (short)(Convert.ToInt16(n552ConexionesID));
         obj80.gxTpr_Conexionesnombre_N = (short)(Convert.ToInt16(n556ConexionesNombre));
         obj80.gxTpr_Conexionestipointegracion_N = (short)(Convert.ToInt16(n964ConexionesTipoIntegracion));
         obj80.gxTpr_Conexioneshost_N = (short)(Convert.ToInt16(n557ConexionesHost));
         obj80.gxTpr_Conexionesbaseurl_N = (short)(Convert.ToInt16(n558ConexionesBaseURL));
         obj80.gxTpr_Conexionesport_N = (short)(Convert.ToInt16(n559ConexionesPort));
         obj80.gxTpr_Conexionesapikey_N = (short)(Convert.ToInt16(n560ConexionesApiKey));
         obj80.gxTpr_Conexionesusr_N = (short)(Convert.ToInt16(n561ConexionesUsr));
         obj80.gxTpr_Conexionesaux1_N = (short)(Convert.ToInt16(n563ConexionesAux1));
         obj80.gxTpr_Conexionesaux2_N = (short)(Convert.ToInt16(n564ConexionesAux2));
         obj80.gxTpr_Conexionesaux3_N = (short)(Convert.ToInt16(n565ConexionesAux3));
         obj80.gxTpr_Conexionesestado_N = (short)(Convert.ToInt16(n562ConexionesEstado));
         obj80.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow80( SdtConexiones obj80 )
      {
         obj80.gxTpr_Conexionesid = A552ConexionesID;
         return  ;
      }

      public void RowToVars80( SdtConexiones obj80 ,
                               int forceLoad )
      {
         Gx_mode = obj80.gxTpr_Mode;
         A556ConexionesNombre = obj80.gxTpr_Conexionesnombre;
         n556ConexionesNombre = false;
         A964ConexionesTipoIntegracion = obj80.gxTpr_Conexionestipointegracion;
         n964ConexionesTipoIntegracion = false;
         A557ConexionesHost = obj80.gxTpr_Conexioneshost;
         n557ConexionesHost = false;
         A558ConexionesBaseURL = obj80.gxTpr_Conexionesbaseurl;
         n558ConexionesBaseURL = false;
         A559ConexionesPort = obj80.gxTpr_Conexionesport;
         n559ConexionesPort = false;
         A560ConexionesApiKey = obj80.gxTpr_Conexionesapikey;
         n560ConexionesApiKey = false;
         A561ConexionesUsr = obj80.gxTpr_Conexionesusr;
         n561ConexionesUsr = false;
         A563ConexionesAux1 = obj80.gxTpr_Conexionesaux1;
         n563ConexionesAux1 = false;
         A564ConexionesAux2 = obj80.gxTpr_Conexionesaux2;
         n564ConexionesAux2 = false;
         A565ConexionesAux3 = obj80.gxTpr_Conexionesaux3;
         n565ConexionesAux3 = false;
         A562ConexionesEstado = obj80.gxTpr_Conexionesestado;
         n562ConexionesEstado = false;
         A552ConexionesID = obj80.gxTpr_Conexionesid;
         n552ConexionesID = false;
         Z552ConexionesID = obj80.gxTpr_Conexionesid_Z;
         Z556ConexionesNombre = obj80.gxTpr_Conexionesnombre_Z;
         Z964ConexionesTipoIntegracion = obj80.gxTpr_Conexionestipointegracion_Z;
         Z557ConexionesHost = obj80.gxTpr_Conexioneshost_Z;
         Z558ConexionesBaseURL = obj80.gxTpr_Conexionesbaseurl_Z;
         Z559ConexionesPort = obj80.gxTpr_Conexionesport_Z;
         Z560ConexionesApiKey = obj80.gxTpr_Conexionesapikey_Z;
         Z561ConexionesUsr = obj80.gxTpr_Conexionesusr_Z;
         Z563ConexionesAux1 = obj80.gxTpr_Conexionesaux1_Z;
         Z564ConexionesAux2 = obj80.gxTpr_Conexionesaux2_Z;
         Z565ConexionesAux3 = obj80.gxTpr_Conexionesaux3_Z;
         Z562ConexionesEstado = obj80.gxTpr_Conexionesestado_Z;
         n552ConexionesID = (bool)(Convert.ToBoolean(obj80.gxTpr_Conexionesid_N));
         n556ConexionesNombre = (bool)(Convert.ToBoolean(obj80.gxTpr_Conexionesnombre_N));
         n964ConexionesTipoIntegracion = (bool)(Convert.ToBoolean(obj80.gxTpr_Conexionestipointegracion_N));
         n557ConexionesHost = (bool)(Convert.ToBoolean(obj80.gxTpr_Conexioneshost_N));
         n558ConexionesBaseURL = (bool)(Convert.ToBoolean(obj80.gxTpr_Conexionesbaseurl_N));
         n559ConexionesPort = (bool)(Convert.ToBoolean(obj80.gxTpr_Conexionesport_N));
         n560ConexionesApiKey = (bool)(Convert.ToBoolean(obj80.gxTpr_Conexionesapikey_N));
         n561ConexionesUsr = (bool)(Convert.ToBoolean(obj80.gxTpr_Conexionesusr_N));
         n563ConexionesAux1 = (bool)(Convert.ToBoolean(obj80.gxTpr_Conexionesaux1_N));
         n564ConexionesAux2 = (bool)(Convert.ToBoolean(obj80.gxTpr_Conexionesaux2_N));
         n565ConexionesAux3 = (bool)(Convert.ToBoolean(obj80.gxTpr_Conexionesaux3_N));
         n562ConexionesEstado = (bool)(Convert.ToBoolean(obj80.gxTpr_Conexionesestado_N));
         Gx_mode = obj80.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow81( SdtConexiones_Datos obj81 )
      {
         obj81.gxTpr_Mode = Gx_mode;
         obj81.gxTpr_Conexionesdatosint = A566ConexionesDatosInt;
         obj81.gxTpr_Conexionesdatosext = A567ConexionesDatosExt;
         obj81.gxTpr_Conexionesdatosdetalle = A568ConexionesDatosDetalle;
         obj81.gxTpr_Conexionesdatosid = A553ConexionesDatosId;
         obj81.gxTpr_Conexionesdatosid_Z = Z553ConexionesDatosId;
         obj81.gxTpr_Conexionesdatosint_Z = Z566ConexionesDatosInt;
         obj81.gxTpr_Conexionesdatosext_Z = Z567ConexionesDatosExt;
         obj81.gxTpr_Conexionesdatosdetalle_Z = Z568ConexionesDatosDetalle;
         obj81.gxTpr_Conexionesdatosint_N = (short)(Convert.ToInt16(n566ConexionesDatosInt));
         obj81.gxTpr_Conexionesdatosext_N = (short)(Convert.ToInt16(n567ConexionesDatosExt));
         obj81.gxTpr_Conexionesdatosdetalle_N = (short)(Convert.ToInt16(n568ConexionesDatosDetalle));
         obj81.gxTpr_Modified = nIsMod_81;
         return  ;
      }

      public void KeyVarsToRow81( SdtConexiones_Datos obj81 )
      {
         obj81.gxTpr_Conexionesdatosid = A553ConexionesDatosId;
         return  ;
      }

      public void RowToVars81( SdtConexiones_Datos obj81 ,
                               int forceLoad )
      {
         Gx_mode = obj81.gxTpr_Mode;
         A566ConexionesDatosInt = obj81.gxTpr_Conexionesdatosint;
         n566ConexionesDatosInt = false;
         A567ConexionesDatosExt = obj81.gxTpr_Conexionesdatosext;
         n567ConexionesDatosExt = false;
         A568ConexionesDatosDetalle = obj81.gxTpr_Conexionesdatosdetalle;
         n568ConexionesDatosDetalle = false;
         A553ConexionesDatosId = obj81.gxTpr_Conexionesdatosid;
         Z553ConexionesDatosId = obj81.gxTpr_Conexionesdatosid_Z;
         Z566ConexionesDatosInt = obj81.gxTpr_Conexionesdatosint_Z;
         Z567ConexionesDatosExt = obj81.gxTpr_Conexionesdatosext_Z;
         Z568ConexionesDatosDetalle = obj81.gxTpr_Conexionesdatosdetalle_Z;
         n566ConexionesDatosInt = (bool)(Convert.ToBoolean(obj81.gxTpr_Conexionesdatosint_N));
         n567ConexionesDatosExt = (bool)(Convert.ToBoolean(obj81.gxTpr_Conexionesdatosext_N));
         n568ConexionesDatosDetalle = (bool)(Convert.ToBoolean(obj81.gxTpr_Conexionesdatosdetalle_N));
         nIsMod_81 = obj81.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A552ConexionesID = (string)getParm(obj,0);
         n552ConexionesID = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2080( ) ;
         ScanKeyStart2080( ) ;
         if ( RcdFound80 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z552ConexionesID = A552ConexionesID;
         }
         ZM2080( -3) ;
         OnLoadActions2080( ) ;
         AddRow2080( ) ;
         bcConexiones.gxTpr_Datos.ClearCollection();
         if ( RcdFound80 == 1 )
         {
            ScanKeyStart2081( ) ;
            nGXsfl_81_idx = 1;
            while ( RcdFound81 != 0 )
            {
               Z552ConexionesID = A552ConexionesID;
               Z553ConexionesDatosId = A553ConexionesDatosId;
               ZM2081( -4) ;
               OnLoadActions2081( ) ;
               nRcdExists_81 = 1;
               nIsMod_81 = 0;
               AddRow2081( ) ;
               nGXsfl_81_idx = (int)(nGXsfl_81_idx+1);
               ScanKeyNext2081( ) ;
            }
            ScanKeyEnd2081( ) ;
         }
         ScanKeyEnd2080( ) ;
         if ( RcdFound80 == 0 )
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
         RowToVars80( bcConexiones, 0) ;
         ScanKeyStart2080( ) ;
         if ( RcdFound80 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z552ConexionesID = A552ConexionesID;
         }
         ZM2080( -3) ;
         OnLoadActions2080( ) ;
         AddRow2080( ) ;
         bcConexiones.gxTpr_Datos.ClearCollection();
         if ( RcdFound80 == 1 )
         {
            ScanKeyStart2081( ) ;
            nGXsfl_81_idx = 1;
            while ( RcdFound81 != 0 )
            {
               Z552ConexionesID = A552ConexionesID;
               Z553ConexionesDatosId = A553ConexionesDatosId;
               ZM2081( -4) ;
               OnLoadActions2081( ) ;
               nRcdExists_81 = 1;
               nIsMod_81 = 0;
               AddRow2081( ) ;
               nGXsfl_81_idx = (int)(nGXsfl_81_idx+1);
               ScanKeyNext2081( ) ;
            }
            ScanKeyEnd2081( ) ;
         }
         ScanKeyEnd2080( ) ;
         if ( RcdFound80 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2080( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2080( ) ;
         }
         else
         {
            if ( RcdFound80 == 1 )
            {
               if ( StringUtil.StrCmp(A552ConexionesID, Z552ConexionesID) != 0 )
               {
                  A552ConexionesID = Z552ConexionesID;
                  n552ConexionesID = false;
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
                  Update2080( ) ;
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
                  if ( StringUtil.StrCmp(A552ConexionesID, Z552ConexionesID) != 0 )
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
                        Insert2080( ) ;
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
                        Insert2080( ) ;
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
         RowToVars80( bcConexiones, 1) ;
         SaveImpl( ) ;
         VarsToRow80( bcConexiones) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars80( bcConexiones, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2080( ) ;
         AfterTrn( ) ;
         VarsToRow80( bcConexiones) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow80( bcConexiones) ;
         }
         else
         {
            SdtConexiones auxBC = new SdtConexiones(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A552ConexionesID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcConexiones);
               auxBC.Save();
               bcConexiones.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars80( bcConexiones, 1) ;
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
         RowToVars80( bcConexiones, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2080( ) ;
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
               VarsToRow80( bcConexiones) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow80( bcConexiones) ;
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
         RowToVars80( bcConexiones, 0) ;
         GetKey2080( ) ;
         if ( RcdFound80 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A552ConexionesID, Z552ConexionesID) != 0 )
            {
               A552ConexionesID = Z552ConexionesID;
               n552ConexionesID = false;
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
            if ( StringUtil.StrCmp(A552ConexionesID, Z552ConexionesID) != 0 )
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
         context.RollbackDataStores("conexiones_bc",pr_default);
         VarsToRow80( bcConexiones) ;
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
         Gx_mode = bcConexiones.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcConexiones.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcConexiones )
         {
            bcConexiones = (SdtConexiones)(sdt);
            if ( StringUtil.StrCmp(bcConexiones.gxTpr_Mode, "") == 0 )
            {
               bcConexiones.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow80( bcConexiones) ;
            }
            else
            {
               RowToVars80( bcConexiones, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcConexiones.gxTpr_Mode, "") == 0 )
            {
               bcConexiones.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars80( bcConexiones, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtConexiones Conexiones_BC
      {
         get {
            return bcConexiones ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z552ConexionesID = "";
         A552ConexionesID = "";
         sMode80 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV15Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z556ConexionesNombre = "";
         A556ConexionesNombre = "";
         Z557ConexionesHost = "";
         A557ConexionesHost = "";
         Z558ConexionesBaseURL = "";
         A558ConexionesBaseURL = "";
         Z560ConexionesApiKey = "";
         A560ConexionesApiKey = "";
         Z561ConexionesUsr = "";
         A561ConexionesUsr = "";
         Z563ConexionesAux1 = "";
         A563ConexionesAux1 = "";
         Z564ConexionesAux2 = "";
         A564ConexionesAux2 = "";
         Z565ConexionesAux3 = "";
         A565ConexionesAux3 = "";
         Z562ConexionesEstado = "";
         A562ConexionesEstado = "";
         BC00206_A552ConexionesID = new string[] {""} ;
         BC00206_n552ConexionesID = new bool[] {false} ;
         BC00206_A556ConexionesNombre = new string[] {""} ;
         BC00206_n556ConexionesNombre = new bool[] {false} ;
         BC00206_A964ConexionesTipoIntegracion = new short[1] ;
         BC00206_n964ConexionesTipoIntegracion = new bool[] {false} ;
         BC00206_A557ConexionesHost = new string[] {""} ;
         BC00206_n557ConexionesHost = new bool[] {false} ;
         BC00206_A558ConexionesBaseURL = new string[] {""} ;
         BC00206_n558ConexionesBaseURL = new bool[] {false} ;
         BC00206_A559ConexionesPort = new int[1] ;
         BC00206_n559ConexionesPort = new bool[] {false} ;
         BC00206_A560ConexionesApiKey = new string[] {""} ;
         BC00206_n560ConexionesApiKey = new bool[] {false} ;
         BC00206_A561ConexionesUsr = new string[] {""} ;
         BC00206_n561ConexionesUsr = new bool[] {false} ;
         BC00206_A563ConexionesAux1 = new string[] {""} ;
         BC00206_n563ConexionesAux1 = new bool[] {false} ;
         BC00206_A564ConexionesAux2 = new string[] {""} ;
         BC00206_n564ConexionesAux2 = new bool[] {false} ;
         BC00206_A565ConexionesAux3 = new string[] {""} ;
         BC00206_n565ConexionesAux3 = new bool[] {false} ;
         BC00206_A562ConexionesEstado = new string[] {""} ;
         BC00206_n562ConexionesEstado = new bool[] {false} ;
         BC00207_A552ConexionesID = new string[] {""} ;
         BC00207_n552ConexionesID = new bool[] {false} ;
         BC00205_A552ConexionesID = new string[] {""} ;
         BC00205_n552ConexionesID = new bool[] {false} ;
         BC00205_A556ConexionesNombre = new string[] {""} ;
         BC00205_n556ConexionesNombre = new bool[] {false} ;
         BC00205_A964ConexionesTipoIntegracion = new short[1] ;
         BC00205_n964ConexionesTipoIntegracion = new bool[] {false} ;
         BC00205_A557ConexionesHost = new string[] {""} ;
         BC00205_n557ConexionesHost = new bool[] {false} ;
         BC00205_A558ConexionesBaseURL = new string[] {""} ;
         BC00205_n558ConexionesBaseURL = new bool[] {false} ;
         BC00205_A559ConexionesPort = new int[1] ;
         BC00205_n559ConexionesPort = new bool[] {false} ;
         BC00205_A560ConexionesApiKey = new string[] {""} ;
         BC00205_n560ConexionesApiKey = new bool[] {false} ;
         BC00205_A561ConexionesUsr = new string[] {""} ;
         BC00205_n561ConexionesUsr = new bool[] {false} ;
         BC00205_A563ConexionesAux1 = new string[] {""} ;
         BC00205_n563ConexionesAux1 = new bool[] {false} ;
         BC00205_A564ConexionesAux2 = new string[] {""} ;
         BC00205_n564ConexionesAux2 = new bool[] {false} ;
         BC00205_A565ConexionesAux3 = new string[] {""} ;
         BC00205_n565ConexionesAux3 = new bool[] {false} ;
         BC00205_A562ConexionesEstado = new string[] {""} ;
         BC00205_n562ConexionesEstado = new bool[] {false} ;
         BC00204_A552ConexionesID = new string[] {""} ;
         BC00204_n552ConexionesID = new bool[] {false} ;
         BC00204_A556ConexionesNombre = new string[] {""} ;
         BC00204_n556ConexionesNombre = new bool[] {false} ;
         BC00204_A964ConexionesTipoIntegracion = new short[1] ;
         BC00204_n964ConexionesTipoIntegracion = new bool[] {false} ;
         BC00204_A557ConexionesHost = new string[] {""} ;
         BC00204_n557ConexionesHost = new bool[] {false} ;
         BC00204_A558ConexionesBaseURL = new string[] {""} ;
         BC00204_n558ConexionesBaseURL = new bool[] {false} ;
         BC00204_A559ConexionesPort = new int[1] ;
         BC00204_n559ConexionesPort = new bool[] {false} ;
         BC00204_A560ConexionesApiKey = new string[] {""} ;
         BC00204_n560ConexionesApiKey = new bool[] {false} ;
         BC00204_A561ConexionesUsr = new string[] {""} ;
         BC00204_n561ConexionesUsr = new bool[] {false} ;
         BC00204_A563ConexionesAux1 = new string[] {""} ;
         BC00204_n563ConexionesAux1 = new bool[] {false} ;
         BC00204_A564ConexionesAux2 = new string[] {""} ;
         BC00204_n564ConexionesAux2 = new bool[] {false} ;
         BC00204_A565ConexionesAux3 = new string[] {""} ;
         BC00204_n565ConexionesAux3 = new bool[] {false} ;
         BC00204_A562ConexionesEstado = new string[] {""} ;
         BC00204_n562ConexionesEstado = new bool[] {false} ;
         BC002011_A918MapeoID = new long[1] ;
         BC002012_A552ConexionesID = new string[] {""} ;
         BC002012_n552ConexionesID = new bool[] {false} ;
         BC002012_A556ConexionesNombre = new string[] {""} ;
         BC002012_n556ConexionesNombre = new bool[] {false} ;
         BC002012_A964ConexionesTipoIntegracion = new short[1] ;
         BC002012_n964ConexionesTipoIntegracion = new bool[] {false} ;
         BC002012_A557ConexionesHost = new string[] {""} ;
         BC002012_n557ConexionesHost = new bool[] {false} ;
         BC002012_A558ConexionesBaseURL = new string[] {""} ;
         BC002012_n558ConexionesBaseURL = new bool[] {false} ;
         BC002012_A559ConexionesPort = new int[1] ;
         BC002012_n559ConexionesPort = new bool[] {false} ;
         BC002012_A560ConexionesApiKey = new string[] {""} ;
         BC002012_n560ConexionesApiKey = new bool[] {false} ;
         BC002012_A561ConexionesUsr = new string[] {""} ;
         BC002012_n561ConexionesUsr = new bool[] {false} ;
         BC002012_A563ConexionesAux1 = new string[] {""} ;
         BC002012_n563ConexionesAux1 = new bool[] {false} ;
         BC002012_A564ConexionesAux2 = new string[] {""} ;
         BC002012_n564ConexionesAux2 = new bool[] {false} ;
         BC002012_A565ConexionesAux3 = new string[] {""} ;
         BC002012_n565ConexionesAux3 = new bool[] {false} ;
         BC002012_A562ConexionesEstado = new string[] {""} ;
         BC002012_n562ConexionesEstado = new bool[] {false} ;
         Z566ConexionesDatosInt = "";
         A566ConexionesDatosInt = "";
         Z567ConexionesDatosExt = "";
         A567ConexionesDatosExt = "";
         Z568ConexionesDatosDetalle = "";
         A568ConexionesDatosDetalle = "";
         Z553ConexionesDatosId = "";
         A553ConexionesDatosId = "";
         BC002013_A552ConexionesID = new string[] {""} ;
         BC002013_n552ConexionesID = new bool[] {false} ;
         BC002013_A553ConexionesDatosId = new string[] {""} ;
         BC002013_A566ConexionesDatosInt = new string[] {""} ;
         BC002013_n566ConexionesDatosInt = new bool[] {false} ;
         BC002013_A567ConexionesDatosExt = new string[] {""} ;
         BC002013_n567ConexionesDatosExt = new bool[] {false} ;
         BC002013_A568ConexionesDatosDetalle = new string[] {""} ;
         BC002013_n568ConexionesDatosDetalle = new bool[] {false} ;
         BC002014_A552ConexionesID = new string[] {""} ;
         BC002014_n552ConexionesID = new bool[] {false} ;
         BC002014_A553ConexionesDatosId = new string[] {""} ;
         BC00203_A552ConexionesID = new string[] {""} ;
         BC00203_n552ConexionesID = new bool[] {false} ;
         BC00203_A553ConexionesDatosId = new string[] {""} ;
         BC00203_A566ConexionesDatosInt = new string[] {""} ;
         BC00203_n566ConexionesDatosInt = new bool[] {false} ;
         BC00203_A567ConexionesDatosExt = new string[] {""} ;
         BC00203_n567ConexionesDatosExt = new bool[] {false} ;
         BC00203_A568ConexionesDatosDetalle = new string[] {""} ;
         BC00203_n568ConexionesDatosDetalle = new bool[] {false} ;
         sMode81 = "";
         BC00202_A552ConexionesID = new string[] {""} ;
         BC00202_n552ConexionesID = new bool[] {false} ;
         BC00202_A553ConexionesDatosId = new string[] {""} ;
         BC00202_A566ConexionesDatosInt = new string[] {""} ;
         BC00202_n566ConexionesDatosInt = new bool[] {false} ;
         BC00202_A567ConexionesDatosExt = new string[] {""} ;
         BC00202_n567ConexionesDatosExt = new bool[] {false} ;
         BC00202_A568ConexionesDatosDetalle = new string[] {""} ;
         BC00202_n568ConexionesDatosDetalle = new bool[] {false} ;
         BC002018_A552ConexionesID = new string[] {""} ;
         BC002018_n552ConexionesID = new bool[] {false} ;
         BC002018_A553ConexionesDatosId = new string[] {""} ;
         BC002018_A566ConexionesDatosInt = new string[] {""} ;
         BC002018_n566ConexionesDatosInt = new bool[] {false} ;
         BC002018_A567ConexionesDatosExt = new string[] {""} ;
         BC002018_n567ConexionesDatosExt = new bool[] {false} ;
         BC002018_A568ConexionesDatosDetalle = new string[] {""} ;
         BC002018_n568ConexionesDatosDetalle = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.conexiones_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.conexiones_bc__default(),
            new Object[][] {
                new Object[] {
               BC00202_A552ConexionesID, BC00202_A553ConexionesDatosId, BC00202_A566ConexionesDatosInt, BC00202_n566ConexionesDatosInt, BC00202_A567ConexionesDatosExt, BC00202_n567ConexionesDatosExt, BC00202_A568ConexionesDatosDetalle, BC00202_n568ConexionesDatosDetalle
               }
               , new Object[] {
               BC00203_A552ConexionesID, BC00203_A553ConexionesDatosId, BC00203_A566ConexionesDatosInt, BC00203_n566ConexionesDatosInt, BC00203_A567ConexionesDatosExt, BC00203_n567ConexionesDatosExt, BC00203_A568ConexionesDatosDetalle, BC00203_n568ConexionesDatosDetalle
               }
               , new Object[] {
               BC00204_A552ConexionesID, BC00204_A556ConexionesNombre, BC00204_n556ConexionesNombre, BC00204_A964ConexionesTipoIntegracion, BC00204_n964ConexionesTipoIntegracion, BC00204_A557ConexionesHost, BC00204_n557ConexionesHost, BC00204_A558ConexionesBaseURL, BC00204_n558ConexionesBaseURL, BC00204_A559ConexionesPort,
               BC00204_n559ConexionesPort, BC00204_A560ConexionesApiKey, BC00204_n560ConexionesApiKey, BC00204_A561ConexionesUsr, BC00204_n561ConexionesUsr, BC00204_A563ConexionesAux1, BC00204_n563ConexionesAux1, BC00204_A564ConexionesAux2, BC00204_n564ConexionesAux2, BC00204_A565ConexionesAux3,
               BC00204_n565ConexionesAux3, BC00204_A562ConexionesEstado, BC00204_n562ConexionesEstado
               }
               , new Object[] {
               BC00205_A552ConexionesID, BC00205_A556ConexionesNombre, BC00205_n556ConexionesNombre, BC00205_A964ConexionesTipoIntegracion, BC00205_n964ConexionesTipoIntegracion, BC00205_A557ConexionesHost, BC00205_n557ConexionesHost, BC00205_A558ConexionesBaseURL, BC00205_n558ConexionesBaseURL, BC00205_A559ConexionesPort,
               BC00205_n559ConexionesPort, BC00205_A560ConexionesApiKey, BC00205_n560ConexionesApiKey, BC00205_A561ConexionesUsr, BC00205_n561ConexionesUsr, BC00205_A563ConexionesAux1, BC00205_n563ConexionesAux1, BC00205_A564ConexionesAux2, BC00205_n564ConexionesAux2, BC00205_A565ConexionesAux3,
               BC00205_n565ConexionesAux3, BC00205_A562ConexionesEstado, BC00205_n562ConexionesEstado
               }
               , new Object[] {
               BC00206_A552ConexionesID, BC00206_A556ConexionesNombre, BC00206_n556ConexionesNombre, BC00206_A964ConexionesTipoIntegracion, BC00206_n964ConexionesTipoIntegracion, BC00206_A557ConexionesHost, BC00206_n557ConexionesHost, BC00206_A558ConexionesBaseURL, BC00206_n558ConexionesBaseURL, BC00206_A559ConexionesPort,
               BC00206_n559ConexionesPort, BC00206_A560ConexionesApiKey, BC00206_n560ConexionesApiKey, BC00206_A561ConexionesUsr, BC00206_n561ConexionesUsr, BC00206_A563ConexionesAux1, BC00206_n563ConexionesAux1, BC00206_A564ConexionesAux2, BC00206_n564ConexionesAux2, BC00206_A565ConexionesAux3,
               BC00206_n565ConexionesAux3, BC00206_A562ConexionesEstado, BC00206_n562ConexionesEstado
               }
               , new Object[] {
               BC00207_A552ConexionesID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002011_A918MapeoID
               }
               , new Object[] {
               BC002012_A552ConexionesID, BC002012_A556ConexionesNombre, BC002012_n556ConexionesNombre, BC002012_A964ConexionesTipoIntegracion, BC002012_n964ConexionesTipoIntegracion, BC002012_A557ConexionesHost, BC002012_n557ConexionesHost, BC002012_A558ConexionesBaseURL, BC002012_n558ConexionesBaseURL, BC002012_A559ConexionesPort,
               BC002012_n559ConexionesPort, BC002012_A560ConexionesApiKey, BC002012_n560ConexionesApiKey, BC002012_A561ConexionesUsr, BC002012_n561ConexionesUsr, BC002012_A563ConexionesAux1, BC002012_n563ConexionesAux1, BC002012_A564ConexionesAux2, BC002012_n564ConexionesAux2, BC002012_A565ConexionesAux3,
               BC002012_n565ConexionesAux3, BC002012_A562ConexionesEstado, BC002012_n562ConexionesEstado
               }
               , new Object[] {
               BC002013_A552ConexionesID, BC002013_A553ConexionesDatosId, BC002013_A566ConexionesDatosInt, BC002013_n566ConexionesDatosInt, BC002013_A567ConexionesDatosExt, BC002013_n567ConexionesDatosExt, BC002013_A568ConexionesDatosDetalle, BC002013_n568ConexionesDatosDetalle
               }
               , new Object[] {
               BC002014_A552ConexionesID, BC002014_A553ConexionesDatosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002018_A552ConexionesID, BC002018_A553ConexionesDatosId, BC002018_A566ConexionesDatosInt, BC002018_n566ConexionesDatosInt, BC002018_A567ConexionesDatosExt, BC002018_n567ConexionesDatosExt, BC002018_A568ConexionesDatosDetalle, BC002018_n568ConexionesDatosDetalle
               }
            }
         );
         AV15Pgmname = "Conexiones_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12202 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_81 ;
      private short RcdFound81 ;
      private short Z964ConexionesTipoIntegracion ;
      private short A964ConexionesTipoIntegracion ;
      private short RcdFound80 ;
      private short nRcdExists_81 ;
      private short Gx_BScreen ;
      private short Gxremove81 ;
      private int trnEnded ;
      private int nGXsfl_81_idx=1 ;
      private int Z559ConexionesPort ;
      private int A559ConexionesPort ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z552ConexionesID ;
      private string A552ConexionesID ;
      private string sMode80 ;
      private string AV15Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Z556ConexionesNombre ;
      private string A556ConexionesNombre ;
      private string Z557ConexionesHost ;
      private string A557ConexionesHost ;
      private string Z558ConexionesBaseURL ;
      private string A558ConexionesBaseURL ;
      private string Z560ConexionesApiKey ;
      private string A560ConexionesApiKey ;
      private string Z561ConexionesUsr ;
      private string A561ConexionesUsr ;
      private string Z563ConexionesAux1 ;
      private string A563ConexionesAux1 ;
      private string Z564ConexionesAux2 ;
      private string A564ConexionesAux2 ;
      private string Z565ConexionesAux3 ;
      private string A565ConexionesAux3 ;
      private string Z562ConexionesEstado ;
      private string A562ConexionesEstado ;
      private string Z566ConexionesDatosInt ;
      private string A566ConexionesDatosInt ;
      private string Z567ConexionesDatosExt ;
      private string A567ConexionesDatosExt ;
      private string Z568ConexionesDatosDetalle ;
      private string A568ConexionesDatosDetalle ;
      private string Z553ConexionesDatosId ;
      private string A553ConexionesDatosId ;
      private string sMode81 ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool n552ConexionesID ;
      private bool n556ConexionesNombre ;
      private bool n964ConexionesTipoIntegracion ;
      private bool n557ConexionesHost ;
      private bool n558ConexionesBaseURL ;
      private bool n559ConexionesPort ;
      private bool n560ConexionesApiKey ;
      private bool n561ConexionesUsr ;
      private bool n563ConexionesAux1 ;
      private bool n564ConexionesAux2 ;
      private bool n565ConexionesAux3 ;
      private bool n562ConexionesEstado ;
      private bool Gx_longc ;
      private bool n566ConexionesDatosInt ;
      private bool n567ConexionesDatosExt ;
      private bool n568ConexionesDatosDetalle ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtConexiones bcConexiones ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private string[] BC00206_A552ConexionesID ;
      private bool[] BC00206_n552ConexionesID ;
      private string[] BC00206_A556ConexionesNombre ;
      private bool[] BC00206_n556ConexionesNombre ;
      private short[] BC00206_A964ConexionesTipoIntegracion ;
      private bool[] BC00206_n964ConexionesTipoIntegracion ;
      private string[] BC00206_A557ConexionesHost ;
      private bool[] BC00206_n557ConexionesHost ;
      private string[] BC00206_A558ConexionesBaseURL ;
      private bool[] BC00206_n558ConexionesBaseURL ;
      private int[] BC00206_A559ConexionesPort ;
      private bool[] BC00206_n559ConexionesPort ;
      private string[] BC00206_A560ConexionesApiKey ;
      private bool[] BC00206_n560ConexionesApiKey ;
      private string[] BC00206_A561ConexionesUsr ;
      private bool[] BC00206_n561ConexionesUsr ;
      private string[] BC00206_A563ConexionesAux1 ;
      private bool[] BC00206_n563ConexionesAux1 ;
      private string[] BC00206_A564ConexionesAux2 ;
      private bool[] BC00206_n564ConexionesAux2 ;
      private string[] BC00206_A565ConexionesAux3 ;
      private bool[] BC00206_n565ConexionesAux3 ;
      private string[] BC00206_A562ConexionesEstado ;
      private bool[] BC00206_n562ConexionesEstado ;
      private string[] BC00207_A552ConexionesID ;
      private bool[] BC00207_n552ConexionesID ;
      private string[] BC00205_A552ConexionesID ;
      private bool[] BC00205_n552ConexionesID ;
      private string[] BC00205_A556ConexionesNombre ;
      private bool[] BC00205_n556ConexionesNombre ;
      private short[] BC00205_A964ConexionesTipoIntegracion ;
      private bool[] BC00205_n964ConexionesTipoIntegracion ;
      private string[] BC00205_A557ConexionesHost ;
      private bool[] BC00205_n557ConexionesHost ;
      private string[] BC00205_A558ConexionesBaseURL ;
      private bool[] BC00205_n558ConexionesBaseURL ;
      private int[] BC00205_A559ConexionesPort ;
      private bool[] BC00205_n559ConexionesPort ;
      private string[] BC00205_A560ConexionesApiKey ;
      private bool[] BC00205_n560ConexionesApiKey ;
      private string[] BC00205_A561ConexionesUsr ;
      private bool[] BC00205_n561ConexionesUsr ;
      private string[] BC00205_A563ConexionesAux1 ;
      private bool[] BC00205_n563ConexionesAux1 ;
      private string[] BC00205_A564ConexionesAux2 ;
      private bool[] BC00205_n564ConexionesAux2 ;
      private string[] BC00205_A565ConexionesAux3 ;
      private bool[] BC00205_n565ConexionesAux3 ;
      private string[] BC00205_A562ConexionesEstado ;
      private bool[] BC00205_n562ConexionesEstado ;
      private string[] BC00204_A552ConexionesID ;
      private bool[] BC00204_n552ConexionesID ;
      private string[] BC00204_A556ConexionesNombre ;
      private bool[] BC00204_n556ConexionesNombre ;
      private short[] BC00204_A964ConexionesTipoIntegracion ;
      private bool[] BC00204_n964ConexionesTipoIntegracion ;
      private string[] BC00204_A557ConexionesHost ;
      private bool[] BC00204_n557ConexionesHost ;
      private string[] BC00204_A558ConexionesBaseURL ;
      private bool[] BC00204_n558ConexionesBaseURL ;
      private int[] BC00204_A559ConexionesPort ;
      private bool[] BC00204_n559ConexionesPort ;
      private string[] BC00204_A560ConexionesApiKey ;
      private bool[] BC00204_n560ConexionesApiKey ;
      private string[] BC00204_A561ConexionesUsr ;
      private bool[] BC00204_n561ConexionesUsr ;
      private string[] BC00204_A563ConexionesAux1 ;
      private bool[] BC00204_n563ConexionesAux1 ;
      private string[] BC00204_A564ConexionesAux2 ;
      private bool[] BC00204_n564ConexionesAux2 ;
      private string[] BC00204_A565ConexionesAux3 ;
      private bool[] BC00204_n565ConexionesAux3 ;
      private string[] BC00204_A562ConexionesEstado ;
      private bool[] BC00204_n562ConexionesEstado ;
      private long[] BC002011_A918MapeoID ;
      private string[] BC002012_A552ConexionesID ;
      private bool[] BC002012_n552ConexionesID ;
      private string[] BC002012_A556ConexionesNombre ;
      private bool[] BC002012_n556ConexionesNombre ;
      private short[] BC002012_A964ConexionesTipoIntegracion ;
      private bool[] BC002012_n964ConexionesTipoIntegracion ;
      private string[] BC002012_A557ConexionesHost ;
      private bool[] BC002012_n557ConexionesHost ;
      private string[] BC002012_A558ConexionesBaseURL ;
      private bool[] BC002012_n558ConexionesBaseURL ;
      private int[] BC002012_A559ConexionesPort ;
      private bool[] BC002012_n559ConexionesPort ;
      private string[] BC002012_A560ConexionesApiKey ;
      private bool[] BC002012_n560ConexionesApiKey ;
      private string[] BC002012_A561ConexionesUsr ;
      private bool[] BC002012_n561ConexionesUsr ;
      private string[] BC002012_A563ConexionesAux1 ;
      private bool[] BC002012_n563ConexionesAux1 ;
      private string[] BC002012_A564ConexionesAux2 ;
      private bool[] BC002012_n564ConexionesAux2 ;
      private string[] BC002012_A565ConexionesAux3 ;
      private bool[] BC002012_n565ConexionesAux3 ;
      private string[] BC002012_A562ConexionesEstado ;
      private bool[] BC002012_n562ConexionesEstado ;
      private string[] BC002013_A552ConexionesID ;
      private bool[] BC002013_n552ConexionesID ;
      private string[] BC002013_A553ConexionesDatosId ;
      private string[] BC002013_A566ConexionesDatosInt ;
      private bool[] BC002013_n566ConexionesDatosInt ;
      private string[] BC002013_A567ConexionesDatosExt ;
      private bool[] BC002013_n567ConexionesDatosExt ;
      private string[] BC002013_A568ConexionesDatosDetalle ;
      private bool[] BC002013_n568ConexionesDatosDetalle ;
      private string[] BC002014_A552ConexionesID ;
      private bool[] BC002014_n552ConexionesID ;
      private string[] BC002014_A553ConexionesDatosId ;
      private string[] BC00203_A552ConexionesID ;
      private bool[] BC00203_n552ConexionesID ;
      private string[] BC00203_A553ConexionesDatosId ;
      private string[] BC00203_A566ConexionesDatosInt ;
      private bool[] BC00203_n566ConexionesDatosInt ;
      private string[] BC00203_A567ConexionesDatosExt ;
      private bool[] BC00203_n567ConexionesDatosExt ;
      private string[] BC00203_A568ConexionesDatosDetalle ;
      private bool[] BC00203_n568ConexionesDatosDetalle ;
      private string[] BC00202_A552ConexionesID ;
      private bool[] BC00202_n552ConexionesID ;
      private string[] BC00202_A553ConexionesDatosId ;
      private string[] BC00202_A566ConexionesDatosInt ;
      private bool[] BC00202_n566ConexionesDatosInt ;
      private string[] BC00202_A567ConexionesDatosExt ;
      private bool[] BC00202_n567ConexionesDatosExt ;
      private string[] BC00202_A568ConexionesDatosDetalle ;
      private bool[] BC00202_n568ConexionesDatosDetalle ;
      private string[] BC002018_A552ConexionesID ;
      private bool[] BC002018_n552ConexionesID ;
      private string[] BC002018_A553ConexionesDatosId ;
      private string[] BC002018_A566ConexionesDatosInt ;
      private bool[] BC002018_n566ConexionesDatosInt ;
      private string[] BC002018_A567ConexionesDatosExt ;
      private bool[] BC002018_n567ConexionesDatosExt ;
      private string[] BC002018_A568ConexionesDatosDetalle ;
      private bool[] BC002018_n568ConexionesDatosDetalle ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class conexiones_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class conexiones_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new ForEachCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00202;
        prmBC00202 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@ConexionesDatosId",GXType.NChar,25,0)
        };
        Object[] prmBC00203;
        prmBC00203 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@ConexionesDatosId",GXType.NChar,25,0)
        };
        Object[] prmBC00204;
        prmBC00204 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmBC00205;
        prmBC00205 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmBC00206;
        prmBC00206 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmBC00207;
        prmBC00207 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmBC00208;
        prmBC00208 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@ConexionesNombre",GXType.NChar,80,0){Nullable=true} ,
        new ParDef("@ConexionesTipoIntegracion",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ConexionesHost",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesBaseURL",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesPort",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@ConexionesApiKey",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesUsr",GXType.NChar,64,0){Nullable=true} ,
        new ParDef("@ConexionesAux1",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesAux2",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesAux3",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesEstado",GXType.NChar,3,0){Nullable=true}
        };
        Object[] prmBC00209;
        prmBC00209 = new Object[] {
        new ParDef("@ConexionesNombre",GXType.NChar,80,0){Nullable=true} ,
        new ParDef("@ConexionesTipoIntegracion",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ConexionesHost",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesBaseURL",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesPort",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@ConexionesApiKey",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesUsr",GXType.NChar,64,0){Nullable=true} ,
        new ParDef("@ConexionesAux1",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesAux2",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesAux3",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmBC002010;
        prmBC002010 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmBC002011;
        prmBC002011 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmBC002012;
        prmBC002012 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        Object[] prmBC002013;
        prmBC002013 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@ConexionesDatosId",GXType.NChar,25,0)
        };
        Object[] prmBC002014;
        prmBC002014 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@ConexionesDatosId",GXType.NChar,25,0)
        };
        Object[] prmBC002015;
        prmBC002015 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@ConexionesDatosId",GXType.NChar,25,0) ,
        new ParDef("@ConexionesDatosInt",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesDatosExt",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesDatosDetalle",GXType.NChar,256,0){Nullable=true}
        };
        Object[] prmBC002016;
        prmBC002016 = new Object[] {
        new ParDef("@ConexionesDatosInt",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesDatosExt",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ConexionesDatosDetalle",GXType.NChar,256,0){Nullable=true} ,
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@ConexionesDatosId",GXType.NChar,25,0)
        };
        Object[] prmBC002017;
        prmBC002017 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true} ,
        new ParDef("@ConexionesDatosId",GXType.NChar,25,0)
        };
        Object[] prmBC002018;
        prmBC002018 = new Object[] {
        new ParDef("@ConexionesID",GXType.NChar,9,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC00202", "SELECT [ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle] FROM [ConexionesDatos] WITH (UPDLOCK) WHERE [ConexionesID] = @ConexionesID AND [ConexionesDatosId] = @ConexionesDatosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00202,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00203", "SELECT [ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle] FROM [ConexionesDatos] WHERE [ConexionesID] = @ConexionesID AND [ConexionesDatosId] = @ConexionesDatosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00203,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00204", "SELECT [ConexionesID], [ConexionesNombre], [ConexionesTipoIntegracion], [ConexionesHost], [ConexionesBaseURL], [ConexionesPort], [ConexionesApiKey], [ConexionesUsr], [ConexionesAux1], [ConexionesAux2], [ConexionesAux3], [ConexionesEstado] FROM [Conexiones] WITH (UPDLOCK) WHERE [ConexionesID] = @ConexionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00204,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00205", "SELECT [ConexionesID], [ConexionesNombre], [ConexionesTipoIntegracion], [ConexionesHost], [ConexionesBaseURL], [ConexionesPort], [ConexionesApiKey], [ConexionesUsr], [ConexionesAux1], [ConexionesAux2], [ConexionesAux3], [ConexionesEstado] FROM [Conexiones] WHERE [ConexionesID] = @ConexionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00205,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00206", "SELECT TM1.[ConexionesID], TM1.[ConexionesNombre], TM1.[ConexionesTipoIntegracion], TM1.[ConexionesHost], TM1.[ConexionesBaseURL], TM1.[ConexionesPort], TM1.[ConexionesApiKey], TM1.[ConexionesUsr], TM1.[ConexionesAux1], TM1.[ConexionesAux2], TM1.[ConexionesAux3], TM1.[ConexionesEstado] FROM [Conexiones] TM1 WHERE TM1.[ConexionesID] = @ConexionesID ORDER BY TM1.[ConexionesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00206,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00207", "SELECT [ConexionesID] FROM [Conexiones] WHERE [ConexionesID] = @ConexionesID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00207,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00208", "INSERT INTO [Conexiones]([ConexionesID], [ConexionesNombre], [ConexionesTipoIntegracion], [ConexionesHost], [ConexionesBaseURL], [ConexionesPort], [ConexionesApiKey], [ConexionesUsr], [ConexionesAux1], [ConexionesAux2], [ConexionesAux3], [ConexionesEstado]) VALUES(@ConexionesID, @ConexionesNombre, @ConexionesTipoIntegracion, @ConexionesHost, @ConexionesBaseURL, @ConexionesPort, @ConexionesApiKey, @ConexionesUsr, @ConexionesAux1, @ConexionesAux2, @ConexionesAux3, @ConexionesEstado)", GxErrorMask.GX_NOMASK,prmBC00208)
           ,new CursorDef("BC00209", "UPDATE [Conexiones] SET [ConexionesNombre]=@ConexionesNombre, [ConexionesTipoIntegracion]=@ConexionesTipoIntegracion, [ConexionesHost]=@ConexionesHost, [ConexionesBaseURL]=@ConexionesBaseURL, [ConexionesPort]=@ConexionesPort, [ConexionesApiKey]=@ConexionesApiKey, [ConexionesUsr]=@ConexionesUsr, [ConexionesAux1]=@ConexionesAux1, [ConexionesAux2]=@ConexionesAux2, [ConexionesAux3]=@ConexionesAux3, [ConexionesEstado]=@ConexionesEstado  WHERE [ConexionesID] = @ConexionesID", GxErrorMask.GX_NOMASK,prmBC00209)
           ,new CursorDef("BC002010", "DELETE FROM [Conexiones]  WHERE [ConexionesID] = @ConexionesID", GxErrorMask.GX_NOMASK,prmBC002010)
           ,new CursorDef("BC002011", "SELECT TOP 1 [MapeoID] FROM [ListaMapeo] WHERE [ConexionesID] = @ConexionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002011,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC002012", "SELECT TM1.[ConexionesID], TM1.[ConexionesNombre], TM1.[ConexionesTipoIntegracion], TM1.[ConexionesHost], TM1.[ConexionesBaseURL], TM1.[ConexionesPort], TM1.[ConexionesApiKey], TM1.[ConexionesUsr], TM1.[ConexionesAux1], TM1.[ConexionesAux2], TM1.[ConexionesAux3], TM1.[ConexionesEstado] FROM [Conexiones] TM1 WHERE TM1.[ConexionesID] = @ConexionesID ORDER BY TM1.[ConexionesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002012,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002013", "SELECT [ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle] FROM [ConexionesDatos] WHERE [ConexionesID] = @ConexionesID and [ConexionesDatosId] = @ConexionesDatosId ORDER BY [ConexionesID], [ConexionesDatosId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002013,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002014", "SELECT [ConexionesID], [ConexionesDatosId] FROM [ConexionesDatos] WHERE [ConexionesID] = @ConexionesID AND [ConexionesDatosId] = @ConexionesDatosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002014,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002015", "INSERT INTO [ConexionesDatos]([ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle]) VALUES(@ConexionesID, @ConexionesDatosId, @ConexionesDatosInt, @ConexionesDatosExt, @ConexionesDatosDetalle)", GxErrorMask.GX_NOMASK,prmBC002015)
           ,new CursorDef("BC002016", "UPDATE [ConexionesDatos] SET [ConexionesDatosInt]=@ConexionesDatosInt, [ConexionesDatosExt]=@ConexionesDatosExt, [ConexionesDatosDetalle]=@ConexionesDatosDetalle  WHERE [ConexionesID] = @ConexionesID AND [ConexionesDatosId] = @ConexionesDatosId", GxErrorMask.GX_NOMASK,prmBC002016)
           ,new CursorDef("BC002017", "DELETE FROM [ConexionesDatos]  WHERE [ConexionesID] = @ConexionesID AND [ConexionesDatosId] = @ConexionesDatosId", GxErrorMask.GX_NOMASK,prmBC002017)
           ,new CursorDef("BC002018", "SELECT [ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle] FROM [ConexionesDatos] WHERE [ConexionesID] = @ConexionesID ORDER BY [ConexionesID], [ConexionesDatosId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002018,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 25);
              ((string[]) buf[2])[0] = rslt.getString(3, 128);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 128);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 256);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 25);
              ((string[]) buf[2])[0] = rslt.getString(3, 128);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 128);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 256);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((short[]) buf[3])[0] = rslt.getShort(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getString(4, 128);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 128);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((int[]) buf[9])[0] = rslt.getInt(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getString(7, 128);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getString(8, 64);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getString(9, 128);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((string[]) buf[17])[0] = rslt.getString(10, 128);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((string[]) buf[19])[0] = rslt.getString(11, 128);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getString(12, 3);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((short[]) buf[3])[0] = rslt.getShort(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getString(4, 128);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 128);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((int[]) buf[9])[0] = rslt.getInt(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getString(7, 128);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getString(8, 64);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getString(9, 128);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((string[]) buf[17])[0] = rslt.getString(10, 128);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((string[]) buf[19])[0] = rslt.getString(11, 128);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getString(12, 3);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((short[]) buf[3])[0] = rslt.getShort(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getString(4, 128);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 128);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((int[]) buf[9])[0] = rslt.getInt(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getString(7, 128);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getString(8, 64);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getString(9, 128);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((string[]) buf[17])[0] = rslt.getString(10, 128);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((string[]) buf[19])[0] = rslt.getString(11, 128);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getString(12, 3);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((short[]) buf[3])[0] = rslt.getShort(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getString(4, 128);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 128);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((int[]) buf[9])[0] = rslt.getInt(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getString(7, 128);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getString(8, 64);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getString(9, 128);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((string[]) buf[17])[0] = rslt.getString(10, 128);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((string[]) buf[19])[0] = rslt.getString(11, 128);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getString(12, 3);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 25);
              ((string[]) buf[2])[0] = rslt.getString(3, 128);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 128);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 256);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 25);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 9);
              ((string[]) buf[1])[0] = rslt.getString(2, 25);
              ((string[]) buf[2])[0] = rslt.getString(3, 128);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 128);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 256);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              return;
     }
  }

}

}
