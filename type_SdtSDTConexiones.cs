/*
				   File: type_SdtSDTConexiones
			Description: SDTConexiones
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
	[XmlRoot(ElementName="SDTConexiones")]
	[XmlType(TypeName="SDTConexiones" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTConexiones : GxUserType
	{
		public SdtSDTConexiones( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTConexiones_Conexionesid = "";

			gxTv_SdtSDTConexiones_Conexionesnombre = "";

			gxTv_SdtSDTConexiones_Conexioneshost = "";

			gxTv_SdtSDTConexiones_Conexionesbaseurl = "";

			gxTv_SdtSDTConexiones_Conexionesapikey = "";

			gxTv_SdtSDTConexiones_Conexionesusr = "";

			gxTv_SdtSDTConexiones_Conexionesaux1 = "";

			gxTv_SdtSDTConexiones_Conexionesaux2 = "";

			gxTv_SdtSDTConexiones_Conexionesaux3 = "";

			gxTv_SdtSDTConexiones_Conexionesestado = "";

		}

		public SdtSDTConexiones(IGxContext context)
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
			AddObjectProperty("ConexionesID", gxTpr_Conexionesid, false);


			AddObjectProperty("ConexionesNombre", gxTpr_Conexionesnombre, false);


			AddObjectProperty("ConexionesHost", gxTpr_Conexioneshost, false);


			AddObjectProperty("ConexionesBaseURL", gxTpr_Conexionesbaseurl, false);


			AddObjectProperty("ConexionesPort", gxTpr_Conexionesport, false);


			AddObjectProperty("ConexionesApiKey", gxTpr_Conexionesapikey, false);


			AddObjectProperty("ConexionesUsr", gxTpr_Conexionesusr, false);


			AddObjectProperty("ConexionesAux1", gxTpr_Conexionesaux1, false);


			AddObjectProperty("ConexionesAux2", gxTpr_Conexionesaux2, false);


			AddObjectProperty("ConexionesAux3", gxTpr_Conexionesaux3, false);


			AddObjectProperty("ConexionesEstado", gxTpr_Conexionesestado, false);

			if (gxTv_SdtSDTConexiones_Datos != null)
			{
				AddObjectProperty("Datos", gxTv_SdtSDTConexiones_Datos, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ConexionesID")]
		[XmlElement(ElementName="ConexionesID")]
		public string gxTpr_Conexionesid
		{
			get {
				return gxTv_SdtSDTConexiones_Conexionesid; 
			}
			set {
				gxTv_SdtSDTConexiones_Conexionesid = value;
				SetDirty("Conexionesid");
			}
		}




		[SoapElement(ElementName="ConexionesNombre")]
		[XmlElement(ElementName="ConexionesNombre")]
		public string gxTpr_Conexionesnombre
		{
			get {
				return gxTv_SdtSDTConexiones_Conexionesnombre; 
			}
			set {
				gxTv_SdtSDTConexiones_Conexionesnombre = value;
				SetDirty("Conexionesnombre");
			}
		}




		[SoapElement(ElementName="ConexionesHost")]
		[XmlElement(ElementName="ConexionesHost")]
		public string gxTpr_Conexioneshost
		{
			get {
				return gxTv_SdtSDTConexiones_Conexioneshost; 
			}
			set {
				gxTv_SdtSDTConexiones_Conexioneshost = value;
				SetDirty("Conexioneshost");
			}
		}




		[SoapElement(ElementName="ConexionesBaseURL")]
		[XmlElement(ElementName="ConexionesBaseURL")]
		public string gxTpr_Conexionesbaseurl
		{
			get {
				return gxTv_SdtSDTConexiones_Conexionesbaseurl; 
			}
			set {
				gxTv_SdtSDTConexiones_Conexionesbaseurl = value;
				SetDirty("Conexionesbaseurl");
			}
		}




		[SoapElement(ElementName="ConexionesPort")]
		[XmlElement(ElementName="ConexionesPort")]
		public int gxTpr_Conexionesport
		{
			get {
				return gxTv_SdtSDTConexiones_Conexionesport; 
			}
			set {
				gxTv_SdtSDTConexiones_Conexionesport = value;
				SetDirty("Conexionesport");
			}
		}




		[SoapElement(ElementName="ConexionesApiKey")]
		[XmlElement(ElementName="ConexionesApiKey")]
		public string gxTpr_Conexionesapikey
		{
			get {
				return gxTv_SdtSDTConexiones_Conexionesapikey; 
			}
			set {
				gxTv_SdtSDTConexiones_Conexionesapikey = value;
				SetDirty("Conexionesapikey");
			}
		}




		[SoapElement(ElementName="ConexionesUsr")]
		[XmlElement(ElementName="ConexionesUsr")]
		public string gxTpr_Conexionesusr
		{
			get {
				return gxTv_SdtSDTConexiones_Conexionesusr; 
			}
			set {
				gxTv_SdtSDTConexiones_Conexionesusr = value;
				SetDirty("Conexionesusr");
			}
		}




		[SoapElement(ElementName="ConexionesAux1")]
		[XmlElement(ElementName="ConexionesAux1")]
		public string gxTpr_Conexionesaux1
		{
			get {
				return gxTv_SdtSDTConexiones_Conexionesaux1; 
			}
			set {
				gxTv_SdtSDTConexiones_Conexionesaux1 = value;
				SetDirty("Conexionesaux1");
			}
		}




		[SoapElement(ElementName="ConexionesAux2")]
		[XmlElement(ElementName="ConexionesAux2")]
		public string gxTpr_Conexionesaux2
		{
			get {
				return gxTv_SdtSDTConexiones_Conexionesaux2; 
			}
			set {
				gxTv_SdtSDTConexiones_Conexionesaux2 = value;
				SetDirty("Conexionesaux2");
			}
		}




		[SoapElement(ElementName="ConexionesAux3")]
		[XmlElement(ElementName="ConexionesAux3")]
		public string gxTpr_Conexionesaux3
		{
			get {
				return gxTv_SdtSDTConexiones_Conexionesaux3; 
			}
			set {
				gxTv_SdtSDTConexiones_Conexionesaux3 = value;
				SetDirty("Conexionesaux3");
			}
		}




		[SoapElement(ElementName="ConexionesEstado")]
		[XmlElement(ElementName="ConexionesEstado")]
		public string gxTpr_Conexionesestado
		{
			get {
				return gxTv_SdtSDTConexiones_Conexionesestado; 
			}
			set {
				gxTv_SdtSDTConexiones_Conexionesestado = value;
				SetDirty("Conexionesestado");
			}
		}




		[SoapElement(ElementName="Datos" )]
		[XmlArray(ElementName="Datos"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<SdtSDTConexiones_Item> gxTpr_Datos
		{
			get {
				if ( gxTv_SdtSDTConexiones_Datos == null )
				{
					gxTv_SdtSDTConexiones_Datos = new GXBaseCollection<SdtSDTConexiones_Item>( context, "SDTConexiones.Item", "");
				}
				SetDirty("Datos");
				return gxTv_SdtSDTConexiones_Datos;
			}
			set {
				gxTv_SdtSDTConexiones_Datos_N = false;
				gxTv_SdtSDTConexiones_Datos = value;
				SetDirty("Datos");
			}
		}

		public void gxTv_SdtSDTConexiones_Datos_SetNull()
		{
			gxTv_SdtSDTConexiones_Datos_N = true;
			gxTv_SdtSDTConexiones_Datos = null;
		}

		public bool gxTv_SdtSDTConexiones_Datos_IsNull()
		{
			return gxTv_SdtSDTConexiones_Datos == null;
		}
		public bool ShouldSerializegxTpr_Datos_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTConexiones_Datos != null && gxTv_SdtSDTConexiones_Datos.Count > 0;

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
			gxTv_SdtSDTConexiones_Conexionesid = "";
			gxTv_SdtSDTConexiones_Conexionesnombre = "";
			gxTv_SdtSDTConexiones_Conexioneshost = "";
			gxTv_SdtSDTConexiones_Conexionesbaseurl = "";

			gxTv_SdtSDTConexiones_Conexionesapikey = "";
			gxTv_SdtSDTConexiones_Conexionesusr = "";
			gxTv_SdtSDTConexiones_Conexionesaux1 = "";
			gxTv_SdtSDTConexiones_Conexionesaux2 = "";
			gxTv_SdtSDTConexiones_Conexionesaux3 = "";
			gxTv_SdtSDTConexiones_Conexionesestado = "";

			gxTv_SdtSDTConexiones_Datos_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTConexiones_Conexionesid;
		 

		protected string gxTv_SdtSDTConexiones_Conexionesnombre;
		 

		protected string gxTv_SdtSDTConexiones_Conexioneshost;
		 

		protected string gxTv_SdtSDTConexiones_Conexionesbaseurl;
		 

		protected int gxTv_SdtSDTConexiones_Conexionesport;
		 

		protected string gxTv_SdtSDTConexiones_Conexionesapikey;
		 

		protected string gxTv_SdtSDTConexiones_Conexionesusr;
		 

		protected string gxTv_SdtSDTConexiones_Conexionesaux1;
		 

		protected string gxTv_SdtSDTConexiones_Conexionesaux2;
		 

		protected string gxTv_SdtSDTConexiones_Conexionesaux3;
		 

		protected string gxTv_SdtSDTConexiones_Conexionesestado;
		 
		protected bool gxTv_SdtSDTConexiones_Datos_N;
		protected GXBaseCollection<SdtSDTConexiones_Item> gxTv_SdtSDTConexiones_Datos = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTConexiones", Namespace="AlmangoX")]
	public class SdtSDTConexiones_RESTInterface : GxGenericCollectionItem<SdtSDTConexiones>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTConexiones_RESTInterface( ) : base()
		{	
		}

		public SdtSDTConexiones_RESTInterface( SdtSDTConexiones psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ConexionesID", Order=0)]
		public  string gxTpr_Conexionesid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Conexionesid);

			}
			set { 
				 sdt.gxTpr_Conexionesid = value;
			}
		}

		[DataMember(Name="ConexionesNombre", Order=1)]
		public  string gxTpr_Conexionesnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Conexionesnombre);

			}
			set { 
				 sdt.gxTpr_Conexionesnombre = value;
			}
		}

		[DataMember(Name="ConexionesHost", Order=2)]
		public  string gxTpr_Conexioneshost
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Conexioneshost);

			}
			set { 
				 sdt.gxTpr_Conexioneshost = value;
			}
		}

		[DataMember(Name="ConexionesBaseURL", Order=3)]
		public  string gxTpr_Conexionesbaseurl
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Conexionesbaseurl);

			}
			set { 
				 sdt.gxTpr_Conexionesbaseurl = value;
			}
		}

		[DataMember(Name="ConexionesPort", Order=4)]
		public  string gxTpr_Conexionesport
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Conexionesport, 9, 0));

			}
			set { 
				sdt.gxTpr_Conexionesport = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ConexionesApiKey", Order=5)]
		public  string gxTpr_Conexionesapikey
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Conexionesapikey);

			}
			set { 
				 sdt.gxTpr_Conexionesapikey = value;
			}
		}

		[DataMember(Name="ConexionesUsr", Order=6)]
		public  string gxTpr_Conexionesusr
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Conexionesusr);

			}
			set { 
				 sdt.gxTpr_Conexionesusr = value;
			}
		}

		[DataMember(Name="ConexionesAux1", Order=7)]
		public  string gxTpr_Conexionesaux1
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Conexionesaux1);

			}
			set { 
				 sdt.gxTpr_Conexionesaux1 = value;
			}
		}

		[DataMember(Name="ConexionesAux2", Order=8)]
		public  string gxTpr_Conexionesaux2
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Conexionesaux2);

			}
			set { 
				 sdt.gxTpr_Conexionesaux2 = value;
			}
		}

		[DataMember(Name="ConexionesAux3", Order=9)]
		public  string gxTpr_Conexionesaux3
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Conexionesaux3);

			}
			set { 
				 sdt.gxTpr_Conexionesaux3 = value;
			}
		}

		[DataMember(Name="ConexionesEstado", Order=10)]
		public  string gxTpr_Conexionesestado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Conexionesestado);

			}
			set { 
				 sdt.gxTpr_Conexionesestado = value;
			}
		}

		[DataMember(Name="Datos", Order=11, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTConexiones_Item_RESTInterface> gxTpr_Datos
		{
			get {
				if (sdt.ShouldSerializegxTpr_Datos_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTConexiones_Item_RESTInterface>(sdt.gxTpr_Datos);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Datos);
			}
		}


		#endregion
		public SdtSDTConexiones sdt
		{
			get { 
				return (SdtSDTConexiones)Sdt;
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
				sdt = new SdtSDTConexiones() ;
			}
		}
	}
	#endregion
}