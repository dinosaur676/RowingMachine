using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameUtil
{
    public enum SceneName
    {
        TRAINING,
        SURVIVE,
        TIMEATTACK,
        MODESELECTION
    }

    public enum SoundName
    {
        WATER_IMPACT
    }

    static public string SCENE_TRAINING = "Training";
    static public string SCENE_SURVIVE = "Survive";
    static public string SCENE_TIMEATTACK = "TimeAttack";
    static public string SCENE_MODESELECTION = "ModeSelection";

    static public string SOUND_WATER_IMPACT = "WaterImpact";
    static public string SOUND_BGM = "BGM";


    static public string getSceneName(SceneName sceneName)
    {
        switch(sceneName)
        {
            case SceneName.TRAINING:
                {
                    return SCENE_TRAINING;
                }
            case SceneName.SURVIVE:
                {
                    return SCENE_SURVIVE;
                }
            case SceneName.TIMEATTACK:
                {
                    return SCENE_TIMEATTACK;
                }
            case SceneName.MODESELECTION:
                {
                    return SCENE_MODESELECTION;
                }
        }

        return null;
    }

    static public string getSoundName(SoundName soundName)
    {
        switch (soundName)
        {
            case SoundName.WATER_IMPACT:
                {
                    return SOUND_WATER_IMPACT;
                }
        }

        return null;
    }
}
