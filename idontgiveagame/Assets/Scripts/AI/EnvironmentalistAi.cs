using System;
using idgag.GameState;
using idgag.GameState.LaneSections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace idgag.AI
{
    public class EnvironmentalistAi : AiController
    {
        public float fucksPercentThreshold;

        private new void Awake()
        {
            fucksPercentThreshold = Random.Range(0.50f, 0.75f);
            base.Awake();
        }

        public override void RunAiLogic()
        {
            if (!GameState.GameState.Singleton.fuckBucketPercentages.TryGetValue(FuckBucketTarget.Environment, out float fuckBucketPercent))
                return;

            if (fuckBucketPercent < fucksPercentThreshold)
            {
                TryMoveForward();
            }
            else
            {
                gameObject.SetActive(false);

                if (lane != null)
                    lane.RemoveAiController(this);
            }
        }
    }
}
