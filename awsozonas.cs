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
   public class awsozonas : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         AV14SDTZonas = new SdtSDTZonas(context) ;
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOZonas");
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
               GXSoapXMLWriter.WriteAttribute("name", "SDTZonas");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "PaisISO");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Departamentos");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "DepartamentosItem");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTZonas.DepartamentosItem");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "ArrayOfSDTZonas.DepartamentosItem");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "SDTZonas.DepartamentosItem");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTZonas.DepartamentosItem");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "SDTZonas.DepartamentosItem");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "DepartamentoId");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "DepartamentoNombre");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Municipios");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "MunicipiosItem");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTZonas.DepartamentosItem.MunicipiosItem");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "ArrayOfSDTZonas.DepartamentosItem.MunicipiosItem");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "SDTZonas.DepartamentosItem.MunicipiosItem");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTZonas.DepartamentosItem.MunicipiosItem");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "SDTZonas.DepartamentosItem.MunicipiosItem");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "MunicipioId");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "MunicipioNombre");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Zonas");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "ZonasItem");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTZonas.DepartamentosItem.MunicipiosItem.ZonasItem");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "ArrayOfSDTZonas.DepartamentosItem.MunicipiosItem.ZonasItem");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "SDTZonas.DepartamentosItem.MunicipiosItem.ZonasItem");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTZonas.DepartamentosItem.MunicipiosItem.ZonasItem");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "SDTZonas.DepartamentosItem.MunicipiosItem.ZonasItem");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "ZonasID");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "ZonasNombre");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WSOZonas.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "Paisiso");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WSOZonas.ExecuteResponse");
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
               GXSoapXMLWriter.WriteAttribute("name", "Sdtzonas");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTZonas");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSOZonas.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSOZonas.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSOZonas.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSOZonas.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "WSOZonasSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSOZonas.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSOZonas.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "WSOZonasSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"WSOZonasSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "AlmangoXaction/"+"AWSOZONAS.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOZonas");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "WSOZonasSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"WSOZonasSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"awsozonas.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "awsozonas.aspx" + "?wsdl to get the WSDL.";
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
                        AV14SDTZonas = new SdtSDTZonas(context);
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
                                 AV8UserConect = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Key") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV11Key = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Paisiso") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV13PaisISO = GXSoapXMLReader.Value;
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
            GXSoapXMLWriter.WriteStartElement("WSOZonas.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
            if ( currSoapErr == 0 )
            {
               GXSoapXMLWriter.WriteElement("Rescode", StringUtil.Trim( StringUtil.Str( (decimal)(AV10ResCode), 6, 0)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Resmessage", AV9ResMessage);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               if ( AV14SDTZonas != null )
               {
                  AV14SDTZonas.writexml(GXSoapXMLWriter, "Sdtzonas", "AlmangoX");
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

      public awsozonas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awsozonas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserConect ,
                           string aP1_Key ,
                           string aP2_PaisISO ,
                           out int aP3_ResCode ,
                           out string aP4_ResMessage ,
                           out SdtSDTZonas aP5_SDTZonas )
      {
         this.AV8UserConect = aP0_UserConect;
         this.AV11Key = aP1_Key;
         this.AV13PaisISO = aP2_PaisISO;
         this.AV10ResCode = 0 ;
         this.AV9ResMessage = "" ;
         this.AV14SDTZonas = new SdtSDTZonas(context) ;
         initialize();
         ExecutePrivate();
         aP3_ResCode=this.AV10ResCode;
         aP4_ResMessage=this.AV9ResMessage;
         aP5_SDTZonas=this.AV14SDTZonas;
      }

      public SdtSDTZonas executeUdp( string aP0_UserConect ,
                                     string aP1_Key ,
                                     string aP2_PaisISO ,
                                     out int aP3_ResCode ,
                                     out string aP4_ResMessage )
      {
         execute(aP0_UserConect, aP1_Key, aP2_PaisISO, out aP3_ResCode, out aP4_ResMessage, out aP5_SDTZonas);
         return AV14SDTZonas ;
      }

      public void executeSubmit( string aP0_UserConect ,
                                 string aP1_Key ,
                                 string aP2_PaisISO ,
                                 out int aP3_ResCode ,
                                 out string aP4_ResMessage ,
                                 out SdtSDTZonas aP5_SDTZonas )
      {
         this.AV8UserConect = aP0_UserConect;
         this.AV11Key = aP1_Key;
         this.AV13PaisISO = aP2_PaisISO;
         this.AV10ResCode = 0 ;
         this.AV9ResMessage = "" ;
         this.AV14SDTZonas = new SdtSDTZonas(context) ;
         SubmitImpl();
         aP3_ResCode=this.AV10ResCode;
         aP4_ResMessage=this.AV9ResMessage;
         aP5_SDTZonas=this.AV14SDTZonas;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12ok = context.GetMessage( "N", "");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8UserConect)) )
         {
            AV9ResMessage = context.GetMessage( "Usuario incorrecto", "");
            AV10ResCode = 102;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11Key)) )
         {
            AV9ResMessage = context.GetMessage( "llave de acceso incorrecta", "");
            AV10ResCode = 104;
         }
         else if ( StringUtil.StrCmp(AV11Key, context.GetMessage( "d3d3LmF6bWl0YS5jb20=", "")) != 0 )
         {
            AV9ResMessage = context.GetMessage( "llave de acceso incorrecta.", "");
            AV10ResCode = 105;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13PaisISO)) )
         {
            AV9ResMessage = context.GetMessage( "País ISO incorrecto.", "");
            AV10ResCode = 106;
         }
         else
         {
            AV12ok = context.GetMessage( "S", "");
         }
         if ( StringUtil.StrCmp(AV12ok, context.GetMessage( "S", "")) == 0 )
         {
            AV20GXLvl22 = 0;
            /* Using cursor P00872 */
            pr_default.execute(0, new Object[] {AV13PaisISO});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK872 = false;
               A907DepartamentoEstado = P00872_A907DepartamentoEstado[0];
               n907DepartamentoEstado = P00872_n907DepartamentoEstado[0];
               A112DepartamentoId = P00872_A112DepartamentoId[0];
               A113DepartamentoDepartamento = P00872_A113DepartamentoDepartamento[0];
               A116PaisID = P00872_A116PaisID[0];
               AV20GXLvl22 = 1;
               AV16DepartamentoId = A112DepartamentoId;
               AV14SDTZonas.gxTpr_Paisiso = A116PaisID;
               while ( (pr_default.getStatus(0) != 101) && ( P00872_A112DepartamentoId[0] == A112DepartamentoId ) )
               {
                  BRK872 = false;
                  A907DepartamentoEstado = P00872_A907DepartamentoEstado[0];
                  n907DepartamentoEstado = P00872_n907DepartamentoEstado[0];
                  A113DepartamentoDepartamento = P00872_A113DepartamentoDepartamento[0];
                  if ( A112DepartamentoId == AV16DepartamentoId )
                  {
                     if ( StringUtil.StrCmp(A907DepartamentoEstado, context.GetMessage( "DES", "")) != 0 )
                     {
                        AV15SdtZonasItem = new SdtSDTZonas_DepartamentosItem(context);
                        AV15SdtZonasItem.gxTpr_Departamentoid = A112DepartamentoId;
                        AV15SdtZonasItem.gxTpr_Departamentonombre = A113DepartamentoDepartamento;
                        /* Using cursor P00873 */
                        pr_default.execute(1, new Object[] {A112DepartamentoId});
                        while ( (pr_default.getStatus(1) != 101) )
                        {
                           A114DepartamentoMunicipioId = P00873_A114DepartamentoMunicipioId[0];
                           A908DepartamentoMunicipioEstado = P00873_A908DepartamentoMunicipioEstado[0];
                           n908DepartamentoMunicipioEstado = P00873_n908DepartamentoMunicipioEstado[0];
                           A115DepartamentoMunicipioNombre = P00873_A115DepartamentoMunicipioNombre[0];
                           if ( StringUtil.StrCmp(A908DepartamentoMunicipioEstado, context.GetMessage( "DES", "")) != 0 )
                           {
                              AV17MuniItem = new SdtSDTZonas_DepartamentosItem_MunicipiosItem(context);
                              AV17MuniItem.gxTpr_Municipioid = A114DepartamentoMunicipioId;
                              AV17MuniItem.gxTpr_Municipionombre = A115DepartamentoMunicipioNombre;
                              /* Using cursor P00874 */
                              pr_default.execute(2, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
                              while ( (pr_default.getStatus(2) != 101) )
                              {
                                 A906ZonasEstado = P00874_A906ZonasEstado[0];
                                 n906ZonasEstado = P00874_n906ZonasEstado[0];
                                 A110ZonasID = P00874_A110ZonasID[0];
                                 A111ZonasNombre = P00874_A111ZonasNombre[0];
                                 if ( StringUtil.StrCmp(A906ZonasEstado, context.GetMessage( "DES", "")) != 0 )
                                 {
                                    AV19ZonasItem = new SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem(context);
                                    AV19ZonasItem.gxTpr_Zonasid = A110ZonasID;
                                    AV19ZonasItem.gxTpr_Zonasnombre = A111ZonasNombre;
                                    AV17MuniItem.gxTpr_Zonas.Add(AV19ZonasItem, 0);
                                 }
                                 pr_default.readNext(2);
                              }
                              pr_default.close(2);
                              AV15SdtZonasItem.gxTpr_Municipios.Add(AV17MuniItem, 0);
                           }
                           pr_default.readNext(1);
                        }
                        pr_default.close(1);
                        AV14SDTZonas.gxTpr_Departamentos.Add(AV15SdtZonasItem, 0);
                     }
                  }
                  BRK872 = true;
                  pr_default.readNext(0);
               }
               AV9ResMessage = context.GetMessage( "Proceso Completado.", "");
               AV10ResCode = 0;
               if ( ! BRK872 )
               {
                  BRK872 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            if ( AV20GXLvl22 == 0 )
            {
               AV9ResMessage = context.GetMessage( "No hay datos para el código del país ingresado.", "");
               AV10ResCode = 206;
            }
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
         AV12ok = "";
         P00872_A907DepartamentoEstado = new string[] {""} ;
         P00872_n907DepartamentoEstado = new bool[] {false} ;
         P00872_A112DepartamentoId = new long[1] ;
         P00872_A113DepartamentoDepartamento = new string[] {""} ;
         P00872_A116PaisID = new string[] {""} ;
         A907DepartamentoEstado = "";
         A113DepartamentoDepartamento = "";
         A116PaisID = "";
         AV15SdtZonasItem = new SdtSDTZonas_DepartamentosItem(context);
         P00873_A112DepartamentoId = new long[1] ;
         P00873_A114DepartamentoMunicipioId = new long[1] ;
         P00873_A908DepartamentoMunicipioEstado = new string[] {""} ;
         P00873_n908DepartamentoMunicipioEstado = new bool[] {false} ;
         P00873_A115DepartamentoMunicipioNombre = new string[] {""} ;
         A908DepartamentoMunicipioEstado = "";
         A115DepartamentoMunicipioNombre = "";
         AV17MuniItem = new SdtSDTZonas_DepartamentosItem_MunicipiosItem(context);
         P00874_A112DepartamentoId = new long[1] ;
         P00874_A114DepartamentoMunicipioId = new long[1] ;
         P00874_A906ZonasEstado = new string[] {""} ;
         P00874_n906ZonasEstado = new bool[] {false} ;
         P00874_A110ZonasID = new long[1] ;
         P00874_A111ZonasNombre = new string[] {""} ;
         A906ZonasEstado = "";
         A111ZonasNombre = "";
         AV19ZonasItem = new SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.awsozonas__default(),
            new Object[][] {
                new Object[] {
               P00872_A907DepartamentoEstado, P00872_n907DepartamentoEstado, P00872_A112DepartamentoId, P00872_A113DepartamentoDepartamento, P00872_A116PaisID
               }
               , new Object[] {
               P00873_A112DepartamentoId, P00873_A114DepartamentoMunicipioId, P00873_A908DepartamentoMunicipioEstado, P00873_n908DepartamentoMunicipioEstado, P00873_A115DepartamentoMunicipioNombre
               }
               , new Object[] {
               P00874_A112DepartamentoId, P00874_A114DepartamentoMunicipioId, P00874_A906ZonasEstado, P00874_n906ZonasEstado, P00874_A110ZonasID, P00874_A111ZonasNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXSoapError ;
      private short currSoapErr ;
      private short readOk ;
      private short nOutParmCount ;
      private short AV20GXLvl22 ;
      private int AV10ResCode ;
      private long A112DepartamentoId ;
      private long AV16DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private string AV8UserConect ;
      private string AV11Key ;
      private string AV13PaisISO ;
      private string AV9ResMessage ;
      private string AV12ok ;
      private string A907DepartamentoEstado ;
      private string A113DepartamentoDepartamento ;
      private string A116PaisID ;
      private string A908DepartamentoMunicipioEstado ;
      private string A115DepartamentoMunicipioNombre ;
      private string A906ZonasEstado ;
      private string A111ZonasNombre ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private bool BRK872 ;
      private bool n907DepartamentoEstado ;
      private bool n908DepartamentoMunicipioEstado ;
      private bool n906ZonasEstado ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private SdtSDTZonas AV14SDTZonas ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00872_A907DepartamentoEstado ;
      private bool[] P00872_n907DepartamentoEstado ;
      private long[] P00872_A112DepartamentoId ;
      private string[] P00872_A113DepartamentoDepartamento ;
      private string[] P00872_A116PaisID ;
      private SdtSDTZonas_DepartamentosItem AV15SdtZonasItem ;
      private long[] P00873_A112DepartamentoId ;
      private long[] P00873_A114DepartamentoMunicipioId ;
      private string[] P00873_A908DepartamentoMunicipioEstado ;
      private bool[] P00873_n908DepartamentoMunicipioEstado ;
      private string[] P00873_A115DepartamentoMunicipioNombre ;
      private SdtSDTZonas_DepartamentosItem_MunicipiosItem AV17MuniItem ;
      private long[] P00874_A112DepartamentoId ;
      private long[] P00874_A114DepartamentoMunicipioId ;
      private string[] P00874_A906ZonasEstado ;
      private bool[] P00874_n906ZonasEstado ;
      private long[] P00874_A110ZonasID ;
      private string[] P00874_A111ZonasNombre ;
      private SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem AV19ZonasItem ;
      private int aP3_ResCode ;
      private string aP4_ResMessage ;
      private SdtSDTZonas aP5_SDTZonas ;
   }

   public class awsozonas__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00872;
          prmP00872 = new Object[] {
          new ParDef("@AV13PaisISO",GXType.NChar,2,0)
          };
          Object[] prmP00873;
          prmP00873 = new Object[] {
          new ParDef("@DepartamentoId",GXType.Decimal,18,0)
          };
          Object[] prmP00874;
          prmP00874 = new Object[] {
          new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00872", "SELECT [DepartamentoEstado], [DepartamentoId], [DepartamentoDepartamento], [PaisID] FROM [Departamento] WHERE [PaisID] = @AV13PaisISO ORDER BY [DepartamentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00872,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00873", "SELECT [DepartamentoId], [DepartamentoMunicipioId], [DepartamentoMunicipioEstado], [DepartamentoMunicipioNombre] FROM [DepartamentoMunicipio] WHERE ([DepartamentoId] = @DepartamentoId) AND ([DepartamentoMunicipioId] <> 9999) ORDER BY [DepartamentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00873,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00874", "SELECT [DepartamentoId], [DepartamentoMunicipioId], [ZonasEstado], [ZonasID], [ZonasNombre] FROM [Zonas] WHERE [DepartamentoId] = @DepartamentoId and [DepartamentoMunicipioId] = @DepartamentoMunicipioId ORDER BY [DepartamentoId], [DepartamentoMunicipioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00874,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((string[]) buf[4])[0] = rslt.getString(4, 2);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 120);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 120);
                return;
       }
    }

 }

}
