using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class link : MonoBehaviour
{

    public string liink = "https://contra.com/lohr_bettina_68155kak";
    public void Open()
    {
        Application.OpenURL(liink);
    }
}
