using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = data[0];
                int id = int.Parse(data[1]);
                string firstName = data[2];
                string lastName = data[3];
                decimal salary;
                string corps;

                switch (type)
                {
                    case "Private":
                        salary = decimal.Parse(data[4]);

                        Private @private = new Private(id, firstName, lastName, salary);
                        soldiers.Add(@private);
                        break;

                    case "LieutenantGeneral":
                        salary = decimal.Parse(data[4]);

                        LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                        foreach (var privateId in data.Skip(5).Select(int.Parse).ToArray())
                        {
                            ISoldier currentPrivate = soldiers.First(x => x.Id == privateId);
                            lieutenantGeneral.AddPrivate(currentPrivate as IPrivate);
                        }

                        soldiers.Add(lieutenantGeneral);
                        break;

                    case "Engineer":
                        salary = decimal.Parse(data[4]);
                        corps = data[5];

                        try
                        {
                            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                            string[] repairPairs = data.Skip(6).ToArray();

                            for (var i = 0; i < repairPairs.Length; i += 2)
                            {
                                string partName = repairPairs[i];
                                int hoursWorked = int.Parse(repairPairs[i + 1]);

                                IRepair repair = new Repair(partName, hoursWorked);
                                engineer.AddRepair(repair);
                            }

                            soldiers.Add(engineer);
                        }
                        catch
                        {
                            continue;
                        }

                        break;

                    case "Commando":
                        salary = decimal.Parse(data[4]);
                        corps = data[5];
                        try
                        {
                            ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                            string[] missionPairs = data.Skip(6).ToArray();

                            for (var i = 0; i < missionPairs.Length; i += 2)
                            {
                                try
                                {
                                    string codeName = missionPairs[i];
                                    string state = missionPairs[i + 1];
                                    IMission mission = new Mission(codeName, state);
                                    commando.AddMission(mission);
                                }
                                catch
                                {
                                }
                            }

                            soldiers.Add(commando);
                        }
                        catch
                        {
                            continue;
                        }
                        break;

                    case "Spy":
                        int codeNumber = int.Parse(data[4]);

                        Spy spy = new Spy(id, firstName, lastName, codeNumber);
                        soldiers.Add(spy);
                        break;
                }
            }

            soldiers.ForEach(Console.WriteLine);
        }
    }
}