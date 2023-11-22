using static System.Net.WebRequestMethods;

namespace OpenGTINDB
{
    public class OpenGTINDBHandler
    {
        private string? USER_ID;
        private readonly string baseURL = "http://opengtindb.org/";
        private readonly HttpClient httpClient;

        public OpenGTINDBHandler(string user_id)
        {
            setUserID(user_id);
            httpClient = new HttpClient();
        }

        // API-Key setzen
        public void setUserID(string user_id)
        {
            USER_ID = user_id;
        }

        // API-Key holen
        public string? getUserID()
        {
            return USER_ID;
        }

        public string getBaseURL()
        {
            return baseURL;
        }

        // Produkt-Informationen per HTTP-Abfrage holen
        public async Task<string> getProductInformation(string gtin)
        {
            // Anfragen-URL definieren
            string url = $"{baseURL}?ean={gtin}&cmd=query&queryid={getUserID}";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                // Wurde StatusCode 200 zurückgegeben?
                if (response.IsSuccessStatusCode)
                {
                    // Antwort lesen
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Fehlercode und -meldung zurückgeben
                    throw new HttpRequestException($"Fehler: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex) 
            {
                throw new HttpRequestException($"Fehler: {ex.Message}");
            }
        }
    }
}
