using Microsoft.Extensions.Localization;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace HastaneRandevuSistemi.Services
{
    public class LanguageService
    {
        public class SharedResource { 
        
        
        }
        private readonly IStringLocalizer _localizer;

        public LanguageService(IStringLocalizerFactory factory) {

            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName (type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create(nameof(SharedResource),assemblyName.Name);

           
        
        }
        public LocalizedString Getkey(string key)
        {
            return _localizer[key];
             
        }
    }
}
