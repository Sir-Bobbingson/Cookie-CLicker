using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


[ExecuteInEditMode()]
public class ToolTip : MonoBehaviour
{

    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;
    public LayoutElement layoutElement;
    public int characterWrapLimit;
    public RectTransform rectTransform;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    public void SetText(string content, string header = "")
    {
        headerField.text = header;
        contentField.text = content;
    }

    private void Update()
    {
        if (Application.isEditor) //allows for preview in editor
        {
            int headerLength = headerField.text.Length;             //stores how long header and content are
            int contentLength = contentField.text.Length;

            layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false; //if headerlength or content length
                                                                                                                              //are longer than character wrap
                                                                                                                              //limit then activate Layout element
        }

        Vector2 position = Input.mousePosition;

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY);      //adjusts box so that it doesnt go off screen

        transform.position = position;                          //makes tooltip appear on mouse position
    }

}
