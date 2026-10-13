/*
				   File: type_SdtSDTProductosActivos_SDTProductosActivosItem
			Description: SDTProductosActivos
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
	[XmlRoot(ElementName="SDTProductosActivosItem")]
	[XmlType(TypeName="SDTProductosActivosItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTProductosActivos_SDTProductosActivosItem : GxUserType
	{
		public SdtSDTProductosActivos_SDTProductosActivosItem( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTProductosActivos_SDTProductosActivosItem(IGxContext context)
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
			AddObjectProperty("CategoriaId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Categoriaid, 18, 0)), false);


			AddObjectProperty("ProductoId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Productoid, 18, 0)), false);


			AddObjectProperty("Activo", gxTpr_Activo, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CategoriaId")]
		[XmlElement(ElementName="CategoriaId")]
		public long gxTpr_Categoriaid
		{
			get {
				return gxTv_SdtSDTProductosActivos_SDTProductosActivosItem_Categoriaid; 
			}
			set {
				gxTv_SdtSDTProductosActivos_SDTProductosActivosItem_Categoriaid = value;
				SetDirty("Categoriaid");
			}
		}




		[SoapElement(ElementName="ProductoId")]
		[XmlElement(ElementName="ProductoId")]
		public long gxTpr_Productoid
		{
			get {
				return gxTv_SdtSDTProductosActivos_SDTProductosActivosItem_Productoid; 
			}
			set {
				gxTv_SdtSDTProductosActivos_SDTProductosActivosItem_Productoid = value;
				SetDirty("Productoid");
			}
		}




		[SoapElement(ElementName="Activo")]
		[XmlElement(ElementName="Activo")]
		public bool gxTpr_Activo
		{
			get {
				return gxTv_SdtSDTProductosActivos_SDTProductosActivosItem_Activo; 
			}
			set {
				gxTv_SdtSDTProductosActivos_SDTProductosActivosItem_Activo = value;
				SetDirty("Activo");
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
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTProductosActivos_SDTProductosActivosItem_Categoriaid;
		 

		protected long gxTv_SdtSDTProductosActivos_SDTProductosActivosItem_Productoid;
		 

		protected bool gxTv_SdtSDTProductosActivos_SDTProductosActivosItem_Activo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTProductosActivosItem", Namespace="AlmangoX")]
	public class SdtSDTProductosActivos_SDTProductosActivosItem_RESTInterface : GxGenericCollectionItem<SdtSDTProductosActivos_SDTProductosActivosItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTProductosActivos_SDTProductosActivosItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTProductosActivos_SDTProductosActivosItem_RESTInterface( SdtSDTProductosActivos_SDTProductosActivosItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CategoriaId", Order=0)]
		public  string gxTpr_Categoriaid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Categoriaid, 18, 0));

			}
			set { 
				sdt.gxTpr_Categoriaid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProductoId", Order=1)]
		public  string gxTpr_Productoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Productoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Productoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Activo", Order=2)]
		public bool gxTpr_Activo
		{
			get { 
				return sdt.gxTpr_Activo;

			}
			set { 
				sdt.gxTpr_Activo = value;
			}
		}


		#endregion
		public SdtSDTProductosActivos_SDTProductosActivosItem sdt
		{
			get { 
				return (SdtSDTProductosActivos_SDTProductosActivosItem)Sdt;
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
				sdt = new SdtSDTProductosActivos_SDTProductosActivosItem() ;
			}
		}
	}
	#endregion
}