/*
				   File: type_SdtSdtReporteDEconomico_SolicitudesItem
			Description: Solicitudes
				 Author: Nemo 🐠 for C# version 18.0.15.188745
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;

using GeneXus.Programs;

namespace GeneXus.Programs.apis
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="SdtReporteDEconomico.SolicitudesItem")]
	[XmlType(TypeName="SdtReporteDEconomico.SolicitudesItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSdtReporteDEconomico_SolicitudesItem : GxUserType
	{
		public SdtSdtReporteDEconomico_SolicitudesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Nombrecliente = "";

			gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Estado = "";

			gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Origenpago = "";

		}

		public SdtSdtReporteDEconomico_SolicitudesItem(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("SolicitudesId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Solicitudesid, 18, 0)), false);


			AddObjectProperty("NombreCliente", gxTpr_Nombrecliente, false);


			AddObjectProperty("Estado", gxTpr_Estado, false);


			AddObjectProperty("ImporteCobrado", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Importecobrado, 18, 2)), false);


			AddObjectProperty("ComisionAlmango", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Comisionalmango, 18, 2)), false);


			AddObjectProperty("PagoProfesional", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Pagoprofesional, 18, 2)), false);


			AddObjectProperty("EsCobroDirecto", gxTpr_Escobrodirecto, false);


			AddObjectProperty("OrigenPago", gxTpr_Origenpago, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SolicitudesId")]
		[XmlElement(ElementName="SolicitudesId")]
		public long gxTpr_Solicitudesid
		{
			get {
				return gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Solicitudesid; 
			}
			set {
				gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Solicitudesid = value;
				SetDirty("Solicitudesid");
			}
		}




		[SoapElement(ElementName="NombreCliente")]
		[XmlElement(ElementName="NombreCliente")]
		public string gxTpr_Nombrecliente
		{
			get {
				return gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Nombrecliente; 
			}
			set {
				gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Nombrecliente = value;
				SetDirty("Nombrecliente");
			}
		}




		[SoapElement(ElementName="Estado")]
		[XmlElement(ElementName="Estado")]
		public string gxTpr_Estado
		{
			get {
				return gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Estado; 
			}
			set {
				gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Estado = value;
				SetDirty("Estado");
			}
		}



		[SoapElement(ElementName="ImporteCobrado")]
		[XmlElement(ElementName="ImporteCobrado")]
		public string gxTpr_Importecobrado_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Importecobrado, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Importecobrado = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Importecobrado
		{
			get {
				return gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Importecobrado; 
			}
			set {
				gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Importecobrado = value;
				SetDirty("Importecobrado");
			}
		}



		[SoapElement(ElementName="ComisionAlmango")]
		[XmlElement(ElementName="ComisionAlmango")]
		public string gxTpr_Comisionalmango_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Comisionalmango, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Comisionalmango = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Comisionalmango
		{
			get {
				return gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Comisionalmango; 
			}
			set {
				gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Comisionalmango = value;
				SetDirty("Comisionalmango");
			}
		}



		[SoapElement(ElementName="PagoProfesional")]
		[XmlElement(ElementName="PagoProfesional")]
		public string gxTpr_Pagoprofesional_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Pagoprofesional, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Pagoprofesional = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Pagoprofesional
		{
			get {
				return gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Pagoprofesional; 
			}
			set {
				gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Pagoprofesional = value;
				SetDirty("Pagoprofesional");
			}
		}




		[SoapElement(ElementName="EsCobroDirecto")]
		[XmlElement(ElementName="EsCobroDirecto")]
		public bool gxTpr_Escobrodirecto
		{
			get {
				return gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Escobrodirecto; 
			}
			set {
				gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Escobrodirecto = value;
				SetDirty("Escobrodirecto");
			}
		}




		[SoapElement(ElementName="OrigenPago")]
		[XmlElement(ElementName="OrigenPago")]
		public string gxTpr_Origenpago
		{
			get {
				return gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Origenpago; 
			}
			set {
				gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Origenpago = value;
				SetDirty("Origenpago");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Static Type Properties

		[SoapIgnore]
		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Nombrecliente = "";
			gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Estado = "";




			gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Origenpago = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Solicitudesid;
		 

		protected string gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Nombrecliente;
		 

		protected string gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Estado;
		 

		protected decimal gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Importecobrado;
		 

		protected decimal gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Comisionalmango;
		 

		protected decimal gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Pagoprofesional;
		 

		protected bool gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Escobrodirecto;
		 

		protected string gxTv_SdtSdtReporteDEconomico_SolicitudesItem_Origenpago;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SdtReporteDEconomico.SolicitudesItem", Namespace="AlmangoX")]
	public class SdtSdtReporteDEconomico_SolicitudesItem_RESTInterface : GxGenericCollectionItem<SdtSdtReporteDEconomico_SolicitudesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdtReporteDEconomico_SolicitudesItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdtReporteDEconomico_SolicitudesItem_RESTInterface( SdtSdtReporteDEconomico_SolicitudesItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="SolicitudesId", Order=0)]
		public  string gxTpr_Solicitudesid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Solicitudesid, 18, 0));

			}
			set { 
				sdt.gxTpr_Solicitudesid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NombreCliente", Order=1)]
		public  string gxTpr_Nombrecliente
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nombrecliente);

			}
			set { 
				 sdt.gxTpr_Nombrecliente = value;
			}
		}

		[DataMember(Name="Estado", Order=2)]
		public  string gxTpr_Estado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Estado);

			}
			set { 
				 sdt.gxTpr_Estado = value;
			}
		}

		[DataMember(Name="ImporteCobrado", Order=3)]
		public  string gxTpr_Importecobrado
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Importecobrado, 18, 2));

			}
			set { 
				sdt.gxTpr_Importecobrado =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ComisionAlmango", Order=4)]
		public  string gxTpr_Comisionalmango
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Comisionalmango, 18, 2));

			}
			set { 
				sdt.gxTpr_Comisionalmango =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PagoProfesional", Order=5)]
		public  string gxTpr_Pagoprofesional
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Pagoprofesional, 18, 2));

			}
			set { 
				sdt.gxTpr_Pagoprofesional =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="EsCobroDirecto", Order=6)]
		public bool gxTpr_Escobrodirecto
		{
			get { 
				return sdt.gxTpr_Escobrodirecto;

			}
			set { 
				sdt.gxTpr_Escobrodirecto = value;
			}
		}

		[DataMember(Name="OrigenPago", Order=7)]
		public  string gxTpr_Origenpago
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Origenpago);

			}
			set { 
				 sdt.gxTpr_Origenpago = value;
			}
		}


		#endregion
		public SdtSdtReporteDEconomico_SolicitudesItem sdt
		{
			get { 
				return (SdtSdtReporteDEconomico_SolicitudesItem)Sdt;
			}
			set {
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSdtReporteDEconomico_SolicitudesItem() ;
			}
		}
	}
	#endregion
}