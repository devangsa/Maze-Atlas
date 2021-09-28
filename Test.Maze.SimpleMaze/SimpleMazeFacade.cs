using System;
using Test.Integration.Maze;
using Test.Maze.Main;


namespace Test.Maze.SimpleMaze
{
    public class SimpleMazeFacade : IMazeIntegration
    {
        private IMaze maze;
        private  IMazeFactory mazeFactory;

        public SimpleMazeFacade() : this(new SimpleMazeFactory())
        {
        }

        public SimpleMazeFacade(IMazeFactory mazeFactory)
        {
            this.mazeFactory = mazeFactory;
        }


        public void BuildMaze(int size)
        {
            this.maze = this.mazeFactory.BuildMaze(size);
            Console.WriteLine(this.maze.ToString());
        }
        public bool CausesInjury(int roomId)
        {
            this.EnsureMazeInitialized();
            var room = this.EnsureValidRoom(roomId);
            return room.CausesInjury;
        }

        public string GetDescription(int roomId)
        {
            this.EnsureMazeInitialized();
            var room = this.EnsureValidRoom(roomId);
            return room.GetDescription();
        }

        public int GetEntranceRoom()
        {
            this.EnsureMazeInitialized();
            return this.maze.EntranceLocation.AsRoomId(this.maze.Length);
        }

        public int? GetRoom(int roomId, char direction)
        {
            var roomLocation = roomId.AsLocation(this.maze.Length);
            return this.maze.GetAdjacentRoom(roomLocation, direction)?.RoomId;
        }

        public bool HasTreasure(int roomId)
        {
            this.EnsureMazeInitialized();
            var room = this.EnsureValidRoom(roomId);
            return room.HasTreasure;
        }

        private void EnsureMazeInitialized()
        {
            if (this.maze == null)
            {
                throw new ArgumentNullException("Maze not initialized. Please call the BuildMaze() method first.");
            }
        }

        private IMazeRoom GetRoom(int roomId)
        {
            var roomLocation = roomId.AsLocation(this.maze.Length);
            return this.maze.GetRoom(roomLocation);
        }

        private IMazeRoom EnsureValidRoom(int roomId)
        {
            var room = this.GetRoom(roomId);
            if (room == null)
            {
                throw new ArgumentOutOfRangeException("Unknown room identifier.");
            }

            return room;
        }
    }
}
