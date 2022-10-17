using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class SharkPathFollow_EX : MonoBehaviour
    {
        private GameObject water;
        private PathCreator pathCreator;
        private EndOfPathInstruction endOfPathInstruction;
        float distanceTravelled;

        void Start()
        {
            endOfPathInstruction = EndOfPathInstruction.Loop;
            water = GameObject.FindGameObjectWithTag("water");
            pathCreator = water.GetComponent<PathCreator>();

            distanceTravelled += Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += (float)SpeedManager.Instance.BoatSpeed / 101 * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);

            }


            transform.position = new Vector3(transform.position.x, WaveManager.Instance.GetWaveHeight(transform.position.x, water.transform.localScale.x), transform.position.z);
        }
        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path

    }
}