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
   public class awsoserviciosdetall : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDetALL");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDetALL.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDetALL.ExecuteResponse");
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
               GXSoapXMLWriter.WriteAttribute("name", "Inventario");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDetALL.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSOServiciosDetALL.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDetALL.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSOServiciosDetALL.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDetALLSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSOServiciosDetALL.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSOServiciosDetALL.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDetALLSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"WSOServiciosDetALLSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "AlmangoXaction/"+"AWSOSERVICIOSDETALL.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDetALL");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "WSOServiciosDetALLSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"WSOServiciosDetALLSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"awsoserviciosdetall.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "awsoserviciosdetall.aspx" + "?wsdl to get the WSDL.";
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
            GXSoapXMLWriter.WriteStartElement("WSOServiciosDetALL.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
            if ( currSoapErr == 0 )
            {
               GXSoapXMLWriter.WriteElement("Rescode", StringUtil.Trim( StringUtil.Str( (decimal)(AV12ResCode), 6, 0)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Resmessage", AV13ResMessage);
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Inventario", AV31Inventario);
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

      public awsoserviciosdetall( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awsoserviciosdetall( IGxContext context )
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
                           out string aP5_Inventario )
      {
         this.AV14UserConect = aP0_UserConect;
         this.AV9Key = aP1_Key;
         this.AV19ProveedorID = aP2_ProveedorID;
         this.AV12ResCode = 0 ;
         this.AV13ResMessage = "" ;
         this.AV31Inventario = "" ;
         initialize();
         ExecutePrivate();
         aP3_ResCode=this.AV12ResCode;
         aP4_ResMessage=this.AV13ResMessage;
         aP5_Inventario=this.AV31Inventario;
      }

      public string executeUdp( string aP0_UserConect ,
                                string aP1_Key ,
                                long aP2_ProveedorID ,
                                out int aP3_ResCode ,
                                out string aP4_ResMessage )
      {
         execute(aP0_UserConect, aP1_Key, aP2_ProveedorID, out aP3_ResCode, out aP4_ResMessage, out aP5_Inventario);
         return AV31Inventario ;
      }

      public void executeSubmit( string aP0_UserConect ,
                                 string aP1_Key ,
                                 long aP2_ProveedorID ,
                                 out int aP3_ResCode ,
                                 out string aP4_ResMessage ,
                                 out string aP5_Inventario )
      {
         this.AV14UserConect = aP0_UserConect;
         this.AV9Key = aP1_Key;
         this.AV19ProveedorID = aP2_ProveedorID;
         this.AV12ResCode = 0 ;
         this.AV13ResMessage = "" ;
         this.AV31Inventario = "" ;
         SubmitImpl();
         aP3_ResCode=this.AV12ResCode;
         aP4_ResMessage=this.AV13ResMessage;
         aP5_Inventario=this.AV31Inventario;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10ok = false;
         AV20ProvedorOK = context.GetMessage( "N", "");
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
            /* Using cursor P00D02 */
            pr_default.execute(0, new Object[] {AV19ProveedorID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A344ProveedorEstado = P00D02_A344ProveedorEstado[0];
               A133ProveedorID = P00D02_A133ProveedorID[0];
               if ( StringUtil.StrCmp(A344ProveedorEstado, context.GetMessage( "HAB", "")) == 0 )
               {
                  AV20ProvedorOK = context.GetMessage( "S", "");
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
         }
         if ( ( AV10ok ) && ( StringUtil.StrCmp(AV20ProvedorOK, context.GetMessage( "S", "")) == 0 ) )
         {
            /* Using cursor P00D03 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               A123RubrosEstado = P00D03_A123RubrosEstado[0];
               n123RubrosEstado = P00D03_n123RubrosEstado[0];
               A40000RubrosImagen_GXI = P00D03_A40000RubrosImagen_GXI[0];
               A121RubrosId = P00D03_A121RubrosId[0];
               A122RubrosNombre = P00D03_A122RubrosNombre[0];
               A168RubrosImagen = P00D03_A168RubrosImagen[0];
               new orubroitemactivo(context ).execute(  AV19ProveedorID,  A121RubrosId,  AV21MedidasID,  AV22InventarioId, out  AV10ok) ;
               if ( AV10ok )
               {
                  AV17RubrosId = A121RubrosId;
                  AV33ServiciosITEM.gxTpr_Serviciosid = A121RubrosId;
                  AV33ServiciosITEM.gxTpr_Serviciosnombre = StringUtil.Trim( A122RubrosNombre);
                  AV33ServiciosITEM.gxTpr_Imagen = A168RubrosImagen;
                  AV33ServiciosITEM.gxTpr_Imagen_gxi = A40000RubrosImagen_GXI;
                  /* Execute user subroutine: 'INTEGRO ITEMS DEL RUBRO' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     cleanup();
                     if (true) return;
                  }
                  AV32Servicios.Add(AV33ServiciosITEM, 0);
                  AV33ServiciosITEM = new SdtSDTServiciosAll_Item(context);
               }
               AV13ResMessage = context.GetMessage( "Success.", "");
               AV12ResCode = 0;
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         AV31Inventario = AV32Servicios.ToJSonString(false);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'INTEGRO ITEMS DEL RUBRO' Routine */
         returnInSub = false;
         /* Using cursor P00D04 */
         pr_default.execute(2, new Object[] {AV17RubrosId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A118MonedaId = P00D04_A118MonedaId[0];
            A119MonedaISOSimbolo = P00D04_A119MonedaISOSimbolo[0];
            A139MedidasEstado = P00D04_A139MedidasEstado[0];
            n139MedidasEstado = P00D04_n139MedidasEstado[0];
            A121RubrosId = P00D04_A121RubrosId[0];
            A137MedidasID = P00D04_A137MedidasID[0];
            A138MedidasNombre = P00D04_A138MedidasNombre[0];
            A150TextosId = P00D04_A150TextosId[0];
            n150TextosId = P00D04_n150TextosId[0];
            A119MonedaISOSimbolo = P00D04_A119MonedaISOSimbolo[0];
            new orubroitemactivo(context ).execute(  AV19ProveedorID,  A121RubrosId,  A137MedidasID,  AV22InventarioId, out  AV10ok) ;
            if ( AV10ok )
            {
               AV23MonedaId = A118MonedaId;
               AV21MedidasID = A137MedidasID;
               AV16Item.gxTpr_Productoid = A137MedidasID;
               AV16Item.gxTpr_Productonombre = StringUtil.Trim( A138MedidasNombre);
               AV16Item.gxTpr_Terminosid = A150TextosId;
               /* Using cursor P00D05 */
               pr_default.execute(3, new Object[] {AV17RubrosId, AV21MedidasID});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A108EstadosGenericosId = P00D05_A108EstadosGenericosId[0];
                  A107EstadosTipo = P00D05_A107EstadosTipo[0];
                  A137MedidasID = P00D05_A137MedidasID[0];
                  A121RubrosId = P00D05_A121RubrosId[0];
                  A40001InventarioImagen_GXI = P00D05_A40001InventarioImagen_GXI[0];
                  A135InventarioId = P00D05_A135InventarioId[0];
                  A136InventarioNombre = P00D05_A136InventarioNombre[0];
                  A181InventarioPrecioFinal = P00D05_A181InventarioPrecioFinal[0];
                  A535InventarioTextosId = P00D05_A535InventarioTextosId[0];
                  n535InventarioTextosId = P00D05_n535InventarioTextosId[0];
                  A189InventarioImagen = P00D05_A189InventarioImagen[0];
                  if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "INV", "")) == 0 )
                  {
                     new orubroitemactivo(context ).execute(  AV19ProveedorID,  A121RubrosId,  A137MedidasID,  A135InventarioId, out  AV10ok) ;
                     if ( AV10ok )
                     {
                        AV22InventarioId = A135InventarioId;
                        AV18ItemDet.gxTpr_Detalleid = A135InventarioId;
                        AV18ItemDet.gxTpr_Detallenombre = StringUtil.Trim( A136InventarioNombre);
                        AV18ItemDet.gxTpr_Imagen = A189InventarioImagen;
                        AV18ItemDet.gxTpr_Imagen_gxi = A40001InventarioImagen_GXI;
                        AV18ItemDet.gxTpr_Monedaid = A118MonedaId;
                        AV18ItemDet.gxTpr_Monedaiso = A119MonedaISOSimbolo;
                        new oprecprov(context ).execute(  AV19ProveedorID,  AV17RubrosId,  AV21MedidasID,  AV22InventarioId,  AV23MonedaId, out  AV24SolicitudItemsComision, out  AV25SolicitudItemsSR, out  AV26SolicitudItemsComisionTipo, out  AV39PrecioFinal, out  AV38Freezar) ;
                        AV37InventarioPrecioFinal = ((AV38Freezar) ? AV39PrecioFinal : A181InventarioPrecioFinal);
                        if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25SolicitudItemsSR)) || ( StringUtil.StrCmp(AV26SolicitudItemsComisionTipo, context.GetMessage( "N", "")) == 0 ) )
                        {
                           AV36Precio = AV37InventarioPrecioFinal;
                        }
                        if ( ( StringUtil.StrCmp(AV26SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(AV25SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
                        {
                           AV36Precio = (decimal)((AV37InventarioPrecioFinal)-(AV24SolicitudItemsComision));
                        }
                        if ( ( StringUtil.StrCmp(AV26SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(AV25SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
                        {
                           AV36Precio = (decimal)((AV37InventarioPrecioFinal)+(AV24SolicitudItemsComision));
                        }
                        if ( ( StringUtil.StrCmp(AV26SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(AV25SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
                        {
                           AV36Precio = (decimal)((AV37InventarioPrecioFinal)-((AV37InventarioPrecioFinal)*(AV24SolicitudItemsComision/ (decimal)(100))));
                        }
                        if ( ( StringUtil.StrCmp(AV26SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(AV25SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
                        {
                           AV36Precio = (decimal)((AV37InventarioPrecioFinal)+((AV37InventarioPrecioFinal)*(AV24SolicitudItemsComision/ (decimal)(100))));
                        }
                        AV18ItemDet.gxTpr_Preciofinal = AV36Precio;
                        AV18ItemDet.gxTpr_Precio = AV37InventarioPrecioFinal;
                        AV18ItemDet.gxTpr_Sr = AV25SolicitudItemsSR;
                        AV18ItemDet.gxTpr_Comision = AV24SolicitudItemsComision;
                        AV18ItemDet.gxTpr_Tipocomision = AV26SolicitudItemsComisionTipo;
                        AV18ItemDet.gxTpr_Terminosid = A535InventarioTextosId;
                        AV16Item.gxTpr_Detalles.Add(AV18ItemDet, 0);
                        AV18ItemDet = new SdtSDTServiciosAll_Item_ProductoItem_DetallesItem(context);
                     }
                  }
                  pr_default.readNext(3);
               }
               pr_default.close(3);
               AV33ServiciosITEM.gxTpr_Producto.Add(AV16Item, 0);
               AV16Item = new SdtSDTServiciosAll_Item_ProductoItem(context);
            }
            pr_default.readNext(2);
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
         AV20ProvedorOK = "";
         P00D02_A344ProveedorEstado = new string[] {""} ;
         P00D02_A133ProveedorID = new long[1] ;
         A344ProveedorEstado = "";
         P00D03_A123RubrosEstado = new string[] {""} ;
         P00D03_n123RubrosEstado = new bool[] {false} ;
         P00D03_A40000RubrosImagen_GXI = new string[] {""} ;
         P00D03_A121RubrosId = new short[1] ;
         P00D03_A122RubrosNombre = new string[] {""} ;
         P00D03_A168RubrosImagen = new string[] {""} ;
         A123RubrosEstado = "";
         A40000RubrosImagen_GXI = "";
         A122RubrosNombre = "";
         A168RubrosImagen = "";
         AV33ServiciosITEM = new SdtSDTServiciosAll_Item(context);
         AV32Servicios = new GXBaseCollection<SdtSDTServiciosAll_Item>( context, "Item", "AlmangoX");
         P00D04_A118MonedaId = new short[1] ;
         P00D04_A119MonedaISOSimbolo = new string[] {""} ;
         P00D04_A139MedidasEstado = new string[] {""} ;
         P00D04_n139MedidasEstado = new bool[] {false} ;
         P00D04_A121RubrosId = new short[1] ;
         P00D04_A137MedidasID = new long[1] ;
         P00D04_A138MedidasNombre = new string[] {""} ;
         P00D04_A150TextosId = new long[1] ;
         P00D04_n150TextosId = new bool[] {false} ;
         A119MonedaISOSimbolo = "";
         A139MedidasEstado = "";
         A138MedidasNombre = "";
         AV16Item = new SdtSDTServiciosAll_Item_ProductoItem(context);
         P00D05_A108EstadosGenericosId = new int[1] ;
         P00D05_A107EstadosTipo = new string[] {""} ;
         P00D05_A137MedidasID = new long[1] ;
         P00D05_A121RubrosId = new short[1] ;
         P00D05_A40001InventarioImagen_GXI = new string[] {""} ;
         P00D05_A135InventarioId = new long[1] ;
         P00D05_A136InventarioNombre = new string[] {""} ;
         P00D05_A181InventarioPrecioFinal = new decimal[1] ;
         P00D05_A535InventarioTextosId = new long[1] ;
         P00D05_n535InventarioTextosId = new bool[] {false} ;
         P00D05_A189InventarioImagen = new string[] {""} ;
         A107EstadosTipo = "";
         A40001InventarioImagen_GXI = "";
         A136InventarioNombre = "";
         A189InventarioImagen = "";
         AV18ItemDet = new SdtSDTServiciosAll_Item_ProductoItem_DetallesItem(context);
         AV25SolicitudItemsSR = "";
         AV26SolicitudItemsComisionTipo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.awsoserviciosdetall__default(),
            new Object[][] {
                new Object[] {
               P00D02_A344ProveedorEstado, P00D02_A133ProveedorID
               }
               , new Object[] {
               P00D03_A123RubrosEstado, P00D03_n123RubrosEstado, P00D03_A40000RubrosImagen_GXI, P00D03_A121RubrosId, P00D03_A122RubrosNombre, P00D03_A168RubrosImagen
               }
               , new Object[] {
               P00D04_A118MonedaId, P00D04_A119MonedaISOSimbolo, P00D04_A139MedidasEstado, P00D04_n139MedidasEstado, P00D04_A121RubrosId, P00D04_A137MedidasID, P00D04_A138MedidasNombre, P00D04_A150TextosId, P00D04_n150TextosId
               }
               , new Object[] {
               P00D05_A108EstadosGenericosId, P00D05_A107EstadosTipo, P00D05_A137MedidasID, P00D05_A121RubrosId, P00D05_A40001InventarioImagen_GXI, P00D05_A135InventarioId, P00D05_A136InventarioNombre, P00D05_A181InventarioPrecioFinal, P00D05_A535InventarioTextosId, P00D05_n535InventarioTextosId,
               P00D05_A189InventarioImagen
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
      private short AV17RubrosId ;
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
      private decimal AV39PrecioFinal ;
      private decimal AV37InventarioPrecioFinal ;
      private decimal AV36Precio ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private string AV14UserConect ;
      private string AV9Key ;
      private string AV13ResMessage ;
      private string AV20ProvedorOK ;
      private string A344ProveedorEstado ;
      private string A123RubrosEstado ;
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
      private bool n123RubrosEstado ;
      private bool returnInSub ;
      private bool n139MedidasEstado ;
      private bool n150TextosId ;
      private bool n535InventarioTextosId ;
      private bool AV38Freezar ;
      private string AV31Inventario ;
      private string A40000RubrosImagen_GXI ;
      private string A40001InventarioImagen_GXI ;
      private string A168RubrosImagen ;
      private string A189InventarioImagen ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00D02_A344ProveedorEstado ;
      private long[] P00D02_A133ProveedorID ;
      private string[] P00D03_A123RubrosEstado ;
      private bool[] P00D03_n123RubrosEstado ;
      private string[] P00D03_A40000RubrosImagen_GXI ;
      private short[] P00D03_A121RubrosId ;
      private string[] P00D03_A122RubrosNombre ;
      private string[] P00D03_A168RubrosImagen ;
      private SdtSDTServiciosAll_Item AV33ServiciosITEM ;
      private GXBaseCollection<SdtSDTServiciosAll_Item> AV32Servicios ;
      private short[] P00D04_A118MonedaId ;
      private string[] P00D04_A119MonedaISOSimbolo ;
      private string[] P00D04_A139MedidasEstado ;
      private bool[] P00D04_n139MedidasEstado ;
      private short[] P00D04_A121RubrosId ;
      private long[] P00D04_A137MedidasID ;
      private string[] P00D04_A138MedidasNombre ;
      private long[] P00D04_A150TextosId ;
      private bool[] P00D04_n150TextosId ;
      private SdtSDTServiciosAll_Item_ProductoItem AV16Item ;
      private int[] P00D05_A108EstadosGenericosId ;
      private string[] P00D05_A107EstadosTipo ;
      private long[] P00D05_A137MedidasID ;
      private short[] P00D05_A121RubrosId ;
      private string[] P00D05_A40001InventarioImagen_GXI ;
      private long[] P00D05_A135InventarioId ;
      private string[] P00D05_A136InventarioNombre ;
      private decimal[] P00D05_A181InventarioPrecioFinal ;
      private long[] P00D05_A535InventarioTextosId ;
      private bool[] P00D05_n535InventarioTextosId ;
      private string[] P00D05_A189InventarioImagen ;
      private SdtSDTServiciosAll_Item_ProductoItem_DetallesItem AV18ItemDet ;
      private int aP3_ResCode ;
      private string aP4_ResMessage ;
      private string aP5_Inventario ;
   }

   public class awsoserviciosdetall__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00D02;
          prmP00D02 = new Object[] {
          new ParDef("@AV19ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00D03;
          prmP00D03 = new Object[] {
          };
          Object[] prmP00D04;
          prmP00D04 = new Object[] {
          new ParDef("@AV17RubrosId",GXType.Int16,4,0)
          };
          Object[] prmP00D05;
          prmP00D05 = new Object[] {
          new ParDef("@AV17RubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV21MedidasID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D02", "SELECT [ProveedorEstado], [ProveedorID] FROM [Proveedor] WHERE [ProveedorID] = @AV19ProveedorID ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D02,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00D03", "SELECT [RubrosEstado], [RubrosImagen_GXI], [RubrosId], [RubrosNombre], [RubrosImagen] FROM [Rubros] WHERE [RubrosEstado] = 'HAB' ORDER BY [RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D03,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D04", "SELECT T1.[MonedaId], T2.[MonedaISOSimbolo], T1.[MedidasEstado], T1.[RubrosId], T1.[MedidasID], T1.[MedidasNombre], T1.[TextosId] FROM ([RubrosMedidas] T1 INNER JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId]) WHERE (T1.[RubrosId] = @AV17RubrosId) AND (T1.[MedidasEstado] = 'HAB') ORDER BY T1.[RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D04,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D05", "SELECT [EstadosGenericosId], [EstadosTipo], [MedidasID], [RubrosId], [InventarioImagen_GXI], [InventarioId], [InventarioNombre], [InventarioPrecioFinal], [InventarioTextosId], [InventarioImagen] FROM [Inventario] WHERE ([RubrosId] = @AV17RubrosId and [MedidasID] = @AV21MedidasID) AND ([EstadosGenericosId] = 1) ORDER BY [RubrosId], [MedidasID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D05,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 100);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(2));
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 50);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
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
