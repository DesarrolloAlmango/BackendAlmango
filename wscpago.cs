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
   public class wscpago : GXProcedure
   {
      public wscpago( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public wscpago( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Key ,
                           string aP1_User ,
                           long aP2_SolicitudesID ,
                           string aP3_TipoMov ,
                           out long aP4_ResCode ,
                           out string aP5_ResMessage )
      {
         this.AV2Key = aP0_Key;
         this.AV3User = aP1_User;
         this.AV4SolicitudesID = aP2_SolicitudesID;
         this.AV5TipoMov = aP3_TipoMov;
         this.AV6ResCode = 0 ;
         this.AV7ResMessage = "" ;
         initialize();
         ExecutePrivate();
         aP4_ResCode=this.AV6ResCode;
         aP5_ResMessage=this.AV7ResMessage;
      }

      public string executeUdp( string aP0_Key ,
                                string aP1_User ,
                                long aP2_SolicitudesID ,
                                string aP3_TipoMov ,
                                out long aP4_ResCode )
      {
         execute(aP0_Key, aP1_User, aP2_SolicitudesID, aP3_TipoMov, out aP4_ResCode, out aP5_ResMessage);
         return AV7ResMessage ;
      }

      public void executeSubmit( string aP0_Key ,
                                 string aP1_User ,
                                 long aP2_SolicitudesID ,
                                 string aP3_TipoMov ,
                                 out long aP4_ResCode ,
                                 out string aP5_ResMessage )
      {
         this.AV2Key = aP0_Key;
         this.AV3User = aP1_User;
         this.AV4SolicitudesID = aP2_SolicitudesID;
         this.AV5TipoMov = aP3_TipoMov;
         this.AV6ResCode = 0 ;
         this.AV7ResMessage = "" ;
         SubmitImpl();
         aP4_ResCode=this.AV6ResCode;
         aP5_ResMessage=this.AV7ResMessage;
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
         SoapParm.AssignLocationProperties( context, "AWSCPago", GXSoapHTTPClient);
         GXSoapHTTPClient.AddHeader("Content-type", "text/xml;charset=utf-8");
         GXSoapHTTPClient.AddHeader("SOAPAction", "AlmangoXaction/"+"AWSCPAGO.Execute");
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
         GXSoapXMLWriter.WriteElement("Key", AV2Key);
         GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
         GXSoapXMLWriter.WriteElement("User", AV3User);
         GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
         GXSoapXMLWriter.WriteElement("Solicitudesid", StringUtil.Trim( StringUtil.Str( (decimal)(AV4SolicitudesID), 18, 0)));
         GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
         GXSoapXMLWriter.WriteElement("Tipomov", AV5TipoMov);
         GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.Close();
         GXSoapHTTPClient.Execute("POST", "awscpago.aspx");
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
                     AV6ResCode = (long)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Resmessage") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     AV7ResMessage = GXSoapXMLReader.Value;
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
            oLocation = SoapParm.getlocation( context, "AWSCPago");
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
         AV7ResMessage = "";
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
      private long AV4SolicitudesID ;
      private long AV6ResCode ;
      private string AV2Key ;
      private string AV3User ;
      private string AV5TipoMov ;
      private string AV7ResMessage ;
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
      private long aP4_ResCode ;
      private string aP5_ResMessage ;
   }

}
