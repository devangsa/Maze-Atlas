using System;
using System.Collections.Generic;
using System.Text;

namespace AtlasCopco.Maze.Main
{
    public interface IMazeRoomTrap
    {

        string BehaviorDescription { get; }

        bool Fire();
    }
}
