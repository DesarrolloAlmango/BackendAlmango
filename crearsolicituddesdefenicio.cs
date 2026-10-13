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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class crearsolicituddesdefenicio : GXProcedure
   {
      public crearsolicituddesdefenicio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public crearsolicituddesdefenicio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EcommerceId ,
                           long aP1_ComercioId ,
                           SdtSDTFenicioOrdersResponse_ordenesItem aP2_Orden ,
                           out string aP3_MensajeBC ,
                           out bool aP4_ResultadoSolicitudOK ,
                           ref string aP5_DebugLog )
      {
         this.AV10EcommerceId = aP0_EcommerceId;
         this.AV8ComercioId = aP1_ComercioId;
         this.AV21Orden = aP2_Orden;
         this.AV19MensajeBC = "" ;
         this.AV25ResultadoSolicitudOK = false ;
         this.AV9DebugLog = aP5_DebugLog;
         initialize();
         ExecutePrivate();
         aP3_MensajeBC=this.AV19MensajeBC;
         aP4_ResultadoSolicitudOK=this.AV25ResultadoSolicitudOK;
         aP5_DebugLog=this.AV9DebugLog;
      }

      public string executeUdp( long aP0_EcommerceId ,
                                long aP1_ComercioId ,
                                SdtSDTFenicioOrdersResponse_ordenesItem aP2_Orden ,
                                out string aP3_MensajeBC ,
                                out bool aP4_ResultadoSolicitudOK )
      {
         execute(aP0_EcommerceId, aP1_ComercioId, aP2_Orden, out aP3_MensajeBC, out aP4_ResultadoSolicitudOK, ref aP5_DebugLog);
         return AV9DebugLog ;
      }

      public void executeSubmit( long aP0_EcommerceId ,
                                 long aP1_ComercioId ,
                                 SdtSDTFenicioOrdersResponse_ordenesItem aP2_Orden ,
                                 out string aP3_MensajeBC ,
                                 out bool aP4_ResultadoSolicitudOK ,
                                 ref string aP5_DebugLog )
      {
         this.AV10EcommerceId = aP0_EcommerceId;
         this.AV8ComercioId = aP1_ComercioId;
         this.AV21Orden = aP2_Orden;
         this.AV19MensajeBC = "" ;
         this.AV25ResultadoSolicitudOK = false ;
         this.AV9DebugLog = aP5_DebugLog;
         SubmitImpl();
         aP3_MensajeBC=this.AV19MensajeBC;
         aP4_ResultadoSolicitudOK=this.AV25ResultadoSolicitudOK;
         aP5_DebugLog=this.AV9DebugLog;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV24ResultadoOk = false;
         AV11ErrorLinea = false;
         AV13FechaAlta = DateTimeUtil.Now( context);
         AV22PostulacionBC = new SdtPostulaciones(context);
         AV22PostulacionBC.gxTpr_Postulacionesestado = "DES";
         AV22PostulacionBC.gxTpr_Postulacionesfechaalta = AV13FechaAlta;
         AV22PostulacionBC.gxTpr_Postulacionesproveedorid = AV8ComercioId;
         AV22PostulacionBC.gxTv_SdtPostulaciones_Serviciosid_SetNull();
         AV22PostulacionBC.Save();
         if ( ! AV22PostulacionBC.Success() )
         {
            AV60GXV2 = 1;
            AV59GXV1 = AV22PostulacionBC.GetMessages();
            while ( AV60GXV2 <= AV59GXV1.Count )
            {
               AV18Mensaje = ((GeneXus.Utils.SdtMessages_Message)AV59GXV1.Item(AV60GXV2));
               AV19MensajeBC += AV18Mensaje.gxTpr_Description + StringUtil.NewLine( );
               AV60GXV2 = (int)(AV60GXV2+1);
            }
            cleanup();
            if (true) return;
         }
         AV23PostulacionesId = AV22PostulacionBC.gxTpr_Postulacionesid;
         AV9DebugLog += context.GetMessage( "Postulacion creada ID: ", "") + StringUtil.Str( (decimal)(AV23PostulacionesId), 18, 0) + " - ";
         AV27SolicitudBC = new SdtSolicitudes(context);
         new armardireccionenviofenicio(context ).execute(  AV21Orden.gxTpr_Entrega.gxTpr_Direccionenvio.gxTpr_Localidad,  AV21Orden.gxTpr_Entrega.gxTpr_Direccionenvio.gxTpr_Calle,  AV21Orden.gxTpr_Entrega.gxTpr_Direccionenvio.gxTpr_Numeropuerta,  AV21Orden.gxTpr_Entrega.gxTpr_Direccionenvio.gxTpr_Numeroapto, out  AV28SolicitudDireccion) ;
         AV9DebugLog += context.GetMessage( "direcc", "") + StringUtil.Trim( AV28SolicitudDireccion) + " - ";
         new obtenermonedaidporiso(context ).execute(  AV21Orden.gxTpr_Pago.gxTpr_Moneda, out  AV20MonedaId, out  AV12ExisteMoneda) ;
         AV27SolicitudBC.gxTpr_Estadossolid = 1;
         AV27SolicitudBC.gxTpr_Estadossoltipo = context.GetMessage( "SOL", "");
         AV27SolicitudBC.gxTpr_Solicitudessubtipo = "Z";
         AV27SolicitudBC.gxTpr_Solicitudservicioorigenpago = "T";
         AV27SolicitudBC.gxTpr_Solicitudescalcomi = true;
         AV27SolicitudBC.gxTpr_Solicitudesnombre = StringUtil.Trim( AV21Orden.gxTpr_Comprador.gxTpr_Nombre)+" "+StringUtil.Trim( AV21Orden.gxTpr_Comprador.gxTpr_Apellido);
         AV27SolicitudBC.gxTpr_Solicitudestelefono = AV21Orden.gxTpr_Comprador.gxTpr_Telefono;
         AV27SolicitudBC.gxTpr_Solicitudesmail = AV21Orden.gxTpr_Comprador.gxTpr_Email;
         AV27SolicitudBC.gxTpr_Solicitudescomentario = AV21Orden.gxTpr_Observaciones;
         AV27SolicitudBC.gxTv_SdtSolicitudes_Zonasid_SetNull();
         AV27SolicitudBC.gxTpr_Solicitudesdireccion = AV28SolicitudDireccion;
         AV27SolicitudBC.gxTpr_Solicitudesfechaalta = AV13FechaAlta;
         AV27SolicitudBC.gxTpr_Proveedorid = AV8ComercioId;
         AV27SolicitudBC.gxTpr_Stcomerciosid = AV10EcommerceId;
         AV27SolicitudBC.gxTpr_Metodopagosid = 2;
         AV27SolicitudBC.gxTpr_Stmonedasid = AV20MonedaId;
         AV27SolicitudBC.gxTpr_Postulacionesid = AV23PostulacionesId;
         AV36HTMLText = "";
         AV52StringRutasCondiciones = "";
         AV44TextosProcesados.Clear();
         AV61GXV3 = 1;
         while ( AV61GXV3 <= AV21Orden.gxTpr_Lineas.Count )
         {
            AV16Linea = ((SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem)AV21Orden.gxTpr_Lineas.Item(AV61GXV3));
            AV9DebugLog += context.GetMessage( "linea en proceso: ", "") + AV16Linea.ToJSonString(false, true) + " - ";
            if ( StringUtil.StrCmp(StringUtil.Substring( AV16Linea.gxTpr_Sku, 1, 3), context.GetMessage( "amg", "")) == 0 )
            {
               new resolverproductodesdesku(context ).execute(  AV10EcommerceId,  AV8ComercioId,  AV16Linea.gxTpr_Sku, out  AV26RubrosId, out  AV17MedidasId, out  AV14InventarioId, out  AV11ErrorLinea, ref  AV9DebugLog) ;
               AV9DebugLog += context.GetMessage( "error en linea: ", "") + StringUtil.BoolToStr( AV11ErrorLinea) + " - ";
               if ( AV11ErrorLinea )
               {
                  AV24ResultadoOk = false;
                  cleanup();
                  if (true) return;
               }
               AV15ItemBC = new SdtSolicitudes_Items(context);
               AV15ItemBC.gxTpr_Rubrosid = AV26RubrosId;
               AV15ItemBC.gxTpr_Medidasid = AV17MedidasId;
               AV15ItemBC.gxTpr_Inventarioid = AV14InventarioId;
               AV15ItemBC.gxTpr_Solicitudesitemscantidad = (short)(Math.Round(AV16Linea.gxTpr_Cantidad, 18, MidpointRounding.ToEven));
               AV27SolicitudBC.gxTpr_Items.Add(AV15ItemBC, 0);
               /* Execute user subroutine: 'GETCONDICIONESITEMS' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV9DebugLog += StringUtil.Trim( AV52StringRutasCondiciones);
            }
            AV61GXV3 = (int)(AV61GXV3+1);
         }
         AV27SolicitudBC.Save();
         if ( ! AV27SolicitudBC.Success() )
         {
            AV63GXV5 = 1;
            AV62GXV4 = AV27SolicitudBC.GetMessages();
            while ( AV63GXV5 <= AV62GXV4.Count )
            {
               AV18Mensaje = ((GeneXus.Utils.SdtMessages_Message)AV62GXV4.Item(AV63GXV5));
               AV19MensajeBC += AV18Mensaje.gxTpr_Description + StringUtil.NewLine( );
               AV63GXV5 = (int)(AV63GXV5+1);
            }
            cleanup();
            if (true) return;
         }
         AV29SolicitudId = AV27SolicitudBC.gxTpr_Solicitudesid;
         AV9DebugLog += context.GetMessage( "Solicitud creada ID: ", "") + StringUtil.Str( (decimal)(AV29SolicitudId), 18, 0) + " - ";
         AV22PostulacionBC.gxTpr_Postulacionesestado = "HAB";
         AV22PostulacionBC.Save();
         if ( ! AV22PostulacionBC.Success() )
         {
            AV65GXV7 = 1;
            AV64GXV6 = AV22PostulacionBC.GetMessages();
            while ( AV65GXV7 <= AV64GXV6.Count )
            {
               AV18Mensaje = ((GeneXus.Utils.SdtMessages_Message)AV64GXV6.Item(AV65GXV7));
               AV19MensajeBC += AV18Mensaje.gxTpr_Description + StringUtil.NewLine( );
               AV65GXV7 = (int)(AV65GXV7+1);
            }
            cleanup();
            if (true) return;
         }
         AV27SolicitudBC.Load(AV29SolicitudId);
         AV32Codigo = context.GetMessage( "URLFORMECOMMERCE", "");
         new GeneXus.Programs.apis.oparametro(context ).execute(  AV32Codigo, out  AV33Valor) ;
         AV37LinkFormulario = StringUtil.Trim( AV33Valor) + StringUtil.Trim( StringUtil.Str( (decimal)(AV27SolicitudBC.gxTpr_Solicitudesid), 18, 0));
         AV56CodigoCondiciones = context.GetMessage( "URL_CONDICIONES_SERV", "");
         new GeneXus.Programs.apis.oparametro(context ).execute(  AV56CodigoCondiciones, out  AV58ValorCondiciones) ;
         AV57BaseUrlCondiciones = StringUtil.Trim( AV58ValorCondiciones);
         AV36HTMLText += context.GetMessage( "<div class=\"u-row-container\" style=\"background-color:transparent; padding:0px\">", "");
         AV36HTMLText += context.GetMessage( "<div class=\"u-row\" style=\"background-color:#ffffff; margin: 0 auto; max-width:600px; min-width:320px; overflow-wrap:break-word;\">", "");
         AV36HTMLText += context.GetMessage( "<div style=\"padding: 30px 40px; font-family: Arial, sans-serif; font-size: 16px; line-height: 150%; text-align: left; color: #333333;\">", "");
         AV36HTMLText += context.GetMessage( "Hola <strong>", "") + StringUtil.Trim( AV21Orden.gxTpr_Comprador.gxTpr_Nombre) + context.GetMessage( "</strong>,<br><br>", "");
         AV36HTMLText += context.GetMessage( "Tu solicitud de servicio fue registrada correctamente.<br>", "");
         AV36HTMLText += context.GetMessage( "Para avanzar con la coordinación, necesitamos que confirmes algunos datos para que podamos conectarte con profesionales disponibles en tu zona.<br><br>", "");
         AV36HTMLText += context.GetMessage( "<strong>¿Qué debés hacer?</strong><br><br>", "");
         AV36HTMLText += context.GetMessage( "<div style=\"margin-left: 20px;\">", "");
         AV36HTMLText += context.GetMessage( "<strong>1.</strong> Ingresá al formulario a través del link o botón abajo<br>", "");
         AV36HTMLText += context.GetMessage( "<strong>2.</strong> Confirmá la dirección del trabajo<br>", "");
         AV36HTMLText += context.GetMessage( "<strong>3.</strong> Indicanos la fecha en la que recibís el producto<br>", "");
         AV36HTMLText += context.GetMessage( "<strong>4.</strong> Elegí la fecha y turno que prefieras<br>", "");
         AV36HTMLText += context.GetMessage( "</div><br>", "");
         AV36HTMLText += context.GetMessage( "<em>El proceso demora menos de 1 minuto.</em>", "");
         AV36HTMLText += context.GetMessage( "<div style=\"margin-top: 25px; text-align: center;\">", "");
         AV36HTMLText += context.GetMessage( "<a href=\"", "") + StringUtil.Trim( AV37LinkFormulario) + context.GetMessage( "\" style=\"background-color: #008be1; color: #ffffff; padding: 15px 30px; text-decoration: none; border-radius: 4px; display: inline-block; font-weight: bold; font-size: 16px;\">", "");
         AV36HTMLText += context.GetMessage( "COMPLETAR DATOS AQUÍ", "");
         AV36HTMLText += context.GetMessage( "</a>", "");
         AV36HTMLText += context.GetMessage( "</div>", "");
         AV36HTMLText += context.GetMessage( "<p style=\"font-size: 12px; color: #7f8c8d; margin-top: 20px; text-align: center;\">O copia este link: ", "") + StringUtil.Trim( AV37LinkFormulario) + context.GetMessage( "</p>", "");
         AV36HTMLText += context.GetMessage( "<br><strong>&#9888; Importante</strong><br>", "");
         AV36HTMLText += context.GetMessage( "Una vez completes el formulario, te notificaremos cuando haya profesionales interesados en realizar el servicio.<br><br>", "");
         AV36HTMLText += context.GetMessage( "<div style=\"border-top: 1px solid #eeeeee; margin-top: 20px; padding-top: 15px;\">", "");
         AV36HTMLText += context.GetMessage( "<p style=\"font-size: 13px; color: #555555; line-height: 1.5;\">", "");
         AV36HTMLText += context.GetMessage( "&#128204; <strong>CONDICIONES DEL SERVICIO:</strong>", "");
         AV36HTMLText += context.GetMessage( "</p>", "");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52StringRutasCondiciones)) )
         {
            AV53ListaPdfs = (GxSimpleCollection<string>)(GxRegex.Split(AV52StringRutasCondiciones,";"));
            AV66GXV8 = 1;
            while ( AV66GXV8 <= AV53ListaPdfs.Count )
            {
               AV55PdfNombre = ((string)AV53ListaPdfs.Item(AV66GXV8));
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55PdfNombre)) )
               {
                  AV54UrlCompletaPdf = AV57BaseUrlCondiciones + StringUtil.Trim( AV55PdfNombre);
                  AV36HTMLText += context.GetMessage( "<a href=\"", "") + StringUtil.Trim( AV54UrlCompletaPdf) + context.GetMessage( "\" target=\"_blank\" style=\"color: #008be1; text-decoration: underline; display: block; margin-top: 8px; font-size: 13px;\">", "");
                  AV36HTMLText += context.GetMessage( "&#128196; Ver documento: ", "") + StringUtil.Trim( AV55PdfNombre);
                  AV36HTMLText += context.GetMessage( "</a>", "");
               }
               AV66GXV8 = (int)(AV66GXV8+1);
            }
         }
         AV36HTMLText += context.GetMessage( "</div>", "");
         AV36HTMLText += context.GetMessage( "</div>", "");
         AV36HTMLText += context.GetMessage( "</div>", "");
         AV36HTMLText += context.GetMessage( "</div>", "");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21Orden.gxTpr_Comprador.gxTpr_Email)) )
         {
            GXt_char1 = AV27SolicitudBC.gxTpr_Proveedornombre;
            new organizarmail(context ).execute(  8,  context.GetMessage( "N", ""),  AV21Orden.gxTpr_Comprador.gxTpr_Email, ref  GXt_char1,  "", ref  AV36HTMLText, out  AV35Ok, out  AV34ErrorDescription) ;
            AV27SolicitudBC.gxTpr_Proveedornombre = GXt_char1;
         }
         if ( StringUtil.StrCmp(AV35Ok, context.GetMessage( "S", "")) == 0 )
         {
            AV27SolicitudBC.gxTpr_Solicitudesnotificacion = context.GetMessage( "S", "");
         }
         else
         {
            AV27SolicitudBC.gxTpr_Solicitudesnotificacion = context.GetMessage( "N", "");
         }
         AV27SolicitudBC.gxTpr_Solicitudesotros3 = AV34ErrorDescription;
         AV27SolicitudBC.Save();
         AV68GXV10 = 1;
         AV67GXV9 = AV27SolicitudBC.GetMessages();
         while ( AV68GXV10 <= AV67GXV9.Count )
         {
            AV18Mensaje = ((GeneXus.Utils.SdtMessages_Message)AV67GXV9.Item(AV68GXV10));
            AV19MensajeBC += AV18Mensaje.gxTpr_Description + StringUtil.NewLine( );
            AV68GXV10 = (int)(AV68GXV10+1);
         }
         AV25ResultadoSolicitudOK = true;
         cleanup();
         if (true) return;
         cleanup();
      }

      protected void S111( )
      {
         /* 'GETCONDICIONESITEMS' Routine */
         returnInSub = false;
         /* Using cursor P00LH2 */
         pr_default.execute(0, new Object[] {AV26RubrosId, AV17MedidasId, AV14InventarioId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A135InventarioId = P00LH2_A135InventarioId[0];
            A137MedidasID = P00LH2_A137MedidasID[0];
            A121RubrosId = P00LH2_A121RubrosId[0];
            A535InventarioTextosId = P00LH2_A535InventarioTextosId[0];
            n535InventarioTextosId = P00LH2_n535InventarioTextosId[0];
            A150TextosId = P00LH2_A150TextosId[0];
            n150TextosId = P00LH2_n150TextosId[0];
            A150TextosId = P00LH2_A150TextosId[0];
            n150TextosId = P00LH2_n150TextosId[0];
            if ( ! P00LH2_n535InventarioTextosId[0] )
            {
               AV41IdABuscar = A535InventarioTextosId;
            }
            else
            {
               AV41IdABuscar = A150TextosId;
            }
            if ( ( AV44TextosProcesados.IndexOf(AV41IdABuscar) == 0 ) && ! (0==AV41IdABuscar) )
            {
               new GeneXus.Programs.apis.obtenertycrutapdf(context ).execute(  AV41IdABuscar, out  AV51RutaPdf) ;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51RutaPdf)) )
               {
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52StringRutasCondiciones)) )
                  {
                     AV52StringRutasCondiciones += ";";
                  }
                  AV52StringRutasCondiciones += StringUtil.Trim( AV51RutaPdf);
               }
               AV44TextosProcesados.Add(AV41IdABuscar, 0);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV19MensajeBC = "";
         AV13FechaAlta = (DateTime)(DateTime.MinValue);
         AV22PostulacionBC = new SdtPostulaciones(context);
         AV59GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV18Mensaje = new GeneXus.Utils.SdtMessages_Message(context);
         AV27SolicitudBC = new SdtSolicitudes(context);
         AV28SolicitudDireccion = "";
         AV36HTMLText = "";
         AV52StringRutasCondiciones = "";
         AV44TextosProcesados = new GxSimpleCollection<long>();
         AV16Linea = new SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem(context);
         AV15ItemBC = new SdtSolicitudes_Items(context);
         AV62GXV4 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV64GXV6 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV32Codigo = "";
         AV33Valor = "";
         AV37LinkFormulario = "";
         AV56CodigoCondiciones = "";
         AV58ValorCondiciones = "";
         AV57BaseUrlCondiciones = "";
         AV53ListaPdfs = new GxSimpleCollection<string>();
         AV55PdfNombre = "";
         AV54UrlCompletaPdf = "";
         GXt_char1 = "";
         AV35Ok = "";
         AV34ErrorDescription = "";
         AV67GXV9 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P00LH2_A135InventarioId = new long[1] ;
         P00LH2_A137MedidasID = new long[1] ;
         P00LH2_A121RubrosId = new short[1] ;
         P00LH2_A535InventarioTextosId = new long[1] ;
         P00LH2_n535InventarioTextosId = new bool[] {false} ;
         P00LH2_A150TextosId = new long[1] ;
         P00LH2_n150TextosId = new bool[] {false} ;
         AV51RutaPdf = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.crearsolicituddesdefenicio__default(),
            new Object[][] {
                new Object[] {
               P00LH2_A135InventarioId, P00LH2_A137MedidasID, P00LH2_A121RubrosId, P00LH2_A535InventarioTextosId, P00LH2_n535InventarioTextosId, P00LH2_A150TextosId, P00LH2_n150TextosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MonedaId ;
      private short AV26RubrosId ;
      private short A121RubrosId ;
      private int AV60GXV2 ;
      private int AV61GXV3 ;
      private int AV63GXV5 ;
      private int AV65GXV7 ;
      private int AV66GXV8 ;
      private int AV68GXV10 ;
      private long AV10EcommerceId ;
      private long AV8ComercioId ;
      private long AV23PostulacionesId ;
      private long AV17MedidasId ;
      private long AV14InventarioId ;
      private long AV29SolicitudId ;
      private long A135InventarioId ;
      private long A137MedidasID ;
      private long A535InventarioTextosId ;
      private long A150TextosId ;
      private long AV41IdABuscar ;
      private string AV28SolicitudDireccion ;
      private string AV36HTMLText ;
      private string AV32Codigo ;
      private string AV37LinkFormulario ;
      private string AV56CodigoCondiciones ;
      private string GXt_char1 ;
      private string AV35Ok ;
      private string AV34ErrorDescription ;
      private DateTime AV13FechaAlta ;
      private bool AV25ResultadoSolicitudOK ;
      private bool AV24ResultadoOk ;
      private bool AV11ErrorLinea ;
      private bool AV12ExisteMoneda ;
      private bool returnInSub ;
      private bool n535InventarioTextosId ;
      private bool n150TextosId ;
      private string AV19MensajeBC ;
      private string AV9DebugLog ;
      private string AV52StringRutasCondiciones ;
      private string AV33Valor ;
      private string AV58ValorCondiciones ;
      private string AV57BaseUrlCondiciones ;
      private string AV55PdfNombre ;
      private string AV54UrlCompletaPdf ;
      private string AV51RutaPdf ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTFenicioOrdersResponse_ordenesItem AV21Orden ;
      private string aP5_DebugLog ;
      private SdtPostulaciones AV22PostulacionBC ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV59GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV18Mensaje ;
      private SdtSolicitudes AV27SolicitudBC ;
      private GxSimpleCollection<long> AV44TextosProcesados ;
      private SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem AV16Linea ;
      private SdtSolicitudes_Items AV15ItemBC ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV62GXV4 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV64GXV6 ;
      private GxSimpleCollection<string> AV53ListaPdfs ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV67GXV9 ;
      private IDataStoreProvider pr_default ;
      private long[] P00LH2_A135InventarioId ;
      private long[] P00LH2_A137MedidasID ;
      private short[] P00LH2_A121RubrosId ;
      private long[] P00LH2_A535InventarioTextosId ;
      private bool[] P00LH2_n535InventarioTextosId ;
      private long[] P00LH2_A150TextosId ;
      private bool[] P00LH2_n150TextosId ;
      private string aP3_MensajeBC ;
      private bool aP4_ResultadoSolicitudOK ;
   }

   public class crearsolicituddesdefenicio__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00LH2;
          prmP00LH2 = new Object[] {
          new ParDef("@AV26RubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV17MedidasId",GXType.Decimal,18,0) ,
          new ParDef("@AV14InventarioId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00LH2", "SELECT T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T1.[InventarioTextosId], T2.[TextosId] FROM ([Inventario] T1 INNER JOIN [RubrosMedidas] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID]) WHERE T1.[RubrosId] = @AV26RubrosId and T1.[MedidasID] = @AV17MedidasId and T1.[InventarioId] = @AV14InventarioId ORDER BY T1.[RubrosId], T1.[MedidasID], T1.[InventarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LH2,1, GxCacheFrequency.OFF ,true,true )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
