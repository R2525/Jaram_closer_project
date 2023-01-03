using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class  onclickbutton: MonoBehaviour
{
    Image btnImage;

    public void GetBtn ()
    {
        GameObject tempBtn = EventSystem.current.currentSelectedGameObject;
        Debug.Log(tempBtn);
    }

}
