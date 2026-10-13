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
   public class wsoserviciosdet : GXProcedure
   {
      public wsoserviciosdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public wsoserviciosdet( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserConect ,
                           string aP1_Key ,
                           short aP2_RubrosId ,
                           long aP3_ProveedorID ,
                           out int aP4_ResCode ,
                           out string aP5_ResMessage ,
                           out SdtSDTServicioDetalle aP6_SDTServicios )
      {
         this.AV2UserConect = aP0_UserConect;
         this.AV3Key = aP1_Key;
         this.AV4RubrosId = aP2_RubrosId;
         this.AV5ProveedorID = aP3_ProveedorID;
         this.AV6ResCode = 0 ;
         this.AV7ResMessage = "" ;
         this.AV8SDTServicios = new SdtSDTServicioDetalle(context) ;
         initialize();
         ExecutePrivate();
         aP4_ResCode=this.AV6ResCode;
         aP5_ResMessage=this.AV7ResMessage;
         aP6_SDTServicios=this.AV8SDTServicios;
      }

      public SdtSDTServicioDetalle executeUdp( string aP0_UserConect ,
                                               string aP1_Key ,
                                               short aP2_RubrosId ,
                                               long aP3_ProveedorID ,
                                               out int aP4_ResCode ,
                                               out string aP5_ResMessage )
      {
         execute(aP0_UserConect, aP1_Key, aP2_RubrosId, aP3_ProveedorID, out aP4_ResCode, out aP5_ResMessage, out aP6_SDTServicios);
         return AV8SDTServicios ;
      }

      public void executeSubmit( string aP0_UserConect ,
                                 string aP1_Key ,
                                 short aP2_RubrosId ,
                                 long aP3_ProveedorID ,
                                 out int aP4_ResCode ,
                                 out string aP5_ResMessage ,
                                 out SdtSDTServicioDetalle aP6_SDTServicios )
      {
         this.AV2UserConect = aP0_UserConect;
         this.AV3Key = aP1_Key;
         this.AV4RubrosId = aP2_RubrosId;
         this.AV5ProveedorID = aP3_ProveedorID;
         this.AV6ResCode = 0 ;
         this.AV7ResMessage = "" ;
         this.AV8SDTServicios = new SdtSDTServicioDetalle(context) ;
         SubmitImpl();
         aP4_ResCode=this.AV6ResCode;
         aP5_ResMessage=this.AV7ResMessage;
         aP6_SDTServicios=this.AV8SDTServicios;
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
         SoapParm.AssignLocationProperties( context, "AWSOServiciosDet", GXSoapHTTPClient);
         GXSoapHTTPClient.AddHeader("Content-type", "text/xml;charset=utf-8");
         GXSoapHTTPClient.AddHeader("SOAPAction", "AlmangoXaction/"+"AWSOSERVICIOSDET.Execute");
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
         GXSoapXMLWriter.WriteElement("Rubrosid", StringUtil.Trim( StringUtil.Str( (decimal)(AV4RubrosId), 4, 0)));
         GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
         GXSoapXMLWriter.WriteElement("Proveedorid", StringUtil.Trim( StringUtil.Str( (decimal)(AV5ProveedorID), 18, 0)));
         GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.Close();
         GXSoapHTTPClient.Execute("POST", "awsoserviciosdet.aspx");
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
                     AV6ResCode = (int)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
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
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Sdtservicios") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     if ( AV8SDTServicios == null )
                     {
                        AV8SDTServicios = new SdtSDTServicioDetalle(context);
                     }
                     AV8SDTServicios.SetPrefixes( GetPrefixesInContext(), GXSoapXMLReader);
                     GXSoapError = AV8SDTServicios.readxml(GXSoapXMLReader, "Sdtservicios");
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
            oLocation = SoapParm.getlocation( context, "AWSOServiciosDet");
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
         AV8SDTServicios = new SdtSDTServicioDetalle(context);
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

      private short AV4RubrosId ;
      private short GXSoapError ;
      private short currSoapErr ;
      private short soapFault ;
      private short readOk ;
      private short nOutParmCount ;
      private int AV6ResCode ;
      private long AV5ProveedorID ;
      private string AV2UserConect ;
      private string AV3Key ;
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
      private SdtSDTServicioDetalle AV8SDTServicios ;
      private int aP4_ResCode ;
      private string aP5_ResMessage ;
      private SdtSDTServicioDetalle aP6_SDTServicios ;
   }

}
