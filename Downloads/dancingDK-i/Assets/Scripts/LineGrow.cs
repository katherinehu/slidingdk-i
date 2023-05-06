using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = GameObject.Find("Cube").GetComponent<Renderer>().material.color;
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
