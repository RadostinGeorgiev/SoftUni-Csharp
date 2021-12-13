namespace AquaShop.Core
{
    using System;

    using AquaShop.IO;
    using AquaShop.IO.Contracts;
    using AquaShop.Core.Contracts;

    public class Engine : IEngine
    {
        private IWriter _writer;
        private IReader _reader;
        private IController _controller;

        public Engine()
        {
            this._writer = new Writer();
            this._reader = new Reader();
            this._controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = this._reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;

                    if (input[0] == "AddAquarium")
                    {
                        string aquariumType = input[1];
                        string aquariumName = input[2];

                        result = this._controller.AddAquarium(aquariumType, aquariumName);
                    }
                    else if (input[0] == "AddDecoration")
                    {
                        string decorationType = input[1];

                        result = this._controller.AddDecoration(decorationType);
                    }
                    else if (input[0] == "InsertDecoration")
                    {
                        string aquariumName = input[1];
                        string decorationType = input[2];

                        result = this._controller.InsertDecoration(aquariumName, decorationType);
                    }
                    else if (input[0] == "AddFish")
                    {
                        string aquariumName = input[1];
                        string fishType = input[2];
                        string fishName = input[3];
                        string fishSpecies = input[4];
                        decimal price = decimal.Parse(input[5]);

                        result = this._controller.AddFish(aquariumName, fishType, fishName, fishSpecies, price);
                    }
                    else if (input[0] == "FeedFish")
                    {
                        string aquariumName = input[1];

                        result = this._controller.FeedFish(aquariumName);
                    }
                    else if (input[0] == "CalculateValue")
                    {
                        string aquariumName = input[1];

                        result = this._controller.CalculateValue(aquariumName);
                    }
                    else if (input[0] == "Report")
                    {
                        result = this._controller.Report();
                    }

                    this._writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this._writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
