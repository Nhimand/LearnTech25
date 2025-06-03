
namespace xAPI.Registry {
    /// <summary>
    /// Provides the definitions of the context exerciseGenerator as public properties.
    /// </summary>
    public class xAPI_Context_ExerciseGenerator : xAPI_Context {
        /// <summary>
        /// 3 verbs of 'exerciseGenerator'.
        /// URI: https://xapi.elearn.rwth-aachen.de/definitions/exerciseGenerator/verbs
        /// </summary>
        public readonly xAPI_Verbs_ExerciseGenerator verbs = new xAPI_Verbs_ExerciseGenerator();

        /// <summary>
        /// 3 activities of 'exerciseGenerator'.
        /// URI: https://xapi.elearn.rwth-aachen.de/definitions/exerciseGenerator/activities
        /// </summary>
        public readonly xAPI_Activities_ExerciseGenerator activities = new xAPI_Activities_ExerciseGenerator();

        /// <summary>
        /// 0 extensions of 'exerciseGenerator': .
        /// URI: https://xapi.elearn.rwth-aachen.de/definitions/exerciseGenerator/extensions
        /// </summary>
        public readonly xAPI_Context_ExerciseGenerator_Extensions extensions = new xAPI_Context_ExerciseGenerator_Extensions();

        public xAPI_Context_ExerciseGenerator() 
            : base("exerciseGenerator") {
        }
    }
}