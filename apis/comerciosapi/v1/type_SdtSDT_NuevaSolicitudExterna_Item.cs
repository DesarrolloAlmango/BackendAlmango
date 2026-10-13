/*
				   File: type_SdtSDT_NuevaSolicitudExterna_Item
			Description: Servicios
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
	[XmlRoot(ElementName="SDT_NuevaSolicitudExterna.Item")]
	[XmlType(TypeName="SDT_NuevaSolicitudExterna.Item" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDT_NuevaSolicitudExterna_Item : GxUserType
	{
		public SdtSDT_NuevaSolicitudExterna_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_NuevaSolicitudExterna_Item_Codigoserviciocomercio = "";

			gxTv_SdtSDT_NuevaSolicitudExterna_Item_Codigoservicioalmango = "";

			gxTv_SdtSDT_NuevaSolicitudExterna_Item_Imagenserviciourl = "";


		}

		public SdtSDT_NuevaSolicitudExterna_Item(IGxContext context)
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
			AddObjectProperty("CodigoServicioComercio", gxTpr_Codigoserviciocomercio, false);


			AddObjectProperty("CodigoServicioAlmango", gxTpr_Codigoservicioalmango, false);


			AddObjectProperty("Cantidad", gxTpr_Cantidad, false);


			AddObjectProperty("ImagenServicioUrl", gxTpr_Imagenserviciourl, false);


			AddObjectProperty("MontoAbonado", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Montoabonado, 18, 2)), false);


			AddObjectProperty("SolicitudIdRef", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Solicitudidref, 18, 0)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CodigoServicioComercio")]
		[XmlElement(ElementName="CodigoServicioComercio")]
		public string gxTpr_Codigoserviciocomercio
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Item_Codigoserviciocomercio; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Item_Codigoserviciocomercio = value;
				SetDirty("Codigoserviciocomercio");
			}
		}




		[SoapElement(ElementName="CodigoServicioAlmango")]
		[XmlElement(ElementName="CodigoServicioAlmango")]
		public string gxTpr_Codigoservicioalmango
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Item_Codigoservicioalmango; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Item_Codigoservicioalmango = value;
				SetDirty("Codigoservicioalmango");
			}
		}




		[SoapElement(ElementName="Cantidad")]
		[XmlElement(ElementName="Cantidad")]
		public short gxTpr_Cantidad
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Item_Cantidad; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Item_Cantidad = value;
				SetDirty("Cantidad");
			}
		}




		[SoapElement(ElementName="ImagenServicioUrl")]
		[XmlElement(ElementName="ImagenServicioUrl")]
		public string gxTpr_Imagenserviciourl
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Item_Imagenserviciourl; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Item_Imagenserviciourl = value;
				SetDirty("Imagenserviciourl");
			}
		}



		[SoapElement(ElementName="MontoAbonado")]
		[XmlElement(ElementName="MontoAbonado")]
		public string gxTpr_Montoabonado_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_NuevaSolicitudExterna_Item_Montoabonado, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Item_Montoabonado = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Montoabonado
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Item_Montoabonado; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Item_Montoabonado = value;
				SetDirty("Montoabonado");
			}
		}




		[SoapElement(ElementName="SolicitudIdRef")]
		[XmlElement(ElementName="SolicitudIdRef")]
		public long gxTpr_Solicitudidref
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Item_Solicitudidref; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Item_Solicitudidref = value;
				SetDirty("Solicitudidref");
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
			gxTv_SdtSDT_NuevaSolicitudExterna_Item_Codigoserviciocomercio = "";
			gxTv_SdtSDT_NuevaSolicitudExterna_Item_Codigoservicioalmango = "";

			gxTv_SdtSDT_NuevaSolicitudExterna_Item_Imagenserviciourl = "";


			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_NuevaSolicitudExterna_Item_Codigoserviciocomercio;
		 

		protected string gxTv_SdtSDT_NuevaSolicitudExterna_Item_Codigoservicioalmango;
		 

		protected short gxTv_SdtSDT_NuevaSolicitudExterna_Item_Cantidad;
		 

		protected string gxTv_SdtSDT_NuevaSolicitudExterna_Item_Imagenserviciourl;
		 

		protected decimal gxTv_SdtSDT_NuevaSolicitudExterna_Item_Montoabonado;
		 

		protected long gxTv_SdtSDT_NuevaSolicitudExterna_Item_Solicitudidref;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_NuevaSolicitudExterna.Item", Namespace="AlmangoX")]
	public class SdtSDT_NuevaSolicitudExterna_Item_RESTInterface : GxGenericCollectionItem<SdtSDT_NuevaSolicitudExterna_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_NuevaSolicitudExterna_Item_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_NuevaSolicitudExterna_Item_RESTInterface( SdtSDT_NuevaSolicitudExterna_Item psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CodigoServicioComercio", Order=0)]
		public  string gxTpr_Codigoserviciocomercio
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Codigoserviciocomercio);

			}
			set { 
				 sdt.gxTpr_Codigoserviciocomercio = value;
			}
		}

		[DataMember(Name="CodigoServicioAlmango", Order=1)]
		public  string gxTpr_Codigoservicioalmango
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Codigoservicioalmango);

			}
			set { 
				 sdt.gxTpr_Codigoservicioalmango = value;
			}
		}

		[DataMember(Name="Cantidad", Order=2)]
		public short gxTpr_Cantidad
		{
			get { 
				return sdt.gxTpr_Cantidad;

			}
			set { 
				sdt.gxTpr_Cantidad = value;
			}
		}

		[DataMember(Name="ImagenServicioUrl", Order=3)]
		public  string gxTpr_Imagenserviciourl
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Imagenserviciourl);

			}
			set { 
				 sdt.gxTpr_Imagenserviciourl = value;
			}
		}

		[DataMember(Name="MontoAbonado", Order=4)]
		public  string gxTpr_Montoabonado
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Montoabonado, 18, 2));

			}
			set { 
				sdt.gxTpr_Montoabonado =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SolicitudIdRef", Order=5)]
		public  string gxTpr_Solicitudidref
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Solicitudidref, 18, 0));

			}
			set { 
				sdt.gxTpr_Solicitudidref = (long) NumberUtil.Val( value, ".");
			}
		}


		#endregion
		public SdtSDT_NuevaSolicitudExterna_Item sdt
		{
			get { 
				return (SdtSDT_NuevaSolicitudExterna_Item)Sdt;
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
				sdt = new SdtSDT_NuevaSolicitudExterna_Item() ;
			}
		}
	}
	#endregion
}