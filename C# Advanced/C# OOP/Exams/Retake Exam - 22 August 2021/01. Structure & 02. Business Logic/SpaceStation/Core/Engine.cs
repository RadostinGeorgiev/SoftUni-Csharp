namespace SpaceStation.Core
{
    using System;
    using System.Linq;

    using Contracts;
    using IO;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IWriter _writer;
        private readonly IReader _reader;
        private readonly IController _controller;

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
                var input = _reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        string astronautType = input[1];
                        string astronautName = input[2];

                        string result = this._controller.AddAstronaut(astronautType, astronautName);

                        this._writer.WriteLine(result);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        string planetName = input[1];
                        string[] items = input
                            .Skip(2)
                            .ToArray();

                        string result = this._controller.AddPlanet(planetName, items);

                        this._writer.WriteLine(result);
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        string astronautName = input[1];

                        string result = this._controller.RetireAstronaut(astronautName);

                        this._writer.WriteLine(result);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        string planetName = input[1];

                        string result = this._controller.ExplorePlanet(planetName);

                        this._writer.WriteLine(result);
                    }
                    else if (input[0] == "Report")
                    {
                        string result = this._controller.Report();

                        this._writer.WriteLine(result);
                    }
                }
                catch (Exception ex)
                {
                    _writer.WriteLine(ex.Message);
                }
            }
        }
    }
}