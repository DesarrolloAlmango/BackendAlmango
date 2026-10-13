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
   public class awsausuarios : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               GXSoapXMLWriter.WriteAttribute("name", "WSAUsuarios");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSAUsuarios.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "Nickname");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Password");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Tipousuario");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Comercio");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Profesional");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WSAUsuarios.ExecuteResponse");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSAUsuarios.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSAUsuarios.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WSAUsuarios.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WSAUsuarios.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "WSAUsuariosSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSAUsuarios.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WSAUsuarios.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "WSAUsuariosSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"WSAUsuariosSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "AlmangoXaction/"+"AWSAUSUARIOS.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "WSAUsuarios");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "WSAUsuariosSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"WSAUsuariosSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"awsausuarios.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "awsausuarios.aspx" + "?wsdl to get the WSDL.";
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
                                 AV47UserConect = GXSoapXMLReader.Value;
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
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Nickname") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV46NickName = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Password") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV14Password = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Tipousuario") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV8tipoUsuario = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Comercio") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV33Comercio = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Profesional") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                              {
                                 AV38Profesional = GXSoapXMLReader.Value;
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
            GXSoapXMLWriter.WriteStartElement("WSAUsuarios.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
            if ( currSoapErr == 0 )
            {
               GXSoapXMLWriter.WriteElement("Rescode", StringUtil.Trim( StringUtil.Str( (decimal)(AV25ResCode), 10, 0)));
               GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
               GXSoapXMLWriter.WriteElement("Resmessage", AV10ResMessage);
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

      public awsausuarios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awsausuarios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserConect ,
                           string aP1_Key ,
                           string aP2_NickName ,
                           string aP3_Password ,
                           string aP4_tipoUsuario ,
                           string aP5_Comercio ,
                           string aP6_Profesional ,
                           out long aP7_ResCode ,
                           out string aP8_ResMessage )
      {
         this.AV47UserConect = aP0_UserConect;
         this.AV9Key = aP1_Key;
         this.AV46NickName = aP2_NickName;
         this.AV14Password = aP3_Password;
         this.AV8tipoUsuario = aP4_tipoUsuario;
         this.AV33Comercio = aP5_Comercio;
         this.AV38Profesional = aP6_Profesional;
         this.AV25ResCode = 0 ;
         this.AV10ResMessage = "" ;
         initialize();
         ExecutePrivate();
         aP7_ResCode=this.AV25ResCode;
         aP8_ResMessage=this.AV10ResMessage;
      }

      public string executeUdp( string aP0_UserConect ,
                                string aP1_Key ,
                                string aP2_NickName ,
                                string aP3_Password ,
                                string aP4_tipoUsuario ,
                                string aP5_Comercio ,
                                string aP6_Profesional ,
                                out long aP7_ResCode )
      {
         execute(aP0_UserConect, aP1_Key, aP2_NickName, aP3_Password, aP4_tipoUsuario, aP5_Comercio, aP6_Profesional, out aP7_ResCode, out aP8_ResMessage);
         return AV10ResMessage ;
      }

      public void executeSubmit( string aP0_UserConect ,
                                 string aP1_Key ,
                                 string aP2_NickName ,
                                 string aP3_Password ,
                                 string aP4_tipoUsuario ,
                                 string aP5_Comercio ,
                                 string aP6_Profesional ,
                                 out long aP7_ResCode ,
                                 out string aP8_ResMessage )
      {
         this.AV47UserConect = aP0_UserConect;
         this.AV9Key = aP1_Key;
         this.AV46NickName = aP2_NickName;
         this.AV14Password = aP3_Password;
         this.AV8tipoUsuario = aP4_tipoUsuario;
         this.AV33Comercio = aP5_Comercio;
         this.AV38Profesional = aP6_Profesional;
         this.AV25ResCode = 0 ;
         this.AV10ResMessage = "" ;
         SubmitImpl();
         aP7_ResCode=this.AV25ResCode;
         aP8_ResMessage=this.AV10ResMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11ok = context.GetMessage( "N", "");
         AV17User = StringUtil.Trim( AV46NickName);
         /* Execute user subroutine: 'CREAR DEBUG' */
         S171 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47UserConect)) )
         {
            AV10ResMessage = context.GetMessage( "Usuario de conexion incorrecto", "");
            AV25ResCode = 102;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17User)) || ( StringUtil.Len( AV17User) < 5 ) )
         {
            AV10ResMessage = context.GetMessage( "Usuario incorrecto, el NickName debe contener más de 5 carácteres.", "");
            AV25ResCode = 102;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14Password)) || ( StringUtil.Len( AV14Password) < 5 ) )
         {
            AV10ResMessage = context.GetMessage( "Contraseña no valida, debe contener más de 5 carácteres.", "");
            AV25ResCode = 103;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9Key)) )
         {
            AV10ResMessage = context.GetMessage( "llave de acceso no valida.", "");
            AV25ResCode = 104;
         }
         else if ( StringUtil.StrCmp(AV9Key, context.GetMessage( "d3d3LmF6bWl0YS5jb20=", "")) != 0 )
         {
            AV10ResMessage = context.GetMessage( "llave de acceso no valida.", "");
            AV25ResCode = 105;
         }
         else
         {
            AV11ok = context.GetMessage( "S", "");
            /* Execute user subroutine: 'EVALUARUSUARIO' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'EVALUARUSUARIO' Routine */
         returnInSub = false;
         GXt_char1 = AV29ExisteUsr;
         new oexisteuser(context ).execute(  AV17User,  AV17User,  "U", out  GXt_char1) ;
         AV29ExisteUsr = GXt_char1;
         if ( StringUtil.StrCmp(AV29ExisteUsr, context.GetMessage( "S", "")) == 0 )
         {
            AV10ResMessage = context.GetMessage( "Ya existe un usuario con el mismo nickname.", "");
            AV25ResCode = 106;
         }
         else
         {
            GXt_char1 = AV29ExisteUsr;
            new oexisteuser(context ).execute(  AV17User,  AV40usuariosId,  "S", out  GXt_char1) ;
            AV29ExisteUsr = GXt_char1;
            if ( StringUtil.StrCmp(AV29ExisteUsr, context.GetMessage( "S", "")) == 0 )
            {
               AV10ResMessage = context.GetMessage( "Ya existe un registro asociado al mismo usuario.", "");
               AV25ResCode = 106;
            }
            else
            {
               /* Execute user subroutine: 'EVALUAR MAS DATOS' */
               S121 ();
               if (returnInSub) return;
            }
         }
      }

      protected void S121( )
      {
         /* 'EVALUAR MAS DATOS' Routine */
         returnInSub = false;
         AV44validacion = context.GetMessage( "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", "");
         if ( StringUtil.StrCmp(AV8tipoUsuario, "P") == 0 )
         {
            /* Execute user subroutine: 'COMERCIO' */
            S131 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV8tipoUsuario, "S") == 0 )
         {
            /* Execute user subroutine: 'PROFESIONAL' */
            S141 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV8tipoUsuario, "C") == 0 )
         {
            AV10ResMessage = context.GetMessage( "Registro de Clientes no implemtentado.", "");
            AV25ResCode = 107;
         }
         else
         {
            AV10ResMessage = context.GetMessage( "Registro de usuario no implemtentado.", "");
            AV25ResCode = 107;
         }
      }

      protected void S131( )
      {
         /* 'COMERCIO' Routine */
         returnInSub = false;
         AV32SDTProveedores.FromJSonString(AV33Comercio, null);
         AV35mail = AV32SDTProveedores.gxTpr_Email;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32SDTProveedores.gxTpr_Nombre)) )
         {
            AV10ResMessage = context.GetMessage( "El nombre del comercio no es valido.", "");
            AV25ResCode = 108;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32SDTProveedores.gxTpr_Docidentidad)) )
         {
            AV10ResMessage = context.GetMessage( "El documento de identidad o RUT del comercio no es valido.", "");
            AV25ResCode = 108;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32SDTProveedores.gxTpr_Telefono)) )
         {
            AV10ResMessage = context.GetMessage( "El número de teléfono no es valido.", "");
            AV25ResCode = 108;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32SDTProveedores.gxTpr_Direccion)) )
         {
            AV10ResMessage = context.GetMessage( "La dirección no es valida.", "");
            AV25ResCode = 108;
         }
         else if ( ! GxRegex.IsMatch(AV35mail,AV44validacion) )
         {
            AV10ResMessage = context.GetMessage( "Mail no valido.", "");
            AV25ResCode = 108;
         }
         else
         {
            AV36DocumentoIdentidad = AV32SDTProveedores.gxTpr_Docidentidad;
            /* Execute user subroutine: 'EVALUAR DOCIDENTIDAD' */
            S151 ();
            if (returnInSub) return;
         }
         if ( AV25ResCode == 0 )
         {
            new nuevousuario(context ).execute(  AV17User,  AV32SDTProveedores.gxTpr_Nombre,  AV14Password,  AV32SDTProveedores.gxTpr_Email,  AV8tipoUsuario,  AV32SDTProveedores.gxTpr_Paisiso2,  AV32SDTProveedores.gxTpr_Docidentidad,  AV37SDTProfesionales,  AV32SDTProveedores, out  AV42okNew) ;
            if ( StringUtil.StrCmp(AV11ok, context.GetMessage( "S", "")) == 0 )
            {
               new oparametros(context ).execute(  context.GetMessage( "URLPOLITICASCOM", ""), out  AV51ParametrosValor, out  AV52ParametrosNumerico, out  AV53ParametrosEstado) ;
               AV57URLPoliticas = StringUtil.Trim( AV51ParametrosValor);
               /* Execute user subroutine: 'ENVIAR NOTIFICACION' */
               S161 ();
               if (returnInSub) return;
               AV10ResMessage = context.GetMessage( "Success", "");
               AV25ResCode = 0;
            }
            else
            {
               AV25ResCode = 101;
            }
         }
      }

      protected void S141( )
      {
         /* 'PROFESIONAL' Routine */
         returnInSub = false;
         AV37SDTProfesionales.FromJSonString(AV38Profesional, null);
         AV35mail = AV37SDTProfesionales.gxTpr_Email;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37SDTProfesionales.gxTpr_Primernombre)) || String.IsNullOrEmpty(StringUtil.RTrim( AV37SDTProfesionales.gxTpr_Apellidoprimero)) )
         {
            AV10ResMessage = context.GetMessage( "El nombre del profesional no es valido.", "");
            AV25ResCode = 108;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37SDTProfesionales.gxTpr_Docidentidad)) )
         {
            AV10ResMessage = context.GetMessage( "El documento de identidad o RUT del profesional no es valido.", "");
            AV25ResCode = 108;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37SDTProfesionales.gxTpr_Telefono)) )
         {
            AV10ResMessage = context.GetMessage( "El número de teléfono no es valido.", "");
            AV25ResCode = 108;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37SDTProfesionales.gxTpr_Direccion)) )
         {
            AV10ResMessage = context.GetMessage( "La dirección no es valida.", "");
            AV25ResCode = 108;
         }
         else if ( ! GxRegex.IsMatch(AV35mail,AV44validacion) )
         {
            AV10ResMessage = context.GetMessage( "Mail no valido.", "");
            AV25ResCode = 108;
         }
         else
         {
            AV36DocumentoIdentidad = AV37SDTProfesionales.gxTpr_Docidentidad;
            /* Execute user subroutine: 'EVALUAR DOCIDENTIDAD' */
            S151 ();
            if (returnInSub) return;
         }
         if ( AV25ResCode == 0 )
         {
            AV43FullName = StringUtil.Format( "%1 %2 %3 %4", AV37SDTProfesionales.gxTpr_Primernombre, AV37SDTProfesionales.gxTpr_Segundonombre, AV37SDTProfesionales.gxTpr_Apellidoprimero, AV37SDTProfesionales.gxTpr_Apellidosegundo, "", "", "", "", "");
            new nuevousuario(context ).execute(  AV17User,  AV43FullName,  AV14Password,  AV37SDTProfesionales.gxTpr_Email,  AV8tipoUsuario,  AV37SDTProfesionales.gxTpr_Paisiso2,  AV37SDTProfesionales.gxTpr_Docidentidad,  AV37SDTProfesionales,  AV32SDTProveedores, out  AV42okNew) ;
            if ( StringUtil.StrCmp(AV11ok, context.GetMessage( "S", "")) == 0 )
            {
               new oparametros(context ).execute(  context.GetMessage( "URLPOLITICASPRF", ""), out  AV51ParametrosValor, out  AV52ParametrosNumerico, out  AV53ParametrosEstado) ;
               AV57URLPoliticas = StringUtil.Trim( AV51ParametrosValor);
               AV10ResMessage = context.GetMessage( "Susses", "");
               AV25ResCode = 0;
               /* Execute user subroutine: 'ENVIAR NOTIFICACION' */
               S161 ();
               if (returnInSub) return;
            }
            else
            {
               AV25ResCode = 101;
            }
         }
      }

      protected void S151( )
      {
         /* 'EVALUAR DOCIDENTIDAD' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV8tipoUsuario, "P") == 0 )
         {
            /* Using cursor P00BM2 */
            pr_default.execute(0, new Object[] {AV36DocumentoIdentidad});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A338ProveedorDocIdentidad = P00BM2_A338ProveedorDocIdentidad[0];
               A133ProveedorID = P00BM2_A133ProveedorID[0];
               AV10ResMessage = context.GetMessage( "Documento de Identidad ya fue registrado con anterioridad.", "");
               AV25ResCode = 108;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         if ( StringUtil.StrCmp(AV8tipoUsuario, "S") == 0 )
         {
            /* Using cursor P00BM3 */
            pr_default.execute(1, new Object[] {AV36DocumentoIdentidad});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A120ProfesionalesId = P00BM3_A120ProfesionalesId[0];
               AV10ResMessage = context.GetMessage( "Documento de Identidad ya fue registrado con anterioridad.", "");
               AV25ResCode = 108;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         if ( StringUtil.StrCmp(AV8tipoUsuario, "C") == 0 )
         {
            /* Using cursor P00BM4 */
            pr_default.execute(2, new Object[] {AV36DocumentoIdentidad});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A434ClientesIdentidad = P00BM4_A434ClientesIdentidad[0];
               A106ClientesId = P00BM4_A106ClientesId[0];
               AV10ResMessage = context.GetMessage( "Documento de Identidad ya fue registrado con anterioridad.", "");
               AV25ResCode = 108;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
      }

      protected void S161( )
      {
         /* 'ENVIAR NOTIFICACION' Routine */
         returnInSub = false;
         AV49SDTCNotificaciones = new SdtSDTCNotificaciones(context);
         if ( StringUtil.StrCmp(AV8tipoUsuario, "S") == 0 )
         {
            AV49SDTCNotificaciones.gxTpr_Nombreprofesional = StringUtil.Trim( AV43FullName);
            AV49SDTCNotificaciones.gxTpr_Emailprofesional = StringUtil.Trim( AV35mail);
         }
         else if ( StringUtil.StrCmp(AV8tipoUsuario, "P") == 0 )
         {
            AV49SDTCNotificaciones.gxTpr_Nombrecomercio = StringUtil.Trim( AV32SDTProveedores.gxTpr_Nombre);
            AV49SDTCNotificaciones.gxTpr_Emailcomercio = StringUtil.Trim( AV35mail);
         }
         AV49SDTCNotificaciones.gxTpr_Maildesignid = 6;
         AV49SDTCNotificaciones.gxTpr_Mensajefijo = StringUtil.Format( context.GetMessage( "USUARIO REGISTRADO: %1,  CONTRASEÑA: %2", ""), AV17User, AV14Password, "", "", "", "", "", "", "");
         AV49SDTCNotificaciones.gxTpr_Mensajeurl1 = context.GetMessage( "Enlace de inicio de sesión: www.app.almango.com.uy", "");
         new oparametros(context ).execute(  context.GetMessage( "URLINICIO", ""), out  AV51ParametrosValor, out  AV52ParametrosNumerico, out  AV53ParametrosEstado) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51ParametrosValor)) )
         {
            AV49SDTCNotificaciones.gxTpr_Urladjunto1 = context.GetMessage( "https://app.almango.com.uy/wwpbaseobjects.login.aspx", "");
         }
         else
         {
            AV49SDTCNotificaciones.gxTpr_Urladjunto1 = StringUtil.Trim( AV51ParametrosValor);
         }
         AV49SDTCNotificaciones.gxTpr_Mensajeurl2 = context.GetMessage( "Para consultar o descargar los términos y condiciones de uso de la plataforma, haga click aquí.", "");
         AV49SDTCNotificaciones.gxTpr_Urladjunto2 = StringUtil.Trim( AV57URLPoliticas);
         new oparametros(context ).execute(  context.GetMessage( "URLPOLITICAS", ""), out  AV51ParametrosValor, out  AV52ParametrosNumerico, out  AV53ParametrosEstado) ;
         AV49SDTCNotificaciones.gxTpr_Adjuntofile = StringUtil.Trim( "");
         new cnotificaciones(context ).execute(  AV49SDTCNotificaciones, out  AV11ok, out  AV48ErrorDescription) ;
      }

      protected void S171( )
      {
         /* 'CREAR DEBUG' Routine */
         returnInSub = false;
         AV54XML = StringUtil.Format( context.GetMessage( "&NickName: %1 &Password: %2 &TipoUsuario: %3 &Comercio: %4 &Profesional: %5 ", ""), AV46NickName, AV14Password, AV8tipoUsuario, AV33Comercio, AV38Profesional, "", "", "", "");
         new debug(context ).execute(  AV54XML) ;
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
         AV11ok = "";
         AV17User = "";
         AV29ExisteUsr = "";
         GXt_char1 = "";
         AV40usuariosId = "";
         AV44validacion = "";
         AV32SDTProveedores = new SdtSDTComercio(context);
         AV35mail = "";
         AV36DocumentoIdentidad = "";
         AV37SDTProfesionales = new SdtSDTProfesionales(context);
         AV42okNew = "";
         AV51ParametrosValor = "";
         AV53ParametrosEstado = "";
         AV57URLPoliticas = "";
         AV43FullName = "";
         P00BM2_A338ProveedorDocIdentidad = new string[] {""} ;
         P00BM2_A133ProveedorID = new long[1] ;
         A338ProveedorDocIdentidad = "";
         P00BM3_A120ProfesionalesId = new string[] {""} ;
         A120ProfesionalesId = "";
         P00BM4_A434ClientesIdentidad = new string[] {""} ;
         P00BM4_A106ClientesId = new long[1] ;
         A434ClientesIdentidad = "";
         AV49SDTCNotificaciones = new SdtSDTCNotificaciones(context);
         AV48ErrorDescription = "";
         AV54XML = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.awsausuarios__default(),
            new Object[][] {
                new Object[] {
               P00BM2_A338ProveedorDocIdentidad, P00BM2_A133ProveedorID
               }
               , new Object[] {
               P00BM3_A120ProfesionalesId
               }
               , new Object[] {
               P00BM4_A434ClientesIdentidad, P00BM4_A106ClientesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXSoapError ;
      private short currSoapErr ;
      private short readOk ;
      private short nOutParmCount ;
      private int AV52ParametrosNumerico ;
      private long AV25ResCode ;
      private long A133ProveedorID ;
      private long A106ClientesId ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private string AV47UserConect ;
      private string AV9Key ;
      private string AV46NickName ;
      private string AV14Password ;
      private string AV8tipoUsuario ;
      private string AV10ResMessage ;
      private string AV11ok ;
      private string AV17User ;
      private string AV29ExisteUsr ;
      private string GXt_char1 ;
      private string AV40usuariosId ;
      private string AV44validacion ;
      private string AV36DocumentoIdentidad ;
      private string AV42okNew ;
      private string AV53ParametrosEstado ;
      private string AV57URLPoliticas ;
      private string AV43FullName ;
      private string A338ProveedorDocIdentidad ;
      private string A120ProfesionalesId ;
      private string A434ClientesIdentidad ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private bool returnInSub ;
      private string AV33Comercio ;
      private string AV38Profesional ;
      private string AV54XML ;
      private string AV35mail ;
      private string AV51ParametrosValor ;
      private string AV48ErrorDescription ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTComercio AV32SDTProveedores ;
      private SdtSDTProfesionales AV37SDTProfesionales ;
      private IDataStoreProvider pr_default ;
      private string[] P00BM2_A338ProveedorDocIdentidad ;
      private long[] P00BM2_A133ProveedorID ;
      private string[] P00BM3_A120ProfesionalesId ;
      private string[] P00BM4_A434ClientesIdentidad ;
      private long[] P00BM4_A106ClientesId ;
      private SdtSDTCNotificaciones AV49SDTCNotificaciones ;
      private long aP7_ResCode ;
      private string aP8_ResMessage ;
   }

   public class awsausuarios__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BM2;
          prmP00BM2 = new Object[] {
          new ParDef("@AV36DocumentoIdentidad",GXType.NChar,25,0)
          };
          Object[] prmP00BM3;
          prmP00BM3 = new Object[] {
          new ParDef("@AV36DocumentoIdentidad",GXType.Char,25,0)
          };
          Object[] prmP00BM4;
          prmP00BM4 = new Object[] {
          new ParDef("@AV36DocumentoIdentidad",GXType.NChar,25,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BM2", "SELECT TOP 1 [ProveedorDocIdentidad], [ProveedorID] FROM [Proveedor] WHERE RTRIM(LTRIM([ProveedorDocIdentidad])) = RTRIM(LTRIM(@AV36DocumentoIdentidad)) ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BM2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BM3", "SELECT TOP 1 [ProfesionalesId] FROM [Profesionales] WHERE RTRIM(LTRIM([ProfesionalesId])) = RTRIM(LTRIM(@AV36DocumentoIdentidad)) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BM3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BM4", "SELECT TOP 1 [ClientesIdentidad], [ClientesId] FROM [Clientes] WHERE RTRIM(LTRIM([ClientesIdentidad])) = RTRIM(LTRIM(@AV36DocumentoIdentidad)) ORDER BY [ClientesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BM4,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
