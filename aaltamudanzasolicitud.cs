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
   public class aaltamudanzasolicitud : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               GXSoapXMLWriter.WriteAttribute("name", "AltaMudanzaSolicitud");
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
               GXSoapXMLWriter.WriteAttribute("name", "AltaMudanzaSolicitud.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "AltaMudanzaSolicitud.ExecuteResponse");
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
               GXSoapXMLWriter.WriteAttribute("name", "AltaMudanzaSolicitud.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:AltaMudanzaSolicitud.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "AltaMudanzaSolicitud.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:AltaMudanzaSolicitud.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "AltaMudanzaSolicitudSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"AltaMudanzaSolicitud.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"AltaMudanzaSolicitud.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "AltaMudanzaSolicitudSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"AltaMudanzaSolicitudSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "AlmangoXaction/"+"AALTAMUDANZASOLICITUD.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "AltaMudanzaSolicitud");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "AltaMudanzaSolicitudSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"AltaMudanzaSolicitudSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"aaltamudanzasolicitud.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "aaltamudanzasolicitud.aspx" + "?wsdl to get the WSDL.";
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
                                 AV26SolicitudesId = (long)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Comision") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV36Comision = NumberUtil.Val( GXSoapXMLReader.Value, ".");
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Iva") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV37IVA = NumberUtil.Val( GXSoapXMLReader.Value, ".");
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Result") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV39Result = GXSoapXMLReader.Value;
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
            GXSoapXMLWriter.WriteStartElement("AltaMudanzaSolicitud.ExecuteResponse");
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

      public aaltamudanzasolicitud( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aaltamudanzasolicitud( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           decimal aP1_Comision ,
                           decimal aP2_IVA ,
                           string aP3_Result )
      {
         this.AV26SolicitudesId = aP0_SolicitudesId;
         this.AV36Comision = aP1_Comision;
         this.AV37IVA = aP2_IVA;
         this.AV39Result = aP3_Result;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 decimal aP1_Comision ,
                                 decimal aP2_IVA ,
                                 string aP3_Result )
      {
         this.AV26SolicitudesId = aP0_SolicitudesId;
         this.AV36Comision = aP1_Comision;
         this.AV37IVA = aP2_IVA;
         this.AV39Result = aP3_Result;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00FI2 */
         pr_default.execute(0, new Object[] {AV26SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00FI2_A127SolicitudesID[0];
            A131EstadosSolId = P00FI2_A131EstadosSolId[0];
            A441SolicitudesPagado = P00FI2_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P00FI2_n441SolicitudesPagado[0];
            A131EstadosSolId = 1;
            A441SolicitudesPagado = context.GetMessage( "S", "");
            n441SolicitudesPagado = false;
            /* Using cursor P00FI3 */
            pr_default.execute(1, new Object[] {A131EstadosSolId, n441SolicitudesPagado, A441SolicitudesPagado, A127SolicitudesID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00FI4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A649OperacionesTipo = P00FI4_A649OperacionesTipo[0];
            n649OperacionesTipo = P00FI4_n649OperacionesTipo[0];
            A555OperacionesRef = P00FI4_A555OperacionesRef[0];
            n555OperacionesRef = P00FI4_n555OperacionesRef[0];
            A570OperacionesImporte = P00FI4_A570OperacionesImporte[0];
            n570OperacionesImporte = P00FI4_n570OperacionesImporte[0];
            A578OperacionesImporteGrabado = P00FI4_A578OperacionesImporteGrabado[0];
            n578OperacionesImporteGrabado = P00FI4_n578OperacionesImporteGrabado[0];
            A576OperacionesResponse = P00FI4_A576OperacionesResponse[0];
            n576OperacionesResponse = P00FI4_n576OperacionesResponse[0];
            A577OperacionesEstado = P00FI4_A577OperacionesEstado[0];
            n577OperacionesEstado = P00FI4_n577OperacionesEstado[0];
            A554OperacionesId = P00FI4_A554OperacionesId[0];
            if ( StringUtil.StrCmp(StringUtil.Trim( A555OperacionesRef), StringUtil.Trim( context.localUtil.Format( (decimal)(AV26SolicitudesId), "ZZZZZZZZZZZZZZZZZ9"))) == 0 )
            {
               A578OperacionesImporteGrabado = (decimal)(A570OperacionesImporte-AV36Comision);
               n578OperacionesImporteGrabado = false;
               A576OperacionesResponse = StringUtil.Trim( AV39Result);
               n576OperacionesResponse = false;
               A577OperacionesEstado = "PRO";
               n577OperacionesEstado = false;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P00FI5 */
               pr_default.execute(3, new Object[] {n578OperacionesImporteGrabado, A578OperacionesImporteGrabado, n576OperacionesResponse, A576OperacionesResponse, n577OperacionesEstado, A577OperacionesEstado, A554OperacionesId});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("Operaciones");
               if (true) break;
               /* Using cursor P00FI6 */
               pr_default.execute(4, new Object[] {n578OperacionesImporteGrabado, A578OperacionesImporteGrabado, n576OperacionesResponse, A576OperacionesResponse, n577OperacionesEstado, A577OperacionesEstado, A554OperacionesId});
               pr_default.close(4);
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
         context.CommitDataStores("altamudanzasolicitud",pr_default);
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
         P00FI2_A127SolicitudesID = new long[1] ;
         P00FI2_A131EstadosSolId = new int[1] ;
         P00FI2_A441SolicitudesPagado = new string[] {""} ;
         P00FI2_n441SolicitudesPagado = new bool[] {false} ;
         A441SolicitudesPagado = "";
         P00FI4_A649OperacionesTipo = new string[] {""} ;
         P00FI4_n649OperacionesTipo = new bool[] {false} ;
         P00FI4_A555OperacionesRef = new string[] {""} ;
         P00FI4_n555OperacionesRef = new bool[] {false} ;
         P00FI4_A570OperacionesImporte = new decimal[1] ;
         P00FI4_n570OperacionesImporte = new bool[] {false} ;
         P00FI4_A578OperacionesImporteGrabado = new decimal[1] ;
         P00FI4_n578OperacionesImporteGrabado = new bool[] {false} ;
         P00FI4_A576OperacionesResponse = new string[] {""} ;
         P00FI4_n576OperacionesResponse = new bool[] {false} ;
         P00FI4_A577OperacionesEstado = new string[] {""} ;
         P00FI4_n577OperacionesEstado = new bool[] {false} ;
         P00FI4_A554OperacionesId = new long[1] ;
         A649OperacionesTipo = "";
         A555OperacionesRef = "";
         A576OperacionesResponse = "";
         A577OperacionesEstado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aaltamudanzasolicitud__default(),
            new Object[][] {
                new Object[] {
               P00FI2_A127SolicitudesID, P00FI2_A131EstadosSolId, P00FI2_A441SolicitudesPagado, P00FI2_n441SolicitudesPagado
               }
               , new Object[] {
               }
               , new Object[] {
               P00FI4_A649OperacionesTipo, P00FI4_n649OperacionesTipo, P00FI4_A555OperacionesRef, P00FI4_n555OperacionesRef, P00FI4_A570OperacionesImporte, P00FI4_n570OperacionesImporte, P00FI4_A578OperacionesImporteGrabado, P00FI4_n578OperacionesImporteGrabado, P00FI4_A576OperacionesResponse, P00FI4_n576OperacionesResponse,
               P00FI4_A577OperacionesEstado, P00FI4_n577OperacionesEstado, P00FI4_A554OperacionesId
               }
               , new Object[] {
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
      private int A131EstadosSolId ;
      private long AV26SolicitudesId ;
      private long A127SolicitudesID ;
      private long A554OperacionesId ;
      private decimal AV36Comision ;
      private decimal AV37IVA ;
      private decimal A570OperacionesImporte ;
      private decimal A578OperacionesImporteGrabado ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private string A441SolicitudesPagado ;
      private string A649OperacionesTipo ;
      private string A555OperacionesRef ;
      private string A577OperacionesEstado ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private bool n441SolicitudesPagado ;
      private bool n649OperacionesTipo ;
      private bool n555OperacionesRef ;
      private bool n570OperacionesImporte ;
      private bool n578OperacionesImporteGrabado ;
      private bool n576OperacionesResponse ;
      private bool n577OperacionesEstado ;
      private string AV39Result ;
      private string A576OperacionesResponse ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00FI2_A127SolicitudesID ;
      private int[] P00FI2_A131EstadosSolId ;
      private string[] P00FI2_A441SolicitudesPagado ;
      private bool[] P00FI2_n441SolicitudesPagado ;
      private string[] P00FI4_A649OperacionesTipo ;
      private bool[] P00FI4_n649OperacionesTipo ;
      private string[] P00FI4_A555OperacionesRef ;
      private bool[] P00FI4_n555OperacionesRef ;
      private decimal[] P00FI4_A570OperacionesImporte ;
      private bool[] P00FI4_n570OperacionesImporte ;
      private decimal[] P00FI4_A578OperacionesImporteGrabado ;
      private bool[] P00FI4_n578OperacionesImporteGrabado ;
      private string[] P00FI4_A576OperacionesResponse ;
      private bool[] P00FI4_n576OperacionesResponse ;
      private string[] P00FI4_A577OperacionesEstado ;
      private bool[] P00FI4_n577OperacionesEstado ;
      private long[] P00FI4_A554OperacionesId ;
   }

   public class aaltamudanzasolicitud__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new UpdateCursor(def[3])
         ,new UpdateCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00FI2;
          prmP00FI2 = new Object[] {
          new ParDef("@AV26SolicitudesId",GXType.Decimal,18,0)
          };
          Object[] prmP00FI3;
          prmP00FI3 = new Object[] {
          new ParDef("@EstadosSolId",GXType.Int32,5,0) ,
          new ParDef("@SolicitudesPagado",GXType.NChar,1,0){Nullable=true} ,
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00FI4;
          prmP00FI4 = new Object[] {
          };
          Object[] prmP00FI5;
          prmP00FI5 = new Object[] {
          new ParDef("@OperacionesImporteGrabado",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@OperacionesResponse",GXType.NVarChar,2097152,0){Nullable=true} ,
          new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
          new ParDef("@OperacionesId",GXType.Decimal,18,0)
          };
          Object[] prmP00FI6;
          prmP00FI6 = new Object[] {
          new ParDef("@OperacionesImporteGrabado",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@OperacionesResponse",GXType.NVarChar,2097152,0){Nullable=true} ,
          new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
          new ParDef("@OperacionesId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FI2", "SELECT [SolicitudesID], [EstadosSolId], [SolicitudesPagado] FROM [Solicitudes] WITH (UPDLOCK) WHERE [SolicitudesID] = @AV26SolicitudesId ORDER BY [SolicitudesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FI2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00FI3", "UPDATE [Solicitudes] SET [EstadosSolId]=@EstadosSolId, [SolicitudesPagado]=@SolicitudesPagado  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00FI3)
             ,new CursorDef("P00FI4", "SELECT [OperacionesTipo], [OperacionesRef], [OperacionesImporte], [OperacionesImporteGrabado], [OperacionesResponse], [OperacionesEstado], [OperacionesId] FROM [Operaciones] WITH (UPDLOCK) WHERE [OperacionesTipo] = 'CSO' ORDER BY [OperacionesRef] DESC ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FI4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FI5", "UPDATE [Operaciones] SET [OperacionesImporteGrabado]=@OperacionesImporteGrabado, [OperacionesResponse]=@OperacionesResponse, [OperacionesEstado]=@OperacionesEstado  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00FI5)
             ,new CursorDef("P00FI6", "UPDATE [Operaciones] SET [OperacionesImporteGrabado]=@OperacionesImporteGrabado, [OperacionesResponse]=@OperacionesResponse, [OperacionesEstado]=@OperacionesEstado  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00FI6)
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 25);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getString(6, 3);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((long[]) buf[12])[0] = rslt.getLong(7);
                return;
       }
    }

 }

}
