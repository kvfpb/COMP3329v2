// using UnityEngine;

// public class Ball : Photon.MonoBehaviour, IPunObservable {

//     // Vector3 _networkPosition;
//     // Quaternion _networkRotation;
//     // Rigidbody _rb;

//     // public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
//     // {
//     //     if (stream.isWriting)
//     //     {
//     //         stream.SendNext(_rb.position);
//     //         stream.SendNext(_rb.rotation);
//     //         stream.SendNext(_rb.velocity);
//     //     }
//     //     else
//     //     {
//     //         _networkPosition = (Vector3)stream.ReceiveNext();
//     //         _networkRotation = (Quaternion)stream.ReceiveNext();
//     //         _rb.velocity = (Vector3)stream.ReceiveNext();

//     //         float lag = Mathf.Abs((float)(PhotonNetwork.time - info.timestamp));
//     //         _networkPosition += (_rb.velocity * lag);
//     //     }
//     // }

//     // void Start()
//     // {
//     //     _rb = GetComponent<Rigidbody>();
//     // }

//     // public void FixedUpdate()
//     // {
//     //     if (!photonView.isMine)
//     //     {
//     //         _rb.position = Vector3.MoveTowards(_rb.position, _networkPosition, Time.fixedDeltaTime);
//     //         _rb.rotation = Quaternion.RotateTowards(_rb.rotation, _networkRotation, Time.fixedDeltaTime * 100.0f);
//     //     }
//     // }
// }