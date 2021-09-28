namespace Test.Maze.SimpleMaze
{
    using System;
    using System.Collections.Generic;
    using Test.Maze.Main;


    /// <summary>
    /// Builds and returns an instance of the <see cref="SimpleMaze"/> class.
    /// </summary>
    public class SimpleMazeFactory : IMazeFactory
    {
        private const int MinimalMazeSize = 3;

        private int size;
        private  ILocationGenerator generator;
        private  SimpleMazeRoomFactory roomFactory;
        private  IList<int> usedIds;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleMazeFactory"/> class.
        /// </summary>
        public SimpleMazeFactory() : this(new SimpleMazeRoomFactory(), new SimpleLocationGenerator())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleMazeFactory"/> class.
        /// </summary>
        /// <param name="roomFactory">
        /// An instance of the <see cref="SimpleMazeRoomFactory"/> class.
        /// </param>
        /// <param name="generator">
        /// An instance of a class implementing the <see cref="ILocationGenerator"/> interface.
        /// </param>
        public SimpleMazeFactory(SimpleMazeRoomFactory roomFactory, ILocationGenerator generator)
        {
            this.roomFactory = roomFactory;
            this.generator = generator;
            this.usedIds = new List<int>();
        }

        /// <summary>
        /// Builds an instance of the <see cref="SimpleMaze"/> class
        /// containing a maze entrance, a treasury and a collection
        /// of randomly generated maze rooms.
        /// </summary>
        /// <param name="size">
        /// A size of the edge of a maze to be generated
        /// </param>
        /// <returns>
        /// An instance of the <see cref="SimpleMaze"/> class.
        /// </returns>
        public IMaze BuildMaze(int size)
        {
            if (size < MinimalMazeSize)
            {
                throw new ArgumentOutOfRangeException(
                    "The stage edge cannot be smaller than {0} elements.".InjectInvariant(MinimalMazeSize), nameof(size));
            }

            this.size = size;
            var maze = new IMazeRoom[size, size]
                .AddRoom(this.BuildEntrance())
                .AddRoom(this.BuildTreasury())
                .AddRooms(this.BuildRooms());

            return new SimpleMaze(maze, this.usedIds[0].AsLocation(this.size));
        }

        private IMazeRoom BuildEntrance()
        {
            var entLoc = this.generator.GenerateEdgeLocation(this.size).Tee(this.AddUsedId);
            return this.roomFactory.BuildEntrance(entLoc.AsRoomId(this.size));
        }

        private IMazeRoom BuildTreasury()
        {
            var loc = this.generator.GenerateInnerLocation(this.size).Tee(this.AddUsedId);
            return this.roomFactory.BuildTreasury(loc.AsRoomId(this.size));
        }

        private IEnumerable<IMazeRoom> BuildRooms()
        {
            for (var i = 0; i < this.size; i++)
            {
                for (var j = 0; j < this.size; j++)
                {
                    var roomId = new Location(i, j).AsRoomId(this.size);
                    if (!this.usedIds.Contains(roomId))
                    {
                        yield return this.roomFactory.BuildRandomRoom(roomId);
                    }
                }
            }
        }

        private void AddUsedId(Location location)
        {
            this.usedIds.Add(location.AsRoomId(this.size));
        }
    }
}

