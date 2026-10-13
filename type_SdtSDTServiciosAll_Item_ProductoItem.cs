/*
				   File: type_SdtSDTServiciosAll_Item_ProductoItem
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
	[XmlRoot(ElementName="SDTServiciosAll.Item.ProductoItem")]
	[XmlType(TypeName="SDTServiciosAll.Item.ProductoItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTServiciosAll_Item_ProductoItem : GxUserType
	{
		public SdtSDTServiciosAll_Item_ProductoItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTServiciosAll_Item_ProductoItem_Productonombre = "";


		}

		public SdtSDTServiciosAll_Item_ProductoItem(IGxContext context)
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

			if (gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles != null)
			{
				AddObjectProperty("Detalles", gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles, false);
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
				return gxTv_SdtSDTServiciosAll_Item_ProductoItem_Productoid; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_Productoid = value;
				SetDirty("Productoid");
			}
		}




		[SoapElement(ElementName="ProductoNombre")]
		[XmlElement(ElementName="ProductoNombre")]
		public string gxTpr_Productonombre
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_ProductoItem_Productonombre; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_Productonombre = value;
				SetDirty("Productonombre");
			}
		}




		[SoapElement(ElementName="TerminosId")]
		[XmlElement(ElementName="TerminosId")]
		public long gxTpr_Terminosid
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_ProductoItem_Terminosid; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_Terminosid = value;
				SetDirty("Terminosid");
			}
		}




		[SoapElement(ElementName="Detalles" )]
		[XmlArray(ElementName="Detalles"  )]
		[XmlArrayItemAttribute(ElementName="DetallesItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTServiciosAll_Item_ProductoItem_DetallesItem> gxTpr_Detalles
		{
			get {
				if ( gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles == null )
				{
					gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles = new GXBaseCollection<SdtSDTServiciosAll_Item_ProductoItem_DetallesItem>( context, "SDTServiciosAll.Item.ProductoItem.DetallesItem", "");
				}
				SetDirty("Detalles");
				return gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles;
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles_N = false;
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles = value;
				SetDirty("Detalles");
			}
		}

		public void gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles_SetNull()
		{
			gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles_N = true;
			gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles = null;
		}

		public bool gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles_IsNull()
		{
			return gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles == null;
		}
		public bool ShouldSerializegxTpr_Detalles_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles != null && gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles.Count > 0;

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
			gxTv_SdtSDTServiciosAll_Item_ProductoItem_Productonombre = "";


			gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTServiciosAll_Item_ProductoItem_Productoid;
		 

		protected string gxTv_SdtSDTServiciosAll_Item_ProductoItem_Productonombre;
		 

		protected long gxTv_SdtSDTServiciosAll_Item_ProductoItem_Terminosid;
		 
		protected bool gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles_N;
		protected GXBaseCollection<SdtSDTServiciosAll_Item_ProductoItem_DetallesItem> gxTv_SdtSDTServiciosAll_Item_ProductoItem_Detalles = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTServiciosAll.Item.ProductoItem", Namespace="AlmangoX")]
	public class SdtSDTServiciosAll_Item_ProductoItem_RESTInterface : GxGenericCollectionItem<SdtSDTServiciosAll_Item_ProductoItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTServiciosAll_Item_ProductoItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTServiciosAll_Item_ProductoItem_RESTInterface( SdtSDTServiciosAll_Item_ProductoItem psdt ) : base(psdt)
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
		public GxGenericCollection<SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_RESTInterface> gxTpr_Detalles
		{
			get {
				if (sdt.ShouldSerializegxTpr_Detalles_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_RESTInterface>(sdt.gxTpr_Detalles);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Detalles);
			}
		}


		#endregion
		public SdtSDTServiciosAll_Item_ProductoItem sdt
		{
			get { 
				return (SdtSDTServiciosAll_Item_ProductoItem)Sdt;
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
				sdt = new SdtSDTServiciosAll_Item_ProductoItem() ;
			}
		}
	}
	#endregion
}