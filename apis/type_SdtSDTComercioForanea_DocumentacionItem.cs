/*
				   File: type_SdtSDTComercioForanea_DocumentacionItem
			Description: Documentacion
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
	[XmlRoot(ElementName="SDTComercioForanea.DocumentacionItem")]
	[XmlType(TypeName="SDTComercioForanea.DocumentacionItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTComercioForanea_DocumentacionItem : GxUserType
	{
		public SdtSDTComercioForanea_DocumentacionItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTComercioForanea_DocumentacionItem_Documentacionicono = "";
			gxTv_SdtSDTComercioForanea_DocumentacionItem_Documentacionicono_gxi = "";

		}

		public SdtSDTComercioForanea_DocumentacionItem(IGxContext context)
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
			AddObjectProperty("DocumentacionId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Documentacionid, 18, 0)), false);


			AddObjectProperty("DocumentacionIcono", gxTpr_Documentacionicono, false);
			AddObjectProperty("DocumentacionIcono_GXI", gxTpr_Documentacionicono_gxi, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DocumentacionId")]
		[XmlElement(ElementName="DocumentacionId")]
		public long gxTpr_Documentacionid
		{
			get {
				return gxTv_SdtSDTComercioForanea_DocumentacionItem_Documentacionid; 
			}
			set {
				gxTv_SdtSDTComercioForanea_DocumentacionItem_Documentacionid = value;
				SetDirty("Documentacionid");
			}
		}




		[SoapElement(ElementName="DocumentacionIcono")]
		[XmlElement(ElementName="DocumentacionIcono")]
		[GxUpload()]

		public string gxTpr_Documentacionicono
		{
			get {
				return gxTv_SdtSDTComercioForanea_DocumentacionItem_Documentacionicono; 
			}
			set {
				gxTv_SdtSDTComercioForanea_DocumentacionItem_Documentacionicono = value;
				SetDirty("Documentacionicono");
			}
		}


		[SoapElement(ElementName="DocumentacionIcono_GXI" )]
		[XmlElement(ElementName="DocumentacionIcono_GXI" )]
		public string gxTpr_Documentacionicono_gxi
		{
			get {
				return gxTv_SdtSDTComercioForanea_DocumentacionItem_Documentacionicono_gxi ;
			}
			set {
				gxTv_SdtSDTComercioForanea_DocumentacionItem_Documentacionicono_gxi = value;
				SetDirty("Documentacionicono_gxi");
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
			gxTv_SdtSDTComercioForanea_DocumentacionItem_Documentacionicono = "";gxTv_SdtSDTComercioForanea_DocumentacionItem_Documentacionicono_gxi = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTComercioForanea_DocumentacionItem_Documentacionid;
		 
		protected string gxTv_SdtSDTComercioForanea_DocumentacionItem_Documentacionicono_gxi;
		protected string gxTv_SdtSDTComercioForanea_DocumentacionItem_Documentacionicono;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTComercioForanea.DocumentacionItem", Namespace="AlmangoX")]
	public class SdtSDTComercioForanea_DocumentacionItem_RESTInterface : GxGenericCollectionItem<SdtSDTComercioForanea_DocumentacionItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTComercioForanea_DocumentacionItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTComercioForanea_DocumentacionItem_RESTInterface( SdtSDTComercioForanea_DocumentacionItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="DocumentacionId", Order=0)]
		public  string gxTpr_Documentacionid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Documentacionid, 18, 0));

			}
			set { 
				sdt.gxTpr_Documentacionid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DocumentacionIcono", Order=1)]
		[GxUpload()]
		public  string gxTpr_Documentacionicono
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Documentacionicono)) ? PathUtil.RelativePath( sdt.gxTpr_Documentacionicono) : StringUtil.RTrim( sdt.gxTpr_Documentacionicono_gxi));

			}
			set { 
				 sdt.gxTpr_Documentacionicono = value;
			}
		}


		#endregion
		public SdtSDTComercioForanea_DocumentacionItem sdt
		{
			get { 
				return (SdtSDTComercioForanea_DocumentacionItem)Sdt;
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
				sdt = new SdtSDTComercioForanea_DocumentacionItem() ;
			}
		}
	}
	#endregion
}