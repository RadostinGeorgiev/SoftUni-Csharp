using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IInhabitant> inhabitants = new List<IInhabitant>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split();

                if (data.Length == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    Citizen citizen = new Citizen(name, age, id);
                    inhabitants.Add(citizen);
                }
                else
                {
                    string model = data[0];
                    string id = data[1];
                    Robot robot = new Robot(model, id);
                    inhabitants.Add(robot);
                }
            }

            string fakeId = Console.ReadLine();

            foreach (var inhabitant in inhabitants)
            {
                if (inhabitant.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(inhabitant.Id);
                }
            }
        }
    }
}