/*
				   File: type_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem
			Description: SDTTarjetasServicios
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
	[XmlRoot(ElementName="SDTTarjetasServiciosItem")]
	[XmlType(TypeName="SDTTarjetasServiciosItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTTarjetasServicios_SDTTarjetasServiciosItem : GxUserType
	{
		public SdtSDTTarjetasServicios_SDTTarjetasServiciosItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Name = "";

			gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Icon = "";

			gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Url = "";

		}

		public SdtSDTTarjetasServicios_SDTTarjetasServiciosItem(IGxContext context)
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
			AddObjectProperty("id", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Id, 18, 0)), false);


			AddObjectProperty("name", gxTpr_Name, false);


			AddObjectProperty("icon", gxTpr_Icon, false);


			AddObjectProperty("url", gxTpr_Url, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public long gxTpr_Id
		{
			get {
				return gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Id; 
			}
			set {
				gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Name; 
			}
			set {
				gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="icon")]
		[XmlElement(ElementName="icon")]
		public string gxTpr_Icon
		{
			get {
				return gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Icon; 
			}
			set {
				gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Icon = value;
				SetDirty("Icon");
			}
		}




		[SoapElement(ElementName="url")]
		[XmlElement(ElementName="url")]
		public string gxTpr_Url
		{
			get {
				return gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Url; 
			}
			set {
				gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Url = value;
				SetDirty("Url");
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
			gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Name = "";
			gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Icon = "";
			gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Url = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Id;
		 

		protected string gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Name;
		 

		protected string gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Icon;
		 

		protected string gxTv_SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_Url;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTTarjetasServiciosItem", Namespace="AlmangoX")]
	public class SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_RESTInterface : GxGenericCollectionItem<SdtSDTTarjetasServicios_SDTTarjetasServiciosItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTTarjetasServicios_SDTTarjetasServiciosItem_RESTInterface( SdtSDTTarjetasServicios_SDTTarjetasServiciosItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Id, 18, 0));

			}
			set { 
				sdt.gxTpr_Id = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="name", Order=1)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="icon", Order=2)]
		public  string gxTpr_Icon
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Icon);

			}
			set { 
				 sdt.gxTpr_Icon = value;
			}
		}

		[DataMember(Name="url", Order=3)]
		public  string gxTpr_Url
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Url);

			}
			set { 
				 sdt.gxTpr_Url = value;
			}
		}


		#endregion
		public SdtSDTTarjetasServicios_SDTTarjetasServiciosItem sdt
		{
			get { 
				return (SdtSDTTarjetasServicios_SDTTarjetasServiciosItem)Sdt;
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
				sdt = new SdtSDTTarjetasServicios_SDTTarjetasServiciosItem() ;
			}
		}
	}
	#endregion
}