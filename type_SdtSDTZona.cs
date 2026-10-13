/*
				   File: type_SdtSDTZona
			Description: SDTZona
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


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="SDTZona")]
	[XmlType(TypeName="SDTZona" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTZona : GxUserType
	{
		public SdtSDTZona( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTZona_Zonasnombre = "";

			gxTv_SdtSDTZona_Zonasestado = "";


		}

		public SdtSDTZona(IGxContext context)
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
			AddObjectProperty("DepartamentoId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Departamentoid, 18, 0)), false);


			AddObjectProperty("DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Departamentomunicipioid, 18, 0)), false);


			AddObjectProperty("ZonasID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Zonasid, 18, 0)), false);


			AddObjectProperty("ZonasNombre", gxTpr_Zonasnombre, false);


			AddObjectProperty("ZonasEstado", gxTpr_Zonasestado, false);


			AddObjectProperty("ZonasHabilitarEcommerce", gxTpr_Zonashabilitarecommerce, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DepartamentoId")]
		[XmlElement(ElementName="DepartamentoId")]
		public long gxTpr_Departamentoid
		{
			get {
				return gxTv_SdtSDTZona_Departamentoid; 
			}
			set {
				gxTv_SdtSDTZona_Departamentoid = value;
				SetDirty("Departamentoid");
			}
		}




		[SoapElement(ElementName="DepartamentoMunicipioId")]
		[XmlElement(ElementName="DepartamentoMunicipioId")]
		public long gxTpr_Departamentomunicipioid
		{
			get {
				return gxTv_SdtSDTZona_Departamentomunicipioid; 
			}
			set {
				gxTv_SdtSDTZona_Departamentomunicipioid = value;
				SetDirty("Departamentomunicipioid");
			}
		}




		[SoapElement(ElementName="ZonasID")]
		[XmlElement(ElementName="ZonasID")]
		public long gxTpr_Zonasid
		{
			get {
				return gxTv_SdtSDTZona_Zonasid; 
			}
			set {
				gxTv_SdtSDTZona_Zonasid = value;
				SetDirty("Zonasid");
			}
		}




		[SoapElement(ElementName="ZonasNombre")]
		[XmlElement(ElementName="ZonasNombre")]
		public string gxTpr_Zonasnombre
		{
			get {
				return gxTv_SdtSDTZona_Zonasnombre; 
			}
			set {
				gxTv_SdtSDTZona_Zonasnombre = value;
				SetDirty("Zonasnombre");
			}
		}




		[SoapElement(ElementName="ZonasEstado")]
		[XmlElement(ElementName="ZonasEstado")]
		public string gxTpr_Zonasestado
		{
			get {
				return gxTv_SdtSDTZona_Zonasestado; 
			}
			set {
				gxTv_SdtSDTZona_Zonasestado = value;
				SetDirty("Zonasestado");
			}
		}




		[SoapElement(ElementName="ZonasHabilitarEcommerce")]
		[XmlElement(ElementName="ZonasHabilitarEcommerce")]
		public bool gxTpr_Zonashabilitarecommerce
		{
			get {
				return gxTv_SdtSDTZona_Zonashabilitarecommerce; 
			}
			set {
				gxTv_SdtSDTZona_Zonashabilitarecommerce = value;
				SetDirty("Zonashabilitarecommerce");
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
			gxTv_SdtSDTZona_Zonasnombre = "";
			gxTv_SdtSDTZona_Zonasestado = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTZona_Departamentoid;
		 

		protected long gxTv_SdtSDTZona_Departamentomunicipioid;
		 

		protected long gxTv_SdtSDTZona_Zonasid;
		 

		protected string gxTv_SdtSDTZona_Zonasnombre;
		 

		protected string gxTv_SdtSDTZona_Zonasestado;
		 

		protected bool gxTv_SdtSDTZona_Zonashabilitarecommerce;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTZona", Namespace="AlmangoX")]
	public class SdtSDTZona_RESTInterface : GxGenericCollectionItem<SdtSDTZona>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTZona_RESTInterface( ) : base()
		{	
		}

		public SdtSDTZona_RESTInterface( SdtSDTZona psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="DepartamentoId", Order=0)]
		public  string gxTpr_Departamentoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Departamentoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Departamentoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DepartamentoMunicipioId", Order=1)]
		public  string gxTpr_Departamentomunicipioid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Departamentomunicipioid, 18, 0));

			}
			set { 
				sdt.gxTpr_Departamentomunicipioid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ZonasID", Order=2)]
		public  string gxTpr_Zonasid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Zonasid, 18, 0));

			}
			set { 
				sdt.gxTpr_Zonasid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ZonasNombre", Order=3)]
		public  string gxTpr_Zonasnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Zonasnombre);

			}
			set { 
				 sdt.gxTpr_Zonasnombre = value;
			}
		}

		[DataMember(Name="ZonasEstado", Order=4)]
		public  string gxTpr_Zonasestado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Zonasestado);

			}
			set { 
				 sdt.gxTpr_Zonasestado = value;
			}
		}

		[DataMember(Name="ZonasHabilitarEcommerce", Order=5)]
		public bool gxTpr_Zonashabilitarecommerce
		{
			get { 
				return sdt.gxTpr_Zonashabilitarecommerce;

			}
			set { 
				sdt.gxTpr_Zonashabilitarecommerce = value;
			}
		}


		#endregion
		public SdtSDTZona sdt
		{
			get { 
				return (SdtSDTZona)Sdt;
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
				sdt = new SdtSDTZona() ;
			}
		}
	}
	#endregion
}