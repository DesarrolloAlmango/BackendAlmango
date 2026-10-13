/*
				   File: type_SdtSDTCarga_SDTCargaItem
			Description: SDTCarga
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
	[XmlRoot(ElementName="SDTCargaItem")]
	[XmlType(TypeName="SDTCargaItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTCarga_SDTCargaItem : GxUserType
	{
		public SdtSDTCarga_SDTCargaItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCarga_SDTCargaItem_Tipo = "";

			gxTv_SdtSDTCarga_SDTCargaItem_Titulo = "";

			gxTv_SdtSDTCarga_SDTCargaItem_Nombre = "";

			gxTv_SdtSDTCarga_SDTCargaItem_Descripcion = "";

			gxTv_SdtSDTCarga_SDTCargaItem_Unidad = "";

			gxTv_SdtSDTCarga_SDTCargaItem_Imagen = "";
			gxTv_SdtSDTCarga_SDTCargaItem_Imagen_gxi = "";


		}

		public SdtSDTCarga_SDTCargaItem(IGxContext context)
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
			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("Tipo", gxTpr_Tipo, false);


			AddObjectProperty("Titulo", gxTpr_Titulo, false);


			AddObjectProperty("Nombre", gxTpr_Nombre, false);


			AddObjectProperty("Descripcion", gxTpr_Descripcion, false);


			AddObjectProperty("Valor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Valor, 18, 2)), false);


			AddObjectProperty("Unidad", gxTpr_Unidad, false);


			AddObjectProperty("Cantidad", gxTpr_Cantidad, false);


			AddObjectProperty("Imagen", gxTpr_Imagen, false);
			AddObjectProperty("Imagen_GXI", gxTpr_Imagen_gxi, false);



			AddObjectProperty("Embalaje", gxTpr_Embalaje, false);


			AddObjectProperty("EmbalajeCant", gxTpr_Embalajecant, false);


			AddObjectProperty("Elevacion", gxTpr_Elevacion, false);


			AddObjectProperty("ElevacionCant", gxTpr_Elevacioncant, false);


			AddObjectProperty("Activo", gxTpr_Activo, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public short gxTpr_Id
		{
			get {
				return gxTv_SdtSDTCarga_SDTCargaItem_Id; 
			}
			set {
				gxTv_SdtSDTCarga_SDTCargaItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Tipo")]
		[XmlElement(ElementName="Tipo")]
		public string gxTpr_Tipo
		{
			get {
				return gxTv_SdtSDTCarga_SDTCargaItem_Tipo; 
			}
			set {
				gxTv_SdtSDTCarga_SDTCargaItem_Tipo = value;
				SetDirty("Tipo");
			}
		}




		[SoapElement(ElementName="Titulo")]
		[XmlElement(ElementName="Titulo")]
		public string gxTpr_Titulo
		{
			get {
				return gxTv_SdtSDTCarga_SDTCargaItem_Titulo; 
			}
			set {
				gxTv_SdtSDTCarga_SDTCargaItem_Titulo = value;
				SetDirty("Titulo");
			}
		}




		[SoapElement(ElementName="Nombre")]
		[XmlElement(ElementName="Nombre")]
		public string gxTpr_Nombre
		{
			get {
				return gxTv_SdtSDTCarga_SDTCargaItem_Nombre; 
			}
			set {
				gxTv_SdtSDTCarga_SDTCargaItem_Nombre = value;
				SetDirty("Nombre");
			}
		}




		[SoapElement(ElementName="Descripcion")]
		[XmlElement(ElementName="Descripcion")]
		public string gxTpr_Descripcion
		{
			get {
				return gxTv_SdtSDTCarga_SDTCargaItem_Descripcion; 
			}
			set {
				gxTv_SdtSDTCarga_SDTCargaItem_Descripcion = value;
				SetDirty("Descripcion");
			}
		}



		[SoapElement(ElementName="Valor")]
		[XmlElement(ElementName="Valor")]
		public string gxTpr_Valor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTCarga_SDTCargaItem_Valor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTCarga_SDTCargaItem_Valor = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Valor
		{
			get {
				return gxTv_SdtSDTCarga_SDTCargaItem_Valor; 
			}
			set {
				gxTv_SdtSDTCarga_SDTCargaItem_Valor = value;
				SetDirty("Valor");
			}
		}




		[SoapElement(ElementName="Unidad")]
		[XmlElement(ElementName="Unidad")]
		public string gxTpr_Unidad
		{
			get {
				return gxTv_SdtSDTCarga_SDTCargaItem_Unidad; 
			}
			set {
				gxTv_SdtSDTCarga_SDTCargaItem_Unidad = value;
				SetDirty("Unidad");
			}
		}




		[SoapElement(ElementName="Cantidad")]
		[XmlElement(ElementName="Cantidad")]
		public short gxTpr_Cantidad
		{
			get {
				return gxTv_SdtSDTCarga_SDTCargaItem_Cantidad; 
			}
			set {
				gxTv_SdtSDTCarga_SDTCargaItem_Cantidad = value;
				SetDirty("Cantidad");
			}
		}




		[SoapElement(ElementName="Imagen")]
		[XmlElement(ElementName="Imagen")]
		[GxUpload()]

		public string gxTpr_Imagen
		{
			get {
				return gxTv_SdtSDTCarga_SDTCargaItem_Imagen; 
			}
			set {
				gxTv_SdtSDTCarga_SDTCargaItem_Imagen = value;
				SetDirty("Imagen");
			}
		}


		[SoapElement(ElementName="Imagen_GXI" )]
		[XmlElement(ElementName="Imagen_GXI" )]
		public string gxTpr_Imagen_gxi
		{
			get {
				return gxTv_SdtSDTCarga_SDTCargaItem_Imagen_gxi ;
			}
			set {
				gxTv_SdtSDTCarga_SDTCargaItem_Imagen_gxi = value;
				SetDirty("Imagen_gxi");
			}
		}

		[SoapElement(ElementName="Embalaje")]
		[XmlElement(ElementName="Embalaje")]
		public bool gxTpr_Embalaje
		{
			get {
				return gxTv_SdtSDTCarga_SDTCargaItem_Embalaje; 
			}
			set {
				gxTv_SdtSDTCarga_SDTCargaItem_Embalaje = value;
				SetDirty("Embalaje");
			}
		}




		[SoapElement(ElementName="EmbalajeCant")]
		[XmlElement(ElementName="EmbalajeCant")]
		public short gxTpr_Embalajecant
		{
			get {
				return gxTv_SdtSDTCarga_SDTCargaItem_Embalajecant; 
			}
			set {
				gxTv_SdtSDTCarga_SDTCargaItem_Embalajecant = value;
				SetDirty("Embalajecant");
			}
		}




		[SoapElement(ElementName="Elevacion")]
		[XmlElement(ElementName="Elevacion")]
		public bool gxTpr_Elevacion
		{
			get {
				return gxTv_SdtSDTCarga_SDTCargaItem_Elevacion; 
			}
			set {
				gxTv_SdtSDTCarga_SDTCargaItem_Elevacion = value;
				SetDirty("Elevacion");
			}
		}




		[SoapElement(ElementName="ElevacionCant")]
		[XmlElement(ElementName="ElevacionCant")]
		public short gxTpr_Elevacioncant
		{
			get {
				return gxTv_SdtSDTCarga_SDTCargaItem_Elevacioncant; 
			}
			set {
				gxTv_SdtSDTCarga_SDTCargaItem_Elevacioncant = value;
				SetDirty("Elevacioncant");
			}
		}




		[SoapElement(ElementName="Activo")]
		[XmlElement(ElementName="Activo")]
		public bool gxTpr_Activo
		{
			get {
				return gxTv_SdtSDTCarga_SDTCargaItem_Activo; 
			}
			set {
				gxTv_SdtSDTCarga_SDTCargaItem_Activo = value;
				SetDirty("Activo");
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
			gxTv_SdtSDTCarga_SDTCargaItem_Tipo = "";
			gxTv_SdtSDTCarga_SDTCargaItem_Titulo = "";
			gxTv_SdtSDTCarga_SDTCargaItem_Nombre = "";
			gxTv_SdtSDTCarga_SDTCargaItem_Descripcion = "";

			gxTv_SdtSDTCarga_SDTCargaItem_Unidad = "";

			gxTv_SdtSDTCarga_SDTCargaItem_Imagen = "";gxTv_SdtSDTCarga_SDTCargaItem_Imagen_gxi = "";





			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTCarga_SDTCargaItem_Id;
		 

		protected string gxTv_SdtSDTCarga_SDTCargaItem_Tipo;
		 

		protected string gxTv_SdtSDTCarga_SDTCargaItem_Titulo;
		 

		protected string gxTv_SdtSDTCarga_SDTCargaItem_Nombre;
		 

		protected string gxTv_SdtSDTCarga_SDTCargaItem_Descripcion;
		 

		protected decimal gxTv_SdtSDTCarga_SDTCargaItem_Valor;
		 

		protected string gxTv_SdtSDTCarga_SDTCargaItem_Unidad;
		 

		protected short gxTv_SdtSDTCarga_SDTCargaItem_Cantidad;
		 
		protected string gxTv_SdtSDTCarga_SDTCargaItem_Imagen_gxi;
		protected string gxTv_SdtSDTCarga_SDTCargaItem_Imagen;
		 

		protected bool gxTv_SdtSDTCarga_SDTCargaItem_Embalaje;
		 

		protected short gxTv_SdtSDTCarga_SDTCargaItem_Embalajecant;
		 

		protected bool gxTv_SdtSDTCarga_SDTCargaItem_Elevacion;
		 

		protected short gxTv_SdtSDTCarga_SDTCargaItem_Elevacioncant;
		 

		protected bool gxTv_SdtSDTCarga_SDTCargaItem_Activo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTCargaItem", Namespace="AlmangoX")]
	public class SdtSDTCarga_SDTCargaItem_RESTInterface : GxGenericCollectionItem<SdtSDTCarga_SDTCargaItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCarga_SDTCargaItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCarga_SDTCargaItem_RESTInterface( SdtSDTCarga_SDTCargaItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Id", Order=0)]
		public short gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="Tipo", Order=1)]
		public  string gxTpr_Tipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tipo);

			}
			set { 
				 sdt.gxTpr_Tipo = value;
			}
		}

		[DataMember(Name="Titulo", Order=2)]
		public  string gxTpr_Titulo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Titulo);

			}
			set { 
				 sdt.gxTpr_Titulo = value;
			}
		}

		[DataMember(Name="Nombre", Order=3)]
		public  string gxTpr_Nombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nombre);

			}
			set { 
				 sdt.gxTpr_Nombre = value;
			}
		}

		[DataMember(Name="Descripcion", Order=4)]
		public  string gxTpr_Descripcion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Descripcion);

			}
			set { 
				 sdt.gxTpr_Descripcion = value;
			}
		}

		[DataMember(Name="Valor", Order=5)]
		public  string gxTpr_Valor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valor, 18, 2));

			}
			set { 
				sdt.gxTpr_Valor =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Unidad", Order=6)]
		public  string gxTpr_Unidad
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Unidad);

			}
			set { 
				 sdt.gxTpr_Unidad = value;
			}
		}

		[DataMember(Name="Cantidad", Order=7)]
		public short gxTpr_Cantidad
		{
			get { 
				return sdt.gxTpr_Cantidad;

			}
			set { 
				sdt.gxTpr_Cantidad = value;
			}
		}

		[DataMember(Name="Imagen", Order=8)]
		[GxUpload()]
		public  string gxTpr_Imagen
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Imagen)) ? PathUtil.RelativePath( sdt.gxTpr_Imagen) : StringUtil.RTrim( sdt.gxTpr_Imagen_gxi));

			}
			set { 
				 sdt.gxTpr_Imagen = value;
			}
		}

		[DataMember(Name="Embalaje", Order=9)]
		public bool gxTpr_Embalaje
		{
			get { 
				return sdt.gxTpr_Embalaje;

			}
			set { 
				sdt.gxTpr_Embalaje = value;
			}
		}

		[DataMember(Name="EmbalajeCant", Order=10)]
		public short gxTpr_Embalajecant
		{
			get { 
				return sdt.gxTpr_Embalajecant;

			}
			set { 
				sdt.gxTpr_Embalajecant = value;
			}
		}

		[DataMember(Name="Elevacion", Order=11)]
		public bool gxTpr_Elevacion
		{
			get { 
				return sdt.gxTpr_Elevacion;

			}
			set { 
				sdt.gxTpr_Elevacion = value;
			}
		}

		[DataMember(Name="ElevacionCant", Order=12)]
		public short gxTpr_Elevacioncant
		{
			get { 
				return sdt.gxTpr_Elevacioncant;

			}
			set { 
				sdt.gxTpr_Elevacioncant = value;
			}
		}

		[DataMember(Name="Activo", Order=13)]
		public bool gxTpr_Activo
		{
			get { 
				return sdt.gxTpr_Activo;

			}
			set { 
				sdt.gxTpr_Activo = value;
			}
		}


		#endregion
		public SdtSDTCarga_SDTCargaItem sdt
		{
			get { 
				return (SdtSDTCarga_SDTCargaItem)Sdt;
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
				sdt = new SdtSDTCarga_SDTCargaItem() ;
			}
		}
	}
	#endregion
}