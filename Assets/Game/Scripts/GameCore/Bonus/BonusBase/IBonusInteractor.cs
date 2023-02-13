using UnityEngine;
using System.Collections;
namespace BonusBase
{
    public interface IBonusInteractor
    {
        int AddRemainingUse(int remUse,int plusRemUse, int remValue);
        int RemoveRemainingUse(int remUse,int minusRemUse);
    }
}