/*
				   File: type_SdtSDT_ApiZonas_DepartamentosItem
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

using GeneXus.Programs;
using GeneXus.Programs.apis;
using GeneXus.Programs.apis.comerciosapi;

namespace GeneXus.Programs.apis.comerciosapi.v1
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="SDT_ApiZonas.DepartamentosItem")]
	[XmlType(TypeName="SDT_ApiZonas.DepartamentosItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDT_ApiZonas_DepartamentosItem : GxUserType
	{
		public SdtSDT_ApiZonas_DepartamentosItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ApiZonas_DepartamentosItem_Nombre = "";

		}

		public SdtSDT_ApiZonas_DepartamentosItem(IGxContext context)
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
			AddObjectProperty("Id", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Id, 18, 0)), false);


			AddObjectProperty("Nombre", gxTpr_Nombre, false);

			if (gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios != null)
			{
				AddObjectProperty("Municipios", gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public long gxTpr_Id
		{
			get {
				return gxTv_SdtSDT_ApiZonas_DepartamentosItem_Id; 
			}
			set {
				gxTv_SdtSDT_ApiZonas_DepartamentosItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Nombre")]
		[XmlElement(ElementName="Nombre")]
		public string gxTpr_Nombre
		{
			get {
				return gxTv_SdtSDT_ApiZonas_DepartamentosItem_Nombre; 
			}
			set {
				gxTv_SdtSDT_ApiZonas_DepartamentosItem_Nombre = value;
				SetDirty("Nombre");
			}
		}




		[SoapElement(ElementName="Municipios" )]
		[XmlArray(ElementName="Municipios"  )]
		[XmlArrayItemAttribute(ElementName="MunicipiosItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem> gxTpr_Municipios
		{
			get {
				if ( gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios == null )
				{
					gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios = new GXBaseCollection<SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem>( context, "SDT_ApiZonas.DepartamentosItem.MunicipiosItem", "");
				}
				SetDirty("Municipios");
				return gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios;
			}
			set {
				gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios_N = false;
				gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios = value;
				SetDirty("Municipios");
			}
		}

		public void gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios_SetNull()
		{
			gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios_N = true;
			gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios = null;
		}

		public bool gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios_IsNull()
		{
			return gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios == null;
		}
		public bool ShouldSerializegxTpr_Municipios_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios != null && gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios.Count > 0;

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
			gxTv_SdtSDT_ApiZonas_DepartamentosItem_Nombre = "";

			gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDT_ApiZonas_DepartamentosItem_Id;
		 

		protected string gxTv_SdtSDT_ApiZonas_DepartamentosItem_Nombre;
		 
		protected bool gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios_N;
		protected GXBaseCollection<SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem> gxTv_SdtSDT_ApiZonas_DepartamentosItem_Municipios = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_ApiZonas.DepartamentosItem", Namespace="AlmangoX")]
	public class SdtSDT_ApiZonas_DepartamentosItem_RESTInterface : GxGenericCollectionItem<SdtSDT_ApiZonas_DepartamentosItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ApiZonas_DepartamentosItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ApiZonas_DepartamentosItem_RESTInterface( SdtSDT_ApiZonas_DepartamentosItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Id, 18, 0));

			}
			set { 
				sdt.gxTpr_Id = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Nombre", Order=1)]
		public  string gxTpr_Nombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nombre);

			}
			set { 
				 sdt.gxTpr_Nombre = value;
			}
		}

		[DataMember(Name="Municipios", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_RESTInterface> gxTpr_Municipios
		{
			get {
				if (sdt.ShouldSerializegxTpr_Municipios_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_RESTInterface>(sdt.gxTpr_Municipios);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Municipios);
			}
		}


		#endregion
		public SdtSDT_ApiZonas_DepartamentosItem sdt
		{
			get { 
				return (SdtSDT_ApiZonas_DepartamentosItem)Sdt;
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
				sdt = new SdtSDT_ApiZonas_DepartamentosItem() ;
			}
		}
	}
	#endregion
}