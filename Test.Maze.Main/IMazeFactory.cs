
namespace Test.Maze.Main
{
    /// <summary>
    /// A facade for building different kinds of mazes.
    /// </summary>
    public interface IMazeFactory
    {
        IMaze BuildMaze(int size);
    }
}
