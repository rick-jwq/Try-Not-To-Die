using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelect : MonoBehaviour
{
    public GameObject container;
    // Start is called before the first frame update
    public void selectSkill(GameObject skill)
    {
        GameObject skillStored = GlobalStaticVars.skills.Find(element => element.name.Equals(skill.name));
        if(skillStored)
        {
            GlobalStaticVars.skills.Remove(skill);
        }
        else
        {
            GlobalStaticVars.skills.Add(skill);
        }

        foreach (Transform t in container.transform)
        {
            Destroy(t.gameObject);
        }
        foreach (GameObject skillToAdd in GlobalStaticVars.skills)
        {
            GameObject skillInstance = Instantiate(skillToAdd);
            skillInstance.transform.SetParent(container.transform);
        }
    }
}
