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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class mudanza_bc : GXHttpHandler, IGxSilentTrn
   {
      public mudanza_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mudanza_bc( IGxContext context )
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
         ReadRow2K119( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2K119( ) ;
         standaloneModal( ) ;
         AddRow2K119( ) ;
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
            E112K2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z735MudanzaId = A735MudanzaId;
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

      protected void CONFIRM_2K0( )
      {
         BeforeValidate2K119( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2K119( ) ;
            }
            else
            {
               CheckExtendedTable2K119( ) ;
               if ( AnyError == 0 )
               {
                  ZM2K119( 12) ;
                  ZM2K119( 13) ;
                  ZM2K119( 14) ;
                  ZM2K119( 15) ;
               }
               CloseExtendedTableCursors2K119( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode119 = Gx_mode;
            CONFIRM_2K120( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_2K121( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode119;
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode119;
         }
      }

      protected void CONFIRM_2K121( )
      {
         nGXsfl_121_idx = 0;
         while ( nGXsfl_121_idx < bcMudanza.gxTpr_Adicional.Count )
         {
            ReadRow2K121( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound121 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_121 != 0 ) )
            {
               GetKey2K121( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound121 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate2K121( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable2K121( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM2K121( 19) ;
                        }
                        CloseExtendedTableCursors2K121( ) ;
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
                  if ( RcdFound121 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey2K121( ) ;
                        Load2K121( ) ;
                        BeforeValidate2K121( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls2K121( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_121 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate2K121( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable2K121( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM2K121( 19) ;
                              }
                              CloseExtendedTableCursors2K121( ) ;
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
               VarsToRow121( ((SdtMudanza_Adicional)bcMudanza.gxTpr_Adicional.Item(nGXsfl_121_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_2K120( )
      {
         nGXsfl_120_idx = 0;
         while ( nGXsfl_120_idx < bcMudanza.gxTpr_Carga.Count )
         {
            ReadRow2K120( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound120 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_120 != 0 ) )
            {
               GetKey2K120( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound120 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate2K120( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable2K120( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM2K120( 17) ;
                        }
                        CloseExtendedTableCursors2K120( ) ;
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
                  if ( RcdFound120 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey2K120( ) ;
                        Load2K120( ) ;
                        BeforeValidate2K120( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls2K120( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_120 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate2K120( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable2K120( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM2K120( 17) ;
                              }
                              CloseExtendedTableCursors2K120( ) ;
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
               VarsToRow120( ((SdtMudanza_Carga)bcMudanza.gxTpr_Carga.Item(nGXsfl_120_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E122K2( )
      {
         /* Start Routine */
         returnInSub = false;
         new oparametros(context ).execute(  context.GetMessage( "URLPASPAG", ""), out  AV112USLPAGO, out  AV113ParametrosNumerico, out  AV114ParametrosEstado) ;
         new oparametros(context ).execute(  context.GetMessage( "URLMAPBOX", ""), out  AV115URLMAPA, out  AV113ParametrosNumerico, out  AV114ParametrosEstado) ;
         new oparametros(context ).execute(  context.GetMessage( "COORDENADAMAPBOX", ""), out  AV116Coordenadas, out  AV113ParametrosNumerico, out  AV114ParametrosEstado) ;
         new oparametros(context ).execute(  context.GetMessage( "TOKENMAPBOX", ""), out  AV117Token, out  AV113ParametrosNumerico, out  AV114ParametrosEstado) ;
         GXt_decimal1 = AV132TiempoxKm;
         new obtenervalortiempoxkm(context ).execute( out  GXt_decimal1) ;
         AV132TiempoxKm = GXt_decimal1;
         GXt_decimal1 = AV130PeonxHora;
         new obtenervalorpeon(context ).execute( out  GXt_decimal1) ;
         AV130PeonxHora = GXt_decimal1;
         GXt_decimal1 = AV134TiempoxM3;
         new obtenertiempoxm3(context ).execute( out  GXt_decimal1) ;
         AV134TiempoxM3 = GXt_decimal1;
         if ( 0 == 1 )
         {
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
            AV9IsAuthorized = true;
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               GXt_boolean2 = AV9IsAuthorized;
               new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza_Insert", out  GXt_boolean2) ;
               AV9IsAuthorized = GXt_boolean2;
            }
            if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               GXt_boolean2 = AV9IsAuthorized;
               new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza_Update", out  GXt_boolean2) ;
               AV9IsAuthorized = GXt_boolean2;
            }
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               GXt_boolean2 = AV9IsAuthorized;
               new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza_Delete", out  GXt_boolean2) ;
               AV9IsAuthorized = GXt_boolean2;
            }
            if ( ! AV9IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV138Pgmname));
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
            AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
            if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV138Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
            {
               AV139GXV1 = 1;
               while ( AV139GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
               {
                  AV17TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV139GXV1));
                  if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "TipoInmuebleOrigenId") == 0 )
                  {
                     AV13Insert_TipoInmuebleOrigenId = (short)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "TipoInmuebleDestinoId") == 0 )
                  {
                     AV14Insert_TipoInmuebleDestinoId = (short)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "TipoEstacionamOrigenId") == 0 )
                  {
                     AV15Insert_TipoEstacionamOrigenId = (short)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "TipoEstacionamDestinoId") == 0 )
                  {
                     AV16Insert_TipoEstacionamDestinoId = (short)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  }
                  AV139GXV1 = (int)(AV139GXV1+1);
               }
            }
         }
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV138Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV140GXV2 = 1;
            while ( AV140GXV2 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV140GXV2));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "TipoInmuebleOrigenId") == 0 )
               {
                  AV13Insert_TipoInmuebleOrigenId = (short)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "TipoInmuebleDestinoId") == 0 )
               {
                  AV14Insert_TipoInmuebleDestinoId = (short)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "TipoEstacionamOrigenId") == 0 )
               {
                  AV15Insert_TipoEstacionamOrigenId = (short)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "TipoEstacionamDestinoId") == 0 )
               {
                  AV16Insert_TipoEstacionamDestinoId = (short)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV140GXV2 = (int)(AV140GXV2+1);
            }
         }
      }

      protected void E112K2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( 0 == 1 )
         {
         }
         AV12WebSession.Remove(context.GetMessage( "MudanzaPrecioBasexHora", ""));
         AV12WebSession.Remove(context.GetMessage( "Distancia", ""));
         AV12WebSession.Remove(context.GetMessage( "MudanzaTiempoMaximo", ""));
         AV12WebSession.Remove(context.GetMessage( "MudanzaPrecioFinal", ""));
         AV12WebSession.Remove(context.GetMessage( "VolumenEstimado", ""));
         AV12WebSession.Remove(context.GetMessage( "ValorAdicional", ""));
         AV12WebSession.Remove(context.GetMessage( "VehiculoSugerido", ""));
         AV12WebSession.Remove(context.GetMessage( "Nombre", ""));
         AV12WebSession.Remove(context.GetMessage( "Email", ""));
         AV12WebSession.Remove(context.GetMessage( "Telefono", ""));
         AV12WebSession.Remove(context.GetMessage( "LocalidadOrigen", ""));
         AV12WebSession.Remove(context.GetMessage( "LocalidadDestino", ""));
         AV12WebSession.Remove(context.GetMessage( "ValorCategorial", ""));
         AV12WebSession.Remove(context.GetMessage( "ValorCategoria2", ""));
         AV12WebSession.Remove(context.GetMessage( "ValorCategoria3", ""));
         AV12WebSession.Remove(context.GetMessage( "ValorCategoria4", ""));
         AV12WebSession.Remove(context.GetMessage( "ValorCategoria5", ""));
         AV12WebSession.Remove(context.GetMessage( "MudanzaComentario", ""));
         AV12WebSession.Remove(context.GetMessage( "Opcion11", ""));
         AV12WebSession.Remove(context.GetMessage( "Opcion22", ""));
         AV12WebSession.Remove(context.GetMessage( "PisoElevacion", ""));
      }

      protected void E132K2( )
      {
         /* 'DoAddGridLineGridLevel_Carga' Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void E142K2( )
      {
         /* Terminos_Click Routine */
         returnInSub = false;
         if ( AV128Terminos )
         {
            AV12WebSession.Set(context.GetMessage( "TyC", ""), context.GetMessage( "True", ""));
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Atención",  context.GetMessage( "Términos y Condiciones aceptados.", ""),  "info",  "",  "true",  ""));
         }
         else
         {
            AV12WebSession.Set(context.GetMessage( "TyC", ""), context.GetMessage( "False", ""));
         }
      }

      protected void ZM2K119( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z760MudanzaPeajevalor = A760MudanzaPeajevalor;
            Z736MudanzaAsesor = A736MudanzaAsesor;
            Z784MudanzaApellidoNombre = A784MudanzaApellidoNombre;
            Z785MudanzaMail = A785MudanzaMail;
            Z786MudanzaPhone = A786MudanzaPhone;
            Z737MudanzaFechaAlta = A737MudanzaFechaAlta;
            Z873MudanzaFechaUpdate = A873MudanzaFechaUpdate;
            Z738MudanzaFechaServicio = A738MudanzaFechaServicio;
            Z739MudanzaHoraServicio = A739MudanzaHoraServicio;
            Z776MudanzaRgoHoraservicio = A776MudanzaRgoHoraservicio;
            Z740MudanzaDireccionOrigen = A740MudanzaDireccionOrigen;
            Z788MudanzaLocalidadOrigen = A788MudanzaLocalidadOrigen;
            Z777MudanzaPisoDptoOrigen = A777MudanzaPisoDptoOrigen;
            Z741MudanzaDireccionDestino = A741MudanzaDireccionDestino;
            Z789MudanzaLocalidadDestino = A789MudanzaLocalidadDestino;
            Z778MudanzaPisoDptoDestino = A778MudanzaPisoDptoDestino;
            Z762MudanzaDistancia = A762MudanzaDistancia;
            Z871MudanzaCoordenadaOrigen = A871MudanzaCoordenadaOrigen;
            Z872MudanzaCoordenadaDestino = A872MudanzaCoordenadaDestino;
            Z742MudanzaVehiculoSugerido = A742MudanzaVehiculoSugerido;
            Z780MudanzaPrecioBasexHora = A780MudanzaPrecioBasexHora;
            Z761MudanzaPeajeCantidad = A761MudanzaPeajeCantidad;
            Z783MudanzaComentario = A783MudanzaComentario;
            Z794MudanzaOrigenMetodo = A794MudanzaOrigenMetodo;
            Z795MudanzaDestinoMetodo = A795MudanzaDestinoMetodo;
            Z763MudanzaTiempoMaximo = A763MudanzaTiempoMaximo;
            Z765MudanzaCargaVolumenEstimado = A765MudanzaCargaVolumenEstimado;
            Z782MudanzaAdicionalPrecio = A782MudanzaAdicionalPrecio;
            Z874MudanzaElevacion = A874MudanzaElevacion;
            Z875MudanzaDescenso = A875MudanzaDescenso;
            Z876MudanzaEmbalaje = A876MudanzaEmbalaje;
            Z840MudanzaCantidadPeones = A840MudanzaCantidadPeones;
            Z764MudanzaPrecioFinal = A764MudanzaPrecioFinal;
            Z790MudanzaOperacionId = A790MudanzaOperacionId;
            Z791MudanzaFormaPago = A791MudanzaFormaPago;
            Z792MudanzaProveedorId = A792MudanzaProveedorId;
            Z837MudanzaSecUserId = A837MudanzaSecUserId;
            Z743TipoInmuebleOrigenId = A743TipoInmuebleOrigenId;
            Z745TipoInmuebleDestinoId = A745TipoInmuebleDestinoId;
            Z747TipoEstacionamOrigenId = A747TipoEstacionamOrigenId;
            Z749TipoEstacionamDestinoId = A749TipoEstacionamDestinoId;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z755TipoInmuebleOrigenNombre = A755TipoInmuebleOrigenNombre;
            Z756TipoInmuebleOrigenValor = A756TipoInmuebleOrigenValor;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z746TipoInmuebleDestinoNombre = A746TipoInmuebleDestinoNombre;
            Z757TipoInmuebleDestinoValor = A757TipoInmuebleDestinoValor;
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z748TipoEstacionamOrigenNombre = A748TipoEstacionamOrigenNombre;
            Z758TipoEstacionamOrigenValor = A758TipoEstacionamOrigenValor;
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z750TipoEstacionamDestinoNombre = A750TipoEstacionamDestinoNombre;
            Z759TipoEstacionamDestinoValor = A759TipoEstacionamDestinoValor;
         }
         if ( GX_JID == -11 )
         {
            Z760MudanzaPeajevalor = A760MudanzaPeajevalor;
            Z735MudanzaId = A735MudanzaId;
            Z736MudanzaAsesor = A736MudanzaAsesor;
            Z784MudanzaApellidoNombre = A784MudanzaApellidoNombre;
            Z785MudanzaMail = A785MudanzaMail;
            Z786MudanzaPhone = A786MudanzaPhone;
            Z737MudanzaFechaAlta = A737MudanzaFechaAlta;
            Z873MudanzaFechaUpdate = A873MudanzaFechaUpdate;
            Z738MudanzaFechaServicio = A738MudanzaFechaServicio;
            Z739MudanzaHoraServicio = A739MudanzaHoraServicio;
            Z776MudanzaRgoHoraservicio = A776MudanzaRgoHoraservicio;
            Z740MudanzaDireccionOrigen = A740MudanzaDireccionOrigen;
            Z788MudanzaLocalidadOrigen = A788MudanzaLocalidadOrigen;
            Z777MudanzaPisoDptoOrigen = A777MudanzaPisoDptoOrigen;
            Z741MudanzaDireccionDestino = A741MudanzaDireccionDestino;
            Z789MudanzaLocalidadDestino = A789MudanzaLocalidadDestino;
            Z778MudanzaPisoDptoDestino = A778MudanzaPisoDptoDestino;
            Z762MudanzaDistancia = A762MudanzaDistancia;
            Z871MudanzaCoordenadaOrigen = A871MudanzaCoordenadaOrigen;
            Z872MudanzaCoordenadaDestino = A872MudanzaCoordenadaDestino;
            Z742MudanzaVehiculoSugerido = A742MudanzaVehiculoSugerido;
            Z780MudanzaPrecioBasexHora = A780MudanzaPrecioBasexHora;
            Z761MudanzaPeajeCantidad = A761MudanzaPeajeCantidad;
            Z783MudanzaComentario = A783MudanzaComentario;
            Z794MudanzaOrigenMetodo = A794MudanzaOrigenMetodo;
            Z795MudanzaDestinoMetodo = A795MudanzaDestinoMetodo;
            Z763MudanzaTiempoMaximo = A763MudanzaTiempoMaximo;
            Z765MudanzaCargaVolumenEstimado = A765MudanzaCargaVolumenEstimado;
            Z782MudanzaAdicionalPrecio = A782MudanzaAdicionalPrecio;
            Z874MudanzaElevacion = A874MudanzaElevacion;
            Z875MudanzaDescenso = A875MudanzaDescenso;
            Z876MudanzaEmbalaje = A876MudanzaEmbalaje;
            Z840MudanzaCantidadPeones = A840MudanzaCantidadPeones;
            Z764MudanzaPrecioFinal = A764MudanzaPrecioFinal;
            Z790MudanzaOperacionId = A790MudanzaOperacionId;
            Z791MudanzaFormaPago = A791MudanzaFormaPago;
            Z792MudanzaProveedorId = A792MudanzaProveedorId;
            Z837MudanzaSecUserId = A837MudanzaSecUserId;
            Z743TipoInmuebleOrigenId = A743TipoInmuebleOrigenId;
            Z745TipoInmuebleDestinoId = A745TipoInmuebleDestinoId;
            Z747TipoEstacionamOrigenId = A747TipoEstacionamOrigenId;
            Z749TipoEstacionamDestinoId = A749TipoEstacionamDestinoId;
            Z755TipoInmuebleOrigenNombre = A755TipoInmuebleOrigenNombre;
            Z756TipoInmuebleOrigenValor = A756TipoInmuebleOrigenValor;
            Z746TipoInmuebleDestinoNombre = A746TipoInmuebleDestinoNombre;
            Z757TipoInmuebleDestinoValor = A757TipoInmuebleDestinoValor;
            Z748TipoEstacionamOrigenNombre = A748TipoEstacionamOrigenNombre;
            Z758TipoEstacionamOrigenValor = A758TipoEstacionamOrigenValor;
            Z750TipoEstacionamDestinoNombre = A750TipoEstacionamDestinoNombre;
            Z759TipoEstacionamDestinoValor = A759TipoEstacionamDestinoValor;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         GXt_decimal1 = A760MudanzaPeajevalor;
         new opeajevalor(context ).execute( out  GXt_decimal1) ;
         A760MudanzaPeajevalor = GXt_decimal1;
      }

      protected void Load2K119( )
      {
         /* Using cursor BC002K14 */
         pr_default.execute(12, new Object[] {n735MudanzaId, A735MudanzaId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound119 = 1;
            A760MudanzaPeajevalor = BC002K14_A760MudanzaPeajevalor[0];
            A736MudanzaAsesor = BC002K14_A736MudanzaAsesor[0];
            A784MudanzaApellidoNombre = BC002K14_A784MudanzaApellidoNombre[0];
            A785MudanzaMail = BC002K14_A785MudanzaMail[0];
            A786MudanzaPhone = BC002K14_A786MudanzaPhone[0];
            A737MudanzaFechaAlta = BC002K14_A737MudanzaFechaAlta[0];
            A873MudanzaFechaUpdate = BC002K14_A873MudanzaFechaUpdate[0];
            A738MudanzaFechaServicio = BC002K14_A738MudanzaFechaServicio[0];
            A739MudanzaHoraServicio = BC002K14_A739MudanzaHoraServicio[0];
            n739MudanzaHoraServicio = BC002K14_n739MudanzaHoraServicio[0];
            A776MudanzaRgoHoraservicio = BC002K14_A776MudanzaRgoHoraservicio[0];
            n776MudanzaRgoHoraservicio = BC002K14_n776MudanzaRgoHoraservicio[0];
            A740MudanzaDireccionOrigen = BC002K14_A740MudanzaDireccionOrigen[0];
            A788MudanzaLocalidadOrigen = BC002K14_A788MudanzaLocalidadOrigen[0];
            A777MudanzaPisoDptoOrigen = BC002K14_A777MudanzaPisoDptoOrigen[0];
            A741MudanzaDireccionDestino = BC002K14_A741MudanzaDireccionDestino[0];
            A789MudanzaLocalidadDestino = BC002K14_A789MudanzaLocalidadDestino[0];
            A778MudanzaPisoDptoDestino = BC002K14_A778MudanzaPisoDptoDestino[0];
            A762MudanzaDistancia = BC002K14_A762MudanzaDistancia[0];
            A871MudanzaCoordenadaOrigen = BC002K14_A871MudanzaCoordenadaOrigen[0];
            A872MudanzaCoordenadaDestino = BC002K14_A872MudanzaCoordenadaDestino[0];
            A742MudanzaVehiculoSugerido = BC002K14_A742MudanzaVehiculoSugerido[0];
            A780MudanzaPrecioBasexHora = BC002K14_A780MudanzaPrecioBasexHora[0];
            A761MudanzaPeajeCantidad = BC002K14_A761MudanzaPeajeCantidad[0];
            A783MudanzaComentario = BC002K14_A783MudanzaComentario[0];
            A755TipoInmuebleOrigenNombre = BC002K14_A755TipoInmuebleOrigenNombre[0];
            A756TipoInmuebleOrigenValor = BC002K14_A756TipoInmuebleOrigenValor[0];
            A794MudanzaOrigenMetodo = BC002K14_A794MudanzaOrigenMetodo[0];
            A746TipoInmuebleDestinoNombre = BC002K14_A746TipoInmuebleDestinoNombre[0];
            A757TipoInmuebleDestinoValor = BC002K14_A757TipoInmuebleDestinoValor[0];
            A748TipoEstacionamOrigenNombre = BC002K14_A748TipoEstacionamOrigenNombre[0];
            A758TipoEstacionamOrigenValor = BC002K14_A758TipoEstacionamOrigenValor[0];
            A750TipoEstacionamDestinoNombre = BC002K14_A750TipoEstacionamDestinoNombre[0];
            A795MudanzaDestinoMetodo = BC002K14_A795MudanzaDestinoMetodo[0];
            A759TipoEstacionamDestinoValor = BC002K14_A759TipoEstacionamDestinoValor[0];
            A763MudanzaTiempoMaximo = BC002K14_A763MudanzaTiempoMaximo[0];
            A765MudanzaCargaVolumenEstimado = BC002K14_A765MudanzaCargaVolumenEstimado[0];
            A782MudanzaAdicionalPrecio = BC002K14_A782MudanzaAdicionalPrecio[0];
            A874MudanzaElevacion = BC002K14_A874MudanzaElevacion[0];
            A875MudanzaDescenso = BC002K14_A875MudanzaDescenso[0];
            A876MudanzaEmbalaje = BC002K14_A876MudanzaEmbalaje[0];
            A840MudanzaCantidadPeones = BC002K14_A840MudanzaCantidadPeones[0];
            A764MudanzaPrecioFinal = BC002K14_A764MudanzaPrecioFinal[0];
            A790MudanzaOperacionId = BC002K14_A790MudanzaOperacionId[0];
            A791MudanzaFormaPago = BC002K14_A791MudanzaFormaPago[0];
            A792MudanzaProveedorId = BC002K14_A792MudanzaProveedorId[0];
            A837MudanzaSecUserId = BC002K14_A837MudanzaSecUserId[0];
            A743TipoInmuebleOrigenId = BC002K14_A743TipoInmuebleOrigenId[0];
            A745TipoInmuebleDestinoId = BC002K14_A745TipoInmuebleDestinoId[0];
            A747TipoEstacionamOrigenId = BC002K14_A747TipoEstacionamOrigenId[0];
            A749TipoEstacionamDestinoId = BC002K14_A749TipoEstacionamDestinoId[0];
            ZM2K119( -11) ;
         }
         pr_default.close(12);
         OnLoadActions2K119( ) ;
      }

      protected void OnLoadActions2K119( )
      {
         AV138Pgmname = "Mudanza_BC";
      }

      protected void CheckExtendedTable2K119( )
      {
         standaloneModal( ) ;
         AV138Pgmname = "Mudanza_BC";
         if ( ! ( GxRegex.IsMatch(A785MudanzaMail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Mudanza Mail", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A737MudanzaFechaAlta) || ( DateTimeUtil.ResetTime ( A737MudanzaFechaAlta ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Mudanza Fecha Alta", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A873MudanzaFechaUpdate) || ( DateTimeUtil.ResetTime ( A873MudanzaFechaUpdate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Mudanza Fecha Update", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A738MudanzaFechaServicio) || ( DateTimeUtil.ResetTime ( A738MudanzaFechaServicio ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Mudanza Fecha Servicio", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC002K10 */
         pr_default.execute(8, new Object[] {A743TipoInmuebleOrigenId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo Inmueble Origen", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TIPOINMUEBLEORIGENID");
            AnyError = 1;
         }
         A755TipoInmuebleOrigenNombre = BC002K10_A755TipoInmuebleOrigenNombre[0];
         A756TipoInmuebleOrigenValor = BC002K10_A756TipoInmuebleOrigenValor[0];
         pr_default.close(8);
         /* Using cursor BC002K11 */
         pr_default.execute(9, new Object[] {A745TipoInmuebleDestinoId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo Inmueble Destino", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TIPOINMUEBLEDESTINOID");
            AnyError = 1;
         }
         A746TipoInmuebleDestinoNombre = BC002K11_A746TipoInmuebleDestinoNombre[0];
         A757TipoInmuebleDestinoValor = BC002K11_A757TipoInmuebleDestinoValor[0];
         pr_default.close(9);
         /* Using cursor BC002K12 */
         pr_default.execute(10, new Object[] {A747TipoEstacionamOrigenId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo Estacionam Origen", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TIPOESTACIONAMORIGENID");
            AnyError = 1;
         }
         A748TipoEstacionamOrigenNombre = BC002K12_A748TipoEstacionamOrigenNombre[0];
         A758TipoEstacionamOrigenValor = BC002K12_A758TipoEstacionamOrigenValor[0];
         pr_default.close(10);
         /* Using cursor BC002K13 */
         pr_default.execute(11, new Object[] {A749TipoEstacionamDestinoId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo Estacionam Destino", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TIPOESTACIONAMDESTINOID");
            AnyError = 1;
         }
         A750TipoEstacionamDestinoNombre = BC002K13_A750TipoEstacionamDestinoNombre[0];
         A759TipoEstacionamDestinoValor = BC002K13_A759TipoEstacionamDestinoValor[0];
         pr_default.close(11);
         if ( ! ( ( StringUtil.StrCmp(A791MudanzaFormaPago, "Sin_Asig") == 0 ) || ( StringUtil.StrCmp(A791MudanzaFormaPago, "Efectivo") == 0 ) || ( StringUtil.StrCmp(A791MudanzaFormaPago, "MercadoP") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Mudanza Forma Pago", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2K119( )
      {
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(10);
         pr_default.close(11);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2K119( )
      {
         /* Using cursor BC002K15 */
         pr_default.execute(13, new Object[] {n735MudanzaId, A735MudanzaId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound119 = 1;
         }
         else
         {
            RcdFound119 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002K9 */
         pr_default.execute(7, new Object[] {n735MudanzaId, A735MudanzaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            ZM2K119( 11) ;
            RcdFound119 = 1;
            A760MudanzaPeajevalor = BC002K9_A760MudanzaPeajevalor[0];
            A735MudanzaId = BC002K9_A735MudanzaId[0];
            n735MudanzaId = BC002K9_n735MudanzaId[0];
            A736MudanzaAsesor = BC002K9_A736MudanzaAsesor[0];
            A784MudanzaApellidoNombre = BC002K9_A784MudanzaApellidoNombre[0];
            A785MudanzaMail = BC002K9_A785MudanzaMail[0];
            A786MudanzaPhone = BC002K9_A786MudanzaPhone[0];
            A737MudanzaFechaAlta = BC002K9_A737MudanzaFechaAlta[0];
            A873MudanzaFechaUpdate = BC002K9_A873MudanzaFechaUpdate[0];
            A738MudanzaFechaServicio = BC002K9_A738MudanzaFechaServicio[0];
            A739MudanzaHoraServicio = BC002K9_A739MudanzaHoraServicio[0];
            n739MudanzaHoraServicio = BC002K9_n739MudanzaHoraServicio[0];
            A776MudanzaRgoHoraservicio = BC002K9_A776MudanzaRgoHoraservicio[0];
            n776MudanzaRgoHoraservicio = BC002K9_n776MudanzaRgoHoraservicio[0];
            A740MudanzaDireccionOrigen = BC002K9_A740MudanzaDireccionOrigen[0];
            A788MudanzaLocalidadOrigen = BC002K9_A788MudanzaLocalidadOrigen[0];
            A777MudanzaPisoDptoOrigen = BC002K9_A777MudanzaPisoDptoOrigen[0];
            A741MudanzaDireccionDestino = BC002K9_A741MudanzaDireccionDestino[0];
            A789MudanzaLocalidadDestino = BC002K9_A789MudanzaLocalidadDestino[0];
            A778MudanzaPisoDptoDestino = BC002K9_A778MudanzaPisoDptoDestino[0];
            A762MudanzaDistancia = BC002K9_A762MudanzaDistancia[0];
            A871MudanzaCoordenadaOrigen = BC002K9_A871MudanzaCoordenadaOrigen[0];
            A872MudanzaCoordenadaDestino = BC002K9_A872MudanzaCoordenadaDestino[0];
            A742MudanzaVehiculoSugerido = BC002K9_A742MudanzaVehiculoSugerido[0];
            A780MudanzaPrecioBasexHora = BC002K9_A780MudanzaPrecioBasexHora[0];
            A761MudanzaPeajeCantidad = BC002K9_A761MudanzaPeajeCantidad[0];
            A783MudanzaComentario = BC002K9_A783MudanzaComentario[0];
            A794MudanzaOrigenMetodo = BC002K9_A794MudanzaOrigenMetodo[0];
            A795MudanzaDestinoMetodo = BC002K9_A795MudanzaDestinoMetodo[0];
            A763MudanzaTiempoMaximo = BC002K9_A763MudanzaTiempoMaximo[0];
            A765MudanzaCargaVolumenEstimado = BC002K9_A765MudanzaCargaVolumenEstimado[0];
            A782MudanzaAdicionalPrecio = BC002K9_A782MudanzaAdicionalPrecio[0];
            A874MudanzaElevacion = BC002K9_A874MudanzaElevacion[0];
            A875MudanzaDescenso = BC002K9_A875MudanzaDescenso[0];
            A876MudanzaEmbalaje = BC002K9_A876MudanzaEmbalaje[0];
            A840MudanzaCantidadPeones = BC002K9_A840MudanzaCantidadPeones[0];
            A764MudanzaPrecioFinal = BC002K9_A764MudanzaPrecioFinal[0];
            A790MudanzaOperacionId = BC002K9_A790MudanzaOperacionId[0];
            A791MudanzaFormaPago = BC002K9_A791MudanzaFormaPago[0];
            A792MudanzaProveedorId = BC002K9_A792MudanzaProveedorId[0];
            A837MudanzaSecUserId = BC002K9_A837MudanzaSecUserId[0];
            A743TipoInmuebleOrigenId = BC002K9_A743TipoInmuebleOrigenId[0];
            A745TipoInmuebleDestinoId = BC002K9_A745TipoInmuebleDestinoId[0];
            A747TipoEstacionamOrigenId = BC002K9_A747TipoEstacionamOrigenId[0];
            A749TipoEstacionamDestinoId = BC002K9_A749TipoEstacionamDestinoId[0];
            Z735MudanzaId = A735MudanzaId;
            sMode119 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2K119( ) ;
            if ( AnyError == 1 )
            {
               RcdFound119 = 0;
               InitializeNonKey2K119( ) ;
            }
            Gx_mode = sMode119;
         }
         else
         {
            RcdFound119 = 0;
            InitializeNonKey2K119( ) ;
            sMode119 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode119;
         }
         pr_default.close(7);
      }

      protected void getEqualNoModal( )
      {
         GetKey2K119( ) ;
         if ( RcdFound119 == 0 )
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
         CONFIRM_2K0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2K119( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002K8 */
            pr_default.execute(6, new Object[] {n735MudanzaId, A735MudanzaId});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Mudanza"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(6) == 101) || ( Z760MudanzaPeajevalor != BC002K8_A760MudanzaPeajevalor[0] ) || ( StringUtil.StrCmp(Z736MudanzaAsesor, BC002K8_A736MudanzaAsesor[0]) != 0 ) || ( StringUtil.StrCmp(Z784MudanzaApellidoNombre, BC002K8_A784MudanzaApellidoNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z785MudanzaMail, BC002K8_A785MudanzaMail[0]) != 0 ) || ( StringUtil.StrCmp(Z786MudanzaPhone, BC002K8_A786MudanzaPhone[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z737MudanzaFechaAlta ) != DateTimeUtil.ResetTime ( BC002K8_A737MudanzaFechaAlta[0] ) ) || ( DateTimeUtil.ResetTime ( Z873MudanzaFechaUpdate ) != DateTimeUtil.ResetTime ( BC002K8_A873MudanzaFechaUpdate[0] ) ) || ( DateTimeUtil.ResetTime ( Z738MudanzaFechaServicio ) != DateTimeUtil.ResetTime ( BC002K8_A738MudanzaFechaServicio[0] ) ) || ( StringUtil.StrCmp(Z739MudanzaHoraServicio, BC002K8_A739MudanzaHoraServicio[0]) != 0 ) || ( StringUtil.StrCmp(Z776MudanzaRgoHoraservicio, BC002K8_A776MudanzaRgoHoraservicio[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z740MudanzaDireccionOrigen, BC002K8_A740MudanzaDireccionOrigen[0]) != 0 ) || ( StringUtil.StrCmp(Z788MudanzaLocalidadOrigen, BC002K8_A788MudanzaLocalidadOrigen[0]) != 0 ) || ( StringUtil.StrCmp(Z777MudanzaPisoDptoOrigen, BC002K8_A777MudanzaPisoDptoOrigen[0]) != 0 ) || ( StringUtil.StrCmp(Z741MudanzaDireccionDestino, BC002K8_A741MudanzaDireccionDestino[0]) != 0 ) || ( StringUtil.StrCmp(Z789MudanzaLocalidadDestino, BC002K8_A789MudanzaLocalidadDestino[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z778MudanzaPisoDptoDestino, BC002K8_A778MudanzaPisoDptoDestino[0]) != 0 ) || ( Z762MudanzaDistancia != BC002K8_A762MudanzaDistancia[0] ) || ( StringUtil.StrCmp(Z871MudanzaCoordenadaOrigen, BC002K8_A871MudanzaCoordenadaOrigen[0]) != 0 ) || ( StringUtil.StrCmp(Z872MudanzaCoordenadaDestino, BC002K8_A872MudanzaCoordenadaDestino[0]) != 0 ) || ( StringUtil.StrCmp(Z742MudanzaVehiculoSugerido, BC002K8_A742MudanzaVehiculoSugerido[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z780MudanzaPrecioBasexHora != BC002K8_A780MudanzaPrecioBasexHora[0] ) || ( Z761MudanzaPeajeCantidad != BC002K8_A761MudanzaPeajeCantidad[0] ) || ( StringUtil.StrCmp(Z783MudanzaComentario, BC002K8_A783MudanzaComentario[0]) != 0 ) || ( StringUtil.StrCmp(Z794MudanzaOrigenMetodo, BC002K8_A794MudanzaOrigenMetodo[0]) != 0 ) || ( StringUtil.StrCmp(Z795MudanzaDestinoMetodo, BC002K8_A795MudanzaDestinoMetodo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z763MudanzaTiempoMaximo != BC002K8_A763MudanzaTiempoMaximo[0] ) || ( Z765MudanzaCargaVolumenEstimado != BC002K8_A765MudanzaCargaVolumenEstimado[0] ) || ( Z782MudanzaAdicionalPrecio != BC002K8_A782MudanzaAdicionalPrecio[0] ) || ( Z874MudanzaElevacion != BC002K8_A874MudanzaElevacion[0] ) || ( Z875MudanzaDescenso != BC002K8_A875MudanzaDescenso[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z876MudanzaEmbalaje != BC002K8_A876MudanzaEmbalaje[0] ) || ( Z840MudanzaCantidadPeones != BC002K8_A840MudanzaCantidadPeones[0] ) || ( Z764MudanzaPrecioFinal != BC002K8_A764MudanzaPrecioFinal[0] ) || ( Z790MudanzaOperacionId != BC002K8_A790MudanzaOperacionId[0] ) || ( StringUtil.StrCmp(Z791MudanzaFormaPago, BC002K8_A791MudanzaFormaPago[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z792MudanzaProveedorId != BC002K8_A792MudanzaProveedorId[0] ) || ( Z837MudanzaSecUserId != BC002K8_A837MudanzaSecUserId[0] ) || ( Z743TipoInmuebleOrigenId != BC002K8_A743TipoInmuebleOrigenId[0] ) || ( Z745TipoInmuebleDestinoId != BC002K8_A745TipoInmuebleDestinoId[0] ) || ( Z747TipoEstacionamOrigenId != BC002K8_A747TipoEstacionamOrigenId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z749TipoEstacionamDestinoId != BC002K8_A749TipoEstacionamDestinoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Mudanza"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2K119( )
      {
         BeforeValidate2K119( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2K119( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2K119( 0) ;
            CheckOptimisticConcurrency2K119( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2K119( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2K119( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002K16 */
                     pr_default.execute(14, new Object[] {A760MudanzaPeajevalor, A736MudanzaAsesor, A784MudanzaApellidoNombre, A785MudanzaMail, A786MudanzaPhone, A737MudanzaFechaAlta, A873MudanzaFechaUpdate, A738MudanzaFechaServicio, n739MudanzaHoraServicio, A739MudanzaHoraServicio, n776MudanzaRgoHoraservicio, A776MudanzaRgoHoraservicio, A740MudanzaDireccionOrigen, A788MudanzaLocalidadOrigen, A777MudanzaPisoDptoOrigen, A741MudanzaDireccionDestino, A789MudanzaLocalidadDestino, A778MudanzaPisoDptoDestino, A762MudanzaDistancia, A871MudanzaCoordenadaOrigen, A872MudanzaCoordenadaDestino, A742MudanzaVehiculoSugerido, A780MudanzaPrecioBasexHora, A761MudanzaPeajeCantidad, A783MudanzaComentario, A794MudanzaOrigenMetodo, A795MudanzaDestinoMetodo, A763MudanzaTiempoMaximo, A765MudanzaCargaVolumenEstimado, A782MudanzaAdicionalPrecio, A874MudanzaElevacion, A875MudanzaDescenso, A876MudanzaEmbalaje, A840MudanzaCantidadPeones, A764MudanzaPrecioFinal, A790MudanzaOperacionId, A791MudanzaFormaPago, A792MudanzaProveedorId, A837MudanzaSecUserId, A743TipoInmuebleOrigenId, A745TipoInmuebleDestinoId, A747TipoEstacionamOrigenId, A749TipoEstacionamDestinoId});
                     A735MudanzaId = BC002K16_A735MudanzaId[0];
                     n735MudanzaId = BC002K16_n735MudanzaId[0];
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Mudanza");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2K119( ) ;
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
               Load2K119( ) ;
            }
            EndLevel2K119( ) ;
         }
         CloseExtendedTableCursors2K119( ) ;
      }

      protected void Update2K119( )
      {
         BeforeValidate2K119( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2K119( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2K119( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2K119( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2K119( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002K17 */
                     pr_default.execute(15, new Object[] {A760MudanzaPeajevalor, A736MudanzaAsesor, A784MudanzaApellidoNombre, A785MudanzaMail, A786MudanzaPhone, A737MudanzaFechaAlta, A873MudanzaFechaUpdate, A738MudanzaFechaServicio, n739MudanzaHoraServicio, A739MudanzaHoraServicio, n776MudanzaRgoHoraservicio, A776MudanzaRgoHoraservicio, A740MudanzaDireccionOrigen, A788MudanzaLocalidadOrigen, A777MudanzaPisoDptoOrigen, A741MudanzaDireccionDestino, A789MudanzaLocalidadDestino, A778MudanzaPisoDptoDestino, A762MudanzaDistancia, A871MudanzaCoordenadaOrigen, A872MudanzaCoordenadaDestino, A742MudanzaVehiculoSugerido, A780MudanzaPrecioBasexHora, A761MudanzaPeajeCantidad, A783MudanzaComentario, A794MudanzaOrigenMetodo, A795MudanzaDestinoMetodo, A763MudanzaTiempoMaximo, A765MudanzaCargaVolumenEstimado, A782MudanzaAdicionalPrecio, A874MudanzaElevacion, A875MudanzaDescenso, A876MudanzaEmbalaje, A840MudanzaCantidadPeones, A764MudanzaPrecioFinal, A790MudanzaOperacionId, A791MudanzaFormaPago, A792MudanzaProveedorId, A837MudanzaSecUserId, A743TipoInmuebleOrigenId, A745TipoInmuebleDestinoId, A747TipoEstacionamOrigenId, A749TipoEstacionamDestinoId, n735MudanzaId, A735MudanzaId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Mudanza");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Mudanza"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2K119( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2K119( ) ;
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
            EndLevel2K119( ) ;
         }
         CloseExtendedTableCursors2K119( ) ;
      }

      protected void DeferredUpdate2K119( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2K119( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2K119( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2K119( ) ;
            AfterConfirm2K119( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2K119( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart2K121( ) ;
                  while ( RcdFound121 != 0 )
                  {
                     getByPrimaryKey2K121( ) ;
                     Delete2K121( ) ;
                     ScanKeyNext2K121( ) ;
                  }
                  ScanKeyEnd2K121( ) ;
                  ScanKeyStart2K120( ) ;
                  while ( RcdFound120 != 0 )
                  {
                     getByPrimaryKey2K120( ) ;
                     Delete2K120( ) ;
                     ScanKeyNext2K120( ) ;
                  }
                  ScanKeyEnd2K120( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002K18 */
                     pr_default.execute(16, new Object[] {n735MudanzaId, A735MudanzaId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Mudanza");
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
         sMode119 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2K119( ) ;
         Gx_mode = sMode119;
      }

      protected void OnDeleteControls2K119( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV138Pgmname = "Mudanza_BC";
            /* Using cursor BC002K19 */
            pr_default.execute(17, new Object[] {A743TipoInmuebleOrigenId});
            A755TipoInmuebleOrigenNombre = BC002K19_A755TipoInmuebleOrigenNombre[0];
            A756TipoInmuebleOrigenValor = BC002K19_A756TipoInmuebleOrigenValor[0];
            pr_default.close(17);
            /* Using cursor BC002K20 */
            pr_default.execute(18, new Object[] {A745TipoInmuebleDestinoId});
            A746TipoInmuebleDestinoNombre = BC002K20_A746TipoInmuebleDestinoNombre[0];
            A757TipoInmuebleDestinoValor = BC002K20_A757TipoInmuebleDestinoValor[0];
            pr_default.close(18);
            /* Using cursor BC002K21 */
            pr_default.execute(19, new Object[] {A747TipoEstacionamOrigenId});
            A748TipoEstacionamOrigenNombre = BC002K21_A748TipoEstacionamOrigenNombre[0];
            A758TipoEstacionamOrigenValor = BC002K21_A758TipoEstacionamOrigenValor[0];
            pr_default.close(19);
            /* Using cursor BC002K22 */
            pr_default.execute(20, new Object[] {A749TipoEstacionamDestinoId});
            A750TipoEstacionamDestinoNombre = BC002K22_A750TipoEstacionamDestinoNombre[0];
            A759TipoEstacionamDestinoValor = BC002K22_A759TipoEstacionamDestinoValor[0];
            pr_default.close(20);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC002K23 */
            pr_default.execute(21, new Object[] {n735MudanzaId, A735MudanzaId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
         }
      }

      protected void ProcessNestedLevel2K120( )
      {
         nGXsfl_120_idx = 0;
         while ( nGXsfl_120_idx < bcMudanza.gxTpr_Carga.Count )
         {
            ReadRow2K120( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound120 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_120 != 0 ) )
            {
               standaloneNotModal2K120( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert2K120( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete2K120( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update2K120( ) ;
                  }
               }
            }
            KeyVarsToRow120( ((SdtMudanza_Carga)bcMudanza.gxTpr_Carga.Item(nGXsfl_120_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_120_idx = 0;
            while ( nGXsfl_120_idx < bcMudanza.gxTpr_Carga.Count )
            {
               ReadRow2K120( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound120 == 0 )
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
                  bcMudanza.gxTpr_Carga.RemoveElement(nGXsfl_120_idx);
                  nGXsfl_120_idx = (int)(nGXsfl_120_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey2K120( ) ;
                  VarsToRow120( ((SdtMudanza_Carga)bcMudanza.gxTpr_Carga.Item(nGXsfl_120_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll2K120( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_120 = 0;
         nIsMod_120 = 0;
      }

      protected void ProcessNestedLevel2K121( )
      {
         nGXsfl_121_idx = 0;
         while ( nGXsfl_121_idx < bcMudanza.gxTpr_Adicional.Count )
         {
            ReadRow2K121( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound121 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_121 != 0 ) )
            {
               standaloneNotModal2K121( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert2K121( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete2K121( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update2K121( ) ;
                  }
               }
            }
            KeyVarsToRow121( ((SdtMudanza_Adicional)bcMudanza.gxTpr_Adicional.Item(nGXsfl_121_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_121_idx = 0;
            while ( nGXsfl_121_idx < bcMudanza.gxTpr_Adicional.Count )
            {
               ReadRow2K121( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound121 == 0 )
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
                  bcMudanza.gxTpr_Adicional.RemoveElement(nGXsfl_121_idx);
                  nGXsfl_121_idx = (int)(nGXsfl_121_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey2K121( ) ;
                  VarsToRow121( ((SdtMudanza_Adicional)bcMudanza.gxTpr_Adicional.Item(nGXsfl_121_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll2K121( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_121 = 0;
         nIsMod_121 = 0;
      }

      protected void ProcessLevel2K119( )
      {
         /* Save parent mode. */
         sMode119 = Gx_mode;
         ProcessNestedLevel2K120( ) ;
         ProcessNestedLevel2K121( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode119;
         /* ' Update level parameters */
      }

      protected void EndLevel2K119( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(6);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2K119( ) ;
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

      public void ScanKeyStart2K119( )
      {
         /* Scan By routine */
         /* Using cursor BC002K24 */
         pr_default.execute(22, new Object[] {n735MudanzaId, A735MudanzaId});
         RcdFound119 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound119 = 1;
            A760MudanzaPeajevalor = BC002K24_A760MudanzaPeajevalor[0];
            A735MudanzaId = BC002K24_A735MudanzaId[0];
            n735MudanzaId = BC002K24_n735MudanzaId[0];
            A736MudanzaAsesor = BC002K24_A736MudanzaAsesor[0];
            A784MudanzaApellidoNombre = BC002K24_A784MudanzaApellidoNombre[0];
            A785MudanzaMail = BC002K24_A785MudanzaMail[0];
            A786MudanzaPhone = BC002K24_A786MudanzaPhone[0];
            A737MudanzaFechaAlta = BC002K24_A737MudanzaFechaAlta[0];
            A873MudanzaFechaUpdate = BC002K24_A873MudanzaFechaUpdate[0];
            A738MudanzaFechaServicio = BC002K24_A738MudanzaFechaServicio[0];
            A739MudanzaHoraServicio = BC002K24_A739MudanzaHoraServicio[0];
            n739MudanzaHoraServicio = BC002K24_n739MudanzaHoraServicio[0];
            A776MudanzaRgoHoraservicio = BC002K24_A776MudanzaRgoHoraservicio[0];
            n776MudanzaRgoHoraservicio = BC002K24_n776MudanzaRgoHoraservicio[0];
            A740MudanzaDireccionOrigen = BC002K24_A740MudanzaDireccionOrigen[0];
            A788MudanzaLocalidadOrigen = BC002K24_A788MudanzaLocalidadOrigen[0];
            A777MudanzaPisoDptoOrigen = BC002K24_A777MudanzaPisoDptoOrigen[0];
            A741MudanzaDireccionDestino = BC002K24_A741MudanzaDireccionDestino[0];
            A789MudanzaLocalidadDestino = BC002K24_A789MudanzaLocalidadDestino[0];
            A778MudanzaPisoDptoDestino = BC002K24_A778MudanzaPisoDptoDestino[0];
            A762MudanzaDistancia = BC002K24_A762MudanzaDistancia[0];
            A871MudanzaCoordenadaOrigen = BC002K24_A871MudanzaCoordenadaOrigen[0];
            A872MudanzaCoordenadaDestino = BC002K24_A872MudanzaCoordenadaDestino[0];
            A742MudanzaVehiculoSugerido = BC002K24_A742MudanzaVehiculoSugerido[0];
            A780MudanzaPrecioBasexHora = BC002K24_A780MudanzaPrecioBasexHora[0];
            A761MudanzaPeajeCantidad = BC002K24_A761MudanzaPeajeCantidad[0];
            A783MudanzaComentario = BC002K24_A783MudanzaComentario[0];
            A755TipoInmuebleOrigenNombre = BC002K24_A755TipoInmuebleOrigenNombre[0];
            A756TipoInmuebleOrigenValor = BC002K24_A756TipoInmuebleOrigenValor[0];
            A794MudanzaOrigenMetodo = BC002K24_A794MudanzaOrigenMetodo[0];
            A746TipoInmuebleDestinoNombre = BC002K24_A746TipoInmuebleDestinoNombre[0];
            A757TipoInmuebleDestinoValor = BC002K24_A757TipoInmuebleDestinoValor[0];
            A748TipoEstacionamOrigenNombre = BC002K24_A748TipoEstacionamOrigenNombre[0];
            A758TipoEstacionamOrigenValor = BC002K24_A758TipoEstacionamOrigenValor[0];
            A750TipoEstacionamDestinoNombre = BC002K24_A750TipoEstacionamDestinoNombre[0];
            A795MudanzaDestinoMetodo = BC002K24_A795MudanzaDestinoMetodo[0];
            A759TipoEstacionamDestinoValor = BC002K24_A759TipoEstacionamDestinoValor[0];
            A763MudanzaTiempoMaximo = BC002K24_A763MudanzaTiempoMaximo[0];
            A765MudanzaCargaVolumenEstimado = BC002K24_A765MudanzaCargaVolumenEstimado[0];
            A782MudanzaAdicionalPrecio = BC002K24_A782MudanzaAdicionalPrecio[0];
            A874MudanzaElevacion = BC002K24_A874MudanzaElevacion[0];
            A875MudanzaDescenso = BC002K24_A875MudanzaDescenso[0];
            A876MudanzaEmbalaje = BC002K24_A876MudanzaEmbalaje[0];
            A840MudanzaCantidadPeones = BC002K24_A840MudanzaCantidadPeones[0];
            A764MudanzaPrecioFinal = BC002K24_A764MudanzaPrecioFinal[0];
            A790MudanzaOperacionId = BC002K24_A790MudanzaOperacionId[0];
            A791MudanzaFormaPago = BC002K24_A791MudanzaFormaPago[0];
            A792MudanzaProveedorId = BC002K24_A792MudanzaProveedorId[0];
            A837MudanzaSecUserId = BC002K24_A837MudanzaSecUserId[0];
            A743TipoInmuebleOrigenId = BC002K24_A743TipoInmuebleOrigenId[0];
            A745TipoInmuebleDestinoId = BC002K24_A745TipoInmuebleDestinoId[0];
            A747TipoEstacionamOrigenId = BC002K24_A747TipoEstacionamOrigenId[0];
            A749TipoEstacionamDestinoId = BC002K24_A749TipoEstacionamDestinoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2K119( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound119 = 0;
         ScanKeyLoad2K119( ) ;
      }

      protected void ScanKeyLoad2K119( )
      {
         sMode119 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound119 = 1;
            A760MudanzaPeajevalor = BC002K24_A760MudanzaPeajevalor[0];
            A735MudanzaId = BC002K24_A735MudanzaId[0];
            n735MudanzaId = BC002K24_n735MudanzaId[0];
            A736MudanzaAsesor = BC002K24_A736MudanzaAsesor[0];
            A784MudanzaApellidoNombre = BC002K24_A784MudanzaApellidoNombre[0];
            A785MudanzaMail = BC002K24_A785MudanzaMail[0];
            A786MudanzaPhone = BC002K24_A786MudanzaPhone[0];
            A737MudanzaFechaAlta = BC002K24_A737MudanzaFechaAlta[0];
            A873MudanzaFechaUpdate = BC002K24_A873MudanzaFechaUpdate[0];
            A738MudanzaFechaServicio = BC002K24_A738MudanzaFechaServicio[0];
            A739MudanzaHoraServicio = BC002K24_A739MudanzaHoraServicio[0];
            n739MudanzaHoraServicio = BC002K24_n739MudanzaHoraServicio[0];
            A776MudanzaRgoHoraservicio = BC002K24_A776MudanzaRgoHoraservicio[0];
            n776MudanzaRgoHoraservicio = BC002K24_n776MudanzaRgoHoraservicio[0];
            A740MudanzaDireccionOrigen = BC002K24_A740MudanzaDireccionOrigen[0];
            A788MudanzaLocalidadOrigen = BC002K24_A788MudanzaLocalidadOrigen[0];
            A777MudanzaPisoDptoOrigen = BC002K24_A777MudanzaPisoDptoOrigen[0];
            A741MudanzaDireccionDestino = BC002K24_A741MudanzaDireccionDestino[0];
            A789MudanzaLocalidadDestino = BC002K24_A789MudanzaLocalidadDestino[0];
            A778MudanzaPisoDptoDestino = BC002K24_A778MudanzaPisoDptoDestino[0];
            A762MudanzaDistancia = BC002K24_A762MudanzaDistancia[0];
            A871MudanzaCoordenadaOrigen = BC002K24_A871MudanzaCoordenadaOrigen[0];
            A872MudanzaCoordenadaDestino = BC002K24_A872MudanzaCoordenadaDestino[0];
            A742MudanzaVehiculoSugerido = BC002K24_A742MudanzaVehiculoSugerido[0];
            A780MudanzaPrecioBasexHora = BC002K24_A780MudanzaPrecioBasexHora[0];
            A761MudanzaPeajeCantidad = BC002K24_A761MudanzaPeajeCantidad[0];
            A783MudanzaComentario = BC002K24_A783MudanzaComentario[0];
            A755TipoInmuebleOrigenNombre = BC002K24_A755TipoInmuebleOrigenNombre[0];
            A756TipoInmuebleOrigenValor = BC002K24_A756TipoInmuebleOrigenValor[0];
            A794MudanzaOrigenMetodo = BC002K24_A794MudanzaOrigenMetodo[0];
            A746TipoInmuebleDestinoNombre = BC002K24_A746TipoInmuebleDestinoNombre[0];
            A757TipoInmuebleDestinoValor = BC002K24_A757TipoInmuebleDestinoValor[0];
            A748TipoEstacionamOrigenNombre = BC002K24_A748TipoEstacionamOrigenNombre[0];
            A758TipoEstacionamOrigenValor = BC002K24_A758TipoEstacionamOrigenValor[0];
            A750TipoEstacionamDestinoNombre = BC002K24_A750TipoEstacionamDestinoNombre[0];
            A795MudanzaDestinoMetodo = BC002K24_A795MudanzaDestinoMetodo[0];
            A759TipoEstacionamDestinoValor = BC002K24_A759TipoEstacionamDestinoValor[0];
            A763MudanzaTiempoMaximo = BC002K24_A763MudanzaTiempoMaximo[0];
            A765MudanzaCargaVolumenEstimado = BC002K24_A765MudanzaCargaVolumenEstimado[0];
            A782MudanzaAdicionalPrecio = BC002K24_A782MudanzaAdicionalPrecio[0];
            A874MudanzaElevacion = BC002K24_A874MudanzaElevacion[0];
            A875MudanzaDescenso = BC002K24_A875MudanzaDescenso[0];
            A876MudanzaEmbalaje = BC002K24_A876MudanzaEmbalaje[0];
            A840MudanzaCantidadPeones = BC002K24_A840MudanzaCantidadPeones[0];
            A764MudanzaPrecioFinal = BC002K24_A764MudanzaPrecioFinal[0];
            A790MudanzaOperacionId = BC002K24_A790MudanzaOperacionId[0];
            A791MudanzaFormaPago = BC002K24_A791MudanzaFormaPago[0];
            A792MudanzaProveedorId = BC002K24_A792MudanzaProveedorId[0];
            A837MudanzaSecUserId = BC002K24_A837MudanzaSecUserId[0];
            A743TipoInmuebleOrigenId = BC002K24_A743TipoInmuebleOrigenId[0];
            A745TipoInmuebleDestinoId = BC002K24_A745TipoInmuebleDestinoId[0];
            A747TipoEstacionamOrigenId = BC002K24_A747TipoEstacionamOrigenId[0];
            A749TipoEstacionamDestinoId = BC002K24_A749TipoEstacionamDestinoId[0];
         }
         Gx_mode = sMode119;
      }

      protected void ScanKeyEnd2K119( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm2K119( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2K119( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2K119( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2K119( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2K119( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2K119( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2K119( )
      {
      }

      protected void ZM2K120( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z753ItemCargaCantidad = A753ItemCargaCantidad;
            Z813ItemCargaEmbCant = A813ItemCargaEmbCant;
            Z815ItemCargaEmbalaje = A815ItemCargaEmbalaje;
            Z814ItemCargaElevCant = A814ItemCargaElevCant;
            Z816ItemCargaElevacion = A816ItemCargaElevacion;
            Z779ItemCargaVolumenCalculado = A779ItemCargaVolumenCalculado;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z752ItemCargaNombre = A752ItemCargaNombre;
            Z841ItemCargaDescripcion = A841ItemCargaDescripcion;
            Z754ItemCargaVolumen = A754ItemCargaVolumen;
            Z779ItemCargaVolumenCalculado = A779ItemCargaVolumenCalculado;
         }
         if ( GX_JID == -16 )
         {
            Z735MudanzaId = A735MudanzaId;
            Z753ItemCargaCantidad = A753ItemCargaCantidad;
            Z813ItemCargaEmbCant = A813ItemCargaEmbCant;
            Z815ItemCargaEmbalaje = A815ItemCargaEmbalaje;
            Z814ItemCargaElevCant = A814ItemCargaElevCant;
            Z816ItemCargaElevacion = A816ItemCargaElevacion;
            Z751ItemCargaId = A751ItemCargaId;
            Z752ItemCargaNombre = A752ItemCargaNombre;
            Z841ItemCargaDescripcion = A841ItemCargaDescripcion;
            Z754ItemCargaVolumen = A754ItemCargaVolumen;
         }
      }

      protected void standaloneNotModal2K120( )
      {
      }

      protected void standaloneModal2K120( )
      {
      }

      protected void Load2K120( )
      {
         /* Using cursor BC002K25 */
         pr_default.execute(23, new Object[] {n735MudanzaId, A735MudanzaId, A751ItemCargaId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound120 = 1;
            A752ItemCargaNombre = BC002K25_A752ItemCargaNombre[0];
            A841ItemCargaDescripcion = BC002K25_A841ItemCargaDescripcion[0];
            A753ItemCargaCantidad = BC002K25_A753ItemCargaCantidad[0];
            A813ItemCargaEmbCant = BC002K25_A813ItemCargaEmbCant[0];
            n813ItemCargaEmbCant = BC002K25_n813ItemCargaEmbCant[0];
            A815ItemCargaEmbalaje = BC002K25_A815ItemCargaEmbalaje[0];
            A814ItemCargaElevCant = BC002K25_A814ItemCargaElevCant[0];
            n814ItemCargaElevCant = BC002K25_n814ItemCargaElevCant[0];
            A816ItemCargaElevacion = BC002K25_A816ItemCargaElevacion[0];
            A754ItemCargaVolumen = BC002K25_A754ItemCargaVolumen[0];
            ZM2K120( -16) ;
         }
         pr_default.close(23);
         OnLoadActions2K120( ) ;
      }

      protected void OnLoadActions2K120( )
      {
         A779ItemCargaVolumenCalculado = (decimal)(A753ItemCargaCantidad*A754ItemCargaVolumen);
      }

      protected void CheckExtendedTable2K120( )
      {
         Gx_BScreen = 1;
         standaloneModal2K120( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC002K7 */
         pr_default.execute(5, new Object[] {A751ItemCargaId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Item Carga", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ITEMCARGAID");
            AnyError = 1;
         }
         A752ItemCargaNombre = BC002K7_A752ItemCargaNombre[0];
         A841ItemCargaDescripcion = BC002K7_A841ItemCargaDescripcion[0];
         A754ItemCargaVolumen = BC002K7_A754ItemCargaVolumen[0];
         pr_default.close(5);
         A779ItemCargaVolumenCalculado = (decimal)(A753ItemCargaCantidad*A754ItemCargaVolumen);
      }

      protected void CloseExtendedTableCursors2K120( )
      {
         pr_default.close(5);
      }

      protected void enableDisable2K120( )
      {
      }

      protected void GetKey2K120( )
      {
         /* Using cursor BC002K26 */
         pr_default.execute(24, new Object[] {n735MudanzaId, A735MudanzaId, A751ItemCargaId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound120 = 1;
         }
         else
         {
            RcdFound120 = 0;
         }
         pr_default.close(24);
      }

      protected void getByPrimaryKey2K120( )
      {
         /* Using cursor BC002K6 */
         pr_default.execute(4, new Object[] {n735MudanzaId, A735MudanzaId, A751ItemCargaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM2K120( 16) ;
            RcdFound120 = 1;
            InitializeNonKey2K120( ) ;
            A753ItemCargaCantidad = BC002K6_A753ItemCargaCantidad[0];
            A813ItemCargaEmbCant = BC002K6_A813ItemCargaEmbCant[0];
            n813ItemCargaEmbCant = BC002K6_n813ItemCargaEmbCant[0];
            A815ItemCargaEmbalaje = BC002K6_A815ItemCargaEmbalaje[0];
            A814ItemCargaElevCant = BC002K6_A814ItemCargaElevCant[0];
            n814ItemCargaElevCant = BC002K6_n814ItemCargaElevCant[0];
            A816ItemCargaElevacion = BC002K6_A816ItemCargaElevacion[0];
            A751ItemCargaId = BC002K6_A751ItemCargaId[0];
            Z735MudanzaId = A735MudanzaId;
            Z751ItemCargaId = A751ItemCargaId;
            sMode120 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal2K120( ) ;
            Load2K120( ) ;
            Gx_mode = sMode120;
         }
         else
         {
            RcdFound120 = 0;
            InitializeNonKey2K120( ) ;
            sMode120 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal2K120( ) ;
            Gx_mode = sMode120;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes2K120( ) ;
         }
         pr_default.close(4);
      }

      protected void CheckOptimisticConcurrency2K120( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002K5 */
            pr_default.execute(3, new Object[] {n735MudanzaId, A735MudanzaId, A751ItemCargaId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MudanzaCarga"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( Z753ItemCargaCantidad != BC002K5_A753ItemCargaCantidad[0] ) || ( Z813ItemCargaEmbCant != BC002K5_A813ItemCargaEmbCant[0] ) || ( Z815ItemCargaEmbalaje != BC002K5_A815ItemCargaEmbalaje[0] ) || ( Z814ItemCargaElevCant != BC002K5_A814ItemCargaElevCant[0] ) || ( Z816ItemCargaElevacion != BC002K5_A816ItemCargaElevacion[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"MudanzaCarga"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2K120( )
      {
         BeforeValidate2K120( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2K120( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2K120( 0) ;
            CheckOptimisticConcurrency2K120( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2K120( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2K120( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002K27 */
                     pr_default.execute(25, new Object[] {n735MudanzaId, A735MudanzaId, A753ItemCargaCantidad, n813ItemCargaEmbCant, A813ItemCargaEmbCant, A815ItemCargaEmbalaje, n814ItemCargaElevCant, A814ItemCargaElevCant, A816ItemCargaElevacion, A751ItemCargaId});
                     pr_default.close(25);
                     pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
                     if ( (pr_default.getStatus(25) == 1) )
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
               Load2K120( ) ;
            }
            EndLevel2K120( ) ;
         }
         CloseExtendedTableCursors2K120( ) ;
      }

      protected void Update2K120( )
      {
         BeforeValidate2K120( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2K120( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2K120( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2K120( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2K120( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002K28 */
                     pr_default.execute(26, new Object[] {A753ItemCargaCantidad, n813ItemCargaEmbCant, A813ItemCargaEmbCant, A815ItemCargaEmbalaje, n814ItemCargaElevCant, A814ItemCargaElevCant, A816ItemCargaElevacion, n735MudanzaId, A735MudanzaId, A751ItemCargaId});
                     pr_default.close(26);
                     pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
                     if ( (pr_default.getStatus(26) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MudanzaCarga"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2K120( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey2K120( ) ;
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
            EndLevel2K120( ) ;
         }
         CloseExtendedTableCursors2K120( ) ;
      }

      protected void DeferredUpdate2K120( )
      {
      }

      protected void Delete2K120( )
      {
         Gx_mode = "DLT";
         BeforeValidate2K120( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2K120( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2K120( ) ;
            AfterConfirm2K120( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2K120( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002K29 */
                  pr_default.execute(27, new Object[] {n735MudanzaId, A735MudanzaId, A751ItemCargaId});
                  pr_default.close(27);
                  pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
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
         sMode120 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2K120( ) ;
         Gx_mode = sMode120;
      }

      protected void OnDeleteControls2K120( )
      {
         standaloneModal2K120( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC002K30 */
            pr_default.execute(28, new Object[] {A751ItemCargaId});
            A752ItemCargaNombre = BC002K30_A752ItemCargaNombre[0];
            A841ItemCargaDescripcion = BC002K30_A841ItemCargaDescripcion[0];
            A754ItemCargaVolumen = BC002K30_A754ItemCargaVolumen[0];
            pr_default.close(28);
            A779ItemCargaVolumenCalculado = (decimal)(A753ItemCargaCantidad*A754ItemCargaVolumen);
         }
      }

      protected void EndLevel2K120( )
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

      public void ScanKeyStart2K120( )
      {
         /* Scan By routine */
         /* Using cursor BC002K31 */
         pr_default.execute(29, new Object[] {n735MudanzaId, A735MudanzaId});
         RcdFound120 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound120 = 1;
            A752ItemCargaNombre = BC002K31_A752ItemCargaNombre[0];
            A841ItemCargaDescripcion = BC002K31_A841ItemCargaDescripcion[0];
            A753ItemCargaCantidad = BC002K31_A753ItemCargaCantidad[0];
            A813ItemCargaEmbCant = BC002K31_A813ItemCargaEmbCant[0];
            n813ItemCargaEmbCant = BC002K31_n813ItemCargaEmbCant[0];
            A815ItemCargaEmbalaje = BC002K31_A815ItemCargaEmbalaje[0];
            A814ItemCargaElevCant = BC002K31_A814ItemCargaElevCant[0];
            n814ItemCargaElevCant = BC002K31_n814ItemCargaElevCant[0];
            A816ItemCargaElevacion = BC002K31_A816ItemCargaElevacion[0];
            A754ItemCargaVolumen = BC002K31_A754ItemCargaVolumen[0];
            A751ItemCargaId = BC002K31_A751ItemCargaId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2K120( )
      {
         /* Scan next routine */
         pr_default.readNext(29);
         RcdFound120 = 0;
         ScanKeyLoad2K120( ) ;
      }

      protected void ScanKeyLoad2K120( )
      {
         sMode120 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound120 = 1;
            A752ItemCargaNombre = BC002K31_A752ItemCargaNombre[0];
            A841ItemCargaDescripcion = BC002K31_A841ItemCargaDescripcion[0];
            A753ItemCargaCantidad = BC002K31_A753ItemCargaCantidad[0];
            A813ItemCargaEmbCant = BC002K31_A813ItemCargaEmbCant[0];
            n813ItemCargaEmbCant = BC002K31_n813ItemCargaEmbCant[0];
            A815ItemCargaEmbalaje = BC002K31_A815ItemCargaEmbalaje[0];
            A814ItemCargaElevCant = BC002K31_A814ItemCargaElevCant[0];
            n814ItemCargaElevCant = BC002K31_n814ItemCargaElevCant[0];
            A816ItemCargaElevacion = BC002K31_A816ItemCargaElevacion[0];
            A754ItemCargaVolumen = BC002K31_A754ItemCargaVolumen[0];
            A751ItemCargaId = BC002K31_A751ItemCargaId[0];
         }
         Gx_mode = sMode120;
      }

      protected void ScanKeyEnd2K120( )
      {
         pr_default.close(29);
      }

      protected void AfterConfirm2K120( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2K120( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2K120( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2K120( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2K120( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2K120( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2K120( )
      {
      }

      protected void send_integrity_lvl_hashes2K120( )
      {
      }

      protected void ZM2K121( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z768ItemAdicionalCantidad = A768ItemAdicionalCantidad;
            Z781ItemAdicionalValorCalculado = A781ItemAdicionalValorCalculado;
         }
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            Z767ItemAdicionalNombre = A767ItemAdicionalNombre;
            Z769ItemAdicionalValor = A769ItemAdicionalValor;
            Z781ItemAdicionalValorCalculado = A781ItemAdicionalValorCalculado;
         }
         if ( GX_JID == -18 )
         {
            Z735MudanzaId = A735MudanzaId;
            Z768ItemAdicionalCantidad = A768ItemAdicionalCantidad;
            Z766ItemAdicionalId = A766ItemAdicionalId;
            Z767ItemAdicionalNombre = A767ItemAdicionalNombre;
            Z769ItemAdicionalValor = A769ItemAdicionalValor;
         }
      }

      protected void standaloneNotModal2K121( )
      {
      }

      protected void standaloneModal2K121( )
      {
      }

      protected void Load2K121( )
      {
         /* Using cursor BC002K32 */
         pr_default.execute(30, new Object[] {n735MudanzaId, A735MudanzaId, A766ItemAdicionalId});
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound121 = 1;
            A767ItemAdicionalNombre = BC002K32_A767ItemAdicionalNombre[0];
            A768ItemAdicionalCantidad = BC002K32_A768ItemAdicionalCantidad[0];
            A769ItemAdicionalValor = BC002K32_A769ItemAdicionalValor[0];
            ZM2K121( -18) ;
         }
         pr_default.close(30);
         OnLoadActions2K121( ) ;
      }

      protected void OnLoadActions2K121( )
      {
         A781ItemAdicionalValorCalculado = (short)(A768ItemAdicionalCantidad*A769ItemAdicionalValor);
      }

      protected void CheckExtendedTable2K121( )
      {
         Gx_BScreen = 1;
         standaloneModal2K121( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC002K4 */
         pr_default.execute(2, new Object[] {A766ItemAdicionalId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Item Adicional", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ITEMADICIONALID");
            AnyError = 1;
         }
         A767ItemAdicionalNombre = BC002K4_A767ItemAdicionalNombre[0];
         A769ItemAdicionalValor = BC002K4_A769ItemAdicionalValor[0];
         pr_default.close(2);
         A781ItemAdicionalValorCalculado = (short)(A768ItemAdicionalCantidad*A769ItemAdicionalValor);
      }

      protected void CloseExtendedTableCursors2K121( )
      {
         pr_default.close(2);
      }

      protected void enableDisable2K121( )
      {
      }

      protected void GetKey2K121( )
      {
         /* Using cursor BC002K33 */
         pr_default.execute(31, new Object[] {n735MudanzaId, A735MudanzaId, A766ItemAdicionalId});
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound121 = 1;
         }
         else
         {
            RcdFound121 = 0;
         }
         pr_default.close(31);
      }

      protected void getByPrimaryKey2K121( )
      {
         /* Using cursor BC002K3 */
         pr_default.execute(1, new Object[] {n735MudanzaId, A735MudanzaId, A766ItemAdicionalId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2K121( 18) ;
            RcdFound121 = 1;
            InitializeNonKey2K121( ) ;
            A768ItemAdicionalCantidad = BC002K3_A768ItemAdicionalCantidad[0];
            A766ItemAdicionalId = BC002K3_A766ItemAdicionalId[0];
            Z735MudanzaId = A735MudanzaId;
            Z766ItemAdicionalId = A766ItemAdicionalId;
            sMode121 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal2K121( ) ;
            Load2K121( ) ;
            Gx_mode = sMode121;
         }
         else
         {
            RcdFound121 = 0;
            InitializeNonKey2K121( ) ;
            sMode121 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal2K121( ) ;
            Gx_mode = sMode121;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes2K121( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency2K121( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002K2 */
            pr_default.execute(0, new Object[] {n735MudanzaId, A735MudanzaId, A766ItemAdicionalId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MudanzaAdicional"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z768ItemAdicionalCantidad != BC002K2_A768ItemAdicionalCantidad[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"MudanzaAdicional"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2K121( )
      {
         BeforeValidate2K121( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2K121( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2K121( 0) ;
            CheckOptimisticConcurrency2K121( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2K121( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2K121( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002K34 */
                     pr_default.execute(32, new Object[] {n735MudanzaId, A735MudanzaId, A768ItemAdicionalCantidad, A766ItemAdicionalId});
                     pr_default.close(32);
                     pr_default.SmartCacheProvider.SetUpdated("MudanzaAdicional");
                     if ( (pr_default.getStatus(32) == 1) )
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
               Load2K121( ) ;
            }
            EndLevel2K121( ) ;
         }
         CloseExtendedTableCursors2K121( ) ;
      }

      protected void Update2K121( )
      {
         BeforeValidate2K121( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2K121( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2K121( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2K121( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2K121( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002K35 */
                     pr_default.execute(33, new Object[] {A768ItemAdicionalCantidad, n735MudanzaId, A735MudanzaId, A766ItemAdicionalId});
                     pr_default.close(33);
                     pr_default.SmartCacheProvider.SetUpdated("MudanzaAdicional");
                     if ( (pr_default.getStatus(33) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MudanzaAdicional"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2K121( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey2K121( ) ;
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
            EndLevel2K121( ) ;
         }
         CloseExtendedTableCursors2K121( ) ;
      }

      protected void DeferredUpdate2K121( )
      {
      }

      protected void Delete2K121( )
      {
         Gx_mode = "DLT";
         BeforeValidate2K121( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2K121( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2K121( ) ;
            AfterConfirm2K121( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2K121( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002K36 */
                  pr_default.execute(34, new Object[] {n735MudanzaId, A735MudanzaId, A766ItemAdicionalId});
                  pr_default.close(34);
                  pr_default.SmartCacheProvider.SetUpdated("MudanzaAdicional");
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
         sMode121 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2K121( ) ;
         Gx_mode = sMode121;
      }

      protected void OnDeleteControls2K121( )
      {
         standaloneModal2K121( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC002K37 */
            pr_default.execute(35, new Object[] {A766ItemAdicionalId});
            A767ItemAdicionalNombre = BC002K37_A767ItemAdicionalNombre[0];
            A769ItemAdicionalValor = BC002K37_A769ItemAdicionalValor[0];
            pr_default.close(35);
            A781ItemAdicionalValorCalculado = (short)(A768ItemAdicionalCantidad*A769ItemAdicionalValor);
         }
      }

      protected void EndLevel2K121( )
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

      public void ScanKeyStart2K121( )
      {
         /* Scan By routine */
         /* Using cursor BC002K38 */
         pr_default.execute(36, new Object[] {n735MudanzaId, A735MudanzaId});
         RcdFound121 = 0;
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound121 = 1;
            A767ItemAdicionalNombre = BC002K38_A767ItemAdicionalNombre[0];
            A768ItemAdicionalCantidad = BC002K38_A768ItemAdicionalCantidad[0];
            A769ItemAdicionalValor = BC002K38_A769ItemAdicionalValor[0];
            A766ItemAdicionalId = BC002K38_A766ItemAdicionalId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2K121( )
      {
         /* Scan next routine */
         pr_default.readNext(36);
         RcdFound121 = 0;
         ScanKeyLoad2K121( ) ;
      }

      protected void ScanKeyLoad2K121( )
      {
         sMode121 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound121 = 1;
            A767ItemAdicionalNombre = BC002K38_A767ItemAdicionalNombre[0];
            A768ItemAdicionalCantidad = BC002K38_A768ItemAdicionalCantidad[0];
            A769ItemAdicionalValor = BC002K38_A769ItemAdicionalValor[0];
            A766ItemAdicionalId = BC002K38_A766ItemAdicionalId[0];
         }
         Gx_mode = sMode121;
      }

      protected void ScanKeyEnd2K121( )
      {
         pr_default.close(36);
      }

      protected void AfterConfirm2K121( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2K121( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2K121( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2K121( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2K121( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2K121( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2K121( )
      {
      }

      protected void send_integrity_lvl_hashes2K121( )
      {
      }

      protected void send_integrity_lvl_hashes2K119( )
      {
      }

      protected void AddRow2K119( )
      {
         VarsToRow119( bcMudanza) ;
      }

      protected void ReadRow2K119( )
      {
         RowToVars119( bcMudanza, 1) ;
      }

      protected void AddRow2K120( )
      {
         SdtMudanza_Carga obj120;
         obj120 = new SdtMudanza_Carga(context);
         VarsToRow120( obj120) ;
         bcMudanza.gxTpr_Carga.Add(obj120, 0);
         obj120.gxTpr_Mode = "UPD";
         obj120.gxTpr_Modified = 0;
      }

      protected void ReadRow2K120( )
      {
         nGXsfl_120_idx = (int)(nGXsfl_120_idx+1);
         RowToVars120( ((SdtMudanza_Carga)bcMudanza.gxTpr_Carga.Item(nGXsfl_120_idx)), 1) ;
      }

      protected void AddRow2K121( )
      {
         SdtMudanza_Adicional obj121;
         obj121 = new SdtMudanza_Adicional(context);
         VarsToRow121( obj121) ;
         bcMudanza.gxTpr_Adicional.Add(obj121, 0);
         obj121.gxTpr_Mode = "UPD";
         obj121.gxTpr_Modified = 0;
      }

      protected void ReadRow2K121( )
      {
         nGXsfl_121_idx = (int)(nGXsfl_121_idx+1);
         RowToVars121( ((SdtMudanza_Adicional)bcMudanza.gxTpr_Adicional.Item(nGXsfl_121_idx)), 1) ;
      }

      protected void InitializeNonKey2K119( )
      {
         A736MudanzaAsesor = "";
         A784MudanzaApellidoNombre = "";
         A785MudanzaMail = "";
         A786MudanzaPhone = "";
         A737MudanzaFechaAlta = DateTime.MinValue;
         A873MudanzaFechaUpdate = DateTime.MinValue;
         A738MudanzaFechaServicio = DateTime.MinValue;
         A739MudanzaHoraServicio = "";
         n739MudanzaHoraServicio = false;
         A776MudanzaRgoHoraservicio = "";
         n776MudanzaRgoHoraservicio = false;
         A740MudanzaDireccionOrigen = "";
         A788MudanzaLocalidadOrigen = "";
         A777MudanzaPisoDptoOrigen = "";
         A741MudanzaDireccionDestino = "";
         A789MudanzaLocalidadDestino = "";
         A778MudanzaPisoDptoDestino = "";
         A762MudanzaDistancia = 0;
         A871MudanzaCoordenadaOrigen = "";
         A872MudanzaCoordenadaDestino = "";
         A742MudanzaVehiculoSugerido = "";
         A780MudanzaPrecioBasexHora = 0;
         A761MudanzaPeajeCantidad = 0;
         A783MudanzaComentario = "";
         A760MudanzaPeajevalor = 0;
         A743TipoInmuebleOrigenId = 0;
         A755TipoInmuebleOrigenNombre = "";
         A756TipoInmuebleOrigenValor = 0;
         A794MudanzaOrigenMetodo = "";
         A745TipoInmuebleDestinoId = 0;
         A746TipoInmuebleDestinoNombre = "";
         A757TipoInmuebleDestinoValor = 0;
         A747TipoEstacionamOrigenId = 0;
         A748TipoEstacionamOrigenNombre = "";
         A758TipoEstacionamOrigenValor = 0;
         A749TipoEstacionamDestinoId = 0;
         A750TipoEstacionamDestinoNombre = "";
         A795MudanzaDestinoMetodo = "";
         A759TipoEstacionamDestinoValor = 0;
         A763MudanzaTiempoMaximo = 0;
         A765MudanzaCargaVolumenEstimado = 0;
         A782MudanzaAdicionalPrecio = 0;
         A874MudanzaElevacion = 0;
         A875MudanzaDescenso = 0;
         A876MudanzaEmbalaje = 0;
         A840MudanzaCantidadPeones = 0;
         A764MudanzaPrecioFinal = 0;
         A790MudanzaOperacionId = 0;
         A791MudanzaFormaPago = "";
         A792MudanzaProveedorId = 0;
         A837MudanzaSecUserId = 0;
         Z760MudanzaPeajevalor = 0;
         Z736MudanzaAsesor = "";
         Z784MudanzaApellidoNombre = "";
         Z785MudanzaMail = "";
         Z786MudanzaPhone = "";
         Z737MudanzaFechaAlta = DateTime.MinValue;
         Z873MudanzaFechaUpdate = DateTime.MinValue;
         Z738MudanzaFechaServicio = DateTime.MinValue;
         Z739MudanzaHoraServicio = "";
         Z776MudanzaRgoHoraservicio = "";
         Z740MudanzaDireccionOrigen = "";
         Z788MudanzaLocalidadOrigen = "";
         Z777MudanzaPisoDptoOrigen = "";
         Z741MudanzaDireccionDestino = "";
         Z789MudanzaLocalidadDestino = "";
         Z778MudanzaPisoDptoDestino = "";
         Z762MudanzaDistancia = 0;
         Z871MudanzaCoordenadaOrigen = "";
         Z872MudanzaCoordenadaDestino = "";
         Z742MudanzaVehiculoSugerido = "";
         Z780MudanzaPrecioBasexHora = 0;
         Z761MudanzaPeajeCantidad = 0;
         Z783MudanzaComentario = "";
         Z794MudanzaOrigenMetodo = "";
         Z795MudanzaDestinoMetodo = "";
         Z763MudanzaTiempoMaximo = 0;
         Z765MudanzaCargaVolumenEstimado = 0;
         Z782MudanzaAdicionalPrecio = 0;
         Z874MudanzaElevacion = 0;
         Z875MudanzaDescenso = 0;
         Z876MudanzaEmbalaje = 0;
         Z840MudanzaCantidadPeones = 0;
         Z764MudanzaPrecioFinal = 0;
         Z790MudanzaOperacionId = 0;
         Z791MudanzaFormaPago = "";
         Z792MudanzaProveedorId = 0;
         Z837MudanzaSecUserId = 0;
         Z743TipoInmuebleOrigenId = 0;
         Z745TipoInmuebleDestinoId = 0;
         Z747TipoEstacionamOrigenId = 0;
         Z749TipoEstacionamDestinoId = 0;
      }

      protected void InitAll2K119( )
      {
         A735MudanzaId = 0;
         n735MudanzaId = false;
         InitializeNonKey2K119( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A760MudanzaPeajevalor = i760MudanzaPeajevalor;
      }

      protected void InitializeNonKey2K120( )
      {
         A779ItemCargaVolumenCalculado = 0;
         A752ItemCargaNombre = "";
         A841ItemCargaDescripcion = "";
         A753ItemCargaCantidad = 0;
         A813ItemCargaEmbCant = 0;
         n813ItemCargaEmbCant = false;
         A815ItemCargaEmbalaje = false;
         A814ItemCargaElevCant = 0;
         n814ItemCargaElevCant = false;
         A816ItemCargaElevacion = false;
         A754ItemCargaVolumen = 0;
         Z753ItemCargaCantidad = 0;
         Z813ItemCargaEmbCant = 0;
         Z815ItemCargaEmbalaje = false;
         Z814ItemCargaElevCant = 0;
         Z816ItemCargaElevacion = false;
      }

      protected void InitAll2K120( )
      {
         A751ItemCargaId = 0;
         InitializeNonKey2K120( ) ;
      }

      protected void StandaloneModalInsert2K120( )
      {
      }

      protected void InitializeNonKey2K121( )
      {
         A781ItemAdicionalValorCalculado = 0;
         A767ItemAdicionalNombre = "";
         A768ItemAdicionalCantidad = 0;
         A769ItemAdicionalValor = 0;
         Z768ItemAdicionalCantidad = 0;
      }

      protected void InitAll2K121( )
      {
         A766ItemAdicionalId = 0;
         InitializeNonKey2K121( ) ;
      }

      protected void StandaloneModalInsert2K121( )
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

      public void VarsToRow119( SdtMudanza obj119 )
      {
         obj119.gxTpr_Mode = Gx_mode;
         obj119.gxTpr_Mudanzaasesor = A736MudanzaAsesor;
         obj119.gxTpr_Mudanzaapellidonombre = A784MudanzaApellidoNombre;
         obj119.gxTpr_Mudanzamail = A785MudanzaMail;
         obj119.gxTpr_Mudanzaphone = A786MudanzaPhone;
         obj119.gxTpr_Mudanzafechaalta = A737MudanzaFechaAlta;
         obj119.gxTpr_Mudanzafechaupdate = A873MudanzaFechaUpdate;
         obj119.gxTpr_Mudanzafechaservicio = A738MudanzaFechaServicio;
         obj119.gxTpr_Mudanzahoraservicio = A739MudanzaHoraServicio;
         obj119.gxTpr_Mudanzargohoraservicio = A776MudanzaRgoHoraservicio;
         obj119.gxTpr_Mudanzadireccionorigen = A740MudanzaDireccionOrigen;
         obj119.gxTpr_Mudanzalocalidadorigen = A788MudanzaLocalidadOrigen;
         obj119.gxTpr_Mudanzapisodptoorigen = A777MudanzaPisoDptoOrigen;
         obj119.gxTpr_Mudanzadirecciondestino = A741MudanzaDireccionDestino;
         obj119.gxTpr_Mudanzalocalidaddestino = A789MudanzaLocalidadDestino;
         obj119.gxTpr_Mudanzapisodptodestino = A778MudanzaPisoDptoDestino;
         obj119.gxTpr_Mudanzadistancia = A762MudanzaDistancia;
         obj119.gxTpr_Mudanzacoordenadaorigen = A871MudanzaCoordenadaOrigen;
         obj119.gxTpr_Mudanzacoordenadadestino = A872MudanzaCoordenadaDestino;
         obj119.gxTpr_Mudanzavehiculosugerido = A742MudanzaVehiculoSugerido;
         obj119.gxTpr_Mudanzapreciobasexhora = A780MudanzaPrecioBasexHora;
         obj119.gxTpr_Mudanzapeajecantidad = A761MudanzaPeajeCantidad;
         obj119.gxTpr_Mudanzacomentario = A783MudanzaComentario;
         obj119.gxTpr_Mudanzapeajevalor = A760MudanzaPeajevalor;
         obj119.gxTpr_Tipoinmuebleorigenid = A743TipoInmuebleOrigenId;
         obj119.gxTpr_Tipoinmuebleorigennombre = A755TipoInmuebleOrigenNombre;
         obj119.gxTpr_Tipoinmuebleorigenvalor = A756TipoInmuebleOrigenValor;
         obj119.gxTpr_Mudanzaorigenmetodo = A794MudanzaOrigenMetodo;
         obj119.gxTpr_Tipoinmuebledestinoid = A745TipoInmuebleDestinoId;
         obj119.gxTpr_Tipoinmuebledestinonombre = A746TipoInmuebleDestinoNombre;
         obj119.gxTpr_Tipoinmuebledestinovalor = A757TipoInmuebleDestinoValor;
         obj119.gxTpr_Tipoestacionamorigenid = A747TipoEstacionamOrigenId;
         obj119.gxTpr_Tipoestacionamorigennombre = A748TipoEstacionamOrigenNombre;
         obj119.gxTpr_Tipoestacionamorigenvalor = A758TipoEstacionamOrigenValor;
         obj119.gxTpr_Tipoestacionamdestinoid = A749TipoEstacionamDestinoId;
         obj119.gxTpr_Tipoestacionamdestinonombre = A750TipoEstacionamDestinoNombre;
         obj119.gxTpr_Mudanzadestinometodo = A795MudanzaDestinoMetodo;
         obj119.gxTpr_Tipoestacionamdestinovalor = A759TipoEstacionamDestinoValor;
         obj119.gxTpr_Mudanzatiempomaximo = A763MudanzaTiempoMaximo;
         obj119.gxTpr_Mudanzacargavolumenestimado = A765MudanzaCargaVolumenEstimado;
         obj119.gxTpr_Mudanzaadicionalprecio = A782MudanzaAdicionalPrecio;
         obj119.gxTpr_Mudanzaelevacion = A874MudanzaElevacion;
         obj119.gxTpr_Mudanzadescenso = A875MudanzaDescenso;
         obj119.gxTpr_Mudanzaembalaje = A876MudanzaEmbalaje;
         obj119.gxTpr_Mudanzacantidadpeones = A840MudanzaCantidadPeones;
         obj119.gxTpr_Mudanzapreciofinal = A764MudanzaPrecioFinal;
         obj119.gxTpr_Mudanzaoperacionid = A790MudanzaOperacionId;
         obj119.gxTpr_Mudanzaformapago = A791MudanzaFormaPago;
         obj119.gxTpr_Mudanzaproveedorid = A792MudanzaProveedorId;
         obj119.gxTpr_Mudanzasecuserid = A837MudanzaSecUserId;
         obj119.gxTpr_Mudanzaid = A735MudanzaId;
         obj119.gxTpr_Mudanzaid_Z = Z735MudanzaId;
         obj119.gxTpr_Mudanzaasesor_Z = Z736MudanzaAsesor;
         obj119.gxTpr_Mudanzaapellidonombre_Z = Z784MudanzaApellidoNombre;
         obj119.gxTpr_Mudanzamail_Z = Z785MudanzaMail;
         obj119.gxTpr_Mudanzaphone_Z = Z786MudanzaPhone;
         obj119.gxTpr_Mudanzafechaalta_Z = Z737MudanzaFechaAlta;
         obj119.gxTpr_Mudanzafechaupdate_Z = Z873MudanzaFechaUpdate;
         obj119.gxTpr_Mudanzafechaservicio_Z = Z738MudanzaFechaServicio;
         obj119.gxTpr_Mudanzahoraservicio_Z = Z739MudanzaHoraServicio;
         obj119.gxTpr_Mudanzargohoraservicio_Z = Z776MudanzaRgoHoraservicio;
         obj119.gxTpr_Mudanzadireccionorigen_Z = Z740MudanzaDireccionOrigen;
         obj119.gxTpr_Mudanzalocalidadorigen_Z = Z788MudanzaLocalidadOrigen;
         obj119.gxTpr_Mudanzapisodptoorigen_Z = Z777MudanzaPisoDptoOrigen;
         obj119.gxTpr_Mudanzadirecciondestino_Z = Z741MudanzaDireccionDestino;
         obj119.gxTpr_Mudanzalocalidaddestino_Z = Z789MudanzaLocalidadDestino;
         obj119.gxTpr_Mudanzapisodptodestino_Z = Z778MudanzaPisoDptoDestino;
         obj119.gxTpr_Mudanzadistancia_Z = Z762MudanzaDistancia;
         obj119.gxTpr_Mudanzacoordenadaorigen_Z = Z871MudanzaCoordenadaOrigen;
         obj119.gxTpr_Mudanzacoordenadadestino_Z = Z872MudanzaCoordenadaDestino;
         obj119.gxTpr_Mudanzavehiculosugerido_Z = Z742MudanzaVehiculoSugerido;
         obj119.gxTpr_Mudanzapreciobasexhora_Z = Z780MudanzaPrecioBasexHora;
         obj119.gxTpr_Mudanzapeajecantidad_Z = Z761MudanzaPeajeCantidad;
         obj119.gxTpr_Mudanzacomentario_Z = Z783MudanzaComentario;
         obj119.gxTpr_Mudanzapeajevalor_Z = Z760MudanzaPeajevalor;
         obj119.gxTpr_Tipoinmuebleorigenid_Z = Z743TipoInmuebleOrigenId;
         obj119.gxTpr_Tipoinmuebleorigennombre_Z = Z755TipoInmuebleOrigenNombre;
         obj119.gxTpr_Tipoinmuebleorigenvalor_Z = Z756TipoInmuebleOrigenValor;
         obj119.gxTpr_Mudanzaorigenmetodo_Z = Z794MudanzaOrigenMetodo;
         obj119.gxTpr_Tipoinmuebledestinoid_Z = Z745TipoInmuebleDestinoId;
         obj119.gxTpr_Tipoinmuebledestinonombre_Z = Z746TipoInmuebleDestinoNombre;
         obj119.gxTpr_Tipoinmuebledestinovalor_Z = Z757TipoInmuebleDestinoValor;
         obj119.gxTpr_Tipoestacionamorigenid_Z = Z747TipoEstacionamOrigenId;
         obj119.gxTpr_Tipoestacionamorigennombre_Z = Z748TipoEstacionamOrigenNombre;
         obj119.gxTpr_Tipoestacionamorigenvalor_Z = Z758TipoEstacionamOrigenValor;
         obj119.gxTpr_Tipoestacionamdestinoid_Z = Z749TipoEstacionamDestinoId;
         obj119.gxTpr_Tipoestacionamdestinonombre_Z = Z750TipoEstacionamDestinoNombre;
         obj119.gxTpr_Mudanzadestinometodo_Z = Z795MudanzaDestinoMetodo;
         obj119.gxTpr_Tipoestacionamdestinovalor_Z = Z759TipoEstacionamDestinoValor;
         obj119.gxTpr_Mudanzatiempomaximo_Z = Z763MudanzaTiempoMaximo;
         obj119.gxTpr_Mudanzacargavolumenestimado_Z = Z765MudanzaCargaVolumenEstimado;
         obj119.gxTpr_Mudanzaadicionalprecio_Z = Z782MudanzaAdicionalPrecio;
         obj119.gxTpr_Mudanzaelevacion_Z = Z874MudanzaElevacion;
         obj119.gxTpr_Mudanzadescenso_Z = Z875MudanzaDescenso;
         obj119.gxTpr_Mudanzaembalaje_Z = Z876MudanzaEmbalaje;
         obj119.gxTpr_Mudanzacantidadpeones_Z = Z840MudanzaCantidadPeones;
         obj119.gxTpr_Mudanzapreciofinal_Z = Z764MudanzaPrecioFinal;
         obj119.gxTpr_Mudanzaoperacionid_Z = Z790MudanzaOperacionId;
         obj119.gxTpr_Mudanzaformapago_Z = Z791MudanzaFormaPago;
         obj119.gxTpr_Mudanzaproveedorid_Z = Z792MudanzaProveedorId;
         obj119.gxTpr_Mudanzasecuserid_Z = Z837MudanzaSecUserId;
         obj119.gxTpr_Mudanzaid_N = (short)(Convert.ToInt16(n735MudanzaId));
         obj119.gxTpr_Mudanzahoraservicio_N = (short)(Convert.ToInt16(n739MudanzaHoraServicio));
         obj119.gxTpr_Mudanzargohoraservicio_N = (short)(Convert.ToInt16(n776MudanzaRgoHoraservicio));
         obj119.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow119( SdtMudanza obj119 )
      {
         obj119.gxTpr_Mudanzaid = A735MudanzaId;
         return  ;
      }

      public void RowToVars119( SdtMudanza obj119 ,
                                int forceLoad )
      {
         Gx_mode = obj119.gxTpr_Mode;
         A736MudanzaAsesor = obj119.gxTpr_Mudanzaasesor;
         A784MudanzaApellidoNombre = obj119.gxTpr_Mudanzaapellidonombre;
         A785MudanzaMail = obj119.gxTpr_Mudanzamail;
         A786MudanzaPhone = obj119.gxTpr_Mudanzaphone;
         A737MudanzaFechaAlta = obj119.gxTpr_Mudanzafechaalta;
         A873MudanzaFechaUpdate = obj119.gxTpr_Mudanzafechaupdate;
         A738MudanzaFechaServicio = obj119.gxTpr_Mudanzafechaservicio;
         A739MudanzaHoraServicio = obj119.gxTpr_Mudanzahoraservicio;
         n739MudanzaHoraServicio = false;
         A776MudanzaRgoHoraservicio = obj119.gxTpr_Mudanzargohoraservicio;
         n776MudanzaRgoHoraservicio = false;
         A740MudanzaDireccionOrigen = obj119.gxTpr_Mudanzadireccionorigen;
         A788MudanzaLocalidadOrigen = obj119.gxTpr_Mudanzalocalidadorigen;
         A777MudanzaPisoDptoOrigen = obj119.gxTpr_Mudanzapisodptoorigen;
         A741MudanzaDireccionDestino = obj119.gxTpr_Mudanzadirecciondestino;
         A789MudanzaLocalidadDestino = obj119.gxTpr_Mudanzalocalidaddestino;
         A778MudanzaPisoDptoDestino = obj119.gxTpr_Mudanzapisodptodestino;
         A762MudanzaDistancia = obj119.gxTpr_Mudanzadistancia;
         A871MudanzaCoordenadaOrigen = obj119.gxTpr_Mudanzacoordenadaorigen;
         A872MudanzaCoordenadaDestino = obj119.gxTpr_Mudanzacoordenadadestino;
         A742MudanzaVehiculoSugerido = obj119.gxTpr_Mudanzavehiculosugerido;
         A780MudanzaPrecioBasexHora = obj119.gxTpr_Mudanzapreciobasexhora;
         A761MudanzaPeajeCantidad = obj119.gxTpr_Mudanzapeajecantidad;
         A783MudanzaComentario = obj119.gxTpr_Mudanzacomentario;
         A760MudanzaPeajevalor = obj119.gxTpr_Mudanzapeajevalor;
         A743TipoInmuebleOrigenId = obj119.gxTpr_Tipoinmuebleorigenid;
         A755TipoInmuebleOrigenNombre = obj119.gxTpr_Tipoinmuebleorigennombre;
         A756TipoInmuebleOrigenValor = obj119.gxTpr_Tipoinmuebleorigenvalor;
         A794MudanzaOrigenMetodo = obj119.gxTpr_Mudanzaorigenmetodo;
         A745TipoInmuebleDestinoId = obj119.gxTpr_Tipoinmuebledestinoid;
         A746TipoInmuebleDestinoNombre = obj119.gxTpr_Tipoinmuebledestinonombre;
         A757TipoInmuebleDestinoValor = obj119.gxTpr_Tipoinmuebledestinovalor;
         A747TipoEstacionamOrigenId = obj119.gxTpr_Tipoestacionamorigenid;
         A748TipoEstacionamOrigenNombre = obj119.gxTpr_Tipoestacionamorigennombre;
         A758TipoEstacionamOrigenValor = obj119.gxTpr_Tipoestacionamorigenvalor;
         A749TipoEstacionamDestinoId = obj119.gxTpr_Tipoestacionamdestinoid;
         A750TipoEstacionamDestinoNombre = obj119.gxTpr_Tipoestacionamdestinonombre;
         A795MudanzaDestinoMetodo = obj119.gxTpr_Mudanzadestinometodo;
         A759TipoEstacionamDestinoValor = obj119.gxTpr_Tipoestacionamdestinovalor;
         A763MudanzaTiempoMaximo = obj119.gxTpr_Mudanzatiempomaximo;
         A765MudanzaCargaVolumenEstimado = obj119.gxTpr_Mudanzacargavolumenestimado;
         A782MudanzaAdicionalPrecio = obj119.gxTpr_Mudanzaadicionalprecio;
         A874MudanzaElevacion = obj119.gxTpr_Mudanzaelevacion;
         A875MudanzaDescenso = obj119.gxTpr_Mudanzadescenso;
         A876MudanzaEmbalaje = obj119.gxTpr_Mudanzaembalaje;
         A840MudanzaCantidadPeones = obj119.gxTpr_Mudanzacantidadpeones;
         A764MudanzaPrecioFinal = obj119.gxTpr_Mudanzapreciofinal;
         A790MudanzaOperacionId = obj119.gxTpr_Mudanzaoperacionid;
         A791MudanzaFormaPago = obj119.gxTpr_Mudanzaformapago;
         A792MudanzaProveedorId = obj119.gxTpr_Mudanzaproveedorid;
         A837MudanzaSecUserId = obj119.gxTpr_Mudanzasecuserid;
         A735MudanzaId = obj119.gxTpr_Mudanzaid;
         n735MudanzaId = false;
         Z735MudanzaId = obj119.gxTpr_Mudanzaid_Z;
         Z736MudanzaAsesor = obj119.gxTpr_Mudanzaasesor_Z;
         Z784MudanzaApellidoNombre = obj119.gxTpr_Mudanzaapellidonombre_Z;
         Z785MudanzaMail = obj119.gxTpr_Mudanzamail_Z;
         Z786MudanzaPhone = obj119.gxTpr_Mudanzaphone_Z;
         Z737MudanzaFechaAlta = obj119.gxTpr_Mudanzafechaalta_Z;
         Z873MudanzaFechaUpdate = obj119.gxTpr_Mudanzafechaupdate_Z;
         Z738MudanzaFechaServicio = obj119.gxTpr_Mudanzafechaservicio_Z;
         Z739MudanzaHoraServicio = obj119.gxTpr_Mudanzahoraservicio_Z;
         Z776MudanzaRgoHoraservicio = obj119.gxTpr_Mudanzargohoraservicio_Z;
         Z740MudanzaDireccionOrigen = obj119.gxTpr_Mudanzadireccionorigen_Z;
         Z788MudanzaLocalidadOrigen = obj119.gxTpr_Mudanzalocalidadorigen_Z;
         Z777MudanzaPisoDptoOrigen = obj119.gxTpr_Mudanzapisodptoorigen_Z;
         Z741MudanzaDireccionDestino = obj119.gxTpr_Mudanzadirecciondestino_Z;
         Z789MudanzaLocalidadDestino = obj119.gxTpr_Mudanzalocalidaddestino_Z;
         Z778MudanzaPisoDptoDestino = obj119.gxTpr_Mudanzapisodptodestino_Z;
         Z762MudanzaDistancia = obj119.gxTpr_Mudanzadistancia_Z;
         Z871MudanzaCoordenadaOrigen = obj119.gxTpr_Mudanzacoordenadaorigen_Z;
         Z872MudanzaCoordenadaDestino = obj119.gxTpr_Mudanzacoordenadadestino_Z;
         Z742MudanzaVehiculoSugerido = obj119.gxTpr_Mudanzavehiculosugerido_Z;
         Z780MudanzaPrecioBasexHora = obj119.gxTpr_Mudanzapreciobasexhora_Z;
         Z761MudanzaPeajeCantidad = obj119.gxTpr_Mudanzapeajecantidad_Z;
         Z783MudanzaComentario = obj119.gxTpr_Mudanzacomentario_Z;
         Z760MudanzaPeajevalor = obj119.gxTpr_Mudanzapeajevalor_Z;
         Z743TipoInmuebleOrigenId = obj119.gxTpr_Tipoinmuebleorigenid_Z;
         Z755TipoInmuebleOrigenNombre = obj119.gxTpr_Tipoinmuebleorigennombre_Z;
         Z756TipoInmuebleOrigenValor = obj119.gxTpr_Tipoinmuebleorigenvalor_Z;
         Z794MudanzaOrigenMetodo = obj119.gxTpr_Mudanzaorigenmetodo_Z;
         Z745TipoInmuebleDestinoId = obj119.gxTpr_Tipoinmuebledestinoid_Z;
         Z746TipoInmuebleDestinoNombre = obj119.gxTpr_Tipoinmuebledestinonombre_Z;
         Z757TipoInmuebleDestinoValor = obj119.gxTpr_Tipoinmuebledestinovalor_Z;
         Z747TipoEstacionamOrigenId = obj119.gxTpr_Tipoestacionamorigenid_Z;
         Z748TipoEstacionamOrigenNombre = obj119.gxTpr_Tipoestacionamorigennombre_Z;
         Z758TipoEstacionamOrigenValor = obj119.gxTpr_Tipoestacionamorigenvalor_Z;
         Z749TipoEstacionamDestinoId = obj119.gxTpr_Tipoestacionamdestinoid_Z;
         Z750TipoEstacionamDestinoNombre = obj119.gxTpr_Tipoestacionamdestinonombre_Z;
         Z795MudanzaDestinoMetodo = obj119.gxTpr_Mudanzadestinometodo_Z;
         Z759TipoEstacionamDestinoValor = obj119.gxTpr_Tipoestacionamdestinovalor_Z;
         Z763MudanzaTiempoMaximo = obj119.gxTpr_Mudanzatiempomaximo_Z;
         Z765MudanzaCargaVolumenEstimado = obj119.gxTpr_Mudanzacargavolumenestimado_Z;
         Z782MudanzaAdicionalPrecio = obj119.gxTpr_Mudanzaadicionalprecio_Z;
         Z874MudanzaElevacion = obj119.gxTpr_Mudanzaelevacion_Z;
         Z875MudanzaDescenso = obj119.gxTpr_Mudanzadescenso_Z;
         Z876MudanzaEmbalaje = obj119.gxTpr_Mudanzaembalaje_Z;
         Z840MudanzaCantidadPeones = obj119.gxTpr_Mudanzacantidadpeones_Z;
         Z764MudanzaPrecioFinal = obj119.gxTpr_Mudanzapreciofinal_Z;
         Z790MudanzaOperacionId = obj119.gxTpr_Mudanzaoperacionid_Z;
         Z791MudanzaFormaPago = obj119.gxTpr_Mudanzaformapago_Z;
         Z792MudanzaProveedorId = obj119.gxTpr_Mudanzaproveedorid_Z;
         Z837MudanzaSecUserId = obj119.gxTpr_Mudanzasecuserid_Z;
         n735MudanzaId = (bool)(Convert.ToBoolean(obj119.gxTpr_Mudanzaid_N));
         n739MudanzaHoraServicio = (bool)(Convert.ToBoolean(obj119.gxTpr_Mudanzahoraservicio_N));
         n776MudanzaRgoHoraservicio = (bool)(Convert.ToBoolean(obj119.gxTpr_Mudanzargohoraservicio_N));
         Gx_mode = obj119.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow120( SdtMudanza_Carga obj120 )
      {
         obj120.gxTpr_Mode = Gx_mode;
         obj120.gxTpr_Itemcargavolumencalculado = A779ItemCargaVolumenCalculado;
         obj120.gxTpr_Itemcarganombre = A752ItemCargaNombre;
         obj120.gxTpr_Itemcargadescripcion = A841ItemCargaDescripcion;
         obj120.gxTpr_Itemcargacantidad = A753ItemCargaCantidad;
         obj120.gxTpr_Itemcargaembcant = A813ItemCargaEmbCant;
         obj120.gxTpr_Itemcargaembalaje = A815ItemCargaEmbalaje;
         obj120.gxTpr_Itemcargaelevcant = A814ItemCargaElevCant;
         obj120.gxTpr_Itemcargaelevacion = A816ItemCargaElevacion;
         obj120.gxTpr_Itemcargavolumen = A754ItemCargaVolumen;
         obj120.gxTpr_Itemcargaid = A751ItemCargaId;
         obj120.gxTpr_Itemcargaid_Z = Z751ItemCargaId;
         obj120.gxTpr_Itemcarganombre_Z = Z752ItemCargaNombre;
         obj120.gxTpr_Itemcargadescripcion_Z = Z841ItemCargaDescripcion;
         obj120.gxTpr_Itemcargacantidad_Z = Z753ItemCargaCantidad;
         obj120.gxTpr_Itemcargaembcant_Z = Z813ItemCargaEmbCant;
         obj120.gxTpr_Itemcargaembalaje_Z = Z815ItemCargaEmbalaje;
         obj120.gxTpr_Itemcargaelevcant_Z = Z814ItemCargaElevCant;
         obj120.gxTpr_Itemcargaelevacion_Z = Z816ItemCargaElevacion;
         obj120.gxTpr_Itemcargavolumen_Z = Z754ItemCargaVolumen;
         obj120.gxTpr_Itemcargavolumencalculado_Z = Z779ItemCargaVolumenCalculado;
         obj120.gxTpr_Itemcargaembcant_N = (short)(Convert.ToInt16(n813ItemCargaEmbCant));
         obj120.gxTpr_Itemcargaelevcant_N = (short)(Convert.ToInt16(n814ItemCargaElevCant));
         obj120.gxTpr_Modified = nIsMod_120;
         return  ;
      }

      public void KeyVarsToRow120( SdtMudanza_Carga obj120 )
      {
         obj120.gxTpr_Itemcargaid = A751ItemCargaId;
         return  ;
      }

      public void RowToVars120( SdtMudanza_Carga obj120 ,
                                int forceLoad )
      {
         Gx_mode = obj120.gxTpr_Mode;
         A779ItemCargaVolumenCalculado = obj120.gxTpr_Itemcargavolumencalculado;
         A752ItemCargaNombre = obj120.gxTpr_Itemcarganombre;
         A841ItemCargaDescripcion = obj120.gxTpr_Itemcargadescripcion;
         A753ItemCargaCantidad = obj120.gxTpr_Itemcargacantidad;
         A813ItemCargaEmbCant = obj120.gxTpr_Itemcargaembcant;
         n813ItemCargaEmbCant = false;
         A815ItemCargaEmbalaje = obj120.gxTpr_Itemcargaembalaje;
         A814ItemCargaElevCant = obj120.gxTpr_Itemcargaelevcant;
         n814ItemCargaElevCant = false;
         A816ItemCargaElevacion = obj120.gxTpr_Itemcargaelevacion;
         A754ItemCargaVolumen = obj120.gxTpr_Itemcargavolumen;
         A751ItemCargaId = obj120.gxTpr_Itemcargaid;
         Z751ItemCargaId = obj120.gxTpr_Itemcargaid_Z;
         Z752ItemCargaNombre = obj120.gxTpr_Itemcarganombre_Z;
         Z841ItemCargaDescripcion = obj120.gxTpr_Itemcargadescripcion_Z;
         Z753ItemCargaCantidad = obj120.gxTpr_Itemcargacantidad_Z;
         Z813ItemCargaEmbCant = obj120.gxTpr_Itemcargaembcant_Z;
         Z815ItemCargaEmbalaje = obj120.gxTpr_Itemcargaembalaje_Z;
         Z814ItemCargaElevCant = obj120.gxTpr_Itemcargaelevcant_Z;
         Z816ItemCargaElevacion = obj120.gxTpr_Itemcargaelevacion_Z;
         Z754ItemCargaVolumen = obj120.gxTpr_Itemcargavolumen_Z;
         Z779ItemCargaVolumenCalculado = obj120.gxTpr_Itemcargavolumencalculado_Z;
         n813ItemCargaEmbCant = (bool)(Convert.ToBoolean(obj120.gxTpr_Itemcargaembcant_N));
         n814ItemCargaElevCant = (bool)(Convert.ToBoolean(obj120.gxTpr_Itemcargaelevcant_N));
         nIsMod_120 = obj120.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow121( SdtMudanza_Adicional obj121 )
      {
         obj121.gxTpr_Mode = Gx_mode;
         obj121.gxTpr_Itemadicionalvalorcalculado = A781ItemAdicionalValorCalculado;
         obj121.gxTpr_Itemadicionalnombre = A767ItemAdicionalNombre;
         obj121.gxTpr_Itemadicionalcantidad = A768ItemAdicionalCantidad;
         obj121.gxTpr_Itemadicionalvalor = A769ItemAdicionalValor;
         obj121.gxTpr_Itemadicionalid = A766ItemAdicionalId;
         obj121.gxTpr_Itemadicionalid_Z = Z766ItemAdicionalId;
         obj121.gxTpr_Itemadicionalnombre_Z = Z767ItemAdicionalNombre;
         obj121.gxTpr_Itemadicionalcantidad_Z = Z768ItemAdicionalCantidad;
         obj121.gxTpr_Itemadicionalvalor_Z = Z769ItemAdicionalValor;
         obj121.gxTpr_Itemadicionalvalorcalculado_Z = Z781ItemAdicionalValorCalculado;
         obj121.gxTpr_Modified = nIsMod_121;
         return  ;
      }

      public void KeyVarsToRow121( SdtMudanza_Adicional obj121 )
      {
         obj121.gxTpr_Itemadicionalid = A766ItemAdicionalId;
         return  ;
      }

      public void RowToVars121( SdtMudanza_Adicional obj121 ,
                                int forceLoad )
      {
         Gx_mode = obj121.gxTpr_Mode;
         A781ItemAdicionalValorCalculado = obj121.gxTpr_Itemadicionalvalorcalculado;
         A767ItemAdicionalNombre = obj121.gxTpr_Itemadicionalnombre;
         A768ItemAdicionalCantidad = obj121.gxTpr_Itemadicionalcantidad;
         A769ItemAdicionalValor = obj121.gxTpr_Itemadicionalvalor;
         A766ItemAdicionalId = obj121.gxTpr_Itemadicionalid;
         Z766ItemAdicionalId = obj121.gxTpr_Itemadicionalid_Z;
         Z767ItemAdicionalNombre = obj121.gxTpr_Itemadicionalnombre_Z;
         Z768ItemAdicionalCantidad = obj121.gxTpr_Itemadicionalcantidad_Z;
         Z769ItemAdicionalValor = obj121.gxTpr_Itemadicionalvalor_Z;
         Z781ItemAdicionalValorCalculado = obj121.gxTpr_Itemadicionalvalorcalculado_Z;
         nIsMod_121 = obj121.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A735MudanzaId = (long)getParm(obj,0);
         n735MudanzaId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2K119( ) ;
         ScanKeyStart2K119( ) ;
         if ( RcdFound119 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z735MudanzaId = A735MudanzaId;
         }
         ZM2K119( -11) ;
         OnLoadActions2K119( ) ;
         AddRow2K119( ) ;
         bcMudanza.gxTpr_Carga.ClearCollection();
         if ( RcdFound119 == 1 )
         {
            ScanKeyStart2K120( ) ;
            nGXsfl_120_idx = 1;
            while ( RcdFound120 != 0 )
            {
               Z735MudanzaId = A735MudanzaId;
               Z751ItemCargaId = A751ItemCargaId;
               ZM2K120( -16) ;
               OnLoadActions2K120( ) ;
               nRcdExists_120 = 1;
               nIsMod_120 = 0;
               AddRow2K120( ) ;
               nGXsfl_120_idx = (int)(nGXsfl_120_idx+1);
               ScanKeyNext2K120( ) ;
            }
            ScanKeyEnd2K120( ) ;
         }
         bcMudanza.gxTpr_Adicional.ClearCollection();
         if ( RcdFound119 == 1 )
         {
            ScanKeyStart2K121( ) ;
            nGXsfl_121_idx = 1;
            while ( RcdFound121 != 0 )
            {
               Z735MudanzaId = A735MudanzaId;
               Z766ItemAdicionalId = A766ItemAdicionalId;
               ZM2K121( -18) ;
               OnLoadActions2K121( ) ;
               nRcdExists_121 = 1;
               nIsMod_121 = 0;
               AddRow2K121( ) ;
               nGXsfl_121_idx = (int)(nGXsfl_121_idx+1);
               ScanKeyNext2K121( ) ;
            }
            ScanKeyEnd2K121( ) ;
         }
         ScanKeyEnd2K119( ) ;
         if ( RcdFound119 == 0 )
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
         RowToVars119( bcMudanza, 0) ;
         ScanKeyStart2K119( ) ;
         if ( RcdFound119 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z735MudanzaId = A735MudanzaId;
         }
         ZM2K119( -11) ;
         OnLoadActions2K119( ) ;
         AddRow2K119( ) ;
         bcMudanza.gxTpr_Carga.ClearCollection();
         if ( RcdFound119 == 1 )
         {
            ScanKeyStart2K120( ) ;
            nGXsfl_120_idx = 1;
            while ( RcdFound120 != 0 )
            {
               Z735MudanzaId = A735MudanzaId;
               Z751ItemCargaId = A751ItemCargaId;
               ZM2K120( -16) ;
               OnLoadActions2K120( ) ;
               nRcdExists_120 = 1;
               nIsMod_120 = 0;
               AddRow2K120( ) ;
               nGXsfl_120_idx = (int)(nGXsfl_120_idx+1);
               ScanKeyNext2K120( ) ;
            }
            ScanKeyEnd2K120( ) ;
         }
         bcMudanza.gxTpr_Adicional.ClearCollection();
         if ( RcdFound119 == 1 )
         {
            ScanKeyStart2K121( ) ;
            nGXsfl_121_idx = 1;
            while ( RcdFound121 != 0 )
            {
               Z735MudanzaId = A735MudanzaId;
               Z766ItemAdicionalId = A766ItemAdicionalId;
               ZM2K121( -18) ;
               OnLoadActions2K121( ) ;
               nRcdExists_121 = 1;
               nIsMod_121 = 0;
               AddRow2K121( ) ;
               nGXsfl_121_idx = (int)(nGXsfl_121_idx+1);
               ScanKeyNext2K121( ) ;
            }
            ScanKeyEnd2K121( ) ;
         }
         ScanKeyEnd2K119( ) ;
         if ( RcdFound119 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2K119( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2K119( ) ;
         }
         else
         {
            if ( RcdFound119 == 1 )
            {
               if ( A735MudanzaId != Z735MudanzaId )
               {
                  A735MudanzaId = Z735MudanzaId;
                  n735MudanzaId = false;
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
                  Update2K119( ) ;
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
                  if ( A735MudanzaId != Z735MudanzaId )
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
                        Insert2K119( ) ;
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
                        Insert2K119( ) ;
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
         RowToVars119( bcMudanza, 1) ;
         SaveImpl( ) ;
         VarsToRow119( bcMudanza) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars119( bcMudanza, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2K119( ) ;
         AfterTrn( ) ;
         VarsToRow119( bcMudanza) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow119( bcMudanza) ;
         }
         else
         {
            SdtMudanza auxBC = new SdtMudanza(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A735MudanzaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcMudanza);
               auxBC.Save();
               bcMudanza.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars119( bcMudanza, 1) ;
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
         RowToVars119( bcMudanza, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2K119( ) ;
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
               VarsToRow119( bcMudanza) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow119( bcMudanza) ;
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
         RowToVars119( bcMudanza, 0) ;
         GetKey2K119( ) ;
         if ( RcdFound119 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A735MudanzaId != Z735MudanzaId )
            {
               A735MudanzaId = Z735MudanzaId;
               n735MudanzaId = false;
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
            if ( A735MudanzaId != Z735MudanzaId )
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
         pr_default.close(4);
         pr_default.close(1);
         pr_default.close(17);
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(20);
         pr_default.close(28);
         pr_default.close(35);
         context.RollbackDataStores("mudanza_bc",pr_default);
         VarsToRow119( bcMudanza) ;
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
         Gx_mode = bcMudanza.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcMudanza.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcMudanza )
         {
            bcMudanza = (SdtMudanza)(sdt);
            if ( StringUtil.StrCmp(bcMudanza.gxTpr_Mode, "") == 0 )
            {
               bcMudanza.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow119( bcMudanza) ;
            }
            else
            {
               RowToVars119( bcMudanza, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcMudanza.gxTpr_Mode, "") == 0 )
            {
               bcMudanza.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars119( bcMudanza, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtMudanza Mudanza_BC
      {
         get {
            return bcMudanza ;
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
         pr_default.close(35);
         pr_default.close(4);
         pr_default.close(28);
         pr_default.close(7);
         pr_default.close(17);
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode119 = "";
         AV112USLPAGO = "";
         AV114ParametrosEstado = "";
         AV115URLMAPA = "";
         AV116Coordenadas = "";
         AV117Token = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV138Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV17TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z736MudanzaAsesor = "";
         A736MudanzaAsesor = "";
         Z784MudanzaApellidoNombre = "";
         A784MudanzaApellidoNombre = "";
         Z785MudanzaMail = "";
         A785MudanzaMail = "";
         Z786MudanzaPhone = "";
         A786MudanzaPhone = "";
         Z737MudanzaFechaAlta = DateTime.MinValue;
         A737MudanzaFechaAlta = DateTime.MinValue;
         Z873MudanzaFechaUpdate = DateTime.MinValue;
         A873MudanzaFechaUpdate = DateTime.MinValue;
         Z738MudanzaFechaServicio = DateTime.MinValue;
         A738MudanzaFechaServicio = DateTime.MinValue;
         Z739MudanzaHoraServicio = "";
         A739MudanzaHoraServicio = "";
         Z776MudanzaRgoHoraservicio = "";
         A776MudanzaRgoHoraservicio = "";
         Z740MudanzaDireccionOrigen = "";
         A740MudanzaDireccionOrigen = "";
         Z788MudanzaLocalidadOrigen = "";
         A788MudanzaLocalidadOrigen = "";
         Z777MudanzaPisoDptoOrigen = "";
         A777MudanzaPisoDptoOrigen = "";
         Z741MudanzaDireccionDestino = "";
         A741MudanzaDireccionDestino = "";
         Z789MudanzaLocalidadDestino = "";
         A789MudanzaLocalidadDestino = "";
         Z778MudanzaPisoDptoDestino = "";
         A778MudanzaPisoDptoDestino = "";
         Z871MudanzaCoordenadaOrigen = "";
         A871MudanzaCoordenadaOrigen = "";
         Z872MudanzaCoordenadaDestino = "";
         A872MudanzaCoordenadaDestino = "";
         Z742MudanzaVehiculoSugerido = "";
         A742MudanzaVehiculoSugerido = "";
         Z783MudanzaComentario = "";
         A783MudanzaComentario = "";
         Z794MudanzaOrigenMetodo = "";
         A794MudanzaOrigenMetodo = "";
         Z795MudanzaDestinoMetodo = "";
         A795MudanzaDestinoMetodo = "";
         Z791MudanzaFormaPago = "";
         A791MudanzaFormaPago = "";
         Z755TipoInmuebleOrigenNombre = "";
         A755TipoInmuebleOrigenNombre = "";
         Z746TipoInmuebleDestinoNombre = "";
         A746TipoInmuebleDestinoNombre = "";
         Z748TipoEstacionamOrigenNombre = "";
         A748TipoEstacionamOrigenNombre = "";
         Z750TipoEstacionamDestinoNombre = "";
         A750TipoEstacionamDestinoNombre = "";
         BC002K14_A760MudanzaPeajevalor = new decimal[1] ;
         BC002K14_A735MudanzaId = new long[1] ;
         BC002K14_n735MudanzaId = new bool[] {false} ;
         BC002K14_A736MudanzaAsesor = new string[] {""} ;
         BC002K14_A784MudanzaApellidoNombre = new string[] {""} ;
         BC002K14_A785MudanzaMail = new string[] {""} ;
         BC002K14_A786MudanzaPhone = new string[] {""} ;
         BC002K14_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC002K14_A873MudanzaFechaUpdate = new DateTime[] {DateTime.MinValue} ;
         BC002K14_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         BC002K14_A739MudanzaHoraServicio = new string[] {""} ;
         BC002K14_n739MudanzaHoraServicio = new bool[] {false} ;
         BC002K14_A776MudanzaRgoHoraservicio = new string[] {""} ;
         BC002K14_n776MudanzaRgoHoraservicio = new bool[] {false} ;
         BC002K14_A740MudanzaDireccionOrigen = new string[] {""} ;
         BC002K14_A788MudanzaLocalidadOrigen = new string[] {""} ;
         BC002K14_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         BC002K14_A741MudanzaDireccionDestino = new string[] {""} ;
         BC002K14_A789MudanzaLocalidadDestino = new string[] {""} ;
         BC002K14_A778MudanzaPisoDptoDestino = new string[] {""} ;
         BC002K14_A762MudanzaDistancia = new decimal[1] ;
         BC002K14_A871MudanzaCoordenadaOrigen = new string[] {""} ;
         BC002K14_A872MudanzaCoordenadaDestino = new string[] {""} ;
         BC002K14_A742MudanzaVehiculoSugerido = new string[] {""} ;
         BC002K14_A780MudanzaPrecioBasexHora = new decimal[1] ;
         BC002K14_A761MudanzaPeajeCantidad = new short[1] ;
         BC002K14_A783MudanzaComentario = new string[] {""} ;
         BC002K14_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         BC002K14_A756TipoInmuebleOrigenValor = new decimal[1] ;
         BC002K14_A794MudanzaOrigenMetodo = new string[] {""} ;
         BC002K14_A746TipoInmuebleDestinoNombre = new string[] {""} ;
         BC002K14_A757TipoInmuebleDestinoValor = new decimal[1] ;
         BC002K14_A748TipoEstacionamOrigenNombre = new string[] {""} ;
         BC002K14_A758TipoEstacionamOrigenValor = new decimal[1] ;
         BC002K14_A750TipoEstacionamDestinoNombre = new string[] {""} ;
         BC002K14_A795MudanzaDestinoMetodo = new string[] {""} ;
         BC002K14_A759TipoEstacionamDestinoValor = new decimal[1] ;
         BC002K14_A763MudanzaTiempoMaximo = new decimal[1] ;
         BC002K14_A765MudanzaCargaVolumenEstimado = new decimal[1] ;
         BC002K14_A782MudanzaAdicionalPrecio = new decimal[1] ;
         BC002K14_A874MudanzaElevacion = new short[1] ;
         BC002K14_A875MudanzaDescenso = new short[1] ;
         BC002K14_A876MudanzaEmbalaje = new short[1] ;
         BC002K14_A840MudanzaCantidadPeones = new short[1] ;
         BC002K14_A764MudanzaPrecioFinal = new decimal[1] ;
         BC002K14_A790MudanzaOperacionId = new long[1] ;
         BC002K14_A791MudanzaFormaPago = new string[] {""} ;
         BC002K14_A792MudanzaProveedorId = new long[1] ;
         BC002K14_A837MudanzaSecUserId = new long[1] ;
         BC002K14_A743TipoInmuebleOrigenId = new short[1] ;
         BC002K14_A745TipoInmuebleDestinoId = new short[1] ;
         BC002K14_A747TipoEstacionamOrigenId = new short[1] ;
         BC002K14_A749TipoEstacionamDestinoId = new short[1] ;
         BC002K10_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         BC002K10_A756TipoInmuebleOrigenValor = new decimal[1] ;
         BC002K11_A746TipoInmuebleDestinoNombre = new string[] {""} ;
         BC002K11_A757TipoInmuebleDestinoValor = new decimal[1] ;
         BC002K12_A748TipoEstacionamOrigenNombre = new string[] {""} ;
         BC002K12_A758TipoEstacionamOrigenValor = new decimal[1] ;
         BC002K13_A750TipoEstacionamDestinoNombre = new string[] {""} ;
         BC002K13_A759TipoEstacionamDestinoValor = new decimal[1] ;
         BC002K15_A735MudanzaId = new long[1] ;
         BC002K15_n735MudanzaId = new bool[] {false} ;
         BC002K9_A760MudanzaPeajevalor = new decimal[1] ;
         BC002K9_A735MudanzaId = new long[1] ;
         BC002K9_n735MudanzaId = new bool[] {false} ;
         BC002K9_A736MudanzaAsesor = new string[] {""} ;
         BC002K9_A784MudanzaApellidoNombre = new string[] {""} ;
         BC002K9_A785MudanzaMail = new string[] {""} ;
         BC002K9_A786MudanzaPhone = new string[] {""} ;
         BC002K9_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC002K9_A873MudanzaFechaUpdate = new DateTime[] {DateTime.MinValue} ;
         BC002K9_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         BC002K9_A739MudanzaHoraServicio = new string[] {""} ;
         BC002K9_n739MudanzaHoraServicio = new bool[] {false} ;
         BC002K9_A776MudanzaRgoHoraservicio = new string[] {""} ;
         BC002K9_n776MudanzaRgoHoraservicio = new bool[] {false} ;
         BC002K9_A740MudanzaDireccionOrigen = new string[] {""} ;
         BC002K9_A788MudanzaLocalidadOrigen = new string[] {""} ;
         BC002K9_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         BC002K9_A741MudanzaDireccionDestino = new string[] {""} ;
         BC002K9_A789MudanzaLocalidadDestino = new string[] {""} ;
         BC002K9_A778MudanzaPisoDptoDestino = new string[] {""} ;
         BC002K9_A762MudanzaDistancia = new decimal[1] ;
         BC002K9_A871MudanzaCoordenadaOrigen = new string[] {""} ;
         BC002K9_A872MudanzaCoordenadaDestino = new string[] {""} ;
         BC002K9_A742MudanzaVehiculoSugerido = new string[] {""} ;
         BC002K9_A780MudanzaPrecioBasexHora = new decimal[1] ;
         BC002K9_A761MudanzaPeajeCantidad = new short[1] ;
         BC002K9_A783MudanzaComentario = new string[] {""} ;
         BC002K9_A794MudanzaOrigenMetodo = new string[] {""} ;
         BC002K9_A795MudanzaDestinoMetodo = new string[] {""} ;
         BC002K9_A763MudanzaTiempoMaximo = new decimal[1] ;
         BC002K9_A765MudanzaCargaVolumenEstimado = new decimal[1] ;
         BC002K9_A782MudanzaAdicionalPrecio = new decimal[1] ;
         BC002K9_A874MudanzaElevacion = new short[1] ;
         BC002K9_A875MudanzaDescenso = new short[1] ;
         BC002K9_A876MudanzaEmbalaje = new short[1] ;
         BC002K9_A840MudanzaCantidadPeones = new short[1] ;
         BC002K9_A764MudanzaPrecioFinal = new decimal[1] ;
         BC002K9_A790MudanzaOperacionId = new long[1] ;
         BC002K9_A791MudanzaFormaPago = new string[] {""} ;
         BC002K9_A792MudanzaProveedorId = new long[1] ;
         BC002K9_A837MudanzaSecUserId = new long[1] ;
         BC002K9_A743TipoInmuebleOrigenId = new short[1] ;
         BC002K9_A745TipoInmuebleDestinoId = new short[1] ;
         BC002K9_A747TipoEstacionamOrigenId = new short[1] ;
         BC002K9_A749TipoEstacionamDestinoId = new short[1] ;
         BC002K8_A760MudanzaPeajevalor = new decimal[1] ;
         BC002K8_A735MudanzaId = new long[1] ;
         BC002K8_n735MudanzaId = new bool[] {false} ;
         BC002K8_A736MudanzaAsesor = new string[] {""} ;
         BC002K8_A784MudanzaApellidoNombre = new string[] {""} ;
         BC002K8_A785MudanzaMail = new string[] {""} ;
         BC002K8_A786MudanzaPhone = new string[] {""} ;
         BC002K8_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC002K8_A873MudanzaFechaUpdate = new DateTime[] {DateTime.MinValue} ;
         BC002K8_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         BC002K8_A739MudanzaHoraServicio = new string[] {""} ;
         BC002K8_n739MudanzaHoraServicio = new bool[] {false} ;
         BC002K8_A776MudanzaRgoHoraservicio = new string[] {""} ;
         BC002K8_n776MudanzaRgoHoraservicio = new bool[] {false} ;
         BC002K8_A740MudanzaDireccionOrigen = new string[] {""} ;
         BC002K8_A788MudanzaLocalidadOrigen = new string[] {""} ;
         BC002K8_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         BC002K8_A741MudanzaDireccionDestino = new string[] {""} ;
         BC002K8_A789MudanzaLocalidadDestino = new string[] {""} ;
         BC002K8_A778MudanzaPisoDptoDestino = new string[] {""} ;
         BC002K8_A762MudanzaDistancia = new decimal[1] ;
         BC002K8_A871MudanzaCoordenadaOrigen = new string[] {""} ;
         BC002K8_A872MudanzaCoordenadaDestino = new string[] {""} ;
         BC002K8_A742MudanzaVehiculoSugerido = new string[] {""} ;
         BC002K8_A780MudanzaPrecioBasexHora = new decimal[1] ;
         BC002K8_A761MudanzaPeajeCantidad = new short[1] ;
         BC002K8_A783MudanzaComentario = new string[] {""} ;
         BC002K8_A794MudanzaOrigenMetodo = new string[] {""} ;
         BC002K8_A795MudanzaDestinoMetodo = new string[] {""} ;
         BC002K8_A763MudanzaTiempoMaximo = new decimal[1] ;
         BC002K8_A765MudanzaCargaVolumenEstimado = new decimal[1] ;
         BC002K8_A782MudanzaAdicionalPrecio = new decimal[1] ;
         BC002K8_A874MudanzaElevacion = new short[1] ;
         BC002K8_A875MudanzaDescenso = new short[1] ;
         BC002K8_A876MudanzaEmbalaje = new short[1] ;
         BC002K8_A840MudanzaCantidadPeones = new short[1] ;
         BC002K8_A764MudanzaPrecioFinal = new decimal[1] ;
         BC002K8_A790MudanzaOperacionId = new long[1] ;
         BC002K8_A791MudanzaFormaPago = new string[] {""} ;
         BC002K8_A792MudanzaProveedorId = new long[1] ;
         BC002K8_A837MudanzaSecUserId = new long[1] ;
         BC002K8_A743TipoInmuebleOrigenId = new short[1] ;
         BC002K8_A745TipoInmuebleDestinoId = new short[1] ;
         BC002K8_A747TipoEstacionamOrigenId = new short[1] ;
         BC002K8_A749TipoEstacionamDestinoId = new short[1] ;
         BC002K16_A735MudanzaId = new long[1] ;
         BC002K16_n735MudanzaId = new bool[] {false} ;
         BC002K19_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         BC002K19_A756TipoInmuebleOrigenValor = new decimal[1] ;
         BC002K20_A746TipoInmuebleDestinoNombre = new string[] {""} ;
         BC002K20_A757TipoInmuebleDestinoValor = new decimal[1] ;
         BC002K21_A748TipoEstacionamOrigenNombre = new string[] {""} ;
         BC002K21_A758TipoEstacionamOrigenValor = new decimal[1] ;
         BC002K22_A750TipoEstacionamDestinoNombre = new string[] {""} ;
         BC002K22_A759TipoEstacionamDestinoValor = new decimal[1] ;
         BC002K23_A127SolicitudesID = new long[1] ;
         BC002K24_A760MudanzaPeajevalor = new decimal[1] ;
         BC002K24_A735MudanzaId = new long[1] ;
         BC002K24_n735MudanzaId = new bool[] {false} ;
         BC002K24_A736MudanzaAsesor = new string[] {""} ;
         BC002K24_A784MudanzaApellidoNombre = new string[] {""} ;
         BC002K24_A785MudanzaMail = new string[] {""} ;
         BC002K24_A786MudanzaPhone = new string[] {""} ;
         BC002K24_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC002K24_A873MudanzaFechaUpdate = new DateTime[] {DateTime.MinValue} ;
         BC002K24_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         BC002K24_A739MudanzaHoraServicio = new string[] {""} ;
         BC002K24_n739MudanzaHoraServicio = new bool[] {false} ;
         BC002K24_A776MudanzaRgoHoraservicio = new string[] {""} ;
         BC002K24_n776MudanzaRgoHoraservicio = new bool[] {false} ;
         BC002K24_A740MudanzaDireccionOrigen = new string[] {""} ;
         BC002K24_A788MudanzaLocalidadOrigen = new string[] {""} ;
         BC002K24_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         BC002K24_A741MudanzaDireccionDestino = new string[] {""} ;
         BC002K24_A789MudanzaLocalidadDestino = new string[] {""} ;
         BC002K24_A778MudanzaPisoDptoDestino = new string[] {""} ;
         BC002K24_A762MudanzaDistancia = new decimal[1] ;
         BC002K24_A871MudanzaCoordenadaOrigen = new string[] {""} ;
         BC002K24_A872MudanzaCoordenadaDestino = new string[] {""} ;
         BC002K24_A742MudanzaVehiculoSugerido = new string[] {""} ;
         BC002K24_A780MudanzaPrecioBasexHora = new decimal[1] ;
         BC002K24_A761MudanzaPeajeCantidad = new short[1] ;
         BC002K24_A783MudanzaComentario = new string[] {""} ;
         BC002K24_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         BC002K24_A756TipoInmuebleOrigenValor = new decimal[1] ;
         BC002K24_A794MudanzaOrigenMetodo = new string[] {""} ;
         BC002K24_A746TipoInmuebleDestinoNombre = new string[] {""} ;
         BC002K24_A757TipoInmuebleDestinoValor = new decimal[1] ;
         BC002K24_A748TipoEstacionamOrigenNombre = new string[] {""} ;
         BC002K24_A758TipoEstacionamOrigenValor = new decimal[1] ;
         BC002K24_A750TipoEstacionamDestinoNombre = new string[] {""} ;
         BC002K24_A795MudanzaDestinoMetodo = new string[] {""} ;
         BC002K24_A759TipoEstacionamDestinoValor = new decimal[1] ;
         BC002K24_A763MudanzaTiempoMaximo = new decimal[1] ;
         BC002K24_A765MudanzaCargaVolumenEstimado = new decimal[1] ;
         BC002K24_A782MudanzaAdicionalPrecio = new decimal[1] ;
         BC002K24_A874MudanzaElevacion = new short[1] ;
         BC002K24_A875MudanzaDescenso = new short[1] ;
         BC002K24_A876MudanzaEmbalaje = new short[1] ;
         BC002K24_A840MudanzaCantidadPeones = new short[1] ;
         BC002K24_A764MudanzaPrecioFinal = new decimal[1] ;
         BC002K24_A790MudanzaOperacionId = new long[1] ;
         BC002K24_A791MudanzaFormaPago = new string[] {""} ;
         BC002K24_A792MudanzaProveedorId = new long[1] ;
         BC002K24_A837MudanzaSecUserId = new long[1] ;
         BC002K24_A743TipoInmuebleOrigenId = new short[1] ;
         BC002K24_A745TipoInmuebleDestinoId = new short[1] ;
         BC002K24_A747TipoEstacionamOrigenId = new short[1] ;
         BC002K24_A749TipoEstacionamDestinoId = new short[1] ;
         Z752ItemCargaNombre = "";
         A752ItemCargaNombre = "";
         Z841ItemCargaDescripcion = "";
         A841ItemCargaDescripcion = "";
         BC002K25_A735MudanzaId = new long[1] ;
         BC002K25_n735MudanzaId = new bool[] {false} ;
         BC002K25_A752ItemCargaNombre = new string[] {""} ;
         BC002K25_A841ItemCargaDescripcion = new string[] {""} ;
         BC002K25_A753ItemCargaCantidad = new short[1] ;
         BC002K25_A813ItemCargaEmbCant = new short[1] ;
         BC002K25_n813ItemCargaEmbCant = new bool[] {false} ;
         BC002K25_A815ItemCargaEmbalaje = new bool[] {false} ;
         BC002K25_A814ItemCargaElevCant = new short[1] ;
         BC002K25_n814ItemCargaElevCant = new bool[] {false} ;
         BC002K25_A816ItemCargaElevacion = new bool[] {false} ;
         BC002K25_A754ItemCargaVolumen = new decimal[1] ;
         BC002K25_A751ItemCargaId = new short[1] ;
         BC002K7_A752ItemCargaNombre = new string[] {""} ;
         BC002K7_A841ItemCargaDescripcion = new string[] {""} ;
         BC002K7_A754ItemCargaVolumen = new decimal[1] ;
         BC002K26_A735MudanzaId = new long[1] ;
         BC002K26_n735MudanzaId = new bool[] {false} ;
         BC002K26_A751ItemCargaId = new short[1] ;
         BC002K6_A735MudanzaId = new long[1] ;
         BC002K6_n735MudanzaId = new bool[] {false} ;
         BC002K6_A753ItemCargaCantidad = new short[1] ;
         BC002K6_A813ItemCargaEmbCant = new short[1] ;
         BC002K6_n813ItemCargaEmbCant = new bool[] {false} ;
         BC002K6_A815ItemCargaEmbalaje = new bool[] {false} ;
         BC002K6_A814ItemCargaElevCant = new short[1] ;
         BC002K6_n814ItemCargaElevCant = new bool[] {false} ;
         BC002K6_A816ItemCargaElevacion = new bool[] {false} ;
         BC002K6_A751ItemCargaId = new short[1] ;
         sMode120 = "";
         BC002K5_A735MudanzaId = new long[1] ;
         BC002K5_n735MudanzaId = new bool[] {false} ;
         BC002K5_A753ItemCargaCantidad = new short[1] ;
         BC002K5_A813ItemCargaEmbCant = new short[1] ;
         BC002K5_n813ItemCargaEmbCant = new bool[] {false} ;
         BC002K5_A815ItemCargaEmbalaje = new bool[] {false} ;
         BC002K5_A814ItemCargaElevCant = new short[1] ;
         BC002K5_n814ItemCargaElevCant = new bool[] {false} ;
         BC002K5_A816ItemCargaElevacion = new bool[] {false} ;
         BC002K5_A751ItemCargaId = new short[1] ;
         BC002K30_A752ItemCargaNombre = new string[] {""} ;
         BC002K30_A841ItemCargaDescripcion = new string[] {""} ;
         BC002K30_A754ItemCargaVolumen = new decimal[1] ;
         BC002K31_A735MudanzaId = new long[1] ;
         BC002K31_n735MudanzaId = new bool[] {false} ;
         BC002K31_A752ItemCargaNombre = new string[] {""} ;
         BC002K31_A841ItemCargaDescripcion = new string[] {""} ;
         BC002K31_A753ItemCargaCantidad = new short[1] ;
         BC002K31_A813ItemCargaEmbCant = new short[1] ;
         BC002K31_n813ItemCargaEmbCant = new bool[] {false} ;
         BC002K31_A815ItemCargaEmbalaje = new bool[] {false} ;
         BC002K31_A814ItemCargaElevCant = new short[1] ;
         BC002K31_n814ItemCargaElevCant = new bool[] {false} ;
         BC002K31_A816ItemCargaElevacion = new bool[] {false} ;
         BC002K31_A754ItemCargaVolumen = new decimal[1] ;
         BC002K31_A751ItemCargaId = new short[1] ;
         Z767ItemAdicionalNombre = "";
         A767ItemAdicionalNombre = "";
         BC002K32_A735MudanzaId = new long[1] ;
         BC002K32_n735MudanzaId = new bool[] {false} ;
         BC002K32_A767ItemAdicionalNombre = new string[] {""} ;
         BC002K32_A768ItemAdicionalCantidad = new short[1] ;
         BC002K32_A769ItemAdicionalValor = new decimal[1] ;
         BC002K32_A766ItemAdicionalId = new short[1] ;
         BC002K4_A767ItemAdicionalNombre = new string[] {""} ;
         BC002K4_A769ItemAdicionalValor = new decimal[1] ;
         BC002K33_A735MudanzaId = new long[1] ;
         BC002K33_n735MudanzaId = new bool[] {false} ;
         BC002K33_A766ItemAdicionalId = new short[1] ;
         BC002K3_A735MudanzaId = new long[1] ;
         BC002K3_n735MudanzaId = new bool[] {false} ;
         BC002K3_A768ItemAdicionalCantidad = new short[1] ;
         BC002K3_A766ItemAdicionalId = new short[1] ;
         sMode121 = "";
         BC002K2_A735MudanzaId = new long[1] ;
         BC002K2_n735MudanzaId = new bool[] {false} ;
         BC002K2_A768ItemAdicionalCantidad = new short[1] ;
         BC002K2_A766ItemAdicionalId = new short[1] ;
         BC002K37_A767ItemAdicionalNombre = new string[] {""} ;
         BC002K37_A769ItemAdicionalValor = new decimal[1] ;
         BC002K38_A735MudanzaId = new long[1] ;
         BC002K38_n735MudanzaId = new bool[] {false} ;
         BC002K38_A767ItemAdicionalNombre = new string[] {""} ;
         BC002K38_A768ItemAdicionalCantidad = new short[1] ;
         BC002K38_A769ItemAdicionalValor = new decimal[1] ;
         BC002K38_A766ItemAdicionalId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.mudanza_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mudanza_bc__default(),
            new Object[][] {
                new Object[] {
               BC002K2_A735MudanzaId, BC002K2_A768ItemAdicionalCantidad, BC002K2_A766ItemAdicionalId
               }
               , new Object[] {
               BC002K3_A735MudanzaId, BC002K3_A768ItemAdicionalCantidad, BC002K3_A766ItemAdicionalId
               }
               , new Object[] {
               BC002K4_A767ItemAdicionalNombre, BC002K4_A769ItemAdicionalValor
               }
               , new Object[] {
               BC002K5_A735MudanzaId, BC002K5_A753ItemCargaCantidad, BC002K5_A813ItemCargaEmbCant, BC002K5_n813ItemCargaEmbCant, BC002K5_A815ItemCargaEmbalaje, BC002K5_A814ItemCargaElevCant, BC002K5_n814ItemCargaElevCant, BC002K5_A816ItemCargaElevacion, BC002K5_A751ItemCargaId
               }
               , new Object[] {
               BC002K6_A735MudanzaId, BC002K6_A753ItemCargaCantidad, BC002K6_A813ItemCargaEmbCant, BC002K6_n813ItemCargaEmbCant, BC002K6_A815ItemCargaEmbalaje, BC002K6_A814ItemCargaElevCant, BC002K6_n814ItemCargaElevCant, BC002K6_A816ItemCargaElevacion, BC002K6_A751ItemCargaId
               }
               , new Object[] {
               BC002K7_A752ItemCargaNombre, BC002K7_A841ItemCargaDescripcion, BC002K7_A754ItemCargaVolumen
               }
               , new Object[] {
               BC002K8_A760MudanzaPeajevalor, BC002K8_A735MudanzaId, BC002K8_A736MudanzaAsesor, BC002K8_A784MudanzaApellidoNombre, BC002K8_A785MudanzaMail, BC002K8_A786MudanzaPhone, BC002K8_A737MudanzaFechaAlta, BC002K8_A873MudanzaFechaUpdate, BC002K8_A738MudanzaFechaServicio, BC002K8_A739MudanzaHoraServicio,
               BC002K8_n739MudanzaHoraServicio, BC002K8_A776MudanzaRgoHoraservicio, BC002K8_n776MudanzaRgoHoraservicio, BC002K8_A740MudanzaDireccionOrigen, BC002K8_A788MudanzaLocalidadOrigen, BC002K8_A777MudanzaPisoDptoOrigen, BC002K8_A741MudanzaDireccionDestino, BC002K8_A789MudanzaLocalidadDestino, BC002K8_A778MudanzaPisoDptoDestino, BC002K8_A762MudanzaDistancia,
               BC002K8_A871MudanzaCoordenadaOrigen, BC002K8_A872MudanzaCoordenadaDestino, BC002K8_A742MudanzaVehiculoSugerido, BC002K8_A780MudanzaPrecioBasexHora, BC002K8_A761MudanzaPeajeCantidad, BC002K8_A783MudanzaComentario, BC002K8_A794MudanzaOrigenMetodo, BC002K8_A795MudanzaDestinoMetodo, BC002K8_A763MudanzaTiempoMaximo, BC002K8_A765MudanzaCargaVolumenEstimado,
               BC002K8_A782MudanzaAdicionalPrecio, BC002K8_A874MudanzaElevacion, BC002K8_A875MudanzaDescenso, BC002K8_A876MudanzaEmbalaje, BC002K8_A840MudanzaCantidadPeones, BC002K8_A764MudanzaPrecioFinal, BC002K8_A790MudanzaOperacionId, BC002K8_A791MudanzaFormaPago, BC002K8_A792MudanzaProveedorId, BC002K8_A837MudanzaSecUserId,
               BC002K8_A743TipoInmuebleOrigenId, BC002K8_A745TipoInmuebleDestinoId, BC002K8_A747TipoEstacionamOrigenId, BC002K8_A749TipoEstacionamDestinoId
               }
               , new Object[] {
               BC002K9_A760MudanzaPeajevalor, BC002K9_A735MudanzaId, BC002K9_A736MudanzaAsesor, BC002K9_A784MudanzaApellidoNombre, BC002K9_A785MudanzaMail, BC002K9_A786MudanzaPhone, BC002K9_A737MudanzaFechaAlta, BC002K9_A873MudanzaFechaUpdate, BC002K9_A738MudanzaFechaServicio, BC002K9_A739MudanzaHoraServicio,
               BC002K9_n739MudanzaHoraServicio, BC002K9_A776MudanzaRgoHoraservicio, BC002K9_n776MudanzaRgoHoraservicio, BC002K9_A740MudanzaDireccionOrigen, BC002K9_A788MudanzaLocalidadOrigen, BC002K9_A777MudanzaPisoDptoOrigen, BC002K9_A741MudanzaDireccionDestino, BC002K9_A789MudanzaLocalidadDestino, BC002K9_A778MudanzaPisoDptoDestino, BC002K9_A762MudanzaDistancia,
               BC002K9_A871MudanzaCoordenadaOrigen, BC002K9_A872MudanzaCoordenadaDestino, BC002K9_A742MudanzaVehiculoSugerido, BC002K9_A780MudanzaPrecioBasexHora, BC002K9_A761MudanzaPeajeCantidad, BC002K9_A783MudanzaComentario, BC002K9_A794MudanzaOrigenMetodo, BC002K9_A795MudanzaDestinoMetodo, BC002K9_A763MudanzaTiempoMaximo, BC002K9_A765MudanzaCargaVolumenEstimado,
               BC002K9_A782MudanzaAdicionalPrecio, BC002K9_A874MudanzaElevacion, BC002K9_A875MudanzaDescenso, BC002K9_A876MudanzaEmbalaje, BC002K9_A840MudanzaCantidadPeones, BC002K9_A764MudanzaPrecioFinal, BC002K9_A790MudanzaOperacionId, BC002K9_A791MudanzaFormaPago, BC002K9_A792MudanzaProveedorId, BC002K9_A837MudanzaSecUserId,
               BC002K9_A743TipoInmuebleOrigenId, BC002K9_A745TipoInmuebleDestinoId, BC002K9_A747TipoEstacionamOrigenId, BC002K9_A749TipoEstacionamDestinoId
               }
               , new Object[] {
               BC002K10_A755TipoInmuebleOrigenNombre, BC002K10_A756TipoInmuebleOrigenValor
               }
               , new Object[] {
               BC002K11_A746TipoInmuebleDestinoNombre, BC002K11_A757TipoInmuebleDestinoValor
               }
               , new Object[] {
               BC002K12_A748TipoEstacionamOrigenNombre, BC002K12_A758TipoEstacionamOrigenValor
               }
               , new Object[] {
               BC002K13_A750TipoEstacionamDestinoNombre, BC002K13_A759TipoEstacionamDestinoValor
               }
               , new Object[] {
               BC002K14_A760MudanzaPeajevalor, BC002K14_A735MudanzaId, BC002K14_A736MudanzaAsesor, BC002K14_A784MudanzaApellidoNombre, BC002K14_A785MudanzaMail, BC002K14_A786MudanzaPhone, BC002K14_A737MudanzaFechaAlta, BC002K14_A873MudanzaFechaUpdate, BC002K14_A738MudanzaFechaServicio, BC002K14_A739MudanzaHoraServicio,
               BC002K14_n739MudanzaHoraServicio, BC002K14_A776MudanzaRgoHoraservicio, BC002K14_n776MudanzaRgoHoraservicio, BC002K14_A740MudanzaDireccionOrigen, BC002K14_A788MudanzaLocalidadOrigen, BC002K14_A777MudanzaPisoDptoOrigen, BC002K14_A741MudanzaDireccionDestino, BC002K14_A789MudanzaLocalidadDestino, BC002K14_A778MudanzaPisoDptoDestino, BC002K14_A762MudanzaDistancia,
               BC002K14_A871MudanzaCoordenadaOrigen, BC002K14_A872MudanzaCoordenadaDestino, BC002K14_A742MudanzaVehiculoSugerido, BC002K14_A780MudanzaPrecioBasexHora, BC002K14_A761MudanzaPeajeCantidad, BC002K14_A783MudanzaComentario, BC002K14_A755TipoInmuebleOrigenNombre, BC002K14_A756TipoInmuebleOrigenValor, BC002K14_A794MudanzaOrigenMetodo, BC002K14_A746TipoInmuebleDestinoNombre,
               BC002K14_A757TipoInmuebleDestinoValor, BC002K14_A748TipoEstacionamOrigenNombre, BC002K14_A758TipoEstacionamOrigenValor, BC002K14_A750TipoEstacionamDestinoNombre, BC002K14_A795MudanzaDestinoMetodo, BC002K14_A759TipoEstacionamDestinoValor, BC002K14_A763MudanzaTiempoMaximo, BC002K14_A765MudanzaCargaVolumenEstimado, BC002K14_A782MudanzaAdicionalPrecio, BC002K14_A874MudanzaElevacion,
               BC002K14_A875MudanzaDescenso, BC002K14_A876MudanzaEmbalaje, BC002K14_A840MudanzaCantidadPeones, BC002K14_A764MudanzaPrecioFinal, BC002K14_A790MudanzaOperacionId, BC002K14_A791MudanzaFormaPago, BC002K14_A792MudanzaProveedorId, BC002K14_A837MudanzaSecUserId, BC002K14_A743TipoInmuebleOrigenId, BC002K14_A745TipoInmuebleDestinoId,
               BC002K14_A747TipoEstacionamOrigenId, BC002K14_A749TipoEstacionamDestinoId
               }
               , new Object[] {
               BC002K15_A735MudanzaId
               }
               , new Object[] {
               BC002K16_A735MudanzaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002K19_A755TipoInmuebleOrigenNombre, BC002K19_A756TipoInmuebleOrigenValor
               }
               , new Object[] {
               BC002K20_A746TipoInmuebleDestinoNombre, BC002K20_A757TipoInmuebleDestinoValor
               }
               , new Object[] {
               BC002K21_A748TipoEstacionamOrigenNombre, BC002K21_A758TipoEstacionamOrigenValor
               }
               , new Object[] {
               BC002K22_A750TipoEstacionamDestinoNombre, BC002K22_A759TipoEstacionamDestinoValor
               }
               , new Object[] {
               BC002K23_A127SolicitudesID
               }
               , new Object[] {
               BC002K24_A760MudanzaPeajevalor, BC002K24_A735MudanzaId, BC002K24_A736MudanzaAsesor, BC002K24_A784MudanzaApellidoNombre, BC002K24_A785MudanzaMail, BC002K24_A786MudanzaPhone, BC002K24_A737MudanzaFechaAlta, BC002K24_A873MudanzaFechaUpdate, BC002K24_A738MudanzaFechaServicio, BC002K24_A739MudanzaHoraServicio,
               BC002K24_n739MudanzaHoraServicio, BC002K24_A776MudanzaRgoHoraservicio, BC002K24_n776MudanzaRgoHoraservicio, BC002K24_A740MudanzaDireccionOrigen, BC002K24_A788MudanzaLocalidadOrigen, BC002K24_A777MudanzaPisoDptoOrigen, BC002K24_A741MudanzaDireccionDestino, BC002K24_A789MudanzaLocalidadDestino, BC002K24_A778MudanzaPisoDptoDestino, BC002K24_A762MudanzaDistancia,
               BC002K24_A871MudanzaCoordenadaOrigen, BC002K24_A872MudanzaCoordenadaDestino, BC002K24_A742MudanzaVehiculoSugerido, BC002K24_A780MudanzaPrecioBasexHora, BC002K24_A761MudanzaPeajeCantidad, BC002K24_A783MudanzaComentario, BC002K24_A755TipoInmuebleOrigenNombre, BC002K24_A756TipoInmuebleOrigenValor, BC002K24_A794MudanzaOrigenMetodo, BC002K24_A746TipoInmuebleDestinoNombre,
               BC002K24_A757TipoInmuebleDestinoValor, BC002K24_A748TipoEstacionamOrigenNombre, BC002K24_A758TipoEstacionamOrigenValor, BC002K24_A750TipoEstacionamDestinoNombre, BC002K24_A795MudanzaDestinoMetodo, BC002K24_A759TipoEstacionamDestinoValor, BC002K24_A763MudanzaTiempoMaximo, BC002K24_A765MudanzaCargaVolumenEstimado, BC002K24_A782MudanzaAdicionalPrecio, BC002K24_A874MudanzaElevacion,
               BC002K24_A875MudanzaDescenso, BC002K24_A876MudanzaEmbalaje, BC002K24_A840MudanzaCantidadPeones, BC002K24_A764MudanzaPrecioFinal, BC002K24_A790MudanzaOperacionId, BC002K24_A791MudanzaFormaPago, BC002K24_A792MudanzaProveedorId, BC002K24_A837MudanzaSecUserId, BC002K24_A743TipoInmuebleOrigenId, BC002K24_A745TipoInmuebleDestinoId,
               BC002K24_A747TipoEstacionamOrigenId, BC002K24_A749TipoEstacionamDestinoId
               }
               , new Object[] {
               BC002K25_A735MudanzaId, BC002K25_A752ItemCargaNombre, BC002K25_A841ItemCargaDescripcion, BC002K25_A753ItemCargaCantidad, BC002K25_A813ItemCargaEmbCant, BC002K25_n813ItemCargaEmbCant, BC002K25_A815ItemCargaEmbalaje, BC002K25_A814ItemCargaElevCant, BC002K25_n814ItemCargaElevCant, BC002K25_A816ItemCargaElevacion,
               BC002K25_A754ItemCargaVolumen, BC002K25_A751ItemCargaId
               }
               , new Object[] {
               BC002K26_A735MudanzaId, BC002K26_A751ItemCargaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002K30_A752ItemCargaNombre, BC002K30_A841ItemCargaDescripcion, BC002K30_A754ItemCargaVolumen
               }
               , new Object[] {
               BC002K31_A735MudanzaId, BC002K31_A752ItemCargaNombre, BC002K31_A841ItemCargaDescripcion, BC002K31_A753ItemCargaCantidad, BC002K31_A813ItemCargaEmbCant, BC002K31_n813ItemCargaEmbCant, BC002K31_A815ItemCargaEmbalaje, BC002K31_A814ItemCargaElevCant, BC002K31_n814ItemCargaElevCant, BC002K31_A816ItemCargaElevacion,
               BC002K31_A754ItemCargaVolumen, BC002K31_A751ItemCargaId
               }
               , new Object[] {
               BC002K32_A735MudanzaId, BC002K32_A767ItemAdicionalNombre, BC002K32_A768ItemAdicionalCantidad, BC002K32_A769ItemAdicionalValor, BC002K32_A766ItemAdicionalId
               }
               , new Object[] {
               BC002K33_A735MudanzaId, BC002K33_A766ItemAdicionalId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002K37_A767ItemAdicionalNombre, BC002K37_A769ItemAdicionalValor
               }
               , new Object[] {
               BC002K38_A735MudanzaId, BC002K38_A767ItemAdicionalNombre, BC002K38_A768ItemAdicionalCantidad, BC002K38_A769ItemAdicionalValor, BC002K38_A766ItemAdicionalId
               }
            }
         );
         AV138Pgmname = "Mudanza_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122K2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_121 ;
      private short RcdFound121 ;
      private short nIsMod_120 ;
      private short RcdFound120 ;
      private short AV13Insert_TipoInmuebleOrigenId ;
      private short AV14Insert_TipoInmuebleDestinoId ;
      private short AV15Insert_TipoEstacionamOrigenId ;
      private short AV16Insert_TipoEstacionamDestinoId ;
      private short Z761MudanzaPeajeCantidad ;
      private short A761MudanzaPeajeCantidad ;
      private short Z874MudanzaElevacion ;
      private short A874MudanzaElevacion ;
      private short Z875MudanzaDescenso ;
      private short A875MudanzaDescenso ;
      private short Z876MudanzaEmbalaje ;
      private short A876MudanzaEmbalaje ;
      private short Z840MudanzaCantidadPeones ;
      private short A840MudanzaCantidadPeones ;
      private short Z743TipoInmuebleOrigenId ;
      private short A743TipoInmuebleOrigenId ;
      private short Z745TipoInmuebleDestinoId ;
      private short A745TipoInmuebleDestinoId ;
      private short Z747TipoEstacionamOrigenId ;
      private short A747TipoEstacionamOrigenId ;
      private short Z749TipoEstacionamDestinoId ;
      private short A749TipoEstacionamDestinoId ;
      private short RcdFound119 ;
      private short nRcdExists_120 ;
      private short nRcdExists_121 ;
      private short Z753ItemCargaCantidad ;
      private short A753ItemCargaCantidad ;
      private short Z813ItemCargaEmbCant ;
      private short A813ItemCargaEmbCant ;
      private short Z814ItemCargaElevCant ;
      private short A814ItemCargaElevCant ;
      private short Z751ItemCargaId ;
      private short A751ItemCargaId ;
      private short Gx_BScreen ;
      private short Gxremove120 ;
      private short Z768ItemAdicionalCantidad ;
      private short A768ItemAdicionalCantidad ;
      private short Z781ItemAdicionalValorCalculado ;
      private short A781ItemAdicionalValorCalculado ;
      private short Z766ItemAdicionalId ;
      private short A766ItemAdicionalId ;
      private short Gxremove121 ;
      private int trnEnded ;
      private int nGXsfl_121_idx=1 ;
      private int nGXsfl_120_idx=1 ;
      private int AV113ParametrosNumerico ;
      private int AV139GXV1 ;
      private int AV140GXV2 ;
      private long Z735MudanzaId ;
      private long A735MudanzaId ;
      private long Z790MudanzaOperacionId ;
      private long A790MudanzaOperacionId ;
      private long Z792MudanzaProveedorId ;
      private long A792MudanzaProveedorId ;
      private long Z837MudanzaSecUserId ;
      private long A837MudanzaSecUserId ;
      private decimal AV132TiempoxKm ;
      private decimal AV130PeonxHora ;
      private decimal AV134TiempoxM3 ;
      private decimal Z760MudanzaPeajevalor ;
      private decimal A760MudanzaPeajevalor ;
      private decimal Z762MudanzaDistancia ;
      private decimal A762MudanzaDistancia ;
      private decimal Z780MudanzaPrecioBasexHora ;
      private decimal A780MudanzaPrecioBasexHora ;
      private decimal Z763MudanzaTiempoMaximo ;
      private decimal A763MudanzaTiempoMaximo ;
      private decimal Z765MudanzaCargaVolumenEstimado ;
      private decimal A765MudanzaCargaVolumenEstimado ;
      private decimal Z782MudanzaAdicionalPrecio ;
      private decimal A782MudanzaAdicionalPrecio ;
      private decimal Z764MudanzaPrecioFinal ;
      private decimal A764MudanzaPrecioFinal ;
      private decimal Z756TipoInmuebleOrigenValor ;
      private decimal A756TipoInmuebleOrigenValor ;
      private decimal Z757TipoInmuebleDestinoValor ;
      private decimal A757TipoInmuebleDestinoValor ;
      private decimal Z758TipoEstacionamOrigenValor ;
      private decimal A758TipoEstacionamOrigenValor ;
      private decimal Z759TipoEstacionamDestinoValor ;
      private decimal A759TipoEstacionamDestinoValor ;
      private decimal GXt_decimal1 ;
      private decimal Z779ItemCargaVolumenCalculado ;
      private decimal A779ItemCargaVolumenCalculado ;
      private decimal Z754ItemCargaVolumen ;
      private decimal A754ItemCargaVolumen ;
      private decimal Z769ItemAdicionalValor ;
      private decimal A769ItemAdicionalValor ;
      private decimal i760MudanzaPeajevalor ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode119 ;
      private string AV114ParametrosEstado ;
      private string AV138Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Z786MudanzaPhone ;
      private string A786MudanzaPhone ;
      private string Z739MudanzaHoraServicio ;
      private string A739MudanzaHoraServicio ;
      private string Z776MudanzaRgoHoraservicio ;
      private string A776MudanzaRgoHoraservicio ;
      private string Z777MudanzaPisoDptoOrigen ;
      private string A777MudanzaPisoDptoOrigen ;
      private string Z778MudanzaPisoDptoDestino ;
      private string A778MudanzaPisoDptoDestino ;
      private string sMode120 ;
      private string sMode121 ;
      private DateTime Z737MudanzaFechaAlta ;
      private DateTime A737MudanzaFechaAlta ;
      private DateTime Z873MudanzaFechaUpdate ;
      private DateTime A873MudanzaFechaUpdate ;
      private DateTime Z738MudanzaFechaServicio ;
      private DateTime A738MudanzaFechaServicio ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean2 ;
      private bool AV128Terminos ;
      private bool n735MudanzaId ;
      private bool n739MudanzaHoraServicio ;
      private bool n776MudanzaRgoHoraservicio ;
      private bool Gx_longc ;
      private bool Z815ItemCargaEmbalaje ;
      private bool A815ItemCargaEmbalaje ;
      private bool Z816ItemCargaElevacion ;
      private bool A816ItemCargaElevacion ;
      private bool n813ItemCargaEmbCant ;
      private bool n814ItemCargaElevCant ;
      private string AV112USLPAGO ;
      private string AV115URLMAPA ;
      private string AV116Coordenadas ;
      private string AV117Token ;
      private string Z736MudanzaAsesor ;
      private string A736MudanzaAsesor ;
      private string Z784MudanzaApellidoNombre ;
      private string A784MudanzaApellidoNombre ;
      private string Z785MudanzaMail ;
      private string A785MudanzaMail ;
      private string Z740MudanzaDireccionOrigen ;
      private string A740MudanzaDireccionOrigen ;
      private string Z788MudanzaLocalidadOrigen ;
      private string A788MudanzaLocalidadOrigen ;
      private string Z741MudanzaDireccionDestino ;
      private string A741MudanzaDireccionDestino ;
      private string Z789MudanzaLocalidadDestino ;
      private string A789MudanzaLocalidadDestino ;
      private string Z871MudanzaCoordenadaOrigen ;
      private string A871MudanzaCoordenadaOrigen ;
      private string Z872MudanzaCoordenadaDestino ;
      private string A872MudanzaCoordenadaDestino ;
      private string Z742MudanzaVehiculoSugerido ;
      private string A742MudanzaVehiculoSugerido ;
      private string Z783MudanzaComentario ;
      private string A783MudanzaComentario ;
      private string Z794MudanzaOrigenMetodo ;
      private string A794MudanzaOrigenMetodo ;
      private string Z795MudanzaDestinoMetodo ;
      private string A795MudanzaDestinoMetodo ;
      private string Z791MudanzaFormaPago ;
      private string A791MudanzaFormaPago ;
      private string Z755TipoInmuebleOrigenNombre ;
      private string A755TipoInmuebleOrigenNombre ;
      private string Z746TipoInmuebleDestinoNombre ;
      private string A746TipoInmuebleDestinoNombre ;
      private string Z748TipoEstacionamOrigenNombre ;
      private string A748TipoEstacionamOrigenNombre ;
      private string Z750TipoEstacionamDestinoNombre ;
      private string A750TipoEstacionamDestinoNombre ;
      private string Z752ItemCargaNombre ;
      private string A752ItemCargaNombre ;
      private string Z841ItemCargaDescripcion ;
      private string A841ItemCargaDescripcion ;
      private string Z767ItemAdicionalNombre ;
      private string A767ItemAdicionalNombre ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtMudanza bcMudanza ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private decimal[] BC002K14_A760MudanzaPeajevalor ;
      private long[] BC002K14_A735MudanzaId ;
      private bool[] BC002K14_n735MudanzaId ;
      private string[] BC002K14_A736MudanzaAsesor ;
      private string[] BC002K14_A784MudanzaApellidoNombre ;
      private string[] BC002K14_A785MudanzaMail ;
      private string[] BC002K14_A786MudanzaPhone ;
      private DateTime[] BC002K14_A737MudanzaFechaAlta ;
      private DateTime[] BC002K14_A873MudanzaFechaUpdate ;
      private DateTime[] BC002K14_A738MudanzaFechaServicio ;
      private string[] BC002K14_A739MudanzaHoraServicio ;
      private bool[] BC002K14_n739MudanzaHoraServicio ;
      private string[] BC002K14_A776MudanzaRgoHoraservicio ;
      private bool[] BC002K14_n776MudanzaRgoHoraservicio ;
      private string[] BC002K14_A740MudanzaDireccionOrigen ;
      private string[] BC002K14_A788MudanzaLocalidadOrigen ;
      private string[] BC002K14_A777MudanzaPisoDptoOrigen ;
      private string[] BC002K14_A741MudanzaDireccionDestino ;
      private string[] BC002K14_A789MudanzaLocalidadDestino ;
      private string[] BC002K14_A778MudanzaPisoDptoDestino ;
      private decimal[] BC002K14_A762MudanzaDistancia ;
      private string[] BC002K14_A871MudanzaCoordenadaOrigen ;
      private string[] BC002K14_A872MudanzaCoordenadaDestino ;
      private string[] BC002K14_A742MudanzaVehiculoSugerido ;
      private decimal[] BC002K14_A780MudanzaPrecioBasexHora ;
      private short[] BC002K14_A761MudanzaPeajeCantidad ;
      private string[] BC002K14_A783MudanzaComentario ;
      private string[] BC002K14_A755TipoInmuebleOrigenNombre ;
      private decimal[] BC002K14_A756TipoInmuebleOrigenValor ;
      private string[] BC002K14_A794MudanzaOrigenMetodo ;
      private string[] BC002K14_A746TipoInmuebleDestinoNombre ;
      private decimal[] BC002K14_A757TipoInmuebleDestinoValor ;
      private string[] BC002K14_A748TipoEstacionamOrigenNombre ;
      private decimal[] BC002K14_A758TipoEstacionamOrigenValor ;
      private string[] BC002K14_A750TipoEstacionamDestinoNombre ;
      private string[] BC002K14_A795MudanzaDestinoMetodo ;
      private decimal[] BC002K14_A759TipoEstacionamDestinoValor ;
      private decimal[] BC002K14_A763MudanzaTiempoMaximo ;
      private decimal[] BC002K14_A765MudanzaCargaVolumenEstimado ;
      private decimal[] BC002K14_A782MudanzaAdicionalPrecio ;
      private short[] BC002K14_A874MudanzaElevacion ;
      private short[] BC002K14_A875MudanzaDescenso ;
      private short[] BC002K14_A876MudanzaEmbalaje ;
      private short[] BC002K14_A840MudanzaCantidadPeones ;
      private decimal[] BC002K14_A764MudanzaPrecioFinal ;
      private long[] BC002K14_A790MudanzaOperacionId ;
      private string[] BC002K14_A791MudanzaFormaPago ;
      private long[] BC002K14_A792MudanzaProveedorId ;
      private long[] BC002K14_A837MudanzaSecUserId ;
      private short[] BC002K14_A743TipoInmuebleOrigenId ;
      private short[] BC002K14_A745TipoInmuebleDestinoId ;
      private short[] BC002K14_A747TipoEstacionamOrigenId ;
      private short[] BC002K14_A749TipoEstacionamDestinoId ;
      private string[] BC002K10_A755TipoInmuebleOrigenNombre ;
      private decimal[] BC002K10_A756TipoInmuebleOrigenValor ;
      private string[] BC002K11_A746TipoInmuebleDestinoNombre ;
      private decimal[] BC002K11_A757TipoInmuebleDestinoValor ;
      private string[] BC002K12_A748TipoEstacionamOrigenNombre ;
      private decimal[] BC002K12_A758TipoEstacionamOrigenValor ;
      private string[] BC002K13_A750TipoEstacionamDestinoNombre ;
      private decimal[] BC002K13_A759TipoEstacionamDestinoValor ;
      private long[] BC002K15_A735MudanzaId ;
      private bool[] BC002K15_n735MudanzaId ;
      private decimal[] BC002K9_A760MudanzaPeajevalor ;
      private long[] BC002K9_A735MudanzaId ;
      private bool[] BC002K9_n735MudanzaId ;
      private string[] BC002K9_A736MudanzaAsesor ;
      private string[] BC002K9_A784MudanzaApellidoNombre ;
      private string[] BC002K9_A785MudanzaMail ;
      private string[] BC002K9_A786MudanzaPhone ;
      private DateTime[] BC002K9_A737MudanzaFechaAlta ;
      private DateTime[] BC002K9_A873MudanzaFechaUpdate ;
      private DateTime[] BC002K9_A738MudanzaFechaServicio ;
      private string[] BC002K9_A739MudanzaHoraServicio ;
      private bool[] BC002K9_n739MudanzaHoraServicio ;
      private string[] BC002K9_A776MudanzaRgoHoraservicio ;
      private bool[] BC002K9_n776MudanzaRgoHoraservicio ;
      private string[] BC002K9_A740MudanzaDireccionOrigen ;
      private string[] BC002K9_A788MudanzaLocalidadOrigen ;
      private string[] BC002K9_A777MudanzaPisoDptoOrigen ;
      private string[] BC002K9_A741MudanzaDireccionDestino ;
      private string[] BC002K9_A789MudanzaLocalidadDestino ;
      private string[] BC002K9_A778MudanzaPisoDptoDestino ;
      private decimal[] BC002K9_A762MudanzaDistancia ;
      private string[] BC002K9_A871MudanzaCoordenadaOrigen ;
      private string[] BC002K9_A872MudanzaCoordenadaDestino ;
      private string[] BC002K9_A742MudanzaVehiculoSugerido ;
      private decimal[] BC002K9_A780MudanzaPrecioBasexHora ;
      private short[] BC002K9_A761MudanzaPeajeCantidad ;
      private string[] BC002K9_A783MudanzaComentario ;
      private string[] BC002K9_A794MudanzaOrigenMetodo ;
      private string[] BC002K9_A795MudanzaDestinoMetodo ;
      private decimal[] BC002K9_A763MudanzaTiempoMaximo ;
      private decimal[] BC002K9_A765MudanzaCargaVolumenEstimado ;
      private decimal[] BC002K9_A782MudanzaAdicionalPrecio ;
      private short[] BC002K9_A874MudanzaElevacion ;
      private short[] BC002K9_A875MudanzaDescenso ;
      private short[] BC002K9_A876MudanzaEmbalaje ;
      private short[] BC002K9_A840MudanzaCantidadPeones ;
      private decimal[] BC002K9_A764MudanzaPrecioFinal ;
      private long[] BC002K9_A790MudanzaOperacionId ;
      private string[] BC002K9_A791MudanzaFormaPago ;
      private long[] BC002K9_A792MudanzaProveedorId ;
      private long[] BC002K9_A837MudanzaSecUserId ;
      private short[] BC002K9_A743TipoInmuebleOrigenId ;
      private short[] BC002K9_A745TipoInmuebleDestinoId ;
      private short[] BC002K9_A747TipoEstacionamOrigenId ;
      private short[] BC002K9_A749TipoEstacionamDestinoId ;
      private decimal[] BC002K8_A760MudanzaPeajevalor ;
      private long[] BC002K8_A735MudanzaId ;
      private bool[] BC002K8_n735MudanzaId ;
      private string[] BC002K8_A736MudanzaAsesor ;
      private string[] BC002K8_A784MudanzaApellidoNombre ;
      private string[] BC002K8_A785MudanzaMail ;
      private string[] BC002K8_A786MudanzaPhone ;
      private DateTime[] BC002K8_A737MudanzaFechaAlta ;
      private DateTime[] BC002K8_A873MudanzaFechaUpdate ;
      private DateTime[] BC002K8_A738MudanzaFechaServicio ;
      private string[] BC002K8_A739MudanzaHoraServicio ;
      private bool[] BC002K8_n739MudanzaHoraServicio ;
      private string[] BC002K8_A776MudanzaRgoHoraservicio ;
      private bool[] BC002K8_n776MudanzaRgoHoraservicio ;
      private string[] BC002K8_A740MudanzaDireccionOrigen ;
      private string[] BC002K8_A788MudanzaLocalidadOrigen ;
      private string[] BC002K8_A777MudanzaPisoDptoOrigen ;
      private string[] BC002K8_A741MudanzaDireccionDestino ;
      private string[] BC002K8_A789MudanzaLocalidadDestino ;
      private string[] BC002K8_A778MudanzaPisoDptoDestino ;
      private decimal[] BC002K8_A762MudanzaDistancia ;
      private string[] BC002K8_A871MudanzaCoordenadaOrigen ;
      private string[] BC002K8_A872MudanzaCoordenadaDestino ;
      private string[] BC002K8_A742MudanzaVehiculoSugerido ;
      private decimal[] BC002K8_A780MudanzaPrecioBasexHora ;
      private short[] BC002K8_A761MudanzaPeajeCantidad ;
      private string[] BC002K8_A783MudanzaComentario ;
      private string[] BC002K8_A794MudanzaOrigenMetodo ;
      private string[] BC002K8_A795MudanzaDestinoMetodo ;
      private decimal[] BC002K8_A763MudanzaTiempoMaximo ;
      private decimal[] BC002K8_A765MudanzaCargaVolumenEstimado ;
      private decimal[] BC002K8_A782MudanzaAdicionalPrecio ;
      private short[] BC002K8_A874MudanzaElevacion ;
      private short[] BC002K8_A875MudanzaDescenso ;
      private short[] BC002K8_A876MudanzaEmbalaje ;
      private short[] BC002K8_A840MudanzaCantidadPeones ;
      private decimal[] BC002K8_A764MudanzaPrecioFinal ;
      private long[] BC002K8_A790MudanzaOperacionId ;
      private string[] BC002K8_A791MudanzaFormaPago ;
      private long[] BC002K8_A792MudanzaProveedorId ;
      private long[] BC002K8_A837MudanzaSecUserId ;
      private short[] BC002K8_A743TipoInmuebleOrigenId ;
      private short[] BC002K8_A745TipoInmuebleDestinoId ;
      private short[] BC002K8_A747TipoEstacionamOrigenId ;
      private short[] BC002K8_A749TipoEstacionamDestinoId ;
      private long[] BC002K16_A735MudanzaId ;
      private bool[] BC002K16_n735MudanzaId ;
      private string[] BC002K19_A755TipoInmuebleOrigenNombre ;
      private decimal[] BC002K19_A756TipoInmuebleOrigenValor ;
      private string[] BC002K20_A746TipoInmuebleDestinoNombre ;
      private decimal[] BC002K20_A757TipoInmuebleDestinoValor ;
      private string[] BC002K21_A748TipoEstacionamOrigenNombre ;
      private decimal[] BC002K21_A758TipoEstacionamOrigenValor ;
      private string[] BC002K22_A750TipoEstacionamDestinoNombre ;
      private decimal[] BC002K22_A759TipoEstacionamDestinoValor ;
      private long[] BC002K23_A127SolicitudesID ;
      private decimal[] BC002K24_A760MudanzaPeajevalor ;
      private long[] BC002K24_A735MudanzaId ;
      private bool[] BC002K24_n735MudanzaId ;
      private string[] BC002K24_A736MudanzaAsesor ;
      private string[] BC002K24_A784MudanzaApellidoNombre ;
      private string[] BC002K24_A785MudanzaMail ;
      private string[] BC002K24_A786MudanzaPhone ;
      private DateTime[] BC002K24_A737MudanzaFechaAlta ;
      private DateTime[] BC002K24_A873MudanzaFechaUpdate ;
      private DateTime[] BC002K24_A738MudanzaFechaServicio ;
      private string[] BC002K24_A739MudanzaHoraServicio ;
      private bool[] BC002K24_n739MudanzaHoraServicio ;
      private string[] BC002K24_A776MudanzaRgoHoraservicio ;
      private bool[] BC002K24_n776MudanzaRgoHoraservicio ;
      private string[] BC002K24_A740MudanzaDireccionOrigen ;
      private string[] BC002K24_A788MudanzaLocalidadOrigen ;
      private string[] BC002K24_A777MudanzaPisoDptoOrigen ;
      private string[] BC002K24_A741MudanzaDireccionDestino ;
      private string[] BC002K24_A789MudanzaLocalidadDestino ;
      private string[] BC002K24_A778MudanzaPisoDptoDestino ;
      private decimal[] BC002K24_A762MudanzaDistancia ;
      private string[] BC002K24_A871MudanzaCoordenadaOrigen ;
      private string[] BC002K24_A872MudanzaCoordenadaDestino ;
      private string[] BC002K24_A742MudanzaVehiculoSugerido ;
      private decimal[] BC002K24_A780MudanzaPrecioBasexHora ;
      private short[] BC002K24_A761MudanzaPeajeCantidad ;
      private string[] BC002K24_A783MudanzaComentario ;
      private string[] BC002K24_A755TipoInmuebleOrigenNombre ;
      private decimal[] BC002K24_A756TipoInmuebleOrigenValor ;
      private string[] BC002K24_A794MudanzaOrigenMetodo ;
      private string[] BC002K24_A746TipoInmuebleDestinoNombre ;
      private decimal[] BC002K24_A757TipoInmuebleDestinoValor ;
      private string[] BC002K24_A748TipoEstacionamOrigenNombre ;
      private decimal[] BC002K24_A758TipoEstacionamOrigenValor ;
      private string[] BC002K24_A750TipoEstacionamDestinoNombre ;
      private string[] BC002K24_A795MudanzaDestinoMetodo ;
      private decimal[] BC002K24_A759TipoEstacionamDestinoValor ;
      private decimal[] BC002K24_A763MudanzaTiempoMaximo ;
      private decimal[] BC002K24_A765MudanzaCargaVolumenEstimado ;
      private decimal[] BC002K24_A782MudanzaAdicionalPrecio ;
      private short[] BC002K24_A874MudanzaElevacion ;
      private short[] BC002K24_A875MudanzaDescenso ;
      private short[] BC002K24_A876MudanzaEmbalaje ;
      private short[] BC002K24_A840MudanzaCantidadPeones ;
      private decimal[] BC002K24_A764MudanzaPrecioFinal ;
      private long[] BC002K24_A790MudanzaOperacionId ;
      private string[] BC002K24_A791MudanzaFormaPago ;
      private long[] BC002K24_A792MudanzaProveedorId ;
      private long[] BC002K24_A837MudanzaSecUserId ;
      private short[] BC002K24_A743TipoInmuebleOrigenId ;
      private short[] BC002K24_A745TipoInmuebleDestinoId ;
      private short[] BC002K24_A747TipoEstacionamOrigenId ;
      private short[] BC002K24_A749TipoEstacionamDestinoId ;
      private long[] BC002K25_A735MudanzaId ;
      private bool[] BC002K25_n735MudanzaId ;
      private string[] BC002K25_A752ItemCargaNombre ;
      private string[] BC002K25_A841ItemCargaDescripcion ;
      private short[] BC002K25_A753ItemCargaCantidad ;
      private short[] BC002K25_A813ItemCargaEmbCant ;
      private bool[] BC002K25_n813ItemCargaEmbCant ;
      private bool[] BC002K25_A815ItemCargaEmbalaje ;
      private short[] BC002K25_A814ItemCargaElevCant ;
      private bool[] BC002K25_n814ItemCargaElevCant ;
      private bool[] BC002K25_A816ItemCargaElevacion ;
      private decimal[] BC002K25_A754ItemCargaVolumen ;
      private short[] BC002K25_A751ItemCargaId ;
      private string[] BC002K7_A752ItemCargaNombre ;
      private string[] BC002K7_A841ItemCargaDescripcion ;
      private decimal[] BC002K7_A754ItemCargaVolumen ;
      private long[] BC002K26_A735MudanzaId ;
      private bool[] BC002K26_n735MudanzaId ;
      private short[] BC002K26_A751ItemCargaId ;
      private long[] BC002K6_A735MudanzaId ;
      private bool[] BC002K6_n735MudanzaId ;
      private short[] BC002K6_A753ItemCargaCantidad ;
      private short[] BC002K6_A813ItemCargaEmbCant ;
      private bool[] BC002K6_n813ItemCargaEmbCant ;
      private bool[] BC002K6_A815ItemCargaEmbalaje ;
      private short[] BC002K6_A814ItemCargaElevCant ;
      private bool[] BC002K6_n814ItemCargaElevCant ;
      private bool[] BC002K6_A816ItemCargaElevacion ;
      private short[] BC002K6_A751ItemCargaId ;
      private long[] BC002K5_A735MudanzaId ;
      private bool[] BC002K5_n735MudanzaId ;
      private short[] BC002K5_A753ItemCargaCantidad ;
      private short[] BC002K5_A813ItemCargaEmbCant ;
      private bool[] BC002K5_n813ItemCargaEmbCant ;
      private bool[] BC002K5_A815ItemCargaEmbalaje ;
      private short[] BC002K5_A814ItemCargaElevCant ;
      private bool[] BC002K5_n814ItemCargaElevCant ;
      private bool[] BC002K5_A816ItemCargaElevacion ;
      private short[] BC002K5_A751ItemCargaId ;
      private string[] BC002K30_A752ItemCargaNombre ;
      private string[] BC002K30_A841ItemCargaDescripcion ;
      private decimal[] BC002K30_A754ItemCargaVolumen ;
      private long[] BC002K31_A735MudanzaId ;
      private bool[] BC002K31_n735MudanzaId ;
      private string[] BC002K31_A752ItemCargaNombre ;
      private string[] BC002K31_A841ItemCargaDescripcion ;
      private short[] BC002K31_A753ItemCargaCantidad ;
      private short[] BC002K31_A813ItemCargaEmbCant ;
      private bool[] BC002K31_n813ItemCargaEmbCant ;
      private bool[] BC002K31_A815ItemCargaEmbalaje ;
      private short[] BC002K31_A814ItemCargaElevCant ;
      private bool[] BC002K31_n814ItemCargaElevCant ;
      private bool[] BC002K31_A816ItemCargaElevacion ;
      private decimal[] BC002K31_A754ItemCargaVolumen ;
      private short[] BC002K31_A751ItemCargaId ;
      private long[] BC002K32_A735MudanzaId ;
      private bool[] BC002K32_n735MudanzaId ;
      private string[] BC002K32_A767ItemAdicionalNombre ;
      private short[] BC002K32_A768ItemAdicionalCantidad ;
      private decimal[] BC002K32_A769ItemAdicionalValor ;
      private short[] BC002K32_A766ItemAdicionalId ;
      private string[] BC002K4_A767ItemAdicionalNombre ;
      private decimal[] BC002K4_A769ItemAdicionalValor ;
      private long[] BC002K33_A735MudanzaId ;
      private bool[] BC002K33_n735MudanzaId ;
      private short[] BC002K33_A766ItemAdicionalId ;
      private long[] BC002K3_A735MudanzaId ;
      private bool[] BC002K3_n735MudanzaId ;
      private short[] BC002K3_A768ItemAdicionalCantidad ;
      private short[] BC002K3_A766ItemAdicionalId ;
      private long[] BC002K2_A735MudanzaId ;
      private bool[] BC002K2_n735MudanzaId ;
      private short[] BC002K2_A768ItemAdicionalCantidad ;
      private short[] BC002K2_A766ItemAdicionalId ;
      private string[] BC002K37_A767ItemAdicionalNombre ;
      private decimal[] BC002K37_A769ItemAdicionalValor ;
      private long[] BC002K38_A735MudanzaId ;
      private bool[] BC002K38_n735MudanzaId ;
      private string[] BC002K38_A767ItemAdicionalNombre ;
      private short[] BC002K38_A768ItemAdicionalCantidad ;
      private decimal[] BC002K38_A769ItemAdicionalValor ;
      private short[] BC002K38_A766ItemAdicionalId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class mudanza_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class mudanza_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[25])
       ,new UpdateCursor(def[26])
       ,new UpdateCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new UpdateCursor(def[32])
       ,new UpdateCursor(def[33])
       ,new UpdateCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC002K2;
        prmBC002K2 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ItemAdicionalId",GXType.Int16,4,0)
        };
        Object[] prmBC002K3;
        prmBC002K3 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ItemAdicionalId",GXType.Int16,4,0)
        };
        Object[] prmBC002K4;
        prmBC002K4 = new Object[] {
        new ParDef("@ItemAdicionalId",GXType.Int16,4,0)
        };
        Object[] prmBC002K5;
        prmBC002K5 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0)
        };
        Object[] prmBC002K6;
        prmBC002K6 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0)
        };
        Object[] prmBC002K7;
        prmBC002K7 = new Object[] {
        new ParDef("@ItemCargaId",GXType.Int16,4,0)
        };
        Object[] prmBC002K8;
        prmBC002K8 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC002K9;
        prmBC002K9 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC002K10;
        prmBC002K10 = new Object[] {
        new ParDef("@TipoInmuebleOrigenId",GXType.Int16,4,0)
        };
        Object[] prmBC002K11;
        prmBC002K11 = new Object[] {
        new ParDef("@TipoInmuebleDestinoId",GXType.Int16,4,0)
        };
        Object[] prmBC002K12;
        prmBC002K12 = new Object[] {
        new ParDef("@TipoEstacionamOrigenId",GXType.Int16,4,0)
        };
        Object[] prmBC002K13;
        prmBC002K13 = new Object[] {
        new ParDef("@TipoEstacionamDestinoId",GXType.Int16,4,0)
        };
        Object[] prmBC002K14;
        prmBC002K14 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true}
        };
        string cmdBufferBC002K14;
        cmdBufferBC002K14=" SELECT TM1.[MudanzaPeajevalor], TM1.[MudanzaId], TM1.[MudanzaAsesor], TM1.[MudanzaApellidoNombre], TM1.[MudanzaMail], TM1.[MudanzaPhone], TM1.[MudanzaFechaAlta], TM1.[MudanzaFechaUpdate], TM1.[MudanzaFechaServicio], TM1.[MudanzaHoraServicio], TM1.[MudanzaRgoHoraservicio], TM1.[MudanzaDireccionOrigen], TM1.[MudanzaLocalidadOrigen], TM1.[MudanzaPisoDptoOrigen], TM1.[MudanzaDireccionDestino], TM1.[MudanzaLocalidadDestino], TM1.[MudanzaPisoDptoDestino], TM1.[MudanzaDistancia], TM1.[MudanzaCoordenadaOrigen], TM1.[MudanzaCoordenadaDestino], TM1.[MudanzaVehiculoSugerido], TM1.[MudanzaPrecioBasexHora], TM1.[MudanzaPeajeCantidad], TM1.[MudanzaComentario], T2.[ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre, T2.[ParametroMudanzaValor] AS TipoInmuebleOrigenValor, TM1.[MudanzaOrigenMetodo], T3.[ParametroMudanzaNombre] AS TipoInmuebleDestinoNombre, T3.[ParametroMudanzaValor] AS TipoInmuebleDestinoValor, T4.[ParametroMudanzaNombre] AS TipoEstacionamOrigenNombre, T4.[ParametroMudanzaValor] AS TipoEstacionamOrigenValor, T5.[ParametroMudanzaNombre] AS TipoEstacionamDestinoNombre, TM1.[MudanzaDestinoMetodo], T5.[ParametroMudanzaValor] AS TipoEstacionamDestinoValor, TM1.[MudanzaTiempoMaximo], TM1.[MudanzaCargaVolumenEstimado], TM1.[MudanzaAdicionalPrecio], TM1.[MudanzaElevacion], TM1.[MudanzaDescenso], TM1.[MudanzaEmbalaje], TM1.[MudanzaCantidadPeones], TM1.[MudanzaPrecioFinal], TM1.[MudanzaOperacionId], TM1.[MudanzaFormaPago], TM1.[MudanzaProveedorId], TM1.[MudanzaSecUserId], TM1.[TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, TM1.[TipoInmuebleDestinoId] AS TipoInmuebleDestinoId, TM1.[TipoEstacionamOrigenId] AS TipoEstacionamOrigenId, TM1.[TipoEstacionamDestinoId] AS TipoEstacionamDestinoId FROM (((([Mudanza] TM1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = TM1.[TipoInmuebleOrigenId]) "
        + " INNER JOIN [ParametroMudanza] T3 ON T3.[ParametroMudanzaId] = TM1.[TipoInmuebleDestinoId]) INNER JOIN [ParametroMudanza] T4 ON T4.[ParametroMudanzaId] = TM1.[TipoEstacionamOrigenId]) INNER JOIN [ParametroMudanza] T5 ON T5.[ParametroMudanzaId] = TM1.[TipoEstacionamDestinoId]) WHERE TM1.[MudanzaId] = @MudanzaId ORDER BY TM1.[MudanzaId]  OPTION (FAST 100)" ;
        Object[] prmBC002K15;
        prmBC002K15 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC002K16;
        prmBC002K16 = new Object[] {
        new ParDef("@MudanzaPeajevalor",GXType.Decimal,18,2) ,
        new ParDef("@MudanzaAsesor",GXType.NVarChar,80,0) ,
        new ParDef("@MudanzaApellidoNombre",GXType.NVarChar,80,0) ,
        new ParDef("@MudanzaMail",GXType.NVarChar,100,0) ,
        new ParDef("@MudanzaPhone",GXType.NChar,20,0) ,
        new ParDef("@MudanzaFechaAlta",GXType.Date,8,0) ,
        new ParDef("@MudanzaFechaUpdate",GXType.Date,8,0) ,
        new ParDef("@MudanzaFechaServicio",GXType.Date,8,0) ,
        new ParDef("@MudanzaHoraServicio",GXType.NChar,2,5){Nullable=true} ,
        new ParDef("@MudanzaRgoHoraservicio",GXType.NChar,5,0){Nullable=true} ,
        new ParDef("@MudanzaDireccionOrigen",GXType.NVarChar,200,0) ,
        new ParDef("@MudanzaLocalidadOrigen",GXType.NVarChar,100,0) ,
        new ParDef("@MudanzaPisoDptoOrigen",GXType.NChar,30,0) ,
        new ParDef("@MudanzaDireccionDestino",GXType.NVarChar,200,0) ,
        new ParDef("@MudanzaLocalidadDestino",GXType.NVarChar,100,0) ,
        new ParDef("@MudanzaPisoDptoDestino",GXType.NChar,30,0) ,
        new ParDef("@MudanzaDistancia",GXType.Decimal,10,2) ,
        new ParDef("@MudanzaCoordenadaOrigen",GXType.NVarChar,80,0) ,
        new ParDef("@MudanzaCoordenadaDestino",GXType.NVarChar,80,0) ,
        new ParDef("@MudanzaVehiculoSugerido",GXType.NVarChar,100,0) ,
        new ParDef("@MudanzaPrecioBasexHora",GXType.Decimal,18,2) ,
        new ParDef("@MudanzaPeajeCantidad",GXType.Int16,1,0) ,
        new ParDef("@MudanzaComentario",GXType.NVarChar,250,0) ,
        new ParDef("@MudanzaOrigenMetodo",GXType.NVarChar,8,0) ,
        new ParDef("@MudanzaDestinoMetodo",GXType.NVarChar,8,0) ,
        new ParDef("@MudanzaTiempoMaximo",GXType.Decimal,18,2) ,
        new ParDef("@MudanzaCargaVolumenEstimado",GXType.Decimal,18,2) ,
        new ParDef("@MudanzaAdicionalPrecio",GXType.Decimal,18,2) ,
        new ParDef("@MudanzaElevacion",GXType.Int16,4,0) ,
        new ParDef("@MudanzaDescenso",GXType.Int16,4,0) ,
        new ParDef("@MudanzaEmbalaje",GXType.Int16,4,0) ,
        new ParDef("@MudanzaCantidadPeones",GXType.Int16,4,0) ,
        new ParDef("@MudanzaPrecioFinal",GXType.Decimal,18,2) ,
        new ParDef("@MudanzaOperacionId",GXType.Decimal,18,0) ,
        new ParDef("@MudanzaFormaPago",GXType.NVarChar,8,0) ,
        new ParDef("@MudanzaProveedorId",GXType.Decimal,18,0) ,
        new ParDef("@MudanzaSecUserId",GXType.Decimal,10,0) ,
        new ParDef("@TipoInmuebleOrigenId",GXType.Int16,4,0) ,
        new ParDef("@TipoInmuebleDestinoId",GXType.Int16,4,0) ,
        new ParDef("@TipoEstacionamOrigenId",GXType.Int16,4,0) ,
        new ParDef("@TipoEstacionamDestinoId",GXType.Int16,4,0)
        };
        string cmdBufferBC002K16;
        cmdBufferBC002K16=" INSERT INTO [Mudanza]([MudanzaPeajevalor], [MudanzaAsesor], [MudanzaApellidoNombre], [MudanzaMail], [MudanzaPhone], [MudanzaFechaAlta], [MudanzaFechaUpdate], [MudanzaFechaServicio], [MudanzaHoraServicio], [MudanzaRgoHoraservicio], [MudanzaDireccionOrigen], [MudanzaLocalidadOrigen], [MudanzaPisoDptoOrigen], [MudanzaDireccionDestino], [MudanzaLocalidadDestino], [MudanzaPisoDptoDestino], [MudanzaDistancia], [MudanzaCoordenadaOrigen], [MudanzaCoordenadaDestino], [MudanzaVehiculoSugerido], [MudanzaPrecioBasexHora], [MudanzaPeajeCantidad], [MudanzaComentario], [MudanzaOrigenMetodo], [MudanzaDestinoMetodo], [MudanzaTiempoMaximo], [MudanzaCargaVolumenEstimado], [MudanzaAdicionalPrecio], [MudanzaElevacion], [MudanzaDescenso], [MudanzaEmbalaje], [MudanzaCantidadPeones], [MudanzaPrecioFinal], [MudanzaOperacionId], [MudanzaFormaPago], [MudanzaProveedorId], [MudanzaSecUserId], [TipoInmuebleOrigenId], [TipoInmuebleDestinoId], [TipoEstacionamOrigenId], [TipoEstacionamDestinoId]) VALUES(@MudanzaPeajevalor, @MudanzaAsesor, @MudanzaApellidoNombre, @MudanzaMail, @MudanzaPhone, @MudanzaFechaAlta, @MudanzaFechaUpdate, @MudanzaFechaServicio, @MudanzaHoraServicio, @MudanzaRgoHoraservicio, @MudanzaDireccionOrigen, @MudanzaLocalidadOrigen, @MudanzaPisoDptoOrigen, @MudanzaDireccionDestino, @MudanzaLocalidadDestino, @MudanzaPisoDptoDestino, @MudanzaDistancia, @MudanzaCoordenadaOrigen, @MudanzaCoordenadaDestino, @MudanzaVehiculoSugerido, @MudanzaPrecioBasexHora, @MudanzaPeajeCantidad, @MudanzaComentario, @MudanzaOrigenMetodo, @MudanzaDestinoMetodo, @MudanzaTiempoMaximo, @MudanzaCargaVolumenEstimado, @MudanzaAdicionalPrecio, @MudanzaElevacion, @MudanzaDescenso, @MudanzaEmbalaje, @MudanzaCantidadPeones, @MudanzaPrecioFinal, @MudanzaOperacionId, @MudanzaFormaPago, @MudanzaProveedorId, @MudanzaSecUserId, "
        + " @TipoInmuebleOrigenId, @TipoInmuebleDestinoId, @TipoEstacionamOrigenId, @TipoEstacionamDestinoId); SELECT SCOPE_IDENTITY()" ;
        Object[] prmBC002K17;
        prmBC002K17 = new Object[] {
        new ParDef("@MudanzaPeajevalor",GXType.Decimal,18,2) ,
        new ParDef("@MudanzaAsesor",GXType.NVarChar,80,0) ,
        new ParDef("@MudanzaApellidoNombre",GXType.NVarChar,80,0) ,
        new ParDef("@MudanzaMail",GXType.NVarChar,100,0) ,
        new ParDef("@MudanzaPhone",GXType.NChar,20,0) ,
        new ParDef("@MudanzaFechaAlta",GXType.Date,8,0) ,
        new ParDef("@MudanzaFechaUpdate",GXType.Date,8,0) ,
        new ParDef("@MudanzaFechaServicio",GXType.Date,8,0) ,
        new ParDef("@MudanzaHoraServicio",GXType.NChar,2,5){Nullable=true} ,
        new ParDef("@MudanzaRgoHoraservicio",GXType.NChar,5,0){Nullable=true} ,
        new ParDef("@MudanzaDireccionOrigen",GXType.NVarChar,200,0) ,
        new ParDef("@MudanzaLocalidadOrigen",GXType.NVarChar,100,0) ,
        new ParDef("@MudanzaPisoDptoOrigen",GXType.NChar,30,0) ,
        new ParDef("@MudanzaDireccionDestino",GXType.NVarChar,200,0) ,
        new ParDef("@MudanzaLocalidadDestino",GXType.NVarChar,100,0) ,
        new ParDef("@MudanzaPisoDptoDestino",GXType.NChar,30,0) ,
        new ParDef("@MudanzaDistancia",GXType.Decimal,10,2) ,
        new ParDef("@MudanzaCoordenadaOrigen",GXType.NVarChar,80,0) ,
        new ParDef("@MudanzaCoordenadaDestino",GXType.NVarChar,80,0) ,
        new ParDef("@MudanzaVehiculoSugerido",GXType.NVarChar,100,0) ,
        new ParDef("@MudanzaPrecioBasexHora",GXType.Decimal,18,2) ,
        new ParDef("@MudanzaPeajeCantidad",GXType.Int16,1,0) ,
        new ParDef("@MudanzaComentario",GXType.NVarChar,250,0) ,
        new ParDef("@MudanzaOrigenMetodo",GXType.NVarChar,8,0) ,
        new ParDef("@MudanzaDestinoMetodo",GXType.NVarChar,8,0) ,
        new ParDef("@MudanzaTiempoMaximo",GXType.Decimal,18,2) ,
        new ParDef("@MudanzaCargaVolumenEstimado",GXType.Decimal,18,2) ,
        new ParDef("@MudanzaAdicionalPrecio",GXType.Decimal,18,2) ,
        new ParDef("@MudanzaElevacion",GXType.Int16,4,0) ,
        new ParDef("@MudanzaDescenso",GXType.Int16,4,0) ,
        new ParDef("@MudanzaEmbalaje",GXType.Int16,4,0) ,
        new ParDef("@MudanzaCantidadPeones",GXType.Int16,4,0) ,
        new ParDef("@MudanzaPrecioFinal",GXType.Decimal,18,2) ,
        new ParDef("@MudanzaOperacionId",GXType.Decimal,18,0) ,
        new ParDef("@MudanzaFormaPago",GXType.NVarChar,8,0) ,
        new ParDef("@MudanzaProveedorId",GXType.Decimal,18,0) ,
        new ParDef("@MudanzaSecUserId",GXType.Decimal,10,0) ,
        new ParDef("@TipoInmuebleOrigenId",GXType.Int16,4,0) ,
        new ParDef("@TipoInmuebleDestinoId",GXType.Int16,4,0) ,
        new ParDef("@TipoEstacionamOrigenId",GXType.Int16,4,0) ,
        new ParDef("@TipoEstacionamDestinoId",GXType.Int16,4,0) ,
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true}
        };
        string cmdBufferBC002K17;
        cmdBufferBC002K17=" UPDATE [Mudanza] SET [MudanzaPeajevalor]=@MudanzaPeajevalor, [MudanzaAsesor]=@MudanzaAsesor, [MudanzaApellidoNombre]=@MudanzaApellidoNombre, [MudanzaMail]=@MudanzaMail, [MudanzaPhone]=@MudanzaPhone, [MudanzaFechaAlta]=@MudanzaFechaAlta, [MudanzaFechaUpdate]=@MudanzaFechaUpdate, [MudanzaFechaServicio]=@MudanzaFechaServicio, [MudanzaHoraServicio]=@MudanzaHoraServicio, [MudanzaRgoHoraservicio]=@MudanzaRgoHoraservicio, [MudanzaDireccionOrigen]=@MudanzaDireccionOrigen, [MudanzaLocalidadOrigen]=@MudanzaLocalidadOrigen, [MudanzaPisoDptoOrigen]=@MudanzaPisoDptoOrigen, [MudanzaDireccionDestino]=@MudanzaDireccionDestino, [MudanzaLocalidadDestino]=@MudanzaLocalidadDestino, [MudanzaPisoDptoDestino]=@MudanzaPisoDptoDestino, [MudanzaDistancia]=@MudanzaDistancia, [MudanzaCoordenadaOrigen]=@MudanzaCoordenadaOrigen, [MudanzaCoordenadaDestino]=@MudanzaCoordenadaDestino, [MudanzaVehiculoSugerido]=@MudanzaVehiculoSugerido, [MudanzaPrecioBasexHora]=@MudanzaPrecioBasexHora, [MudanzaPeajeCantidad]=@MudanzaPeajeCantidad, [MudanzaComentario]=@MudanzaComentario, [MudanzaOrigenMetodo]=@MudanzaOrigenMetodo, [MudanzaDestinoMetodo]=@MudanzaDestinoMetodo, [MudanzaTiempoMaximo]=@MudanzaTiempoMaximo, [MudanzaCargaVolumenEstimado]=@MudanzaCargaVolumenEstimado, [MudanzaAdicionalPrecio]=@MudanzaAdicionalPrecio, [MudanzaElevacion]=@MudanzaElevacion, [MudanzaDescenso]=@MudanzaDescenso, [MudanzaEmbalaje]=@MudanzaEmbalaje, [MudanzaCantidadPeones]=@MudanzaCantidadPeones, [MudanzaPrecioFinal]=@MudanzaPrecioFinal, [MudanzaOperacionId]=@MudanzaOperacionId, [MudanzaFormaPago]=@MudanzaFormaPago, [MudanzaProveedorId]=@MudanzaProveedorId, [MudanzaSecUserId]=@MudanzaSecUserId, [TipoInmuebleOrigenId]=@TipoInmuebleOrigenId, [TipoInmuebleDestinoId]=@TipoInmuebleDestinoId, [TipoEstacionamOrigenId]=@TipoEstacionamOrigenId, "
        + " [TipoEstacionamDestinoId]=@TipoEstacionamDestinoId  WHERE [MudanzaId] = @MudanzaId" ;
        Object[] prmBC002K18;
        prmBC002K18 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC002K19;
        prmBC002K19 = new Object[] {
        new ParDef("@TipoInmuebleOrigenId",GXType.Int16,4,0)
        };
        Object[] prmBC002K20;
        prmBC002K20 = new Object[] {
        new ParDef("@TipoInmuebleDestinoId",GXType.Int16,4,0)
        };
        Object[] prmBC002K21;
        prmBC002K21 = new Object[] {
        new ParDef("@TipoEstacionamOrigenId",GXType.Int16,4,0)
        };
        Object[] prmBC002K22;
        prmBC002K22 = new Object[] {
        new ParDef("@TipoEstacionamDestinoId",GXType.Int16,4,0)
        };
        Object[] prmBC002K23;
        prmBC002K23 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC002K24;
        prmBC002K24 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true}
        };
        string cmdBufferBC002K24;
        cmdBufferBC002K24=" SELECT TM1.[MudanzaPeajevalor], TM1.[MudanzaId], TM1.[MudanzaAsesor], TM1.[MudanzaApellidoNombre], TM1.[MudanzaMail], TM1.[MudanzaPhone], TM1.[MudanzaFechaAlta], TM1.[MudanzaFechaUpdate], TM1.[MudanzaFechaServicio], TM1.[MudanzaHoraServicio], TM1.[MudanzaRgoHoraservicio], TM1.[MudanzaDireccionOrigen], TM1.[MudanzaLocalidadOrigen], TM1.[MudanzaPisoDptoOrigen], TM1.[MudanzaDireccionDestino], TM1.[MudanzaLocalidadDestino], TM1.[MudanzaPisoDptoDestino], TM1.[MudanzaDistancia], TM1.[MudanzaCoordenadaOrigen], TM1.[MudanzaCoordenadaDestino], TM1.[MudanzaVehiculoSugerido], TM1.[MudanzaPrecioBasexHora], TM1.[MudanzaPeajeCantidad], TM1.[MudanzaComentario], T2.[ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre, T2.[ParametroMudanzaValor] AS TipoInmuebleOrigenValor, TM1.[MudanzaOrigenMetodo], T3.[ParametroMudanzaNombre] AS TipoInmuebleDestinoNombre, T3.[ParametroMudanzaValor] AS TipoInmuebleDestinoValor, T4.[ParametroMudanzaNombre] AS TipoEstacionamOrigenNombre, T4.[ParametroMudanzaValor] AS TipoEstacionamOrigenValor, T5.[ParametroMudanzaNombre] AS TipoEstacionamDestinoNombre, TM1.[MudanzaDestinoMetodo], T5.[ParametroMudanzaValor] AS TipoEstacionamDestinoValor, TM1.[MudanzaTiempoMaximo], TM1.[MudanzaCargaVolumenEstimado], TM1.[MudanzaAdicionalPrecio], TM1.[MudanzaElevacion], TM1.[MudanzaDescenso], TM1.[MudanzaEmbalaje], TM1.[MudanzaCantidadPeones], TM1.[MudanzaPrecioFinal], TM1.[MudanzaOperacionId], TM1.[MudanzaFormaPago], TM1.[MudanzaProveedorId], TM1.[MudanzaSecUserId], TM1.[TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, TM1.[TipoInmuebleDestinoId] AS TipoInmuebleDestinoId, TM1.[TipoEstacionamOrigenId] AS TipoEstacionamOrigenId, TM1.[TipoEstacionamDestinoId] AS TipoEstacionamDestinoId FROM (((([Mudanza] TM1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = TM1.[TipoInmuebleOrigenId]) "
        + " INNER JOIN [ParametroMudanza] T3 ON T3.[ParametroMudanzaId] = TM1.[TipoInmuebleDestinoId]) INNER JOIN [ParametroMudanza] T4 ON T4.[ParametroMudanzaId] = TM1.[TipoEstacionamOrigenId]) INNER JOIN [ParametroMudanza] T5 ON T5.[ParametroMudanzaId] = TM1.[TipoEstacionamDestinoId]) WHERE TM1.[MudanzaId] = @MudanzaId ORDER BY TM1.[MudanzaId]  OPTION (FAST 100)" ;
        Object[] prmBC002K25;
        prmBC002K25 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0)
        };
        Object[] prmBC002K26;
        prmBC002K26 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0)
        };
        Object[] prmBC002K27;
        prmBC002K27 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0)
        };
        Object[] prmBC002K28;
        prmBC002K28 = new Object[] {
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0) ,
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0)
        };
        Object[] prmBC002K29;
        prmBC002K29 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0)
        };
        Object[] prmBC002K30;
        prmBC002K30 = new Object[] {
        new ParDef("@ItemCargaId",GXType.Int16,4,0)
        };
        Object[] prmBC002K31;
        prmBC002K31 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC002K32;
        prmBC002K32 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ItemAdicionalId",GXType.Int16,4,0)
        };
        Object[] prmBC002K33;
        prmBC002K33 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ItemAdicionalId",GXType.Int16,4,0)
        };
        Object[] prmBC002K34;
        prmBC002K34 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ItemAdicionalCantidad",GXType.Int16,4,0) ,
        new ParDef("@ItemAdicionalId",GXType.Int16,4,0)
        };
        Object[] prmBC002K35;
        prmBC002K35 = new Object[] {
        new ParDef("@ItemAdicionalCantidad",GXType.Int16,4,0) ,
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ItemAdicionalId",GXType.Int16,4,0)
        };
        Object[] prmBC002K36;
        prmBC002K36 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ItemAdicionalId",GXType.Int16,4,0)
        };
        Object[] prmBC002K37;
        prmBC002K37 = new Object[] {
        new ParDef("@ItemAdicionalId",GXType.Int16,4,0)
        };
        Object[] prmBC002K38;
        prmBC002K38 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC002K2", "SELECT [MudanzaId], [ItemAdicionalCantidad], [ItemAdicionalId] AS ItemAdicionalId FROM [MudanzaAdicional] WITH (UPDLOCK) WHERE [MudanzaId] = @MudanzaId AND [ItemAdicionalId] = @ItemAdicionalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K3", "SELECT [MudanzaId], [ItemAdicionalCantidad], [ItemAdicionalId] AS ItemAdicionalId FROM [MudanzaAdicional] WHERE [MudanzaId] = @MudanzaId AND [ItemAdicionalId] = @ItemAdicionalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K4", "SELECT [ParametroMudanzaNombre] AS ItemAdicionalNombre, [ParametroMudanzaValor] AS ItemAdicionalValor FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @ItemAdicionalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K5", "SELECT [MudanzaId], [ItemCargaCantidad], [ItemCargaEmbCant], [ItemCargaEmbalaje], [ItemCargaElevCant], [ItemCargaElevacion], [ItemCargaId] AS ItemCargaId FROM [MudanzaCarga] WITH (UPDLOCK) WHERE [MudanzaId] = @MudanzaId AND [ItemCargaId] = @ItemCargaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K6", "SELECT [MudanzaId], [ItemCargaCantidad], [ItemCargaEmbCant], [ItemCargaEmbalaje], [ItemCargaElevCant], [ItemCargaElevacion], [ItemCargaId] AS ItemCargaId FROM [MudanzaCarga] WHERE [MudanzaId] = @MudanzaId AND [ItemCargaId] = @ItemCargaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K7", "SELECT [ParametroMudanzaNombre] AS ItemCargaNombre, [ParametroMudanzaDescripcion] AS ItemCargaDescripcion, [ParametroMudanzaValor] AS ItemCargaVolumen FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @ItemCargaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K8", "SELECT [MudanzaPeajevalor], [MudanzaId], [MudanzaAsesor], [MudanzaApellidoNombre], [MudanzaMail], [MudanzaPhone], [MudanzaFechaAlta], [MudanzaFechaUpdate], [MudanzaFechaServicio], [MudanzaHoraServicio], [MudanzaRgoHoraservicio], [MudanzaDireccionOrigen], [MudanzaLocalidadOrigen], [MudanzaPisoDptoOrigen], [MudanzaDireccionDestino], [MudanzaLocalidadDestino], [MudanzaPisoDptoDestino], [MudanzaDistancia], [MudanzaCoordenadaOrigen], [MudanzaCoordenadaDestino], [MudanzaVehiculoSugerido], [MudanzaPrecioBasexHora], [MudanzaPeajeCantidad], [MudanzaComentario], [MudanzaOrigenMetodo], [MudanzaDestinoMetodo], [MudanzaTiempoMaximo], [MudanzaCargaVolumenEstimado], [MudanzaAdicionalPrecio], [MudanzaElevacion], [MudanzaDescenso], [MudanzaEmbalaje], [MudanzaCantidadPeones], [MudanzaPrecioFinal], [MudanzaOperacionId], [MudanzaFormaPago], [MudanzaProveedorId], [MudanzaSecUserId], [TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, [TipoInmuebleDestinoId] AS TipoInmuebleDestinoId, [TipoEstacionamOrigenId] AS TipoEstacionamOrigenId, [TipoEstacionamDestinoId] AS TipoEstacionamDestinoId FROM [Mudanza] WITH (UPDLOCK) WHERE [MudanzaId] = @MudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K9", "SELECT [MudanzaPeajevalor], [MudanzaId], [MudanzaAsesor], [MudanzaApellidoNombre], [MudanzaMail], [MudanzaPhone], [MudanzaFechaAlta], [MudanzaFechaUpdate], [MudanzaFechaServicio], [MudanzaHoraServicio], [MudanzaRgoHoraservicio], [MudanzaDireccionOrigen], [MudanzaLocalidadOrigen], [MudanzaPisoDptoOrigen], [MudanzaDireccionDestino], [MudanzaLocalidadDestino], [MudanzaPisoDptoDestino], [MudanzaDistancia], [MudanzaCoordenadaOrigen], [MudanzaCoordenadaDestino], [MudanzaVehiculoSugerido], [MudanzaPrecioBasexHora], [MudanzaPeajeCantidad], [MudanzaComentario], [MudanzaOrigenMetodo], [MudanzaDestinoMetodo], [MudanzaTiempoMaximo], [MudanzaCargaVolumenEstimado], [MudanzaAdicionalPrecio], [MudanzaElevacion], [MudanzaDescenso], [MudanzaEmbalaje], [MudanzaCantidadPeones], [MudanzaPrecioFinal], [MudanzaOperacionId], [MudanzaFormaPago], [MudanzaProveedorId], [MudanzaSecUserId], [TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, [TipoInmuebleDestinoId] AS TipoInmuebleDestinoId, [TipoEstacionamOrigenId] AS TipoEstacionamOrigenId, [TipoEstacionamDestinoId] AS TipoEstacionamDestinoId FROM [Mudanza] WHERE [MudanzaId] = @MudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K10", "SELECT [ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre, [ParametroMudanzaValor] AS TipoInmuebleOrigenValor FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @TipoInmuebleOrigenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K11", "SELECT [ParametroMudanzaNombre] AS TipoInmuebleDestinoNombre, [ParametroMudanzaValor] AS TipoInmuebleDestinoValor FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @TipoInmuebleDestinoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K12", "SELECT [ParametroMudanzaNombre] AS TipoEstacionamOrigenNombre, [ParametroMudanzaValor] AS TipoEstacionamOrigenValor FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @TipoEstacionamOrigenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K13", "SELECT [ParametroMudanzaNombre] AS TipoEstacionamDestinoNombre, [ParametroMudanzaValor] AS TipoEstacionamDestinoValor FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @TipoEstacionamDestinoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K14", cmdBufferBC002K14,true, GxErrorMask.GX_NOMASK, false, this,prmBC002K14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K15", "SELECT [MudanzaId] FROM [Mudanza] WHERE [MudanzaId] = @MudanzaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K16", cmdBufferBC002K16,true, GxErrorMask.GX_NOMASK, false, this,prmBC002K16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC002K17", cmdBufferBC002K17, GxErrorMask.GX_NOMASK,prmBC002K17)
           ,new CursorDef("BC002K18", "DELETE FROM [Mudanza]  WHERE [MudanzaId] = @MudanzaId", GxErrorMask.GX_NOMASK,prmBC002K18)
           ,new CursorDef("BC002K19", "SELECT [ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre, [ParametroMudanzaValor] AS TipoInmuebleOrigenValor FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @TipoInmuebleOrigenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K20", "SELECT [ParametroMudanzaNombre] AS TipoInmuebleDestinoNombre, [ParametroMudanzaValor] AS TipoInmuebleDestinoValor FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @TipoInmuebleDestinoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K21", "SELECT [ParametroMudanzaNombre] AS TipoEstacionamOrigenNombre, [ParametroMudanzaValor] AS TipoEstacionamOrigenValor FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @TipoEstacionamOrigenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K22", "SELECT [ParametroMudanzaNombre] AS TipoEstacionamDestinoNombre, [ParametroMudanzaValor] AS TipoEstacionamDestinoValor FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @TipoEstacionamDestinoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K23", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [MudanzaId] = @MudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC002K24", cmdBufferBC002K24,true, GxErrorMask.GX_NOMASK, false, this,prmBC002K24,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K25", "SELECT T1.[MudanzaId], T2.[ParametroMudanzaNombre] AS ItemCargaNombre, T2.[ParametroMudanzaDescripcion] AS ItemCargaDescripcion, T1.[ItemCargaCantidad], T1.[ItemCargaEmbCant], T1.[ItemCargaEmbalaje], T1.[ItemCargaElevCant], T1.[ItemCargaElevacion], T2.[ParametroMudanzaValor] AS ItemCargaVolumen, T1.[ItemCargaId] AS ItemCargaId FROM ([MudanzaCarga] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[ItemCargaId]) WHERE T1.[MudanzaId] = @MudanzaId and T1.[ItemCargaId] = @ItemCargaId ORDER BY T1.[MudanzaId], T1.[ItemCargaId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K25,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K26", "SELECT [MudanzaId], [ItemCargaId] AS ItemCargaId FROM [MudanzaCarga] WHERE [MudanzaId] = @MudanzaId AND [ItemCargaId] = @ItemCargaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K27", "INSERT INTO [MudanzaCarga]([MudanzaId], [ItemCargaCantidad], [ItemCargaEmbCant], [ItemCargaEmbalaje], [ItemCargaElevCant], [ItemCargaElevacion], [ItemCargaId]) VALUES(@MudanzaId, @ItemCargaCantidad, @ItemCargaEmbCant, @ItemCargaEmbalaje, @ItemCargaElevCant, @ItemCargaElevacion, @ItemCargaId)", GxErrorMask.GX_NOMASK,prmBC002K27)
           ,new CursorDef("BC002K28", "UPDATE [MudanzaCarga] SET [ItemCargaCantidad]=@ItemCargaCantidad, [ItemCargaEmbCant]=@ItemCargaEmbCant, [ItemCargaEmbalaje]=@ItemCargaEmbalaje, [ItemCargaElevCant]=@ItemCargaElevCant, [ItemCargaElevacion]=@ItemCargaElevacion  WHERE [MudanzaId] = @MudanzaId AND [ItemCargaId] = @ItemCargaId", GxErrorMask.GX_NOMASK,prmBC002K28)
           ,new CursorDef("BC002K29", "DELETE FROM [MudanzaCarga]  WHERE [MudanzaId] = @MudanzaId AND [ItemCargaId] = @ItemCargaId", GxErrorMask.GX_NOMASK,prmBC002K29)
           ,new CursorDef("BC002K30", "SELECT [ParametroMudanzaNombre] AS ItemCargaNombre, [ParametroMudanzaDescripcion] AS ItemCargaDescripcion, [ParametroMudanzaValor] AS ItemCargaVolumen FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @ItemCargaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K31", "SELECT T1.[MudanzaId], T2.[ParametroMudanzaNombre] AS ItemCargaNombre, T2.[ParametroMudanzaDescripcion] AS ItemCargaDescripcion, T1.[ItemCargaCantidad], T1.[ItemCargaEmbCant], T1.[ItemCargaEmbalaje], T1.[ItemCargaElevCant], T1.[ItemCargaElevacion], T2.[ParametroMudanzaValor] AS ItemCargaVolumen, T1.[ItemCargaId] AS ItemCargaId FROM ([MudanzaCarga] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[ItemCargaId]) WHERE T1.[MudanzaId] = @MudanzaId ORDER BY T1.[MudanzaId], T1.[ItemCargaId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K31,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K32", "SELECT T1.[MudanzaId], T2.[ParametroMudanzaNombre] AS ItemAdicionalNombre, T1.[ItemAdicionalCantidad], T2.[ParametroMudanzaValor] AS ItemAdicionalValor, T1.[ItemAdicionalId] AS ItemAdicionalId FROM ([MudanzaAdicional] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[ItemAdicionalId]) WHERE T1.[MudanzaId] = @MudanzaId and T1.[ItemAdicionalId] = @ItemAdicionalId ORDER BY T1.[MudanzaId], T1.[ItemAdicionalId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K32,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K33", "SELECT [MudanzaId], [ItemAdicionalId] AS ItemAdicionalId FROM [MudanzaAdicional] WHERE [MudanzaId] = @MudanzaId AND [ItemAdicionalId] = @ItemAdicionalId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K33,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K34", "INSERT INTO [MudanzaAdicional]([MudanzaId], [ItemAdicionalCantidad], [ItemAdicionalId]) VALUES(@MudanzaId, @ItemAdicionalCantidad, @ItemAdicionalId)", GxErrorMask.GX_NOMASK,prmBC002K34)
           ,new CursorDef("BC002K35", "UPDATE [MudanzaAdicional] SET [ItemAdicionalCantidad]=@ItemAdicionalCantidad  WHERE [MudanzaId] = @MudanzaId AND [ItemAdicionalId] = @ItemAdicionalId", GxErrorMask.GX_NOMASK,prmBC002K35)
           ,new CursorDef("BC002K36", "DELETE FROM [MudanzaAdicional]  WHERE [MudanzaId] = @MudanzaId AND [ItemAdicionalId] = @ItemAdicionalId", GxErrorMask.GX_NOMASK,prmBC002K36)
           ,new CursorDef("BC002K37", "SELECT [ParametroMudanzaNombre] AS ItemAdicionalNombre, [ParametroMudanzaValor] AS ItemAdicionalValor FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @ItemAdicionalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K37,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC002K38", "SELECT T1.[MudanzaId], T2.[ParametroMudanzaNombre] AS ItemAdicionalNombre, T1.[ItemAdicionalCantidad], T2.[ParametroMudanzaValor] AS ItemAdicionalValor, T1.[ItemAdicionalId] AS ItemAdicionalId FROM ([MudanzaAdicional] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[ItemAdicionalId]) WHERE T1.[MudanzaId] = @MudanzaId ORDER BY T1.[MudanzaId], T1.[ItemAdicionalId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K38,11, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((bool[]) buf[4])[0] = rslt.getBool(4);
              ((short[]) buf[5])[0] = rslt.getShort(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((bool[]) buf[7])[0] = rslt.getBool(6);
              ((short[]) buf[8])[0] = rslt.getShort(7);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((bool[]) buf[4])[0] = rslt.getBool(4);
              ((short[]) buf[5])[0] = rslt.getShort(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((bool[]) buf[7])[0] = rslt.getBool(6);
              ((short[]) buf[8])[0] = rslt.getShort(7);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              return;
           case 6 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 2);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 5);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((string[]) buf[13])[0] = rslt.getVarchar(12);
              ((string[]) buf[14])[0] = rslt.getVarchar(13);
              ((string[]) buf[15])[0] = rslt.getString(14, 30);
              ((string[]) buf[16])[0] = rslt.getVarchar(15);
              ((string[]) buf[17])[0] = rslt.getVarchar(16);
              ((string[]) buf[18])[0] = rslt.getString(17, 30);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(18);
              ((string[]) buf[20])[0] = rslt.getVarchar(19);
              ((string[]) buf[21])[0] = rslt.getVarchar(20);
              ((string[]) buf[22])[0] = rslt.getVarchar(21);
              ((decimal[]) buf[23])[0] = rslt.getDecimal(22);
              ((short[]) buf[24])[0] = rslt.getShort(23);
              ((string[]) buf[25])[0] = rslt.getVarchar(24);
              ((string[]) buf[26])[0] = rslt.getVarchar(25);
              ((string[]) buf[27])[0] = rslt.getVarchar(26);
              ((decimal[]) buf[28])[0] = rslt.getDecimal(27);
              ((decimal[]) buf[29])[0] = rslt.getDecimal(28);
              ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
              ((short[]) buf[31])[0] = rslt.getShort(30);
              ((short[]) buf[32])[0] = rslt.getShort(31);
              ((short[]) buf[33])[0] = rslt.getShort(32);
              ((short[]) buf[34])[0] = rslt.getShort(33);
              ((decimal[]) buf[35])[0] = rslt.getDecimal(34);
              ((long[]) buf[36])[0] = rslt.getLong(35);
              ((string[]) buf[37])[0] = rslt.getVarchar(36);
              ((long[]) buf[38])[0] = rslt.getLong(37);
              ((long[]) buf[39])[0] = rslt.getLong(38);
              ((short[]) buf[40])[0] = rslt.getShort(39);
              ((short[]) buf[41])[0] = rslt.getShort(40);
              ((short[]) buf[42])[0] = rslt.getShort(41);
              ((short[]) buf[43])[0] = rslt.getShort(42);
              return;
           case 7 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 2);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 5);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((string[]) buf[13])[0] = rslt.getVarchar(12);
              ((string[]) buf[14])[0] = rslt.getVarchar(13);
              ((string[]) buf[15])[0] = rslt.getString(14, 30);
              ((string[]) buf[16])[0] = rslt.getVarchar(15);
              ((string[]) buf[17])[0] = rslt.getVarchar(16);
              ((string[]) buf[18])[0] = rslt.getString(17, 30);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(18);
              ((string[]) buf[20])[0] = rslt.getVarchar(19);
              ((string[]) buf[21])[0] = rslt.getVarchar(20);
              ((string[]) buf[22])[0] = rslt.getVarchar(21);
              ((decimal[]) buf[23])[0] = rslt.getDecimal(22);
              ((short[]) buf[24])[0] = rslt.getShort(23);
              ((string[]) buf[25])[0] = rslt.getVarchar(24);
              ((string[]) buf[26])[0] = rslt.getVarchar(25);
              ((string[]) buf[27])[0] = rslt.getVarchar(26);
              ((decimal[]) buf[28])[0] = rslt.getDecimal(27);
              ((decimal[]) buf[29])[0] = rslt.getDecimal(28);
              ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
              ((short[]) buf[31])[0] = rslt.getShort(30);
              ((short[]) buf[32])[0] = rslt.getShort(31);
              ((short[]) buf[33])[0] = rslt.getShort(32);
              ((short[]) buf[34])[0] = rslt.getShort(33);
              ((decimal[]) buf[35])[0] = rslt.getDecimal(34);
              ((long[]) buf[36])[0] = rslt.getLong(35);
              ((string[]) buf[37])[0] = rslt.getVarchar(36);
              ((long[]) buf[38])[0] = rslt.getLong(37);
              ((long[]) buf[39])[0] = rslt.getLong(38);
              ((short[]) buf[40])[0] = rslt.getShort(39);
              ((short[]) buf[41])[0] = rslt.getShort(40);
              ((short[]) buf[42])[0] = rslt.getShort(41);
              ((short[]) buf[43])[0] = rslt.getShort(42);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 12 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 2);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 5);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((string[]) buf[13])[0] = rslt.getVarchar(12);
              ((string[]) buf[14])[0] = rslt.getVarchar(13);
              ((string[]) buf[15])[0] = rslt.getString(14, 30);
              ((string[]) buf[16])[0] = rslt.getVarchar(15);
              ((string[]) buf[17])[0] = rslt.getVarchar(16);
              ((string[]) buf[18])[0] = rslt.getString(17, 30);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(18);
              ((string[]) buf[20])[0] = rslt.getVarchar(19);
              ((string[]) buf[21])[0] = rslt.getVarchar(20);
              ((string[]) buf[22])[0] = rslt.getVarchar(21);
              ((decimal[]) buf[23])[0] = rslt.getDecimal(22);
              ((short[]) buf[24])[0] = rslt.getShort(23);
              ((string[]) buf[25])[0] = rslt.getVarchar(24);
              ((string[]) buf[26])[0] = rslt.getVarchar(25);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
              ((string[]) buf[28])[0] = rslt.getVarchar(27);
              ((string[]) buf[29])[0] = rslt.getVarchar(28);
              ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
              ((string[]) buf[31])[0] = rslt.getVarchar(30);
              ((decimal[]) buf[32])[0] = rslt.getDecimal(31);
              ((string[]) buf[33])[0] = rslt.getVarchar(32);
              ((string[]) buf[34])[0] = rslt.getVarchar(33);
              ((decimal[]) buf[35])[0] = rslt.getDecimal(34);
              ((decimal[]) buf[36])[0] = rslt.getDecimal(35);
              ((decimal[]) buf[37])[0] = rslt.getDecimal(36);
              ((decimal[]) buf[38])[0] = rslt.getDecimal(37);
              ((short[]) buf[39])[0] = rslt.getShort(38);
              ((short[]) buf[40])[0] = rslt.getShort(39);
              ((short[]) buf[41])[0] = rslt.getShort(40);
              ((short[]) buf[42])[0] = rslt.getShort(41);
              ((decimal[]) buf[43])[0] = rslt.getDecimal(42);
              ((long[]) buf[44])[0] = rslt.getLong(43);
              ((string[]) buf[45])[0] = rslt.getVarchar(44);
              ((long[]) buf[46])[0] = rslt.getLong(45);
              ((long[]) buf[47])[0] = rslt.getLong(46);
              ((short[]) buf[48])[0] = rslt.getShort(47);
              ((short[]) buf[49])[0] = rslt.getShort(48);
              ((short[]) buf[50])[0] = rslt.getShort(49);
              ((short[]) buf[51])[0] = rslt.getShort(50);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 22 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 2);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 5);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((string[]) buf[13])[0] = rslt.getVarchar(12);
              ((string[]) buf[14])[0] = rslt.getVarchar(13);
              ((string[]) buf[15])[0] = rslt.getString(14, 30);
              ((string[]) buf[16])[0] = rslt.getVarchar(15);
              ((string[]) buf[17])[0] = rslt.getVarchar(16);
              ((string[]) buf[18])[0] = rslt.getString(17, 30);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(18);
              ((string[]) buf[20])[0] = rslt.getVarchar(19);
              ((string[]) buf[21])[0] = rslt.getVarchar(20);
              ((string[]) buf[22])[0] = rslt.getVarchar(21);
              ((decimal[]) buf[23])[0] = rslt.getDecimal(22);
              ((short[]) buf[24])[0] = rslt.getShort(23);
              ((string[]) buf[25])[0] = rslt.getVarchar(24);
              ((string[]) buf[26])[0] = rslt.getVarchar(25);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
              ((string[]) buf[28])[0] = rslt.getVarchar(27);
              ((string[]) buf[29])[0] = rslt.getVarchar(28);
              ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
              ((string[]) buf[31])[0] = rslt.getVarchar(30);
              ((decimal[]) buf[32])[0] = rslt.getDecimal(31);
              ((string[]) buf[33])[0] = rslt.getVarchar(32);
              ((string[]) buf[34])[0] = rslt.getVarchar(33);
              ((decimal[]) buf[35])[0] = rslt.getDecimal(34);
              ((decimal[]) buf[36])[0] = rslt.getDecimal(35);
              ((decimal[]) buf[37])[0] = rslt.getDecimal(36);
              ((decimal[]) buf[38])[0] = rslt.getDecimal(37);
              ((short[]) buf[39])[0] = rslt.getShort(38);
              ((short[]) buf[40])[0] = rslt.getShort(39);
              ((short[]) buf[41])[0] = rslt.getShort(40);
              ((short[]) buf[42])[0] = rslt.getShort(41);
              ((decimal[]) buf[43])[0] = rslt.getDecimal(42);
              ((long[]) buf[44])[0] = rslt.getLong(43);
              ((string[]) buf[45])[0] = rslt.getVarchar(44);
              ((long[]) buf[46])[0] = rslt.getLong(45);
              ((long[]) buf[47])[0] = rslt.getLong(46);
              ((short[]) buf[48])[0] = rslt.getShort(47);
              ((short[]) buf[49])[0] = rslt.getShort(48);
              ((short[]) buf[50])[0] = rslt.getShort(49);
              ((short[]) buf[51])[0] = rslt.getShort(50);
              return;
           case 23 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((bool[]) buf[6])[0] = rslt.getBool(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((bool[]) buf[9])[0] = rslt.getBool(8);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
              ((short[]) buf[11])[0] = rslt.getShort(10);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 28 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              return;
           case 29 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((bool[]) buf[6])[0] = rslt.getBool(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((bool[]) buf[9])[0] = rslt.getBool(8);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
              ((short[]) buf[11])[0] = rslt.getShort(10);
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 31 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 36 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
     }
  }

}

}
