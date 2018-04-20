using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    // Character is used for both player and opponent
    class Character
    {
        string name;
        int sum;
        int role;

        public Character()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            sum = r.Next(5, 15);
            role = 0;
        }

        public string ReturnString()
        {
            string s = name + ": Role: " + role + ", Sum: " + sum;
            return s;
        }

        public void SetRoleSum(int d, int p)
        {
            role = d;
            sum += p;
        }

        public int GetSum() { return sum; }
        public string GetName() { return name; }
        public void SetName(string newName) { name = newName; }
    }

    // Usage of inheritance that I thought is elegant only adding one functionality for the opponent and using the rest already defined in Character
    class EnemyCharacter : Character
    {
        public EnemyCharacter()
        {
            string[] names = new string[] { "Daniel", "Linus", "Jonathan", "Isaac", "Jason", "Jens", "Amir", "Chaminda", "Krall" };
            Random r = new Random(DateTime.Now.Millisecond);
            int i = names.Length;
            SetName(names[r.Next(i)]);
        }
    }

    class Battle
    {
        List<string> log = new List<string>();

        public void AddToLog(Character p, Character e)
        {
            string s = p.ReturnString() + " -- " + e.ReturnString();
            log.Add(s);
            //            string t = string.Join(", \n", log.ToArray());
            Console.Write(s);
        }
    }

    class Round
    {
        public Round(Character p, Character e, Battle b)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int dicep = r.Next(1, 7);
            int dicee = r.Next(1, 7);
            if (dicep != dicee) // To avoid endless games
            {
                int punishp = dicep, punishe = dicee;

                // Deciding who to punish and how much and also trying to create short code for it
                if (dicep > dicee) { punishe = -dicep; }
                else if (dicee > dicep) { punishp = -dicee; }

                p.SetRoleSum(dicep, punishp);
                e.SetRoleSum(dicee, punishe);
            }
            b.AddToLog(p, e);
        }
    }
}
