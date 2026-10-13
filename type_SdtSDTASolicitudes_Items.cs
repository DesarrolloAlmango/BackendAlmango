/*
				   File: type_SdtSDTASolicitudes_Items
			Description: Level1
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
	[XmlRoot(ElementName="SDTASolicitudes.Items")]
	[XmlType(TypeName="SDTASolicitudes.Items" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTASolicitudes_Items : GxUserType
	{
		public SdtSDTASolicitudes_Items( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTASolicitudes_Items_Sr = "";

			gxTv_SdtSDTASolicitudes_Items_Comisiontipo = "";


		}

		public SdtSDTASolicitudes_Items(IGxContext context)
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
			AddObjectProperty("RubrosId", gxTpr_Rubrosid, false);


			AddObjectProperty("ProductoID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Productoid, 18, 0)), false);


			AddObjectProperty("DetalleID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Detalleid, 18, 0)), false);


			AddObjectProperty("Cantidad", gxTpr_Cantidad, false);


			AddObjectProperty("Precio", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Precio, 18, 2)), false);


			AddObjectProperty("SR", gxTpr_Sr, false);


			AddObjectProperty("Comision", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Comision, 18, 2)), false);


			AddObjectProperty("ComisionTipo", gxTpr_Comisiontipo, false);


			AddObjectProperty("PrecioFinal", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Preciofinal, 18, 2)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="RubrosId")]
		[XmlElement(ElementName="RubrosId")]
		public short gxTpr_Rubrosid
		{
			get {
				return gxTv_SdtSDTASolicitudes_Items_Rubrosid; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Items_Rubrosid = value;
				SetDirty("Rubrosid");
			}
		}




		[SoapElement(ElementName="ProductoID")]
		[XmlElement(ElementName="ProductoID")]
		public long gxTpr_Productoid
		{
			get {
				return gxTv_SdtSDTASolicitudes_Items_Productoid; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Items_Productoid = value;
				SetDirty("Productoid");
			}
		}




		[SoapElement(ElementName="DetalleID")]
		[XmlElement(ElementName="DetalleID")]
		public long gxTpr_Detalleid
		{
			get {
				return gxTv_SdtSDTASolicitudes_Items_Detalleid; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Items_Detalleid = value;
				SetDirty("Detalleid");
			}
		}




		[SoapElement(ElementName="Cantidad")]
		[XmlElement(ElementName="Cantidad")]
		public long gxTpr_Cantidad
		{
			get {
				return gxTv_SdtSDTASolicitudes_Items_Cantidad; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Items_Cantidad = value;
				SetDirty("Cantidad");
			}
		}



		[SoapElement(ElementName="Precio")]
		[XmlElement(ElementName="Precio")]
		public string gxTpr_Precio_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTASolicitudes_Items_Precio, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTASolicitudes_Items_Precio = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Precio
		{
			get {
				return gxTv_SdtSDTASolicitudes_Items_Precio; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Items_Precio = value;
				SetDirty("Precio");
			}
		}




		[SoapElement(ElementName="SR")]
		[XmlElement(ElementName="SR")]
		public string gxTpr_Sr
		{
			get {
				return gxTv_SdtSDTASolicitudes_Items_Sr; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Items_Sr = value;
				SetDirty("Sr");
			}
		}



		[SoapElement(ElementName="Comision")]
		[XmlElement(ElementName="Comision")]
		public string gxTpr_Comision_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTASolicitudes_Items_Comision, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTASolicitudes_Items_Comision = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Comision
		{
			get {
				return gxTv_SdtSDTASolicitudes_Items_Comision; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Items_Comision = value;
				SetDirty("Comision");
			}
		}




		[SoapElement(ElementName="ComisionTipo")]
		[XmlElement(ElementName="ComisionTipo")]
		public string gxTpr_Comisiontipo
		{
			get {
				return gxTv_SdtSDTASolicitudes_Items_Comisiontipo; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Items_Comisiontipo = value;
				SetDirty("Comisiontipo");
			}
		}



		[SoapElement(ElementName="PrecioFinal")]
		[XmlElement(ElementName="PrecioFinal")]
		public string gxTpr_Preciofinal_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTASolicitudes_Items_Preciofinal, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTASolicitudes_Items_Preciofinal = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Preciofinal
		{
			get {
				return gxTv_SdtSDTASolicitudes_Items_Preciofinal; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Items_Preciofinal = value;
				SetDirty("Preciofinal");
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
			gxTv_SdtSDTASolicitudes_Items_Sr = "";

			gxTv_SdtSDTASolicitudes_Items_Comisiontipo = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTASolicitudes_Items_Rubrosid;
		 

		protected long gxTv_SdtSDTASolicitudes_Items_Productoid;
		 

		protected long gxTv_SdtSDTASolicitudes_Items_Detalleid;
		 

		protected long gxTv_SdtSDTASolicitudes_Items_Cantidad;
		 

		protected decimal gxTv_SdtSDTASolicitudes_Items_Precio;
		 

		protected string gxTv_SdtSDTASolicitudes_Items_Sr;
		 

		protected decimal gxTv_SdtSDTASolicitudes_Items_Comision;
		 

		protected string gxTv_SdtSDTASolicitudes_Items_Comisiontipo;
		 

		protected decimal gxTv_SdtSDTASolicitudes_Items_Preciofinal;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTASolicitudes.Items", Namespace="AlmangoX")]
	public class SdtSDTASolicitudes_Items_RESTInterface : GxGenericCollectionItem<SdtSDTASolicitudes_Items>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTASolicitudes_Items_RESTInterface( ) : base()
		{	
		}

		public SdtSDTASolicitudes_Items_RESTInterface( SdtSDTASolicitudes_Items psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="RubrosId", Order=0)]
		public short gxTpr_Rubrosid
		{
			get { 
				return sdt.gxTpr_Rubrosid;

			}
			set { 
				sdt.gxTpr_Rubrosid = value;
			}
		}

		[DataMember(Name="ProductoID", Order=1)]
		public  string gxTpr_Productoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Productoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Productoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DetalleID", Order=2)]
		public  string gxTpr_Detalleid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Detalleid, 18, 0));

			}
			set { 
				sdt.gxTpr_Detalleid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Cantidad", Order=3)]
		public  string gxTpr_Cantidad
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Cantidad, 10, 0));

			}
			set { 
				sdt.gxTpr_Cantidad = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Precio", Order=4)]
		public  string gxTpr_Precio
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Precio, 18, 2));

			}
			set { 
				sdt.gxTpr_Precio =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SR", Order=5)]
		public  string gxTpr_Sr
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Sr);

			}
			set { 
				 sdt.gxTpr_Sr = value;
			}
		}

		[DataMember(Name="Comision", Order=6)]
		public  string gxTpr_Comision
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Comision, 18, 2));

			}
			set { 
				sdt.gxTpr_Comision =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ComisionTipo", Order=7)]
		public  string gxTpr_Comisiontipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Comisiontipo);

			}
			set { 
				 sdt.gxTpr_Comisiontipo = value;
			}
		}

		[DataMember(Name="PrecioFinal", Order=8)]
		public  string gxTpr_Preciofinal
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Preciofinal, 18, 2));

			}
			set { 
				sdt.gxTpr_Preciofinal =  NumberUtil.Val( value, ".");
			}
		}


		#endregion
		public SdtSDTASolicitudes_Items sdt
		{
			get { 
				return (SdtSDTASolicitudes_Items)Sdt;
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
				sdt = new SdtSDTASolicitudes_Items() ;
			}
		}
	}
	#endregion
}