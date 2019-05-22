using BikeStore.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using Nest;
using Elasticsearch.Net;

namespace BikeStore.Web.Modules.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static Uri node;

        //Nest Functions
        public static ConnectionSettings settings;
        public static ElasticClient client;
        
        [WebMethod]
        public static ProcessResult<List<Users>> LoginUser(string user, string password)
        {
            ProcessResult<List<Users>> result = new ProcessResult<List<Users>>();

            
            node = new Uri("http://localhost:9200");
            settings = new ConnectionSettings(node);
            
            settings.DefaultIndex("users");

            //settings.ClientCertificate(GetCertificateFromStore());
            //settings.BasicAuthentication(Username, Password);
            settings.ThrowExceptions();
            settings.PrettyJson();
            settings.DisableDirectStreaming();
            settings.DefaultFieldNameInferrer(p => p);

            client = new ElasticClient(settings);
            
            var cli = new ElasticLowLevelClient();
            if (client.IndexExists("users").Exists)
            {
                var res = client.Search<Users>(s=>s.Source(true));


                result.Content = res.Documents.ToList(); //res.Hits.Select(c => c.Source).ToList<Users>();
                var response = client.Search<dynamic>(c => c.Index("users"));
            }
            result.HasError = false;
            return result;
        }
    }
}