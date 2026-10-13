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
   public class awsconfirmaroperacion : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               GXSoapXMLWriter.WriteAttribute("name", "WSConfirmarOperacion");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSConfirmarOperacion.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "Ordenpago");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Request");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Response");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WSConfirmarOperacion.ExecuteResponse");
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
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSConfirmarOperacion.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSConfirmarOperacion.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSConfirmarOperacion.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSConfirmarOperacion.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "WSConfirmarOperacionSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSConfirmarOperacion.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSConfirmarOperacion.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "WSConfirmarOperacionSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"WSConfirmarOperacionSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "AlmangoXaction/"+"AWSCONFIRMAROPERACION.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSConfirmarOperacion");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "WSConfirmarOperacionSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"WSConfirmarOperacionSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"awsconfirmaroperacion.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "awsconfirmaroperacion.aspx" + "?wsdl to get the WSDL.";
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
                                 AV23UserConect = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Key") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV8Key = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Ordenpago") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV22OrdenPago = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Request") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV19Request = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Response") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV20Response = GXSoapXMLReader.Value;
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
            GXSoapXMLWriter.WriteStartElement("WSConfirmarOperacion.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
            if ( currSoapErr == 0 )
            {
               GXSoapXMLWriter.WriteElement("Rescode", StringUtil.Trim( StringUtil.Str( (decimal)(AV10ResCode), 10, 0)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Resmessage", AV12ResMessage);
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

      public awsconfirmaroperacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awsconfirmaroperacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserConect ,
                           string aP1_Key ,
                           string aP2_OrdenPago ,
                           string aP3_Request ,
                           string aP4_Response ,
                           out long aP5_ResCode ,
                           out string aP6_ResMessage )
      {
         this.AV23UserConect = aP0_UserConect;
         this.AV8Key = aP1_Key;
         this.AV22OrdenPago = aP2_OrdenPago;
         this.AV19Request = aP3_Request;
         this.AV20Response = aP4_Response;
         this.AV10ResCode = 0 ;
         this.AV12ResMessage = "" ;
         initialize();
         ExecutePrivate();
         aP5_ResCode=this.AV10ResCode;
         aP6_ResMessage=this.AV12ResMessage;
      }

      public string executeUdp( string aP0_UserConect ,
                                string aP1_Key ,
                                string aP2_OrdenPago ,
                                string aP3_Request ,
                                string aP4_Response ,
                                out long aP5_ResCode )
      {
         execute(aP0_UserConect, aP1_Key, aP2_OrdenPago, aP3_Request, aP4_Response, out aP5_ResCode, out aP6_ResMessage);
         return AV12ResMessage ;
      }

      public void executeSubmit( string aP0_UserConect ,
                                 string aP1_Key ,
                                 string aP2_OrdenPago ,
                                 string aP3_Request ,
                                 string aP4_Response ,
                                 out long aP5_ResCode ,
                                 out string aP6_ResMessage )
      {
         this.AV23UserConect = aP0_UserConect;
         this.AV8Key = aP1_Key;
         this.AV22OrdenPago = aP2_OrdenPago;
         this.AV19Request = aP3_Request;
         this.AV20Response = aP4_Response;
         this.AV10ResCode = 0 ;
         this.AV12ResMessage = "" ;
         SubmitImpl();
         aP5_ResCode=this.AV10ResCode;
         aP6_ResMessage=this.AV12ResMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV25ok = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23UserConect)) )
         {
            AV12ResMessage = context.GetMessage( "Usuario incorrecto", "");
            AV10ResCode = 101;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8Key)) )
         {
            AV12ResMessage = context.GetMessage( "llave de acceso no valida.", "");
            AV10ResCode = 102;
         }
         else if ( StringUtil.StrCmp(AV8Key, context.GetMessage( "d3d3LmF6bWl0YS5jb20=", "")) != 0 )
         {
            AV12ResMessage = context.GetMessage( "llave de acceso no valida.", "");
            AV10ResCode = 103;
         }
         else
         {
            AV25ok = true;
         }
         if ( AV25ok )
         {
            AV21SDTSolicitudCobrar.FromJSonString(AV22OrdenPago, null);
            AV26OperacionesId = AV21SDTSolicitudCobrar.gxTpr_Ordennro;
            AV27GXLvl22 = 0;
            /* Using cursor P00CA2 */
            pr_default.execute(0, new Object[] {AV26OperacionesId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A554OperacionesId = P00CA2_A554OperacionesId[0];
               A577OperacionesEstado = P00CA2_A577OperacionesEstado[0];
               n577OperacionesEstado = P00CA2_n577OperacionesEstado[0];
               A570OperacionesImporte = P00CA2_A570OperacionesImporte[0];
               n570OperacionesImporte = P00CA2_n570OperacionesImporte[0];
               A575OperacionesRequest = P00CA2_A575OperacionesRequest[0];
               n575OperacionesRequest = P00CA2_n575OperacionesRequest[0];
               A576OperacionesResponse = P00CA2_A576OperacionesResponse[0];
               n576OperacionesResponse = P00CA2_n576OperacionesResponse[0];
               A580OperacionesComprobantePago = P00CA2_A580OperacionesComprobantePago[0];
               n580OperacionesComprobantePago = P00CA2_n580OperacionesComprobantePago[0];
               A582OperacionesFechaPago = P00CA2_A582OperacionesFechaPago[0];
               n582OperacionesFechaPago = P00CA2_n582OperacionesFechaPago[0];
               A649OperacionesTipo = P00CA2_A649OperacionesTipo[0];
               n649OperacionesTipo = P00CA2_n649OperacionesTipo[0];
               A555OperacionesRef = P00CA2_A555OperacionesRef[0];
               n555OperacionesRef = P00CA2_n555OperacionesRef[0];
               AV27GXLvl22 = 1;
               if ( StringUtil.StrCmp(A577OperacionesEstado, "PND") != 0 )
               {
                  AV10ResCode = 104;
                  AV12ResMessage = StringUtil.Format( context.GetMessage( "La operación ya fue confirmada.", ""), "", "", "", "", "", "", "", "", "");
               }
               else if ( A570OperacionesImporte != AV21SDTSolicitudCobrar.gxTpr_Totalcobrado )
               {
                  AV10ResCode = 104;
                  AV12ResMessage = StringUtil.Format( context.GetMessage( "El importe cobrado de %1 es diferente al total de la operación de pago.", ""), StringUtil.Trim( context.localUtil.Format( AV21SDTSolicitudCobrar.gxTpr_Totalcobrado, "ZZZZZZZZZZZZZZ9.99")), "", "", "", "", "", "", "", "");
               }
               else
               {
                  A575OperacionesRequest = AV19Request;
                  n575OperacionesRequest = false;
                  A576OperacionesResponse = AV20Response;
                  n576OperacionesResponse = false;
                  A580OperacionesComprobantePago = AV21SDTSolicitudCobrar.gxTpr_Comprobantecobro;
                  n580OperacionesComprobantePago = false;
                  A582OperacionesFechaPago = DateTimeUtil.ServerNow( context, pr_default);
                  n582OperacionesFechaPago = false;
                  A577OperacionesEstado = "PRO";
                  n577OperacionesEstado = false;
                  if ( StringUtil.StrCmp(A649OperacionesTipo, "CSO") == 0 )
                  {
                     AV13SolicitudesID = (long)(Math.Round(NumberUtil.Val( A555OperacionesRef, "."), 18, MidpointRounding.ToEven));
                     /* Execute user subroutine: 'REMARCAR CAMBIO DE PAGO SOLICITUD' */
                     S111 ();
                     if ( returnInSub )
                     {
                        pr_default.close(0);
                        cleanup();
                        if (true) return;
                     }
                  }
                  AV10ResCode = 0;
                  AV12ResMessage = context.GetMessage( "Success", "");
               }
               /* Using cursor P00CA3 */
               pr_default.execute(1, new Object[] {n577OperacionesEstado, A577OperacionesEstado, n575OperacionesRequest, A575OperacionesRequest, n576OperacionesResponse, A576OperacionesResponse, n580OperacionesComprobantePago, A580OperacionesComprobantePago, n582OperacionesFechaPago, A582OperacionesFechaPago, A554OperacionesId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Operaciones");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( AV27GXLvl22 == 0 )
            {
               AV10ResCode = 106;
               AV12ResMessage = context.GetMessage( "Operación no existe.", "");
            }
         }
         context.CommitDataStores("wsconfirmaroperacion",pr_default);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'REMARCAR CAMBIO DE PAGO SOLICITUD' Routine */
         returnInSub = false;
         /* Using cursor P00CA4 */
         pr_default.execute(2, new Object[] {AV13SolicitudesID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A127SolicitudesID = P00CA4_A127SolicitudesID[0];
            A128MetodoPagosID = P00CA4_A128MetodoPagosID[0];
            A441SolicitudesPagado = P00CA4_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P00CA4_n441SolicitudesPagado[0];
            A128MetodoPagosID = 2;
            A441SolicitudesPagado = context.GetMessage( "S", "");
            n441SolicitudesPagado = false;
            /* Using cursor P00CA5 */
            pr_default.execute(3, new Object[] {A128MetodoPagosID, n441SolicitudesPagado, A441SolicitudesPagado, A127SolicitudesID});
            pr_default.close(3);
            pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wsconfirmaroperacion",pr_default);
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
         AV21SDTSolicitudCobrar = new SdtSDTOperacionPago(context);
         P00CA2_A554OperacionesId = new long[1] ;
         P00CA2_A577OperacionesEstado = new string[] {""} ;
         P00CA2_n577OperacionesEstado = new bool[] {false} ;
         P00CA2_A570OperacionesImporte = new decimal[1] ;
         P00CA2_n570OperacionesImporte = new bool[] {false} ;
         P00CA2_A575OperacionesRequest = new string[] {""} ;
         P00CA2_n575OperacionesRequest = new bool[] {false} ;
         P00CA2_A576OperacionesResponse = new string[] {""} ;
         P00CA2_n576OperacionesResponse = new bool[] {false} ;
         P00CA2_A580OperacionesComprobantePago = new string[] {""} ;
         P00CA2_n580OperacionesComprobantePago = new bool[] {false} ;
         P00CA2_A582OperacionesFechaPago = new DateTime[] {DateTime.MinValue} ;
         P00CA2_n582OperacionesFechaPago = new bool[] {false} ;
         P00CA2_A649OperacionesTipo = new string[] {""} ;
         P00CA2_n649OperacionesTipo = new bool[] {false} ;
         P00CA2_A555OperacionesRef = new string[] {""} ;
         P00CA2_n555OperacionesRef = new bool[] {false} ;
         A577OperacionesEstado = "";
         A575OperacionesRequest = "";
         A576OperacionesResponse = "";
         A580OperacionesComprobantePago = "";
         A582OperacionesFechaPago = (DateTime)(DateTime.MinValue);
         A649OperacionesTipo = "";
         A555OperacionesRef = "";
         P00CA4_A127SolicitudesID = new long[1] ;
         P00CA4_A128MetodoPagosID = new long[1] ;
         P00CA4_A441SolicitudesPagado = new string[] {""} ;
         P00CA4_n441SolicitudesPagado = new bool[] {false} ;
         A441SolicitudesPagado = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.awsconfirmaroperacion__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.awsconfirmaroperacion__default(),
            new Object[][] {
                new Object[] {
               P00CA2_A554OperacionesId, P00CA2_A577OperacionesEstado, P00CA2_n577OperacionesEstado, P00CA2_A570OperacionesImporte, P00CA2_n570OperacionesImporte, P00CA2_A575OperacionesRequest, P00CA2_n575OperacionesRequest, P00CA2_A576OperacionesResponse, P00CA2_n576OperacionesResponse, P00CA2_A580OperacionesComprobantePago,
               P00CA2_n580OperacionesComprobantePago, P00CA2_A582OperacionesFechaPago, P00CA2_n582OperacionesFechaPago, P00CA2_A649OperacionesTipo, P00CA2_n649OperacionesTipo, P00CA2_A555OperacionesRef, P00CA2_n555OperacionesRef
               }
               , new Object[] {
               }
               , new Object[] {
               P00CA4_A127SolicitudesID, P00CA4_A128MetodoPagosID, P00CA4_A441SolicitudesPagado, P00CA4_n441SolicitudesPagado
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXSoapError ;
      private short currSoapErr ;
      private short readOk ;
      private short nOutParmCount ;
      private short AV27GXLvl22 ;
      private long AV10ResCode ;
      private long AV26OperacionesId ;
      private long A554OperacionesId ;
      private long AV13SolicitudesID ;
      private long A127SolicitudesID ;
      private long A128MetodoPagosID ;
      private decimal A570OperacionesImporte ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private string AV23UserConect ;
      private string AV8Key ;
      private string AV12ResMessage ;
      private string A577OperacionesEstado ;
      private string A580OperacionesComprobantePago ;
      private string A649OperacionesTipo ;
      private string A555OperacionesRef ;
      private string A441SolicitudesPagado ;
      private DateTime A582OperacionesFechaPago ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private bool AV25ok ;
      private bool n577OperacionesEstado ;
      private bool n570OperacionesImporte ;
      private bool n575OperacionesRequest ;
      private bool n576OperacionesResponse ;
      private bool n580OperacionesComprobantePago ;
      private bool n582OperacionesFechaPago ;
      private bool n649OperacionesTipo ;
      private bool n555OperacionesRef ;
      private bool returnInSub ;
      private bool n441SolicitudesPagado ;
      private string AV22OrdenPago ;
      private string AV19Request ;
      private string AV20Response ;
      private string A575OperacionesRequest ;
      private string A576OperacionesResponse ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTOperacionPago AV21SDTSolicitudCobrar ;
      private IDataStoreProvider pr_default ;
      private long[] P00CA2_A554OperacionesId ;
      private string[] P00CA2_A577OperacionesEstado ;
      private bool[] P00CA2_n577OperacionesEstado ;
      private decimal[] P00CA2_A570OperacionesImporte ;
      private bool[] P00CA2_n570OperacionesImporte ;
      private string[] P00CA2_A575OperacionesRequest ;
      private bool[] P00CA2_n575OperacionesRequest ;
      private string[] P00CA2_A576OperacionesResponse ;
      private bool[] P00CA2_n576OperacionesResponse ;
      private string[] P00CA2_A580OperacionesComprobantePago ;
      private bool[] P00CA2_n580OperacionesComprobantePago ;
      private DateTime[] P00CA2_A582OperacionesFechaPago ;
      private bool[] P00CA2_n582OperacionesFechaPago ;
      private string[] P00CA2_A649OperacionesTipo ;
      private bool[] P00CA2_n649OperacionesTipo ;
      private string[] P00CA2_A555OperacionesRef ;
      private bool[] P00CA2_n555OperacionesRef ;
      private long[] P00CA4_A127SolicitudesID ;
      private long[] P00CA4_A128MetodoPagosID ;
      private string[] P00CA4_A441SolicitudesPagado ;
      private bool[] P00CA4_n441SolicitudesPagado ;
      private long aP5_ResCode ;
      private string aP6_ResMessage ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class awsconfirmaroperacion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class awsconfirmaroperacion__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new UpdateCursor(def[3])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00CA2;
        prmP00CA2 = new Object[] {
        new ParDef("@AV26OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmP00CA3;
        prmP00CA3 = new Object[] {
        new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesRequest",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@OperacionesResponse",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@OperacionesComprobantePago",GXType.NChar,256,0){Nullable=true} ,
        new ParDef("@OperacionesFechaPago",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmP00CA4;
        prmP00CA4 = new Object[] {
        new ParDef("@AV13SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP00CA5;
        prmP00CA5 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0) ,
        new ParDef("@SolicitudesPagado",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00CA2", "SELECT [OperacionesId], [OperacionesEstado], [OperacionesImporte], [OperacionesRequest], [OperacionesResponse], [OperacionesComprobantePago], [OperacionesFechaPago], [OperacionesTipo], [OperacionesRef] FROM [Operaciones] WITH (UPDLOCK) WHERE [OperacionesId] = @AV26OperacionesId ORDER BY [OperacionesId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CA2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00CA3", "UPDATE [Operaciones] SET [OperacionesEstado]=@OperacionesEstado, [OperacionesRequest]=@OperacionesRequest, [OperacionesResponse]=@OperacionesResponse, [OperacionesComprobantePago]=@OperacionesComprobantePago, [OperacionesFechaPago]=@OperacionesFechaPago  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CA3)
           ,new CursorDef("P00CA4", "SELECT [SolicitudesID], [MetodoPagosID], [SolicitudesPagado] FROM [Solicitudes] WITH (UPDLOCK) WHERE [SolicitudesID] = @AV13SolicitudesID ORDER BY [SolicitudesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CA4,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00CA5", "UPDATE [Solicitudes] SET [MetodoPagosID]=@MetodoPagosID, [SolicitudesPagado]=@SolicitudesPagado  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CA5)
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
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 256);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getString(8, 3);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getString(9, 25);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
     }
  }

}

}
