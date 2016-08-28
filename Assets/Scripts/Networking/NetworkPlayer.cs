using UnityEngine;
using System.Collections;

public class NetworkPlayer : Photon.MonoBehaviour
{

    Vector3 realPosition = Vector3.zero;
    Vector3 correctPos = Vector3.zero;
    Quaternion realRotation = Quaternion.identity;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (photonView.isMine)
        {

        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, realPosition, Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, Time.deltaTime);
            gameObject.GetComponent<Rigidbody>().position = Vector3.Lerp(gameObject.GetComponent<Rigidbody>().position, correctPos, Time.deltaTime);

        }

    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // OUTPUT
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(gameObject.GetComponent<Rigidbody>().velocity);
            stream.SendNext(gameObject.GetComponent<Rigidbody>().angularVelocity);
            stream.SendNext(gameObject.GetComponent<Rigidbody>().angularDrag);
            stream.SendNext(gameObject.GetComponent<Rigidbody>().rotation);
            stream.SendNext(gameObject.GetComponent<Rigidbody>().position);
            stream.SendNext(gameObject.GetComponent<Rigidbody>().mass);
            stream.SendNext(gameObject.GetComponent<Rigidbody>().drag);
        }
        else
        {
            // INPUT
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
            gameObject.GetComponent<Rigidbody>().velocity = (Vector3)stream.ReceiveNext();
            gameObject.GetComponent<Rigidbody>().angularVelocity = (Vector3)stream.ReceiveNext();
            gameObject.GetComponent<Rigidbody>().angularDrag = (float)stream.ReceiveNext();
            gameObject.GetComponent<Rigidbody>().rotation = (Quaternion)stream.ReceiveNext();
            gameObject.GetComponent<Rigidbody>().position = (Vector3)stream.ReceiveNext();
            correctPos = gameObject.GetComponent<Rigidbody>().position;
            gameObject.GetComponent<Rigidbody>().mass = (float)stream.ReceiveNext();
            gameObject.GetComponent<Rigidbody>().drag = (float)stream.ReceiveNext();
            realPosition = transform.position;
            realRotation = transform.rotation;
        }
    }

}
