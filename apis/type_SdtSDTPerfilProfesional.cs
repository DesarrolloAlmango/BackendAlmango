/*
				   File: type_SdtSDTPerfilProfesional
			Description: SDTPerfilProfesional
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
	[XmlRoot(ElementName="SDTPerfilProfesional")]
	[XmlType(TypeName="SDTPerfilProfesional" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTPerfilProfesional : GxUserType
	{
		public SdtSDTPerfilProfesional( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTPerfilProfesional_Profesionalesid = "";

			gxTv_SdtSDTPerfilProfesional_Profesionalesprimernombre = "";

			gxTv_SdtSDTPerfilProfesional_Profesionalesapellidoprimero = "";

			gxTv_SdtSDTPerfilProfesional_Profesionalesphoto = "";
			gxTv_SdtSDTPerfilProfesional_Profesionalesphoto_gxi = "";

			gxTv_SdtSDTPerfilProfesional_Profesionalesexperiencia = "";

			gxTv_SdtSDTPerfilProfesional_Turnopropuesto = "";

			gxTv_SdtSDTPerfilProfesional_Estadopostulacion = "";

		}

		public SdtSDTPerfilProfesional(IGxContext context)
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
			AddObjectProperty("ProfesionalesId", gxTpr_Profesionalesid, false);


			AddObjectProperty("ProfesionalesPrimerNombre", gxTpr_Profesionalesprimernombre, false);


			AddObjectProperty("ProfesionalesApellidoPrimero", gxTpr_Profesionalesapellidoprimero, false);


			AddObjectProperty("ProfesionalesPhoto", gxTpr_Profesionalesphoto, false);
			AddObjectProperty("ProfesionalesPhoto_GXI", gxTpr_Profesionalesphoto_gxi, false);



			AddObjectProperty("TrabajosFinalizados", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Trabajosfinalizados, 18, 0)), false);


			AddObjectProperty("Calificacion", gxTpr_Calificacion, false);


			AddObjectProperty("TrabajosCalificados", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Trabajoscalificados, 18, 0)), false);


			AddObjectProperty("ProfesionalesExperiencia", gxTpr_Profesionalesexperiencia, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Fechapropuesta)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Fechapropuesta)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Fechapropuesta)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("FechaPropuesta", sDateCnv, false);



			AddObjectProperty("TurnoPropuesto", gxTpr_Turnopropuesto, false);


			AddObjectProperty("EstadoPostulacion", gxTpr_Estadopostulacion, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProfesionalesId")]
		[XmlElement(ElementName="ProfesionalesId")]
		public string gxTpr_Profesionalesid
		{
			get {
				return gxTv_SdtSDTPerfilProfesional_Profesionalesid; 
			}
			set {
				gxTv_SdtSDTPerfilProfesional_Profesionalesid = value;
				SetDirty("Profesionalesid");
			}
		}




		[SoapElement(ElementName="ProfesionalesPrimerNombre")]
		[XmlElement(ElementName="ProfesionalesPrimerNombre")]
		public string gxTpr_Profesionalesprimernombre
		{
			get {
				return gxTv_SdtSDTPerfilProfesional_Profesionalesprimernombre; 
			}
			set {
				gxTv_SdtSDTPerfilProfesional_Profesionalesprimernombre = value;
				SetDirty("Profesionalesprimernombre");
			}
		}




		[SoapElement(ElementName="ProfesionalesApellidoPrimero")]
		[XmlElement(ElementName="ProfesionalesApellidoPrimero")]
		public string gxTpr_Profesionalesapellidoprimero
		{
			get {
				return gxTv_SdtSDTPerfilProfesional_Profesionalesapellidoprimero; 
			}
			set {
				gxTv_SdtSDTPerfilProfesional_Profesionalesapellidoprimero = value;
				SetDirty("Profesionalesapellidoprimero");
			}
		}




		[SoapElement(ElementName="ProfesionalesPhoto")]
		[XmlElement(ElementName="ProfesionalesPhoto")]
		[GxUpload()]

		public string gxTpr_Profesionalesphoto
		{
			get {
				return gxTv_SdtSDTPerfilProfesional_Profesionalesphoto; 
			}
			set {
				gxTv_SdtSDTPerfilProfesional_Profesionalesphoto = value;
				SetDirty("Profesionalesphoto");
			}
		}


		[SoapElement(ElementName="ProfesionalesPhoto_GXI" )]
		[XmlElement(ElementName="ProfesionalesPhoto_GXI" )]
		public string gxTpr_Profesionalesphoto_gxi
		{
			get {
				return gxTv_SdtSDTPerfilProfesional_Profesionalesphoto_gxi ;
			}
			set {
				gxTv_SdtSDTPerfilProfesional_Profesionalesphoto_gxi = value;
				SetDirty("Profesionalesphoto_gxi");
			}
		}

		[SoapElement(ElementName="TrabajosFinalizados")]
		[XmlElement(ElementName="TrabajosFinalizados")]
		public long gxTpr_Trabajosfinalizados
		{
			get {
				return gxTv_SdtSDTPerfilProfesional_Trabajosfinalizados; 
			}
			set {
				gxTv_SdtSDTPerfilProfesional_Trabajosfinalizados = value;
				SetDirty("Trabajosfinalizados");
			}
		}



		[SoapElement(ElementName="Calificacion")]
		[XmlElement(ElementName="Calificacion")]
		public string gxTpr_Calificacion_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTPerfilProfesional_Calificacion, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTPerfilProfesional_Calificacion = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Calificacion
		{
			get {
				return gxTv_SdtSDTPerfilProfesional_Calificacion; 
			}
			set {
				gxTv_SdtSDTPerfilProfesional_Calificacion = value;
				SetDirty("Calificacion");
			}
		}




		[SoapElement(ElementName="TrabajosCalificados")]
		[XmlElement(ElementName="TrabajosCalificados")]
		public long gxTpr_Trabajoscalificados
		{
			get {
				return gxTv_SdtSDTPerfilProfesional_Trabajoscalificados; 
			}
			set {
				gxTv_SdtSDTPerfilProfesional_Trabajoscalificados = value;
				SetDirty("Trabajoscalificados");
			}
		}




		[SoapElement(ElementName="ProfesionalesExperiencia")]
		[XmlElement(ElementName="ProfesionalesExperiencia")]
		public string gxTpr_Profesionalesexperiencia
		{
			get {
				return gxTv_SdtSDTPerfilProfesional_Profesionalesexperiencia; 
			}
			set {
				gxTv_SdtSDTPerfilProfesional_Profesionalesexperiencia = value;
				SetDirty("Profesionalesexperiencia");
			}
		}



		[SoapElement(ElementName="FechaPropuesta")]
		[XmlElement(ElementName="FechaPropuesta" , IsNullable=true)]
		public string gxTpr_Fechapropuesta_Nullable
		{
			get {
				if ( gxTv_SdtSDTPerfilProfesional_Fechapropuesta == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTPerfilProfesional_Fechapropuesta).value ;
			}
			set {
				gxTv_SdtSDTPerfilProfesional_Fechapropuesta = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Fechapropuesta
		{
			get {
				return gxTv_SdtSDTPerfilProfesional_Fechapropuesta; 
			}
			set {
				gxTv_SdtSDTPerfilProfesional_Fechapropuesta = value;
				SetDirty("Fechapropuesta");
			}
		}



		[SoapElement(ElementName="TurnoPropuesto")]
		[XmlElement(ElementName="TurnoPropuesto")]
		public string gxTpr_Turnopropuesto
		{
			get {
				return gxTv_SdtSDTPerfilProfesional_Turnopropuesto; 
			}
			set {
				gxTv_SdtSDTPerfilProfesional_Turnopropuesto = value;
				SetDirty("Turnopropuesto");
			}
		}




		[SoapElement(ElementName="EstadoPostulacion")]
		[XmlElement(ElementName="EstadoPostulacion")]
		public string gxTpr_Estadopostulacion
		{
			get {
				return gxTv_SdtSDTPerfilProfesional_Estadopostulacion; 
			}
			set {
				gxTv_SdtSDTPerfilProfesional_Estadopostulacion = value;
				SetDirty("Estadopostulacion");
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
			gxTv_SdtSDTPerfilProfesional_Profesionalesid = "";
			gxTv_SdtSDTPerfilProfesional_Profesionalesprimernombre = "";
			gxTv_SdtSDTPerfilProfesional_Profesionalesapellidoprimero = "";
			gxTv_SdtSDTPerfilProfesional_Profesionalesphoto = "";gxTv_SdtSDTPerfilProfesional_Profesionalesphoto_gxi = "";



			gxTv_SdtSDTPerfilProfesional_Profesionalesexperiencia = "";

			gxTv_SdtSDTPerfilProfesional_Turnopropuesto = "";
			gxTv_SdtSDTPerfilProfesional_Estadopostulacion = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtSDTPerfilProfesional_Profesionalesid;
		 

		protected string gxTv_SdtSDTPerfilProfesional_Profesionalesprimernombre;
		 

		protected string gxTv_SdtSDTPerfilProfesional_Profesionalesapellidoprimero;
		 
		protected string gxTv_SdtSDTPerfilProfesional_Profesionalesphoto_gxi;
		protected string gxTv_SdtSDTPerfilProfesional_Profesionalesphoto;
		 

		protected long gxTv_SdtSDTPerfilProfesional_Trabajosfinalizados;
		 

		protected decimal gxTv_SdtSDTPerfilProfesional_Calificacion;
		 

		protected long gxTv_SdtSDTPerfilProfesional_Trabajoscalificados;
		 

		protected string gxTv_SdtSDTPerfilProfesional_Profesionalesexperiencia;
		 

		protected DateTime gxTv_SdtSDTPerfilProfesional_Fechapropuesta;
		 

		protected string gxTv_SdtSDTPerfilProfesional_Turnopropuesto;
		 

		protected string gxTv_SdtSDTPerfilProfesional_Estadopostulacion;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTPerfilProfesional", Namespace="AlmangoX")]
	public class SdtSDTPerfilProfesional_RESTInterface : GxGenericCollectionItem<SdtSDTPerfilProfesional>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTPerfilProfesional_RESTInterface( ) : base()
		{	
		}

		public SdtSDTPerfilProfesional_RESTInterface( SdtSDTPerfilProfesional psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProfesionalesId", Order=0)]
		public  string gxTpr_Profesionalesid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Profesionalesid);

			}
			set { 
				 sdt.gxTpr_Profesionalesid = value;
			}
		}

		[DataMember(Name="ProfesionalesPrimerNombre", Order=1)]
		public  string gxTpr_Profesionalesprimernombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Profesionalesprimernombre);

			}
			set { 
				 sdt.gxTpr_Profesionalesprimernombre = value;
			}
		}

		[DataMember(Name="ProfesionalesApellidoPrimero", Order=2)]
		public  string gxTpr_Profesionalesapellidoprimero
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Profesionalesapellidoprimero);

			}
			set { 
				 sdt.gxTpr_Profesionalesapellidoprimero = value;
			}
		}

		[DataMember(Name="ProfesionalesPhoto", Order=3)]
		[GxUpload()]
		public  string gxTpr_Profesionalesphoto
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Profesionalesphoto)) ? PathUtil.RelativePath( sdt.gxTpr_Profesionalesphoto) : StringUtil.RTrim( sdt.gxTpr_Profesionalesphoto_gxi));

			}
			set { 
				 sdt.gxTpr_Profesionalesphoto = value;
			}
		}

		[DataMember(Name="TrabajosFinalizados", Order=4)]
		public  string gxTpr_Trabajosfinalizados
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Trabajosfinalizados, 18, 0));

			}
			set { 
				sdt.gxTpr_Trabajosfinalizados = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Calificacion", Order=5)]
		public decimal gxTpr_Calificacion
		{
			get { 
				return sdt.gxTpr_Calificacion;

			}
			set { 
				sdt.gxTpr_Calificacion = value;
			}
		}

		[DataMember(Name="TrabajosCalificados", Order=6)]
		public  string gxTpr_Trabajoscalificados
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Trabajoscalificados, 18, 0));

			}
			set { 
				sdt.gxTpr_Trabajoscalificados = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProfesionalesExperiencia", Order=7)]
		public  string gxTpr_Profesionalesexperiencia
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Profesionalesexperiencia);

			}
			set { 
				 sdt.gxTpr_Profesionalesexperiencia = value;
			}
		}

		[DataMember(Name="FechaPropuesta", Order=8)]
		public  string gxTpr_Fechapropuesta
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Fechapropuesta);

			}
			set { 
				sdt.gxTpr_Fechapropuesta = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TurnoPropuesto", Order=9)]
		public  string gxTpr_Turnopropuesto
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Turnopropuesto);

			}
			set { 
				 sdt.gxTpr_Turnopropuesto = value;
			}
		}

		[DataMember(Name="EstadoPostulacion", Order=10)]
		public  string gxTpr_Estadopostulacion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Estadopostulacion);

			}
			set { 
				 sdt.gxTpr_Estadopostulacion = value;
			}
		}


		#endregion
		public SdtSDTPerfilProfesional sdt
		{
			get { 
				return (SdtSDTPerfilProfesional)Sdt;
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
				sdt = new SdtSDTPerfilProfesional() ;
			}
		}
	}
	#endregion
}