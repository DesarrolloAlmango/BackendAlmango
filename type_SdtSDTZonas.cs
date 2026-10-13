/*
				   File: type_SdtSDTZonas
			Description: SDTZonas
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
	[XmlRoot(ElementName="SDTZonas")]
	[XmlType(TypeName="SDTZonas" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTZonas : GxUserType
	{
		public SdtSDTZonas( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTZonas_Paisiso = "";

		}

		public SdtSDTZonas(IGxContext context)
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
			AddObjectProperty("PaisISO", gxTpr_Paisiso, false);

			if (gxTv_SdtSDTZonas_Departamentos != null)
			{
				AddObjectProperty("Departamentos", gxTv_SdtSDTZonas_Departamentos, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PaisISO")]
		[XmlElement(ElementName="PaisISO")]
		public string gxTpr_Paisiso
		{
			get {
				return gxTv_SdtSDTZonas_Paisiso; 
			}
			set {
				gxTv_SdtSDTZonas_Paisiso = value;
				SetDirty("Paisiso");
			}
		}




		[SoapElement(ElementName="Departamentos" )]
		[XmlArray(ElementName="Departamentos"  )]
		[XmlArrayItemAttribute(ElementName="DepartamentosItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTZonas_DepartamentosItem> gxTpr_Departamentos
		{
			get {
				if ( gxTv_SdtSDTZonas_Departamentos == null )
				{
					gxTv_SdtSDTZonas_Departamentos = new GXBaseCollection<SdtSDTZonas_DepartamentosItem>( context, "SDTZonas.DepartamentosItem", "");
				}
				SetDirty("Departamentos");
				return gxTv_SdtSDTZonas_Departamentos;
			}
			set {
				gxTv_SdtSDTZonas_Departamentos_N = false;
				gxTv_SdtSDTZonas_Departamentos = value;
				SetDirty("Departamentos");
			}
		}

		public void gxTv_SdtSDTZonas_Departamentos_SetNull()
		{
			gxTv_SdtSDTZonas_Departamentos_N = true;
			gxTv_SdtSDTZonas_Departamentos = null;
		}

		public bool gxTv_SdtSDTZonas_Departamentos_IsNull()
		{
			return gxTv_SdtSDTZonas_Departamentos == null;
		}
		public bool ShouldSerializegxTpr_Departamentos_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTZonas_Departamentos != null && gxTv_SdtSDTZonas_Departamentos.Count > 0;

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
			gxTv_SdtSDTZonas_Paisiso = "";

			gxTv_SdtSDTZonas_Departamentos_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTZonas_Paisiso;
		 
		protected bool gxTv_SdtSDTZonas_Departamentos_N;
		protected GXBaseCollection<SdtSDTZonas_DepartamentosItem> gxTv_SdtSDTZonas_Departamentos = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTZonas", Namespace="AlmangoX")]
	public class SdtSDTZonas_RESTInterface : GxGenericCollectionItem<SdtSDTZonas>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTZonas_RESTInterface( ) : base()
		{	
		}

		public SdtSDTZonas_RESTInterface( SdtSDTZonas psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PaisISO", Order=0)]
		public  string gxTpr_Paisiso
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Paisiso);

			}
			set { 
				 sdt.gxTpr_Paisiso = value;
			}
		}

		[DataMember(Name="Departamentos", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTZonas_DepartamentosItem_RESTInterface> gxTpr_Departamentos
		{
			get {
				if (sdt.ShouldSerializegxTpr_Departamentos_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTZonas_DepartamentosItem_RESTInterface>(sdt.gxTpr_Departamentos);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Departamentos);
			}
		}


		#endregion
		public SdtSDTZonas sdt
		{
			get { 
				return (SdtSDTZonas)Sdt;
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
				sdt = new SdtSDTZonas() ;
			}
		}
	}
	#endregion
}