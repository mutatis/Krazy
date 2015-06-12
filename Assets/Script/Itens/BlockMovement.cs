using UnityEngine;
using System.Collections;

public class BlockMovement : MonoBehaviour {
    public GameObject blockCosmetic;
    public float noisePeriod;
    public float noiseAmplitude;
    public float timeArrival;

    public IEnumerator GoToTarget(Transform target, bool useNoise)
    {
        var mouseInteraction = GetComponent<MovMouse>();
        mouseInteraction.pode = false; //can't grab while moving!

        mouseInteraction.quadradoSelecionado = target.gameObject;
        var bloco = mouseInteraction.quadradoSelecionado.GetComponent<BlockSquare>();
        //bloco.ok = false;

        var rnd = new System.Random();
        var dist = Vector3.Distance(target.transform.position, transform.position);
        var distInicial = dist;
        var direction = (target.transform.position - transform.position).normalized;
        float noise = .0f;
        while (dist > .1f)
        {
            dist = Vector3.Distance(target.position, transform.position);
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref direction, timeArrival);
            if (useNoise)
            {
                //oscilates the block cosmetically
                noise = Mathf.Lerp(noise, (Mathf.Sin(Time.time * noisePeriod) * noiseAmplitude + (float)rnd.NextDouble()) * (dist / distInicial), Time.deltaTime * 10);
                var noiseVelocity = new Vector3(-direction.y, direction.x, 0).normalized * noise;
                blockCosmetic.transform.position = transform.position + noiseVelocity;
            }
            yield return new WaitForEndOfFrame();
        }
       
        transform.position = target.position; //ensure deltaTime errors are corrected
        mouseInteraction.pode = true;
        target.SendMessage("UnlockBlock", gameObject);
        yield return new WaitForFixedUpdate();
        if (bloco.blockStack == 0)
            bloco.blockStack++;
        
    }
}
