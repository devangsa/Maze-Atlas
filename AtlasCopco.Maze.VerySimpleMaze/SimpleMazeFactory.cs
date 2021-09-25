using Test.Maze.Main;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Maze.SimpleMaze
{
    /// <summary>
    /// Builds and returns an instance of the <see cref="VerySimpleMaze"/> class.
    /// </summary>
    public class SimpleMazeFactory : IMazeFactory
    {
        private const int MinimalMazeSize = 3;
         
        public SimpleMazeFactory() : this(new SimpleMazeRoomFactory(), new SimpleLocationGenerator())
        {
        }
    }
}
