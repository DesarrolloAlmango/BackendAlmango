/*
				   File: type_SdtSDT_PresupuestoRespuesta
			Description: SDT_PresupuestoRespuesta
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
using GeneXus.Programs.apis;
using GeneXus.Programs.apis.comerciosapi;

namespace GeneXus.Programs.apis.comerciosapi.v1
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="SDT_PresupuestoRespuesta")]
	[XmlType(TypeName="SDT_PresupuestoRespuesta" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDT_PresupuestoRespuesta : GxUserType
	{
		public SdtSDT_PresupuestoRespuesta( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_PresupuestoRespuesta_Moneda = "";

		}

		public SdtSDT_PresupuestoRespuesta(IGxContext context)
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
			AddObjectProperty("SolicitudId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Solicitudid, 18, 0)), false);


			AddObjectProperty("CostoPresupuesto", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Costopresupuesto, 18, 2)), false);


			AddObjectProperty("Moneda", gxTpr_Moneda, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SolicitudId")]
		[XmlElement(ElementName="SolicitudId")]
		public long gxTpr_Solicitudid
		{
			get {
				return gxTv_SdtSDT_PresupuestoRespuesta_Solicitudid; 
			}
			set {
				gxTv_SdtSDT_PresupuestoRespuesta_Solicitudid = value;
				SetDirty("Solicitudid");
			}
		}



		[SoapElement(ElementName="CostoPresupuesto")]
		[XmlElement(ElementName="CostoPresupuesto")]
		public string gxTpr_Costopresupuesto_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_PresupuestoRespuesta_Costopresupuesto, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_PresupuestoRespuesta_Costopresupuesto = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Costopresupuesto
		{
			get {
				return gxTv_SdtSDT_PresupuestoRespuesta_Costopresupuesto; 
			}
			set {
				gxTv_SdtSDT_PresupuestoRespuesta_Costopresupuesto = value;
				SetDirty("Costopresupuesto");
			}
		}




		[SoapElement(ElementName="Moneda")]
		[XmlElement(ElementName="Moneda")]
		public string gxTpr_Moneda
		{
			get {
				return gxTv_SdtSDT_PresupuestoRespuesta_Moneda; 
			}
			set {
				gxTv_SdtSDT_PresupuestoRespuesta_Moneda = value;
				SetDirty("Moneda");
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
			gxTv_SdtSDT_PresupuestoRespuesta_Moneda = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDT_PresupuestoRespuesta_Solicitudid;
		 

		protected decimal gxTv_SdtSDT_PresupuestoRespuesta_Costopresupuesto;
		 

		protected string gxTv_SdtSDT_PresupuestoRespuesta_Moneda;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_PresupuestoRespuesta", Namespace="AlmangoX")]
	public class SdtSDT_PresupuestoRespuesta_RESTInterface : GxGenericCollectionItem<SdtSDT_PresupuestoRespuesta>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_PresupuestoRespuesta_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_PresupuestoRespuesta_RESTInterface( SdtSDT_PresupuestoRespuesta psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="SolicitudId", Order=0)]
		public  string gxTpr_Solicitudid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Solicitudid, 18, 0));

			}
			set { 
				sdt.gxTpr_Solicitudid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="CostoPresupuesto", Order=1)]
		public  string gxTpr_Costopresupuesto
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Costopresupuesto, 18, 2));

			}
			set { 
				sdt.gxTpr_Costopresupuesto =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Moneda", Order=2)]
		public  string gxTpr_Moneda
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Moneda);

			}
			set { 
				 sdt.gxTpr_Moneda = value;
			}
		}


		#endregion
		public SdtSDT_PresupuestoRespuesta sdt
		{
			get { 
				return (SdtSDT_PresupuestoRespuesta)Sdt;
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
				sdt = new SdtSDT_PresupuestoRespuesta() ;
			}
		}
	}
	#endregion
}