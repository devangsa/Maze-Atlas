using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Maze.Main
{

    /// <summary>
    /// Exposes details of a maze room the player can get in to.
    /// </summary>
    public interface IMazeRoom
    {
        int RoomId { get; set; }
        string GetDescription();
        bool IsEntrance { get; set; }
        bool HasTreasure { get; set; }
        bool CausesInjury { get; }
        IList<IMazeRoomTrap> Traps { get; set; }
        IList<string> Actions { get; set; }
    }
}
