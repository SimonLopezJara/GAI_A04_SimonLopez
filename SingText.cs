using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using TMPro;

public class SingText : MonoBehaviour
{
    [SerializeField] TMP_Text _myText;

    void Start()
    {
        _myText.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other){ _myText.enabled = true; }
    void OnTriggerExit2D(Collider2D collision)
    {
     _myText.enabled=false;
            
    }

}
