using System.Collections.Generic;
using _GAME.Code.Data;
using _GAME.Code.Infrastructure.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME.Code.Features
{
    public class RunTimeDataFeature : MonoBehaviour, IService
    {
        [ReadOnly] public RunTimeData RunTimeData;

        public void Init()
        {
            RunTimeData = new ();
        }
    }
}