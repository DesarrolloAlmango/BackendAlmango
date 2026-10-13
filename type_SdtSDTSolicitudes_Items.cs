/*
				   File: type_SdtSDTSolicitudes_Items
			Description: Items
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
	[XmlRoot(ElementName="SDTSolicitudes.Items")]
	[XmlType(TypeName="SDTSolicitudes.Items" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTSolicitudes_Items : GxUserType
	{
		public SdtSDTSolicitudes_Items( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTSolicitudes_Items_Rubrosimagen = "";
			gxTv_SdtSDTSolicitudes_Items_Rubrosimagen_gxi = "";

			gxTv_SdtSDTSolicitudes_Items_Medidasnombre = "";

			gxTv_SdtSDTSolicitudes_Items_Rubrosnombre = "";

			gxTv_SdtSDTSolicitudes_Items_Inventarionombre = "";

			gxTv_SdtSDTSolicitudes_Items_Inventarioimagen = "";
			gxTv_SdtSDTSolicitudes_Items_Inventarioimagen_gxi = "";

			gxTv_SdtSDTSolicitudes_Items_Textostitulo = "";

			gxTv_SdtSDTSolicitudes_Items_Textosdescripcion = "";

			gxTv_SdtSDTSolicitudes_Items_Inventariotextosdescripcion = "";

			gxTv_SdtSDTSolicitudes_Items_Inventariotextostitulo = "";

			gxTv_SdtSDTSolicitudes_Items_Monedaisosimbolo = "";

		}

		public SdtSDTSolicitudes_Items(IGxContext context)
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
			AddObjectProperty("SolicitudesItemsID", gxTpr_Solicitudesitemsid, false);


			AddObjectProperty("RubrosId", gxTpr_Rubrosid, false);


			AddObjectProperty("RubrosImagen", gxTpr_Rubrosimagen, false);
			AddObjectProperty("RubrosImagen_GXI", gxTpr_Rubrosimagen_gxi, false);



			AddObjectProperty("MedidasNombre", gxTpr_Medidasnombre, false);


			AddObjectProperty("RubrosNombre", gxTpr_Rubrosnombre, false);


			AddObjectProperty("MedidasID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Medidasid, 18, 0)), false);


			AddObjectProperty("InventarioId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Inventarioid, 18, 0)), false);


			AddObjectProperty("InventarioNombre", gxTpr_Inventarionombre, false);


			AddObjectProperty("InventarioImagen", gxTpr_Inventarioimagen, false);
			AddObjectProperty("InventarioImagen_GXI", gxTpr_Inventarioimagen_gxi, false);



			AddObjectProperty("InventarioPrecioFinal", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Inventariopreciofinal, 18, 2)), false);


			AddObjectProperty("SolicitudesItemsCantidad", gxTpr_Solicitudesitemscantidad, false);


			AddObjectProperty("SolicitudesItemsPrecioInstalacion", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Solicitudesitemsprecioinstalacion, 18, 2)), false);


			AddObjectProperty("TextosId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Textosid, 18, 0)), false);


			AddObjectProperty("TextosTitulo", gxTpr_Textostitulo, false);


			AddObjectProperty("TextosDescripcion", gxTpr_Textosdescripcion, false);


			AddObjectProperty("InventarioTextosId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Inventariotextosid, 18, 0)), false);


			AddObjectProperty("InventarioTextosDescripcion", gxTpr_Inventariotextosdescripcion, false);


			AddObjectProperty("InventarioTextosTitulo", gxTpr_Inventariotextostitulo, false);


			AddObjectProperty("MonedaId", gxTpr_Monedaid, false);


			AddObjectProperty("MonedaISOSimbolo", gxTpr_Monedaisosimbolo, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SolicitudesItemsID")]
		[XmlElement(ElementName="SolicitudesItemsID")]
		public short gxTpr_Solicitudesitemsid
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Solicitudesitemsid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Solicitudesitemsid = value;
				SetDirty("Solicitudesitemsid");
			}
		}




		[SoapElement(ElementName="RubrosId")]
		[XmlElement(ElementName="RubrosId")]
		public short gxTpr_Rubrosid
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Rubrosid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Rubrosid = value;
				SetDirty("Rubrosid");
			}
		}




		[SoapElement(ElementName="RubrosImagen")]
		[XmlElement(ElementName="RubrosImagen")]
		[GxUpload()]

		public string gxTpr_Rubrosimagen
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Rubrosimagen; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Rubrosimagen = value;
				SetDirty("Rubrosimagen");
			}
		}


		[SoapElement(ElementName="RubrosImagen_GXI" )]
		[XmlElement(ElementName="RubrosImagen_GXI" )]
		public string gxTpr_Rubrosimagen_gxi
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Rubrosimagen_gxi ;
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Rubrosimagen_gxi = value;
				SetDirty("Rubrosimagen_gxi");
			}
		}

		[SoapElement(ElementName="MedidasNombre")]
		[XmlElement(ElementName="MedidasNombre")]
		public string gxTpr_Medidasnombre
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Medidasnombre; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Medidasnombre = value;
				SetDirty("Medidasnombre");
			}
		}




		[SoapElement(ElementName="RubrosNombre")]
		[XmlElement(ElementName="RubrosNombre")]
		public string gxTpr_Rubrosnombre
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Rubrosnombre; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Rubrosnombre = value;
				SetDirty("Rubrosnombre");
			}
		}




		[SoapElement(ElementName="MedidasID")]
		[XmlElement(ElementName="MedidasID")]
		public long gxTpr_Medidasid
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Medidasid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Medidasid = value;
				SetDirty("Medidasid");
			}
		}




		[SoapElement(ElementName="InventarioId")]
		[XmlElement(ElementName="InventarioId")]
		public long gxTpr_Inventarioid
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Inventarioid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Inventarioid = value;
				SetDirty("Inventarioid");
			}
		}




		[SoapElement(ElementName="InventarioNombre")]
		[XmlElement(ElementName="InventarioNombre")]
		public string gxTpr_Inventarionombre
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Inventarionombre; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Inventarionombre = value;
				SetDirty("Inventarionombre");
			}
		}




		[SoapElement(ElementName="InventarioImagen")]
		[XmlElement(ElementName="InventarioImagen")]
		[GxUpload()]

		public string gxTpr_Inventarioimagen
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Inventarioimagen; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Inventarioimagen = value;
				SetDirty("Inventarioimagen");
			}
		}


		[SoapElement(ElementName="InventarioImagen_GXI" )]
		[XmlElement(ElementName="InventarioImagen_GXI" )]
		public string gxTpr_Inventarioimagen_gxi
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Inventarioimagen_gxi ;
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Inventarioimagen_gxi = value;
				SetDirty("Inventarioimagen_gxi");
			}
		}
		[SoapElement(ElementName="InventarioPrecioFinal")]
		[XmlElement(ElementName="InventarioPrecioFinal")]
		public string gxTpr_Inventariopreciofinal_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTSolicitudes_Items_Inventariopreciofinal, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Inventariopreciofinal = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Inventariopreciofinal
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Inventariopreciofinal; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Inventariopreciofinal = value;
				SetDirty("Inventariopreciofinal");
			}
		}




		[SoapElement(ElementName="SolicitudesItemsCantidad")]
		[XmlElement(ElementName="SolicitudesItemsCantidad")]
		public short gxTpr_Solicitudesitemscantidad
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Solicitudesitemscantidad; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Solicitudesitemscantidad = value;
				SetDirty("Solicitudesitemscantidad");
			}
		}



		[SoapElement(ElementName="SolicitudesItemsPrecioInstalacion")]
		[XmlElement(ElementName="SolicitudesItemsPrecioInstalacion")]
		public string gxTpr_Solicitudesitemsprecioinstalacion_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTSolicitudes_Items_Solicitudesitemsprecioinstalacion, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Solicitudesitemsprecioinstalacion = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Solicitudesitemsprecioinstalacion
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Solicitudesitemsprecioinstalacion; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Solicitudesitemsprecioinstalacion = value;
				SetDirty("Solicitudesitemsprecioinstalacion");
			}
		}




		[SoapElement(ElementName="TextosId")]
		[XmlElement(ElementName="TextosId")]
		public long gxTpr_Textosid
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Textosid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Textosid = value;
				SetDirty("Textosid");
			}
		}




		[SoapElement(ElementName="TextosTitulo")]
		[XmlElement(ElementName="TextosTitulo")]
		public string gxTpr_Textostitulo
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Textostitulo; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Textostitulo = value;
				SetDirty("Textostitulo");
			}
		}




		[SoapElement(ElementName="TextosDescripcion")]
		[XmlElement(ElementName="TextosDescripcion")]
		public string gxTpr_Textosdescripcion
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Textosdescripcion; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Textosdescripcion = value;
				SetDirty("Textosdescripcion");
			}
		}




		[SoapElement(ElementName="InventarioTextosId")]
		[XmlElement(ElementName="InventarioTextosId")]
		public long gxTpr_Inventariotextosid
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Inventariotextosid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Inventariotextosid = value;
				SetDirty("Inventariotextosid");
			}
		}




		[SoapElement(ElementName="InventarioTextosDescripcion")]
		[XmlElement(ElementName="InventarioTextosDescripcion")]
		public string gxTpr_Inventariotextosdescripcion
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Inventariotextosdescripcion; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Inventariotextosdescripcion = value;
				SetDirty("Inventariotextosdescripcion");
			}
		}




		[SoapElement(ElementName="InventarioTextosTitulo")]
		[XmlElement(ElementName="InventarioTextosTitulo")]
		public string gxTpr_Inventariotextostitulo
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Inventariotextostitulo; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Inventariotextostitulo = value;
				SetDirty("Inventariotextostitulo");
			}
		}




		[SoapElement(ElementName="MonedaId")]
		[XmlElement(ElementName="MonedaId")]
		public short gxTpr_Monedaid
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Monedaid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Monedaid = value;
				SetDirty("Monedaid");
			}
		}




		[SoapElement(ElementName="MonedaISOSimbolo")]
		[XmlElement(ElementName="MonedaISOSimbolo")]
		public string gxTpr_Monedaisosimbolo
		{
			get {
				return gxTv_SdtSDTSolicitudes_Items_Monedaisosimbolo; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_Monedaisosimbolo = value;
				SetDirty("Monedaisosimbolo");
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
			gxTv_SdtSDTSolicitudes_Items_Rubrosimagen = "";gxTv_SdtSDTSolicitudes_Items_Rubrosimagen_gxi = "";
			gxTv_SdtSDTSolicitudes_Items_Medidasnombre = "";
			gxTv_SdtSDTSolicitudes_Items_Rubrosnombre = "";


			gxTv_SdtSDTSolicitudes_Items_Inventarionombre = "";
			gxTv_SdtSDTSolicitudes_Items_Inventarioimagen = "";gxTv_SdtSDTSolicitudes_Items_Inventarioimagen_gxi = "";




			gxTv_SdtSDTSolicitudes_Items_Textostitulo = "";
			gxTv_SdtSDTSolicitudes_Items_Textosdescripcion = "";

			gxTv_SdtSDTSolicitudes_Items_Inventariotextosdescripcion = "";
			gxTv_SdtSDTSolicitudes_Items_Inventariotextostitulo = "";

			gxTv_SdtSDTSolicitudes_Items_Monedaisosimbolo = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTSolicitudes_Items_Solicitudesitemsid;
		 

		protected short gxTv_SdtSDTSolicitudes_Items_Rubrosid;
		 
		protected string gxTv_SdtSDTSolicitudes_Items_Rubrosimagen_gxi;
		protected string gxTv_SdtSDTSolicitudes_Items_Rubrosimagen;
		 

		protected string gxTv_SdtSDTSolicitudes_Items_Medidasnombre;
		 

		protected string gxTv_SdtSDTSolicitudes_Items_Rubrosnombre;
		 

		protected long gxTv_SdtSDTSolicitudes_Items_Medidasid;
		 

		protected long gxTv_SdtSDTSolicitudes_Items_Inventarioid;
		 

		protected string gxTv_SdtSDTSolicitudes_Items_Inventarionombre;
		 
		protected string gxTv_SdtSDTSolicitudes_Items_Inventarioimagen_gxi;
		protected string gxTv_SdtSDTSolicitudes_Items_Inventarioimagen;
		 

		protected decimal gxTv_SdtSDTSolicitudes_Items_Inventariopreciofinal;
		 

		protected short gxTv_SdtSDTSolicitudes_Items_Solicitudesitemscantidad;
		 

		protected decimal gxTv_SdtSDTSolicitudes_Items_Solicitudesitemsprecioinstalacion;
		 

		protected long gxTv_SdtSDTSolicitudes_Items_Textosid;
		 

		protected string gxTv_SdtSDTSolicitudes_Items_Textostitulo;
		 

		protected string gxTv_SdtSDTSolicitudes_Items_Textosdescripcion;
		 

		protected long gxTv_SdtSDTSolicitudes_Items_Inventariotextosid;
		 

		protected string gxTv_SdtSDTSolicitudes_Items_Inventariotextosdescripcion;
		 

		protected string gxTv_SdtSDTSolicitudes_Items_Inventariotextostitulo;
		 

		protected short gxTv_SdtSDTSolicitudes_Items_Monedaid;
		 

		protected string gxTv_SdtSDTSolicitudes_Items_Monedaisosimbolo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTSolicitudes.Items", Namespace="AlmangoX")]
	public class SdtSDTSolicitudes_Items_RESTInterface : GxGenericCollectionItem<SdtSDTSolicitudes_Items>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTSolicitudes_Items_RESTInterface( ) : base()
		{	
		}

		public SdtSDTSolicitudes_Items_RESTInterface( SdtSDTSolicitudes_Items psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="SolicitudesItemsID", Order=0)]
		public short gxTpr_Solicitudesitemsid
		{
			get { 
				return sdt.gxTpr_Solicitudesitemsid;

			}
			set { 
				sdt.gxTpr_Solicitudesitemsid = value;
			}
		}

		[DataMember(Name="RubrosId", Order=1)]
		public short gxTpr_Rubrosid
		{
			get { 
				return sdt.gxTpr_Rubrosid;

			}
			set { 
				sdt.gxTpr_Rubrosid = value;
			}
		}

		[DataMember(Name="RubrosImagen", Order=2)]
		[GxUpload()]
		public  string gxTpr_Rubrosimagen
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Rubrosimagen)) ? PathUtil.RelativePath( sdt.gxTpr_Rubrosimagen) : StringUtil.RTrim( sdt.gxTpr_Rubrosimagen_gxi));

			}
			set { 
				 sdt.gxTpr_Rubrosimagen = value;
			}
		}

		[DataMember(Name="MedidasNombre", Order=3)]
		public  string gxTpr_Medidasnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Medidasnombre);

			}
			set { 
				 sdt.gxTpr_Medidasnombre = value;
			}
		}

		[DataMember(Name="RubrosNombre", Order=4)]
		public  string gxTpr_Rubrosnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Rubrosnombre);

			}
			set { 
				 sdt.gxTpr_Rubrosnombre = value;
			}
		}

		[DataMember(Name="MedidasID", Order=5)]
		public  string gxTpr_Medidasid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Medidasid, 18, 0));

			}
			set { 
				sdt.gxTpr_Medidasid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="InventarioId", Order=6)]
		public  string gxTpr_Inventarioid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Inventarioid, 18, 0));

			}
			set { 
				sdt.gxTpr_Inventarioid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="InventarioNombre", Order=7)]
		public  string gxTpr_Inventarionombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Inventarionombre);

			}
			set { 
				 sdt.gxTpr_Inventarionombre = value;
			}
		}

		[DataMember(Name="InventarioImagen", Order=8)]
		[GxUpload()]
		public  string gxTpr_Inventarioimagen
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Inventarioimagen)) ? PathUtil.RelativePath( sdt.gxTpr_Inventarioimagen) : StringUtil.RTrim( sdt.gxTpr_Inventarioimagen_gxi));

			}
			set { 
				 sdt.gxTpr_Inventarioimagen = value;
			}
		}

		[DataMember(Name="InventarioPrecioFinal", Order=9)]
		public  string gxTpr_Inventariopreciofinal
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Inventariopreciofinal, 18, 2));

			}
			set { 
				sdt.gxTpr_Inventariopreciofinal =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SolicitudesItemsCantidad", Order=10)]
		public short gxTpr_Solicitudesitemscantidad
		{
			get { 
				return sdt.gxTpr_Solicitudesitemscantidad;

			}
			set { 
				sdt.gxTpr_Solicitudesitemscantidad = value;
			}
		}

		[DataMember(Name="SolicitudesItemsPrecioInstalacion", Order=11)]
		public  string gxTpr_Solicitudesitemsprecioinstalacion
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Solicitudesitemsprecioinstalacion, 18, 2));

			}
			set { 
				sdt.gxTpr_Solicitudesitemsprecioinstalacion =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TextosId", Order=12)]
		public  string gxTpr_Textosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Textosid, 18, 0));

			}
			set { 
				sdt.gxTpr_Textosid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TextosTitulo", Order=13)]
		public  string gxTpr_Textostitulo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Textostitulo);

			}
			set { 
				 sdt.gxTpr_Textostitulo = value;
			}
		}

		[DataMember(Name="TextosDescripcion", Order=14)]
		public  string gxTpr_Textosdescripcion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Textosdescripcion);

			}
			set { 
				 sdt.gxTpr_Textosdescripcion = value;
			}
		}

		[DataMember(Name="InventarioTextosId", Order=15)]
		public  string gxTpr_Inventariotextosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Inventariotextosid, 18, 0));

			}
			set { 
				sdt.gxTpr_Inventariotextosid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="InventarioTextosDescripcion", Order=16)]
		public  string gxTpr_Inventariotextosdescripcion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Inventariotextosdescripcion);

			}
			set { 
				 sdt.gxTpr_Inventariotextosdescripcion = value;
			}
		}

		[DataMember(Name="InventarioTextosTitulo", Order=17)]
		public  string gxTpr_Inventariotextostitulo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Inventariotextostitulo);

			}
			set { 
				 sdt.gxTpr_Inventariotextostitulo = value;
			}
		}

		[DataMember(Name="MonedaId", Order=18)]
		public short gxTpr_Monedaid
		{
			get { 
				return sdt.gxTpr_Monedaid;

			}
			set { 
				sdt.gxTpr_Monedaid = value;
			}
		}

		[DataMember(Name="MonedaISOSimbolo", Order=19)]
		public  string gxTpr_Monedaisosimbolo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Monedaisosimbolo);

			}
			set { 
				 sdt.gxTpr_Monedaisosimbolo = value;
			}
		}


		#endregion
		public SdtSDTSolicitudes_Items sdt
		{
			get { 
				return (SdtSDTSolicitudes_Items)Sdt;
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
				sdt = new SdtSDTSolicitudes_Items() ;
			}
		}
	}
	#endregion
}