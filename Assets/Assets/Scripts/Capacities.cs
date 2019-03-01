using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Skill { increaseTime=0, jump, resistanceFire, oneShoot, ghost, openDoor, run, shrink };

public class Capacities : MonoBehaviour
{
    protected int skillPoints = 0;
    protected bool increaseTime, jump, resistanceFire, oneShoot, ghost, openDoor, run, shrink;

    private int numberSkill = 8;
    
	public bool[] skills; 
	public string[] nameSkill;
    public string[] description;
    public int[] prix;

    public virtual void Initialization()
    {
		skills = new bool[numberSkill];
		skills[(int)Skill.jump] = false;
		skills [(int)Skill.run] = false;
		skills [(int)Skill.resistanceFire] = false;
		skills [(int)Skill.openDoor] = false;
		skills [(int)Skill.oneShoot] = false;
		skills [(int)Skill.ghost] = false;
		skills [(int)Skill.shrink] = false;
        skills[(int)Skill.increaseTime] = false;

        description = new string[numberSkill];
        description[(int)Skill.jump] = "Press SPACE to jump.";
        description[(int)Skill.run] = "Hold SHIFT to sprint.";
        description[(int)Skill.resistanceFire] = "Resist naturally to heat and fire.";
        description[(int)Skill.openDoor] = "Press (S) to open doors.";
        description[(int)Skill.oneShoot] = "Press (D) to kill instantly enemies.";
        description[(int)Skill.ghost] = "Hold (W) to can traverse walls.";
        description[(int)Skill.shrink] = "Press CTRL to shrink.";
        description[(int)Skill.increaseTime] = "Increase the lifetime of your psychic images.";

        nameSkill = new string[numberSkill];
        nameSkill[(int)Skill.jump] = "Jump";
        nameSkill[(int)Skill.run] = "Sprint";
        nameSkill[(int)Skill.resistanceFire] = "Heat Resistance";
        nameSkill[(int)Skill.openDoor] = "Open Doors";
        nameSkill[(int)Skill.oneShoot] = "One-Shot Kill";
        nameSkill[(int)Skill.ghost] = "Traverse Walls";
        nameSkill[(int)Skill.shrink] = "Shrink";
        nameSkill[(int)Skill.increaseTime] = "Life Time Increase";

        prix = new int[numberSkill];
        prix[(int)Skill.increaseTime] = 20;
        prix[(int)Skill.jump] = 20;
        prix[(int)Skill.resistanceFire] = 40;
        prix[(int)Skill.oneShoot] = 70;
        prix[(int)Skill.ghost] = 80;
        prix[(int)Skill.openDoor] = 80;
        prix[(int)Skill.run] = 100;
        prix[(int)Skill.shrink] = 100;
    

    }
}
