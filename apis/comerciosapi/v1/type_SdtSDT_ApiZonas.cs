/*
				   File: type_SdtSDT_ApiZonas
			Description: SDT_ApiZonas
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
	[XmlRoot(ElementName="SDT_ApiZonas")]
	[XmlType(TypeName="SDT_ApiZonas" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDT_ApiZonas : GxUserType
	{
		public SdtSDT_ApiZonas( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_ApiZonas(IGxContext context)
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
			if (gxTv_SdtSDT_ApiZonas_Departamentos != null)
			{
				AddObjectProperty("Departamentos", gxTv_SdtSDT_ApiZonas_Departamentos, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Departamentos" )]
		[XmlArray(ElementName="Departamentos"  )]
		[XmlArrayItemAttribute(ElementName="DepartamentosItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_ApiZonas_DepartamentosItem> gxTpr_Departamentos
		{
			get {
				if ( gxTv_SdtSDT_ApiZonas_Departamentos == null )
				{
					gxTv_SdtSDT_ApiZonas_Departamentos = new GXBaseCollection<SdtSDT_ApiZonas_DepartamentosItem>( context, "SDT_ApiZonas.DepartamentosItem", "");
				}
				SetDirty("Departamentos");
				return gxTv_SdtSDT_ApiZonas_Departamentos;
			}
			set {
				gxTv_SdtSDT_ApiZonas_Departamentos_N = false;
				gxTv_SdtSDT_ApiZonas_Departamentos = value;
				SetDirty("Departamentos");
			}
		}

		public void gxTv_SdtSDT_ApiZonas_Departamentos_SetNull()
		{
			gxTv_SdtSDT_ApiZonas_Departamentos_N = true;
			gxTv_SdtSDT_ApiZonas_Departamentos = null;
		}

		public bool gxTv_SdtSDT_ApiZonas_Departamentos_IsNull()
		{
			return gxTv_SdtSDT_ApiZonas_Departamentos == null;
		}
		public bool ShouldSerializegxTpr_Departamentos_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_ApiZonas_Departamentos != null && gxTv_SdtSDT_ApiZonas_Departamentos.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Departamentos_GxSimpleCollection_Json() || 
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
			gxTv_SdtSDT_ApiZonas_Departamentos_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDT_ApiZonas_Departamentos_N;
		protected GXBaseCollection<SdtSDT_ApiZonas_DepartamentosItem> gxTv_SdtSDT_ApiZonas_Departamentos = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_ApiZonas", Namespace="AlmangoX")]
	public class SdtSDT_ApiZonas_RESTInterface : GxGenericCollectionItem<SdtSDT_ApiZonas>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ApiZonas_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ApiZonas_RESTInterface( SdtSDT_ApiZonas psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Departamentos", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_ApiZonas_DepartamentosItem_RESTInterface> gxTpr_Departamentos
		{
			get {
				if (sdt.ShouldSerializegxTpr_Departamentos_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_ApiZonas_DepartamentosItem_RESTInterface>(sdt.gxTpr_Departamentos);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Departamentos);
			}
		}


		#endregion
		public SdtSDT_ApiZonas sdt
		{
			get { 
				return (SdtSDT_ApiZonas)Sdt;
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
				sdt = new SdtSDT_ApiZonas() ;
			}
		}
	}
	#endregion
}