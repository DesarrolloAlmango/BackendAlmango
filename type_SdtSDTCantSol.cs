/*
				   File: type_SdtSDTCantSol
			Description: SDTCantSol
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
	[XmlRoot(ElementName="SDTCantSol")]
	[XmlType(TypeName="SDTCantSol" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTCantSol : GxUserType
	{
		public SdtSDTCantSol( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCantSol_Fechaactualizacion = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTCantSol_Ayerturnos = "";

			gxTv_SdtSDTCantSol_Hoyturnos = "";

			gxTv_SdtSDTCantSol_Mananaturnos = "";

			gxTv_SdtSDTCantSol_Pmananaturnos = "";

			gxTv_SdtSDTCantSol_Dia1turnos = "";

			gxTv_SdtSDTCantSol_Dia2turnos = "";

			gxTv_SdtSDTCantSol_Dia3turno = "";

		}

		public SdtSDTCantSol(IGxContext context)
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
			AddObjectProperty("Habilitadas", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Habilitadas, 18, 0)), false);


			AddObjectProperty("Procesadas", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Procesadas, 18, 0)), false);


			AddObjectProperty("Delegadas", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Delegadas, 18, 0)), false);


			AddObjectProperty("Rechazadas", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Rechazadas, 18, 0)), false);


			AddObjectProperty("Aceptadas", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Aceptadas, 18, 0)), false);


			AddObjectProperty("Canceladas", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Canceladas, 18, 0)), false);


			AddObjectProperty("Finalizadas", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Finalizadas, 18, 0)), false);


			AddObjectProperty("Calificadas", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Calificadas, 18, 0)), false);


			AddObjectProperty("Total", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Total, 18, 0)), false);


			datetime_STZ = gxTpr_Fechaactualizacion;
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
			AddObjectProperty("FechaActualizacion", sDateCnv, false);



			AddObjectProperty("ProveedorId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Proveedorid, 18, 0)), false);


			AddObjectProperty("TotalGenerado", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Totalgenerado, 18, 2)), false);


			AddObjectProperty("MesAnterior", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Mesanterior, 18, 2)), false);


			AddObjectProperty("MesActual", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Mesactual, 18, 2)), false);


			AddObjectProperty("Ayer", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Ayer, 18, 0)), false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Ayerfecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Ayerfecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Ayerfecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("AyerFecha", sDateCnv, false);



			AddObjectProperty("AyerTurnos", gxTpr_Ayerturnos, false);


			AddObjectProperty("Hoy", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Hoy, 18, 0)), false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Hoyfecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Hoyfecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Hoyfecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("HoyFecha", sDateCnv, false);



			AddObjectProperty("HoyTurnos", gxTpr_Hoyturnos, false);


			AddObjectProperty("Manana", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Manana, 18, 0)), false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Mananafecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Mananafecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Mananafecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("MananaFecha", sDateCnv, false);



			AddObjectProperty("MananaTurnos", gxTpr_Mananaturnos, false);


			AddObjectProperty("PManana", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Pmanana, 18, 0)), false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Pmananafecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Pmananafecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Pmananafecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("PMananaFecha", sDateCnv, false);



			AddObjectProperty("PMananaTurnos", gxTpr_Pmananaturnos, false);


			AddObjectProperty("Dia1", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Dia1, 18, 0)), false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Dia1fecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Dia1fecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Dia1fecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("Dia1Fecha", sDateCnv, false);



			AddObjectProperty("Dia1Turnos", gxTpr_Dia1turnos, false);


			AddObjectProperty("Dia2", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Dia2, 18, 0)), false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Dia2fecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Dia2fecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Dia2fecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("Dia2Fecha", sDateCnv, false);



			AddObjectProperty("Dia2Turnos", gxTpr_Dia2turnos, false);


			AddObjectProperty("Dia3", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Dia3, 18, 0)), false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Dia3fecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Dia3fecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Dia3fecha)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("Dia3Fecha", sDateCnv, false);



			AddObjectProperty("Dia3Turno", gxTpr_Dia3turno, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Habilitadas")]
		[XmlElement(ElementName="Habilitadas")]
		public long gxTpr_Habilitadas
		{
			get {
				return gxTv_SdtSDTCantSol_Habilitadas; 
			}
			set {
				gxTv_SdtSDTCantSol_Habilitadas = value;
				SetDirty("Habilitadas");
			}
		}




		[SoapElement(ElementName="Procesadas")]
		[XmlElement(ElementName="Procesadas")]
		public long gxTpr_Procesadas
		{
			get {
				return gxTv_SdtSDTCantSol_Procesadas; 
			}
			set {
				gxTv_SdtSDTCantSol_Procesadas = value;
				SetDirty("Procesadas");
			}
		}




		[SoapElement(ElementName="Delegadas")]
		[XmlElement(ElementName="Delegadas")]
		public long gxTpr_Delegadas
		{
			get {
				return gxTv_SdtSDTCantSol_Delegadas; 
			}
			set {
				gxTv_SdtSDTCantSol_Delegadas = value;
				SetDirty("Delegadas");
			}
		}




		[SoapElement(ElementName="Rechazadas")]
		[XmlElement(ElementName="Rechazadas")]
		public long gxTpr_Rechazadas
		{
			get {
				return gxTv_SdtSDTCantSol_Rechazadas; 
			}
			set {
				gxTv_SdtSDTCantSol_Rechazadas = value;
				SetDirty("Rechazadas");
			}
		}




		[SoapElement(ElementName="Aceptadas")]
		[XmlElement(ElementName="Aceptadas")]
		public long gxTpr_Aceptadas
		{
			get {
				return gxTv_SdtSDTCantSol_Aceptadas; 
			}
			set {
				gxTv_SdtSDTCantSol_Aceptadas = value;
				SetDirty("Aceptadas");
			}
		}




		[SoapElement(ElementName="Canceladas")]
		[XmlElement(ElementName="Canceladas")]
		public long gxTpr_Canceladas
		{
			get {
				return gxTv_SdtSDTCantSol_Canceladas; 
			}
			set {
				gxTv_SdtSDTCantSol_Canceladas = value;
				SetDirty("Canceladas");
			}
		}




		[SoapElement(ElementName="Finalizadas")]
		[XmlElement(ElementName="Finalizadas")]
		public long gxTpr_Finalizadas
		{
			get {
				return gxTv_SdtSDTCantSol_Finalizadas; 
			}
			set {
				gxTv_SdtSDTCantSol_Finalizadas = value;
				SetDirty("Finalizadas");
			}
		}




		[SoapElement(ElementName="Calificadas")]
		[XmlElement(ElementName="Calificadas")]
		public long gxTpr_Calificadas
		{
			get {
				return gxTv_SdtSDTCantSol_Calificadas; 
			}
			set {
				gxTv_SdtSDTCantSol_Calificadas = value;
				SetDirty("Calificadas");
			}
		}




		[SoapElement(ElementName="Total")]
		[XmlElement(ElementName="Total")]
		public long gxTpr_Total
		{
			get {
				return gxTv_SdtSDTCantSol_Total; 
			}
			set {
				gxTv_SdtSDTCantSol_Total = value;
				SetDirty("Total");
			}
		}



		[SoapElement(ElementName="FechaActualizacion")]
		[XmlElement(ElementName="FechaActualizacion" , IsNullable=true)]
		public string gxTpr_Fechaactualizacion_Nullable
		{
			get {
				if ( gxTv_SdtSDTCantSol_Fechaactualizacion == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTCantSol_Fechaactualizacion).value ;
			}
			set {
				gxTv_SdtSDTCantSol_Fechaactualizacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Fechaactualizacion
		{
			get {
				return gxTv_SdtSDTCantSol_Fechaactualizacion; 
			}
			set {
				gxTv_SdtSDTCantSol_Fechaactualizacion = value;
				SetDirty("Fechaactualizacion");
			}
		}



		[SoapElement(ElementName="ProveedorId")]
		[XmlElement(ElementName="ProveedorId")]
		public long gxTpr_Proveedorid
		{
			get {
				return gxTv_SdtSDTCantSol_Proveedorid; 
			}
			set {
				gxTv_SdtSDTCantSol_Proveedorid = value;
				SetDirty("Proveedorid");
			}
		}



		[SoapElement(ElementName="TotalGenerado")]
		[XmlElement(ElementName="TotalGenerado")]
		public string gxTpr_Totalgenerado_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTCantSol_Totalgenerado, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTCantSol_Totalgenerado = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Totalgenerado
		{
			get {
				return gxTv_SdtSDTCantSol_Totalgenerado; 
			}
			set {
				gxTv_SdtSDTCantSol_Totalgenerado = value;
				SetDirty("Totalgenerado");
			}
		}



		[SoapElement(ElementName="MesAnterior")]
		[XmlElement(ElementName="MesAnterior")]
		public string gxTpr_Mesanterior_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTCantSol_Mesanterior, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTCantSol_Mesanterior = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Mesanterior
		{
			get {
				return gxTv_SdtSDTCantSol_Mesanterior; 
			}
			set {
				gxTv_SdtSDTCantSol_Mesanterior = value;
				SetDirty("Mesanterior");
			}
		}



		[SoapElement(ElementName="MesActual")]
		[XmlElement(ElementName="MesActual")]
		public string gxTpr_Mesactual_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTCantSol_Mesactual, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTCantSol_Mesactual = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Mesactual
		{
			get {
				return gxTv_SdtSDTCantSol_Mesactual; 
			}
			set {
				gxTv_SdtSDTCantSol_Mesactual = value;
				SetDirty("Mesactual");
			}
		}




		[SoapElement(ElementName="Ayer")]
		[XmlElement(ElementName="Ayer")]
		public long gxTpr_Ayer
		{
			get {
				return gxTv_SdtSDTCantSol_Ayer; 
			}
			set {
				gxTv_SdtSDTCantSol_Ayer = value;
				SetDirty("Ayer");
			}
		}



		[SoapElement(ElementName="AyerFecha")]
		[XmlElement(ElementName="AyerFecha" , IsNullable=true)]
		public string gxTpr_Ayerfecha_Nullable
		{
			get {
				if ( gxTv_SdtSDTCantSol_Ayerfecha == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTCantSol_Ayerfecha).value ;
			}
			set {
				gxTv_SdtSDTCantSol_Ayerfecha = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Ayerfecha
		{
			get {
				return gxTv_SdtSDTCantSol_Ayerfecha; 
			}
			set {
				gxTv_SdtSDTCantSol_Ayerfecha = value;
				SetDirty("Ayerfecha");
			}
		}



		[SoapElement(ElementName="AyerTurnos")]
		[XmlElement(ElementName="AyerTurnos")]
		public string gxTpr_Ayerturnos
		{
			get {
				return gxTv_SdtSDTCantSol_Ayerturnos; 
			}
			set {
				gxTv_SdtSDTCantSol_Ayerturnos = value;
				SetDirty("Ayerturnos");
			}
		}




		[SoapElement(ElementName="Hoy")]
		[XmlElement(ElementName="Hoy")]
		public long gxTpr_Hoy
		{
			get {
				return gxTv_SdtSDTCantSol_Hoy; 
			}
			set {
				gxTv_SdtSDTCantSol_Hoy = value;
				SetDirty("Hoy");
			}
		}



		[SoapElement(ElementName="HoyFecha")]
		[XmlElement(ElementName="HoyFecha" , IsNullable=true)]
		public string gxTpr_Hoyfecha_Nullable
		{
			get {
				if ( gxTv_SdtSDTCantSol_Hoyfecha == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTCantSol_Hoyfecha).value ;
			}
			set {
				gxTv_SdtSDTCantSol_Hoyfecha = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Hoyfecha
		{
			get {
				return gxTv_SdtSDTCantSol_Hoyfecha; 
			}
			set {
				gxTv_SdtSDTCantSol_Hoyfecha = value;
				SetDirty("Hoyfecha");
			}
		}



		[SoapElement(ElementName="HoyTurnos")]
		[XmlElement(ElementName="HoyTurnos")]
		public string gxTpr_Hoyturnos
		{
			get {
				return gxTv_SdtSDTCantSol_Hoyturnos; 
			}
			set {
				gxTv_SdtSDTCantSol_Hoyturnos = value;
				SetDirty("Hoyturnos");
			}
		}




		[SoapElement(ElementName="Manana")]
		[XmlElement(ElementName="Manana")]
		public long gxTpr_Manana
		{
			get {
				return gxTv_SdtSDTCantSol_Manana; 
			}
			set {
				gxTv_SdtSDTCantSol_Manana = value;
				SetDirty("Manana");
			}
		}



		[SoapElement(ElementName="MananaFecha")]
		[XmlElement(ElementName="MananaFecha" , IsNullable=true)]
		public string gxTpr_Mananafecha_Nullable
		{
			get {
				if ( gxTv_SdtSDTCantSol_Mananafecha == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTCantSol_Mananafecha).value ;
			}
			set {
				gxTv_SdtSDTCantSol_Mananafecha = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Mananafecha
		{
			get {
				return gxTv_SdtSDTCantSol_Mananafecha; 
			}
			set {
				gxTv_SdtSDTCantSol_Mananafecha = value;
				SetDirty("Mananafecha");
			}
		}



		[SoapElement(ElementName="MananaTurnos")]
		[XmlElement(ElementName="MananaTurnos")]
		public string gxTpr_Mananaturnos
		{
			get {
				return gxTv_SdtSDTCantSol_Mananaturnos; 
			}
			set {
				gxTv_SdtSDTCantSol_Mananaturnos = value;
				SetDirty("Mananaturnos");
			}
		}




		[SoapElement(ElementName="PManana")]
		[XmlElement(ElementName="PManana")]
		public long gxTpr_Pmanana
		{
			get {
				return gxTv_SdtSDTCantSol_Pmanana; 
			}
			set {
				gxTv_SdtSDTCantSol_Pmanana = value;
				SetDirty("Pmanana");
			}
		}



		[SoapElement(ElementName="PMananaFecha")]
		[XmlElement(ElementName="PMananaFecha" , IsNullable=true)]
		public string gxTpr_Pmananafecha_Nullable
		{
			get {
				if ( gxTv_SdtSDTCantSol_Pmananafecha == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTCantSol_Pmananafecha).value ;
			}
			set {
				gxTv_SdtSDTCantSol_Pmananafecha = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Pmananafecha
		{
			get {
				return gxTv_SdtSDTCantSol_Pmananafecha; 
			}
			set {
				gxTv_SdtSDTCantSol_Pmananafecha = value;
				SetDirty("Pmananafecha");
			}
		}



		[SoapElement(ElementName="PMananaTurnos")]
		[XmlElement(ElementName="PMananaTurnos")]
		public string gxTpr_Pmananaturnos
		{
			get {
				return gxTv_SdtSDTCantSol_Pmananaturnos; 
			}
			set {
				gxTv_SdtSDTCantSol_Pmananaturnos = value;
				SetDirty("Pmananaturnos");
			}
		}




		[SoapElement(ElementName="Dia1")]
		[XmlElement(ElementName="Dia1")]
		public long gxTpr_Dia1
		{
			get {
				return gxTv_SdtSDTCantSol_Dia1; 
			}
			set {
				gxTv_SdtSDTCantSol_Dia1 = value;
				SetDirty("Dia1");
			}
		}



		[SoapElement(ElementName="Dia1Fecha")]
		[XmlElement(ElementName="Dia1Fecha" , IsNullable=true)]
		public string gxTpr_Dia1fecha_Nullable
		{
			get {
				if ( gxTv_SdtSDTCantSol_Dia1fecha == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTCantSol_Dia1fecha).value ;
			}
			set {
				gxTv_SdtSDTCantSol_Dia1fecha = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Dia1fecha
		{
			get {
				return gxTv_SdtSDTCantSol_Dia1fecha; 
			}
			set {
				gxTv_SdtSDTCantSol_Dia1fecha = value;
				SetDirty("Dia1fecha");
			}
		}



		[SoapElement(ElementName="Dia1Turnos")]
		[XmlElement(ElementName="Dia1Turnos")]
		public string gxTpr_Dia1turnos
		{
			get {
				return gxTv_SdtSDTCantSol_Dia1turnos; 
			}
			set {
				gxTv_SdtSDTCantSol_Dia1turnos = value;
				SetDirty("Dia1turnos");
			}
		}




		[SoapElement(ElementName="Dia2")]
		[XmlElement(ElementName="Dia2")]
		public long gxTpr_Dia2
		{
			get {
				return gxTv_SdtSDTCantSol_Dia2; 
			}
			set {
				gxTv_SdtSDTCantSol_Dia2 = value;
				SetDirty("Dia2");
			}
		}



		[SoapElement(ElementName="Dia2Fecha")]
		[XmlElement(ElementName="Dia2Fecha" , IsNullable=true)]
		public string gxTpr_Dia2fecha_Nullable
		{
			get {
				if ( gxTv_SdtSDTCantSol_Dia2fecha == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTCantSol_Dia2fecha).value ;
			}
			set {
				gxTv_SdtSDTCantSol_Dia2fecha = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Dia2fecha
		{
			get {
				return gxTv_SdtSDTCantSol_Dia2fecha; 
			}
			set {
				gxTv_SdtSDTCantSol_Dia2fecha = value;
				SetDirty("Dia2fecha");
			}
		}



		[SoapElement(ElementName="Dia2Turnos")]
		[XmlElement(ElementName="Dia2Turnos")]
		public string gxTpr_Dia2turnos
		{
			get {
				return gxTv_SdtSDTCantSol_Dia2turnos; 
			}
			set {
				gxTv_SdtSDTCantSol_Dia2turnos = value;
				SetDirty("Dia2turnos");
			}
		}




		[SoapElement(ElementName="Dia3")]
		[XmlElement(ElementName="Dia3")]
		public long gxTpr_Dia3
		{
			get {
				return gxTv_SdtSDTCantSol_Dia3; 
			}
			set {
				gxTv_SdtSDTCantSol_Dia3 = value;
				SetDirty("Dia3");
			}
		}



		[SoapElement(ElementName="Dia3Fecha")]
		[XmlElement(ElementName="Dia3Fecha" , IsNullable=true)]
		public string gxTpr_Dia3fecha_Nullable
		{
			get {
				if ( gxTv_SdtSDTCantSol_Dia3fecha == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTCantSol_Dia3fecha).value ;
			}
			set {
				gxTv_SdtSDTCantSol_Dia3fecha = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Dia3fecha
		{
			get {
				return gxTv_SdtSDTCantSol_Dia3fecha; 
			}
			set {
				gxTv_SdtSDTCantSol_Dia3fecha = value;
				SetDirty("Dia3fecha");
			}
		}



		[SoapElement(ElementName="Dia3Turno")]
		[XmlElement(ElementName="Dia3Turno")]
		public string gxTpr_Dia3turno
		{
			get {
				return gxTv_SdtSDTCantSol_Dia3turno; 
			}
			set {
				gxTv_SdtSDTCantSol_Dia3turno = value;
				SetDirty("Dia3turno");
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
			gxTv_SdtSDTCantSol_Fechaactualizacion = (DateTime)(DateTime.MinValue);






			gxTv_SdtSDTCantSol_Ayerturnos = "";


			gxTv_SdtSDTCantSol_Hoyturnos = "";


			gxTv_SdtSDTCantSol_Mananaturnos = "";


			gxTv_SdtSDTCantSol_Pmananaturnos = "";


			gxTv_SdtSDTCantSol_Dia1turnos = "";


			gxTv_SdtSDTCantSol_Dia2turnos = "";


			gxTv_SdtSDTCantSol_Dia3turno = "";
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

		protected long gxTv_SdtSDTCantSol_Habilitadas;
		 

		protected long gxTv_SdtSDTCantSol_Procesadas;
		 

		protected long gxTv_SdtSDTCantSol_Delegadas;
		 

		protected long gxTv_SdtSDTCantSol_Rechazadas;
		 

		protected long gxTv_SdtSDTCantSol_Aceptadas;
		 

		protected long gxTv_SdtSDTCantSol_Canceladas;
		 

		protected long gxTv_SdtSDTCantSol_Finalizadas;
		 

		protected long gxTv_SdtSDTCantSol_Calificadas;
		 

		protected long gxTv_SdtSDTCantSol_Total;
		 

		protected DateTime gxTv_SdtSDTCantSol_Fechaactualizacion;
		 

		protected long gxTv_SdtSDTCantSol_Proveedorid;
		 

		protected decimal gxTv_SdtSDTCantSol_Totalgenerado;
		 

		protected decimal gxTv_SdtSDTCantSol_Mesanterior;
		 

		protected decimal gxTv_SdtSDTCantSol_Mesactual;
		 

		protected long gxTv_SdtSDTCantSol_Ayer;
		 

		protected DateTime gxTv_SdtSDTCantSol_Ayerfecha;
		 

		protected string gxTv_SdtSDTCantSol_Ayerturnos;
		 

		protected long gxTv_SdtSDTCantSol_Hoy;
		 

		protected DateTime gxTv_SdtSDTCantSol_Hoyfecha;
		 

		protected string gxTv_SdtSDTCantSol_Hoyturnos;
		 

		protected long gxTv_SdtSDTCantSol_Manana;
		 

		protected DateTime gxTv_SdtSDTCantSol_Mananafecha;
		 

		protected string gxTv_SdtSDTCantSol_Mananaturnos;
		 

		protected long gxTv_SdtSDTCantSol_Pmanana;
		 

		protected DateTime gxTv_SdtSDTCantSol_Pmananafecha;
		 

		protected string gxTv_SdtSDTCantSol_Pmananaturnos;
		 

		protected long gxTv_SdtSDTCantSol_Dia1;
		 

		protected DateTime gxTv_SdtSDTCantSol_Dia1fecha;
		 

		protected string gxTv_SdtSDTCantSol_Dia1turnos;
		 

		protected long gxTv_SdtSDTCantSol_Dia2;
		 

		protected DateTime gxTv_SdtSDTCantSol_Dia2fecha;
		 

		protected string gxTv_SdtSDTCantSol_Dia2turnos;
		 

		protected long gxTv_SdtSDTCantSol_Dia3;
		 

		protected DateTime gxTv_SdtSDTCantSol_Dia3fecha;
		 

		protected string gxTv_SdtSDTCantSol_Dia3turno;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTCantSol", Namespace="AlmangoX")]
	public class SdtSDTCantSol_RESTInterface : GxGenericCollectionItem<SdtSDTCantSol>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCantSol_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCantSol_RESTInterface( SdtSDTCantSol psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Habilitadas", Order=0)]
		public  string gxTpr_Habilitadas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Habilitadas, 18, 0));

			}
			set { 
				sdt.gxTpr_Habilitadas = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Procesadas", Order=1)]
		public  string gxTpr_Procesadas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Procesadas, 18, 0));

			}
			set { 
				sdt.gxTpr_Procesadas = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Delegadas", Order=2)]
		public  string gxTpr_Delegadas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Delegadas, 18, 0));

			}
			set { 
				sdt.gxTpr_Delegadas = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Rechazadas", Order=3)]
		public  string gxTpr_Rechazadas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Rechazadas, 18, 0));

			}
			set { 
				sdt.gxTpr_Rechazadas = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Aceptadas", Order=4)]
		public  string gxTpr_Aceptadas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Aceptadas, 18, 0));

			}
			set { 
				sdt.gxTpr_Aceptadas = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Canceladas", Order=5)]
		public  string gxTpr_Canceladas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Canceladas, 18, 0));

			}
			set { 
				sdt.gxTpr_Canceladas = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Finalizadas", Order=6)]
		public  string gxTpr_Finalizadas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Finalizadas, 18, 0));

			}
			set { 
				sdt.gxTpr_Finalizadas = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Calificadas", Order=7)]
		public  string gxTpr_Calificadas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Calificadas, 18, 0));

			}
			set { 
				sdt.gxTpr_Calificadas = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Total", Order=8)]
		public  string gxTpr_Total
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Total, 18, 0));

			}
			set { 
				sdt.gxTpr_Total = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FechaActualizacion", Order=9)]
		public  string gxTpr_Fechaactualizacion
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Fechaactualizacion,context);

			}
			set { 
				sdt.gxTpr_Fechaactualizacion = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="ProveedorId", Order=10)]
		public  string gxTpr_Proveedorid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Proveedorid, 18, 0));

			}
			set { 
				sdt.gxTpr_Proveedorid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TotalGenerado", Order=11)]
		public  string gxTpr_Totalgenerado
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totalgenerado, 18, 2));

			}
			set { 
				sdt.gxTpr_Totalgenerado =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MesAnterior", Order=12)]
		public  string gxTpr_Mesanterior
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Mesanterior, 18, 2));

			}
			set { 
				sdt.gxTpr_Mesanterior =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MesActual", Order=13)]
		public  string gxTpr_Mesactual
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Mesactual, 18, 2));

			}
			set { 
				sdt.gxTpr_Mesactual =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Ayer", Order=14)]
		public  string gxTpr_Ayer
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Ayer, 18, 0));

			}
			set { 
				sdt.gxTpr_Ayer = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="AyerFecha", Order=15)]
		public  string gxTpr_Ayerfecha
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Ayerfecha);

			}
			set { 
				sdt.gxTpr_Ayerfecha = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="AyerTurnos", Order=16)]
		public  string gxTpr_Ayerturnos
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Ayerturnos);

			}
			set { 
				 sdt.gxTpr_Ayerturnos = value;
			}
		}

		[DataMember(Name="Hoy", Order=17)]
		public  string gxTpr_Hoy
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Hoy, 18, 0));

			}
			set { 
				sdt.gxTpr_Hoy = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="HoyFecha", Order=18)]
		public  string gxTpr_Hoyfecha
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Hoyfecha);

			}
			set { 
				sdt.gxTpr_Hoyfecha = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="HoyTurnos", Order=19)]
		public  string gxTpr_Hoyturnos
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Hoyturnos);

			}
			set { 
				 sdt.gxTpr_Hoyturnos = value;
			}
		}

		[DataMember(Name="Manana", Order=20)]
		public  string gxTpr_Manana
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Manana, 18, 0));

			}
			set { 
				sdt.gxTpr_Manana = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MananaFecha", Order=21)]
		public  string gxTpr_Mananafecha
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Mananafecha);

			}
			set { 
				sdt.gxTpr_Mananafecha = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="MananaTurnos", Order=22)]
		public  string gxTpr_Mananaturnos
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mananaturnos);

			}
			set { 
				 sdt.gxTpr_Mananaturnos = value;
			}
		}

		[DataMember(Name="PManana", Order=23)]
		public  string gxTpr_Pmanana
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Pmanana, 18, 0));

			}
			set { 
				sdt.gxTpr_Pmanana = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PMananaFecha", Order=24)]
		public  string gxTpr_Pmananafecha
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Pmananafecha);

			}
			set { 
				sdt.gxTpr_Pmananafecha = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="PMananaTurnos", Order=25)]
		public  string gxTpr_Pmananaturnos
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pmananaturnos);

			}
			set { 
				 sdt.gxTpr_Pmananaturnos = value;
			}
		}

		[DataMember(Name="Dia1", Order=26)]
		public  string gxTpr_Dia1
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Dia1, 18, 0));

			}
			set { 
				sdt.gxTpr_Dia1 = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Dia1Fecha", Order=27)]
		public  string gxTpr_Dia1fecha
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Dia1fecha);

			}
			set { 
				sdt.gxTpr_Dia1fecha = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="Dia1Turnos", Order=28)]
		public  string gxTpr_Dia1turnos
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Dia1turnos);

			}
			set { 
				 sdt.gxTpr_Dia1turnos = value;
			}
		}

		[DataMember(Name="Dia2", Order=29)]
		public  string gxTpr_Dia2
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Dia2, 18, 0));

			}
			set { 
				sdt.gxTpr_Dia2 = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Dia2Fecha", Order=30)]
		public  string gxTpr_Dia2fecha
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Dia2fecha);

			}
			set { 
				sdt.gxTpr_Dia2fecha = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="Dia2Turnos", Order=31)]
		public  string gxTpr_Dia2turnos
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Dia2turnos);

			}
			set { 
				 sdt.gxTpr_Dia2turnos = value;
			}
		}

		[DataMember(Name="Dia3", Order=32)]
		public  string gxTpr_Dia3
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Dia3, 18, 0));

			}
			set { 
				sdt.gxTpr_Dia3 = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Dia3Fecha", Order=33)]
		public  string gxTpr_Dia3fecha
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Dia3fecha);

			}
			set { 
				sdt.gxTpr_Dia3fecha = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="Dia3Turno", Order=34)]
		public  string gxTpr_Dia3turno
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Dia3turno);

			}
			set { 
				 sdt.gxTpr_Dia3turno = value;
			}
		}


		#endregion
		public SdtSDTCantSol sdt
		{
			get { 
				return (SdtSDTCantSol)Sdt;
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
				sdt = new SdtSDTCantSol() ;
			}
		}
	}
	#endregion
}