/*
				   File: type_SdtSDTComercioForanea
			Description: SDTComercioForanea
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

namespace GeneXus.Programs.apis
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="SDTComercioForanea")]
	[XmlType(TypeName="SDTComercioForanea" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTComercioForanea : GxUserType
	{
		public SdtSDTComercioForanea( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTComercioForanea(IGxContext context)
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
			if (gxTv_SdtSDTComercioForanea_Proveedorestipo != null)
			{
				AddObjectProperty("ProveedoresTipo", gxTv_SdtSDTComercioForanea_Proveedorestipo, false);
			}
			if (gxTv_SdtSDTComercioForanea_Banco != null)
			{
				AddObjectProperty("Banco", gxTv_SdtSDTComercioForanea_Banco, false);
			}
			if (gxTv_SdtSDTComercioForanea_Proveedorestado != null)
			{
				AddObjectProperty("ProveedorEstado", gxTv_SdtSDTComercioForanea_Proveedorestado, false);
			}
			if (gxTv_SdtSDTComercioForanea_Proveedorpagodefault != null)
			{
				AddObjectProperty("ProveedorPagoDefault", gxTv_SdtSDTComercioForanea_Proveedorpagodefault, false);
			}
			if (gxTv_SdtSDTComercioForanea_Documentacion != null)
			{
				AddObjectProperty("Documentacion", gxTv_SdtSDTComercioForanea_Documentacion, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProveedoresTipo" )]
		[XmlArray(ElementName="ProveedoresTipo"  )]
		[XmlArrayItemAttribute(ElementName="ProveedoresTipoItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTComercioForanea_ProveedoresTipoItem> gxTpr_Proveedorestipo
		{
			get {
				if ( gxTv_SdtSDTComercioForanea_Proveedorestipo == null )
				{
					gxTv_SdtSDTComercioForanea_Proveedorestipo = new GXBaseCollection<SdtSDTComercioForanea_ProveedoresTipoItem>( context, "SDTComercioForanea.ProveedoresTipoItem", "");
				}
				SetDirty("Proveedorestipo");
				return gxTv_SdtSDTComercioForanea_Proveedorestipo;
			}
			set {
				gxTv_SdtSDTComercioForanea_Proveedorestipo_N = false;
				gxTv_SdtSDTComercioForanea_Proveedorestipo = value;
				SetDirty("Proveedorestipo");
			}
		}

		public void gxTv_SdtSDTComercioForanea_Proveedorestipo_SetNull()
		{
			gxTv_SdtSDTComercioForanea_Proveedorestipo_N = true;
			gxTv_SdtSDTComercioForanea_Proveedorestipo = null;
		}

		public bool gxTv_SdtSDTComercioForanea_Proveedorestipo_IsNull()
		{
			return gxTv_SdtSDTComercioForanea_Proveedorestipo == null;
		}
		public bool ShouldSerializegxTpr_Proveedorestipo_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTComercioForanea_Proveedorestipo != null && gxTv_SdtSDTComercioForanea_Proveedorestipo.Count > 0;

		}



		[SoapElement(ElementName="Banco" )]
		[XmlArray(ElementName="Banco"  )]
		[XmlArrayItemAttribute(ElementName="BancoItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTComercioForanea_BancoItem> gxTpr_Banco
		{
			get {
				if ( gxTv_SdtSDTComercioForanea_Banco == null )
				{
					gxTv_SdtSDTComercioForanea_Banco = new GXBaseCollection<SdtSDTComercioForanea_BancoItem>( context, "SDTComercioForanea.BancoItem", "");
				}
				SetDirty("Banco");
				return gxTv_SdtSDTComercioForanea_Banco;
			}
			set {
				gxTv_SdtSDTComercioForanea_Banco_N = false;
				gxTv_SdtSDTComercioForanea_Banco = value;
				SetDirty("Banco");
			}
		}

		public void gxTv_SdtSDTComercioForanea_Banco_SetNull()
		{
			gxTv_SdtSDTComercioForanea_Banco_N = true;
			gxTv_SdtSDTComercioForanea_Banco = null;
		}

		public bool gxTv_SdtSDTComercioForanea_Banco_IsNull()
		{
			return gxTv_SdtSDTComercioForanea_Banco == null;
		}
		public bool ShouldSerializegxTpr_Banco_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTComercioForanea_Banco != null && gxTv_SdtSDTComercioForanea_Banco.Count > 0;

		}



		[SoapElement(ElementName="ProveedorEstado" )]
		[XmlArray(ElementName="ProveedorEstado"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Proveedorestado_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtSDTComercioForanea_Proveedorestado == null )
				{
					gxTv_SdtSDTComercioForanea_Proveedorestado = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtSDTComercioForanea_Proveedorestado;
			}
			set {
				gxTv_SdtSDTComercioForanea_Proveedorestado_N = false;
				gxTv_SdtSDTComercioForanea_Proveedorestado = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Proveedorestado
		{
			get {
				if ( gxTv_SdtSDTComercioForanea_Proveedorestado == null )
				{
					gxTv_SdtSDTComercioForanea_Proveedorestado = new GxSimpleCollection<string>();
				}
				gxTv_SdtSDTComercioForanea_Proveedorestado_N = false;
				SetDirty("Proveedorestado");
				return gxTv_SdtSDTComercioForanea_Proveedorestado ;
			}
			set {
				gxTv_SdtSDTComercioForanea_Proveedorestado_N = false;
				gxTv_SdtSDTComercioForanea_Proveedorestado = value;
				SetDirty("Proveedorestado");
			}
		}

		public void gxTv_SdtSDTComercioForanea_Proveedorestado_SetNull()
		{
			gxTv_SdtSDTComercioForanea_Proveedorestado_N = true;
			gxTv_SdtSDTComercioForanea_Proveedorestado = null;
		}

		public bool gxTv_SdtSDTComercioForanea_Proveedorestado_IsNull()
		{
			return gxTv_SdtSDTComercioForanea_Proveedorestado == null;
		}
		public bool ShouldSerializegxTpr_Proveedorestado_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTComercioForanea_Proveedorestado != null && gxTv_SdtSDTComercioForanea_Proveedorestado.Count > 0;

		}


		[SoapElement(ElementName="ProveedorPagoDefault" )]
		[XmlArray(ElementName="ProveedorPagoDefault"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Proveedorpagodefault_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtSDTComercioForanea_Proveedorpagodefault == null )
				{
					gxTv_SdtSDTComercioForanea_Proveedorpagodefault = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtSDTComercioForanea_Proveedorpagodefault;
			}
			set {
				gxTv_SdtSDTComercioForanea_Proveedorpagodefault_N = false;
				gxTv_SdtSDTComercioForanea_Proveedorpagodefault = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Proveedorpagodefault
		{
			get {
				if ( gxTv_SdtSDTComercioForanea_Proveedorpagodefault == null )
				{
					gxTv_SdtSDTComercioForanea_Proveedorpagodefault = new GxSimpleCollection<string>();
				}
				gxTv_SdtSDTComercioForanea_Proveedorpagodefault_N = false;
				SetDirty("Proveedorpagodefault");
				return gxTv_SdtSDTComercioForanea_Proveedorpagodefault ;
			}
			set {
				gxTv_SdtSDTComercioForanea_Proveedorpagodefault_N = false;
				gxTv_SdtSDTComercioForanea_Proveedorpagodefault = value;
				SetDirty("Proveedorpagodefault");
			}
		}

		public void gxTv_SdtSDTComercioForanea_Proveedorpagodefault_SetNull()
		{
			gxTv_SdtSDTComercioForanea_Proveedorpagodefault_N = true;
			gxTv_SdtSDTComercioForanea_Proveedorpagodefault = null;
		}

		public bool gxTv_SdtSDTComercioForanea_Proveedorpagodefault_IsNull()
		{
			return gxTv_SdtSDTComercioForanea_Proveedorpagodefault == null;
		}
		public bool ShouldSerializegxTpr_Proveedorpagodefault_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTComercioForanea_Proveedorpagodefault != null && gxTv_SdtSDTComercioForanea_Proveedorpagodefault.Count > 0;

		}


		[SoapElement(ElementName="Documentacion" )]
		[XmlArray(ElementName="Documentacion"  )]
		[XmlArrayItemAttribute(ElementName="DocumentacionItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTComercioForanea_DocumentacionItem> gxTpr_Documentacion
		{
			get {
				if ( gxTv_SdtSDTComercioForanea_Documentacion == null )
				{
					gxTv_SdtSDTComercioForanea_Documentacion = new GXBaseCollection<SdtSDTComercioForanea_DocumentacionItem>( context, "SDTComercioForanea.DocumentacionItem", "");
				}
				SetDirty("Documentacion");
				return gxTv_SdtSDTComercioForanea_Documentacion;
			}
			set {
				gxTv_SdtSDTComercioForanea_Documentacion_N = false;
				gxTv_SdtSDTComercioForanea_Documentacion = value;
				SetDirty("Documentacion");
			}
		}

		public void gxTv_SdtSDTComercioForanea_Documentacion_SetNull()
		{
			gxTv_SdtSDTComercioForanea_Documentacion_N = true;
			gxTv_SdtSDTComercioForanea_Documentacion = null;
		}

		public bool gxTv_SdtSDTComercioForanea_Documentacion_IsNull()
		{
			return gxTv_SdtSDTComercioForanea_Documentacion == null;
		}
		public bool ShouldSerializegxTpr_Documentacion_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTComercioForanea_Documentacion != null && gxTv_SdtSDTComercioForanea_Documentacion.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Proveedorestipo_GxSimpleCollection_Json() ||
				ShouldSerializegxTpr_Banco_GxSimpleCollection_Json() ||
				 ShouldSerializegxTpr_Proveedorestado_GxSimpleCollection_Json()|| 
				 ShouldSerializegxTpr_Proveedorpagodefault_GxSimpleCollection_Json()|| 
				ShouldSerializegxTpr_Documentacion_GxSimpleCollection_Json() || 
				false);
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
			gxTv_SdtSDTComercioForanea_Proveedorestipo_N = true;


			gxTv_SdtSDTComercioForanea_Banco_N = true;


			gxTv_SdtSDTComercioForanea_Proveedorestado_N = true;


			gxTv_SdtSDTComercioForanea_Proveedorpagodefault_N = true;


			gxTv_SdtSDTComercioForanea_Documentacion_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDTComercioForanea_Proveedorestipo_N;
		protected GXBaseCollection<SdtSDTComercioForanea_ProveedoresTipoItem> gxTv_SdtSDTComercioForanea_Proveedorestipo = null; 

		protected bool gxTv_SdtSDTComercioForanea_Banco_N;
		protected GXBaseCollection<SdtSDTComercioForanea_BancoItem> gxTv_SdtSDTComercioForanea_Banco = null; 

		protected bool gxTv_SdtSDTComercioForanea_Proveedorestado_N;
		protected GxSimpleCollection<string> gxTv_SdtSDTComercioForanea_Proveedorestado = null;  
		protected bool gxTv_SdtSDTComercioForanea_Proveedorpagodefault_N;
		protected GxSimpleCollection<string> gxTv_SdtSDTComercioForanea_Proveedorpagodefault = null;  
		protected bool gxTv_SdtSDTComercioForanea_Documentacion_N;
		protected GXBaseCollection<SdtSDTComercioForanea_DocumentacionItem> gxTv_SdtSDTComercioForanea_Documentacion = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTComercioForanea", Namespace="AlmangoX")]
	public class SdtSDTComercioForanea_RESTInterface : GxGenericCollectionItem<SdtSDTComercioForanea>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTComercioForanea_RESTInterface( ) : base()
		{	
		}

		public SdtSDTComercioForanea_RESTInterface( SdtSDTComercioForanea psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProveedoresTipo", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTComercioForanea_ProveedoresTipoItem_RESTInterface> gxTpr_Proveedorestipo
		{
			get {
				if (sdt.ShouldSerializegxTpr_Proveedorestipo_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTComercioForanea_ProveedoresTipoItem_RESTInterface>(sdt.gxTpr_Proveedorestipo);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Proveedorestipo);
			}
		}

		[DataMember(Name="Banco", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTComercioForanea_BancoItem_RESTInterface> gxTpr_Banco
		{
			get {
				if (sdt.ShouldSerializegxTpr_Banco_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTComercioForanea_BancoItem_RESTInterface>(sdt.gxTpr_Banco);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Banco);
			}
		}

		[DataMember(Name="ProveedorEstado", Order=2, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Proveedorestado
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Proveedorestado_GxSimpleCollection_Json())
					return sdt.gxTpr_Proveedorestado;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Proveedorestado = value ;
			}
		}

		[DataMember(Name="ProveedorPagoDefault", Order=3, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Proveedorpagodefault
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Proveedorpagodefault_GxSimpleCollection_Json())
					return sdt.gxTpr_Proveedorpagodefault;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Proveedorpagodefault = value ;
			}
		}

		[DataMember(Name="Documentacion", Order=4, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTComercioForanea_DocumentacionItem_RESTInterface> gxTpr_Documentacion
		{
			get {
				if (sdt.ShouldSerializegxTpr_Documentacion_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTComercioForanea_DocumentacionItem_RESTInterface>(sdt.gxTpr_Documentacion);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Documentacion);
			}
		}


		#endregion
		public SdtSDTComercioForanea sdt
		{
			get { 
				return (SdtSDTComercioForanea)Sdt;
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
				sdt = new SdtSDTComercioForanea() ;
			}
		}
	}
	#endregion
}