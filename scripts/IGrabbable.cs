using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabbable
{
    void OnPickup();
    void OnRelease();
}
