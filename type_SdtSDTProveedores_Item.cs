/*
				   File: type_SdtSDTProveedores_Item
			Description: SDTProveedores
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
	public class SdtSDTProveedores_Item : GxUserType
	{
		public SdtSDTProveedores_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTProveedores_Item_Proveedornombre = "";

			gxTv_SdtSDTProveedores_Item_Proveedorlogo = "";
			gxTv_SdtSDTProveedores_Item_Proveedorlogo_gxi = "";

		}

		public SdtSDTProveedores_Item(IGxContext context)
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
			AddObjectProperty("ProveedorID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Proveedorid, 18, 0)), false);


			AddObjectProperty("ProveedorNombre", gxTpr_Proveedornombre, false);


			AddObjectProperty("ProveedorLogo", gxTpr_Proveedorlogo, false);
			AddObjectProperty("ProveedorLogo_GXI", gxTpr_Proveedorlogo_gxi, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProveedorID")]
		[XmlElement(ElementName="ProveedorID")]
		public long gxTpr_Proveedorid
		{
			get {
				return gxTv_SdtSDTProveedores_Item_Proveedorid; 
			}
			set {
				gxTv_SdtSDTProveedores_Item_Proveedorid = value;
				SetDirty("Proveedorid");
			}
		}




		[SoapElement(ElementName="ProveedorNombre")]
		[XmlElement(ElementName="ProveedorNombre")]
		public string gxTpr_Proveedornombre
		{
			get {
				return gxTv_SdtSDTProveedores_Item_Proveedornombre; 
			}
			set {
				gxTv_SdtSDTProveedores_Item_Proveedornombre = value;
				SetDirty("Proveedornombre");
			}
		}




		[SoapElement(ElementName="ProveedorLogo")]
		[XmlElement(ElementName="ProveedorLogo")]
		[GxUpload()]

		public string gxTpr_Proveedorlogo
		{
			get {
				return gxTv_SdtSDTProveedores_Item_Proveedorlogo; 
			}
			set {
				gxTv_SdtSDTProveedores_Item_Proveedorlogo = value;
				SetDirty("Proveedorlogo");
			}
		}


		[SoapElement(ElementName="ProveedorLogo_GXI" )]
		[XmlElement(ElementName="ProveedorLogo_GXI" )]
		public string gxTpr_Proveedorlogo_gxi
		{
			get {
				return gxTv_SdtSDTProveedores_Item_Proveedorlogo_gxi ;
			}
			set {
				gxTv_SdtSDTProveedores_Item_Proveedorlogo_gxi = value;
				SetDirty("Proveedorlogo_gxi");
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
			gxTv_SdtSDTProveedores_Item_Proveedornombre = "";
			gxTv_SdtSDTProveedores_Item_Proveedorlogo = "";gxTv_SdtSDTProveedores_Item_Proveedorlogo_gxi = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTProveedores_Item_Proveedorid;
		 

		protected string gxTv_SdtSDTProveedores_Item_Proveedornombre;
		 
		protected string gxTv_SdtSDTProveedores_Item_Proveedorlogo_gxi;
		protected string gxTv_SdtSDTProveedores_Item_Proveedorlogo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"Item", Namespace="AlmangoX")]
	public class SdtSDTProveedores_Item_RESTInterface : GxGenericCollectionItem<SdtSDTProveedores_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTProveedores_Item_RESTInterface( ) : base()
		{	
		}

		public SdtSDTProveedores_Item_RESTInterface( SdtSDTProveedores_Item psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProveedorID", Order=0)]
		public  string gxTpr_Proveedorid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Proveedorid, 18, 0));

			}
			set { 
				sdt.gxTpr_Proveedorid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProveedorNombre", Order=1)]
		public  string gxTpr_Proveedornombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedornombre);

			}
			set { 
				 sdt.gxTpr_Proveedornombre = value;
			}
		}

		[DataMember(Name="ProveedorLogo", Order=2)]
		[GxUpload()]
		public  string gxTpr_Proveedorlogo
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Proveedorlogo)) ? PathUtil.RelativePath( sdt.gxTpr_Proveedorlogo) : StringUtil.RTrim( sdt.gxTpr_Proveedorlogo_gxi));

			}
			set { 
				 sdt.gxTpr_Proveedorlogo = value;
			}
		}


		#endregion
		public SdtSDTProveedores_Item sdt
		{
			get { 
				return (SdtSDTProveedores_Item)Sdt;
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
				sdt = new SdtSDTProveedores_Item() ;
			}
		}
	}
	#endregion
}