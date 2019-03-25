using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAnimator : MonoBehaviour
{
    public Animator autreAnimator;
    private Animator m_animator;
    private bool scanning = false;
    private bool showingLaser = false;
    private bool facing = true;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Toggle scanning" + scanning);
            showingLaser = false;
            m_animator.SetBool("IsShowingLaser", showingLaser);
            scanning = !scanning;
            m_animator.SetBool("IsScanning", scanning);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Resetting");
            scanning = false;
            showingLaser = false;
            m_animator.SetBool("IsShowingLaser", showingLaser);
            m_animator.SetBool("IsScanning", scanning);
        }


        if ((autreAnimator.transform.position - transform.position).sqrMagnitude < 25)
        {
            Vector3 target = autreAnimator.transform.position - transform.position;
            Vector3 newRot = Vector3.RotateTowards(transform.forward, target, 1, 0);
            transform.rotation = Quaternion.LookRotation(newRot);
        }
    }
}
