/*
				   File: type_SdtSDTZonas_DepartamentosItem
			Description: Departamentos
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
	[XmlRoot(ElementName="SDTZonas.DepartamentosItem")]
	[XmlType(TypeName="SDTZonas.DepartamentosItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTZonas_DepartamentosItem : GxUserType
	{
		public SdtSDTZonas_DepartamentosItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTZonas_DepartamentosItem_Departamentonombre = "";

		}

		public SdtSDTZonas_DepartamentosItem(IGxContext context)
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
			AddObjectProperty("DepartamentoId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Departamentoid, 18, 0)), false);


			AddObjectProperty("DepartamentoNombre", gxTpr_Departamentonombre, false);

			if (gxTv_SdtSDTZonas_DepartamentosItem_Municipios != null)
			{
				AddObjectProperty("Municipios", gxTv_SdtSDTZonas_DepartamentosItem_Municipios, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DepartamentoId")]
		[XmlElement(ElementName="DepartamentoId")]
		public long gxTpr_Departamentoid
		{
			get {
				return gxTv_SdtSDTZonas_DepartamentosItem_Departamentoid; 
			}
			set {
				gxTv_SdtSDTZonas_DepartamentosItem_Departamentoid = value;
				SetDirty("Departamentoid");
			}
		}




		[SoapElement(ElementName="DepartamentoNombre")]
		[XmlElement(ElementName="DepartamentoNombre")]
		public string gxTpr_Departamentonombre
		{
			get {
				return gxTv_SdtSDTZonas_DepartamentosItem_Departamentonombre; 
			}
			set {
				gxTv_SdtSDTZonas_DepartamentosItem_Departamentonombre = value;
				SetDirty("Departamentonombre");
			}
		}




		[SoapElement(ElementName="Municipios" )]
		[XmlArray(ElementName="Municipios"  )]
		[XmlArrayItemAttribute(ElementName="MunicipiosItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTZonas_DepartamentosItem_MunicipiosItem> gxTpr_Municipios
		{
			get {
				if ( gxTv_SdtSDTZonas_DepartamentosItem_Municipios == null )
				{
					gxTv_SdtSDTZonas_DepartamentosItem_Municipios = new GXBaseCollection<SdtSDTZonas_DepartamentosItem_MunicipiosItem>( context, "SDTZonas.DepartamentosItem.MunicipiosItem", "");
				}
				SetDirty("Municipios");
				return gxTv_SdtSDTZonas_DepartamentosItem_Municipios;
			}
			set {
				gxTv_SdtSDTZonas_DepartamentosItem_Municipios_N = false;
				gxTv_SdtSDTZonas_DepartamentosItem_Municipios = value;
				SetDirty("Municipios");
			}
		}

		public void gxTv_SdtSDTZonas_DepartamentosItem_Municipios_SetNull()
		{
			gxTv_SdtSDTZonas_DepartamentosItem_Municipios_N = true;
			gxTv_SdtSDTZonas_DepartamentosItem_Municipios = null;
		}

		public bool gxTv_SdtSDTZonas_DepartamentosItem_Municipios_IsNull()
		{
			return gxTv_SdtSDTZonas_DepartamentosItem_Municipios == null;
		}
		public bool ShouldSerializegxTpr_Municipios_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTZonas_DepartamentosItem_Municipios != null && gxTv_SdtSDTZonas_DepartamentosItem_Municipios.Count > 0;

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
			gxTv_SdtSDTZonas_DepartamentosItem_Departamentonombre = "";

			gxTv_SdtSDTZonas_DepartamentosItem_Municipios_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTZonas_DepartamentosItem_Departamentoid;
		 

		protected string gxTv_SdtSDTZonas_DepartamentosItem_Departamentonombre;
		 
		protected bool gxTv_SdtSDTZonas_DepartamentosItem_Municipios_N;
		protected GXBaseCollection<SdtSDTZonas_DepartamentosItem_MunicipiosItem> gxTv_SdtSDTZonas_DepartamentosItem_Municipios = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTZonas.DepartamentosItem", Namespace="AlmangoX")]
	public class SdtSDTZonas_DepartamentosItem_RESTInterface : GxGenericCollectionItem<SdtSDTZonas_DepartamentosItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTZonas_DepartamentosItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTZonas_DepartamentosItem_RESTInterface( SdtSDTZonas_DepartamentosItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="DepartamentoId", Order=0)]
		public  string gxTpr_Departamentoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Departamentoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Departamentoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DepartamentoNombre", Order=1)]
		public  string gxTpr_Departamentonombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Departamentonombre);

			}
			set { 
				 sdt.gxTpr_Departamentonombre = value;
			}
		}

		[DataMember(Name="Municipios", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTZonas_DepartamentosItem_MunicipiosItem_RESTInterface> gxTpr_Municipios
		{
			get {
				if (sdt.ShouldSerializegxTpr_Municipios_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTZonas_DepartamentosItem_MunicipiosItem_RESTInterface>(sdt.gxTpr_Municipios);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Municipios);
			}
		}


		#endregion
		public SdtSDTZonas_DepartamentosItem sdt
		{
			get { 
				return (SdtSDTZonas_DepartamentosItem)Sdt;
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
				sdt = new SdtSDTZonas_DepartamentosItem() ;
			}
		}
	}
	#endregion
}