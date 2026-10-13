/*
				   File: type_SdtSDTRubros
			Description: SDTRubros
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
	[XmlRoot(ElementName="SDTRubros")]
	[XmlType(TypeName="SDTRubros" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTRubros : GxUserType
	{
		public SdtSDTRubros( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTRubros_Rubrosnombre = "";

		}

		public SdtSDTRubros(IGxContext context)
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
			AddObjectProperty("RubrosId", gxTpr_Rubrosid, false);


			AddObjectProperty("RubrosNombre", gxTpr_Rubrosnombre, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="RubrosId")]
		[XmlElement(ElementName="RubrosId")]
		public short gxTpr_Rubrosid
		{
			get {
				return gxTv_SdtSDTRubros_Rubrosid; 
			}
			set {
				gxTv_SdtSDTRubros_Rubrosid = value;
				SetDirty("Rubrosid");
			}
		}




		[SoapElement(ElementName="RubrosNombre")]
		[XmlElement(ElementName="RubrosNombre")]
		public string gxTpr_Rubrosnombre
		{
			get {
				return gxTv_SdtSDTRubros_Rubrosnombre; 
			}
			set {
				gxTv_SdtSDTRubros_Rubrosnombre = value;
				SetDirty("Rubrosnombre");
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
			gxTv_SdtSDTRubros_Rubrosnombre = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTRubros_Rubrosid;
		 

		protected string gxTv_SdtSDTRubros_Rubrosnombre;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTRubros", Namespace="AlmangoX")]
	public class SdtSDTRubros_RESTInterface : GxGenericCollectionItem<SdtSDTRubros>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRubros_RESTInterface( ) : base()
		{	
		}

		public SdtSDTRubros_RESTInterface( SdtSDTRubros psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="RubrosId", Order=0)]
		public short gxTpr_Rubrosid
		{
			get { 
				return sdt.gxTpr_Rubrosid;

			}
			set { 
				sdt.gxTpr_Rubrosid = value;
			}
		}

		[DataMember(Name="RubrosNombre", Order=1)]
		public  string gxTpr_Rubrosnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Rubrosnombre);

			}
			set { 
				 sdt.gxTpr_Rubrosnombre = value;
			}
		}


		#endregion
		public SdtSDTRubros sdt
		{
			get { 
				return (SdtSDTRubros)Sdt;
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
				sdt = new SdtSDTRubros() ;
			}
		}
	}
	#endregion
}