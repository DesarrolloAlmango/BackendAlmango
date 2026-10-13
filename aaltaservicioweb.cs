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
   public class aaltaservicioweb : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aaltaservicioweb().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         string aP0_UserConect = new string(' ',0)  ;
         string aP1_Key = new string(' ',0)  ;
          long aP2_ProveedorID ;
         string aP3_UsuarioID = new string(' ',0)  ;
         string aP4_Solicitud = new string(' ',0)  ;
          long aP5_SolicitudesID ;
         if ( 0 < args.Length )
         {
            aP0_UserConect=((string)(args[0]));
         }
         else
         {
            aP0_UserConect="";
         }
         if ( 1 < args.Length )
         {
            aP1_Key=((string)(args[1]));
         }
         else
         {
            aP1_Key="";
         }
         if ( 2 < args.Length )
         {
            aP2_ProveedorID=((long)(NumberUtil.Val( (string)(args[2]), ".")));
         }
         else
         {
            aP2_ProveedorID=0;
         }
         if ( 3 < args.Length )
         {
            aP3_UsuarioID=((string)(args[3]));
         }
         else
         {
            aP3_UsuarioID="";
         }
         if ( 4 < args.Length )
         {
            aP4_Solicitud=((string)(args[4]));
         }
         else
         {
            aP4_Solicitud="";
         }
         if ( 5 < args.Length )
         {
            aP5_SolicitudesID=((long)(NumberUtil.Val( (string)(args[5]), ".")));
         }
         else
         {
            aP5_SolicitudesID=0;
         }
         execute(aP0_UserConect, aP1_Key, aP2_ProveedorID, aP3_UsuarioID, aP4_Solicitud, out aP5_SolicitudesID);
         return GX.GXRuntime.ExitCode ;
      }

      public aaltaservicioweb( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aaltaservicioweb( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserConect ,
                           string aP1_Key ,
                           long aP2_ProveedorID ,
                           string aP3_UsuarioID ,
                           string aP4_Solicitud ,
                           out long aP5_SolicitudesID )
      {
         this.AV14UserConect = aP0_UserConect;
         this.AV9Key = aP1_Key;
         this.AV19ProveedorID = aP2_ProveedorID;
         this.AV38UsuarioID = aP3_UsuarioID;
         this.AV41Solicitud = aP4_Solicitud;
         this.AV28SolicitudesID = 0 ;
         initialize();
         ExecutePrivate();
         aP5_SolicitudesID=this.AV28SolicitudesID;
      }

      public long executeUdp( string aP0_UserConect ,
                              string aP1_Key ,
                              long aP2_ProveedorID ,
                              string aP3_UsuarioID ,
                              string aP4_Solicitud )
      {
         execute(aP0_UserConect, aP1_Key, aP2_ProveedorID, aP3_UsuarioID, aP4_Solicitud, out aP5_SolicitudesID);
         return AV28SolicitudesID ;
      }

      public void executeSubmit( string aP0_UserConect ,
                                 string aP1_Key ,
                                 long aP2_ProveedorID ,
                                 string aP3_UsuarioID ,
                                 string aP4_Solicitud ,
                                 out long aP5_SolicitudesID )
      {
         this.AV14UserConect = aP0_UserConect;
         this.AV9Key = aP1_Key;
         this.AV19ProveedorID = aP2_ProveedorID;
         this.AV38UsuarioID = aP3_UsuarioID;
         this.AV41Solicitud = aP4_Solicitud;
         this.AV28SolicitudesID = 0 ;
         SubmitImpl();
         aP5_SolicitudesID=this.AV28SolicitudesID;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10ok = context.GetMessage( "N", "");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14UserConect)) )
         {
            AV13ResMessage = context.GetMessage( "Usuario incorrecto", "");
            AV12ResCode = 102;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9Key)) )
         {
            AV13ResMessage = context.GetMessage( "llave de acceso incorrecta", "");
            AV12ResCode = 104;
         }
         else if ( StringUtil.StrCmp(AV9Key, context.GetMessage( "d3d3LmF6bWl0YS5jb20=", "")) != 0 )
         {
            AV13ResMessage = context.GetMessage( "llave de acceso incorrecta.", "");
            AV12ResCode = 105;
         }
         else
         {
            AV10ok = context.GetMessage( "S", "");
         }
         AV27SolicitudesDatos.FromJSonString(AV41Solicitud, null);
         if ( StringUtil.StrCmp(AV10ok, context.GetMessage( "S", "")) == 0 )
         {
            if ( AV19ProveedorID == 0 )
            {
               AV34IDProveedor = 1001;
            }
            else
            {
               AV34IDProveedor = AV19ProveedorID;
            }
            AV32Solicitudes = new SdtSolicitudes(context);
            if ( ( NumberUtil.Val( AV38UsuarioID, ".") > Convert.ToDecimal( 0 )) )
            {
               AV52SecUserId = (long)(Math.Round(NumberUtil.Val( AV38UsuarioID, "."), 18, MidpointRounding.ToEven));
               /* Execute user subroutine: 'OBTENER NOMBRE DEL USUARIO' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48SecUserFullName)) )
               {
                  AV32Solicitudes.gxTpr_Solicitudesusralta = AV52SecUserId;
               }
            }
            else
            {
               AV32Solicitudes.gxTpr_Solicitudesusralta = 1061;
               AV52SecUserId = 1061;
               /* Execute user subroutine: 'OBTENER NOMBRE DEL USUARIO' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48SecUserFullName)) )
            {
               AV32Solicitudes.gxTpr_Solicitudesotros3 = context.GetMessage( "Solicitud ingresada por un usuario sin registrar.", "");
            }
            else
            {
               AV32Solicitudes.gxTpr_Solicitudesotros3 = context.GetMessage( "Solicitud ingresada por: ", "")+StringUtil.Trim( AV48SecUserFullName);
            }
            AV32Solicitudes.gxTpr_Solicitudesnombre = AV27SolicitudesDatos.gxTpr_Nombre;
            AV32Solicitudes.gxTpr_Solicitudestelefono = AV27SolicitudesDatos.gxTpr_Telefono;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27SolicitudesDatos.gxTpr_Mail)) )
            {
               AV32Solicitudes.gxTpr_Solicitudesmail = AV27SolicitudesDatos.gxTpr_Mail;
            }
            else
            {
               AV32Solicitudes.gxTv_SdtSolicitudes_Solicitudesmail_SetNull();
            }
            AV32Solicitudes.gxTpr_Departamentoid = AV27SolicitudesDatos.gxTpr_Departamentoid;
            AV32Solicitudes.gxTpr_Departamentomunicipioid = AV27SolicitudesDatos.gxTpr_Municipioid;
            if ( AV27SolicitudesDatos.gxTpr_Zonasid > 0 )
            {
               AV32Solicitudes.gxTpr_Zonasid = AV27SolicitudesDatos.gxTpr_Zonasid;
            }
            else
            {
               AV32Solicitudes.gxTv_SdtSolicitudes_Zonasid_SetNull();
            }
            AV32Solicitudes.gxTv_SdtSolicitudes_Stcomerciosid_SetNull();
            AV32Solicitudes.gxTv_SdtSolicitudes_Postulacionesid_SetNull();
            AV32Solicitudes.gxTpr_Solicitudesdireccion = AV27SolicitudesDatos.gxTpr_Direccion;
            AV32Solicitudes.gxTpr_Solicitudescostoxzona = AV27SolicitudesDatos.gxTpr_Costoxzona;
            AV32Solicitudes.gxTpr_Solicitudesdescuento = AV27SolicitudesDatos.gxTpr_Descuento;
            if ( AV27SolicitudesDatos.gxTpr_Cuponid > 0 )
            {
               AV32Solicitudes.gxTpr_Cuponid = AV27SolicitudesDatos.gxTpr_Cuponid;
               AV32Solicitudes.gxTpr_Solicitudesdescuentocupon = AV27SolicitudesDatos.gxTpr_Descuentocupon;
               new desactivarcupon(context ).execute(  AV27SolicitudesDatos.gxTpr_Cuponid) ;
            }
            else
            {
               AV32Solicitudes.gxTv_SdtSolicitudes_Cuponid_SetNull();
               AV32Solicitudes.gxTpr_Solicitudesdescuentocupon = (decimal)(0);
            }
            GXt_decimal1 = AV56SolicitudesCostoXZComAlmP;
            new ocomisionzona(context ).execute( out  GXt_decimal1) ;
            AV56SolicitudesCostoXZComAlmP = GXt_decimal1;
            if ( ( AV56SolicitudesCostoXZComAlmP > Convert.ToDecimal( 0 )) && ( AV32Solicitudes.gxTpr_Solicitudescostoxzona > Convert.ToDecimal( 0 )) )
            {
               AV32Solicitudes.gxTpr_Solicitudescostoxzcomalmp = AV56SolicitudesCostoXZComAlmP;
            }
            if ( ( AV32Solicitudes.gxTpr_Solicitudescostoxzcomalmp > Convert.ToDecimal( 0 )) )
            {
               AV32Solicitudes.gxTpr_Solicitudescostoxzcomalm = (decimal)((AV32Solicitudes.gxTpr_Solicitudescostoxzona*(AV32Solicitudes.gxTpr_Solicitudescostoxzcomalmp/ (decimal)(100))));
            }
            if ( ( AV32Solicitudes.gxTpr_Solicitudescostoxzcomalmp == Convert.ToDecimal( 0 )) )
            {
               AV32Solicitudes.gxTpr_Solicitudescostoxzcomalm = (decimal)(0);
            }
            AV32Solicitudes.gxTpr_Solicitudescotizacion = AV27SolicitudesDatos.gxTpr_Solicitudescotizacion;
            AV32Solicitudes.gxTpr_Solicitudserviciosolcoti = AV27SolicitudesDatos.gxTpr_Solicitacotizacion;
            AV32Solicitudes.gxTpr_Estadossoltipo = context.GetMessage( "SOL", "");
            AV32Solicitudes.gxTpr_Solicitudesurlorigen = AV27SolicitudesDatos.gxTpr_Urlorigen;
            if ( StringUtil.StrCmp(AV27SolicitudesDatos.gxTpr_Paginaone, context.GetMessage( "One", "")) == 0 )
            {
               AV32Solicitudes.gxTpr_Estadossolid = 11;
            }
            else
            {
               if ( AV27SolicitudesDatos.gxTpr_Metodopagosid == 4 )
               {
                  AV32Solicitudes.gxTpr_Estadossolid = 9;
               }
               else
               {
                  AV32Solicitudes.gxTpr_Estadossolid = 1;
                  if ( ((AV32Solicitudes.gxTpr_Solicitudesusralta==1061)||(AV32Solicitudes.gxTpr_Solicitudesusralta==1013)||(AV32Solicitudes.gxTpr_Solicitudesusralta==1014)||(AV32Solicitudes.gxTpr_Solicitudesusralta==1010)) )
                  {
                     AV32Solicitudes.gxTpr_Estadossolid = 8;
                  }
               }
            }
            if ( AV27SolicitudesDatos.gxTpr_Metodopagosid == 4 )
            {
               AV32Solicitudes.gxTpr_Metodopagosid = 1;
            }
            else
            {
               AV32Solicitudes.gxTpr_Metodopagosid = AV27SolicitudesDatos.gxTpr_Metodopagosid;
            }
            AV32Solicitudes.gxTpr_Solicitudesotros1 = AV27SolicitudesDatos.gxTpr_Solicitaotroservicio;
            AV32Solicitudes.gxTpr_Solicitudesotros2 = AV27SolicitudesDatos.gxTpr_Otroserviciodetalle;
            AV43Fecha = AV27SolicitudesDatos.gxTpr_Fechainstalacion;
            AV32Solicitudes.gxTpr_Solicitudesfechainstalacion = AV43Fecha;
            AV32Solicitudes.gxTpr_Solicitudeshorainstalacion = StringUtil.Trim( StringUtil.Str( (decimal)(AV27SolicitudesDatos.gxTpr_Turnoinstalacion), 10, 0));
            AV32Solicitudes.gxTpr_Solicitudescomentario = AV27SolicitudesDatos.gxTpr_Comentario;
            AV32Solicitudes.gxTpr_Solicitudesnota = StringUtil.Trim( AV27SolicitudesDatos.gxTpr_Nombre)+context.GetMessage( " confirmó la solicitud y acceptó los términos del servicio. ", "");
            AV32Solicitudes.gxTpr_Solicitudesnotificacion = "";
            AV32Solicitudes.gxTpr_Proveedorid = AV34IDProveedor;
            AV32Solicitudes.gxTpr_Solicitudessubtipo = "T";
            if ( AV32Solicitudes.gxTpr_Solicitudesusralta == 1061 )
            {
               AV32Solicitudes.gxTpr_Solicitudessubtipo = "Z";
               AV61PostulacionBC = new SdtPostulaciones(context);
               AV61PostulacionBC.gxTpr_Postulacionesestado = "HAB";
               AV61PostulacionBC.gxTpr_Postulacionesfechaalta = DateTimeUtil.Now( context);
               AV61PostulacionBC.gxTpr_Postulacionesproveedorid = AV34IDProveedor;
               AV61PostulacionBC.gxTv_SdtPostulaciones_Serviciosid_SetNull();
               AV61PostulacionBC.Save();
               if ( ! AV61PostulacionBC.Success() )
               {
                  context.RollbackDataStores("altaservicioweb",pr_default);
                  AV28SolicitudesID = 0;
                  cleanup();
                  if (true) return;
               }
               AV62PostulacionesId = AV61PostulacionBC.gxTpr_Postulacionesid;
               AV32Solicitudes.gxTpr_Postulacionesid = AV62PostulacionesId;
            }
            /* Using cursor P00H62 */
            pr_default.execute(0, new Object[] {AV34IDProveedor});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A133ProveedorID = P00H62_A133ProveedorID[0];
               A440ProveedorPagoDefault = P00H62_A440ProveedorPagoDefault[0];
               AV45ProveedorPagoDefault = A440ProveedorPagoDefault;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00H63 */
            pr_default.execute(1, new Object[] {AV34IDProveedor});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A133ProveedorID = P00H63_A133ProveedorID[0];
               A440ProveedorPagoDefault = P00H63_A440ProveedorPagoDefault[0];
               AV45ProveedorPagoDefault = A440ProveedorPagoDefault;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( AV27SolicitudesDatos.gxTpr_Metodopagosid == 4 )
            {
               AV32Solicitudes.gxTpr_Solicitudespagado = context.GetMessage( "N", "");
               AV32Solicitudes.gxTpr_Solicitudservicioorigenpago = "F";
            }
            else
            {
               if ( StringUtil.StrCmp(AV45ProveedorPagoDefault, "F") == 0 )
               {
                  AV32Solicitudes.gxTpr_Solicitudespagado = context.GetMessage( "N", "");
                  AV32Solicitudes.gxTpr_Solicitudservicioorigenpago = "F";
               }
               else if ( StringUtil.StrCmp(AV45ProveedorPagoDefault, "T") == 0 )
               {
                  AV32Solicitudes.gxTpr_Solicitudespagado = context.GetMessage( "S", "");
                  AV32Solicitudes.gxTpr_Solicitudservicioorigenpago = "T";
               }
               else
               {
                  AV32Solicitudes.gxTpr_Solicitudespagado = context.GetMessage( "S", "");
                  AV32Solicitudes.gxTpr_Solicitudservicioorigenpago = "O";
               }
            }
            AV32Solicitudes.gxTpr_Solicitudescalcomi = true;
            AV32Solicitudes.gxTpr_Stmonedasid = 1;
            AV32Solicitudes.gxTpr_Solicitudesfechaalta = DateTimeUtil.Now( context);
            AV32Solicitudes.gxTpr_Solicitudesfechaactualizacion = DateTimeUtil.Now( context);
            AV32Solicitudes.gxTpr_Proveedornombreaux = StringUtil.Trim( AV27SolicitudesDatos.gxTpr_Proveedorauxiliar);
            AV35iTems = (short)(AV27SolicitudesDatos.gxTpr_Level1.Count);
            while ( AV35iTems > 0 )
            {
               AV37i = (long)(AV37i+1);
               if ( AV37i > AV35iTems )
               {
                  if (true) break;
               }
               AV36SolicitudesItems = new SdtSolicitudes_Items(context);
               AV36SolicitudesItems.gxTpr_Solicitudesitemsid = (short)(AV37i);
               AV36SolicitudesItems.gxTpr_Rubrosid = ((SdtSDTASolicitudes_Items)AV27SolicitudesDatos.gxTpr_Level1.Item((int)(AV37i))).gxTpr_Rubrosid;
               AV36SolicitudesItems.gxTpr_Medidasid = ((SdtSDTASolicitudes_Items)AV27SolicitudesDatos.gxTpr_Level1.Item((int)(AV37i))).gxTpr_Productoid;
               AV36SolicitudesItems.gxTpr_Inventarioid = ((SdtSDTASolicitudes_Items)AV27SolicitudesDatos.gxTpr_Level1.Item((int)(AV37i))).gxTpr_Detalleid;
               AV36SolicitudesItems.gxTpr_Solicitudesitemscantidad = (short)(((SdtSDTASolicitudes_Items)AV27SolicitudesDatos.gxTpr_Level1.Item((int)(AV37i))).gxTpr_Cantidad);
               AV36SolicitudesItems.gxTpr_Solicituditemssr = ((SdtSDTASolicitudes_Items)AV27SolicitudesDatos.gxTpr_Level1.Item((int)(AV37i))).gxTpr_Sr;
               AV36SolicitudesItems.gxTpr_Solicituditemscomision = ((SdtSDTASolicitudes_Items)AV27SolicitudesDatos.gxTpr_Level1.Item((int)(AV37i))).gxTpr_Comision;
               AV36SolicitudesItems.gxTpr_Solicituditemscomisiontipo = ((SdtSDTASolicitudes_Items)AV27SolicitudesDatos.gxTpr_Level1.Item((int)(AV37i))).gxTpr_Comisiontipo;
               AV32Solicitudes.gxTpr_Items.Add(AV36SolicitudesItems, 0);
               if ( AV32Solicitudes.gxTpr_Solicitudesusralta == 1061 )
               {
                  /* Execute user subroutine: 'GETCONDICIONESITEMS' */
                  S151 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
               }
            }
            AV82GXV1 = 1;
            while ( AV82GXV1 <= AV27SolicitudesDatos.gxTpr_Archivo.Count )
            {
               AV70SDTSolicitudesArchivo = ((SdtSDTASolicitudes_ArchivoItem)AV27SolicitudesDatos.gxTpr_Archivo.Item(AV82GXV1));
               AV68SolicitudesArchivo = new SdtSolicitudes_Archivo(context);
               AV68SolicitudesArchivo.gxTpr_Archivoid = AV70SDTSolicitudesArchivo.gxTpr_Archivoid;
               AV68SolicitudesArchivo.gxTpr_Archivodescripcion = AV70SDTSolicitudesArchivo.gxTpr_Archivodescripcion;
               AV68SolicitudesArchivo.gxTpr_Archivodireccion = AV70SDTSolicitudesArchivo.gxTpr_Archivodireccion;
               AV68SolicitudesArchivo.gxTpr_Archivotipo = AV70SDTSolicitudesArchivo.gxTpr_Archivotipo;
               AV32Solicitudes.gxTpr_Archivo.Add(AV68SolicitudesArchivo, 0);
               AV82GXV1 = (int)(AV82GXV1+1);
            }
            AV32Solicitudes.Save();
            AV28SolicitudesID = AV32Solicitudes.gxTpr_Solicitudesid_Z;
            if ( AV32Solicitudes.Success() )
            {
               AV33Boolean = AV32Solicitudes.Success();
               AV13ResMessage = StringUtil.BoolToStr( AV33Boolean);
               new relprovsol(context ).execute(  AV34IDProveedor,  AV28SolicitudesID,  AV27SolicitudesDatos.gxTpr_Nombre) ;
               if ( AV32Solicitudes.gxTpr_Solicitudesusralta == 1061 )
               {
                  /* Execute user subroutine: 'ENVIARCORREO' */
                  S141 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
               }
               /* Execute user subroutine: 'CARGARSDTNOTI' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               if ( ! (0==AV27SolicitudesDatos.gxTpr_Solicitudidcancelar) )
               {
                  /* Execute user subroutine: 'CANCELARPRESOLICITUD' */
                  S131 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
               }
               context.CommitDataStores("altaservicioweb",pr_default);
            }
            else
            {
               AV55Messages = AV32Solicitudes.GetMessages();
               AV83GXV2 = 1;
               while ( AV83GXV2 <= AV55Messages.Count )
               {
                  AV50oneMessage = ((GeneXus.Utils.SdtMessages_Message)AV55Messages.Item(AV83GXV2));
                  AV13ResMessage += "," + (AV50oneMessage.gxTpr_Description);
                  AV83GXV2 = (int)(AV83GXV2+1);
               }
               AV13ResMessage = context.GetMessage( "No se pueden validar los datos proporcionados.", "") + StringUtil.Trim( AV13ResMessage);
               AV12ResCode = 108;
               AV53Plog = new SdtPlog(context);
               AV53Plog.gxTpr_Plogmsg = AV13ResMessage;
               AV53Plog.Insert();
               if ( AV53Plog.Success() )
               {
                  context.CommitDataStores("altaservicioweb",pr_default);
               }
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'CARGARSDTNOTI' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27SolicitudesDatos.gxTpr_Mail)) && ( AV28SolicitudesID > 0 ) )
         {
            AV46SDTCNotificaciones = new SdtSDTCNotificaciones(context);
            AV46SDTCNotificaciones.gxTpr_Solicitudesid = AV28SolicitudesID;
            AV46SDTCNotificaciones.gxTpr_Maildesignid = 2;
            AV46SDTCNotificaciones.gxTpr_Estadosgenericosid = 1;
            AV46SDTCNotificaciones.gxTpr_Mensajefijo = StringUtil.Format( context.GetMessage( "La solicitud Nro: %1, fue ingresada correctamente.", ""), StringUtil.LTrimStr( (decimal)(AV28SolicitudesID), 18, 0), "", "", "", "", "", "", "", "");
            AV46SDTCNotificaciones.gxTpr_Emailcliente = AV27SolicitudesDatos.gxTpr_Mail;
            AV46SDTCNotificaciones.gxTpr_Nombrecliente = AV27SolicitudesDatos.gxTpr_Nombre;
            new cnotificaciones(context ).execute(  AV46SDTCNotificaciones, out  AV10ok, out  AV47ErrorDescription) ;
         }
      }

      protected void S121( )
      {
         /* 'OBTENER NOMBRE DEL USUARIO' Routine */
         returnInSub = false;
         /* Using cursor P00H64 */
         pr_default.execute(2, new Object[] {AV52SecUserId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A18SecUserId = P00H64_A18SecUserId[0];
            A587SecUserFullName = P00H64_A587SecUserFullName[0];
            AV48SecUserFullName = A587SecUserFullName;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      protected void S131( )
      {
         /* 'CANCELARPRESOLICITUD' Routine */
         returnInSub = false;
         /* Optimized UPDATE. */
         /* Using cursor P00H65 */
         pr_default.execute(3, new Object[] {AV27SolicitudesDatos.gxTpr_Solicitudidcancelar});
         pr_default.close(3);
         pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
         /* End optimized UPDATE. */
      }

      protected void S141( )
      {
         /* 'ENVIARCORREO' Routine */
         returnInSub = false;
         AV57Codigo = context.GetMessage( "URLFORMECOMMERCE", "");
         new GeneXus.Programs.apis.oparametro(context ).execute(  AV57Codigo, out  AV67Valor) ;
         AV60LinkFormulario = StringUtil.Trim( AV67Valor) + StringUtil.Trim( StringUtil.Str( (decimal)(AV28SolicitudesID), 18, 0));
         AV72HoraStr = StringUtil.Trim( AV32Solicitudes.gxTpr_Solicitudeshorainstalacion);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72HoraStr)) )
         {
            AV73TextHora = context.GetMessage( "A definir", "");
         }
         else if ( StringUtil.StrCmp(AV72HoraStr, "1") == 0 )
         {
            AV73TextHora = context.GetMessage( "8-12 hs (Sabados 8-14 hs)", "");
         }
         else if ( StringUtil.StrCmp(AV72HoraStr, "2") == 0 )
         {
            AV73TextHora = context.GetMessage( "12-16 hs (Sabados 14-20 hs)", "");
         }
         else if ( StringUtil.StrCmp(AV72HoraStr, "3") == 0 )
         {
            AV73TextHora = context.GetMessage( "16-20 hs", "");
         }
         else
         {
            AV73TextHora = AV72HoraStr;
         }
         AV78CodigoCondiciones = context.GetMessage( "URL_CONDICIONES_SERV", "");
         new GeneXus.Programs.apis.oparametro(context ).execute(  AV78CodigoCondiciones, out  AV79ValorCondiciones) ;
         AV77BaseUrlCondiciones = StringUtil.Trim( AV79ValorCondiciones);
         AV58HTMLText = context.GetMessage( "<div class=\"u-row-container\" style=\"background-color:transparent; padding:0px\">", "");
         AV58HTMLText += context.GetMessage( "<div class=\"u-row\" style=\"background-color:#ffffff; margin: 0 auto; max-width:600px; min-width:320px; overflow-wrap:break-word;\">", "");
         AV58HTMLText += context.GetMessage( "<div style=\"padding: 30px 40px; font-family: Arial, sans-serif; font-size: 16px; line-height: 150%; text-align: left; color: #333333;\">", "");
         AV58HTMLText += context.GetMessage( "Hola <strong>", "") + StringUtil.Trim( AV32Solicitudes.gxTpr_Solicitudesnombre) + context.GetMessage( "</strong>,<br><br>", "");
         AV58HTMLText += context.GetMessage( "Tu solicitud de servicio fue registrada correctamente y ya se encuentra disponible.<br>", "");
         AV58HTMLText += context.GetMessage( "&#128197; <strong>Fecha solicitada:</strong> ", "") + context.localUtil.Format( AV32Solicitudes.gxTpr_Solicitudesfechainstalacion, "99/99/99") + context.GetMessage( "<br>", "");
         AV58HTMLText += context.GetMessage( "&#9200; <strong>Turno solicitado:</strong> ", "") + AV73TextHora + context.GetMessage( "<br><br>", "");
         AV58HTMLText += context.GetMessage( "Los profesionales de tu zona ya pueden:<br>", "");
         AV58HTMLText += context.GetMessage( "<ul style=\"margin-top: 5px; margin-bottom: 10px; padding-left: 20px;\">", "");
         AV58HTMLText += context.GetMessage( "<li>Aceptar el servicio directamente, si cuentan con disponibilidad.</li>", "");
         AV58HTMLText += context.GetMessage( "<li>Postularse, proponiendo una modificación en la agenda.</li>", "");
         AV58HTMLText += context.GetMessage( "</ul>", "");
         AV58HTMLText += context.GetMessage( "Te vamos a notificar por este medio cuando haya interesados.<br><br>", "");
         AV58HTMLText += context.GetMessage( "<div style=\"background-color: #fff4e5; padding: 15px; border-radius: 4px; border-left: 4px solid #ffa117;\">", "");
         AV58HTMLText += context.GetMessage( "<strong>&#9888; Importante</strong><br>", "");
         AV58HTMLText += context.GetMessage( "Los profesionales que se postulen no pueden ver tus datos hasta que selecciones a uno desde la plataforma.", "");
         AV58HTMLText += context.GetMessage( "</div><br>", "");
         AV58HTMLText += context.GetMessage( "<p style=\"margin-top: 10px;\">Podrás seguir el estado de tu solicitud y ver a los profesionales interesados ingresando al siguiente enlace:</p>", "");
         AV58HTMLText += context.GetMessage( "<div style=\"margin-top: 25px; text-align: center;\">", "");
         AV58HTMLText += context.GetMessage( "<a href=\"", "") + StringUtil.Trim( AV60LinkFormulario) + context.GetMessage( "\" style=\"background-color: #008be1; color: #ffffff; padding: 15px 30px; text-decoration: none; border-radius: 4px; display: inline-block; font-weight: bold; font-size: 16px;\">", "");
         AV58HTMLText += context.GetMessage( "VER POSTULADOS Y SOLICITUD", "");
         AV58HTMLText += context.GetMessage( "</a>", "");
         AV58HTMLText += context.GetMessage( "</div>", "");
         AV58HTMLText += context.GetMessage( "<p style=\"font-size: 11px; color: #7f8c8d; margin-top: 20px; text-align: center; word-break: break-all;\">O copia este link: ", "") + StringUtil.Trim( AV60LinkFormulario) + context.GetMessage( "</p>", "");
         AV58HTMLText += context.GetMessage( "<div style=\"border-top: 1px solid #eeeeee; margin-top: 20px; padding-top: 15px;\">", "");
         AV58HTMLText += context.GetMessage( "<p style=\"font-size: 13px; color: #555555; line-height: 1.5;\">", "");
         AV58HTMLText += context.GetMessage( "&#128204; <strong>CONDICIONES DEL SERVICIO:</strong>", "");
         AV58HTMLText += context.GetMessage( "</p>", "");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64StringRutasCondiciones)) )
         {
            AV74ListaPdfs = (GxSimpleCollection<string>)(GxRegex.Split(AV64StringRutasCondiciones,";"));
            AV86GXV3 = 1;
            while ( AV86GXV3 <= AV74ListaPdfs.Count )
            {
               AV75PdfNombre = ((string)AV74ListaPdfs.Item(AV86GXV3));
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75PdfNombre)) )
               {
                  AV76UrlCompletaPdf = AV77BaseUrlCondiciones + StringUtil.Trim( AV75PdfNombre);
                  AV58HTMLText += context.GetMessage( "<a href=\"", "") + StringUtil.Trim( AV76UrlCompletaPdf) + context.GetMessage( "\" target=\"_blank\" style=\"color: #008be1; text-decoration: underline; display: block; margin-top: 8px; font-size: 13px;\">", "");
                  AV58HTMLText += context.GetMessage( "&#128196; Ver documento: ", "") + StringUtil.Trim( AV75PdfNombre);
                  AV58HTMLText += context.GetMessage( "</a>", "");
               }
               AV86GXV3 = (int)(AV86GXV3+1);
            }
         }
         AV58HTMLText += context.GetMessage( "</div>", "");
         AV58HTMLText += context.GetMessage( "</div>", "");
         AV58HTMLText += context.GetMessage( "</div>", "");
         AV58HTMLText += context.GetMessage( "</div>", "");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27SolicitudesDatos.gxTpr_Mail)) && ( AV28SolicitudesID > 0 ) )
         {
            GXt_char2 = "";
            new organizarmail(context ).execute(  8,  context.GetMessage( "N", ""),  AV27SolicitudesDatos.gxTpr_Mail, ref  GXt_char2,  "", ref  AV58HTMLText, out  AV10ok, out  AV47ErrorDescription) ;
         }
      }

      protected void S151( )
      {
         /* 'GETCONDICIONESITEMS' Routine */
         returnInSub = false;
         /* Using cursor P00H66 */
         pr_default.execute(4, new Object[] {AV36SolicitudesItems.gxTpr_Rubrosid, AV36SolicitudesItems.gxTpr_Medidasid, AV36SolicitudesItems.gxTpr_Inventarioid});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A135InventarioId = P00H66_A135InventarioId[0];
            A137MedidasID = P00H66_A137MedidasID[0];
            A121RubrosId = P00H66_A121RubrosId[0];
            A535InventarioTextosId = P00H66_A535InventarioTextosId[0];
            n535InventarioTextosId = P00H66_n535InventarioTextosId[0];
            A150TextosId = P00H66_A150TextosId[0];
            n150TextosId = P00H66_n150TextosId[0];
            A150TextosId = P00H66_A150TextosId[0];
            n150TextosId = P00H66_n150TextosId[0];
            if ( ! P00H66_n535InventarioTextosId[0] )
            {
               AV59IdABuscar = A535InventarioTextosId;
            }
            else
            {
               AV59IdABuscar = A150TextosId;
            }
            if ( ( AV66TextosProcesados.IndexOf(AV59IdABuscar) == 0 ) && ! (0==AV59IdABuscar) )
            {
               new GeneXus.Programs.apis.obtenertycrutapdf(context ).execute(  AV59IdABuscar, out  AV63RutaPdf) ;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63RutaPdf)) )
               {
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64StringRutasCondiciones)) )
                  {
                     AV64StringRutasCondiciones += ";";
                  }
                  AV64StringRutasCondiciones += StringUtil.Trim( AV63RutaPdf);
               }
               AV66TextosProcesados.Add(AV59IdABuscar, 0);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
      }

      public override void cleanup( )
      {
         context.CommitDataStores("altaservicioweb",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10ok = "";
         AV13ResMessage = "";
         AV27SolicitudesDatos = new SdtSDTASolicitudes(context);
         AV32Solicitudes = new SdtSolicitudes(context);
         AV48SecUserFullName = "";
         AV43Fecha = DateTime.MinValue;
         AV61PostulacionBC = new SdtPostulaciones(context);
         P00H62_A133ProveedorID = new long[1] ;
         P00H62_A440ProveedorPagoDefault = new string[] {""} ;
         A440ProveedorPagoDefault = "";
         AV45ProveedorPagoDefault = "";
         P00H63_A133ProveedorID = new long[1] ;
         P00H63_A440ProveedorPagoDefault = new string[] {""} ;
         AV36SolicitudesItems = new SdtSolicitudes_Items(context);
         AV70SDTSolicitudesArchivo = new SdtSDTASolicitudes_ArchivoItem(context);
         AV68SolicitudesArchivo = new SdtSolicitudes_Archivo(context);
         AV55Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV50oneMessage = new GeneXus.Utils.SdtMessages_Message(context);
         AV53Plog = new SdtPlog(context);
         AV46SDTCNotificaciones = new SdtSDTCNotificaciones(context);
         AV47ErrorDescription = "";
         P00H64_A18SecUserId = new long[1] ;
         P00H64_A587SecUserFullName = new string[] {""} ;
         A587SecUserFullName = "";
         AV57Codigo = "";
         AV67Valor = "";
         AV60LinkFormulario = "";
         AV72HoraStr = "";
         AV73TextHora = "";
         AV78CodigoCondiciones = "";
         AV79ValorCondiciones = "";
         AV77BaseUrlCondiciones = "";
         AV58HTMLText = "";
         AV64StringRutasCondiciones = "";
         AV74ListaPdfs = new GxSimpleCollection<string>();
         AV75PdfNombre = "";
         AV76UrlCompletaPdf = "";
         GXt_char2 = "";
         P00H66_A135InventarioId = new long[1] ;
         P00H66_A137MedidasID = new long[1] ;
         P00H66_A121RubrosId = new short[1] ;
         P00H66_A535InventarioTextosId = new long[1] ;
         P00H66_n535InventarioTextosId = new bool[] {false} ;
         P00H66_A150TextosId = new long[1] ;
         P00H66_n150TextosId = new bool[] {false} ;
         AV66TextosProcesados = new GxSimpleCollection<long>();
         AV63RutaPdf = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aaltaservicioweb__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aaltaservicioweb__default(),
            new Object[][] {
                new Object[] {
               P00H62_A133ProveedorID, P00H62_A440ProveedorPagoDefault
               }
               , new Object[] {
               P00H63_A133ProveedorID, P00H63_A440ProveedorPagoDefault
               }
               , new Object[] {
               P00H64_A18SecUserId, P00H64_A587SecUserFullName
               }
               , new Object[] {
               }
               , new Object[] {
               P00H66_A135InventarioId, P00H66_A137MedidasID, P00H66_A121RubrosId, P00H66_A535InventarioTextosId, P00H66_n535InventarioTextosId, P00H66_A150TextosId, P00H66_n150TextosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV35iTems ;
      private short A121RubrosId ;
      private int AV12ResCode ;
      private int AV82GXV1 ;
      private int AV83GXV2 ;
      private int AV86GXV3 ;
      private long AV19ProveedorID ;
      private long AV28SolicitudesID ;
      private long AV34IDProveedor ;
      private long AV52SecUserId ;
      private long AV62PostulacionesId ;
      private long A133ProveedorID ;
      private long AV37i ;
      private long A18SecUserId ;
      private long A135InventarioId ;
      private long A137MedidasID ;
      private long A535InventarioTextosId ;
      private long A150TextosId ;
      private long AV59IdABuscar ;
      private decimal AV56SolicitudesCostoXZComAlmP ;
      private decimal GXt_decimal1 ;
      private string AV14UserConect ;
      private string AV9Key ;
      private string AV38UsuarioID ;
      private string AV41Solicitud ;
      private string AV10ok ;
      private string AV13ResMessage ;
      private string A440ProveedorPagoDefault ;
      private string AV45ProveedorPagoDefault ;
      private string AV57Codigo ;
      private string AV60LinkFormulario ;
      private string AV72HoraStr ;
      private string AV78CodigoCondiciones ;
      private string AV58HTMLText ;
      private string GXt_char2 ;
      private DateTime AV43Fecha ;
      private bool returnInSub ;
      private bool AV33Boolean ;
      private bool n535InventarioTextosId ;
      private bool n150TextosId ;
      private string AV48SecUserFullName ;
      private string AV47ErrorDescription ;
      private string A587SecUserFullName ;
      private string AV67Valor ;
      private string AV73TextHora ;
      private string AV79ValorCondiciones ;
      private string AV77BaseUrlCondiciones ;
      private string AV64StringRutasCondiciones ;
      private string AV75PdfNombre ;
      private string AV76UrlCompletaPdf ;
      private string AV63RutaPdf ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTASolicitudes AV27SolicitudesDatos ;
      private SdtSolicitudes AV32Solicitudes ;
      private SdtPostulaciones AV61PostulacionBC ;
      private IDataStoreProvider pr_default ;
      private long[] P00H62_A133ProveedorID ;
      private string[] P00H62_A440ProveedorPagoDefault ;
      private long[] P00H63_A133ProveedorID ;
      private string[] P00H63_A440ProveedorPagoDefault ;
      private SdtSolicitudes_Items AV36SolicitudesItems ;
      private SdtSDTASolicitudes_ArchivoItem AV70SDTSolicitudesArchivo ;
      private SdtSolicitudes_Archivo AV68SolicitudesArchivo ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV55Messages ;
      private GeneXus.Utils.SdtMessages_Message AV50oneMessage ;
      private SdtPlog AV53Plog ;
      private SdtSDTCNotificaciones AV46SDTCNotificaciones ;
      private long[] P00H64_A18SecUserId ;
      private string[] P00H64_A587SecUserFullName ;
      private GxSimpleCollection<string> AV74ListaPdfs ;
      private long[] P00H66_A135InventarioId ;
      private long[] P00H66_A137MedidasID ;
      private short[] P00H66_A121RubrosId ;
      private long[] P00H66_A535InventarioTextosId ;
      private bool[] P00H66_n535InventarioTextosId ;
      private long[] P00H66_A150TextosId ;
      private bool[] P00H66_n150TextosId ;
      private GxSimpleCollection<long> AV66TextosProcesados ;
      private long aP5_SolicitudesID ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class aaltaservicioweb__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aaltaservicioweb__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new UpdateCursor(def[3])
       ,new ForEachCursor(def[4])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00H62;
        prmP00H62 = new Object[] {
        new ParDef("@AV34IDProveedor",GXType.Decimal,18,0)
        };
        Object[] prmP00H63;
        prmP00H63 = new Object[] {
        new ParDef("@AV34IDProveedor",GXType.Decimal,18,0)
        };
        Object[] prmP00H64;
        prmP00H64 = new Object[] {
        new ParDef("@AV52SecUserId",GXType.Decimal,10,0)
        };
        Object[] prmP00H65;
        prmP00H65 = new Object[] {
        new ParDef("@AV27Soli_1Solicitudidcancelar",GXType.Decimal,10,0)
        };
        Object[] prmP00H66;
        prmP00H66 = new Object[] {
        new ParDef("@AV36Soli_4Rubrosid",GXType.Int16,4,0) ,
        new ParDef("@AV36Soli_3Medidasid",GXType.Decimal,18,0) ,
        new ParDef("@AV36Soli_2Inventarioid",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00H62", "SELECT [ProveedorID], [ProveedorPagoDefault] FROM [Proveedor] WHERE [ProveedorID] = @AV34IDProveedor ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H62,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00H63", "SELECT [ProveedorID], [ProveedorPagoDefault] FROM [Proveedor] WHERE [ProveedorID] = @AV34IDProveedor ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H63,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00H64", "SELECT TOP 1 [SecUserId], [SecUserFullName] FROM [SecUser] WHERE [SecUserId] = @AV52SecUserId ORDER BY [SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H64,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00H65", "UPDATE [Solicitudes] SET [EstadosSolId]=3  WHERE [SolicitudesID] = @AV27Soli_1Solicitudidcancelar", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00H65)
           ,new CursorDef("P00H66", "SELECT T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T1.[InventarioTextosId], T2.[TextosId] FROM ([Inventario] T1 INNER JOIN [RubrosMedidas] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID]) WHERE T1.[RubrosId] = @AV36Soli_4Rubrosid and T1.[MedidasID] = @AV36Soli_3Medidasid and T1.[InventarioId] = @AV36Soli_2Inventarioid ORDER BY T1.[RubrosId], T1.[MedidasID], T1.[InventarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H66,1, GxCacheFrequency.OFF ,true,true )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 4 :
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
