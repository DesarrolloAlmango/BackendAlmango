/*
				   File: type_SdtSdtAltaPostulacion
			Description: SdtAltaPostulacion
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

using GeneXus.Programs;

namespace GeneXus.Programs.apis
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="SdtAltaPostulacion")]
	[XmlType(TypeName="SdtAltaPostulacion" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSdtAltaPostulacion : GxUserType
	{
		public SdtSdtAltaPostulacion( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdtAltaPostulacion_User = "";

			gxTv_SdtSdtAltaPostulacion_Profesionalesid = "";

			gxTv_SdtSdtAltaPostulacion_Turno = "";

			gxTv_SdtSdtAltaPostulacion_Plazoejecucionunidad = "";

			gxTv_SdtSdtAltaPostulacion_Plazogarantiaunidad = "";

			gxTv_SdtSdtAltaPostulacion_Aclaraciones = "";

		}

		public SdtSdtAltaPostulacion(IGxContext context)
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
			AddObjectProperty("User", gxTpr_User, false);


			AddObjectProperty("ProfesionalesId", gxTpr_Profesionalesid, false);


			AddObjectProperty("SolicitudesId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Solicitudesid, 18, 0)), false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Fechatrabajo)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Fechatrabajo)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Fechatrabajo)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("FechaTrabajo", sDateCnv, false);



			AddObjectProperty("Turno", gxTpr_Turno, false);


			AddObjectProperty("Precio", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Precio, 18, 2)), false);


			AddObjectProperty("PlazoEjecucion", gxTpr_Plazoejecucion, false);


			AddObjectProperty("PlazoEjecucionUnidad", gxTpr_Plazoejecucionunidad, false);


			AddObjectProperty("PlazoGarantia", gxTpr_Plazogarantia, false);


			AddObjectProperty("PlazoGarantiaUnidad", gxTpr_Plazogarantiaunidad, false);


			AddObjectProperty("Aclaraciones", gxTpr_Aclaraciones, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="User")]
		[XmlElement(ElementName="User")]
		public string gxTpr_User
		{
			get {
				return gxTv_SdtSdtAltaPostulacion_User; 
			}
			set {
				gxTv_SdtSdtAltaPostulacion_User = value;
				SetDirty("User");
			}
		}




		[SoapElement(ElementName="ProfesionalesId")]
		[XmlElement(ElementName="ProfesionalesId")]
		public string gxTpr_Profesionalesid
		{
			get {
				return gxTv_SdtSdtAltaPostulacion_Profesionalesid; 
			}
			set {
				gxTv_SdtSdtAltaPostulacion_Profesionalesid = value;
				SetDirty("Profesionalesid");
			}
		}




		[SoapElement(ElementName="SolicitudesId")]
		[XmlElement(ElementName="SolicitudesId")]
		public long gxTpr_Solicitudesid
		{
			get {
				return gxTv_SdtSdtAltaPostulacion_Solicitudesid; 
			}
			set {
				gxTv_SdtSdtAltaPostulacion_Solicitudesid = value;
				SetDirty("Solicitudesid");
			}
		}



		[SoapElement(ElementName="FechaTrabajo")]
		[XmlElement(ElementName="FechaTrabajo" , IsNullable=true)]
		public string gxTpr_Fechatrabajo_Nullable
		{
			get {
				if ( gxTv_SdtSdtAltaPostulacion_Fechatrabajo == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSdtAltaPostulacion_Fechatrabajo).value ;
			}
			set {
				gxTv_SdtSdtAltaPostulacion_Fechatrabajo = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Fechatrabajo
		{
			get {
				return gxTv_SdtSdtAltaPostulacion_Fechatrabajo; 
			}
			set {
				gxTv_SdtSdtAltaPostulacion_Fechatrabajo = value;
				SetDirty("Fechatrabajo");
			}
		}



		[SoapElement(ElementName="Turno")]
		[XmlElement(ElementName="Turno")]
		public string gxTpr_Turno
		{
			get {
				return gxTv_SdtSdtAltaPostulacion_Turno; 
			}
			set {
				gxTv_SdtSdtAltaPostulacion_Turno = value;
				SetDirty("Turno");
			}
		}



		[SoapElement(ElementName="Precio")]
		[XmlElement(ElementName="Precio")]
		public string gxTpr_Precio_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtAltaPostulacion_Precio, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtAltaPostulacion_Precio = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Precio
		{
			get {
				return gxTv_SdtSdtAltaPostulacion_Precio; 
			}
			set {
				gxTv_SdtSdtAltaPostulacion_Precio = value;
				SetDirty("Precio");
			}
		}




		[SoapElement(ElementName="PlazoEjecucion")]
		[XmlElement(ElementName="PlazoEjecucion")]
		public short gxTpr_Plazoejecucion
		{
			get {
				return gxTv_SdtSdtAltaPostulacion_Plazoejecucion; 
			}
			set {
				gxTv_SdtSdtAltaPostulacion_Plazoejecucion = value;
				SetDirty("Plazoejecucion");
			}
		}




		[SoapElement(ElementName="PlazoEjecucionUnidad")]
		[XmlElement(ElementName="PlazoEjecucionUnidad")]
		public string gxTpr_Plazoejecucionunidad
		{
			get {
				return gxTv_SdtSdtAltaPostulacion_Plazoejecucionunidad; 
			}
			set {
				gxTv_SdtSdtAltaPostulacion_Plazoejecucionunidad = value;
				SetDirty("Plazoejecucionunidad");
			}
		}




		[SoapElement(ElementName="PlazoGarantia")]
		[XmlElement(ElementName="PlazoGarantia")]
		public short gxTpr_Plazogarantia
		{
			get {
				return gxTv_SdtSdtAltaPostulacion_Plazogarantia; 
			}
			set {
				gxTv_SdtSdtAltaPostulacion_Plazogarantia = value;
				SetDirty("Plazogarantia");
			}
		}




		[SoapElement(ElementName="PlazoGarantiaUnidad")]
		[XmlElement(ElementName="PlazoGarantiaUnidad")]
		public string gxTpr_Plazogarantiaunidad
		{
			get {
				return gxTv_SdtSdtAltaPostulacion_Plazogarantiaunidad; 
			}
			set {
				gxTv_SdtSdtAltaPostulacion_Plazogarantiaunidad = value;
				SetDirty("Plazogarantiaunidad");
			}
		}




		[SoapElement(ElementName="Aclaraciones")]
		[XmlElement(ElementName="Aclaraciones")]
		public string gxTpr_Aclaraciones
		{
			get {
				return gxTv_SdtSdtAltaPostulacion_Aclaraciones; 
			}
			set {
				gxTv_SdtSdtAltaPostulacion_Aclaraciones = value;
				SetDirty("Aclaraciones");
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
			gxTv_SdtSdtAltaPostulacion_User = "";
			gxTv_SdtSdtAltaPostulacion_Profesionalesid = "";


			gxTv_SdtSdtAltaPostulacion_Turno = "";


			gxTv_SdtSdtAltaPostulacion_Plazoejecucionunidad = "";

			gxTv_SdtSdtAltaPostulacion_Plazogarantiaunidad = "";
			gxTv_SdtSdtAltaPostulacion_Aclaraciones = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtSdtAltaPostulacion_User;
		 

		protected string gxTv_SdtSdtAltaPostulacion_Profesionalesid;
		 

		protected long gxTv_SdtSdtAltaPostulacion_Solicitudesid;
		 

		protected DateTime gxTv_SdtSdtAltaPostulacion_Fechatrabajo;
		 

		protected string gxTv_SdtSdtAltaPostulacion_Turno;
		 

		protected decimal gxTv_SdtSdtAltaPostulacion_Precio;
		 

		protected short gxTv_SdtSdtAltaPostulacion_Plazoejecucion;
		 

		protected string gxTv_SdtSdtAltaPostulacion_Plazoejecucionunidad;
		 

		protected short gxTv_SdtSdtAltaPostulacion_Plazogarantia;
		 

		protected string gxTv_SdtSdtAltaPostulacion_Plazogarantiaunidad;
		 

		protected string gxTv_SdtSdtAltaPostulacion_Aclaraciones;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdtAltaPostulacion", Namespace="AlmangoX")]
	public class SdtSdtAltaPostulacion_RESTInterface : GxGenericCollectionItem<SdtSdtAltaPostulacion>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdtAltaPostulacion_RESTInterface( ) : base()
		{	
		}

		public SdtSdtAltaPostulacion_RESTInterface( SdtSdtAltaPostulacion psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="User", Order=0)]
		public  string gxTpr_User
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_User);

			}
			set { 
				 sdt.gxTpr_User = value;
			}
		}

		[DataMember(Name="ProfesionalesId", Order=1)]
		public  string gxTpr_Profesionalesid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Profesionalesid);

			}
			set { 
				 sdt.gxTpr_Profesionalesid = value;
			}
		}

		[DataMember(Name="SolicitudesId", Order=2)]
		public  string gxTpr_Solicitudesid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Solicitudesid, 18, 0));

			}
			set { 
				sdt.gxTpr_Solicitudesid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FechaTrabajo", Order=3)]
		public  string gxTpr_Fechatrabajo
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Fechatrabajo);

			}
			set { 
				sdt.gxTpr_Fechatrabajo = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="Turno", Order=4)]
		public  string gxTpr_Turno
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Turno);

			}
			set { 
				 sdt.gxTpr_Turno = value;
			}
		}

		[DataMember(Name="Precio", Order=5)]
		public  string gxTpr_Precio
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Precio, 18, 2));

			}
			set { 
				sdt.gxTpr_Precio =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PlazoEjecucion", Order=6)]
		public short gxTpr_Plazoejecucion
		{
			get { 
				return sdt.gxTpr_Plazoejecucion;

			}
			set { 
				sdt.gxTpr_Plazoejecucion = value;
			}
		}

		[DataMember(Name="PlazoEjecucionUnidad", Order=7)]
		public  string gxTpr_Plazoejecucionunidad
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Plazoejecucionunidad);

			}
			set { 
				 sdt.gxTpr_Plazoejecucionunidad = value;
			}
		}

		[DataMember(Name="PlazoGarantia", Order=8)]
		public short gxTpr_Plazogarantia
		{
			get { 
				return sdt.gxTpr_Plazogarantia;

			}
			set { 
				sdt.gxTpr_Plazogarantia = value;
			}
		}

		[DataMember(Name="PlazoGarantiaUnidad", Order=9)]
		public  string gxTpr_Plazogarantiaunidad
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Plazogarantiaunidad);

			}
			set { 
				 sdt.gxTpr_Plazogarantiaunidad = value;
			}
		}

		[DataMember(Name="Aclaraciones", Order=10)]
		public  string gxTpr_Aclaraciones
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Aclaraciones);

			}
			set { 
				 sdt.gxTpr_Aclaraciones = value;
			}
		}


		#endregion
		public SdtSdtAltaPostulacion sdt
		{
			get { 
				return (SdtSdtAltaPostulacion)Sdt;
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
				sdt = new SdtSdtAltaPostulacion() ;
			}
		}
	}
	#endregion
}