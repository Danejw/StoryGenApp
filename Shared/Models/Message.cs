namespace StoryGenApp.Shared.Models
{
    public class Message
    {
        public string Text { get; set; }
        public string Sender { get; set; }
        public bool IsEditing { get; set; } = false;
    }
}
