/*
				   File: type_SdtSDTComercioDatos_ComisionItem
			Description: Comision
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
	[XmlRoot(ElementName="SDTComercioDatos.ComisionItem")]
	[XmlType(TypeName="SDTComercioDatos.ComisionItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTComercioDatos_ComisionItem : GxUserType
	{
		public SdtSDTComercioDatos_ComisionItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTComercioDatos_ComisionItem_Rubrosimagen = "";
			gxTv_SdtSDTComercioDatos_ComisionItem_Rubrosimagen_gxi = "";

			gxTv_SdtSDTComercioDatos_ComisionItem_Inventarionombre = "";

			gxTv_SdtSDTComercioDatos_ComisionItem_Estadostipo = "";

			gxTv_SdtSDTComercioDatos_ComisionItem_Estadosgenericosnombre = "";

			gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomisiontipo = "";

			gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomisionaccion = "";

		}

		public SdtSDTComercioDatos_ComisionItem(IGxContext context)
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
			AddObjectProperty("ProveedorComisionID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Proveedorcomisionid, 18, 0)), false);


			AddObjectProperty("RubrosId", gxTpr_Rubrosid, false);


			AddObjectProperty("RubrosImagen", gxTpr_Rubrosimagen, false);
			AddObjectProperty("RubrosImagen_GXI", gxTpr_Rubrosimagen_gxi, false);



			AddObjectProperty("MedidasID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Medidasid, 18, 0)), false);


			AddObjectProperty("InventarioId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Inventarioid, 18, 0)), false);


			AddObjectProperty("InventarioNombre", gxTpr_Inventarionombre, false);


			AddObjectProperty("MonedaId", gxTpr_Monedaid, false);


			AddObjectProperty("EstadosTipo", gxTpr_Estadostipo, false);


			AddObjectProperty("EstadosGenericosId", gxTpr_Estadosgenericosid, false);


			AddObjectProperty("EstadosGenericosNombre", gxTpr_Estadosgenericosnombre, false);


			AddObjectProperty("InventarioPrecioFinal", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Inventariopreciofinal, 18, 2)), false);


			AddObjectProperty("ProveedorComisionTipo", gxTpr_Proveedorcomisiontipo, false);


			AddObjectProperty("ProveedorComision", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Proveedorcomision, 18, 2)), false);


			AddObjectProperty("ProveedorComisionAccion", gxTpr_Proveedorcomisionaccion, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProveedorComisionID")]
		[XmlElement(ElementName="ProveedorComisionID")]
		public long gxTpr_Proveedorcomisionid
		{
			get {
				return gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomisionid; 
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomisionid = value;
				SetDirty("Proveedorcomisionid");
			}
		}




		[SoapElement(ElementName="RubrosId")]
		[XmlElement(ElementName="RubrosId")]
		public short gxTpr_Rubrosid
		{
			get {
				return gxTv_SdtSDTComercioDatos_ComisionItem_Rubrosid; 
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Rubrosid = value;
				SetDirty("Rubrosid");
			}
		}




		[SoapElement(ElementName="RubrosImagen")]
		[XmlElement(ElementName="RubrosImagen")]
		[GxUpload()]

		public string gxTpr_Rubrosimagen
		{
			get {
				return gxTv_SdtSDTComercioDatos_ComisionItem_Rubrosimagen; 
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Rubrosimagen = value;
				SetDirty("Rubrosimagen");
			}
		}


		[SoapElement(ElementName="RubrosImagen_GXI" )]
		[XmlElement(ElementName="RubrosImagen_GXI" )]
		public string gxTpr_Rubrosimagen_gxi
		{
			get {
				return gxTv_SdtSDTComercioDatos_ComisionItem_Rubrosimagen_gxi ;
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Rubrosimagen_gxi = value;
				SetDirty("Rubrosimagen_gxi");
			}
		}

		[SoapElement(ElementName="MedidasID")]
		[XmlElement(ElementName="MedidasID")]
		public long gxTpr_Medidasid
		{
			get {
				return gxTv_SdtSDTComercioDatos_ComisionItem_Medidasid; 
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Medidasid = value;
				SetDirty("Medidasid");
			}
		}




		[SoapElement(ElementName="InventarioId")]
		[XmlElement(ElementName="InventarioId")]
		public long gxTpr_Inventarioid
		{
			get {
				return gxTv_SdtSDTComercioDatos_ComisionItem_Inventarioid; 
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Inventarioid = value;
				SetDirty("Inventarioid");
			}
		}




		[SoapElement(ElementName="InventarioNombre")]
		[XmlElement(ElementName="InventarioNombre")]
		public string gxTpr_Inventarionombre
		{
			get {
				return gxTv_SdtSDTComercioDatos_ComisionItem_Inventarionombre; 
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Inventarionombre = value;
				SetDirty("Inventarionombre");
			}
		}




		[SoapElement(ElementName="MonedaId")]
		[XmlElement(ElementName="MonedaId")]
		public short gxTpr_Monedaid
		{
			get {
				return gxTv_SdtSDTComercioDatos_ComisionItem_Monedaid; 
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Monedaid = value;
				SetDirty("Monedaid");
			}
		}




		[SoapElement(ElementName="EstadosTipo")]
		[XmlElement(ElementName="EstadosTipo")]
		public string gxTpr_Estadostipo
		{
			get {
				return gxTv_SdtSDTComercioDatos_ComisionItem_Estadostipo; 
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Estadostipo = value;
				SetDirty("Estadostipo");
			}
		}




		[SoapElement(ElementName="EstadosGenericosId")]
		[XmlElement(ElementName="EstadosGenericosId")]
		public int gxTpr_Estadosgenericosid
		{
			get {
				return gxTv_SdtSDTComercioDatos_ComisionItem_Estadosgenericosid; 
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Estadosgenericosid = value;
				SetDirty("Estadosgenericosid");
			}
		}




		[SoapElement(ElementName="EstadosGenericosNombre")]
		[XmlElement(ElementName="EstadosGenericosNombre")]
		public string gxTpr_Estadosgenericosnombre
		{
			get {
				return gxTv_SdtSDTComercioDatos_ComisionItem_Estadosgenericosnombre; 
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Estadosgenericosnombre = value;
				SetDirty("Estadosgenericosnombre");
			}
		}



		[SoapElement(ElementName="InventarioPrecioFinal")]
		[XmlElement(ElementName="InventarioPrecioFinal")]
		public string gxTpr_Inventariopreciofinal_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTComercioDatos_ComisionItem_Inventariopreciofinal, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Inventariopreciofinal = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Inventariopreciofinal
		{
			get {
				return gxTv_SdtSDTComercioDatos_ComisionItem_Inventariopreciofinal; 
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Inventariopreciofinal = value;
				SetDirty("Inventariopreciofinal");
			}
		}




		[SoapElement(ElementName="ProveedorComisionTipo")]
		[XmlElement(ElementName="ProveedorComisionTipo")]
		public string gxTpr_Proveedorcomisiontipo
		{
			get {
				return gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomisiontipo; 
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomisiontipo = value;
				SetDirty("Proveedorcomisiontipo");
			}
		}



		[SoapElement(ElementName="ProveedorComision")]
		[XmlElement(ElementName="ProveedorComision")]
		public string gxTpr_Proveedorcomision_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomision, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomision = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Proveedorcomision
		{
			get {
				return gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomision; 
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomision = value;
				SetDirty("Proveedorcomision");
			}
		}




		[SoapElement(ElementName="ProveedorComisionAccion")]
		[XmlElement(ElementName="ProveedorComisionAccion")]
		public string gxTpr_Proveedorcomisionaccion
		{
			get {
				return gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomisionaccion; 
			}
			set {
				gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomisionaccion = value;
				SetDirty("Proveedorcomisionaccion");
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
			gxTv_SdtSDTComercioDatos_ComisionItem_Rubrosimagen = "";gxTv_SdtSDTComercioDatos_ComisionItem_Rubrosimagen_gxi = "";


			gxTv_SdtSDTComercioDatos_ComisionItem_Inventarionombre = "";

			gxTv_SdtSDTComercioDatos_ComisionItem_Estadostipo = "";

			gxTv_SdtSDTComercioDatos_ComisionItem_Estadosgenericosnombre = "";

			gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomisiontipo = "";

			gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomisionaccion = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomisionid;
		 

		protected short gxTv_SdtSDTComercioDatos_ComisionItem_Rubrosid;
		 
		protected string gxTv_SdtSDTComercioDatos_ComisionItem_Rubrosimagen_gxi;
		protected string gxTv_SdtSDTComercioDatos_ComisionItem_Rubrosimagen;
		 

		protected long gxTv_SdtSDTComercioDatos_ComisionItem_Medidasid;
		 

		protected long gxTv_SdtSDTComercioDatos_ComisionItem_Inventarioid;
		 

		protected string gxTv_SdtSDTComercioDatos_ComisionItem_Inventarionombre;
		 

		protected short gxTv_SdtSDTComercioDatos_ComisionItem_Monedaid;
		 

		protected string gxTv_SdtSDTComercioDatos_ComisionItem_Estadostipo;
		 

		protected int gxTv_SdtSDTComercioDatos_ComisionItem_Estadosgenericosid;
		 

		protected string gxTv_SdtSDTComercioDatos_ComisionItem_Estadosgenericosnombre;
		 

		protected decimal gxTv_SdtSDTComercioDatos_ComisionItem_Inventariopreciofinal;
		 

		protected string gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomisiontipo;
		 

		protected decimal gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomision;
		 

		protected string gxTv_SdtSDTComercioDatos_ComisionItem_Proveedorcomisionaccion;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTComercioDatos.ComisionItem", Namespace="AlmangoX")]
	public class SdtSDTComercioDatos_ComisionItem_RESTInterface : GxGenericCollectionItem<SdtSDTComercioDatos_ComisionItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTComercioDatos_ComisionItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTComercioDatos_ComisionItem_RESTInterface( SdtSDTComercioDatos_ComisionItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProveedorComisionID", Order=0)]
		public  string gxTpr_Proveedorcomisionid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Proveedorcomisionid, 18, 0));

			}
			set { 
				sdt.gxTpr_Proveedorcomisionid = (long) NumberUtil.Val( value, ".");
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

		[DataMember(Name="MedidasID", Order=3)]
		public  string gxTpr_Medidasid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Medidasid, 18, 0));

			}
			set { 
				sdt.gxTpr_Medidasid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="InventarioId", Order=4)]
		public  string gxTpr_Inventarioid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Inventarioid, 18, 0));

			}
			set { 
				sdt.gxTpr_Inventarioid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="InventarioNombre", Order=5)]
		public  string gxTpr_Inventarionombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Inventarionombre);

			}
			set { 
				 sdt.gxTpr_Inventarionombre = value;
			}
		}

		[DataMember(Name="MonedaId", Order=6)]
		public short gxTpr_Monedaid
		{
			get { 
				return sdt.gxTpr_Monedaid;

			}
			set { 
				sdt.gxTpr_Monedaid = value;
			}
		}

		[DataMember(Name="EstadosTipo", Order=7)]
		public  string gxTpr_Estadostipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Estadostipo);

			}
			set { 
				 sdt.gxTpr_Estadostipo = value;
			}
		}

		[DataMember(Name="EstadosGenericosId", Order=8)]
		public int gxTpr_Estadosgenericosid
		{
			get { 
				return sdt.gxTpr_Estadosgenericosid;

			}
			set { 
				sdt.gxTpr_Estadosgenericosid = value;
			}
		}

		[DataMember(Name="EstadosGenericosNombre", Order=9)]
		public  string gxTpr_Estadosgenericosnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Estadosgenericosnombre);

			}
			set { 
				 sdt.gxTpr_Estadosgenericosnombre = value;
			}
		}

		[DataMember(Name="InventarioPrecioFinal", Order=10)]
		public  string gxTpr_Inventariopreciofinal
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Inventariopreciofinal, 18, 2));

			}
			set { 
				sdt.gxTpr_Inventariopreciofinal =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProveedorComisionTipo", Order=11)]
		public  string gxTpr_Proveedorcomisiontipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedorcomisiontipo);

			}
			set { 
				 sdt.gxTpr_Proveedorcomisiontipo = value;
			}
		}

		[DataMember(Name="ProveedorComision", Order=12)]
		public  string gxTpr_Proveedorcomision
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Proveedorcomision, 18, 2));

			}
			set { 
				sdt.gxTpr_Proveedorcomision =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProveedorComisionAccion", Order=13)]
		public  string gxTpr_Proveedorcomisionaccion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedorcomisionaccion);

			}
			set { 
				 sdt.gxTpr_Proveedorcomisionaccion = value;
			}
		}


		#endregion
		public SdtSDTComercioDatos_ComisionItem sdt
		{
			get { 
				return (SdtSDTComercioDatos_ComisionItem)Sdt;
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
				sdt = new SdtSDTComercioDatos_ComisionItem() ;
			}
		}
	}
	#endregion
}