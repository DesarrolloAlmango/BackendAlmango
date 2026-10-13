/*
				   File: type_SdtSDTFenicioOrdersResponse_ordenesItem
			Description: ordenes
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
	[XmlRoot(ElementName="SDTFenicioOrdersResponse.ordenesItem")]
	[XmlType(TypeName="SDTFenicioOrdersResponse.ordenesItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTFenicioOrdersResponse_ordenesItem : GxUserType
	{
		public SdtSDTFenicioOrdersResponse_ordenesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Idorden = "";

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Estado = "";

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Fechainicio = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Fechafin = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Observaciones = "";


		}

		public SdtSDTFenicioOrdersResponse_ordenesItem(IGxContext context)
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
			AddObjectProperty("idOrden", gxTpr_Idorden, false);


			AddObjectProperty("numeroOrden", gxTpr_Numeroorden, false);


			AddObjectProperty("estado", gxTpr_Estado, false);


			datetime_STZ = gxTpr_Fechainicio;
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
			AddObjectProperty("fechaInicio", sDateCnv, false);



			datetime_STZ = gxTpr_Fechafin;
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
			AddObjectProperty("fechaFin", sDateCnv, false);



			AddObjectProperty("observaciones", gxTpr_Observaciones, false);

			if (gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador != null)
			{
				AddObjectProperty("comprador", gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador, false);
			}
			if (gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago != null)
			{
				AddObjectProperty("pago", gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago, false);
			}
			if (gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega != null)
			{
				AddObjectProperty("entrega", gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega, false);
			}
			if (gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas != null)
			{
				AddObjectProperty("lineas", gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas, false);
			}

			AddObjectProperty("importeTotal", gxTpr_Importetotal, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="idOrden")]
		[XmlElement(ElementName="idOrden")]
		public string gxTpr_Idorden
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Idorden; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Idorden = value;
				SetDirty("Idorden");
			}
		}



		[SoapElement(ElementName="numeroOrden")]
		[XmlElement(ElementName="numeroOrden")]
		public string gxTpr_Numeroorden_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Numeroorden, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Numeroorden = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Numeroorden
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Numeroorden; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Numeroorden = value;
				SetDirty("Numeroorden");
			}
		}




		[SoapElement(ElementName="estado")]
		[XmlElement(ElementName="estado")]
		public string gxTpr_Estado
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Estado; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Estado = value;
				SetDirty("Estado");
			}
		}



		[SoapElement(ElementName="fechaInicio")]
		[XmlElement(ElementName="fechaInicio" , IsNullable=true)]
		public string gxTpr_Fechainicio_Nullable
		{
			get {
				if ( gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Fechainicio == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Fechainicio).value ;
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Fechainicio = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Fechainicio
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Fechainicio; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Fechainicio = value;
				SetDirty("Fechainicio");
			}
		}


		[SoapElement(ElementName="fechaFin")]
		[XmlElement(ElementName="fechaFin" , IsNullable=true)]
		public string gxTpr_Fechafin_Nullable
		{
			get {
				if ( gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Fechafin == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Fechafin).value ;
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Fechafin = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Fechafin
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Fechafin; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Fechafin = value;
				SetDirty("Fechafin");
			}
		}



		[SoapElement(ElementName="observaciones")]
		[XmlElement(ElementName="observaciones")]
		public string gxTpr_Observaciones
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Observaciones; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Observaciones = value;
				SetDirty("Observaciones");
			}
		}



		[SoapElement(ElementName="comprador" )]
		[XmlElement(ElementName="comprador" )]
		public SdtSDTFenicioOrdersResponse_ordenesItem_comprador gxTpr_Comprador
		{
			get {
				if ( gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador == null )
				{
					gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador = new SdtSDTFenicioOrdersResponse_ordenesItem_comprador(context);
				}
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador_N = false;
				SetDirty("Comprador");
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador;
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador_N = false;
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador = value;
				SetDirty("Comprador");
			}

		}

		public void gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador_SetNull()
		{
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador_N = true;
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador = null;
		}

		public bool gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador_IsNull()
		{
			return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador == null;
		}
		public bool ShouldSerializegxTpr_Comprador_Json()
		{
				return (gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador != null && gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="pago" )]
		[XmlElement(ElementName="pago" )]
		public SdtSDTFenicioOrdersResponse_ordenesItem_pago gxTpr_Pago
		{
			get {
				if ( gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago == null )
				{
					gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago = new SdtSDTFenicioOrdersResponse_ordenesItem_pago(context);
				}
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago_N = false;
				SetDirty("Pago");
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago;
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago_N = false;
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago = value;
				SetDirty("Pago");
			}

		}

		public void gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago_SetNull()
		{
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago_N = true;
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago = null;
		}

		public bool gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago_IsNull()
		{
			return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago == null;
		}
		public bool ShouldSerializegxTpr_Pago_Json()
		{
				return (gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago != null && gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="entrega" )]
		[XmlElement(ElementName="entrega" )]
		public SdtSDTFenicioOrdersResponse_ordenesItem_entrega gxTpr_Entrega
		{
			get {
				if ( gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega == null )
				{
					gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega = new SdtSDTFenicioOrdersResponse_ordenesItem_entrega(context);
				}
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega_N = false;
				SetDirty("Entrega");
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega;
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega_N = false;
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega = value;
				SetDirty("Entrega");
			}

		}

		public void gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega_SetNull()
		{
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega_N = true;
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega = null;
		}

		public bool gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega_IsNull()
		{
			return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega == null;
		}
		public bool ShouldSerializegxTpr_Entrega_Json()
		{
				return (gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega != null && gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="lineas" )]
		[XmlArray(ElementName="lineas"  )]
		[XmlArrayItemAttribute(ElementName="lineasItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem> gxTpr_Lineas
		{
			get {
				if ( gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas == null )
				{
					gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas = new GXBaseCollection<SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem>( context, "SDTFenicioOrdersResponse.ordenesItem.lineasItem", "");
				}
				SetDirty("Lineas");
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas;
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas_N = false;
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas = value;
				SetDirty("Lineas");
			}
		}

		public void gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas_SetNull()
		{
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas_N = true;
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas = null;
		}

		public bool gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas_IsNull()
		{
			return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas == null;
		}
		public bool ShouldSerializegxTpr_Lineas_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas != null && gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas.Count > 0;

		}


		[SoapElement(ElementName="importeTotal")]
		[XmlElement(ElementName="importeTotal")]
		public string gxTpr_Importetotal_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Importetotal, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Importetotal = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Importetotal
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Importetotal; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Importetotal = value;
				SetDirty("Importetotal");
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
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Idorden = "";

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Estado = "";
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Fechainicio = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Fechafin = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Observaciones = "";

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador_N = true;


			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago_N = true;


			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega_N = true;


			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas_N = true;


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

		protected string gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Idorden;
		 

		protected decimal gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Numeroorden;
		 

		protected string gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Estado;
		 

		protected DateTime gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Fechainicio;
		 

		protected DateTime gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Fechafin;
		 

		protected string gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Observaciones;
		 
		protected bool gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador_N;
		protected SdtSDTFenicioOrdersResponse_ordenesItem_comprador gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Comprador = null; 

		protected bool gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago_N;
		protected SdtSDTFenicioOrdersResponse_ordenesItem_pago gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Pago = null; 

		protected bool gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega_N;
		protected SdtSDTFenicioOrdersResponse_ordenesItem_entrega gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Entrega = null; 

		protected bool gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas_N;
		protected GXBaseCollection<SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem> gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Lineas = null; 


		protected decimal gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_Importetotal;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTFenicioOrdersResponse.ordenesItem", Namespace="AlmangoX")]
	public class SdtSDTFenicioOrdersResponse_ordenesItem_RESTInterface : GxGenericCollectionItem<SdtSDTFenicioOrdersResponse_ordenesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTFenicioOrdersResponse_ordenesItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTFenicioOrdersResponse_ordenesItem_RESTInterface( SdtSDTFenicioOrdersResponse_ordenesItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="idOrden", Order=0)]
		public  string gxTpr_Idorden
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Idorden);

			}
			set { 
				 sdt.gxTpr_Idorden = value;
			}
		}

		[DataMember(Name="numeroOrden", Order=1)]
		public  string gxTpr_Numeroorden
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Numeroorden, 10, 5));

			}
			set { 
				sdt.gxTpr_Numeroorden =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="estado", Order=2)]
		public  string gxTpr_Estado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Estado);

			}
			set { 
				 sdt.gxTpr_Estado = value;
			}
		}

		[DataMember(Name="fechaInicio", Order=3)]
		public  string gxTpr_Fechainicio
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Fechainicio,context);

			}
			set { 
				sdt.gxTpr_Fechainicio = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="fechaFin", Order=4)]
		public  string gxTpr_Fechafin
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Fechafin,context);

			}
			set { 
				sdt.gxTpr_Fechafin = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="observaciones", Order=5)]
		public  string gxTpr_Observaciones
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Observaciones);

			}
			set { 
				 sdt.gxTpr_Observaciones = value;
			}
		}

		[DataMember(Name="comprador", Order=6, EmitDefaultValue=false)]
		public SdtSDTFenicioOrdersResponse_ordenesItem_comprador_RESTInterface gxTpr_Comprador
		{
			get {
				if (sdt.ShouldSerializegxTpr_Comprador_Json())
					return new SdtSDTFenicioOrdersResponse_ordenesItem_comprador_RESTInterface(sdt.gxTpr_Comprador);
				else
					return null;

			}

			set {
				sdt.gxTpr_Comprador = value.sdt;
			}

		}

		[DataMember(Name="pago", Order=7, EmitDefaultValue=false)]
		public SdtSDTFenicioOrdersResponse_ordenesItem_pago_RESTInterface gxTpr_Pago
		{
			get {
				if (sdt.ShouldSerializegxTpr_Pago_Json())
					return new SdtSDTFenicioOrdersResponse_ordenesItem_pago_RESTInterface(sdt.gxTpr_Pago);
				else
					return null;

			}

			set {
				sdt.gxTpr_Pago = value.sdt;
			}

		}

		[DataMember(Name="entrega", Order=8, EmitDefaultValue=false)]
		public SdtSDTFenicioOrdersResponse_ordenesItem_entrega_RESTInterface gxTpr_Entrega
		{
			get {
				if (sdt.ShouldSerializegxTpr_Entrega_Json())
					return new SdtSDTFenicioOrdersResponse_ordenesItem_entrega_RESTInterface(sdt.gxTpr_Entrega);
				else
					return null;

			}

			set {
				sdt.gxTpr_Entrega = value.sdt;
			}

		}

		[DataMember(Name="lineas", Order=9, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_RESTInterface> gxTpr_Lineas
		{
			get {
				if (sdt.ShouldSerializegxTpr_Lineas_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem_RESTInterface>(sdt.gxTpr_Lineas);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Lineas);
			}
		}

		[DataMember(Name="importeTotal", Order=10)]
		public  string gxTpr_Importetotal
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Importetotal, 10, 5));

			}
			set { 
				sdt.gxTpr_Importetotal =  NumberUtil.Val( value, ".");
			}
		}


		#endregion
		public SdtSDTFenicioOrdersResponse_ordenesItem sdt
		{
			get { 
				return (SdtSDTFenicioOrdersResponse_ordenesItem)Sdt;
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
				sdt = new SdtSDTFenicioOrdersResponse_ordenesItem() ;
			}
		}
	}
	#endregion
}