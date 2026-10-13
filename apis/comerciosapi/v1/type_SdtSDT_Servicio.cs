/*
				   File: type_SdtSDT_Servicio
			Description: SDT_Servicio
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
using GeneXus.Programs.apis;
using GeneXus.Programs.apis.comerciosapi;

namespace GeneXus.Programs.apis.comerciosapi.v1
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="SDT_Servicio")]
	[XmlType(TypeName="SDT_Servicio" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDT_Servicio : GxUserType
	{
		public SdtSDT_Servicio( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Servicio_Codigoservicio = "";

			gxTv_SdtSDT_Servicio_Nombre = "";

			gxTv_SdtSDT_Servicio_Moneda = "";

			gxTv_SdtSDT_Servicio_Estado = "";

		}

		public SdtSDT_Servicio(IGxContext context)
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
			AddObjectProperty("CodigoServicio", gxTpr_Codigoservicio, false);


			AddObjectProperty("Nombre", gxTpr_Nombre, false);


			AddObjectProperty("Moneda", gxTpr_Moneda, false);


			AddObjectProperty("Precio", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Precio, 18, 2)), false);


			AddObjectProperty("Estado", gxTpr_Estado, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CodigoServicio")]
		[XmlElement(ElementName="CodigoServicio")]
		public string gxTpr_Codigoservicio
		{
			get {
				return gxTv_SdtSDT_Servicio_Codigoservicio; 
			}
			set {
				gxTv_SdtSDT_Servicio_Codigoservicio = value;
				SetDirty("Codigoservicio");
			}
		}




		[SoapElement(ElementName="Nombre")]
		[XmlElement(ElementName="Nombre")]
		public string gxTpr_Nombre
		{
			get {
				return gxTv_SdtSDT_Servicio_Nombre; 
			}
			set {
				gxTv_SdtSDT_Servicio_Nombre = value;
				SetDirty("Nombre");
			}
		}




		[SoapElement(ElementName="Moneda")]
		[XmlElement(ElementName="Moneda")]
		public string gxTpr_Moneda
		{
			get {
				return gxTv_SdtSDT_Servicio_Moneda; 
			}
			set {
				gxTv_SdtSDT_Servicio_Moneda = value;
				SetDirty("Moneda");
			}
		}



		[SoapElement(ElementName="Precio")]
		[XmlElement(ElementName="Precio")]
		public string gxTpr_Precio_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_Servicio_Precio, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_Servicio_Precio = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Precio
		{
			get {
				return gxTv_SdtSDT_Servicio_Precio; 
			}
			set {
				gxTv_SdtSDT_Servicio_Precio = value;
				SetDirty("Precio");
			}
		}




		[SoapElement(ElementName="Estado")]
		[XmlElement(ElementName="Estado")]
		public string gxTpr_Estado
		{
			get {
				return gxTv_SdtSDT_Servicio_Estado; 
			}
			set {
				gxTv_SdtSDT_Servicio_Estado = value;
				SetDirty("Estado");
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
			gxTv_SdtSDT_Servicio_Codigoservicio = "";
			gxTv_SdtSDT_Servicio_Nombre = "";
			gxTv_SdtSDT_Servicio_Moneda = "";

			gxTv_SdtSDT_Servicio_Estado = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_Servicio_Codigoservicio;
		 

		protected string gxTv_SdtSDT_Servicio_Nombre;
		 

		protected string gxTv_SdtSDT_Servicio_Moneda;
		 

		protected decimal gxTv_SdtSDT_Servicio_Precio;
		 

		protected string gxTv_SdtSDT_Servicio_Estado;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Servicio", Namespace="AlmangoX")]
	public class SdtSDT_Servicio_RESTInterface : GxGenericCollectionItem<SdtSDT_Servicio>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Servicio_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Servicio_RESTInterface( SdtSDT_Servicio psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CodigoServicio", Order=0)]
		public  string gxTpr_Codigoservicio
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Codigoservicio);

			}
			set { 
				 sdt.gxTpr_Codigoservicio = value;
			}
		}

		[DataMember(Name="Nombre", Order=1)]
		public  string gxTpr_Nombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nombre);

			}
			set { 
				 sdt.gxTpr_Nombre = value;
			}
		}

		[DataMember(Name="Moneda", Order=2)]
		public  string gxTpr_Moneda
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Moneda);

			}
			set { 
				 sdt.gxTpr_Moneda = value;
			}
		}

		[DataMember(Name="Precio", Order=3)]
		public  string gxTpr_Precio
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Precio, 18, 2));

			}
			set { 
				sdt.gxTpr_Precio =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Estado", Order=4)]
		public  string gxTpr_Estado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Estado);

			}
			set { 
				 sdt.gxTpr_Estado = value;
			}
		}


		#endregion
		public SdtSDT_Servicio sdt
		{
			get { 
				return (SdtSDT_Servicio)Sdt;
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
				sdt = new SdtSDT_Servicio() ;
			}
		}
	}
	#endregion
}