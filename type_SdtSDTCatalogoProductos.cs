/*
				   File: type_SdtSDTCatalogoProductos
			Description: SDTCatalogoProductos
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
	[XmlRoot(ElementName="SDTCatalogoProductos")]
	[XmlType(TypeName="SDTCatalogoProductos" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTCatalogoProductos : GxUserType
	{
		public SdtSDTCatalogoProductos( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTCatalogoProductos(IGxContext context)
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
			if (gxTv_SdtSDTCatalogoProductos_Rubros != null)
			{
				AddObjectProperty("Rubros", gxTv_SdtSDTCatalogoProductos_Rubros, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Rubros" )]
		[XmlArray(ElementName="Rubros"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDTRubro> gxTpr_Rubros_GXBaseCollection
		{
			get {
				if ( gxTv_SdtSDTCatalogoProductos_Rubros == null )
				{
					gxTv_SdtSDTCatalogoProductos_Rubros = new GXBaseCollection<GeneXus.Programs.SdtSDTRubro>( context, "SDTRubro", "");
				}
				return gxTv_SdtSDTCatalogoProductos_Rubros;
			}
			set {
				gxTv_SdtSDTCatalogoProductos_Rubros_N = false;
				gxTv_SdtSDTCatalogoProductos_Rubros = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDTRubro> gxTpr_Rubros
		{
			get {
				if ( gxTv_SdtSDTCatalogoProductos_Rubros == null )
				{
					gxTv_SdtSDTCatalogoProductos_Rubros = new GXBaseCollection<GeneXus.Programs.SdtSDTRubro>( context, "SDTRubro", "");
				}
				gxTv_SdtSDTCatalogoProductos_Rubros_N = false;
				SetDirty("Rubros");
				return gxTv_SdtSDTCatalogoProductos_Rubros ;
			}
			set {
				gxTv_SdtSDTCatalogoProductos_Rubros_N = false;
				gxTv_SdtSDTCatalogoProductos_Rubros = value;
				SetDirty("Rubros");
			}
		}

		public void gxTv_SdtSDTCatalogoProductos_Rubros_SetNull()
		{
			gxTv_SdtSDTCatalogoProductos_Rubros_N = true;
			gxTv_SdtSDTCatalogoProductos_Rubros = null;
		}

		public bool gxTv_SdtSDTCatalogoProductos_Rubros_IsNull()
		{
			return gxTv_SdtSDTCatalogoProductos_Rubros == null;
		}
		public bool ShouldSerializegxTpr_Rubros_GXBaseCollection_Json()
		{
			return gxTv_SdtSDTCatalogoProductos_Rubros != null && gxTv_SdtSDTCatalogoProductos_Rubros.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Rubros_GXBaseCollection_Json()||  
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
			gxTv_SdtSDTCatalogoProductos_Rubros_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDTCatalogoProductos_Rubros_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDTRubro> gxTv_SdtSDTCatalogoProductos_Rubros = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTCatalogoProductos", Namespace="AlmangoX")]
	public class SdtSDTCatalogoProductos_RESTInterface : GxGenericCollectionItem<SdtSDTCatalogoProductos>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCatalogoProductos_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCatalogoProductos_RESTInterface( SdtSDTCatalogoProductos psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Rubros", Order=0, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDTRubro_RESTInterface> gxTpr_Rubros
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Rubros_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDTRubro_RESTInterface>(sdt.gxTpr_Rubros);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Rubros);
			}
		}


		#endregion
		public SdtSDTCatalogoProductos sdt
		{
			get { 
				return (SdtSDTCatalogoProductos)Sdt;
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
				sdt = new SdtSDTCatalogoProductos() ;
			}
		}
	}
	#endregion
}