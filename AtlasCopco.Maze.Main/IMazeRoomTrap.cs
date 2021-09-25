using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Maze.Main
{
    public interface IMazeRoomTrap
    {

        string BehaviorDescription { get; }

        bool Fire();
    }
}
