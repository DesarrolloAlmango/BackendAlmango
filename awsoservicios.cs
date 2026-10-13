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
   public class awsoservicios : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         AV15SDTServicios = new GXBaseCollection<SdtSDTServicios_Item>( context, "Item", "AlmangoX") ;
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOServicios");
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
               GXSoapXMLWriter.WriteAttribute("name", "SDTServicios");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "Item");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTServicios.Item");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "SDTServicios.Item");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "ServiciosId");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:long");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "ServiciosNombre");
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
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServicios.Execute");
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
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServicios.ExecuteResponse");
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
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTServicios");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServicios.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSOServicios.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServicios.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSOServicios.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSOServicios.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSOServicios.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"WSOServiciosSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "AlmangoXaction/"+"AWSOSERVICIOS.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOServicios");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"WSOServiciosSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"awsoservicios.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "awsoservicios.aspx" + "?wsdl to get the WSDL.";
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
                        AV15SDTServicios = new GXBaseCollection<SdtSDTServicios_Item>( context, "Item", "AlmangoX");
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
                                 AV18ProveedorID = (long)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
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
            GXSoapXMLWriter.WriteStartElement("WSOServicios.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
            if ( currSoapErr == 0 )
            {
               GXSoapXMLWriter.WriteElement("Rescode", StringUtil.Trim( StringUtil.Str( (decimal)(AV12ResCode), 6, 0)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Resmessage", AV13ResMessage);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               if ( AV15SDTServicios != null )
               {
                  AV15SDTServicios.writexmlcollection(GXSoapXMLWriter, "Sdtservicios", "AlmangoX", "Item", "AlmangoX");
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

      public awsoservicios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awsoservicios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserConect ,
                           string aP1_Key ,
                           long aP2_ProveedorID ,
                           out int aP3_ResCode ,
                           out string aP4_ResMessage ,
                           out GXBaseCollection<SdtSDTServicios_Item> aP5_SDTServicios )
      {
         this.AV14UserConect = aP0_UserConect;
         this.AV9Key = aP1_Key;
         this.AV18ProveedorID = aP2_ProveedorID;
         this.AV12ResCode = 0 ;
         this.AV13ResMessage = "" ;
         this.AV15SDTServicios = new GXBaseCollection<SdtSDTServicios_Item>( context, "Item", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP3_ResCode=this.AV12ResCode;
         aP4_ResMessage=this.AV13ResMessage;
         aP5_SDTServicios=this.AV15SDTServicios;
      }

      public GXBaseCollection<SdtSDTServicios_Item> executeUdp( string aP0_UserConect ,
                                                                string aP1_Key ,
                                                                long aP2_ProveedorID ,
                                                                out int aP3_ResCode ,
                                                                out string aP4_ResMessage )
      {
         execute(aP0_UserConect, aP1_Key, aP2_ProveedorID, out aP3_ResCode, out aP4_ResMessage, out aP5_SDTServicios);
         return AV15SDTServicios ;
      }

      public void executeSubmit( string aP0_UserConect ,
                                 string aP1_Key ,
                                 long aP2_ProveedorID ,
                                 out int aP3_ResCode ,
                                 out string aP4_ResMessage ,
                                 out GXBaseCollection<SdtSDTServicios_Item> aP5_SDTServicios )
      {
         this.AV14UserConect = aP0_UserConect;
         this.AV9Key = aP1_Key;
         this.AV18ProveedorID = aP2_ProveedorID;
         this.AV12ResCode = 0 ;
         this.AV13ResMessage = "" ;
         this.AV15SDTServicios = new GXBaseCollection<SdtSDTServicios_Item>( context, "Item", "AlmangoX") ;
         SubmitImpl();
         aP3_ResCode=this.AV12ResCode;
         aP4_ResMessage=this.AV13ResMessage;
         aP5_SDTServicios=this.AV15SDTServicios;
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
         else
         {
            AV10ok = true;
         }
         if ( AV10ok )
         {
            /* Using cursor P00822 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A123RubrosEstado = P00822_A123RubrosEstado[0];
               n123RubrosEstado = P00822_n123RubrosEstado[0];
               A40000RubrosImagen_GXI = P00822_A40000RubrosImagen_GXI[0];
               A121RubrosId = P00822_A121RubrosId[0];
               A122RubrosNombre = P00822_A122RubrosNombre[0];
               A168RubrosImagen = P00822_A168RubrosImagen[0];
               new orubroitemactivo(context ).execute(  AV18ProveedorID,  A121RubrosId,  AV20MedidasID,  AV21InventarioId, out  AV10ok) ;
               if ( AV10ok )
               {
                  AV16Item.gxTpr_Serviciosid = A121RubrosId;
                  AV16Item.gxTpr_Serviciosnombre = A122RubrosNombre;
                  AV16Item.gxTpr_Imagen = A168RubrosImagen;
                  AV16Item.gxTpr_Imagen_gxi = A40000RubrosImagen_GXI;
                  AV15SDTServicios.Add(AV16Item, 0);
                  AV16Item = new SdtSDTServicios_Item(context);
               }
               AV13ResMessage = context.GetMessage( "Proceso Completado.", "");
               AV12ResCode = 0;
               pr_default.readNext(0);
            }
            pr_default.close(0);
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
         P00822_A123RubrosEstado = new string[] {""} ;
         P00822_n123RubrosEstado = new bool[] {false} ;
         P00822_A40000RubrosImagen_GXI = new string[] {""} ;
         P00822_A121RubrosId = new short[1] ;
         P00822_A122RubrosNombre = new string[] {""} ;
         P00822_A168RubrosImagen = new string[] {""} ;
         A123RubrosEstado = "";
         A40000RubrosImagen_GXI = "";
         A122RubrosNombre = "";
         A168RubrosImagen = "";
         AV16Item = new SdtSDTServicios_Item(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.awsoservicios__default(),
            new Object[][] {
                new Object[] {
               P00822_A123RubrosEstado, P00822_n123RubrosEstado, P00822_A40000RubrosImagen_GXI, P00822_A121RubrosId, P00822_A122RubrosNombre, P00822_A168RubrosImagen
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXSoapError ;
      private short currSoapErr ;
      private short readOk ;
      private short nOutParmCount ;
      private short A121RubrosId ;
      private int AV12ResCode ;
      private long AV18ProveedorID ;
      private long AV20MedidasID ;
      private long AV21InventarioId ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private string AV14UserConect ;
      private string AV9Key ;
      private string AV13ResMessage ;
      private string A123RubrosEstado ;
      private string A122RubrosNombre ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private bool AV10ok ;
      private bool n123RubrosEstado ;
      private string A40000RubrosImagen_GXI ;
      private string A168RubrosImagen ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private GXBaseCollection<SdtSDTServicios_Item> AV15SDTServicios ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00822_A123RubrosEstado ;
      private bool[] P00822_n123RubrosEstado ;
      private string[] P00822_A40000RubrosImagen_GXI ;
      private short[] P00822_A121RubrosId ;
      private string[] P00822_A122RubrosNombre ;
      private string[] P00822_A168RubrosImagen ;
      private SdtSDTServicios_Item AV16Item ;
      private int aP3_ResCode ;
      private string aP4_ResMessage ;
      private GXBaseCollection<SdtSDTServicios_Item> aP5_SDTServicios ;
   }

   public class awsoservicios__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00822;
          prmP00822 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00822", "SELECT [RubrosEstado], [RubrosImagen_GXI], [RubrosId], [RubrosNombre], [RubrosImagen] FROM [Rubros] WHERE [RubrosEstado] = 'HAB' ORDER BY [RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00822,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 100);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(2));
                return;
       }
    }

 }

}
