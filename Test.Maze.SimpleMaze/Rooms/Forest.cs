namespace Test.Maze.SimpleMaze.Rooms
{
    using Test.Maze.Main;

    public class Forest : MazeRoom
    {
        private const string Description =
            "You open a huge door with a crackling noise. In the dark woods you navigate the path not by sight yet " +
            "by faith and memory.";

        public Forest(int roomId) : base(roomId, Description) 
        {
        }
    }
}
