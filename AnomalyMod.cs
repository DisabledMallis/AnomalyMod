using UnityEngine;

namespace AnomalyMod
{
    public class AnomalyMod
    {
        public static void Start()
        {
            AnomalyMod.LoaderObject = new UnityEngine.GameObject();
            AnomalyMod.LoaderObject.AddComponent<ModObject>();
            UnityEngine.Object.DontDestroyOnLoad(AnomalyMod.LoaderObject);
        }

        public static void Unload()
        {
            _Unload();
        }

        private static void _Unload()
        {
            GameObject.Destroy(AnomalyMod.LoaderObject);
        }

        private static GameObject? LoaderObject;
    }
}