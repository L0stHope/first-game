using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TextHoverHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text textMeshPro;
    public Color normalColor = Color.black;
    public Color hoverColor = Color.white;

    void Start()
    {
        if (textMeshPro == null)
            textMeshPro = GetComponent<TMP_Text>();

        textMeshPro.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textMeshPro.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textMeshPro.color = normalColor;
    }
}