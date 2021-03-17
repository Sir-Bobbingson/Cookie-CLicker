using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string header;
    public string content;
    public bool hover;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        StartCoroutine(Delay());
        hover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipSystem.Hide();           //calls on method from ToolTipSystem to deactivate tooltip
        hover = false;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        if (hover == true)
        {
            ToolTipSystem.Show(content, header);           //calls on method from ToolTipSystem to activate tooltip
        }
        
    }
}
