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
   public class solicitudes_bc : GXHttpHandler, IGxSilentTrn
   {
      public solicitudes_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public solicitudes_bc( IGxContext context )
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
         ReadRow0O30( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0O30( ) ;
         standaloneModal( ) ;
         AddRow0O30( ) ;
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
            E110O2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z127SolicitudesID = A127SolicitudesID;
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

      protected void CONFIRM_0O0( )
      {
         BeforeValidate0O30( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0O30( ) ;
            }
            else
            {
               CheckExtendedTable0O30( ) ;
               if ( AnyError == 0 )
               {
                  ZM0O30( 64) ;
                  ZM0O30( 65) ;
                  ZM0O30( 66) ;
                  ZM0O30( 67) ;
                  ZM0O30( 68) ;
                  ZM0O30( 69) ;
                  ZM0O30( 70) ;
                  ZM0O30( 71) ;
                  ZM0O30( 72) ;
                  ZM0O30( 73) ;
                  ZM0O30( 74) ;
                  ZM0O30( 75) ;
                  ZM0O30( 76) ;
                  ZM0O30( 77) ;
               }
               CloseExtendedTableCursors0O30( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode30 = Gx_mode;
            CONFIRM_0O31( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_0O144( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode30;
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode30;
         }
      }

      protected void CONFIRM_0O144( )
      {
         s992SolicitudesSerialArchivo = O992SolicitudesSerialArchivo;
         nGXsfl_144_idx = 0;
         while ( nGXsfl_144_idx < bcSolicitudes.gxTpr_Archivo.Count )
         {
            ReadRow0O144( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound144 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_144 != 0 ) )
            {
               GetKey0O144( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound144 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0O144( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0O144( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0O144( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        O992SolicitudesSerialArchivo = A992SolicitudesSerialArchivo;
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
                  if ( RcdFound144 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0O144( ) ;
                        Load0O144( ) ;
                        BeforeValidate0O144( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0O144( ) ;
                           O992SolicitudesSerialArchivo = A992SolicitudesSerialArchivo;
                        }
                     }
                     else
                     {
                        if ( nIsMod_144 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0O144( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0O144( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0O144( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              O992SolicitudesSerialArchivo = A992SolicitudesSerialArchivo;
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
               VarsToRow144( ((SdtSolicitudes_Archivo)bcSolicitudes.gxTpr_Archivo.Item(nGXsfl_144_idx))) ;
            }
         }
         O992SolicitudesSerialArchivo = s992SolicitudesSerialArchivo;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0O31( )
      {
         s211SolicitudServicioPFinal = O211SolicitudServicioPFinal;
         s194SolicitudesAutoEnumerar = O194SolicitudesAutoEnumerar;
         s174SolicitudesTotal = O174SolicitudesTotal;
         s529SolicitudServicioComPro = O529SolicitudServicioComPro;
         sV52OldSolicitudServicioPFinal = OV52OldSolicitudServicioPFinal;
         nGXsfl_31_idx = 0;
         while ( nGXsfl_31_idx < bcSolicitudes.gxTpr_Items.Count )
         {
            ReadRow0O31( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound31 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_31 != 0 ) )
            {
               GetKey0O31( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound31 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0O31( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0O31( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0O31( 79) ;
                           ZM0O31( 80) ;
                           ZM0O31( 81) ;
                           ZM0O31( 82) ;
                        }
                        CloseExtendedTableCursors0O31( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        O211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
                        O194SolicitudesAutoEnumerar = A194SolicitudesAutoEnumerar;
                        O174SolicitudesTotal = A174SolicitudesTotal;
                        O529SolicitudServicioComPro = A529SolicitudServicioComPro;
                        OV52OldSolicitudServicioPFinal = AV52OldSolicitudServicioPFinal;
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
                  if ( RcdFound31 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0O31( ) ;
                        Load0O31( ) ;
                        BeforeValidate0O31( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0O31( ) ;
                           O211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
                           O194SolicitudesAutoEnumerar = A194SolicitudesAutoEnumerar;
                           O174SolicitudesTotal = A174SolicitudesTotal;
                           O529SolicitudServicioComPro = A529SolicitudServicioComPro;
                           OV52OldSolicitudServicioPFinal = AV52OldSolicitudServicioPFinal;
                        }
                     }
                     else
                     {
                        if ( nIsMod_31 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0O31( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0O31( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0O31( 79) ;
                                 ZM0O31( 80) ;
                                 ZM0O31( 81) ;
                                 ZM0O31( 82) ;
                              }
                              CloseExtendedTableCursors0O31( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              O211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
                              O194SolicitudesAutoEnumerar = A194SolicitudesAutoEnumerar;
                              O174SolicitudesTotal = A174SolicitudesTotal;
                              O529SolicitudServicioComPro = A529SolicitudServicioComPro;
                              OV52OldSolicitudServicioPFinal = AV52OldSolicitudServicioPFinal;
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
               VarsToRow31( ((SdtSolicitudes_Items)bcSolicitudes.gxTpr_Items.Item(nGXsfl_31_idx))) ;
            }
         }
         O211SolicitudServicioPFinal = s211SolicitudServicioPFinal;
         O194SolicitudesAutoEnumerar = s194SolicitudesAutoEnumerar;
         O174SolicitudesTotal = s174SolicitudesTotal;
         O529SolicitudServicioComPro = s529SolicitudServicioComPro;
         OV52OldSolicitudServicioPFinal = sV52OldSolicitudServicioPFinal;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120O2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_int1 = AV11RubrosId;
         new orubrodefault(context ).execute( out  GXt_int1) ;
         AV11RubrosId = GXt_int1;
         AV12SolicitudServicioComProv = 0;
         AV56SolicitudServicioComProvP = 0;
         AV57OldSolicitudServicioComProvP = 0;
         AV58OldSolicitudServicioComProv = 0;
         AV58OldSolicitudServicioComProv = 0;
         AV60SolicitudServicioComALM = 0;
         AV59OldSolicitudServicioComALMP = 0;
         AV61SolicitudServicioComALMP = 0;
         AV62OldSolicitudServicioComALM = 0;
         AV64BtnRecalcular = false;
         AV66ReloadComProvP = false;
         AV71oldProveedorID = 0;
         AV85PrecioFinal = 0;
         AV86FreezarPrecio = false;
         GXt_decimal2 = AV77SolicitudesCostoXZComAlmP;
         new ocomisionglobal(context ).execute( out  GXt_decimal2) ;
         AV77SolicitudesCostoXZComAlmP = GXt_decimal2;
         GXt_date3 = AV79FechaCierreSolicitud;
         new obtenercierres(context ).execute(  context.GetMessage( "FechaCierreSolicitud", ""), out  GXt_date3) ;
         AV79FechaCierreSolicitud = GXt_date3;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV14WWPContext) ;
         AV15IsAuthorized = true;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean4 = AV15IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudes_Insert", out  GXt_boolean4) ;
            AV15IsAuthorized = GXt_boolean4;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean4 = AV15IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudes_Update", out  GXt_boolean4) ;
            AV15IsAuthorized = GXt_boolean4;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean4 = AV15IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudes_Delete", out  GXt_boolean4) ;
            AV15IsAuthorized = GXt_boolean4;
         }
         if ( ! AV15IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV93Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV17TrnContext.FromXml(AV18WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV17TrnContext.gxTpr_Transactionname, AV93Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV94GXV1 = 1;
            while ( AV94GXV1 <= AV17TrnContext.gxTpr_Attributes.Count )
            {
               AV26TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV17TrnContext.gxTpr_Attributes.Item(AV94GXV1));
               if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "DepartamentoId") == 0 )
               {
                  AV19Insert_DepartamentoId = (long)(Math.Round(NumberUtil.Val( AV26TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "DepartamentoMunicipioId") == 0 )
               {
                  AV20Insert_DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( AV26TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "ZonasID") == 0 )
               {
                  AV21Insert_ZonasID = (long)(Math.Round(NumberUtil.Val( AV26TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "STMonedasId") == 0 )
               {
                  AV54Insert_STMonedasId = (short)(Math.Round(NumberUtil.Val( AV26TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "CuponId") == 0 )
               {
                  AV89Insert_CuponId = (long)(Math.Round(NumberUtil.Val( AV26TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "EstadosSolTipo") == 0 )
               {
                  AV22Insert_EstadosSolTipo = AV26TrnContextAtt.gxTpr_Attributevalue;
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "EstadosSolId") == 0 )
               {
                  AV23Insert_EstadosSolId = (int)(Math.Round(NumberUtil.Val( AV26TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "MetodoPagosID") == 0 )
               {
                  AV24Insert_MetodoPagosID = (long)(Math.Round(NumberUtil.Val( AV26TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "ProveedorID") == 0 )
               {
                  AV25Insert_ProveedorID = (long)(Math.Round(NumberUtil.Val( AV26TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "STComerciosID") == 0 )
               {
                  AV82Insert_STComerciosID = (long)(Math.Round(NumberUtil.Val( AV26TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "MudanzaId") == 0 )
               {
                  AV72Insert_MudanzaId = (long)(Math.Round(NumberUtil.Val( AV26TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "PostulacionesId") == 0 )
               {
                  AV83Insert_PostulacionesId = (long)(Math.Round(NumberUtil.Val( AV26TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "CancelacionTipificacionId") == 0 )
               {
                  AV84Insert_CancelacionTipificacionId = (long)(Math.Round(NumberUtil.Val( AV26TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "TicketId") == 0 )
               {
                  AV91Insert_TicketId = (long)(Math.Round(NumberUtil.Val( AV26TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV94GXV1 = (int)(AV94GXV1+1);
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            new orelnom(context ).execute(  AV7SolicitudesID, out  AV74ProfesionalesId, out  AV76NombreProfesional, out  AV75Existe) ;
         }
         AV70Administrar = false;
         /* Execute user subroutine: 'OBTENGO ROL' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E110O2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void E130O2( )
      {
         /* 'DoAsignarCostos' Routine */
         returnInSub = false;
         new occostosid(context ).execute(  A127SolicitudesID, out  AV8CostosId) ;
         if ( AV8CostosId == 0 )
         {
            /* Window Datatype Object Property */
            AV78Window.Url = formatLink("costoservicios.aspx", new object[] {UrlEncode(StringUtil.RTrim(context.GetMessage( "INS", ""))),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.LTrimStr(A127SolicitudesID,18,0))}, new string[] {"Mode","CentroCostosId","CentroCostosRef"}) ;
            AV78Window.SetReturnParms(new Object[] {});
            AV78Window.Height = 800;
            AV78Window.Width = 800;
            context.NewWindow(AV78Window);
         }
         else
         {
            /* Window Datatype Object Property */
            AV78Window.Url = formatLink("costoservicios.aspx", new object[] {UrlEncode(StringUtil.RTrim(context.GetMessage( "UPD", ""))),UrlEncode(StringUtil.LTrimStr(AV8CostosId,18,0)),UrlEncode(StringUtil.LTrimStr(A127SolicitudesID,18,0))}, new string[] {"Mode","CentroCostosId","CentroCostosRef"}) ;
            AV78Window.SetReturnParms(new Object[] {});
            AV78Window.Height = 800;
            AV78Window.Width = 800;
            context.NewWindow(AV78Window);
         }
      }

      protected void E140O2( )
      {
         /* 'DoCalcularComisiones' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "calcularcomisionwp.aspx"+UrlEncode(StringUtil.LTrimStr(A127SolicitudesID,18,0)) + "," + UrlEncode(StringUtil.BoolToStr(false));
         CallWebObject(formatLink("calcularcomisionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E150O2( )
      {
         /* 'DoVinculoProfesionales' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "solicitudesrelacion.aspx"+UrlEncode(StringUtil.RTrim(AV9Modo)) + "," + UrlEncode(StringUtil.LTrimStr(A127SolicitudesID,18,0));
         context.PopUp(formatLink("solicitudesrelacion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void E160O2( )
      {
         /* EstadosSolId_Click Routine */
         returnInSub = false;
      }

      protected void E170O2( )
      {
         /* SolicitudServicioPFinal_Controlvaluechanged Routine */
         returnInSub = false;
      }

      protected void E180O2( )
      {
         /* SolicitudesCotizacion_Controlvaluechanged Routine */
         returnInSub = false;
      }

      protected void S122( )
      {
         /* 'OBTENGO ROL' Routine */
         returnInSub = false;
      }

      protected void ZM0O30( short GX_JID )
      {
         if ( ( GX_JID == 63 ) || ( GX_JID == 0 ) )
         {
            Z438SolicitudServicioOrigenPago = A438SolicitudServicioOrigenPago;
            Z866SolicitudesCostoXZComAlmP = A866SolicitudesCostoXZComAlmP;
            Z865SolicitudesCostoXZComAlm = A865SolicitudesCostoXZComAlm;
            Z182SolicitudesFechaAlta = A182SolicitudesFechaAlta;
            Z171SolicitudesNombre = A171SolicitudesNombre;
            Z172SolicitudesTelefono = A172SolicitudesTelefono;
            Z206SolicitudesMail = A206SolicitudesMail;
            Z173SolicitudesDireccion = A173SolicitudesDireccion;
            Z194SolicitudesAutoEnumerar = A194SolicitudesAutoEnumerar;
            Z688SolicitudesLiqProf = A688SolicitudesLiqProf;
            Z689SolicitudesLiqProv = A689SolicitudesLiqProv;
            Z212SolicitudesCotizacion = A212SolicitudesCotizacion;
            Z210SolicitudServicioSolCoti = A210SolicitudServicioSolCoti;
            Z897SolicitudesDescuento = A897SolicitudesDescuento;
            Z1016SolicitudesDescuentoCupon = A1016SolicitudesDescuentoCupon;
            Z796SolicitudesComisionMetodoPago = A796SolicitudesComisionMetodoPago;
            Z201SolicitudesOtros1 = A201SolicitudesOtros1;
            Z202SolicitudesOtros2 = A202SolicitudesOtros2;
            Z203SolicitudesOtros3 = A203SolicitudesOtros3;
            Z597SolicitudesUsrAlta = A597SolicitudesUsrAlta;
            Z598SolicitudesUsrActualizacion = A598SolicitudesUsrActualizacion;
            Z204SolicitudesFechaActualizacion = A204SolicitudesFechaActualizacion;
            Z184SolicitudesFechaInstalacion = A184SolicitudesFechaInstalacion;
            Z183SolicitudesHoraInstalacion = A183SolicitudesHoraInstalacion;
            Z261SolicitudesNota = A261SolicitudesNota;
            Z262SolicitudesNotificacion = A262SolicitudesNotificacion;
            Z441SolicitudesPagado = A441SolicitudesPagado;
            Z527SolicitudServicioComProv = A527SolicitudServicioComProv;
            Z528SolicitudServicioComProvP = A528SolicitudServicioComProvP;
            Z530SolicitudServicioComALM = A530SolicitudServicioComALM;
            Z532SolicitudServicioComALMP = A532SolicitudServicioComALMP;
            Z672SolicitudesCalComi = A672SolicitudesCalComi;
            Z533ProveedorNombreAux = A533ProveedorNombreAux;
            Z600SolicitudesSubTipo = A600SolicitudesSubTipo;
            Z864SolicitudesCostoXZona = A864SolicitudesCostoXZona;
            Z972SolicitudesDuplicado = A972SolicitudesDuplicado;
            Z992SolicitudesSerialArchivo = A992SolicitudesSerialArchivo;
            Z1003SolicitudesCostoPresupuesto = A1003SolicitudesCostoPresupuesto;
            Z1006SolicitudesURLOrigen = A1006SolicitudesURLOrigen;
            Z112DepartamentoId = A112DepartamentoId;
            Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            Z110ZonasID = A110ZonasID;
            Z128MetodoPagosID = A128MetodoPagosID;
            Z735MudanzaId = A735MudanzaId;
            Z133ProveedorID = A133ProveedorID;
            Z919STComerciosID = A919STComerciosID;
            Z422PostulacionesId = A422PostulacionesId;
            Z996CancelacionTipificacionId = A996CancelacionTipificacionId;
            Z1013CuponId = A1013CuponId;
            Z1020TicketId = A1020TicketId;
            Z130EstadosSolTipo = A130EstadosSolTipo;
            Z131EstadosSolId = A131EstadosSolId;
            Z669STMonedasId = A669STMonedasId;
            Z174SolicitudesTotal = A174SolicitudesTotal;
            Z211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            Z529SolicitudServicioComPro = A529SolicitudServicioComPro;
            Z531SolicitudServicioComProP = A531SolicitudServicioComProP;
            Z867SolicitudesCostoXZComProf = A867SolicitudesCostoXZComProf;
            Z868SolicitudesCostoXZComProfP = A868SolicitudesCostoXZComProfP;
         }
         if ( ( GX_JID == 64 ) || ( GX_JID == 0 ) )
         {
            Z116PaisID = A116PaisID;
            Z174SolicitudesTotal = A174SolicitudesTotal;
            Z211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            Z529SolicitudServicioComPro = A529SolicitudServicioComPro;
            Z531SolicitudServicioComProP = A531SolicitudServicioComProP;
            Z867SolicitudesCostoXZComProf = A867SolicitudesCostoXZComProf;
            Z868SolicitudesCostoXZComProfP = A868SolicitudesCostoXZComProfP;
         }
         if ( ( GX_JID == 65 ) || ( GX_JID == 0 ) )
         {
            Z174SolicitudesTotal = A174SolicitudesTotal;
            Z211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            Z529SolicitudServicioComPro = A529SolicitudServicioComPro;
            Z531SolicitudServicioComProP = A531SolicitudServicioComProP;
            Z867SolicitudesCostoXZComProf = A867SolicitudesCostoXZComProf;
            Z868SolicitudesCostoXZComProfP = A868SolicitudesCostoXZComProfP;
         }
         if ( ( GX_JID == 66 ) || ( GX_JID == 0 ) )
         {
            Z174SolicitudesTotal = A174SolicitudesTotal;
            Z211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            Z529SolicitudServicioComPro = A529SolicitudServicioComPro;
            Z531SolicitudServicioComProP = A531SolicitudServicioComProP;
            Z867SolicitudesCostoXZComProf = A867SolicitudesCostoXZComProf;
            Z868SolicitudesCostoXZComProfP = A868SolicitudesCostoXZComProfP;
         }
         if ( ( GX_JID == 67 ) || ( GX_JID == 0 ) )
         {
            Z129MetodoPagosNombre = A129MetodoPagosNombre;
            Z174SolicitudesTotal = A174SolicitudesTotal;
            Z211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            Z529SolicitudServicioComPro = A529SolicitudServicioComPro;
            Z531SolicitudServicioComProP = A531SolicitudServicioComProP;
            Z867SolicitudesCostoXZComProf = A867SolicitudesCostoXZComProf;
            Z868SolicitudesCostoXZComProfP = A868SolicitudesCostoXZComProfP;
         }
         if ( ( GX_JID == 68 ) || ( GX_JID == 0 ) )
         {
            Z738MudanzaFechaServicio = A738MudanzaFechaServicio;
            Z740MudanzaDireccionOrigen = A740MudanzaDireccionOrigen;
            Z741MudanzaDireccionDestino = A741MudanzaDireccionDestino;
            Z174SolicitudesTotal = A174SolicitudesTotal;
            Z211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            Z529SolicitudServicioComPro = A529SolicitudServicioComPro;
            Z531SolicitudServicioComProP = A531SolicitudServicioComProP;
            Z867SolicitudesCostoXZComProf = A867SolicitudesCostoXZComProf;
            Z868SolicitudesCostoXZComProfP = A868SolicitudesCostoXZComProfP;
         }
         if ( ( GX_JID == 69 ) || ( GX_JID == 0 ) )
         {
            Z282ProveedorNombre = A282ProveedorNombre;
            Z440ProveedorPagoDefault = A440ProveedorPagoDefault;
            Z174SolicitudesTotal = A174SolicitudesTotal;
            Z211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            Z529SolicitudServicioComPro = A529SolicitudServicioComPro;
            Z531SolicitudServicioComProP = A531SolicitudServicioComProP;
            Z867SolicitudesCostoXZComProf = A867SolicitudesCostoXZComProf;
            Z868SolicitudesCostoXZComProfP = A868SolicitudesCostoXZComProfP;
         }
         if ( ( GX_JID == 70 ) || ( GX_JID == 0 ) )
         {
            Z923STComerciosNombre = A923STComerciosNombre;
            Z924STComerciosEstado = A924STComerciosEstado;
            Z174SolicitudesTotal = A174SolicitudesTotal;
            Z211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            Z529SolicitudServicioComPro = A529SolicitudServicioComPro;
            Z531SolicitudServicioComProP = A531SolicitudServicioComProP;
            Z867SolicitudesCostoXZComProf = A867SolicitudesCostoXZComProf;
            Z868SolicitudesCostoXZComProfP = A868SolicitudesCostoXZComProfP;
         }
         if ( ( GX_JID == 71 ) || ( GX_JID == 0 ) )
         {
            Z174SolicitudesTotal = A174SolicitudesTotal;
            Z211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            Z529SolicitudServicioComPro = A529SolicitudServicioComPro;
            Z531SolicitudServicioComProP = A531SolicitudServicioComProP;
            Z867SolicitudesCostoXZComProf = A867SolicitudesCostoXZComProf;
            Z868SolicitudesCostoXZComProfP = A868SolicitudesCostoXZComProfP;
         }
         if ( ( GX_JID == 72 ) || ( GX_JID == 0 ) )
         {
            Z997CancelacionTipificacionDescrip = A997CancelacionTipificacionDescrip;
            Z174SolicitudesTotal = A174SolicitudesTotal;
            Z211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            Z529SolicitudServicioComPro = A529SolicitudServicioComPro;
            Z531SolicitudServicioComProP = A531SolicitudServicioComProP;
            Z867SolicitudesCostoXZComProf = A867SolicitudesCostoXZComProf;
            Z868SolicitudesCostoXZComProfP = A868SolicitudesCostoXZComProfP;
         }
         if ( ( GX_JID == 73 ) || ( GX_JID == 0 ) )
         {
            Z1014CuponPercent = A1014CuponPercent;
            Z174SolicitudesTotal = A174SolicitudesTotal;
            Z211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            Z529SolicitudServicioComPro = A529SolicitudServicioComPro;
            Z531SolicitudServicioComProP = A531SolicitudServicioComProP;
            Z867SolicitudesCostoXZComProf = A867SolicitudesCostoXZComProf;
            Z868SolicitudesCostoXZComProfP = A868SolicitudesCostoXZComProfP;
         }
         if ( ( GX_JID == 74 ) || ( GX_JID == 0 ) )
         {
            Z1024TicketComentario = A1024TicketComentario;
            Z1026TicketAdjunto = A1026TicketAdjunto;
            Z1030TicketEstado = A1030TicketEstado;
            Z1023TicketSolicitudId = A1023TicketSolicitudId;
            Z1021TicketMotivoId = A1021TicketMotivoId;
            Z174SolicitudesTotal = A174SolicitudesTotal;
            Z211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            Z529SolicitudServicioComPro = A529SolicitudServicioComPro;
            Z531SolicitudServicioComProP = A531SolicitudServicioComProP;
            Z867SolicitudesCostoXZComProf = A867SolicitudesCostoXZComProf;
            Z868SolicitudesCostoXZComProfP = A868SolicitudesCostoXZComProfP;
         }
         if ( ( GX_JID == 75 ) || ( GX_JID == 0 ) )
         {
            Z132EstadosSolNombre = A132EstadosSolNombre;
            Z174SolicitudesTotal = A174SolicitudesTotal;
            Z211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            Z529SolicitudServicioComPro = A529SolicitudServicioComPro;
            Z531SolicitudServicioComProP = A531SolicitudServicioComProP;
            Z867SolicitudesCostoXZComProf = A867SolicitudesCostoXZComProf;
            Z868SolicitudesCostoXZComProfP = A868SolicitudesCostoXZComProfP;
         }
         if ( ( GX_JID == 76 ) || ( GX_JID == 0 ) )
         {
            Z671STMonedasISO = A671STMonedasISO;
            Z174SolicitudesTotal = A174SolicitudesTotal;
            Z211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            Z529SolicitudServicioComPro = A529SolicitudServicioComPro;
            Z531SolicitudServicioComProP = A531SolicitudServicioComProP;
            Z867SolicitudesCostoXZComProf = A867SolicitudesCostoXZComProf;
            Z868SolicitudesCostoXZComProfP = A868SolicitudesCostoXZComProfP;
         }
         if ( ( GX_JID == 77 ) || ( GX_JID == 0 ) )
         {
            Z1022TicketMotivoDescripcion = A1022TicketMotivoDescripcion;
            Z174SolicitudesTotal = A174SolicitudesTotal;
            Z211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            Z529SolicitudServicioComPro = A529SolicitudServicioComPro;
            Z531SolicitudServicioComProP = A531SolicitudServicioComProP;
            Z867SolicitudesCostoXZComProf = A867SolicitudesCostoXZComProf;
            Z868SolicitudesCostoXZComProfP = A868SolicitudesCostoXZComProfP;
         }
         if ( GX_JID == -63 )
         {
            Z127SolicitudesID = A127SolicitudesID;
            Z438SolicitudServicioOrigenPago = A438SolicitudServicioOrigenPago;
            Z866SolicitudesCostoXZComAlmP = A866SolicitudesCostoXZComAlmP;
            Z865SolicitudesCostoXZComAlm = A865SolicitudesCostoXZComAlm;
            Z182SolicitudesFechaAlta = A182SolicitudesFechaAlta;
            Z171SolicitudesNombre = A171SolicitudesNombre;
            Z172SolicitudesTelefono = A172SolicitudesTelefono;
            Z206SolicitudesMail = A206SolicitudesMail;
            Z173SolicitudesDireccion = A173SolicitudesDireccion;
            Z194SolicitudesAutoEnumerar = A194SolicitudesAutoEnumerar;
            Z688SolicitudesLiqProf = A688SolicitudesLiqProf;
            Z689SolicitudesLiqProv = A689SolicitudesLiqProv;
            Z212SolicitudesCotizacion = A212SolicitudesCotizacion;
            Z210SolicitudServicioSolCoti = A210SolicitudServicioSolCoti;
            Z897SolicitudesDescuento = A897SolicitudesDescuento;
            Z1016SolicitudesDescuentoCupon = A1016SolicitudesDescuentoCupon;
            Z796SolicitudesComisionMetodoPago = A796SolicitudesComisionMetodoPago;
            Z201SolicitudesOtros1 = A201SolicitudesOtros1;
            Z202SolicitudesOtros2 = A202SolicitudesOtros2;
            Z203SolicitudesOtros3 = A203SolicitudesOtros3;
            Z597SolicitudesUsrAlta = A597SolicitudesUsrAlta;
            Z598SolicitudesUsrActualizacion = A598SolicitudesUsrActualizacion;
            Z204SolicitudesFechaActualizacion = A204SolicitudesFechaActualizacion;
            Z184SolicitudesFechaInstalacion = A184SolicitudesFechaInstalacion;
            Z183SolicitudesHoraInstalacion = A183SolicitudesHoraInstalacion;
            Z205SolicitudesComentario = A205SolicitudesComentario;
            Z261SolicitudesNota = A261SolicitudesNota;
            Z262SolicitudesNotificacion = A262SolicitudesNotificacion;
            Z441SolicitudesPagado = A441SolicitudesPagado;
            Z527SolicitudServicioComProv = A527SolicitudServicioComProv;
            Z528SolicitudServicioComProvP = A528SolicitudServicioComProvP;
            Z530SolicitudServicioComALM = A530SolicitudServicioComALM;
            Z532SolicitudServicioComALMP = A532SolicitudServicioComALMP;
            Z672SolicitudesCalComi = A672SolicitudesCalComi;
            Z533ProveedorNombreAux = A533ProveedorNombreAux;
            Z600SolicitudesSubTipo = A600SolicitudesSubTipo;
            Z864SolicitudesCostoXZona = A864SolicitudesCostoXZona;
            Z972SolicitudesDuplicado = A972SolicitudesDuplicado;
            Z992SolicitudesSerialArchivo = A992SolicitudesSerialArchivo;
            Z1003SolicitudesCostoPresupuesto = A1003SolicitudesCostoPresupuesto;
            Z1006SolicitudesURLOrigen = A1006SolicitudesURLOrigen;
            Z112DepartamentoId = A112DepartamentoId;
            Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            Z110ZonasID = A110ZonasID;
            Z128MetodoPagosID = A128MetodoPagosID;
            Z735MudanzaId = A735MudanzaId;
            Z133ProveedorID = A133ProveedorID;
            Z919STComerciosID = A919STComerciosID;
            Z422PostulacionesId = A422PostulacionesId;
            Z996CancelacionTipificacionId = A996CancelacionTipificacionId;
            Z1013CuponId = A1013CuponId;
            Z1020TicketId = A1020TicketId;
            Z130EstadosSolTipo = A130EstadosSolTipo;
            Z131EstadosSolId = A131EstadosSolId;
            Z669STMonedasId = A669STMonedasId;
            Z116PaisID = A116PaisID;
            Z671STMonedasISO = A671STMonedasISO;
            Z1014CuponPercent = A1014CuponPercent;
            Z132EstadosSolNombre = A132EstadosSolNombre;
            Z129MetodoPagosNombre = A129MetodoPagosNombre;
            Z282ProveedorNombre = A282ProveedorNombre;
            Z440ProveedorPagoDefault = A440ProveedorPagoDefault;
            Z923STComerciosNombre = A923STComerciosNombre;
            Z924STComerciosEstado = A924STComerciosEstado;
            Z738MudanzaFechaServicio = A738MudanzaFechaServicio;
            Z740MudanzaDireccionOrigen = A740MudanzaDireccionOrigen;
            Z741MudanzaDireccionDestino = A741MudanzaDireccionDestino;
            Z997CancelacionTipificacionDescrip = A997CancelacionTipificacionDescrip;
            Z1024TicketComentario = A1024TicketComentario;
            Z1026TicketAdjunto = A1026TicketAdjunto;
            Z1030TicketEstado = A1030TicketEstado;
            Z1023TicketSolicitudId = A1023TicketSolicitudId;
            Z1021TicketMotivoId = A1021TicketMotivoId;
            Z1022TicketMotivoDescripcion = A1022TicketMotivoDescripcion;
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
            A182SolicitudesFechaAlta = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
            n182SolicitudesFechaAlta = false;
         }
         if ( IsIns( )  && (0==A996CancelacionTipificacionId) && ( Gx_BScreen == 0 ) )
         {
            A996CancelacionTipificacionId = 0;
         }
         if ( IsIns( )  && (0==A669STMonedasId) && ( Gx_BScreen == 0 ) )
         {
            A669STMonedasId = 1;
            n669STMonedasId = false;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A130EstadosSolTipo)) && ( Gx_BScreen == 0 ) )
         {
            A130EstadosSolTipo = context.GetMessage( context.GetMessage( "SOL", ""), "");
         }
         if ( IsIns( )  && (0==A131EstadosSolId) && ( Gx_BScreen == 0 ) )
         {
            A131EstadosSolId = 1;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A201SolicitudesOtros1)) && ( Gx_BScreen == 0 ) )
         {
            A201SolicitudesOtros1 = context.GetMessage( context.GetMessage( "N", ""), "");
         }
         if ( IsIns( )  && (0==A133ProveedorID) && ( Gx_BScreen == 0 ) )
         {
            A133ProveedorID = 1001;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A600SolicitudesSubTipo)) && ( Gx_BScreen == 0 ) )
         {
            A600SolicitudesSubTipo = "T";
            n600SolicitudesSubTipo = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV93Pgmname = "Solicitudes_BC";
            /* Using cursor BC000O21 */
            pr_default.execute(19, new Object[] {A996CancelacionTipificacionId});
            A997CancelacionTipificacionDescrip = BC000O21_A997CancelacionTipificacionDescrip[0];
            pr_default.close(19);
            /* Using cursor BC000O25 */
            pr_default.execute(23, new Object[] {n669STMonedasId, A669STMonedasId});
            A671STMonedasISO = BC000O25_A671STMonedasISO[0];
            pr_default.close(23);
            /* Using cursor BC000O24 */
            pr_default.execute(22, new Object[] {A130EstadosSolTipo, A131EstadosSolId});
            A132EstadosSolNombre = BC000O24_A132EstadosSolNombre[0];
            pr_default.close(22);
            AV73OldEstadosSolId = O131EstadosSolId;
            /* Using cursor BC000O18 */
            pr_default.execute(16, new Object[] {A133ProveedorID});
            A282ProveedorNombre = BC000O18_A282ProveedorNombre[0];
            A440ProveedorPagoDefault = BC000O18_A440ProveedorPagoDefault[0];
            pr_default.close(16);
            AV71oldProveedorID = O133ProveedorID;
         }
      }

      protected void Load0O30( )
      {
         /* Using cursor BC000O27 */
         pr_default.execute(25, new Object[] {A127SolicitudesID});
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound30 = 1;
            A438SolicitudServicioOrigenPago = BC000O27_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = BC000O27_n438SolicitudServicioOrigenPago[0];
            A866SolicitudesCostoXZComAlmP = BC000O27_A866SolicitudesCostoXZComAlmP[0];
            n866SolicitudesCostoXZComAlmP = BC000O27_n866SolicitudesCostoXZComAlmP[0];
            A865SolicitudesCostoXZComAlm = BC000O27_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = BC000O27_n865SolicitudesCostoXZComAlm[0];
            A182SolicitudesFechaAlta = BC000O27_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = BC000O27_n182SolicitudesFechaAlta[0];
            A171SolicitudesNombre = BC000O27_A171SolicitudesNombre[0];
            A172SolicitudesTelefono = BC000O27_A172SolicitudesTelefono[0];
            A206SolicitudesMail = BC000O27_A206SolicitudesMail[0];
            n206SolicitudesMail = BC000O27_n206SolicitudesMail[0];
            A173SolicitudesDireccion = BC000O27_A173SolicitudesDireccion[0];
            A194SolicitudesAutoEnumerar = BC000O27_A194SolicitudesAutoEnumerar[0];
            A671STMonedasISO = BC000O27_A671STMonedasISO[0];
            A688SolicitudesLiqProf = BC000O27_A688SolicitudesLiqProf[0];
            n688SolicitudesLiqProf = BC000O27_n688SolicitudesLiqProf[0];
            A689SolicitudesLiqProv = BC000O27_A689SolicitudesLiqProv[0];
            n689SolicitudesLiqProv = BC000O27_n689SolicitudesLiqProv[0];
            A212SolicitudesCotizacion = BC000O27_A212SolicitudesCotizacion[0];
            A210SolicitudServicioSolCoti = BC000O27_A210SolicitudServicioSolCoti[0];
            A897SolicitudesDescuento = BC000O27_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = BC000O27_n897SolicitudesDescuento[0];
            A1014CuponPercent = BC000O27_A1014CuponPercent[0];
            A1016SolicitudesDescuentoCupon = BC000O27_A1016SolicitudesDescuentoCupon[0];
            A796SolicitudesComisionMetodoPago = BC000O27_A796SolicitudesComisionMetodoPago[0];
            A132EstadosSolNombre = BC000O27_A132EstadosSolNombre[0];
            A201SolicitudesOtros1 = BC000O27_A201SolicitudesOtros1[0];
            A202SolicitudesOtros2 = BC000O27_A202SolicitudesOtros2[0];
            A203SolicitudesOtros3 = BC000O27_A203SolicitudesOtros3[0];
            A597SolicitudesUsrAlta = BC000O27_A597SolicitudesUsrAlta[0];
            n597SolicitudesUsrAlta = BC000O27_n597SolicitudesUsrAlta[0];
            A598SolicitudesUsrActualizacion = BC000O27_A598SolicitudesUsrActualizacion[0];
            n598SolicitudesUsrActualizacion = BC000O27_n598SolicitudesUsrActualizacion[0];
            A204SolicitudesFechaActualizacion = BC000O27_A204SolicitudesFechaActualizacion[0];
            n204SolicitudesFechaActualizacion = BC000O27_n204SolicitudesFechaActualizacion[0];
            A184SolicitudesFechaInstalacion = BC000O27_A184SolicitudesFechaInstalacion[0];
            A183SolicitudesHoraInstalacion = BC000O27_A183SolicitudesHoraInstalacion[0];
            A205SolicitudesComentario = BC000O27_A205SolicitudesComentario[0];
            A129MetodoPagosNombre = BC000O27_A129MetodoPagosNombre[0];
            A261SolicitudesNota = BC000O27_A261SolicitudesNota[0];
            A262SolicitudesNotificacion = BC000O27_A262SolicitudesNotificacion[0];
            A282ProveedorNombre = BC000O27_A282ProveedorNombre[0];
            A440ProveedorPagoDefault = BC000O27_A440ProveedorPagoDefault[0];
            A923STComerciosNombre = BC000O27_A923STComerciosNombre[0];
            A924STComerciosEstado = BC000O27_A924STComerciosEstado[0];
            A441SolicitudesPagado = BC000O27_A441SolicitudesPagado[0];
            n441SolicitudesPagado = BC000O27_n441SolicitudesPagado[0];
            A527SolicitudServicioComProv = BC000O27_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = BC000O27_n527SolicitudServicioComProv[0];
            A528SolicitudServicioComProvP = BC000O27_A528SolicitudServicioComProvP[0];
            n528SolicitudServicioComProvP = BC000O27_n528SolicitudServicioComProvP[0];
            A530SolicitudServicioComALM = BC000O27_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = BC000O27_n530SolicitudServicioComALM[0];
            A532SolicitudServicioComALMP = BC000O27_A532SolicitudServicioComALMP[0];
            n532SolicitudServicioComALMP = BC000O27_n532SolicitudServicioComALMP[0];
            A672SolicitudesCalComi = BC000O27_A672SolicitudesCalComi[0];
            A533ProveedorNombreAux = BC000O27_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = BC000O27_n533ProveedorNombreAux[0];
            A600SolicitudesSubTipo = BC000O27_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = BC000O27_n600SolicitudesSubTipo[0];
            A864SolicitudesCostoXZona = BC000O27_A864SolicitudesCostoXZona[0];
            A738MudanzaFechaServicio = BC000O27_A738MudanzaFechaServicio[0];
            A740MudanzaDireccionOrigen = BC000O27_A740MudanzaDireccionOrigen[0];
            A741MudanzaDireccionDestino = BC000O27_A741MudanzaDireccionDestino[0];
            A972SolicitudesDuplicado = BC000O27_A972SolicitudesDuplicado[0];
            n972SolicitudesDuplicado = BC000O27_n972SolicitudesDuplicado[0];
            A992SolicitudesSerialArchivo = BC000O27_A992SolicitudesSerialArchivo[0];
            A997CancelacionTipificacionDescrip = BC000O27_A997CancelacionTipificacionDescrip[0];
            A1003SolicitudesCostoPresupuesto = BC000O27_A1003SolicitudesCostoPresupuesto[0];
            n1003SolicitudesCostoPresupuesto = BC000O27_n1003SolicitudesCostoPresupuesto[0];
            A1006SolicitudesURLOrigen = BC000O27_A1006SolicitudesURLOrigen[0];
            n1006SolicitudesURLOrigen = BC000O27_n1006SolicitudesURLOrigen[0];
            A1022TicketMotivoDescripcion = BC000O27_A1022TicketMotivoDescripcion[0];
            A1024TicketComentario = BC000O27_A1024TicketComentario[0];
            A1026TicketAdjunto = BC000O27_A1026TicketAdjunto[0];
            A1030TicketEstado = BC000O27_A1030TicketEstado[0];
            A1023TicketSolicitudId = BC000O27_A1023TicketSolicitudId[0];
            A112DepartamentoId = BC000O27_A112DepartamentoId[0];
            n112DepartamentoId = BC000O27_n112DepartamentoId[0];
            A114DepartamentoMunicipioId = BC000O27_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = BC000O27_n114DepartamentoMunicipioId[0];
            A110ZonasID = BC000O27_A110ZonasID[0];
            n110ZonasID = BC000O27_n110ZonasID[0];
            A128MetodoPagosID = BC000O27_A128MetodoPagosID[0];
            A735MudanzaId = BC000O27_A735MudanzaId[0];
            n735MudanzaId = BC000O27_n735MudanzaId[0];
            A133ProveedorID = BC000O27_A133ProveedorID[0];
            A919STComerciosID = BC000O27_A919STComerciosID[0];
            n919STComerciosID = BC000O27_n919STComerciosID[0];
            A422PostulacionesId = BC000O27_A422PostulacionesId[0];
            n422PostulacionesId = BC000O27_n422PostulacionesId[0];
            A996CancelacionTipificacionId = BC000O27_A996CancelacionTipificacionId[0];
            A1013CuponId = BC000O27_A1013CuponId[0];
            n1013CuponId = BC000O27_n1013CuponId[0];
            A1020TicketId = BC000O27_A1020TicketId[0];
            n1020TicketId = BC000O27_n1020TicketId[0];
            A130EstadosSolTipo = BC000O27_A130EstadosSolTipo[0];
            A131EstadosSolId = BC000O27_A131EstadosSolId[0];
            A669STMonedasId = BC000O27_A669STMonedasId[0];
            n669STMonedasId = BC000O27_n669STMonedasId[0];
            A116PaisID = BC000O27_A116PaisID[0];
            A1021TicketMotivoId = BC000O27_A1021TicketMotivoId[0];
            ZM0O30( -63) ;
         }
         pr_default.close(25);
         OnLoadActions0O30( ) ;
      }

      protected void OnLoadActions0O30( )
      {
         AV93Pgmname = "Solicitudes_BC";
         if ( ( AV77SolicitudesCostoXZComAlmP > Convert.ToDecimal( 0 )) && ( A864SolicitudesCostoXZona > Convert.ToDecimal( 0 )) )
         {
            A866SolicitudesCostoXZComAlmP = AV77SolicitudesCostoXZComAlmP;
            n866SolicitudesCostoXZComAlmP = false;
         }
         GetSolicitudesTotal( A127SolicitudesID) ;
         O174SolicitudesTotal = A174SolicitudesTotal;
         if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
         {
            A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
         }
         else
         {
            if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                  }
                  else
                  {
                     A211SolicitudServicioPFinal = 0;
                  }
               }
            }
         }
         O211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
         if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
         {
            A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
         }
         else
         {
            if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
            {
               A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
            }
            else
            {
               if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
               {
                  A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
               }
               else
               {
                  A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
               }
            }
         }
         AV52OldSolicitudServicioPFinal = O211SolicitudServicioPFinal;
         if ( (0==A114DepartamentoMunicipioId) )
         {
            A114DepartamentoMunicipioId = 0;
            n114DepartamentoMunicipioId = false;
            n114DepartamentoMunicipioId = true;
         }
         if ( (0==A110ZonasID) )
         {
            A110ZonasID = 0;
            n110ZonasID = false;
            n110ZonasID = true;
         }
         AV53OldSolicitudesCotizacion = O212SolicitudesCotizacion;
         AV73OldEstadosSolId = O131EstadosSolId;
         AV71oldProveedorID = O133ProveedorID;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A438SolicitudServicioOrigenPago)) && ( A133ProveedorID > 0 ) && ( AV71oldProveedorID != A133ProveedorID ) )
         {
            A438SolicitudServicioOrigenPago = A440ProveedorPagoDefault;
            n438SolicitudServicioOrigenPago = false;
         }
         if ( (0==A919STComerciosID) )
         {
            A919STComerciosID = 0;
            n919STComerciosID = false;
            n919STComerciosID = true;
         }
         if ( ( A532SolicitudServicioComALMP >= Convert.ToDecimal( 0 )) )
         {
            A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
         }
         else
         {
            if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP >= Convert.ToDecimal( 0 )) )
            {
               A531SolicitudServicioComProP = (decimal)((100-A528SolicitudServicioComProvP)+(A532SolicitudServicioComALMP*-1));
            }
            else
            {
               if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP < Convert.ToDecimal( 0 )) )
               {
                  A531SolicitudServicioComProP = (decimal)(100+((A528SolicitudServicioComProvP+A532SolicitudServicioComALMP)*-1));
               }
               else
               {
                  A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
               }
            }
         }
         if ( ( A866SolicitudesCostoXZComAlmP > Convert.ToDecimal( 0 )) )
         {
            A865SolicitudesCostoXZComAlm = (decimal)((A864SolicitudesCostoXZona*(A866SolicitudesCostoXZComAlmP/ (decimal)(100))));
            n865SolicitudesCostoXZComAlm = false;
         }
         else
         {
            if ( (Convert.ToDecimal(0)==A866SolicitudesCostoXZComAlmP) )
            {
               A865SolicitudesCostoXZComAlm = 0;
               n865SolicitudesCostoXZComAlm = false;
            }
         }
         if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
         {
            A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
         }
         else
         {
            A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
         }
         if ( ( A866SolicitudesCostoXZComAlmP >= Convert.ToDecimal( 0 )) )
         {
            A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
         }
         else
         {
            if ( ( A866SolicitudesCostoXZComAlmP < Convert.ToDecimal( 0 )) )
            {
               A868SolicitudesCostoXZComProfP = (decimal)(100+(A866SolicitudesCostoXZComAlmP*-1));
            }
            else
            {
               A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
            }
         }
         if ( (0==A735MudanzaId) )
         {
            A735MudanzaId = 0;
            n735MudanzaId = false;
            n735MudanzaId = true;
         }
         if ( (0==A422PostulacionesId) )
         {
            A422PostulacionesId = 0;
            n422PostulacionesId = false;
            n422PostulacionesId = true;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1006SolicitudesURLOrigen)) )
         {
            A1006SolicitudesURLOrigen = "";
            n1006SolicitudesURLOrigen = false;
            n1006SolicitudesURLOrigen = true;
         }
         if ( (0==A1020TicketId) )
         {
            A1020TicketId = 0;
            n1020TicketId = false;
            n1020TicketId = true;
         }
         if ( IsIns( )  && (0==A112DepartamentoId) && ( Gx_BScreen == 0 ) )
         {
            A112DepartamentoId = 1;
            n112DepartamentoId = false;
         }
         else
         {
            if ( (0==A112DepartamentoId) )
            {
               A112DepartamentoId = 0;
               n112DepartamentoId = false;
               n112DepartamentoId = true;
            }
         }
         if ( (0==A1013CuponId) )
         {
            A1013CuponId = 0;
            n1013CuponId = false;
            n1013CuponId = true;
         }
         else
         {
            if ( IsIns( )  && (0==A1013CuponId) && ( Gx_BScreen == 0 ) )
            {
               A1013CuponId = 1234;
               n1013CuponId = false;
            }
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A116PaisID)) && ( Gx_BScreen == 0 ) )
         {
            A116PaisID = context.GetMessage( "UY", "");
         }
      }

      protected void CheckExtendedTable0O30( )
      {
         standaloneModal( ) ;
         AV93Pgmname = "Solicitudes_BC";
         if ( ( AV77SolicitudesCostoXZComAlmP > Convert.ToDecimal( 0 )) && ( A864SolicitudesCostoXZona > Convert.ToDecimal( 0 )) )
         {
            A866SolicitudesCostoXZComAlmP = AV77SolicitudesCostoXZComAlmP;
            n866SolicitudesCostoXZComAlmP = false;
         }
         GetSolicitudesTotal( A127SolicitudesID) ;
         O174SolicitudesTotal = A174SolicitudesTotal;
         if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
         {
            A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
         }
         else
         {
            if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                  }
                  else
                  {
                     A211SolicitudServicioPFinal = 0;
                  }
               }
            }
         }
         if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
         {
            A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
         }
         else
         {
            if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
            {
               A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
            }
            else
            {
               if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
               {
                  A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
               }
               else
               {
                  A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
               }
            }
         }
         AV52OldSolicitudServicioPFinal = O211SolicitudServicioPFinal;
         if ( ! ( GxRegex.IsMatch(A206SolicitudesMail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A206SolicitudesMail)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "ClientMail", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( (0==A114DepartamentoMunicipioId) )
         {
            A114DepartamentoMunicipioId = 0;
            n114DepartamentoMunicipioId = false;
            n114DepartamentoMunicipioId = true;
         }
         if ( (0==A110ZonasID) )
         {
            A110ZonasID = 0;
            n110ZonasID = false;
            n110ZonasID = true;
         }
         /* Using cursor BC000O25 */
         pr_default.execute(23, new Object[] {n669STMonedasId, A669STMonedasId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (0==A669STMonedasId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "STMonedas", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "STMONEDASID");
               AnyError = 1;
            }
         }
         A671STMonedasISO = BC000O25_A671STMonedasISO[0];
         pr_default.close(23);
         AV53OldSolicitudesCotizacion = O212SolicitudesCotizacion;
         /* Using cursor BC000O24 */
         pr_default.execute(22, new Object[] {A130EstadosSolTipo, A131EstadosSolId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados Solicitudes", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSSOLID");
            AnyError = 1;
         }
         A132EstadosSolNombre = BC000O24_A132EstadosSolNombre[0];
         pr_default.close(22);
         AV73OldEstadosSolId = O131EstadosSolId;
         if ( ( ( A131EstadosSolId == 3 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( A261SolicitudesNota)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "NOTA:", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ( ( A131EstadosSolId == 3 ) ) && (0==A996CancelacionTipificacionId) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Cancelacion Tipificacion Id", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A182SolicitudesFechaAlta) || ( DateTimeUtil.ResetTime ( A182SolicitudesFechaAlta ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "FechaAlta", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A204SolicitudesFechaActualizacion) || ( A204SolicitudesFechaActualizacion >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Actualizado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A184SolicitudesFechaInstalacion) || ( DateTimeUtil.ResetTime ( A184SolicitudesFechaInstalacion ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha de instalación", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ( ( StringUtil.StrCmp(A600SolicitudesSubTipo, "A") == 0 ) ) && (DateTime.MinValue==A184SolicitudesFechaInstalacion) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Fecha de instalación", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000O16 */
         pr_default.execute(14, new Object[] {A128MetodoPagosID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Metodo Pagos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "METODOPAGOSID");
            AnyError = 1;
         }
         A129MetodoPagosNombre = BC000O16_A129MetodoPagosNombre[0];
         pr_default.close(14);
         /* Using cursor BC000O18 */
         pr_default.execute(16, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
         }
         A282ProveedorNombre = BC000O18_A282ProveedorNombre[0];
         A440ProveedorPagoDefault = BC000O18_A440ProveedorPagoDefault[0];
         pr_default.close(16);
         AV71oldProveedorID = O133ProveedorID;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A438SolicitudServicioOrigenPago)) && ( A133ProveedorID > 0 ) && ( AV71oldProveedorID != A133ProveedorID ) )
         {
            A438SolicitudServicioOrigenPago = A440ProveedorPagoDefault;
            n438SolicitudServicioOrigenPago = false;
         }
         if ( ( ( StringUtil.StrCmp(A600SolicitudesSubTipo, "A") == 0 ) ) && (0==A133ProveedorID) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Comercio", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( (0==A919STComerciosID) )
         {
            A919STComerciosID = 0;
            n919STComerciosID = false;
            n919STComerciosID = true;
         }
         /* Using cursor BC000O19 */
         pr_default.execute(17, new Object[] {n919STComerciosID, A919STComerciosID});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (0==A919STComerciosID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Comercios SubTipo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "STCOMERCIOSID");
               AnyError = 1;
            }
         }
         A923STComerciosNombre = BC000O19_A923STComerciosNombre[0];
         A924STComerciosEstado = BC000O19_A924STComerciosEstado[0];
         pr_default.close(17);
         if ( ! ( ( StringUtil.StrCmp(A438SolicitudServicioOrigenPago, "F") == 0 ) || ( StringUtil.StrCmp(A438SolicitudServicioOrigenPago, "T") == 0 ) || ( StringUtil.StrCmp(A438SolicitudServicioOrigenPago, "O") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A438SolicitudServicioOrigenPago)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Origen del Pago", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ( A532SolicitudServicioComALMP >= Convert.ToDecimal( 0 )) )
         {
            A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
         }
         else
         {
            if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP >= Convert.ToDecimal( 0 )) )
            {
               A531SolicitudServicioComProP = (decimal)((100-A528SolicitudServicioComProvP)+(A532SolicitudServicioComALMP*-1));
            }
            else
            {
               if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP < Convert.ToDecimal( 0 )) )
               {
                  A531SolicitudServicioComProP = (decimal)(100+((A528SolicitudServicioComProvP+A532SolicitudServicioComALMP)*-1));
               }
               else
               {
                  A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
               }
            }
         }
         if ( ! ( ( StringUtil.StrCmp(A600SolicitudesSubTipo, "T") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "E") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "G") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "M") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "A") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "O") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "Z") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "S") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "P") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A600SolicitudesSubTipo)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Sub Tipo", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ( A866SolicitudesCostoXZComAlmP > Convert.ToDecimal( 0 )) )
         {
            A865SolicitudesCostoXZComAlm = (decimal)((A864SolicitudesCostoXZona*(A866SolicitudesCostoXZComAlmP/ (decimal)(100))));
            n865SolicitudesCostoXZComAlm = false;
         }
         else
         {
            if ( (Convert.ToDecimal(0)==A866SolicitudesCostoXZComAlmP) )
            {
               A865SolicitudesCostoXZComAlm = 0;
               n865SolicitudesCostoXZComAlm = false;
            }
         }
         if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
         {
            A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
         }
         else
         {
            A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
         }
         if ( ( A866SolicitudesCostoXZComAlmP >= Convert.ToDecimal( 0 )) )
         {
            A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
         }
         else
         {
            if ( ( A866SolicitudesCostoXZComAlmP < Convert.ToDecimal( 0 )) )
            {
               A868SolicitudesCostoXZComProfP = (decimal)(100+(A866SolicitudesCostoXZComAlmP*-1));
            }
            else
            {
               A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
            }
         }
         if ( (0==A735MudanzaId) )
         {
            A735MudanzaId = 0;
            n735MudanzaId = false;
            n735MudanzaId = true;
         }
         /* Using cursor BC000O17 */
         pr_default.execute(15, new Object[] {n735MudanzaId, A735MudanzaId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A735MudanzaId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Mudanza", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MUDANZAID");
               AnyError = 1;
            }
         }
         A738MudanzaFechaServicio = BC000O17_A738MudanzaFechaServicio[0];
         A740MudanzaDireccionOrigen = BC000O17_A740MudanzaDireccionOrigen[0];
         A741MudanzaDireccionDestino = BC000O17_A741MudanzaDireccionDestino[0];
         pr_default.close(15);
         if ( (0==A422PostulacionesId) )
         {
            A422PostulacionesId = 0;
            n422PostulacionesId = false;
            n422PostulacionesId = true;
         }
         /* Using cursor BC000O20 */
         pr_default.execute(18, new Object[] {n422PostulacionesId, A422PostulacionesId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( (0==A422PostulacionesId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Postulaciones", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "POSTULACIONESID");
               AnyError = 1;
            }
         }
         pr_default.close(18);
         /* Using cursor BC000O21 */
         pr_default.execute(19, new Object[] {A996CancelacionTipificacionId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Cancelacion Tipificacion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CANCELACIONTIPIFICACIONID");
            AnyError = 1;
         }
         A997CancelacionTipificacionDescrip = BC000O21_A997CancelacionTipificacionDescrip[0];
         pr_default.close(19);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1006SolicitudesURLOrigen)) )
         {
            A1006SolicitudesURLOrigen = "";
            n1006SolicitudesURLOrigen = false;
            n1006SolicitudesURLOrigen = true;
         }
         if ( (0==A1020TicketId) )
         {
            A1020TicketId = 0;
            n1020TicketId = false;
            n1020TicketId = true;
         }
         /* Using cursor BC000O23 */
         pr_default.execute(21, new Object[] {n1020TicketId, A1020TicketId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( (0==A1020TicketId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ticket", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TICKETID");
               AnyError = 1;
            }
         }
         A1024TicketComentario = BC000O23_A1024TicketComentario[0];
         A1026TicketAdjunto = BC000O23_A1026TicketAdjunto[0];
         A1030TicketEstado = BC000O23_A1030TicketEstado[0];
         A1023TicketSolicitudId = BC000O23_A1023TicketSolicitudId[0];
         A1021TicketMotivoId = BC000O23_A1021TicketMotivoId[0];
         pr_default.close(21);
         /* Using cursor BC000O26 */
         pr_default.execute(24, new Object[] {A1021TicketMotivoId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A1021TicketMotivoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ticket Motivo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TICKETMOTIVOID");
               AnyError = 1;
            }
         }
         A1022TicketMotivoDescripcion = BC000O26_A1022TicketMotivoDescripcion[0];
         pr_default.close(24);
         if ( IsIns( )  && (0==A112DepartamentoId) && ( Gx_BScreen == 0 ) )
         {
            A112DepartamentoId = 1;
            n112DepartamentoId = false;
         }
         else
         {
            if ( (0==A112DepartamentoId) )
            {
               A112DepartamentoId = 0;
               n112DepartamentoId = false;
               n112DepartamentoId = true;
            }
         }
         if ( (0==A1013CuponId) )
         {
            A1013CuponId = 0;
            n1013CuponId = false;
            n1013CuponId = true;
         }
         else
         {
            if ( IsIns( )  && (0==A1013CuponId) && ( Gx_BScreen == 0 ) )
            {
               A1013CuponId = 1234;
               n1013CuponId = false;
            }
         }
         /* Using cursor BC000O13 */
         pr_default.execute(11, new Object[] {n112DepartamentoId, A112DepartamentoId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A112DepartamentoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
               AnyError = 1;
            }
         }
         A116PaisID = BC000O13_A116PaisID[0];
         pr_default.close(11);
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A116PaisID)) && ( Gx_BScreen == 0 ) )
         {
            A116PaisID = context.GetMessage( "UY", "");
         }
         /* Using cursor BC000O14 */
         pr_default.execute(12, new Object[] {n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A112DepartamentoId) || (0==A114DepartamentoMunicipioId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
               AnyError = 1;
            }
         }
         pr_default.close(12);
         /* Using cursor BC000O15 */
         pr_default.execute(13, new Object[] {n110ZonasID, A110ZonasID, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A110ZonasID) || (0==A112DepartamentoId) || (0==A114DepartamentoMunicipioId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Zonas", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
               AnyError = 1;
            }
         }
         pr_default.close(13);
         /* Using cursor BC000O22 */
         pr_default.execute(20, new Object[] {n1013CuponId, A1013CuponId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A1013CuponId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Cupon", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUPONID");
               AnyError = 1;
            }
         }
         A1014CuponPercent = BC000O22_A1014CuponPercent[0];
         pr_default.close(20);
      }

      protected void CloseExtendedTableCursors0O30( )
      {
         pr_default.close(23);
         pr_default.close(22);
         pr_default.close(14);
         pr_default.close(16);
         pr_default.close(17);
         pr_default.close(15);
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(21);
         pr_default.close(24);
         pr_default.close(10);
         pr_default.close(12);
         pr_default.close(13);
         pr_default.close(20);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0O30( )
      {
         /* Using cursor BC000O28 */
         pr_default.execute(26, new Object[] {A127SolicitudesID});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound30 = 1;
         }
         else
         {
            RcdFound30 = 0;
         }
         pr_default.close(26);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000O11 */
         pr_default.execute(9, new Object[] {A127SolicitudesID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            ZM0O30( 63) ;
            RcdFound30 = 1;
            A127SolicitudesID = BC000O11_A127SolicitudesID[0];
            A438SolicitudServicioOrigenPago = BC000O11_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = BC000O11_n438SolicitudServicioOrigenPago[0];
            A866SolicitudesCostoXZComAlmP = BC000O11_A866SolicitudesCostoXZComAlmP[0];
            n866SolicitudesCostoXZComAlmP = BC000O11_n866SolicitudesCostoXZComAlmP[0];
            A865SolicitudesCostoXZComAlm = BC000O11_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = BC000O11_n865SolicitudesCostoXZComAlm[0];
            A182SolicitudesFechaAlta = BC000O11_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = BC000O11_n182SolicitudesFechaAlta[0];
            A171SolicitudesNombre = BC000O11_A171SolicitudesNombre[0];
            A172SolicitudesTelefono = BC000O11_A172SolicitudesTelefono[0];
            A206SolicitudesMail = BC000O11_A206SolicitudesMail[0];
            n206SolicitudesMail = BC000O11_n206SolicitudesMail[0];
            A173SolicitudesDireccion = BC000O11_A173SolicitudesDireccion[0];
            A194SolicitudesAutoEnumerar = BC000O11_A194SolicitudesAutoEnumerar[0];
            A688SolicitudesLiqProf = BC000O11_A688SolicitudesLiqProf[0];
            n688SolicitudesLiqProf = BC000O11_n688SolicitudesLiqProf[0];
            A689SolicitudesLiqProv = BC000O11_A689SolicitudesLiqProv[0];
            n689SolicitudesLiqProv = BC000O11_n689SolicitudesLiqProv[0];
            A212SolicitudesCotizacion = BC000O11_A212SolicitudesCotizacion[0];
            A210SolicitudServicioSolCoti = BC000O11_A210SolicitudServicioSolCoti[0];
            A897SolicitudesDescuento = BC000O11_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = BC000O11_n897SolicitudesDescuento[0];
            A1016SolicitudesDescuentoCupon = BC000O11_A1016SolicitudesDescuentoCupon[0];
            A796SolicitudesComisionMetodoPago = BC000O11_A796SolicitudesComisionMetodoPago[0];
            A201SolicitudesOtros1 = BC000O11_A201SolicitudesOtros1[0];
            A202SolicitudesOtros2 = BC000O11_A202SolicitudesOtros2[0];
            A203SolicitudesOtros3 = BC000O11_A203SolicitudesOtros3[0];
            A597SolicitudesUsrAlta = BC000O11_A597SolicitudesUsrAlta[0];
            n597SolicitudesUsrAlta = BC000O11_n597SolicitudesUsrAlta[0];
            A598SolicitudesUsrActualizacion = BC000O11_A598SolicitudesUsrActualizacion[0];
            n598SolicitudesUsrActualizacion = BC000O11_n598SolicitudesUsrActualizacion[0];
            A204SolicitudesFechaActualizacion = BC000O11_A204SolicitudesFechaActualizacion[0];
            n204SolicitudesFechaActualizacion = BC000O11_n204SolicitudesFechaActualizacion[0];
            A184SolicitudesFechaInstalacion = BC000O11_A184SolicitudesFechaInstalacion[0];
            A183SolicitudesHoraInstalacion = BC000O11_A183SolicitudesHoraInstalacion[0];
            A205SolicitudesComentario = BC000O11_A205SolicitudesComentario[0];
            A261SolicitudesNota = BC000O11_A261SolicitudesNota[0];
            A262SolicitudesNotificacion = BC000O11_A262SolicitudesNotificacion[0];
            A441SolicitudesPagado = BC000O11_A441SolicitudesPagado[0];
            n441SolicitudesPagado = BC000O11_n441SolicitudesPagado[0];
            A527SolicitudServicioComProv = BC000O11_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = BC000O11_n527SolicitudServicioComProv[0];
            A528SolicitudServicioComProvP = BC000O11_A528SolicitudServicioComProvP[0];
            n528SolicitudServicioComProvP = BC000O11_n528SolicitudServicioComProvP[0];
            A530SolicitudServicioComALM = BC000O11_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = BC000O11_n530SolicitudServicioComALM[0];
            A532SolicitudServicioComALMP = BC000O11_A532SolicitudServicioComALMP[0];
            n532SolicitudServicioComALMP = BC000O11_n532SolicitudServicioComALMP[0];
            A672SolicitudesCalComi = BC000O11_A672SolicitudesCalComi[0];
            A533ProveedorNombreAux = BC000O11_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = BC000O11_n533ProveedorNombreAux[0];
            A600SolicitudesSubTipo = BC000O11_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = BC000O11_n600SolicitudesSubTipo[0];
            A864SolicitudesCostoXZona = BC000O11_A864SolicitudesCostoXZona[0];
            A972SolicitudesDuplicado = BC000O11_A972SolicitudesDuplicado[0];
            n972SolicitudesDuplicado = BC000O11_n972SolicitudesDuplicado[0];
            A992SolicitudesSerialArchivo = BC000O11_A992SolicitudesSerialArchivo[0];
            A1003SolicitudesCostoPresupuesto = BC000O11_A1003SolicitudesCostoPresupuesto[0];
            n1003SolicitudesCostoPresupuesto = BC000O11_n1003SolicitudesCostoPresupuesto[0];
            A1006SolicitudesURLOrigen = BC000O11_A1006SolicitudesURLOrigen[0];
            n1006SolicitudesURLOrigen = BC000O11_n1006SolicitudesURLOrigen[0];
            A112DepartamentoId = BC000O11_A112DepartamentoId[0];
            n112DepartamentoId = BC000O11_n112DepartamentoId[0];
            A114DepartamentoMunicipioId = BC000O11_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = BC000O11_n114DepartamentoMunicipioId[0];
            A110ZonasID = BC000O11_A110ZonasID[0];
            n110ZonasID = BC000O11_n110ZonasID[0];
            A128MetodoPagosID = BC000O11_A128MetodoPagosID[0];
            A735MudanzaId = BC000O11_A735MudanzaId[0];
            n735MudanzaId = BC000O11_n735MudanzaId[0];
            A133ProveedorID = BC000O11_A133ProveedorID[0];
            A919STComerciosID = BC000O11_A919STComerciosID[0];
            n919STComerciosID = BC000O11_n919STComerciosID[0];
            A422PostulacionesId = BC000O11_A422PostulacionesId[0];
            n422PostulacionesId = BC000O11_n422PostulacionesId[0];
            A996CancelacionTipificacionId = BC000O11_A996CancelacionTipificacionId[0];
            A1013CuponId = BC000O11_A1013CuponId[0];
            n1013CuponId = BC000O11_n1013CuponId[0];
            A1020TicketId = BC000O11_A1020TicketId[0];
            n1020TicketId = BC000O11_n1020TicketId[0];
            A130EstadosSolTipo = BC000O11_A130EstadosSolTipo[0];
            A131EstadosSolId = BC000O11_A131EstadosSolId[0];
            A669STMonedasId = BC000O11_A669STMonedasId[0];
            n669STMonedasId = BC000O11_n669STMonedasId[0];
            O992SolicitudesSerialArchivo = A992SolicitudesSerialArchivo;
            O194SolicitudesAutoEnumerar = A194SolicitudesAutoEnumerar;
            O133ProveedorID = A133ProveedorID;
            O212SolicitudesCotizacion = A212SolicitudesCotizacion;
            O131EstadosSolId = A131EstadosSolId;
            Z127SolicitudesID = A127SolicitudesID;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0O30( ) ;
            if ( AnyError == 1 )
            {
               RcdFound30 = 0;
               InitializeNonKey0O30( ) ;
            }
            Gx_mode = sMode30;
         }
         else
         {
            RcdFound30 = 0;
            InitializeNonKey0O30( ) ;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode30;
         }
         pr_default.close(9);
      }

      protected void getEqualNoModal( )
      {
         GetKey0O30( ) ;
         if ( RcdFound30 == 0 )
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
         CONFIRM_0O0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0O30( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000O10 */
            pr_default.execute(8, new Object[] {A127SolicitudesID});
            if ( (pr_default.getStatus(8) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Solicitudes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(8) == 101) || ( StringUtil.StrCmp(Z438SolicitudServicioOrigenPago, BC000O10_A438SolicitudServicioOrigenPago[0]) != 0 ) || ( Z866SolicitudesCostoXZComAlmP != BC000O10_A866SolicitudesCostoXZComAlmP[0] ) || ( Z865SolicitudesCostoXZComAlm != BC000O10_A865SolicitudesCostoXZComAlm[0] ) || ( DateTimeUtil.ResetTime ( Z182SolicitudesFechaAlta ) != DateTimeUtil.ResetTime ( BC000O10_A182SolicitudesFechaAlta[0] ) ) || ( StringUtil.StrCmp(Z171SolicitudesNombre, BC000O10_A171SolicitudesNombre[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z172SolicitudesTelefono, BC000O10_A172SolicitudesTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z206SolicitudesMail, BC000O10_A206SolicitudesMail[0]) != 0 ) || ( StringUtil.StrCmp(Z173SolicitudesDireccion, BC000O10_A173SolicitudesDireccion[0]) != 0 ) || ( Z194SolicitudesAutoEnumerar != BC000O10_A194SolicitudesAutoEnumerar[0] ) || ( Z688SolicitudesLiqProf != BC000O10_A688SolicitudesLiqProf[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z689SolicitudesLiqProv != BC000O10_A689SolicitudesLiqProv[0] ) || ( Z212SolicitudesCotizacion != BC000O10_A212SolicitudesCotizacion[0] ) || ( StringUtil.StrCmp(Z210SolicitudServicioSolCoti, BC000O10_A210SolicitudServicioSolCoti[0]) != 0 ) || ( Z897SolicitudesDescuento != BC000O10_A897SolicitudesDescuento[0] ) || ( Z1016SolicitudesDescuentoCupon != BC000O10_A1016SolicitudesDescuentoCupon[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z796SolicitudesComisionMetodoPago != BC000O10_A796SolicitudesComisionMetodoPago[0] ) || ( StringUtil.StrCmp(Z201SolicitudesOtros1, BC000O10_A201SolicitudesOtros1[0]) != 0 ) || ( StringUtil.StrCmp(Z202SolicitudesOtros2, BC000O10_A202SolicitudesOtros2[0]) != 0 ) || ( StringUtil.StrCmp(Z203SolicitudesOtros3, BC000O10_A203SolicitudesOtros3[0]) != 0 ) || ( Z597SolicitudesUsrAlta != BC000O10_A597SolicitudesUsrAlta[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z598SolicitudesUsrActualizacion != BC000O10_A598SolicitudesUsrActualizacion[0] ) || ( Z204SolicitudesFechaActualizacion != BC000O10_A204SolicitudesFechaActualizacion[0] ) || ( DateTimeUtil.ResetTime ( Z184SolicitudesFechaInstalacion ) != DateTimeUtil.ResetTime ( BC000O10_A184SolicitudesFechaInstalacion[0] ) ) || ( StringUtil.StrCmp(Z183SolicitudesHoraInstalacion, BC000O10_A183SolicitudesHoraInstalacion[0]) != 0 ) || ( StringUtil.StrCmp(Z261SolicitudesNota, BC000O10_A261SolicitudesNota[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z262SolicitudesNotificacion, BC000O10_A262SolicitudesNotificacion[0]) != 0 ) || ( StringUtil.StrCmp(Z441SolicitudesPagado, BC000O10_A441SolicitudesPagado[0]) != 0 ) || ( Z527SolicitudServicioComProv != BC000O10_A527SolicitudServicioComProv[0] ) || ( Z528SolicitudServicioComProvP != BC000O10_A528SolicitudServicioComProvP[0] ) || ( Z530SolicitudServicioComALM != BC000O10_A530SolicitudServicioComALM[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z532SolicitudServicioComALMP != BC000O10_A532SolicitudServicioComALMP[0] ) || ( Z672SolicitudesCalComi != BC000O10_A672SolicitudesCalComi[0] ) || ( StringUtil.StrCmp(Z533ProveedorNombreAux, BC000O10_A533ProveedorNombreAux[0]) != 0 ) || ( StringUtil.StrCmp(Z600SolicitudesSubTipo, BC000O10_A600SolicitudesSubTipo[0]) != 0 ) || ( Z864SolicitudesCostoXZona != BC000O10_A864SolicitudesCostoXZona[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z972SolicitudesDuplicado != BC000O10_A972SolicitudesDuplicado[0] ) || ( Z992SolicitudesSerialArchivo != BC000O10_A992SolicitudesSerialArchivo[0] ) || ( Z1003SolicitudesCostoPresupuesto != BC000O10_A1003SolicitudesCostoPresupuesto[0] ) || ( StringUtil.StrCmp(Z1006SolicitudesURLOrigen, BC000O10_A1006SolicitudesURLOrigen[0]) != 0 ) || ( Z112DepartamentoId != BC000O10_A112DepartamentoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z114DepartamentoMunicipioId != BC000O10_A114DepartamentoMunicipioId[0] ) || ( Z110ZonasID != BC000O10_A110ZonasID[0] ) || ( Z128MetodoPagosID != BC000O10_A128MetodoPagosID[0] ) || ( Z735MudanzaId != BC000O10_A735MudanzaId[0] ) || ( Z133ProveedorID != BC000O10_A133ProveedorID[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z919STComerciosID != BC000O10_A919STComerciosID[0] ) || ( Z422PostulacionesId != BC000O10_A422PostulacionesId[0] ) || ( Z996CancelacionTipificacionId != BC000O10_A996CancelacionTipificacionId[0] ) || ( Z1013CuponId != BC000O10_A1013CuponId[0] ) || ( Z1020TicketId != BC000O10_A1020TicketId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z130EstadosSolTipo, BC000O10_A130EstadosSolTipo[0]) != 0 ) || ( Z131EstadosSolId != BC000O10_A131EstadosSolId[0] ) || ( Z669STMonedasId != BC000O10_A669STMonedasId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Solicitudes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
         /* Using cursor BC000O29 */
         pr_default.execute(27, new Object[] {n112DepartamentoId, A112DepartamentoId});
         if ( (pr_default.getStatus(27) == 103) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Departamento"}), "RecordIsLocked", 1, "");
            AnyError = 1;
            return  ;
         }
         if ( ! IsIns( ) )
         {
            if ( false || ( StringUtil.StrCmp(Z116PaisID, BC000O29_A116PaisID[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Departamento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0O30( )
      {
         BeforeValidate0O30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O30( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0O30( 0) ;
            CheckOptimisticConcurrency0O30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0O30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000O30 */
                     pr_default.execute(28, new Object[] {n438SolicitudServicioOrigenPago, A438SolicitudServicioOrigenPago, n866SolicitudesCostoXZComAlmP, A866SolicitudesCostoXZComAlmP, n865SolicitudesCostoXZComAlm, A865SolicitudesCostoXZComAlm, n182SolicitudesFechaAlta, A182SolicitudesFechaAlta, A171SolicitudesNombre, A172SolicitudesTelefono, n206SolicitudesMail, A206SolicitudesMail, A173SolicitudesDireccion, A194SolicitudesAutoEnumerar, n688SolicitudesLiqProf, A688SolicitudesLiqProf, n689SolicitudesLiqProv, A689SolicitudesLiqProv, A212SolicitudesCotizacion, A210SolicitudServicioSolCoti, n897SolicitudesDescuento, A897SolicitudesDescuento, A1016SolicitudesDescuentoCupon, A796SolicitudesComisionMetodoPago, A201SolicitudesOtros1, A202SolicitudesOtros2, A203SolicitudesOtros3, n597SolicitudesUsrAlta, A597SolicitudesUsrAlta, n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion, n204SolicitudesFechaActualizacion, A204SolicitudesFechaActualizacion, A184SolicitudesFechaInstalacion, A183SolicitudesHoraInstalacion, A205SolicitudesComentario, A261SolicitudesNota, A262SolicitudesNotificacion, n441SolicitudesPagado, A441SolicitudesPagado, n527SolicitudServicioComProv, A527SolicitudServicioComProv, n528SolicitudServicioComProvP, A528SolicitudServicioComProvP, n530SolicitudServicioComALM, A530SolicitudServicioComALM, n532SolicitudServicioComALMP, A532SolicitudServicioComALMP, A672SolicitudesCalComi, n533ProveedorNombreAux, A533ProveedorNombreAux, n600SolicitudesSubTipo, A600SolicitudesSubTipo, A864SolicitudesCostoXZona, n972SolicitudesDuplicado, A972SolicitudesDuplicado, A992SolicitudesSerialArchivo, n1003SolicitudesCostoPresupuesto, A1003SolicitudesCostoPresupuesto, n1006SolicitudesURLOrigen, A1006SolicitudesURLOrigen, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId, n110ZonasID, A110ZonasID, A128MetodoPagosID, n735MudanzaId, A735MudanzaId, A133ProveedorID, n919STComerciosID, A919STComerciosID, n422PostulacionesId, A422PostulacionesId, A996CancelacionTipificacionId, n1013CuponId, A1013CuponId, n1020TicketId, A1020TicketId, A130EstadosSolTipo, A131EstadosSolId, n669STMonedasId, A669STMonedasId});
                     A127SolicitudesID = BC000O30_A127SolicitudesID[0];
                     pr_default.close(28);
                     pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN10O30( ) ;
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0O30( ) ;
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
               Load0O30( ) ;
            }
            EndLevel0O30( ) ;
         }
         CloseExtendedTableCursors0O30( ) ;
      }

      protected void Update0O30( )
      {
         BeforeValidate0O30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O30( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0O30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000O31 */
                     pr_default.execute(29, new Object[] {n438SolicitudServicioOrigenPago, A438SolicitudServicioOrigenPago, n866SolicitudesCostoXZComAlmP, A866SolicitudesCostoXZComAlmP, n865SolicitudesCostoXZComAlm, A865SolicitudesCostoXZComAlm, n182SolicitudesFechaAlta, A182SolicitudesFechaAlta, A171SolicitudesNombre, A172SolicitudesTelefono, n206SolicitudesMail, A206SolicitudesMail, A173SolicitudesDireccion, A194SolicitudesAutoEnumerar, n688SolicitudesLiqProf, A688SolicitudesLiqProf, n689SolicitudesLiqProv, A689SolicitudesLiqProv, A212SolicitudesCotizacion, A210SolicitudServicioSolCoti, n897SolicitudesDescuento, A897SolicitudesDescuento, A1016SolicitudesDescuentoCupon, A796SolicitudesComisionMetodoPago, A201SolicitudesOtros1, A202SolicitudesOtros2, A203SolicitudesOtros3, n597SolicitudesUsrAlta, A597SolicitudesUsrAlta, n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion, n204SolicitudesFechaActualizacion, A204SolicitudesFechaActualizacion, A184SolicitudesFechaInstalacion, A183SolicitudesHoraInstalacion, A205SolicitudesComentario, A261SolicitudesNota, A262SolicitudesNotificacion, n441SolicitudesPagado, A441SolicitudesPagado, n527SolicitudServicioComProv, A527SolicitudServicioComProv, n528SolicitudServicioComProvP, A528SolicitudServicioComProvP, n530SolicitudServicioComALM, A530SolicitudServicioComALM, n532SolicitudServicioComALMP, A532SolicitudServicioComALMP, A672SolicitudesCalComi, n533ProveedorNombreAux, A533ProveedorNombreAux, n600SolicitudesSubTipo, A600SolicitudesSubTipo, A864SolicitudesCostoXZona, n972SolicitudesDuplicado, A972SolicitudesDuplicado, A992SolicitudesSerialArchivo, n1003SolicitudesCostoPresupuesto, A1003SolicitudesCostoPresupuesto, n1006SolicitudesURLOrigen, A1006SolicitudesURLOrigen, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId, n110ZonasID, A110ZonasID, A128MetodoPagosID, n735MudanzaId, A735MudanzaId, A133ProveedorID, n919STComerciosID, A919STComerciosID, n422PostulacionesId, A422PostulacionesId, A996CancelacionTipificacionId, n1013CuponId, A1013CuponId, n1020TicketId, A1020TicketId, A130EstadosSolTipo, A131EstadosSolId, n669STMonedasId, A669STMonedasId, A127SolicitudesID});
                     pr_default.close(29);
                     pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
                     if ( (pr_default.getStatus(29) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Solicitudes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0O30( ) ;
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN10O30( ) ;
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0O30( ) ;
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
            EndLevel0O30( ) ;
         }
         CloseExtendedTableCursors0O30( ) ;
      }

      protected void DeferredUpdate0O30( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0O30( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O30( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0O30( ) ;
            AfterConfirm0O30( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0O30( ) ;
               if ( AnyError == 0 )
               {
                  A992SolicitudesSerialArchivo = O992SolicitudesSerialArchivo;
                  ScanKeyStart0O144( ) ;
                  while ( RcdFound144 != 0 )
                  {
                     getByPrimaryKey0O144( ) ;
                     Delete0O144( ) ;
                     ScanKeyNext0O144( ) ;
                     O992SolicitudesSerialArchivo = A992SolicitudesSerialArchivo;
                  }
                  ScanKeyEnd0O144( ) ;
                  A211SolicitudServicioPFinal = O211SolicitudServicioPFinal;
                  A194SolicitudesAutoEnumerar = O194SolicitudesAutoEnumerar;
                  A174SolicitudesTotal = O174SolicitudesTotal;
                  A529SolicitudServicioComPro = O529SolicitudServicioComPro;
                  AV52OldSolicitudServicioPFinal = OV52OldSolicitudServicioPFinal;
                  ScanKeyStart0O31( ) ;
                  while ( RcdFound31 != 0 )
                  {
                     getByPrimaryKey0O31( ) ;
                     Delete0O31( ) ;
                     ScanKeyNext0O31( ) ;
                     O211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
                     O194SolicitudesAutoEnumerar = A194SolicitudesAutoEnumerar;
                     O174SolicitudesTotal = A174SolicitudesTotal;
                     O529SolicitudServicioComPro = A529SolicitudServicioComPro;
                     OV52OldSolicitudServicioPFinal = AV52OldSolicitudServicioPFinal;
                  }
                  ScanKeyEnd0O31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000O32 */
                     pr_default.execute(30, new Object[] {A127SolicitudesID});
                     pr_default.close(30);
                     pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN10O30( ) ;
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
         sMode30 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0O30( ) ;
         Gx_mode = sMode30;
      }

      protected void OnDeleteControls0O30( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV93Pgmname = "Solicitudes_BC";
            GetSolicitudesTotal( A127SolicitudesID) ;
            /* Using cursor BC000O13 */
            pr_default.execute(11, new Object[] {n112DepartamentoId, A112DepartamentoId});
            ZM0O30( 64) ;
            A116PaisID = BC000O13_A116PaisID[0];
            pr_default.close(27);
            /* Using cursor BC000O33 */
            pr_default.execute(31, new Object[] {n669STMonedasId, A669STMonedasId});
            A671STMonedasISO = BC000O33_A671STMonedasISO[0];
            pr_default.close(31);
            AV53OldSolicitudesCotizacion = O212SolicitudesCotizacion;
            /* Using cursor BC000O34 */
            pr_default.execute(32, new Object[] {n1013CuponId, A1013CuponId});
            A1014CuponPercent = BC000O34_A1014CuponPercent[0];
            pr_default.close(32);
            /* Using cursor BC000O35 */
            pr_default.execute(33, new Object[] {A130EstadosSolTipo, A131EstadosSolId});
            A132EstadosSolNombre = BC000O35_A132EstadosSolNombre[0];
            pr_default.close(33);
            AV73OldEstadosSolId = O131EstadosSolId;
            /* Using cursor BC000O36 */
            pr_default.execute(34, new Object[] {A128MetodoPagosID});
            A129MetodoPagosNombre = BC000O36_A129MetodoPagosNombre[0];
            pr_default.close(34);
            /* Using cursor BC000O37 */
            pr_default.execute(35, new Object[] {A133ProveedorID});
            A282ProveedorNombre = BC000O37_A282ProveedorNombre[0];
            A440ProveedorPagoDefault = BC000O37_A440ProveedorPagoDefault[0];
            pr_default.close(35);
            AV71oldProveedorID = O133ProveedorID;
            /* Using cursor BC000O38 */
            pr_default.execute(36, new Object[] {n919STComerciosID, A919STComerciosID});
            A923STComerciosNombre = BC000O38_A923STComerciosNombre[0];
            A924STComerciosEstado = BC000O38_A924STComerciosEstado[0];
            pr_default.close(36);
            if ( ( A532SolicitudServicioComALMP >= Convert.ToDecimal( 0 )) )
            {
               A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
            }
            else
            {
               if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP >= Convert.ToDecimal( 0 )) )
               {
                  A531SolicitudServicioComProP = (decimal)((100-A528SolicitudServicioComProvP)+(A532SolicitudServicioComALMP*-1));
               }
               else
               {
                  if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP < Convert.ToDecimal( 0 )) )
                  {
                     A531SolicitudServicioComProP = (decimal)(100+((A528SolicitudServicioComProvP+A532SolicitudServicioComALMP)*-1));
                  }
                  else
                  {
                     A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
                  }
               }
            }
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            AV52OldSolicitudServicioPFinal = O211SolicitudServicioPFinal;
            if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
            {
               A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
            }
            else
            {
               if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
               {
                  A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
               }
               else
               {
                  if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
                  {
                     A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                  }
                  else
                  {
                     A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                  }
               }
            }
            if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
            {
               A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
            }
            else
            {
               A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
            }
            if ( ( A866SolicitudesCostoXZComAlmP >= Convert.ToDecimal( 0 )) )
            {
               A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
            }
            else
            {
               if ( ( A866SolicitudesCostoXZComAlmP < Convert.ToDecimal( 0 )) )
               {
                  A868SolicitudesCostoXZComProfP = (decimal)(100+(A866SolicitudesCostoXZComAlmP*-1));
               }
               else
               {
                  A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
               }
            }
            /* Using cursor BC000O39 */
            pr_default.execute(37, new Object[] {n735MudanzaId, A735MudanzaId});
            A738MudanzaFechaServicio = BC000O39_A738MudanzaFechaServicio[0];
            A740MudanzaDireccionOrigen = BC000O39_A740MudanzaDireccionOrigen[0];
            A741MudanzaDireccionDestino = BC000O39_A741MudanzaDireccionDestino[0];
            pr_default.close(37);
            /* Using cursor BC000O40 */
            pr_default.execute(38, new Object[] {A996CancelacionTipificacionId});
            A997CancelacionTipificacionDescrip = BC000O40_A997CancelacionTipificacionDescrip[0];
            pr_default.close(38);
            /* Using cursor BC000O41 */
            pr_default.execute(39, new Object[] {n1020TicketId, A1020TicketId});
            A1024TicketComentario = BC000O41_A1024TicketComentario[0];
            A1026TicketAdjunto = BC000O41_A1026TicketAdjunto[0];
            A1030TicketEstado = BC000O41_A1030TicketEstado[0];
            A1023TicketSolicitudId = BC000O41_A1023TicketSolicitudId[0];
            A1021TicketMotivoId = BC000O41_A1021TicketMotivoId[0];
            pr_default.close(39);
            /* Using cursor BC000O42 */
            pr_default.execute(40, new Object[] {A1021TicketMotivoId});
            A1022TicketMotivoDescripcion = BC000O42_A1022TicketMotivoDescripcion[0];
            pr_default.close(40);
            if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A116PaisID)) && ( Gx_BScreen == 0 ) )
            {
               A116PaisID = context.GetMessage( "UY", "");
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000O43 */
            pr_default.execute(41, new Object[] {A127SolicitudesID});
            if ( (pr_default.getStatus(41) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Relaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(41);
         }
      }

      protected void ProcessNestedLevel0O31( )
      {
         s211SolicitudServicioPFinal = O211SolicitudServicioPFinal;
         s194SolicitudesAutoEnumerar = O194SolicitudesAutoEnumerar;
         s174SolicitudesTotal = O174SolicitudesTotal;
         s529SolicitudServicioComPro = O529SolicitudServicioComPro;
         sV52OldSolicitudServicioPFinal = OV52OldSolicitudServicioPFinal;
         nGXsfl_31_idx = 0;
         while ( nGXsfl_31_idx < bcSolicitudes.gxTpr_Items.Count )
         {
            ReadRow0O31( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound31 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_31 != 0 ) )
            {
               standaloneNotModal0O31( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0O31( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0O31( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0O31( ) ;
                  }
               }
               O211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
               O194SolicitudesAutoEnumerar = A194SolicitudesAutoEnumerar;
               O174SolicitudesTotal = A174SolicitudesTotal;
               O529SolicitudServicioComPro = A529SolicitudServicioComPro;
               OV52OldSolicitudServicioPFinal = AV52OldSolicitudServicioPFinal;
            }
            KeyVarsToRow31( ((SdtSolicitudes_Items)bcSolicitudes.gxTpr_Items.Item(nGXsfl_31_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_31_idx = 0;
            while ( nGXsfl_31_idx < bcSolicitudes.gxTpr_Items.Count )
            {
               ReadRow0O31( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound31 == 0 )
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
                  bcSolicitudes.gxTpr_Items.RemoveElement(nGXsfl_31_idx);
                  nGXsfl_31_idx = (int)(nGXsfl_31_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0O31( ) ;
                  VarsToRow31( ((SdtSolicitudes_Items)bcSolicitudes.gxTpr_Items.Item(nGXsfl_31_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0O31( ) ;
         if ( AnyError != 0 )
         {
            O211SolicitudServicioPFinal = s211SolicitudServicioPFinal;
            O194SolicitudesAutoEnumerar = s194SolicitudesAutoEnumerar;
            O174SolicitudesTotal = s174SolicitudesTotal;
            O529SolicitudServicioComPro = s529SolicitudServicioComPro;
            OV52OldSolicitudServicioPFinal = sV52OldSolicitudServicioPFinal;
         }
         nRcdExists_31 = 0;
         nIsMod_31 = 0;
      }

      protected void ProcessNestedLevel0O144( )
      {
         s992SolicitudesSerialArchivo = O992SolicitudesSerialArchivo;
         nGXsfl_144_idx = 0;
         while ( nGXsfl_144_idx < bcSolicitudes.gxTpr_Archivo.Count )
         {
            ReadRow0O144( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound144 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_144 != 0 ) )
            {
               standaloneNotModal0O144( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0O144( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0O144( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0O144( ) ;
                  }
               }
               O992SolicitudesSerialArchivo = A992SolicitudesSerialArchivo;
            }
            KeyVarsToRow144( ((SdtSolicitudes_Archivo)bcSolicitudes.gxTpr_Archivo.Item(nGXsfl_144_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_144_idx = 0;
            while ( nGXsfl_144_idx < bcSolicitudes.gxTpr_Archivo.Count )
            {
               ReadRow0O144( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound144 == 0 )
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
                  bcSolicitudes.gxTpr_Archivo.RemoveElement(nGXsfl_144_idx);
                  nGXsfl_144_idx = (int)(nGXsfl_144_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0O144( ) ;
                  VarsToRow144( ((SdtSolicitudes_Archivo)bcSolicitudes.gxTpr_Archivo.Item(nGXsfl_144_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0O144( ) ;
         if ( AnyError != 0 )
         {
            O992SolicitudesSerialArchivo = s992SolicitudesSerialArchivo;
         }
         nRcdExists_144 = 0;
         nIsMod_144 = 0;
      }

      protected void ProcessLevel0O30( )
      {
         /* Save parent mode. */
         sMode30 = Gx_mode;
         ProcessNestedLevel0O31( ) ;
         ProcessNestedLevel0O144( ) ;
         if ( AnyError != 0 )
         {
            O211SolicitudServicioPFinal = s211SolicitudServicioPFinal;
            O194SolicitudesAutoEnumerar = s194SolicitudesAutoEnumerar;
            O174SolicitudesTotal = s174SolicitudesTotal;
            O529SolicitudServicioComPro = s529SolicitudServicioComPro;
            OV52OldSolicitudServicioPFinal = sV52OldSolicitudServicioPFinal;
            O992SolicitudesSerialArchivo = s992SolicitudesSerialArchivo;
         }
         /* Restore parent mode. */
         Gx_mode = sMode30;
         /* ' Update level parameters */
         /* Using cursor BC000O44 */
         pr_default.execute(42, new Object[] {A992SolicitudesSerialArchivo, A194SolicitudesAutoEnumerar, A127SolicitudesID});
         pr_default.close(42);
         pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
      }

      protected void UpdateTablesN10O30( )
      {
         /* Using cursor BC000O45 */
         pr_default.execute(43, new Object[] {A116PaisID, n112DepartamentoId, A112DepartamentoId});
         pr_default.close(43);
         pr_default.SmartCacheProvider.SetUpdated("Departamento");
      }

      protected void EndLevel0O30( )
      {
         pr_default.close(8);
         pr_default.close(27);
         if ( AnyError == 0 )
         {
            BeforeComplete0O30( ) ;
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

      public void ScanKeyStart0O30( )
      {
         /* Scan By routine */
         /* Using cursor BC000O46 */
         pr_default.execute(44, new Object[] {A127SolicitudesID});
         RcdFound30 = 0;
         if ( (pr_default.getStatus(44) != 101) )
         {
            RcdFound30 = 1;
            A127SolicitudesID = BC000O46_A127SolicitudesID[0];
            A438SolicitudServicioOrigenPago = BC000O46_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = BC000O46_n438SolicitudServicioOrigenPago[0];
            A866SolicitudesCostoXZComAlmP = BC000O46_A866SolicitudesCostoXZComAlmP[0];
            n866SolicitudesCostoXZComAlmP = BC000O46_n866SolicitudesCostoXZComAlmP[0];
            A865SolicitudesCostoXZComAlm = BC000O46_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = BC000O46_n865SolicitudesCostoXZComAlm[0];
            A182SolicitudesFechaAlta = BC000O46_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = BC000O46_n182SolicitudesFechaAlta[0];
            A171SolicitudesNombre = BC000O46_A171SolicitudesNombre[0];
            A172SolicitudesTelefono = BC000O46_A172SolicitudesTelefono[0];
            A206SolicitudesMail = BC000O46_A206SolicitudesMail[0];
            n206SolicitudesMail = BC000O46_n206SolicitudesMail[0];
            A173SolicitudesDireccion = BC000O46_A173SolicitudesDireccion[0];
            A194SolicitudesAutoEnumerar = BC000O46_A194SolicitudesAutoEnumerar[0];
            A671STMonedasISO = BC000O46_A671STMonedasISO[0];
            A688SolicitudesLiqProf = BC000O46_A688SolicitudesLiqProf[0];
            n688SolicitudesLiqProf = BC000O46_n688SolicitudesLiqProf[0];
            A689SolicitudesLiqProv = BC000O46_A689SolicitudesLiqProv[0];
            n689SolicitudesLiqProv = BC000O46_n689SolicitudesLiqProv[0];
            A212SolicitudesCotizacion = BC000O46_A212SolicitudesCotizacion[0];
            A210SolicitudServicioSolCoti = BC000O46_A210SolicitudServicioSolCoti[0];
            A897SolicitudesDescuento = BC000O46_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = BC000O46_n897SolicitudesDescuento[0];
            A1014CuponPercent = BC000O46_A1014CuponPercent[0];
            A1016SolicitudesDescuentoCupon = BC000O46_A1016SolicitudesDescuentoCupon[0];
            A796SolicitudesComisionMetodoPago = BC000O46_A796SolicitudesComisionMetodoPago[0];
            A132EstadosSolNombre = BC000O46_A132EstadosSolNombre[0];
            A201SolicitudesOtros1 = BC000O46_A201SolicitudesOtros1[0];
            A202SolicitudesOtros2 = BC000O46_A202SolicitudesOtros2[0];
            A203SolicitudesOtros3 = BC000O46_A203SolicitudesOtros3[0];
            A597SolicitudesUsrAlta = BC000O46_A597SolicitudesUsrAlta[0];
            n597SolicitudesUsrAlta = BC000O46_n597SolicitudesUsrAlta[0];
            A598SolicitudesUsrActualizacion = BC000O46_A598SolicitudesUsrActualizacion[0];
            n598SolicitudesUsrActualizacion = BC000O46_n598SolicitudesUsrActualizacion[0];
            A204SolicitudesFechaActualizacion = BC000O46_A204SolicitudesFechaActualizacion[0];
            n204SolicitudesFechaActualizacion = BC000O46_n204SolicitudesFechaActualizacion[0];
            A184SolicitudesFechaInstalacion = BC000O46_A184SolicitudesFechaInstalacion[0];
            A183SolicitudesHoraInstalacion = BC000O46_A183SolicitudesHoraInstalacion[0];
            A205SolicitudesComentario = BC000O46_A205SolicitudesComentario[0];
            A129MetodoPagosNombre = BC000O46_A129MetodoPagosNombre[0];
            A261SolicitudesNota = BC000O46_A261SolicitudesNota[0];
            A262SolicitudesNotificacion = BC000O46_A262SolicitudesNotificacion[0];
            A282ProveedorNombre = BC000O46_A282ProveedorNombre[0];
            A440ProveedorPagoDefault = BC000O46_A440ProveedorPagoDefault[0];
            A923STComerciosNombre = BC000O46_A923STComerciosNombre[0];
            A924STComerciosEstado = BC000O46_A924STComerciosEstado[0];
            A441SolicitudesPagado = BC000O46_A441SolicitudesPagado[0];
            n441SolicitudesPagado = BC000O46_n441SolicitudesPagado[0];
            A527SolicitudServicioComProv = BC000O46_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = BC000O46_n527SolicitudServicioComProv[0];
            A528SolicitudServicioComProvP = BC000O46_A528SolicitudServicioComProvP[0];
            n528SolicitudServicioComProvP = BC000O46_n528SolicitudServicioComProvP[0];
            A530SolicitudServicioComALM = BC000O46_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = BC000O46_n530SolicitudServicioComALM[0];
            A532SolicitudServicioComALMP = BC000O46_A532SolicitudServicioComALMP[0];
            n532SolicitudServicioComALMP = BC000O46_n532SolicitudServicioComALMP[0];
            A672SolicitudesCalComi = BC000O46_A672SolicitudesCalComi[0];
            A533ProveedorNombreAux = BC000O46_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = BC000O46_n533ProveedorNombreAux[0];
            A600SolicitudesSubTipo = BC000O46_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = BC000O46_n600SolicitudesSubTipo[0];
            A864SolicitudesCostoXZona = BC000O46_A864SolicitudesCostoXZona[0];
            A738MudanzaFechaServicio = BC000O46_A738MudanzaFechaServicio[0];
            A740MudanzaDireccionOrigen = BC000O46_A740MudanzaDireccionOrigen[0];
            A741MudanzaDireccionDestino = BC000O46_A741MudanzaDireccionDestino[0];
            A972SolicitudesDuplicado = BC000O46_A972SolicitudesDuplicado[0];
            n972SolicitudesDuplicado = BC000O46_n972SolicitudesDuplicado[0];
            A992SolicitudesSerialArchivo = BC000O46_A992SolicitudesSerialArchivo[0];
            A997CancelacionTipificacionDescrip = BC000O46_A997CancelacionTipificacionDescrip[0];
            A1003SolicitudesCostoPresupuesto = BC000O46_A1003SolicitudesCostoPresupuesto[0];
            n1003SolicitudesCostoPresupuesto = BC000O46_n1003SolicitudesCostoPresupuesto[0];
            A1006SolicitudesURLOrigen = BC000O46_A1006SolicitudesURLOrigen[0];
            n1006SolicitudesURLOrigen = BC000O46_n1006SolicitudesURLOrigen[0];
            A1022TicketMotivoDescripcion = BC000O46_A1022TicketMotivoDescripcion[0];
            A1024TicketComentario = BC000O46_A1024TicketComentario[0];
            A1026TicketAdjunto = BC000O46_A1026TicketAdjunto[0];
            A1030TicketEstado = BC000O46_A1030TicketEstado[0];
            A1023TicketSolicitudId = BC000O46_A1023TicketSolicitudId[0];
            A112DepartamentoId = BC000O46_A112DepartamentoId[0];
            n112DepartamentoId = BC000O46_n112DepartamentoId[0];
            A114DepartamentoMunicipioId = BC000O46_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = BC000O46_n114DepartamentoMunicipioId[0];
            A110ZonasID = BC000O46_A110ZonasID[0];
            n110ZonasID = BC000O46_n110ZonasID[0];
            A128MetodoPagosID = BC000O46_A128MetodoPagosID[0];
            A735MudanzaId = BC000O46_A735MudanzaId[0];
            n735MudanzaId = BC000O46_n735MudanzaId[0];
            A133ProveedorID = BC000O46_A133ProveedorID[0];
            A919STComerciosID = BC000O46_A919STComerciosID[0];
            n919STComerciosID = BC000O46_n919STComerciosID[0];
            A422PostulacionesId = BC000O46_A422PostulacionesId[0];
            n422PostulacionesId = BC000O46_n422PostulacionesId[0];
            A996CancelacionTipificacionId = BC000O46_A996CancelacionTipificacionId[0];
            A1013CuponId = BC000O46_A1013CuponId[0];
            n1013CuponId = BC000O46_n1013CuponId[0];
            A1020TicketId = BC000O46_A1020TicketId[0];
            n1020TicketId = BC000O46_n1020TicketId[0];
            A130EstadosSolTipo = BC000O46_A130EstadosSolTipo[0];
            A131EstadosSolId = BC000O46_A131EstadosSolId[0];
            A669STMonedasId = BC000O46_A669STMonedasId[0];
            n669STMonedasId = BC000O46_n669STMonedasId[0];
            A116PaisID = BC000O46_A116PaisID[0];
            A1021TicketMotivoId = BC000O46_A1021TicketMotivoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0O30( )
      {
         /* Scan next routine */
         pr_default.readNext(44);
         RcdFound30 = 0;
         ScanKeyLoad0O30( ) ;
      }

      protected void ScanKeyLoad0O30( )
      {
         sMode30 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(44) != 101) )
         {
            RcdFound30 = 1;
            A127SolicitudesID = BC000O46_A127SolicitudesID[0];
            A438SolicitudServicioOrigenPago = BC000O46_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = BC000O46_n438SolicitudServicioOrigenPago[0];
            A866SolicitudesCostoXZComAlmP = BC000O46_A866SolicitudesCostoXZComAlmP[0];
            n866SolicitudesCostoXZComAlmP = BC000O46_n866SolicitudesCostoXZComAlmP[0];
            A865SolicitudesCostoXZComAlm = BC000O46_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = BC000O46_n865SolicitudesCostoXZComAlm[0];
            A182SolicitudesFechaAlta = BC000O46_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = BC000O46_n182SolicitudesFechaAlta[0];
            A171SolicitudesNombre = BC000O46_A171SolicitudesNombre[0];
            A172SolicitudesTelefono = BC000O46_A172SolicitudesTelefono[0];
            A206SolicitudesMail = BC000O46_A206SolicitudesMail[0];
            n206SolicitudesMail = BC000O46_n206SolicitudesMail[0];
            A173SolicitudesDireccion = BC000O46_A173SolicitudesDireccion[0];
            A194SolicitudesAutoEnumerar = BC000O46_A194SolicitudesAutoEnumerar[0];
            A671STMonedasISO = BC000O46_A671STMonedasISO[0];
            A688SolicitudesLiqProf = BC000O46_A688SolicitudesLiqProf[0];
            n688SolicitudesLiqProf = BC000O46_n688SolicitudesLiqProf[0];
            A689SolicitudesLiqProv = BC000O46_A689SolicitudesLiqProv[0];
            n689SolicitudesLiqProv = BC000O46_n689SolicitudesLiqProv[0];
            A212SolicitudesCotizacion = BC000O46_A212SolicitudesCotizacion[0];
            A210SolicitudServicioSolCoti = BC000O46_A210SolicitudServicioSolCoti[0];
            A897SolicitudesDescuento = BC000O46_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = BC000O46_n897SolicitudesDescuento[0];
            A1014CuponPercent = BC000O46_A1014CuponPercent[0];
            A1016SolicitudesDescuentoCupon = BC000O46_A1016SolicitudesDescuentoCupon[0];
            A796SolicitudesComisionMetodoPago = BC000O46_A796SolicitudesComisionMetodoPago[0];
            A132EstadosSolNombre = BC000O46_A132EstadosSolNombre[0];
            A201SolicitudesOtros1 = BC000O46_A201SolicitudesOtros1[0];
            A202SolicitudesOtros2 = BC000O46_A202SolicitudesOtros2[0];
            A203SolicitudesOtros3 = BC000O46_A203SolicitudesOtros3[0];
            A597SolicitudesUsrAlta = BC000O46_A597SolicitudesUsrAlta[0];
            n597SolicitudesUsrAlta = BC000O46_n597SolicitudesUsrAlta[0];
            A598SolicitudesUsrActualizacion = BC000O46_A598SolicitudesUsrActualizacion[0];
            n598SolicitudesUsrActualizacion = BC000O46_n598SolicitudesUsrActualizacion[0];
            A204SolicitudesFechaActualizacion = BC000O46_A204SolicitudesFechaActualizacion[0];
            n204SolicitudesFechaActualizacion = BC000O46_n204SolicitudesFechaActualizacion[0];
            A184SolicitudesFechaInstalacion = BC000O46_A184SolicitudesFechaInstalacion[0];
            A183SolicitudesHoraInstalacion = BC000O46_A183SolicitudesHoraInstalacion[0];
            A205SolicitudesComentario = BC000O46_A205SolicitudesComentario[0];
            A129MetodoPagosNombre = BC000O46_A129MetodoPagosNombre[0];
            A261SolicitudesNota = BC000O46_A261SolicitudesNota[0];
            A262SolicitudesNotificacion = BC000O46_A262SolicitudesNotificacion[0];
            A282ProveedorNombre = BC000O46_A282ProveedorNombre[0];
            A440ProveedorPagoDefault = BC000O46_A440ProveedorPagoDefault[0];
            A923STComerciosNombre = BC000O46_A923STComerciosNombre[0];
            A924STComerciosEstado = BC000O46_A924STComerciosEstado[0];
            A441SolicitudesPagado = BC000O46_A441SolicitudesPagado[0];
            n441SolicitudesPagado = BC000O46_n441SolicitudesPagado[0];
            A527SolicitudServicioComProv = BC000O46_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = BC000O46_n527SolicitudServicioComProv[0];
            A528SolicitudServicioComProvP = BC000O46_A528SolicitudServicioComProvP[0];
            n528SolicitudServicioComProvP = BC000O46_n528SolicitudServicioComProvP[0];
            A530SolicitudServicioComALM = BC000O46_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = BC000O46_n530SolicitudServicioComALM[0];
            A532SolicitudServicioComALMP = BC000O46_A532SolicitudServicioComALMP[0];
            n532SolicitudServicioComALMP = BC000O46_n532SolicitudServicioComALMP[0];
            A672SolicitudesCalComi = BC000O46_A672SolicitudesCalComi[0];
            A533ProveedorNombreAux = BC000O46_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = BC000O46_n533ProveedorNombreAux[0];
            A600SolicitudesSubTipo = BC000O46_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = BC000O46_n600SolicitudesSubTipo[0];
            A864SolicitudesCostoXZona = BC000O46_A864SolicitudesCostoXZona[0];
            A738MudanzaFechaServicio = BC000O46_A738MudanzaFechaServicio[0];
            A740MudanzaDireccionOrigen = BC000O46_A740MudanzaDireccionOrigen[0];
            A741MudanzaDireccionDestino = BC000O46_A741MudanzaDireccionDestino[0];
            A972SolicitudesDuplicado = BC000O46_A972SolicitudesDuplicado[0];
            n972SolicitudesDuplicado = BC000O46_n972SolicitudesDuplicado[0];
            A992SolicitudesSerialArchivo = BC000O46_A992SolicitudesSerialArchivo[0];
            A997CancelacionTipificacionDescrip = BC000O46_A997CancelacionTipificacionDescrip[0];
            A1003SolicitudesCostoPresupuesto = BC000O46_A1003SolicitudesCostoPresupuesto[0];
            n1003SolicitudesCostoPresupuesto = BC000O46_n1003SolicitudesCostoPresupuesto[0];
            A1006SolicitudesURLOrigen = BC000O46_A1006SolicitudesURLOrigen[0];
            n1006SolicitudesURLOrigen = BC000O46_n1006SolicitudesURLOrigen[0];
            A1022TicketMotivoDescripcion = BC000O46_A1022TicketMotivoDescripcion[0];
            A1024TicketComentario = BC000O46_A1024TicketComentario[0];
            A1026TicketAdjunto = BC000O46_A1026TicketAdjunto[0];
            A1030TicketEstado = BC000O46_A1030TicketEstado[0];
            A1023TicketSolicitudId = BC000O46_A1023TicketSolicitudId[0];
            A112DepartamentoId = BC000O46_A112DepartamentoId[0];
            n112DepartamentoId = BC000O46_n112DepartamentoId[0];
            A114DepartamentoMunicipioId = BC000O46_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = BC000O46_n114DepartamentoMunicipioId[0];
            A110ZonasID = BC000O46_A110ZonasID[0];
            n110ZonasID = BC000O46_n110ZonasID[0];
            A128MetodoPagosID = BC000O46_A128MetodoPagosID[0];
            A735MudanzaId = BC000O46_A735MudanzaId[0];
            n735MudanzaId = BC000O46_n735MudanzaId[0];
            A133ProveedorID = BC000O46_A133ProveedorID[0];
            A919STComerciosID = BC000O46_A919STComerciosID[0];
            n919STComerciosID = BC000O46_n919STComerciosID[0];
            A422PostulacionesId = BC000O46_A422PostulacionesId[0];
            n422PostulacionesId = BC000O46_n422PostulacionesId[0];
            A996CancelacionTipificacionId = BC000O46_A996CancelacionTipificacionId[0];
            A1013CuponId = BC000O46_A1013CuponId[0];
            n1013CuponId = BC000O46_n1013CuponId[0];
            A1020TicketId = BC000O46_A1020TicketId[0];
            n1020TicketId = BC000O46_n1020TicketId[0];
            A130EstadosSolTipo = BC000O46_A130EstadosSolTipo[0];
            A131EstadosSolId = BC000O46_A131EstadosSolId[0];
            A669STMonedasId = BC000O46_A669STMonedasId[0];
            n669STMonedasId = BC000O46_n669STMonedasId[0];
            A116PaisID = BC000O46_A116PaisID[0];
            A1021TicketMotivoId = BC000O46_A1021TicketMotivoId[0];
         }
         Gx_mode = sMode30;
      }

      protected void ScanKeyEnd0O30( )
      {
         pr_default.close(44);
      }

      protected void AfterConfirm0O30( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0O30( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0O30( )
      {
         /* Before Update Rules */
         new actualizarfechamudanza(context ).execute(  A127SolicitudesID,  A735MudanzaId,  A184SolicitudesFechaInstalacion) ;
      }

      protected void BeforeDelete0O30( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0O30( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0O30( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0O30( )
      {
      }

      protected void ZM0O31( short GX_JID )
      {
         if ( ( GX_JID == 78 ) || ( GX_JID == 0 ) )
         {
            Z177SolicitudesItemsCantidad = A177SolicitudesItemsCantidad;
            Z180SolicitudItemsComision = A180SolicitudItemsComision;
            Z178SolicitudItemsSR = A178SolicitudItemsSR;
            Z179SolicitudItemsComisionTipo = A179SolicitudItemsComisionTipo;
            Z176SolicitudesItemsPrecioFinal = A176SolicitudesItemsPrecioFinal;
            Z521SolicitudesItemsComiProv = A521SolicitudesItemsComiProv;
            Z524SolicitudesItemsComiProvP = A524SolicitudesItemsComiProvP;
            Z523SolicitudesItemsComiALM = A523SolicitudesItemsComiALM;
            Z526SolicitudesItemsComiALMP = A526SolicitudesItemsComiALMP;
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z135InventarioId = A135InventarioId;
            Z1002SolicitudesPrecioEsFreezado = A1002SolicitudesPrecioEsFreezado;
            Z175SolicitudesItemsPrecioInstalac = A175SolicitudesItemsPrecioInstalac;
            Z522SolicitudesItemsComiProf = A522SolicitudesItemsComiProf;
            Z525SolicitudesItemsComiProfP = A525SolicitudesItemsComiProfP;
         }
         if ( ( GX_JID == 79 ) || ( GX_JID == 0 ) )
         {
            Z123RubrosEstado = A123RubrosEstado;
            Z1002SolicitudesPrecioEsFreezado = A1002SolicitudesPrecioEsFreezado;
            Z175SolicitudesItemsPrecioInstalac = A175SolicitudesItemsPrecioInstalac;
            Z522SolicitudesItemsComiProf = A522SolicitudesItemsComiProf;
            Z525SolicitudesItemsComiProfP = A525SolicitudesItemsComiProfP;
         }
         if ( ( GX_JID == 80 ) || ( GX_JID == 0 ) )
         {
            Z118MonedaId = A118MonedaId;
            Z1002SolicitudesPrecioEsFreezado = A1002SolicitudesPrecioEsFreezado;
            Z175SolicitudesItemsPrecioInstalac = A175SolicitudesItemsPrecioInstalac;
            Z522SolicitudesItemsComiProf = A522SolicitudesItemsComiProf;
            Z525SolicitudesItemsComiProfP = A525SolicitudesItemsComiProfP;
         }
         if ( ( GX_JID == 81 ) || ( GX_JID == 0 ) )
         {
            Z136InventarioNombre = A136InventarioNombre;
            Z181InventarioPrecioFinal = A181InventarioPrecioFinal;
            Z801InventarioConsumoProductivo = A801InventarioConsumoProductivo;
            Z107EstadosTipo = A107EstadosTipo;
            Z108EstadosGenericosId = A108EstadosGenericosId;
            Z1002SolicitudesPrecioEsFreezado = A1002SolicitudesPrecioEsFreezado;
            Z175SolicitudesItemsPrecioInstalac = A175SolicitudesItemsPrecioInstalac;
            Z522SolicitudesItemsComiProf = A522SolicitudesItemsComiProf;
            Z525SolicitudesItemsComiProfP = A525SolicitudesItemsComiProfP;
         }
         if ( ( GX_JID == 82 ) || ( GX_JID == 0 ) )
         {
            Z119MonedaISOSimbolo = A119MonedaISOSimbolo;
            Z1002SolicitudesPrecioEsFreezado = A1002SolicitudesPrecioEsFreezado;
            Z175SolicitudesItemsPrecioInstalac = A175SolicitudesItemsPrecioInstalac;
            Z522SolicitudesItemsComiProf = A522SolicitudesItemsComiProf;
            Z525SolicitudesItemsComiProfP = A525SolicitudesItemsComiProfP;
         }
         if ( GX_JID == -78 )
         {
            Z127SolicitudesID = A127SolicitudesID;
            Z134SolicitudesItemsID = A134SolicitudesItemsID;
            Z177SolicitudesItemsCantidad = A177SolicitudesItemsCantidad;
            Z180SolicitudItemsComision = A180SolicitudItemsComision;
            Z178SolicitudItemsSR = A178SolicitudItemsSR;
            Z179SolicitudItemsComisionTipo = A179SolicitudItemsComisionTipo;
            Z176SolicitudesItemsPrecioFinal = A176SolicitudesItemsPrecioFinal;
            Z521SolicitudesItemsComiProv = A521SolicitudesItemsComiProv;
            Z524SolicitudesItemsComiProvP = A524SolicitudesItemsComiProvP;
            Z523SolicitudesItemsComiALM = A523SolicitudesItemsComiALM;
            Z526SolicitudesItemsComiALMP = A526SolicitudesItemsComiALMP;
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z135InventarioId = A135InventarioId;
            Z168RubrosImagen = A168RubrosImagen;
            Z40000RubrosImagen_GXI = A40000RubrosImagen_GXI;
            Z123RubrosEstado = A123RubrosEstado;
            Z118MonedaId = A118MonedaId;
            Z119MonedaISOSimbolo = A119MonedaISOSimbolo;
            Z136InventarioNombre = A136InventarioNombre;
            Z189InventarioImagen = A189InventarioImagen;
            Z40001InventarioImagen_GXI = A40001InventarioImagen_GXI;
            Z181InventarioPrecioFinal = A181InventarioPrecioFinal;
            Z801InventarioConsumoProductivo = A801InventarioConsumoProductivo;
            Z107EstadosTipo = A107EstadosTipo;
            Z108EstadosGenericosId = A108EstadosGenericosId;
         }
      }

      protected void standaloneNotModal0O31( )
      {
      }

      protected void standaloneModal0O31( )
      {
         if ( IsIns( )  )
         {
            A194SolicitudesAutoEnumerar = (short)(O194SolicitudesAutoEnumerar+1);
         }
         if ( IsIns( )  )
         {
            A134SolicitudesItemsID = A194SolicitudesAutoEnumerar;
         }
         if ( IsIns( )  && (0==A177SolicitudesItemsCantidad) && ( Gx_BScreen == 0 ) )
         {
            A177SolicitudesItemsCantidad = 1;
         }
         A525SolicitudesItemsComiProfP = (decimal)(100-(A524SolicitudesItemsComiProvP+A526SolicitudesItemsComiALMP));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV52OldSolicitudServicioPFinal = O211SolicitudServicioPFinal;
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
            {
               A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
            }
            else
            {
               if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
               {
                  A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
               }
               else
               {
                  if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
                  {
                     A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                  }
                  else
                  {
                     A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                  }
               }
            }
         }
      }

      protected void Load0O31( )
      {
         /* Using cursor BC000O47 */
         pr_default.execute(45, new Object[] {A127SolicitudesID, A134SolicitudesItemsID});
         if ( (pr_default.getStatus(45) != 101) )
         {
            RcdFound31 = 1;
            A177SolicitudesItemsCantidad = BC000O47_A177SolicitudesItemsCantidad[0];
            A180SolicitudItemsComision = BC000O47_A180SolicitudItemsComision[0];
            A178SolicitudItemsSR = BC000O47_A178SolicitudItemsSR[0];
            A179SolicitudItemsComisionTipo = BC000O47_A179SolicitudItemsComisionTipo[0];
            A40000RubrosImagen_GXI = BC000O47_A40000RubrosImagen_GXI[0];
            A123RubrosEstado = BC000O47_A123RubrosEstado[0];
            n123RubrosEstado = BC000O47_n123RubrosEstado[0];
            A136InventarioNombre = BC000O47_A136InventarioNombre[0];
            A40001InventarioImagen_GXI = BC000O47_A40001InventarioImagen_GXI[0];
            A181InventarioPrecioFinal = BC000O47_A181InventarioPrecioFinal[0];
            A801InventarioConsumoProductivo = BC000O47_A801InventarioConsumoProductivo[0];
            A176SolicitudesItemsPrecioFinal = BC000O47_A176SolicitudesItemsPrecioFinal[0];
            n176SolicitudesItemsPrecioFinal = BC000O47_n176SolicitudesItemsPrecioFinal[0];
            A119MonedaISOSimbolo = BC000O47_A119MonedaISOSimbolo[0];
            A521SolicitudesItemsComiProv = BC000O47_A521SolicitudesItemsComiProv[0];
            n521SolicitudesItemsComiProv = BC000O47_n521SolicitudesItemsComiProv[0];
            A524SolicitudesItemsComiProvP = BC000O47_A524SolicitudesItemsComiProvP[0];
            n524SolicitudesItemsComiProvP = BC000O47_n524SolicitudesItemsComiProvP[0];
            A523SolicitudesItemsComiALM = BC000O47_A523SolicitudesItemsComiALM[0];
            n523SolicitudesItemsComiALM = BC000O47_n523SolicitudesItemsComiALM[0];
            A526SolicitudesItemsComiALMP = BC000O47_A526SolicitudesItemsComiALMP[0];
            n526SolicitudesItemsComiALMP = BC000O47_n526SolicitudesItemsComiALMP[0];
            A121RubrosId = BC000O47_A121RubrosId[0];
            A137MedidasID = BC000O47_A137MedidasID[0];
            A135InventarioId = BC000O47_A135InventarioId[0];
            A118MonedaId = BC000O47_A118MonedaId[0];
            A107EstadosTipo = BC000O47_A107EstadosTipo[0];
            A108EstadosGenericosId = BC000O47_A108EstadosGenericosId[0];
            A168RubrosImagen = BC000O47_A168RubrosImagen[0];
            A189InventarioImagen = BC000O47_A189InventarioImagen[0];
            ZM0O31( -78) ;
         }
         pr_default.close(45);
         OnLoadActions0O31( ) ;
      }

      protected void OnLoadActions0O31( )
      {
         GXt_boolean4 = A1002SolicitudesPrecioEsFreezado;
         new ofreezado(context ).execute(  A133ProveedorID,  A121RubrosId,  A137MedidasID,  A135InventarioId,  A118MonedaId, out  GXt_boolean4) ;
         A1002SolicitudesPrecioEsFreezado = GXt_boolean4;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A178SolicitudItemsSR)) || ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "N", "")) == 0 ) )
         {
            A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad));
         }
         else
         {
            if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)-(A180SolicitudItemsComision*A177SolicitudesItemsCantidad));
            }
            else
            {
               if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)+(A180SolicitudItemsComision*A177SolicitudesItemsCantidad));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)-((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)*(A180SolicitudItemsComision/ (decimal)(100))));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)+((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)*(A180SolicitudItemsComision/ (decimal)(100))));
                     }
                     else
                     {
                        A175SolicitudesItemsPrecioInstalac = 0;
                     }
                  }
               }
            }
         }
         O175SolicitudesItemsPrecioInstalac = A175SolicitudesItemsPrecioInstalac;
         A522SolicitudesItemsComiProf = (decimal)(A175SolicitudesItemsPrecioInstalac-(A521SolicitudesItemsComiProv+A523SolicitudesItemsComiALM));
      }

      protected void CheckExtendedTable0O31( )
      {
         Gx_BScreen = 1;
         standaloneModal0O31( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000O6 */
         pr_default.execute(4, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RUBROSID");
            AnyError = 1;
         }
         A40000RubrosImagen_GXI = BC000O6_A40000RubrosImagen_GXI[0];
         A123RubrosEstado = BC000O6_A123RubrosEstado[0];
         n123RubrosEstado = BC000O6_n123RubrosEstado[0];
         A168RubrosImagen = BC000O6_A168RubrosImagen[0];
         pr_default.close(4);
         /* Using cursor BC000O7 */
         pr_default.execute(5, new Object[] {A121RubrosId, A137MedidasID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros Medidas y Precios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDIDASID");
            AnyError = 1;
         }
         A118MonedaId = BC000O7_A118MonedaId[0];
         pr_default.close(5);
         /* Using cursor BC000O9 */
         pr_default.execute(7, new Object[] {A118MonedaId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( " T12", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MONEDAID");
            AnyError = 1;
         }
         A119MonedaISOSimbolo = BC000O9_A119MonedaISOSimbolo[0];
         pr_default.close(7);
         /* Using cursor BC000O8 */
         pr_default.execute(6, new Object[] {A121RubrosId, A137MedidasID, A135InventarioId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "INVENTARIOID");
            AnyError = 1;
         }
         A136InventarioNombre = BC000O8_A136InventarioNombre[0];
         A40001InventarioImagen_GXI = BC000O8_A40001InventarioImagen_GXI[0];
         A181InventarioPrecioFinal = BC000O8_A181InventarioPrecioFinal[0];
         A801InventarioConsumoProductivo = BC000O8_A801InventarioConsumoProductivo[0];
         A107EstadosTipo = BC000O8_A107EstadosTipo[0];
         A108EstadosGenericosId = BC000O8_A108EstadosGenericosId[0];
         A189InventarioImagen = BC000O8_A189InventarioImagen[0];
         pr_default.close(6);
         GXt_boolean4 = A1002SolicitudesPrecioEsFreezado;
         new ofreezado(context ).execute(  A133ProveedorID,  A121RubrosId,  A137MedidasID,  A135InventarioId,  A118MonedaId, out  GXt_boolean4) ;
         A1002SolicitudesPrecioEsFreezado = GXt_boolean4;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A178SolicitudItemsSR)) || ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "N", "")) == 0 ) )
         {
            A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad));
         }
         else
         {
            if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)-(A180SolicitudItemsComision*A177SolicitudesItemsCantidad));
            }
            else
            {
               if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)+(A180SolicitudItemsComision*A177SolicitudesItemsCantidad));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)-((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)*(A180SolicitudItemsComision/ (decimal)(100))));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)+((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)*(A180SolicitudItemsComision/ (decimal)(100))));
                     }
                     else
                     {
                        A175SolicitudesItemsPrecioInstalac = 0;
                     }
                  }
               }
            }
         }
         A522SolicitudesItemsComiProf = (decimal)(A175SolicitudesItemsPrecioInstalac-(A521SolicitudesItemsComiProv+A523SolicitudesItemsComiALM));
         if ( IsIns( )  )
         {
            A174SolicitudesTotal = (decimal)(O174SolicitudesTotal+A175SolicitudesItemsPrecioInstalac);
         }
         else
         {
            if ( IsUpd( )  )
            {
               A174SolicitudesTotal = (decimal)(O174SolicitudesTotal+A175SolicitudesItemsPrecioInstalac-O175SolicitudesItemsPrecioInstalac);
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A174SolicitudesTotal = (decimal)(O174SolicitudesTotal-O175SolicitudesItemsPrecioInstalac);
               }
            }
         }
         if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
         {
            A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
         }
         else
         {
            if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                  }
                  else
                  {
                     A211SolicitudServicioPFinal = 0;
                  }
               }
            }
         }
         if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
         {
            A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
         }
         else
         {
            if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
            {
               A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
            }
            else
            {
               if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
               {
                  A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
               }
               else
               {
                  A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
               }
            }
         }
         AV52OldSolicitudServicioPFinal = O211SolicitudServicioPFinal;
      }

      protected void CloseExtendedTableCursors0O31( )
      {
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(7);
         pr_default.close(6);
      }

      protected void enableDisable0O31( )
      {
      }

      protected void GetKey0O31( )
      {
         /* Using cursor BC000O48 */
         pr_default.execute(46, new Object[] {A127SolicitudesID, A134SolicitudesItemsID});
         if ( (pr_default.getStatus(46) != 101) )
         {
            RcdFound31 = 1;
         }
         else
         {
            RcdFound31 = 0;
         }
         pr_default.close(46);
      }

      protected void getByPrimaryKey0O31( )
      {
         /* Using cursor BC000O5 */
         pr_default.execute(3, new Object[] {A127SolicitudesID, A134SolicitudesItemsID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0O31( 78) ;
            RcdFound31 = 1;
            InitializeNonKey0O31( ) ;
            A134SolicitudesItemsID = BC000O5_A134SolicitudesItemsID[0];
            A177SolicitudesItemsCantidad = BC000O5_A177SolicitudesItemsCantidad[0];
            A180SolicitudItemsComision = BC000O5_A180SolicitudItemsComision[0];
            A178SolicitudItemsSR = BC000O5_A178SolicitudItemsSR[0];
            A179SolicitudItemsComisionTipo = BC000O5_A179SolicitudItemsComisionTipo[0];
            A176SolicitudesItemsPrecioFinal = BC000O5_A176SolicitudesItemsPrecioFinal[0];
            n176SolicitudesItemsPrecioFinal = BC000O5_n176SolicitudesItemsPrecioFinal[0];
            A521SolicitudesItemsComiProv = BC000O5_A521SolicitudesItemsComiProv[0];
            n521SolicitudesItemsComiProv = BC000O5_n521SolicitudesItemsComiProv[0];
            A524SolicitudesItemsComiProvP = BC000O5_A524SolicitudesItemsComiProvP[0];
            n524SolicitudesItemsComiProvP = BC000O5_n524SolicitudesItemsComiProvP[0];
            A523SolicitudesItemsComiALM = BC000O5_A523SolicitudesItemsComiALM[0];
            n523SolicitudesItemsComiALM = BC000O5_n523SolicitudesItemsComiALM[0];
            A526SolicitudesItemsComiALMP = BC000O5_A526SolicitudesItemsComiALMP[0];
            n526SolicitudesItemsComiALMP = BC000O5_n526SolicitudesItemsComiALMP[0];
            A121RubrosId = BC000O5_A121RubrosId[0];
            A137MedidasID = BC000O5_A137MedidasID[0];
            A135InventarioId = BC000O5_A135InventarioId[0];
            Z127SolicitudesID = A127SolicitudesID;
            Z134SolicitudesItemsID = A134SolicitudesItemsID;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0O31( ) ;
            Load0O31( ) ;
            Gx_mode = sMode31;
         }
         else
         {
            RcdFound31 = 0;
            InitializeNonKey0O31( ) ;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0O31( ) ;
            Gx_mode = sMode31;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0O31( ) ;
         }
         pr_default.close(3);
      }

      protected void CheckOptimisticConcurrency0O31( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000O4 */
            pr_default.execute(2, new Object[] {A127SolicitudesID, A134SolicitudesItemsID});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SolicitudesItems"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( Z177SolicitudesItemsCantidad != BC000O4_A177SolicitudesItemsCantidad[0] ) || ( Z180SolicitudItemsComision != BC000O4_A180SolicitudItemsComision[0] ) || ( StringUtil.StrCmp(Z178SolicitudItemsSR, BC000O4_A178SolicitudItemsSR[0]) != 0 ) || ( StringUtil.StrCmp(Z179SolicitudItemsComisionTipo, BC000O4_A179SolicitudItemsComisionTipo[0]) != 0 ) || ( Z176SolicitudesItemsPrecioFinal != BC000O4_A176SolicitudesItemsPrecioFinal[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z521SolicitudesItemsComiProv != BC000O4_A521SolicitudesItemsComiProv[0] ) || ( Z524SolicitudesItemsComiProvP != BC000O4_A524SolicitudesItemsComiProvP[0] ) || ( Z523SolicitudesItemsComiALM != BC000O4_A523SolicitudesItemsComiALM[0] ) || ( Z526SolicitudesItemsComiALMP != BC000O4_A526SolicitudesItemsComiALMP[0] ) || ( Z121RubrosId != BC000O4_A121RubrosId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z137MedidasID != BC000O4_A137MedidasID[0] ) || ( Z135InventarioId != BC000O4_A135InventarioId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SolicitudesItems"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0O31( )
      {
         BeforeValidate0O31( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O31( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0O31( 0) ;
            CheckOptimisticConcurrency0O31( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O31( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0O31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000O49 */
                     pr_default.execute(47, new Object[] {A127SolicitudesID, A134SolicitudesItemsID, A177SolicitudesItemsCantidad, A180SolicitudItemsComision, A178SolicitudItemsSR, A179SolicitudItemsComisionTipo, n176SolicitudesItemsPrecioFinal, A176SolicitudesItemsPrecioFinal, n521SolicitudesItemsComiProv, A521SolicitudesItemsComiProv, n524SolicitudesItemsComiProvP, A524SolicitudesItemsComiProvP, n523SolicitudesItemsComiALM, A523SolicitudesItemsComiALM, n526SolicitudesItemsComiALMP, A526SolicitudesItemsComiALMP, A121RubrosId, A137MedidasID, A135InventarioId});
                     pr_default.close(47);
                     pr_default.SmartCacheProvider.SetUpdated("SolicitudesItems");
                     if ( (pr_default.getStatus(47) == 1) )
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
               Load0O31( ) ;
            }
            EndLevel0O31( ) ;
         }
         CloseExtendedTableCursors0O31( ) ;
      }

      protected void Update0O31( )
      {
         BeforeValidate0O31( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O31( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O31( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O31( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0O31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000O50 */
                     pr_default.execute(48, new Object[] {A177SolicitudesItemsCantidad, A180SolicitudItemsComision, A178SolicitudItemsSR, A179SolicitudItemsComisionTipo, n176SolicitudesItemsPrecioFinal, A176SolicitudesItemsPrecioFinal, n521SolicitudesItemsComiProv, A521SolicitudesItemsComiProv, n524SolicitudesItemsComiProvP, A524SolicitudesItemsComiProvP, n523SolicitudesItemsComiALM, A523SolicitudesItemsComiALM, n526SolicitudesItemsComiALMP, A526SolicitudesItemsComiALMP, A121RubrosId, A137MedidasID, A135InventarioId, A127SolicitudesID, A134SolicitudesItemsID});
                     pr_default.close(48);
                     pr_default.SmartCacheProvider.SetUpdated("SolicitudesItems");
                     if ( (pr_default.getStatus(48) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SolicitudesItems"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0O31( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0O31( ) ;
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
            EndLevel0O31( ) ;
         }
         CloseExtendedTableCursors0O31( ) ;
      }

      protected void DeferredUpdate0O31( )
      {
      }

      protected void Delete0O31( )
      {
         Gx_mode = "DLT";
         BeforeValidate0O31( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O31( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0O31( ) ;
            AfterConfirm0O31( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0O31( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000O51 */
                  pr_default.execute(49, new Object[] {A127SolicitudesID, A134SolicitudesItemsID});
                  pr_default.close(49);
                  pr_default.SmartCacheProvider.SetUpdated("SolicitudesItems");
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
         sMode31 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0O31( ) ;
         Gx_mode = sMode31;
      }

      protected void OnDeleteControls0O31( )
      {
         standaloneModal0O31( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000O52 */
            pr_default.execute(50, new Object[] {A121RubrosId});
            A40000RubrosImagen_GXI = BC000O52_A40000RubrosImagen_GXI[0];
            A123RubrosEstado = BC000O52_A123RubrosEstado[0];
            n123RubrosEstado = BC000O52_n123RubrosEstado[0];
            A168RubrosImagen = BC000O52_A168RubrosImagen[0];
            pr_default.close(50);
            /* Using cursor BC000O53 */
            pr_default.execute(51, new Object[] {A121RubrosId, A137MedidasID});
            A118MonedaId = BC000O53_A118MonedaId[0];
            pr_default.close(51);
            /* Using cursor BC000O54 */
            pr_default.execute(52, new Object[] {A118MonedaId});
            A119MonedaISOSimbolo = BC000O54_A119MonedaISOSimbolo[0];
            pr_default.close(52);
            /* Using cursor BC000O55 */
            pr_default.execute(53, new Object[] {A121RubrosId, A137MedidasID, A135InventarioId});
            A136InventarioNombre = BC000O55_A136InventarioNombre[0];
            A40001InventarioImagen_GXI = BC000O55_A40001InventarioImagen_GXI[0];
            A181InventarioPrecioFinal = BC000O55_A181InventarioPrecioFinal[0];
            A801InventarioConsumoProductivo = BC000O55_A801InventarioConsumoProductivo[0];
            A107EstadosTipo = BC000O55_A107EstadosTipo[0];
            A108EstadosGenericosId = BC000O55_A108EstadosGenericosId[0];
            A189InventarioImagen = BC000O55_A189InventarioImagen[0];
            pr_default.close(53);
            GXt_boolean4 = A1002SolicitudesPrecioEsFreezado;
            new ofreezado(context ).execute(  A133ProveedorID,  A121RubrosId,  A137MedidasID,  A135InventarioId,  A118MonedaId, out  GXt_boolean4) ;
            A1002SolicitudesPrecioEsFreezado = GXt_boolean4;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A178SolicitudItemsSR)) || ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "N", "")) == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad));
            }
            else
            {
               if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)-(A180SolicitudItemsComision*A177SolicitudesItemsCantidad));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)+(A180SolicitudItemsComision*A177SolicitudesItemsCantidad));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)-((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)*(A180SolicitudItemsComision/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)+((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)*(A180SolicitudItemsComision/ (decimal)(100))));
                        }
                        else
                        {
                           A175SolicitudesItemsPrecioInstalac = 0;
                        }
                     }
                  }
               }
            }
            if ( IsIns( )  )
            {
               A174SolicitudesTotal = (decimal)(O174SolicitudesTotal+A175SolicitudesItemsPrecioInstalac);
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A174SolicitudesTotal = (decimal)(O174SolicitudesTotal+A175SolicitudesItemsPrecioInstalac-O175SolicitudesItemsPrecioInstalac);
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A174SolicitudesTotal = (decimal)(O174SolicitudesTotal-O175SolicitudesItemsPrecioInstalac);
                  }
               }
            }
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
            {
               A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
            }
            else
            {
               if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
               {
                  A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
               }
               else
               {
                  if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
                  {
                     A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                  }
                  else
                  {
                     A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                  }
               }
            }
            AV52OldSolicitudServicioPFinal = O211SolicitudServicioPFinal;
            A522SolicitudesItemsComiProf = (decimal)(A175SolicitudesItemsPrecioInstalac-(A521SolicitudesItemsComiProv+A523SolicitudesItemsComiALM));
         }
      }

      protected void EndLevel0O31( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0O31( )
      {
         /* Scan By routine */
         /* Using cursor BC000O56 */
         pr_default.execute(54, new Object[] {A127SolicitudesID});
         RcdFound31 = 0;
         if ( (pr_default.getStatus(54) != 101) )
         {
            RcdFound31 = 1;
            A134SolicitudesItemsID = BC000O56_A134SolicitudesItemsID[0];
            A177SolicitudesItemsCantidad = BC000O56_A177SolicitudesItemsCantidad[0];
            A180SolicitudItemsComision = BC000O56_A180SolicitudItemsComision[0];
            A178SolicitudItemsSR = BC000O56_A178SolicitudItemsSR[0];
            A179SolicitudItemsComisionTipo = BC000O56_A179SolicitudItemsComisionTipo[0];
            A40000RubrosImagen_GXI = BC000O56_A40000RubrosImagen_GXI[0];
            A123RubrosEstado = BC000O56_A123RubrosEstado[0];
            n123RubrosEstado = BC000O56_n123RubrosEstado[0];
            A136InventarioNombre = BC000O56_A136InventarioNombre[0];
            A40001InventarioImagen_GXI = BC000O56_A40001InventarioImagen_GXI[0];
            A181InventarioPrecioFinal = BC000O56_A181InventarioPrecioFinal[0];
            A801InventarioConsumoProductivo = BC000O56_A801InventarioConsumoProductivo[0];
            A176SolicitudesItemsPrecioFinal = BC000O56_A176SolicitudesItemsPrecioFinal[0];
            n176SolicitudesItemsPrecioFinal = BC000O56_n176SolicitudesItemsPrecioFinal[0];
            A119MonedaISOSimbolo = BC000O56_A119MonedaISOSimbolo[0];
            A521SolicitudesItemsComiProv = BC000O56_A521SolicitudesItemsComiProv[0];
            n521SolicitudesItemsComiProv = BC000O56_n521SolicitudesItemsComiProv[0];
            A524SolicitudesItemsComiProvP = BC000O56_A524SolicitudesItemsComiProvP[0];
            n524SolicitudesItemsComiProvP = BC000O56_n524SolicitudesItemsComiProvP[0];
            A523SolicitudesItemsComiALM = BC000O56_A523SolicitudesItemsComiALM[0];
            n523SolicitudesItemsComiALM = BC000O56_n523SolicitudesItemsComiALM[0];
            A526SolicitudesItemsComiALMP = BC000O56_A526SolicitudesItemsComiALMP[0];
            n526SolicitudesItemsComiALMP = BC000O56_n526SolicitudesItemsComiALMP[0];
            A121RubrosId = BC000O56_A121RubrosId[0];
            A137MedidasID = BC000O56_A137MedidasID[0];
            A135InventarioId = BC000O56_A135InventarioId[0];
            A118MonedaId = BC000O56_A118MonedaId[0];
            A107EstadosTipo = BC000O56_A107EstadosTipo[0];
            A108EstadosGenericosId = BC000O56_A108EstadosGenericosId[0];
            A168RubrosImagen = BC000O56_A168RubrosImagen[0];
            A189InventarioImagen = BC000O56_A189InventarioImagen[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0O31( )
      {
         /* Scan next routine */
         pr_default.readNext(54);
         RcdFound31 = 0;
         ScanKeyLoad0O31( ) ;
      }

      protected void ScanKeyLoad0O31( )
      {
         sMode31 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(54) != 101) )
         {
            RcdFound31 = 1;
            A134SolicitudesItemsID = BC000O56_A134SolicitudesItemsID[0];
            A177SolicitudesItemsCantidad = BC000O56_A177SolicitudesItemsCantidad[0];
            A180SolicitudItemsComision = BC000O56_A180SolicitudItemsComision[0];
            A178SolicitudItemsSR = BC000O56_A178SolicitudItemsSR[0];
            A179SolicitudItemsComisionTipo = BC000O56_A179SolicitudItemsComisionTipo[0];
            A40000RubrosImagen_GXI = BC000O56_A40000RubrosImagen_GXI[0];
            A123RubrosEstado = BC000O56_A123RubrosEstado[0];
            n123RubrosEstado = BC000O56_n123RubrosEstado[0];
            A136InventarioNombre = BC000O56_A136InventarioNombre[0];
            A40001InventarioImagen_GXI = BC000O56_A40001InventarioImagen_GXI[0];
            A181InventarioPrecioFinal = BC000O56_A181InventarioPrecioFinal[0];
            A801InventarioConsumoProductivo = BC000O56_A801InventarioConsumoProductivo[0];
            A176SolicitudesItemsPrecioFinal = BC000O56_A176SolicitudesItemsPrecioFinal[0];
            n176SolicitudesItemsPrecioFinal = BC000O56_n176SolicitudesItemsPrecioFinal[0];
            A119MonedaISOSimbolo = BC000O56_A119MonedaISOSimbolo[0];
            A521SolicitudesItemsComiProv = BC000O56_A521SolicitudesItemsComiProv[0];
            n521SolicitudesItemsComiProv = BC000O56_n521SolicitudesItemsComiProv[0];
            A524SolicitudesItemsComiProvP = BC000O56_A524SolicitudesItemsComiProvP[0];
            n524SolicitudesItemsComiProvP = BC000O56_n524SolicitudesItemsComiProvP[0];
            A523SolicitudesItemsComiALM = BC000O56_A523SolicitudesItemsComiALM[0];
            n523SolicitudesItemsComiALM = BC000O56_n523SolicitudesItemsComiALM[0];
            A526SolicitudesItemsComiALMP = BC000O56_A526SolicitudesItemsComiALMP[0];
            n526SolicitudesItemsComiALMP = BC000O56_n526SolicitudesItemsComiALMP[0];
            A121RubrosId = BC000O56_A121RubrosId[0];
            A137MedidasID = BC000O56_A137MedidasID[0];
            A135InventarioId = BC000O56_A135InventarioId[0];
            A118MonedaId = BC000O56_A118MonedaId[0];
            A107EstadosTipo = BC000O56_A107EstadosTipo[0];
            A108EstadosGenericosId = BC000O56_A108EstadosGenericosId[0];
            A168RubrosImagen = BC000O56_A168RubrosImagen[0];
            A189InventarioImagen = BC000O56_A189InventarioImagen[0];
         }
         Gx_mode = sMode31;
      }

      protected void ScanKeyEnd0O31( )
      {
         pr_default.close(54);
      }

      protected void AfterConfirm0O31( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0O31( )
      {
         /* Before Insert Rules */
         new oprecprov(context ).execute(  A133ProveedorID,  A121RubrosId,  A137MedidasID,  A135InventarioId,  A118MonedaId, out  A180SolicitudItemsComision, out  A178SolicitudItemsSR, out  A179SolicitudItemsComisionTipo, out  AV85PrecioFinal, out  AV86FreezarPrecio) ;
         AV87SolicitudesItemsPrecioFinal = (((AV86FreezarPrecio)&&(AV85PrecioFinal>Convert.ToDecimal(0))) ? AV85PrecioFinal : A181InventarioPrecioFinal);
         A176SolicitudesItemsPrecioFinal = AV87SolicitudesItemsPrecioFinal;
         n176SolicitudesItemsPrecioFinal = false;
      }

      protected void BeforeUpdate0O31( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0O31( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0O31( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0O31( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0O31( )
      {
      }

      protected void send_integrity_lvl_hashes0O31( )
      {
      }

      protected void ZM0O144( short GX_JID )
      {
         if ( ( GX_JID == 83 ) || ( GX_JID == 0 ) )
         {
            Z989ArchivoDireccion = A989ArchivoDireccion;
            Z990ArchivoDescripcion = A990ArchivoDescripcion;
            Z991ArchivoTipo = A991ArchivoTipo;
         }
         if ( GX_JID == -83 )
         {
            Z127SolicitudesID = A127SolicitudesID;
            Z988ArchivoId = A988ArchivoId;
            Z989ArchivoDireccion = A989ArchivoDireccion;
            Z990ArchivoDescripcion = A990ArchivoDescripcion;
            Z991ArchivoTipo = A991ArchivoTipo;
         }
      }

      protected void standaloneNotModal0O144( )
      {
      }

      protected void standaloneModal0O144( )
      {
         if ( IsIns( )  )
         {
            A992SolicitudesSerialArchivo = (short)(O992SolicitudesSerialArchivo+1);
         }
         if ( IsIns( )  )
         {
            A988ArchivoId = A992SolicitudesSerialArchivo;
         }
      }

      protected void Load0O144( )
      {
         /* Using cursor BC000O57 */
         pr_default.execute(55, new Object[] {A127SolicitudesID, A988ArchivoId});
         if ( (pr_default.getStatus(55) != 101) )
         {
            RcdFound144 = 1;
            A989ArchivoDireccion = BC000O57_A989ArchivoDireccion[0];
            A990ArchivoDescripcion = BC000O57_A990ArchivoDescripcion[0];
            A991ArchivoTipo = BC000O57_A991ArchivoTipo[0];
            ZM0O144( -83) ;
         }
         pr_default.close(55);
         OnLoadActions0O144( ) ;
      }

      protected void OnLoadActions0O144( )
      {
      }

      protected void CheckExtendedTable0O144( )
      {
         Gx_BScreen = 1;
         standaloneModal0O144( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors0O144( )
      {
      }

      protected void enableDisable0O144( )
      {
      }

      protected void GetKey0O144( )
      {
         /* Using cursor BC000O58 */
         pr_default.execute(56, new Object[] {A127SolicitudesID, A988ArchivoId});
         if ( (pr_default.getStatus(56) != 101) )
         {
            RcdFound144 = 1;
         }
         else
         {
            RcdFound144 = 0;
         }
         pr_default.close(56);
      }

      protected void getByPrimaryKey0O144( )
      {
         /* Using cursor BC000O3 */
         pr_default.execute(1, new Object[] {A127SolicitudesID, A988ArchivoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0O144( 83) ;
            RcdFound144 = 1;
            InitializeNonKey0O144( ) ;
            A988ArchivoId = BC000O3_A988ArchivoId[0];
            A989ArchivoDireccion = BC000O3_A989ArchivoDireccion[0];
            A990ArchivoDescripcion = BC000O3_A990ArchivoDescripcion[0];
            A991ArchivoTipo = BC000O3_A991ArchivoTipo[0];
            Z127SolicitudesID = A127SolicitudesID;
            Z988ArchivoId = A988ArchivoId;
            sMode144 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0O144( ) ;
            Load0O144( ) ;
            Gx_mode = sMode144;
         }
         else
         {
            RcdFound144 = 0;
            InitializeNonKey0O144( ) ;
            sMode144 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0O144( ) ;
            Gx_mode = sMode144;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0O144( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0O144( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000O2 */
            pr_default.execute(0, new Object[] {A127SolicitudesID, A988ArchivoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SolicitudesArchivo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z989ArchivoDireccion, BC000O2_A989ArchivoDireccion[0]) != 0 ) || ( StringUtil.StrCmp(Z990ArchivoDescripcion, BC000O2_A990ArchivoDescripcion[0]) != 0 ) || ( StringUtil.StrCmp(Z991ArchivoTipo, BC000O2_A991ArchivoTipo[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SolicitudesArchivo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0O144( )
      {
         BeforeValidate0O144( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O144( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0O144( 0) ;
            CheckOptimisticConcurrency0O144( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O144( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0O144( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000O59 */
                     pr_default.execute(57, new Object[] {A127SolicitudesID, A988ArchivoId, A989ArchivoDireccion, A990ArchivoDescripcion, A991ArchivoTipo});
                     pr_default.close(57);
                     pr_default.SmartCacheProvider.SetUpdated("SolicitudesArchivo");
                     if ( (pr_default.getStatus(57) == 1) )
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
               Load0O144( ) ;
            }
            EndLevel0O144( ) ;
         }
         CloseExtendedTableCursors0O144( ) ;
      }

      protected void Update0O144( )
      {
         BeforeValidate0O144( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O144( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O144( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O144( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0O144( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000O60 */
                     pr_default.execute(58, new Object[] {A989ArchivoDireccion, A990ArchivoDescripcion, A991ArchivoTipo, A127SolicitudesID, A988ArchivoId});
                     pr_default.close(58);
                     pr_default.SmartCacheProvider.SetUpdated("SolicitudesArchivo");
                     if ( (pr_default.getStatus(58) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SolicitudesArchivo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0O144( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0O144( ) ;
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
            EndLevel0O144( ) ;
         }
         CloseExtendedTableCursors0O144( ) ;
      }

      protected void DeferredUpdate0O144( )
      {
      }

      protected void Delete0O144( )
      {
         Gx_mode = "DLT";
         BeforeValidate0O144( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O144( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0O144( ) ;
            AfterConfirm0O144( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0O144( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000O61 */
                  pr_default.execute(59, new Object[] {A127SolicitudesID, A988ArchivoId});
                  pr_default.close(59);
                  pr_default.SmartCacheProvider.SetUpdated("SolicitudesArchivo");
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
         sMode144 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0O144( ) ;
         Gx_mode = sMode144;
      }

      protected void OnDeleteControls0O144( )
      {
         standaloneModal0O144( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0O144( )
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

      public void ScanKeyStart0O144( )
      {
         /* Scan By routine */
         /* Using cursor BC000O62 */
         pr_default.execute(60, new Object[] {A127SolicitudesID});
         RcdFound144 = 0;
         if ( (pr_default.getStatus(60) != 101) )
         {
            RcdFound144 = 1;
            A988ArchivoId = BC000O62_A988ArchivoId[0];
            A989ArchivoDireccion = BC000O62_A989ArchivoDireccion[0];
            A990ArchivoDescripcion = BC000O62_A990ArchivoDescripcion[0];
            A991ArchivoTipo = BC000O62_A991ArchivoTipo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0O144( )
      {
         /* Scan next routine */
         pr_default.readNext(60);
         RcdFound144 = 0;
         ScanKeyLoad0O144( ) ;
      }

      protected void ScanKeyLoad0O144( )
      {
         sMode144 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(60) != 101) )
         {
            RcdFound144 = 1;
            A988ArchivoId = BC000O62_A988ArchivoId[0];
            A989ArchivoDireccion = BC000O62_A989ArchivoDireccion[0];
            A990ArchivoDescripcion = BC000O62_A990ArchivoDescripcion[0];
            A991ArchivoTipo = BC000O62_A991ArchivoTipo[0];
         }
         Gx_mode = sMode144;
      }

      protected void ScanKeyEnd0O144( )
      {
         pr_default.close(60);
      }

      protected void AfterConfirm0O144( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0O144( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0O144( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0O144( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0O144( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0O144( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0O144( )
      {
      }

      protected void send_integrity_lvl_hashes0O144( )
      {
      }

      protected void send_integrity_lvl_hashes0O30( )
      {
      }

      protected void AddRow0O30( )
      {
         VarsToRow30( bcSolicitudes) ;
      }

      protected void ReadRow0O30( )
      {
         RowToVars30( bcSolicitudes, 1) ;
      }

      protected void AddRow0O31( )
      {
         SdtSolicitudes_Items obj31;
         obj31 = new SdtSolicitudes_Items(context);
         VarsToRow31( obj31) ;
         bcSolicitudes.gxTpr_Items.Add(obj31, 0);
         obj31.gxTpr_Mode = "UPD";
         obj31.gxTpr_Modified = 0;
      }

      protected void ReadRow0O31( )
      {
         nGXsfl_31_idx = (int)(nGXsfl_31_idx+1);
         RowToVars31( ((SdtSolicitudes_Items)bcSolicitudes.gxTpr_Items.Item(nGXsfl_31_idx)), 1) ;
      }

      protected void AddRow0O144( )
      {
         SdtSolicitudes_Archivo obj144;
         obj144 = new SdtSolicitudes_Archivo(context);
         VarsToRow144( obj144) ;
         bcSolicitudes.gxTpr_Archivo.Add(obj144, 0);
         obj144.gxTpr_Mode = "UPD";
         obj144.gxTpr_Modified = 0;
      }

      protected void ReadRow0O144( )
      {
         nGXsfl_144_idx = (int)(nGXsfl_144_idx+1);
         RowToVars144( ((SdtSolicitudes_Archivo)bcSolicitudes.gxTpr_Archivo.Item(nGXsfl_144_idx)), 1) ;
      }

      protected void InitializeNonKey0O30( )
      {
         AV73OldEstadosSolId = 0;
         AV52OldSolicitudServicioPFinal = 0;
         AV53OldSolicitudesCotizacion = 0;
         A438SolicitudServicioOrigenPago = "";
         n438SolicitudServicioOrigenPago = false;
         A866SolicitudesCostoXZComAlmP = 0;
         n866SolicitudesCostoXZComAlmP = false;
         A865SolicitudesCostoXZComAlm = 0;
         n865SolicitudesCostoXZComAlm = false;
         A182SolicitudesFechaAlta = DateTime.MinValue;
         n182SolicitudesFechaAlta = false;
         A868SolicitudesCostoXZComProfP = 0;
         A867SolicitudesCostoXZComProf = 0;
         A531SolicitudServicioComProP = 0;
         A529SolicitudServicioComPro = 0;
         A211SolicitudServicioPFinal = 0;
         A171SolicitudesNombre = "";
         A172SolicitudesTelefono = "";
         A206SolicitudesMail = "";
         n206SolicitudesMail = false;
         A114DepartamentoMunicipioId = 0;
         n114DepartamentoMunicipioId = false;
         A110ZonasID = 0;
         n110ZonasID = false;
         A173SolicitudesDireccion = "";
         A194SolicitudesAutoEnumerar = 0;
         A671STMonedasISO = "";
         A688SolicitudesLiqProf = 0;
         n688SolicitudesLiqProf = false;
         A689SolicitudesLiqProv = 0;
         n689SolicitudesLiqProv = false;
         A212SolicitudesCotizacion = 0;
         A174SolicitudesTotal = 0;
         A210SolicitudServicioSolCoti = "";
         A897SolicitudesDescuento = 0;
         n897SolicitudesDescuento = false;
         A1014CuponPercent = 0;
         A1016SolicitudesDescuentoCupon = 0;
         A796SolicitudesComisionMetodoPago = 0;
         A132EstadosSolNombre = "";
         A202SolicitudesOtros2 = "";
         A203SolicitudesOtros3 = "";
         A597SolicitudesUsrAlta = 0;
         n597SolicitudesUsrAlta = false;
         A598SolicitudesUsrActualizacion = 0;
         n598SolicitudesUsrActualizacion = false;
         A204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         n204SolicitudesFechaActualizacion = false;
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A183SolicitudesHoraInstalacion = "";
         A205SolicitudesComentario = "";
         A128MetodoPagosID = 0;
         A129MetodoPagosNombre = "";
         A261SolicitudesNota = "";
         A262SolicitudesNotificacion = "";
         A282ProveedorNombre = "";
         A440ProveedorPagoDefault = "";
         A919STComerciosID = 0;
         n919STComerciosID = false;
         A923STComerciosNombre = "";
         A924STComerciosEstado = "";
         A441SolicitudesPagado = "";
         n441SolicitudesPagado = false;
         A527SolicitudServicioComProv = 0;
         n527SolicitudServicioComProv = false;
         A528SolicitudServicioComProvP = 0;
         n528SolicitudServicioComProvP = false;
         A530SolicitudServicioComALM = 0;
         n530SolicitudServicioComALM = false;
         A532SolicitudServicioComALMP = 0;
         n532SolicitudServicioComALMP = false;
         A672SolicitudesCalComi = false;
         A533ProveedorNombreAux = "";
         n533ProveedorNombreAux = false;
         A864SolicitudesCostoXZona = 0;
         A735MudanzaId = 0;
         n735MudanzaId = false;
         A738MudanzaFechaServicio = DateTime.MinValue;
         A740MudanzaDireccionOrigen = "";
         A741MudanzaDireccionDestino = "";
         A422PostulacionesId = 0;
         n422PostulacionesId = false;
         A972SolicitudesDuplicado = 0;
         n972SolicitudesDuplicado = false;
         A992SolicitudesSerialArchivo = 0;
         A997CancelacionTipificacionDescrip = "";
         A1003SolicitudesCostoPresupuesto = 0;
         n1003SolicitudesCostoPresupuesto = false;
         A1006SolicitudesURLOrigen = "";
         n1006SolicitudesURLOrigen = false;
         A1020TicketId = 0;
         n1020TicketId = false;
         A1021TicketMotivoId = 0;
         A1022TicketMotivoDescripcion = "";
         A1024TicketComentario = "";
         A1026TicketAdjunto = "";
         A1030TicketEstado = false;
         A1023TicketSolicitudId = 0;
         A116PaisID = "UY";
         A112DepartamentoId = 1;
         n112DepartamentoId = false;
         A669STMonedasId = 1;
         n669STMonedasId = false;
         A1013CuponId = 1234;
         n1013CuponId = false;
         A130EstadosSolTipo = context.GetMessage( "SOL", "");
         A131EstadosSolId = 1;
         A201SolicitudesOtros1 = context.GetMessage( "N", "");
         A133ProveedorID = 1001;
         A600SolicitudesSubTipo = "T";
         n600SolicitudesSubTipo = false;
         A996CancelacionTipificacionId = 0;
         O992SolicitudesSerialArchivo = A992SolicitudesSerialArchivo;
         O211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
         O194SolicitudesAutoEnumerar = A194SolicitudesAutoEnumerar;
         O174SolicitudesTotal = A174SolicitudesTotal;
         O133ProveedorID = A133ProveedorID;
         O212SolicitudesCotizacion = A212SolicitudesCotizacion;
         O131EstadosSolId = A131EstadosSolId;
         Z438SolicitudServicioOrigenPago = "";
         Z866SolicitudesCostoXZComAlmP = 0;
         Z865SolicitudesCostoXZComAlm = 0;
         Z182SolicitudesFechaAlta = DateTime.MinValue;
         Z171SolicitudesNombre = "";
         Z172SolicitudesTelefono = "";
         Z206SolicitudesMail = "";
         Z173SolicitudesDireccion = "";
         Z194SolicitudesAutoEnumerar = 0;
         Z688SolicitudesLiqProf = 0;
         Z689SolicitudesLiqProv = 0;
         Z212SolicitudesCotizacion = 0;
         Z210SolicitudServicioSolCoti = "";
         Z897SolicitudesDescuento = 0;
         Z1016SolicitudesDescuentoCupon = 0;
         Z796SolicitudesComisionMetodoPago = 0;
         Z201SolicitudesOtros1 = "";
         Z202SolicitudesOtros2 = "";
         Z203SolicitudesOtros3 = "";
         Z597SolicitudesUsrAlta = 0;
         Z598SolicitudesUsrActualizacion = 0;
         Z204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         Z184SolicitudesFechaInstalacion = DateTime.MinValue;
         Z183SolicitudesHoraInstalacion = "";
         Z261SolicitudesNota = "";
         Z262SolicitudesNotificacion = "";
         Z441SolicitudesPagado = "";
         Z527SolicitudServicioComProv = 0;
         Z528SolicitudServicioComProvP = 0;
         Z530SolicitudServicioComALM = 0;
         Z532SolicitudServicioComALMP = 0;
         Z672SolicitudesCalComi = false;
         Z533ProveedorNombreAux = "";
         Z600SolicitudesSubTipo = "";
         Z864SolicitudesCostoXZona = 0;
         Z972SolicitudesDuplicado = 0;
         Z992SolicitudesSerialArchivo = 0;
         Z1003SolicitudesCostoPresupuesto = 0;
         Z1006SolicitudesURLOrigen = "";
         Z112DepartamentoId = 0;
         Z114DepartamentoMunicipioId = 0;
         Z110ZonasID = 0;
         Z128MetodoPagosID = 0;
         Z735MudanzaId = 0;
         Z133ProveedorID = 0;
         Z919STComerciosID = 0;
         Z422PostulacionesId = 0;
         Z996CancelacionTipificacionId = 0;
         Z1013CuponId = 0;
         Z1020TicketId = 0;
         Z130EstadosSolTipo = "";
         Z131EstadosSolId = 0;
         Z669STMonedasId = 0;
         Z116PaisID = "";
      }

      protected void InitAll0O30( )
      {
         A127SolicitudesID = 0;
         InitializeNonKey0O30( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A996CancelacionTipificacionId = i996CancelacionTipificacionId;
         A669STMonedasId = i669STMonedasId;
         n669STMonedasId = false;
         A130EstadosSolTipo = i130EstadosSolTipo;
         A131EstadosSolId = i131EstadosSolId;
         A201SolicitudesOtros1 = i201SolicitudesOtros1;
         A133ProveedorID = i133ProveedorID;
         A600SolicitudesSubTipo = i600SolicitudesSubTipo;
         n600SolicitudesSubTipo = false;
      }

      protected void InitializeNonKey0O31( )
      {
         A180SolicitudItemsComision = 0;
         A178SolicitudItemsSR = "";
         A179SolicitudItemsComisionTipo = "";
         AV87SolicitudesItemsPrecioFinal = 0;
         A525SolicitudesItemsComiProfP = 0;
         A522SolicitudesItemsComiProf = 0;
         A175SolicitudesItemsPrecioInstalac = 0;
         A1002SolicitudesPrecioEsFreezado = false;
         A121RubrosId = 0;
         A168RubrosImagen = "";
         A40000RubrosImagen_GXI = "";
         A123RubrosEstado = "";
         n123RubrosEstado = false;
         A137MedidasID = 0;
         A135InventarioId = 0;
         A136InventarioNombre = "";
         A189InventarioImagen = "";
         A40001InventarioImagen_GXI = "";
         A181InventarioPrecioFinal = 0;
         A801InventarioConsumoProductivo = 0;
         A107EstadosTipo = "";
         A108EstadosGenericosId = 0;
         A176SolicitudesItemsPrecioFinal = 0;
         n176SolicitudesItemsPrecioFinal = false;
         A118MonedaId = 0;
         A119MonedaISOSimbolo = "";
         A521SolicitudesItemsComiProv = 0;
         n521SolicitudesItemsComiProv = false;
         A524SolicitudesItemsComiProvP = 0;
         n524SolicitudesItemsComiProvP = false;
         A523SolicitudesItemsComiALM = 0;
         n523SolicitudesItemsComiALM = false;
         A526SolicitudesItemsComiALMP = 0;
         n526SolicitudesItemsComiALMP = false;
         A177SolicitudesItemsCantidad = 1;
         O175SolicitudesItemsPrecioInstalac = A175SolicitudesItemsPrecioInstalac;
         Z177SolicitudesItemsCantidad = 0;
         Z180SolicitudItemsComision = 0;
         Z178SolicitudItemsSR = "";
         Z179SolicitudItemsComisionTipo = "";
         Z176SolicitudesItemsPrecioFinal = 0;
         Z521SolicitudesItemsComiProv = 0;
         Z524SolicitudesItemsComiProvP = 0;
         Z523SolicitudesItemsComiALM = 0;
         Z526SolicitudesItemsComiALMP = 0;
         Z121RubrosId = 0;
         Z137MedidasID = 0;
         Z135InventarioId = 0;
      }

      protected void InitAll0O31( )
      {
         A134SolicitudesItemsID = 0;
         InitializeNonKey0O31( ) ;
      }

      protected void StandaloneModalInsert0O31( )
      {
         A194SolicitudesAutoEnumerar = i194SolicitudesAutoEnumerar;
         A177SolicitudesItemsCantidad = i177SolicitudesItemsCantidad;
      }

      protected void InitializeNonKey0O144( )
      {
         A989ArchivoDireccion = "";
         A990ArchivoDescripcion = "";
         A991ArchivoTipo = "";
         Z989ArchivoDireccion = "";
         Z990ArchivoDescripcion = "";
         Z991ArchivoTipo = "";
      }

      protected void InitAll0O144( )
      {
         A988ArchivoId = 0;
         InitializeNonKey0O144( ) ;
      }

      protected void StandaloneModalInsert0O144( )
      {
         A992SolicitudesSerialArchivo = i992SolicitudesSerialArchivo;
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor BC000O63 */
         pr_default.execute(61, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(61) != 101) && ( BC000O63_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( BC000O63_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(BC000O63_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((BC000O63_A176SolicitudesItemsPrecioFinal[0]*BC000O63_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(BC000O63_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(BC000O63_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((BC000O63_A176SolicitudesItemsPrecioFinal[0]*BC000O63_A177SolicitudesItemsCantidad[0])-(BC000O63_A180SolicitudItemsComision[0]*BC000O63_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(BC000O63_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(BC000O63_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((BC000O63_A176SolicitudesItemsPrecioFinal[0]*BC000O63_A177SolicitudesItemsCantidad[0])+(BC000O63_A180SolicitudItemsComision[0]*BC000O63_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(BC000O63_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(BC000O63_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((BC000O63_A176SolicitudesItemsPrecioFinal[0]*BC000O63_A177SolicitudesItemsCantidad[0])-((BC000O63_A176SolicitudesItemsPrecioFinal[0]*BC000O63_A177SolicitudesItemsCantidad[0])*(BC000O63_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(BC000O63_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(BC000O63_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((BC000O63_A176SolicitudesItemsPrecioFinal[0]*BC000O63_A177SolicitudesItemsCantidad[0])+((BC000O63_A176SolicitudesItemsPrecioFinal[0]*BC000O63_A177SolicitudesItemsCantidad[0])*(BC000O63_A180SolicitudItemsComision[0]/ (decimal)(100))));
                        }
                        else
                        {
                           A175SolicitudesItemsPrecioInstalac = 0;
                        }
                     }
                  }
               }
            }
            A174SolicitudesTotal = (decimal)(A174SolicitudesTotal+A175SolicitudesItemsPrecioInstalac);
            pr_default.readNext(61);
         }
         pr_default.close(61);
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

      public void VarsToRow30( SdtSolicitudes obj30 )
      {
         obj30.gxTpr_Mode = Gx_mode;
         obj30.gxTpr_Solicitudservicioorigenpago = A438SolicitudServicioOrigenPago;
         obj30.gxTpr_Solicitudescostoxzcomalmp = A866SolicitudesCostoXZComAlmP;
         obj30.gxTpr_Solicitudescostoxzcomalm = A865SolicitudesCostoXZComAlm;
         obj30.gxTpr_Solicitudesfechaalta = A182SolicitudesFechaAlta;
         obj30.gxTpr_Solicitudescostoxzcomprofp = A868SolicitudesCostoXZComProfP;
         obj30.gxTpr_Solicitudescostoxzcomprof = A867SolicitudesCostoXZComProf;
         obj30.gxTpr_Solicitudserviciocomprop = A531SolicitudServicioComProP;
         obj30.gxTpr_Solicitudserviciocompro = A529SolicitudServicioComPro;
         obj30.gxTpr_Solicitudserviciopfinal = A211SolicitudServicioPFinal;
         obj30.gxTpr_Solicitudesnombre = A171SolicitudesNombre;
         obj30.gxTpr_Solicitudestelefono = A172SolicitudesTelefono;
         obj30.gxTpr_Solicitudesmail = A206SolicitudesMail;
         obj30.gxTpr_Departamentomunicipioid = A114DepartamentoMunicipioId;
         obj30.gxTpr_Zonasid = A110ZonasID;
         obj30.gxTpr_Solicitudesdireccion = A173SolicitudesDireccion;
         obj30.gxTpr_Solicitudesautoenumerar = A194SolicitudesAutoEnumerar;
         obj30.gxTpr_Stmonedasiso = A671STMonedasISO;
         obj30.gxTpr_Solicitudesliqprof = A688SolicitudesLiqProf;
         obj30.gxTpr_Solicitudesliqprov = A689SolicitudesLiqProv;
         obj30.gxTpr_Solicitudescotizacion = A212SolicitudesCotizacion;
         obj30.gxTpr_Solicitudestotal = A174SolicitudesTotal;
         obj30.gxTpr_Solicitudserviciosolcoti = A210SolicitudServicioSolCoti;
         obj30.gxTpr_Solicitudesdescuento = A897SolicitudesDescuento;
         obj30.gxTpr_Cuponpercent = A1014CuponPercent;
         obj30.gxTpr_Solicitudesdescuentocupon = A1016SolicitudesDescuentoCupon;
         obj30.gxTpr_Solicitudescomisionmetodopago = A796SolicitudesComisionMetodoPago;
         obj30.gxTpr_Estadossolnombre = A132EstadosSolNombre;
         obj30.gxTpr_Solicitudesotros2 = A202SolicitudesOtros2;
         obj30.gxTpr_Solicitudesotros3 = A203SolicitudesOtros3;
         obj30.gxTpr_Solicitudesusralta = A597SolicitudesUsrAlta;
         obj30.gxTpr_Solicitudesusractualizacion = A598SolicitudesUsrActualizacion;
         obj30.gxTpr_Solicitudesfechaactualizacion = A204SolicitudesFechaActualizacion;
         obj30.gxTpr_Solicitudesfechainstalacion = A184SolicitudesFechaInstalacion;
         obj30.gxTpr_Solicitudeshorainstalacion = A183SolicitudesHoraInstalacion;
         obj30.gxTpr_Solicitudescomentario = A205SolicitudesComentario;
         obj30.gxTpr_Metodopagosid = A128MetodoPagosID;
         obj30.gxTpr_Metodopagosnombre = A129MetodoPagosNombre;
         obj30.gxTpr_Solicitudesnota = A261SolicitudesNota;
         obj30.gxTpr_Solicitudesnotificacion = A262SolicitudesNotificacion;
         obj30.gxTpr_Proveedornombre = A282ProveedorNombre;
         obj30.gxTpr_Proveedorpagodefault = A440ProveedorPagoDefault;
         obj30.gxTpr_Stcomerciosid = A919STComerciosID;
         obj30.gxTpr_Stcomerciosnombre = A923STComerciosNombre;
         obj30.gxTpr_Stcomerciosestado = A924STComerciosEstado;
         obj30.gxTpr_Solicitudespagado = A441SolicitudesPagado;
         obj30.gxTpr_Solicitudserviciocomprov = A527SolicitudServicioComProv;
         obj30.gxTpr_Solicitudserviciocomprovp = A528SolicitudServicioComProvP;
         obj30.gxTpr_Solicitudserviciocomalm = A530SolicitudServicioComALM;
         obj30.gxTpr_Solicitudserviciocomalmp = A532SolicitudServicioComALMP;
         obj30.gxTpr_Solicitudescalcomi = A672SolicitudesCalComi;
         obj30.gxTpr_Proveedornombreaux = A533ProveedorNombreAux;
         obj30.gxTpr_Solicitudescostoxzona = A864SolicitudesCostoXZona;
         obj30.gxTpr_Mudanzaid = A735MudanzaId;
         obj30.gxTpr_Mudanzafechaservicio = A738MudanzaFechaServicio;
         obj30.gxTpr_Mudanzadireccionorigen = A740MudanzaDireccionOrigen;
         obj30.gxTpr_Mudanzadirecciondestino = A741MudanzaDireccionDestino;
         obj30.gxTpr_Postulacionesid = A422PostulacionesId;
         obj30.gxTpr_Solicitudesduplicado = A972SolicitudesDuplicado;
         obj30.gxTpr_Solicitudesserialarchivo = A992SolicitudesSerialArchivo;
         obj30.gxTpr_Cancelaciontipificaciondescripcion = A997CancelacionTipificacionDescrip;
         obj30.gxTpr_Solicitudescostopresupuesto = A1003SolicitudesCostoPresupuesto;
         obj30.gxTpr_Solicitudesurlorigen = A1006SolicitudesURLOrigen;
         obj30.gxTpr_Ticketid = A1020TicketId;
         obj30.gxTpr_Ticketmotivoid = A1021TicketMotivoId;
         obj30.gxTpr_Ticketmotivodescripcion = A1022TicketMotivoDescripcion;
         obj30.gxTpr_Ticketcomentario = A1024TicketComentario;
         obj30.gxTpr_Ticketadjunto = A1026TicketAdjunto;
         obj30.gxTpr_Ticketestado = A1030TicketEstado;
         obj30.gxTpr_Ticketsolicitudid = A1023TicketSolicitudId;
         obj30.gxTpr_Paisid = A116PaisID;
         obj30.gxTpr_Departamentoid = A112DepartamentoId;
         obj30.gxTpr_Stmonedasid = A669STMonedasId;
         obj30.gxTpr_Cuponid = A1013CuponId;
         obj30.gxTpr_Estadossoltipo = A130EstadosSolTipo;
         obj30.gxTpr_Estadossolid = A131EstadosSolId;
         obj30.gxTpr_Solicitudesotros1 = A201SolicitudesOtros1;
         obj30.gxTpr_Proveedorid = A133ProveedorID;
         obj30.gxTpr_Solicitudessubtipo = A600SolicitudesSubTipo;
         obj30.gxTpr_Cancelaciontipificacionid = A996CancelacionTipificacionId;
         obj30.gxTpr_Solicitudesid = A127SolicitudesID;
         obj30.gxTpr_Solicitudesid_Z = Z127SolicitudesID;
         obj30.gxTpr_Solicitudesnombre_Z = Z171SolicitudesNombre;
         obj30.gxTpr_Solicitudestelefono_Z = Z172SolicitudesTelefono;
         obj30.gxTpr_Solicitudesmail_Z = Z206SolicitudesMail;
         obj30.gxTpr_Paisid_Z = Z116PaisID;
         obj30.gxTpr_Departamentoid_Z = Z112DepartamentoId;
         obj30.gxTpr_Departamentomunicipioid_Z = Z114DepartamentoMunicipioId;
         obj30.gxTpr_Zonasid_Z = Z110ZonasID;
         obj30.gxTpr_Solicitudesdireccion_Z = Z173SolicitudesDireccion;
         obj30.gxTpr_Solicitudesautoenumerar_Z = Z194SolicitudesAutoEnumerar;
         obj30.gxTpr_Stmonedasid_Z = Z669STMonedasId;
         obj30.gxTpr_Stmonedasiso_Z = Z671STMonedasISO;
         obj30.gxTpr_Solicitudesliqprof_Z = Z688SolicitudesLiqProf;
         obj30.gxTpr_Solicitudesliqprov_Z = Z689SolicitudesLiqProv;
         obj30.gxTpr_Solicitudescotizacion_Z = Z212SolicitudesCotizacion;
         obj30.gxTpr_Solicitudestotal_Z = Z174SolicitudesTotal;
         obj30.gxTpr_Solicitudserviciosolcoti_Z = Z210SolicitudServicioSolCoti;
         obj30.gxTpr_Solicitudserviciopfinal_Z = Z211SolicitudServicioPFinal;
         obj30.gxTpr_Solicitudesdescuento_Z = Z897SolicitudesDescuento;
         obj30.gxTpr_Cuponid_Z = Z1013CuponId;
         obj30.gxTpr_Cuponpercent_Z = Z1014CuponPercent;
         obj30.gxTpr_Solicitudesdescuentocupon_Z = Z1016SolicitudesDescuentoCupon;
         obj30.gxTpr_Solicitudescomisionmetodopago_Z = Z796SolicitudesComisionMetodoPago;
         obj30.gxTpr_Estadossoltipo_Z = Z130EstadosSolTipo;
         obj30.gxTpr_Estadossolid_Z = Z131EstadosSolId;
         obj30.gxTpr_Estadossolnombre_Z = Z132EstadosSolNombre;
         obj30.gxTpr_Solicitudesotros1_Z = Z201SolicitudesOtros1;
         obj30.gxTpr_Solicitudesotros2_Z = Z202SolicitudesOtros2;
         obj30.gxTpr_Solicitudesotros3_Z = Z203SolicitudesOtros3;
         obj30.gxTpr_Solicitudesusralta_Z = Z597SolicitudesUsrAlta;
         obj30.gxTpr_Solicitudesusractualizacion_Z = Z598SolicitudesUsrActualizacion;
         obj30.gxTpr_Solicitudesfechaalta_Z = Z182SolicitudesFechaAlta;
         obj30.gxTpr_Solicitudesfechaactualizacion_Z = Z204SolicitudesFechaActualizacion;
         obj30.gxTpr_Solicitudesfechainstalacion_Z = Z184SolicitudesFechaInstalacion;
         obj30.gxTpr_Solicitudeshorainstalacion_Z = Z183SolicitudesHoraInstalacion;
         obj30.gxTpr_Metodopagosid_Z = Z128MetodoPagosID;
         obj30.gxTpr_Metodopagosnombre_Z = Z129MetodoPagosNombre;
         obj30.gxTpr_Solicitudesnota_Z = Z261SolicitudesNota;
         obj30.gxTpr_Solicitudesnotificacion_Z = Z262SolicitudesNotificacion;
         obj30.gxTpr_Proveedorid_Z = Z133ProveedorID;
         obj30.gxTpr_Proveedornombre_Z = Z282ProveedorNombre;
         obj30.gxTpr_Proveedorpagodefault_Z = Z440ProveedorPagoDefault;
         obj30.gxTpr_Stcomerciosid_Z = Z919STComerciosID;
         obj30.gxTpr_Stcomerciosnombre_Z = Z923STComerciosNombre;
         obj30.gxTpr_Stcomerciosestado_Z = Z924STComerciosEstado;
         obj30.gxTpr_Solicitudservicioorigenpago_Z = Z438SolicitudServicioOrigenPago;
         obj30.gxTpr_Solicitudespagado_Z = Z441SolicitudesPagado;
         obj30.gxTpr_Solicitudserviciocomprov_Z = Z527SolicitudServicioComProv;
         obj30.gxTpr_Solicitudserviciocomprovp_Z = Z528SolicitudServicioComProvP;
         obj30.gxTpr_Solicitudserviciocomalm_Z = Z530SolicitudServicioComALM;
         obj30.gxTpr_Solicitudserviciocomalmp_Z = Z532SolicitudServicioComALMP;
         obj30.gxTpr_Solicitudserviciocompro_Z = Z529SolicitudServicioComPro;
         obj30.gxTpr_Solicitudserviciocomprop_Z = Z531SolicitudServicioComProP;
         obj30.gxTpr_Solicitudescalcomi_Z = Z672SolicitudesCalComi;
         obj30.gxTpr_Proveedornombreaux_Z = Z533ProveedorNombreAux;
         obj30.gxTpr_Solicitudessubtipo_Z = Z600SolicitudesSubTipo;
         obj30.gxTpr_Solicitudescostoxzona_Z = Z864SolicitudesCostoXZona;
         obj30.gxTpr_Solicitudescostoxzcomalm_Z = Z865SolicitudesCostoXZComAlm;
         obj30.gxTpr_Solicitudescostoxzcomalmp_Z = Z866SolicitudesCostoXZComAlmP;
         obj30.gxTpr_Solicitudescostoxzcomprof_Z = Z867SolicitudesCostoXZComProf;
         obj30.gxTpr_Solicitudescostoxzcomprofp_Z = Z868SolicitudesCostoXZComProfP;
         obj30.gxTpr_Mudanzaid_Z = Z735MudanzaId;
         obj30.gxTpr_Mudanzafechaservicio_Z = Z738MudanzaFechaServicio;
         obj30.gxTpr_Mudanzadireccionorigen_Z = Z740MudanzaDireccionOrigen;
         obj30.gxTpr_Mudanzadirecciondestino_Z = Z741MudanzaDireccionDestino;
         obj30.gxTpr_Postulacionesid_Z = Z422PostulacionesId;
         obj30.gxTpr_Solicitudesduplicado_Z = Z972SolicitudesDuplicado;
         obj30.gxTpr_Solicitudesserialarchivo_Z = Z992SolicitudesSerialArchivo;
         obj30.gxTpr_Cancelaciontipificacionid_Z = Z996CancelacionTipificacionId;
         obj30.gxTpr_Cancelaciontipificaciondescripcion_Z = Z997CancelacionTipificacionDescrip;
         obj30.gxTpr_Solicitudescostopresupuesto_Z = Z1003SolicitudesCostoPresupuesto;
         obj30.gxTpr_Solicitudesurlorigen_Z = Z1006SolicitudesURLOrigen;
         obj30.gxTpr_Ticketid_Z = Z1020TicketId;
         obj30.gxTpr_Ticketmotivoid_Z = Z1021TicketMotivoId;
         obj30.gxTpr_Ticketmotivodescripcion_Z = Z1022TicketMotivoDescripcion;
         obj30.gxTpr_Ticketcomentario_Z = Z1024TicketComentario;
         obj30.gxTpr_Ticketadjunto_Z = Z1026TicketAdjunto;
         obj30.gxTpr_Ticketestado_Z = Z1030TicketEstado;
         obj30.gxTpr_Ticketsolicitudid_Z = Z1023TicketSolicitudId;
         obj30.gxTpr_Solicitudesmail_N = (short)(Convert.ToInt16(n206SolicitudesMail));
         obj30.gxTpr_Departamentoid_N = (short)(Convert.ToInt16(n112DepartamentoId));
         obj30.gxTpr_Departamentomunicipioid_N = (short)(Convert.ToInt16(n114DepartamentoMunicipioId));
         obj30.gxTpr_Zonasid_N = (short)(Convert.ToInt16(n110ZonasID));
         obj30.gxTpr_Stmonedasid_N = (short)(Convert.ToInt16(n669STMonedasId));
         obj30.gxTpr_Solicitudesliqprof_N = (short)(Convert.ToInt16(n688SolicitudesLiqProf));
         obj30.gxTpr_Solicitudesliqprov_N = (short)(Convert.ToInt16(n689SolicitudesLiqProv));
         obj30.gxTpr_Solicitudesdescuento_N = (short)(Convert.ToInt16(n897SolicitudesDescuento));
         obj30.gxTpr_Cuponid_N = (short)(Convert.ToInt16(n1013CuponId));
         obj30.gxTpr_Solicitudesusralta_N = (short)(Convert.ToInt16(n597SolicitudesUsrAlta));
         obj30.gxTpr_Solicitudesusractualizacion_N = (short)(Convert.ToInt16(n598SolicitudesUsrActualizacion));
         obj30.gxTpr_Solicitudesfechaalta_N = (short)(Convert.ToInt16(n182SolicitudesFechaAlta));
         obj30.gxTpr_Solicitudesfechaactualizacion_N = (short)(Convert.ToInt16(n204SolicitudesFechaActualizacion));
         obj30.gxTpr_Stcomerciosid_N = (short)(Convert.ToInt16(n919STComerciosID));
         obj30.gxTpr_Solicitudservicioorigenpago_N = (short)(Convert.ToInt16(n438SolicitudServicioOrigenPago));
         obj30.gxTpr_Solicitudespagado_N = (short)(Convert.ToInt16(n441SolicitudesPagado));
         obj30.gxTpr_Solicitudserviciocomprov_N = (short)(Convert.ToInt16(n527SolicitudServicioComProv));
         obj30.gxTpr_Solicitudserviciocomprovp_N = (short)(Convert.ToInt16(n528SolicitudServicioComProvP));
         obj30.gxTpr_Solicitudserviciocomalm_N = (short)(Convert.ToInt16(n530SolicitudServicioComALM));
         obj30.gxTpr_Solicitudserviciocomalmp_N = (short)(Convert.ToInt16(n532SolicitudServicioComALMP));
         obj30.gxTpr_Proveedornombreaux_N = (short)(Convert.ToInt16(n533ProveedorNombreAux));
         obj30.gxTpr_Solicitudessubtipo_N = (short)(Convert.ToInt16(n600SolicitudesSubTipo));
         obj30.gxTpr_Solicitudescostoxzcomalm_N = (short)(Convert.ToInt16(n865SolicitudesCostoXZComAlm));
         obj30.gxTpr_Solicitudescostoxzcomalmp_N = (short)(Convert.ToInt16(n866SolicitudesCostoXZComAlmP));
         obj30.gxTpr_Mudanzaid_N = (short)(Convert.ToInt16(n735MudanzaId));
         obj30.gxTpr_Postulacionesid_N = (short)(Convert.ToInt16(n422PostulacionesId));
         obj30.gxTpr_Solicitudesduplicado_N = (short)(Convert.ToInt16(n972SolicitudesDuplicado));
         obj30.gxTpr_Solicitudescostopresupuesto_N = (short)(Convert.ToInt16(n1003SolicitudesCostoPresupuesto));
         obj30.gxTpr_Solicitudesurlorigen_N = (short)(Convert.ToInt16(n1006SolicitudesURLOrigen));
         obj30.gxTpr_Ticketid_N = (short)(Convert.ToInt16(n1020TicketId));
         obj30.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow30( SdtSolicitudes obj30 )
      {
         obj30.gxTpr_Solicitudesid = A127SolicitudesID;
         return  ;
      }

      public void RowToVars30( SdtSolicitudes obj30 ,
                               int forceLoad )
      {
         Gx_mode = obj30.gxTpr_Mode;
         A438SolicitudServicioOrigenPago = obj30.gxTpr_Solicitudservicioorigenpago;
         n438SolicitudServicioOrigenPago = false;
         A866SolicitudesCostoXZComAlmP = obj30.gxTpr_Solicitudescostoxzcomalmp;
         n866SolicitudesCostoXZComAlmP = false;
         A865SolicitudesCostoXZComAlm = obj30.gxTpr_Solicitudescostoxzcomalm;
         n865SolicitudesCostoXZComAlm = false;
         A182SolicitudesFechaAlta = obj30.gxTpr_Solicitudesfechaalta;
         n182SolicitudesFechaAlta = false;
         A868SolicitudesCostoXZComProfP = obj30.gxTpr_Solicitudescostoxzcomprofp;
         A867SolicitudesCostoXZComProf = obj30.gxTpr_Solicitudescostoxzcomprof;
         A531SolicitudServicioComProP = obj30.gxTpr_Solicitudserviciocomprop;
         A529SolicitudServicioComPro = obj30.gxTpr_Solicitudserviciocompro;
         A211SolicitudServicioPFinal = obj30.gxTpr_Solicitudserviciopfinal;
         A171SolicitudesNombre = obj30.gxTpr_Solicitudesnombre;
         A172SolicitudesTelefono = obj30.gxTpr_Solicitudestelefono;
         A206SolicitudesMail = obj30.gxTpr_Solicitudesmail;
         n206SolicitudesMail = false;
         A114DepartamentoMunicipioId = obj30.gxTpr_Departamentomunicipioid;
         n114DepartamentoMunicipioId = false;
         A110ZonasID = obj30.gxTpr_Zonasid;
         n110ZonasID = false;
         A173SolicitudesDireccion = obj30.gxTpr_Solicitudesdireccion;
         if ( forceLoad == 1 )
         {
            A194SolicitudesAutoEnumerar = obj30.gxTpr_Solicitudesautoenumerar;
         }
         A671STMonedasISO = obj30.gxTpr_Stmonedasiso;
         A688SolicitudesLiqProf = obj30.gxTpr_Solicitudesliqprof;
         n688SolicitudesLiqProf = false;
         A689SolicitudesLiqProv = obj30.gxTpr_Solicitudesliqprov;
         n689SolicitudesLiqProv = false;
         A212SolicitudesCotizacion = obj30.gxTpr_Solicitudescotizacion;
         A174SolicitudesTotal = obj30.gxTpr_Solicitudestotal;
         A210SolicitudServicioSolCoti = obj30.gxTpr_Solicitudserviciosolcoti;
         A897SolicitudesDescuento = obj30.gxTpr_Solicitudesdescuento;
         n897SolicitudesDescuento = false;
         A1014CuponPercent = obj30.gxTpr_Cuponpercent;
         A1016SolicitudesDescuentoCupon = obj30.gxTpr_Solicitudesdescuentocupon;
         if ( ! ( ( StringUtil.StrCmp(obj30.gxTpr_Solicitudespagado, context.GetMessage( "S", "")) == 0 ) ) || ( forceLoad == 1 ) )
         {
            A796SolicitudesComisionMetodoPago = obj30.gxTpr_Solicitudescomisionmetodopago;
         }
         A132EstadosSolNombre = obj30.gxTpr_Estadossolnombre;
         A202SolicitudesOtros2 = obj30.gxTpr_Solicitudesotros2;
         A203SolicitudesOtros3 = obj30.gxTpr_Solicitudesotros3;
         A597SolicitudesUsrAlta = obj30.gxTpr_Solicitudesusralta;
         n597SolicitudesUsrAlta = false;
         A598SolicitudesUsrActualizacion = obj30.gxTpr_Solicitudesusractualizacion;
         n598SolicitudesUsrActualizacion = false;
         A204SolicitudesFechaActualizacion = obj30.gxTpr_Solicitudesfechaactualizacion;
         n204SolicitudesFechaActualizacion = false;
         A184SolicitudesFechaInstalacion = obj30.gxTpr_Solicitudesfechainstalacion;
         A183SolicitudesHoraInstalacion = obj30.gxTpr_Solicitudeshorainstalacion;
         A205SolicitudesComentario = obj30.gxTpr_Solicitudescomentario;
         A128MetodoPagosID = obj30.gxTpr_Metodopagosid;
         A129MetodoPagosNombre = obj30.gxTpr_Metodopagosnombre;
         A261SolicitudesNota = obj30.gxTpr_Solicitudesnota;
         A262SolicitudesNotificacion = obj30.gxTpr_Solicitudesnotificacion;
         A282ProveedorNombre = obj30.gxTpr_Proveedornombre;
         A440ProveedorPagoDefault = obj30.gxTpr_Proveedorpagodefault;
         A919STComerciosID = obj30.gxTpr_Stcomerciosid;
         n919STComerciosID = false;
         A923STComerciosNombre = obj30.gxTpr_Stcomerciosnombre;
         A924STComerciosEstado = obj30.gxTpr_Stcomerciosestado;
         A441SolicitudesPagado = obj30.gxTpr_Solicitudespagado;
         n441SolicitudesPagado = false;
         A527SolicitudServicioComProv = obj30.gxTpr_Solicitudserviciocomprov;
         n527SolicitudServicioComProv = false;
         A528SolicitudServicioComProvP = obj30.gxTpr_Solicitudserviciocomprovp;
         n528SolicitudServicioComProvP = false;
         A530SolicitudServicioComALM = obj30.gxTpr_Solicitudserviciocomalm;
         n530SolicitudServicioComALM = false;
         A532SolicitudServicioComALMP = obj30.gxTpr_Solicitudserviciocomalmp;
         n532SolicitudServicioComALMP = false;
         A672SolicitudesCalComi = obj30.gxTpr_Solicitudescalcomi;
         A533ProveedorNombreAux = obj30.gxTpr_Proveedornombreaux;
         n533ProveedorNombreAux = false;
         A864SolicitudesCostoXZona = obj30.gxTpr_Solicitudescostoxzona;
         A735MudanzaId = obj30.gxTpr_Mudanzaid;
         n735MudanzaId = false;
         A738MudanzaFechaServicio = obj30.gxTpr_Mudanzafechaservicio;
         A740MudanzaDireccionOrigen = obj30.gxTpr_Mudanzadireccionorigen;
         A741MudanzaDireccionDestino = obj30.gxTpr_Mudanzadirecciondestino;
         A422PostulacionesId = obj30.gxTpr_Postulacionesid;
         n422PostulacionesId = false;
         A972SolicitudesDuplicado = obj30.gxTpr_Solicitudesduplicado;
         n972SolicitudesDuplicado = false;
         if ( forceLoad == 1 )
         {
            A992SolicitudesSerialArchivo = obj30.gxTpr_Solicitudesserialarchivo;
         }
         A997CancelacionTipificacionDescrip = obj30.gxTpr_Cancelaciontipificaciondescripcion;
         A1003SolicitudesCostoPresupuesto = obj30.gxTpr_Solicitudescostopresupuesto;
         n1003SolicitudesCostoPresupuesto = false;
         A1006SolicitudesURLOrigen = obj30.gxTpr_Solicitudesurlorigen;
         n1006SolicitudesURLOrigen = false;
         A1020TicketId = obj30.gxTpr_Ticketid;
         n1020TicketId = false;
         A1021TicketMotivoId = obj30.gxTpr_Ticketmotivoid;
         A1022TicketMotivoDescripcion = obj30.gxTpr_Ticketmotivodescripcion;
         A1024TicketComentario = obj30.gxTpr_Ticketcomentario;
         A1026TicketAdjunto = obj30.gxTpr_Ticketadjunto;
         A1030TicketEstado = obj30.gxTpr_Ticketestado;
         A1023TicketSolicitudId = obj30.gxTpr_Ticketsolicitudid;
         A116PaisID = obj30.gxTpr_Paisid;
         if ( ! ( IsUpd( )  ) || ( forceLoad == 1 ) )
         {
            A112DepartamentoId = obj30.gxTpr_Departamentoid;
            n112DepartamentoId = false;
         }
         A669STMonedasId = obj30.gxTpr_Stmonedasid;
         n669STMonedasId = false;
         A1013CuponId = obj30.gxTpr_Cuponid;
         n1013CuponId = false;
         A130EstadosSolTipo = obj30.gxTpr_Estadossoltipo;
         A131EstadosSolId = obj30.gxTpr_Estadossolid;
         A201SolicitudesOtros1 = obj30.gxTpr_Solicitudesotros1;
         A133ProveedorID = obj30.gxTpr_Proveedorid;
         A600SolicitudesSubTipo = obj30.gxTpr_Solicitudessubtipo;
         n600SolicitudesSubTipo = false;
         A996CancelacionTipificacionId = obj30.gxTpr_Cancelaciontipificacionid;
         A127SolicitudesID = obj30.gxTpr_Solicitudesid;
         Z127SolicitudesID = obj30.gxTpr_Solicitudesid_Z;
         Z171SolicitudesNombre = obj30.gxTpr_Solicitudesnombre_Z;
         Z172SolicitudesTelefono = obj30.gxTpr_Solicitudestelefono_Z;
         Z206SolicitudesMail = obj30.gxTpr_Solicitudesmail_Z;
         Z116PaisID = obj30.gxTpr_Paisid_Z;
         Z112DepartamentoId = obj30.gxTpr_Departamentoid_Z;
         Z114DepartamentoMunicipioId = obj30.gxTpr_Departamentomunicipioid_Z;
         Z110ZonasID = obj30.gxTpr_Zonasid_Z;
         Z173SolicitudesDireccion = obj30.gxTpr_Solicitudesdireccion_Z;
         Z194SolicitudesAutoEnumerar = obj30.gxTpr_Solicitudesautoenumerar_Z;
         O194SolicitudesAutoEnumerar = obj30.gxTpr_Solicitudesautoenumerar_Z;
         Z669STMonedasId = obj30.gxTpr_Stmonedasid_Z;
         Z671STMonedasISO = obj30.gxTpr_Stmonedasiso_Z;
         Z688SolicitudesLiqProf = obj30.gxTpr_Solicitudesliqprof_Z;
         Z689SolicitudesLiqProv = obj30.gxTpr_Solicitudesliqprov_Z;
         Z212SolicitudesCotizacion = obj30.gxTpr_Solicitudescotizacion_Z;
         O212SolicitudesCotizacion = obj30.gxTpr_Solicitudescotizacion_Z;
         Z174SolicitudesTotal = obj30.gxTpr_Solicitudestotal_Z;
         O174SolicitudesTotal = obj30.gxTpr_Solicitudestotal_Z;
         Z210SolicitudServicioSolCoti = obj30.gxTpr_Solicitudserviciosolcoti_Z;
         Z211SolicitudServicioPFinal = obj30.gxTpr_Solicitudserviciopfinal_Z;
         O211SolicitudServicioPFinal = obj30.gxTpr_Solicitudserviciopfinal_Z;
         Z897SolicitudesDescuento = obj30.gxTpr_Solicitudesdescuento_Z;
         Z1013CuponId = obj30.gxTpr_Cuponid_Z;
         Z1014CuponPercent = obj30.gxTpr_Cuponpercent_Z;
         Z1016SolicitudesDescuentoCupon = obj30.gxTpr_Solicitudesdescuentocupon_Z;
         Z796SolicitudesComisionMetodoPago = obj30.gxTpr_Solicitudescomisionmetodopago_Z;
         Z130EstadosSolTipo = obj30.gxTpr_Estadossoltipo_Z;
         Z131EstadosSolId = obj30.gxTpr_Estadossolid_Z;
         O131EstadosSolId = obj30.gxTpr_Estadossolid_Z;
         Z132EstadosSolNombre = obj30.gxTpr_Estadossolnombre_Z;
         Z201SolicitudesOtros1 = obj30.gxTpr_Solicitudesotros1_Z;
         Z202SolicitudesOtros2 = obj30.gxTpr_Solicitudesotros2_Z;
         Z203SolicitudesOtros3 = obj30.gxTpr_Solicitudesotros3_Z;
         Z597SolicitudesUsrAlta = obj30.gxTpr_Solicitudesusralta_Z;
         Z598SolicitudesUsrActualizacion = obj30.gxTpr_Solicitudesusractualizacion_Z;
         Z182SolicitudesFechaAlta = obj30.gxTpr_Solicitudesfechaalta_Z;
         Z204SolicitudesFechaActualizacion = obj30.gxTpr_Solicitudesfechaactualizacion_Z;
         Z184SolicitudesFechaInstalacion = obj30.gxTpr_Solicitudesfechainstalacion_Z;
         Z183SolicitudesHoraInstalacion = obj30.gxTpr_Solicitudeshorainstalacion_Z;
         Z128MetodoPagosID = obj30.gxTpr_Metodopagosid_Z;
         Z129MetodoPagosNombre = obj30.gxTpr_Metodopagosnombre_Z;
         Z261SolicitudesNota = obj30.gxTpr_Solicitudesnota_Z;
         Z262SolicitudesNotificacion = obj30.gxTpr_Solicitudesnotificacion_Z;
         Z133ProveedorID = obj30.gxTpr_Proveedorid_Z;
         O133ProveedorID = obj30.gxTpr_Proveedorid_Z;
         Z282ProveedorNombre = obj30.gxTpr_Proveedornombre_Z;
         Z440ProveedorPagoDefault = obj30.gxTpr_Proveedorpagodefault_Z;
         Z919STComerciosID = obj30.gxTpr_Stcomerciosid_Z;
         Z923STComerciosNombre = obj30.gxTpr_Stcomerciosnombre_Z;
         Z924STComerciosEstado = obj30.gxTpr_Stcomerciosestado_Z;
         Z438SolicitudServicioOrigenPago = obj30.gxTpr_Solicitudservicioorigenpago_Z;
         Z441SolicitudesPagado = obj30.gxTpr_Solicitudespagado_Z;
         Z527SolicitudServicioComProv = obj30.gxTpr_Solicitudserviciocomprov_Z;
         Z528SolicitudServicioComProvP = obj30.gxTpr_Solicitudserviciocomprovp_Z;
         Z530SolicitudServicioComALM = obj30.gxTpr_Solicitudserviciocomalm_Z;
         Z532SolicitudServicioComALMP = obj30.gxTpr_Solicitudserviciocomalmp_Z;
         Z529SolicitudServicioComPro = obj30.gxTpr_Solicitudserviciocompro_Z;
         Z531SolicitudServicioComProP = obj30.gxTpr_Solicitudserviciocomprop_Z;
         Z672SolicitudesCalComi = obj30.gxTpr_Solicitudescalcomi_Z;
         Z533ProveedorNombreAux = obj30.gxTpr_Proveedornombreaux_Z;
         Z600SolicitudesSubTipo = obj30.gxTpr_Solicitudessubtipo_Z;
         Z864SolicitudesCostoXZona = obj30.gxTpr_Solicitudescostoxzona_Z;
         Z865SolicitudesCostoXZComAlm = obj30.gxTpr_Solicitudescostoxzcomalm_Z;
         Z866SolicitudesCostoXZComAlmP = obj30.gxTpr_Solicitudescostoxzcomalmp_Z;
         Z867SolicitudesCostoXZComProf = obj30.gxTpr_Solicitudescostoxzcomprof_Z;
         Z868SolicitudesCostoXZComProfP = obj30.gxTpr_Solicitudescostoxzcomprofp_Z;
         Z735MudanzaId = obj30.gxTpr_Mudanzaid_Z;
         Z738MudanzaFechaServicio = obj30.gxTpr_Mudanzafechaservicio_Z;
         Z740MudanzaDireccionOrigen = obj30.gxTpr_Mudanzadireccionorigen_Z;
         Z741MudanzaDireccionDestino = obj30.gxTpr_Mudanzadirecciondestino_Z;
         Z422PostulacionesId = obj30.gxTpr_Postulacionesid_Z;
         Z972SolicitudesDuplicado = obj30.gxTpr_Solicitudesduplicado_Z;
         Z992SolicitudesSerialArchivo = obj30.gxTpr_Solicitudesserialarchivo_Z;
         O992SolicitudesSerialArchivo = obj30.gxTpr_Solicitudesserialarchivo_Z;
         Z996CancelacionTipificacionId = obj30.gxTpr_Cancelaciontipificacionid_Z;
         Z997CancelacionTipificacionDescrip = obj30.gxTpr_Cancelaciontipificaciondescripcion_Z;
         Z1003SolicitudesCostoPresupuesto = obj30.gxTpr_Solicitudescostopresupuesto_Z;
         Z1006SolicitudesURLOrigen = obj30.gxTpr_Solicitudesurlorigen_Z;
         Z1020TicketId = obj30.gxTpr_Ticketid_Z;
         Z1021TicketMotivoId = obj30.gxTpr_Ticketmotivoid_Z;
         Z1022TicketMotivoDescripcion = obj30.gxTpr_Ticketmotivodescripcion_Z;
         Z1024TicketComentario = obj30.gxTpr_Ticketcomentario_Z;
         Z1026TicketAdjunto = obj30.gxTpr_Ticketadjunto_Z;
         Z1030TicketEstado = obj30.gxTpr_Ticketestado_Z;
         Z1023TicketSolicitudId = obj30.gxTpr_Ticketsolicitudid_Z;
         n206SolicitudesMail = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudesmail_N));
         n112DepartamentoId = (bool)(Convert.ToBoolean(obj30.gxTpr_Departamentoid_N));
         n114DepartamentoMunicipioId = (bool)(Convert.ToBoolean(obj30.gxTpr_Departamentomunicipioid_N));
         n110ZonasID = (bool)(Convert.ToBoolean(obj30.gxTpr_Zonasid_N));
         n669STMonedasId = (bool)(Convert.ToBoolean(obj30.gxTpr_Stmonedasid_N));
         n688SolicitudesLiqProf = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudesliqprof_N));
         n689SolicitudesLiqProv = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudesliqprov_N));
         n897SolicitudesDescuento = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudesdescuento_N));
         n1013CuponId = (bool)(Convert.ToBoolean(obj30.gxTpr_Cuponid_N));
         n597SolicitudesUsrAlta = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudesusralta_N));
         n598SolicitudesUsrActualizacion = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudesusractualizacion_N));
         n182SolicitudesFechaAlta = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudesfechaalta_N));
         n204SolicitudesFechaActualizacion = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudesfechaactualizacion_N));
         n919STComerciosID = (bool)(Convert.ToBoolean(obj30.gxTpr_Stcomerciosid_N));
         n438SolicitudServicioOrigenPago = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudservicioorigenpago_N));
         n441SolicitudesPagado = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudespagado_N));
         n527SolicitudServicioComProv = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudserviciocomprov_N));
         n528SolicitudServicioComProvP = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudserviciocomprovp_N));
         n530SolicitudServicioComALM = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudserviciocomalm_N));
         n532SolicitudServicioComALMP = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudserviciocomalmp_N));
         n533ProveedorNombreAux = (bool)(Convert.ToBoolean(obj30.gxTpr_Proveedornombreaux_N));
         n600SolicitudesSubTipo = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudessubtipo_N));
         n865SolicitudesCostoXZComAlm = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudescostoxzcomalm_N));
         n866SolicitudesCostoXZComAlmP = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudescostoxzcomalmp_N));
         n735MudanzaId = (bool)(Convert.ToBoolean(obj30.gxTpr_Mudanzaid_N));
         n422PostulacionesId = (bool)(Convert.ToBoolean(obj30.gxTpr_Postulacionesid_N));
         n972SolicitudesDuplicado = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudesduplicado_N));
         n1003SolicitudesCostoPresupuesto = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudescostopresupuesto_N));
         n1006SolicitudesURLOrigen = (bool)(Convert.ToBoolean(obj30.gxTpr_Solicitudesurlorigen_N));
         n1020TicketId = (bool)(Convert.ToBoolean(obj30.gxTpr_Ticketid_N));
         Gx_mode = obj30.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow31( SdtSolicitudes_Items obj31 )
      {
         obj31.gxTpr_Mode = Gx_mode;
         obj31.gxTpr_Solicituditemscomision = A180SolicitudItemsComision;
         obj31.gxTpr_Solicituditemssr = A178SolicitudItemsSR;
         obj31.gxTpr_Solicituditemscomisiontipo = A179SolicitudItemsComisionTipo;
         obj31.gxTpr_Solicitudesitemscomiprofp = A525SolicitudesItemsComiProfP;
         obj31.gxTpr_Solicitudesitemscomiprof = A522SolicitudesItemsComiProf;
         obj31.gxTpr_Solicitudesitemsprecioinstalacion = A175SolicitudesItemsPrecioInstalac;
         obj31.gxTpr_Solicitudesprecioesfreezado = A1002SolicitudesPrecioEsFreezado;
         obj31.gxTpr_Rubrosid = A121RubrosId;
         obj31.gxTpr_Rubrosimagen = A168RubrosImagen;
         obj31.gxTpr_Rubrosimagen_gxi = A40000RubrosImagen_GXI;
         obj31.gxTpr_Rubrosestado = A123RubrosEstado;
         obj31.gxTpr_Medidasid = A137MedidasID;
         obj31.gxTpr_Inventarioid = A135InventarioId;
         obj31.gxTpr_Inventarionombre = A136InventarioNombre;
         obj31.gxTpr_Inventarioimagen = A189InventarioImagen;
         obj31.gxTpr_Inventarioimagen_gxi = A40001InventarioImagen_GXI;
         obj31.gxTpr_Inventariopreciofinal = A181InventarioPrecioFinal;
         obj31.gxTpr_Inventarioconsumoproductivo = A801InventarioConsumoProductivo;
         obj31.gxTpr_Estadostipo = A107EstadosTipo;
         obj31.gxTpr_Estadosgenericosid = A108EstadosGenericosId;
         obj31.gxTpr_Solicitudesitemspreciofinal = A176SolicitudesItemsPrecioFinal;
         obj31.gxTpr_Monedaid = A118MonedaId;
         obj31.gxTpr_Monedaisosimbolo = A119MonedaISOSimbolo;
         obj31.gxTpr_Solicitudesitemscomiprov = A521SolicitudesItemsComiProv;
         obj31.gxTpr_Solicitudesitemscomiprovp = A524SolicitudesItemsComiProvP;
         obj31.gxTpr_Solicitudesitemscomialm = A523SolicitudesItemsComiALM;
         obj31.gxTpr_Solicitudesitemscomialmp = A526SolicitudesItemsComiALMP;
         obj31.gxTpr_Solicitudesitemscantidad = A177SolicitudesItemsCantidad;
         obj31.gxTpr_Solicitudesitemsid = A134SolicitudesItemsID;
         obj31.gxTpr_Solicitudesitemsid_Z = Z134SolicitudesItemsID;
         obj31.gxTpr_Rubrosid_Z = Z121RubrosId;
         obj31.gxTpr_Rubrosestado_Z = Z123RubrosEstado;
         obj31.gxTpr_Medidasid_Z = Z137MedidasID;
         obj31.gxTpr_Inventarioid_Z = Z135InventarioId;
         obj31.gxTpr_Inventarionombre_Z = Z136InventarioNombre;
         obj31.gxTpr_Inventariopreciofinal_Z = Z181InventarioPrecioFinal;
         obj31.gxTpr_Inventarioconsumoproductivo_Z = Z801InventarioConsumoProductivo;
         obj31.gxTpr_Estadostipo_Z = Z107EstadosTipo;
         obj31.gxTpr_Estadosgenericosid_Z = Z108EstadosGenericosId;
         obj31.gxTpr_Solicitudesitemspreciofinal_Z = Z176SolicitudesItemsPrecioFinal;
         obj31.gxTpr_Solicitudesprecioesfreezado_Z = Z1002SolicitudesPrecioEsFreezado;
         obj31.gxTpr_Solicitudesitemscantidad_Z = Z177SolicitudesItemsCantidad;
         obj31.gxTpr_Solicituditemscomision_Z = Z180SolicitudItemsComision;
         obj31.gxTpr_Solicituditemssr_Z = Z178SolicitudItemsSR;
         obj31.gxTpr_Solicituditemscomisiontipo_Z = Z179SolicitudItemsComisionTipo;
         obj31.gxTpr_Solicitudesitemsprecioinstalacion_Z = Z175SolicitudesItemsPrecioInstalac;
         obj31.gxTpr_Monedaid_Z = Z118MonedaId;
         obj31.gxTpr_Monedaisosimbolo_Z = Z119MonedaISOSimbolo;
         obj31.gxTpr_Solicitudesitemscomiprov_Z = Z521SolicitudesItemsComiProv;
         obj31.gxTpr_Solicitudesitemscomiprovp_Z = Z524SolicitudesItemsComiProvP;
         obj31.gxTpr_Solicitudesitemscomialm_Z = Z523SolicitudesItemsComiALM;
         obj31.gxTpr_Solicitudesitemscomialmp_Z = Z526SolicitudesItemsComiALMP;
         obj31.gxTpr_Solicitudesitemscomiprof_Z = Z522SolicitudesItemsComiProf;
         obj31.gxTpr_Solicitudesitemscomiprofp_Z = Z525SolicitudesItemsComiProfP;
         obj31.gxTpr_Rubrosimagen_gxi_Z = Z40000RubrosImagen_GXI;
         obj31.gxTpr_Inventarioimagen_gxi_Z = Z40001InventarioImagen_GXI;
         obj31.gxTpr_Rubrosestado_N = (short)(Convert.ToInt16(n123RubrosEstado));
         obj31.gxTpr_Solicitudesitemspreciofinal_N = (short)(Convert.ToInt16(n176SolicitudesItemsPrecioFinal));
         obj31.gxTpr_Solicitudesitemscomiprov_N = (short)(Convert.ToInt16(n521SolicitudesItemsComiProv));
         obj31.gxTpr_Solicitudesitemscomiprovp_N = (short)(Convert.ToInt16(n524SolicitudesItemsComiProvP));
         obj31.gxTpr_Solicitudesitemscomialm_N = (short)(Convert.ToInt16(n523SolicitudesItemsComiALM));
         obj31.gxTpr_Solicitudesitemscomialmp_N = (short)(Convert.ToInt16(n526SolicitudesItemsComiALMP));
         obj31.gxTpr_Modified = nIsMod_31;
         return  ;
      }

      public void KeyVarsToRow31( SdtSolicitudes_Items obj31 )
      {
         obj31.gxTpr_Solicitudesitemsid = A134SolicitudesItemsID;
         return  ;
      }

      public void RowToVars31( SdtSolicitudes_Items obj31 ,
                               int forceLoad )
      {
         Gx_mode = obj31.gxTpr_Mode;
         A180SolicitudItemsComision = obj31.gxTpr_Solicituditemscomision;
         A178SolicitudItemsSR = obj31.gxTpr_Solicituditemssr;
         A179SolicitudItemsComisionTipo = obj31.gxTpr_Solicituditemscomisiontipo;
         A525SolicitudesItemsComiProfP = obj31.gxTpr_Solicitudesitemscomiprofp;
         A522SolicitudesItemsComiProf = obj31.gxTpr_Solicitudesitemscomiprof;
         A175SolicitudesItemsPrecioInstalac = obj31.gxTpr_Solicitudesitemsprecioinstalacion;
         A1002SolicitudesPrecioEsFreezado = obj31.gxTpr_Solicitudesprecioesfreezado;
         A121RubrosId = obj31.gxTpr_Rubrosid;
         A168RubrosImagen = obj31.gxTpr_Rubrosimagen;
         A40000RubrosImagen_GXI = obj31.gxTpr_Rubrosimagen_gxi;
         A123RubrosEstado = obj31.gxTpr_Rubrosestado;
         n123RubrosEstado = false;
         A137MedidasID = obj31.gxTpr_Medidasid;
         A135InventarioId = obj31.gxTpr_Inventarioid;
         A136InventarioNombre = obj31.gxTpr_Inventarionombre;
         A189InventarioImagen = obj31.gxTpr_Inventarioimagen;
         A40001InventarioImagen_GXI = obj31.gxTpr_Inventarioimagen_gxi;
         A181InventarioPrecioFinal = obj31.gxTpr_Inventariopreciofinal;
         A801InventarioConsumoProductivo = obj31.gxTpr_Inventarioconsumoproductivo;
         A107EstadosTipo = obj31.gxTpr_Estadostipo;
         A108EstadosGenericosId = obj31.gxTpr_Estadosgenericosid;
         if ( forceLoad == 1 )
         {
            A176SolicitudesItemsPrecioFinal = obj31.gxTpr_Solicitudesitemspreciofinal;
            n176SolicitudesItemsPrecioFinal = false;
         }
         A118MonedaId = obj31.gxTpr_Monedaid;
         A119MonedaISOSimbolo = obj31.gxTpr_Monedaisosimbolo;
         if ( forceLoad == 1 )
         {
            A521SolicitudesItemsComiProv = obj31.gxTpr_Solicitudesitemscomiprov;
            n521SolicitudesItemsComiProv = false;
         }
         if ( forceLoad == 1 )
         {
            A524SolicitudesItemsComiProvP = obj31.gxTpr_Solicitudesitemscomiprovp;
            n524SolicitudesItemsComiProvP = false;
         }
         if ( forceLoad == 1 )
         {
            A523SolicitudesItemsComiALM = obj31.gxTpr_Solicitudesitemscomialm;
            n523SolicitudesItemsComiALM = false;
         }
         if ( forceLoad == 1 )
         {
            A526SolicitudesItemsComiALMP = obj31.gxTpr_Solicitudesitemscomialmp;
            n526SolicitudesItemsComiALMP = false;
         }
         A177SolicitudesItemsCantidad = obj31.gxTpr_Solicitudesitemscantidad;
         if ( forceLoad == 1 )
         {
            A134SolicitudesItemsID = obj31.gxTpr_Solicitudesitemsid;
         }
         Z134SolicitudesItemsID = obj31.gxTpr_Solicitudesitemsid_Z;
         Z121RubrosId = obj31.gxTpr_Rubrosid_Z;
         Z123RubrosEstado = obj31.gxTpr_Rubrosestado_Z;
         Z137MedidasID = obj31.gxTpr_Medidasid_Z;
         Z135InventarioId = obj31.gxTpr_Inventarioid_Z;
         Z136InventarioNombre = obj31.gxTpr_Inventarionombre_Z;
         Z181InventarioPrecioFinal = obj31.gxTpr_Inventariopreciofinal_Z;
         Z801InventarioConsumoProductivo = obj31.gxTpr_Inventarioconsumoproductivo_Z;
         Z107EstadosTipo = obj31.gxTpr_Estadostipo_Z;
         Z108EstadosGenericosId = obj31.gxTpr_Estadosgenericosid_Z;
         Z176SolicitudesItemsPrecioFinal = obj31.gxTpr_Solicitudesitemspreciofinal_Z;
         Z1002SolicitudesPrecioEsFreezado = obj31.gxTpr_Solicitudesprecioesfreezado_Z;
         Z177SolicitudesItemsCantidad = obj31.gxTpr_Solicitudesitemscantidad_Z;
         Z180SolicitudItemsComision = obj31.gxTpr_Solicituditemscomision_Z;
         Z178SolicitudItemsSR = obj31.gxTpr_Solicituditemssr_Z;
         Z179SolicitudItemsComisionTipo = obj31.gxTpr_Solicituditemscomisiontipo_Z;
         Z175SolicitudesItemsPrecioInstalac = obj31.gxTpr_Solicitudesitemsprecioinstalacion_Z;
         O175SolicitudesItemsPrecioInstalac = obj31.gxTpr_Solicitudesitemsprecioinstalacion_Z;
         Z118MonedaId = obj31.gxTpr_Monedaid_Z;
         Z119MonedaISOSimbolo = obj31.gxTpr_Monedaisosimbolo_Z;
         Z521SolicitudesItemsComiProv = obj31.gxTpr_Solicitudesitemscomiprov_Z;
         Z524SolicitudesItemsComiProvP = obj31.gxTpr_Solicitudesitemscomiprovp_Z;
         Z523SolicitudesItemsComiALM = obj31.gxTpr_Solicitudesitemscomialm_Z;
         Z526SolicitudesItemsComiALMP = obj31.gxTpr_Solicitudesitemscomialmp_Z;
         Z522SolicitudesItemsComiProf = obj31.gxTpr_Solicitudesitemscomiprof_Z;
         Z525SolicitudesItemsComiProfP = obj31.gxTpr_Solicitudesitemscomiprofp_Z;
         Z40000RubrosImagen_GXI = obj31.gxTpr_Rubrosimagen_gxi_Z;
         Z40001InventarioImagen_GXI = obj31.gxTpr_Inventarioimagen_gxi_Z;
         n123RubrosEstado = (bool)(Convert.ToBoolean(obj31.gxTpr_Rubrosestado_N));
         n176SolicitudesItemsPrecioFinal = (bool)(Convert.ToBoolean(obj31.gxTpr_Solicitudesitemspreciofinal_N));
         n521SolicitudesItemsComiProv = (bool)(Convert.ToBoolean(obj31.gxTpr_Solicitudesitemscomiprov_N));
         n524SolicitudesItemsComiProvP = (bool)(Convert.ToBoolean(obj31.gxTpr_Solicitudesitemscomiprovp_N));
         n523SolicitudesItemsComiALM = (bool)(Convert.ToBoolean(obj31.gxTpr_Solicitudesitemscomialm_N));
         n526SolicitudesItemsComiALMP = (bool)(Convert.ToBoolean(obj31.gxTpr_Solicitudesitemscomialmp_N));
         nIsMod_31 = obj31.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow144( SdtSolicitudes_Archivo obj144 )
      {
         obj144.gxTpr_Mode = Gx_mode;
         obj144.gxTpr_Archivodireccion = A989ArchivoDireccion;
         obj144.gxTpr_Archivodescripcion = A990ArchivoDescripcion;
         obj144.gxTpr_Archivotipo = A991ArchivoTipo;
         obj144.gxTpr_Archivoid = A988ArchivoId;
         obj144.gxTpr_Archivoid_Z = Z988ArchivoId;
         obj144.gxTpr_Archivodireccion_Z = Z989ArchivoDireccion;
         obj144.gxTpr_Archivodescripcion_Z = Z990ArchivoDescripcion;
         obj144.gxTpr_Archivotipo_Z = Z991ArchivoTipo;
         obj144.gxTpr_Modified = nIsMod_144;
         return  ;
      }

      public void KeyVarsToRow144( SdtSolicitudes_Archivo obj144 )
      {
         obj144.gxTpr_Archivoid = A988ArchivoId;
         return  ;
      }

      public void RowToVars144( SdtSolicitudes_Archivo obj144 ,
                                int forceLoad )
      {
         Gx_mode = obj144.gxTpr_Mode;
         A989ArchivoDireccion = obj144.gxTpr_Archivodireccion;
         A990ArchivoDescripcion = obj144.gxTpr_Archivodescripcion;
         A991ArchivoTipo = obj144.gxTpr_Archivotipo;
         A988ArchivoId = obj144.gxTpr_Archivoid;
         Z988ArchivoId = obj144.gxTpr_Archivoid_Z;
         Z989ArchivoDireccion = obj144.gxTpr_Archivodireccion_Z;
         Z990ArchivoDescripcion = obj144.gxTpr_Archivodescripcion_Z;
         Z991ArchivoTipo = obj144.gxTpr_Archivotipo_Z;
         nIsMod_144 = obj144.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A127SolicitudesID = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0O30( ) ;
         ScanKeyStart0O30( ) ;
         if ( RcdFound30 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z127SolicitudesID = A127SolicitudesID;
            O992SolicitudesSerialArchivo = A992SolicitudesSerialArchivo;
            O194SolicitudesAutoEnumerar = A194SolicitudesAutoEnumerar;
            O133ProveedorID = A133ProveedorID;
            O212SolicitudesCotizacion = A212SolicitudesCotizacion;
            O211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            O131EstadosSolId = A131EstadosSolId;
         }
         ZM0O30( -63) ;
         OnLoadActions0O30( ) ;
         AddRow0O30( ) ;
         bcSolicitudes.gxTpr_Items.ClearCollection();
         if ( RcdFound30 == 1 )
         {
            ScanKeyStart0O31( ) ;
            nGXsfl_31_idx = 1;
            while ( RcdFound31 != 0 )
            {
               O175SolicitudesItemsPrecioInstalac = A175SolicitudesItemsPrecioInstalac;
               Z127SolicitudesID = A127SolicitudesID;
               Z134SolicitudesItemsID = A134SolicitudesItemsID;
               ZM0O31( -78) ;
               OnLoadActions0O31( ) ;
               nRcdExists_31 = 1;
               nIsMod_31 = 0;
               Z175SolicitudesItemsPrecioInstalac = A175SolicitudesItemsPrecioInstalac;
               AddRow0O31( ) ;
               nGXsfl_31_idx = (int)(nGXsfl_31_idx+1);
               ScanKeyNext0O31( ) ;
            }
            ScanKeyEnd0O31( ) ;
         }
         bcSolicitudes.gxTpr_Archivo.ClearCollection();
         if ( RcdFound30 == 1 )
         {
            ScanKeyStart0O144( ) ;
            nGXsfl_144_idx = 1;
            while ( RcdFound144 != 0 )
            {
               Z127SolicitudesID = A127SolicitudesID;
               Z988ArchivoId = A988ArchivoId;
               ZM0O144( -83) ;
               OnLoadActions0O144( ) ;
               nRcdExists_144 = 1;
               nIsMod_144 = 0;
               AddRow0O144( ) ;
               nGXsfl_144_idx = (int)(nGXsfl_144_idx+1);
               ScanKeyNext0O144( ) ;
            }
            ScanKeyEnd0O144( ) ;
         }
         ScanKeyEnd0O30( ) ;
         if ( RcdFound30 == 0 )
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
         RowToVars30( bcSolicitudes, 0) ;
         ScanKeyStart0O30( ) ;
         if ( RcdFound30 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z127SolicitudesID = A127SolicitudesID;
            O992SolicitudesSerialArchivo = A992SolicitudesSerialArchivo;
            O194SolicitudesAutoEnumerar = A194SolicitudesAutoEnumerar;
            O133ProveedorID = A133ProveedorID;
            O212SolicitudesCotizacion = A212SolicitudesCotizacion;
            O211SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            O131EstadosSolId = A131EstadosSolId;
         }
         ZM0O30( -63) ;
         OnLoadActions0O30( ) ;
         AddRow0O30( ) ;
         bcSolicitudes.gxTpr_Items.ClearCollection();
         if ( RcdFound30 == 1 )
         {
            ScanKeyStart0O31( ) ;
            nGXsfl_31_idx = 1;
            while ( RcdFound31 != 0 )
            {
               O175SolicitudesItemsPrecioInstalac = A175SolicitudesItemsPrecioInstalac;
               Z127SolicitudesID = A127SolicitudesID;
               Z134SolicitudesItemsID = A134SolicitudesItemsID;
               ZM0O31( -78) ;
               OnLoadActions0O31( ) ;
               nRcdExists_31 = 1;
               nIsMod_31 = 0;
               Z175SolicitudesItemsPrecioInstalac = A175SolicitudesItemsPrecioInstalac;
               AddRow0O31( ) ;
               nGXsfl_31_idx = (int)(nGXsfl_31_idx+1);
               ScanKeyNext0O31( ) ;
            }
            ScanKeyEnd0O31( ) ;
         }
         bcSolicitudes.gxTpr_Archivo.ClearCollection();
         if ( RcdFound30 == 1 )
         {
            ScanKeyStart0O144( ) ;
            nGXsfl_144_idx = 1;
            while ( RcdFound144 != 0 )
            {
               Z127SolicitudesID = A127SolicitudesID;
               Z988ArchivoId = A988ArchivoId;
               ZM0O144( -83) ;
               OnLoadActions0O144( ) ;
               nRcdExists_144 = 1;
               nIsMod_144 = 0;
               AddRow0O144( ) ;
               nGXsfl_144_idx = (int)(nGXsfl_144_idx+1);
               ScanKeyNext0O144( ) ;
            }
            ScanKeyEnd0O144( ) ;
         }
         ScanKeyEnd0O30( ) ;
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0O30( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A211SolicitudServicioPFinal = O211SolicitudServicioPFinal;
            A194SolicitudesAutoEnumerar = O194SolicitudesAutoEnumerar;
            A174SolicitudesTotal = O174SolicitudesTotal;
            A529SolicitudServicioComPro = O529SolicitudServicioComPro;
            AV52OldSolicitudServicioPFinal = OV52OldSolicitudServicioPFinal;
            A992SolicitudesSerialArchivo = O992SolicitudesSerialArchivo;
            Insert0O30( ) ;
         }
         else
         {
            if ( RcdFound30 == 1 )
            {
               if ( A127SolicitudesID != Z127SolicitudesID )
               {
                  A127SolicitudesID = Z127SolicitudesID;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A211SolicitudServicioPFinal = O211SolicitudServicioPFinal;
                  A194SolicitudesAutoEnumerar = O194SolicitudesAutoEnumerar;
                  A174SolicitudesTotal = O174SolicitudesTotal;
                  A529SolicitudServicioComPro = O529SolicitudServicioComPro;
                  AV52OldSolicitudServicioPFinal = OV52OldSolicitudServicioPFinal;
                  A992SolicitudesSerialArchivo = O992SolicitudesSerialArchivo;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A211SolicitudServicioPFinal = O211SolicitudServicioPFinal;
                  A194SolicitudesAutoEnumerar = O194SolicitudesAutoEnumerar;
                  A174SolicitudesTotal = O174SolicitudesTotal;
                  A529SolicitudServicioComPro = O529SolicitudServicioComPro;
                  AV52OldSolicitudServicioPFinal = OV52OldSolicitudServicioPFinal;
                  A992SolicitudesSerialArchivo = O992SolicitudesSerialArchivo;
                  Update0O30( ) ;
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
                  if ( A127SolicitudesID != Z127SolicitudesID )
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
                        A211SolicitudServicioPFinal = O211SolicitudServicioPFinal;
                        A194SolicitudesAutoEnumerar = O194SolicitudesAutoEnumerar;
                        A174SolicitudesTotal = O174SolicitudesTotal;
                        A529SolicitudServicioComPro = O529SolicitudServicioComPro;
                        AV52OldSolicitudServicioPFinal = OV52OldSolicitudServicioPFinal;
                        A992SolicitudesSerialArchivo = O992SolicitudesSerialArchivo;
                        Insert0O30( ) ;
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
                        A211SolicitudServicioPFinal = O211SolicitudServicioPFinal;
                        A194SolicitudesAutoEnumerar = O194SolicitudesAutoEnumerar;
                        A174SolicitudesTotal = O174SolicitudesTotal;
                        A529SolicitudServicioComPro = O529SolicitudServicioComPro;
                        AV52OldSolicitudServicioPFinal = OV52OldSolicitudServicioPFinal;
                        A992SolicitudesSerialArchivo = O992SolicitudesSerialArchivo;
                        Insert0O30( ) ;
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
         RowToVars30( bcSolicitudes, 1) ;
         SaveImpl( ) ;
         VarsToRow30( bcSolicitudes) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars30( bcSolicitudes, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A211SolicitudServicioPFinal = O211SolicitudServicioPFinal;
         A194SolicitudesAutoEnumerar = O194SolicitudesAutoEnumerar;
         A174SolicitudesTotal = O174SolicitudesTotal;
         A529SolicitudServicioComPro = O529SolicitudServicioComPro;
         AV52OldSolicitudServicioPFinal = OV52OldSolicitudServicioPFinal;
         A992SolicitudesSerialArchivo = O992SolicitudesSerialArchivo;
         Insert0O30( ) ;
         AfterTrn( ) ;
         VarsToRow30( bcSolicitudes) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow30( bcSolicitudes) ;
         }
         else
         {
            SdtSolicitudes auxBC = new SdtSolicitudes(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A127SolicitudesID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSolicitudes);
               auxBC.Save();
               bcSolicitudes.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars30( bcSolicitudes, 1) ;
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
         RowToVars30( bcSolicitudes, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0O30( ) ;
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
               VarsToRow30( bcSolicitudes) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow30( bcSolicitudes) ;
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
         RowToVars30( bcSolicitudes, 0) ;
         GetKey0O30( ) ;
         if ( RcdFound30 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A127SolicitudesID != Z127SolicitudesID )
            {
               A127SolicitudesID = Z127SolicitudesID;
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
            if ( A127SolicitudesID != Z127SolicitudesID )
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
         pr_default.close(9);
         pr_default.close(3);
         pr_default.close(1);
         pr_default.close(11);
         pr_default.close(34);
         pr_default.close(37);
         pr_default.close(35);
         pr_default.close(36);
         pr_default.close(38);
         pr_default.close(32);
         pr_default.close(39);
         pr_default.close(33);
         pr_default.close(31);
         pr_default.close(40);
         pr_default.close(50);
         pr_default.close(51);
         pr_default.close(53);
         pr_default.close(52);
         context.RollbackDataStores("solicitudes_bc",pr_default);
         VarsToRow30( bcSolicitudes) ;
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
         Gx_mode = bcSolicitudes.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSolicitudes.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSolicitudes )
         {
            bcSolicitudes = (SdtSolicitudes)(sdt);
            if ( StringUtil.StrCmp(bcSolicitudes.gxTpr_Mode, "") == 0 )
            {
               bcSolicitudes.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow30( bcSolicitudes) ;
            }
            else
            {
               RowToVars30( bcSolicitudes, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSolicitudes.gxTpr_Mode, "") == 0 )
            {
               bcSolicitudes.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars30( bcSolicitudes, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSolicitudes Solicitudes_BC
      {
         get {
            return bcSolicitudes ;
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
         pr_default.close(51);
         pr_default.close(53);
         pr_default.close(50);
         pr_default.close(52);
         pr_default.close(9);
         pr_default.close(11);
         pr_default.close(34);
         pr_default.close(37);
         pr_default.close(35);
         pr_default.close(36);
         pr_default.close(38);
         pr_default.close(32);
         pr_default.close(39);
         pr_default.close(33);
         pr_default.close(31);
         pr_default.close(40);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode30 = "";
         AV79FechaCierreSolicitud = DateTime.MinValue;
         GXt_date3 = DateTime.MinValue;
         AV14WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV93Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV17TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV18WebSession = context.GetSession();
         AV26TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV89Insert_CuponId = 1234;
         AV22Insert_EstadosSolTipo = "";
         AV84Insert_CancelacionTipificacionId = 0;
         AV74ProfesionalesId = "";
         AV76NombreProfesional = "";
         AV75Existe = "";
         AV78Window = new GXWindow();
         AV9Modo = "";
         Z438SolicitudServicioOrigenPago = "";
         A438SolicitudServicioOrigenPago = "";
         Z182SolicitudesFechaAlta = DateTime.MinValue;
         A182SolicitudesFechaAlta = DateTime.MinValue;
         Z171SolicitudesNombre = "";
         A171SolicitudesNombre = "";
         Z172SolicitudesTelefono = "";
         A172SolicitudesTelefono = "";
         Z206SolicitudesMail = "";
         A206SolicitudesMail = "";
         Z173SolicitudesDireccion = "";
         A173SolicitudesDireccion = "";
         Z210SolicitudServicioSolCoti = "";
         A210SolicitudServicioSolCoti = "";
         Z201SolicitudesOtros1 = "";
         A201SolicitudesOtros1 = "";
         Z202SolicitudesOtros2 = "";
         A202SolicitudesOtros2 = "";
         Z203SolicitudesOtros3 = "";
         A203SolicitudesOtros3 = "";
         Z204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         A204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         Z184SolicitudesFechaInstalacion = DateTime.MinValue;
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         Z183SolicitudesHoraInstalacion = "";
         A183SolicitudesHoraInstalacion = "";
         Z261SolicitudesNota = "";
         A261SolicitudesNota = "";
         Z262SolicitudesNotificacion = "";
         A262SolicitudesNotificacion = "";
         Z441SolicitudesPagado = "";
         A441SolicitudesPagado = "";
         Z533ProveedorNombreAux = "";
         A533ProveedorNombreAux = "";
         Z600SolicitudesSubTipo = "";
         A600SolicitudesSubTipo = "";
         Z1006SolicitudesURLOrigen = "";
         A1006SolicitudesURLOrigen = "";
         Z130EstadosSolTipo = "";
         A130EstadosSolTipo = "";
         Z116PaisID = "";
         A116PaisID = "";
         Z129MetodoPagosNombre = "";
         A129MetodoPagosNombre = "";
         Z738MudanzaFechaServicio = DateTime.MinValue;
         A738MudanzaFechaServicio = DateTime.MinValue;
         Z740MudanzaDireccionOrigen = "";
         A740MudanzaDireccionOrigen = "";
         Z741MudanzaDireccionDestino = "";
         A741MudanzaDireccionDestino = "";
         Z282ProveedorNombre = "";
         A282ProveedorNombre = "";
         Z440ProveedorPagoDefault = "";
         A440ProveedorPagoDefault = "";
         Z923STComerciosNombre = "";
         A923STComerciosNombre = "";
         Z924STComerciosEstado = "";
         A924STComerciosEstado = "";
         Z997CancelacionTipificacionDescrip = "";
         A997CancelacionTipificacionDescrip = "";
         Z1024TicketComentario = "";
         A1024TicketComentario = "";
         Z1026TicketAdjunto = "";
         A1026TicketAdjunto = "";
         Z132EstadosSolNombre = "";
         A132EstadosSolNombre = "";
         Z671STMonedasISO = "";
         A671STMonedasISO = "";
         Z1022TicketMotivoDescripcion = "";
         A1022TicketMotivoDescripcion = "";
         Z205SolicitudesComentario = "";
         A205SolicitudesComentario = "";
         BC000O21_A997CancelacionTipificacionDescrip = new string[] {""} ;
         BC000O25_A671STMonedasISO = new string[] {""} ;
         BC000O24_A132EstadosSolNombre = new string[] {""} ;
         BC000O18_A282ProveedorNombre = new string[] {""} ;
         BC000O18_A440ProveedorPagoDefault = new string[] {""} ;
         BC000O27_A127SolicitudesID = new long[1] ;
         BC000O27_A438SolicitudServicioOrigenPago = new string[] {""} ;
         BC000O27_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         BC000O27_A866SolicitudesCostoXZComAlmP = new decimal[1] ;
         BC000O27_n866SolicitudesCostoXZComAlmP = new bool[] {false} ;
         BC000O27_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         BC000O27_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         BC000O27_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC000O27_n182SolicitudesFechaAlta = new bool[] {false} ;
         BC000O27_A171SolicitudesNombre = new string[] {""} ;
         BC000O27_A172SolicitudesTelefono = new string[] {""} ;
         BC000O27_A206SolicitudesMail = new string[] {""} ;
         BC000O27_n206SolicitudesMail = new bool[] {false} ;
         BC000O27_A173SolicitudesDireccion = new string[] {""} ;
         BC000O27_A194SolicitudesAutoEnumerar = new short[1] ;
         BC000O27_A671STMonedasISO = new string[] {""} ;
         BC000O27_A688SolicitudesLiqProf = new long[1] ;
         BC000O27_n688SolicitudesLiqProf = new bool[] {false} ;
         BC000O27_A689SolicitudesLiqProv = new long[1] ;
         BC000O27_n689SolicitudesLiqProv = new bool[] {false} ;
         BC000O27_A212SolicitudesCotizacion = new decimal[1] ;
         BC000O27_A210SolicitudServicioSolCoti = new string[] {""} ;
         BC000O27_A897SolicitudesDescuento = new decimal[1] ;
         BC000O27_n897SolicitudesDescuento = new bool[] {false} ;
         BC000O27_A1014CuponPercent = new short[1] ;
         BC000O27_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         BC000O27_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         BC000O27_A132EstadosSolNombre = new string[] {""} ;
         BC000O27_A201SolicitudesOtros1 = new string[] {""} ;
         BC000O27_A202SolicitudesOtros2 = new string[] {""} ;
         BC000O27_A203SolicitudesOtros3 = new string[] {""} ;
         BC000O27_A597SolicitudesUsrAlta = new long[1] ;
         BC000O27_n597SolicitudesUsrAlta = new bool[] {false} ;
         BC000O27_A598SolicitudesUsrActualizacion = new long[1] ;
         BC000O27_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         BC000O27_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         BC000O27_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         BC000O27_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         BC000O27_A183SolicitudesHoraInstalacion = new string[] {""} ;
         BC000O27_A205SolicitudesComentario = new string[] {""} ;
         BC000O27_A129MetodoPagosNombre = new string[] {""} ;
         BC000O27_A261SolicitudesNota = new string[] {""} ;
         BC000O27_A262SolicitudesNotificacion = new string[] {""} ;
         BC000O27_A282ProveedorNombre = new string[] {""} ;
         BC000O27_A440ProveedorPagoDefault = new string[] {""} ;
         BC000O27_A923STComerciosNombre = new string[] {""} ;
         BC000O27_A924STComerciosEstado = new string[] {""} ;
         BC000O27_A441SolicitudesPagado = new string[] {""} ;
         BC000O27_n441SolicitudesPagado = new bool[] {false} ;
         BC000O27_A527SolicitudServicioComProv = new decimal[1] ;
         BC000O27_n527SolicitudServicioComProv = new bool[] {false} ;
         BC000O27_A528SolicitudServicioComProvP = new decimal[1] ;
         BC000O27_n528SolicitudServicioComProvP = new bool[] {false} ;
         BC000O27_A530SolicitudServicioComALM = new decimal[1] ;
         BC000O27_n530SolicitudServicioComALM = new bool[] {false} ;
         BC000O27_A532SolicitudServicioComALMP = new decimal[1] ;
         BC000O27_n532SolicitudServicioComALMP = new bool[] {false} ;
         BC000O27_A672SolicitudesCalComi = new bool[] {false} ;
         BC000O27_A533ProveedorNombreAux = new string[] {""} ;
         BC000O27_n533ProveedorNombreAux = new bool[] {false} ;
         BC000O27_A600SolicitudesSubTipo = new string[] {""} ;
         BC000O27_n600SolicitudesSubTipo = new bool[] {false} ;
         BC000O27_A864SolicitudesCostoXZona = new decimal[1] ;
         BC000O27_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         BC000O27_A740MudanzaDireccionOrigen = new string[] {""} ;
         BC000O27_A741MudanzaDireccionDestino = new string[] {""} ;
         BC000O27_A972SolicitudesDuplicado = new long[1] ;
         BC000O27_n972SolicitudesDuplicado = new bool[] {false} ;
         BC000O27_A992SolicitudesSerialArchivo = new short[1] ;
         BC000O27_A997CancelacionTipificacionDescrip = new string[] {""} ;
         BC000O27_A1003SolicitudesCostoPresupuesto = new decimal[1] ;
         BC000O27_n1003SolicitudesCostoPresupuesto = new bool[] {false} ;
         BC000O27_A1006SolicitudesURLOrigen = new string[] {""} ;
         BC000O27_n1006SolicitudesURLOrigen = new bool[] {false} ;
         BC000O27_A1022TicketMotivoDescripcion = new string[] {""} ;
         BC000O27_A1024TicketComentario = new string[] {""} ;
         BC000O27_A1026TicketAdjunto = new string[] {""} ;
         BC000O27_A1030TicketEstado = new bool[] {false} ;
         BC000O27_A1023TicketSolicitudId = new long[1] ;
         BC000O27_A112DepartamentoId = new long[1] ;
         BC000O27_n112DepartamentoId = new bool[] {false} ;
         BC000O27_A114DepartamentoMunicipioId = new long[1] ;
         BC000O27_n114DepartamentoMunicipioId = new bool[] {false} ;
         BC000O27_A110ZonasID = new long[1] ;
         BC000O27_n110ZonasID = new bool[] {false} ;
         BC000O27_A128MetodoPagosID = new long[1] ;
         BC000O27_A735MudanzaId = new long[1] ;
         BC000O27_n735MudanzaId = new bool[] {false} ;
         BC000O27_A133ProveedorID = new long[1] ;
         BC000O27_A919STComerciosID = new long[1] ;
         BC000O27_n919STComerciosID = new bool[] {false} ;
         BC000O27_A422PostulacionesId = new long[1] ;
         BC000O27_n422PostulacionesId = new bool[] {false} ;
         BC000O27_A996CancelacionTipificacionId = new long[1] ;
         BC000O27_A1013CuponId = new long[1] ;
         BC000O27_n1013CuponId = new bool[] {false} ;
         BC000O27_A1020TicketId = new long[1] ;
         BC000O27_n1020TicketId = new bool[] {false} ;
         BC000O27_A130EstadosSolTipo = new string[] {""} ;
         BC000O27_A131EstadosSolId = new int[1] ;
         BC000O27_A669STMonedasId = new short[1] ;
         BC000O27_n669STMonedasId = new bool[] {false} ;
         BC000O27_A116PaisID = new string[] {""} ;
         BC000O27_A1021TicketMotivoId = new long[1] ;
         BC000O16_A129MetodoPagosNombre = new string[] {""} ;
         BC000O19_A923STComerciosNombre = new string[] {""} ;
         BC000O19_A924STComerciosEstado = new string[] {""} ;
         BC000O17_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         BC000O17_A740MudanzaDireccionOrigen = new string[] {""} ;
         BC000O17_A741MudanzaDireccionDestino = new string[] {""} ;
         BC000O20_A422PostulacionesId = new long[1] ;
         BC000O20_n422PostulacionesId = new bool[] {false} ;
         BC000O23_A1024TicketComentario = new string[] {""} ;
         BC000O23_A1026TicketAdjunto = new string[] {""} ;
         BC000O23_A1030TicketEstado = new bool[] {false} ;
         BC000O23_A1023TicketSolicitudId = new long[1] ;
         BC000O23_A1021TicketMotivoId = new long[1] ;
         BC000O26_A1022TicketMotivoDescripcion = new string[] {""} ;
         BC000O13_A116PaisID = new string[] {""} ;
         BC000O14_A112DepartamentoId = new long[1] ;
         BC000O14_n112DepartamentoId = new bool[] {false} ;
         BC000O15_A110ZonasID = new long[1] ;
         BC000O15_n110ZonasID = new bool[] {false} ;
         BC000O22_A1014CuponPercent = new short[1] ;
         BC000O28_A127SolicitudesID = new long[1] ;
         BC000O11_A127SolicitudesID = new long[1] ;
         BC000O11_A438SolicitudServicioOrigenPago = new string[] {""} ;
         BC000O11_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         BC000O11_A866SolicitudesCostoXZComAlmP = new decimal[1] ;
         BC000O11_n866SolicitudesCostoXZComAlmP = new bool[] {false} ;
         BC000O11_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         BC000O11_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         BC000O11_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC000O11_n182SolicitudesFechaAlta = new bool[] {false} ;
         BC000O11_A171SolicitudesNombre = new string[] {""} ;
         BC000O11_A172SolicitudesTelefono = new string[] {""} ;
         BC000O11_A206SolicitudesMail = new string[] {""} ;
         BC000O11_n206SolicitudesMail = new bool[] {false} ;
         BC000O11_A173SolicitudesDireccion = new string[] {""} ;
         BC000O11_A194SolicitudesAutoEnumerar = new short[1] ;
         BC000O11_A688SolicitudesLiqProf = new long[1] ;
         BC000O11_n688SolicitudesLiqProf = new bool[] {false} ;
         BC000O11_A689SolicitudesLiqProv = new long[1] ;
         BC000O11_n689SolicitudesLiqProv = new bool[] {false} ;
         BC000O11_A212SolicitudesCotizacion = new decimal[1] ;
         BC000O11_A210SolicitudServicioSolCoti = new string[] {""} ;
         BC000O11_A897SolicitudesDescuento = new decimal[1] ;
         BC000O11_n897SolicitudesDescuento = new bool[] {false} ;
         BC000O11_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         BC000O11_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         BC000O11_A201SolicitudesOtros1 = new string[] {""} ;
         BC000O11_A202SolicitudesOtros2 = new string[] {""} ;
         BC000O11_A203SolicitudesOtros3 = new string[] {""} ;
         BC000O11_A597SolicitudesUsrAlta = new long[1] ;
         BC000O11_n597SolicitudesUsrAlta = new bool[] {false} ;
         BC000O11_A598SolicitudesUsrActualizacion = new long[1] ;
         BC000O11_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         BC000O11_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         BC000O11_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         BC000O11_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         BC000O11_A183SolicitudesHoraInstalacion = new string[] {""} ;
         BC000O11_A205SolicitudesComentario = new string[] {""} ;
         BC000O11_A261SolicitudesNota = new string[] {""} ;
         BC000O11_A262SolicitudesNotificacion = new string[] {""} ;
         BC000O11_A441SolicitudesPagado = new string[] {""} ;
         BC000O11_n441SolicitudesPagado = new bool[] {false} ;
         BC000O11_A527SolicitudServicioComProv = new decimal[1] ;
         BC000O11_n527SolicitudServicioComProv = new bool[] {false} ;
         BC000O11_A528SolicitudServicioComProvP = new decimal[1] ;
         BC000O11_n528SolicitudServicioComProvP = new bool[] {false} ;
         BC000O11_A530SolicitudServicioComALM = new decimal[1] ;
         BC000O11_n530SolicitudServicioComALM = new bool[] {false} ;
         BC000O11_A532SolicitudServicioComALMP = new decimal[1] ;
         BC000O11_n532SolicitudServicioComALMP = new bool[] {false} ;
         BC000O11_A672SolicitudesCalComi = new bool[] {false} ;
         BC000O11_A533ProveedorNombreAux = new string[] {""} ;
         BC000O11_n533ProveedorNombreAux = new bool[] {false} ;
         BC000O11_A600SolicitudesSubTipo = new string[] {""} ;
         BC000O11_n600SolicitudesSubTipo = new bool[] {false} ;
         BC000O11_A864SolicitudesCostoXZona = new decimal[1] ;
         BC000O11_A972SolicitudesDuplicado = new long[1] ;
         BC000O11_n972SolicitudesDuplicado = new bool[] {false} ;
         BC000O11_A992SolicitudesSerialArchivo = new short[1] ;
         BC000O11_A1003SolicitudesCostoPresupuesto = new decimal[1] ;
         BC000O11_n1003SolicitudesCostoPresupuesto = new bool[] {false} ;
         BC000O11_A1006SolicitudesURLOrigen = new string[] {""} ;
         BC000O11_n1006SolicitudesURLOrigen = new bool[] {false} ;
         BC000O11_A112DepartamentoId = new long[1] ;
         BC000O11_n112DepartamentoId = new bool[] {false} ;
         BC000O11_A114DepartamentoMunicipioId = new long[1] ;
         BC000O11_n114DepartamentoMunicipioId = new bool[] {false} ;
         BC000O11_A110ZonasID = new long[1] ;
         BC000O11_n110ZonasID = new bool[] {false} ;
         BC000O11_A128MetodoPagosID = new long[1] ;
         BC000O11_A735MudanzaId = new long[1] ;
         BC000O11_n735MudanzaId = new bool[] {false} ;
         BC000O11_A133ProveedorID = new long[1] ;
         BC000O11_A919STComerciosID = new long[1] ;
         BC000O11_n919STComerciosID = new bool[] {false} ;
         BC000O11_A422PostulacionesId = new long[1] ;
         BC000O11_n422PostulacionesId = new bool[] {false} ;
         BC000O11_A996CancelacionTipificacionId = new long[1] ;
         BC000O11_A1013CuponId = new long[1] ;
         BC000O11_n1013CuponId = new bool[] {false} ;
         BC000O11_A1020TicketId = new long[1] ;
         BC000O11_n1020TicketId = new bool[] {false} ;
         BC000O11_A130EstadosSolTipo = new string[] {""} ;
         BC000O11_A131EstadosSolId = new int[1] ;
         BC000O11_A669STMonedasId = new short[1] ;
         BC000O11_n669STMonedasId = new bool[] {false} ;
         BC000O10_A127SolicitudesID = new long[1] ;
         BC000O10_A438SolicitudServicioOrigenPago = new string[] {""} ;
         BC000O10_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         BC000O10_A866SolicitudesCostoXZComAlmP = new decimal[1] ;
         BC000O10_n866SolicitudesCostoXZComAlmP = new bool[] {false} ;
         BC000O10_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         BC000O10_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         BC000O10_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC000O10_n182SolicitudesFechaAlta = new bool[] {false} ;
         BC000O10_A171SolicitudesNombre = new string[] {""} ;
         BC000O10_A172SolicitudesTelefono = new string[] {""} ;
         BC000O10_A206SolicitudesMail = new string[] {""} ;
         BC000O10_n206SolicitudesMail = new bool[] {false} ;
         BC000O10_A173SolicitudesDireccion = new string[] {""} ;
         BC000O10_A194SolicitudesAutoEnumerar = new short[1] ;
         BC000O10_A688SolicitudesLiqProf = new long[1] ;
         BC000O10_n688SolicitudesLiqProf = new bool[] {false} ;
         BC000O10_A689SolicitudesLiqProv = new long[1] ;
         BC000O10_n689SolicitudesLiqProv = new bool[] {false} ;
         BC000O10_A212SolicitudesCotizacion = new decimal[1] ;
         BC000O10_A210SolicitudServicioSolCoti = new string[] {""} ;
         BC000O10_A897SolicitudesDescuento = new decimal[1] ;
         BC000O10_n897SolicitudesDescuento = new bool[] {false} ;
         BC000O10_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         BC000O10_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         BC000O10_A201SolicitudesOtros1 = new string[] {""} ;
         BC000O10_A202SolicitudesOtros2 = new string[] {""} ;
         BC000O10_A203SolicitudesOtros3 = new string[] {""} ;
         BC000O10_A597SolicitudesUsrAlta = new long[1] ;
         BC000O10_n597SolicitudesUsrAlta = new bool[] {false} ;
         BC000O10_A598SolicitudesUsrActualizacion = new long[1] ;
         BC000O10_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         BC000O10_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         BC000O10_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         BC000O10_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         BC000O10_A183SolicitudesHoraInstalacion = new string[] {""} ;
         BC000O10_A205SolicitudesComentario = new string[] {""} ;
         BC000O10_A261SolicitudesNota = new string[] {""} ;
         BC000O10_A262SolicitudesNotificacion = new string[] {""} ;
         BC000O10_A441SolicitudesPagado = new string[] {""} ;
         BC000O10_n441SolicitudesPagado = new bool[] {false} ;
         BC000O10_A527SolicitudServicioComProv = new decimal[1] ;
         BC000O10_n527SolicitudServicioComProv = new bool[] {false} ;
         BC000O10_A528SolicitudServicioComProvP = new decimal[1] ;
         BC000O10_n528SolicitudServicioComProvP = new bool[] {false} ;
         BC000O10_A530SolicitudServicioComALM = new decimal[1] ;
         BC000O10_n530SolicitudServicioComALM = new bool[] {false} ;
         BC000O10_A532SolicitudServicioComALMP = new decimal[1] ;
         BC000O10_n532SolicitudServicioComALMP = new bool[] {false} ;
         BC000O10_A672SolicitudesCalComi = new bool[] {false} ;
         BC000O10_A533ProveedorNombreAux = new string[] {""} ;
         BC000O10_n533ProveedorNombreAux = new bool[] {false} ;
         BC000O10_A600SolicitudesSubTipo = new string[] {""} ;
         BC000O10_n600SolicitudesSubTipo = new bool[] {false} ;
         BC000O10_A864SolicitudesCostoXZona = new decimal[1] ;
         BC000O10_A972SolicitudesDuplicado = new long[1] ;
         BC000O10_n972SolicitudesDuplicado = new bool[] {false} ;
         BC000O10_A992SolicitudesSerialArchivo = new short[1] ;
         BC000O10_A1003SolicitudesCostoPresupuesto = new decimal[1] ;
         BC000O10_n1003SolicitudesCostoPresupuesto = new bool[] {false} ;
         BC000O10_A1006SolicitudesURLOrigen = new string[] {""} ;
         BC000O10_n1006SolicitudesURLOrigen = new bool[] {false} ;
         BC000O10_A112DepartamentoId = new long[1] ;
         BC000O10_n112DepartamentoId = new bool[] {false} ;
         BC000O10_A114DepartamentoMunicipioId = new long[1] ;
         BC000O10_n114DepartamentoMunicipioId = new bool[] {false} ;
         BC000O10_A110ZonasID = new long[1] ;
         BC000O10_n110ZonasID = new bool[] {false} ;
         BC000O10_A128MetodoPagosID = new long[1] ;
         BC000O10_A735MudanzaId = new long[1] ;
         BC000O10_n735MudanzaId = new bool[] {false} ;
         BC000O10_A133ProveedorID = new long[1] ;
         BC000O10_A919STComerciosID = new long[1] ;
         BC000O10_n919STComerciosID = new bool[] {false} ;
         BC000O10_A422PostulacionesId = new long[1] ;
         BC000O10_n422PostulacionesId = new bool[] {false} ;
         BC000O10_A996CancelacionTipificacionId = new long[1] ;
         BC000O10_A1013CuponId = new long[1] ;
         BC000O10_n1013CuponId = new bool[] {false} ;
         BC000O10_A1020TicketId = new long[1] ;
         BC000O10_n1020TicketId = new bool[] {false} ;
         BC000O10_A130EstadosSolTipo = new string[] {""} ;
         BC000O10_A131EstadosSolId = new int[1] ;
         BC000O10_A669STMonedasId = new short[1] ;
         BC000O10_n669STMonedasId = new bool[] {false} ;
         BC000O29_A116PaisID = new string[] {""} ;
         BC000O30_A127SolicitudesID = new long[1] ;
         BC000O33_A671STMonedasISO = new string[] {""} ;
         BC000O34_A1014CuponPercent = new short[1] ;
         BC000O35_A132EstadosSolNombre = new string[] {""} ;
         BC000O36_A129MetodoPagosNombre = new string[] {""} ;
         BC000O37_A282ProveedorNombre = new string[] {""} ;
         BC000O37_A440ProveedorPagoDefault = new string[] {""} ;
         BC000O38_A923STComerciosNombre = new string[] {""} ;
         BC000O38_A924STComerciosEstado = new string[] {""} ;
         BC000O39_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         BC000O39_A740MudanzaDireccionOrigen = new string[] {""} ;
         BC000O39_A741MudanzaDireccionDestino = new string[] {""} ;
         BC000O40_A997CancelacionTipificacionDescrip = new string[] {""} ;
         BC000O41_A1024TicketComentario = new string[] {""} ;
         BC000O41_A1026TicketAdjunto = new string[] {""} ;
         BC000O41_A1030TicketEstado = new bool[] {false} ;
         BC000O41_A1023TicketSolicitudId = new long[1] ;
         BC000O41_A1021TicketMotivoId = new long[1] ;
         BC000O42_A1022TicketMotivoDescripcion = new string[] {""} ;
         BC000O43_A127SolicitudesID = new long[1] ;
         BC000O43_A140RelacionesId = new long[1] ;
         BC000O46_A127SolicitudesID = new long[1] ;
         BC000O46_A438SolicitudServicioOrigenPago = new string[] {""} ;
         BC000O46_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         BC000O46_A866SolicitudesCostoXZComAlmP = new decimal[1] ;
         BC000O46_n866SolicitudesCostoXZComAlmP = new bool[] {false} ;
         BC000O46_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         BC000O46_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         BC000O46_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC000O46_n182SolicitudesFechaAlta = new bool[] {false} ;
         BC000O46_A171SolicitudesNombre = new string[] {""} ;
         BC000O46_A172SolicitudesTelefono = new string[] {""} ;
         BC000O46_A206SolicitudesMail = new string[] {""} ;
         BC000O46_n206SolicitudesMail = new bool[] {false} ;
         BC000O46_A173SolicitudesDireccion = new string[] {""} ;
         BC000O46_A194SolicitudesAutoEnumerar = new short[1] ;
         BC000O46_A671STMonedasISO = new string[] {""} ;
         BC000O46_A688SolicitudesLiqProf = new long[1] ;
         BC000O46_n688SolicitudesLiqProf = new bool[] {false} ;
         BC000O46_A689SolicitudesLiqProv = new long[1] ;
         BC000O46_n689SolicitudesLiqProv = new bool[] {false} ;
         BC000O46_A212SolicitudesCotizacion = new decimal[1] ;
         BC000O46_A210SolicitudServicioSolCoti = new string[] {""} ;
         BC000O46_A897SolicitudesDescuento = new decimal[1] ;
         BC000O46_n897SolicitudesDescuento = new bool[] {false} ;
         BC000O46_A1014CuponPercent = new short[1] ;
         BC000O46_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         BC000O46_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         BC000O46_A132EstadosSolNombre = new string[] {""} ;
         BC000O46_A201SolicitudesOtros1 = new string[] {""} ;
         BC000O46_A202SolicitudesOtros2 = new string[] {""} ;
         BC000O46_A203SolicitudesOtros3 = new string[] {""} ;
         BC000O46_A597SolicitudesUsrAlta = new long[1] ;
         BC000O46_n597SolicitudesUsrAlta = new bool[] {false} ;
         BC000O46_A598SolicitudesUsrActualizacion = new long[1] ;
         BC000O46_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         BC000O46_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         BC000O46_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         BC000O46_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         BC000O46_A183SolicitudesHoraInstalacion = new string[] {""} ;
         BC000O46_A205SolicitudesComentario = new string[] {""} ;
         BC000O46_A129MetodoPagosNombre = new string[] {""} ;
         BC000O46_A261SolicitudesNota = new string[] {""} ;
         BC000O46_A262SolicitudesNotificacion = new string[] {""} ;
         BC000O46_A282ProveedorNombre = new string[] {""} ;
         BC000O46_A440ProveedorPagoDefault = new string[] {""} ;
         BC000O46_A923STComerciosNombre = new string[] {""} ;
         BC000O46_A924STComerciosEstado = new string[] {""} ;
         BC000O46_A441SolicitudesPagado = new string[] {""} ;
         BC000O46_n441SolicitudesPagado = new bool[] {false} ;
         BC000O46_A527SolicitudServicioComProv = new decimal[1] ;
         BC000O46_n527SolicitudServicioComProv = new bool[] {false} ;
         BC000O46_A528SolicitudServicioComProvP = new decimal[1] ;
         BC000O46_n528SolicitudServicioComProvP = new bool[] {false} ;
         BC000O46_A530SolicitudServicioComALM = new decimal[1] ;
         BC000O46_n530SolicitudServicioComALM = new bool[] {false} ;
         BC000O46_A532SolicitudServicioComALMP = new decimal[1] ;
         BC000O46_n532SolicitudServicioComALMP = new bool[] {false} ;
         BC000O46_A672SolicitudesCalComi = new bool[] {false} ;
         BC000O46_A533ProveedorNombreAux = new string[] {""} ;
         BC000O46_n533ProveedorNombreAux = new bool[] {false} ;
         BC000O46_A600SolicitudesSubTipo = new string[] {""} ;
         BC000O46_n600SolicitudesSubTipo = new bool[] {false} ;
         BC000O46_A864SolicitudesCostoXZona = new decimal[1] ;
         BC000O46_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         BC000O46_A740MudanzaDireccionOrigen = new string[] {""} ;
         BC000O46_A741MudanzaDireccionDestino = new string[] {""} ;
         BC000O46_A972SolicitudesDuplicado = new long[1] ;
         BC000O46_n972SolicitudesDuplicado = new bool[] {false} ;
         BC000O46_A992SolicitudesSerialArchivo = new short[1] ;
         BC000O46_A997CancelacionTipificacionDescrip = new string[] {""} ;
         BC000O46_A1003SolicitudesCostoPresupuesto = new decimal[1] ;
         BC000O46_n1003SolicitudesCostoPresupuesto = new bool[] {false} ;
         BC000O46_A1006SolicitudesURLOrigen = new string[] {""} ;
         BC000O46_n1006SolicitudesURLOrigen = new bool[] {false} ;
         BC000O46_A1022TicketMotivoDescripcion = new string[] {""} ;
         BC000O46_A1024TicketComentario = new string[] {""} ;
         BC000O46_A1026TicketAdjunto = new string[] {""} ;
         BC000O46_A1030TicketEstado = new bool[] {false} ;
         BC000O46_A1023TicketSolicitudId = new long[1] ;
         BC000O46_A112DepartamentoId = new long[1] ;
         BC000O46_n112DepartamentoId = new bool[] {false} ;
         BC000O46_A114DepartamentoMunicipioId = new long[1] ;
         BC000O46_n114DepartamentoMunicipioId = new bool[] {false} ;
         BC000O46_A110ZonasID = new long[1] ;
         BC000O46_n110ZonasID = new bool[] {false} ;
         BC000O46_A128MetodoPagosID = new long[1] ;
         BC000O46_A735MudanzaId = new long[1] ;
         BC000O46_n735MudanzaId = new bool[] {false} ;
         BC000O46_A133ProveedorID = new long[1] ;
         BC000O46_A919STComerciosID = new long[1] ;
         BC000O46_n919STComerciosID = new bool[] {false} ;
         BC000O46_A422PostulacionesId = new long[1] ;
         BC000O46_n422PostulacionesId = new bool[] {false} ;
         BC000O46_A996CancelacionTipificacionId = new long[1] ;
         BC000O46_A1013CuponId = new long[1] ;
         BC000O46_n1013CuponId = new bool[] {false} ;
         BC000O46_A1020TicketId = new long[1] ;
         BC000O46_n1020TicketId = new bool[] {false} ;
         BC000O46_A130EstadosSolTipo = new string[] {""} ;
         BC000O46_A131EstadosSolId = new int[1] ;
         BC000O46_A669STMonedasId = new short[1] ;
         BC000O46_n669STMonedasId = new bool[] {false} ;
         BC000O46_A116PaisID = new string[] {""} ;
         BC000O46_A1021TicketMotivoId = new long[1] ;
         Z178SolicitudItemsSR = "";
         A178SolicitudItemsSR = "";
         Z179SolicitudItemsComisionTipo = "";
         A179SolicitudItemsComisionTipo = "";
         Z123RubrosEstado = "";
         A123RubrosEstado = "";
         Z136InventarioNombre = "";
         A136InventarioNombre = "";
         Z107EstadosTipo = "";
         A107EstadosTipo = "";
         Z119MonedaISOSimbolo = "";
         A119MonedaISOSimbolo = "";
         Z168RubrosImagen = "";
         A168RubrosImagen = "";
         Z40000RubrosImagen_GXI = "";
         A40000RubrosImagen_GXI = "";
         Z189InventarioImagen = "";
         A189InventarioImagen = "";
         Z40001InventarioImagen_GXI = "";
         A40001InventarioImagen_GXI = "";
         BC000O47_A127SolicitudesID = new long[1] ;
         BC000O47_A134SolicitudesItemsID = new short[1] ;
         BC000O47_A177SolicitudesItemsCantidad = new short[1] ;
         BC000O47_A180SolicitudItemsComision = new decimal[1] ;
         BC000O47_A178SolicitudItemsSR = new string[] {""} ;
         BC000O47_A179SolicitudItemsComisionTipo = new string[] {""} ;
         BC000O47_A40000RubrosImagen_GXI = new string[] {""} ;
         BC000O47_A123RubrosEstado = new string[] {""} ;
         BC000O47_n123RubrosEstado = new bool[] {false} ;
         BC000O47_A136InventarioNombre = new string[] {""} ;
         BC000O47_A40001InventarioImagen_GXI = new string[] {""} ;
         BC000O47_A181InventarioPrecioFinal = new decimal[1] ;
         BC000O47_A801InventarioConsumoProductivo = new decimal[1] ;
         BC000O47_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         BC000O47_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         BC000O47_A119MonedaISOSimbolo = new string[] {""} ;
         BC000O47_A521SolicitudesItemsComiProv = new decimal[1] ;
         BC000O47_n521SolicitudesItemsComiProv = new bool[] {false} ;
         BC000O47_A524SolicitudesItemsComiProvP = new decimal[1] ;
         BC000O47_n524SolicitudesItemsComiProvP = new bool[] {false} ;
         BC000O47_A523SolicitudesItemsComiALM = new decimal[1] ;
         BC000O47_n523SolicitudesItemsComiALM = new bool[] {false} ;
         BC000O47_A526SolicitudesItemsComiALMP = new decimal[1] ;
         BC000O47_n526SolicitudesItemsComiALMP = new bool[] {false} ;
         BC000O47_A121RubrosId = new short[1] ;
         BC000O47_A137MedidasID = new long[1] ;
         BC000O47_A135InventarioId = new long[1] ;
         BC000O47_A118MonedaId = new short[1] ;
         BC000O47_A107EstadosTipo = new string[] {""} ;
         BC000O47_A108EstadosGenericosId = new int[1] ;
         BC000O47_A168RubrosImagen = new string[] {""} ;
         BC000O47_A189InventarioImagen = new string[] {""} ;
         BC000O6_A40000RubrosImagen_GXI = new string[] {""} ;
         BC000O6_A123RubrosEstado = new string[] {""} ;
         BC000O6_n123RubrosEstado = new bool[] {false} ;
         BC000O6_A168RubrosImagen = new string[] {""} ;
         BC000O7_A118MonedaId = new short[1] ;
         BC000O9_A119MonedaISOSimbolo = new string[] {""} ;
         BC000O8_A136InventarioNombre = new string[] {""} ;
         BC000O8_A40001InventarioImagen_GXI = new string[] {""} ;
         BC000O8_A181InventarioPrecioFinal = new decimal[1] ;
         BC000O8_A801InventarioConsumoProductivo = new decimal[1] ;
         BC000O8_A107EstadosTipo = new string[] {""} ;
         BC000O8_A108EstadosGenericosId = new int[1] ;
         BC000O8_A189InventarioImagen = new string[] {""} ;
         BC000O48_A127SolicitudesID = new long[1] ;
         BC000O48_A134SolicitudesItemsID = new short[1] ;
         BC000O5_A127SolicitudesID = new long[1] ;
         BC000O5_A134SolicitudesItemsID = new short[1] ;
         BC000O5_A177SolicitudesItemsCantidad = new short[1] ;
         BC000O5_A180SolicitudItemsComision = new decimal[1] ;
         BC000O5_A178SolicitudItemsSR = new string[] {""} ;
         BC000O5_A179SolicitudItemsComisionTipo = new string[] {""} ;
         BC000O5_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         BC000O5_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         BC000O5_A521SolicitudesItemsComiProv = new decimal[1] ;
         BC000O5_n521SolicitudesItemsComiProv = new bool[] {false} ;
         BC000O5_A524SolicitudesItemsComiProvP = new decimal[1] ;
         BC000O5_n524SolicitudesItemsComiProvP = new bool[] {false} ;
         BC000O5_A523SolicitudesItemsComiALM = new decimal[1] ;
         BC000O5_n523SolicitudesItemsComiALM = new bool[] {false} ;
         BC000O5_A526SolicitudesItemsComiALMP = new decimal[1] ;
         BC000O5_n526SolicitudesItemsComiALMP = new bool[] {false} ;
         BC000O5_A121RubrosId = new short[1] ;
         BC000O5_A137MedidasID = new long[1] ;
         BC000O5_A135InventarioId = new long[1] ;
         sMode31 = "";
         BC000O4_A127SolicitudesID = new long[1] ;
         BC000O4_A134SolicitudesItemsID = new short[1] ;
         BC000O4_A177SolicitudesItemsCantidad = new short[1] ;
         BC000O4_A180SolicitudItemsComision = new decimal[1] ;
         BC000O4_A178SolicitudItemsSR = new string[] {""} ;
         BC000O4_A179SolicitudItemsComisionTipo = new string[] {""} ;
         BC000O4_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         BC000O4_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         BC000O4_A521SolicitudesItemsComiProv = new decimal[1] ;
         BC000O4_n521SolicitudesItemsComiProv = new bool[] {false} ;
         BC000O4_A524SolicitudesItemsComiProvP = new decimal[1] ;
         BC000O4_n524SolicitudesItemsComiProvP = new bool[] {false} ;
         BC000O4_A523SolicitudesItemsComiALM = new decimal[1] ;
         BC000O4_n523SolicitudesItemsComiALM = new bool[] {false} ;
         BC000O4_A526SolicitudesItemsComiALMP = new decimal[1] ;
         BC000O4_n526SolicitudesItemsComiALMP = new bool[] {false} ;
         BC000O4_A121RubrosId = new short[1] ;
         BC000O4_A137MedidasID = new long[1] ;
         BC000O4_A135InventarioId = new long[1] ;
         BC000O52_A40000RubrosImagen_GXI = new string[] {""} ;
         BC000O52_A123RubrosEstado = new string[] {""} ;
         BC000O52_n123RubrosEstado = new bool[] {false} ;
         BC000O52_A168RubrosImagen = new string[] {""} ;
         BC000O53_A118MonedaId = new short[1] ;
         BC000O54_A119MonedaISOSimbolo = new string[] {""} ;
         BC000O55_A136InventarioNombre = new string[] {""} ;
         BC000O55_A40001InventarioImagen_GXI = new string[] {""} ;
         BC000O55_A181InventarioPrecioFinal = new decimal[1] ;
         BC000O55_A801InventarioConsumoProductivo = new decimal[1] ;
         BC000O55_A107EstadosTipo = new string[] {""} ;
         BC000O55_A108EstadosGenericosId = new int[1] ;
         BC000O55_A189InventarioImagen = new string[] {""} ;
         BC000O56_A127SolicitudesID = new long[1] ;
         BC000O56_A134SolicitudesItemsID = new short[1] ;
         BC000O56_A177SolicitudesItemsCantidad = new short[1] ;
         BC000O56_A180SolicitudItemsComision = new decimal[1] ;
         BC000O56_A178SolicitudItemsSR = new string[] {""} ;
         BC000O56_A179SolicitudItemsComisionTipo = new string[] {""} ;
         BC000O56_A40000RubrosImagen_GXI = new string[] {""} ;
         BC000O56_A123RubrosEstado = new string[] {""} ;
         BC000O56_n123RubrosEstado = new bool[] {false} ;
         BC000O56_A136InventarioNombre = new string[] {""} ;
         BC000O56_A40001InventarioImagen_GXI = new string[] {""} ;
         BC000O56_A181InventarioPrecioFinal = new decimal[1] ;
         BC000O56_A801InventarioConsumoProductivo = new decimal[1] ;
         BC000O56_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         BC000O56_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         BC000O56_A119MonedaISOSimbolo = new string[] {""} ;
         BC000O56_A521SolicitudesItemsComiProv = new decimal[1] ;
         BC000O56_n521SolicitudesItemsComiProv = new bool[] {false} ;
         BC000O56_A524SolicitudesItemsComiProvP = new decimal[1] ;
         BC000O56_n524SolicitudesItemsComiProvP = new bool[] {false} ;
         BC000O56_A523SolicitudesItemsComiALM = new decimal[1] ;
         BC000O56_n523SolicitudesItemsComiALM = new bool[] {false} ;
         BC000O56_A526SolicitudesItemsComiALMP = new decimal[1] ;
         BC000O56_n526SolicitudesItemsComiALMP = new bool[] {false} ;
         BC000O56_A121RubrosId = new short[1] ;
         BC000O56_A137MedidasID = new long[1] ;
         BC000O56_A135InventarioId = new long[1] ;
         BC000O56_A118MonedaId = new short[1] ;
         BC000O56_A107EstadosTipo = new string[] {""} ;
         BC000O56_A108EstadosGenericosId = new int[1] ;
         BC000O56_A168RubrosImagen = new string[] {""} ;
         BC000O56_A189InventarioImagen = new string[] {""} ;
         Z989ArchivoDireccion = "";
         A989ArchivoDireccion = "";
         Z990ArchivoDescripcion = "";
         A990ArchivoDescripcion = "";
         Z991ArchivoTipo = "";
         A991ArchivoTipo = "";
         BC000O57_A127SolicitudesID = new long[1] ;
         BC000O57_A988ArchivoId = new long[1] ;
         BC000O57_A989ArchivoDireccion = new string[] {""} ;
         BC000O57_A990ArchivoDescripcion = new string[] {""} ;
         BC000O57_A991ArchivoTipo = new string[] {""} ;
         BC000O58_A127SolicitudesID = new long[1] ;
         BC000O58_A988ArchivoId = new long[1] ;
         BC000O3_A127SolicitudesID = new long[1] ;
         BC000O3_A988ArchivoId = new long[1] ;
         BC000O3_A989ArchivoDireccion = new string[] {""} ;
         BC000O3_A990ArchivoDescripcion = new string[] {""} ;
         BC000O3_A991ArchivoTipo = new string[] {""} ;
         sMode144 = "";
         BC000O2_A127SolicitudesID = new long[1] ;
         BC000O2_A988ArchivoId = new long[1] ;
         BC000O2_A989ArchivoDireccion = new string[] {""} ;
         BC000O2_A990ArchivoDescripcion = new string[] {""} ;
         BC000O2_A991ArchivoTipo = new string[] {""} ;
         BC000O62_A127SolicitudesID = new long[1] ;
         BC000O62_A988ArchivoId = new long[1] ;
         BC000O62_A989ArchivoDireccion = new string[] {""} ;
         BC000O62_A990ArchivoDescripcion = new string[] {""} ;
         BC000O62_A991ArchivoTipo = new string[] {""} ;
         i130EstadosSolTipo = "";
         i201SolicitudesOtros1 = "";
         i600SolicitudesSubTipo = "";
         BC000O63_A127SolicitudesID = new long[1] ;
         BC000O63_A134SolicitudesItemsID = new short[1] ;
         BC000O63_A180SolicitudItemsComision = new decimal[1] ;
         BC000O63_A179SolicitudItemsComisionTipo = new string[] {""} ;
         BC000O63_A178SolicitudItemsSR = new string[] {""} ;
         BC000O63_A177SolicitudesItemsCantidad = new short[1] ;
         BC000O63_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         BC000O63_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.solicitudes_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.solicitudes_bc__default(),
            new Object[][] {
                new Object[] {
               BC000O2_A127SolicitudesID, BC000O2_A988ArchivoId, BC000O2_A989ArchivoDireccion, BC000O2_A990ArchivoDescripcion, BC000O2_A991ArchivoTipo
               }
               , new Object[] {
               BC000O3_A127SolicitudesID, BC000O3_A988ArchivoId, BC000O3_A989ArchivoDireccion, BC000O3_A990ArchivoDescripcion, BC000O3_A991ArchivoTipo
               }
               , new Object[] {
               BC000O4_A127SolicitudesID, BC000O4_A134SolicitudesItemsID, BC000O4_A177SolicitudesItemsCantidad, BC000O4_A180SolicitudItemsComision, BC000O4_A178SolicitudItemsSR, BC000O4_A179SolicitudItemsComisionTipo, BC000O4_A176SolicitudesItemsPrecioFinal, BC000O4_n176SolicitudesItemsPrecioFinal, BC000O4_A521SolicitudesItemsComiProv, BC000O4_n521SolicitudesItemsComiProv,
               BC000O4_A524SolicitudesItemsComiProvP, BC000O4_n524SolicitudesItemsComiProvP, BC000O4_A523SolicitudesItemsComiALM, BC000O4_n523SolicitudesItemsComiALM, BC000O4_A526SolicitudesItemsComiALMP, BC000O4_n526SolicitudesItemsComiALMP, BC000O4_A121RubrosId, BC000O4_A137MedidasID, BC000O4_A135InventarioId
               }
               , new Object[] {
               BC000O5_A127SolicitudesID, BC000O5_A134SolicitudesItemsID, BC000O5_A177SolicitudesItemsCantidad, BC000O5_A180SolicitudItemsComision, BC000O5_A178SolicitudItemsSR, BC000O5_A179SolicitudItemsComisionTipo, BC000O5_A176SolicitudesItemsPrecioFinal, BC000O5_n176SolicitudesItemsPrecioFinal, BC000O5_A521SolicitudesItemsComiProv, BC000O5_n521SolicitudesItemsComiProv,
               BC000O5_A524SolicitudesItemsComiProvP, BC000O5_n524SolicitudesItemsComiProvP, BC000O5_A523SolicitudesItemsComiALM, BC000O5_n523SolicitudesItemsComiALM, BC000O5_A526SolicitudesItemsComiALMP, BC000O5_n526SolicitudesItemsComiALMP, BC000O5_A121RubrosId, BC000O5_A137MedidasID, BC000O5_A135InventarioId
               }
               , new Object[] {
               BC000O6_A40000RubrosImagen_GXI, BC000O6_A123RubrosEstado, BC000O6_n123RubrosEstado, BC000O6_A168RubrosImagen
               }
               , new Object[] {
               BC000O7_A118MonedaId
               }
               , new Object[] {
               BC000O8_A136InventarioNombre, BC000O8_A40001InventarioImagen_GXI, BC000O8_A181InventarioPrecioFinal, BC000O8_A801InventarioConsumoProductivo, BC000O8_A107EstadosTipo, BC000O8_A108EstadosGenericosId, BC000O8_A189InventarioImagen
               }
               , new Object[] {
               BC000O9_A119MonedaISOSimbolo
               }
               , new Object[] {
               BC000O10_A127SolicitudesID, BC000O10_A438SolicitudServicioOrigenPago, BC000O10_n438SolicitudServicioOrigenPago, BC000O10_A866SolicitudesCostoXZComAlmP, BC000O10_n866SolicitudesCostoXZComAlmP, BC000O10_A865SolicitudesCostoXZComAlm, BC000O10_n865SolicitudesCostoXZComAlm, BC000O10_A182SolicitudesFechaAlta, BC000O10_n182SolicitudesFechaAlta, BC000O10_A171SolicitudesNombre,
               BC000O10_A172SolicitudesTelefono, BC000O10_A206SolicitudesMail, BC000O10_n206SolicitudesMail, BC000O10_A173SolicitudesDireccion, BC000O10_A194SolicitudesAutoEnumerar, BC000O10_A688SolicitudesLiqProf, BC000O10_n688SolicitudesLiqProf, BC000O10_A689SolicitudesLiqProv, BC000O10_n689SolicitudesLiqProv, BC000O10_A212SolicitudesCotizacion,
               BC000O10_A210SolicitudServicioSolCoti, BC000O10_A897SolicitudesDescuento, BC000O10_n897SolicitudesDescuento, BC000O10_A1016SolicitudesDescuentoCupon, BC000O10_A796SolicitudesComisionMetodoPago, BC000O10_A201SolicitudesOtros1, BC000O10_A202SolicitudesOtros2, BC000O10_A203SolicitudesOtros3, BC000O10_A597SolicitudesUsrAlta, BC000O10_n597SolicitudesUsrAlta,
               BC000O10_A598SolicitudesUsrActualizacion, BC000O10_n598SolicitudesUsrActualizacion, BC000O10_A204SolicitudesFechaActualizacion, BC000O10_n204SolicitudesFechaActualizacion, BC000O10_A184SolicitudesFechaInstalacion, BC000O10_A183SolicitudesHoraInstalacion, BC000O10_A205SolicitudesComentario, BC000O10_A261SolicitudesNota, BC000O10_A262SolicitudesNotificacion, BC000O10_A441SolicitudesPagado,
               BC000O10_n441SolicitudesPagado, BC000O10_A527SolicitudServicioComProv, BC000O10_n527SolicitudServicioComProv, BC000O10_A528SolicitudServicioComProvP, BC000O10_n528SolicitudServicioComProvP, BC000O10_A530SolicitudServicioComALM, BC000O10_n530SolicitudServicioComALM, BC000O10_A532SolicitudServicioComALMP, BC000O10_n532SolicitudServicioComALMP, BC000O10_A672SolicitudesCalComi,
               BC000O10_A533ProveedorNombreAux, BC000O10_n533ProveedorNombreAux, BC000O10_A600SolicitudesSubTipo, BC000O10_n600SolicitudesSubTipo, BC000O10_A864SolicitudesCostoXZona, BC000O10_A972SolicitudesDuplicado, BC000O10_n972SolicitudesDuplicado, BC000O10_A992SolicitudesSerialArchivo, BC000O10_A1003SolicitudesCostoPresupuesto, BC000O10_n1003SolicitudesCostoPresupuesto,
               BC000O10_A1006SolicitudesURLOrigen, BC000O10_n1006SolicitudesURLOrigen, BC000O10_A112DepartamentoId, BC000O10_n112DepartamentoId, BC000O10_A114DepartamentoMunicipioId, BC000O10_n114DepartamentoMunicipioId, BC000O10_A110ZonasID, BC000O10_n110ZonasID, BC000O10_A128MetodoPagosID, BC000O10_A735MudanzaId,
               BC000O10_n735MudanzaId, BC000O10_A133ProveedorID, BC000O10_A919STComerciosID, BC000O10_n919STComerciosID, BC000O10_A422PostulacionesId, BC000O10_n422PostulacionesId, BC000O10_A996CancelacionTipificacionId, BC000O10_A1013CuponId, BC000O10_n1013CuponId, BC000O10_A1020TicketId,
               BC000O10_n1020TicketId, BC000O10_A130EstadosSolTipo, BC000O10_A131EstadosSolId, BC000O10_A669STMonedasId, BC000O10_n669STMonedasId
               }
               , new Object[] {
               BC000O11_A127SolicitudesID, BC000O11_A438SolicitudServicioOrigenPago, BC000O11_n438SolicitudServicioOrigenPago, BC000O11_A866SolicitudesCostoXZComAlmP, BC000O11_n866SolicitudesCostoXZComAlmP, BC000O11_A865SolicitudesCostoXZComAlm, BC000O11_n865SolicitudesCostoXZComAlm, BC000O11_A182SolicitudesFechaAlta, BC000O11_n182SolicitudesFechaAlta, BC000O11_A171SolicitudesNombre,
               BC000O11_A172SolicitudesTelefono, BC000O11_A206SolicitudesMail, BC000O11_n206SolicitudesMail, BC000O11_A173SolicitudesDireccion, BC000O11_A194SolicitudesAutoEnumerar, BC000O11_A688SolicitudesLiqProf, BC000O11_n688SolicitudesLiqProf, BC000O11_A689SolicitudesLiqProv, BC000O11_n689SolicitudesLiqProv, BC000O11_A212SolicitudesCotizacion,
               BC000O11_A210SolicitudServicioSolCoti, BC000O11_A897SolicitudesDescuento, BC000O11_n897SolicitudesDescuento, BC000O11_A1016SolicitudesDescuentoCupon, BC000O11_A796SolicitudesComisionMetodoPago, BC000O11_A201SolicitudesOtros1, BC000O11_A202SolicitudesOtros2, BC000O11_A203SolicitudesOtros3, BC000O11_A597SolicitudesUsrAlta, BC000O11_n597SolicitudesUsrAlta,
               BC000O11_A598SolicitudesUsrActualizacion, BC000O11_n598SolicitudesUsrActualizacion, BC000O11_A204SolicitudesFechaActualizacion, BC000O11_n204SolicitudesFechaActualizacion, BC000O11_A184SolicitudesFechaInstalacion, BC000O11_A183SolicitudesHoraInstalacion, BC000O11_A205SolicitudesComentario, BC000O11_A261SolicitudesNota, BC000O11_A262SolicitudesNotificacion, BC000O11_A441SolicitudesPagado,
               BC000O11_n441SolicitudesPagado, BC000O11_A527SolicitudServicioComProv, BC000O11_n527SolicitudServicioComProv, BC000O11_A528SolicitudServicioComProvP, BC000O11_n528SolicitudServicioComProvP, BC000O11_A530SolicitudServicioComALM, BC000O11_n530SolicitudServicioComALM, BC000O11_A532SolicitudServicioComALMP, BC000O11_n532SolicitudServicioComALMP, BC000O11_A672SolicitudesCalComi,
               BC000O11_A533ProveedorNombreAux, BC000O11_n533ProveedorNombreAux, BC000O11_A600SolicitudesSubTipo, BC000O11_n600SolicitudesSubTipo, BC000O11_A864SolicitudesCostoXZona, BC000O11_A972SolicitudesDuplicado, BC000O11_n972SolicitudesDuplicado, BC000O11_A992SolicitudesSerialArchivo, BC000O11_A1003SolicitudesCostoPresupuesto, BC000O11_n1003SolicitudesCostoPresupuesto,
               BC000O11_A1006SolicitudesURLOrigen, BC000O11_n1006SolicitudesURLOrigen, BC000O11_A112DepartamentoId, BC000O11_n112DepartamentoId, BC000O11_A114DepartamentoMunicipioId, BC000O11_n114DepartamentoMunicipioId, BC000O11_A110ZonasID, BC000O11_n110ZonasID, BC000O11_A128MetodoPagosID, BC000O11_A735MudanzaId,
               BC000O11_n735MudanzaId, BC000O11_A133ProveedorID, BC000O11_A919STComerciosID, BC000O11_n919STComerciosID, BC000O11_A422PostulacionesId, BC000O11_n422PostulacionesId, BC000O11_A996CancelacionTipificacionId, BC000O11_A1013CuponId, BC000O11_n1013CuponId, BC000O11_A1020TicketId,
               BC000O11_n1020TicketId, BC000O11_A130EstadosSolTipo, BC000O11_A131EstadosSolId, BC000O11_A669STMonedasId, BC000O11_n669STMonedasId
               }
               , new Object[] {
               BC000O12_A116PaisID
               }
               , new Object[] {
               BC000O13_A116PaisID
               }
               , new Object[] {
               BC000O14_A112DepartamentoId
               }
               , new Object[] {
               BC000O15_A110ZonasID
               }
               , new Object[] {
               BC000O16_A129MetodoPagosNombre
               }
               , new Object[] {
               BC000O17_A738MudanzaFechaServicio, BC000O17_A740MudanzaDireccionOrigen, BC000O17_A741MudanzaDireccionDestino
               }
               , new Object[] {
               BC000O18_A282ProveedorNombre, BC000O18_A440ProveedorPagoDefault
               }
               , new Object[] {
               BC000O19_A923STComerciosNombre, BC000O19_A924STComerciosEstado
               }
               , new Object[] {
               BC000O20_A422PostulacionesId
               }
               , new Object[] {
               BC000O21_A997CancelacionTipificacionDescrip
               }
               , new Object[] {
               BC000O22_A1014CuponPercent
               }
               , new Object[] {
               BC000O23_A1024TicketComentario, BC000O23_A1026TicketAdjunto, BC000O23_A1030TicketEstado, BC000O23_A1023TicketSolicitudId, BC000O23_A1021TicketMotivoId
               }
               , new Object[] {
               BC000O24_A132EstadosSolNombre
               }
               , new Object[] {
               BC000O25_A671STMonedasISO
               }
               , new Object[] {
               BC000O26_A1022TicketMotivoDescripcion
               }
               , new Object[] {
               BC000O27_A127SolicitudesID, BC000O27_A438SolicitudServicioOrigenPago, BC000O27_n438SolicitudServicioOrigenPago, BC000O27_A866SolicitudesCostoXZComAlmP, BC000O27_n866SolicitudesCostoXZComAlmP, BC000O27_A865SolicitudesCostoXZComAlm, BC000O27_n865SolicitudesCostoXZComAlm, BC000O27_A182SolicitudesFechaAlta, BC000O27_n182SolicitudesFechaAlta, BC000O27_A171SolicitudesNombre,
               BC000O27_A172SolicitudesTelefono, BC000O27_A206SolicitudesMail, BC000O27_n206SolicitudesMail, BC000O27_A173SolicitudesDireccion, BC000O27_A194SolicitudesAutoEnumerar, BC000O27_A671STMonedasISO, BC000O27_A688SolicitudesLiqProf, BC000O27_n688SolicitudesLiqProf, BC000O27_A689SolicitudesLiqProv, BC000O27_n689SolicitudesLiqProv,
               BC000O27_A212SolicitudesCotizacion, BC000O27_A210SolicitudServicioSolCoti, BC000O27_A897SolicitudesDescuento, BC000O27_n897SolicitudesDescuento, BC000O27_A1014CuponPercent, BC000O27_A1016SolicitudesDescuentoCupon, BC000O27_A796SolicitudesComisionMetodoPago, BC000O27_A132EstadosSolNombre, BC000O27_A201SolicitudesOtros1, BC000O27_A202SolicitudesOtros2,
               BC000O27_A203SolicitudesOtros3, BC000O27_A597SolicitudesUsrAlta, BC000O27_n597SolicitudesUsrAlta, BC000O27_A598SolicitudesUsrActualizacion, BC000O27_n598SolicitudesUsrActualizacion, BC000O27_A204SolicitudesFechaActualizacion, BC000O27_n204SolicitudesFechaActualizacion, BC000O27_A184SolicitudesFechaInstalacion, BC000O27_A183SolicitudesHoraInstalacion, BC000O27_A205SolicitudesComentario,
               BC000O27_A129MetodoPagosNombre, BC000O27_A261SolicitudesNota, BC000O27_A262SolicitudesNotificacion, BC000O27_A282ProveedorNombre, BC000O27_A440ProveedorPagoDefault, BC000O27_A923STComerciosNombre, BC000O27_A924STComerciosEstado, BC000O27_A441SolicitudesPagado, BC000O27_n441SolicitudesPagado, BC000O27_A527SolicitudServicioComProv,
               BC000O27_n527SolicitudServicioComProv, BC000O27_A528SolicitudServicioComProvP, BC000O27_n528SolicitudServicioComProvP, BC000O27_A530SolicitudServicioComALM, BC000O27_n530SolicitudServicioComALM, BC000O27_A532SolicitudServicioComALMP, BC000O27_n532SolicitudServicioComALMP, BC000O27_A672SolicitudesCalComi, BC000O27_A533ProveedorNombreAux, BC000O27_n533ProveedorNombreAux,
               BC000O27_A600SolicitudesSubTipo, BC000O27_n600SolicitudesSubTipo, BC000O27_A864SolicitudesCostoXZona, BC000O27_A738MudanzaFechaServicio, BC000O27_A740MudanzaDireccionOrigen, BC000O27_A741MudanzaDireccionDestino, BC000O27_A972SolicitudesDuplicado, BC000O27_n972SolicitudesDuplicado, BC000O27_A992SolicitudesSerialArchivo, BC000O27_A997CancelacionTipificacionDescrip,
               BC000O27_A1003SolicitudesCostoPresupuesto, BC000O27_n1003SolicitudesCostoPresupuesto, BC000O27_A1006SolicitudesURLOrigen, BC000O27_n1006SolicitudesURLOrigen, BC000O27_A1022TicketMotivoDescripcion, BC000O27_A1024TicketComentario, BC000O27_A1026TicketAdjunto, BC000O27_A1030TicketEstado, BC000O27_A1023TicketSolicitudId, BC000O27_A112DepartamentoId,
               BC000O27_n112DepartamentoId, BC000O27_A114DepartamentoMunicipioId, BC000O27_n114DepartamentoMunicipioId, BC000O27_A110ZonasID, BC000O27_n110ZonasID, BC000O27_A128MetodoPagosID, BC000O27_A735MudanzaId, BC000O27_n735MudanzaId, BC000O27_A133ProveedorID, BC000O27_A919STComerciosID,
               BC000O27_n919STComerciosID, BC000O27_A422PostulacionesId, BC000O27_n422PostulacionesId, BC000O27_A996CancelacionTipificacionId, BC000O27_A1013CuponId, BC000O27_n1013CuponId, BC000O27_A1020TicketId, BC000O27_n1020TicketId, BC000O27_A130EstadosSolTipo, BC000O27_A131EstadosSolId,
               BC000O27_A669STMonedasId, BC000O27_n669STMonedasId, BC000O27_A116PaisID, BC000O27_A1021TicketMotivoId
               }
               , new Object[] {
               BC000O28_A127SolicitudesID
               }
               , new Object[] {
               BC000O29_A116PaisID
               }
               , new Object[] {
               BC000O30_A127SolicitudesID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000O33_A671STMonedasISO
               }
               , new Object[] {
               BC000O34_A1014CuponPercent
               }
               , new Object[] {
               BC000O35_A132EstadosSolNombre
               }
               , new Object[] {
               BC000O36_A129MetodoPagosNombre
               }
               , new Object[] {
               BC000O37_A282ProveedorNombre, BC000O37_A440ProveedorPagoDefault
               }
               , new Object[] {
               BC000O38_A923STComerciosNombre, BC000O38_A924STComerciosEstado
               }
               , new Object[] {
               BC000O39_A738MudanzaFechaServicio, BC000O39_A740MudanzaDireccionOrigen, BC000O39_A741MudanzaDireccionDestino
               }
               , new Object[] {
               BC000O40_A997CancelacionTipificacionDescrip
               }
               , new Object[] {
               BC000O41_A1024TicketComentario, BC000O41_A1026TicketAdjunto, BC000O41_A1030TicketEstado, BC000O41_A1023TicketSolicitudId, BC000O41_A1021TicketMotivoId
               }
               , new Object[] {
               BC000O42_A1022TicketMotivoDescripcion
               }
               , new Object[] {
               BC000O43_A127SolicitudesID, BC000O43_A140RelacionesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000O46_A127SolicitudesID, BC000O46_A438SolicitudServicioOrigenPago, BC000O46_n438SolicitudServicioOrigenPago, BC000O46_A866SolicitudesCostoXZComAlmP, BC000O46_n866SolicitudesCostoXZComAlmP, BC000O46_A865SolicitudesCostoXZComAlm, BC000O46_n865SolicitudesCostoXZComAlm, BC000O46_A182SolicitudesFechaAlta, BC000O46_n182SolicitudesFechaAlta, BC000O46_A171SolicitudesNombre,
               BC000O46_A172SolicitudesTelefono, BC000O46_A206SolicitudesMail, BC000O46_n206SolicitudesMail, BC000O46_A173SolicitudesDireccion, BC000O46_A194SolicitudesAutoEnumerar, BC000O46_A671STMonedasISO, BC000O46_A688SolicitudesLiqProf, BC000O46_n688SolicitudesLiqProf, BC000O46_A689SolicitudesLiqProv, BC000O46_n689SolicitudesLiqProv,
               BC000O46_A212SolicitudesCotizacion, BC000O46_A210SolicitudServicioSolCoti, BC000O46_A897SolicitudesDescuento, BC000O46_n897SolicitudesDescuento, BC000O46_A1014CuponPercent, BC000O46_A1016SolicitudesDescuentoCupon, BC000O46_A796SolicitudesComisionMetodoPago, BC000O46_A132EstadosSolNombre, BC000O46_A201SolicitudesOtros1, BC000O46_A202SolicitudesOtros2,
               BC000O46_A203SolicitudesOtros3, BC000O46_A597SolicitudesUsrAlta, BC000O46_n597SolicitudesUsrAlta, BC000O46_A598SolicitudesUsrActualizacion, BC000O46_n598SolicitudesUsrActualizacion, BC000O46_A204SolicitudesFechaActualizacion, BC000O46_n204SolicitudesFechaActualizacion, BC000O46_A184SolicitudesFechaInstalacion, BC000O46_A183SolicitudesHoraInstalacion, BC000O46_A205SolicitudesComentario,
               BC000O46_A129MetodoPagosNombre, BC000O46_A261SolicitudesNota, BC000O46_A262SolicitudesNotificacion, BC000O46_A282ProveedorNombre, BC000O46_A440ProveedorPagoDefault, BC000O46_A923STComerciosNombre, BC000O46_A924STComerciosEstado, BC000O46_A441SolicitudesPagado, BC000O46_n441SolicitudesPagado, BC000O46_A527SolicitudServicioComProv,
               BC000O46_n527SolicitudServicioComProv, BC000O46_A528SolicitudServicioComProvP, BC000O46_n528SolicitudServicioComProvP, BC000O46_A530SolicitudServicioComALM, BC000O46_n530SolicitudServicioComALM, BC000O46_A532SolicitudServicioComALMP, BC000O46_n532SolicitudServicioComALMP, BC000O46_A672SolicitudesCalComi, BC000O46_A533ProveedorNombreAux, BC000O46_n533ProveedorNombreAux,
               BC000O46_A600SolicitudesSubTipo, BC000O46_n600SolicitudesSubTipo, BC000O46_A864SolicitudesCostoXZona, BC000O46_A738MudanzaFechaServicio, BC000O46_A740MudanzaDireccionOrigen, BC000O46_A741MudanzaDireccionDestino, BC000O46_A972SolicitudesDuplicado, BC000O46_n972SolicitudesDuplicado, BC000O46_A992SolicitudesSerialArchivo, BC000O46_A997CancelacionTipificacionDescrip,
               BC000O46_A1003SolicitudesCostoPresupuesto, BC000O46_n1003SolicitudesCostoPresupuesto, BC000O46_A1006SolicitudesURLOrigen, BC000O46_n1006SolicitudesURLOrigen, BC000O46_A1022TicketMotivoDescripcion, BC000O46_A1024TicketComentario, BC000O46_A1026TicketAdjunto, BC000O46_A1030TicketEstado, BC000O46_A1023TicketSolicitudId, BC000O46_A112DepartamentoId,
               BC000O46_n112DepartamentoId, BC000O46_A114DepartamentoMunicipioId, BC000O46_n114DepartamentoMunicipioId, BC000O46_A110ZonasID, BC000O46_n110ZonasID, BC000O46_A128MetodoPagosID, BC000O46_A735MudanzaId, BC000O46_n735MudanzaId, BC000O46_A133ProveedorID, BC000O46_A919STComerciosID,
               BC000O46_n919STComerciosID, BC000O46_A422PostulacionesId, BC000O46_n422PostulacionesId, BC000O46_A996CancelacionTipificacionId, BC000O46_A1013CuponId, BC000O46_n1013CuponId, BC000O46_A1020TicketId, BC000O46_n1020TicketId, BC000O46_A130EstadosSolTipo, BC000O46_A131EstadosSolId,
               BC000O46_A669STMonedasId, BC000O46_n669STMonedasId, BC000O46_A116PaisID, BC000O46_A1021TicketMotivoId
               }
               , new Object[] {
               BC000O47_A127SolicitudesID, BC000O47_A134SolicitudesItemsID, BC000O47_A177SolicitudesItemsCantidad, BC000O47_A180SolicitudItemsComision, BC000O47_A178SolicitudItemsSR, BC000O47_A179SolicitudItemsComisionTipo, BC000O47_A40000RubrosImagen_GXI, BC000O47_A123RubrosEstado, BC000O47_n123RubrosEstado, BC000O47_A136InventarioNombre,
               BC000O47_A40001InventarioImagen_GXI, BC000O47_A181InventarioPrecioFinal, BC000O47_A801InventarioConsumoProductivo, BC000O47_A176SolicitudesItemsPrecioFinal, BC000O47_n176SolicitudesItemsPrecioFinal, BC000O47_A119MonedaISOSimbolo, BC000O47_A521SolicitudesItemsComiProv, BC000O47_n521SolicitudesItemsComiProv, BC000O47_A524SolicitudesItemsComiProvP, BC000O47_n524SolicitudesItemsComiProvP,
               BC000O47_A523SolicitudesItemsComiALM, BC000O47_n523SolicitudesItemsComiALM, BC000O47_A526SolicitudesItemsComiALMP, BC000O47_n526SolicitudesItemsComiALMP, BC000O47_A121RubrosId, BC000O47_A137MedidasID, BC000O47_A135InventarioId, BC000O47_A118MonedaId, BC000O47_A107EstadosTipo, BC000O47_A108EstadosGenericosId,
               BC000O47_A168RubrosImagen, BC000O47_A189InventarioImagen
               }
               , new Object[] {
               BC000O48_A127SolicitudesID, BC000O48_A134SolicitudesItemsID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000O52_A40000RubrosImagen_GXI, BC000O52_A123RubrosEstado, BC000O52_n123RubrosEstado, BC000O52_A168RubrosImagen
               }
               , new Object[] {
               BC000O53_A118MonedaId
               }
               , new Object[] {
               BC000O54_A119MonedaISOSimbolo
               }
               , new Object[] {
               BC000O55_A136InventarioNombre, BC000O55_A40001InventarioImagen_GXI, BC000O55_A181InventarioPrecioFinal, BC000O55_A801InventarioConsumoProductivo, BC000O55_A107EstadosTipo, BC000O55_A108EstadosGenericosId, BC000O55_A189InventarioImagen
               }
               , new Object[] {
               BC000O56_A127SolicitudesID, BC000O56_A134SolicitudesItemsID, BC000O56_A177SolicitudesItemsCantidad, BC000O56_A180SolicitudItemsComision, BC000O56_A178SolicitudItemsSR, BC000O56_A179SolicitudItemsComisionTipo, BC000O56_A40000RubrosImagen_GXI, BC000O56_A123RubrosEstado, BC000O56_n123RubrosEstado, BC000O56_A136InventarioNombre,
               BC000O56_A40001InventarioImagen_GXI, BC000O56_A181InventarioPrecioFinal, BC000O56_A801InventarioConsumoProductivo, BC000O56_A176SolicitudesItemsPrecioFinal, BC000O56_n176SolicitudesItemsPrecioFinal, BC000O56_A119MonedaISOSimbolo, BC000O56_A521SolicitudesItemsComiProv, BC000O56_n521SolicitudesItemsComiProv, BC000O56_A524SolicitudesItemsComiProvP, BC000O56_n524SolicitudesItemsComiProvP,
               BC000O56_A523SolicitudesItemsComiALM, BC000O56_n523SolicitudesItemsComiALM, BC000O56_A526SolicitudesItemsComiALMP, BC000O56_n526SolicitudesItemsComiALMP, BC000O56_A121RubrosId, BC000O56_A137MedidasID, BC000O56_A135InventarioId, BC000O56_A118MonedaId, BC000O56_A107EstadosTipo, BC000O56_A108EstadosGenericosId,
               BC000O56_A168RubrosImagen, BC000O56_A189InventarioImagen
               }
               , new Object[] {
               BC000O57_A127SolicitudesID, BC000O57_A988ArchivoId, BC000O57_A989ArchivoDireccion, BC000O57_A990ArchivoDescripcion, BC000O57_A991ArchivoTipo
               }
               , new Object[] {
               BC000O58_A127SolicitudesID, BC000O58_A988ArchivoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000O62_A127SolicitudesID, BC000O62_A988ArchivoId, BC000O62_A989ArchivoDireccion, BC000O62_A990ArchivoDescripcion, BC000O62_A991ArchivoTipo
               }
               , new Object[] {
               BC000O63_A127SolicitudesID, BC000O63_A134SolicitudesItemsID, BC000O63_A180SolicitudItemsComision, BC000O63_A179SolicitudItemsComisionTipo, BC000O63_A178SolicitudItemsSR, BC000O63_A177SolicitudesItemsCantidad, BC000O63_A176SolicitudesItemsPrecioFinal, BC000O63_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         Z996CancelacionTipificacionId = 0;
         A996CancelacionTipificacionId = 0;
         i996CancelacionTipificacionId = 0;
         Z1013CuponId = 1234;
         n1013CuponId = false;
         A1013CuponId = 1234;
         n1013CuponId = false;
         AV93Pgmname = "Solicitudes_BC";
         Z600SolicitudesSubTipo = "T";
         n600SolicitudesSubTipo = false;
         A600SolicitudesSubTipo = "T";
         n600SolicitudesSubTipo = false;
         i600SolicitudesSubTipo = "T";
         n600SolicitudesSubTipo = false;
         Z133ProveedorID = 1001;
         A133ProveedorID = 1001;
         O133ProveedorID = 1001;
         i133ProveedorID = 1001;
         Z201SolicitudesOtros1 = context.GetMessage( "N", "");
         A201SolicitudesOtros1 = context.GetMessage( "N", "");
         i201SolicitudesOtros1 = context.GetMessage( "N", "");
         Z177SolicitudesItemsCantidad = 1;
         A177SolicitudesItemsCantidad = 1;
         i177SolicitudesItemsCantidad = 1;
         Z112DepartamentoId = 1;
         n112DepartamentoId = false;
         A112DepartamentoId = 1;
         n112DepartamentoId = false;
         Z131EstadosSolId = 1;
         A131EstadosSolId = 1;
         O131EstadosSolId = 1;
         i131EstadosSolId = 1;
         Z130EstadosSolTipo = context.GetMessage( "SOL", "");
         A130EstadosSolTipo = context.GetMessage( "SOL", "");
         i130EstadosSolTipo = context.GetMessage( "SOL", "");
         Z669STMonedasId = 1;
         n669STMonedasId = false;
         A669STMonedasId = 1;
         n669STMonedasId = false;
         i669STMonedasId = 1;
         n669STMonedasId = false;
         Z116PaisID = "UY";
         A116PaisID = "UY";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120O2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short s992SolicitudesSerialArchivo ;
      private short O992SolicitudesSerialArchivo ;
      private short A992SolicitudesSerialArchivo ;
      private short nIsMod_144 ;
      private short RcdFound144 ;
      private short s194SolicitudesAutoEnumerar ;
      private short O194SolicitudesAutoEnumerar ;
      private short A194SolicitudesAutoEnumerar ;
      private short nIsMod_31 ;
      private short RcdFound31 ;
      private short AV11RubrosId ;
      private short GXt_int1 ;
      private short AV54Insert_STMonedasId ;
      private short Z194SolicitudesAutoEnumerar ;
      private short Z992SolicitudesSerialArchivo ;
      private short Z669STMonedasId ;
      private short A669STMonedasId ;
      private short Z1014CuponPercent ;
      private short A1014CuponPercent ;
      private short Gx_BScreen ;
      private short RcdFound30 ;
      private short nRcdExists_31 ;
      private short nRcdExists_144 ;
      private short Z177SolicitudesItemsCantidad ;
      private short A177SolicitudesItemsCantidad ;
      private short Z121RubrosId ;
      private short A121RubrosId ;
      private short Z118MonedaId ;
      private short A118MonedaId ;
      private short Z134SolicitudesItemsID ;
      private short A134SolicitudesItemsID ;
      private short Gxremove31 ;
      private short Gxremove144 ;
      private short i669STMonedasId ;
      private short i194SolicitudesAutoEnumerar ;
      private short i177SolicitudesItemsCantidad ;
      private short i992SolicitudesSerialArchivo ;
      private int trnEnded ;
      private int nGXsfl_144_idx=1 ;
      private int nGXsfl_31_idx=1 ;
      private int AV94GXV1 ;
      private int AV23Insert_EstadosSolId ;
      private int Z131EstadosSolId ;
      private int A131EstadosSolId ;
      private int AV73OldEstadosSolId ;
      private int O131EstadosSolId ;
      private int Z108EstadosGenericosId ;
      private int A108EstadosGenericosId ;
      private int i131EstadosSolId ;
      private long Z127SolicitudesID ;
      private long A127SolicitudesID ;
      private long AV71oldProveedorID ;
      private long AV19Insert_DepartamentoId ;
      private long AV20Insert_DepartamentoMunicipioId ;
      private long AV21Insert_ZonasID ;
      private long AV89Insert_CuponId ;
      private long AV24Insert_MetodoPagosID ;
      private long AV25Insert_ProveedorID ;
      private long AV82Insert_STComerciosID ;
      private long AV72Insert_MudanzaId ;
      private long AV83Insert_PostulacionesId ;
      private long AV84Insert_CancelacionTipificacionId ;
      private long AV91Insert_TicketId ;
      private long AV7SolicitudesID ;
      private long AV8CostosId ;
      private long Z688SolicitudesLiqProf ;
      private long A688SolicitudesLiqProf ;
      private long Z689SolicitudesLiqProv ;
      private long A689SolicitudesLiqProv ;
      private long Z597SolicitudesUsrAlta ;
      private long A597SolicitudesUsrAlta ;
      private long Z598SolicitudesUsrActualizacion ;
      private long A598SolicitudesUsrActualizacion ;
      private long Z972SolicitudesDuplicado ;
      private long A972SolicitudesDuplicado ;
      private long Z112DepartamentoId ;
      private long A112DepartamentoId ;
      private long Z114DepartamentoMunicipioId ;
      private long A114DepartamentoMunicipioId ;
      private long Z110ZonasID ;
      private long A110ZonasID ;
      private long Z128MetodoPagosID ;
      private long A128MetodoPagosID ;
      private long Z735MudanzaId ;
      private long A735MudanzaId ;
      private long Z133ProveedorID ;
      private long A133ProveedorID ;
      private long Z919STComerciosID ;
      private long A919STComerciosID ;
      private long Z422PostulacionesId ;
      private long A422PostulacionesId ;
      private long Z996CancelacionTipificacionId ;
      private long A996CancelacionTipificacionId ;
      private long Z1013CuponId ;
      private long A1013CuponId ;
      private long Z1020TicketId ;
      private long A1020TicketId ;
      private long Z1023TicketSolicitudId ;
      private long A1023TicketSolicitudId ;
      private long Z1021TicketMotivoId ;
      private long A1021TicketMotivoId ;
      private long O133ProveedorID ;
      private long Z137MedidasID ;
      private long A137MedidasID ;
      private long Z135InventarioId ;
      private long A135InventarioId ;
      private long Z988ArchivoId ;
      private long A988ArchivoId ;
      private long i996CancelacionTipificacionId ;
      private long i133ProveedorID ;
      private decimal s211SolicitudServicioPFinal ;
      private decimal O211SolicitudServicioPFinal ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal s174SolicitudesTotal ;
      private decimal O174SolicitudesTotal ;
      private decimal A174SolicitudesTotal ;
      private decimal s529SolicitudServicioComPro ;
      private decimal O529SolicitudServicioComPro ;
      private decimal A529SolicitudServicioComPro ;
      private decimal sV52OldSolicitudServicioPFinal ;
      private decimal OV52OldSolicitudServicioPFinal ;
      private decimal AV52OldSolicitudServicioPFinal ;
      private decimal AV12SolicitudServicioComProv ;
      private decimal AV56SolicitudServicioComProvP ;
      private decimal AV57OldSolicitudServicioComProvP ;
      private decimal AV58OldSolicitudServicioComProv ;
      private decimal AV60SolicitudServicioComALM ;
      private decimal AV59OldSolicitudServicioComALMP ;
      private decimal AV61SolicitudServicioComALMP ;
      private decimal AV62OldSolicitudServicioComALM ;
      private decimal AV85PrecioFinal ;
      private decimal AV77SolicitudesCostoXZComAlmP ;
      private decimal GXt_decimal2 ;
      private decimal Z866SolicitudesCostoXZComAlmP ;
      private decimal A866SolicitudesCostoXZComAlmP ;
      private decimal Z865SolicitudesCostoXZComAlm ;
      private decimal A865SolicitudesCostoXZComAlm ;
      private decimal Z212SolicitudesCotizacion ;
      private decimal A212SolicitudesCotizacion ;
      private decimal Z897SolicitudesDescuento ;
      private decimal A897SolicitudesDescuento ;
      private decimal Z1016SolicitudesDescuentoCupon ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal Z796SolicitudesComisionMetodoPago ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal Z527SolicitudServicioComProv ;
      private decimal A527SolicitudServicioComProv ;
      private decimal Z528SolicitudServicioComProvP ;
      private decimal A528SolicitudServicioComProvP ;
      private decimal Z530SolicitudServicioComALM ;
      private decimal A530SolicitudServicioComALM ;
      private decimal Z532SolicitudServicioComALMP ;
      private decimal A532SolicitudServicioComALMP ;
      private decimal Z864SolicitudesCostoXZona ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal Z1003SolicitudesCostoPresupuesto ;
      private decimal A1003SolicitudesCostoPresupuesto ;
      private decimal Z174SolicitudesTotal ;
      private decimal Z211SolicitudServicioPFinal ;
      private decimal Z529SolicitudServicioComPro ;
      private decimal Z531SolicitudServicioComProP ;
      private decimal A531SolicitudServicioComProP ;
      private decimal Z867SolicitudesCostoXZComProf ;
      private decimal A867SolicitudesCostoXZComProf ;
      private decimal Z868SolicitudesCostoXZComProfP ;
      private decimal A868SolicitudesCostoXZComProfP ;
      private decimal AV53OldSolicitudesCotizacion ;
      private decimal O212SolicitudesCotizacion ;
      private decimal Z180SolicitudItemsComision ;
      private decimal A180SolicitudItemsComision ;
      private decimal Z176SolicitudesItemsPrecioFinal ;
      private decimal A176SolicitudesItemsPrecioFinal ;
      private decimal Z521SolicitudesItemsComiProv ;
      private decimal A521SolicitudesItemsComiProv ;
      private decimal Z524SolicitudesItemsComiProvP ;
      private decimal A524SolicitudesItemsComiProvP ;
      private decimal Z523SolicitudesItemsComiALM ;
      private decimal A523SolicitudesItemsComiALM ;
      private decimal Z526SolicitudesItemsComiALMP ;
      private decimal A526SolicitudesItemsComiALMP ;
      private decimal Z175SolicitudesItemsPrecioInstalac ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private decimal Z522SolicitudesItemsComiProf ;
      private decimal A522SolicitudesItemsComiProf ;
      private decimal Z525SolicitudesItemsComiProfP ;
      private decimal A525SolicitudesItemsComiProfP ;
      private decimal Z181InventarioPrecioFinal ;
      private decimal A181InventarioPrecioFinal ;
      private decimal Z801InventarioConsumoProductivo ;
      private decimal A801InventarioConsumoProductivo ;
      private decimal O175SolicitudesItemsPrecioInstalac ;
      private decimal AV87SolicitudesItemsPrecioFinal ;
      private decimal N796SolicitudesComisionMetodoPago ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode30 ;
      private string AV93Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22Insert_EstadosSolTipo ;
      private string AV74ProfesionalesId ;
      private string AV9Modo ;
      private string Z438SolicitudServicioOrigenPago ;
      private string A438SolicitudServicioOrigenPago ;
      private string Z171SolicitudesNombre ;
      private string A171SolicitudesNombre ;
      private string Z172SolicitudesTelefono ;
      private string A172SolicitudesTelefono ;
      private string Z210SolicitudServicioSolCoti ;
      private string A210SolicitudServicioSolCoti ;
      private string Z201SolicitudesOtros1 ;
      private string A201SolicitudesOtros1 ;
      private string Z202SolicitudesOtros2 ;
      private string A202SolicitudesOtros2 ;
      private string Z203SolicitudesOtros3 ;
      private string A203SolicitudesOtros3 ;
      private string Z183SolicitudesHoraInstalacion ;
      private string A183SolicitudesHoraInstalacion ;
      private string Z261SolicitudesNota ;
      private string A261SolicitudesNota ;
      private string Z262SolicitudesNotificacion ;
      private string A262SolicitudesNotificacion ;
      private string Z441SolicitudesPagado ;
      private string A441SolicitudesPagado ;
      private string Z533ProveedorNombreAux ;
      private string A533ProveedorNombreAux ;
      private string Z600SolicitudesSubTipo ;
      private string A600SolicitudesSubTipo ;
      private string Z130EstadosSolTipo ;
      private string A130EstadosSolTipo ;
      private string Z116PaisID ;
      private string A116PaisID ;
      private string Z129MetodoPagosNombre ;
      private string A129MetodoPagosNombre ;
      private string Z282ProveedorNombre ;
      private string A282ProveedorNombre ;
      private string Z440ProveedorPagoDefault ;
      private string A440ProveedorPagoDefault ;
      private string Z923STComerciosNombre ;
      private string A923STComerciosNombre ;
      private string Z924STComerciosEstado ;
      private string A924STComerciosEstado ;
      private string Z997CancelacionTipificacionDescrip ;
      private string A997CancelacionTipificacionDescrip ;
      private string Z1024TicketComentario ;
      private string A1024TicketComentario ;
      private string Z1026TicketAdjunto ;
      private string A1026TicketAdjunto ;
      private string Z132EstadosSolNombre ;
      private string A132EstadosSolNombre ;
      private string Z671STMonedasISO ;
      private string A671STMonedasISO ;
      private string Z1022TicketMotivoDescripcion ;
      private string A1022TicketMotivoDescripcion ;
      private string Z178SolicitudItemsSR ;
      private string A178SolicitudItemsSR ;
      private string Z179SolicitudItemsComisionTipo ;
      private string A179SolicitudItemsComisionTipo ;
      private string Z123RubrosEstado ;
      private string A123RubrosEstado ;
      private string Z136InventarioNombre ;
      private string A136InventarioNombre ;
      private string Z107EstadosTipo ;
      private string A107EstadosTipo ;
      private string Z119MonedaISOSimbolo ;
      private string A119MonedaISOSimbolo ;
      private string sMode31 ;
      private string Z989ArchivoDireccion ;
      private string A989ArchivoDireccion ;
      private string Z990ArchivoDescripcion ;
      private string A990ArchivoDescripcion ;
      private string sMode144 ;
      private string i130EstadosSolTipo ;
      private string i201SolicitudesOtros1 ;
      private string i600SolicitudesSubTipo ;
      private DateTime Z204SolicitudesFechaActualizacion ;
      private DateTime A204SolicitudesFechaActualizacion ;
      private DateTime AV79FechaCierreSolicitud ;
      private DateTime GXt_date3 ;
      private DateTime Z182SolicitudesFechaAlta ;
      private DateTime A182SolicitudesFechaAlta ;
      private DateTime Z184SolicitudesFechaInstalacion ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime Z738MudanzaFechaServicio ;
      private DateTime A738MudanzaFechaServicio ;
      private bool returnInSub ;
      private bool AV64BtnRecalcular ;
      private bool AV66ReloadComProvP ;
      private bool AV86FreezarPrecio ;
      private bool AV15IsAuthorized ;
      private bool AV70Administrar ;
      private bool Z672SolicitudesCalComi ;
      private bool A672SolicitudesCalComi ;
      private bool Z1030TicketEstado ;
      private bool A1030TicketEstado ;
      private bool n182SolicitudesFechaAlta ;
      private bool n669STMonedasId ;
      private bool n600SolicitudesSubTipo ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n866SolicitudesCostoXZComAlmP ;
      private bool n865SolicitudesCostoXZComAlm ;
      private bool n206SolicitudesMail ;
      private bool n688SolicitudesLiqProf ;
      private bool n689SolicitudesLiqProv ;
      private bool n897SolicitudesDescuento ;
      private bool n597SolicitudesUsrAlta ;
      private bool n598SolicitudesUsrActualizacion ;
      private bool n204SolicitudesFechaActualizacion ;
      private bool n441SolicitudesPagado ;
      private bool n527SolicitudServicioComProv ;
      private bool n528SolicitudServicioComProvP ;
      private bool n530SolicitudServicioComALM ;
      private bool n532SolicitudServicioComALMP ;
      private bool n533ProveedorNombreAux ;
      private bool n972SolicitudesDuplicado ;
      private bool n1003SolicitudesCostoPresupuesto ;
      private bool n1006SolicitudesURLOrigen ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n110ZonasID ;
      private bool n735MudanzaId ;
      private bool n919STComerciosID ;
      private bool n422PostulacionesId ;
      private bool n1013CuponId ;
      private bool n1020TicketId ;
      private bool Gx_longc ;
      private bool Z1002SolicitudesPrecioEsFreezado ;
      private bool A1002SolicitudesPrecioEsFreezado ;
      private bool n123RubrosEstado ;
      private bool n176SolicitudesItemsPrecioFinal ;
      private bool n521SolicitudesItemsComiProv ;
      private bool n524SolicitudesItemsComiProvP ;
      private bool n523SolicitudesItemsComiALM ;
      private bool n526SolicitudesItemsComiALMP ;
      private bool GXt_boolean4 ;
      private string Z205SolicitudesComentario ;
      private string A205SolicitudesComentario ;
      private string AV76NombreProfesional ;
      private string AV75Existe ;
      private string Z206SolicitudesMail ;
      private string A206SolicitudesMail ;
      private string Z173SolicitudesDireccion ;
      private string A173SolicitudesDireccion ;
      private string Z1006SolicitudesURLOrigen ;
      private string A1006SolicitudesURLOrigen ;
      private string Z740MudanzaDireccionOrigen ;
      private string A740MudanzaDireccionOrigen ;
      private string Z741MudanzaDireccionDestino ;
      private string A741MudanzaDireccionDestino ;
      private string Z40000RubrosImagen_GXI ;
      private string A40000RubrosImagen_GXI ;
      private string Z40001InventarioImagen_GXI ;
      private string A40001InventarioImagen_GXI ;
      private string Z991ArchivoTipo ;
      private string A991ArchivoTipo ;
      private string Z168RubrosImagen ;
      private string A168RubrosImagen ;
      private string Z189InventarioImagen ;
      private string A189InventarioImagen ;
      private IGxSession AV18WebSession ;
      private GXWindow AV78Window ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSolicitudes bcSolicitudes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV14WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV17TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV26TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] BC000O21_A997CancelacionTipificacionDescrip ;
      private string[] BC000O25_A671STMonedasISO ;
      private string[] BC000O24_A132EstadosSolNombre ;
      private string[] BC000O18_A282ProveedorNombre ;
      private string[] BC000O18_A440ProveedorPagoDefault ;
      private long[] BC000O27_A127SolicitudesID ;
      private string[] BC000O27_A438SolicitudServicioOrigenPago ;
      private bool[] BC000O27_n438SolicitudServicioOrigenPago ;
      private decimal[] BC000O27_A866SolicitudesCostoXZComAlmP ;
      private bool[] BC000O27_n866SolicitudesCostoXZComAlmP ;
      private decimal[] BC000O27_A865SolicitudesCostoXZComAlm ;
      private bool[] BC000O27_n865SolicitudesCostoXZComAlm ;
      private DateTime[] BC000O27_A182SolicitudesFechaAlta ;
      private bool[] BC000O27_n182SolicitudesFechaAlta ;
      private string[] BC000O27_A171SolicitudesNombre ;
      private string[] BC000O27_A172SolicitudesTelefono ;
      private string[] BC000O27_A206SolicitudesMail ;
      private bool[] BC000O27_n206SolicitudesMail ;
      private string[] BC000O27_A173SolicitudesDireccion ;
      private short[] BC000O27_A194SolicitudesAutoEnumerar ;
      private string[] BC000O27_A671STMonedasISO ;
      private long[] BC000O27_A688SolicitudesLiqProf ;
      private bool[] BC000O27_n688SolicitudesLiqProf ;
      private long[] BC000O27_A689SolicitudesLiqProv ;
      private bool[] BC000O27_n689SolicitudesLiqProv ;
      private decimal[] BC000O27_A212SolicitudesCotizacion ;
      private string[] BC000O27_A210SolicitudServicioSolCoti ;
      private decimal[] BC000O27_A897SolicitudesDescuento ;
      private bool[] BC000O27_n897SolicitudesDescuento ;
      private short[] BC000O27_A1014CuponPercent ;
      private decimal[] BC000O27_A1016SolicitudesDescuentoCupon ;
      private decimal[] BC000O27_A796SolicitudesComisionMetodoPago ;
      private string[] BC000O27_A132EstadosSolNombre ;
      private string[] BC000O27_A201SolicitudesOtros1 ;
      private string[] BC000O27_A202SolicitudesOtros2 ;
      private string[] BC000O27_A203SolicitudesOtros3 ;
      private long[] BC000O27_A597SolicitudesUsrAlta ;
      private bool[] BC000O27_n597SolicitudesUsrAlta ;
      private long[] BC000O27_A598SolicitudesUsrActualizacion ;
      private bool[] BC000O27_n598SolicitudesUsrActualizacion ;
      private DateTime[] BC000O27_A204SolicitudesFechaActualizacion ;
      private bool[] BC000O27_n204SolicitudesFechaActualizacion ;
      private DateTime[] BC000O27_A184SolicitudesFechaInstalacion ;
      private string[] BC000O27_A183SolicitudesHoraInstalacion ;
      private string[] BC000O27_A205SolicitudesComentario ;
      private string[] BC000O27_A129MetodoPagosNombre ;
      private string[] BC000O27_A261SolicitudesNota ;
      private string[] BC000O27_A262SolicitudesNotificacion ;
      private string[] BC000O27_A282ProveedorNombre ;
      private string[] BC000O27_A440ProveedorPagoDefault ;
      private string[] BC000O27_A923STComerciosNombre ;
      private string[] BC000O27_A924STComerciosEstado ;
      private string[] BC000O27_A441SolicitudesPagado ;
      private bool[] BC000O27_n441SolicitudesPagado ;
      private decimal[] BC000O27_A527SolicitudServicioComProv ;
      private bool[] BC000O27_n527SolicitudServicioComProv ;
      private decimal[] BC000O27_A528SolicitudServicioComProvP ;
      private bool[] BC000O27_n528SolicitudServicioComProvP ;
      private decimal[] BC000O27_A530SolicitudServicioComALM ;
      private bool[] BC000O27_n530SolicitudServicioComALM ;
      private decimal[] BC000O27_A532SolicitudServicioComALMP ;
      private bool[] BC000O27_n532SolicitudServicioComALMP ;
      private bool[] BC000O27_A672SolicitudesCalComi ;
      private string[] BC000O27_A533ProveedorNombreAux ;
      private bool[] BC000O27_n533ProveedorNombreAux ;
      private string[] BC000O27_A600SolicitudesSubTipo ;
      private bool[] BC000O27_n600SolicitudesSubTipo ;
      private decimal[] BC000O27_A864SolicitudesCostoXZona ;
      private DateTime[] BC000O27_A738MudanzaFechaServicio ;
      private string[] BC000O27_A740MudanzaDireccionOrigen ;
      private string[] BC000O27_A741MudanzaDireccionDestino ;
      private long[] BC000O27_A972SolicitudesDuplicado ;
      private bool[] BC000O27_n972SolicitudesDuplicado ;
      private short[] BC000O27_A992SolicitudesSerialArchivo ;
      private string[] BC000O27_A997CancelacionTipificacionDescrip ;
      private decimal[] BC000O27_A1003SolicitudesCostoPresupuesto ;
      private bool[] BC000O27_n1003SolicitudesCostoPresupuesto ;
      private string[] BC000O27_A1006SolicitudesURLOrigen ;
      private bool[] BC000O27_n1006SolicitudesURLOrigen ;
      private string[] BC000O27_A1022TicketMotivoDescripcion ;
      private string[] BC000O27_A1024TicketComentario ;
      private string[] BC000O27_A1026TicketAdjunto ;
      private bool[] BC000O27_A1030TicketEstado ;
      private long[] BC000O27_A1023TicketSolicitudId ;
      private long[] BC000O27_A112DepartamentoId ;
      private bool[] BC000O27_n112DepartamentoId ;
      private long[] BC000O27_A114DepartamentoMunicipioId ;
      private bool[] BC000O27_n114DepartamentoMunicipioId ;
      private long[] BC000O27_A110ZonasID ;
      private bool[] BC000O27_n110ZonasID ;
      private long[] BC000O27_A128MetodoPagosID ;
      private long[] BC000O27_A735MudanzaId ;
      private bool[] BC000O27_n735MudanzaId ;
      private long[] BC000O27_A133ProveedorID ;
      private long[] BC000O27_A919STComerciosID ;
      private bool[] BC000O27_n919STComerciosID ;
      private long[] BC000O27_A422PostulacionesId ;
      private bool[] BC000O27_n422PostulacionesId ;
      private long[] BC000O27_A996CancelacionTipificacionId ;
      private long[] BC000O27_A1013CuponId ;
      private bool[] BC000O27_n1013CuponId ;
      private long[] BC000O27_A1020TicketId ;
      private bool[] BC000O27_n1020TicketId ;
      private string[] BC000O27_A130EstadosSolTipo ;
      private int[] BC000O27_A131EstadosSolId ;
      private short[] BC000O27_A669STMonedasId ;
      private bool[] BC000O27_n669STMonedasId ;
      private string[] BC000O27_A116PaisID ;
      private long[] BC000O27_A1021TicketMotivoId ;
      private string[] BC000O16_A129MetodoPagosNombre ;
      private string[] BC000O19_A923STComerciosNombre ;
      private string[] BC000O19_A924STComerciosEstado ;
      private DateTime[] BC000O17_A738MudanzaFechaServicio ;
      private string[] BC000O17_A740MudanzaDireccionOrigen ;
      private string[] BC000O17_A741MudanzaDireccionDestino ;
      private long[] BC000O20_A422PostulacionesId ;
      private bool[] BC000O20_n422PostulacionesId ;
      private string[] BC000O23_A1024TicketComentario ;
      private string[] BC000O23_A1026TicketAdjunto ;
      private bool[] BC000O23_A1030TicketEstado ;
      private long[] BC000O23_A1023TicketSolicitudId ;
      private long[] BC000O23_A1021TicketMotivoId ;
      private string[] BC000O26_A1022TicketMotivoDescripcion ;
      private string[] BC000O13_A116PaisID ;
      private long[] BC000O14_A112DepartamentoId ;
      private bool[] BC000O14_n112DepartamentoId ;
      private long[] BC000O15_A110ZonasID ;
      private bool[] BC000O15_n110ZonasID ;
      private short[] BC000O22_A1014CuponPercent ;
      private long[] BC000O28_A127SolicitudesID ;
      private long[] BC000O11_A127SolicitudesID ;
      private string[] BC000O11_A438SolicitudServicioOrigenPago ;
      private bool[] BC000O11_n438SolicitudServicioOrigenPago ;
      private decimal[] BC000O11_A866SolicitudesCostoXZComAlmP ;
      private bool[] BC000O11_n866SolicitudesCostoXZComAlmP ;
      private decimal[] BC000O11_A865SolicitudesCostoXZComAlm ;
      private bool[] BC000O11_n865SolicitudesCostoXZComAlm ;
      private DateTime[] BC000O11_A182SolicitudesFechaAlta ;
      private bool[] BC000O11_n182SolicitudesFechaAlta ;
      private string[] BC000O11_A171SolicitudesNombre ;
      private string[] BC000O11_A172SolicitudesTelefono ;
      private string[] BC000O11_A206SolicitudesMail ;
      private bool[] BC000O11_n206SolicitudesMail ;
      private string[] BC000O11_A173SolicitudesDireccion ;
      private short[] BC000O11_A194SolicitudesAutoEnumerar ;
      private long[] BC000O11_A688SolicitudesLiqProf ;
      private bool[] BC000O11_n688SolicitudesLiqProf ;
      private long[] BC000O11_A689SolicitudesLiqProv ;
      private bool[] BC000O11_n689SolicitudesLiqProv ;
      private decimal[] BC000O11_A212SolicitudesCotizacion ;
      private string[] BC000O11_A210SolicitudServicioSolCoti ;
      private decimal[] BC000O11_A897SolicitudesDescuento ;
      private bool[] BC000O11_n897SolicitudesDescuento ;
      private decimal[] BC000O11_A1016SolicitudesDescuentoCupon ;
      private decimal[] BC000O11_A796SolicitudesComisionMetodoPago ;
      private string[] BC000O11_A201SolicitudesOtros1 ;
      private string[] BC000O11_A202SolicitudesOtros2 ;
      private string[] BC000O11_A203SolicitudesOtros3 ;
      private long[] BC000O11_A597SolicitudesUsrAlta ;
      private bool[] BC000O11_n597SolicitudesUsrAlta ;
      private long[] BC000O11_A598SolicitudesUsrActualizacion ;
      private bool[] BC000O11_n598SolicitudesUsrActualizacion ;
      private DateTime[] BC000O11_A204SolicitudesFechaActualizacion ;
      private bool[] BC000O11_n204SolicitudesFechaActualizacion ;
      private DateTime[] BC000O11_A184SolicitudesFechaInstalacion ;
      private string[] BC000O11_A183SolicitudesHoraInstalacion ;
      private string[] BC000O11_A205SolicitudesComentario ;
      private string[] BC000O11_A261SolicitudesNota ;
      private string[] BC000O11_A262SolicitudesNotificacion ;
      private string[] BC000O11_A441SolicitudesPagado ;
      private bool[] BC000O11_n441SolicitudesPagado ;
      private decimal[] BC000O11_A527SolicitudServicioComProv ;
      private bool[] BC000O11_n527SolicitudServicioComProv ;
      private decimal[] BC000O11_A528SolicitudServicioComProvP ;
      private bool[] BC000O11_n528SolicitudServicioComProvP ;
      private decimal[] BC000O11_A530SolicitudServicioComALM ;
      private bool[] BC000O11_n530SolicitudServicioComALM ;
      private decimal[] BC000O11_A532SolicitudServicioComALMP ;
      private bool[] BC000O11_n532SolicitudServicioComALMP ;
      private bool[] BC000O11_A672SolicitudesCalComi ;
      private string[] BC000O11_A533ProveedorNombreAux ;
      private bool[] BC000O11_n533ProveedorNombreAux ;
      private string[] BC000O11_A600SolicitudesSubTipo ;
      private bool[] BC000O11_n600SolicitudesSubTipo ;
      private decimal[] BC000O11_A864SolicitudesCostoXZona ;
      private long[] BC000O11_A972SolicitudesDuplicado ;
      private bool[] BC000O11_n972SolicitudesDuplicado ;
      private short[] BC000O11_A992SolicitudesSerialArchivo ;
      private decimal[] BC000O11_A1003SolicitudesCostoPresupuesto ;
      private bool[] BC000O11_n1003SolicitudesCostoPresupuesto ;
      private string[] BC000O11_A1006SolicitudesURLOrigen ;
      private bool[] BC000O11_n1006SolicitudesURLOrigen ;
      private long[] BC000O11_A112DepartamentoId ;
      private bool[] BC000O11_n112DepartamentoId ;
      private long[] BC000O11_A114DepartamentoMunicipioId ;
      private bool[] BC000O11_n114DepartamentoMunicipioId ;
      private long[] BC000O11_A110ZonasID ;
      private bool[] BC000O11_n110ZonasID ;
      private long[] BC000O11_A128MetodoPagosID ;
      private long[] BC000O11_A735MudanzaId ;
      private bool[] BC000O11_n735MudanzaId ;
      private long[] BC000O11_A133ProveedorID ;
      private long[] BC000O11_A919STComerciosID ;
      private bool[] BC000O11_n919STComerciosID ;
      private long[] BC000O11_A422PostulacionesId ;
      private bool[] BC000O11_n422PostulacionesId ;
      private long[] BC000O11_A996CancelacionTipificacionId ;
      private long[] BC000O11_A1013CuponId ;
      private bool[] BC000O11_n1013CuponId ;
      private long[] BC000O11_A1020TicketId ;
      private bool[] BC000O11_n1020TicketId ;
      private string[] BC000O11_A130EstadosSolTipo ;
      private int[] BC000O11_A131EstadosSolId ;
      private short[] BC000O11_A669STMonedasId ;
      private bool[] BC000O11_n669STMonedasId ;
      private long[] BC000O10_A127SolicitudesID ;
      private string[] BC000O10_A438SolicitudServicioOrigenPago ;
      private bool[] BC000O10_n438SolicitudServicioOrigenPago ;
      private decimal[] BC000O10_A866SolicitudesCostoXZComAlmP ;
      private bool[] BC000O10_n866SolicitudesCostoXZComAlmP ;
      private decimal[] BC000O10_A865SolicitudesCostoXZComAlm ;
      private bool[] BC000O10_n865SolicitudesCostoXZComAlm ;
      private DateTime[] BC000O10_A182SolicitudesFechaAlta ;
      private bool[] BC000O10_n182SolicitudesFechaAlta ;
      private string[] BC000O10_A171SolicitudesNombre ;
      private string[] BC000O10_A172SolicitudesTelefono ;
      private string[] BC000O10_A206SolicitudesMail ;
      private bool[] BC000O10_n206SolicitudesMail ;
      private string[] BC000O10_A173SolicitudesDireccion ;
      private short[] BC000O10_A194SolicitudesAutoEnumerar ;
      private long[] BC000O10_A688SolicitudesLiqProf ;
      private bool[] BC000O10_n688SolicitudesLiqProf ;
      private long[] BC000O10_A689SolicitudesLiqProv ;
      private bool[] BC000O10_n689SolicitudesLiqProv ;
      private decimal[] BC000O10_A212SolicitudesCotizacion ;
      private string[] BC000O10_A210SolicitudServicioSolCoti ;
      private decimal[] BC000O10_A897SolicitudesDescuento ;
      private bool[] BC000O10_n897SolicitudesDescuento ;
      private decimal[] BC000O10_A1016SolicitudesDescuentoCupon ;
      private decimal[] BC000O10_A796SolicitudesComisionMetodoPago ;
      private string[] BC000O10_A201SolicitudesOtros1 ;
      private string[] BC000O10_A202SolicitudesOtros2 ;
      private string[] BC000O10_A203SolicitudesOtros3 ;
      private long[] BC000O10_A597SolicitudesUsrAlta ;
      private bool[] BC000O10_n597SolicitudesUsrAlta ;
      private long[] BC000O10_A598SolicitudesUsrActualizacion ;
      private bool[] BC000O10_n598SolicitudesUsrActualizacion ;
      private DateTime[] BC000O10_A204SolicitudesFechaActualizacion ;
      private bool[] BC000O10_n204SolicitudesFechaActualizacion ;
      private DateTime[] BC000O10_A184SolicitudesFechaInstalacion ;
      private string[] BC000O10_A183SolicitudesHoraInstalacion ;
      private string[] BC000O10_A205SolicitudesComentario ;
      private string[] BC000O10_A261SolicitudesNota ;
      private string[] BC000O10_A262SolicitudesNotificacion ;
      private string[] BC000O10_A441SolicitudesPagado ;
      private bool[] BC000O10_n441SolicitudesPagado ;
      private decimal[] BC000O10_A527SolicitudServicioComProv ;
      private bool[] BC000O10_n527SolicitudServicioComProv ;
      private decimal[] BC000O10_A528SolicitudServicioComProvP ;
      private bool[] BC000O10_n528SolicitudServicioComProvP ;
      private decimal[] BC000O10_A530SolicitudServicioComALM ;
      private bool[] BC000O10_n530SolicitudServicioComALM ;
      private decimal[] BC000O10_A532SolicitudServicioComALMP ;
      private bool[] BC000O10_n532SolicitudServicioComALMP ;
      private bool[] BC000O10_A672SolicitudesCalComi ;
      private string[] BC000O10_A533ProveedorNombreAux ;
      private bool[] BC000O10_n533ProveedorNombreAux ;
      private string[] BC000O10_A600SolicitudesSubTipo ;
      private bool[] BC000O10_n600SolicitudesSubTipo ;
      private decimal[] BC000O10_A864SolicitudesCostoXZona ;
      private long[] BC000O10_A972SolicitudesDuplicado ;
      private bool[] BC000O10_n972SolicitudesDuplicado ;
      private short[] BC000O10_A992SolicitudesSerialArchivo ;
      private decimal[] BC000O10_A1003SolicitudesCostoPresupuesto ;
      private bool[] BC000O10_n1003SolicitudesCostoPresupuesto ;
      private string[] BC000O10_A1006SolicitudesURLOrigen ;
      private bool[] BC000O10_n1006SolicitudesURLOrigen ;
      private long[] BC000O10_A112DepartamentoId ;
      private bool[] BC000O10_n112DepartamentoId ;
      private long[] BC000O10_A114DepartamentoMunicipioId ;
      private bool[] BC000O10_n114DepartamentoMunicipioId ;
      private long[] BC000O10_A110ZonasID ;
      private bool[] BC000O10_n110ZonasID ;
      private long[] BC000O10_A128MetodoPagosID ;
      private long[] BC000O10_A735MudanzaId ;
      private bool[] BC000O10_n735MudanzaId ;
      private long[] BC000O10_A133ProveedorID ;
      private long[] BC000O10_A919STComerciosID ;
      private bool[] BC000O10_n919STComerciosID ;
      private long[] BC000O10_A422PostulacionesId ;
      private bool[] BC000O10_n422PostulacionesId ;
      private long[] BC000O10_A996CancelacionTipificacionId ;
      private long[] BC000O10_A1013CuponId ;
      private bool[] BC000O10_n1013CuponId ;
      private long[] BC000O10_A1020TicketId ;
      private bool[] BC000O10_n1020TicketId ;
      private string[] BC000O10_A130EstadosSolTipo ;
      private int[] BC000O10_A131EstadosSolId ;
      private short[] BC000O10_A669STMonedasId ;
      private bool[] BC000O10_n669STMonedasId ;
      private string[] BC000O29_A116PaisID ;
      private long[] BC000O30_A127SolicitudesID ;
      private string[] BC000O33_A671STMonedasISO ;
      private short[] BC000O34_A1014CuponPercent ;
      private string[] BC000O35_A132EstadosSolNombre ;
      private string[] BC000O36_A129MetodoPagosNombre ;
      private string[] BC000O37_A282ProveedorNombre ;
      private string[] BC000O37_A440ProveedorPagoDefault ;
      private string[] BC000O38_A923STComerciosNombre ;
      private string[] BC000O38_A924STComerciosEstado ;
      private DateTime[] BC000O39_A738MudanzaFechaServicio ;
      private string[] BC000O39_A740MudanzaDireccionOrigen ;
      private string[] BC000O39_A741MudanzaDireccionDestino ;
      private string[] BC000O40_A997CancelacionTipificacionDescrip ;
      private string[] BC000O41_A1024TicketComentario ;
      private string[] BC000O41_A1026TicketAdjunto ;
      private bool[] BC000O41_A1030TicketEstado ;
      private long[] BC000O41_A1023TicketSolicitudId ;
      private long[] BC000O41_A1021TicketMotivoId ;
      private string[] BC000O42_A1022TicketMotivoDescripcion ;
      private long[] BC000O43_A127SolicitudesID ;
      private long[] BC000O43_A140RelacionesId ;
      private long[] BC000O46_A127SolicitudesID ;
      private string[] BC000O46_A438SolicitudServicioOrigenPago ;
      private bool[] BC000O46_n438SolicitudServicioOrigenPago ;
      private decimal[] BC000O46_A866SolicitudesCostoXZComAlmP ;
      private bool[] BC000O46_n866SolicitudesCostoXZComAlmP ;
      private decimal[] BC000O46_A865SolicitudesCostoXZComAlm ;
      private bool[] BC000O46_n865SolicitudesCostoXZComAlm ;
      private DateTime[] BC000O46_A182SolicitudesFechaAlta ;
      private bool[] BC000O46_n182SolicitudesFechaAlta ;
      private string[] BC000O46_A171SolicitudesNombre ;
      private string[] BC000O46_A172SolicitudesTelefono ;
      private string[] BC000O46_A206SolicitudesMail ;
      private bool[] BC000O46_n206SolicitudesMail ;
      private string[] BC000O46_A173SolicitudesDireccion ;
      private short[] BC000O46_A194SolicitudesAutoEnumerar ;
      private string[] BC000O46_A671STMonedasISO ;
      private long[] BC000O46_A688SolicitudesLiqProf ;
      private bool[] BC000O46_n688SolicitudesLiqProf ;
      private long[] BC000O46_A689SolicitudesLiqProv ;
      private bool[] BC000O46_n689SolicitudesLiqProv ;
      private decimal[] BC000O46_A212SolicitudesCotizacion ;
      private string[] BC000O46_A210SolicitudServicioSolCoti ;
      private decimal[] BC000O46_A897SolicitudesDescuento ;
      private bool[] BC000O46_n897SolicitudesDescuento ;
      private short[] BC000O46_A1014CuponPercent ;
      private decimal[] BC000O46_A1016SolicitudesDescuentoCupon ;
      private decimal[] BC000O46_A796SolicitudesComisionMetodoPago ;
      private string[] BC000O46_A132EstadosSolNombre ;
      private string[] BC000O46_A201SolicitudesOtros1 ;
      private string[] BC000O46_A202SolicitudesOtros2 ;
      private string[] BC000O46_A203SolicitudesOtros3 ;
      private long[] BC000O46_A597SolicitudesUsrAlta ;
      private bool[] BC000O46_n597SolicitudesUsrAlta ;
      private long[] BC000O46_A598SolicitudesUsrActualizacion ;
      private bool[] BC000O46_n598SolicitudesUsrActualizacion ;
      private DateTime[] BC000O46_A204SolicitudesFechaActualizacion ;
      private bool[] BC000O46_n204SolicitudesFechaActualizacion ;
      private DateTime[] BC000O46_A184SolicitudesFechaInstalacion ;
      private string[] BC000O46_A183SolicitudesHoraInstalacion ;
      private string[] BC000O46_A205SolicitudesComentario ;
      private string[] BC000O46_A129MetodoPagosNombre ;
      private string[] BC000O46_A261SolicitudesNota ;
      private string[] BC000O46_A262SolicitudesNotificacion ;
      private string[] BC000O46_A282ProveedorNombre ;
      private string[] BC000O46_A440ProveedorPagoDefault ;
      private string[] BC000O46_A923STComerciosNombre ;
      private string[] BC000O46_A924STComerciosEstado ;
      private string[] BC000O46_A441SolicitudesPagado ;
      private bool[] BC000O46_n441SolicitudesPagado ;
      private decimal[] BC000O46_A527SolicitudServicioComProv ;
      private bool[] BC000O46_n527SolicitudServicioComProv ;
      private decimal[] BC000O46_A528SolicitudServicioComProvP ;
      private bool[] BC000O46_n528SolicitudServicioComProvP ;
      private decimal[] BC000O46_A530SolicitudServicioComALM ;
      private bool[] BC000O46_n530SolicitudServicioComALM ;
      private decimal[] BC000O46_A532SolicitudServicioComALMP ;
      private bool[] BC000O46_n532SolicitudServicioComALMP ;
      private bool[] BC000O46_A672SolicitudesCalComi ;
      private string[] BC000O46_A533ProveedorNombreAux ;
      private bool[] BC000O46_n533ProveedorNombreAux ;
      private string[] BC000O46_A600SolicitudesSubTipo ;
      private bool[] BC000O46_n600SolicitudesSubTipo ;
      private decimal[] BC000O46_A864SolicitudesCostoXZona ;
      private DateTime[] BC000O46_A738MudanzaFechaServicio ;
      private string[] BC000O46_A740MudanzaDireccionOrigen ;
      private string[] BC000O46_A741MudanzaDireccionDestino ;
      private long[] BC000O46_A972SolicitudesDuplicado ;
      private bool[] BC000O46_n972SolicitudesDuplicado ;
      private short[] BC000O46_A992SolicitudesSerialArchivo ;
      private string[] BC000O46_A997CancelacionTipificacionDescrip ;
      private decimal[] BC000O46_A1003SolicitudesCostoPresupuesto ;
      private bool[] BC000O46_n1003SolicitudesCostoPresupuesto ;
      private string[] BC000O46_A1006SolicitudesURLOrigen ;
      private bool[] BC000O46_n1006SolicitudesURLOrigen ;
      private string[] BC000O46_A1022TicketMotivoDescripcion ;
      private string[] BC000O46_A1024TicketComentario ;
      private string[] BC000O46_A1026TicketAdjunto ;
      private bool[] BC000O46_A1030TicketEstado ;
      private long[] BC000O46_A1023TicketSolicitudId ;
      private long[] BC000O46_A112DepartamentoId ;
      private bool[] BC000O46_n112DepartamentoId ;
      private long[] BC000O46_A114DepartamentoMunicipioId ;
      private bool[] BC000O46_n114DepartamentoMunicipioId ;
      private long[] BC000O46_A110ZonasID ;
      private bool[] BC000O46_n110ZonasID ;
      private long[] BC000O46_A128MetodoPagosID ;
      private long[] BC000O46_A735MudanzaId ;
      private bool[] BC000O46_n735MudanzaId ;
      private long[] BC000O46_A133ProveedorID ;
      private long[] BC000O46_A919STComerciosID ;
      private bool[] BC000O46_n919STComerciosID ;
      private long[] BC000O46_A422PostulacionesId ;
      private bool[] BC000O46_n422PostulacionesId ;
      private long[] BC000O46_A996CancelacionTipificacionId ;
      private long[] BC000O46_A1013CuponId ;
      private bool[] BC000O46_n1013CuponId ;
      private long[] BC000O46_A1020TicketId ;
      private bool[] BC000O46_n1020TicketId ;
      private string[] BC000O46_A130EstadosSolTipo ;
      private int[] BC000O46_A131EstadosSolId ;
      private short[] BC000O46_A669STMonedasId ;
      private bool[] BC000O46_n669STMonedasId ;
      private string[] BC000O46_A116PaisID ;
      private long[] BC000O46_A1021TicketMotivoId ;
      private long[] BC000O47_A127SolicitudesID ;
      private short[] BC000O47_A134SolicitudesItemsID ;
      private short[] BC000O47_A177SolicitudesItemsCantidad ;
      private decimal[] BC000O47_A180SolicitudItemsComision ;
      private string[] BC000O47_A178SolicitudItemsSR ;
      private string[] BC000O47_A179SolicitudItemsComisionTipo ;
      private string[] BC000O47_A40000RubrosImagen_GXI ;
      private string[] BC000O47_A123RubrosEstado ;
      private bool[] BC000O47_n123RubrosEstado ;
      private string[] BC000O47_A136InventarioNombre ;
      private string[] BC000O47_A40001InventarioImagen_GXI ;
      private decimal[] BC000O47_A181InventarioPrecioFinal ;
      private decimal[] BC000O47_A801InventarioConsumoProductivo ;
      private decimal[] BC000O47_A176SolicitudesItemsPrecioFinal ;
      private bool[] BC000O47_n176SolicitudesItemsPrecioFinal ;
      private string[] BC000O47_A119MonedaISOSimbolo ;
      private decimal[] BC000O47_A521SolicitudesItemsComiProv ;
      private bool[] BC000O47_n521SolicitudesItemsComiProv ;
      private decimal[] BC000O47_A524SolicitudesItemsComiProvP ;
      private bool[] BC000O47_n524SolicitudesItemsComiProvP ;
      private decimal[] BC000O47_A523SolicitudesItemsComiALM ;
      private bool[] BC000O47_n523SolicitudesItemsComiALM ;
      private decimal[] BC000O47_A526SolicitudesItemsComiALMP ;
      private bool[] BC000O47_n526SolicitudesItemsComiALMP ;
      private short[] BC000O47_A121RubrosId ;
      private long[] BC000O47_A137MedidasID ;
      private long[] BC000O47_A135InventarioId ;
      private short[] BC000O47_A118MonedaId ;
      private string[] BC000O47_A107EstadosTipo ;
      private int[] BC000O47_A108EstadosGenericosId ;
      private string[] BC000O47_A168RubrosImagen ;
      private string[] BC000O47_A189InventarioImagen ;
      private string[] BC000O6_A40000RubrosImagen_GXI ;
      private string[] BC000O6_A123RubrosEstado ;
      private bool[] BC000O6_n123RubrosEstado ;
      private string[] BC000O6_A168RubrosImagen ;
      private short[] BC000O7_A118MonedaId ;
      private string[] BC000O9_A119MonedaISOSimbolo ;
      private string[] BC000O8_A136InventarioNombre ;
      private string[] BC000O8_A40001InventarioImagen_GXI ;
      private decimal[] BC000O8_A181InventarioPrecioFinal ;
      private decimal[] BC000O8_A801InventarioConsumoProductivo ;
      private string[] BC000O8_A107EstadosTipo ;
      private int[] BC000O8_A108EstadosGenericosId ;
      private string[] BC000O8_A189InventarioImagen ;
      private long[] BC000O48_A127SolicitudesID ;
      private short[] BC000O48_A134SolicitudesItemsID ;
      private long[] BC000O5_A127SolicitudesID ;
      private short[] BC000O5_A134SolicitudesItemsID ;
      private short[] BC000O5_A177SolicitudesItemsCantidad ;
      private decimal[] BC000O5_A180SolicitudItemsComision ;
      private string[] BC000O5_A178SolicitudItemsSR ;
      private string[] BC000O5_A179SolicitudItemsComisionTipo ;
      private decimal[] BC000O5_A176SolicitudesItemsPrecioFinal ;
      private bool[] BC000O5_n176SolicitudesItemsPrecioFinal ;
      private decimal[] BC000O5_A521SolicitudesItemsComiProv ;
      private bool[] BC000O5_n521SolicitudesItemsComiProv ;
      private decimal[] BC000O5_A524SolicitudesItemsComiProvP ;
      private bool[] BC000O5_n524SolicitudesItemsComiProvP ;
      private decimal[] BC000O5_A523SolicitudesItemsComiALM ;
      private bool[] BC000O5_n523SolicitudesItemsComiALM ;
      private decimal[] BC000O5_A526SolicitudesItemsComiALMP ;
      private bool[] BC000O5_n526SolicitudesItemsComiALMP ;
      private short[] BC000O5_A121RubrosId ;
      private long[] BC000O5_A137MedidasID ;
      private long[] BC000O5_A135InventarioId ;
      private long[] BC000O4_A127SolicitudesID ;
      private short[] BC000O4_A134SolicitudesItemsID ;
      private short[] BC000O4_A177SolicitudesItemsCantidad ;
      private decimal[] BC000O4_A180SolicitudItemsComision ;
      private string[] BC000O4_A178SolicitudItemsSR ;
      private string[] BC000O4_A179SolicitudItemsComisionTipo ;
      private decimal[] BC000O4_A176SolicitudesItemsPrecioFinal ;
      private bool[] BC000O4_n176SolicitudesItemsPrecioFinal ;
      private decimal[] BC000O4_A521SolicitudesItemsComiProv ;
      private bool[] BC000O4_n521SolicitudesItemsComiProv ;
      private decimal[] BC000O4_A524SolicitudesItemsComiProvP ;
      private bool[] BC000O4_n524SolicitudesItemsComiProvP ;
      private decimal[] BC000O4_A523SolicitudesItemsComiALM ;
      private bool[] BC000O4_n523SolicitudesItemsComiALM ;
      private decimal[] BC000O4_A526SolicitudesItemsComiALMP ;
      private bool[] BC000O4_n526SolicitudesItemsComiALMP ;
      private short[] BC000O4_A121RubrosId ;
      private long[] BC000O4_A137MedidasID ;
      private long[] BC000O4_A135InventarioId ;
      private string[] BC000O52_A40000RubrosImagen_GXI ;
      private string[] BC000O52_A123RubrosEstado ;
      private bool[] BC000O52_n123RubrosEstado ;
      private string[] BC000O52_A168RubrosImagen ;
      private short[] BC000O53_A118MonedaId ;
      private string[] BC000O54_A119MonedaISOSimbolo ;
      private string[] BC000O55_A136InventarioNombre ;
      private string[] BC000O55_A40001InventarioImagen_GXI ;
      private decimal[] BC000O55_A181InventarioPrecioFinal ;
      private decimal[] BC000O55_A801InventarioConsumoProductivo ;
      private string[] BC000O55_A107EstadosTipo ;
      private int[] BC000O55_A108EstadosGenericosId ;
      private string[] BC000O55_A189InventarioImagen ;
      private long[] BC000O56_A127SolicitudesID ;
      private short[] BC000O56_A134SolicitudesItemsID ;
      private short[] BC000O56_A177SolicitudesItemsCantidad ;
      private decimal[] BC000O56_A180SolicitudItemsComision ;
      private string[] BC000O56_A178SolicitudItemsSR ;
      private string[] BC000O56_A179SolicitudItemsComisionTipo ;
      private string[] BC000O56_A40000RubrosImagen_GXI ;
      private string[] BC000O56_A123RubrosEstado ;
      private bool[] BC000O56_n123RubrosEstado ;
      private string[] BC000O56_A136InventarioNombre ;
      private string[] BC000O56_A40001InventarioImagen_GXI ;
      private decimal[] BC000O56_A181InventarioPrecioFinal ;
      private decimal[] BC000O56_A801InventarioConsumoProductivo ;
      private decimal[] BC000O56_A176SolicitudesItemsPrecioFinal ;
      private bool[] BC000O56_n176SolicitudesItemsPrecioFinal ;
      private string[] BC000O56_A119MonedaISOSimbolo ;
      private decimal[] BC000O56_A521SolicitudesItemsComiProv ;
      private bool[] BC000O56_n521SolicitudesItemsComiProv ;
      private decimal[] BC000O56_A524SolicitudesItemsComiProvP ;
      private bool[] BC000O56_n524SolicitudesItemsComiProvP ;
      private decimal[] BC000O56_A523SolicitudesItemsComiALM ;
      private bool[] BC000O56_n523SolicitudesItemsComiALM ;
      private decimal[] BC000O56_A526SolicitudesItemsComiALMP ;
      private bool[] BC000O56_n526SolicitudesItemsComiALMP ;
      private short[] BC000O56_A121RubrosId ;
      private long[] BC000O56_A137MedidasID ;
      private long[] BC000O56_A135InventarioId ;
      private short[] BC000O56_A118MonedaId ;
      private string[] BC000O56_A107EstadosTipo ;
      private int[] BC000O56_A108EstadosGenericosId ;
      private string[] BC000O56_A168RubrosImagen ;
      private string[] BC000O56_A189InventarioImagen ;
      private long[] BC000O57_A127SolicitudesID ;
      private long[] BC000O57_A988ArchivoId ;
      private string[] BC000O57_A989ArchivoDireccion ;
      private string[] BC000O57_A990ArchivoDescripcion ;
      private string[] BC000O57_A991ArchivoTipo ;
      private long[] BC000O58_A127SolicitudesID ;
      private long[] BC000O58_A988ArchivoId ;
      private long[] BC000O3_A127SolicitudesID ;
      private long[] BC000O3_A988ArchivoId ;
      private string[] BC000O3_A989ArchivoDireccion ;
      private string[] BC000O3_A990ArchivoDescripcion ;
      private string[] BC000O3_A991ArchivoTipo ;
      private long[] BC000O2_A127SolicitudesID ;
      private long[] BC000O2_A988ArchivoId ;
      private string[] BC000O2_A989ArchivoDireccion ;
      private string[] BC000O2_A990ArchivoDescripcion ;
      private string[] BC000O2_A991ArchivoTipo ;
      private long[] BC000O62_A127SolicitudesID ;
      private long[] BC000O62_A988ArchivoId ;
      private string[] BC000O62_A989ArchivoDireccion ;
      private string[] BC000O62_A990ArchivoDescripcion ;
      private string[] BC000O62_A991ArchivoTipo ;
      private long[] BC000O63_A127SolicitudesID ;
      private short[] BC000O63_A134SolicitudesItemsID ;
      private decimal[] BC000O63_A180SolicitudItemsComision ;
      private string[] BC000O63_A179SolicitudItemsComisionTipo ;
      private string[] BC000O63_A178SolicitudItemsSR ;
      private short[] BC000O63_A177SolicitudesItemsCantidad ;
      private decimal[] BC000O63_A176SolicitudesItemsPrecioFinal ;
      private bool[] BC000O63_n176SolicitudesItemsPrecioFinal ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private string[] BC000O12_A116PaisID ;
   }

   public class solicitudes_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class solicitudes_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new UpdateCursor(def[42])
       ,new UpdateCursor(def[43])
       ,new ForEachCursor(def[44])
       ,new ForEachCursor(def[45])
       ,new ForEachCursor(def[46])
       ,new UpdateCursor(def[47])
       ,new UpdateCursor(def[48])
       ,new UpdateCursor(def[49])
       ,new ForEachCursor(def[50])
       ,new ForEachCursor(def[51])
       ,new ForEachCursor(def[52])
       ,new ForEachCursor(def[53])
       ,new ForEachCursor(def[54])
       ,new ForEachCursor(def[55])
       ,new ForEachCursor(def[56])
       ,new UpdateCursor(def[57])
       ,new UpdateCursor(def[58])
       ,new UpdateCursor(def[59])
       ,new ForEachCursor(def[60])
       ,new ForEachCursor(def[61])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000O2;
        prmBC000O2 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@ArchivoId",GXType.Decimal,18,0)
        };
        Object[] prmBC000O3;
        prmBC000O3 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@ArchivoId",GXType.Decimal,18,0)
        };
        Object[] prmBC000O4;
        prmBC000O4 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@SolicitudesItemsID",GXType.Int16,4,0)
        };
        Object[] prmBC000O5;
        prmBC000O5 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@SolicitudesItemsID",GXType.Int16,4,0)
        };
        Object[] prmBC000O6;
        prmBC000O6 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000O7;
        prmBC000O7 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmBC000O8;
        prmBC000O8 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmBC000O9;
        prmBC000O9 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0)
        };
        Object[] prmBC000O10;
        prmBC000O10 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmBC000O11;
        prmBC000O11 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmBC000O12;
        prmBC000O12 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000O13;
        prmBC000O13 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000O14;
        prmBC000O14 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000O15;
        prmBC000O15 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000O16;
        prmBC000O16 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmBC000O17;
        prmBC000O17 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000O18;
        prmBC000O18 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmBC000O19;
        prmBC000O19 = new Object[] {
        new ParDef("@STComerciosID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000O20;
        prmBC000O20 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000O21;
        prmBC000O21 = new Object[] {
        new ParDef("@CancelacionTipificacionId",GXType.Decimal,18,0)
        };
        Object[] prmBC000O22;
        prmBC000O22 = new Object[] {
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000O23;
        prmBC000O23 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000O24;
        prmBC000O24 = new Object[] {
        new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0)
        };
        Object[] prmBC000O25;
        prmBC000O25 = new Object[] {
        new ParDef("@STMonedasId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmBC000O26;
        prmBC000O26 = new Object[] {
        new ParDef("@TicketMotivoId",GXType.Decimal,18,0)
        };
        Object[] prmBC000O27;
        prmBC000O27 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        string cmdBufferBC000O27;
        cmdBufferBC000O27=" SELECT TM1.[SolicitudesID], TM1.[SolicitudServicioOrigenPago], TM1.[SolicitudesCostoXZComAlmP], TM1.[SolicitudesCostoXZComAlm], TM1.[SolicitudesFechaAlta], TM1.[SolicitudesNombre], TM1.[SolicitudesTelefono], TM1.[SolicitudesMail], TM1.[SolicitudesDireccion], TM1.[SolicitudesAutoEnumerar], T3.[MonedaISOSimbolo] AS STMonedasISO, TM1.[SolicitudesLiqProf], TM1.[SolicitudesLiqProv], TM1.[SolicitudesCotizacion], TM1.[SolicitudServicioSolCoti], TM1.[SolicitudesDescuento], T4.[CuponPercent], TM1.[SolicitudesDescuentoCupon], TM1.[SolicitudesComisionMetodoPago], T5.[EstadosGenericosNombre] AS EstadosSolNombre, TM1.[SolicitudesOtros1], TM1.[SolicitudesOtros2], TM1.[SolicitudesOtros3], TM1.[SolicitudesUsrAlta], TM1.[SolicitudesUsrActualizacion], TM1.[SolicitudesFechaActualizacion], TM1.[SolicitudesFechaInstalacion], TM1.[SolicitudesHoraInstalacion], TM1.[SolicitudesComentario], T6.[MetodoPagosNombre], TM1.[SolicitudesNota], TM1.[SolicitudesNotificacion], T7.[ProveedorNombre], T7.[ProveedorPagoDefault], T8.[ProveedorNombre] AS STComerciosNombre, T8.[ProveedorEstado] AS STComerciosEstado, TM1.[SolicitudesPagado], TM1.[SolicitudServicioComProv], TM1.[SolicitudServicioComProvP], TM1.[SolicitudServicioComALM], TM1.[SolicitudServicioComALMP], TM1.[SolicitudesCalComi], TM1.[ProveedorNombreAux], TM1.[SolicitudesSubTipo], TM1.[SolicitudesCostoXZona], T9.[MudanzaFechaServicio], T9.[MudanzaDireccionOrigen], T9.[MudanzaDireccionDestino], TM1.[SolicitudesDuplicado], TM1.[SolicitudesSerialArchivo], T10.[CancelacionTipificacionDescrip], TM1.[SolicitudesCostoPresupuesto], TM1.[SolicitudesURLOrigen], T12.[TicketMotivoDescripcion], T11.[TicketComentario], T11.[TicketAdjunto], T11.[TicketEstado], T11.[TicketSolicitudId], TM1.[DepartamentoId], TM1.[DepartamentoMunicipioId], TM1.[ZonasID], TM1.[MetodoPagosID], "
        + " TM1.[MudanzaId], TM1.[ProveedorID], TM1.[STComerciosID] AS STComerciosID, TM1.[PostulacionesId], TM1.[CancelacionTipificacionId], TM1.[CuponId], TM1.[TicketId], TM1.[EstadosSolTipo] AS EstadosSolTipo, TM1.[EstadosSolId] AS EstadosSolId, TM1.[STMonedasId] AS STMonedasId, T2.[PaisID], T11.[TicketMotivoId] FROM ((((((((((([Solicitudes] TM1 LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = TM1.[DepartamentoId]) LEFT JOIN [Moneda] T3 ON T3.[MonedaId] = TM1.[STMonedasId]) LEFT JOIN [Cupon] T4 ON T4.[CuponId] = TM1.[CuponId]) INNER JOIN [EstadosGenericos] T5 ON T5.[EstadosTipo] = TM1.[EstadosSolTipo] AND T5.[EstadosGenericosId] = TM1.[EstadosSolId]) INNER JOIN [MetodoPagos] T6 ON T6.[MetodoPagosID] = TM1.[MetodoPagosID]) INNER JOIN [Proveedor] T7 ON T7.[ProveedorID] = TM1.[ProveedorID]) LEFT JOIN [Proveedor] T8 ON T8.[ProveedorID] = TM1.[STComerciosID]) LEFT JOIN [Mudanza] T9 ON T9.[MudanzaId] = TM1.[MudanzaId]) INNER JOIN [CancelacionTipificacion] T10 ON T10.[CancelacionTipificacionId] = TM1.[CancelacionTipificacionId]) LEFT JOIN [Ticket] T11 ON T11.[TicketId] = TM1.[TicketId]) LEFT JOIN [TicketMotivo] T12 ON T12.[TicketMotivoId] = T11.[TicketMotivoId]) WHERE TM1.[SolicitudesID] = @SolicitudesID ORDER BY TM1.[SolicitudesID]  OPTION (FAST 100)" ;
        Object[] prmBC000O28;
        prmBC000O28 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmBC000O29;
        prmBC000O29 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000O30;
        prmBC000O30 = new Object[] {
        new ParDef("@SolicitudServicioOrigenPago",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudesCostoXZComAlmP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudesCostoXZComAlm",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesFechaAlta",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@SolicitudesNombre",GXType.NChar,100,0) ,
        new ParDef("@SolicitudesTelefono",GXType.NChar,20,0) ,
        new ParDef("@SolicitudesMail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@SolicitudesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@SolicitudesAutoEnumerar",GXType.Int16,4,0) ,
        new ParDef("@SolicitudesLiqProf",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@SolicitudesLiqProv",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@SolicitudesCotizacion",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudServicioSolCoti",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesDescuento",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesDescuentoCupon",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudesComisionMetodoPago",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudesOtros1",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesOtros2",GXType.NChar,1000,0) ,
        new ParDef("@SolicitudesOtros3",GXType.NChar,500,0) ,
        new ParDef("@SolicitudesUsrAlta",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SolicitudesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SolicitudesFechaActualizacion",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@SolicitudesFechaInstalacion",GXType.Date,8,0) ,
        new ParDef("@SolicitudesHoraInstalacion",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@SolicitudesNota",GXType.NChar,500,0) ,
        new ParDef("@SolicitudesNotificacion",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesPagado",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudServicioComProv",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComProvP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComALM",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComALMP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudesCalComi",GXType.Boolean,4,0) ,
        new ParDef("@ProveedorNombreAux",GXType.NChar,80,0){Nullable=true} ,
        new ParDef("@SolicitudesSubTipo",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudesCostoXZona",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudesDuplicado",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@SolicitudesSerialArchivo",GXType.Int16,4,0) ,
        new ParDef("@SolicitudesCostoPresupuesto",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesURLOrigen",GXType.NVarChar,120,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0) ,
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@STComerciosID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CancelacionTipificacionId",GXType.Decimal,18,0) ,
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0) ,
        new ParDef("@STMonedasId",GXType.Int16,4,0){Nullable=true}
        };
        string cmdBufferBC000O30;
        cmdBufferBC000O30=" INSERT INTO [Solicitudes]([SolicitudServicioOrigenPago], [SolicitudesCostoXZComAlmP], [SolicitudesCostoXZComAlm], [SolicitudesFechaAlta], [SolicitudesNombre], [SolicitudesTelefono], [SolicitudesMail], [SolicitudesDireccion], [SolicitudesAutoEnumerar], [SolicitudesLiqProf], [SolicitudesLiqProv], [SolicitudesCotizacion], [SolicitudServicioSolCoti], [SolicitudesDescuento], [SolicitudesDescuentoCupon], [SolicitudesComisionMetodoPago], [SolicitudesOtros1], [SolicitudesOtros2], [SolicitudesOtros3], [SolicitudesUsrAlta], [SolicitudesUsrActualizacion], [SolicitudesFechaActualizacion], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [SolicitudesComentario], [SolicitudesNota], [SolicitudesNotificacion], [SolicitudesPagado], [SolicitudServicioComProv], [SolicitudServicioComProvP], [SolicitudServicioComALM], [SolicitudServicioComALMP], [SolicitudesCalComi], [ProveedorNombreAux], [SolicitudesSubTipo], [SolicitudesCostoXZona], [SolicitudesDuplicado], [SolicitudesSerialArchivo], [SolicitudesCostoPresupuesto], [SolicitudesURLOrigen], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID], [MetodoPagosID], [MudanzaId], [ProveedorID], [STComerciosID], [PostulacionesId], [CancelacionTipificacionId], [CuponId], [TicketId], [EstadosSolTipo], [EstadosSolId], [STMonedasId]) VALUES(@SolicitudServicioOrigenPago, @SolicitudesCostoXZComAlmP, @SolicitudesCostoXZComAlm, @SolicitudesFechaAlta, @SolicitudesNombre, @SolicitudesTelefono, @SolicitudesMail, @SolicitudesDireccion, @SolicitudesAutoEnumerar, @SolicitudesLiqProf, @SolicitudesLiqProv, @SolicitudesCotizacion, @SolicitudServicioSolCoti, @SolicitudesDescuento, @SolicitudesDescuentoCupon, @SolicitudesComisionMetodoPago, @SolicitudesOtros1, @SolicitudesOtros2, @SolicitudesOtros3, @SolicitudesUsrAlta, @SolicitudesUsrActualizacion, @SolicitudesFechaActualizacion, "
        + " @SolicitudesFechaInstalacion, @SolicitudesHoraInstalacion, @SolicitudesComentario, @SolicitudesNota, @SolicitudesNotificacion, @SolicitudesPagado, @SolicitudServicioComProv, @SolicitudServicioComProvP, @SolicitudServicioComALM, @SolicitudServicioComALMP, @SolicitudesCalComi, @ProveedorNombreAux, @SolicitudesSubTipo, @SolicitudesCostoXZona, @SolicitudesDuplicado, @SolicitudesSerialArchivo, @SolicitudesCostoPresupuesto, @SolicitudesURLOrigen, @DepartamentoId, @DepartamentoMunicipioId, @ZonasID, @MetodoPagosID, @MudanzaId, @ProveedorID, @STComerciosID, @PostulacionesId, @CancelacionTipificacionId, @CuponId, @TicketId, @EstadosSolTipo, @EstadosSolId, @STMonedasId); SELECT SCOPE_IDENTITY()" ;
        Object[] prmBC000O31;
        prmBC000O31 = new Object[] {
        new ParDef("@SolicitudServicioOrigenPago",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudesCostoXZComAlmP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudesCostoXZComAlm",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesFechaAlta",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@SolicitudesNombre",GXType.NChar,100,0) ,
        new ParDef("@SolicitudesTelefono",GXType.NChar,20,0) ,
        new ParDef("@SolicitudesMail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@SolicitudesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@SolicitudesAutoEnumerar",GXType.Int16,4,0) ,
        new ParDef("@SolicitudesLiqProf",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@SolicitudesLiqProv",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@SolicitudesCotizacion",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudServicioSolCoti",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesDescuento",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesDescuentoCupon",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudesComisionMetodoPago",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudesOtros1",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesOtros2",GXType.NChar,1000,0) ,
        new ParDef("@SolicitudesOtros3",GXType.NChar,500,0) ,
        new ParDef("@SolicitudesUsrAlta",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SolicitudesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SolicitudesFechaActualizacion",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@SolicitudesFechaInstalacion",GXType.Date,8,0) ,
        new ParDef("@SolicitudesHoraInstalacion",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@SolicitudesNota",GXType.NChar,500,0) ,
        new ParDef("@SolicitudesNotificacion",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesPagado",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudServicioComProv",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComProvP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComALM",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComALMP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudesCalComi",GXType.Boolean,4,0) ,
        new ParDef("@ProveedorNombreAux",GXType.NChar,80,0){Nullable=true} ,
        new ParDef("@SolicitudesSubTipo",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudesCostoXZona",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudesDuplicado",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@SolicitudesSerialArchivo",GXType.Int16,4,0) ,
        new ParDef("@SolicitudesCostoPresupuesto",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesURLOrigen",GXType.NVarChar,120,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0) ,
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@STComerciosID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CancelacionTipificacionId",GXType.Decimal,18,0) ,
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0) ,
        new ParDef("@STMonedasId",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        string cmdBufferBC000O31;
        cmdBufferBC000O31=" UPDATE [Solicitudes] SET [SolicitudServicioOrigenPago]=@SolicitudServicioOrigenPago, [SolicitudesCostoXZComAlmP]=@SolicitudesCostoXZComAlmP, [SolicitudesCostoXZComAlm]=@SolicitudesCostoXZComAlm, [SolicitudesFechaAlta]=@SolicitudesFechaAlta, [SolicitudesNombre]=@SolicitudesNombre, [SolicitudesTelefono]=@SolicitudesTelefono, [SolicitudesMail]=@SolicitudesMail, [SolicitudesDireccion]=@SolicitudesDireccion, [SolicitudesAutoEnumerar]=@SolicitudesAutoEnumerar, [SolicitudesLiqProf]=@SolicitudesLiqProf, [SolicitudesLiqProv]=@SolicitudesLiqProv, [SolicitudesCotizacion]=@SolicitudesCotizacion, [SolicitudServicioSolCoti]=@SolicitudServicioSolCoti, [SolicitudesDescuento]=@SolicitudesDescuento, [SolicitudesDescuentoCupon]=@SolicitudesDescuentoCupon, [SolicitudesComisionMetodoPago]=@SolicitudesComisionMetodoPago, [SolicitudesOtros1]=@SolicitudesOtros1, [SolicitudesOtros2]=@SolicitudesOtros2, [SolicitudesOtros3]=@SolicitudesOtros3, [SolicitudesUsrAlta]=@SolicitudesUsrAlta, [SolicitudesUsrActualizacion]=@SolicitudesUsrActualizacion, [SolicitudesFechaActualizacion]=@SolicitudesFechaActualizacion, [SolicitudesFechaInstalacion]=@SolicitudesFechaInstalacion, [SolicitudesHoraInstalacion]=@SolicitudesHoraInstalacion, [SolicitudesComentario]=@SolicitudesComentario, [SolicitudesNota]=@SolicitudesNota, [SolicitudesNotificacion]=@SolicitudesNotificacion, [SolicitudesPagado]=@SolicitudesPagado, [SolicitudServicioComProv]=@SolicitudServicioComProv, [SolicitudServicioComProvP]=@SolicitudServicioComProvP, [SolicitudServicioComALM]=@SolicitudServicioComALM, [SolicitudServicioComALMP]=@SolicitudServicioComALMP, [SolicitudesCalComi]=@SolicitudesCalComi, [ProveedorNombreAux]=@ProveedorNombreAux, [SolicitudesSubTipo]=@SolicitudesSubTipo, [SolicitudesCostoXZona]=@SolicitudesCostoXZona, [SolicitudesDuplicado]=@SolicitudesDuplicado, "
        + " [SolicitudesSerialArchivo]=@SolicitudesSerialArchivo, [SolicitudesCostoPresupuesto]=@SolicitudesCostoPresupuesto, [SolicitudesURLOrigen]=@SolicitudesURLOrigen, [DepartamentoId]=@DepartamentoId, [DepartamentoMunicipioId]=@DepartamentoMunicipioId, [ZonasID]=@ZonasID, [MetodoPagosID]=@MetodoPagosID, [MudanzaId]=@MudanzaId, [ProveedorID]=@ProveedorID, [STComerciosID]=@STComerciosID, [PostulacionesId]=@PostulacionesId, [CancelacionTipificacionId]=@CancelacionTipificacionId, [CuponId]=@CuponId, [TicketId]=@TicketId, [EstadosSolTipo]=@EstadosSolTipo, [EstadosSolId]=@EstadosSolId, [STMonedasId]=@STMonedasId  WHERE [SolicitudesID] = @SolicitudesID" ;
        Object[] prmBC000O32;
        prmBC000O32 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmBC000O33;
        prmBC000O33 = new Object[] {
        new ParDef("@STMonedasId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmBC000O34;
        prmBC000O34 = new Object[] {
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000O35;
        prmBC000O35 = new Object[] {
        new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0)
        };
        Object[] prmBC000O36;
        prmBC000O36 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmBC000O37;
        prmBC000O37 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmBC000O38;
        prmBC000O38 = new Object[] {
        new ParDef("@STComerciosID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000O39;
        prmBC000O39 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000O40;
        prmBC000O40 = new Object[] {
        new ParDef("@CancelacionTipificacionId",GXType.Decimal,18,0)
        };
        Object[] prmBC000O41;
        prmBC000O41 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000O42;
        prmBC000O42 = new Object[] {
        new ParDef("@TicketMotivoId",GXType.Decimal,18,0)
        };
        Object[] prmBC000O43;
        prmBC000O43 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmBC000O44;
        prmBC000O44 = new Object[] {
        new ParDef("@SolicitudesSerialArchivo",GXType.Int16,4,0) ,
        new ParDef("@SolicitudesAutoEnumerar",GXType.Int16,4,0) ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmBC000O45;
        prmBC000O45 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000O46;
        prmBC000O46 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        string cmdBufferBC000O46;
        cmdBufferBC000O46=" SELECT TM1.[SolicitudesID], TM1.[SolicitudServicioOrigenPago], TM1.[SolicitudesCostoXZComAlmP], TM1.[SolicitudesCostoXZComAlm], TM1.[SolicitudesFechaAlta], TM1.[SolicitudesNombre], TM1.[SolicitudesTelefono], TM1.[SolicitudesMail], TM1.[SolicitudesDireccion], TM1.[SolicitudesAutoEnumerar], T3.[MonedaISOSimbolo] AS STMonedasISO, TM1.[SolicitudesLiqProf], TM1.[SolicitudesLiqProv], TM1.[SolicitudesCotizacion], TM1.[SolicitudServicioSolCoti], TM1.[SolicitudesDescuento], T4.[CuponPercent], TM1.[SolicitudesDescuentoCupon], TM1.[SolicitudesComisionMetodoPago], T5.[EstadosGenericosNombre] AS EstadosSolNombre, TM1.[SolicitudesOtros1], TM1.[SolicitudesOtros2], TM1.[SolicitudesOtros3], TM1.[SolicitudesUsrAlta], TM1.[SolicitudesUsrActualizacion], TM1.[SolicitudesFechaActualizacion], TM1.[SolicitudesFechaInstalacion], TM1.[SolicitudesHoraInstalacion], TM1.[SolicitudesComentario], T6.[MetodoPagosNombre], TM1.[SolicitudesNota], TM1.[SolicitudesNotificacion], T7.[ProveedorNombre], T7.[ProveedorPagoDefault], T8.[ProveedorNombre] AS STComerciosNombre, T8.[ProveedorEstado] AS STComerciosEstado, TM1.[SolicitudesPagado], TM1.[SolicitudServicioComProv], TM1.[SolicitudServicioComProvP], TM1.[SolicitudServicioComALM], TM1.[SolicitudServicioComALMP], TM1.[SolicitudesCalComi], TM1.[ProveedorNombreAux], TM1.[SolicitudesSubTipo], TM1.[SolicitudesCostoXZona], T9.[MudanzaFechaServicio], T9.[MudanzaDireccionOrigen], T9.[MudanzaDireccionDestino], TM1.[SolicitudesDuplicado], TM1.[SolicitudesSerialArchivo], T10.[CancelacionTipificacionDescrip], TM1.[SolicitudesCostoPresupuesto], TM1.[SolicitudesURLOrigen], T12.[TicketMotivoDescripcion], T11.[TicketComentario], T11.[TicketAdjunto], T11.[TicketEstado], T11.[TicketSolicitudId], TM1.[DepartamentoId], TM1.[DepartamentoMunicipioId], TM1.[ZonasID], TM1.[MetodoPagosID], "
        + " TM1.[MudanzaId], TM1.[ProveedorID], TM1.[STComerciosID] AS STComerciosID, TM1.[PostulacionesId], TM1.[CancelacionTipificacionId], TM1.[CuponId], TM1.[TicketId], TM1.[EstadosSolTipo] AS EstadosSolTipo, TM1.[EstadosSolId] AS EstadosSolId, TM1.[STMonedasId] AS STMonedasId, T2.[PaisID], T11.[TicketMotivoId] FROM ((((((((((([Solicitudes] TM1 LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = TM1.[DepartamentoId]) LEFT JOIN [Moneda] T3 ON T3.[MonedaId] = TM1.[STMonedasId]) LEFT JOIN [Cupon] T4 ON T4.[CuponId] = TM1.[CuponId]) INNER JOIN [EstadosGenericos] T5 ON T5.[EstadosTipo] = TM1.[EstadosSolTipo] AND T5.[EstadosGenericosId] = TM1.[EstadosSolId]) INNER JOIN [MetodoPagos] T6 ON T6.[MetodoPagosID] = TM1.[MetodoPagosID]) INNER JOIN [Proveedor] T7 ON T7.[ProveedorID] = TM1.[ProveedorID]) LEFT JOIN [Proveedor] T8 ON T8.[ProveedorID] = TM1.[STComerciosID]) LEFT JOIN [Mudanza] T9 ON T9.[MudanzaId] = TM1.[MudanzaId]) INNER JOIN [CancelacionTipificacion] T10 ON T10.[CancelacionTipificacionId] = TM1.[CancelacionTipificacionId]) LEFT JOIN [Ticket] T11 ON T11.[TicketId] = TM1.[TicketId]) LEFT JOIN [TicketMotivo] T12 ON T12.[TicketMotivoId] = T11.[TicketMotivoId]) WHERE TM1.[SolicitudesID] = @SolicitudesID ORDER BY TM1.[SolicitudesID]  OPTION (FAST 100)" ;
        Object[] prmBC000O47;
        prmBC000O47 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@SolicitudesItemsID",GXType.Int16,4,0)
        };
        Object[] prmBC000O48;
        prmBC000O48 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@SolicitudesItemsID",GXType.Int16,4,0)
        };
        Object[] prmBC000O49;
        prmBC000O49 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@SolicitudesItemsID",GXType.Int16,4,0) ,
        new ParDef("@SolicitudesItemsCantidad",GXType.Int16,4,0) ,
        new ParDef("@SolicitudItemsComision",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudItemsSR",GXType.NChar,1,0) ,
        new ParDef("@SolicitudItemsComisionTipo",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesItemsPrecioFinal",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesItemsComiProv",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesItemsComiProvP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudesItemsComiALM",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesItemsComiALMP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmBC000O50;
        prmBC000O50 = new Object[] {
        new ParDef("@SolicitudesItemsCantidad",GXType.Int16,4,0) ,
        new ParDef("@SolicitudItemsComision",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudItemsSR",GXType.NChar,1,0) ,
        new ParDef("@SolicitudItemsComisionTipo",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesItemsPrecioFinal",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesItemsComiProv",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesItemsComiProvP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudesItemsComiALM",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesItemsComiALMP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0) ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@SolicitudesItemsID",GXType.Int16,4,0)
        };
        Object[] prmBC000O51;
        prmBC000O51 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@SolicitudesItemsID",GXType.Int16,4,0)
        };
        Object[] prmBC000O52;
        prmBC000O52 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000O53;
        prmBC000O53 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmBC000O54;
        prmBC000O54 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0)
        };
        Object[] prmBC000O55;
        prmBC000O55 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmBC000O56;
        prmBC000O56 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmBC000O57;
        prmBC000O57 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@ArchivoId",GXType.Decimal,18,0)
        };
        Object[] prmBC000O58;
        prmBC000O58 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@ArchivoId",GXType.Decimal,18,0)
        };
        Object[] prmBC000O59;
        prmBC000O59 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@ArchivoId",GXType.Decimal,18,0) ,
        new ParDef("@ArchivoDireccion",GXType.NChar,100,0) ,
        new ParDef("@ArchivoDescripcion",GXType.NChar,250,0) ,
        new ParDef("@ArchivoTipo",GXType.NVarChar,40,0)
        };
        Object[] prmBC000O60;
        prmBC000O60 = new Object[] {
        new ParDef("@ArchivoDireccion",GXType.NChar,100,0) ,
        new ParDef("@ArchivoDescripcion",GXType.NChar,250,0) ,
        new ParDef("@ArchivoTipo",GXType.NVarChar,40,0) ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@ArchivoId",GXType.Decimal,18,0)
        };
        Object[] prmBC000O61;
        prmBC000O61 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@ArchivoId",GXType.Decimal,18,0)
        };
        Object[] prmBC000O62;
        prmBC000O62 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmBC000O63;
        prmBC000O63 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000O2", "SELECT [SolicitudesID], [ArchivoId], [ArchivoDireccion], [ArchivoDescripcion], [ArchivoTipo] FROM [SolicitudesArchivo] WITH (UPDLOCK) WHERE [SolicitudesID] = @SolicitudesID AND [ArchivoId] = @ArchivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O3", "SELECT [SolicitudesID], [ArchivoId], [ArchivoDireccion], [ArchivoDescripcion], [ArchivoTipo] FROM [SolicitudesArchivo] WHERE [SolicitudesID] = @SolicitudesID AND [ArchivoId] = @ArchivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O4", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudesItemsCantidad], [SolicitudItemsComision], [SolicitudItemsSR], [SolicitudItemsComisionTipo], [SolicitudesItemsPrecioFinal], [SolicitudesItemsComiProv], [SolicitudesItemsComiProvP], [SolicitudesItemsComiALM], [SolicitudesItemsComiALMP], [RubrosId], [MedidasID], [InventarioId] FROM [SolicitudesItems] WITH (UPDLOCK) WHERE [SolicitudesID] = @SolicitudesID AND [SolicitudesItemsID] = @SolicitudesItemsID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O5", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudesItemsCantidad], [SolicitudItemsComision], [SolicitudItemsSR], [SolicitudItemsComisionTipo], [SolicitudesItemsPrecioFinal], [SolicitudesItemsComiProv], [SolicitudesItemsComiProvP], [SolicitudesItemsComiALM], [SolicitudesItemsComiALMP], [RubrosId], [MedidasID], [InventarioId] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID AND [SolicitudesItemsID] = @SolicitudesItemsID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O6", "SELECT [RubrosImagen_GXI], [RubrosEstado], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O7", "SELECT [MonedaId] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O8", "SELECT [InventarioNombre], [InventarioImagen_GXI], [InventarioPrecioFinal], [InventarioConsumoProductivo], [EstadosTipo], [EstadosGenericosId], [InventarioImagen] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O9", "SELECT [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O10", "SELECT [SolicitudesID], [SolicitudServicioOrigenPago], [SolicitudesCostoXZComAlmP], [SolicitudesCostoXZComAlm], [SolicitudesFechaAlta], [SolicitudesNombre], [SolicitudesTelefono], [SolicitudesMail], [SolicitudesDireccion], [SolicitudesAutoEnumerar], [SolicitudesLiqProf], [SolicitudesLiqProv], [SolicitudesCotizacion], [SolicitudServicioSolCoti], [SolicitudesDescuento], [SolicitudesDescuentoCupon], [SolicitudesComisionMetodoPago], [SolicitudesOtros1], [SolicitudesOtros2], [SolicitudesOtros3], [SolicitudesUsrAlta], [SolicitudesUsrActualizacion], [SolicitudesFechaActualizacion], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [SolicitudesComentario], [SolicitudesNota], [SolicitudesNotificacion], [SolicitudesPagado], [SolicitudServicioComProv], [SolicitudServicioComProvP], [SolicitudServicioComALM], [SolicitudServicioComALMP], [SolicitudesCalComi], [ProveedorNombreAux], [SolicitudesSubTipo], [SolicitudesCostoXZona], [SolicitudesDuplicado], [SolicitudesSerialArchivo], [SolicitudesCostoPresupuesto], [SolicitudesURLOrigen], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID], [MetodoPagosID], [MudanzaId], [ProveedorID], [STComerciosID] AS STComerciosID, [PostulacionesId], [CancelacionTipificacionId], [CuponId], [TicketId], [EstadosSolTipo] AS EstadosSolTipo, [EstadosSolId] AS EstadosSolId, [STMonedasId] AS STMonedasId FROM [Solicitudes] WITH (UPDLOCK) WHERE [SolicitudesID] = @SolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O11", "SELECT [SolicitudesID], [SolicitudServicioOrigenPago], [SolicitudesCostoXZComAlmP], [SolicitudesCostoXZComAlm], [SolicitudesFechaAlta], [SolicitudesNombre], [SolicitudesTelefono], [SolicitudesMail], [SolicitudesDireccion], [SolicitudesAutoEnumerar], [SolicitudesLiqProf], [SolicitudesLiqProv], [SolicitudesCotizacion], [SolicitudServicioSolCoti], [SolicitudesDescuento], [SolicitudesDescuentoCupon], [SolicitudesComisionMetodoPago], [SolicitudesOtros1], [SolicitudesOtros2], [SolicitudesOtros3], [SolicitudesUsrAlta], [SolicitudesUsrActualizacion], [SolicitudesFechaActualizacion], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [SolicitudesComentario], [SolicitudesNota], [SolicitudesNotificacion], [SolicitudesPagado], [SolicitudServicioComProv], [SolicitudServicioComProvP], [SolicitudServicioComALM], [SolicitudServicioComALMP], [SolicitudesCalComi], [ProveedorNombreAux], [SolicitudesSubTipo], [SolicitudesCostoXZona], [SolicitudesDuplicado], [SolicitudesSerialArchivo], [SolicitudesCostoPresupuesto], [SolicitudesURLOrigen], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID], [MetodoPagosID], [MudanzaId], [ProveedorID], [STComerciosID] AS STComerciosID, [PostulacionesId], [CancelacionTipificacionId], [CuponId], [TicketId], [EstadosSolTipo] AS EstadosSolTipo, [EstadosSolId] AS EstadosSolId, [STMonedasId] AS STMonedasId FROM [Solicitudes] WHERE [SolicitudesID] = @SolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O12", "SELECT [PaisID] FROM [Departamento] WITH (UPDLOCK) WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O13", "SELECT [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O14", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O15", "SELECT [ZonasID] FROM [Zonas] WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O16", "SELECT [MetodoPagosNombre] FROM [MetodoPagos] WHERE [MetodoPagosID] = @MetodoPagosID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O17", "SELECT [MudanzaFechaServicio], [MudanzaDireccionOrigen], [MudanzaDireccionDestino] FROM [Mudanza] WHERE [MudanzaId] = @MudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O18", "SELECT [ProveedorNombre], [ProveedorPagoDefault] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O19", "SELECT [ProveedorNombre] AS STComerciosNombre, [ProveedorEstado] AS STComerciosEstado FROM [Proveedor] WHERE [ProveedorID] = @STComerciosID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O20", "SELECT [PostulacionesId] FROM [Postulaciones] WHERE [PostulacionesId] = @PostulacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O21", "SELECT [CancelacionTipificacionDescrip] FROM [CancelacionTipificacion] WHERE [CancelacionTipificacionId] = @CancelacionTipificacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O22", "SELECT [CuponPercent] FROM [Cupon] WHERE [CuponId] = @CuponId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O23", "SELECT [TicketComentario], [TicketAdjunto], [TicketEstado], [TicketSolicitudId], [TicketMotivoId] FROM [Ticket] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O24", "SELECT [EstadosGenericosNombre] AS EstadosSolNombre FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosSolTipo AND [EstadosGenericosId] = @EstadosSolId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O25", "SELECT [MonedaISOSimbolo] AS STMonedasISO FROM [Moneda] WHERE [MonedaId] = @STMonedasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O26", "SELECT [TicketMotivoDescripcion] FROM [TicketMotivo] WHERE [TicketMotivoId] = @TicketMotivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O27", cmdBufferBC000O27,true, GxErrorMask.GX_NOMASK, false, this,prmBC000O27,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O28", "SELECT [SolicitudesID] FROM [Solicitudes] WHERE [SolicitudesID] = @SolicitudesID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O29", "SELECT [PaisID] FROM [Departamento] WITH (UPDLOCK) WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O30", cmdBufferBC000O30,true, GxErrorMask.GX_NOMASK, false, this,prmBC000O30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000O31", cmdBufferBC000O31, GxErrorMask.GX_NOMASK,prmBC000O31)
           ,new CursorDef("BC000O32", "DELETE FROM [Solicitudes]  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK,prmBC000O32)
           ,new CursorDef("BC000O33", "SELECT [MonedaISOSimbolo] AS STMonedasISO FROM [Moneda] WHERE [MonedaId] = @STMonedasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O33,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O34", "SELECT [CuponPercent] FROM [Cupon] WHERE [CuponId] = @CuponId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O34,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O35", "SELECT [EstadosGenericosNombre] AS EstadosSolNombre FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosSolTipo AND [EstadosGenericosId] = @EstadosSolId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O35,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O36", "SELECT [MetodoPagosNombre] FROM [MetodoPagos] WHERE [MetodoPagosID] = @MetodoPagosID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O36,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O37", "SELECT [ProveedorNombre], [ProveedorPagoDefault] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O37,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O38", "SELECT [ProveedorNombre] AS STComerciosNombre, [ProveedorEstado] AS STComerciosEstado FROM [Proveedor] WHERE [ProveedorID] = @STComerciosID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O38,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O39", "SELECT [MudanzaFechaServicio], [MudanzaDireccionOrigen], [MudanzaDireccionDestino] FROM [Mudanza] WHERE [MudanzaId] = @MudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O39,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O40", "SELECT [CancelacionTipificacionDescrip] FROM [CancelacionTipificacion] WHERE [CancelacionTipificacionId] = @CancelacionTipificacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O40,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O41", "SELECT [TicketComentario], [TicketAdjunto], [TicketEstado], [TicketSolicitudId], [TicketMotivoId] FROM [Ticket] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O41,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O42", "SELECT [TicketMotivoDescripcion] FROM [TicketMotivo] WHERE [TicketMotivoId] = @TicketMotivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O42,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O43", "SELECT TOP 1 [SolicitudesID], [RelacionesId] FROM [Relaciones] WHERE [SolicitudesID] = @SolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O43,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000O44", "UPDATE [Solicitudes] SET [SolicitudesSerialArchivo]=@SolicitudesSerialArchivo, [SolicitudesAutoEnumerar]=@SolicitudesAutoEnumerar  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK,prmBC000O44)
           ,new CursorDef("BC000O45", "UPDATE [Departamento] SET [PaisID]=@PaisID  WHERE [DepartamentoId] = @DepartamentoId", GxErrorMask.GX_NOMASK,prmBC000O45)
           ,new CursorDef("BC000O46", cmdBufferBC000O46,true, GxErrorMask.GX_NOMASK, false, this,prmBC000O46,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O47", "SELECT T1.[SolicitudesID], T1.[SolicitudesItemsID], T1.[SolicitudesItemsCantidad], T1.[SolicitudItemsComision], T1.[SolicitudItemsSR], T1.[SolicitudItemsComisionTipo], T2.[RubrosImagen_GXI], T2.[RubrosEstado], T5.[InventarioNombre], T5.[InventarioImagen_GXI], T5.[InventarioPrecioFinal], T5.[InventarioConsumoProductivo], T1.[SolicitudesItemsPrecioFinal], T4.[MonedaISOSimbolo], T1.[SolicitudesItemsComiProv], T1.[SolicitudesItemsComiProvP], T1.[SolicitudesItemsComiALM], T1.[SolicitudesItemsComiALMP], T1.[RubrosId], T1.[MedidasID], T1.[InventarioId], T3.[MonedaId], T5.[EstadosTipo], T5.[EstadosGenericosId], T2.[RubrosImagen], T5.[InventarioImagen] FROM (((([SolicitudesItems] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) INNER JOIN [Moneda] T4 ON T4.[MonedaId] = T3.[MonedaId]) INNER JOIN [Inventario] T5 ON T5.[RubrosId] = T1.[RubrosId] AND T5.[MedidasID] = T1.[MedidasID] AND T5.[InventarioId] = T1.[InventarioId]) WHERE T1.[SolicitudesID] = @SolicitudesID and T1.[SolicitudesItemsID] = @SolicitudesItemsID ORDER BY T1.[SolicitudesID], T1.[SolicitudesItemsID]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O47,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O48", "SELECT [SolicitudesID], [SolicitudesItemsID] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID AND [SolicitudesItemsID] = @SolicitudesItemsID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O48,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O49", "INSERT INTO [SolicitudesItems]([SolicitudesID], [SolicitudesItemsID], [SolicitudesItemsCantidad], [SolicitudItemsComision], [SolicitudItemsSR], [SolicitudItemsComisionTipo], [SolicitudesItemsPrecioFinal], [SolicitudesItemsComiProv], [SolicitudesItemsComiProvP], [SolicitudesItemsComiALM], [SolicitudesItemsComiALMP], [RubrosId], [MedidasID], [InventarioId]) VALUES(@SolicitudesID, @SolicitudesItemsID, @SolicitudesItemsCantidad, @SolicitudItemsComision, @SolicitudItemsSR, @SolicitudItemsComisionTipo, @SolicitudesItemsPrecioFinal, @SolicitudesItemsComiProv, @SolicitudesItemsComiProvP, @SolicitudesItemsComiALM, @SolicitudesItemsComiALMP, @RubrosId, @MedidasID, @InventarioId)", GxErrorMask.GX_NOMASK,prmBC000O49)
           ,new CursorDef("BC000O50", "UPDATE [SolicitudesItems] SET [SolicitudesItemsCantidad]=@SolicitudesItemsCantidad, [SolicitudItemsComision]=@SolicitudItemsComision, [SolicitudItemsSR]=@SolicitudItemsSR, [SolicitudItemsComisionTipo]=@SolicitudItemsComisionTipo, [SolicitudesItemsPrecioFinal]=@SolicitudesItemsPrecioFinal, [SolicitudesItemsComiProv]=@SolicitudesItemsComiProv, [SolicitudesItemsComiProvP]=@SolicitudesItemsComiProvP, [SolicitudesItemsComiALM]=@SolicitudesItemsComiALM, [SolicitudesItemsComiALMP]=@SolicitudesItemsComiALMP, [RubrosId]=@RubrosId, [MedidasID]=@MedidasID, [InventarioId]=@InventarioId  WHERE [SolicitudesID] = @SolicitudesID AND [SolicitudesItemsID] = @SolicitudesItemsID", GxErrorMask.GX_NOMASK,prmBC000O50)
           ,new CursorDef("BC000O51", "DELETE FROM [SolicitudesItems]  WHERE [SolicitudesID] = @SolicitudesID AND [SolicitudesItemsID] = @SolicitudesItemsID", GxErrorMask.GX_NOMASK,prmBC000O51)
           ,new CursorDef("BC000O52", "SELECT [RubrosImagen_GXI], [RubrosEstado], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O52,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O53", "SELECT [MonedaId] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O53,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O54", "SELECT [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O54,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O55", "SELECT [InventarioNombre], [InventarioImagen_GXI], [InventarioPrecioFinal], [InventarioConsumoProductivo], [EstadosTipo], [EstadosGenericosId], [InventarioImagen] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O55,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O56", "SELECT T1.[SolicitudesID], T1.[SolicitudesItemsID], T1.[SolicitudesItemsCantidad], T1.[SolicitudItemsComision], T1.[SolicitudItemsSR], T1.[SolicitudItemsComisionTipo], T2.[RubrosImagen_GXI], T2.[RubrosEstado], T5.[InventarioNombre], T5.[InventarioImagen_GXI], T5.[InventarioPrecioFinal], T5.[InventarioConsumoProductivo], T1.[SolicitudesItemsPrecioFinal], T4.[MonedaISOSimbolo], T1.[SolicitudesItemsComiProv], T1.[SolicitudesItemsComiProvP], T1.[SolicitudesItemsComiALM], T1.[SolicitudesItemsComiALMP], T1.[RubrosId], T1.[MedidasID], T1.[InventarioId], T3.[MonedaId], T5.[EstadosTipo], T5.[EstadosGenericosId], T2.[RubrosImagen], T5.[InventarioImagen] FROM (((([SolicitudesItems] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) INNER JOIN [Moneda] T4 ON T4.[MonedaId] = T3.[MonedaId]) INNER JOIN [Inventario] T5 ON T5.[RubrosId] = T1.[RubrosId] AND T5.[MedidasID] = T1.[MedidasID] AND T5.[InventarioId] = T1.[InventarioId]) WHERE T1.[SolicitudesID] = @SolicitudesID ORDER BY T1.[SolicitudesID], T1.[SolicitudesItemsID]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O56,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O57", "SELECT [SolicitudesID], [ArchivoId], [ArchivoDireccion], [ArchivoDescripcion], [ArchivoTipo] FROM [SolicitudesArchivo] WHERE [SolicitudesID] = @SolicitudesID and [ArchivoId] = @ArchivoId ORDER BY [SolicitudesID], [ArchivoId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O57,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O58", "SELECT [SolicitudesID], [ArchivoId] FROM [SolicitudesArchivo] WHERE [SolicitudesID] = @SolicitudesID AND [ArchivoId] = @ArchivoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O58,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O59", "INSERT INTO [SolicitudesArchivo]([SolicitudesID], [ArchivoId], [ArchivoDireccion], [ArchivoDescripcion], [ArchivoTipo]) VALUES(@SolicitudesID, @ArchivoId, @ArchivoDireccion, @ArchivoDescripcion, @ArchivoTipo)", GxErrorMask.GX_NOMASK,prmBC000O59)
           ,new CursorDef("BC000O60", "UPDATE [SolicitudesArchivo] SET [ArchivoDireccion]=@ArchivoDireccion, [ArchivoDescripcion]=@ArchivoDescripcion, [ArchivoTipo]=@ArchivoTipo  WHERE [SolicitudesID] = @SolicitudesID AND [ArchivoId] = @ArchivoId", GxErrorMask.GX_NOMASK,prmBC000O60)
           ,new CursorDef("BC000O61", "DELETE FROM [SolicitudesArchivo]  WHERE [SolicitudesID] = @SolicitudesID AND [ArchivoId] = @ArchivoId", GxErrorMask.GX_NOMASK,prmBC000O61)
           ,new CursorDef("BC000O62", "SELECT [SolicitudesID], [ArchivoId], [ArchivoDireccion], [ArchivoDescripcion], [ArchivoTipo] FROM [SolicitudesArchivo] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID], [ArchivoId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O62,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O63", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O63,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 250);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 250);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getString(6, 1);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(10);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((short[]) buf[16])[0] = rslt.getShort(12);
              ((long[]) buf[17])[0] = rslt.getLong(13);
              ((long[]) buf[18])[0] = rslt.getLong(14);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getString(6, 1);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(10);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((short[]) buf[16])[0] = rslt.getShort(12);
              ((long[]) buf[17])[0] = rslt.getLong(13);
              ((long[]) buf[18])[0] = rslt.getLong(14);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(2));
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 100);
              ((string[]) buf[10])[0] = rslt.getString(7, 20);
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              ((string[]) buf[13])[0] = rslt.getVarchar(9);
              ((short[]) buf[14])[0] = rslt.getShort(10);
              ((long[]) buf[15])[0] = rslt.getLong(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((long[]) buf[17])[0] = rslt.getLong(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(13);
              ((string[]) buf[20])[0] = rslt.getString(14, 1);
              ((decimal[]) buf[21])[0] = rslt.getDecimal(15);
              ((bool[]) buf[22])[0] = rslt.wasNull(15);
              ((decimal[]) buf[23])[0] = rslt.getDecimal(16);
              ((decimal[]) buf[24])[0] = rslt.getDecimal(17);
              ((string[]) buf[25])[0] = rslt.getString(18, 1);
              ((string[]) buf[26])[0] = rslt.getString(19, 1000);
              ((string[]) buf[27])[0] = rslt.getString(20, 500);
              ((long[]) buf[28])[0] = rslt.getLong(21);
              ((bool[]) buf[29])[0] = rslt.wasNull(21);
              ((long[]) buf[30])[0] = rslt.getLong(22);
              ((bool[]) buf[31])[0] = rslt.wasNull(22);
              ((DateTime[]) buf[32])[0] = rslt.getGXDateTime(23);
              ((bool[]) buf[33])[0] = rslt.wasNull(23);
              ((DateTime[]) buf[34])[0] = rslt.getGXDate(24);
              ((string[]) buf[35])[0] = rslt.getString(25, 1);
              ((string[]) buf[36])[0] = rslt.getLongVarchar(26);
              ((string[]) buf[37])[0] = rslt.getString(27, 500);
              ((string[]) buf[38])[0] = rslt.getString(28, 1);
              ((string[]) buf[39])[0] = rslt.getString(29, 1);
              ((bool[]) buf[40])[0] = rslt.wasNull(29);
              ((decimal[]) buf[41])[0] = rslt.getDecimal(30);
              ((bool[]) buf[42])[0] = rslt.wasNull(30);
              ((decimal[]) buf[43])[0] = rslt.getDecimal(31);
              ((bool[]) buf[44])[0] = rslt.wasNull(31);
              ((decimal[]) buf[45])[0] = rslt.getDecimal(32);
              ((bool[]) buf[46])[0] = rslt.wasNull(32);
              ((decimal[]) buf[47])[0] = rslt.getDecimal(33);
              ((bool[]) buf[48])[0] = rslt.wasNull(33);
              ((bool[]) buf[49])[0] = rslt.getBool(34);
              ((string[]) buf[50])[0] = rslt.getString(35, 80);
              ((bool[]) buf[51])[0] = rslt.wasNull(35);
              ((string[]) buf[52])[0] = rslt.getString(36, 1);
              ((bool[]) buf[53])[0] = rslt.wasNull(36);
              ((decimal[]) buf[54])[0] = rslt.getDecimal(37);
              ((long[]) buf[55])[0] = rslt.getLong(38);
              ((bool[]) buf[56])[0] = rslt.wasNull(38);
              ((short[]) buf[57])[0] = rslt.getShort(39);
              ((decimal[]) buf[58])[0] = rslt.getDecimal(40);
              ((bool[]) buf[59])[0] = rslt.wasNull(40);
              ((string[]) buf[60])[0] = rslt.getVarchar(41);
              ((bool[]) buf[61])[0] = rslt.wasNull(41);
              ((long[]) buf[62])[0] = rslt.getLong(42);
              ((bool[]) buf[63])[0] = rslt.wasNull(42);
              ((long[]) buf[64])[0] = rslt.getLong(43);
              ((bool[]) buf[65])[0] = rslt.wasNull(43);
              ((long[]) buf[66])[0] = rslt.getLong(44);
              ((bool[]) buf[67])[0] = rslt.wasNull(44);
              ((long[]) buf[68])[0] = rslt.getLong(45);
              ((long[]) buf[69])[0] = rslt.getLong(46);
              ((bool[]) buf[70])[0] = rslt.wasNull(46);
              ((long[]) buf[71])[0] = rslt.getLong(47);
              ((long[]) buf[72])[0] = rslt.getLong(48);
              ((bool[]) buf[73])[0] = rslt.wasNull(48);
              ((long[]) buf[74])[0] = rslt.getLong(49);
              ((bool[]) buf[75])[0] = rslt.wasNull(49);
              ((long[]) buf[76])[0] = rslt.getLong(50);
              ((long[]) buf[77])[0] = rslt.getLong(51);
              ((bool[]) buf[78])[0] = rslt.wasNull(51);
              ((long[]) buf[79])[0] = rslt.getLong(52);
              ((bool[]) buf[80])[0] = rslt.wasNull(52);
              ((string[]) buf[81])[0] = rslt.getString(53, 3);
              ((int[]) buf[82])[0] = rslt.getInt(54);
              ((short[]) buf[83])[0] = rslt.getShort(55);
              ((bool[]) buf[84])[0] = rslt.wasNull(55);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 100);
              ((string[]) buf[10])[0] = rslt.getString(7, 20);
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              ((string[]) buf[13])[0] = rslt.getVarchar(9);
              ((short[]) buf[14])[0] = rslt.getShort(10);
              ((long[]) buf[15])[0] = rslt.getLong(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((long[]) buf[17])[0] = rslt.getLong(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(13);
              ((string[]) buf[20])[0] = rslt.getString(14, 1);
              ((decimal[]) buf[21])[0] = rslt.getDecimal(15);
              ((bool[]) buf[22])[0] = rslt.wasNull(15);
              ((decimal[]) buf[23])[0] = rslt.getDecimal(16);
              ((decimal[]) buf[24])[0] = rslt.getDecimal(17);
              ((string[]) buf[25])[0] = rslt.getString(18, 1);
              ((string[]) buf[26])[0] = rslt.getString(19, 1000);
              ((string[]) buf[27])[0] = rslt.getString(20, 500);
              ((long[]) buf[28])[0] = rslt.getLong(21);
              ((bool[]) buf[29])[0] = rslt.wasNull(21);
              ((long[]) buf[30])[0] = rslt.getLong(22);
              ((bool[]) buf[31])[0] = rslt.wasNull(22);
              ((DateTime[]) buf[32])[0] = rslt.getGXDateTime(23);
              ((bool[]) buf[33])[0] = rslt.wasNull(23);
              ((DateTime[]) buf[34])[0] = rslt.getGXDate(24);
              ((string[]) buf[35])[0] = rslt.getString(25, 1);
              ((string[]) buf[36])[0] = rslt.getLongVarchar(26);
              ((string[]) buf[37])[0] = rslt.getString(27, 500);
              ((string[]) buf[38])[0] = rslt.getString(28, 1);
              ((string[]) buf[39])[0] = rslt.getString(29, 1);
              ((bool[]) buf[40])[0] = rslt.wasNull(29);
              ((decimal[]) buf[41])[0] = rslt.getDecimal(30);
              ((bool[]) buf[42])[0] = rslt.wasNull(30);
              ((decimal[]) buf[43])[0] = rslt.getDecimal(31);
              ((bool[]) buf[44])[0] = rslt.wasNull(31);
              ((decimal[]) buf[45])[0] = rslt.getDecimal(32);
              ((bool[]) buf[46])[0] = rslt.wasNull(32);
              ((decimal[]) buf[47])[0] = rslt.getDecimal(33);
              ((bool[]) buf[48])[0] = rslt.wasNull(33);
              ((bool[]) buf[49])[0] = rslt.getBool(34);
              ((string[]) buf[50])[0] = rslt.getString(35, 80);
              ((bool[]) buf[51])[0] = rslt.wasNull(35);
              ((string[]) buf[52])[0] = rslt.getString(36, 1);
              ((bool[]) buf[53])[0] = rslt.wasNull(36);
              ((decimal[]) buf[54])[0] = rslt.getDecimal(37);
              ((long[]) buf[55])[0] = rslt.getLong(38);
              ((bool[]) buf[56])[0] = rslt.wasNull(38);
              ((short[]) buf[57])[0] = rslt.getShort(39);
              ((decimal[]) buf[58])[0] = rslt.getDecimal(40);
              ((bool[]) buf[59])[0] = rslt.wasNull(40);
              ((string[]) buf[60])[0] = rslt.getVarchar(41);
              ((bool[]) buf[61])[0] = rslt.wasNull(41);
              ((long[]) buf[62])[0] = rslt.getLong(42);
              ((bool[]) buf[63])[0] = rslt.wasNull(42);
              ((long[]) buf[64])[0] = rslt.getLong(43);
              ((bool[]) buf[65])[0] = rslt.wasNull(43);
              ((long[]) buf[66])[0] = rslt.getLong(44);
              ((bool[]) buf[67])[0] = rslt.wasNull(44);
              ((long[]) buf[68])[0] = rslt.getLong(45);
              ((long[]) buf[69])[0] = rslt.getLong(46);
              ((bool[]) buf[70])[0] = rslt.wasNull(46);
              ((long[]) buf[71])[0] = rslt.getLong(47);
              ((long[]) buf[72])[0] = rslt.getLong(48);
              ((bool[]) buf[73])[0] = rslt.wasNull(48);
              ((long[]) buf[74])[0] = rslt.getLong(49);
              ((bool[]) buf[75])[0] = rslt.wasNull(49);
              ((long[]) buf[76])[0] = rslt.getLong(50);
              ((long[]) buf[77])[0] = rslt.getLong(51);
              ((bool[]) buf[78])[0] = rslt.wasNull(51);
              ((long[]) buf[79])[0] = rslt.getLong(52);
              ((bool[]) buf[80])[0] = rslt.wasNull(52);
              ((string[]) buf[81])[0] = rslt.getString(53, 3);
              ((int[]) buf[82])[0] = rslt.getInt(54);
              ((short[]) buf[83])[0] = rslt.getShort(55);
              ((bool[]) buf[84])[0] = rslt.wasNull(55);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 15 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 250);
              return;
           case 20 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 250);
              ((string[]) buf[1])[0] = rslt.getString(2, 250);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 250);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 100);
              ((string[]) buf[10])[0] = rslt.getString(7, 20);
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              ((string[]) buf[13])[0] = rslt.getVarchar(9);
              ((short[]) buf[14])[0] = rslt.getShort(10);
              ((string[]) buf[15])[0] = rslt.getString(11, 3);
              ((long[]) buf[16])[0] = rslt.getLong(12);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((long[]) buf[18])[0] = rslt.getLong(13);
              ((bool[]) buf[19])[0] = rslt.wasNull(13);
              ((decimal[]) buf[20])[0] = rslt.getDecimal(14);
              ((string[]) buf[21])[0] = rslt.getString(15, 1);
              ((decimal[]) buf[22])[0] = rslt.getDecimal(16);
              ((bool[]) buf[23])[0] = rslt.wasNull(16);
              ((short[]) buf[24])[0] = rslt.getShort(17);
              ((decimal[]) buf[25])[0] = rslt.getDecimal(18);
              ((decimal[]) buf[26])[0] = rslt.getDecimal(19);
              ((string[]) buf[27])[0] = rslt.getString(20, 80);
              ((string[]) buf[28])[0] = rslt.getString(21, 1);
              ((string[]) buf[29])[0] = rslt.getString(22, 1000);
              ((string[]) buf[30])[0] = rslt.getString(23, 500);
              ((long[]) buf[31])[0] = rslt.getLong(24);
              ((bool[]) buf[32])[0] = rslt.wasNull(24);
              ((long[]) buf[33])[0] = rslt.getLong(25);
              ((bool[]) buf[34])[0] = rslt.wasNull(25);
              ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(26);
              ((bool[]) buf[36])[0] = rslt.wasNull(26);
              ((DateTime[]) buf[37])[0] = rslt.getGXDate(27);
              ((string[]) buf[38])[0] = rslt.getString(28, 1);
              ((string[]) buf[39])[0] = rslt.getLongVarchar(29);
              ((string[]) buf[40])[0] = rslt.getString(30, 80);
              ((string[]) buf[41])[0] = rslt.getString(31, 500);
              ((string[]) buf[42])[0] = rslt.getString(32, 1);
              ((string[]) buf[43])[0] = rslt.getString(33, 80);
              ((string[]) buf[44])[0] = rslt.getString(34, 1);
              ((string[]) buf[45])[0] = rslt.getString(35, 80);
              ((string[]) buf[46])[0] = rslt.getString(36, 3);
              ((string[]) buf[47])[0] = rslt.getString(37, 1);
              ((bool[]) buf[48])[0] = rslt.wasNull(37);
              ((decimal[]) buf[49])[0] = rslt.getDecimal(38);
              ((bool[]) buf[50])[0] = rslt.wasNull(38);
              ((decimal[]) buf[51])[0] = rslt.getDecimal(39);
              ((bool[]) buf[52])[0] = rslt.wasNull(39);
              ((decimal[]) buf[53])[0] = rslt.getDecimal(40);
              ((bool[]) buf[54])[0] = rslt.wasNull(40);
              ((decimal[]) buf[55])[0] = rslt.getDecimal(41);
              ((bool[]) buf[56])[0] = rslt.wasNull(41);
              ((bool[]) buf[57])[0] = rslt.getBool(42);
              ((string[]) buf[58])[0] = rslt.getString(43, 80);
              ((bool[]) buf[59])[0] = rslt.wasNull(43);
              ((string[]) buf[60])[0] = rslt.getString(44, 1);
              ((bool[]) buf[61])[0] = rslt.wasNull(44);
              ((decimal[]) buf[62])[0] = rslt.getDecimal(45);
              ((DateTime[]) buf[63])[0] = rslt.getGXDate(46);
              ((string[]) buf[64])[0] = rslt.getVarchar(47);
              ((string[]) buf[65])[0] = rslt.getVarchar(48);
              ((long[]) buf[66])[0] = rslt.getLong(49);
              ((bool[]) buf[67])[0] = rslt.wasNull(49);
              ((short[]) buf[68])[0] = rslt.getShort(50);
              ((string[]) buf[69])[0] = rslt.getString(51, 250);
              ((decimal[]) buf[70])[0] = rslt.getDecimal(52);
              ((bool[]) buf[71])[0] = rslt.wasNull(52);
              ((string[]) buf[72])[0] = rslt.getVarchar(53);
              ((bool[]) buf[73])[0] = rslt.wasNull(53);
              ((string[]) buf[74])[0] = rslt.getString(54, 250);
              ((string[]) buf[75])[0] = rslt.getString(55, 250);
              ((string[]) buf[76])[0] = rslt.getString(56, 250);
              ((bool[]) buf[77])[0] = rslt.getBool(57);
              ((long[]) buf[78])[0] = rslt.getLong(58);
              ((long[]) buf[79])[0] = rslt.getLong(59);
              ((bool[]) buf[80])[0] = rslt.wasNull(59);
              ((long[]) buf[81])[0] = rslt.getLong(60);
              ((bool[]) buf[82])[0] = rslt.wasNull(60);
              ((long[]) buf[83])[0] = rslt.getLong(61);
              ((bool[]) buf[84])[0] = rslt.wasNull(61);
              ((long[]) buf[85])[0] = rslt.getLong(62);
              ((long[]) buf[86])[0] = rslt.getLong(63);
              ((bool[]) buf[87])[0] = rslt.wasNull(63);
              ((long[]) buf[88])[0] = rslt.getLong(64);
              ((long[]) buf[89])[0] = rslt.getLong(65);
              ((bool[]) buf[90])[0] = rslt.wasNull(65);
              ((long[]) buf[91])[0] = rslt.getLong(66);
              ((bool[]) buf[92])[0] = rslt.wasNull(66);
              ((long[]) buf[93])[0] = rslt.getLong(67);
              ((long[]) buf[94])[0] = rslt.getLong(68);
              ((bool[]) buf[95])[0] = rslt.wasNull(68);
              ((long[]) buf[96])[0] = rslt.getLong(69);
              ((bool[]) buf[97])[0] = rslt.wasNull(69);
              ((string[]) buf[98])[0] = rslt.getString(70, 3);
              ((int[]) buf[99])[0] = rslt.getInt(71);
              ((short[]) buf[100])[0] = rslt.getShort(72);
              ((bool[]) buf[101])[0] = rslt.wasNull(72);
              ((string[]) buf[102])[0] = rslt.getString(73, 2);
              ((long[]) buf[103])[0] = rslt.getLong(74);
              return;
           case 26 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getString(1, 2);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 32 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 34 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              return;
           case 36 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 37 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 38 :
              ((string[]) buf[0])[0] = rslt.getString(1, 250);
              return;
           case 39 :
              ((string[]) buf[0])[0] = rslt.getString(1, 250);
              ((string[]) buf[1])[0] = rslt.getString(2, 250);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              return;
           case 40 :
              ((string[]) buf[0])[0] = rslt.getString(1, 250);
              return;
           case 41 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 44 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 100);
              ((string[]) buf[10])[0] = rslt.getString(7, 20);
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              ((string[]) buf[13])[0] = rslt.getVarchar(9);
              ((short[]) buf[14])[0] = rslt.getShort(10);
              ((string[]) buf[15])[0] = rslt.getString(11, 3);
              ((long[]) buf[16])[0] = rslt.getLong(12);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((long[]) buf[18])[0] = rslt.getLong(13);
              ((bool[]) buf[19])[0] = rslt.wasNull(13);
              ((decimal[]) buf[20])[0] = rslt.getDecimal(14);
              ((string[]) buf[21])[0] = rslt.getString(15, 1);
              ((decimal[]) buf[22])[0] = rslt.getDecimal(16);
              ((bool[]) buf[23])[0] = rslt.wasNull(16);
              ((short[]) buf[24])[0] = rslt.getShort(17);
              ((decimal[]) buf[25])[0] = rslt.getDecimal(18);
              ((decimal[]) buf[26])[0] = rslt.getDecimal(19);
              ((string[]) buf[27])[0] = rslt.getString(20, 80);
              ((string[]) buf[28])[0] = rslt.getString(21, 1);
              ((string[]) buf[29])[0] = rslt.getString(22, 1000);
              ((string[]) buf[30])[0] = rslt.getString(23, 500);
              ((long[]) buf[31])[0] = rslt.getLong(24);
              ((bool[]) buf[32])[0] = rslt.wasNull(24);
              ((long[]) buf[33])[0] = rslt.getLong(25);
              ((bool[]) buf[34])[0] = rslt.wasNull(25);
              ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(26);
              ((bool[]) buf[36])[0] = rslt.wasNull(26);
              ((DateTime[]) buf[37])[0] = rslt.getGXDate(27);
              ((string[]) buf[38])[0] = rslt.getString(28, 1);
              ((string[]) buf[39])[0] = rslt.getLongVarchar(29);
              ((string[]) buf[40])[0] = rslt.getString(30, 80);
              ((string[]) buf[41])[0] = rslt.getString(31, 500);
              ((string[]) buf[42])[0] = rslt.getString(32, 1);
              ((string[]) buf[43])[0] = rslt.getString(33, 80);
              ((string[]) buf[44])[0] = rslt.getString(34, 1);
              ((string[]) buf[45])[0] = rslt.getString(35, 80);
              ((string[]) buf[46])[0] = rslt.getString(36, 3);
              ((string[]) buf[47])[0] = rslt.getString(37, 1);
              ((bool[]) buf[48])[0] = rslt.wasNull(37);
              ((decimal[]) buf[49])[0] = rslt.getDecimal(38);
              ((bool[]) buf[50])[0] = rslt.wasNull(38);
              ((decimal[]) buf[51])[0] = rslt.getDecimal(39);
              ((bool[]) buf[52])[0] = rslt.wasNull(39);
              ((decimal[]) buf[53])[0] = rslt.getDecimal(40);
              ((bool[]) buf[54])[0] = rslt.wasNull(40);
              ((decimal[]) buf[55])[0] = rslt.getDecimal(41);
              ((bool[]) buf[56])[0] = rslt.wasNull(41);
              ((bool[]) buf[57])[0] = rslt.getBool(42);
              ((string[]) buf[58])[0] = rslt.getString(43, 80);
              ((bool[]) buf[59])[0] = rslt.wasNull(43);
              ((string[]) buf[60])[0] = rslt.getString(44, 1);
              ((bool[]) buf[61])[0] = rslt.wasNull(44);
              ((decimal[]) buf[62])[0] = rslt.getDecimal(45);
              ((DateTime[]) buf[63])[0] = rslt.getGXDate(46);
              ((string[]) buf[64])[0] = rslt.getVarchar(47);
              ((string[]) buf[65])[0] = rslt.getVarchar(48);
              ((long[]) buf[66])[0] = rslt.getLong(49);
              ((bool[]) buf[67])[0] = rslt.wasNull(49);
              ((short[]) buf[68])[0] = rslt.getShort(50);
              ((string[]) buf[69])[0] = rslt.getString(51, 250);
              ((decimal[]) buf[70])[0] = rslt.getDecimal(52);
              ((bool[]) buf[71])[0] = rslt.wasNull(52);
              ((string[]) buf[72])[0] = rslt.getVarchar(53);
              ((bool[]) buf[73])[0] = rslt.wasNull(53);
              ((string[]) buf[74])[0] = rslt.getString(54, 250);
              ((string[]) buf[75])[0] = rslt.getString(55, 250);
              ((string[]) buf[76])[0] = rslt.getString(56, 250);
              ((bool[]) buf[77])[0] = rslt.getBool(57);
              ((long[]) buf[78])[0] = rslt.getLong(58);
              ((long[]) buf[79])[0] = rslt.getLong(59);
              ((bool[]) buf[80])[0] = rslt.wasNull(59);
              ((long[]) buf[81])[0] = rslt.getLong(60);
              ((bool[]) buf[82])[0] = rslt.wasNull(60);
              ((long[]) buf[83])[0] = rslt.getLong(61);
              ((bool[]) buf[84])[0] = rslt.wasNull(61);
              ((long[]) buf[85])[0] = rslt.getLong(62);
              ((long[]) buf[86])[0] = rslt.getLong(63);
              ((bool[]) buf[87])[0] = rslt.wasNull(63);
              ((long[]) buf[88])[0] = rslt.getLong(64);
              ((long[]) buf[89])[0] = rslt.getLong(65);
              ((bool[]) buf[90])[0] = rslt.wasNull(65);
              ((long[]) buf[91])[0] = rslt.getLong(66);
              ((bool[]) buf[92])[0] = rslt.wasNull(66);
              ((long[]) buf[93])[0] = rslt.getLong(67);
              ((long[]) buf[94])[0] = rslt.getLong(68);
              ((bool[]) buf[95])[0] = rslt.wasNull(68);
              ((long[]) buf[96])[0] = rslt.getLong(69);
              ((bool[]) buf[97])[0] = rslt.wasNull(69);
              ((string[]) buf[98])[0] = rslt.getString(70, 3);
              ((int[]) buf[99])[0] = rslt.getInt(71);
              ((short[]) buf[100])[0] = rslt.getShort(72);
              ((bool[]) buf[101])[0] = rslt.wasNull(72);
              ((string[]) buf[102])[0] = rslt.getString(73, 2);
              ((long[]) buf[103])[0] = rslt.getLong(74);
              return;
           case 45 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getString(6, 1);
              ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 100);
              ((string[]) buf[10])[0] = rslt.getMultimediaUri(10);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
              ((bool[]) buf[14])[0] = rslt.wasNull(13);
              ((string[]) buf[15])[0] = rslt.getString(14, 3);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(15);
              ((bool[]) buf[17])[0] = rslt.wasNull(15);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(16);
              ((bool[]) buf[19])[0] = rslt.wasNull(16);
              ((decimal[]) buf[20])[0] = rslt.getDecimal(17);
              ((bool[]) buf[21])[0] = rslt.wasNull(17);
              ((decimal[]) buf[22])[0] = rslt.getDecimal(18);
              ((bool[]) buf[23])[0] = rslt.wasNull(18);
              ((short[]) buf[24])[0] = rslt.getShort(19);
              ((long[]) buf[25])[0] = rslt.getLong(20);
              ((long[]) buf[26])[0] = rslt.getLong(21);
              ((short[]) buf[27])[0] = rslt.getShort(22);
              ((string[]) buf[28])[0] = rslt.getString(23, 3);
              ((int[]) buf[29])[0] = rslt.getInt(24);
              ((string[]) buf[30])[0] = rslt.getMultimediaFile(25, rslt.getVarchar(7));
              ((string[]) buf[31])[0] = rslt.getMultimediaFile(26, rslt.getVarchar(10));
              return;
           case 46 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 50 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
              return;
           case 51 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 52 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 53 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(2));
              return;
           case 54 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getString(6, 1);
              ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 100);
              ((string[]) buf[10])[0] = rslt.getMultimediaUri(10);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
              ((bool[]) buf[14])[0] = rslt.wasNull(13);
              ((string[]) buf[15])[0] = rslt.getString(14, 3);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(15);
              ((bool[]) buf[17])[0] = rslt.wasNull(15);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(16);
              ((bool[]) buf[19])[0] = rslt.wasNull(16);
              ((decimal[]) buf[20])[0] = rslt.getDecimal(17);
              ((bool[]) buf[21])[0] = rslt.wasNull(17);
              ((decimal[]) buf[22])[0] = rslt.getDecimal(18);
              ((bool[]) buf[23])[0] = rslt.wasNull(18);
              ((short[]) buf[24])[0] = rslt.getShort(19);
              ((long[]) buf[25])[0] = rslt.getLong(20);
              ((long[]) buf[26])[0] = rslt.getLong(21);
              ((short[]) buf[27])[0] = rslt.getShort(22);
              ((string[]) buf[28])[0] = rslt.getString(23, 3);
              ((int[]) buf[29])[0] = rslt.getInt(24);
              ((string[]) buf[30])[0] = rslt.getMultimediaFile(25, rslt.getVarchar(7));
              ((string[]) buf[31])[0] = rslt.getMultimediaFile(26, rslt.getVarchar(10));
              return;
           case 55 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 250);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 56 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
     getresults60( cursor, rslt, buf) ;
  }

  public void getresults60( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 60 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 250);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 61 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
     }
  }

}

}
