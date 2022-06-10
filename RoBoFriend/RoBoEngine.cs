using System.Text.RegularExpressions;

namespace RoBoFriend
{
    public static class RoBoEngine
    {
        private const string AcceptedCommandsPatten = @"^PLACE [0-5] [0-5] \b(?:north|east|south|west)\b$|\b^(?:move|left|right|report)\b$";
        private const string PlacePatten = @"(PLACE) ([0-5]) ([0-5]) (\b(?:north|east|south|west)\b)";

        /// <summary>
        /// Gig RoBo A command.
        /// </summary>
        /// <param name="command">PLACE 0 0 NORTH.</param>
        public static void RunCommand(string command)
        {
            try
            {
                if (string.IsNullOrEmpty(command))
                {
                    Console.Write(Feedback.NoCommandResponse);
                }

                Regex regex = new Regex(AcceptedCommandsPatten, RegexOptions.IgnoreCase);
                Match match = regex.Match(command);

                if (match.Success)
                {
                    regex = new Regex(PlacePatten, RegexOptions.IgnoreCase);
                    match = regex.Match(command);

                    if (match.Success)
                    {
                        PlaceRoBo(match);
                    }
                    else if (RoBoPet.OnTableSurface)
                    {
                        MoveRoBo(command);
                    }
                    else
                    {
                        Console.Write(Feedback.PlacementResponse);
                    }
                }
                else if (command.Any())
                {
                    Console.Write(Feedback.BadCommandResponse);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        /// <summary>
        /// Factory Reset Robo.
        /// </summary>
        public static void Reset()
        {
            RoBoPet.Facing = 0;
            RoBoPet.X_Axis = 0;
            RoBoPet.Y_Axis = 0;
            RoBoPet.OnTableSurface = false;
        }

        private static void MoveRoBo(string command)
        {
            Enum.TryParse<Commands>(command, true, out var Instruction);

            switch (Instruction)
            {
                case Commands.Right:
                    RoBoPet.Facing = ((int)RoBoPet.Facing + 1) > 4 ? Direction.North : RoBoPet.Facing + 1;
                    break;
                case Commands.Left:
                    RoBoPet.Facing = ((int)RoBoPet.Facing - 1) < 1 ? Direction.West : RoBoPet.Facing - 1;
                    break;
                case Commands.Move:
                    if (RoBoPet.Facing == Direction.North && RoBoPet.Y_Axis + 1 <= 5)
                    {
                        RoBoPet.Y_Axis++;
                    }
                    else if (RoBoPet.Facing == Direction.South && RoBoPet.Y_Axis - 1 > 0)
                    {
                        RoBoPet.Y_Axis--;
                    }
                    else if (RoBoPet.Facing == Direction.East && RoBoPet.X_Axis + 1 <= 5)
                    {
                        RoBoPet.X_Axis++;
                    }
                    else if (RoBoPet.Facing == Direction.West && RoBoPet.X_Axis - 1 > 0)
                    {
                        RoBoPet.X_Axis--;
                    }

                    break;
                case Commands.Report:
                    Console.Write(string.Format("Output: {0}, {1}, {2} \n", RoBoPet.X_Axis, RoBoPet.Y_Axis, RoBoPet.Facing.ToString()));
                    break;
            }
        }

        private static void PlaceRoBo(Match match)
        {
            int.TryParse(match.Groups[2].Value, out var xAxis);
            int.TryParse(match.Groups[3].Value, out var yAxis);
            Enum.TryParse<Direction>(match.Groups[4].Value, true, out var location);

            RoBoPet.X_Axis = xAxis;
            RoBoPet.Y_Axis = yAxis;
            RoBoPet.Facing = location;
            RoBoPet.OnTableSurface = true;
        }
    }
}
