/*
				   File: type_SdtSDTSolicitudes_ArchivoItem
			Description: Archivo
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
	[XmlRoot(ElementName="SDTSolicitudes.ArchivoItem")]
	[XmlType(TypeName="SDTSolicitudes.ArchivoItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTSolicitudes_ArchivoItem : GxUserType
	{
		public SdtSDTSolicitudes_ArchivoItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTSolicitudes_ArchivoItem_Archivotipo = "";

			gxTv_SdtSDTSolicitudes_ArchivoItem_Archivodireccion = "";

			gxTv_SdtSDTSolicitudes_ArchivoItem_Archivodescripcion = "";

		}

		public SdtSDTSolicitudes_ArchivoItem(IGxContext context)
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
			AddObjectProperty("ArchivoId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Archivoid, 18, 0)), false);


			AddObjectProperty("ArchivoTipo", gxTpr_Archivotipo, false);


			AddObjectProperty("ArchivoDireccion", gxTpr_Archivodireccion, false);


			AddObjectProperty("ArchivoDescripcion", gxTpr_Archivodescripcion, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ArchivoId")]
		[XmlElement(ElementName="ArchivoId")]
		public long gxTpr_Archivoid
		{
			get {
				return gxTv_SdtSDTSolicitudes_ArchivoItem_Archivoid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_ArchivoItem_Archivoid = value;
				SetDirty("Archivoid");
			}
		}




		[SoapElement(ElementName="ArchivoTipo")]
		[XmlElement(ElementName="ArchivoTipo")]
		public string gxTpr_Archivotipo
		{
			get {
				return gxTv_SdtSDTSolicitudes_ArchivoItem_Archivotipo; 
			}
			set {
				gxTv_SdtSDTSolicitudes_ArchivoItem_Archivotipo = value;
				SetDirty("Archivotipo");
			}
		}




		[SoapElement(ElementName="ArchivoDireccion")]
		[XmlElement(ElementName="ArchivoDireccion")]
		public string gxTpr_Archivodireccion
		{
			get {
				return gxTv_SdtSDTSolicitudes_ArchivoItem_Archivodireccion; 
			}
			set {
				gxTv_SdtSDTSolicitudes_ArchivoItem_Archivodireccion = value;
				SetDirty("Archivodireccion");
			}
		}




		[SoapElement(ElementName="ArchivoDescripcion")]
		[XmlElement(ElementName="ArchivoDescripcion")]
		public string gxTpr_Archivodescripcion
		{
			get {
				return gxTv_SdtSDTSolicitudes_ArchivoItem_Archivodescripcion; 
			}
			set {
				gxTv_SdtSDTSolicitudes_ArchivoItem_Archivodescripcion = value;
				SetDirty("Archivodescripcion");
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
			gxTv_SdtSDTSolicitudes_ArchivoItem_Archivotipo = "";
			gxTv_SdtSDTSolicitudes_ArchivoItem_Archivodireccion = "";
			gxTv_SdtSDTSolicitudes_ArchivoItem_Archivodescripcion = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTSolicitudes_ArchivoItem_Archivoid;
		 

		protected string gxTv_SdtSDTSolicitudes_ArchivoItem_Archivotipo;
		 

		protected string gxTv_SdtSDTSolicitudes_ArchivoItem_Archivodireccion;
		 

		protected string gxTv_SdtSDTSolicitudes_ArchivoItem_Archivodescripcion;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTSolicitudes.ArchivoItem", Namespace="AlmangoX")]
	public class SdtSDTSolicitudes_ArchivoItem_RESTInterface : GxGenericCollectionItem<SdtSDTSolicitudes_ArchivoItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTSolicitudes_ArchivoItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTSolicitudes_ArchivoItem_RESTInterface( SdtSDTSolicitudes_ArchivoItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ArchivoId", Order=0)]
		public  string gxTpr_Archivoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Archivoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Archivoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ArchivoTipo", Order=1)]
		public  string gxTpr_Archivotipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Archivotipo);

			}
			set { 
				 sdt.gxTpr_Archivotipo = value;
			}
		}

		[DataMember(Name="ArchivoDireccion", Order=2)]
		public  string gxTpr_Archivodireccion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Archivodireccion);

			}
			set { 
				 sdt.gxTpr_Archivodireccion = value;
			}
		}

		[DataMember(Name="ArchivoDescripcion", Order=3)]
		public  string gxTpr_Archivodescripcion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Archivodescripcion);

			}
			set { 
				 sdt.gxTpr_Archivodescripcion = value;
			}
		}


		#endregion
		public SdtSDTSolicitudes_ArchivoItem sdt
		{
			get { 
				return (SdtSDTSolicitudes_ArchivoItem)Sdt;
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
				sdt = new SdtSDTSolicitudes_ArchivoItem() ;
			}
		}
	}
	#endregion
}