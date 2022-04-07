using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCar : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Animator animator;

   void OnEnable()
   {
       animator.Rebind();
       animator.Update(0f);
       animator.enabled = false;
       StartCoroutine(drive());
   }

   IEnumerator drive()
   {
       yield return new WaitForSeconds(waitTime);
       animator.enabled = true;
       animator.speed = speed;
   }

    
}
