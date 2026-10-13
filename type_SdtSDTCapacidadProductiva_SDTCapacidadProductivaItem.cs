/*
				   File: type_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem
			Description: SDTCapacidadProductiva
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
	[XmlRoot(ElementName="SDTCapacidadProductivaItem")]
	[XmlType(TypeName="SDTCapacidadProductivaItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem : GxUserType
	{
		public SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Departamentonombre = "";


		}

		public SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem(IGxContext context)
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
			AddObjectProperty("DepartamentoID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Departamentoid, 18, 0)), false);


			AddObjectProperty("DepartamentoNombre", gxTpr_Departamentonombre, false);


			AddObjectProperty("SolicitudesPorcentaje", gxTpr_Solicitudesporcentaje, false);


			AddObjectProperty("SolicitudesCantidad", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Solicitudescantidad, 18, 2)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DepartamentoID")]
		[XmlElement(ElementName="DepartamentoID")]
		public long gxTpr_Departamentoid
		{
			get {
				return gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Departamentoid; 
			}
			set {
				gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Departamentoid = value;
				SetDirty("Departamentoid");
			}
		}




		[SoapElement(ElementName="DepartamentoNombre")]
		[XmlElement(ElementName="DepartamentoNombre")]
		public string gxTpr_Departamentonombre
		{
			get {
				return gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Departamentonombre; 
			}
			set {
				gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Departamentonombre = value;
				SetDirty("Departamentonombre");
			}
		}



		[SoapElement(ElementName="SolicitudesPorcentaje")]
		[XmlElement(ElementName="SolicitudesPorcentaje")]
		public string gxTpr_Solicitudesporcentaje_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Solicitudesporcentaje, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Solicitudesporcentaje = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Solicitudesporcentaje
		{
			get {
				return gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Solicitudesporcentaje; 
			}
			set {
				gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Solicitudesporcentaje = value;
				SetDirty("Solicitudesporcentaje");
			}
		}



		[SoapElement(ElementName="SolicitudesCantidad")]
		[XmlElement(ElementName="SolicitudesCantidad")]
		public string gxTpr_Solicitudescantidad_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Solicitudescantidad, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Solicitudescantidad = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Solicitudescantidad
		{
			get {
				return gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Solicitudescantidad; 
			}
			set {
				gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Solicitudescantidad = value;
				SetDirty("Solicitudescantidad");
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
			gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Departamentonombre = "";


			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Departamentoid;
		 

		protected string gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Departamentonombre;
		 

		protected decimal gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Solicitudesporcentaje;
		 

		protected decimal gxTv_SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_Solicitudescantidad;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTCapacidadProductivaItem", Namespace="AlmangoX")]
	public class SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_RESTInterface : GxGenericCollectionItem<SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem_RESTInterface( SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="DepartamentoID", Order=0)]
		public  string gxTpr_Departamentoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Departamentoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Departamentoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DepartamentoNombre", Order=1)]
		public  string gxTpr_Departamentonombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Departamentonombre);

			}
			set { 
				 sdt.gxTpr_Departamentonombre = value;
			}
		}

		[DataMember(Name="SolicitudesPorcentaje", Order=2)]
		public decimal gxTpr_Solicitudesporcentaje
		{
			get { 
				return sdt.gxTpr_Solicitudesporcentaje;

			}
			set { 
				sdt.gxTpr_Solicitudesporcentaje = value;
			}
		}

		[DataMember(Name="SolicitudesCantidad", Order=3)]
		public  string gxTpr_Solicitudescantidad
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Solicitudescantidad, 18, 2));

			}
			set { 
				sdt.gxTpr_Solicitudescantidad =  NumberUtil.Val( value, ".");
			}
		}


		#endregion
		public SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem sdt
		{
			get { 
				return (SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem)Sdt;
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
				sdt = new SdtSDTCapacidadProductiva_SDTCapacidadProductivaItem() ;
			}
		}
	}
	#endregion
}