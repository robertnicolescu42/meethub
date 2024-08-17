using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MeetHub.API.Helpers
{
    /// <summary>
    /// Json file retriever class
    /// </summary>
    public static class JsonFileRetriever
    {
        #region Methods

        /// <summary>
        /// Get the configured fields from the config file 'appsettings.json'
        /// </summary>
        /// <returns></returns>
        public static JObject GetConfiguration(string fileName)
        {
            JObject config = new JObject();
            try
            {
                using (StreamReader r = new StreamReader(fileName))
                {
                    string json = r.ReadToEnd();
                    config = (JObject)JsonConvert.DeserializeObject(json);
                }
            }
            catch (JsonException)
            {
                // Not implemented. Use logger service to add log
                throw;
            }
            catch (Exception)
            {

                throw;
            }

            return config;
        }

        /// <summary>
        /// Gets the property value from json config
        /// </summary>
        /// <param name="fieldKey"> The key of the field </param>
        /// <param name="configFileName"> The configuration file name </param>
        /// <returns></returns>
        public static string GetConfigurationValue(string fieldKey, string configFileName)
        {
            var config = JsonFileRetriever.GetConfiguration(configFileName);
            return config[fieldKey].Value<string>();
        }

        /// <summary>
        /// Gets the property value from json config
        /// </summary>
        /// <param name="fieldKey"> The key of the field </param>
        /// <param name="configFileName"> The configuration file name </param>
        /// <returns></returns>
        public static List<T> GetConfigurationObjectValue<T>(string fieldKey, string configFileName)
        {
            var config = JsonFileRetriever.GetConfiguration(configFileName);
            var objects = config[fieldKey].Value<List<object>>();
            return objects.Cast<T>().ToList();
        }
        #endregion Methods
    }
}
