using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Home
{
    public class Helper
    {
        static public string GenerateGUID()
        {
            System.Guid guid = System.Guid.NewGuid();
            return guid.ToString();
        }
    }
}

