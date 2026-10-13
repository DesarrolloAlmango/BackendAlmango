/*
				   File: type_SdtSDTFenicioOrdersResponse
			Description: SDTFenicioOrdersResponse
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
	[XmlRoot(ElementName="SDTFenicioOrdersResponse")]
	[XmlType(TypeName="SDTFenicioOrdersResponse" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTFenicioOrdersResponse : GxUserType
	{
		public SdtSDTFenicioOrdersResponse( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTFenicioOrdersResponse_Msj = "";


		}

		public SdtSDTFenicioOrdersResponse(IGxContext context)
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
			AddObjectProperty("error", gxTpr_Error, false);


			AddObjectProperty("msj", gxTpr_Msj, false);


			AddObjectProperty("totAbs", gxTpr_Totabs, false);

			if (gxTv_SdtSDTFenicioOrdersResponse_Ordenes != null)
			{
				AddObjectProperty("ordenes", gxTv_SdtSDTFenicioOrdersResponse_Ordenes, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="error")]
		[XmlElement(ElementName="error")]
		public bool gxTpr_Error
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_Error; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_Error = value;
				SetDirty("Error");
			}
		}




		[SoapElement(ElementName="msj")]
		[XmlElement(ElementName="msj")]
		public string gxTpr_Msj
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_Msj; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_Msj = value;
				SetDirty("Msj");
			}
		}



		[SoapElement(ElementName="totAbs")]
		[XmlElement(ElementName="totAbs")]
		public string gxTpr_Totabs_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTFenicioOrdersResponse_Totabs, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_Totabs = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Totabs
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_Totabs; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_Totabs = value;
				SetDirty("Totabs");
			}
		}




		[SoapElement(ElementName="ordenes" )]
		[XmlArray(ElementName="ordenes"  )]
		[XmlArrayItemAttribute(ElementName="ordenesItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTFenicioOrdersResponse_ordenesItem> gxTpr_Ordenes
		{
			get {
				if ( gxTv_SdtSDTFenicioOrdersResponse_Ordenes == null )
				{
					gxTv_SdtSDTFenicioOrdersResponse_Ordenes = new GXBaseCollection<SdtSDTFenicioOrdersResponse_ordenesItem>( context, "SDTFenicioOrdersResponse.ordenesItem", "");
				}
				SetDirty("Ordenes");
				return gxTv_SdtSDTFenicioOrdersResponse_Ordenes;
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_Ordenes_N = false;
				gxTv_SdtSDTFenicioOrdersResponse_Ordenes = value;
				SetDirty("Ordenes");
			}
		}

		public void gxTv_SdtSDTFenicioOrdersResponse_Ordenes_SetNull()
		{
			gxTv_SdtSDTFenicioOrdersResponse_Ordenes_N = true;
			gxTv_SdtSDTFenicioOrdersResponse_Ordenes = null;
		}

		public bool gxTv_SdtSDTFenicioOrdersResponse_Ordenes_IsNull()
		{
			return gxTv_SdtSDTFenicioOrdersResponse_Ordenes == null;
		}
		public bool ShouldSerializegxTpr_Ordenes_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTFenicioOrdersResponse_Ordenes != null && gxTv_SdtSDTFenicioOrdersResponse_Ordenes.Count > 0;

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
			gxTv_SdtSDTFenicioOrdersResponse_Msj = "";


			gxTv_SdtSDTFenicioOrdersResponse_Ordenes_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDTFenicioOrdersResponse_Error;
		 

		protected string gxTv_SdtSDTFenicioOrdersResponse_Msj;
		 

		protected decimal gxTv_SdtSDTFenicioOrdersResponse_Totabs;
		 
		protected bool gxTv_SdtSDTFenicioOrdersResponse_Ordenes_N;
		protected GXBaseCollection<SdtSDTFenicioOrdersResponse_ordenesItem> gxTv_SdtSDTFenicioOrdersResponse_Ordenes = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTFenicioOrdersResponse", Namespace="AlmangoX")]
	public class SdtSDTFenicioOrdersResponse_RESTInterface : GxGenericCollectionItem<SdtSDTFenicioOrdersResponse>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTFenicioOrdersResponse_RESTInterface( ) : base()
		{	
		}

		public SdtSDTFenicioOrdersResponse_RESTInterface( SdtSDTFenicioOrdersResponse psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="error", Order=0)]
		public bool gxTpr_Error
		{
			get { 
				return sdt.gxTpr_Error;

			}
			set { 
				sdt.gxTpr_Error = value;
			}
		}

		[DataMember(Name="msj", Order=1)]
		public  string gxTpr_Msj
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Msj);

			}
			set { 
				 sdt.gxTpr_Msj = value;
			}
		}

		[DataMember(Name="totAbs", Order=2)]
		public  string gxTpr_Totabs
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totabs, 10, 5));

			}
			set { 
				sdt.gxTpr_Totabs =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ordenes", Order=3, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTFenicioOrdersResponse_ordenesItem_RESTInterface> gxTpr_Ordenes
		{
			get {
				if (sdt.ShouldSerializegxTpr_Ordenes_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTFenicioOrdersResponse_ordenesItem_RESTInterface>(sdt.gxTpr_Ordenes);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Ordenes);
			}
		}


		#endregion
		public SdtSDTFenicioOrdersResponse sdt
		{
			get { 
				return (SdtSDTFenicioOrdersResponse)Sdt;
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
				sdt = new SdtSDTFenicioOrdersResponse() ;
			}
		}
	}
	#endregion
}