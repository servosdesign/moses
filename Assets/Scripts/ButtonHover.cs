using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    public Button button;
    public Color hoveredColor;
    private Color originalColor;

    void Start()
    {
        originalColor = button.GetComponent<Image>().color;
    }

    public void ChangeOnHover()
    {
        button.GetComponent<Image>().color = hoveredColor;
    }

    public void ChangeOffHover()
    {
        button.GetComponent<Image>().color = originalColor;
    }
}
