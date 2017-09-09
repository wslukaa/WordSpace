using UnityEngine;
using System.Collections;

public class ExistingNormalMonster {
    public long index;
    public int HP;
    public int level;
    public Vector3 position;

    public ExistingNormalMonster(long newIndex) {
        index = newIndex;
    }

    public ExistingNormalMonster(long newIndex, int newlevel, Vector3 newposition) {
        index = newIndex;
        level = newlevel;
        position = newposition;
    }
}
