
namespace xAPI.Registry {
    /// <summary>
    /// Provides the definitions of the context uhfReader as public properties.
    /// </summary>
    public class xAPI_Context_UhfReader : xAPI_Context {
        /// <summary>
        /// 6 verbs of 'uhfReader'.
        /// URI: https://xapi.elearn.rwth-aachen.de/definitions/uhfReader/verbs
        /// </summary>
        public readonly xAPI_Verbs_UhfReader verbs = new xAPI_Verbs_UhfReader();

        /// <summary>
        /// 7 activities of 'uhfReader'.
        /// URI: https://xapi.elearn.rwth-aachen.de/definitions/uhfReader/activities
        /// </summary>
        public readonly xAPI_Activities_UhfReader activities = new xAPI_Activities_UhfReader();

        /// <summary>
        /// 5 extensions of 'uhfReader': 4 in context, 1 in result.
        /// URI: https://xapi.elearn.rwth-aachen.de/definitions/uhfReader/extensions
        /// </summary>
        public readonly xAPI_Context_UhfReader_Extensions extensions = new xAPI_Context_UhfReader_Extensions();

        public xAPI_Context_UhfReader() 
            : base("uhfReader") {
        }
    }
}