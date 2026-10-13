/*
				   File: type_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem
			Description: lineas
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
	[XmlRoot(ElementName="SDTFenicioOrdersResponse.ordenesItem.lineasItem")]
	[XmlType(TypeName="SDTFenicioOrdersResponse.ordenesItem.lineasItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem : GxUserType
	{
		public SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Nombre = "";

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Sku = "";


		}

		public SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem(IGxContext context)
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
			AddObjectProperty("nombre", gxTpr_Nombre, false);


			AddObjectProperty("sku", gxTpr_Sku, false);


			AddObjectProperty("cantidad", gxTpr_Cantidad, false);


			AddObjectProperty("precio", gxTpr_Precio, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="nombre")]
		[XmlElement(ElementName="nombre")]
		public string gxTpr_Nombre
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Nombre; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Nombre = value;
				SetDirty("Nombre");
			}
		}




		[SoapElement(ElementName="sku")]
		[XmlElement(ElementName="sku")]
		public string gxTpr_Sku
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Sku; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Sku = value;
				SetDirty("Sku");
			}
		}



		[SoapElement(ElementName="cantidad")]
		[XmlElement(ElementName="cantidad")]
		public string gxTpr_Cantidad_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Cantidad, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Cantidad = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Cantidad
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Cantidad; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Cantidad = value;
				SetDirty("Cantidad");
			}
		}



		[SoapElement(ElementName="precio")]
		[XmlElement(ElementName="precio")]
		public string gxTpr_Precio_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Precio, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Precio = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Precio
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Precio; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Precio = value;
				SetDirty("Precio");
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
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Nombre = "";
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Sku = "";


			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Nombre;
		 

		protected string gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Sku;
		 

		protected decimal gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Cantidad;
		 

		protected decimal gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_Precio;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTFenicioOrdersResponse.ordenesItem.lineasItem", Namespace="AlmangoX")]
	public class SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_RESTInterface : GxGenericCollectionItem<SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_RESTInterface( SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="nombre", Order=0)]
		public  string gxTpr_Nombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nombre);

			}
			set { 
				 sdt.gxTpr_Nombre = value;
			}
		}

		[DataMember(Name="sku", Order=1)]
		public  string gxTpr_Sku
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Sku);

			}
			set { 
				 sdt.gxTpr_Sku = value;
			}
		}

		[DataMember(Name="cantidad", Order=2)]
		public  string gxTpr_Cantidad
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Cantidad, 10, 5));

			}
			set { 
				sdt.gxTpr_Cantidad =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="precio", Order=3)]
		public  string gxTpr_Precio
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Precio, 10, 5));

			}
			set { 
				sdt.gxTpr_Precio =  NumberUtil.Val( value, ".");
			}
		}


		#endregion
		public SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem sdt
		{
			get { 
				return (SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem)Sdt;
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
				sdt = new SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem() ;
			}
		}
	}
	#endregion
}