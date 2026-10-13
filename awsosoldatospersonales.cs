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
   public class awsosoldatospersonales : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDatosPersonales");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDatosPersonales.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDatosPersonales.ExecuteResponse");
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
               GXSoapXMLWriter.WriteAttribute("name", "Fechainstalacion");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:date");
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
               GXSoapXMLWriter.WriteAttribute("name", "Nombreprofesional");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Turno");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDatosPersonales.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSOSolDatosPersonales.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDatosPersonales.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSOSolDatosPersonales.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDatosPersonalesSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSOSolDatosPersonales.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSOSolDatosPersonales.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDatosPersonalesSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"WSOSolDatosPersonalesSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "AlmangoXaction/"+"AWSOSOLDATOSPERSONALES.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDatosPersonales");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolDatosPersonalesSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"WSOSolDatosPersonalesSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"awsosoldatospersonales.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "awsosoldatospersonales.aspx" + "?wsdl to get the WSDL.";
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
            GXSoapXMLWriter.WriteStartElement("WSOSolDatosPersonales.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
            if ( currSoapErr == 0 )
            {
               GXSoapXMLWriter.WriteElement("Rescode", StringUtil.Trim( StringUtil.Str( (decimal)(AV12ResCode), 6, 0)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Resmessage", AV13ResMessage);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               sDateCnv = "";
               sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( AV37FechaInstalacion)), 10, 0));
               sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
               sDateCnv += "-";
               sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( AV37FechaInstalacion)), 10, 0));
               sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
               sDateCnv += "-";
               sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( AV37FechaInstalacion)), 10, 0));
               sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
               GXSoapXMLWriter.WriteElement("Fechainstalacion", sDateCnv);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Estado", AV21Estado);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Nombrecliente", AV34NombreCliente);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Solicitudestotal", StringUtil.Trim( StringUtil.Str( AV33SolicitudesTotal, 18, 2)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Nombreprofesional", AV35NombreProfesional);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Turno", AV39Turno);
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

      public awsosoldatospersonales( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awsosoldatospersonales( IGxContext context )
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
                           out DateTime aP5_FechaInstalacion ,
                           out string aP6_Estado ,
                           out string aP7_NombreCliente ,
                           out decimal aP8_SolicitudesTotal ,
                           out string aP9_NombreProfesional ,
                           out string aP10_Turno )
      {
         this.AV14UserConect = aP0_UserConect;
         this.AV9Key = aP1_Key;
         this.AV18SolicitudesID = aP2_SolicitudesID;
         this.AV12ResCode = 0 ;
         this.AV13ResMessage = "" ;
         this.AV37FechaInstalacion = DateTime.MinValue ;
         this.AV21Estado = "" ;
         this.AV34NombreCliente = "" ;
         this.AV33SolicitudesTotal = 0 ;
         this.AV35NombreProfesional = "" ;
         this.AV39Turno = "" ;
         initialize();
         ExecutePrivate();
         aP3_ResCode=this.AV12ResCode;
         aP4_ResMessage=this.AV13ResMessage;
         aP5_FechaInstalacion=this.AV37FechaInstalacion;
         aP6_Estado=this.AV21Estado;
         aP7_NombreCliente=this.AV34NombreCliente;
         aP8_SolicitudesTotal=this.AV33SolicitudesTotal;
         aP9_NombreProfesional=this.AV35NombreProfesional;
         aP10_Turno=this.AV39Turno;
      }

      public string executeUdp( string aP0_UserConect ,
                                string aP1_Key ,
                                long aP2_SolicitudesID ,
                                out int aP3_ResCode ,
                                out string aP4_ResMessage ,
                                out DateTime aP5_FechaInstalacion ,
                                out string aP6_Estado ,
                                out string aP7_NombreCliente ,
                                out decimal aP8_SolicitudesTotal ,
                                out string aP9_NombreProfesional )
      {
         execute(aP0_UserConect, aP1_Key, aP2_SolicitudesID, out aP3_ResCode, out aP4_ResMessage, out aP5_FechaInstalacion, out aP6_Estado, out aP7_NombreCliente, out aP8_SolicitudesTotal, out aP9_NombreProfesional, out aP10_Turno);
         return AV39Turno ;
      }

      public void executeSubmit( string aP0_UserConect ,
                                 string aP1_Key ,
                                 long aP2_SolicitudesID ,
                                 out int aP3_ResCode ,
                                 out string aP4_ResMessage ,
                                 out DateTime aP5_FechaInstalacion ,
                                 out string aP6_Estado ,
                                 out string aP7_NombreCliente ,
                                 out decimal aP8_SolicitudesTotal ,
                                 out string aP9_NombreProfesional ,
                                 out string aP10_Turno )
      {
         this.AV14UserConect = aP0_UserConect;
         this.AV9Key = aP1_Key;
         this.AV18SolicitudesID = aP2_SolicitudesID;
         this.AV12ResCode = 0 ;
         this.AV13ResMessage = "" ;
         this.AV37FechaInstalacion = DateTime.MinValue ;
         this.AV21Estado = "" ;
         this.AV34NombreCliente = "" ;
         this.AV33SolicitudesTotal = 0 ;
         this.AV35NombreProfesional = "" ;
         this.AV39Turno = "" ;
         SubmitImpl();
         aP3_ResCode=this.AV12ResCode;
         aP4_ResMessage=this.AV13ResMessage;
         aP5_FechaInstalacion=this.AV37FechaInstalacion;
         aP6_Estado=this.AV21Estado;
         aP7_NombreCliente=this.AV34NombreCliente;
         aP8_SolicitudesTotal=this.AV33SolicitudesTotal;
         aP9_NombreProfesional=this.AV35NombreProfesional;
         aP10_Turno=this.AV39Turno;
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
            AV40GXLvl20 = 0;
            /* Using cursor P00IJ2 */
            pr_default.execute(0, new Object[] {AV18SolicitudesID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A130EstadosSolTipo = P00IJ2_A130EstadosSolTipo[0];
               A127SolicitudesID = P00IJ2_A127SolicitudesID[0];
               A132EstadosSolNombre = P00IJ2_A132EstadosSolNombre[0];
               A171SolicitudesNombre = P00IJ2_A171SolicitudesNombre[0];
               A131EstadosSolId = P00IJ2_A131EstadosSolId[0];
               A182SolicitudesFechaAlta = P00IJ2_A182SolicitudesFechaAlta[0];
               n182SolicitudesFechaAlta = P00IJ2_n182SolicitudesFechaAlta[0];
               A184SolicitudesFechaInstalacion = P00IJ2_A184SolicitudesFechaInstalacion[0];
               A183SolicitudesHoraInstalacion = P00IJ2_A183SolicitudesHoraInstalacion[0];
               A796SolicitudesComisionMetodoPago = P00IJ2_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = P00IJ2_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = P00IJ2_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = P00IJ2_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = P00IJ2_n897SolicitudesDescuento[0];
               A864SolicitudesCostoXZona = P00IJ2_A864SolicitudesCostoXZona[0];
               A132EstadosSolNombre = P00IJ2_A132EstadosSolNombre[0];
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
               AV40GXLvl20 = 1;
               AV21Estado = A132EstadosSolNombre;
               AV34NombreCliente = A171SolicitudesNombre;
               AV33SolicitudesTotal = A211SolicitudServicioPFinal;
               AV31EstadoId = A131EstadosSolId;
               AV30SolicitudesFechaAlta = A182SolicitudesFechaAlta;
               AV37FechaInstalacion = A184SolicitudesFechaInstalacion;
               AV38TurnoValueEnum = A183SolicitudesHoraInstalacion;
               new orelnom(context ).execute(  A127SolicitudesID, out  AV22ProfesionalesId, out  AV35NombreProfesional, out  AV28ExisteProf) ;
               AV13ResMessage = context.GetMessage( "Success.", "");
               AV12ResCode = 0;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( AV40GXLvl20 == 0 )
            {
               AV13ResMessage = context.GetMessage( "Solicitud de servicio incorrecta.", "");
               AV12ResCode = 104;
            }
            if ( AV12ResCode == 0 )
            {
               if ( StringUtil.StrCmp(AV38TurnoValueEnum, "1") == 0 )
               {
                  AV39Turno = context.GetMessage( "Turno 1, 8:00-12:00", "");
               }
               else if ( StringUtil.StrCmp(AV38TurnoValueEnum, "2") == 0 )
               {
                  AV39Turno = context.GetMessage( "Turno 2, 12:00-16:00", "");
               }
               else if ( StringUtil.StrCmp(AV38TurnoValueEnum, "3") == 0 )
               {
                  AV39Turno = context.GetMessage( "Turno 3, 16:00-20:00", "");
               }
               else
               {
                  AV39Turno = context.GetMessage( "No especificado", "");
               }
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
         /* Using cursor P00IJ3 */
         pr_default.execute(1, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(1) != 101) && ( P00IJ3_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00IJ3_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00IJ3_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00IJ3_A176SolicitudesItemsPrecioFinal[0]*P00IJ3_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00IJ3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00IJ3_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00IJ3_A176SolicitudesItemsPrecioFinal[0]*P00IJ3_A177SolicitudesItemsCantidad[0])-(P00IJ3_A180SolicitudItemsComision[0]*P00IJ3_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00IJ3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00IJ3_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00IJ3_A176SolicitudesItemsPrecioFinal[0]*P00IJ3_A177SolicitudesItemsCantidad[0])+(P00IJ3_A180SolicitudItemsComision[0]*P00IJ3_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00IJ3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00IJ3_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00IJ3_A176SolicitudesItemsPrecioFinal[0]*P00IJ3_A177SolicitudesItemsCantidad[0])-((P00IJ3_A176SolicitudesItemsPrecioFinal[0]*P00IJ3_A177SolicitudesItemsCantidad[0])*(P00IJ3_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00IJ3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00IJ3_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00IJ3_A176SolicitudesItemsPrecioFinal[0]*P00IJ3_A177SolicitudesItemsCantidad[0])+((P00IJ3_A176SolicitudesItemsPrecioFinal[0]*P00IJ3_A177SolicitudesItemsCantidad[0])*(P00IJ3_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
         P00IJ2_A130EstadosSolTipo = new string[] {""} ;
         P00IJ2_A127SolicitudesID = new long[1] ;
         P00IJ2_A132EstadosSolNombre = new string[] {""} ;
         P00IJ2_A171SolicitudesNombre = new string[] {""} ;
         P00IJ2_A131EstadosSolId = new int[1] ;
         P00IJ2_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00IJ2_n182SolicitudesFechaAlta = new bool[] {false} ;
         P00IJ2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00IJ2_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00IJ2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00IJ2_A212SolicitudesCotizacion = new decimal[1] ;
         P00IJ2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00IJ2_A897SolicitudesDescuento = new decimal[1] ;
         P00IJ2_n897SolicitudesDescuento = new bool[] {false} ;
         P00IJ2_A864SolicitudesCostoXZona = new decimal[1] ;
         A130EstadosSolTipo = "";
         A132EstadosSolNombre = "";
         A171SolicitudesNombre = "";
         A182SolicitudesFechaAlta = DateTime.MinValue;
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A183SolicitudesHoraInstalacion = "";
         AV30SolicitudesFechaAlta = DateTime.MinValue;
         AV38TurnoValueEnum = "";
         AV22ProfesionalesId = "";
         AV28ExisteProf = "";
         P00IJ3_A127SolicitudesID = new long[1] ;
         P00IJ3_A134SolicitudesItemsID = new short[1] ;
         P00IJ3_A180SolicitudItemsComision = new decimal[1] ;
         P00IJ3_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00IJ3_A178SolicitudItemsSR = new string[] {""} ;
         P00IJ3_A177SolicitudesItemsCantidad = new short[1] ;
         P00IJ3_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00IJ3_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.awsosoldatospersonales__default(),
            new Object[][] {
                new Object[] {
               P00IJ2_A130EstadosSolTipo, P00IJ2_A127SolicitudesID, P00IJ2_A132EstadosSolNombre, P00IJ2_A171SolicitudesNombre, P00IJ2_A131EstadosSolId, P00IJ2_A182SolicitudesFechaAlta, P00IJ2_n182SolicitudesFechaAlta, P00IJ2_A184SolicitudesFechaInstalacion, P00IJ2_A183SolicitudesHoraInstalacion, P00IJ2_A796SolicitudesComisionMetodoPago,
               P00IJ2_A212SolicitudesCotizacion, P00IJ2_A1016SolicitudesDescuentoCupon, P00IJ2_A897SolicitudesDescuento, P00IJ2_n897SolicitudesDescuento, P00IJ2_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P00IJ3_A127SolicitudesID, P00IJ3_A134SolicitudesItemsID, P00IJ3_A180SolicitudItemsComision, P00IJ3_A179SolicitudItemsComisionTipo, P00IJ3_A178SolicitudItemsSR, P00IJ3_A177SolicitudesItemsCantidad, P00IJ3_A176SolicitudesItemsPrecioFinal, P00IJ3_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXSoapError ;
      private short currSoapErr ;
      private short readOk ;
      private short nOutParmCount ;
      private short AV40GXLvl20 ;
      private int AV12ResCode ;
      private int A131EstadosSolId ;
      private int AV31EstadoId ;
      private long AV18SolicitudesID ;
      private long A127SolicitudesID ;
      private decimal AV33SolicitudesTotal ;
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
      private string AV34NombreCliente ;
      private string AV35NombreProfesional ;
      private string AV39Turno ;
      private string AV10ok ;
      private string A130EstadosSolTipo ;
      private string A132EstadosSolNombre ;
      private string A171SolicitudesNombre ;
      private string A183SolicitudesHoraInstalacion ;
      private string AV38TurnoValueEnum ;
      private string AV22ProfesionalesId ;
      private string AV28ExisteProf ;
      private DateTime AV37FechaInstalacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime AV30SolicitudesFechaAlta ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private bool n182SolicitudesFechaAlta ;
      private bool n897SolicitudesDescuento ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00IJ2_A130EstadosSolTipo ;
      private long[] P00IJ2_A127SolicitudesID ;
      private string[] P00IJ2_A132EstadosSolNombre ;
      private string[] P00IJ2_A171SolicitudesNombre ;
      private int[] P00IJ2_A131EstadosSolId ;
      private DateTime[] P00IJ2_A182SolicitudesFechaAlta ;
      private bool[] P00IJ2_n182SolicitudesFechaAlta ;
      private DateTime[] P00IJ2_A184SolicitudesFechaInstalacion ;
      private string[] P00IJ2_A183SolicitudesHoraInstalacion ;
      private decimal[] P00IJ2_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00IJ2_A212SolicitudesCotizacion ;
      private decimal[] P00IJ2_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00IJ2_A897SolicitudesDescuento ;
      private bool[] P00IJ2_n897SolicitudesDescuento ;
      private decimal[] P00IJ2_A864SolicitudesCostoXZona ;
      private long[] P00IJ3_A127SolicitudesID ;
      private short[] P00IJ3_A134SolicitudesItemsID ;
      private decimal[] P00IJ3_A180SolicitudItemsComision ;
      private string[] P00IJ3_A179SolicitudItemsComisionTipo ;
      private string[] P00IJ3_A178SolicitudItemsSR ;
      private short[] P00IJ3_A177SolicitudesItemsCantidad ;
      private decimal[] P00IJ3_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00IJ3_n176SolicitudesItemsPrecioFinal ;
      private int aP3_ResCode ;
      private string aP4_ResMessage ;
      private DateTime aP5_FechaInstalacion ;
      private string aP6_Estado ;
      private string aP7_NombreCliente ;
      private decimal aP8_SolicitudesTotal ;
      private string aP9_NombreProfesional ;
      private string aP10_Turno ;
   }

   public class awsosoldatospersonales__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00IJ2;
          prmP00IJ2 = new Object[] {
          new ParDef("@AV18SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00IJ3;
          prmP00IJ3 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00IJ2", "SELECT T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudesID], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudesNombre], T1.[EstadosSolId] AS EstadosSolId, T1.[SolicitudesFechaAlta], T1.[SolicitudesFechaInstalacion], T1.[SolicitudesHoraInstalacion], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM ([Solicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId]) WHERE T1.[SolicitudesID] = @AV18SolicitudesID ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IJ2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00IJ3", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IJ3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[8])[0] = rslt.getString(8, 1);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(13);
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
