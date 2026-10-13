/*
				   File: type_SdtSDTPais
			Description: SDTPais
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
	[XmlRoot(ElementName="SDTPais")]
	[XmlType(TypeName="SDTPais" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTPais : GxUserType
	{
		public SdtSDTPais( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTPais_Paisid = "";

			gxTv_SdtSDTPais_Paisnombre = "";

		}

		public SdtSDTPais(IGxContext context)
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
			AddObjectProperty("PaisId", gxTpr_Paisid, false);


			AddObjectProperty("PaisNombre", gxTpr_Paisnombre, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PaisId")]
		[XmlElement(ElementName="PaisId")]
		public string gxTpr_Paisid
		{
			get {
				return gxTv_SdtSDTPais_Paisid; 
			}
			set {
				gxTv_SdtSDTPais_Paisid = value;
				SetDirty("Paisid");
			}
		}




		[SoapElement(ElementName="PaisNombre")]
		[XmlElement(ElementName="PaisNombre")]
		public string gxTpr_Paisnombre
		{
			get {
				return gxTv_SdtSDTPais_Paisnombre; 
			}
			set {
				gxTv_SdtSDTPais_Paisnombre = value;
				SetDirty("Paisnombre");
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
			gxTv_SdtSDTPais_Paisid = "";
			gxTv_SdtSDTPais_Paisnombre = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTPais_Paisid;
		 

		protected string gxTv_SdtSDTPais_Paisnombre;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTPais", Namespace="AlmangoX")]
	public class SdtSDTPais_RESTInterface : GxGenericCollectionItem<SdtSDTPais>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTPais_RESTInterface( ) : base()
		{	
		}

		public SdtSDTPais_RESTInterface( SdtSDTPais psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PaisId", Order=0)]
		public  string gxTpr_Paisid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Paisid);

			}
			set { 
				 sdt.gxTpr_Paisid = value;
			}
		}

		[DataMember(Name="PaisNombre", Order=1)]
		public  string gxTpr_Paisnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Paisnombre);

			}
			set { 
				 sdt.gxTpr_Paisnombre = value;
			}
		}


		#endregion
		public SdtSDTPais sdt
		{
			get { 
				return (SdtSDTPais)Sdt;
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
				sdt = new SdtSDTPais() ;
			}
		}
	}
	#endregion
}