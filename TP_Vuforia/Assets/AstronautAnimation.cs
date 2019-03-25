using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautAnimation : MonoBehaviour
{
    public Animator autreAnimator;

    private Animator m_animator;
    private bool drill = false;
    private bool wave = false;
    private bool idle = true;
    bool isRefilling = false;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Toggle Drilling");
            wave = false;
            m_animator.SetBool("IsWaving", wave);
            drill = !drill;
            m_animator.SetBool("IsDrilling", drill);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Waving");
            drill = false;
            m_animator.SetBool("IsDrilling", drill);
            wave = !wave;
            m_animator.SetBool("IsWaving", wave);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Resetting");
            drill = false;
            wave = false;
            m_animator.SetBool("IsDrilling", drill);
            m_animator.SetBool("IsWaving", wave);
        }
        if((autreAnimator.transform.position - transform.position).sqrMagnitude < 25)
        {
            Debug.LogWarning("on se regarde à la distance " + (autreAnimator.transform.position - transform.position).sqrMagnitude);
            Vector3 target = autreAnimator.transform.position - transform.position;
            Vector3 newRot = Vector3.RotateTowards(transform.forward, target, 10 * Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(newRot);
            drill = false;
            wave = false;
            isRefilling = true;
            m_animator.SetBool("IsDrilling", drill);
            m_animator.SetBool("IsWaving", wave);
            m_animator.SetBool("IsRefilling", isRefilling);

        }
        else
        {
            isRefilling = false;

            m_animator.SetBool("IsRefilling", isRefilling);
            
        }
    }
}
