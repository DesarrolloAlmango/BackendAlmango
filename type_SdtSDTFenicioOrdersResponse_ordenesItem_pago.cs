/*
				   File: type_SdtSDTFenicioOrdersResponse_ordenesItem_pago
			Description: pago
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
	[XmlRoot(ElementName="SDTFenicioOrdersResponse.ordenesItem.pago")]
	[XmlType(TypeName="SDTFenicioOrdersResponse.ordenesItem.pago" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTFenicioOrdersResponse_ordenesItem_pago : GxUserType
	{
		public SdtSDTFenicioOrdersResponse_ordenesItem_pago( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Codigo = "";

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Estado = "";

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Fechapago = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Moneda = "";

		}

		public SdtSDTFenicioOrdersResponse_ordenesItem_pago(IGxContext context)
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
			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("codigo", gxTpr_Codigo, false);


			AddObjectProperty("estado", gxTpr_Estado, false);


			datetime_STZ = gxTpr_Fechapago;
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
			AddObjectProperty("fechaPago", sDateCnv, false);



			AddObjectProperty("importe", gxTpr_Importe, false);


			AddObjectProperty("moneda", gxTpr_Moneda, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Id, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Id = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Id
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Id; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="codigo")]
		[XmlElement(ElementName="codigo")]
		public string gxTpr_Codigo
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Codigo; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Codigo = value;
				SetDirty("Codigo");
			}
		}




		[SoapElement(ElementName="estado")]
		[XmlElement(ElementName="estado")]
		public string gxTpr_Estado
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Estado; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Estado = value;
				SetDirty("Estado");
			}
		}



		[SoapElement(ElementName="fechaPago")]
		[XmlElement(ElementName="fechaPago" , IsNullable=true)]
		public string gxTpr_Fechapago_Nullable
		{
			get {
				if ( gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Fechapago == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Fechapago).value ;
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Fechapago = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Fechapago
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Fechapago; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Fechapago = value;
				SetDirty("Fechapago");
			}
		}


		[SoapElement(ElementName="importe")]
		[XmlElement(ElementName="importe")]
		public string gxTpr_Importe_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Importe, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Importe = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Importe
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Importe; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Importe = value;
				SetDirty("Importe");
			}
		}




		[SoapElement(ElementName="moneda")]
		[XmlElement(ElementName="moneda")]
		public string gxTpr_Moneda
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Moneda; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Moneda = value;
				SetDirty("Moneda");
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
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Codigo = "";
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Estado = "";
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Fechapago = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Moneda = "";
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

		protected decimal gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Id;
		 

		protected string gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Codigo;
		 

		protected string gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Estado;
		 

		protected DateTime gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Fechapago;
		 

		protected decimal gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Importe;
		 

		protected string gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_pago_Moneda;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTFenicioOrdersResponse.ordenesItem.pago", Namespace="AlmangoX")]
	public class SdtSDTFenicioOrdersResponse_ordenesItem_pago_RESTInterface : GxGenericCollectionItem<SdtSDTFenicioOrdersResponse_ordenesItem_pago>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTFenicioOrdersResponse_ordenesItem_pago_RESTInterface( ) : base()
		{	
		}

		public SdtSDTFenicioOrdersResponse_ordenesItem_pago_RESTInterface( SdtSDTFenicioOrdersResponse_ordenesItem_pago psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Id, 10, 5));

			}
			set { 
				sdt.gxTpr_Id =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="codigo", Order=1)]
		public  string gxTpr_Codigo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Codigo);

			}
			set { 
				 sdt.gxTpr_Codigo = value;
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

		[DataMember(Name="fechaPago", Order=3)]
		public  string gxTpr_Fechapago
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Fechapago,context);

			}
			set { 
				sdt.gxTpr_Fechapago = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="importe", Order=4)]
		public  string gxTpr_Importe
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Importe, 10, 5));

			}
			set { 
				sdt.gxTpr_Importe =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="moneda", Order=5)]
		public  string gxTpr_Moneda
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Moneda);

			}
			set { 
				 sdt.gxTpr_Moneda = value;
			}
		}


		#endregion
		public SdtSDTFenicioOrdersResponse_ordenesItem_pago sdt
		{
			get { 
				return (SdtSDTFenicioOrdersResponse_ordenesItem_pago)Sdt;
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
				sdt = new SdtSDTFenicioOrdersResponse_ordenesItem_pago() ;
			}
		}
	}
	#endregion
}