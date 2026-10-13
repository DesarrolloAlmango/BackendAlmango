/*
				   File: type_SdtSDTServicioDetalle
			Description: SDTServicioDetalle
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
	[XmlRoot(ElementName="SDTServicioDetalle")]
	[XmlType(TypeName="SDTServicioDetalle" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTServicioDetalle : GxUserType
	{
		public SdtSDTServicioDetalle( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTServicioDetalle_Rubrosnombre = "";

		}

		public SdtSDTServicioDetalle(IGxContext context)
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
			AddObjectProperty("RubrosId", gxTpr_Rubrosid, false);


			AddObjectProperty("RubrosNombre", gxTpr_Rubrosnombre, false);

			if (gxTv_SdtSDTServicioDetalle_Producto != null)
			{
				AddObjectProperty("Producto", gxTv_SdtSDTServicioDetalle_Producto, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="RubrosId")]
		[XmlElement(ElementName="RubrosId")]
		public short gxTpr_Rubrosid
		{
			get {
				return gxTv_SdtSDTServicioDetalle_Rubrosid; 
			}
			set {
				gxTv_SdtSDTServicioDetalle_Rubrosid = value;
				SetDirty("Rubrosid");
			}
		}




		[SoapElement(ElementName="RubrosNombre")]
		[XmlElement(ElementName="RubrosNombre")]
		public string gxTpr_Rubrosnombre
		{
			get {
				return gxTv_SdtSDTServicioDetalle_Rubrosnombre; 
			}
			set {
				gxTv_SdtSDTServicioDetalle_Rubrosnombre = value;
				SetDirty("Rubrosnombre");
			}
		}




		[SoapElement(ElementName="Producto" )]
		[XmlArray(ElementName="Producto"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<SdtSDTServicioDetalle_Item> gxTpr_Producto
		{
			get {
				if ( gxTv_SdtSDTServicioDetalle_Producto == null )
				{
					gxTv_SdtSDTServicioDetalle_Producto = new GXBaseCollection<SdtSDTServicioDetalle_Item>( context, "SDTServicioDetalle.Item", "");
				}
				SetDirty("Producto");
				return gxTv_SdtSDTServicioDetalle_Producto;
			}
			set {
				gxTv_SdtSDTServicioDetalle_Producto_N = false;
				gxTv_SdtSDTServicioDetalle_Producto = value;
				SetDirty("Producto");
			}
		}

		public void gxTv_SdtSDTServicioDetalle_Producto_SetNull()
		{
			gxTv_SdtSDTServicioDetalle_Producto_N = true;
			gxTv_SdtSDTServicioDetalle_Producto = null;
		}

		public bool gxTv_SdtSDTServicioDetalle_Producto_IsNull()
		{
			return gxTv_SdtSDTServicioDetalle_Producto == null;
		}
		public bool ShouldSerializegxTpr_Producto_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTServicioDetalle_Producto != null && gxTv_SdtSDTServicioDetalle_Producto.Count > 0;

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
			gxTv_SdtSDTServicioDetalle_Rubrosnombre = "";

			gxTv_SdtSDTServicioDetalle_Producto_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTServicioDetalle_Rubrosid;
		 

		protected string gxTv_SdtSDTServicioDetalle_Rubrosnombre;
		 
		protected bool gxTv_SdtSDTServicioDetalle_Producto_N;
		protected GXBaseCollection<SdtSDTServicioDetalle_Item> gxTv_SdtSDTServicioDetalle_Producto = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTServicioDetalle", Namespace="AlmangoX")]
	public class SdtSDTServicioDetalle_RESTInterface : GxGenericCollectionItem<SdtSDTServicioDetalle>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTServicioDetalle_RESTInterface( ) : base()
		{	
		}

		public SdtSDTServicioDetalle_RESTInterface( SdtSDTServicioDetalle psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="RubrosId", Order=0)]
		public short gxTpr_Rubrosid
		{
			get { 
				return sdt.gxTpr_Rubrosid;

			}
			set { 
				sdt.gxTpr_Rubrosid = value;
			}
		}

		[DataMember(Name="RubrosNombre", Order=1)]
		public  string gxTpr_Rubrosnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Rubrosnombre);

			}
			set { 
				 sdt.gxTpr_Rubrosnombre = value;
			}
		}

		[DataMember(Name="Producto", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTServicioDetalle_Item_RESTInterface> gxTpr_Producto
		{
			get {
				if (sdt.ShouldSerializegxTpr_Producto_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTServicioDetalle_Item_RESTInterface>(sdt.gxTpr_Producto);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Producto);
			}
		}


		#endregion
		public SdtSDTServicioDetalle sdt
		{
			get { 
				return (SdtSDTServicioDetalle)Sdt;
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
				sdt = new SdtSDTServicioDetalle() ;
			}
		}
	}
	#endregion
}