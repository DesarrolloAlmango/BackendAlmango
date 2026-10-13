/*
				   File: type_SdtSDTCantSolRubro
			Description: SDTCantSolRubro
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
	[XmlRoot(ElementName="SDTCantSolRubro")]
	[XmlType(TypeName="SDTCantSolRubro" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTCantSolRubro : GxUserType
	{
		public SdtSDTCantSolRubro( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCantSolRubro_Rubrosnombre = "";

		}

		public SdtSDTCantSolRubro(IGxContext context)
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
			AddObjectProperty("Cantidad", gxTpr_Cantidad, false);


			AddObjectProperty("RubrosId", gxTpr_Rubrosid, false);


			AddObjectProperty("RubrosNombre", gxTpr_Rubrosnombre, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Cantidad")]
		[XmlElement(ElementName="Cantidad")]
		public int gxTpr_Cantidad
		{
			get {
				return gxTv_SdtSDTCantSolRubro_Cantidad; 
			}
			set {
				gxTv_SdtSDTCantSolRubro_Cantidad = value;
				SetDirty("Cantidad");
			}
		}




		[SoapElement(ElementName="RubrosId")]
		[XmlElement(ElementName="RubrosId")]
		public short gxTpr_Rubrosid
		{
			get {
				return gxTv_SdtSDTCantSolRubro_Rubrosid; 
			}
			set {
				gxTv_SdtSDTCantSolRubro_Rubrosid = value;
				SetDirty("Rubrosid");
			}
		}




		[SoapElement(ElementName="RubrosNombre")]
		[XmlElement(ElementName="RubrosNombre")]
		public string gxTpr_Rubrosnombre
		{
			get {
				return gxTv_SdtSDTCantSolRubro_Rubrosnombre; 
			}
			set {
				gxTv_SdtSDTCantSolRubro_Rubrosnombre = value;
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
			gxTv_SdtSDTCantSolRubro_Rubrosnombre = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTCantSolRubro_Cantidad;
		 

		protected short gxTv_SdtSDTCantSolRubro_Rubrosid;
		 

		protected string gxTv_SdtSDTCantSolRubro_Rubrosnombre;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTCantSolRubro", Namespace="AlmangoX")]
	public class SdtSDTCantSolRubro_RESTInterface : GxGenericCollectionItem<SdtSDTCantSolRubro>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCantSolRubro_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCantSolRubro_RESTInterface( SdtSDTCantSolRubro psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Cantidad", Order=0)]
		public int gxTpr_Cantidad
		{
			get { 
				return sdt.gxTpr_Cantidad;

			}
			set { 
				sdt.gxTpr_Cantidad = value;
			}
		}

		[DataMember(Name="RubrosId", Order=1)]
		public short gxTpr_Rubrosid
		{
			get { 
				return sdt.gxTpr_Rubrosid;

			}
			set { 
				sdt.gxTpr_Rubrosid = value;
			}
		}

		[DataMember(Name="RubrosNombre", Order=2)]
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
		public SdtSDTCantSolRubro sdt
		{
			get { 
				return (SdtSDTCantSolRubro)Sdt;
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
				sdt = new SdtSDTCantSolRubro() ;
			}
		}
	}
	#endregion
}