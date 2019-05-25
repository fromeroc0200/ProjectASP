using BikeStore.Data.Model;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<IEnumerable<TEntity>> where TEntity : class
    {
        protected ElasticClient client;
        protected static ConnectionSettings settings;

        public static Uri node;

       

        //Nest Functions
        //public static ElasticClient client;

        public BaseRepository(Uri elastiSearchServerUrl = null)
        {
            if(elastiSearchServerUrl != null)
            {
                settings = new ConnectionSettings(elastiSearchServerUrl);
                //----- Authentication settings -------

                //settings.ClientCertificate(GetCertificateFromStore());
                //settings.BasicAuthentication(Username, Password);
                //settings.DefaultIndex("users");
                settings.ThrowExceptions();
                settings.PrettyJson();
                settings.DisableDirectStreaming();
                settings.DefaultFieldNameInferrer(p => p);
            }
            
            this.client = elastiSearchServerUrl != null ? new ElasticClient(settings) : new ElasticClient();
            
        }

        public bool IndexData<T>(T data, string indexName =null) where T : class, new()
        {
            if (client == null)
            {
                throw new ArgumentNullException("data");
            }
            var result = this.client.Index<T>(data,
              c => c.Index(indexName));
            return result.IsValid;
        }

        public ProcessResult<IEnumerable<TEntity>> Get()
        {
           
            ProcessResult<IEnumerable<TEntity>> result = new ProcessResult<IEnumerable<TEntity>>();

            result.Content = client.Search<TEntity>(c => c.Index("users")).Documents.ToList();
            
            
            return result;
        }

        

    }
}