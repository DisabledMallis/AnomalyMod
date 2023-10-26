using UnityEngine;

namespace AnomalyMod
{
    class ModObject : MonoBehaviour
    {
        private GameManager? manager;

        public void OnGUI()
        {
            var windowRect = GUI.Window(0, new Rect(100, 100, 200, 400), DoWindow, "Mod Menu");

            if(manager == null)
            {
                return;
            }

            var anomalies = manager.Anomalies;
            if (anomalies == null)
                return;

            foreach (var anomaly in anomalies)
            {
                if(anomaly.Active)
                {
                    foreach (var obj in anomaly.Objects)
                    {
                        Vector3 objectPos = obj.transform.position;
                        Vector3 objectFootPos; objectFootPos.x = objectPos.x; objectFootPos.z = objectPos.z; objectFootPos.y = objectPos.y - 0.2f; //At the feet
                        Vector3 objectHeadPos; objectHeadPos.x = objectPos.x; objectHeadPos.z = objectPos.z; objectHeadPos.y = objectPos.y + 0.2f; //At the head

                        //Screen Position
                        Vector3 w2s_footpos = Camera.main.WorldToScreenPoint(objectFootPos);
                        Vector3 w2s_headpos = Camera.main.WorldToScreenPoint(objectHeadPos);

                        if (w2s_footpos.z > 0f)
                        {
                            DrawBoxESP(w2s_footpos, w2s_headpos, Color.red);
                        }

                        GUI.Label(new Rect(w2s_footpos.x, Screen.height - w2s_footpos.y, 1000, 100), anomaly.AnomalyType);
                    }
                }
            }
        }

        public void DoWindow(int windowId)
        {
            // Make a very long rect that is 20 pixels tall.
            // This will make the window be resizable by the top
            // title bar - no matter how wide it gets.
            GUI.DragWindow(new Rect(0, 0, 10000, 20));

            if (manager == null)
            {
                GUI.Label(new Rect(10, 20, 1000, 20), "No GameManager");
                return;
            }

            var anomalies = manager.Anomalies;
            if (anomalies == null)
            {
                GUI.Label(new Rect(10, 20, 1000, 20), "No anomalies (null)");
                return;
            }
            else
            {
                int activeCount = 0;
                foreach (var anomaly in anomalies)
                {
                    if (anomaly.Active)
                    {
                        activeCount++;
                    }
                }

                if (activeCount == 0)
                {
                    GUI.Label(new Rect(10, 20, 1000, 20), "No anomalies (0 active)");
                }
                else
                {
                    GUI.Label(new Rect(10, 20, 1000, 20), activeCount + " active anomalies");
                }
            }

            GUI.Label(new Rect(10, 40, 1000, 20), "Anomaly Timer:" + manager.Timer);
        }

        public void DrawBoxESP(Vector3 footpos, Vector3 headpos, Color color) //Rendering the ESP
        {
            float height = headpos.y - footpos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;

            //ESP BOX
            Render.DrawBox(footpos.x - (width / 2), (float)Screen.height - footpos.y - height, width, height, color, 2f);

            //Snapline
            Render.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(footpos.x, (float)Screen.height - footpos.y), color, 2f);
        }

        public void Update()
        {
            manager = UnityEngine.Object.FindObjectOfType<GameManager>();
        }
    }
}
