using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FamApp.Frontend.ApiHandling;

namespace FamApp.Frontend.Classes
{
    public class User
    {
        //Parameter für das Objekt User
        private int id;
        private string? first_name;
        private string? last_name;
        private string? email;
        private string? password;

        //getter und Setter für unsere Parameter
        public int Id { get => id; set => id = value; }
        public string First_Name { get => first_name; set => first_name = value; }
        public string Last_Name { get => last_name; set => last_name = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        //Task da async, Liste aus UserObjekten wird returned
        public static async Task<List<User>?> GetUsers()
        {
            // Instantiiert neuen Httphandler
            HttpHandler client = new();

            //wird in response gespeichert
            //client.Client = HttpClient aus dem HttpHandler
            //GetAsync = GET-Call an die API => Wir wollen etwas aus der DB holen
            // $"{client.Url + typeof(User).Name}" = Adresse, an der der API-Call geschickt wird
            HttpResponseMessage response = await client.Client.GetAsync($"{client.Url + typeof(User).Name}");

            // Abhängig vom StatusCode erfolgt Rückgabe
            // StatusCode = OK (bspw.: 200) return Liste aus Usern
            // StatusCode = Nicht OK (bspw.: 400, 500) return null
            return response.IsSuccessStatusCode
                ? await response.Content.ReadAsAsync<List<User>>()
                : null;
        }

        public static async Task<User?> GetUser(int getId)
        {
            HttpHandler client = new();

            HttpResponseMessage response = await client.Client.GetAsync($"{client.Url + typeof(User).Name}/id/{getId}");

            return response.IsSuccessStatusCode
                ? await response.Content.ReadAsAsync<User>()
                : null;
        }

        public static async Task<User?> CreateNewUser(User user)
        {
            HttpHandler client = new();

            HttpResponseMessage response = await client.Client.PostAsJsonAsync($"{client.Url + typeof(User).Name}", user);

            response.EnsureSuccessStatusCode();

            HttpResponseMessage responseUser = await client.Client.GetAsync($"{client.Url + typeof(User).Name}/mail/{user.Email}");

            return responseUser.IsSuccessStatusCode
                ? await responseUser.Content.ReadAsAsync<User>()
                : null;
        }

        public static async Task<User> UpdateUser(int id, User user)
        {
            HttpHandler client = new();

            HttpResponseMessage response = await client.Client.PutAsJsonAsync($"{client.Url + typeof(User).Name}/update/{id}", user);

            return await response.Content.ReadAsAsync<User>();

        }

        public static async Task<HttpStatusCode> DeleteUser(int id)
        {
            HttpHandler client = new();

            return (await client.Client.DeleteAsync($"{client.Url + typeof(User).Name}/{id}")).StatusCode;
        }


    }
}
