using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayForeEver : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("backgroundMusic");
        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
