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
   public class profesionales_bc : GXHttpHandler, IGxSilentTrn
   {
      public profesionales_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profesionales_bc( IGxContext context )
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
         ReadRow0S34( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0S34( ) ;
         standaloneModal( ) ;
         AddRow0S34( ) ;
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
            E110S2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z120ProfesionalesId = A120ProfesionalesId;
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

      protected void CONFIRM_0S0( )
      {
         BeforeValidate0S34( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0S34( ) ;
            }
            else
            {
               CheckExtendedTable0S34( ) ;
               if ( AnyError == 0 )
               {
                  ZM0S34( 28) ;
                  ZM0S34( 29) ;
               }
               CloseExtendedTableCursors0S34( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode34 = Gx_mode;
            CONFIRM_0S35( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_0S36( ) ;
               if ( AnyError == 0 )
               {
                  CONFIRM_0S145( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Restore parent mode. */
                     Gx_mode = sMode34;
                  }
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode34;
         }
      }

      protected void CONFIRM_0S145( )
      {
         nGXsfl_145_idx = 0;
         while ( nGXsfl_145_idx < bcProfesionales.gxTpr_Servicios.Count )
         {
            ReadRow0S145( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound145 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_145 != 0 ) )
            {
               GetKey0S145( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound145 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0S145( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0S145( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0S145( 38) ;
                        }
                        CloseExtendedTableCursors0S145( ) ;
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
                  if ( RcdFound145 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0S145( ) ;
                        Load0S145( ) ;
                        BeforeValidate0S145( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0S145( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_145 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0S145( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0S145( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0S145( 38) ;
                              }
                              CloseExtendedTableCursors0S145( ) ;
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
               VarsToRow145( ((SdtProfesionales_Servicios)bcProfesionales.gxTpr_Servicios.Item(nGXsfl_145_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0S36( )
      {
         s197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
         nGXsfl_36_idx = 0;
         while ( nGXsfl_36_idx < bcProfesionales.gxTpr_Zonas.Count )
         {
            ReadRow0S36( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound36 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_36 != 0 ) )
            {
               GetKey0S36( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound36 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0S36( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0S36( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0S36( 34) ;
                           ZM0S36( 35) ;
                           ZM0S36( 36) ;
                        }
                        CloseExtendedTableCursors0S36( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
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
                  if ( RcdFound36 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0S36( ) ;
                        Load0S36( ) ;
                        BeforeValidate0S36( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0S36( ) ;
                           O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
                        }
                     }
                     else
                     {
                        if ( nIsMod_36 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0S36( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0S36( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0S36( 34) ;
                                 ZM0S36( 35) ;
                                 ZM0S36( 36) ;
                              }
                              CloseExtendedTableCursors0S36( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
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
               VarsToRow36( ((SdtProfesionales_Zonas)bcProfesionales.gxTpr_Zonas.Item(nGXsfl_36_idx))) ;
            }
         }
         O197ProfesionalesAutoEnuZona = s197ProfesionalesAutoEnuZona;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0S35( )
      {
         nGXsfl_35_idx = 0;
         while ( nGXsfl_35_idx < bcProfesionales.gxTpr_Rubros.Count )
         {
            ReadRow0S35( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound35 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_35 != 0 ) )
            {
               GetKey0S35( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound35 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0S35( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0S35( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0S35( 31) ;
                           ZM0S35( 32) ;
                        }
                        CloseExtendedTableCursors0S35( ) ;
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
                  if ( RcdFound35 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0S35( ) ;
                        Load0S35( ) ;
                        BeforeValidate0S35( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0S35( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_35 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0S35( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0S35( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0S35( 31) ;
                                 ZM0S35( 32) ;
                              }
                              CloseExtendedTableCursors0S35( ) ;
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
               VarsToRow35( ((SdtProfesionales_Rubros)bcProfesionales.gxTpr_Rubros.Item(nGXsfl_35_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120S2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV15WWPContext) ;
         AV8IsAuthorized = true;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Insert", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Update", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Delete", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
         }
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV34Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV34Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV35GXV1 = 1;
            while ( AV35GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV35GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "BancoId") == 0 )
               {
                  AV32Insert_BancoId = (long)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "EstadosTipo") == 0 )
               {
                  AV11Insert_EstadosTipo = AV13TrnContextAtt.gxTpr_Attributevalue;
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "EstadosGenericosId") == 0 )
               {
                  AV12Insert_EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV35GXV1 = (int)(AV35GXV1+1);
            }
         }
      }

      protected void E110S2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0S34( short GX_JID )
      {
         if ( ( GX_JID == 27 ) || ( GX_JID == 0 ) )
         {
            Z199ProfesionalesFechaAlta = A199ProfesionalesFechaAlta;
            Z200ProfesionalesFechaActualizado = A200ProfesionalesFechaActualizado;
            Z900ProfesionalesFechaNacimiento = A900ProfesionalesFechaNacimiento;
            Z901ProfesionalesRUT = A901ProfesionalesRUT;
            Z902ProfesionalesTipoEmpresa = A902ProfesionalesTipoEmpresa;
            Z676ProfesionalesEsRUT = A676ProfesionalesEsRUT;
            Z166ProfesionalesPrimerNombre = A166ProfesionalesPrimerNombre;
            Z191ProfesionalesSegundoNombre = A191ProfesionalesSegundoNombre;
            Z167ProfesionalesApellidoPrimero = A167ProfesionalesApellidoPrimero;
            Z192ProfesionalesApellidoSegundo = A192ProfesionalesApellidoSegundo;
            Z170ProfesionalesTelefono = A170ProfesionalesTelefono;
            Z193ProfesionalesEmail = A193ProfesionalesEmail;
            Z198ProfesionalesDireccion = A198ProfesionalesDireccion;
            Z267ProfesionalesVerDatPerSol = A267ProfesionalesVerDatPerSol;
            Z436ProfesionalesPerAltShop = A436ProfesionalesPerAltShop;
            Z196ProfesionalesAutoEnumerar = A196ProfesionalesAutoEnumerar;
            Z197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            Z677ProfesionalesExperiencia = A677ProfesionalesExperiencia;
            Z678ProfesionalesAceptoTerminos = A678ProfesionalesAceptoTerminos;
            Z679ProfesionalesDeclaroDatosV = A679ProfesionalesDeclaroDatosV;
            Z680ProfesionalesCuentaBancaria = A680ProfesionalesCuentaBancaria;
            Z800ProfesionalesCapacidadProducti = A800ProfesionalesCapacidadProducti;
            Z617ProfesionalesLimitOSF = A617ProfesionalesLimitOSF;
            Z268ProfesionalesFeedBackCant = A268ProfesionalesFeedBackCant;
            Z269ProfesionalesFeedBackProm = A269ProfesionalesFeedBackProm;
            Z107EstadosTipo = A107EstadosTipo;
            Z108EstadosGenericosId = A108EstadosGenericosId;
            Z673BancoId = A673BancoId;
            Z886ProfesionalesNombreCompleto = A886ProfesionalesNombreCompleto;
            Z803ProfesionalesTiempoDisponible = A803ProfesionalesTiempoDisponible;
            Z270ProfesionalesFeedback = A270ProfesionalesFeedback;
         }
         if ( ( GX_JID == 28 ) || ( GX_JID == 0 ) )
         {
            Z886ProfesionalesNombreCompleto = A886ProfesionalesNombreCompleto;
            Z803ProfesionalesTiempoDisponible = A803ProfesionalesTiempoDisponible;
            Z270ProfesionalesFeedback = A270ProfesionalesFeedback;
         }
         if ( ( GX_JID == 29 ) || ( GX_JID == 0 ) )
         {
            Z674BancoNombre = A674BancoNombre;
            Z886ProfesionalesNombreCompleto = A886ProfesionalesNombreCompleto;
            Z803ProfesionalesTiempoDisponible = A803ProfesionalesTiempoDisponible;
            Z270ProfesionalesFeedback = A270ProfesionalesFeedback;
         }
         if ( GX_JID == -27 )
         {
            Z120ProfesionalesId = A120ProfesionalesId;
            Z199ProfesionalesFechaAlta = A199ProfesionalesFechaAlta;
            Z200ProfesionalesFechaActualizado = A200ProfesionalesFechaActualizado;
            Z900ProfesionalesFechaNacimiento = A900ProfesionalesFechaNacimiento;
            Z901ProfesionalesRUT = A901ProfesionalesRUT;
            Z902ProfesionalesTipoEmpresa = A902ProfesionalesTipoEmpresa;
            Z676ProfesionalesEsRUT = A676ProfesionalesEsRUT;
            Z166ProfesionalesPrimerNombre = A166ProfesionalesPrimerNombre;
            Z191ProfesionalesSegundoNombre = A191ProfesionalesSegundoNombre;
            Z167ProfesionalesApellidoPrimero = A167ProfesionalesApellidoPrimero;
            Z192ProfesionalesApellidoSegundo = A192ProfesionalesApellidoSegundo;
            Z169ProfesionalesPhoto = A169ProfesionalesPhoto;
            Z40000ProfesionalesPhoto_GXI = A40000ProfesionalesPhoto_GXI;
            Z170ProfesionalesTelefono = A170ProfesionalesTelefono;
            Z193ProfesionalesEmail = A193ProfesionalesEmail;
            Z198ProfesionalesDireccion = A198ProfesionalesDireccion;
            Z267ProfesionalesVerDatPerSol = A267ProfesionalesVerDatPerSol;
            Z436ProfesionalesPerAltShop = A436ProfesionalesPerAltShop;
            Z196ProfesionalesAutoEnumerar = A196ProfesionalesAutoEnumerar;
            Z197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            Z677ProfesionalesExperiencia = A677ProfesionalesExperiencia;
            Z678ProfesionalesAceptoTerminos = A678ProfesionalesAceptoTerminos;
            Z679ProfesionalesDeclaroDatosV = A679ProfesionalesDeclaroDatosV;
            Z680ProfesionalesCuentaBancaria = A680ProfesionalesCuentaBancaria;
            Z800ProfesionalesCapacidadProducti = A800ProfesionalesCapacidadProducti;
            Z617ProfesionalesLimitOSF = A617ProfesionalesLimitOSF;
            Z268ProfesionalesFeedBackCant = A268ProfesionalesFeedBackCant;
            Z269ProfesionalesFeedBackProm = A269ProfesionalesFeedBackProm;
            Z107EstadosTipo = A107EstadosTipo;
            Z108EstadosGenericosId = A108EstadosGenericosId;
            Z673BancoId = A673BancoId;
            Z674BancoNombre = A674BancoNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         A107EstadosTipo = context.GetMessage( context.GetMessage( "STS", ""), "");
         if ( IsIns( )  )
         {
            A108EstadosGenericosId = 3;
         }
         if ( IsIns( )  )
         {
            A199ProfesionalesFechaAlta = DateTimeUtil.Now( context);
         }
         if ( IsIns( )  || IsUpd( )  )
         {
            A200ProfesionalesFechaActualizado = DateTimeUtil.Now( context);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A267ProfesionalesVerDatPerSol)) && ( Gx_BScreen == 0 ) )
         {
            A267ProfesionalesVerDatPerSol = context.GetMessage( context.GetMessage( "N", ""), "");
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A436ProfesionalesPerAltShop)) && ( Gx_BScreen == 0 ) )
         {
            A436ProfesionalesPerAltShop = context.GetMessage( context.GetMessage( "N", ""), "");
            n436ProfesionalesPerAltShop = false;
         }
         if ( IsIns( )  && (Convert.ToDecimal(0)==A800ProfesionalesCapacidadProducti) && ( Gx_BScreen == 0 ) )
         {
            A800ProfesionalesCapacidadProducti = (decimal)(8);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            A803ProfesionalesTiempoDisponible = A800ProfesionalesCapacidadProducti;
         }
      }

      protected void Load0S34( )
      {
         /* Using cursor BC000S18 */
         pr_default.execute(16, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound34 = 1;
            A199ProfesionalesFechaAlta = BC000S18_A199ProfesionalesFechaAlta[0];
            A200ProfesionalesFechaActualizado = BC000S18_A200ProfesionalesFechaActualizado[0];
            A900ProfesionalesFechaNacimiento = BC000S18_A900ProfesionalesFechaNacimiento[0];
            n900ProfesionalesFechaNacimiento = BC000S18_n900ProfesionalesFechaNacimiento[0];
            A901ProfesionalesRUT = BC000S18_A901ProfesionalesRUT[0];
            n901ProfesionalesRUT = BC000S18_n901ProfesionalesRUT[0];
            A902ProfesionalesTipoEmpresa = BC000S18_A902ProfesionalesTipoEmpresa[0];
            n902ProfesionalesTipoEmpresa = BC000S18_n902ProfesionalesTipoEmpresa[0];
            A676ProfesionalesEsRUT = BC000S18_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = BC000S18_n676ProfesionalesEsRUT[0];
            A166ProfesionalesPrimerNombre = BC000S18_A166ProfesionalesPrimerNombre[0];
            A191ProfesionalesSegundoNombre = BC000S18_A191ProfesionalesSegundoNombre[0];
            A167ProfesionalesApellidoPrimero = BC000S18_A167ProfesionalesApellidoPrimero[0];
            A192ProfesionalesApellidoSegundo = BC000S18_A192ProfesionalesApellidoSegundo[0];
            A40000ProfesionalesPhoto_GXI = BC000S18_A40000ProfesionalesPhoto_GXI[0];
            A170ProfesionalesTelefono = BC000S18_A170ProfesionalesTelefono[0];
            A193ProfesionalesEmail = BC000S18_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = BC000S18_n193ProfesionalesEmail[0];
            A198ProfesionalesDireccion = BC000S18_A198ProfesionalesDireccion[0];
            A267ProfesionalesVerDatPerSol = BC000S18_A267ProfesionalesVerDatPerSol[0];
            A436ProfesionalesPerAltShop = BC000S18_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = BC000S18_n436ProfesionalesPerAltShop[0];
            A196ProfesionalesAutoEnumerar = BC000S18_A196ProfesionalesAutoEnumerar[0];
            A197ProfesionalesAutoEnuZona = BC000S18_A197ProfesionalesAutoEnuZona[0];
            A677ProfesionalesExperiencia = BC000S18_A677ProfesionalesExperiencia[0];
            n677ProfesionalesExperiencia = BC000S18_n677ProfesionalesExperiencia[0];
            A678ProfesionalesAceptoTerminos = BC000S18_A678ProfesionalesAceptoTerminos[0];
            n678ProfesionalesAceptoTerminos = BC000S18_n678ProfesionalesAceptoTerminos[0];
            A679ProfesionalesDeclaroDatosV = BC000S18_A679ProfesionalesDeclaroDatosV[0];
            n679ProfesionalesDeclaroDatosV = BC000S18_n679ProfesionalesDeclaroDatosV[0];
            A680ProfesionalesCuentaBancaria = BC000S18_A680ProfesionalesCuentaBancaria[0];
            n680ProfesionalesCuentaBancaria = BC000S18_n680ProfesionalesCuentaBancaria[0];
            A800ProfesionalesCapacidadProducti = BC000S18_A800ProfesionalesCapacidadProducti[0];
            A674BancoNombre = BC000S18_A674BancoNombre[0];
            A617ProfesionalesLimitOSF = BC000S18_A617ProfesionalesLimitOSF[0];
            n617ProfesionalesLimitOSF = BC000S18_n617ProfesionalesLimitOSF[0];
            A268ProfesionalesFeedBackCant = BC000S18_A268ProfesionalesFeedBackCant[0];
            A269ProfesionalesFeedBackProm = BC000S18_A269ProfesionalesFeedBackProm[0];
            A107EstadosTipo = BC000S18_A107EstadosTipo[0];
            A108EstadosGenericosId = BC000S18_A108EstadosGenericosId[0];
            A673BancoId = BC000S18_A673BancoId[0];
            n673BancoId = BC000S18_n673BancoId[0];
            A169ProfesionalesPhoto = BC000S18_A169ProfesionalesPhoto[0];
            ZM0S34( -27) ;
         }
         pr_default.close(16);
         OnLoadActions0S34( ) ;
      }

      protected void OnLoadActions0S34( )
      {
         AV34Pgmname = "Profesionales_BC";
         A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
         A803ProfesionalesTiempoDisponible = A800ProfesionalesCapacidadProducti;
         if ( A268ProfesionalesFeedBackCant > 0 )
         {
            A270ProfesionalesFeedback = (decimal)(A269ProfesionalesFeedBackProm/ (decimal)(A268ProfesionalesFeedBackCant));
         }
         else
         {
            A270ProfesionalesFeedback = 0;
         }
         AV14ProfesionalesFeedback = A270ProfesionalesFeedback;
      }

      protected void CheckExtendedTable0S34( )
      {
         standaloneModal( ) ;
         AV34Pgmname = "Profesionales_BC";
         if ( ! ( (DateTime.MinValue==A900ProfesionalesFechaNacimiento) || ( DateTimeUtil.ResetTime ( A900ProfesionalesFechaNacimiento ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Profesionales Fecha Nacimiento", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( A902ProfesionalesTipoEmpresa == 1 ) || ( A902ProfesionalesTipoEmpresa == 2 ) || ( A902ProfesionalesTipoEmpresa == 3 ) || ( A902ProfesionalesTipoEmpresa == 4 ) || (0==A902ProfesionalesTipoEmpresa) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Profesionales Tipo Empresa", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
         if ( ! ( GxRegex.IsMatch(A193ProfesionalesEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A193ProfesionalesEmail)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A678ProfesionalesAceptoTerminos) || ( A678ProfesionalesAceptoTerminos >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Aceptó los terminos", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A679ProfesionalesDeclaroDatosV) || ( A679ProfesionalesDeclaroDatosV >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Declaró que los datos son Verdaderos", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         A803ProfesionalesTiempoDisponible = A800ProfesionalesCapacidadProducti;
         /* Using cursor BC000S17 */
         pr_default.execute(15, new Object[] {n673BancoId, A673BancoId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A673BancoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Banco", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "BANCOID");
               AnyError = 1;
            }
         }
         A674BancoNombre = BC000S17_A674BancoNombre[0];
         pr_default.close(15);
         /* Using cursor BC000S16 */
         pr_default.execute(14, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSGENERICOSID");
            AnyError = 1;
         }
         pr_default.close(14);
         if ( ! ( (DateTime.MinValue==A199ProfesionalesFechaAlta) || ( A199ProfesionalesFechaAlta >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha de Alta", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A200ProfesionalesFechaActualizado) || ( A200ProfesionalesFechaActualizado >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha Actualizado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( A268ProfesionalesFeedBackCant > 0 )
         {
            A270ProfesionalesFeedback = (decimal)(A269ProfesionalesFeedBackProm/ (decimal)(A268ProfesionalesFeedBackCant));
         }
         else
         {
            A270ProfesionalesFeedback = 0;
         }
         AV14ProfesionalesFeedback = A270ProfesionalesFeedback;
      }

      protected void CloseExtendedTableCursors0S34( )
      {
         pr_default.close(15);
         pr_default.close(14);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0S34( )
      {
         /* Using cursor BC000S19 */
         pr_default.execute(17, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound34 = 1;
         }
         else
         {
            RcdFound34 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000S15 */
         pr_default.execute(13, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            ZM0S34( 27) ;
            RcdFound34 = 1;
            A120ProfesionalesId = BC000S15_A120ProfesionalesId[0];
            A199ProfesionalesFechaAlta = BC000S15_A199ProfesionalesFechaAlta[0];
            A200ProfesionalesFechaActualizado = BC000S15_A200ProfesionalesFechaActualizado[0];
            A900ProfesionalesFechaNacimiento = BC000S15_A900ProfesionalesFechaNacimiento[0];
            n900ProfesionalesFechaNacimiento = BC000S15_n900ProfesionalesFechaNacimiento[0];
            A901ProfesionalesRUT = BC000S15_A901ProfesionalesRUT[0];
            n901ProfesionalesRUT = BC000S15_n901ProfesionalesRUT[0];
            A902ProfesionalesTipoEmpresa = BC000S15_A902ProfesionalesTipoEmpresa[0];
            n902ProfesionalesTipoEmpresa = BC000S15_n902ProfesionalesTipoEmpresa[0];
            A676ProfesionalesEsRUT = BC000S15_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = BC000S15_n676ProfesionalesEsRUT[0];
            A166ProfesionalesPrimerNombre = BC000S15_A166ProfesionalesPrimerNombre[0];
            A191ProfesionalesSegundoNombre = BC000S15_A191ProfesionalesSegundoNombre[0];
            A167ProfesionalesApellidoPrimero = BC000S15_A167ProfesionalesApellidoPrimero[0];
            A192ProfesionalesApellidoSegundo = BC000S15_A192ProfesionalesApellidoSegundo[0];
            A40000ProfesionalesPhoto_GXI = BC000S15_A40000ProfesionalesPhoto_GXI[0];
            A170ProfesionalesTelefono = BC000S15_A170ProfesionalesTelefono[0];
            A193ProfesionalesEmail = BC000S15_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = BC000S15_n193ProfesionalesEmail[0];
            A198ProfesionalesDireccion = BC000S15_A198ProfesionalesDireccion[0];
            A267ProfesionalesVerDatPerSol = BC000S15_A267ProfesionalesVerDatPerSol[0];
            A436ProfesionalesPerAltShop = BC000S15_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = BC000S15_n436ProfesionalesPerAltShop[0];
            A196ProfesionalesAutoEnumerar = BC000S15_A196ProfesionalesAutoEnumerar[0];
            A197ProfesionalesAutoEnuZona = BC000S15_A197ProfesionalesAutoEnuZona[0];
            A677ProfesionalesExperiencia = BC000S15_A677ProfesionalesExperiencia[0];
            n677ProfesionalesExperiencia = BC000S15_n677ProfesionalesExperiencia[0];
            A678ProfesionalesAceptoTerminos = BC000S15_A678ProfesionalesAceptoTerminos[0];
            n678ProfesionalesAceptoTerminos = BC000S15_n678ProfesionalesAceptoTerminos[0];
            A679ProfesionalesDeclaroDatosV = BC000S15_A679ProfesionalesDeclaroDatosV[0];
            n679ProfesionalesDeclaroDatosV = BC000S15_n679ProfesionalesDeclaroDatosV[0];
            A680ProfesionalesCuentaBancaria = BC000S15_A680ProfesionalesCuentaBancaria[0];
            n680ProfesionalesCuentaBancaria = BC000S15_n680ProfesionalesCuentaBancaria[0];
            A800ProfesionalesCapacidadProducti = BC000S15_A800ProfesionalesCapacidadProducti[0];
            A617ProfesionalesLimitOSF = BC000S15_A617ProfesionalesLimitOSF[0];
            n617ProfesionalesLimitOSF = BC000S15_n617ProfesionalesLimitOSF[0];
            A268ProfesionalesFeedBackCant = BC000S15_A268ProfesionalesFeedBackCant[0];
            A269ProfesionalesFeedBackProm = BC000S15_A269ProfesionalesFeedBackProm[0];
            A107EstadosTipo = BC000S15_A107EstadosTipo[0];
            A108EstadosGenericosId = BC000S15_A108EstadosGenericosId[0];
            A673BancoId = BC000S15_A673BancoId[0];
            n673BancoId = BC000S15_n673BancoId[0];
            A169ProfesionalesPhoto = BC000S15_A169ProfesionalesPhoto[0];
            O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            Z120ProfesionalesId = A120ProfesionalesId;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0S34( ) ;
            if ( AnyError == 1 )
            {
               RcdFound34 = 0;
               InitializeNonKey0S34( ) ;
            }
            Gx_mode = sMode34;
         }
         else
         {
            RcdFound34 = 0;
            InitializeNonKey0S34( ) ;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode34;
         }
         pr_default.close(13);
      }

      protected void getEqualNoModal( )
      {
         GetKey0S34( ) ;
         if ( RcdFound34 == 0 )
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
         CONFIRM_0S0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0S34( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000S14 */
            pr_default.execute(12, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(12) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Profesionales"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(12) == 101) || ( Z199ProfesionalesFechaAlta != BC000S14_A199ProfesionalesFechaAlta[0] ) || ( Z200ProfesionalesFechaActualizado != BC000S14_A200ProfesionalesFechaActualizado[0] ) || ( DateTimeUtil.ResetTime ( Z900ProfesionalesFechaNacimiento ) != DateTimeUtil.ResetTime ( BC000S14_A900ProfesionalesFechaNacimiento[0] ) ) || ( StringUtil.StrCmp(Z901ProfesionalesRUT, BC000S14_A901ProfesionalesRUT[0]) != 0 ) || ( Z902ProfesionalesTipoEmpresa != BC000S14_A902ProfesionalesTipoEmpresa[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z676ProfesionalesEsRUT != BC000S14_A676ProfesionalesEsRUT[0] ) || ( StringUtil.StrCmp(Z166ProfesionalesPrimerNombre, BC000S14_A166ProfesionalesPrimerNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z191ProfesionalesSegundoNombre, BC000S14_A191ProfesionalesSegundoNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z167ProfesionalesApellidoPrimero, BC000S14_A167ProfesionalesApellidoPrimero[0]) != 0 ) || ( StringUtil.StrCmp(Z192ProfesionalesApellidoSegundo, BC000S14_A192ProfesionalesApellidoSegundo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z170ProfesionalesTelefono, BC000S14_A170ProfesionalesTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z193ProfesionalesEmail, BC000S14_A193ProfesionalesEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z198ProfesionalesDireccion, BC000S14_A198ProfesionalesDireccion[0]) != 0 ) || ( StringUtil.StrCmp(Z267ProfesionalesVerDatPerSol, BC000S14_A267ProfesionalesVerDatPerSol[0]) != 0 ) || ( StringUtil.StrCmp(Z436ProfesionalesPerAltShop, BC000S14_A436ProfesionalesPerAltShop[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z196ProfesionalesAutoEnumerar != BC000S14_A196ProfesionalesAutoEnumerar[0] ) || ( Z197ProfesionalesAutoEnuZona != BC000S14_A197ProfesionalesAutoEnuZona[0] ) || ( StringUtil.StrCmp(Z677ProfesionalesExperiencia, BC000S14_A677ProfesionalesExperiencia[0]) != 0 ) || ( Z678ProfesionalesAceptoTerminos != BC000S14_A678ProfesionalesAceptoTerminos[0] ) || ( Z679ProfesionalesDeclaroDatosV != BC000S14_A679ProfesionalesDeclaroDatosV[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z680ProfesionalesCuentaBancaria, BC000S14_A680ProfesionalesCuentaBancaria[0]) != 0 ) || ( Z800ProfesionalesCapacidadProducti != BC000S14_A800ProfesionalesCapacidadProducti[0] ) || ( Z617ProfesionalesLimitOSF != BC000S14_A617ProfesionalesLimitOSF[0] ) || ( Z268ProfesionalesFeedBackCant != BC000S14_A268ProfesionalesFeedBackCant[0] ) || ( Z269ProfesionalesFeedBackProm != BC000S14_A269ProfesionalesFeedBackProm[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z107EstadosTipo, BC000S14_A107EstadosTipo[0]) != 0 ) || ( Z108EstadosGenericosId != BC000S14_A108EstadosGenericosId[0] ) || ( Z673BancoId != BC000S14_A673BancoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Profesionales"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0S34( )
      {
         BeforeValidate0S34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S34( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0S34( 0) ;
            CheckOptimisticConcurrency0S34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0S34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000S20 */
                     pr_default.execute(18, new Object[] {A120ProfesionalesId, A199ProfesionalesFechaAlta, A200ProfesionalesFechaActualizado, n900ProfesionalesFechaNacimiento, A900ProfesionalesFechaNacimiento, n901ProfesionalesRUT, A901ProfesionalesRUT, n902ProfesionalesTipoEmpresa, A902ProfesionalesTipoEmpresa, n676ProfesionalesEsRUT, A676ProfesionalesEsRUT, A166ProfesionalesPrimerNombre, A191ProfesionalesSegundoNombre, A167ProfesionalesApellidoPrimero, A192ProfesionalesApellidoSegundo, A169ProfesionalesPhoto, A40000ProfesionalesPhoto_GXI, A170ProfesionalesTelefono, n193ProfesionalesEmail, A193ProfesionalesEmail, A198ProfesionalesDireccion, A267ProfesionalesVerDatPerSol, n436ProfesionalesPerAltShop, A436ProfesionalesPerAltShop, A196ProfesionalesAutoEnumerar, A197ProfesionalesAutoEnuZona, n677ProfesionalesExperiencia, A677ProfesionalesExperiencia, n678ProfesionalesAceptoTerminos, A678ProfesionalesAceptoTerminos, n679ProfesionalesDeclaroDatosV, A679ProfesionalesDeclaroDatosV, n680ProfesionalesCuentaBancaria, A680ProfesionalesCuentaBancaria, A800ProfesionalesCapacidadProducti, n617ProfesionalesLimitOSF, A617ProfesionalesLimitOSF, A268ProfesionalesFeedBackCant, A269ProfesionalesFeedBackProm, A107EstadosTipo, A108EstadosGenericosId, n673BancoId, A673BancoId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("Profesionales");
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
                           ProcessLevel0S34( ) ;
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
               Load0S34( ) ;
            }
            EndLevel0S34( ) ;
         }
         CloseExtendedTableCursors0S34( ) ;
      }

      protected void Update0S34( )
      {
         BeforeValidate0S34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S34( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0S34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000S21 */
                     pr_default.execute(19, new Object[] {A199ProfesionalesFechaAlta, A200ProfesionalesFechaActualizado, n900ProfesionalesFechaNacimiento, A900ProfesionalesFechaNacimiento, n901ProfesionalesRUT, A901ProfesionalesRUT, n902ProfesionalesTipoEmpresa, A902ProfesionalesTipoEmpresa, n676ProfesionalesEsRUT, A676ProfesionalesEsRUT, A166ProfesionalesPrimerNombre, A191ProfesionalesSegundoNombre, A167ProfesionalesApellidoPrimero, A192ProfesionalesApellidoSegundo, A170ProfesionalesTelefono, n193ProfesionalesEmail, A193ProfesionalesEmail, A198ProfesionalesDireccion, A267ProfesionalesVerDatPerSol, n436ProfesionalesPerAltShop, A436ProfesionalesPerAltShop, A196ProfesionalesAutoEnumerar, A197ProfesionalesAutoEnuZona, n677ProfesionalesExperiencia, A677ProfesionalesExperiencia, n678ProfesionalesAceptoTerminos, A678ProfesionalesAceptoTerminos, n679ProfesionalesDeclaroDatosV, A679ProfesionalesDeclaroDatosV, n680ProfesionalesCuentaBancaria, A680ProfesionalesCuentaBancaria, A800ProfesionalesCapacidadProducti, n617ProfesionalesLimitOSF, A617ProfesionalesLimitOSF, A268ProfesionalesFeedBackCant, A269ProfesionalesFeedBackProm, A107EstadosTipo, A108EstadosGenericosId, n673BancoId, A673BancoId, A120ProfesionalesId});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("Profesionales");
                     if ( (pr_default.getStatus(19) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Profesionales"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0S34( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0S34( ) ;
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
            EndLevel0S34( ) ;
         }
         CloseExtendedTableCursors0S34( ) ;
      }

      protected void DeferredUpdate0S34( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000S22 */
            pr_default.execute(20, new Object[] {A169ProfesionalesPhoto, A40000ProfesionalesPhoto_GXI, A120ProfesionalesId});
            pr_default.close(20);
            pr_default.SmartCacheProvider.SetUpdated("Profesionales");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0S34( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S34( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0S34( ) ;
            AfterConfirm0S34( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0S34( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0S145( ) ;
                  while ( RcdFound145 != 0 )
                  {
                     getByPrimaryKey0S145( ) ;
                     Delete0S145( ) ;
                     ScanKeyNext0S145( ) ;
                  }
                  ScanKeyEnd0S145( ) ;
                  A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
                  ScanKeyStart0S36( ) ;
                  while ( RcdFound36 != 0 )
                  {
                     getByPrimaryKey0S36( ) ;
                     Delete0S36( ) ;
                     ScanKeyNext0S36( ) ;
                     O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
                  }
                  ScanKeyEnd0S36( ) ;
                  ScanKeyStart0S35( ) ;
                  while ( RcdFound35 != 0 )
                  {
                     getByPrimaryKey0S35( ) ;
                     Delete0S35( ) ;
                     ScanKeyNext0S35( ) ;
                  }
                  ScanKeyEnd0S35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000S23 */
                     pr_default.execute(21, new Object[] {A120ProfesionalesId});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("Profesionales");
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
         sMode34 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0S34( ) ;
         Gx_mode = sMode34;
      }

      protected void OnDeleteControls0S34( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV34Pgmname = "Profesionales_BC";
            A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
            A803ProfesionalesTiempoDisponible = A800ProfesionalesCapacidadProducti;
            /* Using cursor BC000S24 */
            pr_default.execute(22, new Object[] {n673BancoId, A673BancoId});
            A674BancoNombre = BC000S24_A674BancoNombre[0];
            pr_default.close(22);
            if ( A268ProfesionalesFeedBackCant > 0 )
            {
               A270ProfesionalesFeedback = (decimal)(A269ProfesionalesFeedBackProm/ (decimal)(A268ProfesionalesFeedBackCant));
            }
            else
            {
               A270ProfesionalesFeedback = 0;
            }
            AV14ProfesionalesFeedback = A270ProfesionalesFeedback;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000S25 */
            pr_default.execute(23, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Detalles", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor BC000S26 */
            pr_default.execute(24, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "ProfesionalesRestriccion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor BC000S27 */
            pr_default.execute(25, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Prof Comisiones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor BC000S28 */
            pr_default.execute(26, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Relaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor BC000S29 */
            pr_default.execute(27, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Profesionales", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor BC000S30 */
            pr_default.execute(28, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agrupacion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor BC000S31 */
            pr_default.execute(29, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Profesionales", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
         }
      }

      protected void ProcessNestedLevel0S35( )
      {
         nGXsfl_35_idx = 0;
         while ( nGXsfl_35_idx < bcProfesionales.gxTpr_Rubros.Count )
         {
            ReadRow0S35( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound35 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_35 != 0 ) )
            {
               standaloneNotModal0S35( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0S35( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0S35( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0S35( ) ;
                  }
               }
            }
            KeyVarsToRow35( ((SdtProfesionales_Rubros)bcProfesionales.gxTpr_Rubros.Item(nGXsfl_35_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_35_idx = 0;
            while ( nGXsfl_35_idx < bcProfesionales.gxTpr_Rubros.Count )
            {
               ReadRow0S35( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound35 == 0 )
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
                  bcProfesionales.gxTpr_Rubros.RemoveElement(nGXsfl_35_idx);
                  nGXsfl_35_idx = (int)(nGXsfl_35_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0S35( ) ;
                  VarsToRow35( ((SdtProfesionales_Rubros)bcProfesionales.gxTpr_Rubros.Item(nGXsfl_35_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0S35( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_35 = 0;
         nIsMod_35 = 0;
      }

      protected void ProcessNestedLevel0S36( )
      {
         s197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
         nGXsfl_36_idx = 0;
         while ( nGXsfl_36_idx < bcProfesionales.gxTpr_Zonas.Count )
         {
            ReadRow0S36( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound36 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_36 != 0 ) )
            {
               standaloneNotModal0S36( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0S36( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0S36( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0S36( ) ;
                  }
               }
               O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            }
            KeyVarsToRow36( ((SdtProfesionales_Zonas)bcProfesionales.gxTpr_Zonas.Item(nGXsfl_36_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_36_idx = 0;
            while ( nGXsfl_36_idx < bcProfesionales.gxTpr_Zonas.Count )
            {
               ReadRow0S36( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound36 == 0 )
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
                  bcProfesionales.gxTpr_Zonas.RemoveElement(nGXsfl_36_idx);
                  nGXsfl_36_idx = (int)(nGXsfl_36_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0S36( ) ;
                  VarsToRow36( ((SdtProfesionales_Zonas)bcProfesionales.gxTpr_Zonas.Item(nGXsfl_36_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0S36( ) ;
         if ( AnyError != 0 )
         {
            O197ProfesionalesAutoEnuZona = s197ProfesionalesAutoEnuZona;
         }
         nRcdExists_36 = 0;
         nIsMod_36 = 0;
      }

      protected void ProcessNestedLevel0S145( )
      {
         nGXsfl_145_idx = 0;
         while ( nGXsfl_145_idx < bcProfesionales.gxTpr_Servicios.Count )
         {
            ReadRow0S145( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound145 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_145 != 0 ) )
            {
               standaloneNotModal0S145( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0S145( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0S145( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0S145( ) ;
                  }
               }
            }
            KeyVarsToRow145( ((SdtProfesionales_Servicios)bcProfesionales.gxTpr_Servicios.Item(nGXsfl_145_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_145_idx = 0;
            while ( nGXsfl_145_idx < bcProfesionales.gxTpr_Servicios.Count )
            {
               ReadRow0S145( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound145 == 0 )
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
                  bcProfesionales.gxTpr_Servicios.RemoveElement(nGXsfl_145_idx);
                  nGXsfl_145_idx = (int)(nGXsfl_145_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0S145( ) ;
                  VarsToRow145( ((SdtProfesionales_Servicios)bcProfesionales.gxTpr_Servicios.Item(nGXsfl_145_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0S145( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_145 = 0;
         nIsMod_145 = 0;
      }

      protected void ProcessLevel0S34( )
      {
         /* Save parent mode. */
         sMode34 = Gx_mode;
         ProcessNestedLevel0S35( ) ;
         ProcessNestedLevel0S36( ) ;
         ProcessNestedLevel0S145( ) ;
         if ( AnyError != 0 )
         {
            O197ProfesionalesAutoEnuZona = s197ProfesionalesAutoEnuZona;
         }
         /* Restore parent mode. */
         Gx_mode = sMode34;
         /* ' Update level parameters */
         /* Using cursor BC000S32 */
         pr_default.execute(30, new Object[] {A197ProfesionalesAutoEnuZona, A120ProfesionalesId});
         pr_default.close(30);
         pr_default.SmartCacheProvider.SetUpdated("Profesionales");
      }

      protected void EndLevel0S34( )
      {
         pr_default.close(12);
         if ( AnyError == 0 )
         {
            BeforeComplete0S34( ) ;
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

      public void ScanKeyStart0S34( )
      {
         /* Scan By routine */
         /* Using cursor BC000S33 */
         pr_default.execute(31, new Object[] {A120ProfesionalesId});
         RcdFound34 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound34 = 1;
            A120ProfesionalesId = BC000S33_A120ProfesionalesId[0];
            A199ProfesionalesFechaAlta = BC000S33_A199ProfesionalesFechaAlta[0];
            A200ProfesionalesFechaActualizado = BC000S33_A200ProfesionalesFechaActualizado[0];
            A900ProfesionalesFechaNacimiento = BC000S33_A900ProfesionalesFechaNacimiento[0];
            n900ProfesionalesFechaNacimiento = BC000S33_n900ProfesionalesFechaNacimiento[0];
            A901ProfesionalesRUT = BC000S33_A901ProfesionalesRUT[0];
            n901ProfesionalesRUT = BC000S33_n901ProfesionalesRUT[0];
            A902ProfesionalesTipoEmpresa = BC000S33_A902ProfesionalesTipoEmpresa[0];
            n902ProfesionalesTipoEmpresa = BC000S33_n902ProfesionalesTipoEmpresa[0];
            A676ProfesionalesEsRUT = BC000S33_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = BC000S33_n676ProfesionalesEsRUT[0];
            A166ProfesionalesPrimerNombre = BC000S33_A166ProfesionalesPrimerNombre[0];
            A191ProfesionalesSegundoNombre = BC000S33_A191ProfesionalesSegundoNombre[0];
            A167ProfesionalesApellidoPrimero = BC000S33_A167ProfesionalesApellidoPrimero[0];
            A192ProfesionalesApellidoSegundo = BC000S33_A192ProfesionalesApellidoSegundo[0];
            A40000ProfesionalesPhoto_GXI = BC000S33_A40000ProfesionalesPhoto_GXI[0];
            A170ProfesionalesTelefono = BC000S33_A170ProfesionalesTelefono[0];
            A193ProfesionalesEmail = BC000S33_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = BC000S33_n193ProfesionalesEmail[0];
            A198ProfesionalesDireccion = BC000S33_A198ProfesionalesDireccion[0];
            A267ProfesionalesVerDatPerSol = BC000S33_A267ProfesionalesVerDatPerSol[0];
            A436ProfesionalesPerAltShop = BC000S33_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = BC000S33_n436ProfesionalesPerAltShop[0];
            A196ProfesionalesAutoEnumerar = BC000S33_A196ProfesionalesAutoEnumerar[0];
            A197ProfesionalesAutoEnuZona = BC000S33_A197ProfesionalesAutoEnuZona[0];
            A677ProfesionalesExperiencia = BC000S33_A677ProfesionalesExperiencia[0];
            n677ProfesionalesExperiencia = BC000S33_n677ProfesionalesExperiencia[0];
            A678ProfesionalesAceptoTerminos = BC000S33_A678ProfesionalesAceptoTerminos[0];
            n678ProfesionalesAceptoTerminos = BC000S33_n678ProfesionalesAceptoTerminos[0];
            A679ProfesionalesDeclaroDatosV = BC000S33_A679ProfesionalesDeclaroDatosV[0];
            n679ProfesionalesDeclaroDatosV = BC000S33_n679ProfesionalesDeclaroDatosV[0];
            A680ProfesionalesCuentaBancaria = BC000S33_A680ProfesionalesCuentaBancaria[0];
            n680ProfesionalesCuentaBancaria = BC000S33_n680ProfesionalesCuentaBancaria[0];
            A800ProfesionalesCapacidadProducti = BC000S33_A800ProfesionalesCapacidadProducti[0];
            A674BancoNombre = BC000S33_A674BancoNombre[0];
            A617ProfesionalesLimitOSF = BC000S33_A617ProfesionalesLimitOSF[0];
            n617ProfesionalesLimitOSF = BC000S33_n617ProfesionalesLimitOSF[0];
            A268ProfesionalesFeedBackCant = BC000S33_A268ProfesionalesFeedBackCant[0];
            A269ProfesionalesFeedBackProm = BC000S33_A269ProfesionalesFeedBackProm[0];
            A107EstadosTipo = BC000S33_A107EstadosTipo[0];
            A108EstadosGenericosId = BC000S33_A108EstadosGenericosId[0];
            A673BancoId = BC000S33_A673BancoId[0];
            n673BancoId = BC000S33_n673BancoId[0];
            A169ProfesionalesPhoto = BC000S33_A169ProfesionalesPhoto[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0S34( )
      {
         /* Scan next routine */
         pr_default.readNext(31);
         RcdFound34 = 0;
         ScanKeyLoad0S34( ) ;
      }

      protected void ScanKeyLoad0S34( )
      {
         sMode34 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound34 = 1;
            A120ProfesionalesId = BC000S33_A120ProfesionalesId[0];
            A199ProfesionalesFechaAlta = BC000S33_A199ProfesionalesFechaAlta[0];
            A200ProfesionalesFechaActualizado = BC000S33_A200ProfesionalesFechaActualizado[0];
            A900ProfesionalesFechaNacimiento = BC000S33_A900ProfesionalesFechaNacimiento[0];
            n900ProfesionalesFechaNacimiento = BC000S33_n900ProfesionalesFechaNacimiento[0];
            A901ProfesionalesRUT = BC000S33_A901ProfesionalesRUT[0];
            n901ProfesionalesRUT = BC000S33_n901ProfesionalesRUT[0];
            A902ProfesionalesTipoEmpresa = BC000S33_A902ProfesionalesTipoEmpresa[0];
            n902ProfesionalesTipoEmpresa = BC000S33_n902ProfesionalesTipoEmpresa[0];
            A676ProfesionalesEsRUT = BC000S33_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = BC000S33_n676ProfesionalesEsRUT[0];
            A166ProfesionalesPrimerNombre = BC000S33_A166ProfesionalesPrimerNombre[0];
            A191ProfesionalesSegundoNombre = BC000S33_A191ProfesionalesSegundoNombre[0];
            A167ProfesionalesApellidoPrimero = BC000S33_A167ProfesionalesApellidoPrimero[0];
            A192ProfesionalesApellidoSegundo = BC000S33_A192ProfesionalesApellidoSegundo[0];
            A40000ProfesionalesPhoto_GXI = BC000S33_A40000ProfesionalesPhoto_GXI[0];
            A170ProfesionalesTelefono = BC000S33_A170ProfesionalesTelefono[0];
            A193ProfesionalesEmail = BC000S33_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = BC000S33_n193ProfesionalesEmail[0];
            A198ProfesionalesDireccion = BC000S33_A198ProfesionalesDireccion[0];
            A267ProfesionalesVerDatPerSol = BC000S33_A267ProfesionalesVerDatPerSol[0];
            A436ProfesionalesPerAltShop = BC000S33_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = BC000S33_n436ProfesionalesPerAltShop[0];
            A196ProfesionalesAutoEnumerar = BC000S33_A196ProfesionalesAutoEnumerar[0];
            A197ProfesionalesAutoEnuZona = BC000S33_A197ProfesionalesAutoEnuZona[0];
            A677ProfesionalesExperiencia = BC000S33_A677ProfesionalesExperiencia[0];
            n677ProfesionalesExperiencia = BC000S33_n677ProfesionalesExperiencia[0];
            A678ProfesionalesAceptoTerminos = BC000S33_A678ProfesionalesAceptoTerminos[0];
            n678ProfesionalesAceptoTerminos = BC000S33_n678ProfesionalesAceptoTerminos[0];
            A679ProfesionalesDeclaroDatosV = BC000S33_A679ProfesionalesDeclaroDatosV[0];
            n679ProfesionalesDeclaroDatosV = BC000S33_n679ProfesionalesDeclaroDatosV[0];
            A680ProfesionalesCuentaBancaria = BC000S33_A680ProfesionalesCuentaBancaria[0];
            n680ProfesionalesCuentaBancaria = BC000S33_n680ProfesionalesCuentaBancaria[0];
            A800ProfesionalesCapacidadProducti = BC000S33_A800ProfesionalesCapacidadProducti[0];
            A674BancoNombre = BC000S33_A674BancoNombre[0];
            A617ProfesionalesLimitOSF = BC000S33_A617ProfesionalesLimitOSF[0];
            n617ProfesionalesLimitOSF = BC000S33_n617ProfesionalesLimitOSF[0];
            A268ProfesionalesFeedBackCant = BC000S33_A268ProfesionalesFeedBackCant[0];
            A269ProfesionalesFeedBackProm = BC000S33_A269ProfesionalesFeedBackProm[0];
            A107EstadosTipo = BC000S33_A107EstadosTipo[0];
            A108EstadosGenericosId = BC000S33_A108EstadosGenericosId[0];
            A673BancoId = BC000S33_A673BancoId[0];
            n673BancoId = BC000S33_n673BancoId[0];
            A169ProfesionalesPhoto = BC000S33_A169ProfesionalesPhoto[0];
         }
         Gx_mode = sMode34;
      }

      protected void ScanKeyEnd0S34( )
      {
         pr_default.close(31);
      }

      protected void AfterConfirm0S34( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0S34( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0S34( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0S34( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0S34( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0S34( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0S34( )
      {
      }

      protected void ZM0S35( short GX_JID )
      {
         if ( ( GX_JID == 30 ) || ( GX_JID == 0 ) )
         {
            Z124EstadosProfRubTipo = A124EstadosProfRubTipo;
            Z125EstadosProfRubId = A125EstadosProfRubId;
         }
         if ( ( GX_JID == 31 ) || ( GX_JID == 0 ) )
         {
            Z122RubrosNombre = A122RubrosNombre;
            Z123RubrosEstado = A123RubrosEstado;
         }
         if ( ( GX_JID == 32 ) || ( GX_JID == 0 ) )
         {
            Z221EstadosProfRubNomb = A221EstadosProfRubNomb;
         }
         if ( GX_JID == -30 )
         {
            Z120ProfesionalesId = A120ProfesionalesId;
            Z121RubrosId = A121RubrosId;
            Z124EstadosProfRubTipo = A124EstadosProfRubTipo;
            Z125EstadosProfRubId = A125EstadosProfRubId;
            Z122RubrosNombre = A122RubrosNombre;
            Z168RubrosImagen = A168RubrosImagen;
            Z40001RubrosImagen_GXI = A40001RubrosImagen_GXI;
            Z123RubrosEstado = A123RubrosEstado;
            Z221EstadosProfRubNomb = A221EstadosProfRubNomb;
         }
      }

      protected void standaloneNotModal0S35( )
      {
      }

      protected void standaloneModal0S35( )
      {
         A124EstadosProfRubTipo = context.GetMessage( context.GetMessage( "STS", ""), "");
         if ( IsIns( )  )
         {
            A125EstadosProfRubId = 1;
         }
         if ( IsIns( )  && (0==A121RubrosId) && ( Gx_BScreen == 0 ) )
         {
            A121RubrosId = 0;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor BC000S13 */
            pr_default.execute(11, new Object[] {A124EstadosProfRubTipo, A125EstadosProfRubId});
            A221EstadosProfRubNomb = BC000S13_A221EstadosProfRubNomb[0];
            pr_default.close(11);
            /* Using cursor BC000S12 */
            pr_default.execute(10, new Object[] {A121RubrosId});
            A122RubrosNombre = BC000S12_A122RubrosNombre[0];
            A40001RubrosImagen_GXI = BC000S12_A40001RubrosImagen_GXI[0];
            A123RubrosEstado = BC000S12_A123RubrosEstado[0];
            n123RubrosEstado = BC000S12_n123RubrosEstado[0];
            A168RubrosImagen = BC000S12_A168RubrosImagen[0];
            pr_default.close(10);
         }
      }

      protected void Load0S35( )
      {
         /* Using cursor BC000S34 */
         pr_default.execute(32, new Object[] {A120ProfesionalesId, A121RubrosId});
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound35 = 1;
            A122RubrosNombre = BC000S34_A122RubrosNombre[0];
            A40001RubrosImagen_GXI = BC000S34_A40001RubrosImagen_GXI[0];
            A123RubrosEstado = BC000S34_A123RubrosEstado[0];
            n123RubrosEstado = BC000S34_n123RubrosEstado[0];
            A221EstadosProfRubNomb = BC000S34_A221EstadosProfRubNomb[0];
            A124EstadosProfRubTipo = BC000S34_A124EstadosProfRubTipo[0];
            A125EstadosProfRubId = BC000S34_A125EstadosProfRubId[0];
            A168RubrosImagen = BC000S34_A168RubrosImagen[0];
            ZM0S35( -30) ;
         }
         pr_default.close(32);
         OnLoadActions0S35( ) ;
      }

      protected void OnLoadActions0S35( )
      {
      }

      protected void CheckExtendedTable0S35( )
      {
         Gx_BScreen = 1;
         standaloneModal0S35( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000S12 */
         pr_default.execute(10, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RUBROSID");
            AnyError = 1;
         }
         A122RubrosNombre = BC000S12_A122RubrosNombre[0];
         A40001RubrosImagen_GXI = BC000S12_A40001RubrosImagen_GXI[0];
         A123RubrosEstado = BC000S12_A123RubrosEstado[0];
         n123RubrosEstado = BC000S12_n123RubrosEstado[0];
         A168RubrosImagen = BC000S12_A168RubrosImagen[0];
         pr_default.close(10);
         /* Using cursor BC000S13 */
         pr_default.execute(11, new Object[] {A124EstadosProfRubTipo, A125EstadosProfRubId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados Prof Rub", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSPROFRUBID");
            AnyError = 1;
         }
         A221EstadosProfRubNomb = BC000S13_A221EstadosProfRubNomb[0];
         pr_default.close(11);
      }

      protected void CloseExtendedTableCursors0S35( )
      {
         pr_default.close(10);
         pr_default.close(11);
      }

      protected void enableDisable0S35( )
      {
      }

      protected void GetKey0S35( )
      {
         /* Using cursor BC000S35 */
         pr_default.execute(33, new Object[] {A120ProfesionalesId, A121RubrosId});
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound35 = 1;
         }
         else
         {
            RcdFound35 = 0;
         }
         pr_default.close(33);
      }

      protected void getByPrimaryKey0S35( )
      {
         /* Using cursor BC000S11 */
         pr_default.execute(9, new Object[] {A120ProfesionalesId, A121RubrosId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            ZM0S35( 30) ;
            RcdFound35 = 1;
            InitializeNonKey0S35( ) ;
            A121RubrosId = BC000S11_A121RubrosId[0];
            A124EstadosProfRubTipo = BC000S11_A124EstadosProfRubTipo[0];
            A125EstadosProfRubId = BC000S11_A125EstadosProfRubId[0];
            Z120ProfesionalesId = A120ProfesionalesId;
            Z121RubrosId = A121RubrosId;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0S35( ) ;
            Load0S35( ) ;
            Gx_mode = sMode35;
         }
         else
         {
            RcdFound35 = 0;
            InitializeNonKey0S35( ) ;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0S35( ) ;
            Gx_mode = sMode35;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0S35( ) ;
         }
         pr_default.close(9);
      }

      protected void CheckOptimisticConcurrency0S35( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000S10 */
            pr_default.execute(8, new Object[] {A120ProfesionalesId, A121RubrosId});
            if ( (pr_default.getStatus(8) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesRubros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(8) == 101) || ( StringUtil.StrCmp(Z124EstadosProfRubTipo, BC000S10_A124EstadosProfRubTipo[0]) != 0 ) || ( Z125EstadosProfRubId != BC000S10_A125EstadosProfRubId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProfesionalesRubros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0S35( )
      {
         BeforeValidate0S35( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S35( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0S35( 0) ;
            CheckOptimisticConcurrency0S35( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S35( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0S35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000S36 */
                     pr_default.execute(34, new Object[] {A120ProfesionalesId, A121RubrosId, A124EstadosProfRubTipo, A125EstadosProfRubId});
                     pr_default.close(34);
                     pr_default.SmartCacheProvider.SetUpdated("ProfesionalesRubros");
                     if ( (pr_default.getStatus(34) == 1) )
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
               Load0S35( ) ;
            }
            EndLevel0S35( ) ;
         }
         CloseExtendedTableCursors0S35( ) ;
      }

      protected void Update0S35( )
      {
         BeforeValidate0S35( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S35( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S35( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S35( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0S35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000S37 */
                     pr_default.execute(35, new Object[] {A124EstadosProfRubTipo, A125EstadosProfRubId, A120ProfesionalesId, A121RubrosId});
                     pr_default.close(35);
                     pr_default.SmartCacheProvider.SetUpdated("ProfesionalesRubros");
                     if ( (pr_default.getStatus(35) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesRubros"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0S35( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0S35( ) ;
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
            EndLevel0S35( ) ;
         }
         CloseExtendedTableCursors0S35( ) ;
      }

      protected void DeferredUpdate0S35( )
      {
      }

      protected void Delete0S35( )
      {
         Gx_mode = "DLT";
         BeforeValidate0S35( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S35( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0S35( ) ;
            AfterConfirm0S35( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0S35( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000S38 */
                  pr_default.execute(36, new Object[] {A120ProfesionalesId, A121RubrosId});
                  pr_default.close(36);
                  pr_default.SmartCacheProvider.SetUpdated("ProfesionalesRubros");
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
         sMode35 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0S35( ) ;
         Gx_mode = sMode35;
      }

      protected void OnDeleteControls0S35( )
      {
         standaloneModal0S35( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000S39 */
            pr_default.execute(37, new Object[] {A121RubrosId});
            A122RubrosNombre = BC000S39_A122RubrosNombre[0];
            A40001RubrosImagen_GXI = BC000S39_A40001RubrosImagen_GXI[0];
            A123RubrosEstado = BC000S39_A123RubrosEstado[0];
            n123RubrosEstado = BC000S39_n123RubrosEstado[0];
            A168RubrosImagen = BC000S39_A168RubrosImagen[0];
            pr_default.close(37);
            /* Using cursor BC000S40 */
            pr_default.execute(38, new Object[] {A124EstadosProfRubTipo, A125EstadosProfRubId});
            A221EstadosProfRubNomb = BC000S40_A221EstadosProfRubNomb[0];
            pr_default.close(38);
         }
      }

      protected void EndLevel0S35( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(8);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0S35( )
      {
         /* Scan By routine */
         /* Using cursor BC000S41 */
         pr_default.execute(39, new Object[] {A120ProfesionalesId});
         RcdFound35 = 0;
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound35 = 1;
            A122RubrosNombre = BC000S41_A122RubrosNombre[0];
            A40001RubrosImagen_GXI = BC000S41_A40001RubrosImagen_GXI[0];
            A123RubrosEstado = BC000S41_A123RubrosEstado[0];
            n123RubrosEstado = BC000S41_n123RubrosEstado[0];
            A221EstadosProfRubNomb = BC000S41_A221EstadosProfRubNomb[0];
            A121RubrosId = BC000S41_A121RubrosId[0];
            A124EstadosProfRubTipo = BC000S41_A124EstadosProfRubTipo[0];
            A125EstadosProfRubId = BC000S41_A125EstadosProfRubId[0];
            A168RubrosImagen = BC000S41_A168RubrosImagen[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0S35( )
      {
         /* Scan next routine */
         pr_default.readNext(39);
         RcdFound35 = 0;
         ScanKeyLoad0S35( ) ;
      }

      protected void ScanKeyLoad0S35( )
      {
         sMode35 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound35 = 1;
            A122RubrosNombre = BC000S41_A122RubrosNombre[0];
            A40001RubrosImagen_GXI = BC000S41_A40001RubrosImagen_GXI[0];
            A123RubrosEstado = BC000S41_A123RubrosEstado[0];
            n123RubrosEstado = BC000S41_n123RubrosEstado[0];
            A221EstadosProfRubNomb = BC000S41_A221EstadosProfRubNomb[0];
            A121RubrosId = BC000S41_A121RubrosId[0];
            A124EstadosProfRubTipo = BC000S41_A124EstadosProfRubTipo[0];
            A125EstadosProfRubId = BC000S41_A125EstadosProfRubId[0];
            A168RubrosImagen = BC000S41_A168RubrosImagen[0];
         }
         Gx_mode = sMode35;
      }

      protected void ScanKeyEnd0S35( )
      {
         pr_default.close(39);
      }

      protected void AfterConfirm0S35( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0S35( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0S35( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0S35( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0S35( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0S35( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0S35( )
      {
      }

      protected void send_integrity_lvl_hashes0S35( )
      {
      }

      protected void ZM0S36( short GX_JID )
      {
         if ( ( GX_JID == 33 ) || ( GX_JID == 0 ) )
         {
            Z112DepartamentoId = A112DepartamentoId;
            Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            Z110ZonasID = A110ZonasID;
         }
         if ( ( GX_JID == 34 ) || ( GX_JID == 0 ) )
         {
            Z113DepartamentoDepartamento = A113DepartamentoDepartamento;
            Z116PaisID = A116PaisID;
         }
         if ( ( GX_JID == 35 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 36 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -33 )
         {
            Z120ProfesionalesId = A120ProfesionalesId;
            Z126ProfesionalesZonasCorrelativo = A126ProfesionalesZonasCorrelativo;
            Z112DepartamentoId = A112DepartamentoId;
            Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            Z110ZonasID = A110ZonasID;
            Z113DepartamentoDepartamento = A113DepartamentoDepartamento;
            Z116PaisID = A116PaisID;
         }
      }

      protected void standaloneNotModal0S36( )
      {
      }

      protected void standaloneModal0S36( )
      {
         if ( IsIns( )  )
         {
            A197ProfesionalesAutoEnuZona = (short)(O197ProfesionalesAutoEnuZona+1);
         }
         if ( IsIns( )  )
         {
            A126ProfesionalesZonasCorrelativo = A197ProfesionalesAutoEnuZona;
         }
         else
         {
            if ( IsIns( )  && (0==A126ProfesionalesZonasCorrelativo) && ( Gx_BScreen == 0 ) )
            {
               A126ProfesionalesZonasCorrelativo = 0;
            }
         }
      }

      protected void Load0S36( )
      {
         /* Using cursor BC000S42 */
         pr_default.execute(40, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound36 = 1;
            A113DepartamentoDepartamento = BC000S42_A113DepartamentoDepartamento[0];
            A112DepartamentoId = BC000S42_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = BC000S42_A114DepartamentoMunicipioId[0];
            A110ZonasID = BC000S42_A110ZonasID[0];
            n110ZonasID = BC000S42_n110ZonasID[0];
            A116PaisID = BC000S42_A116PaisID[0];
            ZM0S36( -33) ;
         }
         pr_default.close(40);
         OnLoadActions0S36( ) ;
      }

      protected void OnLoadActions0S36( )
      {
      }

      protected void CheckExtendedTable0S36( )
      {
         Gx_BScreen = 1;
         standaloneModal0S36( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000S7 */
         pr_default.execute(5, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
            AnyError = 1;
         }
         A113DepartamentoDepartamento = BC000S7_A113DepartamentoDepartamento[0];
         A116PaisID = BC000S7_A116PaisID[0];
         pr_default.close(5);
         /* Using cursor BC000S8 */
         pr_default.execute(6, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
            AnyError = 1;
         }
         pr_default.close(6);
         /* Using cursor BC000S9 */
         pr_default.execute(7, new Object[] {n110ZonasID, A110ZonasID, A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A110ZonasID) || (0==A112DepartamentoId) || (0==A114DepartamentoMunicipioId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Zonas", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
               AnyError = 1;
            }
         }
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors0S36( )
      {
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable0S36( )
      {
      }

      protected void GetKey0S36( )
      {
         /* Using cursor BC000S43 */
         pr_default.execute(41, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
         if ( (pr_default.getStatus(41) != 101) )
         {
            RcdFound36 = 1;
         }
         else
         {
            RcdFound36 = 0;
         }
         pr_default.close(41);
      }

      protected void getByPrimaryKey0S36( )
      {
         /* Using cursor BC000S6 */
         pr_default.execute(4, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0S36( 33) ;
            RcdFound36 = 1;
            InitializeNonKey0S36( ) ;
            A126ProfesionalesZonasCorrelativo = BC000S6_A126ProfesionalesZonasCorrelativo[0];
            A112DepartamentoId = BC000S6_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = BC000S6_A114DepartamentoMunicipioId[0];
            A110ZonasID = BC000S6_A110ZonasID[0];
            n110ZonasID = BC000S6_n110ZonasID[0];
            Z120ProfesionalesId = A120ProfesionalesId;
            Z126ProfesionalesZonasCorrelativo = A126ProfesionalesZonasCorrelativo;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0S36( ) ;
            Load0S36( ) ;
            Gx_mode = sMode36;
         }
         else
         {
            RcdFound36 = 0;
            InitializeNonKey0S36( ) ;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0S36( ) ;
            Gx_mode = sMode36;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0S36( ) ;
         }
         pr_default.close(4);
      }

      protected void CheckOptimisticConcurrency0S36( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000S5 */
            pr_default.execute(3, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesZonas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( Z112DepartamentoId != BC000S5_A112DepartamentoId[0] ) || ( Z114DepartamentoMunicipioId != BC000S5_A114DepartamentoMunicipioId[0] ) || ( Z110ZonasID != BC000S5_A110ZonasID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProfesionalesZonas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0S36( )
      {
         BeforeValidate0S36( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S36( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0S36( 0) ;
            CheckOptimisticConcurrency0S36( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S36( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0S36( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000S44 */
                     pr_default.execute(42, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo, A112DepartamentoId, A114DepartamentoMunicipioId, n110ZonasID, A110ZonasID});
                     pr_default.close(42);
                     pr_default.SmartCacheProvider.SetUpdated("ProfesionalesZonas");
                     if ( (pr_default.getStatus(42) == 1) )
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
               Load0S36( ) ;
            }
            EndLevel0S36( ) ;
         }
         CloseExtendedTableCursors0S36( ) ;
      }

      protected void Update0S36( )
      {
         BeforeValidate0S36( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S36( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S36( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S36( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0S36( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000S45 */
                     pr_default.execute(43, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId, n110ZonasID, A110ZonasID, A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
                     pr_default.close(43);
                     pr_default.SmartCacheProvider.SetUpdated("ProfesionalesZonas");
                     if ( (pr_default.getStatus(43) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesZonas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0S36( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0S36( ) ;
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
            EndLevel0S36( ) ;
         }
         CloseExtendedTableCursors0S36( ) ;
      }

      protected void DeferredUpdate0S36( )
      {
      }

      protected void Delete0S36( )
      {
         Gx_mode = "DLT";
         BeforeValidate0S36( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S36( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0S36( ) ;
            AfterConfirm0S36( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0S36( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000S46 */
                  pr_default.execute(44, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
                  pr_default.close(44);
                  pr_default.SmartCacheProvider.SetUpdated("ProfesionalesZonas");
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
         sMode36 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0S36( ) ;
         Gx_mode = sMode36;
      }

      protected void OnDeleteControls0S36( )
      {
         standaloneModal0S36( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000S47 */
            pr_default.execute(45, new Object[] {A112DepartamentoId});
            A113DepartamentoDepartamento = BC000S47_A113DepartamentoDepartamento[0];
            A116PaisID = BC000S47_A116PaisID[0];
            pr_default.close(45);
         }
      }

      protected void EndLevel0S36( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0S36( )
      {
         /* Scan By routine */
         /* Using cursor BC000S48 */
         pr_default.execute(46, new Object[] {A120ProfesionalesId});
         RcdFound36 = 0;
         if ( (pr_default.getStatus(46) != 101) )
         {
            RcdFound36 = 1;
            A126ProfesionalesZonasCorrelativo = BC000S48_A126ProfesionalesZonasCorrelativo[0];
            A113DepartamentoDepartamento = BC000S48_A113DepartamentoDepartamento[0];
            A112DepartamentoId = BC000S48_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = BC000S48_A114DepartamentoMunicipioId[0];
            A110ZonasID = BC000S48_A110ZonasID[0];
            n110ZonasID = BC000S48_n110ZonasID[0];
            A116PaisID = BC000S48_A116PaisID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0S36( )
      {
         /* Scan next routine */
         pr_default.readNext(46);
         RcdFound36 = 0;
         ScanKeyLoad0S36( ) ;
      }

      protected void ScanKeyLoad0S36( )
      {
         sMode36 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(46) != 101) )
         {
            RcdFound36 = 1;
            A126ProfesionalesZonasCorrelativo = BC000S48_A126ProfesionalesZonasCorrelativo[0];
            A113DepartamentoDepartamento = BC000S48_A113DepartamentoDepartamento[0];
            A112DepartamentoId = BC000S48_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = BC000S48_A114DepartamentoMunicipioId[0];
            A110ZonasID = BC000S48_A110ZonasID[0];
            n110ZonasID = BC000S48_n110ZonasID[0];
            A116PaisID = BC000S48_A116PaisID[0];
         }
         Gx_mode = sMode36;
      }

      protected void ScanKeyEnd0S36( )
      {
         pr_default.close(46);
      }

      protected void AfterConfirm0S36( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0S36( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0S36( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0S36( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0S36( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0S36( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0S36( )
      {
      }

      protected void send_integrity_lvl_hashes0S36( )
      {
      }

      protected void ZM0S145( short GX_JID )
      {
         if ( ( GX_JID == 37 ) || ( GX_JID == 0 ) )
         {
            Z995EstadoServProf = A995EstadoServProf;
         }
         if ( ( GX_JID == 38 ) || ( GX_JID == 0 ) )
         {
            Z994ProfesionalServicioNombre = A994ProfesionalServicioNombre;
         }
         if ( GX_JID == -37 )
         {
            Z120ProfesionalesId = A120ProfesionalesId;
            Z995EstadoServProf = A995EstadoServProf;
            Z993ProfesionalServicioId = A993ProfesionalServicioId;
            Z994ProfesionalServicioNombre = A994ProfesionalServicioNombre;
         }
      }

      protected void standaloneNotModal0S145( )
      {
      }

      protected void standaloneModal0S145( )
      {
      }

      protected void Load0S145( )
      {
         /* Using cursor BC000S49 */
         pr_default.execute(47, new Object[] {A120ProfesionalesId, A993ProfesionalServicioId});
         if ( (pr_default.getStatus(47) != 101) )
         {
            RcdFound145 = 1;
            A994ProfesionalServicioNombre = BC000S49_A994ProfesionalServicioNombre[0];
            A995EstadoServProf = BC000S49_A995EstadoServProf[0];
            n995EstadoServProf = BC000S49_n995EstadoServProf[0];
            ZM0S145( -37) ;
         }
         pr_default.close(47);
         OnLoadActions0S145( ) ;
      }

      protected void OnLoadActions0S145( )
      {
      }

      protected void CheckExtendedTable0S145( )
      {
         Gx_BScreen = 1;
         standaloneModal0S145( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000S4 */
         pr_default.execute(2, new Object[] {A993ProfesionalServicioId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesional Servicios Brindados", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROFESIONALSERVICIOID");
            AnyError = 1;
         }
         A994ProfesionalServicioNombre = BC000S4_A994ProfesionalServicioNombre[0];
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A995EstadoServProf, "HAB") == 0 ) || ( StringUtil.StrCmp(A995EstadoServProf, "DES") == 0 ) || ( StringUtil.StrCmp(A995EstadoServProf, "PEN") == 0 ) || ( StringUtil.StrCmp(A995EstadoServProf, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A995EstadoServProf)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado vinculo servicio profesional", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0S145( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0S145( )
      {
      }

      protected void GetKey0S145( )
      {
         /* Using cursor BC000S50 */
         pr_default.execute(48, new Object[] {A120ProfesionalesId, A993ProfesionalServicioId});
         if ( (pr_default.getStatus(48) != 101) )
         {
            RcdFound145 = 1;
         }
         else
         {
            RcdFound145 = 0;
         }
         pr_default.close(48);
      }

      protected void getByPrimaryKey0S145( )
      {
         /* Using cursor BC000S3 */
         pr_default.execute(1, new Object[] {A120ProfesionalesId, A993ProfesionalServicioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0S145( 37) ;
            RcdFound145 = 1;
            InitializeNonKey0S145( ) ;
            A995EstadoServProf = BC000S3_A995EstadoServProf[0];
            n995EstadoServProf = BC000S3_n995EstadoServProf[0];
            A993ProfesionalServicioId = BC000S3_A993ProfesionalServicioId[0];
            Z120ProfesionalesId = A120ProfesionalesId;
            Z993ProfesionalServicioId = A993ProfesionalServicioId;
            sMode145 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0S145( ) ;
            Load0S145( ) ;
            Gx_mode = sMode145;
         }
         else
         {
            RcdFound145 = 0;
            InitializeNonKey0S145( ) ;
            sMode145 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0S145( ) ;
            Gx_mode = sMode145;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0S145( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0S145( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000S2 */
            pr_default.execute(0, new Object[] {A120ProfesionalesId, A993ProfesionalServicioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesServicios"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z995EstadoServProf, BC000S2_A995EstadoServProf[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProfesionalesServicios"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0S145( )
      {
         BeforeValidate0S145( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S145( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0S145( 0) ;
            CheckOptimisticConcurrency0S145( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S145( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0S145( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000S51 */
                     pr_default.execute(49, new Object[] {A120ProfesionalesId, n995EstadoServProf, A995EstadoServProf, A993ProfesionalServicioId});
                     pr_default.close(49);
                     pr_default.SmartCacheProvider.SetUpdated("ProfesionalesServicios");
                     if ( (pr_default.getStatus(49) == 1) )
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
               Load0S145( ) ;
            }
            EndLevel0S145( ) ;
         }
         CloseExtendedTableCursors0S145( ) ;
      }

      protected void Update0S145( )
      {
         BeforeValidate0S145( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S145( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S145( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S145( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0S145( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000S52 */
                     pr_default.execute(50, new Object[] {n995EstadoServProf, A995EstadoServProf, A120ProfesionalesId, A993ProfesionalServicioId});
                     pr_default.close(50);
                     pr_default.SmartCacheProvider.SetUpdated("ProfesionalesServicios");
                     if ( (pr_default.getStatus(50) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesServicios"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0S145( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0S145( ) ;
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
            EndLevel0S145( ) ;
         }
         CloseExtendedTableCursors0S145( ) ;
      }

      protected void DeferredUpdate0S145( )
      {
      }

      protected void Delete0S145( )
      {
         Gx_mode = "DLT";
         BeforeValidate0S145( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S145( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0S145( ) ;
            AfterConfirm0S145( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0S145( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000S53 */
                  pr_default.execute(51, new Object[] {A120ProfesionalesId, A993ProfesionalServicioId});
                  pr_default.close(51);
                  pr_default.SmartCacheProvider.SetUpdated("ProfesionalesServicios");
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
         sMode145 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0S145( ) ;
         Gx_mode = sMode145;
      }

      protected void OnDeleteControls0S145( )
      {
         standaloneModal0S145( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000S54 */
            pr_default.execute(52, new Object[] {A993ProfesionalServicioId});
            A994ProfesionalServicioNombre = BC000S54_A994ProfesionalServicioNombre[0];
            pr_default.close(52);
         }
      }

      protected void EndLevel0S145( )
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

      public void ScanKeyStart0S145( )
      {
         /* Scan By routine */
         /* Using cursor BC000S55 */
         pr_default.execute(53, new Object[] {A120ProfesionalesId});
         RcdFound145 = 0;
         if ( (pr_default.getStatus(53) != 101) )
         {
            RcdFound145 = 1;
            A994ProfesionalServicioNombre = BC000S55_A994ProfesionalServicioNombre[0];
            A995EstadoServProf = BC000S55_A995EstadoServProf[0];
            n995EstadoServProf = BC000S55_n995EstadoServProf[0];
            A993ProfesionalServicioId = BC000S55_A993ProfesionalServicioId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0S145( )
      {
         /* Scan next routine */
         pr_default.readNext(53);
         RcdFound145 = 0;
         ScanKeyLoad0S145( ) ;
      }

      protected void ScanKeyLoad0S145( )
      {
         sMode145 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(53) != 101) )
         {
            RcdFound145 = 1;
            A994ProfesionalServicioNombre = BC000S55_A994ProfesionalServicioNombre[0];
            A995EstadoServProf = BC000S55_A995EstadoServProf[0];
            n995EstadoServProf = BC000S55_n995EstadoServProf[0];
            A993ProfesionalServicioId = BC000S55_A993ProfesionalServicioId[0];
         }
         Gx_mode = sMode145;
      }

      protected void ScanKeyEnd0S145( )
      {
         pr_default.close(53);
      }

      protected void AfterConfirm0S145( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0S145( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0S145( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0S145( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0S145( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0S145( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0S145( )
      {
      }

      protected void send_integrity_lvl_hashes0S145( )
      {
      }

      protected void send_integrity_lvl_hashes0S34( )
      {
      }

      protected void AddRow0S34( )
      {
         VarsToRow34( bcProfesionales) ;
      }

      protected void ReadRow0S34( )
      {
         RowToVars34( bcProfesionales, 1) ;
      }

      protected void AddRow0S35( )
      {
         SdtProfesionales_Rubros obj35;
         obj35 = new SdtProfesionales_Rubros(context);
         VarsToRow35( obj35) ;
         bcProfesionales.gxTpr_Rubros.Add(obj35, 0);
         obj35.gxTpr_Mode = "UPD";
         obj35.gxTpr_Modified = 0;
      }

      protected void ReadRow0S35( )
      {
         nGXsfl_35_idx = (int)(nGXsfl_35_idx+1);
         RowToVars35( ((SdtProfesionales_Rubros)bcProfesionales.gxTpr_Rubros.Item(nGXsfl_35_idx)), 1) ;
      }

      protected void AddRow0S36( )
      {
         SdtProfesionales_Zonas obj36;
         obj36 = new SdtProfesionales_Zonas(context);
         VarsToRow36( obj36) ;
         bcProfesionales.gxTpr_Zonas.Add(obj36, 0);
         obj36.gxTpr_Mode = "UPD";
         obj36.gxTpr_Modified = 0;
      }

      protected void ReadRow0S36( )
      {
         nGXsfl_36_idx = (int)(nGXsfl_36_idx+1);
         RowToVars36( ((SdtProfesionales_Zonas)bcProfesionales.gxTpr_Zonas.Item(nGXsfl_36_idx)), 1) ;
      }

      protected void AddRow0S145( )
      {
         SdtProfesionales_Servicios obj145;
         obj145 = new SdtProfesionales_Servicios(context);
         VarsToRow145( obj145) ;
         bcProfesionales.gxTpr_Servicios.Add(obj145, 0);
         obj145.gxTpr_Mode = "UPD";
         obj145.gxTpr_Modified = 0;
      }

      protected void ReadRow0S145( )
      {
         nGXsfl_145_idx = (int)(nGXsfl_145_idx+1);
         RowToVars145( ((SdtProfesionales_Servicios)bcProfesionales.gxTpr_Servicios.Item(nGXsfl_145_idx)), 1) ;
      }

      protected void InitializeNonKey0S34( )
      {
         A107EstadosTipo = "";
         A108EstadosGenericosId = 0;
         A199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         A200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         AV14ProfesionalesFeedback = 0;
         A270ProfesionalesFeedback = 0;
         A803ProfesionalesTiempoDisponible = 0;
         A886ProfesionalesNombreCompleto = "";
         A900ProfesionalesFechaNacimiento = DateTime.MinValue;
         n900ProfesionalesFechaNacimiento = false;
         A901ProfesionalesRUT = "";
         n901ProfesionalesRUT = false;
         A902ProfesionalesTipoEmpresa = 0;
         n902ProfesionalesTipoEmpresa = false;
         A676ProfesionalesEsRUT = false;
         n676ProfesionalesEsRUT = false;
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A169ProfesionalesPhoto = "";
         A40000ProfesionalesPhoto_GXI = "";
         A170ProfesionalesTelefono = "";
         A193ProfesionalesEmail = "";
         n193ProfesionalesEmail = false;
         A198ProfesionalesDireccion = "";
         A196ProfesionalesAutoEnumerar = 0;
         A197ProfesionalesAutoEnuZona = 0;
         A677ProfesionalesExperiencia = "";
         n677ProfesionalesExperiencia = false;
         A678ProfesionalesAceptoTerminos = (DateTime)(DateTime.MinValue);
         n678ProfesionalesAceptoTerminos = false;
         A679ProfesionalesDeclaroDatosV = (DateTime)(DateTime.MinValue);
         n679ProfesionalesDeclaroDatosV = false;
         A680ProfesionalesCuentaBancaria = "";
         n680ProfesionalesCuentaBancaria = false;
         A673BancoId = 0;
         n673BancoId = false;
         A674BancoNombre = "";
         A617ProfesionalesLimitOSF = 0;
         n617ProfesionalesLimitOSF = false;
         A268ProfesionalesFeedBackCant = 0;
         A269ProfesionalesFeedBackProm = 0;
         A267ProfesionalesVerDatPerSol = context.GetMessage( "N", "");
         A436ProfesionalesPerAltShop = context.GetMessage( "N", "");
         n436ProfesionalesPerAltShop = false;
         A800ProfesionalesCapacidadProducti = (decimal)(8);
         O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
         Z199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         Z200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         Z900ProfesionalesFechaNacimiento = DateTime.MinValue;
         Z901ProfesionalesRUT = "";
         Z902ProfesionalesTipoEmpresa = 0;
         Z676ProfesionalesEsRUT = false;
         Z166ProfesionalesPrimerNombre = "";
         Z191ProfesionalesSegundoNombre = "";
         Z167ProfesionalesApellidoPrimero = "";
         Z192ProfesionalesApellidoSegundo = "";
         Z170ProfesionalesTelefono = "";
         Z193ProfesionalesEmail = "";
         Z198ProfesionalesDireccion = "";
         Z267ProfesionalesVerDatPerSol = "";
         Z436ProfesionalesPerAltShop = "";
         Z196ProfesionalesAutoEnumerar = 0;
         Z197ProfesionalesAutoEnuZona = 0;
         Z677ProfesionalesExperiencia = "";
         Z678ProfesionalesAceptoTerminos = (DateTime)(DateTime.MinValue);
         Z679ProfesionalesDeclaroDatosV = (DateTime)(DateTime.MinValue);
         Z680ProfesionalesCuentaBancaria = "";
         Z800ProfesionalesCapacidadProducti = 0;
         Z617ProfesionalesLimitOSF = 0;
         Z268ProfesionalesFeedBackCant = 0;
         Z269ProfesionalesFeedBackProm = 0;
         Z107EstadosTipo = "";
         Z108EstadosGenericosId = 0;
         Z673BancoId = 0;
      }

      protected void InitAll0S34( )
      {
         A120ProfesionalesId = "";
         InitializeNonKey0S34( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A107EstadosTipo = i107EstadosTipo;
         A108EstadosGenericosId = i108EstadosGenericosId;
         A199ProfesionalesFechaAlta = i199ProfesionalesFechaAlta;
         A200ProfesionalesFechaActualizado = i200ProfesionalesFechaActualizado;
         A267ProfesionalesVerDatPerSol = i267ProfesionalesVerDatPerSol;
         A436ProfesionalesPerAltShop = i436ProfesionalesPerAltShop;
         n436ProfesionalesPerAltShop = false;
         A800ProfesionalesCapacidadProducti = i800ProfesionalesCapacidadProducti;
      }

      protected void InitializeNonKey0S35( )
      {
         A124EstadosProfRubTipo = "";
         A125EstadosProfRubId = 0;
         A122RubrosNombre = "";
         A168RubrosImagen = "";
         A40001RubrosImagen_GXI = "";
         A123RubrosEstado = "";
         n123RubrosEstado = false;
         A221EstadosProfRubNomb = "";
         Z124EstadosProfRubTipo = "";
         Z125EstadosProfRubId = 0;
      }

      protected void InitAll0S35( )
      {
         A121RubrosId = 0;
         InitializeNonKey0S35( ) ;
      }

      protected void StandaloneModalInsert0S35( )
      {
         A124EstadosProfRubTipo = i124EstadosProfRubTipo;
         A125EstadosProfRubId = i125EstadosProfRubId;
      }

      protected void InitializeNonKey0S36( )
      {
         A116PaisID = "";
         A112DepartamentoId = 0;
         A113DepartamentoDepartamento = "";
         A114DepartamentoMunicipioId = 0;
         A110ZonasID = 0;
         n110ZonasID = false;
         Z112DepartamentoId = 0;
         Z114DepartamentoMunicipioId = 0;
         Z110ZonasID = 0;
      }

      protected void InitAll0S36( )
      {
         A126ProfesionalesZonasCorrelativo = 0;
         InitializeNonKey0S36( ) ;
      }

      protected void StandaloneModalInsert0S36( )
      {
         A197ProfesionalesAutoEnuZona = i197ProfesionalesAutoEnuZona;
      }

      protected void InitializeNonKey0S145( )
      {
         A994ProfesionalServicioNombre = "";
         A995EstadoServProf = "";
         n995EstadoServProf = false;
         Z995EstadoServProf = "";
      }

      protected void InitAll0S145( )
      {
         A993ProfesionalServicioId = 0;
         InitializeNonKey0S145( ) ;
      }

      protected void StandaloneModalInsert0S145( )
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

      public void VarsToRow34( SdtProfesionales obj34 )
      {
         obj34.gxTpr_Mode = Gx_mode;
         obj34.gxTpr_Estadostipo = A107EstadosTipo;
         obj34.gxTpr_Estadosgenericosid = A108EstadosGenericosId;
         obj34.gxTpr_Profesionalesfechaalta = A199ProfesionalesFechaAlta;
         obj34.gxTpr_Profesionalesfechaactualizado = A200ProfesionalesFechaActualizado;
         obj34.gxTpr_Profesionalesfeedback = A270ProfesionalesFeedback;
         obj34.gxTpr_Profesionalestiempodisponible = A803ProfesionalesTiempoDisponible;
         obj34.gxTpr_Profesionalesnombrecompleto = A886ProfesionalesNombreCompleto;
         obj34.gxTpr_Profesionalesfechanacimiento = A900ProfesionalesFechaNacimiento;
         obj34.gxTpr_Profesionalesrut = A901ProfesionalesRUT;
         obj34.gxTpr_Profesionalestipoempresa = A902ProfesionalesTipoEmpresa;
         obj34.gxTpr_Profesionalesesrut = A676ProfesionalesEsRUT;
         obj34.gxTpr_Profesionalesprimernombre = A166ProfesionalesPrimerNombre;
         obj34.gxTpr_Profesionalessegundonombre = A191ProfesionalesSegundoNombre;
         obj34.gxTpr_Profesionalesapellidoprimero = A167ProfesionalesApellidoPrimero;
         obj34.gxTpr_Profesionalesapellidosegundo = A192ProfesionalesApellidoSegundo;
         obj34.gxTpr_Profesionalesphoto = A169ProfesionalesPhoto;
         obj34.gxTpr_Profesionalesphoto_gxi = A40000ProfesionalesPhoto_GXI;
         obj34.gxTpr_Profesionalestelefono = A170ProfesionalesTelefono;
         obj34.gxTpr_Profesionalesemail = A193ProfesionalesEmail;
         obj34.gxTpr_Profesionalesdireccion = A198ProfesionalesDireccion;
         obj34.gxTpr_Profesionalesautoenumerar = A196ProfesionalesAutoEnumerar;
         obj34.gxTpr_Profesionalesautoenuzona = A197ProfesionalesAutoEnuZona;
         obj34.gxTpr_Profesionalesexperiencia = A677ProfesionalesExperiencia;
         obj34.gxTpr_Profesionalesaceptoterminos = A678ProfesionalesAceptoTerminos;
         obj34.gxTpr_Profesionalesdeclarodatosv = A679ProfesionalesDeclaroDatosV;
         obj34.gxTpr_Profesionalescuentabancaria = A680ProfesionalesCuentaBancaria;
         obj34.gxTpr_Bancoid = A673BancoId;
         obj34.gxTpr_Banconombre = A674BancoNombre;
         obj34.gxTpr_Profesionaleslimitosf = A617ProfesionalesLimitOSF;
         obj34.gxTpr_Profesionalesfeedbackcant = A268ProfesionalesFeedBackCant;
         obj34.gxTpr_Profesionalesfeedbackprom = A269ProfesionalesFeedBackProm;
         obj34.gxTpr_Profesionalesverdatpersol = A267ProfesionalesVerDatPerSol;
         obj34.gxTpr_Profesionalesperaltshop = A436ProfesionalesPerAltShop;
         obj34.gxTpr_Profesionalescapacidadproductiva = A800ProfesionalesCapacidadProducti;
         obj34.gxTpr_Profesionalesid = A120ProfesionalesId;
         obj34.gxTpr_Profesionalesid_Z = Z120ProfesionalesId;
         obj34.gxTpr_Profesionalesfechanacimiento_Z = Z900ProfesionalesFechaNacimiento;
         obj34.gxTpr_Profesionalesrut_Z = Z901ProfesionalesRUT;
         obj34.gxTpr_Profesionalestipoempresa_Z = Z902ProfesionalesTipoEmpresa;
         obj34.gxTpr_Profesionalesesrut_Z = Z676ProfesionalesEsRUT;
         obj34.gxTpr_Profesionalesprimernombre_Z = Z166ProfesionalesPrimerNombre;
         obj34.gxTpr_Profesionalessegundonombre_Z = Z191ProfesionalesSegundoNombre;
         obj34.gxTpr_Profesionalesapellidoprimero_Z = Z167ProfesionalesApellidoPrimero;
         obj34.gxTpr_Profesionalesapellidosegundo_Z = Z192ProfesionalesApellidoSegundo;
         obj34.gxTpr_Profesionalesnombrecompleto_Z = Z886ProfesionalesNombreCompleto;
         obj34.gxTpr_Profesionalestelefono_Z = Z170ProfesionalesTelefono;
         obj34.gxTpr_Profesionalesemail_Z = Z193ProfesionalesEmail;
         obj34.gxTpr_Profesionalesdireccion_Z = Z198ProfesionalesDireccion;
         obj34.gxTpr_Profesionalesverdatpersol_Z = Z267ProfesionalesVerDatPerSol;
         obj34.gxTpr_Profesionalesperaltshop_Z = Z436ProfesionalesPerAltShop;
         obj34.gxTpr_Profesionalesautoenumerar_Z = Z196ProfesionalesAutoEnumerar;
         obj34.gxTpr_Profesionalesautoenuzona_Z = Z197ProfesionalesAutoEnuZona;
         obj34.gxTpr_Profesionalesexperiencia_Z = Z677ProfesionalesExperiencia;
         obj34.gxTpr_Profesionalesaceptoterminos_Z = Z678ProfesionalesAceptoTerminos;
         obj34.gxTpr_Profesionalesdeclarodatosv_Z = Z679ProfesionalesDeclaroDatosV;
         obj34.gxTpr_Profesionalescuentabancaria_Z = Z680ProfesionalesCuentaBancaria;
         obj34.gxTpr_Profesionalescapacidadproductiva_Z = Z800ProfesionalesCapacidadProducti;
         obj34.gxTpr_Profesionalestiempodisponible_Z = Z803ProfesionalesTiempoDisponible;
         obj34.gxTpr_Bancoid_Z = Z673BancoId;
         obj34.gxTpr_Banconombre_Z = Z674BancoNombre;
         obj34.gxTpr_Estadostipo_Z = Z107EstadosTipo;
         obj34.gxTpr_Estadosgenericosid_Z = Z108EstadosGenericosId;
         obj34.gxTpr_Profesionalesfechaalta_Z = Z199ProfesionalesFechaAlta;
         obj34.gxTpr_Profesionalesfechaactualizado_Z = Z200ProfesionalesFechaActualizado;
         obj34.gxTpr_Profesionaleslimitosf_Z = Z617ProfesionalesLimitOSF;
         obj34.gxTpr_Profesionalesfeedbackcant_Z = Z268ProfesionalesFeedBackCant;
         obj34.gxTpr_Profesionalesfeedbackprom_Z = Z269ProfesionalesFeedBackProm;
         obj34.gxTpr_Profesionalesfeedback_Z = Z270ProfesionalesFeedback;
         obj34.gxTpr_Profesionalesphoto_gxi_Z = Z40000ProfesionalesPhoto_GXI;
         obj34.gxTpr_Profesionalesfechanacimiento_N = (short)(Convert.ToInt16(n900ProfesionalesFechaNacimiento));
         obj34.gxTpr_Profesionalesrut_N = (short)(Convert.ToInt16(n901ProfesionalesRUT));
         obj34.gxTpr_Profesionalestipoempresa_N = (short)(Convert.ToInt16(n902ProfesionalesTipoEmpresa));
         obj34.gxTpr_Profesionalesesrut_N = (short)(Convert.ToInt16(n676ProfesionalesEsRUT));
         obj34.gxTpr_Profesionalesemail_N = (short)(Convert.ToInt16(n193ProfesionalesEmail));
         obj34.gxTpr_Profesionalesperaltshop_N = (short)(Convert.ToInt16(n436ProfesionalesPerAltShop));
         obj34.gxTpr_Profesionalesexperiencia_N = (short)(Convert.ToInt16(n677ProfesionalesExperiencia));
         obj34.gxTpr_Profesionalesaceptoterminos_N = (short)(Convert.ToInt16(n678ProfesionalesAceptoTerminos));
         obj34.gxTpr_Profesionalesdeclarodatosv_N = (short)(Convert.ToInt16(n679ProfesionalesDeclaroDatosV));
         obj34.gxTpr_Profesionalescuentabancaria_N = (short)(Convert.ToInt16(n680ProfesionalesCuentaBancaria));
         obj34.gxTpr_Bancoid_N = (short)(Convert.ToInt16(n673BancoId));
         obj34.gxTpr_Profesionaleslimitosf_N = (short)(Convert.ToInt16(n617ProfesionalesLimitOSF));
         obj34.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow34( SdtProfesionales obj34 )
      {
         obj34.gxTpr_Profesionalesid = A120ProfesionalesId;
         return  ;
      }

      public void RowToVars34( SdtProfesionales obj34 ,
                               int forceLoad )
      {
         Gx_mode = obj34.gxTpr_Mode;
         A107EstadosTipo = obj34.gxTpr_Estadostipo;
         A108EstadosGenericosId = obj34.gxTpr_Estadosgenericosid;
         A199ProfesionalesFechaAlta = obj34.gxTpr_Profesionalesfechaalta;
         A200ProfesionalesFechaActualizado = obj34.gxTpr_Profesionalesfechaactualizado;
         A270ProfesionalesFeedback = obj34.gxTpr_Profesionalesfeedback;
         A803ProfesionalesTiempoDisponible = obj34.gxTpr_Profesionalestiempodisponible;
         A886ProfesionalesNombreCompleto = obj34.gxTpr_Profesionalesnombrecompleto;
         A900ProfesionalesFechaNacimiento = obj34.gxTpr_Profesionalesfechanacimiento;
         n900ProfesionalesFechaNacimiento = false;
         A901ProfesionalesRUT = obj34.gxTpr_Profesionalesrut;
         n901ProfesionalesRUT = false;
         A902ProfesionalesTipoEmpresa = obj34.gxTpr_Profesionalestipoempresa;
         n902ProfesionalesTipoEmpresa = false;
         A676ProfesionalesEsRUT = obj34.gxTpr_Profesionalesesrut;
         n676ProfesionalesEsRUT = false;
         A166ProfesionalesPrimerNombre = obj34.gxTpr_Profesionalesprimernombre;
         A191ProfesionalesSegundoNombre = obj34.gxTpr_Profesionalessegundonombre;
         A167ProfesionalesApellidoPrimero = obj34.gxTpr_Profesionalesapellidoprimero;
         A192ProfesionalesApellidoSegundo = obj34.gxTpr_Profesionalesapellidosegundo;
         A169ProfesionalesPhoto = obj34.gxTpr_Profesionalesphoto;
         A40000ProfesionalesPhoto_GXI = obj34.gxTpr_Profesionalesphoto_gxi;
         A170ProfesionalesTelefono = obj34.gxTpr_Profesionalestelefono;
         A193ProfesionalesEmail = obj34.gxTpr_Profesionalesemail;
         n193ProfesionalesEmail = false;
         A198ProfesionalesDireccion = obj34.gxTpr_Profesionalesdireccion;
         A196ProfesionalesAutoEnumerar = obj34.gxTpr_Profesionalesautoenumerar;
         if ( forceLoad == 1 )
         {
            A197ProfesionalesAutoEnuZona = obj34.gxTpr_Profesionalesautoenuzona;
         }
         A677ProfesionalesExperiencia = obj34.gxTpr_Profesionalesexperiencia;
         n677ProfesionalesExperiencia = false;
         A678ProfesionalesAceptoTerminos = obj34.gxTpr_Profesionalesaceptoterminos;
         n678ProfesionalesAceptoTerminos = false;
         A679ProfesionalesDeclaroDatosV = obj34.gxTpr_Profesionalesdeclarodatosv;
         n679ProfesionalesDeclaroDatosV = false;
         A680ProfesionalesCuentaBancaria = obj34.gxTpr_Profesionalescuentabancaria;
         n680ProfesionalesCuentaBancaria = false;
         A673BancoId = obj34.gxTpr_Bancoid;
         n673BancoId = false;
         A674BancoNombre = obj34.gxTpr_Banconombre;
         A617ProfesionalesLimitOSF = obj34.gxTpr_Profesionaleslimitosf;
         n617ProfesionalesLimitOSF = false;
         A268ProfesionalesFeedBackCant = obj34.gxTpr_Profesionalesfeedbackcant;
         A269ProfesionalesFeedBackProm = obj34.gxTpr_Profesionalesfeedbackprom;
         A267ProfesionalesVerDatPerSol = obj34.gxTpr_Profesionalesverdatpersol;
         A436ProfesionalesPerAltShop = obj34.gxTpr_Profesionalesperaltshop;
         n436ProfesionalesPerAltShop = false;
         A800ProfesionalesCapacidadProducti = obj34.gxTpr_Profesionalescapacidadproductiva;
         A120ProfesionalesId = obj34.gxTpr_Profesionalesid;
         Z120ProfesionalesId = obj34.gxTpr_Profesionalesid_Z;
         Z900ProfesionalesFechaNacimiento = obj34.gxTpr_Profesionalesfechanacimiento_Z;
         Z901ProfesionalesRUT = obj34.gxTpr_Profesionalesrut_Z;
         Z902ProfesionalesTipoEmpresa = obj34.gxTpr_Profesionalestipoempresa_Z;
         Z676ProfesionalesEsRUT = obj34.gxTpr_Profesionalesesrut_Z;
         Z166ProfesionalesPrimerNombre = obj34.gxTpr_Profesionalesprimernombre_Z;
         Z191ProfesionalesSegundoNombre = obj34.gxTpr_Profesionalessegundonombre_Z;
         Z167ProfesionalesApellidoPrimero = obj34.gxTpr_Profesionalesapellidoprimero_Z;
         Z192ProfesionalesApellidoSegundo = obj34.gxTpr_Profesionalesapellidosegundo_Z;
         Z886ProfesionalesNombreCompleto = obj34.gxTpr_Profesionalesnombrecompleto_Z;
         Z170ProfesionalesTelefono = obj34.gxTpr_Profesionalestelefono_Z;
         Z193ProfesionalesEmail = obj34.gxTpr_Profesionalesemail_Z;
         Z198ProfesionalesDireccion = obj34.gxTpr_Profesionalesdireccion_Z;
         Z267ProfesionalesVerDatPerSol = obj34.gxTpr_Profesionalesverdatpersol_Z;
         Z436ProfesionalesPerAltShop = obj34.gxTpr_Profesionalesperaltshop_Z;
         Z196ProfesionalesAutoEnumerar = obj34.gxTpr_Profesionalesautoenumerar_Z;
         Z197ProfesionalesAutoEnuZona = obj34.gxTpr_Profesionalesautoenuzona_Z;
         O197ProfesionalesAutoEnuZona = obj34.gxTpr_Profesionalesautoenuzona_Z;
         Z677ProfesionalesExperiencia = obj34.gxTpr_Profesionalesexperiencia_Z;
         Z678ProfesionalesAceptoTerminos = obj34.gxTpr_Profesionalesaceptoterminos_Z;
         Z679ProfesionalesDeclaroDatosV = obj34.gxTpr_Profesionalesdeclarodatosv_Z;
         Z680ProfesionalesCuentaBancaria = obj34.gxTpr_Profesionalescuentabancaria_Z;
         Z800ProfesionalesCapacidadProducti = obj34.gxTpr_Profesionalescapacidadproductiva_Z;
         Z803ProfesionalesTiempoDisponible = obj34.gxTpr_Profesionalestiempodisponible_Z;
         Z673BancoId = obj34.gxTpr_Bancoid_Z;
         Z674BancoNombre = obj34.gxTpr_Banconombre_Z;
         Z107EstadosTipo = obj34.gxTpr_Estadostipo_Z;
         Z108EstadosGenericosId = obj34.gxTpr_Estadosgenericosid_Z;
         Z199ProfesionalesFechaAlta = obj34.gxTpr_Profesionalesfechaalta_Z;
         Z200ProfesionalesFechaActualizado = obj34.gxTpr_Profesionalesfechaactualizado_Z;
         Z617ProfesionalesLimitOSF = obj34.gxTpr_Profesionaleslimitosf_Z;
         Z268ProfesionalesFeedBackCant = obj34.gxTpr_Profesionalesfeedbackcant_Z;
         Z269ProfesionalesFeedBackProm = obj34.gxTpr_Profesionalesfeedbackprom_Z;
         Z270ProfesionalesFeedback = obj34.gxTpr_Profesionalesfeedback_Z;
         Z40000ProfesionalesPhoto_GXI = obj34.gxTpr_Profesionalesphoto_gxi_Z;
         n900ProfesionalesFechaNacimiento = (bool)(Convert.ToBoolean(obj34.gxTpr_Profesionalesfechanacimiento_N));
         n901ProfesionalesRUT = (bool)(Convert.ToBoolean(obj34.gxTpr_Profesionalesrut_N));
         n902ProfesionalesTipoEmpresa = (bool)(Convert.ToBoolean(obj34.gxTpr_Profesionalestipoempresa_N));
         n676ProfesionalesEsRUT = (bool)(Convert.ToBoolean(obj34.gxTpr_Profesionalesesrut_N));
         n193ProfesionalesEmail = (bool)(Convert.ToBoolean(obj34.gxTpr_Profesionalesemail_N));
         n436ProfesionalesPerAltShop = (bool)(Convert.ToBoolean(obj34.gxTpr_Profesionalesperaltshop_N));
         n677ProfesionalesExperiencia = (bool)(Convert.ToBoolean(obj34.gxTpr_Profesionalesexperiencia_N));
         n678ProfesionalesAceptoTerminos = (bool)(Convert.ToBoolean(obj34.gxTpr_Profesionalesaceptoterminos_N));
         n679ProfesionalesDeclaroDatosV = (bool)(Convert.ToBoolean(obj34.gxTpr_Profesionalesdeclarodatosv_N));
         n680ProfesionalesCuentaBancaria = (bool)(Convert.ToBoolean(obj34.gxTpr_Profesionalescuentabancaria_N));
         n673BancoId = (bool)(Convert.ToBoolean(obj34.gxTpr_Bancoid_N));
         n617ProfesionalesLimitOSF = (bool)(Convert.ToBoolean(obj34.gxTpr_Profesionaleslimitosf_N));
         Gx_mode = obj34.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow35( SdtProfesionales_Rubros obj35 )
      {
         obj35.gxTpr_Mode = Gx_mode;
         obj35.gxTpr_Estadosprofrubtipo = A124EstadosProfRubTipo;
         obj35.gxTpr_Estadosprofrubid = A125EstadosProfRubId;
         obj35.gxTpr_Rubrosnombre = A122RubrosNombre;
         obj35.gxTpr_Rubrosimagen = A168RubrosImagen;
         obj35.gxTpr_Rubrosimagen_gxi = A40001RubrosImagen_GXI;
         obj35.gxTpr_Rubrosestado = A123RubrosEstado;
         obj35.gxTpr_Estadosprofrubnomb = A221EstadosProfRubNomb;
         obj35.gxTpr_Rubrosid = A121RubrosId;
         obj35.gxTpr_Rubrosid_Z = Z121RubrosId;
         obj35.gxTpr_Rubrosnombre_Z = Z122RubrosNombre;
         obj35.gxTpr_Rubrosestado_Z = Z123RubrosEstado;
         obj35.gxTpr_Estadosprofrubtipo_Z = Z124EstadosProfRubTipo;
         obj35.gxTpr_Estadosprofrubid_Z = Z125EstadosProfRubId;
         obj35.gxTpr_Estadosprofrubnomb_Z = Z221EstadosProfRubNomb;
         obj35.gxTpr_Rubrosimagen_gxi_Z = Z40001RubrosImagen_GXI;
         obj35.gxTpr_Rubrosestado_N = (short)(Convert.ToInt16(n123RubrosEstado));
         obj35.gxTpr_Modified = nIsMod_35;
         return  ;
      }

      public void KeyVarsToRow35( SdtProfesionales_Rubros obj35 )
      {
         obj35.gxTpr_Rubrosid = A121RubrosId;
         return  ;
      }

      public void RowToVars35( SdtProfesionales_Rubros obj35 ,
                               int forceLoad )
      {
         Gx_mode = obj35.gxTpr_Mode;
         A124EstadosProfRubTipo = obj35.gxTpr_Estadosprofrubtipo;
         A125EstadosProfRubId = obj35.gxTpr_Estadosprofrubid;
         A122RubrosNombre = obj35.gxTpr_Rubrosnombre;
         A168RubrosImagen = obj35.gxTpr_Rubrosimagen;
         A40001RubrosImagen_GXI = obj35.gxTpr_Rubrosimagen_gxi;
         A123RubrosEstado = obj35.gxTpr_Rubrosestado;
         n123RubrosEstado = false;
         A221EstadosProfRubNomb = obj35.gxTpr_Estadosprofrubnomb;
         A121RubrosId = obj35.gxTpr_Rubrosid;
         Z121RubrosId = obj35.gxTpr_Rubrosid_Z;
         Z122RubrosNombre = obj35.gxTpr_Rubrosnombre_Z;
         Z123RubrosEstado = obj35.gxTpr_Rubrosestado_Z;
         Z124EstadosProfRubTipo = obj35.gxTpr_Estadosprofrubtipo_Z;
         Z125EstadosProfRubId = obj35.gxTpr_Estadosprofrubid_Z;
         Z221EstadosProfRubNomb = obj35.gxTpr_Estadosprofrubnomb_Z;
         Z40001RubrosImagen_GXI = obj35.gxTpr_Rubrosimagen_gxi_Z;
         n123RubrosEstado = (bool)(Convert.ToBoolean(obj35.gxTpr_Rubrosestado_N));
         nIsMod_35 = obj35.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow36( SdtProfesionales_Zonas obj36 )
      {
         obj36.gxTpr_Mode = Gx_mode;
         obj36.gxTpr_Paisid = A116PaisID;
         obj36.gxTpr_Departamentoid = A112DepartamentoId;
         obj36.gxTpr_Departamentodepartamento = A113DepartamentoDepartamento;
         obj36.gxTpr_Departamentomunicipioid = A114DepartamentoMunicipioId;
         obj36.gxTpr_Zonasid = A110ZonasID;
         obj36.gxTpr_Profesionaleszonascorrelativo = A126ProfesionalesZonasCorrelativo;
         obj36.gxTpr_Profesionaleszonascorrelativo_Z = Z126ProfesionalesZonasCorrelativo;
         obj36.gxTpr_Paisid_Z = Z116PaisID;
         obj36.gxTpr_Departamentoid_Z = Z112DepartamentoId;
         obj36.gxTpr_Departamentodepartamento_Z = Z113DepartamentoDepartamento;
         obj36.gxTpr_Departamentomunicipioid_Z = Z114DepartamentoMunicipioId;
         obj36.gxTpr_Zonasid_Z = Z110ZonasID;
         obj36.gxTpr_Zonasid_N = (short)(Convert.ToInt16(n110ZonasID));
         obj36.gxTpr_Modified = nIsMod_36;
         return  ;
      }

      public void KeyVarsToRow36( SdtProfesionales_Zonas obj36 )
      {
         obj36.gxTpr_Profesionaleszonascorrelativo = A126ProfesionalesZonasCorrelativo;
         return  ;
      }

      public void RowToVars36( SdtProfesionales_Zonas obj36 ,
                               int forceLoad )
      {
         Gx_mode = obj36.gxTpr_Mode;
         A116PaisID = obj36.gxTpr_Paisid;
         A112DepartamentoId = obj36.gxTpr_Departamentoid;
         A113DepartamentoDepartamento = obj36.gxTpr_Departamentodepartamento;
         A114DepartamentoMunicipioId = obj36.gxTpr_Departamentomunicipioid;
         A110ZonasID = obj36.gxTpr_Zonasid;
         n110ZonasID = false;
         A126ProfesionalesZonasCorrelativo = obj36.gxTpr_Profesionaleszonascorrelativo;
         Z126ProfesionalesZonasCorrelativo = obj36.gxTpr_Profesionaleszonascorrelativo_Z;
         Z116PaisID = obj36.gxTpr_Paisid_Z;
         Z112DepartamentoId = obj36.gxTpr_Departamentoid_Z;
         Z113DepartamentoDepartamento = obj36.gxTpr_Departamentodepartamento_Z;
         Z114DepartamentoMunicipioId = obj36.gxTpr_Departamentomunicipioid_Z;
         Z110ZonasID = obj36.gxTpr_Zonasid_Z;
         n110ZonasID = (bool)(Convert.ToBoolean(obj36.gxTpr_Zonasid_N));
         nIsMod_36 = obj36.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow145( SdtProfesionales_Servicios obj145 )
      {
         obj145.gxTpr_Mode = Gx_mode;
         obj145.gxTpr_Profesionalservicionombre = A994ProfesionalServicioNombre;
         obj145.gxTpr_Estadoservprof = A995EstadoServProf;
         obj145.gxTpr_Profesionalservicioid = A993ProfesionalServicioId;
         obj145.gxTpr_Profesionalservicioid_Z = Z993ProfesionalServicioId;
         obj145.gxTpr_Profesionalservicionombre_Z = Z994ProfesionalServicioNombre;
         obj145.gxTpr_Estadoservprof_Z = Z995EstadoServProf;
         obj145.gxTpr_Estadoservprof_N = (short)(Convert.ToInt16(n995EstadoServProf));
         obj145.gxTpr_Modified = nIsMod_145;
         return  ;
      }

      public void KeyVarsToRow145( SdtProfesionales_Servicios obj145 )
      {
         obj145.gxTpr_Profesionalservicioid = A993ProfesionalServicioId;
         return  ;
      }

      public void RowToVars145( SdtProfesionales_Servicios obj145 ,
                                int forceLoad )
      {
         Gx_mode = obj145.gxTpr_Mode;
         A994ProfesionalServicioNombre = obj145.gxTpr_Profesionalservicionombre;
         A995EstadoServProf = obj145.gxTpr_Estadoservprof;
         n995EstadoServProf = false;
         A993ProfesionalServicioId = obj145.gxTpr_Profesionalservicioid;
         Z993ProfesionalServicioId = obj145.gxTpr_Profesionalservicioid_Z;
         Z994ProfesionalServicioNombre = obj145.gxTpr_Profesionalservicionombre_Z;
         Z995EstadoServProf = obj145.gxTpr_Estadoservprof_Z;
         n995EstadoServProf = (bool)(Convert.ToBoolean(obj145.gxTpr_Estadoservprof_N));
         nIsMod_145 = obj145.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A120ProfesionalesId = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0S34( ) ;
         ScanKeyStart0S34( ) ;
         if ( RcdFound34 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z120ProfesionalesId = A120ProfesionalesId;
            O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
         }
         ZM0S34( -27) ;
         OnLoadActions0S34( ) ;
         AddRow0S34( ) ;
         bcProfesionales.gxTpr_Rubros.ClearCollection();
         if ( RcdFound34 == 1 )
         {
            ScanKeyStart0S35( ) ;
            nGXsfl_35_idx = 1;
            while ( RcdFound35 != 0 )
            {
               Z120ProfesionalesId = A120ProfesionalesId;
               Z121RubrosId = A121RubrosId;
               ZM0S35( -30) ;
               OnLoadActions0S35( ) ;
               nRcdExists_35 = 1;
               nIsMod_35 = 0;
               AddRow0S35( ) ;
               nGXsfl_35_idx = (int)(nGXsfl_35_idx+1);
               ScanKeyNext0S35( ) ;
            }
            ScanKeyEnd0S35( ) ;
         }
         bcProfesionales.gxTpr_Zonas.ClearCollection();
         if ( RcdFound34 == 1 )
         {
            ScanKeyStart0S36( ) ;
            nGXsfl_36_idx = 1;
            while ( RcdFound36 != 0 )
            {
               Z120ProfesionalesId = A120ProfesionalesId;
               Z126ProfesionalesZonasCorrelativo = A126ProfesionalesZonasCorrelativo;
               ZM0S36( -33) ;
               OnLoadActions0S36( ) ;
               nRcdExists_36 = 1;
               nIsMod_36 = 0;
               AddRow0S36( ) ;
               nGXsfl_36_idx = (int)(nGXsfl_36_idx+1);
               ScanKeyNext0S36( ) ;
            }
            ScanKeyEnd0S36( ) ;
         }
         bcProfesionales.gxTpr_Servicios.ClearCollection();
         if ( RcdFound34 == 1 )
         {
            ScanKeyStart0S145( ) ;
            nGXsfl_145_idx = 1;
            while ( RcdFound145 != 0 )
            {
               Z120ProfesionalesId = A120ProfesionalesId;
               Z993ProfesionalServicioId = A993ProfesionalServicioId;
               ZM0S145( -37) ;
               OnLoadActions0S145( ) ;
               nRcdExists_145 = 1;
               nIsMod_145 = 0;
               AddRow0S145( ) ;
               nGXsfl_145_idx = (int)(nGXsfl_145_idx+1);
               ScanKeyNext0S145( ) ;
            }
            ScanKeyEnd0S145( ) ;
         }
         ScanKeyEnd0S34( ) ;
         if ( RcdFound34 == 0 )
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
         RowToVars34( bcProfesionales, 0) ;
         ScanKeyStart0S34( ) ;
         if ( RcdFound34 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z120ProfesionalesId = A120ProfesionalesId;
            O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
         }
         ZM0S34( -27) ;
         OnLoadActions0S34( ) ;
         AddRow0S34( ) ;
         bcProfesionales.gxTpr_Rubros.ClearCollection();
         if ( RcdFound34 == 1 )
         {
            ScanKeyStart0S35( ) ;
            nGXsfl_35_idx = 1;
            while ( RcdFound35 != 0 )
            {
               Z120ProfesionalesId = A120ProfesionalesId;
               Z121RubrosId = A121RubrosId;
               ZM0S35( -30) ;
               OnLoadActions0S35( ) ;
               nRcdExists_35 = 1;
               nIsMod_35 = 0;
               AddRow0S35( ) ;
               nGXsfl_35_idx = (int)(nGXsfl_35_idx+1);
               ScanKeyNext0S35( ) ;
            }
            ScanKeyEnd0S35( ) ;
         }
         bcProfesionales.gxTpr_Zonas.ClearCollection();
         if ( RcdFound34 == 1 )
         {
            ScanKeyStart0S36( ) ;
            nGXsfl_36_idx = 1;
            while ( RcdFound36 != 0 )
            {
               Z120ProfesionalesId = A120ProfesionalesId;
               Z126ProfesionalesZonasCorrelativo = A126ProfesionalesZonasCorrelativo;
               ZM0S36( -33) ;
               OnLoadActions0S36( ) ;
               nRcdExists_36 = 1;
               nIsMod_36 = 0;
               AddRow0S36( ) ;
               nGXsfl_36_idx = (int)(nGXsfl_36_idx+1);
               ScanKeyNext0S36( ) ;
            }
            ScanKeyEnd0S36( ) ;
         }
         bcProfesionales.gxTpr_Servicios.ClearCollection();
         if ( RcdFound34 == 1 )
         {
            ScanKeyStart0S145( ) ;
            nGXsfl_145_idx = 1;
            while ( RcdFound145 != 0 )
            {
               Z120ProfesionalesId = A120ProfesionalesId;
               Z993ProfesionalServicioId = A993ProfesionalServicioId;
               ZM0S145( -37) ;
               OnLoadActions0S145( ) ;
               nRcdExists_145 = 1;
               nIsMod_145 = 0;
               AddRow0S145( ) ;
               nGXsfl_145_idx = (int)(nGXsfl_145_idx+1);
               ScanKeyNext0S145( ) ;
            }
            ScanKeyEnd0S145( ) ;
         }
         ScanKeyEnd0S34( ) ;
         if ( RcdFound34 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0S34( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
            Insert0S34( ) ;
         }
         else
         {
            if ( RcdFound34 == 1 )
            {
               if ( StringUtil.StrCmp(A120ProfesionalesId, Z120ProfesionalesId) != 0 )
               {
                  A120ProfesionalesId = Z120ProfesionalesId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
                  Update0S34( ) ;
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
                  if ( StringUtil.StrCmp(A120ProfesionalesId, Z120ProfesionalesId) != 0 )
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
                        A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
                        Insert0S34( ) ;
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
                        A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
                        Insert0S34( ) ;
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
         RowToVars34( bcProfesionales, 1) ;
         SaveImpl( ) ;
         VarsToRow34( bcProfesionales) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars34( bcProfesionales, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
         Insert0S34( ) ;
         AfterTrn( ) ;
         VarsToRow34( bcProfesionales) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow34( bcProfesionales) ;
         }
         else
         {
            SdtProfesionales auxBC = new SdtProfesionales(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A120ProfesionalesId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcProfesionales);
               auxBC.Save();
               bcProfesionales.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars34( bcProfesionales, 1) ;
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
         RowToVars34( bcProfesionales, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0S34( ) ;
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
               VarsToRow34( bcProfesionales) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow34( bcProfesionales) ;
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
         RowToVars34( bcProfesionales, 0) ;
         GetKey0S34( ) ;
         if ( RcdFound34 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A120ProfesionalesId, Z120ProfesionalesId) != 0 )
            {
               A120ProfesionalesId = Z120ProfesionalesId;
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
            if ( StringUtil.StrCmp(A120ProfesionalesId, Z120ProfesionalesId) != 0 )
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
         pr_default.close(13);
         pr_default.close(9);
         pr_default.close(4);
         pr_default.close(1);
         pr_default.close(22);
         pr_default.close(37);
         pr_default.close(38);
         pr_default.close(45);
         pr_default.close(52);
         context.RollbackDataStores("profesionales_bc",pr_default);
         VarsToRow34( bcProfesionales) ;
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
         Gx_mode = bcProfesionales.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcProfesionales.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcProfesionales )
         {
            bcProfesionales = (SdtProfesionales)(sdt);
            if ( StringUtil.StrCmp(bcProfesionales.gxTpr_Mode, "") == 0 )
            {
               bcProfesionales.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow34( bcProfesionales) ;
            }
            else
            {
               RowToVars34( bcProfesionales, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcProfesionales.gxTpr_Mode, "") == 0 )
            {
               bcProfesionales.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars34( bcProfesionales, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtProfesionales Profesionales_BC
      {
         get {
            return bcProfesionales ;
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
         pr_default.close(52);
         pr_default.close(4);
         pr_default.close(45);
         pr_default.close(9);
         pr_default.close(37);
         pr_default.close(38);
         pr_default.close(13);
         pr_default.close(22);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z120ProfesionalesId = "";
         A120ProfesionalesId = "";
         sMode34 = "";
         AV15WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV34Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV11Insert_EstadosTipo = "";
         Z199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         A199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         Z200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         A200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         Z900ProfesionalesFechaNacimiento = DateTime.MinValue;
         A900ProfesionalesFechaNacimiento = DateTime.MinValue;
         Z901ProfesionalesRUT = "";
         A901ProfesionalesRUT = "";
         Z166ProfesionalesPrimerNombre = "";
         A166ProfesionalesPrimerNombre = "";
         Z191ProfesionalesSegundoNombre = "";
         A191ProfesionalesSegundoNombre = "";
         Z167ProfesionalesApellidoPrimero = "";
         A167ProfesionalesApellidoPrimero = "";
         Z192ProfesionalesApellidoSegundo = "";
         A192ProfesionalesApellidoSegundo = "";
         Z170ProfesionalesTelefono = "";
         A170ProfesionalesTelefono = "";
         Z193ProfesionalesEmail = "";
         A193ProfesionalesEmail = "";
         Z198ProfesionalesDireccion = "";
         A198ProfesionalesDireccion = "";
         Z267ProfesionalesVerDatPerSol = "";
         A267ProfesionalesVerDatPerSol = "";
         Z436ProfesionalesPerAltShop = "";
         A436ProfesionalesPerAltShop = "";
         Z677ProfesionalesExperiencia = "";
         A677ProfesionalesExperiencia = "";
         Z678ProfesionalesAceptoTerminos = (DateTime)(DateTime.MinValue);
         A678ProfesionalesAceptoTerminos = (DateTime)(DateTime.MinValue);
         Z679ProfesionalesDeclaroDatosV = (DateTime)(DateTime.MinValue);
         A679ProfesionalesDeclaroDatosV = (DateTime)(DateTime.MinValue);
         Z680ProfesionalesCuentaBancaria = "";
         A680ProfesionalesCuentaBancaria = "";
         Z107EstadosTipo = "";
         A107EstadosTipo = "";
         Z886ProfesionalesNombreCompleto = "";
         A886ProfesionalesNombreCompleto = "";
         Z674BancoNombre = "";
         A674BancoNombre = "";
         Z169ProfesionalesPhoto = "";
         A169ProfesionalesPhoto = "";
         Z40000ProfesionalesPhoto_GXI = "";
         A40000ProfesionalesPhoto_GXI = "";
         BC000S18_A120ProfesionalesId = new string[] {""} ;
         BC000S18_A199ProfesionalesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC000S18_A200ProfesionalesFechaActualizado = new DateTime[] {DateTime.MinValue} ;
         BC000S18_A900ProfesionalesFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000S18_n900ProfesionalesFechaNacimiento = new bool[] {false} ;
         BC000S18_A901ProfesionalesRUT = new string[] {""} ;
         BC000S18_n901ProfesionalesRUT = new bool[] {false} ;
         BC000S18_A902ProfesionalesTipoEmpresa = new short[1] ;
         BC000S18_n902ProfesionalesTipoEmpresa = new bool[] {false} ;
         BC000S18_A676ProfesionalesEsRUT = new bool[] {false} ;
         BC000S18_n676ProfesionalesEsRUT = new bool[] {false} ;
         BC000S18_A166ProfesionalesPrimerNombre = new string[] {""} ;
         BC000S18_A191ProfesionalesSegundoNombre = new string[] {""} ;
         BC000S18_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         BC000S18_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         BC000S18_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         BC000S18_A170ProfesionalesTelefono = new string[] {""} ;
         BC000S18_A193ProfesionalesEmail = new string[] {""} ;
         BC000S18_n193ProfesionalesEmail = new bool[] {false} ;
         BC000S18_A198ProfesionalesDireccion = new string[] {""} ;
         BC000S18_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         BC000S18_A436ProfesionalesPerAltShop = new string[] {""} ;
         BC000S18_n436ProfesionalesPerAltShop = new bool[] {false} ;
         BC000S18_A196ProfesionalesAutoEnumerar = new short[1] ;
         BC000S18_A197ProfesionalesAutoEnuZona = new short[1] ;
         BC000S18_A677ProfesionalesExperiencia = new string[] {""} ;
         BC000S18_n677ProfesionalesExperiencia = new bool[] {false} ;
         BC000S18_A678ProfesionalesAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         BC000S18_n678ProfesionalesAceptoTerminos = new bool[] {false} ;
         BC000S18_A679ProfesionalesDeclaroDatosV = new DateTime[] {DateTime.MinValue} ;
         BC000S18_n679ProfesionalesDeclaroDatosV = new bool[] {false} ;
         BC000S18_A680ProfesionalesCuentaBancaria = new string[] {""} ;
         BC000S18_n680ProfesionalesCuentaBancaria = new bool[] {false} ;
         BC000S18_A800ProfesionalesCapacidadProducti = new decimal[1] ;
         BC000S18_A674BancoNombre = new string[] {""} ;
         BC000S18_A617ProfesionalesLimitOSF = new short[1] ;
         BC000S18_n617ProfesionalesLimitOSF = new bool[] {false} ;
         BC000S18_A268ProfesionalesFeedBackCant = new long[1] ;
         BC000S18_A269ProfesionalesFeedBackProm = new decimal[1] ;
         BC000S18_A107EstadosTipo = new string[] {""} ;
         BC000S18_A108EstadosGenericosId = new int[1] ;
         BC000S18_A673BancoId = new long[1] ;
         BC000S18_n673BancoId = new bool[] {false} ;
         BC000S18_A169ProfesionalesPhoto = new string[] {""} ;
         BC000S17_A674BancoNombre = new string[] {""} ;
         BC000S16_A107EstadosTipo = new string[] {""} ;
         BC000S19_A120ProfesionalesId = new string[] {""} ;
         BC000S15_A120ProfesionalesId = new string[] {""} ;
         BC000S15_A199ProfesionalesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC000S15_A200ProfesionalesFechaActualizado = new DateTime[] {DateTime.MinValue} ;
         BC000S15_A900ProfesionalesFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000S15_n900ProfesionalesFechaNacimiento = new bool[] {false} ;
         BC000S15_A901ProfesionalesRUT = new string[] {""} ;
         BC000S15_n901ProfesionalesRUT = new bool[] {false} ;
         BC000S15_A902ProfesionalesTipoEmpresa = new short[1] ;
         BC000S15_n902ProfesionalesTipoEmpresa = new bool[] {false} ;
         BC000S15_A676ProfesionalesEsRUT = new bool[] {false} ;
         BC000S15_n676ProfesionalesEsRUT = new bool[] {false} ;
         BC000S15_A166ProfesionalesPrimerNombre = new string[] {""} ;
         BC000S15_A191ProfesionalesSegundoNombre = new string[] {""} ;
         BC000S15_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         BC000S15_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         BC000S15_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         BC000S15_A170ProfesionalesTelefono = new string[] {""} ;
         BC000S15_A193ProfesionalesEmail = new string[] {""} ;
         BC000S15_n193ProfesionalesEmail = new bool[] {false} ;
         BC000S15_A198ProfesionalesDireccion = new string[] {""} ;
         BC000S15_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         BC000S15_A436ProfesionalesPerAltShop = new string[] {""} ;
         BC000S15_n436ProfesionalesPerAltShop = new bool[] {false} ;
         BC000S15_A196ProfesionalesAutoEnumerar = new short[1] ;
         BC000S15_A197ProfesionalesAutoEnuZona = new short[1] ;
         BC000S15_A677ProfesionalesExperiencia = new string[] {""} ;
         BC000S15_n677ProfesionalesExperiencia = new bool[] {false} ;
         BC000S15_A678ProfesionalesAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         BC000S15_n678ProfesionalesAceptoTerminos = new bool[] {false} ;
         BC000S15_A679ProfesionalesDeclaroDatosV = new DateTime[] {DateTime.MinValue} ;
         BC000S15_n679ProfesionalesDeclaroDatosV = new bool[] {false} ;
         BC000S15_A680ProfesionalesCuentaBancaria = new string[] {""} ;
         BC000S15_n680ProfesionalesCuentaBancaria = new bool[] {false} ;
         BC000S15_A800ProfesionalesCapacidadProducti = new decimal[1] ;
         BC000S15_A617ProfesionalesLimitOSF = new short[1] ;
         BC000S15_n617ProfesionalesLimitOSF = new bool[] {false} ;
         BC000S15_A268ProfesionalesFeedBackCant = new long[1] ;
         BC000S15_A269ProfesionalesFeedBackProm = new decimal[1] ;
         BC000S15_A107EstadosTipo = new string[] {""} ;
         BC000S15_A108EstadosGenericosId = new int[1] ;
         BC000S15_A673BancoId = new long[1] ;
         BC000S15_n673BancoId = new bool[] {false} ;
         BC000S15_A169ProfesionalesPhoto = new string[] {""} ;
         BC000S14_A120ProfesionalesId = new string[] {""} ;
         BC000S14_A199ProfesionalesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC000S14_A200ProfesionalesFechaActualizado = new DateTime[] {DateTime.MinValue} ;
         BC000S14_A900ProfesionalesFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000S14_n900ProfesionalesFechaNacimiento = new bool[] {false} ;
         BC000S14_A901ProfesionalesRUT = new string[] {""} ;
         BC000S14_n901ProfesionalesRUT = new bool[] {false} ;
         BC000S14_A902ProfesionalesTipoEmpresa = new short[1] ;
         BC000S14_n902ProfesionalesTipoEmpresa = new bool[] {false} ;
         BC000S14_A676ProfesionalesEsRUT = new bool[] {false} ;
         BC000S14_n676ProfesionalesEsRUT = new bool[] {false} ;
         BC000S14_A166ProfesionalesPrimerNombre = new string[] {""} ;
         BC000S14_A191ProfesionalesSegundoNombre = new string[] {""} ;
         BC000S14_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         BC000S14_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         BC000S14_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         BC000S14_A170ProfesionalesTelefono = new string[] {""} ;
         BC000S14_A193ProfesionalesEmail = new string[] {""} ;
         BC000S14_n193ProfesionalesEmail = new bool[] {false} ;
         BC000S14_A198ProfesionalesDireccion = new string[] {""} ;
         BC000S14_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         BC000S14_A436ProfesionalesPerAltShop = new string[] {""} ;
         BC000S14_n436ProfesionalesPerAltShop = new bool[] {false} ;
         BC000S14_A196ProfesionalesAutoEnumerar = new short[1] ;
         BC000S14_A197ProfesionalesAutoEnuZona = new short[1] ;
         BC000S14_A677ProfesionalesExperiencia = new string[] {""} ;
         BC000S14_n677ProfesionalesExperiencia = new bool[] {false} ;
         BC000S14_A678ProfesionalesAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         BC000S14_n678ProfesionalesAceptoTerminos = new bool[] {false} ;
         BC000S14_A679ProfesionalesDeclaroDatosV = new DateTime[] {DateTime.MinValue} ;
         BC000S14_n679ProfesionalesDeclaroDatosV = new bool[] {false} ;
         BC000S14_A680ProfesionalesCuentaBancaria = new string[] {""} ;
         BC000S14_n680ProfesionalesCuentaBancaria = new bool[] {false} ;
         BC000S14_A800ProfesionalesCapacidadProducti = new decimal[1] ;
         BC000S14_A617ProfesionalesLimitOSF = new short[1] ;
         BC000S14_n617ProfesionalesLimitOSF = new bool[] {false} ;
         BC000S14_A268ProfesionalesFeedBackCant = new long[1] ;
         BC000S14_A269ProfesionalesFeedBackProm = new decimal[1] ;
         BC000S14_A107EstadosTipo = new string[] {""} ;
         BC000S14_A108EstadosGenericosId = new int[1] ;
         BC000S14_A673BancoId = new long[1] ;
         BC000S14_n673BancoId = new bool[] {false} ;
         BC000S14_A169ProfesionalesPhoto = new string[] {""} ;
         BC000S24_A674BancoNombre = new string[] {""} ;
         BC000S25_A461CentroCostosId = new long[1] ;
         BC000S25_A466CentroCostosDetallesId = new long[1] ;
         BC000S26_A976ProfesionalesRestriccionId = new long[1] ;
         BC000S27_A450ProfComisionesID = new long[1] ;
         BC000S28_A127SolicitudesID = new long[1] ;
         BC000S28_A140RelacionesId = new long[1] ;
         BC000S29_A422PostulacionesId = new long[1] ;
         BC000S29_A120ProfesionalesId = new string[] {""} ;
         BC000S30_A590Listaid = new long[1] ;
         BC000S30_A133ProveedorID = new long[1] ;
         BC000S30_A120ProfesionalesId = new string[] {""} ;
         BC000S31_A503ComisionesID = new long[1] ;
         BC000S31_A120ProfesionalesId = new string[] {""} ;
         BC000S33_A120ProfesionalesId = new string[] {""} ;
         BC000S33_A199ProfesionalesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC000S33_A200ProfesionalesFechaActualizado = new DateTime[] {DateTime.MinValue} ;
         BC000S33_A900ProfesionalesFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000S33_n900ProfesionalesFechaNacimiento = new bool[] {false} ;
         BC000S33_A901ProfesionalesRUT = new string[] {""} ;
         BC000S33_n901ProfesionalesRUT = new bool[] {false} ;
         BC000S33_A902ProfesionalesTipoEmpresa = new short[1] ;
         BC000S33_n902ProfesionalesTipoEmpresa = new bool[] {false} ;
         BC000S33_A676ProfesionalesEsRUT = new bool[] {false} ;
         BC000S33_n676ProfesionalesEsRUT = new bool[] {false} ;
         BC000S33_A166ProfesionalesPrimerNombre = new string[] {""} ;
         BC000S33_A191ProfesionalesSegundoNombre = new string[] {""} ;
         BC000S33_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         BC000S33_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         BC000S33_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         BC000S33_A170ProfesionalesTelefono = new string[] {""} ;
         BC000S33_A193ProfesionalesEmail = new string[] {""} ;
         BC000S33_n193ProfesionalesEmail = new bool[] {false} ;
         BC000S33_A198ProfesionalesDireccion = new string[] {""} ;
         BC000S33_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         BC000S33_A436ProfesionalesPerAltShop = new string[] {""} ;
         BC000S33_n436ProfesionalesPerAltShop = new bool[] {false} ;
         BC000S33_A196ProfesionalesAutoEnumerar = new short[1] ;
         BC000S33_A197ProfesionalesAutoEnuZona = new short[1] ;
         BC000S33_A677ProfesionalesExperiencia = new string[] {""} ;
         BC000S33_n677ProfesionalesExperiencia = new bool[] {false} ;
         BC000S33_A678ProfesionalesAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         BC000S33_n678ProfesionalesAceptoTerminos = new bool[] {false} ;
         BC000S33_A679ProfesionalesDeclaroDatosV = new DateTime[] {DateTime.MinValue} ;
         BC000S33_n679ProfesionalesDeclaroDatosV = new bool[] {false} ;
         BC000S33_A680ProfesionalesCuentaBancaria = new string[] {""} ;
         BC000S33_n680ProfesionalesCuentaBancaria = new bool[] {false} ;
         BC000S33_A800ProfesionalesCapacidadProducti = new decimal[1] ;
         BC000S33_A674BancoNombre = new string[] {""} ;
         BC000S33_A617ProfesionalesLimitOSF = new short[1] ;
         BC000S33_n617ProfesionalesLimitOSF = new bool[] {false} ;
         BC000S33_A268ProfesionalesFeedBackCant = new long[1] ;
         BC000S33_A269ProfesionalesFeedBackProm = new decimal[1] ;
         BC000S33_A107EstadosTipo = new string[] {""} ;
         BC000S33_A108EstadosGenericosId = new int[1] ;
         BC000S33_A673BancoId = new long[1] ;
         BC000S33_n673BancoId = new bool[] {false} ;
         BC000S33_A169ProfesionalesPhoto = new string[] {""} ;
         Z124EstadosProfRubTipo = "";
         A124EstadosProfRubTipo = "";
         Z122RubrosNombre = "";
         A122RubrosNombre = "";
         Z123RubrosEstado = "";
         A123RubrosEstado = "";
         Z221EstadosProfRubNomb = "";
         A221EstadosProfRubNomb = "";
         Z168RubrosImagen = "";
         A168RubrosImagen = "";
         Z40001RubrosImagen_GXI = "";
         A40001RubrosImagen_GXI = "";
         BC000S13_A221EstadosProfRubNomb = new string[] {""} ;
         BC000S12_A122RubrosNombre = new string[] {""} ;
         BC000S12_A40001RubrosImagen_GXI = new string[] {""} ;
         BC000S12_A123RubrosEstado = new string[] {""} ;
         BC000S12_n123RubrosEstado = new bool[] {false} ;
         BC000S12_A168RubrosImagen = new string[] {""} ;
         BC000S34_A120ProfesionalesId = new string[] {""} ;
         BC000S34_A122RubrosNombre = new string[] {""} ;
         BC000S34_A40001RubrosImagen_GXI = new string[] {""} ;
         BC000S34_A123RubrosEstado = new string[] {""} ;
         BC000S34_n123RubrosEstado = new bool[] {false} ;
         BC000S34_A221EstadosProfRubNomb = new string[] {""} ;
         BC000S34_A121RubrosId = new short[1] ;
         BC000S34_A124EstadosProfRubTipo = new string[] {""} ;
         BC000S34_A125EstadosProfRubId = new int[1] ;
         BC000S34_A168RubrosImagen = new string[] {""} ;
         BC000S35_A120ProfesionalesId = new string[] {""} ;
         BC000S35_A121RubrosId = new short[1] ;
         BC000S11_A120ProfesionalesId = new string[] {""} ;
         BC000S11_A121RubrosId = new short[1] ;
         BC000S11_A124EstadosProfRubTipo = new string[] {""} ;
         BC000S11_A125EstadosProfRubId = new int[1] ;
         sMode35 = "";
         BC000S10_A120ProfesionalesId = new string[] {""} ;
         BC000S10_A121RubrosId = new short[1] ;
         BC000S10_A124EstadosProfRubTipo = new string[] {""} ;
         BC000S10_A125EstadosProfRubId = new int[1] ;
         BC000S39_A122RubrosNombre = new string[] {""} ;
         BC000S39_A40001RubrosImagen_GXI = new string[] {""} ;
         BC000S39_A123RubrosEstado = new string[] {""} ;
         BC000S39_n123RubrosEstado = new bool[] {false} ;
         BC000S39_A168RubrosImagen = new string[] {""} ;
         BC000S40_A221EstadosProfRubNomb = new string[] {""} ;
         BC000S41_A120ProfesionalesId = new string[] {""} ;
         BC000S41_A122RubrosNombre = new string[] {""} ;
         BC000S41_A40001RubrosImagen_GXI = new string[] {""} ;
         BC000S41_A123RubrosEstado = new string[] {""} ;
         BC000S41_n123RubrosEstado = new bool[] {false} ;
         BC000S41_A221EstadosProfRubNomb = new string[] {""} ;
         BC000S41_A121RubrosId = new short[1] ;
         BC000S41_A124EstadosProfRubTipo = new string[] {""} ;
         BC000S41_A125EstadosProfRubId = new int[1] ;
         BC000S41_A168RubrosImagen = new string[] {""} ;
         Z113DepartamentoDepartamento = "";
         A113DepartamentoDepartamento = "";
         Z116PaisID = "";
         A116PaisID = "";
         BC000S42_A120ProfesionalesId = new string[] {""} ;
         BC000S42_A126ProfesionalesZonasCorrelativo = new short[1] ;
         BC000S42_A113DepartamentoDepartamento = new string[] {""} ;
         BC000S42_A112DepartamentoId = new long[1] ;
         BC000S42_A114DepartamentoMunicipioId = new long[1] ;
         BC000S42_A110ZonasID = new long[1] ;
         BC000S42_n110ZonasID = new bool[] {false} ;
         BC000S42_A116PaisID = new string[] {""} ;
         BC000S7_A113DepartamentoDepartamento = new string[] {""} ;
         BC000S7_A116PaisID = new string[] {""} ;
         BC000S8_A112DepartamentoId = new long[1] ;
         BC000S9_A110ZonasID = new long[1] ;
         BC000S9_n110ZonasID = new bool[] {false} ;
         BC000S43_A120ProfesionalesId = new string[] {""} ;
         BC000S43_A126ProfesionalesZonasCorrelativo = new short[1] ;
         BC000S6_A120ProfesionalesId = new string[] {""} ;
         BC000S6_A126ProfesionalesZonasCorrelativo = new short[1] ;
         BC000S6_A112DepartamentoId = new long[1] ;
         BC000S6_A114DepartamentoMunicipioId = new long[1] ;
         BC000S6_A110ZonasID = new long[1] ;
         BC000S6_n110ZonasID = new bool[] {false} ;
         sMode36 = "";
         BC000S5_A120ProfesionalesId = new string[] {""} ;
         BC000S5_A126ProfesionalesZonasCorrelativo = new short[1] ;
         BC000S5_A112DepartamentoId = new long[1] ;
         BC000S5_A114DepartamentoMunicipioId = new long[1] ;
         BC000S5_A110ZonasID = new long[1] ;
         BC000S5_n110ZonasID = new bool[] {false} ;
         BC000S47_A113DepartamentoDepartamento = new string[] {""} ;
         BC000S47_A116PaisID = new string[] {""} ;
         BC000S48_A120ProfesionalesId = new string[] {""} ;
         BC000S48_A126ProfesionalesZonasCorrelativo = new short[1] ;
         BC000S48_A113DepartamentoDepartamento = new string[] {""} ;
         BC000S48_A112DepartamentoId = new long[1] ;
         BC000S48_A114DepartamentoMunicipioId = new long[1] ;
         BC000S48_A110ZonasID = new long[1] ;
         BC000S48_n110ZonasID = new bool[] {false} ;
         BC000S48_A116PaisID = new string[] {""} ;
         Z995EstadoServProf = "";
         A995EstadoServProf = "";
         Z994ProfesionalServicioNombre = "";
         A994ProfesionalServicioNombre = "";
         BC000S49_A120ProfesionalesId = new string[] {""} ;
         BC000S49_A994ProfesionalServicioNombre = new string[] {""} ;
         BC000S49_A995EstadoServProf = new string[] {""} ;
         BC000S49_n995EstadoServProf = new bool[] {false} ;
         BC000S49_A993ProfesionalServicioId = new long[1] ;
         BC000S4_A994ProfesionalServicioNombre = new string[] {""} ;
         BC000S50_A120ProfesionalesId = new string[] {""} ;
         BC000S50_A993ProfesionalServicioId = new long[1] ;
         BC000S3_A120ProfesionalesId = new string[] {""} ;
         BC000S3_A995EstadoServProf = new string[] {""} ;
         BC000S3_n995EstadoServProf = new bool[] {false} ;
         BC000S3_A993ProfesionalServicioId = new long[1] ;
         sMode145 = "";
         BC000S2_A120ProfesionalesId = new string[] {""} ;
         BC000S2_A995EstadoServProf = new string[] {""} ;
         BC000S2_n995EstadoServProf = new bool[] {false} ;
         BC000S2_A993ProfesionalServicioId = new long[1] ;
         BC000S54_A994ProfesionalServicioNombre = new string[] {""} ;
         BC000S55_A120ProfesionalesId = new string[] {""} ;
         BC000S55_A994ProfesionalServicioNombre = new string[] {""} ;
         BC000S55_A995EstadoServProf = new string[] {""} ;
         BC000S55_n995EstadoServProf = new bool[] {false} ;
         BC000S55_A993ProfesionalServicioId = new long[1] ;
         i107EstadosTipo = "";
         i199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         i200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         i267ProfesionalesVerDatPerSol = "";
         i436ProfesionalesPerAltShop = "";
         i124EstadosProfRubTipo = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.profesionales_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionales_bc__default(),
            new Object[][] {
                new Object[] {
               BC000S2_A120ProfesionalesId, BC000S2_A995EstadoServProf, BC000S2_n995EstadoServProf, BC000S2_A993ProfesionalServicioId
               }
               , new Object[] {
               BC000S3_A120ProfesionalesId, BC000S3_A995EstadoServProf, BC000S3_n995EstadoServProf, BC000S3_A993ProfesionalServicioId
               }
               , new Object[] {
               BC000S4_A994ProfesionalServicioNombre
               }
               , new Object[] {
               BC000S5_A120ProfesionalesId, BC000S5_A126ProfesionalesZonasCorrelativo, BC000S5_A112DepartamentoId, BC000S5_A114DepartamentoMunicipioId, BC000S5_A110ZonasID, BC000S5_n110ZonasID
               }
               , new Object[] {
               BC000S6_A120ProfesionalesId, BC000S6_A126ProfesionalesZonasCorrelativo, BC000S6_A112DepartamentoId, BC000S6_A114DepartamentoMunicipioId, BC000S6_A110ZonasID, BC000S6_n110ZonasID
               }
               , new Object[] {
               BC000S7_A113DepartamentoDepartamento, BC000S7_A116PaisID
               }
               , new Object[] {
               BC000S8_A112DepartamentoId
               }
               , new Object[] {
               BC000S9_A110ZonasID
               }
               , new Object[] {
               BC000S10_A120ProfesionalesId, BC000S10_A121RubrosId, BC000S10_A124EstadosProfRubTipo, BC000S10_A125EstadosProfRubId
               }
               , new Object[] {
               BC000S11_A120ProfesionalesId, BC000S11_A121RubrosId, BC000S11_A124EstadosProfRubTipo, BC000S11_A125EstadosProfRubId
               }
               , new Object[] {
               BC000S12_A122RubrosNombre, BC000S12_A40001RubrosImagen_GXI, BC000S12_A123RubrosEstado, BC000S12_n123RubrosEstado, BC000S12_A168RubrosImagen
               }
               , new Object[] {
               BC000S13_A221EstadosProfRubNomb
               }
               , new Object[] {
               BC000S14_A120ProfesionalesId, BC000S14_A199ProfesionalesFechaAlta, BC000S14_A200ProfesionalesFechaActualizado, BC000S14_A900ProfesionalesFechaNacimiento, BC000S14_n900ProfesionalesFechaNacimiento, BC000S14_A901ProfesionalesRUT, BC000S14_n901ProfesionalesRUT, BC000S14_A902ProfesionalesTipoEmpresa, BC000S14_n902ProfesionalesTipoEmpresa, BC000S14_A676ProfesionalesEsRUT,
               BC000S14_n676ProfesionalesEsRUT, BC000S14_A166ProfesionalesPrimerNombre, BC000S14_A191ProfesionalesSegundoNombre, BC000S14_A167ProfesionalesApellidoPrimero, BC000S14_A192ProfesionalesApellidoSegundo, BC000S14_A40000ProfesionalesPhoto_GXI, BC000S14_A170ProfesionalesTelefono, BC000S14_A193ProfesionalesEmail, BC000S14_n193ProfesionalesEmail, BC000S14_A198ProfesionalesDireccion,
               BC000S14_A267ProfesionalesVerDatPerSol, BC000S14_A436ProfesionalesPerAltShop, BC000S14_n436ProfesionalesPerAltShop, BC000S14_A196ProfesionalesAutoEnumerar, BC000S14_A197ProfesionalesAutoEnuZona, BC000S14_A677ProfesionalesExperiencia, BC000S14_n677ProfesionalesExperiencia, BC000S14_A678ProfesionalesAceptoTerminos, BC000S14_n678ProfesionalesAceptoTerminos, BC000S14_A679ProfesionalesDeclaroDatosV,
               BC000S14_n679ProfesionalesDeclaroDatosV, BC000S14_A680ProfesionalesCuentaBancaria, BC000S14_n680ProfesionalesCuentaBancaria, BC000S14_A800ProfesionalesCapacidadProducti, BC000S14_A617ProfesionalesLimitOSF, BC000S14_n617ProfesionalesLimitOSF, BC000S14_A268ProfesionalesFeedBackCant, BC000S14_A269ProfesionalesFeedBackProm, BC000S14_A107EstadosTipo, BC000S14_A108EstadosGenericosId,
               BC000S14_A673BancoId, BC000S14_n673BancoId, BC000S14_A169ProfesionalesPhoto
               }
               , new Object[] {
               BC000S15_A120ProfesionalesId, BC000S15_A199ProfesionalesFechaAlta, BC000S15_A200ProfesionalesFechaActualizado, BC000S15_A900ProfesionalesFechaNacimiento, BC000S15_n900ProfesionalesFechaNacimiento, BC000S15_A901ProfesionalesRUT, BC000S15_n901ProfesionalesRUT, BC000S15_A902ProfesionalesTipoEmpresa, BC000S15_n902ProfesionalesTipoEmpresa, BC000S15_A676ProfesionalesEsRUT,
               BC000S15_n676ProfesionalesEsRUT, BC000S15_A166ProfesionalesPrimerNombre, BC000S15_A191ProfesionalesSegundoNombre, BC000S15_A167ProfesionalesApellidoPrimero, BC000S15_A192ProfesionalesApellidoSegundo, BC000S15_A40000ProfesionalesPhoto_GXI, BC000S15_A170ProfesionalesTelefono, BC000S15_A193ProfesionalesEmail, BC000S15_n193ProfesionalesEmail, BC000S15_A198ProfesionalesDireccion,
               BC000S15_A267ProfesionalesVerDatPerSol, BC000S15_A436ProfesionalesPerAltShop, BC000S15_n436ProfesionalesPerAltShop, BC000S15_A196ProfesionalesAutoEnumerar, BC000S15_A197ProfesionalesAutoEnuZona, BC000S15_A677ProfesionalesExperiencia, BC000S15_n677ProfesionalesExperiencia, BC000S15_A678ProfesionalesAceptoTerminos, BC000S15_n678ProfesionalesAceptoTerminos, BC000S15_A679ProfesionalesDeclaroDatosV,
               BC000S15_n679ProfesionalesDeclaroDatosV, BC000S15_A680ProfesionalesCuentaBancaria, BC000S15_n680ProfesionalesCuentaBancaria, BC000S15_A800ProfesionalesCapacidadProducti, BC000S15_A617ProfesionalesLimitOSF, BC000S15_n617ProfesionalesLimitOSF, BC000S15_A268ProfesionalesFeedBackCant, BC000S15_A269ProfesionalesFeedBackProm, BC000S15_A107EstadosTipo, BC000S15_A108EstadosGenericosId,
               BC000S15_A673BancoId, BC000S15_n673BancoId, BC000S15_A169ProfesionalesPhoto
               }
               , new Object[] {
               BC000S16_A107EstadosTipo
               }
               , new Object[] {
               BC000S17_A674BancoNombre
               }
               , new Object[] {
               BC000S18_A120ProfesionalesId, BC000S18_A199ProfesionalesFechaAlta, BC000S18_A200ProfesionalesFechaActualizado, BC000S18_A900ProfesionalesFechaNacimiento, BC000S18_n900ProfesionalesFechaNacimiento, BC000S18_A901ProfesionalesRUT, BC000S18_n901ProfesionalesRUT, BC000S18_A902ProfesionalesTipoEmpresa, BC000S18_n902ProfesionalesTipoEmpresa, BC000S18_A676ProfesionalesEsRUT,
               BC000S18_n676ProfesionalesEsRUT, BC000S18_A166ProfesionalesPrimerNombre, BC000S18_A191ProfesionalesSegundoNombre, BC000S18_A167ProfesionalesApellidoPrimero, BC000S18_A192ProfesionalesApellidoSegundo, BC000S18_A40000ProfesionalesPhoto_GXI, BC000S18_A170ProfesionalesTelefono, BC000S18_A193ProfesionalesEmail, BC000S18_n193ProfesionalesEmail, BC000S18_A198ProfesionalesDireccion,
               BC000S18_A267ProfesionalesVerDatPerSol, BC000S18_A436ProfesionalesPerAltShop, BC000S18_n436ProfesionalesPerAltShop, BC000S18_A196ProfesionalesAutoEnumerar, BC000S18_A197ProfesionalesAutoEnuZona, BC000S18_A677ProfesionalesExperiencia, BC000S18_n677ProfesionalesExperiencia, BC000S18_A678ProfesionalesAceptoTerminos, BC000S18_n678ProfesionalesAceptoTerminos, BC000S18_A679ProfesionalesDeclaroDatosV,
               BC000S18_n679ProfesionalesDeclaroDatosV, BC000S18_A680ProfesionalesCuentaBancaria, BC000S18_n680ProfesionalesCuentaBancaria, BC000S18_A800ProfesionalesCapacidadProducti, BC000S18_A674BancoNombre, BC000S18_A617ProfesionalesLimitOSF, BC000S18_n617ProfesionalesLimitOSF, BC000S18_A268ProfesionalesFeedBackCant, BC000S18_A269ProfesionalesFeedBackProm, BC000S18_A107EstadosTipo,
               BC000S18_A108EstadosGenericosId, BC000S18_A673BancoId, BC000S18_n673BancoId, BC000S18_A169ProfesionalesPhoto
               }
               , new Object[] {
               BC000S19_A120ProfesionalesId
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
               BC000S24_A674BancoNombre
               }
               , new Object[] {
               BC000S25_A461CentroCostosId, BC000S25_A466CentroCostosDetallesId
               }
               , new Object[] {
               BC000S26_A976ProfesionalesRestriccionId
               }
               , new Object[] {
               BC000S27_A450ProfComisionesID
               }
               , new Object[] {
               BC000S28_A127SolicitudesID, BC000S28_A140RelacionesId
               }
               , new Object[] {
               BC000S29_A422PostulacionesId, BC000S29_A120ProfesionalesId
               }
               , new Object[] {
               BC000S30_A590Listaid, BC000S30_A133ProveedorID, BC000S30_A120ProfesionalesId
               }
               , new Object[] {
               BC000S31_A503ComisionesID, BC000S31_A120ProfesionalesId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000S33_A120ProfesionalesId, BC000S33_A199ProfesionalesFechaAlta, BC000S33_A200ProfesionalesFechaActualizado, BC000S33_A900ProfesionalesFechaNacimiento, BC000S33_n900ProfesionalesFechaNacimiento, BC000S33_A901ProfesionalesRUT, BC000S33_n901ProfesionalesRUT, BC000S33_A902ProfesionalesTipoEmpresa, BC000S33_n902ProfesionalesTipoEmpresa, BC000S33_A676ProfesionalesEsRUT,
               BC000S33_n676ProfesionalesEsRUT, BC000S33_A166ProfesionalesPrimerNombre, BC000S33_A191ProfesionalesSegundoNombre, BC000S33_A167ProfesionalesApellidoPrimero, BC000S33_A192ProfesionalesApellidoSegundo, BC000S33_A40000ProfesionalesPhoto_GXI, BC000S33_A170ProfesionalesTelefono, BC000S33_A193ProfesionalesEmail, BC000S33_n193ProfesionalesEmail, BC000S33_A198ProfesionalesDireccion,
               BC000S33_A267ProfesionalesVerDatPerSol, BC000S33_A436ProfesionalesPerAltShop, BC000S33_n436ProfesionalesPerAltShop, BC000S33_A196ProfesionalesAutoEnumerar, BC000S33_A197ProfesionalesAutoEnuZona, BC000S33_A677ProfesionalesExperiencia, BC000S33_n677ProfesionalesExperiencia, BC000S33_A678ProfesionalesAceptoTerminos, BC000S33_n678ProfesionalesAceptoTerminos, BC000S33_A679ProfesionalesDeclaroDatosV,
               BC000S33_n679ProfesionalesDeclaroDatosV, BC000S33_A680ProfesionalesCuentaBancaria, BC000S33_n680ProfesionalesCuentaBancaria, BC000S33_A800ProfesionalesCapacidadProducti, BC000S33_A674BancoNombre, BC000S33_A617ProfesionalesLimitOSF, BC000S33_n617ProfesionalesLimitOSF, BC000S33_A268ProfesionalesFeedBackCant, BC000S33_A269ProfesionalesFeedBackProm, BC000S33_A107EstadosTipo,
               BC000S33_A108EstadosGenericosId, BC000S33_A673BancoId, BC000S33_n673BancoId, BC000S33_A169ProfesionalesPhoto
               }
               , new Object[] {
               BC000S34_A120ProfesionalesId, BC000S34_A122RubrosNombre, BC000S34_A40001RubrosImagen_GXI, BC000S34_A123RubrosEstado, BC000S34_n123RubrosEstado, BC000S34_A221EstadosProfRubNomb, BC000S34_A121RubrosId, BC000S34_A124EstadosProfRubTipo, BC000S34_A125EstadosProfRubId, BC000S34_A168RubrosImagen
               }
               , new Object[] {
               BC000S35_A120ProfesionalesId, BC000S35_A121RubrosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000S39_A122RubrosNombre, BC000S39_A40001RubrosImagen_GXI, BC000S39_A123RubrosEstado, BC000S39_n123RubrosEstado, BC000S39_A168RubrosImagen
               }
               , new Object[] {
               BC000S40_A221EstadosProfRubNomb
               }
               , new Object[] {
               BC000S41_A120ProfesionalesId, BC000S41_A122RubrosNombre, BC000S41_A40001RubrosImagen_GXI, BC000S41_A123RubrosEstado, BC000S41_n123RubrosEstado, BC000S41_A221EstadosProfRubNomb, BC000S41_A121RubrosId, BC000S41_A124EstadosProfRubTipo, BC000S41_A125EstadosProfRubId, BC000S41_A168RubrosImagen
               }
               , new Object[] {
               BC000S42_A120ProfesionalesId, BC000S42_A126ProfesionalesZonasCorrelativo, BC000S42_A113DepartamentoDepartamento, BC000S42_A112DepartamentoId, BC000S42_A114DepartamentoMunicipioId, BC000S42_A110ZonasID, BC000S42_n110ZonasID, BC000S42_A116PaisID
               }
               , new Object[] {
               BC000S43_A120ProfesionalesId, BC000S43_A126ProfesionalesZonasCorrelativo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000S47_A113DepartamentoDepartamento, BC000S47_A116PaisID
               }
               , new Object[] {
               BC000S48_A120ProfesionalesId, BC000S48_A126ProfesionalesZonasCorrelativo, BC000S48_A113DepartamentoDepartamento, BC000S48_A112DepartamentoId, BC000S48_A114DepartamentoMunicipioId, BC000S48_A110ZonasID, BC000S48_n110ZonasID, BC000S48_A116PaisID
               }
               , new Object[] {
               BC000S49_A120ProfesionalesId, BC000S49_A994ProfesionalServicioNombre, BC000S49_A995EstadoServProf, BC000S49_n995EstadoServProf, BC000S49_A993ProfesionalServicioId
               }
               , new Object[] {
               BC000S50_A120ProfesionalesId, BC000S50_A993ProfesionalServicioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000S54_A994ProfesionalServicioNombre
               }
               , new Object[] {
               BC000S55_A120ProfesionalesId, BC000S55_A994ProfesionalServicioNombre, BC000S55_A995EstadoServProf, BC000S55_n995EstadoServProf, BC000S55_A993ProfesionalServicioId
               }
            }
         );
         AV34Pgmname = "Profesionales_BC";
         Z800ProfesionalesCapacidadProducti = (decimal)(8);
         A800ProfesionalesCapacidadProducti = (decimal)(8);
         i800ProfesionalesCapacidadProducti = (decimal)(8);
         Z436ProfesionalesPerAltShop = context.GetMessage( "N", "");
         n436ProfesionalesPerAltShop = false;
         A436ProfesionalesPerAltShop = context.GetMessage( "N", "");
         n436ProfesionalesPerAltShop = false;
         i436ProfesionalesPerAltShop = context.GetMessage( "N", "");
         n436ProfesionalesPerAltShop = false;
         Z267ProfesionalesVerDatPerSol = context.GetMessage( "N", "");
         A267ProfesionalesVerDatPerSol = context.GetMessage( "N", "");
         i267ProfesionalesVerDatPerSol = context.GetMessage( "N", "");
         Z121RubrosId = 0;
         A121RubrosId = 0;
         Z126ProfesionalesZonasCorrelativo = 0;
         A126ProfesionalesZonasCorrelativo = 0;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120S2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_145 ;
      private short RcdFound145 ;
      private short s197ProfesionalesAutoEnuZona ;
      private short O197ProfesionalesAutoEnuZona ;
      private short A197ProfesionalesAutoEnuZona ;
      private short nIsMod_36 ;
      private short RcdFound36 ;
      private short nIsMod_35 ;
      private short RcdFound35 ;
      private short Z902ProfesionalesTipoEmpresa ;
      private short A902ProfesionalesTipoEmpresa ;
      private short Z196ProfesionalesAutoEnumerar ;
      private short A196ProfesionalesAutoEnumerar ;
      private short Z197ProfesionalesAutoEnuZona ;
      private short Z617ProfesionalesLimitOSF ;
      private short A617ProfesionalesLimitOSF ;
      private short Gx_BScreen ;
      private short RcdFound34 ;
      private short nRcdExists_35 ;
      private short nRcdExists_36 ;
      private short nRcdExists_145 ;
      private short Z121RubrosId ;
      private short A121RubrosId ;
      private short Gxremove35 ;
      private short Z126ProfesionalesZonasCorrelativo ;
      private short A126ProfesionalesZonasCorrelativo ;
      private short Gxremove36 ;
      private short Gxremove145 ;
      private short i197ProfesionalesAutoEnuZona ;
      private int trnEnded ;
      private int nGXsfl_145_idx=1 ;
      private int nGXsfl_36_idx=1 ;
      private int nGXsfl_35_idx=1 ;
      private int AV35GXV1 ;
      private int AV12Insert_EstadosGenericosId ;
      private int Z108EstadosGenericosId ;
      private int A108EstadosGenericosId ;
      private int Z125EstadosProfRubId ;
      private int A125EstadosProfRubId ;
      private int i108EstadosGenericosId ;
      private int i125EstadosProfRubId ;
      private long AV32Insert_BancoId ;
      private long Z268ProfesionalesFeedBackCant ;
      private long A268ProfesionalesFeedBackCant ;
      private long Z673BancoId ;
      private long A673BancoId ;
      private long Z112DepartamentoId ;
      private long A112DepartamentoId ;
      private long Z114DepartamentoMunicipioId ;
      private long A114DepartamentoMunicipioId ;
      private long Z110ZonasID ;
      private long A110ZonasID ;
      private long Z993ProfesionalServicioId ;
      private long A993ProfesionalServicioId ;
      private decimal Z800ProfesionalesCapacidadProducti ;
      private decimal A800ProfesionalesCapacidadProducti ;
      private decimal Z269ProfesionalesFeedBackProm ;
      private decimal A269ProfesionalesFeedBackProm ;
      private decimal Z803ProfesionalesTiempoDisponible ;
      private decimal A803ProfesionalesTiempoDisponible ;
      private decimal Z270ProfesionalesFeedback ;
      private decimal A270ProfesionalesFeedback ;
      private decimal AV14ProfesionalesFeedback ;
      private decimal i800ProfesionalesCapacidadProducti ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z120ProfesionalesId ;
      private string A120ProfesionalesId ;
      private string sMode34 ;
      private string AV34Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV11Insert_EstadosTipo ;
      private string Z901ProfesionalesRUT ;
      private string A901ProfesionalesRUT ;
      private string Z166ProfesionalesPrimerNombre ;
      private string A166ProfesionalesPrimerNombre ;
      private string Z191ProfesionalesSegundoNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string Z167ProfesionalesApellidoPrimero ;
      private string A167ProfesionalesApellidoPrimero ;
      private string Z192ProfesionalesApellidoSegundo ;
      private string A192ProfesionalesApellidoSegundo ;
      private string Z170ProfesionalesTelefono ;
      private string A170ProfesionalesTelefono ;
      private string Z267ProfesionalesVerDatPerSol ;
      private string A267ProfesionalesVerDatPerSol ;
      private string Z436ProfesionalesPerAltShop ;
      private string A436ProfesionalesPerAltShop ;
      private string Z680ProfesionalesCuentaBancaria ;
      private string A680ProfesionalesCuentaBancaria ;
      private string Z107EstadosTipo ;
      private string A107EstadosTipo ;
      private string Z674BancoNombre ;
      private string A674BancoNombre ;
      private string Z124EstadosProfRubTipo ;
      private string A124EstadosProfRubTipo ;
      private string Z122RubrosNombre ;
      private string A122RubrosNombre ;
      private string Z123RubrosEstado ;
      private string A123RubrosEstado ;
      private string Z221EstadosProfRubNomb ;
      private string A221EstadosProfRubNomb ;
      private string sMode35 ;
      private string Z113DepartamentoDepartamento ;
      private string A113DepartamentoDepartamento ;
      private string Z116PaisID ;
      private string A116PaisID ;
      private string sMode36 ;
      private string Z995EstadoServProf ;
      private string A995EstadoServProf ;
      private string Z994ProfesionalServicioNombre ;
      private string A994ProfesionalServicioNombre ;
      private string sMode145 ;
      private string i107EstadosTipo ;
      private string i267ProfesionalesVerDatPerSol ;
      private string i436ProfesionalesPerAltShop ;
      private string i124EstadosProfRubTipo ;
      private DateTime Z199ProfesionalesFechaAlta ;
      private DateTime A199ProfesionalesFechaAlta ;
      private DateTime Z200ProfesionalesFechaActualizado ;
      private DateTime A200ProfesionalesFechaActualizado ;
      private DateTime Z678ProfesionalesAceptoTerminos ;
      private DateTime A678ProfesionalesAceptoTerminos ;
      private DateTime Z679ProfesionalesDeclaroDatosV ;
      private DateTime A679ProfesionalesDeclaroDatosV ;
      private DateTime i199ProfesionalesFechaAlta ;
      private DateTime i200ProfesionalesFechaActualizado ;
      private DateTime Z900ProfesionalesFechaNacimiento ;
      private DateTime A900ProfesionalesFechaNacimiento ;
      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Z676ProfesionalesEsRUT ;
      private bool A676ProfesionalesEsRUT ;
      private bool n436ProfesionalesPerAltShop ;
      private bool n900ProfesionalesFechaNacimiento ;
      private bool n901ProfesionalesRUT ;
      private bool n902ProfesionalesTipoEmpresa ;
      private bool n676ProfesionalesEsRUT ;
      private bool n193ProfesionalesEmail ;
      private bool n677ProfesionalesExperiencia ;
      private bool n678ProfesionalesAceptoTerminos ;
      private bool n679ProfesionalesDeclaroDatosV ;
      private bool n680ProfesionalesCuentaBancaria ;
      private bool n617ProfesionalesLimitOSF ;
      private bool n673BancoId ;
      private bool Gx_longc ;
      private bool n123RubrosEstado ;
      private bool n110ZonasID ;
      private bool n995EstadoServProf ;
      private string Z193ProfesionalesEmail ;
      private string A193ProfesionalesEmail ;
      private string Z198ProfesionalesDireccion ;
      private string A198ProfesionalesDireccion ;
      private string Z677ProfesionalesExperiencia ;
      private string A677ProfesionalesExperiencia ;
      private string Z886ProfesionalesNombreCompleto ;
      private string A886ProfesionalesNombreCompleto ;
      private string Z40000ProfesionalesPhoto_GXI ;
      private string A40000ProfesionalesPhoto_GXI ;
      private string Z40001RubrosImagen_GXI ;
      private string A40001RubrosImagen_GXI ;
      private string Z169ProfesionalesPhoto ;
      private string A169ProfesionalesPhoto ;
      private string Z168RubrosImagen ;
      private string A168RubrosImagen ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtProfesionales bcProfesionales ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV15WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] BC000S18_A120ProfesionalesId ;
      private DateTime[] BC000S18_A199ProfesionalesFechaAlta ;
      private DateTime[] BC000S18_A200ProfesionalesFechaActualizado ;
      private DateTime[] BC000S18_A900ProfesionalesFechaNacimiento ;
      private bool[] BC000S18_n900ProfesionalesFechaNacimiento ;
      private string[] BC000S18_A901ProfesionalesRUT ;
      private bool[] BC000S18_n901ProfesionalesRUT ;
      private short[] BC000S18_A902ProfesionalesTipoEmpresa ;
      private bool[] BC000S18_n902ProfesionalesTipoEmpresa ;
      private bool[] BC000S18_A676ProfesionalesEsRUT ;
      private bool[] BC000S18_n676ProfesionalesEsRUT ;
      private string[] BC000S18_A166ProfesionalesPrimerNombre ;
      private string[] BC000S18_A191ProfesionalesSegundoNombre ;
      private string[] BC000S18_A167ProfesionalesApellidoPrimero ;
      private string[] BC000S18_A192ProfesionalesApellidoSegundo ;
      private string[] BC000S18_A40000ProfesionalesPhoto_GXI ;
      private string[] BC000S18_A170ProfesionalesTelefono ;
      private string[] BC000S18_A193ProfesionalesEmail ;
      private bool[] BC000S18_n193ProfesionalesEmail ;
      private string[] BC000S18_A198ProfesionalesDireccion ;
      private string[] BC000S18_A267ProfesionalesVerDatPerSol ;
      private string[] BC000S18_A436ProfesionalesPerAltShop ;
      private bool[] BC000S18_n436ProfesionalesPerAltShop ;
      private short[] BC000S18_A196ProfesionalesAutoEnumerar ;
      private short[] BC000S18_A197ProfesionalesAutoEnuZona ;
      private string[] BC000S18_A677ProfesionalesExperiencia ;
      private bool[] BC000S18_n677ProfesionalesExperiencia ;
      private DateTime[] BC000S18_A678ProfesionalesAceptoTerminos ;
      private bool[] BC000S18_n678ProfesionalesAceptoTerminos ;
      private DateTime[] BC000S18_A679ProfesionalesDeclaroDatosV ;
      private bool[] BC000S18_n679ProfesionalesDeclaroDatosV ;
      private string[] BC000S18_A680ProfesionalesCuentaBancaria ;
      private bool[] BC000S18_n680ProfesionalesCuentaBancaria ;
      private decimal[] BC000S18_A800ProfesionalesCapacidadProducti ;
      private string[] BC000S18_A674BancoNombre ;
      private short[] BC000S18_A617ProfesionalesLimitOSF ;
      private bool[] BC000S18_n617ProfesionalesLimitOSF ;
      private long[] BC000S18_A268ProfesionalesFeedBackCant ;
      private decimal[] BC000S18_A269ProfesionalesFeedBackProm ;
      private string[] BC000S18_A107EstadosTipo ;
      private int[] BC000S18_A108EstadosGenericosId ;
      private long[] BC000S18_A673BancoId ;
      private bool[] BC000S18_n673BancoId ;
      private string[] BC000S18_A169ProfesionalesPhoto ;
      private string[] BC000S17_A674BancoNombre ;
      private string[] BC000S16_A107EstadosTipo ;
      private string[] BC000S19_A120ProfesionalesId ;
      private string[] BC000S15_A120ProfesionalesId ;
      private DateTime[] BC000S15_A199ProfesionalesFechaAlta ;
      private DateTime[] BC000S15_A200ProfesionalesFechaActualizado ;
      private DateTime[] BC000S15_A900ProfesionalesFechaNacimiento ;
      private bool[] BC000S15_n900ProfesionalesFechaNacimiento ;
      private string[] BC000S15_A901ProfesionalesRUT ;
      private bool[] BC000S15_n901ProfesionalesRUT ;
      private short[] BC000S15_A902ProfesionalesTipoEmpresa ;
      private bool[] BC000S15_n902ProfesionalesTipoEmpresa ;
      private bool[] BC000S15_A676ProfesionalesEsRUT ;
      private bool[] BC000S15_n676ProfesionalesEsRUT ;
      private string[] BC000S15_A166ProfesionalesPrimerNombre ;
      private string[] BC000S15_A191ProfesionalesSegundoNombre ;
      private string[] BC000S15_A167ProfesionalesApellidoPrimero ;
      private string[] BC000S15_A192ProfesionalesApellidoSegundo ;
      private string[] BC000S15_A40000ProfesionalesPhoto_GXI ;
      private string[] BC000S15_A170ProfesionalesTelefono ;
      private string[] BC000S15_A193ProfesionalesEmail ;
      private bool[] BC000S15_n193ProfesionalesEmail ;
      private string[] BC000S15_A198ProfesionalesDireccion ;
      private string[] BC000S15_A267ProfesionalesVerDatPerSol ;
      private string[] BC000S15_A436ProfesionalesPerAltShop ;
      private bool[] BC000S15_n436ProfesionalesPerAltShop ;
      private short[] BC000S15_A196ProfesionalesAutoEnumerar ;
      private short[] BC000S15_A197ProfesionalesAutoEnuZona ;
      private string[] BC000S15_A677ProfesionalesExperiencia ;
      private bool[] BC000S15_n677ProfesionalesExperiencia ;
      private DateTime[] BC000S15_A678ProfesionalesAceptoTerminos ;
      private bool[] BC000S15_n678ProfesionalesAceptoTerminos ;
      private DateTime[] BC000S15_A679ProfesionalesDeclaroDatosV ;
      private bool[] BC000S15_n679ProfesionalesDeclaroDatosV ;
      private string[] BC000S15_A680ProfesionalesCuentaBancaria ;
      private bool[] BC000S15_n680ProfesionalesCuentaBancaria ;
      private decimal[] BC000S15_A800ProfesionalesCapacidadProducti ;
      private short[] BC000S15_A617ProfesionalesLimitOSF ;
      private bool[] BC000S15_n617ProfesionalesLimitOSF ;
      private long[] BC000S15_A268ProfesionalesFeedBackCant ;
      private decimal[] BC000S15_A269ProfesionalesFeedBackProm ;
      private string[] BC000S15_A107EstadosTipo ;
      private int[] BC000S15_A108EstadosGenericosId ;
      private long[] BC000S15_A673BancoId ;
      private bool[] BC000S15_n673BancoId ;
      private string[] BC000S15_A169ProfesionalesPhoto ;
      private string[] BC000S14_A120ProfesionalesId ;
      private DateTime[] BC000S14_A199ProfesionalesFechaAlta ;
      private DateTime[] BC000S14_A200ProfesionalesFechaActualizado ;
      private DateTime[] BC000S14_A900ProfesionalesFechaNacimiento ;
      private bool[] BC000S14_n900ProfesionalesFechaNacimiento ;
      private string[] BC000S14_A901ProfesionalesRUT ;
      private bool[] BC000S14_n901ProfesionalesRUT ;
      private short[] BC000S14_A902ProfesionalesTipoEmpresa ;
      private bool[] BC000S14_n902ProfesionalesTipoEmpresa ;
      private bool[] BC000S14_A676ProfesionalesEsRUT ;
      private bool[] BC000S14_n676ProfesionalesEsRUT ;
      private string[] BC000S14_A166ProfesionalesPrimerNombre ;
      private string[] BC000S14_A191ProfesionalesSegundoNombre ;
      private string[] BC000S14_A167ProfesionalesApellidoPrimero ;
      private string[] BC000S14_A192ProfesionalesApellidoSegundo ;
      private string[] BC000S14_A40000ProfesionalesPhoto_GXI ;
      private string[] BC000S14_A170ProfesionalesTelefono ;
      private string[] BC000S14_A193ProfesionalesEmail ;
      private bool[] BC000S14_n193ProfesionalesEmail ;
      private string[] BC000S14_A198ProfesionalesDireccion ;
      private string[] BC000S14_A267ProfesionalesVerDatPerSol ;
      private string[] BC000S14_A436ProfesionalesPerAltShop ;
      private bool[] BC000S14_n436ProfesionalesPerAltShop ;
      private short[] BC000S14_A196ProfesionalesAutoEnumerar ;
      private short[] BC000S14_A197ProfesionalesAutoEnuZona ;
      private string[] BC000S14_A677ProfesionalesExperiencia ;
      private bool[] BC000S14_n677ProfesionalesExperiencia ;
      private DateTime[] BC000S14_A678ProfesionalesAceptoTerminos ;
      private bool[] BC000S14_n678ProfesionalesAceptoTerminos ;
      private DateTime[] BC000S14_A679ProfesionalesDeclaroDatosV ;
      private bool[] BC000S14_n679ProfesionalesDeclaroDatosV ;
      private string[] BC000S14_A680ProfesionalesCuentaBancaria ;
      private bool[] BC000S14_n680ProfesionalesCuentaBancaria ;
      private decimal[] BC000S14_A800ProfesionalesCapacidadProducti ;
      private short[] BC000S14_A617ProfesionalesLimitOSF ;
      private bool[] BC000S14_n617ProfesionalesLimitOSF ;
      private long[] BC000S14_A268ProfesionalesFeedBackCant ;
      private decimal[] BC000S14_A269ProfesionalesFeedBackProm ;
      private string[] BC000S14_A107EstadosTipo ;
      private int[] BC000S14_A108EstadosGenericosId ;
      private long[] BC000S14_A673BancoId ;
      private bool[] BC000S14_n673BancoId ;
      private string[] BC000S14_A169ProfesionalesPhoto ;
      private string[] BC000S24_A674BancoNombre ;
      private long[] BC000S25_A461CentroCostosId ;
      private long[] BC000S25_A466CentroCostosDetallesId ;
      private long[] BC000S26_A976ProfesionalesRestriccionId ;
      private long[] BC000S27_A450ProfComisionesID ;
      private long[] BC000S28_A127SolicitudesID ;
      private long[] BC000S28_A140RelacionesId ;
      private long[] BC000S29_A422PostulacionesId ;
      private string[] BC000S29_A120ProfesionalesId ;
      private long[] BC000S30_A590Listaid ;
      private long[] BC000S30_A133ProveedorID ;
      private string[] BC000S30_A120ProfesionalesId ;
      private long[] BC000S31_A503ComisionesID ;
      private string[] BC000S31_A120ProfesionalesId ;
      private string[] BC000S33_A120ProfesionalesId ;
      private DateTime[] BC000S33_A199ProfesionalesFechaAlta ;
      private DateTime[] BC000S33_A200ProfesionalesFechaActualizado ;
      private DateTime[] BC000S33_A900ProfesionalesFechaNacimiento ;
      private bool[] BC000S33_n900ProfesionalesFechaNacimiento ;
      private string[] BC000S33_A901ProfesionalesRUT ;
      private bool[] BC000S33_n901ProfesionalesRUT ;
      private short[] BC000S33_A902ProfesionalesTipoEmpresa ;
      private bool[] BC000S33_n902ProfesionalesTipoEmpresa ;
      private bool[] BC000S33_A676ProfesionalesEsRUT ;
      private bool[] BC000S33_n676ProfesionalesEsRUT ;
      private string[] BC000S33_A166ProfesionalesPrimerNombre ;
      private string[] BC000S33_A191ProfesionalesSegundoNombre ;
      private string[] BC000S33_A167ProfesionalesApellidoPrimero ;
      private string[] BC000S33_A192ProfesionalesApellidoSegundo ;
      private string[] BC000S33_A40000ProfesionalesPhoto_GXI ;
      private string[] BC000S33_A170ProfesionalesTelefono ;
      private string[] BC000S33_A193ProfesionalesEmail ;
      private bool[] BC000S33_n193ProfesionalesEmail ;
      private string[] BC000S33_A198ProfesionalesDireccion ;
      private string[] BC000S33_A267ProfesionalesVerDatPerSol ;
      private string[] BC000S33_A436ProfesionalesPerAltShop ;
      private bool[] BC000S33_n436ProfesionalesPerAltShop ;
      private short[] BC000S33_A196ProfesionalesAutoEnumerar ;
      private short[] BC000S33_A197ProfesionalesAutoEnuZona ;
      private string[] BC000S33_A677ProfesionalesExperiencia ;
      private bool[] BC000S33_n677ProfesionalesExperiencia ;
      private DateTime[] BC000S33_A678ProfesionalesAceptoTerminos ;
      private bool[] BC000S33_n678ProfesionalesAceptoTerminos ;
      private DateTime[] BC000S33_A679ProfesionalesDeclaroDatosV ;
      private bool[] BC000S33_n679ProfesionalesDeclaroDatosV ;
      private string[] BC000S33_A680ProfesionalesCuentaBancaria ;
      private bool[] BC000S33_n680ProfesionalesCuentaBancaria ;
      private decimal[] BC000S33_A800ProfesionalesCapacidadProducti ;
      private string[] BC000S33_A674BancoNombre ;
      private short[] BC000S33_A617ProfesionalesLimitOSF ;
      private bool[] BC000S33_n617ProfesionalesLimitOSF ;
      private long[] BC000S33_A268ProfesionalesFeedBackCant ;
      private decimal[] BC000S33_A269ProfesionalesFeedBackProm ;
      private string[] BC000S33_A107EstadosTipo ;
      private int[] BC000S33_A108EstadosGenericosId ;
      private long[] BC000S33_A673BancoId ;
      private bool[] BC000S33_n673BancoId ;
      private string[] BC000S33_A169ProfesionalesPhoto ;
      private string[] BC000S13_A221EstadosProfRubNomb ;
      private string[] BC000S12_A122RubrosNombre ;
      private string[] BC000S12_A40001RubrosImagen_GXI ;
      private string[] BC000S12_A123RubrosEstado ;
      private bool[] BC000S12_n123RubrosEstado ;
      private string[] BC000S12_A168RubrosImagen ;
      private string[] BC000S34_A120ProfesionalesId ;
      private string[] BC000S34_A122RubrosNombre ;
      private string[] BC000S34_A40001RubrosImagen_GXI ;
      private string[] BC000S34_A123RubrosEstado ;
      private bool[] BC000S34_n123RubrosEstado ;
      private string[] BC000S34_A221EstadosProfRubNomb ;
      private short[] BC000S34_A121RubrosId ;
      private string[] BC000S34_A124EstadosProfRubTipo ;
      private int[] BC000S34_A125EstadosProfRubId ;
      private string[] BC000S34_A168RubrosImagen ;
      private string[] BC000S35_A120ProfesionalesId ;
      private short[] BC000S35_A121RubrosId ;
      private string[] BC000S11_A120ProfesionalesId ;
      private short[] BC000S11_A121RubrosId ;
      private string[] BC000S11_A124EstadosProfRubTipo ;
      private int[] BC000S11_A125EstadosProfRubId ;
      private string[] BC000S10_A120ProfesionalesId ;
      private short[] BC000S10_A121RubrosId ;
      private string[] BC000S10_A124EstadosProfRubTipo ;
      private int[] BC000S10_A125EstadosProfRubId ;
      private string[] BC000S39_A122RubrosNombre ;
      private string[] BC000S39_A40001RubrosImagen_GXI ;
      private string[] BC000S39_A123RubrosEstado ;
      private bool[] BC000S39_n123RubrosEstado ;
      private string[] BC000S39_A168RubrosImagen ;
      private string[] BC000S40_A221EstadosProfRubNomb ;
      private string[] BC000S41_A120ProfesionalesId ;
      private string[] BC000S41_A122RubrosNombre ;
      private string[] BC000S41_A40001RubrosImagen_GXI ;
      private string[] BC000S41_A123RubrosEstado ;
      private bool[] BC000S41_n123RubrosEstado ;
      private string[] BC000S41_A221EstadosProfRubNomb ;
      private short[] BC000S41_A121RubrosId ;
      private string[] BC000S41_A124EstadosProfRubTipo ;
      private int[] BC000S41_A125EstadosProfRubId ;
      private string[] BC000S41_A168RubrosImagen ;
      private string[] BC000S42_A120ProfesionalesId ;
      private short[] BC000S42_A126ProfesionalesZonasCorrelativo ;
      private string[] BC000S42_A113DepartamentoDepartamento ;
      private long[] BC000S42_A112DepartamentoId ;
      private long[] BC000S42_A114DepartamentoMunicipioId ;
      private long[] BC000S42_A110ZonasID ;
      private bool[] BC000S42_n110ZonasID ;
      private string[] BC000S42_A116PaisID ;
      private string[] BC000S7_A113DepartamentoDepartamento ;
      private string[] BC000S7_A116PaisID ;
      private long[] BC000S8_A112DepartamentoId ;
      private long[] BC000S9_A110ZonasID ;
      private bool[] BC000S9_n110ZonasID ;
      private string[] BC000S43_A120ProfesionalesId ;
      private short[] BC000S43_A126ProfesionalesZonasCorrelativo ;
      private string[] BC000S6_A120ProfesionalesId ;
      private short[] BC000S6_A126ProfesionalesZonasCorrelativo ;
      private long[] BC000S6_A112DepartamentoId ;
      private long[] BC000S6_A114DepartamentoMunicipioId ;
      private long[] BC000S6_A110ZonasID ;
      private bool[] BC000S6_n110ZonasID ;
      private string[] BC000S5_A120ProfesionalesId ;
      private short[] BC000S5_A126ProfesionalesZonasCorrelativo ;
      private long[] BC000S5_A112DepartamentoId ;
      private long[] BC000S5_A114DepartamentoMunicipioId ;
      private long[] BC000S5_A110ZonasID ;
      private bool[] BC000S5_n110ZonasID ;
      private string[] BC000S47_A113DepartamentoDepartamento ;
      private string[] BC000S47_A116PaisID ;
      private string[] BC000S48_A120ProfesionalesId ;
      private short[] BC000S48_A126ProfesionalesZonasCorrelativo ;
      private string[] BC000S48_A113DepartamentoDepartamento ;
      private long[] BC000S48_A112DepartamentoId ;
      private long[] BC000S48_A114DepartamentoMunicipioId ;
      private long[] BC000S48_A110ZonasID ;
      private bool[] BC000S48_n110ZonasID ;
      private string[] BC000S48_A116PaisID ;
      private string[] BC000S49_A120ProfesionalesId ;
      private string[] BC000S49_A994ProfesionalServicioNombre ;
      private string[] BC000S49_A995EstadoServProf ;
      private bool[] BC000S49_n995EstadoServProf ;
      private long[] BC000S49_A993ProfesionalServicioId ;
      private string[] BC000S4_A994ProfesionalServicioNombre ;
      private string[] BC000S50_A120ProfesionalesId ;
      private long[] BC000S50_A993ProfesionalServicioId ;
      private string[] BC000S3_A120ProfesionalesId ;
      private string[] BC000S3_A995EstadoServProf ;
      private bool[] BC000S3_n995EstadoServProf ;
      private long[] BC000S3_A993ProfesionalServicioId ;
      private string[] BC000S2_A120ProfesionalesId ;
      private string[] BC000S2_A995EstadoServProf ;
      private bool[] BC000S2_n995EstadoServProf ;
      private long[] BC000S2_A993ProfesionalServicioId ;
      private string[] BC000S54_A994ProfesionalServicioNombre ;
      private string[] BC000S55_A120ProfesionalesId ;
      private string[] BC000S55_A994ProfesionalServicioNombre ;
      private string[] BC000S55_A995EstadoServProf ;
      private bool[] BC000S55_n995EstadoServProf ;
      private long[] BC000S55_A993ProfesionalServicioId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class profesionales_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class profesionales_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new UpdateCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new UpdateCursor(def[34])
       ,new UpdateCursor(def[35])
       ,new UpdateCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new UpdateCursor(def[42])
       ,new UpdateCursor(def[43])
       ,new UpdateCursor(def[44])
       ,new ForEachCursor(def[45])
       ,new ForEachCursor(def[46])
       ,new ForEachCursor(def[47])
       ,new ForEachCursor(def[48])
       ,new UpdateCursor(def[49])
       ,new UpdateCursor(def[50])
       ,new UpdateCursor(def[51])
       ,new ForEachCursor(def[52])
       ,new ForEachCursor(def[53])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000S2;
        prmBC000S2 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmBC000S3;
        prmBC000S3 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmBC000S4;
        prmBC000S4 = new Object[] {
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmBC000S5;
        prmBC000S5 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmBC000S6;
        prmBC000S6 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmBC000S7;
        prmBC000S7 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmBC000S8;
        prmBC000S8 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmBC000S9;
        prmBC000S9 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmBC000S10;
        prmBC000S10 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000S11;
        prmBC000S11 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000S12;
        prmBC000S12 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000S13;
        prmBC000S13 = new Object[] {
        new ParDef("@EstadosProfRubTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosProfRubId",GXType.Int32,5,0)
        };
        Object[] prmBC000S14;
        prmBC000S14 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S15;
        prmBC000S15 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S16;
        prmBC000S16 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmBC000S17;
        prmBC000S17 = new Object[] {
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000S18;
        prmBC000S18 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S19;
        prmBC000S19 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S20;
        prmBC000S20 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@ProfesionalesFechaActualizado",GXType.DateTime,8,5) ,
        new ParDef("@ProfesionalesFechaNacimiento",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@ProfesionalesRUT",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProfesionalesTipoEmpresa",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ProfesionalesEsRUT",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ProfesionalesPrimerNombre",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesSegundoNombre",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesApellidoPrimero",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesApellidoSegundo",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesPhoto",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ProfesionalesPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=11, Tbl="Profesionales", Fld="ProfesionalesPhoto"} ,
        new ParDef("@ProfesionalesTelefono",GXType.NChar,20,0) ,
        new ParDef("@ProfesionalesEmail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@ProfesionalesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@ProfesionalesVerDatPerSol",GXType.NChar,1,0) ,
        new ParDef("@ProfesionalesPerAltShop",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@ProfesionalesAutoEnumerar",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesAutoEnuZona",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesExperiencia",GXType.NVarChar,1024,0){Nullable=true} ,
        new ParDef("@ProfesionalesAceptoTerminos",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProfesionalesDeclaroDatosV",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProfesionalesCuentaBancaria",GXType.NChar,50,0){Nullable=true} ,
        new ParDef("@ProfesionalesCapacidadProducti",GXType.Decimal,10,2) ,
        new ParDef("@ProfesionalesLimitOSF",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesFeedBackProm",GXType.Decimal,18,2) ,
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0) ,
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000S21;
        prmBC000S21 = new Object[] {
        new ParDef("@ProfesionalesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@ProfesionalesFechaActualizado",GXType.DateTime,8,5) ,
        new ParDef("@ProfesionalesFechaNacimiento",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@ProfesionalesRUT",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProfesionalesTipoEmpresa",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ProfesionalesEsRUT",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ProfesionalesPrimerNombre",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesSegundoNombre",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesApellidoPrimero",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesApellidoSegundo",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesTelefono",GXType.NChar,20,0) ,
        new ParDef("@ProfesionalesEmail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@ProfesionalesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@ProfesionalesVerDatPerSol",GXType.NChar,1,0) ,
        new ParDef("@ProfesionalesPerAltShop",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@ProfesionalesAutoEnumerar",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesAutoEnuZona",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesExperiencia",GXType.NVarChar,1024,0){Nullable=true} ,
        new ParDef("@ProfesionalesAceptoTerminos",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProfesionalesDeclaroDatosV",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProfesionalesCuentaBancaria",GXType.NChar,50,0){Nullable=true} ,
        new ParDef("@ProfesionalesCapacidadProducti",GXType.Decimal,10,2) ,
        new ParDef("@ProfesionalesLimitOSF",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesFeedBackProm",GXType.Decimal,18,2) ,
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0) ,
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S22;
        prmBC000S22 = new Object[] {
        new ParDef("@ProfesionalesPhoto",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ProfesionalesPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Profesionales", Fld="ProfesionalesPhoto"} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S23;
        prmBC000S23 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S24;
        prmBC000S24 = new Object[] {
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000S25;
        prmBC000S25 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S26;
        prmBC000S26 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S27;
        prmBC000S27 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S28;
        prmBC000S28 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S29;
        prmBC000S29 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S30;
        prmBC000S30 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S31;
        prmBC000S31 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S32;
        prmBC000S32 = new Object[] {
        new ParDef("@ProfesionalesAutoEnuZona",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S33;
        prmBC000S33 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S34;
        prmBC000S34 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000S35;
        prmBC000S35 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000S36;
        prmBC000S36 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@EstadosProfRubTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosProfRubId",GXType.Int32,5,0)
        };
        Object[] prmBC000S37;
        prmBC000S37 = new Object[] {
        new ParDef("@EstadosProfRubTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosProfRubId",GXType.Int32,5,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000S38;
        prmBC000S38 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000S39;
        prmBC000S39 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000S40;
        prmBC000S40 = new Object[] {
        new ParDef("@EstadosProfRubTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosProfRubId",GXType.Int32,5,0)
        };
        Object[] prmBC000S41;
        prmBC000S41 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S42;
        prmBC000S42 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmBC000S43;
        prmBC000S43 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmBC000S44;
        prmBC000S44 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0) ,
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000S45;
        prmBC000S45 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0) ,
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmBC000S46;
        prmBC000S46 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmBC000S47;
        prmBC000S47 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmBC000S48;
        prmBC000S48 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC000S49;
        prmBC000S49 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmBC000S50;
        prmBC000S50 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmBC000S51;
        prmBC000S51 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@EstadoServProf",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmBC000S52;
        prmBC000S52 = new Object[] {
        new ParDef("@EstadoServProf",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmBC000S53;
        prmBC000S53 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmBC000S54;
        prmBC000S54 = new Object[] {
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmBC000S55;
        prmBC000S55 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000S2", "SELECT [ProfesionalesId], [EstadoServProf], [ProfesionalServicioId] AS ProfesionalServicioId FROM [ProfesionalesServicios] WITH (UPDLOCK) WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalServicioId] = @ProfesionalServicioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S3", "SELECT [ProfesionalesId], [EstadoServProf], [ProfesionalServicioId] AS ProfesionalServicioId FROM [ProfesionalesServicios] WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalServicioId] = @ProfesionalServicioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S4", "SELECT [ServiciosNombre] AS ProfesionalServicioNombre FROM [Servicios] WHERE [ServiciosId] = @ProfesionalServicioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S5", "SELECT [ProfesionalesId], [ProfesionalesZonasCorrelativo], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID] FROM [ProfesionalesZonas] WITH (UPDLOCK) WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S6", "SELECT [ProfesionalesId], [ProfesionalesZonasCorrelativo], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID] FROM [ProfesionalesZonas] WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S7", "SELECT [DepartamentoDepartamento], [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S8", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S9", "SELECT [ZonasID] FROM [Zonas] WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S10", "SELECT [ProfesionalesId], [RubrosId], [EstadosProfRubTipo] AS EstadosProfRubTipo, [EstadosProfRubId] AS EstadosProfRubId FROM [ProfesionalesRubros] WITH (UPDLOCK) WHERE [ProfesionalesId] = @ProfesionalesId AND [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S11", "SELECT [ProfesionalesId], [RubrosId], [EstadosProfRubTipo] AS EstadosProfRubTipo, [EstadosProfRubId] AS EstadosProfRubId FROM [ProfesionalesRubros] WHERE [ProfesionalesId] = @ProfesionalesId AND [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S12", "SELECT [RubrosNombre], [RubrosImagen_GXI], [RubrosEstado], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S13", "SELECT [EstadosGenericosNombre] AS EstadosProfRubNomb FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosProfRubTipo AND [EstadosGenericosId] = @EstadosProfRubId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S14", "SELECT [ProfesionalesId], [ProfesionalesFechaAlta], [ProfesionalesFechaActualizado], [ProfesionalesFechaNacimiento], [ProfesionalesRUT], [ProfesionalesTipoEmpresa], [ProfesionalesEsRUT], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesPhoto_GXI], [ProfesionalesTelefono], [ProfesionalesEmail], [ProfesionalesDireccion], [ProfesionalesVerDatPerSol], [ProfesionalesPerAltShop], [ProfesionalesAutoEnumerar], [ProfesionalesAutoEnuZona], [ProfesionalesExperiencia], [ProfesionalesAceptoTerminos], [ProfesionalesDeclaroDatosV], [ProfesionalesCuentaBancaria], [ProfesionalesCapacidadProducti], [ProfesionalesLimitOSF], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm], [EstadosTipo], [EstadosGenericosId], [BancoId], [ProfesionalesPhoto] FROM [Profesionales] WITH (UPDLOCK) WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S15", "SELECT [ProfesionalesId], [ProfesionalesFechaAlta], [ProfesionalesFechaActualizado], [ProfesionalesFechaNacimiento], [ProfesionalesRUT], [ProfesionalesTipoEmpresa], [ProfesionalesEsRUT], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesPhoto_GXI], [ProfesionalesTelefono], [ProfesionalesEmail], [ProfesionalesDireccion], [ProfesionalesVerDatPerSol], [ProfesionalesPerAltShop], [ProfesionalesAutoEnumerar], [ProfesionalesAutoEnuZona], [ProfesionalesExperiencia], [ProfesionalesAceptoTerminos], [ProfesionalesDeclaroDatosV], [ProfesionalesCuentaBancaria], [ProfesionalesCapacidadProducti], [ProfesionalesLimitOSF], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm], [EstadosTipo], [EstadosGenericosId], [BancoId], [ProfesionalesPhoto] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S16", "SELECT [EstadosTipo] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S17", "SELECT [BancoNombre] FROM [Banco] WHERE [BancoId] = @BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S18", "SELECT TM1.[ProfesionalesId], TM1.[ProfesionalesFechaAlta], TM1.[ProfesionalesFechaActualizado], TM1.[ProfesionalesFechaNacimiento], TM1.[ProfesionalesRUT], TM1.[ProfesionalesTipoEmpresa], TM1.[ProfesionalesEsRUT], TM1.[ProfesionalesPrimerNombre], TM1.[ProfesionalesSegundoNombre], TM1.[ProfesionalesApellidoPrimero], TM1.[ProfesionalesApellidoSegundo], TM1.[ProfesionalesPhoto_GXI], TM1.[ProfesionalesTelefono], TM1.[ProfesionalesEmail], TM1.[ProfesionalesDireccion], TM1.[ProfesionalesVerDatPerSol], TM1.[ProfesionalesPerAltShop], TM1.[ProfesionalesAutoEnumerar], TM1.[ProfesionalesAutoEnuZona], TM1.[ProfesionalesExperiencia], TM1.[ProfesionalesAceptoTerminos], TM1.[ProfesionalesDeclaroDatosV], TM1.[ProfesionalesCuentaBancaria], TM1.[ProfesionalesCapacidadProducti], T2.[BancoNombre], TM1.[ProfesionalesLimitOSF], TM1.[ProfesionalesFeedBackCant], TM1.[ProfesionalesFeedBackProm], TM1.[EstadosTipo], TM1.[EstadosGenericosId], TM1.[BancoId], TM1.[ProfesionalesPhoto] FROM ([Profesionales] TM1 LEFT JOIN [Banco] T2 ON T2.[BancoId] = TM1.[BancoId]) WHERE TM1.[ProfesionalesId] = @ProfesionalesId ORDER BY TM1.[ProfesionalesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S18,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S19", "SELECT [ProfesionalesId] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S20", "INSERT INTO [Profesionales]([ProfesionalesId], [ProfesionalesFechaAlta], [ProfesionalesFechaActualizado], [ProfesionalesFechaNacimiento], [ProfesionalesRUT], [ProfesionalesTipoEmpresa], [ProfesionalesEsRUT], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesPhoto], [ProfesionalesPhoto_GXI], [ProfesionalesTelefono], [ProfesionalesEmail], [ProfesionalesDireccion], [ProfesionalesVerDatPerSol], [ProfesionalesPerAltShop], [ProfesionalesAutoEnumerar], [ProfesionalesAutoEnuZona], [ProfesionalesExperiencia], [ProfesionalesAceptoTerminos], [ProfesionalesDeclaroDatosV], [ProfesionalesCuentaBancaria], [ProfesionalesCapacidadProducti], [ProfesionalesLimitOSF], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm], [EstadosTipo], [EstadosGenericosId], [BancoId]) VALUES(@ProfesionalesId, @ProfesionalesFechaAlta, @ProfesionalesFechaActualizado, @ProfesionalesFechaNacimiento, @ProfesionalesRUT, @ProfesionalesTipoEmpresa, @ProfesionalesEsRUT, @ProfesionalesPrimerNombre, @ProfesionalesSegundoNombre, @ProfesionalesApellidoPrimero, @ProfesionalesApellidoSegundo, @ProfesionalesPhoto, @ProfesionalesPhoto_GXI, @ProfesionalesTelefono, @ProfesionalesEmail, @ProfesionalesDireccion, @ProfesionalesVerDatPerSol, @ProfesionalesPerAltShop, @ProfesionalesAutoEnumerar, @ProfesionalesAutoEnuZona, @ProfesionalesExperiencia, @ProfesionalesAceptoTerminos, @ProfesionalesDeclaroDatosV, @ProfesionalesCuentaBancaria, @ProfesionalesCapacidadProducti, @ProfesionalesLimitOSF, @ProfesionalesFeedBackCant, @ProfesionalesFeedBackProm, @EstadosTipo, @EstadosGenericosId, @BancoId)", GxErrorMask.GX_NOMASK,prmBC000S20)
           ,new CursorDef("BC000S21", "UPDATE [Profesionales] SET [ProfesionalesFechaAlta]=@ProfesionalesFechaAlta, [ProfesionalesFechaActualizado]=@ProfesionalesFechaActualizado, [ProfesionalesFechaNacimiento]=@ProfesionalesFechaNacimiento, [ProfesionalesRUT]=@ProfesionalesRUT, [ProfesionalesTipoEmpresa]=@ProfesionalesTipoEmpresa, [ProfesionalesEsRUT]=@ProfesionalesEsRUT, [ProfesionalesPrimerNombre]=@ProfesionalesPrimerNombre, [ProfesionalesSegundoNombre]=@ProfesionalesSegundoNombre, [ProfesionalesApellidoPrimero]=@ProfesionalesApellidoPrimero, [ProfesionalesApellidoSegundo]=@ProfesionalesApellidoSegundo, [ProfesionalesTelefono]=@ProfesionalesTelefono, [ProfesionalesEmail]=@ProfesionalesEmail, [ProfesionalesDireccion]=@ProfesionalesDireccion, [ProfesionalesVerDatPerSol]=@ProfesionalesVerDatPerSol, [ProfesionalesPerAltShop]=@ProfesionalesPerAltShop, [ProfesionalesAutoEnumerar]=@ProfesionalesAutoEnumerar, [ProfesionalesAutoEnuZona]=@ProfesionalesAutoEnuZona, [ProfesionalesExperiencia]=@ProfesionalesExperiencia, [ProfesionalesAceptoTerminos]=@ProfesionalesAceptoTerminos, [ProfesionalesDeclaroDatosV]=@ProfesionalesDeclaroDatosV, [ProfesionalesCuentaBancaria]=@ProfesionalesCuentaBancaria, [ProfesionalesCapacidadProducti]=@ProfesionalesCapacidadProducti, [ProfesionalesLimitOSF]=@ProfesionalesLimitOSF, [ProfesionalesFeedBackCant]=@ProfesionalesFeedBackCant, [ProfesionalesFeedBackProm]=@ProfesionalesFeedBackProm, [EstadosTipo]=@EstadosTipo, [EstadosGenericosId]=@EstadosGenericosId, [BancoId]=@BancoId  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmBC000S21)
           ,new CursorDef("BC000S22", "UPDATE [Profesionales] SET [ProfesionalesPhoto]=@ProfesionalesPhoto, [ProfesionalesPhoto_GXI]=@ProfesionalesPhoto_GXI  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmBC000S22)
           ,new CursorDef("BC000S23", "DELETE FROM [Profesionales]  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmBC000S23)
           ,new CursorDef("BC000S24", "SELECT [BancoNombre] FROM [Banco] WHERE [BancoId] = @BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S25", "SELECT TOP 1 [CentroCostosId], [CentroCostosDetallesId] FROM [CentroCostosDetalles] WHERE [CCDetallesProfId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000S26", "SELECT TOP 1 [ProfesionalesRestriccionId] FROM [ProfesionalesRestriccion] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000S27", "SELECT TOP 1 [ProfComisionesID] FROM [ProfComisiones] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000S28", "SELECT TOP 1 [SolicitudesID], [RelacionesId] FROM [Relaciones] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000S29", "SELECT TOP 1 [PostulacionesId], [ProfesionalesId] FROM [PostulacionesProfesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000S30", "SELECT TOP 1 [Listaid], [ProveedorID], [ProfesionalesId] FROM [ListaAgrupacion] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000S31", "SELECT TOP 1 [ComisionesID], [ProfesionalesId] FROM [ComisionesProfesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S31,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000S32", "UPDATE [Profesionales] SET [ProfesionalesAutoEnuZona]=@ProfesionalesAutoEnuZona  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmBC000S32)
           ,new CursorDef("BC000S33", "SELECT TM1.[ProfesionalesId], TM1.[ProfesionalesFechaAlta], TM1.[ProfesionalesFechaActualizado], TM1.[ProfesionalesFechaNacimiento], TM1.[ProfesionalesRUT], TM1.[ProfesionalesTipoEmpresa], TM1.[ProfesionalesEsRUT], TM1.[ProfesionalesPrimerNombre], TM1.[ProfesionalesSegundoNombre], TM1.[ProfesionalesApellidoPrimero], TM1.[ProfesionalesApellidoSegundo], TM1.[ProfesionalesPhoto_GXI], TM1.[ProfesionalesTelefono], TM1.[ProfesionalesEmail], TM1.[ProfesionalesDireccion], TM1.[ProfesionalesVerDatPerSol], TM1.[ProfesionalesPerAltShop], TM1.[ProfesionalesAutoEnumerar], TM1.[ProfesionalesAutoEnuZona], TM1.[ProfesionalesExperiencia], TM1.[ProfesionalesAceptoTerminos], TM1.[ProfesionalesDeclaroDatosV], TM1.[ProfesionalesCuentaBancaria], TM1.[ProfesionalesCapacidadProducti], T2.[BancoNombre], TM1.[ProfesionalesLimitOSF], TM1.[ProfesionalesFeedBackCant], TM1.[ProfesionalesFeedBackProm], TM1.[EstadosTipo], TM1.[EstadosGenericosId], TM1.[BancoId], TM1.[ProfesionalesPhoto] FROM ([Profesionales] TM1 LEFT JOIN [Banco] T2 ON T2.[BancoId] = TM1.[BancoId]) WHERE TM1.[ProfesionalesId] = @ProfesionalesId ORDER BY TM1.[ProfesionalesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S33,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S34", "SELECT T1.[ProfesionalesId], T2.[RubrosNombre], T2.[RubrosImagen_GXI], T2.[RubrosEstado], T3.[EstadosGenericosNombre] AS EstadosProfRubNomb, T1.[RubrosId], T1.[EstadosProfRubTipo] AS EstadosProfRubTipo, T1.[EstadosProfRubId] AS EstadosProfRubId, T2.[RubrosImagen] FROM (([ProfesionalesRubros] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T1.[EstadosProfRubTipo] AND T3.[EstadosGenericosId] = T1.[EstadosProfRubId]) WHERE T1.[ProfesionalesId] = @ProfesionalesId and T1.[RubrosId] = @RubrosId ORDER BY T1.[ProfesionalesId], T1.[RubrosId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S34,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S35", "SELECT [ProfesionalesId], [RubrosId] FROM [ProfesionalesRubros] WHERE [ProfesionalesId] = @ProfesionalesId AND [RubrosId] = @RubrosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S35,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S36", "INSERT INTO [ProfesionalesRubros]([ProfesionalesId], [RubrosId], [EstadosProfRubTipo], [EstadosProfRubId]) VALUES(@ProfesionalesId, @RubrosId, @EstadosProfRubTipo, @EstadosProfRubId)", GxErrorMask.GX_NOMASK,prmBC000S36)
           ,new CursorDef("BC000S37", "UPDATE [ProfesionalesRubros] SET [EstadosProfRubTipo]=@EstadosProfRubTipo, [EstadosProfRubId]=@EstadosProfRubId  WHERE [ProfesionalesId] = @ProfesionalesId AND [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmBC000S37)
           ,new CursorDef("BC000S38", "DELETE FROM [ProfesionalesRubros]  WHERE [ProfesionalesId] = @ProfesionalesId AND [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmBC000S38)
           ,new CursorDef("BC000S39", "SELECT [RubrosNombre], [RubrosImagen_GXI], [RubrosEstado], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S39,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S40", "SELECT [EstadosGenericosNombre] AS EstadosProfRubNomb FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosProfRubTipo AND [EstadosGenericosId] = @EstadosProfRubId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S40,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S41", "SELECT T1.[ProfesionalesId], T2.[RubrosNombre], T2.[RubrosImagen_GXI], T2.[RubrosEstado], T3.[EstadosGenericosNombre] AS EstadosProfRubNomb, T1.[RubrosId], T1.[EstadosProfRubTipo] AS EstadosProfRubTipo, T1.[EstadosProfRubId] AS EstadosProfRubId, T2.[RubrosImagen] FROM (([ProfesionalesRubros] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T1.[EstadosProfRubTipo] AND T3.[EstadosGenericosId] = T1.[EstadosProfRubId]) WHERE T1.[ProfesionalesId] = @ProfesionalesId ORDER BY T1.[ProfesionalesId], T1.[RubrosId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S41,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S42", "SELECT T1.[ProfesionalesId], T1.[ProfesionalesZonasCorrelativo], T2.[DepartamentoDepartamento], T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T1.[ZonasID], T2.[PaisID] FROM ([ProfesionalesZonas] T1 INNER JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) WHERE T1.[ProfesionalesId] = @ProfesionalesId and T1.[ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo ORDER BY T1.[ProfesionalesId], T1.[ProfesionalesZonasCorrelativo]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S42,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S43", "SELECT [ProfesionalesId], [ProfesionalesZonasCorrelativo] FROM [ProfesionalesZonas] WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S43,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S44", "INSERT INTO [ProfesionalesZonas]([ProfesionalesId], [ProfesionalesZonasCorrelativo], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID]) VALUES(@ProfesionalesId, @ProfesionalesZonasCorrelativo, @DepartamentoId, @DepartamentoMunicipioId, @ZonasID)", GxErrorMask.GX_NOMASK,prmBC000S44)
           ,new CursorDef("BC000S45", "UPDATE [ProfesionalesZonas] SET [DepartamentoId]=@DepartamentoId, [DepartamentoMunicipioId]=@DepartamentoMunicipioId, [ZonasID]=@ZonasID  WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo", GxErrorMask.GX_NOMASK,prmBC000S45)
           ,new CursorDef("BC000S46", "DELETE FROM [ProfesionalesZonas]  WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo", GxErrorMask.GX_NOMASK,prmBC000S46)
           ,new CursorDef("BC000S47", "SELECT [DepartamentoDepartamento], [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S47,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S48", "SELECT T1.[ProfesionalesId], T1.[ProfesionalesZonasCorrelativo], T2.[DepartamentoDepartamento], T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T1.[ZonasID], T2.[PaisID] FROM ([ProfesionalesZonas] T1 INNER JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) WHERE T1.[ProfesionalesId] = @ProfesionalesId ORDER BY T1.[ProfesionalesId], T1.[ProfesionalesZonasCorrelativo]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S48,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S49", "SELECT T1.[ProfesionalesId], T2.[ServiciosNombre] AS ProfesionalServicioNombre, T1.[EstadoServProf], T1.[ProfesionalServicioId] AS ProfesionalServicioId FROM ([ProfesionalesServicios] T1 INNER JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ProfesionalServicioId]) WHERE T1.[ProfesionalesId] = @ProfesionalesId and T1.[ProfesionalServicioId] = @ProfesionalServicioId ORDER BY T1.[ProfesionalesId], T1.[ProfesionalServicioId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S49,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S50", "SELECT [ProfesionalesId], [ProfesionalServicioId] AS ProfesionalServicioId FROM [ProfesionalesServicios] WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalServicioId] = @ProfesionalServicioId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S50,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S51", "INSERT INTO [ProfesionalesServicios]([ProfesionalesId], [EstadoServProf], [ProfesionalServicioId]) VALUES(@ProfesionalesId, @EstadoServProf, @ProfesionalServicioId)", GxErrorMask.GX_NOMASK,prmBC000S51)
           ,new CursorDef("BC000S52", "UPDATE [ProfesionalesServicios] SET [EstadoServProf]=@EstadoServProf  WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalServicioId] = @ProfesionalServicioId", GxErrorMask.GX_NOMASK,prmBC000S52)
           ,new CursorDef("BC000S53", "DELETE FROM [ProfesionalesServicios]  WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalServicioId] = @ProfesionalServicioId", GxErrorMask.GX_NOMASK,prmBC000S53)
           ,new CursorDef("BC000S54", "SELECT [ServiciosNombre] AS ProfesionalServicioNombre FROM [Servicios] WHERE [ServiciosId] = @ProfesionalServicioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S54,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S55", "SELECT T1.[ProfesionalesId], T2.[ServiciosNombre] AS ProfesionalServicioNombre, T1.[EstadoServProf], T1.[ProfesionalServicioId] AS ProfesionalServicioId FROM ([ProfesionalesServicios] T1 INNER JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ProfesionalServicioId]) WHERE T1.[ProfesionalesId] = @ProfesionalesId ORDER BY T1.[ProfesionalesId], T1.[ProfesionalServicioId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S55,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 2);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((short[]) buf[7])[0] = rslt.getShort(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((bool[]) buf[9])[0] = rslt.getBool(7);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((string[]) buf[11])[0] = rslt.getString(8, 30);
              ((string[]) buf[12])[0] = rslt.getString(9, 30);
              ((string[]) buf[13])[0] = rslt.getString(10, 30);
              ((string[]) buf[14])[0] = rslt.getString(11, 30);
              ((string[]) buf[15])[0] = rslt.getMultimediaUri(12);
              ((string[]) buf[16])[0] = rslt.getString(13, 20);
              ((string[]) buf[17])[0] = rslt.getVarchar(14);
              ((bool[]) buf[18])[0] = rslt.wasNull(14);
              ((string[]) buf[19])[0] = rslt.getVarchar(15);
              ((string[]) buf[20])[0] = rslt.getString(16, 1);
              ((string[]) buf[21])[0] = rslt.getString(17, 1);
              ((bool[]) buf[22])[0] = rslt.wasNull(17);
              ((short[]) buf[23])[0] = rslt.getShort(18);
              ((short[]) buf[24])[0] = rslt.getShort(19);
              ((string[]) buf[25])[0] = rslt.getVarchar(20);
              ((bool[]) buf[26])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(21);
              ((bool[]) buf[28])[0] = rslt.wasNull(21);
              ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(22);
              ((bool[]) buf[30])[0] = rslt.wasNull(22);
              ((string[]) buf[31])[0] = rslt.getString(23, 50);
              ((bool[]) buf[32])[0] = rslt.wasNull(23);
              ((decimal[]) buf[33])[0] = rslt.getDecimal(24);
              ((short[]) buf[34])[0] = rslt.getShort(25);
              ((bool[]) buf[35])[0] = rslt.wasNull(25);
              ((long[]) buf[36])[0] = rslt.getLong(26);
              ((decimal[]) buf[37])[0] = rslt.getDecimal(27);
              ((string[]) buf[38])[0] = rslt.getString(28, 3);
              ((int[]) buf[39])[0] = rslt.getInt(29);
              ((long[]) buf[40])[0] = rslt.getLong(30);
              ((bool[]) buf[41])[0] = rslt.wasNull(30);
              ((string[]) buf[42])[0] = rslt.getMultimediaFile(31, rslt.getVarchar(12));
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((short[]) buf[7])[0] = rslt.getShort(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((bool[]) buf[9])[0] = rslt.getBool(7);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((string[]) buf[11])[0] = rslt.getString(8, 30);
              ((string[]) buf[12])[0] = rslt.getString(9, 30);
              ((string[]) buf[13])[0] = rslt.getString(10, 30);
              ((string[]) buf[14])[0] = rslt.getString(11, 30);
              ((string[]) buf[15])[0] = rslt.getMultimediaUri(12);
              ((string[]) buf[16])[0] = rslt.getString(13, 20);
              ((string[]) buf[17])[0] = rslt.getVarchar(14);
              ((bool[]) buf[18])[0] = rslt.wasNull(14);
              ((string[]) buf[19])[0] = rslt.getVarchar(15);
              ((string[]) buf[20])[0] = rslt.getString(16, 1);
              ((string[]) buf[21])[0] = rslt.getString(17, 1);
              ((bool[]) buf[22])[0] = rslt.wasNull(17);
              ((short[]) buf[23])[0] = rslt.getShort(18);
              ((short[]) buf[24])[0] = rslt.getShort(19);
              ((string[]) buf[25])[0] = rslt.getVarchar(20);
              ((bool[]) buf[26])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(21);
              ((bool[]) buf[28])[0] = rslt.wasNull(21);
              ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(22);
              ((bool[]) buf[30])[0] = rslt.wasNull(22);
              ((string[]) buf[31])[0] = rslt.getString(23, 50);
              ((bool[]) buf[32])[0] = rslt.wasNull(23);
              ((decimal[]) buf[33])[0] = rslt.getDecimal(24);
              ((short[]) buf[34])[0] = rslt.getShort(25);
              ((bool[]) buf[35])[0] = rslt.wasNull(25);
              ((long[]) buf[36])[0] = rslt.getLong(26);
              ((decimal[]) buf[37])[0] = rslt.getDecimal(27);
              ((string[]) buf[38])[0] = rslt.getString(28, 3);
              ((int[]) buf[39])[0] = rslt.getInt(29);
              ((long[]) buf[40])[0] = rslt.getLong(30);
              ((bool[]) buf[41])[0] = rslt.wasNull(30);
              ((string[]) buf[42])[0] = rslt.getMultimediaFile(31, rslt.getVarchar(12));
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((short[]) buf[7])[0] = rslt.getShort(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((bool[]) buf[9])[0] = rslt.getBool(7);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((string[]) buf[11])[0] = rslt.getString(8, 30);
              ((string[]) buf[12])[0] = rslt.getString(9, 30);
              ((string[]) buf[13])[0] = rslt.getString(10, 30);
              ((string[]) buf[14])[0] = rslt.getString(11, 30);
              ((string[]) buf[15])[0] = rslt.getMultimediaUri(12);
              ((string[]) buf[16])[0] = rslt.getString(13, 20);
              ((string[]) buf[17])[0] = rslt.getVarchar(14);
              ((bool[]) buf[18])[0] = rslt.wasNull(14);
              ((string[]) buf[19])[0] = rslt.getVarchar(15);
              ((string[]) buf[20])[0] = rslt.getString(16, 1);
              ((string[]) buf[21])[0] = rslt.getString(17, 1);
              ((bool[]) buf[22])[0] = rslt.wasNull(17);
              ((short[]) buf[23])[0] = rslt.getShort(18);
              ((short[]) buf[24])[0] = rslt.getShort(19);
              ((string[]) buf[25])[0] = rslt.getVarchar(20);
              ((bool[]) buf[26])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(21);
              ((bool[]) buf[28])[0] = rslt.wasNull(21);
              ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(22);
              ((bool[]) buf[30])[0] = rslt.wasNull(22);
              ((string[]) buf[31])[0] = rslt.getString(23, 50);
              ((bool[]) buf[32])[0] = rslt.wasNull(23);
              ((decimal[]) buf[33])[0] = rslt.getDecimal(24);
              ((string[]) buf[34])[0] = rslt.getString(25, 80);
              ((short[]) buf[35])[0] = rslt.getShort(26);
              ((bool[]) buf[36])[0] = rslt.wasNull(26);
              ((long[]) buf[37])[0] = rslt.getLong(27);
              ((decimal[]) buf[38])[0] = rslt.getDecimal(28);
              ((string[]) buf[39])[0] = rslt.getString(29, 3);
              ((int[]) buf[40])[0] = rslt.getInt(30);
              ((long[]) buf[41])[0] = rslt.getLong(31);
              ((bool[]) buf[42])[0] = rslt.wasNull(31);
              ((string[]) buf[43])[0] = rslt.getMultimediaFile(32, rslt.getVarchar(12));
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 23 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 26 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 29 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((short[]) buf[7])[0] = rslt.getShort(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((bool[]) buf[9])[0] = rslt.getBool(7);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((string[]) buf[11])[0] = rslt.getString(8, 30);
              ((string[]) buf[12])[0] = rslt.getString(9, 30);
              ((string[]) buf[13])[0] = rslt.getString(10, 30);
              ((string[]) buf[14])[0] = rslt.getString(11, 30);
              ((string[]) buf[15])[0] = rslt.getMultimediaUri(12);
              ((string[]) buf[16])[0] = rslt.getString(13, 20);
              ((string[]) buf[17])[0] = rslt.getVarchar(14);
              ((bool[]) buf[18])[0] = rslt.wasNull(14);
              ((string[]) buf[19])[0] = rslt.getVarchar(15);
              ((string[]) buf[20])[0] = rslt.getString(16, 1);
              ((string[]) buf[21])[0] = rslt.getString(17, 1);
              ((bool[]) buf[22])[0] = rslt.wasNull(17);
              ((short[]) buf[23])[0] = rslt.getShort(18);
              ((short[]) buf[24])[0] = rslt.getShort(19);
              ((string[]) buf[25])[0] = rslt.getVarchar(20);
              ((bool[]) buf[26])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(21);
              ((bool[]) buf[28])[0] = rslt.wasNull(21);
              ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(22);
              ((bool[]) buf[30])[0] = rslt.wasNull(22);
              ((string[]) buf[31])[0] = rslt.getString(23, 50);
              ((bool[]) buf[32])[0] = rslt.wasNull(23);
              ((decimal[]) buf[33])[0] = rslt.getDecimal(24);
              ((string[]) buf[34])[0] = rslt.getString(25, 80);
              ((short[]) buf[35])[0] = rslt.getShort(26);
              ((bool[]) buf[36])[0] = rslt.wasNull(26);
              ((long[]) buf[37])[0] = rslt.getLong(27);
              ((decimal[]) buf[38])[0] = rslt.getDecimal(28);
              ((string[]) buf[39])[0] = rslt.getString(29, 3);
              ((int[]) buf[40])[0] = rslt.getInt(30);
              ((long[]) buf[41])[0] = rslt.getLong(31);
              ((bool[]) buf[42])[0] = rslt.wasNull(31);
              ((string[]) buf[43])[0] = rslt.getMultimediaFile(32, rslt.getVarchar(12));
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 80);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 3);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              ((string[]) buf[9])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(3));
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 37 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
              return;
           case 38 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 39 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 80);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 3);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              ((string[]) buf[9])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(3));
              return;
           case 40 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 2);
              return;
           case 41 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 45 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 2);
              return;
           case 46 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 2);
              return;
           case 47 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              return;
           case 48 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 52 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 53 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              return;
     }
  }

}

}
