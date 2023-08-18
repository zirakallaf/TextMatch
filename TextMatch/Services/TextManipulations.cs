using TextMatch.Models;

namespace TextMatch.Services;

public class TextManipulations
{
    private readonly string resultNotFoundMessage = "There is no output.";

    /// <summary>
    /// the IsTextMatches method compares SubTex with a new subset
    /// as the same length as SubText from Text.
    /// </summary>
    /// <param name="subText"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    private bool IsTextMatches(Char[] subText, Char[] text)
    {
        for (int i = 0; i < subText.Length; i++)
        {
            if (!subText[i].Equals(text[i]))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// The FindSubTextFrequency method is used to find the frequency of a given SubText from Text.
    /// </summary>
    /// <param name="textForFrequency">the object textForFrequency holds SubText to be searched in Text.</param>
    /// <returns>a string containing a list of the indices of the sub text in the tex Or return a not found message.</returns>
    /// <examples>3,5 Or not found message.</examples>
    public string FindSubTextFrequency(TextForFrequency textForFrequency)
    {
        var positions = new List<int>();

        var textCharList = textForFrequency.Text.ToCharArray();
        var subTextCharList = textForFrequency.SubText.ToCharArray();

        var textCharCounts = textCharList.Length;
        var subTextCharCounts = subTextCharList.Length;

        var newIndex = subTextCharCounts;

        for (int i = 0; i < textCharCounts; i++)
        {
            if (textCharCounts - i < subTextCharCounts) { break; };
            if (IsTextMatches(subTextCharList, textCharList[i..newIndex++]))
            {
                positions.Add(i + 1);
            }
        }

        if (positions.Count > 0)
        {
            return string.Join(",", positions);
        }

        return resultNotFoundMessage;
    }

}