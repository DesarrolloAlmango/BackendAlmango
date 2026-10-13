/*
				   File: type_SdtNotificacionesSDT_NotificacionesSDTItem
			Description: NotificacionesSDT
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
	[XmlRoot(ElementName="NotificacionesSDTItem")]
	[XmlType(TypeName="NotificacionesSDTItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtNotificacionesSDT_NotificacionesSDTItem : GxUserType
	{
		public SdtNotificacionesSDT_NotificacionesSDTItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosid = "";

			gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificaciontipo = "";

			gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionnotificado = "";

			gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificaciondescripcion = "";

			gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionparametros = "";

			gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionobjeto = "";

			gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionfecha = (DateTime)(DateTime.MinValue);

		}

		public SdtNotificacionesSDT_NotificacionesSDTItem(IGxContext context)
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
			AddObjectProperty("NusuariosId", gxTpr_Nusuariosid, false);


			AddObjectProperty("NusuariosNotificacionTipo", gxTpr_Nusuariosnotificaciontipo, false);


			AddObjectProperty("NusuariosNotificacionCodigo", gxTpr_Nusuariosnotificacioncodigo, false);


			AddObjectProperty("NusuariosNotificacionNotificado", gxTpr_Nusuariosnotificacionnotificado, false);


			AddObjectProperty("NusuariosNotificacionDescripcion", gxTpr_Nusuariosnotificaciondescripcion, false);


			AddObjectProperty("NusuariosNotificacionParametros", gxTpr_Nusuariosnotificacionparametros, false);


			AddObjectProperty("NusuariosNotificacionObjeto", gxTpr_Nusuariosnotificacionobjeto, false);


			datetime_STZ = gxTpr_Nusuariosnotificacionfecha;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("NusuariosNotificacionFecha", sDateCnv, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NusuariosId")]
		[XmlElement(ElementName="NusuariosId")]
		public string gxTpr_Nusuariosid
		{
			get {
				return gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosid; 
			}
			set {
				gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosid = value;
				SetDirty("Nusuariosid");
			}
		}




		[SoapElement(ElementName="NusuariosNotificacionTipo")]
		[XmlElement(ElementName="NusuariosNotificacionTipo")]
		public string gxTpr_Nusuariosnotificaciontipo
		{
			get {
				return gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificaciontipo; 
			}
			set {
				gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificaciontipo = value;
				SetDirty("Nusuariosnotificaciontipo");
			}
		}




		[SoapElement(ElementName="NusuariosNotificacionCodigo")]
		[XmlElement(ElementName="NusuariosNotificacionCodigo")]
		public long gxTpr_Nusuariosnotificacioncodigo
		{
			get {
				return gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacioncodigo; 
			}
			set {
				gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacioncodigo = value;
				SetDirty("Nusuariosnotificacioncodigo");
			}
		}




		[SoapElement(ElementName="NusuariosNotificacionNotificado")]
		[XmlElement(ElementName="NusuariosNotificacionNotificado")]
		public string gxTpr_Nusuariosnotificacionnotificado
		{
			get {
				return gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionnotificado; 
			}
			set {
				gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionnotificado = value;
				SetDirty("Nusuariosnotificacionnotificado");
			}
		}




		[SoapElement(ElementName="NusuariosNotificacionDescripcion")]
		[XmlElement(ElementName="NusuariosNotificacionDescripcion")]
		public string gxTpr_Nusuariosnotificaciondescripcion
		{
			get {
				return gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificaciondescripcion; 
			}
			set {
				gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificaciondescripcion = value;
				SetDirty("Nusuariosnotificaciondescripcion");
			}
		}




		[SoapElement(ElementName="NusuariosNotificacionParametros")]
		[XmlElement(ElementName="NusuariosNotificacionParametros")]
		public string gxTpr_Nusuariosnotificacionparametros
		{
			get {
				return gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionparametros; 
			}
			set {
				gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionparametros = value;
				SetDirty("Nusuariosnotificacionparametros");
			}
		}




		[SoapElement(ElementName="NusuariosNotificacionObjeto")]
		[XmlElement(ElementName="NusuariosNotificacionObjeto")]
		public string gxTpr_Nusuariosnotificacionobjeto
		{
			get {
				return gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionobjeto; 
			}
			set {
				gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionobjeto = value;
				SetDirty("Nusuariosnotificacionobjeto");
			}
		}



		[SoapElement(ElementName="NusuariosNotificacionFecha")]
		[XmlElement(ElementName="NusuariosNotificacionFecha" , IsNullable=true)]
		public string gxTpr_Nusuariosnotificacionfecha_Nullable
		{
			get {
				if ( gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionfecha == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionfecha).value ;
			}
			set {
				gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionfecha = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Nusuariosnotificacionfecha
		{
			get {
				return gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionfecha; 
			}
			set {
				gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionfecha = value;
				SetDirty("Nusuariosnotificacionfecha");
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
			gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosid = "";
			gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificaciontipo = "";

			gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionnotificado = "";
			gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificaciondescripcion = "";
			gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionparametros = "";
			gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionobjeto = "";
			gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionfecha = (DateTime)(DateTime.MinValue);
			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected string gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosid;
		 

		protected string gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificaciontipo;
		 

		protected long gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacioncodigo;
		 

		protected string gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionnotificado;
		 

		protected string gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificaciondescripcion;
		 

		protected string gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionparametros;
		 

		protected string gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionobjeto;
		 

		protected DateTime gxTv_SdtNotificacionesSDT_NotificacionesSDTItem_Nusuariosnotificacionfecha;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"NotificacionesSDTItem", Namespace="AlmangoX")]
	public class SdtNotificacionesSDT_NotificacionesSDTItem_RESTInterface : GxGenericCollectionItem<SdtNotificacionesSDT_NotificacionesSDTItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtNotificacionesSDT_NotificacionesSDTItem_RESTInterface( ) : base()
		{	
		}

		public SdtNotificacionesSDT_NotificacionesSDTItem_RESTInterface( SdtNotificacionesSDT_NotificacionesSDTItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="NusuariosId", Order=0)]
		public  string gxTpr_Nusuariosid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nusuariosid);

			}
			set { 
				 sdt.gxTpr_Nusuariosid = value;
			}
		}

		[DataMember(Name="NusuariosNotificacionTipo", Order=1)]
		public  string gxTpr_Nusuariosnotificaciontipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nusuariosnotificaciontipo);

			}
			set { 
				 sdt.gxTpr_Nusuariosnotificaciontipo = value;
			}
		}

		[DataMember(Name="NusuariosNotificacionCodigo", Order=2)]
		public  string gxTpr_Nusuariosnotificacioncodigo
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Nusuariosnotificacioncodigo, 10, 0));

			}
			set { 
				sdt.gxTpr_Nusuariosnotificacioncodigo = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NusuariosNotificacionNotificado", Order=3)]
		public  string gxTpr_Nusuariosnotificacionnotificado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nusuariosnotificacionnotificado);

			}
			set { 
				 sdt.gxTpr_Nusuariosnotificacionnotificado = value;
			}
		}

		[DataMember(Name="NusuariosNotificacionDescripcion", Order=4)]
		public  string gxTpr_Nusuariosnotificaciondescripcion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nusuariosnotificaciondescripcion);

			}
			set { 
				 sdt.gxTpr_Nusuariosnotificaciondescripcion = value;
			}
		}

		[DataMember(Name="NusuariosNotificacionParametros", Order=5)]
		public  string gxTpr_Nusuariosnotificacionparametros
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nusuariosnotificacionparametros);

			}
			set { 
				 sdt.gxTpr_Nusuariosnotificacionparametros = value;
			}
		}

		[DataMember(Name="NusuariosNotificacionObjeto", Order=6)]
		public  string gxTpr_Nusuariosnotificacionobjeto
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nusuariosnotificacionobjeto);

			}
			set { 
				 sdt.gxTpr_Nusuariosnotificacionobjeto = value;
			}
		}

		[DataMember(Name="NusuariosNotificacionFecha", Order=7)]
		public  string gxTpr_Nusuariosnotificacionfecha
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Nusuariosnotificacionfecha,context);

			}
			set { 
				sdt.gxTpr_Nusuariosnotificacionfecha = DateTimeUtil.CToT2(value,context);
			}
		}


		#endregion
		public SdtNotificacionesSDT_NotificacionesSDTItem sdt
		{
			get { 
				return (SdtNotificacionesSDT_NotificacionesSDTItem)Sdt;
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
				sdt = new SdtNotificacionesSDT_NotificacionesSDTItem() ;
			}
		}
	}
	#endregion
}