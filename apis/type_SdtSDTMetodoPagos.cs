/*
				   File: type_SdtSDTMetodoPagos
			Description: SDTMetodoPagos
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
	[XmlRoot(ElementName="SDTMetodoPagos")]
	[XmlType(TypeName="SDTMetodoPagos" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTMetodoPagos : GxUserType
	{
		public SdtSDTMetodoPagos( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTMetodoPagos_Metodopagosnombre = "";

		}

		public SdtSDTMetodoPagos(IGxContext context)
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
			AddObjectProperty("MetodoPagosID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Metodopagosid, 18, 0)), false);


			AddObjectProperty("MetodoPagosNombre", gxTpr_Metodopagosnombre, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MetodoPagosID")]
		[XmlElement(ElementName="MetodoPagosID")]
		public long gxTpr_Metodopagosid
		{
			get {
				return gxTv_SdtSDTMetodoPagos_Metodopagosid; 
			}
			set {
				gxTv_SdtSDTMetodoPagos_Metodopagosid = value;
				SetDirty("Metodopagosid");
			}
		}




		[SoapElement(ElementName="MetodoPagosNombre")]
		[XmlElement(ElementName="MetodoPagosNombre")]
		public string gxTpr_Metodopagosnombre
		{
			get {
				return gxTv_SdtSDTMetodoPagos_Metodopagosnombre; 
			}
			set {
				gxTv_SdtSDTMetodoPagos_Metodopagosnombre = value;
				SetDirty("Metodopagosnombre");
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
			gxTv_SdtSDTMetodoPagos_Metodopagosnombre = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTMetodoPagos_Metodopagosid;
		 

		protected string gxTv_SdtSDTMetodoPagos_Metodopagosnombre;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTMetodoPagos", Namespace="AlmangoX")]
	public class SdtSDTMetodoPagos_RESTInterface : GxGenericCollectionItem<SdtSDTMetodoPagos>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTMetodoPagos_RESTInterface( ) : base()
		{	
		}

		public SdtSDTMetodoPagos_RESTInterface( SdtSDTMetodoPagos psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="MetodoPagosID", Order=0)]
		public  string gxTpr_Metodopagosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Metodopagosid, 18, 0));

			}
			set { 
				sdt.gxTpr_Metodopagosid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MetodoPagosNombre", Order=1)]
		public  string gxTpr_Metodopagosnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Metodopagosnombre);

			}
			set { 
				 sdt.gxTpr_Metodopagosnombre = value;
			}
		}


		#endregion
		public SdtSDTMetodoPagos sdt
		{
			get { 
				return (SdtSDTMetodoPagos)Sdt;
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
				sdt = new SdtSDTMetodoPagos() ;
			}
		}
	}
	#endregion
}