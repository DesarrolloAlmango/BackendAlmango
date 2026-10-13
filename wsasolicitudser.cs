using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using System.Web.Services;
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
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wsasolicitudser : GXProcedure
   {
      public wsasolicitudser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public wsasolicitudser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserConect ,
                           string aP1_Key ,
                           long aP2_ProveedorID ,
                           string aP3_UsuarioID ,
                           string aP4_XMLSolicitud ,
                           out int aP5_ResCode ,
                           out string aP6_ResMessage ,
                           out long aP7_SolicitudesID )
      {
         this.AV2UserConect = aP0_UserConect;
         this.AV3Key = aP1_Key;
         this.AV4ProveedorID = aP2_ProveedorID;
         this.AV5UsuarioID = aP3_UsuarioID;
         this.AV6XMLSolicitud = aP4_XMLSolicitud;
         this.AV7ResCode = 0 ;
         this.AV8ResMessage = "" ;
         this.AV9SolicitudesID = 0 ;
         initialize();
         ExecutePrivate();
         aP5_ResCode=this.AV7ResCode;
         aP6_ResMessage=this.AV8ResMessage;
         aP7_SolicitudesID=this.AV9SolicitudesID;
      }

      public long executeUdp( string aP0_UserConect ,
                              string aP1_Key ,
                              long aP2_ProveedorID ,
                              string aP3_UsuarioID ,
                              string aP4_XMLSolicitud ,
                              out int aP5_ResCode ,
                              out string aP6_ResMessage )
      {
         execute(aP0_UserConect, aP1_Key, aP2_ProveedorID, aP3_UsuarioID, aP4_XMLSolicitud, out aP5_ResCode, out aP6_ResMessage, out aP7_SolicitudesID);
         return AV9SolicitudesID ;
      }

      public void executeSubmit( string aP0_UserConect ,
                                 string aP1_Key ,
                                 long aP2_ProveedorID ,
                                 string aP3_UsuarioID ,
                                 string aP4_XMLSolicitud ,
                                 out int aP5_ResCode ,
                                 out string aP6_ResMessage ,
                                 out long aP7_SolicitudesID )
      {
         this.AV2UserConect = aP0_UserConect;
         this.AV3Key = aP1_Key;
         this.AV4ProveedorID = aP2_ProveedorID;
         this.AV5UsuarioID = aP3_UsuarioID;
         this.AV6XMLSolicitud = aP4_XMLSolicitud;
         this.AV7ResCode = 0 ;
         this.AV8ResMessage = "" ;
         this.AV9SolicitudesID = 0 ;
         SubmitImpl();
         aP5_ResCode=this.AV7ResCode;
         aP6_ResMessage=this.AV8ResMessage;
         aP7_SolicitudesID=this.AV9SolicitudesID;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         context.nSOAPErr = 0;
         context.sSOAPErrMsg = "";
         GXSoapHTTPClient.Host = context.GetServerName( );
         GXSoapHTTPClient.Port = context.GetServerPort( );
         GXSoapHTTPClient.BaseURL = context.GetScriptPath( );
         SoapParm.AssignLocationProperties( context, "AWSAsolicitudSer", GXSoapHTTPClient);
         GXSoapHTTPClient.AddHeader("Content-type", "text/xml;charset=utf-8");
         GXSoapHTTPClient.AddHeader("SOAPAction", "AlmangoXaction/"+"AWSASOLICITUDSER.Execute");
         GXSoapXMLWriter.OpenRequest(GXSoapHTTPClient);
         GXSoapXMLWriter.WriteStartDocument("utf-8", 0);
         GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Envelope");
         GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENV", "http://schemas.xmlsoap.org/soap/envelope/");
         GXSoapXMLWriter.WriteAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
         GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENC", "http://schemas.xmlsoap.org/soap/encoding/");
         GXSoapXMLWriter.WriteAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
         GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Body");
         GXSoapXMLWriter.WriteStartElement("Execute");
         GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
         GXSoapXMLWriter.WriteElement("Userconect", AV2UserConect);
         GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
         GXSoapXMLWriter.WriteElement("Key", AV3Key);
         GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
         GXSoapXMLWriter.WriteElement("Proveedorid", StringUtil.Trim( StringUtil.Str( (decimal)(AV4ProveedorID), 18, 0)));
         GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
         GXSoapXMLWriter.WriteElement("Usuarioid", AV5UsuarioID);
         GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
         GXSoapXMLWriter.WriteElement("Xmlsolicitud", AV6XMLSolicitud);
         GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.Close();
         GXSoapHTTPClient.Execute("POST", "awsasolicitudser.aspx");
         if ( GXSoapHTTPClient.ErrCode != 0 )
         {
            currSoapErr = (short)(GXSoapHTTPClient.ErrCode*-1-10000);
            currSoapErrmsg = GXSoapHTTPClient.ErrDescription;
         }
         GXSoapXMLReader.OpenResponse(GXSoapHTTPClient);
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
            this.SetPrefixesFromReader( GXSoapXMLReader);
            if ( ( GXSoapError > 0 ) && ( StringUtil.StrCmp(GXSoapXMLReader.LocalName, "Fault") == 0 ) )
            {
               soapFault = 1;
            }
         }
         formatError = false;
         sTagName = GXSoapXMLReader.Name;
         if ( GXSoapXMLReader.IsSimple == 0 )
         {
            if ( soapFault == 0 )
            {
               GXSoapError = GXSoapXMLReader.Read();
               if ( ( GXSoapError > 0 ) && ( StringUtil.StrCmp(GXSoapXMLReader.LocalName, "Fault") == 0 ) )
               {
                  soapFault = 1;
               }
            }
            if ( soapFault == 1 )
            {
               GXSoapXMLReader.Read();
               while ( ! ( ( StringUtil.StrCmp(GXSoapXMLReader.LocalName, "Fault") == 0 ) && ( GXSoapXMLReader.NodeType == 2 ) ) )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapXMLReader.Name), "faultcode") == 0 )
                  {
                     sFaultCode = GXSoapXMLReader.Value;
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapXMLReader.Name), "faultstring") == 0 )
                  {
                     sFaultString = GXSoapXMLReader.Value;
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapXMLReader.Name), "detail") == 0 )
                  {
                     if ( GXSoapXMLReader.IsSimple == 0 )
                     {
                        GXSoapXMLReader.Read();
                        sDetail = GXSoapXMLReader.ReadRawXML();
                     }
                     else
                     {
                        sDetail = GXSoapXMLReader.Value;
                     }
                  }
                  if ( ! ( ( StringUtil.StrCmp(GXSoapXMLReader.LocalName, "Fault") == 0 ) && ( GXSoapXMLReader.NodeType == 2 ) ) )
                  {
                     GXSoapError = GXSoapXMLReader.Read();
                     if ( GXSoapError == 0 )
                     {
                        if (true) break;
                     }
                  }
               }
               if ( StringUtil.StringSearch( StringUtil.Lower( sFaultCode), "client", 1) > 0 )
               {
                  currSoapErr = (short)(-20004);
                  currSoapErrmsg += "SOAP Fault: Error in client request." + StringUtil.NewLine( ) + "Message: " + sFaultString + StringUtil.NewLine( ) + "Detail: " + sDetail;
               }
               else if ( StringUtil.StringSearch( StringUtil.Lower( sFaultCode), "server", 1) > 0 )
               {
                  currSoapErr = (short)(-20005);
                  currSoapErrmsg += "SOAP Fault: Error in server execution." + StringUtil.NewLine( ) + "Message: " + sFaultString + StringUtil.NewLine( ) + "Detail: " + sDetail;
               }
               else
               {
                  currSoapErr = (short)(-20006);
                  currSoapErrmsg += "Unknown error: " + sFaultCode + StringUtil.NewLine( ) + "Message: " + sFaultString + StringUtil.NewLine( ) + "Detail: " + sDetail;
               }
            }
            else
            {
               nOutParmCount = 0;
               while ( ( ( StringUtil.StrCmp(GXSoapXMLReader.Name, sTagName) != 0 ) || ( GXSoapXMLReader.NodeType == 1 ) ) && ( GXSoapError > 0 ) )
               {
                  readOk = 0;
                  readElement = false;
                  this.SetNamedPrefixesFromReader( GXSoapXMLReader);
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Rescode") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     AV7ResCode = (int)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Resmessage") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     AV8ResMessage = GXSoapXMLReader.Value;
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Solicitudesid") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     AV9SolicitudesID = (long)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
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
         GXSoapXMLReader.Close();
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
         if ( currSoapErr != 0 )
         {
            oLocation = SoapParm.getlocation( context, "AWSAsolicitudSer");
            if ( oLocation.CancelOnError == 1 )
            {
               throw new Exception( currSoapErrmsg+"("+StringUtil.LTrim( StringUtil.NToC( (decimal)(currSoapErr), 6, 0, ".", ""))+")") ;
            }
         }
         context.nSOAPErr = currSoapErr;
         context.sSOAPErrMsg = currSoapErrmsg;
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      public override void initialize( )
      {
         AV8ResMessage = "";
         GXSoapHTTPClient = new GxHttpClient( context);
         sReturn = "";
         GXSoapXMLReader = new GXXMLReader(context.GetPhysicalPath());
         GXSoapXMLWriter = new GXXMLWriter(context.GetPhysicalPath());
         currSoapErrmsg = "";
         sTagName = "";
         sFaultCode = "";
         sFaultString = "";
         sDetail = "";
         oLocation = new GxLocation();
         /* GeneXus formulas. */
      }

      private short GXSoapError ;
      private short currSoapErr ;
      private short soapFault ;
      private short readOk ;
      private short nOutParmCount ;
      private int AV7ResCode ;
      private long AV4ProveedorID ;
      private long AV9SolicitudesID ;
      private string AV2UserConect ;
      private string AV3Key ;
      private string AV5UsuarioID ;
      private string AV6XMLSolicitud ;
      private string AV8ResMessage ;
      private string sReturn ;
      private string currSoapErrmsg ;
      private string sTagName ;
      private string sFaultCode ;
      private string sFaultString ;
      private string sDetail ;
      private bool readElement ;
      private bool formatError ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxHttpClient GXSoapHTTPClient ;
      private GxLocation oLocation ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private int aP5_ResCode ;
      private string aP6_ResMessage ;
      private long aP7_SolicitudesID ;
   }

}
