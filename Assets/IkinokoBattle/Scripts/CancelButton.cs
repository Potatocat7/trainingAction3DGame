using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]

public class CancelButton : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            AudioManager.Inscance.Play("cancel");
        });
    }
}
