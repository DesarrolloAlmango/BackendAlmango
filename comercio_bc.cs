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
   public class comercio_bc : GXHttpHandler, IGxSilentTrn
   {
      public comercio_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comercio_bc( IGxContext context )
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
         ReadRow1B28( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1B28( ) ;
         standaloneModal( ) ;
         AddRow1B28( ) ;
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
            E111B2 ();
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

      protected void CONFIRM_1B0( )
      {
         BeforeValidate1B28( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1B28( ) ;
            }
            else
            {
               CheckExtendedTable1B28( ) ;
               if ( AnyError == 0 )
               {
                  ZM1B28( 8) ;
                  ZM1B28( 9) ;
               }
               CloseExtendedTableCursors1B28( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode28 = Gx_mode;
            CONFIRM_1B52( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode28;
            }
            /* Restore parent mode. */
            Gx_mode = sMode28;
         }
      }

      protected void CONFIRM_1B52( )
      {
         nGXsfl_52_idx = 0;
         while ( nGXsfl_52_idx < bcComercio.gxTpr_Solicitudes.Count )
         {
            ReadRow1B52( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound52 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_52 != 0 ) )
            {
               GetKey1B52( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound52 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate1B52( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1B52( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors1B52( ) ;
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
                  if ( RcdFound52 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey1B52( ) ;
                        Load1B52( ) ;
                        BeforeValidate1B52( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1B52( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_52 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate1B52( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1B52( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors1B52( ) ;
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
               VarsToRow52( ((SdtComercio_Solicitudes)bcComercio.gxTpr_Solicitudes.Item(nGXsfl_52_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E121B2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV16WWPContext) ;
         AV7IsAuthorized = true;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComercio_Insert", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComercio_Update", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComercio_Delete", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
         }
         if ( ! AV7IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV22Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV8TrnContext.FromXml(AV9WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Transactionname, AV22Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV23GXV1 = 1;
            while ( AV23GXV1 <= AV8TrnContext.gxTpr_Attributes.Count )
            {
               AV11TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV8TrnContext.gxTpr_Attributes.Item(AV23GXV1));
               if ( StringUtil.StrCmp(AV11TrnContextAtt.gxTpr_Attributename, "ProveedoresTipoId") == 0 )
               {
                  AV10Insert_ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( AV11TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV11TrnContextAtt.gxTpr_Attributename, "BancoId") == 0 )
               {
                  AV18Insert_BancoId = (long)(Math.Round(NumberUtil.Val( AV11TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV23GXV1 = (int)(AV23GXV1+1);
            }
         }
      }

      protected void E111B2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1B28( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z282ProveedorNombre = A282ProveedorNombre;
            Z338ProveedorDocIdentidad = A338ProveedorDocIdentidad;
            Z430ProveedorTelefono = A430ProveedorTelefono;
            Z431ProveedorDireccion = A431ProveedorDireccion;
            Z433ProveedorEmail = A433ProveedorEmail;
            Z344ProveedorEstado = A344ProveedorEstado;
            Z682ProveedorRazonSocial = A682ProveedorRazonSocial;
            Z683ProveedorContacto = A683ProveedorContacto;
            Z684ProveedorContactoCell = A684ProveedorContactoCell;
            Z687ProveedorCuentaBancaria = A687ProveedorCuentaBancaria;
            Z978ProveedorCIU = A978ProveedorCIU;
            Z151ProveedoresTipoId = A151ProveedoresTipoId;
            Z673BancoId = A673BancoId;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z278ProveedoresTipoNombre = A278ProveedoresTipoNombre;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z674BancoNombre = A674BancoNombre;
         }
         if ( GX_JID == -7 )
         {
            Z133ProveedorID = A133ProveedorID;
            Z282ProveedorNombre = A282ProveedorNombre;
            Z338ProveedorDocIdentidad = A338ProveedorDocIdentidad;
            Z430ProveedorTelefono = A430ProveedorTelefono;
            Z431ProveedorDireccion = A431ProveedorDireccion;
            Z433ProveedorEmail = A433ProveedorEmail;
            Z344ProveedorEstado = A344ProveedorEstado;
            Z682ProveedorRazonSocial = A682ProveedorRazonSocial;
            Z683ProveedorContacto = A683ProveedorContacto;
            Z684ProveedorContactoCell = A684ProveedorContactoCell;
            Z432ProveedorImagen = A432ProveedorImagen;
            Z40000ProveedorImagen_GXI = A40000ProveedorImagen_GXI;
            Z687ProveedorCuentaBancaria = A687ProveedorCuentaBancaria;
            Z978ProveedorCIU = A978ProveedorCIU;
            Z151ProveedoresTipoId = A151ProveedoresTipoId;
            Z673BancoId = A673BancoId;
            Z278ProveedoresTipoNombre = A278ProveedoresTipoNombre;
            Z674BancoNombre = A674BancoNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A978ProveedorCIU) && ( Gx_BScreen == 0 ) )
         {
            A978ProveedorCIU = false;
         }
      }

      protected void Load1B28( )
      {
         /* Using cursor BC001B8 */
         pr_default.execute(6, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound28 = 1;
            A278ProveedoresTipoNombre = BC001B8_A278ProveedoresTipoNombre[0];
            A282ProveedorNombre = BC001B8_A282ProveedorNombre[0];
            A338ProveedorDocIdentidad = BC001B8_A338ProveedorDocIdentidad[0];
            A430ProveedorTelefono = BC001B8_A430ProveedorTelefono[0];
            n430ProveedorTelefono = BC001B8_n430ProveedorTelefono[0];
            A431ProveedorDireccion = BC001B8_A431ProveedorDireccion[0];
            n431ProveedorDireccion = BC001B8_n431ProveedorDireccion[0];
            A433ProveedorEmail = BC001B8_A433ProveedorEmail[0];
            n433ProveedorEmail = BC001B8_n433ProveedorEmail[0];
            A344ProveedorEstado = BC001B8_A344ProveedorEstado[0];
            A682ProveedorRazonSocial = BC001B8_A682ProveedorRazonSocial[0];
            n682ProveedorRazonSocial = BC001B8_n682ProveedorRazonSocial[0];
            A683ProveedorContacto = BC001B8_A683ProveedorContacto[0];
            n683ProveedorContacto = BC001B8_n683ProveedorContacto[0];
            A684ProveedorContactoCell = BC001B8_A684ProveedorContactoCell[0];
            n684ProveedorContactoCell = BC001B8_n684ProveedorContactoCell[0];
            A40000ProveedorImagen_GXI = BC001B8_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = BC001B8_n40000ProveedorImagen_GXI[0];
            A687ProveedorCuentaBancaria = BC001B8_A687ProveedorCuentaBancaria[0];
            n687ProveedorCuentaBancaria = BC001B8_n687ProveedorCuentaBancaria[0];
            A674BancoNombre = BC001B8_A674BancoNombre[0];
            A978ProveedorCIU = BC001B8_A978ProveedorCIU[0];
            A151ProveedoresTipoId = BC001B8_A151ProveedoresTipoId[0];
            A673BancoId = BC001B8_A673BancoId[0];
            n673BancoId = BC001B8_n673BancoId[0];
            A432ProveedorImagen = BC001B8_A432ProveedorImagen[0];
            n432ProveedorImagen = BC001B8_n432ProveedorImagen[0];
            ZM1B28( -7) ;
         }
         pr_default.close(6);
         OnLoadActions1B28( ) ;
      }

      protected void OnLoadActions1B28( )
      {
         AV22Pgmname = "Comercio_BC";
      }

      protected void CheckExtendedTable1B28( )
      {
         standaloneModal( ) ;
         AV22Pgmname = "Comercio_BC";
         /* Using cursor BC001B6 */
         pr_default.execute(4, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
         }
         A278ProveedoresTipoNombre = BC001B6_A278ProveedoresTipoNombre[0];
         pr_default.close(4);
         if ( ! ( GxRegex.IsMatch(A433ProveedorEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A433ProveedorEmail)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A344ProveedorEstado, "BLO") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Proveedor Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC001B7 */
         pr_default.execute(5, new Object[] {n673BancoId, A673BancoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A673BancoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Banco", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "BANCOID");
               AnyError = 1;
            }
         }
         A674BancoNombre = BC001B7_A674BancoNombre[0];
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors1B28( )
      {
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1B28( )
      {
         /* Using cursor BC001B9 */
         pr_default.execute(7, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001B5 */
         pr_default.execute(3, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1B28( 7) ;
            RcdFound28 = 1;
            A133ProveedorID = BC001B5_A133ProveedorID[0];
            n133ProveedorID = BC001B5_n133ProveedorID[0];
            A282ProveedorNombre = BC001B5_A282ProveedorNombre[0];
            A338ProveedorDocIdentidad = BC001B5_A338ProveedorDocIdentidad[0];
            A430ProveedorTelefono = BC001B5_A430ProveedorTelefono[0];
            n430ProveedorTelefono = BC001B5_n430ProveedorTelefono[0];
            A431ProveedorDireccion = BC001B5_A431ProveedorDireccion[0];
            n431ProveedorDireccion = BC001B5_n431ProveedorDireccion[0];
            A433ProveedorEmail = BC001B5_A433ProveedorEmail[0];
            n433ProveedorEmail = BC001B5_n433ProveedorEmail[0];
            A344ProveedorEstado = BC001B5_A344ProveedorEstado[0];
            A682ProveedorRazonSocial = BC001B5_A682ProveedorRazonSocial[0];
            n682ProveedorRazonSocial = BC001B5_n682ProveedorRazonSocial[0];
            A683ProveedorContacto = BC001B5_A683ProveedorContacto[0];
            n683ProveedorContacto = BC001B5_n683ProveedorContacto[0];
            A684ProveedorContactoCell = BC001B5_A684ProveedorContactoCell[0];
            n684ProveedorContactoCell = BC001B5_n684ProveedorContactoCell[0];
            A40000ProveedorImagen_GXI = BC001B5_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = BC001B5_n40000ProveedorImagen_GXI[0];
            A687ProveedorCuentaBancaria = BC001B5_A687ProveedorCuentaBancaria[0];
            n687ProveedorCuentaBancaria = BC001B5_n687ProveedorCuentaBancaria[0];
            A978ProveedorCIU = BC001B5_A978ProveedorCIU[0];
            A151ProveedoresTipoId = BC001B5_A151ProveedoresTipoId[0];
            A673BancoId = BC001B5_A673BancoId[0];
            n673BancoId = BC001B5_n673BancoId[0];
            A432ProveedorImagen = BC001B5_A432ProveedorImagen[0];
            n432ProveedorImagen = BC001B5_n432ProveedorImagen[0];
            Z133ProveedorID = A133ProveedorID;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1B28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey1B28( ) ;
            }
            Gx_mode = sMode28;
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey1B28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode28;
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey1B28( ) ;
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
         CONFIRM_1B0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1B28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001B4 */
            pr_default.execute(2, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proveedor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z282ProveedorNombre, BC001B4_A282ProveedorNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z338ProveedorDocIdentidad, BC001B4_A338ProveedorDocIdentidad[0]) != 0 ) || ( StringUtil.StrCmp(Z430ProveedorTelefono, BC001B4_A430ProveedorTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z431ProveedorDireccion, BC001B4_A431ProveedorDireccion[0]) != 0 ) || ( StringUtil.StrCmp(Z433ProveedorEmail, BC001B4_A433ProveedorEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z344ProveedorEstado, BC001B4_A344ProveedorEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z682ProveedorRazonSocial, BC001B4_A682ProveedorRazonSocial[0]) != 0 ) || ( StringUtil.StrCmp(Z683ProveedorContacto, BC001B4_A683ProveedorContacto[0]) != 0 ) || ( StringUtil.StrCmp(Z684ProveedorContactoCell, BC001B4_A684ProveedorContactoCell[0]) != 0 ) || ( StringUtil.StrCmp(Z687ProveedorCuentaBancaria, BC001B4_A687ProveedorCuentaBancaria[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z978ProveedorCIU != BC001B4_A978ProveedorCIU[0] ) || ( Z151ProveedoresTipoId != BC001B4_A151ProveedoresTipoId[0] ) || ( Z673BancoId != BC001B4_A673BancoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Proveedor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1B28( )
      {
         BeforeValidate1B28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1B28( 0) ;
            CheckOptimisticConcurrency1B28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1B28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001B10 */
                     pr_default.execute(8, new Object[] {A282ProveedorNombre, A338ProveedorDocIdentidad, n430ProveedorTelefono, A430ProveedorTelefono, n431ProveedorDireccion, A431ProveedorDireccion, n433ProveedorEmail, A433ProveedorEmail, A344ProveedorEstado, n682ProveedorRazonSocial, A682ProveedorRazonSocial, n683ProveedorContacto, A683ProveedorContacto, n684ProveedorContactoCell, A684ProveedorContactoCell, n432ProveedorImagen, A432ProveedorImagen, n40000ProveedorImagen_GXI, A40000ProveedorImagen_GXI, n687ProveedorCuentaBancaria, A687ProveedorCuentaBancaria, A978ProveedorCIU, A151ProveedoresTipoId, n673BancoId, A673BancoId});
                     A133ProveedorID = BC001B10_A133ProveedorID[0];
                     n133ProveedorID = BC001B10_n133ProveedorID[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Proveedor");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1B28( ) ;
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
               Load1B28( ) ;
            }
            EndLevel1B28( ) ;
         }
         CloseExtendedTableCursors1B28( ) ;
      }

      protected void Update1B28( )
      {
         BeforeValidate1B28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1B28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001B11 */
                     pr_default.execute(9, new Object[] {A282ProveedorNombre, A338ProveedorDocIdentidad, n430ProveedorTelefono, A430ProveedorTelefono, n431ProveedorDireccion, A431ProveedorDireccion, n433ProveedorEmail, A433ProveedorEmail, A344ProveedorEstado, n682ProveedorRazonSocial, A682ProveedorRazonSocial, n683ProveedorContacto, A683ProveedorContacto, n684ProveedorContactoCell, A684ProveedorContactoCell, n687ProveedorCuentaBancaria, A687ProveedorCuentaBancaria, A978ProveedorCIU, A151ProveedoresTipoId, n673BancoId, A673BancoId, n133ProveedorID, A133ProveedorID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Proveedor");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proveedor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1B28( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1B28( ) ;
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
            EndLevel1B28( ) ;
         }
         CloseExtendedTableCursors1B28( ) ;
      }

      protected void DeferredUpdate1B28( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC001B12 */
            pr_default.execute(10, new Object[] {n432ProveedorImagen, A432ProveedorImagen, n40000ProveedorImagen_GXI, A40000ProveedorImagen_GXI, n133ProveedorID, A133ProveedorID});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("Proveedor");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1B28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1B28( ) ;
            AfterConfirm1B28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1B28( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart1B52( ) ;
                  while ( RcdFound52 != 0 )
                  {
                     getByPrimaryKey1B52( ) ;
                     Delete1B52( ) ;
                     ScanKeyNext1B52( ) ;
                  }
                  ScanKeyEnd1B52( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001B13 */
                     pr_default.execute(11, new Object[] {n133ProveedorID, A133ProveedorID});
                     pr_default.close(11);
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
         EndLevel1B28( ) ;
         Gx_mode = sMode28;
      }

      protected void OnDeleteControls1B28( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV22Pgmname = "Comercio_BC";
            /* Using cursor BC001B14 */
            pr_default.execute(12, new Object[] {A151ProveedoresTipoId});
            A278ProveedoresTipoNombre = BC001B14_A278ProveedoresTipoNombre[0];
            pr_default.close(12);
            /* Using cursor BC001B15 */
            pr_default.execute(13, new Object[] {n673BancoId, A673BancoId});
            A674BancoNombre = BC001B15_A674BancoNombre[0];
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001B16 */
            pr_default.execute(14, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Postulaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor BC001B17 */
            pr_default.execute(15, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Lista Mapeo", "")+" ("+context.GetMessage( "Comercios SubTipo", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor BC001B18 */
            pr_default.execute(16, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Lista Mapeo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor BC001B19 */
            pr_default.execute(17, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Vincular Trn", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor BC001B20 */
            pr_default.execute(18, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor BC001B21 */
            pr_default.execute(19, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")+" ("+context.GetMessage( "Comercios SubTipo", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor BC001B22 */
            pr_default.execute(20, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor BC001B23 */
            pr_default.execute(21, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor BC001B24 */
            pr_default.execute(22, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agrupacion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor BC001B25 */
            pr_default.execute(23, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Proveedor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor BC001B26 */
            pr_default.execute(24, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Comercio | Proveedor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor BC001B27 */
            pr_default.execute(25, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Comisiones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
         }
      }

      protected void ProcessNestedLevel1B52( )
      {
         nGXsfl_52_idx = 0;
         while ( nGXsfl_52_idx < bcComercio.gxTpr_Solicitudes.Count )
         {
            ReadRow1B52( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound52 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_52 != 0 ) )
            {
               standaloneNotModal1B52( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert1B52( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete1B52( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update1B52( ) ;
                  }
               }
            }
            KeyVarsToRow52( ((SdtComercio_Solicitudes)bcComercio.gxTpr_Solicitudes.Item(nGXsfl_52_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_52_idx = 0;
            while ( nGXsfl_52_idx < bcComercio.gxTpr_Solicitudes.Count )
            {
               ReadRow1B52( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound52 == 0 )
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
                  bcComercio.gxTpr_Solicitudes.RemoveElement(nGXsfl_52_idx);
                  nGXsfl_52_idx = (int)(nGXsfl_52_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey1B52( ) ;
                  VarsToRow52( ((SdtComercio_Solicitudes)bcComercio.gxTpr_Solicitudes.Item(nGXsfl_52_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1B52( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_52 = 0;
         nIsMod_52 = 0;
      }

      protected void ProcessLevel1B28( )
      {
         /* Save parent mode. */
         sMode28 = Gx_mode;
         ProcessNestedLevel1B52( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode28;
         /* ' Update level parameters */
      }

      protected void EndLevel1B28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1B28( ) ;
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

      public void ScanKeyStart1B28( )
      {
         /* Scan By routine */
         /* Using cursor BC001B28 */
         pr_default.execute(26, new Object[] {n133ProveedorID, A133ProveedorID});
         RcdFound28 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound28 = 1;
            A133ProveedorID = BC001B28_A133ProveedorID[0];
            n133ProveedorID = BC001B28_n133ProveedorID[0];
            A278ProveedoresTipoNombre = BC001B28_A278ProveedoresTipoNombre[0];
            A282ProveedorNombre = BC001B28_A282ProveedorNombre[0];
            A338ProveedorDocIdentidad = BC001B28_A338ProveedorDocIdentidad[0];
            A430ProveedorTelefono = BC001B28_A430ProveedorTelefono[0];
            n430ProveedorTelefono = BC001B28_n430ProveedorTelefono[0];
            A431ProveedorDireccion = BC001B28_A431ProveedorDireccion[0];
            n431ProveedorDireccion = BC001B28_n431ProveedorDireccion[0];
            A433ProveedorEmail = BC001B28_A433ProveedorEmail[0];
            n433ProveedorEmail = BC001B28_n433ProveedorEmail[0];
            A344ProveedorEstado = BC001B28_A344ProveedorEstado[0];
            A682ProveedorRazonSocial = BC001B28_A682ProveedorRazonSocial[0];
            n682ProveedorRazonSocial = BC001B28_n682ProveedorRazonSocial[0];
            A683ProveedorContacto = BC001B28_A683ProveedorContacto[0];
            n683ProveedorContacto = BC001B28_n683ProveedorContacto[0];
            A684ProveedorContactoCell = BC001B28_A684ProveedorContactoCell[0];
            n684ProveedorContactoCell = BC001B28_n684ProveedorContactoCell[0];
            A40000ProveedorImagen_GXI = BC001B28_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = BC001B28_n40000ProveedorImagen_GXI[0];
            A687ProveedorCuentaBancaria = BC001B28_A687ProveedorCuentaBancaria[0];
            n687ProveedorCuentaBancaria = BC001B28_n687ProveedorCuentaBancaria[0];
            A674BancoNombre = BC001B28_A674BancoNombre[0];
            A978ProveedorCIU = BC001B28_A978ProveedorCIU[0];
            A151ProveedoresTipoId = BC001B28_A151ProveedoresTipoId[0];
            A673BancoId = BC001B28_A673BancoId[0];
            n673BancoId = BC001B28_n673BancoId[0];
            A432ProveedorImagen = BC001B28_A432ProveedorImagen[0];
            n432ProveedorImagen = BC001B28_n432ProveedorImagen[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1B28( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound28 = 0;
         ScanKeyLoad1B28( ) ;
      }

      protected void ScanKeyLoad1B28( )
      {
         sMode28 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound28 = 1;
            A133ProveedorID = BC001B28_A133ProveedorID[0];
            n133ProveedorID = BC001B28_n133ProveedorID[0];
            A278ProveedoresTipoNombre = BC001B28_A278ProveedoresTipoNombre[0];
            A282ProveedorNombre = BC001B28_A282ProveedorNombre[0];
            A338ProveedorDocIdentidad = BC001B28_A338ProveedorDocIdentidad[0];
            A430ProveedorTelefono = BC001B28_A430ProveedorTelefono[0];
            n430ProveedorTelefono = BC001B28_n430ProveedorTelefono[0];
            A431ProveedorDireccion = BC001B28_A431ProveedorDireccion[0];
            n431ProveedorDireccion = BC001B28_n431ProveedorDireccion[0];
            A433ProveedorEmail = BC001B28_A433ProveedorEmail[0];
            n433ProveedorEmail = BC001B28_n433ProveedorEmail[0];
            A344ProveedorEstado = BC001B28_A344ProveedorEstado[0];
            A682ProveedorRazonSocial = BC001B28_A682ProveedorRazonSocial[0];
            n682ProveedorRazonSocial = BC001B28_n682ProveedorRazonSocial[0];
            A683ProveedorContacto = BC001B28_A683ProveedorContacto[0];
            n683ProveedorContacto = BC001B28_n683ProveedorContacto[0];
            A684ProveedorContactoCell = BC001B28_A684ProveedorContactoCell[0];
            n684ProveedorContactoCell = BC001B28_n684ProveedorContactoCell[0];
            A40000ProveedorImagen_GXI = BC001B28_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = BC001B28_n40000ProveedorImagen_GXI[0];
            A687ProveedorCuentaBancaria = BC001B28_A687ProveedorCuentaBancaria[0];
            n687ProveedorCuentaBancaria = BC001B28_n687ProveedorCuentaBancaria[0];
            A674BancoNombre = BC001B28_A674BancoNombre[0];
            A978ProveedorCIU = BC001B28_A978ProveedorCIU[0];
            A151ProveedoresTipoId = BC001B28_A151ProveedoresTipoId[0];
            A673BancoId = BC001B28_A673BancoId[0];
            n673BancoId = BC001B28_n673BancoId[0];
            A432ProveedorImagen = BC001B28_A432ProveedorImagen[0];
            n432ProveedorImagen = BC001B28_n432ProveedorImagen[0];
         }
         Gx_mode = sMode28;
      }

      protected void ScanKeyEnd1B28( )
      {
         pr_default.close(26);
      }

      protected void AfterConfirm1B28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1B28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1B28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1B28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1B28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1B28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1B28( )
      {
      }

      protected void ZM1B52( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z337ProveedorSolicitudesNombre = A337ProveedorSolicitudesNombre;
            Z280ProveedorSolicitudesFecha = A280ProveedorSolicitudesFecha;
         }
         if ( GX_JID == -10 )
         {
            Z133ProveedorID = A133ProveedorID;
            Z152ProveedorSolicitudesId = A152ProveedorSolicitudesId;
            Z337ProveedorSolicitudesNombre = A337ProveedorSolicitudesNombre;
            Z280ProveedorSolicitudesFecha = A280ProveedorSolicitudesFecha;
         }
      }

      protected void standaloneNotModal1B52( )
      {
      }

      protected void standaloneModal1B52( )
      {
      }

      protected void Load1B52( )
      {
         /* Using cursor BC001B29 */
         pr_default.execute(27, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound52 = 1;
            A337ProveedorSolicitudesNombre = BC001B29_A337ProveedorSolicitudesNombre[0];
            A280ProveedorSolicitudesFecha = BC001B29_A280ProveedorSolicitudesFecha[0];
            n280ProveedorSolicitudesFecha = BC001B29_n280ProveedorSolicitudesFecha[0];
            ZM1B52( -10) ;
         }
         pr_default.close(27);
         OnLoadActions1B52( ) ;
      }

      protected void OnLoadActions1B52( )
      {
      }

      protected void CheckExtendedTable1B52( )
      {
         Gx_BScreen = 1;
         standaloneModal1B52( ) ;
         Gx_BScreen = 0;
         if ( ! ( (DateTime.MinValue==A280ProveedorSolicitudesFecha) || ( DateTimeUtil.ResetTime ( A280ProveedorSolicitudesFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1B52( )
      {
      }

      protected void enableDisable1B52( )
      {
      }

      protected void GetKey1B52( )
      {
         /* Using cursor BC001B30 */
         pr_default.execute(28, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound52 = 1;
         }
         else
         {
            RcdFound52 = 0;
         }
         pr_default.close(28);
      }

      protected void getByPrimaryKey1B52( )
      {
         /* Using cursor BC001B3 */
         pr_default.execute(1, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1B52( 10) ;
            RcdFound52 = 1;
            InitializeNonKey1B52( ) ;
            A152ProveedorSolicitudesId = BC001B3_A152ProveedorSolicitudesId[0];
            A337ProveedorSolicitudesNombre = BC001B3_A337ProveedorSolicitudesNombre[0];
            A280ProveedorSolicitudesFecha = BC001B3_A280ProveedorSolicitudesFecha[0];
            n280ProveedorSolicitudesFecha = BC001B3_n280ProveedorSolicitudesFecha[0];
            Z133ProveedorID = A133ProveedorID;
            Z152ProveedorSolicitudesId = A152ProveedorSolicitudesId;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1B52( ) ;
            Load1B52( ) ;
            Gx_mode = sMode52;
         }
         else
         {
            RcdFound52 = 0;
            InitializeNonKey1B52( ) ;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1B52( ) ;
            Gx_mode = sMode52;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1B52( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1B52( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001B2 */
            pr_default.execute(0, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProveedorSolicitudes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z337ProveedorSolicitudesNombre, BC001B2_A337ProveedorSolicitudesNombre[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z280ProveedorSolicitudesFecha ) != DateTimeUtil.ResetTime ( BC001B2_A280ProveedorSolicitudesFecha[0] ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProveedorSolicitudes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1B52( )
      {
         BeforeValidate1B52( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B52( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1B52( 0) ;
            CheckOptimisticConcurrency1B52( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B52( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1B52( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001B31 */
                     pr_default.execute(29, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId, A337ProveedorSolicitudesNombre, n280ProveedorSolicitudesFecha, A280ProveedorSolicitudesFecha});
                     pr_default.close(29);
                     pr_default.SmartCacheProvider.SetUpdated("ProveedorSolicitudes");
                     if ( (pr_default.getStatus(29) == 1) )
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
               Load1B52( ) ;
            }
            EndLevel1B52( ) ;
         }
         CloseExtendedTableCursors1B52( ) ;
      }

      protected void Update1B52( )
      {
         BeforeValidate1B52( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B52( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B52( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B52( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1B52( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001B32 */
                     pr_default.execute(30, new Object[] {A337ProveedorSolicitudesNombre, n280ProveedorSolicitudesFecha, A280ProveedorSolicitudesFecha, n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
                     pr_default.close(30);
                     pr_default.SmartCacheProvider.SetUpdated("ProveedorSolicitudes");
                     if ( (pr_default.getStatus(30) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProveedorSolicitudes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1B52( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey1B52( ) ;
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
            EndLevel1B52( ) ;
         }
         CloseExtendedTableCursors1B52( ) ;
      }

      protected void DeferredUpdate1B52( )
      {
      }

      protected void Delete1B52( )
      {
         Gx_mode = "DLT";
         BeforeValidate1B52( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B52( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1B52( ) ;
            AfterConfirm1B52( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1B52( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001B33 */
                  pr_default.execute(31, new Object[] {n133ProveedorID, A133ProveedorID, A152ProveedorSolicitudesId});
                  pr_default.close(31);
                  pr_default.SmartCacheProvider.SetUpdated("ProveedorSolicitudes");
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
         sMode52 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1B52( ) ;
         Gx_mode = sMode52;
      }

      protected void OnDeleteControls1B52( )
      {
         standaloneModal1B52( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1B52( )
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

      public void ScanKeyStart1B52( )
      {
         /* Scan By routine */
         /* Using cursor BC001B34 */
         pr_default.execute(32, new Object[] {n133ProveedorID, A133ProveedorID});
         RcdFound52 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound52 = 1;
            A152ProveedorSolicitudesId = BC001B34_A152ProveedorSolicitudesId[0];
            A337ProveedorSolicitudesNombre = BC001B34_A337ProveedorSolicitudesNombre[0];
            A280ProveedorSolicitudesFecha = BC001B34_A280ProveedorSolicitudesFecha[0];
            n280ProveedorSolicitudesFecha = BC001B34_n280ProveedorSolicitudesFecha[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1B52( )
      {
         /* Scan next routine */
         pr_default.readNext(32);
         RcdFound52 = 0;
         ScanKeyLoad1B52( ) ;
      }

      protected void ScanKeyLoad1B52( )
      {
         sMode52 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound52 = 1;
            A152ProveedorSolicitudesId = BC001B34_A152ProveedorSolicitudesId[0];
            A337ProveedorSolicitudesNombre = BC001B34_A337ProveedorSolicitudesNombre[0];
            A280ProveedorSolicitudesFecha = BC001B34_A280ProveedorSolicitudesFecha[0];
            n280ProveedorSolicitudesFecha = BC001B34_n280ProveedorSolicitudesFecha[0];
         }
         Gx_mode = sMode52;
      }

      protected void ScanKeyEnd1B52( )
      {
         pr_default.close(32);
      }

      protected void AfterConfirm1B52( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1B52( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1B52( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1B52( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1B52( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1B52( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1B52( )
      {
      }

      protected void send_integrity_lvl_hashes1B52( )
      {
      }

      protected void send_integrity_lvl_hashes1B28( )
      {
      }

      protected void AddRow1B28( )
      {
         VarsToRow28( bcComercio) ;
      }

      protected void ReadRow1B28( )
      {
         RowToVars28( bcComercio, 1) ;
      }

      protected void AddRow1B52( )
      {
         SdtComercio_Solicitudes obj52;
         obj52 = new SdtComercio_Solicitudes(context);
         VarsToRow52( obj52) ;
         bcComercio.gxTpr_Solicitudes.Add(obj52, 0);
         obj52.gxTpr_Mode = "UPD";
         obj52.gxTpr_Modified = 0;
      }

      protected void ReadRow1B52( )
      {
         nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
         RowToVars52( ((SdtComercio_Solicitudes)bcComercio.gxTpr_Solicitudes.Item(nGXsfl_52_idx)), 1) ;
      }

      protected void InitializeNonKey1B28( )
      {
         A151ProveedoresTipoId = 0;
         A278ProveedoresTipoNombre = "";
         A282ProveedorNombre = "";
         A338ProveedorDocIdentidad = "";
         A430ProveedorTelefono = "";
         n430ProveedorTelefono = false;
         A431ProveedorDireccion = "";
         n431ProveedorDireccion = false;
         A433ProveedorEmail = "";
         n433ProveedorEmail = false;
         A344ProveedorEstado = "";
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
         A687ProveedorCuentaBancaria = "";
         n687ProveedorCuentaBancaria = false;
         A673BancoId = 0;
         n673BancoId = false;
         A674BancoNombre = "";
         A978ProveedorCIU = false;
         Z282ProveedorNombre = "";
         Z338ProveedorDocIdentidad = "";
         Z430ProveedorTelefono = "";
         Z431ProveedorDireccion = "";
         Z433ProveedorEmail = "";
         Z344ProveedorEstado = "";
         Z682ProveedorRazonSocial = "";
         Z683ProveedorContacto = "";
         Z684ProveedorContactoCell = "";
         Z687ProveedorCuentaBancaria = "";
         Z978ProveedorCIU = false;
         Z151ProveedoresTipoId = 0;
         Z673BancoId = 0;
      }

      protected void InitAll1B28( )
      {
         A133ProveedorID = 0;
         n133ProveedorID = false;
         InitializeNonKey1B28( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A978ProveedorCIU = i978ProveedorCIU;
      }

      protected void InitializeNonKey1B52( )
      {
         A337ProveedorSolicitudesNombre = "";
         A280ProveedorSolicitudesFecha = DateTime.MinValue;
         n280ProveedorSolicitudesFecha = false;
         Z337ProveedorSolicitudesNombre = "";
         Z280ProveedorSolicitudesFecha = DateTime.MinValue;
      }

      protected void InitAll1B52( )
      {
         A152ProveedorSolicitudesId = 0;
         InitializeNonKey1B52( ) ;
      }

      protected void StandaloneModalInsert1B52( )
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

      public void VarsToRow28( SdtComercio obj28 )
      {
         obj28.gxTpr_Mode = Gx_mode;
         obj28.gxTpr_Proveedorestipoid = A151ProveedoresTipoId;
         obj28.gxTpr_Proveedorestiponombre = A278ProveedoresTipoNombre;
         obj28.gxTpr_Proveedornombre = A282ProveedorNombre;
         obj28.gxTpr_Proveedordocidentidad = A338ProveedorDocIdentidad;
         obj28.gxTpr_Proveedortelefono = A430ProveedorTelefono;
         obj28.gxTpr_Proveedordireccion = A431ProveedorDireccion;
         obj28.gxTpr_Proveedoremail = A433ProveedorEmail;
         obj28.gxTpr_Proveedorestado = A344ProveedorEstado;
         obj28.gxTpr_Proveedorrazonsocial = A682ProveedorRazonSocial;
         obj28.gxTpr_Proveedorcontacto = A683ProveedorContacto;
         obj28.gxTpr_Proveedorcontactocell = A684ProveedorContactoCell;
         obj28.gxTpr_Proveedorimagen = A432ProveedorImagen;
         obj28.gxTpr_Proveedorimagen_gxi = A40000ProveedorImagen_GXI;
         obj28.gxTpr_Proveedorcuentabancaria = A687ProveedorCuentaBancaria;
         obj28.gxTpr_Bancoid = A673BancoId;
         obj28.gxTpr_Banconombre = A674BancoNombre;
         obj28.gxTpr_Proveedorciu = A978ProveedorCIU;
         obj28.gxTpr_Proveedorid = A133ProveedorID;
         obj28.gxTpr_Proveedorid_Z = Z133ProveedorID;
         obj28.gxTpr_Proveedorestipoid_Z = Z151ProveedoresTipoId;
         obj28.gxTpr_Proveedorestiponombre_Z = Z278ProveedoresTipoNombre;
         obj28.gxTpr_Proveedornombre_Z = Z282ProveedorNombre;
         obj28.gxTpr_Proveedordocidentidad_Z = Z338ProveedorDocIdentidad;
         obj28.gxTpr_Proveedortelefono_Z = Z430ProveedorTelefono;
         obj28.gxTpr_Proveedordireccion_Z = Z431ProveedorDireccion;
         obj28.gxTpr_Proveedoremail_Z = Z433ProveedorEmail;
         obj28.gxTpr_Proveedorestado_Z = Z344ProveedorEstado;
         obj28.gxTpr_Proveedorrazonsocial_Z = Z682ProveedorRazonSocial;
         obj28.gxTpr_Proveedorcontacto_Z = Z683ProveedorContacto;
         obj28.gxTpr_Proveedorcontactocell_Z = Z684ProveedorContactoCell;
         obj28.gxTpr_Proveedorcuentabancaria_Z = Z687ProveedorCuentaBancaria;
         obj28.gxTpr_Bancoid_Z = Z673BancoId;
         obj28.gxTpr_Banconombre_Z = Z674BancoNombre;
         obj28.gxTpr_Proveedorimagen_gxi_Z = Z40000ProveedorImagen_GXI;
         obj28.gxTpr_Proveedorciu_Z = Z978ProveedorCIU;
         obj28.gxTpr_Proveedorid_N = (short)(Convert.ToInt16(n133ProveedorID));
         obj28.gxTpr_Proveedortelefono_N = (short)(Convert.ToInt16(n430ProveedorTelefono));
         obj28.gxTpr_Proveedordireccion_N = (short)(Convert.ToInt16(n431ProveedorDireccion));
         obj28.gxTpr_Proveedoremail_N = (short)(Convert.ToInt16(n433ProveedorEmail));
         obj28.gxTpr_Proveedorrazonsocial_N = (short)(Convert.ToInt16(n682ProveedorRazonSocial));
         obj28.gxTpr_Proveedorcontacto_N = (short)(Convert.ToInt16(n683ProveedorContacto));
         obj28.gxTpr_Proveedorcontactocell_N = (short)(Convert.ToInt16(n684ProveedorContactoCell));
         obj28.gxTpr_Proveedorimagen_N = (short)(Convert.ToInt16(n432ProveedorImagen));
         obj28.gxTpr_Proveedorcuentabancaria_N = (short)(Convert.ToInt16(n687ProveedorCuentaBancaria));
         obj28.gxTpr_Bancoid_N = (short)(Convert.ToInt16(n673BancoId));
         obj28.gxTpr_Proveedorimagen_gxi_N = (short)(Convert.ToInt16(n40000ProveedorImagen_GXI));
         obj28.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow28( SdtComercio obj28 )
      {
         obj28.gxTpr_Proveedorid = A133ProveedorID;
         return  ;
      }

      public void RowToVars28( SdtComercio obj28 ,
                               int forceLoad )
      {
         Gx_mode = obj28.gxTpr_Mode;
         A151ProveedoresTipoId = obj28.gxTpr_Proveedorestipoid;
         A278ProveedoresTipoNombre = obj28.gxTpr_Proveedorestiponombre;
         A282ProveedorNombre = obj28.gxTpr_Proveedornombre;
         A338ProveedorDocIdentidad = obj28.gxTpr_Proveedordocidentidad;
         A430ProveedorTelefono = obj28.gxTpr_Proveedortelefono;
         n430ProveedorTelefono = false;
         A431ProveedorDireccion = obj28.gxTpr_Proveedordireccion;
         n431ProveedorDireccion = false;
         A433ProveedorEmail = obj28.gxTpr_Proveedoremail;
         n433ProveedorEmail = false;
         A344ProveedorEstado = obj28.gxTpr_Proveedorestado;
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
         A687ProveedorCuentaBancaria = obj28.gxTpr_Proveedorcuentabancaria;
         n687ProveedorCuentaBancaria = false;
         A673BancoId = obj28.gxTpr_Bancoid;
         n673BancoId = false;
         A674BancoNombre = obj28.gxTpr_Banconombre;
         A978ProveedorCIU = obj28.gxTpr_Proveedorciu;
         A133ProveedorID = obj28.gxTpr_Proveedorid;
         n133ProveedorID = false;
         Z133ProveedorID = obj28.gxTpr_Proveedorid_Z;
         Z151ProveedoresTipoId = obj28.gxTpr_Proveedorestipoid_Z;
         Z278ProveedoresTipoNombre = obj28.gxTpr_Proveedorestiponombre_Z;
         Z282ProveedorNombre = obj28.gxTpr_Proveedornombre_Z;
         Z338ProveedorDocIdentidad = obj28.gxTpr_Proveedordocidentidad_Z;
         Z430ProveedorTelefono = obj28.gxTpr_Proveedortelefono_Z;
         Z431ProveedorDireccion = obj28.gxTpr_Proveedordireccion_Z;
         Z433ProveedorEmail = obj28.gxTpr_Proveedoremail_Z;
         Z344ProveedorEstado = obj28.gxTpr_Proveedorestado_Z;
         Z682ProveedorRazonSocial = obj28.gxTpr_Proveedorrazonsocial_Z;
         Z683ProveedorContacto = obj28.gxTpr_Proveedorcontacto_Z;
         Z684ProveedorContactoCell = obj28.gxTpr_Proveedorcontactocell_Z;
         Z687ProveedorCuentaBancaria = obj28.gxTpr_Proveedorcuentabancaria_Z;
         Z673BancoId = obj28.gxTpr_Bancoid_Z;
         Z674BancoNombre = obj28.gxTpr_Banconombre_Z;
         Z40000ProveedorImagen_GXI = obj28.gxTpr_Proveedorimagen_gxi_Z;
         Z978ProveedorCIU = obj28.gxTpr_Proveedorciu_Z;
         n133ProveedorID = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorid_N));
         n430ProveedorTelefono = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedortelefono_N));
         n431ProveedorDireccion = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedordireccion_N));
         n433ProveedorEmail = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedoremail_N));
         n682ProveedorRazonSocial = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorrazonsocial_N));
         n683ProveedorContacto = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorcontacto_N));
         n684ProveedorContactoCell = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorcontactocell_N));
         n432ProveedorImagen = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorimagen_N));
         n687ProveedorCuentaBancaria = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorcuentabancaria_N));
         n673BancoId = (bool)(Convert.ToBoolean(obj28.gxTpr_Bancoid_N));
         n40000ProveedorImagen_GXI = (bool)(Convert.ToBoolean(obj28.gxTpr_Proveedorimagen_gxi_N));
         Gx_mode = obj28.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow52( SdtComercio_Solicitudes obj52 )
      {
         obj52.gxTpr_Mode = Gx_mode;
         obj52.gxTpr_Proveedorsolicitudesnombre = A337ProveedorSolicitudesNombre;
         obj52.gxTpr_Proveedorsolicitudesfecha = A280ProveedorSolicitudesFecha;
         obj52.gxTpr_Proveedorsolicitudesid = A152ProveedorSolicitudesId;
         obj52.gxTpr_Proveedorsolicitudesid_Z = Z152ProveedorSolicitudesId;
         obj52.gxTpr_Proveedorsolicitudesnombre_Z = Z337ProveedorSolicitudesNombre;
         obj52.gxTpr_Proveedorsolicitudesfecha_Z = Z280ProveedorSolicitudesFecha;
         obj52.gxTpr_Proveedorsolicitudesfecha_N = (short)(Convert.ToInt16(n280ProveedorSolicitudesFecha));
         obj52.gxTpr_Modified = nIsMod_52;
         return  ;
      }

      public void KeyVarsToRow52( SdtComercio_Solicitudes obj52 )
      {
         obj52.gxTpr_Proveedorsolicitudesid = A152ProveedorSolicitudesId;
         return  ;
      }

      public void RowToVars52( SdtComercio_Solicitudes obj52 ,
                               int forceLoad )
      {
         Gx_mode = obj52.gxTpr_Mode;
         A337ProveedorSolicitudesNombre = obj52.gxTpr_Proveedorsolicitudesnombre;
         A280ProveedorSolicitudesFecha = obj52.gxTpr_Proveedorsolicitudesfecha;
         n280ProveedorSolicitudesFecha = false;
         A152ProveedorSolicitudesId = obj52.gxTpr_Proveedorsolicitudesid;
         Z152ProveedorSolicitudesId = obj52.gxTpr_Proveedorsolicitudesid_Z;
         Z337ProveedorSolicitudesNombre = obj52.gxTpr_Proveedorsolicitudesnombre_Z;
         Z280ProveedorSolicitudesFecha = obj52.gxTpr_Proveedorsolicitudesfecha_Z;
         n280ProveedorSolicitudesFecha = (bool)(Convert.ToBoolean(obj52.gxTpr_Proveedorsolicitudesfecha_N));
         nIsMod_52 = obj52.gxTpr_Modified;
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
         InitializeNonKey1B28( ) ;
         ScanKeyStart1B28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z133ProveedorID = A133ProveedorID;
         }
         ZM1B28( -7) ;
         OnLoadActions1B28( ) ;
         AddRow1B28( ) ;
         bcComercio.gxTpr_Solicitudes.ClearCollection();
         if ( RcdFound28 == 1 )
         {
            ScanKeyStart1B52( ) ;
            nGXsfl_52_idx = 1;
            while ( RcdFound52 != 0 )
            {
               Z133ProveedorID = A133ProveedorID;
               Z152ProveedorSolicitudesId = A152ProveedorSolicitudesId;
               ZM1B52( -10) ;
               OnLoadActions1B52( ) ;
               nRcdExists_52 = 1;
               nIsMod_52 = 0;
               AddRow1B52( ) ;
               nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
               ScanKeyNext1B52( ) ;
            }
            ScanKeyEnd1B52( ) ;
         }
         ScanKeyEnd1B28( ) ;
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
         RowToVars28( bcComercio, 0) ;
         ScanKeyStart1B28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z133ProveedorID = A133ProveedorID;
         }
         ZM1B28( -7) ;
         OnLoadActions1B28( ) ;
         AddRow1B28( ) ;
         bcComercio.gxTpr_Solicitudes.ClearCollection();
         if ( RcdFound28 == 1 )
         {
            ScanKeyStart1B52( ) ;
            nGXsfl_52_idx = 1;
            while ( RcdFound52 != 0 )
            {
               Z133ProveedorID = A133ProveedorID;
               Z152ProveedorSolicitudesId = A152ProveedorSolicitudesId;
               ZM1B52( -10) ;
               OnLoadActions1B52( ) ;
               nRcdExists_52 = 1;
               nIsMod_52 = 0;
               AddRow1B52( ) ;
               nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
               ScanKeyNext1B52( ) ;
            }
            ScanKeyEnd1B52( ) ;
         }
         ScanKeyEnd1B28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1B28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1B28( ) ;
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
                  Update1B28( ) ;
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
                        Insert1B28( ) ;
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
                        Insert1B28( ) ;
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
         RowToVars28( bcComercio, 1) ;
         SaveImpl( ) ;
         VarsToRow28( bcComercio) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars28( bcComercio, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1B28( ) ;
         AfterTrn( ) ;
         VarsToRow28( bcComercio) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow28( bcComercio) ;
         }
         else
         {
            SdtComercio auxBC = new SdtComercio(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A133ProveedorID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcComercio);
               auxBC.Save();
               bcComercio.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars28( bcComercio, 1) ;
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
         RowToVars28( bcComercio, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1B28( ) ;
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
               VarsToRow28( bcComercio) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow28( bcComercio) ;
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
         RowToVars28( bcComercio, 0) ;
         GetKey1B28( ) ;
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
         pr_default.close(3);
         pr_default.close(1);
         pr_default.close(12);
         pr_default.close(13);
         context.RollbackDataStores("comercio_bc",pr_default);
         VarsToRow28( bcComercio) ;
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
         Gx_mode = bcComercio.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcComercio.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcComercio )
         {
            bcComercio = (SdtComercio)(sdt);
            if ( StringUtil.StrCmp(bcComercio.gxTpr_Mode, "") == 0 )
            {
               bcComercio.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow28( bcComercio) ;
            }
            else
            {
               RowToVars28( bcComercio, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcComercio.gxTpr_Mode, "") == 0 )
            {
               bcComercio.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars28( bcComercio, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtComercio Comercio_BC
      {
         get {
            return bcComercio ;
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
         sMode28 = "";
         AV16WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV22Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9WebSession = context.GetSession();
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z282ProveedorNombre = "";
         A282ProveedorNombre = "";
         Z338ProveedorDocIdentidad = "";
         A338ProveedorDocIdentidad = "";
         Z430ProveedorTelefono = "";
         A430ProveedorTelefono = "";
         Z431ProveedorDireccion = "";
         A431ProveedorDireccion = "";
         Z433ProveedorEmail = "";
         A433ProveedorEmail = "";
         Z344ProveedorEstado = "";
         A344ProveedorEstado = "";
         Z682ProveedorRazonSocial = "";
         A682ProveedorRazonSocial = "";
         Z683ProveedorContacto = "";
         A683ProveedorContacto = "";
         Z684ProveedorContactoCell = "";
         A684ProveedorContactoCell = "";
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
         BC001B8_A133ProveedorID = new long[1] ;
         BC001B8_n133ProveedorID = new bool[] {false} ;
         BC001B8_A278ProveedoresTipoNombre = new string[] {""} ;
         BC001B8_A282ProveedorNombre = new string[] {""} ;
         BC001B8_A338ProveedorDocIdentidad = new string[] {""} ;
         BC001B8_A430ProveedorTelefono = new string[] {""} ;
         BC001B8_n430ProveedorTelefono = new bool[] {false} ;
         BC001B8_A431ProveedorDireccion = new string[] {""} ;
         BC001B8_n431ProveedorDireccion = new bool[] {false} ;
         BC001B8_A433ProveedorEmail = new string[] {""} ;
         BC001B8_n433ProveedorEmail = new bool[] {false} ;
         BC001B8_A344ProveedorEstado = new string[] {""} ;
         BC001B8_A682ProveedorRazonSocial = new string[] {""} ;
         BC001B8_n682ProveedorRazonSocial = new bool[] {false} ;
         BC001B8_A683ProveedorContacto = new string[] {""} ;
         BC001B8_n683ProveedorContacto = new bool[] {false} ;
         BC001B8_A684ProveedorContactoCell = new string[] {""} ;
         BC001B8_n684ProveedorContactoCell = new bool[] {false} ;
         BC001B8_A40000ProveedorImagen_GXI = new string[] {""} ;
         BC001B8_n40000ProveedorImagen_GXI = new bool[] {false} ;
         BC001B8_A687ProveedorCuentaBancaria = new string[] {""} ;
         BC001B8_n687ProveedorCuentaBancaria = new bool[] {false} ;
         BC001B8_A674BancoNombre = new string[] {""} ;
         BC001B8_A978ProveedorCIU = new bool[] {false} ;
         BC001B8_A151ProveedoresTipoId = new long[1] ;
         BC001B8_A673BancoId = new long[1] ;
         BC001B8_n673BancoId = new bool[] {false} ;
         BC001B8_A432ProveedorImagen = new string[] {""} ;
         BC001B8_n432ProveedorImagen = new bool[] {false} ;
         BC001B6_A278ProveedoresTipoNombre = new string[] {""} ;
         BC001B7_A674BancoNombre = new string[] {""} ;
         BC001B9_A133ProveedorID = new long[1] ;
         BC001B9_n133ProveedorID = new bool[] {false} ;
         BC001B5_A133ProveedorID = new long[1] ;
         BC001B5_n133ProveedorID = new bool[] {false} ;
         BC001B5_A282ProveedorNombre = new string[] {""} ;
         BC001B5_A338ProveedorDocIdentidad = new string[] {""} ;
         BC001B5_A430ProveedorTelefono = new string[] {""} ;
         BC001B5_n430ProveedorTelefono = new bool[] {false} ;
         BC001B5_A431ProveedorDireccion = new string[] {""} ;
         BC001B5_n431ProveedorDireccion = new bool[] {false} ;
         BC001B5_A433ProveedorEmail = new string[] {""} ;
         BC001B5_n433ProveedorEmail = new bool[] {false} ;
         BC001B5_A344ProveedorEstado = new string[] {""} ;
         BC001B5_A682ProveedorRazonSocial = new string[] {""} ;
         BC001B5_n682ProveedorRazonSocial = new bool[] {false} ;
         BC001B5_A683ProveedorContacto = new string[] {""} ;
         BC001B5_n683ProveedorContacto = new bool[] {false} ;
         BC001B5_A684ProveedorContactoCell = new string[] {""} ;
         BC001B5_n684ProveedorContactoCell = new bool[] {false} ;
         BC001B5_A40000ProveedorImagen_GXI = new string[] {""} ;
         BC001B5_n40000ProveedorImagen_GXI = new bool[] {false} ;
         BC001B5_A687ProveedorCuentaBancaria = new string[] {""} ;
         BC001B5_n687ProveedorCuentaBancaria = new bool[] {false} ;
         BC001B5_A978ProveedorCIU = new bool[] {false} ;
         BC001B5_A151ProveedoresTipoId = new long[1] ;
         BC001B5_A673BancoId = new long[1] ;
         BC001B5_n673BancoId = new bool[] {false} ;
         BC001B5_A432ProveedorImagen = new string[] {""} ;
         BC001B5_n432ProveedorImagen = new bool[] {false} ;
         BC001B4_A133ProveedorID = new long[1] ;
         BC001B4_n133ProveedorID = new bool[] {false} ;
         BC001B4_A282ProveedorNombre = new string[] {""} ;
         BC001B4_A338ProveedorDocIdentidad = new string[] {""} ;
         BC001B4_A430ProveedorTelefono = new string[] {""} ;
         BC001B4_n430ProveedorTelefono = new bool[] {false} ;
         BC001B4_A431ProveedorDireccion = new string[] {""} ;
         BC001B4_n431ProveedorDireccion = new bool[] {false} ;
         BC001B4_A433ProveedorEmail = new string[] {""} ;
         BC001B4_n433ProveedorEmail = new bool[] {false} ;
         BC001B4_A344ProveedorEstado = new string[] {""} ;
         BC001B4_A682ProveedorRazonSocial = new string[] {""} ;
         BC001B4_n682ProveedorRazonSocial = new bool[] {false} ;
         BC001B4_A683ProveedorContacto = new string[] {""} ;
         BC001B4_n683ProveedorContacto = new bool[] {false} ;
         BC001B4_A684ProveedorContactoCell = new string[] {""} ;
         BC001B4_n684ProveedorContactoCell = new bool[] {false} ;
         BC001B4_A40000ProveedorImagen_GXI = new string[] {""} ;
         BC001B4_n40000ProveedorImagen_GXI = new bool[] {false} ;
         BC001B4_A687ProveedorCuentaBancaria = new string[] {""} ;
         BC001B4_n687ProveedorCuentaBancaria = new bool[] {false} ;
         BC001B4_A978ProveedorCIU = new bool[] {false} ;
         BC001B4_A151ProveedoresTipoId = new long[1] ;
         BC001B4_A673BancoId = new long[1] ;
         BC001B4_n673BancoId = new bool[] {false} ;
         BC001B4_A432ProveedorImagen = new string[] {""} ;
         BC001B4_n432ProveedorImagen = new bool[] {false} ;
         BC001B10_A133ProveedorID = new long[1] ;
         BC001B10_n133ProveedorID = new bool[] {false} ;
         BC001B14_A278ProveedoresTipoNombre = new string[] {""} ;
         BC001B15_A674BancoNombre = new string[] {""} ;
         BC001B16_A422PostulacionesId = new long[1] ;
         BC001B17_A918MapeoID = new long[1] ;
         BC001B18_A918MapeoID = new long[1] ;
         BC001B19_A491VincularTrnId = new long[1] ;
         BC001B20_A450ProfComisionesID = new long[1] ;
         BC001B20_A452ProfComisionesRubrosId = new long[1] ;
         BC001B21_A127SolicitudesID = new long[1] ;
         BC001B22_A127SolicitudesID = new long[1] ;
         BC001B23_A133ProveedorID = new long[1] ;
         BC001B23_n133ProveedorID = new bool[] {false} ;
         BC001B23_A713ComercioProductosRubrosID = new long[1] ;
         BC001B24_A590Listaid = new long[1] ;
         BC001B24_A133ProveedorID = new long[1] ;
         BC001B24_n133ProveedorID = new bool[] {false} ;
         BC001B24_A120ProfesionalesId = new string[] {""} ;
         BC001B25_A590Listaid = new long[1] ;
         BC001B25_A18SecUserId = new long[1] ;
         BC001B25_A133ProveedorID = new long[1] ;
         BC001B25_n133ProveedorID = new bool[] {false} ;
         BC001B26_A503ComisionesID = new long[1] ;
         BC001B26_A133ProveedorID = new long[1] ;
         BC001B26_n133ProveedorID = new bool[] {false} ;
         BC001B27_A133ProveedorID = new long[1] ;
         BC001B27_n133ProveedorID = new bool[] {false} ;
         BC001B27_A157ProveedorComisionID = new long[1] ;
         BC001B28_A133ProveedorID = new long[1] ;
         BC001B28_n133ProveedorID = new bool[] {false} ;
         BC001B28_A278ProveedoresTipoNombre = new string[] {""} ;
         BC001B28_A282ProveedorNombre = new string[] {""} ;
         BC001B28_A338ProveedorDocIdentidad = new string[] {""} ;
         BC001B28_A430ProveedorTelefono = new string[] {""} ;
         BC001B28_n430ProveedorTelefono = new bool[] {false} ;
         BC001B28_A431ProveedorDireccion = new string[] {""} ;
         BC001B28_n431ProveedorDireccion = new bool[] {false} ;
         BC001B28_A433ProveedorEmail = new string[] {""} ;
         BC001B28_n433ProveedorEmail = new bool[] {false} ;
         BC001B28_A344ProveedorEstado = new string[] {""} ;
         BC001B28_A682ProveedorRazonSocial = new string[] {""} ;
         BC001B28_n682ProveedorRazonSocial = new bool[] {false} ;
         BC001B28_A683ProveedorContacto = new string[] {""} ;
         BC001B28_n683ProveedorContacto = new bool[] {false} ;
         BC001B28_A684ProveedorContactoCell = new string[] {""} ;
         BC001B28_n684ProveedorContactoCell = new bool[] {false} ;
         BC001B28_A40000ProveedorImagen_GXI = new string[] {""} ;
         BC001B28_n40000ProveedorImagen_GXI = new bool[] {false} ;
         BC001B28_A687ProveedorCuentaBancaria = new string[] {""} ;
         BC001B28_n687ProveedorCuentaBancaria = new bool[] {false} ;
         BC001B28_A674BancoNombre = new string[] {""} ;
         BC001B28_A978ProveedorCIU = new bool[] {false} ;
         BC001B28_A151ProveedoresTipoId = new long[1] ;
         BC001B28_A673BancoId = new long[1] ;
         BC001B28_n673BancoId = new bool[] {false} ;
         BC001B28_A432ProveedorImagen = new string[] {""} ;
         BC001B28_n432ProveedorImagen = new bool[] {false} ;
         Z337ProveedorSolicitudesNombre = "";
         A337ProveedorSolicitudesNombre = "";
         Z280ProveedorSolicitudesFecha = DateTime.MinValue;
         A280ProveedorSolicitudesFecha = DateTime.MinValue;
         BC001B29_A133ProveedorID = new long[1] ;
         BC001B29_n133ProveedorID = new bool[] {false} ;
         BC001B29_A152ProveedorSolicitudesId = new long[1] ;
         BC001B29_A337ProveedorSolicitudesNombre = new string[] {""} ;
         BC001B29_A280ProveedorSolicitudesFecha = new DateTime[] {DateTime.MinValue} ;
         BC001B29_n280ProveedorSolicitudesFecha = new bool[] {false} ;
         BC001B30_A133ProveedorID = new long[1] ;
         BC001B30_n133ProveedorID = new bool[] {false} ;
         BC001B30_A152ProveedorSolicitudesId = new long[1] ;
         BC001B3_A133ProveedorID = new long[1] ;
         BC001B3_n133ProveedorID = new bool[] {false} ;
         BC001B3_A152ProveedorSolicitudesId = new long[1] ;
         BC001B3_A337ProveedorSolicitudesNombre = new string[] {""} ;
         BC001B3_A280ProveedorSolicitudesFecha = new DateTime[] {DateTime.MinValue} ;
         BC001B3_n280ProveedorSolicitudesFecha = new bool[] {false} ;
         sMode52 = "";
         BC001B2_A133ProveedorID = new long[1] ;
         BC001B2_n133ProveedorID = new bool[] {false} ;
         BC001B2_A152ProveedorSolicitudesId = new long[1] ;
         BC001B2_A337ProveedorSolicitudesNombre = new string[] {""} ;
         BC001B2_A280ProveedorSolicitudesFecha = new DateTime[] {DateTime.MinValue} ;
         BC001B2_n280ProveedorSolicitudesFecha = new bool[] {false} ;
         BC001B34_A133ProveedorID = new long[1] ;
         BC001B34_n133ProveedorID = new bool[] {false} ;
         BC001B34_A152ProveedorSolicitudesId = new long[1] ;
         BC001B34_A337ProveedorSolicitudesNombre = new string[] {""} ;
         BC001B34_A280ProveedorSolicitudesFecha = new DateTime[] {DateTime.MinValue} ;
         BC001B34_n280ProveedorSolicitudesFecha = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.comercio_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comercio_bc__default(),
            new Object[][] {
                new Object[] {
               BC001B2_A133ProveedorID, BC001B2_A152ProveedorSolicitudesId, BC001B2_A337ProveedorSolicitudesNombre, BC001B2_A280ProveedorSolicitudesFecha, BC001B2_n280ProveedorSolicitudesFecha
               }
               , new Object[] {
               BC001B3_A133ProveedorID, BC001B3_A152ProveedorSolicitudesId, BC001B3_A337ProveedorSolicitudesNombre, BC001B3_A280ProveedorSolicitudesFecha, BC001B3_n280ProveedorSolicitudesFecha
               }
               , new Object[] {
               BC001B4_A133ProveedorID, BC001B4_A282ProveedorNombre, BC001B4_A338ProveedorDocIdentidad, BC001B4_A430ProveedorTelefono, BC001B4_n430ProveedorTelefono, BC001B4_A431ProveedorDireccion, BC001B4_n431ProveedorDireccion, BC001B4_A433ProveedorEmail, BC001B4_n433ProveedorEmail, BC001B4_A344ProveedorEstado,
               BC001B4_A682ProveedorRazonSocial, BC001B4_n682ProveedorRazonSocial, BC001B4_A683ProveedorContacto, BC001B4_n683ProveedorContacto, BC001B4_A684ProveedorContactoCell, BC001B4_n684ProveedorContactoCell, BC001B4_A40000ProveedorImagen_GXI, BC001B4_n40000ProveedorImagen_GXI, BC001B4_A687ProveedorCuentaBancaria, BC001B4_n687ProveedorCuentaBancaria,
               BC001B4_A978ProveedorCIU, BC001B4_A151ProveedoresTipoId, BC001B4_A673BancoId, BC001B4_n673BancoId, BC001B4_A432ProveedorImagen, BC001B4_n432ProveedorImagen
               }
               , new Object[] {
               BC001B5_A133ProveedorID, BC001B5_A282ProveedorNombre, BC001B5_A338ProveedorDocIdentidad, BC001B5_A430ProveedorTelefono, BC001B5_n430ProveedorTelefono, BC001B5_A431ProveedorDireccion, BC001B5_n431ProveedorDireccion, BC001B5_A433ProveedorEmail, BC001B5_n433ProveedorEmail, BC001B5_A344ProveedorEstado,
               BC001B5_A682ProveedorRazonSocial, BC001B5_n682ProveedorRazonSocial, BC001B5_A683ProveedorContacto, BC001B5_n683ProveedorContacto, BC001B5_A684ProveedorContactoCell, BC001B5_n684ProveedorContactoCell, BC001B5_A40000ProveedorImagen_GXI, BC001B5_n40000ProveedorImagen_GXI, BC001B5_A687ProveedorCuentaBancaria, BC001B5_n687ProveedorCuentaBancaria,
               BC001B5_A978ProveedorCIU, BC001B5_A151ProveedoresTipoId, BC001B5_A673BancoId, BC001B5_n673BancoId, BC001B5_A432ProveedorImagen, BC001B5_n432ProveedorImagen
               }
               , new Object[] {
               BC001B6_A278ProveedoresTipoNombre
               }
               , new Object[] {
               BC001B7_A674BancoNombre
               }
               , new Object[] {
               BC001B8_A133ProveedorID, BC001B8_A278ProveedoresTipoNombre, BC001B8_A282ProveedorNombre, BC001B8_A338ProveedorDocIdentidad, BC001B8_A430ProveedorTelefono, BC001B8_n430ProveedorTelefono, BC001B8_A431ProveedorDireccion, BC001B8_n431ProveedorDireccion, BC001B8_A433ProveedorEmail, BC001B8_n433ProveedorEmail,
               BC001B8_A344ProveedorEstado, BC001B8_A682ProveedorRazonSocial, BC001B8_n682ProveedorRazonSocial, BC001B8_A683ProveedorContacto, BC001B8_n683ProveedorContacto, BC001B8_A684ProveedorContactoCell, BC001B8_n684ProveedorContactoCell, BC001B8_A40000ProveedorImagen_GXI, BC001B8_n40000ProveedorImagen_GXI, BC001B8_A687ProveedorCuentaBancaria,
               BC001B8_n687ProveedorCuentaBancaria, BC001B8_A674BancoNombre, BC001B8_A978ProveedorCIU, BC001B8_A151ProveedoresTipoId, BC001B8_A673BancoId, BC001B8_n673BancoId, BC001B8_A432ProveedorImagen, BC001B8_n432ProveedorImagen
               }
               , new Object[] {
               BC001B9_A133ProveedorID
               }
               , new Object[] {
               BC001B10_A133ProveedorID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001B14_A278ProveedoresTipoNombre
               }
               , new Object[] {
               BC001B15_A674BancoNombre
               }
               , new Object[] {
               BC001B16_A422PostulacionesId
               }
               , new Object[] {
               BC001B17_A918MapeoID
               }
               , new Object[] {
               BC001B18_A918MapeoID
               }
               , new Object[] {
               BC001B19_A491VincularTrnId
               }
               , new Object[] {
               BC001B20_A450ProfComisionesID, BC001B20_A452ProfComisionesRubrosId
               }
               , new Object[] {
               BC001B21_A127SolicitudesID
               }
               , new Object[] {
               BC001B22_A127SolicitudesID
               }
               , new Object[] {
               BC001B23_A133ProveedorID, BC001B23_A713ComercioProductosRubrosID
               }
               , new Object[] {
               BC001B24_A590Listaid, BC001B24_A133ProveedorID, BC001B24_A120ProfesionalesId
               }
               , new Object[] {
               BC001B25_A590Listaid, BC001B25_A18SecUserId, BC001B25_A133ProveedorID
               }
               , new Object[] {
               BC001B26_A503ComisionesID, BC001B26_A133ProveedorID
               }
               , new Object[] {
               BC001B27_A133ProveedorID, BC001B27_A157ProveedorComisionID
               }
               , new Object[] {
               BC001B28_A133ProveedorID, BC001B28_A278ProveedoresTipoNombre, BC001B28_A282ProveedorNombre, BC001B28_A338ProveedorDocIdentidad, BC001B28_A430ProveedorTelefono, BC001B28_n430ProveedorTelefono, BC001B28_A431ProveedorDireccion, BC001B28_n431ProveedorDireccion, BC001B28_A433ProveedorEmail, BC001B28_n433ProveedorEmail,
               BC001B28_A344ProveedorEstado, BC001B28_A682ProveedorRazonSocial, BC001B28_n682ProveedorRazonSocial, BC001B28_A683ProveedorContacto, BC001B28_n683ProveedorContacto, BC001B28_A684ProveedorContactoCell, BC001B28_n684ProveedorContactoCell, BC001B28_A40000ProveedorImagen_GXI, BC001B28_n40000ProveedorImagen_GXI, BC001B28_A687ProveedorCuentaBancaria,
               BC001B28_n687ProveedorCuentaBancaria, BC001B28_A674BancoNombre, BC001B28_A978ProveedorCIU, BC001B28_A151ProveedoresTipoId, BC001B28_A673BancoId, BC001B28_n673BancoId, BC001B28_A432ProveedorImagen, BC001B28_n432ProveedorImagen
               }
               , new Object[] {
               BC001B29_A133ProveedorID, BC001B29_A152ProveedorSolicitudesId, BC001B29_A337ProveedorSolicitudesNombre, BC001B29_A280ProveedorSolicitudesFecha, BC001B29_n280ProveedorSolicitudesFecha
               }
               , new Object[] {
               BC001B30_A133ProveedorID, BC001B30_A152ProveedorSolicitudesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001B34_A133ProveedorID, BC001B34_A152ProveedorSolicitudesId, BC001B34_A337ProveedorSolicitudesNombre, BC001B34_A280ProveedorSolicitudesFecha, BC001B34_n280ProveedorSolicitudesFecha
               }
            }
         );
         Z978ProveedorCIU = false;
         A978ProveedorCIU = false;
         i978ProveedorCIU = false;
         AV22Pgmname = "Comercio_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121B2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_52 ;
      private short RcdFound52 ;
      private short Gx_BScreen ;
      private short RcdFound28 ;
      private short nRcdExists_52 ;
      private short Gxremove52 ;
      private int trnEnded ;
      private int nGXsfl_52_idx=1 ;
      private int AV23GXV1 ;
      private long Z133ProveedorID ;
      private long A133ProveedorID ;
      private long AV10Insert_ProveedoresTipoId ;
      private long AV18Insert_BancoId ;
      private long Z151ProveedoresTipoId ;
      private long A151ProveedoresTipoId ;
      private long Z673BancoId ;
      private long A673BancoId ;
      private long Z152ProveedorSolicitudesId ;
      private long A152ProveedorSolicitudesId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode28 ;
      private string AV22Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Z282ProveedorNombre ;
      private string A282ProveedorNombre ;
      private string Z338ProveedorDocIdentidad ;
      private string A338ProveedorDocIdentidad ;
      private string Z430ProveedorTelefono ;
      private string A430ProveedorTelefono ;
      private string Z344ProveedorEstado ;
      private string A344ProveedorEstado ;
      private string Z682ProveedorRazonSocial ;
      private string A682ProveedorRazonSocial ;
      private string Z683ProveedorContacto ;
      private string A683ProveedorContacto ;
      private string Z684ProveedorContactoCell ;
      private string A684ProveedorContactoCell ;
      private string Z687ProveedorCuentaBancaria ;
      private string A687ProveedorCuentaBancaria ;
      private string Z278ProveedoresTipoNombre ;
      private string A278ProveedoresTipoNombre ;
      private string Z674BancoNombre ;
      private string A674BancoNombre ;
      private string Z337ProveedorSolicitudesNombre ;
      private string A337ProveedorSolicitudesNombre ;
      private string sMode52 ;
      private DateTime Z280ProveedorSolicitudesFecha ;
      private DateTime A280ProveedorSolicitudesFecha ;
      private bool returnInSub ;
      private bool AV7IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Z978ProveedorCIU ;
      private bool A978ProveedorCIU ;
      private bool n133ProveedorID ;
      private bool n430ProveedorTelefono ;
      private bool n431ProveedorDireccion ;
      private bool n433ProveedorEmail ;
      private bool n682ProveedorRazonSocial ;
      private bool n683ProveedorContacto ;
      private bool n684ProveedorContactoCell ;
      private bool n40000ProveedorImagen_GXI ;
      private bool n687ProveedorCuentaBancaria ;
      private bool n673BancoId ;
      private bool n432ProveedorImagen ;
      private bool Gx_longc ;
      private bool n280ProveedorSolicitudesFecha ;
      private bool i978ProveedorCIU ;
      private string Z431ProveedorDireccion ;
      private string A431ProveedorDireccion ;
      private string Z433ProveedorEmail ;
      private string A433ProveedorEmail ;
      private string Z40000ProveedorImagen_GXI ;
      private string A40000ProveedorImagen_GXI ;
      private string Z432ProveedorImagen ;
      private string A432ProveedorImagen ;
      private IGxSession AV9WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtComercio bcComercio ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV16WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private long[] BC001B8_A133ProveedorID ;
      private bool[] BC001B8_n133ProveedorID ;
      private string[] BC001B8_A278ProveedoresTipoNombre ;
      private string[] BC001B8_A282ProveedorNombre ;
      private string[] BC001B8_A338ProveedorDocIdentidad ;
      private string[] BC001B8_A430ProveedorTelefono ;
      private bool[] BC001B8_n430ProveedorTelefono ;
      private string[] BC001B8_A431ProveedorDireccion ;
      private bool[] BC001B8_n431ProveedorDireccion ;
      private string[] BC001B8_A433ProveedorEmail ;
      private bool[] BC001B8_n433ProveedorEmail ;
      private string[] BC001B8_A344ProveedorEstado ;
      private string[] BC001B8_A682ProveedorRazonSocial ;
      private bool[] BC001B8_n682ProveedorRazonSocial ;
      private string[] BC001B8_A683ProveedorContacto ;
      private bool[] BC001B8_n683ProveedorContacto ;
      private string[] BC001B8_A684ProveedorContactoCell ;
      private bool[] BC001B8_n684ProveedorContactoCell ;
      private string[] BC001B8_A40000ProveedorImagen_GXI ;
      private bool[] BC001B8_n40000ProveedorImagen_GXI ;
      private string[] BC001B8_A687ProveedorCuentaBancaria ;
      private bool[] BC001B8_n687ProveedorCuentaBancaria ;
      private string[] BC001B8_A674BancoNombre ;
      private bool[] BC001B8_A978ProveedorCIU ;
      private long[] BC001B8_A151ProveedoresTipoId ;
      private long[] BC001B8_A673BancoId ;
      private bool[] BC001B8_n673BancoId ;
      private string[] BC001B8_A432ProveedorImagen ;
      private bool[] BC001B8_n432ProveedorImagen ;
      private string[] BC001B6_A278ProveedoresTipoNombre ;
      private string[] BC001B7_A674BancoNombre ;
      private long[] BC001B9_A133ProveedorID ;
      private bool[] BC001B9_n133ProveedorID ;
      private long[] BC001B5_A133ProveedorID ;
      private bool[] BC001B5_n133ProveedorID ;
      private string[] BC001B5_A282ProveedorNombre ;
      private string[] BC001B5_A338ProveedorDocIdentidad ;
      private string[] BC001B5_A430ProveedorTelefono ;
      private bool[] BC001B5_n430ProveedorTelefono ;
      private string[] BC001B5_A431ProveedorDireccion ;
      private bool[] BC001B5_n431ProveedorDireccion ;
      private string[] BC001B5_A433ProveedorEmail ;
      private bool[] BC001B5_n433ProveedorEmail ;
      private string[] BC001B5_A344ProveedorEstado ;
      private string[] BC001B5_A682ProveedorRazonSocial ;
      private bool[] BC001B5_n682ProveedorRazonSocial ;
      private string[] BC001B5_A683ProveedorContacto ;
      private bool[] BC001B5_n683ProveedorContacto ;
      private string[] BC001B5_A684ProveedorContactoCell ;
      private bool[] BC001B5_n684ProveedorContactoCell ;
      private string[] BC001B5_A40000ProveedorImagen_GXI ;
      private bool[] BC001B5_n40000ProveedorImagen_GXI ;
      private string[] BC001B5_A687ProveedorCuentaBancaria ;
      private bool[] BC001B5_n687ProveedorCuentaBancaria ;
      private bool[] BC001B5_A978ProveedorCIU ;
      private long[] BC001B5_A151ProveedoresTipoId ;
      private long[] BC001B5_A673BancoId ;
      private bool[] BC001B5_n673BancoId ;
      private string[] BC001B5_A432ProveedorImagen ;
      private bool[] BC001B5_n432ProveedorImagen ;
      private long[] BC001B4_A133ProveedorID ;
      private bool[] BC001B4_n133ProveedorID ;
      private string[] BC001B4_A282ProveedorNombre ;
      private string[] BC001B4_A338ProveedorDocIdentidad ;
      private string[] BC001B4_A430ProveedorTelefono ;
      private bool[] BC001B4_n430ProveedorTelefono ;
      private string[] BC001B4_A431ProveedorDireccion ;
      private bool[] BC001B4_n431ProveedorDireccion ;
      private string[] BC001B4_A433ProveedorEmail ;
      private bool[] BC001B4_n433ProveedorEmail ;
      private string[] BC001B4_A344ProveedorEstado ;
      private string[] BC001B4_A682ProveedorRazonSocial ;
      private bool[] BC001B4_n682ProveedorRazonSocial ;
      private string[] BC001B4_A683ProveedorContacto ;
      private bool[] BC001B4_n683ProveedorContacto ;
      private string[] BC001B4_A684ProveedorContactoCell ;
      private bool[] BC001B4_n684ProveedorContactoCell ;
      private string[] BC001B4_A40000ProveedorImagen_GXI ;
      private bool[] BC001B4_n40000ProveedorImagen_GXI ;
      private string[] BC001B4_A687ProveedorCuentaBancaria ;
      private bool[] BC001B4_n687ProveedorCuentaBancaria ;
      private bool[] BC001B4_A978ProveedorCIU ;
      private long[] BC001B4_A151ProveedoresTipoId ;
      private long[] BC001B4_A673BancoId ;
      private bool[] BC001B4_n673BancoId ;
      private string[] BC001B4_A432ProveedorImagen ;
      private bool[] BC001B4_n432ProveedorImagen ;
      private long[] BC001B10_A133ProveedorID ;
      private bool[] BC001B10_n133ProveedorID ;
      private string[] BC001B14_A278ProveedoresTipoNombre ;
      private string[] BC001B15_A674BancoNombre ;
      private long[] BC001B16_A422PostulacionesId ;
      private long[] BC001B17_A918MapeoID ;
      private long[] BC001B18_A918MapeoID ;
      private long[] BC001B19_A491VincularTrnId ;
      private long[] BC001B20_A450ProfComisionesID ;
      private long[] BC001B20_A452ProfComisionesRubrosId ;
      private long[] BC001B21_A127SolicitudesID ;
      private long[] BC001B22_A127SolicitudesID ;
      private long[] BC001B23_A133ProveedorID ;
      private bool[] BC001B23_n133ProveedorID ;
      private long[] BC001B23_A713ComercioProductosRubrosID ;
      private long[] BC001B24_A590Listaid ;
      private long[] BC001B24_A133ProveedorID ;
      private bool[] BC001B24_n133ProveedorID ;
      private string[] BC001B24_A120ProfesionalesId ;
      private long[] BC001B25_A590Listaid ;
      private long[] BC001B25_A18SecUserId ;
      private long[] BC001B25_A133ProveedorID ;
      private bool[] BC001B25_n133ProveedorID ;
      private long[] BC001B26_A503ComisionesID ;
      private long[] BC001B26_A133ProveedorID ;
      private bool[] BC001B26_n133ProveedorID ;
      private long[] BC001B27_A133ProveedorID ;
      private bool[] BC001B27_n133ProveedorID ;
      private long[] BC001B27_A157ProveedorComisionID ;
      private long[] BC001B28_A133ProveedorID ;
      private bool[] BC001B28_n133ProveedorID ;
      private string[] BC001B28_A278ProveedoresTipoNombre ;
      private string[] BC001B28_A282ProveedorNombre ;
      private string[] BC001B28_A338ProveedorDocIdentidad ;
      private string[] BC001B28_A430ProveedorTelefono ;
      private bool[] BC001B28_n430ProveedorTelefono ;
      private string[] BC001B28_A431ProveedorDireccion ;
      private bool[] BC001B28_n431ProveedorDireccion ;
      private string[] BC001B28_A433ProveedorEmail ;
      private bool[] BC001B28_n433ProveedorEmail ;
      private string[] BC001B28_A344ProveedorEstado ;
      private string[] BC001B28_A682ProveedorRazonSocial ;
      private bool[] BC001B28_n682ProveedorRazonSocial ;
      private string[] BC001B28_A683ProveedorContacto ;
      private bool[] BC001B28_n683ProveedorContacto ;
      private string[] BC001B28_A684ProveedorContactoCell ;
      private bool[] BC001B28_n684ProveedorContactoCell ;
      private string[] BC001B28_A40000ProveedorImagen_GXI ;
      private bool[] BC001B28_n40000ProveedorImagen_GXI ;
      private string[] BC001B28_A687ProveedorCuentaBancaria ;
      private bool[] BC001B28_n687ProveedorCuentaBancaria ;
      private string[] BC001B28_A674BancoNombre ;
      private bool[] BC001B28_A978ProveedorCIU ;
      private long[] BC001B28_A151ProveedoresTipoId ;
      private long[] BC001B28_A673BancoId ;
      private bool[] BC001B28_n673BancoId ;
      private string[] BC001B28_A432ProveedorImagen ;
      private bool[] BC001B28_n432ProveedorImagen ;
      private long[] BC001B29_A133ProveedorID ;
      private bool[] BC001B29_n133ProveedorID ;
      private long[] BC001B29_A152ProveedorSolicitudesId ;
      private string[] BC001B29_A337ProveedorSolicitudesNombre ;
      private DateTime[] BC001B29_A280ProveedorSolicitudesFecha ;
      private bool[] BC001B29_n280ProveedorSolicitudesFecha ;
      private long[] BC001B30_A133ProveedorID ;
      private bool[] BC001B30_n133ProveedorID ;
      private long[] BC001B30_A152ProveedorSolicitudesId ;
      private long[] BC001B3_A133ProveedorID ;
      private bool[] BC001B3_n133ProveedorID ;
      private long[] BC001B3_A152ProveedorSolicitudesId ;
      private string[] BC001B3_A337ProveedorSolicitudesNombre ;
      private DateTime[] BC001B3_A280ProveedorSolicitudesFecha ;
      private bool[] BC001B3_n280ProveedorSolicitudesFecha ;
      private long[] BC001B2_A133ProveedorID ;
      private bool[] BC001B2_n133ProveedorID ;
      private long[] BC001B2_A152ProveedorSolicitudesId ;
      private string[] BC001B2_A337ProveedorSolicitudesNombre ;
      private DateTime[] BC001B2_A280ProveedorSolicitudesFecha ;
      private bool[] BC001B2_n280ProveedorSolicitudesFecha ;
      private long[] BC001B34_A133ProveedorID ;
      private bool[] BC001B34_n133ProveedorID ;
      private long[] BC001B34_A152ProveedorSolicitudesId ;
      private string[] BC001B34_A337ProveedorSolicitudesNombre ;
      private DateTime[] BC001B34_A280ProveedorSolicitudesFecha ;
      private bool[] BC001B34_n280ProveedorSolicitudesFecha ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class comercio_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class comercio_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
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
       ,new UpdateCursor(def[29])
       ,new UpdateCursor(def[30])
       ,new UpdateCursor(def[31])
       ,new ForEachCursor(def[32])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC001B2;
        prmBC001B2 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmBC001B3;
        prmBC001B3 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmBC001B4;
        prmBC001B4 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B5;
        prmBC001B5 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B6;
        prmBC001B6 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmBC001B7;
        prmBC001B7 = new Object[] {
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B8;
        prmBC001B8 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B9;
        prmBC001B9 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B10;
        prmBC001B10 = new Object[] {
        new ParDef("@ProveedorNombre",GXType.NChar,80,0) ,
        new ParDef("@ProveedorDocIdentidad",GXType.NChar,25,0) ,
        new ParDef("@ProveedorTelefono",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorDireccion",GXType.NVarChar,1024,0){Nullable=true} ,
        new ParDef("@ProveedorEmail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@ProveedorEstado",GXType.NChar,3,0) ,
        new ParDef("@ProveedorRazonSocial",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@ProveedorContacto",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ProveedorContactoCell",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ProveedorImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=9, Tbl="Proveedor", Fld="ProveedorImagen"} ,
        new ParDef("@ProveedorCuentaBancaria",GXType.NChar,50,0){Nullable=true} ,
        new ParDef("@ProveedorCIU",GXType.Boolean,4,0) ,
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0) ,
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B11;
        prmBC001B11 = new Object[] {
        new ParDef("@ProveedorNombre",GXType.NChar,80,0) ,
        new ParDef("@ProveedorDocIdentidad",GXType.NChar,25,0) ,
        new ParDef("@ProveedorTelefono",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorDireccion",GXType.NVarChar,1024,0){Nullable=true} ,
        new ParDef("@ProveedorEmail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@ProveedorEstado",GXType.NChar,3,0) ,
        new ParDef("@ProveedorRazonSocial",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@ProveedorContacto",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ProveedorContactoCell",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorCuentaBancaria",GXType.NChar,50,0){Nullable=true} ,
        new ParDef("@ProveedorCIU",GXType.Boolean,4,0) ,
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0) ,
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B12;
        prmBC001B12 = new Object[] {
        new ParDef("@ProveedorImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ProveedorImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Proveedor", Fld="ProveedorImagen"} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B13;
        prmBC001B13 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B14;
        prmBC001B14 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmBC001B15;
        prmBC001B15 = new Object[] {
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B16;
        prmBC001B16 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B17;
        prmBC001B17 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B18;
        prmBC001B18 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B19;
        prmBC001B19 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B20;
        prmBC001B20 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B21;
        prmBC001B21 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B22;
        prmBC001B22 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B23;
        prmBC001B23 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B24;
        prmBC001B24 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B25;
        prmBC001B25 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B26;
        prmBC001B26 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B27;
        prmBC001B27 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B28;
        prmBC001B28 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001B29;
        prmBC001B29 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmBC001B30;
        prmBC001B30 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmBC001B31;
        prmBC001B31 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorSolicitudesNombre",GXType.NChar,120,0) ,
        new ParDef("@ProveedorSolicitudesFecha",GXType.Date,8,0){Nullable=true}
        };
        Object[] prmBC001B32;
        prmBC001B32 = new Object[] {
        new ParDef("@ProveedorSolicitudesNombre",GXType.NChar,120,0) ,
        new ParDef("@ProveedorSolicitudesFecha",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmBC001B33;
        prmBC001B33 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmBC001B34;
        prmBC001B34 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC001B2", "SELECT [ProveedorID], [ProveedorSolicitudesId], [ProveedorSolicitudesNombre], [ProveedorSolicitudesFecha] FROM [ProveedorSolicitudes] WITH (UPDLOCK) WHERE [ProveedorID] = @ProveedorID AND [ProveedorSolicitudesId] = @ProveedorSolicitudesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B3", "SELECT [ProveedorID], [ProveedorSolicitudesId], [ProveedorSolicitudesNombre], [ProveedorSolicitudesFecha] FROM [ProveedorSolicitudes] WHERE [ProveedorID] = @ProveedorID AND [ProveedorSolicitudesId] = @ProveedorSolicitudesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B4", "SELECT [ProveedorID], [ProveedorNombre], [ProveedorDocIdentidad], [ProveedorTelefono], [ProveedorDireccion], [ProveedorEmail], [ProveedorEstado], [ProveedorRazonSocial], [ProveedorContacto], [ProveedorContactoCell], [ProveedorImagen_GXI], [ProveedorCuentaBancaria], [ProveedorCIU], [ProveedoresTipoId], [BancoId], [ProveedorImagen] FROM [Proveedor] WITH (UPDLOCK) WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B5", "SELECT [ProveedorID], [ProveedorNombre], [ProveedorDocIdentidad], [ProveedorTelefono], [ProveedorDireccion], [ProveedorEmail], [ProveedorEstado], [ProveedorRazonSocial], [ProveedorContacto], [ProveedorContactoCell], [ProveedorImagen_GXI], [ProveedorCuentaBancaria], [ProveedorCIU], [ProveedoresTipoId], [BancoId], [ProveedorImagen] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B6", "SELECT [ProveedoresTipoNombre] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B7", "SELECT [BancoNombre] FROM [Banco] WHERE [BancoId] = @BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B8", "SELECT TM1.[ProveedorID], T2.[ProveedoresTipoNombre], TM1.[ProveedorNombre], TM1.[ProveedorDocIdentidad], TM1.[ProveedorTelefono], TM1.[ProveedorDireccion], TM1.[ProveedorEmail], TM1.[ProveedorEstado], TM1.[ProveedorRazonSocial], TM1.[ProveedorContacto], TM1.[ProveedorContactoCell], TM1.[ProveedorImagen_GXI], TM1.[ProveedorCuentaBancaria], T3.[BancoNombre], TM1.[ProveedorCIU], TM1.[ProveedoresTipoId], TM1.[BancoId], TM1.[ProveedorImagen] FROM (([Proveedor] TM1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = TM1.[ProveedoresTipoId]) LEFT JOIN [Banco] T3 ON T3.[BancoId] = TM1.[BancoId]) WHERE TM1.[ProveedorID] = @ProveedorID ORDER BY TM1.[ProveedorID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B9", "SELECT [ProveedorID] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B10", "INSERT INTO [Proveedor]([ProveedorNombre], [ProveedorDocIdentidad], [ProveedorTelefono], [ProveedorDireccion], [ProveedorEmail], [ProveedorEstado], [ProveedorRazonSocial], [ProveedorContacto], [ProveedorContactoCell], [ProveedorImagen], [ProveedorImagen_GXI], [ProveedorCuentaBancaria], [ProveedorCIU], [ProveedoresTipoId], [BancoId], [ProveedorSerialComi], [ProveedorPerAltShop], [ProveedorPagoDefault], [ProveedorPideDoc], [DocumentacionId], [ProveedorUsrAlta], [ProveedorUsrActualizacion], [ProveedorFechaAlta], [ProveedorFechaActualizacion], [ProveedorUsoInterno], [ProveedorSitioWeb], [ProveedorAceptoTerminos], [ComercioProductosREnum], [ProveedorFreezePrice]) VALUES(@ProveedorNombre, @ProveedorDocIdentidad, @ProveedorTelefono, @ProveedorDireccion, @ProveedorEmail, @ProveedorEstado, @ProveedorRazonSocial, @ProveedorContacto, @ProveedorContactoCell, @ProveedorImagen, @ProveedorImagen_GXI, @ProveedorCuentaBancaria, @ProveedorCIU, @ProveedoresTipoId, @BancoId, convert(int, 0), '', '', '', convert(int, 0), convert(int, 0), convert(int, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', convert( DATETIME, '17530101', 112 ), convert(int, 0), convert(bit, 0)); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001B11", "UPDATE [Proveedor] SET [ProveedorNombre]=@ProveedorNombre, [ProveedorDocIdentidad]=@ProveedorDocIdentidad, [ProveedorTelefono]=@ProveedorTelefono, [ProveedorDireccion]=@ProveedorDireccion, [ProveedorEmail]=@ProveedorEmail, [ProveedorEstado]=@ProveedorEstado, [ProveedorRazonSocial]=@ProveedorRazonSocial, [ProveedorContacto]=@ProveedorContacto, [ProveedorContactoCell]=@ProveedorContactoCell, [ProveedorCuentaBancaria]=@ProveedorCuentaBancaria, [ProveedorCIU]=@ProveedorCIU, [ProveedoresTipoId]=@ProveedoresTipoId, [BancoId]=@BancoId  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmBC001B11)
           ,new CursorDef("BC001B12", "UPDATE [Proveedor] SET [ProveedorImagen]=@ProveedorImagen, [ProveedorImagen_GXI]=@ProveedorImagen_GXI  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmBC001B12)
           ,new CursorDef("BC001B13", "DELETE FROM [Proveedor]  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmBC001B13)
           ,new CursorDef("BC001B14", "SELECT [ProveedoresTipoNombre] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B15", "SELECT [BancoNombre] FROM [Banco] WHERE [BancoId] = @BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B16", "SELECT TOP 1 [PostulacionesId] FROM [Postulaciones] WHERE [PostulacionesProveedorId] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001B17", "SELECT TOP 1 [MapeoID] FROM [ListaMapeo] WHERE [STComerciosID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001B18", "SELECT TOP 1 [MapeoID] FROM [ListaMapeo] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001B19", "SELECT TOP 1 [VincularTrnId] FROM [VincularTrn] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001B20", "SELECT TOP 1 [ProfComisionesID], [ProfComisionesRubrosId] FROM [ProfComisionesRubros] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001B21", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [STComerciosID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001B22", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001B23", "SELECT TOP 1 [ProveedorID], [ComercioProductosRubrosID] FROM [ComercioProductosRubros] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001B24", "SELECT TOP 1 [Listaid], [ProveedorID], [ProfesionalesId] FROM [ListaAgrupacion] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001B25", "SELECT TOP 1 [Listaid], [SecUserId], [ProveedorID] FROM [ListaAgrUserProveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001B26", "SELECT TOP 1 [ComisionesID], [ProveedorID] FROM [ComisionesProveedores] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001B27", "SELECT TOP 1 [ProveedorID], [ProveedorComisionID] FROM [ProveedorComision] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001B28", "SELECT TM1.[ProveedorID], T2.[ProveedoresTipoNombre], TM1.[ProveedorNombre], TM1.[ProveedorDocIdentidad], TM1.[ProveedorTelefono], TM1.[ProveedorDireccion], TM1.[ProveedorEmail], TM1.[ProveedorEstado], TM1.[ProveedorRazonSocial], TM1.[ProveedorContacto], TM1.[ProveedorContactoCell], TM1.[ProveedorImagen_GXI], TM1.[ProveedorCuentaBancaria], T3.[BancoNombre], TM1.[ProveedorCIU], TM1.[ProveedoresTipoId], TM1.[BancoId], TM1.[ProveedorImagen] FROM (([Proveedor] TM1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = TM1.[ProveedoresTipoId]) LEFT JOIN [Banco] T3 ON T3.[BancoId] = TM1.[BancoId]) WHERE TM1.[ProveedorID] = @ProveedorID ORDER BY TM1.[ProveedorID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B28,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B29", "SELECT [ProveedorID], [ProveedorSolicitudesId], [ProveedorSolicitudesNombre], [ProveedorSolicitudesFecha] FROM [ProveedorSolicitudes] WHERE [ProveedorID] = @ProveedorID and [ProveedorSolicitudesId] = @ProveedorSolicitudesId ORDER BY [ProveedorID], [ProveedorSolicitudesId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B29,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B30", "SELECT [ProveedorID], [ProveedorSolicitudesId] FROM [ProveedorSolicitudes] WHERE [ProveedorID] = @ProveedorID AND [ProveedorSolicitudesId] = @ProveedorSolicitudesId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001B31", "INSERT INTO [ProveedorSolicitudes]([ProveedorID], [ProveedorSolicitudesId], [ProveedorSolicitudesNombre], [ProveedorSolicitudesFecha]) VALUES(@ProveedorID, @ProveedorSolicitudesId, @ProveedorSolicitudesNombre, @ProveedorSolicitudesFecha)", GxErrorMask.GX_NOMASK,prmBC001B31)
           ,new CursorDef("BC001B32", "UPDATE [ProveedorSolicitudes] SET [ProveedorSolicitudesNombre]=@ProveedorSolicitudesNombre, [ProveedorSolicitudesFecha]=@ProveedorSolicitudesFecha  WHERE [ProveedorID] = @ProveedorID AND [ProveedorSolicitudesId] = @ProveedorSolicitudesId", GxErrorMask.GX_NOMASK,prmBC001B32)
           ,new CursorDef("BC001B33", "DELETE FROM [ProveedorSolicitudes]  WHERE [ProveedorID] = @ProveedorID AND [ProveedorSolicitudesId] = @ProveedorSolicitudesId", GxErrorMask.GX_NOMASK,prmBC001B33)
           ,new CursorDef("BC001B34", "SELECT [ProveedorID], [ProveedorSolicitudesId], [ProveedorSolicitudesNombre], [ProveedorSolicitudesFecha] FROM [ProveedorSolicitudes] WHERE [ProveedorID] = @ProveedorID ORDER BY [ProveedorID], [ProveedorSolicitudesId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B34,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 25);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getString(7, 3);
              ((string[]) buf[10])[0] = rslt.getString(8, 25);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getString(9, 128);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getString(10, 20);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((string[]) buf[16])[0] = rslt.getMultimediaUri(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((string[]) buf[18])[0] = rslt.getString(12, 50);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              ((bool[]) buf[20])[0] = rslt.getBool(13);
              ((long[]) buf[21])[0] = rslt.getLong(14);
              ((long[]) buf[22])[0] = rslt.getLong(15);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(11));
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 25);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getString(7, 3);
              ((string[]) buf[10])[0] = rslt.getString(8, 25);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getString(9, 128);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getString(10, 20);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((string[]) buf[16])[0] = rslt.getMultimediaUri(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((string[]) buf[18])[0] = rslt.getString(12, 50);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              ((bool[]) buf[20])[0] = rslt.getBool(13);
              ((long[]) buf[21])[0] = rslt.getLong(14);
              ((long[]) buf[22])[0] = rslt.getLong(15);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(11));
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 120);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getString(4, 25);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getString(8, 3);
              ((string[]) buf[11])[0] = rslt.getString(9, 25);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getString(10, 128);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getString(11, 20);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getMultimediaUri(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              ((string[]) buf[19])[0] = rslt.getString(13, 50);
              ((bool[]) buf[20])[0] = rslt.wasNull(13);
              ((string[]) buf[21])[0] = rslt.getString(14, 80);
              ((bool[]) buf[22])[0] = rslt.getBool(15);
              ((long[]) buf[23])[0] = rslt.getLong(16);
              ((long[]) buf[24])[0] = rslt.getLong(17);
              ((bool[]) buf[25])[0] = rslt.wasNull(17);
              ((string[]) buf[26])[0] = rslt.getMultimediaFile(18, rslt.getVarchar(12));
              ((bool[]) buf[27])[0] = rslt.wasNull(18);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 120);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 22 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 23 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 26 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getString(4, 25);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getString(8, 3);
              ((string[]) buf[11])[0] = rslt.getString(9, 25);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getString(10, 128);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getString(11, 20);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getMultimediaUri(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              ((string[]) buf[19])[0] = rslt.getString(13, 50);
              ((bool[]) buf[20])[0] = rslt.wasNull(13);
              ((string[]) buf[21])[0] = rslt.getString(14, 80);
              ((bool[]) buf[22])[0] = rslt.getBool(15);
              ((long[]) buf[23])[0] = rslt.getLong(16);
              ((long[]) buf[24])[0] = rslt.getLong(17);
              ((bool[]) buf[25])[0] = rslt.wasNull(17);
              ((string[]) buf[26])[0] = rslt.getMultimediaFile(18, rslt.getVarchar(12));
              ((bool[]) buf[27])[0] = rslt.wasNull(18);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 32 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
     }
  }

}

}
