using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    public static PopUpText INSTANCE;
    public TextMeshProUGUI popUpText;
    public int timer;
    bool triggered = false;
    private void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;


        if (timer == 0)
        {
            timer = 1;
        }
    }
    // Start is called before the first frame update
    public void PopUpMessage(string message, Color color)
    {
        if (!triggered)
        {
            StartCoroutine(showText(message, color));
            return;
        }
        else
        {
            return;
        }
    }
    IEnumerator showText(string message, Color color)
    {triggered = true;
        popUpText.gameObject.SetActive(true);
        popUpText.color = color;
        popUpText.text = message;
        yield return new WaitForSeconds(timer);
        popUpText.gameObject.SetActive(false);
        triggered = false;
    }
}
