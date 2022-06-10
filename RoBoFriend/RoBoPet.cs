namespace RoBoFriend
{
    /// <summary>
    /// Directional options.
    /// </summary>
    public enum Direction
    {
        North = 1,
        East = 2,
        South = 3,
        West = 4
    }

    /// <summary>
    /// Available Command instructions.
    /// </summary>
    public enum Commands
    {
        Move = 0,
        Left = 1,
        Right = 2,
        Report = 3
    }

    /// <summary>
    /// User feedback responses.
    /// </summary>
    public static class Feedback
    {
        public static readonly string
            PlacementResponse = "Please start by placing your Robo-Pet on the table, example: PLACE 0 0 NORTH \n";
        public static readonly string
            NoCommandResponse = "Please give your Robo-Pet a command, example: PLACE 0 0 NORTH \n";
        public static readonly string
             BadCommandResponse = "Please give your Robo-Pet a valid command with no spaces, example: PLACE 0 0 NORTH \n";
    }

    public static class RoBoPet
    {
        /// <summary>
        /// Gets or sets the direction the robot is facing.
        /// </summary>
        public static Direction Facing
        { get; set; }

        /// <summary>
        /// Gets or sets the vertical axis.
        /// </summary>
        public static int X_Axis
        { get; set; }

        /// <summary>
        /// Gets or sets the horizontal axis.
        /// </summary>
        public static int Y_Axis
        { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the robot is on the table.
        /// </summary>
        public static bool OnTableSurface
        { get; set; }
    }
}