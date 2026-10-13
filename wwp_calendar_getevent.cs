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
namespace GeneXus.Programs {
   public class wwp_calendar_getevent : GXProcedure
   {
      public wwp_calendar_getevent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_calendar_getevent( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Filtro ,
                           long aP1_ZonasId ,
                           long aP2_DepartamentoId ,
                           short aP3_RubrosId ,
                           long aP4_MedidasId ,
                           string aP5_LocalidadOrigen ,
                           string aP6_LocalidadDestino ,
                           out GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP7_Events )
      {
         this.AV17Filtro = aP0_Filtro;
         this.AV13ZonasId = aP1_ZonasId;
         this.AV14DepartamentoId = aP2_DepartamentoId;
         this.AV15RubrosId = aP3_RubrosId;
         this.AV16MedidasId = aP4_MedidasId;
         this.AV19LocalidadOrigen = aP5_LocalidadOrigen;
         this.AV18LocalidadDestino = aP6_LocalidadDestino;
         this.AV10Events = new GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item>( context, "Item", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP7_Events=this.AV10Events;
      }

      public GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> executeUdp( string aP0_Filtro ,
                                                                                                     long aP1_ZonasId ,
                                                                                                     long aP2_DepartamentoId ,
                                                                                                     short aP3_RubrosId ,
                                                                                                     long aP4_MedidasId ,
                                                                                                     string aP5_LocalidadOrigen ,
                                                                                                     string aP6_LocalidadDestino )
      {
         execute(aP0_Filtro, aP1_ZonasId, aP2_DepartamentoId, aP3_RubrosId, aP4_MedidasId, aP5_LocalidadOrigen, aP6_LocalidadDestino, out aP7_Events);
         return AV10Events ;
      }

      public void executeSubmit( string aP0_Filtro ,
                                 long aP1_ZonasId ,
                                 long aP2_DepartamentoId ,
                                 short aP3_RubrosId ,
                                 long aP4_MedidasId ,
                                 string aP5_LocalidadOrigen ,
                                 string aP6_LocalidadDestino ,
                                 out GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP7_Events )
      {
         this.AV17Filtro = aP0_Filtro;
         this.AV13ZonasId = aP1_ZonasId;
         this.AV14DepartamentoId = aP2_DepartamentoId;
         this.AV15RubrosId = aP3_RubrosId;
         this.AV16MedidasId = aP4_MedidasId;
         this.AV19LocalidadOrigen = aP5_LocalidadOrigen;
         this.AV18LocalidadDestino = aP6_LocalidadDestino;
         this.AV10Events = new GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item>( context, "Item", "AlmangoX") ;
         SubmitImpl();
         aP7_Events=this.AV10Events;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV17Filtro, context.GetMessage( "Servicios", "")) == 0 )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV13ZonasId ,
                                                 AV14DepartamentoId ,
                                                 A110ZonasID ,
                                                 A112DepartamentoId ,
                                                 A735MudanzaId ,
                                                 A184SolicitudesFechaInstalacion ,
                                                 Gx_date ,
                                                 A131EstadosSolId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.INT
                                                 }
            });
            /* Using cursor P00G62 */
            pr_default.execute(0, new Object[] {Gx_date, AV13ZonasId, AV14DepartamentoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A183SolicitudesHoraInstalacion = P00G62_A183SolicitudesHoraInstalacion[0];
               A127SolicitudesID = P00G62_A127SolicitudesID[0];
               A184SolicitudesFechaInstalacion = P00G62_A184SolicitudesFechaInstalacion[0];
               A131EstadosSolId = P00G62_A131EstadosSolId[0];
               A735MudanzaId = P00G62_A735MudanzaId[0];
               n735MudanzaId = P00G62_n735MudanzaId[0];
               A112DepartamentoId = P00G62_A112DepartamentoId[0];
               n112DepartamentoId = P00G62_n112DepartamentoId[0];
               A110ZonasID = P00G62_A110ZonasID[0];
               n110ZonasID = P00G62_n110ZonasID[0];
               if ( (0==AV15RubrosId) )
               {
                  AV8Calendar_Event = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
                  AV8Calendar_Event.gxTpr_Allday = true;
                  AV8Calendar_Event.gxTpr_Title = context.GetMessage( "Solicitud", "");
                  if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
                  {
                     AV8Calendar_Event.gxTpr_Title = context.GetMessage( " 08 a 12 - ", "")+AV8Calendar_Event.gxTpr_Title+" "+StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0);
                  }
                  if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
                  {
                     AV8Calendar_Event.gxTpr_Title = context.GetMessage( " 12 a 16 - ", "")+AV8Calendar_Event.gxTpr_Title+" "+StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0);
                  }
                  if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "3") == 0 )
                  {
                     AV8Calendar_Event.gxTpr_Title = context.GetMessage( " 16 a 20 - ", "")+AV8Calendar_Event.gxTpr_Title+" "+StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0);
                  }
                  GXt_dtime1 = DateTimeUtil.ResetTime( A184SolicitudesFechaInstalacion ) ;
                  AV8Calendar_Event.gxTpr_Start = GXt_dtime1;
                  GXt_dtime1 = DateTimeUtil.ResetTime( A184SolicitudesFechaInstalacion ) ;
                  AV8Calendar_Event.gxTpr_End = GXt_dtime1;
                  AV10Events.Add(AV8Calendar_Event, 0);
               }
               else
               {
                  pr_default.dynParam(1, new Object[]{ new Object[]{
                                                       AV15RubrosId ,
                                                       AV16MedidasId ,
                                                       A121RubrosId ,
                                                       A137MedidasID ,
                                                       A131EstadosSolId ,
                                                       A127SolicitudesID } ,
                                                       new int[]{
                                                       TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG
                                                       }
                  });
                  /* Using cursor P00G63 */
                  pr_default.execute(1, new Object[] {A127SolicitudesID, A131EstadosSolId, AV15RubrosId, AV16MedidasId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A137MedidasID = P00G63_A137MedidasID[0];
                     A121RubrosId = P00G63_A121RubrosId[0];
                     A134SolicitudesItemsID = P00G63_A134SolicitudesItemsID[0];
                     AV8Calendar_Event = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
                     AV8Calendar_Event.gxTpr_Allday = true;
                     AV8Calendar_Event.gxTpr_Title = context.GetMessage( "Solicitud", "");
                     if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
                     {
                        AV8Calendar_Event.gxTpr_Title = context.GetMessage( " 08 a 12 - ", "")+AV8Calendar_Event.gxTpr_Title+" "+StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0);
                     }
                     if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
                     {
                        AV8Calendar_Event.gxTpr_Title = context.GetMessage( " 12 a 16 - ", "")+AV8Calendar_Event.gxTpr_Title+" "+StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0);
                     }
                     if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "3") == 0 )
                     {
                        AV8Calendar_Event.gxTpr_Title = context.GetMessage( " 16 a 20 - ", "")+AV8Calendar_Event.gxTpr_Title+" "+StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0);
                     }
                     GXt_dtime1 = DateTimeUtil.ResetTime( A184SolicitudesFechaInstalacion ) ;
                     AV8Calendar_Event.gxTpr_Start = GXt_dtime1;
                     GXt_dtime1 = DateTimeUtil.ResetTime( A184SolicitudesFechaInstalacion ) ;
                     AV8Calendar_Event.gxTpr_End = GXt_dtime1;
                     AV10Events.Add(AV8Calendar_Event, 0);
                     pr_default.readNext(1);
                  }
                  pr_default.close(1);
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else if ( StringUtil.StrCmp(AV17Filtro, context.GetMessage( "Mudanzas", "")) == 0 )
         {
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV19LocalidadOrigen ,
                                                 AV18LocalidadDestino ,
                                                 A788MudanzaLocalidadOrigen ,
                                                 A789MudanzaLocalidadDestino ,
                                                 A735MudanzaId ,
                                                 A184SolicitudesFechaInstalacion ,
                                                 Gx_date ,
                                                 A131EstadosSolId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT
                                                 }
            });
            /* Using cursor P00G64 */
            pr_default.execute(2, new Object[] {Gx_date, AV19LocalidadOrigen, AV18LocalidadDestino});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A131EstadosSolId = P00G64_A131EstadosSolId[0];
               A789MudanzaLocalidadDestino = P00G64_A789MudanzaLocalidadDestino[0];
               A788MudanzaLocalidadOrigen = P00G64_A788MudanzaLocalidadOrigen[0];
               A184SolicitudesFechaInstalacion = P00G64_A184SolicitudesFechaInstalacion[0];
               A735MudanzaId = P00G64_A735MudanzaId[0];
               n735MudanzaId = P00G64_n735MudanzaId[0];
               A127SolicitudesID = P00G64_A127SolicitudesID[0];
               A183SolicitudesHoraInstalacion = P00G64_A183SolicitudesHoraInstalacion[0];
               A789MudanzaLocalidadDestino = P00G64_A789MudanzaLocalidadDestino[0];
               A788MudanzaLocalidadOrigen = P00G64_A788MudanzaLocalidadOrigen[0];
               AV8Calendar_Event = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
               AV8Calendar_Event.gxTpr_Allday = true;
               AV8Calendar_Event.gxTpr_Title = context.GetMessage( "Mudanza", "");
               if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
               {
                  AV8Calendar_Event.gxTpr_Title = context.GetMessage( " 08 a 12 - ", "")+AV8Calendar_Event.gxTpr_Title+" "+StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0);
               }
               if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
               {
                  AV8Calendar_Event.gxTpr_Title = context.GetMessage( " 12 a 16 - ", "")+AV8Calendar_Event.gxTpr_Title+" "+StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0);
               }
               if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "3") == 0 )
               {
                  AV8Calendar_Event.gxTpr_Title = context.GetMessage( " 16 a 20 - ", "")+AV8Calendar_Event.gxTpr_Title+" "+StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0);
               }
               GXt_dtime1 = DateTimeUtil.ResetTime( A184SolicitudesFechaInstalacion ) ;
               AV8Calendar_Event.gxTpr_Start = GXt_dtime1;
               GXt_dtime1 = DateTimeUtil.ResetTime( A184SolicitudesFechaInstalacion ) ;
               AV8Calendar_Event.gxTpr_End = GXt_dtime1;
               AV10Events.Add(AV8Calendar_Event, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         else
         {
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV13ZonasId ,
                                                 AV14DepartamentoId ,
                                                 A110ZonasID ,
                                                 A112DepartamentoId ,
                                                 A184SolicitudesFechaInstalacion ,
                                                 Gx_date ,
                                                 A131EstadosSolId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT
                                                 }
            });
            /* Using cursor P00G65 */
            pr_default.execute(3, new Object[] {Gx_date, AV13ZonasId, AV14DepartamentoId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A735MudanzaId = P00G65_A735MudanzaId[0];
               n735MudanzaId = P00G65_n735MudanzaId[0];
               A183SolicitudesHoraInstalacion = P00G65_A183SolicitudesHoraInstalacion[0];
               A127SolicitudesID = P00G65_A127SolicitudesID[0];
               A184SolicitudesFechaInstalacion = P00G65_A184SolicitudesFechaInstalacion[0];
               A131EstadosSolId = P00G65_A131EstadosSolId[0];
               A112DepartamentoId = P00G65_A112DepartamentoId[0];
               n112DepartamentoId = P00G65_n112DepartamentoId[0];
               A110ZonasID = P00G65_A110ZonasID[0];
               n110ZonasID = P00G65_n110ZonasID[0];
               if ( (0==AV15RubrosId) )
               {
                  AV8Calendar_Event = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
                  AV8Calendar_Event.gxTpr_Allday = true;
                  if ( (0==A735MudanzaId) )
                  {
                     AV8Calendar_Event.gxTpr_Title = context.GetMessage( "Solicitud", "");
                  }
                  else
                  {
                     AV8Calendar_Event.gxTpr_Title = context.GetMessage( "Mudanza", "");
                  }
                  if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
                  {
                     AV8Calendar_Event.gxTpr_Title = context.GetMessage( " 08 a 12 - ", "")+AV8Calendar_Event.gxTpr_Title+" "+StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0);
                  }
                  if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
                  {
                     AV8Calendar_Event.gxTpr_Title = context.GetMessage( " 12 a 16 - ", "")+AV8Calendar_Event.gxTpr_Title+" "+StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0);
                  }
                  if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "3") == 0 )
                  {
                     AV8Calendar_Event.gxTpr_Title = context.GetMessage( " 16 a 20 - ", "")+AV8Calendar_Event.gxTpr_Title+" "+StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0);
                  }
                  GXt_dtime1 = DateTimeUtil.ResetTime( A184SolicitudesFechaInstalacion ) ;
                  AV8Calendar_Event.gxTpr_Start = GXt_dtime1;
                  GXt_dtime1 = DateTimeUtil.ResetTime( A184SolicitudesFechaInstalacion ) ;
                  AV8Calendar_Event.gxTpr_End = GXt_dtime1;
                  AV10Events.Add(AV8Calendar_Event, 0);
               }
               else
               {
                  pr_default.dynParam(4, new Object[]{ new Object[]{
                                                       AV15RubrosId ,
                                                       AV16MedidasId ,
                                                       A121RubrosId ,
                                                       A137MedidasID ,
                                                       A131EstadosSolId ,
                                                       A127SolicitudesID } ,
                                                       new int[]{
                                                       TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG
                                                       }
                  });
                  /* Using cursor P00G66 */
                  pr_default.execute(4, new Object[] {A127SolicitudesID, A131EstadosSolId, AV15RubrosId, AV16MedidasId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A137MedidasID = P00G66_A137MedidasID[0];
                     A121RubrosId = P00G66_A121RubrosId[0];
                     A134SolicitudesItemsID = P00G66_A134SolicitudesItemsID[0];
                     AV8Calendar_Event = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
                     AV8Calendar_Event.gxTpr_Allday = true;
                     if ( (0==A735MudanzaId) )
                     {
                        AV8Calendar_Event.gxTpr_Title = context.GetMessage( "Solicitud", "");
                     }
                     else
                     {
                        AV8Calendar_Event.gxTpr_Title = context.GetMessage( "Mudanza", "");
                     }
                     if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
                     {
                        AV8Calendar_Event.gxTpr_Title = context.GetMessage( " 08 a 12 - ", "")+AV8Calendar_Event.gxTpr_Title+" "+StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0);
                     }
                     if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
                     {
                        AV8Calendar_Event.gxTpr_Title = context.GetMessage( " 12 a 16 - ", "")+AV8Calendar_Event.gxTpr_Title+" "+StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0);
                     }
                     if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "3") == 0 )
                     {
                        AV8Calendar_Event.gxTpr_Title = context.GetMessage( " 16 a 20 - ", "")+AV8Calendar_Event.gxTpr_Title+" "+StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0);
                     }
                     GXt_dtime1 = DateTimeUtil.ResetTime( A184SolicitudesFechaInstalacion ) ;
                     AV8Calendar_Event.gxTpr_Start = GXt_dtime1;
                     GXt_dtime1 = DateTimeUtil.ResetTime( A184SolicitudesFechaInstalacion ) ;
                     AV8Calendar_Event.gxTpr_End = GXt_dtime1;
                     AV10Events.Add(AV8Calendar_Event, 0);
                     pr_default.readNext(4);
                  }
                  pr_default.close(4);
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
         }
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
         AV10Events = new GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item>( context, "Item", "AlmangoX");
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         P00G62_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00G62_A127SolicitudesID = new long[1] ;
         P00G62_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00G62_A131EstadosSolId = new int[1] ;
         P00G62_A735MudanzaId = new long[1] ;
         P00G62_n735MudanzaId = new bool[] {false} ;
         P00G62_A112DepartamentoId = new long[1] ;
         P00G62_n112DepartamentoId = new bool[] {false} ;
         P00G62_A110ZonasID = new long[1] ;
         P00G62_n110ZonasID = new bool[] {false} ;
         A183SolicitudesHoraInstalacion = "";
         AV8Calendar_Event = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
         P00G63_A127SolicitudesID = new long[1] ;
         P00G63_A137MedidasID = new long[1] ;
         P00G63_A121RubrosId = new short[1] ;
         P00G63_A134SolicitudesItemsID = new short[1] ;
         A788MudanzaLocalidadOrigen = "";
         A789MudanzaLocalidadDestino = "";
         P00G64_A131EstadosSolId = new int[1] ;
         P00G64_A789MudanzaLocalidadDestino = new string[] {""} ;
         P00G64_A788MudanzaLocalidadOrigen = new string[] {""} ;
         P00G64_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00G64_A735MudanzaId = new long[1] ;
         P00G64_n735MudanzaId = new bool[] {false} ;
         P00G64_A127SolicitudesID = new long[1] ;
         P00G64_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00G65_A735MudanzaId = new long[1] ;
         P00G65_n735MudanzaId = new bool[] {false} ;
         P00G65_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00G65_A127SolicitudesID = new long[1] ;
         P00G65_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00G65_A131EstadosSolId = new int[1] ;
         P00G65_A112DepartamentoId = new long[1] ;
         P00G65_n112DepartamentoId = new bool[] {false} ;
         P00G65_A110ZonasID = new long[1] ;
         P00G65_n110ZonasID = new bool[] {false} ;
         P00G66_A127SolicitudesID = new long[1] ;
         P00G66_A137MedidasID = new long[1] ;
         P00G66_A121RubrosId = new short[1] ;
         P00G66_A134SolicitudesItemsID = new short[1] ;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwp_calendar_getevent__default(),
            new Object[][] {
                new Object[] {
               P00G62_A183SolicitudesHoraInstalacion, P00G62_A127SolicitudesID, P00G62_A184SolicitudesFechaInstalacion, P00G62_A131EstadosSolId, P00G62_A735MudanzaId, P00G62_n735MudanzaId, P00G62_A112DepartamentoId, P00G62_n112DepartamentoId, P00G62_A110ZonasID, P00G62_n110ZonasID
               }
               , new Object[] {
               P00G63_A127SolicitudesID, P00G63_A137MedidasID, P00G63_A121RubrosId, P00G63_A134SolicitudesItemsID
               }
               , new Object[] {
               P00G64_A131EstadosSolId, P00G64_A789MudanzaLocalidadDestino, P00G64_A788MudanzaLocalidadOrigen, P00G64_A184SolicitudesFechaInstalacion, P00G64_A735MudanzaId, P00G64_n735MudanzaId, P00G64_A127SolicitudesID, P00G64_A183SolicitudesHoraInstalacion
               }
               , new Object[] {
               P00G65_A735MudanzaId, P00G65_n735MudanzaId, P00G65_A183SolicitudesHoraInstalacion, P00G65_A127SolicitudesID, P00G65_A184SolicitudesFechaInstalacion, P00G65_A131EstadosSolId, P00G65_A112DepartamentoId, P00G65_n112DepartamentoId, P00G65_A110ZonasID, P00G65_n110ZonasID
               }
               , new Object[] {
               P00G66_A127SolicitudesID, P00G66_A137MedidasID, P00G66_A121RubrosId, P00G66_A134SolicitudesItemsID
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV15RubrosId ;
      private short A121RubrosId ;
      private short A134SolicitudesItemsID ;
      private int A131EstadosSolId ;
      private long AV13ZonasId ;
      private long AV14DepartamentoId ;
      private long AV16MedidasId ;
      private long A110ZonasID ;
      private long A112DepartamentoId ;
      private long A735MudanzaId ;
      private long A127SolicitudesID ;
      private long A137MedidasID ;
      private string A183SolicitudesHoraInstalacion ;
      private DateTime GXt_dtime1 ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime Gx_date ;
      private bool n735MudanzaId ;
      private bool n112DepartamentoId ;
      private bool n110ZonasID ;
      private string AV17Filtro ;
      private string AV19LocalidadOrigen ;
      private string AV18LocalidadDestino ;
      private string A788MudanzaLocalidadOrigen ;
      private string A789MudanzaLocalidadDestino ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> AV10Events ;
      private IDataStoreProvider pr_default ;
      private string[] P00G62_A183SolicitudesHoraInstalacion ;
      private long[] P00G62_A127SolicitudesID ;
      private DateTime[] P00G62_A184SolicitudesFechaInstalacion ;
      private int[] P00G62_A131EstadosSolId ;
      private long[] P00G62_A735MudanzaId ;
      private bool[] P00G62_n735MudanzaId ;
      private long[] P00G62_A112DepartamentoId ;
      private bool[] P00G62_n112DepartamentoId ;
      private long[] P00G62_A110ZonasID ;
      private bool[] P00G62_n110ZonasID ;
      private GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item AV8Calendar_Event ;
      private long[] P00G63_A127SolicitudesID ;
      private long[] P00G63_A137MedidasID ;
      private short[] P00G63_A121RubrosId ;
      private short[] P00G63_A134SolicitudesItemsID ;
      private int[] P00G64_A131EstadosSolId ;
      private string[] P00G64_A789MudanzaLocalidadDestino ;
      private string[] P00G64_A788MudanzaLocalidadOrigen ;
      private DateTime[] P00G64_A184SolicitudesFechaInstalacion ;
      private long[] P00G64_A735MudanzaId ;
      private bool[] P00G64_n735MudanzaId ;
      private long[] P00G64_A127SolicitudesID ;
      private string[] P00G64_A183SolicitudesHoraInstalacion ;
      private long[] P00G65_A735MudanzaId ;
      private bool[] P00G65_n735MudanzaId ;
      private string[] P00G65_A183SolicitudesHoraInstalacion ;
      private long[] P00G65_A127SolicitudesID ;
      private DateTime[] P00G65_A184SolicitudesFechaInstalacion ;
      private int[] P00G65_A131EstadosSolId ;
      private long[] P00G65_A112DepartamentoId ;
      private bool[] P00G65_n112DepartamentoId ;
      private long[] P00G65_A110ZonasID ;
      private bool[] P00G65_n110ZonasID ;
      private long[] P00G66_A127SolicitudesID ;
      private long[] P00G66_A137MedidasID ;
      private short[] P00G66_A121RubrosId ;
      private short[] P00G66_A134SolicitudesItemsID ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP7_Events ;
   }

   public class wwp_calendar_getevent__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00G62( IGxContext context ,
                                             long AV13ZonasId ,
                                             long AV14DepartamentoId ,
                                             long A110ZonasID ,
                                             long A112DepartamentoId ,
                                             long A735MudanzaId ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime Gx_date ,
                                             int A131EstadosSolId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[3];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [SolicitudesHoraInstalacion], [SolicitudesID], [SolicitudesFechaInstalacion], [EstadosSolId], [MudanzaId], [DepartamentoId], [ZonasID] FROM [Solicitudes]";
         AddWhere(sWhereString, "([MudanzaId] IS NULL)");
         AddWhere(sWhereString, "([SolicitudesFechaInstalacion] >= DATEADD( dd,-30, @Gx_date))");
         AddWhere(sWhereString, "(Not [EstadosSolId] = 3)");
         if ( ! (0==AV13ZonasId) )
         {
            AddWhere(sWhereString, "([ZonasID] = @AV13ZonasId)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV14DepartamentoId) )
         {
            AddWhere(sWhereString, "([DepartamentoId] = @AV14DepartamentoId)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SolicitudesFechaInstalacion] DESC, [SolicitudesHoraInstalacion]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00G63( IGxContext context ,
                                             short AV15RubrosId ,
                                             long AV16MedidasId ,
                                             short A121RubrosId ,
                                             long A137MedidasID ,
                                             int A131EstadosSolId ,
                                             long A127SolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [SolicitudesID], [MedidasID], [RubrosId], [SolicitudesItemsID] FROM [SolicitudesItems]";
         AddWhere(sWhereString, "([SolicitudesID] = @SolicitudesID)");
         AddWhere(sWhereString, "(Not @EstadosSolId = 3)");
         if ( ! (0==AV15RubrosId) )
         {
            AddWhere(sWhereString, "([RubrosId] = @AV15RubrosId)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV16MedidasId) )
         {
            AddWhere(sWhereString, "([MedidasID] = @AV16MedidasId)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SolicitudesID]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00G64( IGxContext context ,
                                             string AV19LocalidadOrigen ,
                                             string AV18LocalidadDestino ,
                                             string A788MudanzaLocalidadOrigen ,
                                             string A789MudanzaLocalidadDestino ,
                                             long A735MudanzaId ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime Gx_date ,
                                             int A131EstadosSolId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[3];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosSolId], T2.[MudanzaLocalidadDestino], T2.[MudanzaLocalidadOrigen], T1.[SolicitudesFechaInstalacion], T1.[MudanzaId], T1.[SolicitudesID], T1.[SolicitudesHoraInstalacion] FROM ([Solicitudes] T1 LEFT JOIN [Mudanza] T2 ON T2.[MudanzaId] = T1.[MudanzaId])";
         AddWhere(sWhereString, "(Not T1.[MudanzaId] IS NULL)");
         AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= DATEADD( dd,-30, @Gx_date))");
         AddWhere(sWhereString, "(Not T1.[EstadosSolId] = 3)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19LocalidadOrigen)) )
         {
            AddWhere(sWhereString, "(T2.[MudanzaLocalidadOrigen] = RTRIM(LTRIM(@AV19LocalidadOrigen)))");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18LocalidadDestino)) )
         {
            AddWhere(sWhereString, "(T2.[MudanzaLocalidadDestino] = RTRIM(LTRIM(@AV18LocalidadDestino)))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SolicitudesFechaInstalacion] DESC, T1.[SolicitudesHoraInstalacion]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00G65( IGxContext context ,
                                             long AV13ZonasId ,
                                             long AV14DepartamentoId ,
                                             long A110ZonasID ,
                                             long A112DepartamentoId ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime Gx_date ,
                                             int A131EstadosSolId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[3];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT [MudanzaId], [SolicitudesHoraInstalacion], [SolicitudesID], [SolicitudesFechaInstalacion], [EstadosSolId], [DepartamentoId], [ZonasID] FROM [Solicitudes]";
         AddWhere(sWhereString, "([SolicitudesFechaInstalacion] >= DATEADD( dd,-30, @Gx_date))");
         AddWhere(sWhereString, "(Not [EstadosSolId] = 3)");
         if ( ! (0==AV13ZonasId) )
         {
            AddWhere(sWhereString, "([ZonasID] = @AV13ZonasId)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! (0==AV14DepartamentoId) )
         {
            AddWhere(sWhereString, "([DepartamentoId] = @AV14DepartamentoId)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SolicitudesFechaInstalacion] DESC, [SolicitudesHoraInstalacion]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P00G66( IGxContext context ,
                                             short AV15RubrosId ,
                                             long AV16MedidasId ,
                                             short A121RubrosId ,
                                             long A137MedidasID ,
                                             int A131EstadosSolId ,
                                             long A127SolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[4];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT [SolicitudesID], [MedidasID], [RubrosId], [SolicitudesItemsID] FROM [SolicitudesItems]";
         AddWhere(sWhereString, "([SolicitudesID] = @SolicitudesID)");
         AddWhere(sWhereString, "(Not @EstadosSolId = 3)");
         if ( ! (0==AV15RubrosId) )
         {
            AddWhere(sWhereString, "([RubrosId] = @AV15RubrosId)");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( ! (0==AV16MedidasId) )
         {
            AddWhere(sWhereString, "([MedidasID] = @AV16MedidasId)");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SolicitudesID]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00G62(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (int)dynConstraints[7] );
               case 1 :
                     return conditional_P00G63(context, (short)dynConstraints[0] , (long)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (int)dynConstraints[4] , (long)dynConstraints[5] );
               case 2 :
                     return conditional_P00G64(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (long)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (int)dynConstraints[7] );
               case 3 :
                     return conditional_P00G65(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] );
               case 4 :
                     return conditional_P00G66(context, (short)dynConstraints[0] , (long)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (int)dynConstraints[4] , (long)dynConstraints[5] );
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
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00G62;
          prmP00G62 = new Object[] {
          new ParDef("@Gx_date",GXType.Date,8,0) ,
          new ParDef("@AV13ZonasId",GXType.Decimal,18,0) ,
          new ParDef("@AV14DepartamentoId",GXType.Decimal,18,0)
          };
          Object[] prmP00G63;
          prmP00G63 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@EstadosSolId",GXType.Int32,5,0) ,
          new ParDef("@AV15RubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV16MedidasId",GXType.Decimal,18,0)
          };
          Object[] prmP00G64;
          prmP00G64 = new Object[] {
          new ParDef("@Gx_date",GXType.Date,8,0) ,
          new ParDef("@AV19LocalidadOrigen",GXType.NVarChar,100,0) ,
          new ParDef("@AV18LocalidadDestino",GXType.NVarChar,100,0)
          };
          Object[] prmP00G65;
          prmP00G65 = new Object[] {
          new ParDef("@Gx_date",GXType.Date,8,0) ,
          new ParDef("@AV13ZonasId",GXType.Decimal,18,0) ,
          new ParDef("@AV14DepartamentoId",GXType.Decimal,18,0)
          };
          Object[] prmP00G66;
          prmP00G66 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@EstadosSolId",GXType.Int32,5,0) ,
          new ParDef("@AV15RubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV16MedidasId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00G62", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G62,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00G63", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G63,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00G64", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G64,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00G65", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G65,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00G66", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G66,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 1);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 1);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
