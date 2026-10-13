using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class dividirtexto : GXProcedure
   {
      public dividirtexto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dividirtexto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref string aP0_Linea ,
                           ref string aP1_Separador ,
                           ref string aP2_MostrarResultado ,
                           ref string []  aP3_CDatosSepa )
      {
         this.AV12Linea = aP0_Linea;
         this.AV26Separador = aP1_Separador;
         this.AV31MostrarResultado = aP2_MostrarResultado;
         this.AV25CDatosSepa = aP3_CDatosSepa;
         initialize();
         ExecutePrivate();
         aP0_Linea=this.AV12Linea;
         aP1_Separador=this.AV26Separador;
         aP2_MostrarResultado=this.AV31MostrarResultado;
         aP3_CDatosSepa=this.AV25CDatosSepa;
      }

      public string[] executeUdp( ref string aP0_Linea ,
                                  ref string aP1_Separador ,
                                  ref string aP2_MostrarResultado )
      {
         execute(ref aP0_Linea, ref aP1_Separador, ref aP2_MostrarResultado, ref aP3_CDatosSepa);
         return AV25CDatosSepa ;
      }

      public void executeSubmit( ref string aP0_Linea ,
                                 ref string aP1_Separador ,
                                 ref string aP2_MostrarResultado ,
                                 ref string []  aP3_CDatosSepa )
      {
         this.AV12Linea = aP0_Linea;
         this.AV26Separador = aP1_Separador;
         this.AV31MostrarResultado = aP2_MostrarResultado;
         this.AV25CDatosSepa = aP3_CDatosSepa;
         SubmitImpl();
         aP0_Linea=this.AV12Linea;
         aP1_Separador=this.AV26Separador;
         aP2_MostrarResultado=this.AV31MostrarResultado;
         aP3_CDatosSepa=this.AV25CDatosSepa;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17CantCarac = (short)(StringUtil.Len( StringUtil.Trim( AV12Linea)));
         AV20PosiCaraActu = 0;
         AV19PosiSepa = 0;
         GX_I = 1;
         while ( GX_I <= 99 )
         {
            AV25CDatosSepa[GX_I-1] = "";
            GX_I = (int)(GX_I+1);
         }
         AV32i = 0;
         while ( AV20PosiCaraActu < AV17CantCarac )
         {
            AV20PosiCaraActu = (short)(AV20PosiCaraActu+1);
            AV18CaraActual = StringUtil.Substring( AV12Linea, AV20PosiCaraActu, 1);
            if ( ( StringUtil.StrCmp(AV18CaraActual, AV26Separador) == 0 ) || ( AV20PosiCaraActu == AV17CantCarac ) )
            {
               AV21PosiInicial = (short)(AV19PosiSepa+1);
               if ( StringUtil.StrCmp(AV18CaraActual, AV26Separador) == 0 )
               {
                  AV28Extraer = (short)(AV20PosiCaraActu-AV19PosiSepa-1);
               }
               else
               {
                  AV28Extraer = (short)(AV20PosiCaraActu-AV19PosiSepa);
               }
               AV19PosiSepa = AV20PosiCaraActu;
               AV27DatoIndividual = StringUtil.Substring( AV12Linea, AV21PosiInicial, AV28Extraer);
               AV32i = (short)(AV32i+1);
               AV25CDatosSepa[AV32i-1] = StringUtil.Trim( AV27DatoIndividual);
            }
         }
         AV29CantDatosTota = AV32i;
         AV30NumeDatoActu = 0;
         while ( AV30NumeDatoActu < AV29CantDatosTota )
         {
            AV30NumeDatoActu = (short)(AV30NumeDatoActu+1);
            AV27DatoIndividual = AV25CDatosSepa[AV30NumeDatoActu-1];
            if ( StringUtil.StrCmp(AV31MostrarResultado, context.GetMessage( "S", "")) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "Dato Individual (", "")+StringUtil.Trim( StringUtil.Str( (decimal)(AV30NumeDatoActu), 10, 0))+") - "+StringUtil.Trim( AV27DatoIndividual));
            }
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
         AV18CaraActual = "";
         AV27DatoIndividual = "";
         /* GeneXus formulas. */
      }

      private short AV17CantCarac ;
      private short AV20PosiCaraActu ;
      private short AV19PosiSepa ;
      private short AV32i ;
      private short AV21PosiInicial ;
      private short AV28Extraer ;
      private short AV29CantDatosTota ;
      private short AV30NumeDatoActu ;
      private int GX_I ;
      private string AV12Linea ;
      private string AV26Separador ;
      private string AV31MostrarResultado ;
      private string [] AV25CDatosSepa ;
      private string AV18CaraActual ;
      private string AV27DatoIndividual ;
      private string aP0_Linea ;
      private string aP1_Separador ;
      private string aP2_MostrarResultado ;
      private string[] aP3_CDatosSepa ;
   }

}
