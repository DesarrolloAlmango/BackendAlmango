/*
				   File: type_SdtSDTConexiones_Item
			Description: Datos
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
	[XmlRoot(ElementName="SDTConexiones.Item")]
	[XmlType(TypeName="SDTConexiones.Item" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTConexiones_Item : GxUserType
	{
		public SdtSDTConexiones_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTConexiones_Item_Conexionesdatosid = "";

			gxTv_SdtSDTConexiones_Item_Conexionesdatosint = "";

			gxTv_SdtSDTConexiones_Item_Conexionesdatosext = "";

			gxTv_SdtSDTConexiones_Item_Conexionesdatosdetalle = "";

		}

		public SdtSDTConexiones_Item(IGxContext context)
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
			AddObjectProperty("ConexionesDatosId", gxTpr_Conexionesdatosid, false);


			AddObjectProperty("ConexionesDatosInt", gxTpr_Conexionesdatosint, false);


			AddObjectProperty("ConexionesDatosExt", gxTpr_Conexionesdatosext, false);


			AddObjectProperty("ConexionesDatosDetalle", gxTpr_Conexionesdatosdetalle, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ConexionesDatosId")]
		[XmlElement(ElementName="ConexionesDatosId")]
		public string gxTpr_Conexionesdatosid
		{
			get {
				return gxTv_SdtSDTConexiones_Item_Conexionesdatosid; 
			}
			set {
				gxTv_SdtSDTConexiones_Item_Conexionesdatosid = value;
				SetDirty("Conexionesdatosid");
			}
		}




		[SoapElement(ElementName="ConexionesDatosInt")]
		[XmlElement(ElementName="ConexionesDatosInt")]
		public string gxTpr_Conexionesdatosint
		{
			get {
				return gxTv_SdtSDTConexiones_Item_Conexionesdatosint; 
			}
			set {
				gxTv_SdtSDTConexiones_Item_Conexionesdatosint = value;
				SetDirty("Conexionesdatosint");
			}
		}




		[SoapElement(ElementName="ConexionesDatosExt")]
		[XmlElement(ElementName="ConexionesDatosExt")]
		public string gxTpr_Conexionesdatosext
		{
			get {
				return gxTv_SdtSDTConexiones_Item_Conexionesdatosext; 
			}
			set {
				gxTv_SdtSDTConexiones_Item_Conexionesdatosext = value;
				SetDirty("Conexionesdatosext");
			}
		}




		[SoapElement(ElementName="ConexionesDatosDetalle")]
		[XmlElement(ElementName="ConexionesDatosDetalle")]
		public string gxTpr_Conexionesdatosdetalle
		{
			get {
				return gxTv_SdtSDTConexiones_Item_Conexionesdatosdetalle; 
			}
			set {
				gxTv_SdtSDTConexiones_Item_Conexionesdatosdetalle = value;
				SetDirty("Conexionesdatosdetalle");
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
			gxTv_SdtSDTConexiones_Item_Conexionesdatosid = "";
			gxTv_SdtSDTConexiones_Item_Conexionesdatosint = "";
			gxTv_SdtSDTConexiones_Item_Conexionesdatosext = "";
			gxTv_SdtSDTConexiones_Item_Conexionesdatosdetalle = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTConexiones_Item_Conexionesdatosid;
		 

		protected string gxTv_SdtSDTConexiones_Item_Conexionesdatosint;
		 

		protected string gxTv_SdtSDTConexiones_Item_Conexionesdatosext;
		 

		protected string gxTv_SdtSDTConexiones_Item_Conexionesdatosdetalle;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTConexiones.Item", Namespace="AlmangoX")]
	public class SdtSDTConexiones_Item_RESTInterface : GxGenericCollectionItem<SdtSDTConexiones_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTConexiones_Item_RESTInterface( ) : base()
		{	
		}

		public SdtSDTConexiones_Item_RESTInterface( SdtSDTConexiones_Item psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ConexionesDatosId", Order=0)]
		public  string gxTpr_Conexionesdatosid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Conexionesdatosid);

			}
			set { 
				 sdt.gxTpr_Conexionesdatosid = value;
			}
		}

		[DataMember(Name="ConexionesDatosInt", Order=1)]
		public  string gxTpr_Conexionesdatosint
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Conexionesdatosint);

			}
			set { 
				 sdt.gxTpr_Conexionesdatosint = value;
			}
		}

		[DataMember(Name="ConexionesDatosExt", Order=2)]
		public  string gxTpr_Conexionesdatosext
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Conexionesdatosext);

			}
			set { 
				 sdt.gxTpr_Conexionesdatosext = value;
			}
		}

		[DataMember(Name="ConexionesDatosDetalle", Order=3)]
		public  string gxTpr_Conexionesdatosdetalle
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Conexionesdatosdetalle);

			}
			set { 
				 sdt.gxTpr_Conexionesdatosdetalle = value;
			}
		}


		#endregion
		public SdtSDTConexiones_Item sdt
		{
			get { 
				return (SdtSDTConexiones_Item)Sdt;
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
				sdt = new SdtSDTConexiones_Item() ;
			}
		}
	}
	#endregion
}