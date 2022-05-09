using System;
using System.Text.Json;
using RestSharp;

class Program
{
    static async void Main(string[] args)
    {
        RestClient pokeClient = new RestClient("https://pokeapi.co/api/v2");
        while (true)
        {
            Console.WriteLine("Which pokemon?");
            RestRequest request;
            request = GetUserInput();
            RestResponse response = await pokeClient.GetAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("Not found!");
            }
            else
            {
                Pokemon poke = JsonSerializer.Deserialize<Pokemon>(response.Content);
                Console.WriteLine($"Name: {poke.Name}   id: {poke.Id}");
            }
            // if (IsValid(response))
            // {
            //     Pokemon poke = JsonSerializer.Deserialize<Pokemon>(response.Content);
            //     Console.WriteLine($"Name: {poke.Name}   id: {poke.Id}");
            // }
            // else
            // {
            //     Console.WriteLine("Not Found! Please enter a valid input...");
            // }
        }
    }
    static RestRequest GetUserInput()
    {
        string userInput = Console.ReadLine();

        RestRequest request = new RestRequest($"pokemon/{userInput}");

        return request;
    }

    static bool IsValid(RestResponse resp)
    {
        if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
