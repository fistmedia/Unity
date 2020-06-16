using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {
	public Rigidbody rb;
	public double G = 6.6743;

	[SerializeField]
	bool _realism = false;

	static List<Attractor> Attractors = new List<Attractor>();

	void Attract(Attractor obj) {
		Rigidbody obj_rb = obj.rb;

		Vector3 dir = rb.position - obj_rb.position;
		float distance2 = dir.sqrMagnitude;

		if (distance2 == 0f)
			return;

		float forceMagnitude = G * rb.mass * obj_rb.mass / distance2;

		Vector3 force = dir.normalized * forceMagnitude;

		obj_rb.AddForce(force);
	}

	void FixedUpdate() {
		foreach (Attractor attr in Attractors)
			if (attr != this)
				Attract(attr);
	}

	void OnEnable() {
		if (_realism)
			G *= Mathf.Pow(10f, -11f);
		//if (!Attractors)
		//	Attractors = new List<Attractor>();

		Attractors.Add(this);
	}

	void OnDisable() {
		Attractors.Remove(this);
	}
}
