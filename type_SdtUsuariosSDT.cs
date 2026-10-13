/*
				   File: type_SdtUsuariosSDT
			Description: UsuariosSDT
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
	[XmlRoot(ElementName="UsuariosSDT")]
	[XmlType(TypeName="UsuariosSDT" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtUsuariosSDT : GxUserType
	{
		public SdtUsuariosSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtUsuariosSDT_Usuariosid = "";

			gxTv_SdtUsuariosSDT_Usuariostipo = "";

			gxTv_SdtUsuariosSDT_Usuariosnombre = "";

			gxTv_SdtUsuariosSDT_Usuarioscorreo = "";

			gxTv_SdtUsuariosSDT_Paisid = "";

			gxTv_SdtUsuariosSDT_Paisnombre = "";

			gxTv_SdtUsuariosSDT_Usuariosdireccion = "";

			gxTv_SdtUsuariosSDT_Usuariosimagen = "";
			gxTv_SdtUsuariosSDT_Usuariosimagen_gxi = "";

			gxTv_SdtUsuariosSDT_Usuariospasw = "";

			gxTv_SdtUsuariosSDT_Usuariostelefono = "";

			gxTv_SdtUsuariosSDT_Usuariosestado = "";

			gxTv_SdtUsuariosSDT_Usuariosestadoonoffline = "";

			gxTv_SdtUsuariosSDT_Usuarioshoraestadoonoff = (DateTime)(DateTime.MinValue);

			gxTv_SdtUsuariosSDT_Usuariosnumeroidentidad = "";

		}

		public SdtUsuariosSDT(IGxContext context)
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
			AddObjectProperty("usuariosId", gxTpr_Usuariosid, false);


			AddObjectProperty("usuariosTipo", gxTpr_Usuariostipo, false);


			AddObjectProperty("usuariosNombre", gxTpr_Usuariosnombre, false);


			AddObjectProperty("usuariosCorreo", gxTpr_Usuarioscorreo, false);


			AddObjectProperty("PaisID", gxTpr_Paisid, false);


			AddObjectProperty("PaisNombre", gxTpr_Paisnombre, false);


			AddObjectProperty("usuariosDireccion", gxTpr_Usuariosdireccion, false);


			AddObjectProperty("usuariosImagen", gxTpr_Usuariosimagen, false);
			AddObjectProperty("usuariosImagen_GXI", gxTpr_Usuariosimagen_gxi, false);



			AddObjectProperty("usuariosPasw", gxTpr_Usuariospasw, false);


			AddObjectProperty("usuariosCPostal", gxTpr_Usuarioscpostal, false);


			AddObjectProperty("usuariosTelefono", gxTpr_Usuariostelefono, false);


			AddObjectProperty("usuariosEstado", gxTpr_Usuariosestado, false);


			AddObjectProperty("usuariosEstadoOnOffLine", gxTpr_Usuariosestadoonoffline, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Usuariosfechaestadoonoff)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Usuariosfechaestadoonoff)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Usuariosfechaestadoonoff)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("usuariosFechaEstadoOnOff", sDateCnv, false);



			datetime_STZ = gxTpr_Usuarioshoraestadoonoff;
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
			AddObjectProperty("usuariosHoraEstadoOnOff", sDateCnv, false);



			AddObjectProperty("usuariosNumeroIdentidad", gxTpr_Usuariosnumeroidentidad, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="usuariosId")]
		[XmlElement(ElementName="usuariosId")]
		public string gxTpr_Usuariosid
		{
			get {
				return gxTv_SdtUsuariosSDT_Usuariosid; 
			}
			set {
				gxTv_SdtUsuariosSDT_Usuariosid = value;
				SetDirty("Usuariosid");
			}
		}




		[SoapElement(ElementName="usuariosTipo")]
		[XmlElement(ElementName="usuariosTipo")]
		public string gxTpr_Usuariostipo
		{
			get {
				return gxTv_SdtUsuariosSDT_Usuariostipo; 
			}
			set {
				gxTv_SdtUsuariosSDT_Usuariostipo = value;
				SetDirty("Usuariostipo");
			}
		}




		[SoapElement(ElementName="usuariosNombre")]
		[XmlElement(ElementName="usuariosNombre")]
		public string gxTpr_Usuariosnombre
		{
			get {
				return gxTv_SdtUsuariosSDT_Usuariosnombre; 
			}
			set {
				gxTv_SdtUsuariosSDT_Usuariosnombre = value;
				SetDirty("Usuariosnombre");
			}
		}




		[SoapElement(ElementName="usuariosCorreo")]
		[XmlElement(ElementName="usuariosCorreo")]
		public string gxTpr_Usuarioscorreo
		{
			get {
				return gxTv_SdtUsuariosSDT_Usuarioscorreo; 
			}
			set {
				gxTv_SdtUsuariosSDT_Usuarioscorreo = value;
				SetDirty("Usuarioscorreo");
			}
		}




		[SoapElement(ElementName="PaisID")]
		[XmlElement(ElementName="PaisID")]
		public string gxTpr_Paisid
		{
			get {
				return gxTv_SdtUsuariosSDT_Paisid; 
			}
			set {
				gxTv_SdtUsuariosSDT_Paisid = value;
				SetDirty("Paisid");
			}
		}




		[SoapElement(ElementName="PaisNombre")]
		[XmlElement(ElementName="PaisNombre")]
		public string gxTpr_Paisnombre
		{
			get {
				return gxTv_SdtUsuariosSDT_Paisnombre; 
			}
			set {
				gxTv_SdtUsuariosSDT_Paisnombre = value;
				SetDirty("Paisnombre");
			}
		}




		[SoapElement(ElementName="usuariosDireccion")]
		[XmlElement(ElementName="usuariosDireccion")]
		public string gxTpr_Usuariosdireccion
		{
			get {
				return gxTv_SdtUsuariosSDT_Usuariosdireccion; 
			}
			set {
				gxTv_SdtUsuariosSDT_Usuariosdireccion = value;
				SetDirty("Usuariosdireccion");
			}
		}




		[SoapElement(ElementName="usuariosImagen")]
		[XmlElement(ElementName="usuariosImagen")]
		[GxUpload()]

		public string gxTpr_Usuariosimagen
		{
			get {
				return gxTv_SdtUsuariosSDT_Usuariosimagen; 
			}
			set {
				gxTv_SdtUsuariosSDT_Usuariosimagen = value;
				SetDirty("Usuariosimagen");
			}
		}


		[SoapElement(ElementName="usuariosImagen_GXI" )]
		[XmlElement(ElementName="usuariosImagen_GXI" )]
		public string gxTpr_Usuariosimagen_gxi
		{
			get {
				return gxTv_SdtUsuariosSDT_Usuariosimagen_gxi ;
			}
			set {
				gxTv_SdtUsuariosSDT_Usuariosimagen_gxi = value;
				SetDirty("Usuariosimagen_gxi");
			}
		}

		[SoapElement(ElementName="usuariosPasw")]
		[XmlElement(ElementName="usuariosPasw")]
		public string gxTpr_Usuariospasw
		{
			get {
				return gxTv_SdtUsuariosSDT_Usuariospasw; 
			}
			set {
				gxTv_SdtUsuariosSDT_Usuariospasw = value;
				SetDirty("Usuariospasw");
			}
		}




		[SoapElement(ElementName="usuariosCPostal")]
		[XmlElement(ElementName="usuariosCPostal")]
		public int gxTpr_Usuarioscpostal
		{
			get {
				return gxTv_SdtUsuariosSDT_Usuarioscpostal; 
			}
			set {
				gxTv_SdtUsuariosSDT_Usuarioscpostal = value;
				SetDirty("Usuarioscpostal");
			}
		}




		[SoapElement(ElementName="usuariosTelefono")]
		[XmlElement(ElementName="usuariosTelefono")]
		public string gxTpr_Usuariostelefono
		{
			get {
				return gxTv_SdtUsuariosSDT_Usuariostelefono; 
			}
			set {
				gxTv_SdtUsuariosSDT_Usuariostelefono = value;
				SetDirty("Usuariostelefono");
			}
		}




		[SoapElement(ElementName="usuariosEstado")]
		[XmlElement(ElementName="usuariosEstado")]
		public string gxTpr_Usuariosestado
		{
			get {
				return gxTv_SdtUsuariosSDT_Usuariosestado; 
			}
			set {
				gxTv_SdtUsuariosSDT_Usuariosestado = value;
				SetDirty("Usuariosestado");
			}
		}




		[SoapElement(ElementName="usuariosEstadoOnOffLine")]
		[XmlElement(ElementName="usuariosEstadoOnOffLine")]
		public string gxTpr_Usuariosestadoonoffline
		{
			get {
				return gxTv_SdtUsuariosSDT_Usuariosestadoonoffline; 
			}
			set {
				gxTv_SdtUsuariosSDT_Usuariosestadoonoffline = value;
				SetDirty("Usuariosestadoonoffline");
			}
		}



		[SoapElement(ElementName="usuariosFechaEstadoOnOff")]
		[XmlElement(ElementName="usuariosFechaEstadoOnOff" , IsNullable=true)]
		public string gxTpr_Usuariosfechaestadoonoff_Nullable
		{
			get {
				if ( gxTv_SdtUsuariosSDT_Usuariosfechaestadoonoff == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtUsuariosSDT_Usuariosfechaestadoonoff).value ;
			}
			set {
				gxTv_SdtUsuariosSDT_Usuariosfechaestadoonoff = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Usuariosfechaestadoonoff
		{
			get {
				return gxTv_SdtUsuariosSDT_Usuariosfechaestadoonoff; 
			}
			set {
				gxTv_SdtUsuariosSDT_Usuariosfechaestadoonoff = value;
				SetDirty("Usuariosfechaestadoonoff");
			}
		}


		[SoapElement(ElementName="usuariosHoraEstadoOnOff")]
		[XmlElement(ElementName="usuariosHoraEstadoOnOff" , IsNullable=true)]
		public string gxTpr_Usuarioshoraestadoonoff_Nullable
		{
			get {
				if ( gxTv_SdtUsuariosSDT_Usuarioshoraestadoonoff == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtUsuariosSDT_Usuarioshoraestadoonoff).value ;
			}
			set {
				gxTv_SdtUsuariosSDT_Usuarioshoraestadoonoff = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Usuarioshoraestadoonoff
		{
			get {
				return gxTv_SdtUsuariosSDT_Usuarioshoraestadoonoff; 
			}
			set {
				gxTv_SdtUsuariosSDT_Usuarioshoraestadoonoff = value;
				SetDirty("Usuarioshoraestadoonoff");
			}
		}



		[SoapElement(ElementName="usuariosNumeroIdentidad")]
		[XmlElement(ElementName="usuariosNumeroIdentidad")]
		public string gxTpr_Usuariosnumeroidentidad
		{
			get {
				return gxTv_SdtUsuariosSDT_Usuariosnumeroidentidad; 
			}
			set {
				gxTv_SdtUsuariosSDT_Usuariosnumeroidentidad = value;
				SetDirty("Usuariosnumeroidentidad");
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
			gxTv_SdtUsuariosSDT_Usuariosid = "";
			gxTv_SdtUsuariosSDT_Usuariostipo = "";
			gxTv_SdtUsuariosSDT_Usuariosnombre = "";
			gxTv_SdtUsuariosSDT_Usuarioscorreo = "";
			gxTv_SdtUsuariosSDT_Paisid = "";
			gxTv_SdtUsuariosSDT_Paisnombre = "";
			gxTv_SdtUsuariosSDT_Usuariosdireccion = "";
			gxTv_SdtUsuariosSDT_Usuariosimagen = "";gxTv_SdtUsuariosSDT_Usuariosimagen_gxi = "";
			gxTv_SdtUsuariosSDT_Usuariospasw = "";

			gxTv_SdtUsuariosSDT_Usuariostelefono = "";
			gxTv_SdtUsuariosSDT_Usuariosestado = "";
			gxTv_SdtUsuariosSDT_Usuariosestadoonoffline = "";

			gxTv_SdtUsuariosSDT_Usuarioshoraestadoonoff = (DateTime)(DateTime.MinValue);
			gxTv_SdtUsuariosSDT_Usuariosnumeroidentidad = "";
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

		protected string gxTv_SdtUsuariosSDT_Usuariosid;
		 

		protected string gxTv_SdtUsuariosSDT_Usuariostipo;
		 

		protected string gxTv_SdtUsuariosSDT_Usuariosnombre;
		 

		protected string gxTv_SdtUsuariosSDT_Usuarioscorreo;
		 

		protected string gxTv_SdtUsuariosSDT_Paisid;
		 

		protected string gxTv_SdtUsuariosSDT_Paisnombre;
		 

		protected string gxTv_SdtUsuariosSDT_Usuariosdireccion;
		 
		protected string gxTv_SdtUsuariosSDT_Usuariosimagen_gxi;
		protected string gxTv_SdtUsuariosSDT_Usuariosimagen;
		 

		protected string gxTv_SdtUsuariosSDT_Usuariospasw;
		 

		protected int gxTv_SdtUsuariosSDT_Usuarioscpostal;
		 

		protected string gxTv_SdtUsuariosSDT_Usuariostelefono;
		 

		protected string gxTv_SdtUsuariosSDT_Usuariosestado;
		 

		protected string gxTv_SdtUsuariosSDT_Usuariosestadoonoffline;
		 

		protected DateTime gxTv_SdtUsuariosSDT_Usuariosfechaestadoonoff;
		 

		protected DateTime gxTv_SdtUsuariosSDT_Usuarioshoraestadoonoff;
		 

		protected string gxTv_SdtUsuariosSDT_Usuariosnumeroidentidad;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"UsuariosSDT", Namespace="AlmangoX")]
	public class SdtUsuariosSDT_RESTInterface : GxGenericCollectionItem<SdtUsuariosSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtUsuariosSDT_RESTInterface( ) : base()
		{	
		}

		public SdtUsuariosSDT_RESTInterface( SdtUsuariosSDT psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="usuariosId", Order=0)]
		public  string gxTpr_Usuariosid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosid);

			}
			set { 
				 sdt.gxTpr_Usuariosid = value;
			}
		}

		[DataMember(Name="usuariosTipo", Order=1)]
		public  string gxTpr_Usuariostipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariostipo);

			}
			set { 
				 sdt.gxTpr_Usuariostipo = value;
			}
		}

		[DataMember(Name="usuariosNombre", Order=2)]
		public  string gxTpr_Usuariosnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosnombre);

			}
			set { 
				 sdt.gxTpr_Usuariosnombre = value;
			}
		}

		[DataMember(Name="usuariosCorreo", Order=3)]
		public  string gxTpr_Usuarioscorreo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuarioscorreo);

			}
			set { 
				 sdt.gxTpr_Usuarioscorreo = value;
			}
		}

		[DataMember(Name="PaisID", Order=4)]
		public  string gxTpr_Paisid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Paisid);

			}
			set { 
				 sdt.gxTpr_Paisid = value;
			}
		}

		[DataMember(Name="PaisNombre", Order=5)]
		public  string gxTpr_Paisnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Paisnombre);

			}
			set { 
				 sdt.gxTpr_Paisnombre = value;
			}
		}

		[DataMember(Name="usuariosDireccion", Order=6)]
		public  string gxTpr_Usuariosdireccion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosdireccion);

			}
			set { 
				 sdt.gxTpr_Usuariosdireccion = value;
			}
		}

		[DataMember(Name="usuariosImagen", Order=7)]
		[GxUpload()]
		public  string gxTpr_Usuariosimagen
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Usuariosimagen)) ? PathUtil.RelativePath( sdt.gxTpr_Usuariosimagen) : StringUtil.RTrim( sdt.gxTpr_Usuariosimagen_gxi));

			}
			set { 
				 sdt.gxTpr_Usuariosimagen = value;
			}
		}

		[DataMember(Name="usuariosPasw", Order=8)]
		public  string gxTpr_Usuariospasw
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariospasw);

			}
			set { 
				 sdt.gxTpr_Usuariospasw = value;
			}
		}

		[DataMember(Name="usuariosCPostal", Order=9)]
		public int gxTpr_Usuarioscpostal
		{
			get { 
				return sdt.gxTpr_Usuarioscpostal;

			}
			set { 
				sdt.gxTpr_Usuarioscpostal = value;
			}
		}

		[DataMember(Name="usuariosTelefono", Order=10)]
		public  string gxTpr_Usuariostelefono
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariostelefono);

			}
			set { 
				 sdt.gxTpr_Usuariostelefono = value;
			}
		}

		[DataMember(Name="usuariosEstado", Order=11)]
		public  string gxTpr_Usuariosestado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosestado);

			}
			set { 
				 sdt.gxTpr_Usuariosestado = value;
			}
		}

		[DataMember(Name="usuariosEstadoOnOffLine", Order=12)]
		public  string gxTpr_Usuariosestadoonoffline
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosestadoonoffline);

			}
			set { 
				 sdt.gxTpr_Usuariosestadoonoffline = value;
			}
		}

		[DataMember(Name="usuariosFechaEstadoOnOff", Order=13)]
		public  string gxTpr_Usuariosfechaestadoonoff
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Usuariosfechaestadoonoff);

			}
			set { 
				sdt.gxTpr_Usuariosfechaestadoonoff = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="usuariosHoraEstadoOnOff", Order=14)]
		public  string gxTpr_Usuarioshoraestadoonoff
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Usuarioshoraestadoonoff,context);

			}
			set { 
				sdt.gxTpr_Usuarioshoraestadoonoff = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="usuariosNumeroIdentidad", Order=15)]
		public  string gxTpr_Usuariosnumeroidentidad
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosnumeroidentidad);

			}
			set { 
				 sdt.gxTpr_Usuariosnumeroidentidad = value;
			}
		}


		#endregion
		public SdtUsuariosSDT sdt
		{
			get { 
				return (SdtUsuariosSDT)Sdt;
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
				sdt = new SdtUsuariosSDT() ;
			}
		}
	}
	#endregion
}