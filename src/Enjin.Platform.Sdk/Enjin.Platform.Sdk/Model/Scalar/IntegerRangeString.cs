using System;
using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Represents an inclusive range between two integer <see cref="string"/> values.
/// </summary>
[JsonConverter(typeof(IntegerRangeStringJsonConverter))]
[PublicAPI]
public readonly struct IntegerRangeString
{
    private readonly string _str;

    /// <summary>
    /// The starting value of this range.
    /// </summary>
    public readonly BigInteger Start;

    /// <summary>
    /// The ending value of this range.
    /// </summary>
    public readonly BigInteger End;

    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerRange"/> struct with the given value.
    /// </summary>
    /// <param name="value">The value representing the whole range.</param>
    public IntegerRangeString(string value) : this(value, value)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerRange"/> struct with the given starting and ending values.
    /// </summary>
    /// <param name="start">The starting value.</param>
    /// <param name="end">The ending value.</param>
    /// <exception cref="ArgumentException">
    /// Thrown if the starting value is greater than the ending value.
    /// </exception>
    public IntegerRangeString(string start, string end)
    {
        Start = BigInteger.Parse(start);
        End = BigInteger.Parse(end);
        
        if (Start > End)
        {
            throw new ArgumentException($"{nameof(start)} cannot be greater than {nameof(end)}");
        }

        _str = Start == End
            ? Start.ToString()
            : Start + ".." + End;
    }

    /// <summary>
    /// Returns the string representing this range.
    /// </summary>
    /// <returns>The string representing this range.</returns>
    /// <remarks>
    /// <para>
    /// If <see cref="Start"/> and <see cref="End"/> are not equal, then the returned string will be the starting and
    /// ending values separated by two periods. For example, if the starting value is <c>3</c> and the ending value is
    /// <c>8</c>, then the string will be returned as <c>3..8</c>.
    /// </para>
    /// <para>
    /// If the values are equal, then the returned string will be the string representing
    /// the shared value.
    /// </para>
    /// </remarks>
    public override string ToString()
    {
        return _str;
    }
}