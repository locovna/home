using UnityEngine;

namespace Home
{
    static public class CharacterCreator
    {
        static private string[] RandomNames =
                        {"Prikolchik","Loshok",
                        "Pips","Chelik",
                        "Caratel","Ulyot",
                        "Chaika","Loh"};

        static public Character CreateRandomizedCharacter()
        {
            string name = RandomNames[Random.Range(0, RandomNames.Length - 1)];
            float randomHealthLimit = Random.Range(100f, 500f);
            float randomSelfDamage = Random.Range(0f, 2f);
            Character createdCharacter = new Character(randomHealthLimit, randomHealthLimit, randomSelfDamage, name, 10f);
            return createdCharacter;
        }
    }
}
