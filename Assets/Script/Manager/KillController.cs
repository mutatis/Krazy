using UnityEngine;
using System.Collections;

public class KillController : MonoBehaviour 
{

	//public MouseInteraction mouse;

	public void Desativa()
	{
        transform.parent.GetComponent<CircleCollider2D>().enabled = false;
	}

    public void Cancela()
    {
    }

	public void Shatter()
    {
        transform.parent.GetComponentInChildren<DestructibleBlock>().Explodir();
    }

	public void Kill()
	{
        SendMessageUpwards("OnKill");
	}
}
