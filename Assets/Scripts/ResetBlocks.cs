using UnityEngine;

public class ResetBlocks : MonoBehaviour
{
    public DraggableBlock[] blocks;

    public DropSlot[] slots;

    public void ReiniciarBloques()
    {
        // Reiniciar bloques
        foreach (DraggableBlock block in blocks)
        {
            block.ResetBlock();
        }

        // Limpiar slots
        foreach (DropSlot slot in slots)
        {
            slot.currentBlock = "";
        }

        Debug.Log("Bloques reiniciados");
    }
}