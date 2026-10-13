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
   public class oproveedorlistaasig : GXProcedure
   {
      public oproveedorlistaasig( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oproveedorlistaasig( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_ProveedorID ,
                           out bool aP1_HacerLoadTF )
      {
         this.AV13ProveedorID = aP0_ProveedorID;
         this.AV14HacerLoadTF = false ;
         initialize();
         ExecutePrivate();
         aP1_HacerLoadTF=this.AV14HacerLoadTF;
      }

      public bool executeUdp( long aP0_ProveedorID )
      {
         execute(aP0_ProveedorID, out aP1_HacerLoadTF);
         return AV14HacerLoadTF ;
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 out bool aP1_HacerLoadTF )
      {
         this.AV13ProveedorID = aP0_ProveedorID;
         this.AV14HacerLoadTF = false ;
         SubmitImpl();
         aP1_HacerLoadTF=this.AV14HacerLoadTF;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV16WWPContext) ;
         AV9HacerLoad = 0;
         AV11Roles = AV16WWPContext.gxTpr_Roles;
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV11Roles.gxTpr_Roles.Count )
         {
            AV12RolesItem = ((SdtSDTRoles_Id)AV11Roles.gxTpr_Roles.Item(AV19GXV1));
            AV10SecRoleName = AV12RolesItem.gxTpr_Secrolename;
            AV19GXV1 = (int)(AV19GXV1+1);
         }
         if ( ( ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV10SecRoleName)), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) ) || ( ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV10SecRoleName)), context.GetMessage( "ADM GENERAL", "")) == 0 ) ) || ( ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV10SecRoleName)), context.GetMessage( "GERENTE GENERAL", "")) == 0 ) ) )
         {
            AV9HacerLoad = 1;
            AV8proveedorProperty.Set(StringUtil.Str( (decimal)(AV13ProveedorID), 18, 0), StringUtil.Str( (decimal)(AV9HacerLoad), 5, 0));
         }
         else
         {
            new olisagruserprovid(context ).execute(  AV16WWPContext.gxTpr_Userid,  AV13ProveedorID,  "ADM", out  AV18Existe, out  AV15AgrProveedorEstado) ;
            if ( StringUtil.StrCmp(AV15AgrProveedorEstado, "VIN") == 0 )
            {
               AV9HacerLoad = 1;
            }
            else
            {
               AV9HacerLoad = 2;
            }
         }
         AV14HacerLoadTF = ((AV9HacerLoad==1) ? true : false);
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
         AV16WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11Roles = new SdtSDTRoles(context);
         AV12RolesItem = new SdtSDTRoles_Id(context);
         AV10SecRoleName = "";
         AV8proveedorProperty = new GXProperties();
         AV15AgrProveedorEstado = "";
         /* GeneXus formulas. */
      }

      private int AV9HacerLoad ;
      private int AV19GXV1 ;
      private long AV13ProveedorID ;
      private string AV15AgrProveedorEstado ;
      private bool AV14HacerLoadTF ;
      private bool AV18Existe ;
      private string AV10SecRoleName ;
      private GXProperties AV8proveedorProperty ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV16WWPContext ;
      private SdtSDTRoles AV11Roles ;
      private SdtSDTRoles_Id AV12RolesItem ;
      private bool aP1_HacerLoadTF ;
   }

}
