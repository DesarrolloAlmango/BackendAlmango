/*
				   File: type_SdtSDTPostulaciones_MultimediaItem
			Description: Multimedia
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
	[XmlRoot(ElementName="SDTPostulaciones.MultimediaItem")]
	[XmlType(TypeName="SDTPostulaciones.MultimediaItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTPostulaciones_MultimediaItem : GxUserType
	{
		public SdtSDTPostulaciones_MultimediaItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediadireccion = "";

			gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediadescripcion = "";

			gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediatipo = "";

		}

		public SdtSDTPostulaciones_MultimediaItem(IGxContext context)
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
			AddObjectProperty("MultimediaId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Multimediaid, 18, 0)), false);


			AddObjectProperty("MultimediaDireccion", gxTpr_Multimediadireccion, false);


			AddObjectProperty("MultimediaDescripcion", gxTpr_Multimediadescripcion, false);


			AddObjectProperty("MultimediaTipo", gxTpr_Multimediatipo, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MultimediaId")]
		[XmlElement(ElementName="MultimediaId")]
		public long gxTpr_Multimediaid
		{
			get {
				return gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediaid; 
			}
			set {
				gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediaid = value;
				SetDirty("Multimediaid");
			}
		}




		[SoapElement(ElementName="MultimediaDireccion")]
		[XmlElement(ElementName="MultimediaDireccion")]
		public string gxTpr_Multimediadireccion
		{
			get {
				return gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediadireccion; 
			}
			set {
				gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediadireccion = value;
				SetDirty("Multimediadireccion");
			}
		}




		[SoapElement(ElementName="MultimediaDescripcion")]
		[XmlElement(ElementName="MultimediaDescripcion")]
		public string gxTpr_Multimediadescripcion
		{
			get {
				return gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediadescripcion; 
			}
			set {
				gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediadescripcion = value;
				SetDirty("Multimediadescripcion");
			}
		}




		[SoapElement(ElementName="MultimediaTipo")]
		[XmlElement(ElementName="MultimediaTipo")]
		public string gxTpr_Multimediatipo
		{
			get {
				return gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediatipo; 
			}
			set {
				gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediatipo = value;
				SetDirty("Multimediatipo");
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
			gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediadireccion = "";
			gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediadescripcion = "";
			gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediatipo = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediaid;
		 

		protected string gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediadireccion;
		 

		protected string gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediadescripcion;
		 

		protected string gxTv_SdtSDTPostulaciones_MultimediaItem_Multimediatipo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTPostulaciones.MultimediaItem", Namespace="AlmangoX")]
	public class SdtSDTPostulaciones_MultimediaItem_RESTInterface : GxGenericCollectionItem<SdtSDTPostulaciones_MultimediaItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTPostulaciones_MultimediaItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTPostulaciones_MultimediaItem_RESTInterface( SdtSDTPostulaciones_MultimediaItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="MultimediaId", Order=0)]
		public  string gxTpr_Multimediaid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Multimediaid, 18, 0));

			}
			set { 
				sdt.gxTpr_Multimediaid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MultimediaDireccion", Order=1)]
		public  string gxTpr_Multimediadireccion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Multimediadireccion);

			}
			set { 
				 sdt.gxTpr_Multimediadireccion = value;
			}
		}

		[DataMember(Name="MultimediaDescripcion", Order=2)]
		public  string gxTpr_Multimediadescripcion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Multimediadescripcion);

			}
			set { 
				 sdt.gxTpr_Multimediadescripcion = value;
			}
		}

		[DataMember(Name="MultimediaTipo", Order=3)]
		public  string gxTpr_Multimediatipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Multimediatipo);

			}
			set { 
				 sdt.gxTpr_Multimediatipo = value;
			}
		}


		#endregion
		public SdtSDTPostulaciones_MultimediaItem sdt
		{
			get { 
				return (SdtSDTPostulaciones_MultimediaItem)Sdt;
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
				sdt = new SdtSDTPostulaciones_MultimediaItem() ;
			}
		}
	}
	#endregion
}