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
   public class awsosolicitudesmpago : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudesMPago");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudesMPago.Execute");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Solicitudesid");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Mpagoid");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Comision");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:double");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Iva");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:double");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Result");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudesMPago.ExecuteResponse");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("name", "retval");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudesMPago.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSOSolicitudesMPago.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudesMPago.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSOSolicitudesMPago.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudesMPagoSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSOSolicitudesMPago.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSOSolicitudesMPago.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudesMPagoSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"WSOSolicitudesMPagoSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "AlmangoXaction/"+"AWSOSOLICITUDESMPAGO.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudesMPago");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "WSOSolicitudesMPagoSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"WSOSolicitudesMPagoSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"awsosolicitudesmpago.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "awsosolicitudesmpago.aspx" + "?wsdl to get the WSDL.";
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
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Solicitudesid") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV8SolicitudesId = (long)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Mpagoid") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV10MPagoId = (long)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Comision") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV9Comision = NumberUtil.Val( GXSoapXMLReader.Value, ".");
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Iva") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV11IVA = NumberUtil.Val( GXSoapXMLReader.Value, ".");
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Result") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV12Result = GXSoapXMLReader.Value;
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
            GXSoapXMLWriter.WriteStartElement("WSOSolicitudesMPago.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
            if ( currSoapErr == 0 )
            {
               GXSoapXMLWriter.WriteElement("retval", "");
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

      public awsosolicitudesmpago( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awsosolicitudesmpago( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           long aP1_MPagoId ,
                           decimal aP2_Comision ,
                           decimal aP3_IVA ,
                           string aP4_Result )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV10MPagoId = aP1_MPagoId;
         this.AV9Comision = aP2_Comision;
         this.AV11IVA = aP3_IVA;
         this.AV12Result = aP4_Result;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 long aP1_MPagoId ,
                                 decimal aP2_Comision ,
                                 decimal aP3_IVA ,
                                 string aP4_Result )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV10MPagoId = aP1_MPagoId;
         this.AV9Comision = aP2_Comision;
         this.AV11IVA = aP3_IVA;
         this.AV12Result = aP4_Result;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00FT2 */
         pr_default.execute(0, new Object[] {AV8SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTFT2 = 0;
            A127SolicitudesID = P00FT2_A127SolicitudesID[0];
            A796SolicitudesComisionMetodoPago = P00FT2_A796SolicitudesComisionMetodoPago[0];
            A438SolicitudServicioOrigenPago = P00FT2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00FT2_n438SolicitudServicioOrigenPago[0];
            A128MetodoPagosID = P00FT2_A128MetodoPagosID[0];
            A131EstadosSolId = P00FT2_A131EstadosSolId[0];
            A597SolicitudesUsrAlta = P00FT2_A597SolicitudesUsrAlta[0];
            n597SolicitudesUsrAlta = P00FT2_n597SolicitudesUsrAlta[0];
            A441SolicitudesPagado = P00FT2_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P00FT2_n441SolicitudesPagado[0];
            A672SolicitudesCalComi = P00FT2_A672SolicitudesCalComi[0];
            A527SolicitudServicioComProv = P00FT2_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = P00FT2_n527SolicitudServicioComProv[0];
            A528SolicitudServicioComProvP = P00FT2_A528SolicitudServicioComProvP[0];
            n528SolicitudServicioComProvP = P00FT2_n528SolicitudServicioComProvP[0];
            A530SolicitudServicioComALM = P00FT2_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = P00FT2_n530SolicitudServicioComALM[0];
            A532SolicitudServicioComALMP = P00FT2_A532SolicitudServicioComALMP[0];
            n532SolicitudServicioComALMP = P00FT2_n532SolicitudServicioComALMP[0];
            A598SolicitudesUsrActualizacion = P00FT2_A598SolicitudesUsrActualizacion[0];
            n598SolicitudesUsrActualizacion = P00FT2_n598SolicitudesUsrActualizacion[0];
            A796SolicitudesComisionMetodoPago = AV9Comision;
            A438SolicitudServicioOrigenPago = "O";
            n438SolicitudServicioOrigenPago = false;
            A128MetodoPagosID = 4;
            if ( A131EstadosSolId == 9 )
            {
               A131EstadosSolId = 1;
               if ( ((A597SolicitudesUsrAlta==1061)||(A597SolicitudesUsrAlta==1013)||(A597SolicitudesUsrAlta==1014)||(A597SolicitudesUsrAlta==1010)) )
               {
                  A131EstadosSolId = 8;
               }
            }
            A441SolicitudesPagado = context.GetMessage( "S", "");
            n441SolicitudesPagado = false;
            GXTFT2 = 1;
            if ( A672SolicitudesCalComi )
            {
               new ocomisionsolicitud(context ).execute(  A127SolicitudesID,  "",  true, out  AV13SolicitudServicioComProv, out  AV14SolicitudServicioComProvP, out  AV15SolicitudServicioComALM, out  AV16SolicitudServicioComALMP, out  AV17SolicitudServicioComPro, out  AV18SolicitudServicioComProP) ;
               A527SolicitudServicioComProv = AV13SolicitudServicioComProv;
               n527SolicitudServicioComProv = false;
               A528SolicitudServicioComProvP = AV14SolicitudServicioComProvP;
               n528SolicitudServicioComProvP = false;
               A530SolicitudServicioComALM = AV15SolicitudServicioComALM;
               n530SolicitudServicioComALM = false;
               A532SolicitudServicioComALMP = AV16SolicitudServicioComALMP;
               n532SolicitudServicioComALMP = false;
            }
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV20WWPContext) ;
            A598SolicitudesUsrActualizacion = AV20WWPContext.gxTpr_Userid;
            n598SolicitudesUsrActualizacion = false;
            /* Using cursor P00FT3 */
            pr_default.execute(1, new Object[] {A796SolicitudesComisionMetodoPago, n438SolicitudServicioOrigenPago, A438SolicitudServicioOrigenPago, A128MetodoPagosID, A131EstadosSolId, n441SolicitudesPagado, A441SolicitudesPagado, n527SolicitudServicioComProv, A527SolicitudServicioComProv, n528SolicitudServicioComProvP, A528SolicitudServicioComProvP, n530SolicitudServicioComALM, A530SolicitudServicioComALM, n532SolicitudServicioComALMP, A532SolicitudServicioComALMP, n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion, A127SolicitudesID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
            if ( GXTFT2 == 1 )
            {
               context.CommitDataStores("wsosolicitudesmpago",pr_default);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00FT4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A577OperacionesEstado = P00FT4_A577OperacionesEstado[0];
            n577OperacionesEstado = P00FT4_n577OperacionesEstado[0];
            A649OperacionesTipo = P00FT4_A649OperacionesTipo[0];
            n649OperacionesTipo = P00FT4_n649OperacionesTipo[0];
            A555OperacionesRef = P00FT4_A555OperacionesRef[0];
            n555OperacionesRef = P00FT4_n555OperacionesRef[0];
            A570OperacionesImporte = P00FT4_A570OperacionesImporte[0];
            n570OperacionesImporte = P00FT4_n570OperacionesImporte[0];
            A578OperacionesImporteGrabado = P00FT4_A578OperacionesImporteGrabado[0];
            n578OperacionesImporteGrabado = P00FT4_n578OperacionesImporteGrabado[0];
            A580OperacionesComprobantePago = P00FT4_A580OperacionesComprobantePago[0];
            n580OperacionesComprobantePago = P00FT4_n580OperacionesComprobantePago[0];
            A573OperacionesIva = P00FT4_A573OperacionesIva[0];
            n573OperacionesIva = P00FT4_n573OperacionesIva[0];
            A576OperacionesResponse = P00FT4_A576OperacionesResponse[0];
            n576OperacionesResponse = P00FT4_n576OperacionesResponse[0];
            A554OperacionesId = P00FT4_A554OperacionesId[0];
            if ( StringUtil.StrCmp(StringUtil.Trim( A555OperacionesRef), StringUtil.Trim( context.localUtil.Format( (decimal)(AV8SolicitudesId), "ZZZZZZZZZZZZZZZZZ9"))) == 0 )
            {
               A577OperacionesEstado = "PRO";
               n577OperacionesEstado = false;
               A578OperacionesImporteGrabado = (decimal)(A570OperacionesImporte-AV9Comision);
               n578OperacionesImporteGrabado = false;
               A580OperacionesComprobantePago = StringUtil.Str( (decimal)(AV10MPagoId), 18, 0);
               n580OperacionesComprobantePago = false;
               A573OperacionesIva = AV11IVA;
               n573OperacionesIva = false;
               A576OperacionesResponse = StringUtil.Trim( AV12Result);
               n576OperacionesResponse = false;
               /* Using cursor P00FT5 */
               pr_default.execute(3, new Object[] {n577OperacionesEstado, A577OperacionesEstado, n578OperacionesImporteGrabado, A578OperacionesImporteGrabado, n580OperacionesComprobantePago, A580OperacionesComprobantePago, n573OperacionesIva, A573OperacionesIva, n576OperacionesResponse, A576OperacionesResponse, A554OperacionesId});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("Operaciones");
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wsosolicitudesmpago",pr_default);
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
         P00FT2_A127SolicitudesID = new long[1] ;
         P00FT2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00FT2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00FT2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00FT2_A128MetodoPagosID = new long[1] ;
         P00FT2_A131EstadosSolId = new int[1] ;
         P00FT2_A597SolicitudesUsrAlta = new long[1] ;
         P00FT2_n597SolicitudesUsrAlta = new bool[] {false} ;
         P00FT2_A441SolicitudesPagado = new string[] {""} ;
         P00FT2_n441SolicitudesPagado = new bool[] {false} ;
         P00FT2_A672SolicitudesCalComi = new bool[] {false} ;
         P00FT2_A527SolicitudServicioComProv = new decimal[1] ;
         P00FT2_n527SolicitudServicioComProv = new bool[] {false} ;
         P00FT2_A528SolicitudServicioComProvP = new decimal[1] ;
         P00FT2_n528SolicitudServicioComProvP = new bool[] {false} ;
         P00FT2_A530SolicitudServicioComALM = new decimal[1] ;
         P00FT2_n530SolicitudServicioComALM = new bool[] {false} ;
         P00FT2_A532SolicitudServicioComALMP = new decimal[1] ;
         P00FT2_n532SolicitudServicioComALMP = new bool[] {false} ;
         P00FT2_A598SolicitudesUsrActualizacion = new long[1] ;
         P00FT2_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         A438SolicitudServicioOrigenPago = "";
         A441SolicitudesPagado = "";
         AV20WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00FT4_A577OperacionesEstado = new string[] {""} ;
         P00FT4_n577OperacionesEstado = new bool[] {false} ;
         P00FT4_A649OperacionesTipo = new string[] {""} ;
         P00FT4_n649OperacionesTipo = new bool[] {false} ;
         P00FT4_A555OperacionesRef = new string[] {""} ;
         P00FT4_n555OperacionesRef = new bool[] {false} ;
         P00FT4_A570OperacionesImporte = new decimal[1] ;
         P00FT4_n570OperacionesImporte = new bool[] {false} ;
         P00FT4_A578OperacionesImporteGrabado = new decimal[1] ;
         P00FT4_n578OperacionesImporteGrabado = new bool[] {false} ;
         P00FT4_A580OperacionesComprobantePago = new string[] {""} ;
         P00FT4_n580OperacionesComprobantePago = new bool[] {false} ;
         P00FT4_A573OperacionesIva = new decimal[1] ;
         P00FT4_n573OperacionesIva = new bool[] {false} ;
         P00FT4_A576OperacionesResponse = new string[] {""} ;
         P00FT4_n576OperacionesResponse = new bool[] {false} ;
         P00FT4_A554OperacionesId = new long[1] ;
         A577OperacionesEstado = "";
         A649OperacionesTipo = "";
         A555OperacionesRef = "";
         A580OperacionesComprobantePago = "";
         A576OperacionesResponse = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.awsosolicitudesmpago__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.awsosolicitudesmpago__default(),
            new Object[][] {
                new Object[] {
               P00FT2_A127SolicitudesID, P00FT2_A796SolicitudesComisionMetodoPago, P00FT2_A438SolicitudServicioOrigenPago, P00FT2_n438SolicitudServicioOrigenPago, P00FT2_A128MetodoPagosID, P00FT2_A131EstadosSolId, P00FT2_A597SolicitudesUsrAlta, P00FT2_n597SolicitudesUsrAlta, P00FT2_A441SolicitudesPagado, P00FT2_n441SolicitudesPagado,
               P00FT2_A672SolicitudesCalComi, P00FT2_A527SolicitudServicioComProv, P00FT2_n527SolicitudServicioComProv, P00FT2_A528SolicitudServicioComProvP, P00FT2_n528SolicitudServicioComProvP, P00FT2_A530SolicitudServicioComALM, P00FT2_n530SolicitudServicioComALM, P00FT2_A532SolicitudServicioComALMP, P00FT2_n532SolicitudServicioComALMP, P00FT2_A598SolicitudesUsrActualizacion,
               P00FT2_n598SolicitudesUsrActualizacion
               }
               , new Object[] {
               }
               , new Object[] {
               P00FT4_A577OperacionesEstado, P00FT4_n577OperacionesEstado, P00FT4_A649OperacionesTipo, P00FT4_n649OperacionesTipo, P00FT4_A555OperacionesRef, P00FT4_n555OperacionesRef, P00FT4_A570OperacionesImporte, P00FT4_n570OperacionesImporte, P00FT4_A578OperacionesImporteGrabado, P00FT4_n578OperacionesImporteGrabado,
               P00FT4_A580OperacionesComprobantePago, P00FT4_n580OperacionesComprobantePago, P00FT4_A573OperacionesIva, P00FT4_n573OperacionesIva, P00FT4_A576OperacionesResponse, P00FT4_n576OperacionesResponse, P00FT4_A554OperacionesId
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
      private short GXTFT2 ;
      private int A131EstadosSolId ;
      private long AV8SolicitudesId ;
      private long AV10MPagoId ;
      private long A127SolicitudesID ;
      private long A128MetodoPagosID ;
      private long A597SolicitudesUsrAlta ;
      private long A598SolicitudesUsrActualizacion ;
      private long A554OperacionesId ;
      private decimal AV9Comision ;
      private decimal AV11IVA ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A527SolicitudServicioComProv ;
      private decimal A528SolicitudServicioComProvP ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A532SolicitudServicioComALMP ;
      private decimal AV13SolicitudServicioComProv ;
      private decimal AV14SolicitudServicioComProvP ;
      private decimal AV15SolicitudServicioComALM ;
      private decimal AV16SolicitudServicioComALMP ;
      private decimal AV17SolicitudServicioComPro ;
      private decimal AV18SolicitudServicioComProP ;
      private decimal A570OperacionesImporte ;
      private decimal A578OperacionesImporteGrabado ;
      private decimal A573OperacionesIva ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private string A438SolicitudServicioOrigenPago ;
      private string A441SolicitudesPagado ;
      private string A577OperacionesEstado ;
      private string A649OperacionesTipo ;
      private string A555OperacionesRef ;
      private string A580OperacionesComprobantePago ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n597SolicitudesUsrAlta ;
      private bool n441SolicitudesPagado ;
      private bool A672SolicitudesCalComi ;
      private bool n527SolicitudServicioComProv ;
      private bool n528SolicitudServicioComProvP ;
      private bool n530SolicitudServicioComALM ;
      private bool n532SolicitudServicioComALMP ;
      private bool n598SolicitudesUsrActualizacion ;
      private bool n577OperacionesEstado ;
      private bool n649OperacionesTipo ;
      private bool n555OperacionesRef ;
      private bool n570OperacionesImporte ;
      private bool n578OperacionesImporteGrabado ;
      private bool n580OperacionesComprobantePago ;
      private bool n573OperacionesIva ;
      private bool n576OperacionesResponse ;
      private string AV12Result ;
      private string A576OperacionesResponse ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00FT2_A127SolicitudesID ;
      private decimal[] P00FT2_A796SolicitudesComisionMetodoPago ;
      private string[] P00FT2_A438SolicitudServicioOrigenPago ;
      private bool[] P00FT2_n438SolicitudServicioOrigenPago ;
      private long[] P00FT2_A128MetodoPagosID ;
      private int[] P00FT2_A131EstadosSolId ;
      private long[] P00FT2_A597SolicitudesUsrAlta ;
      private bool[] P00FT2_n597SolicitudesUsrAlta ;
      private string[] P00FT2_A441SolicitudesPagado ;
      private bool[] P00FT2_n441SolicitudesPagado ;
      private bool[] P00FT2_A672SolicitudesCalComi ;
      private decimal[] P00FT2_A527SolicitudServicioComProv ;
      private bool[] P00FT2_n527SolicitudServicioComProv ;
      private decimal[] P00FT2_A528SolicitudServicioComProvP ;
      private bool[] P00FT2_n528SolicitudServicioComProvP ;
      private decimal[] P00FT2_A530SolicitudServicioComALM ;
      private bool[] P00FT2_n530SolicitudServicioComALM ;
      private decimal[] P00FT2_A532SolicitudServicioComALMP ;
      private bool[] P00FT2_n532SolicitudServicioComALMP ;
      private long[] P00FT2_A598SolicitudesUsrActualizacion ;
      private bool[] P00FT2_n598SolicitudesUsrActualizacion ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV20WWPContext ;
      private string[] P00FT4_A577OperacionesEstado ;
      private bool[] P00FT4_n577OperacionesEstado ;
      private string[] P00FT4_A649OperacionesTipo ;
      private bool[] P00FT4_n649OperacionesTipo ;
      private string[] P00FT4_A555OperacionesRef ;
      private bool[] P00FT4_n555OperacionesRef ;
      private decimal[] P00FT4_A570OperacionesImporte ;
      private bool[] P00FT4_n570OperacionesImporte ;
      private decimal[] P00FT4_A578OperacionesImporteGrabado ;
      private bool[] P00FT4_n578OperacionesImporteGrabado ;
      private string[] P00FT4_A580OperacionesComprobantePago ;
      private bool[] P00FT4_n580OperacionesComprobantePago ;
      private decimal[] P00FT4_A573OperacionesIva ;
      private bool[] P00FT4_n573OperacionesIva ;
      private string[] P00FT4_A576OperacionesResponse ;
      private bool[] P00FT4_n576OperacionesResponse ;
      private long[] P00FT4_A554OperacionesId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class awsosolicitudesmpago__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class awsosolicitudesmpago__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00FT2;
        prmP00FT2 = new Object[] {
        new ParDef("@AV8SolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmP00FT3;
        prmP00FT3 = new Object[] {
        new ParDef("@SolicitudesComisionMetodoPago",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudServicioOrigenPago",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0) ,
        new ParDef("@SolicitudesPagado",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudServicioComProv",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComProvP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComALM",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComALMP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP00FT4;
        prmP00FT4 = new Object[] {
        };
        Object[] prmP00FT5;
        prmP00FT5 = new Object[] {
        new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesImporteGrabado",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesComprobantePago",GXType.NChar,256,0){Nullable=true} ,
        new ParDef("@OperacionesIva",GXType.Decimal,4,2){Nullable=true} ,
        new ParDef("@OperacionesResponse",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00FT2", "SELECT [SolicitudesID], [SolicitudesComisionMetodoPago], [SolicitudServicioOrigenPago], [MetodoPagosID], [EstadosSolId], [SolicitudesUsrAlta], [SolicitudesPagado], [SolicitudesCalComi], [SolicitudServicioComProv], [SolicitudServicioComProvP], [SolicitudServicioComALM], [SolicitudServicioComALMP], [SolicitudesUsrActualizacion] FROM [Solicitudes] WITH (UPDLOCK) WHERE [SolicitudesID] = @AV8SolicitudesId ORDER BY [SolicitudesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FT2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00FT3", "UPDATE [Solicitudes] SET [SolicitudesComisionMetodoPago]=@SolicitudesComisionMetodoPago, [SolicitudServicioOrigenPago]=@SolicitudServicioOrigenPago, [MetodoPagosID]=@MetodoPagosID, [EstadosSolId]=@EstadosSolId, [SolicitudesPagado]=@SolicitudesPagado, [SolicitudServicioComProv]=@SolicitudServicioComProv, [SolicitudServicioComProvP]=@SolicitudServicioComProvP, [SolicitudServicioComALM]=@SolicitudServicioComALM, [SolicitudServicioComALMP]=@SolicitudServicioComALMP, [SolicitudesUsrActualizacion]=@SolicitudesUsrActualizacion  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00FT3)
           ,new CursorDef("P00FT4", "SELECT [OperacionesEstado], [OperacionesTipo], [OperacionesRef], [OperacionesImporte], [OperacionesImporteGrabado], [OperacionesComprobantePago], [OperacionesIva], [OperacionesResponse], [OperacionesId] FROM [Operaciones] WITH (UPDLOCK) WHERE ([OperacionesTipo] = 'CSO') AND ([OperacionesEstado] = 'PND') ORDER BY [OperacionesRef] DESC ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FT4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00FT5", "UPDATE [Operaciones] SET [OperacionesEstado]=@OperacionesEstado, [OperacionesImporteGrabado]=@OperacionesImporteGrabado, [OperacionesComprobantePago]=@OperacionesComprobantePago, [OperacionesIva]=@OperacionesIva, [OperacionesResponse]=@OperacionesResponse  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00FT5)
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
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              ((int[]) buf[5])[0] = rslt.getInt(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((string[]) buf[8])[0] = rslt.getString(7, 1);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((bool[]) buf[10])[0] = rslt.getBool(8);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              ((long[]) buf[19])[0] = rslt.getLong(13);
              ((bool[]) buf[20])[0] = rslt.wasNull(13);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((string[]) buf[4])[0] = rslt.getString(3, 25);
              ((bool[]) buf[5])[0] = rslt.wasNull(3);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
              ((bool[]) buf[7])[0] = rslt.wasNull(4);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
              ((bool[]) buf[9])[0] = rslt.wasNull(5);
              ((string[]) buf[10])[0] = rslt.getString(6, 256);
              ((bool[]) buf[11])[0] = rslt.wasNull(6);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
              ((bool[]) buf[13])[0] = rslt.wasNull(7);
              ((string[]) buf[14])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[15])[0] = rslt.wasNull(8);
              ((long[]) buf[16])[0] = rslt.getLong(9);
              return;
     }
  }

}

}
