using System;
using System.Text.RegularExpressions;

namespace LE_NEVEZ_Logan_Tp1
{
    public class ArmeImporteur
    {
        public Dictionary<string, int> textFile;
        public int wordSize = 0;
        public List<string> blackList;

        public ArmeImporteur ()
        {
            textFile = new Dictionary<string, int>();
            blackList = new List<string>();
        }

        public ArmeImporteur(int _wordSize, List<string> _blackList)
        {
            wordSize = _wordSize;
            blackList = _blackList;
        }


        public void frequencyWord(string path)
        {
            Regex regex = new Regex("[.?!,;:]*(?=[.?!,;:]$)");
            string input = regex.Replace(File.ReadAllText(path).ToLower(), "");
            var arr = input.Split(' ');

            foreach (var item in arr)
            {
                if (wordValidation(item))
                {
                    if (textFile.ContainsKey(item))
                        textFile[item]++;
                    else
                        textFile.Add(item, 1);
                }
            }
        }

        public bool wordValidation (string word)
        {
            if (word.Length < wordSize)
                return false;
            if (blackList.Contains(word))
                return false;
            return true;
        }

        public void newWeapon()
        {
            List<Weapon> weapons = new List<Weapon>();
            Random random = new Random();

            foreach (var item in textFile)
            {
                int randomEnum = random.Next(0, 3);
                int reloadTime = random.Next(0, 3);
                weapons.Add(new Weapon(item.Key, item.Value, item.Key.Length, (EWeaponType)randomEnum, reloadTime));
            }

            Armory a = Armory.Instance;
            a.Weapons = weapons;
        }
    }
}
