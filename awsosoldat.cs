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
   public class awsosoldat : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDat");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDat.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "Solicitudesid");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDat.ExecuteResponse");
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
               GXSoapXMLWriter.WriteAttribute("name", "Solicitudesfechaalta");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:date");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Fechainstalacion");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:date");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Estadoid");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:int");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Estado");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Nombrecliente");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Solicitudestotal");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:double");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Profesionalesid");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Nombreprofesional");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Feedbackid");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Calificacion");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:int");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Comentario");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Feedbackfechaalta");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:date");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDat.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSOSolDat.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDat.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSOSolDat.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDatSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSOSolDat.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSOSolDat.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDatSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"WSOSolDatSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "AlmangoXaction/"+"AWSOSOLDAT.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDat");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDatSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"WSOSolDatSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"awsosoldat.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "awsosoldat.aspx" + "?wsdl to get the WSDL.";
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
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Solicitudesid") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV18SolicitudesID = (long)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
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
            GXSoapXMLWriter.WriteStartElement("WSOSolDat.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
            if ( currSoapErr == 0 )
            {
               GXSoapXMLWriter.WriteElement("Rescode", StringUtil.Trim( StringUtil.Str( (decimal)(AV12ResCode), 6, 0)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Resmessage", AV13ResMessage);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               sDateCnv = "";
               sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( AV31SolicitudesFechaAlta)), 10, 0));
               sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
               sDateCnv += "-";
               sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( AV31SolicitudesFechaAlta)), 10, 0));
               sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
               sDateCnv += "-";
               sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( AV31SolicitudesFechaAlta)), 10, 0));
               sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
               GXSoapXMLWriter.WriteElement("Solicitudesfechaalta", sDateCnv);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               sDateCnv = "";
               sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( AV38FechaInstalacion)), 10, 0));
               sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
               sDateCnv += "-";
               sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( AV38FechaInstalacion)), 10, 0));
               sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
               sDateCnv += "-";
               sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( AV38FechaInstalacion)), 10, 0));
               sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
               GXSoapXMLWriter.WriteElement("Fechainstalacion", sDateCnv);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Estadoid", StringUtil.Trim( StringUtil.Str( (decimal)(AV32EstadoId), 5, 0)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Estado", AV21Estado);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Nombrecliente", AV35NombreCliente);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Solicitudestotal", StringUtil.Trim( StringUtil.Str( AV34SolicitudesTotal, 18, 2)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Profesionalesid", AV22ProfesionalesId);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Nombreprofesional", AV36NombreProfesional);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Feedbackid", StringUtil.Trim( StringUtil.Str( (decimal)(AV24FeedBackId), 18, 0)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Calificacion", StringUtil.Trim( StringUtil.Str( (decimal)(AV25Calificacion), 5, 0)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Comentario", AV26Comentario);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               sDateCnv = "";
               sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( AV27FeedBackFechaAlta)), 10, 0));
               sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
               sDateCnv += "-";
               sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( AV27FeedBackFechaAlta)), 10, 0));
               sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
               sDateCnv += "-";
               sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( AV27FeedBackFechaAlta)), 10, 0));
               sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
               GXSoapXMLWriter.WriteElement("Feedbackfechaalta", sDateCnv);
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

      public awsosoldat( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awsosoldat( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserConect ,
                           string aP1_Key ,
                           long aP2_SolicitudesID ,
                           out int aP3_ResCode ,
                           out string aP4_ResMessage ,
                           out DateTime aP5_SolicitudesFechaAlta ,
                           out DateTime aP6_FechaInstalacion ,
                           out int aP7_EstadoId ,
                           out string aP8_Estado ,
                           out string aP9_NombreCliente ,
                           out decimal aP10_SolicitudesTotal ,
                           out string aP11_ProfesionalesId ,
                           out string aP12_NombreProfesional ,
                           out long aP13_FeedBackId ,
                           out int aP14_Calificacion ,
                           out string aP15_Comentario ,
                           out DateTime aP16_FeedBackFechaAlta )
      {
         this.AV14UserConect = aP0_UserConect;
         this.AV9Key = aP1_Key;
         this.AV18SolicitudesID = aP2_SolicitudesID;
         this.AV12ResCode = 0 ;
         this.AV13ResMessage = "" ;
         this.AV31SolicitudesFechaAlta = DateTime.MinValue ;
         this.AV38FechaInstalacion = DateTime.MinValue ;
         this.AV32EstadoId = 0 ;
         this.AV21Estado = "" ;
         this.AV35NombreCliente = "" ;
         this.AV34SolicitudesTotal = 0 ;
         this.AV22ProfesionalesId = "" ;
         this.AV36NombreProfesional = "" ;
         this.AV24FeedBackId = 0 ;
         this.AV25Calificacion = 0 ;
         this.AV26Comentario = "" ;
         this.AV27FeedBackFechaAlta = DateTime.MinValue ;
         initialize();
         ExecutePrivate();
         aP3_ResCode=this.AV12ResCode;
         aP4_ResMessage=this.AV13ResMessage;
         aP5_SolicitudesFechaAlta=this.AV31SolicitudesFechaAlta;
         aP6_FechaInstalacion=this.AV38FechaInstalacion;
         aP7_EstadoId=this.AV32EstadoId;
         aP8_Estado=this.AV21Estado;
         aP9_NombreCliente=this.AV35NombreCliente;
         aP10_SolicitudesTotal=this.AV34SolicitudesTotal;
         aP11_ProfesionalesId=this.AV22ProfesionalesId;
         aP12_NombreProfesional=this.AV36NombreProfesional;
         aP13_FeedBackId=this.AV24FeedBackId;
         aP14_Calificacion=this.AV25Calificacion;
         aP15_Comentario=this.AV26Comentario;
         aP16_FeedBackFechaAlta=this.AV27FeedBackFechaAlta;
      }

      public DateTime executeUdp( string aP0_UserConect ,
                                  string aP1_Key ,
                                  long aP2_SolicitudesID ,
                                  out int aP3_ResCode ,
                                  out string aP4_ResMessage ,
                                  out DateTime aP5_SolicitudesFechaAlta ,
                                  out DateTime aP6_FechaInstalacion ,
                                  out int aP7_EstadoId ,
                                  out string aP8_Estado ,
                                  out string aP9_NombreCliente ,
                                  out decimal aP10_SolicitudesTotal ,
                                  out string aP11_ProfesionalesId ,
                                  out string aP12_NombreProfesional ,
                                  out long aP13_FeedBackId ,
                                  out int aP14_Calificacion ,
                                  out string aP15_Comentario )
      {
         execute(aP0_UserConect, aP1_Key, aP2_SolicitudesID, out aP3_ResCode, out aP4_ResMessage, out aP5_SolicitudesFechaAlta, out aP6_FechaInstalacion, out aP7_EstadoId, out aP8_Estado, out aP9_NombreCliente, out aP10_SolicitudesTotal, out aP11_ProfesionalesId, out aP12_NombreProfesional, out aP13_FeedBackId, out aP14_Calificacion, out aP15_Comentario, out aP16_FeedBackFechaAlta);
         return AV27FeedBackFechaAlta ;
      }

      public void executeSubmit( string aP0_UserConect ,
                                 string aP1_Key ,
                                 long aP2_SolicitudesID ,
                                 out int aP3_ResCode ,
                                 out string aP4_ResMessage ,
                                 out DateTime aP5_SolicitudesFechaAlta ,
                                 out DateTime aP6_FechaInstalacion ,
                                 out int aP7_EstadoId ,
                                 out string aP8_Estado ,
                                 out string aP9_NombreCliente ,
                                 out decimal aP10_SolicitudesTotal ,
                                 out string aP11_ProfesionalesId ,
                                 out string aP12_NombreProfesional ,
                                 out long aP13_FeedBackId ,
                                 out int aP14_Calificacion ,
                                 out string aP15_Comentario ,
                                 out DateTime aP16_FeedBackFechaAlta )
      {
         this.AV14UserConect = aP0_UserConect;
         this.AV9Key = aP1_Key;
         this.AV18SolicitudesID = aP2_SolicitudesID;
         this.AV12ResCode = 0 ;
         this.AV13ResMessage = "" ;
         this.AV31SolicitudesFechaAlta = DateTime.MinValue ;
         this.AV38FechaInstalacion = DateTime.MinValue ;
         this.AV32EstadoId = 0 ;
         this.AV21Estado = "" ;
         this.AV35NombreCliente = "" ;
         this.AV34SolicitudesTotal = 0 ;
         this.AV22ProfesionalesId = "" ;
         this.AV36NombreProfesional = "" ;
         this.AV24FeedBackId = 0 ;
         this.AV25Calificacion = 0 ;
         this.AV26Comentario = "" ;
         this.AV27FeedBackFechaAlta = DateTime.MinValue ;
         SubmitImpl();
         aP3_ResCode=this.AV12ResCode;
         aP4_ResMessage=this.AV13ResMessage;
         aP5_SolicitudesFechaAlta=this.AV31SolicitudesFechaAlta;
         aP6_FechaInstalacion=this.AV38FechaInstalacion;
         aP7_EstadoId=this.AV32EstadoId;
         aP8_Estado=this.AV21Estado;
         aP9_NombreCliente=this.AV35NombreCliente;
         aP10_SolicitudesTotal=this.AV34SolicitudesTotal;
         aP11_ProfesionalesId=this.AV22ProfesionalesId;
         aP12_NombreProfesional=this.AV36NombreProfesional;
         aP13_FeedBackId=this.AV24FeedBackId;
         aP14_Calificacion=this.AV25Calificacion;
         aP15_Comentario=this.AV26Comentario;
         aP16_FeedBackFechaAlta=this.AV27FeedBackFechaAlta;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10ok = context.GetMessage( "N", "");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14UserConect)) )
         {
            AV13ResMessage = context.GetMessage( "Usuario incorrecto", "");
            AV12ResCode = 101;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9Key)) )
         {
            AV13ResMessage = context.GetMessage( "llave de acceso incorrecta", "");
            AV12ResCode = 102;
         }
         else if ( StringUtil.StrCmp(AV9Key, context.GetMessage( "d3d3LmF6bWl0YS5jb20=", "")) != 0 )
         {
            AV13ResMessage = context.GetMessage( "llave de acceso incorrecta.", "");
            AV12ResCode = 103;
         }
         else
         {
            AV10ok = context.GetMessage( "S", "");
         }
         if ( StringUtil.StrCmp(AV10ok, context.GetMessage( "S", "")) == 0 )
         {
            AV39GXLvl20 = 0;
            /* Using cursor P00A92 */
            pr_default.execute(0, new Object[] {AV18SolicitudesID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A130EstadosSolTipo = P00A92_A130EstadosSolTipo[0];
               A127SolicitudesID = P00A92_A127SolicitudesID[0];
               A132EstadosSolNombre = P00A92_A132EstadosSolNombre[0];
               A171SolicitudesNombre = P00A92_A171SolicitudesNombre[0];
               A131EstadosSolId = P00A92_A131EstadosSolId[0];
               A182SolicitudesFechaAlta = P00A92_A182SolicitudesFechaAlta[0];
               n182SolicitudesFechaAlta = P00A92_n182SolicitudesFechaAlta[0];
               A184SolicitudesFechaInstalacion = P00A92_A184SolicitudesFechaInstalacion[0];
               A796SolicitudesComisionMetodoPago = P00A92_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = P00A92_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = P00A92_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = P00A92_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = P00A92_n897SolicitudesDescuento[0];
               A864SolicitudesCostoXZona = P00A92_A864SolicitudesCostoXZona[0];
               A132EstadosSolNombre = P00A92_A132EstadosSolNombre[0];
               GetSolicitudesTotal( A127SolicitudesID) ;
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
               AV39GXLvl20 = 1;
               AV21Estado = A132EstadosSolNombre;
               AV35NombreCliente = A171SolicitudesNombre;
               AV34SolicitudesTotal = A211SolicitudServicioPFinal;
               AV32EstadoId = A131EstadosSolId;
               AV31SolicitudesFechaAlta = A182SolicitudesFechaAlta;
               AV38FechaInstalacion = A184SolicitudesFechaInstalacion;
               new orelnom(context ).execute(  A127SolicitudesID, out  AV22ProfesionalesId, out  AV36NombreProfesional, out  AV28ExisteProf) ;
               if ( A131EstadosSolId == 7 )
               {
                  GXt_int1 = AV25Calificacion;
                  new ofeedbackid(context ).execute(  AV22ProfesionalesId,  AV23ClientesId,  A127SolicitudesID, out  AV24FeedBackId, out  GXt_int1, out  AV26Comentario, out  AV27FeedBackFechaAlta) ;
                  AV25Calificacion = Convert.ToInt32(GXt_int1);
               }
               AV13ResMessage = context.GetMessage( "Success.", "");
               AV12ResCode = 0;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( AV39GXLvl20 == 0 )
            {
               AV13ResMessage = context.GetMessage( "Solicitud de servicio incorrecta.", "");
               AV12ResCode = 104;
            }
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00A93 */
         pr_default.execute(1, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(1) != 101) && ( P00A93_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00A93_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00A93_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00A93_A176SolicitudesItemsPrecioFinal[0]*P00A93_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00A93_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00A93_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00A93_A176SolicitudesItemsPrecioFinal[0]*P00A93_A177SolicitudesItemsCantidad[0])-(P00A93_A180SolicitudItemsComision[0]*P00A93_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00A93_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00A93_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00A93_A176SolicitudesItemsPrecioFinal[0]*P00A93_A177SolicitudesItemsCantidad[0])+(P00A93_A180SolicitudItemsComision[0]*P00A93_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00A93_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00A93_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00A93_A176SolicitudesItemsPrecioFinal[0]*P00A93_A177SolicitudesItemsCantidad[0])-((P00A93_A176SolicitudesItemsPrecioFinal[0]*P00A93_A177SolicitudesItemsCantidad[0])*(P00A93_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00A93_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00A93_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00A93_A176SolicitudesItemsPrecioFinal[0]*P00A93_A177SolicitudesItemsCantidad[0])+((P00A93_A176SolicitudesItemsPrecioFinal[0]*P00A93_A177SolicitudesItemsCantidad[0])*(P00A93_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         sDateCnv = "";
         sNumToPad = "";
         AV10ok = "";
         P00A92_A130EstadosSolTipo = new string[] {""} ;
         P00A92_A127SolicitudesID = new long[1] ;
         P00A92_A132EstadosSolNombre = new string[] {""} ;
         P00A92_A171SolicitudesNombre = new string[] {""} ;
         P00A92_A131EstadosSolId = new int[1] ;
         P00A92_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00A92_n182SolicitudesFechaAlta = new bool[] {false} ;
         P00A92_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00A92_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00A92_A212SolicitudesCotizacion = new decimal[1] ;
         P00A92_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00A92_A897SolicitudesDescuento = new decimal[1] ;
         P00A92_n897SolicitudesDescuento = new bool[] {false} ;
         P00A92_A864SolicitudesCostoXZona = new decimal[1] ;
         A130EstadosSolTipo = "";
         A132EstadosSolNombre = "";
         A171SolicitudesNombre = "";
         A182SolicitudesFechaAlta = DateTime.MinValue;
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         AV28ExisteProf = "";
         P00A93_A127SolicitudesID = new long[1] ;
         P00A93_A134SolicitudesItemsID = new short[1] ;
         P00A93_A180SolicitudItemsComision = new decimal[1] ;
         P00A93_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00A93_A178SolicitudItemsSR = new string[] {""} ;
         P00A93_A177SolicitudesItemsCantidad = new short[1] ;
         P00A93_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00A93_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.awsosoldat__default(),
            new Object[][] {
                new Object[] {
               P00A92_A130EstadosSolTipo, P00A92_A127SolicitudesID, P00A92_A132EstadosSolNombre, P00A92_A171SolicitudesNombre, P00A92_A131EstadosSolId, P00A92_A182SolicitudesFechaAlta, P00A92_n182SolicitudesFechaAlta, P00A92_A184SolicitudesFechaInstalacion, P00A92_A796SolicitudesComisionMetodoPago, P00A92_A212SolicitudesCotizacion,
               P00A92_A1016SolicitudesDescuentoCupon, P00A92_A897SolicitudesDescuento, P00A92_n897SolicitudesDescuento, P00A92_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P00A93_A127SolicitudesID, P00A93_A134SolicitudesItemsID, P00A93_A180SolicitudItemsComision, P00A93_A179SolicitudItemsComisionTipo, P00A93_A178SolicitudItemsSR, P00A93_A177SolicitudesItemsCantidad, P00A93_A176SolicitudesItemsPrecioFinal, P00A93_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXSoapError ;
      private short currSoapErr ;
      private short readOk ;
      private short nOutParmCount ;
      private short AV39GXLvl20 ;
      private int AV12ResCode ;
      private int AV32EstadoId ;
      private int AV25Calificacion ;
      private int A131EstadosSolId ;
      private long AV18SolicitudesID ;
      private long AV24FeedBackId ;
      private long A127SolicitudesID ;
      private long AV23ClientesId ;
      private long GXt_int1 ;
      private decimal AV34SolicitudesTotal ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private string AV14UserConect ;
      private string AV9Key ;
      private string AV13ResMessage ;
      private string sDateCnv ;
      private string sNumToPad ;
      private string AV21Estado ;
      private string AV35NombreCliente ;
      private string AV22ProfesionalesId ;
      private string AV36NombreProfesional ;
      private string AV10ok ;
      private string A130EstadosSolTipo ;
      private string A132EstadosSolNombre ;
      private string A171SolicitudesNombre ;
      private string AV28ExisteProf ;
      private DateTime AV31SolicitudesFechaAlta ;
      private DateTime AV38FechaInstalacion ;
      private DateTime AV27FeedBackFechaAlta ;
      private DateTime A182SolicitudesFechaAlta ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private bool n182SolicitudesFechaAlta ;
      private bool n897SolicitudesDescuento ;
      private string AV26Comentario ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00A92_A130EstadosSolTipo ;
      private long[] P00A92_A127SolicitudesID ;
      private string[] P00A92_A132EstadosSolNombre ;
      private string[] P00A92_A171SolicitudesNombre ;
      private int[] P00A92_A131EstadosSolId ;
      private DateTime[] P00A92_A182SolicitudesFechaAlta ;
      private bool[] P00A92_n182SolicitudesFechaAlta ;
      private DateTime[] P00A92_A184SolicitudesFechaInstalacion ;
      private decimal[] P00A92_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00A92_A212SolicitudesCotizacion ;
      private decimal[] P00A92_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00A92_A897SolicitudesDescuento ;
      private bool[] P00A92_n897SolicitudesDescuento ;
      private decimal[] P00A92_A864SolicitudesCostoXZona ;
      private long[] P00A93_A127SolicitudesID ;
      private short[] P00A93_A134SolicitudesItemsID ;
      private decimal[] P00A93_A180SolicitudItemsComision ;
      private string[] P00A93_A179SolicitudItemsComisionTipo ;
      private string[] P00A93_A178SolicitudItemsSR ;
      private short[] P00A93_A177SolicitudesItemsCantidad ;
      private decimal[] P00A93_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00A93_n176SolicitudesItemsPrecioFinal ;
      private int aP3_ResCode ;
      private string aP4_ResMessage ;
      private DateTime aP5_SolicitudesFechaAlta ;
      private DateTime aP6_FechaInstalacion ;
      private int aP7_EstadoId ;
      private string aP8_Estado ;
      private string aP9_NombreCliente ;
      private decimal aP10_SolicitudesTotal ;
      private string aP11_ProfesionalesId ;
      private string aP12_NombreProfesional ;
      private long aP13_FeedBackId ;
      private int aP14_Calificacion ;
      private string aP15_Comentario ;
      private DateTime aP16_FeedBackFechaAlta ;
   }

   public class awsosoldat__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00A92;
          prmP00A92 = new Object[] {
          new ParDef("@AV18SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00A93;
          prmP00A93 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A92", "SELECT T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudesID], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudesNombre], T1.[EstadosSolId] AS EstadosSolId, T1.[SolicitudesFechaAlta], T1.[SolicitudesFechaInstalacion], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM ([Solicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId]) WHERE T1.[SolicitudesID] = @AV18SolicitudesID ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A92,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00A93", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A93,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                return;
             case 1 :
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
