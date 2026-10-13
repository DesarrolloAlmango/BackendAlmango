/*
				   File: type_SdtSDTUser
			Description: SDTUser
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
	[XmlRoot(ElementName="SDTUser")]
	[XmlType(TypeName="SDTUser" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTUser : GxUserType
	{
		public SdtSDTUser( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTUser_Usuariosid = "";

			gxTv_SdtSDTUser_Usuariospassw = "";

			gxTv_SdtSDTUser_Usuariosnombre = "";

			gxTv_SdtSDTUser_Paisid = "";

			gxTv_SdtSDTUser_Tipousuario = "";

			gxTv_SdtSDTUser_Profesionalesid = "";

			gxTv_SdtSDTUser_Usuarioscorreo = "";

			gxTv_SdtSDTUser_Usuariosdireccion = "";

			gxTv_SdtSDTUser_Usuariostelefono = "";

			gxTv_SdtSDTUser_Usuariosimagen = "";
			gxTv_SdtSDTUser_Usuariosimagen_gxi = "";

			gxTv_SdtSDTUser_Usuariosurl = "";

			gxTv_SdtSDTUser_Usuariosestado = "";

			gxTv_SdtSDTUser_Sdtroles_N = true;


		}

		public SdtSDTUser(IGxContext context)
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
			AddObjectProperty("UsuariosID", gxTpr_Usuariosid, false);


			AddObjectProperty("UsuariosPassw", gxTpr_Usuariospassw, false);


			AddObjectProperty("usuariosNombre", gxTpr_Usuariosnombre, false);


			AddObjectProperty("PaisId", gxTpr_Paisid, false);


			AddObjectProperty("tipoUsuario", gxTpr_Tipousuario, false);


			AddObjectProperty("ProfesionalesId", gxTpr_Profesionalesid, false);


			AddObjectProperty("usuariosCorreo", gxTpr_Usuarioscorreo, false);


			AddObjectProperty("usuariosDireccion", gxTpr_Usuariosdireccion, false);


			AddObjectProperty("usuariosCPostal", gxTpr_Usuarioscpostal, false);


			AddObjectProperty("usuariosTelefono", gxTpr_Usuariostelefono, false);


			AddObjectProperty("usuariosImagen", gxTpr_Usuariosimagen, false);
			AddObjectProperty("usuariosImagen_GXI", gxTpr_Usuariosimagen_gxi, false);



			AddObjectProperty("usuariosUrl", gxTpr_Usuariosurl, false);


			AddObjectProperty("usuariosEstado", gxTpr_Usuariosestado, false);

			if (gxTv_SdtSDTUser_Sdtroles != null)
			{
				AddObjectProperty("SdtRoles", gxTv_SdtSDTUser_Sdtroles, false);
			}

			AddObjectProperty("secUserId", gxTpr_Secuserid, false);


			AddObjectProperty("UsuarioTieneRubro", gxTpr_Usuariotienerubro, false);


			AddObjectProperty("NotificarPostulacion", gxTpr_Notificarpostulacion, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="UsuariosID")]
		[XmlElement(ElementName="UsuariosID")]
		public string gxTpr_Usuariosid
		{
			get {
				return gxTv_SdtSDTUser_Usuariosid; 
			}
			set {
				gxTv_SdtSDTUser_Usuariosid = value;
				SetDirty("Usuariosid");
			}
		}




		[SoapElement(ElementName="UsuariosPassw")]
		[XmlElement(ElementName="UsuariosPassw")]
		public string gxTpr_Usuariospassw
		{
			get {
				return gxTv_SdtSDTUser_Usuariospassw; 
			}
			set {
				gxTv_SdtSDTUser_Usuariospassw = value;
				SetDirty("Usuariospassw");
			}
		}




		[SoapElement(ElementName="usuariosNombre")]
		[XmlElement(ElementName="usuariosNombre")]
		public string gxTpr_Usuariosnombre
		{
			get {
				return gxTv_SdtSDTUser_Usuariosnombre; 
			}
			set {
				gxTv_SdtSDTUser_Usuariosnombre = value;
				SetDirty("Usuariosnombre");
			}
		}




		[SoapElement(ElementName="PaisId")]
		[XmlElement(ElementName="PaisId")]
		public string gxTpr_Paisid
		{
			get {
				return gxTv_SdtSDTUser_Paisid; 
			}
			set {
				gxTv_SdtSDTUser_Paisid = value;
				SetDirty("Paisid");
			}
		}




		[SoapElement(ElementName="tipoUsuario")]
		[XmlElement(ElementName="tipoUsuario")]
		public string gxTpr_Tipousuario
		{
			get {
				return gxTv_SdtSDTUser_Tipousuario; 
			}
			set {
				gxTv_SdtSDTUser_Tipousuario = value;
				SetDirty("Tipousuario");
			}
		}




		[SoapElement(ElementName="ProfesionalesId")]
		[XmlElement(ElementName="ProfesionalesId")]
		public string gxTpr_Profesionalesid
		{
			get {
				return gxTv_SdtSDTUser_Profesionalesid; 
			}
			set {
				gxTv_SdtSDTUser_Profesionalesid = value;
				SetDirty("Profesionalesid");
			}
		}




		[SoapElement(ElementName="usuariosCorreo")]
		[XmlElement(ElementName="usuariosCorreo")]
		public string gxTpr_Usuarioscorreo
		{
			get {
				return gxTv_SdtSDTUser_Usuarioscorreo; 
			}
			set {
				gxTv_SdtSDTUser_Usuarioscorreo = value;
				SetDirty("Usuarioscorreo");
			}
		}




		[SoapElement(ElementName="usuariosDireccion")]
		[XmlElement(ElementName="usuariosDireccion")]
		public string gxTpr_Usuariosdireccion
		{
			get {
				return gxTv_SdtSDTUser_Usuariosdireccion; 
			}
			set {
				gxTv_SdtSDTUser_Usuariosdireccion = value;
				SetDirty("Usuariosdireccion");
			}
		}




		[SoapElement(ElementName="usuariosCPostal")]
		[XmlElement(ElementName="usuariosCPostal")]
		public int gxTpr_Usuarioscpostal
		{
			get {
				return gxTv_SdtSDTUser_Usuarioscpostal; 
			}
			set {
				gxTv_SdtSDTUser_Usuarioscpostal = value;
				SetDirty("Usuarioscpostal");
			}
		}




		[SoapElement(ElementName="usuariosTelefono")]
		[XmlElement(ElementName="usuariosTelefono")]
		public string gxTpr_Usuariostelefono
		{
			get {
				return gxTv_SdtSDTUser_Usuariostelefono; 
			}
			set {
				gxTv_SdtSDTUser_Usuariostelefono = value;
				SetDirty("Usuariostelefono");
			}
		}




		[SoapElement(ElementName="usuariosImagen")]
		[XmlElement(ElementName="usuariosImagen")]
		[GxUpload()]

		public string gxTpr_Usuariosimagen
		{
			get {
				return gxTv_SdtSDTUser_Usuariosimagen; 
			}
			set {
				gxTv_SdtSDTUser_Usuariosimagen = value;
				SetDirty("Usuariosimagen");
			}
		}


		[SoapElement(ElementName="usuariosImagen_GXI" )]
		[XmlElement(ElementName="usuariosImagen_GXI" )]
		public string gxTpr_Usuariosimagen_gxi
		{
			get {
				return gxTv_SdtSDTUser_Usuariosimagen_gxi ;
			}
			set {
				gxTv_SdtSDTUser_Usuariosimagen_gxi = value;
				SetDirty("Usuariosimagen_gxi");
			}
		}

		[SoapElement(ElementName="usuariosUrl")]
		[XmlElement(ElementName="usuariosUrl")]
		public string gxTpr_Usuariosurl
		{
			get {
				return gxTv_SdtSDTUser_Usuariosurl; 
			}
			set {
				gxTv_SdtSDTUser_Usuariosurl = value;
				SetDirty("Usuariosurl");
			}
		}




		[SoapElement(ElementName="usuariosEstado")]
		[XmlElement(ElementName="usuariosEstado")]
		public string gxTpr_Usuariosestado
		{
			get {
				return gxTv_SdtSDTUser_Usuariosestado; 
			}
			set {
				gxTv_SdtSDTUser_Usuariosestado = value;
				SetDirty("Usuariosestado");
			}
		}



		[SoapElement(ElementName="SdtRoles")]
		[XmlElement(ElementName="SdtRoles")]
		public GeneXus.Programs.SdtSDTRoles gxTpr_Sdtroles
		{
			get {
				if ( gxTv_SdtSDTUser_Sdtroles == null )
				{
					gxTv_SdtSDTUser_Sdtroles = new GeneXus.Programs.SdtSDTRoles(context);
					SetDirty("Sdtroles");
				}
				return gxTv_SdtSDTUser_Sdtroles; 
			}
			set {
				gxTv_SdtSDTUser_Sdtroles = value;
				SetDirty("Sdtroles");
			}
		}
		public void gxTv_SdtSDTUser_Sdtroles_SetNull()
		{
			gxTv_SdtSDTUser_Sdtroles_N = true;
			gxTv_SdtSDTUser_Sdtroles = null;
		}

		public bool gxTv_SdtSDTUser_Sdtroles_IsNull()
		{
			return gxTv_SdtSDTUser_Sdtroles == null;
		}
		public bool ShouldSerializegxTpr_Sdtroles_Json()
		{
			return gxTv_SdtSDTUser_Sdtroles != null;

		}


		[SoapElement(ElementName="secUserId")]
		[XmlElement(ElementName="secUserId")]
		public long gxTpr_Secuserid
		{
			get {
				return gxTv_SdtSDTUser_Secuserid; 
			}
			set {
				gxTv_SdtSDTUser_Secuserid = value;
				SetDirty("Secuserid");
			}
		}




		[SoapElement(ElementName="UsuarioTieneRubro")]
		[XmlElement(ElementName="UsuarioTieneRubro")]
		public bool gxTpr_Usuariotienerubro
		{
			get {
				return gxTv_SdtSDTUser_Usuariotienerubro; 
			}
			set {
				gxTv_SdtSDTUser_Usuariotienerubro = value;
				SetDirty("Usuariotienerubro");
			}
		}




		[SoapElement(ElementName="NotificarPostulacion")]
		[XmlElement(ElementName="NotificarPostulacion")]
		public bool gxTpr_Notificarpostulacion
		{
			get {
				return gxTv_SdtSDTUser_Notificarpostulacion; 
			}
			set {
				gxTv_SdtSDTUser_Notificarpostulacion = value;
				SetDirty("Notificarpostulacion");
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
			gxTv_SdtSDTUser_Usuariosid = "";
			gxTv_SdtSDTUser_Usuariospassw = "";
			gxTv_SdtSDTUser_Usuariosnombre = "";
			gxTv_SdtSDTUser_Paisid = "";
			gxTv_SdtSDTUser_Tipousuario = "";
			gxTv_SdtSDTUser_Profesionalesid = "";
			gxTv_SdtSDTUser_Usuarioscorreo = "";
			gxTv_SdtSDTUser_Usuariosdireccion = "";

			gxTv_SdtSDTUser_Usuariostelefono = "";
			gxTv_SdtSDTUser_Usuariosimagen = "";gxTv_SdtSDTUser_Usuariosimagen_gxi = "";
			gxTv_SdtSDTUser_Usuariosurl = "";
			gxTv_SdtSDTUser_Usuariosestado = "";

			gxTv_SdtSDTUser_Sdtroles_N = true;




			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTUser_Usuariosid;
		 

		protected string gxTv_SdtSDTUser_Usuariospassw;
		 

		protected string gxTv_SdtSDTUser_Usuariosnombre;
		 

		protected string gxTv_SdtSDTUser_Paisid;
		 

		protected string gxTv_SdtSDTUser_Tipousuario;
		 

		protected string gxTv_SdtSDTUser_Profesionalesid;
		 

		protected string gxTv_SdtSDTUser_Usuarioscorreo;
		 

		protected string gxTv_SdtSDTUser_Usuariosdireccion;
		 

		protected int gxTv_SdtSDTUser_Usuarioscpostal;
		 

		protected string gxTv_SdtSDTUser_Usuariostelefono;
		 
		protected string gxTv_SdtSDTUser_Usuariosimagen_gxi;
		protected string gxTv_SdtSDTUser_Usuariosimagen;
		 

		protected string gxTv_SdtSDTUser_Usuariosurl;
		 

		protected string gxTv_SdtSDTUser_Usuariosestado;
		 

		protected GeneXus.Programs.SdtSDTRoles gxTv_SdtSDTUser_Sdtroles = null;
		protected bool gxTv_SdtSDTUser_Sdtroles_N;
		 

		protected long gxTv_SdtSDTUser_Secuserid;
		 

		protected bool gxTv_SdtSDTUser_Usuariotienerubro;
		 

		protected bool gxTv_SdtSDTUser_Notificarpostulacion;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTUser", Namespace="AlmangoX")]
	public class SdtSDTUser_RESTInterface : GxGenericCollectionItem<SdtSDTUser>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTUser_RESTInterface( ) : base()
		{	
		}

		public SdtSDTUser_RESTInterface( SdtSDTUser psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="UsuariosID", Order=0)]
		public  string gxTpr_Usuariosid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosid);

			}
			set { 
				 sdt.gxTpr_Usuariosid = value;
			}
		}

		[DataMember(Name="UsuariosPassw", Order=1)]
		public  string gxTpr_Usuariospassw
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariospassw);

			}
			set { 
				 sdt.gxTpr_Usuariospassw = value;
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

		[DataMember(Name="PaisId", Order=3)]
		public  string gxTpr_Paisid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Paisid);

			}
			set { 
				 sdt.gxTpr_Paisid = value;
			}
		}

		[DataMember(Name="tipoUsuario", Order=4)]
		public  string gxTpr_Tipousuario
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tipousuario);

			}
			set { 
				 sdt.gxTpr_Tipousuario = value;
			}
		}

		[DataMember(Name="ProfesionalesId", Order=5)]
		public  string gxTpr_Profesionalesid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Profesionalesid);

			}
			set { 
				 sdt.gxTpr_Profesionalesid = value;
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

		[DataMember(Name="usuariosCPostal", Order=8)]
		public int gxTpr_Usuarioscpostal
		{
			get { 
				return sdt.gxTpr_Usuarioscpostal;

			}
			set { 
				sdt.gxTpr_Usuarioscpostal = value;
			}
		}

		[DataMember(Name="usuariosTelefono", Order=9)]
		public  string gxTpr_Usuariostelefono
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariostelefono);

			}
			set { 
				 sdt.gxTpr_Usuariostelefono = value;
			}
		}

		[DataMember(Name="usuariosImagen", Order=10)]
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

		[DataMember(Name="usuariosUrl", Order=11)]
		public  string gxTpr_Usuariosurl
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosurl);

			}
			set { 
				 sdt.gxTpr_Usuariosurl = value;
			}
		}

		[DataMember(Name="usuariosEstado", Order=12)]
		public  string gxTpr_Usuariosestado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosestado);

			}
			set { 
				 sdt.gxTpr_Usuariosestado = value;
			}
		}

		[DataMember(Name="SdtRoles", Order=13, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDTRoles_RESTInterface gxTpr_Sdtroles
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Sdtroles_Json())
					return new GeneXus.Programs.SdtSDTRoles_RESTInterface(sdt.gxTpr_Sdtroles);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Sdtroles = value.sdt;
			}
		}

		[DataMember(Name="secUserId", Order=14)]
		public  string gxTpr_Secuserid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Secuserid, 10, 0));

			}
			set { 
				sdt.gxTpr_Secuserid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="UsuarioTieneRubro", Order=15)]
		public bool gxTpr_Usuariotienerubro
		{
			get { 
				return sdt.gxTpr_Usuariotienerubro;

			}
			set { 
				sdt.gxTpr_Usuariotienerubro = value;
			}
		}

		[DataMember(Name="NotificarPostulacion", Order=16)]
		public bool gxTpr_Notificarpostulacion
		{
			get { 
				return sdt.gxTpr_Notificarpostulacion;

			}
			set { 
				sdt.gxTpr_Notificarpostulacion = value;
			}
		}


		#endregion
		public SdtSDTUser sdt
		{
			get { 
				return (SdtSDTUser)Sdt;
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
				sdt = new SdtSDTUser() ;
			}
		}
	}
	#endregion
}