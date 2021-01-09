using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Song> songs = new List<Song>();

        int numberOfSongs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfSongs; i++)
        {
            var songsArgs = Console.ReadLine()
                    .Split(';');
            try
            {
                if (songsArgs.Length == 3)
                {
                    AddSongs(songsArgs, songs);
                }
                else
                {
                    Console.WriteLine("Invalid song.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        string songLength = CalculateSongsTotalDuration(songs);
        Console.WriteLine($"Songs added: {songs.Count}");
        Console.WriteLine(songLength);
    }

    private static void AddSongs(string[] songsArgs, List<Song> songs)
    {
        var durationArgs = songsArgs[2].Split(':');

        string artistName = songsArgs[0];
        string songName = songsArgs[1];
        int minutes;
        int seconds;

        if (int.TryParse(durationArgs[0], out minutes) && int.TryParse(durationArgs[1], out seconds))
        {
            Song song = new Song(artistName, songName, minutes, seconds);
            Console.WriteLine("Song added.");
            songs.Add(song);
        }
        else
        {
            Console.WriteLine("Invalid song length.");
        }
    }

    private static string CalculateSongsTotalDuration(List<Song> songs)
    {
        
        int totalSeconds = 0;

        for (int i = 0; i < songs.Count; i++)
        {
            totalSeconds += songs[i].DurationInSeconds + (songs[i].DurationInMinutes * 60);
        }

        TimeSpan time = TimeSpan.FromSeconds(totalSeconds);

        return $"Playlist length: {time.Hours}h {time.Minutes}m {time.Seconds}s";
    }
}

