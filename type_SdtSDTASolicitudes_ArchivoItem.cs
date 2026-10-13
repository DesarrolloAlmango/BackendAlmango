/*
				   File: type_SdtSDTASolicitudes_ArchivoItem
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
	[XmlRoot(ElementName="SDTASolicitudes.ArchivoItem")]
	[XmlType(TypeName="SDTASolicitudes.ArchivoItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTASolicitudes_ArchivoItem : GxUserType
	{
		public SdtSDTASolicitudes_ArchivoItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTASolicitudes_ArchivoItem_Archivodireccion = "";

			gxTv_SdtSDTASolicitudes_ArchivoItem_Archivodescripcion = "";

			gxTv_SdtSDTASolicitudes_ArchivoItem_Archivotipo = "";

		}

		public SdtSDTASolicitudes_ArchivoItem(IGxContext context)
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


			AddObjectProperty("ArchivoDireccion", gxTpr_Archivodireccion, false);


			AddObjectProperty("ArchivoDescripcion", gxTpr_Archivodescripcion, false);


			AddObjectProperty("ArchivoTipo", gxTpr_Archivotipo, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ArchivoId")]
		[XmlElement(ElementName="ArchivoId")]
		public long gxTpr_Archivoid
		{
			get {
				return gxTv_SdtSDTASolicitudes_ArchivoItem_Archivoid; 
			}
			set {
				gxTv_SdtSDTASolicitudes_ArchivoItem_Archivoid = value;
				SetDirty("Archivoid");
			}
		}




		[SoapElement(ElementName="ArchivoDireccion")]
		[XmlElement(ElementName="ArchivoDireccion")]
		public string gxTpr_Archivodireccion
		{
			get {
				return gxTv_SdtSDTASolicitudes_ArchivoItem_Archivodireccion; 
			}
			set {
				gxTv_SdtSDTASolicitudes_ArchivoItem_Archivodireccion = value;
				SetDirty("Archivodireccion");
			}
		}




		[SoapElement(ElementName="ArchivoDescripcion")]
		[XmlElement(ElementName="ArchivoDescripcion")]
		public string gxTpr_Archivodescripcion
		{
			get {
				return gxTv_SdtSDTASolicitudes_ArchivoItem_Archivodescripcion; 
			}
			set {
				gxTv_SdtSDTASolicitudes_ArchivoItem_Archivodescripcion = value;
				SetDirty("Archivodescripcion");
			}
		}




		[SoapElement(ElementName="ArchivoTipo")]
		[XmlElement(ElementName="ArchivoTipo")]
		public string gxTpr_Archivotipo
		{
			get {
				return gxTv_SdtSDTASolicitudes_ArchivoItem_Archivotipo; 
			}
			set {
				gxTv_SdtSDTASolicitudes_ArchivoItem_Archivotipo = value;
				SetDirty("Archivotipo");
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
			gxTv_SdtSDTASolicitudes_ArchivoItem_Archivodireccion = "";
			gxTv_SdtSDTASolicitudes_ArchivoItem_Archivodescripcion = "";
			gxTv_SdtSDTASolicitudes_ArchivoItem_Archivotipo = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTASolicitudes_ArchivoItem_Archivoid;
		 

		protected string gxTv_SdtSDTASolicitudes_ArchivoItem_Archivodireccion;
		 

		protected string gxTv_SdtSDTASolicitudes_ArchivoItem_Archivodescripcion;
		 

		protected string gxTv_SdtSDTASolicitudes_ArchivoItem_Archivotipo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTASolicitudes.ArchivoItem", Namespace="AlmangoX")]
	public class SdtSDTASolicitudes_ArchivoItem_RESTInterface : GxGenericCollectionItem<SdtSDTASolicitudes_ArchivoItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTASolicitudes_ArchivoItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTASolicitudes_ArchivoItem_RESTInterface( SdtSDTASolicitudes_ArchivoItem psdt ) : base(psdt)
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

		[DataMember(Name="ArchivoDireccion", Order=1)]
		public  string gxTpr_Archivodireccion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Archivodireccion);

			}
			set { 
				 sdt.gxTpr_Archivodireccion = value;
			}
		}

		[DataMember(Name="ArchivoDescripcion", Order=2)]
		public  string gxTpr_Archivodescripcion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Archivodescripcion);

			}
			set { 
				 sdt.gxTpr_Archivodescripcion = value;
			}
		}

		[DataMember(Name="ArchivoTipo", Order=3)]
		public  string gxTpr_Archivotipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Archivotipo);

			}
			set { 
				 sdt.gxTpr_Archivotipo = value;
			}
		}


		#endregion
		public SdtSDTASolicitudes_ArchivoItem sdt
		{
			get { 
				return (SdtSDTASolicitudes_ArchivoItem)Sdt;
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
				sdt = new SdtSDTASolicitudes_ArchivoItem() ;
			}
		}
	}
	#endregion
}