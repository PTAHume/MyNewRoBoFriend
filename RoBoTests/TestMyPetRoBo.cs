using RoBoFriend;

namespace RoBoTests
{
    public class TestMyPetRoBo
    {
        public TestMyPetRoBo()
        {
            RoBoEngine.Reset();
        }

        [Fact]
        public void CanPlaceRoBo()
        {
            // Arrange
            string playCommand = "PLACE 1 5 NORTH";

            // Act
            RoBoEngine.RunCommand(playCommand);

            // Assert
            Assert.Equal(Direction.North, RoBoPet.Facing);
            Assert.Equal(1, RoBoPet.X_Axis);
            Assert.Equal(5, RoBoPet.Y_Axis);
            Assert.True(RoBoPet.OnTableSurface);
        }

        [Fact]
        public void NoMovementBeforePlacement()
        {
            // Arrange
            string playCommand = "MOVE";
            using (var consoleOutput = new ConsoleOutput())
            {
                // Act
                RoBoEngine.RunCommand(playCommand);

                // Assert
                Assert.Matches(Feedback.PlacementResponse, consoleOutput.GetOuPut());
                Assert.False(RoBoPet.OnTableSurface);
            }
        }

        [Fact]
        public void MustHaveACommand()
        {
            // Arrange
            string playCommand = string.Empty;
            using (var consoleOutput = new ConsoleOutput())
            {
                // Act
                RoBoEngine.RunCommand(playCommand);

                // Assert
                Assert.Matches(Feedback.NoCommandResponse, consoleOutput.GetOuPut());
            }
        }

        [Fact]
        public void CantFallOffTable()
        {
            // Arrange
            string[] playCommands = new string[] { "PLACE 0 0 NORTH",
                                                    "MOVE", "MOVE", "MOVE", "MOVE", "MOVE", "MOVE",
                                                    "REPORT"
                                                    };
            using (var consoleOutput = new ConsoleOutput())
            {
                // Act
                foreach (string command in playCommands)
                {
                    RoBoEngine.RunCommand(command);
                }

                // Assert
                Assert.Matches(string.Format("Output: {0}, {1}, {2}", 0, 5, Direction.North), consoleOutput.GetOuPut());
                Assert.True(RoBoPet.OnTableSurface);
            }
        }

        [Fact]
        public void CanRomeAround()
        {
            // Arrange
            string[] playCommands = new string[] { "PLACE 0 0 NORTH",
                                                    "MOVE", "MOVE", "MOVE",
                                                    "RIGHT", "MOVE", "MOVE", "MOVE",
                                                    "RIGHT", "MOVE", "MOVE",
                                                    "RIGHT", "MOVE", "REPORT" };
            using (var consoleOutput = new ConsoleOutput())
            {
                // Act
                foreach (string command in playCommands)
                {
                    RoBoEngine.RunCommand(command);
                }

                // Assert
                Assert.Matches(string.Format("Output: {0}, {1}, {2}", 2, 1, Direction.West), consoleOutput.GetOuPut());
                Assert.True(RoBoPet.OnTableSurface);
            }
        }

        [Fact]
        public void CanDoAFullTurnAround()
        {
            // Arrange
            string[] playCommands = new string[] { "PLACE 2 2 NORTH",
                                                    "LEFT", "LEFT", "LEFT", "LEFT",
                                                    "REPORT" };
            using (var consoleOutput = new ConsoleOutput())
            {
                // Act
                foreach (string command in playCommands)
                {
                    RoBoEngine.RunCommand(command);
                }

                // Assert
                Assert.Matches(string.Format("Output: {0}, {1}, {2}", 2, 2, Direction.North), consoleOutput.GetOuPut());
                Assert.True(RoBoPet.OnTableSurface);
            }
        }

        [Fact]
        public void CanBeReplacedAndMove()
        {
            // Arrange
            string[] playCommands = new string[] { "PLACE 3 2 NORTH",
                                                    "MOVE", "MOVE", "RIGHT", "MOVE",
                                                    "PLACE 2 2 SOUTH",
                                                    "MOVE", "LEFT", "MOVE", "REPORT" };
            using (var consoleOutput = new ConsoleOutput())
            {
                // Act
                foreach (string command in playCommands)
                {
                    RoBoEngine.RunCommand(command);
                }

                // Assert
                Assert.Matches(string.Format("Output: {0}, {1}, {2}", 3, 1, Direction.East), consoleOutput.GetOuPut());
                Assert.True(RoBoPet.OnTableSurface);
            }
        }

        [Fact]
        public void IgnoreBadCommands()
        {
            // Arrange
            string[] playCommands = new string[] { "PLACE 7 7 NORTH",
                                                    "     MOVE   ", "FOO", "" };
            using (var consoleOutput = new ConsoleOutput())
            {
                // Act
                foreach (string command in playCommands)
                {
                    RoBoEngine.RunCommand(command);
                }

                // Assert
                Assert.Matches(Feedback.BadCommandResponse, consoleOutput.GetOuPut());
            }

            // Assert
            Assert.False(RoBoPet.OnTableSurface);
        }

        [Fact]
        public void CanCompleteUserStories()
        {
            // Arrange
            using (var consoleOutput = new ConsoleOutput())
            {
                // Act - user story: A
                string[] playCommands = new string[] { "PLACE 0 0 NORTH",
                                                        "MOVE",
                                                        "REPORT" };
                foreach (string command in playCommands)
                {
                    RoBoEngine.RunCommand(command);
                }

                // Assert
                Assert.Matches(string.Format("Output: {0}, {1}, {2}", 0, 1, Direction.North), consoleOutput.GetOuPut());

                // Act - user story: B
                playCommands = new string[] { "PLACE 0 0 NORTH",
                                                "LEFT",
                                                "REPORT" };
                foreach (string command in playCommands)
                {
                    RoBoEngine.RunCommand(command);
                }

                // Assert
                Assert.Matches(string.Format("Output: {0}, {1}, {2}", 0, 0, Direction.West), consoleOutput.GetOuPut());

                // Act - user story: C
                playCommands = new string[] { "PLACE 1 2 EAST",
                                                "MOVE", "MOVE", "LEFT",
                                                "MOVE", "REPORT" };
                foreach (string command in playCommands)
                {
                    RoBoEngine.RunCommand(command);
                }

                // Assert
                Assert.Matches(string.Format("Output: {0}, {1}, {2}", 3, 3, Direction.North), consoleOutput.GetOuPut());
            }

            // Assert
            Assert.True(RoBoPet.OnTableSurface);
        }
    }
}