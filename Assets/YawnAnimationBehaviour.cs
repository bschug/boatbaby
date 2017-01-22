using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YawnAnimationBehaviour : StateMachineBehaviour {

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        BabySoundManager.Instance.Yawn();
	}
}
