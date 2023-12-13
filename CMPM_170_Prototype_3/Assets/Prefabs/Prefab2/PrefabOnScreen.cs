using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabOnScreen : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(WaitFor10andDestroy());
    }

   
    private IEnumerator WaitFor10andDestroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
