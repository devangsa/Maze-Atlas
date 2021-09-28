
namespace Test.Maze.SimpleMaze
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Test.Maze.Main;
    using Test.Maze.SimpleMaze.Rooms;
    using Test.Maze.SimpleMaze.Rooms.Traps;

    public class SimpleMazeRoomFactory
    {
        private  IMazeRoomTrapFactory trapFactory;
        private IEnumerable<Type> roomTypes;
        private  Random randomizer;

        public SimpleMazeRoomFactory() : this(new SimpleRoomTrapFactory(), new Random())
        {
        }

        public SimpleMazeRoomFactory(IMazeRoomTrapFactory trapFactory, Random randomizer)
        {
            this.trapFactory = trapFactory;
            this.randomizer = randomizer;
            this.InitializeRoomTypes();
        }

        public IMazeRoom BuildEntrance(int roomId)
        {
            return this.CreateMazeRoomOfType(typeof(Entrance), roomId);
        }

        public IMazeRoom BuildTreasury(int roomId)
        {
            return this.CreateMazeRoomOfType(typeof(Treasury), roomId);
        }

        public IMazeRoom BuildRandomRoom(int roomId)
        {
            return this.CreateMazeRoomOfType(this.GetRandomRoomType(), roomId);
        }

        private Type GetRandomRoomType()
        {
            return this.roomTypes.ElementAt(this.randomizer.Next(this.roomTypes.Count()));
        }

        private IMazeRoom CreateMazeRoomOfType(Type type, int roomId)
        {
            if (type.IsSubclassOf(typeof(MazeTrapRoom)))
            {
                return Activator.CreateInstance(type, roomId, this.trapFactory.CreateTrapFor(type)) as IMazeRoom;
            }

            return Activator.CreateInstance(type, roomId) as IMazeRoom;
        }

        private void InitializeRoomTypes()
        {
            this.roomTypes = Assembly.GetExecutingAssembly()
                                      .GetTypes()
                                      .Where(t => t.Namespace == "Text.Maze.SimpleMaze.Rooms"
                                             && t.IsClass
                                             && !new[] { typeof(Entrance), typeof(Treasury) }.Contains(t))
                                      .OrderBy(t => t.Name);
        }
    }
}

