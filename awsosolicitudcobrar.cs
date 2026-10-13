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
   public class awsosolicitudcobrar : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudCobrar");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudCobrar.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "Tipoope");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Identificador");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudCobrar.ExecuteResponse");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Rescode");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Resmessage");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Ordenpago");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudCobrar.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSOSolicitudCobrar.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudCobrar.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSOSolicitudCobrar.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudCobrarSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSOSolicitudCobrar.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSOSolicitudCobrar.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudCobrarSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"WSOSolicitudCobrarSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "AlmangoXaction/"+"AWSOSOLICITUDCOBRAR.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudCobrar");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudCobrarSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"WSOSolicitudCobrarSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"awsosolicitudcobrar.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "awsosolicitudcobrar.aspx" + "?wsdl to get the WSDL.";
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
                                 AV15UserConect = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Key") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV16Key = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Tipoope") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV22TipoOpe = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Identificador") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV23Identificador = GXSoapXMLReader.Value;
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
            GXSoapXMLWriter.WriteStartElement("WSOSolicitudCobrar.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
            if ( currSoapErr == 0 )
            {
               GXSoapXMLWriter.WriteElement("Rescode", StringUtil.Trim( StringUtil.Str( (decimal)(AV11ResCode), 10, 0)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Resmessage", AV12ResMessage);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Ordenpago", AV17OrdenPago);
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

      public awsosolicitudcobrar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awsosolicitudcobrar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserConect ,
                           string aP1_Key ,
                           string aP2_TipoOpe ,
                           string aP3_Identificador ,
                           out long aP4_ResCode ,
                           out string aP5_ResMessage ,
                           out string aP6_OrdenPago )
      {
         this.AV15UserConect = aP0_UserConect;
         this.AV16Key = aP1_Key;
         this.AV22TipoOpe = aP2_TipoOpe;
         this.AV23Identificador = aP3_Identificador;
         this.AV11ResCode = 0 ;
         this.AV12ResMessage = "" ;
         this.AV17OrdenPago = "" ;
         initialize();
         ExecutePrivate();
         aP4_ResCode=this.AV11ResCode;
         aP5_ResMessage=this.AV12ResMessage;
         aP6_OrdenPago=this.AV17OrdenPago;
      }

      public string executeUdp( string aP0_UserConect ,
                                string aP1_Key ,
                                string aP2_TipoOpe ,
                                string aP3_Identificador ,
                                out long aP4_ResCode ,
                                out string aP5_ResMessage )
      {
         execute(aP0_UserConect, aP1_Key, aP2_TipoOpe, aP3_Identificador, out aP4_ResCode, out aP5_ResMessage, out aP6_OrdenPago);
         return AV17OrdenPago ;
      }

      public void executeSubmit( string aP0_UserConect ,
                                 string aP1_Key ,
                                 string aP2_TipoOpe ,
                                 string aP3_Identificador ,
                                 out long aP4_ResCode ,
                                 out string aP5_ResMessage ,
                                 out string aP6_OrdenPago )
      {
         this.AV15UserConect = aP0_UserConect;
         this.AV16Key = aP1_Key;
         this.AV22TipoOpe = aP2_TipoOpe;
         this.AV23Identificador = aP3_Identificador;
         this.AV11ResCode = 0 ;
         this.AV12ResMessage = "" ;
         this.AV17OrdenPago = "" ;
         SubmitImpl();
         aP4_ResCode=this.AV11ResCode;
         aP5_ResMessage=this.AV12ResMessage;
         aP6_OrdenPago=this.AV17OrdenPago;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13OK = context.GetMessage( "N", "");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15UserConect)) )
         {
            AV12ResMessage = context.GetMessage( "Usuario incorrecto", "");
            AV11ResCode = 101;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16Key)) )
         {
            AV12ResMessage = context.GetMessage( "llave de acceso incorrecta", "");
            AV11ResCode = 102;
         }
         else if ( StringUtil.StrCmp(AV16Key, context.GetMessage( "d3d3LmF6bWl0YS5jb20=", "")) != 0 )
         {
            AV12ResMessage = context.GetMessage( "llave de acceso incorrecta.", "");
            AV11ResCode = 103;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23Identificador)) )
         {
            AV11ResCode = 104;
            AV12ResMessage = context.GetMessage( "Identificador no valida.", "");
         }
         else if ( ( StringUtil.StrCmp(StringUtil.Upper( AV22TipoOpe), context.GetMessage( "S", "")) != 0 ) && ( StringUtil.StrCmp(StringUtil.Upper( AV22TipoOpe), context.GetMessage( "O", "")) != 0 ) && ( StringUtil.StrCmp(StringUtil.Upper( AV22TipoOpe), context.GetMessage( "M", "")) != 0 ) )
         {
            AV11ResCode = 105;
            AV12ResMessage = context.GetMessage( "Tipo de operación no valida.", "");
         }
         else
         {
            AV13OK = context.GetMessage( "S", "");
         }
         if ( StringUtil.StrCmp(AV13OK, context.GetMessage( "S", "")) == 0 )
         {
            if ( StringUtil.StrCmp(AV22TipoOpe, context.GetMessage( "S", "")) == 0 )
            {
               AV23Identificador = StringUtil.StringReplace( AV23Identificador, context.GetMessage( "S", ""), "");
               AV8SolicitudesID = (long)(Math.Round(NumberUtil.Val( AV23Identificador, "."), 18, MidpointRounding.ToEven));
               AV27GXLvl37 = 0;
               /* Using cursor P00C32 */
               pr_default.execute(0, new Object[] {AV8SolicitudesID});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A112DepartamentoId = P00C32_A112DepartamentoId[0];
                  n112DepartamentoId = P00C32_n112DepartamentoId[0];
                  A669STMonedasId = P00C32_A669STMonedasId[0];
                  n669STMonedasId = P00C32_n669STMonedasId[0];
                  A127SolicitudesID = P00C32_A127SolicitudesID[0];
                  A171SolicitudesNombre = P00C32_A171SolicitudesNombre[0];
                  A113DepartamentoDepartamento = P00C32_A113DepartamentoDepartamento[0];
                  A173SolicitudesDireccion = P00C32_A173SolicitudesDireccion[0];
                  A172SolicitudesTelefono = P00C32_A172SolicitudesTelefono[0];
                  A116PaisID = P00C32_A116PaisID[0];
                  A671STMonedasISO = P00C32_A671STMonedasISO[0];
                  A796SolicitudesComisionMetodoPago = P00C32_A796SolicitudesComisionMetodoPago[0];
                  A212SolicitudesCotizacion = P00C32_A212SolicitudesCotizacion[0];
                  A1016SolicitudesDescuentoCupon = P00C32_A1016SolicitudesDescuentoCupon[0];
                  A897SolicitudesDescuento = P00C32_A897SolicitudesDescuento[0];
                  n897SolicitudesDescuento = P00C32_n897SolicitudesDescuento[0];
                  A864SolicitudesCostoXZona = P00C32_A864SolicitudesCostoXZona[0];
                  A113DepartamentoDepartamento = P00C32_A113DepartamentoDepartamento[0];
                  A116PaisID = P00C32_A116PaisID[0];
                  A671STMonedasISO = P00C32_A671STMonedasISO[0];
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
                  AV27GXLvl37 = 1;
                  AV14SDTSolicitudCobrar.gxTpr_Solicitudid = A127SolicitudesID;
                  AV14SDTSolicitudCobrar.gxTpr_Codreferencia = StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0));
                  AV14SDTSolicitudCobrar.gxTpr_Totalcobrar = A211SolicitudServicioPFinal;
                  AV14SDTSolicitudCobrar.gxTpr_Anombre = StringUtil.Trim( A171SolicitudesNombre);
                  AV14SDTSolicitudCobrar.gxTpr_Departamento = A113DepartamentoDepartamento;
                  AV14SDTSolicitudCobrar.gxTpr_Ciudad = A113DepartamentoDepartamento;
                  AV14SDTSolicitudCobrar.gxTpr_Direccion = A173SolicitudesDireccion;
                  AV14SDTSolicitudCobrar.gxTpr_Telefono = StringUtil.Trim( A172SolicitudesTelefono);
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( A116PaisID)) )
                  {
                     AV14SDTSolicitudCobrar.gxTpr_Pais = context.GetMessage( "UY", "");
                  }
                  else
                  {
                     AV14SDTSolicitudCobrar.gxTpr_Pais = A116PaisID;
                  }
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( A671STMonedasISO)) )
                  {
                     AV14SDTSolicitudCobrar.gxTpr_Moneda = context.GetMessage( "UYU", "");
                  }
                  else
                  {
                     AV14SDTSolicitudCobrar.gxTpr_Moneda = StringUtil.Trim( A671STMonedasISO);
                  }
                  /* Execute user subroutine: 'OBTENER DESCRIPCION' */
                  S121 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
                  /* Execute user subroutine: 'GENERAR NUMERO DE ORDEN' */
                  S131 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
                  AV14SDTSolicitudCobrar.gxTpr_Fuepago = AV20OperacionesEstado;
                  if ( StringUtil.StrCmp(AV20OperacionesEstado, "PND") == 0 )
                  {
                     AV11ResCode = 0;
                     AV12ResMessage = context.GetMessage( "Success.", "");
                  }
                  else
                  {
                     AV11ResCode = 107;
                     AV12ResMessage = context.GetMessage( "Solicitud ya fue procesada.", "");
                  }
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(0);
               if ( AV27GXLvl37 == 0 )
               {
                  AV11ResCode = 106;
                  AV12ResMessage = context.GetMessage( "Solicitud no encontrada.", "");
               }
            }
            else if ( StringUtil.StrCmp(AV22TipoOpe, context.GetMessage( "M", "")) == 0 )
            {
               AV23Identificador = StringUtil.StringReplace( AV23Identificador, context.GetMessage( "M", ""), "");
               AV8SolicitudesID = (long)(Math.Round(NumberUtil.Val( AV23Identificador, "."), 18, MidpointRounding.ToEven));
               /* Using cursor P00C33 */
               pr_default.execute(1, new Object[] {AV8SolicitudesID});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A735MudanzaId = P00C33_A735MudanzaId[0];
                  n735MudanzaId = P00C33_n735MudanzaId[0];
                  A127SolicitudesID = P00C33_A127SolicitudesID[0];
                  A764MudanzaPrecioFinal = P00C33_A764MudanzaPrecioFinal[0];
                  A784MudanzaApellidoNombre = P00C33_A784MudanzaApellidoNombre[0];
                  A764MudanzaPrecioFinal = P00C33_A764MudanzaPrecioFinal[0];
                  A784MudanzaApellidoNombre = P00C33_A784MudanzaApellidoNombre[0];
                  /* Using cursor P00C34 */
                  pr_default.execute(2, new Object[] {n735MudanzaId, A735MudanzaId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     AV24MudanzaId = A735MudanzaId;
                     AV14SDTSolicitudCobrar.gxTpr_Solicitudid = A127SolicitudesID;
                     AV14SDTSolicitudCobrar.gxTpr_Codreferencia = StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0));
                     AV14SDTSolicitudCobrar.gxTpr_Totalcobrar = A764MudanzaPrecioFinal;
                     AV14SDTSolicitudCobrar.gxTpr_Anombre = StringUtil.Trim( A784MudanzaApellidoNombre);
                     AV14SDTSolicitudCobrar.gxTpr_Pais = context.GetMessage( "UY", "");
                     AV14SDTSolicitudCobrar.gxTpr_Moneda = context.GetMessage( "UYU", "");
                     /* Execute user subroutine: 'GENERAR NUMERO DE ORDEN' */
                     S131 ();
                     if ( returnInSub )
                     {
                        pr_default.close(2);
                        cleanup();
                        if (true) return;
                     }
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
            }
            else if ( StringUtil.StrCmp(AV22TipoOpe, context.GetMessage( "O", "")) == 0 )
            {
               AV18OperacionesId = (long)(Math.Round(NumberUtil.Val( AV23Identificador, "."), 18, MidpointRounding.ToEven));
               /* Execute user subroutine: 'OBTENER OPERACION' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV17OrdenPago = AV14SDTSolicitudCobrar.ToJSonString(false, true);
         AV26Plog = new SdtPlog(context);
         AV26Plog.gxTpr_Plogmsg = AV14SDTSolicitudCobrar.ToJSonString(false, true);
         AV26Plog.gxTpr_Plogpgm = "122";
         AV26Plog.Insert();
         context.CommitDataStores("wsosolicitudcobrar",pr_default);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'OBTENER OPERACION' Routine */
         returnInSub = false;
         AV30GXLvl128 = 0;
         /* Using cursor P00C35 */
         pr_default.execute(3, new Object[] {AV18OperacionesId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A554OperacionesId = P00C35_A554OperacionesId[0];
            A555OperacionesRef = P00C35_A555OperacionesRef[0];
            n555OperacionesRef = P00C35_n555OperacionesRef[0];
            A572OperacionesFacturaCod = P00C35_A572OperacionesFacturaCod[0];
            n572OperacionesFacturaCod = P00C35_n572OperacionesFacturaCod[0];
            A582OperacionesFechaPago = P00C35_A582OperacionesFechaPago[0];
            n582OperacionesFechaPago = P00C35_n582OperacionesFechaPago[0];
            A577OperacionesEstado = P00C35_A577OperacionesEstado[0];
            n577OperacionesEstado = P00C35_n577OperacionesEstado[0];
            A657OperacionesNombreRef = P00C35_A657OperacionesNombreRef[0];
            n657OperacionesNombreRef = P00C35_n657OperacionesNombreRef[0];
            A570OperacionesImporte = P00C35_A570OperacionesImporte[0];
            n570OperacionesImporte = P00C35_n570OperacionesImporte[0];
            A571OperacionesMoneda = P00C35_A571OperacionesMoneda[0];
            n571OperacionesMoneda = P00C35_n571OperacionesMoneda[0];
            AV30GXLvl128 = 1;
            AV14SDTSolicitudCobrar.gxTpr_Ordennro = A554OperacionesId;
            AV14SDTSolicitudCobrar.gxTpr_Codreferencia = StringUtil.Trim( A555OperacionesRef);
            AV14SDTSolicitudCobrar.gxTpr_Facturanro = StringUtil.Trim( A572OperacionesFacturaCod);
            AV14SDTSolicitudCobrar.gxTpr_Fechacobro = A582OperacionesFechaPago;
            AV14SDTSolicitudCobrar.gxTpr_Fuepago = A577OperacionesEstado;
            AV14SDTSolicitudCobrar.gxTpr_Anombre = A657OperacionesNombreRef;
            AV14SDTSolicitudCobrar.gxTpr_Totalcobrar = A570OperacionesImporte;
            AV14SDTSolicitudCobrar.gxTpr_Moneda = A571OperacionesMoneda;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         if ( AV30GXLvl128 == 0 )
         {
            AV11ResCode = 107;
            AV12ResMessage = context.GetMessage( "Operación  no encontrada.", "");
         }
      }

      protected void S121( )
      {
         /* 'OBTENER DESCRIPCION' Routine */
         returnInSub = false;
         AV31GXLvl147 = 0;
         /* Using cursor P00C36 */
         pr_default.execute(4, new Object[] {AV8SolicitudesID});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A121RubrosId = P00C36_A121RubrosId[0];
            A137MedidasID = P00C36_A137MedidasID[0];
            A134SolicitudesItemsID = P00C36_A134SolicitudesItemsID[0];
            A127SolicitudesID = P00C36_A127SolicitudesID[0];
            A122RubrosNombre = P00C36_A122RubrosNombre[0];
            A138MedidasNombre = P00C36_A138MedidasNombre[0];
            A122RubrosNombre = P00C36_A122RubrosNombre[0];
            A138MedidasNombre = P00C36_A138MedidasNombre[0];
            AV31GXLvl147 = 1;
            AV14SDTSolicitudCobrar.gxTpr_Descripcion = AV14SDTSolicitudCobrar.gxTpr_Descripcion+StringUtil.Format( " %1 %2,", StringUtil.Trim( A138MedidasNombre), StringUtil.Trim( A122RubrosNombre), "", "", "", "", "", "", "");
            pr_default.readNext(4);
         }
         pr_default.close(4);
         if ( AV31GXLvl147 == 0 )
         {
            AV14SDTSolicitudCobrar.gxTpr_Descripcion = context.GetMessage( "Otros Servicios contratado en www.almango.com.uy", "");
         }
      }

      protected void S131( )
      {
         /* 'GENERAR NUMERO DE ORDEN' Routine */
         returnInSub = false;
         AV18OperacionesId = 0;
         /* Using cursor P00C37 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A649OperacionesTipo = P00C37_A649OperacionesTipo[0];
            n649OperacionesTipo = P00C37_n649OperacionesTipo[0];
            A555OperacionesRef = P00C37_A555OperacionesRef[0];
            n555OperacionesRef = P00C37_n555OperacionesRef[0];
            A554OperacionesId = P00C37_A554OperacionesId[0];
            A572OperacionesFacturaCod = P00C37_A572OperacionesFacturaCod[0];
            n572OperacionesFacturaCod = P00C37_n572OperacionesFacturaCod[0];
            A582OperacionesFechaPago = P00C37_A582OperacionesFechaPago[0];
            n582OperacionesFechaPago = P00C37_n582OperacionesFechaPago[0];
            A577OperacionesEstado = P00C37_A577OperacionesEstado[0];
            n577OperacionesEstado = P00C37_n577OperacionesEstado[0];
            if ( StringUtil.StrCmp(StringUtil.Trim( A555OperacionesRef), StringUtil.Trim( context.localUtil.Format( (decimal)(AV8SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"))) == 0 )
            {
               AV14SDTSolicitudCobrar.gxTpr_Ordennro = A554OperacionesId;
               AV14SDTSolicitudCobrar.gxTpr_Facturanro = StringUtil.Trim( A572OperacionesFacturaCod);
               AV14SDTSolicitudCobrar.gxTpr_Fechacobro = A582OperacionesFechaPago;
               AV20OperacionesEstado = A577OperacionesEstado;
               AV18OperacionesId = A554OperacionesId;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(5);
         }
         pr_default.close(5);
         if ( AV18OperacionesId == 0 )
         {
            /* Using cursor P00C38 */
            pr_default.execute(6);
            while ( (pr_default.getStatus(6) != 101) )
            {
               A554OperacionesId = P00C38_A554OperacionesId[0];
               AV18OperacionesId = A554OperacionesId;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(6);
            }
            pr_default.close(6);
            if ( AV18OperacionesId == 0 )
            {
               AV18OperacionesId = 1000;
            }
            AV18OperacionesId = (long)(AV18OperacionesId+1);
            /*
               INSERT RECORD ON TABLE Operaciones

            */
            A554OperacionesId = AV18OperacionesId;
            A555OperacionesRef = StringUtil.Trim( context.localUtil.Format( (decimal)(AV8SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"));
            n555OperacionesRef = false;
            A657OperacionesNombreRef = AV14SDTSolicitudCobrar.gxTpr_Anombre;
            n657OperacionesNombreRef = false;
            A569OperacionesTipoES = "E";
            n569OperacionesTipoES = false;
            A570OperacionesImporte = AV14SDTSolicitudCobrar.gxTpr_Totalcobrar;
            n570OperacionesImporte = false;
            A571OperacionesMoneda = AV14SDTSolicitudCobrar.gxTpr_Moneda;
            n571OperacionesMoneda = false;
            A578OperacionesImporteGrabado = AV14SDTSolicitudCobrar.gxTpr_Totalcobrar;
            n578OperacionesImporteGrabado = false;
            A581OperacionesFechaAlta = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
            n581OperacionesFechaAlta = false;
            A649OperacionesTipo = "CSO";
            n649OperacionesTipo = false;
            A577OperacionesEstado = "PND";
            n577OperacionesEstado = false;
            AV14SDTSolicitudCobrar.gxTpr_Ordennro = AV18OperacionesId;
            AV20OperacionesEstado = "PND";
            /* Using cursor P00C39 */
            pr_default.execute(7, new Object[] {A554OperacionesId, n555OperacionesRef, A555OperacionesRef, n569OperacionesTipoES, A569OperacionesTipoES, n570OperacionesImporte, A570OperacionesImporte, n571OperacionesMoneda, A571OperacionesMoneda, n578OperacionesImporteGrabado, A578OperacionesImporteGrabado, n581OperacionesFechaAlta, A581OperacionesFechaAlta, n577OperacionesEstado, A577OperacionesEstado, n649OperacionesTipo, A649OperacionesTipo, n657OperacionesNombreRef, A657OperacionesNombreRef});
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("Operaciones");
            if ( (pr_default.getStatus(7) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            /* Optimized UPDATE. */
            /* Using cursor P00C310 */
            pr_default.execute(8, new Object[] {AV18OperacionesId, AV24MudanzaId});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("Mudanza");
            /* End optimized UPDATE. */
         }
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00C311 */
         pr_default.execute(9, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(9) != 101) && ( P00C311_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00C311_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00C311_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00C311_A176SolicitudesItemsPrecioFinal[0]*P00C311_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00C311_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00C311_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00C311_A176SolicitudesItemsPrecioFinal[0]*P00C311_A177SolicitudesItemsCantidad[0])-(P00C311_A180SolicitudItemsComision[0]*P00C311_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00C311_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00C311_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00C311_A176SolicitudesItemsPrecioFinal[0]*P00C311_A177SolicitudesItemsCantidad[0])+(P00C311_A180SolicitudItemsComision[0]*P00C311_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00C311_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00C311_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00C311_A176SolicitudesItemsPrecioFinal[0]*P00C311_A177SolicitudesItemsCantidad[0])-((P00C311_A176SolicitudesItemsPrecioFinal[0]*P00C311_A177SolicitudesItemsCantidad[0])*(P00C311_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00C311_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00C311_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00C311_A176SolicitudesItemsPrecioFinal[0]*P00C311_A177SolicitudesItemsCantidad[0])+((P00C311_A176SolicitudesItemsPrecioFinal[0]*P00C311_A177SolicitudesItemsCantidad[0])*(P00C311_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(9);
         }
         pr_default.close(9);
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wsosolicitudcobrar",pr_default);
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
         AV13OK = "";
         P00C32_A112DepartamentoId = new long[1] ;
         P00C32_n112DepartamentoId = new bool[] {false} ;
         P00C32_A669STMonedasId = new short[1] ;
         P00C32_n669STMonedasId = new bool[] {false} ;
         P00C32_A127SolicitudesID = new long[1] ;
         P00C32_A171SolicitudesNombre = new string[] {""} ;
         P00C32_A113DepartamentoDepartamento = new string[] {""} ;
         P00C32_A173SolicitudesDireccion = new string[] {""} ;
         P00C32_A172SolicitudesTelefono = new string[] {""} ;
         P00C32_A116PaisID = new string[] {""} ;
         P00C32_A671STMonedasISO = new string[] {""} ;
         P00C32_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00C32_A212SolicitudesCotizacion = new decimal[1] ;
         P00C32_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00C32_A897SolicitudesDescuento = new decimal[1] ;
         P00C32_n897SolicitudesDescuento = new bool[] {false} ;
         P00C32_A864SolicitudesCostoXZona = new decimal[1] ;
         A171SolicitudesNombre = "";
         A113DepartamentoDepartamento = "";
         A173SolicitudesDireccion = "";
         A172SolicitudesTelefono = "";
         A116PaisID = "";
         A671STMonedasISO = "";
         AV14SDTSolicitudCobrar = new SdtSDTSolicitudCobrar(context);
         AV20OperacionesEstado = "";
         P00C33_A735MudanzaId = new long[1] ;
         P00C33_n735MudanzaId = new bool[] {false} ;
         P00C33_A127SolicitudesID = new long[1] ;
         P00C33_A764MudanzaPrecioFinal = new decimal[1] ;
         P00C33_A784MudanzaApellidoNombre = new string[] {""} ;
         A784MudanzaApellidoNombre = "";
         P00C34_A735MudanzaId = new long[1] ;
         P00C34_n735MudanzaId = new bool[] {false} ;
         AV26Plog = new SdtPlog(context);
         P00C35_A554OperacionesId = new long[1] ;
         P00C35_A555OperacionesRef = new string[] {""} ;
         P00C35_n555OperacionesRef = new bool[] {false} ;
         P00C35_A572OperacionesFacturaCod = new string[] {""} ;
         P00C35_n572OperacionesFacturaCod = new bool[] {false} ;
         P00C35_A582OperacionesFechaPago = new DateTime[] {DateTime.MinValue} ;
         P00C35_n582OperacionesFechaPago = new bool[] {false} ;
         P00C35_A577OperacionesEstado = new string[] {""} ;
         P00C35_n577OperacionesEstado = new bool[] {false} ;
         P00C35_A657OperacionesNombreRef = new string[] {""} ;
         P00C35_n657OperacionesNombreRef = new bool[] {false} ;
         P00C35_A570OperacionesImporte = new decimal[1] ;
         P00C35_n570OperacionesImporte = new bool[] {false} ;
         P00C35_A571OperacionesMoneda = new string[] {""} ;
         P00C35_n571OperacionesMoneda = new bool[] {false} ;
         A555OperacionesRef = "";
         A572OperacionesFacturaCod = "";
         A582OperacionesFechaPago = (DateTime)(DateTime.MinValue);
         A577OperacionesEstado = "";
         A657OperacionesNombreRef = "";
         A571OperacionesMoneda = "";
         P00C36_A121RubrosId = new short[1] ;
         P00C36_A137MedidasID = new long[1] ;
         P00C36_A134SolicitudesItemsID = new short[1] ;
         P00C36_A127SolicitudesID = new long[1] ;
         P00C36_A122RubrosNombre = new string[] {""} ;
         P00C36_A138MedidasNombre = new string[] {""} ;
         A122RubrosNombre = "";
         A138MedidasNombre = "";
         P00C37_A649OperacionesTipo = new string[] {""} ;
         P00C37_n649OperacionesTipo = new bool[] {false} ;
         P00C37_A555OperacionesRef = new string[] {""} ;
         P00C37_n555OperacionesRef = new bool[] {false} ;
         P00C37_A554OperacionesId = new long[1] ;
         P00C37_A572OperacionesFacturaCod = new string[] {""} ;
         P00C37_n572OperacionesFacturaCod = new bool[] {false} ;
         P00C37_A582OperacionesFechaPago = new DateTime[] {DateTime.MinValue} ;
         P00C37_n582OperacionesFechaPago = new bool[] {false} ;
         P00C37_A577OperacionesEstado = new string[] {""} ;
         P00C37_n577OperacionesEstado = new bool[] {false} ;
         A649OperacionesTipo = "";
         P00C38_A554OperacionesId = new long[1] ;
         A569OperacionesTipoES = "";
         A581OperacionesFechaAlta = DateTime.MinValue;
         Gx_emsg = "";
         P00C311_A127SolicitudesID = new long[1] ;
         P00C311_A134SolicitudesItemsID = new short[1] ;
         P00C311_A180SolicitudItemsComision = new decimal[1] ;
         P00C311_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00C311_A178SolicitudItemsSR = new string[] {""} ;
         P00C311_A177SolicitudesItemsCantidad = new short[1] ;
         P00C311_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00C311_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.awsosolicitudcobrar__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.awsosolicitudcobrar__default(),
            new Object[][] {
                new Object[] {
               P00C32_A112DepartamentoId, P00C32_n112DepartamentoId, P00C32_A669STMonedasId, P00C32_n669STMonedasId, P00C32_A127SolicitudesID, P00C32_A171SolicitudesNombre, P00C32_A113DepartamentoDepartamento, P00C32_A173SolicitudesDireccion, P00C32_A172SolicitudesTelefono, P00C32_A116PaisID,
               P00C32_A671STMonedasISO, P00C32_A796SolicitudesComisionMetodoPago, P00C32_A212SolicitudesCotizacion, P00C32_A1016SolicitudesDescuentoCupon, P00C32_A897SolicitudesDescuento, P00C32_n897SolicitudesDescuento, P00C32_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P00C33_A735MudanzaId, P00C33_n735MudanzaId, P00C33_A127SolicitudesID, P00C33_A764MudanzaPrecioFinal, P00C33_A784MudanzaApellidoNombre
               }
               , new Object[] {
               P00C34_A735MudanzaId
               }
               , new Object[] {
               P00C35_A554OperacionesId, P00C35_A555OperacionesRef, P00C35_n555OperacionesRef, P00C35_A572OperacionesFacturaCod, P00C35_n572OperacionesFacturaCod, P00C35_A582OperacionesFechaPago, P00C35_n582OperacionesFechaPago, P00C35_A577OperacionesEstado, P00C35_n577OperacionesEstado, P00C35_A657OperacionesNombreRef,
               P00C35_n657OperacionesNombreRef, P00C35_A570OperacionesImporte, P00C35_n570OperacionesImporte, P00C35_A571OperacionesMoneda, P00C35_n571OperacionesMoneda
               }
               , new Object[] {
               P00C36_A121RubrosId, P00C36_A137MedidasID, P00C36_A134SolicitudesItemsID, P00C36_A127SolicitudesID, P00C36_A122RubrosNombre, P00C36_A138MedidasNombre
               }
               , new Object[] {
               P00C37_A649OperacionesTipo, P00C37_n649OperacionesTipo, P00C37_A555OperacionesRef, P00C37_n555OperacionesRef, P00C37_A554OperacionesId, P00C37_A572OperacionesFacturaCod, P00C37_n572OperacionesFacturaCod, P00C37_A582OperacionesFechaPago, P00C37_n582OperacionesFechaPago, P00C37_A577OperacionesEstado,
               P00C37_n577OperacionesEstado
               }
               , new Object[] {
               P00C38_A554OperacionesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00C311_A127SolicitudesID, P00C311_A134SolicitudesItemsID, P00C311_A180SolicitudItemsComision, P00C311_A179SolicitudItemsComisionTipo, P00C311_A178SolicitudItemsSR, P00C311_A177SolicitudesItemsCantidad, P00C311_A176SolicitudesItemsPrecioFinal, P00C311_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXSoapError ;
      private short currSoapErr ;
      private short readOk ;
      private short nOutParmCount ;
      private short AV27GXLvl37 ;
      private short A669STMonedasId ;
      private short AV30GXLvl128 ;
      private short AV31GXLvl147 ;
      private short A121RubrosId ;
      private short A134SolicitudesItemsID ;
      private int GX_INS82 ;
      private long AV11ResCode ;
      private long AV8SolicitudesID ;
      private long A112DepartamentoId ;
      private long A127SolicitudesID ;
      private long A735MudanzaId ;
      private long AV24MudanzaId ;
      private long AV18OperacionesId ;
      private long A554OperacionesId ;
      private long A137MedidasID ;
      private long A790MudanzaOperacionId ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal A764MudanzaPrecioFinal ;
      private decimal A570OperacionesImporte ;
      private decimal A578OperacionesImporteGrabado ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private string AV15UserConect ;
      private string AV16Key ;
      private string AV22TipoOpe ;
      private string AV23Identificador ;
      private string AV12ResMessage ;
      private string AV13OK ;
      private string A171SolicitudesNombre ;
      private string A113DepartamentoDepartamento ;
      private string A172SolicitudesTelefono ;
      private string A116PaisID ;
      private string A671STMonedasISO ;
      private string AV20OperacionesEstado ;
      private string A555OperacionesRef ;
      private string A572OperacionesFacturaCod ;
      private string A577OperacionesEstado ;
      private string A657OperacionesNombreRef ;
      private string A571OperacionesMoneda ;
      private string A122RubrosNombre ;
      private string A138MedidasNombre ;
      private string A649OperacionesTipo ;
      private string A569OperacionesTipoES ;
      private string Gx_emsg ;
      private DateTime A582OperacionesFechaPago ;
      private DateTime A581OperacionesFechaAlta ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private bool n112DepartamentoId ;
      private bool n669STMonedasId ;
      private bool n897SolicitudesDescuento ;
      private bool returnInSub ;
      private bool n735MudanzaId ;
      private bool n555OperacionesRef ;
      private bool n572OperacionesFacturaCod ;
      private bool n582OperacionesFechaPago ;
      private bool n577OperacionesEstado ;
      private bool n657OperacionesNombreRef ;
      private bool n570OperacionesImporte ;
      private bool n571OperacionesMoneda ;
      private bool n649OperacionesTipo ;
      private bool n569OperacionesTipoES ;
      private bool n578OperacionesImporteGrabado ;
      private bool n581OperacionesFechaAlta ;
      private string AV17OrdenPago ;
      private string A173SolicitudesDireccion ;
      private string A784MudanzaApellidoNombre ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00C32_A112DepartamentoId ;
      private bool[] P00C32_n112DepartamentoId ;
      private short[] P00C32_A669STMonedasId ;
      private bool[] P00C32_n669STMonedasId ;
      private long[] P00C32_A127SolicitudesID ;
      private string[] P00C32_A171SolicitudesNombre ;
      private string[] P00C32_A113DepartamentoDepartamento ;
      private string[] P00C32_A173SolicitudesDireccion ;
      private string[] P00C32_A172SolicitudesTelefono ;
      private string[] P00C32_A116PaisID ;
      private string[] P00C32_A671STMonedasISO ;
      private decimal[] P00C32_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00C32_A212SolicitudesCotizacion ;
      private decimal[] P00C32_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00C32_A897SolicitudesDescuento ;
      private bool[] P00C32_n897SolicitudesDescuento ;
      private decimal[] P00C32_A864SolicitudesCostoXZona ;
      private SdtSDTSolicitudCobrar AV14SDTSolicitudCobrar ;
      private long[] P00C33_A735MudanzaId ;
      private bool[] P00C33_n735MudanzaId ;
      private long[] P00C33_A127SolicitudesID ;
      private decimal[] P00C33_A764MudanzaPrecioFinal ;
      private string[] P00C33_A784MudanzaApellidoNombre ;
      private long[] P00C34_A735MudanzaId ;
      private bool[] P00C34_n735MudanzaId ;
      private SdtPlog AV26Plog ;
      private long[] P00C35_A554OperacionesId ;
      private string[] P00C35_A555OperacionesRef ;
      private bool[] P00C35_n555OperacionesRef ;
      private string[] P00C35_A572OperacionesFacturaCod ;
      private bool[] P00C35_n572OperacionesFacturaCod ;
      private DateTime[] P00C35_A582OperacionesFechaPago ;
      private bool[] P00C35_n582OperacionesFechaPago ;
      private string[] P00C35_A577OperacionesEstado ;
      private bool[] P00C35_n577OperacionesEstado ;
      private string[] P00C35_A657OperacionesNombreRef ;
      private bool[] P00C35_n657OperacionesNombreRef ;
      private decimal[] P00C35_A570OperacionesImporte ;
      private bool[] P00C35_n570OperacionesImporte ;
      private string[] P00C35_A571OperacionesMoneda ;
      private bool[] P00C35_n571OperacionesMoneda ;
      private short[] P00C36_A121RubrosId ;
      private long[] P00C36_A137MedidasID ;
      private short[] P00C36_A134SolicitudesItemsID ;
      private long[] P00C36_A127SolicitudesID ;
      private string[] P00C36_A122RubrosNombre ;
      private string[] P00C36_A138MedidasNombre ;
      private string[] P00C37_A649OperacionesTipo ;
      private bool[] P00C37_n649OperacionesTipo ;
      private string[] P00C37_A555OperacionesRef ;
      private bool[] P00C37_n555OperacionesRef ;
      private long[] P00C37_A554OperacionesId ;
      private string[] P00C37_A572OperacionesFacturaCod ;
      private bool[] P00C37_n572OperacionesFacturaCod ;
      private DateTime[] P00C37_A582OperacionesFechaPago ;
      private bool[] P00C37_n582OperacionesFechaPago ;
      private string[] P00C37_A577OperacionesEstado ;
      private bool[] P00C37_n577OperacionesEstado ;
      private long[] P00C38_A554OperacionesId ;
      private long[] P00C311_A127SolicitudesID ;
      private short[] P00C311_A134SolicitudesItemsID ;
      private decimal[] P00C311_A180SolicitudItemsComision ;
      private string[] P00C311_A179SolicitudItemsComisionTipo ;
      private string[] P00C311_A178SolicitudItemsSR ;
      private short[] P00C311_A177SolicitudesItemsCantidad ;
      private decimal[] P00C311_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00C311_n176SolicitudesItemsPrecioFinal ;
      private long aP4_ResCode ;
      private string aP5_ResMessage ;
      private string aP6_OrdenPago ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class awsosolicitudcobrar__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class awsosolicitudcobrar__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00C32;
        prmP00C32 = new Object[] {
        new ParDef("@AV8SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP00C33;
        prmP00C33 = new Object[] {
        new ParDef("@AV8SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP00C34;
        prmP00C34 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmP00C35;
        prmP00C35 = new Object[] {
        new ParDef("@AV18OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmP00C36;
        prmP00C36 = new Object[] {
        new ParDef("@AV8SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP00C37;
        prmP00C37 = new Object[] {
        };
        Object[] prmP00C38;
        prmP00C38 = new Object[] {
        };
        Object[] prmP00C39;
        prmP00C39 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0) ,
        new ParDef("@OperacionesRef",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@OperacionesTipoES",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@OperacionesImporte",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesMoneda",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesImporteGrabado",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesFechaAlta",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesTipo",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesNombreRef",GXType.NChar,120,0){Nullable=true}
        };
        Object[] prmP00C310;
        prmP00C310 = new Object[] {
        new ParDef("@MudanzaOperacionId",GXType.Decimal,18,0) ,
        new ParDef("@AV24MudanzaId",GXType.Decimal,18,0)
        };
        Object[] prmP00C311;
        prmP00C311 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00C32", "SELECT TOP 1 T1.[DepartamentoId], T1.[STMonedasId] AS STMonedasId, T1.[SolicitudesID], T1.[SolicitudesNombre], T2.[DepartamentoDepartamento], T1.[SolicitudesDireccion], T1.[SolicitudesTelefono], T2.[PaisID], T3.[MonedaISOSimbolo] AS STMonedasISO, T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM (([Solicitudes] T1 LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) LEFT JOIN [Moneda] T3 ON T3.[MonedaId] = T1.[STMonedasId]) WHERE T1.[SolicitudesID] = @AV8SolicitudesID ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C32,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00C33", "SELECT T1.[MudanzaId], T1.[SolicitudesID], T2.[MudanzaPrecioFinal], T2.[MudanzaApellidoNombre] FROM ([Solicitudes] T1 LEFT JOIN [Mudanza] T2 ON T2.[MudanzaId] = T1.[MudanzaId]) WHERE T1.[SolicitudesID] = @AV8SolicitudesID ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C33,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00C34", "SELECT [MudanzaId] FROM [Mudanza] WHERE [MudanzaId] = @MudanzaId ORDER BY [MudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C34,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00C35", "SELECT [OperacionesId], [OperacionesRef], [OperacionesFacturaCod], [OperacionesFechaPago], [OperacionesEstado], [OperacionesNombreRef], [OperacionesImporte], [OperacionesMoneda] FROM [Operaciones] WHERE [OperacionesId] = @AV18OperacionesId ORDER BY [OperacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C35,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00C36", "SELECT T1.[RubrosId], T1.[MedidasID], T1.[SolicitudesItemsID], T1.[SolicitudesID], T2.[RubrosNombre], T3.[MedidasNombre] FROM (([SolicitudesItems] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) WHERE T1.[SolicitudesID] = @AV8SolicitudesID and T1.[SolicitudesItemsID] > 0 ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C36,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P00C37", "SELECT [OperacionesTipo], [OperacionesRef], [OperacionesId], [OperacionesFacturaCod], [OperacionesFechaPago], [OperacionesEstado] FROM [Operaciones] WHERE [OperacionesTipo] = 'CSO' ORDER BY [OperacionesRef] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C37,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P00C38", "SELECT TOP 1 [OperacionesId] FROM [Operaciones] ORDER BY [OperacionesId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C38,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00C39", "INSERT INTO [Operaciones]([OperacionesId], [OperacionesRef], [OperacionesTipoES], [OperacionesImporte], [OperacionesMoneda], [OperacionesImporteGrabado], [OperacionesFechaAlta], [OperacionesEstado], [OperacionesTipo], [OperacionesNombreRef], [OperacionesOrdinal], [OperacionesIDORD], [OperacionesFacturaCod], [OperacionesIva], [OperacionesComision], [OperacionesRequest], [OperacionesResponse], [OperacionesComprobantePago], [OperacionesFechaPago], [OperacionesAux1], [OperacionesAux2], [OperacionesAux3], [OperacionesFechaDesde], [OperacionesFechaHasta], [OperacionesMonId], [OperacionesBlob1], [OperacionesBlob2], [OperacionesUsrAlta], [OperacionesUsrActualizacion], [OperacionesComercioId1], [OperacionesComercioId2], [OperacionesPeriodoCod]) VALUES(@OperacionesId, @OperacionesRef, @OperacionesTipoES, @OperacionesImporte, @OperacionesMoneda, @OperacionesImporteGrabado, @OperacionesFechaAlta, @OperacionesEstado, @OperacionesTipo, @OperacionesNombreRef, convert(int, 0), '', '', convert(int, 0), convert(int, 0), '', '', '', convert( DATETIME, '17530101', 112 ), '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert(int, 0), CONVERT(varbinary(1), ''), CONVERT(varbinary(1), ''), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '')", GxErrorMask.GX_NOMASK,prmP00C39)
           ,new CursorDef("P00C310", "UPDATE [Mudanza] SET [MudanzaOperacionId]=@MudanzaOperacionId  WHERE [MudanzaId] = @AV24MudanzaId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C310)
           ,new CursorDef("P00C311", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C311,100, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((short[]) buf[2])[0] = rslt.getShort(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((long[]) buf[4])[0] = rslt.getLong(3);
              ((string[]) buf[5])[0] = rslt.getString(4, 100);
              ((string[]) buf[6])[0] = rslt.getString(5, 80);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((string[]) buf[8])[0] = rslt.getString(7, 20);
              ((string[]) buf[9])[0] = rslt.getString(8, 2);
              ((string[]) buf[10])[0] = rslt.getString(9, 3);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(13);
              ((bool[]) buf[15])[0] = rslt.wasNull(13);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(14);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((long[]) buf[2])[0] = rslt.getLong(2);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 25);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 25);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 3);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 120);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getString(8, 3);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 50);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 25);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((long[]) buf[4])[0] = rslt.getLong(3);
              ((string[]) buf[5])[0] = rslt.getString(4, 25);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 3);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
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
