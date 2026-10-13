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
   public class wsosoldat : GXProcedure
   {
      public wsosoldat( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public wsosoldat( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserConect ,
                           string aP1_Key ,
                           long aP2_SolicitudesID ,
                           out int aP3_ResCode ,
                           out string aP4_ResMessage ,
                           out DateTime aP5_SolicitudesFechaAlta ,
                           out DateTime aP6_FechaInstalacion ,
                           out int aP7_EstadoId ,
                           out string aP8_Estado ,
                           out string aP9_NombreCliente ,
                           out decimal aP10_SolicitudesTotal ,
                           out string aP11_ProfesionalesId ,
                           out string aP12_NombreProfesional ,
                           out long aP13_FeedBackId ,
                           out int aP14_Calificacion ,
                           out string aP15_Comentario ,
                           out DateTime aP16_FeedBackFechaAlta )
      {
         this.AV2UserConect = aP0_UserConect;
         this.AV3Key = aP1_Key;
         this.AV4SolicitudesID = aP2_SolicitudesID;
         this.AV5ResCode = 0 ;
         this.AV6ResMessage = "" ;
         this.AV7SolicitudesFechaAlta = DateTime.MinValue ;
         this.AV8FechaInstalacion = DateTime.MinValue ;
         this.AV9EstadoId = 0 ;
         this.AV10Estado = "" ;
         this.AV11NombreCliente = "" ;
         this.AV12SolicitudesTotal = 0 ;
         this.AV13ProfesionalesId = "" ;
         this.AV14NombreProfesional = "" ;
         this.AV15FeedBackId = 0 ;
         this.AV16Calificacion = 0 ;
         this.AV17Comentario = "" ;
         this.AV18FeedBackFechaAlta = DateTime.MinValue ;
         initialize();
         ExecutePrivate();
         aP3_ResCode=this.AV5ResCode;
         aP4_ResMessage=this.AV6ResMessage;
         aP5_SolicitudesFechaAlta=this.AV7SolicitudesFechaAlta;
         aP6_FechaInstalacion=this.AV8FechaInstalacion;
         aP7_EstadoId=this.AV9EstadoId;
         aP8_Estado=this.AV10Estado;
         aP9_NombreCliente=this.AV11NombreCliente;
         aP10_SolicitudesTotal=this.AV12SolicitudesTotal;
         aP11_ProfesionalesId=this.AV13ProfesionalesId;
         aP12_NombreProfesional=this.AV14NombreProfesional;
         aP13_FeedBackId=this.AV15FeedBackId;
         aP14_Calificacion=this.AV16Calificacion;
         aP15_Comentario=this.AV17Comentario;
         aP16_FeedBackFechaAlta=this.AV18FeedBackFechaAlta;
      }

      public DateTime executeUdp( string aP0_UserConect ,
                                  string aP1_Key ,
                                  long aP2_SolicitudesID ,
                                  out int aP3_ResCode ,
                                  out string aP4_ResMessage ,
                                  out DateTime aP5_SolicitudesFechaAlta ,
                                  out DateTime aP6_FechaInstalacion ,
                                  out int aP7_EstadoId ,
                                  out string aP8_Estado ,
                                  out string aP9_NombreCliente ,
                                  out decimal aP10_SolicitudesTotal ,
                                  out string aP11_ProfesionalesId ,
                                  out string aP12_NombreProfesional ,
                                  out long aP13_FeedBackId ,
                                  out int aP14_Calificacion ,
                                  out string aP15_Comentario )
      {
         execute(aP0_UserConect, aP1_Key, aP2_SolicitudesID, out aP3_ResCode, out aP4_ResMessage, out aP5_SolicitudesFechaAlta, out aP6_FechaInstalacion, out aP7_EstadoId, out aP8_Estado, out aP9_NombreCliente, out aP10_SolicitudesTotal, out aP11_ProfesionalesId, out aP12_NombreProfesional, out aP13_FeedBackId, out aP14_Calificacion, out aP15_Comentario, out aP16_FeedBackFechaAlta);
         return AV18FeedBackFechaAlta ;
      }

      public void executeSubmit( string aP0_UserConect ,
                                 string aP1_Key ,
                                 long aP2_SolicitudesID ,
                                 out int aP3_ResCode ,
                                 out string aP4_ResMessage ,
                                 out DateTime aP5_SolicitudesFechaAlta ,
                                 out DateTime aP6_FechaInstalacion ,
                                 out int aP7_EstadoId ,
                                 out string aP8_Estado ,
                                 out string aP9_NombreCliente ,
                                 out decimal aP10_SolicitudesTotal ,
                                 out string aP11_ProfesionalesId ,
                                 out string aP12_NombreProfesional ,
                                 out long aP13_FeedBackId ,
                                 out int aP14_Calificacion ,
                                 out string aP15_Comentario ,
                                 out DateTime aP16_FeedBackFechaAlta )
      {
         this.AV2UserConect = aP0_UserConect;
         this.AV3Key = aP1_Key;
         this.AV4SolicitudesID = aP2_SolicitudesID;
         this.AV5ResCode = 0 ;
         this.AV6ResMessage = "" ;
         this.AV7SolicitudesFechaAlta = DateTime.MinValue ;
         this.AV8FechaInstalacion = DateTime.MinValue ;
         this.AV9EstadoId = 0 ;
         this.AV10Estado = "" ;
         this.AV11NombreCliente = "" ;
         this.AV12SolicitudesTotal = 0 ;
         this.AV13ProfesionalesId = "" ;
         this.AV14NombreProfesional = "" ;
         this.AV15FeedBackId = 0 ;
         this.AV16Calificacion = 0 ;
         this.AV17Comentario = "" ;
         this.AV18FeedBackFechaAlta = DateTime.MinValue ;
         SubmitImpl();
         aP3_ResCode=this.AV5ResCode;
         aP4_ResMessage=this.AV6ResMessage;
         aP5_SolicitudesFechaAlta=this.AV7SolicitudesFechaAlta;
         aP6_FechaInstalacion=this.AV8FechaInstalacion;
         aP7_EstadoId=this.AV9EstadoId;
         aP8_Estado=this.AV10Estado;
         aP9_NombreCliente=this.AV11NombreCliente;
         aP10_SolicitudesTotal=this.AV12SolicitudesTotal;
         aP11_ProfesionalesId=this.AV13ProfesionalesId;
         aP12_NombreProfesional=this.AV14NombreProfesional;
         aP13_FeedBackId=this.AV15FeedBackId;
         aP14_Calificacion=this.AV16Calificacion;
         aP15_Comentario=this.AV17Comentario;
         aP16_FeedBackFechaAlta=this.AV18FeedBackFechaAlta;
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
         SoapParm.AssignLocationProperties( context, "AWSOSolDat", GXSoapHTTPClient);
         GXSoapHTTPClient.AddHeader("Content-type", "text/xml;charset=utf-8");
         GXSoapHTTPClient.AddHeader("SOAPAction", "AlmangoXaction/"+"AWSOSOLDAT.Execute");
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
         GXSoapXMLWriter.WriteElement("Solicitudesid", StringUtil.Trim( StringUtil.Str( (decimal)(AV4SolicitudesID), 18, 0)));
         GXSoapXMLWriter.WriteAttribute("xmlns", "AlmangoX");
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.Close();
         GXSoapHTTPClient.Execute("POST", "awsosoldat.aspx");
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
                     AV5ResCode = (int)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Resmessage") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     AV6ResMessage = GXSoapXMLReader.Value;
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Solicitudesfechaalta") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     if ( ( StringUtil.StrCmp(GXSoapXMLReader.Value, "") == 0 ) || ( GXSoapXMLReader.ExistsAttribute("xsi:nil") == 1 ) )
                     {
                        AV7SolicitudesFechaAlta = DateTime.MinValue;
                     }
                     else
                     {
                        AV7SolicitudesFechaAlta = context.localUtil.YMDToD( (int)(Math.Round(NumberUtil.Val( StringUtil.Substring( GXSoapXMLReader.Value, 1, 4), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( StringUtil.Substring( GXSoapXMLReader.Value, 6, 2), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( StringUtil.Substring( GXSoapXMLReader.Value, 9, 2), "."), 18, MidpointRounding.ToEven)));
                     }
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Fechainstalacion") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     if ( ( StringUtil.StrCmp(GXSoapXMLReader.Value, "") == 0 ) || ( GXSoapXMLReader.ExistsAttribute("xsi:nil") == 1 ) )
                     {
                        AV8FechaInstalacion = DateTime.MinValue;
                     }
                     else
                     {
                        AV8FechaInstalacion = context.localUtil.YMDToD( (int)(Math.Round(NumberUtil.Val( StringUtil.Substring( GXSoapXMLReader.Value, 1, 4), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( StringUtil.Substring( GXSoapXMLReader.Value, 6, 2), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( StringUtil.Substring( GXSoapXMLReader.Value, 9, 2), "."), 18, MidpointRounding.ToEven)));
                     }
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Estadoid") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     AV9EstadoId = (int)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Estado") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     AV10Estado = GXSoapXMLReader.Value;
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Nombrecliente") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     AV11NombreCliente = GXSoapXMLReader.Value;
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Solicitudestotal") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     AV12SolicitudesTotal = NumberUtil.Val( GXSoapXMLReader.Value, ".");
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Profesionalesid") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     AV13ProfesionalesId = GXSoapXMLReader.Value;
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Nombreprofesional") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     AV14NombreProfesional = GXSoapXMLReader.Value;
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Feedbackid") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     AV15FeedBackId = (long)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Calificacion") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     AV16Calificacion = (int)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Comentario") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     AV17Comentario = GXSoapXMLReader.Value;
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Feedbackfechaalta") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "AlmangoX") == 0 ) )
                  {
                     if ( ( StringUtil.StrCmp(GXSoapXMLReader.Value, "") == 0 ) || ( GXSoapXMLReader.ExistsAttribute("xsi:nil") == 1 ) )
                     {
                        AV18FeedBackFechaAlta = DateTime.MinValue;
                     }
                     else
                     {
                        AV18FeedBackFechaAlta = context.localUtil.YMDToD( (int)(Math.Round(NumberUtil.Val( StringUtil.Substring( GXSoapXMLReader.Value, 1, 4), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( StringUtil.Substring( GXSoapXMLReader.Value, 6, 2), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( StringUtil.Substring( GXSoapXMLReader.Value, 9, 2), "."), 18, MidpointRounding.ToEven)));
                     }
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
            oLocation = SoapParm.getlocation( context, "AWSOSolDat");
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
         AV6ResMessage = "";
         AV7SolicitudesFechaAlta = DateTime.MinValue;
         AV8FechaInstalacion = DateTime.MinValue;
         AV10Estado = "";
         AV11NombreCliente = "";
         AV13ProfesionalesId = "";
         AV14NombreProfesional = "";
         AV17Comentario = "";
         AV18FeedBackFechaAlta = DateTime.MinValue;
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
      private int AV5ResCode ;
      private int AV9EstadoId ;
      private int AV16Calificacion ;
      private long AV4SolicitudesID ;
      private long AV15FeedBackId ;
      private decimal AV12SolicitudesTotal ;
      private string AV2UserConect ;
      private string AV3Key ;
      private string AV6ResMessage ;
      private string AV10Estado ;
      private string AV11NombreCliente ;
      private string AV13ProfesionalesId ;
      private string AV14NombreProfesional ;
      private string sReturn ;
      private string currSoapErrmsg ;
      private string sTagName ;
      private string sFaultCode ;
      private string sFaultString ;
      private string sDetail ;
      private DateTime AV7SolicitudesFechaAlta ;
      private DateTime AV8FechaInstalacion ;
      private DateTime AV18FeedBackFechaAlta ;
      private bool readElement ;
      private bool formatError ;
      private string AV17Comentario ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxHttpClient GXSoapHTTPClient ;
      private GxLocation oLocation ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private int aP3_ResCode ;
      private string aP4_ResMessage ;
      private DateTime aP5_SolicitudesFechaAlta ;
      private DateTime aP6_FechaInstalacion ;
      private int aP7_EstadoId ;
      private string aP8_Estado ;
      private string aP9_NombreCliente ;
      private decimal aP10_SolicitudesTotal ;
      private string aP11_ProfesionalesId ;
      private string aP12_NombreProfesional ;
      private long aP13_FeedBackId ;
      private int aP14_Calificacion ;
      private string aP15_Comentario ;
      private DateTime aP16_FeedBackFechaAlta ;
   }

}
