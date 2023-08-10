using UnityEngine;

public class ObjectInRange : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject completedText;

    [System.Serializable]
    public struct TargetSet
    {
        public GameObject[] targetObjects; 
        public float detectionRange; 
    }

    public TargetSet[] targetSets; 

    private void Update()
    {
        bool allSetsInRange = true;
        foreach (TargetSet set in targetSets)
        {
            bool allObjectsInRange = true;

            foreach (GameObject targetObject in set.targetObjects)
            {
                float distanceToTarget = Vector3.Distance(playerTransform.position, targetObject.transform.position);
                if (distanceToTarget > set.detectionRange)
                {
                    allObjectsInRange = false;
                    break;
                }
            }
            if (!allObjectsInRange)
            {
                allSetsInRange = false;
                break;
            }
        }

        if (allSetsInRange)
        {
            // Debug.Log("Success! All target sets are within range.");
            completedText.gameObject.SetActive(true);
        }
    }
}
