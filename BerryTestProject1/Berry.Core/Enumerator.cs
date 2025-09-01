namespace BerryTestProject1.Berry.Core
{
    public enum ResponseIntensity
    {
        StronglyAgree = 2,
        Agree = 1,
        Neutral = 0,
        Disagree = -1,
        StronglyDisagree = -2
    }
    public enum Gender
    {
        male,
        female
    }
    public enum InteractionFrequency
    {
        daily = 1,
        weekly = 2,
        monthly = 3,
        rarely = 4
    }

    public enum ReciprocityLevel
    {
        HighlyReciprocal = 5,
        MostlyReciprocal = 4,
        Neutral = 3,
        MostlyNonReciprocal = 2,
        HighlyNonReciprocal = 1
    }

    public enum FinalResultCategory
    {
        Core = 1,
        InnerCircle = 2,
        Allies = 3,
        OuterCircle = 4,
        QuarantineZone = 5,
        ExclusionZone = 6,
        Neutral = 7
    }
}
