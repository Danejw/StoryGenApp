using Newtonsoft.Json;
using OpenAI_API.Chat;
using System.Diagnostics;

namespace StoryGenApp.Shared.Models
{
    public class SerializableChatMessage
    {
        [JsonProperty("role")]
        public string? Role { get; set; }

        [JsonProperty("content")]
        public string? Content { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        public SerializableChatMessage(string role = null, string content = null, string name = null)
        {
            Role = role;
            Content = content;
            Name = name;
        }

        public ChatMessage ToChatMessage()
        {
            var role = ChatMessageRole.FromString(Role);
            var content = Content;
            var name = Name;

            var chatMessage = new ChatMessage();

            if (role != null)
                chatMessage.Role = role;

            if (content != null)
                chatMessage.Content = content;

            if (name != null)
                chatMessage.Name = name;

            return chatMessage;
        }

        public static List<ChatMessage> ToChatMessages(List<SerializableChatMessage> serialiableMessages)
        {
            List<ChatMessage> chatMessages = new List<ChatMessage>();

            foreach (var message in serialiableMessages)
            {
                chatMessages.Add(message.ToChatMessage());
            }

            return chatMessages;
        }

        public static SerializableChatMessage FromMessage(Message message)
        {
            // You will have to determine how to map the Message properties to the SerializableChatMessage properties.
            // This is just an example and might need to be adapted to your actual needs.
            return new SerializableChatMessage
            {
                Role = message.Sender, // or something else depending on your application
                Content = message.Text,
                Name = message.Sender // or something else depending on your application
            };
        }

    }

}
