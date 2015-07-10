using UnityEngine;
using System.Collections;

public class MouseInteraction : MonoBehaviour {
    //public bool isSelected;
    public bool teleport;
    private GameObject blocoAtual;
    private GameObject quadradoSelecionado;
	// Use this for initialization

    public void OnClickBlock(GameObject block)
    {
        if (block == blocoAtual)
        {
            blocoAtual.SendMessage("OnDeselectBlock");
            blocoAtual = null;
            return;
        }
        if(blocoAtual)
            blocoAtual.SendMessage("OnDeselectBlock");

        blocoAtual = block;
        blocoAtual.SendMessage("OnSelectBlock");
    }

    public void OnClickSquare(GameObject square)
    {
        if (!blocoAtual)
            return;

        if(!square.GetComponent<BlockSquare>().LockBlock(blocoAtual)) 
            return;

        if(quadradoSelecionado)
            quadradoSelecionado.GetComponent<BlockSquare>().UnlockBlock(blocoAtual);
        quadradoSelecionado = square;

        if (teleport)
        {
            square.SendMessage("OnHover");
            blocoAtual.SendMessage("TeleportToTarget", square);
        }
        else
        {
            square.SendMessage("OnHover");
            blocoAtual.GetComponent<Block>().SetTarget(square);
            blocoAtual.SendMessage("OnDeselectBlock");
            blocoAtual = null;
        }
    }   
}
