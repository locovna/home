using System.Collections;
using System.Collections.Generic;
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
            Character createdCharacter = new Character(100f, 100f, 10f, name, 10f);
            Debug.Log(nameof(CharacterCreator) + " name: " + createdCharacter.name);
            return createdCharacter;
        }
    }
}
