using MatrixAPI.ExtensionMethods;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixAPI.Data.Timeline
{
    public struct RelationshipEvent
    {
        public RelationshipTypes RelationshipType;
        public string RelationshipId;

        public RelationshipEvent(JToken token)
        {
            RelationshipType = token.IfNotNull<RelationshipTypes>("rel_type", RelationshipTypes.none);
            RelationshipId = token.IfNotNull<string>("event_id");

            if (token["m.in_reply_to"] != null)
            {
                RelationshipType = RelationshipTypes.m_reply;
                RelationshipId = token["m.in_reply_to"].IfNotNull<string>("event_id");
            }
        }

        public RelationshipEvent(RelationshipTypes type)
        {
            RelationshipType = type;
            RelationshipId = null;
        }
    }
}
