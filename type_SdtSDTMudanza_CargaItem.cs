/*
				   File: type_SdtSDTMudanza_CargaItem
			Description: Carga
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
	[XmlRoot(ElementName="SDTMudanza.CargaItem")]
	[XmlType(TypeName="SDTMudanza.CargaItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTMudanza_CargaItem : GxUserType
	{
		public SdtSDTMudanza_CargaItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTMudanza_CargaItem_Itemcarganombre = "";

			gxTv_SdtSDTMudanza_CargaItem_Itemcargadescripcion = "";


		}

		public SdtSDTMudanza_CargaItem(IGxContext context)
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
			AddObjectProperty("ItemCargaId", gxTpr_Itemcargaid, false);


			AddObjectProperty("ItemCargaNombre", gxTpr_Itemcarganombre, false);


			AddObjectProperty("ItemCargaDescripcion", gxTpr_Itemcargadescripcion, false);


			AddObjectProperty("ItemCargaCantidad", gxTpr_Itemcargacantidad, false);


			AddObjectProperty("ItemCargaEmbCant", gxTpr_Itemcargaembcant, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ItemCargaId")]
		[XmlElement(ElementName="ItemCargaId")]
		public short gxTpr_Itemcargaid
		{
			get {
				return gxTv_SdtSDTMudanza_CargaItem_Itemcargaid; 
			}
			set {
				gxTv_SdtSDTMudanza_CargaItem_Itemcargaid = value;
				SetDirty("Itemcargaid");
			}
		}




		[SoapElement(ElementName="ItemCargaNombre")]
		[XmlElement(ElementName="ItemCargaNombre")]
		public string gxTpr_Itemcarganombre
		{
			get {
				return gxTv_SdtSDTMudanza_CargaItem_Itemcarganombre; 
			}
			set {
				gxTv_SdtSDTMudanza_CargaItem_Itemcarganombre = value;
				SetDirty("Itemcarganombre");
			}
		}




		[SoapElement(ElementName="ItemCargaDescripcion")]
		[XmlElement(ElementName="ItemCargaDescripcion")]
		public string gxTpr_Itemcargadescripcion
		{
			get {
				return gxTv_SdtSDTMudanza_CargaItem_Itemcargadescripcion; 
			}
			set {
				gxTv_SdtSDTMudanza_CargaItem_Itemcargadescripcion = value;
				SetDirty("Itemcargadescripcion");
			}
		}




		[SoapElement(ElementName="ItemCargaCantidad")]
		[XmlElement(ElementName="ItemCargaCantidad")]
		public short gxTpr_Itemcargacantidad
		{
			get {
				return gxTv_SdtSDTMudanza_CargaItem_Itemcargacantidad; 
			}
			set {
				gxTv_SdtSDTMudanza_CargaItem_Itemcargacantidad = value;
				SetDirty("Itemcargacantidad");
			}
		}




		[SoapElement(ElementName="ItemCargaEmbCant")]
		[XmlElement(ElementName="ItemCargaEmbCant")]
		public short gxTpr_Itemcargaembcant
		{
			get {
				return gxTv_SdtSDTMudanza_CargaItem_Itemcargaembcant; 
			}
			set {
				gxTv_SdtSDTMudanza_CargaItem_Itemcargaembcant = value;
				SetDirty("Itemcargaembcant");
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
			gxTv_SdtSDTMudanza_CargaItem_Itemcarganombre = "";
			gxTv_SdtSDTMudanza_CargaItem_Itemcargadescripcion = "";


			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTMudanza_CargaItem_Itemcargaid;
		 

		protected string gxTv_SdtSDTMudanza_CargaItem_Itemcarganombre;
		 

		protected string gxTv_SdtSDTMudanza_CargaItem_Itemcargadescripcion;
		 

		protected short gxTv_SdtSDTMudanza_CargaItem_Itemcargacantidad;
		 

		protected short gxTv_SdtSDTMudanza_CargaItem_Itemcargaembcant;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTMudanza.CargaItem", Namespace="AlmangoX")]
	public class SdtSDTMudanza_CargaItem_RESTInterface : GxGenericCollectionItem<SdtSDTMudanza_CargaItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTMudanza_CargaItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTMudanza_CargaItem_RESTInterface( SdtSDTMudanza_CargaItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ItemCargaId", Order=0)]
		public short gxTpr_Itemcargaid
		{
			get { 
				return sdt.gxTpr_Itemcargaid;

			}
			set { 
				sdt.gxTpr_Itemcargaid = value;
			}
		}

		[DataMember(Name="ItemCargaNombre", Order=1)]
		public  string gxTpr_Itemcarganombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Itemcarganombre);

			}
			set { 
				 sdt.gxTpr_Itemcarganombre = value;
			}
		}

		[DataMember(Name="ItemCargaDescripcion", Order=2)]
		public  string gxTpr_Itemcargadescripcion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Itemcargadescripcion);

			}
			set { 
				 sdt.gxTpr_Itemcargadescripcion = value;
			}
		}

		[DataMember(Name="ItemCargaCantidad", Order=3)]
		public short gxTpr_Itemcargacantidad
		{
			get { 
				return sdt.gxTpr_Itemcargacantidad;

			}
			set { 
				sdt.gxTpr_Itemcargacantidad = value;
			}
		}

		[DataMember(Name="ItemCargaEmbCant", Order=4)]
		public short gxTpr_Itemcargaembcant
		{
			get { 
				return sdt.gxTpr_Itemcargaembcant;

			}
			set { 
				sdt.gxTpr_Itemcargaembcant = value;
			}
		}


		#endregion
		public SdtSDTMudanza_CargaItem sdt
		{
			get { 
				return (SdtSDTMudanza_CargaItem)Sdt;
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
				sdt = new SdtSDTMudanza_CargaItem() ;
			}
		}
	}
	#endregion
}