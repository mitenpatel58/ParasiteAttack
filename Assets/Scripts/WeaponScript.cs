using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Animator animator2;
    public Animator animator3;
    public Animator animator4;
    public bool trigger;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Parasite" && trigger == true)
        {
            trigger = false;
            Debug.Log("Hitted");
            animator2.SetTrigger("Fall");
            //animator3.SetTrigger("Fall");
            Movements.inst.enemies--;
            Destroy(other.gameObject, 2.5f);
            //Destroy(other.gameObject, 2.5f);
        }

        if (other.tag == "Parasite2" && trigger == true)
        {
            trigger = false;
            Debug.Log("Hitted2");
            animator3.SetTrigger("Fall");
            //animator3.SetTrigger("Fall");
            Destroy(other.gameObject, 2.5f);
            Movements.inst.enemies--;

            //Destroy(other.gameObject, 2.5f);
        }

        if (other.tag == "Parasite3" && trigger == true)
        {
            trigger = false;
            Debug.Log("Hitted3");
            animator4.SetTrigger("Fall");
            //animator3.SetTrigger("Fall");
            Destroy(other.gameObject, 2.5f);
            Movements.inst.enemies--;

            //Destroy(other.gameObject, 2.5f);
        }
    }
}
