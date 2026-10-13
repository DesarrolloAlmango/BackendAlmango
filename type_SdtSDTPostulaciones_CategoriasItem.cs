/*
				   File: type_SdtSDTPostulaciones_CategoriasItem
			Description: Categorias
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
	[XmlRoot(ElementName="SDTPostulaciones.CategoriasItem")]
	[XmlType(TypeName="SDTPostulaciones.CategoriasItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTPostulaciones_CategoriasItem : GxUserType
	{
		public SdtSDTPostulaciones_CategoriasItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTPostulaciones_CategoriasItem_Categoriasnombre = "";

		}

		public SdtSDTPostulaciones_CategoriasItem(IGxContext context)
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
			AddObjectProperty("CategoriasId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Categoriasid, 18, 0)), false);


			AddObjectProperty("CategoriasNombre", gxTpr_Categoriasnombre, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CategoriasId")]
		[XmlElement(ElementName="CategoriasId")]
		public long gxTpr_Categoriasid
		{
			get {
				return gxTv_SdtSDTPostulaciones_CategoriasItem_Categoriasid; 
			}
			set {
				gxTv_SdtSDTPostulaciones_CategoriasItem_Categoriasid = value;
				SetDirty("Categoriasid");
			}
		}




		[SoapElement(ElementName="CategoriasNombre")]
		[XmlElement(ElementName="CategoriasNombre")]
		public string gxTpr_Categoriasnombre
		{
			get {
				return gxTv_SdtSDTPostulaciones_CategoriasItem_Categoriasnombre; 
			}
			set {
				gxTv_SdtSDTPostulaciones_CategoriasItem_Categoriasnombre = value;
				SetDirty("Categoriasnombre");
			}
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
			gxTv_SdtSDTPostulaciones_CategoriasItem_Categoriasnombre = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTPostulaciones_CategoriasItem_Categoriasid;
		 

		protected string gxTv_SdtSDTPostulaciones_CategoriasItem_Categoriasnombre;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTPostulaciones.CategoriasItem", Namespace="AlmangoX")]
	public class SdtSDTPostulaciones_CategoriasItem_RESTInterface : GxGenericCollectionItem<SdtSDTPostulaciones_CategoriasItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTPostulaciones_CategoriasItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTPostulaciones_CategoriasItem_RESTInterface( SdtSDTPostulaciones_CategoriasItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CategoriasId", Order=0)]
		public  string gxTpr_Categoriasid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Categoriasid, 18, 0));

			}
			set { 
				sdt.gxTpr_Categoriasid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="CategoriasNombre", Order=1)]
		public  string gxTpr_Categoriasnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Categoriasnombre);

			}
			set { 
				 sdt.gxTpr_Categoriasnombre = value;
			}
		}


		#endregion
		public SdtSDTPostulaciones_CategoriasItem sdt
		{
			get { 
				return (SdtSDTPostulaciones_CategoriasItem)Sdt;
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
				sdt = new SdtSDTPostulaciones_CategoriasItem() ;
			}
		}
	}
	#endregion
}