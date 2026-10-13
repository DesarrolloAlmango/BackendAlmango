/*
				   File: type_SdtSDTConsumoProductivo_SDTConsumoProductivoItem
			Description: SDTConsumoProductivo
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
	[XmlRoot(ElementName="SDTConsumoProductivoItem")]
	[XmlType(TypeName="SDTConsumoProductivoItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTConsumoProductivo_SDTConsumoProductivoItem : GxUserType
	{
		public SdtSDTConsumoProductivo_SDTConsumoProductivoItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Diastipo = "";


		}

		public SdtSDTConsumoProductivo_SDTConsumoProductivoItem(IGxContext context)
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
			AddObjectProperty("DiasTipo", gxTpr_Diastipo, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Dia)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Dia)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Dia)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("Dia", sDateCnv, false);



			AddObjectProperty("Horas", gxTpr_Horas, false);


			AddObjectProperty("HorasSolicitadas", gxTpr_Horassolicitadas, false);


			AddObjectProperty("HorasDisponibles", gxTpr_Horasdisponibles, false);


			AddObjectProperty("HorasDisponiblesTeoricas", gxTpr_Horasdisponiblesteoricas, false);


			AddObjectProperty("PorcentajeSolicitado", gxTpr_Porcentajesolicitado, false);


			AddObjectProperty("HorasTomadas", gxTpr_Horastomadas, false);


			AddObjectProperty("PorcentajeTomadas", gxTpr_Porcentajetomadas, false);


			AddObjectProperty("TiempoEnOtros", gxTpr_Tiempoenotros, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DiasTipo")]
		[XmlElement(ElementName="DiasTipo")]
		public string gxTpr_Diastipo
		{
			get {
				return gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Diastipo; 
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Diastipo = value;
				SetDirty("Diastipo");
			}
		}



		[SoapElement(ElementName="Dia")]
		[XmlElement(ElementName="Dia" , IsNullable=true)]
		public string gxTpr_Dia_Nullable
		{
			get {
				if ( gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Dia == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Dia).value ;
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Dia = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Dia
		{
			get {
				return gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Dia; 
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Dia = value;
				SetDirty("Dia");
			}
		}



		[SoapElement(ElementName="Horas")]
		[XmlElement(ElementName="Horas")]
		public short gxTpr_Horas
		{
			get {
				return gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horas; 
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horas = value;
				SetDirty("Horas");
			}
		}



		[SoapElement(ElementName="HorasSolicitadas")]
		[XmlElement(ElementName="HorasSolicitadas")]
		public string gxTpr_Horassolicitadas_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horassolicitadas, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horassolicitadas = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Horassolicitadas
		{
			get {
				return gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horassolicitadas; 
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horassolicitadas = value;
				SetDirty("Horassolicitadas");
			}
		}



		[SoapElement(ElementName="HorasDisponibles")]
		[XmlElement(ElementName="HorasDisponibles")]
		public string gxTpr_Horasdisponibles_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horasdisponibles, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horasdisponibles = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Horasdisponibles
		{
			get {
				return gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horasdisponibles; 
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horasdisponibles = value;
				SetDirty("Horasdisponibles");
			}
		}



		[SoapElement(ElementName="HorasDisponiblesTeoricas")]
		[XmlElement(ElementName="HorasDisponiblesTeoricas")]
		public string gxTpr_Horasdisponiblesteoricas_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horasdisponiblesteoricas, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horasdisponiblesteoricas = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Horasdisponiblesteoricas
		{
			get {
				return gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horasdisponiblesteoricas; 
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horasdisponiblesteoricas = value;
				SetDirty("Horasdisponiblesteoricas");
			}
		}



		[SoapElement(ElementName="PorcentajeSolicitado")]
		[XmlElement(ElementName="PorcentajeSolicitado")]
		public string gxTpr_Porcentajesolicitado_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Porcentajesolicitado, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Porcentajesolicitado = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Porcentajesolicitado
		{
			get {
				return gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Porcentajesolicitado; 
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Porcentajesolicitado = value;
				SetDirty("Porcentajesolicitado");
			}
		}



		[SoapElement(ElementName="HorasTomadas")]
		[XmlElement(ElementName="HorasTomadas")]
		public string gxTpr_Horastomadas_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horastomadas, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horastomadas = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Horastomadas
		{
			get {
				return gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horastomadas; 
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horastomadas = value;
				SetDirty("Horastomadas");
			}
		}



		[SoapElement(ElementName="PorcentajeTomadas")]
		[XmlElement(ElementName="PorcentajeTomadas")]
		public string gxTpr_Porcentajetomadas_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Porcentajetomadas, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Porcentajetomadas = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Porcentajetomadas
		{
			get {
				return gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Porcentajetomadas; 
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Porcentajetomadas = value;
				SetDirty("Porcentajetomadas");
			}
		}



		[SoapElement(ElementName="TiempoEnOtros")]
		[XmlElement(ElementName="TiempoEnOtros")]
		public string gxTpr_Tiempoenotros_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Tiempoenotros, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Tiempoenotros = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Tiempoenotros
		{
			get {
				return gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Tiempoenotros; 
			}
			set {
				gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Tiempoenotros = value;
				SetDirty("Tiempoenotros");
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
			gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Diastipo = "";









			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Diastipo;
		 

		protected DateTime gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Dia;
		 

		protected short gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horas;
		 

		protected decimal gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horassolicitadas;
		 

		protected decimal gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horasdisponibles;
		 

		protected decimal gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horasdisponiblesteoricas;
		 

		protected decimal gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Porcentajesolicitado;
		 

		protected decimal gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Horastomadas;
		 

		protected decimal gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Porcentajetomadas;
		 

		protected decimal gxTv_SdtSDTConsumoProductivo_SDTConsumoProductivoItem_Tiempoenotros;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTConsumoProductivoItem", Namespace="AlmangoX")]
	public class SdtSDTConsumoProductivo_SDTConsumoProductivoItem_RESTInterface : GxGenericCollectionItem<SdtSDTConsumoProductivo_SDTConsumoProductivoItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTConsumoProductivo_SDTConsumoProductivoItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTConsumoProductivo_SDTConsumoProductivoItem_RESTInterface( SdtSDTConsumoProductivo_SDTConsumoProductivoItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="DiasTipo", Order=0)]
		public  string gxTpr_Diastipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Diastipo);

			}
			set { 
				 sdt.gxTpr_Diastipo = value;
			}
		}

		[DataMember(Name="Dia", Order=1)]
		public  string gxTpr_Dia
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Dia);

			}
			set { 
				sdt.gxTpr_Dia = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="Horas", Order=2)]
		public short gxTpr_Horas
		{
			get { 
				return sdt.gxTpr_Horas;

			}
			set { 
				sdt.gxTpr_Horas = value;
			}
		}

		[DataMember(Name="HorasSolicitadas", Order=3)]
		public  string gxTpr_Horassolicitadas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Horassolicitadas, 10, 2));

			}
			set { 
				sdt.gxTpr_Horassolicitadas =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="HorasDisponibles", Order=4)]
		public  string gxTpr_Horasdisponibles
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Horasdisponibles, 10, 2));

			}
			set { 
				sdt.gxTpr_Horasdisponibles =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="HorasDisponiblesTeoricas", Order=5)]
		public  string gxTpr_Horasdisponiblesteoricas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Horasdisponiblesteoricas, 10, 2));

			}
			set { 
				sdt.gxTpr_Horasdisponiblesteoricas =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PorcentajeSolicitado", Order=6)]
		public decimal gxTpr_Porcentajesolicitado
		{
			get { 
				return sdt.gxTpr_Porcentajesolicitado;

			}
			set { 
				sdt.gxTpr_Porcentajesolicitado = value;
			}
		}

		[DataMember(Name="HorasTomadas", Order=7)]
		public  string gxTpr_Horastomadas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Horastomadas, 10, 2));

			}
			set { 
				sdt.gxTpr_Horastomadas =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PorcentajeTomadas", Order=8)]
		public decimal gxTpr_Porcentajetomadas
		{
			get { 
				return sdt.gxTpr_Porcentajetomadas;

			}
			set { 
				sdt.gxTpr_Porcentajetomadas = value;
			}
		}

		[DataMember(Name="TiempoEnOtros", Order=9)]
		public  string gxTpr_Tiempoenotros
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tiempoenotros, 10, 2));

			}
			set { 
				sdt.gxTpr_Tiempoenotros =  NumberUtil.Val( value, ".");
			}
		}


		#endregion
		public SdtSDTConsumoProductivo_SDTConsumoProductivoItem sdt
		{
			get { 
				return (SdtSDTConsumoProductivo_SDTConsumoProductivoItem)Sdt;
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
				sdt = new SdtSDTConsumoProductivo_SDTConsumoProductivoItem() ;
			}
		}
	}
	#endregion
}