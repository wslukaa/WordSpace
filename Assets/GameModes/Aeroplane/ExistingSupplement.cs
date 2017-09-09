using UnityEngine;
using System.Collections;

public class ExistingSupplement{

    public long index;
    public int type;
    public Vector3 position;

    public ExistingSupplement(long newIndex)
    {
        index = newIndex;
    }

    public ExistingSupplement(long newIndex, int newtype, Vector3 newposition)
    {
        index = newIndex;
        type = newtype;
        position = newposition;
    }
}
