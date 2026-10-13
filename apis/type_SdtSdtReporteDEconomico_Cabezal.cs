/*
				   File: type_SdtSdtReporteDEconomico_Cabezal
			Description: Cabezal
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
	[XmlRoot(ElementName="SdtReporteDEconomico.Cabezal")]
	[XmlType(TypeName="SdtReporteDEconomico.Cabezal" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSdtReporteDEconomico_Cabezal : GxUserType
	{
		public SdtSdtReporteDEconomico_Cabezal( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdtReporteDEconomico_Cabezal_Rangofechas = "";


		}

		public SdtSdtReporteDEconomico_Cabezal(IGxContext context)
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
			AddObjectProperty("RangoFechas", gxTpr_Rangofechas, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Fechareporte)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Fechareporte)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Fechareporte)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("FechaReporte", sDateCnv, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="RangoFechas")]
		[XmlElement(ElementName="RangoFechas")]
		public string gxTpr_Rangofechas
		{
			get {
				return gxTv_SdtSdtReporteDEconomico_Cabezal_Rangofechas; 
			}
			set {
				gxTv_SdtSdtReporteDEconomico_Cabezal_Rangofechas = value;
				SetDirty("Rangofechas");
			}
		}



		[SoapElement(ElementName="FechaReporte")]
		[XmlElement(ElementName="FechaReporte" , IsNullable=true)]
		public string gxTpr_Fechareporte_Nullable
		{
			get {
				if ( gxTv_SdtSdtReporteDEconomico_Cabezal_Fechareporte == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSdtReporteDEconomico_Cabezal_Fechareporte).value ;
			}
			set {
				gxTv_SdtSdtReporteDEconomico_Cabezal_Fechareporte = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Fechareporte
		{
			get {
				return gxTv_SdtSdtReporteDEconomico_Cabezal_Fechareporte; 
			}
			set {
				gxTv_SdtSdtReporteDEconomico_Cabezal_Fechareporte = value;
				SetDirty("Fechareporte");
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
			gxTv_SdtSdtReporteDEconomico_Cabezal_Rangofechas = "";

			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtSdtReporteDEconomico_Cabezal_Rangofechas;
		 

		protected DateTime gxTv_SdtSdtReporteDEconomico_Cabezal_Fechareporte;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdtReporteDEconomico.Cabezal", Namespace="AlmangoX")]
	public class SdtSdtReporteDEconomico_Cabezal_RESTInterface : GxGenericCollectionItem<SdtSdtReporteDEconomico_Cabezal>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdtReporteDEconomico_Cabezal_RESTInterface( ) : base()
		{	
		}

		public SdtSdtReporteDEconomico_Cabezal_RESTInterface( SdtSdtReporteDEconomico_Cabezal psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="RangoFechas", Order=0)]
		public  string gxTpr_Rangofechas
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Rangofechas);

			}
			set { 
				 sdt.gxTpr_Rangofechas = value;
			}
		}

		[DataMember(Name="FechaReporte", Order=1)]
		public  string gxTpr_Fechareporte
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Fechareporte);

			}
			set { 
				sdt.gxTpr_Fechareporte = DateTimeUtil.CToD2(value);
			}
		}


		#endregion
		public SdtSdtReporteDEconomico_Cabezal sdt
		{
			get { 
				return (SdtSdtReporteDEconomico_Cabezal)Sdt;
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
				sdt = new SdtSdtReporteDEconomico_Cabezal() ;
			}
		}
	}
	#endregion
}