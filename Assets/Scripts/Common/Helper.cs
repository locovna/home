using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Home
{
    public class Helper : MonoBehaviour
    {
        static public string GenerateGUID()
        {
            System.Guid guid = System.Guid.NewGuid();
            return guid.ToString();
        }

        static public GameObject InstantiateObject(GameObject objectToInstantiate)
        {
            return Instantiate(objectToInstantiate, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
