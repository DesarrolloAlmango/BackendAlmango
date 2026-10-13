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
   public class usuarios_bc : GXHttpHandler, IGxSilentTrn
   {
      public usuarios_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usuarios_bc( IGxContext context )
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
         ReadRow1445( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1445( ) ;
         standaloneModal( ) ;
         AddRow1445( ) ;
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
            E11142 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z145usuariosId = A145usuariosId;
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

      protected void CONFIRM_140( )
      {
         BeforeValidate1445( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1445( ) ;
            }
            else
            {
               CheckExtendedTable1445( ) ;
               if ( AnyError == 0 )
               {
                  ZM1445( 9) ;
               }
               CloseExtendedTableCursors1445( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode45 = Gx_mode;
            CONFIRM_1446( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode45;
            }
            /* Restore parent mode. */
            Gx_mode = sMode45;
         }
      }

      protected void CONFIRM_1446( )
      {
         nGXsfl_46_idx = 0;
         while ( nGXsfl_46_idx < bcusuarios.gxTpr_Notificacion.Count )
         {
            ReadRow1446( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound46 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_46 != 0 ) )
            {
               GetKey1446( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound46 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate1446( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1446( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors1446( ) ;
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
                  if ( RcdFound46 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey1446( ) ;
                        Load1446( ) ;
                        BeforeValidate1446( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1446( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_46 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate1446( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1446( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors1446( ) ;
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
               VarsToRow46( ((Sdtusuarios_Notificacion)bcusuarios.gxTpr_Notificacion.Item(nGXsfl_46_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E12142( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV8IsAuthorized = true;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWusuarios_Insert", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWusuarios_Update", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWusuarios_Delete", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
         }
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV17Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV17Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV18GXV1 = 1;
            while ( AV18GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV18GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "PaisID") == 0 )
               {
                  AV14Insert_PaisID = AV15TrnContextAtt.gxTpr_Attributevalue;
               }
               AV18GXV1 = (int)(AV18GXV1+1);
            }
         }
      }

      protected void E11142( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1445( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z225usuariosTipo = A225usuariosTipo;
            Z222usuariosNombre = A222usuariosNombre;
            Z224usuariosCorreo = A224usuariosCorreo;
            Z230usuariosDireccion = A230usuariosDireccion;
            Z223usuariosPasw = A223usuariosPasw;
            Z231usuariosCPostal = A231usuariosCPostal;
            Z232usuariosTelefono = A232usuariosTelefono;
            Z226usuariosEstado = A226usuariosEstado;
            Z227usuariosEstadoOnOffLine = A227usuariosEstadoOnOffLine;
            Z228usuariosFechaEstadoOnOff = A228usuariosFechaEstadoOnOff;
            Z229usuariosHoraEstadoOnOff = A229usuariosHoraEstadoOnOff;
            Z240usuariosNumeroIdentidad = A240usuariosNumeroIdentidad;
            Z116PaisID = A116PaisID;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z165PaisNombre = A165PaisNombre;
         }
         if ( GX_JID == -8 )
         {
            Z145usuariosId = A145usuariosId;
            Z225usuariosTipo = A225usuariosTipo;
            Z222usuariosNombre = A222usuariosNombre;
            Z224usuariosCorreo = A224usuariosCorreo;
            Z230usuariosDireccion = A230usuariosDireccion;
            Z266usuariosImagen = A266usuariosImagen;
            Z40000usuariosImagen_GXI = A40000usuariosImagen_GXI;
            Z223usuariosPasw = A223usuariosPasw;
            Z231usuariosCPostal = A231usuariosCPostal;
            Z232usuariosTelefono = A232usuariosTelefono;
            Z226usuariosEstado = A226usuariosEstado;
            Z227usuariosEstadoOnOffLine = A227usuariosEstadoOnOffLine;
            Z228usuariosFechaEstadoOnOff = A228usuariosFechaEstadoOnOff;
            Z229usuariosHoraEstadoOnOff = A229usuariosHoraEstadoOnOff;
            Z240usuariosNumeroIdentidad = A240usuariosNumeroIdentidad;
            Z116PaisID = A116PaisID;
            Z165PaisNombre = A165PaisNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A226usuariosEstado)) && ( Gx_BScreen == 0 ) )
         {
            A226usuariosEstado = "HAB";
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1445( )
      {
         /* Using cursor BC00147 */
         pr_default.execute(5, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound45 = 1;
            A225usuariosTipo = BC00147_A225usuariosTipo[0];
            A222usuariosNombre = BC00147_A222usuariosNombre[0];
            A224usuariosCorreo = BC00147_A224usuariosCorreo[0];
            A165PaisNombre = BC00147_A165PaisNombre[0];
            A230usuariosDireccion = BC00147_A230usuariosDireccion[0];
            A40000usuariosImagen_GXI = BC00147_A40000usuariosImagen_GXI[0];
            A223usuariosPasw = BC00147_A223usuariosPasw[0];
            A231usuariosCPostal = BC00147_A231usuariosCPostal[0];
            A232usuariosTelefono = BC00147_A232usuariosTelefono[0];
            A226usuariosEstado = BC00147_A226usuariosEstado[0];
            A227usuariosEstadoOnOffLine = BC00147_A227usuariosEstadoOnOffLine[0];
            A228usuariosFechaEstadoOnOff = BC00147_A228usuariosFechaEstadoOnOff[0];
            A229usuariosHoraEstadoOnOff = BC00147_A229usuariosHoraEstadoOnOff[0];
            A240usuariosNumeroIdentidad = BC00147_A240usuariosNumeroIdentidad[0];
            A116PaisID = BC00147_A116PaisID[0];
            A266usuariosImagen = BC00147_A266usuariosImagen[0];
            ZM1445( -8) ;
         }
         pr_default.close(5);
         OnLoadActions1445( ) ;
      }

      protected void OnLoadActions1445( )
      {
         AV17Pgmname = "usuarios_BC";
      }

      protected void CheckExtendedTable1445( )
      {
         standaloneModal( ) ;
         AV17Pgmname = "usuarios_BC";
         if ( ! ( GxRegex.IsMatch(A224usuariosCorreo,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Correo", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00146 */
         pr_default.execute(4, new Object[] {A116PaisID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A165PaisNombre = BC00146_A165PaisNombre[0];
         pr_default.close(4);
         if ( ! ( ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A226usuariosEstado, "BLO") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "usuarios Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A228usuariosFechaEstadoOnOff) || ( DateTimeUtil.ResetTime ( A228usuariosFechaEstadoOnOff ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( " Fecha Estado On Off", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1445( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1445( )
      {
         /* Using cursor BC00148 */
         pr_default.execute(6, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound45 = 1;
         }
         else
         {
            RcdFound45 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00145 */
         pr_default.execute(3, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1445( 8) ;
            RcdFound45 = 1;
            A145usuariosId = BC00145_A145usuariosId[0];
            n145usuariosId = BC00145_n145usuariosId[0];
            A225usuariosTipo = BC00145_A225usuariosTipo[0];
            A222usuariosNombre = BC00145_A222usuariosNombre[0];
            A224usuariosCorreo = BC00145_A224usuariosCorreo[0];
            A230usuariosDireccion = BC00145_A230usuariosDireccion[0];
            A40000usuariosImagen_GXI = BC00145_A40000usuariosImagen_GXI[0];
            A223usuariosPasw = BC00145_A223usuariosPasw[0];
            A231usuariosCPostal = BC00145_A231usuariosCPostal[0];
            A232usuariosTelefono = BC00145_A232usuariosTelefono[0];
            A226usuariosEstado = BC00145_A226usuariosEstado[0];
            A227usuariosEstadoOnOffLine = BC00145_A227usuariosEstadoOnOffLine[0];
            A228usuariosFechaEstadoOnOff = BC00145_A228usuariosFechaEstadoOnOff[0];
            A229usuariosHoraEstadoOnOff = BC00145_A229usuariosHoraEstadoOnOff[0];
            A240usuariosNumeroIdentidad = BC00145_A240usuariosNumeroIdentidad[0];
            A116PaisID = BC00145_A116PaisID[0];
            A266usuariosImagen = BC00145_A266usuariosImagen[0];
            Z145usuariosId = A145usuariosId;
            sMode45 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1445( ) ;
            if ( AnyError == 1 )
            {
               RcdFound45 = 0;
               InitializeNonKey1445( ) ;
            }
            Gx_mode = sMode45;
         }
         else
         {
            RcdFound45 = 0;
            InitializeNonKey1445( ) ;
            sMode45 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode45;
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey1445( ) ;
         if ( RcdFound45 == 0 )
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
         CONFIRM_140( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1445( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00144 */
            pr_default.execute(2, new Object[] {n145usuariosId, A145usuariosId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"usuarios"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z225usuariosTipo, BC00144_A225usuariosTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z222usuariosNombre, BC00144_A222usuariosNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z224usuariosCorreo, BC00144_A224usuariosCorreo[0]) != 0 ) || ( StringUtil.StrCmp(Z230usuariosDireccion, BC00144_A230usuariosDireccion[0]) != 0 ) || ( StringUtil.StrCmp(Z223usuariosPasw, BC00144_A223usuariosPasw[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z231usuariosCPostal != BC00144_A231usuariosCPostal[0] ) || ( StringUtil.StrCmp(Z232usuariosTelefono, BC00144_A232usuariosTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z226usuariosEstado, BC00144_A226usuariosEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z227usuariosEstadoOnOffLine, BC00144_A227usuariosEstadoOnOffLine[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z228usuariosFechaEstadoOnOff ) != DateTimeUtil.ResetTime ( BC00144_A228usuariosFechaEstadoOnOff[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z229usuariosHoraEstadoOnOff != BC00144_A229usuariosHoraEstadoOnOff[0] ) || ( StringUtil.StrCmp(Z240usuariosNumeroIdentidad, BC00144_A240usuariosNumeroIdentidad[0]) != 0 ) || ( StringUtil.StrCmp(Z116PaisID, BC00144_A116PaisID[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"usuarios"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1445( )
      {
         BeforeValidate1445( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1445( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1445( 0) ;
            CheckOptimisticConcurrency1445( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1445( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1445( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00149 */
                     pr_default.execute(7, new Object[] {n145usuariosId, A145usuariosId, A225usuariosTipo, A222usuariosNombre, A224usuariosCorreo, A230usuariosDireccion, A266usuariosImagen, A40000usuariosImagen_GXI, A223usuariosPasw, A231usuariosCPostal, A232usuariosTelefono, A226usuariosEstado, A227usuariosEstadoOnOffLine, A228usuariosFechaEstadoOnOff, A229usuariosHoraEstadoOnOff, A240usuariosNumeroIdentidad, A116PaisID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("usuarios");
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
                           ProcessLevel1445( ) ;
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
               Load1445( ) ;
            }
            EndLevel1445( ) ;
         }
         CloseExtendedTableCursors1445( ) ;
      }

      protected void Update1445( )
      {
         BeforeValidate1445( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1445( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1445( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1445( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1445( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001410 */
                     pr_default.execute(8, new Object[] {A225usuariosTipo, A222usuariosNombre, A224usuariosCorreo, A230usuariosDireccion, A223usuariosPasw, A231usuariosCPostal, A232usuariosTelefono, A226usuariosEstado, A227usuariosEstadoOnOffLine, A228usuariosFechaEstadoOnOff, A229usuariosHoraEstadoOnOff, A240usuariosNumeroIdentidad, A116PaisID, n145usuariosId, A145usuariosId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("usuarios");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"usuarios"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1445( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1445( ) ;
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
            EndLevel1445( ) ;
         }
         CloseExtendedTableCursors1445( ) ;
      }

      protected void DeferredUpdate1445( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC001411 */
            pr_default.execute(9, new Object[] {A266usuariosImagen, A40000usuariosImagen_GXI, n145usuariosId, A145usuariosId});
            pr_default.close(9);
            pr_default.SmartCacheProvider.SetUpdated("usuarios");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1445( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1445( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1445( ) ;
            AfterConfirm1445( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1445( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart1446( ) ;
                  while ( RcdFound46 != 0 )
                  {
                     getByPrimaryKey1446( ) ;
                     Delete1446( ) ;
                     ScanKeyNext1446( ) ;
                  }
                  ScanKeyEnd1446( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001412 */
                     pr_default.execute(10, new Object[] {n145usuariosId, A145usuariosId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("usuarios");
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
         sMode45 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1445( ) ;
         Gx_mode = sMode45;
      }

      protected void OnDeleteControls1445( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV17Pgmname = "usuarios_BC";
            /* Using cursor BC001413 */
            pr_default.execute(11, new Object[] {A116PaisID});
            A165PaisNombre = BC001413_A165PaisNombre[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001414 */
            pr_default.execute(12, new Object[] {n145usuariosId, A145usuariosId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Token", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC001415 */
            pr_default.execute(13, new Object[] {n145usuariosId, A145usuariosId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "User", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void ProcessNestedLevel1446( )
      {
         nGXsfl_46_idx = 0;
         while ( nGXsfl_46_idx < bcusuarios.gxTpr_Notificacion.Count )
         {
            ReadRow1446( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound46 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_46 != 0 ) )
            {
               standaloneNotModal1446( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert1446( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete1446( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update1446( ) ;
                  }
               }
            }
            KeyVarsToRow46( ((Sdtusuarios_Notificacion)bcusuarios.gxTpr_Notificacion.Item(nGXsfl_46_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_46_idx = 0;
            while ( nGXsfl_46_idx < bcusuarios.gxTpr_Notificacion.Count )
            {
               ReadRow1446( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound46 == 0 )
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
                  bcusuarios.gxTpr_Notificacion.RemoveElement(nGXsfl_46_idx);
                  nGXsfl_46_idx = (int)(nGXsfl_46_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey1446( ) ;
                  VarsToRow46( ((Sdtusuarios_Notificacion)bcusuarios.gxTpr_Notificacion.Item(nGXsfl_46_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1446( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_46 = 0;
         nIsMod_46 = 0;
      }

      protected void ProcessLevel1445( )
      {
         /* Save parent mode. */
         sMode45 = Gx_mode;
         ProcessNestedLevel1446( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode45;
         /* ' Update level parameters */
      }

      protected void EndLevel1445( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1445( ) ;
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

      public void ScanKeyStart1445( )
      {
         /* Scan By routine */
         /* Using cursor BC001416 */
         pr_default.execute(14, new Object[] {n145usuariosId, A145usuariosId});
         RcdFound45 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound45 = 1;
            A145usuariosId = BC001416_A145usuariosId[0];
            n145usuariosId = BC001416_n145usuariosId[0];
            A225usuariosTipo = BC001416_A225usuariosTipo[0];
            A222usuariosNombre = BC001416_A222usuariosNombre[0];
            A224usuariosCorreo = BC001416_A224usuariosCorreo[0];
            A165PaisNombre = BC001416_A165PaisNombre[0];
            A230usuariosDireccion = BC001416_A230usuariosDireccion[0];
            A40000usuariosImagen_GXI = BC001416_A40000usuariosImagen_GXI[0];
            A223usuariosPasw = BC001416_A223usuariosPasw[0];
            A231usuariosCPostal = BC001416_A231usuariosCPostal[0];
            A232usuariosTelefono = BC001416_A232usuariosTelefono[0];
            A226usuariosEstado = BC001416_A226usuariosEstado[0];
            A227usuariosEstadoOnOffLine = BC001416_A227usuariosEstadoOnOffLine[0];
            A228usuariosFechaEstadoOnOff = BC001416_A228usuariosFechaEstadoOnOff[0];
            A229usuariosHoraEstadoOnOff = BC001416_A229usuariosHoraEstadoOnOff[0];
            A240usuariosNumeroIdentidad = BC001416_A240usuariosNumeroIdentidad[0];
            A116PaisID = BC001416_A116PaisID[0];
            A266usuariosImagen = BC001416_A266usuariosImagen[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1445( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound45 = 0;
         ScanKeyLoad1445( ) ;
      }

      protected void ScanKeyLoad1445( )
      {
         sMode45 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound45 = 1;
            A145usuariosId = BC001416_A145usuariosId[0];
            n145usuariosId = BC001416_n145usuariosId[0];
            A225usuariosTipo = BC001416_A225usuariosTipo[0];
            A222usuariosNombre = BC001416_A222usuariosNombre[0];
            A224usuariosCorreo = BC001416_A224usuariosCorreo[0];
            A165PaisNombre = BC001416_A165PaisNombre[0];
            A230usuariosDireccion = BC001416_A230usuariosDireccion[0];
            A40000usuariosImagen_GXI = BC001416_A40000usuariosImagen_GXI[0];
            A223usuariosPasw = BC001416_A223usuariosPasw[0];
            A231usuariosCPostal = BC001416_A231usuariosCPostal[0];
            A232usuariosTelefono = BC001416_A232usuariosTelefono[0];
            A226usuariosEstado = BC001416_A226usuariosEstado[0];
            A227usuariosEstadoOnOffLine = BC001416_A227usuariosEstadoOnOffLine[0];
            A228usuariosFechaEstadoOnOff = BC001416_A228usuariosFechaEstadoOnOff[0];
            A229usuariosHoraEstadoOnOff = BC001416_A229usuariosHoraEstadoOnOff[0];
            A240usuariosNumeroIdentidad = BC001416_A240usuariosNumeroIdentidad[0];
            A116PaisID = BC001416_A116PaisID[0];
            A266usuariosImagen = BC001416_A266usuariosImagen[0];
         }
         Gx_mode = sMode45;
      }

      protected void ScanKeyEnd1445( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm1445( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1445( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1445( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1445( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1445( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1445( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1445( )
      {
      }

      protected void ZM1446( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z234usuariosNotificacionNotificado = A234usuariosNotificacionNotificado;
            Z233usuariosNotificacionDescripcio = A233usuariosNotificacionDescripcio;
            Z420usuariosNotificacionParametros = A420usuariosNotificacionParametros;
            Z421usuariosNotificacionObjeto = A421usuariosNotificacionObjeto;
            Z235usuariosNotificacionFecha = A235usuariosNotificacionFecha;
         }
         if ( GX_JID == -10 )
         {
            Z145usuariosId = A145usuariosId;
            Z146usuariosNotificacionTipo = A146usuariosNotificacionTipo;
            Z147usuariosNotificacionCodigo = A147usuariosNotificacionCodigo;
            Z234usuariosNotificacionNotificado = A234usuariosNotificacionNotificado;
            Z233usuariosNotificacionDescripcio = A233usuariosNotificacionDescripcio;
            Z420usuariosNotificacionParametros = A420usuariosNotificacionParametros;
            Z421usuariosNotificacionObjeto = A421usuariosNotificacionObjeto;
            Z235usuariosNotificacionFecha = A235usuariosNotificacionFecha;
         }
      }

      protected void standaloneNotModal1446( )
      {
      }

      protected void standaloneModal1446( )
      {
      }

      protected void Load1446( )
      {
         /* Using cursor BC001417 */
         pr_default.execute(15, new Object[] {n145usuariosId, A145usuariosId, A146usuariosNotificacionTipo, A147usuariosNotificacionCodigo});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound46 = 1;
            A234usuariosNotificacionNotificado = BC001417_A234usuariosNotificacionNotificado[0];
            A233usuariosNotificacionDescripcio = BC001417_A233usuariosNotificacionDescripcio[0];
            A420usuariosNotificacionParametros = BC001417_A420usuariosNotificacionParametros[0];
            A421usuariosNotificacionObjeto = BC001417_A421usuariosNotificacionObjeto[0];
            A235usuariosNotificacionFecha = BC001417_A235usuariosNotificacionFecha[0];
            ZM1446( -10) ;
         }
         pr_default.close(15);
         OnLoadActions1446( ) ;
      }

      protected void OnLoadActions1446( )
      {
      }

      protected void CheckExtendedTable1446( )
      {
         Gx_BScreen = 1;
         standaloneModal1446( ) ;
         Gx_BScreen = 0;
         if ( ! ( (DateTime.MinValue==A235usuariosNotificacionFecha) || ( A235usuariosNotificacionFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1446( )
      {
      }

      protected void enableDisable1446( )
      {
      }

      protected void GetKey1446( )
      {
         /* Using cursor BC001418 */
         pr_default.execute(16, new Object[] {n145usuariosId, A145usuariosId, A146usuariosNotificacionTipo, A147usuariosNotificacionCodigo});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound46 = 1;
         }
         else
         {
            RcdFound46 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey1446( )
      {
         /* Using cursor BC00143 */
         pr_default.execute(1, new Object[] {n145usuariosId, A145usuariosId, A146usuariosNotificacionTipo, A147usuariosNotificacionCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1446( 10) ;
            RcdFound46 = 1;
            InitializeNonKey1446( ) ;
            A146usuariosNotificacionTipo = BC00143_A146usuariosNotificacionTipo[0];
            A147usuariosNotificacionCodigo = BC00143_A147usuariosNotificacionCodigo[0];
            A234usuariosNotificacionNotificado = BC00143_A234usuariosNotificacionNotificado[0];
            A233usuariosNotificacionDescripcio = BC00143_A233usuariosNotificacionDescripcio[0];
            A420usuariosNotificacionParametros = BC00143_A420usuariosNotificacionParametros[0];
            A421usuariosNotificacionObjeto = BC00143_A421usuariosNotificacionObjeto[0];
            A235usuariosNotificacionFecha = BC00143_A235usuariosNotificacionFecha[0];
            Z145usuariosId = A145usuariosId;
            Z146usuariosNotificacionTipo = A146usuariosNotificacionTipo;
            Z147usuariosNotificacionCodigo = A147usuariosNotificacionCodigo;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1446( ) ;
            Load1446( ) ;
            Gx_mode = sMode46;
         }
         else
         {
            RcdFound46 = 0;
            InitializeNonKey1446( ) ;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1446( ) ;
            Gx_mode = sMode46;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1446( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1446( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00142 */
            pr_default.execute(0, new Object[] {n145usuariosId, A145usuariosId, A146usuariosNotificacionTipo, A147usuariosNotificacionCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"usuariosNotificacion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z234usuariosNotificacionNotificado, BC00142_A234usuariosNotificacionNotificado[0]) != 0 ) || ( StringUtil.StrCmp(Z233usuariosNotificacionDescripcio, BC00142_A233usuariosNotificacionDescripcio[0]) != 0 ) || ( StringUtil.StrCmp(Z420usuariosNotificacionParametros, BC00142_A420usuariosNotificacionParametros[0]) != 0 ) || ( StringUtil.StrCmp(Z421usuariosNotificacionObjeto, BC00142_A421usuariosNotificacionObjeto[0]) != 0 ) || ( Z235usuariosNotificacionFecha != BC00142_A235usuariosNotificacionFecha[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"usuariosNotificacion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1446( )
      {
         BeforeValidate1446( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1446( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1446( 0) ;
            CheckOptimisticConcurrency1446( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1446( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1446( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001419 */
                     pr_default.execute(17, new Object[] {n145usuariosId, A145usuariosId, A146usuariosNotificacionTipo, A147usuariosNotificacionCodigo, A234usuariosNotificacionNotificado, A233usuariosNotificacionDescripcio, A420usuariosNotificacionParametros, A421usuariosNotificacionObjeto, A235usuariosNotificacionFecha});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("usuariosNotificacion");
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
               Load1446( ) ;
            }
            EndLevel1446( ) ;
         }
         CloseExtendedTableCursors1446( ) ;
      }

      protected void Update1446( )
      {
         BeforeValidate1446( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1446( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1446( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1446( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1446( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001420 */
                     pr_default.execute(18, new Object[] {A234usuariosNotificacionNotificado, A233usuariosNotificacionDescripcio, A420usuariosNotificacionParametros, A421usuariosNotificacionObjeto, A235usuariosNotificacionFecha, n145usuariosId, A145usuariosId, A146usuariosNotificacionTipo, A147usuariosNotificacionCodigo});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("usuariosNotificacion");
                     if ( (pr_default.getStatus(18) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"usuariosNotificacion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1446( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey1446( ) ;
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
            EndLevel1446( ) ;
         }
         CloseExtendedTableCursors1446( ) ;
      }

      protected void DeferredUpdate1446( )
      {
      }

      protected void Delete1446( )
      {
         Gx_mode = "DLT";
         BeforeValidate1446( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1446( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1446( ) ;
            AfterConfirm1446( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1446( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001421 */
                  pr_default.execute(19, new Object[] {n145usuariosId, A145usuariosId, A146usuariosNotificacionTipo, A147usuariosNotificacionCodigo});
                  pr_default.close(19);
                  pr_default.SmartCacheProvider.SetUpdated("usuariosNotificacion");
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
         sMode46 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1446( ) ;
         Gx_mode = sMode46;
      }

      protected void OnDeleteControls1446( )
      {
         standaloneModal1446( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1446( )
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

      public void ScanKeyStart1446( )
      {
         /* Scan By routine */
         /* Using cursor BC001422 */
         pr_default.execute(20, new Object[] {n145usuariosId, A145usuariosId});
         RcdFound46 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound46 = 1;
            A146usuariosNotificacionTipo = BC001422_A146usuariosNotificacionTipo[0];
            A147usuariosNotificacionCodigo = BC001422_A147usuariosNotificacionCodigo[0];
            A234usuariosNotificacionNotificado = BC001422_A234usuariosNotificacionNotificado[0];
            A233usuariosNotificacionDescripcio = BC001422_A233usuariosNotificacionDescripcio[0];
            A420usuariosNotificacionParametros = BC001422_A420usuariosNotificacionParametros[0];
            A421usuariosNotificacionObjeto = BC001422_A421usuariosNotificacionObjeto[0];
            A235usuariosNotificacionFecha = BC001422_A235usuariosNotificacionFecha[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1446( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound46 = 0;
         ScanKeyLoad1446( ) ;
      }

      protected void ScanKeyLoad1446( )
      {
         sMode46 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound46 = 1;
            A146usuariosNotificacionTipo = BC001422_A146usuariosNotificacionTipo[0];
            A147usuariosNotificacionCodigo = BC001422_A147usuariosNotificacionCodigo[0];
            A234usuariosNotificacionNotificado = BC001422_A234usuariosNotificacionNotificado[0];
            A233usuariosNotificacionDescripcio = BC001422_A233usuariosNotificacionDescripcio[0];
            A420usuariosNotificacionParametros = BC001422_A420usuariosNotificacionParametros[0];
            A421usuariosNotificacionObjeto = BC001422_A421usuariosNotificacionObjeto[0];
            A235usuariosNotificacionFecha = BC001422_A235usuariosNotificacionFecha[0];
         }
         Gx_mode = sMode46;
      }

      protected void ScanKeyEnd1446( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm1446( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1446( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1446( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1446( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1446( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1446( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1446( )
      {
      }

      protected void send_integrity_lvl_hashes1446( )
      {
      }

      protected void send_integrity_lvl_hashes1445( )
      {
      }

      protected void AddRow1445( )
      {
         VarsToRow45( bcusuarios) ;
      }

      protected void ReadRow1445( )
      {
         RowToVars45( bcusuarios, 1) ;
      }

      protected void AddRow1446( )
      {
         Sdtusuarios_Notificacion obj46;
         obj46 = new Sdtusuarios_Notificacion(context);
         VarsToRow46( obj46) ;
         bcusuarios.gxTpr_Notificacion.Add(obj46, 0);
         obj46.gxTpr_Mode = "UPD";
         obj46.gxTpr_Modified = 0;
      }

      protected void ReadRow1446( )
      {
         nGXsfl_46_idx = (int)(nGXsfl_46_idx+1);
         RowToVars46( ((Sdtusuarios_Notificacion)bcusuarios.gxTpr_Notificacion.Item(nGXsfl_46_idx)), 1) ;
      }

      protected void InitializeNonKey1445( )
      {
         A225usuariosTipo = "";
         A222usuariosNombre = "";
         A224usuariosCorreo = "";
         A116PaisID = "";
         A165PaisNombre = "";
         A230usuariosDireccion = "";
         A266usuariosImagen = "";
         A40000usuariosImagen_GXI = "";
         A223usuariosPasw = "";
         A231usuariosCPostal = 0;
         A232usuariosTelefono = "";
         A227usuariosEstadoOnOffLine = "";
         A228usuariosFechaEstadoOnOff = DateTime.MinValue;
         A229usuariosHoraEstadoOnOff = (DateTime)(DateTime.MinValue);
         A240usuariosNumeroIdentidad = "";
         A226usuariosEstado = "HAB";
         Z225usuariosTipo = "";
         Z222usuariosNombre = "";
         Z224usuariosCorreo = "";
         Z230usuariosDireccion = "";
         Z223usuariosPasw = "";
         Z231usuariosCPostal = 0;
         Z232usuariosTelefono = "";
         Z226usuariosEstado = "";
         Z227usuariosEstadoOnOffLine = "";
         Z228usuariosFechaEstadoOnOff = DateTime.MinValue;
         Z229usuariosHoraEstadoOnOff = (DateTime)(DateTime.MinValue);
         Z240usuariosNumeroIdentidad = "";
         Z116PaisID = "";
      }

      protected void InitAll1445( )
      {
         A145usuariosId = "";
         n145usuariosId = false;
         InitializeNonKey1445( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A226usuariosEstado = i226usuariosEstado;
      }

      protected void InitializeNonKey1446( )
      {
         A234usuariosNotificacionNotificado = "";
         A233usuariosNotificacionDescripcio = "";
         A420usuariosNotificacionParametros = "";
         A421usuariosNotificacionObjeto = "";
         A235usuariosNotificacionFecha = (DateTime)(DateTime.MinValue);
         Z234usuariosNotificacionNotificado = "";
         Z233usuariosNotificacionDescripcio = "";
         Z420usuariosNotificacionParametros = "";
         Z421usuariosNotificacionObjeto = "";
         Z235usuariosNotificacionFecha = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll1446( )
      {
         A146usuariosNotificacionTipo = "";
         A147usuariosNotificacionCodigo = 0;
         InitializeNonKey1446( ) ;
      }

      protected void StandaloneModalInsert1446( )
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

      public void VarsToRow45( Sdtusuarios obj45 )
      {
         obj45.gxTpr_Mode = Gx_mode;
         obj45.gxTpr_Usuariostipo = A225usuariosTipo;
         obj45.gxTpr_Usuariosnombre = A222usuariosNombre;
         obj45.gxTpr_Usuarioscorreo = A224usuariosCorreo;
         obj45.gxTpr_Paisid = A116PaisID;
         obj45.gxTpr_Paisnombre = A165PaisNombre;
         obj45.gxTpr_Usuariosdireccion = A230usuariosDireccion;
         obj45.gxTpr_Usuariosimagen = A266usuariosImagen;
         obj45.gxTpr_Usuariosimagen_gxi = A40000usuariosImagen_GXI;
         obj45.gxTpr_Usuariospasw = A223usuariosPasw;
         obj45.gxTpr_Usuarioscpostal = A231usuariosCPostal;
         obj45.gxTpr_Usuariostelefono = A232usuariosTelefono;
         obj45.gxTpr_Usuariosestadoonoffline = A227usuariosEstadoOnOffLine;
         obj45.gxTpr_Usuariosfechaestadoonoff = A228usuariosFechaEstadoOnOff;
         obj45.gxTpr_Usuarioshoraestadoonoff = A229usuariosHoraEstadoOnOff;
         obj45.gxTpr_Usuariosnumeroidentidad = A240usuariosNumeroIdentidad;
         obj45.gxTpr_Usuariosestado = A226usuariosEstado;
         obj45.gxTpr_Usuariosid = A145usuariosId;
         obj45.gxTpr_Usuariosid_Z = Z145usuariosId;
         obj45.gxTpr_Usuariostipo_Z = Z225usuariosTipo;
         obj45.gxTpr_Usuariosnombre_Z = Z222usuariosNombre;
         obj45.gxTpr_Usuarioscorreo_Z = Z224usuariosCorreo;
         obj45.gxTpr_Paisid_Z = Z116PaisID;
         obj45.gxTpr_Paisnombre_Z = Z165PaisNombre;
         obj45.gxTpr_Usuariosdireccion_Z = Z230usuariosDireccion;
         obj45.gxTpr_Usuariospasw_Z = Z223usuariosPasw;
         obj45.gxTpr_Usuarioscpostal_Z = Z231usuariosCPostal;
         obj45.gxTpr_Usuariostelefono_Z = Z232usuariosTelefono;
         obj45.gxTpr_Usuariosestado_Z = Z226usuariosEstado;
         obj45.gxTpr_Usuariosestadoonoffline_Z = Z227usuariosEstadoOnOffLine;
         obj45.gxTpr_Usuariosfechaestadoonoff_Z = Z228usuariosFechaEstadoOnOff;
         obj45.gxTpr_Usuarioshoraestadoonoff_Z = Z229usuariosHoraEstadoOnOff;
         obj45.gxTpr_Usuariosnumeroidentidad_Z = Z240usuariosNumeroIdentidad;
         obj45.gxTpr_Usuariosimagen_gxi_Z = Z40000usuariosImagen_GXI;
         obj45.gxTpr_Usuariosid_N = (short)(Convert.ToInt16(n145usuariosId));
         obj45.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow45( Sdtusuarios obj45 )
      {
         obj45.gxTpr_Usuariosid = A145usuariosId;
         return  ;
      }

      public void RowToVars45( Sdtusuarios obj45 ,
                               int forceLoad )
      {
         Gx_mode = obj45.gxTpr_Mode;
         A225usuariosTipo = obj45.gxTpr_Usuariostipo;
         A222usuariosNombre = obj45.gxTpr_Usuariosnombre;
         A224usuariosCorreo = obj45.gxTpr_Usuarioscorreo;
         A116PaisID = obj45.gxTpr_Paisid;
         A165PaisNombre = obj45.gxTpr_Paisnombre;
         A230usuariosDireccion = obj45.gxTpr_Usuariosdireccion;
         A266usuariosImagen = obj45.gxTpr_Usuariosimagen;
         A40000usuariosImagen_GXI = obj45.gxTpr_Usuariosimagen_gxi;
         A223usuariosPasw = obj45.gxTpr_Usuariospasw;
         A231usuariosCPostal = obj45.gxTpr_Usuarioscpostal;
         A232usuariosTelefono = obj45.gxTpr_Usuariostelefono;
         A227usuariosEstadoOnOffLine = obj45.gxTpr_Usuariosestadoonoffline;
         A228usuariosFechaEstadoOnOff = obj45.gxTpr_Usuariosfechaestadoonoff;
         A229usuariosHoraEstadoOnOff = obj45.gxTpr_Usuarioshoraestadoonoff;
         A240usuariosNumeroIdentidad = obj45.gxTpr_Usuariosnumeroidentidad;
         A226usuariosEstado = obj45.gxTpr_Usuariosestado;
         A145usuariosId = obj45.gxTpr_Usuariosid;
         n145usuariosId = false;
         Z145usuariosId = obj45.gxTpr_Usuariosid_Z;
         Z225usuariosTipo = obj45.gxTpr_Usuariostipo_Z;
         Z222usuariosNombre = obj45.gxTpr_Usuariosnombre_Z;
         Z224usuariosCorreo = obj45.gxTpr_Usuarioscorreo_Z;
         Z116PaisID = obj45.gxTpr_Paisid_Z;
         Z165PaisNombre = obj45.gxTpr_Paisnombre_Z;
         Z230usuariosDireccion = obj45.gxTpr_Usuariosdireccion_Z;
         Z223usuariosPasw = obj45.gxTpr_Usuariospasw_Z;
         Z231usuariosCPostal = obj45.gxTpr_Usuarioscpostal_Z;
         Z232usuariosTelefono = obj45.gxTpr_Usuariostelefono_Z;
         Z226usuariosEstado = obj45.gxTpr_Usuariosestado_Z;
         Z227usuariosEstadoOnOffLine = obj45.gxTpr_Usuariosestadoonoffline_Z;
         Z228usuariosFechaEstadoOnOff = obj45.gxTpr_Usuariosfechaestadoonoff_Z;
         Z229usuariosHoraEstadoOnOff = obj45.gxTpr_Usuarioshoraestadoonoff_Z;
         Z240usuariosNumeroIdentidad = obj45.gxTpr_Usuariosnumeroidentidad_Z;
         Z40000usuariosImagen_GXI = obj45.gxTpr_Usuariosimagen_gxi_Z;
         n145usuariosId = (bool)(Convert.ToBoolean(obj45.gxTpr_Usuariosid_N));
         Gx_mode = obj45.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow46( Sdtusuarios_Notificacion obj46 )
      {
         obj46.gxTpr_Mode = Gx_mode;
         obj46.gxTpr_Usuariosnotificacionnotificado = A234usuariosNotificacionNotificado;
         obj46.gxTpr_Usuariosnotificaciondescripcion = A233usuariosNotificacionDescripcio;
         obj46.gxTpr_Usuariosnotificacionparametros = A420usuariosNotificacionParametros;
         obj46.gxTpr_Usuariosnotificacionobjeto = A421usuariosNotificacionObjeto;
         obj46.gxTpr_Usuariosnotificacionfecha = A235usuariosNotificacionFecha;
         obj46.gxTpr_Usuariosnotificaciontipo = A146usuariosNotificacionTipo;
         obj46.gxTpr_Usuariosnotificacioncodigo = A147usuariosNotificacionCodigo;
         obj46.gxTpr_Usuariosnotificaciontipo_Z = Z146usuariosNotificacionTipo;
         obj46.gxTpr_Usuariosnotificacioncodigo_Z = Z147usuariosNotificacionCodigo;
         obj46.gxTpr_Usuariosnotificacionnotificado_Z = Z234usuariosNotificacionNotificado;
         obj46.gxTpr_Usuariosnotificaciondescripcion_Z = Z233usuariosNotificacionDescripcio;
         obj46.gxTpr_Usuariosnotificacionparametros_Z = Z420usuariosNotificacionParametros;
         obj46.gxTpr_Usuariosnotificacionobjeto_Z = Z421usuariosNotificacionObjeto;
         obj46.gxTpr_Usuariosnotificacionfecha_Z = Z235usuariosNotificacionFecha;
         obj46.gxTpr_Modified = nIsMod_46;
         return  ;
      }

      public void KeyVarsToRow46( Sdtusuarios_Notificacion obj46 )
      {
         obj46.gxTpr_Usuariosnotificaciontipo = A146usuariosNotificacionTipo;
         obj46.gxTpr_Usuariosnotificacioncodigo = A147usuariosNotificacionCodigo;
         return  ;
      }

      public void RowToVars46( Sdtusuarios_Notificacion obj46 ,
                               int forceLoad )
      {
         Gx_mode = obj46.gxTpr_Mode;
         A234usuariosNotificacionNotificado = obj46.gxTpr_Usuariosnotificacionnotificado;
         A233usuariosNotificacionDescripcio = obj46.gxTpr_Usuariosnotificaciondescripcion;
         A420usuariosNotificacionParametros = obj46.gxTpr_Usuariosnotificacionparametros;
         A421usuariosNotificacionObjeto = obj46.gxTpr_Usuariosnotificacionobjeto;
         A235usuariosNotificacionFecha = obj46.gxTpr_Usuariosnotificacionfecha;
         A146usuariosNotificacionTipo = obj46.gxTpr_Usuariosnotificaciontipo;
         A147usuariosNotificacionCodigo = obj46.gxTpr_Usuariosnotificacioncodigo;
         Z146usuariosNotificacionTipo = obj46.gxTpr_Usuariosnotificaciontipo_Z;
         Z147usuariosNotificacionCodigo = obj46.gxTpr_Usuariosnotificacioncodigo_Z;
         Z234usuariosNotificacionNotificado = obj46.gxTpr_Usuariosnotificacionnotificado_Z;
         Z233usuariosNotificacionDescripcio = obj46.gxTpr_Usuariosnotificaciondescripcion_Z;
         Z420usuariosNotificacionParametros = obj46.gxTpr_Usuariosnotificacionparametros_Z;
         Z421usuariosNotificacionObjeto = obj46.gxTpr_Usuariosnotificacionobjeto_Z;
         Z235usuariosNotificacionFecha = obj46.gxTpr_Usuariosnotificacionfecha_Z;
         nIsMod_46 = obj46.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A145usuariosId = (string)getParm(obj,0);
         n145usuariosId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1445( ) ;
         ScanKeyStart1445( ) ;
         if ( RcdFound45 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z145usuariosId = A145usuariosId;
         }
         ZM1445( -8) ;
         OnLoadActions1445( ) ;
         AddRow1445( ) ;
         bcusuarios.gxTpr_Notificacion.ClearCollection();
         if ( RcdFound45 == 1 )
         {
            ScanKeyStart1446( ) ;
            nGXsfl_46_idx = 1;
            while ( RcdFound46 != 0 )
            {
               Z145usuariosId = A145usuariosId;
               Z146usuariosNotificacionTipo = A146usuariosNotificacionTipo;
               Z147usuariosNotificacionCodigo = A147usuariosNotificacionCodigo;
               ZM1446( -10) ;
               OnLoadActions1446( ) ;
               nRcdExists_46 = 1;
               nIsMod_46 = 0;
               AddRow1446( ) ;
               nGXsfl_46_idx = (int)(nGXsfl_46_idx+1);
               ScanKeyNext1446( ) ;
            }
            ScanKeyEnd1446( ) ;
         }
         ScanKeyEnd1445( ) ;
         if ( RcdFound45 == 0 )
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
         RowToVars45( bcusuarios, 0) ;
         ScanKeyStart1445( ) ;
         if ( RcdFound45 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z145usuariosId = A145usuariosId;
         }
         ZM1445( -8) ;
         OnLoadActions1445( ) ;
         AddRow1445( ) ;
         bcusuarios.gxTpr_Notificacion.ClearCollection();
         if ( RcdFound45 == 1 )
         {
            ScanKeyStart1446( ) ;
            nGXsfl_46_idx = 1;
            while ( RcdFound46 != 0 )
            {
               Z145usuariosId = A145usuariosId;
               Z146usuariosNotificacionTipo = A146usuariosNotificacionTipo;
               Z147usuariosNotificacionCodigo = A147usuariosNotificacionCodigo;
               ZM1446( -10) ;
               OnLoadActions1446( ) ;
               nRcdExists_46 = 1;
               nIsMod_46 = 0;
               AddRow1446( ) ;
               nGXsfl_46_idx = (int)(nGXsfl_46_idx+1);
               ScanKeyNext1446( ) ;
            }
            ScanKeyEnd1446( ) ;
         }
         ScanKeyEnd1445( ) ;
         if ( RcdFound45 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1445( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1445( ) ;
         }
         else
         {
            if ( RcdFound45 == 1 )
            {
               if ( StringUtil.StrCmp(A145usuariosId, Z145usuariosId) != 0 )
               {
                  A145usuariosId = Z145usuariosId;
                  n145usuariosId = false;
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
                  Update1445( ) ;
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
                  if ( StringUtil.StrCmp(A145usuariosId, Z145usuariosId) != 0 )
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
                        Insert1445( ) ;
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
                        Insert1445( ) ;
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
         RowToVars45( bcusuarios, 1) ;
         SaveImpl( ) ;
         VarsToRow45( bcusuarios) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars45( bcusuarios, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1445( ) ;
         AfterTrn( ) ;
         VarsToRow45( bcusuarios) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow45( bcusuarios) ;
         }
         else
         {
            Sdtusuarios auxBC = new Sdtusuarios(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A145usuariosId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcusuarios);
               auxBC.Save();
               bcusuarios.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars45( bcusuarios, 1) ;
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
         RowToVars45( bcusuarios, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1445( ) ;
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
               VarsToRow45( bcusuarios) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow45( bcusuarios) ;
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
         RowToVars45( bcusuarios, 0) ;
         GetKey1445( ) ;
         if ( RcdFound45 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A145usuariosId, Z145usuariosId) != 0 )
            {
               A145usuariosId = Z145usuariosId;
               n145usuariosId = false;
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
            if ( StringUtil.StrCmp(A145usuariosId, Z145usuariosId) != 0 )
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
         pr_default.close(11);
         context.RollbackDataStores("usuarios_bc",pr_default);
         VarsToRow45( bcusuarios) ;
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
         Gx_mode = bcusuarios.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcusuarios.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcusuarios )
         {
            bcusuarios = (Sdtusuarios)(sdt);
            if ( StringUtil.StrCmp(bcusuarios.gxTpr_Mode, "") == 0 )
            {
               bcusuarios.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow45( bcusuarios) ;
            }
            else
            {
               RowToVars45( bcusuarios, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcusuarios.gxTpr_Mode, "") == 0 )
            {
               bcusuarios.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars45( bcusuarios, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public Sdtusuarios usuarios_BC
      {
         get {
            return bcusuarios ;
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z145usuariosId = "";
         A145usuariosId = "";
         sMode45 = "";
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV17Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV14Insert_PaisID = "";
         Z225usuariosTipo = "";
         A225usuariosTipo = "";
         Z222usuariosNombre = "";
         A222usuariosNombre = "";
         Z224usuariosCorreo = "";
         A224usuariosCorreo = "";
         Z230usuariosDireccion = "";
         A230usuariosDireccion = "";
         Z223usuariosPasw = "";
         A223usuariosPasw = "";
         Z232usuariosTelefono = "";
         A232usuariosTelefono = "";
         Z226usuariosEstado = "";
         A226usuariosEstado = "";
         Z227usuariosEstadoOnOffLine = "";
         A227usuariosEstadoOnOffLine = "";
         Z228usuariosFechaEstadoOnOff = DateTime.MinValue;
         A228usuariosFechaEstadoOnOff = DateTime.MinValue;
         Z229usuariosHoraEstadoOnOff = (DateTime)(DateTime.MinValue);
         A229usuariosHoraEstadoOnOff = (DateTime)(DateTime.MinValue);
         Z240usuariosNumeroIdentidad = "";
         A240usuariosNumeroIdentidad = "";
         Z116PaisID = "";
         A116PaisID = "";
         Z165PaisNombre = "";
         A165PaisNombre = "";
         Z266usuariosImagen = "";
         A266usuariosImagen = "";
         Z40000usuariosImagen_GXI = "";
         A40000usuariosImagen_GXI = "";
         BC00147_A145usuariosId = new string[] {""} ;
         BC00147_n145usuariosId = new bool[] {false} ;
         BC00147_A225usuariosTipo = new string[] {""} ;
         BC00147_A222usuariosNombre = new string[] {""} ;
         BC00147_A224usuariosCorreo = new string[] {""} ;
         BC00147_A165PaisNombre = new string[] {""} ;
         BC00147_A230usuariosDireccion = new string[] {""} ;
         BC00147_A40000usuariosImagen_GXI = new string[] {""} ;
         BC00147_A223usuariosPasw = new string[] {""} ;
         BC00147_A231usuariosCPostal = new int[1] ;
         BC00147_A232usuariosTelefono = new string[] {""} ;
         BC00147_A226usuariosEstado = new string[] {""} ;
         BC00147_A227usuariosEstadoOnOffLine = new string[] {""} ;
         BC00147_A228usuariosFechaEstadoOnOff = new DateTime[] {DateTime.MinValue} ;
         BC00147_A229usuariosHoraEstadoOnOff = new DateTime[] {DateTime.MinValue} ;
         BC00147_A240usuariosNumeroIdentidad = new string[] {""} ;
         BC00147_A116PaisID = new string[] {""} ;
         BC00147_A266usuariosImagen = new string[] {""} ;
         BC00146_A165PaisNombre = new string[] {""} ;
         BC00148_A145usuariosId = new string[] {""} ;
         BC00148_n145usuariosId = new bool[] {false} ;
         BC00145_A145usuariosId = new string[] {""} ;
         BC00145_n145usuariosId = new bool[] {false} ;
         BC00145_A225usuariosTipo = new string[] {""} ;
         BC00145_A222usuariosNombre = new string[] {""} ;
         BC00145_A224usuariosCorreo = new string[] {""} ;
         BC00145_A230usuariosDireccion = new string[] {""} ;
         BC00145_A40000usuariosImagen_GXI = new string[] {""} ;
         BC00145_A223usuariosPasw = new string[] {""} ;
         BC00145_A231usuariosCPostal = new int[1] ;
         BC00145_A232usuariosTelefono = new string[] {""} ;
         BC00145_A226usuariosEstado = new string[] {""} ;
         BC00145_A227usuariosEstadoOnOffLine = new string[] {""} ;
         BC00145_A228usuariosFechaEstadoOnOff = new DateTime[] {DateTime.MinValue} ;
         BC00145_A229usuariosHoraEstadoOnOff = new DateTime[] {DateTime.MinValue} ;
         BC00145_A240usuariosNumeroIdentidad = new string[] {""} ;
         BC00145_A116PaisID = new string[] {""} ;
         BC00145_A266usuariosImagen = new string[] {""} ;
         BC00144_A145usuariosId = new string[] {""} ;
         BC00144_n145usuariosId = new bool[] {false} ;
         BC00144_A225usuariosTipo = new string[] {""} ;
         BC00144_A222usuariosNombre = new string[] {""} ;
         BC00144_A224usuariosCorreo = new string[] {""} ;
         BC00144_A230usuariosDireccion = new string[] {""} ;
         BC00144_A40000usuariosImagen_GXI = new string[] {""} ;
         BC00144_A223usuariosPasw = new string[] {""} ;
         BC00144_A231usuariosCPostal = new int[1] ;
         BC00144_A232usuariosTelefono = new string[] {""} ;
         BC00144_A226usuariosEstado = new string[] {""} ;
         BC00144_A227usuariosEstadoOnOffLine = new string[] {""} ;
         BC00144_A228usuariosFechaEstadoOnOff = new DateTime[] {DateTime.MinValue} ;
         BC00144_A229usuariosHoraEstadoOnOff = new DateTime[] {DateTime.MinValue} ;
         BC00144_A240usuariosNumeroIdentidad = new string[] {""} ;
         BC00144_A116PaisID = new string[] {""} ;
         BC00144_A266usuariosImagen = new string[] {""} ;
         BC001413_A165PaisNombre = new string[] {""} ;
         BC001414_A899TokenId = new string[] {""} ;
         BC001415_A18SecUserId = new long[1] ;
         BC001416_A145usuariosId = new string[] {""} ;
         BC001416_n145usuariosId = new bool[] {false} ;
         BC001416_A225usuariosTipo = new string[] {""} ;
         BC001416_A222usuariosNombre = new string[] {""} ;
         BC001416_A224usuariosCorreo = new string[] {""} ;
         BC001416_A165PaisNombre = new string[] {""} ;
         BC001416_A230usuariosDireccion = new string[] {""} ;
         BC001416_A40000usuariosImagen_GXI = new string[] {""} ;
         BC001416_A223usuariosPasw = new string[] {""} ;
         BC001416_A231usuariosCPostal = new int[1] ;
         BC001416_A232usuariosTelefono = new string[] {""} ;
         BC001416_A226usuariosEstado = new string[] {""} ;
         BC001416_A227usuariosEstadoOnOffLine = new string[] {""} ;
         BC001416_A228usuariosFechaEstadoOnOff = new DateTime[] {DateTime.MinValue} ;
         BC001416_A229usuariosHoraEstadoOnOff = new DateTime[] {DateTime.MinValue} ;
         BC001416_A240usuariosNumeroIdentidad = new string[] {""} ;
         BC001416_A116PaisID = new string[] {""} ;
         BC001416_A266usuariosImagen = new string[] {""} ;
         Z234usuariosNotificacionNotificado = "";
         A234usuariosNotificacionNotificado = "";
         Z233usuariosNotificacionDescripcio = "";
         A233usuariosNotificacionDescripcio = "";
         Z420usuariosNotificacionParametros = "";
         A420usuariosNotificacionParametros = "";
         Z421usuariosNotificacionObjeto = "";
         A421usuariosNotificacionObjeto = "";
         Z235usuariosNotificacionFecha = (DateTime)(DateTime.MinValue);
         A235usuariosNotificacionFecha = (DateTime)(DateTime.MinValue);
         Z146usuariosNotificacionTipo = "";
         A146usuariosNotificacionTipo = "";
         BC001417_A145usuariosId = new string[] {""} ;
         BC001417_n145usuariosId = new bool[] {false} ;
         BC001417_A146usuariosNotificacionTipo = new string[] {""} ;
         BC001417_A147usuariosNotificacionCodigo = new long[1] ;
         BC001417_A234usuariosNotificacionNotificado = new string[] {""} ;
         BC001417_A233usuariosNotificacionDescripcio = new string[] {""} ;
         BC001417_A420usuariosNotificacionParametros = new string[] {""} ;
         BC001417_A421usuariosNotificacionObjeto = new string[] {""} ;
         BC001417_A235usuariosNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         BC001418_A145usuariosId = new string[] {""} ;
         BC001418_n145usuariosId = new bool[] {false} ;
         BC001418_A146usuariosNotificacionTipo = new string[] {""} ;
         BC001418_A147usuariosNotificacionCodigo = new long[1] ;
         BC00143_A145usuariosId = new string[] {""} ;
         BC00143_n145usuariosId = new bool[] {false} ;
         BC00143_A146usuariosNotificacionTipo = new string[] {""} ;
         BC00143_A147usuariosNotificacionCodigo = new long[1] ;
         BC00143_A234usuariosNotificacionNotificado = new string[] {""} ;
         BC00143_A233usuariosNotificacionDescripcio = new string[] {""} ;
         BC00143_A420usuariosNotificacionParametros = new string[] {""} ;
         BC00143_A421usuariosNotificacionObjeto = new string[] {""} ;
         BC00143_A235usuariosNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         sMode46 = "";
         BC00142_A145usuariosId = new string[] {""} ;
         BC00142_n145usuariosId = new bool[] {false} ;
         BC00142_A146usuariosNotificacionTipo = new string[] {""} ;
         BC00142_A147usuariosNotificacionCodigo = new long[1] ;
         BC00142_A234usuariosNotificacionNotificado = new string[] {""} ;
         BC00142_A233usuariosNotificacionDescripcio = new string[] {""} ;
         BC00142_A420usuariosNotificacionParametros = new string[] {""} ;
         BC00142_A421usuariosNotificacionObjeto = new string[] {""} ;
         BC00142_A235usuariosNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         BC001422_A145usuariosId = new string[] {""} ;
         BC001422_n145usuariosId = new bool[] {false} ;
         BC001422_A146usuariosNotificacionTipo = new string[] {""} ;
         BC001422_A147usuariosNotificacionCodigo = new long[1] ;
         BC001422_A234usuariosNotificacionNotificado = new string[] {""} ;
         BC001422_A233usuariosNotificacionDescripcio = new string[] {""} ;
         BC001422_A420usuariosNotificacionParametros = new string[] {""} ;
         BC001422_A421usuariosNotificacionObjeto = new string[] {""} ;
         BC001422_A235usuariosNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         i226usuariosEstado = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.usuarios_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuarios_bc__default(),
            new Object[][] {
                new Object[] {
               BC00142_A145usuariosId, BC00142_A146usuariosNotificacionTipo, BC00142_A147usuariosNotificacionCodigo, BC00142_A234usuariosNotificacionNotificado, BC00142_A233usuariosNotificacionDescripcio, BC00142_A420usuariosNotificacionParametros, BC00142_A421usuariosNotificacionObjeto, BC00142_A235usuariosNotificacionFecha
               }
               , new Object[] {
               BC00143_A145usuariosId, BC00143_A146usuariosNotificacionTipo, BC00143_A147usuariosNotificacionCodigo, BC00143_A234usuariosNotificacionNotificado, BC00143_A233usuariosNotificacionDescripcio, BC00143_A420usuariosNotificacionParametros, BC00143_A421usuariosNotificacionObjeto, BC00143_A235usuariosNotificacionFecha
               }
               , new Object[] {
               BC00144_A145usuariosId, BC00144_A225usuariosTipo, BC00144_A222usuariosNombre, BC00144_A224usuariosCorreo, BC00144_A230usuariosDireccion, BC00144_A40000usuariosImagen_GXI, BC00144_A223usuariosPasw, BC00144_A231usuariosCPostal, BC00144_A232usuariosTelefono, BC00144_A226usuariosEstado,
               BC00144_A227usuariosEstadoOnOffLine, BC00144_A228usuariosFechaEstadoOnOff, BC00144_A229usuariosHoraEstadoOnOff, BC00144_A240usuariosNumeroIdentidad, BC00144_A116PaisID, BC00144_A266usuariosImagen
               }
               , new Object[] {
               BC00145_A145usuariosId, BC00145_A225usuariosTipo, BC00145_A222usuariosNombre, BC00145_A224usuariosCorreo, BC00145_A230usuariosDireccion, BC00145_A40000usuariosImagen_GXI, BC00145_A223usuariosPasw, BC00145_A231usuariosCPostal, BC00145_A232usuariosTelefono, BC00145_A226usuariosEstado,
               BC00145_A227usuariosEstadoOnOffLine, BC00145_A228usuariosFechaEstadoOnOff, BC00145_A229usuariosHoraEstadoOnOff, BC00145_A240usuariosNumeroIdentidad, BC00145_A116PaisID, BC00145_A266usuariosImagen
               }
               , new Object[] {
               BC00146_A165PaisNombre
               }
               , new Object[] {
               BC00147_A145usuariosId, BC00147_A225usuariosTipo, BC00147_A222usuariosNombre, BC00147_A224usuariosCorreo, BC00147_A165PaisNombre, BC00147_A230usuariosDireccion, BC00147_A40000usuariosImagen_GXI, BC00147_A223usuariosPasw, BC00147_A231usuariosCPostal, BC00147_A232usuariosTelefono,
               BC00147_A226usuariosEstado, BC00147_A227usuariosEstadoOnOffLine, BC00147_A228usuariosFechaEstadoOnOff, BC00147_A229usuariosHoraEstadoOnOff, BC00147_A240usuariosNumeroIdentidad, BC00147_A116PaisID, BC00147_A266usuariosImagen
               }
               , new Object[] {
               BC00148_A145usuariosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001413_A165PaisNombre
               }
               , new Object[] {
               BC001414_A899TokenId
               }
               , new Object[] {
               BC001415_A18SecUserId
               }
               , new Object[] {
               BC001416_A145usuariosId, BC001416_A225usuariosTipo, BC001416_A222usuariosNombre, BC001416_A224usuariosCorreo, BC001416_A165PaisNombre, BC001416_A230usuariosDireccion, BC001416_A40000usuariosImagen_GXI, BC001416_A223usuariosPasw, BC001416_A231usuariosCPostal, BC001416_A232usuariosTelefono,
               BC001416_A226usuariosEstado, BC001416_A227usuariosEstadoOnOffLine, BC001416_A228usuariosFechaEstadoOnOff, BC001416_A229usuariosHoraEstadoOnOff, BC001416_A240usuariosNumeroIdentidad, BC001416_A116PaisID, BC001416_A266usuariosImagen
               }
               , new Object[] {
               BC001417_A145usuariosId, BC001417_A146usuariosNotificacionTipo, BC001417_A147usuariosNotificacionCodigo, BC001417_A234usuariosNotificacionNotificado, BC001417_A233usuariosNotificacionDescripcio, BC001417_A420usuariosNotificacionParametros, BC001417_A421usuariosNotificacionObjeto, BC001417_A235usuariosNotificacionFecha
               }
               , new Object[] {
               BC001418_A145usuariosId, BC001418_A146usuariosNotificacionTipo, BC001418_A147usuariosNotificacionCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001422_A145usuariosId, BC001422_A146usuariosNotificacionTipo, BC001422_A147usuariosNotificacionCodigo, BC001422_A234usuariosNotificacionNotificado, BC001422_A233usuariosNotificacionDescripcio, BC001422_A420usuariosNotificacionParametros, BC001422_A421usuariosNotificacionObjeto, BC001422_A235usuariosNotificacionFecha
               }
            }
         );
         AV17Pgmname = "usuarios_BC";
         Z226usuariosEstado = "HAB";
         A226usuariosEstado = "HAB";
         i226usuariosEstado = "HAB";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12142 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_46 ;
      private short RcdFound46 ;
      private short Gx_BScreen ;
      private short RcdFound45 ;
      private short nRcdExists_46 ;
      private short Gxremove46 ;
      private int trnEnded ;
      private int nGXsfl_46_idx=1 ;
      private int AV18GXV1 ;
      private int Z231usuariosCPostal ;
      private int A231usuariosCPostal ;
      private long Z147usuariosNotificacionCodigo ;
      private long A147usuariosNotificacionCodigo ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z145usuariosId ;
      private string A145usuariosId ;
      private string sMode45 ;
      private string AV17Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV14Insert_PaisID ;
      private string Z225usuariosTipo ;
      private string A225usuariosTipo ;
      private string Z222usuariosNombre ;
      private string A222usuariosNombre ;
      private string Z223usuariosPasw ;
      private string A223usuariosPasw ;
      private string Z232usuariosTelefono ;
      private string A232usuariosTelefono ;
      private string Z226usuariosEstado ;
      private string A226usuariosEstado ;
      private string Z227usuariosEstadoOnOffLine ;
      private string A227usuariosEstadoOnOffLine ;
      private string Z240usuariosNumeroIdentidad ;
      private string A240usuariosNumeroIdentidad ;
      private string Z116PaisID ;
      private string A116PaisID ;
      private string Z165PaisNombre ;
      private string A165PaisNombre ;
      private string Z234usuariosNotificacionNotificado ;
      private string A234usuariosNotificacionNotificado ;
      private string Z233usuariosNotificacionDescripcio ;
      private string A233usuariosNotificacionDescripcio ;
      private string Z420usuariosNotificacionParametros ;
      private string A420usuariosNotificacionParametros ;
      private string Z421usuariosNotificacionObjeto ;
      private string A421usuariosNotificacionObjeto ;
      private string Z146usuariosNotificacionTipo ;
      private string A146usuariosNotificacionTipo ;
      private string sMode46 ;
      private string i226usuariosEstado ;
      private DateTime Z229usuariosHoraEstadoOnOff ;
      private DateTime A229usuariosHoraEstadoOnOff ;
      private DateTime Z235usuariosNotificacionFecha ;
      private DateTime A235usuariosNotificacionFecha ;
      private DateTime Z228usuariosFechaEstadoOnOff ;
      private DateTime A228usuariosFechaEstadoOnOff ;
      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool n145usuariosId ;
      private bool Gx_longc ;
      private string Z224usuariosCorreo ;
      private string A224usuariosCorreo ;
      private string Z230usuariosDireccion ;
      private string A230usuariosDireccion ;
      private string Z40000usuariosImagen_GXI ;
      private string A40000usuariosImagen_GXI ;
      private string Z266usuariosImagen ;
      private string A266usuariosImagen ;
      private IGxSession AV13WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private Sdtusuarios bcusuarios ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] BC00147_A145usuariosId ;
      private bool[] BC00147_n145usuariosId ;
      private string[] BC00147_A225usuariosTipo ;
      private string[] BC00147_A222usuariosNombre ;
      private string[] BC00147_A224usuariosCorreo ;
      private string[] BC00147_A165PaisNombre ;
      private string[] BC00147_A230usuariosDireccion ;
      private string[] BC00147_A40000usuariosImagen_GXI ;
      private string[] BC00147_A223usuariosPasw ;
      private int[] BC00147_A231usuariosCPostal ;
      private string[] BC00147_A232usuariosTelefono ;
      private string[] BC00147_A226usuariosEstado ;
      private string[] BC00147_A227usuariosEstadoOnOffLine ;
      private DateTime[] BC00147_A228usuariosFechaEstadoOnOff ;
      private DateTime[] BC00147_A229usuariosHoraEstadoOnOff ;
      private string[] BC00147_A240usuariosNumeroIdentidad ;
      private string[] BC00147_A116PaisID ;
      private string[] BC00147_A266usuariosImagen ;
      private string[] BC00146_A165PaisNombre ;
      private string[] BC00148_A145usuariosId ;
      private bool[] BC00148_n145usuariosId ;
      private string[] BC00145_A145usuariosId ;
      private bool[] BC00145_n145usuariosId ;
      private string[] BC00145_A225usuariosTipo ;
      private string[] BC00145_A222usuariosNombre ;
      private string[] BC00145_A224usuariosCorreo ;
      private string[] BC00145_A230usuariosDireccion ;
      private string[] BC00145_A40000usuariosImagen_GXI ;
      private string[] BC00145_A223usuariosPasw ;
      private int[] BC00145_A231usuariosCPostal ;
      private string[] BC00145_A232usuariosTelefono ;
      private string[] BC00145_A226usuariosEstado ;
      private string[] BC00145_A227usuariosEstadoOnOffLine ;
      private DateTime[] BC00145_A228usuariosFechaEstadoOnOff ;
      private DateTime[] BC00145_A229usuariosHoraEstadoOnOff ;
      private string[] BC00145_A240usuariosNumeroIdentidad ;
      private string[] BC00145_A116PaisID ;
      private string[] BC00145_A266usuariosImagen ;
      private string[] BC00144_A145usuariosId ;
      private bool[] BC00144_n145usuariosId ;
      private string[] BC00144_A225usuariosTipo ;
      private string[] BC00144_A222usuariosNombre ;
      private string[] BC00144_A224usuariosCorreo ;
      private string[] BC00144_A230usuariosDireccion ;
      private string[] BC00144_A40000usuariosImagen_GXI ;
      private string[] BC00144_A223usuariosPasw ;
      private int[] BC00144_A231usuariosCPostal ;
      private string[] BC00144_A232usuariosTelefono ;
      private string[] BC00144_A226usuariosEstado ;
      private string[] BC00144_A227usuariosEstadoOnOffLine ;
      private DateTime[] BC00144_A228usuariosFechaEstadoOnOff ;
      private DateTime[] BC00144_A229usuariosHoraEstadoOnOff ;
      private string[] BC00144_A240usuariosNumeroIdentidad ;
      private string[] BC00144_A116PaisID ;
      private string[] BC00144_A266usuariosImagen ;
      private string[] BC001413_A165PaisNombre ;
      private string[] BC001414_A899TokenId ;
      private long[] BC001415_A18SecUserId ;
      private string[] BC001416_A145usuariosId ;
      private bool[] BC001416_n145usuariosId ;
      private string[] BC001416_A225usuariosTipo ;
      private string[] BC001416_A222usuariosNombre ;
      private string[] BC001416_A224usuariosCorreo ;
      private string[] BC001416_A165PaisNombre ;
      private string[] BC001416_A230usuariosDireccion ;
      private string[] BC001416_A40000usuariosImagen_GXI ;
      private string[] BC001416_A223usuariosPasw ;
      private int[] BC001416_A231usuariosCPostal ;
      private string[] BC001416_A232usuariosTelefono ;
      private string[] BC001416_A226usuariosEstado ;
      private string[] BC001416_A227usuariosEstadoOnOffLine ;
      private DateTime[] BC001416_A228usuariosFechaEstadoOnOff ;
      private DateTime[] BC001416_A229usuariosHoraEstadoOnOff ;
      private string[] BC001416_A240usuariosNumeroIdentidad ;
      private string[] BC001416_A116PaisID ;
      private string[] BC001416_A266usuariosImagen ;
      private string[] BC001417_A145usuariosId ;
      private bool[] BC001417_n145usuariosId ;
      private string[] BC001417_A146usuariosNotificacionTipo ;
      private long[] BC001417_A147usuariosNotificacionCodigo ;
      private string[] BC001417_A234usuariosNotificacionNotificado ;
      private string[] BC001417_A233usuariosNotificacionDescripcio ;
      private string[] BC001417_A420usuariosNotificacionParametros ;
      private string[] BC001417_A421usuariosNotificacionObjeto ;
      private DateTime[] BC001417_A235usuariosNotificacionFecha ;
      private string[] BC001418_A145usuariosId ;
      private bool[] BC001418_n145usuariosId ;
      private string[] BC001418_A146usuariosNotificacionTipo ;
      private long[] BC001418_A147usuariosNotificacionCodigo ;
      private string[] BC00143_A145usuariosId ;
      private bool[] BC00143_n145usuariosId ;
      private string[] BC00143_A146usuariosNotificacionTipo ;
      private long[] BC00143_A147usuariosNotificacionCodigo ;
      private string[] BC00143_A234usuariosNotificacionNotificado ;
      private string[] BC00143_A233usuariosNotificacionDescripcio ;
      private string[] BC00143_A420usuariosNotificacionParametros ;
      private string[] BC00143_A421usuariosNotificacionObjeto ;
      private DateTime[] BC00143_A235usuariosNotificacionFecha ;
      private string[] BC00142_A145usuariosId ;
      private bool[] BC00142_n145usuariosId ;
      private string[] BC00142_A146usuariosNotificacionTipo ;
      private long[] BC00142_A147usuariosNotificacionCodigo ;
      private string[] BC00142_A234usuariosNotificacionNotificado ;
      private string[] BC00142_A233usuariosNotificacionDescripcio ;
      private string[] BC00142_A420usuariosNotificacionParametros ;
      private string[] BC00142_A421usuariosNotificacionObjeto ;
      private DateTime[] BC00142_A235usuariosNotificacionFecha ;
      private string[] BC001422_A145usuariosId ;
      private bool[] BC001422_n145usuariosId ;
      private string[] BC001422_A146usuariosNotificacionTipo ;
      private long[] BC001422_A147usuariosNotificacionCodigo ;
      private string[] BC001422_A234usuariosNotificacionNotificado ;
      private string[] BC001422_A233usuariosNotificacionDescripcio ;
      private string[] BC001422_A420usuariosNotificacionParametros ;
      private string[] BC001422_A421usuariosNotificacionObjeto ;
      private DateTime[] BC001422_A235usuariosNotificacionFecha ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class usuarios_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class usuarios_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
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
        Object[] prmBC00142;
        prmBC00142 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosNotificacionTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionCodigo",GXType.Decimal,10,0)
        };
        Object[] prmBC00143;
        prmBC00143 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosNotificacionTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionCodigo",GXType.Decimal,10,0)
        };
        Object[] prmBC00144;
        prmBC00144 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmBC00145;
        prmBC00145 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmBC00146;
        prmBC00146 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmBC00147;
        prmBC00147 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmBC00148;
        prmBC00148 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmBC00149;
        prmBC00149 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNombre",GXType.NChar,80,0) ,
        new ParDef("@usuariosCorreo",GXType.NVarChar,100,0) ,
        new ParDef("@usuariosDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@usuariosImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@usuariosImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=5, Tbl="usuarios", Fld="usuariosImagen"} ,
        new ParDef("@usuariosPasw",GXType.NChar,80,0) ,
        new ParDef("@usuariosCPostal",GXType.Int32,5,0) ,
        new ParDef("@usuariosTelefono",GXType.NChar,20,0) ,
        new ParDef("@usuariosEstado",GXType.NChar,3,0) ,
        new ParDef("@usuariosEstadoOnOffLine",GXType.NChar,3,0) ,
        new ParDef("@usuariosFechaEstadoOnOff",GXType.Date,8,0) ,
        new ParDef("@usuariosHoraEstadoOnOff",GXType.DateTime,0,5) ,
        new ParDef("@usuariosNumeroIdentidad",GXType.NChar,20,0) ,
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmBC001410;
        prmBC001410 = new Object[] {
        new ParDef("@usuariosTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNombre",GXType.NChar,80,0) ,
        new ParDef("@usuariosCorreo",GXType.NVarChar,100,0) ,
        new ParDef("@usuariosDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@usuariosPasw",GXType.NChar,80,0) ,
        new ParDef("@usuariosCPostal",GXType.Int32,5,0) ,
        new ParDef("@usuariosTelefono",GXType.NChar,20,0) ,
        new ParDef("@usuariosEstado",GXType.NChar,3,0) ,
        new ParDef("@usuariosEstadoOnOffLine",GXType.NChar,3,0) ,
        new ParDef("@usuariosFechaEstadoOnOff",GXType.Date,8,0) ,
        new ParDef("@usuariosHoraEstadoOnOff",GXType.DateTime,0,5) ,
        new ParDef("@usuariosNumeroIdentidad",GXType.NChar,20,0) ,
        new ParDef("@PaisID",GXType.NChar,2,0) ,
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmBC001411;
        prmBC001411 = new Object[] {
        new ParDef("@usuariosImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@usuariosImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="usuarios", Fld="usuariosImagen"} ,
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmBC001412;
        prmBC001412 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmBC001413;
        prmBC001413 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0)
        };
        Object[] prmBC001414;
        prmBC001414 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmBC001415;
        prmBC001415 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmBC001416;
        prmBC001416 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmBC001417;
        prmBC001417 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosNotificacionTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionCodigo",GXType.Decimal,10,0)
        };
        Object[] prmBC001418;
        prmBC001418 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosNotificacionTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionCodigo",GXType.Decimal,10,0)
        };
        Object[] prmBC001419;
        prmBC001419 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosNotificacionTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionCodigo",GXType.Decimal,10,0) ,
        new ParDef("@usuariosNotificacionNotificado",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionDescripcio",GXType.NChar,250,0) ,
        new ParDef("@usuariosNotificacionParametros",GXType.NChar,500,0) ,
        new ParDef("@usuariosNotificacionObjeto",GXType.NChar,100,0) ,
        new ParDef("@usuariosNotificacionFecha",GXType.DateTime,8,5)
        };
        Object[] prmBC001420;
        prmBC001420 = new Object[] {
        new ParDef("@usuariosNotificacionNotificado",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionDescripcio",GXType.NChar,250,0) ,
        new ParDef("@usuariosNotificacionParametros",GXType.NChar,500,0) ,
        new ParDef("@usuariosNotificacionObjeto",GXType.NChar,100,0) ,
        new ParDef("@usuariosNotificacionFecha",GXType.DateTime,8,5) ,
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosNotificacionTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionCodigo",GXType.Decimal,10,0)
        };
        Object[] prmBC001421;
        prmBC001421 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosNotificacionTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionCodigo",GXType.Decimal,10,0)
        };
        Object[] prmBC001422;
        prmBC001422 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC00142", "SELECT [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo], [usuariosNotificacionNotificado], [usuariosNotificacionDescripcio], [usuariosNotificacionParametros], [usuariosNotificacionObjeto], [usuariosNotificacionFecha] FROM [usuariosNotificacion] WITH (UPDLOCK) WHERE [usuariosId] = @usuariosId AND [usuariosNotificacionTipo] = @usuariosNotificacionTipo AND [usuariosNotificacionCodigo] = @usuariosNotificacionCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00142,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00143", "SELECT [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo], [usuariosNotificacionNotificado], [usuariosNotificacionDescripcio], [usuariosNotificacionParametros], [usuariosNotificacionObjeto], [usuariosNotificacionFecha] FROM [usuariosNotificacion] WHERE [usuariosId] = @usuariosId AND [usuariosNotificacionTipo] = @usuariosNotificacionTipo AND [usuariosNotificacionCodigo] = @usuariosNotificacionCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00143,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00144", "SELECT [usuariosId], [usuariosTipo], [usuariosNombre], [usuariosCorreo], [usuariosDireccion], [usuariosImagen_GXI], [usuariosPasw], [usuariosCPostal], [usuariosTelefono], [usuariosEstado], [usuariosEstadoOnOffLine], [usuariosFechaEstadoOnOff], [usuariosHoraEstadoOnOff], [usuariosNumeroIdentidad], [PaisID], [usuariosImagen] FROM [usuarios] WITH (UPDLOCK) WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00144,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00145", "SELECT [usuariosId], [usuariosTipo], [usuariosNombre], [usuariosCorreo], [usuariosDireccion], [usuariosImagen_GXI], [usuariosPasw], [usuariosCPostal], [usuariosTelefono], [usuariosEstado], [usuariosEstadoOnOffLine], [usuariosFechaEstadoOnOff], [usuariosHoraEstadoOnOff], [usuariosNumeroIdentidad], [PaisID], [usuariosImagen] FROM [usuarios] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00145,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00146", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00146,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00147", "SELECT TM1.[usuariosId], TM1.[usuariosTipo], TM1.[usuariosNombre], TM1.[usuariosCorreo], T2.[PaisNombre], TM1.[usuariosDireccion], TM1.[usuariosImagen_GXI], TM1.[usuariosPasw], TM1.[usuariosCPostal], TM1.[usuariosTelefono], TM1.[usuariosEstado], TM1.[usuariosEstadoOnOffLine], TM1.[usuariosFechaEstadoOnOff], TM1.[usuariosHoraEstadoOnOff], TM1.[usuariosNumeroIdentidad], TM1.[PaisID], TM1.[usuariosImagen] FROM ([usuarios] TM1 INNER JOIN [Pais] T2 ON T2.[PaisID] = TM1.[PaisID]) WHERE TM1.[usuariosId] = @usuariosId ORDER BY TM1.[usuariosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00147,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00148", "SELECT [usuariosId] FROM [usuarios] WHERE [usuariosId] = @usuariosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00148,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00149", "INSERT INTO [usuarios]([usuariosId], [usuariosTipo], [usuariosNombre], [usuariosCorreo], [usuariosDireccion], [usuariosImagen], [usuariosImagen_GXI], [usuariosPasw], [usuariosCPostal], [usuariosTelefono], [usuariosEstado], [usuariosEstadoOnOffLine], [usuariosFechaEstadoOnOff], [usuariosHoraEstadoOnOff], [usuariosNumeroIdentidad], [PaisID]) VALUES(@usuariosId, @usuariosTipo, @usuariosNombre, @usuariosCorreo, @usuariosDireccion, @usuariosImagen, @usuariosImagen_GXI, @usuariosPasw, @usuariosCPostal, @usuariosTelefono, @usuariosEstado, @usuariosEstadoOnOffLine, @usuariosFechaEstadoOnOff, @usuariosHoraEstadoOnOff, @usuariosNumeroIdentidad, @PaisID)", GxErrorMask.GX_NOMASK,prmBC00149)
           ,new CursorDef("BC001410", "UPDATE [usuarios] SET [usuariosTipo]=@usuariosTipo, [usuariosNombre]=@usuariosNombre, [usuariosCorreo]=@usuariosCorreo, [usuariosDireccion]=@usuariosDireccion, [usuariosPasw]=@usuariosPasw, [usuariosCPostal]=@usuariosCPostal, [usuariosTelefono]=@usuariosTelefono, [usuariosEstado]=@usuariosEstado, [usuariosEstadoOnOffLine]=@usuariosEstadoOnOffLine, [usuariosFechaEstadoOnOff]=@usuariosFechaEstadoOnOff, [usuariosHoraEstadoOnOff]=@usuariosHoraEstadoOnOff, [usuariosNumeroIdentidad]=@usuariosNumeroIdentidad, [PaisID]=@PaisID  WHERE [usuariosId] = @usuariosId", GxErrorMask.GX_NOMASK,prmBC001410)
           ,new CursorDef("BC001411", "UPDATE [usuarios] SET [usuariosImagen]=@usuariosImagen, [usuariosImagen_GXI]=@usuariosImagen_GXI  WHERE [usuariosId] = @usuariosId", GxErrorMask.GX_NOMASK,prmBC001411)
           ,new CursorDef("BC001412", "DELETE FROM [usuarios]  WHERE [usuariosId] = @usuariosId", GxErrorMask.GX_NOMASK,prmBC001412)
           ,new CursorDef("BC001413", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001413,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001414", "SELECT TOP 1 [TokenId] FROM [Token] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001414,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001415", "SELECT TOP 1 [SecUserId] FROM [SecUser] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001415,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001416", "SELECT TM1.[usuariosId], TM1.[usuariosTipo], TM1.[usuariosNombre], TM1.[usuariosCorreo], T2.[PaisNombre], TM1.[usuariosDireccion], TM1.[usuariosImagen_GXI], TM1.[usuariosPasw], TM1.[usuariosCPostal], TM1.[usuariosTelefono], TM1.[usuariosEstado], TM1.[usuariosEstadoOnOffLine], TM1.[usuariosFechaEstadoOnOff], TM1.[usuariosHoraEstadoOnOff], TM1.[usuariosNumeroIdentidad], TM1.[PaisID], TM1.[usuariosImagen] FROM ([usuarios] TM1 INNER JOIN [Pais] T2 ON T2.[PaisID] = TM1.[PaisID]) WHERE TM1.[usuariosId] = @usuariosId ORDER BY TM1.[usuariosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001416,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001417", "SELECT [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo], [usuariosNotificacionNotificado], [usuariosNotificacionDescripcio], [usuariosNotificacionParametros], [usuariosNotificacionObjeto], [usuariosNotificacionFecha] FROM [usuariosNotificacion] WHERE [usuariosId] = @usuariosId and [usuariosNotificacionTipo] = @usuariosNotificacionTipo and [usuariosNotificacionCodigo] = @usuariosNotificacionCodigo ORDER BY [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001417,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001418", "SELECT [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo] FROM [usuariosNotificacion] WHERE [usuariosId] = @usuariosId AND [usuariosNotificacionTipo] = @usuariosNotificacionTipo AND [usuariosNotificacionCodigo] = @usuariosNotificacionCodigo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001418,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001419", "INSERT INTO [usuariosNotificacion]([usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo], [usuariosNotificacionNotificado], [usuariosNotificacionDescripcio], [usuariosNotificacionParametros], [usuariosNotificacionObjeto], [usuariosNotificacionFecha]) VALUES(@usuariosId, @usuariosNotificacionTipo, @usuariosNotificacionCodigo, @usuariosNotificacionNotificado, @usuariosNotificacionDescripcio, @usuariosNotificacionParametros, @usuariosNotificacionObjeto, @usuariosNotificacionFecha)", GxErrorMask.GX_NOMASK,prmBC001419)
           ,new CursorDef("BC001420", "UPDATE [usuariosNotificacion] SET [usuariosNotificacionNotificado]=@usuariosNotificacionNotificado, [usuariosNotificacionDescripcio]=@usuariosNotificacionDescripcio, [usuariosNotificacionParametros]=@usuariosNotificacionParametros, [usuariosNotificacionObjeto]=@usuariosNotificacionObjeto, [usuariosNotificacionFecha]=@usuariosNotificacionFecha  WHERE [usuariosId] = @usuariosId AND [usuariosNotificacionTipo] = @usuariosNotificacionTipo AND [usuariosNotificacionCodigo] = @usuariosNotificacionCodigo", GxErrorMask.GX_NOMASK,prmBC001420)
           ,new CursorDef("BC001421", "DELETE FROM [usuariosNotificacion]  WHERE [usuariosId] = @usuariosId AND [usuariosNotificacionTipo] = @usuariosNotificacionTipo AND [usuariosNotificacionCodigo] = @usuariosNotificacionCodigo", GxErrorMask.GX_NOMASK,prmBC001421)
           ,new CursorDef("BC001422", "SELECT [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo], [usuariosNotificacionNotificado], [usuariosNotificacionDescripcio], [usuariosNotificacionParametros], [usuariosNotificacionObjeto], [usuariosNotificacionFecha] FROM [usuariosNotificacion] WHERE [usuariosId] = @usuariosId ORDER BY [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001422,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 250);
              ((string[]) buf[5])[0] = rslt.getString(6, 500);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 250);
              ((string[]) buf[5])[0] = rslt.getString(6, 500);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 80);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((string[]) buf[10])[0] = rslt.getString(11, 3);
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 20);
              ((string[]) buf[14])[0] = rslt.getString(15, 2);
              ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(6));
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 80);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((string[]) buf[10])[0] = rslt.getString(11, 3);
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 20);
              ((string[]) buf[14])[0] = rslt.getString(15, 2);
              ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(6));
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 80);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 20);
              ((string[]) buf[10])[0] = rslt.getString(11, 3);
              ((string[]) buf[11])[0] = rslt.getString(12, 3);
              ((DateTime[]) buf[12])[0] = rslt.getGXDate(13);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((string[]) buf[15])[0] = rslt.getString(16, 2);
              ((string[]) buf[16])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(7));
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 80);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 20);
              ((string[]) buf[10])[0] = rslt.getString(11, 3);
              ((string[]) buf[11])[0] = rslt.getString(12, 3);
              ((DateTime[]) buf[12])[0] = rslt.getGXDate(13);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((string[]) buf[15])[0] = rslt.getString(16, 2);
              ((string[]) buf[16])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(7));
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 250);
              ((string[]) buf[5])[0] = rslt.getString(6, 500);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 250);
              ((string[]) buf[5])[0] = rslt.getString(6, 500);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              return;
     }
  }

}

}
