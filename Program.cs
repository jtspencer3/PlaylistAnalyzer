using System;
using System.Collections.Generic;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            if ( args.Length != 2)
            {
                Console.WriteLine("Playlist Reporter <playlist_file_path> <report_file_path>");
                Environment.Exit(1);
            }

            string DataFilePath = args[0];
            string reportFilePath = args[1];

            List<Song> Playlist = null;

            try
            {
                Playlist = LoadPlaylist.Load(DataFilePath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(2);
            }

            var report = PlaylistReporter.GenerateReport(Playlist);

            try
            {
                System.IO.File.WriteAllText(reportFilePath, report);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(3);
            }
        }
    }
}
