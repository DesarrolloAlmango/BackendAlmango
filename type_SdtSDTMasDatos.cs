/*
				   File: type_SdtSDTMasDatos
			Description: SDTMasDatos
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
	[XmlRoot(ElementName="SDTMasDatos")]
	[XmlType(TypeName="SDTMasDatos" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTMasDatos : GxUserType
	{
		public SdtSDTMasDatos( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTMasDatos(IGxContext context)
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
			if (gxTv_SdtSDTMasDatos_Mododepago != null)
			{
				AddObjectProperty("ModoDePago", gxTv_SdtSDTMasDatos_Mododepago, false);
			}
			if (gxTv_SdtSDTMasDatos_Turnosinstalacion != null)
			{
				AddObjectProperty("TurnosInstalacion", gxTv_SdtSDTMasDatos_Turnosinstalacion, false);
			}

			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Instalardespuesde)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Instalardespuesde)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Instalardespuesde)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("InstalarDespuesDe", sDateCnv, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ModoDePago" )]
		[XmlArray(ElementName="ModoDePago"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<SdtSDTMasDatos_Item> gxTpr_Mododepago
		{
			get {
				if ( gxTv_SdtSDTMasDatos_Mododepago == null )
				{
					gxTv_SdtSDTMasDatos_Mododepago = new GXBaseCollection<SdtSDTMasDatos_Item>( context, "SDTMasDatos.Item", "");
				}
				SetDirty("Mododepago");
				return gxTv_SdtSDTMasDatos_Mododepago;
			}
			set {
				gxTv_SdtSDTMasDatos_Mododepago_N = false;
				gxTv_SdtSDTMasDatos_Mododepago = value;
				SetDirty("Mododepago");
			}
		}

		public void gxTv_SdtSDTMasDatos_Mododepago_SetNull()
		{
			gxTv_SdtSDTMasDatos_Mododepago_N = true;
			gxTv_SdtSDTMasDatos_Mododepago = null;
		}

		public bool gxTv_SdtSDTMasDatos_Mododepago_IsNull()
		{
			return gxTv_SdtSDTMasDatos_Mododepago == null;
		}
		public bool ShouldSerializegxTpr_Mododepago_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTMasDatos_Mododepago != null && gxTv_SdtSDTMasDatos_Mododepago.Count > 0;

		}



		[SoapElement(ElementName="TurnosInstalacion" )]
		[XmlArray(ElementName="TurnosInstalacion"  )]
		[XmlArrayItemAttribute(ElementName="ItemTurno" , IsNullable=false )]
		public GXBaseCollection<SdtSDTMasDatos_ItemTurno> gxTpr_Turnosinstalacion
		{
			get {
				if ( gxTv_SdtSDTMasDatos_Turnosinstalacion == null )
				{
					gxTv_SdtSDTMasDatos_Turnosinstalacion = new GXBaseCollection<SdtSDTMasDatos_ItemTurno>( context, "SDTMasDatos.ItemTurno", "");
				}
				SetDirty("Turnosinstalacion");
				return gxTv_SdtSDTMasDatos_Turnosinstalacion;
			}
			set {
				gxTv_SdtSDTMasDatos_Turnosinstalacion_N = false;
				gxTv_SdtSDTMasDatos_Turnosinstalacion = value;
				SetDirty("Turnosinstalacion");
			}
		}

		public void gxTv_SdtSDTMasDatos_Turnosinstalacion_SetNull()
		{
			gxTv_SdtSDTMasDatos_Turnosinstalacion_N = true;
			gxTv_SdtSDTMasDatos_Turnosinstalacion = null;
		}

		public bool gxTv_SdtSDTMasDatos_Turnosinstalacion_IsNull()
		{
			return gxTv_SdtSDTMasDatos_Turnosinstalacion == null;
		}
		public bool ShouldSerializegxTpr_Turnosinstalacion_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTMasDatos_Turnosinstalacion != null && gxTv_SdtSDTMasDatos_Turnosinstalacion.Count > 0;

		}


		[SoapElement(ElementName="InstalarDespuesDe")]
		[XmlElement(ElementName="InstalarDespuesDe" , IsNullable=true)]
		public string gxTpr_Instalardespuesde_Nullable
		{
			get {
				if ( gxTv_SdtSDTMasDatos_Instalardespuesde == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTMasDatos_Instalardespuesde).value ;
			}
			set {
				gxTv_SdtSDTMasDatos_Instalardespuesde = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Instalardespuesde
		{
			get {
				return gxTv_SdtSDTMasDatos_Instalardespuesde; 
			}
			set {
				gxTv_SdtSDTMasDatos_Instalardespuesde = value;
				SetDirty("Instalardespuesde");
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
			gxTv_SdtSDTMasDatos_Mododepago_N = true;


			gxTv_SdtSDTMasDatos_Turnosinstalacion_N = true;


			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected bool gxTv_SdtSDTMasDatos_Mododepago_N;
		protected GXBaseCollection<SdtSDTMasDatos_Item> gxTv_SdtSDTMasDatos_Mododepago = null; 

		protected bool gxTv_SdtSDTMasDatos_Turnosinstalacion_N;
		protected GXBaseCollection<SdtSDTMasDatos_ItemTurno> gxTv_SdtSDTMasDatos_Turnosinstalacion = null; 


		protected DateTime gxTv_SdtSDTMasDatos_Instalardespuesde;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTMasDatos", Namespace="AlmangoX")]
	public class SdtSDTMasDatos_RESTInterface : GxGenericCollectionItem<SdtSDTMasDatos>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTMasDatos_RESTInterface( ) : base()
		{	
		}

		public SdtSDTMasDatos_RESTInterface( SdtSDTMasDatos psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ModoDePago", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTMasDatos_Item_RESTInterface> gxTpr_Mododepago
		{
			get {
				if (sdt.ShouldSerializegxTpr_Mododepago_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTMasDatos_Item_RESTInterface>(sdt.gxTpr_Mododepago);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Mododepago);
			}
		}

		[DataMember(Name="TurnosInstalacion", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTMasDatos_ItemTurno_RESTInterface> gxTpr_Turnosinstalacion
		{
			get {
				if (sdt.ShouldSerializegxTpr_Turnosinstalacion_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTMasDatos_ItemTurno_RESTInterface>(sdt.gxTpr_Turnosinstalacion);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Turnosinstalacion);
			}
		}

		[DataMember(Name="InstalarDespuesDe", Order=2)]
		public  string gxTpr_Instalardespuesde
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Instalardespuesde);

			}
			set { 
				sdt.gxTpr_Instalardespuesde = DateTimeUtil.CToD2(value);
			}
		}


		#endregion
		public SdtSDTMasDatos sdt
		{
			get { 
				return (SdtSDTMasDatos)Sdt;
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
				sdt = new SdtSDTMasDatos() ;
			}
		}
	}
	#endregion
}