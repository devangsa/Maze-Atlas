namespace Test.Maze.SimpleMaze.Rooms
{
    using Test.Maze.Main;

    public class Desert : MazeTrapRoom
    {
        private const string Description =
            "No matter when you look, not a shadow in sight. Sand and searing heat is the only things " + 
            "that can be found. The wind is whipping sharp grains of sand into your face as you slowly " + 
            "advance from dune to dune. You need to find shelter or maybe an oasis.";

        public Desert(int roomId, IMazeRoomTrap roomTrap) : base(roomId, Description, roomTrap)
        {
        }
    }
}
