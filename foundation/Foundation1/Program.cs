using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Cook Pasta", "Chef John", 300);
        video1.AddComment(new Comment("Alice", "Great recipe!"));
        video1.AddComment(new Comment("Bob", "I tried it, and it was delicious."));
        video1.AddComment(new Comment("Carol", "Can you add more tips on seasoning?"));
        videos.Add(video1);

        Video video2 = new Video("Understanding Quantum Physics", "Dr. Smith", 900);
        video2.AddComment(new Comment("David", "This is so confusing but fascinating."));
        video2.AddComment(new Comment("Eve", "Thanks for breaking it down!"));
        video2.AddComment(new Comment("Frank", "Could you recommend more resources?"));
        videos.Add(video2);

        Video video3 = new Video("Travel Vlog: Paris", "Globetrotter", 600);
        video3.AddComment(new Comment("Grace", "Love your videos!"));
        video3.AddComment(new Comment("Hank", "Paris looks amazing."));
        video3.AddComment(new Comment("Ivy", "What camera are you using?"));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; private set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}
