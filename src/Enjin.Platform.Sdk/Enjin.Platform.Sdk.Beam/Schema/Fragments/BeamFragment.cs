using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A fragment for requesting properties of a <see cref="Beam"/> returned by the platform.
/// </summary>
[PublicAPI]
public class BeamFragment : GraphQlFragment<BeamFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BeamFragment"/> class.
    /// </summary>
    public BeamFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="Beam"/> is to be returned with its <see cref="Beam.Id"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamFragment WithId(bool isIncluded = true)
    {
        return WithField("id", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Beam"/> is to be returned with its <see cref="Beam.Code"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamFragment WithCode(bool isIncluded = true)
    {
        return WithField("code", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Beam"/> is to be returned with its <see cref="Beam.Name"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamFragment WithName(bool isIncluded = true)
    {
        return WithField("name", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Beam"/> is to be returned with its <see cref="Beam.Description"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamFragment WithDescription(bool isIncluded = true)
    {
        return WithField("description", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Beam"/> is to be returned with its <see cref="Beam.Image"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamFragment WithImage(bool isIncluded = true)
    {
        return WithField("image", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Beam"/> is to be returned with its <see cref="Beam.Start"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamFragment WithStart(bool isIncluded = true)
    {
        return WithField("start", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Beam"/> is to be returned with its <see cref="Beam.End"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamFragment WithEnd(bool isIncluded = true)
    {
        return WithField("end", isIncluded);
    }
    
    /// <summary>
    /// Sets the <see cref="Account"/> fragment to be used for getting the <see cref="Beam.Source"/>
    /// property of the <see cref="Beam"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Account"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamFragment WithSource(AccountFragment? fragment)
    {
        return WithField("source", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Collection"/> fragment to be used for getting the <see cref="Beam.Collection"/>
    /// property of the <see cref="Beam"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Collection"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamFragment WithCollection(CollectionFragment? fragment)
    {
        return WithField("collection", fragment);
    }

    /// <summary>
    /// Sets the <see cref="BeamScan"/> fragment to be used for getting the <see cref="Beam.Message"/> property of
    /// the <see cref="Beam"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="BeamScan"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamFragment WithMessage(BeamScanFragment? fragment)
    {
        return WithField("message", fragment);
    }
    
    /// <summary>
    /// Sets whether the <see cref="Beam"/> is to be returned with its <see cref="Beam.IsClaimable"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamFragment WithIsClaimable(bool isIncluded = true)
    {
        return WithField("isClaimable", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Beam"/> is to be returned with its <see cref="Beam.Flags"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamFragment WithFlags(bool isIncluded = true)
    {
        return WithField("flags", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="BeamScan"/> fragment to be used for getting the <see cref="Beam.Qr"/> property of the
    /// <see cref="Beam"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="BeamQr"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamFragment WithQr(BeamQrFragment? fragment)
    {
        return WithField("qr", fragment);
    }
    
    /// <summary>
    /// Sets whether the <see cref="Beam"/> is to be returned with its <see cref="Beam.Probabilities"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamFragment WithProbabilities(bool isIncluded = true)
    {
        return WithField("probabilities", isIncluded);
    }
    
    /// <summary>
    /// Sets the <see cref="BeamScan"/> fragment to be used for getting the <see cref="Beam.Claims"/> property of the
    /// <see cref="Beam"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="BeamQr"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamFragment WithClaims(BeamClaimConnectionFragment? fragment)
    {
        return WithField("claims", fragment);
    }
    
    /// <summary>
    /// Sets whether the <see cref="Beam"/> is to be returned with its <see cref="Beam.ClaimsRemaining"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamFragment WithClaimsRemaining(bool isIncluded = true)
    {
        return WithField("claimsRemaining", isIncluded);
    }
}