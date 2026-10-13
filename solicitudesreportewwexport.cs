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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class solicitudesreportewwexport : GXProcedure
   {
      public solicitudesreportewwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public solicitudesreportewwexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         ExecutePrivate();
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         SubmitImpl();
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( 0 == 1 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudesReporte", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV184Pgmname));
               CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
            if ( AV8IsAuthorized )
            {
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
               /* Execute user subroutine: 'OPENDOCUMENT' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV14CellRow = 1;
               AV15FirstColumn = 1;
               /* Execute user subroutine: 'LOADGRIDSTATE' */
               S201 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'WRITEFILTERS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'WRITECOLUMNTITLES' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'WRITEDATA' */
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'CLOSEDOCUMENT' */
               S191 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV14CellRow = 1;
         AV15FirstColumn = 1;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S201 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEFILTERS' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S141 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S161 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S191 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         AV16Random = (int)(NumberUtil.Random( )*10000);
         GXt_char2 = AV12Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char2) ;
         AV12Filename = GXt_char2 + "SolicitudesReporteWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
         AV11ExcelDocument.Open(AV12Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! ( (DateTime.MinValue==AV178SolicitudesFechaInstalacion) && (DateTime.MinValue==AV179SolicitudesFechaInstalacion_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Fecha Instalación", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV178SolicitudesFechaInstalacion ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_MiddleText", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Italic = 1;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV179SolicitudesFechaInstalacion_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
         }
         if ( ! ( (0==AV62TFSolicitudesID) && (0==AV63TFSolicitudesID_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Solicitud", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV62TFSolicitudesID;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV63TFSolicitudesID_To;
         }
         if ( ! ( ( AV119TFSolicitudesSubTipo_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo", "")) ;
            AV14CellRow = GXt_int3;
            AV112i = 1;
            AV185GXV1 = 1;
            while ( AV185GXV1 <= AV119TFSolicitudesSubTipo_Sels.Count )
            {
               AV118TFSolicitudesSubTipo_Sel = AV119TFSolicitudesSubTipo_Sels.GetString(AV185GXV1);
               if ( AV112i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainsolicitudsubtipo.getDescription(context,AV118TFSolicitudesSubTipo_Sel), "");
               AV112i = (long)(AV112i+1);
               AV185GXV1 = (int)(AV185GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV123TFEstadosSolNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV123TFEstadosSolNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV123TFEstadosSolNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV122TFEstadosSolNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV122TFEstadosSolNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV71TFProveedorNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comercio", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV71TFProveedorNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV71TFProveedorNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV70TFProveedorNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comercio", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV70TFProveedorNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV65TFSolicitudesNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Cliente Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV65TFSolicitudesNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV65TFSolicitudesNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFSolicitudesNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Cliente Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV64TFSolicitudesNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV91TFSolicitudesTelefono_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Teléfono", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV91TFSolicitudesTelefono_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV91TFSolicitudesTelefono_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV90TFSolicitudesTelefono)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Teléfono", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV90TFSolicitudesTelefono, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV93TFSolicitudesMail_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Mail", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV93TFSolicitudesMail_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV93TFSolicitudesMail_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV92TFSolicitudesMail)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Mail", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV92TFSolicitudesMail, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV95TFPaisID_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Pais", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV95TFPaisID_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV95TFPaisID_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV94TFPaisID)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Pais", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV94TFPaisID, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV99TFDepartamentoDepartamento_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Departamento", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV99TFDepartamentoDepartamento_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV99TFDepartamentoDepartamento_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV98TFDepartamentoDepartamento)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Departamento", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV98TFDepartamentoDepartamento, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV103TFDepartamentoMunicipioNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Municipio", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV103TFDepartamentoMunicipioNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV103TFDepartamentoMunicipioNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV102TFDepartamentoMunicipioNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Municipio", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV102TFDepartamentoMunicipioNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV107TFSolicitudesDireccion_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Dirección", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV107TFSolicitudesDireccion_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV107TFSolicitudesDireccion_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV106TFSolicitudesDireccion)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Dirección", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV106TFSolicitudesDireccion, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV126TFSolicitudServicioOrigenPago_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Origen de Pago", "")) ;
            AV14CellRow = GXt_int3;
            AV112i = 1;
            AV186GXV2 = 1;
            while ( AV186GXV2 <= AV126TFSolicitudServicioOrigenPago_Sels.Count )
            {
               AV125TFSolicitudServicioOrigenPago_Sel = AV126TFSolicitudServicioOrigenPago_Sels.GetString(AV186GXV2);
               if ( AV112i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainorigenpago.getDescription(context,AV125TFSolicitudServicioOrigenPago_Sel), "");
               AV112i = (long)(AV112i+1);
               AV186GXV2 = (int)(AV186GXV2+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV128TFMetodoPagosNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Metodo de Pago", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV128TFMetodoPagosNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV128TFMetodoPagosNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV127TFMetodoPagosNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Metodo de Pago", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV127TFMetodoPagosNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV131TFSolicitudesPagado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "¿Pagado?", "")) ;
            AV14CellRow = GXt_int3;
            AV112i = 1;
            AV187GXV3 = 1;
            while ( AV187GXV3 <= AV131TFSolicitudesPagado_Sels.Count )
            {
               AV130TFSolicitudesPagado_Sel = AV131TFSolicitudesPagado_Sels.GetString(AV187GXV3);
               if ( AV112i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV130TFSolicitudesPagado_Sel), context.GetMessage( "S", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Pagado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV130TFSolicitudesPagado_Sel), context.GetMessage( "N", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Pendiente de Pago", "");
               }
               AV112i = (long)(AV112i+1);
               AV187GXV3 = (int)(AV187GXV3+1);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV132TFSolicitudServicioPFinal) && (Convert.ToDecimal(0)==AV133TFSolicitudServicioPFinal_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Precio Final", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV132TFSolicitudServicioPFinal);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV133TFSolicitudServicioPFinal_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV134TFSolicitudesCotizacion) && (Convert.ToDecimal(0)==AV135TFSolicitudesCotizacion_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Cotización", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV134TFSolicitudesCotizacion);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV135TFSolicitudesCotizacion_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV136TFSolicitudesDescuento) && (Convert.ToDecimal(0)==AV137TFSolicitudesDescuento_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Solicitud Descuento", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV136TFSolicitudesDescuento);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV137TFSolicitudesDescuento_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV138TFSolicitudServicioComALM) && (Convert.ToDecimal(0)==AV139TFSolicitudServicioComALM_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comisión Almango", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV138TFSolicitudServicioComALM);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV139TFSolicitudServicioComALM_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV140TFSolicitudServicioComALMP) && (Convert.ToDecimal(0)==AV141TFSolicitudServicioComALMP_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "% Comisión Almango", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV140TFSolicitudServicioComALMP);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV141TFSolicitudServicioComALMP_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV142TFSolicitudServicioComPro) && (Convert.ToDecimal(0)==AV143TFSolicitudServicioComPro_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comisión Profesional", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV142TFSolicitudServicioComPro);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV143TFSolicitudServicioComPro_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV144TFSolicitudServicioComProP) && (Convert.ToDecimal(0)==AV145TFSolicitudServicioComProP_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "% Comisión Profesional", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV144TFSolicitudServicioComProP);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV145TFSolicitudServicioComProP_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV146TFSolicitudServicioComProv) && (Convert.ToDecimal(0)==AV147TFSolicitudServicioComProv_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comisión Comercio", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV146TFSolicitudServicioComProv);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV147TFSolicitudServicioComProv_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV148TFSolicitudServicioComProvP) && (Convert.ToDecimal(0)==AV149TFSolicitudServicioComProvP_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "% Comisión Comercio", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV148TFSolicitudServicioComProvP);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV149TFSolicitudServicioComProvP_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV150TFSolicitudesCostoXZComAlm) && (Convert.ToDecimal(0)==AV151TFSolicitudesCostoXZComAlm_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Almango xZona", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV150TFSolicitudesCostoXZComAlm);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV151TFSolicitudesCostoXZComAlm_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV152TFSolicitudesCostoXZComAlmP) && (Convert.ToDecimal(0)==AV153TFSolicitudesCostoXZComAlmP_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "% Almango xZona", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV152TFSolicitudesCostoXZComAlmP);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV153TFSolicitudesCostoXZComAlmP_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV154TFSolicitudesCostoXZComProf) && (Convert.ToDecimal(0)==AV155TFSolicitudesCostoXZComProf_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Profesional xZona", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV154TFSolicitudesCostoXZComProf);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV155TFSolicitudesCostoXZComProf_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV156TFSolicitudesCostoXZComProfP) && (Convert.ToDecimal(0)==AV157TFSolicitudesCostoXZComProfP_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "% Profesional xZona", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV156TFSolicitudesCostoXZComProfP);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV157TFSolicitudesCostoXZComProfP_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV158TFSolicitudesCostoXZona) && (Convert.ToDecimal(0)==AV159TFSolicitudesCostoXZona_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Total xZona", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV158TFSolicitudesCostoXZona);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV159TFSolicitudesCostoXZona_To);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV183TFCancelacionTipificacionDescripcion_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo Cancelación", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV183TFCancelacionTipificacionDescripcion_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV183TFCancelacionTipificacionDescripcion_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV182TFCancelacionTipificacionDescripcion)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo Cancelación", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV182TFCancelacionTipificacionDescripcion, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV161TFSolicitudesNota_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nota", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV161TFSolicitudesNota_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV161TFSolicitudesNota_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV160TFSolicitudesNota)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nota", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV160TFSolicitudesNota, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV163TFSolicitudesComentario_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comentario", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV163TFSolicitudesComentario_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : StringUtil.Substring( AV163TFSolicitudesComentario_Sel, 1, 1000)), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV162TFSolicitudesComentario)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comentario", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( AV162TFSolicitudesComentario, 1, 1000), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV165TFSolicitudesOtros2_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Otros2", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV165TFSolicitudesOtros2_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV165TFSolicitudesOtros2_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV164TFSolicitudesOtros2)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Otros2", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV164TFSolicitudesOtros2, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV167TFSolicitudesOtros3_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Otros3", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV167TFSolicitudesOtros3_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV167TFSolicitudesOtros3_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV166TFSolicitudesOtros3)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Otros3", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV166TFSolicitudesOtros3, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (DateTime.MinValue==AV168TFSolicitudesFechaAlta) && (DateTime.MinValue==AV169TFSolicitudesFechaAlta_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Fecha Alta", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV168TFSolicitudesFechaAlta ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV169TFSolicitudesFechaAlta_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
         }
         if ( ! ( (DateTime.MinValue==AV170TFSolicitudesFechaActualizacion) && (DateTime.MinValue==AV171TFSolicitudesFechaActualizacion_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Fecha Modificación", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = AV170TFSolicitudesFechaActualizacion;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = AV171TFSolicitudesFechaActualizacion_To;
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV59VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV47Session.Get("SolicitudesReporteWWColumnsSelector"), "") != 0 )
         {
            AV54ColumnsSelectorXML = AV47Session.Get("SolicitudesReporteWWColumnsSelector");
            AV51ColumnsSelector.FromXml(AV54ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV51ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV188GXV4 = 1;
         while ( AV188GXV4 <= AV51ColumnsSelector.gxTpr_Columns.Count )
         {
            AV53ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV51ColumnsSelector.gxTpr_Columns.Item(AV188GXV4));
            if ( AV53ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV53ColumnsSelector_Column.gxTpr_Displayname)) ? AV53ColumnsSelector_Column.gxTpr_Columnname : AV53ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Color = 11;
               AV59VisibleColumnCount = (long)(AV59VisibleColumnCount+1);
            }
            AV188GXV4 = (int)(AV188GXV4+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV190Solicitudesreportewwds_1_solicitudesfechainstalacion = AV178SolicitudesFechaInstalacion;
         AV191Solicitudesreportewwds_2_solicitudesfechainstalacion_to = AV179SolicitudesFechaInstalacion_To;
         AV192Solicitudesreportewwds_3_tfsolicitudesid = AV62TFSolicitudesID;
         AV193Solicitudesreportewwds_4_tfsolicitudesid_to = AV63TFSolicitudesID_To;
         AV194Solicitudesreportewwds_5_tfsolicitudessubtipo_sels = AV119TFSolicitudesSubTipo_Sels;
         AV195Solicitudesreportewwds_6_tfestadossolnombre = AV122TFEstadosSolNombre;
         AV196Solicitudesreportewwds_7_tfestadossolnombre_sel = AV123TFEstadosSolNombre_Sel;
         AV197Solicitudesreportewwds_8_tfproveedornombre = AV70TFProveedorNombre;
         AV198Solicitudesreportewwds_9_tfproveedornombre_sel = AV71TFProveedorNombre_Sel;
         AV199Solicitudesreportewwds_10_tfsolicitudesnombre = AV64TFSolicitudesNombre;
         AV200Solicitudesreportewwds_11_tfsolicitudesnombre_sel = AV65TFSolicitudesNombre_Sel;
         AV201Solicitudesreportewwds_12_tfsolicitudestelefono = AV90TFSolicitudesTelefono;
         AV202Solicitudesreportewwds_13_tfsolicitudestelefono_sel = AV91TFSolicitudesTelefono_Sel;
         AV203Solicitudesreportewwds_14_tfsolicitudesmail = AV92TFSolicitudesMail;
         AV204Solicitudesreportewwds_15_tfsolicitudesmail_sel = AV93TFSolicitudesMail_Sel;
         AV205Solicitudesreportewwds_16_tfpaisid = AV94TFPaisID;
         AV206Solicitudesreportewwds_17_tfpaisid_sel = AV95TFPaisID_Sel;
         AV207Solicitudesreportewwds_18_tfdepartamentodepartamento = AV98TFDepartamentoDepartamento;
         AV208Solicitudesreportewwds_19_tfdepartamentodepartamento_sel = AV99TFDepartamentoDepartamento_Sel;
         AV209Solicitudesreportewwds_20_tfdepartamentomunicipionombre = AV102TFDepartamentoMunicipioNombre;
         AV210Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel = AV103TFDepartamentoMunicipioNombre_Sel;
         AV211Solicitudesreportewwds_22_tfsolicitudesdireccion = AV106TFSolicitudesDireccion;
         AV212Solicitudesreportewwds_23_tfsolicitudesdireccion_sel = AV107TFSolicitudesDireccion_Sel;
         AV213Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels = AV126TFSolicitudServicioOrigenPago_Sels;
         AV214Solicitudesreportewwds_25_tfmetodopagosnombre = AV127TFMetodoPagosNombre;
         AV215Solicitudesreportewwds_26_tfmetodopagosnombre_sel = AV128TFMetodoPagosNombre_Sel;
         AV216Solicitudesreportewwds_27_tfsolicitudespagado_sels = AV131TFSolicitudesPagado_Sels;
         AV217Solicitudesreportewwds_28_tfsolicitudserviciopfinal = AV132TFSolicitudServicioPFinal;
         AV218Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to = AV133TFSolicitudServicioPFinal_To;
         AV219Solicitudesreportewwds_30_tfsolicitudescotizacion = AV134TFSolicitudesCotizacion;
         AV220Solicitudesreportewwds_31_tfsolicitudescotizacion_to = AV135TFSolicitudesCotizacion_To;
         AV221Solicitudesreportewwds_32_tfsolicitudesdescuento = AV136TFSolicitudesDescuento;
         AV222Solicitudesreportewwds_33_tfsolicitudesdescuento_to = AV137TFSolicitudesDescuento_To;
         AV223Solicitudesreportewwds_34_tfsolicitudserviciocomalm = AV138TFSolicitudServicioComALM;
         AV224Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to = AV139TFSolicitudServicioComALM_To;
         AV225Solicitudesreportewwds_36_tfsolicitudserviciocomalmp = AV140TFSolicitudServicioComALMP;
         AV226Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to = AV141TFSolicitudServicioComALMP_To;
         AV227Solicitudesreportewwds_38_tfsolicitudserviciocompro = AV142TFSolicitudServicioComPro;
         AV228Solicitudesreportewwds_39_tfsolicitudserviciocompro_to = AV143TFSolicitudServicioComPro_To;
         AV229Solicitudesreportewwds_40_tfsolicitudserviciocomprop = AV144TFSolicitudServicioComProP;
         AV230Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to = AV145TFSolicitudServicioComProP_To;
         AV231Solicitudesreportewwds_42_tfsolicitudserviciocomprov = AV146TFSolicitudServicioComProv;
         AV232Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to = AV147TFSolicitudServicioComProv_To;
         AV233Solicitudesreportewwds_44_tfsolicitudserviciocomprovp = AV148TFSolicitudServicioComProvP;
         AV234Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to = AV149TFSolicitudServicioComProvP_To;
         AV235Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm = AV150TFSolicitudesCostoXZComAlm;
         AV236Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to = AV151TFSolicitudesCostoXZComAlm_To;
         AV237Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp = AV152TFSolicitudesCostoXZComAlmP;
         AV238Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to = AV153TFSolicitudesCostoXZComAlmP_To;
         AV239Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof = AV154TFSolicitudesCostoXZComProf;
         AV240Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to = AV155TFSolicitudesCostoXZComProf_To;
         AV241Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp = AV156TFSolicitudesCostoXZComProfP;
         AV242Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to = AV157TFSolicitudesCostoXZComProfP_To;
         AV243Solicitudesreportewwds_54_tfsolicitudescostoxzona = AV158TFSolicitudesCostoXZona;
         AV244Solicitudesreportewwds_55_tfsolicitudescostoxzona_to = AV159TFSolicitudesCostoXZona_To;
         AV245Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion = AV182TFCancelacionTipificacionDescripcion;
         AV246Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel = AV183TFCancelacionTipificacionDescripcion_Sel;
         AV247Solicitudesreportewwds_58_tfsolicitudesnota = AV160TFSolicitudesNota;
         AV248Solicitudesreportewwds_59_tfsolicitudesnota_sel = AV161TFSolicitudesNota_Sel;
         AV249Solicitudesreportewwds_60_tfsolicitudescomentario = AV162TFSolicitudesComentario;
         AV250Solicitudesreportewwds_61_tfsolicitudescomentario_sel = AV163TFSolicitudesComentario_Sel;
         AV251Solicitudesreportewwds_62_tfsolicitudesotros2 = AV164TFSolicitudesOtros2;
         AV252Solicitudesreportewwds_63_tfsolicitudesotros2_sel = AV165TFSolicitudesOtros2_Sel;
         AV253Solicitudesreportewwds_64_tfsolicitudesotros3 = AV166TFSolicitudesOtros3;
         AV254Solicitudesreportewwds_65_tfsolicitudesotros3_sel = AV167TFSolicitudesOtros3_Sel;
         AV255Solicitudesreportewwds_66_tfsolicitudesfechaalta = AV168TFSolicitudesFechaAlta;
         AV256Solicitudesreportewwds_67_tfsolicitudesfechaalta_to = AV169TFSolicitudesFechaAlta_To;
         AV257Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion = AV170TFSolicitudesFechaActualizacion;
         AV258Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to = AV171TFSolicitudesFechaActualizacion_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A600SolicitudesSubTipo ,
                                              AV194Solicitudesreportewwds_5_tfsolicitudessubtipo_sels ,
                                              A438SolicitudServicioOrigenPago ,
                                              AV213Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels ,
                                              A441SolicitudesPagado ,
                                              AV216Solicitudesreportewwds_27_tfsolicitudespagado_sels ,
                                              AV190Solicitudesreportewwds_1_solicitudesfechainstalacion ,
                                              AV191Solicitudesreportewwds_2_solicitudesfechainstalacion_to ,
                                              AV192Solicitudesreportewwds_3_tfsolicitudesid ,
                                              AV193Solicitudesreportewwds_4_tfsolicitudesid_to ,
                                              AV194Solicitudesreportewwds_5_tfsolicitudessubtipo_sels.Count ,
                                              AV196Solicitudesreportewwds_7_tfestadossolnombre_sel ,
                                              AV195Solicitudesreportewwds_6_tfestadossolnombre ,
                                              AV198Solicitudesreportewwds_9_tfproveedornombre_sel ,
                                              AV197Solicitudesreportewwds_8_tfproveedornombre ,
                                              AV200Solicitudesreportewwds_11_tfsolicitudesnombre_sel ,
                                              AV199Solicitudesreportewwds_10_tfsolicitudesnombre ,
                                              AV202Solicitudesreportewwds_13_tfsolicitudestelefono_sel ,
                                              AV201Solicitudesreportewwds_12_tfsolicitudestelefono ,
                                              AV204Solicitudesreportewwds_15_tfsolicitudesmail_sel ,
                                              AV203Solicitudesreportewwds_14_tfsolicitudesmail ,
                                              AV206Solicitudesreportewwds_17_tfpaisid_sel ,
                                              AV205Solicitudesreportewwds_16_tfpaisid ,
                                              AV208Solicitudesreportewwds_19_tfdepartamentodepartamento_sel ,
                                              AV207Solicitudesreportewwds_18_tfdepartamentodepartamento ,
                                              AV210Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel ,
                                              AV209Solicitudesreportewwds_20_tfdepartamentomunicipionombre ,
                                              AV212Solicitudesreportewwds_23_tfsolicitudesdireccion_sel ,
                                              AV211Solicitudesreportewwds_22_tfsolicitudesdireccion ,
                                              AV213Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels.Count ,
                                              AV215Solicitudesreportewwds_26_tfmetodopagosnombre_sel ,
                                              AV214Solicitudesreportewwds_25_tfmetodopagosnombre ,
                                              AV216Solicitudesreportewwds_27_tfsolicitudespagado_sels.Count ,
                                              AV219Solicitudesreportewwds_30_tfsolicitudescotizacion ,
                                              AV220Solicitudesreportewwds_31_tfsolicitudescotizacion_to ,
                                              AV221Solicitudesreportewwds_32_tfsolicitudesdescuento ,
                                              AV222Solicitudesreportewwds_33_tfsolicitudesdescuento_to ,
                                              AV223Solicitudesreportewwds_34_tfsolicitudserviciocomalm ,
                                              AV224Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to ,
                                              AV225Solicitudesreportewwds_36_tfsolicitudserviciocomalmp ,
                                              AV226Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to ,
                                              AV229Solicitudesreportewwds_40_tfsolicitudserviciocomprop ,
                                              AV230Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to ,
                                              AV231Solicitudesreportewwds_42_tfsolicitudserviciocomprov ,
                                              AV232Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to ,
                                              AV233Solicitudesreportewwds_44_tfsolicitudserviciocomprovp ,
                                              AV234Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to ,
                                              AV235Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm ,
                                              AV236Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to ,
                                              AV237Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp ,
                                              AV238Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to ,
                                              AV239Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof ,
                                              AV240Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to ,
                                              AV241Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp ,
                                              AV242Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to ,
                                              AV243Solicitudesreportewwds_54_tfsolicitudescostoxzona ,
                                              AV244Solicitudesreportewwds_55_tfsolicitudescostoxzona_to ,
                                              AV246Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel ,
                                              AV245Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion ,
                                              AV248Solicitudesreportewwds_59_tfsolicitudesnota_sel ,
                                              AV247Solicitudesreportewwds_58_tfsolicitudesnota ,
                                              AV250Solicitudesreportewwds_61_tfsolicitudescomentario_sel ,
                                              AV249Solicitudesreportewwds_60_tfsolicitudescomentario ,
                                              AV252Solicitudesreportewwds_63_tfsolicitudesotros2_sel ,
                                              AV251Solicitudesreportewwds_62_tfsolicitudesotros2 ,
                                              AV254Solicitudesreportewwds_65_tfsolicitudesotros3_sel ,
                                              AV253Solicitudesreportewwds_64_tfsolicitudesotros3 ,
                                              AV255Solicitudesreportewwds_66_tfsolicitudesfechaalta ,
                                              AV256Solicitudesreportewwds_67_tfsolicitudesfechaalta_to ,
                                              AV257Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion ,
                                              AV258Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to ,
                                              A184SolicitudesFechaInstalacion ,
                                              A127SolicitudesID ,
                                              A132EstadosSolNombre ,
                                              A282ProveedorNombre ,
                                              A171SolicitudesNombre ,
                                              A172SolicitudesTelefono ,
                                              A206SolicitudesMail ,
                                              A116PaisID ,
                                              A113DepartamentoDepartamento ,
                                              A115DepartamentoMunicipioNombre ,
                                              A173SolicitudesDireccion ,
                                              A129MetodoPagosNombre ,
                                              A212SolicitudesCotizacion ,
                                              A897SolicitudesDescuento ,
                                              A530SolicitudServicioComALM ,
                                              A532SolicitudServicioComALMP ,
                                              A528SolicitudServicioComProvP ,
                                              A527SolicitudServicioComProv ,
                                              A865SolicitudesCostoXZComAlm ,
                                              A866SolicitudesCostoXZComAlmP ,
                                              A864SolicitudesCostoXZona ,
                                              A997CancelacionTipificacionDescrip ,
                                              A261SolicitudesNota ,
                                              A205SolicitudesComentario ,
                                              A202SolicitudesOtros2 ,
                                              A203SolicitudesOtros3 ,
                                              A182SolicitudesFechaAlta ,
                                              A204SolicitudesFechaActualizacion ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV217Solicitudesreportewwds_28_tfsolicitudserviciopfinal ,
                                              A211SolicitudServicioPFinal ,
                                              AV218Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to ,
                                              AV227Solicitudesreportewwds_38_tfsolicitudserviciocompro ,
                                              A529SolicitudServicioComPro ,
                                              AV228Solicitudesreportewwds_39_tfsolicitudserviciocompro_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV195Solicitudesreportewwds_6_tfestadossolnombre = StringUtil.PadR( StringUtil.RTrim( AV195Solicitudesreportewwds_6_tfestadossolnombre), 80, "%");
         lV197Solicitudesreportewwds_8_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV197Solicitudesreportewwds_8_tfproveedornombre), 80, "%");
         lV199Solicitudesreportewwds_10_tfsolicitudesnombre = StringUtil.PadR( StringUtil.RTrim( AV199Solicitudesreportewwds_10_tfsolicitudesnombre), 100, "%");
         lV201Solicitudesreportewwds_12_tfsolicitudestelefono = StringUtil.PadR( StringUtil.RTrim( AV201Solicitudesreportewwds_12_tfsolicitudestelefono), 20, "%");
         lV203Solicitudesreportewwds_14_tfsolicitudesmail = StringUtil.Concat( StringUtil.RTrim( AV203Solicitudesreportewwds_14_tfsolicitudesmail), "%", "");
         lV205Solicitudesreportewwds_16_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV205Solicitudesreportewwds_16_tfpaisid), 2, "%");
         lV207Solicitudesreportewwds_18_tfdepartamentodepartamento = StringUtil.PadR( StringUtil.RTrim( AV207Solicitudesreportewwds_18_tfdepartamentodepartamento), 80, "%");
         lV209Solicitudesreportewwds_20_tfdepartamentomunicipionombre = StringUtil.PadR( StringUtil.RTrim( AV209Solicitudesreportewwds_20_tfdepartamentomunicipionombre), 120, "%");
         lV211Solicitudesreportewwds_22_tfsolicitudesdireccion = StringUtil.Concat( StringUtil.RTrim( AV211Solicitudesreportewwds_22_tfsolicitudesdireccion), "%", "");
         lV214Solicitudesreportewwds_25_tfmetodopagosnombre = StringUtil.PadR( StringUtil.RTrim( AV214Solicitudesreportewwds_25_tfmetodopagosnombre), 80, "%");
         lV245Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion = StringUtil.PadR( StringUtil.RTrim( AV245Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion), 250, "%");
         lV247Solicitudesreportewwds_58_tfsolicitudesnota = StringUtil.PadR( StringUtil.RTrim( AV247Solicitudesreportewwds_58_tfsolicitudesnota), 500, "%");
         lV249Solicitudesreportewwds_60_tfsolicitudescomentario = StringUtil.Concat( StringUtil.RTrim( AV249Solicitudesreportewwds_60_tfsolicitudescomentario), "%", "");
         lV251Solicitudesreportewwds_62_tfsolicitudesotros2 = StringUtil.PadR( StringUtil.RTrim( AV251Solicitudesreportewwds_62_tfsolicitudesotros2), 1000, "%");
         lV253Solicitudesreportewwds_64_tfsolicitudesotros3 = StringUtil.PadR( StringUtil.RTrim( AV253Solicitudesreportewwds_64_tfsolicitudesotros3), 500, "%");
         /* Using cursor P00L42 */
         pr_default.execute(0, new Object[] {AV190Solicitudesreportewwds_1_solicitudesfechainstalacion, AV191Solicitudesreportewwds_2_solicitudesfechainstalacion_to, AV192Solicitudesreportewwds_3_tfsolicitudesid, AV193Solicitudesreportewwds_4_tfsolicitudesid_to, lV195Solicitudesreportewwds_6_tfestadossolnombre, AV196Solicitudesreportewwds_7_tfestadossolnombre_sel, lV197Solicitudesreportewwds_8_tfproveedornombre, AV198Solicitudesreportewwds_9_tfproveedornombre_sel, lV199Solicitudesreportewwds_10_tfsolicitudesnombre, AV200Solicitudesreportewwds_11_tfsolicitudesnombre_sel, lV201Solicitudesreportewwds_12_tfsolicitudestelefono, AV202Solicitudesreportewwds_13_tfsolicitudestelefono_sel, lV203Solicitudesreportewwds_14_tfsolicitudesmail, AV204Solicitudesreportewwds_15_tfsolicitudesmail_sel, lV205Solicitudesreportewwds_16_tfpaisid, AV206Solicitudesreportewwds_17_tfpaisid_sel, lV207Solicitudesreportewwds_18_tfdepartamentodepartamento, AV208Solicitudesreportewwds_19_tfdepartamentodepartamento_sel, lV209Solicitudesreportewwds_20_tfdepartamentomunicipionombre, AV210Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel, lV211Solicitudesreportewwds_22_tfsolicitudesdireccion, AV212Solicitudesreportewwds_23_tfsolicitudesdireccion_sel, lV214Solicitudesreportewwds_25_tfmetodopagosnombre, AV215Solicitudesreportewwds_26_tfmetodopagosnombre_sel, AV219Solicitudesreportewwds_30_tfsolicitudescotizacion, AV220Solicitudesreportewwds_31_tfsolicitudescotizacion_to, AV221Solicitudesreportewwds_32_tfsolicitudesdescuento, AV222Solicitudesreportewwds_33_tfsolicitudesdescuento_to, AV223Solicitudesreportewwds_34_tfsolicitudserviciocomalm, AV224Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to, AV225Solicitudesreportewwds_36_tfsolicitudserviciocomalmp, AV226Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to, AV229Solicitudesreportewwds_40_tfsolicitudserviciocomprop, AV230Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to, AV231Solicitudesreportewwds_42_tfsolicitudserviciocomprov, AV232Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to, AV233Solicitudesreportewwds_44_tfsolicitudserviciocomprovp, AV234Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to, AV235Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm, AV236Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to, AV237Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp, AV238Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to, AV239Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof, AV240Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to, AV241Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp, AV242Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to, AV243Solicitudesreportewwds_54_tfsolicitudescostoxzona, AV244Solicitudesreportewwds_55_tfsolicitudescostoxzona_to, lV245Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion, AV246Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel, lV247Solicitudesreportewwds_58_tfsolicitudesnota, AV248Solicitudesreportewwds_59_tfsolicitudesnota_sel, lV249Solicitudesreportewwds_60_tfsolicitudescomentario, AV250Solicitudesreportewwds_61_tfsolicitudescomentario_sel, lV251Solicitudesreportewwds_62_tfsolicitudesotros2, AV252Solicitudesreportewwds_63_tfsolicitudesotros2_sel, lV253Solicitudesreportewwds_64_tfsolicitudesotros3, AV254Solicitudesreportewwds_65_tfsolicitudesotros3_sel, AV255Solicitudesreportewwds_66_tfsolicitudesfechaalta, AV256Solicitudesreportewwds_67_tfsolicitudesfechaalta_to, AV257Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion, AV258Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112DepartamentoId = P00L42_A112DepartamentoId[0];
            n112DepartamentoId = P00L42_n112DepartamentoId[0];
            A114DepartamentoMunicipioId = P00L42_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P00L42_n114DepartamentoMunicipioId[0];
            A128MetodoPagosID = P00L42_A128MetodoPagosID[0];
            A133ProveedorID = P00L42_A133ProveedorID[0];
            A996CancelacionTipificacionId = P00L42_A996CancelacionTipificacionId[0];
            A130EstadosSolTipo = P00L42_A130EstadosSolTipo[0];
            A131EstadosSolId = P00L42_A131EstadosSolId[0];
            A598SolicitudesUsrActualizacion = P00L42_A598SolicitudesUsrActualizacion[0];
            n598SolicitudesUsrActualizacion = P00L42_n598SolicitudesUsrActualizacion[0];
            A597SolicitudesUsrAlta = P00L42_A597SolicitudesUsrAlta[0];
            n597SolicitudesUsrAlta = P00L42_n597SolicitudesUsrAlta[0];
            A204SolicitudesFechaActualizacion = P00L42_A204SolicitudesFechaActualizacion[0];
            n204SolicitudesFechaActualizacion = P00L42_n204SolicitudesFechaActualizacion[0];
            A182SolicitudesFechaAlta = P00L42_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = P00L42_n182SolicitudesFechaAlta[0];
            A203SolicitudesOtros3 = P00L42_A203SolicitudesOtros3[0];
            A202SolicitudesOtros2 = P00L42_A202SolicitudesOtros2[0];
            A205SolicitudesComentario = P00L42_A205SolicitudesComentario[0];
            A261SolicitudesNota = P00L42_A261SolicitudesNota[0];
            A997CancelacionTipificacionDescrip = P00L42_A997CancelacionTipificacionDescrip[0];
            A441SolicitudesPagado = P00L42_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P00L42_n441SolicitudesPagado[0];
            A129MetodoPagosNombre = P00L42_A129MetodoPagosNombre[0];
            A438SolicitudServicioOrigenPago = P00L42_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00L42_n438SolicitudServicioOrigenPago[0];
            A173SolicitudesDireccion = P00L42_A173SolicitudesDireccion[0];
            A115DepartamentoMunicipioNombre = P00L42_A115DepartamentoMunicipioNombre[0];
            A113DepartamentoDepartamento = P00L42_A113DepartamentoDepartamento[0];
            A116PaisID = P00L42_A116PaisID[0];
            A206SolicitudesMail = P00L42_A206SolicitudesMail[0];
            n206SolicitudesMail = P00L42_n206SolicitudesMail[0];
            A172SolicitudesTelefono = P00L42_A172SolicitudesTelefono[0];
            A171SolicitudesNombre = P00L42_A171SolicitudesNombre[0];
            A282ProveedorNombre = P00L42_A282ProveedorNombre[0];
            A132EstadosSolNombre = P00L42_A132EstadosSolNombre[0];
            A600SolicitudesSubTipo = P00L42_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P00L42_n600SolicitudesSubTipo[0];
            A127SolicitudesID = P00L42_A127SolicitudesID[0];
            A184SolicitudesFechaInstalacion = P00L42_A184SolicitudesFechaInstalacion[0];
            A183SolicitudesHoraInstalacion = P00L42_A183SolicitudesHoraInstalacion[0];
            A796SolicitudesComisionMetodoPago = P00L42_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P00L42_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P00L42_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00L42_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00L42_n897SolicitudesDescuento[0];
            A527SolicitudServicioComProv = P00L42_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = P00L42_n527SolicitudServicioComProv[0];
            A530SolicitudServicioComALM = P00L42_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = P00L42_n530SolicitudServicioComALM[0];
            A532SolicitudServicioComALMP = P00L42_A532SolicitudServicioComALMP[0];
            n532SolicitudServicioComALMP = P00L42_n532SolicitudServicioComALMP[0];
            A528SolicitudServicioComProvP = P00L42_A528SolicitudServicioComProvP[0];
            n528SolicitudServicioComProvP = P00L42_n528SolicitudServicioComProvP[0];
            A865SolicitudesCostoXZComAlm = P00L42_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = P00L42_n865SolicitudesCostoXZComAlm[0];
            A864SolicitudesCostoXZona = P00L42_A864SolicitudesCostoXZona[0];
            A866SolicitudesCostoXZComAlmP = P00L42_A866SolicitudesCostoXZComAlmP[0];
            n866SolicitudesCostoXZComAlmP = P00L42_n866SolicitudesCostoXZComAlmP[0];
            A113DepartamentoDepartamento = P00L42_A113DepartamentoDepartamento[0];
            A116PaisID = P00L42_A116PaisID[0];
            A115DepartamentoMunicipioNombre = P00L42_A115DepartamentoMunicipioNombre[0];
            A129MetodoPagosNombre = P00L42_A129MetodoPagosNombre[0];
            A282ProveedorNombre = P00L42_A282ProveedorNombre[0];
            A997CancelacionTipificacionDescrip = P00L42_A997CancelacionTipificacionDescrip[0];
            A132EstadosSolNombre = P00L42_A132EstadosSolNombre[0];
            if ( ( A866SolicitudesCostoXZComAlmP >= Convert.ToDecimal( 0 )) )
            {
               A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
            }
            else
            {
               if ( ( A866SolicitudesCostoXZComAlmP < Convert.ToDecimal( 0 )) )
               {
                  A868SolicitudesCostoXZComProfP = (decimal)(100+(A866SolicitudesCostoXZComAlmP*-1));
               }
               else
               {
                  A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
               }
            }
            if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
            {
               A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
            }
            else
            {
               A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
            }
            if ( ( A532SolicitudServicioComALMP >= Convert.ToDecimal( 0 )) )
            {
               A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
            }
            else
            {
               if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP >= Convert.ToDecimal( 0 )) )
               {
                  A531SolicitudServicioComProP = (decimal)((100-A528SolicitudServicioComProvP)+(A532SolicitudServicioComALMP*-1));
               }
               else
               {
                  if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP < Convert.ToDecimal( 0 )) )
                  {
                     A531SolicitudServicioComProP = (decimal)(100+((A528SolicitudServicioComProvP+A532SolicitudServicioComALMP)*-1));
                  }
                  else
                  {
                     A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
                  }
               }
            }
            GetSolicitudesTotal( A127SolicitudesID) ;
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            if ( (Convert.ToDecimal(0)==AV217Solicitudesreportewwds_28_tfsolicitudserviciopfinal) || ( ( A211SolicitudServicioPFinal >= AV217Solicitudesreportewwds_28_tfsolicitudserviciopfinal ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV218Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to) || ( ( A211SolicitudServicioPFinal <= AV218Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to ) ) )
               {
                  if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
                  {
                     A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
                  }
                  else
                  {
                     if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
                     {
                        A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
                     }
                     else
                     {
                        if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
                        {
                           A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                        }
                        else
                        {
                           A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                        }
                     }
                  }
                  if ( (Convert.ToDecimal(0)==AV227Solicitudesreportewwds_38_tfsolicitudserviciocompro) || ( ( A529SolicitudServicioComPro >= AV227Solicitudesreportewwds_38_tfsolicitudserviciocompro ) ) )
                  {
                     if ( (Convert.ToDecimal(0)==AV228Solicitudesreportewwds_39_tfsolicitudserviciocompro_to) || ( ( A529SolicitudServicioComPro <= AV228Solicitudesreportewwds_39_tfsolicitudserviciocompro_to ) ) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        /* Execute user subroutine: 'BEFOREWRITELINE' */
                        S172 ();
                        if ( returnInSub )
                        {
                           pr_default.close(0);
                           returnInSub = true;
                           if (true) return;
                        }
                        AV59VisibleColumnCount = 0;
                        AV259GXV5 = 1;
                        while ( AV259GXV5 <= AV51ColumnsSelector.gxTpr_Columns.Count )
                        {
                           AV53ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV51ColumnsSelector.gxTpr_Columns.Item(AV259GXV5));
                           if ( AV53ColumnsSelector_Column.gxTpr_Isvisible )
                           {
                              if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "&ProfesionalId") == 0 )
                              {
                                 new orelnom(context ).execute(  A127SolicitudesID, out  AV175ProfesionalId, out  AV176Profesional, out  AV177Existe) ;
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV175ProfesionalId, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "&Profesional") == 0 )
                              {
                                 new orelnom(context ).execute(  A127SolicitudesID, out  AV175ProfesionalId, out  AV176Profesional, out  AV177Existe) ;
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV176Profesional, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesID") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Number = A127SolicitudesID;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesSubTipo") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainsolicitudsubtipo.getDescription(context,A600SolicitudesSubTipo), "");
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesFechaInstalacion") == 0 )
                              {
                                 GXt_dtime4 = DateTimeUtil.ResetTime( A184SolicitudesFechaInstalacion ) ;
                                 AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Date = GXt_dtime4;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "&HoraInstalacion") == 0 )
                              {
                                 if ( StringUtil.StrCmp(DateTimeUtil.CDow( A184SolicitudesFechaInstalacion, context.GetLanguage( )), context.GetMessage( "Sábado", "")) == 0 )
                                 {
                                    if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
                                    {
                                       AV113HoraInstalacion = "08 - 14";
                                    }
                                    if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
                                    {
                                       AV113HoraInstalacion = "14 - 20";
                                    }
                                 }
                                 else
                                 {
                                    if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
                                    {
                                       AV113HoraInstalacion = "08 - 12";
                                    }
                                    if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
                                    {
                                       AV113HoraInstalacion = "12 - 16";
                                    }
                                    if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "3") == 0 )
                                    {
                                       AV113HoraInstalacion = "16 - 20";
                                    }
                                 }
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV113HoraInstalacion, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "&Dia") == 0 )
                              {
                                 AV114Dia = DateTimeUtil.CDow( A184SolicitudesFechaInstalacion, context.GetLanguage( ));
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV114Dia, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "EstadosSolNombre") == 0 )
                              {
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A132EstadosSolNombre, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "ProveedorNombre") == 0 )
                              {
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A282ProveedorNombre, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesNombre") == 0 )
                              {
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A171SolicitudesNombre, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesTelefono") == 0 )
                              {
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A172SolicitudesTelefono, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesMail") == 0 )
                              {
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A206SolicitudesMail, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "PaisID") == 0 )
                              {
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A116PaisID, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "DepartamentoDepartamento") == 0 )
                              {
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A113DepartamentoDepartamento, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "DepartamentoMunicipioNombre") == 0 )
                              {
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A115DepartamentoMunicipioNombre, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesDireccion") == 0 )
                              {
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A173SolicitudesDireccion, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudServicioOrigenPago") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainorigenpago.getDescription(context,A438SolicitudServicioOrigenPago), "");
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "MetodoPagosNombre") == 0 )
                              {
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A129MetodoPagosNombre, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesPagado") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = "";
                                 if ( StringUtil.StrCmp(StringUtil.Trim( A441SolicitudesPagado), context.GetMessage( "S", "")) == 0 )
                                 {
                                    AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = context.GetMessage( "Pagado", "");
                                 }
                                 else if ( StringUtil.StrCmp(StringUtil.Trim( A441SolicitudesPagado), context.GetMessage( "N", "")) == 0 )
                                 {
                                    AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = context.GetMessage( "Pendiente de Pago", "");
                                 }
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudServicioPFinal") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Number = (double)(A211SolicitudServicioPFinal);
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesCotizacion") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Number = (double)(A212SolicitudesCotizacion);
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesDescuento") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Number = (double)(A897SolicitudesDescuento);
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudServicioComALM") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Number = (double)(A530SolicitudServicioComALM);
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudServicioComALMP") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Number = (double)(A532SolicitudServicioComALMP);
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudServicioComPro") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Number = (double)(A529SolicitudServicioComPro);
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudServicioComProP") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Number = (double)(A531SolicitudServicioComProP);
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudServicioComProv") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Number = (double)(A527SolicitudServicioComProv);
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudServicioComProvP") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Number = (double)(A528SolicitudServicioComProvP);
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesCostoXZComAlm") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Number = (double)(A865SolicitudesCostoXZComAlm);
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesCostoXZComAlmP") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Number = (double)(A866SolicitudesCostoXZComAlmP);
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesCostoXZComProf") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Number = (double)(A867SolicitudesCostoXZComProf);
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesCostoXZComProfP") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Number = (double)(A868SolicitudesCostoXZComProfP);
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesCostoXZona") == 0 )
                              {
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Number = (double)(A864SolicitudesCostoXZona);
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "CancelacionTipificacionDescripcion") == 0 )
                              {
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A997CancelacionTipificacionDescrip, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesNota") == 0 )
                              {
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A261SolicitudesNota, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesComentario") == 0 )
                              {
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( A205SolicitudesComentario, 1, 1000), out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesOtros2") == 0 )
                              {
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A202SolicitudesOtros2, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesOtros3") == 0 )
                              {
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A203SolicitudesOtros3, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "&UserAlta") == 0 )
                              {
                                 /* Using cursor P00L43 */
                                 pr_default.execute(1, new Object[] {n597SolicitudesUsrAlta, A597SolicitudesUsrAlta});
                                 while ( (pr_default.getStatus(1) != 101) )
                                 {
                                    A18SecUserId = P00L43_A18SecUserId[0];
                                    A26SecUserName = P00L43_A26SecUserName[0];
                                    AV115UserAlta = A26SecUserName;
                                    /* Exiting from a For First loop. */
                                    if (true) break;
                                 }
                                 pr_default.close(1);
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV115UserAlta, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "&UserUPD") == 0 )
                              {
                                 /* Using cursor P00L44 */
                                 pr_default.execute(2, new Object[] {n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion});
                                 while ( (pr_default.getStatus(2) != 101) )
                                 {
                                    A18SecUserId = P00L44_A18SecUserId[0];
                                    A26SecUserName = P00L44_A26SecUserName[0];
                                    AV116UserUPD = A26SecUserName;
                                    /* Exiting from a For First loop. */
                                    if (true) break;
                                 }
                                 pr_default.close(2);
                                 GXt_char2 = "";
                                 new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV116UserUPD, out  GXt_char2) ;
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Text = GXt_char2;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesFechaAlta") == 0 )
                              {
                                 GXt_dtime4 = DateTimeUtil.ResetTime( A182SolicitudesFechaAlta ) ;
                                 AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Date = GXt_dtime4;
                              }
                              else if ( StringUtil.StrCmp(AV53ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesFechaActualizacion") == 0 )
                              {
                                 AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                                 AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV59VisibleColumnCount), 1, 1).Date = A204SolicitudesFechaActualizacion;
                              }
                              AV59VisibleColumnCount = (long)(AV59VisibleColumnCount+1);
                           }
                           AV259GXV5 = (int)(AV259GXV5+1);
                        }
                        /* Execute user subroutine: 'AFTERWRITELINE' */
                        S182 ();
                        if ( returnInSub )
                        {
                           pr_default.close(0);
                           returnInSub = true;
                           if (true) return;
                        }
                     }
                  }
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S191( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV11ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Close();
         AV47Session.Set("WWPExportFilePath", AV12Filename);
         AV47Session.Set("WWPExportFileName", "SolicitudesReporteWWExport.xlsx");
         AV12Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV11ExcelDocument.ErrCode != 0 )
         {
            AV12Filename = "";
            AV13ErrorMessage = AV11ExcelDocument.ErrDescription;
            AV11ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S151( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV51ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "&ProfesionalId",  "",  "ProfesionalId",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "&Profesional",  "",  "Profesional",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesID",  "",  "Solicitud",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesSubTipo",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesFechaInstalacion",  "",  "Fecha de instalación",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "&HoraInstalacion",  "",  "Hora",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "&Dia",  "",  "Día",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "EstadosSolNombre",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "ProveedorNombre",  "",  "Comercio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesNombre",  "",  "Cliente Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesTelefono",  "",  "Teléfono",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesMail",  "",  "Mail",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "PaisID",  "",  "Pais",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "DepartamentoDepartamento",  "",  "Departamento",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "DepartamentoMunicipioNombre",  "",  "Municipio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesDireccion",  "",  "Dirección",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudServicioOrigenPago",  "",  "Origen de Pago",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "MetodoPagosNombre",  "",  "Metodo de Pago",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesPagado",  "",  "¿Pagado?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudServicioPFinal",  "",  "Precio Final",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesCotizacion",  "",  "Cotización",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesDescuento",  "",  "Solicitud Descuento",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudServicioComALM",  "",  "Comisión Almango",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudServicioComALMP",  "",  "% Comisión Almango",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudServicioComPro",  "",  "Comisión Profesional",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudServicioComProP",  "",  "% Comisión Profesional",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudServicioComProv",  "",  "Comisión Comercio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudServicioComProvP",  "",  "% Comisión Comercio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesCostoXZComAlm",  "",  "Almango xZona",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesCostoXZComAlmP",  "",  "% Almango xZona",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesCostoXZComProf",  "",  "Profesional xZona",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesCostoXZComProfP",  "",  "% Profesional xZona",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesCostoXZona",  "",  "Total xZona",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "CancelacionTipificacionDescripcion",  "",  "Tipo Cancelación",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesNota",  "",  "Nota",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesComentario",  "",  "Comentario",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesOtros2",  "",  "Otros2",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesOtros3",  "",  "Otros3",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "&UserAlta",  "",  "Usuario Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "&UserUPD",  "",  "Usuario Modificación",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesFechaAlta",  "",  "Fecha Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV51ColumnsSelector,  "SolicitudesFechaActualizacion",  "",  "Fecha Modificación",  true,  "") ;
         GXt_char2 = AV55UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "SolicitudesReporteWWColumnsSelector", out  GXt_char2) ;
         AV55UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55UserCustomValue)) ) )
         {
            AV52ColumnsSelectorAux.FromXml(AV55UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV52ColumnsSelectorAux, ref  AV51ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV47Session.Get("SolicitudesReporteWWGridState"), "") == 0 )
         {
            AV49GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SolicitudesReporteWWGridState"), null, "", "");
         }
         else
         {
            AV49GridState.FromXml(AV47Session.Get("SolicitudesReporteWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV49GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV49GridState.gxTpr_Ordereddsc;
         AV262GXV6 = 1;
         while ( AV262GXV6 <= AV49GridState.gxTpr_Filtervalues.Count )
         {
            AV50GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV49GridState.gxTpr_Filtervalues.Item(AV262GXV6));
            if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "SOLICITUDESFECHAINSTALACION") == 0 )
            {
               AV178SolicitudesFechaInstalacion = context.localUtil.CToD( AV50GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV179SolicitudesFechaInstalacion_To = context.localUtil.CToD( AV50GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESID") == 0 )
            {
               AV62TFSolicitudesID = (long)(Math.Round(NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV63TFSolicitudesID_To = (long)(Math.Round(NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESSUBTIPO_SEL") == 0 )
            {
               AV117TFSolicitudesSubTipo_SelsJson = AV50GridStateFilterValue.gxTpr_Value;
               AV119TFSolicitudesSubTipo_Sels.FromJSonString(AV117TFSolicitudesSubTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFESTADOSSOLNOMBRE") == 0 )
            {
               AV122TFEstadosSolNombre = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFESTADOSSOLNOMBRE_SEL") == 0 )
            {
               AV123TFEstadosSolNombre_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV70TFProveedorNombre = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV71TFProveedorNombre_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESNOMBRE") == 0 )
            {
               AV64TFSolicitudesNombre = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESNOMBRE_SEL") == 0 )
            {
               AV65TFSolicitudesNombre_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESTELEFONO") == 0 )
            {
               AV90TFSolicitudesTelefono = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESTELEFONO_SEL") == 0 )
            {
               AV91TFSolicitudesTelefono_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESMAIL") == 0 )
            {
               AV92TFSolicitudesMail = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESMAIL_SEL") == 0 )
            {
               AV93TFSolicitudesMail_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFPAISID") == 0 )
            {
               AV94TFPaisID = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFPAISID_SEL") == 0 )
            {
               AV95TFPaisID_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTODEPARTAMENTO") == 0 )
            {
               AV98TFDepartamentoDepartamento = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTODEPARTAMENTO_SEL") == 0 )
            {
               AV99TFDepartamentoDepartamento_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE") == 0 )
            {
               AV102TFDepartamentoMunicipioNombre = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE_SEL") == 0 )
            {
               AV103TFDepartamentoMunicipioNombre_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESDIRECCION") == 0 )
            {
               AV106TFSolicitudesDireccion = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESDIRECCION_SEL") == 0 )
            {
               AV107TFSolicitudesDireccion_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOORIGENPAGO_SEL") == 0 )
            {
               AV124TFSolicitudServicioOrigenPago_SelsJson = AV50GridStateFilterValue.gxTpr_Value;
               AV126TFSolicitudServicioOrigenPago_Sels.FromJSonString(AV124TFSolicitudServicioOrigenPago_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSNOMBRE") == 0 )
            {
               AV127TFMetodoPagosNombre = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSNOMBRE_SEL") == 0 )
            {
               AV128TFMetodoPagosNombre_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESPAGADO_SEL") == 0 )
            {
               AV129TFSolicitudesPagado_SelsJson = AV50GridStateFilterValue.gxTpr_Value;
               AV131TFSolicitudesPagado_Sels.FromJSonString(AV129TFSolicitudesPagado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOPFINAL") == 0 )
            {
               AV132TFSolicitudServicioPFinal = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Value, ".");
               AV133TFSolicitudServicioPFinal_To = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOTIZACION") == 0 )
            {
               AV134TFSolicitudesCotizacion = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Value, ".");
               AV135TFSolicitudesCotizacion_To = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESDESCUENTO") == 0 )
            {
               AV136TFSolicitudesDescuento = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Value, ".");
               AV137TFSolicitudesDescuento_To = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOCOMALM") == 0 )
            {
               AV138TFSolicitudServicioComALM = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Value, ".");
               AV139TFSolicitudServicioComALM_To = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOCOMALMP") == 0 )
            {
               AV140TFSolicitudServicioComALMP = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Value, ".");
               AV141TFSolicitudServicioComALMP_To = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOCOMPRO") == 0 )
            {
               AV142TFSolicitudServicioComPro = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Value, ".");
               AV143TFSolicitudServicioComPro_To = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOCOMPROP") == 0 )
            {
               AV144TFSolicitudServicioComProP = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Value, ".");
               AV145TFSolicitudServicioComProP_To = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOCOMPROV") == 0 )
            {
               AV146TFSolicitudServicioComProv = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Value, ".");
               AV147TFSolicitudServicioComProv_To = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOCOMPROVP") == 0 )
            {
               AV148TFSolicitudServicioComProvP = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Value, ".");
               AV149TFSolicitudServicioComProvP_To = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOSTOXZCOMALM") == 0 )
            {
               AV150TFSolicitudesCostoXZComAlm = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Value, ".");
               AV151TFSolicitudesCostoXZComAlm_To = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOSTOXZCOMALMP") == 0 )
            {
               AV152TFSolicitudesCostoXZComAlmP = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Value, ".");
               AV153TFSolicitudesCostoXZComAlmP_To = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOSTOXZCOMPROF") == 0 )
            {
               AV154TFSolicitudesCostoXZComProf = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Value, ".");
               AV155TFSolicitudesCostoXZComProf_To = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOSTOXZCOMPROFP") == 0 )
            {
               AV156TFSolicitudesCostoXZComProfP = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Value, ".");
               AV157TFSolicitudesCostoXZComProfP_To = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOSTOXZONA") == 0 )
            {
               AV158TFSolicitudesCostoXZona = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Value, ".");
               AV159TFSolicitudesCostoXZona_To = NumberUtil.Val( AV50GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFCANCELACIONTIPIFICACIONDESCRIPCION") == 0 )
            {
               AV182TFCancelacionTipificacionDescripcion = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFCANCELACIONTIPIFICACIONDESCRIPCION_SEL") == 0 )
            {
               AV183TFCancelacionTipificacionDescripcion_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESNOTA") == 0 )
            {
               AV160TFSolicitudesNota = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESNOTA_SEL") == 0 )
            {
               AV161TFSolicitudesNota_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOMENTARIO") == 0 )
            {
               AV162TFSolicitudesComentario = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOMENTARIO_SEL") == 0 )
            {
               AV163TFSolicitudesComentario_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESOTROS2") == 0 )
            {
               AV164TFSolicitudesOtros2 = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESOTROS2_SEL") == 0 )
            {
               AV165TFSolicitudesOtros2_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESOTROS3") == 0 )
            {
               AV166TFSolicitudesOtros3 = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESOTROS3_SEL") == 0 )
            {
               AV167TFSolicitudesOtros3_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESFECHAALTA") == 0 )
            {
               AV168TFSolicitudesFechaAlta = context.localUtil.CToD( AV50GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV169TFSolicitudesFechaAlta_To = context.localUtil.CToD( AV50GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESFECHAACTUALIZACION") == 0 )
            {
               AV170TFSolicitudesFechaActualizacion = context.localUtil.CToT( AV50GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV171TFSolicitudesFechaActualizacion_To = context.localUtil.CToT( AV50GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV262GXV6 = (int)(AV262GXV6+1);
         }
      }

      protected void S172( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S182( )
      {
         /* 'AFTERWRITELINE' Routine */
         returnInSub = false;
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00L45 */
         pr_default.execute(3, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(3) != 101) && ( P00L45_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00L45_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00L45_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00L45_A176SolicitudesItemsPrecioFinal[0]*P00L45_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00L45_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00L45_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00L45_A176SolicitudesItemsPrecioFinal[0]*P00L45_A177SolicitudesItemsCantidad[0])-(P00L45_A180SolicitudItemsComision[0]*P00L45_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00L45_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00L45_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00L45_A176SolicitudesItemsPrecioFinal[0]*P00L45_A177SolicitudesItemsCantidad[0])+(P00L45_A180SolicitudItemsComision[0]*P00L45_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00L45_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00L45_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00L45_A176SolicitudesItemsPrecioFinal[0]*P00L45_A177SolicitudesItemsCantidad[0])-((P00L45_A176SolicitudesItemsPrecioFinal[0]*P00L45_A177SolicitudesItemsCantidad[0])*(P00L45_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00L45_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00L45_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00L45_A176SolicitudesItemsPrecioFinal[0]*P00L45_A177SolicitudesItemsCantidad[0])+((P00L45_A176SolicitudesItemsPrecioFinal[0]*P00L45_A177SolicitudesItemsCantidad[0])*(P00L45_A180SolicitudItemsComision[0]/ (decimal)(100))));
                        }
                        else
                        {
                           A175SolicitudesItemsPrecioInstalac = 0;
                        }
                     }
                  }
               }
            }
            A174SolicitudesTotal = (decimal)(A174SolicitudesTotal+A175SolicitudesItemsPrecioInstalac);
            pr_default.readNext(3);
         }
         pr_default.close(3);
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
         AV12Filename = "";
         AV13ErrorMessage = "";
         AV184Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV178SolicitudesFechaInstalacion = DateTime.MinValue;
         AV179SolicitudesFechaInstalacion_To = DateTime.MinValue;
         AV119TFSolicitudesSubTipo_Sels = new GxSimpleCollection<string>();
         AV118TFSolicitudesSubTipo_Sel = "";
         AV123TFEstadosSolNombre_Sel = "";
         AV122TFEstadosSolNombre = "";
         AV71TFProveedorNombre_Sel = "";
         AV70TFProveedorNombre = "";
         AV65TFSolicitudesNombre_Sel = "";
         AV64TFSolicitudesNombre = "";
         AV91TFSolicitudesTelefono_Sel = "";
         AV90TFSolicitudesTelefono = "";
         AV93TFSolicitudesMail_Sel = "";
         AV92TFSolicitudesMail = "";
         AV95TFPaisID_Sel = "";
         AV94TFPaisID = "";
         AV99TFDepartamentoDepartamento_Sel = "";
         AV98TFDepartamentoDepartamento = "";
         AV103TFDepartamentoMunicipioNombre_Sel = "";
         AV102TFDepartamentoMunicipioNombre = "";
         AV107TFSolicitudesDireccion_Sel = "";
         AV106TFSolicitudesDireccion = "";
         AV126TFSolicitudServicioOrigenPago_Sels = new GxSimpleCollection<string>();
         AV125TFSolicitudServicioOrigenPago_Sel = "";
         AV128TFMetodoPagosNombre_Sel = "";
         AV127TFMetodoPagosNombre = "";
         AV131TFSolicitudesPagado_Sels = new GxSimpleCollection<string>();
         AV130TFSolicitudesPagado_Sel = "";
         AV183TFCancelacionTipificacionDescripcion_Sel = "";
         AV182TFCancelacionTipificacionDescripcion = "";
         AV161TFSolicitudesNota_Sel = "";
         AV160TFSolicitudesNota = "";
         AV163TFSolicitudesComentario_Sel = "";
         AV162TFSolicitudesComentario = "";
         AV165TFSolicitudesOtros2_Sel = "";
         AV164TFSolicitudesOtros2 = "";
         AV167TFSolicitudesOtros3_Sel = "";
         AV166TFSolicitudesOtros3 = "";
         AV168TFSolicitudesFechaAlta = DateTime.MinValue;
         AV169TFSolicitudesFechaAlta_To = DateTime.MinValue;
         AV170TFSolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         AV171TFSolicitudesFechaActualizacion_To = (DateTime)(DateTime.MinValue);
         AV47Session = context.GetSession();
         AV54ColumnsSelectorXML = "";
         AV51ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV53ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV190Solicitudesreportewwds_1_solicitudesfechainstalacion = DateTime.MinValue;
         AV191Solicitudesreportewwds_2_solicitudesfechainstalacion_to = DateTime.MinValue;
         AV194Solicitudesreportewwds_5_tfsolicitudessubtipo_sels = new GxSimpleCollection<string>();
         AV195Solicitudesreportewwds_6_tfestadossolnombre = "";
         AV196Solicitudesreportewwds_7_tfestadossolnombre_sel = "";
         AV197Solicitudesreportewwds_8_tfproveedornombre = "";
         AV198Solicitudesreportewwds_9_tfproveedornombre_sel = "";
         AV199Solicitudesreportewwds_10_tfsolicitudesnombre = "";
         AV200Solicitudesreportewwds_11_tfsolicitudesnombre_sel = "";
         AV201Solicitudesreportewwds_12_tfsolicitudestelefono = "";
         AV202Solicitudesreportewwds_13_tfsolicitudestelefono_sel = "";
         AV203Solicitudesreportewwds_14_tfsolicitudesmail = "";
         AV204Solicitudesreportewwds_15_tfsolicitudesmail_sel = "";
         AV205Solicitudesreportewwds_16_tfpaisid = "";
         AV206Solicitudesreportewwds_17_tfpaisid_sel = "";
         AV207Solicitudesreportewwds_18_tfdepartamentodepartamento = "";
         AV208Solicitudesreportewwds_19_tfdepartamentodepartamento_sel = "";
         AV209Solicitudesreportewwds_20_tfdepartamentomunicipionombre = "";
         AV210Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel = "";
         AV211Solicitudesreportewwds_22_tfsolicitudesdireccion = "";
         AV212Solicitudesreportewwds_23_tfsolicitudesdireccion_sel = "";
         AV213Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels = new GxSimpleCollection<string>();
         AV214Solicitudesreportewwds_25_tfmetodopagosnombre = "";
         AV215Solicitudesreportewwds_26_tfmetodopagosnombre_sel = "";
         AV216Solicitudesreportewwds_27_tfsolicitudespagado_sels = new GxSimpleCollection<string>();
         AV245Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion = "";
         AV246Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel = "";
         AV247Solicitudesreportewwds_58_tfsolicitudesnota = "";
         AV248Solicitudesreportewwds_59_tfsolicitudesnota_sel = "";
         AV249Solicitudesreportewwds_60_tfsolicitudescomentario = "";
         AV250Solicitudesreportewwds_61_tfsolicitudescomentario_sel = "";
         AV251Solicitudesreportewwds_62_tfsolicitudesotros2 = "";
         AV252Solicitudesreportewwds_63_tfsolicitudesotros2_sel = "";
         AV253Solicitudesreportewwds_64_tfsolicitudesotros3 = "";
         AV254Solicitudesreportewwds_65_tfsolicitudesotros3_sel = "";
         AV255Solicitudesreportewwds_66_tfsolicitudesfechaalta = DateTime.MinValue;
         AV256Solicitudesreportewwds_67_tfsolicitudesfechaalta_to = DateTime.MinValue;
         AV257Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion = (DateTime)(DateTime.MinValue);
         AV258Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to = (DateTime)(DateTime.MinValue);
         lV195Solicitudesreportewwds_6_tfestadossolnombre = "";
         lV197Solicitudesreportewwds_8_tfproveedornombre = "";
         lV199Solicitudesreportewwds_10_tfsolicitudesnombre = "";
         lV201Solicitudesreportewwds_12_tfsolicitudestelefono = "";
         lV203Solicitudesreportewwds_14_tfsolicitudesmail = "";
         lV205Solicitudesreportewwds_16_tfpaisid = "";
         lV207Solicitudesreportewwds_18_tfdepartamentodepartamento = "";
         lV209Solicitudesreportewwds_20_tfdepartamentomunicipionombre = "";
         lV211Solicitudesreportewwds_22_tfsolicitudesdireccion = "";
         lV214Solicitudesreportewwds_25_tfmetodopagosnombre = "";
         lV245Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion = "";
         lV247Solicitudesreportewwds_58_tfsolicitudesnota = "";
         lV249Solicitudesreportewwds_60_tfsolicitudescomentario = "";
         lV251Solicitudesreportewwds_62_tfsolicitudesotros2 = "";
         lV253Solicitudesreportewwds_64_tfsolicitudesotros3 = "";
         A600SolicitudesSubTipo = "";
         A438SolicitudServicioOrigenPago = "";
         A441SolicitudesPagado = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A132EstadosSolNombre = "";
         A282ProveedorNombre = "";
         A171SolicitudesNombre = "";
         A172SolicitudesTelefono = "";
         A206SolicitudesMail = "";
         A116PaisID = "";
         A113DepartamentoDepartamento = "";
         A115DepartamentoMunicipioNombre = "";
         A173SolicitudesDireccion = "";
         A129MetodoPagosNombre = "";
         A997CancelacionTipificacionDescrip = "";
         A261SolicitudesNota = "";
         A205SolicitudesComentario = "";
         A202SolicitudesOtros2 = "";
         A203SolicitudesOtros3 = "";
         A182SolicitudesFechaAlta = DateTime.MinValue;
         A204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         P00L42_A112DepartamentoId = new long[1] ;
         P00L42_n112DepartamentoId = new bool[] {false} ;
         P00L42_A114DepartamentoMunicipioId = new long[1] ;
         P00L42_n114DepartamentoMunicipioId = new bool[] {false} ;
         P00L42_A128MetodoPagosID = new long[1] ;
         P00L42_A133ProveedorID = new long[1] ;
         P00L42_A996CancelacionTipificacionId = new long[1] ;
         P00L42_A130EstadosSolTipo = new string[] {""} ;
         P00L42_A131EstadosSolId = new int[1] ;
         P00L42_A598SolicitudesUsrActualizacion = new long[1] ;
         P00L42_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         P00L42_A597SolicitudesUsrAlta = new long[1] ;
         P00L42_n597SolicitudesUsrAlta = new bool[] {false} ;
         P00L42_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P00L42_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         P00L42_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00L42_n182SolicitudesFechaAlta = new bool[] {false} ;
         P00L42_A203SolicitudesOtros3 = new string[] {""} ;
         P00L42_A202SolicitudesOtros2 = new string[] {""} ;
         P00L42_A205SolicitudesComentario = new string[] {""} ;
         P00L42_A261SolicitudesNota = new string[] {""} ;
         P00L42_A997CancelacionTipificacionDescrip = new string[] {""} ;
         P00L42_A441SolicitudesPagado = new string[] {""} ;
         P00L42_n441SolicitudesPagado = new bool[] {false} ;
         P00L42_A129MetodoPagosNombre = new string[] {""} ;
         P00L42_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00L42_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00L42_A173SolicitudesDireccion = new string[] {""} ;
         P00L42_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P00L42_A113DepartamentoDepartamento = new string[] {""} ;
         P00L42_A116PaisID = new string[] {""} ;
         P00L42_A206SolicitudesMail = new string[] {""} ;
         P00L42_n206SolicitudesMail = new bool[] {false} ;
         P00L42_A172SolicitudesTelefono = new string[] {""} ;
         P00L42_A171SolicitudesNombre = new string[] {""} ;
         P00L42_A282ProveedorNombre = new string[] {""} ;
         P00L42_A132EstadosSolNombre = new string[] {""} ;
         P00L42_A600SolicitudesSubTipo = new string[] {""} ;
         P00L42_n600SolicitudesSubTipo = new bool[] {false} ;
         P00L42_A127SolicitudesID = new long[1] ;
         P00L42_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00L42_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00L42_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00L42_A212SolicitudesCotizacion = new decimal[1] ;
         P00L42_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00L42_A897SolicitudesDescuento = new decimal[1] ;
         P00L42_n897SolicitudesDescuento = new bool[] {false} ;
         P00L42_A527SolicitudServicioComProv = new decimal[1] ;
         P00L42_n527SolicitudServicioComProv = new bool[] {false} ;
         P00L42_A530SolicitudServicioComALM = new decimal[1] ;
         P00L42_n530SolicitudServicioComALM = new bool[] {false} ;
         P00L42_A532SolicitudServicioComALMP = new decimal[1] ;
         P00L42_n532SolicitudServicioComALMP = new bool[] {false} ;
         P00L42_A528SolicitudServicioComProvP = new decimal[1] ;
         P00L42_n528SolicitudServicioComProvP = new bool[] {false} ;
         P00L42_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         P00L42_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         P00L42_A864SolicitudesCostoXZona = new decimal[1] ;
         P00L42_A866SolicitudesCostoXZComAlmP = new decimal[1] ;
         P00L42_n866SolicitudesCostoXZComAlmP = new bool[] {false} ;
         A130EstadosSolTipo = "";
         A183SolicitudesHoraInstalacion = "";
         AV175ProfesionalId = "";
         AV176Profesional = "";
         AV177Existe = "";
         AV113HoraInstalacion = "";
         AV114Dia = "";
         P00L43_A18SecUserId = new long[1] ;
         P00L43_A26SecUserName = new string[] {""} ;
         A26SecUserName = "";
         AV115UserAlta = "";
         P00L44_A18SecUserId = new long[1] ;
         P00L44_A26SecUserName = new string[] {""} ;
         AV116UserUPD = "";
         GXt_dtime4 = (DateTime)(DateTime.MinValue);
         AV55UserCustomValue = "";
         GXt_char2 = "";
         AV52ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV49GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV50GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV117TFSolicitudesSubTipo_SelsJson = "";
         AV124TFSolicitudServicioOrigenPago_SelsJson = "";
         AV129TFSolicitudesPagado_SelsJson = "";
         P00L45_A127SolicitudesID = new long[1] ;
         P00L45_A134SolicitudesItemsID = new short[1] ;
         P00L45_A180SolicitudItemsComision = new decimal[1] ;
         P00L45_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00L45_A178SolicitudItemsSR = new string[] {""} ;
         P00L45_A177SolicitudesItemsCantidad = new short[1] ;
         P00L45_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00L45_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.solicitudesreportewwexport__default(),
            new Object[][] {
                new Object[] {
               P00L42_A112DepartamentoId, P00L42_n112DepartamentoId, P00L42_A114DepartamentoMunicipioId, P00L42_n114DepartamentoMunicipioId, P00L42_A128MetodoPagosID, P00L42_A133ProveedorID, P00L42_A996CancelacionTipificacionId, P00L42_A130EstadosSolTipo, P00L42_A131EstadosSolId, P00L42_A598SolicitudesUsrActualizacion,
               P00L42_n598SolicitudesUsrActualizacion, P00L42_A597SolicitudesUsrAlta, P00L42_n597SolicitudesUsrAlta, P00L42_A204SolicitudesFechaActualizacion, P00L42_n204SolicitudesFechaActualizacion, P00L42_A182SolicitudesFechaAlta, P00L42_n182SolicitudesFechaAlta, P00L42_A203SolicitudesOtros3, P00L42_A202SolicitudesOtros2, P00L42_A205SolicitudesComentario,
               P00L42_A261SolicitudesNota, P00L42_A997CancelacionTipificacionDescrip, P00L42_A441SolicitudesPagado, P00L42_n441SolicitudesPagado, P00L42_A129MetodoPagosNombre, P00L42_A438SolicitudServicioOrigenPago, P00L42_n438SolicitudServicioOrigenPago, P00L42_A173SolicitudesDireccion, P00L42_A115DepartamentoMunicipioNombre, P00L42_A113DepartamentoDepartamento,
               P00L42_A116PaisID, P00L42_A206SolicitudesMail, P00L42_n206SolicitudesMail, P00L42_A172SolicitudesTelefono, P00L42_A171SolicitudesNombre, P00L42_A282ProveedorNombre, P00L42_A132EstadosSolNombre, P00L42_A600SolicitudesSubTipo, P00L42_n600SolicitudesSubTipo, P00L42_A127SolicitudesID,
               P00L42_A184SolicitudesFechaInstalacion, P00L42_A183SolicitudesHoraInstalacion, P00L42_A796SolicitudesComisionMetodoPago, P00L42_A212SolicitudesCotizacion, P00L42_A1016SolicitudesDescuentoCupon, P00L42_A897SolicitudesDescuento, P00L42_n897SolicitudesDescuento, P00L42_A527SolicitudServicioComProv, P00L42_n527SolicitudServicioComProv, P00L42_A530SolicitudServicioComALM,
               P00L42_n530SolicitudServicioComALM, P00L42_A532SolicitudServicioComALMP, P00L42_n532SolicitudServicioComALMP, P00L42_A528SolicitudServicioComProvP, P00L42_n528SolicitudServicioComProvP, P00L42_A865SolicitudesCostoXZComAlm, P00L42_n865SolicitudesCostoXZComAlm, P00L42_A864SolicitudesCostoXZona, P00L42_A866SolicitudesCostoXZComAlmP, P00L42_n866SolicitudesCostoXZComAlmP
               }
               , new Object[] {
               P00L43_A18SecUserId, P00L43_A26SecUserName
               }
               , new Object[] {
               P00L44_A18SecUserId, P00L44_A26SecUserName
               }
               , new Object[] {
               P00L45_A127SolicitudesID, P00L45_A134SolicitudesItemsID, P00L45_A180SolicitudItemsComision, P00L45_A179SolicitudItemsComisionTipo, P00L45_A178SolicitudItemsSR, P00L45_A177SolicitudesItemsCantidad, P00L45_A176SolicitudesItemsPrecioFinal, P00L45_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         AV184Pgmname = "SolicitudesReporteWWExport";
         /* GeneXus formulas. */
         AV184Pgmname = "SolicitudesReporteWWExport";
      }

      private short GXt_int3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV185GXV1 ;
      private int AV186GXV2 ;
      private int AV187GXV3 ;
      private int AV188GXV4 ;
      private int AV194Solicitudesreportewwds_5_tfsolicitudessubtipo_sels_Count ;
      private int AV213Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels_Count ;
      private int AV216Solicitudesreportewwds_27_tfsolicitudespagado_sels_Count ;
      private int A131EstadosSolId ;
      private int AV259GXV5 ;
      private int AV262GXV6 ;
      private long AV62TFSolicitudesID ;
      private long AV63TFSolicitudesID_To ;
      private long AV112i ;
      private long AV59VisibleColumnCount ;
      private long AV192Solicitudesreportewwds_3_tfsolicitudesid ;
      private long AV193Solicitudesreportewwds_4_tfsolicitudesid_to ;
      private long A127SolicitudesID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A128MetodoPagosID ;
      private long A133ProveedorID ;
      private long A996CancelacionTipificacionId ;
      private long A598SolicitudesUsrActualizacion ;
      private long A597SolicitudesUsrAlta ;
      private long A18SecUserId ;
      private decimal AV132TFSolicitudServicioPFinal ;
      private decimal AV133TFSolicitudServicioPFinal_To ;
      private decimal AV134TFSolicitudesCotizacion ;
      private decimal AV135TFSolicitudesCotizacion_To ;
      private decimal AV136TFSolicitudesDescuento ;
      private decimal AV137TFSolicitudesDescuento_To ;
      private decimal AV138TFSolicitudServicioComALM ;
      private decimal AV139TFSolicitudServicioComALM_To ;
      private decimal AV140TFSolicitudServicioComALMP ;
      private decimal AV141TFSolicitudServicioComALMP_To ;
      private decimal AV142TFSolicitudServicioComPro ;
      private decimal AV143TFSolicitudServicioComPro_To ;
      private decimal AV144TFSolicitudServicioComProP ;
      private decimal AV145TFSolicitudServicioComProP_To ;
      private decimal AV146TFSolicitudServicioComProv ;
      private decimal AV147TFSolicitudServicioComProv_To ;
      private decimal AV148TFSolicitudServicioComProvP ;
      private decimal AV149TFSolicitudServicioComProvP_To ;
      private decimal AV150TFSolicitudesCostoXZComAlm ;
      private decimal AV151TFSolicitudesCostoXZComAlm_To ;
      private decimal AV152TFSolicitudesCostoXZComAlmP ;
      private decimal AV153TFSolicitudesCostoXZComAlmP_To ;
      private decimal AV154TFSolicitudesCostoXZComProf ;
      private decimal AV155TFSolicitudesCostoXZComProf_To ;
      private decimal AV156TFSolicitudesCostoXZComProfP ;
      private decimal AV157TFSolicitudesCostoXZComProfP_To ;
      private decimal AV158TFSolicitudesCostoXZona ;
      private decimal AV159TFSolicitudesCostoXZona_To ;
      private decimal AV217Solicitudesreportewwds_28_tfsolicitudserviciopfinal ;
      private decimal AV218Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to ;
      private decimal AV219Solicitudesreportewwds_30_tfsolicitudescotizacion ;
      private decimal AV220Solicitudesreportewwds_31_tfsolicitudescotizacion_to ;
      private decimal AV221Solicitudesreportewwds_32_tfsolicitudesdescuento ;
      private decimal AV222Solicitudesreportewwds_33_tfsolicitudesdescuento_to ;
      private decimal AV223Solicitudesreportewwds_34_tfsolicitudserviciocomalm ;
      private decimal AV224Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to ;
      private decimal AV225Solicitudesreportewwds_36_tfsolicitudserviciocomalmp ;
      private decimal AV226Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to ;
      private decimal AV227Solicitudesreportewwds_38_tfsolicitudserviciocompro ;
      private decimal AV228Solicitudesreportewwds_39_tfsolicitudserviciocompro_to ;
      private decimal AV229Solicitudesreportewwds_40_tfsolicitudserviciocomprop ;
      private decimal AV230Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to ;
      private decimal AV231Solicitudesreportewwds_42_tfsolicitudserviciocomprov ;
      private decimal AV232Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to ;
      private decimal AV233Solicitudesreportewwds_44_tfsolicitudserviciocomprovp ;
      private decimal AV234Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to ;
      private decimal AV235Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm ;
      private decimal AV236Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to ;
      private decimal AV237Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp ;
      private decimal AV238Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to ;
      private decimal AV239Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof ;
      private decimal AV240Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to ;
      private decimal AV241Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp ;
      private decimal AV242Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to ;
      private decimal AV243Solicitudesreportewwds_54_tfsolicitudescostoxzona ;
      private decimal AV244Solicitudesreportewwds_55_tfsolicitudescostoxzona_to ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A897SolicitudesDescuento ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A532SolicitudServicioComALMP ;
      private decimal A528SolicitudServicioComProvP ;
      private decimal A527SolicitudServicioComProv ;
      private decimal A865SolicitudesCostoXZComAlm ;
      private decimal A866SolicitudesCostoXZComAlmP ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A529SolicitudServicioComPro ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A868SolicitudesCostoXZComProfP ;
      private decimal A867SolicitudesCostoXZComProf ;
      private decimal A531SolicitudServicioComProP ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV184Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV118TFSolicitudesSubTipo_Sel ;
      private string AV123TFEstadosSolNombre_Sel ;
      private string AV122TFEstadosSolNombre ;
      private string AV71TFProveedorNombre_Sel ;
      private string AV70TFProveedorNombre ;
      private string AV65TFSolicitudesNombre_Sel ;
      private string AV64TFSolicitudesNombre ;
      private string AV91TFSolicitudesTelefono_Sel ;
      private string AV90TFSolicitudesTelefono ;
      private string AV95TFPaisID_Sel ;
      private string AV94TFPaisID ;
      private string AV99TFDepartamentoDepartamento_Sel ;
      private string AV98TFDepartamentoDepartamento ;
      private string AV103TFDepartamentoMunicipioNombre_Sel ;
      private string AV102TFDepartamentoMunicipioNombre ;
      private string AV125TFSolicitudServicioOrigenPago_Sel ;
      private string AV128TFMetodoPagosNombre_Sel ;
      private string AV127TFMetodoPagosNombre ;
      private string AV130TFSolicitudesPagado_Sel ;
      private string AV183TFCancelacionTipificacionDescripcion_Sel ;
      private string AV182TFCancelacionTipificacionDescripcion ;
      private string AV161TFSolicitudesNota_Sel ;
      private string AV160TFSolicitudesNota ;
      private string AV165TFSolicitudesOtros2_Sel ;
      private string AV164TFSolicitudesOtros2 ;
      private string AV167TFSolicitudesOtros3_Sel ;
      private string AV166TFSolicitudesOtros3 ;
      private string AV195Solicitudesreportewwds_6_tfestadossolnombre ;
      private string AV196Solicitudesreportewwds_7_tfestadossolnombre_sel ;
      private string AV197Solicitudesreportewwds_8_tfproveedornombre ;
      private string AV198Solicitudesreportewwds_9_tfproveedornombre_sel ;
      private string AV199Solicitudesreportewwds_10_tfsolicitudesnombre ;
      private string AV200Solicitudesreportewwds_11_tfsolicitudesnombre_sel ;
      private string AV201Solicitudesreportewwds_12_tfsolicitudestelefono ;
      private string AV202Solicitudesreportewwds_13_tfsolicitudestelefono_sel ;
      private string AV205Solicitudesreportewwds_16_tfpaisid ;
      private string AV206Solicitudesreportewwds_17_tfpaisid_sel ;
      private string AV207Solicitudesreportewwds_18_tfdepartamentodepartamento ;
      private string AV208Solicitudesreportewwds_19_tfdepartamentodepartamento_sel ;
      private string AV209Solicitudesreportewwds_20_tfdepartamentomunicipionombre ;
      private string AV210Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel ;
      private string AV214Solicitudesreportewwds_25_tfmetodopagosnombre ;
      private string AV215Solicitudesreportewwds_26_tfmetodopagosnombre_sel ;
      private string AV245Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion ;
      private string AV246Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel ;
      private string AV247Solicitudesreportewwds_58_tfsolicitudesnota ;
      private string AV248Solicitudesreportewwds_59_tfsolicitudesnota_sel ;
      private string AV251Solicitudesreportewwds_62_tfsolicitudesotros2 ;
      private string AV252Solicitudesreportewwds_63_tfsolicitudesotros2_sel ;
      private string AV253Solicitudesreportewwds_64_tfsolicitudesotros3 ;
      private string AV254Solicitudesreportewwds_65_tfsolicitudesotros3_sel ;
      private string lV195Solicitudesreportewwds_6_tfestadossolnombre ;
      private string lV197Solicitudesreportewwds_8_tfproveedornombre ;
      private string lV199Solicitudesreportewwds_10_tfsolicitudesnombre ;
      private string lV201Solicitudesreportewwds_12_tfsolicitudestelefono ;
      private string lV205Solicitudesreportewwds_16_tfpaisid ;
      private string lV207Solicitudesreportewwds_18_tfdepartamentodepartamento ;
      private string lV209Solicitudesreportewwds_20_tfdepartamentomunicipionombre ;
      private string lV214Solicitudesreportewwds_25_tfmetodopagosnombre ;
      private string lV245Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion ;
      private string lV247Solicitudesreportewwds_58_tfsolicitudesnota ;
      private string lV251Solicitudesreportewwds_62_tfsolicitudesotros2 ;
      private string lV253Solicitudesreportewwds_64_tfsolicitudesotros3 ;
      private string A600SolicitudesSubTipo ;
      private string A438SolicitudServicioOrigenPago ;
      private string A441SolicitudesPagado ;
      private string A132EstadosSolNombre ;
      private string A282ProveedorNombre ;
      private string A171SolicitudesNombre ;
      private string A172SolicitudesTelefono ;
      private string A116PaisID ;
      private string A113DepartamentoDepartamento ;
      private string A115DepartamentoMunicipioNombre ;
      private string A129MetodoPagosNombre ;
      private string A997CancelacionTipificacionDescrip ;
      private string A261SolicitudesNota ;
      private string A202SolicitudesOtros2 ;
      private string A203SolicitudesOtros3 ;
      private string A130EstadosSolTipo ;
      private string A183SolicitudesHoraInstalacion ;
      private string AV175ProfesionalId ;
      private string AV177Existe ;
      private string GXt_char2 ;
      private DateTime AV170TFSolicitudesFechaActualizacion ;
      private DateTime AV171TFSolicitudesFechaActualizacion_To ;
      private DateTime AV257Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion ;
      private DateTime AV258Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to ;
      private DateTime A204SolicitudesFechaActualizacion ;
      private DateTime GXt_dtime4 ;
      private DateTime AV178SolicitudesFechaInstalacion ;
      private DateTime AV179SolicitudesFechaInstalacion_To ;
      private DateTime AV168TFSolicitudesFechaAlta ;
      private DateTime AV169TFSolicitudesFechaAlta_To ;
      private DateTime AV190Solicitudesreportewwds_1_solicitudesfechainstalacion ;
      private DateTime AV191Solicitudesreportewwds_2_solicitudesfechainstalacion_to ;
      private DateTime AV255Solicitudesreportewwds_66_tfsolicitudesfechaalta ;
      private DateTime AV256Solicitudesreportewwds_67_tfsolicitudesfechaalta_to ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n598SolicitudesUsrActualizacion ;
      private bool n597SolicitudesUsrAlta ;
      private bool n204SolicitudesFechaActualizacion ;
      private bool n182SolicitudesFechaAlta ;
      private bool n441SolicitudesPagado ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n206SolicitudesMail ;
      private bool n600SolicitudesSubTipo ;
      private bool n897SolicitudesDescuento ;
      private bool n527SolicitudServicioComProv ;
      private bool n530SolicitudServicioComALM ;
      private bool n532SolicitudServicioComALMP ;
      private bool n528SolicitudServicioComProvP ;
      private bool n865SolicitudesCostoXZComAlm ;
      private bool n866SolicitudesCostoXZComAlmP ;
      private string AV54ColumnsSelectorXML ;
      private string A205SolicitudesComentario ;
      private string AV55UserCustomValue ;
      private string AV117TFSolicitudesSubTipo_SelsJson ;
      private string AV124TFSolicitudServicioOrigenPago_SelsJson ;
      private string AV129TFSolicitudesPagado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV93TFSolicitudesMail_Sel ;
      private string AV92TFSolicitudesMail ;
      private string AV107TFSolicitudesDireccion_Sel ;
      private string AV106TFSolicitudesDireccion ;
      private string AV163TFSolicitudesComentario_Sel ;
      private string AV162TFSolicitudesComentario ;
      private string AV203Solicitudesreportewwds_14_tfsolicitudesmail ;
      private string AV204Solicitudesreportewwds_15_tfsolicitudesmail_sel ;
      private string AV211Solicitudesreportewwds_22_tfsolicitudesdireccion ;
      private string AV212Solicitudesreportewwds_23_tfsolicitudesdireccion_sel ;
      private string AV249Solicitudesreportewwds_60_tfsolicitudescomentario ;
      private string AV250Solicitudesreportewwds_61_tfsolicitudescomentario_sel ;
      private string lV203Solicitudesreportewwds_14_tfsolicitudesmail ;
      private string lV211Solicitudesreportewwds_22_tfsolicitudesdireccion ;
      private string lV249Solicitudesreportewwds_60_tfsolicitudescomentario ;
      private string A206SolicitudesMail ;
      private string A173SolicitudesDireccion ;
      private string AV176Profesional ;
      private string AV113HoraInstalacion ;
      private string AV114Dia ;
      private string A26SecUserName ;
      private string AV115UserAlta ;
      private string AV116UserUPD ;
      private IGxSession AV47Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV119TFSolicitudesSubTipo_Sels ;
      private GxSimpleCollection<string> AV126TFSolicitudServicioOrigenPago_Sels ;
      private GxSimpleCollection<string> AV131TFSolicitudesPagado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV51ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV53ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV194Solicitudesreportewwds_5_tfsolicitudessubtipo_sels ;
      private GxSimpleCollection<string> AV213Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels ;
      private GxSimpleCollection<string> AV216Solicitudesreportewwds_27_tfsolicitudespagado_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P00L42_A112DepartamentoId ;
      private bool[] P00L42_n112DepartamentoId ;
      private long[] P00L42_A114DepartamentoMunicipioId ;
      private bool[] P00L42_n114DepartamentoMunicipioId ;
      private long[] P00L42_A128MetodoPagosID ;
      private long[] P00L42_A133ProveedorID ;
      private long[] P00L42_A996CancelacionTipificacionId ;
      private string[] P00L42_A130EstadosSolTipo ;
      private int[] P00L42_A131EstadosSolId ;
      private long[] P00L42_A598SolicitudesUsrActualizacion ;
      private bool[] P00L42_n598SolicitudesUsrActualizacion ;
      private long[] P00L42_A597SolicitudesUsrAlta ;
      private bool[] P00L42_n597SolicitudesUsrAlta ;
      private DateTime[] P00L42_A204SolicitudesFechaActualizacion ;
      private bool[] P00L42_n204SolicitudesFechaActualizacion ;
      private DateTime[] P00L42_A182SolicitudesFechaAlta ;
      private bool[] P00L42_n182SolicitudesFechaAlta ;
      private string[] P00L42_A203SolicitudesOtros3 ;
      private string[] P00L42_A202SolicitudesOtros2 ;
      private string[] P00L42_A205SolicitudesComentario ;
      private string[] P00L42_A261SolicitudesNota ;
      private string[] P00L42_A997CancelacionTipificacionDescrip ;
      private string[] P00L42_A441SolicitudesPagado ;
      private bool[] P00L42_n441SolicitudesPagado ;
      private string[] P00L42_A129MetodoPagosNombre ;
      private string[] P00L42_A438SolicitudServicioOrigenPago ;
      private bool[] P00L42_n438SolicitudServicioOrigenPago ;
      private string[] P00L42_A173SolicitudesDireccion ;
      private string[] P00L42_A115DepartamentoMunicipioNombre ;
      private string[] P00L42_A113DepartamentoDepartamento ;
      private string[] P00L42_A116PaisID ;
      private string[] P00L42_A206SolicitudesMail ;
      private bool[] P00L42_n206SolicitudesMail ;
      private string[] P00L42_A172SolicitudesTelefono ;
      private string[] P00L42_A171SolicitudesNombre ;
      private string[] P00L42_A282ProveedorNombre ;
      private string[] P00L42_A132EstadosSolNombre ;
      private string[] P00L42_A600SolicitudesSubTipo ;
      private bool[] P00L42_n600SolicitudesSubTipo ;
      private long[] P00L42_A127SolicitudesID ;
      private DateTime[] P00L42_A184SolicitudesFechaInstalacion ;
      private string[] P00L42_A183SolicitudesHoraInstalacion ;
      private decimal[] P00L42_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00L42_A212SolicitudesCotizacion ;
      private decimal[] P00L42_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00L42_A897SolicitudesDescuento ;
      private bool[] P00L42_n897SolicitudesDescuento ;
      private decimal[] P00L42_A527SolicitudServicioComProv ;
      private bool[] P00L42_n527SolicitudServicioComProv ;
      private decimal[] P00L42_A530SolicitudServicioComALM ;
      private bool[] P00L42_n530SolicitudServicioComALM ;
      private decimal[] P00L42_A532SolicitudServicioComALMP ;
      private bool[] P00L42_n532SolicitudServicioComALMP ;
      private decimal[] P00L42_A528SolicitudServicioComProvP ;
      private bool[] P00L42_n528SolicitudServicioComProvP ;
      private decimal[] P00L42_A865SolicitudesCostoXZComAlm ;
      private bool[] P00L42_n865SolicitudesCostoXZComAlm ;
      private decimal[] P00L42_A864SolicitudesCostoXZona ;
      private decimal[] P00L42_A866SolicitudesCostoXZComAlmP ;
      private bool[] P00L42_n866SolicitudesCostoXZComAlmP ;
      private long[] P00L43_A18SecUserId ;
      private string[] P00L43_A26SecUserName ;
      private long[] P00L44_A18SecUserId ;
      private string[] P00L44_A26SecUserName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV52ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV49GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV50GridStateFilterValue ;
      private long[] P00L45_A127SolicitudesID ;
      private short[] P00L45_A134SolicitudesItemsID ;
      private decimal[] P00L45_A180SolicitudItemsComision ;
      private string[] P00L45_A179SolicitudItemsComisionTipo ;
      private string[] P00L45_A178SolicitudItemsSR ;
      private short[] P00L45_A177SolicitudesItemsCantidad ;
      private decimal[] P00L45_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00L45_n176SolicitudesItemsPrecioFinal ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class solicitudesreportewwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00L42( IGxContext context ,
                                             string A600SolicitudesSubTipo ,
                                             GxSimpleCollection<string> AV194Solicitudesreportewwds_5_tfsolicitudessubtipo_sels ,
                                             string A438SolicitudServicioOrigenPago ,
                                             GxSimpleCollection<string> AV213Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels ,
                                             string A441SolicitudesPagado ,
                                             GxSimpleCollection<string> AV216Solicitudesreportewwds_27_tfsolicitudespagado_sels ,
                                             DateTime AV190Solicitudesreportewwds_1_solicitudesfechainstalacion ,
                                             DateTime AV191Solicitudesreportewwds_2_solicitudesfechainstalacion_to ,
                                             long AV192Solicitudesreportewwds_3_tfsolicitudesid ,
                                             long AV193Solicitudesreportewwds_4_tfsolicitudesid_to ,
                                             int AV194Solicitudesreportewwds_5_tfsolicitudessubtipo_sels_Count ,
                                             string AV196Solicitudesreportewwds_7_tfestadossolnombre_sel ,
                                             string AV195Solicitudesreportewwds_6_tfestadossolnombre ,
                                             string AV198Solicitudesreportewwds_9_tfproveedornombre_sel ,
                                             string AV197Solicitudesreportewwds_8_tfproveedornombre ,
                                             string AV200Solicitudesreportewwds_11_tfsolicitudesnombre_sel ,
                                             string AV199Solicitudesreportewwds_10_tfsolicitudesnombre ,
                                             string AV202Solicitudesreportewwds_13_tfsolicitudestelefono_sel ,
                                             string AV201Solicitudesreportewwds_12_tfsolicitudestelefono ,
                                             string AV204Solicitudesreportewwds_15_tfsolicitudesmail_sel ,
                                             string AV203Solicitudesreportewwds_14_tfsolicitudesmail ,
                                             string AV206Solicitudesreportewwds_17_tfpaisid_sel ,
                                             string AV205Solicitudesreportewwds_16_tfpaisid ,
                                             string AV208Solicitudesreportewwds_19_tfdepartamentodepartamento_sel ,
                                             string AV207Solicitudesreportewwds_18_tfdepartamentodepartamento ,
                                             string AV210Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel ,
                                             string AV209Solicitudesreportewwds_20_tfdepartamentomunicipionombre ,
                                             string AV212Solicitudesreportewwds_23_tfsolicitudesdireccion_sel ,
                                             string AV211Solicitudesreportewwds_22_tfsolicitudesdireccion ,
                                             int AV213Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels_Count ,
                                             string AV215Solicitudesreportewwds_26_tfmetodopagosnombre_sel ,
                                             string AV214Solicitudesreportewwds_25_tfmetodopagosnombre ,
                                             int AV216Solicitudesreportewwds_27_tfsolicitudespagado_sels_Count ,
                                             decimal AV219Solicitudesreportewwds_30_tfsolicitudescotizacion ,
                                             decimal AV220Solicitudesreportewwds_31_tfsolicitudescotizacion_to ,
                                             decimal AV221Solicitudesreportewwds_32_tfsolicitudesdescuento ,
                                             decimal AV222Solicitudesreportewwds_33_tfsolicitudesdescuento_to ,
                                             decimal AV223Solicitudesreportewwds_34_tfsolicitudserviciocomalm ,
                                             decimal AV224Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to ,
                                             decimal AV225Solicitudesreportewwds_36_tfsolicitudserviciocomalmp ,
                                             decimal AV226Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to ,
                                             decimal AV229Solicitudesreportewwds_40_tfsolicitudserviciocomprop ,
                                             decimal AV230Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to ,
                                             decimal AV231Solicitudesreportewwds_42_tfsolicitudserviciocomprov ,
                                             decimal AV232Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to ,
                                             decimal AV233Solicitudesreportewwds_44_tfsolicitudserviciocomprovp ,
                                             decimal AV234Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to ,
                                             decimal AV235Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm ,
                                             decimal AV236Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to ,
                                             decimal AV237Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp ,
                                             decimal AV238Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to ,
                                             decimal AV239Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof ,
                                             decimal AV240Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to ,
                                             decimal AV241Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp ,
                                             decimal AV242Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to ,
                                             decimal AV243Solicitudesreportewwds_54_tfsolicitudescostoxzona ,
                                             decimal AV244Solicitudesreportewwds_55_tfsolicitudescostoxzona_to ,
                                             string AV246Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel ,
                                             string AV245Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion ,
                                             string AV248Solicitudesreportewwds_59_tfsolicitudesnota_sel ,
                                             string AV247Solicitudesreportewwds_58_tfsolicitudesnota ,
                                             string AV250Solicitudesreportewwds_61_tfsolicitudescomentario_sel ,
                                             string AV249Solicitudesreportewwds_60_tfsolicitudescomentario ,
                                             string AV252Solicitudesreportewwds_63_tfsolicitudesotros2_sel ,
                                             string AV251Solicitudesreportewwds_62_tfsolicitudesotros2 ,
                                             string AV254Solicitudesreportewwds_65_tfsolicitudesotros3_sel ,
                                             string AV253Solicitudesreportewwds_64_tfsolicitudesotros3 ,
                                             DateTime AV255Solicitudesreportewwds_66_tfsolicitudesfechaalta ,
                                             DateTime AV256Solicitudesreportewwds_67_tfsolicitudesfechaalta_to ,
                                             DateTime AV257Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion ,
                                             DateTime AV258Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             long A127SolicitudesID ,
                                             string A132EstadosSolNombre ,
                                             string A282ProveedorNombre ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A206SolicitudesMail ,
                                             string A116PaisID ,
                                             string A113DepartamentoDepartamento ,
                                             string A115DepartamentoMunicipioNombre ,
                                             string A173SolicitudesDireccion ,
                                             string A129MetodoPagosNombre ,
                                             decimal A212SolicitudesCotizacion ,
                                             decimal A897SolicitudesDescuento ,
                                             decimal A530SolicitudServicioComALM ,
                                             decimal A532SolicitudServicioComALMP ,
                                             decimal A528SolicitudServicioComProvP ,
                                             decimal A527SolicitudServicioComProv ,
                                             decimal A865SolicitudesCostoXZComAlm ,
                                             decimal A866SolicitudesCostoXZComAlmP ,
                                             decimal A864SolicitudesCostoXZona ,
                                             string A997CancelacionTipificacionDescrip ,
                                             string A261SolicitudesNota ,
                                             string A205SolicitudesComentario ,
                                             string A202SolicitudesOtros2 ,
                                             string A203SolicitudesOtros3 ,
                                             DateTime A182SolicitudesFechaAlta ,
                                             DateTime A204SolicitudesFechaActualizacion ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             decimal AV217Solicitudesreportewwds_28_tfsolicitudserviciopfinal ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV218Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to ,
                                             decimal AV227Solicitudesreportewwds_38_tfsolicitudserviciocompro ,
                                             decimal A529SolicitudServicioComPro ,
                                             decimal AV228Solicitudesreportewwds_39_tfsolicitudserviciocompro_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[62];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T1.[MetodoPagosID], T1.[ProveedorID], T1.[CancelacionTipificacionId], T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[EstadosSolId] AS EstadosSolId, T1.[SolicitudesUsrActualizacion], T1.[SolicitudesUsrAlta], T1.[SolicitudesFechaActualizacion], T1.[SolicitudesFechaAlta], T1.[SolicitudesOtros3], T1.[SolicitudesOtros2], T1.[SolicitudesComentario], T1.[SolicitudesNota], T6.[CancelacionTipificacionDescrip], T1.[SolicitudesPagado], T4.[MetodoPagosNombre], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesDireccion], T3.[DepartamentoMunicipioNombre], T2.[DepartamentoDepartamento], T2.[PaisID], T1.[SolicitudesMail], T1.[SolicitudesTelefono], T1.[SolicitudesNombre], T5.[ProveedorNombre], T7.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudesSubTipo], T1.[SolicitudesID], T1.[SolicitudesFechaInstalacion], T1.[SolicitudesHoraInstalacion], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudServicioComProv], T1.[SolicitudServicioComALM], T1.[SolicitudServicioComALMP], T1.[SolicitudServicioComProvP], T1.[SolicitudesCostoXZComAlm], T1.[SolicitudesCostoXZona], T1.[SolicitudesCostoXZComAlmP] FROM (((((([Solicitudes] T1 LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) LEFT JOIN [DepartamentoMunicipio] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId] AND T3.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) INNER JOIN [MetodoPagos] T4 ON T4.[MetodoPagosID] = T1.[MetodoPagosID]) INNER JOIN [Proveedor] T5 ON T5.[ProveedorID] = T1.[ProveedorID]) INNER JOIN [CancelacionTipificacion] T6 ON T6.[CancelacionTipificacionId] = T1.[CancelacionTipificacionId]) INNER JOIN [EstadosGenericos] T7 ON T7.[EstadosTipo] = T1.[EstadosSolTipo]";
         scmdbuf += " AND T7.[EstadosGenericosId] = T1.[EstadosSolId])";
         if ( ! (DateTime.MinValue==AV190Solicitudesreportewwds_1_solicitudesfechainstalacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV190Solicitudesreportewwds_1_solicitudesfechainstalacion)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV191Solicitudesreportewwds_2_solicitudesfechainstalacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] <= @AV191Solicitudesreportewwds_2_solicitudesfechainstalacion_to)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (0==AV192Solicitudesreportewwds_3_tfsolicitudesid) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] >= @AV192Solicitudesreportewwds_3_tfsolicitudesid)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV193Solicitudesreportewwds_4_tfsolicitudesid_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] <= @AV193Solicitudesreportewwds_4_tfsolicitudesid_to)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV194Solicitudesreportewwds_5_tfsolicitudessubtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV194Solicitudesreportewwds_5_tfsolicitudessubtipo_sels, "T1.[SolicitudesSubTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV196Solicitudesreportewwds_7_tfestadossolnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV195Solicitudesreportewwds_6_tfestadossolnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T7.[EstadosGenericosNombre]) like UPPER(@lV195Solicitudesreportewwds_6_tfestadossolnombre))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV196Solicitudesreportewwds_7_tfestadossolnombre_sel)) && ! ( StringUtil.StrCmp(AV196Solicitudesreportewwds_7_tfestadossolnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T7.[EstadosGenericosNombre] = @AV196Solicitudesreportewwds_7_tfestadossolnombre_sel)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV196Solicitudesreportewwds_7_tfestadossolnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T7.[EstadosGenericosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV198Solicitudesreportewwds_9_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV197Solicitudesreportewwds_8_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T5.[ProveedorNombre]) like UPPER(@lV197Solicitudesreportewwds_8_tfproveedornombre))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV198Solicitudesreportewwds_9_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV198Solicitudesreportewwds_9_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] = @AV198Solicitudesreportewwds_9_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV198Solicitudesreportewwds_9_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T5.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV200Solicitudesreportewwds_11_tfsolicitudesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV199Solicitudesreportewwds_10_tfsolicitudesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesNombre]) like UPPER(@lV199Solicitudesreportewwds_10_tfsolicitudesnombre))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV200Solicitudesreportewwds_11_tfsolicitudesnombre_sel)) && ! ( StringUtil.StrCmp(AV200Solicitudesreportewwds_11_tfsolicitudesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesNombre] = @AV200Solicitudesreportewwds_11_tfsolicitudesnombre_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV200Solicitudesreportewwds_11_tfsolicitudesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV202Solicitudesreportewwds_13_tfsolicitudestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV201Solicitudesreportewwds_12_tfsolicitudestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesTelefono]) like UPPER(@lV201Solicitudesreportewwds_12_tfsolicitudestelefono))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV202Solicitudesreportewwds_13_tfsolicitudestelefono_sel)) && ! ( StringUtil.StrCmp(AV202Solicitudesreportewwds_13_tfsolicitudestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesTelefono] = @AV202Solicitudesreportewwds_13_tfsolicitudestelefono_sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV202Solicitudesreportewwds_13_tfsolicitudestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV204Solicitudesreportewwds_15_tfsolicitudesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV203Solicitudesreportewwds_14_tfsolicitudesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesMail]) like UPPER(@lV203Solicitudesreportewwds_14_tfsolicitudesmail))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV204Solicitudesreportewwds_15_tfsolicitudesmail_sel)) && ! ( StringUtil.StrCmp(AV204Solicitudesreportewwds_15_tfsolicitudesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesMail] = @AV204Solicitudesreportewwds_15_tfsolicitudesmail_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV204Solicitudesreportewwds_15_tfsolicitudesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesMail] IS NULL or (T1.[SolicitudesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV206Solicitudesreportewwds_17_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV205Solicitudesreportewwds_16_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisID]) like UPPER(@lV205Solicitudesreportewwds_16_tfpaisid))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV206Solicitudesreportewwds_17_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV206Solicitudesreportewwds_17_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[PaisID] = @AV206Solicitudesreportewwds_17_tfpaisid_sel)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV206Solicitudesreportewwds_17_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV208Solicitudesreportewwds_19_tfdepartamentodepartamento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV207Solicitudesreportewwds_18_tfdepartamentodepartamento)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[DepartamentoDepartamento]) like UPPER(@lV207Solicitudesreportewwds_18_tfdepartamentodepartamento))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV208Solicitudesreportewwds_19_tfdepartamentodepartamento_sel)) && ! ( StringUtil.StrCmp(AV208Solicitudesreportewwds_19_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DepartamentoDepartamento] = @AV208Solicitudesreportewwds_19_tfdepartamentodepartamento_sel)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( StringUtil.StrCmp(AV208Solicitudesreportewwds_19_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[DepartamentoDepartamento] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV210Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV209Solicitudesreportewwds_20_tfdepartamentomunicipionombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[DepartamentoMunicipioNombre]) like UPPER(@lV209Solicitudesreportewwds_20_tfdepartamentomunicipionombre))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV210Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel)) && ! ( StringUtil.StrCmp(AV210Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[DepartamentoMunicipioNombre] = @AV210Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( StringUtil.StrCmp(AV210Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[DepartamentoMunicipioNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV212Solicitudesreportewwds_23_tfsolicitudesdireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV211Solicitudesreportewwds_22_tfsolicitudesdireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesDireccion]) like UPPER(@lV211Solicitudesreportewwds_22_tfsolicitudesdireccion))");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV212Solicitudesreportewwds_23_tfsolicitudesdireccion_sel)) && ! ( StringUtil.StrCmp(AV212Solicitudesreportewwds_23_tfsolicitudesdireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDireccion] = @AV212Solicitudesreportewwds_23_tfsolicitudesdireccion_sel)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( StringUtil.StrCmp(AV212Solicitudesreportewwds_23_tfsolicitudesdireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesDireccion] = ''))");
         }
         if ( AV213Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV213Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels, "T1.[SolicitudServicioOrigenPago] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV215Solicitudesreportewwds_26_tfmetodopagosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV214Solicitudesreportewwds_25_tfmetodopagosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[MetodoPagosNombre]) like UPPER(@lV214Solicitudesreportewwds_25_tfmetodopagosnombre))");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV215Solicitudesreportewwds_26_tfmetodopagosnombre_sel)) && ! ( StringUtil.StrCmp(AV215Solicitudesreportewwds_26_tfmetodopagosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[MetodoPagosNombre] = @AV215Solicitudesreportewwds_26_tfmetodopagosnombre_sel)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( StringUtil.StrCmp(AV215Solicitudesreportewwds_26_tfmetodopagosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[MetodoPagosNombre] = ''))");
         }
         if ( AV216Solicitudesreportewwds_27_tfsolicitudespagado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV216Solicitudesreportewwds_27_tfsolicitudespagado_sels, "T1.[SolicitudesPagado] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV219Solicitudesreportewwds_30_tfsolicitudescotizacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCotizacion] >= @AV219Solicitudesreportewwds_30_tfsolicitudescotizacion)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV220Solicitudesreportewwds_31_tfsolicitudescotizacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCotizacion] <= @AV220Solicitudesreportewwds_31_tfsolicitudescotizacion_to)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV221Solicitudesreportewwds_32_tfsolicitudesdescuento) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDescuento] >= @AV221Solicitudesreportewwds_32_tfsolicitudesdescuento)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV222Solicitudesreportewwds_33_tfsolicitudesdescuento_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDescuento] <= @AV222Solicitudesreportewwds_33_tfsolicitudesdescuento_to)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV223Solicitudesreportewwds_34_tfsolicitudserviciocomalm) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComALM] >= @AV223Solicitudesreportewwds_34_tfsolicitudserviciocomalm)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV224Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComALM] <= @AV224Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV225Solicitudesreportewwds_36_tfsolicitudserviciocomalmp) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComALMP] >= @AV225Solicitudesreportewwds_36_tfsolicitudserviciocomalmp)");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV226Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComALMP] <= @AV226Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to)");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV229Solicitudesreportewwds_40_tfsolicitudserviciocomprop) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudServicioComALMP] >= 0 THEN 100 - ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) WHEN T1.[SolicitudServicioComALMP] < 0 and T1.[SolicitudServicioComProvP] >= 0 THEN ( 100 - T1.[SolicitudServicioComProvP]) + ( T1.[SolicitudServicioComALMP] * CAST(-1 AS decimal( 16, 10))) WHEN T1.[SolicitudServicioComALMP] < 0 and T1.[SolicitudServicioComProvP] < 0 THEN 100 + ( ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) * CAST(-1 AS decimal( 16, 10))) ELSE 100 - ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) END) >= @AV229Solicitudesreportewwds_40_tfsolicitudserviciocomprop)");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV230Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudServicioComALMP] >= 0 THEN 100 - ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) WHEN T1.[SolicitudServicioComALMP] < 0 and T1.[SolicitudServicioComProvP] >= 0 THEN ( 100 - T1.[SolicitudServicioComProvP]) + ( T1.[SolicitudServicioComALMP] * CAST(-1 AS decimal( 16, 10))) WHEN T1.[SolicitudServicioComALMP] < 0 and T1.[SolicitudServicioComProvP] < 0 THEN 100 + ( ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) * CAST(-1 AS decimal( 16, 10))) ELSE 100 - ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) END) <= @AV230Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to)");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV231Solicitudesreportewwds_42_tfsolicitudserviciocomprov) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComProv] >= @AV231Solicitudesreportewwds_42_tfsolicitudserviciocomprov)");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV232Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComProv] <= @AV232Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to)");
         }
         else
         {
            GXv_int5[35] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV233Solicitudesreportewwds_44_tfsolicitudserviciocomprovp) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComProvP] >= @AV233Solicitudesreportewwds_44_tfsolicitudserviciocomprovp)");
         }
         else
         {
            GXv_int5[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV234Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComProvP] <= @AV234Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to)");
         }
         else
         {
            GXv_int5[37] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV235Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZComAlm] >= @AV235Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm)");
         }
         else
         {
            GXv_int5[38] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV236Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZComAlm] <= @AV236Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to)");
         }
         else
         {
            GXv_int5[39] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV237Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZComAlmP] >= @AV237Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp)");
         }
         else
         {
            GXv_int5[40] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV238Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZComAlmP] <= @AV238Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to)");
         }
         else
         {
            GXv_int5[41] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV239Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudesCostoXZComAlm] < 0 THEN T1.[SolicitudesCostoXZona] + ( T1.[SolicitudesCostoXZComAlm] * CAST(-1 AS decimal( 28, 10))) ELSE T1.[SolicitudesCostoXZona] - ( T1.[SolicitudesCostoXZComAlm]) END) >= @AV239Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof)");
         }
         else
         {
            GXv_int5[42] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV240Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudesCostoXZComAlm] < 0 THEN T1.[SolicitudesCostoXZona] + ( T1.[SolicitudesCostoXZComAlm] * CAST(-1 AS decimal( 28, 10))) ELSE T1.[SolicitudesCostoXZona] - ( T1.[SolicitudesCostoXZComAlm]) END) <= @AV240Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to)");
         }
         else
         {
            GXv_int5[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV241Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudesCostoXZComAlmP] >= 0 THEN 100 - ( T1.[SolicitudesCostoXZComAlmP]) WHEN T1.[SolicitudesCostoXZComAlmP] < 0 THEN 100 + ( T1.[SolicitudesCostoXZComAlmP] * CAST(-1 AS decimal( 16, 10))) ELSE 100 - ( T1.[SolicitudesCostoXZComAlmP]) END) >= @AV241Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp)");
         }
         else
         {
            GXv_int5[44] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV242Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudesCostoXZComAlmP] >= 0 THEN 100 - ( T1.[SolicitudesCostoXZComAlmP]) WHEN T1.[SolicitudesCostoXZComAlmP] < 0 THEN 100 + ( T1.[SolicitudesCostoXZComAlmP] * CAST(-1 AS decimal( 16, 10))) ELSE 100 - ( T1.[SolicitudesCostoXZComAlmP]) END) <= @AV242Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to)");
         }
         else
         {
            GXv_int5[45] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV243Solicitudesreportewwds_54_tfsolicitudescostoxzona) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZona] >= @AV243Solicitudesreportewwds_54_tfsolicitudescostoxzona)");
         }
         else
         {
            GXv_int5[46] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV244Solicitudesreportewwds_55_tfsolicitudescostoxzona_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZona] <= @AV244Solicitudesreportewwds_55_tfsolicitudescostoxzona_to)");
         }
         else
         {
            GXv_int5[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV246Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV245Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T6.[CancelacionTipificacionDescrip]) like UPPER(@lV245Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion))");
         }
         else
         {
            GXv_int5[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV246Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel)) && ! ( StringUtil.StrCmp(AV246Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.[CancelacionTipificacionDescrip] = @AV246Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel)");
         }
         else
         {
            GXv_int5[49] = 1;
         }
         if ( StringUtil.StrCmp(AV246Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T6.[CancelacionTipificacionDescrip] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV248Solicitudesreportewwds_59_tfsolicitudesnota_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV247Solicitudesreportewwds_58_tfsolicitudesnota)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesNota]) like UPPER(@lV247Solicitudesreportewwds_58_tfsolicitudesnota))");
         }
         else
         {
            GXv_int5[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV248Solicitudesreportewwds_59_tfsolicitudesnota_sel)) && ! ( StringUtil.StrCmp(AV248Solicitudesreportewwds_59_tfsolicitudesnota_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesNota] = @AV248Solicitudesreportewwds_59_tfsolicitudesnota_sel)");
         }
         else
         {
            GXv_int5[51] = 1;
         }
         if ( StringUtil.StrCmp(AV248Solicitudesreportewwds_59_tfsolicitudesnota_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesNota] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV250Solicitudesreportewwds_61_tfsolicitudescomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV249Solicitudesreportewwds_60_tfsolicitudescomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesComentario]) like UPPER(@lV249Solicitudesreportewwds_60_tfsolicitudescomentario))");
         }
         else
         {
            GXv_int5[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV250Solicitudesreportewwds_61_tfsolicitudescomentario_sel)) && ! ( StringUtil.StrCmp(AV250Solicitudesreportewwds_61_tfsolicitudescomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesComentario] = @AV250Solicitudesreportewwds_61_tfsolicitudescomentario_sel)");
         }
         else
         {
            GXv_int5[53] = 1;
         }
         if ( StringUtil.StrCmp(AV250Solicitudesreportewwds_61_tfsolicitudescomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[SolicitudesComentario])=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV252Solicitudesreportewwds_63_tfsolicitudesotros2_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV251Solicitudesreportewwds_62_tfsolicitudesotros2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesOtros2]) like UPPER(@lV251Solicitudesreportewwds_62_tfsolicitudesotros2))");
         }
         else
         {
            GXv_int5[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV252Solicitudesreportewwds_63_tfsolicitudesotros2_sel)) && ! ( StringUtil.StrCmp(AV252Solicitudesreportewwds_63_tfsolicitudesotros2_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesOtros2] = @AV252Solicitudesreportewwds_63_tfsolicitudesotros2_sel)");
         }
         else
         {
            GXv_int5[55] = 1;
         }
         if ( StringUtil.StrCmp(AV252Solicitudesreportewwds_63_tfsolicitudesotros2_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesOtros2] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV254Solicitudesreportewwds_65_tfsolicitudesotros3_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV253Solicitudesreportewwds_64_tfsolicitudesotros3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesOtros3]) like UPPER(@lV253Solicitudesreportewwds_64_tfsolicitudesotros3))");
         }
         else
         {
            GXv_int5[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV254Solicitudesreportewwds_65_tfsolicitudesotros3_sel)) && ! ( StringUtil.StrCmp(AV254Solicitudesreportewwds_65_tfsolicitudesotros3_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesOtros3] = @AV254Solicitudesreportewwds_65_tfsolicitudesotros3_sel)");
         }
         else
         {
            GXv_int5[57] = 1;
         }
         if ( StringUtil.StrCmp(AV254Solicitudesreportewwds_65_tfsolicitudesotros3_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesOtros3] = ''))");
         }
         if ( ! (DateTime.MinValue==AV255Solicitudesreportewwds_66_tfsolicitudesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] >= @AV255Solicitudesreportewwds_66_tfsolicitudesfechaalta)");
         }
         else
         {
            GXv_int5[58] = 1;
         }
         if ( ! (DateTime.MinValue==AV256Solicitudesreportewwds_67_tfsolicitudesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] <= @AV256Solicitudesreportewwds_67_tfsolicitudesfechaalta_to)");
         }
         else
         {
            GXv_int5[59] = 1;
         }
         if ( ! (DateTime.MinValue==AV257Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaActualizacion] >= @AV257Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion)");
         }
         else
         {
            GXv_int5[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV258Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaActualizacion] <= @AV258Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to)");
         }
         else
         {
            GXv_int5[61] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesID]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesID] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesSubTipo]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesSubTipo] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaInstalacion]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaInstalacion] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T7.[EstadosGenericosNombre]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T7.[EstadosGenericosNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.[ProveedorNombre]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.[ProveedorNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesNombre]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesTelefono]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesTelefono] DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesMail]";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesMail] DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[PaisID]";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[PaisID] DESC";
         }
         else if ( ( AV17OrderedBy == 10 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[DepartamentoDepartamento]";
         }
         else if ( ( AV17OrderedBy == 10 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[DepartamentoDepartamento] DESC";
         }
         else if ( ( AV17OrderedBy == 11 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[DepartamentoMunicipioNombre]";
         }
         else if ( ( AV17OrderedBy == 11 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[DepartamentoMunicipioNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 12 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDireccion]";
         }
         else if ( ( AV17OrderedBy == 12 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDireccion] DESC";
         }
         else if ( ( AV17OrderedBy == 13 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioOrigenPago]";
         }
         else if ( ( AV17OrderedBy == 13 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioOrigenPago] DESC";
         }
         else if ( ( AV17OrderedBy == 14 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[MetodoPagosNombre]";
         }
         else if ( ( AV17OrderedBy == 14 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[MetodoPagosNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 15 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesPagado]";
         }
         else if ( ( AV17OrderedBy == 15 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesPagado] DESC";
         }
         else if ( ( AV17OrderedBy == 16 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCotizacion]";
         }
         else if ( ( AV17OrderedBy == 16 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCotizacion] DESC";
         }
         else if ( ( AV17OrderedBy == 17 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDescuento]";
         }
         else if ( ( AV17OrderedBy == 17 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDescuento] DESC";
         }
         else if ( ( AV17OrderedBy == 18 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComALM]";
         }
         else if ( ( AV17OrderedBy == 18 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComALM] DESC";
         }
         else if ( ( AV17OrderedBy == 19 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComALMP]";
         }
         else if ( ( AV17OrderedBy == 19 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComALMP] DESC";
         }
         else if ( ( AV17OrderedBy == 20 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComProv]";
         }
         else if ( ( AV17OrderedBy == 20 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComProv] DESC";
         }
         else if ( ( AV17OrderedBy == 21 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComProvP]";
         }
         else if ( ( AV17OrderedBy == 21 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComProvP] DESC";
         }
         else if ( ( AV17OrderedBy == 22 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZComAlm]";
         }
         else if ( ( AV17OrderedBy == 22 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZComAlm] DESC";
         }
         else if ( ( AV17OrderedBy == 23 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZComAlmP]";
         }
         else if ( ( AV17OrderedBy == 23 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZComAlmP] DESC";
         }
         else if ( ( AV17OrderedBy == 24 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZona]";
         }
         else if ( ( AV17OrderedBy == 24 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZona] DESC";
         }
         else if ( ( AV17OrderedBy == 25 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T6.[CancelacionTipificacionDescrip]";
         }
         else if ( ( AV17OrderedBy == 25 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T6.[CancelacionTipificacionDescrip] DESC";
         }
         else if ( ( AV17OrderedBy == 26 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesNota]";
         }
         else if ( ( AV17OrderedBy == 26 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesNota] DESC";
         }
         else if ( ( AV17OrderedBy == 27 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesComentario]";
         }
         else if ( ( AV17OrderedBy == 27 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesComentario] DESC";
         }
         else if ( ( AV17OrderedBy == 28 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesOtros2]";
         }
         else if ( ( AV17OrderedBy == 28 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesOtros2] DESC";
         }
         else if ( ( AV17OrderedBy == 29 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesOtros3]";
         }
         else if ( ( AV17OrderedBy == 29 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesOtros3] DESC";
         }
         else if ( ( AV17OrderedBy == 30 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaAlta]";
         }
         else if ( ( AV17OrderedBy == 30 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaAlta] DESC";
         }
         else if ( ( AV17OrderedBy == 31 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaActualizacion]";
         }
         else if ( ( AV17OrderedBy == 31 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaActualizacion] DESC";
         }
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00L42(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (int)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (decimal)dynConstraints[42] , (decimal)dynConstraints[43] , (decimal)dynConstraints[44] , (decimal)dynConstraints[45] , (decimal)dynConstraints[46] , (decimal)dynConstraints[47] , (decimal)dynConstraints[48] , (decimal)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (decimal)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (DateTime)dynConstraints[67] , (DateTime)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (DateTime)dynConstraints[71] , (long)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (string)dynConstraints[77] , (string)dynConstraints[78] , (string)dynConstraints[79] , (string)dynConstraints[80] , (string)dynConstraints[81] , (string)dynConstraints[82] , (decimal)dynConstraints[83] , (decimal)dynConstraints[84] , (decimal)dynConstraints[85] , (decimal)dynConstraints[86] , (decimal)dynConstraints[87] , (decimal)dynConstraints[88] , (decimal)dynConstraints[89] , (decimal)dynConstraints[90] , (decimal)dynConstraints[91] , (string)dynConstraints[92] , (string)dynConstraints[93] , (string)dynConstraints[94] , (string)dynConstraints[95] , (string)dynConstraints[96] , (DateTime)dynConstraints[97] , (DateTime)dynConstraints[98] , (short)dynConstraints[99] , (bool)dynConstraints[100] , (decimal)dynConstraints[101] , (decimal)dynConstraints[102] , (decimal)dynConstraints[103] , (decimal)dynConstraints[104] , (decimal)dynConstraints[105] , (decimal)dynConstraints[106] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00L43;
          prmP00L43 = new Object[] {
          new ParDef("@SolicitudesUsrAlta",GXType.Decimal,10,0){Nullable=true}
          };
          Object[] prmP00L44;
          prmP00L44 = new Object[] {
          new ParDef("@SolicitudesUsrActualizacion",GXType.Decimal,10,0){Nullable=true}
          };
          Object[] prmP00L45;
          prmP00L45 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00L42;
          prmP00L42 = new Object[] {
          new ParDef("@AV190Solicitudesreportewwds_1_solicitudesfechainstalacion",GXType.Date,8,0) ,
          new ParDef("@AV191Solicitudesreportewwds_2_solicitudesfechainstalacion_to",GXType.Date,8,0) ,
          new ParDef("@AV192Solicitudesreportewwds_3_tfsolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV193Solicitudesreportewwds_4_tfsolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV195Solicitudesreportewwds_6_tfestadossolnombre",GXType.Char,80,0) ,
          new ParDef("@AV196Solicitudesreportewwds_7_tfestadossolnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV197Solicitudesreportewwds_8_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV198Solicitudesreportewwds_9_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV199Solicitudesreportewwds_10_tfsolicitudesnombre",GXType.Char,100,0) ,
          new ParDef("@AV200Solicitudesreportewwds_11_tfsolicitudesnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV201Solicitudesreportewwds_12_tfsolicitudestelefono",GXType.Char,20,0) ,
          new ParDef("@AV202Solicitudesreportewwds_13_tfsolicitudestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV203Solicitudesreportewwds_14_tfsolicitudesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV204Solicitudesreportewwds_15_tfsolicitudesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV205Solicitudesreportewwds_16_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV206Solicitudesreportewwds_17_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV207Solicitudesreportewwds_18_tfdepartamentodepartamento",GXType.Char,80,0) ,
          new ParDef("@AV208Solicitudesreportewwds_19_tfdepartamentodepartamento_sel",GXType.NChar,80,0) ,
          new ParDef("@lV209Solicitudesreportewwds_20_tfdepartamentomunicipionombre",GXType.Char,120,0) ,
          new ParDef("@AV210Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV211Solicitudesreportewwds_22_tfsolicitudesdireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV212Solicitudesreportewwds_23_tfsolicitudesdireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV214Solicitudesreportewwds_25_tfmetodopagosnombre",GXType.Char,80,0) ,
          new ParDef("@AV215Solicitudesreportewwds_26_tfmetodopagosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV219Solicitudesreportewwds_30_tfsolicitudescotizacion",GXType.Decimal,18,2) ,
          new ParDef("@AV220Solicitudesreportewwds_31_tfsolicitudescotizacion_to",GXType.Decimal,18,2) ,
          new ParDef("@AV221Solicitudesreportewwds_32_tfsolicitudesdescuento",GXType.Decimal,18,2) ,
          new ParDef("@AV222Solicitudesreportewwds_33_tfsolicitudesdescuento_to",GXType.Decimal,18,2) ,
          new ParDef("@AV223Solicitudesreportewwds_34_tfsolicitudserviciocomalm",GXType.Decimal,18,2) ,
          new ParDef("@AV224Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to",GXType.Decimal,18,2) ,
          new ParDef("@AV225Solicitudesreportewwds_36_tfsolicitudserviciocomalmp",GXType.Decimal,6,2) ,
          new ParDef("@AV226Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to",GXType.Decimal,6,2) ,
          new ParDef("@AV229Solicitudesreportewwds_40_tfsolicitudserviciocomprop",GXType.Decimal,6,2) ,
          new ParDef("@AV230Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to",GXType.Decimal,6,2) ,
          new ParDef("@AV231Solicitudesreportewwds_42_tfsolicitudserviciocomprov",GXType.Decimal,18,2) ,
          new ParDef("@AV232Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to",GXType.Decimal,18,2) ,
          new ParDef("@AV233Solicitudesreportewwds_44_tfsolicitudserviciocomprovp",GXType.Decimal,6,2) ,
          new ParDef("@AV234Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to",GXType.Decimal,6,2) ,
          new ParDef("@AV235Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm",GXType.Decimal,18,2) ,
          new ParDef("@AV236Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to",GXType.Decimal,18,2) ,
          new ParDef("@AV237Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp",GXType.Decimal,6,2) ,
          new ParDef("@AV238Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to",GXType.Decimal,6,2) ,
          new ParDef("@AV239Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof",GXType.Decimal,18,2) ,
          new ParDef("@AV240Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to",GXType.Decimal,18,2) ,
          new ParDef("@AV241Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp",GXType.Decimal,6,2) ,
          new ParDef("@AV242Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to",GXType.Decimal,6,2) ,
          new ParDef("@AV243Solicitudesreportewwds_54_tfsolicitudescostoxzona",GXType.Decimal,18,2) ,
          new ParDef("@AV244Solicitudesreportewwds_55_tfsolicitudescostoxzona_to",GXType.Decimal,18,2) ,
          new ParDef("@lV245Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion",GXType.Char,250,0) ,
          new ParDef("@AV246Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@lV247Solicitudesreportewwds_58_tfsolicitudesnota",GXType.Char,500,0) ,
          new ParDef("@AV248Solicitudesreportewwds_59_tfsolicitudesnota_sel",GXType.NChar,500,0) ,
          new ParDef("@lV249Solicitudesreportewwds_60_tfsolicitudescomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV250Solicitudesreportewwds_61_tfsolicitudescomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV251Solicitudesreportewwds_62_tfsolicitudesotros2",GXType.Char,1000,0) ,
          new ParDef("@AV252Solicitudesreportewwds_63_tfsolicitudesotros2_sel",GXType.NChar,1000,0) ,
          new ParDef("@lV253Solicitudesreportewwds_64_tfsolicitudesotros3",GXType.Char,500,0) ,
          new ParDef("@AV254Solicitudesreportewwds_65_tfsolicitudesotros3_sel",GXType.NChar,500,0) ,
          new ParDef("@AV255Solicitudesreportewwds_66_tfsolicitudesfechaalta",GXType.Date,8,0) ,
          new ParDef("@AV256Solicitudesreportewwds_67_tfsolicitudesfechaalta_to",GXType.Date,8,0) ,
          new ParDef("@AV257Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion",GXType.DateTime,8,5) ,
          new ParDef("@AV258Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00L42", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00L42,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00L43", "SELECT [SecUserId], [SecUserName] FROM [SecUser] WHERE [SecUserId] = @SolicitudesUsrAlta ORDER BY [SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00L43,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00L44", "SELECT [SecUserId], [SecUserName] FROM [SecUser] WHERE [SecUserId] = @SolicitudesUsrActualizacion ORDER BY [SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00L44,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00L45", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00L45,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 3);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((long[]) buf[9])[0] = rslt.getLong(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((long[]) buf[11])[0] = rslt.getLong(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(11);
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                ((string[]) buf[17])[0] = rslt.getString(12, 500);
                ((string[]) buf[18])[0] = rslt.getString(13, 1000);
                ((string[]) buf[19])[0] = rslt.getLongVarchar(14);
                ((string[]) buf[20])[0] = rslt.getString(15, 500);
                ((string[]) buf[21])[0] = rslt.getString(16, 250);
                ((string[]) buf[22])[0] = rslt.getString(17, 1);
                ((bool[]) buf[23])[0] = rslt.wasNull(17);
                ((string[]) buf[24])[0] = rslt.getString(18, 80);
                ((string[]) buf[25])[0] = rslt.getString(19, 1);
                ((bool[]) buf[26])[0] = rslt.wasNull(19);
                ((string[]) buf[27])[0] = rslt.getVarchar(20);
                ((string[]) buf[28])[0] = rslt.getString(21, 120);
                ((string[]) buf[29])[0] = rslt.getString(22, 80);
                ((string[]) buf[30])[0] = rslt.getString(23, 2);
                ((string[]) buf[31])[0] = rslt.getVarchar(24);
                ((bool[]) buf[32])[0] = rslt.wasNull(24);
                ((string[]) buf[33])[0] = rslt.getString(25, 20);
                ((string[]) buf[34])[0] = rslt.getString(26, 100);
                ((string[]) buf[35])[0] = rslt.getString(27, 80);
                ((string[]) buf[36])[0] = rslt.getString(28, 80);
                ((string[]) buf[37])[0] = rslt.getString(29, 1);
                ((bool[]) buf[38])[0] = rslt.wasNull(29);
                ((long[]) buf[39])[0] = rslt.getLong(30);
                ((DateTime[]) buf[40])[0] = rslt.getGXDate(31);
                ((string[]) buf[41])[0] = rslt.getString(32, 1);
                ((decimal[]) buf[42])[0] = rslt.getDecimal(33);
                ((decimal[]) buf[43])[0] = rslt.getDecimal(34);
                ((decimal[]) buf[44])[0] = rslt.getDecimal(35);
                ((decimal[]) buf[45])[0] = rslt.getDecimal(36);
                ((bool[]) buf[46])[0] = rslt.wasNull(36);
                ((decimal[]) buf[47])[0] = rslt.getDecimal(37);
                ((bool[]) buf[48])[0] = rslt.wasNull(37);
                ((decimal[]) buf[49])[0] = rslt.getDecimal(38);
                ((bool[]) buf[50])[0] = rslt.wasNull(38);
                ((decimal[]) buf[51])[0] = rslt.getDecimal(39);
                ((bool[]) buf[52])[0] = rslt.wasNull(39);
                ((decimal[]) buf[53])[0] = rslt.getDecimal(40);
                ((bool[]) buf[54])[0] = rslt.wasNull(40);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(41);
                ((bool[]) buf[56])[0] = rslt.wasNull(41);
                ((decimal[]) buf[57])[0] = rslt.getDecimal(42);
                ((decimal[]) buf[58])[0] = rslt.getDecimal(43);
                ((bool[]) buf[59])[0] = rslt.wasNull(43);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
