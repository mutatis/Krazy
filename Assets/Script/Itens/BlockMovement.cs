using UnityEngine;
using System.Collections;

public class BlockMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

    IEnumerator GoToTarget(Transform target)
    {
        var rnd = new System.Random();
        var dist = Vector3.Distance(target.transform.position, transform.position);
        var direction = (target.transform.position - transform.position).normalized;
        while (dist > .1f)
        {
            
        }
        /*var rnd = new System.Random();
        mouse.quadradoSelecionado = target;
        var dist = Vector3.Distance(target.transform.position, transform.position);
        var direction2 = (target.transform.position - transform.position);
        var noiseDirection = new Vector3(-direction2.y, direction2.x, 0).normalized;
        var magnitudeInicial = direction2.magnitude;
        while (dist > .1f)
        {
            direction2 = (target.transform.position - transform.position);
            var noise = (rnd.NextDouble() + Mathf.Sin(Time.time * 15)) * noiseRange;
            mouse.playingAnimation = true;
            dist = Vector3.Distance(target.transform.position, transform.position);
            Vector3 destination = transform.position + direction2;
            transform.position = Vector3.SmoothDamp(transform.position, destination + (noiseDirection * (float)noise * (dist / magnitudeInicial)), ref velocity, 0.25f);
            yield return new WaitForEndOfFrame();
        }
        mouse.enabled = true;
        mouse.pode = true;
        mouse.quadradoSelecionado = target;
        mouse.playingAnimation = false;*/
        yield return null;
    }
}
