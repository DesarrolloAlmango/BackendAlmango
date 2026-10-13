/*
				   File: type_SdtSdtReporteDEconomico
			Description: SdtReporteDEconomico
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
	[XmlRoot(ElementName="SdtReporteDEconomico")]
	[XmlType(TypeName="SdtReporteDEconomico" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSdtReporteDEconomico : GxUserType
	{
		public SdtSdtReporteDEconomico( )
		{
			/* Constructor for serialization */
		}

		public SdtSdtReporteDEconomico(IGxContext context)
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
			if (gxTv_SdtSdtReporteDEconomico_Cabezal != null)
			{
				AddObjectProperty("Cabezal", gxTv_SdtSdtReporteDEconomico_Cabezal, false);
			}
			if (gxTv_SdtSdtReporteDEconomico_Solicitudes != null)
			{
				AddObjectProperty("Solicitudes", gxTv_SdtSdtReporteDEconomico_Solicitudes, false);
			}
			if (gxTv_SdtSdtReporteDEconomico_Totales != null)
			{
				AddObjectProperty("Totales", gxTv_SdtSdtReporteDEconomico_Totales, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Cabezal" )]
		[XmlElement(ElementName="Cabezal" )]
		public SdtSdtReporteDEconomico_Cabezal gxTpr_Cabezal
		{
			get {
				if ( gxTv_SdtSdtReporteDEconomico_Cabezal == null )
				{
					gxTv_SdtSdtReporteDEconomico_Cabezal = new SdtSdtReporteDEconomico_Cabezal(context);
				}
				gxTv_SdtSdtReporteDEconomico_Cabezal_N = false;
				SetDirty("Cabezal");
				return gxTv_SdtSdtReporteDEconomico_Cabezal;
			}
			set {
				gxTv_SdtSdtReporteDEconomico_Cabezal_N = false;
				gxTv_SdtSdtReporteDEconomico_Cabezal = value;
				SetDirty("Cabezal");
			}

		}

		public void gxTv_SdtSdtReporteDEconomico_Cabezal_SetNull()
		{
			gxTv_SdtSdtReporteDEconomico_Cabezal_N = true;
			gxTv_SdtSdtReporteDEconomico_Cabezal = null;
		}

		public bool gxTv_SdtSdtReporteDEconomico_Cabezal_IsNull()
		{
			return gxTv_SdtSdtReporteDEconomico_Cabezal == null;
		}
		public bool ShouldSerializegxTpr_Cabezal_Json()
		{
				return (gxTv_SdtSdtReporteDEconomico_Cabezal != null && gxTv_SdtSdtReporteDEconomico_Cabezal.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="Solicitudes" )]
		[XmlArray(ElementName="Solicitudes"  )]
		[XmlArrayItemAttribute(ElementName="SolicitudesItem" , IsNullable=false )]
		public GXBaseCollection<SdtSdtReporteDEconomico_SolicitudesItem> gxTpr_Solicitudes
		{
			get {
				if ( gxTv_SdtSdtReporteDEconomico_Solicitudes == null )
				{
					gxTv_SdtSdtReporteDEconomico_Solicitudes = new GXBaseCollection<SdtSdtReporteDEconomico_SolicitudesItem>( context, "SdtReporteDEconomico.SolicitudesItem", "");
				}
				SetDirty("Solicitudes");
				return gxTv_SdtSdtReporteDEconomico_Solicitudes;
			}
			set {
				gxTv_SdtSdtReporteDEconomico_Solicitudes_N = false;
				gxTv_SdtSdtReporteDEconomico_Solicitudes = value;
				SetDirty("Solicitudes");
			}
		}

		public void gxTv_SdtSdtReporteDEconomico_Solicitudes_SetNull()
		{
			gxTv_SdtSdtReporteDEconomico_Solicitudes_N = true;
			gxTv_SdtSdtReporteDEconomico_Solicitudes = null;
		}

		public bool gxTv_SdtSdtReporteDEconomico_Solicitudes_IsNull()
		{
			return gxTv_SdtSdtReporteDEconomico_Solicitudes == null;
		}
		public bool ShouldSerializegxTpr_Solicitudes_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdtReporteDEconomico_Solicitudes != null && gxTv_SdtSdtReporteDEconomico_Solicitudes.Count > 0;

		}


		[SoapElement(ElementName="Totales" )]
		[XmlElement(ElementName="Totales" )]
		public SdtSdtReporteDEconomico_Totales gxTpr_Totales
		{
			get {
				if ( gxTv_SdtSdtReporteDEconomico_Totales == null )
				{
					gxTv_SdtSdtReporteDEconomico_Totales = new SdtSdtReporteDEconomico_Totales(context);
				}
				gxTv_SdtSdtReporteDEconomico_Totales_N = false;
				SetDirty("Totales");
				return gxTv_SdtSdtReporteDEconomico_Totales;
			}
			set {
				gxTv_SdtSdtReporteDEconomico_Totales_N = false;
				gxTv_SdtSdtReporteDEconomico_Totales = value;
				SetDirty("Totales");
			}

		}

		public void gxTv_SdtSdtReporteDEconomico_Totales_SetNull()
		{
			gxTv_SdtSdtReporteDEconomico_Totales_N = true;
			gxTv_SdtSdtReporteDEconomico_Totales = null;
		}

		public bool gxTv_SdtSdtReporteDEconomico_Totales_IsNull()
		{
			return gxTv_SdtSdtReporteDEconomico_Totales == null;
		}
		public bool ShouldSerializegxTpr_Totales_Json()
		{
				return (gxTv_SdtSdtReporteDEconomico_Totales != null && gxTv_SdtSdtReporteDEconomico_Totales.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Cabezal_Json() ||
				ShouldSerializegxTpr_Solicitudes_GxSimpleCollection_Json() ||
				ShouldSerializegxTpr_Totales_Json() || 
				false);
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
			gxTv_SdtSdtReporteDEconomico_Cabezal_N = true;


			gxTv_SdtSdtReporteDEconomico_Solicitudes_N = true;


			gxTv_SdtSdtReporteDEconomico_Totales_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSdtReporteDEconomico_Cabezal_N;
		protected SdtSdtReporteDEconomico_Cabezal gxTv_SdtSdtReporteDEconomico_Cabezal = null; 

		protected bool gxTv_SdtSdtReporteDEconomico_Solicitudes_N;
		protected GXBaseCollection<SdtSdtReporteDEconomico_SolicitudesItem> gxTv_SdtSdtReporteDEconomico_Solicitudes = null; 

		protected bool gxTv_SdtSdtReporteDEconomico_Totales_N;
		protected SdtSdtReporteDEconomico_Totales gxTv_SdtSdtReporteDEconomico_Totales = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdtReporteDEconomico", Namespace="AlmangoX")]
	public class SdtSdtReporteDEconomico_RESTInterface : GxGenericCollectionItem<SdtSdtReporteDEconomico>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdtReporteDEconomico_RESTInterface( ) : base()
		{	
		}

		public SdtSdtReporteDEconomico_RESTInterface( SdtSdtReporteDEconomico psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Cabezal", Order=0, EmitDefaultValue=false)]
		public SdtSdtReporteDEconomico_Cabezal_RESTInterface gxTpr_Cabezal
		{
			get {
				if (sdt.ShouldSerializegxTpr_Cabezal_Json())
					return new SdtSdtReporteDEconomico_Cabezal_RESTInterface(sdt.gxTpr_Cabezal);
				else
					return null;

			}

			set {
				sdt.gxTpr_Cabezal = value.sdt;
			}

		}

		[DataMember(Name="Solicitudes", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSdtReporteDEconomico_SolicitudesItem_RESTInterface> gxTpr_Solicitudes
		{
			get {
				if (sdt.ShouldSerializegxTpr_Solicitudes_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSdtReporteDEconomico_SolicitudesItem_RESTInterface>(sdt.gxTpr_Solicitudes);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Solicitudes);
			}
		}

		[DataMember(Name="Totales", Order=2, EmitDefaultValue=false)]
		public SdtSdtReporteDEconomico_Totales_RESTInterface gxTpr_Totales
		{
			get {
				if (sdt.ShouldSerializegxTpr_Totales_Json())
					return new SdtSdtReporteDEconomico_Totales_RESTInterface(sdt.gxTpr_Totales);
				else
					return null;

			}

			set {
				sdt.gxTpr_Totales = value.sdt;
			}

		}


		#endregion
		public SdtSdtReporteDEconomico sdt
		{
			get { 
				return (SdtSdtReporteDEconomico)Sdt;
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
				sdt = new SdtSdtReporteDEconomico() ;
			}
		}
	}
	#endregion
}