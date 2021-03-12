using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string header;
    public string content;
    
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        StartCoroutine(Delay());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipSystem.Hide();           //calls on method from ToolTipSystem to deactivate tooltip
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        ToolTipSystem.Show(content, header);           //calls on method from ToolTipSystem to activate tooltip
    }
}
