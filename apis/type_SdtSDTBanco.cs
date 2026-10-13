/*
				   File: type_SdtSDTBanco
			Description: SDTBanco
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
	[XmlRoot(ElementName="SDTBanco")]
	[XmlType(TypeName="SDTBanco" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTBanco : GxUserType
	{
		public SdtSDTBanco( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTBanco_Banconombre = "";

		}

		public SdtSDTBanco(IGxContext context)
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
				return gxTv_SdtSDTBanco_Bancoid; 
			}
			set {
				gxTv_SdtSDTBanco_Bancoid = value;
				SetDirty("Bancoid");
			}
		}




		[SoapElement(ElementName="BancoNombre")]
		[XmlElement(ElementName="BancoNombre")]
		public string gxTpr_Banconombre
		{
			get {
				return gxTv_SdtSDTBanco_Banconombre; 
			}
			set {
				gxTv_SdtSDTBanco_Banconombre = value;
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
			gxTv_SdtSDTBanco_Banconombre = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTBanco_Bancoid;
		 

		protected string gxTv_SdtSDTBanco_Banconombre;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTBanco", Namespace="AlmangoX")]
	public class SdtSDTBanco_RESTInterface : GxGenericCollectionItem<SdtSDTBanco>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTBanco_RESTInterface( ) : base()
		{	
		}

		public SdtSDTBanco_RESTInterface( SdtSDTBanco psdt ) : base(psdt)
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
		public SdtSDTBanco sdt
		{
			get { 
				return (SdtSDTBanco)Sdt;
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
				sdt = new SdtSDTBanco() ;
			}
		}
	}
	#endregion
}