/*
				   File: type_SdtSDTSuggestMapBox_suggestions_context_street
			Description: street
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
	[XmlRoot(ElementName="SDTSuggestMapBox.suggestions.context.street")]
	[XmlType(TypeName="SDTSuggestMapBox.suggestions.context.street" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTSuggestMapBox_suggestions_context_street : GxUserType
	{
		public SdtSDTSuggestMapBox_suggestions_context_street( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTSuggestMapBox_suggestions_context_street_Id = "";

			gxTv_SdtSDTSuggestMapBox_suggestions_context_street_Name = "";

		}

		public SdtSDTSuggestMapBox_suggestions_context_street(IGxContext context)
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

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtSDTSuggestMapBox_suggestions_context_street_Id; 
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_context_street_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDTSuggestMapBox_suggestions_context_street_Name; 
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_context_street_Name = value;
				SetDirty("Name");
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
			gxTv_SdtSDTSuggestMapBox_suggestions_context_street_Id = "";
			gxTv_SdtSDTSuggestMapBox_suggestions_context_street_Name = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTSuggestMapBox_suggestions_context_street_Id;
		 

		protected string gxTv_SdtSDTSuggestMapBox_suggestions_context_street_Name;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTSuggestMapBox.suggestions.context.street", Namespace="AlmangoX")]
	public class SdtSDTSuggestMapBox_suggestions_context_street_RESTInterface : GxGenericCollectionItem<SdtSDTSuggestMapBox_suggestions_context_street>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTSuggestMapBox_suggestions_context_street_RESTInterface( ) : base()
		{	
		}

		public SdtSDTSuggestMapBox_suggestions_context_street_RESTInterface( SdtSDTSuggestMapBox_suggestions_context_street psdt ) : base(psdt)
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


		#endregion
		public SdtSDTSuggestMapBox_suggestions_context_street sdt
		{
			get { 
				return (SdtSDTSuggestMapBox_suggestions_context_street)Sdt;
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
				sdt = new SdtSDTSuggestMapBox_suggestions_context_street() ;
			}
		}
	}
	#endregion
}