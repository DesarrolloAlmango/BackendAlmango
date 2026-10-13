/*
				   File: type_SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem
			Description: SDTDiasLimiteSaturado
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
	[XmlRoot(ElementName="SDTDiasLimiteSaturadoItem")]
	[XmlType(TypeName="SDTDiasLimiteSaturadoItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem : GxUserType
	{
		public SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_Diastipo = "";


		}

		public SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem(IGxContext context)
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
			AddObjectProperty("DiasTipo", gxTpr_Diastipo, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Dia)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Dia)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Dia)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("Dia", sDateCnv, false);



			AddObjectProperty("ServiciosPorDia", gxTpr_Serviciospordia, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DiasTipo")]
		[XmlElement(ElementName="DiasTipo")]
		public string gxTpr_Diastipo
		{
			get {
				return gxTv_SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_Diastipo; 
			}
			set {
				gxTv_SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_Diastipo = value;
				SetDirty("Diastipo");
			}
		}



		[SoapElement(ElementName="Dia")]
		[XmlElement(ElementName="Dia" , IsNullable=true)]
		public string gxTpr_Dia_Nullable
		{
			get {
				if ( gxTv_SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_Dia == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_Dia).value ;
			}
			set {
				gxTv_SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_Dia = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Dia
		{
			get {
				return gxTv_SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_Dia; 
			}
			set {
				gxTv_SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_Dia = value;
				SetDirty("Dia");
			}
		}



		[SoapElement(ElementName="ServiciosPorDia")]
		[XmlElement(ElementName="ServiciosPorDia")]
		public short gxTpr_Serviciospordia
		{
			get {
				return gxTv_SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_Serviciospordia; 
			}
			set {
				gxTv_SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_Serviciospordia = value;
				SetDirty("Serviciospordia");
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
			gxTv_SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_Diastipo = "";


			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_Diastipo;
		 

		protected DateTime gxTv_SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_Dia;
		 

		protected short gxTv_SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_Serviciospordia;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTDiasLimiteSaturadoItem", Namespace="AlmangoX")]
	public class SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_RESTInterface : GxGenericCollectionItem<SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem_RESTInterface( SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="DiasTipo", Order=0)]
		public  string gxTpr_Diastipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Diastipo);

			}
			set { 
				 sdt.gxTpr_Diastipo = value;
			}
		}

		[DataMember(Name="Dia", Order=1)]
		public  string gxTpr_Dia
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Dia);

			}
			set { 
				sdt.gxTpr_Dia = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="ServiciosPorDia", Order=2)]
		public short gxTpr_Serviciospordia
		{
			get { 
				return sdt.gxTpr_Serviciospordia;

			}
			set { 
				sdt.gxTpr_Serviciospordia = value;
			}
		}


		#endregion
		public SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem sdt
		{
			get { 
				return (SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem)Sdt;
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
				sdt = new SdtSDTDiasLimiteSaturado_SDTDiasLimiteSaturadoItem() ;
			}
		}
	}
	#endregion
}