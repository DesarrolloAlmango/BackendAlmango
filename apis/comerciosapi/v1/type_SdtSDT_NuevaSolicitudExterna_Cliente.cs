/*
				   File: type_SdtSDT_NuevaSolicitudExterna_Cliente
			Description: Cliente
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
	[XmlRoot(ElementName="SDT_NuevaSolicitudExterna.Cliente")]
	[XmlType(TypeName="SDT_NuevaSolicitudExterna.Cliente" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDT_NuevaSolicitudExterna_Cliente : GxUserType
	{
		public SdtSDT_NuevaSolicitudExterna_Cliente( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Nombre = "";

			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Email = "";

			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Telefono = "";

		}

		public SdtSDT_NuevaSolicitudExterna_Cliente(IGxContext context)
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
			AddObjectProperty("Nombre", gxTpr_Nombre, false);


			AddObjectProperty("Email", gxTpr_Email, false);


			AddObjectProperty("Telefono", gxTpr_Telefono, false);

			if (gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion != null)
			{
				AddObjectProperty("Direccion", gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Nombre")]
		[XmlElement(ElementName="Nombre")]
		public string gxTpr_Nombre
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Nombre; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Nombre = value;
				SetDirty("Nombre");
			}
		}




		[SoapElement(ElementName="Email")]
		[XmlElement(ElementName="Email")]
		public string gxTpr_Email
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Email; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Email = value;
				SetDirty("Email");
			}
		}




		[SoapElement(ElementName="Telefono")]
		[XmlElement(ElementName="Telefono")]
		public string gxTpr_Telefono
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Telefono; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Telefono = value;
				SetDirty("Telefono");
			}
		}



		[SoapElement(ElementName="Direccion" )]
		[XmlElement(ElementName="Direccion" )]
		public SdtSDT_NuevaSolicitudExterna_Cliente_Direccion gxTpr_Direccion
		{
			get {
				if ( gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion == null )
				{
					gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion = new SdtSDT_NuevaSolicitudExterna_Cliente_Direccion(context);
				}
				gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_N = false;
				SetDirty("Direccion");
				return gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion;
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_N = false;
				gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion = value;
				SetDirty("Direccion");
			}

		}

		public void gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_SetNull()
		{
			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_N = true;
			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion = null;
		}

		public bool gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_IsNull()
		{
			return gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion == null;
		}
		public bool ShouldSerializegxTpr_Direccion_Json()
		{
				return (gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion != null && gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion.ShouldSerializeSdtJson());

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
			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Nombre = "";
			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Email = "";
			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Telefono = "";

			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Nombre;
		 

		protected string gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Email;
		 

		protected string gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Telefono;
		 
		protected bool gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_N;
		protected SdtSDT_NuevaSolicitudExterna_Cliente_Direccion gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_NuevaSolicitudExterna.Cliente", Namespace="AlmangoX")]
	public class SdtSDT_NuevaSolicitudExterna_Cliente_RESTInterface : GxGenericCollectionItem<SdtSDT_NuevaSolicitudExterna_Cliente>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_NuevaSolicitudExterna_Cliente_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_NuevaSolicitudExterna_Cliente_RESTInterface( SdtSDT_NuevaSolicitudExterna_Cliente psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Nombre", Order=0)]
		public  string gxTpr_Nombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nombre);

			}
			set { 
				 sdt.gxTpr_Nombre = value;
			}
		}

		[DataMember(Name="Email", Order=1)]
		public  string gxTpr_Email
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Email);

			}
			set { 
				 sdt.gxTpr_Email = value;
			}
		}

		[DataMember(Name="Telefono", Order=2)]
		public  string gxTpr_Telefono
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Telefono);

			}
			set { 
				 sdt.gxTpr_Telefono = value;
			}
		}

		[DataMember(Name="Direccion", Order=3, EmitDefaultValue=false)]
		public SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_RESTInterface gxTpr_Direccion
		{
			get {
				if (sdt.ShouldSerializegxTpr_Direccion_Json())
					return new SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_RESTInterface(sdt.gxTpr_Direccion);
				else
					return null;

			}

			set {
				sdt.gxTpr_Direccion = value.sdt;
			}

		}


		#endregion
		public SdtSDT_NuevaSolicitudExterna_Cliente sdt
		{
			get { 
				return (SdtSDT_NuevaSolicitudExterna_Cliente)Sdt;
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
				sdt = new SdtSDT_NuevaSolicitudExterna_Cliente() ;
			}
		}
	}
	#endregion
}