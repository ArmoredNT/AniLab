using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UIElements;

public class FollowSpline : MonoBehaviour
{
    [SerializeField] private SplineContainer[] road;
    [SerializeField] private SplineAnimate splineAni;
    [SerializeField] private SplineAnimate splineAni2;

    [SerializeField] bool roadSwitch;
    [SerializeField] bool isSwitching;
    [SerializeField] bool pleaseSwitch;

    [SerializeField] private Transform[] spots;

    private Vector3 pos;
    private Vector3 target;
    private Vector3 moveVec;

    public float speed;

    private float t;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        // if (roadSwitch)
        // {
        //     splineAni.Pause();
        //     splineAni2.Play();
        // }
        // else
        // {
        //     splineAni2.Pause();
        //     splineAni.Play();
        // }
        //
        // if (isSwitching)
        // {
        //     if (roadSwitch)
        //     {
        //         splineAni.Pause();
        //         splineAni2.Pause();
        //         Vector3 pos = transform.position;
        //         Vector3 target = road[1].Splines[0].ToArray()[0].Position;
        //         print(target);
        //
        //         transform.position = target; //+= (target - pos).normalized * 5;
        //     }
        // }

        if (pleaseSwitch)
        {
            pleaseSwitch = false;
            isSwitching = true;
            roadSwitch = !roadSwitch;
            splineAni.Pause();
            splineAni2.Pause();

            if (!roadSwitch)
            {
                pos = transform.position;
                target = spots[1].position;
            }
            else
            {
                pos = transform.position;
                target = spots[0].position;
            }

            moveVec = (target - pos).normalized;
        }

        if (isSwitching)
        {
            
            if (t < 1)
            {
                transform.position = Vector3.Lerp(pos, target, t);
                t += 0.1f * Time.deltaTime;
            }
            else
            {
                t = 0;
                isSwitching = false;
                if (!roadSwitch)
                {
                    splineAni2.Play();
                }
                else
                {
                    splineAni.Play();
                }
            }
            
        }
        
    }
}
