using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Maze.Main
{
    public class Location
    {
      
        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Location()
        {
        }
    
        public int X { get; set; }

     
        public int Y { get; set; }

   
        public Location North => new Location(this.X, this.Y + 1);

        public Location East => new Location(this.X + 1, this.Y);

 
        public Location South => new Location(this.X, this.Y - 1);

    
        public Location West => new Location(this.X - 1, this.Y);
    }
}
