using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : Photon.PunBehaviour, IPunObservable {

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) { } else { }
	}
}