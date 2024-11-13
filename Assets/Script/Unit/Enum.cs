using System;
[Serializable]
public enum  States 
{
    idle=0,
    move=1,
    attack=2,
    dead=4,
    rolling=8,
    jump=16,
    fall=32,
}
