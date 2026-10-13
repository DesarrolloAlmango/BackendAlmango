/*
				   File: type_SdtSdtReporteDEconomico_Totales
			Description: Totales
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
	[XmlRoot(ElementName="SdtReporteDEconomico.Totales")]
	[XmlType(TypeName="SdtReporteDEconomico.Totales" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSdtReporteDEconomico_Totales : GxUserType
	{
		public SdtSdtReporteDEconomico_Totales( )
		{
			/* Constructor for serialization */
		}

		public SdtSdtReporteDEconomico_Totales(IGxContext context)
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
			AddObjectProperty("TotalCobrado", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Totalcobrado, 18, 2)), false);


			AddObjectProperty("TotalAlmango", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Totalalmango, 18, 2)), false);


			AddObjectProperty("TotalProfesional", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Totalprofesional, 18, 2)), false);


			AddObjectProperty("TotalProfNoCDirecto", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Totalprofnocdirecto, 18, 2)), false);


			AddObjectProperty("ResultadoNeto", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Resultadoneto, 18, 2)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TotalCobrado")]
		[XmlElement(ElementName="TotalCobrado")]
		public string gxTpr_Totalcobrado_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtReporteDEconomico_Totales_Totalcobrado, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtReporteDEconomico_Totales_Totalcobrado = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Totalcobrado
		{
			get {
				return gxTv_SdtSdtReporteDEconomico_Totales_Totalcobrado; 
			}
			set {
				gxTv_SdtSdtReporteDEconomico_Totales_Totalcobrado = value;
				SetDirty("Totalcobrado");
			}
		}



		[SoapElement(ElementName="TotalAlmango")]
		[XmlElement(ElementName="TotalAlmango")]
		public string gxTpr_Totalalmango_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtReporteDEconomico_Totales_Totalalmango, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtReporteDEconomico_Totales_Totalalmango = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Totalalmango
		{
			get {
				return gxTv_SdtSdtReporteDEconomico_Totales_Totalalmango; 
			}
			set {
				gxTv_SdtSdtReporteDEconomico_Totales_Totalalmango = value;
				SetDirty("Totalalmango");
			}
		}



		[SoapElement(ElementName="TotalProfesional")]
		[XmlElement(ElementName="TotalProfesional")]
		public string gxTpr_Totalprofesional_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtReporteDEconomico_Totales_Totalprofesional, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtReporteDEconomico_Totales_Totalprofesional = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Totalprofesional
		{
			get {
				return gxTv_SdtSdtReporteDEconomico_Totales_Totalprofesional; 
			}
			set {
				gxTv_SdtSdtReporteDEconomico_Totales_Totalprofesional = value;
				SetDirty("Totalprofesional");
			}
		}



		[SoapElement(ElementName="TotalProfNoCDirecto")]
		[XmlElement(ElementName="TotalProfNoCDirecto")]
		public string gxTpr_Totalprofnocdirecto_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtReporteDEconomico_Totales_Totalprofnocdirecto, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtReporteDEconomico_Totales_Totalprofnocdirecto = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Totalprofnocdirecto
		{
			get {
				return gxTv_SdtSdtReporteDEconomico_Totales_Totalprofnocdirecto; 
			}
			set {
				gxTv_SdtSdtReporteDEconomico_Totales_Totalprofnocdirecto = value;
				SetDirty("Totalprofnocdirecto");
			}
		}



		[SoapElement(ElementName="ResultadoNeto")]
		[XmlElement(ElementName="ResultadoNeto")]
		public string gxTpr_Resultadoneto_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtReporteDEconomico_Totales_Resultadoneto, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtReporteDEconomico_Totales_Resultadoneto = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Resultadoneto
		{
			get {
				return gxTv_SdtSdtReporteDEconomico_Totales_Resultadoneto; 
			}
			set {
				gxTv_SdtSdtReporteDEconomico_Totales_Resultadoneto = value;
				SetDirty("Resultadoneto");
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
			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtSdtReporteDEconomico_Totales_Totalcobrado;
		 

		protected decimal gxTv_SdtSdtReporteDEconomico_Totales_Totalalmango;
		 

		protected decimal gxTv_SdtSdtReporteDEconomico_Totales_Totalprofesional;
		 

		protected decimal gxTv_SdtSdtReporteDEconomico_Totales_Totalprofnocdirecto;
		 

		protected decimal gxTv_SdtSdtReporteDEconomico_Totales_Resultadoneto;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdtReporteDEconomico.Totales", Namespace="AlmangoX")]
	public class SdtSdtReporteDEconomico_Totales_RESTInterface : GxGenericCollectionItem<SdtSdtReporteDEconomico_Totales>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdtReporteDEconomico_Totales_RESTInterface( ) : base()
		{	
		}

		public SdtSdtReporteDEconomico_Totales_RESTInterface( SdtSdtReporteDEconomico_Totales psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="TotalCobrado", Order=0)]
		public  string gxTpr_Totalcobrado
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totalcobrado, 18, 2));

			}
			set { 
				sdt.gxTpr_Totalcobrado =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TotalAlmango", Order=1)]
		public  string gxTpr_Totalalmango
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totalalmango, 18, 2));

			}
			set { 
				sdt.gxTpr_Totalalmango =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TotalProfesional", Order=2)]
		public  string gxTpr_Totalprofesional
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totalprofesional, 18, 2));

			}
			set { 
				sdt.gxTpr_Totalprofesional =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TotalProfNoCDirecto", Order=3)]
		public  string gxTpr_Totalprofnocdirecto
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totalprofnocdirecto, 18, 2));

			}
			set { 
				sdt.gxTpr_Totalprofnocdirecto =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ResultadoNeto", Order=4)]
		public  string gxTpr_Resultadoneto
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Resultadoneto, 18, 2));

			}
			set { 
				sdt.gxTpr_Resultadoneto =  NumberUtil.Val( value, ".");
			}
		}


		#endregion
		public SdtSdtReporteDEconomico_Totales sdt
		{
			get { 
				return (SdtSdtReporteDEconomico_Totales)Sdt;
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
				sdt = new SdtSdtReporteDEconomico_Totales() ;
			}
		}
	}
	#endregion
}