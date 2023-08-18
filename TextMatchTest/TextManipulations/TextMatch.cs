using TextMatch.Models;
using TextMatch.Services;

namespace TextMatchTest;

public class TextManipulationsTests
{
    [SetUp]
    public void Setup()
    {
    }

    // Positive tests
    [Test]
    [TestCase("polly", "polly", "1")]
    [TestCase("Polly", "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea", "1")]
    [TestCase("polly", "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea", "26,51")]
    public void FindSubTextFrequencyPositive(string subText, string text, string positions)
    {
        // arrange
        var textManipulations = new TextManipulations();
        var textForFrequency = new TextForFrequency { SubText = subText, Text = text };

        // act
        var result = textManipulations.FindSubTextFrequency(textForFrequency);

        // assert
        Assert.IsTrue(result == positions);
    }

    [Test]
    [TestCase("'", "'", "1")]
    [TestCase("''", "''", "1")]
    [TestCase(",", ",", "1")]
    [TestCase("\\", "\\", "1")] // there is one "\" the other one is escaping char
    public void FindSubTextFrequencyPositiveSpecialCharacters(string subText, string text, string positions)
    {
        // arrange
        var textManipulations = new TextManipulations();
        var textForFrequency = new TextForFrequency { SubText = subText, Text = text };

        // act
        var result = textManipulations.FindSubTextFrequency(textForFrequency);

        // assert
        Assert.IsTrue(result == positions);
    }

    // Negative tests
    [Test]
    [TestCase("Polly", "polly", "1")]
    public void FindSubTextFrequencyNegativeDoesNotExists(string subText, string text, string positions)
    {
        // arrange
        var textManipulations = new TextManipulations();
        var textForFrequency = new TextForFrequency { SubText = subText, Text = text };

        // act
        var result = textManipulations.FindSubTextFrequency(textForFrequency);

        // assert
        Assert.IsFalse(result == positions);
    }

    [Test]
    [TestCase("Polly", "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea", "2")] // wrong position
    public void FindSubTextFrequencyNegativeWrongPosition(string subText, string text, string positions)
    {
        // arrange
        var textManipulations = new TextManipulations();
        var textForFrequency = new TextForFrequency { SubText = subText, Text = text };

        // act
        var result = textManipulations.FindSubTextFrequency(textForFrequency);

        // assert
        Assert.IsFalse(result == positions);
    }

    [Test]
    [TestCase("polly", "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea", "1,26,51")]
    public void FindSubTextFrequencyNegativeWrongFrequency(string subText, string text, string positions)
    {
        // arrange
        var textManipulations = new TextManipulations();
        var textForFrequency = new TextForFrequency { SubText = subText, Text = text };

        // act
        var result = textManipulations.FindSubTextFrequency(textForFrequency);

        // assert
        Assert.IsFalse(result == positions);
    }
}