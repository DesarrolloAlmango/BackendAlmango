/*
				   File: type_SdtWWPContext
			Description: WWPContext
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

namespace GeneXus.Programs.wwpbaseobjects
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="WWPContext")]
	[XmlType(TypeName="WWPContext" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtWWPContext : GxUserType
	{
		public SdtWWPContext( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPContext_Username = "";

			gxTv_SdtWWPContext_Usuariosid = "";

			gxTv_SdtWWPContext_Usuariosnombre = "";

			gxTv_SdtWWPContext_Usuariotipo = "";

			gxTv_SdtWWPContext_Usuariopaisid = "";

			gxTv_SdtWWPContext_Usuarioscorreo = "";

			gxTv_SdtWWPContext_Usuariosdireccion = "";

			gxTv_SdtWWPContext_Usuariostelefono = "";

			gxTv_SdtWWPContext_Gxtpr_usuariotip = "";

			gxTv_SdtWWPContext_Profesionalesid = "";

			gxTv_SdtWWPContext_Usuariosimagen = "";
			gxTv_SdtWWPContext_Usuariosimagen_gxi = "";

			gxTv_SdtWWPContext_Usuariourl = "";

			gxTv_SdtWWPContext_Clientesidentidad = "";

			gxTv_SdtWWPContext_Usuariosestado = "";

			gxTv_SdtWWPContext_Roles_N = true;

		}

		public SdtWWPContext(IGxContext context)
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
			AddObjectProperty("UserId", gxTpr_Userid, false);


			AddObjectProperty("UserName", gxTpr_Username, false);


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

			if (gxTv_SdtWWPContext_Roles != null)
			{
				AddObjectProperty("Roles", gxTv_SdtWWPContext_Roles, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="UserId")]
		[XmlElement(ElementName="UserId")]
		public long gxTpr_Userid
		{
			get {
				return gxTv_SdtWWPContext_Userid; 
			}
			set {
				gxTv_SdtWWPContext_Userid = value;
				SetDirty("Userid");
			}
		}




		[SoapElement(ElementName="UserName")]
		[XmlElement(ElementName="UserName")]
		public string gxTpr_Username
		{
			get {
				return gxTv_SdtWWPContext_Username; 
			}
			set {
				gxTv_SdtWWPContext_Username = value;
				SetDirty("Username");
			}
		}




		[SoapElement(ElementName="usuariosId")]
		[XmlElement(ElementName="usuariosId")]
		public string gxTpr_Usuariosid
		{
			get {
				return gxTv_SdtWWPContext_Usuariosid; 
			}
			set {
				gxTv_SdtWWPContext_Usuariosid = value;
				SetDirty("Usuariosid");
			}
		}




		[SoapElement(ElementName="usuariosNombre")]
		[XmlElement(ElementName="usuariosNombre")]
		public string gxTpr_Usuariosnombre
		{
			get {
				return gxTv_SdtWWPContext_Usuariosnombre; 
			}
			set {
				gxTv_SdtWWPContext_Usuariosnombre = value;
				SetDirty("Usuariosnombre");
			}
		}




		[SoapElement(ElementName="UsuarioTipo")]
		[XmlElement(ElementName="UsuarioTipo")]
		public string gxTpr_Usuariotipo
		{
			get {
				return gxTv_SdtWWPContext_Usuariotipo; 
			}
			set {
				gxTv_SdtWWPContext_Usuariotipo = value;
				SetDirty("Usuariotipo");
			}
		}




		[SoapElement(ElementName="UsuarioPaisId")]
		[XmlElement(ElementName="UsuarioPaisId")]
		public string gxTpr_Usuariopaisid
		{
			get {
				return gxTv_SdtWWPContext_Usuariopaisid; 
			}
			set {
				gxTv_SdtWWPContext_Usuariopaisid = value;
				SetDirty("Usuariopaisid");
			}
		}




		[SoapElement(ElementName="usuariosCorreo")]
		[XmlElement(ElementName="usuariosCorreo")]
		public string gxTpr_Usuarioscorreo
		{
			get {
				return gxTv_SdtWWPContext_Usuarioscorreo; 
			}
			set {
				gxTv_SdtWWPContext_Usuarioscorreo = value;
				SetDirty("Usuarioscorreo");
			}
		}




		[SoapElement(ElementName="usuariosDireccion")]
		[XmlElement(ElementName="usuariosDireccion")]
		public string gxTpr_Usuariosdireccion
		{
			get {
				return gxTv_SdtWWPContext_Usuariosdireccion; 
			}
			set {
				gxTv_SdtWWPContext_Usuariosdireccion = value;
				SetDirty("Usuariosdireccion");
			}
		}




		[SoapElement(ElementName="UsuariosCPostal")]
		[XmlElement(ElementName="UsuariosCPostal")]
		public int gxTpr_Usuarioscpostal
		{
			get {
				return gxTv_SdtWWPContext_Usuarioscpostal; 
			}
			set {
				gxTv_SdtWWPContext_Usuarioscpostal = value;
				SetDirty("Usuarioscpostal");
			}
		}




		[SoapElement(ElementName="UsuariosTelefono")]
		[XmlElement(ElementName="UsuariosTelefono")]
		public string gxTpr_Usuariostelefono
		{
			get {
				return gxTv_SdtWWPContext_Usuariostelefono; 
			}
			set {
				gxTv_SdtWWPContext_Usuariostelefono = value;
				SetDirty("Usuariostelefono");
			}
		}




		[SoapElement(ElementName="gxTpr_Usuariotip")]
		[XmlElement(ElementName="gxTpr_Usuariotip")]
		public string gxTpr_Gxtpr_usuariotip
		{
			get {
				return gxTv_SdtWWPContext_Gxtpr_usuariotip; 
			}
			set {
				gxTv_SdtWWPContext_Gxtpr_usuariotip = value;
				SetDirty("Gxtpr_usuariotip");
			}
		}




		[SoapElement(ElementName="ProfesionalesId")]
		[XmlElement(ElementName="ProfesionalesId")]
		public string gxTpr_Profesionalesid
		{
			get {
				return gxTv_SdtWWPContext_Profesionalesid; 
			}
			set {
				gxTv_SdtWWPContext_Profesionalesid = value;
				SetDirty("Profesionalesid");
			}
		}




		[SoapElement(ElementName="usuariosImagen")]
		[XmlElement(ElementName="usuariosImagen")]
		[GxUpload()]

		public string gxTpr_Usuariosimagen
		{
			get {
				return gxTv_SdtWWPContext_Usuariosimagen; 
			}
			set {
				gxTv_SdtWWPContext_Usuariosimagen = value;
				SetDirty("Usuariosimagen");
			}
		}


		[SoapElement(ElementName="usuariosImagen_GXI" )]
		[XmlElement(ElementName="usuariosImagen_GXI" )]
		public string gxTpr_Usuariosimagen_gxi
		{
			get {
				return gxTv_SdtWWPContext_Usuariosimagen_gxi ;
			}
			set {
				gxTv_SdtWWPContext_Usuariosimagen_gxi = value;
				SetDirty("Usuariosimagen_gxi");
			}
		}

		[SoapElement(ElementName="UsuarioURL")]
		[XmlElement(ElementName="UsuarioURL")]
		public string gxTpr_Usuariourl
		{
			get {
				return gxTv_SdtWWPContext_Usuariourl; 
			}
			set {
				gxTv_SdtWWPContext_Usuariourl = value;
				SetDirty("Usuariourl");
			}
		}




		[SoapElement(ElementName="ProveedorID")]
		[XmlElement(ElementName="ProveedorID")]
		public long gxTpr_Proveedorid
		{
			get {
				return gxTv_SdtWWPContext_Proveedorid; 
			}
			set {
				gxTv_SdtWWPContext_Proveedorid = value;
				SetDirty("Proveedorid");
			}
		}




		[SoapElement(ElementName="ClientesID")]
		[XmlElement(ElementName="ClientesID")]
		public long gxTpr_Clientesid
		{
			get {
				return gxTv_SdtWWPContext_Clientesid; 
			}
			set {
				gxTv_SdtWWPContext_Clientesid = value;
				SetDirty("Clientesid");
			}
		}




		[SoapElement(ElementName="ClientesIdentidad")]
		[XmlElement(ElementName="ClientesIdentidad")]
		public string gxTpr_Clientesidentidad
		{
			get {
				return gxTv_SdtWWPContext_Clientesidentidad; 
			}
			set {
				gxTv_SdtWWPContext_Clientesidentidad = value;
				SetDirty("Clientesidentidad");
			}
		}




		[SoapElement(ElementName="usuariosEstado")]
		[XmlElement(ElementName="usuariosEstado")]
		public string gxTpr_Usuariosestado
		{
			get {
				return gxTv_SdtWWPContext_Usuariosestado; 
			}
			set {
				gxTv_SdtWWPContext_Usuariosestado = value;
				SetDirty("Usuariosestado");
			}
		}



		[SoapElement(ElementName="Roles")]
		[XmlElement(ElementName="Roles")]
		public GeneXus.Programs.SdtSDTRoles gxTpr_Roles
		{
			get {
				if ( gxTv_SdtWWPContext_Roles == null )
				{
					gxTv_SdtWWPContext_Roles = new GeneXus.Programs.SdtSDTRoles(context);
					SetDirty("Roles");
				}
				return gxTv_SdtWWPContext_Roles; 
			}
			set {
				gxTv_SdtWWPContext_Roles = value;
				SetDirty("Roles");
			}
		}
		public void gxTv_SdtWWPContext_Roles_SetNull()
		{
			gxTv_SdtWWPContext_Roles_N = true;
			gxTv_SdtWWPContext_Roles = null;
		}

		public bool gxTv_SdtWWPContext_Roles_IsNull()
		{
			return gxTv_SdtWWPContext_Roles == null;
		}
		public bool ShouldSerializegxTpr_Roles_Json()
		{
			return gxTv_SdtWWPContext_Roles != null;

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
			gxTv_SdtWWPContext_Username = "";
			gxTv_SdtWWPContext_Usuariosid = "";
			gxTv_SdtWWPContext_Usuariosnombre = "";
			gxTv_SdtWWPContext_Usuariotipo = "";
			gxTv_SdtWWPContext_Usuariopaisid = "";
			gxTv_SdtWWPContext_Usuarioscorreo = "";
			gxTv_SdtWWPContext_Usuariosdireccion = "";

			gxTv_SdtWWPContext_Usuariostelefono = "";
			gxTv_SdtWWPContext_Gxtpr_usuariotip = "";
			gxTv_SdtWWPContext_Profesionalesid = "";
			gxTv_SdtWWPContext_Usuariosimagen = "";gxTv_SdtWWPContext_Usuariosimagen_gxi = "";
			gxTv_SdtWWPContext_Usuariourl = "";


			gxTv_SdtWWPContext_Clientesidentidad = "";
			gxTv_SdtWWPContext_Usuariosestado = "";

			gxTv_SdtWWPContext_Roles_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtWWPContext_Userid;
		 

		protected string gxTv_SdtWWPContext_Username;
		 

		protected string gxTv_SdtWWPContext_Usuariosid;
		 

		protected string gxTv_SdtWWPContext_Usuariosnombre;
		 

		protected string gxTv_SdtWWPContext_Usuariotipo;
		 

		protected string gxTv_SdtWWPContext_Usuariopaisid;
		 

		protected string gxTv_SdtWWPContext_Usuarioscorreo;
		 

		protected string gxTv_SdtWWPContext_Usuariosdireccion;
		 

		protected int gxTv_SdtWWPContext_Usuarioscpostal;
		 

		protected string gxTv_SdtWWPContext_Usuariostelefono;
		 

		protected string gxTv_SdtWWPContext_Gxtpr_usuariotip;
		 

		protected string gxTv_SdtWWPContext_Profesionalesid;
		 
		protected string gxTv_SdtWWPContext_Usuariosimagen_gxi;
		protected string gxTv_SdtWWPContext_Usuariosimagen;
		 

		protected string gxTv_SdtWWPContext_Usuariourl;
		 

		protected long gxTv_SdtWWPContext_Proveedorid;
		 

		protected long gxTv_SdtWWPContext_Clientesid;
		 

		protected string gxTv_SdtWWPContext_Clientesidentidad;
		 

		protected string gxTv_SdtWWPContext_Usuariosestado;
		 

		protected GeneXus.Programs.SdtSDTRoles gxTv_SdtWWPContext_Roles = null;
		protected bool gxTv_SdtWWPContext_Roles_N;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWPContext", Namespace="AlmangoX")]
	public class SdtWWPContext_RESTInterface : GxGenericCollectionItem<SdtWWPContext>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPContext_RESTInterface( ) : base()
		{	
		}

		public SdtWWPContext_RESTInterface( SdtWWPContext psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="UserId", Order=0)]
		public  string gxTpr_Userid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Userid, 10, 0));

			}
			set { 
				sdt.gxTpr_Userid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="UserName", Order=1)]
		public  string gxTpr_Username
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Username);

			}
			set { 
				 sdt.gxTpr_Username = value;
			}
		}

		[DataMember(Name="usuariosId", Order=2)]
		public  string gxTpr_Usuariosid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosid);

			}
			set { 
				 sdt.gxTpr_Usuariosid = value;
			}
		}

		[DataMember(Name="usuariosNombre", Order=3)]
		public  string gxTpr_Usuariosnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosnombre);

			}
			set { 
				 sdt.gxTpr_Usuariosnombre = value;
			}
		}

		[DataMember(Name="UsuarioTipo", Order=4)]
		public  string gxTpr_Usuariotipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariotipo);

			}
			set { 
				 sdt.gxTpr_Usuariotipo = value;
			}
		}

		[DataMember(Name="UsuarioPaisId", Order=5)]
		public  string gxTpr_Usuariopaisid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariopaisid);

			}
			set { 
				 sdt.gxTpr_Usuariopaisid = value;
			}
		}

		[DataMember(Name="usuariosCorreo", Order=6)]
		public  string gxTpr_Usuarioscorreo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuarioscorreo);

			}
			set { 
				 sdt.gxTpr_Usuarioscorreo = value;
			}
		}

		[DataMember(Name="usuariosDireccion", Order=7)]
		public  string gxTpr_Usuariosdireccion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosdireccion);

			}
			set { 
				 sdt.gxTpr_Usuariosdireccion = value;
			}
		}

		[DataMember(Name="UsuariosCPostal", Order=8)]
		public int gxTpr_Usuarioscpostal
		{
			get { 
				return sdt.gxTpr_Usuarioscpostal;

			}
			set { 
				sdt.gxTpr_Usuarioscpostal = value;
			}
		}

		[DataMember(Name="UsuariosTelefono", Order=9)]
		public  string gxTpr_Usuariostelefono
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariostelefono);

			}
			set { 
				 sdt.gxTpr_Usuariostelefono = value;
			}
		}

		[DataMember(Name="gxTpr_Usuariotip", Order=10)]
		public  string gxTpr_Gxtpr_usuariotip
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Gxtpr_usuariotip);

			}
			set { 
				 sdt.gxTpr_Gxtpr_usuariotip = value;
			}
		}

		[DataMember(Name="ProfesionalesId", Order=11)]
		public  string gxTpr_Profesionalesid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Profesionalesid);

			}
			set { 
				 sdt.gxTpr_Profesionalesid = value;
			}
		}

		[DataMember(Name="usuariosImagen", Order=12)]
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

		[DataMember(Name="UsuarioURL", Order=13)]
		public  string gxTpr_Usuariourl
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariourl);

			}
			set { 
				 sdt.gxTpr_Usuariourl = value;
			}
		}

		[DataMember(Name="ProveedorID", Order=14)]
		public  string gxTpr_Proveedorid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Proveedorid, 18, 0));

			}
			set { 
				sdt.gxTpr_Proveedorid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ClientesID", Order=15)]
		public  string gxTpr_Clientesid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Clientesid, 18, 0));

			}
			set { 
				sdt.gxTpr_Clientesid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ClientesIdentidad", Order=16)]
		public  string gxTpr_Clientesidentidad
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Clientesidentidad);

			}
			set { 
				 sdt.gxTpr_Clientesidentidad = value;
			}
		}

		[DataMember(Name="usuariosEstado", Order=17)]
		public  string gxTpr_Usuariosestado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosestado);

			}
			set { 
				 sdt.gxTpr_Usuariosestado = value;
			}
		}

		[DataMember(Name="Roles", Order=18, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDTRoles_RESTInterface gxTpr_Roles
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Roles_Json())
					return new GeneXus.Programs.SdtSDTRoles_RESTInterface(sdt.gxTpr_Roles);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Roles = value.sdt;
			}
		}


		#endregion
		public SdtWWPContext sdt
		{
			get { 
				return (SdtWWPContext)Sdt;
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
				sdt = new SdtWWPContext() ;
			}
		}
	}
	#endregion
}