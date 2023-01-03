using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading;

public class ScrollUI_2 : MonoBehaviour
{
    
    public GameObject scrollbar;
    public Button button1;
    public Button button2;
    public Button button3;
    
    
    //public GameObject selectButton;
    float scroll_pos = 0;
    bool selectedBtn = false;
    float[] pos;
    Scrollbar scroll;
    //버튼 활성화 
    void showButtonLabels()
        {
            
            button1.gameObject.SetActive(true);
            button2.gameObject.SetActive(true);
            button3.gameObject.SetActive(true);
        }
    //버튼 비활성화  
    void hideButtonLabels()
        {
            
            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);
            button3.gameObject.SetActive(false);

        }
    
    void Start()
    {
        scroll = scrollbar.GetComponent<Scrollbar>();
        
    }

    void Update()
    {
        
        ColorBlock colorBlock1 = button1.colors;
        ColorBlock colorBlock2 = button2.colors;
        ColorBlock colorBlock3 = button3.colors;
        
        pos = new float[transform.childCount];
        float distacne = 1f / (pos.Length - 1);
        for(int i = 0; i< pos.Length; i++)
        {
            pos[i] = distacne * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scroll.value;
        }
        else
        {
            if (!selectedBtn)
            {
                for (int i = 0; i < pos.Length; i++)
                {
                    if (scroll_pos < pos[i] + (distacne / 2) && scroll_pos > pos[i] - (distacne / 2 ))
                    {
                        
                        scroll.value = Mathf.Lerp(scroll.value, pos[i], 0.01f);

                        colorBlock1.normalColor = new Color(1f, 1f, 1f, scroll.value);
                        button1.colors = colorBlock1;
                        colorBlock2.normalColor = new Color(1f, 1f, 1f, scroll.value);
                        button2.colors = colorBlock2;
                        colorBlock3.normalColor = new Color(1f, 1f, 1f, scroll.value);
                        button3.colors = colorBlock3;
                        
                        if(scroll.value == 0)
                        {
                            hideButtonLabels();
                        }
                        else{
                            showButtonLabels();
                            if (scroll.value <0.5)
                            {
                                scroll.value = scroll.value - 0.05f;
                                Thread.Sleep(10);
                            }
                            else if (scroll.value >=0.5)
                            {
                                scroll.value = scroll.value + 0.05f;
                                Thread.Sleep(10);
                            }
                        }
                    }
                }
            }
        }

        
    }
    
    public void ContentsPosition()
    {
        float distacne = 1f / (pos.Length - 1);
        int selectedValue = int.Parse(EventSystem.current.currentSelectedGameObject.transform.GetComponentInChildren<Text>().text)-1;
        StartCoroutine(selectBtn(selectedValue * distacne));
    }

    IEnumerator selectBtn(float targetValue)
    {
        selectedBtn = true;
        while (true)
        {
            yield return null;
            scroll.value = Mathf.Lerp(scroll.value, targetValue, 0.1f);
            if (Mathf.Abs(scroll.value - targetValue) <= 0.1f)
            {
                scroll_pos = scroll.value;
                selectedBtn = false;
                break;
            }
        }
    }
}