using System;

namespace Test.Maze.Main
{    /// <summary>
     /// Exposes basic features of a maze.
     /// </summary>
    public interface IMaze
    {

        IMazeRoom GetRoom(Location location);

      
        IMazeRoom GetAdjacentRoom(Location location, char direction);

        int Length { get; }

   
        int Width { get; }

   
        Location EntranceLocation { get; }
    }
}
