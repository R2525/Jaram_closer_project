using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Captureimg : MonoBehaviour
{
    
	
		//public int superSize = 2;
		//private int _shotIndex = 0;

		private void Update()
		{
			if(Input.GetKeyDown(KeyCode.A)) {
                ScreenCapture.CaptureScreenshot("SomeLevel.png");
				//ScreenCapture.CaptureScreenshot($"Screenshot{_shotIndex}.png", superSize);
				//_shotIndex++;
                Debug.Log("print");

			}
		}
	

}
    

