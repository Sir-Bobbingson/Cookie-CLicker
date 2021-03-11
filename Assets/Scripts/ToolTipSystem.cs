using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipSystem : MonoBehaviour
{
    private static ToolTipSystem current;

    public ToolTip ToolTip;

    public void Awake()
    {
        current = this;
    }

    public static void Show(string content, string header = "")
    {
        current.ToolTip.SetText(content, header);           //sets text for tooltip
        current.ToolTip.gameObject.SetActive(true);         //sets tooltip active
    }

    public static void Hide()
    {
        current.ToolTip.gameObject.SetActive(false);        //deactivates tooltip
    }
}
