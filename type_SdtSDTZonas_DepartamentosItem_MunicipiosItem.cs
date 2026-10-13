/*
				   File: type_SdtSDTZonas_DepartamentosItem_MunicipiosItem
			Description: Municipios
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
	[XmlRoot(ElementName="SDTZonas.DepartamentosItem.MunicipiosItem")]
	[XmlType(TypeName="SDTZonas.DepartamentosItem.MunicipiosItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTZonas_DepartamentosItem_MunicipiosItem : GxUserType
	{
		public SdtSDTZonas_DepartamentosItem_MunicipiosItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Municipionombre = "";

		}

		public SdtSDTZonas_DepartamentosItem_MunicipiosItem(IGxContext context)
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
			AddObjectProperty("MunicipioId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Municipioid, 18, 0)), false);


			AddObjectProperty("MunicipioNombre", gxTpr_Municipionombre, false);

			if (gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas != null)
			{
				AddObjectProperty("Zonas", gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MunicipioId")]
		[XmlElement(ElementName="MunicipioId")]
		public long gxTpr_Municipioid
		{
			get {
				return gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Municipioid; 
			}
			set {
				gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Municipioid = value;
				SetDirty("Municipioid");
			}
		}




		[SoapElement(ElementName="MunicipioNombre")]
		[XmlElement(ElementName="MunicipioNombre")]
		public string gxTpr_Municipionombre
		{
			get {
				return gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Municipionombre; 
			}
			set {
				gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Municipionombre = value;
				SetDirty("Municipionombre");
			}
		}




		[SoapElement(ElementName="Zonas" )]
		[XmlArray(ElementName="Zonas"  )]
		[XmlArrayItemAttribute(ElementName="ZonasItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem> gxTpr_Zonas
		{
			get {
				if ( gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas == null )
				{
					gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas = new GXBaseCollection<SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem>( context, "SDTZonas.DepartamentosItem.MunicipiosItem.ZonasItem", "");
				}
				SetDirty("Zonas");
				return gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas;
			}
			set {
				gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas_N = false;
				gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas = value;
				SetDirty("Zonas");
			}
		}

		public void gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas_SetNull()
		{
			gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas_N = true;
			gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas = null;
		}

		public bool gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas_IsNull()
		{
			return gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas == null;
		}
		public bool ShouldSerializegxTpr_Zonas_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas != null && gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas.Count > 0;

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
			gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Municipionombre = "";

			gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Municipioid;
		 

		protected string gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Municipionombre;
		 
		protected bool gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas_N;
		protected GXBaseCollection<SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem> gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_Zonas = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTZonas.DepartamentosItem.MunicipiosItem", Namespace="AlmangoX")]
	public class SdtSDTZonas_DepartamentosItem_MunicipiosItem_RESTInterface : GxGenericCollectionItem<SdtSDTZonas_DepartamentosItem_MunicipiosItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTZonas_DepartamentosItem_MunicipiosItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTZonas_DepartamentosItem_MunicipiosItem_RESTInterface( SdtSDTZonas_DepartamentosItem_MunicipiosItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="MunicipioId", Order=0)]
		public  string gxTpr_Municipioid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Municipioid, 18, 0));

			}
			set { 
				sdt.gxTpr_Municipioid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MunicipioNombre", Order=1)]
		public  string gxTpr_Municipionombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Municipionombre);

			}
			set { 
				 sdt.gxTpr_Municipionombre = value;
			}
		}

		[DataMember(Name="Zonas", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem_RESTInterface> gxTpr_Zonas
		{
			get {
				if (sdt.ShouldSerializegxTpr_Zonas_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem_RESTInterface>(sdt.gxTpr_Zonas);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Zonas);
			}
		}


		#endregion
		public SdtSDTZonas_DepartamentosItem_MunicipiosItem sdt
		{
			get { 
				return (SdtSDTZonas_DepartamentosItem_MunicipiosItem)Sdt;
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
				sdt = new SdtSDTZonas_DepartamentosItem_MunicipiosItem() ;
			}
		}
	}
	#endregion
}