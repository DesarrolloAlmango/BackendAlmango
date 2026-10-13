/*
				   File: type_SdtSDTSuggestMapBox_suggestions_metadata
			Description: metadata
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
	[XmlRoot(ElementName="SDTSuggestMapBox.suggestions.metadata")]
	[XmlType(TypeName="SDTSuggestMapBox.suggestions.metadata" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTSuggestMapBox_suggestions_metadata : GxUserType
	{
		public SdtSDTSuggestMapBox_suggestions_metadata( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTSuggestMapBox_suggestions_metadata(IGxContext context)
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
			return;
		}
		#endregion

		#region Properties

		public override bool ShouldSerializeSdtJson()
		{
			return (
		 
				false);
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


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTSuggestMapBox.suggestions.metadata", Namespace="AlmangoX")]
	public class SdtSDTSuggestMapBox_suggestions_metadata_RESTInterface : GxGenericCollectionItem<SdtSDTSuggestMapBox_suggestions_metadata>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTSuggestMapBox_suggestions_metadata_RESTInterface( ) : base()
		{	
		}

		public SdtSDTSuggestMapBox_suggestions_metadata_RESTInterface( SdtSDTSuggestMapBox_suggestions_metadata psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		#endregion
		public SdtSDTSuggestMapBox_suggestions_metadata sdt
		{
			get { 
				return (SdtSDTSuggestMapBox_suggestions_metadata)Sdt;
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
				sdt = new SdtSDTSuggestMapBox_suggestions_metadata() ;
			}
		}
	}
	#endregion
}