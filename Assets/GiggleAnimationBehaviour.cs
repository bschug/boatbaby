using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiggleAnimationBehaviour : StateMachineBehaviour {

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        BabySoundManager.Instance.Giggle();
	}
}
