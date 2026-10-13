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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class awsasolicitudser : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( ! context.isAjaxRequest( ) )
         {
            GXSoapHTTPResponse.AppendHeader("Content-type", "text/xml;charset=utf-8");
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapHTTPRequest.Method), "get") == 0 )
         {
            if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapHTTPRequest.QueryString), "wsdl") == 0 )
            {
               GXSoapXMLWriter.OpenResponse(GXSoapHTTPResponse);
               GXSoapXMLWriter.WriteStartDocument("utf-8", 0);
               GXSoapXMLWriter.WriteStartElement("definitions");
               GXSoapXMLWriter.WriteAttribute("name", "WSAsolicitudSer");
               GXSoapXMLWriter.WriteAttribute("targetNamespace", "AlmangoX");
               GXSoapXMLWriter.WriteAttribute("xmlns:wsdlns", "AlmangoX");
               GXSoapXMLWriter.WriteAttribute("xmlns:soap", "http://schemas.xmlsoap.org/wsdl/soap/");
               GXSoapXMLWriter.WriteAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
               GXSoapXMLWriter.WriteAttribute("xmlns", "http://schemas.xmlsoap.org/wsdl/");
               GXSoapXMLWriter.WriteAttribute("xmlns:tns", "AlmangoX");
               GXSoapXMLWriter.WriteStartElement("types");
               GXSoapXMLWriter.WriteStartElement("schema");
               GXSoapXMLWriter.WriteAttribute("targetNamespace", "AlmangoX");
               GXSoapXMLWriter.WriteAttribute("xmlns", "http://www.w3.org/2001/XMLSchema");
               GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENC", "http://schemas.xmlsoap.org/soap/encoding/");
               GXSoapXMLWriter.WriteAttribute("elementFormDefault", "qualified");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WSAsolicitudSer.Execute");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Userconect");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Key");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Proveedorid");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Usuarioid");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Xmlsolicitud");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WSAsolicitudSer.ExecuteResponse");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Rescode");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:int");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Resmessage");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Solicitudesid");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSAsolicitudSer.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSAsolicitudSer.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSAsolicitudSer.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSAsolicitudSer.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "WSAsolicitudSerSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSAsolicitudSer.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSAsolicitudSer.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "WSAsolicitudSerSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"WSAsolicitudSerSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "AlmangoXaction/"+"AWSASOLICITUDSER.Execute");
               GXSoapXMLWriter.WriteStartElement("input");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("output");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("service");
               GXSoapXMLWriter.WriteAttribute("name", "WSAsolicitudSer");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "WSAsolicitudSerSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"WSAsolicitudSerSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"awsasolicitudser.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "awsasolicitudser.aspx" + "?wsdl to get the WSDL.";
            }
         }
         if ( currSoapErr == 0 )
         {
            GXSoapXMLReader.OpenRequest(GXSoapHTTPRequest);
            GXSoapXMLReader.ReadExternalEntities = 0;
            GXSoapXMLReader.IgnoreComments = 1;
            GXSoapError = GXSoapXMLReader.Read();
            while ( GXSoapError > 0 )
            {
               if ( StringUtil.StringSearch( GXSoapXMLReader.Name, "Envelope", 1) > 0 )
               {
                  this.SetPrefixesFromReader( GXSoapXMLReader);
               }
               if ( StringUtil.StringSearch( GXSoapXMLReader.Name, "Body", 1) > 0 )
               {
                  this.SetPrefixesFromReader( GXSoapXMLReader);
                  if (true) break;
               }
               GXSoapError = GXSoapXMLReader.Read();
            }
            if ( GXSoapError > 0 )
            {
               GXSoapError = GXSoapXMLReader.Read();
               if ( GXSoapError > 0 )
               {
                  this.SetPrefixesFromReader( GXSoapXMLReader);
                  currMethod = GXSoapXMLReader.Name;
                  if ( ( StringUtil.StringSearch( currMethod+"&", "Execute&", 1) > 0 ) || ( currSoapErr != 0 ) )
                  {
                     if ( currSoapErr == 0 )
                     {
                        formatError = false;
                        sTagName = GXSoapXMLReader.Name;
                        if ( GXSoapXMLReader.IsSimple == 0 )
                        {
                           GXSoapError = GXSoapXMLReader.Read();
                           nOutParmCount = 0;
                           while ( ( ( StringUtil.StrCmp(GXSoapXMLReader.Name, sTagName) != 0 ) || ( GXSoapXMLReader.NodeType == 1 ) ) && ( GXSoapError > 0 ) )
                           {
                              readOk = 0;
                              readElement = false;
                              this.SetNamedPrefixesFromReader( GXSoapXMLReader);
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Userconect") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV14UserConect = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Key") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV9Key = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Proveedorid") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV19ProveedorID = (long)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Usuarioid") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV38UsuarioID = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Xmlsolicitud") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV41XMLSolicitud = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( ! readElement )
                              {
                                 readOk = 1;
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              nOutParmCount = (short)(nOutParmCount+1);
                              if ( ( readOk == 0 ) || formatError )
                              {
                                 context.sSOAPErrMsg += "Error reading " + sTagName + StringUtil.NewLine( );
                                 context.sSOAPErrMsg += "Message: " + GXSoapXMLReader.ReadRawXML();
                                 GXSoapError = (short)(nOutParmCount*-1);
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     currSoapErr = (short)(-20002);
                     currSoapErrmsg = "Wrong method called. Expected method: " + "Execute";
                  }
               }
            }
            GXSoapXMLReader.Close();
         }
         if ( currSoapErr == 0 )
         {
            if ( GXSoapError < 0 )
            {
               currSoapErr = (short)(GXSoapError*-1);
               currSoapErrmsg = context.sSOAPErrMsg;
            }
            else
            {
               if ( GXSoapXMLReader.ErrCode > 0 )
               {
                  currSoapErr = (short)(GXSoapXMLReader.ErrCode*-1);
                  currSoapErrmsg = GXSoapXMLReader.ErrDescription;
               }
               else
               {
                  if ( GXSoapError == 0 )
                  {
                     currSoapErr = (short)(-20001);
                     currSoapErrmsg = "Malformed SOAP message.";
                  }
                  else
                  {
                     currSoapErr = 0;
                     currSoapErrmsg = "No error.";
                  }
               }
            }
         }
         if ( currSoapErr == 0 )
         {
            ExecutePrivate();
         }
         context.CloseConnections();
         sIncludeState = true;
         GXSoapXMLWriter.OpenResponse(GXSoapHTTPResponse);
         GXSoapXMLWriter.WriteStartDocument("utf-8", 0);
         GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Envelope");
         GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENV", "http://schemas.xmlsoap.org/soap/envelope/");
         GXSoapXMLWriter.WriteAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
         GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENC", "http://schemas.xmlsoap.org/soap/encoding/");
         GXSoapXMLWriter.WriteAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
         if ( ( StringUtil.StringSearch( currMethod+"&", "Execute&", 1) > 0 ) || ( currSoapErr != 0 ) )
         {
            GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Body");
            GXSoapXMLWriter.WriteStartElement("WSAsolicitudSer.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
            if ( currSoapErr == 0 )
            {
               GXSoapXMLWriter.WriteElement("Rescode", StringUtil.Trim( StringUtil.Str( (decimal)(AV12ResCode), 6, 0)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Resmessage", AV13ResMessage);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Solicitudesid", StringUtil.Trim( StringUtil.Str( (decimal)(AV28SolicitudesID), 18, 0)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
            }
            else
            {
               GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Fault");
               GXSoapXMLWriter.WriteElement("faultcode", "SOAP-ENV:Client");
               GXSoapXMLWriter.WriteElement("faultstring", currSoapErrmsg);
               GXSoapXMLWriter.WriteElement("detail", StringUtil.Trim( StringUtil.Str( (decimal)(currSoapErr), 10, 0)));
               GXSoapXMLWriter.WriteEndElement();
            }
            GXSoapXMLWriter.WriteEndElement();
            GXSoapXMLWriter.WriteEndElement();
         }
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.Close();
         cleanup();
      }

      public awsasolicitudser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awsasolicitudser( IGxContext context )
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
                           string aP4_XMLSolicitud ,
                           out int aP5_ResCode ,
                           out string aP6_ResMessage ,
                           out long aP7_SolicitudesID )
      {
         this.AV14UserConect = aP0_UserConect;
         this.AV9Key = aP1_Key;
         this.AV19ProveedorID = aP2_ProveedorID;
         this.AV38UsuarioID = aP3_UsuarioID;
         this.AV41XMLSolicitud = aP4_XMLSolicitud;
         this.AV12ResCode = 0 ;
         this.AV13ResMessage = "" ;
         this.AV28SolicitudesID = 0 ;
         initialize();
         ExecutePrivate();
         aP5_ResCode=this.AV12ResCode;
         aP6_ResMessage=this.AV13ResMessage;
         aP7_SolicitudesID=this.AV28SolicitudesID;
      }

      public long executeUdp( string aP0_UserConect ,
                              string aP1_Key ,
                              long aP2_ProveedorID ,
                              string aP3_UsuarioID ,
                              string aP4_XMLSolicitud ,
                              out int aP5_ResCode ,
                              out string aP6_ResMessage )
      {
         execute(aP0_UserConect, aP1_Key, aP2_ProveedorID, aP3_UsuarioID, aP4_XMLSolicitud, out aP5_ResCode, out aP6_ResMessage, out aP7_SolicitudesID);
         return AV28SolicitudesID ;
      }

      public void executeSubmit( string aP0_UserConect ,
                                 string aP1_Key ,
                                 long aP2_ProveedorID ,
                                 string aP3_UsuarioID ,
                                 string aP4_XMLSolicitud ,
                                 out int aP5_ResCode ,
                                 out string aP6_ResMessage ,
                                 out long aP7_SolicitudesID )
      {
         this.AV14UserConect = aP0_UserConect;
         this.AV9Key = aP1_Key;
         this.AV19ProveedorID = aP2_ProveedorID;
         this.AV38UsuarioID = aP3_UsuarioID;
         this.AV41XMLSolicitud = aP4_XMLSolicitud;
         this.AV12ResCode = 0 ;
         this.AV13ResMessage = "" ;
         this.AV28SolicitudesID = 0 ;
         SubmitImpl();
         aP5_ResCode=this.AV12ResCode;
         aP6_ResMessage=this.AV13ResMessage;
         aP7_SolicitudesID=this.AV28SolicitudesID;
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
         AV41XMLSolicitud = StringUtil.StringReplace( AV41XMLSolicitud, context.GetMessage( "<![CDATA[", ""), "");
         AV41XMLSolicitud = StringUtil.StringReplace( AV41XMLSolicitud, "]]>", "");
         AV39XML = context.GetMessage( " Original XMLSolicitud: ", "") + StringUtil.Trim( AV41XMLSolicitud);
         new debug(context ).execute(  AV39XML) ;
         AV27SolicitudesDatos.FromXml(AV41XMLSolicitud, null, "", "");
         /* Execute user subroutine: 'CREAR DEBUG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
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
               AV55SecUserId = (long)(Math.Round(NumberUtil.Val( AV38UsuarioID, "."), 18, MidpointRounding.ToEven));
               /* Execute user subroutine: 'OBTENER NOMBRE DEL USUARIO' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49SecUserFullName)) )
               {
                  AV32Solicitudes.gxTpr_Solicitudesusralta = AV55SecUserId;
               }
            }
            else
            {
               AV32Solicitudes.gxTpr_Solicitudesusralta = 1061;
               AV55SecUserId = 1061;
               /* Execute user subroutine: 'OBTENER NOMBRE DEL USUARIO' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49SecUserFullName)) )
            {
               AV32Solicitudes.gxTpr_Solicitudesotros3 = context.GetMessage( "Solicitud ingresada por un usuario sin registrar.", "");
            }
            else
            {
               AV32Solicitudes.gxTpr_Solicitudesotros3 = context.GetMessage( "Solicitud ingresada por: ", "")+StringUtil.Trim( AV49SecUserFullName);
            }
            AV32Solicitudes.gxTpr_Solicitudesnombre = AV27SolicitudesDatos.gxTpr_Nombre;
            AV32Solicitudes.gxTpr_Solicitudestelefono = AV27SolicitudesDatos.gxTpr_Telefono;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27SolicitudesDatos.gxTpr_Mail)) )
            {
               AV32Solicitudes.gxTpr_Solicitudesmail = AV27SolicitudesDatos.gxTpr_Mail;
            }
            else
            {
               AV32Solicitudes.gxTpr_Solicitudesmail = "";
            }
            AV32Solicitudes.gxTpr_Departamentoid = AV27SolicitudesDatos.gxTpr_Departamentoid;
            AV32Solicitudes.gxTpr_Departamentomunicipioid = AV27SolicitudesDatos.gxTpr_Municipioid;
            if ( AV27SolicitudesDatos.gxTpr_Zonasid > 0 )
            {
               AV32Solicitudes.gxTpr_Zonasid = AV27SolicitudesDatos.gxTpr_Zonasid;
            }
            else
            {
               AV32Solicitudes.gxTpr_Zonasid = ((0==A110ZonasID) ? 1 : 0);
            }
            AV32Solicitudes.gxTpr_Solicitudesdireccion = AV27SolicitudesDatos.gxTpr_Direccion;
            AV32Solicitudes.gxTpr_Solicitudserviciosolcoti = AV27SolicitudesDatos.gxTpr_Solicitacotizacion;
            AV32Solicitudes.gxTpr_Estadossoltipo = context.GetMessage( "SOL", "");
            if ( AV27SolicitudesDatos.gxTpr_Metodopagosid == 4 )
            {
               AV32Solicitudes.gxTpr_Estadossolid = 9;
            }
            else
            {
               AV32Solicitudes.gxTpr_Estadossolid = 1;
            }
            AV32Solicitudes.gxTpr_Solicitudesotros1 = AV27SolicitudesDatos.gxTpr_Solicitaotroservicio;
            AV32Solicitudes.gxTpr_Solicitudesotros2 = AV27SolicitudesDatos.gxTpr_Otroserviciodetalle;
            AV43Fecha = AV27SolicitudesDatos.gxTpr_Fechainstalacion;
            AV32Solicitudes.gxTpr_Solicitudesfechainstalacion = AV43Fecha;
            AV32Solicitudes.gxTpr_Solicitudeshorainstalacion = StringUtil.Trim( StringUtil.Str( (decimal)(AV27SolicitudesDatos.gxTpr_Turnoinstalacion), 10, 0));
            AV32Solicitudes.gxTpr_Solicitudescomentario = AV27SolicitudesDatos.gxTpr_Comentario;
            AV32Solicitudes.gxTpr_Metodopagosid = AV27SolicitudesDatos.gxTpr_Metodopagosid;
            AV32Solicitudes.gxTpr_Solicitudesnota = StringUtil.Trim( AV27SolicitudesDatos.gxTpr_Nombre)+context.GetMessage( " confirmó la solicitud y acceptó los términos del servicio. ", "");
            AV32Solicitudes.gxTpr_Solicitudesnotificacion = "";
            AV32Solicitudes.gxTpr_Proveedorid = AV34IDProveedor;
            AV32Solicitudes.gxTpr_Solicitudessubtipo = "T";
            /* Using cursor P007U2 */
            pr_default.execute(0, new Object[] {AV34IDProveedor});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A133ProveedorID = P007U2_A133ProveedorID[0];
               A440ProveedorPagoDefault = P007U2_A440ProveedorPagoDefault[0];
               AV45ProveedorPagoDefault = A440ProveedorPagoDefault;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P007U3 */
            pr_default.execute(1, new Object[] {AV34IDProveedor});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A133ProveedorID = P007U3_A133ProveedorID[0];
               A440ProveedorPagoDefault = P007U3_A440ProveedorPagoDefault[0];
               AV45ProveedorPagoDefault = A440ProveedorPagoDefault;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( AV27SolicitudesDatos.gxTpr_Metodopagosid == 4 )
            {
               AV32Solicitudes.gxTpr_Solicitudespagado = context.GetMessage( "N", "");
               AV32Solicitudes.gxTpr_Solicitudservicioorigenpago = "O";
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
            }
            AV32Solicitudes.Save();
            AV28SolicitudesID = AV32Solicitudes.gxTpr_Solicitudesid_Z;
            if ( AV28SolicitudesID > 0 )
            {
               AV33Boolean = AV32Solicitudes.Success();
               AV13ResMessage = StringUtil.BoolToStr( AV33Boolean);
               new relprovsol(context ).execute(  AV34IDProveedor,  AV28SolicitudesID,  AV27SolicitudesDatos.gxTpr_Nombre) ;
               /* Execute user subroutine: 'CARGARSDTNOTI' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV39XML = context.GetMessage( "SolicitudesID ", "") + StringUtil.Str( (decimal)(AV28SolicitudesID), 18, 0);
               new debug(context ).execute(  AV39XML) ;
            }
            else
            {
               if ( AV12ResCode == 0 )
               {
                  AV51Messages = AV32Solicitudes.GetMessages();
                  AV59GXV1 = 1;
                  while ( AV59GXV1 <= AV51Messages.Count )
                  {
                     AV52oneMessage = ((GeneXus.Utils.SdtMessages_Message)AV51Messages.Item(AV59GXV1));
                     AV13ResMessage += "," + (AV52oneMessage.gxTpr_Description);
                     AV59GXV1 = (int)(AV59GXV1+1);
                  }
                  AV13ResMessage = context.GetMessage( "No se pueden validar los datos proporcionados.", "") + StringUtil.Trim( AV13ResMessage);
                  AV12ResCode = 108;
                  AV39XML = context.GetMessage( "********ERROR********", "") + AV32Solicitudes.ToJSonString(true, true);
                  new debug(context ).execute(  AV39XML) ;
                  AV39XML = StringUtil.Trim( AV13ResMessage);
                  new debug(context ).execute(  AV39XML) ;
               }
            }
            if ( AV32Solicitudes.Success() )
            {
               context.CommitDataStores("wsasolicitudser",pr_default);
            }
            else
            {
               AV56Plog = new SdtPlog(context);
               AV56Plog.gxTpr_Plogmsg = context.GetMessage( "Error", "");
               AV56Plog.Save();
               context.CommitDataStores("wsasolicitudser",pr_default);
            }
            AV39XML = StringUtil.Format( context.GetMessage( "**************** &ResCode:%1 &ResMessage:%2 &SolicitudesID:%3 *************", ""), StringUtil.LTrimStr( (decimal)(AV12ResCode), 6, 0), AV13ResMessage, StringUtil.LTrimStr( (decimal)(AV28SolicitudesID), 18, 0), "", "", "", "", "", "");
            new debug(context ).execute(  AV39XML) ;
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'CREAR DEBUG' Routine */
         returnInSub = false;
         AV39XML = StringUtil.Format( context.GetMessage( "ProveedorID %1 UsuarioID%2  SolicitudesDatos%3 ", ""), StringUtil.LTrimStr( (decimal)(AV19ProveedorID), 18, 0), AV38UsuarioID, AV27SolicitudesDatos.ToXml(false, true, "", ""), "", "", "", "", "", "");
         new debug(context ).execute(  AV39XML) ;
      }

      protected void S121( )
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

      protected void S131( )
      {
         /* 'OBTENER NOMBRE DEL USUARIO' Routine */
         returnInSub = false;
         /* Using cursor P007U4 */
         pr_default.execute(2, new Object[] {AV55SecUserId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A18SecUserId = P007U4_A18SecUserId[0];
            A587SecUserFullName = P007U4_A587SecUserFullName[0];
            AV49SecUserFullName = A587SecUserFullName;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXSoapHTTPRequest = new GxSoapRequest(context) ;
         GXSoapXMLReader = new GXXMLReader(context.GetPhysicalPath());
         GXSoapHTTPResponse = new GxHttpResponse(context) ;
         GXSoapXMLWriter = new GXXMLWriter(context.GetPhysicalPath());
         currSoapErrmsg = "";
         currMethod = "";
         sTagName = "";
         AV10ok = "";
         AV39XML = "";
         AV27SolicitudesDatos = new SdtSDTASolicitudes(context);
         AV32Solicitudes = new SdtSolicitudes(context);
         AV49SecUserFullName = "";
         AV31SolicitudesMail = "";
         AV43Fecha = DateTime.MinValue;
         P007U2_A133ProveedorID = new long[1] ;
         P007U2_A440ProveedorPagoDefault = new string[] {""} ;
         A440ProveedorPagoDefault = "";
         AV45ProveedorPagoDefault = "";
         P007U3_A133ProveedorID = new long[1] ;
         P007U3_A440ProveedorPagoDefault = new string[] {""} ;
         AV36SolicitudesItems = new SdtSolicitudes_Items(context);
         AV51Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV52oneMessage = new GeneXus.Utils.SdtMessages_Message(context);
         AV56Plog = new SdtPlog(context);
         AV46SDTCNotificaciones = new SdtSDTCNotificaciones(context);
         AV47ErrorDescription = "";
         P007U4_A18SecUserId = new long[1] ;
         P007U4_A587SecUserFullName = new string[] {""} ;
         A587SecUserFullName = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.awsasolicitudser__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.awsasolicitudser__default(),
            new Object[][] {
                new Object[] {
               P007U2_A133ProveedorID, P007U2_A440ProveedorPagoDefault
               }
               , new Object[] {
               P007U3_A133ProveedorID, P007U3_A440ProveedorPagoDefault
               }
               , new Object[] {
               P007U4_A18SecUserId, P007U4_A587SecUserFullName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXSoapError ;
      private short currSoapErr ;
      private short readOk ;
      private short nOutParmCount ;
      private short AV35iTems ;
      private int AV12ResCode ;
      private int AV59GXV1 ;
      private long AV19ProveedorID ;
      private long AV28SolicitudesID ;
      private long AV34IDProveedor ;
      private long AV55SecUserId ;
      private long A110ZonasID ;
      private long A133ProveedorID ;
      private long AV37i ;
      private long A18SecUserId ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private string AV14UserConect ;
      private string AV9Key ;
      private string AV38UsuarioID ;
      private string AV41XMLSolicitud ;
      private string AV13ResMessage ;
      private string AV10ok ;
      private string AV39XML ;
      private string A440ProveedorPagoDefault ;
      private string AV45ProveedorPagoDefault ;
      private DateTime AV43Fecha ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private bool returnInSub ;
      private bool AV33Boolean ;
      private string AV49SecUserFullName ;
      private string AV31SolicitudesMail ;
      private string AV47ErrorDescription ;
      private string A587SecUserFullName ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTASolicitudes AV27SolicitudesDatos ;
      private SdtSolicitudes AV32Solicitudes ;
      private IDataStoreProvider pr_default ;
      private long[] P007U2_A133ProveedorID ;
      private string[] P007U2_A440ProveedorPagoDefault ;
      private long[] P007U3_A133ProveedorID ;
      private string[] P007U3_A440ProveedorPagoDefault ;
      private SdtSolicitudes_Items AV36SolicitudesItems ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV51Messages ;
      private GeneXus.Utils.SdtMessages_Message AV52oneMessage ;
      private SdtPlog AV56Plog ;
      private SdtSDTCNotificaciones AV46SDTCNotificaciones ;
      private long[] P007U4_A18SecUserId ;
      private string[] P007U4_A587SecUserFullName ;
      private int aP5_ResCode ;
      private string aP6_ResMessage ;
      private long aP7_SolicitudesID ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class awsasolicitudser__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class awsasolicitudser__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP007U2;
        prmP007U2 = new Object[] {
        new ParDef("@AV34IDProveedor",GXType.Decimal,18,0)
        };
        Object[] prmP007U3;
        prmP007U3 = new Object[] {
        new ParDef("@AV34IDProveedor",GXType.Decimal,18,0)
        };
        Object[] prmP007U4;
        prmP007U4 = new Object[] {
        new ParDef("@AV55SecUserId",GXType.Decimal,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("P007U2", "SELECT [ProveedorID], [ProveedorPagoDefault] FROM [Proveedor] WHERE [ProveedorID] = @AV34IDProveedor ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007U2,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P007U3", "SELECT [ProveedorID], [ProveedorPagoDefault] FROM [Proveedor] WHERE [ProveedorID] = @AV34IDProveedor ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007U3,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P007U4", "SELECT TOP 1 [SecUserId], [SecUserFullName] FROM [SecUser] WHERE [SecUserId] = @AV55SecUserId ORDER BY [SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007U4,1, GxCacheFrequency.OFF ,false,true )
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
     }
  }

}

}
