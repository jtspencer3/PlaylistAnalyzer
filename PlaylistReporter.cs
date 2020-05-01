using System.Collections.Generic;
using System.Linq;

namespace MusicPlaylistAnalyzer
{
    public class PlaylistReporter
    {
        public static string GenerateReport(List<Song> Playlist)
        {
            string report = "Playlist Report\n\n";

            if (Playlist.Count() < 1)
            {
                report += "No data is available.\n";

                return report;
            }
            report += "Songs that received 200 or more plays: ";
            var plays200orMore = from Song in Playlist where Song.Plays >= 200 select Song;

            if (plays200orMore.Count() > 0)
            {
                foreach ( var song in plays200orMore)
                {
                    report += song + "\n";
                }
                report += "\n";
            }

            
            var alternativeSongs = from Song in Playlist where Song.Genre == "Alternative" select Song;
            report += $"Number of Alternative songs: {alternativeSongs.Count()}\n";

            var hiphopSongs = from Song in Playlist where Song.Genre == "Hip=Hop/Rap" select Song;
            report += $"Number of Hip-Hop/Rap songs: {hiphopSongs.Count()}" + "\n\n";

            report += "Songs from the album Welcome to the Fishbowl: ";
            var welcomeToTheFishbowl = from Song in Playlist where Song.Album == "Welcome to the Fishbowl" select Song;

            if (welcomeToTheFishbowl.Count() > 0)
            {
                foreach ( var song in welcomeToTheFishbowl)
                {
                    report += song + "\n";
                }
                report += "\n";
            }

            report += "Songs from before 1970: ";
            var songsBefore1970 = from Song in Playlist where Song.Year < 1970 select Song;

            if (songsBefore1970.Count() > 0)
            {
                foreach ( var song in songsBefore1970)
                {
                    report += song + "\n";
                }
                report += "\n";
            }

            report += "Song names longer than 85 characters: ";
            var songsLongerThan85 = from Song in Playlist where Song.Name.Length > 85 select Song;

            if (songsLongerThan85.Count() > 0)
            {
                foreach ( var song in songsLongerThan85)
                {
                    report += song + "\n";
                }
                report += "\n";
            }

            report += "Longest song: ";
            var longestSong = from Song in Playlist orderby Song.Name descending select Song;

            report += $"{longestSong.First()}";

            return report;
        }

    }
}