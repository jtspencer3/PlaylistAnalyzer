using System;
using System.IO;
using System.Collections.Generic;

namespace MusicPlaylistAnalyzer
{
    public static class LoadPlaylist
    {
        private static int NumItemsInRow = 8;

        public static List<Song> Load(string txtDataFilePath) 
        {
            List<Song> Playlist = new List<Song>();

            int lineNumber = 0;

            try
            {
                using (var reader = new StreamReader(txtDataFilePath))
                {
                    while(!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        lineNumber++;
                        if(lineNumber == 1) continue;

                        var values = line.Split('\t');

                        if (values.Length != NumItemsInRow)
                        {
                            throw new Exception($"Row {lineNumber} contains {values.Length} values. It should contain {NumItemsInRow}.");
                        }
                        try
                        {
                            string name = values[0];
                            string artist = values[1];
                            string album = values[2];
                            string genre = values[3];
                            int size = Int32.Parse(values[4]);
                            double time = Double.Parse(values[5]);
                            int year = Int32.Parse(values[6]);
                            int plays = Int32.Parse(values[7]);
                            Song song = new Song(name, artist, album, genre, size, time, year, plays);
                            Playlist.Add(song);
                        }
                        catch(FormatException ex)
                        {
                            throw new Exception($"Row {lineNumber} contains invalid data. ({ex.Message})");
                        }
                    }
                }
                
            } catch (Exception ex) 
            {
                throw new Exception($"Unable to open {txtDataFilePath} ({ex.Message})");
            }

            return Playlist;
        }
    }
}