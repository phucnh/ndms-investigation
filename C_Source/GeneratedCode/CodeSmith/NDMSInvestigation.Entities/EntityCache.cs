﻿using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Caching.BackingStoreImplementations;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Caching.Cryptography.Configuration;

namespace NDMSInvestigation.Entities
{
	/// <summary>
    /// Entity Cache provides a caching mechanism for entities on a by entity level.
    /// </summary>
    public static class EntityCache
    {
        private static volatile CacheManagerFactory cacheManagerFactory;
        private static volatile CacheManager cacheManager;
        private static string cacheManagerKey = "NDMSInvestigation.Entities.EntityCache";
		private static object syncObject = new object(); 
		private static string configurationFile;
        
		/// <summary>
        /// Gets the cache manager.
        /// </summary>
        /// <value>The cache manager.</value>		
        public static CacheManager CacheManager
        {
            get{
                if (cacheManager == null)
                    cacheManager = (CacheManager) CacheManagerFactory.Create(cacheManagerKey);

                return cacheManager;
             }
        }
        
		/// <summary>
        /// Generates the configuration.
        /// </summary>
        /// <returns>DictionaryConfigurationSource to Configure the cache</returns>
        internal static DictionaryConfigurationSource GenerateConfiguration()
        {
            DictionaryConfigurationSource sections = new DictionaryConfigurationSource();
            sections.Add(CacheManagerSettings.SectionName, GenerateDefaultCacheManagerSettings());
            return sections;
        }

		#region GenerateDefaultCacheManagerSettings
        /// <summary>
        /// Generates the default cache manager settings.
        /// </summary>
        /// <returns></returns>
		private static CacheManagerSettings GenerateDefaultCacheManagerSettings()
        {
            CacheManagerSettings settings = new CacheManagerSettings();
            settings.BackingStores.Add(new CacheStorageData("inMemoryWithEncryptor", typeof(NullBackingStore), "dpapiEncryptor"));
            settings.EncryptionProviders.Add(new SymmetricStorageEncryptionProviderData("dpapiEncryptor", "dpapi1"));
            settings.CacheManagers.Add(
                new CacheManagerData(cacheManagerKey,
                        10000, //Polling time
                        1000, //Items to store
                        100, //Items to remove 
                        "inMemoryWithEncryptor"));
            return settings;
        }
		#endregion 
	    
		#region ConfigurationFile
		/// <summary>
        /// Gets or sets the configuration file.
        /// </summary>
        /// <value>The configuration file.</value>
        public static string ConfigurationFile
		{
			get
			{ 	
			    return configurationFile; 
			}
			set
			{
			    lock(syncObject)    
			        configurationFile = value;
			}
		}
		#endregion 
		
        #region CacheManagerFactory
		/// <summary>
        /// Gets or sets the cache manager factory.
        /// </summary>
        /// <value>The cache manager factory.</value>
        public static CacheManagerFactory CacheManagerFactory
        {
            get {
            	    if (cacheManagerFactory == null)
					{
						lock(syncObject)
						{
							IConfigurationSource configurationSource = null;
							//From specified config
							if (ConfigurationFile != null && System.IO.File.Exists(ConfigurationFile))
							{
								 configurationSource = new FileConfigurationSource(ConfigurationFile);
                                 cacheManagerFactory = new CacheManagerFactory(configurationSource);
							}
							else
                            {
                                try
                                {
                                    //Try reading from default Configuration Source web/app config
                                    IConfigurationSource userConfiguration = new SystemConfigurationSource();
                                    cacheManagerFactory = new CacheManagerFactory(userConfiguration);
									
									//Test if CacheManagerKey is Configured
                                    cacheManagerFactory.Create(CacheManagerKey);
                                }
                                catch(Exception)
                                {
                                    // Currently not configured, generate configuration
                                    configurationSource = GenerateConfiguration();
                                    cacheManagerFactory = new CacheManagerFactory(configurationSource);
                                }
							}
						}
					}
                    return cacheManagerFactory; 
                }
            set { cacheManagerFactory = value; }
        }
		#endregion 
		
		#region CacheManagerKey
		/// <summary>
	    /// Assigns the Default CacheManagerKey To Be Used.
	    /// </summary>
	    public static string CacheManagerKey
	    {
	        get
	        {
	            return cacheManagerKey;
	        }
	        set
	        {
	            lock(syncObject)
                {
	                cacheManagerKey = value;
                }
	        }
	    }
		#endregion 
		
        #region RemoveItem
        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="id">The id.</param>
		public static void RemoveItem(string id)
        {
            CacheManager.Remove(id);
        }
		#endregion 
	
        #region Flush Objects
		/// <summary>
        /// Flushes the cache manager.
        /// </summary>
        public static void FlushCacheManager()
        {
            cacheManager = null;
        }

        /// <summary>
        /// Flushes the cache.
        /// </summary>
        public static void FlushCache()
        {
            CacheManager.Flush();
        }
        #endregion 
	
		#region AddCache
		/// <summary>
        /// Adds the cache.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="entity">The entity.</param>
        public static void AddCache(string id, object entity)
        {
            CacheManager.Add(id, entity);
        }
		#endregion 
	
		#region GetItem
        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns> 
		public static T GetItem<T>(string id) where T : class
        {
            return CacheManager.GetData(id) as T;    
        }
        #endregion
    
	}
}
