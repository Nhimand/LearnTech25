
namespace xAPI.Registry {
    /// <summary>
    /// Provides the definitions of the context voice as public properties.
    /// </summary>
    public class xAPI_Context_Voice : xAPI_Context {
        /// <summary>
        /// 5 verbs of 'voice'.
        /// URI: https://xapi.elearn.rwth-aachen.de/definitions/voice/verbs
        /// </summary>
        public readonly xAPI_Verbs_Voice verbs = new xAPI_Verbs_Voice();

        /// <summary>
        /// 4 activities of 'voice'.
        /// URI: https://xapi.elearn.rwth-aachen.de/definitions/voice/activities
        /// </summary>
        public readonly xAPI_Activities_Voice activities = new xAPI_Activities_Voice();

        /// <summary>
        /// 3 extensions of 'voice': 3 in activity.
        /// URI: https://xapi.elearn.rwth-aachen.de/definitions/voice/extensions
        /// </summary>
        public readonly xAPI_Context_Voice_Extensions extensions = new xAPI_Context_Voice_Extensions();

        public xAPI_Context_Voice() 
            : base("voice") {
        }
    }
}