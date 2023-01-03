using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public Mapbox.Unity.Map.AbstractMap Map;
    public Texture RenderTexture;
    public int MapSize = 400;
    // Start is called before the first frame update
    // private Texture2D _separatorTexture;
    //     private Texture2D separatorTexture
    //     {
    //         get
    //         {
    //             if (_separatorTexture == null)
    //             {
    //                 _separatorTexture = new Texture2D(1, 1);
    //                 _separatorTexture.SetPixel(0, 0, new Color(0.15f, 0.15f, 0.15f));
    //                 _separatorTexture.Apply();
    //             }

    //             return _separatorTexture;
    //         }
    //     }
    void drawMap()
        {
            var tw = RenderTexture.width;
            var th = RenderTexture.height;

            var scale = MapSize / th;
            var newWidth = scale * tw;
            var x = Screen.width / 2 - newWidth / 2;
            float border;
            if (x < 0)
            {
                border = -x;
            }
            else
            {
                border = 0;
            }


            //GUI.DrawTexture(new Rect(x, Screen.height - MapSize, newWidth, MapSize), RenderTexture, ScaleMode.ScaleAndCrop);
            //GUI.DrawTexture(new Rect(0, Screen.height - MapSize - 20, Screen.width, 20), separatorTexture, ScaleMode.StretchToFill, false);

            var newZoom = GUI.HorizontalSlider(new Rect(0, Screen.height - 60, Screen.width, 60), Map.Zoom, 10, 22);

            if (newZoom != Map.Zoom)
            {
                Map.SetZoom(newZoom);
                Map.UpdateMap();
                // buildMinimapRoute(currentResponse);
            }
        }
    void OnGUI()
        {
            

            float h = Screen.height - MapSize;
            //GUILayout.BeginVertical(new GUIStyle() { padding = new RectOffset(20, 20, 20, 20) }, GUILayout.MaxHeight(h), GUILayout.Height(h));

            var w = Screen.width;

            

            
            //GUILayout.EndHorizontal();
            //UILayout.EndVertical();
           //GUILayout.BeginVertical();

            

            


           // GUILayout.EndVertical();
            
            
            
            drawMap();
        }
}
