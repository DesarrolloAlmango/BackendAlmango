/*
				   File: type_SdtSDTFeedBack_Items
			Description: SDTFeedBack
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
	[XmlRoot(ElementName="Items")]
	[XmlType(TypeName="Items" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTFeedBack_Items : GxUserType
	{
		public SdtSDTFeedBack_Items( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTFeedBack_Items_Feedbackprofesionalid = "";

			gxTv_SdtSDTFeedBack_Items_Feedbackcomentario = "";

			gxTv_SdtSDTFeedBack_Items_Imagen = "";
			gxTv_SdtSDTFeedBack_Items_Imagen_gxi = "";

			gxTv_SdtSDTFeedBack_Items_Profesionalnombre = "";

		}

		public SdtSDTFeedBack_Items(IGxContext context)
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
			AddObjectProperty("ProveedorId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Proveedorid, 18, 0)), false);


			AddObjectProperty("FeedBackId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Feedbackid, 18, 0)), false);


			AddObjectProperty("FeedBackSolicitudId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Feedbacksolicitudid, 18, 0)), false);


			AddObjectProperty("FeedBackProfesionalId", gxTpr_Feedbackprofesionalid, false);


			AddObjectProperty("FeedBackNum", gxTpr_Feedbacknum, false);


			AddObjectProperty("FeedBackComentario", gxTpr_Feedbackcomentario, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Feedbackfechaalta)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Feedbackfechaalta)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Feedbackfechaalta)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("FeedBackFechaAlta", sDateCnv, false);



			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Feedbackfechamodif)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Feedbackfechamodif)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Feedbackfechamodif)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("FeedBackFechaModif", sDateCnv, false);



			AddObjectProperty("Imagen", gxTpr_Imagen, false);
			AddObjectProperty("Imagen_GXI", gxTpr_Imagen_gxi, false);



			AddObjectProperty("ProfesionalNombre", gxTpr_Profesionalnombre, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProveedorId")]
		[XmlElement(ElementName="ProveedorId")]
		public long gxTpr_Proveedorid
		{
			get {
				return gxTv_SdtSDTFeedBack_Items_Proveedorid; 
			}
			set {
				gxTv_SdtSDTFeedBack_Items_Proveedorid = value;
				SetDirty("Proveedorid");
			}
		}




		[SoapElement(ElementName="FeedBackId")]
		[XmlElement(ElementName="FeedBackId")]
		public long gxTpr_Feedbackid
		{
			get {
				return gxTv_SdtSDTFeedBack_Items_Feedbackid; 
			}
			set {
				gxTv_SdtSDTFeedBack_Items_Feedbackid = value;
				SetDirty("Feedbackid");
			}
		}




		[SoapElement(ElementName="FeedBackSolicitudId")]
		[XmlElement(ElementName="FeedBackSolicitudId")]
		public long gxTpr_Feedbacksolicitudid
		{
			get {
				return gxTv_SdtSDTFeedBack_Items_Feedbacksolicitudid; 
			}
			set {
				gxTv_SdtSDTFeedBack_Items_Feedbacksolicitudid = value;
				SetDirty("Feedbacksolicitudid");
			}
		}




		[SoapElement(ElementName="FeedBackProfesionalId")]
		[XmlElement(ElementName="FeedBackProfesionalId")]
		public string gxTpr_Feedbackprofesionalid
		{
			get {
				return gxTv_SdtSDTFeedBack_Items_Feedbackprofesionalid; 
			}
			set {
				gxTv_SdtSDTFeedBack_Items_Feedbackprofesionalid = value;
				SetDirty("Feedbackprofesionalid");
			}
		}




		[SoapElement(ElementName="FeedBackNum")]
		[XmlElement(ElementName="FeedBackNum")]
		public long gxTpr_Feedbacknum
		{
			get {
				return gxTv_SdtSDTFeedBack_Items_Feedbacknum; 
			}
			set {
				gxTv_SdtSDTFeedBack_Items_Feedbacknum = value;
				SetDirty("Feedbacknum");
			}
		}




		[SoapElement(ElementName="FeedBackComentario")]
		[XmlElement(ElementName="FeedBackComentario")]
		public string gxTpr_Feedbackcomentario
		{
			get {
				return gxTv_SdtSDTFeedBack_Items_Feedbackcomentario; 
			}
			set {
				gxTv_SdtSDTFeedBack_Items_Feedbackcomentario = value;
				SetDirty("Feedbackcomentario");
			}
		}



		[SoapElement(ElementName="FeedBackFechaAlta")]
		[XmlElement(ElementName="FeedBackFechaAlta" , IsNullable=true)]
		public string gxTpr_Feedbackfechaalta_Nullable
		{
			get {
				if ( gxTv_SdtSDTFeedBack_Items_Feedbackfechaalta == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTFeedBack_Items_Feedbackfechaalta).value ;
			}
			set {
				gxTv_SdtSDTFeedBack_Items_Feedbackfechaalta = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Feedbackfechaalta
		{
			get {
				return gxTv_SdtSDTFeedBack_Items_Feedbackfechaalta; 
			}
			set {
				gxTv_SdtSDTFeedBack_Items_Feedbackfechaalta = value;
				SetDirty("Feedbackfechaalta");
			}
		}


		[SoapElement(ElementName="FeedBackFechaModif")]
		[XmlElement(ElementName="FeedBackFechaModif" , IsNullable=true)]
		public string gxTpr_Feedbackfechamodif_Nullable
		{
			get {
				if ( gxTv_SdtSDTFeedBack_Items_Feedbackfechamodif == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTFeedBack_Items_Feedbackfechamodif).value ;
			}
			set {
				gxTv_SdtSDTFeedBack_Items_Feedbackfechamodif = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Feedbackfechamodif
		{
			get {
				return gxTv_SdtSDTFeedBack_Items_Feedbackfechamodif; 
			}
			set {
				gxTv_SdtSDTFeedBack_Items_Feedbackfechamodif = value;
				SetDirty("Feedbackfechamodif");
			}
		}



		[SoapElement(ElementName="Imagen")]
		[XmlElement(ElementName="Imagen")]
		[GxUpload()]

		public string gxTpr_Imagen
		{
			get {
				return gxTv_SdtSDTFeedBack_Items_Imagen; 
			}
			set {
				gxTv_SdtSDTFeedBack_Items_Imagen = value;
				SetDirty("Imagen");
			}
		}


		[SoapElement(ElementName="Imagen_GXI" )]
		[XmlElement(ElementName="Imagen_GXI" )]
		public string gxTpr_Imagen_gxi
		{
			get {
				return gxTv_SdtSDTFeedBack_Items_Imagen_gxi ;
			}
			set {
				gxTv_SdtSDTFeedBack_Items_Imagen_gxi = value;
				SetDirty("Imagen_gxi");
			}
		}

		[SoapElement(ElementName="ProfesionalNombre")]
		[XmlElement(ElementName="ProfesionalNombre")]
		public string gxTpr_Profesionalnombre
		{
			get {
				return gxTv_SdtSDTFeedBack_Items_Profesionalnombre; 
			}
			set {
				gxTv_SdtSDTFeedBack_Items_Profesionalnombre = value;
				SetDirty("Profesionalnombre");
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
			gxTv_SdtSDTFeedBack_Items_Feedbackprofesionalid = "";

			gxTv_SdtSDTFeedBack_Items_Feedbackcomentario = "";


			gxTv_SdtSDTFeedBack_Items_Imagen = "";gxTv_SdtSDTFeedBack_Items_Imagen_gxi = "";
			gxTv_SdtSDTFeedBack_Items_Profesionalnombre = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected long gxTv_SdtSDTFeedBack_Items_Proveedorid;
		 

		protected long gxTv_SdtSDTFeedBack_Items_Feedbackid;
		 

		protected long gxTv_SdtSDTFeedBack_Items_Feedbacksolicitudid;
		 

		protected string gxTv_SdtSDTFeedBack_Items_Feedbackprofesionalid;
		 

		protected long gxTv_SdtSDTFeedBack_Items_Feedbacknum;
		 

		protected string gxTv_SdtSDTFeedBack_Items_Feedbackcomentario;
		 

		protected DateTime gxTv_SdtSDTFeedBack_Items_Feedbackfechaalta;
		 

		protected DateTime gxTv_SdtSDTFeedBack_Items_Feedbackfechamodif;
		 
		protected string gxTv_SdtSDTFeedBack_Items_Imagen_gxi;
		protected string gxTv_SdtSDTFeedBack_Items_Imagen;
		 

		protected string gxTv_SdtSDTFeedBack_Items_Profesionalnombre;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"Items", Namespace="AlmangoX")]
	public class SdtSDTFeedBack_Items_RESTInterface : GxGenericCollectionItem<SdtSDTFeedBack_Items>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTFeedBack_Items_RESTInterface( ) : base()
		{	
		}

		public SdtSDTFeedBack_Items_RESTInterface( SdtSDTFeedBack_Items psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProveedorId", Order=0)]
		public  string gxTpr_Proveedorid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Proveedorid, 18, 0));

			}
			set { 
				sdt.gxTpr_Proveedorid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FeedBackId", Order=1)]
		public  string gxTpr_Feedbackid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Feedbackid, 18, 0));

			}
			set { 
				sdt.gxTpr_Feedbackid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FeedBackSolicitudId", Order=2)]
		public  string gxTpr_Feedbacksolicitudid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Feedbacksolicitudid, 18, 0));

			}
			set { 
				sdt.gxTpr_Feedbacksolicitudid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FeedBackProfesionalId", Order=3)]
		public  string gxTpr_Feedbackprofesionalid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Feedbackprofesionalid);

			}
			set { 
				 sdt.gxTpr_Feedbackprofesionalid = value;
			}
		}

		[DataMember(Name="FeedBackNum", Order=4)]
		public  string gxTpr_Feedbacknum
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Feedbacknum, 10, 0));

			}
			set { 
				sdt.gxTpr_Feedbacknum = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FeedBackComentario", Order=5)]
		public  string gxTpr_Feedbackcomentario
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Feedbackcomentario);

			}
			set { 
				 sdt.gxTpr_Feedbackcomentario = value;
			}
		}

		[DataMember(Name="FeedBackFechaAlta", Order=6)]
		public  string gxTpr_Feedbackfechaalta
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Feedbackfechaalta);

			}
			set { 
				sdt.gxTpr_Feedbackfechaalta = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="FeedBackFechaModif", Order=7)]
		public  string gxTpr_Feedbackfechamodif
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Feedbackfechamodif);

			}
			set { 
				sdt.gxTpr_Feedbackfechamodif = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="Imagen", Order=8)]
		[GxUpload()]
		public  string gxTpr_Imagen
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Imagen)) ? PathUtil.RelativePath( sdt.gxTpr_Imagen) : StringUtil.RTrim( sdt.gxTpr_Imagen_gxi));

			}
			set { 
				 sdt.gxTpr_Imagen = value;
			}
		}

		[DataMember(Name="ProfesionalNombre", Order=9)]
		public  string gxTpr_Profesionalnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Profesionalnombre);

			}
			set { 
				 sdt.gxTpr_Profesionalnombre = value;
			}
		}


		#endregion
		public SdtSDTFeedBack_Items sdt
		{
			get { 
				return (SdtSDTFeedBack_Items)Sdt;
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
				sdt = new SdtSDTFeedBack_Items() ;
			}
		}
	}
	#endregion
}