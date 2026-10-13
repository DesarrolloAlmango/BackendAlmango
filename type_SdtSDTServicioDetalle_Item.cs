/*
				   File: type_SdtSDTServicioDetalle_Item
			Description: Producto
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
	[XmlRoot(ElementName="SDTServicioDetalle.Item")]
	[XmlType(TypeName="SDTServicioDetalle.Item" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTServicioDetalle_Item : GxUserType
	{
		public SdtSDTServicioDetalle_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTServicioDetalle_Item_Productonombre = "";


		}

		public SdtSDTServicioDetalle_Item(IGxContext context)
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
			AddObjectProperty("ProductoID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Productoid, 18, 0)), false);


			AddObjectProperty("ProductoNombre", gxTpr_Productonombre, false);


			AddObjectProperty("TerminosId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Terminosid, 18, 0)), false);

			if (gxTv_SdtSDTServicioDetalle_Item_Detalles != null)
			{
				AddObjectProperty("Detalles", gxTv_SdtSDTServicioDetalle_Item_Detalles, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProductoID")]
		[XmlElement(ElementName="ProductoID")]
		public long gxTpr_Productoid
		{
			get {
				return gxTv_SdtSDTServicioDetalle_Item_Productoid; 
			}
			set {
				gxTv_SdtSDTServicioDetalle_Item_Productoid = value;
				SetDirty("Productoid");
			}
		}




		[SoapElement(ElementName="ProductoNombre")]
		[XmlElement(ElementName="ProductoNombre")]
		public string gxTpr_Productonombre
		{
			get {
				return gxTv_SdtSDTServicioDetalle_Item_Productonombre; 
			}
			set {
				gxTv_SdtSDTServicioDetalle_Item_Productonombre = value;
				SetDirty("Productonombre");
			}
		}




		[SoapElement(ElementName="TerminosId")]
		[XmlElement(ElementName="TerminosId")]
		public long gxTpr_Terminosid
		{
			get {
				return gxTv_SdtSDTServicioDetalle_Item_Terminosid; 
			}
			set {
				gxTv_SdtSDTServicioDetalle_Item_Terminosid = value;
				SetDirty("Terminosid");
			}
		}




		[SoapElement(ElementName="Detalles" )]
		[XmlArray(ElementName="Detalles"  )]
		[XmlArrayItemAttribute(ElementName="DetalleItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTServicioDetalle_Item_DetalleItem> gxTpr_Detalles
		{
			get {
				if ( gxTv_SdtSDTServicioDetalle_Item_Detalles == null )
				{
					gxTv_SdtSDTServicioDetalle_Item_Detalles = new GXBaseCollection<SdtSDTServicioDetalle_Item_DetalleItem>( context, "SDTServicioDetalle.Item.DetalleItem", "");
				}
				SetDirty("Detalles");
				return gxTv_SdtSDTServicioDetalle_Item_Detalles;
			}
			set {
				gxTv_SdtSDTServicioDetalle_Item_Detalles_N = false;
				gxTv_SdtSDTServicioDetalle_Item_Detalles = value;
				SetDirty("Detalles");
			}
		}

		public void gxTv_SdtSDTServicioDetalle_Item_Detalles_SetNull()
		{
			gxTv_SdtSDTServicioDetalle_Item_Detalles_N = true;
			gxTv_SdtSDTServicioDetalle_Item_Detalles = null;
		}

		public bool gxTv_SdtSDTServicioDetalle_Item_Detalles_IsNull()
		{
			return gxTv_SdtSDTServicioDetalle_Item_Detalles == null;
		}
		public bool ShouldSerializegxTpr_Detalles_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTServicioDetalle_Item_Detalles != null && gxTv_SdtSDTServicioDetalle_Item_Detalles.Count > 0;

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
			gxTv_SdtSDTServicioDetalle_Item_Productonombre = "";


			gxTv_SdtSDTServicioDetalle_Item_Detalles_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTServicioDetalle_Item_Productoid;
		 

		protected string gxTv_SdtSDTServicioDetalle_Item_Productonombre;
		 

		protected long gxTv_SdtSDTServicioDetalle_Item_Terminosid;
		 
		protected bool gxTv_SdtSDTServicioDetalle_Item_Detalles_N;
		protected GXBaseCollection<SdtSDTServicioDetalle_Item_DetalleItem> gxTv_SdtSDTServicioDetalle_Item_Detalles = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTServicioDetalle.Item", Namespace="AlmangoX")]
	public class SdtSDTServicioDetalle_Item_RESTInterface : GxGenericCollectionItem<SdtSDTServicioDetalle_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTServicioDetalle_Item_RESTInterface( ) : base()
		{	
		}

		public SdtSDTServicioDetalle_Item_RESTInterface( SdtSDTServicioDetalle_Item psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProductoID", Order=0)]
		public  string gxTpr_Productoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Productoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Productoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProductoNombre", Order=1)]
		public  string gxTpr_Productonombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Productonombre);

			}
			set { 
				 sdt.gxTpr_Productonombre = value;
			}
		}

		[DataMember(Name="TerminosId", Order=2)]
		public  string gxTpr_Terminosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Terminosid, 18, 0));

			}
			set { 
				sdt.gxTpr_Terminosid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Detalles", Order=3, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTServicioDetalle_Item_DetalleItem_RESTInterface> gxTpr_Detalles
		{
			get {
				if (sdt.ShouldSerializegxTpr_Detalles_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTServicioDetalle_Item_DetalleItem_RESTInterface>(sdt.gxTpr_Detalles);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Detalles);
			}
		}


		#endregion
		public SdtSDTServicioDetalle_Item sdt
		{
			get { 
				return (SdtSDTServicioDetalle_Item)Sdt;
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
				sdt = new SdtSDTServicioDetalle_Item() ;
			}
		}
	}
	#endregion
}