/*
				   File: type_SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem
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

using GeneXus.Programs;
using GeneXus.Programs.apis;
using GeneXus.Programs.apis.comerciosapi;

namespace GeneXus.Programs.apis.comerciosapi.v1
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="SDT_ApiZonas.DepartamentosItem.MunicipiosItem")]
	[XmlType(TypeName="SDT_ApiZonas.DepartamentosItem.MunicipiosItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem : GxUserType
	{
		public SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_Nombre = "";


		}

		public SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem(IGxContext context)
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


			AddObjectProperty("CostoAdicional", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Costoadicional, 18, 2)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public long gxTpr_Id
		{
			get {
				return gxTv_SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_Id; 
			}
			set {
				gxTv_SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Nombre")]
		[XmlElement(ElementName="Nombre")]
		public string gxTpr_Nombre
		{
			get {
				return gxTv_SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_Nombre; 
			}
			set {
				gxTv_SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_Nombre = value;
				SetDirty("Nombre");
			}
		}



		[SoapElement(ElementName="CostoAdicional")]
		[XmlElement(ElementName="CostoAdicional")]
		public string gxTpr_Costoadicional_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_Costoadicional, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_Costoadicional = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Costoadicional
		{
			get {
				return gxTv_SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_Costoadicional; 
			}
			set {
				gxTv_SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_Costoadicional = value;
				SetDirty("Costoadicional");
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
			gxTv_SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_Nombre = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_Id;
		 

		protected string gxTv_SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_Nombre;
		 

		protected decimal gxTv_SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_Costoadicional;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_ApiZonas.DepartamentosItem.MunicipiosItem", Namespace="AlmangoX")]
	public class SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_RESTInterface : GxGenericCollectionItem<SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem_RESTInterface( SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem psdt ) : base(psdt)
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

		[DataMember(Name="CostoAdicional", Order=2)]
		public  string gxTpr_Costoadicional
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Costoadicional, 18, 2));

			}
			set { 
				sdt.gxTpr_Costoadicional =  NumberUtil.Val( value, ".");
			}
		}


		#endregion
		public SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem sdt
		{
			get { 
				return (SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem)Sdt;
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
				sdt = new SdtSDT_ApiZonas_DepartamentosItem_MunicipiosItem() ;
			}
		}
	}
	#endregion
}