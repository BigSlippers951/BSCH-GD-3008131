using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    
    [SerializeField]
    private ScoreScript scoreScript;

    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private Transform rayPoint;
    [SerializeField]
    private float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;


    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");    
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, Vector2.right * transform.localScale, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (Input.GetKeyDown(KeyCode.E) && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
                scoreScript.CurrentScore += 1;
                Destroy(grabbedObject);
            }
        }
    }

    public void drop()
    {
        grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
        grabbedObject.transform.SetParent(null);
        grabbedObject = null;
    }
}
