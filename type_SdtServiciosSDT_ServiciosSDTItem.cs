/*
				   File: type_SdtServiciosSDT_ServiciosSDTItem
			Description: ServiciosSDT
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
	[XmlRoot(ElementName="ServiciosSDTItem")]
	[XmlType(TypeName="ServiciosSDTItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtServiciosSDT_ServiciosSDTItem : GxUserType
	{
		public SdtServiciosSDT_ServiciosSDTItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtServiciosSDT_ServiciosSDTItem_Serviciosnombre = "";

		}

		public SdtServiciosSDT_ServiciosSDTItem(IGxContext context)
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
			AddObjectProperty("ServiciosId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Serviciosid, 18, 0)), false);


			AddObjectProperty("ServiciosNombre", gxTpr_Serviciosnombre, false);

			if (gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias != null)
			{
				AddObjectProperty("Categorias", gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ServiciosId")]
		[XmlElement(ElementName="ServiciosId")]
		public long gxTpr_Serviciosid
		{
			get {
				return gxTv_SdtServiciosSDT_ServiciosSDTItem_Serviciosid; 
			}
			set {
				gxTv_SdtServiciosSDT_ServiciosSDTItem_Serviciosid = value;
				SetDirty("Serviciosid");
			}
		}




		[SoapElement(ElementName="ServiciosNombre")]
		[XmlElement(ElementName="ServiciosNombre")]
		public string gxTpr_Serviciosnombre
		{
			get {
				return gxTv_SdtServiciosSDT_ServiciosSDTItem_Serviciosnombre; 
			}
			set {
				gxTv_SdtServiciosSDT_ServiciosSDTItem_Serviciosnombre = value;
				SetDirty("Serviciosnombre");
			}
		}




		[SoapElement(ElementName="Categorias" )]
		[XmlArray(ElementName="Categorias"  )]
		[XmlArrayItemAttribute(ElementName="CategoriasItem" , IsNullable=false )]
		public GXBaseCollection<SdtServiciosSDT_ServiciosSDTItem_CategoriasItem> gxTpr_Categorias
		{
			get {
				if ( gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias == null )
				{
					gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias = new GXBaseCollection<SdtServiciosSDT_ServiciosSDTItem_CategoriasItem>( context, "ServiciosSDT.ServiciosSDTItem.CategoriasItem", "");
				}
				SetDirty("Categorias");
				return gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias;
			}
			set {
				gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias_N = false;
				gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias = value;
				SetDirty("Categorias");
			}
		}

		public void gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias_SetNull()
		{
			gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias_N = true;
			gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias = null;
		}

		public bool gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias_IsNull()
		{
			return gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias == null;
		}
		public bool ShouldSerializegxTpr_Categorias_GxSimpleCollection_Json()
		{
			return gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias != null && gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias.Count > 0;

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
			gxTv_SdtServiciosSDT_ServiciosSDTItem_Serviciosnombre = "";

			gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtServiciosSDT_ServiciosSDTItem_Serviciosid;
		 

		protected string gxTv_SdtServiciosSDT_ServiciosSDTItem_Serviciosnombre;
		 
		protected bool gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias_N;
		protected GXBaseCollection<SdtServiciosSDT_ServiciosSDTItem_CategoriasItem> gxTv_SdtServiciosSDT_ServiciosSDTItem_Categorias = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"ServiciosSDTItem", Namespace="AlmangoX")]
	public class SdtServiciosSDT_ServiciosSDTItem_RESTInterface : GxGenericCollectionItem<SdtServiciosSDT_ServiciosSDTItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtServiciosSDT_ServiciosSDTItem_RESTInterface( ) : base()
		{	
		}

		public SdtServiciosSDT_ServiciosSDTItem_RESTInterface( SdtServiciosSDT_ServiciosSDTItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ServiciosId", Order=0)]
		public  string gxTpr_Serviciosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Serviciosid, 18, 0));

			}
			set { 
				sdt.gxTpr_Serviciosid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ServiciosNombre", Order=1)]
		public  string gxTpr_Serviciosnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Serviciosnombre);

			}
			set { 
				 sdt.gxTpr_Serviciosnombre = value;
			}
		}

		[DataMember(Name="Categorias", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtServiciosSDT_ServiciosSDTItem_CategoriasItem_RESTInterface> gxTpr_Categorias
		{
			get {
				if (sdt.ShouldSerializegxTpr_Categorias_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtServiciosSDT_ServiciosSDTItem_CategoriasItem_RESTInterface>(sdt.gxTpr_Categorias);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Categorias);
			}
		}


		#endregion
		public SdtServiciosSDT_ServiciosSDTItem sdt
		{
			get { 
				return (SdtServiciosSDT_ServiciosSDTItem)Sdt;
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
				sdt = new SdtServiciosSDT_ServiciosSDTItem() ;
			}
		}
	}
	#endregion
}