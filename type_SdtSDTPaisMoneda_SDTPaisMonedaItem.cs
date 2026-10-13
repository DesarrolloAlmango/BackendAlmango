/*
				   File: type_SdtSDTPaisMoneda_SDTPaisMonedaItem
			Description: SDTPaisMoneda
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
	[XmlRoot(ElementName="SDTPaisMonedaItem")]
	[XmlType(TypeName="SDTPaisMonedaItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTPaisMoneda_SDTPaisMonedaItem : GxUserType
	{
		public SdtSDTPaisMoneda_SDTPaisMonedaItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Paisid = "";

			gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Paisnombre = "";

			gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Monedanombre = "";

		}

		public SdtSDTPaisMoneda_SDTPaisMonedaItem(IGxContext context)
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
			AddObjectProperty("PaisId", gxTpr_Paisid, false);


			AddObjectProperty("PaisNombre", gxTpr_Paisnombre, false);


			AddObjectProperty("MonedaId", gxTpr_Monedaid, false);


			AddObjectProperty("MonedaNombre", gxTpr_Monedanombre, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PaisId")]
		[XmlElement(ElementName="PaisId")]
		public string gxTpr_Paisid
		{
			get {
				return gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Paisid; 
			}
			set {
				gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Paisid = value;
				SetDirty("Paisid");
			}
		}




		[SoapElement(ElementName="PaisNombre")]
		[XmlElement(ElementName="PaisNombre")]
		public string gxTpr_Paisnombre
		{
			get {
				return gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Paisnombre; 
			}
			set {
				gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Paisnombre = value;
				SetDirty("Paisnombre");
			}
		}




		[SoapElement(ElementName="MonedaId")]
		[XmlElement(ElementName="MonedaId")]
		public short gxTpr_Monedaid
		{
			get {
				return gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Monedaid; 
			}
			set {
				gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Monedaid = value;
				SetDirty("Monedaid");
			}
		}




		[SoapElement(ElementName="MonedaNombre")]
		[XmlElement(ElementName="MonedaNombre")]
		public string gxTpr_Monedanombre
		{
			get {
				return gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Monedanombre; 
			}
			set {
				gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Monedanombre = value;
				SetDirty("Monedanombre");
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
			gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Paisid = "";
			gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Paisnombre = "";

			gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Monedanombre = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Paisid;
		 

		protected string gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Paisnombre;
		 

		protected short gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Monedaid;
		 

		protected string gxTv_SdtSDTPaisMoneda_SDTPaisMonedaItem_Monedanombre;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTPaisMonedaItem", Namespace="AlmangoX")]
	public class SdtSDTPaisMoneda_SDTPaisMonedaItem_RESTInterface : GxGenericCollectionItem<SdtSDTPaisMoneda_SDTPaisMonedaItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTPaisMoneda_SDTPaisMonedaItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTPaisMoneda_SDTPaisMonedaItem_RESTInterface( SdtSDTPaisMoneda_SDTPaisMonedaItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PaisId", Order=0)]
		public  string gxTpr_Paisid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Paisid);

			}
			set { 
				 sdt.gxTpr_Paisid = value;
			}
		}

		[DataMember(Name="PaisNombre", Order=1)]
		public  string gxTpr_Paisnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Paisnombre);

			}
			set { 
				 sdt.gxTpr_Paisnombre = value;
			}
		}

		[DataMember(Name="MonedaId", Order=2)]
		public short gxTpr_Monedaid
		{
			get { 
				return sdt.gxTpr_Monedaid;

			}
			set { 
				sdt.gxTpr_Monedaid = value;
			}
		}

		[DataMember(Name="MonedaNombre", Order=3)]
		public  string gxTpr_Monedanombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Monedanombre);

			}
			set { 
				 sdt.gxTpr_Monedanombre = value;
			}
		}


		#endregion
		public SdtSDTPaisMoneda_SDTPaisMonedaItem sdt
		{
			get { 
				return (SdtSDTPaisMoneda_SDTPaisMonedaItem)Sdt;
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
				sdt = new SdtSDTPaisMoneda_SDTPaisMonedaItem() ;
			}
		}
	}
	#endregion
}