using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerStay(Collider coll)
    {
        lineOfSight(coll.gameObject);
    }

    // Checks if target is in line of sight
    bool lineOfSight(GameObject target)
    {
        print(target);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, (target.transform.position - transform.position), out hit))
        {
            if(hit.collider == target)
            {
                Debug.DrawLine(transform.position, hit.point, Color.green);
                Debug.Log("BOom");
                return true;
            }
            else
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
                Debug.Log("no");
                return false;
            }
        }
        else
        {
            return false;
        }
    }

}
