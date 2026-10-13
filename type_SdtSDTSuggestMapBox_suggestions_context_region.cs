/*
				   File: type_SdtSDTSuggestMapBox_suggestions_context_region
			Description: region
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
	[XmlRoot(ElementName="SDTSuggestMapBox.suggestions.context.region")]
	[XmlType(TypeName="SDTSuggestMapBox.suggestions.context.region" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTSuggestMapBox_suggestions_context_region : GxUserType
	{
		public SdtSDTSuggestMapBox_suggestions_context_region( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Id = "";

			gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Name = "";

			gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Region_code = "";

			gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Region_code_full = "";

		}

		public SdtSDTSuggestMapBox_suggestions_context_region(IGxContext context)
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
			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("name", gxTpr_Name, false);


			AddObjectProperty("region_code", gxTpr_Region_code, false);


			AddObjectProperty("region_code_full", gxTpr_Region_code_full, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Id; 
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Name; 
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="region_code")]
		[XmlElement(ElementName="region_code")]
		public string gxTpr_Region_code
		{
			get {
				return gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Region_code; 
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Region_code = value;
				SetDirty("Region_code");
			}
		}




		[SoapElement(ElementName="region_code_full")]
		[XmlElement(ElementName="region_code_full")]
		public string gxTpr_Region_code_full
		{
			get {
				return gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Region_code_full; 
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Region_code_full = value;
				SetDirty("Region_code_full");
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
			gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Id = "";
			gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Name = "";
			gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Region_code = "";
			gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Region_code_full = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Id;
		 

		protected string gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Name;
		 

		protected string gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Region_code;
		 

		protected string gxTv_SdtSDTSuggestMapBox_suggestions_context_region_Region_code_full;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTSuggestMapBox.suggestions.context.region", Namespace="AlmangoX")]
	public class SdtSDTSuggestMapBox_suggestions_context_region_RESTInterface : GxGenericCollectionItem<SdtSDTSuggestMapBox_suggestions_context_region>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTSuggestMapBox_suggestions_context_region_RESTInterface( ) : base()
		{	
		}

		public SdtSDTSuggestMapBox_suggestions_context_region_RESTInterface( SdtSDTSuggestMapBox_suggestions_context_region psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Id);

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="name", Order=1)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="region_code", Order=2)]
		public  string gxTpr_Region_code
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Region_code);

			}
			set { 
				 sdt.gxTpr_Region_code = value;
			}
		}

		[DataMember(Name="region_code_full", Order=3)]
		public  string gxTpr_Region_code_full
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Region_code_full);

			}
			set { 
				 sdt.gxTpr_Region_code_full = value;
			}
		}


		#endregion
		public SdtSDTSuggestMapBox_suggestions_context_region sdt
		{
			get { 
				return (SdtSDTSuggestMapBox_suggestions_context_region)Sdt;
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
				sdt = new SdtSDTSuggestMapBox_suggestions_context_region() ;
			}
		}
	}
	#endregion
}