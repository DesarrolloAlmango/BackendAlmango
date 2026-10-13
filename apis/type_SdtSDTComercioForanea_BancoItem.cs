/*
				   File: type_SdtSDTComercioForanea_BancoItem
			Description: Banco
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
	[XmlRoot(ElementName="SDTComercioForanea.BancoItem")]
	[XmlType(TypeName="SDTComercioForanea.BancoItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTComercioForanea_BancoItem : GxUserType
	{
		public SdtSDTComercioForanea_BancoItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTComercioForanea_BancoItem_Banconombre = "";

		}

		public SdtSDTComercioForanea_BancoItem(IGxContext context)
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
			AddObjectProperty("BancoId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Bancoid, 18, 0)), false);


			AddObjectProperty("BancoNombre", gxTpr_Banconombre, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="BancoId")]
		[XmlElement(ElementName="BancoId")]
		public long gxTpr_Bancoid
		{
			get {
				return gxTv_SdtSDTComercioForanea_BancoItem_Bancoid; 
			}
			set {
				gxTv_SdtSDTComercioForanea_BancoItem_Bancoid = value;
				SetDirty("Bancoid");
			}
		}




		[SoapElement(ElementName="BancoNombre")]
		[XmlElement(ElementName="BancoNombre")]
		public string gxTpr_Banconombre
		{
			get {
				return gxTv_SdtSDTComercioForanea_BancoItem_Banconombre; 
			}
			set {
				gxTv_SdtSDTComercioForanea_BancoItem_Banconombre = value;
				SetDirty("Banconombre");
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
			gxTv_SdtSDTComercioForanea_BancoItem_Banconombre = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTComercioForanea_BancoItem_Bancoid;
		 

		protected string gxTv_SdtSDTComercioForanea_BancoItem_Banconombre;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTComercioForanea.BancoItem", Namespace="AlmangoX")]
	public class SdtSDTComercioForanea_BancoItem_RESTInterface : GxGenericCollectionItem<SdtSDTComercioForanea_BancoItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTComercioForanea_BancoItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTComercioForanea_BancoItem_RESTInterface( SdtSDTComercioForanea_BancoItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="BancoId", Order=0)]
		public  string gxTpr_Bancoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Bancoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Bancoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="BancoNombre", Order=1)]
		public  string gxTpr_Banconombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Banconombre);

			}
			set { 
				 sdt.gxTpr_Banconombre = value;
			}
		}


		#endregion
		public SdtSDTComercioForanea_BancoItem sdt
		{
			get { 
				return (SdtSDTComercioForanea_BancoItem)Sdt;
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
				sdt = new SdtSDTComercioForanea_BancoItem() ;
			}
		}
	}
	#endregion
}