/*
				   File: type_SdtSDTMotivo
			Description: SDTMotivo
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
	[XmlRoot(ElementName="SDTMotivo")]
	[XmlType(TypeName="SDTMotivo" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTMotivo : GxUserType
	{
		public SdtSDTMotivo( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTMotivo_Motivotipo = "";

			gxTv_SdtSDTMotivo_Motivonombre = "";

		}

		public SdtSDTMotivo(IGxContext context)
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
			AddObjectProperty("MotivoId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Motivoid, 18, 0)), false);


			AddObjectProperty("MotivoTipo", gxTpr_Motivotipo, false);


			AddObjectProperty("MotivoNombre", gxTpr_Motivonombre, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MotivoId")]
		[XmlElement(ElementName="MotivoId")]
		public long gxTpr_Motivoid
		{
			get {
				return gxTv_SdtSDTMotivo_Motivoid; 
			}
			set {
				gxTv_SdtSDTMotivo_Motivoid = value;
				SetDirty("Motivoid");
			}
		}




		[SoapElement(ElementName="MotivoTipo")]
		[XmlElement(ElementName="MotivoTipo")]
		public string gxTpr_Motivotipo
		{
			get {
				return gxTv_SdtSDTMotivo_Motivotipo; 
			}
			set {
				gxTv_SdtSDTMotivo_Motivotipo = value;
				SetDirty("Motivotipo");
			}
		}




		[SoapElement(ElementName="MotivoNombre")]
		[XmlElement(ElementName="MotivoNombre")]
		public string gxTpr_Motivonombre
		{
			get {
				return gxTv_SdtSDTMotivo_Motivonombre; 
			}
			set {
				gxTv_SdtSDTMotivo_Motivonombre = value;
				SetDirty("Motivonombre");
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
			gxTv_SdtSDTMotivo_Motivotipo = "";
			gxTv_SdtSDTMotivo_Motivonombre = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTMotivo_Motivoid;
		 

		protected string gxTv_SdtSDTMotivo_Motivotipo;
		 

		protected string gxTv_SdtSDTMotivo_Motivonombre;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTMotivo", Namespace="AlmangoX")]
	public class SdtSDTMotivo_RESTInterface : GxGenericCollectionItem<SdtSDTMotivo>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTMotivo_RESTInterface( ) : base()
		{	
		}

		public SdtSDTMotivo_RESTInterface( SdtSDTMotivo psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="MotivoId", Order=0)]
		public  string gxTpr_Motivoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Motivoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Motivoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MotivoTipo", Order=1)]
		public  string gxTpr_Motivotipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Motivotipo);

			}
			set { 
				 sdt.gxTpr_Motivotipo = value;
			}
		}

		[DataMember(Name="MotivoNombre", Order=2)]
		public  string gxTpr_Motivonombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Motivonombre);

			}
			set { 
				 sdt.gxTpr_Motivonombre = value;
			}
		}


		#endregion
		public SdtSDTMotivo sdt
		{
			get { 
				return (SdtSDTMotivo)Sdt;
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
				sdt = new SdtSDTMotivo() ;
			}
		}
	}
	#endregion
}