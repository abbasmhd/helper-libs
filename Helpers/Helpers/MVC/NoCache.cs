using System.IO;
using System.Web.Caching;
using System.Web.Hosting;

namespace System.Web.Mvc {

    public static class NoCache {

        /**
         * Add the url rewrite to <system.webServer>  
         *
         *   <rewrite>
         *       <rules>
         *       <rule name="fingerprint">
         *           <match url="([\S]+)(/v-[0-9]+/)([\S]+)" />
         *           <action type="Rewrite" url="{R:1}/{R:3}" />
         *       </rule>
         *       </rules>
         *   </rewrite> 
         *
         *   Input
         *   <link rel="stylesheet" href="~/@NoCache.Tag("/content/site.css")" />
         *
         *   Output
         *   <link rel="stylesheet" href="/content/v-634933238684083941/site.css" />
         */

        public static string Tag(string rootRelativePath) {
            if(String.IsNullOrWhiteSpace(rootRelativePath)) {
                throw new ArgumentNullException($"{nameof(rootRelativePath)}is required");
            }
            if(HttpRuntime.Cache[rootRelativePath] != null) {
                return HttpRuntime.Cache[rootRelativePath] as string;
            }
            var absolute = HostingEnvironment.MapPath($"~{rootRelativePath}");
            if(absolute == null) {
                throw new Exception($"could not map HostingEnvironment.MapPath for {rootRelativePath}");
            }
            var date = File.GetLastWriteTime(absolute);
            var index = rootRelativePath.LastIndexOf('/');
            var result = rootRelativePath.Insert(index, $"/v-{date.Ticks}");
            HttpRuntime.Cache.Insert(rootRelativePath, result.TrimStart('/'), new CacheDependency(absolute));
            return HttpRuntime.Cache[rootRelativePath] as string;
        }

    }

}
