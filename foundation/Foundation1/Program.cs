using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create the videos
        Video video1 = new Video("How the Beatles fueled Paul McCartney's death rumors", "Adão Klepa", 440);
        Video video2 = new Video("Uncomplicated Python", "Cristiano Rodrigues", 3500);
        Video video3 = new Video("Ranking the albums of the main rock bands of the 70s and 80s", "Adão Klepa", 2400);

        // Add comments to videos
        video1.AddComment(new Comment("Rebeca", "Are you sure they did this?!"));
        video1.AddComment(new Comment("SilentBob", "What is Beatles?"));
        video1.AddComment(new Comment("Thompson", "Paul died in the accident. I saw it, I was there."));

        video2.AddComment(new Comment("David", "Best explanation I've ever seen."));
        video2.AddComment(new Comment("Magda", "Now I'm a programmer!"));
        video2.AddComment(new Comment("Sinatra", "I'm a dead musician! This isn't for me."));

        video3.AddComment(new Comment("Rufus", "And where are the deep purple albums?"));
        video3.AddComment(new Comment("Walter", "I completely agree."));
        video3.AddComment(new Comment("Santana", "You don't understand music. try food videos."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display details for each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}