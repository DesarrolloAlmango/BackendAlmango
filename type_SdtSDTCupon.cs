/*
				   File: type_SdtSDTCupon
			Description: SDTCupon
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
	[XmlRoot(ElementName="SDTCupon")]
	[XmlType(TypeName="SDTCupon" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTCupon : GxUserType
	{
		public SdtSDTCupon( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTCupon(IGxContext context)
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
			AddObjectProperty("CuponId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Cuponid, 18, 0)), false);


			AddObjectProperty("CuponPercent", gxTpr_Cuponpercent, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Cuponfechavence)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Cuponfechavence)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Cuponfechavence)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("CuponFechaVence", sDateCnv, false);



			AddObjectProperty("CuponUsado", gxTpr_Cuponusado, false);


			AddObjectProperty("CuponUser", gxTpr_Cuponuser, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CuponId")]
		[XmlElement(ElementName="CuponId")]
		public long gxTpr_Cuponid
		{
			get {
				return gxTv_SdtSDTCupon_Cuponid; 
			}
			set {
				gxTv_SdtSDTCupon_Cuponid = value;
				SetDirty("Cuponid");
			}
		}




		[SoapElement(ElementName="CuponPercent")]
		[XmlElement(ElementName="CuponPercent")]
		public short gxTpr_Cuponpercent
		{
			get {
				return gxTv_SdtSDTCupon_Cuponpercent; 
			}
			set {
				gxTv_SdtSDTCupon_Cuponpercent = value;
				SetDirty("Cuponpercent");
			}
		}



		[SoapElement(ElementName="CuponFechaVence")]
		[XmlElement(ElementName="CuponFechaVence" , IsNullable=true)]
		public string gxTpr_Cuponfechavence_Nullable
		{
			get {
				if ( gxTv_SdtSDTCupon_Cuponfechavence == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTCupon_Cuponfechavence).value ;
			}
			set {
				gxTv_SdtSDTCupon_Cuponfechavence = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Cuponfechavence
		{
			get {
				return gxTv_SdtSDTCupon_Cuponfechavence; 
			}
			set {
				gxTv_SdtSDTCupon_Cuponfechavence = value;
				SetDirty("Cuponfechavence");
			}
		}



		[SoapElement(ElementName="CuponUsado")]
		[XmlElement(ElementName="CuponUsado")]
		public bool gxTpr_Cuponusado
		{
			get {
				return gxTv_SdtSDTCupon_Cuponusado; 
			}
			set {
				gxTv_SdtSDTCupon_Cuponusado = value;
				SetDirty("Cuponusado");
			}
		}




		[SoapElement(ElementName="CuponUser")]
		[XmlElement(ElementName="CuponUser")]
		public long gxTpr_Cuponuser
		{
			get {
				return gxTv_SdtSDTCupon_Cuponuser; 
			}
			set {
				gxTv_SdtSDTCupon_Cuponuser = value;
				SetDirty("Cuponuser");
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
			gxTv_SdtSDTCupon_Cuponid = 1234;




			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected long gxTv_SdtSDTCupon_Cuponid;
		 

		protected short gxTv_SdtSDTCupon_Cuponpercent;
		 

		protected DateTime gxTv_SdtSDTCupon_Cuponfechavence;
		 

		protected bool gxTv_SdtSDTCupon_Cuponusado;
		 

		protected long gxTv_SdtSDTCupon_Cuponuser;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTCupon", Namespace="AlmangoX")]
	public class SdtSDTCupon_RESTInterface : GxGenericCollectionItem<SdtSDTCupon>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCupon_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCupon_RESTInterface( SdtSDTCupon psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CuponId", Order=0)]
		public  string gxTpr_Cuponid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Cuponid, 18, 0));

			}
			set { 
				sdt.gxTpr_Cuponid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="CuponPercent", Order=1)]
		public short gxTpr_Cuponpercent
		{
			get { 
				return sdt.gxTpr_Cuponpercent;

			}
			set { 
				sdt.gxTpr_Cuponpercent = value;
			}
		}

		[DataMember(Name="CuponFechaVence", Order=2)]
		public  string gxTpr_Cuponfechavence
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Cuponfechavence);

			}
			set { 
				sdt.gxTpr_Cuponfechavence = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="CuponUsado", Order=3)]
		public bool gxTpr_Cuponusado
		{
			get { 
				return sdt.gxTpr_Cuponusado;

			}
			set { 
				sdt.gxTpr_Cuponusado = value;
			}
		}

		[DataMember(Name="CuponUser", Order=4)]
		public  string gxTpr_Cuponuser
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Cuponuser, 10, 0));

			}
			set { 
				sdt.gxTpr_Cuponuser = (long) NumberUtil.Val( value, ".");
			}
		}


		#endregion
		public SdtSDTCupon sdt
		{
			get { 
				return (SdtSDTCupon)Sdt;
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
				sdt = new SdtSDTCupon() ;
			}
		}
	}
	#endregion
}