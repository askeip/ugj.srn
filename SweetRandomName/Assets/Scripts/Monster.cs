using UnityEngine;
using System.Collections;

public class Monster : DarkObject {
    public int damage;

	void Start () {
        PreStart();
	}
	
	void Update () {
        ChangeWorld();
	}
}
