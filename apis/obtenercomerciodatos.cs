using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis {
   public class obtenercomerciodatos : GXProcedure
   {
      public obtenercomerciodatos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenercomerciodatos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorId ,
                           out string aP1_ComercioDatos )
      {
         this.AV8ProveedorId = aP0_ProveedorId;
         this.AV9ComercioDatos = "" ;
         initialize();
         ExecutePrivate();
         aP1_ComercioDatos=this.AV9ComercioDatos;
      }

      public string executeUdp( long aP0_ProveedorId )
      {
         execute(aP0_ProveedorId, out aP1_ComercioDatos);
         return AV9ComercioDatos ;
      }

      public void executeSubmit( long aP0_ProveedorId ,
                                 out string aP1_ComercioDatos )
      {
         this.AV8ProveedorId = aP0_ProveedorId;
         this.AV9ComercioDatos = "" ;
         SubmitImpl();
         aP1_ComercioDatos=this.AV9ComercioDatos;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00HQ2 */
         pr_default.execute(0, new Object[] {AV8ProveedorId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133ProveedorID = P00HQ2_A133ProveedorID[0];
            A40000ProveedorImagen_GXI = P00HQ2_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = P00HQ2_n40000ProveedorImagen_GXI[0];
            A40001DocumentacionIcono_GXI = P00HQ2_A40001DocumentacionIcono_GXI[0];
            A151ProveedoresTipoId = P00HQ2_A151ProveedoresTipoId[0];
            A282ProveedorNombre = P00HQ2_A282ProveedorNombre[0];
            A682ProveedorRazonSocial = P00HQ2_A682ProveedorRazonSocial[0];
            n682ProveedorRazonSocial = P00HQ2_n682ProveedorRazonSocial[0];
            A683ProveedorContacto = P00HQ2_A683ProveedorContacto[0];
            n683ProveedorContacto = P00HQ2_n683ProveedorContacto[0];
            A684ProveedorContactoCell = P00HQ2_A684ProveedorContactoCell[0];
            n684ProveedorContactoCell = P00HQ2_n684ProveedorContactoCell[0];
            A338ProveedorDocIdentidad = P00HQ2_A338ProveedorDocIdentidad[0];
            A345ProveedorSerialComi = P00HQ2_A345ProveedorSerialComi[0];
            A430ProveedorTelefono = P00HQ2_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P00HQ2_n430ProveedorTelefono[0];
            A431ProveedorDireccion = P00HQ2_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P00HQ2_n431ProveedorDireccion[0];
            A433ProveedorEmail = P00HQ2_A433ProveedorEmail[0];
            n433ProveedorEmail = P00HQ2_n433ProveedorEmail[0];
            A685ProveedorSitioWeb = P00HQ2_A685ProveedorSitioWeb[0];
            n685ProveedorSitioWeb = P00HQ2_n685ProveedorSitioWeb[0];
            A686ProveedorAceptoTerminos = P00HQ2_A686ProveedorAceptoTerminos[0];
            n686ProveedorAceptoTerminos = P00HQ2_n686ProveedorAceptoTerminos[0];
            A437ProveedorPerAltShop = P00HQ2_A437ProveedorPerAltShop[0];
            n437ProveedorPerAltShop = P00HQ2_n437ProveedorPerAltShop[0];
            A344ProveedorEstado = P00HQ2_A344ProveedorEstado[0];
            A440ProveedorPagoDefault = P00HQ2_A440ProveedorPagoDefault[0];
            A490ProveedorPideDoc = P00HQ2_A490ProveedorPideDoc[0];
            n490ProveedorPideDoc = P00HQ2_n490ProveedorPideDoc[0];
            A488DocumentacionId = P00HQ2_A488DocumentacionId[0];
            n488DocumentacionId = P00HQ2_n488DocumentacionId[0];
            A546ProveedorUsrAlta = P00HQ2_A546ProveedorUsrAlta[0];
            n546ProveedorUsrAlta = P00HQ2_n546ProveedorUsrAlta[0];
            A547ProveedorUsrActualizacion = P00HQ2_A547ProveedorUsrActualizacion[0];
            n547ProveedorUsrActualizacion = P00HQ2_n547ProveedorUsrActualizacion[0];
            A548ProveedorFechaAlta = P00HQ2_A548ProveedorFechaAlta[0];
            n548ProveedorFechaAlta = P00HQ2_n548ProveedorFechaAlta[0];
            A549ProveedorFechaActualizacion = P00HQ2_A549ProveedorFechaActualizacion[0];
            n549ProveedorFechaActualizacion = P00HQ2_n549ProveedorFechaActualizacion[0];
            A601ProveedorUsoInterno = P00HQ2_A601ProveedorUsoInterno[0];
            n601ProveedorUsoInterno = P00HQ2_n601ProveedorUsoInterno[0];
            A687ProveedorCuentaBancaria = P00HQ2_A687ProveedorCuentaBancaria[0];
            n687ProveedorCuentaBancaria = P00HQ2_n687ProveedorCuentaBancaria[0];
            A673BancoId = P00HQ2_A673BancoId[0];
            n673BancoId = P00HQ2_n673BancoId[0];
            A674BancoNombre = P00HQ2_A674BancoNombre[0];
            A432ProveedorImagen = P00HQ2_A432ProveedorImagen[0];
            n432ProveedorImagen = P00HQ2_n432ProveedorImagen[0];
            A498DocumentacionIcono = P00HQ2_A498DocumentacionIcono[0];
            A40001DocumentacionIcono_GXI = P00HQ2_A40001DocumentacionIcono_GXI[0];
            A498DocumentacionIcono = P00HQ2_A498DocumentacionIcono[0];
            A674BancoNombre = P00HQ2_A674BancoNombre[0];
            AV10SDTComercioDatos.gxTpr_Proveedorestipoid = A151ProveedoresTipoId;
            AV10SDTComercioDatos.gxTpr_Proveedornombre = A282ProveedorNombre;
            AV10SDTComercioDatos.gxTpr_Proveedorrazonsocial = A682ProveedorRazonSocial;
            AV10SDTComercioDatos.gxTpr_Proveedorcontacto = A683ProveedorContacto;
            AV10SDTComercioDatos.gxTpr_Proveedorcontactocell = A684ProveedorContactoCell;
            AV10SDTComercioDatos.gxTpr_Proveedorimagen = A432ProveedorImagen;
            AV10SDTComercioDatos.gxTpr_Proveedorimagen_gxi = A40000ProveedorImagen_GXI;
            AV10SDTComercioDatos.gxTpr_Proveedordocidentidad = A338ProveedorDocIdentidad;
            AV10SDTComercioDatos.gxTpr_Proveedorserialcomi = A345ProveedorSerialComi;
            AV10SDTComercioDatos.gxTpr_Proveedortelefono = A430ProveedorTelefono;
            AV10SDTComercioDatos.gxTpr_Proveedordireccion = A431ProveedorDireccion;
            AV10SDTComercioDatos.gxTpr_Proveedoremail = A433ProveedorEmail;
            AV10SDTComercioDatos.gxTpr_Proveedorsitioweb = A685ProveedorSitioWeb;
            AV10SDTComercioDatos.gxTpr_Proveedoraceptoterminos = A686ProveedorAceptoTerminos;
            AV10SDTComercioDatos.gxTpr_Proveedorperaltshop = A437ProveedorPerAltShop;
            AV10SDTComercioDatos.gxTpr_Proveedorestado = A344ProveedorEstado;
            AV10SDTComercioDatos.gxTpr_Proveedorpagodefault = A440ProveedorPagoDefault;
            AV10SDTComercioDatos.gxTpr_Proveedorpidedoc = A490ProveedorPideDoc;
            AV10SDTComercioDatos.gxTpr_Documentacionid = A488DocumentacionId;
            AV10SDTComercioDatos.gxTpr_Documentacionicono = A498DocumentacionIcono;
            AV10SDTComercioDatos.gxTpr_Documentacionicono_gxi = A40001DocumentacionIcono_GXI;
            AV10SDTComercioDatos.gxTpr_Proveedorusralta = A546ProveedorUsrAlta;
            AV10SDTComercioDatos.gxTpr_Proveedorusractualizacion = A547ProveedorUsrActualizacion;
            AV10SDTComercioDatos.gxTpr_Proveedorfechaalta = A548ProveedorFechaAlta;
            AV10SDTComercioDatos.gxTpr_Proveedorfechaactualizacion = A549ProveedorFechaActualizacion;
            AV10SDTComercioDatos.gxTpr_Proveedorusointerno = A601ProveedorUsoInterno;
            AV10SDTComercioDatos.gxTpr_Proveedorcuentabancaria = A687ProveedorCuentaBancaria;
            AV10SDTComercioDatos.gxTpr_Bancoid = A673BancoId;
            AV10SDTComercioDatos.gxTpr_Banconombre = A674BancoNombre;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV9ComercioDatos = AV10SDTComercioDatos.ToJSonString(false, true);
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9ComercioDatos = "";
         P00HQ2_A133ProveedorID = new long[1] ;
         P00HQ2_A40000ProveedorImagen_GXI = new string[] {""} ;
         P00HQ2_n40000ProveedorImagen_GXI = new bool[] {false} ;
         P00HQ2_A40001DocumentacionIcono_GXI = new string[] {""} ;
         P00HQ2_A151ProveedoresTipoId = new long[1] ;
         P00HQ2_A282ProveedorNombre = new string[] {""} ;
         P00HQ2_A682ProveedorRazonSocial = new string[] {""} ;
         P00HQ2_n682ProveedorRazonSocial = new bool[] {false} ;
         P00HQ2_A683ProveedorContacto = new string[] {""} ;
         P00HQ2_n683ProveedorContacto = new bool[] {false} ;
         P00HQ2_A684ProveedorContactoCell = new string[] {""} ;
         P00HQ2_n684ProveedorContactoCell = new bool[] {false} ;
         P00HQ2_A338ProveedorDocIdentidad = new string[] {""} ;
         P00HQ2_A345ProveedorSerialComi = new short[1] ;
         P00HQ2_A430ProveedorTelefono = new string[] {""} ;
         P00HQ2_n430ProveedorTelefono = new bool[] {false} ;
         P00HQ2_A431ProveedorDireccion = new string[] {""} ;
         P00HQ2_n431ProveedorDireccion = new bool[] {false} ;
         P00HQ2_A433ProveedorEmail = new string[] {""} ;
         P00HQ2_n433ProveedorEmail = new bool[] {false} ;
         P00HQ2_A685ProveedorSitioWeb = new string[] {""} ;
         P00HQ2_n685ProveedorSitioWeb = new bool[] {false} ;
         P00HQ2_A686ProveedorAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         P00HQ2_n686ProveedorAceptoTerminos = new bool[] {false} ;
         P00HQ2_A437ProveedorPerAltShop = new string[] {""} ;
         P00HQ2_n437ProveedorPerAltShop = new bool[] {false} ;
         P00HQ2_A344ProveedorEstado = new string[] {""} ;
         P00HQ2_A440ProveedorPagoDefault = new string[] {""} ;
         P00HQ2_A490ProveedorPideDoc = new string[] {""} ;
         P00HQ2_n490ProveedorPideDoc = new bool[] {false} ;
         P00HQ2_A488DocumentacionId = new long[1] ;
         P00HQ2_n488DocumentacionId = new bool[] {false} ;
         P00HQ2_A546ProveedorUsrAlta = new long[1] ;
         P00HQ2_n546ProveedorUsrAlta = new bool[] {false} ;
         P00HQ2_A547ProveedorUsrActualizacion = new long[1] ;
         P00HQ2_n547ProveedorUsrActualizacion = new bool[] {false} ;
         P00HQ2_A548ProveedorFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00HQ2_n548ProveedorFechaAlta = new bool[] {false} ;
         P00HQ2_A549ProveedorFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P00HQ2_n549ProveedorFechaActualizacion = new bool[] {false} ;
         P00HQ2_A601ProveedorUsoInterno = new string[] {""} ;
         P00HQ2_n601ProveedorUsoInterno = new bool[] {false} ;
         P00HQ2_A687ProveedorCuentaBancaria = new string[] {""} ;
         P00HQ2_n687ProveedorCuentaBancaria = new bool[] {false} ;
         P00HQ2_A673BancoId = new long[1] ;
         P00HQ2_n673BancoId = new bool[] {false} ;
         P00HQ2_A674BancoNombre = new string[] {""} ;
         P00HQ2_A432ProveedorImagen = new string[] {""} ;
         P00HQ2_n432ProveedorImagen = new bool[] {false} ;
         P00HQ2_A498DocumentacionIcono = new string[] {""} ;
         A40000ProveedorImagen_GXI = "";
         A40001DocumentacionIcono_GXI = "";
         A282ProveedorNombre = "";
         A682ProveedorRazonSocial = "";
         A683ProveedorContacto = "";
         A684ProveedorContactoCell = "";
         A338ProveedorDocIdentidad = "";
         A430ProveedorTelefono = "";
         A431ProveedorDireccion = "";
         A433ProveedorEmail = "";
         A685ProveedorSitioWeb = "";
         A686ProveedorAceptoTerminos = (DateTime)(DateTime.MinValue);
         A437ProveedorPerAltShop = "";
         A344ProveedorEstado = "";
         A440ProveedorPagoDefault = "";
         A490ProveedorPideDoc = "";
         A548ProveedorFechaAlta = (DateTime)(DateTime.MinValue);
         A549ProveedorFechaActualizacion = (DateTime)(DateTime.MinValue);
         A601ProveedorUsoInterno = "";
         A687ProveedorCuentaBancaria = "";
         A674BancoNombre = "";
         A432ProveedorImagen = "";
         A498DocumentacionIcono = "";
         AV10SDTComercioDatos = new GeneXus.Programs.apis.SdtSDTComercioDatos(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.obtenercomerciodatos__default(),
            new Object[][] {
                new Object[] {
               P00HQ2_A133ProveedorID, P00HQ2_A40000ProveedorImagen_GXI, P00HQ2_n40000ProveedorImagen_GXI, P00HQ2_A40001DocumentacionIcono_GXI, P00HQ2_A151ProveedoresTipoId, P00HQ2_A282ProveedorNombre, P00HQ2_A682ProveedorRazonSocial, P00HQ2_n682ProveedorRazonSocial, P00HQ2_A683ProveedorContacto, P00HQ2_n683ProveedorContacto,
               P00HQ2_A684ProveedorContactoCell, P00HQ2_n684ProveedorContactoCell, P00HQ2_A338ProveedorDocIdentidad, P00HQ2_A345ProveedorSerialComi, P00HQ2_A430ProveedorTelefono, P00HQ2_n430ProveedorTelefono, P00HQ2_A431ProveedorDireccion, P00HQ2_n431ProveedorDireccion, P00HQ2_A433ProveedorEmail, P00HQ2_n433ProveedorEmail,
               P00HQ2_A685ProveedorSitioWeb, P00HQ2_n685ProveedorSitioWeb, P00HQ2_A686ProveedorAceptoTerminos, P00HQ2_n686ProveedorAceptoTerminos, P00HQ2_A437ProveedorPerAltShop, P00HQ2_n437ProveedorPerAltShop, P00HQ2_A344ProveedorEstado, P00HQ2_A440ProveedorPagoDefault, P00HQ2_A490ProveedorPideDoc, P00HQ2_n490ProveedorPideDoc,
               P00HQ2_A488DocumentacionId, P00HQ2_n488DocumentacionId, P00HQ2_A546ProveedorUsrAlta, P00HQ2_n546ProveedorUsrAlta, P00HQ2_A547ProveedorUsrActualizacion, P00HQ2_n547ProveedorUsrActualizacion, P00HQ2_A548ProveedorFechaAlta, P00HQ2_n548ProveedorFechaAlta, P00HQ2_A549ProveedorFechaActualizacion, P00HQ2_n549ProveedorFechaActualizacion,
               P00HQ2_A601ProveedorUsoInterno, P00HQ2_n601ProveedorUsoInterno, P00HQ2_A687ProveedorCuentaBancaria, P00HQ2_n687ProveedorCuentaBancaria, P00HQ2_A673BancoId, P00HQ2_n673BancoId, P00HQ2_A674BancoNombre, P00HQ2_A432ProveedorImagen, P00HQ2_n432ProveedorImagen, P00HQ2_A498DocumentacionIcono
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A345ProveedorSerialComi ;
      private long AV8ProveedorId ;
      private long A133ProveedorID ;
      private long A151ProveedoresTipoId ;
      private long A488DocumentacionId ;
      private long A546ProveedorUsrAlta ;
      private long A547ProveedorUsrActualizacion ;
      private long A673BancoId ;
      private string A282ProveedorNombre ;
      private string A682ProveedorRazonSocial ;
      private string A683ProveedorContacto ;
      private string A684ProveedorContactoCell ;
      private string A338ProveedorDocIdentidad ;
      private string A430ProveedorTelefono ;
      private string A685ProveedorSitioWeb ;
      private string A437ProveedorPerAltShop ;
      private string A344ProveedorEstado ;
      private string A440ProveedorPagoDefault ;
      private string A490ProveedorPideDoc ;
      private string A601ProveedorUsoInterno ;
      private string A687ProveedorCuentaBancaria ;
      private string A674BancoNombre ;
      private DateTime A686ProveedorAceptoTerminos ;
      private DateTime A548ProveedorFechaAlta ;
      private DateTime A549ProveedorFechaActualizacion ;
      private bool n40000ProveedorImagen_GXI ;
      private bool n682ProveedorRazonSocial ;
      private bool n683ProveedorContacto ;
      private bool n684ProveedorContactoCell ;
      private bool n430ProveedorTelefono ;
      private bool n431ProveedorDireccion ;
      private bool n433ProveedorEmail ;
      private bool n685ProveedorSitioWeb ;
      private bool n686ProveedorAceptoTerminos ;
      private bool n437ProveedorPerAltShop ;
      private bool n490ProveedorPideDoc ;
      private bool n488DocumentacionId ;
      private bool n546ProveedorUsrAlta ;
      private bool n547ProveedorUsrActualizacion ;
      private bool n548ProveedorFechaAlta ;
      private bool n549ProveedorFechaActualizacion ;
      private bool n601ProveedorUsoInterno ;
      private bool n687ProveedorCuentaBancaria ;
      private bool n673BancoId ;
      private bool n432ProveedorImagen ;
      private string AV9ComercioDatos ;
      private string A40000ProveedorImagen_GXI ;
      private string A40001DocumentacionIcono_GXI ;
      private string A431ProveedorDireccion ;
      private string A433ProveedorEmail ;
      private string A432ProveedorImagen ;
      private string A498DocumentacionIcono ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00HQ2_A133ProveedorID ;
      private string[] P00HQ2_A40000ProveedorImagen_GXI ;
      private bool[] P00HQ2_n40000ProveedorImagen_GXI ;
      private string[] P00HQ2_A40001DocumentacionIcono_GXI ;
      private long[] P00HQ2_A151ProveedoresTipoId ;
      private string[] P00HQ2_A282ProveedorNombre ;
      private string[] P00HQ2_A682ProveedorRazonSocial ;
      private bool[] P00HQ2_n682ProveedorRazonSocial ;
      private string[] P00HQ2_A683ProveedorContacto ;
      private bool[] P00HQ2_n683ProveedorContacto ;
      private string[] P00HQ2_A684ProveedorContactoCell ;
      private bool[] P00HQ2_n684ProveedorContactoCell ;
      private string[] P00HQ2_A338ProveedorDocIdentidad ;
      private short[] P00HQ2_A345ProveedorSerialComi ;
      private string[] P00HQ2_A430ProveedorTelefono ;
      private bool[] P00HQ2_n430ProveedorTelefono ;
      private string[] P00HQ2_A431ProveedorDireccion ;
      private bool[] P00HQ2_n431ProveedorDireccion ;
      private string[] P00HQ2_A433ProveedorEmail ;
      private bool[] P00HQ2_n433ProveedorEmail ;
      private string[] P00HQ2_A685ProveedorSitioWeb ;
      private bool[] P00HQ2_n685ProveedorSitioWeb ;
      private DateTime[] P00HQ2_A686ProveedorAceptoTerminos ;
      private bool[] P00HQ2_n686ProveedorAceptoTerminos ;
      private string[] P00HQ2_A437ProveedorPerAltShop ;
      private bool[] P00HQ2_n437ProveedorPerAltShop ;
      private string[] P00HQ2_A344ProveedorEstado ;
      private string[] P00HQ2_A440ProveedorPagoDefault ;
      private string[] P00HQ2_A490ProveedorPideDoc ;
      private bool[] P00HQ2_n490ProveedorPideDoc ;
      private long[] P00HQ2_A488DocumentacionId ;
      private bool[] P00HQ2_n488DocumentacionId ;
      private long[] P00HQ2_A546ProveedorUsrAlta ;
      private bool[] P00HQ2_n546ProveedorUsrAlta ;
      private long[] P00HQ2_A547ProveedorUsrActualizacion ;
      private bool[] P00HQ2_n547ProveedorUsrActualizacion ;
      private DateTime[] P00HQ2_A548ProveedorFechaAlta ;
      private bool[] P00HQ2_n548ProveedorFechaAlta ;
      private DateTime[] P00HQ2_A549ProveedorFechaActualizacion ;
      private bool[] P00HQ2_n549ProveedorFechaActualizacion ;
      private string[] P00HQ2_A601ProveedorUsoInterno ;
      private bool[] P00HQ2_n601ProveedorUsoInterno ;
      private string[] P00HQ2_A687ProveedorCuentaBancaria ;
      private bool[] P00HQ2_n687ProveedorCuentaBancaria ;
      private long[] P00HQ2_A673BancoId ;
      private bool[] P00HQ2_n673BancoId ;
      private string[] P00HQ2_A674BancoNombre ;
      private string[] P00HQ2_A432ProveedorImagen ;
      private bool[] P00HQ2_n432ProveedorImagen ;
      private string[] P00HQ2_A498DocumentacionIcono ;
      private GeneXus.Programs.apis.SdtSDTComercioDatos AV10SDTComercioDatos ;
      private string aP1_ComercioDatos ;
   }

   public class obtenercomerciodatos__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00HQ2;
          prmP00HQ2 = new Object[] {
          new ParDef("@AV8ProveedorId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00HQ2", "SELECT T1.[ProveedorID], T1.[ProveedorImagen_GXI], T2.[DocumentacionIcono_GXI], T1.[ProveedoresTipoId], T1.[ProveedorNombre], T1.[ProveedorRazonSocial], T1.[ProveedorContacto], T1.[ProveedorContactoCell], T1.[ProveedorDocIdentidad], T1.[ProveedorSerialComi], T1.[ProveedorTelefono], T1.[ProveedorDireccion], T1.[ProveedorEmail], T1.[ProveedorSitioWeb], T1.[ProveedorAceptoTerminos], T1.[ProveedorPerAltShop], T1.[ProveedorEstado], T1.[ProveedorPagoDefault], T1.[ProveedorPideDoc], T1.[DocumentacionId], T1.[ProveedorUsrAlta], T1.[ProveedorUsrActualizacion], T1.[ProveedorFechaAlta], T1.[ProveedorFechaActualizacion], T1.[ProveedorUsoInterno], T1.[ProveedorCuentaBancaria], T1.[BancoId], T3.[BancoNombre], T1.[ProveedorImagen], T2.[DocumentacionIcono] FROM (([Proveedor] T1 LEFT JOIN [Documentacion] T2 ON T2.[DocumentacionId] = T1.[DocumentacionId]) LEFT JOIN [Banco] T3 ON T3.[BancoId] = T1.[BancoId]) WHERE T1.[ProveedorID] = @AV8ProveedorId ORDER BY T1.[ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HQ2,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((string[]) buf[6])[0] = rslt.getString(6, 25);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 128);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 20);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((string[]) buf[12])[0] = rslt.getString(9, 25);
                ((short[]) buf[13])[0] = rslt.getShort(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 20);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getVarchar(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((string[]) buf[20])[0] = rslt.getString(14, 128);
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(15);
                ((bool[]) buf[23])[0] = rslt.wasNull(15);
                ((string[]) buf[24])[0] = rslt.getString(16, 1);
                ((bool[]) buf[25])[0] = rslt.wasNull(16);
                ((string[]) buf[26])[0] = rslt.getString(17, 3);
                ((string[]) buf[27])[0] = rslt.getString(18, 1);
                ((string[]) buf[28])[0] = rslt.getString(19, 1);
                ((bool[]) buf[29])[0] = rslt.wasNull(19);
                ((long[]) buf[30])[0] = rslt.getLong(20);
                ((bool[]) buf[31])[0] = rslt.wasNull(20);
                ((long[]) buf[32])[0] = rslt.getLong(21);
                ((bool[]) buf[33])[0] = rslt.wasNull(21);
                ((long[]) buf[34])[0] = rslt.getLong(22);
                ((bool[]) buf[35])[0] = rslt.wasNull(22);
                ((DateTime[]) buf[36])[0] = rslt.getGXDateTime(23);
                ((bool[]) buf[37])[0] = rslt.wasNull(23);
                ((DateTime[]) buf[38])[0] = rslt.getGXDateTime(24);
                ((bool[]) buf[39])[0] = rslt.wasNull(24);
                ((string[]) buf[40])[0] = rslt.getString(25, 1);
                ((bool[]) buf[41])[0] = rslt.wasNull(25);
                ((string[]) buf[42])[0] = rslt.getString(26, 50);
                ((bool[]) buf[43])[0] = rslt.wasNull(26);
                ((long[]) buf[44])[0] = rslt.getLong(27);
                ((bool[]) buf[45])[0] = rslt.wasNull(27);
                ((string[]) buf[46])[0] = rslt.getString(28, 80);
                ((string[]) buf[47])[0] = rslt.getMultimediaFile(29, rslt.getVarchar(2));
                ((bool[]) buf[48])[0] = rslt.wasNull(29);
                ((string[]) buf[49])[0] = rslt.getMultimediaFile(30, rslt.getVarchar(3));
                return;
       }
    }

 }

}
