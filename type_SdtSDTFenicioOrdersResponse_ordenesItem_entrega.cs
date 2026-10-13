/*
				   File: type_SdtSDTFenicioOrdersResponse_ordenesItem_entrega
			Description: entrega
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
	[XmlRoot(ElementName="SDTFenicioOrdersResponse.ordenesItem.entrega")]
	[XmlType(TypeName="SDTFenicioOrdersResponse.ordenesItem.entrega" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTFenicioOrdersResponse_ordenesItem_entrega : GxUserType
	{
		public SdtSDTFenicioOrdersResponse_ordenesItem_entrega( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Tipo = "";

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Estado = "";

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Destinatario = "";

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Direccionenvio_N = true;

		}

		public SdtSDTFenicioOrdersResponse_ordenesItem_entrega(IGxContext context)
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
			AddObjectProperty("tipo", gxTpr_Tipo, false);


			AddObjectProperty("estado", gxTpr_Estado, false);


			AddObjectProperty("destinatario", gxTpr_Destinatario, false);

			if (gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Direccionenvio != null)
			{
				AddObjectProperty("direccionEnvio", gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Direccionenvio, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="tipo")]
		[XmlElement(ElementName="tipo")]
		public string gxTpr_Tipo
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Tipo; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Tipo = value;
				SetDirty("Tipo");
			}
		}




		[SoapElement(ElementName="estado")]
		[XmlElement(ElementName="estado")]
		public string gxTpr_Estado
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Estado; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Estado = value;
				SetDirty("Estado");
			}
		}




		[SoapElement(ElementName="destinatario")]
		[XmlElement(ElementName="destinatario")]
		public string gxTpr_Destinatario
		{
			get {
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Destinatario; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Destinatario = value;
				SetDirty("Destinatario");
			}
		}



		[SoapElement(ElementName="direccionEnvio")]
		[XmlElement(ElementName="direccionEnvio")]
		public GeneXus.Programs.SdtSDTFenicioDireccionEnvio gxTpr_Direccionenvio
		{
			get {
				if ( gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Direccionenvio == null )
				{
					gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Direccionenvio = new GeneXus.Programs.SdtSDTFenicioDireccionEnvio(context);
					SetDirty("Direccionenvio");
				}
				return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Direccionenvio; 
			}
			set {
				gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Direccionenvio = value;
				SetDirty("Direccionenvio");
			}
		}
		public void gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Direccionenvio_SetNull()
		{
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Direccionenvio_N = true;
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Direccionenvio = null;
		}

		public bool gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Direccionenvio_IsNull()
		{
			return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Direccionenvio == null;
		}
		public bool ShouldSerializegxTpr_Direccionenvio_Json()
		{
			return gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Direccionenvio != null;

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
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Tipo = "";
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Estado = "";
			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Destinatario = "";

			gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Direccionenvio_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Tipo;
		 

		protected string gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Estado;
		 

		protected string gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Destinatario;
		 

		protected GeneXus.Programs.SdtSDTFenicioDireccionEnvio gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Direccionenvio = null;
		protected bool gxTv_SdtSDTFenicioOrdersResponse_ordenesItem_entrega_Direccionenvio_N;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTFenicioOrdersResponse.ordenesItem.entrega", Namespace="AlmangoX")]
	public class SdtSDTFenicioOrdersResponse_ordenesItem_entrega_RESTInterface : GxGenericCollectionItem<SdtSDTFenicioOrdersResponse_ordenesItem_entrega>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTFenicioOrdersResponse_ordenesItem_entrega_RESTInterface( ) : base()
		{	
		}

		public SdtSDTFenicioOrdersResponse_ordenesItem_entrega_RESTInterface( SdtSDTFenicioOrdersResponse_ordenesItem_entrega psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="tipo", Order=0)]
		public  string gxTpr_Tipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tipo);

			}
			set { 
				 sdt.gxTpr_Tipo = value;
			}
		}

		[DataMember(Name="estado", Order=1)]
		public  string gxTpr_Estado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Estado);

			}
			set { 
				 sdt.gxTpr_Estado = value;
			}
		}

		[DataMember(Name="destinatario", Order=2)]
		public  string gxTpr_Destinatario
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Destinatario);

			}
			set { 
				 sdt.gxTpr_Destinatario = value;
			}
		}

		[DataMember(Name="direccionEnvio", Order=3, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDTFenicioDireccionEnvio_RESTInterface gxTpr_Direccionenvio
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Direccionenvio_Json())
					return new GeneXus.Programs.SdtSDTFenicioDireccionEnvio_RESTInterface(sdt.gxTpr_Direccionenvio);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Direccionenvio = value.sdt;
			}
		}


		#endregion
		public SdtSDTFenicioOrdersResponse_ordenesItem_entrega sdt
		{
			get { 
				return (SdtSDTFenicioOrdersResponse_ordenesItem_entrega)Sdt;
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
				sdt = new SdtSDTFenicioOrdersResponse_ordenesItem_entrega() ;
			}
		}
	}
	#endregion
}