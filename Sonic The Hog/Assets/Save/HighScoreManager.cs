using UnityEngine;
using Realms.Sync;
using Realms;
using System;

public class HighScoreManager : MonoBehaviour
{
    private async void Start()
    {
        // Initialize MongoDB Realm App
        string yourRealmAppId = "<application-0-vujja>";

        // Create a new App with the App ID
        var app = App.Create(new AppConfiguration(yourRealmAppId));

        // Get a user (you can customize this based on your authentication)
        var user = await app.LogInAsync(Credentials.Anonymous());

        // Open a Realm instance
        var realm = Realm.GetInstance(new RealmConfiguration(user));

        // Create a new HighScore object
        var highScore = new highscore
        {
            InsertedAt = DateTimeOffset.Now,
            Partition = "your_partition_value",
            Player = "John Doe",
            Score = 1000
        };

        // Write the HighScore to the Realm
        using (var transaction = realm.BeginWrite())
        {
            realm.Write(highScore);
            transaction.Commit();
        }

        Debug.Log("HighScore written to MongoDB Realm!");
    }
}


