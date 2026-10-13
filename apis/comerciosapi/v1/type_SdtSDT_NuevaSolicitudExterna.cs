/*
				   File: type_SdtSDT_NuevaSolicitudExterna
			Description: SDT_NuevaSolicitudExterna
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
	[XmlRoot(ElementName="SDT_NuevaSolicitudExterna")]
	[XmlType(TypeName="SDT_NuevaSolicitudExterna" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDT_NuevaSolicitudExterna : GxUserType
	{
		public SdtSDT_NuevaSolicitudExterna( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_NuevaSolicitudExterna_Comercioticketid = "";

			gxTv_SdtSDT_NuevaSolicitudExterna_Notasadicionales = "";

			gxTv_SdtSDT_NuevaSolicitudExterna_Moneda = "";

		}

		public SdtSDT_NuevaSolicitudExterna(IGxContext context)
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
			AddObjectProperty("ComercioTicketId", gxTpr_Comercioticketid, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Fechacompra)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Fechacompra)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Fechacompra)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("FechaCompra", sDateCnv, false);



			AddObjectProperty("SucursalId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Sucursalid, 18, 0)), false);


			AddObjectProperty("NotasAdicionales", gxTpr_Notasadicionales, false);


			AddObjectProperty("Moneda", gxTpr_Moneda, false);

			if (gxTv_SdtSDT_NuevaSolicitudExterna_Cliente != null)
			{
				AddObjectProperty("Cliente", gxTv_SdtSDT_NuevaSolicitudExterna_Cliente, false);
			}
			if (gxTv_SdtSDT_NuevaSolicitudExterna_Servicios != null)
			{
				AddObjectProperty("Servicios", gxTv_SdtSDT_NuevaSolicitudExterna_Servicios, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ComercioTicketId")]
		[XmlElement(ElementName="ComercioTicketId")]
		public string gxTpr_Comercioticketid
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Comercioticketid; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Comercioticketid = value;
				SetDirty("Comercioticketid");
			}
		}



		[SoapElement(ElementName="FechaCompra")]
		[XmlElement(ElementName="FechaCompra" , IsNullable=true)]
		public string gxTpr_Fechacompra_Nullable
		{
			get {
				if ( gxTv_SdtSDT_NuevaSolicitudExterna_Fechacompra == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDT_NuevaSolicitudExterna_Fechacompra).value ;
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Fechacompra = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Fechacompra
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Fechacompra; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Fechacompra = value;
				SetDirty("Fechacompra");
			}
		}



		[SoapElement(ElementName="SucursalId")]
		[XmlElement(ElementName="SucursalId")]
		public long gxTpr_Sucursalid
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Sucursalid; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Sucursalid = value;
				SetDirty("Sucursalid");
			}
		}




		[SoapElement(ElementName="NotasAdicionales")]
		[XmlElement(ElementName="NotasAdicionales")]
		public string gxTpr_Notasadicionales
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Notasadicionales; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Notasadicionales = value;
				SetDirty("Notasadicionales");
			}
		}




		[SoapElement(ElementName="Moneda")]
		[XmlElement(ElementName="Moneda")]
		public string gxTpr_Moneda
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Moneda; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Moneda = value;
				SetDirty("Moneda");
			}
		}



		[SoapElement(ElementName="Cliente" )]
		[XmlElement(ElementName="Cliente" )]
		public SdtSDT_NuevaSolicitudExterna_Cliente gxTpr_Cliente
		{
			get {
				if ( gxTv_SdtSDT_NuevaSolicitudExterna_Cliente == null )
				{
					gxTv_SdtSDT_NuevaSolicitudExterna_Cliente = new SdtSDT_NuevaSolicitudExterna_Cliente(context);
				}
				gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_N = false;
				SetDirty("Cliente");
				return gxTv_SdtSDT_NuevaSolicitudExterna_Cliente;
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_N = false;
				gxTv_SdtSDT_NuevaSolicitudExterna_Cliente = value;
				SetDirty("Cliente");
			}

		}

		public void gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_SetNull()
		{
			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_N = true;
			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente = null;
		}

		public bool gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_IsNull()
		{
			return gxTv_SdtSDT_NuevaSolicitudExterna_Cliente == null;
		}
		public bool ShouldSerializegxTpr_Cliente_Json()
		{
				return (gxTv_SdtSDT_NuevaSolicitudExterna_Cliente != null && gxTv_SdtSDT_NuevaSolicitudExterna_Cliente.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="Servicios" )]
		[XmlArray(ElementName="Servicios"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_NuevaSolicitudExterna_Item> gxTpr_Servicios
		{
			get {
				if ( gxTv_SdtSDT_NuevaSolicitudExterna_Servicios == null )
				{
					gxTv_SdtSDT_NuevaSolicitudExterna_Servicios = new GXBaseCollection<SdtSDT_NuevaSolicitudExterna_Item>( context, "SDT_NuevaSolicitudExterna.Item", "");
				}
				SetDirty("Servicios");
				return gxTv_SdtSDT_NuevaSolicitudExterna_Servicios;
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Servicios_N = false;
				gxTv_SdtSDT_NuevaSolicitudExterna_Servicios = value;
				SetDirty("Servicios");
			}
		}

		public void gxTv_SdtSDT_NuevaSolicitudExterna_Servicios_SetNull()
		{
			gxTv_SdtSDT_NuevaSolicitudExterna_Servicios_N = true;
			gxTv_SdtSDT_NuevaSolicitudExterna_Servicios = null;
		}

		public bool gxTv_SdtSDT_NuevaSolicitudExterna_Servicios_IsNull()
		{
			return gxTv_SdtSDT_NuevaSolicitudExterna_Servicios == null;
		}
		public bool ShouldSerializegxTpr_Servicios_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_NuevaSolicitudExterna_Servicios != null && gxTv_SdtSDT_NuevaSolicitudExterna_Servicios.Count > 0;

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
			gxTv_SdtSDT_NuevaSolicitudExterna_Comercioticketid = "";


			gxTv_SdtSDT_NuevaSolicitudExterna_Notasadicionales = "";
			gxTv_SdtSDT_NuevaSolicitudExterna_Moneda = "";

			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_N = true;


			gxTv_SdtSDT_NuevaSolicitudExterna_Servicios_N = true;

			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtSDT_NuevaSolicitudExterna_Comercioticketid;
		 

		protected DateTime gxTv_SdtSDT_NuevaSolicitudExterna_Fechacompra;
		 

		protected long gxTv_SdtSDT_NuevaSolicitudExterna_Sucursalid;
		 

		protected string gxTv_SdtSDT_NuevaSolicitudExterna_Notasadicionales;
		 

		protected string gxTv_SdtSDT_NuevaSolicitudExterna_Moneda;
		 
		protected bool gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_N;
		protected SdtSDT_NuevaSolicitudExterna_Cliente gxTv_SdtSDT_NuevaSolicitudExterna_Cliente = null; 

		protected bool gxTv_SdtSDT_NuevaSolicitudExterna_Servicios_N;
		protected GXBaseCollection<SdtSDT_NuevaSolicitudExterna_Item> gxTv_SdtSDT_NuevaSolicitudExterna_Servicios = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_NuevaSolicitudExterna", Namespace="AlmangoX")]
	public class SdtSDT_NuevaSolicitudExterna_RESTInterface : GxGenericCollectionItem<SdtSDT_NuevaSolicitudExterna>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_NuevaSolicitudExterna_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_NuevaSolicitudExterna_RESTInterface( SdtSDT_NuevaSolicitudExterna psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ComercioTicketId", Order=0)]
		public  string gxTpr_Comercioticketid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Comercioticketid);

			}
			set { 
				 sdt.gxTpr_Comercioticketid = value;
			}
		}

		[DataMember(Name="FechaCompra", Order=1)]
		public  string gxTpr_Fechacompra
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Fechacompra);

			}
			set { 
				sdt.gxTpr_Fechacompra = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="SucursalId", Order=2)]
		public  string gxTpr_Sucursalid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Sucursalid, 18, 0));

			}
			set { 
				sdt.gxTpr_Sucursalid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NotasAdicionales", Order=3)]
		public  string gxTpr_Notasadicionales
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Notasadicionales);

			}
			set { 
				 sdt.gxTpr_Notasadicionales = value;
			}
		}

		[DataMember(Name="Moneda", Order=4)]
		public  string gxTpr_Moneda
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Moneda);

			}
			set { 
				 sdt.gxTpr_Moneda = value;
			}
		}

		[DataMember(Name="Cliente", Order=5, EmitDefaultValue=false)]
		public SdtSDT_NuevaSolicitudExterna_Cliente_RESTInterface gxTpr_Cliente
		{
			get {
				if (sdt.ShouldSerializegxTpr_Cliente_Json())
					return new SdtSDT_NuevaSolicitudExterna_Cliente_RESTInterface(sdt.gxTpr_Cliente);
				else
					return null;

			}

			set {
				sdt.gxTpr_Cliente = value.sdt;
			}

		}

		[DataMember(Name="Servicios", Order=6, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_NuevaSolicitudExterna_Item_RESTInterface> gxTpr_Servicios
		{
			get {
				if (sdt.ShouldSerializegxTpr_Servicios_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_NuevaSolicitudExterna_Item_RESTInterface>(sdt.gxTpr_Servicios);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Servicios);
			}
		}


		#endregion
		public SdtSDT_NuevaSolicitudExterna sdt
		{
			get { 
				return (SdtSDT_NuevaSolicitudExterna)Sdt;
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
				sdt = new SdtSDT_NuevaSolicitudExterna() ;
			}
		}
	}
	#endregion
}