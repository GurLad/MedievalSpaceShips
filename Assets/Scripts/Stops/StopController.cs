using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>StopController</c> chooses a Stop Event from a list of possible stops.
/// </summary>
///
public class StopController : MonoBehaviour
{
    public List<StopEvent> Options;

    public StopEvent Choose()
    {
        Options.Sort((a, b) => a.TimesChosen > b.TimesChosen ? 1 : (a.TimesChosen < b.TimesChosen ? -1 : 0));
        List<StopEvent> minValueOptions = Options.FindAll(a => a.TimesChosen == Options[0].TimesChosen);
        StopEvent chosen = minValueOptions[Random.Range(0, minValueOptions.Count)];
        chosen.TimesChosen++;
        return chosen;
    }
}
