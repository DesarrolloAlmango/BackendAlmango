/*
				   File: type_SdtSDTRoles
			Description: SDTRoles
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
	[XmlRoot(ElementName="SDTRoles")]
	[XmlType(TypeName="SDTRoles" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTRoles : GxUserType
	{
		public SdtSDTRoles( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTRoles_Usuariosnombre = "";

		}

		public SdtSDTRoles(IGxContext context)
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
			AddObjectProperty("SecUserId", gxTpr_Secuserid, false);


			AddObjectProperty("usuariosNombre", gxTpr_Usuariosnombre, false);

			if (gxTv_SdtSDTRoles_Roles != null)
			{
				AddObjectProperty("Roles", gxTv_SdtSDTRoles_Roles, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SecUserId")]
		[XmlElement(ElementName="SecUserId")]
		public long gxTpr_Secuserid
		{
			get {
				return gxTv_SdtSDTRoles_Secuserid; 
			}
			set {
				gxTv_SdtSDTRoles_Secuserid = value;
				SetDirty("Secuserid");
			}
		}




		[SoapElement(ElementName="usuariosNombre")]
		[XmlElement(ElementName="usuariosNombre")]
		public string gxTpr_Usuariosnombre
		{
			get {
				return gxTv_SdtSDTRoles_Usuariosnombre; 
			}
			set {
				gxTv_SdtSDTRoles_Usuariosnombre = value;
				SetDirty("Usuariosnombre");
			}
		}




		[SoapElement(ElementName="Roles" )]
		[XmlArray(ElementName="Roles"  )]
		[XmlArrayItemAttribute(ElementName="Id" , IsNullable=false )]
		public GXBaseCollection<SdtSDTRoles_Id> gxTpr_Roles
		{
			get {
				if ( gxTv_SdtSDTRoles_Roles == null )
				{
					gxTv_SdtSDTRoles_Roles = new GXBaseCollection<SdtSDTRoles_Id>( context, "SDTRoles.Id", "");
				}
				SetDirty("Roles");
				return gxTv_SdtSDTRoles_Roles;
			}
			set {
				gxTv_SdtSDTRoles_Roles_N = false;
				gxTv_SdtSDTRoles_Roles = value;
				SetDirty("Roles");
			}
		}

		public void gxTv_SdtSDTRoles_Roles_SetNull()
		{
			gxTv_SdtSDTRoles_Roles_N = true;
			gxTv_SdtSDTRoles_Roles = null;
		}

		public bool gxTv_SdtSDTRoles_Roles_IsNull()
		{
			return gxTv_SdtSDTRoles_Roles == null;
		}
		public bool ShouldSerializegxTpr_Roles_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTRoles_Roles != null && gxTv_SdtSDTRoles_Roles.Count > 0;

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
			gxTv_SdtSDTRoles_Usuariosnombre = "";

			gxTv_SdtSDTRoles_Roles_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTRoles_Secuserid;
		 

		protected string gxTv_SdtSDTRoles_Usuariosnombre;
		 
		protected bool gxTv_SdtSDTRoles_Roles_N;
		protected GXBaseCollection<SdtSDTRoles_Id> gxTv_SdtSDTRoles_Roles = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTRoles", Namespace="AlmangoX")]
	public class SdtSDTRoles_RESTInterface : GxGenericCollectionItem<SdtSDTRoles>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRoles_RESTInterface( ) : base()
		{	
		}

		public SdtSDTRoles_RESTInterface( SdtSDTRoles psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="SecUserId", Order=0)]
		public  string gxTpr_Secuserid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Secuserid, 10, 0));

			}
			set { 
				sdt.gxTpr_Secuserid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="usuariosNombre", Order=1)]
		public  string gxTpr_Usuariosnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosnombre);

			}
			set { 
				 sdt.gxTpr_Usuariosnombre = value;
			}
		}

		[DataMember(Name="Roles", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTRoles_Id_RESTInterface> gxTpr_Roles
		{
			get {
				if (sdt.ShouldSerializegxTpr_Roles_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTRoles_Id_RESTInterface>(sdt.gxTpr_Roles);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Roles);
			}
		}


		#endregion
		public SdtSDTRoles sdt
		{
			get { 
				return (SdtSDTRoles)Sdt;
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
				sdt = new SdtSDTRoles() ;
			}
		}
	}
	#endregion
}