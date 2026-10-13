/*
				   File: type_SdtSDTOperacionPago
			Description: SDTOperacionPago
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
	[XmlRoot(ElementName="SDTOperacionPago")]
	[XmlType(TypeName="SDTOperacionPago" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTOperacionPago : GxUserType
	{
		public SdtSDTOperacionPago( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTOperacionPago_Comprobantecobro = "";

			gxTv_SdtSDTOperacionPago_Tipoope = "";

		}

		public SdtSDTOperacionPago(IGxContext context)
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
			AddObjectProperty("OrdenNro", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Ordennro, 18, 0)), false);


			AddObjectProperty("TotalCobrado", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Totalcobrado, 18, 2)), false);


			AddObjectProperty("ComprobanteCobro", gxTpr_Comprobantecobro, false);


			AddObjectProperty("TipoOpe", gxTpr_Tipoope, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="OrdenNro")]
		[XmlElement(ElementName="OrdenNro")]
		public long gxTpr_Ordennro
		{
			get {
				return gxTv_SdtSDTOperacionPago_Ordennro; 
			}
			set {
				gxTv_SdtSDTOperacionPago_Ordennro = value;
				SetDirty("Ordennro");
			}
		}



		[SoapElement(ElementName="TotalCobrado")]
		[XmlElement(ElementName="TotalCobrado")]
		public string gxTpr_Totalcobrado_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTOperacionPago_Totalcobrado, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTOperacionPago_Totalcobrado = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Totalcobrado
		{
			get {
				return gxTv_SdtSDTOperacionPago_Totalcobrado; 
			}
			set {
				gxTv_SdtSDTOperacionPago_Totalcobrado = value;
				SetDirty("Totalcobrado");
			}
		}




		[SoapElement(ElementName="ComprobanteCobro")]
		[XmlElement(ElementName="ComprobanteCobro")]
		public string gxTpr_Comprobantecobro
		{
			get {
				return gxTv_SdtSDTOperacionPago_Comprobantecobro; 
			}
			set {
				gxTv_SdtSDTOperacionPago_Comprobantecobro = value;
				SetDirty("Comprobantecobro");
			}
		}




		[SoapElement(ElementName="TipoOpe")]
		[XmlElement(ElementName="TipoOpe")]
		public string gxTpr_Tipoope
		{
			get {
				return gxTv_SdtSDTOperacionPago_Tipoope; 
			}
			set {
				gxTv_SdtSDTOperacionPago_Tipoope = value;
				SetDirty("Tipoope");
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
			gxTv_SdtSDTOperacionPago_Comprobantecobro = "";
			gxTv_SdtSDTOperacionPago_Tipoope = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTOperacionPago_Ordennro;
		 

		protected decimal gxTv_SdtSDTOperacionPago_Totalcobrado;
		 

		protected string gxTv_SdtSDTOperacionPago_Comprobantecobro;
		 

		protected string gxTv_SdtSDTOperacionPago_Tipoope;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTOperacionPago", Namespace="AlmangoX")]
	public class SdtSDTOperacionPago_RESTInterface : GxGenericCollectionItem<SdtSDTOperacionPago>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTOperacionPago_RESTInterface( ) : base()
		{	
		}

		public SdtSDTOperacionPago_RESTInterface( SdtSDTOperacionPago psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="OrdenNro", Order=0)]
		public  string gxTpr_Ordennro
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Ordennro, 18, 0));

			}
			set { 
				sdt.gxTpr_Ordennro = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TotalCobrado", Order=1)]
		public  string gxTpr_Totalcobrado
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totalcobrado, 18, 2));

			}
			set { 
				sdt.gxTpr_Totalcobrado =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ComprobanteCobro", Order=2)]
		public  string gxTpr_Comprobantecobro
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Comprobantecobro);

			}
			set { 
				 sdt.gxTpr_Comprobantecobro = value;
			}
		}

		[DataMember(Name="TipoOpe", Order=3)]
		public  string gxTpr_Tipoope
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tipoope);

			}
			set { 
				 sdt.gxTpr_Tipoope = value;
			}
		}


		#endregion
		public SdtSDTOperacionPago sdt
		{
			get { 
				return (SdtSDTOperacionPago)Sdt;
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
				sdt = new SdtSDTOperacionPago() ;
			}
		}
	}
	#endregion
}