using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startPos;

    public Camera cam;

    public float parallaxLevel;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position.x; //start pos of camera
        length = GetComponent<SpriteRenderer>().bounds.size.x; //the length of our background
    }

    // Update is called once per frame
    void Update()
    {
        float movedRelative = (cam.transform.position.x * (1 - parallaxLevel)); //how far we have moved, relative to the camera
        float parallaxDist = (cam.transform.position.x * parallaxLevel);

        transform.position = new Vector3(startPos + parallaxDist, this.transform.position.y, this.transform.position.z);

        //this section of code allows the background to repeat
        if (movedRelative > startPos + length)
        {
            startPos += length;
        } else if (movedRelative < startPos - length)
        {
            startPos -= length; 
        }
    }
}
