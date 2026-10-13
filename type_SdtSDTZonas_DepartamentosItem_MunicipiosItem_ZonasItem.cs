/*
				   File: type_SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem
			Description: Zonas
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
	[XmlRoot(ElementName="SDTZonas.DepartamentosItem.MunicipiosItem.ZonasItem")]
	[XmlType(TypeName="SDTZonas.DepartamentosItem.MunicipiosItem.ZonasItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem : GxUserType
	{
		public SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem_Zonasnombre = "";

		}

		public SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem(IGxContext context)
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
			AddObjectProperty("ZonasID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Zonasid, 18, 0)), false);


			AddObjectProperty("ZonasNombre", gxTpr_Zonasnombre, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ZonasID")]
		[XmlElement(ElementName="ZonasID")]
		public long gxTpr_Zonasid
		{
			get {
				return gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem_Zonasid; 
			}
			set {
				gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem_Zonasid = value;
				SetDirty("Zonasid");
			}
		}




		[SoapElement(ElementName="ZonasNombre")]
		[XmlElement(ElementName="ZonasNombre")]
		public string gxTpr_Zonasnombre
		{
			get {
				return gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem_Zonasnombre; 
			}
			set {
				gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem_Zonasnombre = value;
				SetDirty("Zonasnombre");
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
			gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem_Zonasnombre = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem_Zonasid;
		 

		protected string gxTv_SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem_Zonasnombre;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTZonas.DepartamentosItem.MunicipiosItem.ZonasItem", Namespace="AlmangoX")]
	public class SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem_RESTInterface : GxGenericCollectionItem<SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem_RESTInterface( SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ZonasID", Order=0)]
		public  string gxTpr_Zonasid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Zonasid, 18, 0));

			}
			set { 
				sdt.gxTpr_Zonasid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ZonasNombre", Order=1)]
		public  string gxTpr_Zonasnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Zonasnombre);

			}
			set { 
				 sdt.gxTpr_Zonasnombre = value;
			}
		}


		#endregion
		public SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem sdt
		{
			get { 
				return (SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem)Sdt;
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
				sdt = new SdtSDTZonas_DepartamentosItem_MunicipiosItem_ZonasItem() ;
			}
		}
	}
	#endregion
}