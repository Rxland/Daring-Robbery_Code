using System.Collections.Generic;
using UnityEngine;

namespace _GAME.Code.StaticData
{
    [CreateAssetMenu(fileName = "Customers Main Static Data", menuName = "Static Data/Customer/Customers Main", order = 0)]
    public class CustomersMainStaticData : ScriptableObject
    {
        public List<RuntimeAnimatorController> AnimatorControllersForRandomReplace;
    }
}