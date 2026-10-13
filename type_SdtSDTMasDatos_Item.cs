/*
				   File: type_SdtSDTMasDatos_Item
			Description: ModoDePago
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
	[XmlRoot(ElementName="SDTMasDatos.Item")]
	[XmlType(TypeName="SDTMasDatos.Item" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTMasDatos_Item : GxUserType
	{
		public SdtSDTMasDatos_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTMasDatos_Item_Metodopagosnombre = "";

			gxTv_SdtSDTMasDatos_Item_Metodopagoslogo = "";
			gxTv_SdtSDTMasDatos_Item_Metodopagoslogo_gxi = "";

		}

		public SdtSDTMasDatos_Item(IGxContext context)
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
			AddObjectProperty("MetodoPagosID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Metodopagosid, 18, 0)), false);


			AddObjectProperty("MetodoPagosNombre", gxTpr_Metodopagosnombre, false);


			AddObjectProperty("MetodoPagosLogo", gxTpr_Metodopagoslogo, false);
			AddObjectProperty("MetodoPagosLogo_GXI", gxTpr_Metodopagoslogo_gxi, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MetodoPagosID")]
		[XmlElement(ElementName="MetodoPagosID")]
		public long gxTpr_Metodopagosid
		{
			get {
				return gxTv_SdtSDTMasDatos_Item_Metodopagosid; 
			}
			set {
				gxTv_SdtSDTMasDatos_Item_Metodopagosid = value;
				SetDirty("Metodopagosid");
			}
		}




		[SoapElement(ElementName="MetodoPagosNombre")]
		[XmlElement(ElementName="MetodoPagosNombre")]
		public string gxTpr_Metodopagosnombre
		{
			get {
				return gxTv_SdtSDTMasDatos_Item_Metodopagosnombre; 
			}
			set {
				gxTv_SdtSDTMasDatos_Item_Metodopagosnombre = value;
				SetDirty("Metodopagosnombre");
			}
		}




		[SoapElement(ElementName="MetodoPagosLogo")]
		[XmlElement(ElementName="MetodoPagosLogo")]
		[GxUpload()]

		public string gxTpr_Metodopagoslogo
		{
			get {
				return gxTv_SdtSDTMasDatos_Item_Metodopagoslogo; 
			}
			set {
				gxTv_SdtSDTMasDatos_Item_Metodopagoslogo = value;
				SetDirty("Metodopagoslogo");
			}
		}


		[SoapElement(ElementName="MetodoPagosLogo_GXI" )]
		[XmlElement(ElementName="MetodoPagosLogo_GXI" )]
		public string gxTpr_Metodopagoslogo_gxi
		{
			get {
				return gxTv_SdtSDTMasDatos_Item_Metodopagoslogo_gxi ;
			}
			set {
				gxTv_SdtSDTMasDatos_Item_Metodopagoslogo_gxi = value;
				SetDirty("Metodopagoslogo_gxi");
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
			gxTv_SdtSDTMasDatos_Item_Metodopagosnombre = "";
			gxTv_SdtSDTMasDatos_Item_Metodopagoslogo = "";gxTv_SdtSDTMasDatos_Item_Metodopagoslogo_gxi = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTMasDatos_Item_Metodopagosid;
		 

		protected string gxTv_SdtSDTMasDatos_Item_Metodopagosnombre;
		 
		protected string gxTv_SdtSDTMasDatos_Item_Metodopagoslogo_gxi;
		protected string gxTv_SdtSDTMasDatos_Item_Metodopagoslogo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTMasDatos.Item", Namespace="AlmangoX")]
	public class SdtSDTMasDatos_Item_RESTInterface : GxGenericCollectionItem<SdtSDTMasDatos_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTMasDatos_Item_RESTInterface( ) : base()
		{	
		}

		public SdtSDTMasDatos_Item_RESTInterface( SdtSDTMasDatos_Item psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="MetodoPagosID", Order=0)]
		public  string gxTpr_Metodopagosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Metodopagosid, 18, 0));

			}
			set { 
				sdt.gxTpr_Metodopagosid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MetodoPagosNombre", Order=1)]
		public  string gxTpr_Metodopagosnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Metodopagosnombre);

			}
			set { 
				 sdt.gxTpr_Metodopagosnombre = value;
			}
		}

		[DataMember(Name="MetodoPagosLogo", Order=2)]
		[GxUpload()]
		public  string gxTpr_Metodopagoslogo
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Metodopagoslogo)) ? PathUtil.RelativePath( sdt.gxTpr_Metodopagoslogo) : StringUtil.RTrim( sdt.gxTpr_Metodopagoslogo_gxi));

			}
			set { 
				 sdt.gxTpr_Metodopagoslogo = value;
			}
		}


		#endregion
		public SdtSDTMasDatos_Item sdt
		{
			get { 
				return (SdtSDTMasDatos_Item)Sdt;
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
				sdt = new SdtSDTMasDatos_Item() ;
			}
		}
	}
	#endregion
}