using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Maze.SimpleMaze
{
    public class SimpleMazeRoomFactory
    {

        public SimpleMazeRoomFactory() : this(new SimpleRoomTrapFactory(), new Random())
        {
        }


        public SimpleMazeRoomFactory(IMazeRoomTrapFactory trapFactory, Random randomizer)
        {
            this._trapFactory = trapFactory;
            this._randomizer = randomizer;
            this.InitializeRoomTypes();
        }
    }
}
