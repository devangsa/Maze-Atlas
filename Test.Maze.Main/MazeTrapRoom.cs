namespace Test.Maze.Main
{
    using System.Linq;

    public abstract class MazeTrapRoom : MazeRoom
    {
        private bool trapFired;

        /// <summary>
        /// Initializes a new instance of the <see cref="MazeTrapRoom"/> class.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="description"></param>
        /// <param name="trap"></param>
        public MazeTrapRoom(int roomId, string description, IMazeRoomTrap trap) : base(roomId, description) 
        {
            this.Traps.Add(trap);
        }

        /// <summary>
        /// Gets the value indicating if the room causes an injury.
        /// </summary>
        public override bool CausesInjury
        {
            get
            {
                if (this.Traps.Any())
                {
                    this.trapFired = this.Traps.First().Fire();
                    return this.trapFired;
                }

                return false;
            }
        }

        /// <summary>
        /// Gets the room description.
        /// </summary>
        public override string GetDescription() 
        {            
            if (this.trapFired)
            {
                var trapDescription = this.Traps.First().BehaviorDescription;
                return string.Format($"{this.GetType().Name} - {this.description}\n{trapDescription}");
            }

            return base.GetDescription();
        }
    }
}
