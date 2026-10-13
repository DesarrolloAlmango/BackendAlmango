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
   public class secuser_bc : GXHttpHandler, IGxSilentTrn
   {
      public secuser_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuser_bc( IGxContext context )
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
         ReadRow067( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey067( ) ;
         standaloneModal( ) ;
         AddRow067( ) ;
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
            E11062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z18SecUserId = A18SecUserId;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls067( ) ;
            }
            else
            {
               CheckExtendedTable067( ) ;
               if ( AnyError == 0 )
               {
                  ZM067( 18) ;
               }
               CloseExtendedTableCursors067( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12062( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV15WWPContext) ;
         AV9IsAuthorized = true;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecUser_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecUser_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecUser_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV32Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV32Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV33GXV1 = 1;
            while ( AV33GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV33GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "usuariosId") == 0 )
               {
                  AV16Insert_usuariosId = AV17TrnContextAtt.gxTpr_Attributevalue;
               }
               AV33GXV1 = (int)(AV33GXV1+1);
            }
         }
         AV24Exite = context.GetMessage( "N", "");
         AV25ExiteVinculo = context.GetMessage( "N", "");
         AV28UserPassword = "";
      }

      protected void E11062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28UserPassword)) && ! String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) )
         {
            new setusuariospasw(context ).execute(  A145usuariosId,  AV28UserPassword) ;
         }
      }

      protected void E13062( )
      {
         /* Userpassword_Isvalid Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28UserPassword)) )
         {
            new pencripta(context ).execute(  StringUtil.Trim( AV28UserPassword), out  A27SecUserPassword) ;
         }
      }

      protected void ZM067( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z27SecUserPassword = A27SecUserPassword;
            Z26SecUserName = A26SecUserName;
            Z587SecUserFullName = A587SecUserFullName;
            Z550SecUserEstado = A550SecUserEstado;
            Z145usuariosId = A145usuariosId;
         }
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z222usuariosNombre = A222usuariosNombre;
            Z223usuariosPasw = A223usuariosPasw;
            Z226usuariosEstado = A226usuariosEstado;
            Z225usuariosTipo = A225usuariosTipo;
         }
         if ( GX_JID == -17 )
         {
            Z18SecUserId = A18SecUserId;
            Z27SecUserPassword = A27SecUserPassword;
            Z26SecUserName = A26SecUserName;
            Z587SecUserFullName = A587SecUserFullName;
            Z550SecUserEstado = A550SecUserEstado;
            Z145usuariosId = A145usuariosId;
            Z222usuariosNombre = A222usuariosNombre;
            Z223usuariosPasw = A223usuariosPasw;
            Z226usuariosEstado = A226usuariosEstado;
            Z266usuariosImagen = A266usuariosImagen;
            Z40000usuariosImagen_GXI = A40000usuariosImagen_GXI;
            Z225usuariosTipo = A225usuariosTipo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         if ( StringUtil.StrCmp(AV24Exite, context.GetMessage( "S", "")) == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "Error: El usuario ya existe, selecciones otro nickname (Nombre)", ""), 1, "");
            AnyError = 1;
         }
         if ( StringUtil.StrCmp(AV25ExiteVinculo, context.GetMessage( "S", "")) == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "Error: Ya se encuentra vinculado con el usuario seleccionado.", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void standaloneModal( )
      {
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28UserPassword)) )
         {
            GXt_char2 = A27SecUserPassword;
            new pencripta(context ).execute(  AV28UserPassword, out  GXt_char2) ;
            A27SecUserPassword = GXt_char2;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A550SecUserEstado)) && ( Gx_BScreen == 0 ) )
         {
            A550SecUserEstado = "HAB";
            n550SecUserEstado = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV32Pgmname = "WWPBaseObjects.SecUser_BC";
            AV30OdlusuariosPasw = O27SecUserPassword;
         }
      }

      protected void Load067( )
      {
         /* Using cursor BC00065 */
         pr_default.execute(3, new Object[] {A18SecUserId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
            A27SecUserPassword = BC00065_A27SecUserPassword[0];
            A26SecUserName = BC00065_A26SecUserName[0];
            A587SecUserFullName = BC00065_A587SecUserFullName[0];
            A222usuariosNombre = BC00065_A222usuariosNombre[0];
            A223usuariosPasw = BC00065_A223usuariosPasw[0];
            A226usuariosEstado = BC00065_A226usuariosEstado[0];
            A40000usuariosImagen_GXI = BC00065_A40000usuariosImagen_GXI[0];
            A225usuariosTipo = BC00065_A225usuariosTipo[0];
            A550SecUserEstado = BC00065_A550SecUserEstado[0];
            n550SecUserEstado = BC00065_n550SecUserEstado[0];
            A145usuariosId = BC00065_A145usuariosId[0];
            n145usuariosId = BC00065_n145usuariosId[0];
            A266usuariosImagen = BC00065_A266usuariosImagen[0];
            ZM067( -17) ;
         }
         pr_default.close(3);
         OnLoadActions067( ) ;
      }

      protected void OnLoadActions067( )
      {
         AV32Pgmname = "WWPBaseObjects.SecUser_BC";
         AV26OldSecUserName = O26SecUserName;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_char2 = AV24Exite;
            new oexisteuser(context ).execute(  A145usuariosId,  A26SecUserName,  "S", out  GXt_char2) ;
            AV24Exite = GXt_char2;
         }
         AV30OdlusuariosPasw = O27SecUserPassword;
         AV27OldusuariosId = O145usuariosId;
         if ( ( ( StringUtil.StrCmp(AV26OldSecUserName, A26SecUserName) != 0 ) || ( StringUtil.StrCmp(AV27OldusuariosId, A145usuariosId) != 0 ) ) && ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            GXt_char2 = AV25ExiteVinculo;
            new oexisteuser(context ).execute(  A145usuariosId,  A26SecUserName,  "V", out  GXt_char2) ;
            AV25ExiteVinculo = GXt_char2;
         }
      }

      protected void CheckExtendedTable067( )
      {
         standaloneModal( ) ;
         AV32Pgmname = "WWPBaseObjects.SecUser_BC";
         AV26OldSecUserName = O26SecUserName;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_char2 = AV24Exite;
            new oexisteuser(context ).execute(  A145usuariosId,  A26SecUserName,  "S", out  GXt_char2) ;
            AV24Exite = GXt_char2;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A26SecUserName)) )
         {
            GX_msglist.addItem(context.GetMessage( "Error: El nickname no puede ser vacíos.", ""), 1, "");
            AnyError = 1;
         }
         AV30OdlusuariosPasw = O27SecUserPassword;
         /* Using cursor BC00064 */
         pr_default.execute(2, new Object[] {n145usuariosId, A145usuariosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "usuarios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOSID");
               AnyError = 1;
            }
         }
         A222usuariosNombre = BC00064_A222usuariosNombre[0];
         A223usuariosPasw = BC00064_A223usuariosPasw[0];
         A226usuariosEstado = BC00064_A226usuariosEstado[0];
         A40000usuariosImagen_GXI = BC00064_A40000usuariosImagen_GXI[0];
         A225usuariosTipo = BC00064_A225usuariosTipo[0];
         A266usuariosImagen = BC00064_A266usuariosImagen[0];
         pr_default.close(2);
         AV27OldusuariosId = O145usuariosId;
         if ( ( ( StringUtil.StrCmp(AV26OldSecUserName, A26SecUserName) != 0 ) || ( StringUtil.StrCmp(AV27OldusuariosId, A145usuariosId) != 0 ) ) && ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            GXt_char2 = AV25ExiteVinculo;
            new oexisteuser(context ).execute(  A145usuariosId,  A26SecUserName,  "V", out  GXt_char2) ;
            AV25ExiteVinculo = GXt_char2;
         }
         if ( ! ( ( StringUtil.StrCmp(A550SecUserEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A550SecUserEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A550SecUserEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A550SecUserEstado, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A550SecUserEstado)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors067( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey067( )
      {
         /* Using cursor BC00066 */
         pr_default.execute(4, new Object[] {A18SecUserId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00063 */
         pr_default.execute(1, new Object[] {A18SecUserId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM067( 17) ;
            RcdFound7 = 1;
            A18SecUserId = BC00063_A18SecUserId[0];
            A27SecUserPassword = BC00063_A27SecUserPassword[0];
            A26SecUserName = BC00063_A26SecUserName[0];
            A587SecUserFullName = BC00063_A587SecUserFullName[0];
            A550SecUserEstado = BC00063_A550SecUserEstado[0];
            n550SecUserEstado = BC00063_n550SecUserEstado[0];
            A145usuariosId = BC00063_A145usuariosId[0];
            n145usuariosId = BC00063_n145usuariosId[0];
            O27SecUserPassword = A27SecUserPassword;
            O145usuariosId = A145usuariosId;
            n145usuariosId = false;
            O26SecUserName = A26SecUserName;
            Z18SecUserId = A18SecUserId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load067( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey067( ) ;
            }
            Gx_mode = sMode7;
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey067( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode7;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey067( ) ;
         if ( RcdFound7 == 0 )
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
         CONFIRM_060( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency067( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00062 */
            pr_default.execute(0, new Object[] {A18SecUserId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUser"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z27SecUserPassword, BC00062_A27SecUserPassword[0]) != 0 ) || ( StringUtil.StrCmp(Z26SecUserName, BC00062_A26SecUserName[0]) != 0 ) || ( StringUtil.StrCmp(Z587SecUserFullName, BC00062_A587SecUserFullName[0]) != 0 ) || ( StringUtil.StrCmp(Z550SecUserEstado, BC00062_A550SecUserEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z145usuariosId, BC00062_A145usuariosId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecUser"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert067( )
      {
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable067( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM067( 0) ;
            CheckOptimisticConcurrency067( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm067( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert067( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00067 */
                     pr_default.execute(5, new Object[] {A27SecUserPassword, A26SecUserName, A587SecUserFullName, n550SecUserEstado, A550SecUserEstado, n145usuariosId, A145usuariosId});
                     A18SecUserId = BC00067_A18SecUserId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("SecUser");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        new GeneXus.Programs.wwpbaseobjects.wwp_createuserextended(context ).execute(  StringUtil.Trim( StringUtil.Str( (decimal)(A18SecUserId), 10, 0)),  "") ;
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
               Load067( ) ;
            }
            EndLevel067( ) ;
         }
         CloseExtendedTableCursors067( ) ;
      }

      protected void Update067( )
      {
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable067( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency067( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm067( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate067( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00068 */
                     pr_default.execute(6, new Object[] {A27SecUserPassword, A26SecUserName, A587SecUserFullName, n550SecUserEstado, A550SecUserEstado, n145usuariosId, A145usuariosId, A18SecUserId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("SecUser");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUser"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate067( ) ;
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
            EndLevel067( ) ;
         }
         CloseExtendedTableCursors067( ) ;
      }

      protected void DeferredUpdate067( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency067( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls067( ) ;
            AfterConfirm067( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete067( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00069 */
                  pr_default.execute(7, new Object[] {A18SecUserId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("SecUser");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel067( ) ;
         Gx_mode = sMode7;
      }

      protected void OnDeleteControls067( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV32Pgmname = "WWPBaseObjects.SecUser_BC";
            AV26OldSecUserName = O26SecUserName;
            AV30OdlusuariosPasw = O27SecUserPassword;
            /* Using cursor BC000610 */
            pr_default.execute(8, new Object[] {n145usuariosId, A145usuariosId});
            A222usuariosNombre = BC000610_A222usuariosNombre[0];
            A223usuariosPasw = BC000610_A223usuariosPasw[0];
            A226usuariosEstado = BC000610_A226usuariosEstado[0];
            A40000usuariosImagen_GXI = BC000610_A40000usuariosImagen_GXI[0];
            A225usuariosTipo = BC000610_A225usuariosTipo[0];
            A266usuariosImagen = BC000610_A266usuariosImagen[0];
            pr_default.close(8);
            AV27OldusuariosId = O145usuariosId;
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               GXt_char2 = AV24Exite;
               new oexisteuser(context ).execute(  A145usuariosId,  A26SecUserName,  "S", out  GXt_char2) ;
               AV24Exite = GXt_char2;
            }
            if ( ( ( StringUtil.StrCmp(AV26OldSecUserName, A26SecUserName) != 0 ) || ( StringUtil.StrCmp(AV27OldusuariosId, A145usuariosId) != 0 ) ) && ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               GXt_char2 = AV25ExiteVinculo;
               new oexisteuser(context ).execute(  A145usuariosId,  A26SecUserName,  "V", out  GXt_char2) ;
               AV25ExiteVinculo = GXt_char2;
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000611 */
            pr_default.execute(9, new Object[] {A18SecUserId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agrupar Usuarios y Proveedores", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000612 */
            pr_default.execute(10, new Object[] {A18SecUserId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Sec User Role", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel067( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete067( ) ;
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

      public void ScanKeyStart067( )
      {
         /* Scan By routine */
         /* Using cursor BC000613 */
         pr_default.execute(11, new Object[] {A18SecUserId});
         RcdFound7 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound7 = 1;
            A18SecUserId = BC000613_A18SecUserId[0];
            A27SecUserPassword = BC000613_A27SecUserPassword[0];
            A26SecUserName = BC000613_A26SecUserName[0];
            A587SecUserFullName = BC000613_A587SecUserFullName[0];
            A222usuariosNombre = BC000613_A222usuariosNombre[0];
            A223usuariosPasw = BC000613_A223usuariosPasw[0];
            A226usuariosEstado = BC000613_A226usuariosEstado[0];
            A40000usuariosImagen_GXI = BC000613_A40000usuariosImagen_GXI[0];
            A225usuariosTipo = BC000613_A225usuariosTipo[0];
            A550SecUserEstado = BC000613_A550SecUserEstado[0];
            n550SecUserEstado = BC000613_n550SecUserEstado[0];
            A145usuariosId = BC000613_A145usuariosId[0];
            n145usuariosId = BC000613_n145usuariosId[0];
            A266usuariosImagen = BC000613_A266usuariosImagen[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext067( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound7 = 0;
         ScanKeyLoad067( ) ;
      }

      protected void ScanKeyLoad067( )
      {
         sMode7 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound7 = 1;
            A18SecUserId = BC000613_A18SecUserId[0];
            A27SecUserPassword = BC000613_A27SecUserPassword[0];
            A26SecUserName = BC000613_A26SecUserName[0];
            A587SecUserFullName = BC000613_A587SecUserFullName[0];
            A222usuariosNombre = BC000613_A222usuariosNombre[0];
            A223usuariosPasw = BC000613_A223usuariosPasw[0];
            A226usuariosEstado = BC000613_A226usuariosEstado[0];
            A40000usuariosImagen_GXI = BC000613_A40000usuariosImagen_GXI[0];
            A225usuariosTipo = BC000613_A225usuariosTipo[0];
            A550SecUserEstado = BC000613_A550SecUserEstado[0];
            n550SecUserEstado = BC000613_n550SecUserEstado[0];
            A145usuariosId = BC000613_A145usuariosId[0];
            n145usuariosId = BC000613_n145usuariosId[0];
            A266usuariosImagen = BC000613_A266usuariosImagen[0];
         }
         Gx_mode = sMode7;
      }

      protected void ScanKeyEnd067( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm067( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert067( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate067( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete067( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete067( )
      {
         /* Before Complete Rules */
         if ( IsUpd( )  || IsDlt( )  )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_updateuserextended(context ).execute( ) ;
         }
      }

      protected void BeforeValidate067( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes067( )
      {
      }

      protected void send_integrity_lvl_hashes067( )
      {
      }

      protected void AddRow067( )
      {
         VarsToRow7( bcwwpbaseobjects_SecUser) ;
      }

      protected void ReadRow067( )
      {
         RowToVars7( bcwwpbaseobjects_SecUser, 1) ;
      }

      protected void InitializeNonKey067( )
      {
         AV26OldSecUserName = "";
         AV27OldusuariosId = "";
         AV30OdlusuariosPasw = "";
         A27SecUserPassword = "";
         A26SecUserName = "";
         A587SecUserFullName = "";
         A145usuariosId = "";
         n145usuariosId = false;
         A222usuariosNombre = "";
         A223usuariosPasw = "";
         A226usuariosEstado = "";
         A266usuariosImagen = "";
         A40000usuariosImagen_GXI = "";
         A225usuariosTipo = "";
         A550SecUserEstado = "HAB";
         n550SecUserEstado = false;
         O27SecUserPassword = A27SecUserPassword;
         O145usuariosId = A145usuariosId;
         n145usuariosId = false;
         O26SecUserName = A26SecUserName;
         Z27SecUserPassword = "";
         Z26SecUserName = "";
         Z587SecUserFullName = "";
         Z550SecUserEstado = "";
         Z145usuariosId = "";
      }

      protected void InitAll067( )
      {
         A18SecUserId = 0;
         InitializeNonKey067( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A550SecUserEstado = i550SecUserEstado;
         n550SecUserEstado = false;
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

      public void VarsToRow7( GeneXus.Programs.wwpbaseobjects.SdtSecUser obj7 )
      {
         obj7.gxTpr_Mode = Gx_mode;
         obj7.gxTpr_Secuserpassword = A27SecUserPassword;
         obj7.gxTpr_Secusername = A26SecUserName;
         obj7.gxTpr_Secuserfullname = A587SecUserFullName;
         obj7.gxTpr_Usuariosid = A145usuariosId;
         obj7.gxTpr_Usuariosnombre = A222usuariosNombre;
         obj7.gxTpr_Usuariospasw = A223usuariosPasw;
         obj7.gxTpr_Usuariosestado = A226usuariosEstado;
         obj7.gxTpr_Usuariosimagen = A266usuariosImagen;
         obj7.gxTpr_Usuariosimagen_gxi = A40000usuariosImagen_GXI;
         obj7.gxTpr_Usuariostipo = A225usuariosTipo;
         obj7.gxTpr_Secuserestado = A550SecUserEstado;
         obj7.gxTpr_Secuserid = A18SecUserId;
         obj7.gxTpr_Secuserid_Z = Z18SecUserId;
         obj7.gxTpr_Secusername_Z = Z26SecUserName;
         obj7.gxTpr_Secuserfullname_Z = Z587SecUserFullName;
         obj7.gxTpr_Secuserpassword_Z = Z27SecUserPassword;
         obj7.gxTpr_Usuariosid_Z = Z145usuariosId;
         obj7.gxTpr_Usuariosnombre_Z = Z222usuariosNombre;
         obj7.gxTpr_Usuariospasw_Z = Z223usuariosPasw;
         obj7.gxTpr_Usuariosestado_Z = Z226usuariosEstado;
         obj7.gxTpr_Usuariostipo_Z = Z225usuariosTipo;
         obj7.gxTpr_Secuserestado_Z = Z550SecUserEstado;
         obj7.gxTpr_Usuariosimagen_gxi_Z = Z40000usuariosImagen_GXI;
         obj7.gxTpr_Usuariosid_N = (short)(Convert.ToInt16(n145usuariosId));
         obj7.gxTpr_Secuserestado_N = (short)(Convert.ToInt16(n550SecUserEstado));
         obj7.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow7( GeneXus.Programs.wwpbaseobjects.SdtSecUser obj7 )
      {
         obj7.gxTpr_Secuserid = A18SecUserId;
         return  ;
      }

      public void RowToVars7( GeneXus.Programs.wwpbaseobjects.SdtSecUser obj7 ,
                              int forceLoad )
      {
         Gx_mode = obj7.gxTpr_Mode;
         A27SecUserPassword = obj7.gxTpr_Secuserpassword;
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) ) || ( forceLoad == 1 ) )
         {
            A26SecUserName = obj7.gxTpr_Secusername;
         }
         A587SecUserFullName = obj7.gxTpr_Secuserfullname;
         A145usuariosId = obj7.gxTpr_Usuariosid;
         n145usuariosId = false;
         A222usuariosNombre = obj7.gxTpr_Usuariosnombre;
         A223usuariosPasw = obj7.gxTpr_Usuariospasw;
         A226usuariosEstado = obj7.gxTpr_Usuariosestado;
         A266usuariosImagen = obj7.gxTpr_Usuariosimagen;
         A40000usuariosImagen_GXI = obj7.gxTpr_Usuariosimagen_gxi;
         A225usuariosTipo = obj7.gxTpr_Usuariostipo;
         A550SecUserEstado = obj7.gxTpr_Secuserestado;
         n550SecUserEstado = false;
         A18SecUserId = obj7.gxTpr_Secuserid;
         Z18SecUserId = obj7.gxTpr_Secuserid_Z;
         Z26SecUserName = obj7.gxTpr_Secusername_Z;
         O26SecUserName = obj7.gxTpr_Secusername_Z;
         Z587SecUserFullName = obj7.gxTpr_Secuserfullname_Z;
         Z27SecUserPassword = obj7.gxTpr_Secuserpassword_Z;
         O27SecUserPassword = obj7.gxTpr_Secuserpassword_Z;
         Z145usuariosId = obj7.gxTpr_Usuariosid_Z;
         O145usuariosId = obj7.gxTpr_Usuariosid_Z;
         Z222usuariosNombre = obj7.gxTpr_Usuariosnombre_Z;
         Z223usuariosPasw = obj7.gxTpr_Usuariospasw_Z;
         Z226usuariosEstado = obj7.gxTpr_Usuariosestado_Z;
         Z225usuariosTipo = obj7.gxTpr_Usuariostipo_Z;
         Z550SecUserEstado = obj7.gxTpr_Secuserestado_Z;
         Z40000usuariosImagen_GXI = obj7.gxTpr_Usuariosimagen_gxi_Z;
         n145usuariosId = (bool)(Convert.ToBoolean(obj7.gxTpr_Usuariosid_N));
         n550SecUserEstado = (bool)(Convert.ToBoolean(obj7.gxTpr_Secuserestado_N));
         Gx_mode = obj7.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A18SecUserId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey067( ) ;
         ScanKeyStart067( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z18SecUserId = A18SecUserId;
            O27SecUserPassword = A27SecUserPassword;
            O145usuariosId = A145usuariosId;
            n145usuariosId = false;
            O26SecUserName = A26SecUserName;
         }
         ZM067( -17) ;
         OnLoadActions067( ) ;
         AddRow067( ) ;
         ScanKeyEnd067( ) ;
         if ( RcdFound7 == 0 )
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
         RowToVars7( bcwwpbaseobjects_SecUser, 0) ;
         ScanKeyStart067( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z18SecUserId = A18SecUserId;
            O27SecUserPassword = A27SecUserPassword;
            O145usuariosId = A145usuariosId;
            n145usuariosId = false;
            O26SecUserName = A26SecUserName;
         }
         ZM067( -17) ;
         OnLoadActions067( ) ;
         AddRow067( ) ;
         ScanKeyEnd067( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey067( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert067( ) ;
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A18SecUserId != Z18SecUserId )
               {
                  A18SecUserId = Z18SecUserId;
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
                  Update067( ) ;
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
                  if ( A18SecUserId != Z18SecUserId )
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
                        Insert067( ) ;
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
                        Insert067( ) ;
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
         RowToVars7( bcwwpbaseobjects_SecUser, 1) ;
         SaveImpl( ) ;
         VarsToRow7( bcwwpbaseobjects_SecUser) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars7( bcwwpbaseobjects_SecUser, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert067( ) ;
         AfterTrn( ) ;
         VarsToRow7( bcwwpbaseobjects_SecUser) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow7( bcwwpbaseobjects_SecUser) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtSecUser auxBC = new GeneXus.Programs.wwpbaseobjects.SdtSecUser(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A18SecUserId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_SecUser);
               auxBC.Save();
               bcwwpbaseobjects_SecUser.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars7( bcwwpbaseobjects_SecUser, 1) ;
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
         RowToVars7( bcwwpbaseobjects_SecUser, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert067( ) ;
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
               VarsToRow7( bcwwpbaseobjects_SecUser) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow7( bcwwpbaseobjects_SecUser) ;
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
         RowToVars7( bcwwpbaseobjects_SecUser, 0) ;
         GetKey067( ) ;
         if ( RcdFound7 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A18SecUserId != Z18SecUserId )
            {
               A18SecUserId = Z18SecUserId;
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
            if ( A18SecUserId != Z18SecUserId )
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
         context.RollbackDataStores("wwpbaseobjects.secuser_bc",pr_default);
         VarsToRow7( bcwwpbaseobjects_SecUser) ;
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
         Gx_mode = bcwwpbaseobjects_SecUser.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_SecUser.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_SecUser )
         {
            bcwwpbaseobjects_SecUser = (GeneXus.Programs.wwpbaseobjects.SdtSecUser)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_SecUser.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_SecUser.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow7( bcwwpbaseobjects_SecUser) ;
            }
            else
            {
               RowToVars7( bcwwpbaseobjects_SecUser, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_SecUser.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_SecUser.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars7( bcwwpbaseobjects_SecUser, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSecUser SecUser_BC
      {
         get {
            return bcwwpbaseobjects_SecUser ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV15WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV32Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV17TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV16Insert_usuariosId = "";
         AV24Exite = "";
         AV25ExiteVinculo = "";
         AV28UserPassword = "";
         A145usuariosId = "";
         A27SecUserPassword = "";
         Z27SecUserPassword = "";
         Z26SecUserName = "";
         A26SecUserName = "";
         Z587SecUserFullName = "";
         A587SecUserFullName = "";
         Z550SecUserEstado = "";
         A550SecUserEstado = "";
         Z145usuariosId = "";
         Z222usuariosNombre = "";
         A222usuariosNombre = "";
         Z223usuariosPasw = "";
         A223usuariosPasw = "";
         Z226usuariosEstado = "";
         A226usuariosEstado = "";
         Z225usuariosTipo = "";
         A225usuariosTipo = "";
         Z266usuariosImagen = "";
         A266usuariosImagen = "";
         Z40000usuariosImagen_GXI = "";
         A40000usuariosImagen_GXI = "";
         AV30OdlusuariosPasw = "";
         O27SecUserPassword = "";
         BC00065_A18SecUserId = new long[1] ;
         BC00065_A27SecUserPassword = new string[] {""} ;
         BC00065_A26SecUserName = new string[] {""} ;
         BC00065_A587SecUserFullName = new string[] {""} ;
         BC00065_A222usuariosNombre = new string[] {""} ;
         BC00065_A223usuariosPasw = new string[] {""} ;
         BC00065_A226usuariosEstado = new string[] {""} ;
         BC00065_A40000usuariosImagen_GXI = new string[] {""} ;
         BC00065_A225usuariosTipo = new string[] {""} ;
         BC00065_A550SecUserEstado = new string[] {""} ;
         BC00065_n550SecUserEstado = new bool[] {false} ;
         BC00065_A145usuariosId = new string[] {""} ;
         BC00065_n145usuariosId = new bool[] {false} ;
         BC00065_A266usuariosImagen = new string[] {""} ;
         AV26OldSecUserName = "";
         O26SecUserName = "";
         AV27OldusuariosId = "";
         O145usuariosId = "";
         BC00064_A222usuariosNombre = new string[] {""} ;
         BC00064_A223usuariosPasw = new string[] {""} ;
         BC00064_A226usuariosEstado = new string[] {""} ;
         BC00064_A40000usuariosImagen_GXI = new string[] {""} ;
         BC00064_A225usuariosTipo = new string[] {""} ;
         BC00064_A266usuariosImagen = new string[] {""} ;
         BC00066_A18SecUserId = new long[1] ;
         BC00063_A18SecUserId = new long[1] ;
         BC00063_A27SecUserPassword = new string[] {""} ;
         BC00063_A26SecUserName = new string[] {""} ;
         BC00063_A587SecUserFullName = new string[] {""} ;
         BC00063_A550SecUserEstado = new string[] {""} ;
         BC00063_n550SecUserEstado = new bool[] {false} ;
         BC00063_A145usuariosId = new string[] {""} ;
         BC00063_n145usuariosId = new bool[] {false} ;
         sMode7 = "";
         BC00062_A18SecUserId = new long[1] ;
         BC00062_A27SecUserPassword = new string[] {""} ;
         BC00062_A26SecUserName = new string[] {""} ;
         BC00062_A587SecUserFullName = new string[] {""} ;
         BC00062_A550SecUserEstado = new string[] {""} ;
         BC00062_n550SecUserEstado = new bool[] {false} ;
         BC00062_A145usuariosId = new string[] {""} ;
         BC00062_n145usuariosId = new bool[] {false} ;
         BC00067_A18SecUserId = new long[1] ;
         BC000610_A222usuariosNombre = new string[] {""} ;
         BC000610_A223usuariosPasw = new string[] {""} ;
         BC000610_A226usuariosEstado = new string[] {""} ;
         BC000610_A40000usuariosImagen_GXI = new string[] {""} ;
         BC000610_A225usuariosTipo = new string[] {""} ;
         BC000610_A266usuariosImagen = new string[] {""} ;
         GXt_char2 = "";
         BC000611_A590Listaid = new long[1] ;
         BC000611_A18SecUserId = new long[1] ;
         BC000612_A18SecUserId = new long[1] ;
         BC000612_A16SecRoleId = new short[1] ;
         BC000613_A18SecUserId = new long[1] ;
         BC000613_A27SecUserPassword = new string[] {""} ;
         BC000613_A26SecUserName = new string[] {""} ;
         BC000613_A587SecUserFullName = new string[] {""} ;
         BC000613_A222usuariosNombre = new string[] {""} ;
         BC000613_A223usuariosPasw = new string[] {""} ;
         BC000613_A226usuariosEstado = new string[] {""} ;
         BC000613_A40000usuariosImagen_GXI = new string[] {""} ;
         BC000613_A225usuariosTipo = new string[] {""} ;
         BC000613_A550SecUserEstado = new string[] {""} ;
         BC000613_n550SecUserEstado = new bool[] {false} ;
         BC000613_A145usuariosId = new string[] {""} ;
         BC000613_n145usuariosId = new bool[] {false} ;
         BC000613_A266usuariosImagen = new string[] {""} ;
         N26SecUserName = "";
         i550SecUserEstado = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secuser_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secuser_bc__default(),
            new Object[][] {
                new Object[] {
               BC00062_A18SecUserId, BC00062_A27SecUserPassword, BC00062_A26SecUserName, BC00062_A587SecUserFullName, BC00062_A550SecUserEstado, BC00062_n550SecUserEstado, BC00062_A145usuariosId, BC00062_n145usuariosId
               }
               , new Object[] {
               BC00063_A18SecUserId, BC00063_A27SecUserPassword, BC00063_A26SecUserName, BC00063_A587SecUserFullName, BC00063_A550SecUserEstado, BC00063_n550SecUserEstado, BC00063_A145usuariosId, BC00063_n145usuariosId
               }
               , new Object[] {
               BC00064_A222usuariosNombre, BC00064_A223usuariosPasw, BC00064_A226usuariosEstado, BC00064_A40000usuariosImagen_GXI, BC00064_A225usuariosTipo, BC00064_A266usuariosImagen
               }
               , new Object[] {
               BC00065_A18SecUserId, BC00065_A27SecUserPassword, BC00065_A26SecUserName, BC00065_A587SecUserFullName, BC00065_A222usuariosNombre, BC00065_A223usuariosPasw, BC00065_A226usuariosEstado, BC00065_A40000usuariosImagen_GXI, BC00065_A225usuariosTipo, BC00065_A550SecUserEstado,
               BC00065_n550SecUserEstado, BC00065_A145usuariosId, BC00065_n145usuariosId, BC00065_A266usuariosImagen
               }
               , new Object[] {
               BC00066_A18SecUserId
               }
               , new Object[] {
               BC00067_A18SecUserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000610_A222usuariosNombre, BC000610_A223usuariosPasw, BC000610_A226usuariosEstado, BC000610_A40000usuariosImagen_GXI, BC000610_A225usuariosTipo, BC000610_A266usuariosImagen
               }
               , new Object[] {
               BC000611_A590Listaid, BC000611_A18SecUserId
               }
               , new Object[] {
               BC000612_A18SecUserId, BC000612_A16SecRoleId
               }
               , new Object[] {
               BC000613_A18SecUserId, BC000613_A27SecUserPassword, BC000613_A26SecUserName, BC000613_A587SecUserFullName, BC000613_A222usuariosNombre, BC000613_A223usuariosPasw, BC000613_A226usuariosEstado, BC000613_A40000usuariosImagen_GXI, BC000613_A225usuariosTipo, BC000613_A550SecUserEstado,
               BC000613_n550SecUserEstado, BC000613_A145usuariosId, BC000613_n145usuariosId, BC000613_A266usuariosImagen
               }
            }
         );
         AV32Pgmname = "WWPBaseObjects.SecUser_BC";
         Z550SecUserEstado = "HAB";
         n550SecUserEstado = false;
         A550SecUserEstado = "HAB";
         n550SecUserEstado = false;
         i550SecUserEstado = "HAB";
         n550SecUserEstado = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12062 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound7 ;
      private int trnEnded ;
      private int AV33GXV1 ;
      private long Z18SecUserId ;
      private long A18SecUserId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV32Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV16Insert_usuariosId ;
      private string AV24Exite ;
      private string AV25ExiteVinculo ;
      private string A145usuariosId ;
      private string Z550SecUserEstado ;
      private string A550SecUserEstado ;
      private string Z145usuariosId ;
      private string Z222usuariosNombre ;
      private string A222usuariosNombre ;
      private string Z223usuariosPasw ;
      private string A223usuariosPasw ;
      private string Z226usuariosEstado ;
      private string A226usuariosEstado ;
      private string Z225usuariosTipo ;
      private string A225usuariosTipo ;
      private string AV30OdlusuariosPasw ;
      private string AV27OldusuariosId ;
      private string O145usuariosId ;
      private string sMode7 ;
      private string GXt_char2 ;
      private string i550SecUserEstado ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool n550SecUserEstado ;
      private bool n145usuariosId ;
      private string AV28UserPassword ;
      private string A27SecUserPassword ;
      private string Z27SecUserPassword ;
      private string Z26SecUserName ;
      private string A26SecUserName ;
      private string Z587SecUserFullName ;
      private string A587SecUserFullName ;
      private string Z40000usuariosImagen_GXI ;
      private string A40000usuariosImagen_GXI ;
      private string O27SecUserPassword ;
      private string AV26OldSecUserName ;
      private string O26SecUserName ;
      private string N26SecUserName ;
      private string Z266usuariosImagen ;
      private string A266usuariosImagen ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV15WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private long[] BC00065_A18SecUserId ;
      private string[] BC00065_A27SecUserPassword ;
      private string[] BC00065_A26SecUserName ;
      private string[] BC00065_A587SecUserFullName ;
      private string[] BC00065_A222usuariosNombre ;
      private string[] BC00065_A223usuariosPasw ;
      private string[] BC00065_A226usuariosEstado ;
      private string[] BC00065_A40000usuariosImagen_GXI ;
      private string[] BC00065_A225usuariosTipo ;
      private string[] BC00065_A550SecUserEstado ;
      private bool[] BC00065_n550SecUserEstado ;
      private string[] BC00065_A145usuariosId ;
      private bool[] BC00065_n145usuariosId ;
      private string[] BC00065_A266usuariosImagen ;
      private string[] BC00064_A222usuariosNombre ;
      private string[] BC00064_A223usuariosPasw ;
      private string[] BC00064_A226usuariosEstado ;
      private string[] BC00064_A40000usuariosImagen_GXI ;
      private string[] BC00064_A225usuariosTipo ;
      private string[] BC00064_A266usuariosImagen ;
      private long[] BC00066_A18SecUserId ;
      private long[] BC00063_A18SecUserId ;
      private string[] BC00063_A27SecUserPassword ;
      private string[] BC00063_A26SecUserName ;
      private string[] BC00063_A587SecUserFullName ;
      private string[] BC00063_A550SecUserEstado ;
      private bool[] BC00063_n550SecUserEstado ;
      private string[] BC00063_A145usuariosId ;
      private bool[] BC00063_n145usuariosId ;
      private long[] BC00062_A18SecUserId ;
      private string[] BC00062_A27SecUserPassword ;
      private string[] BC00062_A26SecUserName ;
      private string[] BC00062_A587SecUserFullName ;
      private string[] BC00062_A550SecUserEstado ;
      private bool[] BC00062_n550SecUserEstado ;
      private string[] BC00062_A145usuariosId ;
      private bool[] BC00062_n145usuariosId ;
      private long[] BC00067_A18SecUserId ;
      private string[] BC000610_A222usuariosNombre ;
      private string[] BC000610_A223usuariosPasw ;
      private string[] BC000610_A226usuariosEstado ;
      private string[] BC000610_A40000usuariosImagen_GXI ;
      private string[] BC000610_A225usuariosTipo ;
      private string[] BC000610_A266usuariosImagen ;
      private long[] BC000611_A590Listaid ;
      private long[] BC000611_A18SecUserId ;
      private long[] BC000612_A18SecUserId ;
      private short[] BC000612_A16SecRoleId ;
      private long[] BC000613_A18SecUserId ;
      private string[] BC000613_A27SecUserPassword ;
      private string[] BC000613_A26SecUserName ;
      private string[] BC000613_A587SecUserFullName ;
      private string[] BC000613_A222usuariosNombre ;
      private string[] BC000613_A223usuariosPasw ;
      private string[] BC000613_A226usuariosEstado ;
      private string[] BC000613_A40000usuariosImagen_GXI ;
      private string[] BC000613_A225usuariosTipo ;
      private string[] BC000613_A550SecUserEstado ;
      private bool[] BC000613_n550SecUserEstado ;
      private string[] BC000613_A145usuariosId ;
      private bool[] BC000613_n145usuariosId ;
      private string[] BC000613_A266usuariosImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecUser bcwwpbaseobjects_SecUser ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class secuser_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class secuser_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00062;
        prmBC00062 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmBC00063;
        prmBC00063 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmBC00064;
        prmBC00064 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmBC00065;
        prmBC00065 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmBC00066;
        prmBC00066 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmBC00067;
        prmBC00067 = new Object[] {
        new ParDef("@SecUserPassword",GXType.NVarChar,100,0) ,
        new ParDef("@SecUserName",GXType.NVarChar,100,0) ,
        new ParDef("@SecUserFullName",GXType.NVarChar,120,0) ,
        new ParDef("@SecUserEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmBC00068;
        prmBC00068 = new Object[] {
        new ParDef("@SecUserPassword",GXType.NVarChar,100,0) ,
        new ParDef("@SecUserName",GXType.NVarChar,100,0) ,
        new ParDef("@SecUserFullName",GXType.NVarChar,120,0) ,
        new ParDef("@SecUserEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmBC00069;
        prmBC00069 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmBC000610;
        prmBC000610 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmBC000611;
        prmBC000611 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmBC000612;
        prmBC000612 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmBC000613;
        prmBC000613 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00062", "SELECT [SecUserId], [SecUserPassword], [SecUserName], [SecUserFullName], [SecUserEstado], [usuariosId] FROM [SecUser] WITH (UPDLOCK) WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00062,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00063", "SELECT [SecUserId], [SecUserPassword], [SecUserName], [SecUserFullName], [SecUserEstado], [usuariosId] FROM [SecUser] WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00063,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00064", "SELECT [usuariosNombre], [usuariosPasw], [usuariosEstado], [usuariosImagen_GXI], [usuariosTipo], [usuariosImagen] FROM [usuarios] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00064,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00065", "SELECT TM1.[SecUserId], TM1.[SecUserPassword], TM1.[SecUserName], TM1.[SecUserFullName], T2.[usuariosNombre], T2.[usuariosPasw], T2.[usuariosEstado], T2.[usuariosImagen_GXI], T2.[usuariosTipo], TM1.[SecUserEstado], TM1.[usuariosId], T2.[usuariosImagen] FROM ([SecUser] TM1 LEFT JOIN [usuarios] T2 ON T2.[usuariosId] = TM1.[usuariosId]) WHERE TM1.[SecUserId] = @SecUserId ORDER BY TM1.[SecUserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00065,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00066", "SELECT [SecUserId] FROM [SecUser] WHERE [SecUserId] = @SecUserId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00066,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00067", "INSERT INTO [SecUser]([SecUserPassword], [SecUserName], [SecUserFullName], [SecUserEstado], [usuariosId]) VALUES(@SecUserPassword, @SecUserName, @SecUserFullName, @SecUserEstado, @usuariosId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00067,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC00068", "UPDATE [SecUser] SET [SecUserPassword]=@SecUserPassword, [SecUserName]=@SecUserName, [SecUserFullName]=@SecUserFullName, [SecUserEstado]=@SecUserEstado, [usuariosId]=@usuariosId  WHERE [SecUserId] = @SecUserId", GxErrorMask.GX_NOMASK,prmBC00068)
           ,new CursorDef("BC00069", "DELETE FROM [SecUser]  WHERE [SecUserId] = @SecUserId", GxErrorMask.GX_NOMASK,prmBC00069)
           ,new CursorDef("BC000610", "SELECT [usuariosNombre], [usuariosPasw], [usuariosEstado], [usuariosImagen_GXI], [usuariosTipo], [usuariosImagen] FROM [usuarios] WHERE [usuariosId] = @usuariosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000610,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000611", "SELECT TOP 1 [Listaid], [SecUserId] FROM [ListaAgrUser] WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000611,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000612", "SELECT TOP 1 [SecUserId], [SecRoleId] FROM [SecUserRole] WHERE [SecUserId] = @SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000612,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000613", "SELECT TM1.[SecUserId], TM1.[SecUserPassword], TM1.[SecUserName], TM1.[SecUserFullName], T2.[usuariosNombre], T2.[usuariosPasw], T2.[usuariosEstado], T2.[usuariosImagen_GXI], T2.[usuariosTipo], TM1.[SecUserEstado], TM1.[usuariosId], T2.[usuariosImagen] FROM ([SecUser] TM1 LEFT JOIN [usuarios] T2 ON T2.[usuariosId] = TM1.[usuariosId]) WHERE TM1.[SecUserId] = @SecUserId ORDER BY TM1.[SecUserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000613,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((string[]) buf[5])[0] = rslt.getString(6, 80);
              ((string[]) buf[6])[0] = rslt.getString(7, 3);
              ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 1);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 20);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(8));
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((string[]) buf[5])[0] = rslt.getString(6, 80);
              ((string[]) buf[6])[0] = rslt.getString(7, 3);
              ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 1);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 20);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(8));
              return;
     }
  }

}

}
