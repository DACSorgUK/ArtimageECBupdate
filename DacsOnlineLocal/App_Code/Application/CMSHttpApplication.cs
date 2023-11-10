using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CMS.CMSHelper;
using Microsoft.Practices.Unity;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Model.Utilities;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Service.Service.Interfaces;
using Microsoft.Practices.ServiceLocation;
using WebFormsMvp.Binder;
using WebFormsMvp.Unity;
using DacsOnline.Service.Service;
using DacsOnline.Model.Manager;
using DacsOnline.Model.RepostioriesInterfaces;
using DacsOnline.Repository.Repositories;
using DacsOnline.Repository;
using DacsOnline.Model.Adadpters;
using System.Configuration;

public class CMSHttpApplication : HttpApplication
{
    #region "Variables"

    /// <summary>
    /// True if handlers were already initialized
    /// </summary>
    private static bool mHandlersInitialized = false;

    /// <summary>
    /// Lock object
    /// </summary>
    private static object mLock = new object();

    #endregion

    #region //Private Variables
    /// <summary>
    /// Unity Container
    /// </summary>
    private readonly IUnityContainer _container;
    #endregion




    #region "Application events"

    /// <summary>
    /// Application start event handler.
    /// </summary>
    public void Application_Start(object sender, EventArgs e)
    {
        // Azure Application start init
        AzureInit.Current.ApplicationStartInit();

        CMSAppBase.CMSApplicationStart();

        _container.RegisterType<IEventLogService, NullLogger>(new ContainerControlledLifetimeManager());


        _container.RegisterType<IExchangeRepository, ExchangeRepository>(new ContainerControlledLifetimeManager());
        _container.RegisterType<IExchangeManager, ExchangeManager>(new ContainerControlledLifetimeManager());
        _container.RegisterType<ICalculatorManager, CalculatorManager>(new ContainerControlledLifetimeManager());
        _container.RegisterType<ICalculatorService, CalculatorService>(new ContainerControlledLifetimeManager());

        _container.RegisterType<IArtMarketSalesFormRepository, ArtMarketSalesFormRepository>(new ContainerControlledLifetimeManager());
        _container.RegisterType<IArtMarketSalesFormServiceManager, ArtMarketSalesFormServiceManager>(new ContainerControlledLifetimeManager());
        _container.RegisterType<IArtMarketSalesFormService, ArtMarketSalesFormService>(new ContainerControlledLifetimeManager());

        _container.RegisterType<ICopyRightLicencingFormRepository, CopyRightLicencingFormRepository>(new ContainerControlledLifetimeManager());
        _container.RegisterType<ICopyRightLicencingFormServiceManager, CopyRightLicencingFormServiceManager>(new ContainerControlledLifetimeManager());
        _container.RegisterType<ICopyRightLicencingFormService, CopyRightLicencingFormService>(new ContainerControlledLifetimeManager());

        string CacheExpiryMins = ConfigurationManager.AppSettings["CacaheExpiriy"].ToString();
        _container.RegisterType<ICache, WebCacheAdapter>(new ContainerControlledLifetimeManager());
        _container.RegisterType<IARRArtistSearchManager, ARRArtistSearchManager>(new ContainerControlledLifetimeManager());
        _container.RegisterType<IARRArtistSearchService, ARRArtistSearchService>(new ContainerControlledLifetimeManager());
        _container.RegisterType<IARRArtistSearchRepository, ArtistSearchRepository>(new ContainerControlledLifetimeManager());
        _container.Configure<InjectedMembers>()
                             .ConfigureInjectionFor<ArtistSearchRepository>(
                                 new InjectionConstructor(new ResolvedParameter<IEventLogService>(),
                                                           new ResolvedParameter<ICache>(),
                                                           Convert.ToInt32(CacheExpiryMins)));

        _container.RegisterType<IArtistDetailsManager, ArtistDetailsManager>(new ContainerControlledLifetimeManager());
        _container.RegisterType<IArtistDetailsService, ArtistDetailsService>(new ContainerControlledLifetimeManager());

        _container.RegisterType<ICLArtistSearchService, CLArtistSearchService>(new ContainerControlledLifetimeManager());
        _container.RegisterType<ICLArtistSearchManager, CLArtistSearchManager>(new ContainerControlledLifetimeManager());


        _container.RegisterType<IAllArtistSearchService, AllArtistSearchService>(new ContainerControlledLifetimeManager());
        _container.RegisterType<IAllArtistDetailsManager, AllArtistSearchManager>(new ContainerControlledLifetimeManager());

        _container.RegisterType<ICountrySelectorService, CountrySelectorService>(new ContainerControlledLifetimeManager());

        _container.RegisterType<IDocumentRepository, DocumentListRepository>(new ContainerControlledLifetimeManager());
        _container.RegisterType<IDocumentationListManager, DocumentListManager>(new ContainerControlledLifetimeManager());
        _container.RegisterType<IDocumentListService, DocumentListService>(new ContainerControlledLifetimeManager());

        UnityServiceLocator locator = new UnityServiceLocator(_container);
        ServiceLocator.SetLocatorProvider(() => locator);
        PresenterBinder.Factory = new UnityPresenterFactory(_container);

        //System.Net.ServicePointManager.ServerCertificateValidationCallback = 
        //       ((sender, certificate, chain, sslPolicyErrors) => true);
    }


    /// <summary>
    /// Application error event handler.
    /// </summary>
    public void Application_Error(object sender, EventArgs e)
    {
        CMSAppBase.CMSApplicationError(sender, e);
    }


    /// <summary>
    /// Application end event handler.
    /// </summary>
    public void Application_End(object sender, EventArgs e)
    {
        CMSAppBase.CMSApplicationEnd(sender, e);
    }

    #endregion


    #region "Session events"

    /// <summary>
    /// Session start event handler.
    /// </summary>
    public void Session_Start(object sender, EventArgs e)
    {
        CMSAppBase.CMSSessionStart(sender, e);
    }


    /// <summary>
    /// Session end event handler.
    /// </summary>
    public void Session_End(object sender, EventArgs e)
    {
        CMSAppBase.CMSSessionEnd(sender, e);
    }

    #endregion


    #region "Request events"

    /// <summary>
    /// Constructor
    /// </summary>
    public CMSHttpApplication()
    {
        InitHandlers();
        _container = new UnityContainer();
    }


    /// <summary>
    /// Initializes the handlers
    /// </summary>
    private void InitHandlers()
    {
        if (mHandlersInitialized)
        {
            return;
        }

        lock (mLock)
        {
            if (mHandlersInitialized)
            {
                return;
            }

            // Map the request handlers
            CMSApplicationModule.BeginRequest += CMSAppBase.CMSBeginRequest;
            CMSApplicationModule.AuthenticateRequest += CMSAppBase.CMSAuthenticateRequest;
            CMSApplicationModule.AuthorizeRequest += CMSAppBase.CMSAuthorizeRequest;
            CMSApplicationModule.MapRequestHandler += CMSAppBase.CMSMapRequestHandler;
            CMSApplicationModule.AcquireRequestState += CMSAppBase.CMSAcquireRequestState;
            CMSApplicationModule.EndRequest += CMSAppBase.CMSEndRequest;

            mHandlersInitialized = true;
        }
    }

    #endregion


    #region "Overriden methods"

    /// <summary>
    /// Custom cache parameters processing.
    /// </summary>
    public override string GetVaryByCustomString(HttpContext context, string custom)
    {
        return CMSAppBase.CMSGetVaryByCustomString(context, custom);
    }

    #endregion
}

