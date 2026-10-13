/*
				   File: type_SdtSDTSolicitudesAceptadas
			Description: SDTSolicitudesAceptadas
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
	[XmlRoot(ElementName="SDTSolicitudesAceptadas")]
	[XmlType(TypeName="SDTSolicitudesAceptadas" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTSolicitudesAceptadas : GxUserType
	{
		public SdtSDTSolicitudesAceptadas( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTSolicitudesAceptadas_Cliente = "";

			gxTv_SdtSDTSolicitudesAceptadas_Direccion = "";

			gxTv_SdtSDTSolicitudesAceptadas_Turnodsc = "";

			gxTv_SdtSDTSolicitudesAceptadas_Turno = "";

			gxTv_SdtSDTSolicitudesAceptadas_Rubronombre = "";


		}

		public SdtSDTSolicitudesAceptadas(IGxContext context)
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
			AddObjectProperty("Id", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Id, 18, 0)), false);


			AddObjectProperty("Cliente", gxTpr_Cliente, false);


			AddObjectProperty("Direccion", gxTpr_Direccion, false);


			AddObjectProperty("TurnoDsc", gxTpr_Turnodsc, false);


			AddObjectProperty("Turno", gxTpr_Turno, false);


			AddObjectProperty("RubroId", gxTpr_Rubroid, false);


			AddObjectProperty("RubroNombre", gxTpr_Rubronombre, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Fechainstalacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Fechainstalacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Fechainstalacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("FechaInstalacion", sDateCnv, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public long gxTpr_Id
		{
			get {
				return gxTv_SdtSDTSolicitudesAceptadas_Id; 
			}
			set {
				gxTv_SdtSDTSolicitudesAceptadas_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Cliente")]
		[XmlElement(ElementName="Cliente")]
		public string gxTpr_Cliente
		{
			get {
				return gxTv_SdtSDTSolicitudesAceptadas_Cliente; 
			}
			set {
				gxTv_SdtSDTSolicitudesAceptadas_Cliente = value;
				SetDirty("Cliente");
			}
		}




		[SoapElement(ElementName="Direccion")]
		[XmlElement(ElementName="Direccion")]
		public string gxTpr_Direccion
		{
			get {
				return gxTv_SdtSDTSolicitudesAceptadas_Direccion; 
			}
			set {
				gxTv_SdtSDTSolicitudesAceptadas_Direccion = value;
				SetDirty("Direccion");
			}
		}




		[SoapElement(ElementName="TurnoDsc")]
		[XmlElement(ElementName="TurnoDsc")]
		public string gxTpr_Turnodsc
		{
			get {
				return gxTv_SdtSDTSolicitudesAceptadas_Turnodsc; 
			}
			set {
				gxTv_SdtSDTSolicitudesAceptadas_Turnodsc = value;
				SetDirty("Turnodsc");
			}
		}




		[SoapElement(ElementName="Turno")]
		[XmlElement(ElementName="Turno")]
		public string gxTpr_Turno
		{
			get {
				return gxTv_SdtSDTSolicitudesAceptadas_Turno; 
			}
			set {
				gxTv_SdtSDTSolicitudesAceptadas_Turno = value;
				SetDirty("Turno");
			}
		}




		[SoapElement(ElementName="RubroId")]
		[XmlElement(ElementName="RubroId")]
		public short gxTpr_Rubroid
		{
			get {
				return gxTv_SdtSDTSolicitudesAceptadas_Rubroid; 
			}
			set {
				gxTv_SdtSDTSolicitudesAceptadas_Rubroid = value;
				SetDirty("Rubroid");
			}
		}




		[SoapElement(ElementName="RubroNombre")]
		[XmlElement(ElementName="RubroNombre")]
		public string gxTpr_Rubronombre
		{
			get {
				return gxTv_SdtSDTSolicitudesAceptadas_Rubronombre; 
			}
			set {
				gxTv_SdtSDTSolicitudesAceptadas_Rubronombre = value;
				SetDirty("Rubronombre");
			}
		}



		[SoapElement(ElementName="FechaInstalacion")]
		[XmlElement(ElementName="FechaInstalacion" , IsNullable=true)]
		public string gxTpr_Fechainstalacion_Nullable
		{
			get {
				if ( gxTv_SdtSDTSolicitudesAceptadas_Fechainstalacion == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTSolicitudesAceptadas_Fechainstalacion).value ;
			}
			set {
				gxTv_SdtSDTSolicitudesAceptadas_Fechainstalacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Fechainstalacion
		{
			get {
				return gxTv_SdtSDTSolicitudesAceptadas_Fechainstalacion; 
			}
			set {
				gxTv_SdtSDTSolicitudesAceptadas_Fechainstalacion = value;
				SetDirty("Fechainstalacion");
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
			gxTv_SdtSDTSolicitudesAceptadas_Cliente = "";
			gxTv_SdtSDTSolicitudesAceptadas_Direccion = "";
			gxTv_SdtSDTSolicitudesAceptadas_Turnodsc = "";
			gxTv_SdtSDTSolicitudesAceptadas_Turno = "";

			gxTv_SdtSDTSolicitudesAceptadas_Rubronombre = "";

			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected long gxTv_SdtSDTSolicitudesAceptadas_Id;
		 

		protected string gxTv_SdtSDTSolicitudesAceptadas_Cliente;
		 

		protected string gxTv_SdtSDTSolicitudesAceptadas_Direccion;
		 

		protected string gxTv_SdtSDTSolicitudesAceptadas_Turnodsc;
		 

		protected string gxTv_SdtSDTSolicitudesAceptadas_Turno;
		 

		protected short gxTv_SdtSDTSolicitudesAceptadas_Rubroid;
		 

		protected string gxTv_SdtSDTSolicitudesAceptadas_Rubronombre;
		 

		protected DateTime gxTv_SdtSDTSolicitudesAceptadas_Fechainstalacion;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTSolicitudesAceptadas", Namespace="AlmangoX")]
	public class SdtSDTSolicitudesAceptadas_RESTInterface : GxGenericCollectionItem<SdtSDTSolicitudesAceptadas>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTSolicitudesAceptadas_RESTInterface( ) : base()
		{	
		}

		public SdtSDTSolicitudesAceptadas_RESTInterface( SdtSDTSolicitudesAceptadas psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Id, 18, 0));

			}
			set { 
				sdt.gxTpr_Id = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Cliente", Order=1)]
		public  string gxTpr_Cliente
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Cliente);

			}
			set { 
				 sdt.gxTpr_Cliente = value;
			}
		}

		[DataMember(Name="Direccion", Order=2)]
		public  string gxTpr_Direccion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Direccion);

			}
			set { 
				 sdt.gxTpr_Direccion = value;
			}
		}

		[DataMember(Name="TurnoDsc", Order=3)]
		public  string gxTpr_Turnodsc
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Turnodsc);

			}
			set { 
				 sdt.gxTpr_Turnodsc = value;
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

		[DataMember(Name="RubroId", Order=5)]
		public short gxTpr_Rubroid
		{
			get { 
				return sdt.gxTpr_Rubroid;

			}
			set { 
				sdt.gxTpr_Rubroid = value;
			}
		}

		[DataMember(Name="RubroNombre", Order=6)]
		public  string gxTpr_Rubronombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Rubronombre);

			}
			set { 
				 sdt.gxTpr_Rubronombre = value;
			}
		}

		[DataMember(Name="FechaInstalacion", Order=7)]
		public  string gxTpr_Fechainstalacion
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Fechainstalacion);

			}
			set { 
				sdt.gxTpr_Fechainstalacion = DateTimeUtil.CToD2(value);
			}
		}


		#endregion
		public SdtSDTSolicitudesAceptadas sdt
		{
			get { 
				return (SdtSDTSolicitudesAceptadas)Sdt;
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
				sdt = new SdtSDTSolicitudesAceptadas() ;
			}
		}
	}
	#endregion
}