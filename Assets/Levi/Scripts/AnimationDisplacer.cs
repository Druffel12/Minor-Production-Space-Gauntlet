using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDisplacer : MonoBehaviour
{
    Animation anim;
    public string animationName;
    public string root;

	void Start ()
    {
        
	}
	
	public void ChangeAnimation()
    {
        Transform mixTransform = transform.Find(root);

        anim[animationName].AddMixingTransform(mixTransform);
    }
	
}
