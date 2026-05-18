using UnityEngine;

public class ResetBlocks : MonoBehaviour
{
    public DraggableBlock[] blocks;

    public DropSlot[] slots;

    public void ReiniciarBloques()
    {
        foreach (DraggableBlock block in blocks)
        {
            block.ResetBlock();
        }

        foreach (DropSlot slot in slots)
        {
            slot.currentBlock = "";
        }

        Debug.Log("Bloques reiniciados");
    }
}