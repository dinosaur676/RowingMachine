using System.Collections;
using UnityEngine;
using UnityEngine.Android;
using UnityStandardAssets.Water;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class SharkPathFollow : MonoBehaviour
    {
        private bool IsStart = false;
        public GameObject water;
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;

        float speed;
        float distanceTravelled;

        IEnumerator SharkStart(float time){
            while(time >= 0.1)
            {
                time -= Time.deltaTime;
                yield return null;
            }
            IsStart = true;
            StartCoroutine(updateSpeed(120.0f));
        }

        

        void Start() 
        {
            StartCoroutine(SharkStart(5.0f));
            speed = 0.0f;
            if (pathCreator != null)
            {
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        { 
            if (pathCreator != null && IsStart)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);

            }

        }

        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        IEnumerator updateSpeed(float seconds)
        {
            TimeUtil.StopWatch stopWatch = new TimeUtil.StopWatch();

            while(stopWatch.Time <= seconds)
            {
                speed = 0.07f * stopWatch.Time / seconds;

                yield return null;
            }
        }
    }
}