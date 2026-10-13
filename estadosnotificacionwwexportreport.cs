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
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class estadosnotificacionwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public estadosnotificacionwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public estadosnotificacionwwexportreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("EstadosNotificacionWWExportReport");
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 1, 15840, 12240, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV41Pgmname));
               CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
            if ( AV8IsAuthorized )
            {
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
               /* Execute user subroutine: 'LOADGRIDSTATE' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV39Title = context.GetMessage( "Lista de Estados Notificacion", "");
               /* Execute user subroutine: 'PRINTFILTERS' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTCOLUMNTITLES' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTDATA' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTFOOTER' */
               S171 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HC90( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'PRINTFILTERS' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            HC90( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFEstadosTipo_Sel)) )
         {
            AV28TempBoolean = (bool)(((StringUtil.StrCmp(AV19TFEstadosTipo_Sel, "<#Empty#>")==0)));
            AV19TFEstadosTipo_Sel = (AV28TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV19TFEstadosTipo_Sel);
            HC90( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Estados", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19TFEstadosTipo_Sel, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV19TFEstadosTipo_Sel = (AV28TempBoolean ? "<#Empty#>" : AV19TFEstadosTipo_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFEstadosTipo)) )
            {
               HC90( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Tipo de Estados", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18TFEstadosTipo, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV20TFEstadosGenericosId) && (0==AV21TFEstadosGenericosId_To) ) )
         {
            HC90( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Identificador", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV20TFEstadosGenericosId), "ZZZZ9")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV27TFEstadosGenericosId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Identificador", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HC90( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27TFEstadosGenericosId_To_Description, "")), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV21TFEstadosGenericosId_To), "ZZZZ9")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFEstadosGenericosNombre_Sel)) )
         {
            AV28TempBoolean = (bool)(((StringUtil.StrCmp(AV23TFEstadosGenericosNombre_Sel, "<#Empty#>")==0)));
            AV23TFEstadosGenericosNombre_Sel = (AV28TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV23TFEstadosGenericosNombre_Sel);
            HC90( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23TFEstadosGenericosNombre_Sel, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV23TFEstadosGenericosNombre_Sel = (AV28TempBoolean ? "<#Empty#>" : AV23TFEstadosGenericosNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFEstadosGenericosNombre)) )
            {
               HC90( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22TFEstadosGenericosNombre, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFEstadosNotificacionCliente_Sel)) )
         {
            AV28TempBoolean = (bool)(((StringUtil.StrCmp(AV24TFEstadosNotificacionCliente_Sel, "<#Empty#>")==0)));
            AV24TFEstadosNotificacionCliente_Sel = (AV28TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV24TFEstadosNotificacionCliente_Sel);
            HC90( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Notificar al cliente el nuevo estado", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24TFEstadosNotificacionCliente_Sel, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV24TFEstadosNotificacionCliente_Sel = (AV28TempBoolean ? "<#Empty#>" : AV24TFEstadosNotificacionCliente_Sel);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFEstadosNotificacionProfesional_Sel)) )
         {
            AV28TempBoolean = (bool)(((StringUtil.StrCmp(AV25TFEstadosNotificacionProfesional_Sel, "<#Empty#>")==0)));
            AV25TFEstadosNotificacionProfesional_Sel = (AV28TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV25TFEstadosNotificacionProfesional_Sel);
            HC90( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Notificar al profesional el nuevo estado", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25TFEstadosNotificacionProfesional_Sel, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV25TFEstadosNotificacionProfesional_Sel = (AV28TempBoolean ? "<#Empty#>" : AV25TFEstadosNotificacionProfesional_Sel);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFEstadosNotificacionOperador_Sel)) )
         {
            AV28TempBoolean = (bool)(((StringUtil.StrCmp(AV26TFEstadosNotificacionOperador_Sel, "<#Empty#>")==0)));
            AV26TFEstadosNotificacionOperador_Sel = (AV28TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV26TFEstadosNotificacionOperador_Sel);
            HC90( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Notificar al operador el nuevo estado", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26TFEstadosNotificacionOperador_Sel, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV26TFEstadosNotificacionOperador_Sel = (AV28TempBoolean ? "<#Empty#>" : AV26TFEstadosNotificacionOperador_Sel);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HC90( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HC90( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Tipo de Estados", ""), 30, Gx_line+10, 135, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Identificador", ""), 139, Gx_line+10, 244, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 248, Gx_line+10, 458, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Notificar al cliente el nuevo estado", ""), 462, Gx_line+10, 567, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Notificar al profesional el nuevo estado", ""), 571, Gx_line+10, 677, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Notificar al operador el nuevo estado", ""), 681, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV45Estadosnotificacionwwds_1_filterfulltext = AV13FilterFullText;
         AV46Estadosnotificacionwwds_2_tfestadostipo = AV18TFEstadosTipo;
         AV47Estadosnotificacionwwds_3_tfestadostipo_sel = AV19TFEstadosTipo_Sel;
         AV48Estadosnotificacionwwds_4_tfestadosgenericosid = AV20TFEstadosGenericosId;
         AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to = AV21TFEstadosGenericosId_To;
         AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre = AV22TFEstadosGenericosNombre;
         AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel = AV23TFEstadosGenericosNombre_Sel;
         AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel = AV24TFEstadosNotificacionCliente_Sel;
         AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel = AV25TFEstadosNotificacionProfesional_Sel;
         AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel = AV26TFEstadosNotificacionOperador_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV45Estadosnotificacionwwds_1_filterfulltext ,
                                              AV47Estadosnotificacionwwds_3_tfestadostipo_sel ,
                                              AV46Estadosnotificacionwwds_2_tfestadostipo ,
                                              AV48Estadosnotificacionwwds_4_tfestadosgenericosid ,
                                              AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to ,
                                              AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel ,
                                              AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre ,
                                              AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel ,
                                              AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel ,
                                              AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel ,
                                              A107EstadosTipo ,
                                              A108EstadosGenericosId ,
                                              A109EstadosGenericosNombre ,
                                              A263EstadosNotificacionCliente ,
                                              A264EstadosNotificacionProfesional ,
                                              A265EstadosNotificacionOperador ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV45Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Estadosnotificacionwwds_1_filterfulltext), "%", "");
         lV45Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Estadosnotificacionwwds_1_filterfulltext), "%", "");
         lV45Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Estadosnotificacionwwds_1_filterfulltext), "%", "");
         lV46Estadosnotificacionwwds_2_tfestadostipo = StringUtil.PadR( StringUtil.RTrim( AV46Estadosnotificacionwwds_2_tfestadostipo), 3, "%");
         lV50Estadosnotificacionwwds_6_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre), 80, "%");
         /* Using cursor P00C92 */
         pr_default.execute(0, new Object[] {lV45Estadosnotificacionwwds_1_filterfulltext, lV45Estadosnotificacionwwds_1_filterfulltext, lV45Estadosnotificacionwwds_1_filterfulltext, lV46Estadosnotificacionwwds_2_tfestadostipo, AV47Estadosnotificacionwwds_3_tfestadostipo_sel, AV48Estadosnotificacionwwds_4_tfestadosgenericosid, AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to, lV50Estadosnotificacionwwds_6_tfestadosgenericosnombre, AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel, AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel, AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A265EstadosNotificacionOperador = P00C92_A265EstadosNotificacionOperador[0];
            A264EstadosNotificacionProfesional = P00C92_A264EstadosNotificacionProfesional[0];
            A263EstadosNotificacionCliente = P00C92_A263EstadosNotificacionCliente[0];
            A109EstadosGenericosNombre = P00C92_A109EstadosGenericosNombre[0];
            A108EstadosGenericosId = P00C92_A108EstadosGenericosId[0];
            A107EstadosTipo = P00C92_A107EstadosTipo[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HC90( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A107EstadosTipo, "")), 30, Gx_line+10, 135, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9")), 139, Gx_line+10, 244, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A109EstadosGenericosNombre, "")), 248, Gx_line+10, 458, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A263EstadosNotificacionCliente, "")), 462, Gx_line+10, 567, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A264EstadosNotificacionProfesional, "")), 571, Gx_line+10, 677, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A265EstadosNotificacionOperador, "")), 681, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+36);
            /* Execute user subroutine: 'AFTERPRINTLINE' */
            S161 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV14Session.Get("EstadosNotificacionWWGridState"), "") == 0 )
         {
            AV16GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "EstadosNotificacionWWGridState"), null, "", "");
         }
         else
         {
            AV16GridState.FromXml(AV14Session.Get("EstadosNotificacionWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV16GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV16GridState.gxTpr_Ordereddsc;
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV16GridState.gxTpr_Filtervalues.Count )
         {
            AV17GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV16GridState.gxTpr_Filtervalues.Item(AV55GXV1));
            if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFESTADOSTIPO") == 0 )
            {
               AV18TFEstadosTipo = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFESTADOSTIPO_SEL") == 0 )
            {
               AV19TFEstadosTipo_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSID") == 0 )
            {
               AV20TFEstadosGenericosId = (int)(Math.Round(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV21TFEstadosGenericosId_To = (int)(Math.Round(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE") == 0 )
            {
               AV22TFEstadosGenericosNombre = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE_SEL") == 0 )
            {
               AV23TFEstadosGenericosNombre_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFESTADOSNOTIFICACIONCLIENTE_SEL") == 0 )
            {
               AV24TFEstadosNotificacionCliente_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFESTADOSNOTIFICACIONPROFESIONAL_SEL") == 0 )
            {
               AV25TFEstadosNotificacionProfesional_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFESTADOSNOTIFICACIONOPERADOR_SEL") == 0 )
            {
               AV26TFEstadosNotificacionOperador_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S161( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void HC90( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  AV37PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV34DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               AV32AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV38Phone = "+1 550 8923";
               AV36Mail = "info@mail.com";
               AV40Website = "http://www.web.com";
               AV29AddressLine1 = "French Boulevard 2859";
               AV30AddressLine2 = "Downtown";
               AV31AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+128);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV41Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV39Title = "";
         AV13FilterFullText = "";
         AV19TFEstadosTipo_Sel = "";
         AV18TFEstadosTipo = "";
         AV27TFEstadosGenericosId_To_Description = "";
         AV23TFEstadosGenericosNombre_Sel = "";
         AV22TFEstadosGenericosNombre = "";
         AV24TFEstadosNotificacionCliente_Sel = "";
         AV25TFEstadosNotificacionProfesional_Sel = "";
         AV26TFEstadosNotificacionOperador_Sel = "";
         AV45Estadosnotificacionwwds_1_filterfulltext = "";
         AV46Estadosnotificacionwwds_2_tfestadostipo = "";
         AV47Estadosnotificacionwwds_3_tfestadostipo_sel = "";
         AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre = "";
         AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel = "";
         AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel = "";
         AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel = "";
         AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel = "";
         lV45Estadosnotificacionwwds_1_filterfulltext = "";
         lV46Estadosnotificacionwwds_2_tfestadostipo = "";
         lV50Estadosnotificacionwwds_6_tfestadosgenericosnombre = "";
         A107EstadosTipo = "";
         A109EstadosGenericosNombre = "";
         A263EstadosNotificacionCliente = "";
         A264EstadosNotificacionProfesional = "";
         A265EstadosNotificacionOperador = "";
         P00C92_A265EstadosNotificacionOperador = new string[] {""} ;
         P00C92_A264EstadosNotificacionProfesional = new string[] {""} ;
         P00C92_A263EstadosNotificacionCliente = new string[] {""} ;
         P00C92_A109EstadosGenericosNombre = new string[] {""} ;
         P00C92_A108EstadosGenericosId = new int[1] ;
         P00C92_A107EstadosTipo = new string[] {""} ;
         AV14Session = context.GetSession();
         AV16GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV17GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV37PageInfo = "";
         AV34DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV32AppName = "";
         AV38Phone = "";
         AV36Mail = "";
         AV40Website = "";
         AV29AddressLine1 = "";
         AV30AddressLine2 = "";
         AV31AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estadosnotificacionwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00C92_A265EstadosNotificacionOperador, P00C92_A264EstadosNotificacionProfesional, P00C92_A263EstadosNotificacionCliente, P00C92_A109EstadosGenericosNombre, P00C92_A108EstadosGenericosId, P00C92_A107EstadosTipo
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV41Pgmname = "EstadosNotificacionWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV41Pgmname = "EstadosNotificacionWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV20TFEstadosGenericosId ;
      private int AV21TFEstadosGenericosId_To ;
      private int AV48Estadosnotificacionwwds_4_tfestadosgenericosid ;
      private int AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to ;
      private int A108EstadosGenericosId ;
      private int AV55GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV41Pgmname ;
      private string GXEncryptionTmp ;
      private string AV19TFEstadosTipo_Sel ;
      private string AV18TFEstadosTipo ;
      private string AV23TFEstadosGenericosNombre_Sel ;
      private string AV22TFEstadosGenericosNombre ;
      private string AV24TFEstadosNotificacionCliente_Sel ;
      private string AV25TFEstadosNotificacionProfesional_Sel ;
      private string AV26TFEstadosNotificacionOperador_Sel ;
      private string AV46Estadosnotificacionwwds_2_tfestadostipo ;
      private string AV47Estadosnotificacionwwds_3_tfestadostipo_sel ;
      private string AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre ;
      private string AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel ;
      private string AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel ;
      private string AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel ;
      private string AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel ;
      private string lV46Estadosnotificacionwwds_2_tfestadostipo ;
      private string lV50Estadosnotificacionwwds_6_tfestadosgenericosnombre ;
      private string A107EstadosTipo ;
      private string A109EstadosGenericosNombre ;
      private string A263EstadosNotificacionCliente ;
      private string A264EstadosNotificacionProfesional ;
      private string A265EstadosNotificacionOperador ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV28TempBoolean ;
      private bool AV12OrderedDsc ;
      private string AV39Title ;
      private string AV13FilterFullText ;
      private string AV27TFEstadosGenericosId_To_Description ;
      private string AV45Estadosnotificacionwwds_1_filterfulltext ;
      private string lV45Estadosnotificacionwwds_1_filterfulltext ;
      private string AV37PageInfo ;
      private string AV34DateInfo ;
      private string AV32AppName ;
      private string AV38Phone ;
      private string AV36Mail ;
      private string AV40Website ;
      private string AV29AddressLine1 ;
      private string AV30AddressLine2 ;
      private string AV31AddressLine3 ;
      private IGxSession AV14Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P00C92_A265EstadosNotificacionOperador ;
      private string[] P00C92_A264EstadosNotificacionProfesional ;
      private string[] P00C92_A263EstadosNotificacionCliente ;
      private string[] P00C92_A109EstadosGenericosNombre ;
      private int[] P00C92_A108EstadosGenericosId ;
      private string[] P00C92_A107EstadosTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV16GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV17GridStateFilterValue ;
   }

   public class estadosnotificacionwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C92( IGxContext context ,
                                             string AV45Estadosnotificacionwwds_1_filterfulltext ,
                                             string AV47Estadosnotificacionwwds_3_tfestadostipo_sel ,
                                             string AV46Estadosnotificacionwwds_2_tfestadostipo ,
                                             int AV48Estadosnotificacionwwds_4_tfestadosgenericosid ,
                                             int AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to ,
                                             string AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel ,
                                             string AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre ,
                                             string AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel ,
                                             string AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel ,
                                             string AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel ,
                                             string A107EstadosTipo ,
                                             int A108EstadosGenericosId ,
                                             string A109EstadosGenericosNombre ,
                                             string A263EstadosNotificacionCliente ,
                                             string A264EstadosNotificacionProfesional ,
                                             string A265EstadosNotificacionOperador ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [EstadosNotificacionOperador], [EstadosNotificacionProfesional], [EstadosNotificacionCliente], [EstadosGenericosNombre], [EstadosGenericosId], [EstadosTipo] FROM [EstadosGenericos]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Estadosnotificacionwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([EstadosTipo]) like '%' + UPPER(@lV45Estadosnotificacionwwds_1_filterfulltext)) or ( CONVERT( char(5), CAST([EstadosGenericosId] AS decimal(5,0))) like '%' + @lV45Estadosnotificacionwwds_1_filterfulltext) or ( UPPER([EstadosGenericosNombre]) like '%' + UPPER(@lV45Estadosnotificacionwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Estadosnotificacionwwds_3_tfestadostipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Estadosnotificacionwwds_2_tfestadostipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosTipo]) like UPPER(@lV46Estadosnotificacionwwds_2_tfestadostipo))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Estadosnotificacionwwds_3_tfestadostipo_sel)) && ! ( StringUtil.StrCmp(AV47Estadosnotificacionwwds_3_tfestadostipo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosTipo] = @AV47Estadosnotificacionwwds_3_tfestadostipo_sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV47Estadosnotificacionwwds_3_tfestadostipo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosTipo] = ''))");
         }
         if ( ! (0==AV48Estadosnotificacionwwds_4_tfestadosgenericosid) )
         {
            AddWhere(sWhereString, "([EstadosGenericosId] >= @AV48Estadosnotificacionwwds_4_tfestadosgenericosid)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to) )
         {
            AddWhere(sWhereString, "([EstadosGenericosId] <= @AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosGenericosNombre]) like UPPER(@lV50Estadosnotificacionwwds_6_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosGenericosNombre] = @AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosGenericosNombre] = ''))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionCliente] = @AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionProfesional] = @AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionOperador] = @AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [EstadosGenericosNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EstadosGenericosNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [EstadosTipo]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EstadosTipo] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [EstadosGenericosId]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EstadosGenericosId] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [EstadosNotificacionCliente]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EstadosNotificacionCliente] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [EstadosNotificacionProfesional]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EstadosNotificacionProfesional] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [EstadosNotificacionOperador]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EstadosNotificacionOperador] DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00C92(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00C92;
          prmP00C92 = new Object[] {
          new ParDef("@lV45Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV45Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV45Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV46Estadosnotificacionwwds_2_tfestadostipo",GXType.Char,3,0) ,
          new ParDef("@AV47Estadosnotificacionwwds_3_tfestadostipo_sel",GXType.NChar,3,0) ,
          new ParDef("@AV48Estadosnotificacionwwds_4_tfestadosgenericosid",GXType.Int32,5,0) ,
          new ParDef("@AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to",GXType.Int32,5,0) ,
          new ParDef("@lV50Estadosnotificacionwwds_6_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel",GXType.NChar,1,0) ,
          new ParDef("@AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel",GXType.NChar,1,0) ,
          new ParDef("@AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C92", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C92,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
       }
    }

 }

}
