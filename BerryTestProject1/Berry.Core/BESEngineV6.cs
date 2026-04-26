using BerryTestProject1.ViewModels;
namespace BerryTestProject1.Berry.Core
{
    public static class BESEngineV6
    {
        public static FinalResultVM InitiateBES(
            List<UserResponseVM> data,
            ReciprocityLevel reciprocity,
            InteractionFrequency frequency,
            int yearsKnown,
            Dictionary<string, int> statementScores)
        {
            if (data == null || data.Count == 0)
            {
                return new FinalResultVM { FinalScore = 0, ResultCategory = FinalResultCategory.Neutral };
            }

            double positiveSum = 0d, negativeSum = 0d;
            var presentCategories = new Dictionary<string, ResponseIntensity>(StringComparer.OrdinalIgnoreCase);

            foreach (var response in data)
            {
                if (response.Intensity == ResponseIntensity.Neutral)
                    continue;
                if (string.IsNullOrEmpty(response.Category)) continue;

                if (!statementScores.TryGetValue(response.Category, out var baseWeight)) continue;

                var intensityModifier = GetIntensityModifier(response.Intensity);

                var score = baseWeight + Math.Sign(baseWeight) * intensityModifier;

                if (baseWeight > 0) positiveSum += score;
                else negativeSum += score;
                if(response.Intensity == ResponseIntensity.StronglyAgree || 
                   response.Intensity == ResponseIntensity.StronglyDisagree)
                {
                    presentCategories.Add(response.Category, response.Intensity);
                }

            }

            bool IsStrong(string key) =>
                presentCategories.TryGetValue(key, out var val) && val == ResponseIntensity.StronglyAgree;

            if (IsStrong("WellWisher") && IsStrong("GrowthCatalyst"))
                positiveSum += 2;

            if (IsStrong("Backstabber") && IsStrong("Manipulator"))
                negativeSum *= 1.2;


            var initialImpact = positiveSum + (negativeSum * 1.3);

            var adjusted = initialImpact * GetReciprocityMultiplier(reciprocity, initialImpact);

            var unscaled = adjusted * GetFrequencyMultiplier(frequency);

            //var longevityAdjusted = unscaled * GetYearsKnownMultiplier(yearsKnown);

            var finalScore = 10 * Math.Tanh(unscaled / 10);

            FinalResultCategory circle = finalScore switch
            {
                >= 8.5 => FinalResultCategory.Core,
                >= 5.0 => FinalResultCategory.InnerCircle,
                >= 2.0 => FinalResultCategory.Allies,
                >= 0 => FinalResultCategory.OuterCircle,
                >= -2.0 => FinalResultCategory.QuarantineZone,
                _ => FinalResultCategory.ExclusionZone 
            };

            return new FinalResultVM
            {
                FinalScore = Math.Round(finalScore, 2),
                ResultCategory = circle
            };
        }

        // ----------------- Helpers -----------------
        private static double GetIntensityModifier(ResponseIntensity intensity) => intensity switch
        {
            ResponseIntensity.StronglyAgree => 2.0,
            ResponseIntensity.Agree => 0.5,
            ResponseIntensity.Neutral => 0.0,
            ResponseIntensity.Disagree => -0.5,
            ResponseIntensity.StronglyDisagree => -2.0,
            _ => 0.0
        };

        private static double GetReciprocityMultiplier(ReciprocityLevel reciprocity, double initialImpact)
        {
            var isPositive = initialImpact >= 0;

            return (reciprocity, isPositive) switch
            {
                (ReciprocityLevel.HighlyReciprocal, true) => 1.40,
                (ReciprocityLevel.MostlyReciprocal, true) => 1.20,
                (ReciprocityLevel.Neutral, true) => 1.00,
                (ReciprocityLevel.MostlyNonReciprocal, true) => 0.85,
                (ReciprocityLevel.HighlyNonReciprocal, true) => 0.70,

                (ReciprocityLevel.HighlyReciprocal, false) => 0.70,
                (ReciprocityLevel.MostlyReciprocal, false) => 0.85,
                (ReciprocityLevel.Neutral, false) => 1.00,
                (ReciprocityLevel.MostlyNonReciprocal, false) => 1.20,
                (ReciprocityLevel.HighlyNonReciprocal, false) => 1.40,

                _ => 1.0
            };
        }

        private static double GetFrequencyMultiplier(InteractionFrequency freq) => freq switch
        {
            InteractionFrequency.daily => 1.30,
            InteractionFrequency.weekly => 1.10,
            InteractionFrequency.monthly => 1.00,
            InteractionFrequency.rarely => 0.90,
            _ => 1.0
        };
        /*private static double GetYearsKnownMultiplier(int yearsKnown) => yearsKnown switch
        {
            < 1 => 1.00,
            < 5 => 1.05,
            < 10 => 1.10,
            _ => 1.15
        };
        */
    }
}
