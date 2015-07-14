using UnityEngine;
using System.Collections;

public class MouseInteraction : MonoBehaviour {
    //public bool isSelected;
    public bool teleport;
    private GameObject blocoAtual;
    private bool hasSelected;
    public bool HasSelected { get { return hasSelected; } }

    public void OnClickBlock(GameObject block)
    {
        if (block == blocoAtual)
        {
            blocoAtual.SendMessage("OnDeselectBlock");
            blocoAtual = null;
            hasSelected = false;
            return;
        }
        if(blocoAtual)
            blocoAtual.SendMessage("OnDeselectBlock");

        blocoAtual = block;
        blocoAtual.SendMessage("OnSelectBlock");
        hasSelected = true;
    }

    public void OnClickSquare(GameObject square)
    {
        if (!blocoAtual)
            return;

        blocoAtual.GetComponent<BlockMovement>().lockedSquare.GetComponent<BlockSquare>().UnlockBlock(blocoAtual);

        if(!square.GetComponent<BlockSquare>().LockBlock(blocoAtual)) 
            return;

        if (teleport)
        {
            square.SendMessage("OnHover");
            blocoAtual.SendMessage("TeleportToTarget", square);
            blocoAtual.SendMessage("OnDeselectBlock");
            hasSelected = false;
            blocoAtual = null;
        }
        else
        {
            square.SendMessage("OnHover");
            blocoAtual.GetComponent<Block>().SetTarget(square);
            blocoAtual.SendMessage("OnDeselectBlock");
            hasSelected = false;
            blocoAtual = null;
        }
    }   
}
