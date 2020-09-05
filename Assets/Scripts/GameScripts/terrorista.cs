using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class terrorista : MonoBehaviour
{

    public Rigidbody2D rb;
    public Rigidbody2D hook;

    public float Seconds = 5f;

    public float maxDragDistance = 4f;
    public float releaseTime = .15f;

    public GameObject nextTerrorist;

    private bool isPressed = false;


    void Update()
    {
        if (isPressed)
        {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
            {
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            }

            else
            {
                rb.position = mousePos;
                Destroy(gameObject, Seconds);
            }
        }

        
    }

  

    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(1f);
        nextTerrorist.SetActive(true);
     
    }

}
