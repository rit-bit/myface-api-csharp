using System;
using System.Text.Json.Serialization;
using MyFace.Models.Database;

namespace MyFace.Models.Response
{
    public class InteractionResponseModel
    {
        private readonly Interaction _interaction;

        public InteractionResponseModel(Interaction interaction)
        {
            _interaction = interaction;
            Post = new PostSummary(interaction.Post);
            User = new UserSummary(interaction.User);
        }

        public int Id => _interaction.Id;
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public InteractionType Type => _interaction.Type;
        
        public DateTime Date => _interaction.Date;
        
        public PostSummary Post { get; }
        public UserSummary User { get; }
    }
}