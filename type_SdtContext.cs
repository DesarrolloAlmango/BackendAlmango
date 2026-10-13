/*
				   File: type_SdtContext
			Description: Context
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
	[XmlRoot(ElementName="Context")]
	[XmlType(TypeName="Context" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtContext : GxUserType
	{
		public SdtContext( )
		{
			/* Constructor for serialization */
			gxTv_SdtContext_Userscreenname = "";

			gxTv_SdtContext_Usuariosid = "";

			gxTv_SdtContext_Usuariosnombre = "";

			gxTv_SdtContext_Usuariotipo = "";

			gxTv_SdtContext_Usuariopaisid = "";

			gxTv_SdtContext_Usuarioscorreo = "";

			gxTv_SdtContext_Usuariosdireccion = "";

			gxTv_SdtContext_Usuariostelefono = "";

			gxTv_SdtContext_Gxtpr_usuariotip = "";

			gxTv_SdtContext_Profesionalesid = "";

			gxTv_SdtContext_Usuariosimagen = "";
			gxTv_SdtContext_Usuariosimagen_gxi = "";

			gxTv_SdtContext_Usuariourl = "";

			gxTv_SdtContext_Clientesidentidad = "";

			gxTv_SdtContext_Usuariosestado = "";

		}

		public SdtContext(IGxContext context)
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
			AddObjectProperty("UserScreenName", gxTpr_Userscreenname, false);


			AddObjectProperty("usuariosId", gxTpr_Usuariosid, false);


			AddObjectProperty("usuariosNombre", gxTpr_Usuariosnombre, false);


			AddObjectProperty("UsuarioTipo", gxTpr_Usuariotipo, false);


			AddObjectProperty("UsuarioPaisId", gxTpr_Usuariopaisid, false);


			AddObjectProperty("usuariosCorreo", gxTpr_Usuarioscorreo, false);


			AddObjectProperty("usuariosDireccion", gxTpr_Usuariosdireccion, false);


			AddObjectProperty("UsuariosCPostal", gxTpr_Usuarioscpostal, false);


			AddObjectProperty("UsuariosTelefono", gxTpr_Usuariostelefono, false);


			AddObjectProperty("gxTpr_Usuariotip", gxTpr_Gxtpr_usuariotip, false);


			AddObjectProperty("ProfesionalesId", gxTpr_Profesionalesid, false);


			AddObjectProperty("usuariosImagen", gxTpr_Usuariosimagen, false);
			AddObjectProperty("usuariosImagen_GXI", gxTpr_Usuariosimagen_gxi, false);



			AddObjectProperty("UsuarioURL", gxTpr_Usuariourl, false);


			AddObjectProperty("ProveedorID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Proveedorid, 18, 0)), false);


			AddObjectProperty("ClientesID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Clientesid, 18, 0)), false);


			AddObjectProperty("ClientesIdentidad", gxTpr_Clientesidentidad, false);


			AddObjectProperty("usuariosEstado", gxTpr_Usuariosestado, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="UserScreenName")]
		[XmlElement(ElementName="UserScreenName")]
		public string gxTpr_Userscreenname
		{
			get {
				return gxTv_SdtContext_Userscreenname; 
			}
			set {
				gxTv_SdtContext_Userscreenname = value;
				SetDirty("Userscreenname");
			}
		}




		[SoapElement(ElementName="usuariosId")]
		[XmlElement(ElementName="usuariosId")]
		public string gxTpr_Usuariosid
		{
			get {
				return gxTv_SdtContext_Usuariosid; 
			}
			set {
				gxTv_SdtContext_Usuariosid = value;
				SetDirty("Usuariosid");
			}
		}




		[SoapElement(ElementName="usuariosNombre")]
		[XmlElement(ElementName="usuariosNombre")]
		public string gxTpr_Usuariosnombre
		{
			get {
				return gxTv_SdtContext_Usuariosnombre; 
			}
			set {
				gxTv_SdtContext_Usuariosnombre = value;
				SetDirty("Usuariosnombre");
			}
		}




		[SoapElement(ElementName="UsuarioTipo")]
		[XmlElement(ElementName="UsuarioTipo")]
		public string gxTpr_Usuariotipo
		{
			get {
				return gxTv_SdtContext_Usuariotipo; 
			}
			set {
				gxTv_SdtContext_Usuariotipo = value;
				SetDirty("Usuariotipo");
			}
		}




		[SoapElement(ElementName="UsuarioPaisId")]
		[XmlElement(ElementName="UsuarioPaisId")]
		public string gxTpr_Usuariopaisid
		{
			get {
				return gxTv_SdtContext_Usuariopaisid; 
			}
			set {
				gxTv_SdtContext_Usuariopaisid = value;
				SetDirty("Usuariopaisid");
			}
		}




		[SoapElement(ElementName="usuariosCorreo")]
		[XmlElement(ElementName="usuariosCorreo")]
		public string gxTpr_Usuarioscorreo
		{
			get {
				return gxTv_SdtContext_Usuarioscorreo; 
			}
			set {
				gxTv_SdtContext_Usuarioscorreo = value;
				SetDirty("Usuarioscorreo");
			}
		}




		[SoapElement(ElementName="usuariosDireccion")]
		[XmlElement(ElementName="usuariosDireccion")]
		public string gxTpr_Usuariosdireccion
		{
			get {
				return gxTv_SdtContext_Usuariosdireccion; 
			}
			set {
				gxTv_SdtContext_Usuariosdireccion = value;
				SetDirty("Usuariosdireccion");
			}
		}




		[SoapElement(ElementName="UsuariosCPostal")]
		[XmlElement(ElementName="UsuariosCPostal")]
		public int gxTpr_Usuarioscpostal
		{
			get {
				return gxTv_SdtContext_Usuarioscpostal; 
			}
			set {
				gxTv_SdtContext_Usuarioscpostal = value;
				SetDirty("Usuarioscpostal");
			}
		}




		[SoapElement(ElementName="UsuariosTelefono")]
		[XmlElement(ElementName="UsuariosTelefono")]
		public string gxTpr_Usuariostelefono
		{
			get {
				return gxTv_SdtContext_Usuariostelefono; 
			}
			set {
				gxTv_SdtContext_Usuariostelefono = value;
				SetDirty("Usuariostelefono");
			}
		}




		[SoapElement(ElementName="gxTpr_Usuariotip")]
		[XmlElement(ElementName="gxTpr_Usuariotip")]
		public string gxTpr_Gxtpr_usuariotip
		{
			get {
				return gxTv_SdtContext_Gxtpr_usuariotip; 
			}
			set {
				gxTv_SdtContext_Gxtpr_usuariotip = value;
				SetDirty("Gxtpr_usuariotip");
			}
		}




		[SoapElement(ElementName="ProfesionalesId")]
		[XmlElement(ElementName="ProfesionalesId")]
		public string gxTpr_Profesionalesid
		{
			get {
				return gxTv_SdtContext_Profesionalesid; 
			}
			set {
				gxTv_SdtContext_Profesionalesid = value;
				SetDirty("Profesionalesid");
			}
		}




		[SoapElement(ElementName="usuariosImagen")]
		[XmlElement(ElementName="usuariosImagen")]
		[GxUpload()]

		public string gxTpr_Usuariosimagen
		{
			get {
				return gxTv_SdtContext_Usuariosimagen; 
			}
			set {
				gxTv_SdtContext_Usuariosimagen = value;
				SetDirty("Usuariosimagen");
			}
		}


		[SoapElement(ElementName="usuariosImagen_GXI" )]
		[XmlElement(ElementName="usuariosImagen_GXI" )]
		public string gxTpr_Usuariosimagen_gxi
		{
			get {
				return gxTv_SdtContext_Usuariosimagen_gxi ;
			}
			set {
				gxTv_SdtContext_Usuariosimagen_gxi = value;
				SetDirty("Usuariosimagen_gxi");
			}
		}

		[SoapElement(ElementName="UsuarioURL")]
		[XmlElement(ElementName="UsuarioURL")]
		public string gxTpr_Usuariourl
		{
			get {
				return gxTv_SdtContext_Usuariourl; 
			}
			set {
				gxTv_SdtContext_Usuariourl = value;
				SetDirty("Usuariourl");
			}
		}




		[SoapElement(ElementName="ProveedorID")]
		[XmlElement(ElementName="ProveedorID")]
		public long gxTpr_Proveedorid
		{
			get {
				return gxTv_SdtContext_Proveedorid; 
			}
			set {
				gxTv_SdtContext_Proveedorid = value;
				SetDirty("Proveedorid");
			}
		}




		[SoapElement(ElementName="ClientesID")]
		[XmlElement(ElementName="ClientesID")]
		public long gxTpr_Clientesid
		{
			get {
				return gxTv_SdtContext_Clientesid; 
			}
			set {
				gxTv_SdtContext_Clientesid = value;
				SetDirty("Clientesid");
			}
		}




		[SoapElement(ElementName="ClientesIdentidad")]
		[XmlElement(ElementName="ClientesIdentidad")]
		public string gxTpr_Clientesidentidad
		{
			get {
				return gxTv_SdtContext_Clientesidentidad; 
			}
			set {
				gxTv_SdtContext_Clientesidentidad = value;
				SetDirty("Clientesidentidad");
			}
		}




		[SoapElement(ElementName="usuariosEstado")]
		[XmlElement(ElementName="usuariosEstado")]
		public string gxTpr_Usuariosestado
		{
			get {
				return gxTv_SdtContext_Usuariosestado; 
			}
			set {
				gxTv_SdtContext_Usuariosestado = value;
				SetDirty("Usuariosestado");
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
			gxTv_SdtContext_Userscreenname = "";
			gxTv_SdtContext_Usuariosid = "";
			gxTv_SdtContext_Usuariosnombre = "";
			gxTv_SdtContext_Usuariotipo = "";
			gxTv_SdtContext_Usuariopaisid = "";
			gxTv_SdtContext_Usuarioscorreo = "";
			gxTv_SdtContext_Usuariosdireccion = "";

			gxTv_SdtContext_Usuariostelefono = "";
			gxTv_SdtContext_Gxtpr_usuariotip = "";
			gxTv_SdtContext_Profesionalesid = "";
			gxTv_SdtContext_Usuariosimagen = "";gxTv_SdtContext_Usuariosimagen_gxi = "";
			gxTv_SdtContext_Usuariourl = "";


			gxTv_SdtContext_Clientesidentidad = "";
			gxTv_SdtContext_Usuariosestado = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtContext_Userscreenname;
		 

		protected string gxTv_SdtContext_Usuariosid;
		 

		protected string gxTv_SdtContext_Usuariosnombre;
		 

		protected string gxTv_SdtContext_Usuariotipo;
		 

		protected string gxTv_SdtContext_Usuariopaisid;
		 

		protected string gxTv_SdtContext_Usuarioscorreo;
		 

		protected string gxTv_SdtContext_Usuariosdireccion;
		 

		protected int gxTv_SdtContext_Usuarioscpostal;
		 

		protected string gxTv_SdtContext_Usuariostelefono;
		 

		protected string gxTv_SdtContext_Gxtpr_usuariotip;
		 

		protected string gxTv_SdtContext_Profesionalesid;
		 
		protected string gxTv_SdtContext_Usuariosimagen_gxi;
		protected string gxTv_SdtContext_Usuariosimagen;
		 

		protected string gxTv_SdtContext_Usuariourl;
		 

		protected long gxTv_SdtContext_Proveedorid;
		 

		protected long gxTv_SdtContext_Clientesid;
		 

		protected string gxTv_SdtContext_Clientesidentidad;
		 

		protected string gxTv_SdtContext_Usuariosestado;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"Context", Namespace="AlmangoX")]
	public class SdtContext_RESTInterface : GxGenericCollectionItem<SdtContext>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtContext_RESTInterface( ) : base()
		{	
		}

		public SdtContext_RESTInterface( SdtContext psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="UserScreenName", Order=0)]
		public  string gxTpr_Userscreenname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Userscreenname);

			}
			set { 
				 sdt.gxTpr_Userscreenname = value;
			}
		}

		[DataMember(Name="usuariosId", Order=1)]
		public  string gxTpr_Usuariosid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosid);

			}
			set { 
				 sdt.gxTpr_Usuariosid = value;
			}
		}

		[DataMember(Name="usuariosNombre", Order=2)]
		public  string gxTpr_Usuariosnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosnombre);

			}
			set { 
				 sdt.gxTpr_Usuariosnombre = value;
			}
		}

		[DataMember(Name="UsuarioTipo", Order=3)]
		public  string gxTpr_Usuariotipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariotipo);

			}
			set { 
				 sdt.gxTpr_Usuariotipo = value;
			}
		}

		[DataMember(Name="UsuarioPaisId", Order=4)]
		public  string gxTpr_Usuariopaisid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariopaisid);

			}
			set { 
				 sdt.gxTpr_Usuariopaisid = value;
			}
		}

		[DataMember(Name="usuariosCorreo", Order=5)]
		public  string gxTpr_Usuarioscorreo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuarioscorreo);

			}
			set { 
				 sdt.gxTpr_Usuarioscorreo = value;
			}
		}

		[DataMember(Name="usuariosDireccion", Order=6)]
		public  string gxTpr_Usuariosdireccion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosdireccion);

			}
			set { 
				 sdt.gxTpr_Usuariosdireccion = value;
			}
		}

		[DataMember(Name="UsuariosCPostal", Order=7)]
		public int gxTpr_Usuarioscpostal
		{
			get { 
				return sdt.gxTpr_Usuarioscpostal;

			}
			set { 
				sdt.gxTpr_Usuarioscpostal = value;
			}
		}

		[DataMember(Name="UsuariosTelefono", Order=8)]
		public  string gxTpr_Usuariostelefono
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariostelefono);

			}
			set { 
				 sdt.gxTpr_Usuariostelefono = value;
			}
		}

		[DataMember(Name="gxTpr_Usuariotip", Order=9)]
		public  string gxTpr_Gxtpr_usuariotip
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Gxtpr_usuariotip);

			}
			set { 
				 sdt.gxTpr_Gxtpr_usuariotip = value;
			}
		}

		[DataMember(Name="ProfesionalesId", Order=10)]
		public  string gxTpr_Profesionalesid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Profesionalesid);

			}
			set { 
				 sdt.gxTpr_Profesionalesid = value;
			}
		}

		[DataMember(Name="usuariosImagen", Order=11)]
		[GxUpload()]
		public  string gxTpr_Usuariosimagen
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Usuariosimagen)) ? PathUtil.RelativePath( sdt.gxTpr_Usuariosimagen) : StringUtil.RTrim( sdt.gxTpr_Usuariosimagen_gxi));

			}
			set { 
				 sdt.gxTpr_Usuariosimagen = value;
			}
		}

		[DataMember(Name="UsuarioURL", Order=12)]
		public  string gxTpr_Usuariourl
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariourl);

			}
			set { 
				 sdt.gxTpr_Usuariourl = value;
			}
		}

		[DataMember(Name="ProveedorID", Order=13)]
		public  string gxTpr_Proveedorid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Proveedorid, 18, 0));

			}
			set { 
				sdt.gxTpr_Proveedorid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ClientesID", Order=14)]
		public  string gxTpr_Clientesid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Clientesid, 18, 0));

			}
			set { 
				sdt.gxTpr_Clientesid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ClientesIdentidad", Order=15)]
		public  string gxTpr_Clientesidentidad
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Clientesidentidad);

			}
			set { 
				 sdt.gxTpr_Clientesidentidad = value;
			}
		}

		[DataMember(Name="usuariosEstado", Order=16)]
		public  string gxTpr_Usuariosestado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosestado);

			}
			set { 
				 sdt.gxTpr_Usuariosestado = value;
			}
		}


		#endregion
		public SdtContext sdt
		{
			get { 
				return (SdtContext)Sdt;
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
				sdt = new SdtContext() ;
			}
		}
	}
	#endregion
}