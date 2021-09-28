namespace Test.Maze.SimpleMaze.Rooms.Traps
{
    using System;

    using Test.Maze.Main;
    public class SimpleRoomTrapFactory : IMazeRoomTrapFactory
    {
        public IMazeRoomTrap CreateTrapFor(Type t)
        {
            if (t == typeof(Desert))
            {
                return new DehydrationTrap();
            }

            if (t == typeof(Marsh))
            {
                return new SinkingTrap();
            }

            throw new ArgumentException("No trap found for the type of {0}.".InjectInvariant(t.Name));
        }
    }
}
