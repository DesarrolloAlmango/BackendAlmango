/*
				   File: type_SdtSDTMudanza_AdicionalItem
			Description: Adicional
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
	[XmlRoot(ElementName="SDTMudanza.AdicionalItem")]
	[XmlType(TypeName="SDTMudanza.AdicionalItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTMudanza_AdicionalItem : GxUserType
	{
		public SdtSDTMudanza_AdicionalItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTMudanza_AdicionalItem_Itemadicionalnombre = "";


		}

		public SdtSDTMudanza_AdicionalItem(IGxContext context)
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
			AddObjectProperty("ItemAdicionalId", gxTpr_Itemadicionalid, false);


			AddObjectProperty("ItemAdicionalNombre", gxTpr_Itemadicionalnombre, false);


			AddObjectProperty("ItemAdicionalCantidad", gxTpr_Itemadicionalcantidad, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ItemAdicionalId")]
		[XmlElement(ElementName="ItemAdicionalId")]
		public short gxTpr_Itemadicionalid
		{
			get {
				return gxTv_SdtSDTMudanza_AdicionalItem_Itemadicionalid; 
			}
			set {
				gxTv_SdtSDTMudanza_AdicionalItem_Itemadicionalid = value;
				SetDirty("Itemadicionalid");
			}
		}




		[SoapElement(ElementName="ItemAdicionalNombre")]
		[XmlElement(ElementName="ItemAdicionalNombre")]
		public string gxTpr_Itemadicionalnombre
		{
			get {
				return gxTv_SdtSDTMudanza_AdicionalItem_Itemadicionalnombre; 
			}
			set {
				gxTv_SdtSDTMudanza_AdicionalItem_Itemadicionalnombre = value;
				SetDirty("Itemadicionalnombre");
			}
		}




		[SoapElement(ElementName="ItemAdicionalCantidad")]
		[XmlElement(ElementName="ItemAdicionalCantidad")]
		public short gxTpr_Itemadicionalcantidad
		{
			get {
				return gxTv_SdtSDTMudanza_AdicionalItem_Itemadicionalcantidad; 
			}
			set {
				gxTv_SdtSDTMudanza_AdicionalItem_Itemadicionalcantidad = value;
				SetDirty("Itemadicionalcantidad");
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
			gxTv_SdtSDTMudanza_AdicionalItem_Itemadicionalnombre = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTMudanza_AdicionalItem_Itemadicionalid;
		 

		protected string gxTv_SdtSDTMudanza_AdicionalItem_Itemadicionalnombre;
		 

		protected short gxTv_SdtSDTMudanza_AdicionalItem_Itemadicionalcantidad;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTMudanza.AdicionalItem", Namespace="AlmangoX")]
	public class SdtSDTMudanza_AdicionalItem_RESTInterface : GxGenericCollectionItem<SdtSDTMudanza_AdicionalItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTMudanza_AdicionalItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTMudanza_AdicionalItem_RESTInterface( SdtSDTMudanza_AdicionalItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ItemAdicionalId", Order=0)]
		public short gxTpr_Itemadicionalid
		{
			get { 
				return sdt.gxTpr_Itemadicionalid;

			}
			set { 
				sdt.gxTpr_Itemadicionalid = value;
			}
		}

		[DataMember(Name="ItemAdicionalNombre", Order=1)]
		public  string gxTpr_Itemadicionalnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Itemadicionalnombre);

			}
			set { 
				 sdt.gxTpr_Itemadicionalnombre = value;
			}
		}

		[DataMember(Name="ItemAdicionalCantidad", Order=2)]
		public short gxTpr_Itemadicionalcantidad
		{
			get { 
				return sdt.gxTpr_Itemadicionalcantidad;

			}
			set { 
				sdt.gxTpr_Itemadicionalcantidad = value;
			}
		}


		#endregion
		public SdtSDTMudanza_AdicionalItem sdt
		{
			get { 
				return (SdtSDTMudanza_AdicionalItem)Sdt;
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
				sdt = new SdtSDTMudanza_AdicionalItem() ;
			}
		}
	}
	#endregion
}