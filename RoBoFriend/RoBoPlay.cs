namespace RoBoFriend
{
    public static class RoBoPlay
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Type 'end' and press Enter to close the app \n");
            while (true)
            {
                var command = Console.ReadLine() ?? string.Empty;
                if (string.Equals(command, "END", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                RoBoEngine.RunCommand(command);
            }
        }
    }
}
