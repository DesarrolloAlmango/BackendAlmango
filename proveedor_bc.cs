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
   public class proveedor_bc : GXHttpHandler, IGxSilentTrn
   {
      public proveedor_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public proveedor_bc( IGxContext context )
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
         ReadRow0N28( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0N28( ) ;
         standaloneModal( ) ;
         AddRow0N28( ) ;
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
            E110N2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z133ProveedorID = A133ProveedorID;
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

      protected void CONFIRM_0N0( )
      {
         BeforeValidate0N28( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0N28( ) ;
            }
            else
            {
               CheckExtendedTable0N28( ) ;
               if ( AnyError == 0 )
               {
                  ZM0N28( 16) ;
                  ZM0N28( 17) ;
                  ZM0N28( 18) ;
               }
               CloseExtendedTableCursors0N28( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode28 = Gx_mode;
            CONFIRM_0N29( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode28;
            }
            /* Restore parent mode. */
            Gx_mode = sMode28;
         }
      }

      protected void CONFIRM_0N29( )
      {
         nGXsfl_29_idx = 0;
         while ( nGXsfl_29_idx < bcProveedor.gxTpr_Comision.Count )
         {
            ReadRow0N29( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound29 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_29 != 0 ) )
            {
               GetKey0N29( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound29 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0N29( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0N29( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0N29( 20) ;
                           ZM0N29( 21) ;
                           ZM0N29( 22) ;
                           ZM0N29( 23) ;
                        }
                        CloseExtendedTableCursors0N29( ) ;
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
                  if ( RcdFound29 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0N29( ) ;
                        Load0N29( ) ;
                        BeforeValidate0N29( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0N29( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_29 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0N29( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0N29( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0N29( 20) ;
                                 ZM0N29( 21) ;
                                 ZM0N29( 22) ;
                                 ZM0N29( 23) ;
                              }
                              CloseExtendedTableCursors0N29( ) ;
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
               VarsToRow29( ((SdtProveedor_Comision)bcProveedor.gxTpr_Comision.Item(nGXsfl_29_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120N2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV40Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV40Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV41GXV1 = 1;
            while ( AV41GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV41GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "ProveedoresTipoId") == 0 )
               {
                  AV13Insert_ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "DocumentacionId") == 0 )
               {
                  AV14Insert_DocumentacionId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "BancoId") == 0 )
               {
                  AV36Insert_BancoId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV41GXV1 = (int)(AV41GXV1+1);
            }
         }
         /* Execute user subroutine: 'OBTENGO ROL' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E110N2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'OBTENGO ROL' Routine */
         returnInSub = false;
         AV31Roles = AV8WWPContext.gxTpr_Roles;
         AV42GXV2 = 1;
         while ( AV42GXV2 <= AV31Roles.gxTpr_Roles.Count )
         {
            AV32RolesItem = ((SdtSDTRoles_Id)AV31Roles.gxTpr_Roles.Item(AV42GXV2));
            AV34SecRoleName = AV32RolesItem.gxTpr_Secrolename;
            AV42GXV2 = (int)(AV42GXV2+1);
         }
         if ( ( ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV34SecRoleName)), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) ) || ( ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV34SecRoleName)), context.GetMessage( "ADM GENERAL", "")) == 0 ) ) )
         {
         }
         else
         {
            new olisagruserprovid(context ).execute(  AV8WWPContext.gxTpr_Userid,  AV7ProveedorID,  "ADM", out  AV37Existe, out  AV33AgrProveedorEstado) ;
            if ( StringUtil.StrCmp(AV33AgrProveedorEstado, "VIN") != 0 )
            {
            }
         }
      }

      protected void ZM0N28( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z546ProveedorUsrAlta = A546ProveedorUsrAlta;
            Z547ProveedorUsrActualizacion = A547ProveedorUsrActualizacion;
            Z548ProveedorFechaAlta = A548ProveedorFechaAlta;
            Z549ProveedorFechaActualizacion = A549ProveedorFechaActualizacion;
            Z282ProveedorNombre = A282ProveedorNombre;
            Z682ProveedorRazonSocial = A682ProveedorRazonSocial;
            Z683ProveedorContacto = A683ProveedorContacto;
            Z684ProveedorContactoCell = A684ProveedorContactoCell;
            Z338ProveedorDocIdentidad = A338ProveedorDocIdentidad;
            Z345ProveedorSerialComi = A345ProveedorSerialComi;
            Z430ProveedorTelefono = A430ProveedorTelefono;
            Z431ProveedorDireccion = A431ProveedorDireccion;
            Z433ProveedorEmail = A433ProveedorEmail;
            Z685ProveedorSitioWeb = A685ProveedorSitioWeb;
            Z686ProveedorAceptoTerminos = A686ProveedorAceptoTerminos;
            Z437ProveedorPerAltShop = A437ProveedorPerAltShop;
            Z344ProveedorEstado = A344ProveedorEstado;
            Z440ProveedorPagoDefault = A440ProveedorPagoDefault;
            Z490ProveedorPideDoc = A490ProveedorPideDoc;
            Z601ProveedorUsoInterno = A601ProveedorUsoInterno;
            Z687ProveedorCuentaBancaria = A687ProveedorCuentaBancaria;
            Z978ProveedorCIU = A978ProveedorCIU;
            Z999ProveedorFreezePrice = A999ProveedorFreezePrice;
            Z151ProveedoresTipoId = A151ProveedoresTipoId;
            Z488DocumentacionId = A488DocumentacionId;
            Z673BancoId = A673BancoId;
         }
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z278ProveedoresTipoNombre = A278ProveedoresTipoNombre;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z674BancoNombre = A674BancoNombre;
         }
         if ( GX_JID == -15 )
         {
            Z133ProveedorID = A133ProveedorID;
            Z546ProveedorUsrAlta = A546ProveedorUsrAlta;
            Z547ProveedorUsrActualizacion = A547ProveedorUsrActualizacion;
            Z548ProveedorFechaAlta = A548ProveedorFechaAlta;
            Z549ProveedorFechaActualizacion = A549ProveedorFechaActualizacion;
            Z282ProveedorNombre = A282ProveedorNombre;
            Z682ProveedorRazonSocial = A682ProveedorRazonSocial;
            Z683ProveedorContacto = A683ProveedorContacto;
            Z684ProveedorContactoCell = A684ProveedorContactoCell;
            Z432ProveedorImagen = A432ProveedorImagen;
            Z40000ProveedorImagen_GXI = A40000ProveedorImagen_GXI;
            Z338ProveedorDocIdentidad = A338ProveedorDocIdentidad;
            Z345ProveedorSerialComi = A345ProveedorSerialComi;
            Z430ProveedorTelefono = A430ProveedorTelefono;
            Z431ProveedorDireccion = A431ProveedorDireccion;
            Z433ProveedorEmail = A433ProveedorEmail;
            Z685ProveedorSitioWeb = A685ProveedorSitioWeb;
            Z686ProveedorAceptoTerminos = A686ProveedorAceptoTerminos;
            Z437ProveedorPerAltShop = A437ProveedorPerAltShop;
            Z344ProveedorEstado = A344ProveedorEstado;
            Z440ProveedorPagoDefault = A440ProveedorPagoDefault;
            Z490ProveedorPideDoc = A490ProveedorPideDoc;
            Z601ProveedorUsoInterno = A601ProveedorUsoInterno;
            Z687ProveedorCuentaBancaria = A687ProveedorCuentaBancaria;
            Z978ProveedorCIU = A978ProveedorCIU;
            Z999ProveedorFreezePrice = A999ProveedorFreezePrice;
            Z151ProveedoresTipoId = A151ProveedoresTipoId;
            Z488DocumentacionId = A488DocumentacionId;
            Z673BancoId = A673BancoId;
            Z278ProveedoresTipoNombre = A278ProveedoresTipoNombre;
            Z498DocumentacionIcono = A498DocumentacionIcono;
            Z40001DocumentacionIcono_GXI = A40001DocumentacionIcono_GXI;
            Z674BancoNombre = A674BancoNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A548ProveedorFechaAlta = DateTimeUtil.ServerNow( context, pr_default);
            n548ProveedorFechaAlta = false;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            A549ProveedorFechaActualizacion = DateTimeUtil.ServerNow( context, pr_default);
            n549ProveedorFechaActualizacion = false;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A546ProveedorUsrAlta = AV8WWPContext.gxTpr_Userid;
            n546ProveedorUsrAlta = false;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            A547ProveedorUsrActualizacion = AV8WWPContext.gxTpr_Userid;
            n547ProveedorUsrActualizacion = false;
         }
         if ( IsIns( )  && (false==A978ProveedorCIU) && ( Gx_BScreen == 0 ) )
         {
            A978ProveedorCIU = false;
         }
         if ( IsIns( )  && (false==A999ProveedorFreezePrice) && ( Gx_BScreen == 0 ) )
         {
            A999ProveedorFreezePrice = false;
            n999ProveedorFreezePrice = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0N28( )
      {
         /* Using cursor BC000N13 */
         pr_default.execute(11, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound28 = 1;
            A546ProveedorUsrAlta = BC000N13_A546ProveedorUsrAlta[0];
            n546ProveedorUsrAlta = BC000N13_n546ProveedorUsrAlta[0];
            A547ProveedorUsrActualizacion = BC000N13_A547ProveedorUsrActualizacion[0];
            n547ProveedorUsrActualizacion = BC000N13_n547ProveedorUsrActualizacion[0];
            A548ProveedorFechaAlta = BC000N13_A548ProveedorFechaAlta[0];
            n548ProveedorFechaAlta = BC000N13_n548ProveedorFechaAlta[0];
            A549ProveedorFechaActualizacion = BC000N13_A549ProveedorFechaActualizacion[0];
            n549ProveedorFechaActualizacion = BC000N13_n549ProveedorFechaActualizacion[0];
            A278ProveedoresTipoNombre = BC000N13_A278ProveedoresTipoNombre[0];
            A282ProveedorNombre = BC000N13_A282ProveedorNombre[0];
            A682ProveedorRazonSocial = BC000N13_A682ProveedorRazonSocial[0];
            n682ProveedorRazonSocial = BC000N13_n682ProveedorRazonSocial[0];
            A683ProveedorContacto = BC000N13_A683ProveedorContacto[0];
            n683ProveedorContacto = BC000N13_n683ProveedorContacto[0];
            A684ProveedorContactoCell = BC000N13_A684ProveedorContactoCell[0];
            n684ProveedorContactoCell = BC000N13_n684ProveedorContactoCell[0];
            A40000ProveedorImagen_GXI = BC000N13_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = BC000N13_n40000ProveedorImagen_GXI[0];
            A338ProveedorDocIdentidad = BC000N13_A338ProveedorDocIdentidad[0];
            A345ProveedorSerialComi = BC000N13_A345ProveedorSerialComi[0];
            A430ProveedorTelefono = BC000N13_A430ProveedorTelefono[0];
            n430ProveedorTelefono = BC000N13_n430ProveedorTelefono[0];
            A431ProveedorDireccion = BC000N13_A431ProveedorDireccion[0];
            n431ProveedorDireccion = BC000N13_n431ProveedorDireccion[0];
            A433ProveedorEmail = BC000N13_A433ProveedorEmail[0];
            n433ProveedorEmail = BC000N13_n433ProveedorEmail[0];
            A685ProveedorSitioWeb = BC000N13_A685ProveedorSitioWeb[0];
            n685ProveedorSitioWeb = BC000N13_n685ProveedorSitioWeb[0];
            A686ProveedorAceptoTerminos = BC000N13_A686ProveedorAceptoTerminos[0];
            n686ProveedorAceptoTerminos = BC000N13_n686ProveedorAceptoTerminos[0];
            A437ProveedorPerAltShop = BC000N13_A437ProveedorPerAltShop[0];
            n437ProveedorPerAltShop = BC000N13_n437ProveedorPerAltShop[0];
            A344ProveedorEstado = BC000N13_A344ProveedorEstado[0];
            A440ProveedorPagoDefault = BC000N13_A440ProveedorPagoDefault[0];
            A490ProveedorPideDoc = BC000N13_A490ProveedorPideDoc[0];
            n490ProveedorPideDoc = BC000N13_n490ProveedorPideDoc[0];
            A40001DocumentacionIcono_GXI = BC000N13_A40001DocumentacionIcono_GXI[0];
            A601ProveedorUsoInterno = BC000N13_A601ProveedorUsoInterno[0];
            n601ProveedorUsoInterno = BC000N13_n601ProveedorUsoInterno[0];
            A687ProveedorCuentaBancaria = BC000N13_A687ProveedorCuentaBancaria[0];
            n687ProveedorCuentaBancaria = BC000N13_n687ProveedorCuentaBancaria[0];
            A674BancoNombre = BC000N13_A674BancoNombre[0];
            A978ProveedorCIU = BC000N13_A978ProveedorCIU[0];
            A999ProveedorFreezePrice = BC000N13_A999ProveedorFreezePrice[0];
            n999ProveedorFreezePrice = BC000N13_n999ProveedorFreezePrice[0];
            A151ProveedoresTipoId = BC000N13_A151ProveedoresTipoId[0];
            A488DocumentacionId = BC000N13_A488DocumentacionId[0];
            n488DocumentacionId = BC000N13_n488DocumentacionId[0];
            A673BancoId = BC000N13_A673BancoId[0];
            n673BancoId = BC000N13_n673BancoId[0];
            A432ProveedorImagen = BC000N13_A432ProveedorImagen[0];
            n432ProveedorImagen = BC000N13_n432ProveedorImagen[0];
            A498DocumentacionIcono = BC000N13_A498DocumentacionIcono[0];
            ZM0N28( -15) ;
         }
         pr_default.close(11);
         OnLoadActions0N28( ) ;
      }

      protected void OnLoadActions0N28( )
      {
         AV40Pgmname = "Proveedor_BC";
      }

      protected void CheckExtendedTable0N28( )
      {
         standaloneModal( ) ;
         AV40Pgmname = "Proveedor_BC";
         /* Using cursor BC000N10 */
         pr_default.execute(8, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
         }
         A278ProveedoresTipoNombre = BC000N10_A278ProveedoresTipoNombre[0];
         pr_default.close(8);
         if ( ! ( GxRegex.IsMatch(A433ProveedorEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A433ProveedorEmail)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A686ProveedorAceptoTerminos) || ( A686ProveedorAceptoTerminos >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Acepto Terminos y Condiciones", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A344ProveedorEstado, "BLO") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Proveedor Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) || ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) || ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Pago por Default", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000N11 */
         pr_default.execute(9, new Object[] {n488DocumentacionId, A488DocumentacionId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A488DocumentacionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Documentacion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DOCUMENTACIONID");
               AnyError = 1;
            }
         }
         A40001DocumentacionIcono_GXI = BC000N11_A40001DocumentacionIcono_GXI[0];
         A498DocumentacionIcono = BC000N11_A498DocumentacionIcono[0];
         pr_default.close(9);
         if ( ! ( (DateTime.MinValue==A548ProveedorFechaAlta) || ( A548ProveedorFechaAlta >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fechade Alta", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A549ProveedorFechaActualizacion) || ( A549ProveedorFechaActualizacion >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha de Actualizacion", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000N12 */
         pr_default.execute(10, new Object[] {n673BancoId, A673BancoId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A673BancoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Banco", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "BANCOID");
               AnyError = 1;
            }
         }
         A674BancoNombre = BC000N12_A674BancoNombre[0];
         pr_default.close(10);
      }

      protected void CloseExtendedTableCursors0N28( )
      {
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(10);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0N28( )
      {
         /* Using cursor BC000N14 */
         pr_default.execute(12, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(12);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000N9 */
         pr_default.execute(7, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            ZM0N28( 15) ;
            RcdFound28 = 1;
            A133ProveedorID = BC000N9_A133ProveedorID[0];
            n133ProveedorID = BC000N9_n133ProveedorID[0];
            A546ProveedorUsrAlta = BC000N9_A546ProveedorUsrAlta[0];
            n546ProveedorUsrAlta = BC000N9_n546ProveedorUsrAlta[0];
            A547ProveedorUsrActualizacion = BC000N9_A547ProveedorUsrActualizacion[0];
            n547ProveedorUsrActualizacion = BC000N9_n547ProveedorUsrActualizacion[0];
            A548ProveedorFechaAlta = BC000N9_A548ProveedorFechaAlta[0];
            n548ProveedorFechaAlta = BC000N9_n548ProveedorFechaAlta[0];
            A549ProveedorFechaActualizacion = BC000N9_A549ProveedorFechaActualizacion[0];
            n549ProveedorFechaActualizacion = BC000N9_n549ProveedorFechaActualizacion[0];
            A282ProveedorNombre = BC000N9_A282ProveedorNombre[0];
            A682ProveedorRazonSocial = BC000N9_A682ProveedorRazonSocial[0];
            n682ProveedorRazonSocial = BC000N9_n682ProveedorRazonSocial[0];
            A683ProveedorContacto = BC000N9_A683ProveedorContacto[0];
            n683ProveedorContacto = BC000N9_n683ProveedorContacto[0];
            A684ProveedorContactoCell = BC000N9_A684ProveedorContactoCell[0];
            n684ProveedorContactoCell = BC000N9_n684ProveedorContactoCell[0];
            A40000ProveedorImagen_GXI = BC000N9_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = BC000N9_n40000ProveedorImagen_GXI[0];
            A338ProveedorDocIdentidad = BC000N9_A338ProveedorDocIdentidad[0];
            A345ProveedorSerialComi = BC000N9_A345ProveedorSerialComi[0];
            A430ProveedorTelefono = BC000N9_A430ProveedorTelefono[0];
            n430ProveedorTelefono = BC000N9_n430ProveedorTelefono[0];
            A431ProveedorDireccion = BC000N9_A431ProveedorDireccion[0];
            n431ProveedorDireccion = BC000N9_n431ProveedorDireccion[0];
            A433ProveedorEmail = BC000N9_A433ProveedorEmail[0];
            n433ProveedorEmail = BC000N9_n433ProveedorEmail[0];
            A685ProveedorSitioWeb = BC000N9_A685ProveedorSitioWeb[0];
            n685ProveedorSitioWeb = BC000N9_n685ProveedorSitioWeb[0];
            A686ProveedorAceptoTerminos = BC000N9_A686ProveedorAceptoTerminos[0];
            n686ProveedorAceptoTerminos = BC000N9_n686ProveedorAceptoTerminos[0];
            A437ProveedorPerAltShop = BC000N9_A437ProveedorPerAltShop[0];
            n437ProveedorPerAltShop = BC000N9_n437ProveedorPerAltShop[0];
            A344ProveedorEstado = BC000N9_A344ProveedorEstado[0];
            A440ProveedorPagoDefault = BC000N9_A440ProveedorPagoDefault[0];
            A490ProveedorPideDoc = BC000N9_A490ProveedorPideDoc[0];
            n490ProveedorPideDoc = BC000N9_n490ProveedorPideDoc[0];
            A601ProveedorUsoInterno = BC000N9_A601ProveedorUsoInterno[0];
            n601ProveedorUsoInterno = BC000N9_n601ProveedorUsoInterno[0];
            A687ProveedorCuentaBancaria = BC000N9_A687ProveedorCuentaBancaria[0];
            n687ProveedorCuentaBancaria = BC000N9_n687ProveedorCuentaBancaria[0];
            A978ProveedorCIU = BC000N9_A978ProveedorCIU[0];
            A999ProveedorFreezePrice = BC000N9_A999ProveedorFreezePrice[0];
            n999ProveedorFreezePrice = BC000N9_n999ProveedorFreezePrice[0];
            A151ProveedoresTipoId = BC000N9_A151ProveedoresTipoId[0];
            A488DocumentacionId = BC000N9_A488DocumentacionId[0];
            n488DocumentacionId = BC000N9_n488DocumentacionId[0];
            A673BancoId = BC000N9_A673BancoId[0];
            n673BancoId = BC000N9_n673BancoId[0];
            A432ProveedorImagen = BC000N9_A432ProveedorImagen[0];
            n432ProveedorImagen = BC000N9_n432ProveedorImagen[0];
            Z133ProveedorID = A133ProveedorID;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0N28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey0N28( ) ;
            }
            Gx_mode = sMode28;
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey0N28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode28;
         }
         pr_default.close(7);
      }

      protected void getEqualNoModal( )
      {
         GetKey0N28( ) ;
         if ( RcdFound28 == 0 )
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
         CONFIRM_0N0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0N28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000N8 */
            pr_default.execute(6, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proveedor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(6) == 101) || ( Z546ProveedorUsrAlta != BC000N8_A546ProveedorUsrAlta[0] ) || ( Z547ProveedorUsrActualizacion != BC000N8_A547ProveedorUsrActualizacion[0] ) || ( Z548ProveedorFechaAlta != BC000N8_A548ProveedorFechaAlta[0] ) || ( Z549ProveedorFechaActualizacion != BC000N8_A549ProveedorFechaActualizacion[0] ) || ( StringUtil.StrCmp(Z282ProveedorNombre, BC000N8_A282ProveedorNombre[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z682ProveedorRazonSocial, BC000N8_A682ProveedorRazonSocial[0]) != 0 ) || ( StringUtil.StrCmp(Z683ProveedorContacto, BC000N8_A683ProveedorContacto[0]) != 0 ) || ( StringUtil.StrCmp(Z684ProveedorContactoCell, BC000N8_A684ProveedorContactoCell[0]) != 0 ) || ( StringUtil.StrCmp(Z338ProveedorDocIdentidad, BC000N8_A338ProveedorDocIdentidad[0]) != 0 ) || ( Z345ProveedorSerialComi != BC000N8_A345ProveedorSerialComi[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z430ProveedorTelefono, BC000N8_A430ProveedorTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z431ProveedorDireccion, BC000N8_A431ProveedorDireccion[0]) != 0 ) || ( StringUtil.StrCmp(Z433ProveedorEmail, BC000N8_A433ProveedorEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z685ProveedorSitioWeb, BC000N8_A685ProveedorSitioWeb[0]) != 0 ) || ( Z686ProveedorAceptoTerminos != BC000N8_A686ProveedorAceptoTerminos[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z437ProveedorPerAltShop, BC000N8_A437ProveedorPerAltShop[0]) != 0 ) || ( StringUtil.StrCmp(Z344ProveedorEstado, BC000N8_A344ProveedorEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z440ProveedorPagoDefault, BC000N8_A440ProveedorPagoDefault[0]) != 0 ) || ( StringUtil.StrCmp(Z490ProveedorPideDoc, BC000N8_A490ProveedorPideDoc[0]) != 0 ) || ( StringUtil.StrCmp(Z601ProveedorUsoInterno, BC000N8_A601ProveedorUsoInterno[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z687ProveedorCuentaBancaria, BC000N8_A687ProveedorCuentaBancaria[0]) != 0 ) || ( Z978ProveedorCIU != BC000N8_A978ProveedorCIU[0] ) || ( Z999ProveedorFreezePrice != BC000N8_A999ProveedorFreezePrice[0] ) || ( Z151ProveedoresTipoId != BC000N8_A151ProveedoresTipoId[0] ) || ( Z488DocumentacionId != BC000N8_A488DocumentacionId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z673BancoId != BC000N8_A673BancoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Proveedor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N28( )
      {
         BeforeValidate0N28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N28( 0) ;
            CheckOptimisticConcurrency0N28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N15 */
                     pr_default.execute(13, new Object[] {n546ProveedorUsrAlta, A546ProveedorUsrAlta, n547ProveedorUsrActualizacion, A547ProveedorUsrActualizacion, n548ProveedorFechaAlta, A548ProveedorFechaAlta, n549ProveedorFechaActualizacion, A549ProveedorFechaActualizacion, A282ProveedorNombre, n682ProveedorRazonSocial, A682ProveedorRazonSocial, n683ProveedorContacto, A683ProveedorContacto, n684ProveedorContactoCell, A684ProveedorContactoCell, n432ProveedorImagen, A432ProveedorImagen, n40000ProveedorImagen_GXI, A40000ProveedorImagen_GXI, A338ProveedorDocIdentidad, A345ProveedorSerialComi, n430ProveedorTelefono, A430ProveedorTelefono, n431ProveedorDireccion, A431ProveedorDireccion, n433ProveedorEmail, A433ProveedorEmail, n685ProveedorSitioWeb, A685ProveedorSitioWeb, n686ProveedorAceptoTerminos, A686ProveedorAceptoTerminos, n437ProveedorPerAltShop, A437ProveedorPerAltShop, A344ProveedorEstado, A440ProveedorPagoDefault, n490ProveedorPideDoc, A490ProveedorPideDoc, n601ProveedorUsoInterno, A601ProveedorUsoInterno, n687ProveedorCuentaBancaria, A687ProveedorCuentaBancaria, A978ProveedorCIU, n999ProveedorFreezePrice, A999ProveedorFreezePrice, A151ProveedoresTipoId, n488DocumentacionId, A488DocumentacionId, n673BancoId, A673BancoId});
                     A133ProveedorID = BC000N15_A133ProveedorID[0];
                     n133ProveedorID = BC000N15_n133ProveedorID[0];
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Proveedor");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0N28( ) ;
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
               Load0N28( ) ;
            }
            EndLevel0N28( ) ;
         }
         CloseExtendedTableCursors0N28( ) ;
      }

      protected void Update0N28( )
      {
         BeforeValidate0N28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N16 */
                     pr_default.execute(14, new Object[] {n546ProveedorUsrAlta, A546ProveedorUsrAlta, n547ProveedorUsrActualizacion, A547ProveedorUsrActualizacion, n548ProveedorFechaAlta, A548ProveedorFechaAlta, n549ProveedorFechaActualizacion, A549ProveedorFechaActualizacion, A282ProveedorNombre, n682ProveedorRazonSocial, A682ProveedorRazonSocial, n683ProveedorContacto, A683ProveedorContacto, n684ProveedorContactoCell, A684ProveedorContactoCell, A338ProveedorDocIdentidad, A345ProveedorSerialComi, n430ProveedorTelefono, A430ProveedorTelefono, n431ProveedorDireccion, A431ProveedorDireccion, n433ProveedorEmail, A433ProveedorEmail, n685ProveedorSitioWeb, A685ProveedorSitioWeb, n686ProveedorAceptoTerminos, A686ProveedorAceptoTerminos, n437ProveedorPerAltShop, A437ProveedorPerAltShop, A344ProveedorEstado, A440ProveedorPagoDefault, n490ProveedorPideDoc, A490ProveedorPideDoc, n601ProveedorUsoInterno, A601ProveedorUsoInterno, n687ProveedorCuentaBancaria, A687ProveedorCuentaBancaria, A978ProveedorCIU, n999ProveedorFreezePrice, A999ProveedorFreezePrice, A151ProveedoresTipoId, n488DocumentacionId, A488DocumentacionId, n673BancoId, A673BancoId, n133ProveedorID, A133ProveedorID});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Proveedor");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proveedor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N28( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0N28( ) ;
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
            EndLevel0N28( ) ;
         }
         CloseExtendedTableCursors0N28( ) ;
      }

      protected void DeferredUpdate0N28( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000N17 */
            pr_default.execute(15, new Object[] {n432ProveedorImagen, A432ProveedorImagen, n40000ProveedorImagen_GXI, A40000ProveedorImagen_GXI, n133ProveedorID, A133ProveedorID});
            pr_default.close(15);
            pr_default.SmartCacheProvider.SetUpdated("Proveedor");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0N28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N28( ) ;
            AfterConfirm0N28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N28( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0N29( ) ;
                  while ( RcdFound29 != 0 )
                  {
                     getByPrimaryKey0N29( ) ;
                     Delete0N29( ) ;
                     ScanKeyNext0N29( ) ;
                  }
                  ScanKeyEnd0N29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N18 */
                     pr_default.execute(16, new Object[] {n133ProveedorID, A133ProveedorID});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Proveedor");
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0N28( ) ;
         Gx_mode = sMode28;
      }

      protected void OnDeleteControls0N28( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV40Pgmname = "Proveedor_BC";
            /* Using cursor BC000N19 */
            pr_default.execute(17, new Object[] {A151ProveedoresTipoId});
            A278ProveedoresTipoNombre = BC000N19_A278ProveedoresTipoNombre[0];
            pr_default.close(17);
            /* Using cursor BC000N20 */
            pr_default.execute(18, new Object[] {n488DocumentacionId, A488DocumentacionId});
            A40001DocumentacionIcono_GXI = BC000N20_A40001DocumentacionIcono_GXI[0];
            A498DocumentacionIcono = BC000N20_A498DocumentacionIcono[0];
            pr_default.close(18);
            /* Using cursor BC000N21 */
            pr_default.execute(19, new Object[] {n673BancoId, A673BancoId});
            A674BancoNombre = BC000N21_A674BancoNombre[0];
            pr_default.close(19);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000N22 */
            pr_default.execute(20, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Postulaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor BC000N23 */
            pr_default.execute(21, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Lista Mapeo", "")+" ("+context.GetMessage( "Comercios SubTipo", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor BC000N24 */
            pr_default.execute(22, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Lista Mapeo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor BC000N25 */
            pr_default.execute(23, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Vincular Trn", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor BC000N26 */
            pr_default.execute(24, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor BC000N27 */
            pr_default.execute(25, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")+" ("+context.GetMessage( "Comercios SubTipo", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor BC000N28 */
            pr_default.execute(26, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor BC000N29 */
            pr_default.execute(27, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor BC000N30 */
            pr_default.execute(28, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agrupacion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor BC000N31 */
            pr_default.execute(29, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Proveedor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor BC000N32 */
            pr_default.execute(30, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Comercio | Proveedor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor BC000N33 */
            pr_default.execute(31, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
         }
      }

      protected void ProcessNestedLevel0N29( )
      {
         nGXsfl_29_idx = 0;
         while ( nGXsfl_29_idx < bcProveedor.gxTpr_Comision.Count )
         {
            ReadRow0N29( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound29 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_29 != 0 ) )
            {
               standaloneNotModal0N29( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0N29( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0N29( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0N29( ) ;
                  }
               }
            }
            KeyVarsToRow29( ((SdtProveedor_Comision)bcProveedor.gxTpr_Comision.Item(nGXsfl_29_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_29_idx = 0;
            while ( nGXsfl_29_idx < bcProveedor.gxTpr_Comision.Count )
            {
               ReadRow0N29( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound29 == 0 )
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
                  bcProveedor.gxTpr_Comision.RemoveElement(nGXsfl_29_idx);
                  nGXsfl_29_idx = (int)(nGXsfl_29_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0N29( ) ;
                  VarsToRow29( ((SdtProveedor_Comision)bcProveedor.gxTpr_Comision.Item(nGXsfl_29_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0N29( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_29 = 0;
         nIsMod_29 = 0;
      }

      protected void ProcessLevel0N28( )
      {
         /* Save parent mode. */
         sMode28 = Gx_mode;
         ProcessNestedLevel0N29( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode28;
         /* ' Update level parameters */
      }

      protected void EndLevel0N28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(6);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0N28( ) ;
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

      public void ScanKeyStart0N28( )
      {
         /* Scan By routine */
         /* Using cursor BC000N34 */
         pr_default.execute(32, new Object[] {n133ProveedorID, A133ProveedorID});
         RcdFound28 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound28 = 1;
            A133ProveedorID = BC000N34_A133ProveedorID[0];
            n133ProveedorID = BC000N34_n133ProveedorID[0];
            A546ProveedorUsrAlta = BC000N34_A546ProveedorUsrAlta[0];
            n546ProveedorUsrAlta = BC000N34_n546ProveedorUsrAlta[0];
            A547ProveedorUsrActualizacion = BC000N34_A547ProveedorUsrActualizacion[0];
            n547ProveedorUsrActualizacion = BC000N34_n547ProveedorUsrActualizacion[0];
            A548ProveedorFechaAlta = BC000N34_A548ProveedorFechaAlta[0];
            n548ProveedorFechaAlta = BC000N34_n548ProveedorFechaAlta[0];
            A549ProveedorFechaActualizacion = BC000N34_A549ProveedorFechaActualizacion[0];
            n549ProveedorFechaActualizacion = BC000N34_n549ProveedorFechaActualizacion[0];
            A278ProveedoresTipoNombre = BC000N34_A278ProveedoresTipoNombre[0];
            A282ProveedorNombre = BC000N34_A282ProveedorNombre[0];
            A682ProveedorRazonSocial = BC000N34_A682ProveedorRazonSocial[0];
            n682ProveedorRazonSocial = BC000N34_n682ProveedorRazonSocial[0];
            A683ProveedorContacto = BC000N34_A683ProveedorContacto[0];
            n683ProveedorContacto = BC000N34_n683ProveedorContacto[0];
            A684ProveedorContactoCell = BC000N34_A684ProveedorContactoCell[0];
            n684ProveedorContactoCell = BC000N34_n684ProveedorContactoCell[0];
            A40000ProveedorImagen_GXI = BC000N34_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = BC000N34_n40000ProveedorImagen_GXI[0];
            A338ProveedorDocIdentidad = BC000N34_A338ProveedorDocIdentidad[0];
            A345ProveedorSerialComi = BC000N34_A345ProveedorSerialComi[0];
            A430ProveedorTelefono = BC000N34_A430ProveedorTelefono[0];
            n430ProveedorTelefono = BC000N34_n430ProveedorTelefono[0];
            A431ProveedorDireccion = BC000N34_A431ProveedorDireccion[0];
            n431ProveedorDireccion = BC000N34_n431ProveedorDireccion[0];
            A433ProveedorEmail = BC000N34_A433ProveedorEmail[0];
            n433ProveedorEmail = BC000N34_n433ProveedorEmail[0];
            A685ProveedorSitioWeb = BC000N34_A685ProveedorSitioWeb[0];
            n685ProveedorSitioWeb = BC000N34_n685ProveedorSitioWeb[0];
            A686ProveedorAceptoTerminos = BC000N34_A686ProveedorAceptoTerminos[0];
            n686ProveedorAceptoTerminos = BC000N34_n686ProveedorAceptoTerminos[0];
            A437ProveedorPerAltShop = BC000N34_A437ProveedorPerAltShop[0];
            n437ProveedorPerAltShop = BC000N34_n437ProveedorPerAltShop[0];
            A344ProveedorEstado = BC000N34_A344ProveedorEstado[0];
            A440ProveedorPagoDefault = BC000N34_A440ProveedorPagoDefault[0];
            A490ProveedorPideDoc = BC000N34_A490ProveedorPideDoc[0];
            n490ProveedorPideDoc = BC000N34_n490ProveedorPideDoc[0];
            A40001DocumentacionIcono_GXI = BC000N34_A40001DocumentacionIcono_GXI[0];
            A601ProveedorUsoInterno = BC000N34_A601ProveedorUsoInterno[0];
            n601ProveedorUsoInterno = BC000N34_n601ProveedorUsoInterno[0];
            A687ProveedorCuentaBancaria = BC000N34_A687ProveedorCuentaBancaria[0];
            n687ProveedorCuentaBancaria = BC000N34_n687ProveedorCuentaBancaria[0];
            A674BancoNombre = BC000N34_A674BancoNombre[0];
            A978ProveedorCIU = BC000N34_A978ProveedorCIU[0];
            A999ProveedorFreezePrice = BC000N34_A999ProveedorFreezePrice[0];
            n999ProveedorFreezePrice = BC000N34_n999ProveedorFreezePrice[0];
            A151ProveedoresTipoId = BC000N34_A151ProveedoresTipoId[0];
            A488DocumentacionId = BC000N34_A488DocumentacionId[0];
            n488DocumentacionId = BC000N34_n488DocumentacionId[0];
            A673BancoId = BC000N34_A673BancoId[0];
            n673BancoId = BC000N34_n673BancoId[0];
            A432ProveedorImagen = BC000N34_A432ProveedorImagen[0];
            n432ProveedorImagen = BC000N34_n432ProveedorImagen[0];
            A498DocumentacionIcono = BC000N34_A498DocumentacionIcono[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0N28( )
      {
         /* Scan next routine */
         pr_default.readNext(32);
         RcdFound28 = 0;
         ScanKeyLoad0N28( ) ;
      }

      protected void ScanKeyLoad0N28( )
      {
         sMode28 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound28 = 1;
            A133ProveedorID = BC000N34_A133ProveedorID[0];
            n133ProveedorID = BC000N34_n133ProveedorID[0];
            A546ProveedorUsrAlta = BC000N34_A546ProveedorUsrAlta[0];
            n546ProveedorUsrAlta = BC000N34_n546ProveedorUsrAlta[0];
            A547ProveedorUsrActualizacion = BC000N34_A547ProveedorUsrActualizacion[0];
            n547ProveedorUsrActualizacion = BC000N34_n547ProveedorUsrActualizacion[0];
            A548ProveedorFechaAlta = BC000N34_A548ProveedorFechaAlta[0];
            n548ProveedorFechaAlta = BC000N34_n548ProveedorFechaAlta[0];
            A549ProveedorFechaActualizacion = BC000N34_A549ProveedorFechaActualizacion[0];
            n549ProveedorFechaActualizacion = BC000N34_n549ProveedorFechaActualizacion[0];
            A278ProveedoresTipoNombre = BC000N34_A278ProveedoresTipoNombre[0];
            A282ProveedorNombre = BC000N34_A282ProveedorNombre[0];
            A682ProveedorRazonSocial = BC000N34_A682ProveedorRazonSocial[0];
            n682ProveedorRazonSocial = BC000N34_n682ProveedorRazonSocial[0];
            A683ProveedorContacto = BC000N34_A683ProveedorContacto[0];
            n683ProveedorContacto = BC000N34_n683ProveedorContacto[0];
            A684ProveedorContactoCell = BC000N34_A684ProveedorContactoCell[0];
            n684ProveedorContactoCell = BC000N34_n684ProveedorContactoCell[0];
            A40000ProveedorImagen_GXI = BC000N34_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = BC000N34_n40000ProveedorImagen_GXI[0];
            A338ProveedorDocIdentidad = BC000N34_A338ProveedorDocIdentidad[0];
            A345ProveedorSerialComi = BC000N34_A345ProveedorSerialComi[0];
            A430ProveedorTelefono = BC000N34_A430ProveedorTelefono[0];
            n430ProveedorTelefono = BC000N34_n430ProveedorTelefono[0];
            A431ProveedorDireccion = BC000N34_A431ProveedorDireccion[0];
            n431ProveedorDireccion = BC000N34_n431ProveedorDireccion[0];
            A433ProveedorEmail = BC000N34_A433ProveedorEmail[0];
            n433ProveedorEmail = BC000N34_n433ProveedorEmail[0];
            A685ProveedorSitioWeb = BC000N34_A685ProveedorSitioWeb[0];
            n685ProveedorSitioWeb = BC000N34_n685ProveedorSitioWeb[0];
            A686ProveedorAceptoTerminos = BC000N34_A686ProveedorAceptoTerminos[0];
            n686ProveedorAceptoTerminos = BC000N34_n686ProveedorAceptoTerminos[0];
            A437ProveedorPerAltShop = BC000N34_A437ProveedorPerAltShop[0];
            n437ProveedorPerAltShop = BC000N34_n437ProveedorPerAltShop[0];
            A344ProveedorEstado = BC000N34_A344ProveedorEstado[0];
            A440ProveedorPagoDefault = BC000N34_A440ProveedorPagoDefault[0];
            A490ProveedorPideDoc = BC000N34_A490ProveedorPideDoc[0];
            n490ProveedorPideDoc = BC000N34_n490ProveedorPideDoc[0];
            A40001DocumentacionIcono_GXI = BC000N34_A40001DocumentacionIcono_GXI[0];
            A601ProveedorUsoInterno = BC000N34_A601ProveedorUsoInterno[0];
            n601ProveedorUsoInterno = BC000N34_n601ProveedorUsoInterno[0];
            A687ProveedorCuentaBancaria = BC000N34_A687ProveedorCuentaBancaria[0];
            n687ProveedorCuentaBancaria = BC000N34_n687ProveedorCuentaBancaria[0];
            A674BancoNombre = BC000N34_A674BancoNombre[0];
            A978ProveedorCIU = BC000N34_A978ProveedorCIU[0];
            A999ProveedorFreezePrice = BC000N34_A999ProveedorFreezePrice[0];
            n999ProveedorFreezePrice = BC000N34_n999ProveedorFreezePrice[0];
            A151ProveedoresTipoId = BC000N34_A151ProveedoresTipoId[0];
            A488DocumentacionId = BC000N34_A488DocumentacionId[0];
            n488DocumentacionId = BC000N34_n488DocumentacionId[0];
            A673BancoId = BC000N34_A673BancoId[0];
            n673BancoId = BC000N34_n673BancoId[0];
            A432ProveedorImagen = BC000N34_A432ProveedorImagen[0];
            n432ProveedorImagen = BC000N34_n432ProveedorImagen[0];
            A498DocumentacionIcono = BC000N34_A498DocumentacionIcono[0];
         }
         Gx_mode = sMode28;
      }

      protected void ScanKeyEnd0N28( )
      {
         pr_default.close(32);
      }

      protected void AfterConfirm0N28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N28( )
      {
      }

      protected void ZM0N29( short GX_JID )
      {
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            Z1001ProveedorComisionFP = A1001ProveedorComisionFP;
            Z1000ProveedorComisionFPF = A1000ProveedorComisionFPF;
            Z346ProveedorComisionTipo = A346ProveedorComisionTipo;
            Z347ProveedorComision = A347ProveedorComision;
            Z348ProveedorComisionAccion = A348ProveedorComisionAccion;
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z135InventarioId = A135InventarioId;
         }
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
            Z118MonedaId = A118MonedaId;
         }
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            Z136InventarioNombre = A136InventarioNombre;
            Z181InventarioPrecioFinal = A181InventarioPrecioFinal;
            Z107EstadosTipo = A107EstadosTipo;
            Z108EstadosGenericosId = A108EstadosGenericosId;
         }
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            Z109EstadosGenericosNombre = A109EstadosGenericosNombre;
         }
         if ( GX_JID == -19 )
         {
            Z133ProveedorID = A133ProveedorID;
            Z157ProveedorComisionID = A157ProveedorComisionID;
            Z1001ProveedorComisionFP = A1001ProveedorComisionFP;
            Z1000ProveedorComisionFPF = A1000ProveedorComisionFPF;
            Z346ProveedorComisionTipo = A346ProveedorComisionTipo;
            Z347ProveedorComision = A347ProveedorComision;
            Z348ProveedorComisionAccion = A348ProveedorComisionAccion;
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z135InventarioId = A135InventarioId;
            Z168RubrosImagen = A168RubrosImagen;
            Z40002RubrosImagen_GXI = A40002RubrosImagen_GXI;
            Z118MonedaId = A118MonedaId;
            Z136InventarioNombre = A136InventarioNombre;
            Z181InventarioPrecioFinal = A181InventarioPrecioFinal;
            Z107EstadosTipo = A107EstadosTipo;
            Z108EstadosGenericosId = A108EstadosGenericosId;
            Z109EstadosGenericosNombre = A109EstadosGenericosNombre;
         }
      }

      protected void standaloneNotModal0N29( )
      {
      }

      protected void standaloneModal0N29( )
      {
      }

      protected void Load0N29( )
      {
         /* Using cursor BC000N35 */
         pr_default.execute(33, new Object[] {n133ProveedorID, A133ProveedorID, A157ProveedorComisionID});
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound29 = 1;
            A40002RubrosImagen_GXI = BC000N35_A40002RubrosImagen_GXI[0];
            A136InventarioNombre = BC000N35_A136InventarioNombre[0];
            A109EstadosGenericosNombre = BC000N35_A109EstadosGenericosNombre[0];
            A181InventarioPrecioFinal = BC000N35_A181InventarioPrecioFinal[0];
            A1001ProveedorComisionFP = BC000N35_A1001ProveedorComisionFP[0];
            n1001ProveedorComisionFP = BC000N35_n1001ProveedorComisionFP[0];
            A1000ProveedorComisionFPF = BC000N35_A1000ProveedorComisionFPF[0];
            n1000ProveedorComisionFPF = BC000N35_n1000ProveedorComisionFPF[0];
            A346ProveedorComisionTipo = BC000N35_A346ProveedorComisionTipo[0];
            A347ProveedorComision = BC000N35_A347ProveedorComision[0];
            A348ProveedorComisionAccion = BC000N35_A348ProveedorComisionAccion[0];
            A121RubrosId = BC000N35_A121RubrosId[0];
            A137MedidasID = BC000N35_A137MedidasID[0];
            A135InventarioId = BC000N35_A135InventarioId[0];
            n135InventarioId = BC000N35_n135InventarioId[0];
            A118MonedaId = BC000N35_A118MonedaId[0];
            A107EstadosTipo = BC000N35_A107EstadosTipo[0];
            A108EstadosGenericosId = BC000N35_A108EstadosGenericosId[0];
            A168RubrosImagen = BC000N35_A168RubrosImagen[0];
            ZM0N29( -19) ;
         }
         pr_default.close(33);
         OnLoadActions0N29( ) ;
      }

      protected void OnLoadActions0N29( )
      {
      }

      protected void CheckExtendedTable0N29( )
      {
         Gx_BScreen = 1;
         standaloneModal0N29( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000N4 */
         pr_default.execute(2, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RUBROSID");
            AnyError = 1;
         }
         A40002RubrosImagen_GXI = BC000N4_A40002RubrosImagen_GXI[0];
         A168RubrosImagen = BC000N4_A168RubrosImagen[0];
         pr_default.close(2);
         /* Using cursor BC000N5 */
         pr_default.execute(3, new Object[] {A121RubrosId, A137MedidasID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros Medidas y Precios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDIDASID");
            AnyError = 1;
         }
         A118MonedaId = BC000N5_A118MonedaId[0];
         pr_default.close(3);
         /* Using cursor BC000N6 */
         pr_default.execute(4, new Object[] {A121RubrosId, A137MedidasID, n135InventarioId, A135InventarioId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) || (0==A135InventarioId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "INVENTARIOID");
               AnyError = 1;
            }
         }
         A136InventarioNombre = BC000N6_A136InventarioNombre[0];
         A181InventarioPrecioFinal = BC000N6_A181InventarioPrecioFinal[0];
         A107EstadosTipo = BC000N6_A107EstadosTipo[0];
         A108EstadosGenericosId = BC000N6_A108EstadosGenericosId[0];
         pr_default.close(4);
         /* Using cursor BC000N7 */
         pr_default.execute(5, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A107EstadosTipo)) || (0==A108EstadosGenericosId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSGENERICOSID");
               AnyError = 1;
            }
         }
         A109EstadosGenericosNombre = BC000N7_A109EstadosGenericosNombre[0];
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors0N29( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable0N29( )
      {
      }

      protected void GetKey0N29( )
      {
         /* Using cursor BC000N36 */
         pr_default.execute(34, new Object[] {n133ProveedorID, A133ProveedorID, A157ProveedorComisionID});
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound29 = 1;
         }
         else
         {
            RcdFound29 = 0;
         }
         pr_default.close(34);
      }

      protected void getByPrimaryKey0N29( )
      {
         /* Using cursor BC000N3 */
         pr_default.execute(1, new Object[] {n133ProveedorID, A133ProveedorID, A157ProveedorComisionID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0N29( 19) ;
            RcdFound29 = 1;
            InitializeNonKey0N29( ) ;
            A157ProveedorComisionID = BC000N3_A157ProveedorComisionID[0];
            A1001ProveedorComisionFP = BC000N3_A1001ProveedorComisionFP[0];
            n1001ProveedorComisionFP = BC000N3_n1001ProveedorComisionFP[0];
            A1000ProveedorComisionFPF = BC000N3_A1000ProveedorComisionFPF[0];
            n1000ProveedorComisionFPF = BC000N3_n1000ProveedorComisionFPF[0];
            A346ProveedorComisionTipo = BC000N3_A346ProveedorComisionTipo[0];
            A347ProveedorComision = BC000N3_A347ProveedorComision[0];
            A348ProveedorComisionAccion = BC000N3_A348ProveedorComisionAccion[0];
            A121RubrosId = BC000N3_A121RubrosId[0];
            A137MedidasID = BC000N3_A137MedidasID[0];
            A135InventarioId = BC000N3_A135InventarioId[0];
            n135InventarioId = BC000N3_n135InventarioId[0];
            Z133ProveedorID = A133ProveedorID;
            Z157ProveedorComisionID = A157ProveedorComisionID;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0N29( ) ;
            Load0N29( ) ;
            Gx_mode = sMode29;
         }
         else
         {
            RcdFound29 = 0;
            InitializeNonKey0N29( ) ;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0N29( ) ;
            Gx_mode = sMode29;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0N29( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0N29( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000N2 */
            pr_default.execute(0, new Object[] {n133ProveedorID, A133ProveedorID, A157ProveedorComisionID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProveedorComision"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1001ProveedorComisionFP != BC000N2_A1001ProveedorComisionFP[0] ) || ( Z1000ProveedorComisionFPF != BC000N2_A1000ProveedorComisionFPF[0] ) || ( StringUtil.StrCmp(Z346ProveedorComisionTipo, BC000N2_A346ProveedorComisionTipo[0]) != 0 ) || ( Z347ProveedorComision != BC000N2_A347ProveedorComision[0] ) || ( StringUtil.StrCmp(Z348ProveedorComisionAccion, BC000N2_A348ProveedorComisionAccion[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z121RubrosId != BC000N2_A121RubrosId[0] ) || ( Z137MedidasID != BC000N2_A137MedidasID[0] ) || ( Z135InventarioId != BC000N2_A135InventarioId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProveedorComision"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N29( )
      {
         BeforeValidate0N29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N29( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N29( 0) ;
            CheckOptimisticConcurrency0N29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N37 */
                     pr_default.execute(35, new Object[] {n133ProveedorID, A133ProveedorID, A157ProveedorComisionID, n1001ProveedorComisionFP, A1001ProveedorComisionFP, n1000ProveedorComisionFPF, A1000ProveedorComisionFPF, A346ProveedorComisionTipo, A347ProveedorComision, A348ProveedorComisionAccion, A121RubrosId, A137MedidasID, n135InventarioId, A135InventarioId});
                     pr_default.close(35);
                     pr_default.SmartCacheProvider.SetUpdated("ProveedorComision");
                     if ( (pr_default.getStatus(35) == 1) )
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
               Load0N29( ) ;
            }
            EndLevel0N29( ) ;
         }
         CloseExtendedTableCursors0N29( ) ;
      }

      protected void Update0N29( )
      {
         BeforeValidate0N29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N29( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N38 */
                     pr_default.execute(36, new Object[] {n1001ProveedorComisionFP, A1001ProveedorComisionFP, n1000ProveedorComisionFPF, A1000ProveedorComisionFPF, A346ProveedorComisionTipo, A347ProveedorComision, A348ProveedorComisionAccion, A121RubrosId, A137MedidasID, n135InventarioId, A135InventarioId, n133ProveedorID, A133ProveedorID, A157ProveedorComisionID});
                     pr_default.close(36);
                     pr_default.SmartCacheProvider.SetUpdated("ProveedorComision");
                     if ( (pr_default.getStatus(36) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProveedorComision"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N29( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0N29( ) ;
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
            EndLevel0N29( ) ;
         }
         CloseExtendedTableCursors0N29( ) ;
      }

      protected void DeferredUpdate0N29( )
      {
      }

      protected void Delete0N29( )
      {
         Gx_mode = "DLT";
         BeforeValidate0N29( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N29( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N29( ) ;
            AfterConfirm0N29( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N29( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000N39 */
                  pr_default.execute(37, new Object[] {n133ProveedorID, A133ProveedorID, A157ProveedorComisionID});
                  pr_default.close(37);
                  pr_default.SmartCacheProvider.SetUpdated("ProveedorComision");
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
         sMode29 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0N29( ) ;
         Gx_mode = sMode29;
      }

      protected void OnDeleteControls0N29( )
      {
         standaloneModal0N29( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000N40 */
            pr_default.execute(38, new Object[] {A121RubrosId});
            A40002RubrosImagen_GXI = BC000N40_A40002RubrosImagen_GXI[0];
            A168RubrosImagen = BC000N40_A168RubrosImagen[0];
            pr_default.close(38);
            /* Using cursor BC000N41 */
            pr_default.execute(39, new Object[] {A121RubrosId, A137MedidasID});
            A118MonedaId = BC000N41_A118MonedaId[0];
            pr_default.close(39);
            /* Using cursor BC000N42 */
            pr_default.execute(40, new Object[] {A121RubrosId, A137MedidasID, n135InventarioId, A135InventarioId});
            A136InventarioNombre = BC000N42_A136InventarioNombre[0];
            A181InventarioPrecioFinal = BC000N42_A181InventarioPrecioFinal[0];
            A107EstadosTipo = BC000N42_A107EstadosTipo[0];
            A108EstadosGenericosId = BC000N42_A108EstadosGenericosId[0];
            pr_default.close(40);
            /* Using cursor BC000N43 */
            pr_default.execute(41, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            A109EstadosGenericosNombre = BC000N43_A109EstadosGenericosNombre[0];
            pr_default.close(41);
         }
      }

      protected void EndLevel0N29( )
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

      public void ScanKeyStart0N29( )
      {
         /* Scan By routine */
         /* Using cursor BC000N44 */
         pr_default.execute(42, new Object[] {n133ProveedorID, A133ProveedorID});
         RcdFound29 = 0;
         if ( (pr_default.getStatus(42) != 101) )
         {
            RcdFound29 = 1;
            A157ProveedorComisionID = BC000N44_A157ProveedorComisionID[0];
            A40002RubrosImagen_GXI = BC000N44_A40002RubrosImagen_GXI[0];
            A136InventarioNombre = BC000N44_A136InventarioNombre[0];
            A109EstadosGenericosNombre = BC000N44_A109EstadosGenericosNombre[0];
            A181InventarioPrecioFinal = BC000N44_A181InventarioPrecioFinal[0];
            A1001ProveedorComisionFP = BC000N44_A1001ProveedorComisionFP[0];
            n1001ProveedorComisionFP = BC000N44_n1001ProveedorComisionFP[0];
            A1000ProveedorComisionFPF = BC000N44_A1000ProveedorComisionFPF[0];
            n1000ProveedorComisionFPF = BC000N44_n1000ProveedorComisionFPF[0];
            A346ProveedorComisionTipo = BC000N44_A346ProveedorComisionTipo[0];
            A347ProveedorComision = BC000N44_A347ProveedorComision[0];
            A348ProveedorComisionAccion = BC000N44_A348ProveedorComisionAccion[0];
            A121RubrosId = BC000N44_A121RubrosId[0];
            A137MedidasID = BC000N44_A137MedidasID[0];
            A135InventarioId = BC000N44_A135InventarioId[0];
            n135InventarioId = BC000N44_n135InventarioId[0];
            A118MonedaId = BC000N44_A118MonedaId[0];
            A107EstadosTipo = BC000N44_A107EstadosTipo[0];
            A108EstadosGenericosId = BC000N44_A108EstadosGenericosId[0];
            A168RubrosImagen = BC000N44_A168RubrosImagen[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0N29( )
      {
         /* Scan next routine */
         pr_default.readNext(42);
         RcdFound29 = 0;
         ScanKeyLoad0N29( ) ;
      }

      protected void ScanKeyLoad0N29( )
      {
         sMode29 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(42) != 101) )
         {
            RcdFound29 = 1;
            A157ProveedorComisionID = BC000N44_A157ProveedorComisionID[0];
            A40002RubrosImagen_GXI = BC000N44_A40002RubrosImagen_GXI[0];
            A136InventarioNombre = BC000N44_A136InventarioNombre[0];
            A109EstadosGenericosNombre = BC000N44_A109EstadosGenericosNombre[0];
            A181InventarioPrecioFinal = BC000N44_A181InventarioPrecioFinal[0];
            A1001ProveedorComisionFP = BC000N44_A1001ProveedorComisionFP[0];
            n1001ProveedorComisionFP = BC000N44_n1001ProveedorComisionFP[0];
            A1000ProveedorComisionFPF = BC000N44_A1000ProveedorComisionFPF[0];
            n1000ProveedorComisionFPF = BC000N44_n1000ProveedorComisionFPF[0];
            A346ProveedorComisionTipo = BC000N44_A346ProveedorComisionTipo[0];
            A347ProveedorComision = BC000N44_A347ProveedorComision[0];
            A348ProveedorComisionAccion = BC000N44_A348ProveedorComisionAccion[0];
            A121RubrosId = BC000N44_A121RubrosId[0];
            A137MedidasID = BC000N44_A137MedidasID[0];
            A135InventarioId = BC000N44_A135InventarioId[0];
            n135InventarioId = BC000N44_n135InventarioId[0];
            A118MonedaId = BC000N44_A118MonedaId[0];
            A107EstadosTipo = BC000N44_A107EstadosTipo[0];
            A108EstadosGenericosId = BC000N44_A108EstadosGenericosId[0];
            A168RubrosImagen = BC000N44_A168RubrosImagen[0];
         }
         Gx_mode = sMode29;
      }

      protected void ScanKeyEnd0N29( )
      {
         pr_default.close(42);
      }

      protected void AfterConfirm0N29( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N29( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N29( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N29( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N29( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N29( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N29( )
      {
      }

      protected void send_integrity_lvl_hashes0N29( )
      {
      }

      protected void send_integrity_lvl_hashes0N28( )
      {
      }

      protected void AddRow0N28( )
      {
         VarsToRow28( bcProveedor) ;
      }

      protected void ReadRow0N28( )
      {
         RowToVars28( bcProveedor, 1) ;
      }

      protected void AddRow0N29( )
      {
         SdtProveedor_Comision obj29;
         obj29 = new SdtProveedor_Comision(context);
         VarsToRow29( obj29) ;
         bcProveedor.gxTpr_Comision.Add(obj29, 0);
         obj29.gxTpr_Mode = "UPD";
         obj29.gxTpr_Modified = 0;
      }

      protected void ReadRow0N29( )
      {
         nGXsfl_29_idx = (int)(nGXsfl_29_idx+1);
         RowToVars29( ((SdtProveedor_Comision)bcProveedor.gxTpr_Comision.Item(nGXsfl_29_idx)), 1) ;
      }

      protected void InitializeNonKey0N28( )
      {
         A546ProveedorUsrAlta = 0;
         n546ProveedorUsrAlta = false;
         A547ProveedorUsrActualizacion = 0;
         n547ProveedorUsrActualizacion = false;
         A548ProveedorFechaAlta = (DateTime)(DateTime.MinValue);
         n548ProveedorFechaAlta = false;
         A549ProveedorFechaActualizacion = (DateTime)(DateTime.MinValue);
         n549ProveedorFechaActualizacion = false;
         A151ProveedoresTipoId = 0;
         A278ProveedoresTipoNombre = "";
         A282ProveedorNombre = "";
         A682ProveedorRazonSocial = "";
         n682ProveedorRazonSocial = false;
         A683ProveedorContacto = "";
         n683ProveedorContacto = false;
         A684ProveedorContactoCell = "";
         n684ProveedorContactoCell = false;
         A432ProveedorImagen = "";
         n432ProveedorImagen = false;
         A40000ProveedorImagen_GXI = "";
         n40000ProveedorImagen_GXI = false;
         A338ProveedorDocIdentidad = "";
         A345ProveedorSerialComi = 0;
         A430ProveedorTelefono = "";
         n430ProveedorTelefono = false;
         A431ProveedorDireccion = "";
         n431ProveedorDireccion = false;
         A433ProveedorEmail = "";
         n433ProveedorEmail = false;
         A685ProveedorSitioWeb = "";
         n685ProveedorSitioWeb = false;
         A686ProveedorAceptoTerminos = (DateTime)(DateTime.MinValue);
         n686ProveedorAceptoTerminos = false;
         A437ProveedorPerAltShop = "";
         n437ProveedorPerAltShop = false;
         A344ProveedorEstado = "";
         A440ProveedorPagoDefault = "";
         A490ProveedorPideDoc = "";
         n490ProveedorPideDoc = false;
         A488DocumentacionId = 0;
         n488DocumentacionId = false;
         A498DocumentacionIcono = "";
         A40001DocumentacionIcono_GXI = "";
         A601ProveedorUsoInterno = "";
         n601ProveedorUsoInterno = false;
         A687ProveedorCuentaBancaria = "";
         n687ProveedorCuentaBancaria = false;
         A673BancoId = 0;
         n673BancoId = false;
         A674BancoNombre = "";
         A978ProveedorCIU = false;
         A999ProveedorFreezePrice = false;
         n999ProveedorFreezePrice = false;
         Z546ProveedorUsrAlta = 0;
         Z547ProveedorUsrActualizacion = 0;
         Z548ProveedorFechaAlta = (DateTime)(DateTime.MinValue);
         Z549ProveedorFechaActualizacion = (DateTime)(DateTime.MinValue);
         Z282ProveedorNombre = "";
         Z682ProveedorRazonSocial = "";
         Z683ProveedorContacto = "";
         Z684ProveedorContactoCell = "";
         Z338ProveedorDocIdentidad = "";
         Z345ProveedorSerialComi = 0;
         Z430ProveedorTelefono = "";
         Z431ProveedorDireccion = "";
         Z433ProveedorEmail = "";
         Z685ProveedorSitioWeb = "";
         Z686ProveedorAceptoTerminos = (DateTime)(DateTime.MinValue);
         Z437ProveedorPerAltShop = "";
         Z344ProveedorEstado = "";
         Z440ProveedorPagoDefault = "";
         Z490ProveedorPideDoc = "";
         Z601ProveedorUsoInterno = "";
         Z687ProveedorCuentaBancaria = "";
         Z978ProveedorCIU = false;
         Z999ProveedorFreezePrice = false;
         Z151ProveedoresTipoId = 0;
         Z488DocumentacionId = 0;
         Z673BancoId = 0;
      }

      protected void InitAll0N28( )
      {
         A133ProveedorID = 0;
         n133ProveedorID = false;
         InitializeNonKey0N28( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A978ProveedorCIU = i978ProveedorCIU;
         A999ProveedorFreezePrice = i999ProveedorFreezePrice;
         n999ProveedorFreezePrice = false;
      }

      protected void InitializeNonKey0N29( )
      {
         A121RubrosId = 0;
         A168RubrosImagen = "";
         A40002RubrosImagen_GXI = "";
         A137MedidasID = 0;
         A135InventarioId = 0;
         n135InventarioId = false;
         A136InventarioNombre = "";
         A118MonedaId = 0;
         A107EstadosTipo = "";
         A108EstadosGenericosId = 0;
         A109EstadosGenericosNombre = "";
         A181InventarioPrecioFinal = 0;
         A1001ProveedorComisionFP = false;
         n1001ProveedorComisionFP = false;
         A1000ProveedorComisionFPF = 0;
         n1000ProveedorComisionFPF = false;
         A346ProveedorComisionTipo = "";
         A347ProveedorComision = 0;
         A348ProveedorComisionAccion = "";
         Z1001ProveedorComisionFP = false;
         Z1000ProveedorComisionFPF = 0;
         Z346ProveedorComisionTipo = "";
         Z347ProveedorComision = 0;
         Z348ProveedorComisionAccion = "";
         Z121RubrosId = 0;
         Z137MedidasID = 0;
         Z135InventarioId = 0;
      }

      protected void InitAll0N29( )
      {
         A157ProveedorComisionID = 0;
         InitializeNonKey0N29( ) ;
      }

      protected void StandaloneModalInsert0N29( )
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

      public void VarsToRow28( SdtProveedor obj28 )
      {
         obj28.gxTpr_Mode = Gx_mode;
         obj28.gxTpr_Proveedorusralta = A546ProveedorUsrAlta;
         obj28.gxTpr_Proveedorusractualizacion = A547ProveedorUsrActualizacion;
         obj28.gxTpr_Proveedorfechaalta = A548ProveedorFechaAlta;
         obj28.gxTpr_Proveedorfechaactualizacion = A549ProveedorFechaActualizacion;
         obj28.gxTpr_Proveedorestipoid = A151ProveedoresTipoId;
         obj28.gxTpr_Proveedorestiponombre = A278ProveedoresTipoNombre;
         obj28.gxTpr_Proveedornombre = A282ProveedorNombre;
         obj28.gxTpr_Proveedorrazonsocial = A682ProveedorRazonSocial;
         obj28.gxTpr_Proveedorcontacto = A683ProveedorContacto;
         obj28.gxTpr_Proveedorcontactocell = A684ProveedorContactoCell;
         obj28.gxTpr_Proveedorimagen = A432ProveedorImagen;
         obj28.gxTpr_Proveedorimagen_gxi = A40000ProveedorImagen_GXI;
         obj28.gxTpr_Proveedordocidentidad = A338ProveedorDocIdentidad;
         obj28.gxTpr_Proveedorserialcomi = A345ProveedorSerialComi;
         obj28.gxTpr_Proveedortelefono = A430ProveedorTelefono;
         obj28.gxTpr_Proveedordireccion = A431ProveedorDireccion;
         obj28.gxTpr_Proveedoremail = A433ProveedorEmail;
         obj28.gxTpr_Proveedorsitioweb = A685ProveedorSitioWeb;
         obj28.gxTpr_Proveedoraceptoterminos = A686ProveedorAceptoTerminos;
         obj28.gxTpr_Proveedorperaltshop = A437ProveedorPerAltShop;
         obj28.gxTpr_Proveedorestado = A344ProveedorEstado;
         obj28.gxTpr_Proveedorpagodefault = A440ProveedorPagoDefault;
         obj28.gxTpr_Proveedorpidedoc = A490ProveedorPideDoc;
         obj28.gxTpr_Documentacionid = A488DocumentacionId;
         obj28.gxTpr_Documentacionicono = A498DocumentacionIcono;
         obj28.gxTpr_Documentacionicono_gxi = A40001DocumentacionIcono_GXI;
         obj28.gxTpr_Proveedorusointerno = A601ProveedorUsoInterno;
         obj28.gxTpr_Proveedorcuentabancaria = A687ProveedorCuentaBancaria;
         obj28.gxTpr_Bancoid = A673BancoId;
         obj28.gxTpr_Banconombre = A674BancoNombre;
         obj28.gxTpr_Proveedorciu = A978ProveedorCIU;
         obj28.gxTpr_Proveedorfreezeprice = A999ProveedorFreezePrice;
         obj28.gxTpr_Proveedorid = A133ProveedorID;
         obj28.gxTpr_Proveedorid_Z = Z133ProveedorID;
         obj28.gxTpr_Proveedorestipoid_Z = Z151ProveedoresTipoId;
         obj28.gxTpr_Proveedorestiponombre_Z = Z278ProveedoresTipoNombre;
         obj28.gxTpr_Proveedornombre_Z = Z282ProveedorNombre;
         obj28.gxTpr_Proveedorrazonsocial_Z = Z682ProveedorRazonSocial;
         obj28.gxTpr_Proveedorcontacto_Z = Z683ProveedorContacto;
         obj28.gxTpr_Proveedorcontactocell_Z = Z684ProveedorContactoCell;
         obj28.gxTpr_Proveedordocidentidad_Z = Z338ProveedorDocIdentidad;
         obj28.gxTpr_Proveedorserialcomi_Z = Z345ProveedorSerialComi;
         obj28.gxTpr_Proveedortelefono_Z = Z430ProveedorTelefono;
         obj28.gxTpr_Proveedordireccion_Z = Z431ProveedorDireccion;
         obj28.gxTpr_Proveedoremail_Z = Z433ProveedorEmail;
         obj28.gxTpr_Proveedorsitioweb_Z = Z685ProveedorSitioWeb;
         obj28.gxTpr_Proveedoraceptoterminos_Z = Z686ProveedorAceptoTerminos;
         obj28.gxTpr_Proveedorperaltshop_Z = Z437ProveedorPerAltShop;
         obj28.gxTpr_Proveedorestado_Z = Z344ProveedorEstado;
         obj28.gxTpr_Proveedorpagodefault_Z = Z440ProveedorPagoDefault;
         obj28.gxTpr_Proveedorpidedoc_Z = Z490ProveedorPideDoc;
         obj28.gxTpr_Documentacionid_Z = Z488DocumentacionId;
         obj28.gxTpr_Proveedorusralta_Z = Z546ProveedorUsrAlta;
         obj28.gxTpr_Proveedorusractualizacion_Z = Z547ProveedorUsrActualizacion;
         obj28.gxTpr_Proveedorfechaalta_Z = Z548ProveedorFechaAlta;
         obj28.gxTpr_Proveedorfechaactualizacion_Z = Z549ProveedorFechaActualizacion;
         obj28.gxTpr_Proveedorusointerno_Z = Z601ProveedorUsoInterno;
         obj28.gxTpr_Proveedorcuentabancaria_Z = Z687ProveedorCuentaBancaria;
         obj28.gxTpr_Bancoid_Z = Z673BancoId;
         obj28.gxTpr_Banconombre_Z = Z674BancoNombre;
         obj28.gxTpr_Proveedorciu_Z = Z978ProveedorCIU;
         obj28.gxTpr_Proveedorfreezeprice_Z = Z999ProveedorFreezePrice;
         obj28.gxTpr_Proveedorimagen_gxi_Z = Z40000ProveedorImagen_GXI;
         obj28.gxTpr_Documentacionicono_gxi_Z = Z40001DocumentacionIcono_GXI;
         obj28.gxTpr_Proveedorid_N = (short)(Convert.ToInt16(n133ProveedorID));
         obj28.gxTpr_Proveedorrazonsocial_N = (short)(Convert.ToInt16(n682ProveedorRazonSocial));
         obj28.gxTpr_Proveedorcontacto_N = (short)(Convert.ToInt16(n683ProveedorContacto));
         obj28.gxTpr_Proveedorcontactocell_N = (short)(Convert.ToInt16(n684ProveedorContactoCell));
         obj28.gxTpr_Proveedorimagen_N = (short)(Convert.ToInt16(n432ProveedorImagen));
         obj28.gxTpr_Proveedortelefono_N = (short)(Convert.ToInt16(n430ProveedorTelefono));
         obj28.gxTpr_Proveedordireccion_N = (short)(Convert.ToInt16(n431ProveedorDireccion));
         obj28.gxTpr_Proveedoremail_N = (short)(Convert.ToInt16(n433ProveedorEmail));
         obj28.gxTpr_Proveedorsitioweb_N = (short)(Convert.ToInt16(n685ProveedorSitioWeb));
         obj28.gxTpr_Proveedoraceptoterminos_N = (short)(Convert.ToInt16(n686ProveedorAceptoTerminos));
         obj28.gxTpr_Proveedorperaltshop_N = (short)(Convert.ToInt16(n437ProveedorPerAltShop));
         obj28.gxTpr_Proveedorpidedoc_N = (short)(Convert.ToInt16(n490ProveedorPideDoc));
         obj28.gxTpr_Documentacionid_N = (short)(Convert.ToInt16(n488DocumentacionId));
         obj28.gxTpr_Proveedorusralta_N = (short)(Convert.ToInt16(n546ProveedorUsrAlta));
         obj28.gxTpr_Proveedorusractualizacion_N = (short)(Convert.ToInt16(n547ProveedorUsrActualizacion));
         obj28.gxTpr_Proveedorfechaalta_N = (short)(Convert.ToInt16(n548ProveedorFechaAlta));
         obj28.gxTpr_Proveedorfechaactualizacion_N = (short)(Convert.ToInt16(n549ProveedorFechaActualizacion));
         obj28.gxTpr_Proveedorusointerno_N = (short)(Convert.ToInt16(n601ProveedorUsoInterno));
         obj28.gxTpr_Proveedorcuentabancaria_N = (short)(Convert.ToInt16(n687ProveedorCuentaBancaria));
         obj28.gxTpr_Bancoid_N = (short)(Convert.ToInt16(n673BancoId));
         obj28.gxTpr_Proveedorfreezeprice_N = (short)(Convert.ToInt16(n999ProveedorFreezePrice));
         obj28.gxTpr_Proveedorimagen_gxi_N = (short)(Convert.ToInt16(n40000ProveedorImagen_GXI));
         obj28.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow28( SdtProveedor obj28 )
      {
         obj28.gxTpr_Proveedorid = A133ProveedorID;
         return  ;
      }

      public void RowToVars28( SdtProveedor obj28 ,
                               int forceLoad )
      {
         Gx_mode = obj28.gxTpr_Mode;
         A546ProveedorUsrAlta = obj28.gxTpr_Proveedorusralta;
         n546ProveedorUsrAlta = false;
         A547ProveedorUsrActualizacion = obj28.gxTpr_Proveedorusractualizacion;
         n547ProveedorUsrActualizacion = false;
         A548ProveedorFechaAlta = obj28.gxTpr_Proveedorfechaalta;
         n548ProveedorFechaAlta = false;
         A549ProveedorFechaActualizacion = obj28.gxTpr_Proveedorfechaactualizacion;
         n549ProveedorFechaActualizacion = false;
         A151ProveedoresTipoId = obj28.gxTpr_Proveedorestipoid;
         A278ProveedoresTipoNombre = obj28.gxTpr_Proveedorestiponombre;
         A282ProveedorNombre = obj28.gxTpr_Proveedornombre;
         A682ProveedorRazonSocial = obj28.gxTpr_Proveedorrazonsocial;
         n682ProveedorRazonSocial = false;
         A683ProveedorContacto = obj28.gxTpr_Proveedorcontacto;
         n683ProveedorContacto = false;
         A684ProveedorContactoCell = obj28.gxTpr_Proveedorcontactocell;
         n684ProveedorContactoCell = false;
         A432ProveedorImagen = obj28.gxTpr_Proveedorimagen;
         n432ProveedorImagen = false;
         A40000ProveedorImagen_GXI = obj28.gxTpr_Proveedorimagen_gxi;
         n40000ProveedorImagen_GXI = false;
         A338ProveedorDocIdentidad = obj28.gxTpr_Proveedordocidentidad;
         A345ProveedorSerialComi = obj28.gxTpr_Proveedorserialcomi;
         A430ProveedorTelefono = obj28.gxTpr_Proveedortelefono;
         n430ProveedorTelefono = false;
         A431ProveedorDireccion = obj28.gxTpr_Proveedordireccion;
         n431ProveedorDireccion = false;
         A433ProveedorEmail = obj28.gxTpr_Proveedoremail;
         n433ProveedorEmail = false;
         A685ProveedorSitioWeb = obj28.gxTpr_Proveedorsitioweb;
         n685ProveedorSitioWeb = false;
         A686ProveedorAceptoTerminos = obj28.gxTpr_Proveedoraceptoterminos;
         n686ProveedorAceptoTerminos = false;
         A437ProveedorPerAltShop = obj28.gxTpr_Proveedorperaltshop;
         n437ProveedorPerAltShop = false;
         A344ProveedorEstado = obj28.gxTpr_Proveedorestado;
         A440ProveedorPagoDefault = obj28.gxTpr_Proveedorpagodefault;
         A490ProveedorPideDoc = obj28.gxTpr_Proveedorpidedoc;
         n490ProveedorPideDoc = false;
         A488DocumentacionId = obj28.gxTpr_Documentacionid;
         n488DocumentacionId = false;
         A498DocumentacionIcono = obj28.gxTpr_Documentacionicono;
         A40001DocumentacionIcono_GXI = obj28.gxTpr_Documentacionicono_gxi;
         A601ProveedorUsoInterno = obj28.gxTpr_Proveedorusointerno;
         n601ProveedorUsoInterno = false;
         A687ProveedorCuentaBancaria = obj28.gxTpr_Proveedorcuentabancaria;
         n687ProveedorCuentaBancaria = false;
         A673BancoId = obj28.gxTpr_Bancoid;
         n673BancoId = false;
         A674BancoNombre = obj28.gxTpr_Banconombre;
         A978ProveedorCIU = obj28.gxTpr_Proveedorciu;
         A999ProveedorFreezePrice = obj28.gxTpr_Proveedorfreezeprice;
         n999ProveedorFreezePrice = false;
         A133ProveedorID = obj28.gxTpr_Proveedorid;
         n133ProveedorID = false;
         Z133ProveedorID = obj28.gxTpr_Proveedorid_Z;
         Z151ProveedoresTipoId = obj28.gxTpr_Proveedorestipoid_Z;
         Z278ProveedoresTipoNombre = obj28.gxTpr_Proveedorestiponombre_Z;
         Z282ProveedorNombre = obj28.gxTpr_Proveedornombre_Z;
         Z682ProveedorRazonSocial = obj28.gxTpr_Proveedorrazonsocial_Z;
         Z683ProveedorContacto = obj28.gxTpr_Proveedorcontacto_Z;
         Z684ProveedorContactoCell = obj28.gxTpr_Proveedorcontactocell_Z;
         Z338ProveedorDocIdentidad = obj28.gxTpr_Proveedordocidentidad_Z;
         Z345ProveedorSerialComi = obj28.gxTpr_Proveedorserialcomi_Z;
         Z430ProveedorTelefono = obj28.gxTpr_Proveedortelefono_Z;
         Z431ProveedorDireccion = obj28.gxTpr_Proveedordireccion_Z;
         Z433ProveedorEmail = obj28.gxTpr_Proveedoremail_Z;
         Z685ProveedorSitioWeb = obj28.gxTpr_Proveedorsitioweb_Z;
         Z686ProveedorAceptoTerminos = obj28.gxTpr_Proveedoraceptoterminos_Z;
         Z437ProveedorPerAltShop = obj28.gxTpr_Proveedorperaltshop_Z;
         Z344ProveedorEstado = obj28.gxTpr_Proveedorestado_Z;
         Z440ProveedorPagoDefault = obj28.gxTpr_Proveedorpagodefault_Z;
         Z490ProveedorPideDoc = obj28.gxTpr_Proveedorpidedoc_Z;
         Z488DocumentacionId = obj28.gxTpr_Documentacionid_Z;
         Z546ProveedorUsrAlta = obj28.gxTpr_Proveedorusralta_Z;
         Z547ProveedorUsrActualizacion = obj28.gxTpr_Proveedorusractualizacion_Z;
         Z548ProveedorFechaAlta = obj28.gxTpr_Proveedorfechaalta_Z;
         Z549ProveedorFechaActualizacion = obj28.gxTpr_Proveedorfechaactualizacion_Z;
         Z601ProveedorUsoInterno = obj28.gxTpr_Proveedorusointerno_Z;
         Z687ProveedorCuentaBancaria = obj28.gxTpr_Proveedorcuentabancaria_Z;
         Z673BancoId = obj28.gxTpr_Bancoid_Z;
         Z674BancoNombre = obj28.gxTpr_Banconombre_Z;
         Z978ProveedorCIU = obj28.gxTpr_Proveedorciu_Z;
         Z999ProveedorFreezePrice = obj28.gxTpr_Proveedorfreezeprice_Z;
         Z40000ProveedorImagen_GXI = obj28.gxTpr_Proveedorimagen_gxi_Z;
         Z40001DocumentacionIcono_GXI = obj28.gxTpr_Documentacionicono_gxi_Z;
         n133ProveedorID = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorid_N));
         n682ProveedorRazonSocial = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorrazonsocial_N));
         n683ProveedorContacto = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorcontacto_N));
         n684ProveedorContactoCell = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorcontactocell_N));
         n432ProveedorImagen = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorimagen_N));
         n430ProveedorTelefono = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedortelefono_N));
         n431ProveedorDireccion = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedordireccion_N));
         n433ProveedorEmail = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedoremail_N));
         n685ProveedorSitioWeb = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorsitioweb_N));
         n686ProveedorAceptoTerminos = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedoraceptoterminos_N));
         n437ProveedorPerAltShop = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorperaltshop_N));
         n490ProveedorPideDoc = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorpidedoc_N));
         n488DocumentacionId = (bool)(Convert.ToBoolean(obj28.gxTpr_Documentacionid_N));
         n546ProveedorUsrAlta = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorusralta_N));
         n547ProveedorUsrActualizacion = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorusractualizacion_N));
         n548ProveedorFechaAlta = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorfechaalta_N));
         n549ProveedorFechaActualizacion = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorfechaactualizacion_N));
         n601ProveedorUsoInterno = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorusointerno_N));
         n687ProveedorCuentaBancaria = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorcuentabancaria_N));
         n673BancoId = (bool)(Convert.ToBoolean(obj28.gxTpr_Bancoid_N));
         n999ProveedorFreezePrice = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorfreezeprice_N));
         n40000ProveedorImagen_GXI = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorimagen_gxi_N));
         Gx_mode = obj28.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow29( SdtProveedor_Comision obj29 )
      {
         obj29.gxTpr_Mode = Gx_mode;
         obj29.gxTpr_Rubrosid = A121RubrosId;
         obj29.gxTpr_Rubrosimagen = A168RubrosImagen;
         obj29.gxTpr_Rubrosimagen_gxi = A40002RubrosImagen_GXI;
         obj29.gxTpr_Medidasid = A137MedidasID;
         obj29.gxTpr_Inventarioid = A135InventarioId;
         obj29.gxTpr_Inventarionombre = A136InventarioNombre;
         obj29.gxTpr_Monedaid = A118MonedaId;
         obj29.gxTpr_Estadostipo = A107EstadosTipo;
         obj29.gxTpr_Estadosgenericosid = A108EstadosGenericosId;
         obj29.gxTpr_Estadosgenericosnombre = A109EstadosGenericosNombre;
         obj29.gxTpr_Inventariopreciofinal = A181InventarioPrecioFinal;
         obj29.gxTpr_Proveedorcomisionfp = A1001ProveedorComisionFP;
         obj29.gxTpr_Proveedorcomisionfpf = A1000ProveedorComisionFPF;
         obj29.gxTpr_Proveedorcomisiontipo = A346ProveedorComisionTipo;
         obj29.gxTpr_Proveedorcomision = A347ProveedorComision;
         obj29.gxTpr_Proveedorcomisionaccion = A348ProveedorComisionAccion;
         obj29.gxTpr_Proveedorcomisionid = A157ProveedorComisionID;
         obj29.gxTpr_Proveedorcomisionid_Z = Z157ProveedorComisionID;
         obj29.gxTpr_Rubrosid_Z = Z121RubrosId;
         obj29.gxTpr_Medidasid_Z = Z137MedidasID;
         obj29.gxTpr_Inventarioid_Z = Z135InventarioId;
         obj29.gxTpr_Inventarionombre_Z = Z136InventarioNombre;
         obj29.gxTpr_Monedaid_Z = Z118MonedaId;
         obj29.gxTpr_Estadostipo_Z = Z107EstadosTipo;
         obj29.gxTpr_Estadosgenericosid_Z = Z108EstadosGenericosId;
         obj29.gxTpr_Estadosgenericosnombre_Z = Z109EstadosGenericosNombre;
         obj29.gxTpr_Inventariopreciofinal_Z = Z181InventarioPrecioFinal;
         obj29.gxTpr_Proveedorcomisionfp_Z = Z1001ProveedorComisionFP;
         obj29.gxTpr_Proveedorcomisionfpf_Z = Z1000ProveedorComisionFPF;
         obj29.gxTpr_Proveedorcomisiontipo_Z = Z346ProveedorComisionTipo;
         obj29.gxTpr_Proveedorcomision_Z = Z347ProveedorComision;
         obj29.gxTpr_Proveedorcomisionaccion_Z = Z348ProveedorComisionAccion;
         obj29.gxTpr_Rubrosimagen_gxi_Z = Z40002RubrosImagen_GXI;
         obj29.gxTpr_Inventarioid_N = (short)(Convert.ToInt16(n135InventarioId));
         obj29.gxTpr_Proveedorcomisionfp_N = (short)(Convert.ToInt16(n1001ProveedorComisionFP));
         obj29.gxTpr_Proveedorcomisionfpf_N = (short)(Convert.ToInt16(n1000ProveedorComisionFPF));
         obj29.gxTpr_Modified = nIsMod_29;
         return  ;
      }

      public void KeyVarsToRow29( SdtProveedor_Comision obj29 )
      {
         obj29.gxTpr_Proveedorcomisionid = A157ProveedorComisionID;
         return  ;
      }

      public void RowToVars29( SdtProveedor_Comision obj29 ,
                               int forceLoad )
      {
         Gx_mode = obj29.gxTpr_Mode;
         A121RubrosId = obj29.gxTpr_Rubrosid;
         A168RubrosImagen = obj29.gxTpr_Rubrosimagen;
         A40002RubrosImagen_GXI = obj29.gxTpr_Rubrosimagen_gxi;
         A137MedidasID = obj29.gxTpr_Medidasid;
         A135InventarioId = obj29.gxTpr_Inventarioid;
         n135InventarioId = false;
         A136InventarioNombre = obj29.gxTpr_Inventarionombre;
         A118MonedaId = obj29.gxTpr_Monedaid;
         A107EstadosTipo = obj29.gxTpr_Estadostipo;
         A108EstadosGenericosId = obj29.gxTpr_Estadosgenericosid;
         A109EstadosGenericosNombre = obj29.gxTpr_Estadosgenericosnombre;
         A181InventarioPrecioFinal = obj29.gxTpr_Inventariopreciofinal;
         A1001ProveedorComisionFP = obj29.gxTpr_Proveedorcomisionfp;
         n1001ProveedorComisionFP = false;
         A1000ProveedorComisionFPF = obj29.gxTpr_Proveedorcomisionfpf;
         n1000ProveedorComisionFPF = false;
         A346ProveedorComisionTipo = obj29.gxTpr_Proveedorcomisiontipo;
         A347ProveedorComision = obj29.gxTpr_Proveedorcomision;
         A348ProveedorComisionAccion = obj29.gxTpr_Proveedorcomisionaccion;
         A157ProveedorComisionID = obj29.gxTpr_Proveedorcomisionid;
         Z157ProveedorComisionID = obj29.gxTpr_Proveedorcomisionid_Z;
         Z121RubrosId = obj29.gxTpr_Rubrosid_Z;
         Z137MedidasID = obj29.gxTpr_Medidasid_Z;
         Z135InventarioId = obj29.gxTpr_Inventarioid_Z;
         Z136InventarioNombre = obj29.gxTpr_Inventarionombre_Z;
         Z118MonedaId = obj29.gxTpr_Monedaid_Z;
         Z107EstadosTipo = obj29.gxTpr_Estadostipo_Z;
         Z108EstadosGenericosId = obj29.gxTpr_Estadosgenericosid_Z;
         Z109EstadosGenericosNombre = obj29.gxTpr_Estadosgenericosnombre_Z;
         Z181InventarioPrecioFinal = obj29.gxTpr_Inventariopreciofinal_Z;
         Z1001ProveedorComisionFP = obj29.gxTpr_Proveedorcomisionfp_Z;
         Z1000ProveedorComisionFPF = obj29.gxTpr_Proveedorcomisionfpf_Z;
         Z346ProveedorComisionTipo = obj29.gxTpr_Proveedorcomisiontipo_Z;
         Z347ProveedorComision = obj29.gxTpr_Proveedorcomision_Z;
         Z348ProveedorComisionAccion = obj29.gxTpr_Proveedorcomisionaccion_Z;
         Z40002RubrosImagen_GXI = obj29.gxTpr_Rubrosimagen_gxi_Z;
         n135InventarioId = (bool)(Convert.ToBoolean(obj29.gxTpr_Inventarioid_N));
         n1001ProveedorComisionFP = (bool)(Convert.ToBoolean(obj29.gxTpr_Proveedorcomisionfp_N));
         n1000ProveedorComisionFPF = (bool)(Convert.ToBoolean(obj29.gxTpr_Proveedorcomisionfpf_N));
         nIsMod_29 = obj29.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A133ProveedorID = (long)getParm(obj,0);
         n133ProveedorID = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0N28( ) ;
         ScanKeyStart0N28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z133ProveedorID = A133ProveedorID;
         }
         ZM0N28( -15) ;
         OnLoadActions0N28( ) ;
         AddRow0N28( ) ;
         bcProveedor.gxTpr_Comision.ClearCollection();
         if ( RcdFound28 == 1 )
         {
            ScanKeyStart0N29( ) ;
            nGXsfl_29_idx = 1;
            while ( RcdFound29 != 0 )
            {
               Z133ProveedorID = A133ProveedorID;
               Z157ProveedorComisionID = A157ProveedorComisionID;
               ZM0N29( -19) ;
               OnLoadActions0N29( ) ;
               nRcdExists_29 = 1;
               nIsMod_29 = 0;
               AddRow0N29( ) ;
               nGXsfl_29_idx = (int)(nGXsfl_29_idx+1);
               ScanKeyNext0N29( ) ;
            }
            ScanKeyEnd0N29( ) ;
         }
         ScanKeyEnd0N28( ) ;
         if ( RcdFound28 == 0 )
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
         RowToVars28( bcProveedor, 0) ;
         ScanKeyStart0N28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z133ProveedorID = A133ProveedorID;
         }
         ZM0N28( -15) ;
         OnLoadActions0N28( ) ;
         AddRow0N28( ) ;
         bcProveedor.gxTpr_Comision.ClearCollection();
         if ( RcdFound28 == 1 )
         {
            ScanKeyStart0N29( ) ;
            nGXsfl_29_idx = 1;
            while ( RcdFound29 != 0 )
            {
               Z133ProveedorID = A133ProveedorID;
               Z157ProveedorComisionID = A157ProveedorComisionID;
               ZM0N29( -19) ;
               OnLoadActions0N29( ) ;
               nRcdExists_29 = 1;
               nIsMod_29 = 0;
               AddRow0N29( ) ;
               nGXsfl_29_idx = (int)(nGXsfl_29_idx+1);
               ScanKeyNext0N29( ) ;
            }
            ScanKeyEnd0N29( ) ;
         }
         ScanKeyEnd0N28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0N28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0N28( ) ;
         }
         else
         {
            if ( RcdFound28 == 1 )
            {
               if ( A133ProveedorID != Z133ProveedorID )
               {
                  A133ProveedorID = Z133ProveedorID;
                  n133ProveedorID = false;
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
                  Update0N28( ) ;
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
                  if ( A133ProveedorID != Z133ProveedorID )
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
                        Insert0N28( ) ;
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
                        Insert0N28( ) ;
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
         RowToVars28( bcProveedor, 1) ;
         SaveImpl( ) ;
         VarsToRow28( bcProveedor) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars28( bcProveedor, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0N28( ) ;
         AfterTrn( ) ;
         VarsToRow28( bcProveedor) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow28( bcProveedor) ;
         }
         else
         {
            SdtProveedor auxBC = new SdtProveedor(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A133ProveedorID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcProveedor);
               auxBC.Save();
               bcProveedor.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars28( bcProveedor, 1) ;
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
         RowToVars28( bcProveedor, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0N28( ) ;
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
               VarsToRow28( bcProveedor) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow28( bcProveedor) ;
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
         RowToVars28( bcProveedor, 0) ;
         GetKey0N28( ) ;
         if ( RcdFound28 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A133ProveedorID != Z133ProveedorID )
            {
               A133ProveedorID = Z133ProveedorID;
               n133ProveedorID = false;
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
            if ( A133ProveedorID != Z133ProveedorID )
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
         pr_default.close(7);
         pr_default.close(1);
         pr_default.close(17);
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(38);
         pr_default.close(39);
         pr_default.close(40);
         pr_default.close(41);
         context.RollbackDataStores("proveedor_bc",pr_default);
         VarsToRow28( bcProveedor) ;
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
         Gx_mode = bcProveedor.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcProveedor.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcProveedor )
         {
            bcProveedor = (SdtProveedor)(sdt);
            if ( StringUtil.StrCmp(bcProveedor.gxTpr_Mode, "") == 0 )
            {
               bcProveedor.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow28( bcProveedor) ;
            }
            else
            {
               RowToVars28( bcProveedor, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcProveedor.gxTpr_Mode, "") == 0 )
            {
               bcProveedor.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars28( bcProveedor, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtProveedor Proveedor_BC
      {
         get {
            return bcProveedor ;
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
         pr_default.close(39);
         pr_default.close(40);
         pr_default.close(38);
         pr_default.close(41);
         pr_default.close(7);
         pr_default.close(17);
         pr_default.close(18);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode28 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV31Roles = new SdtSDTRoles(context);
         AV32RolesItem = new SdtSDTRoles_Id(context);
         AV34SecRoleName = "";
         AV33AgrProveedorEstado = "";
         Z548ProveedorFechaAlta = (DateTime)(DateTime.MinValue);
         A548ProveedorFechaAlta = (DateTime)(DateTime.MinValue);
         Z549ProveedorFechaActualizacion = (DateTime)(DateTime.MinValue);
         A549ProveedorFechaActualizacion = (DateTime)(DateTime.MinValue);
         Z282ProveedorNombre = "";
         A282ProveedorNombre = "";
         Z682ProveedorRazonSocial = "";
         A682ProveedorRazonSocial = "";
         Z683ProveedorContacto = "";
         A683ProveedorContacto = "";
         Z684ProveedorContactoCell = "";
         A684ProveedorContactoCell = "";
         Z338ProveedorDocIdentidad = "";
         A338ProveedorDocIdentidad = "";
         Z430ProveedorTelefono = "";
         A430ProveedorTelefono = "";
         Z431ProveedorDireccion = "";
         A431ProveedorDireccion = "";
         Z433ProveedorEmail = "";
         A433ProveedorEmail = "";
         Z685ProveedorSitioWeb = "";
         A685ProveedorSitioWeb = "";
         Z686ProveedorAceptoTerminos = (DateTime)(DateTime.MinValue);
         A686ProveedorAceptoTerminos = (DateTime)(DateTime.MinValue);
         Z437ProveedorPerAltShop = "";
         A437ProveedorPerAltShop = "";
         Z344ProveedorEstado = "";
         A344ProveedorEstado = "";
         Z440ProveedorPagoDefault = "";
         A440ProveedorPagoDefault = "";
         Z490ProveedorPideDoc = "";
         A490ProveedorPideDoc = "";
         Z601ProveedorUsoInterno = "";
         A601ProveedorUsoInterno = "";
         Z687ProveedorCuentaBancaria = "";
         A687ProveedorCuentaBancaria = "";
         Z278ProveedoresTipoNombre = "";
         A278ProveedoresTipoNombre = "";
         Z674BancoNombre = "";
         A674BancoNombre = "";
         Z432ProveedorImagen = "";
         A432ProveedorImagen = "";
         Z40000ProveedorImagen_GXI = "";
         A40000ProveedorImagen_GXI = "";
         Z498DocumentacionIcono = "";
         A498DocumentacionIcono = "";
         Z40001DocumentacionIcono_GXI = "";
         A40001DocumentacionIcono_GXI = "";
         BC000N13_A133ProveedorID = new long[1] ;
         BC000N13_n133ProveedorID = new bool[] {false} ;
         BC000N13_A546ProveedorUsrAlta = new long[1] ;
         BC000N13_n546ProveedorUsrAlta = new bool[] {false} ;
         BC000N13_A547ProveedorUsrActualizacion = new long[1] ;
         BC000N13_n547ProveedorUsrActualizacion = new bool[] {false} ;
         BC000N13_A548ProveedorFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC000N13_n548ProveedorFechaAlta = new bool[] {false} ;
         BC000N13_A549ProveedorFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         BC000N13_n549ProveedorFechaActualizacion = new bool[] {false} ;
         BC000N13_A278ProveedoresTipoNombre = new string[] {""} ;
         BC000N13_A282ProveedorNombre = new string[] {""} ;
         BC000N13_A682ProveedorRazonSocial = new string[] {""} ;
         BC000N13_n682ProveedorRazonSocial = new bool[] {false} ;
         BC000N13_A683ProveedorContacto = new string[] {""} ;
         BC000N13_n683ProveedorContacto = new bool[] {false} ;
         BC000N13_A684ProveedorContactoCell = new string[] {""} ;
         BC000N13_n684ProveedorContactoCell = new bool[] {false} ;
         BC000N13_A40000ProveedorImagen_GXI = new string[] {""} ;
         BC000N13_n40000ProveedorImagen_GXI = new bool[] {false} ;
         BC000N13_A338ProveedorDocIdentidad = new string[] {""} ;
         BC000N13_A345ProveedorSerialComi = new short[1] ;
         BC000N13_A430ProveedorTelefono = new string[] {""} ;
         BC000N13_n430ProveedorTelefono = new bool[] {false} ;
         BC000N13_A431ProveedorDireccion = new string[] {""} ;
         BC000N13_n431ProveedorDireccion = new bool[] {false} ;
         BC000N13_A433ProveedorEmail = new string[] {""} ;
         BC000N13_n433ProveedorEmail = new bool[] {false} ;
         BC000N13_A685ProveedorSitioWeb = new string[] {""} ;
         BC000N13_n685ProveedorSitioWeb = new bool[] {false} ;
         BC000N13_A686ProveedorAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         BC000N13_n686ProveedorAceptoTerminos = new bool[] {false} ;
         BC000N13_A437ProveedorPerAltShop = new string[] {""} ;
         BC000N13_n437ProveedorPerAltShop = new bool[] {false} ;
         BC000N13_A344ProveedorEstado = new string[] {""} ;
         BC000N13_A440ProveedorPagoDefault = new string[] {""} ;
         BC000N13_A490ProveedorPideDoc = new string[] {""} ;
         BC000N13_n490ProveedorPideDoc = new bool[] {false} ;
         BC000N13_A40001DocumentacionIcono_GXI = new string[] {""} ;
         BC000N13_A601ProveedorUsoInterno = new string[] {""} ;
         BC000N13_n601ProveedorUsoInterno = new bool[] {false} ;
         BC000N13_A687ProveedorCuentaBancaria = new string[] {""} ;
         BC000N13_n687ProveedorCuentaBancaria = new bool[] {false} ;
         BC000N13_A674BancoNombre = new string[] {""} ;
         BC000N13_A978ProveedorCIU = new bool[] {false} ;
         BC000N13_A999ProveedorFreezePrice = new bool[] {false} ;
         BC000N13_n999ProveedorFreezePrice = new bool[] {false} ;
         BC000N13_A151ProveedoresTipoId = new long[1] ;
         BC000N13_A488DocumentacionId = new long[1] ;
         BC000N13_n488DocumentacionId = new bool[] {false} ;
         BC000N13_A673BancoId = new long[1] ;
         BC000N13_n673BancoId = new bool[] {false} ;
         BC000N13_A432ProveedorImagen = new string[] {""} ;
         BC000N13_n432ProveedorImagen = new bool[] {false} ;
         BC000N13_A498DocumentacionIcono = new string[] {""} ;
         BC000N10_A278ProveedoresTipoNombre = new string[] {""} ;
         BC000N11_A40001DocumentacionIcono_GXI = new string[] {""} ;
         BC000N11_A498DocumentacionIcono = new string[] {""} ;
         BC000N12_A674BancoNombre = new string[] {""} ;
         BC000N14_A133ProveedorID = new long[1] ;
         BC000N14_n133ProveedorID = new bool[] {false} ;
         BC000N9_A133ProveedorID = new long[1] ;
         BC000N9_n133ProveedorID = new bool[] {false} ;
         BC000N9_A546ProveedorUsrAlta = new long[1] ;
         BC000N9_n546ProveedorUsrAlta = new bool[] {false} ;
         BC000N9_A547ProveedorUsrActualizacion = new long[1] ;
         BC000N9_n547ProveedorUsrActualizacion = new bool[] {false} ;
         BC000N9_A548ProveedorFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC000N9_n548ProveedorFechaAlta = new bool[] {false} ;
         BC000N9_A549ProveedorFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         BC000N9_n549ProveedorFechaActualizacion = new bool[] {false} ;
         BC000N9_A282ProveedorNombre = new string[] {""} ;
         BC000N9_A682ProveedorRazonSocial = new string[] {""} ;
         BC000N9_n682ProveedorRazonSocial = new bool[] {false} ;
         BC000N9_A683ProveedorContacto = new string[] {""} ;
         BC000N9_n683ProveedorContacto = new bool[] {false} ;
         BC000N9_A684ProveedorContactoCell = new string[] {""} ;
         BC000N9_n684ProveedorContactoCell = new bool[] {false} ;
         BC000N9_A40000ProveedorImagen_GXI = new string[] {""} ;
         BC000N9_n40000ProveedorImagen_GXI = new bool[] {false} ;
         BC000N9_A338ProveedorDocIdentidad = new string[] {""} ;
         BC000N9_A345ProveedorSerialComi = new short[1] ;
         BC000N9_A430ProveedorTelefono = new string[] {""} ;
         BC000N9_n430ProveedorTelefono = new bool[] {false} ;
         BC000N9_A431ProveedorDireccion = new string[] {""} ;
         BC000N9_n431ProveedorDireccion = new bool[] {false} ;
         BC000N9_A433ProveedorEmail = new string[] {""} ;
         BC000N9_n433ProveedorEmail = new bool[] {false} ;
         BC000N9_A685ProveedorSitioWeb = new string[] {""} ;
         BC000N9_n685ProveedorSitioWeb = new bool[] {false} ;
         BC000N9_A686ProveedorAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         BC000N9_n686ProveedorAceptoTerminos = new bool[] {false} ;
         BC000N9_A437ProveedorPerAltShop = new string[] {""} ;
         BC000N9_n437ProveedorPerAltShop = new bool[] {false} ;
         BC000N9_A344ProveedorEstado = new string[] {""} ;
         BC000N9_A440ProveedorPagoDefault = new string[] {""} ;
         BC000N9_A490ProveedorPideDoc = new string[] {""} ;
         BC000N9_n490ProveedorPideDoc = new bool[] {false} ;
         BC000N9_A601ProveedorUsoInterno = new string[] {""} ;
         BC000N9_n601ProveedorUsoInterno = new bool[] {false} ;
         BC000N9_A687ProveedorCuentaBancaria = new string[] {""} ;
         BC000N9_n687ProveedorCuentaBancaria = new bool[] {false} ;
         BC000N9_A978ProveedorCIU = new bool[] {false} ;
         BC000N9_A999ProveedorFreezePrice = new bool[] {false} ;
         BC000N9_n999ProveedorFreezePrice = new bool[] {false} ;
         BC000N9_A151ProveedoresTipoId = new long[1] ;
         BC000N9_A488DocumentacionId = new long[1] ;
         BC000N9_n488DocumentacionId = new bool[] {false} ;
         BC000N9_A673BancoId = new long[1] ;
         BC000N9_n673BancoId = new bool[] {false} ;
         BC000N9_A432ProveedorImagen = new string[] {""} ;
         BC000N9_n432ProveedorImagen = new bool[] {false} ;
         BC000N8_A133ProveedorID = new long[1] ;
         BC000N8_n133ProveedorID = new bool[] {false} ;
         BC000N8_A546ProveedorUsrAlta = new long[1] ;
         BC000N8_n546ProveedorUsrAlta = new bool[] {false} ;
         BC000N8_A547ProveedorUsrActualizacion = new long[1] ;
         BC000N8_n547ProveedorUsrActualizacion = new bool[] {false} ;
         BC000N8_A548ProveedorFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC000N8_n548ProveedorFechaAlta = new bool[] {false} ;
         BC000N8_A549ProveedorFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         BC000N8_n549ProveedorFechaActualizacion = new bool[] {false} ;
         BC000N8_A282ProveedorNombre = new string[] {""} ;
         BC000N8_A682ProveedorRazonSocial = new string[] {""} ;
         BC000N8_n682ProveedorRazonSocial = new bool[] {false} ;
         BC000N8_A683ProveedorContacto = new string[] {""} ;
         BC000N8_n683ProveedorContacto = new bool[] {false} ;
         BC000N8_A684ProveedorContactoCell = new string[] {""} ;
         BC000N8_n684ProveedorContactoCell = new bool[] {false} ;
         BC000N8_A40000ProveedorImagen_GXI = new string[] {""} ;
         BC000N8_n40000ProveedorImagen_GXI = new bool[] {false} ;
         BC000N8_A338ProveedorDocIdentidad = new string[] {""} ;
         BC000N8_A345ProveedorSerialComi = new short[1] ;
         BC000N8_A430ProveedorTelefono = new string[] {""} ;
         BC000N8_n430ProveedorTelefono = new bool[] {false} ;
         BC000N8_A431ProveedorDireccion = new string[] {""} ;
         BC000N8_n431ProveedorDireccion = new bool[] {false} ;
         BC000N8_A433ProveedorEmail = new string[] {""} ;
         BC000N8_n433ProveedorEmail = new bool[] {false} ;
         BC000N8_A685ProveedorSitioWeb = new string[] {""} ;
         BC000N8_n685ProveedorSitioWeb = new bool[] {false} ;
         BC000N8_A686ProveedorAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         BC000N8_n686ProveedorAceptoTerminos = new bool[] {false} ;
         BC000N8_A437ProveedorPerAltShop = new string[] {""} ;
         BC000N8_n437ProveedorPerAltShop = new bool[] {false} ;
         BC000N8_A344ProveedorEstado = new string[] {""} ;
         BC000N8_A440ProveedorPagoDefault = new string[] {""} ;
         BC000N8_A490ProveedorPideDoc = new string[] {""} ;
         BC000N8_n490ProveedorPideDoc = new bool[] {false} ;
         BC000N8_A601ProveedorUsoInterno = new string[] {""} ;
         BC000N8_n601ProveedorUsoInterno = new bool[] {false} ;
         BC000N8_A687ProveedorCuentaBancaria = new string[] {""} ;
         BC000N8_n687ProveedorCuentaBancaria = new bool[] {false} ;
         BC000N8_A978ProveedorCIU = new bool[] {false} ;
         BC000N8_A999ProveedorFreezePrice = new bool[] {false} ;
         BC000N8_n999ProveedorFreezePrice = new bool[] {false} ;
         BC000N8_A151ProveedoresTipoId = new long[1] ;
         BC000N8_A488DocumentacionId = new long[1] ;
         BC000N8_n488DocumentacionId = new bool[] {false} ;
         BC000N8_A673BancoId = new long[1] ;
         BC000N8_n673BancoId = new bool[] {false} ;
         BC000N8_A432ProveedorImagen = new string[] {""} ;
         BC000N8_n432ProveedorImagen = new bool[] {false} ;
         BC000N15_A133ProveedorID = new long[1] ;
         BC000N15_n133ProveedorID = new bool[] {false} ;
         BC000N19_A278ProveedoresTipoNombre = new string[] {""} ;
         BC000N20_A40001DocumentacionIcono_GXI = new string[] {""} ;
         BC000N20_A498DocumentacionIcono = new string[] {""} ;
         BC000N21_A674BancoNombre = new string[] {""} ;
         BC000N22_A422PostulacionesId = new long[1] ;
         BC000N23_A918MapeoID = new long[1] ;
         BC000N24_A918MapeoID = new long[1] ;
         BC000N25_A491VincularTrnId = new long[1] ;
         BC000N26_A450ProfComisionesID = new long[1] ;
         BC000N26_A452ProfComisionesRubrosId = new long[1] ;
         BC000N27_A127SolicitudesID = new long[1] ;
         BC000N28_A127SolicitudesID = new long[1] ;
         BC000N29_A133ProveedorID = new long[1] ;
         BC000N29_n133ProveedorID = new bool[] {false} ;
         BC000N29_A713ComercioProductosRubrosID = new long[1] ;
         BC000N30_A590Listaid = new long[1] ;
         BC000N30_A133ProveedorID = new long[1] ;
         BC000N30_n133ProveedorID = new bool[] {false} ;
         BC000N30_A120ProfesionalesId = new string[] {""} ;
         BC000N31_A590Listaid = new long[1] ;
         BC000N31_A18SecUserId = new long[1] ;
         BC000N31_A133ProveedorID = new long[1] ;
         BC000N31_n133ProveedorID = new bool[] {false} ;
         BC000N32_A503ComisionesID = new long[1] ;
         BC000N32_A133ProveedorID = new long[1] ;
         BC000N32_n133ProveedorID = new bool[] {false} ;
         BC000N33_A133ProveedorID = new long[1] ;
         BC000N33_n133ProveedorID = new bool[] {false} ;
         BC000N33_A152ProveedorSolicitudesId = new long[1] ;
         BC000N34_A133ProveedorID = new long[1] ;
         BC000N34_n133ProveedorID = new bool[] {false} ;
         BC000N34_A546ProveedorUsrAlta = new long[1] ;
         BC000N34_n546ProveedorUsrAlta = new bool[] {false} ;
         BC000N34_A547ProveedorUsrActualizacion = new long[1] ;
         BC000N34_n547ProveedorUsrActualizacion = new bool[] {false} ;
         BC000N34_A548ProveedorFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC000N34_n548ProveedorFechaAlta = new bool[] {false} ;
         BC000N34_A549ProveedorFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         BC000N34_n549ProveedorFechaActualizacion = new bool[] {false} ;
         BC000N34_A278ProveedoresTipoNombre = new string[] {""} ;
         BC000N34_A282ProveedorNombre = new string[] {""} ;
         BC000N34_A682ProveedorRazonSocial = new string[] {""} ;
         BC000N34_n682ProveedorRazonSocial = new bool[] {false} ;
         BC000N34_A683ProveedorContacto = new string[] {""} ;
         BC000N34_n683ProveedorContacto = new bool[] {false} ;
         BC000N34_A684ProveedorContactoCell = new string[] {""} ;
         BC000N34_n684ProveedorContactoCell = new bool[] {false} ;
         BC000N34_A40000ProveedorImagen_GXI = new string[] {""} ;
         BC000N34_n40000ProveedorImagen_GXI = new bool[] {false} ;
         BC000N34_A338ProveedorDocIdentidad = new string[] {""} ;
         BC000N34_A345ProveedorSerialComi = new short[1] ;
         BC000N34_A430ProveedorTelefono = new string[] {""} ;
         BC000N34_n430ProveedorTelefono = new bool[] {false} ;
         BC000N34_A431ProveedorDireccion = new string[] {""} ;
         BC000N34_n431ProveedorDireccion = new bool[] {false} ;
         BC000N34_A433ProveedorEmail = new string[] {""} ;
         BC000N34_n433ProveedorEmail = new bool[] {false} ;
         BC000N34_A685ProveedorSitioWeb = new string[] {""} ;
         BC000N34_n685ProveedorSitioWeb = new bool[] {false} ;
         BC000N34_A686ProveedorAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         BC000N34_n686ProveedorAceptoTerminos = new bool[] {false} ;
         BC000N34_A437ProveedorPerAltShop = new string[] {""} ;
         BC000N34_n437ProveedorPerAltShop = new bool[] {false} ;
         BC000N34_A344ProveedorEstado = new string[] {""} ;
         BC000N34_A440ProveedorPagoDefault = new string[] {""} ;
         BC000N34_A490ProveedorPideDoc = new string[] {""} ;
         BC000N34_n490ProveedorPideDoc = new bool[] {false} ;
         BC000N34_A40001DocumentacionIcono_GXI = new string[] {""} ;
         BC000N34_A601ProveedorUsoInterno = new string[] {""} ;
         BC000N34_n601ProveedorUsoInterno = new bool[] {false} ;
         BC000N34_A687ProveedorCuentaBancaria = new string[] {""} ;
         BC000N34_n687ProveedorCuentaBancaria = new bool[] {false} ;
         BC000N34_A674BancoNombre = new string[] {""} ;
         BC000N34_A978ProveedorCIU = new bool[] {false} ;
         BC000N34_A999ProveedorFreezePrice = new bool[] {false} ;
         BC000N34_n999ProveedorFreezePrice = new bool[] {false} ;
         BC000N34_A151ProveedoresTipoId = new long[1] ;
         BC000N34_A488DocumentacionId = new long[1] ;
         BC000N34_n488DocumentacionId = new bool[] {false} ;
         BC000N34_A673BancoId = new long[1] ;
         BC000N34_n673BancoId = new bool[] {false} ;
         BC000N34_A432ProveedorImagen = new string[] {""} ;
         BC000N34_n432ProveedorImagen = new bool[] {false} ;
         BC000N34_A498DocumentacionIcono = new string[] {""} ;
         Z346ProveedorComisionTipo = "";
         A346ProveedorComisionTipo = "";
         Z348ProveedorComisionAccion = "";
         A348ProveedorComisionAccion = "";
         Z136InventarioNombre = "";
         A136InventarioNombre = "";
         Z107EstadosTipo = "";
         A107EstadosTipo = "";
         Z109EstadosGenericosNombre = "";
         A109EstadosGenericosNombre = "";
         Z168RubrosImagen = "";
         A168RubrosImagen = "";
         Z40002RubrosImagen_GXI = "";
         A40002RubrosImagen_GXI = "";
         BC000N35_A133ProveedorID = new long[1] ;
         BC000N35_n133ProveedorID = new bool[] {false} ;
         BC000N35_A157ProveedorComisionID = new long[1] ;
         BC000N35_A40002RubrosImagen_GXI = new string[] {""} ;
         BC000N35_A136InventarioNombre = new string[] {""} ;
         BC000N35_A109EstadosGenericosNombre = new string[] {""} ;
         BC000N35_A181InventarioPrecioFinal = new decimal[1] ;
         BC000N35_A1001ProveedorComisionFP = new bool[] {false} ;
         BC000N35_n1001ProveedorComisionFP = new bool[] {false} ;
         BC000N35_A1000ProveedorComisionFPF = new decimal[1] ;
         BC000N35_n1000ProveedorComisionFPF = new bool[] {false} ;
         BC000N35_A346ProveedorComisionTipo = new string[] {""} ;
         BC000N35_A347ProveedorComision = new decimal[1] ;
         BC000N35_A348ProveedorComisionAccion = new string[] {""} ;
         BC000N35_A121RubrosId = new short[1] ;
         BC000N35_A137MedidasID = new long[1] ;
         BC000N35_A135InventarioId = new long[1] ;
         BC000N35_n135InventarioId = new bool[] {false} ;
         BC000N35_A118MonedaId = new short[1] ;
         BC000N35_A107EstadosTipo = new string[] {""} ;
         BC000N35_A108EstadosGenericosId = new int[1] ;
         BC000N35_A168RubrosImagen = new string[] {""} ;
         BC000N4_A40002RubrosImagen_GXI = new string[] {""} ;
         BC000N4_A168RubrosImagen = new string[] {""} ;
         BC000N5_A118MonedaId = new short[1] ;
         BC000N6_A136InventarioNombre = new string[] {""} ;
         BC000N6_A181InventarioPrecioFinal = new decimal[1] ;
         BC000N6_A107EstadosTipo = new string[] {""} ;
         BC000N6_A108EstadosGenericosId = new int[1] ;
         BC000N7_A109EstadosGenericosNombre = new string[] {""} ;
         BC000N36_A133ProveedorID = new long[1] ;
         BC000N36_n133ProveedorID = new bool[] {false} ;
         BC000N36_A157ProveedorComisionID = new long[1] ;
         BC000N3_A133ProveedorID = new long[1] ;
         BC000N3_n133ProveedorID = new bool[] {false} ;
         BC000N3_A157ProveedorComisionID = new long[1] ;
         BC000N3_A1001ProveedorComisionFP = new bool[] {false} ;
         BC000N3_n1001ProveedorComisionFP = new bool[] {false} ;
         BC000N3_A1000ProveedorComisionFPF = new decimal[1] ;
         BC000N3_n1000ProveedorComisionFPF = new bool[] {false} ;
         BC000N3_A346ProveedorComisionTipo = new string[] {""} ;
         BC000N3_A347ProveedorComision = new decimal[1] ;
         BC000N3_A348ProveedorComisionAccion = new string[] {""} ;
         BC000N3_A121RubrosId = new short[1] ;
         BC000N3_A137MedidasID = new long[1] ;
         BC000N3_A135InventarioId = new long[1] ;
         BC000N3_n135InventarioId = new bool[] {false} ;
         sMode29 = "";
         BC000N2_A133ProveedorID = new long[1] ;
         BC000N2_n133ProveedorID = new bool[] {false} ;
         BC000N2_A157ProveedorComisionID = new long[1] ;
         BC000N2_A1001ProveedorComisionFP = new bool[] {false} ;
         BC000N2_n1001ProveedorComisionFP = new bool[] {false} ;
         BC000N2_A1000ProveedorComisionFPF = new decimal[1] ;
         BC000N2_n1000ProveedorComisionFPF = new bool[] {false} ;
         BC000N2_A346ProveedorComisionTipo = new string[] {""} ;
         BC000N2_A347ProveedorComision = new decimal[1] ;
         BC000N2_A348ProveedorComisionAccion = new string[] {""} ;
         BC000N2_A121RubrosId = new short[1] ;
         BC000N2_A137MedidasID = new long[1] ;
         BC000N2_A135InventarioId = new long[1] ;
         BC000N2_n135InventarioId = new bool[] {false} ;
         BC000N40_A40002RubrosImagen_GXI = new string[] {""} ;
         BC000N40_A168RubrosImagen = new string[] {""} ;
         BC000N41_A118MonedaId = new short[1] ;
         BC000N42_A136InventarioNombre = new string[] {""} ;
         BC000N42_A181InventarioPrecioFinal = new decimal[1] ;
         BC000N42_A107EstadosTipo = new string[] {""} ;
         BC000N42_A108EstadosGenericosId = new int[1] ;
         BC000N43_A109EstadosGenericosNombre = new string[] {""} ;
         BC000N44_A133ProveedorID = new long[1] ;
         BC000N44_n133ProveedorID = new bool[] {false} ;
         BC000N44_A157ProveedorComisionID = new long[1] ;
         BC000N44_A40002RubrosImagen_GXI = new string[] {""} ;
         BC000N44_A136InventarioNombre = new string[] {""} ;
         BC000N44_A109EstadosGenericosNombre = new string[] {""} ;
         BC000N44_A181InventarioPrecioFinal = new decimal[1] ;
         BC000N44_A1001ProveedorComisionFP = new bool[] {false} ;
         BC000N44_n1001ProveedorComisionFP = new bool[] {false} ;
         BC000N44_A1000ProveedorComisionFPF = new decimal[1] ;
         BC000N44_n1000ProveedorComisionFPF = new bool[] {false} ;
         BC000N44_A346ProveedorComisionTipo = new string[] {""} ;
         BC000N44_A347ProveedorComision = new decimal[1] ;
         BC000N44_A348ProveedorComisionAccion = new string[] {""} ;
         BC000N44_A121RubrosId = new short[1] ;
         BC000N44_A137MedidasID = new long[1] ;
         BC000N44_A135InventarioId = new long[1] ;
         BC000N44_n135InventarioId = new bool[] {false} ;
         BC000N44_A118MonedaId = new short[1] ;
         BC000N44_A107EstadosTipo = new string[] {""} ;
         BC000N44_A108EstadosGenericosId = new int[1] ;
         BC000N44_A168RubrosImagen = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.proveedor_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.proveedor_bc__default(),
            new Object[][] {
                new Object[] {
               BC000N2_A133ProveedorID, BC000N2_A157ProveedorComisionID, BC000N2_A1001ProveedorComisionFP, BC000N2_n1001ProveedorComisionFP, BC000N2_A1000ProveedorComisionFPF, BC000N2_n1000ProveedorComisionFPF, BC000N2_A346ProveedorComisionTipo, BC000N2_A347ProveedorComision, BC000N2_A348ProveedorComisionAccion, BC000N2_A121RubrosId,
               BC000N2_A137MedidasID, BC000N2_A135InventarioId, BC000N2_n135InventarioId
               }
               , new Object[] {
               BC000N3_A133ProveedorID, BC000N3_A157ProveedorComisionID, BC000N3_A1001ProveedorComisionFP, BC000N3_n1001ProveedorComisionFP, BC000N3_A1000ProveedorComisionFPF, BC000N3_n1000ProveedorComisionFPF, BC000N3_A346ProveedorComisionTipo, BC000N3_A347ProveedorComision, BC000N3_A348ProveedorComisionAccion, BC000N3_A121RubrosId,
               BC000N3_A137MedidasID, BC000N3_A135InventarioId, BC000N3_n135InventarioId
               }
               , new Object[] {
               BC000N4_A40002RubrosImagen_GXI, BC000N4_A168RubrosImagen
               }
               , new Object[] {
               BC000N5_A118MonedaId
               }
               , new Object[] {
               BC000N6_A136InventarioNombre, BC000N6_A181InventarioPrecioFinal, BC000N6_A107EstadosTipo, BC000N6_A108EstadosGenericosId
               }
               , new Object[] {
               BC000N7_A109EstadosGenericosNombre
               }
               , new Object[] {
               BC000N8_A133ProveedorID, BC000N8_A546ProveedorUsrAlta, BC000N8_n546ProveedorUsrAlta, BC000N8_A547ProveedorUsrActualizacion, BC000N8_n547ProveedorUsrActualizacion, BC000N8_A548ProveedorFechaAlta, BC000N8_n548ProveedorFechaAlta, BC000N8_A549ProveedorFechaActualizacion, BC000N8_n549ProveedorFechaActualizacion, BC000N8_A282ProveedorNombre,
               BC000N8_A682ProveedorRazonSocial, BC000N8_n682ProveedorRazonSocial, BC000N8_A683ProveedorContacto, BC000N8_n683ProveedorContacto, BC000N8_A684ProveedorContactoCell, BC000N8_n684ProveedorContactoCell, BC000N8_A40000ProveedorImagen_GXI, BC000N8_n40000ProveedorImagen_GXI, BC000N8_A338ProveedorDocIdentidad, BC000N8_A345ProveedorSerialComi,
               BC000N8_A430ProveedorTelefono, BC000N8_n430ProveedorTelefono, BC000N8_A431ProveedorDireccion, BC000N8_n431ProveedorDireccion, BC000N8_A433ProveedorEmail, BC000N8_n433ProveedorEmail, BC000N8_A685ProveedorSitioWeb, BC000N8_n685ProveedorSitioWeb, BC000N8_A686ProveedorAceptoTerminos, BC000N8_n686ProveedorAceptoTerminos,
               BC000N8_A437ProveedorPerAltShop, BC000N8_n437ProveedorPerAltShop, BC000N8_A344ProveedorEstado, BC000N8_A440ProveedorPagoDefault, BC000N8_A490ProveedorPideDoc, BC000N8_n490ProveedorPideDoc, BC000N8_A601ProveedorUsoInterno, BC000N8_n601ProveedorUsoInterno, BC000N8_A687ProveedorCuentaBancaria, BC000N8_n687ProveedorCuentaBancaria,
               BC000N8_A978ProveedorCIU, BC000N8_A999ProveedorFreezePrice, BC000N8_n999ProveedorFreezePrice, BC000N8_A151ProveedoresTipoId, BC000N8_A488DocumentacionId, BC000N8_n488DocumentacionId, BC000N8_A673BancoId, BC000N8_n673BancoId, BC000N8_A432ProveedorImagen, BC000N8_n432ProveedorImagen
               }
               , new Object[] {
               BC000N9_A133ProveedorID, BC000N9_A546ProveedorUsrAlta, BC000N9_n546ProveedorUsrAlta, BC000N9_A547ProveedorUsrActualizacion, BC000N9_n547ProveedorUsrActualizacion, BC000N9_A548ProveedorFechaAlta, BC000N9_n548ProveedorFechaAlta, BC000N9_A549ProveedorFechaActualizacion, BC000N9_n549ProveedorFechaActualizacion, BC000N9_A282ProveedorNombre,
               BC000N9_A682ProveedorRazonSocial, BC000N9_n682ProveedorRazonSocial, BC000N9_A683ProveedorContacto, BC000N9_n683ProveedorContacto, BC000N9_A684ProveedorContactoCell, BC000N9_n684ProveedorContactoCell, BC000N9_A40000ProveedorImagen_GXI, BC000N9_n40000ProveedorImagen_GXI, BC000N9_A338ProveedorDocIdentidad, BC000N9_A345ProveedorSerialComi,
               BC000N9_A430ProveedorTelefono, BC000N9_n430ProveedorTelefono, BC000N9_A431ProveedorDireccion, BC000N9_n431ProveedorDireccion, BC000N9_A433ProveedorEmail, BC000N9_n433ProveedorEmail, BC000N9_A685ProveedorSitioWeb, BC000N9_n685ProveedorSitioWeb, BC000N9_A686ProveedorAceptoTerminos, BC000N9_n686ProveedorAceptoTerminos,
               BC000N9_A437ProveedorPerAltShop, BC000N9_n437ProveedorPerAltShop, BC000N9_A344ProveedorEstado, BC000N9_A440ProveedorPagoDefault, BC000N9_A490ProveedorPideDoc, BC000N9_n490ProveedorPideDoc, BC000N9_A601ProveedorUsoInterno, BC000N9_n601ProveedorUsoInterno, BC000N9_A687ProveedorCuentaBancaria, BC000N9_n687ProveedorCuentaBancaria,
               BC000N9_A978ProveedorCIU, BC000N9_A999ProveedorFreezePrice, BC000N9_n999ProveedorFreezePrice, BC000N9_A151ProveedoresTipoId, BC000N9_A488DocumentacionId, BC000N9_n488DocumentacionId, BC000N9_A673BancoId, BC000N9_n673BancoId, BC000N9_A432ProveedorImagen, BC000N9_n432ProveedorImagen
               }
               , new Object[] {
               BC000N10_A278ProveedoresTipoNombre
               }
               , new Object[] {
               BC000N11_A40001DocumentacionIcono_GXI, BC000N11_A498DocumentacionIcono
               }
               , new Object[] {
               BC000N12_A674BancoNombre
               }
               , new Object[] {
               BC000N13_A133ProveedorID, BC000N13_A546ProveedorUsrAlta, BC000N13_n546ProveedorUsrAlta, BC000N13_A547ProveedorUsrActualizacion, BC000N13_n547ProveedorUsrActualizacion, BC000N13_A548ProveedorFechaAlta, BC000N13_n548ProveedorFechaAlta, BC000N13_A549ProveedorFechaActualizacion, BC000N13_n549ProveedorFechaActualizacion, BC000N13_A278ProveedoresTipoNombre,
               BC000N13_A282ProveedorNombre, BC000N13_A682ProveedorRazonSocial, BC000N13_n682ProveedorRazonSocial, BC000N13_A683ProveedorContacto, BC000N13_n683ProveedorContacto, BC000N13_A684ProveedorContactoCell, BC000N13_n684ProveedorContactoCell, BC000N13_A40000ProveedorImagen_GXI, BC000N13_n40000ProveedorImagen_GXI, BC000N13_A338ProveedorDocIdentidad,
               BC000N13_A345ProveedorSerialComi, BC000N13_A430ProveedorTelefono, BC000N13_n430ProveedorTelefono, BC000N13_A431ProveedorDireccion, BC000N13_n431ProveedorDireccion, BC000N13_A433ProveedorEmail, BC000N13_n433ProveedorEmail, BC000N13_A685ProveedorSitioWeb, BC000N13_n685ProveedorSitioWeb, BC000N13_A686ProveedorAceptoTerminos,
               BC000N13_n686ProveedorAceptoTerminos, BC000N13_A437ProveedorPerAltShop, BC000N13_n437ProveedorPerAltShop, BC000N13_A344ProveedorEstado, BC000N13_A440ProveedorPagoDefault, BC000N13_A490ProveedorPideDoc, BC000N13_n490ProveedorPideDoc, BC000N13_A40001DocumentacionIcono_GXI, BC000N13_A601ProveedorUsoInterno, BC000N13_n601ProveedorUsoInterno,
               BC000N13_A687ProveedorCuentaBancaria, BC000N13_n687ProveedorCuentaBancaria, BC000N13_A674BancoNombre, BC000N13_A978ProveedorCIU, BC000N13_A999ProveedorFreezePrice, BC000N13_n999ProveedorFreezePrice, BC000N13_A151ProveedoresTipoId, BC000N13_A488DocumentacionId, BC000N13_n488DocumentacionId, BC000N13_A673BancoId,
               BC000N13_n673BancoId, BC000N13_A432ProveedorImagen, BC000N13_n432ProveedorImagen, BC000N13_A498DocumentacionIcono
               }
               , new Object[] {
               BC000N14_A133ProveedorID
               }
               , new Object[] {
               BC000N15_A133ProveedorID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000N19_A278ProveedoresTipoNombre
               }
               , new Object[] {
               BC000N20_A40001DocumentacionIcono_GXI, BC000N20_A498DocumentacionIcono
               }
               , new Object[] {
               BC000N21_A674BancoNombre
               }
               , new Object[] {
               BC000N22_A422PostulacionesId
               }
               , new Object[] {
               BC000N23_A918MapeoID
               }
               , new Object[] {
               BC000N24_A918MapeoID
               }
               , new Object[] {
               BC000N25_A491VincularTrnId
               }
               , new Object[] {
               BC000N26_A450ProfComisionesID, BC000N26_A452ProfComisionesRubrosId
               }
               , new Object[] {
               BC000N27_A127SolicitudesID
               }
               , new Object[] {
               BC000N28_A127SolicitudesID
               }
               , new Object[] {
               BC000N29_A133ProveedorID, BC000N29_A713ComercioProductosRubrosID
               }
               , new Object[] {
               BC000N30_A590Listaid, BC000N30_A133ProveedorID, BC000N30_A120ProfesionalesId
               }
               , new Object[] {
               BC000N31_A590Listaid, BC000N31_A18SecUserId, BC000N31_A133ProveedorID
               }
               , new Object[] {
               BC000N32_A503ComisionesID, BC000N32_A133ProveedorID
               }
               , new Object[] {
               BC000N33_A133ProveedorID, BC000N33_A152ProveedorSolicitudesId
               }
               , new Object[] {
               BC000N34_A133ProveedorID, BC000N34_A546ProveedorUsrAlta, BC000N34_n546ProveedorUsrAlta, BC000N34_A547ProveedorUsrActualizacion, BC000N34_n547ProveedorUsrActualizacion, BC000N34_A548ProveedorFechaAlta, BC000N34_n548ProveedorFechaAlta, BC000N34_A549ProveedorFechaActualizacion, BC000N34_n549ProveedorFechaActualizacion, BC000N34_A278ProveedoresTipoNombre,
               BC000N34_A282ProveedorNombre, BC000N34_A682ProveedorRazonSocial, BC000N34_n682ProveedorRazonSocial, BC000N34_A683ProveedorContacto, BC000N34_n683ProveedorContacto, BC000N34_A684ProveedorContactoCell, BC000N34_n684ProveedorContactoCell, BC000N34_A40000ProveedorImagen_GXI, BC000N34_n40000ProveedorImagen_GXI, BC000N34_A338ProveedorDocIdentidad,
               BC000N34_A345ProveedorSerialComi, BC000N34_A430ProveedorTelefono, BC000N34_n430ProveedorTelefono, BC000N34_A431ProveedorDireccion, BC000N34_n431ProveedorDireccion, BC000N34_A433ProveedorEmail, BC000N34_n433ProveedorEmail, BC000N34_A685ProveedorSitioWeb, BC000N34_n685ProveedorSitioWeb, BC000N34_A686ProveedorAceptoTerminos,
               BC000N34_n686ProveedorAceptoTerminos, BC000N34_A437ProveedorPerAltShop, BC000N34_n437ProveedorPerAltShop, BC000N34_A344ProveedorEstado, BC000N34_A440ProveedorPagoDefault, BC000N34_A490ProveedorPideDoc, BC000N34_n490ProveedorPideDoc, BC000N34_A40001DocumentacionIcono_GXI, BC000N34_A601ProveedorUsoInterno, BC000N34_n601ProveedorUsoInterno,
               BC000N34_A687ProveedorCuentaBancaria, BC000N34_n687ProveedorCuentaBancaria, BC000N34_A674BancoNombre, BC000N34_A978ProveedorCIU, BC000N34_A999ProveedorFreezePrice, BC000N34_n999ProveedorFreezePrice, BC000N34_A151ProveedoresTipoId, BC000N34_A488DocumentacionId, BC000N34_n488DocumentacionId, BC000N34_A673BancoId,
               BC000N34_n673BancoId, BC000N34_A432ProveedorImagen, BC000N34_n432ProveedorImagen, BC000N34_A498DocumentacionIcono
               }
               , new Object[] {
               BC000N35_A133ProveedorID, BC000N35_A157ProveedorComisionID, BC000N35_A40002RubrosImagen_GXI, BC000N35_A136InventarioNombre, BC000N35_A109EstadosGenericosNombre, BC000N35_A181InventarioPrecioFinal, BC000N35_A1001ProveedorComisionFP, BC000N35_n1001ProveedorComisionFP, BC000N35_A1000ProveedorComisionFPF, BC000N35_n1000ProveedorComisionFPF,
               BC000N35_A346ProveedorComisionTipo, BC000N35_A347ProveedorComision, BC000N35_A348ProveedorComisionAccion, BC000N35_A121RubrosId, BC000N35_A137MedidasID, BC000N35_A135InventarioId, BC000N35_n135InventarioId, BC000N35_A118MonedaId, BC000N35_A107EstadosTipo, BC000N35_A108EstadosGenericosId,
               BC000N35_A168RubrosImagen
               }
               , new Object[] {
               BC000N36_A133ProveedorID, BC000N36_A157ProveedorComisionID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000N40_A40002RubrosImagen_GXI, BC000N40_A168RubrosImagen
               }
               , new Object[] {
               BC000N41_A118MonedaId
               }
               , new Object[] {
               BC000N42_A136InventarioNombre, BC000N42_A181InventarioPrecioFinal, BC000N42_A107EstadosTipo, BC000N42_A108EstadosGenericosId
               }
               , new Object[] {
               BC000N43_A109EstadosGenericosNombre
               }
               , new Object[] {
               BC000N44_A133ProveedorID, BC000N44_A157ProveedorComisionID, BC000N44_A40002RubrosImagen_GXI, BC000N44_A136InventarioNombre, BC000N44_A109EstadosGenericosNombre, BC000N44_A181InventarioPrecioFinal, BC000N44_A1001ProveedorComisionFP, BC000N44_n1001ProveedorComisionFP, BC000N44_A1000ProveedorComisionFPF, BC000N44_n1000ProveedorComisionFPF,
               BC000N44_A346ProveedorComisionTipo, BC000N44_A347ProveedorComision, BC000N44_A348ProveedorComisionAccion, BC000N44_A121RubrosId, BC000N44_A137MedidasID, BC000N44_A135InventarioId, BC000N44_n135InventarioId, BC000N44_A118MonedaId, BC000N44_A107EstadosTipo, BC000N44_A108EstadosGenericosId,
               BC000N44_A168RubrosImagen
               }
            }
         );
         Z978ProveedorCIU = false;
         A978ProveedorCIU = false;
         i978ProveedorCIU = false;
         AV40Pgmname = "Proveedor_BC";
         Z999ProveedorFreezePrice = false;
         n999ProveedorFreezePrice = false;
         A999ProveedorFreezePrice = false;
         n999ProveedorFreezePrice = false;
         i999ProveedorFreezePrice = false;
         n999ProveedorFreezePrice = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120N2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_29 ;
      private short RcdFound29 ;
      private short Z345ProveedorSerialComi ;
      private short A345ProveedorSerialComi ;
      private short Gx_BScreen ;
      private short RcdFound28 ;
      private short nRcdExists_29 ;
      private short Z121RubrosId ;
      private short A121RubrosId ;
      private short Z118MonedaId ;
      private short A118MonedaId ;
      private short Gxremove29 ;
      private int trnEnded ;
      private int nGXsfl_29_idx=1 ;
      private int AV41GXV1 ;
      private int AV42GXV2 ;
      private int Z108EstadosGenericosId ;
      private int A108EstadosGenericosId ;
      private long Z133ProveedorID ;
      private long A133ProveedorID ;
      private long AV13Insert_ProveedoresTipoId ;
      private long AV14Insert_DocumentacionId ;
      private long AV36Insert_BancoId ;
      private long AV7ProveedorID ;
      private long Z546ProveedorUsrAlta ;
      private long A546ProveedorUsrAlta ;
      private long Z547ProveedorUsrActualizacion ;
      private long A547ProveedorUsrActualizacion ;
      private long Z151ProveedoresTipoId ;
      private long A151ProveedoresTipoId ;
      private long Z488DocumentacionId ;
      private long A488DocumentacionId ;
      private long Z673BancoId ;
      private long A673BancoId ;
      private long Z137MedidasID ;
      private long A137MedidasID ;
      private long Z135InventarioId ;
      private long A135InventarioId ;
      private long Z157ProveedorComisionID ;
      private long A157ProveedorComisionID ;
      private decimal Z1000ProveedorComisionFPF ;
      private decimal A1000ProveedorComisionFPF ;
      private decimal Z347ProveedorComision ;
      private decimal A347ProveedorComision ;
      private decimal Z181InventarioPrecioFinal ;
      private decimal A181InventarioPrecioFinal ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode28 ;
      private string AV40Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV33AgrProveedorEstado ;
      private string Z282ProveedorNombre ;
      private string A282ProveedorNombre ;
      private string Z682ProveedorRazonSocial ;
      private string A682ProveedorRazonSocial ;
      private string Z683ProveedorContacto ;
      private string A683ProveedorContacto ;
      private string Z684ProveedorContactoCell ;
      private string A684ProveedorContactoCell ;
      private string Z338ProveedorDocIdentidad ;
      private string A338ProveedorDocIdentidad ;
      private string Z430ProveedorTelefono ;
      private string A430ProveedorTelefono ;
      private string Z685ProveedorSitioWeb ;
      private string A685ProveedorSitioWeb ;
      private string Z437ProveedorPerAltShop ;
      private string A437ProveedorPerAltShop ;
      private string Z344ProveedorEstado ;
      private string A344ProveedorEstado ;
      private string Z440ProveedorPagoDefault ;
      private string A440ProveedorPagoDefault ;
      private string Z490ProveedorPideDoc ;
      private string A490ProveedorPideDoc ;
      private string Z601ProveedorUsoInterno ;
      private string A601ProveedorUsoInterno ;
      private string Z687ProveedorCuentaBancaria ;
      private string A687ProveedorCuentaBancaria ;
      private string Z278ProveedoresTipoNombre ;
      private string A278ProveedoresTipoNombre ;
      private string Z674BancoNombre ;
      private string A674BancoNombre ;
      private string Z346ProveedorComisionTipo ;
      private string A346ProveedorComisionTipo ;
      private string Z348ProveedorComisionAccion ;
      private string A348ProveedorComisionAccion ;
      private string Z136InventarioNombre ;
      private string A136InventarioNombre ;
      private string Z107EstadosTipo ;
      private string A107EstadosTipo ;
      private string Z109EstadosGenericosNombre ;
      private string A109EstadosGenericosNombre ;
      private string sMode29 ;
      private DateTime Z548ProveedorFechaAlta ;
      private DateTime A548ProveedorFechaAlta ;
      private DateTime Z549ProveedorFechaActualizacion ;
      private DateTime A549ProveedorFechaActualizacion ;
      private DateTime Z686ProveedorAceptoTerminos ;
      private DateTime A686ProveedorAceptoTerminos ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool AV37Existe ;
      private bool Z978ProveedorCIU ;
      private bool A978ProveedorCIU ;
      private bool Z999ProveedorFreezePrice ;
      private bool A999ProveedorFreezePrice ;
      private bool n548ProveedorFechaAlta ;
      private bool n549ProveedorFechaActualizacion ;
      private bool n546ProveedorUsrAlta ;
      private bool n547ProveedorUsrActualizacion ;
      private bool n999ProveedorFreezePrice ;
      private bool n133ProveedorID ;
      private bool n682ProveedorRazonSocial ;
      private bool n683ProveedorContacto ;
      private bool n684ProveedorContactoCell ;
      private bool n40000ProveedorImagen_GXI ;
      private bool n430ProveedorTelefono ;
      private bool n431ProveedorDireccion ;
      private bool n433ProveedorEmail ;
      private bool n685ProveedorSitioWeb ;
      private bool n686ProveedorAceptoTerminos ;
      private bool n437ProveedorPerAltShop ;
      private bool n490ProveedorPideDoc ;
      private bool n601ProveedorUsoInterno ;
      private bool n687ProveedorCuentaBancaria ;
      private bool n488DocumentacionId ;
      private bool n673BancoId ;
      private bool n432ProveedorImagen ;
      private bool Gx_longc ;
      private bool Z1001ProveedorComisionFP ;
      private bool A1001ProveedorComisionFP ;
      private bool n1001ProveedorComisionFP ;
      private bool n1000ProveedorComisionFPF ;
      private bool n135InventarioId ;
      private bool i978ProveedorCIU ;
      private bool i999ProveedorFreezePrice ;
      private string AV34SecRoleName ;
      private string Z431ProveedorDireccion ;
      private string A431ProveedorDireccion ;
      private string Z433ProveedorEmail ;
      private string A433ProveedorEmail ;
      private string Z40000ProveedorImagen_GXI ;
      private string A40000ProveedorImagen_GXI ;
      private string Z40001DocumentacionIcono_GXI ;
      private string A40001DocumentacionIcono_GXI ;
      private string Z40002RubrosImagen_GXI ;
      private string A40002RubrosImagen_GXI ;
      private string Z432ProveedorImagen ;
      private string A432ProveedorImagen ;
      private string Z498DocumentacionIcono ;
      private string A498DocumentacionIcono ;
      private string Z168RubrosImagen ;
      private string A168RubrosImagen ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtProveedor bcProveedor ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private SdtSDTRoles AV31Roles ;
      private SdtSDTRoles_Id AV32RolesItem ;
      private IDataStoreProvider pr_default ;
      private long[] BC000N13_A133ProveedorID ;
      private bool[] BC000N13_n133ProveedorID ;
      private long[] BC000N13_A546ProveedorUsrAlta ;
      private bool[] BC000N13_n546ProveedorUsrAlta ;
      private long[] BC000N13_A547ProveedorUsrActualizacion ;
      private bool[] BC000N13_n547ProveedorUsrActualizacion ;
      private DateTime[] BC000N13_A548ProveedorFechaAlta ;
      private bool[] BC000N13_n548ProveedorFechaAlta ;
      private DateTime[] BC000N13_A549ProveedorFechaActualizacion ;
      private bool[] BC000N13_n549ProveedorFechaActualizacion ;
      private string[] BC000N13_A278ProveedoresTipoNombre ;
      private string[] BC000N13_A282ProveedorNombre ;
      private string[] BC000N13_A682ProveedorRazonSocial ;
      private bool[] BC000N13_n682ProveedorRazonSocial ;
      private string[] BC000N13_A683ProveedorContacto ;
      private bool[] BC000N13_n683ProveedorContacto ;
      private string[] BC000N13_A684ProveedorContactoCell ;
      private bool[] BC000N13_n684ProveedorContactoCell ;
      private string[] BC000N13_A40000ProveedorImagen_GXI ;
      private bool[] BC000N13_n40000ProveedorImagen_GXI ;
      private string[] BC000N13_A338ProveedorDocIdentidad ;
      private short[] BC000N13_A345ProveedorSerialComi ;
      private string[] BC000N13_A430ProveedorTelefono ;
      private bool[] BC000N13_n430ProveedorTelefono ;
      private string[] BC000N13_A431ProveedorDireccion ;
      private bool[] BC000N13_n431ProveedorDireccion ;
      private string[] BC000N13_A433ProveedorEmail ;
      private bool[] BC000N13_n433ProveedorEmail ;
      private string[] BC000N13_A685ProveedorSitioWeb ;
      private bool[] BC000N13_n685ProveedorSitioWeb ;
      private DateTime[] BC000N13_A686ProveedorAceptoTerminos ;
      private bool[] BC000N13_n686ProveedorAceptoTerminos ;
      private string[] BC000N13_A437ProveedorPerAltShop ;
      private bool[] BC000N13_n437ProveedorPerAltShop ;
      private string[] BC000N13_A344ProveedorEstado ;
      private string[] BC000N13_A440ProveedorPagoDefault ;
      private string[] BC000N13_A490ProveedorPideDoc ;
      private bool[] BC000N13_n490ProveedorPideDoc ;
      private string[] BC000N13_A40001DocumentacionIcono_GXI ;
      private string[] BC000N13_A601ProveedorUsoInterno ;
      private bool[] BC000N13_n601ProveedorUsoInterno ;
      private string[] BC000N13_A687ProveedorCuentaBancaria ;
      private bool[] BC000N13_n687ProveedorCuentaBancaria ;
      private string[] BC000N13_A674BancoNombre ;
      private bool[] BC000N13_A978ProveedorCIU ;
      private bool[] BC000N13_A999ProveedorFreezePrice ;
      private bool[] BC000N13_n999ProveedorFreezePrice ;
      private long[] BC000N13_A151ProveedoresTipoId ;
      private long[] BC000N13_A488DocumentacionId ;
      private bool[] BC000N13_n488DocumentacionId ;
      private long[] BC000N13_A673BancoId ;
      private bool[] BC000N13_n673BancoId ;
      private string[] BC000N13_A432ProveedorImagen ;
      private bool[] BC000N13_n432ProveedorImagen ;
      private string[] BC000N13_A498DocumentacionIcono ;
      private string[] BC000N10_A278ProveedoresTipoNombre ;
      private string[] BC000N11_A40001DocumentacionIcono_GXI ;
      private string[] BC000N11_A498DocumentacionIcono ;
      private string[] BC000N12_A674BancoNombre ;
      private long[] BC000N14_A133ProveedorID ;
      private bool[] BC000N14_n133ProveedorID ;
      private long[] BC000N9_A133ProveedorID ;
      private bool[] BC000N9_n133ProveedorID ;
      private long[] BC000N9_A546ProveedorUsrAlta ;
      private bool[] BC000N9_n546ProveedorUsrAlta ;
      private long[] BC000N9_A547ProveedorUsrActualizacion ;
      private bool[] BC000N9_n547ProveedorUsrActualizacion ;
      private DateTime[] BC000N9_A548ProveedorFechaAlta ;
      private bool[] BC000N9_n548ProveedorFechaAlta ;
      private DateTime[] BC000N9_A549ProveedorFechaActualizacion ;
      private bool[] BC000N9_n549ProveedorFechaActualizacion ;
      private string[] BC000N9_A282ProveedorNombre ;
      private string[] BC000N9_A682ProveedorRazonSocial ;
      private bool[] BC000N9_n682ProveedorRazonSocial ;
      private string[] BC000N9_A683ProveedorContacto ;
      private bool[] BC000N9_n683ProveedorContacto ;
      private string[] BC000N9_A684ProveedorContactoCell ;
      private bool[] BC000N9_n684ProveedorContactoCell ;
      private string[] BC000N9_A40000ProveedorImagen_GXI ;
      private bool[] BC000N9_n40000ProveedorImagen_GXI ;
      private string[] BC000N9_A338ProveedorDocIdentidad ;
      private short[] BC000N9_A345ProveedorSerialComi ;
      private string[] BC000N9_A430ProveedorTelefono ;
      private bool[] BC000N9_n430ProveedorTelefono ;
      private string[] BC000N9_A431ProveedorDireccion ;
      private bool[] BC000N9_n431ProveedorDireccion ;
      private string[] BC000N9_A433ProveedorEmail ;
      private bool[] BC000N9_n433ProveedorEmail ;
      private string[] BC000N9_A685ProveedorSitioWeb ;
      private bool[] BC000N9_n685ProveedorSitioWeb ;
      private DateTime[] BC000N9_A686ProveedorAceptoTerminos ;
      private bool[] BC000N9_n686ProveedorAceptoTerminos ;
      private string[] BC000N9_A437ProveedorPerAltShop ;
      private bool[] BC000N9_n437ProveedorPerAltShop ;
      private string[] BC000N9_A344ProveedorEstado ;
      private string[] BC000N9_A440ProveedorPagoDefault ;
      private string[] BC000N9_A490ProveedorPideDoc ;
      private bool[] BC000N9_n490ProveedorPideDoc ;
      private string[] BC000N9_A601ProveedorUsoInterno ;
      private bool[] BC000N9_n601ProveedorUsoInterno ;
      private string[] BC000N9_A687ProveedorCuentaBancaria ;
      private bool[] BC000N9_n687ProveedorCuentaBancaria ;
      private bool[] BC000N9_A978ProveedorCIU ;
      private bool[] BC000N9_A999ProveedorFreezePrice ;
      private bool[] BC000N9_n999ProveedorFreezePrice ;
      private long[] BC000N9_A151ProveedoresTipoId ;
      private long[] BC000N9_A488DocumentacionId ;
      private bool[] BC000N9_n488DocumentacionId ;
      private long[] BC000N9_A673BancoId ;
      private bool[] BC000N9_n673BancoId ;
      private string[] BC000N9_A432ProveedorImagen ;
      private bool[] BC000N9_n432ProveedorImagen ;
      private long[] BC000N8_A133ProveedorID ;
      private bool[] BC000N8_n133ProveedorID ;
      private long[] BC000N8_A546ProveedorUsrAlta ;
      private bool[] BC000N8_n546ProveedorUsrAlta ;
      private long[] BC000N8_A547ProveedorUsrActualizacion ;
      private bool[] BC000N8_n547ProveedorUsrActualizacion ;
      private DateTime[] BC000N8_A548ProveedorFechaAlta ;
      private bool[] BC000N8_n548ProveedorFechaAlta ;
      private DateTime[] BC000N8_A549ProveedorFechaActualizacion ;
      private bool[] BC000N8_n549ProveedorFechaActualizacion ;
      private string[] BC000N8_A282ProveedorNombre ;
      private string[] BC000N8_A682ProveedorRazonSocial ;
      private bool[] BC000N8_n682ProveedorRazonSocial ;
      private string[] BC000N8_A683ProveedorContacto ;
      private bool[] BC000N8_n683ProveedorContacto ;
      private string[] BC000N8_A684ProveedorContactoCell ;
      private bool[] BC000N8_n684ProveedorContactoCell ;
      private string[] BC000N8_A40000ProveedorImagen_GXI ;
      private bool[] BC000N8_n40000ProveedorImagen_GXI ;
      private string[] BC000N8_A338ProveedorDocIdentidad ;
      private short[] BC000N8_A345ProveedorSerialComi ;
      private string[] BC000N8_A430ProveedorTelefono ;
      private bool[] BC000N8_n430ProveedorTelefono ;
      private string[] BC000N8_A431ProveedorDireccion ;
      private bool[] BC000N8_n431ProveedorDireccion ;
      private string[] BC000N8_A433ProveedorEmail ;
      private bool[] BC000N8_n433ProveedorEmail ;
      private string[] BC000N8_A685ProveedorSitioWeb ;
      private bool[] BC000N8_n685ProveedorSitioWeb ;
      private DateTime[] BC000N8_A686ProveedorAceptoTerminos ;
      private bool[] BC000N8_n686ProveedorAceptoTerminos ;
      private string[] BC000N8_A437ProveedorPerAltShop ;
      private bool[] BC000N8_n437ProveedorPerAltShop ;
      private string[] BC000N8_A344ProveedorEstado ;
      private string[] BC000N8_A440ProveedorPagoDefault ;
      private string[] BC000N8_A490ProveedorPideDoc ;
      private bool[] BC000N8_n490ProveedorPideDoc ;
      private string[] BC000N8_A601ProveedorUsoInterno ;
      private bool[] BC000N8_n601ProveedorUsoInterno ;
      private string[] BC000N8_A687ProveedorCuentaBancaria ;
      private bool[] BC000N8_n687ProveedorCuentaBancaria ;
      private bool[] BC000N8_A978ProveedorCIU ;
      private bool[] BC000N8_A999ProveedorFreezePrice ;
      private bool[] BC000N8_n999ProveedorFreezePrice ;
      private long[] BC000N8_A151ProveedoresTipoId ;
      private long[] BC000N8_A488DocumentacionId ;
      private bool[] BC000N8_n488DocumentacionId ;
      private long[] BC000N8_A673BancoId ;
      private bool[] BC000N8_n673BancoId ;
      private string[] BC000N8_A432ProveedorImagen ;
      private bool[] BC000N8_n432ProveedorImagen ;
      private long[] BC000N15_A133ProveedorID ;
      private bool[] BC000N15_n133ProveedorID ;
      private string[] BC000N19_A278ProveedoresTipoNombre ;
      private string[] BC000N20_A40001DocumentacionIcono_GXI ;
      private string[] BC000N20_A498DocumentacionIcono ;
      private string[] BC000N21_A674BancoNombre ;
      private long[] BC000N22_A422PostulacionesId ;
      private long[] BC000N23_A918MapeoID ;
      private long[] BC000N24_A918MapeoID ;
      private long[] BC000N25_A491VincularTrnId ;
      private long[] BC000N26_A450ProfComisionesID ;
      private long[] BC000N26_A452ProfComisionesRubrosId ;
      private long[] BC000N27_A127SolicitudesID ;
      private long[] BC000N28_A127SolicitudesID ;
      private long[] BC000N29_A133ProveedorID ;
      private bool[] BC000N29_n133ProveedorID ;
      private long[] BC000N29_A713ComercioProductosRubrosID ;
      private long[] BC000N30_A590Listaid ;
      private long[] BC000N30_A133ProveedorID ;
      private bool[] BC000N30_n133ProveedorID ;
      private string[] BC000N30_A120ProfesionalesId ;
      private long[] BC000N31_A590Listaid ;
      private long[] BC000N31_A18SecUserId ;
      private long[] BC000N31_A133ProveedorID ;
      private bool[] BC000N31_n133ProveedorID ;
      private long[] BC000N32_A503ComisionesID ;
      private long[] BC000N32_A133ProveedorID ;
      private bool[] BC000N32_n133ProveedorID ;
      private long[] BC000N33_A133ProveedorID ;
      private bool[] BC000N33_n133ProveedorID ;
      private long[] BC000N33_A152ProveedorSolicitudesId ;
      private long[] BC000N34_A133ProveedorID ;
      private bool[] BC000N34_n133ProveedorID ;
      private long[] BC000N34_A546ProveedorUsrAlta ;
      private bool[] BC000N34_n546ProveedorUsrAlta ;
      private long[] BC000N34_A547ProveedorUsrActualizacion ;
      private bool[] BC000N34_n547ProveedorUsrActualizacion ;
      private DateTime[] BC000N34_A548ProveedorFechaAlta ;
      private bool[] BC000N34_n548ProveedorFechaAlta ;
      private DateTime[] BC000N34_A549ProveedorFechaActualizacion ;
      private bool[] BC000N34_n549ProveedorFechaActualizacion ;
      private string[] BC000N34_A278ProveedoresTipoNombre ;
      private string[] BC000N34_A282ProveedorNombre ;
      private string[] BC000N34_A682ProveedorRazonSocial ;
      private bool[] BC000N34_n682ProveedorRazonSocial ;
      private string[] BC000N34_A683ProveedorContacto ;
      private bool[] BC000N34_n683ProveedorContacto ;
      private string[] BC000N34_A684ProveedorContactoCell ;
      private bool[] BC000N34_n684ProveedorContactoCell ;
      private string[] BC000N34_A40000ProveedorImagen_GXI ;
      private bool[] BC000N34_n40000ProveedorImagen_GXI ;
      private string[] BC000N34_A338ProveedorDocIdentidad ;
      private short[] BC000N34_A345ProveedorSerialComi ;
      private string[] BC000N34_A430ProveedorTelefono ;
      private bool[] BC000N34_n430ProveedorTelefono ;
      private string[] BC000N34_A431ProveedorDireccion ;
      private bool[] BC000N34_n431ProveedorDireccion ;
      private string[] BC000N34_A433ProveedorEmail ;
      private bool[] BC000N34_n433ProveedorEmail ;
      private string[] BC000N34_A685ProveedorSitioWeb ;
      private bool[] BC000N34_n685ProveedorSitioWeb ;
      private DateTime[] BC000N34_A686ProveedorAceptoTerminos ;
      private bool[] BC000N34_n686ProveedorAceptoTerminos ;
      private string[] BC000N34_A437ProveedorPerAltShop ;
      private bool[] BC000N34_n437ProveedorPerAltShop ;
      private string[] BC000N34_A344ProveedorEstado ;
      private string[] BC000N34_A440ProveedorPagoDefault ;
      private string[] BC000N34_A490ProveedorPideDoc ;
      private bool[] BC000N34_n490ProveedorPideDoc ;
      private string[] BC000N34_A40001DocumentacionIcono_GXI ;
      private string[] BC000N34_A601ProveedorUsoInterno ;
      private bool[] BC000N34_n601ProveedorUsoInterno ;
      private string[] BC000N34_A687ProveedorCuentaBancaria ;
      private bool[] BC000N34_n687ProveedorCuentaBancaria ;
      private string[] BC000N34_A674BancoNombre ;
      private bool[] BC000N34_A978ProveedorCIU ;
      private bool[] BC000N34_A999ProveedorFreezePrice ;
      private bool[] BC000N34_n999ProveedorFreezePrice ;
      private long[] BC000N34_A151ProveedoresTipoId ;
      private long[] BC000N34_A488DocumentacionId ;
      private bool[] BC000N34_n488DocumentacionId ;
      private long[] BC000N34_A673BancoId ;
      private bool[] BC000N34_n673BancoId ;
      private string[] BC000N34_A432ProveedorImagen ;
      private bool[] BC000N34_n432ProveedorImagen ;
      private string[] BC000N34_A498DocumentacionIcono ;
      private long[] BC000N35_A133ProveedorID ;
      private bool[] BC000N35_n133ProveedorID ;
      private long[] BC000N35_A157ProveedorComisionID ;
      private string[] BC000N35_A40002RubrosImagen_GXI ;
      private string[] BC000N35_A136InventarioNombre ;
      private string[] BC000N35_A109EstadosGenericosNombre ;
      private decimal[] BC000N35_A181InventarioPrecioFinal ;
      private bool[] BC000N35_A1001ProveedorComisionFP ;
      private bool[] BC000N35_n1001ProveedorComisionFP ;
      private decimal[] BC000N35_A1000ProveedorComisionFPF ;
      private bool[] BC000N35_n1000ProveedorComisionFPF ;
      private string[] BC000N35_A346ProveedorComisionTipo ;
      private decimal[] BC000N35_A347ProveedorComision ;
      private string[] BC000N35_A348ProveedorComisionAccion ;
      private short[] BC000N35_A121RubrosId ;
      private long[] BC000N35_A137MedidasID ;
      private long[] BC000N35_A135InventarioId ;
      private bool[] BC000N35_n135InventarioId ;
      private short[] BC000N35_A118MonedaId ;
      private string[] BC000N35_A107EstadosTipo ;
      private int[] BC000N35_A108EstadosGenericosId ;
      private string[] BC000N35_A168RubrosImagen ;
      private string[] BC000N4_A40002RubrosImagen_GXI ;
      private string[] BC000N4_A168RubrosImagen ;
      private short[] BC000N5_A118MonedaId ;
      private string[] BC000N6_A136InventarioNombre ;
      private decimal[] BC000N6_A181InventarioPrecioFinal ;
      private string[] BC000N6_A107EstadosTipo ;
      private int[] BC000N6_A108EstadosGenericosId ;
      private string[] BC000N7_A109EstadosGenericosNombre ;
      private long[] BC000N36_A133ProveedorID ;
      private bool[] BC000N36_n133ProveedorID ;
      private long[] BC000N36_A157ProveedorComisionID ;
      private long[] BC000N3_A133ProveedorID ;
      private bool[] BC000N3_n133ProveedorID ;
      private long[] BC000N3_A157ProveedorComisionID ;
      private bool[] BC000N3_A1001ProveedorComisionFP ;
      private bool[] BC000N3_n1001ProveedorComisionFP ;
      private decimal[] BC000N3_A1000ProveedorComisionFPF ;
      private bool[] BC000N3_n1000ProveedorComisionFPF ;
      private string[] BC000N3_A346ProveedorComisionTipo ;
      private decimal[] BC000N3_A347ProveedorComision ;
      private string[] BC000N3_A348ProveedorComisionAccion ;
      private short[] BC000N3_A121RubrosId ;
      private long[] BC000N3_A137MedidasID ;
      private long[] BC000N3_A135InventarioId ;
      private bool[] BC000N3_n135InventarioId ;
      private long[] BC000N2_A133ProveedorID ;
      private bool[] BC000N2_n133ProveedorID ;
      private long[] BC000N2_A157ProveedorComisionID ;
      private bool[] BC000N2_A1001ProveedorComisionFP ;
      private bool[] BC000N2_n1001ProveedorComisionFP ;
      private decimal[] BC000N2_A1000ProveedorComisionFPF ;
      private bool[] BC000N2_n1000ProveedorComisionFPF ;
      private string[] BC000N2_A346ProveedorComisionTipo ;
      private decimal[] BC000N2_A347ProveedorComision ;
      private string[] BC000N2_A348ProveedorComisionAccion ;
      private short[] BC000N2_A121RubrosId ;
      private long[] BC000N2_A137MedidasID ;
      private long[] BC000N2_A135InventarioId ;
      private bool[] BC000N2_n135InventarioId ;
      private string[] BC000N40_A40002RubrosImagen_GXI ;
      private string[] BC000N40_A168RubrosImagen ;
      private short[] BC000N41_A118MonedaId ;
      private string[] BC000N42_A136InventarioNombre ;
      private decimal[] BC000N42_A181InventarioPrecioFinal ;
      private string[] BC000N42_A107EstadosTipo ;
      private int[] BC000N42_A108EstadosGenericosId ;
      private string[] BC000N43_A109EstadosGenericosNombre ;
      private long[] BC000N44_A133ProveedorID ;
      private bool[] BC000N44_n133ProveedorID ;
      private long[] BC000N44_A157ProveedorComisionID ;
      private string[] BC000N44_A40002RubrosImagen_GXI ;
      private string[] BC000N44_A136InventarioNombre ;
      private string[] BC000N44_A109EstadosGenericosNombre ;
      private decimal[] BC000N44_A181InventarioPrecioFinal ;
      private bool[] BC000N44_A1001ProveedorComisionFP ;
      private bool[] BC000N44_n1001ProveedorComisionFP ;
      private decimal[] BC000N44_A1000ProveedorComisionFPF ;
      private bool[] BC000N44_n1000ProveedorComisionFPF ;
      private string[] BC000N44_A346ProveedorComisionTipo ;
      private decimal[] BC000N44_A347ProveedorComision ;
      private string[] BC000N44_A348ProveedorComisionAccion ;
      private short[] BC000N44_A121RubrosId ;
      private long[] BC000N44_A137MedidasID ;
      private long[] BC000N44_A135InventarioId ;
      private bool[] BC000N44_n135InventarioId ;
      private short[] BC000N44_A118MonedaId ;
      private string[] BC000N44_A107EstadosTipo ;
      private int[] BC000N44_A108EstadosGenericosId ;
      private string[] BC000N44_A168RubrosImagen ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class proveedor_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class proveedor_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new UpdateCursor(def[35])
       ,new UpdateCursor(def[36])
       ,new UpdateCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new ForEachCursor(def[42])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000N2;
        prmBC000N2 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorComisionID",GXType.Decimal,18,0)
        };
        Object[] prmBC000N3;
        prmBC000N3 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorComisionID",GXType.Decimal,18,0)
        };
        Object[] prmBC000N4;
        prmBC000N4 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000N5;
        prmBC000N5 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmBC000N6;
        prmBC000N6 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N7;
        prmBC000N7 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmBC000N8;
        prmBC000N8 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N9;
        prmBC000N9 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N10;
        prmBC000N10 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmBC000N11;
        prmBC000N11 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N12;
        prmBC000N12 = new Object[] {
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N13;
        prmBC000N13 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N14;
        prmBC000N14 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N15;
        prmBC000N15 = new Object[] {
        new ParDef("@ProveedorUsrAlta",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@ProveedorUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@ProveedorFechaAlta",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProveedorFechaActualizacion",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProveedorNombre",GXType.NChar,80,0) ,
        new ParDef("@ProveedorRazonSocial",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@ProveedorContacto",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ProveedorContactoCell",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ProveedorImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=8, Tbl="Proveedor", Fld="ProveedorImagen"} ,
        new ParDef("@ProveedorDocIdentidad",GXType.NChar,25,0) ,
        new ParDef("@ProveedorSerialComi",GXType.Int16,4,0) ,
        new ParDef("@ProveedorTelefono",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorDireccion",GXType.NVarChar,1024,0){Nullable=true} ,
        new ParDef("@ProveedorEmail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@ProveedorSitioWeb",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ProveedorAceptoTerminos",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProveedorPerAltShop",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@ProveedorEstado",GXType.NChar,3,0) ,
        new ParDef("@ProveedorPagoDefault",GXType.NChar,1,0) ,
        new ParDef("@ProveedorPideDoc",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@ProveedorUsoInterno",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@ProveedorCuentaBancaria",GXType.NChar,50,0){Nullable=true} ,
        new ParDef("@ProveedorCIU",GXType.Boolean,4,0) ,
        new ParDef("@ProveedorFreezePrice",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0) ,
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N16;
        prmBC000N16 = new Object[] {
        new ParDef("@ProveedorUsrAlta",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@ProveedorUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@ProveedorFechaAlta",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProveedorFechaActualizacion",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProveedorNombre",GXType.NChar,80,0) ,
        new ParDef("@ProveedorRazonSocial",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@ProveedorContacto",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ProveedorContactoCell",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorDocIdentidad",GXType.NChar,25,0) ,
        new ParDef("@ProveedorSerialComi",GXType.Int16,4,0) ,
        new ParDef("@ProveedorTelefono",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorDireccion",GXType.NVarChar,1024,0){Nullable=true} ,
        new ParDef("@ProveedorEmail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@ProveedorSitioWeb",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ProveedorAceptoTerminos",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProveedorPerAltShop",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@ProveedorEstado",GXType.NChar,3,0) ,
        new ParDef("@ProveedorPagoDefault",GXType.NChar,1,0) ,
        new ParDef("@ProveedorPideDoc",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@ProveedorUsoInterno",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@ProveedorCuentaBancaria",GXType.NChar,50,0){Nullable=true} ,
        new ParDef("@ProveedorCIU",GXType.Boolean,4,0) ,
        new ParDef("@ProveedorFreezePrice",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0) ,
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N17;
        prmBC000N17 = new Object[] {
        new ParDef("@ProveedorImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ProveedorImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Proveedor", Fld="ProveedorImagen"} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N18;
        prmBC000N18 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N19;
        prmBC000N19 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmBC000N20;
        prmBC000N20 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N21;
        prmBC000N21 = new Object[] {
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N22;
        prmBC000N22 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N23;
        prmBC000N23 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N24;
        prmBC000N24 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N25;
        prmBC000N25 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N26;
        prmBC000N26 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N27;
        prmBC000N27 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N28;
        prmBC000N28 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N29;
        prmBC000N29 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N30;
        prmBC000N30 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N31;
        prmBC000N31 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N32;
        prmBC000N32 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N33;
        prmBC000N33 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N34;
        prmBC000N34 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N35;
        prmBC000N35 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorComisionID",GXType.Decimal,18,0)
        };
        Object[] prmBC000N36;
        prmBC000N36 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorComisionID",GXType.Decimal,18,0)
        };
        Object[] prmBC000N37;
        prmBC000N37 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorComisionID",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorComisionFP",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ProveedorComisionFPF",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@ProveedorComisionTipo",GXType.NChar,1,0) ,
        new ParDef("@ProveedorComision",GXType.Decimal,18,2) ,
        new ParDef("@ProveedorComisionAccion",GXType.NChar,1,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N38;
        prmBC000N38 = new Object[] {
        new ParDef("@ProveedorComisionFP",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ProveedorComisionFPF",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@ProveedorComisionTipo",GXType.NChar,1,0) ,
        new ParDef("@ProveedorComision",GXType.Decimal,18,2) ,
        new ParDef("@ProveedorComisionAccion",GXType.NChar,1,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorComisionID",GXType.Decimal,18,0)
        };
        Object[] prmBC000N39;
        prmBC000N39 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorComisionID",GXType.Decimal,18,0)
        };
        Object[] prmBC000N40;
        prmBC000N40 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000N41;
        prmBC000N41 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmBC000N42;
        prmBC000N42 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000N43;
        prmBC000N43 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmBC000N44;
        prmBC000N44 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC000N2", "SELECT [ProveedorID], [ProveedorComisionID], [ProveedorComisionFP], [ProveedorComisionFPF], [ProveedorComisionTipo], [ProveedorComision], [ProveedorComisionAccion], [RubrosId], [MedidasID], [InventarioId] FROM [ProveedorComision] WITH (UPDLOCK) WHERE [ProveedorID] = @ProveedorID AND [ProveedorComisionID] = @ProveedorComisionID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N3", "SELECT [ProveedorID], [ProveedorComisionID], [ProveedorComisionFP], [ProveedorComisionFPF], [ProveedorComisionTipo], [ProveedorComision], [ProveedorComisionAccion], [RubrosId], [MedidasID], [InventarioId] FROM [ProveedorComision] WHERE [ProveedorID] = @ProveedorID AND [ProveedorComisionID] = @ProveedorComisionID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N4", "SELECT [RubrosImagen_GXI], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N5", "SELECT [MonedaId] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N6", "SELECT [InventarioNombre], [InventarioPrecioFinal], [EstadosTipo], [EstadosGenericosId] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N7", "SELECT [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N8", "SELECT [ProveedorID], [ProveedorUsrAlta], [ProveedorUsrActualizacion], [ProveedorFechaAlta], [ProveedorFechaActualizacion], [ProveedorNombre], [ProveedorRazonSocial], [ProveedorContacto], [ProveedorContactoCell], [ProveedorImagen_GXI], [ProveedorDocIdentidad], [ProveedorSerialComi], [ProveedorTelefono], [ProveedorDireccion], [ProveedorEmail], [ProveedorSitioWeb], [ProveedorAceptoTerminos], [ProveedorPerAltShop], [ProveedorEstado], [ProveedorPagoDefault], [ProveedorPideDoc], [ProveedorUsoInterno], [ProveedorCuentaBancaria], [ProveedorCIU], [ProveedorFreezePrice], [ProveedoresTipoId], [DocumentacionId], [BancoId], [ProveedorImagen] FROM [Proveedor] WITH (UPDLOCK) WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N9", "SELECT [ProveedorID], [ProveedorUsrAlta], [ProveedorUsrActualizacion], [ProveedorFechaAlta], [ProveedorFechaActualizacion], [ProveedorNombre], [ProveedorRazonSocial], [ProveedorContacto], [ProveedorContactoCell], [ProveedorImagen_GXI], [ProveedorDocIdentidad], [ProveedorSerialComi], [ProveedorTelefono], [ProveedorDireccion], [ProveedorEmail], [ProveedorSitioWeb], [ProveedorAceptoTerminos], [ProveedorPerAltShop], [ProveedorEstado], [ProveedorPagoDefault], [ProveedorPideDoc], [ProveedorUsoInterno], [ProveedorCuentaBancaria], [ProveedorCIU], [ProveedorFreezePrice], [ProveedoresTipoId], [DocumentacionId], [BancoId], [ProveedorImagen] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N10", "SELECT [ProveedoresTipoNombre] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N11", "SELECT [DocumentacionIcono_GXI], [DocumentacionIcono] FROM [Documentacion] WHERE [DocumentacionId] = @DocumentacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N12", "SELECT [BancoNombre] FROM [Banco] WHERE [BancoId] = @BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N13", "SELECT TM1.[ProveedorID], TM1.[ProveedorUsrAlta], TM1.[ProveedorUsrActualizacion], TM1.[ProveedorFechaAlta], TM1.[ProveedorFechaActualizacion], T2.[ProveedoresTipoNombre], TM1.[ProveedorNombre], TM1.[ProveedorRazonSocial], TM1.[ProveedorContacto], TM1.[ProveedorContactoCell], TM1.[ProveedorImagen_GXI], TM1.[ProveedorDocIdentidad], TM1.[ProveedorSerialComi], TM1.[ProveedorTelefono], TM1.[ProveedorDireccion], TM1.[ProveedorEmail], TM1.[ProveedorSitioWeb], TM1.[ProveedorAceptoTerminos], TM1.[ProveedorPerAltShop], TM1.[ProveedorEstado], TM1.[ProveedorPagoDefault], TM1.[ProveedorPideDoc], T3.[DocumentacionIcono_GXI], TM1.[ProveedorUsoInterno], TM1.[ProveedorCuentaBancaria], T4.[BancoNombre], TM1.[ProveedorCIU], TM1.[ProveedorFreezePrice], TM1.[ProveedoresTipoId], TM1.[DocumentacionId], TM1.[BancoId], TM1.[ProveedorImagen], T3.[DocumentacionIcono] FROM ((([Proveedor] TM1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = TM1.[ProveedoresTipoId]) LEFT JOIN [Documentacion] T3 ON T3.[DocumentacionId] = TM1.[DocumentacionId]) LEFT JOIN [Banco] T4 ON T4.[BancoId] = TM1.[BancoId]) WHERE TM1.[ProveedorID] = @ProveedorID ORDER BY TM1.[ProveedorID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N14", "SELECT [ProveedorID] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N15", "INSERT INTO [Proveedor]([ProveedorUsrAlta], [ProveedorUsrActualizacion], [ProveedorFechaAlta], [ProveedorFechaActualizacion], [ProveedorNombre], [ProveedorRazonSocial], [ProveedorContacto], [ProveedorContactoCell], [ProveedorImagen], [ProveedorImagen_GXI], [ProveedorDocIdentidad], [ProveedorSerialComi], [ProveedorTelefono], [ProveedorDireccion], [ProveedorEmail], [ProveedorSitioWeb], [ProveedorAceptoTerminos], [ProveedorPerAltShop], [ProveedorEstado], [ProveedorPagoDefault], [ProveedorPideDoc], [ProveedorUsoInterno], [ProveedorCuentaBancaria], [ProveedorCIU], [ProveedorFreezePrice], [ProveedoresTipoId], [DocumentacionId], [BancoId], [ComercioProductosREnum]) VALUES(@ProveedorUsrAlta, @ProveedorUsrActualizacion, @ProveedorFechaAlta, @ProveedorFechaActualizacion, @ProveedorNombre, @ProveedorRazonSocial, @ProveedorContacto, @ProveedorContactoCell, @ProveedorImagen, @ProveedorImagen_GXI, @ProveedorDocIdentidad, @ProveedorSerialComi, @ProveedorTelefono, @ProveedorDireccion, @ProveedorEmail, @ProveedorSitioWeb, @ProveedorAceptoTerminos, @ProveedorPerAltShop, @ProveedorEstado, @ProveedorPagoDefault, @ProveedorPideDoc, @ProveedorUsoInterno, @ProveedorCuentaBancaria, @ProveedorCIU, @ProveedorFreezePrice, @ProveedoresTipoId, @DocumentacionId, @BancoId, convert(int, 0)); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N16", "UPDATE [Proveedor] SET [ProveedorUsrAlta]=@ProveedorUsrAlta, [ProveedorUsrActualizacion]=@ProveedorUsrActualizacion, [ProveedorFechaAlta]=@ProveedorFechaAlta, [ProveedorFechaActualizacion]=@ProveedorFechaActualizacion, [ProveedorNombre]=@ProveedorNombre, [ProveedorRazonSocial]=@ProveedorRazonSocial, [ProveedorContacto]=@ProveedorContacto, [ProveedorContactoCell]=@ProveedorContactoCell, [ProveedorDocIdentidad]=@ProveedorDocIdentidad, [ProveedorSerialComi]=@ProveedorSerialComi, [ProveedorTelefono]=@ProveedorTelefono, [ProveedorDireccion]=@ProveedorDireccion, [ProveedorEmail]=@ProveedorEmail, [ProveedorSitioWeb]=@ProveedorSitioWeb, [ProveedorAceptoTerminos]=@ProveedorAceptoTerminos, [ProveedorPerAltShop]=@ProveedorPerAltShop, [ProveedorEstado]=@ProveedorEstado, [ProveedorPagoDefault]=@ProveedorPagoDefault, [ProveedorPideDoc]=@ProveedorPideDoc, [ProveedorUsoInterno]=@ProveedorUsoInterno, [ProveedorCuentaBancaria]=@ProveedorCuentaBancaria, [ProveedorCIU]=@ProveedorCIU, [ProveedorFreezePrice]=@ProveedorFreezePrice, [ProveedoresTipoId]=@ProveedoresTipoId, [DocumentacionId]=@DocumentacionId, [BancoId]=@BancoId  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmBC000N16)
           ,new CursorDef("BC000N17", "UPDATE [Proveedor] SET [ProveedorImagen]=@ProveedorImagen, [ProveedorImagen_GXI]=@ProveedorImagen_GXI  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmBC000N17)
           ,new CursorDef("BC000N18", "DELETE FROM [Proveedor]  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmBC000N18)
           ,new CursorDef("BC000N19", "SELECT [ProveedoresTipoNombre] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N20", "SELECT [DocumentacionIcono_GXI], [DocumentacionIcono] FROM [Documentacion] WHERE [DocumentacionId] = @DocumentacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N21", "SELECT [BancoNombre] FROM [Banco] WHERE [BancoId] = @BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N22", "SELECT TOP 1 [PostulacionesId] FROM [Postulaciones] WHERE [PostulacionesProveedorId] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N23", "SELECT TOP 1 [MapeoID] FROM [ListaMapeo] WHERE [STComerciosID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N24", "SELECT TOP 1 [MapeoID] FROM [ListaMapeo] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N25", "SELECT TOP 1 [VincularTrnId] FROM [VincularTrn] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N26", "SELECT TOP 1 [ProfComisionesID], [ProfComisionesRubrosId] FROM [ProfComisionesRubros] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N27", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [STComerciosID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N28", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N29", "SELECT TOP 1 [ProveedorID], [ComercioProductosRubrosID] FROM [ComercioProductosRubros] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N30", "SELECT TOP 1 [Listaid], [ProveedorID], [ProfesionalesId] FROM [ListaAgrupacion] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N31", "SELECT TOP 1 [Listaid], [SecUserId], [ProveedorID] FROM [ListaAgrUserProveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N31,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N32", "SELECT TOP 1 [ComisionesID], [ProveedorID] FROM [ComisionesProveedores] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N32,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N33", "SELECT TOP 1 [ProveedorID], [ProveedorSolicitudesId] FROM [ProveedorSolicitudes] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N33,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N34", "SELECT TM1.[ProveedorID], TM1.[ProveedorUsrAlta], TM1.[ProveedorUsrActualizacion], TM1.[ProveedorFechaAlta], TM1.[ProveedorFechaActualizacion], T2.[ProveedoresTipoNombre], TM1.[ProveedorNombre], TM1.[ProveedorRazonSocial], TM1.[ProveedorContacto], TM1.[ProveedorContactoCell], TM1.[ProveedorImagen_GXI], TM1.[ProveedorDocIdentidad], TM1.[ProveedorSerialComi], TM1.[ProveedorTelefono], TM1.[ProveedorDireccion], TM1.[ProveedorEmail], TM1.[ProveedorSitioWeb], TM1.[ProveedorAceptoTerminos], TM1.[ProveedorPerAltShop], TM1.[ProveedorEstado], TM1.[ProveedorPagoDefault], TM1.[ProveedorPideDoc], T3.[DocumentacionIcono_GXI], TM1.[ProveedorUsoInterno], TM1.[ProveedorCuentaBancaria], T4.[BancoNombre], TM1.[ProveedorCIU], TM1.[ProveedorFreezePrice], TM1.[ProveedoresTipoId], TM1.[DocumentacionId], TM1.[BancoId], TM1.[ProveedorImagen], T3.[DocumentacionIcono] FROM ((([Proveedor] TM1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = TM1.[ProveedoresTipoId]) LEFT JOIN [Documentacion] T3 ON T3.[DocumentacionId] = TM1.[DocumentacionId]) LEFT JOIN [Banco] T4 ON T4.[BancoId] = TM1.[BancoId]) WHERE TM1.[ProveedorID] = @ProveedorID ORDER BY TM1.[ProveedorID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N34,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N35", "SELECT T1.[ProveedorID], T1.[ProveedorComisionID], T2.[RubrosImagen_GXI], T4.[InventarioNombre], T5.[EstadosGenericosNombre], T4.[InventarioPrecioFinal], T1.[ProveedorComisionFP], T1.[ProveedorComisionFPF], T1.[ProveedorComisionTipo], T1.[ProveedorComision], T1.[ProveedorComisionAccion], T1.[RubrosId], T1.[MedidasID], T1.[InventarioId], T3.[MonedaId], T4.[EstadosTipo], T4.[EstadosGenericosId], T2.[RubrosImagen] FROM (((([ProveedorComision] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) LEFT JOIN [Inventario] T4 ON T4.[RubrosId] = T1.[RubrosId] AND T4.[MedidasID] = T1.[MedidasID] AND T4.[InventarioId] = T1.[InventarioId]) LEFT JOIN [EstadosGenericos] T5 ON T5.[EstadosTipo] = T4.[EstadosTipo] AND T5.[EstadosGenericosId] = T4.[EstadosGenericosId]) WHERE T1.[ProveedorID] = @ProveedorID and T1.[ProveedorComisionID] = @ProveedorComisionID ORDER BY T1.[ProveedorID], T1.[ProveedorComisionID]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N35,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N36", "SELECT [ProveedorID], [ProveedorComisionID] FROM [ProveedorComision] WHERE [ProveedorID] = @ProveedorID AND [ProveedorComisionID] = @ProveedorComisionID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N36,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N37", "INSERT INTO [ProveedorComision]([ProveedorID], [ProveedorComisionID], [ProveedorComisionFP], [ProveedorComisionFPF], [ProveedorComisionTipo], [ProveedorComision], [ProveedorComisionAccion], [RubrosId], [MedidasID], [InventarioId]) VALUES(@ProveedorID, @ProveedorComisionID, @ProveedorComisionFP, @ProveedorComisionFPF, @ProveedorComisionTipo, @ProveedorComision, @ProveedorComisionAccion, @RubrosId, @MedidasID, @InventarioId)", GxErrorMask.GX_NOMASK,prmBC000N37)
           ,new CursorDef("BC000N38", "UPDATE [ProveedorComision] SET [ProveedorComisionFP]=@ProveedorComisionFP, [ProveedorComisionFPF]=@ProveedorComisionFPF, [ProveedorComisionTipo]=@ProveedorComisionTipo, [ProveedorComision]=@ProveedorComision, [ProveedorComisionAccion]=@ProveedorComisionAccion, [RubrosId]=@RubrosId, [MedidasID]=@MedidasID, [InventarioId]=@InventarioId  WHERE [ProveedorID] = @ProveedorID AND [ProveedorComisionID] = @ProveedorComisionID", GxErrorMask.GX_NOMASK,prmBC000N38)
           ,new CursorDef("BC000N39", "DELETE FROM [ProveedorComision]  WHERE [ProveedorID] = @ProveedorID AND [ProveedorComisionID] = @ProveedorComisionID", GxErrorMask.GX_NOMASK,prmBC000N39)
           ,new CursorDef("BC000N40", "SELECT [RubrosImagen_GXI], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N40,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N41", "SELECT [MonedaId] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N41,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N42", "SELECT [InventarioNombre], [InventarioPrecioFinal], [EstadosTipo], [EstadosGenericosId] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N42,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N43", "SELECT [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N43,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N44", "SELECT T1.[ProveedorID], T1.[ProveedorComisionID], T2.[RubrosImagen_GXI], T4.[InventarioNombre], T5.[EstadosGenericosNombre], T4.[InventarioPrecioFinal], T1.[ProveedorComisionFP], T1.[ProveedorComisionFPF], T1.[ProveedorComisionTipo], T1.[ProveedorComision], T1.[ProveedorComisionAccion], T1.[RubrosId], T1.[MedidasID], T1.[InventarioId], T3.[MonedaId], T4.[EstadosTipo], T4.[EstadosGenericosId], T2.[RubrosImagen] FROM (((([ProveedorComision] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) LEFT JOIN [Inventario] T4 ON T4.[RubrosId] = T1.[RubrosId] AND T4.[MedidasID] = T1.[MedidasID] AND T4.[InventarioId] = T1.[InventarioId]) LEFT JOIN [EstadosGenericos] T5 ON T5.[EstadosTipo] = T4.[EstadosTipo] AND T5.[EstadosGenericosId] = T4.[EstadosGenericosId]) WHERE T1.[ProveedorID] = @ProveedorID ORDER BY T1.[ProveedorID], T1.[ProveedorComisionID]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N44,11, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 1);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
              ((string[]) buf[8])[0] = rslt.getString(7, 1);
              ((short[]) buf[9])[0] = rslt.getShort(8);
              ((long[]) buf[10])[0] = rslt.getLong(9);
              ((long[]) buf[11])[0] = rslt.getLong(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 1);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
              ((string[]) buf[8])[0] = rslt.getString(7, 1);
              ((short[]) buf[9])[0] = rslt.getShort(8);
              ((long[]) buf[10])[0] = rslt.getLong(9);
              ((long[]) buf[11])[0] = rslt.getLong(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 80);
              ((string[]) buf[10])[0] = rslt.getString(7, 25);
              ((bool[]) buf[11])[0] = rslt.wasNull(7);
              ((string[]) buf[12])[0] = rslt.getString(8, 128);
              ((bool[]) buf[13])[0] = rslt.wasNull(8);
              ((string[]) buf[14])[0] = rslt.getString(9, 20);
              ((bool[]) buf[15])[0] = rslt.wasNull(9);
              ((string[]) buf[16])[0] = rslt.getMultimediaUri(10);
              ((bool[]) buf[17])[0] = rslt.wasNull(10);
              ((string[]) buf[18])[0] = rslt.getString(11, 25);
              ((short[]) buf[19])[0] = rslt.getShort(12);
              ((string[]) buf[20])[0] = rslt.getString(13, 20);
              ((bool[]) buf[21])[0] = rslt.wasNull(13);
              ((string[]) buf[22])[0] = rslt.getVarchar(14);
              ((bool[]) buf[23])[0] = rslt.wasNull(14);
              ((string[]) buf[24])[0] = rslt.getVarchar(15);
              ((bool[]) buf[25])[0] = rslt.wasNull(15);
              ((string[]) buf[26])[0] = rslt.getString(16, 128);
              ((bool[]) buf[27])[0] = rslt.wasNull(16);
              ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(17);
              ((bool[]) buf[29])[0] = rslt.wasNull(17);
              ((string[]) buf[30])[0] = rslt.getString(18, 1);
              ((bool[]) buf[31])[0] = rslt.wasNull(18);
              ((string[]) buf[32])[0] = rslt.getString(19, 3);
              ((string[]) buf[33])[0] = rslt.getString(20, 1);
              ((string[]) buf[34])[0] = rslt.getString(21, 1);
              ((bool[]) buf[35])[0] = rslt.wasNull(21);
              ((string[]) buf[36])[0] = rslt.getString(22, 1);
              ((bool[]) buf[37])[0] = rslt.wasNull(22);
              ((string[]) buf[38])[0] = rslt.getString(23, 50);
              ((bool[]) buf[39])[0] = rslt.wasNull(23);
              ((bool[]) buf[40])[0] = rslt.getBool(24);
              ((bool[]) buf[41])[0] = rslt.getBool(25);
              ((bool[]) buf[42])[0] = rslt.wasNull(25);
              ((long[]) buf[43])[0] = rslt.getLong(26);
              ((long[]) buf[44])[0] = rslt.getLong(27);
              ((bool[]) buf[45])[0] = rslt.wasNull(27);
              ((long[]) buf[46])[0] = rslt.getLong(28);
              ((bool[]) buf[47])[0] = rslt.wasNull(28);
              ((string[]) buf[48])[0] = rslt.getMultimediaFile(29, rslt.getVarchar(10));
              ((bool[]) buf[49])[0] = rslt.wasNull(29);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 80);
              ((string[]) buf[10])[0] = rslt.getString(7, 25);
              ((bool[]) buf[11])[0] = rslt.wasNull(7);
              ((string[]) buf[12])[0] = rslt.getString(8, 128);
              ((bool[]) buf[13])[0] = rslt.wasNull(8);
              ((string[]) buf[14])[0] = rslt.getString(9, 20);
              ((bool[]) buf[15])[0] = rslt.wasNull(9);
              ((string[]) buf[16])[0] = rslt.getMultimediaUri(10);
              ((bool[]) buf[17])[0] = rslt.wasNull(10);
              ((string[]) buf[18])[0] = rslt.getString(11, 25);
              ((short[]) buf[19])[0] = rslt.getShort(12);
              ((string[]) buf[20])[0] = rslt.getString(13, 20);
              ((bool[]) buf[21])[0] = rslt.wasNull(13);
              ((string[]) buf[22])[0] = rslt.getVarchar(14);
              ((bool[]) buf[23])[0] = rslt.wasNull(14);
              ((string[]) buf[24])[0] = rslt.getVarchar(15);
              ((bool[]) buf[25])[0] = rslt.wasNull(15);
              ((string[]) buf[26])[0] = rslt.getString(16, 128);
              ((bool[]) buf[27])[0] = rslt.wasNull(16);
              ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(17);
              ((bool[]) buf[29])[0] = rslt.wasNull(17);
              ((string[]) buf[30])[0] = rslt.getString(18, 1);
              ((bool[]) buf[31])[0] = rslt.wasNull(18);
              ((string[]) buf[32])[0] = rslt.getString(19, 3);
              ((string[]) buf[33])[0] = rslt.getString(20, 1);
              ((string[]) buf[34])[0] = rslt.getString(21, 1);
              ((bool[]) buf[35])[0] = rslt.wasNull(21);
              ((string[]) buf[36])[0] = rslt.getString(22, 1);
              ((bool[]) buf[37])[0] = rslt.wasNull(22);
              ((string[]) buf[38])[0] = rslt.getString(23, 50);
              ((bool[]) buf[39])[0] = rslt.wasNull(23);
              ((bool[]) buf[40])[0] = rslt.getBool(24);
              ((bool[]) buf[41])[0] = rslt.getBool(25);
              ((bool[]) buf[42])[0] = rslt.wasNull(25);
              ((long[]) buf[43])[0] = rslt.getLong(26);
              ((long[]) buf[44])[0] = rslt.getLong(27);
              ((bool[]) buf[45])[0] = rslt.wasNull(27);
              ((long[]) buf[46])[0] = rslt.getLong(28);
              ((bool[]) buf[47])[0] = rslt.wasNull(28);
              ((string[]) buf[48])[0] = rslt.getMultimediaFile(29, rslt.getVarchar(10));
              ((bool[]) buf[49])[0] = rslt.wasNull(29);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 120);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 120);
              ((string[]) buf[10])[0] = rslt.getString(7, 80);
              ((string[]) buf[11])[0] = rslt.getString(8, 25);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              ((string[]) buf[13])[0] = rslt.getString(9, 128);
              ((bool[]) buf[14])[0] = rslt.wasNull(9);
              ((string[]) buf[15])[0] = rslt.getString(10, 20);
              ((bool[]) buf[16])[0] = rslt.wasNull(10);
              ((string[]) buf[17])[0] = rslt.getMultimediaUri(11);
              ((bool[]) buf[18])[0] = rslt.wasNull(11);
              ((string[]) buf[19])[0] = rslt.getString(12, 25);
              ((short[]) buf[20])[0] = rslt.getShort(13);
              ((string[]) buf[21])[0] = rslt.getString(14, 20);
              ((bool[]) buf[22])[0] = rslt.wasNull(14);
              ((string[]) buf[23])[0] = rslt.getVarchar(15);
              ((bool[]) buf[24])[0] = rslt.wasNull(15);
              ((string[]) buf[25])[0] = rslt.getVarchar(16);
              ((bool[]) buf[26])[0] = rslt.wasNull(16);
              ((string[]) buf[27])[0] = rslt.getString(17, 128);
              ((bool[]) buf[28])[0] = rslt.wasNull(17);
              ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(18);
              ((bool[]) buf[30])[0] = rslt.wasNull(18);
              ((string[]) buf[31])[0] = rslt.getString(19, 1);
              ((bool[]) buf[32])[0] = rslt.wasNull(19);
              ((string[]) buf[33])[0] = rslt.getString(20, 3);
              ((string[]) buf[34])[0] = rslt.getString(21, 1);
              ((string[]) buf[35])[0] = rslt.getString(22, 1);
              ((bool[]) buf[36])[0] = rslt.wasNull(22);
              ((string[]) buf[37])[0] = rslt.getMultimediaUri(23);
              ((string[]) buf[38])[0] = rslt.getString(24, 1);
              ((bool[]) buf[39])[0] = rslt.wasNull(24);
              ((string[]) buf[40])[0] = rslt.getString(25, 50);
              ((bool[]) buf[41])[0] = rslt.wasNull(25);
              ((string[]) buf[42])[0] = rslt.getString(26, 80);
              ((bool[]) buf[43])[0] = rslt.getBool(27);
              ((bool[]) buf[44])[0] = rslt.getBool(28);
              ((bool[]) buf[45])[0] = rslt.wasNull(28);
              ((long[]) buf[46])[0] = rslt.getLong(29);
              ((long[]) buf[47])[0] = rslt.getLong(30);
              ((bool[]) buf[48])[0] = rslt.wasNull(30);
              ((long[]) buf[49])[0] = rslt.getLong(31);
              ((bool[]) buf[50])[0] = rslt.wasNull(31);
              ((string[]) buf[51])[0] = rslt.getMultimediaFile(32, rslt.getVarchar(11));
              ((bool[]) buf[52])[0] = rslt.wasNull(32);
              ((string[]) buf[53])[0] = rslt.getMultimediaFile(33, rslt.getVarchar(23));
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 120);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 22 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 23 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 26 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 29 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 31 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 32 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 120);
              ((string[]) buf[10])[0] = rslt.getString(7, 80);
              ((string[]) buf[11])[0] = rslt.getString(8, 25);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              ((string[]) buf[13])[0] = rslt.getString(9, 128);
              ((bool[]) buf[14])[0] = rslt.wasNull(9);
              ((string[]) buf[15])[0] = rslt.getString(10, 20);
              ((bool[]) buf[16])[0] = rslt.wasNull(10);
              ((string[]) buf[17])[0] = rslt.getMultimediaUri(11);
              ((bool[]) buf[18])[0] = rslt.wasNull(11);
              ((string[]) buf[19])[0] = rslt.getString(12, 25);
              ((short[]) buf[20])[0] = rslt.getShort(13);
              ((string[]) buf[21])[0] = rslt.getString(14, 20);
              ((bool[]) buf[22])[0] = rslt.wasNull(14);
              ((string[]) buf[23])[0] = rslt.getVarchar(15);
              ((bool[]) buf[24])[0] = rslt.wasNull(15);
              ((string[]) buf[25])[0] = rslt.getVarchar(16);
              ((bool[]) buf[26])[0] = rslt.wasNull(16);
              ((string[]) buf[27])[0] = rslt.getString(17, 128);
              ((bool[]) buf[28])[0] = rslt.wasNull(17);
              ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(18);
              ((bool[]) buf[30])[0] = rslt.wasNull(18);
              ((string[]) buf[31])[0] = rslt.getString(19, 1);
              ((bool[]) buf[32])[0] = rslt.wasNull(19);
              ((string[]) buf[33])[0] = rslt.getString(20, 3);
              ((string[]) buf[34])[0] = rslt.getString(21, 1);
              ((string[]) buf[35])[0] = rslt.getString(22, 1);
              ((bool[]) buf[36])[0] = rslt.wasNull(22);
              ((string[]) buf[37])[0] = rslt.getMultimediaUri(23);
              ((string[]) buf[38])[0] = rslt.getString(24, 1);
              ((bool[]) buf[39])[0] = rslt.wasNull(24);
              ((string[]) buf[40])[0] = rslt.getString(25, 50);
              ((bool[]) buf[41])[0] = rslt.wasNull(25);
              ((string[]) buf[42])[0] = rslt.getString(26, 80);
              ((bool[]) buf[43])[0] = rslt.getBool(27);
              ((bool[]) buf[44])[0] = rslt.getBool(28);
              ((bool[]) buf[45])[0] = rslt.wasNull(28);
              ((long[]) buf[46])[0] = rslt.getLong(29);
              ((long[]) buf[47])[0] = rslt.getLong(30);
              ((bool[]) buf[48])[0] = rslt.wasNull(30);
              ((long[]) buf[49])[0] = rslt.getLong(31);
              ((bool[]) buf[50])[0] = rslt.wasNull(31);
              ((string[]) buf[51])[0] = rslt.getMultimediaFile(32, rslt.getVarchar(11));
              ((bool[]) buf[52])[0] = rslt.wasNull(32);
              ((string[]) buf[53])[0] = rslt.getMultimediaFile(33, rslt.getVarchar(23));
              return;
           case 33 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getString(9, 1);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
              ((string[]) buf[12])[0] = rslt.getString(11, 1);
              ((short[]) buf[13])[0] = rslt.getShort(12);
              ((long[]) buf[14])[0] = rslt.getLong(13);
              ((long[]) buf[15])[0] = rslt.getLong(14);
              ((bool[]) buf[16])[0] = rslt.wasNull(14);
              ((short[]) buf[17])[0] = rslt.getShort(15);
              ((string[]) buf[18])[0] = rslt.getString(16, 3);
              ((int[]) buf[19])[0] = rslt.getInt(17);
              ((string[]) buf[20])[0] = rslt.getMultimediaFile(18, rslt.getVarchar(3));
              return;
           case 34 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 38 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 39 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 40 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 41 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 42 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getString(9, 1);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
              ((string[]) buf[12])[0] = rslt.getString(11, 1);
              ((short[]) buf[13])[0] = rslt.getShort(12);
              ((long[]) buf[14])[0] = rslt.getLong(13);
              ((long[]) buf[15])[0] = rslt.getLong(14);
              ((bool[]) buf[16])[0] = rslt.wasNull(14);
              ((short[]) buf[17])[0] = rslt.getShort(15);
              ((string[]) buf[18])[0] = rslt.getString(16, 3);
              ((int[]) buf[19])[0] = rslt.getInt(17);
              ((string[]) buf[20])[0] = rslt.getMultimediaFile(18, rslt.getVarchar(3));
              return;
     }
  }

}

}
