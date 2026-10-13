/*
				   File: type_SdtSDTFenicioOrdersResponse_ordenesItem_comprador
			Description: comprador
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
	[XmlRoot(ElementName="SDTFenicioOrdersResponse.ordenesItem.comprador")]
	[XmlType(TypeName="SDTFenicioOrdersResponse.ordenesItem.comprador" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTFenicioOrdersResponse_ordenesItem_comprador : GxUserType
	{
		public SdtSDTFenicioOrdersResponse_ordenesItem_comprador( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Email = "";

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Nombre = "";

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Apellido = "";

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Telefono = "";

		}

		public SdtSDTFenicioOrdersResponse_ordenesItem_comprador(IGxContext context)
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
			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("email", gxTpr_Email, false);


			AddObjectProperty("nombre", gxTpr_Nombre, false);


			AddObjectProperty("apellido", gxTpr_Apellido, false);


			AddObjectProperty("telefono", gxTpr_Telefono, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Id, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Id = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Id
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Id; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="email")]
		[XmlElement(ElementName="email")]
		public string gxTpr_Email
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Email; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Email = value;
				SetDirty("Email");
			}
		}




		[SoapElement(ElementName="nombre")]
		[XmlElement(ElementName="nombre")]
		public string gxTpr_Nombre
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Nombre; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Nombre = value;
				SetDirty("Nombre");
			}
		}




		[SoapElement(ElementName="apellido")]
		[XmlElement(ElementName="apellido")]
		public string gxTpr_Apellido
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Apellido; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Apellido = value;
				SetDirty("Apellido");
			}
		}




		[SoapElement(ElementName="telefono")]
		[XmlElement(ElementName="telefono")]
		public string gxTpr_Telefono
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Telefono; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Telefono = value;
				SetDirty("Telefono");
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
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Email = "";
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Nombre = "";
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Apellido = "";
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Telefono = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Id;
		 

		protected string gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Email;
		 

		protected string gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Nombre;
		 

		protected string gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Apellido;
		 

		protected string gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_comprador_Telefono;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTFenicioOrdersResponse.ordenesItem.comprador", Namespace="AlmangoX")]
	public class SdtSDTFenicioOrdersResponse_ordenesItem_comprador_RESTInterface : GxGenericCollectionItem<SdtSDTFenicioOrdersResponse_ordenesItem_comprador>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTFenicioOrdersResponse_ordenesItem_comprador_RESTInterface( ) : base()
		{	
		}

		public SdtSDTFenicioOrdersResponse_ordenesItem_comprador_RESTInterface( SdtSDTFenicioOrdersResponse_ordenesItem_comprador psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Id, 10, 5));

			}
			set { 
				sdt.gxTpr_Id =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="email", Order=1)]
		public  string gxTpr_Email
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Email);

			}
			set { 
				 sdt.gxTpr_Email = value;
			}
		}

		[DataMember(Name="nombre", Order=2)]
		public  string gxTpr_Nombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nombre);

			}
			set { 
				 sdt.gxTpr_Nombre = value;
			}
		}

		[DataMember(Name="apellido", Order=3)]
		public  string gxTpr_Apellido
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Apellido);

			}
			set { 
				 sdt.gxTpr_Apellido = value;
			}
		}

		[DataMember(Name="telefono", Order=4)]
		public  string gxTpr_Telefono
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Telefono);

			}
			set { 
				 sdt.gxTpr_Telefono = value;
			}
		}


		#endregion
		public SdtSDTFenicioOrdersResponse_ordenesItem_comprador sdt
		{
			get { 
				return (SdtSDTFenicioOrdersResponse_ordenesItem_comprador)Sdt;
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
				sdt = new SdtSDTFenicioOrdersResponse_ordenesItem_comprador() ;
			}
		}
	}
	#endregion
}