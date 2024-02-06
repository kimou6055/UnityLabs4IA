using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class Character : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] private float normalSpeed = 2f;
    [SerializeField] private float slowSpeed = 1f;
    private bool inTrigger = false;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        float currentSpeed = inTrigger ? slowSpeed : normalSpeed;
        transform.Translate(new Vector3(0, 0, 1) * currentSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Reward"))
        {
            StartCoroutine(DisableReward(other.gameObject));
        }
        if (other.gameObject.tag.Equals("Water"))
        {
            Debug.Log("Trigger Enter");
            inTrigger = true;
        }
    }

    private IEnumerator DisableReward(GameObject reward)
    {
        // Désactiver le rewards
        reward.SetActive(false);

        // Attendre pendant 2 secondes
        yield return new WaitForSeconds(2f);

        // Réactiver le rewards
        reward.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Plane"))
        {
            Debug.Log("Collision");
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag.Equals("Water"))
    //    {
    //        Debug.Log("Trigger Enter");
    //        inTrigger = true;
    //    }
    //}
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Water"))
        {
            Debug.Log("Trigger Exit");
            inTrigger = false;
        }
    }


}
