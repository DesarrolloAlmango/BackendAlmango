/*
				   File: type_SdtSDTServicios_Item
			Description: SDTServicios
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
	[XmlRoot(ElementName="Item")]
	[XmlType(TypeName="Item" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTServicios_Item : GxUserType
	{
		public SdtSDTServicios_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTServicios_Item_Serviciosnombre = "";

			gxTv_SdtSDTServicios_Item_Imagen = "";
			gxTv_SdtSDTServicios_Item_Imagen_gxi = "";

		}

		public SdtSDTServicios_Item(IGxContext context)
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


			AddObjectProperty("Imagen", gxTpr_Imagen, false);
			AddObjectProperty("Imagen_GXI", gxTpr_Imagen_gxi, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ServiciosId")]
		[XmlElement(ElementName="ServiciosId")]
		public long gxTpr_Serviciosid
		{
			get {
				return gxTv_SdtSDTServicios_Item_Serviciosid; 
			}
			set {
				gxTv_SdtSDTServicios_Item_Serviciosid = value;
				SetDirty("Serviciosid");
			}
		}




		[SoapElement(ElementName="ServiciosNombre")]
		[XmlElement(ElementName="ServiciosNombre")]
		public string gxTpr_Serviciosnombre
		{
			get {
				return gxTv_SdtSDTServicios_Item_Serviciosnombre; 
			}
			set {
				gxTv_SdtSDTServicios_Item_Serviciosnombre = value;
				SetDirty("Serviciosnombre");
			}
		}




		[SoapElement(ElementName="Imagen")]
		[XmlElement(ElementName="Imagen")]
		[GxUpload()]

		public string gxTpr_Imagen
		{
			get {
				return gxTv_SdtSDTServicios_Item_Imagen; 
			}
			set {
				gxTv_SdtSDTServicios_Item_Imagen = value;
				SetDirty("Imagen");
			}
		}


		[SoapElement(ElementName="Imagen_GXI" )]
		[XmlElement(ElementName="Imagen_GXI" )]
		public string gxTpr_Imagen_gxi
		{
			get {
				return gxTv_SdtSDTServicios_Item_Imagen_gxi ;
			}
			set {
				gxTv_SdtSDTServicios_Item_Imagen_gxi = value;
				SetDirty("Imagen_gxi");
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
			gxTv_SdtSDTServicios_Item_Serviciosnombre = "";
			gxTv_SdtSDTServicios_Item_Imagen = "";gxTv_SdtSDTServicios_Item_Imagen_gxi = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTServicios_Item_Serviciosid;
		 

		protected string gxTv_SdtSDTServicios_Item_Serviciosnombre;
		 
		protected string gxTv_SdtSDTServicios_Item_Imagen_gxi;
		protected string gxTv_SdtSDTServicios_Item_Imagen;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"Item", Namespace="AlmangoX")]
	public class SdtSDTServicios_Item_RESTInterface : GxGenericCollectionItem<SdtSDTServicios_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTServicios_Item_RESTInterface( ) : base()
		{	
		}

		public SdtSDTServicios_Item_RESTInterface( SdtSDTServicios_Item psdt ) : base(psdt)
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

		[DataMember(Name="Imagen", Order=2)]
		[GxUpload()]
		public  string gxTpr_Imagen
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Imagen)) ? PathUtil.RelativePath( sdt.gxTpr_Imagen) : StringUtil.RTrim( sdt.gxTpr_Imagen_gxi));

			}
			set { 
				 sdt.gxTpr_Imagen = value;
			}
		}


		#endregion
		public SdtSDTServicios_Item sdt
		{
			get { 
				return (SdtSDTServicios_Item)Sdt;
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
				sdt = new SdtSDTServicios_Item() ;
			}
		}
	}
	#endregion
}