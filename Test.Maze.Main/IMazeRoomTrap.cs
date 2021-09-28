namespace Test.Maze.Main
{
    public interface IMazeRoomTrap
    {

        string BehaviorDescription { get; }

        bool Fire();
    }
}
