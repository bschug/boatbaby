using UnityEngine;

namespace Assets.Scripts.System
{
    public class NeverSleep : MonoBehaviour
    {
        private void Start()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}
