using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{

    /*
     * Disclaimer: this script was not written by me. It was provided as part of the free asset packs I was using. 
     * This script was originally written by @Cainos on the Unity Asset Store, and is included as part of the 
     * "Pixel Art Top Down - Basic" package. I have added comments to explain some of the finer details if you're curious,
     * but you are not expected to know how this script works, only be able to implement it. 
     */

    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        public Transform target; //the target we are following

        //"Linear interpolation" = lots of math, it finds out how to "smooth" values between animations
        public float lerpSpeed = 1.0f;
        //by default it is set to 1.0, I normally set it to 0.5. You can find out more information on LERP via Google. 
        
        //the offset distance of the camera to the player
        private Vector3 offset;

        //the player's position (if the camera is set to follow the player's transform)
        private Vector3 targetPos;

        private void Start()
        {
            //if there is no target, don't do anything 
            if (target == null) return;

            //calculate the distance between the camera and the player
            offset = transform.position - target.position;
        }

        private void Update()
        {
            //if there is no target, do nothing
            if (target == null) return;

            //maintain the same offset for the camera, consistency 
            targetPos = target.position + offset;

            //move the camera in relation to the player, smoothly
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }

    }
}
