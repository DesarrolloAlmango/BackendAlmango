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
   public class awsoserviciosdet : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         AV15SDTServicios = new SdtSDTServicioDetalle(context) ;
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDet");
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
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "SDTServicioDetalle");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "RubrosId");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:short");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "RubrosNombre");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Producto");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "Item");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTServicioDetalle.Item");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "ArrayOfSDTServicioDetalle.Item");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "SDTServicioDetalle.Item");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTServicioDetalle.Item");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "SDTServicioDetalle.Item");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "ProductoID");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "ProductoNombre");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "TerminosId");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Detalles");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "DetalleItem");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTServicioDetalle.Item.DetalleItem");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "ArrayOfSDTServicioDetalle.Item.DetalleItem");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "SDTServicioDetalle.Item.DetalleItem");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTServicioDetalle.Item.DetalleItem");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "SDTServicioDetalle.Item.DetalleItem");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "DetalleID");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "DetalleNombre");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Imagen");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Imagen_GXI");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "MonedaId");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:short");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "MonedaISO");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Precio");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:double");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Comision");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:double");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "SR");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "TipoComision");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "PrecioFinal");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:double");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "TerminosId");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDet.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "Rubrosid");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:short");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Proveedorid");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDet.ExecuteResponse");
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
               GXSoapXMLWriter.WriteAttribute("name", "Sdtservicios");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTServicioDetalle");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDet.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSOServiciosDet.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDet.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSOServiciosDet.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDetSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSOServiciosDet.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSOServiciosDet.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDetSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"WSOServiciosDetSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "AlmangoXaction/"+"AWSOSERVICIOSDET.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDet");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDetSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"WSOServiciosDetSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"awsoserviciosdet.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "awsoserviciosdet.aspx" + "?wsdl to get the WSDL.";
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
                        AV15SDTServicios = new SdtSDTServicioDetalle(context);
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
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Rubrosid") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV17RubrosId = (short)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
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
            GXSoapXMLWriter.WriteStartElement("WSOServiciosDet.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
            if ( currSoapErr == 0 )
            {
               GXSoapXMLWriter.WriteElement("Rescode", StringUtil.Trim( StringUtil.Str( (decimal)(AV12ResCode), 6, 0)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Resmessage", AV13ResMessage);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               if ( AV15SDTServicios != null )
               {
                  AV15SDTServicios.writexml(GXSoapXMLWriter, "Sdtservicios", "AlmangoX");
               }
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

      public awsoserviciosdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awsoserviciosdet( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserConect ,
                           string aP1_Key ,
                           short aP2_RubrosId ,
                           long aP3_ProveedorID ,
                           out int aP4_ResCode ,
                           out string aP5_ResMessage ,
                           out SdtSDTServicioDetalle aP6_SDTServicios )
      {
         this.AV14UserConect = aP0_UserConect;
         this.AV9Key = aP1_Key;
         this.AV17RubrosId = aP2_RubrosId;
         this.AV19ProveedorID = aP3_ProveedorID;
         this.AV12ResCode = 0 ;
         this.AV13ResMessage = "" ;
         this.AV15SDTServicios = new SdtSDTServicioDetalle(context) ;
         initialize();
         ExecutePrivate();
         aP4_ResCode=this.AV12ResCode;
         aP5_ResMessage=this.AV13ResMessage;
         aP6_SDTServicios=this.AV15SDTServicios;
      }

      public SdtSDTServicioDetalle executeUdp( string aP0_UserConect ,
                                               string aP1_Key ,
                                               short aP2_RubrosId ,
                                               long aP3_ProveedorID ,
                                               out int aP4_ResCode ,
                                               out string aP5_ResMessage )
      {
         execute(aP0_UserConect, aP1_Key, aP2_RubrosId, aP3_ProveedorID, out aP4_ResCode, out aP5_ResMessage, out aP6_SDTServicios);
         return AV15SDTServicios ;
      }

      public void executeSubmit( string aP0_UserConect ,
                                 string aP1_Key ,
                                 short aP2_RubrosId ,
                                 long aP3_ProveedorID ,
                                 out int aP4_ResCode ,
                                 out string aP5_ResMessage ,
                                 out SdtSDTServicioDetalle aP6_SDTServicios )
      {
         this.AV14UserConect = aP0_UserConect;
         this.AV9Key = aP1_Key;
         this.AV17RubrosId = aP2_RubrosId;
         this.AV19ProveedorID = aP3_ProveedorID;
         this.AV12ResCode = 0 ;
         this.AV13ResMessage = "" ;
         this.AV15SDTServicios = new SdtSDTServicioDetalle(context) ;
         SubmitImpl();
         aP4_ResCode=this.AV12ResCode;
         aP5_ResMessage=this.AV13ResMessage;
         aP6_SDTServicios=this.AV15SDTServicios;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10ok = false;
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
         else if ( AV19ProveedorID == 0 )
         {
            AV13ResMessage = context.GetMessage( "Debe proporcionar el código de un proveedor de solicitudes.", "");
            AV12ResCode = 106;
         }
         else
         {
            AV10ok = true;
         }
         /* Using cursor P00832 */
         pr_default.execute(0, new Object[] {AV19ProveedorID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A344ProveedorEstado = P00832_A344ProveedorEstado[0];
            A133ProveedorID = P00832_A133ProveedorID[0];
            if ( StringUtil.StrCmp(A344ProveedorEstado, context.GetMessage( "HAB", "")) == 0 )
            {
               AV20ProvedorOK = context.GetMessage( "S", "");
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( ( AV10ok ) && ( StringUtil.StrCmp(AV20ProvedorOK, context.GetMessage( "S", "")) == 0 ) )
         {
            /* Using cursor P00833 */
            pr_default.execute(1, new Object[] {AV17RubrosId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A121RubrosId = P00833_A121RubrosId[0];
               A122RubrosNombre = P00833_A122RubrosNombre[0];
               new orubroitemactivo(context ).execute(  AV19ProveedorID,  A121RubrosId,  AV21MedidasID,  AV22InventarioId, out  AV10ok) ;
               if ( AV10ok )
               {
                  AV15SDTServicios.gxTpr_Rubrosid = AV17RubrosId;
                  AV15SDTServicios.gxTpr_Rubrosnombre = A122RubrosNombre;
                  /* Using cursor P00834 */
                  pr_default.execute(2, new Object[] {A121RubrosId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A137MedidasID = P00834_A137MedidasID[0];
                     A118MonedaId = P00834_A118MonedaId[0];
                     A119MonedaISOSimbolo = P00834_A119MonedaISOSimbolo[0];
                     A139MedidasEstado = P00834_A139MedidasEstado[0];
                     n139MedidasEstado = P00834_n139MedidasEstado[0];
                     A138MedidasNombre = P00834_A138MedidasNombre[0];
                     A150TextosId = P00834_A150TextosId[0];
                     n150TextosId = P00834_n150TextosId[0];
                     A119MonedaISOSimbolo = P00834_A119MonedaISOSimbolo[0];
                     new orubroitemactivo(context ).execute(  AV19ProveedorID,  A121RubrosId,  A137MedidasID,  0, out  AV10ok) ;
                     if ( AV10ok )
                     {
                        AV16Item.gxTpr_Productoid = A137MedidasID;
                        AV16Item.gxTpr_Productonombre = A138MedidasNombre;
                        AV21MedidasID = A137MedidasID;
                        AV23MonedaId = A118MonedaId;
                        AV16Item.gxTpr_Terminosid = A150TextosId;
                        /* Using cursor P00835 */
                        pr_default.execute(3, new Object[] {A121RubrosId, A137MedidasID});
                        while ( (pr_default.getStatus(3) != 101) )
                        {
                           A108EstadosGenericosId = P00835_A108EstadosGenericosId[0];
                           A107EstadosTipo = P00835_A107EstadosTipo[0];
                           A40000InventarioImagen_GXI = P00835_A40000InventarioImagen_GXI[0];
                           A135InventarioId = P00835_A135InventarioId[0];
                           A136InventarioNombre = P00835_A136InventarioNombre[0];
                           A181InventarioPrecioFinal = P00835_A181InventarioPrecioFinal[0];
                           A535InventarioTextosId = P00835_A535InventarioTextosId[0];
                           n535InventarioTextosId = P00835_n535InventarioTextosId[0];
                           A189InventarioImagen = P00835_A189InventarioImagen[0];
                           if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "INV", "")) == 0 )
                           {
                              new orubroitemactivo(context ).execute(  AV19ProveedorID,  A121RubrosId,  A137MedidasID,  A135InventarioId, out  AV10ok) ;
                              if ( AV10ok )
                              {
                                 AV22InventarioId = A135InventarioId;
                                 AV18ItemDet.gxTpr_Detalleid = A135InventarioId;
                                 AV18ItemDet.gxTpr_Detallenombre = A136InventarioNombre;
                                 AV18ItemDet.gxTpr_Imagen = A189InventarioImagen;
                                 AV18ItemDet.gxTpr_Imagen_gxi = A40000InventarioImagen_GXI;
                                 AV18ItemDet.gxTpr_Monedaid = A118MonedaId;
                                 AV18ItemDet.gxTpr_Monedaiso = A119MonedaISOSimbolo;
                                 new oprecprov(context ).execute(  AV19ProveedorID,  AV17RubrosId,  AV21MedidasID,  AV22InventarioId,  AV23MonedaId, out  AV24SolicitudItemsComision, out  AV25SolicitudItemsSR, out  AV26SolicitudItemsComisionTipo, out  AV29PrecioFinal, out  AV28Freezar) ;
                                 AV30InventarioPrecioFinal = ((AV28Freezar) ? AV29PrecioFinal : A181InventarioPrecioFinal);
                                 if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25SolicitudItemsSR)) || ( StringUtil.StrCmp(AV26SolicitudItemsComisionTipo, context.GetMessage( "N", "")) == 0 ) )
                                 {
                                    AV27Precio = AV30InventarioPrecioFinal;
                                 }
                                 if ( ( StringUtil.StrCmp(AV26SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(AV25SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
                                 {
                                    AV27Precio = (decimal)((AV30InventarioPrecioFinal)-(AV24SolicitudItemsComision));
                                 }
                                 if ( ( StringUtil.StrCmp(AV26SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(AV25SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
                                 {
                                    AV27Precio = (decimal)((AV30InventarioPrecioFinal)+(AV24SolicitudItemsComision));
                                 }
                                 if ( ( StringUtil.StrCmp(AV26SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(AV25SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
                                 {
                                    AV27Precio = (decimal)((AV30InventarioPrecioFinal)-((AV30InventarioPrecioFinal)*(AV24SolicitudItemsComision/ (decimal)(100))));
                                 }
                                 if ( ( StringUtil.StrCmp(AV26SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(AV25SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
                                 {
                                    AV27Precio = (decimal)((AV30InventarioPrecioFinal)+((AV30InventarioPrecioFinal)*(AV24SolicitudItemsComision/ (decimal)(100))));
                                 }
                                 AV18ItemDet.gxTpr_Preciofinal = AV27Precio;
                                 AV18ItemDet.gxTpr_Precio = AV30InventarioPrecioFinal;
                                 AV18ItemDet.gxTpr_Sr = AV25SolicitudItemsSR;
                                 AV18ItemDet.gxTpr_Comision = AV24SolicitudItemsComision;
                                 AV18ItemDet.gxTpr_Tipocomision = AV26SolicitudItemsComisionTipo;
                                 AV18ItemDet.gxTpr_Terminosid = A535InventarioTextosId;
                                 AV16Item.gxTpr_Detalles.Add(AV18ItemDet, 0);
                                 AV18ItemDet = new SdtSDTServicioDetalle_Item_DetalleItem(context);
                              }
                           }
                           pr_default.readNext(3);
                        }
                        pr_default.close(3);
                        if ( AV16Item.gxTpr_Detalles.Count == 1 )
                        {
                           AV16Item.gxTpr_Detalles.Add(AV18ItemDet, 0);
                           AV18ItemDet = new SdtSDTServicioDetalle_Item_DetalleItem(context);
                        }
                        AV15SDTServicios.gxTpr_Producto.Add(AV16Item, 0);
                        AV16Item = new SdtSDTServicioDetalle_Item(context);
                     }
                     pr_default.readNext(2);
                  }
                  pr_default.close(2);
               }
               AV13ResMessage = context.GetMessage( "Proceso Completado.", "");
               AV12ResCode = 0;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
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
         P00832_A344ProveedorEstado = new string[] {""} ;
         P00832_A133ProveedorID = new long[1] ;
         A344ProveedorEstado = "";
         AV20ProvedorOK = "";
         P00833_A121RubrosId = new short[1] ;
         P00833_A122RubrosNombre = new string[] {""} ;
         A122RubrosNombre = "";
         P00834_A121RubrosId = new short[1] ;
         P00834_A137MedidasID = new long[1] ;
         P00834_A118MonedaId = new short[1] ;
         P00834_A119MonedaISOSimbolo = new string[] {""} ;
         P00834_A139MedidasEstado = new string[] {""} ;
         P00834_n139MedidasEstado = new bool[] {false} ;
         P00834_A138MedidasNombre = new string[] {""} ;
         P00834_A150TextosId = new long[1] ;
         P00834_n150TextosId = new bool[] {false} ;
         A119MonedaISOSimbolo = "";
         A139MedidasEstado = "";
         A138MedidasNombre = "";
         AV16Item = new SdtSDTServicioDetalle_Item(context);
         P00835_A121RubrosId = new short[1] ;
         P00835_A137MedidasID = new long[1] ;
         P00835_A108EstadosGenericosId = new int[1] ;
         P00835_A107EstadosTipo = new string[] {""} ;
         P00835_A40000InventarioImagen_GXI = new string[] {""} ;
         P00835_A135InventarioId = new long[1] ;
         P00835_A136InventarioNombre = new string[] {""} ;
         P00835_A181InventarioPrecioFinal = new decimal[1] ;
         P00835_A535InventarioTextosId = new long[1] ;
         P00835_n535InventarioTextosId = new bool[] {false} ;
         P00835_A189InventarioImagen = new string[] {""} ;
         A107EstadosTipo = "";
         A40000InventarioImagen_GXI = "";
         A136InventarioNombre = "";
         A189InventarioImagen = "";
         AV18ItemDet = new SdtSDTServicioDetalle_Item_DetalleItem(context);
         AV25SolicitudItemsSR = "";
         AV26SolicitudItemsComisionTipo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.awsoserviciosdet__default(),
            new Object[][] {
                new Object[] {
               P00832_A344ProveedorEstado, P00832_A133ProveedorID
               }
               , new Object[] {
               P00833_A121RubrosId, P00833_A122RubrosNombre
               }
               , new Object[] {
               P00834_A121RubrosId, P00834_A137MedidasID, P00834_A118MonedaId, P00834_A119MonedaISOSimbolo, P00834_A139MedidasEstado, P00834_n139MedidasEstado, P00834_A138MedidasNombre, P00834_A150TextosId, P00834_n150TextosId
               }
               , new Object[] {
               P00835_A121RubrosId, P00835_A137MedidasID, P00835_A108EstadosGenericosId, P00835_A107EstadosTipo, P00835_A40000InventarioImagen_GXI, P00835_A135InventarioId, P00835_A136InventarioNombre, P00835_A181InventarioPrecioFinal, P00835_A535InventarioTextosId, P00835_n535InventarioTextosId,
               P00835_A189InventarioImagen
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXSoapError ;
      private short currSoapErr ;
      private short readOk ;
      private short nOutParmCount ;
      private short AV17RubrosId ;
      private short A121RubrosId ;
      private short A118MonedaId ;
      private short AV23MonedaId ;
      private int AV12ResCode ;
      private int A108EstadosGenericosId ;
      private long AV19ProveedorID ;
      private long A133ProveedorID ;
      private long AV21MedidasID ;
      private long AV22InventarioId ;
      private long A137MedidasID ;
      private long A150TextosId ;
      private long A135InventarioId ;
      private long A535InventarioTextosId ;
      private decimal A181InventarioPrecioFinal ;
      private decimal AV24SolicitudItemsComision ;
      private decimal AV29PrecioFinal ;
      private decimal AV30InventarioPrecioFinal ;
      private decimal AV27Precio ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private string AV14UserConect ;
      private string AV9Key ;
      private string AV13ResMessage ;
      private string A344ProveedorEstado ;
      private string AV20ProvedorOK ;
      private string A122RubrosNombre ;
      private string A119MonedaISOSimbolo ;
      private string A139MedidasEstado ;
      private string A138MedidasNombre ;
      private string A107EstadosTipo ;
      private string A136InventarioNombre ;
      private string AV25SolicitudItemsSR ;
      private string AV26SolicitudItemsComisionTipo ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private bool AV10ok ;
      private bool n139MedidasEstado ;
      private bool n150TextosId ;
      private bool n535InventarioTextosId ;
      private bool AV28Freezar ;
      private string A40000InventarioImagen_GXI ;
      private string A189InventarioImagen ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private SdtSDTServicioDetalle AV15SDTServicios ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00832_A344ProveedorEstado ;
      private long[] P00832_A133ProveedorID ;
      private short[] P00833_A121RubrosId ;
      private string[] P00833_A122RubrosNombre ;
      private short[] P00834_A121RubrosId ;
      private long[] P00834_A137MedidasID ;
      private short[] P00834_A118MonedaId ;
      private string[] P00834_A119MonedaISOSimbolo ;
      private string[] P00834_A139MedidasEstado ;
      private bool[] P00834_n139MedidasEstado ;
      private string[] P00834_A138MedidasNombre ;
      private long[] P00834_A150TextosId ;
      private bool[] P00834_n150TextosId ;
      private SdtSDTServicioDetalle_Item AV16Item ;
      private short[] P00835_A121RubrosId ;
      private long[] P00835_A137MedidasID ;
      private int[] P00835_A108EstadosGenericosId ;
      private string[] P00835_A107EstadosTipo ;
      private string[] P00835_A40000InventarioImagen_GXI ;
      private long[] P00835_A135InventarioId ;
      private string[] P00835_A136InventarioNombre ;
      private decimal[] P00835_A181InventarioPrecioFinal ;
      private long[] P00835_A535InventarioTextosId ;
      private bool[] P00835_n535InventarioTextosId ;
      private string[] P00835_A189InventarioImagen ;
      private SdtSDTServicioDetalle_Item_DetalleItem AV18ItemDet ;
      private int aP4_ResCode ;
      private string aP5_ResMessage ;
      private SdtSDTServicioDetalle aP6_SDTServicios ;
   }

   public class awsoserviciosdet__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00832;
          prmP00832 = new Object[] {
          new ParDef("@AV19ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00833;
          prmP00833 = new Object[] {
          new ParDef("@AV17RubrosId",GXType.Int16,4,0)
          };
          Object[] prmP00834;
          prmP00834 = new Object[] {
          new ParDef("@RubrosId",GXType.Int16,4,0)
          };
          Object[] prmP00835;
          prmP00835 = new Object[] {
          new ParDef("@RubrosId",GXType.Int16,4,0) ,
          new ParDef("@MedidasID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00832", "SELECT [ProveedorEstado], [ProveedorID] FROM [Proveedor] WHERE [ProveedorID] = @AV19ProveedorID ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00832,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00833", "SELECT [RubrosId], [RubrosNombre] FROM [Rubros] WHERE [RubrosId] = @AV17RubrosId ORDER BY [RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00833,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00834", "SELECT T1.[RubrosId], T1.[MedidasID], T1.[MonedaId], T2.[MonedaISOSimbolo], T1.[MedidasEstado], T1.[MedidasNombre], T1.[TextosId] FROM ([RubrosMedidas] T1 INNER JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId]) WHERE (T1.[RubrosId] = @RubrosId) AND (T1.[MedidasEstado] = 'HAB') ORDER BY T1.[RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00834,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00835", "SELECT [RubrosId], [MedidasID], [EstadosGenericosId], [EstadosTipo], [InventarioImagen_GXI], [InventarioId], [InventarioNombre], [InventarioPrecioFinal], [InventarioTextosId], [InventarioImagen] FROM [Inventario] WHERE ([RubrosId] = @RubrosId and [MedidasID] = @MedidasID) AND ([EstadosGenericosId] = 1) ORDER BY [RubrosId], [MedidasID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00835,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 50);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
                return;
       }
    }

 }

}
