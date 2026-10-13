/*
				   File: type_SdtSDTComercioForanea_ProveedoresTipoItem
			Description: ProveedoresTipo
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
	[XmlRoot(ElementName="SDTComercioForanea.ProveedoresTipoItem")]
	[XmlType(TypeName="SDTComercioForanea.ProveedoresTipoItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTComercioForanea_ProveedoresTipoItem : GxUserType
	{
		public SdtSDTComercioForanea_ProveedoresTipoItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTComercioForanea_ProveedoresTipoItem_Proveedorestiponombre = "";

		}

		public SdtSDTComercioForanea_ProveedoresTipoItem(IGxContext context)
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
			AddObjectProperty("ProveedoresTipoId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Proveedorestipoid, 18, 0)), false);


			AddObjectProperty("ProveedoresTipoNombre", gxTpr_Proveedorestiponombre, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProveedoresTipoId")]
		[XmlElement(ElementName="ProveedoresTipoId")]
		public long gxTpr_Proveedorestipoid
		{
			get {
				return gxTv_SdtSDTComercioForanea_ProveedoresTipoItem_Proveedorestipoid; 
			}
			set {
				gxTv_SdtSDTComercioForanea_ProveedoresTipoItem_Proveedorestipoid = value;
				SetDirty("Proveedorestipoid");
			}
		}




		[SoapElement(ElementName="ProveedoresTipoNombre")]
		[XmlElement(ElementName="ProveedoresTipoNombre")]
		public string gxTpr_Proveedorestiponombre
		{
			get {
				return gxTv_SdtSDTComercioForanea_ProveedoresTipoItem_Proveedorestiponombre; 
			}
			set {
				gxTv_SdtSDTComercioForanea_ProveedoresTipoItem_Proveedorestiponombre = value;
				SetDirty("Proveedorestiponombre");
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
			gxTv_SdtSDTComercioForanea_ProveedoresTipoItem_Proveedorestiponombre = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTComercioForanea_ProveedoresTipoItem_Proveedorestipoid;
		 

		protected string gxTv_SdtSDTComercioForanea_ProveedoresTipoItem_Proveedorestiponombre;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTComercioForanea.ProveedoresTipoItem", Namespace="AlmangoX")]
	public class SdtSDTComercioForanea_ProveedoresTipoItem_RESTInterface : GxGenericCollectionItem<SdtSDTComercioForanea_ProveedoresTipoItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTComercioForanea_ProveedoresTipoItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTComercioForanea_ProveedoresTipoItem_RESTInterface( SdtSDTComercioForanea_ProveedoresTipoItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProveedoresTipoId", Order=0)]
		public  string gxTpr_Proveedorestipoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Proveedorestipoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Proveedorestipoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProveedoresTipoNombre", Order=1)]
		public  string gxTpr_Proveedorestiponombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedorestiponombre);

			}
			set { 
				 sdt.gxTpr_Proveedorestiponombre = value;
			}
		}


		#endregion
		public SdtSDTComercioForanea_ProveedoresTipoItem sdt
		{
			get { 
				return (SdtSDTComercioForanea_ProveedoresTipoItem)Sdt;
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
				sdt = new SdtSDTComercioForanea_ProveedoresTipoItem() ;
			}
		}
	}
	#endregion
}