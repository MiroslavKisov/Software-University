using System;
using System.Collections.Generic;
using System.Text;


public class Song
{
    private string artistName;
    private string songName;
    private int durationInSeconds;
    private int durationInMinutes;

    public int DurationInMinutes
    {
        get { return durationInMinutes; }
        set
        {
            if (value < 0 || value > 14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }
            durationInMinutes = value;
        }
    }

    public int DurationInSeconds
    {
        get { return durationInSeconds; }
        set
        {
            if (value < 0 || value > 59)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }
            durationInSeconds = value;
        }
    }

    public string SongName
    {
        get { return songName; }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException("Song name should be between 3 and 30 symbols.");
            }
            songName = value;
        }
    }

    public string ArtistName
    {
        get { return artistName; }
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            }
            artistName = value;
        }
    }

    public Song(string artistName, string songName, int durationInMinutes, int durationInSeconds)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.DurationInMinutes = durationInMinutes;
        this.DurationInSeconds = durationInSeconds;
    }

}

