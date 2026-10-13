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
   public class solicitudeswwexport : GXProcedure
   {
      public solicitudeswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public solicitudeswwexport( IGxContext context )
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
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudes", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV195Pgmname));
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
         cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         AV16Random = (int)(NumberUtil.Random( )*10000);
         GXt_char2 = AV12Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char2) ;
         AV12Filename = GXt_char2 + "SolicitudesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  "") ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV19FilterFullText, out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         if ( ! ( (0==AV57TFSolicitudesID) && (0==AV58TFSolicitudesID_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Solicitud", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV57TFSolicitudesID;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV58TFSolicitudesID_To;
         }
         if ( ! ( (0==AV151TFProveedorID_Sel) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comercio", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV151TFProveedorID_Sel;
         }
         else
         {
            if ( ! ( (0==AV59TFProveedorID) && (0==AV60TFProveedorID_To) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comercio", "")) ;
               AV14CellRow = GXt_int3;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV59TFProveedorID;
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
               AV14CellRow = GXt_int3;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV60TFProveedorID_To;
            }
         }
         if ( ! ( (DateTime.MinValue==AV71TFSolicitudesFechaInstalacion) && (DateTime.MinValue==AV72TFSolicitudesFechaInstalacion_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Trabajo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV71TFSolicitudesFechaInstalacion ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV72TFSolicitudesFechaInstalacion_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
         }
         if ( ! ( (DateTime.MinValue==AV69TFSolicitudesFechaAlta) && (DateTime.MinValue==AV70TFSolicitudesFechaAlta_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Fecha de Alta", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV69TFSolicitudesFechaAlta ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV70TFSolicitudesFechaAlta_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV181TFDepartamentoMunicipioNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Municipio", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV181TFDepartamentoMunicipioNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV181TFDepartamentoMunicipioNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV180TFDepartamentoMunicipioNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Municipio", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV180TFDepartamentoMunicipioNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV183TFZonasNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Zona", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV183TFZonasNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV183TFZonasNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV182TFZonasNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Zona", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV182TFZonasNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV105TFSolicitudServicioPFinal) && (Convert.ToDecimal(0)==AV106TFSolicitudServicioPFinal_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Total", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV105TFSolicitudServicioPFinal);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV106TFSolicitudServicioPFinal_To);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV66TFSolicitudesComentario_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comentario", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV66TFSolicitudesComentario_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : StringUtil.Substring( AV66TFSolicitudesComentario_Sel, 1, 1000)), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV65TFSolicitudesComentario)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comentario", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( AV65TFSolicitudesComentario, 1, 1000), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV155TFProveedorNombreAux_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comercio Auxiliar", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV155TFProveedorNombreAux_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV155TFProveedorNombreAux_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV154TFProveedorNombreAux)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comercio Auxiliar", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV154TFProveedorNombreAux, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV165TFSolicitudesPagado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Pagado", "")) ;
            AV14CellRow = GXt_int3;
            AV86i = 1;
            AV196GXV1 = 1;
            while ( AV196GXV1 <= AV165TFSolicitudesPagado_Sels.Count )
            {
               AV166TFSolicitudesPagado_Sel = AV165TFSolicitudesPagado_Sels.GetString(AV196GXV1);
               if ( AV86i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV166TFSolicitudesPagado_Sel), context.GetMessage( "S", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Pagado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV166TFSolicitudesPagado_Sel), context.GetMessage( "N", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Pendiente de Pago", "");
               }
               AV86i = (long)(AV86i+1);
               AV196GXV1 = (int)(AV196GXV1+1);
            }
         }
         if ( ! ( ( AV168TFSolicitudServicioOrigenPago_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Origen", "")) ;
            AV14CellRow = GXt_int3;
            AV86i = 1;
            AV197GXV2 = 1;
            while ( AV197GXV2 <= AV168TFSolicitudServicioOrigenPago_Sels.Count )
            {
               AV169TFSolicitudServicioOrigenPago_Sel = AV168TFSolicitudServicioOrigenPago_Sels.GetString(AV197GXV2);
               if ( AV86i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainorigenpago.getDescription(context,AV169TFSolicitudServicioOrigenPago_Sel), "");
               AV86i = (long)(AV86i+1);
               AV197GXV2 = (int)(AV197GXV2+1);
            }
         }
         if ( ! ( ( AV173TFSolicitudesSubTipo_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Sub Tipo", "")) ;
            AV14CellRow = GXt_int3;
            AV86i = 1;
            AV198GXV3 = 1;
            while ( AV198GXV3 <= AV173TFSolicitudesSubTipo_Sels.Count )
            {
               AV172TFSolicitudesSubTipo_Sel = AV173TFSolicitudesSubTipo_Sels.GetString(AV198GXV3);
               if ( AV86i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainsolicitudsubtipo.getDescription(context,AV172TFSolicitudesSubTipo_Sel), "");
               AV86i = (long)(AV86i+1);
               AV198GXV3 = (int)(AV198GXV3+1);
            }
         }
         if ( ! ( (0==AV193TFMudanzaId) && (0==AV194TFMudanzaId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Mudanza Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV193TFMudanzaId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV194TFMudanzaId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV188TFSTComerciosNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Convenio Comercio", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV188TFSTComerciosNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV188TFSTComerciosNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV187TFSTComerciosNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Convenio Comercio", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV187TFSTComerciosNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (0==AV189TFSolicitudesDuplicado) && (0==AV190TFSolicitudesDuplicado_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Duplicado (código)", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV189TFSolicitudesDuplicado;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV190TFSolicitudesDuplicado_To;
         }
         if ( ! ( (0==AV191TFPostulacionesId) && (0==AV192TFPostulacionesId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Postulaciones Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV191TFPostulacionesId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV192TFPostulacionesId_To;
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV54VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV42Session.Get("SolicitudesWWColumnsSelector"), "") != 0 )
         {
            AV49ColumnsSelectorXML = AV42Session.Get("SolicitudesWWColumnsSelector");
            AV46ColumnsSelector.FromXml(AV49ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV46ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible = false;
         ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV46ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible = false;
         ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV46ColumnsSelector.gxTpr_Columns.Item(24)).gxTpr_Isvisible = false;
         AV46ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV199GXV4 = 1;
         while ( AV199GXV4 <= AV46ColumnsSelector.gxTpr_Columns.Count )
         {
            AV48ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV46ColumnsSelector.gxTpr_Columns.Item(AV199GXV4));
            if ( AV48ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV48ColumnsSelector_Column.gxTpr_Displayname)) ? AV48ColumnsSelector_Column.gxTpr_Columnname : AV48ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Color = 11;
               AV54VisibleColumnCount = (long)(AV54VisibleColumnCount+1);
            }
            AV199GXV4 = (int)(AV199GXV4+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV201Solicitudeswwds_1_filterfulltext = AV19FilterFullText;
         AV202Solicitudeswwds_2_tfsolicitudesid = AV57TFSolicitudesID;
         AV203Solicitudeswwds_3_tfsolicitudesid_to = AV58TFSolicitudesID_To;
         AV204Solicitudeswwds_4_tfproveedorid = AV59TFProveedorID;
         AV205Solicitudeswwds_5_tfproveedorid_to = AV60TFProveedorID_To;
         AV206Solicitudeswwds_6_tfproveedorid_sel = AV151TFProveedorID_Sel;
         AV207Solicitudeswwds_7_tfsolicitudesfechainstalacion = AV71TFSolicitudesFechaInstalacion;
         AV208Solicitudeswwds_8_tfsolicitudesfechainstalacion_to = AV72TFSolicitudesFechaInstalacion_To;
         AV209Solicitudeswwds_9_tfsolicitudesfechaalta = AV69TFSolicitudesFechaAlta;
         AV210Solicitudeswwds_10_tfsolicitudesfechaalta_to = AV70TFSolicitudesFechaAlta_To;
         AV211Solicitudeswwds_11_tfdepartamentomunicipionombre = AV180TFDepartamentoMunicipioNombre;
         AV212Solicitudeswwds_12_tfdepartamentomunicipionombre_sel = AV181TFDepartamentoMunicipioNombre_Sel;
         AV213Solicitudeswwds_13_tfzonasnombre = AV182TFZonasNombre;
         AV214Solicitudeswwds_14_tfzonasnombre_sel = AV183TFZonasNombre_Sel;
         AV215Solicitudeswwds_15_tfsolicitudserviciopfinal = AV105TFSolicitudServicioPFinal;
         AV216Solicitudeswwds_16_tfsolicitudserviciopfinal_to = AV106TFSolicitudServicioPFinal_To;
         AV217Solicitudeswwds_17_tfsolicitudescomentario = AV65TFSolicitudesComentario;
         AV218Solicitudeswwds_18_tfsolicitudescomentario_sel = AV66TFSolicitudesComentario_Sel;
         AV219Solicitudeswwds_19_tfproveedornombreaux = AV154TFProveedorNombreAux;
         AV220Solicitudeswwds_20_tfproveedornombreaux_sel = AV155TFProveedorNombreAux_Sel;
         AV221Solicitudeswwds_21_tfsolicitudespagado_sels = AV165TFSolicitudesPagado_Sels;
         AV222Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels = AV168TFSolicitudServicioOrigenPago_Sels;
         AV223Solicitudeswwds_23_tfsolicitudessubtipo_sels = AV173TFSolicitudesSubTipo_Sels;
         AV224Solicitudeswwds_24_tfmudanzaid = AV193TFMudanzaId;
         AV225Solicitudeswwds_25_tfmudanzaid_to = AV194TFMudanzaId_To;
         AV226Solicitudeswwds_26_tfstcomerciosnombre = AV187TFSTComerciosNombre;
         AV227Solicitudeswwds_27_tfstcomerciosnombre_sel = AV188TFSTComerciosNombre_Sel;
         AV228Solicitudeswwds_28_tfsolicitudesduplicado = AV189TFSolicitudesDuplicado;
         AV229Solicitudeswwds_29_tfsolicitudesduplicado_to = AV190TFSolicitudesDuplicado_To;
         AV230Solicitudeswwds_30_tfpostulacionesid = AV191TFPostulacionesId;
         AV231Solicitudeswwds_31_tfpostulacionesid_to = AV192TFPostulacionesId_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A441SolicitudesPagado ,
                                              AV221Solicitudeswwds_21_tfsolicitudespagado_sels ,
                                              A438SolicitudServicioOrigenPago ,
                                              AV222Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ,
                                              A600SolicitudesSubTipo ,
                                              AV223Solicitudeswwds_23_tfsolicitudessubtipo_sels ,
                                              A133ProveedorID ,
                                              AV176ProveedorIDCollection ,
                                              A131EstadosSolId ,
                                              AV201Solicitudeswwds_1_filterfulltext ,
                                              AV202Solicitudeswwds_2_tfsolicitudesid ,
                                              AV203Solicitudeswwds_3_tfsolicitudesid_to ,
                                              AV206Solicitudeswwds_6_tfproveedorid_sel ,
                                              AV207Solicitudeswwds_7_tfsolicitudesfechainstalacion ,
                                              AV208Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ,
                                              AV209Solicitudeswwds_9_tfsolicitudesfechaalta ,
                                              AV210Solicitudeswwds_10_tfsolicitudesfechaalta_to ,
                                              AV212Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ,
                                              AV211Solicitudeswwds_11_tfdepartamentomunicipionombre ,
                                              AV214Solicitudeswwds_14_tfzonasnombre_sel ,
                                              AV213Solicitudeswwds_13_tfzonasnombre ,
                                              AV218Solicitudeswwds_18_tfsolicitudescomentario_sel ,
                                              AV217Solicitudeswwds_17_tfsolicitudescomentario ,
                                              AV220Solicitudeswwds_20_tfproveedornombreaux_sel ,
                                              AV219Solicitudeswwds_19_tfproveedornombreaux ,
                                              AV221Solicitudeswwds_21_tfsolicitudespagado_sels.Count ,
                                              AV222Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels.Count ,
                                              AV223Solicitudeswwds_23_tfsolicitudessubtipo_sels.Count ,
                                              AV224Solicitudeswwds_24_tfmudanzaid ,
                                              AV225Solicitudeswwds_25_tfmudanzaid_to ,
                                              AV227Solicitudeswwds_27_tfstcomerciosnombre_sel ,
                                              AV226Solicitudeswwds_26_tfstcomerciosnombre ,
                                              AV228Solicitudeswwds_28_tfsolicitudesduplicado ,
                                              AV229Solicitudeswwds_29_tfsolicitudesduplicado_to ,
                                              AV230Solicitudeswwds_30_tfpostulacionesid ,
                                              AV231Solicitudeswwds_31_tfpostulacionesid_to ,
                                              AV178MudanzaId ,
                                              AV159ProveedorID ,
                                              AV176ProveedorIDCollection.Count ,
                                              AV156EstadosGenericosID ,
                                              A127SolicitudesID ,
                                              A282ProveedorNombre ,
                                              A171SolicitudesNombre ,
                                              A172SolicitudesTelefono ,
                                              A173SolicitudesDireccion ,
                                              A203SolicitudesOtros3 ,
                                              A113DepartamentoDepartamento ,
                                              A533ProveedorNombreAux ,
                                              A205SolicitudesComentario ,
                                              A111ZonasNombre ,
                                              A115DepartamentoMunicipioNombre ,
                                              A184SolicitudesFechaInstalacion ,
                                              A182SolicitudesFechaAlta ,
                                              A735MudanzaId ,
                                              A923STComerciosNombre ,
                                              A972SolicitudesDuplicado ,
                                              A422PostulacionesId ,
                                              AV157FechaIni ,
                                              AV158FechaFin ,
                                              A737MudanzaFechaAlta ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV215Solicitudeswwds_15_tfsolicitudserviciopfinal ,
                                              A211SolicitudServicioPFinal ,
                                              AV216Solicitudeswwds_16_tfsolicitudserviciopfinal_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV201Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV201Solicitudeswwds_1_filterfulltext), "%", "");
         lV201Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV201Solicitudeswwds_1_filterfulltext), "%", "");
         lV201Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV201Solicitudeswwds_1_filterfulltext), "%", "");
         lV201Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV201Solicitudeswwds_1_filterfulltext), "%", "");
         lV201Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV201Solicitudeswwds_1_filterfulltext), "%", "");
         lV201Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV201Solicitudeswwds_1_filterfulltext), "%", "");
         lV201Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV201Solicitudeswwds_1_filterfulltext), "%", "");
         lV201Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV201Solicitudeswwds_1_filterfulltext), "%", "");
         lV201Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV201Solicitudeswwds_1_filterfulltext), "%", "");
         lV201Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV201Solicitudeswwds_1_filterfulltext), "%", "");
         lV201Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV201Solicitudeswwds_1_filterfulltext), "%", "");
         lV211Solicitudeswwds_11_tfdepartamentomunicipionombre = StringUtil.PadR( StringUtil.RTrim( AV211Solicitudeswwds_11_tfdepartamentomunicipionombre), 120, "%");
         lV213Solicitudeswwds_13_tfzonasnombre = StringUtil.PadR( StringUtil.RTrim( AV213Solicitudeswwds_13_tfzonasnombre), 120, "%");
         lV217Solicitudeswwds_17_tfsolicitudescomentario = StringUtil.Concat( StringUtil.RTrim( AV217Solicitudeswwds_17_tfsolicitudescomentario), "%", "");
         lV219Solicitudeswwds_19_tfproveedornombreaux = StringUtil.PadR( StringUtil.RTrim( AV219Solicitudeswwds_19_tfproveedornombreaux), 80, "%");
         lV226Solicitudeswwds_26_tfstcomerciosnombre = StringUtil.PadR( StringUtil.RTrim( AV226Solicitudeswwds_26_tfstcomerciosnombre), 80, "%");
         /* Using cursor P006T2 */
         pr_default.execute(0, new Object[] {lV201Solicitudeswwds_1_filterfulltext, lV201Solicitudeswwds_1_filterfulltext, lV201Solicitudeswwds_1_filterfulltext, lV201Solicitudeswwds_1_filterfulltext, lV201Solicitudeswwds_1_filterfulltext, lV201Solicitudeswwds_1_filterfulltext, lV201Solicitudeswwds_1_filterfulltext, lV201Solicitudeswwds_1_filterfulltext, lV201Solicitudeswwds_1_filterfulltext, lV201Solicitudeswwds_1_filterfulltext, lV201Solicitudeswwds_1_filterfulltext, AV202Solicitudeswwds_2_tfsolicitudesid, AV203Solicitudeswwds_3_tfsolicitudesid_to, AV206Solicitudeswwds_6_tfproveedorid_sel, AV207Solicitudeswwds_7_tfsolicitudesfechainstalacion, AV208Solicitudeswwds_8_tfsolicitudesfechainstalacion_to, AV209Solicitudeswwds_9_tfsolicitudesfechaalta, AV210Solicitudeswwds_10_tfsolicitudesfechaalta_to, lV211Solicitudeswwds_11_tfdepartamentomunicipionombre, AV212Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, lV213Solicitudeswwds_13_tfzonasnombre, AV214Solicitudeswwds_14_tfzonasnombre_sel, lV217Solicitudeswwds_17_tfsolicitudescomentario, AV218Solicitudeswwds_18_tfsolicitudescomentario_sel, lV219Solicitudeswwds_19_tfproveedornombreaux, AV220Solicitudeswwds_20_tfproveedornombreaux_sel, AV224Solicitudeswwds_24_tfmudanzaid, AV225Solicitudeswwds_25_tfmudanzaid_to, lV226Solicitudeswwds_26_tfstcomerciosnombre, AV227Solicitudeswwds_27_tfstcomerciosnombre_sel, AV228Solicitudeswwds_28_tfsolicitudesduplicado, AV229Solicitudeswwds_29_tfsolicitudesduplicado_to, AV230Solicitudeswwds_30_tfpostulacionesid, AV231Solicitudeswwds_31_tfpostulacionesid_to, AV157FechaIni, AV158FechaFin, AV157FechaIni, AV158FechaFin, AV159ProveedorID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112DepartamentoId = P006T2_A112DepartamentoId[0];
            n112DepartamentoId = P006T2_n112DepartamentoId[0];
            A114DepartamentoMunicipioId = P006T2_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P006T2_n114DepartamentoMunicipioId[0];
            A110ZonasID = P006T2_A110ZonasID[0];
            n110ZonasID = P006T2_n110ZonasID[0];
            A919STComerciosID = P006T2_A919STComerciosID[0];
            n919STComerciosID = P006T2_n919STComerciosID[0];
            A131EstadosSolId = P006T2_A131EstadosSolId[0];
            A737MudanzaFechaAlta = P006T2_A737MudanzaFechaAlta[0];
            A113DepartamentoDepartamento = P006T2_A113DepartamentoDepartamento[0];
            A203SolicitudesOtros3 = P006T2_A203SolicitudesOtros3[0];
            A173SolicitudesDireccion = P006T2_A173SolicitudesDireccion[0];
            A172SolicitudesTelefono = P006T2_A172SolicitudesTelefono[0];
            A171SolicitudesNombre = P006T2_A171SolicitudesNombre[0];
            A282ProveedorNombre = P006T2_A282ProveedorNombre[0];
            A422PostulacionesId = P006T2_A422PostulacionesId[0];
            n422PostulacionesId = P006T2_n422PostulacionesId[0];
            A972SolicitudesDuplicado = P006T2_A972SolicitudesDuplicado[0];
            n972SolicitudesDuplicado = P006T2_n972SolicitudesDuplicado[0];
            A923STComerciosNombre = P006T2_A923STComerciosNombre[0];
            A735MudanzaId = P006T2_A735MudanzaId[0];
            n735MudanzaId = P006T2_n735MudanzaId[0];
            A600SolicitudesSubTipo = P006T2_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P006T2_n600SolicitudesSubTipo[0];
            A438SolicitudServicioOrigenPago = P006T2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P006T2_n438SolicitudServicioOrigenPago[0];
            A441SolicitudesPagado = P006T2_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P006T2_n441SolicitudesPagado[0];
            A533ProveedorNombreAux = P006T2_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = P006T2_n533ProveedorNombreAux[0];
            A205SolicitudesComentario = P006T2_A205SolicitudesComentario[0];
            A111ZonasNombre = P006T2_A111ZonasNombre[0];
            A115DepartamentoMunicipioNombre = P006T2_A115DepartamentoMunicipioNombre[0];
            A182SolicitudesFechaAlta = P006T2_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = P006T2_n182SolicitudesFechaAlta[0];
            A184SolicitudesFechaInstalacion = P006T2_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P006T2_A133ProveedorID[0];
            A127SolicitudesID = P006T2_A127SolicitudesID[0];
            A183SolicitudesHoraInstalacion = P006T2_A183SolicitudesHoraInstalacion[0];
            A210SolicitudServicioSolCoti = P006T2_A210SolicitudServicioSolCoti[0];
            A796SolicitudesComisionMetodoPago = P006T2_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P006T2_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P006T2_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P006T2_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P006T2_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P006T2_A864SolicitudesCostoXZona[0];
            A113DepartamentoDepartamento = P006T2_A113DepartamentoDepartamento[0];
            A115DepartamentoMunicipioNombre = P006T2_A115DepartamentoMunicipioNombre[0];
            A111ZonasNombre = P006T2_A111ZonasNombre[0];
            A923STComerciosNombre = P006T2_A923STComerciosNombre[0];
            A737MudanzaFechaAlta = P006T2_A737MudanzaFechaAlta[0];
            A282ProveedorNombre = P006T2_A282ProveedorNombre[0];
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
            if ( (Convert.ToDecimal(0)==AV215Solicitudeswwds_15_tfsolicitudserviciopfinal) || ( ( A211SolicitudServicioPFinal >= AV215Solicitudeswwds_15_tfsolicitudserviciopfinal ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV216Solicitudeswwds_16_tfsolicitudserviciopfinal_to) || ( ( A211SolicitudServicioPFinal <= AV216Solicitudeswwds_16_tfsolicitudserviciopfinal_to ) ) )
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
                  AV54VisibleColumnCount = 0;
                  AV232GXV5 = 1;
                  while ( AV232GXV5 <= AV46ColumnsSelector.gxTpr_Columns.Count )
                  {
                     AV48ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV46ColumnsSelector.gxTpr_Columns.Item(AV232GXV5));
                     if ( AV48ColumnsSelector_Column.gxTpr_Isvisible )
                     {
                        if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesID") == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Number = A127SolicitudesID;
                           if ( A131EstadosSolId == 9 )
                           {
                              AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 251, 110, 82);
                           }
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "ProveedorID") == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Number = A133ProveedorID;
                           if ( A131EstadosSolId == 9 )
                           {
                              AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 251, 110, 82);
                           }
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesFechaInstalacion") == 0 )
                        {
                           GXt_dtime4 = DateTimeUtil.ResetTime( A184SolicitudesFechaInstalacion ) ;
                           AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Date = GXt_dtime4;
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "&HoraInstalacion") == 0 )
                        {
                           if ( StringUtil.StrCmp(DateTimeUtil.CDow( A184SolicitudesFechaInstalacion, context.GetLanguage( )), context.GetMessage( "Sábado", "")) == 0 )
                           {
                              if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
                              {
                                 AV184HoraInstalacion = "08 - 14";
                              }
                              if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
                              {
                                 AV184HoraInstalacion = "14 - 20";
                              }
                           }
                           else
                           {
                              if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
                              {
                                 AV184HoraInstalacion = "08 - 12";
                              }
                              if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
                              {
                                 AV184HoraInstalacion = "12 - 16";
                              }
                              if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "3") == 0 )
                              {
                                 AV184HoraInstalacion = "16 - 20";
                              }
                           }
                           GXt_char2 = "";
                           new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV184HoraInstalacion, out  GXt_char2) ;
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = GXt_char2;
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "&Dia") == 0 )
                        {
                           AV185Dia = DateTimeUtil.CDow( A184SolicitudesFechaInstalacion, context.GetLanguage( ));
                           GXt_char2 = "";
                           new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV185Dia, out  GXt_char2) ;
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = GXt_char2;
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "ProveedorNombre") == 0 )
                        {
                           GXt_char2 = "";
                           new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A282ProveedorNombre, out  GXt_char2) ;
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = GXt_char2;
                           if ( A131EstadosSolId == 9 )
                           {
                              AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 251, 110, 82);
                           }
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesNombre") == 0 )
                        {
                           GXt_char2 = "";
                           new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A171SolicitudesNombre, out  GXt_char2) ;
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = GXt_char2;
                           if ( A131EstadosSolId == 9 )
                           {
                              AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 251, 110, 82);
                           }
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesTelefono") == 0 )
                        {
                           GXt_char2 = "";
                           new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A172SolicitudesTelefono, out  GXt_char2) ;
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = GXt_char2;
                           if ( A131EstadosSolId == 9 )
                           {
                              AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 251, 110, 82);
                           }
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesFechaAlta") == 0 )
                        {
                           GXt_dtime4 = DateTimeUtil.ResetTime( A182SolicitudesFechaAlta ) ;
                           AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Date = GXt_dtime4;
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "DepartamentoDepartamento") == 0 )
                        {
                           GXt_char2 = "";
                           new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A113DepartamentoDepartamento, out  GXt_char2) ;
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = GXt_char2;
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "DepartamentoMunicipioNombre") == 0 )
                        {
                           GXt_char2 = "";
                           new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A115DepartamentoMunicipioNombre, out  GXt_char2) ;
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = GXt_char2;
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "ZonasNombre") == 0 )
                        {
                           GXt_char2 = "";
                           new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A111ZonasNombre, out  GXt_char2) ;
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = GXt_char2;
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesDireccion") == 0 )
                        {
                           GXt_char2 = "";
                           new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A173SolicitudesDireccion, out  GXt_char2) ;
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = GXt_char2;
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "SolicitudServicioPFinal") == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Number = (double)(A211SolicitudServicioPFinal);
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesComentario") == 0 )
                        {
                           GXt_char2 = "";
                           new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( A205SolicitudesComentario, 1, 1000), out  GXt_char2) ;
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = GXt_char2;
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "SolicitudServicioSolCoti") == 0 )
                        {
                           GXt_char2 = "";
                           new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A210SolicitudServicioSolCoti, out  GXt_char2) ;
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = GXt_char2;
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "ProveedorNombreAux") == 0 )
                        {
                           GXt_char2 = "";
                           new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A533ProveedorNombreAux, out  GXt_char2) ;
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = GXt_char2;
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesPagado") == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = "";
                           if ( StringUtil.StrCmp(StringUtil.Trim( A441SolicitudesPagado), context.GetMessage( "S", "")) == 0 )
                           {
                              AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = context.GetMessage( "Pagado", "");
                           }
                           else if ( StringUtil.StrCmp(StringUtil.Trim( A441SolicitudesPagado), context.GetMessage( "N", "")) == 0 )
                           {
                              AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = context.GetMessage( "Pendiente de Pago", "");
                           }
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "SolicitudServicioOrigenPago") == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainorigenpago.getDescription(context,A438SolicitudServicioOrigenPago), "");
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesSubTipo") == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainsolicitudsubtipo.getDescription(context,A600SolicitudesSubTipo), "");
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "MudanzaId") == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Number = A735MudanzaId;
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "STComerciosNombre") == 0 )
                        {
                           GXt_char2 = "";
                           new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A923STComerciosNombre, out  GXt_char2) ;
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Text = GXt_char2;
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesDuplicado") == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Number = A972SolicitudesDuplicado;
                        }
                        else if ( StringUtil.StrCmp(AV48ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesId") == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV54VisibleColumnCount), 1, 1).Number = A422PostulacionesId;
                        }
                        AV54VisibleColumnCount = (long)(AV54VisibleColumnCount+1);
                     }
                     AV232GXV5 = (int)(AV232GXV5+1);
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
         AV42Session.Set("WWPExportFilePath", AV12Filename);
         AV42Session.Set("WWPExportFileName", "SolicitudesWWExport.xlsx");
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
         AV46ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "&Incluir",  "",  "",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "SolicitudesID",  "",  "Solicitud",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "ProveedorID",  "",  "Comercio",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "SolicitudesFechaInstalacion",  "",  "Trabajo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "&HoraInstalacion",  "",  "Hora",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "&Dia",  "",  "",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "ProveedorNombre",  "",  "Comercio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "&Delegado",  "",  "Delegado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "SolicitudesNombre",  "",  "Contacto",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "SolicitudesTelefono",  "",  "Teléfono",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "SolicitudesFechaAlta",  "",  "Fecha de Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "DepartamentoDepartamento",  "",  "Departamento",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "DepartamentoMunicipioNombre",  "",  "Municipio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "ZonasNombre",  "",  "Zona",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "SolicitudesDireccion",  "",  "Dirección",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "SolicitudServicioPFinal",  "",  "Total",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "SolicitudesComentario",  "",  "Comentario",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "SolicitudServicioSolCoti",  "",  "Solicitó Cotización?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "ProveedorNombreAux",  "",  "Comercio Auxiliar",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "SolicitudesPagado",  "",  "Pagado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "SolicitudServicioOrigenPago",  "",  "Origen",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "SolicitudesSubTipo",  "",  "Sub Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "MudanzaId",  "",  "Mudanza Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "&Order",  "",  "Orden",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "STComerciosNombre",  "",  "Convenio Comercio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "SolicitudesDuplicado",  "",  "Duplicado (código)",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV46ColumnsSelector,  "PostulacionesId",  "",  "Postulaciones Id",  true,  "") ;
         GXt_char2 = AV50UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "SolicitudesWWColumnsSelector", out  GXt_char2) ;
         AV50UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50UserCustomValue)) ) )
         {
            AV47ColumnsSelectorAux.FromXml(AV50UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV47ColumnsSelectorAux, ref  AV46ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV42Session.Get("SolicitudesWWGridState"), "") == 0 )
         {
            AV44GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SolicitudesWWGridState"), null, "", "");
         }
         else
         {
            AV44GridState.FromXml(AV42Session.Get("SolicitudesWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV44GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV44GridState.gxTpr_Ordereddsc;
         AV233GXV6 = 1;
         while ( AV233GXV6 <= AV44GridState.gxTpr_Filtervalues.Count )
         {
            AV45GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV44GridState.gxTpr_Filtervalues.Item(AV233GXV6));
            if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESID") == 0 )
            {
               AV57TFSolicitudesID = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV58TFSolicitudesID_To = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV59TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV60TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID_SEL") == 0 )
            {
               AV151TFProveedorID_Sel = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESFECHAINSTALACION") == 0 )
            {
               AV71TFSolicitudesFechaInstalacion = context.localUtil.CToD( AV45GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV72TFSolicitudesFechaInstalacion_To = context.localUtil.CToD( AV45GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESFECHAALTA") == 0 )
            {
               AV69TFSolicitudesFechaAlta = context.localUtil.CToD( AV45GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV70TFSolicitudesFechaAlta_To = context.localUtil.CToD( AV45GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE") == 0 )
            {
               AV180TFDepartamentoMunicipioNombre = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE_SEL") == 0 )
            {
               AV181TFDepartamentoMunicipioNombre_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFZONASNOMBRE") == 0 )
            {
               AV182TFZonasNombre = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFZONASNOMBRE_SEL") == 0 )
            {
               AV183TFZonasNombre_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOPFINAL") == 0 )
            {
               AV105TFSolicitudServicioPFinal = NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, ".");
               AV106TFSolicitudServicioPFinal_To = NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOMENTARIO") == 0 )
            {
               AV65TFSolicitudesComentario = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOMENTARIO_SEL") == 0 )
            {
               AV66TFSolicitudesComentario_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBREAUX") == 0 )
            {
               AV154TFProveedorNombreAux = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBREAUX_SEL") == 0 )
            {
               AV155TFProveedorNombreAux_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESPAGADO_SEL") == 0 )
            {
               AV164TFSolicitudesPagado_SelsJson = AV45GridStateFilterValue.gxTpr_Value;
               AV165TFSolicitudesPagado_Sels.FromJSonString(AV164TFSolicitudesPagado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOORIGENPAGO_SEL") == 0 )
            {
               AV167TFSolicitudServicioOrigenPago_SelsJson = AV45GridStateFilterValue.gxTpr_Value;
               AV168TFSolicitudServicioOrigenPago_Sels.FromJSonString(AV167TFSolicitudServicioOrigenPago_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESSUBTIPO_SEL") == 0 )
            {
               AV171TFSolicitudesSubTipo_SelsJson = AV45GridStateFilterValue.gxTpr_Value;
               AV173TFSolicitudesSubTipo_Sels.FromJSonString(AV171TFSolicitudesSubTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFMUDANZAID") == 0 )
            {
               AV193TFMudanzaId = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV194TFMudanzaId_To = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSNOMBRE") == 0 )
            {
               AV187TFSTComerciosNombre = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSNOMBRE_SEL") == 0 )
            {
               AV188TFSTComerciosNombre_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESDUPLICADO") == 0 )
            {
               AV189TFSolicitudesDuplicado = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV190TFSolicitudesDuplicado_To = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESID") == 0 )
            {
               AV191TFPostulacionesId = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV192TFPostulacionesId_To = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "PARM_&INSOLICITUDESID") == 0 )
            {
               AV170inSolicitudesId = (short)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV233GXV6 = (int)(AV233GXV6+1);
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
         /* Using cursor P006T3 */
         pr_default.execute(1, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(1) != 101) && ( P006T3_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P006T3_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P006T3_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P006T3_A176SolicitudesItemsPrecioFinal[0]*P006T3_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P006T3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P006T3_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P006T3_A176SolicitudesItemsPrecioFinal[0]*P006T3_A177SolicitudesItemsCantidad[0])-(P006T3_A180SolicitudItemsComision[0]*P006T3_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P006T3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P006T3_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P006T3_A176SolicitudesItemsPrecioFinal[0]*P006T3_A177SolicitudesItemsCantidad[0])+(P006T3_A180SolicitudItemsComision[0]*P006T3_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P006T3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P006T3_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P006T3_A176SolicitudesItemsPrecioFinal[0]*P006T3_A177SolicitudesItemsCantidad[0])-((P006T3_A176SolicitudesItemsPrecioFinal[0]*P006T3_A177SolicitudesItemsCantidad[0])*(P006T3_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P006T3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P006T3_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P006T3_A176SolicitudesItemsPrecioFinal[0]*P006T3_A177SolicitudesItemsCantidad[0])+((P006T3_A176SolicitudesItemsPrecioFinal[0]*P006T3_A177SolicitudesItemsCantidad[0])*(P006T3_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         AV195Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV71TFSolicitudesFechaInstalacion = DateTime.MinValue;
         AV72TFSolicitudesFechaInstalacion_To = DateTime.MinValue;
         AV69TFSolicitudesFechaAlta = DateTime.MinValue;
         AV70TFSolicitudesFechaAlta_To = DateTime.MinValue;
         AV181TFDepartamentoMunicipioNombre_Sel = "";
         AV180TFDepartamentoMunicipioNombre = "";
         AV183TFZonasNombre_Sel = "";
         AV182TFZonasNombre = "";
         AV66TFSolicitudesComentario_Sel = "";
         AV65TFSolicitudesComentario = "";
         AV155TFProveedorNombreAux_Sel = "";
         AV154TFProveedorNombreAux = "";
         AV165TFSolicitudesPagado_Sels = new GxSimpleCollection<string>();
         AV166TFSolicitudesPagado_Sel = "";
         AV168TFSolicitudServicioOrigenPago_Sels = new GxSimpleCollection<string>();
         AV169TFSolicitudServicioOrigenPago_Sel = "";
         AV173TFSolicitudesSubTipo_Sels = new GxSimpleCollection<string>();
         AV172TFSolicitudesSubTipo_Sel = "";
         AV188TFSTComerciosNombre_Sel = "";
         AV187TFSTComerciosNombre = "";
         AV42Session = context.GetSession();
         AV49ColumnsSelectorXML = "";
         AV46ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV48ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV201Solicitudeswwds_1_filterfulltext = "";
         AV207Solicitudeswwds_7_tfsolicitudesfechainstalacion = DateTime.MinValue;
         AV208Solicitudeswwds_8_tfsolicitudesfechainstalacion_to = DateTime.MinValue;
         AV209Solicitudeswwds_9_tfsolicitudesfechaalta = DateTime.MinValue;
         AV210Solicitudeswwds_10_tfsolicitudesfechaalta_to = DateTime.MinValue;
         AV211Solicitudeswwds_11_tfdepartamentomunicipionombre = "";
         AV212Solicitudeswwds_12_tfdepartamentomunicipionombre_sel = "";
         AV213Solicitudeswwds_13_tfzonasnombre = "";
         AV214Solicitudeswwds_14_tfzonasnombre_sel = "";
         AV217Solicitudeswwds_17_tfsolicitudescomentario = "";
         AV218Solicitudeswwds_18_tfsolicitudescomentario_sel = "";
         AV219Solicitudeswwds_19_tfproveedornombreaux = "";
         AV220Solicitudeswwds_20_tfproveedornombreaux_sel = "";
         AV221Solicitudeswwds_21_tfsolicitudespagado_sels = new GxSimpleCollection<string>();
         AV222Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels = new GxSimpleCollection<string>();
         AV223Solicitudeswwds_23_tfsolicitudessubtipo_sels = new GxSimpleCollection<string>();
         AV226Solicitudeswwds_26_tfstcomerciosnombre = "";
         AV227Solicitudeswwds_27_tfstcomerciosnombre_sel = "";
         AV176ProveedorIDCollection = new GxSimpleCollection<long>();
         lV201Solicitudeswwds_1_filterfulltext = "";
         lV211Solicitudeswwds_11_tfdepartamentomunicipionombre = "";
         lV213Solicitudeswwds_13_tfzonasnombre = "";
         lV217Solicitudeswwds_17_tfsolicitudescomentario = "";
         lV219Solicitudeswwds_19_tfproveedornombreaux = "";
         lV226Solicitudeswwds_26_tfstcomerciosnombre = "";
         A441SolicitudesPagado = "";
         A438SolicitudServicioOrigenPago = "";
         A600SolicitudesSubTipo = "";
         A282ProveedorNombre = "";
         A171SolicitudesNombre = "";
         A172SolicitudesTelefono = "";
         A173SolicitudesDireccion = "";
         A203SolicitudesOtros3 = "";
         A113DepartamentoDepartamento = "";
         A533ProveedorNombreAux = "";
         A205SolicitudesComentario = "";
         A111ZonasNombre = "";
         A115DepartamentoMunicipioNombre = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A182SolicitudesFechaAlta = DateTime.MinValue;
         A923STComerciosNombre = "";
         AV157FechaIni = DateTime.MinValue;
         AV158FechaFin = DateTime.MinValue;
         A737MudanzaFechaAlta = DateTime.MinValue;
         P006T2_A112DepartamentoId = new long[1] ;
         P006T2_n112DepartamentoId = new bool[] {false} ;
         P006T2_A114DepartamentoMunicipioId = new long[1] ;
         P006T2_n114DepartamentoMunicipioId = new bool[] {false} ;
         P006T2_A110ZonasID = new long[1] ;
         P006T2_n110ZonasID = new bool[] {false} ;
         P006T2_A919STComerciosID = new long[1] ;
         P006T2_n919STComerciosID = new bool[] {false} ;
         P006T2_A131EstadosSolId = new int[1] ;
         P006T2_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P006T2_A113DepartamentoDepartamento = new string[] {""} ;
         P006T2_A203SolicitudesOtros3 = new string[] {""} ;
         P006T2_A173SolicitudesDireccion = new string[] {""} ;
         P006T2_A172SolicitudesTelefono = new string[] {""} ;
         P006T2_A171SolicitudesNombre = new string[] {""} ;
         P006T2_A282ProveedorNombre = new string[] {""} ;
         P006T2_A422PostulacionesId = new long[1] ;
         P006T2_n422PostulacionesId = new bool[] {false} ;
         P006T2_A972SolicitudesDuplicado = new long[1] ;
         P006T2_n972SolicitudesDuplicado = new bool[] {false} ;
         P006T2_A923STComerciosNombre = new string[] {""} ;
         P006T2_A735MudanzaId = new long[1] ;
         P006T2_n735MudanzaId = new bool[] {false} ;
         P006T2_A600SolicitudesSubTipo = new string[] {""} ;
         P006T2_n600SolicitudesSubTipo = new bool[] {false} ;
         P006T2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P006T2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P006T2_A441SolicitudesPagado = new string[] {""} ;
         P006T2_n441SolicitudesPagado = new bool[] {false} ;
         P006T2_A533ProveedorNombreAux = new string[] {""} ;
         P006T2_n533ProveedorNombreAux = new bool[] {false} ;
         P006T2_A205SolicitudesComentario = new string[] {""} ;
         P006T2_A111ZonasNombre = new string[] {""} ;
         P006T2_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P006T2_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P006T2_n182SolicitudesFechaAlta = new bool[] {false} ;
         P006T2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P006T2_A133ProveedorID = new long[1] ;
         P006T2_A127SolicitudesID = new long[1] ;
         P006T2_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P006T2_A210SolicitudServicioSolCoti = new string[] {""} ;
         P006T2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P006T2_A212SolicitudesCotizacion = new decimal[1] ;
         P006T2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P006T2_A897SolicitudesDescuento = new decimal[1] ;
         P006T2_n897SolicitudesDescuento = new bool[] {false} ;
         P006T2_A864SolicitudesCostoXZona = new decimal[1] ;
         A183SolicitudesHoraInstalacion = "";
         A210SolicitudServicioSolCoti = "";
         AV184HoraInstalacion = "";
         AV185Dia = "";
         GXt_dtime4 = (DateTime)(DateTime.MinValue);
         AV50UserCustomValue = "";
         GXt_char2 = "";
         AV47ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV44GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV45GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV164TFSolicitudesPagado_SelsJson = "";
         AV167TFSolicitudServicioOrigenPago_SelsJson = "";
         AV171TFSolicitudesSubTipo_SelsJson = "";
         P006T3_A127SolicitudesID = new long[1] ;
         P006T3_A134SolicitudesItemsID = new short[1] ;
         P006T3_A180SolicitudItemsComision = new decimal[1] ;
         P006T3_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P006T3_A178SolicitudItemsSR = new string[] {""} ;
         P006T3_A177SolicitudesItemsCantidad = new short[1] ;
         P006T3_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P006T3_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.solicitudeswwexport__default(),
            new Object[][] {
                new Object[] {
               P006T2_A112DepartamentoId, P006T2_n112DepartamentoId, P006T2_A114DepartamentoMunicipioId, P006T2_n114DepartamentoMunicipioId, P006T2_A110ZonasID, P006T2_n110ZonasID, P006T2_A919STComerciosID, P006T2_n919STComerciosID, P006T2_A131EstadosSolId, P006T2_A737MudanzaFechaAlta,
               P006T2_A113DepartamentoDepartamento, P006T2_A203SolicitudesOtros3, P006T2_A173SolicitudesDireccion, P006T2_A172SolicitudesTelefono, P006T2_A171SolicitudesNombre, P006T2_A282ProveedorNombre, P006T2_A422PostulacionesId, P006T2_n422PostulacionesId, P006T2_A972SolicitudesDuplicado, P006T2_n972SolicitudesDuplicado,
               P006T2_A923STComerciosNombre, P006T2_A735MudanzaId, P006T2_n735MudanzaId, P006T2_A600SolicitudesSubTipo, P006T2_n600SolicitudesSubTipo, P006T2_A438SolicitudServicioOrigenPago, P006T2_n438SolicitudServicioOrigenPago, P006T2_A441SolicitudesPagado, P006T2_n441SolicitudesPagado, P006T2_A533ProveedorNombreAux,
               P006T2_n533ProveedorNombreAux, P006T2_A205SolicitudesComentario, P006T2_A111ZonasNombre, P006T2_A115DepartamentoMunicipioNombre, P006T2_A182SolicitudesFechaAlta, P006T2_n182SolicitudesFechaAlta, P006T2_A184SolicitudesFechaInstalacion, P006T2_A133ProveedorID, P006T2_A127SolicitudesID, P006T2_A183SolicitudesHoraInstalacion,
               P006T2_A210SolicitudServicioSolCoti, P006T2_A796SolicitudesComisionMetodoPago, P006T2_A212SolicitudesCotizacion, P006T2_A1016SolicitudesDescuentoCupon, P006T2_A897SolicitudesDescuento, P006T2_n897SolicitudesDescuento, P006T2_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P006T3_A127SolicitudesID, P006T3_A134SolicitudesItemsID, P006T3_A180SolicitudItemsComision, P006T3_A179SolicitudItemsComisionTipo, P006T3_A178SolicitudItemsSR, P006T3_A177SolicitudesItemsCantidad, P006T3_A176SolicitudesItemsPrecioFinal, P006T3_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         AV195Pgmname = "SolicitudesWWExport";
         /* GeneXus formulas. */
         AV195Pgmname = "SolicitudesWWExport";
      }

      private short GXt_int3 ;
      private short AV17OrderedBy ;
      private short AV170inSolicitudesId ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV196GXV1 ;
      private int AV197GXV2 ;
      private int AV198GXV3 ;
      private int AV199GXV4 ;
      private int AV221Solicitudeswwds_21_tfsolicitudespagado_sels_Count ;
      private int AV222Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count ;
      private int AV223Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count ;
      private int AV176ProveedorIDCollection_Count ;
      private int A131EstadosSolId ;
      private int AV156EstadosGenericosID ;
      private int AV232GXV5 ;
      private int AV233GXV6 ;
      private long AV57TFSolicitudesID ;
      private long AV58TFSolicitudesID_To ;
      private long AV151TFProveedorID_Sel ;
      private long AV59TFProveedorID ;
      private long AV60TFProveedorID_To ;
      private long AV86i ;
      private long AV193TFMudanzaId ;
      private long AV194TFMudanzaId_To ;
      private long AV189TFSolicitudesDuplicado ;
      private long AV190TFSolicitudesDuplicado_To ;
      private long AV191TFPostulacionesId ;
      private long AV192TFPostulacionesId_To ;
      private long AV54VisibleColumnCount ;
      private long AV202Solicitudeswwds_2_tfsolicitudesid ;
      private long AV203Solicitudeswwds_3_tfsolicitudesid_to ;
      private long AV204Solicitudeswwds_4_tfproveedorid ;
      private long AV205Solicitudeswwds_5_tfproveedorid_to ;
      private long AV206Solicitudeswwds_6_tfproveedorid_sel ;
      private long AV224Solicitudeswwds_24_tfmudanzaid ;
      private long AV225Solicitudeswwds_25_tfmudanzaid_to ;
      private long AV228Solicitudeswwds_28_tfsolicitudesduplicado ;
      private long AV229Solicitudeswwds_29_tfsolicitudesduplicado_to ;
      private long AV230Solicitudeswwds_30_tfpostulacionesid ;
      private long AV231Solicitudeswwds_31_tfpostulacionesid_to ;
      private long A133ProveedorID ;
      private long AV178MudanzaId ;
      private long AV159ProveedorID ;
      private long A127SolicitudesID ;
      private long A735MudanzaId ;
      private long A972SolicitudesDuplicado ;
      private long A422PostulacionesId ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private long A919STComerciosID ;
      private decimal AV105TFSolicitudServicioPFinal ;
      private decimal AV106TFSolicitudServicioPFinal_To ;
      private decimal AV215Solicitudeswwds_15_tfsolicitudserviciopfinal ;
      private decimal AV216Solicitudeswwds_16_tfsolicitudserviciopfinal_to ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV195Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV181TFDepartamentoMunicipioNombre_Sel ;
      private string AV180TFDepartamentoMunicipioNombre ;
      private string AV183TFZonasNombre_Sel ;
      private string AV182TFZonasNombre ;
      private string AV155TFProveedorNombreAux_Sel ;
      private string AV154TFProveedorNombreAux ;
      private string AV166TFSolicitudesPagado_Sel ;
      private string AV169TFSolicitudServicioOrigenPago_Sel ;
      private string AV172TFSolicitudesSubTipo_Sel ;
      private string AV188TFSTComerciosNombre_Sel ;
      private string AV187TFSTComerciosNombre ;
      private string AV211Solicitudeswwds_11_tfdepartamentomunicipionombre ;
      private string AV212Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ;
      private string AV213Solicitudeswwds_13_tfzonasnombre ;
      private string AV214Solicitudeswwds_14_tfzonasnombre_sel ;
      private string AV219Solicitudeswwds_19_tfproveedornombreaux ;
      private string AV220Solicitudeswwds_20_tfproveedornombreaux_sel ;
      private string AV226Solicitudeswwds_26_tfstcomerciosnombre ;
      private string AV227Solicitudeswwds_27_tfstcomerciosnombre_sel ;
      private string lV211Solicitudeswwds_11_tfdepartamentomunicipionombre ;
      private string lV213Solicitudeswwds_13_tfzonasnombre ;
      private string lV219Solicitudeswwds_19_tfproveedornombreaux ;
      private string lV226Solicitudeswwds_26_tfstcomerciosnombre ;
      private string A441SolicitudesPagado ;
      private string A438SolicitudServicioOrigenPago ;
      private string A600SolicitudesSubTipo ;
      private string A282ProveedorNombre ;
      private string A171SolicitudesNombre ;
      private string A172SolicitudesTelefono ;
      private string A203SolicitudesOtros3 ;
      private string A113DepartamentoDepartamento ;
      private string A533ProveedorNombreAux ;
      private string A111ZonasNombre ;
      private string A115DepartamentoMunicipioNombre ;
      private string A923STComerciosNombre ;
      private string A183SolicitudesHoraInstalacion ;
      private string A210SolicitudServicioSolCoti ;
      private string GXt_char2 ;
      private DateTime GXt_dtime4 ;
      private DateTime AV71TFSolicitudesFechaInstalacion ;
      private DateTime AV72TFSolicitudesFechaInstalacion_To ;
      private DateTime AV69TFSolicitudesFechaAlta ;
      private DateTime AV70TFSolicitudesFechaAlta_To ;
      private DateTime AV207Solicitudeswwds_7_tfsolicitudesfechainstalacion ;
      private DateTime AV208Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ;
      private DateTime AV209Solicitudeswwds_9_tfsolicitudesfechaalta ;
      private DateTime AV210Solicitudeswwds_10_tfsolicitudesfechaalta_to ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private DateTime AV157FechaIni ;
      private DateTime AV158FechaFin ;
      private DateTime A737MudanzaFechaAlta ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n110ZonasID ;
      private bool n919STComerciosID ;
      private bool n422PostulacionesId ;
      private bool n972SolicitudesDuplicado ;
      private bool n735MudanzaId ;
      private bool n600SolicitudesSubTipo ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n441SolicitudesPagado ;
      private bool n533ProveedorNombreAux ;
      private bool n182SolicitudesFechaAlta ;
      private bool n897SolicitudesDescuento ;
      private string AV49ColumnsSelectorXML ;
      private string A205SolicitudesComentario ;
      private string AV50UserCustomValue ;
      private string AV164TFSolicitudesPagado_SelsJson ;
      private string AV167TFSolicitudServicioOrigenPago_SelsJson ;
      private string AV171TFSolicitudesSubTipo_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV66TFSolicitudesComentario_Sel ;
      private string AV65TFSolicitudesComentario ;
      private string AV201Solicitudeswwds_1_filterfulltext ;
      private string AV217Solicitudeswwds_17_tfsolicitudescomentario ;
      private string AV218Solicitudeswwds_18_tfsolicitudescomentario_sel ;
      private string lV201Solicitudeswwds_1_filterfulltext ;
      private string lV217Solicitudeswwds_17_tfsolicitudescomentario ;
      private string A173SolicitudesDireccion ;
      private string AV184HoraInstalacion ;
      private string AV185Dia ;
      private IGxSession AV42Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV165TFSolicitudesPagado_Sels ;
      private GxSimpleCollection<string> AV168TFSolicitudServicioOrigenPago_Sels ;
      private GxSimpleCollection<string> AV173TFSolicitudesSubTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV46ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV48ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV221Solicitudeswwds_21_tfsolicitudespagado_sels ;
      private GxSimpleCollection<string> AV222Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ;
      private GxSimpleCollection<string> AV223Solicitudeswwds_23_tfsolicitudessubtipo_sels ;
      private GxSimpleCollection<long> AV176ProveedorIDCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P006T2_A112DepartamentoId ;
      private bool[] P006T2_n112DepartamentoId ;
      private long[] P006T2_A114DepartamentoMunicipioId ;
      private bool[] P006T2_n114DepartamentoMunicipioId ;
      private long[] P006T2_A110ZonasID ;
      private bool[] P006T2_n110ZonasID ;
      private long[] P006T2_A919STComerciosID ;
      private bool[] P006T2_n919STComerciosID ;
      private int[] P006T2_A131EstadosSolId ;
      private DateTime[] P006T2_A737MudanzaFechaAlta ;
      private string[] P006T2_A113DepartamentoDepartamento ;
      private string[] P006T2_A203SolicitudesOtros3 ;
      private string[] P006T2_A173SolicitudesDireccion ;
      private string[] P006T2_A172SolicitudesTelefono ;
      private string[] P006T2_A171SolicitudesNombre ;
      private string[] P006T2_A282ProveedorNombre ;
      private long[] P006T2_A422PostulacionesId ;
      private bool[] P006T2_n422PostulacionesId ;
      private long[] P006T2_A972SolicitudesDuplicado ;
      private bool[] P006T2_n972SolicitudesDuplicado ;
      private string[] P006T2_A923STComerciosNombre ;
      private long[] P006T2_A735MudanzaId ;
      private bool[] P006T2_n735MudanzaId ;
      private string[] P006T2_A600SolicitudesSubTipo ;
      private bool[] P006T2_n600SolicitudesSubTipo ;
      private string[] P006T2_A438SolicitudServicioOrigenPago ;
      private bool[] P006T2_n438SolicitudServicioOrigenPago ;
      private string[] P006T2_A441SolicitudesPagado ;
      private bool[] P006T2_n441SolicitudesPagado ;
      private string[] P006T2_A533ProveedorNombreAux ;
      private bool[] P006T2_n533ProveedorNombreAux ;
      private string[] P006T2_A205SolicitudesComentario ;
      private string[] P006T2_A111ZonasNombre ;
      private string[] P006T2_A115DepartamentoMunicipioNombre ;
      private DateTime[] P006T2_A182SolicitudesFechaAlta ;
      private bool[] P006T2_n182SolicitudesFechaAlta ;
      private DateTime[] P006T2_A184SolicitudesFechaInstalacion ;
      private long[] P006T2_A133ProveedorID ;
      private long[] P006T2_A127SolicitudesID ;
      private string[] P006T2_A183SolicitudesHoraInstalacion ;
      private string[] P006T2_A210SolicitudServicioSolCoti ;
      private decimal[] P006T2_A796SolicitudesComisionMetodoPago ;
      private decimal[] P006T2_A212SolicitudesCotizacion ;
      private decimal[] P006T2_A1016SolicitudesDescuentoCupon ;
      private decimal[] P006T2_A897SolicitudesDescuento ;
      private bool[] P006T2_n897SolicitudesDescuento ;
      private decimal[] P006T2_A864SolicitudesCostoXZona ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV47ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV44GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV45GridStateFilterValue ;
      private long[] P006T3_A127SolicitudesID ;
      private short[] P006T3_A134SolicitudesItemsID ;
      private decimal[] P006T3_A180SolicitudItemsComision ;
      private string[] P006T3_A179SolicitudItemsComisionTipo ;
      private string[] P006T3_A178SolicitudItemsSR ;
      private short[] P006T3_A177SolicitudesItemsCantidad ;
      private decimal[] P006T3_A176SolicitudesItemsPrecioFinal ;
      private bool[] P006T3_n176SolicitudesItemsPrecioFinal ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class solicitudeswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006T2( IGxContext context ,
                                             string A441SolicitudesPagado ,
                                             GxSimpleCollection<string> AV221Solicitudeswwds_21_tfsolicitudespagado_sels ,
                                             string A438SolicitudServicioOrigenPago ,
                                             GxSimpleCollection<string> AV222Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ,
                                             string A600SolicitudesSubTipo ,
                                             GxSimpleCollection<string> AV223Solicitudeswwds_23_tfsolicitudessubtipo_sels ,
                                             long A133ProveedorID ,
                                             GxSimpleCollection<long> AV176ProveedorIDCollection ,
                                             int A131EstadosSolId ,
                                             string AV201Solicitudeswwds_1_filterfulltext ,
                                             long AV202Solicitudeswwds_2_tfsolicitudesid ,
                                             long AV203Solicitudeswwds_3_tfsolicitudesid_to ,
                                             long AV206Solicitudeswwds_6_tfproveedorid_sel ,
                                             DateTime AV207Solicitudeswwds_7_tfsolicitudesfechainstalacion ,
                                             DateTime AV208Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ,
                                             DateTime AV209Solicitudeswwds_9_tfsolicitudesfechaalta ,
                                             DateTime AV210Solicitudeswwds_10_tfsolicitudesfechaalta_to ,
                                             string AV212Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ,
                                             string AV211Solicitudeswwds_11_tfdepartamentomunicipionombre ,
                                             string AV214Solicitudeswwds_14_tfzonasnombre_sel ,
                                             string AV213Solicitudeswwds_13_tfzonasnombre ,
                                             string AV218Solicitudeswwds_18_tfsolicitudescomentario_sel ,
                                             string AV217Solicitudeswwds_17_tfsolicitudescomentario ,
                                             string AV220Solicitudeswwds_20_tfproveedornombreaux_sel ,
                                             string AV219Solicitudeswwds_19_tfproveedornombreaux ,
                                             int AV221Solicitudeswwds_21_tfsolicitudespagado_sels_Count ,
                                             int AV222Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count ,
                                             int AV223Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count ,
                                             long AV224Solicitudeswwds_24_tfmudanzaid ,
                                             long AV225Solicitudeswwds_25_tfmudanzaid_to ,
                                             string AV227Solicitudeswwds_27_tfstcomerciosnombre_sel ,
                                             string AV226Solicitudeswwds_26_tfstcomerciosnombre ,
                                             long AV228Solicitudeswwds_28_tfsolicitudesduplicado ,
                                             long AV229Solicitudeswwds_29_tfsolicitudesduplicado_to ,
                                             long AV230Solicitudeswwds_30_tfpostulacionesid ,
                                             long AV231Solicitudeswwds_31_tfpostulacionesid_to ,
                                             long AV178MudanzaId ,
                                             long AV159ProveedorID ,
                                             int AV176ProveedorIDCollection_Count ,
                                             int AV156EstadosGenericosID ,
                                             long A127SolicitudesID ,
                                             string A282ProveedorNombre ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A173SolicitudesDireccion ,
                                             string A203SolicitudesOtros3 ,
                                             string A113DepartamentoDepartamento ,
                                             string A533ProveedorNombreAux ,
                                             string A205SolicitudesComentario ,
                                             string A111ZonasNombre ,
                                             string A115DepartamentoMunicipioNombre ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime A182SolicitudesFechaAlta ,
                                             long A735MudanzaId ,
                                             string A923STComerciosNombre ,
                                             long A972SolicitudesDuplicado ,
                                             long A422PostulacionesId ,
                                             DateTime AV157FechaIni ,
                                             DateTime AV158FechaFin ,
                                             DateTime A737MudanzaFechaAlta ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             decimal AV215Solicitudeswwds_15_tfsolicitudserviciopfinal ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV216Solicitudeswwds_16_tfsolicitudserviciopfinal_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[39];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T1.[ZonasID], T1.[STComerciosID] AS STComerciosID, T1.[EstadosSolId], T6.[MudanzaFechaAlta], T2.[DepartamentoDepartamento], T1.[SolicitudesOtros3], T1.[SolicitudesDireccion], T1.[SolicitudesTelefono], T1.[SolicitudesNombre], T7.[ProveedorNombre], T1.[PostulacionesId], T1.[SolicitudesDuplicado], T5.[ProveedorNombre] AS STComerciosNombre, T1.[MudanzaId], T1.[SolicitudesSubTipo], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesPagado], T1.[ProveedorNombreAux], T1.[SolicitudesComentario], T4.[ZonasNombre], T3.[DepartamentoMunicipioNombre], T1.[SolicitudesFechaAlta], T1.[SolicitudesFechaInstalacion], T1.[ProveedorID], T1.[SolicitudesID], T1.[SolicitudesHoraInstalacion], T1.[SolicitudServicioSolCoti], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM (((((([Solicitudes] T1 LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) LEFT JOIN [DepartamentoMunicipio] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId] AND T3.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) LEFT JOIN [Zonas] T4 ON T4.[ZonasID] = T1.[ZonasID] AND T4.[DepartamentoId] = T1.[DepartamentoId] AND T4.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) LEFT JOIN [Proveedor] T5 ON T5.[ProveedorID] = T1.[STComerciosID]) LEFT JOIN [Mudanza] T6 ON T6.[MudanzaId] = T1.[MudanzaId]) INNER JOIN [Proveedor] T7 ON T7.[ProveedorID] = T1.[ProveedorID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV201Solicitudeswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[SolicitudesID] AS decimal(18,0))) like '%' + @lV201Solicitudeswwds_1_filterfulltext) or ( UPPER(T7.[ProveedorNombre]) like '%' + UPPER(@lV201Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesNombre]) like '%' + UPPER(@lV201Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesTelefono]) like '%' + UPPER(@lV201Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesDireccion]) like '%' + UPPER(@lV201Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesOtros3]) like '%' + UPPER(@lV201Solicitudeswwds_1_filterfulltext)) or ( UPPER(T2.[DepartamentoDepartamento]) like '%' + UPPER(@lV201Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[ProveedorNombreAux]) like '%' + UPPER(@lV201Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesComentario]) like '%' + UPPER(@lV201Solicitudeswwds_1_filterfulltext)) or ( UPPER(T4.[ZonasNombre]) like '%' + UPPER(@lV201Solicitudeswwds_1_filterfulltext)) or ( UPPER(T3.[DepartamentoMunicipioNombre]) like '%' + UPPER(@lV201Solicitudeswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
            GXv_int5[10] = 1;
         }
         if ( ! (0==AV202Solicitudeswwds_2_tfsolicitudesid) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] >= @AV202Solicitudeswwds_2_tfsolicitudesid)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (0==AV203Solicitudeswwds_3_tfsolicitudesid_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] <= @AV203Solicitudeswwds_3_tfsolicitudesid_to)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (0==AV206Solicitudeswwds_6_tfproveedorid_sel) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV206Solicitudeswwds_6_tfproveedorid_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV207Solicitudeswwds_7_tfsolicitudesfechainstalacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV207Solicitudeswwds_7_tfsolicitudesfechainstalacion)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV208Solicitudeswwds_8_tfsolicitudesfechainstalacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] <= @AV208Solicitudeswwds_8_tfsolicitudesfechainstalacion_to)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV209Solicitudeswwds_9_tfsolicitudesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] >= @AV209Solicitudeswwds_9_tfsolicitudesfechaalta)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV210Solicitudeswwds_10_tfsolicitudesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] <= @AV210Solicitudeswwds_10_tfsolicitudesfechaalta_to)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV212Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV211Solicitudeswwds_11_tfdepartamentomunicipionombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[DepartamentoMunicipioNombre]) like UPPER(@lV211Solicitudeswwds_11_tfdepartamentomunicipionombre))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV212Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)) && ! ( StringUtil.StrCmp(AV212Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[DepartamentoMunicipioNombre] = @AV212Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( StringUtil.StrCmp(AV212Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[DepartamentoMunicipioNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV214Solicitudeswwds_14_tfzonasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV213Solicitudeswwds_13_tfzonasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ZonasNombre]) like UPPER(@lV213Solicitudeswwds_13_tfzonasnombre))");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV214Solicitudeswwds_14_tfzonasnombre_sel)) && ! ( StringUtil.StrCmp(AV214Solicitudeswwds_14_tfzonasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[ZonasNombre] = @AV214Solicitudeswwds_14_tfzonasnombre_sel)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( StringUtil.StrCmp(AV214Solicitudeswwds_14_tfzonasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[ZonasNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV218Solicitudeswwds_18_tfsolicitudescomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV217Solicitudeswwds_17_tfsolicitudescomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesComentario]) like UPPER(@lV217Solicitudeswwds_17_tfsolicitudescomentario))");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV218Solicitudeswwds_18_tfsolicitudescomentario_sel)) && ! ( StringUtil.StrCmp(AV218Solicitudeswwds_18_tfsolicitudescomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesComentario] = @AV218Solicitudeswwds_18_tfsolicitudescomentario_sel)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( StringUtil.StrCmp(AV218Solicitudeswwds_18_tfsolicitudescomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[SolicitudesComentario])=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV220Solicitudeswwds_20_tfproveedornombreaux_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV219Solicitudeswwds_19_tfproveedornombreaux)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorNombreAux]) like UPPER(@lV219Solicitudeswwds_19_tfproveedornombreaux))");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV220Solicitudeswwds_20_tfproveedornombreaux_sel)) && ! ( StringUtil.StrCmp(AV220Solicitudeswwds_20_tfproveedornombreaux_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombreAux] = @AV220Solicitudeswwds_20_tfproveedornombreaux_sel)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( StringUtil.StrCmp(AV220Solicitudeswwds_20_tfproveedornombreaux_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombreAux] IS NULL or (T1.[ProveedorNombreAux] = ''))");
         }
         if ( AV221Solicitudeswwds_21_tfsolicitudespagado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV221Solicitudeswwds_21_tfsolicitudespagado_sels, "T1.[SolicitudesPagado] IN (", ")")+")");
         }
         if ( AV222Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV222Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels, "T1.[SolicitudServicioOrigenPago] IN (", ")")+")");
         }
         if ( AV223Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV223Solicitudeswwds_23_tfsolicitudessubtipo_sels, "T1.[SolicitudesSubTipo] IN (", ")")+")");
         }
         if ( ! (0==AV224Solicitudeswwds_24_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV224Solicitudeswwds_24_tfmudanzaid)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! (0==AV225Solicitudeswwds_25_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV225Solicitudeswwds_25_tfmudanzaid_to)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV227Solicitudeswwds_27_tfstcomerciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV226Solicitudeswwds_26_tfstcomerciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T5.[ProveedorNombre]) like UPPER(@lV226Solicitudeswwds_26_tfstcomerciosnombre))");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV227Solicitudeswwds_27_tfstcomerciosnombre_sel)) && ! ( StringUtil.StrCmp(AV227Solicitudeswwds_27_tfstcomerciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] = @AV227Solicitudeswwds_27_tfstcomerciosnombre_sel)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( StringUtil.StrCmp(AV227Solicitudeswwds_27_tfstcomerciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] IS NULL or (T5.[ProveedorNombre] = ''))");
         }
         if ( ! (0==AV228Solicitudeswwds_28_tfsolicitudesduplicado) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDuplicado] >= @AV228Solicitudeswwds_28_tfsolicitudesduplicado)");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( ! (0==AV229Solicitudeswwds_29_tfsolicitudesduplicado_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDuplicado] <= @AV229Solicitudeswwds_29_tfsolicitudesduplicado_to)");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( ! (0==AV230Solicitudeswwds_30_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV230Solicitudeswwds_30_tfpostulacionesid)");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( ! (0==AV231Solicitudeswwds_31_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV231Solicitudeswwds_31_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( (0==AV178MudanzaId) )
         {
            AddWhere(sWhereString, "(( T1.[SolicitudesFechaInstalacion] >= @AV157FechaIni and T1.[SolicitudesFechaInstalacion] <= @AV158FechaFin) or ( (T1.[SolicitudesFechaInstalacion] = convert( DATETIME, '17530101', 112 )) and T1.[SolicitudesSubTipo] IN ('Z','P','S')))");
         }
         else
         {
            GXv_int5[34] = 1;
            GXv_int5[35] = 1;
         }
         if ( ! (0==AV178MudanzaId) )
         {
            AddWhere(sWhereString, "(T6.[MudanzaFechaAlta] >= @AV157FechaIni and T6.[MudanzaFechaAlta] <= @AV158FechaFin)");
         }
         else
         {
            GXv_int5[36] = 1;
            GXv_int5[37] = 1;
         }
         if ( ! (0==AV159ProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV159ProveedorID)");
         }
         else
         {
            GXv_int5[38] = 1;
         }
         if ( AV176ProveedorIDCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV176ProveedorIDCollection, "T1.[ProveedorID] IN (", ")")+")");
         }
         if ( AV156EstadosGenericosID == 1 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (1,9))");
         }
         if ( AV156EstadosGenericosID == 2 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (2,9))");
         }
         if ( AV156EstadosGenericosID == 3 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (3,9))");
         }
         if ( AV156EstadosGenericosID == 4 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (4,9))");
         }
         if ( AV156EstadosGenericosID == 5 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (5,9))");
         }
         if ( AV156EstadosGenericosID == 6 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (6,9))");
         }
         if ( AV156EstadosGenericosID == 7 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (7,9))");
         }
         if ( AV156EstadosGenericosID == 8 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (8,9))");
         }
         if ( AV156EstadosGenericosID == 9 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 9)");
         }
         if ( AV156EstadosGenericosID == 10 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 10)");
         }
         if ( AV156EstadosGenericosID == 11 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 11)");
         }
         if ( AV156EstadosGenericosID == 12 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 12)");
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesID] DESC, T1.[SolicitudesFechaInstalacion] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesID]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesID] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorID]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorID] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaInstalacion]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaInstalacion] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T7.[ProveedorNombre]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T7.[ProveedorNombre] DESC";
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
            scmdbuf += " ORDER BY T1.[SolicitudesFechaAlta]";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaAlta] DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[DepartamentoDepartamento]";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[DepartamentoDepartamento] DESC";
         }
         else if ( ( AV17OrderedBy == 10 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[DepartamentoMunicipioNombre]";
         }
         else if ( ( AV17OrderedBy == 10 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[DepartamentoMunicipioNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 11 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[ZonasNombre]";
         }
         else if ( ( AV17OrderedBy == 11 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[ZonasNombre] DESC";
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
            scmdbuf += " ORDER BY T1.[SolicitudesComentario]";
         }
         else if ( ( AV17OrderedBy == 13 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesComentario] DESC";
         }
         else if ( ( AV17OrderedBy == 14 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioSolCoti]";
         }
         else if ( ( AV17OrderedBy == 14 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioSolCoti] DESC";
         }
         else if ( ( AV17OrderedBy == 15 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorNombreAux]";
         }
         else if ( ( AV17OrderedBy == 15 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorNombreAux] DESC";
         }
         else if ( ( AV17OrderedBy == 16 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesPagado]";
         }
         else if ( ( AV17OrderedBy == 16 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesPagado] DESC";
         }
         else if ( ( AV17OrderedBy == 17 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioOrigenPago]";
         }
         else if ( ( AV17OrderedBy == 17 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioOrigenPago] DESC";
         }
         else if ( ( AV17OrderedBy == 18 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesSubTipo]";
         }
         else if ( ( AV17OrderedBy == 18 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesSubTipo] DESC";
         }
         else if ( ( AV17OrderedBy == 19 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaId]";
         }
         else if ( ( AV17OrderedBy == 19 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaId] DESC";
         }
         else if ( ( AV17OrderedBy == 20 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.[ProveedorNombre]";
         }
         else if ( ( AV17OrderedBy == 20 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.[ProveedorNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 21 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDuplicado]";
         }
         else if ( ( AV17OrderedBy == 21 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDuplicado] DESC";
         }
         else if ( ( AV17OrderedBy == 22 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesId]";
         }
         else if ( ( AV17OrderedBy == 22 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesId] DESC";
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
                     return conditional_P006T2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (long)dynConstraints[6] , (GxSimpleCollection<long>)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (long)dynConstraints[35] , (long)dynConstraints[36] , (long)dynConstraints[37] , (int)dynConstraints[38] , (int)dynConstraints[39] , (long)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (long)dynConstraints[53] , (string)dynConstraints[54] , (long)dynConstraints[55] , (long)dynConstraints[56] , (DateTime)dynConstraints[57] , (DateTime)dynConstraints[58] , (DateTime)dynConstraints[59] , (short)dynConstraints[60] , (bool)dynConstraints[61] , (decimal)dynConstraints[62] , (decimal)dynConstraints[63] , (decimal)dynConstraints[64] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006T3;
          prmP006T3 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP006T2;
          prmP006T2 = new Object[] {
          new ParDef("@lV201Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV201Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV201Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV201Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV201Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV201Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV201Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV201Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV201Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV201Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV201Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV202Solicitudeswwds_2_tfsolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV203Solicitudeswwds_3_tfsolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV206Solicitudeswwds_6_tfproveedorid_sel",GXType.Decimal,18,0) ,
          new ParDef("@AV207Solicitudeswwds_7_tfsolicitudesfechainstalacion",GXType.Date,8,0) ,
          new ParDef("@AV208Solicitudeswwds_8_tfsolicitudesfechainstalacion_to",GXType.Date,8,0) ,
          new ParDef("@AV209Solicitudeswwds_9_tfsolicitudesfechaalta",GXType.Date,8,0) ,
          new ParDef("@AV210Solicitudeswwds_10_tfsolicitudesfechaalta_to",GXType.Date,8,0) ,
          new ParDef("@lV211Solicitudeswwds_11_tfdepartamentomunicipionombre",GXType.Char,120,0) ,
          new ParDef("@AV212Solicitudeswwds_12_tfdepartamentomunicipionombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV213Solicitudeswwds_13_tfzonasnombre",GXType.Char,120,0) ,
          new ParDef("@AV214Solicitudeswwds_14_tfzonasnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV217Solicitudeswwds_17_tfsolicitudescomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV218Solicitudeswwds_18_tfsolicitudescomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV219Solicitudeswwds_19_tfproveedornombreaux",GXType.Char,80,0) ,
          new ParDef("@AV220Solicitudeswwds_20_tfproveedornombreaux_sel",GXType.NChar,80,0) ,
          new ParDef("@AV224Solicitudeswwds_24_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV225Solicitudeswwds_25_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV226Solicitudeswwds_26_tfstcomerciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV227Solicitudeswwds_27_tfstcomerciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV228Solicitudeswwds_28_tfsolicitudesduplicado",GXType.Decimal,18,0) ,
          new ParDef("@AV229Solicitudeswwds_29_tfsolicitudesduplicado_to",GXType.Decimal,18,0) ,
          new ParDef("@AV230Solicitudeswwds_30_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV231Solicitudeswwds_31_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV157FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV158FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV157FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV158FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV159ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006T2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006T3", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006T3,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((string[]) buf[10])[0] = rslt.getString(7, 80);
                ((string[]) buf[11])[0] = rslt.getString(8, 500);
                ((string[]) buf[12])[0] = rslt.getVarchar(9);
                ((string[]) buf[13])[0] = rslt.getString(10, 20);
                ((string[]) buf[14])[0] = rslt.getString(11, 100);
                ((string[]) buf[15])[0] = rslt.getString(12, 80);
                ((long[]) buf[16])[0] = rslt.getLong(13);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((long[]) buf[18])[0] = rslt.getLong(14);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((string[]) buf[20])[0] = rslt.getString(15, 80);
                ((long[]) buf[21])[0] = rslt.getLong(16);
                ((bool[]) buf[22])[0] = rslt.wasNull(16);
                ((string[]) buf[23])[0] = rslt.getString(17, 1);
                ((bool[]) buf[24])[0] = rslt.wasNull(17);
                ((string[]) buf[25])[0] = rslt.getString(18, 1);
                ((bool[]) buf[26])[0] = rslt.wasNull(18);
                ((string[]) buf[27])[0] = rslt.getString(19, 1);
                ((bool[]) buf[28])[0] = rslt.wasNull(19);
                ((string[]) buf[29])[0] = rslt.getString(20, 80);
                ((bool[]) buf[30])[0] = rslt.wasNull(20);
                ((string[]) buf[31])[0] = rslt.getLongVarchar(21);
                ((string[]) buf[32])[0] = rslt.getString(22, 120);
                ((string[]) buf[33])[0] = rslt.getString(23, 120);
                ((DateTime[]) buf[34])[0] = rslt.getGXDate(24);
                ((bool[]) buf[35])[0] = rslt.wasNull(24);
                ((DateTime[]) buf[36])[0] = rslt.getGXDate(25);
                ((long[]) buf[37])[0] = rslt.getLong(26);
                ((long[]) buf[38])[0] = rslt.getLong(27);
                ((string[]) buf[39])[0] = rslt.getString(28, 1);
                ((string[]) buf[40])[0] = rslt.getString(29, 1);
                ((decimal[]) buf[41])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[42])[0] = rslt.getDecimal(31);
                ((decimal[]) buf[43])[0] = rslt.getDecimal(32);
                ((decimal[]) buf[44])[0] = rslt.getDecimal(33);
                ((bool[]) buf[45])[0] = rslt.wasNull(33);
                ((decimal[]) buf[46])[0] = rslt.getDecimal(34);
                return;
             case 1 :
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
