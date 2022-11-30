using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unfocus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None; //show the cursor
        Cursor.visible = true;
    }
}
